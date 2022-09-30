using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main.Predefined;
using DevExpress.XtraEditors;
using System.Net.Mail;
using System.Net;
using ERP_Library.Security;
using ERP_Library;
using System.Data.SqlClient;
using DevExpress.DataAccess.Excel;
using PSC_ERP;
using System.IO;
using DevExpress.Utils;

namespace PSC_ERPNew.Main
{
    public partial class frmDieuChuyenNoiBoTSCDCaBiet : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDieuChuyenNoiBoTSCDCaBiet singleton_ = null;
        public static frmDieuChuyenNoiBoTSCDCaBiet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDieuChuyenNoiBoTSCDCaBiet();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
           FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }
        #endregion

        //Private Member field
        #region Private Member field
        List<tblBoPhanERPNew> _viTriList = null;
        IQueryable<tblnsBoPhan> _boPhanList = null;
        List<tblnsBoPhan> _boPhan_LichSuDCList = null;
        List<tblDanhMucTSCD> _tscdList = null;
        //List<tblTaiSanCoDinhCaBiet> _taiSanCoDinhCaBietList_TimDuyet = null;
        NghiepVuDieuChuyenNoiBo_Factory _nghiepVuDieuChuyenNoiBo_Factory = null;
        tblNghiepVuDieuChuyenNoiBo _nghiepVuDieuChuyenNoiBo = null;
        IQueryable<tblnsNhanVien> _nhanVienGiaoList = null;
        IQueryable<tblnsNhanVien> _nhanVienTiepNhanList = null;
        IQueryable<tblCT_NghiepVuDieuChuyenNoiBo> _chiTietNghiepVuDieuChuyenNoiBoList = null;
        int _maNghiepVuDieuChuyenNoiBo = 0;
        Boolean _xemLaiChungTuCu = false;
        
        UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDieuChuyenNoiBoTSCDCaBiet()
        {
            InitializeComponent();
            _maNghiepVuDieuChuyenNoiBo = 0;
            _xemLaiChungTuCu = false;          
        }

        public frmDieuChuyenNoiBoTSCDCaBiet(int maNghiepVuDieuChuyenNoiBo)
        {
            InitializeComponent();
            _xemLaiChungTuCu = true;
            // Lấy mã nghiệp vụ điều chuyển nội bộ
            _maNghiepVuDieuChuyenNoiBo = maNghiepVuDieuChuyenNoiBo;
        }
        #endregion
        //Private Member Function
        #region Private Member Function

        private void XemLaiChungTuCu(int maNghiepVuDieuChuyenNoiBo)
        {
            //Khởi tạo factory
            //_nghiepVuDieuChuyenNoiBo_Factory = NghiepVuDieuChuyenNoiBo_Factory.New();
            // Lấy nghiệp vu điều chuyển nội bộ
            _nghiepVuDieuChuyenNoiBo = _nghiepVuDieuChuyenNoiBo_Factory.Get_NghiepVuDieuChuyenNoiBoTheoMaNghiepVuDieuChuyenNoiBo(maNghiepVuDieuChuyenNoiBo);
            //nếu duyệt sẽ không cho sửa ngày chứng từ
            if (_nghiepVuDieuChuyenNoiBo.TinhTrang == 1 )
            {
                this.dteNgayChungTu.Properties.ReadOnly = true;
            }
            // Đưa dữ liệu vào bindingsource
            GanBindingSource();
            xtraTabControl1.SelectedTabPageIndex = 1;         
        }

        private void GanBindingSource()
        {
            tblBoPhanERPNewBindingSource.DataSource = _viTriList;
            tblBoPhanBindingSource.DataSource = _boPhanList;
            //
            if (_tscdList != null)
                tblDanhMucTSCDBindingSource.DataSource = _tscdList;
            //
            tblNghiepVuDieuChuyenNoiBoBindingSource.DataSource = _nghiepVuDieuChuyenNoiBo;
            //
            tblCTNghiepVuDieuChuyenNoiBoBindingSource.DataSource = _nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo;
            //
            tblBoPhanERPNew_LichSuDC_BindingSource.DataSource = _boPhan_LichSuDCList;
            // Gán vào BindingSource
            tblnsNhanVienGiaoBindingSource.DataSource = _nhanVienGiaoList;
            tblnsNhanVienNhanBindingSource.DataSource = _nhanVienTiepNhanList;
        }

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }

        private void RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim()
        {
            #region old
            //foreach (tblCT_NghiepVuDieuChuyenNoiBo itemCT_NghiepVuDieuChuyenNoiBo in _nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo)
            //{
            //    tblTaiSanCoDinhCaBiet TSCDCaBietRemoveRaKhoiDanhSachTim = null;
            //    foreach (tblTaiSanCoDinhCaBiet taiSanCaBiet in _taiSanCoDinhCaBietList_TimDuyet)
            //    {
            //        if (taiSanCaBiet.MaTSCDCaBiet == itemCT_NghiepVuDieuChuyenNoiBo.MaTSCDCaBiet)
            //        {
            //            TSCDCaBietRemoveRaKhoiDanhSachTim = taiSanCaBiet;
            //            break;
            //        }
            //    }
            //    if (TSCDCaBietRemoveRaKhoiDanhSachTim != null)
            //    {
            //        tblTaiSanCoDinhCaBietBindingSource_TimDuyet.Remove(TSCDCaBietRemoveRaKhoiDanhSachTim);
            //    }
            //}
            #endregion end old
            foreach (tblCT_NghiepVuDieuChuyenNoiBo itemCT_NghiepVuDieuChuyenNoiBo in _nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo)
            {
                for (int i = 0; i < grdViewTSCDCaBiet_DaDuyet.RowCount; i++)
                {
                    if (itemCT_NghiepVuDieuChuyenNoiBo.MaTSCDCaBiet == int.Parse(grdViewTSCDCaBiet_DaDuyet.GetRowCellValue(i, "MaTSCDCaBiet").ToString()))
                    {
                        grdViewTSCDCaBiet_DaDuyet.DeleteRow(i);
                    }
                }
            }
        }

        private bool DuocPhepLuu()
        {
            bool returnValue = true;
            if (_nghiepVuDieuChuyenNoiBo == null)
            {
                DialogUtil.ShowWarning("Vui lòng thêm dữ liệu.");
                return false;
            }
            //KIỂM TRA KHÓA SỔ
            if (Ky_Factory.New().DaKhoaSoTSCD(_nghiepVuDieuChuyenNoiBo.NgayChungTu, _user.MaCongTy))
            {
                DialogUtil.ShowDaKhoaSoTSCD(_nghiepVuDieuChuyenNoiBo.NgayChungTu);
                return false;
            }
            //kiểm tra trùng số chứng từ
            if (_nghiepVuDieuChuyenNoiBo_Factory.KiemTraTrungSoChungTu(_nghiepVuDieuChuyenNoiBo) == true)
            {
                txtSoChungTu.Focus();
                DialogResult dlgResult = DialogUtil.ShowYesNo("Trùng số chứng từ. Tự động phát sinh số chứng từ mới");
                if (dlgResult == DialogResult.Yes)
                {
                    _nghiepVuDieuChuyenNoiBo.SoChungTu = _nghiepVuDieuChuyenNoiBo_Factory.Get_NextSoChungTu_ByYear_And_Month
                        (_nghiepVuDieuChuyenNoiBo.NgayChungTu.Year, _nghiepVuDieuChuyenNoiBo.NgayChungTu.Month, _user.UserID);
                    //đệ quy
                    return DuocPhepLuu();
                }
                else
                    return false;
            }
            if (radioDuyet.SelectedIndex > -1)
            {
                if ((Int32)radioDuyet.EditValue == 0 && String.IsNullOrEmpty(textEdit_LyDo.Text))
                {
                    DialogUtil.ShowWarning("Vui lòng nhập lý do không duyệt!\nLý do không duyệt không được bỏ trống!");
                    textEdit_LyDo.Focus();
                    return false;
                }
                if((Int32)radioDuyet.EditValue == 1 && ChungTu_HoSoFileLuuTruList.GetChungTu_HoSoFileLuuTruList(_nghiepVuDieuChuyenNoiBo.MaNghiepVuDieuChuyenNoiBo, 13).Count==0)
                {
                    DialogUtil.ShowWarning("Chứng từ điều chuyển chưa có up file chứng từ!\nBạn có muốn duyệt?\nNếu không duyệt hãy đổi trạng thái không duyệt!\nYêu cầu cập nhật chứng từ liên quan!");              
                }
            }
            if (this._nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo.Count == 0)
            {
                DialogUtil.ShowWarning("Không thể lưu điều chuyển rỗng.");
                return false;
            }
            if (String.IsNullOrEmpty(_nghiepVuDieuChuyenNoiBo.SoChungTu))
            {
                DialogUtil.ShowWarning("Chưa nhập số chứng từ.");
                return false;
            }
            if (Convert.ToInt32(_nghiepVuDieuChuyenNoiBo.MaPhongBanNhan) == 0)
            {
                DialogUtil.ShowWarning("Chưa chọn bộ phận nhận.");
                return false;
            }
            if (Convert.ToInt32(_nghiepVuDieuChuyenNoiBo.MaPhongBanGiao) == 0)
            {
                DialogUtil.ShowWarning("Chưa chọn bộ phận giao.");
                return false;
            }
            #region chưa sử dụng
            //if (Convert.ToInt32(_nghiepVuDieuChuyenNoiBo.MaNhanVienBenGiao) == 0)
            //{
            //    DialogUtil.ShowWarning("Chưa chọn nhân viên giao.");
            //    return false;
            //}

            //if (Convert.ToInt32(_nghiepVuDieuChuyenNoiBo.MaNhanVienBenNhan) == 0)
            //{
            //    DialogUtil.ShowWarning("Chưa chọn nhân viên nhận.");
            //    return false;
            //}

            //if (_nghiepVuDieuChuyenNoiBo.MaPhongBanGiao == _nghiepVuDieuChuyenNoiBo.MaPhongBanNhan
            //    && Convert.ToInt32(_nghiepVuDieuChuyenNoiBo.MaPhongBanGiao) != 0
            //    && Convert.ToInt32(_nghiepVuDieuChuyenNoiBo.MaPhongBanNhan) != 0
            //    )
            //{
            //    DialogUtil.ShowWarning("Bộ phận nhận đang trùng bộ phận giao.");
            //    return false;
            //}
            #endregion
            return returnValue;
        }
        public static void SendEmail_DKAPP(string sArrToMail, string Email, string Pass, string ServerMail, int Port, string TieuDe_DangKy, string NoiDung_DangKy)
        {
            string[] sArrToMail_Arr = sArrToMail.Split(',');
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(Email);
                foreach (string EmailTo in sArrToMail_Arr)
                {
                    message.To.Add(new MailAddress(EmailTo));
                }
                message.Subject = TieuDe_DangKy;
                message.IsBodyHtml = true; //to make message body as html
                message.Body = NoiDung_DangKy;
                smtp.Port = Port == null ? 587 : int.Parse(Port.ToString()); //for gmail host
                smtp.Host = string.IsNullOrEmpty(ServerMail) ? "smtp.office365.com" : ServerMail; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(Email, Pass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex) { }
        }
        private bool Save()
        {
            this.ChangeFocus();
            try
            {
                //Kiểm tra dữ liệu trước khi lưu
                if (this.DuocPhepLuu() == true)
                {
                    string emailNhan = string.Empty, emailGui = string.Empty, matKhauEmailGui = string.Empty;
                    emailNhan = _user.EmailDenTang;
                    emailGui = _user.EmailGui;
                    matKhauEmailGui = _user.MatKhauEmailGui;
                    using (DialogUtil.WaitForSave(this))
                    {
                        tblnsNhanVienNhanBindingSource.EndEdit();
                        //Cập nhật lại mã phòng ban trong tài sản cá biệt phòng ban
                        foreach (tblCT_NghiepVuDieuChuyenNoiBo chiTiet in _nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo)
                        {
                            foreach (tblTaiSanCoDinhCaBiet_PhongBan taiSan in chiTiet.tblTaiSanCoDinhCaBiet_PhongBan)
                            {
                                taiSan.MaPhongBan = _nghiepVuDieuChuyenNoiBo.MaPhongBanNhan;
                                if (chiTiet.MaViTri != null)
                                    taiSan.MaViTri = chiTiet.MaViTri;
                                else
                                    taiSan.MaViTri = chiTiet.tblTaiSanCoDinhCaBiet.PhanBoSauCung_RefObj.MaViTri;
                            }
                        }
                        bool duyet = false;
                        if (radioDuyet.SelectedIndex > -1)
                        {
                            UserItem userLap = UserItem.GetUserItem(_nghiepVuDieuChuyenNoiBo.UserID.Value);
                            if ((Int32)radioDuyet.EditValue == 0)
                            {
                                duyet = false;
                                _nghiepVuDieuChuyenNoiBo.HoanTat = duyet;
                                if (_user.GroupID == 38)
                                {
                                    emailNhan = userLap.EmailHRM;
                                    SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Không Duyệt Chứng Từ {_nghiepVuDieuChuyenNoiBo.SoChungTu} ",
                                        "Chứng từ điều chuyển nội bộ TSCĐ hay CCDC có số:" + _nghiepVuDieuChuyenNoiBo.SoChungTu + " không được duyệt! Với lý do: " + _nghiepVuDieuChuyenNoiBo.LyDo);
                                }
                                else
                                {
                                    _nghiepVuDieuChuyenNoiBo.TinhTrang = null;
                                    SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đề Nghị Duyệt Chứng Từ {_nghiepVuDieuChuyenNoiBo.SoChungTu }",
                                        "Đề nghị duyệt chứng từ sửa chữa lớn TSCĐ hay CCDC có số:" + _nghiepVuDieuChuyenNoiBo.SoChungTu + " với nội dung:" + _nghiepVuDieuChuyenNoiBo.GhiChu);
                                }
                                foreach (tblCT_NghiepVuDieuChuyenNoiBo chiTietDieuChuyen in _nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo)
                                {
                                    chiTietDieuChuyen.tblTaiSanCoDinhCaBiet_PhongBan.Clear();                             
                                }
                            }
                            else
                            {
                                //tạo phân bổ phòng ban mới                      
                                foreach (tblCT_NghiepVuDieuChuyenNoiBo chiTietDieuChuyen in _nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo)
                                {
                                    tblTaiSanCoDinhCaBiet_PhongBan taiSanCDcaBiet_Phongban = new tblTaiSanCoDinhCaBiet_PhongBan();
                                    taiSanCDcaBiet_Phongban.MaTSCDCaBiet = chiTietDieuChuyen.MaTSCDCaBiet;
                                    taiSanCDcaBiet_Phongban.MaPhongBan = _nghiepVuDieuChuyenNoiBo.MaPhongBanNhan;
                                    taiSanCDcaBiet_Phongban.NgayPhanBo = _nghiepVuDieuChuyenNoiBo.NgayChungTu;
                                    taiSanCDcaBiet_Phongban.MaChiTietDieuChuyenNoiBo = chiTietDieuChuyen.MaChiTiet;
                                    taiSanCDcaBiet_Phongban.UserID = _user.UserID;
                                    taiSanCDcaBiet_Phongban.MaViTri = chiTietDieuChuyen.MaViTri;
                                    //
                                    chiTietDieuChuyen.tblTaiSanCoDinhCaBiet_PhongBan.Add(taiSanCDcaBiet_Phongban);
                                }
                                duyet = true;
                                _nghiepVuDieuChuyenNoiBo.UserIDNgDuyetCongTy = _user.UserID;
                                _nghiepVuDieuChuyenNoiBo.NgayDuyetCongTy = DateTime.Today.Date;
                                _nghiepVuDieuChuyenNoiBo.HoanTat = duyet;
                                SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đã Duyệt Chứng Từ {_nghiepVuDieuChuyenNoiBo.SoChungTu} ",
                                    "Chứng từ điều chuyển nội bộ TSCĐ hay CCDC có số:" + _nghiepVuDieuChuyenNoiBo.SoChungTu + " đã được duyệt!");
                            }
                        }
                        else
                        {
                            SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đề Nghị Duyệt Chứng Từ {_nghiepVuDieuChuyenNoiBo.SoChungTu }",
                                "Đề nghị duyệt chứng từ điều chuyển nội bộ TSCĐ hay CCDC có số:" + _nghiepVuDieuChuyenNoiBo.SoChungTu + " với nội dung:" + _nghiepVuDieuChuyenNoiBo.LyDoDieuChuyen);
                        }
                        // Lưu nghiệp vụ điều chuyển nội bộ
                        this._nghiepVuDieuChuyenNoiBo_Factory.SaveChangesWithoutTrackingLog();
                        //this._nghiepVuDieuChuyenNoiBo_Factory.SaveChanges(BusinessCodeEnum.TSCD_DieuChuyenNoiBo.ToString());
                    }
                    DialogUtil.ShowSaveSuccessful();
                    return true;
                }
            }
            catch (Exception ex)
            {
                DialogUtil.ShowNotSaveSuccessful();
            }
            return false;
        }
        #endregion
        //Event Method
        #region Event Method
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.ChangeFocus();
            if (treeListLookUpEdit_BoPhan_Tim.EditValue == "")
            {
                DialogUtil.ShowWarning("Chưa chọn bộ phận!\nVui lòng chọn bộ phận!");
                return;
            }
            Int32 maPhongBanDangChon = Convert.ToInt32(treeListLookUpEdit_BoPhan_Tim.EditValue);
            //cảnh báo người dùng nếu chưa chọn phòng ban
            if (maPhongBanDangChon == 0)
            {
                DialogUtil.ShowWarning("Chưa Chọn phòng ban!\nVui lòng chọn phòng ban!");
                return;
            }
            //lấy mã TSCD đang chọn trong điều kiện tìm
            Int32 maTSCDDangChon = Convert.ToInt32(cbTaiSanCD.EditValue);
            Int32 maViTri = Convert.ToInt32(treeListLookUpEdit_ViTri.EditValue);

            using (DialogUtil.Wait())
            {
                DataTable _dt_TaiSanCoDinhCaBiet = new DataTable();
                //_dt_TaiSanCoDinhCaBiet.Columns.Add("Chon", typeof(bool));
                _dt_TaiSanCoDinhCaBiet = dt_TaiSanCoDinhCaBiet(DateTime.Now.Date, maPhongBanDangChon, maViTri, maTSCDDangChon, _user.MaCongTy, 0, 13);
                grdControl_TaiSanCDCBCaBietDaDuyet.DataSource = _dt_TaiSanCoDinhCaBiet;
                if (grdViewTSCDCaBiet_DaDuyet.RowCount > 0 && tblCTNghiepVuDieuChuyenNoiBoBindingSource.Count > 0)
                {
                    //Xóa dòng ĐÃ được chọn trước khi đưa vào chứng từ 
                    RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
                }
            }
            if (grdViewTSCDCaBiet_DaDuyet.RowCount == 0)
            {
                DialogUtil.ShowOK("Không có dữ liệu!");
            }
            

        }
        
        // bổ sung 10/11/2020 
        public static DataTable dt_TaiSanCoDinhCaBiet(
                Nullable<System.DateTime> denNgay, Nullable<int> maBoPhan, Nullable<int> maViTri, Nullable<int> maLoai, Nullable<int> maCongTy,
                Nullable<int> loaiBaoCao, Nullable<int> loaiNghiepVu)
        {
            DataTable kq = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TSCD_DanhSachTaiSanCoDinhHayCCDCCoDenNgay_TheoPhongBanViTriLoaiTaiSan";
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan",maBoPhan);
                    cm.Parameters.AddWithValue("@MaViTri", maViTri);
                    cm.Parameters.AddWithValue("@MaLoai", maLoai);
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                    cm.Parameters.AddWithValue("@LoaiBaoCao", loaiBaoCao);
                    cm.Parameters.AddWithValue("@LoaiNghiepVu", loaiNghiepVu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(kq);
                }
            }
            return kq;
        }

        //// phân quyền
        public string strStatus = "KHOA";
        PhanQuyenSuDungForm _phanQuyen = null;
        private void frmDieuChuyenNoiBoTSCDCaBiet_Load(object sender, EventArgs e)
        {
            
             //Lấy dữ liệu
             _boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(_user.MaCongTy);       
            _boPhan_LichSuDCList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(_user.MaCongTy).ToList();
            tblnsBoPhan boPhan_ChonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất Cả>>", TenBoPhan = "Tất Cả" };
            _boPhan_LichSuDCList.Insert(0, boPhan_ChonTatCa);
            //Lấy bộ phận
            _viTriList = BoPhanERPNew_Factory.New().GetAll().ToList();
            tblBoPhanERPNew boPhan_vitri_chonTatCa = new tblBoPhanERPNew() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _viTriList.Insert(0, boPhan_vitri_chonTatCa);
            //Lấy danh sách nhân viên
            _nhanVienGiaoList = NhanVien_Factory.New().GetAll();
            _nhanVienTiepNhanList = _nhanVienGiaoList;
            //Lấy tài sản cá biệt phòng ban
            _tscdList = DanhMucTSCD_Factory.New().Get_DanhSachTaiSanCoDinh_CoTSCDCaBietChuaThanhLy().ToList();
            tblDanhMucTSCD tscd_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
            _tscdList.Insert(0, tscd_chonTatCa);

            _nghiepVuDieuChuyenNoiBo_Factory = NghiepVuDieuChuyenNoiBo_Factory.New();
            if (_xemLaiChungTuCu == true && _maNghiepVuDieuChuyenNoiBo != 0)
            {
                XemLaiChungTuCu(_maNghiepVuDieuChuyenNoiBo);
            }
            else
            {
                //tạo chứng từ mới
                _nghiepVuDieuChuyenNoiBo = _nghiepVuDieuChuyenNoiBo_Factory.CreateAloneObject();
                _nghiepVuDieuChuyenNoiBo.UserID = _user.UserID;
                dteNgayChungTu.EditValue = app_users_Factory.New().SystemDate;
            }

            //Đưa checkbox lên lưới
            GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewTSCDCaBiet_DaDuyet, colChon);
            // Set số thứ tự cho lưới
            GridUtil.SetSTTForGridView(grdViewTSCDCaBiet_DaDuyet,50);
            GridUtil.SetSTTForGridView(gridView_CTDieuChuyenNoiBo);
            GridUtil.SetSTTForGridView(gridView_LichSuDieuChuyen);

            //Set ngày
            //dteNgayChungTu.EditValue = DateTime.Now.Date;
            deTuNgay.EditValue = DateTime.Now.Date;
            deDenNgay.EditValue = DateTime.Now.Date;
            //cài đặt delete helper
            GridUtil.DeleteHelper.Setup_ManualType(gridView_CTDieuChuyenNoiBo, (GridView gridView, List<Object> deleteList) =>
            {
                //xóa chi tiết nghiệp vụ điều chuyển nội bộ
                CT_NghiepVuDieuChuyenNoiBo_Factory.FullDeleteCT_NghiepVuDieuChuyenNoiBo(context: _nghiepVuDieuChuyenNoiBo_Factory.Context, deleteList: deleteList);
            });
            //
            this.GanBindingSource();

            if (_user.TenDangNhap.ToLower().Equals("admin") || _user.GroupID == 38)
            {     
                radioDuyet.Enabled = true;
                textEdit_LyDo.Enabled = true;
                btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {           
                if (_nghiepVuDieuChuyenNoiBo.TinhTrang == 1)
                    ReadOnlyConTrolByStatus();
            }
            // phân quyền 
            PhanQuyenThemSuaXoa();
        }
        private void PhanQuyenThemSuaXoa()
        {
            _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            if (_phanQuyen.Them == true || _phanQuyen.Sua == true)
            {
                btnLuu.Enabled = true;
            }
            else
                btnLuu.Enabled = false;
            btnXoa.Enabled = _phanQuyen.Xoa;
        }
        private void ReadOnlyConTrolByStatus()
        {
            grdViewTSCDCaBiet_DaDuyet.OptionsBehavior.ReadOnly = true;
            gridView_CTDieuChuyenNoiBo.OptionsBehavior.ReadOnly = true;
            foreach (Control c in groupControl2.Controls)
            {
                if (c is MemoEdit)
                {
                    ((MemoEdit)c).Properties.ReadOnly = true;
                }
                else if (c is TextEdit)
                {
                    ((TextEdit)c).Properties.ReadOnly = true;
                }
                else if (c is DateEdit)
                {
                    ((DateEdit)c).Properties.ReadOnly = true;
                }
                else if (c is GridLookUpEdit)
                {
                    ((GridLookUpEdit)c).Properties.ReadOnly = true;
                }
                else if (c is TreeListLookUpEdit)
                {
                    ((TreeListLookUpEdit)c).Properties.ReadOnly = true;
                }
                else if (c is RadioGroup)
                {
                    ((RadioGroup)c).Properties.ReadOnly = true;
                }

            }
            btnDuaTSVaoChungTu.Enabled = false;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }
        private void btnDuaTSVaoChungTu_Click(object sender, EventArgs e)
        {
            #region old
            //this.ChangeFocus();
            //if (_taiSanCoDinhCaBietList_TimDuyet != null && _taiSanCoDinhCaBietList_TimDuyet.Count > 0)
            //{
            //    Boolean coTaiSanCaBietDuocChonTuDanhSach = false;
            //    //lặp qua từng dòng tài sản tìm được
            //    foreach (tblTaiSanCoDinhCaBiet taiSanCaBiet in _taiSanCoDinhCaBietList_TimDuyet)
            //    {
            //        //nếu tài sản được chọn
            //        if (taiSanCaBiet.Chon == true)
            //        {
            //            coTaiSanCaBietDuocChonTuDanhSach = true;
            //            //khởi tạo chi tiết nghiệp vụ điều chuyển nội bộ 
            //            tblCT_NghiepVuDieuChuyenNoiBo chiTietNghiepVuDieuChuyenNoiBo = CT_NghiepVuDieuChuyenNoiBo_Factory.New().CreateAloneObject();
            //            chiTietNghiepVuDieuChuyenNoiBo.MaTSCDCaBiet = taiSanCaBiet.MaTSCDCaBiet;
            //            //copy ly do dieu chuyen
            //            chiTietNghiepVuDieuChuyenNoiBo.LyDoDieuChuyen = _nghiepVuDieuChuyenNoiBo.LyDoDieuChuyen;
            //            chiTietNghiepVuDieuChuyenNoiBo.MaViTri = taiSanCaBiet.PhanBoSauCung_RefObj.MaViTri;
            //            // Lấy mã chờ duyệt tài sản cố định 
            //            //chiTietNghiepVuDieuChuyenNoiBo.MaChoDuyetTSCD = taiSanCaBiet.MaChoDuyet;

            //            //Đưa vao danh sach chi tiết điều chuyển nội bộ
            //            _nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo.Add(chiTietNghiepVuDieuChuyenNoiBo);
            //        }
            //    }

            //    //thông báo người dùng nếu chưa chọn bất cứ dòng nào từ danh sách duyệt
            //    if (coTaiSanCaBietDuocChonTuDanhSach == false)
            //    {
            //        DialogUtil.ShowWarning("Chưa chọn dữ liệu.");
            //        return;
            //    }
            //    // Xóa duyệt tài sản cố định cá biệt vừa chọn ra khỏi danh sách tìm
            //    RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
            //}
            #endregion old
            try
            {
                Boolean coTaiSanCaBietDuocChonTuDanhSach = false;
                using (DialogUtil.Wait())
                {
                    this.ChangeFocus();
                    if (grdViewTSCDCaBiet_DaDuyet.RowCount > 0)
                    {
                         for (int i = 0; i < grdViewTSCDCaBiet_DaDuyet.RowCount; i++)
                        {
                            DataRow dr = grdViewTSCDCaBiet_DaDuyet.GetDataRow(i);
                            if (dr != null)
                            {
                                if (bool.Parse(dr["Chon"].ToString()) == true)
                                {
                                    coTaiSanCaBietDuocChonTuDanhSach = true;
                                    //khởi tạo chi tiết nghiệp vụ điều chuyển nội bộ
                                    tblCT_NghiepVuDieuChuyenNoiBo chiTietNghiepVuDieuChuyenNoiBo = CT_NghiepVuDieuChuyenNoiBo_Factory.New().CreateAloneObject();
                                    chiTietNghiepVuDieuChuyenNoiBo.MaTSCDCaBiet = Convert.ToInt32(dr["MaTSCDCaBiet"].ToString());
                                    //copy ly do dieu chuyen
                                    chiTietNghiepVuDieuChuyenNoiBo.LyDoDieuChuyen = _nghiepVuDieuChuyenNoiBo.LyDoDieuChuyen;
                                    chiTietNghiepVuDieuChuyenNoiBo.MaViTri = Convert.ToInt32(dr["MaViTri"].ToString());
                                    //Đưa vao danh sach chi tiết điều chuyển nội bộ
                                    _nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo.Add(chiTietNghiepVuDieuChuyenNoiBo);
                                }
                            }
                        }
                        //Xóa duyệt tài sản cố định cá biệt vừa chọn ra khỏi danh sách tìm
                        RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
                        xtraTabControl1.SelectedTabPage = tabChungTu;
                    }
                }
                //thông báo người dùng nếu chưa chọn bất cứ dòng nào từ danh sách duyệt
                if (coTaiSanCaBietDuocChonTuDanhSach == false) { DialogUtil.ShowWarning("Chưa chọn dữ liệu."); return; }
            } catch (Exception ex)
            { XtraMessageBox.Show("<color=red>- Lỗi: </color>" + ex.ToString(), "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error,DevExpress.Utils.DefaultBoolean.True); }
        }
        private void cbPhongBan_EditValueChanged(object sender, EventArgs e)
        {
            int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);       
            if (maPhongBan != 0)
            {
                if (_nghiepVuDieuChuyenNoiBo == null || _nghiepVuDieuChuyenNoiBo.MaPhongBanGiao != maPhongBan)
                {
                    _nghiepVuDieuChuyenNoiBo_Factory = NghiepVuDieuChuyenNoiBo_Factory.New();
                    //khởi tạo nghiệp vụ điều chuyển nội bộ
                    _nghiepVuDieuChuyenNoiBo = _nghiepVuDieuChuyenNoiBo_Factory.NewChungTu(maPhongBan, _nghiepVuDieuChuyenNoiBo.NgayChungTu);
                }
            }
            GanBindingSource();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBlackHole.Focus();
            if (_nghiepVuDieuChuyenNoiBo == null)
            {
                DialogUtil.ShowWarning("Chứng từ rỗng.");
                return;
            }
            //
            if (Ky_Factory.New().DaKhoaSoTSCD(_nghiepVuDieuChuyenNoiBo.NgayChungTu, _user.MaCongTy))
            {
                DialogUtil.ShowDaKhoaSoTSCD(_nghiepVuDieuChuyenNoiBo.NgayChungTu);
            }
            else 
            {
               
                if (_nghiepVuDieuChuyenNoiBo.UserID == _user.UserID && DialogResult.Yes == DialogUtil.ShowYesNo(String.Format("Bạn muốn xóa chứng từ [{0}]?", this.Text)))
                {
                    try
                    {
                        using (DialogUtil.WaitForDelete(this))
                        {
                            //Xóa nghiệp vụ điều chuyển nội bộ
                            _nghiepVuDieuChuyenNoiBo_Factory.FullDeleteNghiepVu(_nghiepVuDieuChuyenNoiBo);
                            _nghiepVuDieuChuyenNoiBo_Factory.SaveChangesWithoutTrackingLog();
                        }
                        DialogUtil.ShowDeleteSuccessful();

                        // Cài đặt lại dữ liệu
                        _nghiepVuDieuChuyenNoiBo_Factory = NghiepVuDieuChuyenNoiBo_Factory.New();
                        _nghiepVuDieuChuyenNoiBo = _nghiepVuDieuChuyenNoiBo_Factory.CreateAloneObject();
                        tblNghiepVuDieuChuyenNoiBoBindingSource.Clear();
                    }
                    catch (Exception ex)
                    {
                        DialogUtil.ShowNotDeleteSuccessful(ex.Message);
                    }
                }
                else
                {
                    DialogUtil.ShowWarning("Bạn không thể xóa Chứng Từ của người khác !");
                }
            }
        }

       
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save();
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void dteNgayChungTu_EditValueChanged(object sender, EventArgs e)
        {
            DateTime ngayChungTu = dteNgayChungTu.DateTime.Date;
            if (ngayChungTu != new DateTime(1, 1, 1) && dteNgayChungTu.DateTime.Date != _nghiepVuDieuChuyenNoiBo.NgayChungTu)
            {

                _nghiepVuDieuChuyenNoiBo.NgayChungTu = ngayChungTu;
                if(_nghiepVuDieuChuyenNoiBo.MaNghiepVuDieuChuyenNoiBo == 0)
                {
                    //Phát sinh mã
                    _nghiepVuDieuChuyenNoiBo.SoChungTu = NghiepVuDieuChuyenNoiBo_Factory.New().Get_NextSoChungTu_ByYear_And_Month(_nghiepVuDieuChuyenNoiBo.NgayChungTu.Year, _nghiepVuDieuChuyenNoiBo.NgayChungTu.Month, _user.UserID);
                }
              
                foreach (var item in _nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo)
                {
                    tblTaiSanCoDinhCaBiet_PhongBan phanBo = item.tblTaiSanCoDinhCaBiet_PhongBan.FirstOrDefault();
                    if(phanBo!= null)
                        phanBo.NgayPhanBo = _nghiepVuDieuChuyenNoiBo.NgayChungTu;//ngayChungTu; 
                }
            }
        }
        private void btnDanhSachChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachDieuChuyenNoiBoTSCDCaBiet.ShowSingleton(null, this.MdiParent);
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void splitContainerControl1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
        private void btnTimLichSuDC_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = Convert.ToDateTime(deTuNgay.EditValue);
            DateTime denNgay = Convert.ToDateTime(deDenNgay.EditValue);

            int maPhongBanGiao = Convert.ToInt32(cbPhongBanGiao_LichSuDC.EditValue);
            int maPhongBanNhan = Convert.ToInt32(cbPhongBanNhan_LichSuDC.EditValue);

            _chiTietNghiepVuDieuChuyenNoiBoList = CT_NghiepVuDieuChuyenNoiBo_Factory.New().
                Get_CT_NghiepVuDieuChuyenNoiBo_ByTuNgayAndDenNgayAndMaPhongBanGiaoAndMaPhongBanNhan_PhucVuLichSuDieuChuyenNoiBo(maPhongBanGiao, maPhongBanNhan, tuNgay, denNgay);
            tblCTNghiepVuDieuChuyenNoiBo_LichSuDC_BindingSource.DataSource = _chiTietNghiepVuDieuChuyenNoiBoList;
        }
        private void btnInLichSuDC_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = Convert.ToDateTime(deTuNgay.EditValue);
            DateTime denNgay = Convert.ToDateTime(deDenNgay.EditValue);

            int maPhongBanGiao = Convert.ToInt32(cbPhongBanGiao_LichSuDC.EditValue);
            int maPhongBanNhan = Convert.ToInt32(cbPhongBanNhan_LichSuDC.EditValue);
            int maTaiSanCoDinhCaBiet = 0;

            if (check_TatCa.Checked == false)
            {
                //Lấy tài sản cố định hiện tại trên lưới
                tblCT_NghiepVuDieuChuyenNoiBo chiTietNghiepVuDieuChuyenNoiBo = tblCTNghiepVuDieuChuyenNoiBo_LichSuDC_BindingSource.Current as tblCT_NghiepVuDieuChuyenNoiBo;

                if (chiTietNghiepVuDieuChuyenNoiBo != null)
                { maTaiSanCoDinhCaBiet = chiTietNghiepVuDieuChuyenNoiBo.MaTSCDCaBiet.Value; }
            }

            ReportHelper.ShowReport("BangTongHopLichDieuChuyenNoiBo", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(PSC_ERP_Business.Main.Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BangTongHopLichDieuChuyenNoiBo", "@MaPhongBanGiao,@MaPhongBanNhan,@TuNgay,@DenNgay,@MaTaiSanCoDinhCaBiet", maPhongBanGiao, maPhongBanNhan, tuNgay, denNgay, maTaiSanCoDinhCaBiet);
                #region Extend table
                //Tao Bang Ngay Lap
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("NgayLap", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["NgayLap"] = DateTime.Now.Date;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "SubInfo";
                dataSet.Tables.Add(dtngay);
                #endregion
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }
        private void frmDieuChuyenNoiBoTSCDCaBiet_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_nghiepVuDieuChuyenNoiBo_Factory.IsDirty)
            {
                DialogResult dlgResult = DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
                if (DialogResult.Yes == dlgResult)
                {
                    if (false == this.Save())
                        e.Cancel = true;
                }
                else if (DialogResult.No == dlgResult)
                {
                    //không làm gì cả
                }
                else if (DialogResult.Cancel == dlgResult)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_DieuChuyenNoiBo, this.MdiParent);
        }
        #endregion

        private void treeListLookUpEdit_BoPhan_Tim_EditValueChanged(object sender, EventArgs e)
        {
            int maPhongBan = Convert.ToInt32(treeListLookUpEdit_BoPhan_Tim.EditValue);
            //lấy danh sách tên tài sản
            {
                _tscdList = DanhMucTSCD_Factory.New().Get_DanhSachTaiSanCoDinh_NamTrongDanhSachDangDuyetTSCD_ByMaPhongBan_AndLoaiNghiepVu(maPhongBan, LoaiNghiepVuTaiSanEnum.DieuChuyenNoiBo).ToList();
                tblDanhMucTSCD tscd_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
                _tscdList.Insert(0, tscd_chonTatCa);
            }
            if (maPhongBan != 0)
            {
                if (_nghiepVuDieuChuyenNoiBo == null || _nghiepVuDieuChuyenNoiBo.MaPhongBanGiao != maPhongBan)
                {
                    _nghiepVuDieuChuyenNoiBo_Factory = NghiepVuDieuChuyenNoiBo_Factory.New();
                    //khởi tạo nghiệp vụ điều chuyển nội bộ
                    _nghiepVuDieuChuyenNoiBo = _nghiepVuDieuChuyenNoiBo_Factory.NewChungTu(maPhongBan, _nghiepVuDieuChuyenNoiBo.NgayChungTu);
                }
            }
            GanBindingSource();
        }

        private void btn_InBienBanBanGiao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("NghiepVuDieuChuyenNoiBo_BienBanGiaoNhanTSCD", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(PSC_ERP_Business.Main.Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BienBanGiaoNhanTSCD_DCNB", "@MaNghiepVuDieuChuyenNoiBo", _nghiepVuDieuChuyenNoiBo.MaNghiepVuDieuChuyenNoiBo);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }

        private void btn_InBienBanDieuChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("NghiepVuDieuChuyenNoiBo_BienBanChuyenDichTSCD", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(PSC_ERP_Business.Main.Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BienBanGiaoNhanTSCD_DCNB", "@MaNghiepVuDieuChuyenNoiBo", _nghiepVuDieuChuyenNoiBo.MaNghiepVuDieuChuyenNoiBo);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }

        private void btn_UpFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_nghiepVuDieuChuyenNoiBo.MaNghiepVuDieuChuyenNoiBo == 0)
            {
                DialogUtil.ShowInfo("Vui lòng lưu chứng từ trước khi up file!");
                return;
            }
            else
            {                                                                       //13 là Mã loại chứng từ có trong tblLoaiChungTu
                frmNTSD_ChonFilesUpLoad frm_upFile = new frmNTSD_ChonFilesUpLoad(_nghiepVuDieuChuyenNoiBo.MaNghiepVuDieuChuyenNoiBo,13); 
                frm_upFile.ShowDialog();
            }
        }

       
        private void cbNhanVienGiao_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            txtTenNhanVienBenGiao.EditValue = cbNhanVienGiao.Properties.View.FocusedValue;
        }

        private void cbNhanVienTiepNhan_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            txtTenNhanVienBenNhan.EditValue = cbNhanVienTiepNhan.Properties.View.FocusedValue;
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Convert.ToInt32(_nghiepVuDieuChuyenNoiBo.MaPhongBanGiao) < 0)
            {
                DialogUtil.ShowWarning("Chưa chọn bộ phận giao.");
                xtraTabControl1.SelectedTabPageIndex = 0;
                return ;
            }
            else xtraTabControl1.SelectedTabPageIndex = 1;

            if (_xemLaiChungTuCu == false)
                ImportTSCDCaBiet(_nghiepVuDieuChuyenNoiBo_Factory, _nghiepVuDieuChuyenNoiBo);
            tblCTNghiepVuDieuChuyenNoiBoBindingSource.ResetBindings(true);
        }
        public static void ImportTSCDCaBiet(NghiepVuDieuChuyenNoiBo_Factory _nghiepVuDieuChuyenNoiBo_Factory
                                             ,tblNghiepVuDieuChuyenNoiBo _nghiepVuDieuChuyenNoiBo)
        {
            //CT_NghiepVuDieuChuyenNoiBo_Factory cT_NghiepVuDieuChuyenNoiBo_Factory = CT_NghiepVuDieuChuyenNoiBo_Factory.New();
            OpenFileDialog oFD = new OpenFileDialog() { Filter = "Excel files (*.xls, *.xlsx)|*.xls;*.xlsx" };

            var mainLog = new System.Text.StringBuilder();
            if (oFD.ShowDialog() == DialogResult.OK)
            {
              try
              {
                using (WaitDialogForm wait = new WaitDialogForm("Đang import dữ liệu từ file excel...", "Vui lòng chờ"))
                {
                  
                    string tenSheeet = "[DieuChuyenNoiBo_Import$A1:L]";

                    using (DataTable dt = ImportTSCD.GetDataTable(oFD.FileName, tenSheeet))
                    {
                        #region thông tin tài sản cố định
                        const int sttIdx = 0;
                        const int soHieuIdx = 1;
                        const int tenTaiSanIdx = 2;
                        const int nguyenGiaIdx = 3;
                        const int maViTriIdx = 4;
                        const int tenViTriIdx = 5;
                        const int maViTriMoiIdx = 6;
                        const int tenViTriMoiIdx = 7;
                        const int modelIdx = 8;
                        const int serialIdx = 9;
                        const int chungLoaiIdx = 10;
                        const int lyDoDieuChuyenIdx = 11;
                        #endregion

                        foreach (DataRow dr in dt.Rows)
                        {
                            var errorLog = new System.Text.StringBuilder();
                            
                            #region khởi tạo các cột
                            //số thứ tự 0
                            String soTT = dr[sttIdx].ToString().FullTrim(); //0// dr[sttIdx].ToString().FullTrim(); //0
                            String soHieuTSCDCB = dr[soHieuIdx].ToString().FullTrim();//1                      
                            String tenTaiSan = dr[tenTaiSanIdx].ToString().FullTrim(); //2
                            String nguyenGia = dr[nguyenGiaIdx].ToString().FullTrim(); //3
                            String maViTri = dr[maViTriIdx].ToString().FullTrim(); //4
                            String tenViTri = dr[tenViTriIdx].ToString().FullTrim(); //5
                            String maViTriMoi = dr[maViTriMoiIdx].ToString().FullTrim(); //6
                            String tenViTriMoi = dr[tenViTriMoiIdx].ToString().FullTrim(); //7
                            String model = dr[modelIdx].ToString().FullTrim(); //8
                            String serial = dr[serialIdx].ToString().FullTrim(); //9
                            String chungLoai = dr[chungLoaiIdx].ToString().FullTrim(); //10
                            String lyDoDieuChuyen = dr[lyDoDieuChuyenIdx].ToString().FullTrim(); //11

                            #endregion
                            #region validate excel
                            if (String.IsNullOrEmpty(soHieuTSCDCB))
                                errorLog.AppendLine(" Không có số hiệu tài sản.");
                            if (String.IsNullOrEmpty(tenTaiSan))
                                errorLog.AppendLine(" Không có tên tài sản.");
                            if (String.IsNullOrEmpty(maViTri))
                                errorLog.AppendLine(" Không có mã vị trí hiện tại.");
                            if (String.IsNullOrEmpty(tenViTri))
                                errorLog.AppendLine(" Không có tên vị trí hiện tại.");
                            if (String.IsNullOrEmpty(maViTriMoi))
                                errorLog.AppendLine(" Không có mã vị trí mới.");
                            if (String.IsNullOrEmpty(tenViTriMoi))
                                errorLog.AppendLine(" Không có tên vị trí mới.");

                            #endregion

                            if (!String.IsNullOrEmpty(soHieuTSCDCB) && !String.IsNullOrEmpty(maViTri) && !String.IsNullOrEmpty(maViTriMoi))
                            {
                                #region  Entity_Factory.GetObjectByMultiKey(entityKeyValues)
                                //IEnumerable<KeyValuePair<string, object>> entityKeyValues = new KeyValuePair<string, object>[]
                                //                                    {
                                //                                        new KeyValuePair<string, object>("SoHieu", soHieuTSCDCB),
                                //                                        new KeyValuePair<string, object>("MaCongTy",CurrentUser.Info.MaCongTy)
                                //                                        //,new KeyValuePair<string, object>("MaViTri",maViTri)
                                //                                    };
                                //// 
                                #endregion

                                tblCT_NghiepVuDieuChuyenNoiBo ct_DieuChuyen_FromExcel = new tblCT_NghiepVuDieuChuyenNoiBo();
     
                                var _tsCDCB = _nghiepVuDieuChuyenNoiBo_Factory.Context.tblTaiSanCoDinhCaBiets
                                                                         .Where( o => o.SoHieu == soHieuTSCDCB 
                                                                                 && o.MaCongTy == ERP_Library.Security.CurrentUser.Info.MaCongTy
                                                                               ).Single();
   
                                int _maViTriMoi = _nghiepVuDieuChuyenNoiBo_Factory.Context.tblBoPhanERPNews
                                                                        .Where(o => o.MaBoPhanQL == maViTriMoi).Select(o => o.MaBoPhan)
                                                                        .Single();

                                ct_DieuChuyen_FromExcel.MaTSCDCaBiet = Convert.ToInt32(_tsCDCB.MaTSCDCaBiet);
                                ct_DieuChuyen_FromExcel.LyDoDieuChuyen = lyDoDieuChuyen;
                                ct_DieuChuyen_FromExcel.MaViTri = Convert.ToInt32(_maViTriMoi);
                                ct_DieuChuyen_FromExcel.tblTaiSanCoDinhCaBiet = _tsCDCB;

                                 _nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo.Add(ct_DieuChuyen_FromExcel); 

                            }
                            
                            //kiểm tra xem tài sản nào không import vào phần mềm
                            if (errorLog.Length > 0)
                            {
                                mainLog.AppendLine($"- STT: {soTT}");
                                mainLog.AppendLine(string.Format($"- Tài sản {soHieuTSCDCB} - {tenTaiSan} không import được vào phần mềm"));
                                mainLog.AppendLine(errorLog.ToString());
                            }
                        }//end for
                    }
                    DialogUtil.ShowInfo("Đã Import xong!");
                } //end using dialog waiting
               }
               catch (Exception ex)
               {
                  XtraMessageBox.Show(String.Format($"Lỗi <color=red>\"{ex.ToString()}\"</color>  !"), "Thông Báo ",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error, DevExpress.Utils.DefaultBoolean.True);
               }
            }  //end if open file
            //ghi lại thông tin lỗi khi import tài sản
            if (mainLog.Length > 0)
            {
                string tenFile = DateTime.Now.ToLongDateString() + "Import_DieuChuyenNoiBo_Log.txt";
                StreamWriter writer = new StreamWriter(tenFile);
                writer.WriteLine(mainLog.ToString());
                writer.Flush();
                writer.Close();
                writer.Dispose();
                //mở file log
                System.Diagnostics.Process.Start(tenFile);
            }
            
        }

        private void btnExportMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.AddExtension = true;
                dlg.Filter = "Excel|*.xls|All file|*.*";
                dlg.FileName = "Template_Import_DieuChuyenNoiBo";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //tạo file template
                    FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    
                    fs.Write(PSC_ERP.Properties.Resources.Template_Import_DieuChuyenNoiBo, 0, PSC_ERP.Properties.Resources.Template_Import_DieuChuyenNoiBo.Length);
                    fs.Close();

                    MessageBox.Show("Đã xuất dữ liệu thành công.", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Export không thành công!\n" + ex.Message);

            }
        }
    }
}
