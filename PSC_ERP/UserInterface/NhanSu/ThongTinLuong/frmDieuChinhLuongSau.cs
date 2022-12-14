using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmDieuChinhLuongSau : Form
    {
        private ERP_Library.DieuChinhLuongSauList _data;

        public frmDieuChinhLuongSau()
        {
            InitializeComponent();
        }

        private void frmDieuChinhLuongSau_Load(object sender, EventArgs e)
        {
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            foreach (ERP_Library.BoPhan item in ERP_Library.BoPhanList.GetBoPhanList())
                grdData.DisplayLayout.ValueLists["BoPhan"].ValueListItems.Add(item.MaBoPhan, item.TenBoPhan);
            cmbNhanVien.SetEditColumn("MaNhanVien", "MaBoPhan", grdData);
            foreach (ERP_Library.NhanVienComboListChild item in ERP_Library.NhanVienComboList.GetNhanVienAll())
                grdData.DisplayLayout.ValueLists["NhanVien"].ValueListItems.Add(item.MaNhanVien, item.TenNhanVien);
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdData.BeforeCellDeactivate += new CancelEventHandler(grdData_BeforeCellDeactivate);
            grdData.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(grdData_BeforeCellActivate);
        }

        private bool cellsothang = false;
        void grdData_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            if (e.Cell.Column.Key == "SoTienDieuChinh")
            {
                if (cellsothang)
                {
                    e.Cell.Row.Cells["HeSoLuongTruoc"].Activate();
                    grdData.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    e.Cancel = true;
                }
            }
        }

        void grdData_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            cellsothang = grdData.ActiveCell.Column.Key == "SoThang";
        }

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            if (_data != null && _data.IsDirty)
            {
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
            }
            LoadData();
        }

        private void SaveData()
        {
            try
            {
                grdData.UpdateData();               
                _data.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công", "Lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void LoadData()
        {
            if (cmbKyLuong.Value != null)
            {
                _data = ERP_Library.DieuChinhLuongSauList.GetDieuChinhLuongSauList((int)cmbKyLuong.Value);
                bdData.DataSource = _data;
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa điều chỉnh lương của nhân viên này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDieuChinhLuongSau_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_data != null && _data.IsDirty)
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();      
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grdData_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            e.Row.Cells["MaKyTinhLuong"].Value = cmbKyLuong.Value;
        }
    }
}