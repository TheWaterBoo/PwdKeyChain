using System;
using System.Windows.Forms;

namespace PwdKeychain.Forms
{
    public partial class ConfirmationForm : Form
    {
        public ConfirmationForm(string msgText, string okButton, string noButton, string formTitle)
        {
            InitializeComponent();
            FormModify(msgText, okButton, noButton, formTitle);
        }

        private void positiveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void NegativeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormModify(string msgText, string okButton, string noButton, string formTitle)
        {
            textInfoLabel.Text = msgText;
            positiveButton.Text = okButton;
            NegativeButton.Text = noButton;
            Text = formTitle;
        }
        
        private void ConfirmationForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 27: //ESC Key
                    NegativeButton_Click(sender, null);
                    break;
                case 13: //ENTER Key
                    positiveButton_Click(sender, null);
                    break;
            }
        }

        private void ConfirmationForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }
    }
}