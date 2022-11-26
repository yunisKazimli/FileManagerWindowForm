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

        public static async void Init(CheckedComboBoxEdit _toGmailCheckedComboBoxEdit, CheckedComboBoxEdit _filesCheckedComboBoxEdit)
        {
            toGmailCheckedComboBoxEdit = _toGmailCheckedComboBoxEdit;
            filesCheckedComboBoxEdit = _filesCheckedComboBoxEdit;

            await UpdateComboBoxList();
        }

        public static void CheckComboBoxes()
        {
            if (toGmailCheckedComboBoxEdit.Properties.Items.Where(x => x.CheckState == System.Windows.Forms.CheckState.Checked).Count() == 0 || filesCheckedComboBoxEdit.Properties.Items.Where(x => x.CheckState == System.Windows.Forms.CheckState.Checked).Count() == 0)
            {
                throw new Exception("Fill the fields/Wrong filling");
            }
        }

        private static async Task UpdateComboBoxList()
        {
            List<string> gmailsList;
            List<string> acceptedFilesList;

            try
            {
                gmailsList = await GetAllGmails();
                acceptedFilesList = CutFileName(await GetAllAcceptedFiles());
            }
            catch(Exception e)
            {
                XtraMessageBox.Show(e.Message.Split('/')[0], e.Message.Split('/').Length == 1 ? "Unexpected error" : e.Message.Split('/')[1], System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return;
            }

            toGmailCheckedComboBoxEdit.Properties.Items.Clear();
            filesCheckedComboBoxEdit.Properties.Items.Clear();

            foreach (string gm in gmailsList) toGmailCheckedComboBoxEdit.Properties.Items.Add(gm);
            foreach (string af in acceptedFilesList) filesCheckedComboBoxEdit.Properties.Items.Add(af);
        }

        private static async Task<List<string>> GetAllGmails()
        {
            UrlParameterContainer parameters = new UrlParameterContainer();

            return JsonConvert.DeserializeObject<List<string>>(await HttpGenerator.GenerateJsonHttp("GetAllGmails", parameters));
        }

        private static async Task<List<string>> GetAllAcceptedFiles()
        {
            UrlParameterContainer parameters = new UrlParameterContainer();

            return (JsonConvert.DeserializeObject<List<string>>(await HttpGenerator.GenerateJsonHttp("GetAllAcceptedFiles", parameters))).Where(x => x.IndexOf(AuthorizationManager.gmail) != -1).ToList();//find all path where only own gmail folder
        }
        
        private static List<string> CutFileName(List<string> allFiles)
        {
            for(int i = 0; i < allFiles.Count; i++)
            {
                allFiles[i] = allFiles[i].Remove(0, allFiles[i].IndexOf("@gmail.com\\") + 11);
            }

            return allFiles;
        }

        public static async Task ShareFile()
        {
            UrlParameterContainer cont = new UrlParameterContainer();

            cont.AddParameter("toGmails", GetAllCheckedItemsAsStringList(toGmailCheckedComboBoxEdit), true);
            cont.AddParameter("filesName", GetAllCheckedItemsAsStringList(filesCheckedComboBoxEdit), true);

            await HttpGenerator.GenerateVoidHttp("ShareFile", cont);
        }

        public static List<string> GetAllCheckedItemsAsStringList(CheckedComboBoxEdit checkedComboBoxEdit)
        {
            List<DevExpress.XtraEditors.Controls.CheckedListBoxItem> checkedList = checkedComboBoxEdit.Properties.Items.Where(x => x.CheckState == System.Windows.Forms.CheckState.Checked).ToList();

            return (from checkedListBoxItem in checkedList select (string)checkedListBoxItem.Value).ToList();
        }
    }
}
