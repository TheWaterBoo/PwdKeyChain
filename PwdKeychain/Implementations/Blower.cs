using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PwdKeychain.Interfaces;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;

namespace PwdKeychain.Implementations
{
    public class Blower : IBlower
    {
        private readonly IBlockCipherPadding _padding;
        private byte[] _key;
        private byte[] _firstPart;
        private byte[] _secondPart;

        public Blower()
        {
            _padding = new Pkcs7Padding();
        }

        public string Encrypter(string plainText, out string key)
        {
            _key = KeyGen();
            byte[] iv = IVGen();

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
        
        /*public string Encrypter(string pwd)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(pwd);
            byte[] encryptOutput = CryptNDecrypt(inputBytes, true);
            //byte[] finalOutput = EncryptMilkshake(encryptOutput);
            string finalOutput = Convert.ToBase64String(encryptOutput) + Convert.ToBase64String(_key);
            //return Convert.ToBase64String(encryptOutput);
            return finalOutput;
        }*/

        public string Decrypter(string cipherText, string key)
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
        
        public byte[] KeyGen()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                return aes.Key;
            }
        }

        public byte[] IVGen()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateIV();
                return aes.IV;
            }
        }
        
        /*public string Decrypter(string zipedPwd)
        {
            byte[] decodedCipherText = Convert.FromBase64String(zipedPwd);
            byte[] encryptedText = MilkshakeExtractor(decodedCipherText);
            byte[] decryptOutput = CryptNDecrypt(encryptedText, false);
            return Encoding.UTF8.GetString(decryptOutput);
        }*/

        private byte[] CryptNDecrypt(byte[] inputBytes, bool forEncrypt)
        {
            BufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new BlowfishEngine(), _padding);
            cipher.Init(forEncrypt, new KeyParameter(_key));

            byte[] outputBytes = new byte[cipher.GetOutputSize(inputBytes.Length)];
            int length = cipher.ProcessBytes(inputBytes, 0, inputBytes.Length, outputBytes, 0);
            cipher.DoFinal(outputBytes, length);

            return outputBytes;
        }
        
        private void ShardGen()
        {
            int halfLenght = _key.Length / 2;

            _firstPart = new byte[halfLenght];
            _secondPart = new byte[halfLenght];

            Array.Copy(_key, 0, _firstPart, 0, halfLenght);
            Array.Copy(_key, halfLenght, _secondPart, 0, halfLenght);
        }

        private byte[] EncryptMilkshake(byte[] encryptOutput)
        {
            byte[] finalOutput = new byte[_firstPart.Length + encryptOutput.Length + _secondPart.Length];
            Array.Copy(_firstPart, 0, finalOutput, 0, _firstPart.Length);
            Array.Copy(encryptOutput, 0, finalOutput, _firstPart.Length, encryptOutput.Length);
            Array.Copy(_secondPart, 0, finalOutput, _firstPart.Length + encryptOutput.Length, _secondPart.Length);

            return finalOutput;
        }

        private byte[] MilkshakeExtractor(byte[] decodedCipherText)
        {
            byte[] key1 = decodedCipherText.Take(_firstPart.Length).ToArray();
            byte[] key2 = decodedCipherText.Skip(decodedCipherText.Length - _firstPart.Length).Take(_secondPart.Length)
                .ToArray();
            byte[] encryptedText = decodedCipherText.Skip(_firstPart.Length)
                .Take(decodedCipherText.Length - 2 * _secondPart.Length).ToArray();

            _key = new byte[key1.Length + key2.Length];
            Array.Copy(key1, 0, _key, 0, key1.Length);
            Array.Copy(key2, 0, _key, key1.Length, key2.Length);
            
            return encryptedText;
        }
    }
}