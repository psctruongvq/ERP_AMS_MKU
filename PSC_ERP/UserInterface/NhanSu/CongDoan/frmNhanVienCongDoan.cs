using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using ERP_Library;



namespace PSC_ERP.UserInterface.NhanSu.CongDoan
{
    public partial class frmNhanVienCongDoan : Form
    {
        BoPhanList _boPhanList;
        NhanVienList _nhanVienList;
        int maBoPhan = 0;
        public frmNhanVienCongDoan()
        {
            InitializeComponent();
            _boPhanList = BoPhanList.GetBoPhanListByMaBoPhanChaNotNull();
            BoPhan itemBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _boPhanList.Insert(0, itemBoPhan);
            this.bindingSource_BoPhan.DataSource = _boPhanList;

            _nhanVienList = NhanVienList.NewNhanVienList();
            bindingSource_NhanVien.DataSource = _nhanVienList;
        }
      

        private void ultraGrid_NhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            
            this.ultraGrid_NhanVien.DisplayLayout.Override.HeaderCheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;

            foreach (UltraGridColumn col in this.ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            }
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;

            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phân";
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 200;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 1;


            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 70;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 2;


            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 200;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 3;


            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CongDoan"].Hidden = false;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CongDoan"].Header.Caption = "Công Đoàn";
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CongDoan"].Width = 200;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CongDoan"].Header.VisiblePosition = 4;
        }

        private void ultraGrid_NhanVien_PropertyChanged(object sender, Infragistics.Win.PropertyChangedEventArgs e)
        {
          
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
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        private void cmbu_NhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_NhanVien, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_NhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 0;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 60;

            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbu_Bophan.ActiveRow != null)
                {
                    maBoPhan = (int)cmbu_Bophan.ActiveRow.Cells["MaBoPhan"].Value;
                }
       
                _nhanVienList = NhanVienList.GetNhanVienList(maBoPhan);
                this.bindingSource_NhanVien.DataSource = _nhanVienList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource_NhanVien.EndEdit();
                _nhanVienList.Save();
                MessageBox.Show(this, "Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Cập nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw ex;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
