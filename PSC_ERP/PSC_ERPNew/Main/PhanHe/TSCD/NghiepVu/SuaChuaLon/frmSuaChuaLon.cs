using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using PSC_ERPNew.Main.PhanHe.TSCD.UsefulDialog;
using PSC_ERPNew.Main.Reports;
using System.Data;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
using System.Net;
using ERP_Library.Security;
using System.Net.Mail;
using PSC_ERP;
using System.Data.SqlClient;
using ERP_Library;

namespace PSC_ERPNew.Main
{
    public partial class frmSuaChuaLon : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmSuaChuaLon singleton_ = null;
        public static frmSuaChuaLon Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmSuaChuaLon();
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
        List<tblDanhMucTSCD> _tscdList = null;
        List<tblBoPhanERPNew> _viTriList = null;
        List<tblnsBoPhan> _boPhanList = null;
        // ///////////
        ChungTuSuaChuaLonTaiSan_DerivedFactory _factory = null;

        tblChungTu _chungTu = null;
        tblNghiepVuSuaChuaLon _nghiepVuSuaChuaLon = null;

        IQueryable<tblTaiKhoan> _taiKhoanNoList = null;
        IQueryable<tblTaiKhoan> _taiKhoanCoList = null;
        IQueryable<tblDoiTac> _doiTacList = null;
        IQueryable<tblNguon> _nguonList;
        List<tblHopDong> _hopDongList = null;
        // /////////////
        Boolean _daLoadXong = false;
        Boolean _taoMoiChungTu = true;
        long _maChungTuCuCanXemLai = 0;
        tblChungTu _objFromAnotherFactory = null;
        DateTime? _ngayBanDau = DateTime.MinValue;
        int _maCongTy = CurrentUser.Info.MaCongTy;
        List<tblTaiSanCoDinhCaBiet> _taiSanCoDinhCaBietList_TimDuyet = null;
        // UserItem _user = UserItem.GetUserItem(CurrentUser.Info.UserID);
        UserInfo _user = ERP_Library.Security.CurrentUser.Info;

        #endregion

