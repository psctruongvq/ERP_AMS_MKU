using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace PSC_ERP
{
    public partial class FrmKetXuatThuLaoChuongTrinh : DevExpress.XtraEditors.XtraForm
    {
        int _maChuongTrinh = 0;
        int _loaiThuLao = 1;
        string _diengiai = "";
        int _maCongTyCurrent = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        ChuongTrinh_NewList _chuongTrinh_NewList = ChuongTrinh_NewList.NewChuongTrinh_NewList();

        public FrmKetXuatThuLaoChuongTrinh()
        {
            InitializeComponent();
            LoadForm();
        }

        public static void InitGridView(GridView grid, bool autoFilter, bool multiSelect,
            GridMultiSelectMode selectMode, bool detailButton, bool groupPanel,
            bool showAutoFilterRow, bool showFooter)
        {
            //Show filter
            grid.OptionsView.ShowAutoFilterRow = autoFilter;
            //Show multi select
            grid.OptionsSelection.MultiSelect = multiSelect;
            //Show multi select mode
            grid.OptionsSelection.MultiSelectMode = selectMode;
            //Show detail button
            grid.OptionsView.ShowDetailButtons = detailButton;
            //Show group panel
            grid.OptionsView.ShowGroupPanel = groupPanel;
            //Show auto filter row
            grid.OptionsView.ShowAutoFilterRow = showAutoFilterRow;
            //Show footer
            grid.OptionsView.ShowFooter = showFooter;

            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].Visible = false;
        }//End InitGridView

        public static void ShowField(GridView grid, string[] fieldName, string[] caption, int[] width)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].Visible = false;

            grid.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].VisibleIndex = i;
                grid.Columns[fieldName[i]].Visible = true;
                grid.Columns[fieldName[i]].Caption = caption[i];
                grid.Columns[fieldName[i]].Width = width[i];
                grid.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }

        public static void FormatGridColumnNumber(GridView grid, string[] fieldName)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].DisplayFormat.FormatString = "#,###";
                grid.Columns[fieldName[i]].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            }

        }

        public static void ShowGridColumnSummaryFooter(GridView grid, string[] fieldName)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, fieldName[i], "{0:N0}")});
            }
        }

        public static void ReadOnlyColumn(GridView grid)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].OptionsColumn.AllowEdit = false;
        }

        public static void AlignHeader(GridView grid, string[] fieldName, DevExpress.Utils.HorzAlignment align)
        {
            for (int i = 0; i < fieldName.Length; i++)
                grid.Columns[fieldName[i]].AppearanceHeader.TextOptions.HAlignment = align;
        }

        private void FormatGridBaoCaoTongHop(GridView gridV)
        {
            ////MaChuongTrinh,MaQL, TenChuongTrinh, SoTien, TienThue, TienSauThue, DienGiai, NguoiLap,TenNguoiLap, NgayNhap
            InitGridView(gridV, false, false, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, true, true, true);
            FormatGridColumnNumber(gridV, new string[] { "SoTien", "TienThue", "TienSauThue" });
            ShowField(gridV, new string[] { "MaQL", "TenChuongTrinh", "SoTien", "TienThue", "TienSauThue"},
                                new string[] { "Mã Chương Trình", "Tên Chương Trình", "Số Tiền", "Tiền Thuế", "Tiền Sau Thuế"},
                                             new int[] { 150, 300, 100, 100, 100});
            ReadOnlyColumn(gridV);
            AlignHeader(gridV, new string[] { "MaQL", "TenChuongTrinh", "SoTien", "TienThue", "TienSauThue"}, DevExpress.Utils.HorzAlignment.Center);
            ShowGridColumnSummaryFooter(gridV, new string[] { "SoTien", "TienThue", "TienSauThue" });
            
            Utils.GridUtils.SetSTTForGridView(gridV, 50);//M

        }

        private void FormatGridBaoCaoChiTiet(GridView gridV)
        {
            ////MaChuongTrinh,MaQL, TenChuongTrinh, SoTien, TienThue, TienSauThue, DienGiai, NguoiLap,TenNguoiLap, NgayNhap
            InitGridView(gridV, false, false, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, true, true, true);
            FormatGridColumnNumber(gridV, new string[] { "SoTien", "TienThue", "TienSauThue" });
            ShowField(gridV, new string[] { "MaQL", "TenChuongTrinh", "SoTien", "TienThue", "TienSauThue", "DienGiai", "TenNguoiLap", "TenNhanVien", "NgayLap" },
                                new string[] { "Mã Chương Trình", "Tên Chương Trình", "Số Tiền", "Tiền Thuế", "Tiền Sau Thuế", "Diễn Giải", "Người Lập", "Nhân Viên", "Ngày Nhập" },
                                             new int[] { 125, 250, 100, 100, 100, 250, 100, 100, 75 });
            ReadOnlyColumn(gridV);
            AlignHeader(gridV, new string[] { "MaQL", "TenChuongTrinh", "SoTien", "TienThue", "TienSauThue", "DienGiai", "TenNguoiLap", "TenNhanVien", "NgayLap" }, DevExpress.Utils.HorzAlignment.Center);
            ShowGridColumnSummaryFooter(gridV, new string[] { "SoTien", "TienThue", "TienSauThue" });
            
            Utils.GridUtils.SetSTTForGridView(gridV, 50);//M

        }


        private string TenLoaiThuLao()
        {
            string tenLoaiThuLao = "";
            if (_loaiThuLao == 3)
                tenLoaiThuLao = " - Tiền mặt";
            else if (_loaiThuLao == 2)
                tenLoaiThuLao = " - Chuyển khoản";
            return tenLoaiThuLao;
        }

        private void LoadForm()
        {
            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;

            _chuongTrinh_NewList = ChuongTrinh_NewList.GetChuongTrinh_NewList();
            ChuongTrinh_New ct0 = ChuongTrinh_New.NewChuongTrinh_New("Không Chọn");
            _chuongTrinh_NewList.Insert(0, ct0);
            chuongTrinh_NewListAllBindingSource.DataSource = _chuongTrinh_NewList;

            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
            cbLoaiThuLao.Value = 1;



        }



        private void btn_BaoCaoTongHop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView2.Columns.Clear();
            DataTable _daTaKetXuatThuLao = new DataTable();
            
           

            _diengiai = txt_DienGiai.Text.Trim();

            if (checkEdit_Ngay.Checked == true)
            {
                DateTime tuNgay = Convert.ToDateTime(dtEdit_TuNgay.EditValue).Date;
                DateTime denNgay = Convert.ToDateTime(dtEdit_DenNgay.EditValue).Date;
                _daTaKetXuatThuLao = KetXuatThuLaoChuongTrinh.GetKetXuatThuLaoChuongTrinhTheoNgay(tuNgay, denNgay, _maChuongTrinh, _diengiai, _loaiThuLao);
            }
            else
            {
                _daTaKetXuatThuLao = KetXuatThuLaoChuongTrinh.GetKetXuatThuLaoChuongTrinh(_maChuongTrinh, _diengiai, _loaiThuLao);
            }
            
            gridView2.GroupPanelText = "Kết Xuất Thù Lao Tổng Hợp" + TenLoaiThuLao();
            if (_daTaKetXuatThuLao.Rows.Count <= 0)
                MessageBox.Show("Kết xuất thù lao Tổng Hợp rỗng");
            else
            {

                gridControl1.DataSource = _daTaKetXuatThuLao;
                FormatGridBaoCaoTongHop(gridView2);
                FormatGridColumnNumber(gridView2, new string[] { "SoTien", "TienThue", "TienSauThue" });
            }
        }
        private void btn_BaoCaoChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView2.Columns.Clear();
            DataTable _daTaKetXuatThuLao_ChiTiet = new DataTable();


            _diengiai = txt_DienGiai.Text.Trim();

            if (checkEdit_Ngay.Checked == true)
            {
                DateTime tuNgay = Convert.ToDateTime(dtEdit_TuNgay.EditValue).Date;
                DateTime denNgay = Convert.ToDateTime(dtEdit_DenNgay.EditValue).Date;
                _daTaKetXuatThuLao_ChiTiet = KetXuatThuLaoChuongTrinh.GetKetXuatThuLaoChuongTrinhTheoNgay_ChiTiet(tuNgay, denNgay, _maChuongTrinh, _diengiai, _loaiThuLao);
            }
            else
            {
                _daTaKetXuatThuLao_ChiTiet = KetXuatThuLaoChuongTrinh.GetKetXuatThuLaoChuongTrinh_ChiTiet(_maChuongTrinh, _diengiai, _loaiThuLao);
            }


            gridView2.GroupPanelText = "Kết Xuất Thù Lao Chi Tiết" + TenLoaiThuLao();
            if (_daTaKetXuatThuLao_ChiTiet.Rows.Count <= 0)
                MessageBox.Show("Kết xuất thù lao Chi Tiết rỗng");
            else
            {
                gridControl1.DataSource = _daTaKetXuatThuLao_ChiTiet;
                FormatGridBaoCaoChiTiet(gridView2);
                FormatGridColumnNumber(gridView2, new string[] { "SoTien", "TienThue", "TienSauThue" });
            }
        }

        private void btn_XuatfileExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView2.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        

        private void grdLU_ChuongTrinh_EditValueChanged(object sender, EventArgs e)
        {
            if (grdLU_ChuongTrinh.EditValue != null)
            {
                _maChuongTrinh = (int)grdLU_ChuongTrinh.EditValue;
            }
        }

        private void cbLoaiThuLao_ValueChanged(object sender, EventArgs e)
        {
            if (cbLoaiThuLao.Value != null)
            {
                _loaiThuLao = (int)cbLoaiThuLao.Value;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        
    }
}