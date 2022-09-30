using System;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using ERP_Library.Security;

namespace PSC_ERP.UserInterface.NhanSu.NghiViec
{
    public partial class frmPhepNamTruoc : Form
    {
        private PhepNamTruocList _phepNamTruocList;
        BoPhanList _boPhanList;
        ThongTinNhanVienTongHopList _thongTinNhanVienTongHopList;
        int userID = CurrentUser.Info.UserID;
        public frmPhepNamTruoc()
        {
            InitializeComponent();
            for (int i = 2010; i <= 2020; i++)
            {
                cb_Nam.Items.Add(i);
            }
            cb_Nam.Text = DateTime.Today.Year.ToString();
            _boPhanList = BoPhanList.GetBoPhanListByUserID(userID);
            BoPhan itemBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _boPhanList.Insert(0, itemBoPhan);
            bindingSource_BoPhan.DataSource = _boPhanList;

            ultraGrid_Data.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            ultraGrid_Data.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            ultraGrid_Data.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));


            ultraGrid_Data.KeyDown += new KeyEventHandler(ultraGrid_Data_KeyDown);
            ultraGrid_Data.KeyPress += new KeyPressEventHandler(ultraGrid_Data_KeyPress);
            ultraGrid_Data.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(ultraGrid_Data_BeforeMultiCellOperation);

        }

        //xử lý copy 1 cell cho nhiều cell
        private bool iscopyok = false;
        private object copyvalue;

        void ultraGrid_Data_BeforeMultiCellOperation(object sender, BeforeMultiCellOperationEventArgs e)
        {
            if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Copy)
            {
                if (e.Cells.RowCount == 1 && e.Cells.ColumnCount == 1)
                {
                    iscopyok = true;
                    copyvalue = e.Cells[0, 0].Value;
                }
            }
            else
                if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Paste)
                {
                    if (iscopyok && ultraGrid_Data.Selected != null && ultraGrid_Data.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in ultraGrid_Data.Selected.Cells)
                        {
                            try
                            {
                                item.Value = copyvalue;
                                item.Row.Update();
                            }
                            catch { }
                        }
                    }
                    iscopyok = false;
                }
        }

        void ultraGrid_Data_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (iskeyok && ultraGrid_Data.ActiveCell.Row.IsDataRow)
            {
                if (ultraGrid_Data.ActiveCell.Column.DataType == typeof(decimal))
                    try
                    {
                        ultraGrid_Data.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                    }
                    catch
                    { }
                else
                    ultraGrid_Data.ActiveCell.Value = e.KeyChar.ToString();
                ultraGrid_Data.ActiveCell.SelStart = ultraGrid_Data.ActiveCell.Text.Length;
                e.Handled = true;
                iskeyok = false;
            }
        }

        private bool iskeyok = false;//xử lý key cho cột string
     
        void ultraGrid_Data_KeyDown(object sender, KeyEventArgs e)
        {
            if (ultraGrid_Data.ActiveCell != null && !ultraGrid_Data.ActiveCell.IsInEditMode && ultraGrid_Data.ActiveCell.Column.Key != "TenNhanVien")
            {
                if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                {
                    ultraGrid_Data.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    ultraGrid_Data.ActiveCell.SelectAll();
                    iskeyok = true;
                }
                if (e.KeyCode == Keys.Space && ultraGrid_Data.ActiveCell.Column.DataType == typeof(bool))
                {
                    ultraGrid_Data.ActiveCell.Value = !Convert.ToBoolean(ultraGrid_Data.ActiveCell.Value);
                }
            }
        }

      
        public void KhoiTao()
        {
            if (cmbu_Bophan.Value != null)
            {
                _phepNamTruocList = PhepNamTruocList.GetPhepNamTruocList(Convert.ToInt32(cb_Nam.Text), (int)cmbu_Bophan.Value);
                bindingSource_PhepNamTruocList.DataSource = _phepNamTruocList;
            }
        }

        private void ultraGrid_Data_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraGrid_Data.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.Format = "#,###.##";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
                col.CellActivation = Activation.NoEdit;
            }
            // Turn on all of the Cut, Copy, and Paste functionality. 
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;

            // In order to cut or copy, the user needs to select cells or rows. 
            // So set CellClickAction so that clicking on a cell selects that cell
            // instead of going into edit mode.
            e.Layout.Override.CellClickAction = CellClickAction.CellSelect;
           

            ultraGrid_Data.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = false;
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.Caption = "Bộ Phận";
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.VisiblePosition = 0;
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["MaBoPhan"].EditorComponent = cmbu_Bophan;
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["MaBoPhan"].Width = 150;

            ultraGrid_Data.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Nhân Viên";
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["TenNhanVien"].EditorComponent = ultraCombo_NhanVienList;
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 200;

            ultraGrid_Data.DisplayLayout.Bands[0].Columns["Nam"].Hidden = false;
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["Nam"].Header.Caption = "Năm";
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["Nam"].Width = 80;
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["Nam"].Header.VisiblePosition = 2;

            ultraGrid_Data.DisplayLayout.Bands[0].Columns["SoNgay"].Hidden = false;
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["SoNgay"].Header.Caption = "Số Ngày Phép";
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["SoNgay"].Width = 80;
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["SoNgay"].Header.VisiblePosition = 2;
            ultraGrid_Data.DisplayLayout.Bands[0].Columns["SoNgay"].CellActivation = Activation.AllowEdit;
        }

        private void cb_Nam_SelectedValueChanged(object sender, EventArgs e)
        {
            KhoiTao();
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        private void cmbu_Bophan_Leave(object sender, EventArgs e)
        {
            KhoiTao();
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {

            KhoiTao();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
                _thongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByDatabase((int)cmbu_Bophan.Value, false);
                bindingSource_NhanVienList.DataSource = _thongTinNhanVienTongHopList;
                _phepNamTruocList = PhepNamTruocList.NewPhepNamTruocList();
                foreach (ThongTinNhanVienTongHop nv in _thongTinNhanVienTongHopList)
                {
                    PhepNamTruoc phep = PhepNamTruoc.NewPhepNamTruoc();
                    phep.MaNhanVien = nv.MaNhanVien;
                    phep.TenNhanVien = nv.TenNhanVien;
                    phep.SoNgay = 0;
                    phep.MaBoPhan = nv.MaBoPhan;
                    phep.Nam = Convert.ToInt32(cb_Nam.Text);
                    phep.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                    phep.NgayLap = DateTime.Today.Date;
                    _phepNamTruocList.Add(phep);
                }
                bindingSource_PhepNamTruocList.DataSource = _phepNamTruocList;

            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource_PhepNamTruocList.EndEdit();
                _phepNamTruocList.Save();
                MessageBox.Show(this, "Cập nhật thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Lỗi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
                
        }
    }
}
