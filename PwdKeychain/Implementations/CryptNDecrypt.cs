using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using PwdKeychain.Interfaces;
using PwdKeychain.Utils;

namespace PwdKeychain.Implementations
{
    public class CryptNDecrypt : ICryptNDecrypt
    {
        private byte[] _key;

        public string Encrypter(string pwd, out string key)
        {
            try
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
                            swEncrypt.Write(pwd);
                        }

                        byte[] encrypted = msEncrypt.ToArray();
                        key = Convert.ToBase64String(_key);

                        return Convert.ToBase64String(iv.Concat(encrypted).ToArray());
                    }
                }
            }
            catch (FormatException ex)
            {
                HandleException(ex, nameof(Encrypter), [pwd], "FormatException", 1);
                key = "";
                return "";
            }
            catch (Exception ex)
            {
                HandleException(ex, nameof(Encrypter), [pwd], "Exception", 2);
                key = "";
                return "";
            }
        }

        public string Decrypter(string zipedPwd, string key)
        {
            try
            {
                byte[] tempKey = Convert.FromBase64String(key);
                byte[] fullCipher = Convert.FromBase64String(zipedPwd);

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
                HandleException(ex, nameof(Decrypter), [zipedPwd, key], "FormatException", 1);
                return "";
            }
            catch (Exception ex)
            {
                HandleException(ex, nameof(Decrypter), [zipedPwd, key], "Exception", 1);
                return "";
            }
        }

        private static void HandleException(Exception ex, string? method, object[]? args, string title, int exitCode)
        {
            var customEx = new CustomExceptions(ex, nameof(CryptNDecrypt), method, args);
            customEx.ShowErrDialog(title, exitCode);
        }

        //Generates a pseudo-random key
        private static byte[] KeyGen()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                return aes.Key;
            }
        }

        //Generates a pseudo-random iv
        private static byte[] IvGen()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateIV();
                return aes.IV;
            }
        }
    }
}