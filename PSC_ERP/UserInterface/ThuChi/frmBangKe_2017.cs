using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using PSC_ERP;
using ERP_Library.ThanhToan;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using PSC_ERPNew.Main.PhanHe.DIGITIZING;
using System.Linq;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
//long 

namespace PSC_ERP
{//4-1-2010
    //Thành
    public partial class frmBangKe_2017 : Form
    {
        #region Properties
        int maLoaiDoiTuong = 0;
        HamDungChung hamDungChung = new HamDungChung();
        DoiTuongAllList _doiTuongList;
        public ChiThuLaoList _ChiThuLaoList = ChiThuLaoList.NewChiThuLaoList();
        public int LoaiChi = 0;
        long maDoiTuong = 0;
        TieuMucNganSachList _TieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();

        //
        public static ChungTu _ChungTu = ChungTu.NewChungTu();
        ButToanList _ButToanList = ButToanList.NewButToanList();
        LoaiTienList _LoaiTienList = LoaiTienList.NewLoaiTienList();
        HeThongTaiKhoan1List _HeThongTaiKhoan1ListCo, _HeThongTaiKhoanSearchCo, _HeThongTaiKhoanSearchNo, _HeThongTaiKhoan1ListNo;
        DoiTuongAll _DoiTuongAll = DoiTuongAll.NewDoiTuongAll(1);
   
        public static ChiThuLaoList _chiThuLaoList_DaChon = ChiThuLaoList.NewChiThuLaoList();

        static public int DoiTuongThu_Chi = -1;

        static decimal TongTien = 0;

        Util _Util = new Util();
        static decimal soTien = 0;
        long soChungTu = 0;// dùng cho cập nhật các đề nghị thanh toán, chuyển khoản
        public long MaKhachHang = 0;

        static int Phieu = 2; // PhieuThu = 2; PhieuChi = 3; UyNhiemChi = 6; UyNhiemThu = 7; PhieuChuyenKhoan = 8

        public bool flag = false;

        int maTKNoSearch = 0; int maTKCoSearch = 0;
        long MaDangNhap = ERP_Library.Security.CurrentUser.Info.UserID;
        string SoChungTuTuDongTang = string.Empty;
        DateTime NgayLap = DateTime.Today;

        DoiTuongAll dtKhachHang = DoiTuongAll.NewDoiTuongAll(0);

        string SoCTMoiPS = "";
        //
        DoiTuongThuChiList _DoiTuongThuChiList;
        int MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

        ChungTuList _ChungTuList;
        public TamUngList _tamUngList = TamUngList.NewTamUngList();
        HopDongMuaBanList _hopDongList;
     
        PhanBoChiPhiCCDC _phanBoChiPhiCCDC = PhanBoChiPhiCCDC.NewPhanBoChiPhiCCDC();

        DataSet dataSet = new DataSet();
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        private DateTime _ngayKhoaSo;

        #region Them Khoa So Thue
        private bool _loadFormFinish = false;
        DateTime _ngayLapCu = DateTime.Today;
        private bool _co_ultraCombo_NoTaiKhoanValueChange = false;
        private bool _co_ultraCombo_CoTaiKhoanValueChange = false;
        #endregion

        #endregion

        #region LayDuLieuLenLuoi
        private void LayDuLieuLenLuoi()
        {
            //Cấu trúc bảng danh sách chứng từ kèm theo
            TaoCauTrucBang();
            _LoaiTienList = LoaiTienList.GetLoaiTienList();
            LoaiTien_BindingSource.DataSource = _LoaiTienList;
            // tai khoan
            _HeThongTaiKhoan1ListCo = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            HeThongTaiKhoan1 tk = HeThongTaiKhoan1.NewHeThongTaiKhoan1("Tất Cả");
            _HeThongTaiKhoan1ListCo.Insert(0, tk);
            CoTaiKhoan_BindingSource.DataSource = _HeThongTaiKhoan1ListCo;
            _HeThongTaiKhoan1ListNo = _HeThongTaiKhoan1ListCo;

            _HeThongTaiKhoanSearchCo = _HeThongTaiKhoan1ListNo;
            _HeThongTaiKhoanSearchNo = _HeThongTaiKhoanSearchCo;
            NoTaiKhoan_BindingSource.DataSource = _HeThongTaiKhoan1ListNo;
            bdCoTKSearch.DataSource = _HeThongTaiKhoan1ListCo;
            bdNoTKSearch.DataSource = _HeThongTaiKhoan1ListCo;

            ////_TieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            ////TieuMucNganSach_BindingSource.DataSource = _TieuMucNganSachList;

            // doi tuong
            _DoiTuongThuChiList = DoiTuongThuChiList.GetDoiTuongThuChiList(MaCongTy);
            DoiTuongThuChi_BindingSource.DataSource = _DoiTuongThuChiList;

            ////// đôi tương no thu chu chi trong bút toan 
            ////DoiTuongAll dt = DoiTuongAll.NewDoiTuongAll("Không Chọn");
            ////_DoiTuongNoList = DoiTuongAllList.GetDoiTuongAllList_Tim("");
            ////_DoiTuongNoList.Insert(0, dt);
            ////DoiTuongNoList_BindingSource.DataSource = _DoiTuongNoList;
            ////// doi tuong co
            ////DoiTuongCoList_BindingSource.DataSource = _DoiTuongNoList;//_DoiTuongCoList;

        }
        #endregion

        #region frmBangKe
        public frmBangKe_2017()
        {
            InitializeComponent();
            KhoiTao();
            TaoMoiChungTu(16);
        }

        public frmBangKe_2017(PhanBoChiPhiCCDC phanBoChiPhiCCDC)
        {
            InitializeComponent();
            KhoiTao();
            TaoMoiChungTu(phanBoChiPhiCCDC);

        }

        public frmBangKe_2017(ChungTu chungTu)
        {
            InitializeComponent();
            KhoiTao();
            TaoChungTu(chungTu);

        }

        #endregion

        private void KhoiTao()
        {
            //bt_TamUng.Enabled = false;
            ChungTu_BindingSource.DataSource = typeof(ERP_Library.ChungTu);
            DinhKhoan_BindingSource.DataSource = typeof(ERP_Library.DinhKhoan);
            ButToan_BindingSource.DataSource = typeof(ERP_Library.ButToanList);
            TienTe_BindingSource.DataSource = typeof(ERP_Library.TienTe);
            NoTaiKhoan_BindingSource.DataSource = typeof(ERP_Library.HeThongTaiKhoan1List);
            CoTaiKhoan_BindingSource.DataSource = typeof(ERP_Library.HeThongTaiKhoan1List);
            KhachHang_BindingSource.DataSource = typeof(ERP_Library.DoiTuongAllList);
            LoaiTien_BindingSource.DataSource = typeof(ERP_Library.LoaiTienList);
            PPThanhToan_BindingSource.DataSource = typeof(ERP_Library.PhuongThucThanhToanList);
            DoiTuongThuChi_BindingSource.DataSource = typeof(ERP_Library.DoiTuongThuChiList);
            DSChungTu_BindingSource.DataSource = typeof(ERP_Library.ChungTuList);
            ChungTu_TaiKhoan_BindingSource.DataSource = typeof(ERP_Library.ChungTu_TaiKhoanList);
            bdCoTKSearch.DataSource = typeof(ERP_Library.HeThongTaiKhoan1List);
            bdNoTKSearch.DataSource = typeof(ERP_Library.HeThongTaiKhoan1List);
            DoiTuong_BindingSource.DataSource = typeof(ERP_Library.DoiTuongAllList);
            LoaiTien_BindingSource.DataSource = typeof(ERP_Library.LoaiTienList);
            tlslblXoa.Visible = false;
            toolStripSeparator2.Visible = false;

            tlslblUndo.Visible = false;
            toolStripSeparator3.Visible = false;
      
            this.WindowState = FormWindowState.Maximized;

            dtmp_Ngay.Value = DateTime.Today;
            txtSoChungTuKemTheo.Value = 1;
            hamDungChung.EventForm(this);
            DesignGridControls();
        }

        #region TaoMoiChungTu
        private void TaoMoiChungTu(int loaiChungTu)
        {
            _ChungTu = ChungTu.NewChungTu(loaiChungTu);
            ChungTu_BindingSource.DataSource = _ChungTu;
            _ChungTu.SoChungTuKemTheo = 1;
            TienTe_BindingSource.DataSource = _ChungTu.Tien;
            DinhKhoan_BindingSource.DataSource = _ChungTu.DinhKhoan;
            ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
            soTien = 0;
            TongTien = 0;
            dtmp_Ngay.Value = DateTime.Today;
            bdChungTu.DataSource = _ChungTu.ChungTuDeNghiList;
                        _ngayLapCu = _ChungTu.NgayLap;
        }
        #endregion

        #region TaoChungTu

        private void TaoChungTu(ChungTu chungTu)
        {
            _ChungTu = chungTu;
            ChungTu_BindingSource.DataSource = _ChungTu;
            TienTe_BindingSource.DataSource = _ChungTu.Tien;
            DinhKhoan_BindingSource.DataSource = _ChungTu.DinhKhoan;
            ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
            dtmp_Ngay.Value = DateTime.Today;
            bdChungTu.DataSource = _ChungTu.ChungTuDeNghiList;

            _ngayLapCu = _ChungTu.NgayLap;
        }

