using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using DevExpress.XtraEditors.Repository;

namespace PSC_ERP.ThuChiEntity
{
    public partial class frmGhiMucNganSachcuaChiPhiSanXuatE : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        Entities _context = null;
        IQueryable<tblTieuMucNganSach> _tieuMucNganSachList = null;
        List<object> _btMNSDelList = null;
        tblChungTu _chungTu = null;
        tblButToan _butToan = null;
        tblCT_ChiPhiSanXuat _chiPhiSanXuat = null;

        private bool clickgridview = false;
        #endregion//Properties

        #region Methods

        private void KhoiTao()
        {
            tblButToanMucNganSachBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblButToan_MucNganSach);
            tblnsChuongTrinhBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblnsChuongTrinh);
            tblTieuMucNganSachBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTieuMucNganSach);
            gridControl1.DataSource = tblButToanMucNganSachBindingSource;
            DesignGrid();
        }

        private void LoadData()
        {
            List<tblnsChuongTrinh> _chuongTrinhList = NsChuongTrinh_Factory.New().Get_DanhSachChuaHoanTatByMaCongTy(PSC_ERPNew.Main.BasicInfo.User.MaCongTy ?? 0).ToList<tblnsChuongTrinh>();
            tblnsChuongTrinh chuongtrinh_khongChon = new tblnsChuongTrinh() { MaChuongTrinh = 0, TenChuongTrinh = "<<Không chọn>>" };
            _chuongTrinhList.Insert(0, chuongtrinh_khongChon);
            tblnsChuongTrinhBindingSource.DataSource = _chuongTrinhList;
            //lấy danh sách tiểu mục ngân sách
            _tieuMucNganSachList = TieuMucNganSach_Factory.New().GetAll();

            GanBindingSource();
        }

        private void GanBindingSource()
        {

            tblButToanMucNganSachBindingSource.DataSource = _chiPhiSanXuat.tblButToan_MucNganSach;
            tblTieuMucNganSachBindingSource.DataSource = _tieuMucNganSachList;
        }

        private Boolean KiemTraHopLe()
        {
            Boolean hopLe = true;


            return hopLe;
        }

        private void DesignGrid()
        {
            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaTieuMuc", "SoTien", "DienGiai" },
                                new string[] { "Tiểu mục ngân sách", "Số Tiền", "Diễn giải" },
                                             new int[] { 200, 100, 200 });


            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoTien", "MaTieuMuc", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(gridView1,NewItemRowPosition.Bottom);

            Utils.GridUtils.SetSTTForGridView(gridView1, 40);//M

            //Cong Viec/Chuong Trinh
            RepositoryItemGridLookUpEdit mucngansach_grdLU = new RepositoryItemGridLookUpEdit();
            mucngansach_grdLU.DataSource = tblTieuMucNganSachBindingSource;
            mucngansach_grdLU.DisplayMember = "MaQuanLy";
            mucngansach_grdLU.ValueMember = "MaTieuMuc";
            HamDungChung.InitRepositoryItemGridLookUpDev(mucngansach_grdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(mucngansach_grdLU, new string[] { "MaQuanLy", "TenTieuMuc" }, new string[] { "Mã tiểu mục", "Tên tiểu mục", }, new int[] { 120, 250 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaTieuMuc", mucngansach_grdLU);
            //

            //
            RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditSoTien.AutoHeight = false;
            repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["SoTien"].ColumnEdit = repositoryItemCalcEditSoTien;

            //


            HamDungChung.FormatNumberTypeofColumnGridViewDev(gridView1, new string[] { "SoTien" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "#,###.#");

            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            //this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            //this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            //this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);

            this.gridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView1_FocusedColumnChanged);
        }

        private void XoaButToan_MNSdaChon()
        {
            if (gridView1.RowCount > 0)
            {
                if (gridView1.GetSelectedRows().Length > 0)
                {
                    if (XtraMessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", gridView1.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (int i in gridView1.GetSelectedRows())
                        {
                            tblButToan_MucNganSach btmnsDel = _chiPhiSanXuat.tblButToan_MucNganSach.ElementAtOrDefault(i);
                            _btMNSDelList.Add(btmnsDel);
                        }
                        gridView1.DeleteSelectedRows();
                        ButToan_MucNganSach_Factory.FullDeleteButToan_MucNganSach(_context, _btMNSDelList);
                        //ButToan_MucNganSach_Factory.New().DeleteObjectList(gridView1.getrr
                    }
                }
            }
        }


        private void ThietLapChoButToanMucNganSachMoi(tblButToan_MucNganSach butToan_MucNganSach)
        {
            butToan_MucNganSach.DienGiai = _butToan.DienGiai;
            //số tiền trừ dần
            {
                Decimal tongTienMucNganSachKhac = 0;
                //foreach (var item in _butToan.tblButToan_MucNganSach)
                foreach (var item in _chiPhiSanXuat.tblButToan_MucNganSach)
                {
                    if (!Object.ReferenceEquals(item, butToan_MucNganSach))
                        tongTienMucNganSachKhac += item.SoTien;
                }
                butToan_MucNganSach.SoTien = (_chiPhiSanXuat.SoTien ?? 0) - tongTienMucNganSachKhac;

            }
            //_butToan.tblButToan_MucNganSach.Add(butToan_MucNganSach);//ko can nua vi rdViewButToan_MucNganSach da binding truc tiep vo _butToan.tblButToan_MucNganSach
            //gan lien kiet den chi phi san xuat
            //_chiPhiSanXuat.tblButToan_MucNganSach.Add(butToan_MucNganSach);
        }

        #endregion//Methods

        #region EventHandle

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //lấy chi phi san xuat vừa tạo mới trên lưới
            tblButToan_MucNganSach bt_mns = this.gridView1.GetRow(e.RowHandle) as tblButToan_MucNganSach;
            if (bt_mns != null)
                ThietLapChoButToanMucNganSachMoi(bt_mns);
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                XoaButToan_MNSdaChon();
            }

        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (clickgridview)
            {
                if (e.FocusedColumn.FieldName == "MaTieuMuc")
                {
                    gridView1.ShowEditor();
                    ((GridLookUpEdit)gridView1.ActiveEditor).ShowPopup();
                }
            }
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            clickgridview = true;
        }


        #endregion//EventHandle

        #region Events
        private void frmDialogDanhSachGhiMucNganSachTheoButToan_Load(object sender, EventArgs e)
        {
            LoadData();

        }


        private void btnDuaDuLieuVeChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBlackHole.Focus();
            //kiểm tra thông tin

            if (_chiPhiSanXuat.tblButToan_MucNganSach.Count > 0)
            {
                Decimal tongTien = 0;
                foreach (var butToan_MucNganSach in _chiPhiSanXuat.tblButToan_MucNganSach)
                {
                    if ((butToan_MucNganSach.MaTieuMuc ?? 0) == 0)
                    {
                        DialogUtil.ShowError("Có dòng ghi mục ngân sách chưa chọn tiểu mục");
                        return;
                    }
                    else if (butToan_MucNganSach.SoTien == 0)
                    {
                        DialogUtil.ShowError("Có dòng ghi mục ngân sách số tiền = 0!");
                        return;
                    }
                    tongTien += butToan_MucNganSach.SoTien;
                }
                //
                if (tongTien != _chiPhiSanXuat.SoTien)// && _butToan.tblButToan_MucNganSach.Any())//.Count > 0)
                {
                    DialogUtil.ShowError("Tổng tiền ghi mục ngân sách không bằng tiền chi phí");
                    return;
                }
            }

            this.Close();

        }


        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tblButToan_MucNganSach butToan_MucNganSachNew = ButToan_MucNganSach_Factory.New().CreateAloneObject();

            ////_butToan.tblButToan_MucNganSach.Add(butToan_MucNganSachNew);
            //_chiPhiSanXuat.tblButToan_MucNganSach.Add(butToan_MucNganSachNew);
            //tblButToanMucNganSachBindingSource.Add(butToan_MucNganSachNew);
            //tblButToanMucNganSachBindingSource.MoveLast();  
            //ThietLapChoButToanMucNganSachMoi(butToan_MucNganSachNew);
        }


        private void tbnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XoaButToan_MNSdaChon();
        }

        #endregion//Events

        #region Constructors

        public frmGhiMucNganSachcuaChiPhiSanXuatE()
        {
            InitializeComponent();
        }
        public frmGhiMucNganSachcuaChiPhiSanXuatE(Entities context, tblChungTu chungTu, tblButToan butToan, tblCT_ChiPhiSanXuat chiPhiSanXuat)
        {
            InitializeComponent();
            KhoiTao();
            _context = context;
            _chungTu = chungTu;
            _butToan = butToan;
            _chiPhiSanXuat = chiPhiSanXuat;

            _btMNSDelList = new List<object>();

            #region BS
            txtSoTien.EditValue = _chiPhiSanXuat.SoTien;
            grdLUChuognTrinh.EditValue = _chiPhiSanXuat.MaChuongTrinh;
            #endregion//BS
        }

        #endregion//Constructors


















    }
}