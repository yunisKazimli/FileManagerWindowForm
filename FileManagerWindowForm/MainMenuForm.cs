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
    public partial class MainMenuForm : XtraForm
    {
        public MainMenuForm()
        {
            InitializeComponent();

            MainMenuFormStaticHandler.Init(FileShowPanelControl, 
                new EventHandler(DownloadContainerFileSimpleButton_Click), 
                new EventHandler(DeleteContainerFileSimpleButton_Click),
                ((Image)(new ComponentResourceManager(typeof(MainMenuForm)).GetObject("DownloadContainerFileSimpleButton.ImageOptions.Image"))), 
                ((Image)(new ComponentResourceManager(typeof(MainMenuForm)).GetObject("DeleteContainerFileSimpleButton.ImageOptions.Image"))));

            MainMenuFormStaticHandler.Refresh();
        }

        private void AddFileSimpleButton_Click(object sender, EventArgs e)
        {
            if ((new AddFileForm()).ShowDialog() == DialogResult.OK) MainMenuFormStaticHandler.Refresh();
        }

        private void ShareFileSimpleButton_Click(object sender, EventArgs e)
        {
            if ((new ShareFileForm()).ShowDialog() == DialogResult.OK) MainMenuFormStaticHandler.Refresh();
        }

        private void DownloadFileimpleButton_Click(object sender, EventArgs e)
        {
            if ((new DownloadFileForm()).ShowDialog() == DialogResult.OK) MainMenuFormStaticHandler.Refresh();
        }

        private void DeleteSimpleButton_Click(object sender, EventArgs e)
        {
            if ((new DeleteFileForm()).ShowDialog() == DialogResult.OK) MainMenuFormStaticHandler.Refresh();
        }

        private void DownloadContainerFileSimpleButton_Click(object sender, EventArgs e)
        {
            if ((new DownloadFileForm((sender as SimpleButton).Parent.Controls.OfType<LabelControl>().FirstOrDefault(x => x.Name == "FileNameLabelControl").Text)).ShowDialog() == DialogResult.OK) MainMenuFormStaticHandler.Refresh();
        }

        private void DeleteContainerFileSimpleButton_Click(object sender, EventArgs e)
        {
            if ((new DeleteFileForm((sender as SimpleButton).Parent.Controls.OfType<LabelControl>().FirstOrDefault(x => x.Name == "FileNameLabelControl").Text)).ShowDialog() == DialogResult.OK) MainMenuFormStaticHandler.Refresh();
        }

        private void MainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginMenuSimpleButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void RefreshSimpleButton_Click(object sender, EventArgs e)
        {
            MainMenuFormStaticHandler.Refresh();
        }
    }
}
