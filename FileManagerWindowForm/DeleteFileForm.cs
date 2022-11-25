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
    public partial class DeleteFileForm : XtraForm
    {
        public DeleteFileForm()
        {
            InitializeComponent();

            DeleteFileFormStaticHandler.Init(FileNameComboBoxEdit);
        }

        private async void DeleteSimpleButton_Click(object sender, EventArgs e)
        {
            if (!DeleteFileFormStaticHandler.CheckfileNameComboBoxEdit()) return;

            if (await DeleteFileFormStaticHandler.DeleteFile()) DialogResult = DialogResult.OK;
        }
    }
}
