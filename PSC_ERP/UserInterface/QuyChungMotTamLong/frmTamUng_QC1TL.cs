using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace PSC_ERP
{


    public partial class frmTamUng_QC1TL : Form
    {      
        DoiTuongAllList _doiTuongAllList;
        ChungTu_CacLoaiQuyList _chungTuList;
        public TamUng_QC1TLList _tamUngList;
         LoaiChungTuList _loaiChungTuList;
        ChuongTrinhList _chuongTrinhList;
        long maChungTu = 0;
        int loaiChungTu = 0;
        int loaiThuChi = 0;
        public static decimal ThanhTien = 0;
        public    bool IsSave = false;
        public static int MaChuongTrinh = 0;
        string dienGiai = string.Empty;
        public DateTime NgayLap;
        long MaDoiTuongDefault = 0;
        decimal SoTienDefault = 0;
        public frmTamUng_QC1TL()
        {
            InitializeComponent();
          
            
            this.bindingSource1_DoiTuong.DataSource = typeof(DoiTuongAllList);            
            this.bindingSource1_LoaiChungTu.DataSource = typeof(LoaiChungTuList);
            this.DSChungTu_BindingSource.DataSource = typeof(ChungTu_CacLoaiQuyList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            bindingSource1_TamUng.DataSource = typeof(TamUng_QC1TLList);
        }
        public frmTamUng_QC1TL(TamUng_QC1TLList tamUngList, int _maLoaiChungTu, string _dienGiai, DateTime _ngayLap, long maDoiTuongDefault, decimal soTienDefault)
        {
            
            InitializeComponent();
            _tamUngList = tamUngList;
            this.bindingSource1_TamUng.DataSource = _tamUngList;
            this.loaiChungTu = _maLoaiChungTu;
            loaiChungTu=_maLoaiChungTu;
            dienGiai = _dienGiai;
            NgayLap = _ngayLap;

            this.SoTienDefault = soTienDefault;
            this.MaDoiTuongDefault = maDoiTuongDefault;
            int maBoPhanCha = ERP_Library.Security.CurrentUser.Info.MaBoPhanCha;
           
        }
        private void frmTamUng_QC1TL_Load(object sender, EventArgs e)
        {
            _doiTuongAllList = DoiTuongAllList.GetDoiTuongAllList_Tim_NhanVien("", ERP_Library.Security.CurrentUser.Info.MaCongTy);
            //_doiTuongAllList = DoiTuongAllList.GetDoiTuongAllList();
            this.bindingSource1_DoiTuong.DataSource = _doiTuongAllList;
            
              _loaiChungTuList = LoaiChungTuList.GetLoaiChungTuList();
            this.bindingSource1_LoaiChungTu.DataSource = _loaiChungTuList;           
           // this.DSChungTu_BindingSource.DataSource = _chungTuList;
          _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("Không Có");
            _chuongTrinhList.Insert(0, itemChuongTrinh);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

        }
   
        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.FixedAddRowOnTop;
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
           grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Header.Caption = "Tên Khách Hàng";
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Width = cbNhanVien.Width;
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].EditorComponent = cbDoiTuong;


            //grdData.DisplayLayout.Bands[0].Columns["DonViDoiTuong"].Hidden = false;
            //grdData.DisplayLayout.Bands[0].Columns["DonViDoiTuong"].Header.Caption = "Đơn Vị Khách Hàng";
            //grdData.DisplayLayout.Bands[0].Columns["DonViDoiTuong"].Header.VisiblePosition = 2;
            //grdData.DisplayLayout.Bands[0].Columns["DonViDoiTuong"].Width = 230;
            //grdData.DisplayLayout.Bands[0].Columns["DonViDoiTuong"].CellActivation = Activation.NoEdit;

            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 5;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Format="###,###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Width = 180;

            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.Caption = "Tên Chương Trinh";
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Width = cmbu_ChuongTrinh.Width;
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.VisiblePosition = 6;
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].EditorComponent = cmbu_ChuongTrinh;

            //grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            //grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            //grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 7;
            //grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 350;

            //grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            //grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            //grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition =8;
           

        }

        private void cbNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbNhanVien, "TenNhanVien");
            foreach (UltraGridColumn col in this.cbNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            cbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
        }

      
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            this.bindingSource1_TamUng.EndEdit();
            grdData.UpdateData();
            if (ThanhTien != 0)
                ThanhTien = 0;
            foreach (TamUng_QC1TL tamUng in _tamUngList)
            {
                ThanhTien += tamUng.SoTien;
                tamUng.LoaiChungTu = loaiChungTu;  
                tamUng.DienGiai = dienGiai;
                tamUng.NgayLap = NgayLap;
            }
            _tamUngList.ApplyEdit();
            IsSave = true;
            this.Close();           
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _tamUngList = TamUng_QC1TLList.GetTamUng_QC1TLList(maChungTu);
            this.bindingSource1_TamUng.DataSource = _tamUngList;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cbDSChungTu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbDSChungTu, "SoChungTu");
            foreach (UltraGridColumn col in this.cbDSChungTu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbDSChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            cbDSChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            cbDSChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;
            cbDSChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 150;

            //cbDSChungTu.DisplayLayout.Bands[0].Columns["ThanhTien"].Hidden = false;
            //cbDSChungTu.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Số Tiền";
            //cbDSChungTu.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 1;
            //cbDSChungTu.DisplayLayout.Bands[0].Columns["ThanhTien"].Width = 150;

            cbDSChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            cbDSChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            cbDSChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 1;
            cbDSChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 150;

            cbDSChungTu.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            cbDSChungTu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            cbDSChungTu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 1;
            cbDSChungTu.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 200;
        }

        private void cbDoiTuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(grdData, "MaDoiTuong", "TenDoiTuong");
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

        private void cbChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(grdData, "MaChuongTrinh", "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = cmbu_ChuongTrinh.Width;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã QL";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;
        }

      
        private void grdData_AfterRowInsert(object sender, RowEventArgs e)
        {
            decimal soTienDaNhap = 0;
            foreach (TamUng_QC1TL tu in _tamUngList)
            {
                soTienDaNhap += tu.SoTien;
            }
            ((TamUng_QC1TL)bindingSource1_TamUng.Current).MaDoiTuong = MaDoiTuongDefault;
            ((TamUng_QC1TL)bindingSource1_TamUng.Current).SoTien = SoTienDefault - soTienDaNhap;
            e.Row.Update();
        }

        private void cmbu_ChuongTrinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.ActiveRow != null)
            {
                MaChuongTrinh = (int)cmbu_ChuongTrinh.Value;
            }
        }

       

      
    }
}
