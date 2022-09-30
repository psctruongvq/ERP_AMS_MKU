using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmBoPhanMoRong_NhanVien : DevExpress.XtraEditors.XtraForm
    {
        BoPhanMoRong_NhanVienList _boPhanMoRong_NhanVienList = null;
        bool _chonTrungNhanVien = false;
        public frmBoPhanMoRong_NhanVien()
        {
            InitializeComponent();
            this.LoadData();
        }
        #region Useful Method
        private bool Save()
        {
            this.ChangeFocus();
            if (KiemTraHopLeTruocKhiLuu())
            {
                try
                {
                    _boPhanMoRong_NhanVienList.Save();
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Lưu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
                return false;
        }//end function

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }
        private void LoadData()
        {
            //ThongTinNhanVienTongHopList

            boPhanMoRongListBindingSource.DataSource = BoPhanMoRongList.GetBoPhanMoRongList();
            thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
        }
        #endregion
        #region Button

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BoPhanMoRong_NhanVien item = BoPhanMoRong_NhanVien.NewBoPhanMoRong_NhanVien(maNhanVien: 0, maBoPhanMoRong: (this.boPhanMoRongListBindingSource.Current as BoPhanMoRong).MaBoPhanMoRong);
            item.NgayLap = DateTime.Today;
            _boPhanMoRong_NhanVienList.Insert(0, item);
            this.gridViewNhanVienThuocBoPhanMoRong.Focus();

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridViewNhanVienThuocBoPhanMoRong.SelectedRowsCount > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa trên lưới những dòng đang chọn. Nếu xóa, sau đó cần bấm nut \"[" + btnLuu.Caption + "]\" để lưu lại những thay đổi xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    this.gridViewNhanVienThuocBoPhanMoRong.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng chi tiết cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool KiemTraHopLeTruocKhiLuu()
        {
            if (_boPhanMoRong_NhanVienList == null)
            {
                return false;
            }
            else
            {
                //kiem tra da chon nhan vien chua
                foreach (BoPhanMoRong_NhanVien item in _boPhanMoRong_NhanVienList)
                {
                    if (item.MaNhanVien == 0)
                    {
                        MessageBox.Show("Có dòng dữ liệu chưa chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
            return true;
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn lưu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.Save();
            }

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Grid

        private void gridViewNhanVienThuocBoPhanMoRong_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridViewNhanVienThuocBoPhanMoRong.SetRowCellValue(e.RowHandle, this.colMaBoPhanMoRong1, (this.boPhanMoRongListBindingSource.Current as BoPhanMoRong).MaBoPhanMoRong);
            gridViewNhanVienThuocBoPhanMoRong.SetRowCellValue(e.RowHandle, this.colNgayLap_NgayDuaNhanVienVaoBoPhanMoRong, DateTime.Today);
        }//end function




        private void gridViewNhanVienThuocBoPhanMoRong_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            //this.gridViewNhanVienThuocBoPhanMoRong.RowCount
            //this.gridViewNhanVienThuocBoPhanMoRong.GetRowCellValue()
            if (object.ReferenceEquals(e.Column, this.colTenNhanVien))
            {
                _chonTrungNhanVien = false;
                long maNhanVien = (long)e.Value;
                for (int i = 0; i < this.gridViewNhanVienThuocBoPhanMoRong.RowCount; i++)
                {
                    if (i != e.RowHandle)
                    {
                        if ((long)(this.gridViewNhanVienThuocBoPhanMoRong.GetRowCellValue(i, this.colTenNhanVien)) == maNhanVien)
                        {
                            _chonTrungNhanVien = true;
                            MessageBox.Show("Nhân viên đã có trong danh sách! Vui lòng chọn nhân viên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                    }
                }
                SendKeys.Send("{Tab}{Tab}{Tab}");
            }

        }
        private void gridViewNhanVienThuocBoPhanMoRong_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (object.ReferenceEquals(e.Column, this.colTenNhanVien))
            {
                if (_chonTrungNhanVien)
                {
                    _chonTrungNhanVien = false;
                    this.gridViewNhanVienThuocBoPhanMoRong.SetRowCellValue(e.RowHandle, this.colTenNhanVien, 0);
                    this.ChangeFocus();
                }
            }
        }
        #endregion
        #region Tree

        private void treeListBoPhanMoRong_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            if (_boPhanMoRong_NhanVienList != null && (_boPhanMoRong_NhanVienList.IsDirty))
            {
                DialogResult result = MessageBox.Show("Bạn cần lưu lại những thay đổi trên lưới! Chọn Yes để lưu, chọn No sẽ hủy những thay đổi vừa thao tác trên lưới", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {

                    if (this.Save() == false)
                        e.CanFocus = false;
                }
                else if (DialogResult.Cancel == result)
                {
                    e.CanFocus = false;
                }
            }
        }

        private void treeListBoPhanMoRong_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }
        private void treeListBoPhanMoRong_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {

            BoPhanMoRong bpmr = boPhanMoRongListBindingSource.Current as BoPhanMoRong;
            _boPhanMoRong_NhanVienList = BoPhanMoRong_NhanVienList.GetBoPhanMoRong_NhanVienList(bpmr.MaBoPhanMoRong);
            boPhanMoRongNhanVienListBindingSource.DataSource = _boPhanMoRong_NhanVienList;
            this.gridViewNhanVienThuocBoPhanMoRong.GroupPanelText = String.Format("Danh sách nhân viên thuộc bộ phận mở rộng {0}:{1}", bpmr.MaQuanLy, bpmr.TenBoPhanMoRong);
        }
        #endregion
        #region Form event
        private void frmBoPhanMoRong_NhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_boPhanMoRong_NhanVienList != null && (_boPhanMoRong_NhanVienList.IsDirty))
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
        #endregion

        private void frmBoPhanMoRong_NhanVien_Load(object sender, EventArgs e)
        {
            Utils.GridUtils.ConfigGridView(gridViewNhanVienThuocBoPhanMoRong
                , setSTT: true//
                , initCopyCell: true//
                , multiSelectCell: true//
                , multiSelectRow: false
                , initNewRowOnTop: true);//
        }


    }//end class
}//end namespace