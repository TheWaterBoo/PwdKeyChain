using System;
using System.Windows.Forms;
using PwdKeychain.Forms;

namespace PwdKeychain.Utils;

public class CustomExceptions
{
    private string? Function { get; set; }
    private Exception? Exception { get; set; }
    private string? ClassName { get; set; }
    private object[]? FunctionArgs { get; set; }
    private string Message => Exception?.Message ?? "Exception Message not found, please see inner exception for details";
    private int? LineNumber { get; set; }
    private string? FileName { get; set; }

    public CustomExceptions(Exception exception, string? className, string? function, object[]? functionArgs)
    {
        Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        Function = function;
        ClassName = className;
        FunctionArgs = functionArgs;
        FileName = GetFileName(exception);
        LineNumber = GetLineNumber(exception);
    }

    public string ExceptionMsg()
    {
        return $"[Exception]: {Message}\n" +
               $"[Class]: {ClassName}\n" +
               $"[Function]: {Function}\n" +
               $"[LineNumber]: {LineNumber}\n" +
               $"[FileName]: {FileName}\n" +
               $"[FunctionArguments]: {FunctionArgsString()}";
    }

    public void ShowErrDialog(string excepTitle, int exitCode)
    {
        using ErrorForm errDialog = new ErrorForm(ExceptionMsg(), excepTitle);
        errDialog.ShowDialog();
        Environment.Exit(exitCode);
    }
    
    private static int? GetLineNumber(Exception exception)
    {
        var stackTrace = new System.Diagnostics.StackTrace(exception, true);
        var frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
        return frame?.GetFileLineNumber();
    }

    private static string? GetFileName(Exception exception)
    {
        if (exception == null) return null;
        
        var stackTrace = new System.Diagnostics.StackTrace(exception, true);
        var frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
        
        return frame?.GetFileName();
    }

    private string FunctionArgsString()
    {
        if (FunctionArgs == null || FunctionArgs.Length == 0)
            return "No arguments provided";
        
        return string.Join(", ", FunctionArgs);
    }
}