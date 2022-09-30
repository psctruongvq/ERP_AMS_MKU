﻿using PSC_ERP_Common;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace PSC_ERPNew.Main
{
    public  class FptProvider
    {
        /// <summary>
        /// Upload file to server using FTP UTF8
        /// </summary>
        /// <param name="ftppath">ftp path</param>
        /// <param name="username">ftp username</param>
        /// <param name="password">ftp password</param>
        /// <param name="filename">file name</param>
        public static void UploadFileUTF8(string ftppath, string username, string password, string file, string fileName_Next)
        {
            try
            {
                {//Tiến hành upload file lên máy chủ

                    FtpWebRequest ftp = CreateFTP(ftppath, username, password, fileName_Next, WebRequestMethods.Ftp.UploadFile);

                    if (!CheckFileExists(ftppath, username, password, fileName_Next))
                    {
                        StreamReader sourceStream = new StreamReader(file);
                        byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                        sourceStream.Close();
                        ftp.ContentLength = fileContents.Length;

                        Stream requestStream = ftp.GetRequestStream();
                        requestStream.Write(fileContents, 0, fileContents.Length);
                        requestStream.Close();
                    }
                    else
                        throw new Exception("File đã tồn tại trên máy chủ. Vui lòng đổi tên file rồi thử lại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi trong quá trình ghi tập tin: \r\n" + ex.Message);
            }
        }

        private static bool CheckFileExists(string ftppath, string username, string password, string filename)
        {
            try
            {
                FtpWebRequest ftp = CreateFTP(ftppath, username, password, filename, WebRequestMethods.Ftp.DownloadFile);
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                return response != null;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Upload file to server using FTP
        /// </summary>
        /// <param name="ftppath">ftp path</param>
        /// <param name="username">ftp username</param>
        /// <param name="password">ftp password</param>
        /// <param name="filename">file name</param>
        public static void UploadFile(string ftppath, string username, string password, string file, string fileName_Next)
        {
            try
            {
                {//Tiến hành upload file lên máy chủ
                    FtpWebRequest ftp = CreateFTP(ftppath, username, password, fileName_Next, WebRequestMethods.Ftp.UploadFile);
                    if (!CheckFileExists(ftppath, username, password, fileName_Next))
                    {
                        using (FileStream fs = File.OpenRead(file))
                        {
                            byte[] buffer = new byte[fs.Length];
                            fs.Read(buffer, 0, buffer.Length);
                            fs.Close();
                            Stream requestStream = ftp.GetRequestStream();
                            requestStream.Write(buffer, 0, buffer.Length);
                            requestStream.Close();
                            requestStream.Flush();
                        }
                    }
                    else
                        throw new Exception("File đã tồn tại trên máy chủ. Vui lòng liên hệ với quản trị phần mềm.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi trong quá trình ghi tập tin: \r\n" + ex.Message);
            }
        }

        /// <summary>
        /// Upload file to server using FTP
        /// </summary>
        /// <param name="ftppath">ftp path</param>
        /// <param name="username">ftp username</param>
        /// <param name="password">ftp password</param>
        /// <param name="filename">file name</param>
        public static void UploadImageFile(string ftppath, string username, string password, string file, string fileName_Next)
        {
            try
            {
                {//Tiến hành upload file lên máy chủ
                    FtpWebRequest ftp = CreateFTP(ftppath, username, password, fileName_Next, WebRequestMethods.Ftp.UploadFile);
                    using (FileStream fs = File.OpenRead(file))
                    {
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        fs.Close();
                        Stream requestStream = ftp.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Close();
                        requestStream.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi trong quá trình ghi tập tin: \r\n" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ftppath"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static byte[] DownloadFile(string ftppath, string username, string password)
        {
            try
            {
                WebClient request = new WebClient();
                request.Credentials = new NetworkCredential(username, password);
                byte[] newFileData = request.DownloadData(ftppath);
                return newFileData;
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi trong quá trình đọc tập tin: \r\n" + ex.Message);
            }
        }

        /// <summary>
        /// Create FTP
        /// </summary>
        /// <param name="ftppath">ftp path</param>
        /// <param name="username">ftp username</param>
        /// <param name="password">ftp password</param>
        /// <param name="filepath">file path</param>
        /// <param name="method">ftp method</param>
        /// <returns></returns>
        private static FtpWebRequest CreateFTP(string ftppath, string username, string password, string filepath, string method)
        {
            FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(ftppath + filepath);
            ftp.Credentials = new NetworkCredential(username, password);
            ftp.KeepAlive = false;
            ftp.UseBinary = true;
            ftp.Method = method;

            return ftp;
        }

        /// <summary>
        /// Tạo đường dẫn và thư mục chứa văn bản
        /// </summary>
        /// <param name="ftppath">ftp path</param>
        /// <param name="username">ftp username</param>
        /// <param name="password">ftp password</param>
        /// <returns></returns>
        public static void CreateForder(string directory, string userName, string pass)
        {
            bool directoryExists;

            var request = WebRequest.Create(directory);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(userName, pass);

            try
            {
                using (request.GetResponse())
                {
                    directoryExists = true;
                }
            }
            catch (WebException)
            {
                directoryExists = false;
            }

            try
            {
                if (!directoryExists)
                {
                    WebRequest req = WebRequest.Create(directory);
                    req.Method = WebRequestMethods.Ftp.MakeDirectory;
                    req.Credentials = new NetworkCredential(userName, pass);
                    using (var resp = (FtpWebResponse)req.GetResponse())
                    {
                        Console.WriteLine(resp.StatusCode);
                    }
                }
            }
            catch (Exception ex) { throw; }
        }

        /// <summary>
        /// Tạo đường dẫn và thư mục chứa văn bản
        /// </summary>
        /// <param name="Filepath">file path</param>
        /// <returns></returns>
        public static void CreateForder(string directoryServer)
        {
            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(directoryServer);
                if (!dInfo.Exists)
                {
                    dInfo.Create();
                }
            }
            catch (Exception ex) { throw; }
        }

        /// <summary>
        /// Tiến hành xóa file trên máy chủ
        /// </summary>
        /// <param name="ftppath">ftp path</param>
        /// <param name="username">ftp username</param>
        /// <param name="password">ftp password</param>
        /// <returns></returns>
        public static void DeleteFileOnServer(string url, string ftpusername, string ftppassword)
        {
            try
            {
                FtpWebRequest requestFileDelete = (FtpWebRequest)WebRequest.Create(url);
                requestFileDelete.Credentials = new NetworkCredential(ftpusername, ftppassword);
                requestFileDelete.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse responseFileDelete = (FtpWebResponse)requestFileDelete.GetResponse();
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Không thể xóa tập tin trong máy chủ." + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Tiến hành xóa file trên máy chủ
        /// </summary>
        /// <param name="ftppath">ftp path</param>
        /// <param name="username">ftp username</param>
        /// <param name="password">ftp password</param>
        /// <returns></returns>
        public static bool DeleteFileOnServerNew(string url, string ftpusername, string ftppassword)
        {
            try
            {

                FtpWebRequest requestFileDelete = (FtpWebRequest)WebRequest.Create(url);
                requestFileDelete.Credentials = new NetworkCredential(ftpusername, ftppassword);
                requestFileDelete.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse responseFileDelete = (FtpWebResponse)requestFileDelete.GetResponse();
                //
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ftppath"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static void SaveFilePDF(byte[] File, string strTenFile)
        {
            try
            {
                FileStream fs = new FileStream(strTenFile, FileMode.Create, FileAccess.ReadWrite);
                BinaryWriter w = new BinaryWriter(fs);
                w.Flush();
                w.Write(File);
                w.Close();
            }
            catch
            {
                throw;
            }
        }
    }
}
