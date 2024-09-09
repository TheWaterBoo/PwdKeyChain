using System;
using System.Windows.Forms;

namespace PwdKeychain.Forms
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string errMsg, string excpTitle)
        {
            InitializeComponent();
            ErrMsgPanel.Controls.Add(ErrMsgLabel);
            ShowErrorMsg(errMsg, excpTitle);
        }

        private void ShowErrorMsg(string errMsg, string excpTitle)
        {
            Text = excpTitle + " - Custom Exception";
            ErrMsgLabel.Text = errMsg;
        }

        private void closeButt_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void copyAndClose_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ErrMsgLabel.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}