namespace Rouigram
{
    partial class Show
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.DragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Elipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ذخیرهبعنوانفایلمتنیToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ذخیرهبعنوانعکسToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اسکرینشاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DragControl
            // 
            this.DragControl.Fixed = true;
            this.DragControl.Horizontal = true;
            this.DragControl.TargetControl = null;
            this.DragControl.Vertical = true;
            // 
            // Elipse
            // 
            this.Elipse.ElipseRadius = 0;
            this.Elipse.TargetControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(488, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.اسکرینشاتToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "فایل";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ذخیرهبعنوانفایلمتنیToolStripMenuItem,
            this.ذخیرهبعنوانعکسToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "ذخیره";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // ذخیرهبعنوانفایلمتنیToolStripMenuItem
            // 
            this.ذخیرهبعنوانفایلمتنیToolStripMenuItem.Name = "ذخیرهبعنوانفایلمتنیToolStripMenuItem";
            this.ذخیرهبعنوانفایلمتنیToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.ذخیرهبعنوانفایلمتنیToolStripMenuItem.Text = "ذخیره بعنوان فایل متنی";
            // 
            // ذخیرهبعنوانعکسToolStripMenuItem
            // 
            this.ذخیرهبعنوانعکسToolStripMenuItem.Name = "ذخیرهبعنوانعکسToolStripMenuItem";
            this.ذخیرهبعنوانعکسToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.ذخیرهبعنوانعکسToolStripMenuItem.Text = "ذخیره بعنوان عکس";
            // 
            // اسکرینشاتToolStripMenuItem
            // 
            this.اسکرینشاتToolStripMenuItem.Name = "اسکرینشاتToolStripMenuItem";
            this.اسکرینشاتToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.اسکرینشاتToolStripMenuItem.Text = "اسکرین شات";
            // 
            // Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 421);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Show";
            this.Text = "SHow";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl DragControl;
        private Bunifu.Framework.UI.BunifuElipse Elipse;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ذخیرهبعنوانفایلمتنیToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ذخیرهبعنوانعکسToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem اسکرینشاتToolStripMenuItem;
    }
}