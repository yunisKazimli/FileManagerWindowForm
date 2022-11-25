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
            if (!LoginFormStaticHandler.CheckForSignIn()) return;

            string token = await LoginFormStaticHandler.ValidateSignIn();

            if (token == "") return;

            AuthorizationManager.token = token;
            AuthorizationManager.gmail = GmailTextEdit.Text;

            (new MainMenuForm()).Show();

            Hide();
        }

        private void SignUpSimpleButton_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();

            regForm.ShowDialog();
        }
    }
}
