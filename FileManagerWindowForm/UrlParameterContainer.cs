using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerWindowForm
{
    public struct UrlParameterContainer
    {
        public List<string> parameters;

        public void AddParameter(string parameterName, object value, bool isArray)
        {
            if (parameters == null) parameters = new List<string>();

            if (isArray)
            {
                List<string> valuesArray = (List<string>)value;

                for (int i = 0; i < valuesArray.Count; i++)
                {
                    parameters.Add(parameterName + " " + valuesArray[i]);
                }
            }

            else parameters.Add(parameterName + " " + value);
        }
    }
}
