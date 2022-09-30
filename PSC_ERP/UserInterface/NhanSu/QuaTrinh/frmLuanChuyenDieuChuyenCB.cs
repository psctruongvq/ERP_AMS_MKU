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

namespace PSC_ERP
{
    public partial class frmLuanChuyenDieuChuyenCB : Form
    {
        #region Properties
        QuaTrinhLuanChuyenBoNhiem _QuaTrinhLuanChuyenBoNhiem;
        QuaTrinhLuanChuyenBoNhiemList _QuaTrinhLuanChuyenBoNhiemList;
        ChucVuList _ChucVuList;
        ChucDanhList _ChucDanhList;
        BoPhanList _PhongBanList;        
        ChuyenMonNghiepVuClassList _ChuyenMonNghiepVuClassList;
        CongTyList _CongTyList;
        TenNhanVienList _TenNhanVienList;
        TenNhanVienList _TenNhanVienHangLoatList;
        LoaiQuyetDinhList _LoaiQuyetDinhList;
     
        BoNhiemList _BoNhiemList = BoNhiemList.NewBoNhiemList(); 
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        Util util = new Util();
        NhanVien _nhanVien = NhanVien.NewNhanVien();
        static long MaNhanVien;
        int maBoPhanMoi = 0;
        NhomNgachLuongCoBanList nhomNgachList, nhomNgachBHList;
        BacLuongCoBanList bacCoBanCuList,bacCoBanMoiList,bacBaoHiemCuList,bacBaoHiemMoiList;
        NgachLuongCoBanList ngachCoBanCuList, ngachCoBanMoiList, ngachBaoHiemCuList, ngachBaoHiemMoiList;
        int _Loai;
        #endregion

        #region Contructor
        public frmLuanChuyenDieuChuyenCB()
        {
            InitializeComponent();

            //chucVuListBindingSource.DataSource = typeof(ChucVuList);
            //tenNhanVienListBindingSource.DataSource = typeof(TenNhanVienList);
            //phongBanListBindingSource.DataSource = typeof(BoPhanList);
            //bdNhanVien.DataSource = typeof(TenNhanVienList);
            //bdBacBHCu.DataSource = typeof(BacLuongCoBanList);
            //bdBacBHMoi.DataSource = typeof(BacLuongCoBanList);
            //bdBacLuongCu.DataSource = typeof(BacLuongCoBanList);
            //bdBacMoi.DataSource = typeof(BacLuongCoBanList);
            //bdNhomNgach.DataSource = typeof(NhomNgachLuongCoBanList);
            //bdNhomNgachBH.DataSource = typeof(NhomNgachLuongCoBanList);
            //bdNgachBHCu.DataSource = typeof(NgachLuongCoBanList);
            //bdNgachBHMoi.DataSource = typeof(NgachLuongCoBanList);
            //bdNgachCu.DataSource = typeof(NgachLuongCoBanList);
            //bdNgachMoi.DataSource = typeof(NgachLuongCoBanList);
            //bdQuaTrinhLuanChuyenBoNhiem.DataSource = typeof(QuaTrinhLuanChuyenBoNhiemList);
            //bdQuaTrinhLuanChuyenList.DataSource = typeof(QuaTrinhLuanChuyenBoNhiemList);
            //KhoiTao(Loai);
            //_Loai = Loai;

            //tlslblThem.Enabled = false;
            //tlslblLuu.Enabled = false;
            //tlslblXoa.Enabled = false;
            //tlslblUndo.Enabled = false;

            //tlslblIn.Visible = false;
            //toolStripButton1.Visible = false;

        }
        public void ShowDieuChuyenNoBo()
        {
             
            chucVuListBindingSource.DataSource = typeof(ChucVuList);
            tenNhanVienListBindingSource.DataSource = typeof(TenNhanVienList);
            phongBanListBindingSource.DataSource = typeof(BoPhanList);
            bdNhanVien.DataSource = typeof(TenNhanVienList);
            bdBacBHCu.DataSource = typeof(BacLuongCoBanList);
            bdBacBHMoi.DataSource = typeof(BacLuongCoBanList);
            bdBacLuongCu.DataSource = typeof(BacLuongCoBanList);
            bdBacMoi.DataSource = typeof(BacLuongCoBanList);
            bdNhomNgach.DataSource = typeof(NhomNgachLuongCoBanList);
            bdNhomNgachBH.DataSource = typeof(NhomNgachLuongCoBanList);
            bdNgachBHCu.DataSource = typeof(NgachLuongCoBanList);
            bdNgachBHMoi.DataSource = typeof(NgachLuongCoBanList);
            bdNgachCu.DataSource = typeof(NgachLuongCoBanList);
            bdNgachMoi.DataSource = typeof(NgachLuongCoBanList);
            bdQuaTrinhLuanChuyenBoNhiem.DataSource = typeof(QuaTrinhLuanChuyenBoNhiemList);
            bdQuaTrinhLuanChuyenList.DataSource = typeof(QuaTrinhLuanChuyenBoNhiemList);
            KhoiTao(0);
            _Loai = 0;
            tabPageLuanChuyenDieuChuyen.Text = "Điều Chuyển Nhân Viên";
            tabPage2.Text = "Danh Sách Điều Chuyển";
            tabPage1.Text = "Điều Chuyển Tập Thể";
            checkBox_Loai.Checked = false;
            checkBox_Loai.Text = "Điều Chuyển NB";

            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblXoa.Enabled = false;
            tlslblUndo.Enabled = false;

            tlslblIn.Visible = false;
            toolStripButton1.Visible = false;
            this.Text = "Điều Chuyển Nội Bộ";
            this.Show();
        }
        public void ShowBoNhiem()
        {
           
            chucVuListBindingSource.DataSource = typeof(ChucVuList);
            tenNhanVienListBindingSource.DataSource = typeof(TenNhanVienList);
            phongBanListBindingSource.DataSource = typeof(BoPhanList);
            bdNhanVien.DataSource = typeof(TenNhanVienList);
            bdBacBHCu.DataSource = typeof(BacLuongCoBanList);
            bdBacBHMoi.DataSource = typeof(BacLuongCoBanList);
            bdBacLuongCu.DataSource = typeof(BacLuongCoBanList);
            bdBacMoi.DataSource = typeof(BacLuongCoBanList);
            bdNhomNgach.DataSource = typeof(NhomNgachLuongCoBanList);
            bdNhomNgachBH.DataSource = typeof(NhomNgachLuongCoBanList);
            bdNgachBHCu.DataSource = typeof(NgachLuongCoBanList);
            bdNgachBHMoi.DataSource = typeof(NgachLuongCoBanList);
            bdNgachCu.DataSource = typeof(NgachLuongCoBanList);
            bdNgachMoi.DataSource = typeof(NgachLuongCoBanList);
            bdQuaTrinhLuanChuyenBoNhiem.DataSource = typeof(QuaTrinhLuanChuyenBoNhiemList);
            bdQuaTrinhLuanChuyenList.DataSource = typeof(QuaTrinhLuanChuyenBoNhiemList);
            KhoiTao(1);
            _Loai = 1;
            tabPageLuanChuyenDieuChuyen.Text = "Bổ Nhiệm Nhân Viên";
            tabPage2.Text = "Danh Sách Bổ Nhiệm";
            tabPage1.Text = "Bổ Nhiệm Tập Thể";
            checkBox_Loai.Checked = true;
            checkBox_Loai.Text = "Bổ Nhiệm";
            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblXoa.Enabled = false;
            tlslblUndo.Enabled = false;

            tlslblIn.Visible = false;
            toolStripButton1.Visible = false;
            this.Text = "Bổ Nhiệm Nhân Viên";
            this.Show();
        }

