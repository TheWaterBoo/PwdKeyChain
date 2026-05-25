using System.Text;

namespace PwdKeychain.Utils;

public record ExceptionMetadata(
    Exception Exception,
    string ClassName,
    string FunctionName,
    string FilePath,
    object[]? FunctionArgs = null)
{
    public string FormatExceptionDetails()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"[Exception]: {Exception.Message}");
        sb.AppendLine($"[Class]: {ClassName}");
        sb.AppendLine($"[Function]: {FunctionName}");
        sb.AppendLine($"[File]: {FilePath}");
        
        if (FunctionArgs is { Length: > 0 })
        {
            sb.AppendLine($"[Arguments]: {string.Join(", ", FunctionArgs)}");
        }

        sb.AppendLine("\n[System StackTrace]:");
        sb.AppendLine(Exception.StackTrace ?? "No stack trace available.");

        return sb.ToString();
    }
}