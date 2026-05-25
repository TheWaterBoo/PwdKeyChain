using System.Security.Cryptography;
using PwdKeychain.Interfaces;

namespace PwdKeychain.Implementations
{
    public class CryptNDecrypt : ICryptNDecrypt
    {
        public string Encrypter(string pwd, out string key)
        {
            var encryptionKey = KeyGen();
            var iv = IvGen();
            
            using (var aes = Aes.Create())
            {
                aes.Key = encryptionKey;
                aes.IV = iv;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(pwd);
                    }

                    var encrypted = memoryStream.ToArray();
                    key = Convert.ToBase64String(encryptionKey);

                    return Convert.ToBase64String(iv.Concat(encrypted).ToArray());
                }
            }
        }

        public string Decrypter(string zipedPwd, string key)
        {
            var tempKey = Convert.FromBase64String(key);
            var fullCipher = Convert.FromBase64String(zipedPwd);

            const int ivSize = 16;
            if (fullCipher.Length < ivSize)
                throw new FormatException("The cipher text is too short to contain the Initialization Vector");
            
            var tempIv = new byte[ivSize];
            Array.Copy(fullCipher, tempIv, tempIv.Length);
            
            var cipher = new byte[fullCipher.Length - tempIv.Length];
            Array.Copy(fullCipher, tempIv.Length, cipher, 0, cipher.Length);

            using (var aes = Aes.Create())
            {
                aes.Key = tempKey;
                aes.IV = tempIv;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream(cipher))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    using (var streamReader = new StreamReader(cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }

        //Generates a pseudo-random key
        private static byte[] KeyGen()
        {
            using (var aes = Aes.Create())
            {
                aes.GenerateKey();
                return aes.Key;
            }
        }

        //Generates a pseudo-random iv
        private static byte[] IvGen()
        {
            using (var aes = Aes.Create())
            {
                aes.GenerateIV();
                return aes.IV;
            }
        }
    }
}