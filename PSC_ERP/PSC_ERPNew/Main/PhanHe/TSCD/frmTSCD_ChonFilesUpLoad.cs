using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Common;
using System.IO;
using PSC_ERP_Digitizing.Client.WebReference1;
using System.Transactions;
using iTextSharp.text.pdf;
using ERP_Library;
using System.Diagnostics;
using System.Net;

namespace PSC_ERPNew.Main
{
    public partial class frmDigitizing_ChonFilesUpLoad : XtraForm
    {
        ChungTu_HoSoFileLuuTruList _danhSachFileChungTu = ChungTu_HoSoFileLuuTruList.NewChungTu_HoSoFileLuuTruList();
        ChungTu_HoSoFileLuuTru fileChungTu = null;
        ChungTu _chungTu = null;
        public frmDigitizing_ChonFilesUpLoad(long maChungTu = 0)
        {
            InitializeComponent();
            _chungTu = ChungTu.GetChungTu(maChungTu); 
        }
      
        private void frmDigitizing_ChonFilesUpLoad_Load(object sender, EventArgs e)
        {
            _danhSachFileChungTu = ChungTu_HoSoFileLuuTruList.GetChungTu_HoSoFileLuuTruList(_chungTu.MaChungTu, _chungTu.LoaiChungTu.MaLoaiCT);
            if(_danhSachFileChungTu.Count>0)
                ChungTu_HoSoFileLuuTruListSource.DataSource = _danhSachFileChungTu;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        public int GetNoOfPagesPDF(string FileName)
        {
            int result = 0;
            //FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            //StreamReader r = new StreamReader(fs);
            //string pdfText = r.ReadToEnd();

            //System.Text.RegularExpressions.Regex regx = new Regex(@"/Type\s*/Page[^s]");
            //System.Text.RegularExpressions.MatchCollection matches = regx.Matches(pdfText);
            //result = matches.Count;
           
            PdfReader pdfReader = new PdfReader(FileName);
            result = pdfReader.NumberOfPages;        

            return result;
        }

        private void btnAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //mở open file diaglog cho phép chọn nhieu file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
          //  openFileDialog1.Filter = "Pdf files|*.pdf";
            openFileDialog1.Filter = "Chứng từ files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png,*.pdf) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png;*.pdf";
            openFileDialog1.Multiselect = true;
            //int soFileUpLoad = 0;
            //int soFileLoi = 0;
            List<string> dsFileLoi = new List<string>();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.         
            if (result == DialogResult.OK) // Test result. 
            {
                if (openFileDialog1.FileNames.Count() > 0)
                {
                    foreach (String filePath in openFileDialog1.FileNames)
                    {
                        string ftppath = "ftp://data.psctelecom.com.vn/AMS/GiayTo/", userName = "erp", matKhau = "pscvietnam";
                        ChungTu_HoSoFileLuuTru fileChungTuNew = ChungTu_HoSoFileLuuTru.NewChungTu_HoSoFileLuuTru();
                        fileChungTuNew.TenFile = filePath;
                        fileChungTuNew.UrlHosochungtu = ftppath;
                        fileChungTuNew.Username = userName;
                        fileChungTuNew.Password = matKhau;
                        fileChungTuNew.TenFile = filePath.Substring(filePath.LastIndexOf(@"\") + 1);
                        fileChungTuNew.MaChungTu = _chungTu.MaChungTu;
                        fileChungTuNew.MaLoaiNghiepVu = _chungTu.LoaiChungTu.MaLoaiCT;       
                        fileChungTuNew.TenFileUp = _chungTu.MaChungTu.ToString() + "_" + Guid.NewGuid();
                        try
                        {
                            using (DialogUtil.WaitForSave(this)) { 
                                    FptProvider.UploadFile(ftppath, userName, matKhau, filePath, fileChungTuNew.TenFileUp);
                                    _danhSachFileChungTu.Add(fileChungTuNew);
                                    _danhSachFileChungTu.Save();
                                ChungTu_HoSoFileLuuTruListSource.DataSource = _danhSachFileChungTu;
                            }
                            DialogUtil.ShowSaveSuccessful();
                        }
                        catch (Exception)
                        {
                            DialogUtil.ShowWarning("Đã xảy ra lỗi trong quá trình tải file!\nVui lòng tải lại file lần nữa!");
                        }
                    }
                }
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.txtBlackHole.Focus();
            ////yêu cầu người dùng xác nhận xóa
            string ftppath = "ftp://data.psctelecom.com.vn/AMS/GiayTo/" + fileChungTu.TenFileUp;
            byte[] file;
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn xóa những dòng đang chọn?");
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required,
                    //                 TimeSpan.FromSeconds(180)))
                    //{
                    //    Int32[] rowHandleList = this.gridViewDanhSachFile.GetSelectedRows();
                       
                    //}
                    using (DialogUtil.WaitForDelete(this))
                    {
                        // FptProvider.DeleteFileOnServer(ftppath, fileChungTu.Username, fileChungTu.Password);
                        _danhSachFileChungTu.RemoveAt(gridViewDanhSachFile.FocusedRowHandle);
                    //    ChungTu_HoSoFileLuuTruListSource.RemoveAt(gridViewDanhSachFile.FocusedRowHandle);
                    //    gridViewDanhSachFile.DeleteRow(gridViewDanhSachFile.FocusedRowHandle );
                        _danhSachFileChungTu.Save();
                    }
                    DialogUtil.ShowDeleteSuccessful();
                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError("Không thể xóa những dòng đang chọn!");
                }
            }
        }

        //up file lên Server
        public static Boolean UploadFile(String publicKey, String token, String filePath, String destFileNameWithExtension)
        {
            bool uploadSuccedd = true;
            try
            {
                long offset = 0;
                int intendedChunkSize = 65536; //65536;
                byte[] buffer = new byte[intendedChunkSize];
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                DigitizingService service = new DigitizingService();
                //DigitizingServiceSoap service = new DigitizingServiceSoapClient();     

                try
                {
                    Int64 fileSize = new FileInfo(filePath).Length;//Tổng dung lượng file
                    //this.progressBarControl1.Properties.Step = intendedChunkSize;
                    //this.progressBarControl1.Properties.Maximum = (Int32)(fileSize / intendedChunkSize);
                    //this.progressBarControl1.Properties.Minimum = 0;
                    fs.Position = offset;
                    int bytesRead = 0;
                    while (offset != fileSize)
                    {
                        ////////_num3 = Offset; //Dung lượng đã upload
                        //progressBarControl1.PerformStep();
                        //progressBarControl1.Update();

                        bytesRead = fs.Read(buffer, 0, intendedChunkSize);
                        if (bytesRead != intendedChunkSize)
                        {

                            byte[] trimmedBuffer = new byte[bytesRead];
                            Array.Copy(buffer, trimmedBuffer, bytesRead);
                            buffer = trimmedBuffer;
                        }

                        try
                        {
                            service.QuickHelper_UploadFileLargeSize(publicKey, token, destFileNameWithExtension, buffer, offset, fileSize, "SH");
                            //QuickHelper_UploadFileLargeSizeResponse response = service.QuickHelper_UploadFileLargeSize(new QuickHelper_UploadFileLargeSizeRequest(new QuickHelper_UploadFileLargeSizeRequestBody(PublicKey, Token, targetFilePath, buffer, offset, fileSize)));
                        }
                        catch (Exception ex)
                        {
                            uploadSuccedd = false;
                            break;
                        }

                        offset += bytesRead;
                    }
                }
                catch { }
                finally
                {
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                //PscMessage.ShowError(ex.Message);
            }
            return uploadSuccedd;
        }

        private void frmDigitizing_ChonFilesUpLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtBlackHole.Focus();
            this.DialogResult = DialogResult.Yes;
            //xử lý khi form đang đóng nếu có thay đổi thì save lại vào database           
        }

        private void gridViewDanhSachFile_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridViewDanhSachFile_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(_danhSachFileChungTu.Count>0)
            fileChungTu = _danhSachFileChungTu.ElementAt(e.FocusedRowHandle);
        }

