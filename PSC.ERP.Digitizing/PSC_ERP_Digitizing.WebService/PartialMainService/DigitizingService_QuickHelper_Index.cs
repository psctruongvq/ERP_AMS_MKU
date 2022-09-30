using iTextSharp.text.pdf;
using PSC_ERP_Digitizing.WebService.Model;
using PSC_ERP_Digitizing.WebService.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        public void QuickHelper_ResetIndex(String publicKey, String token)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                try
                {

                    foreach (FileInfo fi in (new DirectoryInfo(_indexDirectory)).GetFiles())
                    {
                        fi.Delete();
                    }

                }
                catch (Exception ex)
                {
                    SoapException se = new SoapException("QuickHelper_ResetIndex error",
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

        [WebMethod]
        public byte[] QuickHelper_GetFileContent(String publicKey, String token, String docFileNameWithExtension)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                try
                {



                    String filePath = Path.Combine(_convertedDirectory, docFileNameWithExtension);
                    //WriteSimpleLogFileUtil.WriteLog("File: " + filePath);
                    if (File.Exists(filePath))
                    {
                        //WriteSimpleLogFileUtil.WriteLog("Test1");
                        //lay file content
                        //chi lay content cua file docx
                        String fileContent = Helper.Digitizing_GetFileContent_SmartChoice(filePath);
                        //WriteSimpleLogFileUtil.WriteLog("Test2");
                        //WriteSimpleLogFileUtil.WriteLog("File content: " + fileContent);
                        byte[] zippedFileContent = Helper.Digitizing_ZipString(fileContent);

                        //tra ve ket qua cho ham
                        return zippedFileContent;
                    }
                    else
                    {
                        SoapException se = new SoapException("File not found",
                           SoapException.ClientFaultCode,
                           Context.Request.Url.AbsoluteUri,
                           new Exception("File not found"));
                        throw se;
                    }
                }
                catch (Exception ex)
                {

                    SoapException se = new SoapException("QuickHelper_GetFileContent error",
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

        [WebMethod]
        public string QuickHelper_GetFileContent_String(String publicKey, String token, String docFileNameWithExtension)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                try
                {

                    String filePath = Path.Combine(_convertedDirectory, docFileNameWithExtension);
                    //WriteSimpleLogFileUtil.WriteLog("File: " + filePath);
                    if (File.Exists(filePath))
                    {
                        //WriteSimpleLogFileUtil.WriteLog("Test1");
                        //lay file content
                        //chi lay content cua file docx
                        String fileContent = WebService.Helper.Digitizing_GetFileContent_SmartChoice(filePath);
                        //tra ve ket qua cho ham
                        return fileContent;
                    }
                    else
                    {
                        SoapException se = new SoapException("File not found",
                           SoapException.ClientFaultCode,
                           Context.Request.Url.AbsoluteUri,
                           new Exception("File not found"));
                        throw se;
                    }
                }
                catch (Exception ex)
                {

                    SoapException se = new SoapException("QuickHelper_GetFileContent error",
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

        [WebMethod]
        public void QuickHelper_MakeFileIndex(String publicKey, String token, String docFileNameWithExtension)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                try
                {
                    String filePath = Path.Combine(_convertedDirectory, docFileNameWithExtension);

                    if (File.Exists(filePath))
                    {
                        //lay file content
                        //chi lay content cua file docx
                        String fileContentForIndex = Helper.Digitizing_GetFileContent_SmartChoice(filePath);
                        IndexPackage indexPackage = new IndexPackage() { DocId = Path.GetFileNameWithoutExtension(docFileNameWithExtension), DocFileName = docFileNameWithExtension, Content = fileContentForIndex };
                        //ghi index
                        Helper.Digitizing_WriteToIndexing(indexPackage: indexPackage, directoryIndexing: _indexDirectory);

                    }
                    else
                    {
                        SoapException se = new SoapException("File not found",
                           SoapException.ClientFaultCode,
                           Context.Request.Url.AbsoluteUri,
                           new Exception("File not found"));
                        throw se;
                    }
                }
                catch (Exception ex)
                {

                    SoapException se = new SoapException("QuickHelper_MakeFileIndex error",
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

        [WebMethod]
        public void QuickHelper_DeleteIndex_ByDocFileName(String publicKey, String token, String docFileNameWithExtension)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                try
                {

                    //xoa index
                    Helper.Digitizing_DeleteDocIndexing_ByDocFileName(docFileNameWithExtension, _indexDirectory);
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

        [WebMethod]
        public void QuickHelper_DeleteIndex_ByDocId(String publicKey, String token, String docId)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                try
                {

                    //xoa index
                    Helper.Digitizing_DeleteDocIndexing_ByDocId(docId, _indexDirectory);
                }
                catch (Exception ex)
                {
                    SoapException se = new SoapException("QuickHelper_RemoveFileIndex_ByDocId error",
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


        [WebMethod]
        public List<IndexPackage> QuickHelper_SearchContent(String publicKey, String token, byte[] binaryContent, Boolean fileContentInResult = false)
        {
            if (Helper.TrustTest(publicKey, token))
            {

                return Helper.Digitizing_SearchContent(Helper.Digitizing_Unzip(binaryContent), _indexDirectory);
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
        public List<IndexPackage> QuickHelper_SearchContent_String(String publicKey, String token, String content, String maPhanHe, Boolean fileContentInResult = false)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                if (maPhanHe == "NS")
                    return Helper.Digitizing_SearchContent(content, _indexNhanSuDirectory);
                else if (maPhanHe == "SH")
                    return Helper.Digitizing_SearchContent(content, _indexSoHoaDirectory);
                return null;
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