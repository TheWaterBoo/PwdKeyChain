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
            this.SuspendLayout();
            // 
            // entryAndEditButt
            // 
            this.entryAndEditButt.Location = new System.Drawing.Point(204, 167);
            this.entryAndEditButt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.entryAndEditButt.Name = "entryAndEditButt";
            this.entryAndEditButt.Size = new System.Drawing.Size(100, 28);
            this.entryAndEditButt.TabIndex = 0;
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
            this.label1.TabIndex = 1;
            this.label1.Text = "Website name:";
            // 
            // websiteTxtBox
            // 
            this.websiteTxtBox.Location = new System.Drawing.Point(157, 27);
            this.websiteTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.websiteTxtBox.Name = "websiteTxtBox";
            this.websiteTxtBox.Size = new System.Drawing.Size(337, 22);
            this.websiteTxtBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username / Email:";
            // 
            // userTxtBox
            // 
            this.userTxtBox.Location = new System.Drawing.Point(157, 64);
            this.userTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userTxtBox.Name = "userTxtBox";
            this.userTxtBox.Size = new System.Drawing.Size(337, 22);
            this.userTxtBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:\r\n";
            // 
            // pwdTxtBox
            // 
            this.pwdTxtBox.Location = new System.Drawing.Point(157, 101);
            this.pwdTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pwdTxtBox.Name = "pwdTxtBox";
            this.pwdTxtBox.Size = new System.Drawing.Size(337, 22);
            this.pwdTxtBox.TabIndex = 6;
            // 
            // EntryAndEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 210);
            this.Controls.Add(this.pwdTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.websiteTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.entryAndEditButt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntryAndEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NameAction Here";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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