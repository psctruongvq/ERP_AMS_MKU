using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ERP_Library;

namespace PSC_ERP
{
    public partial class ComboboxNhanVien : UserControl
    {
        private int _MaBoPhan = 0;
        public event EventHandler ValueChanged;
        private object mValue;
        private FilterCombo fCombo;

        public ComboboxNhanVien()
        {
            InitializeComponent();
            fCombo = new FilterCombo(cmbNhanVien, "TenNhanVien");
        }
        private void ApllyFilter()
        {
            Infragistics.Win.UltraWinGrid.FilterConditionsCollection f = cmbNhanVien.DisplayLayout.Bands[0].ColumnFilters["MaBoPhan"].FilterConditions;
            f.Clear();
            if (_MaBoPhan > 0)
                f.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals,_MaBoPhan);
        }
        public void LoadData()
        {
            
            nhanVienComboListBindingSource.DataSource = NhanVienComboList.GetNhanVienAll();
        }

        public void LoadDataLong()
        {

            nhanVienComboListBindingSource.DataSource = NhanVienComboList.GetNhanVienAllLong();
        }
        public void LoadDataByQuyetToan(int Nam,int DenKy)
        {

            nhanVienComboListBindingSource.DataSource = NhanVienComboList.GetNhanVienByQuyetToan(Nam, DenKy);
        }
       
        public void LoadDataByBoPhan(int MaBoPhan)
        {
            nhanVienComboListBindingSource.DataSource = ERP_Library.NhanVienComboList.GetNhanVienByMaBoPhan(MaBoPhan);
        }
        public void LoadDataByBoPhanALL(int MaBoPhan)
        {
            nhanVienComboListBindingSource.DataSource = ERP_Library.NhanVienComboList.GetNhanVienByMaBoPhanAll(MaBoPhan);
        }

        public void LoadDataByLoai(int BoPhan, int Loai)
        {
            nhanVienComboListBindingSource.DataSource = ERP_Library.NhanVienComboList.GetNhanVienByLoai(BoPhan, Loai);
        }
        public void LoadDataByKyLuong( int MaKy,int MaBoPhan)
        {
            nhanVienComboListBindingSource.DataSource = ERP_Library.NhanVienComboList.GetNhanVienByKyLuong(MaKy, MaBoPhan);
        }
        

        public string GetTextMaTen()
        {
            if (mValue == null || Convert.ToInt64(mValue) == 0)
                return "";

            foreach (ERP_Library.NhanVienComboListChild item in (ERP_Library.NhanVienComboList)nhanVienComboListBindingSource.DataSource)
                if (item.MaNhanVien == Convert.ToInt64(mValue))
                {
                    return item.MaQLNhanVien + " - " + item.TenNhanVien;
                }
            return "";
        }

        public void FilterByMaBoPhan(Object MaBoPhan)
        {
            if (MaBoPhan is DBNull || MaBoPhan == null)
                _MaBoPhan = 0;
            else
                _MaBoPhan = (int)MaBoPhan;
            ApllyFilter();
        }
        [System.ComponentModel.Bindable(true)]
        public object Value
        {
            get
            { return cmbNhanVien.Value; }
            set
            {
                if ((cmbNhanVien.Value == null && value != null ) || (cmbNhanVien.Value != null && !cmbNhanVien.Value.Equals(value)))
                {
                    cmbNhanVien.Value = value;
                    mValue = value;
                    if (ValueChanged != null)
                        ValueChanged(this, EventArgs.Empty);
                }
            }
        }
        public long MaNhanVien
        {
            get 
            {
                if (cmbNhanVien.Value != null)
                    return Convert.ToInt64(cmbNhanVien.Value);
                else
                    return 0;
            } 
        }
        [System.ComponentModel.Browsable(false)]
        public String Text
        {
            get
            { return cmbNhanVien.Text; }
            set
            { cmbNhanVien.Text = value; }
        }

        private void cmbNhanVien_AfterCloseUp(object sender, EventArgs e)
        {
            if ((mValue == null && cmbNhanVien.Value != null) || (mValue != null && !mValue.Equals(cmbNhanVien.Value)))
            {
                mValue = Value;
                if (ValueChanged != null)
                    ValueChanged(this, EventArgs.Empty);
            }
        }

