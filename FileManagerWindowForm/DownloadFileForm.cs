using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManagerWindowForm
{
    public partial class DownloadFileForm : XtraForm
    {
        public DownloadFileForm()
        {
            InitializeComponent();

            DownloadFileFormStaticHandler.Init(FileComboBoxEdit, DirectoryPathTextEdit);
        }

        private void FindFileSimpleButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DirectoryPathTextEdit.Text = ofd.SelectedPath;
            }
        }

        private async void DownloadFileSimpleButton_Click(object sender, EventArgs e)
        {
            if (!DownloadFileFormStaticHandler.CheckFileTexEdit()) return;

            if(await DownloadFileFormStaticHandler.DownloadFile()) DialogResult = DialogResult.OK;
        }
    }
}
