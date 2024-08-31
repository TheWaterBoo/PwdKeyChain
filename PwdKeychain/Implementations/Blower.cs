using System;
using System.Linq;
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
            //_key = new byte[] { 24, 87, 245, 72, 44, 7, 99, 112, 255, 177, 101, 34, 22, 58, 244, 1 };
            _key = KeyGen();
            ShardGen();
            _padding = new Pkcs7Padding();
        }

        public string Encrypter(string pwd)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(pwd);
            byte[] encryptOutput = CryptNDecrypt(inputBytes, true);
            byte[] finalOutput = EncryptMilkshake(encryptOutput);
            return Convert.ToBase64String(finalOutput);
        }

        public string Decrypter(string zipedPwd)
        {
            byte[] decodedCipherText = Convert.FromBase64String(zipedPwd);
            byte[] encryptedText = MilkshakeExtractor(decodedCipherText);
            byte[] decryptOutput = CryptNDecrypt(encryptedText, false);
            return Encoding.UTF8.GetString(decryptOutput);
        }

        private byte[] CryptNDecrypt(byte[] inputBytes, bool forEncrypt)
        {
            BufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new BlowfishEngine(), _padding);
            cipher.Init(forEncrypt, new KeyParameter(_key));

            byte[] outputBytes = new byte[cipher.GetOutputSize(inputBytes.Length)];
            int length = cipher.ProcessBytes(inputBytes, 0, inputBytes.Length, outputBytes, 0);
            cipher.DoFinal(outputBytes, length);

            return outputBytes;
        }

        private byte[] KeyGen()
        {
            byte[] key = new byte[16];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }
            return key;
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