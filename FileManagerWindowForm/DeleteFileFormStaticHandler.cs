using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerWindowForm
{
    public static class DeleteFileFormStaticHandler
    {
        private static ComboBoxEdit fileNameComboBoxEdit;

        public static void Init(ComboBoxEdit _fileNameComboBoxEdit)
        {
            fileNameComboBoxEdit = _fileNameComboBoxEdit;

            UpdateFileNameComboBox();
        }

        public static async Task DeleteFile()
        {
            UrlParameterContainer parameters = new UrlParameterContainer();

            parameters.AddParameter("fileName", fileNameComboBoxEdit.Text.Split('\\')[1], false);
            parameters.AddParameter("isPersonal", fileNameComboBoxEdit.Text.Split('\\')[0] == AuthorizationManager.gmail ? "true" : "false", false);

            await HttpGenerator.GenerateVoidHttp("DeleteFile", parameters);
        }

        public static void CheckfileNameComboBoxEdit()
        {
            if (fileNameComboBoxEdit.Text == "")
            {
                throw new Exception("Fill the fields/Wrong filling");
            }
        }

        private static async Task UpdateFileNameComboBox()
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
