
namespace FileManagerWindowForm
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ExitSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.DeleteSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.RefreshSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.ShareFileSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.DownloadFileimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.AddFileSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ExitSimpleButton);
            this.panelControl1.Controls.Add(this.DeleteSimpleButton);
            this.panelControl1.Controls.Add(this.RefreshSimpleButton);
            this.panelControl1.Controls.Add(this.ShareFileSimpleButton);
            this.panelControl1.Controls.Add(this.DownloadFileimpleButton);
            this.panelControl1.Controls.Add(this.AddFileSimpleButton);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(776, 426);
            this.panelControl1.TabIndex = 4;
            // 
            // ExitSimpleButton
            // 
            this.ExitSimpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ExitSimpleButton.ImageOptions.Image")));
            this.ExitSimpleButton.Location = new System.Drawing.Point(732, 5);
            this.ExitSimpleButton.Name = "ExitSimpleButton";
            this.ExitSimpleButton.Size = new System.Drawing.Size(39, 42);
            this.ExitSimpleButton.TabIndex = 5;
            this.ExitSimpleButton.Text = "Quit";
            this.ExitSimpleButton.Click += new System.EventHandler(this.ExitSimpleButton_Click);
            // 
            // DeleteSimpleButton
            // 
            this.DeleteSimpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("DeleteSimpleButton.ImageOptions.Image")));
            this.DeleteSimpleButton.Location = new System.Drawing.Point(412, 5);
            this.DeleteSimpleButton.Name = "DeleteSimpleButton";
            this.DeleteSimpleButton.Size = new System.Drawing.Size(105, 42);
            this.DeleteSimpleButton.TabIndex = 4;
            this.DeleteSimpleButton.Text = "Delete File";
            this.DeleteSimpleButton.Click += new System.EventHandler(this.DeleteSimpleButton_Click);
            // 
            // RefreshSimpleButton
            // 
            this.RefreshSimpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("RefreshSimpleButton.ImageOptions.Image")));
            this.RefreshSimpleButton.Location = new System.Drawing.Point(322, 5);
            this.RefreshSimpleButton.Name = "RefreshSimpleButton";
            this.RefreshSimpleButton.Size = new System.Drawing.Size(84, 42);
            this.RefreshSimpleButton.TabIndex = 3;
            this.RefreshSimpleButton.Text = "Refresh";
            // 
            // ShareFileSimpleButton
            // 
            this.ShareFileSimpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ShareFileSimpleButton.ImageOptions.Image")));
            this.ShareFileSimpleButton.Location = new System.Drawing.Point(103, 5);
            this.ShareFileSimpleButton.Name = "ShareFileSimpleButton";
            this.ShareFileSimpleButton.Size = new System.Drawing.Size(95, 42);
            this.ShareFileSimpleButton.TabIndex = 2;
            this.ShareFileSimpleButton.Text = "Share File";
            this.ShareFileSimpleButton.Click += new System.EventHandler(this.ShareFileSimpleButton_Click);
            // 
            // DownloadFileimpleButton
            // 
            this.DownloadFileimpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("DownloadFileimpleButton.ImageOptions.Image")));
            this.DownloadFileimpleButton.Location = new System.Drawing.Point(206, 5);
            this.DownloadFileimpleButton.Name = "DownloadFileimpleButton";
            this.DownloadFileimpleButton.Size = new System.Drawing.Size(110, 42);
            this.DownloadFileimpleButton.TabIndex = 1;
            this.DownloadFileimpleButton.Text = "Download File";
            this.DownloadFileimpleButton.Click += new System.EventHandler(this.DownloadFileimpleButton_Click);
            // 
            // AddFileSimpleButton
            // 
            this.AddFileSimpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("AddFileSimpleButton.ImageOptions.Image")));
            this.AddFileSimpleButton.Location = new System.Drawing.Point(5, 5);
            this.AddFileSimpleButton.Name = "AddFileSimpleButton";
            this.AddFileSimpleButton.Size = new System.Drawing.Size(92, 42);
            this.AddFileSimpleButton.TabIndex = 0;
            this.AddFileSimpleButton.Text = "Add File";
            this.AddFileSimpleButton.Click += new System.EventHandler(this.AddFileSimpleButton_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 450);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panelControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 430);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton DownloadFileimpleButton;
        private DevExpress.XtraEditors.SimpleButton AddFileSimpleButton;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton ExitSimpleButton;
        private DevExpress.XtraEditors.SimpleButton DeleteSimpleButton;
        private DevExpress.XtraEditors.SimpleButton RefreshSimpleButton;
        private DevExpress.XtraEditors.SimpleButton ShareFileSimpleButton;
    }
}