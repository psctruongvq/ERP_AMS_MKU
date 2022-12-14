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

//long 

namespace PSC_ERP
{//4-1-2010

    public partial class frmPhieuThu : Form
    {
        #region Properties

        int maLoaiDoiTuong = 0;
        HamDungChung hamDungChung = new HamDungChung();
        HeThongTaiKhoan1List _HeThongTaiKhoan1ListCo, _HeThongTaiKhoanSearchCo, _HeThongTaiKhoanSearchNo, _HeThongTaiKhoan1ListNo, _HeThongTaiKhoan1List;
        TieuMucNganSachList _TieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();

        // tran them
        ChungTuNganHangList _DSDeNghiChuyenKhoanChon = ChungTuNganHangList.NewChungTuNganHangList();
        DeNghiThanhToanList _DSDeNghiThanhToanCu = DeNghiThanhToanList.NewDeNghiThanhToanList("NhanSu");
        ChungTuNganHangList _DSDeNghiChuyenKhoanCu = ChungTuNganHangList.NewChungTuNganHangList();
        public ChiThuLaoList _ChiThuLaoList = ChiThuLaoList.NewChiThuLaoList();
        public int LoaiChi = 0;
        DoiTuongAllList _doiTuongList;
        DoiTuongAllList _DoiTuongNoList, _DoiTuongCoList;
        long maDoiTuong = 0;

        //
        static ChungTu _ChungTu = ChungTu.NewChungTu();
        ButToanList _ButToanList = ButToanList.NewButToanList();
        LoaiTienList _LoaiTienList = LoaiTienList.NewLoaiTienList();

        DoiTuongAll _DoiTuongAll = DoiTuongAll.NewDoiTuongAll(1);

        PhuongThucThanhToanList _PhuongThucThanhToanList;
        
        CongTy_NganHangList _CongTy_NganHangList = CongTy_NganHangList.NewCongTy_NganHangList();
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
        // 
        string[] userall = new string[] { "bahung", "thuchi", "honganh", "admin" };

        string SoCTMoiPS = "";
        //
        DoiTuongThuChiList _DoiTuongThuChiList;
        int MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

        public TamUngList _tamUngList = TamUngList.NewTamUngList();

        public ChungTuList _ChungTuList = ChungTuList.NewChungTuList();        
        private bool kiemTraTaiKhoan;
        DataSet dataSet = new DataSet();
        int UserID = ERP_Library.Security.CurrentUser.Info.UserID;
        System.Windows.Forms.Binding a;
        System.Windows.Forms.Binding b;
        private DateTime _ngayKhoaSo;

        #endregion


        #region LayDuLieuLenLuoi
        private void LayDuLieuLenLuoi()
        {
            DSChungTu_BindingSource.DataSource = ChungTuList.NewChungTuList();
            _LoaiTienList = LoaiTienList.GetLoaiTienList();
            LoaiTien_BindingSource.DataSource = _LoaiTienList;

            _HeThongTaiKhoan1ListCo = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            _HeThongTaiKhoan1List = _HeThongTaiKhoan1ListCo;
            HeThongTaiKhoan1 tk = HeThongTaiKhoan1.NewHeThongTaiKhoan1("Tất Cả");
            _HeThongTaiKhoan1ListCo.Insert(0, tk);
            CoTaiKhoan_BindingSource.DataSource = _HeThongTaiKhoan1ListCo;
            _HeThongTaiKhoan1ListNo = _HeThongTaiKhoan1ListCo;
            _HeThongTaiKhoanSearchCo = _HeThongTaiKhoan1ListNo;
            _HeThongTaiKhoanSearchNo = _HeThongTaiKhoanSearchCo;
            NoTaiKhoan_BindingSource.DataSource = _HeThongTaiKhoan1ListNo;
            cbu_SoHieuTKCo.DataSource = _HeThongTaiKhoan1ListCo;
            cbu_SoHieuTKNo.DataSource = _HeThongTaiKhoan1ListNo;
            cbCoTKSearch.DataSource = _HeThongTaiKhoanSearchCo;
            cbNoTKSearch.DataSource = _HeThongTaiKhoanSearchNo;

            _TieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach_BindingSource.DataSource = _TieuMucNganSachList;
            _PhuongThucThanhToanList = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            PPThanhToan_BindingSource.DataSource = _PhuongThucThanhToanList;

            _CongTy_NganHangList = CongTy_NganHangList.NewCongTy_NganHangList();
            CongTy_NganHang_BindingSource.DataSource = _CongTy_NganHangList;


            _DoiTuongThuChiList = DoiTuongThuChiList.GetDoiTuongThuChiList(MaCongTy);
            DoiTuongThuChi_BindingSource.DataSource = _DoiTuongThuChiList;
            cboDoiTuongThuChi.DataSource = _DoiTuongThuChiList;

            DoiTuongAll dt = DoiTuongAll.NewDoiTuongAll("Không Có");
            _DoiTuongNoList = DoiTuongAllList.GetDoiTuongAllList_Tim("",0);
            _DoiTuongNoList.Insert(0, dt);
            DoiTuongNoList_BindingSource.DataSource = _DoiTuongNoList;
            // doi tuong co

            //_DoiTuongCoList = DoiTuongAllList.GetDoiTuongAllList_Tim("");
            //_DoiTuongCoList.Insert(0, dt);
            _DoiTuongCoList = _DoiTuongNoList;
            DoiTuongCoList_BindingSource.DataSource = _DoiTuongCoList;

            LayNoCoTaiKhoanDefault();

            if (_ChungTu.DinhKhoan != null)
            {
                if (_ChungTu.DinhKhoan.LaMotNoNhieuCo == false)
                {
                    ChonNoLoad();
                }
                else ChonCoLoad();
            }
            else
            {
                ChonCoLoad();
            }
            this.cmbu_TaiKhoanNC.ValueChanged += new EventHandler(cmbu_TaiKhoanNC_ValueChanged);
        }
        #endregion

        #region frmBangKe
        public frmPhieuThu()
        {
            InitializeComponent();
            //bt_TamUng.Enabled = false;
            ChungTu_BindingSource.DataSource = typeof(ERP_Library.ChungTu);
            DinhKhoan_BindingSource.DataSource = typeof(ERP_Library.DinhKhoan);
            ButToan_BindingSource.DataSource = typeof(ERP_Library.ButToanList);
            TienTe_BindingSource.DataSource = typeof(ERP_Library.TienTe);
            NoTaiKhoan_BindingSource.DataSource = typeof(ERP_Library.HeThongTaiKhoan1);
            CoTaiKhoan_BindingSource.DataSource = typeof(ERP_Library.HeThongTaiKhoan1);
            KhachHang_BindingSource.DataSource = typeof(ERP_Library.DoiTuongAllList);
            LoaiTien_BindingSource.DataSource = typeof(ERP_Library.LoaiTienList);
            PPThanhToan_BindingSource.DataSource = typeof(ERP_Library.PhuongThucThanhToanList);
            CongTy_NganHang_BindingSource.DataSource = typeof(ERP_Library.CongTy_NganHangList);
            DoiTuongThuChi_BindingSource.DataSource = typeof(ERP_Library.DoiTuongThuChiList);
            DSChungTu_BindingSource.DataSource = typeof(ERP_Library.ChungTuList);
            ChungTu_TaiKhoan_BindingSource.DataSource = typeof(ERP_Library.ChungTu_TaiKhoanList);
            DoiTuong_BindingSource.DataSource = typeof(ERP_Library.DoiTuongAllList);
            tlslblXoa.Visible = false;
            toolStripSeparator2.Visible = false;

            tlslblUndo.Visible = false;
            toolStripSeparator3.Visible = false;
            cmbu_GhiMucNganSach.Value = false;
            DSChungTu_BindingSource.DataSource = ChungTuList.NewChungTuList();
            this.WindowState = FormWindowState.Maximized;
            if (ERP_Library.Security.CurrentUser.Info.MaCongTy == 3)
                button2.Enabled = false;
            else
                button2.Enabled = true;
            dtmp_Ngay.Value = DateTime.Today;
            txtSoChungTuKemTheo.Value = 1;
            //hamDungChung.EventForm(this);


        }
        #endregion

