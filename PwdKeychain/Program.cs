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
        private static bool _handlingException;
        
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Common_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            try
            {
                var dbManager = new DatabaseManager();
                var passwordService = new PasswordService();
                var storedData = dbManager.GetStoredData();

                if (storedData == null)
                {
                    using var registerForm = new RegistrationForm(dbManager, passwordService);
                
                    if (registerForm.ShowDialog() != DialogResult.OK) 
                        return;
                
                    storedData = dbManager.GetStoredData();
                    if (storedData == null) 
                        throw new InvalidOperationException("Ocurrio un error al obtener los datos de la cuenta...");
                }
            
                using var authorizationForm = new AuthorizationForm(storedData.Hash, storedData.Salt);
                if (authorizationForm.ShowDialog() != DialogResult.OK) return;

                var masterPassword = authorizationForm.UserPasswordInput;
            
                var cryptNDecrypt = new CryptNDecrypt(masterPassword, storedData.Salt);
                dbManager.InitializeCryptor(cryptNDecrypt);
                
                Application.Run(new MainForm(dbManager, passwordService));
            }
            catch (Exception ex)
            {
                ProcessUnhandledException(ex);
            }
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
            if (_handlingException) return;
            
            _handlingException = true;
            
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

            Application.Exit();
        }
    }
}