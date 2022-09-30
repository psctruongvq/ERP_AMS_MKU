using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Csla;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmDSNhanVienDungCuLaoDong : Form
    {
        Util util=new Util();
        NhanVien_DungCuLaoDongList list;
        DateTime tuNgay = DateTime.Today.Date;
        DateTime denNgay = DateTime.Today.Date;
        public frmDSNhanVienDungCuLaoDong()
        {
            InitializeComponent();
        }

        #region Load
        private void Load_Luoi()
        {
            try
            {
                ComBoChanged();
            }
            catch (ApplicationException)
            {

            }

        }

        private void frmChuyenMonNghiepVu_Load(object sender, EventArgs e)
        {
            ComBoChanged();
        }

        private void ultragrdChuyenMonNghiepVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in gridData.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
                col.CellActivation = Activation.NoEdit;
            }
            gridData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["MaDungCu"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["NgayCap"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["ThoiHan"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["NgayHetHan"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;      
          

            gridData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";          
            gridData.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
            gridData.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            gridData.DisplayLayout.Bands[0].Columns["MaDungCu"].Header.Caption = "Tên Dụng Cụ";
            gridData.DisplayLayout.Bands[0].Columns["NgayCap"].Header.Caption = "Ngày Cấp";
            gridData.DisplayLayout.Bands[0].Columns["ThoiHan"].Header.Caption = "Thời Hạn";
            gridData.DisplayLayout.Bands[0].Columns["NgayHetHan"].Header.Caption = "Ngày Hết Hạn";
            gridData.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

            gridData.DisplayLayout.Bands[0].Columns["MaDungCu"].Width = cbDungCuLaoDong.Width;
            gridData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            gridData.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 1;
            gridData.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;            
            gridData.DisplayLayout.Bands[0].Columns["MaDungCu"].Header.VisiblePosition = 3;
            gridData.DisplayLayout.Bands[0].Columns["NgayCap"].Header.VisiblePosition = 4;
            gridData.DisplayLayout.Bands[0].Columns["ThoiHan"].Header.VisiblePosition = 5;
            gridData.DisplayLayout.Bands[0].Columns["NgayHetHan"].Header.VisiblePosition = 6;
            gridData.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 7;

            gridData.DisplayLayout.Bands[0].Columns["MaDungCu"].EditorComponent = cbDungCuLaoDong;
        }
        #endregion

        #region Event
       

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            
            gridData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(gridData);
        }
        #endregion

        #region Process
       
        #endregion  

        private void ultragrdChuyenMonNghiepVu_KeyDown(object sender, KeyEventArgs e)
        {
           // gridData.UpdateData();
        }

        private void ultragrdChuyenMonNghiepVu_Leave(object sender, EventArgs e)
        {
           // gridData.UpdateData();
        }

        private void dateTuNgay_ValueChanged(object sender, EventArgs e)
        {
            tuNgay = Convert.ToDateTime(dateTuNgay.Value).Date;
            ComBoChanged();
        }
        private void ComBoChanged()
        {
            DungCuLaoDongList _list = DungCuLaoDongList.GetDungCuLaoDongList();
            this.bindingSource1_DungCuLaoDong.DataSource = _list;
            list = NhanVien_DungCuLaoDongList.GetNhanVien_DungCuLaoDongList(tuNgay, denNgay, 0);
            NhanVienDungCuLaoDong_bindingSource.DataSource = list;
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            denNgay = Convert.ToDateTime(dateDenNgay.Value).Date;
            ComBoChanged();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(gridData);

        }
        



    }
}