using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using PSC_ERP_Common.Ado.Net;
using PSC_ERPNew.Main.PhanHe.TSCD.UsefulDialog;
using PSC_ERPNew.Main.Reports;
using System.Net.Mail;
using System.Net;
using ERP_Library.Security;

using PSC_ERP;
using Csla;
//Định khoản -> Chứng từ -> Tiền tệ
namespace PSC_ERPNew.Main
{
    public partial class frmGhiTangTSCDCaBiet : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmGhiTangTSCDCaBiet singleton_ = null;
        public static frmGhiTangTSCDCaBiet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmGhiTangTSCDCaBiet();
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
        ChungTuGhiTangTaiSan_DerivedFactory _factory = null;

        tblChungTu _chungTu = null;
        IQueryable<tblTaiKhoan> _taiKhoanNoList = null;
        IQueryable<tblTaiKhoan> _taiKhoanCoList = null;
        IQueryable<tblDoiTac> _doiTacList = null;
        IQueryable<tblnsBoPhan> _boPhanList = null;
        IQueryable<tblBoPhanERPNew> _viTriList = null;
        List<tblHopDong> _hopDongList = null;

        Boolean _daLoadXong = false;
        Boolean _taoMoiChungTu = true;
        Boolean _forceClose = false;
        long _maChungTuGhiTangCuCanXemLai = 0;
        tblChungTu _objFromAnotherFactory = null;
        DateTime? _ngayBanDau = DateTime.MinValue;
        Boolean _themMoiButToan = true;

        UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        int _maCongTy = CurrentUser.Info.MaCongTy;
        //// phân quyền
        public string strStatus = "KHOA";
        ERP_Library.PhanQuyenSuDungForm _phanQuyen = null;


        #endregion

        //Member Constructor
        #region Member Constructor
        public frmGhiTangTSCDCaBiet()
        {
            InitializeComponent();
            grdTSCDCaBiet.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            _taoMoiChungTu = true;
        }

        public frmGhiTangTSCDCaBiet(tblChungTu chungTu)//(long maChungTuGhiTang)
        {
            InitializeComponent();
            grdTSCDCaBiet.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            _taoMoiChungTu = false;
            _objFromAnotherFactory = chungTu;
            _maChungTuGhiTangCuCanXemLai = chungTu.MaChungTu;
            LoadChungTuCu(_maChungTuGhiTangCuCanXemLai);
        }

