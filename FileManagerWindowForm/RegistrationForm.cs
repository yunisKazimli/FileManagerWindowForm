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
    public partial class RegistrationForm : XtraForm
    {
        public RegistrationForm()
        {
            InitializeComponent();

            RegistrationFormStaticHandler.Init(GmailTextEdit, PasswordTextEdit);
        }

        private async void SignUpSimpleButton_Click(object sender, EventArgs e)
        {
            if (!RegistrationFormStaticHandler.CheckForSignUp()) return;

            if ((await RegistrationFormStaticHandler.ValidateSignUp()) == "") return;

            DialogResult = DialogResult.OK;
        }
    }
}
