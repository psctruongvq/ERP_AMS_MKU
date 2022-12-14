using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmHangHoa_Tim : Form
    {
        #region Properties
        HamDungChung _hamDC = new HamDungChung();
        Util util = new Util();
        LoaiVatTuHHList _loaiVatTuHHList = LoaiVatTuHHList.NewLoaiVatTuHHList();
        LoaiHangHoaList _loaiHHList = LoaiHangHoaList.NewLoaiHangHoaList();
        QuocGiaList _quocGiaList = QuocGiaList.NewQuocGiaList();
        DonViTinhList _donVTList = DonViTinhList.NewDonViTinhList();
        DonViTinhList _donVCanList = DonViTinhList.NewDonViTinhList();
        LoaiVangList _loaiVangList = LoaiVangList.NewLoaiVangList();
        HangHoaList _hangHoaList = HangHoaList.NewHangHoaList();
        public HangHoa _hangHoa;
        public static int _maHangHoa;
        #endregion

        public frmHangHoa_Tim()
        {
            InitializeComponent();
            _hamDC.EventForm(this);
            GanDuLieu();
            chku_TimALL.Checked = true;
        }

        #region GanDuLieu
        private void GanDuLieu()
        {
            try
            {
                
                _donVTList = DonViTinhList.GetDonViTinhList();
                donViTinhListBindingSource.DataSource = _donVTList;                
                _quocGiaList = QuocGiaList.GetQuocGiaList();
                quocGiaListBindingSource.DataSource = _quocGiaList;               
                _loaiHHList = LoaiHangHoaList.GetLoaiHangHoaList_MuaBan();
                loaiHangHoaListBindingSource.DataSource = _loaiHHList;
            }
            catch (ApplicationException ex)
            {
                //throw ex;
            }
        }
        #endregion

        private void grdu_HangHoa_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grdu_HangHoa.DisplayLayout.Bands[0],
            new string[7] { "MaQuanLy", "TenHangHoa", "TenHangSanXuat", "MaQuocGia", "MaDonViTinh", "MaLoaiHangHoa", "DienGiai" },
            new string[7] { "Mã HH", "Tên HH", "Tên Hãng SX", "Xuất Xứ", "Đơn Vị Tính", "Loại Hàng Hóa","Diễn Giải" },
            new int[7] { 80, 120, 120, 100, 90, 90,  120},
            new Control[7] { null, null, null, cmbu_XuatXuQG, cmbu_DVT, cmbu_LoaiHHLuoi, null},
            new KieuDuLieu[7] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null},
            new bool[7] { false, false, false, false, false, false, false});
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_HangHoa.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                if (col.DataType.ToString() == "System.Decimal")
                    col.CellAppearance.TextHAlign = HAlign.Right;
                else
                    col.CellAppearance.TextHAlign = HAlign.Left;
            }
            //màu nền
            this.grdu_HangHoa.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_HangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void cmbu_MaLoaiVatTuHHLuoi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_MaLoaiVatTuHHLuoi.DisplayLayout.Bands[0],
            new string[3] { "MaQuanLy", "TenLoaiVatTuHH", "DienGiai" },
            new string[3] { "Mã Loại VT", "Tên Loại VT", "Diễn Giải" },
            new int[3] { 100, 150, 120 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[3] { true, true, true });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_MaLoaiVatTuHHLuoi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.cmbu_MaLoaiVatTuHHLuoi.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_MaLoaiVatTuHHLuoi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void cmbu_DVCan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_DVCan.DisplayLayout.Bands[0],
           new string[3] { "MaQuanLy", "TenDonViTinh", "DienGiai" },
           new string[3] { "Mã ĐV Cân", "Tên ĐV Cân", "Diễn Giải" },
           new int[3] { 100, 150, 120 },
           new Control[3] { null, null, null },
           new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
           new bool[3] { true, true, true });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_DVCan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.cmbu_DVCan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_DVCan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void cmbu_LoaiHHLuoi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_LoaiHHLuoi.DisplayLayout.Bands[0],
          new string[3] { "MaQuanLy", "TenLoaiHangHoa", "DienGiai" },
          new string[3] { "Mã Loại HH", "Tên Loại HH", "Diễn Giải" },
          new int[3] { 100, 150, 120 },
          new Control[3] { null, null, null },
          new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
          new bool[3] { true, true, true });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_LoaiHHLuoi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.cmbu_LoaiHHLuoi.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_LoaiHHLuoi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void cmbu_MaLoaiVangLuoi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_MaLoaiVangLuoi.DisplayLayout.Bands[0],
           new string[3] { "MaQuanLy", "TenLoaiVang", "DienGiai" },
           new string[3] { "Mã Loại Vàng", "Tên Loại Vàng", "Diễn Giải" },
           new int[3] { 150, 150, 120 },
           new Control[3] { null, null, null },
           new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
           new bool[3] { true, true, true });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_MaLoaiVangLuoi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.cmbu_MaLoaiVangLuoi.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_MaLoaiVangLuoi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void cmbu_XuatXuQG_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_XuatXuQG.DisplayLayout.Bands[0],
           new string[3] { "MaQuocGiaQuanLy", "TenQuocGia", "DienGiai" },
           new string[3] { "Mã Quốc Gia", "Tên Quốc Gia", "Diễn Giải" },
           new int[3] { 100, 150, 120 },
           new Control[3] { null, null, null },
           new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
           new bool[3] { true, true, true });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_XuatXuQG.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.cmbu_XuatXuQG.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_XuatXuQG.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void cmbu_DVT_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_DVT.DisplayLayout.Bands[0],
           new string[3] { "MaQuanLy", "TenDonViTinh", "DienGiai" },
           new string[3] { "Mã ĐVT", "Tên ĐVT", "Diễn Giải" },
           new int[3] { 100, 150, 120 },
           new Control[3] { null, null, null },
           new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
           new bool[3] { true, true, true });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_DVT.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.cmbu_DVT.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_DVT.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void chku_TimALL_CheckedChanged(object sender, EventArgs e)
        {
            if (chku_TimALL.Checked)
            {
                txtDieuKien.Text = "";
                txtDieuKien.Enabled = false;
            }
            else
            {
                txtDieuKien.Enabled = true;
            }
        }

        private void btnu_TimKiem_Click(object sender, EventArgs e)
        {
            if (txtDieuKien.Text == "" && chku_TimALL.Checked == false)
                MessageBox.Show(this, "Vui lòng nhập điều kiện tìm kiếm", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                _hangHoaList = HangHoaList.GetHangHoaList(txtDieuKien.Text.Trim(), chku_TimALL.Checked);
                hangHoaListBindingSource.DataSource = _hangHoaList;
                if (_hangHoaList.Count == 0)
                    MessageBox.Show(this, "Không tìm thấy dữ liệu.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    hangHoaListBindingSource.DataSource = _hangHoaList;
                chku_TimALL_CheckedChanged(sender, e);
            }
        }

        private void grdu_HangHoa_DoubleClick(object sender, EventArgs e)
        {
            _maHangHoa = ((HangHoa)(hangHoaListBindingSource.Current)).MaHangHoa;
            _hangHoa = HangHoa.GetHangHoa(_maHangHoa);
            this.Close();
        }

        private void btnu_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_HangHoa.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdu_HangHoa.DeleteSelectedRows();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            //_hangHoaList.upda
            try
            {
                _hangHoaList.ApplyEdit();
                _hangHoaList.Save();
                MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ApplicationException ex)
            {
            }
        }
    }
}