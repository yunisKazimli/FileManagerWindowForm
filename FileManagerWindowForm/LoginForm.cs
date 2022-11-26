using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FileManagerWindowForm
{
    public partial class LoginForm : XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();

            LoginFormStaticHandler.Init(GmailTextEdit, PasswordTextEdit);
        }

        private async void SignInSinpleButton_Click(object sender, EventArgs e)
        {
            string token = "";

            Hide();

            try
            {
                LoginFormStaticHandler.CheckForSignIn();

                token = await LoginFormStaticHandler.ValidateSignIn();
            }
            catch(Exception exc)
            {
                XtraMessageBox.Show(exc.Message.Split('/')[0], exc.Message.Split('/').Length == 1 ? "Unexpected error" : exc.Message.Split('/')[1], System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                Show();

                return;
            }

            AuthorizationManager.token = token;
            AuthorizationManager.gmail = GmailTextEdit.Text;

            (new MainMenuForm()).Show();
        }

        private void SignUpSimpleButton_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();

            regForm.ShowDialog();
        }
    }
}
