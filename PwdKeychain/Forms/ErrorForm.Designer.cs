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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            this.closeButt = new System.Windows.Forms.Button();
            this.copyAndClose = new System.Windows.Forms.Button();
            this.ErrMsgPanel = new System.Windows.Forms.Panel();
            this.ErrMsgLabel = new System.Windows.Forms.Label();
            this.ErrMsgPanel.SuspendLayout();
            this.SuspendLayout();
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
            // ErrMsgPanel
            // 
            this.ErrMsgPanel.AutoScroll = true;
            this.ErrMsgPanel.Controls.Add(this.ErrMsgLabel);
            this.ErrMsgPanel.Location = new System.Drawing.Point(12, 12);
            this.ErrMsgPanel.Name = "ErrMsgPanel";
            this.ErrMsgPanel.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.ErrMsgPanel.Size = new System.Drawing.Size(483, 161);
            this.ErrMsgPanel.TabIndex = 3;
            // 
            // ErrMsgLabel
            // 
            this.ErrMsgLabel.AutoSize = true;
            this.ErrMsgLabel.Location = new System.Drawing.Point(3, 1);
            this.ErrMsgLabel.MaximumSize = new System.Drawing.Size(460, 0);
            this.ErrMsgLabel.Name = "ErrMsgLabel";
            this.ErrMsgLabel.Size = new System.Drawing.Size(106, 13);
            this.ErrMsgLabel.TabIndex = 0;
            this.ErrMsgLabel.Text = "Exceptions Info Here";
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(507, 214);
            this.Controls.Add(this.ErrMsgPanel);
            this.Controls.Add(this.copyAndClose);
            this.Controls.Add(this.closeButt);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExceptionTitle";
            this.ErrMsgPanel.ResumeLayout(false);
            this.ErrMsgPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel ErrMsgPanel;
        private System.Windows.Forms.Label ErrMsgLabel;

        private System.Windows.Forms.Button copyAndClose;

        private System.Windows.Forms.Button closeButt;

        #endregion
    }
}