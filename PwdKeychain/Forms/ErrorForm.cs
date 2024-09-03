using System;
using System.Windows.Forms;

namespace PwdKeychain.Forms
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string errMsg, string excpTitle)
        {
            InitializeComponent();
            ShowErrorMsg(errMsg, excpTitle);
        }

        private void ShowErrorMsg(string errMsg, string excpTitle)
        {
            Text = excpTitle;
            MsgErrorLabel.Text = errMsg;
        }

        private void closeButt_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void copyAndClose_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MsgErrorLabel.Text);
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}