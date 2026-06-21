using System.ComponentModel;
using PwdKeychain.Interfaces;

namespace PwdKeychain.Forms
{
    [Serializable]
    public partial class EntryAndEditForm : Form
    {
        private readonly IPasswordService _passwordService;
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Website
        {
            get => websiteTxtBox.Text;
            set => websiteTxtBox.Text = value;
        }
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Email
        {
            get => userTxtBox.Text;
            set => userTxtBox.Text = value;
        }
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Password
        {
            get => pwdTxtBox.Text;
            set => pwdTxtBox.Text = value;
        }
        
        public EntryAndEditForm(IPasswordService passwordService, string okButton, string noButton, string formTitle)
        {
            _passwordService = passwordService;
            InitializeComponent();
            CustomForm(okButton, noButton, formTitle);
        }
        
        private void entryAndEditButt_Click(object sender, EventArgs? e)
        {
            if (string.IsNullOrWhiteSpace(Website) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Website and Email cannot be empty!");
                return;
            }
            
            if (!_passwordService.IsValid(Password, out var errorMsg))
            {
                MessageBox.Show(errorMsg);
                return;
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }
        
        private void cancelButton_Click(object sender, EventArgs? e)
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