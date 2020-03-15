using Midea.Mes.Update;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Midea.Mes.Frm
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void checkUpdateMenu_Click(object sender, EventArgs e)
        {
            //检查系统更新
            var objUpdateManager = new UpdateManger();
            try
            {
                if (!objUpdateManager.IsUpdate)
                {
                    MessageBox.Show("当前版本已经是最新的，不需要升级!!!", "提示信息");
                    return;
                }
                if (MessageBox.Show("为了更新系统,将退出当前程序,请确保数据已保存,确认退出吗?", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Application.Exit();
                    System.Diagnostics.Process.Start("Midea.Mes.Update.exe");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法连接服务器,请检查问题,原因" + ex.Message);
            }
        }
    }
}
