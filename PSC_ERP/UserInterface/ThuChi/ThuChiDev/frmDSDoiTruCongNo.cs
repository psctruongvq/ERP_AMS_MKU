using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using PSC_ERP_Common;

namespace PSC_ERP
{
    public partial class frmDSDoiTruCongNo : DevExpress.XtraEditors.XtraForm
    {
        private TongHopDoiTruCongNo _tongHopDTCN = TongHopDoiTruCongNo.NewTongHopDoiTruCongNo();
        private TongHopDoiTruCongNoList _tongHopDTCNList = TongHopDoiTruCongNoList.NewTongHopDoiTruCongNoList();
        private BindingSource DanhSachDTCNBindingSource = new BindingSource();
        private int _loai = 0;
        public frmDSDoiTruCongNo(int loai)
        {
            InitializeComponent();
            _loai = loai;
            this.Load += frmDSDoiTruCongNo_Load;
            this.btnTim.Click += btnTim_Click;
            this.gridView1.KeyDown += gridView1_KeyDown;
            this.btnThoat.ItemClick += btnThoat_ItemClick;
            this.gridControl1.ViewRegistered += gridControl1_ViewRegistered;
        }

        void gridControl1_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            if (_loai != 3)
            {
                GridView view = e.View as GridView;
                //view.Columns["SoChungTu"].Caption = "Số chứng từ";
                //view.Columns["SoHoaDon"].Caption = "Số hóa đơn";
                //view.Columns["SoTienThanhToan"].Caption = "Tiền Thanh Toán";
                view.OptionsDetail.ShowDetailTabs = false;
                view.Columns["Id"].Visible = false;
                view.Columns["MaChungTu"].Visible = false;
                view.Columns["MaHoaDon"].Visible = false;
                view.Columns["MaButToan"].Visible = false;
                view.Columns["MaPhieuNhapXuat"].Visible = false;
                view.Columns["NguoiLap"].Visible = false;
                view.Columns["TienThue"].Visible = false;
                view.Columns["IdDTCN"].Visible = false;
                view.Columns["HoaDon"].Visible = false;
                view.Columns["NgayLap"].Visible = false;
                HamDungChung.InitGridViewDev(view, false, false, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, false);
                HamDungChung.ShowFieldGridViewDev_Modify(view, new string[] { "SoChungTu", "NgayChungTu", "SoHoaDon", "NgayHoaDon", "SoTienThanhToan" },
                                    new string[] { "Số chứng từ", "Ngày chứng từ", "Số hóa đơn", "Ngày hóa đơn", "Tiền Thanh Toán" },
                                                 new int[] { 80, 80, 80, 80, 80 }, true);
                HamDungChung.AlignHeaderColumnGridViewDev(view, new string[] { "SoChungTu", "NgayChungTu", "SoHoaDon", "NgayHoaDon", "SoTienThanhToan" }, DevExpress.Utils.HorzAlignment.Center);
                HamDungChung.ReadOnlyColumnChoseGridViewDev(view, new string[] { "SoChungTu", "NgayChungTu", "SoHoaDon", "NgayHoaDon", "SoTienThanhToan" });
                HamDungChung.FormatNumberTypeofColumnGridViewDev2(view, new string[] { "SoTienThanhToan" }, "#,###.##");
                //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(view, new string[] { "SoTienThanhToan" }, "{0:#,###.##}");
                Utils.GridUtils.SetSTTForGridView(view, 50);//M
                //RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();

                //repositoryItemCalcEditSoTien.AutoHeight = false;
                //repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
                //repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //repositoryItemCalcEditSoTien.Name = "repositoryItemCalcEditSoTien";
                //view.Columns["SoTienThanhToan"].ColumnEdit = repositoryItemCalcEditSoTien;
                ////
                //HamDungChung.FormatNumberTypeofColumnGridViewDev2(view, new string[] { "SoTienThanhToan" }, "#,###.##");
            }
        }

        void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView1.RowCount > 0)
                {
                    if (gridView1.GetSelectedRows().Length > 0)
                    {
                        if (MessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", gridView1.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            gridView1.DeleteSelectedRows();
                        }
                    }
                }
            }
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            _tongHopDTCNList = TongHopDoiTruCongNoList.GetTongHopDoiTruCongNoListByNgay(dtmp_TuNgay.DateTime.Date, dtm_DenNgay.DateTime.Date, _loai);
            DanhSachDTCNBindingSource.DataSource = _tongHopDTCNList;
            gridControl1.DataSource = DanhSachDTCNBindingSource;
            DesignGrid();
        }

        void frmDSDoiTruCongNo_Load(object sender, EventArgs e)
        {
            dtmp_TuNgay.DateTime = DateTime.Today.Month > 6 ? new DateTime(DateTime.Today.Year, 7, 1) : new DateTime(DateTime.Today.Year - 1, 7, 1);
            dtm_DenNgay.DateTime = DateTime.Today.Month > 6 ? new DateTime(DateTime.Today.Year + 1, 6, 30) : new DateTime(DateTime.Today.Year, 6, 30);

            btnTim_Click(sender, e);
        }

        private void DesignGrid()
        {
            gridView1.OptionsDetail.ShowDetailTabs = false;
            gridControl1.DataSource = DanhSachDTCNBindingSource;
            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "SoPhieu", "NgayLap", "DienGiai", "TenDoiTac", "TongTien" },
                                new string[] { "Số Phiếu", "Ngày Lập", "Diễn Giải", "Tên Đối Tượng", "Tổng Tiền" },
                                             new int[] { 80, 80, 300, 200, 80 }, true);

            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoPhieu", "NgayLap", "DienGiai", "TenDoiTac", "TongTien" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoPhieu", "NgayLap", "DienGiai", "TenDoiTac", "TongTien" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "{0:#,###.##}");
            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M

            RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();

            repositoryItemCalcEditSoTien.AutoHeight = false;
            repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditSoTien.Name = "repositoryItemCalcEditSoTien";
            gridView1.Columns["TongTien"].ColumnEdit = repositoryItemCalcEditSoTien;
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.##");
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (DialogUtil.WaitForSave(this))
                {
                    _tongHopDTCNList.Save();
                    DialogUtil.ShowSaveSuccessful();
                }
            }
            catch (System.Exception ex)
            {
                DialogUtil.ShowNotSaveSuccessful();
            }
        }
    }
}