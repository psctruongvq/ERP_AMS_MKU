using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP.ThanhToan
{
    public partial class frmChonHoaDon_DichVu : frmChungTuGoc
    {
        #region Properties
        private int _iLoaiDoiTuong = 0; //0: NV ngoài Đài - 1: Nhân Viên - 2: Đối tác
        public static string TenDoiTac = string.Empty;
        public static string TenNganHang = string.Empty;
        public static string TaiKhoan = string.Empty;

        #endregion

        #region Load
        public frmChonHoaDon_DichVu()
        {
            InitializeComponent();
        }

        private void frmChonHoaDon_DichVu_Load(object sender, EventArgs e)
        {
            DoiTuongAllList doiTuongAllList = DoiTuongAllList.GetDoiTuongAllList_Tim_NhanVien("", ERP_Library.Security.CurrentUser.Info.MaCongTy);
            cmbDoiTac.DataSource = doiTuongAllList;

            ///Loai Doi Tuong: 2 : Nhan Vien - 1 : Doi Tac - 3: Cong Tac Vien
            if (!IsNew)
            {
                cmbDoiTac.Value = _dataset.Tables["HoaDon_DichVu"].Rows[0]["MaDoiTuong"];
                cmb_NganHang.Value = _dataset.Tables["HoaDon_DichVu"].Rows[0]["MaNganHang"];
            }

            if (IsNew)
            {
                if (_denghi != null && _denghi.MaTaiKhoanChuyen.HasValue)
                    cmbDoiTac.Value = DoiTuongAll.GetDoiTuongAll(_denghi.MaTaiKhoanChuyen.Value).MaDoiTuong;
                else
                    cmbDoiTac.Value = 0;
                IsLoaded = true;
                CapNhatChungTuGoc(this, null);
            }
            IsLoaded = true;
        }

        private void frmChonKyLuong_CreateXMLData(object sender, EventArgs e)
        {
            DataTable tbl = _dataset.Tables.Add("HoaDon_DichVu");
            tbl.Columns.Add("MaDoiTuong", typeof(int));
            tbl.Columns.Add("TenDoiTuong", typeof(string));
            tbl.Columns.Add("SoDienThoai", typeof(string));
            tbl.Columns.Add("CMND", typeof(string));
            tbl.Columns.Add("MaSoThue", typeof(string));
            tbl.Columns.Add("MaNganHang", typeof(int));
            tbl.Columns.Add("TenNganHang", typeof(string));
            tbl.Columns.Add("SoTaiKhoan", typeof(string));      
            tbl.Rows.Add(0, 0);
        }

        private void frmChonKyLuong_SaveXMLData(object sender, CancelEventArgs e)
        {
            if (cmbDoiTac.Value == null)
            {
                e.Cancel = true;
                return;
            }
            _dataset.Tables["HoaDon_DichVu"].Rows[0]["MaDoiTuong"] = cmbDoiTac.Value;
            _dataset.Tables["HoaDon_DichVu"].Rows[0]["TenDoiTuong"] = cmbDoiTac.Text;
            _dataset.Tables["HoaDon_DichVu"].Rows[0]["SoDienThoai"] = txt_DienThoai.Text;
            _dataset.Tables["HoaDon_DichVu"].Rows[0]["CMND"] = txt_CMND.Text;
            _dataset.Tables["HoaDon_DichVu"].Rows[0]["MaSoThue"] = txt_MST.Text;
            _dataset.Tables["HoaDon_DichVu"].Rows[0]["MaNganHang"] = cmb_NganHang.Value;
            _dataset.Tables["HoaDon_DichVu"].Rows[0]["TenNganHang"] = cmb_NganHang.Text;
            _dataset.Tables["HoaDon_DichVu"].Rows[0]["SoTaiKhoan"] = txtTaiKhoan.Text;
        }

        private void cmbDoiTac_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbDoiTac.DisplayLayout.Bands[0],
            new string[3] { "TenDoiTuong", "MaSoThue", "DiaChi" },
            new string[3] { "Tên đối tượng", "Mã số thuế", "Đơn vị" },
            new int[3] { 250, 120, 250 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[3] { false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbDoiTac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
            }
            //màu nền
            this.cmbDoiTac.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.cmbDoiTac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            FilterCombo filter = new FilterCombo(cmbDoiTac, "TenDoiTuong");
        }
        #endregion

        #region Process
        private void TaoComboNganHang(int Loai)
        {
            if (Loai == 1)
            {
                HamDungChung.EditBand(cmb_NganHang.DisplayLayout.Bands[0],
                    new string[2] { "TenNganHang", "SoTaiKhoan" },
                    new string[2] { "Tên ngân hàng", "Số tài khoản" },
                    new int[2] { 250, 120 },
                    new Control[2] { null, null },
                    new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
                    new bool[2] { false, false });
            }
            else if (Loai == 2)
            {
                HamDungChung.EditBand(cmb_NganHang.DisplayLayout.Bands[0],
                    new string[2] { "TenNganHang", "SoTk" },
                    new string[2] { "Tên ngân hàng", "Số tài khoản" },
                    new int[2] { 250, 100 },
                    new Control[2] { null, null },
                    new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
                    new bool[2] { false, false });
            }
            else if (Loai == 3)
            {
                HamDungChung.EditBand(cmb_NganHang.DisplayLayout.Bands[0],
                    new string[1] { "TenNganHang" },
                    new string[1] { "Tên ngân hàng" },
                    new int[1] { 250 },
                    new Control[1] { null },
                    new KieuDuLieu[1] { KieuDuLieu.Null },
                    new bool[1] { false });
            }
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_NganHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
            }
            //màu nền
            this.cmb_NganHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.cmb_NganHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            FilterCombo filter = new FilterCombo(cmb_NganHang, "TenNganHang");
        }
        #endregion

        #region Event
        private void CapNhatChungTuGoc(object sender, EventArgs e)
        {
            if (IsLoaded)
            {
                txtDienGiai.Text = "Đề nghị chuyển khoản " + _loaichungtu.TenLoai + " cho " + cmbDoiTac.Text;
            }
        }

        private void cmbDoiTac_ValueChanged(object sender, EventArgs e)
        {
           cmb_NganHang.Enabled = true;

            if (cmbDoiTac.ActiveRow != null)
            {
                txt_MST.Text = DoiTuongAll.GetDoiTuongAll(Convert.ToInt64(cmbDoiTac.Value)).MaSoThue;
                DoiTuong dt = DoiTuong.GetDoiTuong(Convert.ToInt64(cmbDoiTac.Value));
                if (dt.MaDoiTuong != 0)
                {
                    if (!dt.Loai) //Nhanvien
                    {
                        NhanVien nv = NhanVien.GetNhanVien(dt.MaDoiTuong);
                        _iLoaiDoiTuong = 1;
                        //Lấy CMND
                        txt_CMND.Text = nv.Cmnd;

                        this.NganHangBinding.DataSource = typeof(ERP_Library.NhanVien_TaiKhoanNganHangList);
                        this.NganHangBinding.DataSource = nv.NhanVienTaiKhoanNganHangList;
                        TaoComboNganHang(1);

                        foreach (NhanVien_DienThoai_Fax dienthoai in nv.NhanVien_DienThoai_FaxList)
                        {
                            if (dienthoai.Active)
                            {
                                txt_DienThoai.Text = dienthoai.SoDTFax; ;
                                break;
                            }
                            txt_DienThoai.Text = "";
                        }
                    }
                    else // Đối tác
                    {
                        DoiTac doitac = DoiTac.GetDoiTac(Convert.ToInt64(cmbDoiTac.Value));
                        _iLoaiDoiTuong = 2;

                        this.NganHangBinding.DataSource = typeof(ERP_Library.TK_NganHangList);
                        this.NganHangBinding.DataSource = doitac.TK_NganHangList;
                        txt_CMND.Text = KhachHang.GetKhachHang(doitac.MaDoiTac).Cmnd;
                        TaoComboNganHang(2);

                        foreach (DoiTac_DienThoai_Fax dienthoai in doitac.DoiTac_DienThoai_FaxList)
                        {
                            if (dienthoai.Active)
                            {
                                txt_DienThoai.Text = dienthoai.SoDTFax; ;
                                break;
                            }
                            txt_DienThoai.Text = "";
                        }
                    }
                }
                else
                {
                    NhanVienNgoaiDai nv = NhanVienNgoaiDai.GetNhanVienNgoaiDai(Convert.ToInt64(cmbDoiTac.Value));
                    //Lấy CMND
                    txt_CMND.Text = nv.Cmnd;
                    txt_DienThoai.Text = nv.DienThoai;
                    txtTaiKhoan.Text = nv.SoTaiKhoan;
                    cmb_NganHang.Enabled = false;

                    this.NganHangBinding.DataSource = typeof(ERP_Library.NganHangList);
                    this.NganHangBinding.DataSource = NganHangList.GetNganHangList();
                    TaoComboNganHang(3);

                    cmb_NganHang.Value = nv.MaNganHang;
                    //cmb_NganHang.Text = nv.TenNganHang;
                }

                if (Convert.ToInt32(cmb_NganHang.Value) == 0)
                    cmb_NganHang.Value = null;
                cmb_NganHang.DisplayMember = "TenNganHang";
                cmb_NganHang.ValueMember = "MaNganHang";
                CapNhatChungTuGoc(sender, e);

            }

            //Lưu tạm tên đối tác đang chọn
            TenDoiTac = cmbDoiTac.Text;
        }

        private void cmb_NganHang_ValueChanged(object sender, EventArgs e)
        {
            int iMaDoiTac = 0;
            int iMaNganHang = 0;
            if (cmb_NganHang.ActiveRow != null)
            {
                iMaDoiTac = Convert.ToInt32(cmbDoiTac.Value);
                iMaNganHang = Convert.ToInt32(cmb_NganHang.Value);

                if (_iLoaiDoiTuong == 1) //Nhân Viên
                {
                    txtTaiKhoan.Text = NhanVien_TaiKhoanNganHang.GetSoTaiKhoan(iMaDoiTac, iMaNganHang);
                }
                else if (_iLoaiDoiTuong == 2) //Đối tác
                {
                    txtTaiKhoan.Text = TK_NganHang.GetSoTaiKhoan(iMaDoiTac, iMaNganHang);
                }

            }
            else
            {
                cmb_NganHang.SelectedRow = null;
            }
            //Lưu tạm tên đối tác đang chọn
            TenNganHang = cmb_NganHang.Text;
            TaiKhoan = txtTaiKhoan.Text;
        }
        #endregion

    }
}