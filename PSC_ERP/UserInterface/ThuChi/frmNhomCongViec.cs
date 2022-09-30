using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmNhomCongViec : Form
    {
        
        NhomCongViecList _list;
        
        public frmNhomCongViec()
        {
            InitializeComponent();
        }
        private void frmTamUng_SoDu_Load(object sender, EventArgs e)
        {
            _list = NhomCongViecList.GetNhomCongViecList();
            this.bindingSourceNhomCongViec.DataSource = _list;
           
        }
        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdData.DisplayLayout.Bands[0].Columns["MaNhomDoiTuongQL"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaNhomDoiTuongQL"].Header.Caption = "Mã Quản Lý";
            grdData.DisplayLayout.Bands[0].Columns["MaNhomDoiTuongQL"].Header.VisiblePosition = 0;
           
            grdData.DisplayLayout.Bands[0].Columns["TenNhomDoiTuong"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TenNhomDoiTuong"].Header.Caption = "Nhóm Công Việc";
            grdData.DisplayLayout.Bands[0].Columns["TenNhomDoiTuong"].Header.VisiblePosition = 1;

            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
       
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            bindingSourceNhomCongViec.EndEdit();
            grdData.UpdateData();
            _list.ApplyEdit();
            _list.Save();
            MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _list = NhomCongViecList.GetNhomCongViecList();
            this.bindingSourceNhomCongViec.DataSource = _list;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

   
       
    }
}
