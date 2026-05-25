using System.Security.Cryptography;
using System.Text;
using PwdKeychain.Interfaces;

namespace PwdKeychain.Implementations
{
    public class CryptNDecrypt(string masterPass) : ICryptNDecrypt
    {
        public string Encrypter(string pwd, string id)
        {
            var encryptionKey = DeriveKeyFromContext(masterPass, id);
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

                    return Convert.ToBase64String(iv.Concat(encrypted).ToArray());
                }
            }
        }

        public string Decrypter(string zipedPwd, string id)
        {
            var fullCipher = Convert.FromBase64String(zipedPwd);

            const int ivSize = 16;
            if (fullCipher.Length < ivSize)
                throw new FormatException("The cipher text is too short to contain the Initialization Vector");
            
            var tempIv = new byte[ivSize];
            Array.Copy(fullCipher, tempIv, tempIv.Length);
            
            var cipher = new byte[fullCipher.Length - tempIv.Length];
            Array.Copy(fullCipher, tempIv.Length, cipher, 0, cipher.Length);
            
            var tempKey = DeriveKeyFromContext(masterPass, id);

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

        private static byte[] DeriveKeyFromContext(string masterPassword, string id)
        {
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(masterPassword);
            var pepperBytes = Encoding.UTF8.GetBytes(id); // El id se usa como sazonador para generar claves distintas
            using (var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, pepperBytes, 10000, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(32);
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