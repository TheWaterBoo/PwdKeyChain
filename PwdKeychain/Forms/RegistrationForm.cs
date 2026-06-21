using PwdKeychain.Implementations;
using PwdKeychain.Interfaces;

namespace PwdKeychain.Forms;

public partial class RegistrationForm : Form
{
    private readonly IDatabaseManager _dbManager;
    private readonly IPasswordService _passwordService;

    public RegistrationForm(IDatabaseManager dbManager, IPasswordService passwordService)
    {
        _dbManager = dbManager;
        _passwordService = passwordService;
        InitializeComponent();
    }

    private void registerButton_Click(object sender, EventArgs e)
    {
        var inputPassword = registerTextBox.Text;

        if (!_passwordService.IsValid(inputPassword, out var errorMessage))
        {
            MessageBox.Show(errorMessage, "Password not admited", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }

        var hashAndSalt = CryptNDecrypt.CreateMasterHash(inputPassword);
        _dbManager.StoreData(hashAndSalt.Hash, hashAndSalt.Salt);

        DialogResult = DialogResult.OK;
        Close();
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void RegistrationFrom_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyValue)
        {
            case 13: //ENTER Key
                registerButton_Click(sender, null);
                break;
        }
    }

    private void RegistrationForm_Load(object sender, EventArgs e)
    {
        KeyPreview = true;
    }
}