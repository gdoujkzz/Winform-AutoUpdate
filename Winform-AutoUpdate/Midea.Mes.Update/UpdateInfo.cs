using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midea.Mes.Update
{
    public class UpdateInfo
    {
        public string Version { get; set; }

        public DateTime UpdateTime { get; set; }

        public string UpdateFileUrl { get; set; }

        /// <summary>
        /// 文件列表
        /// </summary>
        public List<string[]> FileList { get; set; } 

    }
}
