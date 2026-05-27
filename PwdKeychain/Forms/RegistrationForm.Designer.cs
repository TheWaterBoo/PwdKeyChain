using System.ComponentModel;

namespace PwdKeychain.Forms;

partial class RegistrationForm
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
        registerButton = new System.Windows.Forms.Button();
        registerTextBox = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // registerButton
        // 
        registerButton.Location = new System.Drawing.Point(76, 81);
        registerButton.Name = "registerButton";
        registerButton.Size = new System.Drawing.Size(75, 23);
        registerButton.TabIndex = 0;
        registerButton.Text = "Register";
        registerButton.UseVisualStyleBackColor = true;
        registerButton.Click += registerButton_Click;
        // 
        // registerTextBox
        // 
        registerTextBox.Location = new System.Drawing.Point(26, 41);
        registerTextBox.Name = "registerTextBox";
        registerTextBox.Size = new System.Drawing.Size(177, 23);
        registerTextBox.TabIndex = 1;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(26, 22);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 16);
        label1.TabIndex = 2;
        label1.Text = "Set a password:";
        // 
        // RegistrationForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(225, 130);
        Controls.Add(label1);
        Controls.Add(registerTextBox);
        Controls.Add(registerButton);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Register";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.TextBox registerTextBox;

    private System.Windows.Forms.Button registerButton;

    #endregion
}