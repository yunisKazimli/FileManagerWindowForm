using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerWindowForm
{
    public static class RegistrationFormStaticHandler
    {
        private static TextEdit gmailTextEdit;
        private static TextEdit passwordTextEdit;

        public static void Init(TextEdit _gmailTextEdit, TextEdit _passwordTextEdit)
        {
            gmailTextEdit = _gmailTextEdit;
            passwordTextEdit = _passwordTextEdit;
        }

        public static bool CheckForSignUp()
        {
            if (gmailTextEdit.Text == "" || passwordTextEdit.Text == "")
            {
                XtraMessageBox.Show("Fill the fields", "Wrong filling", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        public static async Task<string> ValidateSignUp()
        {
            HttpClient httpClient = HttpClientFactory.Create();

            UrlParameterContainer parameters = new UrlParameterContainer();

            parameters.AddParameter("Gmail", gmailTextEdit.Text, false);
            parameters.AddParameter("Password", passwordTextEdit.Text, false);

            string url = HttpGenerator.GenerateHttp("SignUp", parameters);

            try
            {
                await httpClient.GetStringAsync(url);
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Registration error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return "";
            }

            return "Success";

            /*HttpClient httpClient = HttpClientFactory.Create();

            object[] url = HttpGenerator.GenerateSignUpHttp(gmailTextEdit.Text, passwordTextEdit.Text);

            try
            {
                await httpClient.PostAsync(url[0] as string, url[1] as HttpContent);
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Registration error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return "";
            }

            return "Success";
            */
        }
    }
}
