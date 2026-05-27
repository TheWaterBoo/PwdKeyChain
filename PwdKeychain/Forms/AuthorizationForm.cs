using PwdKeychain.Implementations;

namespace PwdKeychain.Forms;

public partial class AuthorizationForm : Form
{
    private readonly byte[] _storedHash;
    private readonly byte[] _storedSalt;
    public string UserPasswordInput { get; private set; } = string.Empty;
    
    public AuthorizationForm(byte[] storedHash, byte[] storedSalt)
    {
        _storedHash = storedHash;
        _storedSalt = storedSalt;
        InitializeComponent();
    }
    
    private void loginButton_Click(object sender, EventArgs e)
    {
        var inputPassword = passwordTextBox.Text;
        if (!CryptNDecrypt.ValidateMasterPassword(inputPassword, _storedHash, _storedSalt))
        {
            MessageBox.Show("Incorrect password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            passwordTextBox.Clear();
            passwordTextBox.Focus();
            return;
        }
        UserPasswordInput = inputPassword;
        DialogResult = DialogResult.OK;
        Close();
    }
}