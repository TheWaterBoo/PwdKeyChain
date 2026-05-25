namespace PwdKeychain.Interfaces
{
    public interface ICryptNDecrypt
    {
        string Encrypter(string pwd, string id);
        string Decrypter(string zipedPwd, string id);
    }
}