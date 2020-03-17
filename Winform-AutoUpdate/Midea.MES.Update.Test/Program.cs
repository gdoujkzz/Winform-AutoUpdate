using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Midea.MES.Update.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试类
            #region 测试XML文件的生成
            //string url = "www.baidu.com";
            //string num = "1.0.0.1";
            //string date = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd hh:mi:ss"));

            //XmlDocument xd = new XmlDocument();
            //XmlDeclaration xmlDeclaration=xd.CreateXmlDeclaration("1.0", "utf-8", "");
            //xd.AppendChild(xmlDeclaration);
            //XmlElement root=xd.CreateElement("AutoUpdater");
            //xd.AppendChild(root);

            //XmlElement urlElement = xd.CreateElement("URLAddress");
            //urlElement.SetAttribute("URL", url);

            //XmlElement updateElement = xd.CreateElement("UpdateInfo");

            //XmlElement versionElement = xd.CreateElement("Version");
            //versionElement.SetAttribute("Num", num);

            //XmlElement updateTimeElement = xd.CreateElement("UpdateTime");
            //updateTimeElement.SetAttribute("Date", date);

            //updateElement.AppendChild(versionElement);
            //updateElement.AppendChild(updateTimeElement);

            //XmlElement updateFileListEle = xd.CreateElement("UpdateFileList");
            //root.AppendChild(updateFileListEle);
            //root.AppendChild(urlElement);
            //root.AppendChild(updateElement);

            //xd.Save("test.xml");
            #endregion

            #region 测试文件
            //string dir = @"D:\workfile\运维小分队";
            //var files=new List<string>();
            //GetFiles(dir,files);
            //var fileModels = new List<FileModel>();
            //foreach(var t in files)
            //{
            //    var fileInfo = new FileInfo(t);
            //    fileModels.Add(new FileModel()
            //    {
            //        Ext = fileInfo.Extension,
            //        Name = fileInfo.Name,
            //        RelativeDir = fileInfo.DirectoryName.Replace(dir, ""),
            //        LastModifyTime=fileInfo.LastWriteTime,
            //        Lenght=fileInfo.Length
            //    }); 
            //    ; 
            //}
            //foreach(var file in fileModels)
            //{
            //    Console.WriteLine($"{file.Name} {file.Ext} {file.LastModifyTime} {file.RelativeDir}");
            //} 
            #endregion
            #region 测试文件的创建
            FileStream fileStream = new FileStream("test/zhangzhen.txt", FileMode.OpenOrCreate);
            var str = "我是中国人";
            fileStream.Write(Encoding.UTF8.GetBytes(str),0,str.Length);
            #endregion
            fileStream.Close();

            Console.ReadKey();


        }

        static void  GetFiles(string rootDir,List<string> files)
        {
            var dirs=Directory.GetDirectories(rootDir);
            foreach (var dir in dirs)
            {
                GetFiles(dir, files);
            }
            files.AddRange(Directory.GetFiles(rootDir));
        }

    }

    public class FileModel { 
    
           public string Name { get; set; }

           public string Ext { get; set; }

           public DateTime LastModifyTime { get; set; }

           public string RelativeDir { get; set; }

           public long Lenght { get; set; }
              
    }

}
