using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midea.Mes.Generate
{
    public  class UpdateFileModel
    {
        public string Name { get; set; }

        public string Ext { get; set; }

        public DateTime LastModifyTime { get; set; }

        public string RelativeDir { get; set; }

        public long Lenght { get; set; }

        public string Version { get; set; }
    }
}
