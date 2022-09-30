using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Diagnostics;
using System.IO;

using PSC_ERP_Business.Main;
using PSC_ERP_Common;
using PSC_ERP_Common.Ado.Net;
using PSC_ERPNew.Main.Reports;
//26_04_2014
namespace PSC_ERP
{
    public partial class frmTamUng_Dev : DevExpress.XtraEditors.XtraForm
    {

        #region properties
        ChungTu _chungTu = null;
        static TamUngList _tamUngListFirst = null;

        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        DoiTuongAllList _doiTuongList = null;
        ChuongTrinhList _chuongTrinhList = null;

        List<object> _tamungDelList;

        long maChungTu = 0;
        int loaiChungTu = 0;
        int loaiThuChi = 0;
        public static decimal ThanhTien = 0;
        public bool IsSave = false;
        public static int MaChuongTrinh = 0;
        string dienGiai = string.Empty;
        public DateTime NgayLap;
        long MaDoiTuongDefault = 0;
        decimal SoTienDefault = 0;

        #endregion
        #region Function
        private void KhoiTao()
        {
            //   tblChungTuBindingSource_Single.DataSource = typeof(PSC_ERP_Business.Main.Model.tblChungTu);
            tblBoPhanERPNewBindingSource.DataSource = typeof(BoPhanList);
            tblnsChuongTrinhBindingSource.DataSource = typeof(ChuongTrinhList);
            TamUngbindingSource.DataSource = typeof(TamUngList);
            AllDoiTuong_bindingSource.DataSource = typeof(DoiTuongAllList);
            gridControl1.DataSource = TamUngbindingSource;
            DesignGrid();
        }

        private void LoadDaTa()
        {
            _doiTuongList = DoiTuongAllList.NewDoiTuongAllList();
            //_doiTuongList = _context.sp_AllDoiTuong(0).Where(x => x.MaCongTy == _maCongTy).ToList();
            //sp_AllDoiTuong_Result doituong = new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "<<không chọn>>" };
            //_doiTuongList.Insert(0, doituong);
            _doiTuongList = DoiTuongAllList.GetDoiTuongAllList_Tim("",0);
            DoiTuongAll doituong = DoiTuongAll.NewDoiTuongAll("<<None>>");
            AllDoiTuong_bindingSource.DataSource = _doiTuongList;

            //_chuongTrinhList = NsChuongTrinh_Factory.New().GetAll().ToList();
            //tblnsChuongTrinh chuongtrinh_khongChon = new tblnsChuongTrinh() { MaChuongTrinh = 0, TenChuongTrinh = "<<Không chọn>>" };
            //_chuongTrinhList.Insert(0, chuongtrinh_khongChon);
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("<<None>>");
            _chuongTrinhList.Insert(0, itemChuongTrinh);
            tblnsChuongTrinhBindingSource.DataSource = _chuongTrinhList;
        }
        private void bindingValue()
        {
            TamUngbindingSource.DataSource = _chungTu.TamUngList;
            loaiChungTu = _chungTu.LoaiChungTu.MaLoaiCT;
            dienGiai = _chungTu.DienGiai;
            NgayLap = _chungTu.NgayLap;

            this.SoTienDefault = _chungTu.Tien.ThanhTien;
            this.MaDoiTuongDefault = (_chungTu.DoiTuong== null ? 0 : _chungTu.DoiTuong);
            int maBoPhanCha = ERP_Library.Security.CurrentUser.Info.MaBoPhanCha;
        }

        private void DesignGrid()
        {
            //HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaDoiTuong", "SoTien", "MaChuongTrinh" },
                                new string[] { "Tên Khách Hàng", "Số Tiền", "Tên Chương Trinh" },
                                             new int[] { 150, 100, 150 });


            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaDoiTuong", "SoTien", "MaChuongTrinh" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(gridView1,NewItemRowPosition.Bottom);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M

            //
            RepositoryItemGridLookUpEdit DoiTuongNo_grdLU = new RepositoryItemGridLookUpEdit();
            DoiTuongNo_grdLU.DataSource = AllDoiTuong_bindingSource;
            DoiTuongNo_grdLU.DisplayMember = "TenDoiTuong";
            DoiTuongNo_grdLU.ValueMember = "MaDoiTuong";
            HamDungChung.InitRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaDoiTuong", DoiTuongNo_grdLU);
            //

