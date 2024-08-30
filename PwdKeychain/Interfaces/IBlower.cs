namespace PwdKeychain.Interfaces
{
    public interface IBlower
    {
        string Encrypter(string pwd);
        string Decrypter(string zipedPwd);
    }
}