        //Member Constructor
        #region Member Constructor
        public frmSuaChuaLon()
        {
            InitializeComponent();
        }
        public frmSuaChuaLon(tblChungTu chungTu)//(long maChungTuGhiTang)
        {
            InitializeComponent();
            _taoMoiChungTu = false;
            _objFromAnotherFactory = chungTu;
            _maChungTuCuCanXemLai = chungTu.MaChungTu;

        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private void XoaDanhSachChungTu_HopDong(List<Object> deleteList)
        {
            //xóa chứng từ hợp đồng
            ChungTu_HopDong_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
            //
            LayDanhSachHopDongCuaChungTu();
            //tính lại tổng tiền chứng từ
            this.CapNhatLaiTongTien();
        }
        private void XoaDanhSachChungTu_HoaDonTaiSan(List<Object> deleteList)
        {
            //xóa chứng từ hoa don tai san
            ChungTu_HoaDonTaiSan_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
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
            txtBlackHole.Focus();
            string emailNhan = string.Empty, emailGui = string.Empty, matKhauEmailGui = string.Empty;
            emailNhan = _user.EmailDenTang;
            emailGui = _user.EmailGui;
            matKhauEmailGui = _user.MatKhauEmailGui;
            //kiểm tra chứng từ trước khi lưu
            if (DuocPhepLuu())
                try
                {
                    using (DialogUtil.WaitForSave(this))
                    {
                        bool duyet = false;
                        if (radioDuyet.SelectedIndex > -1)
                        {
                            UserItem userLap = UserItem.GetUserItem(_chungTu.MaNguoiLap.Value);

                            if ((Int32)radioDuyet.EditValue == 0)//không duyệt
                            {
                                duyet = false;
                                _chungTu.HoanTat = duyet;
                                if (_user.GroupID == 38)//duyệt của kế toán lưu
                                {
                                    emailNhan = userLap.EmailHRM;
                                    SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Không Duyệt Chứng Từ {_chungTu.MaChungTuQL}", "Chứng từ sửa chữa lớn TSCĐ hay CCDC có mã quản lý: " + _chungTu.MaChungTuQL + " không được duyệt! Với lý do: " + _chungTu.LyDo);
                                }
                                else//không phải kế toán
                                {
                                    _chungTu.TrangThai = null;//trả lại trạng thái chờ duyệt
                                    SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đề Nghị Duyệt Chứng Từ {_chungTu.MaChungTuQL}", "Đề nghị duyệt chứng từ sửa chữa lớn TSCĐ hay CCDC có mã quản lý: " + _chungTu.MaChungTuQL + " với nội dung:" + _chungTu.DienGiai);
                                }
                                //xử lý nghiệp vụ
                                foreach (tblCT_NghiepVuSuaChuaLon ct in _nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon)
                                {
                                    ct.tblTaiSanCoDinhCaBiet.ThoiGianSuDung = ct.ThoiGianSuDungCu;
                                    ct.tblTaiSanCoDinhCaBiet.NguyenGiaTinhKhauHao = ct.NguyenGiaTruocSuaChua;
                                }
                            }
                            else//duyệt
                            {
                                duyet = true;
                                _chungTu.HoanTat = duyet;
                                _chungTu.UserIDNgDuyetCongTy = _user.UserID;
                                _chungTu.NgayDuyetCongTy = DateTime.Today.Date;
                                SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đã Duyệt Chứng Từ {_chungTu.MaChungTuQL}", "Chứng từ sửa chữa lớn TSCĐ hay CCDC có mã quản lý: " + _chungTu.MaChungTuQL + " đã được duyệt! với lý do: " + _chungTu.LyDo);
                                foreach (tblCT_NghiepVuSuaChuaLon ct in _nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon)
                                {
                                    if ((ct.ThoiGianSuDung == null ? 0 : ct.ThoiGianSuDung.Value) > 0)
                                        ct.tblTaiSanCoDinhCaBiet.ThoiGianSuDung = ct.ThoiGianSuDung;
                                    ct.tblTaiSanCoDinhCaBiet.NguyenGiaTinhKhauHao += ct.TongTienSuaChua;
                                    ct.tblTaiSanCoDinhCaBiet.TinhTrang = "Đang Sửa Chữa";
                                }
                            }
                        }
                        else
                        {
                            SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đề Nghị Duyệt Chứng Từ {_chungTu.MaChungTuQL}", "Đề nghị duyệt chứng từ sửa chữa lớn TSCĐ hay CCDC có mã quản lý: " + _chungTu.MaChungTuQL + " với nội dung:" + _chungTu.DienGiai);
                        }

                        _factory.SaveChanges(BusinessCodeEnum.TSCD_SuaChuaLon.ToString());//lưu lại chứng từ
                    }
                    DialogUtil.ShowSaveSuccessful();
                    return true;
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful("Lỗi: " + ex.Message + "\n" + ex.InnerException);
                }
            return false;

        }
        private Boolean DuocPhepLuu()
        {
            Ky_Factory ky_Factory = Ky_Factory.New();
            if (_nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon.Count == 0)
            {
                DialogUtil.ShowError("Không lưu chứng từ rỗng!\nVui lòng nhập chi tiết cho cho nghiệp vụ sửa chữa!", "Không lưu được");
                return false;
            }
            foreach (tblCT_NghiepVuSuaChuaLon ct in _nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon)
            {
                if ((ct.TongTienSuaChua == null ? 0 : ct.TongTienSuaChua.Value) == 0)
                {
                    DialogUtil.ShowError("Có dòng tài sản " + ct.tblTaiSanCoDinhCaBiet.TenCaBiet + " chưa có thông tin sửa chữa!\nVui lòng nhập thông tin sửa chữa!", "Không lưu được");
                    return false;
                }
                if (ct.SoHoaDon == null || ct.SoHoaDon.Trim() == "")
                {
                    DialogUtil.ShowError("Có dòng tài sản " + ct.tblTaiSanCoDinhCaBiet.TenCaBiet + " chưa nhập số hóa đơn!\nVui lòng nhập thông tin hóa đơn!", "Không lưu được");
                    return false;
                }
                if (ct.SoHopDong == null || ct.SoHopDong.Trim() == "")
                {
                    DialogUtil.ShowError("Có dòng tài sản " + ct.tblTaiSanCoDinhCaBiet.TenCaBiet + " chưa nhập số hợp đồng!\nVui lòng nhập thông tin hợp đồng!", "Không lưu được");
                    return false;
                }

            }
            //kiểm tra nếu có tài khoản bị khóa sổ trong kỳ
            if (KiemTraCoTaiKhoanKhoaSo(_chungTu.NgayLap.Value) && dteNgayChungTu.Properties.ReadOnly == false)
            {
                DialogUtil.ShowError("Bạn đã nhập định khoản trước rồi thay đổi ngày trong kỳ có tài khoản khóa số!\nHệ thống sẽ tự động trả lại ngày ban đầu của chứng từ\n\nNếu muốn đổi ngày vui lòng xóa dòng định khoản có tài khoản không bị khóa trong kỳ bạn muốn đổi tới!", "Không lưu được");
                _chungTu.NgayLap = _ngayBanDau;
                return false;
            }
            //kiểm tra đối tác
            if ((_chungTu.MaDoiTuong ?? 0) == 0)
            {
                DialogUtil.ShowError("Chưa chọn đối tác");
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
            }
            //kiểm tra nguồn
            //if ((_nghiepVuSuaChuaLon.MaNguon ?? 0) == 0)
            //{
            //    //DialogUtil.ShowWarning("Chưa chọn nguồn");
            //    //chỉ nhắc nhở, vẫn cho phép lưu khi không chọn nguồn
            //}
            //
            // Ky_Factory ky_Factory = Ky_Factory.New();
            if (ky_Factory.DaKhoaSoTSCD(_chungTu.NgayLap.Value, _maCongTy))
            {
                //bật thông báo đã khóa sổ
                DialogUtil.ShowDaKhoaSoTSCD(_chungTu.NgayLap.Value);
                return false;
            }
            //Kiểm tra mã chứng từ quản lý
            if (_factory.KiemTraTrungMaChungTuQL(_chungTu) == true)
            {
                txtMaChungTuQuanLy.Focus();
                DialogResult dlgResult = DialogUtil.ShowYesNo("Trùng mã chứng từ quản lý. Tự động phát sinh mã mới");
                if (dlgResult == DialogResult.Yes)
                {
                    //_chungTu.MaChungTuQL = _factory.Get_NextMaChungTuQL_ByYear(_chungTu.NgayLap.Value.Year, PSC_ERP_Global.Main.UserID);
                    _chungTu.MaChungTuQL = _factory.Get_NextMaChungTuQL_ByYear_And_Month(_chungTu.NgayLap.Value.Year, _chungTu.NgayLap.Value.Month, _maCongTy);
                    //đệ quy
                    return DuocPhepLuu();
                }
                else
                    return false;
            }
            //kiểm tra trùng số chứng từ
            if (_factory.KiemTraTrungSoChungTu(_chungTu) == true)
            {
                txtSoChungTu.Focus();
                DialogResult dlgResult = DialogUtil.ShowYesNo("Trùng số chứng từ. Tự động phát sinh số chứng từ mới");
                if (dlgResult == DialogResult.Yes)
                {
                    //_chungTu.SoChungTu = _factory.Get_NextSoChungTuPhieuKeToanTaiSan(_chungTu.NgayLap.Value.Year, PSC_ERP_Global.Main.UserID);
                    _chungTu.SoChungTu = _factory.Get_NextSoChungTuPhieuKeToanTaiSan_ByYear_and_Month(_chungTu.NgayLap.Value.Year, _chungTu.NgayLap.Value.Month, _maCongTy);
                    //đệ quy
                    return DuocPhepLuu();
                }
                else
                    return false;
            }

            //kiểm tra định khoản
            //if (_chungTu.KiemTraDinhKhoan(kiemTraSoTienChungTuBangSoTienButToan: false) == false)
            //    return false;

            //if (_chungTu.KiemTraHoaDon() == false)
            //    return false;
            return true;
        }
        private void GanBindingSource()
        {
            tblNguonBindingSource.DataSource = _nguonList;
            //
            tblBoPhanERPNewBindingSource.DataSource = _viTriList;
            tblBoPhanBindingSource.DataSource = _boPhanList;
            //
            tblDanhMucTSCDBindingSource.DataSource = _tscdList;
            //gán bindingSource
            {
                tblChungTuBindingSource_Single.DataSource = _chungTu;
                tblTienTeBindingSource_Single.DataSource = _chungTu.tblTienTe;
            }
            try
            {
                tblNghiepVuSuaChuaLonBindingSource.DataSource = _nghiepVuSuaChuaLon;
                tblCTNghiepVuSuaChuaLonBindingSource.DataSource = _nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon;//_chungTu.tblNghiepVuSuaChuaLons.First().tblCT_NghiepVuSuaChuaLon;
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Lỗi hệ thống:\n" + ex.Message);
            }

            tblDinhKhoanBindingSource_Single.DataSource = _chungTu.tblDinhKhoan;
            tblButToanBindingSource.DataSource = _chungTu.tblDinhKhoan.tblButToans;
            tblChungTuHopDongBindingSource.DataSource = _chungTu.tblChungTu_HopDong;
            tblChungTuHoaDonBindingSource.DataSource = _chungTu.tblChungTu_HoaDon;
            //new
            tblChungTuHoaDonTaiSanBindingSource.DataSource = _chungTu.tblChungTu_HoaDonTaiSan;
            tblChungTuHopDongTaiSanBindingSource.DataSource = _chungTu.tblChungTu_HopDongTaiSan;
            tblChungTuHoaDonMuaSuaBanTaiSanBindingSource.DataSource = _chungTu.tblChungTu_HoaDonTaiSanMuaSuaBan;
            //
            //tinhChatSoDuTaiKhoanBindingSource.DataSource = PSC_ERP_Business.Main.Predefined.TinhChatSoDuTaiKhoan.TinhChatSoDuTaiKhoanList;
            //tài khoản
            tblTaiKhoanBindingSource_No.DataSource = _taiKhoanNoList;
            tblTaiKhoanBindingSource_Co.DataSource = _taiKhoanCoList;
            //ghi mục ngân sách
            ghiMucNganSachBindingSource.DataSource = CoKhong.CoKhongList;
        }
        private void KhoiTaoChungTuMoi()
        {
            //chưa load xong
            _daLoadXong = false;
            {
                //khởi tạo mới chứng từ factory
                _factory = ChungTuSuaChuaLonTaiSan_DerivedFactory.New();
                //khởi tạo chứng từ mới 
                _chungTu = _factory.NewChungTu();
                _chungTu.MaCongTy = _maCongTy;
                //lấy nghiệp vụ scl từ chứng từ ra
                _nghiepVuSuaChuaLon = _chungTu.tblNghiepVuSuaChuaLons.First();
                //gán bindingSource
                GanBindingSource();
                //
                //cbTinhChatSoDuTaiKhoan.EditValue = (Int32)TinhChatSoDuTaiKhoanEnum.No;
            }
            //đã load xong
            _daLoadXong = true;
        }
        private void LoadChungTuCu(long maChungTu)
        {
            //chưa load xong
            _daLoadXong = false;
            {
                //khởi tạo mới chứng từ factory
                _factory = ChungTuSuaChuaLonTaiSan_DerivedFactory.New();
                //load chứng từ được quản lý bởi _factory
                _chungTu = _factory.Get_ChungTu_ByMaChungTu(maChungTu);
                //lấy nghiệp vụ scl từ chứng từ ra
                try
                {
                    _nghiepVuSuaChuaLon = _chungTu.tblNghiepVuSuaChuaLons.First();
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowError(ex.Message);
                }
                //nếu duyệt sẽ không cho sửa ngày chứng từ
                if (_chungTu.TrangThai == 1)
                {
                    this.dteNgayChungTu.Properties.ReadOnly = true;
                }
                //gán bindingSource
                GanBindingSource();
                xtraTabControl2.SelectedTabPageIndex = 1;
                //
                //{
                //    //lấy bút toán đầu tiên trong danh sách
                //    tblButToan butToanDauTien = _chungTu.tblDinhKhoan.tblButToans.FirstOrDefault();
                //    if (_chungTu.tblDinhKhoan.LaMotNoNhieuCo == true)
                //    {
                //        if (butToanDauTien != null)
                //        {
                //            cbTaiKhoan.EditValue = butToanDauTien.NoTaiKhoan;
                //            cbTaiKhoan.Properties.DataSource = _taiKhoanNoList;
                //            cbDoiTuong1.EditValue = butToanDauTien.MaDoiTuongNo;
                //        }
                //        cbTinhChatSoDuTaiKhoan.EditValue = (Int32)TinhChatSoDuTaiKhoanEnum.No;
                //    }
                //    else
                //    {
                //        if (butToanDauTien != null)
                //        {
                //            cbTaiKhoan.EditValue = butToanDauTien.CoTaiKhoan;
                //            cbTaiKhoan.Properties.DataSource = _taiKhoanCoList;
                //            cbDoiTuong1.EditValue = butToanDauTien.MaDoiTuongCo;
                //        }
                //        cbTinhChatSoDuTaiKhoan.EditValue = (Int32)TinhChatSoDuTaiKhoanEnum.Co;
                //    }
                //}
                LayDanhSachHopDongCuaChungTu();
            }
            //đã load xong
            _daLoadXong = true;
        }
        private void LayDanhSachNoCoTaiKhoan()
        {
            IQueryable<tblTaiKhoan> taiKhoanList = TaiKhoan_Factory.New().GetAll();
            _taiKhoanNoList = taiKhoanList;//TaiKhoan_Factory.New().Get_DanhSachTaiKhoanNo();
            _taiKhoanCoList = taiKhoanList;// TaiKhoan_Factory.New().Get_DanhSachTaiKhoanCo();
        }
        private void LoadDoiTac_VaBoPhan()
        {
            Thread thr = new Thread(() =>
            {
                if (this.InvokeRequired)
                {
                    PSC_ERP_Common.Delegate.VoidDelegate dele = new PSC_ERP_Common.Delegate.VoidDelegate(this.LoadDoiTac_Helper);
                    this.Invoke(dele);
                }
                else
                {
                    this.LoadDoiTac_Helper();
                }
            });
            thr.Start();
            //Lấy bộ phận
            _viTriList = BoPhanERPNew_Factory.New().GetAll().ToList();
            tblBoPhanERPNew boPhan_vitri_chonTatCa = new tblBoPhanERPNew() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _viTriList.Insert(0, boPhan_vitri_chonTatCa);
            //Lấy bộ phận
            _boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(_maCongTy).ToList();
            tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _boPhanList.Insert(0, boPhan_chonTatCa);
            //Lấy tài sản cá biệt phòng ban
            _tscdList = DanhMucTSCD_Factory.New().Get_DanhSachTaiSanCoDinh_CoTSCDCaBietChuaThanhLy().ToList();
            tblDanhMucTSCD tscd_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
            _tscdList.Insert(0, tscd_chonTatCa);
        }

        void LoadDoiTac_Helper()
        {
            _doiTacList = DoiTac_Factory.New().GetAll();
            tblDoiTacBindingSource.DataSource = _doiTacList;
        }
        private void RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim()
        {
            #region old      
            //foreach (tblCT_NghiepVuSuaChuaLon chiTiet in _nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon)
            //{
            //    tblTaiSanCoDinhCaBiet TSCDCaBietRemoveRaKhoiDanhSachTim = null;
            //    foreach (tblTaiSanCoDinhCaBiet taiSanCaBiet in _taiSanCoDinhCaBietList_TimDuyet)
            //    {
            //        if (taiSanCaBiet.MaTSCDCaBiet == chiTiet.MaTSCDCaBiet)
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
            #endregion old
            // date: 11/11/2020
            foreach (tblCT_NghiepVuSuaChuaLon chiTiet in _nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon)
            {
                for (int i = 0; i < grdViewTSCDCaBiet.RowCount; i++)
                {
                    if (chiTiet.MaTSCDCaBiet == int.Parse(grdViewTSCDCaBiet.GetRowCellValue(i, "MaTSCDCaBiet").ToString()))
                    {
                        grdViewTSCDCaBiet.DeleteRow(i);
                    }
                }
            }
        }

        private void CapNhatLaiTongTien()
        {
            //cập nhật lại tổng tiền chứng từ
            Decimal tongTien = 0;
            Decimal tongTienSuaChuaTungTS = 0;
            foreach (var chiTiet in _nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon)
            {
                tongTienSuaChuaTungTS = 0;
                Decimal tongTienTungChiTietNghiepVu_BoSungDCPT = 0;
                foreach (var bsdcpt in chiTiet.tblBoSungDungCuPhuTungs)
                {
                    tongTienTungChiTietNghiepVu_BoSungDCPT += bsdcpt.TongGiaTri;
                }
                //tongTien += tongTienTungChiTietNghiepVu_BoSungDCPT;
                ////////////////////////////////////////////
                Decimal tongTienTungChiTietNghiepVu_BoSungChiTietTaiSan = 0;
                foreach (var chiTietBoSung in chiTiet.tblChiTietTaiSanCaBiets)
                {
                    if (ERP_Library.Security.CurrentUser.Info.CongThue)
                    {
                        //chiTietBoSung.NguyenGia = chiTietBoSung.TienSauThue;
                        tongTienTungChiTietNghiepVu_BoSungChiTietTaiSan += chiTietBoSung.TienSauThue.Value;
                    }
                    else
                    {
                        tongTienTungChiTietNghiepVu_BoSungChiTietTaiSan += chiTietBoSung.NguyenGia.Value;
                    }
                }
                tongTienSuaChuaTungTS = tongTienTungChiTietNghiepVu_BoSungDCPT + tongTienTungChiTietNghiepVu_BoSungChiTietTaiSan;
                chiTiet.TongTienSuaChua = tongTienSuaChuaTungTS;
                tongTien += tongTienSuaChuaTungTS;
                //tongTien += tongTienTungChiTietNghiepVu_BoSungChiTietTaiSan;
            }
            //foreach (var item in _chungTu.tblChungTu_HopDong)
            //{
            //    tongTien += item.tblHopDong.tblHopDongMuaBan.TongTien.Value;
            //}
            txtSoTien.EditValue = tongTien;
            _chungTu.tblTienTe.SoTien = tongTien;
        }
        #endregion
        private void PhanQuyenThemSuaXoa()
        {
            PhanQuyenSuDungForm _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(ERP_Library.Security.CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            btnThemMoi.Enabled = _phanQuyen.Them;
            btnSave.Enabled = _phanQuyen.Sua;
            btnXoaChungTu.Enabled = _phanQuyen.Xoa;
        }
        //Event Method
        #region Event Method
        private void frmSuaChuaLon_Load(object sender, EventArgs e)
        {
            PhanQuyenThemSuaXoa();
            // app_users user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);
            //lấy danh sách nguồn
            _nguonList = Nguon_Factory.New().GetAll();
            //load đối tác
            LoadDoiTac_VaBoPhan();
            LayDanhSachNoCoTaiKhoan();
            //lay danh sach doi tuong
            {
                List<sp_AllDoiTuong_Result> doiTuongList = new List<sp_AllDoiTuong_Result>();
                doiTuongList = ChungTu_Factory.New().Context.sp_AllDoiTuong(0).ToList();
                sp_AllDoiTuong_Result khongChon = new sp_AllDoiTuong_Result() { MaDoiTuong = 0, MaQLDoiTuong = "<<Không chọn>>", TenDoiTuong = "<<Không chọn>>" };
                doiTuongList.Insert(0, khongChon);
                sp_AllDoiTuong_ResultBindingSource.DataSource = doiTuongList;
                sp_AllDoiTuong_Result_HopDongBindingSource.DataSource = doiTuongList;
            }
            if (_taoMoiChungTu)
            {
                KhoiTaoChungTuMoi();
            }
            else
            {
                LoadChungTuCu(_maChungTuCuCanXemLai);
            }
            //lấy ngày ban đầu của chứng từ để cập nhật lại
            _ngayBanDau = _chungTu.NgayLap.Value;

            //cài đặt master-details
            {
                GridUtil.InitDetailForGridView<tblButToan>(grdViewDinhKhoan_ButToan, tblButToan.tblChungTu_HoaDon_EntityCollectionPropertyName, 0, 1);
            }
            // Đưa checkbox lên lưới
            GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewTSCDCaBiet, colChon);
            GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewCT_NghiepVuSuaChuaLon, colDuyet);
            // Cài đặt lưới
            GridUtil.SetSTTForGridView(new GridView[] { this.grdViewCT_NghiepVuSuaChuaLon
                , this.grdViewDinhKhoan_ButToan
                , this.grdViewChungTu_HopDong
                , this.gridViewHoaDon//new
                , this.gridView_ButToanHoaDon });
            //copy cell
            GridUtil.InitCopyCellForGridView(this.grdViewCT_NghiepVuSuaChuaLon
                , this.grdViewDinhKhoan_ButToan);
            //multi cell select
            GridUtil.InitMultiCellSelectForGridView(this.grdViewCT_NghiepVuSuaChuaLon, grdViewChungTu_HopDong, grdViewDinhKhoan_ButToan);
            //cài đặt delete helper
            GridUtil.DeleteHelper.Setup_ManualType(grdViewCT_NghiepVuSuaChuaLon, (gridView, deleteList) =>
                                                                                 {
                                                                                     //xóa chi tiết
                                                                                     CT_NghiepVuSuaChuaLon_Factory.FullDeleteCT_NghiepVuSuaChuaLon(context: _factory.Context, deleteList: deleteList);
                                                                                 });
            //new
            GridUtil.DeleteHelper.Setup_ManualType(gridViewHoaDon, (gridView, deleteList) =>
                                                                   {
                                                                       //xóa chứng từ hóa đơn tai san
                                                                       XoaDanhSachChungTu_HoaDonTaiSan(deleteList); //ChungTu_HoaDon_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
                                                                   });
            GridUtil.DeleteHelper.Setup_ManualType(gridView_ButToanHoaDon, (gridView, deleteList) =>
                                                                           {
                                                                               //xóa chứng từ hóa đơn
                                                                               ChungTu_HoaDon_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
                                                                           });
            GridUtil.DeleteHelper.Setup_ManualType(grdViewChungTu_HopDong, (gridView, deleteList) =>
                                                                           {
                                                                               //xóa chứng từ hợp đồng
                                                                               XoaDanhSachChungTu_HopDong(deleteList);
                                                                               //ChungTu_HopDong_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
                                                                           });
            GridUtil.DeleteHelper.Setup_ManualType(grdViewDinhKhoan_ButToan, (gridView, deleteList) =>
                                                                             {
                                                                                 //xóa bút toán
                                                                                 // ButToan_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
                                                                                 tblKy ky = Ky_Factory.New().XacDinhKy_ByNgay(_chungTu.NgayLap.Value);
                                                                                 ButToan_Factory.FullDeleteKiemTraKhoaTaiKhoan(_factory.Context, deleteList, PSC_ERP_Global.Main.UserID, ky.MaKy);
                                                                             });
            // Set số thứ tự cho lưới
            GridUtil.SetSTTForGridView(grdViewTSCDCaBiet, 50);
            if (_user.TenDangNhap.ToLower().Equals("admin") || _user.GroupID == 38)
            {
                //tabDinhKhoan.PageVisible = true;
                panelControl_Duyet.Enabled = true;

            }
            else
            {
                grdViewCT_NghiepVuSuaChuaLon.Columns["ThoiGianSuDung"].OptionsColumn.ReadOnly = true;
                panelControl_Duyet.Enabled = false;
                //tabDinhKhoan.PageVisible = false;
                if (_chungTu.TrangThai == 1) ReadOnlyConTrolByStatus();
            }
        }
        private void ReadOnlyConTrolByStatus()
        {
            grdViewTSCDCaBiet.OptionsBehavior.ReadOnly = true;
            grdViewCT_NghiepVuSuaChuaLon.OptionsBehavior.ReadOnly = true;
            grdViewChungTu_HopDong.OptionsBehavior.ReadOnly = true;
            gridViewHoaDon.OptionsBehavior.ReadOnly = true;
            grdViewDinhKhoan_ButToan.OptionsBehavior.ReadOnly = true;
            gridView_ButToanHoaDon.OptionsBehavior.ReadOnly = true;

            foreach (Control c in tabPageChungTu.Controls)
            {
                if (c is PanelControl) { ((PanelControl)c).Controls.Owner.Enabled = false; }
                else if (c is GroupControl) { ((GroupControl)c).Controls.Owner.Enabled = false; }
            }

            btnDuaTaiSanCheckChonVaoChungTu.Enabled = false;
        }

