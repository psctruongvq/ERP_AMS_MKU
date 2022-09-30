using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
namespace PSC_ERP
{
    public partial class frmButToan_SoQuy : Form
    {
        SoQuyList _soQuyList;
        ButToanList _list;
        BoPhanList _boPhanList;
        HeThongTaiKhoan1List _noTaiKhoanList,_coTaiKhoanList;
        int maSoQuyAll = 0;
        bool loaiThu = false;
        DateTime tuNgay = DateTime.Now.Date;
        DateTime denNgay = DateTime.Now.Date;
        string _boPhanString = "0";
        string _noTaiKhoan = "0";
        string _coTaiKhoan = "0";
        int MaSoQuy1 = 0;
        bool loaiThu1 = false;
        public frmButToan_SoQuy()
        {
            InitializeComponent();
        }
        private void frmLoaiChiPhiSanXuat_Load(object sender, EventArgs e)
        {
            _noTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            HeThongTaiKhoan1 itemAdd=HeThongTaiKhoan1.NewHeThongTaiKhoan1("Tất Cả");
            _noTaiKhoanList.Insert(0, itemAdd);
            _coTaiKhoanList = _noTaiKhoanList;
            this.bdNoTaiKhoan.DataSource = _noTaiKhoanList;
            this.bdCoTaiKhoan.DataSource = _coTaiKhoanList;
            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            bdBoPhan.DataSource = _boPhanList;

            

            _soQuyList = SoQuyList.GetSoQuyList();            
            SoQuy item = SoQuy.NewSoQuy("Không Có");
            _soQuyList.Insert(0, item);
            bdSoQuy.DataSource = _soQuyList;
            SoQuyList soQuyList1 = _soQuyList;
            bdSoQuy1.DataSource = soQuyList1;
            _list = ButToanList.GetButToanListByThuQuy(tuNgay, denNgay, _noTaiKhoan, _coTaiKhoan, _boPhanString);
            bdButToan.DataSource = _list;

            ComboChanged();
            dateTuNgay.Value = tuNgay;
            dateDenNgay.Value = denNgay;
            ((ICheckedItemList)this.cbBoPhan).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(frmButToan_ChiPhiHoatDong_CheckStateChanged);
            ((ICheckedItemList)this.cbCoTaiKhoan).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(CBCoTK_ChiPhiHoatDong_CheckStateChanged);
            ((ICheckedItemList)this.cbNoTaiKhoan).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(CBNoTK_ChiPhiHoatDong_CheckStateChanged);

        }

