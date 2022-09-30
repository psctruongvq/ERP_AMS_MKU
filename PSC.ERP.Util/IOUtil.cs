using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PSC_ERP_Util
{
    public static class IOUtil
    {
        public static string ReadFileToString(string filePath)
        {

            StreamReader myStreamReader = null;
            string content;

            try
            {
                myStreamReader = File.OpenText(filePath);
                content = myStreamReader.ReadToEnd();
            }
            catch (Exception)
            {
                content = "";
            }
            finally
            {
                if (myStreamReader != null)
                {
                    myStreamReader.Close();
                }
            }
            return content;
        }
        public static Boolean WriteStringToNewFile(String content, String filePath, Boolean overrideExistFile = false)
        {

            Boolean returnValue = false;
            FileMode fileMode;

            if (overrideExistFile == true)
            {
                fileMode = FileMode.Create;
            }
            else
            {
                fileMode = FileMode.CreateNew;
            }
            try
            {

                FileStream fs = new FileStream(filePath, fileMode);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(content);
                sw.Flush();
                sw.Close();
                fs.Close();
                //
                returnValue = true;
            }
            catch (System.Exception ex)
            {
                returnValue = false;
            }
            return returnValue;
        }
    }
}
