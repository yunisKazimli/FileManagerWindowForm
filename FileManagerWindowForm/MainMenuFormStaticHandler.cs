using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManagerWindowForm
{
    public static class MainMenuFormStaticHandler
    {
        private static PanelControl fileShowPanelControl;
        private static EventHandler downloadButtonEventHandler;
        private static EventHandler deleteButtonEventHandler;
        private static Image downloadButtonImage;
        private static Image deleteButtonImage;

        public static void Init(PanelControl _fileShowPanelControl, EventHandler _downloadButtonEventHandler, EventHandler _deleteButtonEventHandler, Image _downloadButtonImage, Image _deleteButtonImage)
        {
            fileShowPanelControl = _fileShowPanelControl;

            downloadButtonEventHandler = _downloadButtonEventHandler;
            deleteButtonEventHandler = _deleteButtonEventHandler;

            downloadButtonImage = _downloadButtonImage;
            deleteButtonImage = _deleteButtonImage;
        }

        public static async Task Refresh()
        {
            fileShowPanelControl.Controls.Clear();

            string[] allFiles;
            string[] allFilesUrl;

            try
            {
                allFiles = await GetAllFiles();
                allFilesUrl = await GetAllFilesUrl();
            }
            catch(Exception exc)
            {
                XtraMessageBox.Show(exc.Message.Split('/')[0], exc.Message.Split('/').Length == 1 ? "Unexpected error" : exc.Message.Split('/')[1], System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return;
            }

            CreateFileContainer(allFiles, allFilesUrl.ToList());
        }

        private static Control InitFileContainer(string fileName, string downloadedFilePath, int height)
        {
            PanelControl FileContainerPanelControl = new PanelControl();
            SimpleButton DeleteContainerFileSimpleButton = new SimpleButton();
            SimpleButton DownloadContainerFileSimpleButton = new SimpleButton();
            LabelControl FilePathLabelControl = new LabelControl();
            LabelControl FileNameLabelControl = new LabelControl();

            FilePathLabelControl.Location = new System.Drawing.Point(5, 34);
            FilePathLabelControl.Name = "FilePathLabelControl";
            FilePathLabelControl.Size = new System.Drawing.Size(63, 13);
            FilePathLabelControl.TabIndex = 1;
            FilePathLabelControl.Text = downloadedFilePath;

            FileNameLabelControl.Location = new System.Drawing.Point(5, 5);
            FileNameLabelControl.Name = "FileNameLabelControl";
            FileNameLabelControl.Size = new System.Drawing.Size(98, 13);
            FileNameLabelControl.TabIndex = 0;
            FileNameLabelControl.Text = fileName;

            DeleteContainerFileSimpleButton.ImageOptions.Image = deleteButtonImage;
            DeleteContainerFileSimpleButton.Location = new System.Drawing.Point(657, 6);
            DeleteContainerFileSimpleButton.Name = "DeleteContainerFileSimpleButton";
            DeleteContainerFileSimpleButton.Size = new System.Drawing.Size(105, 42);
            DeleteContainerFileSimpleButton.TabIndex = 7;
            DeleteContainerFileSimpleButton.Text = "Delete File";
            DeleteContainerFileSimpleButton.Click += deleteButtonEventHandler;

            DownloadContainerFileSimpleButton.ImageOptions.Image = downloadButtonImage;
            DownloadContainerFileSimpleButton.Location = new System.Drawing.Point(541, 6);
            DownloadContainerFileSimpleButton.Name = "DownloadContainerFileSimpleButton";
            DownloadContainerFileSimpleButton.Size = new System.Drawing.Size(110, 42);
            DownloadContainerFileSimpleButton.TabIndex = 7;
            DownloadContainerFileSimpleButton.Text = "Download File";
            DownloadContainerFileSimpleButton.Click += downloadButtonEventHandler;

            FileContainerPanelControl.Controls.Add(DeleteContainerFileSimpleButton);
            FileContainerPanelControl.Controls.Add(DownloadContainerFileSimpleButton);
            FileContainerPanelControl.Controls.Add(FilePathLabelControl);
            FileContainerPanelControl.Controls.Add(FileNameLabelControl);
            FileContainerPanelControl.Location = new System.Drawing.Point(3, height);
            FileContainerPanelControl.Name = "FileContainerPanelControl";
            FileContainerPanelControl.Size = new System.Drawing.Size(767, 53);
            FileContainerPanelControl.TabIndex = 0;

            return FileContainerPanelControl;
        }

        private static async Task<string[]> GetAllFiles()
        {
            return JsonConvert.DeserializeObject<List<string>>(await HttpGenerator.GenerateJsonHttp("GetAllAcceptedFiles", new UrlParameterContainer())).ToArray();
        }

        private static async Task<string[]> GetAllFilesUrl()
        {
            return JsonConvert.DeserializeObject<List<string>>(await HttpGenerator.GenerateJsonHttp("GetAllFilesUrl", new UrlParameterContainer())).ToArray();
        }

        private static void CreateFileContainer(string[] allFiles, List<string> allFilesURl)
        {
            List<string> allFilesName = CutFileName(allFiles.ToList());

            for (int i = 0; i < allFilesName.Count; i++)
            {
                string urlLogLine = allFilesURl.FirstOrDefault(x => x.IndexOf($"!1!{allFilesName[i].Split('\\')[0]}!2!{AuthorizationManager.gmail}!3!{allFilesName[i].Split('\\')[1]}!4!") != -1);

                fileShowPanelControl.Controls.Add(InitFileContainer(allFilesName[i], urlLogLine.Remove(0, urlLogLine.IndexOf("!4!") + 3), i * 53));
            }    
        }

        private static List<string> CutFileName(List<string> allFiles)
        {
            for (int i = 0; i < allFiles.Count; i++)
            {
                int index = allFiles[i].IndexOf("@gmail.com");

                for (int j = index - 1; j > 0; j--)
                {
                    if (allFiles[i][j - 1] == '\\')
                    {
                        index = j;

                        break;
                    }
                }

                allFiles[i] = allFiles[i].Remove(0, index);
            }

            return allFiles;
        }
    }
}
