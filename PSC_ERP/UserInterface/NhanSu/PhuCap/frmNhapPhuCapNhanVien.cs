using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmNhapPhuCapNhanVien : Form
    {
        private ERP_Library.PhuCapNhanVienList _data;
        private bool issave = false;

        public frmNhapPhuCapNhanVien()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(frmPhuCapNhanVien_FormClosed);
            grdData.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(grdData_BeforeRowsDeleted);
            grdData.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(grdData_AfterCellUpdate);
            //grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0,  0, 0, 0));
            grdData.BeforeRowUpdate += new Infragistics.Win.UltraWinGrid.CancelableRowEventHandler(grdData_BeforeRowUpdate);
        }

        void grdData_BeforeRowUpdate(object sender, Infragistics.Win.UltraWinGrid.CancelableRowEventArgs e)
        {
            if (cmbKyLuong.Value == null || cmbKyPC.Value == null)
            {
                e.Cancel = true;
                MessageBox.Show("Chọn Tháng lương và kỳ tính phụ cấp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            e.Row.Cells["MaKyTinhLuong"].Value = cmbKyLuong.Value;
            e.Row.Cells["MaKyPhuCap"].Value = cmbKyPC.Value;
        }

        void grdData_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            string t = e.Cell.Column.Key;
            if (t == "ThueSuat" || t == "PhuCap")
            {
                decimal sotien = Convert.ToDecimal(e.Cell.Row.Cells["PhuCap"].Value);
                decimal ts = Convert.ToDecimal(e.Cell.Row.Cells["ThueSuat"].Value);
                e.Cell.Row.Cells["TienThue"].Value = Math.Round(sotien * ts / 100, 0);
                e.Cell.Row.Cells["SoTien"].Value = sotien - Math.Round(sotien * ts / 100, 0);
            }
            else if (t == "TienThue")
            {
                decimal sotien = Convert.ToDecimal(e.Cell.Row.Cells["PhuCap"].Value);
                decimal thue = Convert.ToDecimal(e.Cell.Value);
                e.Cell.Row.Cells["SoTien"].Value = sotien + thue;
            }
            else if (t == "MaLoaiPhuCap")
            {
                e.Cell.Row.Cells["TenPhuCap"].Value = e.Cell.Text;
            }
        }

        void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        void frmPhuCapNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_data != null && _data.IsDirty)
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhuCapNhanVien_Load(object sender, EventArgs e)
        {
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            cmbKyPC.DataSource = cmbKyLuong.DataSource;
            foreach (ERP_Library.BoPhan item in ERP_Library.BoPhanList.GetBoPhanList())
            {
                grdData.DisplayLayout.ValueLists["BoPhan"].ValueListItems.Add(item.MaBoPhan, item.TenBoPhan);
            }
            foreach (ERP_Library.LoaiPhuCapChild item in ERP_Library.LoaiPhuCapList.GetLoaiPhuCapList())
            {
                grdData.DisplayLayout.ValueLists["PhuCap"].ValueListItems.Add(item.MaLoaiPhuCap, item.TenLoaiPhuCap);
            }
            foreach (ERP_Library.NhanVienComboListChild item in ERP_Library.NhanVienComboList.GetNhanVienAll())
            {
                grdData.DisplayLayout.ValueLists["NhanVien"].ValueListItems.Add(item.MaNhanVien, item.TenNhanVien);
            }
            cmbNhanVien.SetEditColumn("MaNhanVien", "MaBoPhan", grdData);
        }

        private void LoadData()
        {
            if (_data != null && issave && _data.IsDirty)
            {
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    _data.Save();
            }
            issave = tlslblLuu.Enabled;

            if (cmbKyLuong.Value != null && cmbKyPC.Value != null)
            {
                _data = ERP_Library.PhuCapNhanVienList.GetNhapPhuCapList((int)cmbKyLuong.Value, (int)cmbKyPC.Value);
                bdData.DataSource = _data;
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SaveData()
        {
            if (_data != null)
            {

                ERP_Library.KyTinhLuong ky = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value);
                if (ky.KhoaSoKy2)
                {
                    MessageBox.Show("Tháng lương này đã khóa sổ nên bạn không thể cập nhật", "Khóa sổ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                foreach (ERP_Library.PhuCapNhanVien pc in _data)
                {
                    if (pc.IsDirty|| pc.IsDeleted)
                    {
                         if (pc.SoQuyetDinh != "")
                        {
                            MessageBox.Show(this, "Dữ liệu đã được chuyển khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                
                }

                try
                {
                    grdData.UpdateData();
                    _data.Save();
                }
                catch (Exception ex)
                {
                    frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
                }
            }
            MessageBox.Show("Đã lưu dữ liệu thành công", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            bool hl = false;
            if (cmbKyLuong.Value != null)
            {
                ERP_Library.KyTinhLuong ky = (ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject;
                if (ky.KhoaSoKy2)
                    MessageBox.Show("Tháng lương này đã khóa sổ nên bạn không thể cập nhật", "Khóa sổ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    hl = true;
            }
            tlslblLuu.Enabled = hl;
            tlslblXoa.Enabled = hl;
            LoadData();
        }

        private void cmbKyPC_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}