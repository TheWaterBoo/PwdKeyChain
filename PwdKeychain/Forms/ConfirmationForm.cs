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
    }
}