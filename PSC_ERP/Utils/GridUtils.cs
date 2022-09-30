using System;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraGrid;
using System.Threading;

namespace PSC_ERP.Utils
{
    class GridUtils
    {
        private delegate void VoidDelegate(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e);

        public static void InitGridViewDev(GridView grid, bool autoFilter, bool multiSelect,
           GridMultiSelectMode selectMode, bool detailButton, bool groupPanel,
           bool showAutoFilterRow, bool showFooter)
        {
            grid.CopyToClipboard();
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
        public static void ShowFieldGridViewDev(GridView grid, string[] fieldName, string[] caption, int[] width)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].Visible = false;

            grid.OptionsView.ColumnAutoWidth = true;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].VisibleIndex = i;
                grid.Columns[fieldName[i]].Visible = true;
                grid.Columns[fieldName[i]].Caption = caption[i];
                grid.Columns[fieldName[i]].Width = width[i];
                grid.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }
        public static void FormatNumberTypeofColumnGridViewDev2(GridView grid, string[] fieldName, string S_format)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].DisplayFormat.FormatType = FormatType.Numeric;
                grid.Columns[fieldName[i]].DisplayFormat.FormatString = S_format;
            }

        }
        public static void ShowSummaryFooterofColumnGridViewDev2(GridView grid, string[] fieldName, string S_format)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, fieldName[i], S_format)});
            }
        }
        public static void AlignHeaderColumnGridViewDev(GridView grid, string[] fieldName, DevExpress.Utils.HorzAlignment align)
        {
            for (int i = 0; i < fieldName.Length; i++)
                grid.Columns[fieldName[i]].AppearanceHeader.TextOptions.HAlignment = align;
        }


        public static void InitCopyCellForGridView(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {//Cuong
            gridView.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            gridView.KeyDown -= new KeyEventHandler(InitCopyCell_Helper);
            gridView.KeyDown += new KeyEventHandler(InitCopyCell_Helper);
        }
        private static bool NeedCopyHeaders(GridView gridView)
        {//cuong
            return gridView.SelectedRowsCount > 1;
        }
        private static void InitCopyCell_Helper(object sender, KeyEventArgs e)
        {//Cuong
            //DevExpress.XtraGrid.Views.Grid.GridView gridView = sender as GridView;
            //gridView.OptionsBehavior.CopyToClipboardWithColumnHeaders = NeedCopyHeaders(gridView);
            //
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            { 
                
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.UnicodeText))
                {

                    string text = (string)iData.GetData(DataFormats.UnicodeText);
                    DevExpress.XtraGrid.Views.Grid.GridView gridView = sender as GridView;
                    Array.ForEach(gridView.GetSelectedCells(), cell =>
                    {
                        try
                        {
                            cell.Column.View.SetRowCellValue(cell.RowHandle, cell.Column, text);
                            cell.Column.View.RefreshData();
                        }
                        catch { return; }
                    });
                }
            }
        }

        public static void ConfigGridView(GridView gridView, bool setSTT, bool initCopyCell, bool multiSelectCell, bool multiSelectRow, bool initNewRowOnTop)
        {//Cuong
            //
            if (setSTT) SetSTTForGridView(gridView);
            //
            if (initCopyCell) InitCopyCellForGridView(gridView);
            //
            if (multiSelectCell)
            {
                InitMultiCellSelectForGridView(gridView);
            }
            else if (multiSelectRow)
            {
                InitMultiRowSelectForGridView(gridView);
            }
            //
            if (initNewRowOnTop) InitNewRowOnTopOfGridView(gridView);
            //
        }
        public static void InitMultiCellSelectForGridView(GridView gridView)
        {//Cuong
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
        }
        public static void InitMultiRowSelectForGridView(GridView gridView)
        {//Cuong
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
        }
        public static void InitNewRowOnTopOfGridView(GridView gridView)
        {//Cuong
            gridView.NewItemRowText = @"Thêm Dòng Mới";
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            //gridView.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(InitNewRowOnTopOfGridView_Helper);
            //gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(InitNewRowOnTopOfGridView_Helper);

        }

        static void InitNewRowOnTopOfGridView_Helper(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {//Cuong

            Thread thr = new Thread(() =>
            {
                GridControl ct = (sender as GridView).GridControl;

                if (ct.InvokeRequired)
                {
                    VoidDelegate dele = new VoidDelegate(InitNewRowOnTopOfGridView_Helper1);
                    ct.Invoke(dele, sender, e);

                }
                else
                {
                    InitNewRowOnTopOfGridView_Helper1(sender, e);
                }
            }
            );

            thr.Start();
        }

        private static void InitNewRowOnTopOfGridView_Helper1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {//Cuong
            if (e.RowHandle < 0)
            {
                try
                {
                    GridView gridView = sender as GridView;
                    GridControl gridControl = gridView.GridControl;
                    Object newItem;
                    
                    gridView.RefreshData();//cap nhat lai du lieu rat quan trong
                    gridView.MoveLast();
                    newItem = ((BindingSource)gridControl.DataSource).Current;
                    if (((BindingSource)gridControl.DataSource).Count > 1)
                    {
                        gridView.DeleteRow(gridView.RowCount - 1);
                        dynamic objectList = gridControl.DataSource;
                        objectList.Insert(0, newItem);
                        //gridView.RefreshData();
                        gridView.MoveFirst();
                    }
                }
                catch (System.Exception ex)
                {

                }

            }
        }


        /// ////////////////////////////////////////////////////////////////////////////
        public static void SetSTTForGridView(GridView gridView, int width = 35)
        {//Cuong
            gridView.IndicatorWidth = width;
            gridView.CustomDrawRowIndicator -= new RowIndicatorCustomDrawEventHandler(SetSTTForGridView_Helper);
            gridView.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(SetSTTForGridView_Helper);

        }
        static void SetSTTForGridView_Helper(object sender, RowIndicatorCustomDrawEventArgs e)
        {//Cuong
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();

            }
        }
        /// /////////////////////////////////////////////////


        #region Inner Type
        //public class CGridPainter : DevExpress.XtraGrid.Views.Grid.Drawing.GridPainter
        //{
        //    public CGridPainter(GridView view) : base(view) { }

        //    public override bool DrawNewItemRow(DevExpress.XtraGrid.Views.Grid.Drawing.GridViewDrawArgs e, GridRowInfo ri)
        //    {
        //        //if ((ri.RowState & GridRowCellState.Focused) != GridRowCellState.Dirty)
        //        //{
        //        //    return false;
        //        //}
        //        //Rectangle r = ri.DataBounds;
        //        //if (r.X < e.ViewInfo.ViewRects.ColumnPanelLeft)
        //        //{
        //        //    r.X = e.ViewInfo.ViewRects.ColumnPanelLeft;
        //        //}
        //        //if (r.Right > e.ViewInfo.ViewRects.Rows.Right)
        //        //{
        //        //    r.Width = e.ViewInfo.ViewRects.Rows.Right - r.X;
        //        //}
        //        //this.StyleFillRectangle(e.Cache, ri.Appearance, r);
        //        //ri.Appearance.DrawString(e.Cache, e.ViewInfo.GetNewItemRowText(), r);
        //        //this.DrawRowIndent(e, ri);
        //        //return true;

        //        Rectangle r = ri.DataBounds;
        //        if ((ri.RowState & GridRowCellState.Focused) != GridRowCellState.Dirty)
        //        {
        //            return false;
        //        }
        //        View.NewItemRowText = "Thêm dòng mới";
        //        if (r.X < e.ViewInfo.ViewRects.ColumnPanelLeft)
        //        {
        //            r.X = e.ViewInfo.ViewRects.ColumnPanelLeft;
        //        }
        //        if (r.Right > e.ViewInfo.ViewRects.Rows.Right)
        //        {
        //            r.Width = e.ViewInfo.ViewRects.Rows.Right - r.X;
        //        }
        //        base.DrawNewItemRow(e, ri);
        //        Font fnt = View.PaintAppearance.Row.Font;
        //        Brush brush = View.PaintAppearance.Row.GetForeBrush(e.Cache);
        //        foreach (DevExpress.XtraGrid.Drawing.GridColumnInfoArgs columnInfo in e.ViewInfo.ColumnsInfo)
        //        {
        //            Rectangle rect = new Rectangle(columnInfo.Bounds.X, ri.Bounds.Top, columnInfo.Bounds.Width, ri.Bounds.Height);
        //            rect.Inflate(-2, -2);
        //            ri.Appearance.DrawString(e.Cache, columnInfo.Caption, rect, columnInfo.Appearance.GetStringFormat());
        //        }

        //        //DrawRowLines(e, ri) 
        //        return true;
        //    }
        //}
        public class BooleanCheckAllBox
        {//Cuong
            #region Static method
            public static BooleanCheckAllBox SetCheckAllBoxToBooleanGridColumn(GridView gridView, GridColumn booleanColumn)
            {
                return new BooleanCheckAllBox(gridView, booleanColumn);
            }
            public static BooleanCheckAllBox SetCheckAllBoxToBooleanGridColumn(GridView gridView, GridColumn booleanColumn, BooleanCheckAllBox.ColumnChecking delegateFn)
            {
                BooleanCheckAllBox chk = new BooleanCheckAllBox(gridView, booleanColumn);
                chk.ColumnCheckingEvent += delegateFn;
                return chk;
            }
            public static BooleanCheckAllBox SetCheckAllBoxToBooleanGridColumn(GridView gridView, GridColumn booleanColumn, DevExpress.Utils.HorzAlignment horzAlignment)
            {
                return new BooleanCheckAllBox(gridView, booleanColumn, horzAlignment);
            }
            public static BooleanCheckAllBox SetCheckAllBoxToBooleanGridColumn(GridView gridView, GridColumn booleanColumn, DevExpress.Utils.HorzAlignment horzAlignment, BooleanCheckAllBox.ColumnChecking delegateFn)
            {
                BooleanCheckAllBox chk = new BooleanCheckAllBox(gridView, booleanColumn, horzAlignment);
                chk.ColumnCheckingEvent += delegateFn;
                return chk;
            }



            #endregion
            #region Inner Type
            public delegate void ColumnChecking(object sender, CheckAllColumnCheckingEventArgs e);
            #region CheckAllColumnCheckingEventArgs
            public class CheckAllColumnCheckingEventArgs : EventArgs
            {
                private bool checking;
                private bool allow = true;
                private GridColumn gridColumn;
                private int rowHandle;

                public bool Checking
                {
                    get { return checking; }
                }

                public bool Allow
                {
                    get { return allow; }
                    set { allow = value; }
                }

                public GridColumn GridColumn
                {
                    get { return gridColumn; }
                }

                public int RowHandle
                {
                    get { return rowHandle; }
                }

                public CheckAllColumnCheckingEventArgs(bool checking, GridColumn gridColumn, int rowHandle)
                {
                    this.checking = checking;
                    this.gridColumn = gridColumn;
                    this.rowHandle = rowHandle;
                }
            }

            #endregion
            #endregion
            private GridColumn booleanColumn;
            private GridView gridView;
            private RepositoryItemCheckEdit edit;
            private bool checkAllState = false;
            public event ColumnChecking ColumnCheckingEvent;
            private DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo _checkEditViewInfo;
            public BooleanCheckAllBox(GridView gridView, GridColumn booleanColumn, DevExpress.Utils.HorzAlignment horzAlignment)
            {
                SetupColumn(gridView, booleanColumn, horzAlignment);
            }

            public BooleanCheckAllBox(GridView gridView, GridColumn booleanColumn)
            {
                SetupColumn(gridView, booleanColumn, DevExpress.Utils.HorzAlignment.Default);
            }

            private void SetupColumn(GridView gridView, GridColumn booleanColumn, DevExpress.Utils.HorzAlignment horzAlignment)
            {
                if (booleanColumn.UnboundType == UnboundColumnType.Boolean || booleanColumn.UnboundType == UnboundColumnType.Bound)
                {
                    this.booleanColumn = booleanColumn;
                    this.gridView = gridView;

                    //Create a repository item check edit to use in the column header
                    edit = new RepositoryItemCheckEdit();
                    //Set the caption to the same as the column header
                    edit.Caption = " " + booleanColumn.GetCaption();
                    edit.GlyphAlignment = horzAlignment;

                    //Turn off sorting and the column caption
                    booleanColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    booleanColumn.OptionsColumn.ShowCaption = false;

                    //Wire up the grid view events
                    gridView.Click += new EventHandler(gridView_Click);
                    gridView.CustomDrawColumnHeader += new ColumnHeaderCustomDrawEventHandler(gridView_CustomDrawColumnHeader);
                }
            }

            protected void DrawCheckBox(Graphics g, AppearanceObject a, Rectangle r, bool Checked)
            {

                DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
                DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
                _checkEditViewInfo = edit.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
                painter = edit.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
                _checkEditViewInfo.EditValue = Checked;
                _checkEditViewInfo.Bounds = r;
                //Manually set the forecolor and font
                _checkEditViewInfo.PaintAppearance.ForeColor = a.ForeColor;
                _checkEditViewInfo.PaintAppearance.Font = a.Font;
                _checkEditViewInfo.CalcViewInfo(g);
                args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(_checkEditViewInfo, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
                painter.Draw(args);
                args.Cache.Dispose();
            }

            void gridView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
            {
                //If drawing the boolean column header, draw the checkbox
                if (object.ReferenceEquals(e.Column, booleanColumn))
                {
                    e.Info.InnerElements.Clear();
                    e.Painter.DrawObject(e.Info);
                    DrawCheckBox(e.Graphics, e.Appearance, e.Bounds, checkAllState);
                    e.Handled = true;
                }
            }

            void gridView_Click(object sender, EventArgs e)
            {

                GridHitInfo hitInfo;
                Point pt = gridView.GridControl.PointToClient(Control.MousePosition);
                hitInfo = gridView.CalcHitInfo(pt);

                if (hitInfo.InColumn && Object.ReferenceEquals(hitInfo.Column, booleanColumn))
                {
                    int toaDoXCuaCheckBox = _checkEditViewInfo.CheckInfo.GlyphRect.X;
                    int checkBoxWidth = _checkEditViewInfo.CheckInfo.GlyphRect.Width;
                    int checkBoxHeight = _checkEditViewInfo.CheckInfo.GlyphRect.Height;
                    int toaDoYCuaCheckBox = _checkEditViewInfo.CheckInfo.GlyphRect.Y;
                    if (pt.X >= toaDoXCuaCheckBox && pt.X <= toaDoXCuaCheckBox + checkBoxWidth)
                    {
                        if (pt.Y >= toaDoYCuaCheckBox && pt.Y <= toaDoYCuaCheckBox + checkBoxHeight)
                        {

                            if (checkAllState)
                            {
                                CheckNone();
                                checkAllState = false;
                            }
                            else
                            {
                                CheckAll();
                                checkAllState = true;
                            }
                        }
                    }

                }
            }

            private void CheckNone()
            {
                Cursor cursor = gridView.GridControl.Cursor;
                gridView.GridControl.Cursor = Cursors.WaitCursor;

                try
                {
                    gridView.BeginDataUpdate();
                    //Uncheck all rows
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        CheckAllColumnCheckingEventArgs e = new CheckAllColumnCheckingEventArgs(false, booleanColumn, i);
                        if (ColumnCheckingEvent != null)
                        {
                            ColumnCheckingEvent(this, e);
                        }
                        if (e.Allow)
                        {
                            gridView.SetRowCellValue(i, booleanColumn, false);
                        }
                    }
                    gridView.EndDataUpdate();
                }
                finally
                {
                    gridView.GridControl.Cursor = cursor;
                }
            }

            private void CheckAll()
            {
                Cursor cursor = gridView.GridControl.Cursor;
                gridView.GridControl.Cursor = Cursors.WaitCursor;

                try
                {
                    gridView.BeginDataUpdate();
                    //Check all rows
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        CheckAllColumnCheckingEventArgs e = new CheckAllColumnCheckingEventArgs(false, booleanColumn, i);
                        if (ColumnCheckingEvent != null)
                        {
                            ColumnCheckingEvent(this, e);
                        }
                        if (e.Allow)
                        {
                            gridView.SetRowCellValue(i, booleanColumn, true);
                        }
                    }
                    gridView.EndDataUpdate();
                }
                finally
                {
                    gridView.GridControl.Cursor = cursor;
                }
            }
        }
        #endregion

        internal static void SetSTTForGridView(GridControl gridView_ButToan, int p)
        {
            throw new NotImplementedException();
        }
    }



}
