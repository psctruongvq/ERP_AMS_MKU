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
    public partial class frmHeSoLuong : Form
    {
        HeSoList heSoList = HeSoList.NewHeSoList();
        BoPhanList boPhanList = BoPhanList.NewBoPhanList();

        public frmHeSoLuong()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            kyTinhLuongListBindingSource.DataSource = KyTinhLuongList.GetKyTinhLuongList();
            boPhanList = BoPhanList.GetBoPhanList();

            BoPhan boPhan = BoPhan.NewBoPhan();
            boPhan.TenBoPhan = "Select All";
            boPhanList.Insert(0, boPhan);
            boPhanListBindingSource.DataSource = boPhanList;
            heSoListBindingSource.DataSource = heSoList;
        }


        #region tìmToolStripMenuItem_Click
        private void tìmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbKy.SelectedItem != null && cbu_BoPhan.Value != null)
            {
                heSoList = HeSoList.GetHeSoList(Convert.ToInt32(((KyTinhLuong)cbKy.SelectedItem).MaKy), Convert.ToInt32(cbu_BoPhan.Value));
                heSoListBindingSource.DataSource = heSoList;
            }
        }
        #endregion

        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                heSoList.ApplyEdit();
                heSoList.Save();
                MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region cbu_BoPhan_InitializeLayout
        private void cbu_BoPhan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_BoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.CellActivation = Activation.NoEdit;
            }
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            
        }
        #endregion 

        #region ugrButToan_InitializeLayout
        private void ugrButToan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ugrButToan.DisplayLayout.Bands[0].Columns)
            {               
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.CellActivation = Activation.NoEdit;
            }
            ugrButToan.DisplayLayout.Bands[0].Columns["MaHeSo"].Hidden = true;
            ugrButToan.DisplayLayout.Bands[0].Columns["MaKyTinhLuong"].Hidden = true;
            ugrButToan.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            ugrButToan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Nhân Viên";
            ugrButToan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ugrButToan.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ugrButToan.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            ugrButToan.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            ugrButToan.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 2;
            ugrButToan.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "Hệ Số Lương";
            ugrButToan.DisplayLayout.Bands[0].Columns["HeSoLuong"].CellActivation = Activation.AllowEdit;
            ugrButToan.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 3;
            ugrButToan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            ugrButToan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 4;
            ugrButToan.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            ugrButToan.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 5;
            ugrButToan.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.Caption = "Tên Công Việc";
            ugrButToan.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.VisiblePosition = 6;
            
            
            
        }
        #endregion 
    }
}