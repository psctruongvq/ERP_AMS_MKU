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
        public byte[] QuickHelper_DownloadSourceFile_ByFileName(String publicKey, String token, String fileNameWithExtension, String maPhanHe)
        {
            if (Helper.TrustTest(publicKey, token))
            {

                String filePath = "";
                if (maPhanHe == "SH")
                    filePath = Path.Combine(_sourceSoHoaDirectory, fileNameWithExtension);
                else if (maPhanHe == "NS")
                    filePath = Path.Combine(_sourceNhanSuDirectory, fileNameWithExtension);
                //String filePath = Path.Combine(_sourceDirectory, fileNameWithExtension);
                //
                return DownloadFile_Helper(filePath: filePath, pdfPassword: null);
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


        [WebMethod]
        public byte[] QuickHelper_DownloadConvertedFile_ByFileName(String publicKey, String token, String fileNameWithExtension)
        {
            if (Helper.TrustTest(publicKey, token))
            {

                
                String filePath = Path.Combine(_convertedDirectory, fileNameWithExtension);
                //
                return DownloadFile_Helper(filePath: filePath, pdfPassword: null);
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


        private byte[] DownloadFile_Helper(string filePath, string pdfPassword = null)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    //Throw the exception    
                    SoapException se = new SoapException("DownloadFile error",
                      SoapException.ClientFaultCode,
                      Context.Request.Url.AbsoluteUri,
                      new Exception("File not exists"));
                    throw se;
                }
                string extension = Path.GetExtension(filePath).ToLower();
                byte[] data = null;
                if (extension == ".pdf" && !string.IsNullOrEmpty(pdfPassword))
                {
                    PdfReader pReader = new PdfReader(filePath, new System.Text.ASCIIEncoding().GetBytes(pdfPassword));
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfStamper stamper = new PdfStamper(pReader, memoryStream);
                        stamper.Close();
                        pReader.Close();

                        data = memoryStream.ToArray();

                    }
                }
                else
                {
                    data = System.IO.File.ReadAllBytes(filePath);

                }
                return data;
            }
            catch (Exception ex)
            {
                //Throw the exception    
                SoapException se = new SoapException("DownloadFile error",
                  SoapException.ClientFaultCode,
                  Context.Request.Url.AbsoluteUri,
                  ex);
                throw se;
            }
        }
    }
}