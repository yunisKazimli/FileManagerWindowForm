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
    public partial class AddFileForm : XtraForm
    {
        public AddFileForm()
        {
            InitializeComponent();

            AddFileFormStaticHandler.Init(FilePathTextEdit);
        }

        private void FindFileSimpleButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilePathTextEdit.Text = ofd.FileName;
            }
        }

        private async void AddSimpleButton_Click(object sender, EventArgs e)
        {
            bool result;

            if (!AddFileFormStaticHandler.CheckFileTexEdit()) return;

            result = await AddFileFormStaticHandler.AddFile();

            if (result) DialogResult = DialogResult.OK;
        }
    }
}