        public frmLuanChuyenDieuChuyenCB(ThongTinNhanVienTongHop thongTinNhanVienTongHop)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;

            //MaDonViCu = Convert.ToInt32(NhanVien.GetNhanVien(_ThongTinNhanVienTongHop.MaNhanVien).MaChiNhanh);
            //MaPhongBanCu = Convert.ToInt32(_ThongTinNhanVienTongHop.MaPhongBan);
            //MaChucDanhCu = Convert.ToInt32(_ThongTinNhanVienTongHop.MaChucDanh);
            //MaChucVuCu = Convert.ToInt32(_ThongTinNhanVienTongHop.MaChucVu);
            //MaDonViChuyenMonCu = TrinhDoList.GetTrinhDoList(_ThongTinNhanVienTongHop.MaNhanVien)[0].MaChuyenMonNghiepVu;

            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblXoa.Enabled = false;
            tlslblUndo.Enabled = false;

            tlslblIn.Visible = false;
            toolStripButton1.Visible = false;
        }
        #endregion

        #region KhoiTao
        public void KhoiTao(int Loai)
        {
            this.tlsMain.Enabled = true;
            dateDenNgay.Value = DateTime.Now.Date;
            dateTuNgay.Value = DateTime.Now.Date;
            checkBox1.Checked = false;
            _ChucVuList = ChucVuList.GetChucVuListAll();
            chucVuListBindingSource.DataSource = _ChucVuList;

            _ChucDanhList = ChucDanhList.GetChucDanhList();
          //  ChucDanh_BindingSource.DataSource = _ChucDanhList;

            _ChuyenMonNghiepVuClassList = ChuyenMonNghiepVuClassList.GetChuyenMonNghiepVuClassList();
           // chuyenMonNghiepVuClassListBindingSource.DataSource = _ChuyenMonNghiepVuClassList;

            _CongTyList = CongTyList.GetCongTyList();
           // congTyListBindingSource.DataSource = _CongTyList;

            _PhongBanList = BoPhanList.GetBoPhanList();
            phongBanListBindingSource.DataSource = _PhongBanList;

            _TenNhanVienList = TenNhanVienList.GetTenNhanVienList();
            tenNhanVienListBindingSource.DataSource = _TenNhanVienList;

            _LoaiQuyetDinhList = LoaiQuyetDinhList.GetLoaiQuyetDinhList();
          //  loaiQuyetDinhListBindingSource.DataSource = _LoaiQuyetDinhList;

            _QuaTrinhLuanChuyenBoNhiemList = QuaTrinhLuanChuyenBoNhiemList.GetQuaTrinhLuanChuyenBoNhiemList(0, Loai);
            bdQuaTrinhLuanChuyenBoNhiem.DataSource = _QuaTrinhLuanChuyenBoNhiemList;

             nhomNgachList = NhomNgachLuongCoBanList.GetNhomNgachLuongCoBanListAll();
             nhomNgachBHList = nhomNgachList;
             ngachBaoHiemCuList = NgachLuongCoBanList.GetNgachLuongCoBanList();
             ngachBaoHiemMoiList = ngachBaoHiemCuList;
             ngachCoBanCuList = ngachBaoHiemCuList;
             ngachCoBanMoiList = ngachCoBanCuList;
             bacBaoHiemCuList = BacLuongCoBanList.GetBacLuongCoBanListAll();
             bacBaoHiemMoiList = bacBaoHiemCuList;
             bacCoBanCuList = bacBaoHiemCuList;
             bacCoBanMoiList = bacBaoHiemCuList;

             bdBacBHCu.DataSource = bacBaoHiemCuList;
             bdBacBHMoi.DataSource = bacBaoHiemMoiList;
             bdBacLuongCu.DataSource = bacCoBanCuList;
             bdBacMoi.DataSource = bacCoBanMoiList;
             bdNhomNgach.DataSource = nhomNgachList;
             bdNhomNgachBH.DataSource = nhomNgachBHList;
             bdNgachBHCu.DataSource = ngachBaoHiemCuList;
             bdNgachBHMoi.DataSource = ngachBaoHiemMoiList;
             bdNgachCu.DataSource = ngachCoBanCuList;
             bdNgachMoi.DataSource = ngachCoBanMoiList;

        }

        private void LayDuLieu(int Loai)
        {
            _QuaTrinhLuanChuyenBoNhiemList = QuaTrinhLuanChuyenBoNhiemList.GetQuaTrinhLuanChuyenBoNhiemList(_ThongTinNhanVienTongHop.MaNhanVien, Loai);
            bdQuaTrinhLuanChuyenBoNhiem.DataSource = _QuaTrinhLuanChuyenBoNhiemList;

            _BoNhiemList = BoNhiemList.GetBoNhiemList(_ThongTinNhanVienTongHop.MaNhanVien);
           // boNhiemListBindingSource.DataSource = _BoNhiemList;
        }