        void frmButToan_ChiPhiHoatDong_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _boPhanString = string.Empty;
            string boPhanString = string.Empty;
            if (cbBoPhan.ActiveRow != null)
            {
                for (int i = 0; i < cbBoPhan.CheckedRows.Count; i++)
                {
                    string s = cbBoPhan.CheckedRows[i].Cells["MaBoPhan"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cbBoPhan;
                        for (int j = 1; j < this.cbBoPhan.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    boPhanString += s + ",";
                }

                if (boPhanString.Length > 0)
                {
                    _boPhanString = boPhanString.Substring(0, boPhanString.Length - 1);
                }
                else
                    _boPhanString = "0";
            }
        }
        void CBCoTK_ChiPhiHoatDong_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _coTaiKhoan = string.Empty;
            string coTKString = string.Empty;
            if (cbCoTaiKhoan.ActiveRow != null)
            {
                for (int i = 0; i < cbCoTaiKhoan.CheckedRows.Count; i++)
                {
                    string s = cbCoTaiKhoan.CheckedRows[i].Cells["MaTaiKhoan"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cbCoTaiKhoan;
                        for (int j = 1; j < this.cbCoTaiKhoan.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    coTKString += s + ",";
                }

                if (coTKString.Length > 0)
                {
                    _coTaiKhoan = coTKString.Substring(0, coTKString.Length - 1);
                }
                else
                    _coTaiKhoan = "0";
            }
        }
        void CBNoTK_ChiPhiHoatDong_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _noTaiKhoan = string.Empty;
            string noTKString = string.Empty;
            if (cbNoTaiKhoan.ActiveRow != null)
            {
                for (int i = 0; i < cbNoTaiKhoan.CheckedRows.Count; i++)
                {
                    string s = cbNoTaiKhoan.CheckedRows[i].Cells["MaTaiKhoan"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cbNoTaiKhoan;
                        for (int j = 1; j < this.cbNoTaiKhoan.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    noTKString += s + ",";
                }

                if (noTKString.Length > 0)
                {
                    _noTaiKhoan = noTKString.Substring(0, noTKString.Length - 1);
                }
                else
                    _noTaiKhoan = "0";
            }
        }
        private void ComboChanged()
        {
            _list = ButToanList.GetButToanListByThuQuy(tuNgay, denNgay, _noTaiKhoan, _coTaiKhoan, _boPhanString);
            bdButToan.DataSource = _list;
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            bdButToan.EndEdit();
            grdData.UpdateData();

            foreach (ButToan bt in _list)
            {
                if (bt.IsDirty)
                    bt.UpdateButToanSoQuy(bt.MaButToan, bt.MaSoQuy);
            }

            MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            ComboChanged();
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            ComboChanged();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                col.CellActivation = Activation.ActivateOnly;
            }
            grdData.DisplayLayout.Bands[0].Columns["SoHieuTKNo"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoHieuTKNo"].Header.Caption = "TK Nợ";
            grdData.DisplayLayout.Bands[0].Columns["SoHieuTKNo"].Header.VisiblePosition = 0;
            
            grdData.DisplayLayout.Bands[0].Columns["SoHieuTKCo"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoHieuTKCo"].Header.Caption = "TK Có";
            grdData.DisplayLayout.Bands[0].Columns["SoHieuTKCo"].Header.VisiblePosition = 1;
            

            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Width = 120;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = HAlign.Right;

            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 400;

            grdData.DisplayLayout.Bands[0].Columns["MaSoQuy"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaSoQuy"].Width = 100;
            grdData.DisplayLayout.Bands[0].Columns["MaSoQuy"].CellActivation = Activation.AllowEdit;
            grdData.DisplayLayout.Bands[0].Columns["MaSoQuy"].Header.Caption = "Sổ Quỹ";
            grdData.DisplayLayout.Bands[0].Columns["MaSoQuy"].EditorComponent = cbSoQuy1;
            grdData.DisplayLayout.Bands[0].Columns["MaSoQuy"].Header.VisiblePosition = 4;

        }

        private void cbChiPhiHoatDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbSoQuy1, "TenSoQuy");
            foreach (UltraGridColumn col in this.cbSoQuy1.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
        
            cbSoQuy1.DisplayLayout.Bands[0].Columns["TenSoQuy"].Hidden = false;
            cbSoQuy1.DisplayLayout.Bands[0].Columns["TenSoQuy"].Header.Caption = "Tên Sổ Quỹ";
            cbSoQuy1.DisplayLayout.Bands[0].Columns["TenSoQuy"].Width = 250;
            cbSoQuy1.DisplayLayout.Bands[0].Columns["TenSoQuy"].Header.VisiblePosition = 0;

        }

        private void dateTuNgay_ValueChanged(object sender, EventArgs e)
        {
            tuNgay = Convert.ToDateTime(dateTuNgay.Value);
          //  ComboChanged();
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            denNgay = Convert.ToDateTime(dateDenNgay.Value);
           // ComboChanged();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void grdData_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            MessageBox.Show("Không thể xóa dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel=true;
            
        }

        private void cbNoTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbNoTaiKhoan, "SoHieuTK");
            foreach (UltraGridColumn col in this.cbNoTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbNoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cbNoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbNoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbNoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cbNoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbNoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            cbNoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;

            cbNoTaiKhoan.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cbNoTaiKhoan.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cbNoTaiKhoan.CheckedListSettings.CheckStateMember = checkColumn.Key;

        }

      

        private void cbCoTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbCoTaiKhoan, "SoHieuTK");
            foreach (UltraGridColumn col in this.cbCoTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbCoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cbCoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbCoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbCoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cbCoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbCoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            cbCoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;

            cbCoTaiKhoan.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cbCoTaiKhoan.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cbCoTaiKhoan.CheckedListSettings.CheckStateMember = checkColumn.Key;
        }

       

        private void cbBoPhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cbBoPhan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cbBoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cbBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cbBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
            cbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 200;
            cbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;

            cbBoPhan.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cbBoPhan.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cbBoPhan.CheckedListSettings.CheckStateMember = checkColumn.Key;

        }

      

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            ComboChanged();
        }

        private void chọnChiPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChonSoQuy f = new frmChonSoQuy();
            f.ShowDialog();
            if (frmChonSoQuy.IsCheck == true)
            {
                maSoQuyAll = frmChonSoQuy.MaSoQuy;
                foreach (UltraGridRow row in grdData.Selected.Rows)
                {
                    row.Cells["MaSoQuy"].Value = maSoQuyAll;                    
                }
            }
          
        }
        
        private void cbChiPhiHoatDong1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(cbSoQuy, "TenSoQuy");
            HamDungChung h = new HamDungChung();            
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbSoQuy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbSoQuy.DisplayLayout.Bands[0].Columns["TenSoQuy"].Hidden = false;
            cbSoQuy.DisplayLayout.Bands[0].Columns["TenSoQuy"].Header.Caption = "Tên Sổ Quỹ";
            cbSoQuy.DisplayLayout.Bands[0].Columns["TenSoQuy"].Width = 100;
            cbSoQuy.DisplayLayout.Bands[0].Columns["TenSoQuy"].Header.VisiblePosition = 0;

         
        }

        private void cbChiPhiHoatDong1_ValueChanged(object sender, EventArgs e)
        {
            if (cbSoQuy.ActiveRow != null)
            {
                MaSoQuy1 = (int)cbSoQuy.Value;
            }
            foreach (UltraGridRow row in grdData.Rows)
            {
                if (row.IsFilteredOut == false)
                {
                    row.Cells["MaSoQuy"].Value = MaSoQuy1;
                }
            }
        }

    }
}
