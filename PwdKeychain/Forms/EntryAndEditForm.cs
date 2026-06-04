using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PwdKeychain.Models;
using PwdKeychain.Properties;

namespace PwdKeychain.Forms
{
    public partial class EntryAndEditForm : Form
    {
        private ToolTip passwordToolTip;

        public EntryAndEditForm(string okButton, string noButton, string formTitle)
        {
            InitializeComponent();
            CustomForm(okButton, noButton, formTitle);
            SetComboImage();

            passwordToolTip = new ToolTip();
            passwordToolTip.SetToolTip(pwdPictureBox, "Show Password");
            passwordToolTip.SetToolTip(genPwdPictureBox, "Make a safe password with the generated password\n-option1\n-option2\n-option3\n-option4");
        }

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

        public string? Password
        {
            get => pwdTxtBox.Text;
            set => pwdTxtBox.Text = value;
        }

        public string? Type
        {
            get => defaultWebsComboBox.Text;
            set => defaultWebsComboBox.Text = value;
        }
        
        private void CustomForm(string okButton, string noButton, string formTitle)
        {
            entryAndEditButt.Text = okButton;
            cancelButton.Text = noButton;
            Text = formTitle;
        }

        private void TogglePasswordVisibility(object sender, EventArgs e)
        {
            if (pwdTxtBox.UseSystemPasswordChar)
            {
                pwdTxtBox.UseSystemPasswordChar = false;
                pwdPictureBox.Image = Images.open_eye64;
                passwordToolTip.SetToolTip(pwdPictureBox, "Hide Password");
            }
            else
            {
                pwdTxtBox.UseSystemPasswordChar = true;
                pwdPictureBox.Image = Images.close_eye;
                passwordToolTip.SetToolTip(pwdPictureBox, "Show Password");
            }
        }

        private void SetComboImage()
        {
            Dictionary<string, Image> comboBoxItems = new Dictionary<string, Image>
            {
                {"Google", Images.googleIco},
                {"Facebook", Images.facebookIco},
                {"Amazon", Images.amazonIco},
                {"Spotify", Images.spotifyIco},
                {"Github", Images.githubIco},
                {"Reddit", Images.redditIco},
                {"Uber", Images.uberIco},
                {"Others", Images.ellipsis64}
            };
            
            foreach (var item in comboBoxItems)
            {
                defaultWebsComboBox.Items.Add(new ComboBoxItem(item.Key, item.Value));
            }
        }

        private void SetPlaceholder(TextBox textBox, string placeholder, string initialValue = "")
        {
            if (string.IsNullOrWhiteSpace(initialValue))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }
            else
            {
                textBox.Text = initialValue;
                textBox.ForeColor = Color.Black;
            }

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }
        
        private void CustomComboNTextBox()
        {
            defaultWebsComboBox.DropDownHeight = 200;
            defaultWebsComboBox.ItemHeight = 21;
            
            defaultWebsComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            defaultWebsComboBox.DrawItem += DefaultWebsComboBox_DrawItem;
        }
        
        //Events
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
        
        private void EntryAndEditForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CustomComboNTextBox();
        }

        private void EntryAndEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 27:
                    cancelButton_Click(sender, null);
                    break;
                case 13:
                    entryAndEditButt_Click(sender, null);
                    break;
            }
        }
        
        private void PasswordPictureBox_MouseEnter(object sender, EventArgs e)
        {
            pwdPictureBox.BackColor = Color.LightGray;
        }

        private void PasswordPictureBox_MouseLeave(object sender, EventArgs e)
        {
            pwdPictureBox.BackColor = Color.Transparent;
        }
        
        private void DefaultWebsComboBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 20;
            e.ItemWidth = defaultWebsComboBox.Width;
        }

        private void DefaultWebsComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            ComboBoxItem item = (ComboBoxItem)defaultWebsComboBox.Items[e.Index];

            e.Graphics.DrawImage(item.Image, new Rectangle(e.Bounds.Left, e.Bounds.Top, 20, 20));

            e.Graphics.DrawString(item.Text, e.Font, Brushes.Black, e.Bounds.Left + 25,
                e.Bounds.Top + (e.Bounds.Height - e.Font.Height) / 2);

            e.DrawFocusRectangle();
        }
        
        private void DefaultWebsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (defaultWebsComboBox.SelectedItem.ToString())
            {
                case "Others":
                    websiteTxtBox.Visible = true;
                    websiteTxtBox.Enabled = true;
                    if (Website == "")
                        SetPlaceholder(websiteTxtBox, "Enter website name");
                    break;
                default:
                    websiteTxtBox.Visible = false;
                    websiteTxtBox.Enabled = false;
                    if (Website == "")
                        SetPlaceholder(websiteTxtBox, "");
                    break;
            }
        }

        private void GenPwdPictureBox_Click(object sender, EventArgs e)
        {
            
        }

        private void genPwdPictureBox_MouseEnter(object sender, EventArgs e)
        {
            genPwdPictureBox.BackColor = Color.LightGray;
        }

        private void genPwdPictureBox_MouseLeave(object sender, EventArgs e)
        {
            genPwdPictureBox.BackColor = Color.Transparent;
        }
    }
}