using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Xml;

namespace Midea.Mes.Generate
{
    public partial class GenerateFrm : Form
    {
        public GenerateFrm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //从指定目录下读取出文件。
            var rootDir = ConfigurationManager.AppSettings["SearchDir"];
            var ignoredDir = ConfigurationManager.AppSettings["IgnoredDir"];
            var AdancedDay = ConfigurationManager.AppSettings["AddvancedDay"];
            string version = "1.0.0.1";
            string url = ConfigurationManager.AppSettings["URL"];
            string num = "1.0.0.1";
            string date = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            var updateFiles = GetUpdateFileModels(rootDir, version);
            //去除包含pdb文件
            updateFiles = updateFiles.Where(d => !d.Name.Contains("pdb")&&!d.Name.Contains("Update")).ToList();
            //然后根据需要做一些筛选。
            //生成XML文件
            BuildXMLFile(updateFiles, url, num, date);
        }

        private void BuildXMLFile(List<UpdateFileModel> updateFiles,string url,string num,string date)
        {
            //用DOM的方式来操作XML。
            if (File.Exists("UpdateList.xml"))
            {
                File.Delete("UpdateList.xml");
            }
            XmlDocument xd = new XmlDocument();
            XmlDeclaration xmlDeclaration = xd.CreateXmlDeclaration("1.0", "utf-8", "");
            xd.AppendChild(xmlDeclaration);
            XmlElement root = xd.CreateElement("AutoUpdater");
            xd.AppendChild(root);

            XmlElement urlElement = xd.CreateElement("URLAddress");
            urlElement.SetAttribute("URL", url);

            XmlElement updateElement = xd.CreateElement("UpdateInfo");

            XmlElement versionElement = xd.CreateElement("Version");
            versionElement.SetAttribute("Num", num);

            XmlElement updateTimeElement = xd.CreateElement("UpdateTime");
            updateTimeElement.SetAttribute("Date", date);

            updateElement.AppendChild(versionElement);
            updateElement.AppendChild(updateTimeElement);
            XmlElement updateFileListEle = xd.CreateElement("UpdateFileList");
            foreach(var file in updateFiles)
            {
                XmlElement updateFileEle = xd.CreateElement("UpdateFile");
                updateFileEle.SetAttribute("Ver",file.Version);
                updateFileEle.SetAttribute("FileName",file.Name);
                updateFileEle.SetAttribute("ContentLength",file.Lenght.ToString());
                updateFileListEle.AppendChild(updateFileEle);
            }
            root.AppendChild(updateFileListEle);
            root.AppendChild(urlElement);
            root.AppendChild(updateElement);
            xd.Save("UpdateList.xml");
        }




        private List<UpdateFileModel> GetUpdateFileModels(string rootDir,string version)
        {
            var result = new List<UpdateFileModel>();
            var filePaths = new List<string>();
            GetFiles(rootDir, filePaths);
            var fileModels = new List<UpdateFileModel>();
            foreach (var t in filePaths)
            {
                var fileInfo = new FileInfo(t);
                result.Add(new UpdateFileModel()
                {
                    Ext = fileInfo.Extension,
                    Name = fileInfo.Name,
                    RelativeDir = fileInfo.DirectoryName.Replace(rootDir, ""),
                    LastModifyTime = fileInfo.LastWriteTime,
                    Lenght = fileInfo.Length,
                    Version= version
                });
            }
            return result;
        }


        private void GetFiles(string rootDir, List<string> files)
        {
            var dirs = Directory.GetDirectories(rootDir);
            foreach (var dir in dirs)
            {
                GetFiles(dir, files);
            }
            files.AddRange(Directory.GetFiles(rootDir));
        }



    }
}
