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
using PSC_ERP_Common.CustomDialog;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
namespace PSC_ERP
{
    public partial class frmXemDSCongCuDungCuChoDuyet : DevExpress.XtraEditors.XtraForm
    {
        #region Field
        BoPhanList _boPhanListAll = null;
        HangHoaBQ_VTList _hangHoaList = null;
        DuyetCongCuDungCuList _DuyetCongCuDungCuList_Find = null;

        #endregion
        #region Constructor

        public frmXemDSCongCuDungCuChoDuyet()
        {
            InitializeComponent();
            this.deNgayLapDS.DateTime = DateTime.Now.Date;
            this.LoadData();
            this.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region Useful Method

        private void LoadData()
        {


            //danh sach hang hoa rong
            _hangHoaList = HangHoaBQ_VTList.NewHangHoaBQ_VTList();
            hangHoaBQVTListBindingSource_forCombo.DataSource = _hangHoaList;

            _boPhanListAll = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();//.GetBoPhanListBy_All();
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

                _DuyetCongCuDungCuList_Find = DuyetCongCuDungCuList.GetDuyetCongCuDungCuList_ChoDuyetTheoDieuKien(loaiNghiepVu, maBoPhan, maHangHoa,deNgayLapDS.DateTime.Date);
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




        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn lưu danh sách", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.ChangeFocus();

                this.Save();
            }
        }
        private bool Save()
        {
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



        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView_DuyetCongCuDungCuList.SelectedRowsCount > 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa trên lưới những dòng đang chọn? Nếu xóa, sau đó cần bấm nút" + this.btnLuu.Caption + " để lưu lại những thay đổi trên lưới xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    this.gridView_DuyetCongCuDungCuList.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void frmXemDSCongCuDungCuChoDuyet_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ChangeFocus();
            if (_DuyetCongCuDungCuList_Find != null && _DuyetCongCuDungCuList_Find.IsDirty == true)
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

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView_DuyetCongCuDungCuList_KeyDown(object sender, KeyEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.KeyCode == Keys.Delete)
            {

                if (gridView.SelectedRowsCount > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa trên lưới những dòng đang chọn? Nếu xóa, sau đó cần bấm nút" + this.btnLuu.Caption + " để lưu lại những thay đổi trên lưới xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        gridView.DeleteSelectedRows();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmXemDSCongCuDungCuChoDuyet_Load(object sender, EventArgs e)
        {

            Utils.GridUtils.ConfigGridView(gridView_DuyetCongCuDungCuList
             , setSTT: true//
             , initCopyCell: false
             , multiSelectCell: false
             , multiSelectRow: true//
             , initNewRowOnTop: false);
        }

        private void btnInDanhSachChoDuyet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int32 nam = 0;
            Int32 maPhongBan = Convert.ToInt32(this.barEditItem_BoPhan.EditValue);

            Int32 loaiNghiepVu = Convert.ToInt32(radioGroupLoaiNghiepVu.EditValue);

            frmDialogChonNam dlgChonNam = new frmDialogChonNam();
            dlgChonNam.ShowDialog(this);

            nam = dlgChonNam.Nam;

            ReportHelper.ShowReport("DanhSachCCDCChoDuyet", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(PSC_ERP_Business.Main.Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_CCDC_DanhSachCCDCChoDuyet", "@MaPhongBan,@LoaiNghiepVu,@Nam,@InChiTiet", maPhongBan, loaiNghiepVu, nam, false);
                #region Extend table
                //Tao Bang Ngay Lap
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("NgayLap", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["NgayLap"] = DateTime.Now.Date;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "SubInfo";
                dataSet.Tables.Add(dtngay);
                #endregion
                return dataSet;
            }, PSC_ERP_Global.CCDC.MaPhanHeCCDC, false, true);
        }




    }
}