using System.ComponentModel;

namespace PwdKeychain.Forms
{
    partial class ConfirmationForm
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
            this.textInfoLabel = new System.Windows.Forms.Label();
            this.positiveButton = new System.Windows.Forms.Button();
            this.NegativeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textInfoLabel
            // 
            this.textInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInfoLabel.Location = new System.Drawing.Point(16, 11);
            this.textInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textInfoLabel.Name = "textInfoLabel";
            this.textInfoLabel.Size = new System.Drawing.Size(345, 78);
            this.textInfoLabel.TabIndex = 0;
            this.textInfoLabel.Text = "Put some text here, also modify the text Buttons";
            this.textInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // positiveButton
            // 
            this.positiveButton.Location = new System.Drawing.Point(87, 106);
            this.positiveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.positiveButton.Name = "positiveButton";
            this.positiveButton.Size = new System.Drawing.Size(100, 28);
            this.positiveButton.TabIndex = 1;
            this.positiveButton.Text = "Sure";
            this.positiveButton.UseVisualStyleBackColor = true;
            this.positiveButton.Click += new System.EventHandler(this.positiveButton_Click);
            // 
            // NegativeButton
            // 
            this.NegativeButton.Location = new System.Drawing.Point(195, 106);
            this.NegativeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NegativeButton.Name = "NegativeButton";
            this.NegativeButton.Size = new System.Drawing.Size(100, 28);
            this.NegativeButton.TabIndex = 2;
            this.NegativeButton.Text = "Cancel";
            this.NegativeButton.UseVisualStyleBackColor = true;
            this.NegativeButton.Click += new System.EventHandler(this.NegativeButton_Click);
            // 
            // ConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 149);
            this.Controls.Add(this.NegativeButton);
            this.Controls.Add(this.positiveButton);
            this.Controls.Add(this.textInfoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Action name";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label textInfoLabel;
        private System.Windows.Forms.Button positiveButton;
        private System.Windows.Forms.Button NegativeButton;

        #endregion
    }
}