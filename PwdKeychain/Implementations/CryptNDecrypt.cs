using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using PwdKeychain.Interfaces;

namespace PwdKeychain.Implementations
{
    public class CryptNDecrypt : ICryptNDecrypt
    {
        private byte[] _key;

        public string Encrypter(string? plainText, out string key)
        {
            _key = KeyGen();
            byte[] iv = IvGen();

            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    byte[] encrypted = msEncrypt.ToArray();
                    key = Convert.ToBase64String(_key);
                    
                    return Convert.ToBase64String(iv.Concat(encrypted).ToArray());
                }
            }
        }

        public string Decrypter(string cipherText, string key)
        {
            try
            {
                byte[] tempKey = Convert.FromBase64String(key);
                byte[] fullCipher = Convert.FromBase64String(cipherText);

                byte[] tempIv = new byte[16];
                byte[] cipher = new byte[fullCipher.Length - tempIv.Length];
                Array.Copy(fullCipher, tempIv, tempIv.Length);
                Array.Copy(fullCipher, tempIv.Length, cipher, 0, cipher.Length);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = tempKey;
                    aes.IV = tempIv;

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(cipher))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            string plaintext = srDecrypt.ReadToEnd();

                            return plaintext;
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        
        //Generates a pseudo-random key
        private byte[] KeyGen()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                return aes.Key;
            }
        }

        //Generates a pseudo-random iv
        private byte[] IvGen()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateIV();
                return aes.IV;
            }
        }
    }
}