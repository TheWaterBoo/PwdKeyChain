namespace PwdKeychain.Interfaces
{
    public interface IBlower
    {
        string Encrypter(string pwd, out string key);
        string Decrypter(string zipedPwd, string key);
    }
}