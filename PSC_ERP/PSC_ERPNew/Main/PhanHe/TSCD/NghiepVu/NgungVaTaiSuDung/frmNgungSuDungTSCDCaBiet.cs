using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Predefined;
using System.Net.Mail;
using System.Net;
using ERP_Library.Security;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using ERP_Library;

namespace PSC_ERPNew.Main
{
    public partial class frmNgungSuDungTSCDCaBiet : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmNgungSuDungTSCDCaBiet singleton_ = null;
        public static frmNgungSuDungTSCDCaBiet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmNgungSuDungTSCDCaBiet();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }
        #endregion

        //Private Member field
        #region Private Member field

        List<tblBoPhanERPNew> _viTriList = null;
        // IQueryable<tblnsBoPhan> _boPhanList = null;
        List<tblnsBoPhan> _boPhanList = null;
        // List<tblnsBoPhan> _boPhan_LichSuDCList = null;
        List<tblDanhMucTSCD> _tscdList = null;
        NVNgungvaTaiSuDungTSCD_Factory _nVNgungvaTaiSuDungTSCD_Factory = null;
        tblNVNgungvaTaiSuDungTSCD _nVNgungvaTaiSuDungTSCD = null;
        List<tblTaiSanCoDinhCaBiet> _taiSanCDCaBietList = null;
        int _maNVNgungvaTaiSuDungTSCD = 0;
        Boolean _xemLaiNVNgungvaTaiSuDungTSCD = false;

        UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        //UserItem _user = UserItem.GetUserItem(CurrentUser.Info.UserID);
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmNgungSuDungTSCDCaBiet()
        {
            InitializeComponent();
        }

        public frmNgungSuDungTSCDCaBiet(int maNVNgungvaTaiSuDungTSCD)
        {
            InitializeComponent();
            _xemLaiNVNgungvaTaiSuDungTSCD = true;
            // Lấy mã nghiệp vụ ngừng và tái sử dụng tài sản cố định cá biệt
            _maNVNgungvaTaiSuDungTSCD = maNVNgungvaTaiSuDungTSCD;

        }
        #endregion
        //Private Member Function
        #region Private Member Function

        private void XemLaiChungTuCu(int maNVNgungvaTaiSuDungTSCD)
        {
            //không cho sửa ngày khi xem lại chứng từ cũ
            this.deNgayLap.Properties.ReadOnly = true;

            // Lấy nghiệp vụ ngừng và tái sử dụng tài sản cố định cá biệt
            _nVNgungvaTaiSuDungTSCD = _nVNgungvaTaiSuDungTSCD_Factory.Get_DanhSachNVNgungvaTaiSuDungTSCD_ByMaNVNgungvaTaiSuDungTSCD(maNVNgungvaTaiSuDungTSCD);
            //nếu đã duyệt sẽ không cho sửa ngày chứng từ
            if (_nVNgungvaTaiSuDungTSCD.TinhTrang == 1)
            {
                this.deNgayLap.Properties.ReadOnly = true;
            }
            // Đưa dữ liệu vào bindingsource
            GanBindingSource();
            tabNgungSuDungTaiSanCoDinhCaBiet.SelectedTabPageIndex = 1;
        }

        private void GanBindingSource()
        {
            tblBoPhanBindingSource.DataSource = _boPhanList;
            tblBoPhanERPNewBindingSource.DataSource = _viTriList;
            //
            if (_tscdList != null)
                tblDanhMucTSCDBindingSource.DataSource = _tscdList;
            //
            tblNVNgungvaTaiSuDungTSCDBindingSource.DataSource = _nVNgungvaTaiSuDungTSCD;
            //
            tblCTNVNgungvaTaiSuDungTSCDBindingSource.DataSource = _nVNgungvaTaiSuDungTSCD.tblCT_NVNgungvaTaiSuDungTSCD;
        }

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }

        private void RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim()
        {
            #region old
            //foreach (tblCT_NVNgungvaTaiSuDungTSCD itemlCT_NVNgungvaTaiSuDungTSCD in _nVNgungvaTaiSuDungTSCD.tblCT_NVNgungvaTaiSuDungTSCD)
            //{
            //    tblTaiSanCoDinhCaBiet taiSanCDCaBietRemoveRaKhoiDanhSachTim = null;
            //    foreach (tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet in _taiSanCDCaBietList)
            //    {
            //        if (taiSanCoDinhCaBiet.MaTSCDCaBiet == itemlCT_NVNgungvaTaiSuDungTSCD.MaTSCDCaBiet)
            //        {
            //            taiSanCDCaBietRemoveRaKhoiDanhSachTim = taiSanCoDinhCaBiet;
            //            break;
            //        }
            //    }
            //    if (taiSanCDCaBietRemoveRaKhoiDanhSachTim != null)
            //    {
            //        tblTaiSanCoDinhCaBietBindingSource.Remove(taiSanCDCaBietRemoveRaKhoiDanhSachTim);
            //    }
            //}
            #endregion old
            foreach (tblCT_NVNgungvaTaiSuDungTSCD itemlCT_NVNgungvaTaiSuDungTSCD in _nVNgungvaTaiSuDungTSCD.tblCT_NVNgungvaTaiSuDungTSCD)
            {
                for (int i = 0; i < grdViewTSCDCaBiet.RowCount; i++)
                {
                    if (itemlCT_NVNgungvaTaiSuDungTSCD.MaTSCDCaBiet == int.Parse(grdViewTSCDCaBiet.GetRowCellValue(i, "MaTSCDCaBiet").ToString()))
                    {
                        grdViewTSCDCaBiet.DeleteRow(i);
                    }
                }
            }
        }

        private bool DuocPhepLuu()
        {
            bool returnValue = true;
            //kiểm tra khóa sổ
            if (Ky_Factory.New().DaKhoaSoTSCD(_nVNgungvaTaiSuDungTSCD.NgayChungTu,_user.MaCongTy))
            {
                //bật thông báo đã khóa sổ
                DialogUtil.ShowDaKhoaSoTSCD(_nVNgungvaTaiSuDungTSCD.NgayChungTu);
                return false;
            }
            
            if (_nVNgungvaTaiSuDungTSCD == null)
            {
                DialogUtil.ShowWarning("Vui lòng thêm dữ liệu.");
                return false;
            }
            //kiểm tra trùng số chứng từ
            if (_nVNgungvaTaiSuDungTSCD_Factory.KiemTraTrungSoChungTu(_nVNgungvaTaiSuDungTSCD) == true)
            {
                DialogUtil.ShowWarning("Trùng số chứng từ.");
                txtSoChungTu.Focus();
                return false;
            }
            if (this._nVNgungvaTaiSuDungTSCD.tblCT_NVNgungvaTaiSuDungTSCD.Count == 0)
            {
                DialogUtil.ShowWarning("Không thể lưu nghiệp vụ rỗng.");
                tabNgungSuDungTaiSanCoDinhCaBiet.SelectedTabPageIndex = 0;
                return false;
            }
            if (String.IsNullOrEmpty(_nVNgungvaTaiSuDungTSCD.SoChungTu))
            {
                DialogUtil.ShowWarning("Chưa nhập số chứng từ.");
                txtSoChungTu.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(_nVNgungvaTaiSuDungTSCD.GhiChu))
            {
                DialogUtil.ShowWarning("Chưa nhập diễn giải.");
                textEdit1.Focus(); //focus đến textEdit Diễn Giải
                return false;
            }
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
                    if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn muốn lưu dữu liệu không?"))
                    {
                        bool duyet = false;
                        if (radioDuyet.SelectedIndex > -1)
                        {
                            UserItem userLap = UserItem.GetUserItem(_nVNgungvaTaiSuDungTSCD.UserID.Value);
                            if ((Int32)radioDuyet.EditValue == 0)
                            {
                                duyet = false;
                                _nVNgungvaTaiSuDungTSCD.HoanTat = duyet;
                                if (_user.GroupID == 38)
                                {
                                   emailNhan = userLap.EmailHRM;
                                   SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Không Duyệt Chứng Từ {_nVNgungvaTaiSuDungTSCD.SoChungTu}", "Chứng từ ngừng sử dụng TSCĐ:" + _nVNgungvaTaiSuDungTSCD.SoChungTu + " không được duyệt! Với lý do: " + _nVNgungvaTaiSuDungTSCD.LyDo);
                                }
                                else
                                {
                                    _nVNgungvaTaiSuDungTSCD.TinhTrang = null;
                                    SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đề Nghị Duyệt Chứng Từ {_nVNgungvaTaiSuDungTSCD.SoChungTu}", "Đề nghị duyệt chứng từ ngừng sử dụng TSCĐ có số:" + _nVNgungvaTaiSuDungTSCD.SoChungTu + " với nội dung:" + _nVNgungvaTaiSuDungTSCD.GhiChu);
                                }
                            }
                            else
                            {
                                duyet = true;
                                _nVNgungvaTaiSuDungTSCD.UserIDNgDuyetCongTy = _user.UserID;
                                _nVNgungvaTaiSuDungTSCD.NgayDuyetCongTy = DateTime.Today.Date;
                                _nVNgungvaTaiSuDungTSCD.HoanTat = duyet;
                                SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đã Duyệt Chứng Từ {_nVNgungvaTaiSuDungTSCD.SoChungTu}", "Chứng từ ngừng sử dụng TSCĐ có số:" + _nVNgungvaTaiSuDungTSCD.SoChungTu + " đã được duyệt!");
                                // 13/11/2020
                                foreach (tblCT_NVNgungvaTaiSuDungTSCD ct in _nVNgungvaTaiSuDungTSCD.tblCT_NVNgungvaTaiSuDungTSCD)
                                {
                                    ct.tblTaiSanCoDinhCaBiet.NgungSuDung = true;
                                    ct.tblTaiSanCoDinhCaBiet.TinhTrang = "Ngưng Sử Dụng";
                                }
                            }
                        }
                        else
                        {
                            SendEmail_DKAPP(emailNhan, emailGui, matKhauEmailGui, String.Empty, 587, $"Đề Nghị Duyệt Chứng Từ {_nVNgungvaTaiSuDungTSCD.SoChungTu}", "Đề nghị duyệt chứng từ ngừng sử dụng TSCĐ :" + _nVNgungvaTaiSuDungTSCD.SoChungTu + " với nội dung:" + _nVNgungvaTaiSuDungTSCD.GhiChu);
                        }
                        tblNVNgungvaTaiSuDungTSCDBindingSource.EndEdit();
                        // Lưu nghiệp vụ điều chuyển nội bộ
                        this._nVNgungvaTaiSuDungTSCD_Factory.SaveChanges(BusinessCodeEnum.TSCD_NgungSuDung.ToString());

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
        #endregion
        //Event Method
        #region Event Method


        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_NgungSuDung, this.MdiParent);
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.ChangeFocus();
            //lấy mã phòng ban đang chọn trong điều kiện tìm
            //Int32 maPhongBanDangChon = Convert.ToInt32(cbPhongBan.EditValue)
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
                DataTable _taiSanCDCaBiet = new DataTable();
                _taiSanCDCaBiet = dt_TaiSanCoDinhCaBiet(DateTime.Now.Date, maPhongBanDangChon, maViTri, maTSCDDangChon, _user.MaCongTy, 0);
                grdControl_TaiSanCDCBCaBiet.DataSource = _taiSanCDCaBiet;
                if (grdViewTSCDCaBiet.RowCount > 0 && tblCTNVNgungvaTaiSuDungTSCDBindingSource.Count > 0)
                {
                    //Xóa dòng ĐÃ được chọn trước khi đưa vào chứng từ 
                    RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
                }
            }
            if (grdViewTSCDCaBiet.RowCount == 0)
            {
                DialogUtil.ShowOK("Không có dữ liệu!");
            }
        }
        // bổ sung 11/11/2020 
        public static DataTable dt_TaiSanCoDinhCaBiet(
                Nullable<System.DateTime> denNgay, Nullable<int> maBoPhan, Nullable<int> maViTri, Nullable<int> maLoai, Nullable<int> maCongTy, Nullable<int> loaiBaoCao)
        {
            DataTable kq = new DataTable();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TSCD_DanhSachTaiSanCoDinhHayCCDCCoDenNgay_TheoPhongBanViTriLoaiTaiSanDaLapCTNgung";
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@MaViTri", maViTri);
                    cm.Parameters.AddWithValue("@MaLoai", maLoai);
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                    cm.Parameters.AddWithValue("@LoaiBaoCao", loaiBaoCao);                   
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(kq);
                }
            }
            return kq;
        }
        private void PhanQuyenThemSuaXoa()
        {
            PhanQuyenSuDungForm _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(ERP_Library.Security.CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            btnThem.Enabled = _phanQuyen.Them;
            btnLuu.Enabled = _phanQuyen.Sua;
            btnXoa.Enabled = _phanQuyen.Xoa;
        }
        private void frmDieuChuyenNoiBoTSCDCaBiet_Load(object sender, EventArgs e)
        {
            //Khởi tạo dữ liệu
            _nVNgungvaTaiSuDungTSCD_Factory = NVNgungvaTaiSuDungTSCD_Factory.New();

            //Lấy dữ liệu
            //_boPhanList = BoPhan_Factory.New().GetAll();
            //_boPhan_LichSuDCList = BoPhan_Factory.New().GetAll().ToList();
            //tblnsBoPhan boPhan_ChonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất Cả>>", TenBoPhan = "Tất Cả" };

            _boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(_user.MaCongTy).ToList();
            tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _boPhanList.Insert(0, boPhan_chonTatCa);
            // _boPhan_LichSuDCList.Insert(0, boPhan_ChonTatCa);
            //Lấy bộ phận
            _viTriList = BoPhanERPNew_Factory.New().GetAll().ToList();
            tblBoPhanERPNew boPhan_vitri_chonTatCa = new tblBoPhanERPNew() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _viTriList.Insert(0, boPhan_vitri_chonTatCa);
            //Đưa checkbox lên lưới
            GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewTSCDCaBiet, colChon);

            // Set số thứ tự cho lưới
            GridUtil.SetSTTForGridView(grdViewTSCDCaBiet);
            GridUtil.SetSTTForGridView(gridView_CTNgungVaTaiSuDung);


            if (_xemLaiNVNgungvaTaiSuDungTSCD == true && _maNVNgungvaTaiSuDungTSCD != 0)
            {
                XemLaiChungTuCu(_maNVNgungvaTaiSuDungTSCD);
            }
            else
            {
                //khởi tạo nghiệp vụ ngừng và tái sử dụng
                _nVNgungvaTaiSuDungTSCD = _nVNgungvaTaiSuDungTSCD_Factory.NewNVNgungVaTaiSuDung_NgungSuDung();
            }

            //cài đặt delete helper
            GridUtil.DeleteHelper.Setup_ManualType(gridView_CTNgungVaTaiSuDung, (GridView gridView, List<Object> deleteList) =>
            {
                //xóa chi tiết nghiệp vụ điều chuyển nội bộ
                CT_NVNgungvaTaiSuDungTSCD_Factory.FullDeleteCT_NVNgungSuDungTSCD(context: _nVNgungvaTaiSuDungTSCD_Factory.Context, deleteList: deleteList);
            });
            this.GanBindingSource();
            if (_user.TenDangNhap.ToLower().Equals("admin") || _user.GroupID == 38)
            {
                radioDuyet.Enabled = true;
                textEdit_LyDo.Enabled = true;
            
            }
            else
            {
                if (_nVNgungvaTaiSuDungTSCD.TinhTrang == 1)
                    ReadOnlyConTrolByStatus();
            }
            PhanQuyenThemSuaXoa();
        }
        private void ReadOnlyConTrolByStatus()
        {
            grdViewTSCDCaBiet.OptionsBehavior.ReadOnly = true;
            gridView_CTNgungVaTaiSuDung.OptionsBehavior.ReadOnly = true;
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


            }
            btnDuaTaiSanVaoChungTu.Enabled = false;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
         

        }
        private void btnDuaTaiSanVaoChungTu_Click(object sender, EventArgs e)
        {
            #region old
            //this.ChangeFocus();
            //if (_taiSanCDCaBietList != null && _taiSanCDCaBietList.Count > 0)
            //{
            //    Boolean coTaiSanCaBietDuocChonTuDanhSach = false;

            //    if (_taiSanCDCaBietList == null)
            //        return;

            //    //lặp qua từng dòng tài sản tìm được
            //    foreach (tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet in _taiSanCDCaBietList)
            //    {
            //        //nếu tài sản được chọn
            //        if (taiSanCoDinhCaBiet.Chon == true)
            //        {
            //            coTaiSanCaBietDuocChonTuDanhSach = true;

            //            //khởi tạo chi tiết nghiệp vụ ngừng và tái sử dụng 
            //            tblCT_NVNgungvaTaiSuDungTSCD chiTietNVNgungvaTaiSuDungTSCD = CT_NVNgungvaTaiSuDungTSCD_Factory.New().CreateAloneObject();
            //            chiTietNVNgungvaTaiSuDungTSCD.MaTSCDCaBiet = taiSanCoDinhCaBiet.MaTSCDCaBiet;

            //            //Đưa vào danh sách chi tiết nghiệp vụ ngừng và tái sử dụng
            //            _nVNgungvaTaiSuDungTSCD.tblCT_NVNgungvaTaiSuDungTSCD.Add(chiTietNVNgungvaTaiSuDungTSCD);

            //            //Cập nhật ngừng và tái sử dụng tài sản cố định cá biệt
            //            chiTietNVNgungvaTaiSuDungTSCD.tblTaiSanCoDinhCaBiet.NgungSuDung = true;
            //        }
            //    }

            //    //thông báo người dùng nếu chưa chọn bất cứ dòng nào từ danh sách duyệt
            //    if (coTaiSanCaBietDuocChonTuDanhSach == false)
            //    {
            //        DialogUtil.ShowWarning("Chưa chọn dữ liệu.");
            //        return;
            //    }
            //    // Xóa tài sản cố định cá biệt vừa chọn ra khỏi danh sách tìm
            //    RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();

            //    //Gán bindingsource
            //    this.GanBindingSource();
            //}
            #endregion end old
            try
            {
                this.ChangeFocus();
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
                                    //khởi tạo chi tiết nghiệp vụ ngừng và tái sử dụng 
                                    tblCT_NVNgungvaTaiSuDungTSCD chiTietNVNgungvaTaiSuDungTSCD = CT_NVNgungvaTaiSuDungTSCD_Factory.New().CreateAloneObject();
                                    chiTietNVNgungvaTaiSuDungTSCD.MaTSCDCaBiet = Convert.ToInt32(dr["MaTSCDCaBiet"].ToString());
                                    //Đưa vào danh sách chi tiết nghiệp vụ ngừng và tái sử dụng
                                    _nVNgungvaTaiSuDungTSCD.tblCT_NVNgungvaTaiSuDungTSCD.Add(chiTietNVNgungvaTaiSuDungTSCD);
                                    //Cập nhật ngừng và tái sử dụng tài sản cố định cá biệt
                                    //chiTietNVNgungvaTaiSuDungTSCD.tblTaiSanCoDinhCaBiet.NgungSuDung = true;
                                }

                                
                            }
                        }
                        // Xóa tài sản cố định cá biệt vừa chọn ra khỏi danh sách tìm
                        RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
                        tabNgungSuDungTaiSanCoDinhCaBiet.SelectedTabPage = xtraTabPage1; //chuyển focus sang tab chứng từ 
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
            if (_nVNgungvaTaiSuDungTSCD == null)
            {
                DialogUtil.ShowWarning("Chứng từ rỗng.");
                return;
            }
            if (Ky_Factory.New().DaKhoaSoTSCD(_nVNgungvaTaiSuDungTSCD.NgayChungTu, _user.MaCongTy))
            {
                //bật thông báo đã khóa sổ
                DialogUtil.ShowDaKhoaSoTSCD(_nVNgungvaTaiSuDungTSCD.NgayChungTu);

            }
            else
            {
                if (_nVNgungvaTaiSuDungTSCD.UserID == _user.UserID && DialogResult.Yes == DialogUtil.ShowYesNo(String.Format("Bạn muốn xóa chứng từ [{0}]?", this.Text)))
                {
                    try
                    {
                        //Xóa nghiệp vụ điều chuyển nội bộ
                        _nVNgungvaTaiSuDungTSCD_Factory.FullDeleteNghiepVu_NgungSuDung(_nVNgungvaTaiSuDungTSCD);
                        _nVNgungvaTaiSuDungTSCD_Factory.SaveChanges();
                        DialogUtil.ShowDeleteSuccessful();

                        // Cài đặt lại dữ liệu
                        _nVNgungvaTaiSuDungTSCD_Factory = NVNgungvaTaiSuDungTSCD_Factory.New();
                        _nVNgungvaTaiSuDungTSCD = _nVNgungvaTaiSuDungTSCD_Factory.CreateAloneObject();
                        //Gán bindingSource
                        GanBindingSource();
                    }
                    catch (Exception)
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
        private void btnDanhSachChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachNgungSuDungTSCDCaBiet.ShowSingleton(null, this.MdiParent);
        }
       
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dlgResult = DialogUtil.ShowSaveRequireOptions(this);
            if (dlgResult == DialogResult.Yes)
            {
                if (this.Save() == false)
                    return;
            }
            //Khởi tạo lại factory
            _nVNgungvaTaiSuDungTSCD_Factory = NVNgungvaTaiSuDungTSCD_Factory.New();
            //khởi tạo nghiệp vụ ngừng và tái sử dụng
            _nVNgungvaTaiSuDungTSCD = _nVNgungvaTaiSuDungTSCD_Factory.NewNVNgungVaTaiSuDung_NgungSuDung();
            //Gán bindingSource
            this.GanBindingSource();
        }
        #endregion

        private void frmNgungSuDungTSCDCaBiet_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_nVNgungvaTaiSuDungTSCD_Factory.IsDirty)
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

        private void btnTaiFileChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_nVNgungvaTaiSuDungTSCD.MaNghiepVu == 0)
            {
                DialogUtil.ShowInfo("Vui lòng lưu chứng từ trước khi up file!");
                return;
            }
            else
            {                                           //98 là Mã TSCD Ngưng sử dụng không có trong tblLoaiChungTu
                frmNTSD_ChonFilesUpLoad frm_upFile = new frmNTSD_ChonFilesUpLoad(_nVNgungvaTaiSuDungTSCD.MaNghiepVu ,98); 
                frm_upFile.ShowDialog();
            }
        }

        private void treeListLookUpEdit_BoPhan_Tim_EditValueChanged(object sender, EventArgs e)
        {
            int maPhongBan = Convert.ToInt32(treeListLookUpEdit_BoPhan_Tim.EditValue);
            //lấy danh sách tên tài sản
            {
                _tscdList = DanhMucTSCD_Factory.New().Get_DanhSachTaiSanCoDinh_ConSuDung_ByMaPhongBan(maPhongBan).ToList();
                tblDanhMucTSCD tscd_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
                _tscdList.Insert(0, tscd_chonTatCa);
            }
            //Gán bindigsource
            GanBindingSource();

         
        }

        private void deNgayLap_EditValueChanged(object sender, EventArgs e)
        {
            DateTime ngayChungTu = deNgayLap.DateTime.Date;
            if (ngayChungTu != new DateTime(1, 1, 1) && deNgayLap.DateTime.Date != _nVNgungvaTaiSuDungTSCD.NgayChungTu)
            {
                _nVNgungvaTaiSuDungTSCD.NgayChungTu = ngayChungTu;
                if (_nVNgungvaTaiSuDungTSCD.MaNghiepVu == 0)
                    _nVNgungvaTaiSuDungTSCD.SoChungTu = NVNgungvaTaiSuDungTSCD_Factory.New().Get_NextSoChungTu_ByYear_And_Month_NgungSuDung(_nVNgungvaTaiSuDungTSCD.NgayChungTu.Year, _nVNgungvaTaiSuDungTSCD.NgayChungTu.Month, PSC_ERP_Global.Main.UserID);
                
            }
        }
    }
}
