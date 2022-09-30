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
    public partial class frmDSDieuChuyenNoiBoCCDC : DevExpress.XtraEditors.XtraForm
    {
        private DieuChuyenNoiBoCCDCList _dieuChuyenNoiBoCongCuDungCuList = null;
        public frmDSDieuChuyenNoiBoCCDC()
        {
            InitializeComponent();
            SetDataSourceForBindingSource();
            this.LoadData();
            this.deNgay.DateTime = DateTime.Now.Date;
            this.deDenNgay.DateTime = DateTime.Now.Date;
            this.WindowState = FormWindowState.Maximized;
        }

        #region Functions
        private void SetDataSourceForBindingSource()
        {
            dieuChuyenNoiBoCongCuDungCuListBindingSource.DataSource = typeof(DieuChuyenNoiBoCCDCList);
        }

        private bool KiemTraTruocCapNhat()
        {
            int[] selectedArray = gridView_DieuChuyenNoiBoCCDCList.GetSelectedRows();
            foreach (int i in selectedArray)
            {
                DateTime ngaydieuchuyen = ((DieuChuyenNoiBoCCDC)gridView_DieuChuyenNoiBoCCDCList.GetRow(i)).NgayDieuChuyen;
                KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(ngaydieuchuyen);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        MessageBox.Show("Đã khóa sổ, không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (!CCDC.KiemTraThaoTacCCDCHopLe(ngaydieuchuyen))
                {
                    MessageBox.Show(string.Format("Đã thực hiện kết chuyển sang năm {0}, không thể thực hiện!", (ngaydieuchuyen.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }
        #endregion//Functions

        private void LoadData()
        {

        }


        private void cmdTimTheoNgay_Click(object sender, EventArgs e)
        {
            if (radioTatCa.Checked)
            {
                _dieuChuyenNoiBoCongCuDungCuList = DieuChuyenNoiBoCCDCList.GetDieuChuyenNoiBoCongCuDungCuList_TimTheoNgay(DateTime.Parse("01/01/1753"), DateTime.Parse("01/01/9999"));
                dieuChuyenNoiBoCongCuDungCuListBindingSource.DataSource = _dieuChuyenNoiBoCongCuDungCuList;
            }
            else
            {
                _dieuChuyenNoiBoCongCuDungCuList = DieuChuyenNoiBoCCDCList.GetDieuChuyenNoiBoCongCuDungCuList_TimTheoNgay( (deNgay.DateTime).Date, (deDenNgay.DateTime).Date);
                dieuChuyenNoiBoCongCuDungCuListBindingSource.DataSource = _dieuChuyenNoiBoCongCuDungCuList;
            }
            if (_dieuChuyenNoiBoCongCuDungCuList.Count == 0)//M
                MessageBox.Show("Danh Sách Phiếu rỗng!");

        }
        private void btnTimTheoSoChungTu_Click(object sender, EventArgs e)
        {
            //_dieuChuyenNoiBoCongCuDungCuList = DieuChuyenNoiBoCongCuDungCuList.GetDieuChuyenNoiBoCongCuDungCuList_TimTheoSoChungTu(txtSoChungTu.Text.Trim(), radioGroupPhepToanSoSanh_SoChungTu.EditValue as String);
            _dieuChuyenNoiBoCongCuDungCuList = DieuChuyenNoiBoCCDCList.GetDieuChuyenNoiBoCongCuDungCuList_TimTheoSoChungTu(txtSoChungTu.Text.Trim(), "chua");//bang;chua
            dieuChuyenNoiBoCongCuDungCuListBindingSource.DataSource = _dieuChuyenNoiBoCongCuDungCuList;
            if (_dieuChuyenNoiBoCongCuDungCuList.Count == 0)//M
                MessageBox.Show("Danh Sách Phiếu rỗng!");
        }
        private void deNgay_EditValueChanged(object sender, EventArgs e)
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

            //}
        }

        private void gridView_DieuChuyenNoiBoCCDCList_DoubleClick(object sender, EventArgs e)
        {

            GridView view = (GridView)sender;


            XemLaiChungTu(view);

        }

        private void XemLaiChungTu(GridView view)
        {
            try
            {
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);

                if (info.InRow || info.InRowCell)
                {
                    int maDieuChuyen = (int)view.GetRowCellValue(info.RowHandle, this.colMaDieuChuyen);
                    //MessageBox.Show(maDieuChuyen.ToString());
                    frmDieuChuyenNoiBoCCDC frm = new frmDieuChuyenNoiBoCCDC(maDieuChuyen);
                    frm.ShowDialog();

                }
            }
            catch (Exception ex)
            {

            }

        }
        BaseEdit inplaceEditor;

        private void gridView_DieuChuyenNoiBoCCDCList_ShownEditor(object sender, EventArgs e)
        {
            inplaceEditor = ((GridView)sender).ActiveEditor;

            inplaceEditor.DoubleClick += inplaceEditor_DoubleClick;
        }

        private void gridView_DieuChuyenNoiBoCCDCList_HiddenEditor(object sender, EventArgs e)
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
            this.XemLaiChungTu(view);
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

                _dieuChuyenNoiBoCongCuDungCuList.Save();
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
            if (this.gridView_DieuChuyenNoiBoCCDCList.SelectedRowsCount > 0)
            {
                if (KiemTraTruocCapNhat() ==false) return;
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa trên lưới những dòng đang chọn. Nếu xóa, sau đó cần bấm nut \"[" + btnLuu.Caption + "]\" để lưu lại những thay đổi xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    this.gridView_DieuChuyenNoiBoCCDCList.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng chi tiết cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }





        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmDSDieuChuyenNoiBoCCDC_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ChangeFocus();
            if (_dieuChuyenNoiBoCongCuDungCuList != null && _dieuChuyenNoiBoCongCuDungCuList.IsDirty)
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

        private void gridView_DieuChuyenNoiBoCCDCList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.btnXoa.PerformClick();
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDieuChuyenNoiBoCCDC frm = new frmDieuChuyenNoiBoCCDC();
            frm.Show();
        }

        private void frmDSDieuChuyenNoiBoCCDC_Load(object sender, EventArgs e)
        {
     
            Utils.GridUtils.ConfigGridView(gridView_DieuChuyenNoiBoCCDCList
                         , setSTT: true//
                         , initCopyCell: false
                         , multiSelectCell: false
                         , multiSelectRow: true//
                         , initNewRowOnTop: false);
  
        }






    }
}