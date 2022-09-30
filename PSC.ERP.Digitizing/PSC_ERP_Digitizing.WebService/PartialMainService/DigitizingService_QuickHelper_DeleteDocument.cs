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
        public void QuickHelper_DeleteDocument_ByDocFileNameWithoutExtension(String publicKey, String token, String fileNameWithoutExtension)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                try
                {
                    String pdfFile = fileNameWithoutExtension + ".pdf";
                    String txtFile = fileNameWithoutExtension + ".txt";
                    String docFile = fileNameWithoutExtension + ".doc";
                    String excelFile = fileNameWithoutExtension + ".xls";

                    //xoa file trong converted
                    if (File.Exists(System.IO.Path.Combine(_convertedDirectory, txtFile)))
                        File.Delete(System.IO.Path.Combine(_convertedDirectory, txtFile));
                    //
                    if (File.Exists(System.IO.Path.Combine(_convertedDirectory, docFile)))
                        File.Delete(System.IO.Path.Combine(_convertedDirectory, docFile));
                    //
                    if (File.Exists(System.IO.Path.Combine(_convertedDirectory, excelFile)))
                        File.Delete(System.IO.Path.Combine(_convertedDirectory, excelFile));
                    //
                    if (File.Exists(System.IO.Path.Combine(_convertedDirectory, pdfFile)))
                        File.Delete(System.IO.Path.Combine(_convertedDirectory, pdfFile));
                    //xoa file source
                    if (File.Exists(System.IO.Path.Combine(_sourceDirectory, pdfFile)))
                        File.Delete(System.IO.Path.Combine(_sourceDirectory, pdfFile));
                    //xóa file source nhân sự
                    if (File.Exists(System.IO.Path.Combine(_sourceNhanSuDirectory, pdfFile)))
                        File.Delete(System.IO.Path.Combine(_sourceNhanSuDirectory, pdfFile));
                    //xóa file source sô hóa
                    if (File.Exists(System.IO.Path.Combine(_sourceSoHoaDirectory, pdfFile)))
                        File.Delete(System.IO.Path.Combine(_sourceSoHoaDirectory, pdfFile));
                    //xoa index. (trước đó lấy tên của text file ghi vào index nên phải gởi text file để xóa)
                    try
                    {
                        Helper.Digitizing_DeleteDocIndexing_ByDocFileName(txtFile, _indexDirectory);
                    }
                    catch (Exception ex)
                    {
                    }

                }
                catch (Exception ex)
                {

                    SoapException se = new SoapException("QuickHelper_RemoveFileIndex_ByDocFileName error",
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