        #endregion

        #region TaoMoiChungTutuPhanBoChiPhi

        private void TaoMoiChungTu(PhanBoChiPhiCCDC phanBoChiPhiCCDC)
        {
            _ChungTu = ChungTu.NewChungTu(16);
            _phanBoChiPhiCCDC = phanBoChiPhiCCDC;
            decimal tongTien = 0;
            foreach (CT_PhanBoChiPhiCCDC ct in _phanBoChiPhiCCDC.CT_PhanBoChiPhiCCDCList)
            {
                tongTien += ct.SoTienPhanBo;
            }
            _ChungTu.SoTien = tongTien;
            ChungTu_BindingSource.DataSource = _ChungTu;
            _ChungTu.SoChungTuKemTheo = 1;
            TienTe_BindingSource.DataSource = _ChungTu.Tien;
            DinhKhoan_BindingSource.DataSource = _ChungTu.DinhKhoan;      
            dtmp_Ngay.Value = DateTime.Today;
            bdChungTu.DataSource = _ChungTu.ChungTuDeNghiList;
            _ngayLapCu = _ChungTu.NgayLap;
        }

        #endregion

        #region New
        private void New()
        {

            TongTien = 0;
            soTien = 0;

            txtu_DienGiai.Clear();
            txtutxeditSoCT.Clear();
        }
        #endregion

        #region LayDoiTuongThuChi
        private void LayDoiTuongThuChi(int Phieu)
        {
            if (Phieu == 8)
            {
                #region Phieu Chuyen Khoan
                group_ThongTinPhieu.Text = "Thông Tin Chuyển Khoản";
                lbl_DoiTuong.Text = "Đối Tượng CK";
                lbl_SoTien.Text = "Số Tiền CK";
                lbl_Ngay.Text = "Ngày CK";

                btnu_InUyNhiem.Visible = false;

                tlslblIn.Visible = true;
                toolStripButton1.Visible = true;

                TaoMoiChungTu(8);
                Phieu = 8;// Phieu Chuyen Khoan
           

                #endregion
            }
        }
        #endregion

        #region LayDoiTuongThuChi_KhongTaoMoi
        private void LayDoiTuongThuChi_KhongTaoMoi(int Phieu)
        {
            ClearChiTietKH();
            if (Phieu == 16)
            {
                #region Phieu Ke Toan

                group_ThongTinPhieu.Text = "Thông Tin Kế toán";
                lbl_DoiTuong.Text = "Phiếu KT";
                lbl_SoTien.Text = "Số Tiền KT";
                lbl_Ngay.Text = "Ngày KT";
                btnu_InUyNhiem.Visible = false;
                tlslblIn.Visible = true;
                toolStripButton1.Visible = true;
              
                btnu_InUyNhiem.Visible = false;
                tlslblIn.Visible = true;
                #endregion
            }
        }

        private void ClearChiTietKH()
        {
            txtNguoiNhan.Clear();
            txtDiaChi.Clear();
        }
        private void ShowKH()
        {
            ClearChiTietKH();
            txtNguoiNhan.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            btnDSKhachHang.Enabled = false;
            dtKhachHang = DoiTuongAll.NewDoiTuongAll(0);
        }
        private void HideKH()
        {
            ClearChiTietKH();
            txtNguoiNhan.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            btnDSKhachHang.Enabled = true;
        }
        #endregion

        #region LayKhachHang
        private void LayKhachHang(long maKhachHang)
        {
            _DoiTuongAll = DoiTuongAll.GetDoiTuongAll(maKhachHang);
            KhachHang_BindingSource.DataSource = _DoiTuongAll;
            MaKhachHang = _DoiTuongAll.MaDoiTuong;
            _ChungTu.DoiTuong = _DoiTuongAll.MaDoiTuong;

        }
        #endregion


