namespace PwdKeychain.Interfaces
{
    public interface ICryptNDecrypt
    {
        string Encrypter(string data, string id);
        string Decrypter(string encryptedData, string id);
    }
}