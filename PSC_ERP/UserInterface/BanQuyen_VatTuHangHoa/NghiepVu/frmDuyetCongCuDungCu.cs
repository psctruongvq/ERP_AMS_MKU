using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using ERP_Library.Security;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
namespace PSC_ERP
{
    public partial class frmDuyetCongCuDungCu : DevExpress.XtraEditors.XtraForm
    {
        #region Field
        BoPhanList _boPhanListAll = null;
        HangHoaBQ_VTList _hangHoaList = null;
        DuyetCongCuDungCuList _DuyetCongCuDungCuList_Find = null;

        #endregion
        #region Constructor

        public frmDuyetCongCuDungCu()
        {
            InitializeComponent();
            deNgayLapDS.EditValue = DateTime.Now.Date;
            //this.deNgayLap.DateTime = DateTime.Now.Date;
            this.LoadData();
            //Utils.GridUtils.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.gridView_DuyetCongCuDungCuList, this.colDaDuyet).ColumnCheckingEvent += new Utils.GridUtils.BooleanCheckAllBox.ColumnChecking(Duyet_ColumnCheckingEvent);

            this.WindowState = FormWindowState.Maximized;
        }

        void Duyet_ColumnCheckingEvent(object sender, Utils.GridUtils.BooleanCheckAllBox.CheckAllColumnCheckingEventArgs e)
        {
           
        }

        #endregion

        #region Useful Method

