using System;
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
        private readonly byte[] _key;

        public Blower()
        {
            _key = new byte[] {24,87,245,72,44,7,99,112,255,177,101,34,22,58,244,1};
            _padding = new Pkcs7Padding();
        }

        public string Encrypter(string pwd)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(pwd);
            byte[] encryptOutput = CryptNDecrypt(inputBytes, true);
            return Convert.ToBase64String(encryptOutput);
        }

        public string Decrypter(string zipedPwd)
        {
            byte[] decodedCipherText = Convert.FromBase64String(zipedPwd);
            byte[] decryptOutput = CryptNDecrypt(decodedCipherText, false);
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
    }
}