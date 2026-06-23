using System.Security.Cryptography;
using System.Text.RegularExpressions;
using PwdKeychain.Interfaces;
using PwdKeychain.Models;
using Zxcvbn;

namespace PwdKeychain.Implementations;

public partial class PasswordService : IPasswordService
{
    //Regex Pattern
    [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[-_@$!%*#?&]).{16,}$")]
    private static partial Regex RegexPattern();
    

    public bool IsValid(string password, out string errorMessage)
    {
        if (RegexPattern().IsMatch(password))
        {
            errorMessage = string.Empty;
            return true;
        }

        errorMessage = "Password must contain at least 16 characters, 1 number, 1 special character and 1 letter";
        return false;
    }

    public string GenerateRandomPassword(int length = 16)
    {
        const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_@$!%*#?&";

        using var rng = RandomNumberGenerator.Create();
        var bytes = new byte[length];
        rng.GetBytes(bytes);

        var chars = new char[length];
        for (var i = 0; i < length; i++)
        {
            chars[i] = validChars[bytes[i] % validChars.Length];
        }
        
        var password = new string(chars);
        
        return IsValid(password, out _) ? password : GenerateRandomPassword(length); // recursive call, in case the generated password is invalid
    }
    
    public PasswordStrength GetPasswordStrength(string password)
    {
        if (string.IsNullOrEmpty(password)) 
            return PasswordStrength.Invalid;
        
        var result = Core.EvaluatePassword(password);
        
        if (result.Score == 4 && password.Length >= 39)
            return PasswordStrength.Indecipherable;

        return result.Score switch
        {
            0 => PasswordStrength.VeryWeak,
            1 => PasswordStrength.Weak,
            2 => PasswordStrength.Medium, 
            3 => PasswordStrength.Strong, 
            4 => PasswordStrength.VeryStrong,
            _ => PasswordStrength.Indecipherable
        };
    }
}