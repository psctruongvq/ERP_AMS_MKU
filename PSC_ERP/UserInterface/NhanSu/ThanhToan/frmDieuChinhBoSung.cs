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

namespace PSC_ERP.UserInterface.NhanSu.ThanhToan
{
    public partial class frmDieuChinhBoSung : Form
    {
        #region Properties
        DieuChinhBoSungList _dieuChinhBoSungList;
        #endregion

        public frmDieuChinhBoSung()
        {
            InitializeComponent();
            Load_Form();
        }

        private void Load_Form()
        {
            for (int i = 2013; i <= 2030; i++)
            {
                cb_Nam.Items.Add(i);
            }
            cb_Nam.Text = DateTime.Today.Year.ToString();
            cmb_NhanVien.DataSource = NhanVienComboList.GetNhanVienByMaBoPhanKhongNghiViec( Convert.ToInt32(0), Convert.ToBoolean(0));
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung f = new HamDungChung();
            f.ultragrdEmail_InitializeLayout(sender, e);

            HamDungChung.EditBand(grdData.DisplayLayout.Bands[0],
                new string[7] { "MaKyTinhLuong", "Thang", "Nam", "MaNhanVien", "SoTien", "DienGiai", "LoaiDieuChinh" },
                new string[7] { "Kỳ lương", "Tháng", "Năm", "Nhân Viên", "Số Tiền", "Diễn Giải", "Loại điều chỉnh" },
                new int[7] { 150, 70, 70, 150, 120, 130, 130 },
                new Control[7] { cmbKyLuong, null, null, cmb_NhanVien, null, null, cmb_LoaiDieuChinh },
                new KieuDuLieu[7] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Tien, KieuDuLieu.Null, KieuDuLieu.Null },
                new bool[7] { true, false, false, true, true, true, true });
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.White;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }

        private void cmb_NhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            FilterCombo filter = new FilterCombo(grdData,"MaNhanVien", "TenNhanVien");
        }
        private bool KiemTra()
        {
            foreach (DieuChinhBoSung dc in _dieuChinhBoSungList)
            {
                if (dc.LoaiDieuChinh == 0)
                {
                    MessageBox.Show(this, "Vui Lòng Chọn Loại Điều Chỉnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra())
                {
                    _dieuChinhBoSungList.ApplyEdit();
                    bdDanhSach.EndEdit();
                    _dieuChinhBoSungList.Save();
                    MessageBox.Show(this, "Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void tlUndo_Click(object sender, EventArgs e)
        {
            Load_Form();
        }

        private void tlXoa_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Chưa chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdData.DeleteSelectedRows();
            grdData.UpdateData();
        }

        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dieuChinhBoSungList = DieuChinhBoSungList.GetDieuChinhBoSungList(Convert.ToInt32(cb_Nam.Text));
            bdDanhSach.DataSource = _dieuChinhBoSungList;
        }
    }
}
