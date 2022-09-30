using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Data;
using DevExpress.XtraGrid;
using System.Collections;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmXuatChungTuGocRaExcelCoCT : Form
    {
        string path;
        SaveFileDialog saveFileDialog;
        BoPhanList _boPhanList = BoPhanList.NewBoPhanList();
        DataTable table = new DataTable();
        DateTime ngayBatDau;
        DateTime ngayKetThuc;
        BoPhan _boPhan = BoPhan.NewBoPhan();
        int userID = CurrentUser.Info.UserID;
        public frmXuatChungTuGocRaExcelCoCT()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            _boPhanList = BoPhanList.GetBoPhanListByUserID(userID);
            BoPhan itemBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _boPhanList.Insert(0, itemBoPhan);
            boPhanListBindingSource.DataSource = _boPhanList;
        }

        private void cbu_BoPhan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbu_BoPhan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cbu_BoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cbu_BoPhan.Width;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        #region bt_Xem_Click
        private void bt_Xem_Click(object sender, EventArgs e)
        {
            ngayBatDau = Convert.ToDateTime(dtu_TuNgay.Value);
            ngayKetThuc = Convert.ToDateTime(dtu_DenNgay.Value);
            XuatDuLieuList _xuatDuLieuList = XuatDuLieuList.GetXuatDuLieuListByChuongTrinh(ngayBatDau, ngayKetThuc, _boPhan.MaBoPhan, ERP_Library.Security.CurrentUser.Info.UserID);
            bindingSource_XuatDuLieuExcel.DataSource = _xuatDuLieuList;
        }
        #endregion

        #region cbu_BoPhan_ValueChanged
        private void cbu_BoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cbu_BoPhan.Value != null)
            {
                _boPhan = BoPhan.GetBoPhan(Convert.ToInt32(cbu_BoPhan.Value));
            }
        }
        #endregion

        private void sồSáchBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //HamDungChung.ExportToExcel(ultraGrid_DuLieu);
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // HamDungChung.ExportToExcel(ultraGrid_DuLieu);
            GridUtil.ExportToExcelXlsx(this.gridView1, false);
        }

        decimal _Tong = 0;
        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            XuatDuLieu obj1 = gridView1.GetRow(e.RowHandle1) as XuatDuLieu;
            XuatDuLieu obj2 = gridView1.GetRow(e.RowHandle2) as XuatDuLieu;

            if (Object.ReferenceEquals(e.Column, this.colSoTienBT))
            {
                e.Merge = (obj1.MaButToan == obj2.MaButToan);
                e.Handled = true;
            }
            else if (Object.ReferenceEquals(e.Column, this.colSoTienCPSX))
            {
                e.Merge = (obj1.MaCT_ChiPhiSanXuat == obj2.MaCT_ChiPhiSanXuat);
                e.Handled = true;
            }
            else if (Object.ReferenceEquals(e.Column, this.colTenChuongTrinh))
            {
                e.Merge = (obj1.MaCT_ChiPhiSanXuat == obj2.MaCT_ChiPhiSanXuat);
                e.Handled = true;
            }
            ///
            if (e.Merge)
            {
                //e.Column.AppearanceCell.BackColor = Color.LightYellow;
            }
        }    

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewInfo vInfo = gridView1.GetViewInfo() as GridViewInfo;
            //GridMergedCellInfo mergedCell = null;
            for (int i = 0; i < vInfo.RowsInfo.Count; i++)
            {
                GridDataRowInfo rowInfo = vInfo.RowsInfo[i] as GridDataRowInfo;
                if (rowInfo != null)
                {
                    GridCellInfo cInfo = rowInfo.Cells[e.Column];
                    if (cInfo.IsMerged && cInfo.MergedCell.RowHandle == e.RowHandle)
                    {
                        e.Appearance.BackColor = Color.LightYellow;
                        break;
                    }
                }
            }
        }

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            // Get the summary ID. 
            int summaryID = Convert.ToInt32((e.Item as GridSummaryItem).Tag);
            GridView View = sender as GridView;

            // Initialization 
            //if (e.SummaryProcess == CustomSummaryProcess.Start)
            //{
                
            //}
            // Calculation 
            //if (e.SummaryProcess == CustomSummaryProcess.Calculate)
            //{
            //    switch (summaryID)
            //    {
            //        case 1:
            //            break;
            //        case 2:
            //            break;
            //    }
            //}
            // Finalization 
            if (e.SummaryProcess == CustomSummaryProcess.Finalize)
            {
                switch (summaryID)
                {
                    case 1:
                        {
                            Hashtable danhSachDistinctButToan = new Hashtable();
                            List<XuatDuLieu> filteredObjects = GridUtil.GetFilteredData<XuatDuLieu>(View);
                            Decimal totalSoTienButToanValue = 0;
                            foreach (var item in filteredObjects)
                            {
                                if (danhSachDistinctButToan.ContainsKey(item.MaButToan) == false)
                                {
                                    danhSachDistinctButToan.Add(item.MaButToan, item);
                                    totalSoTienButToanValue += item.SoTienBT;
                                }
                            }
                            e.TotalValue = totalSoTienButToanValue;
                        }
                        break;
                    case 2:
                        {
                            Hashtable danhSachDistinctChiPhiSX = new Hashtable();
                            List<XuatDuLieu> filteredObjects = GridUtil.GetFilteredData<XuatDuLieu>(View);
                            Decimal totalSoTienChiPhiValue = 0;
                            foreach (var item in filteredObjects)
                            {
                                if (danhSachDistinctChiPhiSX.ContainsKey(item.MaCT_ChiPhiSanXuat) == false)
                                {
                                    danhSachDistinctChiPhiSX.Add(item.MaCT_ChiPhiSanXuat, item);
                                    totalSoTienChiPhiValue += item.SoTienChuongTrinh;
                                }
                            }
                            e.TotalValue = totalSoTienChiPhiValue;
                        }
                        break;
                }
            }
        }
        private void frmXuatChungTuGocRaExcelCoCT_Load(object sender, EventArgs e)
        {
            GridUtil.SetSTTForGridView(this.gridView1, 60);
            //
            {
                this.gridView1.OptionsView.ShowFooter = true;
                {
                    // Customize the total summary. 
                    colSoTienBT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                    colSoTienBT.SummaryItem.DisplayFormat = "{0:n0}";
                    colSoTienBT.SummaryItem.Tag = 1;
                }
                //
                {
                    // Customize the total summary. 
                    colSoTienCPSX.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                    colSoTienCPSX.SummaryItem.DisplayFormat = "{0:n0}";
                    colSoTienCPSX.SummaryItem.Tag = 2;
                }
            }
        }
    }
}
