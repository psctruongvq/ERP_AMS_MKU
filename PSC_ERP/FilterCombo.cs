using System;
using System.Collections.Generic;
using System.Text;

namespace PSC_ERP
{
    class FilterCombo
    {
        private Infragistics.Win.UltraWinGrid.UltraGrid grid;
        private string colid, colfilter;
        private bool delfilter = true;
        private Infragistics.Win.UltraWinGrid.FilterComparisionOperator compar = Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Contains;
        /// <summary>
        /// Tạo filter tự động cho 1 control UltraCombo sử dụng để nhập liệu cho UltraGrid
        /// </summary>
        /// <param name="Grid">Khung lưới nhập liệu</param>
        /// <param name="ColID">Tên field dữ liệu nhập trên khung lưới</param>
        /// <param name="ColFilter">Tên field của combo để filter dữ liệu</param>
        public FilterCombo(Infragistics.Win.UltraWinGrid.UltraGrid Grid, string ColID, string ColFilter)
        {
            grid = Grid;
            colid = ColID;
            colfilter = ColFilter;
            grid.KeyUp += new System.Windows.Forms.KeyEventHandler(grid_KeyUp);
            grid.KeyDown += new System.Windows.Forms.KeyEventHandler(grid_KeyDown);
            grid.BeforeCellListDropDown += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(grid_BeforeCellListDropDown);
        }

        void grid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (grid.ActiveCell != null && grid.ActiveCell.Column.Key == colid && (e.KeyCode == System.Windows.Forms.Keys.Enter || e.KeyCode == System.Windows.Forms.Keys.Tab))
            {
                Infragistics.Win.UltraWinGrid.UltraCombo cmb = (Infragistics.Win.UltraWinGrid.UltraCombo)grid.ActiveCell.EditorControlResolved;
                if (cmb.SelectedRow == null)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow r = cmb.ActiveRowScrollRegion.FirstRow;
                    if (r != null)
                        grid.ActiveCell.Value = r.Cells[cmb.ValueMember].Value;
                    else
                        grid.ActiveCell.Value = 0;
                }
            }
        }

        void grid_BeforeCellListDropDown(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            if (delfilter && grid.ActiveCell.Column.Key == colid)
                ((Infragistics.Win.UltraWinGrid.UltraCombo)grid.ActiveCell.EditorControlResolved).DisplayLayout.Bands[0].ColumnFilters[colfilter].FilterConditions.Clear();
        }

        void grid_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode >= System.Windows.Forms.Keys.A && e.KeyCode <= System.Windows.Forms.Keys.Z) || (e.KeyCode >= System.Windows.Forms.Keys.D0 && e.KeyCode <= System.Windows.Forms.Keys.D9) || e.KeyCode == System.Windows.Forms.Keys.Back || e.KeyCode == System.Windows.Forms.Keys.Delete)

                if (grid.ActiveCell != null && grid.ActiveCell.Column.Key == colid)
                {
                    string s = "";
                    if (grid.ActiveCell.SelLength > 0)
                        s = grid.ActiveCell.Text.Substring(0, grid.ActiveCell.SelStart);
                    else
                        s = grid.ActiveCell.Text;
                    Infragistics.Win.UltraWinGrid.UltraCombo cmb = (Infragistics.Win.UltraWinGrid.UltraCombo)grid.ActiveCell.EditorControlResolved;
                    Infragistics.Win.UltraWinGrid.FilterConditionsCollection fs;
                    if (cmb!= null)
                    {
                        fs = cmb.DisplayLayout.Bands[0].ColumnFilters[colfilter].FilterConditions;
                        fs.Clear();

                        if (s != "")
                            fs.Add(compar, s);
                    }
                    if (!grid.ActiveCell.DroppedDown)
                    {
                        delfilter = false;
                        int pos = grid.ActiveCell.SelStart;
                        grid.ActiveCell.DroppedDown = true;
                        grid.ActiveCell.SelStart = pos;
                        delfilter = true;
                    }
                }
        }

        /// <summary>
        /// Công thức áp dụng để sử dụng cho filter
        /// </summary>
        public Infragistics.Win.UltraWinGrid.FilterComparisionOperator Comparision
        {
            get
            {
                return compar;
            }
            set
            {
                compar = value;
            }
        }


        private Infragistics.Win.UltraWinGrid.UltraCombo combo;
        /// <summary>
        /// Tạo filter tự động cho 1 UltraCombo
        /// </summary>
        /// <param name="Combo">UltraCombo sẽ được filter tự động</param>
        /// <param name="ColFilter">Tên field của combo để filter dữ liệu</param>
        public FilterCombo(Infragistics.Win.UltraWinGrid.UltraCombo Combo, string ColFilter)
        {
            combo = Combo;
            colfilter = ColFilter;
            combo.KeyUp += new System.Windows.Forms.KeyEventHandler(combo_KeyUp);
            combo.BeforeDropDown += new System.ComponentModel.CancelEventHandler(combo_BeforeDropDown);
            combo.KeyDown += new System.Windows.Forms.KeyEventHandler(combo_KeyDown);
        }

        void combo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter || e.KeyCode== System.Windows.Forms.Keys.Tab) && combo.IsDroppedDown && combo.SelectedRow == null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow r = combo.ActiveRowScrollRegion.FirstRow;
                if ( r != null)
                    combo.Value = r.Cells[combo.ValueMember].Value;
                else
                    combo.Value = 0;
            }
        }

        void combo_BeforeDropDown(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (delfilter)
                combo.DisplayLayout.Bands[0].ColumnFilters[colfilter].FilterConditions.Clear();
        }

        void combo_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode >= System.Windows.Forms.Keys.A && e.KeyCode <= System.Windows.Forms.Keys.Z) || (e.KeyCode >= System.Windows.Forms.Keys.D0 && e.KeyCode <= System.Windows.Forms.Keys.D9) || e.KeyCode == System.Windows.Forms.Keys.Back || e.KeyCode == System.Windows.Forms.Keys.Delete)
            {
                string s = "";
                if (combo.Textbox != null)
                {
                    if (combo.Textbox.SelectionLength > 0)
                        s = combo.Text.Substring(0, combo.Textbox.SelectionStart);
                    else
                        s = combo.Textbox.Text;
                }
                Infragistics.Win.UltraWinGrid.FilterConditionsCollection fs = combo.DisplayLayout.Bands[0].ColumnFilters[colfilter].FilterConditions;
                
                fs.Clear();
                if (s != "")
                    fs.Add(compar, s);
                if (!combo.IsDroppedDown)
                {
                    delfilter = false;
                    int pos = combo.Textbox.SelectionStart;
                    combo.ToggleDropdown();
                    combo.Textbox.SelectionStart = pos;
                    delfilter = true;
                }
            }


        }
    }
}