        private void btnDownFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ftppath = "ftp://data.psctelecom.com.vn/AMS/GiayTo/" + fileChungTu.TenFileUp;
            byte[] file;


             SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
           // SaveFileDialog1.Filter = "Pdf files|*.pdf";
            SaveFileDialog1.Filter = "(*.jpg, *.jpeg, *.jpe, *.jfif, *.png,*.pdf) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png;*.pdf";
            SaveFileDialog1.FileName = fileChungTu.TenFile;
            SaveFileDialog1.Title = "Lưu Hồ Sơ Chứng Từ";
            SaveFileDialog1.AddExtension = true;

            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (DialogUtil.WaitForSave(this))
                    {
                        file = FptProvider.DownloadFile(ftppath, fileChungTu.Username, fileChungTu.Password);
                        FptProvider.SaveFilePDF(file, SaveFileDialog1.FileName);
                    }
                    DialogUtil.ShowSaveSuccessful();
                }
                catch (Exception)
                {
                    DialogUtil.ShowWarning("Đã xảy ra lỗi trong quá trình tải file!\nVui lòng tải lại file lần nữa!");
                }
               
            }
            else
            {
               // MessageBox.Show("You hit cancel or closed the dialog.");
            }

          if(  DialogUtil.ShowYesNo("Đồng ý mở file!", "Hỏi ý kiến") ==DialogResult.Yes)
                      Process.Start(SaveFileDialog1.FileName);
            SaveFileDialog1.Dispose();
            SaveFileDialog1 = null;
        }
    }
}