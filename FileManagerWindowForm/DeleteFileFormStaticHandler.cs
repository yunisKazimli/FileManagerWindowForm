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

        public static async Task<bool> DeleteFile()
        {
            string url;

            HttpClient httpClient = HttpClientFactory.Create();

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthorizationManager.token);

            UrlParameterContainer parameters = new UrlParameterContainer();

            parameters.AddParameter("fileName", fileNameComboBoxEdit.Text.Split('\\')[1], false);
            parameters.AddParameter("isPersonal", fileNameComboBoxEdit.Text.Split('\\')[0] == AuthorizationManager.gmail ? "true" : "false", false);

            url = HttpGenerator.GenerateHttp("DeleteFile", parameters);

            try
            {
                await httpClient.GetStringAsync(url);
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "File deleting error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        public static bool CheckfileNameComboBoxEdit()
        {
            if (fileNameComboBoxEdit.Text == "")
            {
                XtraMessageBox.Show("You must choose file name", "Wrong filling", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private static async void UpdateFileNameComboBox()
        {
            List<string> allFilesName = CutFileName(await GetAllFilesName());

            fileNameComboBoxEdit.Properties.Items.Clear();

            foreach (string fn in allFilesName) fileNameComboBoxEdit.Properties.Items.Add(fn);
        }

        private static async Task<List<string>> GetAllFilesName()
        {
            List<string> allFiles;

            HttpClient httpClient = HttpClientFactory.Create();

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthorizationManager.token);

            UrlParameterContainer parameters = new UrlParameterContainer();

            string url = HttpGenerator.GenerateHttp("GetAllAcceptedFiles", parameters);

            try
            {
                allFiles = JsonConvert.DeserializeObject<List<string>>(await httpClient.GetStringAsync(url));
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Unexpected error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return null;
            }

            return allFiles;
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