        private void cmbNhanVien_Validated(object sender, EventArgs e)
        {
            if ((mValue == null && cmbNhanVien.Value != null) || (mValue != null && !mValue.Equals(cmbNhanVien.Value)))
            {
                mValue = Value;
                if (ValueChanged != null)
                    ValueChanged(this, EventArgs.Empty);
            }
        }
        #region Su dung voi khung luoi

        private Infragistics.Win.UltraWinGrid.UltraGrid grdEdit;
        private string ColEdit, ColBoPhan;

        /// <summary>
        /// Sử dụng để edit dữ liệu mã nhân viên trên khung lưới, control tự động binding dữ liệu
        /// </summary>
        /// <param name="colMaNhanVien">Tên field là mã nhân viên (bắt buộc)</param>
        /// <param name="colMaBoPhan">Tên field là mã bộ phận (có hoặc không), dùng để filter nhân viên trong bộ phận</param>
        /// <param name="grd">Control Grid sử dụng combobox này</param>
        public void SetEditColumn(string colMaNhanVien, string colMaBoPhan, Infragistics.Win.UltraWinGrid.UltraGrid grd)
        {
            grdEdit = grd;
            ColEdit = colMaNhanVien;
            ColBoPhan = colMaBoPhan;
            this.LoadData();
            grdEdit.BeforeEnterEditMode += new CancelEventHandler(grdEdit_BeforeEnterEditMode);
            grdEdit.BeforeCellDeactivate += new CancelEventHandler(grdEdit_BeforeCellDeactivate);
            cmbNhanVien.KeyDown += new KeyEventHandler(cmbNhanVien_KeyDown);
            grdEdit.BeforeColRegionScroll += new Infragistics.Win.UltraWinGrid.BeforeColRegionScrollEventHandler(grdEdit_BeforeColRegionScroll);
            grdEdit.BeforeRowRegionScroll += new Infragistics.Win.UltraWinGrid.BeforeRowRegionScrollEventHandler(grdEdit_BeforeRowRegionScroll);
        }

        void grdEdit_BeforeRowRegionScroll(object sender, Infragistics.Win.UltraWinGrid.BeforeRowRegionScrollEventArgs e)
        {
            if (this.Visible) this.Visible = false;
        }

        void grdEdit_BeforeColRegionScroll(object sender, Infragistics.Win.UltraWinGrid.BeforeColRegionScrollEventArgs e)
        {
            if (this.Visible) this.Visible = false;
        }


        void cmbNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdEdit != null)
            {
                if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
                {
                    grdEdit.Focus();
                    this.Visible = false;
                    grdEdit.ActiveCell.Value = this.Value;
                    if ((Control.ModifierKeys & Keys.Shift) != 0)
                        grdEdit.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                    else
                        grdEdit.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                    e.Handled = true;
                }
            }
        }

        void grdEdit_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell objCell = grdEdit.ActiveCell;
            if (objCell == null) return;
            if (objCell.Column.Key != ColEdit || !this.Visible) return;
            
            this.Visible = false;
            grdEdit.ActiveCell.Value = this.Value;
        }

        void grdEdit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell objCell = grdEdit.ActiveCell;
            if (objCell == null) return;
            if (objCell.Column.Key != ColEdit) return;

            Infragistics.Win.UltraWinGrid.CellUIElement element;
            try
            {
                element = (Infragistics.Win.UltraWinGrid.CellUIElement)objCell.GetUIElement(grdEdit.ActiveRowScrollRegion, grdEdit.ActiveColScrollRegion);
            }
            catch
            {
                return;
            }
            int left = element.RectInsideBorders.Location.X + grdEdit.Location.X;
            int top = element.RectInsideBorders.Location.Y + grdEdit.Location.Y;
            int width = element.RectInsideBorders.Width;
            int height = element.RectInsideBorders.Height;

            this.SetBounds(left, top, width, height);
            this.Value = objCell.Value;
            if (ColBoPhan != "")
            {
                this.FilterByMaBoPhan(objCell.Row.Cells[ColBoPhan].Value);
            }
            grdEdit.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChange;//chặn ngăn không cho grid update khi mất focus do focus vào control combobox
            
            this.Visible = true;
            this.Focus();
            this.BringToFront();
            cmbNhanVien.PerformAction(Infragistics.Win.UltraWinGrid.UltraComboAction.Dropdown);

            e.Cancel = true;
        }

        #endregion
    }
}
