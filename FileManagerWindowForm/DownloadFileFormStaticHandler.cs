using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerWindowForm
{
    public static class DownloadFileFormStaticHandler
    {
        private static ComboBoxEdit fileNameComboBoxEdit;
        private static TextEdit directoryPathtextEdit;

        public static void Init(ComboBoxEdit _fileNameComboBoxEdit, TextEdit _directoryPathtextEdit)
        {
            fileNameComboBoxEdit = _fileNameComboBoxEdit;
            directoryPathtextEdit = _directoryPathtextEdit;

            UpdateFileNameComboBoxEdit();
        }

        public static async Task DownloadFile()
        {
            UrlParameterContainer parameters = new UrlParameterContainer();

            parameters.AddParameter("fromGmail", fileNameComboBoxEdit.Text.Split('\\')[0], false);
            parameters.AddParameter("fileName", fileNameComboBoxEdit.Text.Split('\\')[1], false);
            parameters.AddParameter("destPath", directoryPathtextEdit.Text, false);

            await HttpGenerator.GenerateVoidHttp("DownloadFile", parameters);
        }

        public static void CheckFileTexEdit()
        {
            if (fileNameComboBoxEdit.Text == "")
            {
                throw new Exception("Fill the fields/Wrong filling");
            }

            if (directoryPathtextEdit.Text == "" || !Directory.Exists(directoryPathtextEdit.Text))
            {
                throw new Exception("Directory not found/Wrong path");
            }
        }

        private static async Task UpdateFileNameComboBoxEdit()
        {
            List<string> allFilesName = CutFileName(await GetAllFilesName()); 
            
            fileNameComboBoxEdit.Properties.Items.Clear();

            foreach (string fn in allFilesName) fileNameComboBoxEdit.Properties.Items.Add(fn);
        }

        private static async Task<List<string>> GetAllFilesName()
        {
            UrlParameterContainer parameters = new UrlParameterContainer();

            return JsonConvert.DeserializeObject<List<string>>(await HttpGenerator.GenerateJsonHttp("GetAllAcceptedFiles", parameters));
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
