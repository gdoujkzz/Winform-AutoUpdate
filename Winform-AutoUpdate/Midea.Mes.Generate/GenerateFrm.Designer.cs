namespace Midea.Mes.Generate
{
    partial class GenerateFrm
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnPublishTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(13, 13);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(119, 27);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "生成更新文件";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnPublishTest
            // 
            this.btnPublishTest.Location = new System.Drawing.Point(180, 13);
            this.btnPublishTest.Name = "btnPublishTest";
            this.btnPublishTest.Size = new System.Drawing.Size(126, 27);
            this.btnPublishTest.TabIndex = 1;
            this.btnPublishTest.Text = "一键部署到测试环境";
            this.btnPublishTest.UseVisualStyleBackColor = true;
            // 
            // GenerateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPublishTest);
            this.Controls.Add(this.btnGenerate);
            this.Name = "GenerateFrm";
            this.Text = "更新文件生成程序";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnPublishTest;
    }
}

