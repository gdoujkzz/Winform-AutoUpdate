using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Midea.Mes.Update
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UpdateStartFrm updateStartFrm = new UpdateStartFrm();
            DialogResult result = updateStartFrm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Application.Run(new UpdateFrm());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
