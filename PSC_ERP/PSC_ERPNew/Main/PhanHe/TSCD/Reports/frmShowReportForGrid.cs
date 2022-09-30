using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP.Utils;
using PSC_ERP_Common;

//2018.08.03
namespace PSC_ERPNew.Main.PhanHe.TSCD.Reports
{
    public partial class frmShowReportForGrid : XtraForm
    {
        #region Properties
        string strTenPhuongThuc;
        DataSet dsReport;

        private void DesignGridView()
        {
            #region Design Gridview
            GridUtils.InitGridViewDev(gridView1, false, true, GridMultiSelectMode.CellSelect, false, false, false, true);     
            GridUtils.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "{Nguyên Giá}" }, "#,###.##");
            GridUtils.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "{Nguyên Giá}", }, "{0:#,###.#}");

            GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design Gridview
        }

        public void ShowSummaryCustomFooterGridView(GridView grid, string[] fieldName, string S_format)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, fieldName[i], S_format)});
            }
        }

        public frmShowReportForGrid(string tenPhuongThuc, DataSet ds)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            strTenPhuongThuc = tenPhuongThuc;
            dsReport = ds;
        }

        #endregion Events

        #region event FormLoad
        private void frmShowReportForGrid_Load(object sender, EventArgs e)
        {
            if (this.strTenPhuongThuc == "spRpt_KiemDo")
            {
                //DesignGridView();
                GridUtils.SetSTTForGridView(gridView1, 50);//M
                gridView1.OptionsView.ShowFooter = true;
                gridControl1.DataSource = dsReport.Tables[0];
                gridView1.Columns["Nguyên Giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["Nguyên Giá"].DisplayFormat.FormatString = "#,###";
                //gridView1.Columns["Nguyên Giá"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                //new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Nguyên Giá" , "#,###.##")});

                //gridView1.Columns["Thời gian sử dụng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //gridView1.Columns["Thời gian sử dụng"].DisplayFormat.FormatString = "#,###.##";
                //gridView1.Columns["Thời gian sử dụng"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                //new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Thời gian sử dụng" , "#,###.##")});

                gridView1.Columns["Khấu hao lũy kế"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["Khấu hao lũy kế"].DisplayFormat.FormatString = "#,###";
                //gridView1.Columns["Khấu hao lũy kế"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                //new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Khấu hao lũy kế" , "#,###.##")});

                gridView1.Columns["Giá trị còn lại"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["Giá trị còn lại"].DisplayFormat.FormatString = "#,###";
                //gridView1.Columns["Giá trị còn lại"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                //new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Giá trị còn lại" , "#,###.##")});

                gridView1.Columns["Nguyên Giá"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Nguyên Giá", "{0:#,###}");
                gridView1.Columns["Khấu hao lũy kế"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Khấu hao lũy kế", "{0:#,###}");
                gridView1.Columns["Giá trị còn lại"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Giá trị còn lại", "{0:#,###}");

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    gridView1.Columns[i].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                }
                //GridUtils.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "{Nguyên Giá}" }, "#,###.##");
            }
            else if (this.strTenPhuongThuc == "spRpt_TSCD_DanhSachTaiSanCoDenNgay")
            {
                GridUtils.SetSTTForGridView(gridView1, 50);//M
                gridView1.OptionsView.ShowFooter = true;
                gridControl1.DataSource = dsReport.Tables[0];

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    gridView1.Columns[i].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                }
            }
        }
        #endregion
 

        #region event btn
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnExportDataExcell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //SaveFileDialog dlg = new SaveFileDialog();
            //dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    //gridControl1.ExportToXls(dlg.FileName);
            //    GridUtil.ExportToExcelXlsx(gridView1, true);
            //     //.ExportToExcelXlsx(dlg.FileName);
            //    MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //Process.Start(dlg.FileName);
            //}

            GridUtil.ExportToExcelXlsx(gridView1, true);
            //.ExportToExcelXlsx(dlg.FileName);
            MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        #endregion
        #region sum theo dieu kien - bao cao BangCanDoiPhatSinh
        decimal SumNoDauKy = 0, SumCoDauKy = 0, SumNoPhatSinh = 0, SumCoPhatSinh = 0, SumNoCuoiKy = 0, SumCoCuoiKy = 0;
        private void TinhTong_CanDoiPhatSinh()
        {
            DataTable dt = dsReport.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["KieuIn"] + "" == "1")
                {
                    SumNoDauKy = SumNoDauKy + (decimal)dr["SoDuDauKyNo"];
                    SumCoDauKy = SumCoDauKy + (decimal)dr["SoDuDauKyCo"];
                    SumNoPhatSinh = SumNoPhatSinh + (decimal)dr["SoPhatSinhNo"];
                    SumCoPhatSinh = SumCoPhatSinh + (decimal)dr["SoPhatSinhCo"];
                    SumNoCuoiKy = SumNoCuoiKy + (decimal)dr["SoDuCuoiKyNo"];
                    SumCoCuoiKy = SumCoCuoiKy + (decimal)dr["SoDuCuoiKyCo"];
                }
            }
        }
        #endregion          

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (this.strTenPhuongThuc == "spRpt_KiemDo")
            {
                if (e.IsTotalSummary)
                {
                    if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == "SoDuDauKyNo")
                    {
                        e.TotalValue = Math.Round(this.SumNoDauKy, 0, MidpointRounding.AwayFromZero);
                        e.TotalValueReady = true;
                    }
                    if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == "SoDuDauKyCo")
                    {
                        e.TotalValue = Math.Round(this.SumCoDauKy, 0, MidpointRounding.AwayFromZero);
                        e.TotalValueReady = true;
                    }
                    if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == "SoPhatSinhNo")
                    {
                        e.TotalValue = Math.Round(this.SumNoPhatSinh, 0, MidpointRounding.AwayFromZero);
                        e.TotalValueReady = true;
                    }
                    if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == "SoPhatSinhCo")
                    {
                        e.TotalValue = Math.Round(this.SumCoPhatSinh, 0, MidpointRounding.AwayFromZero);
                        e.TotalValueReady = true;
                    }
                    if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == "SoDuCuoiKyNo")
                    {
                        e.TotalValue = Math.Round(this.SumNoCuoiKy, 0, MidpointRounding.AwayFromZero);
                        e.TotalValueReady = true;
                    }
                    if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == "SoDuCuoiKyCo")
                    {
                        e.TotalValue = Math.Round(this.SumCoCuoiKy, 0, MidpointRounding.AwayFromZero);
                        e.TotalValueReady = true;
                    }            
                }
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (this.strTenPhuongThuc.Contains("Method_BangCanDoiPhatSinh"))
            {
                GridView view = sender as GridView;
                if (view == null) return;
                //if (e.RowHandle != view.FocusedRowHandle &&
                //   ((e.RowHandle % 2 == 0 && e.Column.VisibleIndex % 2 == 1) ||
                //   (e.Column.VisibleIndex % 2 == 0 && e.RowHandle % 2 == 1)))
                //    e.Appearance.BackColor = Color.NavajoWhite;
                if (e.RowHandle < 0)
                    return;

                if (e.RowHandle > dsReport.Tables[0].Rows.Count)
                    return;

                DataRow dr = dsReport.Tables[0].Rows[e.RowHandle];
                if (dr["KieuIn"] + "" == "1")
                {

                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
            }
        }
    }
}