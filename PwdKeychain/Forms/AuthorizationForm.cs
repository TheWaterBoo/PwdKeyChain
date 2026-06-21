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
    
    private void loginButton_Click(object sender, EventArgs? e)
    {
        var inputPassword = passwordTextBox.Text;
        if (!CryptNDecrypt.ValidateMasterPassword(inputPassword, _storedHash, _storedSalt))
        {
            MessageBox.Show("Incorrect password! Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            passwordTextBox.Clear();
            passwordTextBox.Focus();
            return;
        }
        UserPasswordInput = inputPassword;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void AuthorizationFrom_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyValue)
        {
            case 13: //ENTER Key
                loginButton_Click(sender, null);
                break;
        }
    }
    
    private void AuthorizationForm_Load(object sender, EventArgs e)
    {
        KeyPreview = true;
    }
}