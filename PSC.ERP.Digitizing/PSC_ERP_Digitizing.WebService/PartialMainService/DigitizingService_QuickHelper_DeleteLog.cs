using iTextSharp.text.pdf;
using PSC_ERP_Digitizing.WebService.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.Services.Protocols;


namespace PSC_ERP_Digitizing.WebService
{
    public partial class DigitizingService
    {


        [WebMethod]
        public void QuickHelper_DeleteHotFolderLog(String publicKey, String token)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                try
                {

                    string[] files = System.IO.Directory.GetFiles(_convertedDirectory, "Hot Folder Log*.txt");
                    foreach (string f in files)
                    {
                        try
                        {
                            System.IO.File.Delete(f);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    //foreach (FileInfo fi in (new DirectoryInfo(_convertedDirectory)).GetFiles())
                    //{
                    //    if (fi.Name.IndexOf("Hot Folder Log") >= 0)
                    //    {
                    //        try
                    //        {
                    //            fi.Delete();
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //        }
                    //    }
                    //}


                }
                catch (Exception ex)
                {

                    SoapException se = new SoapException("QuickHelper_DeleteHotFolderLog error",
                           SoapException.ClientFaultCode,
                           Context.Request.Url.AbsoluteUri,
                           ex);
                    throw se;
                }



            }
            else
            {
                //Xác thực không hợp lệ.
                SoapException se = new SoapException("Xác thực không hợp lệ",
                 SoapException.ClientFaultCode,
                 Context.Request.Url.AbsoluteUri,
                 new Exception("Xác thực không hợp lệ"));
                throw se;
            }
        }

    }
}