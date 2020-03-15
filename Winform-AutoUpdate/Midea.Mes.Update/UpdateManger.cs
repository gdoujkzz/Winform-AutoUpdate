using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Midea.Mes.Update
{
    public class UpdateManger
    {

        public UpdateManger()
        {
            this.LastUpdateInfo = new UpdateInfo();
            this.NowUpdateInfo = new UpdateInfo();
            GetLastUpdateInfo();
            GetNowUpdateInfo();
        }

        //属性


        public UpdateInfo LastUpdateInfo { get; set; }

        public UpdateInfo NowUpdateInfo { get; set; }

        public bool IsUpdate
        {
            get
            {
                return this.LastUpdateInfo.UpdateTime < this.NowUpdateInfo.UpdateTime;
            }
        }

        /// <summary>
        /// 下载文件保存路径
        /// </summary>
        public string TempFilePath
        {
            get
            {
                string newTempPath = Environment.GetEnvironmentVariable("Temp") + "/updateFiles";
                //获取变量，临时变量
                if (!Directory.Exists(newTempPath))
                {
                    Directory.CreateDirectory(newTempPath);
                }
                return newTempPath;
            }
        }


        //方法

        //从本次获取上次更新的信息封装到属性
        private void GetLastUpdateInfo()
        {
            //从启动目录获取。
            FileStream myFile = new FileStream("UpdateList.xml", FileMode.Open);
            XmlTextReader xmlTextReader = new XmlTextReader(myFile);
            while (xmlTextReader.Read())
            {
                switch (xmlTextReader.Name)
                {
                    case "URLAddress":
                        this.LastUpdateInfo.UpdateFileUrl = xmlTextReader.GetAttribute("URL");
                        break;
                    case "Version":
                        this.LastUpdateInfo.Version = xmlTextReader.GetAttribute("Num");
                        break;
                    case "UpdateTime":
                        this.LastUpdateInfo.UpdateTime = Convert.ToDateTime(xmlTextReader.GetAttribute("Date"));
                        break;
                    default:
                        break;
                }
            }
            xmlTextReader.Close();
            myFile.Close();
        }

        private void GetNowUpdateInfo()
        {
            //下载最新的文件到临时目录
            string newXmlTempPath = Path.Combine(this.TempFilePath, "UpdateList.xml");

            //用WebClient里面的方法进行下载
            WebClient wb = new WebClient();
            wb.DownloadFile(this.LastUpdateInfo.UpdateFileUrl + "UpdateList.xml", newXmlTempPath);
            //通过这个方法下载到本地。

            //读取封装更新信息
            FileStream myFile = new FileStream(newXmlTempPath, FileMode.Open);
            XmlTextReader xmlTextReader = new XmlTextReader(myFile);
            this.NowUpdateInfo.FileList = new List<string[]>();
            while (xmlTextReader.Read())
            {
                switch (xmlTextReader.Name)
                {
                    case "Version":
                        this.NowUpdateInfo.Version = xmlTextReader.GetAttribute("Num");
                        break;
                    case "UpdateTime":
                        this.NowUpdateInfo.UpdateTime = Convert.ToDateTime(xmlTextReader.GetAttribute("Date"));
                        break;
                    case "UpdateFile":
                        string ver = xmlTextReader.GetAttribute("Ver");
                        string fileName = xmlTextReader.GetAttribute("FileName");
                        string contentLength = xmlTextReader.GetAttribute("ContentLength");
                        this.NowUpdateInfo.FileList.Add(new string[] { fileName, contentLength, ver, "0" });
                        break;
                    default:
                        break;
                }
            }
            xmlTextReader.Close();
            myFile.Close();
        }

        /// <summary>
        /// 同步显示百分比。
        /// </summary>
        /// <param name="fileIndex"></param>
        /// <param name="finishedPercent"></param>
        public delegate void ShowUpdateProgress(int fileIndex, int finishedPercent);

        public ShowUpdateProgress ShowProgressDelegate;

        /// <summary>
        /// 根据文件列表，并同步显示下载百分比。
        /// </summary>
        public void DownloadFiles()
        {
            List<String[]> fileList = this.NowUpdateInfo.FileList;
            for (int i = 0; i < fileList.Count; i++)
            {
                //当前需要下载文件名
                string fileName = fileList[i][0];
                string fileUrl = this.LastUpdateInfo.UpdateFileUrl + fileName;

                //不用WebClient的原因，不是很好的支持异步。

                //创建请求对象
                WebRequest objRequest = WebRequest.Create(fileUrl);

                //根据请求对象创建响应对象
                WebResponse objResponse = objRequest.GetResponse();

                //通过响应对象返回数据流对象
                Stream objStream = objResponse.GetResponseStream();

                //把数据流对象作为参数转换为常见的读取器对象
                StreamReader objReader = new StreamReader(objStream);

                //在线读取远程文件,并基于委托反馈下载进度。

                //文件大小计算。
                long fileLength = objResponse.ContentLength; //通过响应对象获取接手长度

                //用一个Byte来存
                byte[] bufferByte = new byte[fileLength];

                int allByte = bufferByte.Length;//得到总字节数。

                int startByte = 0;

                while (fileLength > 0)
                {
                    Application.DoEvents();//该语句表示运行一个线程中，处理其他事件。
                    int downloadByte = objStream.Read(bufferByte, startByte, allByte);
                    //开始读取字节流。
                    if (downloadByte == 0) break;
                    startByte += downloadByte;  //累加已经下载的次数。
                    allByte -= downloadByte;//未下载的。

                    float part = (float)startByte / 1024;
                    float total = (float)bufferByte.Length / 1024;

                    int percent = Convert.ToInt32((part / total) * 100);

                    //调用委托更新百分比。
                    ShowProgressDelegate(i, percent);
                    //还需要实时的传递更新进度。
                }
                string newFileName = this.TempFilePath + "\\" + fileName;
                FileStream fs = new FileStream(newFileName, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Write(bufferByte, 0, bufferByte.Length);
                objStream.Close();
                objReader.Close();
                fs.Close();

            }
        }

        /// <summary>
        /// 将下载的文件，复制到应用程序目录。
        /// </summary>
        /// <returns></returns>
        public bool CopyFiles()
        {
            //直接去目录下找。
            string[] files = Directory.GetFiles(TempFilePath);
            foreach (string name in files)
            {
                string currentFile = name.Substring(name.LastIndexOf(@"\") + 1);
                if (File.Exists(currentFile))
                {
                    File.Delete(currentFile);
                }
                File.Copy(name, currentFile);
            }
            return true;
        }
    }
}
