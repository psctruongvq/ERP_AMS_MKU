using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmThemTruyLuongNhanVien : Form
    {
        private ERP_Library.ThemTruyLuongNhanVienList _data;
        public ERP_Library.TruyLuongNhanVienList _list;
        public DateTime DenKy;

        public frmThemTruyLuongNhanVien()
        {
            InitializeComponent();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in grdData.Rows)
            {
                item.Cells["Chon"].Value = chkAll.Checked;
                item.Update();
            }
        }

        private void frmThemTruyLuongNhanVien_Load(object sender, EventArgs e)
        {
            _data = ERP_Library.ThemTruyLuongNhanVienList.GetThemTruyLuongNhanVienList();
            bdData.DataSource = _data;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in grdData.Rows)
            {
                if ((bool)item.Cells["Chon"].Value)
                    _list.ThemTruyLuong((ERP_Library.ThemTruyLuongNhanVienChild)item.ListObject, DenKy);
            }
        }
    }
}