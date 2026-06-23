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
            components = new System.ComponentModel.Container();
            entryAndEditButt = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            websiteTxtBox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            userTxtBox = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            pwdTxtBox = new System.Windows.Forms.TextBox();
            cancelButton = new System.Windows.Forms.Button();
            pictureShowPassword = new System.Windows.Forms.PictureBox();
            pictureCopyPassword = new System.Windows.Forms.PictureBox();
            generalTooltip = new System.Windows.Forms.ToolTip(components);
            generateRandomPassword = new System.Windows.Forms.Button();
            strengthLabel = new System.Windows.Forms.Label();
            strengthPanel1 = new System.Windows.Forms.Panel();
            strengthPanel2 = new System.Windows.Forms.Panel();
            strengthPanel4 = new System.Windows.Forms.Panel();
            strengthPanel3 = new System.Windows.Forms.Panel();
            strengthPanel5 = new System.Windows.Forms.Panel();
            strengthPanel6 = new System.Windows.Forms.Panel();
            pictureCopyUsername = new System.Windows.Forms.PictureBox();
            labelErrorWebsite = new System.Windows.Forms.Label();
            labelErrorUsername = new System.Windows.Forms.Label();
            labelErrorPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureShowPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureCopyPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureCopyUsername).BeginInit();
            SuspendLayout();
            // 
            // entryAndEditButt
            // 
            entryAndEditButt.Location = new System.Drawing.Point(59, 222);
            entryAndEditButt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            entryAndEditButt.Name = "entryAndEditButt";
            entryAndEditButt.Size = new System.Drawing.Size(88, 27);
            entryAndEditButt.TabIndex = 0;
            entryAndEditButt.TabStop = false;
            entryAndEditButt.Text = "Accept";
            entryAndEditButt.UseVisualStyleBackColor = true;
            entryAndEditButt.Click += entryAndEditButt_Click;
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(13, 12);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Site name:";
            // 
            // websiteTxtBox
            // 
            websiteTxtBox.Location = new System.Drawing.Point(13, 28);
            websiteTxtBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            websiteTxtBox.Name = "websiteTxtBox";
            websiteTxtBox.Size = new System.Drawing.Size(296, 23);
            websiteTxtBox.TabIndex = 1;
            websiteTxtBox.TextChanged += websiteTxtBox_TextChanged;
            websiteTxtBox.Validating += websiteTxtBox_Validating;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(13, 67);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(146, 15);
            label2.TabIndex = 0;
            label2.Text = "Username/Email/Number:";
            // 
            // userTxtBox
            // 
            userTxtBox.Location = new System.Drawing.Point(13, 84);
            userTxtBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            userTxtBox.Name = "userTxtBox";
            userTxtBox.Size = new System.Drawing.Size(266, 23);
            userTxtBox.TabIndex = 2;
            userTxtBox.TextChanged += userTxtBox_TextChanged;
            userTxtBox.Validating += userTxtBox_Validating;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(13, 126);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(60, 15);
            label3.TabIndex = 0;
            label3.Text = "Password:\r\n";
            // 
            // pwdTxtBox
            // 
            pwdTxtBox.Location = new System.Drawing.Point(13, 142);
            pwdTxtBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pwdTxtBox.Name = "pwdTxtBox";
            pwdTxtBox.Size = new System.Drawing.Size(236, 23);
            pwdTxtBox.TabIndex = 3;
            pwdTxtBox.UseSystemPasswordChar = true;
            pwdTxtBox.TextChanged += pwdTxtBox_TextChanged;
            pwdTxtBox.Validating += pwdTxtBox_Validating;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(171, 222);
            cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(88, 27);
            cancelButton.TabIndex = 4;
            cancelButton.TabStop = false;
            cancelButton.Text = "No";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // pictureShowPassword
            // 
            pictureShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureShowPassword.Image = global::PwdKeychain.Properties.Images.hide24;
            pictureShowPassword.Location = new System.Drawing.Point(255, 142);
            pictureShowPassword.Name = "pictureShowPassword";
            pictureShowPassword.Size = new System.Drawing.Size(24, 24);
            pictureShowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureShowPassword.TabIndex = 6;
            pictureShowPassword.TabStop = false;
            pictureShowPassword.MouseDown += pictureShowPassword_MouseDown;
            pictureShowPassword.MouseEnter += pictureShowPassword_MouseEnter;
            pictureShowPassword.MouseLeave += pictureShowPassword_MouseLeave;
            // 
            // pictureCopyPassword
            // 
            pictureCopyPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureCopyPassword.Image = global::PwdKeychain.Properties.Images.copy24;
            pictureCopyPassword.Location = new System.Drawing.Point(284, 142);
            pictureCopyPassword.Name = "pictureCopyPassword";
            pictureCopyPassword.Size = new System.Drawing.Size(24, 24);
            pictureCopyPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureCopyPassword.TabIndex = 7;
            pictureCopyPassword.TabStop = false;
            pictureCopyPassword.Click += pictureCopyPassword_Click;
            pictureCopyPassword.MouseEnter += pictureCopyPassword_MouseEnter;
            pictureCopyPassword.MouseLeave += pictureCopyPassword_MouseLeave;
            // 
            // generalTooltip
            // 
            generalTooltip.AutoPopDelay = 5000;
            generalTooltip.InitialDelay = 300;
            generalTooltip.ReshowDelay = 100;
            // 
            // generateRandomPassword
            // 
            generateRandomPassword.AutoSize = true;
            generateRandomPassword.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            generateRandomPassword.Location = new System.Drawing.Point(185, 184);
            generateRandomPassword.Name = "generateRandomPassword";
            generateRandomPassword.Size = new System.Drawing.Size(63, 23);
            generateRandomPassword.TabIndex = 8;
            generateRandomPassword.Text = "Generate\r\n";
            generateRandomPassword.UseVisualStyleBackColor = true;
            generateRandomPassword.Click += generateRandomPassword_Click;
            // 
            // strengthLabel
            // 
            strengthLabel.Location = new System.Drawing.Point(78, 188);
            strengthLabel.Name = "strengthLabel";
            strengthLabel.Size = new System.Drawing.Size(90, 15);
            strengthLabel.TabIndex = 10;
            strengthLabel.Text = "? ? ?";
            // 
            // strengthPanel1
            // 
            strengthPanel1.BackColor = System.Drawing.Color.LightGray;
            strengthPanel1.Location = new System.Drawing.Point(15, 185);
            strengthPanel1.Name = "strengthPanel1";
            strengthPanel1.Size = new System.Drawing.Size(10, 20);
            strengthPanel1.TabIndex = 11;
            // 
            // strengthPanel2
            // 
            strengthPanel2.BackColor = System.Drawing.Color.LightGray;
            strengthPanel2.Location = new System.Drawing.Point(27, 185);
            strengthPanel2.Name = "strengthPanel2";
            strengthPanel2.Size = new System.Drawing.Size(10, 20);
            strengthPanel2.TabIndex = 12;
            // 
            // strengthPanel4
            // 
            strengthPanel4.BackColor = System.Drawing.Color.LightGray;
            strengthPanel4.Location = new System.Drawing.Point(51, 185);
            strengthPanel4.Name = "strengthPanel4";
            strengthPanel4.Size = new System.Drawing.Size(10, 20);
            strengthPanel4.TabIndex = 14;
            // 
            // strengthPanel3
            // 
            strengthPanel3.BackColor = System.Drawing.Color.LightGray;
            strengthPanel3.Location = new System.Drawing.Point(39, 185);
            strengthPanel3.Name = "strengthPanel3";
            strengthPanel3.Size = new System.Drawing.Size(10, 20);
            strengthPanel3.TabIndex = 13;
            // 
            // strengthPanel5
            // 
            strengthPanel5.BackColor = System.Drawing.Color.LightGray;
            strengthPanel5.Location = new System.Drawing.Point(63, 185);
            strengthPanel5.Name = "strengthPanel5";
            strengthPanel5.Size = new System.Drawing.Size(10, 20);
            strengthPanel5.TabIndex = 15;
            // 
            // strengthPanel6
            // 
            strengthPanel6.BackColor = System.Drawing.Color.Transparent;
            strengthPanel6.Location = new System.Drawing.Point(75, 185);
            strengthPanel6.Name = "strengthPanel6";
            strengthPanel6.Size = new System.Drawing.Size(10, 20);
            strengthPanel6.TabIndex = 16;
            // 
            // pictureCopyUsername
            // 
            pictureCopyUsername.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureCopyUsername.Image = global::PwdKeychain.Properties.Images.copy24;
            pictureCopyUsername.Location = new System.Drawing.Point(284, 84);
            pictureCopyUsername.Name = "pictureCopyUsername";
            pictureCopyUsername.Size = new System.Drawing.Size(24, 24);
            pictureCopyUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureCopyUsername.TabIndex = 17;
            pictureCopyUsername.TabStop = false;
            pictureCopyUsername.Click += pictureCopyUsername_Click;
            // 
            // labelErrorWebsite
            // 
            labelErrorWebsite.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)0));
            labelErrorWebsite.ForeColor = System.Drawing.Color.Red;
            labelErrorWebsite.Location = new System.Drawing.Point(14, 51);
            labelErrorWebsite.Name = "labelErrorWebsite";
            labelErrorWebsite.Size = new System.Drawing.Size(145, 13);
            labelErrorWebsite.TabIndex = 18;
            // 
            // labelErrorUsername
            // 
            labelErrorUsername.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)0));
            labelErrorUsername.ForeColor = System.Drawing.Color.Red;
            labelErrorUsername.Location = new System.Drawing.Point(14, 108);
            labelErrorUsername.Name = "labelErrorUsername";
            labelErrorUsername.Size = new System.Drawing.Size(145, 13);
            labelErrorUsername.TabIndex = 19;
            // 
            // labelErrorPassword
            // 
            labelErrorPassword.BackColor = System.Drawing.Color.Transparent;
            labelErrorPassword.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)0));
            labelErrorPassword.ForeColor = System.Drawing.Color.Red;
            labelErrorPassword.Location = new System.Drawing.Point(14, 165);
            labelErrorPassword.Name = "labelErrorPassword";
            labelErrorPassword.Size = new System.Drawing.Size(145, 13);
            labelErrorPassword.TabIndex = 20;
            // 
            // EntryAndEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(321, 264);
            Controls.Add(labelErrorPassword);
            Controls.Add(labelErrorUsername);
            Controls.Add(labelErrorWebsite);
            Controls.Add(strengthLabel);
            Controls.Add(pictureCopyUsername);
            Controls.Add(strengthPanel6);
            Controls.Add(strengthPanel5);
            Controls.Add(strengthPanel4);
            Controls.Add(strengthPanel3);
            Controls.Add(strengthPanel2);
            Controls.Add(strengthPanel1);
            Controls.Add(generateRandomPassword);
            Controls.Add(pictureCopyPassword);
            Controls.Add(pictureShowPassword);
            Controls.Add(cancelButton);
            Controls.Add(pwdTxtBox);
            Controls.Add(label3);
            Controls.Add(userTxtBox);
            Controls.Add(label2);
            Controls.Add(websiteTxtBox);
            Controls.Add(label1);
            Controls.Add(entryAndEditButt);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "NameAction Here";
            TopMost = true;
            Load += EntryAndEditForm_Load;
            KeyDown += EntryAndEditForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureShowPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureCopyPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureCopyUsername).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label labelErrorPassword;

        private System.Windows.Forms.Label labelErrorUsername;

        private System.Windows.Forms.Label labelErrorWebsite;

        private System.Windows.Forms.Panel strengthPanel6;
        private System.Windows.Forms.PictureBox pictureCopyUsername;

        private System.Windows.Forms.Panel strengthPanel2;
        private System.Windows.Forms.Panel strengthPanel4;
        private System.Windows.Forms.Panel strengthPanel3;
        private System.Windows.Forms.Panel strengthPanel5;

        private System.Windows.Forms.Panel strengthPanel1;

        private System.Windows.Forms.Label strengthLabel;

        private System.Windows.Forms.Button generateRandomPassword;

        private System.Windows.Forms.ToolTip generalTooltip;

        private System.Windows.Forms.PictureBox pictureShowPassword;
        private System.Windows.Forms.PictureBox pictureCopyPassword;

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