        #region Function Them Khoa So Thue
        private bool KhoaSoThue()
        {
            bool khoasothue = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ChungTu.NgayLap);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSoThue == true)
                {
                    khoasothue = true;
                }
            }
            //
            if (khoasothue == false && _ChungTu.IsNew == false)
            {
                khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSoThue == true)
                    {
                        khoasothue = true;
                    }
                }
            }
            return khoasothue;
        }//Them

        private bool CheckCoTaiKhoanThueTrongButToan()
        {
            foreach (ButToan buttoan in _ChungTu.ButToanList)
            {
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                HeThongTaiKhoan1 tkco = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.CoTaiKhoan);
                if (tk.SoHieuTK.StartsWith("3113") || tk.SoHieuTK.StartsWith("3337") || tkco.SoHieuTK.StartsWith("3337"))
                {
                    return true;
                }
            }
            return false;
        }


        private bool CheckValidKhoaSoThueWhenChangeNgayNX()//Them
        {
            if (_ChungTu.IsNew == false)
            {
                bool khoasotheoNgaylapcu = false;
                bool khoasotheoNgayNX = false;
                //duyet  theo ngay lap cu
                KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSoThue == true)
                    {
                        khoasotheoNgaylapcu = true;
                    }
                }

                if (khoasotheoNgaylapcu)
                {
                    if (CheckCoTaiKhoanThueTrongButToan())
                    {
                        _ChungTu.NgayLap = _ngayLapCu;
                        dtmp_Ngay.Value = _ngayLapCu as object;
                        MessageBox.Show("Ngày lập phiếu đã Khóa sổ Thuế, không thể thay đổi", "Thông Báo");
                        return false;
                    }
                }
                else
                {
                    //duyet  theo ngay nhap xuat
                    KhoaSo_UserList khoa_NgayNX = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ChungTu.NgayLap);
                    if (khoa_NgayNX.Count > 0)
                    {
                        if (khoa_NgayNX[0].KhoaSoThue == true)
                        {
                            khoasotheoNgayNX = true;
                        }
                    }

                    if (khoasotheoNgayNX)
                    {
                        if (CheckCoTaiKhoanThueTrongButToan())
                        {
                            _ChungTu.NgayLap = _ngayLapCu;
                            dtmp_Ngay.Value = _ngayLapCu as object;
                            MessageBox.Show("Ngày thay đổi rơi vào ngày Khóa sổ Thuế, không thể thực hiện", "Thông Báo");
                            return false;
                        }

                    }

                }
            }

            return true;
        }

 
        #endregion

        #region frmCongNo_Load
        private void frmCongNo_Load(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
            tabControl1.SelectedIndex = 2;
            Phieu = 16;
            SetSoChungTuMoiPS(16);
            //_doiTuongList = DoiTuongAllList.GetDoiTuongAllListByTaiKhoanTheoDoi();
            //DoiTuongAll itemAdd = DoiTuongAll.NewDoiTuongAll("Không Chọn");
            //this._doiTuongList.Insert(0, itemAdd);
            //this.DoiTuong_BindingSource.DataSource = _doiTuongList;

            TaoCauTrucBang();
        }
        #endregion

        #region crreu_SoTien_ValueChanged
        private void crreu_SoTien_ValueChanged(object sender, EventArgs e)
        {
            if ((decimal)crreu_SoTien.Value != 0)
            {

                soTien = Convert.ToDecimal(crreu_SoTien.Value);
                crre_ThanhTien.Value = soTien * crre_TyGia.Value;
            }
        }
        #endregion

       
        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {

            if (chkKhachHang.Checked == true)
            {
                maDoiTuong = 0;
                _ChungTu.MaLoaiDoiTuong = 4;
            }
            else if (maDoiTuong != 0)
                _ChungTu.MaLoaiDoiTuong = maLoaiDoiTuong;

            if (cboDoiTuongThuChi.ActiveRow != null)
            {
                _ChungTu.MaDoiTuongThuChi = (Int32)cboDoiTuongThuChi.ActiveRow.Cells["MaDoiTuongThuChi"].Value;
            }
            else
            {
                cboDoiTuongThuChi.Focus();
                MessageBox.Show(this, "Vui lòng chọn công viêc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkKhachHang.Checked == true)
            {

                _ChungTu.DoiTuong = 0;
                _ChungTu.ChungTu_DiaChi.Ten = txtNguoiNhan.Text;
                _ChungTu.ChungTu_DiaChi.DiaChi = txtDiaChi.Text;
            }
            else
            {
                _ChungTu.DoiTuong = dtKhachHang.MaDoiTuong;

            }
            if ((DateTime)dtmp_Ngay.Value <= Convert.ToDateTime("31-12-2013"))
            {
                MessageBox.Show(this, "Ngày lập phải lớn hơn ngày 31-12-2013", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtutxeditSoCT.Text == "" || KiemTraSoChungTu(txtutxeditSoCT.Text) == false)
            {
                if (Convert.ToInt32(ultrcobo_LoaiTien.ActiveRow.Cells["MaLoaiTien"].Value) == 1)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Số Chứng Từ theo định dạng 1234B/DVXX", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Số Chứng Từ theo định dạng 1234NTB/DVXX", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (_ChungTu.MaChungTu == 0)
                    txtutxeditSoCT.Text = SoCTMoiPS;
                else
                    txtutxeditSoCT.Text = _ChungTu.SoChungTu;
                txtutxeditSoCT.Focus();
                return;
            }

            else if (ChungTu.KiemTraSoChungTu(txtutxeditSoCT.Text, _ChungTu) == true)
            {
                MessageBox.Show(this, "Số Chứng Từ Đã Có Vui Lòng Nhập SCT Khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtutxeditSoCT.Focus();
                return;
            }
            else if (Convert.ToDecimal(crreu_SoTien.Value) == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Số Tiền Chứng Từ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                crreu_SoTien.Focus();
                return;
            }

            _ChungTu.SoChungTu = txtutxeditSoCT.Text;
            this.ChungTu_BindingSource.RaiseListChangedEvents = false;
            Decimal sum = 0;


            foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
            {
                if (ERP_Library.Security.CurrentUser.Info.MaCongTy == 3)//Hang Phim TFS
                {
                    if (buttoan.ChungTuChiPhiSanXuatList.Count == 0)
                    {
                        MessageBox.Show(this, "Bạn phải chọn công việc/chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
            {
                HeThongTaiKhoan1 httkno = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                HeThongTaiKhoan1 httkco = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.CoTaiKhoan);
                string noTK = httkno.SoHieuTK;
                string CoTK = httkco.SoHieuTK;
                decimal soTienChiPhiSanXuatChuongTrinh = 0;

                if (httkno.CoDoiTuongTheoDoi == true)
                {
                    if (buttoan.DoiTuongNo == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng nợ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (httkco.CoDoiTuongTheoDoi == true)
                {
                    if (buttoan.DoiTuongCo == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng Có ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (noTK == "1551" || noTK == "1552" || CoTK == "1551" || CoTK == "1552" || noTK.Contains("631") || noTK.Contains("4314"))
                {
                    if (buttoan.ChungTuChiPhiSanXuatList.Count == 0)
                    {
                        MessageBox.Show(this, "Bạn phải chọn công việc/chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        foreach (ChungTu_ChiPhiSanXuat cp in buttoan.ChungTuChiPhiSanXuatList)
                        {
                            if (cp.ButtoanMucNganSachList.Count == 0 && (noTK.Contains("631") || noTK.Contains("4314")))
                            {
                                MessageBox.Show(this, "Vui lòng nhập mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }


                foreach (ChungTu_ChiPhiSanXuat cp in buttoan.ChungTuChiPhiSanXuatList)
                {
                    soTienChiPhiSanXuatChuongTrinh += cp.SoTien;
                    decimal soTienMucNganSach = 0;
                    foreach (ButToanMucNganSach butToanNganSach in cp.ButtoanMucNganSachList)
                    {
                        soTienMucNganSach += butToanNganSach.SoTien;
                    }
                    if (cp.ButtoanMucNganSachList.Count > 0 && cp.SoTien != soTienMucNganSach)
                    {
                        MessageBox.Show(this, "Số tiền chi phí sản xuất chương trình không bằng số tiền mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (buttoan.ChungTuChiPhiSanXuatList.Count > 0 && buttoan.SoTien != soTienChiPhiSanXuatChuongTrinh)
                {
                    MessageBox.Show(this, "Số tiền chi phí sản xuất chương trình không bằng số tiền bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                sum += buttoan.SoTien;
                if (noTK == "312" || noTK == "312.5" || noTK == "312.9" || noTK == "312.9" || noTK == "312.93" || CoTK == "312" || CoTK == "312.5" || CoTK == "312.9" || CoTK == "312.9" || CoTK == "312.93")
                //if (noTK.Contains("312") )
                {
                    if (_ChungTu.TamUngList.Count == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn nhập tạm ứng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }

            }
            ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
            _ChungTu.NgayThucHien = (DateTime)dtmp_Ngay.Value;
            _ChungTu.Tien.SoTien = crreu_SoTien.Value;
            _ChungTu.SoTien = (decimal)crreu_SoTien.Value;
            _ChungTu.DienGiai = txtu_DienGiai.Text;

            if (_ChungTu.DinhKhoan.ButToan != null)
            {
                if (_ChungTu.DinhKhoan.ButToan.Count != 0)
                {

                    
                    #region BS Kiem tra buttoan đầy đủ No Co
                    foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                    {
                        if (bt.NoTaiKhoan == 0 || bt.CoTaiKhoan == 0)
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin Nợ Có bút toán!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    #endregion
                    _ChungTu.NgayLap = ((DateTime)dtmp_Ngay.Value).Date;

                    if (_ChungTu.Tien.ThanhTien == sum)
                    {
                        if (MessageBox.Show("Ban Có Muốn Save Dữ Liệu Không", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            try
                            {
                                {//Khi cập nhật lại tên khách hàng trong chứng thì phải cập nhật tên khác hàng trong chi phí thực hiện

                                    foreach (ChungTu_ChiPhiSanXuat chungTuChiPhiSanXuat in _ChungTu.ChungTuChiPhiSanXuatList)
                                    {
                                        if (chungTuChiPhiSanXuat.ChiPhiThucHienList.Count != 0 && chungTuChiPhiSanXuat.ChiPhiThucHienList[0].MaDoiTuong != maDoiTuong)
                                        {
                                            chungTuChiPhiSanXuat.ChiPhiThucHienList[0].MaDoiTuong = maDoiTuong;
                                        }
                                    }
                                }

                                if (_ChungTu.IsNew == true)
                                {
                                    _ngayKhoaSo = dtmp_Ngay.DateTime.Date;
                                    KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayKhoaSo);

                                    if (khoa.Count > 0)
                                    {
                                        if (khoa[0].KhoaSo == true)
                                        {
                                            MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }
                                    _ChungTu.NgayLap = dtmp_Ngay.DateTime.Date;
                                    _ChungTu.ApplyEdit();
                                    ChungTu_BindingSource.EndEdit();
                                    ButToan_BindingSource.EndEdit();
                                    _ChungTu.SoTT = ChungTu.GetSoTT() + 1;
                                    _ChungTu.KhoaSo = 1;

                                    _ChungTu.Save();
                                    _ngayKhoaSo = _ChungTu.NgayLap;
                                    _ngayLapCu = _ChungTu.NgayLap;//Them
                                    if (_phanBoChiPhiCCDC.MaPhanBo != 0)
                                    {
                                        _phanBoChiPhiCCDC.MaChungTu = _ChungTu.MaChungTu;
                                        _phanBoChiPhiCCDC.ApplyEdit();
                                        _phanBoChiPhiCCDC.Save();
                                    }
                                }
                                else
                                {
                                    _ChungTu.NgayLap = dtmp_Ngay.DateTime.Date;
                                    KhoaSo_UserList khoaso = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayKhoaSo);

                                    if (khoaso.Count > 0)
                                    {
                                        if (khoaso[0].KhoaSo == true)
                                        {
                                            MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }

                                    _ChungTu.ApplyEdit();
                                    _ChungTu.Save();
                                    _ngayKhoaSo = _ChungTu.NgayLap;
                                    _ngayLapCu = _ChungTu.NgayLap;//Them
                                    ChungTu_BindingSource.DataSource = _ChungTu;
                                    DinhKhoan_BindingSource.DataSource = _ChungTu.DinhKhoan;
                                }

                                //Tiến hành cập nhật lại mã chứng từ chí phí (nếu có)
                                if (_chiThuLaoList_DaChon != null && _chiThuLaoList_DaChon.Count > 0)
                                {
                                    foreach (ButToan itemButToan in _ChungTu.ButToanList)
                                    {
                                        foreach (ChungTu_ChiPhiSanXuat itemChungTu in itemButToan.ChungTuChiPhiSanXuatList)
                                        {
                                            foreach (ChiThuLao item in _chiThuLaoList_DaChon)
                                            {
                                                if (item.MaChuongTrinh == itemChungTu.MaChuongTrinh)
                                                {
                                                    CapNhapMaButToanChiPhiSanXuat(itemChungTu.MactChiphisanxuat, item.MaBoPhanGui, item.MaChuongTrinh, item.SoDNCK, item.LoaiNV);
                                                }
                                            }
                                        }
                                    }
                                }

                                MessageBox.Show(this, "Cập Nhật Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Lỗi khi đang Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            finally
                            {
                                this.ChungTu_BindingSource.RaiseListChangedEvents = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Thành Tiền Trong Chứng Từ Phải Bằng Tổng Tiền Trong Bút Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Vui Lòng Bút Toán Cho Phiếu Này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        #endregion

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            LoaiIn(5);
        }
        ReportDocument Report;
        private void LoaiIn(int loaiIn)
        {
            DataSet _DataSet = new DataSet();

            if (Phieu == 16) // In Phieu Chuyen Khoan
            {
                #region Phieu Chuyen Khoan
                if (loaiIn == 5)
                {
                    Report = new PSC_ERP.Report.CongNo.ChungTuGhiSo();
                }
                else if (loaiIn == 4)
                {
                    Report = new PSC_ERP.Report.CongNo.ChungTuGhiSoA4();
                }


                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_BaoCaoChungTuGhiSo";
                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command2 = new SqlCommand();
                command2.CommandType = CommandType.StoredProcedure;
                command2.CommandText = "spd_LayNguoiKyTenCongNo";
                command2.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);




                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoChungTuGhiSo;1";
                _DataSet.Tables.Add(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(this, "Lưu dữ liệu trước khi in.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                table2.TableName = "spd_LayNguoiKyTenCongNo;1";
                _DataSet.Tables.Add(table2);


                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }

        }

        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, _Util.thaoTac, _Util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                this.Close();
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            cboDoiTuongThuChi.Focus();
            cboDoiTuongThuChi.SelectAll();
            soChungTu = 0;
            tlslblXoa.Visible = false;
            TaoMoiChungTu(16);
            New();
            SetSoChungTuMoiPS(16);

            MaKhachHang = 0;
            cboDoiTuongThuChi.TabIndex = 0;
            TaoBindingDanhSach();

            _chiThuLaoList_DaChon = ChiThuLaoList.NewChiThuLaoList();
            tlslblLuu.Enabled = true;
        }
        #endregion


        #region tlslblTim_Click  ham nay dung de double chung tu len
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            _loadFormFinish = false;

            frmTimChungTuNew f = new frmTimChungTuNew(16);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                if (f.DaChon == true)
                {

                    ButToanList btList = ButToanList.NewButToanList();
                    New();
                    ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu_New(f._ChungTu1.MaChungTu);

                    if (ct.Count > 0)
                    {
                        _ChungTu = ct[0];
                        _ngayLapCu = _ChungTu.NgayLap;//Them
                    }
                    TienTe tt = TienTe.GetTienTe(_ChungTu.MaChungTu);
                    if (_ChungTu.MaChungTu != 0)
                    {
                        if (_ChungTu.NgayLap.Year <= 2013)
                        {
                            tlslblLuu.Enabled = false;
                        }
                        else
                        {
                            tlslblLuu.Enabled = true;
                        }

                        _ngayKhoaSo = _ChungTu.NgayLap;
                        dtmp_Ngay.DateTime = _ChungTu.NgayLap;
                        _ngayKhoaSo = _ChungTu.NgayLap;
                        Phieu = _ChungTu.LoaiChungTu.MaLoaiCT;
                        crreu_SoTien.Value = tt.SoTien;
                        crre_ThanhTien.Value = tt.ThanhTien;
                        maDoiTuong = _ChungTu.DoiTuong;
                        //LayDoiTuongThuChi_KhongTaoMoi(Phieu);
                        ChungTu_BindingSource.DataSource = _ChungTu;
                        TaoBindingDanhSach();
                        DoiTuongThu_Chi = _ChungTu.MaDoiTuongThuChi;
                        TienTe_BindingSource.DataSource = tt;

                        txtutxeditSoCT.Text = _ChungTu.SoChungTu;
                        group_ThongTinPhieu.Enabled = true;
                        tab_DinhKhoan.Enabled = true;

                        ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;

                        if (Phieu != 8)
                        {
                            if (_ChungTu.DoiTuong == 0)
                            {
                                chkKhachHang.Checked = true;
                                txtNguoiNhan.Enabled = true;
                                txtDiaChi.Enabled = true;
                                txtNguoiNhan.Text = _ChungTu.ChungTu_DiaChi.Ten;
                                txtDiaChi.Text = _ChungTu.ChungTu_DiaChi.DiaChi;
                            }
                            else
                            {
                                chkKhachHang.Checked = false;
                                dtKhachHang = DoiTuongAll.GetDoiTuongAll(_ChungTu.DoiTuong);
                                txtNguoiNhan.Text = txtNguoiNhan.Text = dtKhachHang.MaQLDoiTuong + " - " + dtKhachHang.TenDoiTuong;
                                txtDiaChi.Text = dtKhachHang.DiaChi;
                            }
                        }
                      
                        soChungTu = _ChungTu.MaChungTu;
                        tlslblXoa.Visible = true;
                        TongTien = crre_ThanhTien.Value;
                        soTien = tt.SoTien;
                    }
                }
            }
       
        }

        #endregion

        #region TaiKhoan

        #region Gán DataSource
        private void GanDataSource(ChungTu chungTu)
        {
            _ChungTu = chungTu;
            ChungTu_BindingSource.DataSource = _ChungTu;
            DinhKhoan_BindingSource.DataSource = chungTu.DinhKhoan;
            ButToan_BindingSource.DataSource = chungTu.DinhKhoan.ButToan;

            TienTe_BindingSource.DataSource = chungTu.Tien;

            if (_ChungTu.DinhKhoan != null)
            {
                if (_ChungTu.DinhKhoan.ButToan.Count != 0)
                {
                        _ButToanList = ButToanList.GetButToanList_DinhKhoan(_ChungTu.DinhKhoan.ButToan._MaDinhKhoan);
                }
            }
            
        }
        #endregion

      

        private void crreu_SoTien_Leave(object sender, EventArgs e)
        {
            if ((decimal)crreu_SoTien.Value != 0)
            {
                soTien = Convert.ToDecimal(crreu_SoTien.Value);
                _ChungTu.Tien.SoTien = soTien;
            }
        }

        private void txtutxeditSoCT_Leave(object sender, EventArgs e)
        {
            if (ChungTu.KiemTraSoChungTu(txtutxeditSoCT.Text, _ChungTu) == true)
            {
                MessageBox.Show(this, "Số Chứng Từ Này Đã Tồn Tại Vui Lòng Nhập Số Khác ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtutxeditSoCT.Focus();
                return;
            }
            _ChungTu.SoChungTu = txtutxeditSoCT.Text.Trim();

        }

        #endregion

        private void DesignGrid_ButToan()
        {
            gridView_ButToan.DataSource = _ButToanList;
       ////////     HamDungChung.InitGridViewDev(gridView_ButToan, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
       ////////     HamDungChung.ShowFieldGridViewDev(gridView_ButToan, new string[] { "NoTaiKhoan", "CoTaiKhoan", "SoTien", "MaDoiTuongNo", "MaDoiTuongCo", "MaHopDong", "DienGiai" },
       ////////                         new string[] { "Nợ Tài Khoản", "Có Tài Khoản", "Số Tiền", "Đối tượng nợ", "Đối tượng có", "Số hợp đồng", "Diễn Giải" },
       ////////                                      new int[] { 80, 80, 90, 120, 120, 100, 150 });
       ////////     //Column Cong Viec/ChuongTrinh
       ////////     RepositoryItemButtonEdit ButtonEdit_CongViec_CT = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
       ////////     ((System.ComponentModel.ISupportInitialize)(ButtonEdit_CongViec_CT)).BeginInit();
       ////////     ButtonEdit_CongViec_CT.AutoHeight = false;
       ////////     ButtonEdit_CongViec_CT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
       ////////     new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Công việc/Chương trình", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), new DevExpress.Utils.SerializableAppearanceObject(), "", null, null, true)});
       ////////     ButtonEdit_CongViec_CT.Name = "repositoryItemButtonEdit1";
       ////////     ButtonEdit_CongViec_CT.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
       ////////     //add button colCT_ChiPhiSX
       ////////     GridColumn colCT_ChiPhiSX = new GridColumn();
       ////////     colCT_ChiPhiSX.Caption = "Công việc/Chương trình";
       ////////     colCT_ChiPhiSX.ColumnEdit = ButtonEdit_CongViec_CT;
       ////////     colCT_ChiPhiSX.Name = "colCT_ChiPhiSX";
       ////////     colCT_ChiPhiSX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
       ////////     colCT_ChiPhiSX.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
       ////////     colCT_ChiPhiSX.Visible = true;
       ////////     colCT_ChiPhiSX.VisibleIndex = 8;
       ////////     //this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ButtonEdit_CongViec_CT });
       ////////     //gridView_ButToan.Columns.Add(colCT_ChiPhiSX);
       ////////     ((System.ComponentModel.ISupportInitialize)(ButtonEdit_CongViec_CT)).EndInit();

       ////////     #region add Column HoaDon
       ////////     ////Begin Column HoaDon
       ////////     //RepositoryItemButtonEdit ButtonEdit_DsHoaDon = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
       ////////     //((System.ComponentModel.ISupportInitialize)(ButtonEdit_DsHoaDon)).BeginInit();
       ////////     //ButtonEdit_DsHoaDon.AutoHeight = false;
       ////////     //ButtonEdit_DsHoaDon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
       ////////     //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "DS Hóa đơn", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), new DevExpress.Utils.SerializableAppearanceObject(), "", null, null, true)});
       ////////     //ButtonEdit_DsHoaDon.Name = "repositoryItemButtonEdit2";
       ////////     //ButtonEdit_DsHoaDon.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
       ////////     ////add button colChungTu_HoaDon
       ////////     //GridColumn colChungTu_HoaDon = new GridColumn();
       ////////     //colChungTu_HoaDon.Caption = "DS Hóa đơn";
       ////////     //colChungTu_HoaDon.ColumnEdit = ButtonEdit_DsHoaDon;
       ////////     //colChungTu_HoaDon.Name = "colChungTu_HoaDon";
       ////////     //colChungTu_HoaDon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
       ////////     //colChungTu_HoaDon.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
       ////////     //colChungTu_HoaDon.Visible = true;
       ////////     //colChungTu_HoaDon.VisibleIndex = 9;
       ////////     //this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ButtonEdit_DsHoaDon });
       ////////     //gridView_ButToan.Columns.Add(colChungTu_HoaDon);
       ////////     //((System.ComponentModel.ISupportInitialize)(ButtonEdit_DsHoaDon)).EndInit();
       ////////     ////End Column HoaDon 
       ////////     #endregion//add Column HoaDon

       ////////     //this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ButtonEdit_CongViec_CT, ButtonEdit_DsHoaDon });
       ////////     //gridView_ButToan.Columns.Add(colCT_ChiPhiSX);
       ////////     //gridView_ButToan.Columns.Add(colChungTu_HoaDon);

       ////////     //((System.ComponentModel.ISupportInitialize)(ButtonEdit_CongViec_CT)).EndInit();
       ////////     //((System.ComponentModel.ISupportInitialize)(ButtonEdit_DsHoaDon)).EndInit();
       ////////     //

       ////////     HamDungChung.AlignHeaderColumnGridViewDev(gridView_ButToan, new string[] { "NoTaiKhoan", "CoTaiKhoan", "SoTien", "DienGiai", "MaDoiTuongNo", "MaDoiTuongCo", "MaHopDong" }, DevExpress.Utils.HorzAlignment.Center);

       ////////     HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "#,###.#");
       ////////     HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "{0:#,###.#}");
       ////////     HamDungChung.NewRowGridViewDev(gridView_ButToan, NewItemRowPosition.Bottom);

       ////////     Utils.GridUtils.SetSTTForGridView(gridView_ButToan, 50);//M
       ////////     //
       ////////     RepositoryItemGridLookUpEdit TaiKhoanNo_GrdLU = new RepositoryItemGridLookUpEdit();
       ////////     TaiKhoanNo_GrdLU.DataSource = NoTaiKhoan_BindingSource;
       ////////     TaiKhoanNo_GrdLU.DisplayMember = "SoHieuTK";
       ////////     TaiKhoanNo_GrdLU.ValueMember = "MaTaiKhoan";
       ////////     HamDungChung.InitRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
       ////////     HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
       ////////     HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "NoTaiKhoan", TaiKhoanNo_GrdLU);
       ////////     //
       ////////     //
       ////////     RepositoryItemGridLookUpEdit TaiKhoanCo_GrdLU = new RepositoryItemGridLookUpEdit();
       ////////     TaiKhoanCo_GrdLU.DataSource = CoTaiKhoan_BindingSource;
       ////////     TaiKhoanCo_GrdLU.DisplayMember = "SoHieuTK";
       ////////     TaiKhoanCo_GrdLU.ValueMember = "MaTaiKhoan";
       ////////     HamDungChung.InitRepositoryItemGridLookUpDev(TaiKhoanCo_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
       ////////     HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanCo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
       ////////     HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "CoTaiKhoan", TaiKhoanCo_GrdLU);
       ////////     //
       ////////     //
       ////////     RepositoryItemGridLookUpEdit DoiTuongNo_grdLU = new RepositoryItemGridLookUpEdit();
       ////////     DoiTuongNo_grdLU.DataSource = DoiTuongNoList_BindingSource;
       ////////     DoiTuongNo_grdLU.DisplayMember = "TenDoiTuong";
       ////////     DoiTuongNo_grdLU.ValueMember = "MaDoiTuong";
       ////////     HamDungChung.InitRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
       ////////     HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
       ////////     HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaDoiTuongNo", DoiTuongNo_grdLU);
       ////////     //
       ////////     //
       ////////     RepositoryItemGridLookUpEdit DoiTuongCo_grdLU = new RepositoryItemGridLookUpEdit();
       ////////     DoiTuongCo_grdLU.DataSource = DoiTuongCoList_BindingSource;
       ////////     DoiTuongCo_grdLU.DisplayMember = "TenDoiTuong";
       ////////     DoiTuongCo_grdLU.ValueMember = "MaDoiTuong";
       ////////     HamDungChung.InitRepositoryItemGridLookUpDev(DoiTuongCo_grdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
       ////////     HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongCo_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
       ////////     HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaDoiTuongCo", DoiTuongCo_grdLU);
       ////////     //

       ////////     //
       ////////     RepositoryItemGridLookUpEdit HopDong_GrdLU = new RepositoryItemGridLookUpEdit();
       ////////     HopDong_GrdLU.DataSource = HopDongbd;
       ////////     HopDong_GrdLU.DisplayMember = "tblHopDongMuaBan.SoHopDong";
       ////////     HopDong_GrdLU.ValueMember = "MaHopDong";
       ////////     HamDungChung.InitRepositoryItemGridLookUpDev(HopDong_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
       ////////     HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HopDong_GrdLU, new string[] { "tblHopDongMuaBan.SoHopDong", "TenHopDong" }, new string[] { "Số hợp đồng", "Nội dung" }, new int[] { 100, 200 }, false);
       ////////     HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaHopDong", HopDong_GrdLU);
       ////////     //

       ////////     //
       ////////     RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();

       ////////     repositoryItemCalcEditSoTien.AutoHeight = false;
       ////////     repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
       ////////     repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
       ////////     repositoryItemCalcEditSoTien.Name = "repositoryItemCalcEditSoTien";
       ////////    // gridView_ButToan.Columns["SoTien"].ColumnEdit = repositoryItemCalcEditSoTien;
       ////////     //
       ////////     HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "#,###.#");
       //////////     this.gridView_ButToan.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView_ButToan_RowCellClick);
       ////////   //  this.gridView_ButToan.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_ButToan_CellValueChanged);
       ////////   //  this.gridView_ButToan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_ButToan_KeyDown);
       ////////   //  this.gridView_ButToan.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_ButToan_InitNewRow);
      
       ////////     //this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);

       ////////    /// this.gridView_ButToan.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdView_DinhKhoan_FocusedRowChanged);

       ////////   //  this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grd_DinhKhoan_ProcessGridKey);
       ////////    // this.gridView_ButToan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grd_DinhKhoan_KeyPress);
        }

        private void DesignGridControls()
        {
            //btnInDVKhoanChi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            DesignGrid_ButToan();
            //if (_maLoaiChungTu == 16 || _maLoaiChungTu == 2)//Bang Ke or PhieThu
            //{
            //    if (_maLoaiChungTu == 16)//BangKe
            //    {
            //        btnInDVKhoanChi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    }
            //    DesignGrid_DSDeNghiChuyenKhoan();
            //}
            //DesignGrid_HoaDon();

        }
        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Lap Phieu", "Help_CongNo.chm");
        }
             

        private void ultraTextEditor_MNS_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            frmDinhKhoan_MucNganSach _frmDinhKhoan_MucNganSach = new frmDinhKhoan_MucNganSach((ButToan)ButToan_BindingSource.Current, TongTien);
            _frmDinhKhoan_MucNganSach.Show();
        }

        private void txtu_DienGiai_Leave(object sender, EventArgs e)
        {
            if (_ChungTu.IsNew)
            {
                for (int i = 0; i < _ChungTu.DinhKhoan.ButToan.Count; i++)
                    _ChungTu.DinhKhoan.ButToan[i].DienGiai = txtu_DienGiai.Text.Trim();
            }
        }

        //Sua
        private void tlslblXoa_Click(object sender, EventArgs e)
        {

            if (_ChungTu.MaChungTu != 0)
            {
                if (KhoaSoThue())
                {
                    if (CheckCoTaiKhoanThueTrongButToan())
                    {
                        MessageBox.Show("Đã khóa sổ Thuế, không thể thực hiện, xin vui lòng kiểm tra lại", "Thông Báo");
                        return;
                    }
                }

                if (MessageBox.Show("Bạn Có Muốn Xóa Chứng Từ Số " + _ChungTu.SoChungTu + " ?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        ChungTu.DeleteChungTu(_ChungTu);
                        MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        tlslblThem_Click(sender, e);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                }
            }

        }

        private void chkKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhachHang.Checked == true)
            {
                ShowKH();
                maDoiTuong = 0;
            }
            else
            {
                HideKH();
            }
        }

        private void btnDSKhachHang_Click(object sender, EventArgs e)
        {
            frmTimKhachHang _frmKH = new frmTimKhachHang();
            if (_frmKH.ShowDialog(this) != DialogResult.OK)
            {
                maDoiTuong = _frmKH._DoiTuongAll.MaDoiTuong;
                dtKhachHang = _frmKH._DoiTuongAll;
                txtNguoiNhan.Text = txtNguoiNhan.Text = dtKhachHang.MaQLDoiTuong + " - " + dtKhachHang.TenDoiTuong;
                txtDiaChi.Text = dtKhachHang.DiaChi;
                maLoaiDoiTuong = _frmKH._DoiTuongAll.MaLoaiDoiTuong;
                _ChungTu.DoiTuong = maDoiTuong;

                _hopDongList = HopDongMuaBanList.GetHopDongMuaBanList_TheoDoiTac(maDoiTuong);
                _hopDongList.Insert(0, HopDongMuaBan.NewHopDongMuaBan(0, "Không Chọn"));
             
            }
            else
            {
                maLoaiDoiTuong = 0;
            }
        }

        bool KiemTraSoChungTu(string soct)
        {
            if (soct.Length < 5)
                return false;
            string[] mang = new string[4];
            for (int i = 0; i < 4; i++)
            {
                mang[i] = soct.Substring(i, 1);
            }
            // kiem tra so
            for (int j = 0; j < 4; j++)
            {
                try
                {
                    int.Parse(mang[j]);
                }
                catch
                {

                    return false;
                }
            }
            return true;
        }

    
       

        public int GetMaTaiKhoan(String soHieuTK)
        {
            foreach (HeThongTaiKhoan1 tk in _HeThongTaiKhoan1ListCo)
                if (tk.SoHieuTK == soHieuTK)
                    return tk.MaTaiKhoan;
            return 1;
        }

       
        

        private void SetSoChungTuMoiPS(int MaPhieu)
        {
            int loaitien = 1;
            if (ultrcobo_LoaiTien.ActiveRow != null)
            {
                loaitien = Convert.ToInt32(ultrcobo_LoaiTien.ActiveRow.Cells["MaLoaiTien"].Value);
            }
            else
            {
                loaitien = 1;
            }
            string soCTCu = ChungTu.KiemTraSoChungTuMoiNhat(MaPhieu, loaitien, Convert.ToDateTime(dtmp_Ngay.Value).Year);
            if (soCTCu != null)
            {

                if (_ChungTu.MaChungTu == 0)
                {

                    SoCTMoiPS = ChungTu.LaySoChungTuMax(MaPhieu, Convert.ToDateTime(dtmp_Ngay.Value).Year);
                    txtutxeditSoCT.Text = SoCTMoiPS;
                    _ChungTu.SoChungTu = SoCTMoiPS;
                }
                else
                {
                    SoCTMoiPS = _ChungTu.SoChungTu;
                    txtutxeditSoCT.Text = SoCTMoiPS;

                }
            }
            else
            {
                SoCTMoiPS = "";
                txtutxeditSoCT.Text = "";
                _ChungTu.SoChungTu = "";

            }
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang frmKhachHang = new frmKhachHang();
            if (frmKhachHang.ShowDialog(this) != DialogResult.OK)
            {

            }
        }

        private void cboDoiTuongThuChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            crreu_SoTien.SelectAll();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LoaiIn(4);
        }

        private void bt_Tim_Click(object sender, EventArgs e)
        {
            string SoChungTu = txt_SoChungTu.Text.Trim();

            decimal SoTienTu = ultraCurrencyEditor_TienTu.Value;
            decimal SoTienDen = ultraCurrencyEditor_TienDen.Value;

            string TenDoiTuong = txt_DoiTuong.Text;
            string DienGiai = txtDienGiai.Text;

            _ChungTuList = ChungTuList.TimChungTu(SoChungTu, (DateTime)dtu_NgayBatDau.Value, (DateTime)dtu_NgayKetThuc.Value, SoTienTu, SoTienDen, DienGiai, maTKNoSearch, maTKCoSearch, TenDoiTuong, 16);
            DSChungTu_BindingSource.DataSource = _ChungTuList;
            if (_ChungTuList.Count == 0)
            {
                MessageBox.Show(this, "Không có chứng từ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //grdu_DSChungTu.DataSource = _ChungTuList;
            }
        }

        private void grdu_DSKhachHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            foreach (UltraGridColumn col in this.grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";

                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###,###.##";
                    col.Header.Appearance.TextHAlign = HAlign.Right;

                }
            }
            foreach (UltraGridColumn col in this.grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";

                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###,###.##";
                    col.Header.Appearance.TextHAlign = HAlign.Right;

                }
            }
            foreach (UltraGridColumn col in this.grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";

                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###,###.##";
                    col.Header.Appearance.TextHAlign = HAlign.Right;

                }
            }
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["SoChungTu"].Header.Caption = "Số Chứng Tư";
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["SoChungTu"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["SoChungTu"].Header.VisiblePosition = 0;
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["SoChungTu"].Width = 145;

            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["NgayLap"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["NgayLap"].Header.VisiblePosition = 1;
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["NgayLap"].Width = 50;

            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["SoTien"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["SoTien"].Width = 120;
        

            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["TyGia"].Header.Caption = "Tỷ Giá";
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["TyGia"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["TyGia"].Header.VisiblePosition = 3;
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["TyGia"].Width = 30;

            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["ThanhTien"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["ThanhTien"].Header.VisiblePosition = 4;
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["ThanhTien"].Width = 120;

            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["DienGiai"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["DienGiai"].Header.VisiblePosition = 5;
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["DienGiai"].Width = 300;

            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["NoTaiKhoan"].Header.Caption = "Nợ TK";
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["NoTaiKhoan"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["NoTaiKhoan"].Header.VisiblePosition = 0;
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["NoTaiKhoan"].Width = 70;
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["NoTaiKhoan"].EditorComponent = cbNoTKSearch;

            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["CoTaiKhoan"].Header.Caption = "Có TK";
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["CoTaiKhoan"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["CoTaiKhoan"].Header.VisiblePosition = 1;
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["CoTaiKhoan"].Width = 70;
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["CoTaiKhoan"].EditorComponent = cbCoTKSearch;

            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["SoTien"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["SoTien"].Width = 120;



            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["DienGiai"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["DienGiai"].Header.VisiblePosition = 3;
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["DienGiai"].Width = 80;


            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["MaTieuMucNganSach"].Header.Caption = "Mã Tiểu Mục";
            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["MaTieuMucNganSach"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["MaTieuMucNganSach"].Header.VisiblePosition = 0;
            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["MaTieuMucNganSach"].Width = 50;
            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["MaTieuMucNganSach"].EditorComponent = ultraCombo_MaTieuMuc;

            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["SoTien"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["SoTien"].Width = 120;
            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["SoTien"].Header.Appearance.TextHAlign = HAlign.Right;

            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["DienGiai"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["DienGiai"].Header.VisiblePosition = 3;
            grdu_DSChungTu.DisplayLayout.Bands["MucNganSach"].Columns["DienGiai"].Width = 80;
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            _ChungTuList.ApplyEdit();
            grdu_DSChungTu.UpdateData();
            DSChungTu_BindingSource.EndEdit();
            foreach (ChungTu ct in _ChungTuList)
            {
                if (ct.IsDirty)
                {
                    KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(ct.NgayLap);

                    if (khoa.Count > 0)
                    {
                        

                        if (khoa[0].KhoaSo == false)
                        {
                            ct.Save();
                            
                        }
                        else
                        {
                            return;
                        }
                        
                    }
                 
                }
            }

        }

        private void grdu_DSKhachHang_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            long maChungTu = (long)grdu_DSChungTu.ActiveRow.Cells["MaChungTu"].Value;
            ChungTuList ctl = ChungTuList.GetChungTuListByMaChungTu(maChungTu);
            _ChungTu = ctl[0];
            ButToanList btList = ButToanList.NewButToanList();
            // New();
            TienTe tt = TienTe.GetTienTe(_ChungTu.MaChungTu);
            if (_ChungTu.MaChungTu != 0)
            {

                Phieu = _ChungTu.LoaiChungTu.MaLoaiCT;
                crreu_SoTien.Value = tt.SoTien;
                crre_ThanhTien.Value = tt.ThanhTien;
                dtmp_Ngay.Value = _ChungTu.NgayLap;
                _ngayKhoaSo = _ChungTu.NgayLap;
                //LayDoiTuongThuChi_KhongTaoMoi(Phieu);
                ChungTu_BindingSource.DataSource = _ChungTu;
                bdChungTu.DataSource = _ChungTu.ChungTuDeNghiList;
                DoiTuongThu_Chi = _ChungTu.MaDoiTuongThuChi;
                TienTe_BindingSource.DataSource = tt;

                txtutxeditSoCT.Text = _ChungTu.SoChungTu;
                group_ThongTinPhieu.Enabled = true;
                tab_DinhKhoan.Enabled = true;
                ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
                if (Phieu != 8)
                {
                    if (_ChungTu.DoiTuong == 0)
                    {
                        chkKhachHang.Checked = true;

                        txtNguoiNhan.Text = _ChungTu.ChungTu_DiaChi.Ten;
                        txtDiaChi.Text = _ChungTu.ChungTu_DiaChi.DiaChi;


                    }
                    else
                    {
                        chkKhachHang.Checked = false;
                        dtKhachHang = DoiTuongAll.GetDoiTuongAll(_ChungTu.DoiTuong);
                        txtNguoiNhan.Text = dtKhachHang.TenDoiTuong;
                        txtDiaChi.Text = dtKhachHang.DiaChi;

                    }
                }
                soChungTu = _ChungTu.MaChungTu;
                tlslblXoa.Visible = true;
                TongTien = crre_ThanhTien.Value;
                soTien = tt.SoTien;
                tabControl1.SelectedIndex = 0;
                TaoBindingDanhSach();
            }
        }

        private void bt_TamUng_Click(object sender, EventArgs e)
        {
            if (_ChungTu.MaChungTu != 0)
                _tamUngList = _ChungTu.TamUngList;
            _ChungTu.TamUngList.BeginEdit();

            frmTamUng _frmTamUng = new frmTamUng(_ChungTu.TamUngList, 16, _ChungTu.DienGiai, _ChungTu.NgayLap, maDoiTuong, _ChungTu.Tien.ThanhTien);
            if (_frmTamUng.ShowDialog(this) != DialogResult.OK)
            {
                if (_frmTamUng.IsSave == true)
                {
                    _ChungTu.TamUngList = _frmTamUng._tamUngList;
                    _ChungTu.TamUngList.ApplyEdit();
                }
                else
                {
                    _ChungTu.TamUngList.CancelEdit();
                }

            }


        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmXemIn f = new frmXemIn();


            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;

            rpt.ReportEmbeddedResource = "PSC_ERP.Report.CongNo.rpBangKe.rdlc";
            BangKeList bangkelist = ERP_Library.BangKeList.GetBangKeList(_ChungTu.MaChungTu);

            rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_BangKeList", bangkelist));

            f.SetParameter("TenBoPhan", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);

            f.SetParameter("TieuDeReport", "PHIẾU KẾ TOÁN ");
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            //string ngay ="";// "Tp.HCM, Ngày " + _ChungTu.NgayLap.Day+ " tháng " + _ChungTu.NgayLap.Month.ToString() + " năm " + _ChungTu.NgayLap.Year.ToString();
            //f.SetParameter("Ngay", ngay);
            if (ERP_Library.Security.CurrentUser.Info.MaCongTy != 1)
            {
                f.SetNguoiKyTongHopBangKe(2, _ChungTu.NgayLap);
            }
            else if (ERP_Library.Security.CurrentUser.Info.MaCongTy == 1 & ERP_Library.Security.CurrentUser.Info.MaBoPhan != 9)
            {
                f.SetNguoiKyTongHopBangKe(10, _ChungTu.NgayLap);
            }
            else
            {
                f.SetNguoiKyTongHop(3);
            }

            f.Show(this);
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ChungTu.ChungTuChiPhiSanXuatList.BeginEdit();
            frmChiPhiSanXuatChuongTrinh f = new frmChiPhiSanXuatChuongTrinh(_ChungTu, _ChungTu.ChungTuChiPhiSanXuatList, _ChungTu.SoTien, _ChungTu.MaChungTu, _ChungTu.SoChungTu, maDoiTuong, _ChungTu.NgayLap, _ChungTu.DienGiai, 0);
            f.Show();
            if (f.IsSave == true)
            {
                _ChungTu.ChungTuChiPhiSanXuatList = f._ChungTu_ChiPhiSXList;
                _ChungTu.ChungTuChiPhiSanXuatList.ApplyEdit();
            }
            else
            {
                _ChungTu.ChungTuChiPhiSanXuatList.CancelEdit();
            }


        }

        private void ultrcobo_LoaiTien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultrcobo_LoaiTien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            ultrcobo_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Hidden = false;
            ultrcobo_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.Caption = "Loại Tiền";
            ultrcobo_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.VisiblePosition = 0;
            ultrcobo_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Width = 40;

            ultrcobo_LoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Hidden = false;
            ultrcobo_LoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.Caption = "Tên Loại Tiền";
            ultrcobo_LoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.VisiblePosition = 2;
            ultrcobo_LoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Width = 80;

            ultrcobo_LoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Hidden = false;
            ultrcobo_LoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.Caption = "Tỷ Giá";
            ultrcobo_LoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.VisiblePosition = 1;
            ultrcobo_LoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Width = 50;
        }

        private void ultrcobo_LoaiTien_ValueChanged(object sender, EventArgs e)
        {
            if (ultrcobo_LoaiTien.ActiveRow != null)
            {
                _ChungTu.Tien.MaLoaiTien = Convert.ToInt32(ultrcobo_LoaiTien.ActiveRow.Cells["MaLoaiTien"].Value);
            }
        }

        private void cbNoTKSearch_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbNoTKSearch.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbNoTKSearch.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cbNoTKSearch.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK1";
            cbNoTKSearch.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbNoTKSearch.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cbNoTKSearch.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbNoTKSearch.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            cbNoTKSearch.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
        }

        private void cbCoTKSearch_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            foreach (UltraGridColumn col in this.cbCoTKSearch.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbCoTKSearch.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cbCoTKSearch.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK1";
            cbCoTKSearch.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbCoTKSearch.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cbCoTKSearch.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbCoTKSearch.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            cbCoTKSearch.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;

        }

        private void ultraTextEditor_MNS_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ultraCombo_MaTieuMuc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {


            foreach (UltraGridColumn col in this.ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                    col.CellAppearance.TextHAlign = HAlign.Center;
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
                    col.Format = "###,###,###,###,###,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
                col.Hidden = true;
            }
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Tiểu Mục";
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Hidden = false;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.Caption = "Tên Tiểu Mục";
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.VisiblePosition = 1;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Width = 250;

            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Hidden = false;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Header.Caption = "Số Tiền";
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Header.VisiblePosition = 3;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Width = 80;
        }

        private void cbu_SoHieuTKNo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_SoHieuTKNo.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_SoHieuTKNo.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cbu_SoHieuTKNo.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbu_SoHieuTKNo.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbu_SoHieuTKNo.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cbu_SoHieuTKNo.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_SoHieuTKNo.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            cbu_SoHieuTKNo.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
        }

        private void cbu_SoHieuTKCo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_SoHieuTKCo.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_SoHieuTKCo.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cbu_SoHieuTKCo.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbu_SoHieuTKCo.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbu_SoHieuTKCo.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cbu_SoHieuTKCo.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_SoHieuTKCo.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            cbu_SoHieuTKCo.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;

        }

        //Sua
        private void ultraTextEditor_dshoadon_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            //Sua
            if (!(KhoaSoThue()))
            {
                if (HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToan)ButToan_BindingSource.Current).NoTaiKhoan).SoHieuTK.Contains("3113")||
                    HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToan)ButToan_BindingSource.Current).CoTaiKhoan).SoHieuTK.Contains("3113")
                    )
                {
                    frmDanhSachHoaDonDichVu _frm = new frmDanhSachHoaDonDichVu(_ChungTu, (ButToan)ButToan_BindingSource.Current);
                    _frm.ShowDialog();
                }
                else if (HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToan)ButToan_BindingSource.Current).NoTaiKhoan).SoHieuTK.Contains("3337")
                            || HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToan)ButToan_BindingSource.Current).CoTaiKhoan).SoHieuTK.Contains("3337"))
                {
                    frmDanhSachHoaDonDichVu _frm = new frmDanhSachHoaDonDichVu(_ChungTu, ((ButToan)ButToan_BindingSource.Current).ChungTu_HoaDonList, (ButToan)ButToan_BindingSource.Current, true);
                    _frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(this, "Vui lòng chọn tài khoản 3113 hay 3337....", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //foreach (ButToan btc in _ChungTu.DinhKhoan.ButToan)
            //{
            //    if (btc.SoHieuTKNo.Contains("3113"))
            //    {
            //        frmDanhSachHoaDonDichVu _frm = new frmDanhSachHoaDonDichVu(_ChungTu, (ButToan)ButToan_BindingSource.Current);
            //        _frm.Show();
            //    }
            //}
        }

        private void cbu_SoHieuTKNo_ValueChanged(object sender, EventArgs e)
        {
            if (cbu_SoHieuTKNo.ActiveRow != null)
            {
                maTKNoSearch = Convert.ToInt32(cbu_SoHieuTKNo.Value);

            }
            else
            {
                maTKNoSearch = 0;
            }
        }

        private void cbu_SoHieuTKCo_ValueChanged(object sender, EventArgs e)
        {
            if (cbu_SoHieuTKCo.ActiveRow != null)
            {
                maTKCoSearch = Convert.ToInt32(cbu_SoHieuTKCo.Value);

            }
            else
            {
                maTKCoSearch = 0;
            }
        }

     
        private void dtmp_Ngay_ValueChanged(object sender, EventArgs e)
        {
            SetSoChungTuMoiPS(16);
        }

        private void grd_DSDeNghi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["LyDo"];
            SummarySettings summary = grd_DSDeNghi.DisplayLayout.Bands[0].Summaries.Add("SotienGoc", SummaryType.Sum, columnToSummarize, SummaryPosition.UseSummaryPositionColumn);
            summary.DisplayFormat = "Thành tiền: ";
            summary.Appearance.TextHAlign = HAlign.Center;

            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["SoTien"];
            SummarySettings summary2 = grd_DSDeNghi.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize2, SummaryPosition.UseSummaryPositionColumn);
            summary2.DisplayFormat = " {0:###,###,###,###,###,###.##}";
            summary2.Appearance.TextHAlign = HAlign.Right;

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
        }

        private void tlslblThemDN_Click(object sender, EventArgs e)
        {
            if (_ChungTu.ChungTuDeNghiList.Count == 0 && _ChungTu.ChungTuGiayBaoCoList.Count == 0 && _ChungTu.ChungTuLenhChuyenTienList.Count == 0 && _ChungTu.ChungTuDeNghiList.Count == 0 && _ChungTu.ChungTuUyNhiemChiList.Count == 0 && _ChungTu.ChungTuGiayRutTienList.Count == 0)
            {
                _ChungTu.LoaiChungTuDiKem = 0;
            }
            frmChonDeNghiChuyenKhoan frm = new frmChonDeNghiChuyenKhoan(_ChungTu);
            frm.ShowDialog();
            maDoiTuong = _ChungTu.DoiTuong;
            dtmp_Ngay.DateTime = _ChungTu.NgayLap;
            TaoBindingDanhSach();
        }

        private void TaoBindingDanhSach()
        {
            if (_ChungTu.LoaiChungTuDiKem == 1)
            {
                this.bdChungTu.DataSource = typeof(ChungTu_DeNghiChuyenKhoanChildList);
                bdChungTu.DataSource = _ChungTu.ChungTuDeNghiList;
            }
            else if (_ChungTu.LoaiChungTuDiKem == 2 || _ChungTu.LoaiChungTuDiKem == 6) //Giấy báo có & Phí Ngân hàng
            {
                this.bdChungTu.DataSource = typeof(ChungTu_GiayBaoCoList);
                bdChungTu.DataSource = _ChungTu.ChungTuGiayBaoCoList;
            }
            else if (_ChungTu.LoaiChungTuDiKem == 3)
            {
                this.bdChungTu.DataSource = typeof(ChungTu_GiayBanNgoaiTeChildList);
                bdChungTu.DataSource = _ChungTu.ChungTuGiayBanNgoaiTe;
            }
            else if (_ChungTu.LoaiChungTuDiKem == 4)
            {
                this.bdChungTu.DataSource = typeof(ChungTu_LenhChuyenTienNNChildList);
                bdChungTu.DataSource = _ChungTu.ChungTuLenhChuyenTienList;
            }
            else if (_ChungTu.LoaiChungTuDiKem == 5 || _ChungTu.LoaiChungTuDiKem == 8) //5: Ủy Nhiệm Chi cấp 1 || 8: Điều chuyển nội bộ
            {
                this.bdChungTu.DataSource = typeof(ChungTu_UNCChildList);
                bdChungTu.DataSource = _ChungTu.ChungTuUyNhiemChiList;
            }
            else if (_ChungTu.LoaiChungTuDiKem == 7) // Giấy rút tiền mặt ( Chú ý: Chỉ tồn tại trong phiếu thu không tồn tại trong bảng kê)
            {
                this.bdChungTu.DataSource = typeof(ChungTu_GiayRutTienChildList);
                bdChungTu.DataSource = _ChungTu.ChungTuGiayRutTienList;
            }
            _ChungTu.DoiTuong = maDoiTuong;
            //Load thông tin của đối tượng
            if (_ChungTu.DoiTuong != 0)
            {
                chkKhachHang.Checked = false;
                dtKhachHang = DoiTuongAll.GetDoiTuongAll(_ChungTu.DoiTuong);
                txtNguoiNhan.Text = txtNguoiNhan.Text = dtKhachHang.MaQLDoiTuong + " - " + dtKhachHang.TenDoiTuong;
                txtDiaChi.Text = dtKhachHang.DiaChi;
            }

            _hopDongList = HopDongMuaBanList.GetHopDongMuaBanList_TheoDoiTac(maDoiTuong);
            _hopDongList.Insert(0, HopDongMuaBan.NewHopDongMuaBan(0, "Không chọn"));           

            TaoCauTrucBang();
        }

        private void tlslblXoaDN_Click(object sender, EventArgs e)
        {
            if (grd_DSDeNghi.Selected.Rows.Count <= 0)
            {
                MessageBox.Show(this, "Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grd_DSDeNghi.DeleteSelectedRows();
            grd_DSDeNghi.UpdateData();
        }

        private void TaoCauTrucBang()
        {
            toolStrip1.Visible = true;
            HamDungChung.EditBand(grd_DSDeNghi.DisplayLayout.Bands[0],
            new string[3] { "SoChungTu", "LyDo", "SoTien" },
            new string[3] { "Số chứng từ", "Lý do", "Số tiền" },
            new int[3] { 150, 330, 150 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Tien },
            new bool[3] { false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.grd_DSDeNghi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
                if (col.Key == "SoTien")
                    col.CellAppearance.TextHAlign = HAlign.Right;
            }
            //màu nền
            this.grd_DSDeNghi.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.grd_DSDeNghi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

      

        private void cboDoiTuongThuChi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cboDoiTuongThuChi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
                col.Hidden = true;
            }
            this.cboDoiTuongThuChi.DisplayLayout.Bands[0].Columns["TenDoiTuongThuChi"].Hidden = false;
            this.cboDoiTuongThuChi.DisplayLayout.Bands[0].Columns["TenDoiTuongThuChi"].Header.Caption = "Công Việc";
            this.cboDoiTuongThuChi.DisplayLayout.Bands[0].Columns["TenDoiTuongThuChi"].Width = 350;
            this.cboDoiTuongThuChi.DisplayLayout.Bands[0].Columns["TenDoiTuongThuChi"].Header.VisiblePosition = 0;
            //màu nền
            this.cboDoiTuongThuChi.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.cboDoiTuongThuChi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            FilterCombo f = new FilterCombo(cboDoiTuongThuChi, "TenDoiTuongThuChi");
        }

        private void cboDoiTuongThuChi_ValueChanged(object sender, EventArgs e)
        {

            crreu_SoTien.SelectAll();
            if (cboDoiTuongThuChi.ActiveRow != null)
            {             
                _ChungTu.MaDoiTuongThuChi = (Int32)cboDoiTuongThuChi.ActiveRow.Cells["MaDoiTuongThuChi"].Value;
            }
        }

        private void CapNhapMaButToanChiPhiSanXuat(long maButToanChiPhiSanXuat, int maBoPhan, int maChuongTrinh, string soDeNghi, bool loaiNV)
        {

            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CapNhatMaButToanChiPhiSanXuat";
                    cm.Parameters.AddWithValue("@MaButToanChiPhiSanXuat", maButToanChiPhiSanXuat);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    cm.Parameters.AddWithValue("@SoDeNghi", soDeNghi);
                    cm.Parameters.AddWithValue("@LoaiNV", loaiNV);

                    cm.ExecuteNonQuery();
                }
            }//using
        }

        #region Them Khoa So Thue
      
      
        #endregion

        #region tlslblInA4New_Click
        private void tlslblInA4New_Click(object sender, EventArgs e)
        {

            ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuKeToanA4");//PhieuNhapVatTu//
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }
                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.Show();
            }
        }
        #endregion

        #region tlslblInA5New_Click
        private void tlslblInA5New_Click(object sender, EventArgs e)
        {
            ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuKeToanA5");//PhieuNhapVatTu//
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }
                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.Show();
            }
        }
        #endregion

        #region Phiếu kế toán
        public bool PhieuKeToan()//[dbo].[spd_BaoCaoChungTuGhiSo] 
        {

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao spd_BaoCaoChungTuGhiSo
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoChungTuGhiSo";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_BaoCaoChungTuGhiSo;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }

       
      
            #endregion

            #region Tạm ứng

            
        private void btnDanhSachVanBan_Click(object sender, EventArgs e)
        {
            if (_ChungTu != null && _ChungTu.MaChungTu != 0)
            {
                List<DigitizingBag> dsFilePreView = new List<DigitizingBag>();
                dsFilePreView = DigitizingBag_Factory.New().LayFileTheoMaChungTu_SoChungTu(_ChungTu.MaChungTu, _ChungTu.SoChungTu).ToList();
                if (dsFilePreView != null && dsFilePreView.Count > 0)
                {
                    using (frmDigitizing_Find_and_PreViewFile frm = new frmDigitizing_Find_and_PreViewFile(dsFilePreView))
                    {
                        frm.WindowState = FormWindowState.Maximized;
                        frm.Text = "Bạn Đang Xem File " + dsFilePreView[0].Name;
                        if (dsFilePreView.Count == 1)
                        {
                            frm.splitContainerControl1.Panel1.Hide();
                            frm.splitContainerControl1.SplitterPosition = 0;
                            frm.splitContainerControl1.IsSplitterFixed = true;
                        }
                        else
                        {
                            frm.groupControl_TimKiem.Visible = false;
                            frm.groupControl_TimKiem.Size = new System.Drawing.Size(0, 0);

                            frm.splitContainerControl2.Panel1.Hide();
                            frm.splitContainerControl2.SplitterPosition = 0;
                            frm.splitContainerControl2.IsSplitterFixed = true;
                        }
                        frm.ShowDialog();
                    }
                    
                }
                else
                {
                    DialogUtil.ShowWarning("Chứng từ chưa được scan File \nVui lòng thực hiện nghiệp vụ số hóa");
                }
            }
            else
            {
                MessageBox.Show("Chọn chứng từ cần xem.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        //END Phieu Ke Toan
        #endregion
    }
}