        private void btnBoSungDCPTSuaChuaLonTheoSuaChuaLon_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //lấy dòng chi tiết nghiệp vụ sửa chữa lớn hiện tại
            tblCT_NghiepVuSuaChuaLon chiTietNghiepVu = this.grdViewCT_NghiepVuSuaChuaLon.GetFocusedRow() as tblCT_NghiepVuSuaChuaLon;
            //show danh sách bổ sung dụng cụ phụ tùng theo chi tiết nghiệp vụ SCL
            frmDialogDanhSachBoSungDCPTvaChiTietTheoChiTietNghiepVuSuaChuaLon frm = new frmDialogDanhSachBoSungDCPTvaChiTietTheoChiTietNghiepVuSuaChuaLon(context: _factory.Context, chungTu: _chungTu, ct_NghiepVuSuaChuaLon: chiTietNghiepVu);
            frm.ShowDialog();
            //cập nhật lại tổng tiền
            this.CapNhatLaiTongTien();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.txtBlackHole.Focus();
            //lấy mã phòng ban đang chọn trong điều kiện tìm
            Int32 maViTri = Convert.ToInt32(treeListLookUpEdit_ViTri.EditValue);
            Int32 maPhongBan = Convert.ToInt32(treeListLookUpEdit_BoPhan.EditValue.ToString() == "" ? 0 : treeListLookUpEdit_BoPhan.EditValue);
            // Lấy mã tài sản cố định cá biệt
            Int32 maTaiSanCDCB = Convert.ToInt32(cbTaiSanCD.EditValue);
            #region old
            ////Tìm kiếm dữ liệu
            //_taiSanCoDinhCaBietList_TimDuyet = TaiSanCoDinhCaBiet_Factory.New().Context.spd_TSCD_DanhSachTaiSanCoDinhHayCCDCCoDenNgay_TheoPhongBanViTriLoaiTaiSan(DateTime.Now.Date, maPhongBan, maViTri, maTaiSanCDCB, _maCongTy, 1,_chungTu.MaLoaiChungTu).ToList();

