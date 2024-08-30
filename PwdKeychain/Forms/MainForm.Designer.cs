namespace PwdKeychain.Forms
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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addDataButton = new System.Windows.Forms.ToolStripButton();
            this.editDataButton = new System.Windows.Forms.ToolStripButton();
            this.deleteDataButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.accGridView = new System.Windows.Forms.DataGridView();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accGridView)).BeginInit();
            this.SuspendLayout();
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
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.addDataButton, this.editDataButton, this.deleteDataButton, this.toolStripButton4 });
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(314, 25);
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
            this.deleteDataButton.Click += new System.EventHandler(this.deleteDataButton_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(53, 22);
            this.toolStripButton4.Text = "Drop";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
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
            this.accGridView.Location = new System.Drawing.Point(9, 32);
            this.accGridView.Margin = new System.Windows.Forms.Padding(2);
            this.accGridView.Name = "accGridView";
            this.accGridView.ReadOnly = true;
            this.accGridView.RowTemplate.Height = 24;
            this.accGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.accGridView.Size = new System.Drawing.Size(296, 331);
            this.accGridView.TabIndex = 13;
            this.accGridView.SelectionChanged += new System.EventHandler(this.accGridView_SelectionChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 373);
            this.Controls.Add(this.accGridView);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

        private System.Windows.Forms.ToolStripButton toolStripButton4;

        private System.Windows.Forms.DataGridView accGridView;

        private System.Windows.Forms.ToolStripButton deleteDataButton;

        private System.Windows.Forms.ToolStripButton editDataButton;

        private System.Windows.Forms.ToolStripButton addDataButton;

        private System.Windows.Forms.ToolStripButton toolStripButton3;

        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStrip toolStrip1;

        #endregion
    }
}

