using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerWindowForm
{
    public static class AddFileFormStaticHandler
    {
        private static TextEdit filePathTextEdit;

        public static void Init(TextEdit _filePathTextEdit)
        {
            filePathTextEdit = _filePathTextEdit;
        }

        public static bool CheckFileTexEdit()
        {
            if (filePathTextEdit.Text == "" || !File.Exists(filePathTextEdit.Text))
            {
                XtraMessageBox.Show("Wrong file path", "Wrong filling", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        public static async Task<bool> AddFile()
        {
            string fileName;
            string filePath;
            string url;

            HttpClient httpClient = HttpClientFactory.Create();

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthorizationManager.token);

            DividePathToFileAndDirectory(filePathTextEdit.Text, out fileName, out filePath);

            UrlParameterContainer parameters = new UrlParameterContainer();

            parameters.AddParameter("fileName", fileName, false);
            parameters.AddParameter("filePath", filePath, false);

            url = HttpGenerator.GenerateHttp("AddFile", parameters);

            try
            {
                await httpClient.GetStringAsync(url);
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "File adding error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private static void DividePathToFileAndDirectory(string fullPath, out string fileName, out string filePath)
        {
            int lastSlashIndex = 0;

            for (int i = fullPath.Length - 1; i >= 0; i--) if (fullPath[i] == '\\') lastSlashIndex = i;

            fileName = fullPath.Substring(lastSlashIndex + 1, fullPath.Length - (lastSlashIndex + 1));

            filePath = fullPath.Substring(0, lastSlashIndex);
        }
    }
}
