using System.ComponentModel;

namespace PwdKeychain.Forms;

partial class AuthorizationForm
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
        passwordTextBox = new System.Windows.Forms.TextBox();
        enterButton = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // passwordTextBox
        // 
        passwordTextBox.Location = new System.Drawing.Point(27, 54);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.Size = new System.Drawing.Size(199, 23);
        passwordTextBox.TabIndex = 0;
        // 
        // enterButton
        // 
        enterButton.Location = new System.Drawing.Point(90, 95);
        enterButton.Name = "enterButton";
        enterButton.Size = new System.Drawing.Size(71, 32);
        enterButton.TabIndex = 1;
        enterButton.Text = "Enter";
        enterButton.UseVisualStyleBackColor = true;
        enterButton.Click += loginButton_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(27, 35);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(64, 16);
        label1.TabIndex = 2;
        label1.Text = "Password:";
        // 
        // AuthorizationForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(254, 149);
        Controls.Add(label1);
        Controls.Add(enterButton);
        Controls.Add(passwordTextBox);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "LogIn";
        Load += AuthorizationForm_Load;
        KeyDown += AuthorizationFrom_KeyDown;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.Button enterButton;

    #endregion
}