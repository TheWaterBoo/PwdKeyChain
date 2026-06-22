using System.Security.Cryptography;
using System.Text.RegularExpressions;
using PwdKeychain.Interfaces;
using PwdKeychain.Models;

namespace PwdKeychain.Implementations;

public partial class PasswordService : IPasswordService
{
    //Regex Pattern
    [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[-_@$!%*#?&]).{16,}$")]
    private static partial Regex RegexPattern();
    //Scores for PasswordStrength Method
    [GeneratedRegex(@"[a-z]")]
    private static partial Regex RegexScore1();
    [GeneratedRegex(@"[A-Z]")]
    private static partial Regex RegexScore2();
    [GeneratedRegex(@"\d")]
    private static partial Regex RegexScore3();
    [GeneratedRegex(@"[-_@$!%*#?&]")]
    private static partial Regex RegexScore4();

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
        var score = 0;

        if (password.Length >= 11)
            score++;

        if (password.Length >= 24)
            score++;

        if (RegexScore1().IsMatch(password))
            score++;

        if (RegexScore2().IsMatch(password))
            score++;

        if (RegexScore3().IsMatch(password))
            score++;

        if (RegexScore4().IsMatch(password))
            score++;

        return score switch
        {
            0 => PasswordStrength.Invalid,
            <= 2 => PasswordStrength.Weak,
            <= 4 => PasswordStrength.Medium,
            <= 5 => PasswordStrength.Strong,
            _ => PasswordStrength.VeryStrong
        };
    }
}