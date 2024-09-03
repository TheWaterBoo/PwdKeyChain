using System.ComponentModel;

namespace PwdKeychain.Forms
{
    partial class ErrorForm
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
            this.MsgErrorLabel = new System.Windows.Forms.Label();
            this.closeButt = new System.Windows.Forms.Button();
            this.copyAndClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MsgErrorLabel
            // 
            this.MsgErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MsgErrorLabel.Location = new System.Drawing.Point(12, 9);
            this.MsgErrorLabel.Name = "MsgErrorLabel";
            this.MsgErrorLabel.Size = new System.Drawing.Size(483, 150);
            this.MsgErrorLabel.TabIndex = 0;
            this.MsgErrorLabel.Text = "Exception Messages Here";
            // 
            // closeButt
            // 
            this.closeButt.Location = new System.Drawing.Point(12, 179);
            this.closeButt.Name = "closeButt";
            this.closeButt.Size = new System.Drawing.Size(79, 23);
            this.closeButt.TabIndex = 1;
            this.closeButt.Text = "Close";
            this.closeButt.UseVisualStyleBackColor = true;
            this.closeButt.Click += new System.EventHandler(this.closeButt_Click);
            // 
            // copyAndClose
            // 
            this.copyAndClose.Location = new System.Drawing.Point(317, 179);
            this.copyAndClose.Name = "copyAndClose";
            this.copyAndClose.Size = new System.Drawing.Size(178, 23);
            this.copyAndClose.TabIndex = 2;
            this.copyAndClose.Text = "Copy to clipboard and close";
            this.copyAndClose.UseVisualStyleBackColor = true;
            this.copyAndClose.Click += new System.EventHandler(this.copyAndClose_Click);
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(507, 214);
            this.Controls.Add(this.copyAndClose);
            this.Controls.Add(this.closeButt);
            this.Controls.Add(this.MsgErrorLabel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExceptionTitle";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button copyAndClose;

        private System.Windows.Forms.Button closeButt;

        private System.Windows.Forms.Label MsgErrorLabel;

        #endregion
    }
}