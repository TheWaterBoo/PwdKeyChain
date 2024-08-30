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
            this.SuspendLayout();
            // 
            // entryAndEditButt
            // 
            this.entryAndEditButt.Location = new System.Drawing.Point(108, 136);
            this.entryAndEditButt.Name = "entryAndEditButt";
            this.entryAndEditButt.Size = new System.Drawing.Size(75, 23);
            this.entryAndEditButt.TabIndex = 0;
            this.entryAndEditButt.TabStop = false;
            this.entryAndEditButt.Text = "Accept";
            this.entryAndEditButt.UseVisualStyleBackColor = true;
            this.entryAndEditButt.Click += new System.EventHandler(this.entryAndEditButt_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Website name:";
            // 
            // websiteTxtBox
            // 
            this.websiteTxtBox.Location = new System.Drawing.Point(118, 22);
            this.websiteTxtBox.Name = "websiteTxtBox";
            this.websiteTxtBox.Size = new System.Drawing.Size(254, 20);
            this.websiteTxtBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username / Email:";
            // 
            // userTxtBox
            // 
            this.userTxtBox.Location = new System.Drawing.Point(118, 52);
            this.userTxtBox.Name = "userTxtBox";
            this.userTxtBox.Size = new System.Drawing.Size(254, 20);
            this.userTxtBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password:\r\n";
            // 
            // pwdTxtBox
            // 
            this.pwdTxtBox.Location = new System.Drawing.Point(118, 82);
            this.pwdTxtBox.Name = "pwdTxtBox";
            this.pwdTxtBox.Size = new System.Drawing.Size(254, 20);
            this.pwdTxtBox.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(208, 136);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.TabStop = false;
            this.cancelButton.Text = "No";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // EntryAndEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 171);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.pwdTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.websiteTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.entryAndEditButt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntryAndEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NameAction Here";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EntryAndEditForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntryAndEditForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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