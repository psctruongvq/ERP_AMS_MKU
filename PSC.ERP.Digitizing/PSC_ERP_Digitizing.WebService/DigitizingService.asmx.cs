using System.Web.Services;
using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Data;

using System.Text;

using System.IO;
using iTextSharp.text.pdf;
using System.Web.Services.Protocols;
using System.Web.Configuration;

namespace PSC_ERP_Digitizing.WebService
{
    //BasicHttpBinding httpBinding = youAddWebServiceName.ChannelFactory.Endpoint.Binding as BasicHttpBinding;
    //httpBinding.MaxReceivedMessageSize = int.MaxValue;

    /// <summary>
    /// Summary description for MainService
    /// </summary>
    [WebService(Namespace = "http://www.pscvietnam.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public partial class DigitizingService : System.Web.Services.WebService
    {
        String _customerCode;
        String _digitizingRootDirectory;
        //String _trashDirectory;
        String _tempUploadDirectory;
        String _watchingDirectory;
        //String _dataDirectory;
        //index
        String _indexDirectory;
        String _indexNhanSuDirectory;
        String _indexSoHoaDirectory;
        //convert
        String _convertedDirectory;
        //String _convertedNhanSuDirectory;
        //String _convertedSoHoaDirectory;
        //source
        String _sourceDirectory;
        String _sourceNhanSuDirectory;
        String _sourceSoHoaDirectory;
        //String _tempForIndexDirectory;
        //String _backupSegmentsFilePath;

        public DigitizingService()
        {
            _customerCode = WebConfigurationManager.AppSettings["CustomerCode"];
            _digitizingRootDirectory = WebConfigurationManager.AppSettings["DigitizingRootDirectory"];
            //_trashDirectory = Path.Combine(_digitizingRootDirectory, WebConfigurationManager.AppSettings["TrashDirectory"]);
            _tempUploadDirectory = Path.Combine(_digitizingRootDirectory, WebConfigurationManager.AppSettings["TempUploadDirectory"]);
            _watchingDirectory = Path.Combine(_digitizingRootDirectory, WebConfigurationManager.AppSettings["WatchingDirectory"]);
            //_dataDirectory = Path.Combine(_digitizingRootDirectory, WebConfigurationManager.AppSettings["DataDirectory"]);
            //index
            _indexDirectory = Path.Combine(_digitizingRootDirectory, WebConfigurationManager.AppSettings["IndexDirectory"]);
            _indexNhanSuDirectory = Path.Combine(_digitizingRootDirectory, WebConfigurationManager.AppSettings["IndexNhanSuDirectory"]);
            _indexSoHoaDirectory = Path.Combine(_digitizingRootDirectory, WebConfigurationManager.AppSettings["IndexSoHoaDirectory"]);
            //convert
            _convertedDirectory = Path.Combine(_digitizingRootDirectory, WebConfigurationManager.AppSettings["ConvertedDirectory"]);
            //_convertedNhanSuDirectory = Path.Combine(_convertedDirectory, WebConfigurationManager.AppSettings["ConvertedNhanSuDirectory"]);
            //_convertedSoHoaDirectory = Path.Combine(_convertedDirectory, WebConfigurationManager.AppSettings["ConvertedSoHoaDirectory"]);
            //source
            _sourceDirectory = Path.Combine(_digitizingRootDirectory, WebConfigurationManager.AppSettings["SourceDirectory"]);
            _sourceNhanSuDirectory = Path.Combine(_digitizingRootDirectory, WebConfigurationManager.AppSettings["SourceNhanSuDirectory"]);
            _sourceSoHoaDirectory = Path.Combine(_digitizingRootDirectory, WebConfigurationManager.AppSettings["SourceSoHoaDirectory"]);
            //_tempForIndexDirectory = Path.Combine(_digitizingRootDirectory, WebConfigurationManager.AppSettings["TempForIndexDirectory"]);
            //_backupSegmentsFilePath = Path.Combine(_digitizingRootDirectory, WebConfigurationManager.AppSettings["BackupSegmentsFilePath"]);


        }







        //private static void TestUploadFile(String publicKey, String token, String filePath, String targetDirectoryPath, String targetFileName)
        //{
        //    try
        //    {
        //        String targetFilePath = Path.Combine(targetDirectoryPath, targetFileName);
        //        int offset = 0;
        //        int intendedChunkSize = 65536; //65536;
        //        byte[] buffer = new byte[intendedChunkSize];
        //        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        //        DigitizingService service = new DigitizingService();
        //        bool uploadSuccedd = true;

        //        try
        //        {
        //            //Delete file first
        //            service.IO_TryDeleteFile("publicKey", "token", targetFilePath);
        //        }
        //        catch { }
        //        try
        //        {
        //            Int64 fileSize = new FileInfo(filePath).Length;//Tổng dung lượng file
        //            fs.Position = offset;
        //            int bytesRead = 0;
        //            while (offset != fileSize)
        //            {
        //                //_num3 = Offset; //Dung lượng đã upload
        //                bytesRead = fs.Read(buffer, 0, intendedChunkSize);

        //                if (bytesRead != intendedChunkSize)
        //                {

        //                    byte[] trimmedBuffer = new byte[bytesRead];
        //                    Array.Copy(buffer, trimmedBuffer, bytesRead);
        //                    buffer = trimmedBuffer;
        //                }

        //                try
        //                {
        //                    service.UploadFileLargeSize(publicKey, token, targetFilePath, buffer, offset);

        //                }
        //                catch (Exception ex)
        //                {
        //                    uploadSuccedd = false;
        //                    break;

        //                }

        //                offset += bytesRead;
        //            }
        //        }
        //        catch { }
        //        finally
        //        {
        //            fs.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //PscMessage.ShowError(ex.Message);
        //    }
        //}


        //private static void TestDownloadFile(String sourceFilePath, String targetFilePath)
        //{

        //    //str1: Server file location
        //    //str3: local file location
        //    byte[] data = null;
        //    DigitizingService service = new DigitizingService();
        //    try
        //    {
        //        data = service.DownloadFile("publicKey", "token", sourceFilePath, null);
        //        System.IO.FileStream fs = new System.IO.FileStream(targetFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
        //        fs.Write(data, 0, data.Length);
        //        fs.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        //[WebMethod(Description = "Trả về danh mục đối tượng: đơn vị", EnableSession = true)]
        //[System.Xml.Serialization.XmlInclude(typeof(DonVi))]
        //public List<DonVi> Get_DonViList_Type2(ModifiedType modifiedType, DateTime tuNgay, DateTime denNgay, Boolean isTest)
        //{
        //    String method = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    return GetDonViList_Helper(modifiedType: modifiedType, tuNgay: tuNgay, denNgay: denNgay, method: method, isTest: isTest);
        //}// 


    }
}
