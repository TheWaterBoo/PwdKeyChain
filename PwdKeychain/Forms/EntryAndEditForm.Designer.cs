using System.ComponentModel;

namespace PwdKeychain.Forms
{
    partial class EntryAndEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.entryAndEditButt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.websiteTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pwdTxtBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.pwdPictureBox = new System.Windows.Forms.PictureBox();
            this.defaultWebsComboBox = new System.Windows.Forms.ComboBox();
            this.genPwdPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pwdPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genPwdPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // entryAndEditButt
            // 
            this.entryAndEditButt.Location = new System.Drawing.Point(145, 261);
            this.entryAndEditButt.Margin = new System.Windows.Forms.Padding(4);
            this.entryAndEditButt.Name = "entryAndEditButt";
            this.entryAndEditButt.Size = new System.Drawing.Size(100, 28);
            this.entryAndEditButt.TabIndex = 0;
            this.entryAndEditButt.TabStop = false;
            this.entryAndEditButt.Text = "Accept";
            this.entryAndEditButt.UseVisualStyleBackColor = true;
            this.entryAndEditButt.Click += new System.EventHandler(this.entryAndEditButt_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Website / App name:";
            // 
            // websiteTxtBox
            // 
            this.websiteTxtBox.Enabled = false;
            this.websiteTxtBox.Location = new System.Drawing.Point(337, 28);
            this.websiteTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.websiteTxtBox.Name = "websiteTxtBox";
            this.websiteTxtBox.Size = new System.Drawing.Size(156, 22);
            this.websiteTxtBox.TabIndex = 1;
            this.websiteTxtBox.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username / Email:";
            // 
            // userTxtBox
            // 
            this.userTxtBox.Location = new System.Drawing.Point(156, 78);
            this.userTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.userTxtBox.Name = "userTxtBox";
            this.userTxtBox.Size = new System.Drawing.Size(337, 22);
            this.userTxtBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password:\r\n";
            // 
            // pwdTxtBox
            // 
            this.pwdTxtBox.Location = new System.Drawing.Point(156, 129);
            this.pwdTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.pwdTxtBox.Name = "pwdTxtBox";
            this.pwdTxtBox.Size = new System.Drawing.Size(272, 22);
            this.pwdTxtBox.TabIndex = 3;
            this.pwdTxtBox.UseSystemPasswordChar = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(278, 261);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.TabStop = false;
            this.cancelButton.Text = "No";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // pwdPictureBox
            // 
            this.pwdPictureBox.Image = global::PwdKeychain.Properties.Images.close_eye;
            this.pwdPictureBox.InitialImage = global::PwdKeychain.Properties.Images.close_eye;
            this.pwdPictureBox.Location = new System.Drawing.Point(435, 129);
            this.pwdPictureBox.Name = "pwdPictureBox";
            this.pwdPictureBox.Size = new System.Drawing.Size(26, 24);
            this.pwdPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pwdPictureBox.TabIndex = 6;
            this.pwdPictureBox.TabStop = false;
            this.pwdPictureBox.Click += new System.EventHandler(this.TogglePasswordVisibility);
            this.pwdPictureBox.MouseEnter += new System.EventHandler(this.PasswordPictureBox_MouseEnter);
            this.pwdPictureBox.MouseLeave += new System.EventHandler(this.PasswordPictureBox_MouseLeave);
            // 
            // defaultWebsComboBox
            // 
            this.defaultWebsComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.defaultWebsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaultWebsComboBox.Location = new System.Drawing.Point(156, 28);
            this.defaultWebsComboBox.Name = "defaultWebsComboBox";
            this.defaultWebsComboBox.Size = new System.Drawing.Size(174, 23);
            this.defaultWebsComboBox.TabIndex = 7;
            this.defaultWebsComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DefaultWebsComboBox_DrawItem);
            this.defaultWebsComboBox.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.DefaultWebsComboBox_MeasureItem);
            this.defaultWebsComboBox.SelectedIndexChanged += new System.EventHandler(this.DefaultWebsComboBox_SelectedIndexChanged);
            // 
            // genPwdPictureBox
            // 
            this.genPwdPictureBox.Image = global::PwdKeychain.Properties.Images.key64;
            this.genPwdPictureBox.Location = new System.Drawing.Point(467, 129);
            this.genPwdPictureBox.Name = "genPwdPictureBox";
            this.genPwdPictureBox.Size = new System.Drawing.Size(26, 24);
            this.genPwdPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.genPwdPictureBox.TabIndex = 9;
            this.genPwdPictureBox.TabStop = false;
            this.genPwdPictureBox.Click += new System.EventHandler(this.GenPwdPictureBox_Click);
            this.genPwdPictureBox.MouseEnter += new System.EventHandler(this.genPwdPictureBox_MouseEnter);
            this.genPwdPictureBox.MouseLeave += new System.EventHandler(this.genPwdPictureBox_MouseLeave);
            // 
            // EntryAndEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(531, 343);
            this.Controls.Add(this.genPwdPictureBox);
            this.Controls.Add(this.defaultWebsComboBox);
            this.Controls.Add(this.pwdPictureBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.pwdTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.websiteTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.entryAndEditButt);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntryAndEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EntryAndEditForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntryAndEditForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pwdPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genPwdPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.PictureBox genPwdPictureBox;

        private System.Windows.Forms.ComboBox defaultWebsComboBox;

        private System.Windows.Forms.PictureBox pwdPictureBox;

        private System.Windows.Forms.Button cancelButton;

        private System.Windows.Forms.TextBox pwdTxtBox;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.TextBox userTxtBox;

        private System.Windows.Forms.TextBox websiteTxtBox;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button entryAndEditButt;

        #endregion
    }
}