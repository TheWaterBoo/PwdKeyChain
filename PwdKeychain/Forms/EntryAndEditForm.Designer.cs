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
            panel3 = new System.Windows.Forms.Panel();
            panel4 = new System.Windows.Forms.Panel();
            strengthPanel2 = new System.Windows.Forms.Panel();
            strengthPanel4 = new System.Windows.Forms.Panel();
            strengthPanel3 = new System.Windows.Forms.Panel();
            strengthPanel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)pictureShowPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureCopyPassword).BeginInit();
            strengthPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // entryAndEditButt
            // 
            entryAndEditButt.Location = new System.Drawing.Point(63, 238);
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
            label1.Location = new System.Drawing.Point(13, 15);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Site name:";
            // 
            // websiteTxtBox
            // 
            websiteTxtBox.Location = new System.Drawing.Point(13, 31);
            websiteTxtBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            websiteTxtBox.Name = "websiteTxtBox";
            websiteTxtBox.Size = new System.Drawing.Size(296, 23);
            websiteTxtBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(13, 85);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(146, 15);
            label2.TabIndex = 0;
            label2.Text = "Username/Email/Number:";
            // 
            // userTxtBox
            // 
            userTxtBox.Location = new System.Drawing.Point(13, 102);
            userTxtBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            userTxtBox.Name = "userTxtBox";
            userTxtBox.Size = new System.Drawing.Size(296, 23);
            userTxtBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(13, 154);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(60, 15);
            label3.TabIndex = 0;
            label3.Text = "Password:\r\n";
            // 
            // pwdTxtBox
            // 
            pwdTxtBox.Location = new System.Drawing.Point(13, 170);
            pwdTxtBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pwdTxtBox.Name = "pwdTxtBox";
            pwdTxtBox.Size = new System.Drawing.Size(236, 23);
            pwdTxtBox.TabIndex = 3;
            pwdTxtBox.UseSystemPasswordChar = true;
            pwdTxtBox.TextChanged += pwdTxtBox_TextChanged;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(173, 238);
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
            pictureShowPassword.Location = new System.Drawing.Point(255, 170);
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
            pictureCopyPassword.Location = new System.Drawing.Point(284, 170);
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
            generateRandomPassword.Location = new System.Drawing.Point(186, 200);
            generateRandomPassword.Name = "generateRandomPassword";
            generateRandomPassword.Size = new System.Drawing.Size(63, 23);
            generateRandomPassword.TabIndex = 8;
            generateRandomPassword.Text = "Generate\r\n";
            generateRandomPassword.UseVisualStyleBackColor = true;
            generateRandomPassword.Click += generateRandomPassword_Click;
            // 
            // strengthLabel
            // 
            strengthLabel.Location = new System.Drawing.Point(79, 204);
            strengthLabel.Name = "strengthLabel";
            strengthLabel.Size = new System.Drawing.Size(101, 15);
            strengthLabel.TabIndex = 10;
            strengthLabel.Text = "? ? ?";
            // 
            // strengthPanel1
            // 
            strengthPanel1.BackColor = System.Drawing.Color.LightGray;
            strengthPanel1.Controls.Add(panel3);
            strengthPanel1.Controls.Add(panel4);
            strengthPanel1.Location = new System.Drawing.Point(14, 201);
            strengthPanel1.Name = "strengthPanel1";
            strengthPanel1.Size = new System.Drawing.Size(10, 20);
            strengthPanel1.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.Location = new System.Drawing.Point(35, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(10, 20);
            panel3.TabIndex = 14;
            // 
            // panel4
            // 
            panel4.Location = new System.Drawing.Point(24, 0);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(10, 20);
            panel4.TabIndex = 13;
            // 
            // strengthPanel2
            // 
            strengthPanel2.BackColor = System.Drawing.Color.LightGray;
            strengthPanel2.Location = new System.Drawing.Point(26, 201);
            strengthPanel2.Name = "strengthPanel2";
            strengthPanel2.Size = new System.Drawing.Size(10, 20);
            strengthPanel2.TabIndex = 12;
            // 
            // strengthPanel4
            // 
            strengthPanel4.BackColor = System.Drawing.Color.LightGray;
            strengthPanel4.Location = new System.Drawing.Point(50, 201);
            strengthPanel4.Name = "strengthPanel4";
            strengthPanel4.Size = new System.Drawing.Size(10, 20);
            strengthPanel4.TabIndex = 14;
            // 
            // strengthPanel3
            // 
            strengthPanel3.BackColor = System.Drawing.Color.LightGray;
            strengthPanel3.Location = new System.Drawing.Point(38, 201);
            strengthPanel3.Name = "strengthPanel3";
            strengthPanel3.Size = new System.Drawing.Size(10, 20);
            strengthPanel3.TabIndex = 13;
            // 
            // strengthPanel5
            // 
            strengthPanel5.BackColor = System.Drawing.Color.LightGray;
            strengthPanel5.Location = new System.Drawing.Point(63, 201);
            strengthPanel5.Name = "strengthPanel5";
            strengthPanel5.Size = new System.Drawing.Size(10, 20);
            strengthPanel5.TabIndex = 15;
            // 
            // EntryAndEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(323, 278);
            Controls.Add(strengthPanel5);
            Controls.Add(strengthPanel4);
            Controls.Add(strengthPanel3);
            Controls.Add(strengthPanel2);
            Controls.Add(strengthPanel1);
            Controls.Add(strengthLabel);
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
            strengthPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel strengthPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
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