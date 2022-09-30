
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using Infragistics.Win;
using System.IO;
using System.Net;
using PSC_ERP_Common;
using System.Configuration;

namespace PSC_ERP
{
    public partial class frmChiTietVanBan : Form
    {
        #region
        #endregion

        public frmChiTietVanBan(VanBan vanBan)
        {
            InitializeComponent();
            //Tải thông tin văn bản
            DisplayFilePDF(vanBan.DuongDan);
        }
      
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
                this.Close();        
        }

        private void DisplayFilePDF(string url)
        {
            //Khai báo các biến
            String ftpurl = string.Empty; // e.g. ftp://serverip/foldername/foldername
            String ftpusername = string.Empty; // e.g. username
            String ftppassword = string.Empty; // e.g. password

            try
            {
                //Lấy thông tin từ file config
                LayThongTinKetNoi(ref ftpurl, ref ftpusername, ref ftppassword);

                WebClient request = new WebClient();
                request.Credentials = new NetworkCredential(ftpusername, ftppassword);

                byte[] newFileData = request.DownloadData(new Uri(url));

                string strTenFile = "TempFile.pdf";
                SaveFilePDF(newFileData, strTenFile);

                axAcroPDF.LoadFile("TempFile.pdf");
                axAcroPDF.setView("Fit");
                axAcroPDF.setShowToolbar(false);
                axAcroPDF.Enabled = true;
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Không thể lấy tập tin trong máy chủ." + ex.Message);          
                return;
            }
        }

        private void SaveFilePDF(byte[] File, string strTenFile)
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

        private void LayThongTinKetNoi(ref String ftpurl, ref String ftpusername, ref String ftppassword)
        {
            ftpurl = ConfigurationManager.AppSettings["ftpUrl_Digital"];
            ftpusername = ConfigurationManager.AppSettings["ftpUser_Digital"];
            ftppassword = ConfigurationManager.AppSettings["ftpPass_Digital"];
        }
    }
}
