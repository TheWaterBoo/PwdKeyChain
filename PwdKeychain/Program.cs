using PwdKeychain.Forms;
using PwdKeychain.Implementations;
using PwdKeychain.Utils;

namespace PwdKeyChain
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.ThreadException += Common_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            var cryptNDecrypt = new CryptNDecrypt("TemporalMastePass");
            var dbManager = new DatabaseManager(cryptNDecrypt);
            Application.Run(new MainForm(dbManager));
        }
        
        private static void Common_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ProcessUnhandledException(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                ProcessUnhandledException(ex);
            }
        }

        private static void ProcessUnhandledException(Exception ex)
        {
            var metadata = new ExceptionMetadata(
                Exception: ex,
                ClassName: ex.TargetSite?.DeclaringType?.Name ?? "UnknownClass",
                FunctionName: ex.TargetSite?.Name ?? "UnknownMethod",
                FilePath: "Extracted via TargetSite"
            );
            
            using (var errDialog = new ErrorForm(metadata.FormatExceptionDetails(), "Error Crítico!!"))
            {
                errDialog.ShowDialog();
            }
            
            Environment.Exit(1);
        }
    }
}