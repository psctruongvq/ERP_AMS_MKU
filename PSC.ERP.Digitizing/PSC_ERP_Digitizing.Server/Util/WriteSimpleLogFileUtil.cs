using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PSC_Digitizing.Server.Util
{
    public static class WriteSimpleLogFileUtil
    {
        static string _baseDir = null;

        static WriteSimpleLogFileUtil()
        {
            _baseDir = AppDomain.CurrentDomain.BaseDirectory;
        }

        //returns filename in format: DD_MM_YYYY
        private static string GetFilenameInFormat_dd_MM_yyyy(string suffix, string extension)
        {
            return System.DateTime.Now.ToString("dd_MM_yyyy")
                + suffix
                + extension;
        }

        public static void WriteLog(String message)
        {
            //just in case: we protect code with try.
            try
            {
                string filename = _baseDir
                    + GetFilenameInFormat_dd_MM_yyyy("_LOG", ".log");
                System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, true);
                
                XElement xmlEntry = new XElement("LogEntry",
                    new XElement("Date", System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                    new XElement("Message", message));
                //
                sw.WriteLine(xmlEntry);
                sw.Close();
            }
            catch (Exception) { }
        }

        public static void WriteLog(Exception ex)
        {
            //just in case: we protect code with try.
            try
            {
                string filename = _baseDir
                    + GetFilenameInFormat_dd_MM_yyyy("_LOG", ".log");
                System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, true);
                XElement xmlEntry = new XElement("LogEntry",
                    new XElement("Date", System.DateTime.Now.ToString()),
                    new XElement("Exception",
                        new XElement("Source", ex.Source),
                        new XElement("Message", ex.Message),
                        new XElement("Stack", ex.StackTrace)
                     )//end exception
                );
                //has inner exception?
                if (ex.InnerException != null)
                {
                    xmlEntry.Element("Exception").Add(
                        new XElement("InnerException",
                            new XElement("Source", ex.InnerException.Source),
                            new XElement("Message", ex.InnerException.Message),
                            new XElement("Stack", ex.InnerException.StackTrace))
                        );
                }
                sw.WriteLine(xmlEntry);
                sw.Close();
            }
            catch (Exception) { }
        }
    }
}
