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
            try
            {
                DownloadFileFormStaticHandler.Init(FileComboBoxEdit, DirectoryPathTextEdit);
            }
            catch(Exception exc)
            {
                XtraMessageBox.Show(exc.Message.Split('/')[0], exc.Message.Split('/').Length == 1 ? "Unexpected error" : exc.Message.Split('/')[1], System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return;
            }
        }

        public DownloadFileForm(string fileName)
        {
            InitializeComponent();
            try
            {
                DownloadFileFormStaticHandler.Init(FileComboBoxEdit, DirectoryPathTextEdit);
            }
            catch(Exception exc)
            {
                XtraMessageBox.Show(exc.Message.Split('/')[0], exc.Message.Split('/').Length == 1 ? "Unexpected error" : exc.Message.Split('/')[1], System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return;
            }

            FileComboBoxEdit.Text = fileName;
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
            try
            {
                DownloadFileFormStaticHandler.CheckFileTexEdit();
                await DownloadFileFormStaticHandler.DownloadFile();
            }
            catch(Exception exc)
            {
                XtraMessageBox.Show(exc.Message.Split('/')[0], exc.Message.Split('/').Length == 1 ? "Unexpected error" : exc.Message.Split('/')[1], System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