            //TaiSanCoDinhCaBiet_Factory.New().Get_DanhSachTSCDCaBietTheoPhongBanAndMaTruongAndMaTSCD(maPhongBan, maViTri, maTaiSanCDCB, _maCongTy).ToList(); super old
            //// Đưa dữ liệu vào bindingsource
            //tblTaiSanCoDinhCaBietBindingSource_TimDuyet.DataSource = _taiSanCoDinhCaBietList_TimDuyet;
            #endregion end old
            // chỉnh sửa tìm kiếm dữ liệu date:11/11/2020
            using (DialogUtil.Wait())
            {
                DataTable _dt_TaiSanCoDinhCaBiet = new DataTable();
                _dt_TaiSanCoDinhCaBiet = dt_TaiSanCoDinhCaBiet(DateTime.Now.Date, maPhongBan, maViTri, maTaiSanCDCB, _maCongTy, 1, _chungTu.MaLoaiChungTu);
                grdTSCDCaBiet.DataSource = _dt_TaiSanCoDinhCaBiet;
                // Xóa duyệt tài sản cố định cá biệt vừa chọn ra khỏi danh sách tìm
                if (grdViewTSCDCaBiet.RowCount > 0 && tblCTNghiepVuSuaChuaLonBindingSource.Count > 0)
                {
                    RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
                }
            }
            // Thông báo khi không có dữ liệu
            if (grdViewTSCDCaBiet.RowCount == 0)
            {
                DialogUtil.ShowOK("Không có dữ liệu");
            }
        }
        // bổ sung 10/11/2020 
        public static DataTable dt_TaiSanCoDinhCaBiet(
                Nullable<System.DateTime> denNgay, Nullable<int> maBoPhan, Nullable<int> maViTri, Nullable<int> maLoai, Nullable<int> maCongTy,
                Nullable<int> loaiBaoCao, Nullable<int> loaiNghiepVu)
        {
            DataTable kq = new DataTable();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TSCD_DanhSachTaiSanCoDinhHayCCDCCoDenNgay_TheoPhongBanViTriLoaiTaiSan";
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
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
        private void btnDuaTaiSanCheckChonVaoChungTu_Click(object sender, EventArgs e)
        {
            #region old
            //this.txtBlackHole.Focus();
            ////cập nhật lại tổng tiền               
            //Boolean coTaiSanCaBietDuocChonTuDanhSach = false;
            //if (_taiSanCoDinhCaBietList_TimDuyet == null)
            //{
            //    DialogUtil.ShowWarning("Chọn tài sản cần lập chờ duyệt.");
            //    return;
            //}
            ////lặp qua từng dòng tài sản tìm được
            //foreach (tblTaiSanCoDinhCaBiet taiSanCaBiet in _taiSanCoDinhCaBietList_TimDuyet)
            //{
            //    //nếu tài sản được chọn
            //    if (taiSanCaBiet.Chon == true)
            //    {
            //        coTaiSanCaBietDuocChonTuDanhSach = true;
            //        //khởi tạo chi tiết nghiệp vụ scl
            //        tblCT_NghiepVuSuaChuaLon chiTietNghiepVu = CT_NghiepVuSuaChuaLon_Factory.New().CreateAloneObject();
            //        chiTietNghiepVu.MaTSCDCaBiet = taiSanCaBiet.MaTSCDCaBiet;
            //        // Lấy mã chờ duyệt tài sản cố định 
            //        //chiTietNghiepVu.MaChoDuyetTSCD = taiSanCaBiet.MaChoDuyet;
            //        chiTietNghiepVu.ThoiGianSuDungCu = taiSanCaBiet.ThoiGianSuDung;
            //        DateTime day = _chungTu.NgayLap.Value.AddDays(-1);
            //        chiTietNghiepVu.NguyenGiaTruocSuaChua = TaiSanCoDinhCaBiet_Factory.New().Get_TongNguyenGiaCuaTaiSanCaBiet_ByMaTSCDCB_DenNgay(day, taiSanCaBiet.MaTSCDCaBiet);
            //        //Đưa vao danh sach chi tiết nv scl
            //        _nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon.Add(chiTietNghiepVu);
            //    }
            //}
            ////thông báo người dùng nếu chưa chọn bất cứ dòng nào từ danh sách duyệt
            //if (coTaiSanCaBietDuocChonTuDanhSach == false)
            //{
            //    DialogUtil.ShowWarning("Chưa chọn dữ liệu.");
            //    return;
            //}
            //// Xóa duyệt tài sản cố định cá biệt vừa chọn ra khỏi danh sách tìm
            //RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
            #endregion end old
            try
            {
                this.txtBlackHole.Focus();
                //cập nhật lại tổng tiền               
                Boolean coTaiSanCaBietDuocChonTuDanhSach = false;
                using (DialogUtil.Wait())
                {
                    if (grdViewTSCDCaBiet.RowCount > 0)
                    {
                        for (int i = 0; i < grdViewTSCDCaBiet.RowCount; i++)
                        {
                            DataRow dr = grdViewTSCDCaBiet.GetDataRow(i);
                            if (dr != null)
                            {
                                if (bool.Parse(dr["Chon"].ToString()) == true)
                                {
                                    coTaiSanCaBietDuocChonTuDanhSach = true;
                                    //khởi tạo chi tiết nghiệp vụ scl
                                    tblCT_NghiepVuSuaChuaLon chiTietNghiepVu = CT_NghiepVuSuaChuaLon_Factory.New().CreateAloneObject();
                                    chiTietNghiepVu.MaTSCDCaBiet = Convert.ToInt32(dr["MaTSCDCaBiet"].ToString());
                                    // Lấy mã chờ duyệt tài sản cố định 
                                    chiTietNghiepVu.ThoiGianSuDungCu = Convert.ToInt32(dr["ThoiGianSuDung"].ToString());
                                    DateTime day = _chungTu.NgayLap.Value.AddDays(-1);
                                    chiTietNghiepVu.NguyenGiaTruocSuaChua = TaiSanCoDinhCaBiet_Factory.New().Get_TongNguyenGiaCuaTaiSanCaBiet_ByMaTSCDCB_DenNgay(day, Convert.ToInt32(dr["MaTSCDCaBiet"].ToString()));
                                    //Đưa vao danh sach chi tiết nv scl
                                    _nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon.Add(chiTietNghiepVu);
                                }
                            }
                        }
                        // Xóa duyệt tài sản cố định cá biệt vừa chọn ra khỏi danh sách tìm
                        RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
                        xtraTabControl2.SelectedTabPage = tabPageChungTu;

                    }
                }
                //thông báo người dùng nếu chưa chọn bất cứ dòng nào từ danh sách duyệt
                if (coTaiSanCaBietDuocChonTuDanhSach == false) { DialogUtil.ShowWarning("Chưa chọn dữ liệu."); return; }
            }
            catch (Exception ex)
            { XtraMessageBox.Show("<color=red>- Lỗi: </color>" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, DevExpress.Utils.DefaultBoolean.True); }
        }

        private void cbDoiTac_EditValueChanged(object sender, EventArgs e)
        {
            tblDoiTac doiTacHienTai = cbDoiTac.GetSelectedDataRow() as tblDoiTac;
            if (cbDoiTac.EditValue != null && cbDoiTac.EditValue != DBNull.Value && doiTacHienTai == null)
            {
                Int64 maDoiTac = Convert.ToInt64(cbDoiTac.EditValue);
                doiTacHienTai = DoiTac_Factory.New().Get_DoiTacByMaDoiTac(maDoiTac);
            }
            //đưa thông tin tên đối tác hiển thị lên texbox cạnh cbDoiTac
            if (doiTacHienTai != null)
                txtTenDoiTac.Text = doiTacHienTai.TenDoiTac;
            else
                txtTenDoiTac.Text = "";
        }
        private void LayDanhSachHopDongCuaChungTu()
        {
            //lây hợp đồng cua chung tu
            {
                List<Int64> danhSachMaHopDong = new List<Int64>();
                //duyet qua tung hop dong trong chung tu
                foreach (var item in _chungTu.tblChungTu_HopDong)
                {
                    danhSachMaHopDong.Add(item.MaHopDong ?? 0);
                }
                _hopDongList = HopDongTaiSan_DerivedFactory.New().GetListByMaHopDongList(danhSachMaHopDong).ToList();
            }
            tblHopDong hopDong_khongChon = new tblHopDong() { MaHopDong = 0, TenHopDong = "<<Không chọn>>" };
            hopDong_khongChon.tblHopDongMuaBan = new tblHopDongMuaBan() { SoHopDong = "<<Không chọn>>" };
            _hopDongList.Insert(0, hopDong_khongChon);
            tblHopDongBindingSource.DataSource = _hopDongList;

            //////gở bỏ hợp đồng gắn sai tren but toan
            foreach (var item in _chungTu.tblDinhKhoan.tblButToans)
            {
                //List<tblHopDong> hdList = tblHopDongBindingSource.DataSource as List<tblHopDong>;
                if (false == _hopDongList.Any(x => x.MaHopDong == (item.MaHopDong ?? 0)))
                    item.MaHopDong = null;
            }
        }
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dlgResult = DialogUtil.ShowSaveRequireOptions(this);
            if (dlgResult == DialogResult.Yes)
            {
                if (this.Save() == false)
                    return;
            }
            if (_objFromAnotherFactory != null)
                this._objFromAnotherFactory.CurrentForm_AddedObj = null;
            this.KhoiTaoChungTuMoi();
        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save();
        }
        private void btnXoaChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (Ky_Factory.New().DaKhoaSoTSCD(_chungTu.NgayLap.Value, _maCongTy))
            {
                //bật thông báo đã khóa sổ
                DialogUtil.ShowDaKhoaSoTSCD(_chungTu.NgayLap.Value);
            }
            else if (KiemTraCoTaiKhoanKhoaSo(_chungTu.NgayLap.Value))
            {
                DialogUtil.ShowError("Có tài khoản khóa sổ không thể xóa chứng từ!");
            }
            else
            {
                //yêu cầu người dùng xác nhận xóa
                if (_chungTu.MaNguoiLap == _user.UserID && DialogUtil.ShowDelete(this) == DialogResult.Yes)
                {
                    try
                    {
                        using (DialogUtil.WaitForDelete(this))
                        {
                            _factory.XoaChungTu(_chungTu);
                            //lưu lại thay đổi
                            _factory.SaveChanges();
                        }
                        //thông báo đã xóa thành công
                        DialogUtil.ShowDeleteSuccessful();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        //thông báo không xóa được
                        DialogUtil.ShowNotDeleteSuccessful(ex.Message);
                    }
                }
                else
                {
                    DialogUtil.ShowWarning("Bạn không thể xóa Chứng Từ của người khác !");
                }
            }
        }
        private void btnDanhSachChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachChungTu_SuaChuaLon.ShowSingleton(null, this.MdiParent);
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #region các tab

        private void btnTimChonHoaDon_Click(object sender, EventArgs e)
        {
            frmDialogTimChonHoaDon frm = new frmDialogTimChonHoaDon(_chungTu, _chungTu.MaDoiTuong ?? 0);
            DialogResult dlgResult = frm.ShowDialog(this);
            if (dlgResult == DialogResult.Yes)
            {
                int count = 0;
                //duyệt qua từng hóa đơn được chọn
                foreach (tblHoaDon item in frm.HoaDonDuocChonList)
                {
                    tblChungTu_HoaDonTaiSan chungTu_HoaDonTaiSan = ChungTu_HoaDonTaiSan_Factory.New().CreateAloneObject();
                    chungTu_HoaDonTaiSan.MaHoaDon = item.MaHoaDon;
                    //đưa vào danh sách chứng từ hóa đơn tai san
                    tblChungTuHoaDonTaiSanBindingSource.Add(chungTu_HoaDonTaiSan);

                    foreach (tblButToan butToan in _chungTu.tblDinhKhoan.tblButToans)
                    {
                        tblTaiKhoan taiKhoanCo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(butToan.CoTaiKhoan ?? 0);
                        tblTaiKhoan taiKhoanNo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(butToan.NoTaiKhoan ?? 0);

                        if ((taiKhoanCo != null && (taiKhoanCo.SoHieuTK.StartsWith("3113") || taiKhoanCo.SoHieuTK.StartsWith("3337"))
                            )
                        || (taiKhoanNo != null && (taiKhoanNo.SoHieuTK.StartsWith("3113") || taiKhoanNo.SoHieuTK.StartsWith("3337"))
                            )
                       )
                        {
                            //butToan.tblChungTu_HoaDon.Clear();
                            if (butToan.tblChungTu_HoaDon.Any(x => x.MaHoaDon == item.MaHoaDon) == false)
                            {
                                tblChungTu_HoaDon chungTu_HoaDonNew = ChungTu_HoaDon_Factory.New().CreateAloneObject();
                                chungTu_HoaDonNew.MaHoaDon = item.MaHoaDon;
                                butToan.tblChungTu_HoaDon.Add(chungTu_HoaDonNew);
                                _chungTu.tblChungTu_HoaDon.Add(chungTu_HoaDonNew);
                                count++;
                            }
                        }
                    }//end foreach
                }//end foreach
                /*
                if (count > 0)
                    DialogUtil.ShowInfo("Hệ thống vừa tự động gắn hóa đơn vào các bút toán thuế");
                 */
            }
        }

        private void btnTimChonHopDongTaiSan_Click(object sender, EventArgs e)
        {
            Int64 maDoiTac = 0;
            try
            {
                maDoiTac = (Int64)cbDoiTac.EditValue;
            }
            catch (Exception ex) { }

            //if (maDoiTac == 0)
            //{
            //    DialogUtil.ShowWarning("Cần chọn đối tác trước");
            //    cbDoiTac.Focus();
            //}
            //else
            {//
                using (frmDialogTimChonHopDongTaiSan frm = new frmDialogTimChonHopDongTaiSan(maDoiTac))
                {
                    DialogResult dlgResult = frm.ShowDialog(this);
                    if (dlgResult == DialogResult.Yes)
                    {
                        //duyệt qua từng hợp đồng được chọn
                        foreach (tblHopDong hd in frm.HopDongDuocChonList)
                        {
                            Boolean daTonTai = false;
                            foreach (tblChungTu_HopDong chungTu_HopDong in _chungTu.tblChungTu_HopDong)
                            {
                                if (hd.MaHopDong == chungTu_HopDong.MaHopDong)
                                {
                                    daTonTai = true;
                                    break;
                                }
                            }
                            //
                            if (daTonTai == false)
                            {
                                tblChungTu_HopDong chungTu_HopDong = ChungTu_HopDong_Factory.New().CreateAloneObject();
                                chungTu_HopDong.MaHopDong = hd.MaHopDong;
                                //đưa vào danh sách chứng từ hợp đồng
                                tblChungTuHopDongBindingSource.Add(chungTu_HopDong);
                                //lấy mã đối tác của hợp đồng gán cho chứng từ
                                _chungTu.MaDoiTuong = chungTu_HopDong.tblHopDong.MaDoiTac;
                            }
                        }
                        LayDanhSachHopDongCuaChungTu();
                        //tính lại tổng tiền chứng từ
                        this.CapNhatLaiTongTien();
                        //lấy danh sách hợp đồng
                    }
                }
            }//
        }

        private void btnButToanMucNganSach_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.grdViewDinhKhoan_ButToan.FocusedRowHandle >= 0)
            {
                //lấy bút toán hiện tại
                tblButToan currentButToan = this.grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
                //show danh sách bút toán mục ngân sách theo bút toán
                frmDialogDanhSachGhiMucNganSachTheoButToan frm = new frmDialogDanhSachGhiMucNganSachTheoButToan(context: _factory.Context, chungTu: _chungTu, butToan: currentButToan, noTaiKhoanList: _taiKhoanNoList, coTaiKhoanList: _taiKhoanCoList);
                frm.ShowDialog();
            }
        }
        private void btnCongViecChuongTrinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.grdViewDinhKhoan_ButToan.FocusedRowHandle >= 0)
            {
                //lấy bút toán hiện tại
                tblButToan currentButToan = this.grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
                //show danh sách công việc chương trình
                using (frmDialogPhanLoaiChiPhi frm = new frmDialogPhanLoaiChiPhi(context: _factory.Context, chungTu: _chungTu, butToan: currentButToan))
                {
                    frm.ShowDialog();
                }
            }
        }
        private void grdViewDinhKhoan_ButToan_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //lấy bút toán vừa tạo mới trên lưới
            tblButToan butToan = grdViewDinhKhoan_ButToan.GetRow(e.RowHandle) as tblButToan;
            if (butToan != null)
            {      //lấy diễn giải chứng từ
                butToan.DienGiai = _chungTu.DienGiai;
                //new
                //lay ma hop dong dau tien
                {
                    tblChungTu_HopDong chungTuHopDongDauTien = _chungTu.tblChungTu_HopDong.FirstOrDefault();
                    if (chungTuHopDongDauTien != null)
                        butToan.MaHopDong = chungTuHopDongDauTien.MaHopDong;
                }
                //new
                //gan doi tuong
                butToan.MaDoiTuongCo = _chungTu.MaDoiTuong;
                butToan.MaDoiTuongNo = _chungTu.MaDoiTuong;
                //số tiền bút toán trừ dần
                {
                    Decimal tongTienCacButToanKhac = 0;
                    foreach (var item in _chungTu.tblDinhKhoan.tblButToans)
                    {
                        if (!Object.ReferenceEquals(item, butToan))
                            tongTienCacButToanKhac += item.SoTien;
                    }
                    butToan.SoTien = (_chungTu.tblTienTe.ThanhTien != null ? _chungTu.tblTienTe.ThanhTien.Value : 0) - tongTienCacButToanKhac;
                }
                //lấy tính chất số dư được chọn
                //try
                //{
                //    TinhChatSoDuTaiKhoanEnum tinhChatSoDu = (TinhChatSoDuTaiKhoanEnum)((Int32)cbTinhChatSoDuTaiKhoan.EditValue);
                //    tblTaiKhoan taiKhoanDuocChon = cbTaiKhoan.GetSelectedDataRow() as tblTaiKhoan;
                //    sp_AllDoiTuong_Result doiTuongDuocChon = cbDoiTuong1.GetSelectedDataRow() as sp_AllDoiTuong_Result;
                //    if (taiKhoanDuocChon != null)
                //        //lấy tài khoản được chọn gán cho mặc định cho dòng định khoản mới tạo
                //        if (tinhChatSoDu == TinhChatSoDuTaiKhoanEnum.No)
                //        {
                //            butToan.NoTaiKhoan = taiKhoanDuocChon.MaTaiKhoan;
                //            butToan.MaDoiTuongNo = doiTuongDuocChon.MaDoiTuong;
                //        }
                //        else if (tinhChatSoDu == TinhChatSoDuTaiKhoanEnum.Co)
                //        {
                //            butToan.CoTaiKhoan = taiKhoanDuocChon.MaTaiKhoan;
                //            butToan.MaDoiTuongCo = doiTuongDuocChon.MaDoiTuong;
                //        }
                //}
                //catch (System.Exception ex) { }
            }
        }
        private void btnHoaDonButToan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.grdViewDinhKhoan_ButToan.FocusedRowHandle >= 0)
            {
                //lấy bút toán hiện tại
                tblButToan currentButToan = this.grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
                //show danh sách bút toán hóa đơn
                using (frmDialogDanhSachHoaDonTheoButToan frm = new frmDialogDanhSachHoaDonTheoButToan(context: _factory.Context, chungTu: _chungTu, butToan: currentButToan, noTaiKhoanList: _taiKhoanNoList, coTaiKhoanList: _taiKhoanCoList))
                {
                    frm.ShowDialog();
                }
            }
        }

        //private void cbTinhChatSoDuTaiKhoan_EditValueChanged(object sender, EventArgs e)
        //{
        //    //lấy tính chất được chọn
        //    TinhChatSoDuTaiKhoanEnum tinhChat = (TinhChatSoDuTaiKhoanEnum)((Int32)(cbTinhChatSoDuTaiKhoan.EditValue));


        //    //lấy mã tài khoản được chọn trước đó
        //    Int32 maTaiKhoan = (Int32)(cbTaiKhoan.EditValue ?? 0);

        //    Boolean maTaiKhoanTuongThich = false;
        //    if (tinhChat == TinhChatSoDuTaiKhoanEnum.No)
        //    {
        //        cbTaiKhoan.Properties.DataSource = tblTaiKhoanBindingSource_No;
        //        //một nợ nhiều có = true
        //        _chungTu.tblDinhKhoan.LaMotNoNhieuCo = true;
        //        //khóa cột nợ
        //        colNoTaiKhoan.OptionsColumn.ReadOnly = true;
        //        colNoTaiKhoan.Visible = false;
        //        colDoiTuongNo.OptionsColumn.ReadOnly = true;
        //        colDoiTuongNo.Visible = false;
        //        //mở cột có
        //        colCoTaiKhoan.OptionsColumn.ReadOnly = false;
        //        colCoTaiKhoan.Visible = true;
        //        colDoiTuongCo.OptionsColumn.ReadOnly = false;
        //        colDoiTuongCo.Visible = true;
        //        //
        //        foreach (var item in _taiKhoanNoList)
        //        {
        //            if (maTaiKhoan == item.MaTaiKhoan)
        //            {
        //                maTaiKhoanTuongThich = true;
        //            }
        //        }
        //    }
        //    else if (tinhChat == TinhChatSoDuTaiKhoanEnum.Co)//cần set mặc định một có nhiều nợ
        //    {
        //        cbTaiKhoan.Properties.DataSource = tblTaiKhoanBindingSource_Co;
        //        //một nợ nhiều có = false = một có nhiều nợ
        //        _chungTu.tblDinhKhoan.LaMotNoNhieuCo = false;
        //        //khóa cột có
        //        colCoTaiKhoan.OptionsColumn.ReadOnly = true;
        //        colCoTaiKhoan.Visible = false;
        //        colDoiTuongCo.OptionsColumn.ReadOnly = true;
        //        colDoiTuongCo.Visible = false;
        //        //mở cột nợ
        //        colNoTaiKhoan.OptionsColumn.ReadOnly = false;
        //        colNoTaiKhoan.Visible = true;
        //        colDoiTuongNo.OptionsColumn.ReadOnly = false;
        //        colDoiTuongNo.Visible = true;
        //        //
        //        foreach (var item in _taiKhoanCoList)
        //        {
        //            if (maTaiKhoan == item.MaTaiKhoan)
        //            {
        //                maTaiKhoanTuongThich = true;
        //            }
        //        }

        //        if (cbTaiKhoan.EditValue == null)
        //        {
        //            //lấy tài khoản mặc định
        //            tblTaiKhoan taiKhoanMacDinh = TaiKhoan_Factory.New().Get_TaiKhoan_BySoHieu("3311");
        //            cbTaiKhoan.EditValue = taiKhoanMacDinh.MaTaiKhoan;
        //        }
        //    }
        //    //thay đổi nợ có các bút toán
        //    ThayDoiHangLoatNoHoacCoCuaButToan();

        //    //chọn lại tài khoản khác nếu tài khoản được chọn trước đó không có trong danh sách mới
        //    if (maTaiKhoanTuongThich == false)//nếu tài khoản ko tương thích
        //    {
        //        //this.cbTaiKhoan.EditValue = null;//set về null

        //        //if (cbTaiKhoan.Properties.DataSource != null)
        //        //{//lấy mã tài khoản đầu tiên trong danh sách gán cho cbTaiKhoan

        //        //    BindingSource currentBinding = cbTaiKhoan.Properties.DataSource as BindingSource;
        //        //    currentBinding.MoveFirst();
        //        //    tblTaiKhoan taiKhoanDauTien = currentBinding.Current as tblTaiKhoan;
        //        //    if (taiKhoanDauTien != null)
        //        //        this.cbTaiKhoan.EditValue = taiKhoanDauTien.MaTaiKhoan;

        //        //}
        //    }
        //}

        //private void cbTaiKhoan_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (_daLoadXong)
        //    {
        //        ThayDoiHangLoatNoHoacCoCuaButToan();
        //    }
        //}

        //private void cbDoiTuong1_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (_daLoadXong)
        //    {
        //        ThayDoiHangLoatNoHoacCoCuaButToan(fromDoiTuong: true);
        //    }
        //}

        //private void ThayDoiHangLoatNoHoacCoCuaButToan(Boolean fromDoiTuong = false)
        //{
        //    TinhChatSoDuTaiKhoanEnum tinhChat = (TinhChatSoDuTaiKhoanEnum)((Int32)(cbTinhChatSoDuTaiKhoan.EditValue));
        //    //new
        //    if (fromDoiTuong == false && tinhChat == TinhChatSoDuTaiKhoanEnum.Co)
        //    {
        //        tblTaiKhoan coTaiKhoan = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(Convert.ToInt32(cbTaiKhoan.EditValue));
        //        if (coTaiKhoan != null)
        //        {
        //            if (coTaiKhoan.CoDoiTuongTheoDoi == true)
        //            {
        //                if (Convert.ToInt64(cbDoiTuong1.EditValue) == 0)
        //                    cbDoiTuong1.EditValue = _chungTu.MaDoiTuong;
        //            }
        //            else
        //                cbDoiTuong1.EditValue = null;
        //        }
        //    }
        //    //chuyển hàng loạt cột nợ hoặc có chọn từ cbTaiKhoan
        //    foreach (var butToan in _chungTu.tblDinhKhoan.tblButToans)
        //    {
        //        if (tinhChat == TinhChatSoDuTaiKhoanEnum.No)
        //        {
        //            butToan.NoTaiKhoan = (Int32?)cbTaiKhoan.EditValue;
        //            butToan.MaDoiTuongNo = (Int64)cbDoiTuong1.EditValue;
        //        }
        //        else if (tinhChat == TinhChatSoDuTaiKhoanEnum.Co)
        //        {
        //            butToan.CoTaiKhoan = (Int32?)cbTaiKhoan.EditValue;
        //            butToan.MaDoiTuongCo = (Int64)cbDoiTuong1.EditValue;
        //        }
        //    }
        //}

        //private void cbGhiMucNganSach_EditValueChanged(object sender, EventArgs e)
        //{
        //    Boolean ghiMucNganSach = false;
        //    try
        //    {
        //        ghiMucNganSach = (Boolean)cbGhiMucNganSach.EditValue;

        //        if (_chungTu.tblDinhKhoan.GhiMucNganSach != ghiMucNganSach)
        //            //gán giá tri cho d?nh kho?n (r?t quan tr?ng)
        //            _chungTu.tblDinhKhoan.GhiMucNganSach = ghiMucNganSach;

        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //    //?n hi?n c?t ghi m?c ngân sách trên lu?i bút toán
        //    this.colButToanMucNganSach.Visible = ghiMucNganSach;
        //}
        private void btnGoBoHoaDon_Click(object sender, EventArgs e)
        {
            this.txtBlackHole.Focus();
            //yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn gở bỏ những dòng hóa đơn đang chọn?");
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    Int32[] rowHandleList = this.gridViewHoaDon.GetSelectedRows();
                    if (rowHandleList.Count() > 0)
                    {
                        List<Object> deleteList = new List<Object>();
                        foreach (var index in rowHandleList)
                        {
                            deleteList.Add(this.gridViewHoaDon.GetRow(index));
                        }
                        //
                        XoaDanhSachChungTu_HoaDonTaiSan(deleteList);
                    }
                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError(string.Format("Không thể gở bỏ những dòng hóa đơn đang chọn!\n{0}", ex.Message));
                }
            }
        }
        #endregion

        #region Report
        private void btnInBienBanDieuChinhBoSung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDialogChonPhongBan dlg = new frmDialogChonPhongBan(LayDanhSachBoPhanTrongDanhSachTaiSanCuaChungTu(), true);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                int maPhongBan = dlg.MaPhongBan;
                ReportHelper.ShowReport("NghiepVuSuaChuaLon_BienBanDieuChinhBoSung", () =>
                {
                    DataSet dataSet = new DataSet();
                    SpeedDataAccess dataAccess = new SpeedDataAccess(PSC_ERP_Business.Main.Database.NormalConnectionString);
                    dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BienBanSuaChuaLon", "@MaChungTu,@MaPhongBan", _chungTu.MaChungTu, maPhongBan);
                    dataAccess.FillDataSet(ref dataSet, "CoTaiKhoan", "sp_TSCD_LayCoTaiKhoanCuaDSTaiSanTheoChungTuSuaChuaLon", "@MaChungTu", _chungTu.MaChungTu);
                    dataAccess.FillDataSet(ref dataSet, "NoTaiKhoan", "sp_TSCD_LayNoTaiKhoanCuaDSTaiSanTheoChungTuSuaChuaLon", "@MaChungTu", _chungTu.MaChungTu);
                    return dataSet;
                }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
            }
        }
        private List<tblnsBoPhan> LayDanhSachBoPhanTrongDanhSachTaiSanCuaChungTu()
        {
            List<tblnsBoPhan> list = new List<tblnsBoPhan>();
            foreach (var item in _nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon)
            {
                //list.Remove(item.tblTaiSanCoDinhCaBiet.PhanBoSauCung_RefObj.tblBoPhanERPNew);
                list.RemoveAll(x => x.MaBoPhan == item.tblTaiSanCoDinhCaBiet.PhanBoSauCung_RefObj.MaPhongBan);
                list.Add(item.tblTaiSanCoDinhCaBiet.PhanBoSauCung_RefObj.tblnsBoPhan);
            }
            return list;
        }
        private void btnInPhieuKeToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("PhieuKeToanChungTuSuaChuaLon", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(PSC_ERP_Business.Main.Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_PhieuKeToanChungTu", "@MaChungTu", _chungTu.MaChungTu);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);

        }
        #endregion

        private void dteNgayChungTu_EditValueChanged(object sender, EventArgs e)
        {
            //cập nhật lại ngày lập
            if (dteNgayChungTu.DateTime.Date != new DateTime(1, 1, 1) && dteNgayChungTu.DateTime.Date != _chungTu.NgayLap)
            {
                _chungTu.NgayLap = (DateTime?)dteNgayChungTu.DateTime.Date;
                if (_chungTu.MaChungTu == 0)
                {
                    //Phát sinh số chứng từ mới
                    _chungTu.MaChungTuQL = _factory.Get_NextMaChungTuQL_ByYear_And_Month(_chungTu.NgayLap.Value.Year, _chungTu.NgayLap.Value.Month, _maCongTy);
                    _chungTu.SoChungTu = _factory.Get_NextSoChungTuPhieuKeToanTaiSan_ByYear_and_Month(_chungTu.NgayLap.Value.Year, _chungTu.NgayLap.Value.Month, _maCongTy);
                }

            }
            try
            {
                //cập nhật lại ngày
                foreach (var ctiet in _nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon)
                {
                    foreach (var bsdcpt in ctiet.tblBoSungDungCuPhuTungs)
                    {
                        bsdcpt.NgayChungTuSCL = _chungTu.NgayLap;
                    }

                    foreach (var chiTietTSCaBiet in ctiet.tblChiTietTaiSanCaBiets)
                    {
                        chiTietTSCaBiet.NgayChungTuSCL = _chungTu.NgayLap;
                    }
                }
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Lỗi hệ thống!\n" + ex.Message);
            }
        }
        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_SuaChuaLon, this.MdiParent);
        }

        private void btnXoaChungTu_HopDong_Click(object sender, EventArgs e)
        {
            this.txtBlackHole.Focus();
            //yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn gở bỏ những dòng hợp đồng đang chọn?");
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    Int32[] rowHandleList = this.grdViewChungTu_HopDong.GetSelectedRows();
                    if (rowHandleList.Count() > 0)
                    {
                        List<Object> deleteList = new List<Object>();
                        foreach (var index in rowHandleList)
                        {
                            deleteList.Add(this.grdViewChungTu_HopDong.GetRow(index));
                        }
                        //
                        XoaDanhSachChungTu_HopDong(deleteList);
                    }
                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError("Không thể gở bỏ những dòng hợp đồng đang chọn!\n" + ex.Message);
                }
            }
        }
        private void frmSuaChuaLon_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_factory.IsDirty)
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
        private void grdViewDinhKhoan_ButToan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            tblButToan currentButToan = grdViewDinhKhoan_ButToan.GetRow(e.RowHandle) as tblButToan;
            if (Object.ReferenceEquals(e.Column, this.colNoTaiKhoan) || Object.ReferenceEquals(e.Column, this.colCoTaiKhoan))
            {
                int count = 0;
                //////duyệt qua từng hóa đơn
                foreach (tblChungTu_HoaDonTaiSan chungTu_HoaDonTaiSan in _chungTu.tblChungTu_HoaDonTaiSan)
                {
                    tblTaiKhoan taiKhoanCo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.CoTaiKhoan ?? 0);
                    tblTaiKhoan taiKhoanNo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.NoTaiKhoan ?? 0);

                    if ((taiKhoanCo != null && (taiKhoanCo.SoHieuTK.StartsWith("3113") || taiKhoanCo.SoHieuTK.StartsWith("3337"))
                            )
                        || (taiKhoanNo != null && (taiKhoanNo.SoHieuTK.StartsWith("3113") || taiKhoanNo.SoHieuTK.StartsWith("3337"))
                            )
                       )
                    {
                        if (currentButToan.tblChungTu_HoaDon.Any(x => x.MaHoaDon == chungTu_HoaDonTaiSan.MaHoaDon) == false)
                        {
                            tblChungTu_HoaDon chungTu_HoaDonNew = ChungTu_HoaDon_Factory.New().CreateAloneObject();
                            chungTu_HoaDonNew.MaHoaDon = chungTu_HoaDonTaiSan.MaHoaDon;
                            currentButToan.tblChungTu_HoaDon.Add(chungTu_HoaDonNew);
                            _chungTu.tblChungTu_HoaDon.Add(chungTu_HoaDonNew);
                            count++;
                        }
                    }
                }
                /*
                if (count > 0)
                    DialogUtil.ShowInfo(String.Format("Hệ thống vừa tự động gắn {0} hóa đơn vào bút toán thuế hiện tại", count));
                 */
            }
        }
        #endregion

        public bool KiemTraCoTaiKhoanKhoaSo(DateTime ngay)
        {
            if (_chungTu.tblDinhKhoan.tblButToans.Count() == 0)
                return false;
            foreach (tblButToan butToan in _chungTu.tblDinhKhoan.tblButToans)
            {
                tblKy ky = Ky_Factory.New().XacDinhKy_ByNgay(ngay);
                if (TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, PSC_ERP_Global.Main.UserID, butToan.NoTaiKhoan ?? 0) || TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, PSC_ERP_Global.Main.UserID, butToan.CoTaiKhoan ?? 0))
                {
                    return true;
                }
            }
            return false;
        }

        private void LockgrdView_DinhKhoan()
        {
            grdViewDinhKhoan_ButToan.Columns[0].OptionsColumn.AllowEdit = false;//"colNoTaiKhoan"
            grdViewDinhKhoan_ButToan.Columns[1].OptionsColumn.AllowEdit = false;//"colCoTaiKhoan"
            grdViewDinhKhoan_ButToan.Columns[2].OptionsColumn.AllowEdit = false;//"colSoTien"
            grdViewDinhKhoan_ButToan.Columns[3].OptionsColumn.AllowEdit = false;//"colDoiTuongNo"
            grdViewDinhKhoan_ButToan.Columns[4].OptionsColumn.AllowEdit = false;//"colDoiTuongCo"
            grdViewDinhKhoan_ButToan.Columns[5].OptionsColumn.AllowEdit = false;//"colHopDong"
            grdViewDinhKhoan_ButToan.Columns[6].OptionsColumn.AllowEdit = false;//"colDienGiai"
        }//Them

        private void UnLockgrdView_DinhKhoan()
        {
            grdViewDinhKhoan_ButToan.Columns[0].OptionsColumn.AllowEdit = true;//"colNoTaiKhoan"
            grdViewDinhKhoan_ButToan.Columns[1].OptionsColumn.AllowEdit = true;//"colCoTaiKhoan"
            grdViewDinhKhoan_ButToan.Columns[2].OptionsColumn.AllowEdit = true;//"colSoTien"
            grdViewDinhKhoan_ButToan.Columns[3].OptionsColumn.AllowEdit = true;//"colDoiTuongNo"
            grdViewDinhKhoan_ButToan.Columns[4].OptionsColumn.AllowEdit = true;//"colDoiTuongCo"
            grdViewDinhKhoan_ButToan.Columns[5].OptionsColumn.AllowEdit = true;//"colHopDong"
            grdViewDinhKhoan_ButToan.Columns[6].OptionsColumn.AllowEdit = true;//"colDienGiai"
        }//Them

        private void grdViewDinhKhoan_ButToan_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            tblButToan currentButToan = grdViewDinhKhoan_ButToan.GetRow(e.RowHandle) as tblButToan;
            tblKy ky = Ky_Factory.New().XacDinhKy_ByNgay(_chungTu.NgayLap.Value);
            if (currentButToan != null)
            {
                if (TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, PSC_ERP_Global.Main.UserID, currentButToan.NoTaiKhoan ?? 0) || TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, PSC_ERP_Global.Main.UserID, currentButToan.CoTaiKhoan ?? 0))
                {
                    //DialogUtil.ShowWarning("Tài khoản đã được khóa trong kỳ!\nBạn không thể thay đổi thông tin của tài khoản này\nVui lòng liên hệ người khóa tài khoản để thực hiện tiếp nghiệp vụ", "Cảnh báo");
                    LockgrdView_DinhKhoan();
                }
                else
                {
                    UnLockgrdView_DinhKhoan();
                }
            }
            else
            {
                UnLockgrdView_DinhKhoan();
            }
        }

        private void cbNoTaiKhoan_ForGrid_EditValueChanged(object sender, EventArgs e)
        {
            tblButToan currentButToan = grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
            GridLookUpEdit gridLUED = sender as GridLookUpEdit;
            tblTaiKhoan taiKhoanNo = gridLUED.GetSelectedDataRow() as tblTaiKhoan;
            PSC_ERP.HamDungChung.KiemTraKhoaTaiKhoan(currentButToan, gridLUED, taiKhoanNo, _chungTu.NgayLap.Value, PSC_ERP_Global.Main.UserID, true);//là nợ
        }

        private void cbCoTaiKhoan_ForGrid_EditValueChanged(object sender, EventArgs e)
        {
            tblButToan currentButToan = grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
            GridLookUpEdit gridLUED = sender as GridLookUpEdit;
            tblTaiKhoan taiKhoanCo = gridLUED.GetSelectedDataRow() as tblTaiKhoan;
            PSC_ERP.HamDungChung.KiemTraKhoaTaiKhoan(currentButToan, gridLUED, taiKhoanCo, _chungTu.NgayLap.Value, PSC_ERP_Global.Main.UserID, false);//là có
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_chungTu.MaChungTu == 0)
            {
                DialogUtil.ShowInfo("Vui lòng lưu chứng từ trước khi up file!");
                return;
            }
            else
            {
                frmDigitizing_ChonFilesUpLoad frm_upFile = new frmDigitizing_ChonFilesUpLoad(_chungTu.MaChungTu);
                frm_upFile.ShowDialog();
            }
        }

        private void cbDoiTac_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//refresh danh sách tài sản cố đinh
            {
                frmNhaCungCapCustomize frm = new frmNhaCungCapCustomize();
                frm.ShowDialog();
                _doiTacList = DoiTac_Factory.New().GetAll();
                tblDoiTacBindingSource.DataSource = _doiTacList;
            }
        }

        private void grdViewCT_NghiepVuSuaChuaLon_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "colThoiGianDaKhauHaoTruocSCL" && e.Column.Name != "colThoiGianTinhKhauHaoConLai" && e.Column.Name != "colThoiGianSuDungMoi")
                return;
            tblCT_NghiepVuSuaChuaLon currentButToan = grdViewCT_NghiepVuSuaChuaLon.GetRow(e.RowHandle) as tblCT_NghiepVuSuaChuaLon;
            if (currentButToan == null)
                return;
            if (e.Column.Name == "colThoiGianDaKhauHaoTruocSCL")
            {
                if (currentButToan.ThoiGianSuDung != null)
                    currentButToan.ThoiGianTinhKhauHaoConLai = currentButToan.ThoiGianSuDung - currentButToan.ThoiGianDaKhauHaoTruocSCL;
                else if(currentButToan.ThoiGianTinhKhauHaoConLai != null)
                    currentButToan.ThoiGianSuDung = currentButToan.ThoiGianTinhKhauHaoConLai + currentButToan.ThoiGianDaKhauHaoTruocSCL;
            }
            else if (e.Column.Name == "colThoiGianTinhKhauHaoConLai")
            {
                if (currentButToan.ThoiGianDaKhauHaoTruocSCL != null)
                    currentButToan.ThoiGianSuDung = currentButToan.ThoiGianTinhKhauHaoConLai + currentButToan.ThoiGianDaKhauHaoTruocSCL;
                else if(currentButToan.ThoiGianSuDung != null)
                    currentButToan.ThoiGianDaKhauHaoTruocSCL = currentButToan.ThoiGianSuDung - currentButToan.ThoiGianTinhKhauHaoConLai;
            }
            else if (e.Column.Name == "colThoiGianSuDungMoi")
            {
                if (currentButToan.ThoiGianDaKhauHaoTruocSCL != null)
                    currentButToan.ThoiGianTinhKhauHaoConLai = currentButToan.ThoiGianSuDung - currentButToan.ThoiGianDaKhauHaoTruocSCL;
                else if(currentButToan.ThoiGianTinhKhauHaoConLai != null)
                    currentButToan.ThoiGianDaKhauHaoTruocSCL = currentButToan.ThoiGianSuDung - currentButToan.ThoiGianTinhKhauHaoConLai;
            }
        }
    }
}