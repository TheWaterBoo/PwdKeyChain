using System.Runtime.CompilerServices;

namespace PwdKeychain.Utils;

public static class ErrorFactory
{
    public static ExceptionMetadata Create(
        Exception exception,
        object[]? args = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "")
    {
        var className = Path.GetFileNameWithoutExtension(filePath);
        return new ExceptionMetadata(exception, className, memberName, filePath, args);
    }
}