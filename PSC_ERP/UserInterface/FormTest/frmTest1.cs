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
    public partial class frmTest1 : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        private byte _loaiMau = 1;

        #endregion//Properties

        public frmTest1()
        {
            InitializeComponent();
        }

        #region FunctionS

        private void DesigngridView1()
        {//N
            gridView1.OptionsView.ShowGroupPanel = true;
            if (_loaiMau == 1)
                gridView1.GroupPanelText = "Danh Sách";
            else if (_loaiMau == 2)
                gridView1.GroupPanelText = "Danh Sách";
            else if (_loaiMau == 3)
                gridView1.GroupPanelText = "Danh Sách";
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.OptionsView.AllowCellMerge = true;
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                //if (gridView1.Columns[i].FieldName == "MaButToan" || gridView1.Columns[i].FieldName == "MaCT_ChiPhiSanXuat")
                //{
                //    gridView1.Columns[i].Visible = false;
                //}
                gridView1.Columns[i].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                gridView1.Columns[i].OptionsColumn.FixedWidth = false;
                gridView1.Columns[i].BestFit();
                gridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                //if (_loaiMau == 1 &&
                //    (
                //        gridView1.Columns[i].FieldName.Contains("Nợ")
                //        || gridView1.Columns[i].FieldName.Contains("Có")
                //        || gridView1.Columns[i].FieldName.Contains("Số tiền chương trình")
                //        || gridView1.Columns[i].FieldName.Contains("Số Chứng Từ")
                //        || gridView1.Columns[i].FieldName.Contains("Ngày chứng từ")
                //        || gridView1.Columns[i].FieldName.Contains("Chương trình")
                //        || gridView1.Columns[i].FieldName.Contains("User lập")
                //    )
                //   )
                //    gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                //if (gridView1.Columns[i].FieldName != "Ngày chứng từ")
                //    gridView1.Columns[i].DisplayFormat.FormatString = "#,###";
                //else gridView1.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy";
                //if (
                //    _loaiMau == 2 &&
                //        (
                //            gridView1.Columns[i].FieldName.Contains("Nợ")
                //            || gridView1.Columns[i].FieldName.Contains("Có")
                //            || gridView1.Columns[i].FieldName.Contains("Số tiền")
                //        )

                //    )
                //    gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                //new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,gridView1.Columns[i].FieldName, "{0:#,###}")});
                //    if (
                //        _loaiMau == 3 &&
                //            (
                //                gridView1.Columns[i].FieldName.Contains("Nợ")
                //                || gridView1.Columns[i].FieldName.Contains("Có")
                //            )

                //        )
                //        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                //new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,gridView1.Columns[i].FieldName, "{0:#,###}")});

            }

            Utils.GridUtils.SetSTTForGridView(gridView1, 40);//M
        }


        #endregion//FunctionS

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {

        }

    }
}