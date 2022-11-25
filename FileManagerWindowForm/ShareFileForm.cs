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
            ShareFileFormStaticHandler.CheckComboBoxes();

            if (await ShareFileFormStaticHandler.ShareFile()) DialogResult = DialogResult.OK;
        }
    }
}
