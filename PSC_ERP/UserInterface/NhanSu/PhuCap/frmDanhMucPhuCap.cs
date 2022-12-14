using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmDanhMucPhuCap : Form
    {
        private ERP_Library.PhuCapList _Data;
        private ERP_Library.NhanVien_CauHinhList _cauhinh;
        private string currDK = "";


        public frmDanhMucPhuCap()
        {
            InitializeComponent();

            grdDieuKien.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(grdDieuKien_BeforeCellActivate);
        }

        void grdDieuKien_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].MaskInput = "";
            grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;

            if (e.Cell.Column.Key == "GiaTri")
            {
                string dk = e.Cell.Row.Cells["DieuKien"].Value.ToString();         
                if (dk == "Số năm thâm niên")
                {
                    grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                    grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].MaskInput = "##";
                }
                else if (dk == "Ngày vào Đài")
                {
                    grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                    grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].MaskInput = "{LOC}dd/mm/yy";
                    grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                    grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].MaskDisplayMode =  Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                }
                else if (dk == "Hệ số bù" | dk == "Hệ số độc hại" | dk == "Hệ số bổ sung" | dk == "Hệ số lương" | dk == "Hệ số nội bộ" | dk == "Hệ số phụ cấp")
                {
                    grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                    grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                    grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                    grdDieuKien.DisplayLayout.Bands[0].Columns["GiaTri"].MaskInput = "#.##";
                }
                if (dk != currDK)
                {
                    currDK = dk;
                    Infragistics.Win.ValueListItemsCollection lst = grdDieuKien.DisplayLayout.ValueLists["GiaTri"].ValueListItems;
                    lst.Clear();
                    switch (dk)
                    {
                        case "Toàn đài":
                            e.Cancel = true;
                            break;
                        case "Bộ phận":
                            foreach (ERP_Library.BoPhan item in ERP_Library.BoPhanList.GetBoPhanList())
                                lst.Add(item.TenBoPhan);
                            break;
                        case "Chức vụ":
                            foreach (ERP_Library.ChucVu item in ERP_Library.ChucVuList.GetChucVuList())
                                lst.Add(item.TenChucVu);
                            break;
                        case "Chức danh":
                            foreach (ERP_Library.ChucDanh item in ERP_Library.ChucDanhList.GetChucDanhList())
                                lst.Add(item.TenChucDanh);
                            break;
                        case "Trách nhiệm":
                            break;
                        case "Số năm thâm niên":
                            break;
                        case "Ngày vào Đài":
                            break;
                        case "Công việc":
                            break;
                        case "Loại nhân viên":
                            foreach (ERP_Library.LoaiNhanVienChild item in ERP_Library.LoaiNhanVienList.GetLoaiNhanVienList())
                                lst.Add(item.TenLoaiNhanVien);
                            break;
                        case "Phụ cấp hành chính":
                            lst.Add("True");
                            lst.Add("False");
                            break;
                        case "Giới Tính":
                            lst.Add("Nam");
                            lst.Add("Nữ");
                            break;
                        case "Số ngày làm việc trong tháng":
                            break;
                        case "Kỳ tính lương":
                            foreach (ERP_Library.KyTinhLuong item in ERP_Library.KyTinhLuongList.GetKyTinhLuongList())
                                lst.Add(item.TenKy);
                            break;
                        case "Loại độc hại":
                            foreach (ERP_Library.LoaiDocHai item in ERP_Library.LoaiDocHaiList.GetLoaiDocHaiList())
                            {
                                lst.Add(item.Ten);
                            }
                            break;
                        default:
                            foreach (ERP_Library.NhanVien_CauHinh item in _cauhinh)
                            {
                                if (item.Ten == dk)
                                {
                                    if (item.LoaiDuLieu == "Yes/No")
                                    {
                                        lst.Add("True");
                                        lst.Add("False");
                                        break;
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDanhMucPhuCap_Load(object sender, EventArgs e)
        {
            bdNhomPC.DataSource = ERP_Library.NhomPhuCapList.GetNhomPhuCapList();

            foreach (ERP_Library.PhuCapFieldChild i in ERP_Library.PhuCapFieldList.GetPhuCapFieldListDieuKien())
                grdDieuKien.DisplayLayout.ValueLists["DieuKien"].ValueListItems.Add(i.TenField, i.TenField);

            //thêm các field cấu hình
            _cauhinh = ERP_Library.NhanVien_CauHinhList.GetNhanVien_CauHinhList();
            foreach (ERP_Library.NhanVien_CauHinh item in _cauhinh)
            {
                grdDieuKien.DisplayLayout.ValueLists["DieuKien"].ValueListItems.Add(item.Ten, item.Ten);
            }
            foreach (ERP_Library.PhuCapFieldChild i in ERP_Library.PhuCapFieldList.GetPhuCapFieldListCongThuc())
            {
                mnCongThuc.Items.Add(i.TenField);
            }
            mnCongThuc.Items.Add("-");
            foreach (ERP_Library.HinhThucTangCaChild i in ERP_Library.HinhThucTangCaList.GetHinhThucTangCaList())
            {
                mnCongThuc.Items.Add("Số " + i.ThoiGian.ToLower() + " " + i.TenLoaiTangCa);
            }

            cmbNhanVien.LoadData();
        }

        private void LoadData()
        {
            if (cmbPhanLoai.Value != null)
            {
                _Data = ERP_Library.PhuCapList.GetPhuCapListByLoaiPhuCap((int)cmbPhanLoai.Value);
                bdData.DataSource = _Data;
            }
        }

        private bool SaveData()
        {
            try
            {
                grdDieuKien.UpdateData();
                bdData.EndEdit();
                _Data.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _Data);
            }
            return false;
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (cmbPhanLoai.Value != null)
            {
                bdData.AddNew();
                grdData.Selected.Rows.Clear();
                grdData.Selected.Rows.Add(grdData.Rows[grdData.Rows.Count - 1]);
                ((ERP_Library.PhuCapChild)bdData.Current).MaLoaiPhuCap = (int)cmbPhanLoai.Value;
            }
            else
            {
                MessageBox.Show("Chọn phân loại phụ cấp trước khi cập nhật dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbPhanLoai_ValueChanged(object sender, EventArgs e)
        {
            if (_Data != null && _Data.IsDirty)
            {
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveData();
                }
            }
            LoadData();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (_Data != null)
                SaveData();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa phụ cấp này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.No;
        }

        private void grdDieuKien_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa điều kiện này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Information)== DialogResult.No;
        }

        private void txtCongThuc_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            mnCongThuc.Show(Control.MousePosition);
        }

        private void mnCongThuc_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string s = txtCongThuc.Text;
            string a = e.ClickedItem.Text;
            a = "[" + a + "]";
            int i = txtCongThuc.SelectionStart;
            s = s.Insert(i, a);
            txtCongThuc.Text = s;
            txtCongThuc.SelectionStart = i + a.Length;
        }

        private void frmDanhMucPhuCap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Data != null && _Data.IsDirty)
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();          
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grdDieuKien_BeforeColRegionScroll(object sender, Infragistics.Win.UltraWinGrid.BeforeColRegionScrollEventArgs e)
        {
            if (cmbNhanVien.Visible) cmbNhanVien.Visible = false;
        }

        private void grdDieuKien_BeforeRowRegionScroll(object sender, Infragistics.Win.UltraWinGrid.BeforeRowRegionScrollEventArgs e)
        {
            if (cmbNhanVien.Visible) cmbNhanVien.Visible = false;
        }

 

        private void grdDieuKien_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell objCell = grdDieuKien.ActiveCell;
            if (objCell == null) return;
            if (objCell.Column.Key != "GiaTri" || !cmbNhanVien.Visible) return;

            cmbNhanVien.Visible = false;

            //cài đặt value cho điều kiện
            grdDieuKien.ActiveCell.Value = cmbNhanVien.GetTextMaTen();
        }

        private void grdDieuKien_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell objCell = grdDieuKien.ActiveCell;
            if (objCell == null) return;
            if (objCell.Column.Key != "GiaTri" || objCell.Row.Cells["DieuKien"].Value.ToString() != "Nhân viên") return;

            Infragistics.Win.UltraWinGrid.CellUIElement element;
            try
            {
                element = (Infragistics.Win.UltraWinGrid.CellUIElement)objCell.GetUIElement(grdDieuKien.ActiveRowScrollRegion, grdDieuKien.ActiveColScrollRegion);
            }
            catch
            {
                return;
            }
            int left = element.RectInsideBorders.Location.X + grdDieuKien.Location.X;
            int top = element.RectInsideBorders.Location.Y + grdDieuKien.Location.Y;
            int width = element.RectInsideBorders.Width;
            int height = element.RectInsideBorders.Height;

            cmbNhanVien.SetBounds(left, top, width, height);
            //thay đổi set giá trị nhân viên ban đầu
            //cmbNhanVien.Value = objCell.Value;

            grdDieuKien.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChange;//chặn ngăn không cho grid update khi mất focus do focus vào control combobox

            cmbNhanVien.Visible = true;
            cmbNhanVien.Focus();
            cmbNhanVien.BringToFront();

            e.Cancel = true;
        }

        private void cmbNhomPhuCap_ValueChanged(object sender, EventArgs e)
        {
            if (cmbNhomPhuCap.Value != null)
                bdLoai.DataSource = ERP_Library.LoaiPhuCapList.GetLoaiPhuCapByMaNhom((int)cmbNhomPhuCap.Value);
        }

        private void toolCopy_Click(object sender, EventArgs e)
        {
            if (cmbPhanLoai.Value == null)
            {
                MessageBox.Show("Bạn cần phải chọn phụ cấp để copy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmCopyPhuCap f = new frmCopyPhuCap();
            if (f.ShowCopy(cmbPhanLoai.SelectedItem.ListObject as ERP_Library.LoaiPhuCapChild))
            {
                bdLoai.DataSource = ERP_Library.LoaiPhuCapList.GetLoaiPhuCapByMaNhom((int)cmbNhomPhuCap.Value);
                cmbPhanLoai.Value = f.NewID;
                MessageBox.Show("Đã copy thành công!", "Copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbNhanVien_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                grdDieuKien.Focus();
                this.Visible = false;

                //cài đặt value cho điều kiện
                grdDieuKien.ActiveCell.Value = cmbNhanVien.GetTextMaTen();

                if ((Control.ModifierKeys & Keys.Shift) != 0)
                    grdDieuKien.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                else
                    grdDieuKien.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                e.Handled = true;
            }
        }

        private void cmbNhanVien_ValueChanged(object sender, EventArgs e)
        {
           
                grdDieuKien.Focus();
                grdDieuKien.ActiveCell.Value = cmbNhanVien.GetTextMaTen();

        }
    }
}