using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
using DevExpress.XtraEditors;
using PSC_ERP;
using System.Net.Mail;
using System.Net;
using ERP_Library.Security;
using System.Data.SqlClient;
using PSC_ERPNew.Main.PhanHe.TSCD.UsefulDialog;
//
namespace PSC_ERPNew.Main
{
    public partial class frmThanhLyTSCDCaBiet : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmThanhLyTSCDCaBiet singleton_ = null;
        public static frmThanhLyTSCDCaBiet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmThanhLyTSCDCaBiet();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }
        #endregion
        //   List<tblTaiSanCoDinhCaBiet> _taiSanCoDinhCaBietList_TimDuyet = null;
        List<tblBoPhanERPNew> _viTriList = null;
        List<tblnsBoPhan> _boPhanList = null;
        // List<tblnsBoPhan> _boPhan_LichSuDCList = null;
        //Private Member field
        #region Private Member field
        List<tblDanhMucTSCD> _tscdList = null;
        //List<tblDuyetTSCD> _duyetTSCDList = null;
        ChungTuThanhLy_DerivedFactory _factory = null;
        tblChungTu _chungTu = null;
        IQueryable<tblTaiKhoan> _taiKhoanNoList = null;
        IQueryable<tblTaiKhoan> _taiKhoanCoList = null;

        tblNVThanhLyvaDieuChuyenNgoaiTSCD _nghiepVu = null;

        //  IQueryable<tblnsNhanVien> _nhanVienList = null;
        IQueryable<tblDoiTac> _doiTacList = null;
        List<tblHopDong> _hopDongList = null;
        long _maChungTuCuCanXemLai = 0;
        tblChungTu _objFromAnotherFactory = null;
        Boolean _taoMoiChungTu = true;
        Boolean _daLoadXong = false;
        DateTime? _ngayBanDau = DateTime.MinValue;

        UserItem _userItem = UserItem.GetUserItem(CurrentUser.Info.UserID);
        UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmThanhLyTSCDCaBiet()
        {
            InitializeComponent();
        }

        public frmThanhLyTSCDCaBiet(tblChungTu chungTu)
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
        private void XemLaiChungTuCu(long maChungTu)
        {
            //chưa load xong
            xtraTabControl1.SelectedTabPage = tabChungTu;
            _daLoadXong = false;
            {
                //Khởi tạo factory
                _factory = ChungTuThanhLy_DerivedFactory.New();

                // Lấy chứng từ nghiệp vụ
                _chungTu = _factory.Get_ChungTu_ByMaChungTu(maChungTu);
                //
                try
                {
                    _nghiepVu = _chungTu.tblNVThanhLyvaDieuChuyenNgoaiTSCDs.First();
                }
                catch (System.Exception ex)
                {

                }
                //nếu duyệt sẽ không cho sửa ngày chứng từ
                if (_chungTu.TrangThai == 1)
                {
                    this.dteNgayLap.Properties.ReadOnly = true;
                }
                // Đưa dữ liệu vào bindingsource
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
                LayDanhSachHopDongCuaChungTu();

            }
            //đã load xong
            _daLoadXong = true;
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
        private void TaoChungTuMoi()
        {
            //chưa load xong
            _daLoadXong = false;
            {
                //Khởi tạo factory
                _factory = ChungTuThanhLy_DerivedFactory.New();
                //Khởi tạo chứng từ
                _chungTu = _factory.NewChungTu();
                _chungTu.MaCongTy = _user.MaCongTy;
                _chungTu.TrangThai = null;
                _nghiepVu = _chungTu.tblNVThanhLyvaDieuChuyenNgoaiTSCDs.First();
                // Đưa dữ liệu vào bindingsource
                this.GanBindingSource();
                //cbTinhChatSoDuTaiKhoan.EditValue = (Int32)TinhChatSoDuTaiKhoanEnum.Co;
            }
            _daLoadXong = true;//đã load xong
        }


        private void GanBindingSource()
        {
            tblBoPhanBindingSource.DataSource = _boPhanList;
            tblBoPhanERPNewBindingSource.DataSource = _viTriList;


            tblChungTuBindingSource_Single.DataSource = _chungTu;
            tblTienTeBindingSource.DataSource = _chungTu.tblTienTe;
            try
            {
                tblNVThanhLyvaDieuChuyenNgoaiTSCDBindingSource.DataSource = _nghiepVu;//_chungTu.tblNVThanhLyvaDieuChuyenNgoaiTSCDs;
                tblCT_NVThanhLyvaDieuChuyenNgoaiTSCDBindingSource.DataSource = _nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD;
            }
            catch (System.Exception ex)
            {

            }
            //  tblnsNhanVienGiaoBindingSource.DataSource = _nhanVienList;
            tblnsDoiTacBindingSource.DataSource = _doiTacList;

            if (_tscdList != null)
                tblDanhMucTSCDBindingSource.DataSource = _tscdList;

            {
                tblButToanBindingSource.DataSource = _chungTu.tblDinhKhoan.tblButToans;
                tblChungTuHopDongBindingSource.DataSource = _chungTu.tblChungTu_HopDong;
                tblChungTuHoaDonBindingSource.DataSource = _chungTu.tblChungTu_HoaDon;
                //new
                tblChungTuHoaDonTaiSanBindingSource.DataSource = _chungTu.tblChungTu_HoaDonTaiSan;
                //
                //tinhChatSoDuTaiKhoanBindingSource.DataSource = PSC_ERP_Business.Main.Predefined.TinhChatSoDuTaiKhoan.TinhChatSoDuTaiKhoanList;
                //tài khoản
                tblTaiKhoanBindingSource_No.DataSource = _taiKhoanNoList;
                tblTaiKhoanBindingSource_Co.DataSource = _taiKhoanCoList;
                //ghi mục ngân sách
                ghiMucNganSachBindingSource.DataSource = PSC_ERP_Business.Main.Predefined.CoKhong.CoKhongList;
            }
        }
        private void LayDanhSachNoCoTaiKhoan()
        {
            IQueryable<tblTaiKhoan> taiKhoanList = TaiKhoan_Factory.New().GetAll();
            _taiKhoanNoList = taiKhoanList;//TaiKhoan_Factory.New().Get_DanhSachTaiKhoanNo();
            _taiKhoanCoList = taiKhoanList;// TaiKhoan_Factory.New().Get_DanhSachTaiKhoanCo();
        }

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }
        private void RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim()
        {
            #region old      
            //foreach (tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD chiTiet in _nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD)
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
            foreach (tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD chiTiet in _nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD)
            {
                for (int i = 0; i < grdViewDuyetTSCD.RowCount; i++)
                {
                    if (chiTiet.MaTSCDCaBiet == int.Parse(grdViewDuyetTSCD.GetRowCellValue(i, "MaTSCDCaBiet").ToString()))
                    {
                        grdViewDuyetTSCD.DeleteRow(i);
                    }
                }
            }
        }
        private bool DuocPhepLuu()
        {
            Ky_Factory ky_Factory = Ky_Factory.New();
            if (ky_Factory.DaKhoaSoTSCD(_chungTu.NgayLap.Value, _user.MaCongTy))
            {
                //bật thông báo đã khóa sổ
                DialogUtil.ShowDaKhoaSoTSCD(_chungTu.NgayLap.Value);
                return false;
            }
            if (KiemTraCoTaiKhoanKhoaSo(_chungTu.NgayLap.Value) && dteNgayLap.Properties.ReadOnly == false)
            {
                DialogUtil.ShowError("Bạn đã nhập định khoản trước rồi thay đổi ngày trong kỳ có tài khoản khóa số!\nHệ thống sẽ tự động trả lại ngày ban đầu của chứng từ\n\nNếu muốn đổi ngày vui lòng xóa dòng định khoản có tài khoản không bị khóa trong kỳ bạn muốn đổi tới!", "Không lưu được");
                _chungTu.NgayLap = _ngayBanDau;
                return false;
            }
            //Kiểm tra mã chứng từ quản lý
            if (_factory.KiemTraTrungMaChungTuQL(_chungTu) == true)
            {
                txtMaChungTuQuanLy.Focus();
                DialogResult dlgResult = DialogUtil.ShowYesNo("Trùng mã chứng từ quản lý. Tự động phát sinh mã mới");
                if (dlgResult == DialogResult.Yes)
                {
                    _chungTu.MaChungTuQL = _factory.Get_NextMaChungTuQL_ByYear_And_Month(_chungTu.NgayLap.Value.Year, _chungTu.NgayLap.Value.Month, _user.UserID);
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
                    _chungTu.SoChungTu = _factory.Get_NextSoChungTuPhieuKeToanTaiSan_ByYear_and_Month(_chungTu.NgayLap.Value.Year, _chungTu.NgayLap.Value.Month, _user.MaCongTy);
                    //đệ quy
                    return DuocPhepLuu();
                }
                else
                    return false;
            }

            #region kiểm tra đối tác nhận
            if ((_chungTu.MaDoiTuong ?? 0) == 0)
            {
                DialogUtil.ShowWarning("Chưa chọn đối tác nhận.");
                return false;
            }
            #endregion
            if (_nghiepVu.tblTaiSanCoDinhCaBiets.Count == 0)
            {
                DialogUtil.ShowWarning("Không thể lưu chứng từ rỗng.");
                return false;
            }

            //kiểm tra định khoản
            if (_chungTu.KiemTraDinhKhoan(kiemTraSoTienChungTuBangSoTienButToan: false) == false)
                return false;

            if (_chungTu.KiemTraHoaDon() == false)
                return false;
            if (String.IsNullOrEmpty(_chungTu.DienGiai))
            {
                DialogUtil.ShowWarning("Không thể lưu diễn giải rỗng.");
                return false;
            }
            if (String.IsNullOrEmpty(_nghiepVu.KetLuanThanhLy))
            {
                DialogUtil.ShowWarning("Không thể lưu kết luộn thanh lý rỗng.");
                return false;
            }
            if (String.IsNullOrEmpty(_nghiepVu.GiaTriThuHoi.ToString()))
            {
                DialogUtil.ShowWarning("Không thể lưu giá trị thu hồi rỗng.");
                return false;
            }
            if (String.IsNullOrEmpty(_nghiepVu.ChiPhiThanhLy.ToString()))
            {
                DialogUtil.ShowWarning("Không thể lưu chi phí thanh lý rỗng.");
                return false;
            }
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
            this.ChangeFocus();
            string emailNhan = string.Empty, emailGui = string.Empty, matKhauEmailGui = string.Empty;
            emailNhan = _user.EmailDenTang;
            emailGui = _user.EmailGui;
            matKhauEmailGui = _user.MatKhauEmailGui;
            int temp = (Int32)_chungTu.MaChungTu;
            try
            {
                //Kiểm tra dữ liệu trước khi lưu
                if (this.DuocPhepLuu() == true)
                {
                    if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn muốn lưu dữu liệu không?"))
                    {

                        using (DialogUtil.WaitForSave(this))
                        {
                            bool duyet = false;
                            //if (radioDuyet.SelectedIndex > -1)

                            UserItem userLap = UserItem.GetUserItem(_chungTu.MaNguoiLap.Value);
                            if (temp == 0)
                            {
                                _chungTu.HoanTat = duyet;
                                _chungTu.TrangThaiThanhLy = "Chờ duyệt";
                                SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Chờ Kế Toán Duyệt Chứng Từ {_chungTu.MaChungTuQL}",
                                    " Chờ kế toán duyệt chứng từ thanh lý TSCĐ hay CCDC có mã quản lý: " + _chungTu.MaChungTuQL + " với nội dung:" + _chungTu.DienGiai);
                            }

                            else if (radKeToanDuyet.Checked == true && temp != 0
                                && _chungTu.TrangThaiThanhLy == "Chờ duyệt")//được duyệt bước 1
                            {
                                if (_userItem.GroupID != 38)
                                {
                                    DialogUtil.ShowWarning("Chỉ kế toán đơn vị thực hiện bức duyệt này!\nVui lòng chờ kế toán đơn vị duyệt!");
                                    return false;
                                }
                                duyet = false;
                                _chungTu.TrangThaiThanhLy = "Kế toán duyệt";
                                _chungTu.HoanTat = duyet;
                                _chungTu.UserIDNgDuyetCongTy = _user.UserID;
                                _chungTu.NgayDuyetCongTy = DateTime.Today.Date;
                                string emailNhanDenTapDoan = String.Empty;
                                foreach (UserItem uItem in UserList.GetUserKeToanTapDoan(38, 14))  //groupID 38 là group kế toán -- Mã công Ty 14 Cty VLC Tập Đoàn
                                {
                                    emailNhanDenTapDoan += uItem.EmailHRM + ',';
                                }
                                if (emailNhanDenTapDoan.Length > 0) emailNhanDenTapDoan = emailNhanDenTapDoan.Remove(emailNhanDenTapDoan.Length - 1, 1);
                                SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Chờ Kế Toán Trưởng Duyệt Chứng Từ {_chungTu.MaChungTuQL}",
                                    " Chờ kế toán trưởng đã duyệt chứng từ thanh lý TSCĐ hay CCDC có mã quản lý: " + _chungTu.MaChungTuQL + " với nội dung:" + _chungTu.DienGiai);

                                SendEmail_DKAPP(emailNhanDenTapDoan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đề Nghị Duyệt Chứng Từ {_chungTu.MaChungTuQL}",
                                    "Đề nghị Kế toán trưởng duyệt chứng từ thanh lý TSCĐ hay CCDC có mã quản lý: " + _chungTu.MaChungTuQL + " với nội dung:" + _chungTu.DienGiai);
                            }


                            else if (_userItem.IsKeToanTruong == true && temp != 0 && radKeToanTruongDuyet.Checked == true)
                            {
                                if (_chungTu.TrangThaiThanhLy != "Kế toán duyệt")
                                {
                                    DialogUtil.ShowWarning("Kế toán đơn vị chưa duyệt!\nVui lòng chờ kế toán đơn vị duyệt!");
                                    return false;
                                }
                                duyet = false;
                                _chungTu.TrangThaiThanhLy = "Kế toán trưởng duyệt";
                                _chungTu.HoanTat = duyet;
                                _chungTu.UserIDNgDuyetKTTruong = _user.UserID;
                                _chungTu.NgayDuyetKTTruong = DateTime.Today.Date;
                                string emailNhanDenTapDoan = String.Empty;
                                foreach (UserItem uItem in UserList.GetUserKeToanTapDoan(38, 14))  //groupID 38 là group kế toán -- Mã công Ty 14 Cty VLC Tập Đoàn
                                {
                                    emailNhanDenTapDoan += uItem.EmailHRM + ',';
                                }
                                if (emailNhanDenTapDoan.Length > 0) emailNhanDenTapDoan = emailNhanDenTapDoan.Remove(emailNhanDenTapDoan.Length - 1, 1);
                                SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Chờ Kế Toán Tập Đoàn Duyệt Chứng Từ {_chungTu.MaChungTuQL}",
                                    " Chờ kế toán trưởng duyệt chứng từ thanh lý TSCĐ hay CCDC có mã quản lý: " + _chungTu.MaChungTuQL + " với nội dung:" + _chungTu.DienGiai);

                                SendEmail_DKAPP(emailNhanDenTapDoan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đề Nghị Duyệt Chứng Từ {_chungTu.MaChungTuQL}",
                                    "Đề nghị kế toán tập đoàn duyệt chứng từ thanh lý TSCĐ hay CCDC có mã quản lý: " + _chungTu.MaChungTuQL + " với nội dung:" + _chungTu.DienGiai);
                            }

                            else if (_userItem.IsKeToanTapDoan == true && temp != 0 && radKeToanTapDoanDuyet.Checked == true)
                            {
                                if (_chungTu.TrangThaiThanhLy != "Kế toán trưởng duyệt")
                                {
                                    DialogUtil.ShowWarning("Kế toán trưởng hoặc kế toán viên chưa duyệt!\nVui lòng chờ kế toán trưởng hoặc kế toán viên duyệt!");
                                    return false;
                                }
                                duyet = true;
                                _chungTu.TrangThaiThanhLy = "Kế toán tập đoàn duyệt";
                                _chungTu.HoanTat = duyet;
                                _chungTu.TrangThai = 1;
                                _chungTu.UserIDNgDuyetTapDoan = _user.UserID;
                                _chungTu.NgayDuyetTapDoan = DateTime.Today.Date;
                                string emailNhanDenTapDoan = String.Empty;
                                foreach (UserItem uItem in UserList.GetUserKeToanTapDoan(38, 14))  //groupID 38 là group kế toán -- Mã công Ty 14 Cty VLC Tập Đoàn
                                {
                                    emailNhanDenTapDoan += uItem.EmailHRM + ',';
                                }
                                if (emailNhanDenTapDoan.Length > 0) emailNhanDenTapDoan = emailNhanDenTapDoan.Remove(emailNhanDenTapDoan.Length - 1, 1);
                                SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Chờ Tập Đoàn Duyệt Chứng Từ {_chungTu.MaChungTuQL}",
                                    " Chờ duyệt chứng từ thanh lý TSCĐ hay CCDC có mã quản lý: " + _chungTu.MaChungTuQL + " với nội dung:" + _chungTu.DienGiai);

                                SendEmail_DKAPP(emailNhanDenTapDoan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đề Nghị Duyệt Chứng Từ {_chungTu.MaChungTuQL}",
                                    "Đề nghị duyệt chứng từ thanh lý TSCĐ hay CCDC có mã quản lý: " + _chungTu.MaChungTuQL + " với nội dung:" + _chungTu.DienGiai);
                                foreach (tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD ct in _nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD)
                                {
                                    //Định ngày thanh lý cho dòng tài sản cá biệt
                                    ct.tblTaiSanCoDinhCaBiet.NgayThanhLy = DateTime.Today.Date;
                                    //Cập nhật lại thanh lý cho dòng tài sản cá biệt
                                    ct.tblTaiSanCoDinhCaBiet.ThanhLy = true;
                                    ct.tblTaiSanCoDinhCaBiet.TinhTrang = "Đã Thanh Lý";
                                    //ct.tblTaiSanCoDinhCaBiet.NgungSuDung = true;
                                }

                            }

                            _factory.SaveChanges(BusinessCodeEnum.TSCD_ThanhLy.ToString());//lưu lại chứng từ
                            XetRadioTrangThaiThanhLy();
                        }

                        DialogUtil.ShowSaveSuccessful();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                DialogUtil.ShowNotSaveSuccessful();
            }
            return false;
        }
        private void CapNhatLaiTongTien()
        {
            //cập nhật lại tổng tiền chứng từ
            Decimal tongTien = 0;
            //foreach (var item in _nghiepVu.tblTaiSanCoDinhCaBiets)
            //{
            //    tongTien += item.NguyenGiaMua.Value;
            //}
            foreach (var item in _chungTu.tblChungTu_HopDong)
            {
                tongTien += item.tblHopDong.tblHopDongMuaBan.TongTien.Value;
            }
            _chungTu.tblTienTe.SoTien = tongTien;
        }
        #endregion
        //Event Method
        #region Event Method

        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_ThanhLy, this.MdiParent);
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.ChangeFocus();
            //lấy mã phòng ban đang chọn trong điều kiện tìm
            Int32 maViTri = Convert.ToInt32(treeListLookUpEdit_ViTri.EditValue);
            Int32 maPhongBanDangChon = Convert.ToInt32(treeListLookUpEdit_BoPhan_Tim.EditValue.ToString() == "" ? 0 : treeListLookUpEdit_BoPhan_Tim.EditValue);
            // Lấy mã tài sản cố định cá biệt
            Int32 maTaiSanCDCB = Convert.ToInt32(cbTaiSanCD.EditValue);
            //Tìm kiếm dữ liệu

            if (treeListLookUpEdit_BoPhan_Tim.EditValue == "")
            {
                DialogUtil.ShowWarning("Chưa chọn bộ phận!\nVui lòng chọn bộ phận!");
                return;
            }

            //cảnh báo người dùng nếu chưa chọn phòng ban
            if (maPhongBanDangChon == 0)
            {
                DialogUtil.ShowWarning("Chưa Chọn phòng ban!\nVui lòng chọn phòng ban!");
                return;
            }

            //_taiSanCoDinhCaBietList_TimDuyet = TaiSanCoDinhCaBiet_Factory.New().Context.spd_TSCD_DanhSachTaiSanCoDinhHayCCDCCoDenNgay_TheoPhongBanViTriLoaiTaiSan(DateTime.Now.Date, maPhongBanDangChon, maViTri, maTaiSanCDCB, _user.MaCongTy, 1, _chungTu.MaLoaiChungTu).ToList();       
            //// Đưa dữ liệu vào bindingsource         
            //tblTaiSanCoDinhCaBietBindingSource_TimDuyet.DataSource = _taiSanCoDinhCaBietList_TimDuyet;     

            //remove những tài sản đã tồn tại trong chi tiết bên dưới ra khỏi danh sách tìm
            // RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
            // chỉnh sửa tìm kiếm dữ liệu date:11/11/2020
            using (DialogUtil.Wait())
            {
                DataTable _dt_TaiSanCoDinhCaBiet = new DataTable();
                _dt_TaiSanCoDinhCaBiet = dt_TaiSanCoDinhCaBiet(DateTime.Now.Date, maPhongBanDangChon, maViTri, maTaiSanCDCB, _user.MaCongTy, 0, _chungTu.MaLoaiChungTu);
                grdDuyetTSCD.DataSource = _dt_TaiSanCoDinhCaBiet;
                // Xóa duyệt tài sản cố định cá biệt vừa chọn ra khỏi danh sách tìm
                if (grdViewDuyetTSCD.RowCount > 0 && tblCT_NVThanhLyvaDieuChuyenNgoaiTSCDBindingSource.Count > 0)
                {
                    RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
                }
            }
            //remove những tài sản đã tồn tại trong chi tiết bên dưới ra khỏi danh sách tìm
            // RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
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
        private void btnDuaTSVaoChungTu_Click(object sender, EventArgs e)
        {

            this.ChangeFocus();
            #region old
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
            //        tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD chiTietNew = CT_NVThanhLyvaDieuChuyenNgoaiTSCD_Factory.New().CreateAloneObject();
            //        //Đưa vào danh sách chi tiết
            //        _nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD.Add(chiTietNew);
            //        //gán mã tài sản cá biệt
            //        chiTietNew.MaTSCDCaBiet = taiSanCaBiet.MaTSCDCaBiet;
            //        //Định ngày thanh lý cho dòng tài sản cá biệt
            //        chiTietNew.tblTaiSanCoDinhCaBiet.NgayThanhLy = _chungTu.NgayLap;
            //        //Cập nhật lại thanh lý cho dòng tài sản cá biệt
            //        chiTietNew.tblTaiSanCoDinhCaBiet.ThanhLy = true;
            //        //liên kết trực tiếp tài sản với nghiệp vụ thanh lý
            //        _nghiepVu.tblTaiSanCoDinhCaBiets.Add(chiTietNew.tblTaiSanCoDinhCaBiet);

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
            #endregion

            try
            {
                //cập nhật lại tổng tiền               
                Boolean coTaiSanCaBietDuocChonTuDanhSach = false;
                using (DialogUtil.Wait())
                {
                    if (grdViewDuyetTSCD.RowCount > 0)
                    {
                        for (int i = 0; i < grdViewDuyetTSCD.RowCount; i++)
                        {
                            DataRow dr = grdViewDuyetTSCD.GetDataRow(i);
                            if (dr != null)
                            {
                                if (bool.Parse(dr["Chon"].ToString()) == true)
                                {
                                    coTaiSanCaBietDuocChonTuDanhSach = true;
                                    //khởi tạo chi tiết nghiệp vụ thanh lý
                                    tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD chiTietNew = CT_NVThanhLyvaDieuChuyenNgoaiTSCD_Factory.New().CreateAloneObject();
                                    chiTietNew.MaTSCDCaBiet = Convert.ToInt32(dr["MaTSCDCaBiet"].ToString());
                                    // Đưa vào danh sách chi tiết
                                    _nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD.Add(chiTietNew);
                                    #region update code mới
                                    ////Định ngày thanh lý cho dòng tài sản cá biệt
                                    //chiTietNew.tblTaiSanCoDinhCaBiet.NgayThanhLy = _chungTu.NgayLap;
                                    ////Cập nhật lại thanh lý cho dòng tài sản cá biệt
                                    //chiTietNew.tblTaiSanCoDinhCaBiet.ThanhLy = true;
                                    #endregion
                                    //liên kết trực tiếp tài sản với nghiệp vụ thanh lý
                                    DataSet dataSet = new DataSet();
                                    using (SqlConnection cn = new SqlConnection(Database.NormalConnectionString))
                                    {

                                        //tao bang_ReportHeaderAndFooter
                                        using (SqlCommand cm = cn.CreateCommand())
                                        {
                                            cm.CommandType = CommandType.StoredProcedure;
                                            cm.CommandText = "spd_UpdateLuyKeKhauHao_GiaTriConLaiTSCD";
                                            cm.Parameters.AddWithValue("@MaTSCDCaBiet", chiTietNew.MaTSCDCaBiet);
                                        }
                                    }
                                    _nghiepVu.tblTaiSanCoDinhCaBiets.Add(chiTietNew.tblTaiSanCoDinhCaBiet);
                                }
                            }
                        }
                        // Xóa duyệt tài sản cố định cá biệt vừa chọn ra khỏi danh sách tìm
                        RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
                        xtraTabControl1.SelectedTabPage = tabChungTu;
                    }
                }
                //thông báo người dùng nếu chưa chọn bất cứ dòng nào từ danh sách duyệt
                if (coTaiSanCaBietDuocChonTuDanhSach == false) { DialogUtil.ShowWarning("Chưa chọn dữ liệu."); return; }
            }
            catch (Exception ex)
            { XtraMessageBox.Show("<color=red>- Lỗi: </color>" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, DevExpress.Utils.DefaultBoolean.True); }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Ky_Factory.New().DaKhoaSoTSCD(_chungTu.NgayLap.Value, _user.MaCongTy))
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
                if (_chungTu.MaNguoiLap == _user.UserID && DialogResult.Yes == DialogUtil.ShowYesNo(String.Format("Bạn muốn xóa chứng từ [{0}]?", this.Text)))
                {
                    try
                    {
                        // Cập nhật lại tài sản cố định cá biệt
                        //foreach (tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet in _taiSanCoDinhCaBietList)
                        //{
                        //    TaiSanCoDinhCaBiet_Factory.New().CapNhatTSCDCaBiet_PhucVuXoaTatCaDieuChuyenNgoaiAndThanhLy(taiSanCoDinhCaBiet.MaTSCDCaBiet);
                        //    DuyetTSCD_Factory.New().CapNhatChuaThucHienNghiepVuTrongDuyetTSCDCaBiet_PhucVuDieuChuyenNgoaiAndThanhLy(taiSanCoDinhCaBiet.MaTSCDCaBiet);
                        //}
                        using (DialogUtil.WaitForDelete(this))
                        {
                            //Xóa nghiệp vụ điều chuyển ngoài
                            _factory.FullDelete(_chungTu);
                            _factory.SaveChanges();
                        }
                        DialogUtil.ShowDeleteSuccessful();
                        // Tạo mới chứng từ
                        TaoChungTuMoi();
                        this.GanBindingSource();

                    }
                    catch (Exception ex)
                    {
                        DialogUtil.ShowNotDeleteSuccessful();
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
        private void frmDieuChuyenNgoaiTSCDCaBiet_Load(object sender, EventArgs e)
        {
            LayDanhSachNoCoTaiKhoan();
            //Lấy vị trí
            _viTriList = BoPhanERPNew_Factory.New().GetAll().ToList();
            tblBoPhanERPNew boPhan_vitri_chonTatCa = new tblBoPhanERPNew() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _viTriList.Insert(0, boPhan_vitri_chonTatCa);
            //Lấy bộ phận
            _boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(_user.MaCongTy).ToList();
            tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _boPhanList.Insert(0, boPhan_chonTatCa);
            //Lấy tài sản cá biệt phòng ban
            _tscdList = DanhMucTSCD_Factory.New().Get_DanhSachTaiSanCoDinh_CoTSCDCaBietChuaThanhLy().ToList();
            tblDanhMucTSCD tscd_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
            _tscdList.Insert(0, tscd_chonTatCa);

            // Lấy danh sách nhân viên 
            // _nhanVienList = NhanVien_Factory.New().GetAll();
            //Lấy danh sách đối tác 
            _doiTacList = DoiTac_Factory.New().GetAll();

            //Đưa checkbox lên lưới
            GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewDuyetTSCD, colChon);

            //lay danh sach doi tuong
            {
                List<sp_AllDoiTuong_Result> doiTuongList = new List<sp_AllDoiTuong_Result>();
                doiTuongList = ChungTu_Factory.New().Context.sp_AllDoiTuong(0).ToList();
                sp_AllDoiTuong_Result khongChon = new sp_AllDoiTuong_Result() { MaDoiTuong = 0, MaQLDoiTuong = "<<Không chọn>>", TenDoiTuong = "<<Không chọn>>" };
                doiTuongList.Insert(0, khongChon);
                sp_AllDoiTuong_ResultBindingSource.DataSource = doiTuongList;
            }
            if (_taoMoiChungTu == true)
            {
                TaoChungTuMoi();
            }
            else
            {
                XemLaiChungTuCu(_maChungTuCuCanXemLai);
            }

            //cài đặt master-details
            {
                GridUtil.InitDetailForGridView<tblButToan>(grdViewDinhKhoan_ButToan, tblButToan.tblChungTu_HoaDon_EntityCollectionPropertyName, 0, 1);
            }
            // Cài đặt lưới
            // Set số thứ tự cho lưới
            GridUtil.SetSTTForGridView(new GridView[] { this.grdViewDuyetTSCD
                , this.grdViewChiTietNghiepVu
                , this.grdViewDinhKhoan_ButToan
                , this.grdViewChungTu_HopDong
                , this.gridViewHoaDon//new
                , this.gridView_ButToanHoaDon});
            //cài đặt delete helper
            GridUtil.DeleteHelper.Setup_ManualType(grdViewChiTietNghiepVu, (gridView, deleteList) =>
                                                                           {
                                                                               GoBoDanhSachTaiSan(deleteList);
                                                                           });
            //new
            GridUtil.DeleteHelper.Setup_ManualType(gridViewHoaDon, (gridView, deleteList) =>
                                                                   {
                                                                       //xóa chứng từ hóa đơn tai san
                                                                       XoaDanhSachChungTu_HoaDonTaiSan(deleteList);
                                                                       //ChungTu_HoaDon_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
                                                                   });
            GridUtil.DeleteHelper.Setup_ManualType(grdViewDinhKhoan_ButToan, (gridView, deleteList) =>
                                                                             {
                                                                                 //xóa bút toán
                                                                                 // ButToan_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
                                                                                 tblKy ky = Ky_Factory.New().XacDinhKy_ByNgay(_chungTu.NgayLap.Value);
                                                                                 ButToan_Factory.FullDeleteKiemTraKhoaTaiKhoan(_factory.Context, deleteList, _user.UserID, ky.MaKy);
                                                                             });
            GridUtil.DeleteHelper.Setup_ManualType(grdViewChungTu_HopDong, (gridView, deleteList) =>
                                                                           {
                                                                               //xóa chứng từ hợp đồng
                                                                               XoaDanhSachChungTu_HopDong(deleteList);
                                                                               //ChungTu_HopDong_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
                                                                           });
            XetRadioTrangThaiThanhLy();
            PhanQuyenThemSuaXoa();
        }
        private void XetRadioTrangThaiThanhLy()
        {
            if (_chungTu != null)
            {
                radKeToanTapDoanDuyet.Enabled = false;
                radKeToanDuyet.Enabled = false;
                radChoDuyet.Enabled = false;
                radKeToanTruongDuyet.Enabled = false;
                if (_chungTu.TrangThaiThanhLy == "Chờ duyệt")
                {
                    radChoDuyet.BackColor = System.Drawing.Color.Red;
                    radChoDuyet.Checked = true;
                }
                else if (_chungTu.TrangThaiThanhLy == "Kế toán duyệt")
                {
                    radChoDuyet.BackColor = System.Drawing.Color.Red;
                    radKeToanDuyet.BackColor = System.Drawing.Color.Red;
                    radKeToanDuyet.Checked = true;
                }
                else if (_chungTu.TrangThaiThanhLy == "Kế toán trưởng duyệt")
                {
                    radChoDuyet.BackColor = System.Drawing.Color.Red;
                    radKeToanDuyet.BackColor = System.Drawing.Color.Red;
                    radKeToanTruongDuyet.BackColor = System.Drawing.Color.Red;
                    radKeToanTruongDuyet.Checked = true;
                }
                else if (_chungTu.TrangThaiThanhLy == "Kế toán tập đoàn duyệt")
                {
                    radChoDuyet.BackColor = System.Drawing.Color.Red;
                    radKeToanDuyet.BackColor = System.Drawing.Color.Red;
                    radKeToanTruongDuyet.BackColor = System.Drawing.Color.Red;
                    radKeToanTapDoanDuyet.BackColor = System.Drawing.Color.Red;
                    radKeToanTapDoanDuyet.Checked = true;
                }
                if (_userItem.GroupID == 38 && !_userItem.IsKeToanTruong && !_userItem.IsKeToanTapDoan)
                {
                    if (_chungTu.TrangThaiThanhLy == "Kế toán tập đoàn duyệt" || _chungTu.TrangThaiThanhLy == "Kế toán trưởng duyệt")
                        radKeToanDuyet.Enabled = false;
                    else
                        radKeToanDuyet.Enabled = true;
                }
                if (_userItem.IsKeToanTruong)
                {
                    if (_chungTu.TrangThaiThanhLy == "Kế toán trưởng duyệt")
                        radKeToanTruongDuyet.Enabled = false;
                    else
                        radKeToanTruongDuyet.Enabled = true;
                }
                if (_userItem.IsKeToanTapDoan)
                    radKeToanTapDoanDuyet.Enabled = true;
            }
        }
        //// phân quyền
        ERP_Library.PhanQuyenSuDungForm _phanQuyen = null;
        private void PhanQuyenThemSuaXoa()
        {
            _phanQuyen = ERP_Library.PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            btnThemMoi.Enabled = _phanQuyen.Them;
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
            grdViewDuyetTSCD.OptionsBehavior.ReadOnly = true;
            grdViewChiTietNghiepVu.OptionsBehavior.ReadOnly = true;
            grdViewChungTu_HopDong.OptionsBehavior.ReadOnly = true;
            gridViewHoaDon.OptionsBehavior.ReadOnly = true;
            grdViewDinhKhoan_ButToan.OptionsBehavior.ReadOnly = true;
            gridView_ButToanHoaDon.OptionsBehavior.ReadOnly = true;

            foreach (Control c in tabChungTu.Controls)
            {
                if (c is PanelControl) { ((PanelControl)c).Controls.Owner.Enabled = false; }
                else if (c is GroupControl) { ((GroupControl)c).Controls.Owner.Enabled = false; }
            }

            btnDuaTSVaoChungTu.Enabled = false;
        }
        private void GoBoDanhSachTaiSan(List<Object> deleteList)
        {
            //chi tiết nghiệp vụ
            CT_NVThanhLyvaDieuChuyenNgoaiTSCD_Factory.FullDeleteCT_NVThanhLyvaDieuChuyenNgoaiTSCD_Factory(context: _factory.Context, deleteList: deleteList);
        }
        private void btnDanhSachChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachChungTu_ThanhLyTSCDCaBiet.ShowSingleton(null, this.MdiParent);
        }
        private void dteNgayLap_EditValueChanged(object sender, EventArgs e)
        {
            //cập nhật lại ngày lập
            if (dteNgayLap.DateTime.Date != new DateTime(1, 1, 1) && dteNgayLap.DateTime.Date != _chungTu.NgayLap)
            {
                _chungTu.NgayLap = dteNgayLap.DateTime.Date;
                //Phát sinh số chứng từ mới
                if (_chungTu.MaChungTu == 0)
                {
                    _chungTu.MaChungTuQL = _factory.Get_NextMaChungTuQL_ByYear_And_Month(_chungTu.NgayLap.Value.Year, _chungTu.NgayLap.Value.Month, _user.UserID);
                    _chungTu.SoChungTu = _factory.Get_NextSoChungTuPhieuKeToanTaiSan_ByYear_and_Month(_chungTu.NgayLap.Value.Year, _chungTu.NgayLap.Value.Month, _user.MaCongTy);
                }

            }
            //cập nhật lại ngày thanh lý cho dòng tài sản   
            try
            {

                foreach (var item in _nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD)
                {
                    item.tblTaiSanCoDinhCaBiet.NgayThanhLy = _chungTu.NgayLap;
                }
            }
            catch (System.Exception ex)
            {

            }

        }
        #region các tab

        #region old
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

        //private void ThayDoiHangLoatNoHoacCoCuaButToan()
        //{
        //    TinhChatSoDuTaiKhoanEnum tinhChat = (TinhChatSoDuTaiKhoanEnum)((Int32)(cbTinhChatSoDuTaiKhoan.EditValue));

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
        //        ThayDoiHangLoatNoHoacCoCuaButToan();
        //    }
        //}
        #endregion
        private void btnHoaDonButToan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.grdViewDinhKhoan_ButToan.FocusedRowHandle >= 0)
            {
                //lấy bút toán hiện tại
                tblButToan currentButToan = this.grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
                //show danh sách bút toán hóa đơn
                frmDialogDanhSachHoaDonTheoButToan frm = new frmDialogDanhSachHoaDonTheoButToan(context: _factory.Context, chungTu: _chungTu, butToan: currentButToan, noTaiKhoanList: _taiKhoanNoList, coTaiKhoanList: _taiKhoanCoList);
                frm.ShowDialog();
            }
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

        private void grdViewDinhKhoan_ButToan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //lấy bút toán vừa tạo mới trên lưới
            tblButToan butToan = grdViewDinhKhoan_ButToan.GetRow(e.RowHandle) as tblButToan;

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
                #region old
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
                //catch (System.Exception ex){}
                #endregion

            }
        }
        #region old
        //private void cbGhiMucNganSach_EditValueChanged(object sender, EventArgs e)
        //{
        //    Boolean ghiMucNganSach = false;
        //    try
        //    {
        //        ghiMucNganSach = (Boolean)cbGhiMucNganSach.EditValue;

        //        if (_chungTu.tblDinhKhoan.GhiMucNganSach != ghiMucNganSach)
        //            //gán giá tri cho định khoản (rất quan trọng)
        //            _chungTu.tblDinhKhoan.GhiMucNganSach = ghiMucNganSach;

        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //    //ẩn hiện cột ghi mục ngân sách trên lưới bút toán
        //    this.colButToanMucNganSach.Visible = ghiMucNganSach;

        //}
        #endregion
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
            }

        }
        private void btnTimChonHopDongTaiSan_Click(object sender, EventArgs e)
        {
            Int64 maDoiTac = 0;
            try
            {
                maDoiTac = (Int64)cbDoiTacNhan.EditValue;
            }
            catch (System.Exception ex) { }

            //if (maDoiTac == 0)
            //{
            //    DialogUtil.ShowWarning("Cần chọn đối tác trước");
            //    cbDoiTacNhan.Focus();
            //}
            //else
            {//
                frmDialogTimChonHopDongTaiSan frm = new frmDialogTimChonHopDongTaiSan(maDoiTac);
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


                }
            }//
        }

        #endregion

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dlgResult = DialogUtil.ShowSaveRequireOptions(this);
            if (dlgResult == DialogResult.Yes)
            {
                if (this.Save() == false)
                    return;
            }
            frmThanhLyTSCDCaBiet.ShowSingleton(null, this.MdiParent);
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
        private void frmThanhLyTSCDCaBiet_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnXuatExcelDanhSachTaiSan_Click(object sender, EventArgs e)
        {
            //xuất excel danh sách tài sản cá biệt
            GridUtil.ExportToExcelXlsx(gridView: this.grdViewChiTietNghiepVu, showOpenFilePrompt: true);
        }

        private void btnGoBoTaiSan_Click(object sender, EventArgs e)
        {
            this.txtBlackHole.Focus();
            //yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn gở bỏ những dòng tài sản đang chọn?");
            if (_chungTu.MaNguoiLap == _user.UserID && dlgResult == DialogResult.Yes)
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
                        GoBoDanhSachTaiSan(deleteList);
                    }
                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError("Không thể gở bỏ những dòng tài sản đang chọn!");
                }
            }
            else
            {
                DialogUtil.ShowWarning("Bạn không thể thay đổi Chứng Từ của người khác !");
            }
        }

        #endregion

        #region Reports

        private void btnLenhGiaoHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_chungTu == null || _chungTu.MaChungTu == 0)
            {
                DialogUtil.ShowWarning("Chứng từ rỗng.");
                return;
            }

            ReportHelper.ShowReport("InLenhGiaoHang", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_LenhGiaoHang", "@MaChungTu", _chungTu.MaChungTu);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }

        #endregion//Reports

        private void btnInPhieuKeToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("PhieuKeToanChungTuThanhLyTaiSan", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_PhieuKeToanChungTu", "@MaChungTu", _chungTu.MaChungTu);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }

        private void grdViewDinhKhoan_ButToan_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

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

        public bool KiemTraCoTaiKhoanKhoaSo(DateTime ngay)
        {
            if (_chungTu.tblDinhKhoan.tblButToans.Count() == 0)
                return false;
            foreach (tblButToan butToan in _chungTu.tblDinhKhoan.tblButToans)
            {
                tblKy ky = Ky_Factory.New().XacDinhKy_ByNgay(ngay);
                if (TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, _user.UserID, butToan.NoTaiKhoan ?? 0) || TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, _user.UserID, butToan.CoTaiKhoan ?? 0))
                {
                    return true;
                }
            }
            return false;
        }

        private void cbDoiTacNhan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//refresh danh sách tài sản cố đinh
            {
                frmNhaCungCapCustomize frm = new frmNhaCungCapCustomize();
                frm.ShowDialog();
                _doiTacList = DoiTac_Factory.New().GetAll();
                tblnsDoiTacBindingSource.DataSource = _doiTacList;
            }
        }

        private void treeListLookUpEdit_BoPhan_Tim_EditValueChanged(object sender, EventArgs e)
        {
            int maPhongBan = Convert.ToInt32(treeListLookUpEdit_BoPhan_Tim.EditValue);
            //lấy danh sách tên tài sản
            {
                _tscdList = DanhMucTSCD_Factory.New().Get_DanhSachTaiSanCoDinh_NgungSuDung_ByMaPhongBan(maPhongBan).ToList();
                tblDanhMucTSCD tscd_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
                _tscdList.Insert(0, tscd_chonTatCa);
            }
            //Gán bindigsource
            GanBindingSource();
        }

        private void btnBienBanThanhLy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmDialogBienBanThanhLy dlg = new frmDialogBienBanThanhLy(_chungTu.MaChungTu);
            //if (dlg.ShowDialog(this) == DialogResult.OK)
            //{
            ReportHelper.ShowReport("BienBanThanhLyTaiSan", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_BienBanThanhLyTSCD", "@MaChungTuThanhLy", _chungTu.MaChungTu);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
            //}

        }

        private void labelControl15_Click(object sender, EventArgs e)
        {

        }
    }
}
