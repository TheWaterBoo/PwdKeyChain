using PwdKeychain.Implementations;
using PwdKeychain.Interfaces;

namespace PwdKeychain.Forms;

public partial class RegistrationForm : Form
{
    private readonly IDatabaseManager _dbManager;
    
    public RegistrationForm(IDatabaseManager dbManager)
    {
        _dbManager = dbManager;
        InitializeComponent();
    }
    
    private void registerButton_Click(object sender, EventArgs e)
    {
        var inputPassword = registerTextBox.Text;
        var hashAndSalt= CryptNDecrypt.CreateMasterHash(inputPassword);
        
        _dbManager.StoreData(hashAndSalt.Hash, hashAndSalt.Salt);
        
        DialogResult = DialogResult.OK;
        Close();
    }
}