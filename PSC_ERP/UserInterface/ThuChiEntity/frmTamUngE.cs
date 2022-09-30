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
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using PSC_ERP_Common.Ado.Net;
using PSC_ERPNew.Main.Reports;
using System.Data.Objects;
using System.Linq;
using PSC_ERP_Business.Main.Model.Context;
//26_04_2014
namespace PSC_ERP.ThuChiEntity
{
    public partial class frmTamUng : DevExpress.XtraEditors.XtraForm
    {

        #region properties

        Entities _context = null;
        tblChungTu _chungTu = null;
        static List<tblTamUng> _tamUngListFirst = null;

        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        List<sp_AllDoiTuong_Result> _doiTuongList = null;
        List<tblnsChuongTrinh> _chuongTrinhList = null;

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
            tblBoPhanERPNewBindingSource.DataSource = typeof(tblBoPhanERPNew);
            tblnsChuongTrinhBindingSource.DataSource = typeof(tblnsChuongTrinh);
            TamUngbindingSource.DataSource = typeof(tblTamUng);
            AllDoiTuong_bindingSource.DataSource = typeof(sp_AllDoiTuong_Result);
            gridControl1.DataSource = TamUngbindingSource;
            DesignGrid();
        }

        private void LoadDaTa()
        {
            _doiTuongList = new List<sp_AllDoiTuong_Result>();
            _doiTuongList = _context.sp_AllDoiTuong(0).Where(x => x.MaCongTy == _maCongTy).ToList();
            sp_AllDoiTuong_Result doituong = new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "<<không chọn>>" };
            _doiTuongList.Insert(0, doituong);
            AllDoiTuong_bindingSource.DataSource = _doiTuongList;

            _chuongTrinhList = NsChuongTrinh_Factory.New().GetAll().ToList();
            tblnsChuongTrinh chuongtrinh_khongChon = new tblnsChuongTrinh() { MaChuongTrinh = 0, TenChuongTrinh = "<<Không chọn>>" };
            _chuongTrinhList.Insert(0, chuongtrinh_khongChon);
            tblnsChuongTrinhBindingSource.DataSource = _chuongTrinhList;
            //tblBoPhanERPNewBindingSource.DataSource = BoPhanERPNew_Factory.New().GetAll();
        }
        private void bindingValue()
        {
            TamUngbindingSource.DataSource = _chungTu.tblTamUngs;
            loaiChungTu = _chungTu.MaLoaiChungTu;
            dienGiai = _chungTu.DienGiai;
            NgayLap = _chungTu.NgayLap.Value;

            this.SoTienDefault = _chungTu.tblTienTe.ThanhTien.Value;
            this.MaDoiTuongDefault = (_chungTu.MaDoiTuong== null ? 0 : _chungTu.MaDoiTuong.Value);
            int maBoPhanCha = ERP_Library.Security.CurrentUser.Info.MaBoPhanCha;
        }

        private void DesignGrid()
        {
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

            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            //this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);

            //this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
        }

        private void setvaluesDefault(tblTamUng tamung)
        {
            decimal soTienDaNhap = 0;
            foreach (tblTamUng tu in _chungTu.tblTamUngs)
            {
                soTienDaNhap += tu.SoTien.Value;
            }
            tamung.LoaiChungTu = loaiChungTu;
            tamung.MaDoiTuong = MaDoiTuongDefault;
            tamung.DienGiai = dienGiai;
            tamung.NgayLap = NgayLap;
            tamung.SoTien = SoTienDefault - soTienDaNhap;
            tamung.SoTienBangChu = HamDungChung.DocTien(tamung.SoTien.Value);

            tamung.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        }

        private Boolean HopLe()
        {
            #region Kiem tra Tongtien Chungtu với TongIienCTamUng
            if (_chungTu.tblTamUngs.Count > 0)
            {
                decimal tongtienTU = 0;
                foreach (var tu in _chungTu.tblTamUngs)
                {
                    #region BS
                    if ((tu.MaDoiTuong ?? 0) == 0)
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


                    tongtienTU += tu.SoTien.Value;
                }
                //if (tongtienTU != SoTienDefault)
                //{
                //    DialogUtil.ShowError("Tổng tiền tạm ứng không bằng tổng tiền chứng từ!");
                //    return false;
                //}
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
                        foreach (int i in gridView1.GetSelectedRows())
                        {
                            tblTamUng tamungDel = _chungTu.tblTamUngs.ElementAtOrDefault(i);
                            _tamungDelList.Add(tamungDel);
                        }
                        gridView1.DeleteSelectedRows();
                        TamUng_Factory.FullDelete(_context, _tamungDelList);
                    }
                }
            }
        }
        #endregion

        #region EventHandle
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //lấy tam ứng vừa tạo mới trên lưới
            tblTamUng tamung = this.gridView1.GetRow(e.RowHandle) as tblTamUng;
            if (tamung != null)
                setvaluesDefault(tamung);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            tblTamUng currenttamung = (tblTamUng)TamUngbindingSource.Current;
            if (gridView1.FocusedColumn.FieldName == "SoTien")
            {
                currenttamung.SoTienBangChu = HamDungChung.DocTien(currenttamung.SoTien.Value);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
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
        public frmTamUng()
        {
            InitializeComponent();
        }

        public frmTamUng(Entities context, tblChungTu chungtu)
        {
            InitializeComponent();
            KhoiTao();
            _context = context;
            _chungTu = chungtu;
            _tamUngListFirst = _chungTu.tblTamUngs.ToList();
            _tamungDelList = new List<object>();
        }
        #endregion//Constructors

        #region Events
        private void frmTamUng_Load(object sender, EventArgs e)
        {

            LoadDaTa();
            bindingValue();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _chungTu.tblTamUngs.Clear();
            foreach (tblTamUng tu in _tamUngListFirst)
            {
                _chungTu.tblTamUngs.Add(tu);
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTamUng_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult kq = MessageBox.Show("Bạn thật sự muốn thoát không lưu?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //if (kq == DialogResult.Cancel)
            //{
            //    e.Cancel = true;
            //}
            //else if (kq == DialogResult.OK)
            //{
            //    tlslblUndo.PerformClick();
            //}
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            tblTamUng tu = TamUng_Factory.New().CreateAloneObject();
            setvaluesDefault(tu);
            _chungTu.tblTamUngs.Add(tu);
            TamUngbindingSource.DataSource = _chungTu.tblTamUngs;

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtFocus.Focus();
            if (HopLe())
            {
                _tamUngListFirst = _chungTu.tblTamUngs.ToList();
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