        #endregion

        private bool KiemTra_Luoi_LuanChuyen()
        {
            bool kq = true;
            for (int i = 0; i < grdu_LuanChuyen.Rows.Count; i++)
            {
                if (grdu_LuanChuyen.Rows[i].Cells["SoQuyetDinh"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Nhập Số Quyết Định", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_LuanChuyen.ActiveRow = grdu_LuanChuyen.Rows[i];
                    return kq;
                }
                if (grdu_LuanChuyen.Rows[i].Cells["MaDonViMoi"].Text == "0")
                {
                    kq = false;
                    MessageBox.Show(this, "Chọn Đơn Vị Mới", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_LuanChuyen.ActiveRow = grdu_LuanChuyen.Rows[i];
                    return kq;
                }
                if (grdu_LuanChuyen.Rows[i].Cells["MaPhongBanMoi"].Text == "0")
                {
                    kq = false;
                    MessageBox.Show(this, "Chọn Phòng Ban Mới", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_LuanChuyen.ActiveRow = grdu_LuanChuyen.Rows[i];
                    return kq;
                }
                if (grdu_LuanChuyen.Rows[i].Cells["MaChucDanhMoi"].Text == "0")
                {
                    kq = false;
                    MessageBox.Show(this, "Chọn Chức Danh Mới", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_LuanChuyen.ActiveRow = grdu_LuanChuyen.Rows[i];
                    return kq;
                }
                if (grdu_LuanChuyen.Rows[i].Cells["MaChucVuMoi"].Text == "0")
                {
                    kq = false;
                    MessageBox.Show(this, "Chọn Chức Vụ Mới", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_LuanChuyen.ActiveRow = grdu_LuanChuyen.Rows[i];
                    return kq;
                }
                if (grdu_LuanChuyen.Rows[i].Cells["MaChuyenMonNghiepVuMoi"].Text == "0")
                {
                    kq = false;
                    MessageBox.Show(this, "Chọn Chuyên Môn Nghiệp Vụ Mới", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_LuanChuyen.ActiveRow = grdu_LuanChuyen.Rows[i];
                    return kq;
                }
            }
            return kq;
        }
        /*
        private bool KiemTra_Luoi_BoNhiem()
        {
            bool kq = true;
            for (int i = 0; i < grdu_BoNhiem.Rows.Count; i++)
            {
                if (grdu_BoNhiem.Rows[i].Cells["SoQuyetDinh"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Nhập Số Quyết Định", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_BoNhiem.ActiveRow = grdu_BoNhiem.Rows[i];
                    return kq;
                }
                if (grdu_BoNhiem.Rows[i].Cells["MaChucDanhMoi"].Text == "0")
                {
                    kq = false;
                    MessageBox.Show(this, "Chọn Chức Danh Mới", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_BoNhiem.ActiveRow = grdu_BoNhiem.Rows[i];
                    return kq;
                }
                if (grdu_BoNhiem.Rows[i].Cells["MaChucVuMoi"].Text == "0")
                {
                    kq = false;
                    MessageBox.Show(this, "Chọn Chức Vụ Mới", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_BoNhiem.ActiveRow = grdu_BoNhiem.Rows[i];
                    return kq;
                }
            }
            return kq;
        }
        */
        private Boolean KiemTraMaQuanLy_LuanChuyen()
        {
            for (int i = 0; i < _QuaTrinhLuanChuyenBoNhiemList.Count; i++)
            {
                for (int j = 0; j < _QuaTrinhLuanChuyenBoNhiemList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_QuaTrinhLuanChuyenBoNhiemList[i].SoQuyetDinh.Trim() == _QuaTrinhLuanChuyenBoNhiemList[j].SoQuyetDinh.Trim())
                        {
                            QuaTrinhLuanChuyenBoNhiem qg = QuaTrinhLuanChuyenBoNhiem.GetQuaTrinhLuanChuyenBoNhiem(_QuaTrinhLuanChuyenBoNhiemList[i].MactQuatrinhluanchuyen);
                            MessageBox.Show(this, "Số Quyết Định " + qg.SoQuyetDinh.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_LuanChuyen.ActiveRow = grdu_LuanChuyen.Rows[i + 1];
                            grdu_LuanChuyen.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private Boolean KiemTraMaQuanLy_BoNhiem()
        {
            for (int i = 0; i < _BoNhiemList.Count; i++)
            {
                for (int j = 0; j < _BoNhiemList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_BoNhiemList[i].SoQuyetDinh.Trim() == _BoNhiemList[j].SoQuyetDinh.Trim())
                        {
                            BoNhiem qg = BoNhiem.GetBoNhiem(_BoNhiemList[i].MaBoNhiem);
                            MessageBox.Show(this, "Số Quyết Định " + qg.SoQuyetDinh.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_BoNhiem.ActiveRow = grdu_BoNhiem.Rows[i + 1];
                            grdu_BoNhiem.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            
                this.Close();
            
        }
        #endregion

        #region InitializeLayout

        #region grdu_LuanChuyen_InitializeLayout
        private void grdu_LuanChuyen_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in grdu_LuanChuyen.DisplayLayout.Bands[0].Columns)
            {
                if(col.DataType==typeof(DateTime))
                {
                    col.Format = "dd/MM/yyyy";
                }
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Hidden = false;
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.Caption = "Số QĐ";
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.VisiblePosition = 0;

            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["NguoiCapQuyetDinh"].Hidden = false;
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["NguoiCapQuyetDinh"].Header.Caption = "Người Ký";
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["NguoiCapQuyetDinh"].Header.VisiblePosition = 1;

            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["CapQuyetDinh"].Hidden = false;
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["CapQuyetDinh"].Header.Caption = "Chức Vụ";
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["CapQuyetDinh"].Header.VisiblePosition = 2;

            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["NgayKy"].Hidden = false;
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["NgayKy"].Header.Caption = "Ngày Ký";
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["NgayKy"].Header.VisiblePosition = 3;

            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Hidden = false;
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.Caption = "Ngày Hiệu Lực";
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.VisiblePosition = 4;

            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["NgayHuongMucMoi"].Hidden = false;
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["NgayHuongMucMoi"].Header.Caption = "Ngày Mức Mới";
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["NgayHuongMucMoi"].Header.VisiblePosition = 5;
        }
        #endregion
        
        #region cmbu_PhongBanMoi_InitializeLayout
         #endregion

        #region cmbu_ChucVuMoi_InitializeLayout
        private void cmbu_ChucVuMoi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cmbu_ChucVuMoi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_ChucVuMoi.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            cmbu_ChucVuMoi.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            cmbu_ChucVuMoi.DisplayLayout.Bands[0].Columns["TenChucVu"].Width = 240;           
            //this.cmbu_ChucVuMoi.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.cmbu_ChucVuMoi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

     
        #region cmbu_Loai_InitializeLayout
         #endregion

        #region grdu_BoNhiem_InitializeLayout
        private void grdu_BoNhiem_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_BoNhiem.DisplayLayout.Bands[0].Columns["MaBoNhiem"].Hidden = true;
            grdu_BoNhiem.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_BoNhiem.DisplayLayout.Bands[0].Columns["QuyetDinh"].Hidden = true;
            grdu_BoNhiem.DisplayLayout.Bands[0].Columns["NguoiKy"].Hidden = true;
            grdu_BoNhiem.DisplayLayout.Bands[0].Columns["NguoiLap"].Hidden = true;
            grdu_BoNhiem.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = true;

            //grdu_BoNhiem.DisplayLayout.Bands[0].Columns["MaChucDanhMoi"].Header.Caption = "Chức Danh Mới";
            //grdu_BoNhiem.DisplayLayout.Bands[0].Columns["MaChucDanhMoi"].EditorComponent = cmbu_ChucDanhMoiBN;
            //grdu_BoNhiem.DisplayLayout.Bands[0].Columns["MaChucVuMoi"].Header.Caption = "Chức Vụ Mới";
            //grdu_BoNhiem.DisplayLayout.Bands[0].Columns["MaChucVuMoi"].EditorComponent = cmbu_ChucVuMoiBN;
            //grdu_BoNhiem.DisplayLayout.Bands[0].Columns["MaChuyenMonNVMoi"].Header.Caption = "Chuyên Môn Nghiệp Vụ Mới";
            //grdu_BoNhiem.DisplayLayout.Bands[0].Columns["MaChuyenMonNVMoi"].EditorComponent = cmbu_ChuyenMonNVBN;
            //grdu_BoNhiem.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.Caption = "Số Quyết Định";
            //grdu_BoNhiem.DisplayLayout.Bands[0].Columns["NgayKy"].Header.Caption = "Ngày Ký";
            //grdu_BoNhiem.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.Caption = "Ngày Hiệu Lực";
            //grdu_BoNhiem.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";

            grdu_BoNhiem.DisplayLayout.Bands[0].Columns["MaChucDanhMoi"].Header.VisiblePosition = 0;
            grdu_BoNhiem.DisplayLayout.Bands[0].Columns["MaChucVuMoi"].Header.VisiblePosition = 1;
            grdu_BoNhiem.DisplayLayout.Bands[0].Columns["MaChuyenMonNVMoi"].Header.VisiblePosition = 2;
            grdu_BoNhiem.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.VisiblePosition = 3;
            grdu_BoNhiem.DisplayLayout.Bands[0].Columns["NgayKy"].Header.VisiblePosition = 4;
            grdu_BoNhiem.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.VisiblePosition = 5;
            grdu_BoNhiem.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 6;

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_BoNhiem.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
            //màu nền
            //this.grdu_BoNhiem.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.grdu_BoNhiem.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region cmbu_ChucDanhMoiBN_InitializeLayout
         #endregion

        #region cmbu_ChucVuMoiBN_InitializeLayout
         #endregion

 
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            New();
        }
        private void New()
        {
           
            if (tab_Chung.SelectedTab.Name == "tabPageLuanChuyenDieuChuyen")
            {
                if (_QuaTrinhLuanChuyenBoNhiemList.Count != 0)
                { 
                    foreach( QuaTrinhLuanChuyenBoNhiem qt in _QuaTrinhLuanChuyenBoNhiemList)
                    {
                        if(qt.SoQuyetDinh=="" || qt.SoQuyetDinh== null)
                        {
                               MessageBox.Show(this, "Số Quyết Định Không Được Để Trống " , "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                               return;
                        }
                    }
                }
                _QuaTrinhLuanChuyenBoNhiem = QuaTrinhLuanChuyenBoNhiem.NewQuaTrinhLuanChuyenBoNhiem();
                _QuaTrinhLuanChuyenBoNhiem.MaNhanVien = _nhanVien.MaNhanVien;
                _QuaTrinhLuanChuyenBoNhiem.TenNhanVien = _nhanVien.TenNhanVien;
                _QuaTrinhLuanChuyenBoNhiem.MaBoPhanCu = _nhanVien.MaBoPhan;
                _QuaTrinhLuanChuyenBoNhiem.TenBoPhanCu = _nhanVien.TenBoPhan;
                _QuaTrinhLuanChuyenBoNhiem.MaChucVuCu = _nhanVien.MaChucVu;
                _QuaTrinhLuanChuyenBoNhiem.TenChucVuCu = _nhanVien.TenChucVu;
                _QuaTrinhLuanChuyenBoNhiem.HeSoBHCu = _nhanVien.HeSoLuongBaoHiem;
                _QuaTrinhLuanChuyenBoNhiem.HeSoBoSungCu = _nhanVien.HeSoLuongBoSung;
                _QuaTrinhLuanChuyenBoNhiem.HeSoBuCu = _nhanVien.HeSoBu;
                _QuaTrinhLuanChuyenBoNhiem.HeSoDocHaiCu = _nhanVien.HeSoDocHai;
                _QuaTrinhLuanChuyenBoNhiem.HeSoLuongCu = _nhanVien.HeSoLuong;
                _QuaTrinhLuanChuyenBoNhiem.HeSoNoiBoCu = _nhanVien.HeSoLuongNoiBo;
                _QuaTrinhLuanChuyenBoNhiem.HeSoPhuCapCu = _nhanVien.HeSoPhuCapChucVu;
                _QuaTrinhLuanChuyenBoNhiem.HSVKBHCu = _nhanVien.HeSoVuotKhungBH;
                _QuaTrinhLuanChuyenBoNhiem.HSVKCu = _nhanVien.HeSoVuotKhung;
                _QuaTrinhLuanChuyenBoNhiem.MaBacBHCu = _nhanVien.MaBacLuongBaoHiem;
                _QuaTrinhLuanChuyenBoNhiem.MaBacLuongCu = _nhanVien.MaBacLuongCoBan;
                _QuaTrinhLuanChuyenBoNhiem.MaNgachBHCu = _nhanVien.MaNgachLuongBaoHiem;
                _QuaTrinhLuanChuyenBoNhiem.MaNgachLuongCu = _nhanVien.MaNgachLuongCoBan;                

                //Thông tin mới
                _QuaTrinhLuanChuyenBoNhiem.MaNhomNgachBHMoi = _nhanVien.MaNhomNgachLuongBaoHiem;
                _QuaTrinhLuanChuyenBoNhiem.MaNhomNgachMoi = _nhanVien.MaNhomNgachLuongCB;
                _QuaTrinhLuanChuyenBoNhiem.MaBoPhanMoi = _nhanVien.MaBoPhan;
                _QuaTrinhLuanChuyenBoNhiem.TenBoPhanMoi = _nhanVien.TenBoPhan;                
                _QuaTrinhLuanChuyenBoNhiem.MaChucVuMoi = _nhanVien.MaChucVu;
                _QuaTrinhLuanChuyenBoNhiem.TenChucVuMoi = _nhanVien.TenChucVu;
                _QuaTrinhLuanChuyenBoNhiem.HeSoBHMoi = _nhanVien.HeSoLuongBaoHiem;
                _QuaTrinhLuanChuyenBoNhiem.HeSoBoSungMoi = _nhanVien.HeSoLuongBoSung;
                _QuaTrinhLuanChuyenBoNhiem.HeSoBuMoi = _nhanVien.HeSoBu;
                _QuaTrinhLuanChuyenBoNhiem.HeSoDocHaiMoi = _nhanVien.HeSoDocHai;
                _QuaTrinhLuanChuyenBoNhiem.HeSoLuongMoi = _nhanVien.HeSoLuong;
                _QuaTrinhLuanChuyenBoNhiem.HeSoNoiBoMoi = _nhanVien.HeSoLuongNoiBo;
                _QuaTrinhLuanChuyenBoNhiem.HeSoPhuCapMoi = _nhanVien.HeSoPhuCapChucVu;
                _QuaTrinhLuanChuyenBoNhiem.HSVKBHMoi = _nhanVien.HeSoVuotKhungBH;
                _QuaTrinhLuanChuyenBoNhiem.HSVKMoi = _nhanVien.HeSoVuotKhung;
                _QuaTrinhLuanChuyenBoNhiem.MaBacBHMoi = _nhanVien.MaBacLuongBaoHiem;
                _QuaTrinhLuanChuyenBoNhiem.MaBacLuongMoi = _nhanVien.MaBacLuongCoBan;
                _QuaTrinhLuanChuyenBoNhiem.MaNgachBHMoi = _nhanVien.MaNgachLuongBaoHiem;
                _QuaTrinhLuanChuyenBoNhiem.MaNgachLuongMoi = _nhanVien.MaNgachLuongCoBan;
                

                _QuaTrinhLuanChuyenBoNhiem.NgayLap = DateTime.Today.Date;
                _QuaTrinhLuanChuyenBoNhiem.MaNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;

                _QuaTrinhLuanChuyenBoNhiem.MaLoaiQuyetDinh = _Loai;
                _QuaTrinhLuanChuyenBoNhiemList.Add(_QuaTrinhLuanChuyenBoNhiem);
                bdQuaTrinhLuanChuyenBoNhiem.DataSource = _QuaTrinhLuanChuyenBoNhiemList;
                grdu_LuanChuyen.ActiveRow = grdu_LuanChuyen.Rows[_QuaTrinhLuanChuyenBoNhiemList.Count - 1];

               
            }
           
        }
        #endregion

        #region tlslblLuu_Click
        private void Save() 
        {
            try
            {
                if (_QuaTrinhLuanChuyenBoNhiemList != null)
                {

                    for (int i = 0; i < _QuaTrinhLuanChuyenBoNhiemList.Count; i++)
                    {
                        if (_QuaTrinhLuanChuyenBoNhiemList[i].SoQuyetDinh == "")
                        {
                            MessageBox.Show("Chưa nhập số quyết định", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (_QuaTrinhLuanChuyenBoNhiemList[i].MaChucVuMoi==0)
                        {
                            MessageBox.Show("Chưa nhập chức vụ mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (_QuaTrinhLuanChuyenBoNhiemList[i].MaBoPhanMoi == 0)
                        {
                            MessageBox.Show("Chưa nhập bộ phận mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                       
                    }
                    grdu_LuanChuyen.UpdateData();
                   
                    _QuaTrinhLuanChuyenBoNhiemList.ApplyEdit();
                    _QuaTrinhLuanChuyenBoNhiemList.Save();

                    _QuaTrinhLuanChuyenBoNhiemList = QuaTrinhLuanChuyenBoNhiemList.GetQuaTrinhLuanChuyenBoNhiemList(MaNhanVien,_Loai);       
                    int soQuyetDinh = QuaTrinhLuanChuyenBoNhiem.KiemTraNgayHieuLucMax(MaNhanVien);

                    for (int i = 0; i < _QuaTrinhLuanChuyenBoNhiemList.Count; i++)
                    {
                        if (_QuaTrinhLuanChuyenBoNhiemList[i].MactQuatrinhluanchuyen == soQuyetDinh)
                        {
                            if (checkBox1.Checked == true)
                            {

                                _nhanVien.MaBoPhan = _QuaTrinhLuanChuyenBoNhiemList[i].MaBoPhanMoi;
                                _nhanVien.TenBoPhan = _QuaTrinhLuanChuyenBoNhiemList[i].TenBoPhanMoi;
                                _nhanVien.MaChucVu = _QuaTrinhLuanChuyenBoNhiemList[i].MaChucVuMoi;
                                _nhanVien.TenChucVu = _QuaTrinhLuanChuyenBoNhiemList[i].TenChucVuMoi;
                                _nhanVien.MaNhomNgachLuongBaoHiem = _QuaTrinhLuanChuyenBoNhiemList[i].MaNhomNgachBHMoi;
                                _nhanVien.MaNhomNgachLuongCB = _QuaTrinhLuanChuyenBoNhiemList[i].MaNhomNgachMoi;
                                _nhanVien.HeSoLuongBaoHiem = _QuaTrinhLuanChuyenBoNhiemList[i].HeSoBHMoi;
                                _nhanVien.HeSoLuongBoSung = _QuaTrinhLuanChuyenBoNhiemList[i].HeSoBoSungMoi;
                                _nhanVien.HeSoBu = _QuaTrinhLuanChuyenBoNhiemList[i].HeSoBuMoi;
                                _nhanVien.HeSoDocHai = _QuaTrinhLuanChuyenBoNhiemList[i].HeSoDocHaiMoi;
                                _nhanVien.HeSoLuong = _QuaTrinhLuanChuyenBoNhiemList[i].HeSoLuongMoi;
                                _nhanVien.HeSoLuongNoiBo = _QuaTrinhLuanChuyenBoNhiemList[i].HeSoNoiBoMoi;
                                _nhanVien.HeSoPhuCapChucVu = _QuaTrinhLuanChuyenBoNhiemList[i].HeSoPhuCapMoi;
                                _nhanVien.HeSoVuotKhungBH = _QuaTrinhLuanChuyenBoNhiemList[i].HSVKBHMoi;
                                _nhanVien.HeSoVuotKhung = _QuaTrinhLuanChuyenBoNhiemList[i].HSVKMoi;
                                _nhanVien.MaBacLuongBaoHiem = _QuaTrinhLuanChuyenBoNhiemList[i].MaBacBHMoi;
                                _nhanVien.MaBacLuongCoBan = _QuaTrinhLuanChuyenBoNhiemList[i].MaBacLuongMoi;
                                _nhanVien.MaNgachLuongBaoHiem = _QuaTrinhLuanChuyenBoNhiemList[i].MaNgachBHMoi;
                                _nhanVien.MaNgachLuongCoBan = _QuaTrinhLuanChuyenBoNhiemList[i].MaNgachLuongMoi;
                                _nhanVien.NgayTinhThamNien = _QuaTrinhLuanChuyenBoNhiemList[i].NgayHieuLuc;


                            }
                        }
                    }
                    
                    _nhanVien.ApplyEdit();
                    _nhanVien.Save(true);
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }

        private bool KiemTra_Luoi_BoNhiem()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (tab_Chung.SelectedTab.Name == "tabPageLuanChuyenDieuChuyen")
            {
                grdu_LuanChuyen.DeleteSelectedRows();
            }
            else if (tab_Chung.SelectedTab.Name == "tabPageBoNhiemMienNhiem")
            {
                grdu_BoNhiem.DeleteSelectedRows();
            }
        }
        #endregion

        #region tlslblUndo_Click
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            KhoiTao(_Loai);
        }
        #endregion

        #region tlslblTim_Click
        private void Find(int Loai)
        {
            checkBox1.Checked = false;
            _QuaTrinhLuanChuyenBoNhiemList = QuaTrinhLuanChuyenBoNhiemList.NewQuaTrinhLuanChuyenBoNhiemList();
            frmTimNhanVien _frmTimNhanVien = new frmTimNhanVien(19);
            if (_frmTimNhanVien.ShowDialog(this) != DialogResult.OK)
            {

                if (frmTimNhanVien.MaNhanVien != 0)
                {
                    MaNhanVien = frmTimNhanVien.MaNhanVien;
                    _nhanVien = NhanVien.GetNhanVien(MaNhanVien);
                    _QuaTrinhLuanChuyenBoNhiemList = QuaTrinhLuanChuyenBoNhiemList.GetQuaTrinhLuanChuyenBoNhiemList(MaNhanVien, Loai);
                    bdQuaTrinhLuanChuyenBoNhiem.DataSource = _QuaTrinhLuanChuyenBoNhiemList;

                    //_BoNhiemList = BoNhiemList.GetBoNhiemList(MaNhanVien);


                    txtu_TenNhanVien.Text = _nhanVien.TenNhanVien;
                    txtu_MaNhanVienQL.Text = _nhanVien.MaQLNhanVien;

                    //LayDuLieuLenTextbox();

                    tlslblThem.Enabled = true;
                    tlslblLuu.Enabled = true;
                    tlslblXoa.Enabled = true;
                    tlslblUndo.Enabled = true;
                }
            }
        }
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            Find(_Loai);
        }
        #endregion

        private void cmbu_PXBoPhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_PXBoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_PXBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden=false;
            cmbu_PXBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;
            cmbu_PXBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption ="Mã Bộ Phận";
            cmbu_PXBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_PXBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_PXBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 1;
            
        }

        private void cmbu_PXBoPhan_ValueChanged(object sender, EventArgs e)
        {
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                lbCheck.Text = "Quyết định mới sẽ làm ảnh hưởng thông tin hiện tại của Nhân Viên";
            else
                lbCheck.Text = "";
        }

        private void ultraCombo1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbBoPhanCu.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbBoPhanCu.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cbBoPhanCu.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;
            cbBoPhanCu.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cbBoPhanCu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbBoPhanCu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cbBoPhanCu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 1;
        }

        private void ultraCombo2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbChucVuCu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cbChucVuCu.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            cbChucVuCu.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            cbChucVuCu.DisplayLayout.Bands[0].Columns["TenChucVu"].Width = 240;           
        }

        private void ultraCombo5_ValueChanged(object sender, EventArgs e)
        {
            if (ultraCombo5.ActiveRow != null)
            {
                _TenNhanVienHangLoatList = TenNhanVienList.GetTenNhanVienList_BoPhan((int)ultraCombo5.Value);
                this.bdNhanVien.DataSource = _TenNhanVienHangLoatList;
            }
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Check";

            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 1;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";

            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 2;

            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 3;

            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 4;
        }

        private void btDieuChuyen_Click(object sender, EventArgs e)
        {
            if (maBoPhanMoi == 0)
            {
                MessageBox.Show("Chưa chọn đơn vị chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbSoQDHL.Text=="")
            {
                MessageBox.Show("Chưa nhập số quyết định", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            QuaTrinhLuanChuyenBoNhiem _quaTrinh;
            QuaTrinhLuanChuyenBoNhiemList _quaTrinhList=QuaTrinhLuanChuyenBoNhiemList.NewQuaTrinhLuanChuyenBoNhiemList();
              DialogResult _DialogResult = MessageBox.Show("Bạn Có Đồng Điều Chuyển Các Nhân Nhân Viên Đã Chọn?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
              if (_DialogResult == DialogResult.Yes)
              {
                  for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                  {
                      if ((bool)ultraGrid1.Rows[i].Cells["Check"].Value == true)
                      {
                          long maNhanVien = (long)ultraGrid1.Rows[i].Cells["MaNhanVien"].Value;
                          int maBoPhanCu = (int)ultraGrid1.Rows[i].Cells["MaBoPhan"].Value;
                          int maChucVuCu = (int)ultraGrid1.Rows[i].Cells["MaChucVu"].Value;
                          _quaTrinh = QuaTrinhLuanChuyenBoNhiem.NewQuaTrinhLuanChuyenBoNhiem();
                          _quaTrinh.MaBoPhanCu = maBoPhanCu;
                          _quaTrinh.MaChucVuCu = maChucVuCu;
                          _quaTrinh.MaChucVuMoi = maChucVuCu;
                          _quaTrinh.MaNhanVien = maNhanVien;
                          _quaTrinh.CapQuyetDinh = tbCapQDHL.Text;
                          _quaTrinh.GhiChu = tbGhiChu.Text;
                          _quaTrinh.MaLoaiQuyetDinh = 0;
                          _quaTrinh.MaNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                          _quaTrinh.NgayHieuLuc = Convert.ToDateTime(dateNgayHLHL.Value).Date;
                          _quaTrinh.NgayKy = Convert.ToDateTime(dateNgayKyHL.Value).Date;
                          _quaTrinh.NgayLap = DateTime.Today.Date;
                          _quaTrinh.NguoiCapQuyetDinh = tbNguoiQuyetDinhHL.Text;
                          _quaTrinh.SoQuyetDinh = tbSoQDHL.Text;
                          _quaTrinh.MaBoPhanMoi = maBoPhanMoi;
                          _quaTrinh.Save(true);
                          NhanVien nv = NhanVien.GetNhanVien(maNhanVien);
                          nv.MaBoPhan = maBoPhanMoi;
                          nv.TenBoPhan = _quaTrinh.TenBoPhanMoi;
                          nv.Save(true);
                      }
                  }
              }
        }

        private void cbBoPhanMoi_ValueChanged(object sender, EventArgs e)
        {
            if (cbBoPhanMoi.ActiveRow != null)
            {
                maBoPhanMoi = (int)cbBoPhanMoi.Value;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                {
                    if (!ultraGrid1.Rows[i].Hidden == true && ultraGrid1.Rows[i].IsFilteredOut == false)
                    {
                        ultraGrid1.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                {
                    ultraGrid1.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void ultraCombo5_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.ultraCombo5.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            ultraCombo5.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            ultraCombo5.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;
            ultraCombo5.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            ultraCombo5.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraCombo5.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            ultraCombo5.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 1;
        }

        private void cbBoPhanMoi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbBoPhanMoi.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbBoPhanMoi.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cbBoPhanMoi.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;
            cbBoPhanMoi.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cbBoPhanMoi.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbBoPhanMoi.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cbBoPhanMoi.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 1;
        }

       
        private void DateChanged()
        {
            QuaTrinhLuanChuyenBoNhiemList _list = QuaTrinhLuanChuyenBoNhiemList.GetQuaTrinhLuanChuyenBoNhiemList(Convert.ToDateTime(dateTuNgay.Value).Date, Convert.ToDateTime(dateDenNgay.Value).Date, _Loai);
            this.bdQuaTrinhLuanChuyenList.DataSource = _list;
        }

        private void ultraDateTimeEditor4_ValueChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void ultraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;

            foreach (UltraGridColumn col in this.ultraGrid2.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            ultraGrid2.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraGrid2.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ultraGrid2.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;

            ultraGrid2.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Hidden = false;
            ultraGrid2.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.VisiblePosition = 1;
            ultraGrid2.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.Caption = "Số Quyết Định";
          
            ultraGrid2.DisplayLayout.Bands[0].Columns["CapQuyetDinh"].Hidden = false;
            ultraGrid2.DisplayLayout.Bands[0].Columns["CapQuyetDinh"].Header.Caption = "Cấp Quyết Định";
            ultraGrid2.DisplayLayout.Bands[0].Columns["CapQuyetDinh"].Header.VisiblePosition = 2;

            ultraGrid2.DisplayLayout.Bands[0].Columns["NguoiCapQuyetDinh"].Hidden = false;
            ultraGrid2.DisplayLayout.Bands[0].Columns["NguoiCapQuyetDinh"].Header.Caption = "Người Cấp QĐ";
            ultraGrid2.DisplayLayout.Bands[0].Columns["NguoiCapQuyetDinh"].Header.VisiblePosition = 3;

            ultraGrid2.DisplayLayout.Bands[0].Columns["TenBoPhanMoi"].Hidden = false;
            ultraGrid2.DisplayLayout.Bands[0].Columns["TenBoPhanMoi"].Header.Caption = "Đơn Vị Mới";
            ultraGrid2.DisplayLayout.Bands[0].Columns["TenBoPhanMoi"].Header.VisiblePosition = 4;

            ultraGrid2.DisplayLayout.Bands[0].Columns["NgayKy"].Hidden = false;
            ultraGrid2.DisplayLayout.Bands[0].Columns["NgayKy"].Header.Caption = "Ngày Ký";
            ultraGrid2.DisplayLayout.Bands[0].Columns["NgayKy"].Header.VisiblePosition = 5;
            ultraGrid2.DisplayLayout.Bands[0].Columns["NgayKy"].Format = "dd/MM/yyyy";

            ultraGrid2.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Hidden = false;
            ultraGrid2.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.Caption = "Ngày Hiệu Lực";
            ultraGrid2.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.VisiblePosition = 6;
            ultraGrid2.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Format = "dd/MM/yyyy";
        }

        private void tab_Chung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_Chung.SelectedTab.Name == "tabPageLuanChuyenDieuChuyen")
            {
                this.tlsMain.Enabled = true;
            }
            else
                this.tlsMain.Enabled = false;
        }

        private void frmLuanChuyenDieuChuyenCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {

                Save();

            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                New();
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                Find(_Loai);
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                LayDuLieu(_Loai);
            }
        }

        private void cbNgachCu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in cbNgachCu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            cbNgachCu.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Hidden = false;
            cbNgachCu.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.Caption = "Tên Ngạch";
            cbNgachCu.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.VisiblePosition = 0;

            cbNgachCu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbNgachCu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            cbNgachCu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void cbNgachBHCu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in cbNgachBHCu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            cbNgachBHCu.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Hidden = false;
            cbNgachBHCu.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.Caption = "Tên Ngạch";
            cbNgachBHCu.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.VisiblePosition = 0;

            cbNgachBHCu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbNgachBHCu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            cbNgachBHCu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void cbNgachMoi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in cbNgachMoi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            cbNgachMoi.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Hidden = false;
            cbNgachMoi.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.Caption = "Tên Ngạch";
            cbNgachMoi.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.VisiblePosition = 0;

            cbNgachMoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbNgachMoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            cbNgachMoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void cbNgachBHMoi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in cbNgachBHMoi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            cbNgachBHMoi.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Hidden = false;
            cbNgachBHMoi.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.Caption = "Tên Ngạch";
            cbNgachBHMoi.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.VisiblePosition = 0;

            cbNgachBHMoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbNgachBHMoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            cbNgachBHMoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void cbBacCu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in cbBacCu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            cbBacCu.DisplayLayout.Bands[0].Columns["HeSoLuong"].Hidden = false;
            cbBacCu.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "Hệ Số Lương";
            cbBacCu.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 0;

            cbBacCu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbBacCu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            cbBacCu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void cbBacBHCu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in cbBacBHCu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            cbBacBHCu.DisplayLayout.Bands[0].Columns["HeSoLuong"].Hidden = false;
            cbBacBHCu.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "Hệ Số Lương";
            cbBacBHCu.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 0;

            cbBacBHCu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbBacBHCu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            cbBacBHCu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void cbBacLuongMoi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in cbBacLuongMoi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            cbBacLuongMoi.DisplayLayout.Bands[0].Columns["HeSoLuong"].Hidden = false;
            cbBacLuongMoi.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "Hệ Số Lương";
            cbBacLuongMoi.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 0;

            cbBacLuongMoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbBacLuongMoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            cbBacLuongMoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void cbBacBHMoi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in cbBacBHMoi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            cbBacBHMoi.DisplayLayout.Bands[0].Columns["HeSoLuong"].Hidden = false;
            cbBacBHMoi.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "Hệ Số Lương";
            cbBacBHMoi.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 0;

            cbBacBHMoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbBacBHMoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            cbBacBHMoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void cbNhomNgach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in cbNhomNgach.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            cbNhomNgach.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Width = cbNhomNgach.Width;
            cbNhomNgach.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Hidden = false;
            cbNhomNgach.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.Caption = "Nhóm Ngạch";
            cbNhomNgach.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.VisiblePosition = 0;
  
        }

        private void cbNhomNgachBHMoi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in cbNhomNgachBHMoi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            cbNhomNgachBHMoi.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Width = cbNhomNgachBHMoi.Width;
            cbNhomNgachBHMoi.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Hidden = false;
            cbNhomNgachBHMoi.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.Caption = "Nhóm Ngạch";
            cbNhomNgachBHMoi.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.VisiblePosition = 0;
  
        }

        private void cbNhomNgach_ValueChanged(object sender, EventArgs e)
        {
            if (cbNhomNgach.ActiveRow != null)
            {
                ngachCoBanMoiList = NgachLuongCoBanList.GetNgachLuongCoBanListByNhomNgach(Convert.ToInt32(cbNhomNgach.Value));
                this.bdNgachMoi.DataSource = ngachCoBanMoiList;
            }
        }

        private void cbNgachMoi_ValueChanged(object sender, EventArgs e)
        {
            if (cbNgachMoi.ActiveRow != null)
            {
                bacCoBanMoiList = BacLuongCoBanList.GetBacLuongCoBanListByNgachLuong(Convert.ToInt32(cbNgachMoi.Value));
                this.bdBacMoi.DataSource = bacCoBanMoiList;
            }
        }

        private void cbBacLuongMoi_ValueChanged(object sender, EventArgs e)
        {
            if (cbBacLuongMoi.ActiveRow != null)
            {
                tbHSLuongMoi.Value = BacLuongCoBan.GetBacLuongCoBan(Convert.ToInt32(cbBacLuongMoi.Value)).HeSoLuong;
            }
        }

        private void cbNhomNgachBHMoi_ValueChanged(object sender, EventArgs e)
        {
            if (cbNhomNgachBHMoi.ActiveRow != null)
            {
                ngachBaoHiemMoiList = NgachLuongCoBanList.GetNgachLuongCoBanListByNhomNgach(Convert.ToInt32(cbNhomNgachBHMoi.Value));
                this.bdNgachBHMoi.DataSource = ngachBaoHiemMoiList;
            }
        }

        private void cbNgachBHMoi_ValueChanged(object sender, EventArgs e)
        {
            if (cbNgachBHMoi.ActiveRow != null)
            {
                bacBaoHiemMoiList = BacLuongCoBanList.GetBacLuongCoBanListByNgachLuong(Convert.ToInt32(cbNgachBHMoi.Value));
                this.bdBacMoi.DataSource = bacBaoHiemMoiList;
            }
        }

        private void cbBacBHMoi_ValueChanged(object sender, EventArgs e)
        {
            if (cbBacBHMoi.ActiveRow != null)
            {
                tbHSBHMoi.Value = BacLuongCoBan.GetBacLuongCoBan(Convert.ToInt32(cbBacBHMoi.Value)).HeSoLuong;
            }
        }

        private void bt_Xem_Click(object sender, EventArgs e)
        {
            DateChanged();
        }
     
    }
}
