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
            _key = Encoding.UTF8.GetBytes("15161718202111");
            _padding = new Pkcs7Padding();
        }

        public string Encrypter(string pwd)
        {
            byte[] encryptOutput = CryptNDecrypt(pwd, true);

            return Convert.ToBase64String(encryptOutput);
        }

        public string Decrypter(string zipedPwd)
        {
            byte[] decryptOutput = CryptNDecrypt(zipedPwd, false);

            return Encoding.UTF8.GetString(decryptOutput);
        }

        private byte[] CryptNDecrypt(string thing, bool forEncrypt)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(thing);
            BufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new BlowfishEngine(), _padding);
            cipher.Init(forEncrypt, new KeyParameter(_key));
            
            byte[] outputBytes = new byte[cipher.GetOutputSize(inputBytes.Length)];
            int length = cipher.ProcessBytes(inputBytes, 0, inputBytes.Length, outputBytes, 0);
            cipher.DoFinal(outputBytes, length);

            return outputBytes;
        }
    }
}