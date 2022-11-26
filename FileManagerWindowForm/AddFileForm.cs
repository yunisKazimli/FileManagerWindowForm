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
            try
            {
                AddFileFormStaticHandler.CheckFileTexEdit();
                await AddFileFormStaticHandler.AddFile();
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
