using System;
using System.Windows.Forms;
using PwdKeychain.Properties;

namespace PwdKeychain
{
    public partial class EntryAndEditForm : Form
    {
        public string FormType { get; set; }
        
        public string Website
        {
            get => websiteTxtBox.Text;
            set => websiteTxtBox.Text = value;
        }

        public string Username
        {
            get => userTxtBox.Text;
            set => userTxtBox.Text = value;
        }

        public string Password
        {
            get => pwdTxtBox.Text;
            set => pwdTxtBox.Text = value;
        }
        
        public EntryAndEditForm(string formType)
        {
            InitializeComponent();
            FormType = formType;
            customForm();
        }
        
        private void entryAndEditButt_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void customForm()
        {
            switch (FormType)
            {
                case "0":
                    entryAndEditButt.Text = Resources.EntryAndEditForm_customForm_Save;
                    Text = Resources.EntryAndEditForm_customForm_Add_new_account;
                    break;
                case "1":
                    entryAndEditButt.Text = Resources.EntryAndEditForm_customForm_Edit;
                    Text = Resources.EntryAndEditForm_customForm_Editing_existing_account;
                    break;
            }
        }
    }
}