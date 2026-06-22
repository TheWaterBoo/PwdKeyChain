using System.ComponentModel;
using PwdKeychain.Interfaces;
using PwdKeychain.Models;
using PwdKeychain.Properties;

namespace PwdKeychain.Forms
{
    [Serializable]
    public partial class EntryAndEditForm : Form
    {
        private readonly IPasswordService _passwordService;
        private bool _showPassword;
        private Random _rnd = new();

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
            generalTooltip.SetToolTip(pictureShowPassword, "Show / Hide password");
            generalTooltip.SetToolTip(pictureCopyPassword, "Copy password");
            generalTooltip.SetToolTip(generateRandomPassword, "Generate new safe password");
            pictureShowPassword.Image = Images.hide24;
            CustomForm(okButton, noButton, formTitle);
        }

        private void CustomForm(string okButton, string noButton, string formTitle)
        {
            entryAndEditButt.Text = okButton;
            cancelButton.Text = noButton;
            Text = formTitle;
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

        private void pictureCopyPassword_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(pwdTxtBox.Text);
            generalTooltip.Show(
                "Copied!",
                pictureCopyPassword,
                500
            );
        }

        private void pictureShowPassword_MouseDown(object sender, MouseEventArgs e)
        {
            _showPassword = !_showPassword;

            pwdTxtBox.UseSystemPasswordChar = !_showPassword;

            pictureShowPassword.Image = _showPassword
                ? Images.view24
                : Images.hide24;

            pwdTxtBox.Focus();
        }

        private void generateRandomPassword_Click(object sender, EventArgs e)
        {
            var length = _rnd.Next(18, 27);
            pwdTxtBox.Text = _passwordService.GenerateRandomPassword(length);
        }

        private void pwdTxtBox_TextChanged(object sender, EventArgs e)
        {
            var strength = _passwordService.GetPasswordStrength(pwdTxtBox.Text);

            switch (strength)
            {
                case PasswordStrength.Invalid:
                    strengthLabel.Text = "? ? ?";
                    ResetStrengthPanels();
                    break;
                case PasswordStrength.Weak:
                    strengthLabel.Text = "Weak";
                    UpdateStrengthPanels(1, Color.Red);
                    break;
                case PasswordStrength.Medium:
                    strengthLabel.Text = "Medium";
                    UpdateStrengthPanels(3, Color.Goldenrod);
                    break;
                case PasswordStrength.Strong:
                    strengthLabel.Text = "Strong";
                    UpdateStrengthPanels(4, Color.Green);
                    break;
                case PasswordStrength.VeryStrong:
                    strengthLabel.Text = "Very Strong";
                    UpdateStrengthPanels(5, Color.DarkGreen);
                    break;
            }
        }

        private void UpdateStrengthPanels(
            int blocks,
            Color color)
        {
            ResetStrengthPanels();

            Panel[] panels =
            [
                strengthPanel1,
                strengthPanel2,
                strengthPanel3,
                strengthPanel4,
                strengthPanel5
            ];

            for (var i = 0; i < blocks; i++)
            {
                panels[i].BackColor = color;
            }
        }

        private void ResetStrengthPanels()
        {
            strengthPanel1.BackColor = Color.LightGray;
            strengthPanel2.BackColor = Color.LightGray;
            strengthPanel3.BackColor = Color.LightGray;
            strengthPanel4.BackColor = Color.LightGray;
            strengthPanel5.BackColor = Color.LightGray;
        }

        private void pictureShowPassword_MouseEnter(object sender, EventArgs e)
        {
            pictureShowPassword.BackColor = Color.Gainsboro;
        }

        private void pictureShowPassword_MouseLeave(object sender, EventArgs e)
        {
            pictureShowPassword.BackColor = Color.Transparent;
        }

        private void pictureCopyPassword_MouseEnter(object sender, EventArgs e)
        {
            pictureCopyPassword.BackColor = Color.Gainsboro;
        }

        private void pictureCopyPassword_MouseLeave(object sender, EventArgs e)
        {
            pictureCopyPassword.BackColor = Color.Transparent;
        }
    }
}