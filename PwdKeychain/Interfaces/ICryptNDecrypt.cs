namespace PwdKeychain.Interfaces
{
    public interface ICryptNDecrypt
    {
        string Encrypter(string? pwd, out string key);
        string Decrypter(string zipedPwd, string key);
    }
}