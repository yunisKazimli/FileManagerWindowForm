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
    public static class ShareFileFormStaticHandler
    {
        private static CheckedComboBoxEdit toGmailCheckedComboBoxEdit;
        private static CheckedComboBoxEdit filesCheckedComboBoxEdit;

        public static void Init(CheckedComboBoxEdit _toGmailCheckedComboBoxEdit, CheckedComboBoxEdit _filesCheckedComboBoxEdit)
        {
            toGmailCheckedComboBoxEdit = _toGmailCheckedComboBoxEdit;
            filesCheckedComboBoxEdit = _filesCheckedComboBoxEdit;

            UpdateComboBoxList();
        }

        public static bool CheckComboBoxes()
        {
            if (toGmailCheckedComboBoxEdit.Properties.Items.Where(x => x.CheckState == System.Windows.Forms.CheckState.Checked).Count() == 0 || filesCheckedComboBoxEdit.Properties.Items.Where(x => x.CheckState == System.Windows.Forms.CheckState.Checked).Count() == 0)
            {
                XtraMessageBox.Show("choose at least one option", "Wrong filling", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private static async void UpdateComboBoxList()
        {
            List<string> gmailsList = await GetAllGmails();
            List<string> acceptedFilesList = CutFileName(await GetAllAcceptedFiles());

            toGmailCheckedComboBoxEdit.Properties.Items.Clear();
            filesCheckedComboBoxEdit.Properties.Items.Clear();

            foreach (string gm in gmailsList) toGmailCheckedComboBoxEdit.Properties.Items.Add(gm);
            foreach (string af in acceptedFilesList) filesCheckedComboBoxEdit.Properties.Items.Add(af);
        }

        private static async Task<List<string>> GetAllGmails()
        {
            List<string> allGmails;

            HttpClient httpClient = HttpClientFactory.Create();

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthorizationManager.token);
            
            UrlParameterContainer parameters = new UrlParameterContainer();

            string url = HttpGenerator.GenerateHttp("GetAllGmails", parameters);

            try
            {
                allGmails = JsonConvert.DeserializeObject<List<string>>(await httpClient.GetStringAsync(url));
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Unexpected error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return null;
            }

            return allGmails;
        }

        private static async Task<List<string>> GetAllAcceptedFiles()
        {
            List<string> allFiles;

            HttpClient httpClient = HttpClientFactory.Create();

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthorizationManager.token);
            
            UrlParameterContainer parameters = new UrlParameterContainer();

            string url = HttpGenerator.GenerateHttp("GetAllAcceptedFiles", parameters);

            try
            {
                allFiles = (JsonConvert.DeserializeObject<List<string>>(await httpClient.GetStringAsync(url))).Where(x => x.IndexOf(AuthorizationManager.gmail) != -1).ToList();//find all path where only own gmail folder
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
            for(int i = 0; i < allFiles.Count; i++)
            {
                allFiles[i] = allFiles[i].Remove(0, allFiles[i].IndexOf("@gmail.com\\") + 11);
            }

            return allFiles;
        }

        public static async Task<bool> ShareFile()
        {
            HttpClient httpClient = HttpClientFactory.Create();

            string url;

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthorizationManager.token);

            UrlParameterContainer cont = new UrlParameterContainer();

            cont.AddParameter("toGmails", GetAllCheckedItemsAsStringList(toGmailCheckedComboBoxEdit), true);
            cont.AddParameter("filesName", GetAllCheckedItemsAsStringList(filesCheckedComboBoxEdit), true);

            url = HttpGenerator.GenerateHttp("ShareFile", cont);

            try
            {
                await httpClient.GetStringAsync(url);
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "File sharing error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        public static List<string> GetAllCheckedItemsAsStringList(CheckedComboBoxEdit checkedComboBoxEdit)
        {
            List<DevExpress.XtraEditors.Controls.CheckedListBoxItem> checkedList = checkedComboBoxEdit.Properties.Items.Where(x => x.CheckState == System.Windows.Forms.CheckState.Checked).ToList();

            return (from checkedListBoxItem in checkedList select (string)checkedListBoxItem.Value).ToList();
        }
    }
}
