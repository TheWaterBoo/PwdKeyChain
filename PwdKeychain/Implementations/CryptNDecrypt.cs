using System.Security.Cryptography;
using System.Text;
using PwdKeychain.Interfaces;

namespace PwdKeychain.Implementations
{
    public class CryptNDecrypt : ICryptNDecrypt
    {
        private readonly byte[] _masterKey;
        private const int Pbkdf2Iterations = 600000;

        public CryptNDecrypt(string masterPassword, byte[] masterSalt)
        {
            if (string.IsNullOrWhiteSpace(masterPassword))
                throw new ArgumentException("Master password cannot be null or empty!");
            if (masterSalt == null || masterSalt.Length < 16)
                throw new ArgumentException("Master salt must be at least 16 bytes long");

            _masterKey = DeriveKey(masterPassword, masterSalt, 32);
        }

        public static (byte[] Hash, byte[] Salt) CreateMasterHash(string masterPassword)
        {
            var paprika = RandomNumberGenerator.GetBytes(16);
            var hash = DeriveKey(masterPassword, paprika, 32);
            return (hash, paprika);
        }

        public static bool ValidateMasterPassword(string inputPassword, byte[] storedHash, byte[] storedSalt)
        {
            var computedHash = DeriveKey(inputPassword, storedSalt, 32);
            return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
        }

        public string Encrypter(string data, string id)
        {
            var encryptionKey = DeriveKeyFromContext(_masterKey, id);
            var iv = IvGen();

            using (var aes = Aes.Create())
            {
                aes.Key = encryptionKey;
                aes.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    memoryStream.Write(iv, 0, iv.Length);
                    
                    using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (var streamWriter = new StreamWriter(cryptoStream, Encoding.UTF8))
                    {
                        streamWriter.Write(data);
                    }

                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        public string Decrypter(string encryptedData, string id)
        {
            var fullCipher = Convert.FromBase64String(encryptedData);
            const int ivSize = 16;
            
            if (fullCipher.Length < ivSize)
                throw new FormatException("The cipher text is too short to contain the Initialization Vector");

            var iv = new byte[ivSize];
            Array.Copy(fullCipher, iv, ivSize);

            var cipher = new byte[fullCipher.Length - ivSize];
            Array.Copy(fullCipher, ivSize, cipher, 0, cipher.Length);
    
            var decryptionKey = DeriveKeyFromContext(_masterKey, id);

            using (var aes = Aes.Create())
            {
                aes.Key = decryptionKey;
                aes.IV = iv;

                using (var memoryStream = new MemoryStream(cipher)) 
                using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (var streamReader = new StreamReader(cryptoStream, Encoding.UTF8))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        private static byte[] DeriveKey(string password, byte[] salt, int outputBytes)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            using var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, salt, Pbkdf2Iterations, HashAlgorithmName.SHA256);
            return pbkdf2.GetBytes(outputBytes);
        }

        private static byte[] DeriveKeyFromContext(byte[] masterKey, string id)
        {
            var contextBytes = Encoding.UTF8.GetBytes(id);
            return HKDF.DeriveKey(HashAlgorithmName.SHA256, masterKey, 32, contextBytes);
        }

        //Generates a pseudo-random iv
        private static byte[] IvGen()
        {
            return RandomNumberGenerator.GetBytes(16);
        }
    }
}