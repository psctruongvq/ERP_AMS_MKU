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
    public partial class frmThongTinNganHang : Form
    {
        #region Properties
        public ThongTinNganHangChildList _thongtinList;
        #endregion

        #region Loads
        public frmThongTinNganHang()
        {
            InitializeComponent();
        }

        public frmThongTinNganHang(ThongTinNganHangChildList thongtinList)
        {
            InitializeComponent();
            _thongtinList = thongtinList;
            Load_Form();
        }

        private void grd_NganHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            grd_NganHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region Process
        private void Load_Form()
        {
            NganHang_bindingSource1.DataSource = _thongtinList;
        }
        #endregion

        #region Events

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grd_NganHang.UpdateData();
                NganHang_bindingSource1.EndEdit();

                MessageBox.Show(this, "Thông tin ngân hàng đã được lưu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grd_NganHang.Selected.Rows.Count <= 0)
            {
                MessageBox.Show(this, "Vui lòng chọn dòng cần xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grd_NganHang.DeleteSelectedRows();
            grd_NganHang.UpdateData();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            Load_Form();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
