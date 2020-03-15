using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Midea.Mes.Update
{
    public partial class UpdateFrm : Form
    {
        private UpdateManger objUpdateManager = new UpdateManger();
        public UpdateFrm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.btnFinish.Visible = false;
            //将委托变量，进行调用
            objUpdateManager.ShowProgressDelegate = this.ShowUpdateProgress;
            List<string[]> fileList = objUpdateManager.NowUpdateInfo.FileList;
            foreach (string[] item in fileList)
            {
                this.lvUpdateList.Items.Add(new ListViewItem(item));
            }
            //显示当前版本号。
            this.lblVersion.Text = objUpdateManager.LastUpdateInfo.Version;

        }

        private void ShowUpdateProgress(int fileIndex, int finishPercent)
        {
            //在列表框最后显示百分比。
            this.lvUpdateList.Items[fileIndex].SubItems[3].Text = finishPercent.ToString();
            //进度条显示。
            this.pbDownload.Maximum = 100;
            this.pbDownload.Value = finishPercent;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnNext.Enabled = false;
                this.lblDowonStatus.Text = "正在从服务器抓取文件,请稍后";
                //开始下载文件，同时异步显示百分比。
                this.objUpdateManager.DownloadFiles();
                this.lblDowonStatus.Text = "全部下载成功，点击完成结束升级";
                this.btnNext.Visible = false;
                this.btnCancel.Visible = false;
                this.btnFinish.Location = this.btnCancel.Location;
                this.btnFinish.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //复制文件到指定目录
            try
            {
                if (objUpdateManager.CopyFiles()) //调用复制方法，复制文件到程序
                {
                    //启动主程序
                    System.Diagnostics.Process.Start("Midea.Mes.Frm.exe");
                    //关闭主程序
                    Application.ExitThread();
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认取消升级吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.ExitThread();
                Application.Exit();
            }
        }
    }
}
