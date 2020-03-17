namespace Midea.Mes.Frm
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.生产ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.物流ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUpdateMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.生产标签打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生产标签打印V10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生产ToolStripMenuItem,
            this.物流ToolStripMenuItem,
            this.打印ToolStripMenuItem,
            this.采集ToolStripMenuItem,
            this.SystemMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(843, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 生产ToolStripMenuItem
            // 
            this.生产ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生产标签打印ToolStripMenuItem,
            this.生产标签打印V10ToolStripMenuItem});
            this.生产ToolStripMenuItem.Name = "生产ToolStripMenuItem";
            this.生产ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.生产ToolStripMenuItem.Text = "生产";
            // 
            // 物流ToolStripMenuItem
            // 
            this.物流ToolStripMenuItem.Name = "物流ToolStripMenuItem";
            this.物流ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.物流ToolStripMenuItem.Text = "物流";
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.打印ToolStripMenuItem.Text = "打印";
            // 
            // 采集ToolStripMenuItem
            // 
            this.采集ToolStripMenuItem.Name = "采集ToolStripMenuItem";
            this.采集ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.采集ToolStripMenuItem.Text = "采集";
            // 
            // SystemMenu
            // 
            this.SystemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于我们ToolStripMenuItem,
            this.checkUpdateMenu});
            this.SystemMenu.Name = "SystemMenu";
            this.SystemMenu.Size = new System.Drawing.Size(44, 21);
            this.SystemMenu.Text = "系统";
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.关于我们ToolStripMenuItem.Text = "关于我们";
            // 
            // checkUpdateMenu
            // 
            this.checkUpdateMenu.Name = "checkUpdateMenu";
            this.checkUpdateMenu.Size = new System.Drawing.Size(180, 22);
            this.checkUpdateMenu.Text = "系统更新";
            this.checkUpdateMenu.Click += new System.EventHandler(this.checkUpdateMenu_Click);
            // 
            // 生产标签打印ToolStripMenuItem
            // 
            this.生产标签打印ToolStripMenuItem.Name = "生产标签打印ToolStripMenuItem";
            this.生产标签打印ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.生产标签打印ToolStripMenuItem.Text = "生产标签打印";
            // 
            // 生产标签打印V10ToolStripMenuItem
            // 
            this.生产标签打印V10ToolStripMenuItem.Name = "生产标签打印V10ToolStripMenuItem";
            this.生产标签打印V10ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.生产标签打印V10ToolStripMenuItem.Text = "生产标签打印V1.0";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 315);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrm";
            this.Text = "这是我们的MES主程序";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 生产ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 物流ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 采集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SystemMenu;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkUpdateMenu;
        private System.Windows.Forms.ToolStripMenuItem 生产标签打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生产标签打印V10ToolStripMenuItem;
    }
}

