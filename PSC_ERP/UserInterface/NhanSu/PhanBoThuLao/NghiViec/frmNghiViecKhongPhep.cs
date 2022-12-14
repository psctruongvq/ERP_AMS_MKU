using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace PSC_ERP
{
    public partial class frmNghiViecKhongPhep : Form
    {
        private ERP_Library.NghiViecKhongPhepList _Data;
        public frmNghiViecKhongPhep()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNghiViecKhongPhep_Load(object sender, EventArgs e)
        {
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            txtThang.Text = DateTime.Today.ToString("MM/yyyy");
            tlslblLuu.Enabled = false;
            tlslblUndo.Enabled = false;
            tlslblXoa.Enabled = false;
            ERP_Library.HinhThucNghiList l = ERP_Library.HinhThucNghiList.GetHinhThucNghiList();
            foreach (ERP_Library.HinhThucNghi i in l)
            {
                grdData.DisplayLayout.ValueLists["HinhThucNghi"].ValueListItems.Add(i.MaHinhThucNghi, i.TenHinhThucNghi);
            }
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            int id=0;
            try
            {
                id = (int)cmbBoPhan.Value;
            }
            catch { }
            cmbNhanVien.LoadDataByBoPhan(id);
            cmbNhanVien.Value = null;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
           
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa ngày nghỉ này của nhân viên không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grdData.UpdateData();
                _Data.Save();
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _Data);
            }
            MessageBox.Show("Lưu dữ liệu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _Data = ERP_Library.NghiViecKhongPhepList.GetNghiViecKhongPhepList((long)cmbNhanVien.Value, Convert.ToInt32(txtThang.Value.Month), Convert.ToInt32(txtThang.Value.Year));
            bdData.DataSource = _Data;           
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            if (_Data != null)
            {
                grdData.UpdateData();
                if (_Data.IsDirty && _Data.IsValid)
                {
                    if (MessageBox.Show("Dữ liệu đã được thay đổi\nBạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            _Data.Save();
                        }
                        catch (Exception ex)
                        {
                            frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _Data);
                            return;
                        }
                    }
                }
            }
            if (cmbBoPhan.Value != null && cmbNhanVien.Value != null && txtThang.Text != "")
            {
                _Data = ERP_Library.NghiViecKhongPhepList.GetNghiViecKhongPhepList((long)cmbNhanVien.Value, Convert.ToInt32(txtThang.Value.Month), Convert.ToInt32(txtThang.Value.Year));
                bdData.DataSource = _Data;
                tlslblLuu.Enabled = true;
                tlslblUndo.Enabled = true;
                tlslblXoa.Enabled = true;
                grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].DefaultCellValue = cmbBoPhan.Value;
                grdData.DisplayLayout.Bands[0].Columns["MaNhanVien"].DefaultCellValue = cmbNhanVien.Value;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu nhân viên cần tìm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}