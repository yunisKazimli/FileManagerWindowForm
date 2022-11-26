using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerWindowForm
{
    public static class AddFileFormStaticHandler
    {
        private static TextEdit filePathTextEdit;

        public static void Init(TextEdit _filePathTextEdit)
        {
            filePathTextEdit = _filePathTextEdit;
        }

        public static void CheckFileTexEdit()
        {
            if (filePathTextEdit.Text == "")
            {
                throw new Exception("Fill the fields/Wrong filling");
            }

            if (!File.Exists(filePathTextEdit.Text))
            {
                throw new Exception("File not found/Wrong path");
            }
        }

        public static async Task AddFile()
        {
            string fileName;
            string filePath;

            DividePathToFileAndDirectory(filePathTextEdit.Text, out fileName, out filePath);

            UrlParameterContainer parameters = new UrlParameterContainer();

            parameters.AddParameter("fileName", fileName, false);
            parameters.AddParameter("filePath", filePath, false);

            await HttpGenerator.GenerateVoidHttp("AddFile", parameters);
        }

        private static void DividePathToFileAndDirectory(string fullPath, out string fileName, out string filePath)
        {
            int lastSlashIndex = 0;

            for (int i = fullPath.Length - 1; i >= 0; i--) if (fullPath[i] == '\\')
            {
                lastSlashIndex = i;

                break;
            } 
                    

            fileName = fullPath.Substring(lastSlashIndex + 1, fullPath.Length - (lastSlashIndex + 1));

            filePath = fullPath.Substring(0, lastSlashIndex);
        }
    }
}
