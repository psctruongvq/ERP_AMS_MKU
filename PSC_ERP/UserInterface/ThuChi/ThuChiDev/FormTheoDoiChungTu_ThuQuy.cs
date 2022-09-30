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
//13/04/2013
namespace PSC_ERP
{
    public partial class FormTheoDoiChungTu_ThuQuy : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        ChungTu_TheoDoiList _chungTuTheoDoiList = ChungTu_TheoDoiList.NewChungTu_TheoDoiList();
        ChungTu_TheoDoiList _chungTuTheoDoiListSelected = ChungTu_TheoDoiList.NewChungTu_TheoDoiList();
        DateTime _tuNgay; DateTime _denNgay;

        #endregion//Properties

        private void DesignGridView1()
        {
            #region Design ChungTu_HoaDon
            gridControl1.DataSource = ChungTuTheoDoiList_BindingSource;

            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, true, true);


            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "HoanTat", "TenDoiTuong", "NgayLapChungTu", "PhieuThu", "PhieuChi", "SoTienChungTu", "SoTienThuChi", "SoTienConLai", "LoaiThuChi", "NgayChiTien", "DienGiaiChungTu", "GhiChu" },
                                new string[] { "Hoàn Tất", "Đối Tượng", "Ngày Lập CT", "Phiếu Thu", "Phiếu Chi", "Số Tiền CT", "Tiền Đã Thu/Chi", "Số Tiền Còn Lại", "Loại Thu Chi", "Ngày Thu/Chi", "Diễn Giải CT", "Diễn Giải" },
                                             new int[] { 80, 120, 90, 90, 90, 95, 110,95, 95, 90, 120, 120 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "HoanTat", "TenDoiTuong", "NgayLapChungTu", "PhieuThu", "PhieuChi", "SoTienChungTu", "SoTienThuChi", "SoTienConLai", "LoaiThuChi", "NgayChiTien", "DienGiaiChungTu", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTienChungTu", "SoTienThuChi", "SoTienConLai" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTienChungTu", "SoTienThuChi", "SoTienConLai" }, "{0:#,###.#}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "TenDoiTuong", "NgayLapChungTu", "PhieuThu", "PhieuChi", "SoTienChungTu", "SoTienThuChi", "SoTienConLai", "LoaiThuChi", "DienGiaiChungTu" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "HoanTat", "NgayChiTien", "GhiChu" });
            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M

            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            #endregion//Design ChungTu_HoaDon

        }

        private void loadForm()
        {
            ChungTuTheoDoiList_BindingSource.DataSource = typeof(ChungTu_TheoDoiList);
            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
            LoadData();
            DesignGridView1();
        }
        private void GetThongTinTimKiem()
        {
            _tuNgay = (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date;
            _denNgay = (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date;
        }
        private void LoadData()
        {
            GetThongTinTimKiem();
            _chungTuTheoDoiList = ChungTu_TheoDoiList.GetChungTu_TheoDoiList(_tuNgay, _denNgay);
            this.ChungTuTheoDoiList_BindingSource.DataSource = _chungTuTheoDoiList;
        }
        public FormTheoDoiChungTu_ThuQuy()
        {
            InitializeComponent();
            loadForm();

        }


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FocustextBox1.Focus();
            ChungTuTheoDoiList_BindingSource.EndEdit();
            //foreach (ChungTu_TheoDoi ct_td in _chungTuTheoDoiList)
            //{
            //    if (ct_td.HoanTat == true)
            //    {
            //        ct_td.SoTienDaChi = ct_td.SoTienChungTu;
            //        ct_td.SoTienConLai = 0;
            //    }
            //}
            try
            {
                _chungTuTheoDoiList.ApplyEdit();
                _chungTuTheoDoiList.Save();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            HoaDon hd = (HoaDon)ChungTuTheoDoiList_BindingSource.Current;
            CheckEdit check = (CheckEdit)sender;
            hd.Check = (bool)check.EditValue;

        }

        #region Events Handle
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (gridView1.FocusedColumn.Name == "colHoanTat")
            {
                gridView1.SetRowCellValue(e.RowHandle, gridView1.FocusedColumn, !(bool)e.CellValue);
                //GridView gridv = (GridView)sender;
                //gridv.UpdateColumnsCustomization();
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gridView1.FocusedColumn.Name == "colHoanTat")
            {
                if (gridView1.GetFocusedRow() != null)
                {
                    ChungTu_TheoDoi ct_td = (ChungTu_TheoDoi)gridView1.GetFocusedRow();
                    if (ct_td.HoanTat == true)
                    {
                        ct_td.SoTienDaChi = ct_td.SoTienChungTu;
                        ct_td.SoTienConLai = 0;
                        ct_td.SoTienThuChi = ct_td.SoTienChungTu;
                    }
                    else
                    {
                        ct_td.SoTienDaChi = 0;
                        ct_td.SoTienConLai = ct_td.SoTienChungTu;
                        ct_td.SoTienThuChi = 0;
                    }
                }
            }
            gridView1.UpdateCurrentRow();
        }
        #endregion//Events Handle

        private void barbtnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
            if (_chungTuTheoDoiList.Count < 1)
            {
                MessageBox.Show("Danh sách tìm kiếm rỗng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




    }
}