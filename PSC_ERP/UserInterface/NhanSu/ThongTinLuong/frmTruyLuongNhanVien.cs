using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmTruyLuongNhanVien : Form
    {
        private ERP_Library.TruyLuongNhanVienList _data = null;
        private int KyLuongOld = 0;

        public frmTruyLuongNhanVien()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool KiemTraKhoaSo(int k)
        {
            //tra về true nếu Tháng lương đã khóa sổ kỳ 2
            if (k != 0)
            {
                ERP_Library.KyTinhLuong ky = ERP_Library.KyTinhLuong.GetKyTinhLuong(k);
                return ky.KhoaSoKy2;
            }
            return true;
        }

        private void LoadData()
        {
            if (_data != null && _data.IsDirty && !KiemTraKhoaSo(KyLuongOld))
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
            _data = ERP_Library.TruyLuongNhanVienList.GetTruyLuongNhanVienList((int)cmbKyLuong.Value);
            bdData.DataSource = _data;
            KyLuongOld = (int)cmbKyLuong.Value;
        }

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
            if (KiemTraKhoaSo(KyLuongOld))
            {
                MessageBox.Show("Tháng lương này đã khóa sổ nên không thể cập nhật!", "Khóa sổ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tlslblThem.Enabled = false;
                tlslblLuu.Enabled = false;
                grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
                btnXuLy.Enabled = false;
            }
            else
            {
                tlslblThem.Enabled = true;
                tlslblLuu.Enabled = true;
                grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
                btnXuLy.Enabled = true;
            }
        }

        private void frmTruyLuongNhanVien_Load(object sender, EventArgs e)
        {
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            tlslblLuu.Enabled = false;
            tlslblThem.Enabled = false;
            foreach (ERP_Library.KyTinhLuong item in ERP_Library.KyTinhLuongList.GetKyTinhLuongList())
                grdData.DisplayLayout.ValueLists["KyLuong"].ValueListItems.Add(item.MaKy, item.TenKy);
        }

        private void frmTruyLuongNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_data != null && _data.IsDirty)
            {
                if (!KiemTraKhoaSo(KyLuongOld) && MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
            }
        }

        private void SaveData()
        {
            try
            {
                grdData.UpdateData();
                _data.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công!", "Lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraKhoaSo(KyLuongOld))
            {
                SaveData();
                LoadData();
            }
            else
                MessageBox.Show("Tháng lương này đã khóa sổ nên không thể cập nhật!", "Khóa sổ", MessageBoxButtons.OK, MessageBoxIcon.Information);               
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa truy lương của nhân viên này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            frmThemTruyLuongNhanVien f = new frmThemTruyLuongNhanVien();
            DateTime d = ((ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject).NgayBatDau;
            f.DenKy = new DateTime(d.Year, d.Month, 1);
            f.DenKy = f.DenKy.AddMonths(1);
            f._list = _data;
            f.ShowDialog(this);
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                _data = ERP_Library.TruyLuongNhanVienList.GetTruyLuongNhanVienList((int)cmbKyLuong.Value);
                bdData.DataSource = _data;
            }
        }

        private void toolXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            if (KiemTraKhoaSo(KyLuongOld))
            {
                MessageBox.Show("Tháng lương này đã khóa sổ", "Khóa sổ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnXuLy.Enabled = false;
                return;
            }
            _data.XuLyTruyLuong();
            LoadData();
            MessageBox.Show("Đã xữ lý thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value is int)
            {
                frmXemIn f = new frmXemIn();
                f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptTruyLuongNhanVien.rdlc";
                f.SetDatabase("ERP_Library_BaoCaoTruyLuongList", ERP_Library.BaoCaoTruyLuongList.GetBaoCaoTruyLuongList((int)cmbKyLuong.Value, "All", 0));
                f.SetParameter("KyLuong", cmbKyLuong.Text, "PhanLoai", "");
                f.SetNguoiKy(3);
                f.ShowDialog();
            }
        }
    }
}