using System.ComponentModel;
using PwdKeychain.Models;

namespace PwdKeychain.Forms
{
    [Serializable]
    public partial class EntryAndEditForm : Form
    {
        private AccountEntry _accountEntry;
        // [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        // public string Website
        // {
        //     get => websiteTxtBox.Text;
        //     set => websiteTxtBox.Text = value;
        // }
        //
        // [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        // public string Username
        // {
        //     get => userTxtBox.Text;
        //     set => userTxtBox.Text = value;
        // }
        //
        // [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        // public string? Password
        // {
        //     get => pwdTxtBox.Text;
        //     set => pwdTxtBox.Text = value;
        // }
        
        public EntryAndEditForm(string okButton, string noButton, string formTitle)
        {
            InitializeComponent();
            CustomForm(okButton, noButton, formTitle);
        }
        
        private void entryAndEditButt_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CustomForm(string okButton, string noButton, string formTitle)
        {
            entryAndEditButt.Text = okButton;
            cancelButton.Text = noButton;
            Text = formTitle;
        }

        private void EntryAndEditForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            _accountEntry = new AccountEntry("", "", null, "");
        }
        
        public AccountEntry GetAccountData()
        {
            _accountEntry.WebsiteName = websiteTxtBox.Text;
            _accountEntry.Username = userTxtBox.Text;
            _accountEntry.Password = pwdTxtBox.Text;
            return _accountEntry;
        }

        private void EntryAndEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 27: //ESC Key
                    cancelButton_Click(sender, null);
                    break;
                case 13: //ENTER Key
                    entryAndEditButt_Click(sender, null);
                    break;
            }
        }

        private void passwordChecker_CheckStateChanged(object sender, EventArgs e)
        {
            pwdTxtBox.UseSystemPasswordChar = !passwordChecker.Checked;
        }
    }
}