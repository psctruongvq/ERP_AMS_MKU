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
    public partial class frmButToan_ChiPhiHoatDong : Form
    {
        ChiPhiHoatDongList _chiPhiHoatDongList;
        ButToan_ChiPhiHDList _list;
        BoPhanList _boPhanList;
        HeThongTaiKhoan1List _noTaiKhoanList,_coTaiKhoanList;
        int maChiPhiAll = 0;
        bool loaiThu = false;
        DateTime tuNgay = DateTime.Now.AddDays(-10).Date;
        DateTime denNgay = DateTime.Now.Date;
        string _boPhanString = "0";
        string _noTaiKhoan = "0";
        string _coTaiKhoan = "0";
        int maChiPhiAll1 = 0;
        bool loaiThu1 = false;
        public frmButToan_ChiPhiHoatDong()
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
            _chiPhiHoatDongList = ChiPhiHoatDongList.GetChiPhiHoatDongList();            
            ChiPhiHoatDong itemAdd1 = ChiPhiHoatDong.NewChiPhiHoatDong("Không Có");
            _chiPhiHoatDongList.Insert(0, itemAdd1);
            this.bdChiPhiHoatDong.DataSource = _chiPhiHoatDongList;
            ChiPhiHoatDongList chiPhiList1 = _chiPhiHoatDongList;
            bdChiPhiHoatDong1.DataSource = chiPhiList1;
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
            _list = ButToan_ChiPhiHDList.GetButToan_ChiPhiHDList(tuNgay, denNgay,_noTaiKhoan,_coTaiKhoan,_boPhanString);
            bdButToan_ChiPhiHoatDong.DataSource = _list;
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            bdButToan_ChiPhiHoatDong.EndEdit();
            grdData.UpdateData();
            _list.ApplyEdit();
            _list.Save();
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
            }
            grdData.DisplayLayout.Bands[0].Columns["TenButToan"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TenButToan"].Header.Caption = "Tên Bút Toán";
            grdData.DisplayLayout.Bands[0].Columns["TenButToan"].Width = 450;
            grdData.DisplayLayout.Bands[0].Columns["TenButToan"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["TenButToan"].CellActivation = Activation.ActivateOnly;

            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].CellActivation = Activation.ActivateOnly;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;

            grdData.DisplayLayout.Bands[0].Columns["MaChiPhiHD"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaChiPhiHD"].Header.Caption = "Tên Chi Phí";
            grdData.DisplayLayout.Bands[0].Columns["MaChiPhiHD"].EditorComponent = cbChiPhiHoatDong;
            grdData.DisplayLayout.Bands[0].Columns["MaChiPhiHD"].Header.VisiblePosition = 2;

            grdData.DisplayLayout.Bands[0].Columns["ThuChi"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["ThuChi"].Header.Caption = "Loại Thu";            
            grdData.DisplayLayout.Bands[0].Columns["ThuChi"].Header.VisiblePosition = 3;

        }

        private void cbChiPhiHoatDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChiPhiHoatDong, "TenChiPhiHD");
            foreach (UltraGridColumn col in this.cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Hidden = false;
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Header.Caption = "Mã Quản Lý";
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Width = 100;
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Header.VisiblePosition = 0;

            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Hidden = false;
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Header.Caption = "Tên Chi Phí";
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Width = 200;
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Header.VisiblePosition = 1;

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

        private void cbBoPhan_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            ComboChanged();
        }

        private void chọnChiPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChonChiPhi f = new frmChonChiPhi();
            f.ShowDialog();
            if (frmChonChiPhi.IsCheck == true)
            {
                maChiPhiAll = frmChonChiPhi.MaChiPhi;
                loaiThu = frmChonChiPhi.LoaiThu;
                foreach (UltraGridRow row in grdData.Selected.Rows)
                {
                    row.Cells["MaChiPhiHD"].Value = maChiPhiAll;
                    row.Cells["ThuChi"].Value = loaiThu;
                }
            }
        }
        
        private void cbChiPhiHoatDong1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(cbChiPhiHoatDong1, "TenChiPhiHD");
            HamDungChung h = new HamDungChung();            
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbChiPhiHoatDong1.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbChiPhiHoatDong1.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Hidden = false;
            cbChiPhiHoatDong1.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Header.Caption = "Mã Quản Lý";
            cbChiPhiHoatDong1.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Width = 100;
            cbChiPhiHoatDong1.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Header.VisiblePosition = 0;

            cbChiPhiHoatDong1.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Hidden = false;
            cbChiPhiHoatDong1.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Header.Caption = "Tên Chi Phí";
            cbChiPhiHoatDong1.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Width = 200;
            cbChiPhiHoatDong1.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Header.VisiblePosition = 1;
        }

        private void cbChiPhiHoatDong1_ValueChanged(object sender, EventArgs e)
        {
            if (cbChiPhiHoatDong1.ActiveRow != null)
            {
                maChiPhiAll1 = (int)cbChiPhiHoatDong1.Value;
            }
            foreach (UltraGridRow row in grdData.Rows)
            {
                if (row.IsFilteredOut == false)
                {
                    row.Cells["MaChiPhiHD"].Value = maChiPhiAll1;
                }
            }
        }

        private void cbLoaiThu1_CheckedChanged(object sender, EventArgs e)
        {
            loaiThu1 = (bool)cbLoaiThu1.Checked;
            foreach (UltraGridRow row in grdData.Rows)
            {
                if (row.IsFilteredOut == false)
                {
                    row.Cells["ThuChi"].Value = loaiThu1;
                }
            }
        }

    }
}
