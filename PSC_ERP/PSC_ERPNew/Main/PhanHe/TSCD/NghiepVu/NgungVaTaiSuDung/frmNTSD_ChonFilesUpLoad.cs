using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ERP_Library;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using System.Diagnostics;

namespace PSC_ERPNew.Main
{
    public partial class frmNTSD_ChonFilesUpLoad : DevExpress.XtraEditors.XtraForm
    {
        ChungTu_HoSoFileLuuTruList _danhSachFileChungTu = ChungTu_HoSoFileLuuTruList.NewChungTu_HoSoFileLuuTruList();
        ERP_Library.ChungTu_HoSoFileLuuTru fileChungTu = null;
        NVNgungvaTaiSuDungTSCD_Factory _nVNgungvaTaiSuDungTSCD_Factory = new NVNgungvaTaiSuDungTSCD_Factory();
        tblNVNgungvaTaiSuDungTSCD _nVNgungvaTaiSuDungTSCD = null;

        NghiepVuDieuChuyenNoiBo_Factory _nghiepVuDieuChuyenNoiBo_Factory = new NghiepVuDieuChuyenNoiBo_Factory();
        tblNghiepVuDieuChuyenNoiBo _nghiepVuDieuChuyenNoiBo = null;
        int maLoaiNghiepVu ;
        public frmNTSD_ChonFilesUpLoad(int maNghiepVu, int maLoaiNV)
        {
            InitializeComponent();
            maLoaiNghiepVu = maLoaiNV;
            if(maLoaiNghiepVu ==99|| maLoaiNghiepVu == 98)
             _nVNgungvaTaiSuDungTSCD = _nVNgungvaTaiSuDungTSCD_Factory.Get_DanhSachNVNgungvaTaiSuDungTSCD_ByMaNVNgungvaTaiSuDungTSCD(maNghiepVu);
            else if (maLoaiNghiepVu == 13)
             _nghiepVuDieuChuyenNoiBo = _nghiepVuDieuChuyenNoiBo_Factory.Get_NghiepVuDieuChuyenNoiBoTheoMaNghiepVuDieuChuyenNoiBo(maNghiepVu);

        }

        private void btnAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //mở open file diaglog cho phép chọn nhieu file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "Pdf files|*.pdf";
            openFileDialog1.Filter = "Chứng từ files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png,*.pdf) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png;*.pdf";
            openFileDialog1.Multiselect = true;
            int soFileUpLoad = 0;
            int soFileLoi = 0;
            List<string> dsFileLoi = new List<string>();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.         
            if (result == DialogResult.OK) // Test result. 
            {
                if (openFileDialog1.FileNames.Count() > 0)
                {
                    foreach (String filePath in openFileDialog1.FileNames)
                    {
                        string ftppath = "ftp://data.psctelecom.com.vn/AMS/GiayTo/", userName = "erp", matKhau = "pscvietnam";
                        ERP_Library.ChungTu_HoSoFileLuuTru fileChungTuNew = ERP_Library.ChungTu_HoSoFileLuuTru.NewChungTu_HoSoFileLuuTru();
                        fileChungTuNew.TenFile = filePath;
                        fileChungTuNew.UrlHosochungtu = ftppath;
                        fileChungTuNew.Username = userName;
                        fileChungTuNew.Password = matKhau;
                        fileChungTuNew.TenFile = filePath.Substring(filePath.LastIndexOf(@"\") + 1);
                        if (maLoaiNghiepVu == 99 || maLoaiNghiepVu == 98)//99 TSCD tái sử dụng; 98 TSCD ngừng sử dụng; không có trong bảng Loại chứng từ 
                        {
                            fileChungTuNew.MaChungTu = _nVNgungvaTaiSuDungTSCD.MaNghiepVu;                         
                            fileChungTuNew.TenFileUp = _nVNgungvaTaiSuDungTSCD.MaNghiepVu.ToString() + "_" + Guid.NewGuid();
                        }
                        else if(maLoaiNghiepVu==13) // 13 Loại chứng từ Điều chuyển nội bộ
                        {
                            fileChungTuNew.MaChungTu = _nghiepVuDieuChuyenNoiBo.MaNghiepVuDieuChuyenNoiBo;                            
                            fileChungTuNew.TenFileUp = _nghiepVuDieuChuyenNoiBo.MaNghiepVuDieuChuyenNoiBo.ToString() + "_" + Guid.NewGuid();
                        }
                        fileChungTuNew.MaLoaiNghiepVu = maLoaiNghiepVu;
                        try
                        {
                            using (DialogUtil.WaitForSave(this))
                            {
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

        private void btnDownFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ftppath = "ftp://data.psctelecom.com.vn/AMS/GiayTo/" + fileChungTu.TenFileUp;
            byte[] file;


            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
         //   SaveFileDialog1.Filter = "Pdf files|*.pdf";
            SaveFileDialog1.Filter = "Chứng từ files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png,*.pdf) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png;*.pdf";
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

            if (DialogUtil.ShowYesNo("Đồng ý mở file!", "Hỏi ý kiến") == DialogResult.Yes)
                Process.Start(SaveFileDialog1.FileName);
            SaveFileDialog1.Dispose();
            SaveFileDialog1 = null;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmNTSD_ChonFilesUpLoad_Load(object sender, EventArgs e)
        {
            if(maLoaiNghiepVu ==98 ||maLoaiNghiepVu ==99)
            _danhSachFileChungTu = ChungTu_HoSoFileLuuTruList.GetChungTu_HoSoFileLuuTruList(_nVNgungvaTaiSuDungTSCD.MaNghiepVu ,maLoaiNghiepVu);
            else if(maLoaiNghiepVu ==13)
             _danhSachFileChungTu = ChungTu_HoSoFileLuuTruList.GetChungTu_HoSoFileLuuTruList(_nghiepVuDieuChuyenNoiBo.MaNghiepVuDieuChuyenNoiBo, maLoaiNghiepVu);
            if (_danhSachFileChungTu.Count > 0)
                ChungTu_HoSoFileLuuTruListSource.DataSource = _danhSachFileChungTu;
        }

        private void gridViewDanhSachFile_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (_danhSachFileChungTu.Count > 0)
                fileChungTu = _danhSachFileChungTu.ElementAt(e.FocusedRowHandle);
        }

        private void gridViewDanhSachFile_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void frmNTSD_ChonFilesUpLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtBlackHole.Focus();
            this.DialogResult = DialogResult.Yes;
        }
    }
}