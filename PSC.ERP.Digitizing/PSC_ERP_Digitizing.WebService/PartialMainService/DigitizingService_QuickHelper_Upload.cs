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

//B1:
//upload: dua vao thu muc TempUpload -> chuyen sang thu muc Watching
//dong thoi cung copy sang thu muc DATA\Source
//Hoan tat qua trinh upload

//B2:
//ABBYY se convert sang dinh dang docx va xlsx vao thu muc DATA\Converted
//txt vao thu muc DATA\TempForIndex
//Sau khi convert xong file trong thu muc Watching thi ABBYY di chuyen file nguon vao thu muc Rash

//B3:
//ung dung chay ngam tren server se quet cac file txt trong DATA\TempForIndex để ghi index vào thư mục DATA\Index và đồng thời di chuyển text file sang thư mục DATA\Converted de luu tru 
//cung se tu dong xoa cac file trong thu muc Rash

namespace PSC_ERP_Digitizing.WebService
{
    public partial class DigitizingService
    {


        [WebMethod]
        public void QuickHelper_UploadPdfFile(String publicKey, String token, byte[] f, String destFileNameWithExtension, String key)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                //refresh appSettings section
                //ConfigurationManager.RefreshSection("appSettings");



                String tempUploadFilePath = Path.Combine(_tempUploadDirectory, destFileNameWithExtension);

                UploadPdfFile_Helper(f: f, destFileName: destFileNameWithExtension, destDirPath: _tempUploadDirectory, key: key);
                //thay doi ti xiu
                IOUtil.SetAllowFullAccessFileForEveryone(tempUploadFilePath);
                //copy sang thu muc Source
                try
                {
                    String destFilePath_inSource = Path.Combine(_sourceDirectory, destFileNameWithExtension);
                    File.Copy(tempUploadFilePath, destFilePath_inSource);
                    IOUtil.SetAllowFullAccessFileForEveryone(destFilePath_inSource);
                }
                catch (Exception ex)
                {
                    //Throw the exception    
                    SoapException se = new SoapException("Copy file " + destFileNameWithExtension + " to " + _sourceDirectory + " error",
                      SoapException.ClientFaultCode,
                      Context.Request.Url.AbsoluteUri,
                      ex);
                    throw se;
                }
                //di chuyen file da up sang thu muc Watching
                try
                {
                    File.Move(tempUploadFilePath, Path.Combine(_watchingDirectory, destFileNameWithExtension));
                }
                catch (Exception ex)
                {
                    //Throw the exception    
                    SoapException se = new SoapException("Move file error",
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
        public void QuickHelper_UploadFileLargeSize(String publicKey, String token, string destFileNameWithExtension, byte[] buffer, long offset, long fileSize, String maPhanHe)
        {//su dung
            if (Helper.TrustTest(publicKey, token))
            {
                //WriteSimpleLogFileUtil.WriteLog("Test1");

                String tempUploadFilePath = Path.Combine(_tempUploadDirectory, destFileNameWithExtension);


                //Delete file first
                if (offset == 0)
                    IOUtil.TryDeleteFile(tempUploadFilePath);

                try
                {
                    Helper.Digitizing_UploadFileLargeSize(destFilePath: tempUploadFilePath, buffer: buffer, offset: offset);

                }
                catch (Exception ex)
                {
                    //Throw the exception    
                    SoapException se = new SoapException("Digitizing_UploadFileLargeSize error",
                      SoapException.ClientFaultCode,
                      Context.Request.Url.AbsoluteUri,
                      ex);
                    throw se;
                }

                if (fileSize == offset + buffer.LongLength)
                {

                    //thay doi ti xiu
                    IOUtil.SetAllowFullAccessFileForEveryone(tempUploadFilePath);

                    //copy sang thu muc Source
                    try
                    {
                        String sourceFilePath="";
                        if (maPhanHe == "SH")
                            sourceFilePath = Path.Combine(_sourceSoHoaDirectory, destFileNameWithExtension);
                        else if (maPhanHe == "NS")
                            sourceFilePath = Path.Combine(_sourceNhanSuDirectory, destFileNameWithExtension);
                        File.Copy(tempUploadFilePath, sourceFilePath);
                        IOUtil.SetAllowFullAccessFileForEveryone(sourceFilePath);

                    }
                    catch (Exception ex)
                    {
                        //Throw the exception    
                        SoapException se = new SoapException("Copy file " + destFileNameWithExtension + " to " + _sourceDirectory + " error",
                          SoapException.ClientFaultCode,
                          Context.Request.Url.AbsoluteUri,
                          ex);
                        throw se;
                    }
                    //di chuyen file
                    try
                    {

                        //Directory.GetDirectories(watchingFilePath);
                        DirectoryInfo watchingRoot = new DirectoryInfo(_watchingDirectory);
                        DirectoryInfo[] childDirList = watchingRoot.GetDirectories();
                        int num1 = 0;
                        Boolean breakWhile = false;
                        while (breakWhile == false)
                        {
                            foreach (var dir in childDirList)
                            {
                                if (dir.GetFiles().Count() <= num1)
                                {
                                    String childWatchingFilePath = Path.Combine(dir.FullName, destFileNameWithExtension);
                                    File.Move(tempUploadFilePath, childWatchingFilePath);
                                    IOUtil.TrySetAllowFullAccessFileForEveryone(childWatchingFilePath);
                                    breakWhile = true;
                                    break;
                                }
                            }
                            num1 += 1;
                        }

                        //String watchingFilePath = Path.Combine(_watchingDirectory, destFileNameWithExtension);
                        //File.Move(tempUploadFilePath, watchingFilePath);
                    }
                    catch (Exception ex)
                    {
                        //Throw the exception    
                        SoapException se = new SoapException("Move file error",
                          SoapException.ClientFaultCode,
                          Context.Request.Url.AbsoluteUri,
                          ex);
                        throw se;
                    }
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