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
    public partial class ShareFileForm : XtraForm
    {
        public ShareFileForm()
        {
            InitializeComponent();

            ShareFileFormStaticHandler.Init(ToGmailCheckedComboBoxEdit, FilesCheckedComboBoxEdit);
        }

        private async void ShareFileSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShareFileFormStaticHandler.CheckComboBoxes();

                await ShareFileFormStaticHandler.ShareFile();
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
