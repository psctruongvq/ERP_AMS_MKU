using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;

namespace PSC_ERP
{
    public partial class frmDSThanhLyCongCuDungCu : DevExpress.XtraEditors.XtraForm
    {
        //private DieuChuyenNoiBoCongCuDungCuList _dieuChuyenNoiBoCongCuDungCuList = null;
        private BoPhanList _boPhanListAll = null;
        private PhieuNhapXuatList _phieuNhapXuatList = null;

        public frmDSThanhLyCongCuDungCu()
        {
            InitializeComponent();

            this.LoadData();
            this.deNgay.DateTime = DateTime.Today;
            this.deDenNgay.DateTime = DateTime.Today;

            this.WindowState = FormWindowState.Maximized;

        }

        private void LoadData()
        {
            _boPhanListAll = BoPhanList.GetBoPhanListBy_All();
        }


        private void cmdTimTheoNgay_Click(object sender, EventArgs e)
        {

            int loai = 7;//7:thanhlyccdc; 8:dieuchuyenNgoaiccdc
            if (radioTatCa.Checked)
            {
                _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList_TimTheoLoaiVaNgay(loai, DateTime.Parse("01/01/1753"), DateTime.Parse("01/01/9999"));
            }
            else
            {
                _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList_TimTheoLoaiVaNgay(loai, deNgay.DateTime.Date, deDenNgay.DateTime.Date);
            }
            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
        }


        private void TimThanhLyCCDC_TheoNgay()
        {

        }
        private void btnTimTheoSoChungTu_Click(object sender, EventArgs e)
        {
            int loai = 7;//7:thanhlyccdc; 8:dieuchuyenNgoaiccdc
            //_phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList_TimTheoLoaiVaSoChungTu(loai, txtSoChungTu.Text.Trim(), radioGroupPhepToanSoSanh_SoChungTu.EditValue as string);
            _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList_TimTheoLoaiVaSoChungTu(loai, txtSoChungTu.Text.Trim(), "chua");//bang;chua
            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
        }
        private void btnTimTheoSoTien_Click(object sender, EventArgs e)
        {
            int loai = 7;//7:thanhlyccdc; 8:dieuchuyenNgoaiccdc
            _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList_TimTheoLoaiVaSoTien(loai, (decimal)txtSoTien.EditValue, radioGroupPhepTinhToanSoSanh_SoTien.EditValue as String);
            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
        }
        private void deTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            radioTatCa.Checked = false;
        }

        private void deDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            radioTatCa.Checked = false;
        }

        private void radioTatCa_EditValueChanged(object sender, EventArgs e)
        {
            //CheckEdit radio = sender as CheckEdit;
            //if (radio.Checked == true)
            //{
            //    deNgay.DateTime = DateTime.Parse("01/01/1753");
            //    deDenNgay.DateTime = DateTime.MaxValue;

            //    radio.Checked = true;
            //}
        }

        private void gridView_ThanhLyCongCuDungCu_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            this.XemLaiChungTu(view);
        }
        BaseEdit inplaceEditor;

        private void gridView_ThanhLyCongCuDungCu_ShownEditor(object sender, EventArgs e)
        {
            inplaceEditor = ((GridView)sender).ActiveEditor;

            inplaceEditor.DoubleClick += inplaceEditor_DoubleClick;
        }

        private void gridView_ThanhLyCongCuDungCu_HiddenEditor(object sender, EventArgs e)
        {
            if (inplaceEditor != null)
            {
                inplaceEditor.DoubleClick -= inplaceEditor_DoubleClick;

                inplaceEditor = null;

            }
        }
        void inplaceEditor_DoubleClick(object sender, EventArgs e)
        {

            BaseEdit editor = (BaseEdit)sender;

            GridControl grid = (GridControl)editor.Parent;

            //Point pt = grid.PointToClient(Control.MousePosition);

            GridView view = (GridView)grid.FocusedView;

            XemLaiChungTu(view);

        }

        private void XemLaiChungTu(GridView view)
        {
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);

            if (info.InRow || info.InRowCell)
            {
                long maPhieuNhapXuat = (long)view.GetRowCellValue(info.RowHandle, this.colMaPhieuNhapXuat);

                frmThanhLyCongCuDungCu frm = new frmThanhLyCongCuDungCu(maPhieuNhapXuat);
                frm.ShowDialog();

            }
        }
        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn lưu lại những thay đổi trên lưới", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.ChangeFocus();
                Save();
            }

        }

        private bool Save()
        {
            try
            {
                _phieuNhapXuatList.ApplyEdit();
                phieuNhapXuatListBindingSource.EndEdit();
                _phieuNhapXuatList.Save();
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lưu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView_ThanhLyCongCuDungCu.SelectedRowsCount > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa trên lưới những dòng đang chọn. Nếu xóa, sau đó cần bấm nut \"[" + btnLuu.Caption + "]\" để lưu lại những thay đổi xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    this.gridView_ThanhLyCongCuDungCu.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng chi tiết cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.TimThanhLyCCDC_TheoNgay();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        private void radioGroupPhepToanSoSanh_SoChungTu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSoChungTu_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSoChungTu_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDSThanhLyCongCuDungCu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ChangeFocus();
            if (_phieuNhapXuatList != null && _phieuNhapXuatList.IsDirty)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu trước khi thoát?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {

                    if (this.Save() == false)
                        e.Cancel = true;
                }
                else if (DialogResult.No == result)
                {

                }
                else if (DialogResult.Cancel == result)
                {
                    e.Cancel = true;
                }
            }
        }

        private void gridView_ThanhLyCongCuDungCu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.btnXoa.PerformClick();
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThanhLyCongCuDungCu frm = new frmThanhLyCongCuDungCu();
            frm.Show();
        }

        private void frmDSThanhLyCongCuDungCu_Load(object sender, EventArgs e)
        {
            Utils.GridUtils.ConfigGridView(gridView_ThanhLyCongCuDungCu
                         , setSTT: true//
                         , initCopyCell: false
                         , multiSelectCell: false
                         , multiSelectRow: true
                         , initNewRowOnTop: false);

        }










    }
}