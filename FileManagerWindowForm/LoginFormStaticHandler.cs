using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerWindowForm
{
    public static class LoginFormStaticHandler
    {
        private static TextEdit gmailTextEdit;
        private static TextEdit passwordTextEdit;

        public static void Init(TextEdit _gmailTextEdit, TextEdit _passwordTextEdit)
        {
            gmailTextEdit = _gmailTextEdit;
            passwordTextEdit = _passwordTextEdit;
        }

        public static bool CheckForSignIn()
        {
            if (gmailTextEdit.Text == "" || passwordTextEdit.Text == "")
            {
                XtraMessageBox.Show("Fill the fields", "Wrong filling", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        public static async Task<string> ValidateSignIn()
        {
            HttpClient httpClient = HttpClientFactory.Create();

            UrlParameterContainer parameters = new UrlParameterContainer();

            parameters.AddParameter("Gmail", gmailTextEdit.Text, false);
            parameters.AddParameter("Password", passwordTextEdit.Text, false);

            string url = HttpGenerator.GenerateHttp("SignIn", parameters);

            string token;

            try
            {
                token = await httpClient.GetStringAsync(url);
            }
            catch(Exception e)
            {
                XtraMessageBox.Show(e.Message, "Authentcation error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return "";
            }

            return token;
        }
    }
}
