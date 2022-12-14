using ERP_Library.Security;
using System;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmThongTinNhanVienTrichNgang : Form
    {
        private ERP_Library.ThongTinNhanVienTrichNgangList _data;
        private bool CellChanged = true;
        int userID = CurrentUser.Info.UserID;
        public frmThongTinNhanVienTrichNgang()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongTinNhanVienTrichNgang_Load(object sender, EventArgs e)
        {
            bdBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanListAll(userID);
            grdData.DisplayLayout.ValueLists["DocHai"].ValueListItems.Add(0, "");
            foreach (ERP_Library.LoaiDocHai item in ERP_Library.LoaiDocHaiList.GetLoaiDocHaiList())
            {
                grdData.DisplayLayout.ValueLists["DocHai"].ValueListItems.Add(item.MaDocHai, item.Ten);
            }
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            //cài đặt hiển thị các cột chi tiết
            foreach (ERP_Library.NhanVien_CauHinh item in ERP_Library.NhanVien_CauHinhList.GetNhanVien_CauHinhList())
            {
                Infragistics.Win.UltraWinGrid.UltraGridColumn col = grdData.DisplayLayout.Bands[0].Columns.Add("col" + item.MaCauHinh, item.Ten);
                col.Tag = item;
                Infragistics.Win.Appearance a;
                switch (item.LoaiDuLieu)
                {
                    case "Số":
                        a = new Infragistics.Win.Appearance();
                        a.TextHAlign = Infragistics.Win.HAlign.Right;
                        col.CellAppearance = a;
                        col.MaskInput = "nnnnnnnnnnn";
                        col.Format = "#,###";
                        col.DataType = typeof(decimal);
                        break;
                    case "Ký tự":
                        col.DataType = typeof(string);
                        col.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
                        break;
                    case "Ngày":
                        a = new Infragistics.Win.Appearance();
                        a.TextHAlign = Infragistics.Win.HAlign.Center;
                        col.CellAppearance = a;
                        col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
                        col.DefaultCellValue = DateTime.Today;
                        col.DataType = typeof(DateTime);
                        break;
                    case "Yes/No":
                        col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        col.DataType = typeof(bool);
                        col.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
                        break;
                    default:
                        break;
                }
            }
            //------------------
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.Value != null)
            {
                if (_data != null && _data.IsDirty)
                {
                    cmbBoPhan.PerformAction(Infragistics.Win.UltraWinGrid.UltraComboAction.CloseDropdown);
                    if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tlslblLuu.PerformClick();
                    }
                }
                _data = ERP_Library.ThongTinNhanVienTrichNgangList.GetThongTinNhanVienTrichNgangList(Convert.ToInt32(cmbBoPhan.Value));
                bdData.DataSource = _data;
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grdData.UpdateData();
                _data.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _data = ERP_Library.ThongTinNhanVienTrichNgangList.GetThongTinNhanVienTrichNgangList(Convert.ToInt32(cmbBoPhan.Value));
            bdData.DataSource = _data;
        }

        private void frmThongTinNhanVienTrichNgang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_data != null && _data.IsDirty)
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tlslblLuu.PerformClick();
                }
        }

        private void grdData_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            //cập nhật dữ liệu cho các cột
            if (e.Row.IsDataRow && !e.ReInitialize)
            {
                ERP_Library.ThongTinNhanVienTrichNgang nv = (ERP_Library.ThongTinNhanVienTrichNgang)e.Row.ListObject;
                foreach (ERP_Library.NhanVien_DuLieu item in nv.ChiTiet)
                {
                    CellChanged = false;
                    if (e.Row.Cells["col" + item.MaCauHinh].Column.DataType == typeof(DateTime))
                    {
                        try
                        {
                            DateTime d = DateTime.ParseExact(item.DuLieu, "dd/MM/yy", null);
                            e.Row.Cells["col" + item.MaCauHinh].Value = d;
                        }
                        catch 
                        {
                            //MessageBox.Show("Lỗi xữ lý dữ liệu kiểu ngày của mã nhân viên " + nv.MaNhanVien, "Lỗi");                            
                        }
                    }
                    else
                        try
                        {
                            e.Row.Cells["col" + item.MaCauHinh].Value = item.DuLieu;
                        }
                        catch { }
                    CellChanged = true;
                    e.Row.Cells["col" + item.MaCauHinh].Tag = item;
                }
            }
        }

        private void grdData_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            //lưu lại dữ liệu vào object
            if (e.Cell.Column.Key.StartsWith("col") && CellChanged && e.Cell.Row.IsDataRow)
            {
                if (e.Cell.Tag != null)
                {
                    if (e.Cell.Column.DataType == typeof(DateTime))
                        try
                        {
                            ((ERP_Library.NhanVien_DuLieu)e.Cell.Tag).DuLieu = Convert.ToDateTime(e.Cell.Value).ToString("dd/MM/yy");
                        }
                        catch
                        {
                            ((ERP_Library.NhanVien_DuLieu)e.Cell.Tag).DuLieu = "";
                        }
                    else
                        try
                        {
                            ((ERP_Library.NhanVien_DuLieu)e.Cell.Tag).DuLieu = e.Cell.Value.ToString();
                        }
                        catch 
                        {
                            ((ERP_Library.NhanVien_DuLieu)e.Cell.Tag).DuLieu = "";
                        }
                    if (((ERP_Library.NhanVien_DuLieu)e.Cell.Tag).DuLieu == "")
                    {
                        ((ERP_Library.ThongTinNhanVienTrichNgang)e.Cell.Row.ListObject).ChiTiet.Remove((ERP_Library.NhanVien_DuLieu)e.Cell.Tag);
                    }
                }
                else
                {
                    ERP_Library.ThongTinNhanVienTrichNgang nv = (ERP_Library.ThongTinNhanVienTrichNgang)e.Cell.Row.ListObject;
                    ERP_Library.NhanVien_DuLieu dl = ERP_Library.NhanVien_DuLieu.NewNhanVien_DuLieuChild();
                    dl.MaNhanVien = nv.MaNhanVien;
                    dl.MaCauHinh = ((ERP_Library.NhanVien_CauHinh)e.Cell.Column.Tag).MaCauHinh;
                    try
                    {
                        if (e.Cell.Column.DataType == typeof(DateTime))
                            dl.DuLieu = Convert.ToDateTime(e.Cell.Value).ToString("dd/MM/yy");
                        else
                            dl.DuLieu = e.Cell.Value.ToString();
                    }
                    catch
                    {
                        dl.DuLieu = "";
                    }
                    e.Cell.Tag = dl;
                    nv.ChiTiet.Add(dl);
                }
            }
        }

        private bool iskeyok = false;//xử lý key cho cột string
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdData.ActiveCell != null && !grdData.ActiveCell.IsInEditMode && grdData.ActiveCell.Column.Key != "TenNhanVien")
            {
                if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                {
                    grdData.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    grdData.ActiveCell.SelectAll();
                    if (grdData.ActiveCell.Column.DataType == typeof(string))
                    {
                        iskeyok = true;
                    }
                }
                if (e.KeyCode == Keys.Space && grdData.ActiveCell.Column.DataType == typeof(bool))
                {
                    grdData.ActiveCell.Value = !Convert.ToBoolean(grdData.ActiveCell.Value);
                }
            }
        }

        private void grdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (iskeyok)
            {
                grdData.ActiveCell.Value = e.KeyChar;
                grdData.ActiveCell.SelStart = grdData.ActiveCell.Text.Length;
                e.Handled = true;
                iskeyok = false;
            }
        }
        //xử lý copy 1 cell cho nhiều cell
        private bool iscopyok = false;
        private object copyvalue;
        private void grdData_BeforeMultiCellOperation(object sender, Infragistics.Win.UltraWinGrid.BeforeMultiCellOperationEventArgs e)
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
                    if (iscopyok && grdData.Selected != null && grdData.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdData.Selected.Cells)
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

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }
    }
}