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
            var key = DeriveKeyFromContext(_masterKey, id);

            var nonce = RandomNumberGenerator.GetBytes(12);

            var plaintext = Encoding.UTF8.GetBytes(data);

            var cipher = new byte[plaintext.Length];

            var tag = new byte[16];

            using var aes = new AesGcm(key, 16);

            aes.Encrypt(
                nonce,
                plaintext,
                cipher,
                tag
            );

            var result = new byte[
                nonce.Length +
                tag.Length +
                cipher.Length
            ];

            Buffer.BlockCopy(nonce, 0, result, 0, nonce.Length);
            Buffer.BlockCopy(tag, 0, result, nonce.Length, tag.Length);
            Buffer.BlockCopy(cipher, 0, result,
                nonce.Length + tag.Length,
                cipher.Length);

            return Convert.ToBase64String(result);
        }

        public string Decrypter(string encryptedData, string id)
        {
            var key = DeriveKeyFromContext(_masterKey, id);

            var data = Convert.FromBase64String(encryptedData);

            var nonce = new byte[12];
            var tag = new byte[16];

            Array.Copy(data, 0, nonce, 0, 12);
            Array.Copy(data, 12, tag, 0, 16);

            var cipherLength = data.Length - 28;

            var cipher = new byte[cipherLength];

            Array.Copy(
                data,
                28,
                cipher,
                0,
                cipherLength
            );

            var plaintext = new byte[cipherLength];

            using var aes = new AesGcm(key, 16);

            aes.Decrypt(
                nonce,
                cipher,
                tag,
                plaintext
            );

            return Encoding.UTF8.GetString(plaintext);
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