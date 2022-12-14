using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace PSC_ERP
{
    public partial class frmNghiThaiSanList : Form
    {
        private FilterCombo fBoPhan, fTuKy, fDenKy;
        private ERP_Library.NghiThaiSanList _data;

        public frmNghiThaiSanList()
        {
            InitializeComponent();
        }

        private bool SaveData()
        {
            if (_data == null) return true;

            try
            {
                grdDanhSach.UpdateData();
                nghiThaiSanListBindingSource.EndEdit();
                _data.Save();
                grdDanhSach.DataBind();
                return true;
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
                return false;
            }
        }
        private void frmNghiThaiSanList_Load(object sender, EventArgs e)
        {
            kyTinhLuongListBindingSource.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            boPhanListBindingSource.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbNhanVien.SetEditColumn("MaNhanVien", "MaBoPhan", grdDanhSach);
            foreach (ERP_Library.NhanVienComboListChild item in ERP_Library.NhanVienComboList.GetNhanVienAll())
                grdDanhSach.DisplayLayout.ValueLists["NhanVien"].ValueListItems.Add(item.MaNhanVien, item.TenNhanVien);

            _data = ERP_Library.NghiThaiSanList.GetNghiThaiSanList();
            nghiThaiSanListBindingSource.DataSource = _data;
            fBoPhan = new FilterCombo(grdDanhSach, "MaBoPhan", "TenBoPhan");
            fTuKy = new FilterCombo(grdDanhSach, "TuKy", "TenKy");
            fDenKy = new FilterCombo(grdDanhSach, "DenKy", "TenKy");
            HamDungChung.VisibleColumn(cmbTuKy.DisplayLayout.Bands[0], "TenKy");
            HamDungChung.VisibleColumn(cmbDenKy.DisplayLayout.Bands[0], "TenKy");
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (SaveData())
                MessageBox.Show("Dữ liệu đã lưu thành công", "Lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            nghiThaiSanListBindingSource.AddNew();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdDanhSach.DeleteSelectedRows();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _data = ERP_Library.NghiThaiSanList.GetNghiThaiSanList();
            nghiThaiSanListBindingSource.DataSource = _data;          
        }
    }
}