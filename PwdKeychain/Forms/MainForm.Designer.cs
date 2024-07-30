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
            this.listViewShowPass = new System.Windows.Forms.ListView();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addDataButton = new System.Windows.Forms.ToolStripButton();
            this.editDataButton = new System.Windows.Forms.ToolStripButton();
            this.deleteDataButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.accGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewShowPass
            // 
            this.listViewShowPass.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewShowPass.HideSelection = false;
            this.listViewShowPass.Location = new System.Drawing.Point(115, 454);
            this.listViewShowPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewShowPass.Name = "listViewShowPass";
            this.listViewShowPass.Size = new System.Drawing.Size(104, 67);
            this.listViewShowPass.TabIndex = 7;
            this.listViewShowPass.TileSize = new System.Drawing.Size(1, 1);
            this.listViewShowPass.UseCompatibleStateImageBehavior = false;
            this.listViewShowPass.View = System.Windows.Forms.View.List;
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
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.addDataButton, this.editDataButton, this.deleteDataButton });
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(359, 25);
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
            // editDataButton
            // 
            this.editDataButton.Enabled = false;
            this.editDataButton.Image = global::PwdKeychain.Properties.Images.pencil32;
            this.editDataButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editDataButton.Name = "editDataButton";
            this.editDataButton.Size = new System.Drawing.Size(47, 22);
            this.editDataButton.Text = "Edit";
            this.editDataButton.Click += new System.EventHandler(this.editDataButton_Click);
            // 
            // deleteDataButton
            // 
            this.deleteDataButton.Enabled = false;
            this.deleteDataButton.Image = global::PwdKeychain.Properties.Images.delete32;
            this.deleteDataButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteDataButton.Name = "deleteDataButton";
            this.deleteDataButton.Size = new System.Drawing.Size(60, 22);
            this.deleteDataButton.Text = "Delete";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton3.Text = "Add";
            // 
            // accGridView
            // 
            this.accGridView.AllowUserToAddRows = false;
            this.accGridView.AllowUserToDeleteRows = false;
            this.accGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accGridView.Location = new System.Drawing.Point(12, 40);
            this.accGridView.Name = "accGridView";
            this.accGridView.ReadOnly = true;
            this.accGridView.RowTemplate.Height = 24;
            this.accGridView.Size = new System.Drawing.Size(335, 398);
            this.accGridView.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 547);
            this.Controls.Add(this.accGridView);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listViewShowPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView accGridView;

        private System.Windows.Forms.ToolStripButton deleteDataButton;

        private System.Windows.Forms.ToolStripButton editDataButton;

        private System.Windows.Forms.ToolStripButton addDataButton;

        private System.Windows.Forms.ToolStripButton toolStripButton3;

        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStrip toolStrip1;

        private System.Windows.Forms.ListView listViewShowPass;

        #endregion
    }
}

