namespace PwdKeychain
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.websiteTxtBox = new System.Windows.Forms.TextBox();
            this.userTxtBox = new System.Windows.Forms.TextBox();
            this.pwdTxtBox = new System.Windows.Forms.TextBox();
            this.addPass = new System.Windows.Forms.Button();
            this.editPass = new System.Windows.Forms.Button();
            this.deletePass = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listViewShowPass = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addDataButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // websiteTxtBox
            // 
            this.websiteTxtBox.Location = new System.Drawing.Point(116, 102);
            this.websiteTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.websiteTxtBox.Name = "websiteTxtBox";
            this.websiteTxtBox.Size = new System.Drawing.Size(120, 20);
            this.websiteTxtBox.TabIndex = 0;
            // 
            // userTxtBox
            // 
            this.userTxtBox.Location = new System.Drawing.Point(116, 138);
            this.userTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.userTxtBox.Name = "userTxtBox";
            this.userTxtBox.Size = new System.Drawing.Size(120, 20);
            this.userTxtBox.TabIndex = 1;
            // 
            // pwdTxtBox
            // 
            this.pwdTxtBox.Location = new System.Drawing.Point(116, 176);
            this.pwdTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.pwdTxtBox.Name = "pwdTxtBox";
            this.pwdTxtBox.Size = new System.Drawing.Size(120, 20);
            this.pwdTxtBox.TabIndex = 2;
            // 
            // addPass
            // 
            this.addPass.Location = new System.Drawing.Point(28, 216);
            this.addPass.Margin = new System.Windows.Forms.Padding(2);
            this.addPass.Name = "addPass";
            this.addPass.Size = new System.Drawing.Size(56, 19);
            this.addPass.TabIndex = 3;
            this.addPass.Text = "Add";
            this.addPass.UseVisualStyleBackColor = true;
            this.addPass.Click += new System.EventHandler(this.addPass_Click);
            // 
            // editPass
            // 
            this.editPass.Location = new System.Drawing.Point(165, 216);
            this.editPass.Margin = new System.Windows.Forms.Padding(2);
            this.editPass.Name = "editPass";
            this.editPass.Size = new System.Drawing.Size(56, 19);
            this.editPass.TabIndex = 4;
            this.editPass.Text = "Edit";
            this.editPass.UseVisualStyleBackColor = true;
            this.editPass.Click += new System.EventHandler(this.editPass_Click);
            // 
            // deletePass
            // 
            this.deletePass.Location = new System.Drawing.Point(28, 258);
            this.deletePass.Margin = new System.Windows.Forms.Padding(2);
            this.deletePass.Name = "deletePass";
            this.deletePass.Size = new System.Drawing.Size(56, 19);
            this.deletePass.TabIndex = 5;
            this.deletePass.Text = "Delete";
            this.deletePass.UseVisualStyleBackColor = true;
            this.deletePass.Click += new System.EventHandler(this.deletePass_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(155, 258);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(73, 37);
            this.button4.TabIndex = 6;
            this.button4.Text = "Show Saved Pass";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // listViewShowPass
            // 
            this.listViewShowPass.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewShowPass.HideSelection = false;
            this.listViewShowPass.Location = new System.Drawing.Point(258, 102);
            this.listViewShowPass.Margin = new System.Windows.Forms.Padding(2);
            this.listViewShowPass.Name = "listViewShowPass";
            this.listViewShowPass.Size = new System.Drawing.Size(534, 348);
            this.listViewShowPass.TabIndex = 7;
            this.listViewShowPass.TileSize = new System.Drawing.Size(1, 1);
            this.listViewShowPass.UseCompatibleStateImageBehavior = false;
            this.listViewShowPass.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Website";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 176);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Usuario";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.addDataButton, this.toolStripButton5, this.toolStripButton4 });
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(803, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addDataButton
            // 
            this.addDataButton.Image = global::PwdKeychain.Properties.Images.add32;
            this.addDataButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addDataButton.Name = "addDataButton";
            this.addDataButton.Size = new System.Drawing.Size(76, 22);
            this.addDataButton.Text = "Add New";
            this.addDataButton.Click += new System.EventHandler(this.addDataButton_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Enabled = false;
            this.toolStripButton5.Image = global::PwdKeychain.Properties.Images.pencil32;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(47, 22);
            this.toolStripButton5.Text = "Edit";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Enabled = false;
            this.toolStripButton4.Image = global::PwdKeychain.Properties.Images.delete32;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton4.Text = "Delete";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton3.Text = "Add";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 474);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewShowPass);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.deletePass);
            this.Controls.Add(this.editPass);
            this.Controls.Add(this.addPass);
            this.Controls.Add(this.pwdTxtBox);
            this.Controls.Add(this.userTxtBox);
            this.Controls.Add(this.websiteTxtBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Alpha0.0.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripButton toolStripButton4;

        private System.Windows.Forms.ToolStripButton toolStripButton5;

        private System.Windows.Forms.ToolStripButton addDataButton;

        private System.Windows.Forms.ToolStripButton toolStripButton3;

        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStrip toolStrip1;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.ListView listViewShowPass;

        private System.Windows.Forms.Button addPass;
        private System.Windows.Forms.Button editPass;
        private System.Windows.Forms.Button deletePass;
        private System.Windows.Forms.Button button4;

        private System.Windows.Forms.TextBox websiteTxtBox;
        private System.Windows.Forms.TextBox userTxtBox;
        private System.Windows.Forms.TextBox pwdTxtBox;

        #endregion
    }
}

