namespace PwdKeychain.Interfaces;

public interface IPasswordService
{
    bool IsValid(string password, out string errorMessage);
    string GenerateRandomPassword(int length = 16); // 16 is the minimum length
}