        #region TaoMoiChungTu
        private void TaoMoiChungTu(int loaiChungTu)
        {
            _ChungTu = ChungTu.NewChungTu(loaiChungTu);
            ChungTu_BindingSource.DataSource = _ChungTu;
            _ChungTu.SoChungTuKemTheo = 1;
            TienTe_BindingSource.DataSource = _ChungTu.Tien;
            _CongTy_NganHangList = CongTy_NganHangList.NewCongTy_NganHangList();
            CongTy_NganHang_BindingSource.DataSource = _CongTy_NganHangList;
            DinhKhoan_BindingSource.DataSource = _ChungTu.DinhKhoan;
            ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
            soTien = 0;
            dtmp_Ngay.Value = DateTime.Today;

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
                cmbu_TaiKhoanNC.Value = true;// Có: false; Nợ: True

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
                //TaoMoiChungTu(8);
                //Phieu = 8;// Phieu Chuyen Khoan
                cmbu_TaiKhoanNC.Value = true;// Có: false; Nợ: True

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

        #region frmCongNo_Load
        private void frmCongNo_Load(object sender, EventArgs e)
        {
            a = new System.Windows.Forms.Binding("Value", this.ButToan_BindingSource, "CoTaiKhoan", true);
            b = new System.Windows.Forms.Binding("Value", this.ButToan_BindingSource, "NoTaiKhoan", true);
            this.ultraCombo_NoTaiKhoan.DataBindings.Add(b);
            LayDuLieuLenLuoi();
            TaoMoiChungTu(2);

            Phieu = 2;
            SetSoChungTuMoiPS(2);
            SetTaiKhoanDefault();
            cmbu_TaiKhoanNC.Text = "Nợ";

            //hamDungChung.EventForm(this);
            _doiTuongList = DoiTuongAllList.GetDoiTuongAllListByTaiKhoanTheoDoi();
            DoiTuongAll itemAdd = DoiTuongAll.NewDoiTuongAll("Không Có");
            this._doiTuongList.Insert(0, itemAdd);
            this.DoiTuong_BindingSource.DataSource = _doiTuongList;
          

         

            TaoCauTrucBang();
            //btnChiThuLao.Enabled = false;
        }
        #endregion

        #region KiemTraQuyen
        int KiemTraQuyen()
        {
            foreach (string user in userall)
            {
                if (ERP_Library.Security.CurrentUser.Info.TenDangNhap == user)
                {
                    return 1; // all

                }

            }
            return 2; // han che
        }
        #endregion

        #region ultrtxt_ChiTiet_EditorButtonClick
        private void ultrtxt_ChiTiet_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            ButToan butToan = (ButToan)(ButToan_BindingSource.Current);
            if (butToan.ChiTietButToanList.Count == 0)
            {
                int flag = 0;

            }
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

        #region ugrButToan_Error
        private void ugrButToan_Error(object sender, ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.Data)
                e.ErrorText = "Kiểu dữ liệu không hợp lệ";
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
            kiemTraTaiKhoan = false;
            if (cboDoiTuongThuChi.SelectedItem != null)
            {
                DoiTuongThuChi _doituong = (DoiTuongThuChi)cboDoiTuongThuChi.SelectedItem;
                _ChungTu.MaDoiTuongThuChi = _doituong.MaDoiTuongThuChi;
            }
            else
            {
                cboDoiTuongThuChi.Focus();
                MessageBox.Show("Vui Lòng Chọn công viêc");
                return;
            }
            //DoiTuongThuChi _doituong = (DoiTuongThuChi)cboDoiTuongThuChi.SelectedItem;
            //if(_doituong!=null)
            //_ChungTu.MaDoiTuongThuChi = _doituong.MaDoiTuongThuChi;

            if ((bool)cmbu_GhiMucNganSach.Value == true)
                _ChungTu.DinhKhoan.GhiMucNganSach = true;
            else
                _ChungTu.DinhKhoan.GhiMucNganSach = false;
            _ChungTu.Tien.ThanhTien = crre_ThanhTien.Value;
            
            if (chkKhachHang.Checked == true)
            {
                if (txtNguoiNhan.Text.Trim() == "")
                {
                    MessageBox.Show(this, "Vui lòng chọn nhập tên đối tượng thu chi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _ChungTu.DoiTuong = 0;
                _ChungTu.ChungTu_DiaChi.Ten = txtNguoiNhan.Text;
                _ChungTu.ChungTu_DiaChi.DiaChi = txtDiaChi.Text;
            }
            else
            {
                _ChungTu.DoiTuong = dtKhachHang.MaDoiTuong;

            }

            if ((DateTime)dtmp_Ngay.Value > Convert.ToDateTime("31-12-2013"))
            {
                MessageBox.Show(this, "Ngày lập phải bé hơn hoặc bằng ngày ngày 31-12-2013", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtutxeditSoCT.Text == "" || KiemTraSoChungTu(txtutxeditSoCT.Text) == false)
            {
                if (Convert.ToInt32(cmbu_LoaiTien.Value) == 1)
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


            bool ktmucngansach = false;
            foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
            {
                if (buttoan.MucNganSach.Count != 0)
                {
                    ktmucngansach = true;
                    break;
                }

            }
            if (ktmucngansach == false)
            {
                if (_ChungTu.DinhKhoan.GhiMucNganSach == true)
                {
                    MessageBox.Show(this, "Phải chọn Mục Ngân Sách cho bút toán.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else // buttoan co muc ngan sach
            {
                if (_ChungTu.DinhKhoan.GhiMucNganSach == false)
                {
                    foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
                    {
                        if (buttoan.MucNganSach.Count != 0)
                        {
                            buttoan.MucNganSach.Clear();
                        }

                    }
                }
                else // kiem tra buttoan bang muc ngan sach
                {
                    foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
                    {
                        if (buttoan.MucNganSach.Count != 0)
                        {
                            decimal tong = 0;
                            foreach (ButToanMucNganSach ns in buttoan.MucNganSach)
                            {
                                tong += ns.SoTien;

                            }
                            if (buttoan.SoTien != tong)
                            {
                                MessageBox.Show(this, "Mục ngân sách và số tiền bút toán không bằng nhau. Số tiền " + buttoan.SoTien.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                        }
                    }
                }
            }



            bool KiemTraButtoan = false;
            foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
            {
                HeThongTaiKhoan1 httkno = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                HeThongTaiKhoan1 httkco = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.CoTaiKhoan);
                string noTK = httkno.SoHieuTK;
                string CoTK = httkco.SoHieuTK;


                if (httkno.CoDoiTuongTheoDoi == true)
                {
                    if (buttoan.DoiTuongNo == 0 )
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng nợ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (httkco.CoDoiTuongTheoDoi == true )
                {
                    if (buttoan.DoiTuongCo == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng Có ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (noTK.Contains("631") || noTK.Contains("4314"))
                {
                    if (buttoan.MucNganSach.Count == 0)
                    {
                        MessageBox.Show(this, "Vui lòng nhập mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (noTK == "1551" || noTK == "1552" || CoTK == "1551" || CoTK == "1552")
                {
                    if (buttoan.ChungTuChiPhiSanXuatList.Count == 0)
                    {
                        MessageBox.Show(this, "Bạn phải chọn Chi Phí Thực Hiện hoặc Chi Thù Lao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        foreach (ChungTu_ChiPhiSanXuat cp in buttoan.ChungTuChiPhiSanXuatList)
                        {
                            if (cp.ChiPhiThucHienList.Count == 0 && cp.ChiThuLaoList.Count == 0)
                            {
                                MessageBox.Show(this, "Bạn phải chọn Chi Phí Thực Hiện hoặc Chi Thù Lao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }

                sum += buttoan.SoTien;
                if (buttoan.NoTaiKhoan == 0 || buttoan.CoTaiKhoan == 0)
                {
                    KiemTraButtoan = true;
                }
                if (noTK == "312" || noTK == "312.5" || noTK == "312.9" || noTK == "312.9" || noTK == "312.93" || CoTK == "312" || CoTK == "312.5" || CoTK == "312.9" || CoTK == "312.9" || CoTK == "312.93")
                {
                    if (_ChungTu.TamUngList.Count == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn nhập tạm ứng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }
            //if (kiemTraTaiKhoan == false)
            //{
            //    MessageBox.Show(this, "Tài khoản không Nợ/Có hợp lệ vui lòng chọn lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (KiemTraButtoan == true)
            {
                MessageBox.Show(this, "Chọn Nợ/Có cho các bút toán đã chọn.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ChungTu.NgayThucHien = (DateTime)dtmp_Ngay.Value;

            if (_ChungTu.DinhKhoan.ButToan != null)
            {
                if (_ChungTu.DinhKhoan.ButToan.Count != 0)
                {
                    if (cmbu_TaiKhoanNC.Value != null)
                        _ChungTu.DinhKhoan.LaMotNoNhieuCo = (bool)cmbu_TaiKhoanNC.Value;

                    _ChungTu.NgayLap = ((DateTime)dtmp_Ngay.Value).Date;

                    if (_ChungTu.Tien.ThanhTien == sum)
                    {
                        if (MessageBox.Show("Ban Có Muốn Save Dữ Liệu Không", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            try
                            {
                                _ChungTu.Tien.SoTien = crreu_SoTien.Value;
                                _ChungTu.SoTien = (decimal)crreu_SoTien.Value;
                                _ChungTu.DienGiai = txtu_DienGiai.Text;
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
                                    _ChungTu.Save();
                                    _ngayKhoaSo = _ChungTu.NgayLap;
                                }
                                else
                                {
                                    KhoaSo_UserList khoaso = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayKhoaSo);
                                    if (khoaso.Count > 0)
                                    {
                                        if (khoaso[0].KhoaSo == true)
                                        {
                                            MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }
                                    if (_ChungTu.KiemTraSoQuy(_ChungTu.MaChungTu) == 0)
                                    {
                                        _ChungTu.NgayLap = dtmp_Ngay.DateTime.Date;
                                        _ChungTu.ApplyEdit();
                                        ChungTu_BindingSource.EndEdit();
                                        ButToan_BindingSource.EndEdit();
                                        _ChungTu.Save();
                                        _ngayKhoaSo = _ChungTu.NgayLap;
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Chứng từ này đã thu chi thực tế, vui lòng liên hệ Thủy Quỷ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
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

            if (Phieu == 2) // In phieu thu
            {
                #region Phieu Thu

                if (loaiIn == 5)
                {
                    if(ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9)
                        Report = new Report.CongNo.PhieuThu();
                    else
                        Report = new Report.CongNo.PhieuThu_DonViCon();
                }
                else if (loaiIn == 4)
                {
                    if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9)
                        Report = new Report.CongNo.PhieuThuA4();
                    else
                        Report = new Report.CongNo.PhieuThuA4_DonViCon();
                }
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_PhieuThu";
                command.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@SoCTKemTheo", 0);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command2 = new SqlCommand();
                command2.CommandType = CommandType.StoredProcedure;
                command2.CommandText = "spd_LayNoTaiKhoan_1";
                command2.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command3 = new SqlCommand();
                command3.CommandType = CommandType.StoredProcedure;
                command3.CommandText = "spd_LayCoTaiKhoan_1";
                command3.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlCommand command4 = new SqlCommand();
                command4.CommandType = CommandType.StoredProcedure;
                command4.CommandText = "spd_LayNguoiKyTenCongNo";
                command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_PhieuThu;1";
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
                table2.TableName = "spd_LayNoTaiKhoan_1;1";
                _DataSet.Tables.Add(table2);

                SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
                DataTable table3 = new DataTable();
                adapter3.Fill(table3);
                table3.TableName = "spd_LayCoTaiKhoan_1;1";
                _DataSet.Tables.Add(table3);

                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                DataTable table4 = new DataTable();
                adapter4.Fill(table4);
                table4.TableName = "spd_LayNguoiKyTenCongNo;1";
                _DataSet.Tables.Add(table4);
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
            //btnChiThuLao.Enabled = false;


            soChungTu = 0;
            tlslblXoa.Visible = false;
            TaoMoiChungTu(2);
            New();
            SetSoChungTuMoiPS(2);
            SetTaiKhoanDefault();

            MaKhachHang = 0;
            tlslblLuu.Enabled = true;

        }
        #endregion

        #region tlslblTim_Click  ham nay dung de double chung tu len
    

        private void tlslblTim_Click(object sender, EventArgs e)
        {

            frmTimChungTuNew f = new frmTimChungTuNew(2);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                if (f.DaChon == true)
                {
                    ButToanList btList = ButToanList.NewButToanList();
                    New();
                    ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu(f._ChungTu1.MaChungTu);
                    if (ct.Count > 0)
                    {
                        _ChungTu = ct[0];
                    }
                    maDoiTuong = _ChungTu.DoiTuong;
                    TienTe tt = TienTe.GetTienTe(_ChungTu.MaChungTu);
                    if (_ChungTu.MaChungTu != 0)
                    {
                        if (_ChungTu.NgayLap.Year > 2013)
                        {
                            tlslblLuu.Enabled = false;
                        }
                        else
                        {
                            tlslblLuu.Enabled = true;
                        }
                        dtmp_Ngay.DateTime = _ChungTu.NgayLap;
                        _ngayKhoaSo = _ChungTu.NgayLap;
                        Phieu = _ChungTu.LoaiChungTu.MaLoaiCT;
                        crreu_SoTien.Value = tt.SoTien;
                        crre_ThanhTien.Value = tt.ThanhTien;
                        LayDoiTuongThuChi_KhongTaoMoi(Phieu);
                        ChungTu_BindingSource.DataSource = _ChungTu;
                        DoiTuongThu_Chi = _ChungTu.MaDoiTuongThuChi;
                        TienTe_BindingSource.DataSource = tt;

                        txtutxeditSoCT.Text = _ChungTu.SoChungTu;
                        group_ThongTinPhieu.Enabled = true;
                        tab_Info.Enabled = true;

                        cmbu_TaiKhoanNC.Value = _ChungTu.DinhKhoan.LaMotNoNhieuCo;
                        if (_ChungTu.DinhKhoan.ButToan.Count != 0)
                        {
                            if (_ChungTu.DinhKhoan.LaMotNoNhieuCo == true) // no tren
                            {
                                ultraCombo_NoTaiKhoan.Value = _ChungTu.DinhKhoan.ButToan[0].NoTaiKhoan;
                            }
                            else // co tren
                            {
                                ultraCombo_CoTaiKhoan.Value = _ChungTu.DinhKhoan.ButToan[0].CoTaiKhoan;
                            }
                        }
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
                                txtNguoiNhan.Text = txtNguoiNhan.Text = dtKhachHang.MaQLDoiTuong + " - " + dtKhachHang.TenDoiTuong;
                                txtDiaChi.Text = dtKhachHang.DiaChi;
                            }
                        }
                        //if (_ChungTu.ChiThuLaoList.Count != 0)
                        //{
                        //    // btnChiThuLao.Enabled = true;
                        //    _ChiThuLaoList = _ChungTu.ChiThuLaoList;
                        //    LoaiChi = 1;
                        //}
                        soChungTu = _ChungTu.MaChungTu;
                        tlslblXoa.Visible = true;
                        cmbu_GhiMucNganSach.Value = _ChungTu.DinhKhoan.GhiMucNganSach;
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
                    if (_ChungTu.DinhKhoan.LaMotNoNhieuCo == true)
                    {
                        ChonNoLoad();
                        ultraCombo_NoTaiKhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_ChungTu.DinhKhoan.ButToan[0].NoTaiKhoan).SoHieuTK;
                        _ButToanList = ButToanList.GetButToanList_DinhKhoan(_ChungTu.DinhKhoan.ButToan._MaDinhKhoan);
                    }
                    else
                    {
                        ChonCoLoad();
                        ultraCombo_CoTaiKhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_ChungTu.DinhKhoan.ButToan[0].CoTaiKhoan).SoHieuTK;
                        _ButToanList = ButToanList.GetButToanList_DinhKhoan(_ChungTu.DinhKhoan.ButToan._MaDinhKhoan);
                    }
                }
            }
            else
            {
                ChonCoLoad();
            }
        }
        #endregion

        #region lấy nợ có tài khoản
        String NoTaiKhoan1;
        String CoTaiKhoan1;
        private void LayNoCoTaiKhoan()
        {
            if (cmbu_TaiKhoanNC.Text == "Có")
            {
                ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].Hidden = true;
                ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Hidden = false;
                ultraCombo_CoTaiKhoan.Visible = true;
                ultraCombo_NoTaiKhoan.Visible = false;
            }
            else
            {
                ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Hidden = true;
                ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].Hidden = false;
                ultraCombo_NoTaiKhoan.Visible = true;
                ultraCombo_CoTaiKhoan.Visible = false;
            }

            ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
        }
        #endregion

        #region lấy nợ có defaul

        String NoTaiKhoan;
        String CoTaiKhoan;
        private void LayNoCoTaiKhoanDefault()
        {
            if (NoTaiKhoan_BindingSource.Current != null)
            {
                NoTaiKhoan = Convert.ToString(((HeThongTaiKhoan1)NoTaiKhoan_BindingSource.Current).SoHieuTK);
            }
            else if (((HeThongTaiKhoan1)CoTaiKhoan_BindingSource.Current) != null)
            {
                CoTaiKhoan = Convert.ToString(((HeThongTaiKhoan1)CoTaiKhoan_BindingSource.Current).SoHieuTK);
            }
            if (cmbu_TaiKhoanNC.Text == "Có")
            {

                ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].Hidden = true;
                ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Hidden = false;
                ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].DefaultCellValue = CoTaiKhoan; //ultraCombo_CoTaiKhoan.Value;                
                ultraCombo_CoTaiKhoan.Visible = true;
                ultraCombo_NoTaiKhoan.Visible = false;

            }
            else
            {

                ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Hidden = true;
                ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].Hidden = false;
                ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].DefaultCellValue = ultraCombo_NoTaiKhoan.Value;//ultraCombo_NoTaiKhoan.Value;                
                ultraCombo_NoTaiKhoan.Visible = true;
                ultraCombo_CoTaiKhoan.Visible = false;
            }

        }
        #endregion

        #region hàm thay đổi nợ có tài khoản
        private void ThayDoiNoCoTaiKhoan()
        {
            if (cmbu_TaiKhoanNC.Text == "Có")
            {
                foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                {
                    bt.CoTaiKhoan = Convert.ToInt32(ultraCombo_CoTaiKhoan.Value);
                }
            }
            if (cmbu_TaiKhoanNC.Text == "Nợ")
            {
                foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                {
                    bt.NoTaiKhoan = Convert.ToInt32(ultraCombo_NoTaiKhoan.Value);
                }
            }

            ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
        }
        #endregion

        private void ChonNo()
        {
            //this.ultraCombo_NoTaiKhoan.ValueChanged += new System.EventHandler(this.ultraCombo_NoTaiKhoan_TextChanged);
            //this.ultraCombo_CoTaiKhoan.ValueChanged -= new System.EventHandler(this.ultraCombo_NoTaiKhoan_TextChanged);
        }

        private void ChonCo()
        {
            //this.ultraCombo_CoTaiKhoan.ValueChanged += new System.EventHandler(this.ultraCombo_NoTaiKhoan_TextChanged);
            //this.ultraCombo_NoTaiKhoan.ValueChanged -= new System.EventHandler(this.ultraCombo_NoTaiKhoan_TextChanged);
        }

        private void ChonNoLoad()
        {
            _ChungTu.DinhKhoan.LaMotNoNhieuCo = true;
            cmbu_TaiKhoanNC.Text = "Nợ";
        }

        private void ChonCoLoad()
        {
            _ChungTu.DinhKhoan.LaMotNoNhieuCo = false;
            cmbu_TaiKhoanNC.Text = "Có";
        }

        #region cmbu_TaiKhoanNC_ValueChanged
        private void cmbu_TaiKhoanNC_ValueChanged(object sender, EventArgs e)
        {
            
            LayNoCoTaiKhoan();
            if ((bool)cmbu_TaiKhoanNC.Value == true)
            {
                if (this.ultraCombo_CoTaiKhoan.DataBindings.Count ==0)
                    this.ultraCombo_CoTaiKhoan.DataBindings.Add(a);
                if (this.ultraCombo_NoTaiKhoan.DataBindings.Count !=0 ) 
                    this.ultraCombo_NoTaiKhoan.DataBindings.Remove(b);
               // _HeThongTaiKhoan1ListNo = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
                NoTaiKhoan_BindingSource.DataSource = _HeThongTaiKhoan1ListNo;
                ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongNo"].Hidden = true;
                ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongCo"].Hidden = false;
                ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongCo"].Header.Caption = "Đối Tượng Có";
                ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongCo"].Header.VisiblePosition = 5;
                ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongCo"].EditorComponent = ultraCombo_DoiTuongCo;
                ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongCo"].Width = 200;
                lbDoiTuong.Text = "Đối Tượng Nợ";
                ultraCombo_DoiTuongCo.Visible = false;
                ultraCombo_DoiTuongNo.Visible = true;
            }
            else
            {
                if (this.ultraCombo_NoTaiKhoan.DataBindings.Count ==0 )
                    this.ultraCombo_NoTaiKhoan.DataBindings.Add(b);
                if (this.ultraCombo_CoTaiKhoan.DataBindings.Count !=0 )
                    this.ultraCombo_CoTaiKhoan.DataBindings.Remove(a);
                //this.ultraCombo_CoTaiKhoan.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.ButToan_BindingSource, "CoTaiKhoan", false));
                //_HeThongTaiKhoan1ListCo = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
                CoTaiKhoan_BindingSource.DataSource = _HeThongTaiKhoan1ListCo;
                ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongCo"].Hidden = true;
                ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongNo"].Hidden = false;
                ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongNo"].Header.Caption = "Đối Tượng Nợ";
                ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongNo"].Header.VisiblePosition = 5;
                ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongNo"].EditorComponent = ultraCombo_DoiTuongNo;
                ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongNo"].Width = 200;
                lbDoiTuong.Text = "Đối Tượng Có";
                ultraCombo_DoiTuongCo.Visible = true;
                ultraCombo_DoiTuongNo.Visible = false;
            }
            //ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongNo"].Hidden = true;
            //ugrButToan.DisplayLayout.Bands[0].Columns["DoiTuongCo"].Hidden = true;
        }
        #endregion


        #region ultraCombo_NoTaiKhoan_ValueChanged
        private void ultraCombo_NoTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_TaiKhoanNC.Value != null)
            {
                if ((bool)cmbu_TaiKhoanNC.Value == true)
                {
                    if (ultraCombo_NoTaiKhoan.Value != null)
                    {
                        _HeThongTaiKhoan1ListCo = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List((int)ultraCombo_NoTaiKhoan.Value);
                        CoTaiKhoan_BindingSource.DataSource = _HeThongTaiKhoan1ListCo;
                        ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
                        HeThongTaiKhoan1 tkn = HeThongTaiKhoan1.GetHeThongTaiKhoan1(Convert.ToInt32(ultraCombo_NoTaiKhoan.Value));

                        if (tkn.CoDoiTuongTheoDoi == true)
                        {
                            ultraCombo_DoiTuongNo.Value = _ChungTu.DoiTuong;
                        }
                        else ultraCombo_DoiTuongNo.Value = 0;
                        foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                        {
                            bt.NoTaiKhoan = tkn.MaTaiKhoan;
                            if (tkn.CoDoiTuongTheoDoi == true)
                            {
                                bt.DoiTuongNo = _ChungTu.DoiTuong;
                            }
                            else
                            {
                                bt.DoiTuongNo = 0;
                            }
                        }

                    }
                }
               
                ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
            }
        }
        #endregion

        #region ultraCombo_CoTaiKhoan_ValueChanged
        private void ultraCombo_CoTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_TaiKhoanNC.Value != null)
            {
                ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
                if ((bool)cmbu_TaiKhoanNC.Value == false)
                {
                    if (ultraCombo_CoTaiKhoan.Value != null)
                    {
                        _HeThongTaiKhoan1ListNo = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List((int)ultraCombo_CoTaiKhoan.Value);
                        NoTaiKhoan_BindingSource.DataSource = _HeThongTaiKhoan1ListNo;
                        ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
                        HeThongTaiKhoan1 tkc = HeThongTaiKhoan1.GetHeThongTaiKhoan1(Convert.ToInt32(ultraCombo_CoTaiKhoan.Value));
                        if (tkc.CoDoiTuongTheoDoi == true)
                        {
                            ultraCombo_DoiTuongCo.Value = _ChungTu.DoiTuong;
                        }
                        else ultraCombo_DoiTuongCo.Value = 0;
                        foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                        {
                            bt.CoTaiKhoan = tkc.MaTaiKhoan;
                            if (tkc.CoDoiTuongTheoDoi == true)
                            {
                                bt.DoiTuongCo = _ChungTu.DoiTuong;
                            }
                            else
                            {
                                bt.DoiTuongCo = 0;
                            }
                        }

                        ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
                    }
                }               
            }

            ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
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
            crreu_SoTien.SelectAll();

        }

        #endregion

        #region Click
        private void btnu_InUyNhiem_Click(object sender, EventArgs e)
        {
            DataSet _DataSet = new DataSet();
            if (Phieu == 6) // In Uy Nhiem Chi
            {
                #region Uy Nhiem Chi
                ReportDocument Report = new PSC_ERP.Report.CongNo.UyNhiemChi();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_UyNhiemChi";
                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@MaCongTy", 1);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_UyNhiemChi;1";
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

                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }
            else if (Phieu == 7) // In Uy Nhiem Chi
            {
                #region Uy Nhiem Thu
                ReportDocument Report = new PSC_ERP.Report.CongNo.UyNhiemThu();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_UyNhiemThu";
                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@MaCongTy", 1);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_UyNhiemThu;1";
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

                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }
        }

        private void btnu_ChuyenKhoan_Click(object sender, EventArgs e)
        {
            DataSet _DataSet = new DataSet();
            ReportDocument Report = new PSC_ERP.Report.CongNo.PhieuChuyenKhoan();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_CongNo_ChuyenKhoan";
            command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
            command1.CommandText = "spd_REPORT_ReportHeader";

            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.StoredProcedure;
            command2.CommandText = "BarcodeReport_Create_CK";
            command2.Parameters.AddWithValue("@MaPhieu", _ChungTu.MaChungTu);

            command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlCommand command3 = new SqlCommand();
            command3.CommandType = CommandType.StoredProcedure;
            command3.CommandText = "spd_LayNoTaiKhoan";
            command3.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

            command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlCommand command4 = new SqlCommand();
            command4.CommandType = CommandType.StoredProcedure;
            command4.CommandText = "spd_LayCoTaiKhoan";
            command4.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

            command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_CongNo_ChuyenKhoan;1";
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
            table2.TableName = "BarcodeReport_Create_CK;1";
            _DataSet.Tables.Add(table2);

            SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
            DataTable table3 = new DataTable();
            adapter3.Fill(table3);
            table3.TableName = "spd_LayNoTaiKhoan;1";
            _DataSet.Tables.Add(table3);

            SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
            DataTable table4 = new DataTable();
            adapter4.Fill(table4);
            table4.TableName = "spd_LayCoTaiKhoan;1";
            _DataSet.Tables.Add(table4);

            Report.SetDataSource(_DataSet);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void dtmp_Ngay_Leave(object sender, EventArgs e)
        {
            DateTime NgayLap = DateTime.Today;
            if (dtmp_Ngay.Value != null)
                NgayLap = Convert.ToDateTime(dtmp_Ngay.Value);
        }
        #endregion


        #region InitializeLayout
        private void ultraCombo_NoTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {


            foreach (UltraGridColumn col in this.ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
        }

        private void ultraCombo_CoTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {


            foreach (UltraGridColumn col in this.ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
        }

        private void ugrButToan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridBand ban in this.ugrButToan.DisplayLayout.Bands)
            {
                ban.Hidden = true;
            } ugrButToan.DisplayLayout.Bands[0].Hidden = false;
            foreach (UltraGridColumn col in this.ugrButToan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Header.Appearance.BackColor = System.Drawing.Color.White;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    //col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "#,###.##";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }

            e.Layout.Override.AllowAddNew = AllowAddNew.TemplateOnTop;
            e.Layout.Override.TemplateAddRowPrompt = "Click vào đây để thêm dòng mới";
            e.Layout.Override.TemplateAddRowAppearance.BackColor = Color.FromArgb(245, 250, 255);
            e.Layout.Override.TemplateAddRowAppearance.ForeColor = SystemColors.GrayText;
            e.Layout.Override.AddRowAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.AddRowAppearance.ForeColor = Color.Blue;
            e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.TemplateAddRow;
            e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = SystemColors.Control;
            e.Layout.Override.TemplateAddRowPromptAppearance.ForeColor = Color.Maroon;
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            ugrButToan.DisplayLayout.Bands[1].Hidden = true;
            ugrButToan.DisplayLayout.Bands[2].Hidden = true;

            ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Hidden = false;
            ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Header.Caption = "Nợ Tài Khoản";
            ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Header.VisiblePosition = 0;
            ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].EditorComponent = ultraCombo_NoTaiKhoan;
            ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Width = 80;

            ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].Hidden = false;
            ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].Header.Caption = "Có Tài Khoản";
            ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].Header.VisiblePosition = 1;
            ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].EditorComponent = ultraCombo_CoTaiKhoan;
            ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].Width = 80;

            ugrButToan.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            ugrButToan.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            ugrButToan.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;
            ugrButToan.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            ugrButToan.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';

            ugrButToan.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            ugrButToan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            ugrButToan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            ugrButToan.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 280;

            ugrButToan.DisplayLayout.Bands[0].Columns.Add("GhiMucNganSach", "Ghi MNS");
            ugrButToan.DisplayLayout.Bands[0].Columns["GhiMucNganSach"].EditorComponent = ultraTextEditor_MNS;
            ugrButToan.DisplayLayout.Bands[0].Columns["GhiMucNganSach"].Header.VisiblePosition = 4;
            ugrButToan.DisplayLayout.Bands[0].Columns["GhiMucNganSach"].Width = 60;
            ugrButToan.DisplayLayout.Bands[0].Columns["GhiMucNganSach"].Hidden = true;
            ugrButToan.DisplayLayout.Bands[0].Columns["GhiMucNganSach"].CellActivation = Activation.ActivateOnly;
            ugrButToan.DisplayLayout.Bands[0].Columns["GhiMucNganSach"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;


            ugrButToan.DisplayLayout.Bands[0].Columns.Add("ChiPhiSXCT", "Chi Phí SXCT");
            ugrButToan.DisplayLayout.Bands[0].Columns["ChiPhiSXCT"].EditorComponent = text_CPSXCT;
            ugrButToan.DisplayLayout.Bands[0].Columns["ChiPhiSXCT"].Header.VisiblePosition = 5;
            ugrButToan.DisplayLayout.Bands[0].Columns["ChiPhiSXCT"].Width = 100;
            ugrButToan.DisplayLayout.Bands[0].Columns["ChiPhiSXCT"].Hidden = false;
            ugrButToan.DisplayLayout.Bands[0].Columns["ChiPhiSXCT"].CellActivation = Activation.ActivateOnly;
            ugrButToan.DisplayLayout.Bands[0].Columns["ChiPhiSXCT"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;

            // By loc nhap danh sach hoa don vao but toan
            ugrButToan.DisplayLayout.Bands[0].Columns.Add("Chungtu_hoadon", "DS Hóa Đơn");
            ugrButToan.DisplayLayout.Bands[0].Columns["Chungtu_hoadon"].EditorComponent = ultraTextEditor_dshoadon;
            ugrButToan.DisplayLayout.Bands[0].Columns["Chungtu_hoadon"].Header.VisiblePosition = 6;
            ugrButToan.DisplayLayout.Bands[0].Columns["Chungtu_hoadon"].Width = 80;
            ugrButToan.DisplayLayout.Bands[0].Columns["Chungtu_hoadon"].Hidden = false;
            ugrButToan.DisplayLayout.Bands[0].Columns["Chungtu_hoadon"].CellActivation = Activation.ActivateOnly;
            ugrButToan.DisplayLayout.Bands[0].Columns["Chungtu_hoadon"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;


            ugrButToan.DisplayLayout.Bands[1].Hidden = true;
            ugrButToan.DisplayLayout.Bands[0].Override.RowSelectors = DefaultableBoolean.True;
            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["SoTien"];
            SummarySettings summary2 = ugrButToan.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.Left;
            summary2.DisplayFormat = "Tông Tiền = {0:###,###,###,###,###,###.##}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            ugrButToan.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;

            //FilterCombo f = new FilterCombo(ugrButToan, "SoHieuTKNo", "SoHieuTKNo");
            //FilterCombo f1 = new FilterCombo(ugrButToan, "SoHieuTKCo", "SoHieuTKCo");
        }
        #endregion

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Lap Phieu", "Help_CongNo.chm");
        }

        private void ugrButToan_AfterRowInsert(object sender, RowEventArgs e)
        {
            decimal sotien = Convert.ToDecimal(crre_ThanhTien.Value);
            if (_ChungTu.DinhKhoan.ButToan.Count != 0)
            {
                foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                {
                    //if (HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan).SoHieuTK.Contains("312") && HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan).SoHieuTK.StartsWith("312"))
                    //    bt_TamUng.Enabled = true;
                    //if (HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.CoTaiKhoan).SoHieuTK.Contains("312") && HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.CoTaiKhoan).SoHieuTK.StartsWith("312"))
                    //    bt_TamUng.Enabled = true;

                    if (sotien != bt.SoTien)
                        sotien -= bt.SoTien;
                    else if (sotien == bt.SoTien)
                        sotien = 0;
                }
                if (ugrButToan.ActiveRow != null)
                {
                    ugrButToan.ActiveRow.Cells["SoTien"].Value = sotien;

                    ugrButToan.ActiveRow.Cells["DienGiai"].Value = txtu_DienGiai.Value;
                    if (ultraCombo_CoTaiKhoan.Value != null)
                        ugrButToan.ActiveRow.Cells["CoTaiKhoan"].Value = Convert.ToInt32(ultraCombo_CoTaiKhoan.Value);
                    if (ultraCombo_NoTaiKhoan.Value != null)
                        ugrButToan.ActiveRow.Cells["NoTaiKhoan"].Value = Convert.ToInt32(ultraCombo_NoTaiKhoan.Value);

                }
            }
        }

        private void GhiMucNganSach()
        {
            if (cmbu_GhiMucNganSach.Text == "Không")
            {
                _ChungTu.DinhKhoan.GhiMucNganSach = false;
                cmbu_GhiMucNganSach.Text = "Không";
                ugrButToan.DisplayLayout.Bands["ButToan"].Columns["GhiMucNganSach"].Hidden = true;
                ugrButToan.DisplayLayout.Bands["ButToan"].Columns["DienGiai"].Width = 437;
            }
            else if (cmbu_GhiMucNganSach.Text == "Có")
            {
                _ChungTu.DinhKhoan.GhiMucNganSach = true;
                cmbu_GhiMucNganSach.Text = "Có";
                ugrButToan.DisplayLayout.Bands["ButToan"].Columns["GhiMucNganSach"].Hidden = false;
                ugrButToan.DisplayLayout.Bands["ButToan"].Columns["DienGiai"].Width = 377;
            }

        }

        private void cmbu_GhiMucNganSach_ValueChanged(object sender, EventArgs e)
        {
            GhiMucNganSach();
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

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (_ChungTu.MaChungTu != 0)
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

        private void btnChiThuLao_Click(object sender, EventArgs e)
        {
            //if (soTien <= 0)
            //{
            //    MessageBox.Show(this, "Số tiền chi chưa có. Xem lại.", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    return;
            //}
            //if (_ChungTu.MaChungTu != 0)
            //    _ChiThuLaoList = _ChungTu._ChiThuLaoList;
            //_ChungTu.ChiThuLaoList.BeginEdit();

            //frmChiThuLao _frmChiThuLao = new frmChiThuLao( _ChungTu.ChiThuLaoList, 0,);
            //if (_frmChiThuLao.ShowDialog(this) != DialogResult.OK)
            //{

            //    if (_frmChiThuLao.Luu == true)
            //    {

            //        _ChungTu.ChiThuLaoList = _frmChiThuLao._ChiThuLaoList;
            //        _ChungTu.ChiThuLaoList.ApplyEdit();
            //        //   _ChiThuLaoList = _frmChiThuLao._ChiThuLaoList;
            //    }
            //    else
            //    {
            //        _ChungTu.ChiThuLaoList.CancelEdit();
            //    }

            //}
        }

        private int GetMaDatabase(int MaBoPhan)
        {
            if (MaBoPhan == 22)
                return 22;
            if (MaBoPhan == 26)
                return 26;
            return 1;
        }

        private void chkKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhachHang.Checked == true)
            {
                ShowKH();
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


        private void ultraCombo_NoTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            FilterCombo filter = new FilterCombo(ultraCombo_NoTaiKhoan, "SoHieuTK");
        }

        private void ultraCombo_CoTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            FilterCombo filter = new FilterCombo(ultraCombo_CoTaiKhoan, "SoHieuTK");
        }

        void SetTaiKhoanDefault()
        {

            int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

            if (maCongTy == 2)//HTVC
            {
                ultraCombo_NoTaiKhoan.Value = GetMaTaiKhoan("1111.9");
            }
            else if (maCongTy == 3)
            {
                ultraCombo_NoTaiKhoan.Value = GetMaTaiKhoan("1111.5");
            }
            else
                ultraCombo_NoTaiKhoan.Value = GetMaTaiKhoan("1111");

        }

        public int GetMaTaiKhoan(String soHieuTK)
        {
            foreach (HeThongTaiKhoan1 tk in _HeThongTaiKhoan1List)
                if (tk.SoHieuTK == soHieuTK)
                    return tk.MaTaiKhoan;
            return 1;
        }

        private void cmbu_LoaiTien_Leave(object sender, EventArgs e)
        {
            // SetSoChungTuMoiPS(Phieu);
        }

        private void ugrButToan_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (ugrButToan.ActiveRow != null)
            {

                if (((ButToan)ButToan_BindingSource.Current).NoTaiKhoan == 55 || ((ButToan)ButToan_BindingSource.Current).CoTaiKhoan == 55)
                {
                    ugrButToan.ActiveRow.Cells["DienGiai"].Value = "Thuế GTGT Được Khấu Trừ Của Hàng Hóa, Dịch Vụ";
                }

            }
        }
        
        private void SetSoChungTuMoiPS(int MaPhieu)
        {
            int loaitien = Convert.ToInt32(cmbu_LoaiTien.Value);
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
            // }
            //else // dung cho cong doan
            //{
            //    string mamoi = SoCTCu;
            //    string strSoMoi = SoCTCu;
            //    int len = strSoMoi.Length;
            //    string nam = DateTime.Today.Year.ToString();
            //    while (len < 3)
            //    {
            //        strSoMoi = "0" + strSoMoi;
            //        len = strSoMoi.Length;
            //    }
            //    mamoi = strSoMoi + "CD/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL;
            //    _ChungTu.SoChungTu = mamoi + "/" + nam;
            //}

        }

        private void cboDoiTuongThuChi_SelectedValueChanged(object sender, EventArgs e)
        {
            DoiTuongThuChi _doituong = (DoiTuongThuChi)cboDoiTuongThuChi.SelectedItem;
            crreu_SoTien.SelectAll();
            if (_doituong != null)
            {
                txtu_DienGiai.Text = _doituong.TenDoiTuongThuChi;
                _ChungTu.MaDoiTuongThuChi = _doituong.MaDoiTuongThuChi;
            }
        }

        private void btnChuongTrinh_Click(object sender, EventArgs e)
        {
            //if (soTien <= 0)
            //{
            //    MessageBox.Show(this, "Số tiền chi chưa có. Xem lại.", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    return;
            //}
            //if (_ChungTu.MaChungTu != 0)
            //    _ChiThuLaoList = _ChungTu._ChiThuLaoList;
            //frmDSChuongTrinhCN _frmDSChuongTrinh = new frmDSChuongTrinhCN(soTien, _ChungTu.CT_ChuongTrinhList);
            //if (_frmDSChuongTrinh.ShowDialog(this) != DialogResult.OK)
            //{
            //    if (_frmDSChuongTrinh.Luu == true)
            //    {
            //        _ChungTu.CT_ChuongTrinhList = _frmDSChuongTrinh._ChungTu_ChuongTrinhList;
            //    }

            //}
        }
       
        private void cboDoiTuongThuChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtmp_Ngay.SelectAll();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LoaiIn(4);
        }
              
        private void bt_TamUng_Click(object sender, EventArgs e)
        {
            //frmTamUng a = new frmTamUng(_ChungTu.MaChungTu, 2);
            //a.Show();

            //if (_ChungTu.MaChungTu != 0)
            //    _tamUngList = _ChungTu.TamUngList;
            //_ChungTu.TamUngList.BeginEdit();

            //frmTamUng _frmTamUng = new frmTamUng(_ChungTu.TamUngList, 2);
            //if (_frmTamUng.ShowDialog(this) != DialogResult.OK)
            //{
            //    if (_frmTamUng.IsSave == true)
            //    {
            //        _ChungTu.TamUngList = _frmTamUng._tamUngList;
            //        _ChungTu.TamUngList.ApplyEdit();
            //    }
            //    else
            //    {
            //        _ChungTu.TamUngList.CancelEdit();
            //    }

            //}

            if (_ChungTu.MaChungTu != 0)
                _tamUngList = _ChungTu.TamUngList;
            _ChungTu.TamUngList.BeginEdit();

            frmTamUng _frmTamUng = new frmTamUng(_ChungTu.TamUngList, 2, _ChungTu.DienGiai, _ChungTu.NgayLap, maDoiTuong, _ChungTu.Tien.ThanhTien);
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

        private void button2_Click(object sender, EventArgs e)
        {
            _ChungTu.ChungTuChiPhiSanXuatList.BeginEdit();
            frmChiPhiSanXuatChuongTrinh f = new frmChiPhiSanXuatChuongTrinh(_ChungTu,_ChungTu.ChungTuChiPhiSanXuatList, _ChungTu.SoTien, _ChungTu.MaChungTu, _ChungTu.SoChungTu, maDoiTuong, _ChungTu.NgayLap, _ChungTu.DienGiai, 0);
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

        private void cbDoiTuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(ugrButToan, "MaDoiTuong", "TenDoiTuong");
            foreach (UltraGridColumn col in this.cbDoiTuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Hidden = false;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "Tên Khách Hàng";
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 0;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Width = 250;

            cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 2;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Width = 250;

            cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Hidden = false;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.Caption = "Mã Quản Lý";
            cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.VisiblePosition = 1;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Width = 250;

        }

        private void ugrButToan_BeforeCellListDropDown(object sender, CancelableCellEventArgs e)
        {
            if (ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Hidden == false)
            {
                int maTaiKhoanNo = (int)ugrButToan.ActiveRow.Cells["NoTaiKhoan"].Value;
                cbDoiTuong.DisplayLayout.Bands[0].ColumnFilters["MaTaiKhoan"].ClearFilterConditions();
                cbDoiTuong.DisplayLayout.Bands[0].ColumnFilters["MaTaiKhoan"].FilterConditions.Add(FilterComparisionOperator.Equals, maTaiKhoanNo);
            }
            else if (ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Hidden == true)
            {
                int maTaiKhoanCo = (int)ugrButToan.ActiveRow.Cells["CoTaiKhoan"].Value;
                cbDoiTuong.DisplayLayout.Bands[0].ColumnFilters["MaTaiKhoan"].FilterConditions.Clear();
                cbDoiTuong.DisplayLayout.Bands[0].ColumnFilters["MaTaiKhoan"].FilterConditions.Add(FilterComparisionOperator.Equals, maTaiKhoanCo);
            }
        }

        private void ugrButToan_AfterCellUpdate_1(object sender, CellEventArgs e)
        {
            ButToan butToan = ((ButToan)ButToan_BindingSource.Current);
            if (e.Cell == ugrButToan.ActiveRow.Cells["NoTaiKhoan"])
            {
                HeThongTaiKhoan1 tkn = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.NoTaiKhoan);
                if (tkn.CoDoiTuongTheoDoi == true)
                    ((ButToan)(ButToan_BindingSource.Current)).DoiTuongNo = _ChungTu.DoiTuong;
                else ((ButToan)(ButToan_BindingSource.Current)).DoiTuongNo = 0;
            }
            else if (e.Cell == ugrButToan.ActiveRow.Cells["CoTaiKhoan"])
            {
                HeThongTaiKhoan1 tkc = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.CoTaiKhoan);
                if (tkc.CoDoiTuongTheoDoi == true)
                    ((ButToan)(ButToan_BindingSource.Current)).DoiTuongCo = _ChungTu.DoiTuong;
                else ((ButToan)(ButToan_BindingSource.Current)).DoiTuongCo = 0;
            }

            #region Tạm ứng
            if (e.Cell == ugrButToan.ActiveRow.Cells["NoTaiKhoan"] || e.Cell == ugrButToan.ActiveRow.Cells["CoTaiKhoan"])
            {
                string TK = "";
                if (e.Cell.Value != null)
                {
                    TK = HeThongTaiKhoan1.GetHeThongTaiKhoan1((int)e.Cell.Value).SoHieuTK;
                }
                ButToan_BindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
          
                if (TK == "312" || TK == "312.5" || TK == "312.9" || TK == "312.93" || TK == "312.1")
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
                else if (TK.Contains("3113"))
                {
                    ChungTu_HoaDonList cthdlist = ChungTu_HoaDonList.GetChungTu_HoaDonListByMaBuToan(Convert.ToInt64(ugrButToan.ActiveRow.Cells["MaButToan"].Value));
                    if (cthdlist.Count > 0)
                    {
                        MessageBox.Show(this, "Vui xóa hóa đơn trước khi sửa bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }

                }
            }
            #endregion Hết tạm ứng
        }

        private void bt_Tim_Click(object sender, EventArgs e)
        {
            string SoChungTu = txt_SoChungTu.Text.Trim();

            decimal SoTienTu = ultraCurrencyEditor_TienTu.Value;
            decimal SoTienDen = ultraCurrencyEditor_TienDen.Value;
            string TenDoiTuong = txt_DoiTuong.Text;
            string DienGiai = txtDienGiai.Text;

            _ChungTuList = ChungTuList.TimChungTu(SoChungTu, (DateTime)dtu_NgayBatDau.Value, (DateTime)dtu_NgayKetThuc.Value, SoTienTu, SoTienDen, DienGiai, maTKNoSearch, maTKCoSearch, TenDoiTuong, 2);
            DSChungTu_BindingSource.DataSource = _ChungTuList;
            if (_ChungTuList.Count == 0)
            {
                MessageBox.Show(this, "Không có chứng từ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DSChungTu_BindingSource.DataSource = _ChungTuList;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ChungTuList.ApplyEdit();
            grdu_DSChungTu.UpdateData();
            DSChungTu_BindingSource.EndEdit();
            _ChungTuList.Save();
            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void grdu_DSChungTu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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
            grdu_DSChungTu.DisplayLayout.Bands["ChungTu"].Columns["SoTien"].Header.Appearance.TextHAlign = HAlign.Right;

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
            grdu_DSChungTu.DisplayLayout.Bands["ButToanList"].Columns["CoTaiKhoan"].Width = 50;
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

        private void grdu_DSChungTu_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
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
                //LayDoiTuongThuChi_KhongTaoMoi(Phieu);
                ChungTu_BindingSource.DataSource = _ChungTu;
                DoiTuongThu_Chi = _ChungTu.MaDoiTuongThuChi;
                TienTe_BindingSource.DataSource = tt;

                txtutxeditSoCT.Text = _ChungTu.SoChungTu;
                group_ThongTinPhieu.Enabled = true;
                tab_Info.Enabled = true;

                cmbu_TaiKhoanNC.Value = _ChungTu.DinhKhoan.LaMotNoNhieuCo;
                if (_ChungTu.DinhKhoan.ButToan.Count != 0)
                {
                    if (_ChungTu.DinhKhoan.LaMotNoNhieuCo == true) // no tren
                    {
                        ultraCombo_NoTaiKhoan.Value = _ChungTu.DinhKhoan.ButToan[0].NoTaiKhoan;
                    }
                    else // co tren
                    {
                        ultraCombo_CoTaiKhoan.Value = _ChungTu.DinhKhoan.ButToan[0].CoTaiKhoan;
                    }
                }
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
                //if (_ChungTu.ChiThuLaoList.Count != 0)
                //{

                //    _ChiThuLaoList = _ChungTu.ChiThuLaoList;
                //    LoaiChi = 1;
                //}
                soChungTu = _ChungTu.MaChungTu;
                //txtDienGiai.Text = _ChungTu.DienGiai;
                tlslblXoa.Visible = true;
                cmbu_GhiMucNganSach.Value = _ChungTu.DinhKhoan.GhiMucNganSach;

                TongTien = crre_ThanhTien.Value;
                soTien = tt.SoTien;
                this.ultraTabControl1.SelectedTab = ultraTabPageControl1.Tab;
            }

        }

        private void text_CPSXCT_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            ((ButToan)ButToan_BindingSource.Current).BeginEdit();
            frmChiThuLao.SoTienDaNhap = 0;
            frmChiPhiThucHien.SoTienDaNhap = 0;
            //_ChungTu.ChungTuChiPhiSanXuatList.BeginEdit();
            ChungTu_ChiPhiSanXuatList cpList = ((ButToan)ButToan_BindingSource.Current).ChungTuChiPhiSanXuatList;
            frmChiPhiSanXuatChuongTrinh f = new frmChiPhiSanXuatChuongTrinh(_ChungTu,cpList, ((ButToan)ButToan_BindingSource.Current).SoTien, _ChungTu.MaChungTu, _ChungTu.SoChungTu, maDoiTuong, _ChungTu.NgayLap, ((ButToan)ButToan_BindingSource.Current).DienGiai, ((ButToan)ButToan_BindingSource.Current).MaButToan);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                if (f.IsSave == true)
                {


                    ((ButToan)ButToan_BindingSource.Current).ChungTuChiPhiSanXuatList = f._ChungTu_ChiPhiSXList;
                    ((ButToan)ButToan_BindingSource.Current).ChungTuChiPhiSanXuatList.ApplyEdit();
                    _ChungTu.ChungTuChiPhiSanXuatList = f._ChungTu_ChiPhiSXList;
                    ((ButToan)ButToan_BindingSource.Current).SoTien = f.SoTienDaNhap;
                    ((ChungTu)ChungTu_BindingSource.Current).ButToanList = ((ButToanList)ButToan_BindingSource.DataSource);
                    _ChungTu.ChungTuChiPhiSanXuatList.ApplyEdit();
                }
                else
                {
                    _ChungTu.ChungTuChiPhiSanXuatList.CancelEdit();
                }
            }
        }

        private void ultraTextEditor_dshoadon_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            frmDanhSachHoaDonDichVu _frm = new frmDanhSachHoaDonDichVu(_ChungTu, (ButToan)ButToan_BindingSource.Current);
            _frm.Show();
        }

        private void cbu_SoHieuTKNo_ValueChanged(object sender, EventArgs e)
        {
            if (cbu_SoHieuTKNo.ActiveRow != null)
            {
                maTKNoSearch = Convert.ToInt32(cbu_SoHieuTKNo.Value);

            }
        }

        private void cbu_SoHieuTKCo_ValueChanged(object sender, EventArgs e)
        {
            if (cbu_SoHieuTKCo.ActiveRow != null)
            {
                maTKCoSearch = Convert.ToInt32(cbu_SoHieuTKCo.Value);

            }
        }

        private void ugrButToan_ClickCell(object sender, ClickCellEventArgs e)
        {
            #region Tạm ứng
         
            if (e.Cell == ugrButToan.ActiveRow.Cells["NoTaiKhoan"] || e.Cell == ugrButToan.ActiveRow.Cells["CoTaiKhoan"])
            {
                string TK = "";

                if (e.Cell.Value != null)
                {

                    TK = HeThongTaiKhoan1.GetHeThongTaiKhoan1((int)e.Cell.Value).SoHieuTK;
                }
                if (TK == "312" || TK == "312.5" || TK == "312.9" || TK == "312.93" || TK == "312.1")
                {
                    if (_ChungTu.MaChungTu != 0)
                        _tamUngList = _ChungTu.TamUngList;
                    _ChungTu.TamUngList.BeginEdit();

                    frmTamUng _frmTamUng = new frmTamUng(_ChungTu.TamUngList, _ChungTu.LoaiChungTu.MaLoaiCT, _ChungTu.DienGiai, _ChungTu.NgayLap, maDoiTuong, _ChungTu.Tien.ThanhTien);
                    _frmTamUng.Show(this);
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
            #endregion Hết tạm ứng
        }

        private void dtmp_Ngay_ValueChanged(object sender, EventArgs e)
        {
            SetSoChungTuMoiPS(2);
        }

        private void tlslblThemDN_Click(object sender, EventArgs e)
        {
            if (_ChungTu.ChungTuDeNghiList.Count == 0 && _ChungTu.ChungTuGiayBaoCoList.Count == 0 && _ChungTu.ChungTuLenhChuyenTienList.Count == 0 && _ChungTu.ChungTuDeNghiList.Count == 0 && _ChungTu.ChungTuUyNhiemChiList.Count == 0 && _ChungTu.ChungTuGiayRutTienList.Count == 0)
            {
                _ChungTu.LoaiChungTuDiKem = 0;
            }
            frmChonDeNghiChuyenKhoan frm = new frmChonDeNghiChuyenKhoan(_ChungTu);
            frm.ShowDialog();

            TaoBindingDanhSach();
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
            else if (_ChungTu.LoaiChungTuDiKem == 5)
            {
                this.bdChungTu.DataSource = typeof(ChungTu_UNCChildList);
                bdChungTu.DataSource = _ChungTu.ChungTuUyNhiemChiList;
            }
            else if (_ChungTu.LoaiChungTuDiKem == 7) // Giấy rút tiền mặt ( Chú ý: Chỉ tồn tại trong phiếu thu không tồn tại trong bảng kê)
            {
                this.bdChungTu.DataSource = typeof(ChungTu_GiayRutTienChildList);
                bdChungTu.DataSource = _ChungTu.ChungTuGiayRutTienList;
            }

            //Load thông tin của đối tượng
            if (_ChungTu.DoiTuong != 0)
            {
                chkKhachHang.Checked = false;
                dtKhachHang = DoiTuongAll.GetDoiTuongAll(_ChungTu.DoiTuong);
                txtNguoiNhan.Text = dtKhachHang.MaQLDoiTuong + " - " + dtKhachHang.TenDoiTuong;
                txtDiaChi.Text = dtKhachHang.DiaChi;
            }

            TaoCauTrucBang();
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

        private void ultraCombo_DoiTuongNo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraCombo_DoiTuongNo.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
                col.Hidden = true;
            }
            this.ultraCombo_DoiTuongNo.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Hidden = false;
            this.ultraCombo_DoiTuongNo.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.Caption = "Mã Đối Tượng";
            this.ultraCombo_DoiTuongNo.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Width = 80;
            this.ultraCombo_DoiTuongNo.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.VisiblePosition = 0;

            this.ultraCombo_DoiTuongNo.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;
            this.ultraCombo_DoiTuongNo.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";
            this.ultraCombo_DoiTuongNo.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 80;
            this.ultraCombo_DoiTuongNo.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 1;

            this.ultraCombo_DoiTuongNo.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Hidden = false;
            this.ultraCombo_DoiTuongNo.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "Tên Đối Tượng";
            this.ultraCombo_DoiTuongNo.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Width = 250;
            this.ultraCombo_DoiTuongNo.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 2;
            //màu nền
            this.ultraCombo_DoiTuongNo.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.ultraCombo_DoiTuongNo.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            //FilterCombo f = new FilterCombo(ultraCombo_DoiTuongNo, "TenDoiTuong");
            FilterCombo f1 = new FilterCombo(ugrButToan, "DoiTuongNo", "TenDoiTuong");
        }

        private void ultraCombo_DoiTuongCo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraCombo_DoiTuongCo.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
                col.Hidden = true;
            }
            this.ultraCombo_DoiTuongCo.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Hidden = false;
            this.ultraCombo_DoiTuongCo.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.Caption = "Mã Đối Tượng";
            this.ultraCombo_DoiTuongCo.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Width = 80;
            this.ultraCombo_DoiTuongCo.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.VisiblePosition = 0;

            this.ultraCombo_DoiTuongCo.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;
            this.ultraCombo_DoiTuongCo.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";
            this.ultraCombo_DoiTuongCo.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 80;
            this.ultraCombo_DoiTuongCo.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 1;

            this.ultraCombo_DoiTuongCo.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Hidden = false;
            this.ultraCombo_DoiTuongCo.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "Tên Đối Tượng";
            this.ultraCombo_DoiTuongCo.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Width = 250;
            this.ultraCombo_DoiTuongCo.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 2;
            //màu nền
            this.ultraCombo_DoiTuongNo.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.ultraCombo_DoiTuongNo.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            //FilterCombo f = new FilterCombo(ultraCombo_DoiTuongCo, "TenDoiTuong");
            FilterCombo f2 = new FilterCombo(ugrButToan, "DoiTuongCo", "TenDoiTuong");
        }

        private void tlslblInA4New_Click(object sender, EventArgs e)
        {
            ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuThuA4_2");//PhieuNhapVatTu//
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserID, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserID;
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

        private void tlslblInA5New_Click(object sender, EventArgs e)
        {
            ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuThuA5_2");//PhieuNhapVatTu//
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserID, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserID;
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
        
        public bool Inspd_CongNo_PhieuThu() //Thang
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChuoiHachToan";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dataSet);
                    dataSet.Tables[0].TableName = "spd_ChuoiHachToan";
                    dataSet.Tables[1].TableName = "spd_ChuoiTien";
                    
                }
                //tao Inspd_CongNo_PhieuThu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CongNo_PhieuThu";
                    cm.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);
                    cm.Parameters.AddWithValue("@SoCTKemTheo", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_CongNo_PhieuThu";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 

               

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }

        private void ultraCombo_DoiTuongCo_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_TaiKhoanNC.Value != null)
            {
                if ((bool)cmbu_TaiKhoanNC.Value == true)
                {
                    if (ultraCombo_DoiTuongCo.Value != null)
                    {
                        ((ButToan)(ButToan_BindingSource.Current)).DoiTuongCo = Convert.ToInt32(ultraCombo_DoiTuongCo.Value);
                    }
                }
                else
                {
                    if (ultraCombo_DoiTuongCo.Value != null)
                    {
                        foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                        {
                            bt.DoiTuongCo = Convert.ToInt32(ultraCombo_DoiTuongCo.Value);
                        }
                    }
                }
            }
        }

        private void ultraCombo_DoiTuongNo_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_TaiKhoanNC.Value != null)
            {
                if ((bool)cmbu_TaiKhoanNC.Value == true)
                {
                    if (ultraCombo_DoiTuongNo.Value != null)
                    {
                        foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                        {
                            bt.DoiTuongNo = Convert.ToInt32(ultraCombo_DoiTuongNo.Value);
                        }                        
                    }
                }
                else
                {
                    if (ultraCombo_DoiTuongNo.Value != null)
                    {
                        ((ButToan)(ButToan_BindingSource.Current)).DoiTuongNo = Convert.ToInt32(ultraCombo_DoiTuongNo.Value);
                    }
                }
            }
        }
    }
}