        private void TimDanhSachCCDCChoDuyet()
        {
            if (this.radioGroupLoaiNghiepVu.EditValue != null || (int)this.radioGroupLoaiNghiepVu.EditValue != 0)//(repositoryItemGridLookUpEdit_BoPhan.Tag != null)
            {
                //
                int maBoPhan = 0;
                if (this.barEditItem_BoPhan.EditValue != null)
                    maBoPhan = (int)this.barEditItem_BoPhan.EditValue;
                int maHangHoa = 0;

                if (this.barEditItem_HangHoa.EditValue != null)
                    maHangHoa = (int)this.barEditItem_HangHoa.EditValue;

                byte loaiNghiepVu = (byte)radioGroupLoaiNghiepVu.EditValue;

                _DuyetCongCuDungCuList_Find = DuyetCongCuDungCuList.GetDuyetCongCuDungCuList_ChuaThucHienNghiepVu_DuyetHoacChuaDuyet_TheoDieuKien(loaiNghiepVu, maBoPhan, maHangHoa,this.deNgayLapDS.DateTime.Date);
                duyetCongCuDungCuListBindingSource.DataSource = _DuyetCongCuDungCuList_Find;
                if (_DuyetCongCuDungCuList_Find.Count == 0)
                {
                    MessageBox.Show("Danh sách rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else
            {
                MessageBox.Show("Vui lòng chọn nghiệp vụ trước khi tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadData()
        {


            //danh sach hang hoa rong
            _hangHoaList = HangHoaBQ_VTList.NewHangHoaBQ_VTList();
            hangHoaBQVTListBindingSource_forCombo.DataSource = _hangHoaList;

            _boPhanListAll = BoPhanList.GetBoPhanListBy_All();
            BoPhan boPhan_ChonTatCa = BoPhan.NewBoPhan();
            boPhan_ChonTatCa.TenBoPhan = "<<Tất cả>>";
            boPhan_ChonTatCa.MaBoPhanQL = "<<Tất cả>>";
            _boPhanListAll.Insert(0, boPhan_ChonTatCa);
            boPhanListAllBindingSource_forCombo.DataSource = _boPhanListAll;
        }
        public void ChangeFocus()
        {
            this.txtBlackHole1.Focus();
            this.txtBlackHole2.Focus();

        }
        #endregion

        #region Event Method

        private void repositoryItemGridLookUpEdit_BoPhan_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit lookupEdit = sender as GridLookUpEdit;
            int maBoPhan = (int)lookupEdit.EditValue;

            this.barEditItem_HangHoa.EditValue = 0;

            //

            _hangHoaList = HangHoaBQ_VTList.GetHangHoaBQ_VTList_BoPhanDangSuDung(maBoPhan);
            HangHoaBQ_VT hangHoa_ChonTatCa = HangHoaBQ_VT.NewHangHoaBQ_VT();
            hangHoa_ChonTatCa.MaQuanLy = "<<Tất cả>>";
            hangHoa_ChonTatCa.TenHangHoa = "<<Tất cả>>";
            _hangHoaList.Insert(0, hangHoa_ChonTatCa);
            hangHoaBQVTListBindingSource_forCombo.DataSource = _hangHoaList;





        }

        private void repositoryItemGridLookUpEdit_HangHoa_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit lookupEdit = sender as GridLookUpEdit;
            int maBoPhan = (int)lookupEdit.EditValue;

        }




        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ChangeFocus();
            TimDanhSachCCDCChoDuyet();
        }




        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn lưu lại những thay đổi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.ChangeFocus();
                this.Save();
            }
        }
        private bool Save()
        {
            this.ChangeFocus();

            //kiem tra da dien du du lieu can thiet hay chua
            if (this.KiemTraDuDieuKienTruocKhiLuu() == false)
            {
                return false;
            }
            try
            {

                this._DuyetCongCuDungCuList_Find.Save();
                MessageBox.Show("Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private bool KiemTraDuDieuKienTruocKhiLuu()
        {
            bool hopLe = true;

            return hopLe;
        }
        #endregion

        private void gridView_DuyetCongCuDungCuList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gridView_DuyetCongCuDungCuList_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gridView = sender as GridView;

            if (Object.ReferenceEquals(e.Column, this.colDaDuyet))
            {
                if ((bool)e.Value == true)
                {
                    gridView.SetRowCellValue(e.RowHandle, this.colNgayDuyet, DateTime.Today.Date);
                    gridView.SetRowCellValue(e.RowHandle, this.colMaUserDuyet, CurrentUser.Info.UserID);
                }
                else
                {
                    gridView.SetRowCellValue(e.RowHandle, this.colNgayDuyet, DateTime.MaxValue);
                    gridView.SetRowCellValue(e.RowHandle, this.colMaUserDuyet, 0);
                    //MessageBox.Show("Test");
                }

            }

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView_DuyetCongCuDungCuList.SelectedRowsCount > 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa trên lưới những dòng đang chọn. Nếu xóa, sau đó cần bấm nút \"[" + btnLuu.Caption + "]\" để lưu lại những thay đổi xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    this.gridView_DuyetCongCuDungCuList.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmDuyetCongCuDungCu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ChangeFocus();
            if (_DuyetCongCuDungCuList_Find != null && _DuyetCongCuDungCuList_Find.IsDirty)
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

        private void gridView_DuyetCongCuDungCuList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.btnXoa.PerformClick();
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmDuyetCongCuDungCu_Load(object sender, EventArgs e)
        {
            Utils.GridUtils.ConfigGridView(gridView_DuyetCongCuDungCuList
                         , setSTT: true//
                         , initCopyCell: false
                         , multiSelectCell: false
                         , multiSelectRow: false
                         , initNewRowOnTop: false);//

        }

        private void deNgayLapDS_Leave(object sender, EventArgs e)
        {
            if (deNgayLapDS.OldEditValue != deNgayLapDS.EditValue)
            {
                TimDanhSachCCDCChoDuyet();
            }
            
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DuyetCongCuDungCu ccdcC in _DuyetCongCuDungCuList_Find)
            {
                ccdcC.DaDuyet = (bool)repositoryItemCheckEdit1.ValueChecked;
                if ((bool)repositoryItemCheckEdit1.ValueChecked == true)
                {
                    ccdcC.NgayDuyet = DateTime.Today.Date;
                }
            }
            gridView_DuyetCongCuDungCuList.RefreshData();
        }


    }
}