        public frmGhiTangTSCDCaBiet(long maChungTuGhiTang)
        {
            InitializeComponent();
            grdTSCDCaBiet.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            _taoMoiChungTu = false;
            _maChungTuGhiTangCuCanXemLai = maChungTuGhiTang;
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
        private void XoaDanhSachTaiSan(List<Object> deleteList)
        {
            //kiểm tra tài sản đã phát sinh nghiệp vụ điều chuyển nội bộ
            foreach (tblTaiSanCoDinhCaBiet item in deleteList)
            {
                if (TaiSanCoDinhCaBiet_Factory.KiemTraTSCDCaBietDaPhatSinhNghiepVuInMaVach(item.MaTSCDCaBiet))
                {
                    DialogUtil.ShowError(string.Format("Tài sản [{0}] đã phát sinh nghiệp vụ In Mã vạch \n\nVui lòng xóa bỏ mã vạch tài sản trước khi xóa", item.SoHieu));
                    deleteList.Remove(item);
                }
                if (TaiSanCoDinhCaBiet_Factory.KiemTraTSCDCaBietDaPhatSinhNghiepVuDieuChuyenNoiBo(item.MaTSCDCaBiet))
                {
                    DialogUtil.ShowError(string.Format("Tài sản [{0}] đã phát sinh nghiệp vụ điều chuyển nội bộ", item.SoHieu));
                    deleteList.Remove(item);
                }
            }
            //xóa tài sản
            TaiSanCoDinhCaBiet_Factory.FullDeleteTSCDCaBiet(context: _factory.Context, deleteList: deleteList);
        }
        private void ThemChiTietNguyenGiaTheoTaiSanCaBiet(tblTaiSanCoDinhCaBiet taiSanCaBiet)
        {
            tblChiTietNguyenGiaTSCD chiTietNguyenGia = ChiTietNguyenGiaTSCD_Factory.New().CreateAloneObject();
            //chiTietNguyenGia.SoTien = taiSanCaBiet.NguyenGiaMua; lấy sai, sửa lại ngày 21-07-2021
            chiTietNguyenGia.SoTien = taiSanCaBiet.NguyenGiaTinhKhauHao;
            chiTietNguyenGia.LuyKeKhauHao = taiSanCaBiet.LuyKeKhauHao;
            chiTietNguyenGia.LuyKeHaoMon = taiSanCaBiet.LuyKeHaoMon;
            chiTietNguyenGia.NgayThucHien = (DateTime?)dteNgayChungTu.DateTime.Date;
            chiTietNguyenGia.LoaiPhanBietNV = (Byte)ChiTietNguyenGiaTSCD_LoaiPhanBietNVEnum.TaiSanGoc;//tài sản gốc
            //đưa vào danh sách
            _chungTu.tblChiTietNguyenGiaTSCDs.Add(chiTietNguyenGia);
            taiSanCaBiet.tblChiTietNguyenGiaTSCDs.Add(chiTietNguyenGia);
        }

        private void TaoMoiPhanBoTaiSanCaBiet(tblTaiSanCoDinhCaBiet taiSanCaBiet, Int32 maPhongBan, Int32 maViTri)
        {
            tblTaiSanCoDinhCaBiet_PhongBan ts_pb = TaiSanCoDinhCaBiet_PhongBan_Factory.New().CreateAloneObject();
            //gán mã phòng ban
            ts_pb.MaPhongBan = maPhongBan;
            ts_pb.MaViTri = maViTri;
            //gán ngày phân bổ là ngày chứng từ
            ts_pb.NgayPhanBo = _chungTu.NgayLap;
            //gán user tạo
            ts_pb.UserID = _user.UserID;
            //đưa phân bổ vào danh sách phân bổ của tài sản
            taiSanCaBiet.tblTaiSanCoDinhCaBiet_PhongBan.Add(ts_pb);
        }
        private void LayDanhSachNoCoTaiKhoan()
        {
            IQueryable<tblTaiKhoan> taiKhoanList = TaiKhoan_Factory.New().GetAll();
            _taiKhoanNoList = taiKhoanList;//TaiKhoan_Factory.New().Get_DanhSachTaiKhoanNo();
            _taiKhoanCoList = taiKhoanList;//TaiKhoan_Factory.New().Get_DanhSachTaiKhoanCo();
        }

        private void KhoiTaoChungTuMoi()
        {
            //chưa load xong
            _daLoadXong = false;
            {
                //_taoMoiChungTu = true;
                //_maChungTuGhiTangCuCanXemLai = 0;
                //khởi tạo mới chứng từ factory
                _factory = ChungTuGhiTangTaiSan_DerivedFactory.New();
                //khởi tạo chứng từ mới 
                _chungTu = _factory.NewChungTuGhiTangTaiSan();
                _chungTu.MaCongTy = _user.MaCongTy;
                //gán bindingSource
                GanBindingSource();
                //
                //cbTinhChatSoDuTaiKhoan.EditValue = (Int32)TinhChatSoDuTaiKhoanEnum.Co;
            }
            //đã load xong
            _daLoadXong = true;
        }

        private void LoadChungTuCu(long maChungTuGhiTang)
        {
            //chưa load xong
            _daLoadXong = false;
            {
                //khởi tạo mới chứng từ factory
                _factory = ChungTuGhiTangTaiSan_DerivedFactory.New();
                //load chứng từ được quản lý bởi _factory
                _chungTu = _factory.Get_ChungTu_ByMaChungTu(maChungTuGhiTang);
                //nếu Duyệt sẽ không cho sửa ngày chứng từ
                if (_chungTu.TrangThai == 1)
                {
                    this.dteNgayChungTu.Properties.ReadOnly = true;
                }
                //gán bindingSource
                GanBindingSource();
                #region old
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
                #endregion
                LayDanhSachHopDongCuaChungTu();//LayDanhSachHopDongTheoDoiTac(_chungTu.MaDoiTuong ?? 0);
            }
            //đã load xong
            _daLoadXong = true;
        }

        private void GanBindingSource()
        {
            //gán bindingSource
            tblChungTuBindingSource_Single.DataSource = _chungTu;
            tblTienTeBindingSource_Single.DataSource = _chungTu.tblTienTe;
            //
            tblTaiSanCoDinhCaBietBindingSource.DataSource = _chungTu.tblTaiSanCoDinhCaBiets;
            //
            tblBoPhanBindingSource.DataSource = _boPhanList;
            tblBoPhanERPNewBindingSource.DataSource = _viTriList;
            //
            {
                tblDinhKhoanBindingSource_Single.DataSource = _chungTu.tblDinhKhoan;
                tblButToanBindingSource.DataSource = _chungTu.tblDinhKhoan.tblButToans;
                tblChungTuHopDongTaiSanBindingSource.DataSource = _chungTu.tblChungTu_HopDongTaiSan;
                tblChungTuHoaDonBindingSource.DataSource = _chungTu.tblChungTu_HoaDon;
                //new
                tblChungTuHoaDonMuaSuaBanTaiSanBindingSource.DataSource = _chungTu.tblChungTu_HoaDonTaiSanMuaSuaBan;
                //
                //tinhChatSoDuTaiKhoanBindingSource.DataSource = PSC_ERP_Business.Main.Predefined.TinhChatSoDuTaiKhoan.TinhChatSoDuTaiKhoanList;
                //tài khoản
                tblTaiKhoanBindingSource_No.DataSource = _taiKhoanNoList;
                tblTaiKhoanBindingSource_Co.DataSource = _taiKhoanCoList;
            }
            //thuế suất VAT
            ThueSuatVAT_bindingSource.DataSource = ThueSuatVAT.ThueSuatVATList;
            txtTongChiPhi.EditValue = _chungTu.TongTienChiPhi;
            gridLookUpEdit_ThueSuatVAT.EditValue = _chungTu.PhamTramThue;
            txt_TongChiPhiCoThue.EditValue = _chungTu.TongChiPhiCoThue;
            radioDuyet.EditValue = _chungTu.TrangThai;
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
            _boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(_user.MaCongTy);
            _viTriList = BoPhanERPNew_Factory.New().GetAll();
        }

        void LoadDoiTac_Helper()
        {
            _doiTacList = DoiTac_Factory.New().GetAll();
            tblDoiTacBindingSource.DataSource = _doiTacList;
        }
        private Boolean DuocPhepLuu()
        {
            Ky_Factory ky_Factory = Ky_Factory.New();
            if (_chungTu.tblTaiSanCoDinhCaBiets.Count == 0)
            {
                DialogUtil.ShowWarning("Không lưu chứng từ trống không có tài sản hay công cụ dụng cụ!");
                return false;
            }
            if ((_chungTu.MaDoiTuong ?? 0) == 0)
            {
                DialogUtil.ShowWarning("Vui lòng chọn nhà cung cấp!\nNhà cung cấp không được bỏ trống!");
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
            //kiểm tra nếu có tài khoản bị khóa sổ trong kỳ
            if (KiemTraCoTaiKhoanKhoaSo(_chungTu.NgayLap.Value) && dteNgayChungTu.Properties.ReadOnly == false)
            {
                DialogUtil.ShowError("Bạn đã nhập định khoản trước rồi thay đổi ngày trong kỳ có tài khoản khóa số!\nHệ thống sẽ tự động trả lại ngày ban đầu của chứng từ\n\nNếu muốn đổi ngày vui lòng xóa dòng định khoản có tài khoản không bị khóa trong kỳ bạn muốn đổi tới!", "Không lưu được");
                _chungTu.NgayLap = _ngayBanDau;
                return false;
            }

            if (ky_Factory.DaKhoaSoTSCD(_chungTu.NgayLap.Value, _user.MaCongTy))
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
                    _chungTu.MaChungTuQL = _factory.Get_NextMaChungTuQL_ByYear_And_Month(_chungTu.NgayLap.Value.Year, _chungTu.NgayLap.Value.Month, _user.MaCongTy);
                    //đệ quyp
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
                    _chungTu.SoChungTu = _factory.Get_NextMaChungTuQL_ByYear_And_Month(_chungTu.NgayLap.Value.Year, _chungTu.NgayLap.Value.Month, _user.MaCongTy);
                    //đệ quy
                    return DuocPhepLuu();
                }
                else
                    return false;
            }
            decimal tongTienChiPhi = 0, tongTienChiPhiCoThue = 0;
            foreach (tblTaiSanCoDinhCaBiet tscdcb in _chungTu.tblTaiSanCoDinhCaBiets)
            {
                tongTienChiPhi += tscdcb.ChiPhi.Value;
                tongTienChiPhiCoThue += tscdcb.ChiPhiCoThue.Value;
            }
            if (tongTienChiPhi != (decimal)txtTongChiPhi.EditValue)
            {
                DialogUtil.ShowWarning("Tổng chi phí không khớp vui lòng nhấn nút phân bổ chi phí/ tiền thuế hoặc nhập lại số tổng chi phí cho khớp!");
                return false;
            }
            if (tongTienChiPhiCoThue != (decimal)txt_TongChiPhiCoThue.EditValue)
            {
                DialogUtil.ShowWarning("Tổng tiền thuế không khớp vui lòng nhấn nút phân bổ chi phí/ tiền thuế hoặc nhập lại số tổng tiền thuế cho khớp!");
                return false;
            }
            if (_chungTu.KiemTraDinhKhoan(kiemTraSoTienChungTuBangSoTienButToan: false) == false)
                return false;

            if (_chungTu.KiemTraHoaDon() == false)
                return false;
            _chungTu.NgayHeThong = DateTime.Now;
            return true;
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
            string emailNhan = string.Empty, emailGui = string.Empty, matKhauEmailGui = string.Empty;
            emailNhan = _user.EmailDenTang;
            emailGui = _user.EmailGui;
            matKhauEmailGui = _user.MatKhauEmailGui;
            txtBlackHole.Focus();
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
                            if ((Int32)radioDuyet.EditValue == 0)
                            {
                                duyet = false;
                                _chungTu.HoanTat = false;
                                if (_user.GroupID == 38)
                                {
                                    foreach (tblTaiSanCoDinhCaBiet tscdcb in _chungTu.tblTaiSanCoDinhCaBiets)
                                    {
                                        tscdcb.SuDung = false;
                                        tscdcb.TinhTrang = "Không Duyệt Chứng Từ, Chưa Sử Dụng";
                                    }
                                    emailNhan = userLap.EmailHRM;
                                    SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Không Duyệt Chứng Từ {_chungTu.MaChungTuQL}",
                                        "Chứng từ mua sắm TSCĐ hay CCDC có số mã quản lý: " + _chungTu.MaChungTuQL + " không được duyệt! Với lý do: " + _chungTu.LyDo);
                                }
                                else
                                {
                                    _chungTu.TrangThai = null;
                                    SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đề Nghị Duyệt Chứng Từ {_chungTu.MaChungTuQL}",
                                        "Đề nghị duyệt chứng từ mua sắm TSCĐ hay CCDC có số mã quản lý: " + _chungTu.MaChungTuQL + " với nội dung:" + _chungTu.DienGiai);
                                }
                            }
                            else
                            {
                                duyet = true;
                                _chungTu.HoanTat = true;
                                _chungTu.UserIDNgDuyetCongTy = _user.UserID;
                                _chungTu.NgayDuyetCongTy = DateTime.Today.Date;
                                foreach (tblTaiSanCoDinhCaBiet tscdcb in _chungTu.tblTaiSanCoDinhCaBiets)
                                {
                                    if (tscdcb.SuDung == true) tscdcb.TinhTrang = "Đang Sử Dụng";
                                    else tscdcb.TinhTrang = "Chưa Sử Dụng";
                                }
                                SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đã Duyệt Chứng Từ {_chungTu.MaChungTuQL}",
                                    "Chứng từ mua sắm TSCĐ hay CCDC có số mã quản lý: " + _chungTu.MaChungTuQL + " đã được duyệt! với lý do: " + _chungTu.LyDo);
                            }
                        }
                        else
                        {
                            SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đề Nghị Duyệt Chứng Từ {_chungTu.MaChungTuQL}",
                                "Đề nghị duyệt chứng từ mua sắm TSCĐ hay CCDC có số mã quản lý: " + _chungTu.MaChungTuQL + " với nội dung:" + _chungTu.DienGiai);
                        }
                        foreach (tblTaiSanCoDinhCaBiet tscdcb in _chungTu.tblTaiSanCoDinhCaBiets)
                        {
                            tscdcb.MaNhaCungCap = _chungTu.MaDoiTuong;
                        }
                        _factory.SaveChangesWithoutTrackingLog();
                    }
                    DialogUtil.ShowSaveSuccessful();
                    return true;
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful(ex.Message);
                }
            return false;
        }
        private List<tblnsBoPhan> LayDanhSachBoPhanTrongDanhSachTaiSanCuaChungTu()
        {
            List<tblnsBoPhan> list = new List<tblnsBoPhan>();
            foreach (var item in _chungTu.tblTaiSanCoDinhCaBiets)
            {
                //item.PhanBoDauTien_RefObj.tblBoPhanERPNew
                //list.Remove(item.PhanBoDauTien_RefObj.tblBoPhanERPNew);
                list.RemoveAll(x => x.MaBoPhan == item.PhanBoDauTien_RefObj.MaPhongBan);
                list.Add(item.PhanBoDauTien_RefObj.tblnsBoPhan);
            }

            return list;
        }
        private List<tblBoPhanERPNew> LayDanhSachViTriTrongDanhSachTaiSanCuaChungTu()
        {
            List<tblBoPhanERPNew> list = new List<tblBoPhanERPNew>();
            foreach (var item in _chungTu.tblTaiSanCoDinhCaBiets)
            {
                //item.PhanBoDauTien_RefObj.tblBoPhanERPNew
                //list.Remove(item.PhanBoDauTien_RefObj.tblBoPhanERPNew);
                list.RemoveAll(x => x.MaBoPhan == item.PhanBoDauTien_RefObj.MaViTri);
                list.Add(item.PhanBoDauTien_RefObj.tblBoPhanERPNew);
            }
            return list;
        }
        private void TinhThueChiPhiTaiSanCoDinhCaBiet()
        {
            decimal tongChiPhi = 0, phanTramThueChiPhi = 0, tongTienThueChiPhi = 0, tongChiPhiCoThue = 0;
            tongChiPhi = Decimal.Parse(txtTongChiPhi.EditValue.ToString() == "" ? "0" : txtTongChiPhi.EditValue.ToString());
            _chungTu.TongTienChiPhi = tongChiPhi;
            phanTramThueChiPhi = Decimal.Parse(gridLookUpEdit_ThueSuatVAT.EditValue.ToString() == "" ? "0" : gridLookUpEdit_ThueSuatVAT.EditValue.ToString());
            _chungTu.PhamTramThue = phanTramThueChiPhi;
            tongTienThueChiPhi = Math.Floor(phanTramThueChiPhi * tongChiPhi / 100);
            tongChiPhiCoThue = tongChiPhi + tongTienThueChiPhi;
            _chungTu.TongChiPhiCoThue = tongChiPhiCoThue;
            txt_TongChiPhiCoThue.EditValue = tongChiPhiCoThue;
        }
        private void CapNhatLaiTongTien()
        {
            //cập nhật lại tổng tiền chứng từ
            Decimal tongTien = 0;
            if (_chungTu != null)
            {
                foreach (var item in _chungTu.tblTaiSanCoDinhCaBiets)
                {
                    if (item.IsTinhThue == true)
                    {
                        tongTien += item.NguyenGiaMua.Value;
                        item.NguyenGiaTinhKhauHao = item.TongNguyenGiaCoThue.Value;
                    }
                    else
                    {
                        tongTien += item.NguyenGiaMua.Value;
                        item.NguyenGiaTinhKhauHao = item.TongNguyenGiaKhongThue.Value;
                    }
                    foreach (var item1 in item.tblTaiSanCoDinhCaBiet_PhongBan)
                    {
                        item1.NgayPhanBo = Convert.ToDateTime(dteNgayChungTu.DateTime.Date);
                    }
                }
                foreach (var item in _chungTu.tblChiTietNguyenGiaTSCDs)
                {
                    item.NgayThucHien = Convert.ToDateTime(dteNgayChungTu.DateTime.Date);
                }

                txtSoTien.EditValue = tongTien;
                _chungTu.tblTienTe.SoTien = tongTien;
            }
        }
        #endregion


        //Event Method
        #region Event Method

        private void frmGhiTangTSCDCaBiet_Load(object sender, EventArgs e)
        {
            // Đưa checkbox lên lưới
            // GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewTSCDCaBiet, colSuDung);
            // app_users user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);           

            this.Shown += (senderz, ez) =>
                          {
                              using (DialogUtil.Wait(this))
                              {
                                  //load đối tác
                                  LoadDoiTac_VaBoPhan();
                                  //
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
                                      LoadChungTuCu(_maChungTuGhiTangCuCanXemLai);
                                      txtTongChiPhi.EditValue = _chungTu.TongTienChiPhi;
                                      gridLookUpEdit_ThueSuatVAT.EditValue = _chungTu.PhamTramThue;
                                      txt_TongChiPhiCoThue.EditValue = _chungTu.TongChiPhiCoThue;
                                      radioDuyet.EditValue = _chungTu.TrangThai;
                                  }
                                  //lấy ngày ban đầu của chứng từ để cập nhật lại
                                  _ngayBanDau = _chungTu.NgayLap.Value;
                                  //cài đặt master-details
                                  {
                                      GridUtil.InitDetailForGridView<tblButToan>(grdViewDinhKhoan_ButToan, tblButToan.tblChungTu_HoaDon_EntityCollectionPropertyName, 0, 1);
                                  }
                                  //cài đặt double click event cho grid view tài sản cá biệt
                                  GridUtil.DoubleClickHelper.Setup(this.grdViewTSCDCaBiet, (senderz1, ez1) =>
                                                                                           {
                                                                                               GridView view = senderz1 as GridView;
                                                                                               tblTaiSanCoDinhCaBiet taiSanCaBiet = view.GetFocusedRow() as tblTaiSanCoDinhCaBiet;
                                                                                               if (taiSanCaBiet != null)
                                                                                               {
                                                                                                   if (_chungTu != null)
                                                                                                   {
                                                                                                       if (_chungTu.TrangThai == 1 && _user.GroupID != 38 && _user.GroupID != 2) return;
                                                                                                   }
                                                                                                   using (frmDialogThongTinTSCDCaBiet frm = new frmDialogThongTinTSCDCaBiet(taiSanCaBiet))
                                                                                                   {
                                                                                                       frm.ShowDialog();
                                                                                                   }
                                                                                                   this.CapNhatLaiTongTien();
                                                                                               }
                                                                                           });
                                  // Cài đặt lưới
                                  GridUtil.SetSTTForGridView(new GridView[] { this.grdViewTSCDCaBiet, this.grdViewDinhKhoan_ButToan, this.grdViewChungTu_HopDong, this.gridViewHoaDon, this.gridView_ButToanHoaDon });
                                  //copy cell
                                  GridUtil.InitCopyCellForGridView(this.grdViewTSCDCaBiet, this.grdViewDinhKhoan_ButToan);
                                  //multi cell select
                                  GridUtil.InitMultiCellSelectForGridView(this.grdViewTSCDCaBiet, grdViewChungTu_HopDong, grdViewDinhKhoan_ButToan);
                                  //cài đặt delete helper
                                  GridUtil.DeleteHelper.Setup_ManualType(grdViewTSCDCaBiet, (gridView, deleteList) =>
                                                                                            {
                                                                                                XoaDanhSachTaiSan(deleteList);
                                                                                                //tính lại tổng tiền chứng từ
                                                                                                //this.CapNhatLaiTongTien();
                                                                                            });
                                  //new
                                  GridUtil.DeleteHelper.Setup_ManualType(gridViewHoaDon, (gridView, deleteList) =>
                                                                                         {
                                                                                             XoaDanhSachChungTu_HoaDonTaiSan(deleteList);
                                                                                         });
                                  GridUtil.DeleteHelper.Setup_ManualType(gridView_ButToanHoaDon, (gridView, deleteList) =>
                                                                                                 {
                                                                                                     ChungTu_HoaDon_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
                                                                                                 });
                                  GridUtil.DeleteHelper.Setup_ManualType(grdViewChungTu_HopDong, (gridView, deleteList) =>
                                                                                                 {
                                                                                                     XoaDanhSachChungTu_HopDong(deleteList);
                                                                                                     //ChungTu_HopDong_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
                                                                                                 });
                                  GridUtil.DeleteHelper.Setup_ManualType(grdViewDinhKhoan_ButToan, (gridView, deleteList) =>
                                                                                                   {
                                                                                                       //ButToan_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
                                                                                                       tblKy ky = Ky_Factory.New().XacDinhKy_ByNgay(_chungTu.NgayLap.Value);
                                                                                                       ButToan_Factory.FullDeleteKiemTraKhoaTaiKhoan(_factory.Context, deleteList, _user.UserID, ky.MaKy);
                                                                                                   });
                              }
                          };
            if (_user.TenDangNhap.ToLower().Equals("admin") || _user.GroupID == 38)
            {
                // tabDinhKhoan.PageVisible = true;
                panelControl_Duyet.Enabled = true;

                grdViewTSCDCaBiet.Columns["ThoiGianSuDung"].OptionsColumn.ReadOnly = false;
            }
            else
            {
                panelControl_Duyet.Enabled = false;
                // tabDinhKhoan.PageVisible = false;   
                if (_chungTu != null)
                {
                    if (_chungTu.TrangThai == 1) ReadOnlyConTrolByStatus();
                }
            }
            PhanQuyenThemSuaXoa();

        }

        // phân quyền

        private void PhanQuyenThemSuaXoa()
        {
            _phanQuyen = ERP_Library.PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            btnThemMoi.Enabled = _phanQuyen.Them;
            // btnSave.Enabled = _phanQuyen.Sua;
            if (_phanQuyen.Them == true || _phanQuyen.Sua == true)
            {
                btnSave.Enabled = true;
            }
            else
                btnSave.Enabled = false;
            btnXoaChungTu.Enabled = _phanQuyen.Xoa;
        }
        private void ReadOnlyConTrolByStatus()
        {
            grdViewTSCDCaBiet.OptionsBehavior.ReadOnly = true;
            grdViewChungTu_HopDong.OptionsBehavior.ReadOnly = true;
            gridViewHoaDon.OptionsBehavior.ReadOnly = true;
            grdViewDinhKhoan_ButToan.OptionsBehavior.ReadOnly = true;
            gridView_ButToanHoaDon.OptionsBehavior.ReadOnly = true;
            cbDoiTac.ReadOnly = true;
            foreach (Control c in groupControl1.Controls)
            {
                if (c is GridLookUpEdit)
                {
                    ((GridLookUpEdit)c).Properties.ReadOnly = true;
                }
                else if (c is TextEdit)
                {
                    ((TextEdit)c).Properties.ReadOnly = true;
                }
                else if (c is DateEdit)
                {
                    ((DateEdit)c).Properties.ReadOnly = true;
                }
                else if (c is SimpleButton)
                {
                    ((SimpleButton)c).Enabled = false;
                }
                else if (c is PanelControl) { ((PanelControl)c).Controls.Owner.Enabled = false; }
            }

            btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnThemTSCDCaBiet.Enabled = false; btnXoaDongTaiSan.Enabled = false;
            btnXoaChungTu_HopDong.Enabled = false; btnGoBoHoaDon.Enabled = false;
        }

        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_GhiTang, this.MdiParent);
        }
        private void dteNgayChungTu_EditValueChanged(object sender, EventArgs e)
        {
            //cập nhật lại ngày lập
            if (dteNgayChungTu.DateTime.Date != new DateTime(1, 1, 1) && dteNgayChungTu.DateTime.Date != _chungTu.NgayLap)//
            {
                _chungTu.NgayLap = (DateTime?)dteNgayChungTu.DateTime.Date;
                _chungTu.NgayThucHien = _chungTu.NgayLap;
                if (_chungTu.MaChungTu == 0)
                {
                    //Phát sinh mã
                    _chungTu.MaChungTuQL = _factory.Get_NextMaChungTuQL_ByYear_And_Month(_chungTu.NgayLap.Value.Year, _chungTu.NgayLap.Value.Month, _user.MaCongTy);
                    _chungTu.SoChungTu = ChungTu_Factory.New().Get_NextSoChungTuPhieuKeToanTaiSan_ByYear_and_Month(_chungTu.NgayLap.Value.Year, _chungTu.NgayLap.Value.Month, _user.MaCongTy);
                }

            }
            //duyệt qua từng dòng tài sản
            foreach (var item in _chungTu.tblTaiSanCoDinhCaBiets)
            {
                {
                    //01-cập nhật lại ngày sử dụng
                    if (item.NgayChungTu == item.NgaySuDung)
                        item.NgaySuDung = _chungTu.NgayLap;
                    //02-cập nhật lại ngày chứng từ cho dòng tài sản ghi tăng
                    item.NgayChungTu = _chungTu.NgayLap;
                }
                //cập nhật lại ngày phân bổ cho phòng ban đầu tiên
                foreach (var item1 in item.tblTaiSanCoDinhCaBiet_PhongBan)
                {
                    item1.NgayPhanBo = Convert.ToDateTime(dteNgayChungTu.DateTime.Date);
                }
            }
            foreach (var item in _chungTu.tblChiTietNguyenGiaTSCDs)
            {
                item.NgayThucHien = Convert.ToDateTime(dteNgayChungTu.DateTime.Date);
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

        private void frmGhiTangTSCDCaBiet_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_factory == null) return;
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

        private void btnThemTSCDCaBiet_Click(object sender, EventArgs e)
        {
            tblCongTy congTy_Factory = CongTy_Factory.New().Get_ByID(_user.MaCongTy);
            int temp = _maCongTy;
            bool _isTinhThue = Convert.ToBoolean(congTy_Factory.CongThue);
            string _soHoaDon = string.Empty, _soHopDong = string.Empty;
            if (_chungTu.tblTaiSanCoDinhCaBiets.Count > 0)
            {
                _soHoaDon = _chungTu.tblTaiSanCoDinhCaBiets.Last().SoHoaDon;
                _soHopDong = _chungTu.tblTaiSanCoDinhCaBiets.Last().SoHopDong;
            }
            using (frmDialogThongTinTSCDCaBiet_GhiTangHangLoat frm = new frmDialogThongTinTSCDCaBiet_GhiTangHangLoat(_soHoaDon, _soHopDong))
            {//show form thông tin TSCD cá biệt ghi tăng   
                frm._NgayChungtu = (DateTime)_chungTu.NgayLap;
                DialogResult dlgResult = frm.ShowDialog(this);
                if (dlgResult == DialogResult.Yes)//button đưa dữ liệu về chứng từ ghi tăng
                {
                    //lấy số lượng tài sản cá biệt
                    Int32 soLuong = frm.SoLuongTaiSanCaBiet;
                    Int32 maPhongBan = frm.MaBoPhan;
                    Int32 maViTri = frm.MaViTri;
                    //lấy tài sản đầu tiên
                    tblTaiSanCoDinhCaBiet taiSanDauTien = frm.TaiSanCoDinhCaBiet;
                    taiSanDauTien.MaCongTy = _user.MaCongTy;
                    taiSanDauTien.TienThue = 0;
                    taiSanDauTien.ChiPhiCoThue = 0;
                    taiSanDauTien.SuDung = true;
                    //kiểm tra lại số hiệu trường hợp 1 tài sản họ nhập 2 lần chứ không nhập 1 lần:
                    foreach (tblTaiSanCoDinhCaBiet taiSanCoDinhCaBietDaCo in tblTaiSanCoDinhCaBietBindingSource)
                    {
                        if (taiSanCoDinhCaBietDaCo.SoHieu == taiSanDauTien.SoHieu)
                        {
                            taiSanDauTien.SoHieu = TaiSanCoDinhCaBiet_Factory.IncreaseSoHieuTSCDCaBiet(taiSanDauTien.SoHieu);
                        }
                    }
                    taiSanDauTien.NgayChungTu = (DateTime?)dteNgayChungTu.DateTime.Date;
                    taiSanDauTien.SoChungTu = _chungTu.MaChungTuQL;//HTV ngược đời
                    taiSanDauTien.IsTinhThue = _isTinhThue;

                    if (taiSanDauTien.IsTinhThue == true)
                    {
                        taiSanDauTien.NguyenGiaTinhKhauHao = taiSanDauTien.TongNguyenGiaCoThue.Value;
                    }
                    else
                    {
                        taiSanDauTien.NguyenGiaTinhKhauHao = taiSanDauTien.TongNguyenGiaKhongThue.Value;
                    }

                    //tạo mới chi tiết nguyên giá
                    ThemChiTietNguyenGiaTheoTaiSanCaBiet(taiSanDauTien);
                    //tạo phân bổ cho tài sản đầu tiên
                    TaoMoiPhanBoTaiSanCaBiet(taiSanDauTien, maPhongBan, maViTri);
                    //thêm tài sản đầu tiên vào danh sách
                    tblTaiSanCoDinhCaBietBindingSource.Add(taiSanDauTien);
                    //số hiệu trước
                    string preSoHieuCaBiet = taiSanDauTien.SoHieu;
                    //lặp soLuong-1 lần
                    for (int i = 1; i < soLuong; i++)
                    {
                        //tạo tài sản tiếp theo
                        tblTaiSanCoDinhCaBiet taiSanCaBietTiepTheo = TaiSanCoDinhCaBiet_Factory.BasicCloneTSCDCaBiet(taiSanDauTien);
                        //nguyên giá, chi phí tài sản sau cùng
                        if (i == soLuong - 1)
                        {
                            taiSanCaBietTiepTheo.NguyenGiaMua = frm.NguyenGiaTaiSanSauCung;
                            taiSanCaBietTiepTheo.DonGia = frm.DonGiaTaiSanSanSauCung;
                            taiSanCaBietTiepTheo.ChiPhi = frm.ChiPhiTaiSanSanSauCung;
                            taiSanCaBietTiepTheo.TienThue = frm.TienThueSanSauCung;
                            taiSanCaBietTiepTheo.SuDung = true;
                        }
                        taiSanCaBietTiepTheo.NgayChungTu = (DateTime?)dteNgayChungTu.DateTime.Date;
                        //tăng số hiệu lên 1 đơn vị
                        taiSanCaBietTiepTheo.IsTinhThue = _isTinhThue;
                        if (taiSanCaBietTiepTheo.IsTinhThue == true)
                        {
                            taiSanCaBietTiepTheo.NguyenGiaTinhKhauHao = taiSanCaBietTiepTheo.TongNguyenGiaCoThue.Value;
                        }
                        else
                        {
                            taiSanCaBietTiepTheo.NguyenGiaTinhKhauHao = taiSanCaBietTiepTheo.TongNguyenGiaKhongThue.Value;
                        }

                        //tăng số hiệu lên 1 đơn vị
                        taiSanCaBietTiepTheo.SoHieu = TaiSanCoDinhCaBiet_Factory.IncreaseSoHieuTSCDCaBiet(preSoHieuCaBiet);
                        //gán lại số hiệu trước
                        preSoHieuCaBiet = taiSanCaBietTiepTheo.SoHieu;

                        //tạo mới số hiệu cho các chi tiết
                        {
                            Int32 maxNum = 0;
                            foreach (var chiTietTaiSanCaBiet in taiSanCaBietTiepTheo.tblChiTietTaiSanCaBiets)
                            {
                                //foreach (tblChiTietTaiSanCaBiet chiTietTruocDo in _taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets)
                                //{
                                //    if (String.IsNullOrWhiteSpace(chiTietTruocDo.SoHieu) == false)
                                //    {
                                //        Int32 maxNumTemp = Int32.Parse(chiTietTruocDo.SoHieu.Substring(chiTietTruocDo.SoHieu.Length - PSC_ERP_Global.TSCD.SizeOf_SoHieuChiTietTSCDCaBiet_IncreasePart));
                                //        if (maxNumTemp > maxNum)
                                //            maxNum = maxNumTemp;
                                //    }
                                //}

                                String soHieuCapTren = taiSanCaBietTiepTheo.SoHieu;
                                //tạo số hiệu
                                String soHieuMoi = "";
                                if (maxNum == 0) //số hiệu đầu tiên
                                {
                                    soHieuMoi = ChiTietTaiSanCaBiet_Factory.CreateFirst_SoHieuChiTietTaiSanCaBiet(soHieuCapTren);
                                    maxNum++;
                                }
                                else//số hiệu tiếp theo
                                {
                                    soHieuMoi = ChiTietTaiSanCaBiet_Factory.Create_SoHieuChiTietTaiSanCaBiet(soHieuCapTren, maxNum + 1);
                                    maxNum++;
                                }
                                //gán số hiệu mới cho chi tiết
                                chiTietTaiSanCaBiet.SoHieu = soHieuMoi;
                            }
                        }
                        //tạo mới chi tiết nguyên giá
                        ThemChiTietNguyenGiaTheoTaiSanCaBiet(taiSanCaBietTiepTheo);
                        //tạo phân bổ tài sản tiếp theo
                        TaoMoiPhanBoTaiSanCaBiet(taiSanCaBietTiepTheo, maPhongBan, maViTri);
                        //thêm tài sản cá biệt tiếp theo vào danh sách
                        tblTaiSanCoDinhCaBietBindingSource.Add(taiSanCaBietTiepTheo);
                    }
                    //cập nhật tổng tiền
                    CapNhatLaiTongTien();
                }
            }
        }

        private void btnXoaChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();

            if (Ky_Factory.New().DaKhoaSoTSCD(_chungTu.NgayLap.Value, _user.MaCongTy))
            {
                DialogUtil.ShowDaKhoaSoTSCD(_chungTu.NgayLap.Value);
            }
            else
            {
                if (KiemTraCoTaiKhoanKhoaSo(_chungTu.NgayLap.Value))
                {
                    DialogUtil.ShowError("Có tài khoản khóa sổ không thể xóa chứng từ!");
                }
                else
                {
                    //yêu cầu người dùng xác nhận xóa
                    DialogResult dlgResult = DialogUtil.ShowDelete(this);
                    if (_chungTu.MaNguoiLap == _user.UserID && dlgResult == DialogResult.Yes)
                    {
                        try
                        {
                            using (DialogUtil.WaitForDelete(this))
                            {
                                _factory.XoaChungTuGhiTangTSCDCaBiet(_chungTu);
                                //lưu lại thay đổi
                                _factory.SaveChangesWithoutTrackingLog();
                            }
                            //thông báo đã xóa thành công
                            DialogUtil.ShowDeleteSuccessful();
                            this._forceClose = true;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            //thông báo không xóa được
                            DialogUtil.ShowNotDeleteSuccessful();
                        }
                    }
                    else
                    {
                        DialogUtil.ShowWarning("Bạn không thể xóa Chứng Từ của người khác !");
                    }
                }

            }
        }
        private void btnXoaDongTaiSan_Click(object sender, EventArgs e)
        {
            this.txtBlackHole.Focus();
            //yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn xóa những dòng tài sản đang chọn?");
            if (_chungTu.MaNguoiLap == _user.UserID && dlgResult == DialogResult.Yes)
            {
                try
                {
                    Int32[] rowHandleList = this.grdViewTSCDCaBiet.GetSelectedRows();
                    if (rowHandleList.Count() > 0)
                    {
                        List<Object> deleteList = new List<Object>();
                        foreach (var index in rowHandleList)
                        {
                            deleteList.Add(this.grdViewTSCDCaBiet.GetRow(index));
                        }
                        //
                        XoaDanhSachTaiSan(deleteList);
                    }
                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError("Không thể xóa những dòng tài sản đang chọn!" + ex.Message + "\n" + ex.InnerException);
                }
            }
            else
            {
                DialogUtil.ShowWarning("Bạn không thể xóa Chứng Từ của người khác !");
            }

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
                    DialogUtil.ShowError("Không thể gở bỏ những dòng hợp đồng đang chọn!");
                }
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void grdViewTSCDCaBiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (Object.ReferenceEquals(e.Column, this.colTongNguyenGiaCoThue) || Object.ReferenceEquals(e.Column, this.colTienThue) || Object.ReferenceEquals(e.Column, this.colDonGia) || Object.ReferenceEquals(e.Column, this.colChiPhiCoThue) || Object.ReferenceEquals(e.Column, this.colPhanTramThue) || Object.ReferenceEquals(e.Column, this.colChiPhi) || Object.ReferenceEquals(e.Column, this.rCd_CoThue))
            {
                CapNhatLaiTongTien();
            }

            grdViewTSCDCaBiet.RefreshData();
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
            {
                txtTenDoiTac.Text = doiTacHienTai.TenDoiTac;
                //LayDanhSachHopDongTheoDoiTac(doiTacHienTai.MaDoiTac);
                //////gở bỏ hợp đồng cũ gắn sai
                //foreach (var item in _chungTu.tblDinhKhoan.tblButToans)
                //{
                //    List<tblHopDong> hdList = tblHopDongBindingSource.DataSource as List<tblHopDong>;
                //    if (false == hdList.Any(x => x.MaHopDong == (item.MaHopDong ?? 0)))
                //        item.MaHopDong = 0;
                //}
            }
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
            tblHopDong hopDong_khongChon = new tblHopDong() { MaHopDong = 0, TenHopDong = "<<Không chọn>>", tblHopDongMuaBan = new tblHopDongMuaBan() { SoHopDong = "<<Không chọn>>" } };
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
        //private void LayDanhSachHopDongTheoDoiTac(Int64 maDoiTac)
        //{
        //    //lây hợp đồng theo đối tác

        //    List<tblHopDong> hopDongListTheoDoiTac = new List<tblHopDong>();
        //    hopDongListTheoDoiTac = HopDongTaiSan_DerivedFactory.New().GetListByMaDoiTac(maDoiTac).ToList();
        //    tblHopDong hopDong_khongChon = new tblHopDong() { MaHopDong = 0, TenHopDong = "<<Không chọn>>" };
        //    hopDong_khongChon.tblHopDongMuaBan = new tblHopDongMuaBan() { SoHopDong = "<<Không chọn>>" };
        //    hopDongListTheoDoiTac.Insert(0, hopDong_khongChon);
        //    tblHopDongBindingSource.DataSource = hopDongListTheoDoiTac;

        //}

        private void btnDanhSachChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachChungTu_GhiTangTSCDCaBiet.ShowSingleton(null, this.MdiParent);
        }
        #region các tab
        private void btnXuatExcelDanhSachTaiSan_Click(object sender, EventArgs e)
        {
            //xuất excel danh sách tài sản cá biệt
            GridUtil.ExportToExcelXlsx(gridView: this.grdViewTSCDCaBiet, showOpenFilePrompt: true);
        }
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
                    tblChungTuHoaDonMuaSuaBanTaiSanBindingSource.Add(chungTu_HoaDonTaiSan);

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
                                tblChungTuHopDongTaiSanBindingSource.Add(chungTu_HopDong);
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
        //private void btnButToanMucNganSach_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    //if (this.grdViewDinhKhoan_ButToan.FocusedRowHandle >= 0)
        //    //{
        //    //    //lấy bút toán hiện tại
        //    //    tblButToan currentButToan = this.grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
        //    //    //show danh sách bút toán mục ngân sách theo bút toán
        //    //    using (frmDialogDanhSachGhiMucNganSachTheoButToan frm = new frmDialogDanhSachGhiMucNganSachTheoButToan(context: _factory.Context, chungTu: _chungTu, butToan: currentButToan, noTaiKhoanList: _taiKhoanNoList, coTaiKhoanList: _taiKhoanCoList))
        //    //    {
        //    //        frm.ShowDialog();
        //    //    }
        //    //}
        //}
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
            //UnLockgrdView_DinhKhoan();
            if (butToan != null)
            {
                //lấy diễn giải chứng từ
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
                //            butToan.NoTaiKhoan = taiKhoanDuocChon.MaTaiKhoan;
                //        else if (tinhChatSoDu == TinhChatSoDuTaiKhoanEnum.Co)
                //            butToan.CoTaiKhoan = taiKhoanDuocChon.MaTaiKhoan;
                //    if (doiTuongDuocChon != null)
                //        //lấy tài khoản được chọn gán cho mặc định cho dòng định khoản mới tạo
                //        if (tinhChatSoDu == TinhChatSoDuTaiKhoanEnum.No)
                //            butToan.MaDoiTuongNo = doiTuongDuocChon.MaDoiTuong;
                //        else if (tinhChatSoDu == TinhChatSoDuTaiKhoanEnum.Co)
                //            butToan.MaDoiTuongCo = doiTuongDuocChon.MaDoiTuong;
                //}
                //catch (System.Exception ex){ }

                //}//end foreach
            }
        }

        private void cbGhiMucNganSach_EditValueChanged(object sender, EventArgs e)
        {
            //Boolean ghiMucNganSach = false;
            //try
            //{
            //    ghiMucNganSach = (Boolean)cbGhiMucNganSach.EditValue;

            //    if (_chungTu.tblDinhKhoan.GhiMucNganSach != ghiMucNganSach)
            //        //gán giá tri cho định khoản (rất quan trọng)
            //        _chungTu.tblDinhKhoan.GhiMucNganSach = ghiMucNganSach;

            //}
            //catch (System.Exception ex)
            //{

            //}
            ////ẩn hiện cột ghi mục ngân sách trên lưới bút toán
            //this.colButToanMucNganSach.Visible = ghiMucNganSach;
        }

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
                    DialogUtil.ShowError("Không thể gở bỏ những dòng hóa đơn đang chọn!");
                }
            }
        }
        #endregion

        #region Report
        private void btnInBienBanGiaoNhanTongHop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("NghiepVuGhiTang_BienBanGiaoNhanTongHop", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BienBanGiaoNhanTongHop", "@MaChungTuGhiTang", _chungTu.MaChungTu);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }

        private void btnBienBanGiaoNhanTSCD4ChuKy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDialogChonPhongBan dlg = new frmDialogChonPhongBan(LayDanhSachBoPhanTrongDanhSachTaiSanCuaChungTu(), true);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                int maPhongBan = dlg.MaPhongBan;
                ReportHelper.ShowReport("NghiepVuGhiTang_BienBanGiaoNhanTSCD4ChuKy", () =>
                {
                    DataSet dataSet = new DataSet();
                    SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                    dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BienBanGiaoNhanTSCD_New", "@MaChungTuGhiTang,@MaPhongBan", _chungTu.MaChungTu, maPhongBan);
                    dataAccess.FillDataSet(ref dataSet, "CoTaiKhoan", "sp_TSCD_LayCoTaiKhoanCuaDSTaiSanGhiTangTheoChungTuGhiTang", "@MaChungTu", _chungTu.MaChungTu);
                    return dataSet;
                }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
            }
        }

        private void btnBienBanGiaoNhanTSCD3ChuKy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDialogChonPhongBan dlg = new frmDialogChonPhongBan(LayDanhSachBoPhanTrongDanhSachTaiSanCuaChungTu(), true);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                int maPhongBan = dlg.MaPhongBan;
                ReportHelper.ShowReport("NghiepVuGhiTang_BienBanGiaoNhanTSCD3ChuKy", () =>
                {
                    DataSet dataSet = new DataSet();
                    SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                    dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BienBanGiaoNhanTSCD_New", "@MaChungTuGhiTang,@MaPhongBan", _chungTu.MaChungTu, maPhongBan);
                    dataAccess.FillDataSet(ref dataSet, "CoTaiKhoan", "sp_TSCD_LayCoTaiKhoanCuaDSTaiSanGhiTangTheoChungTuGhiTang", "@MaChungTu", _chungTu.MaChungTu);
                    return dataSet;
                }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
            }
        }

        private void btnDungCuPhuTungKemTheo4ChuKy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDialogChonPhongBan dlg = new frmDialogChonPhongBan(LayDanhSachBoPhanTrongDanhSachTaiSanCuaChungTu());
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                int maPhongBan = dlg.MaPhongBan;
                ReportHelper.ShowReport("NghiepVuGhiTang_DungCuPhuTungKemTheo4ChuKy", () =>
                {
                    DataSet dataSet = new DataSet();
                    SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                    dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachDungCuPhuTungKemTheo_ChungTuGhiTangTS", "@MaChungTuGhiTang,@MaPhongBan", _chungTu.MaChungTu, maPhongBan);
                    return dataSet;
                }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
            }
        }

        private void btnDungCuPhuTungKemTheo3ChuKy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDialogChonPhongBan dlg = new frmDialogChonPhongBan(LayDanhSachBoPhanTrongDanhSachTaiSanCuaChungTu());
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                int maPhongBan = dlg.MaPhongBan;
                ReportHelper.ShowReport("NghiepVuGhiTang_DungCuPhuTungKemTheo3ChuKy", () =>
                {
                    DataSet dataSet = new DataSet();
                    SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                    dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachDungCuPhuTungKemTheo_ChungTuGhiTangTS", "@MaChungTuGhiTang,@MaPhongBan", _chungTu.MaChungTu, maPhongBan);
                    return dataSet;
                }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
            }
        }

        private void btnInPhieuKeToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("PhieuKeToanChungTuGhiTang", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_PhieuKeToanChungTu", "@MaChungTu", _chungTu.MaChungTu);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }
        #endregion//end Report

        private void grdViewDinhKhoan_ButToan_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            tblButToan currentButToan = grdViewDinhKhoan_ButToan.GetRow(e.RowHandle) as tblButToan;
            if (currentButToan == null)
            {
                _themMoiButToan = true;
            }
            else
            {
                _themMoiButToan = false;
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
                    if ((taiKhoanCo != null && (taiKhoanCo.SoHieuTK.StartsWith("3113") || taiKhoanCo.SoHieuTK.StartsWith("3337"))) || (taiKhoanNo != null && (taiKhoanNo.SoHieuTK.StartsWith("3113") || taiKhoanNo.SoHieuTK.StartsWith("3337"))))
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

        private void cbNoTaiKhoan_ForGrid_EditValueChanged(object sender, EventArgs e)
        {
            tblButToan currentButToan = grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
            GridLookUpEdit gridLUED = sender as GridLookUpEdit;
            tblTaiKhoan taiKhoanNo = gridLUED.GetSelectedDataRow() as tblTaiKhoan;
            PSC_ERP.HamDungChung.KiemTraKhoaTaiKhoan(currentButToan, gridLUED, taiKhoanNo, _chungTu.NgayLap.Value, _user.UserID, true);//là nợ
        }

        private void cbCoTaiKhoan_ForGrid_EditValueChanged(object sender, EventArgs e)
        {
            tblButToan currentButToan = grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
            GridLookUpEdit gridLUED = sender as GridLookUpEdit;
            tblTaiKhoan taiKhoanCo = gridLUED.GetSelectedDataRow() as tblTaiKhoan;
            PSC_ERP.HamDungChung.KiemTraKhoaTaiKhoan(currentButToan, gridLUED, taiKhoanCo, _chungTu.NgayLap.Value, _user.UserID, false);//là có
        }

        public bool KiemTraCoTaiKhoanKhoaSo(DateTime ngay)
        {
            if (_chungTu.tblDinhKhoan.tblButToans.Count() == 0)
                return false;
            //foreach (tblButToan butToan in _chungTu.tblDinhKhoan.tblButToans)
            //{
            //    tblKy ky = Ky_Factory.New().XacDinhKy_ByNgay(ngay);
            //    if (TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, PSC_ERP_Global.Main.UserID, butToan.NoTaiKhoan ?? 0) || TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, PSC_ERP_Global.Main.UserID, butToan.CoTaiKhoan ?? 0))
            //    {
            //        return true;
            //    }
            //}
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
                if (TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, _user.UserID, currentButToan.NoTaiKhoan ?? 0) || TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, _user.UserID, currentButToan.CoTaiKhoan ?? 0))
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

        private void btn_PhieuNhapTS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("NghiepVuGhiTang_PhieuNhapTaiSan", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_PhieuNhapTaiSanGhiTang", "@MaChungTuGhiTang", _chungTu.MaChungTu);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }

        private void btn_ApDung_Click(object sender, EventArgs e)
        {
            if (_chungTu.tblTaiSanCoDinhCaBiets.Count > 0 && !String.IsNullOrEmpty(txt_TongChiPhiCoThue.EditValue.ToString()))
            {
                Decimal tongChiPhi = Convert.ToDecimal(txtTongChiPhi.EditValue);
                Decimal tongChiPhiCoThue = Convert.ToDecimal(txt_TongChiPhiCoThue.EditValue);
                int soLuong = _chungTu.tblTaiSanCoDinhCaBiets.Count;
                decimal chiPhiLamTron = 0, chiPhiCoThueLamTron = 0;
                chiPhiLamTron = Math.Floor(tongChiPhi / soLuong);
                chiPhiCoThueLamTron = Math.Floor(tongChiPhiCoThue / soLuong);
                foreach (tblTaiSanCoDinhCaBiet tscdcb in _chungTu.tblTaiSanCoDinhCaBiets)
                {
                    if (soLuong == 1)
                    {
                        chiPhiLamTron = tongChiPhi - chiPhiLamTron * (_chungTu.tblTaiSanCoDinhCaBiets.Count - 1);
                        chiPhiCoThueLamTron = tongChiPhiCoThue - chiPhiCoThueLamTron * (_chungTu.tblTaiSanCoDinhCaBiets.Count - 1);
                    }
                    tscdcb.ChiPhi = chiPhiLamTron;
                    tscdcb.ChiPhiCoThue = chiPhiCoThueLamTron;
                    //tscdcb.NguyenGiaTinhKhauHao = tscdcb.NguyenGiaMua + tscdcb.ChiPhi + tscdcb.TienThue;
                    soLuong--;
                }
                CapNhatLaiTongTien();
            }
        }

        private void txtTongChiPhi_EditValueChanged(object sender, EventArgs e)
        {
            TinhThueChiPhiTaiSanCoDinhCaBiet();
        }

        private void gridLookUpEdit_ThueSuatVAT_EditValueChanged(object sender, EventArgs e)
        {
            TinhThueChiPhiTaiSanCoDinhCaBiet();
        }

        private void btn_TaiFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnInMaVach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (_chungTu.MaChungTu == 0)
            {
                DialogUtil.ShowInfo("Vui lòng lưu chứng từ trước khi In mã vạch !");
                return;
            }
            else
            {
                InMaVachTaiSan(_chungTu.MaChungTu);
            }
        }
        private void InMaVachTaiSan(long maChungTu)
        {

            ReportHelper.ShowReport("InMaVachTaiSanCoDinhCaBiet", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_InMaVachByMaChungTu", "@maChungTu", maChungTu);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }

        private void radioDuyet_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(radioDuyet.SelectedIndex==1)
            //    foreach (tblTaiSanCoDinhCaBiet ts in _chungTu.tblTaiSanCoDinhCaBiets)
            //    { ts.SuDung = false; }
            //if (radioDuyet.SelectedIndex == 0)
            //    foreach (tblTaiSanCoDinhCaBiet ts in _chungTu.tblTaiSanCoDinhCaBiets)
            //    { ts.SuDung = true; }
        }

        private void repoCheckEdit_SuDung_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //if((bool)e.NewValue == true)
            //{
            //    if (radioDuyet.SelectedIndex == 1)
            //    {
            //        e.NewValue = false;                 
            //        XtraMessageBox.Show("Chứng Từ đang ở trạng thái <color=red>Không Duyệt</color> \n\n <b>Không thể sử dụng tài sản cá biệt này</b> ",
            //            "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);
            //    }
            //}
        }

        private void cbBoPhan_forGrid_EditValueChanged(object sender, EventArgs e)
        {
            if (tblTaiSanCoDinhCaBietBindingSource.Position == tblTaiSanCoDinhCaBietBindingSource.Count - 1)
                tblTaiSanCoDinhCaBietBindingSource.MoveFirst();
            else
                tblTaiSanCoDinhCaBietBindingSource.MoveNext();

        }
        private void repoTreeMaViTri_EditValueChanged(object sender, EventArgs e)
        {
            if (tblTaiSanCoDinhCaBietBindingSource.Position == tblTaiSanCoDinhCaBietBindingSource.Count - 1)
                tblTaiSanCoDinhCaBietBindingSource.MoveFirst();
            else
                tblTaiSanCoDinhCaBietBindingSource.MoveNext();
        }

        private void grdViewTSCDCaBiet_RowCountChanged(object sender, EventArgs e)
        {
            CapNhatLaiTongTien();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {


        }
    }
}