            //
            RepositoryItemGridLookUpEdit ChuongTrinh_GrdLU = new RepositoryItemGridLookUpEdit();
            ChuongTrinh_GrdLU.DataSource = tblnsChuongTrinhBindingSource;
            ChuongTrinh_GrdLU.DisplayMember = "TenChuongTrinh";
            ChuongTrinh_GrdLU.ValueMember = "MaChuongTrinh";
            HamDungChung.InitRepositoryItemGridLookUpDev(ChuongTrinh_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(ChuongTrinh_GrdLU, new string[] { "MaQL", "TenChuongTrinh", "TenNguon" }, new string[] { "Mã QL", "Tên Chương Trình", "Tên nguồn" }, new int[] { 100, 200, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaChuongTrinh", ChuongTrinh_GrdLU);
            //


            HamDungChung.FormatNumberTypeofColumnGridViewDev(gridView1, new string[] { "SoTien" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "#,###.#");

            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            //this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);

            //this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
        }

        private void setvaluesDefault(TamUng tamung)
        {
            decimal soTienDaNhap = 0;
            foreach (TamUng tu in _chungTu.TamUngList)
            {
                soTienDaNhap += tu.SoTien;
            }
            tamung.LoaiChungTu = loaiChungTu;
            tamung.MaDoiTuong = MaDoiTuongDefault;
            tamung.DienGiai = dienGiai;
            tamung.NgayLap = NgayLap;
            tamung.SoTien = SoTienDefault - soTienDaNhap;
            //tamung.SoTienBangChu = HamDungChung.DocTien(tamung.SoTien);

            tamung.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        }

        private Boolean HopLe()
        {
            #region Kiem tra Tongtien Chungtu với TongIienCTamUng
            if (_chungTu.TamUngList.Count > 0)
            {
                decimal tongtienTU = 0;
                foreach (var tu in _chungTu.TamUngList)
                {
                    #region BS
                    if (tu.MaDoiTuong == 0)
                    {
                        DialogUtil.ShowError("Có dòng chưa chọn đối tượng tạm ứng!");
                        return false;
                    }
                    else if (tu.SoTien == 0)
                    {
                        DialogUtil.ShowError("Có dòng có Số tiền =0!");
                        return false;
                    }
                    #endregion//BS


                    tongtienTU += tu.SoTien;
                }
            }
            #endregion//Kiem tra Tongtien Chungtu với TongIienCTamUng
            return true;
        }

        private void XoaTamUngdaChon()
        {
            if (gridView1.RowCount > 0)
            {
                if (gridView1.GetSelectedRows().Length > 0)
                {
                    if (XtraMessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", gridView1.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //foreach (int i in gridView1.GetSelectedRows())
                        //{
                        //    TamUng tamungDel = _chungTu.TamUngList[i];//.ElementAtOrDefault(i);
                        //    _tamungDelList.Add(tamungDel);
                        //}
                        gridView1.DeleteSelectedRows();
                        //TamUng_Factory.FullDelete(_context, _tamungDelList);
                    }
                }
            }
        }
        #endregion

        #region EventHandle
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //lấy tam ứng vừa tạo mới trên lưới
            TamUng tamung = this.gridView1.GetRow(e.RowHandle) as TamUng;
            if (tamung != null)
                setvaluesDefault(tamung);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //TamUng currenttamung = (TamUng)TamUngbindingSource.Current;
            //if (gridView1.FocusedColumn.FieldName == "SoTien")
            //{
            //currenttamung.SoTienBangChu = HamDungChung.DocTien(currenttamung.SoTien);
            //}
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (gridView1.IsNewItemRow(e.RowHandle))
            {
                if (gridView1.GetRow(e.RowHandle) == null)
                    gridView1.AddNewRow();
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                XoaTamUngdaChon();
            }

        }
        #endregion

        #region Constructors
        public frmTamUng_Dev()
        {
            InitializeComponent();
        }

        public frmTamUng_Dev( ChungTu chungtu)
        {
            InitializeComponent();
            KhoiTao();
            _chungTu = chungtu;
            _tamUngListFirst = _chungTu.TamUngList;
        }
        #endregion//Constructors

        #region Events
        private void frmTamUng_Dev_Load(object sender, EventArgs e)
        {

            LoadDaTa();
            bindingValue();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _chungTu.TamUngList.Clear();
            foreach (TamUng tu in _tamUngListFirst)
            {
                _chungTu.TamUngList.Add(tu);
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTamUng_Dev_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            TamUng tu = TamUng.NewTamUng();
            setvaluesDefault(tu);
            _chungTu.TamUngList.Add(tu);
            TamUngbindingSource.DataSource = _chungTu.TamUngList;

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtFocus.Focus();
            if (HopLe())
            {
                this.TamUngbindingSource.EndEdit();
                gridControl1.Update();//.UpdateData();
                _chungTu.TamUngList.ApplyEdit();
                IsSave = true;
                this.Close();     

                _tamUngListFirst = _chungTu.TamUngList;
                this.Close();
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XoaTamUngdaChon();
            //HamDungChung.DeleteSelectedRowsGridViewDev(gridView1);
        }

        #endregion//Events







    }
}