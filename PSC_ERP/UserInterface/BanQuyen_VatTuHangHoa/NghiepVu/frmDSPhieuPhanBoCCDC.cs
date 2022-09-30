using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using PSC_ERP_Common;

namespace PSC_ERP
{
    public partial class frmDSPhieuPhanBoCCDC : XtraForm
    {
        PhanBoChiPhiCCDCList _phanBoChiPhiCCDCList = PhanBoChiPhiCCDCList.NewPhanBoChiPhiCCDCList();
        public frmDSPhieuPhanBoCCDC()
        {
            InitializeComponent();
            KhoiTao();
        }

        #region KhoiTao
        private void KhoiTao()
        {
            khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoBQ_VTList();
            //boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanList();
            //boPhanListBindingSource1.DataSource = BoPhanList.GetBoPhanList();
            BoPhanList _boPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            BoPhan boPhan = BoPhan.NewBoPhan("<<Tất cả>>");
            _boPhanList.Insert(0, boPhan);
            boPhanListBindingSource.DataSource = _boPhanList;
            boPhanListBindingSource1.DataSource = _boPhanList;
            phanBoChiPhiCCDCListBindingSource.DataSource = _phanBoChiPhiCCDCList;
        }
        #endregion
        private bool KiemTraTruocCapNhat()
        {
            int[] selectedArray = grdv_DanhSachPhieuNhapXuat.GetSelectedRows();
            foreach (int i in selectedArray)
            {
                DateTime ngayPhanBo = ((PhanBoChiPhiCCDC)grdv_DanhSachPhieuNhapXuat.GetRow(i)).NgayPhanBo;
                KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(ngayPhanBo);
                long maChungTuPhanBo = ((PhanBoChiPhiCCDC)grdv_DanhSachPhieuNhapXuat.GetRow(i)).MaChungTu;
                if (maChungTuPhanBo != 0)
                {
                    DialogUtil.ShowWarning("Đã Lập chứng từ không thể xóa!\nVui lòng xóa chứng từ trước!");
                    return false;
                }
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        MessageBox.Show("Đã khóa sổ, không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (!CCDC.KiemTraThaoTacCCDCHopLe(ngayPhanBo))
                {
                    MessageBox.Show(string.Format("Đã thực hiện kết chuyển sang năm {0}, không thể thực hiện!", (ngayPhanBo.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkEdit_Ngay.Checked == true)
            {
                _phanBoChiPhiCCDCList = PhanBoChiPhiCCDCList.GetPhanBoChiPhiCCDCList(Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToDateTime(dtEdit_TuNgay.EditValue), Convert.ToDateTime(dtEdit_DenNgay.EditValue));
            }
            else
            {
                _phanBoChiPhiCCDCList = PhanBoChiPhiCCDCList.GetPhanBoChiPhiCCDCList(Convert.ToInt32(lookUpEdit_PhongBan.EditValue));
            }
            phanBoChiPhiCCDCListBindingSource.DataSource = _phanBoChiPhiCCDCList;
            if (_phanBoChiPhiCCDCList.Count == 0)//M
                MessageBox.Show("Danh Sách Phiếu rỗng!");
        }

        private void grdv_DanhSachPhieuNhapXuat_DoubleClick(object sender, EventArgs e)
        {
            if (phanBoChiPhiCCDCListBindingSource.Current != null)
            {
                PhanBoChiPhiCCDC phanBoChiPhi = PhanBoChiPhiCCDC.GetPhanBoChiPhiCCDC(((PhanBoChiPhiCCDC)phanBoChiPhiCCDCListBindingSource.Current).MaPhanBo);
                frmPhanBoChiPhiCCDC frm = new frmPhanBoChiPhiCCDC(phanBoChiPhi);
                frm.ShowDialog();
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPhanBoChiPhiCCDC frm = new frmPhanBoChiPhiCCDC();
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (checkEdit_Ngay.Checked == true)
                {
                    _phanBoChiPhiCCDCList = PhanBoChiPhiCCDCList.GetPhanBoChiPhiCCDCList(Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToDateTime(dtEdit_TuNgay.EditValue), Convert.ToDateTime(dtEdit_DenNgay.EditValue));
                }
                else
                {
                    _phanBoChiPhiCCDCList = PhanBoChiPhiCCDCList.GetPhanBoChiPhiCCDCList(Convert.ToInt32(lookUpEdit_PhongBan.EditValue));
                }
                phanBoChiPhiCCDCListBindingSource.DataSource = _phanBoChiPhiCCDCList;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraTruocCapNhat())
                grdv_DanhSachPhieuNhapXuat.DeleteSelectedRows();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _phanBoChiPhiCCDCList.ApplyEdit();
                _phanBoChiPhiCCDCList.Save();
                MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void grdv_DanhSachPhieuNhapXuat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (KiemTraTruocCapNhat())
                    grdv_DanhSachPhieuNhapXuat.DeleteSelectedRows();
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmDSPhieuPhanBoCCDC_Load(object sender, EventArgs e)
        {
            Utils.GridUtils.ConfigGridView(grdv_DanhSachPhieuNhapXuat
                         , setSTT: true//
                         , initCopyCell: false
                         , multiSelectCell: false
                         , multiSelectRow: true
                         , initNewRowOnTop: false);

            dtEdit_TuNgay.EditValue = DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = DateTime.Today.Date;

        }
    }
}