using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class frmCongViec : Form
    {
        #region
        CongViecList _congViecList=CongViecList.NewCongViecList();
        #endregion

        public frmCongViec()
        {
            InitializeComponent();
            this.CongViec_BindingSource.DataSource= typeof(CongViecList);
            LoadForm();
        }

        public void LoadForm()
        {
            _congViecList = CongViecList.GetCongViecList();
            CongViec_BindingSource.DataSource = _congViecList;
        }

        private void grdu_CongViec_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;

            grdu_CongViec.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            grdu_CongViec.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            grdu_CongViec.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.Caption = "Tên Công Việc";
            grdu_CongViec.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.VisiblePosition = 1;
            grdu_CongViec.DisplayLayout.Bands[0].Columns["TenCongViec"].Width = 300;

            foreach (UltraGridColumn col in this.grdu_CongViec.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            grdu_CongViec.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            grdu_CongViec.DisplayLayout.Bands[0].Columns["TenCongViec"].Hidden = false;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grdu_CongViec.UpdateData();
                _congViecList.ApplyEdit();
                _congViecList.Save();

                MessageBox.Show("Cập nhật thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_CongViec.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Chọn dòng cần xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            grdu_CongViec.DeleteSelectedRows();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            DialogResult _DialogResult = MessageBox.Show("Bạn thật sự muốn thoát không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_CongViec);
        }
    }
}
