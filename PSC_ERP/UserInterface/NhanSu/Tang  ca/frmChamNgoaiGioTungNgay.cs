using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmChamNgoaiGioTungNgay : Form
    {
        private ERP_Library.NgoaiGioTungNgay_TongHopList _data;
        private bool isupdate = false;
        public frmChamNgoaiGioTungNgay()
        {
            InitializeComponent();
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdData.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(grdData_BeforeRowsDeleted);
            grdData.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(grdData_AfterCellUpdate);
            grdData.BeforeEnterEditMode += new CancelEventHandler(grdData_BeforeEnterEditMode);
        }

        void grdData_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (grdData.ActiveCell != null)
                if (grdData.ActiveRow != null && (bool)grdData.ActiveRow.Cells["DaDuyet"].Value)
                {
                    MessageBox.Show("Dữ liệu này đã được duyệt nên không thể thay đổi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
        }

        void grdData_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            //cập nhật lại giá trị cho bảng dọc
            if (e.Cell.Column.Key.StartsWith("col") && isupdate)
            {
                if (e.Cell.Tag != null)
                {
                    ERP_Library.NgoaiGioTungNgay_ChiTiet tmp = (ERP_Library.NgoaiGioTungNgay_ChiTiet)e.Cell.Tag;
                    tmp.SoGio = Convert.ToDecimal(e.Cell.Value);
                }
                else
                {
                    ERP_Library.NgoaiGioTungNgay_ChiTiet tmp = ERP_Library.NgoaiGioTungNgay_ChiTiet.NewNgoaiGioTungNgay_ChiTiet();
                    tmp.SoGio = Convert.ToDecimal(e.Cell.Value);
                    tmp.MaLoai = Convert.ToInt32(cmbHinhThuc.Value);
                    int ngay = Convert.ToInt32(e.Cell.Column.Key.Remove(0, 3));
                    DateTime d = ((ERP_Library.KyTinhLuong)cmbKyCham.SelectedItem.ListObject).NgayBatDau;
                    if (d.Day > ngay)
                        d = ((ERP_Library.KyTinhLuong)cmbKyCham.SelectedItem.ListObject).NgayKetThuc;
                    tmp.Ngay = new DateTime(d.Year, d.Month, ngay);
                    e.Cell.Tag = tmp;
                    ((ERP_Library.NgoaiGioTungNgay_TongHop)e.Cell.Row.ListObject).ChiTiet.Add(tmp);
                }

                decimal tong = 0;
                for (int i = 1; i <= 31; i++)
                    tong += Convert.ToDecimal(e.Cell.Row.Cells["col" + i].Value);
                e.Cell.Row.Cells["TongCong"].Value = tong;
            }
        }

        void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            //kiểm tra dữ liệu đã duyệt trước khi xóa
            bool hl = true;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in e.Rows)
                if ((bool)item.Cells["DaDuyet"].Value)
                {
                    hl = false;
                    break;
                }
            if (hl)
            {
                e.DisplayPromptMsg = false;
                e.Cancel = MessageBox.Show("Bạn có muốn xóa chấm ngoài giờ nhân viên này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            }
            else
            {
                e.DisplayPromptMsg = false;
                e.Cancel = true;
                MessageBox.Show("Không thể xóa dữ liệu đã được duyệt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //chuyển dữ liệu từ bảng dọc sang bảng ngang trên khung lưới
        private void CapNhatSoGio()
        {
            isupdate = false;
            ERP_Library.NgoaiGioTungNgay_TongHop tmp;
            decimal tong = 0;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in grdData.Rows)
            {
                tong = 0;
                tmp = (ERP_Library.NgoaiGioTungNgay_TongHop)row.ListObject;
                foreach (ERP_Library.NgoaiGioTungNgay_ChiTiet item in tmp.ChiTiet)
                {
                    row.Cells["col" + item.Ngay.Day].Value = item.SoGio;
                    tong += item.SoGio;
                    row.Cells["col" + item.Ngay.Day].Tag = item;
                }
                row.Cells["TongCong"].Value = tong;
                row.Update();
            }
            isupdate = true;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (_data != null && _data.IsDirty)
            {
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
            }
            this.Close();
        }

        private void frmChamNgoaiGioTungNgay_Load(object sender, EventArgs e)
        {
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbHinhThuc.DataSource = ERP_Library.HinhThucTangCaList.GetHinhThucTangCaList();

            //khởi tạo 31 cột ngày
            Infragistics.Win.UltraWinGrid.UltraGridColumn col;
            Infragistics.Win.UltraWinGrid.SummarySettings sum;
            for (int i = 1; i <= 31; i++)
            {
                col = grdData.DisplayLayout.Bands[0].Columns.Add("col" + i, i.ToString());
                col.DataType = typeof(decimal);
                col.Format = "#.##;-#.##;";
                col.MaskInput = "{double:1.1}";
                col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
                col.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
                col.CellDisplayStyle = Infragistics.Win.UltraWinGrid.CellDisplayStyle.FormattedText;
                col.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                col.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
                col.Width = 40;

                //dòng tổng cộng
                sum = grdData.DisplayLayout.Bands[0].Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, col);
                sum.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                sum.DisplayFormat = "{0:#.#}";
            }
            col = grdData.DisplayLayout.Bands[0].Columns.Add("TongCong", "Tổng cộng");
            col.DataType = typeof(decimal);
            col.Format = "#.##;-#.##;";
            col.CellDisplayStyle = Infragistics.Win.UltraWinGrid.CellDisplayStyle.FormattedText;
            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            //dòng tổng cộng
            sum = grdData.DisplayLayout.Bands[0].Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, col);
            sum.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            sum.DisplayFormat = "{0:#.#}";
        }

        private void LoadData()
        {
            if (cmbKyLuong.Value != null && cmbBoPhan.Value != null && cmbHinhThuc.Value != null && cmbKyCham.Value != null)
            {
                _data = ERP_Library.NgoaiGioTungNgay_TongHopList.GetNgoaiGioTungNgay_TongHopList((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, (int)cmbHinhThuc.Value, (int)cmbKyCham.Value);
                bdData.DataSource = _data;
                CapNhatSoGio();
                CapNhatHienThiCotNgay();
            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null && cmbBoPhan.Value != null && cmbHinhThuc.Value != null)
            {
                if (_data == null) //tạo dữ liệu default nếu chưa có chọn được kỳ chấm
                {
                    _data = ERP_Library.NgoaiGioTungNgay_TongHopList.GetNgoaiGioTungNgay_TongHopList((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, (int)cmbHinhThuc.Value, 0);
                    bdData.DataSource = _data;
                }
                frmThemChamNgoaiGioTungNgay f = new frmThemChamNgoaiGioTungNgay();
                if (f.ChamNgoaiGio((ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject, (ERP_Library.BoPhan)cmbBoPhan.SelectedRow.ListObject, (ERP_Library.HinhThucTangCaChild)cmbHinhThuc.SelectedItem.ListObject))
                {
                    //cập nhật thêm Kỳ chấm công vào combobox của form chính
                    if (cmbKyCham.Value != f.cmbKyCham.Value)
                    {
                        ERP_Library.KyTinhLuongList kycham;
                        kycham = (ERP_Library.KyTinhLuongList)cmbKyCham.DataSource;
                        ERP_Library.KyTinhLuong ky = null;
                        foreach (ERP_Library.KyTinhLuong k in kycham)
                            if (k.MaKy == (int)f.cmbKyCham.Value)
                            {
                                ky = k;
                                break;
                            }
                        if (ky == null)
                        {
                            ky = kycham.AddNew();
                            ky.MaKy = (int)f.cmbKyCham.Value;
                            ky.TenKy = f.cmbKyCham.Text;
                        }
                        if (!ky.MaKy.Equals(cmbKyCham.Value))
                            cmbKyCham.Value = ky.MaKy;
                    }
                    f.CapNhatDuLieu(_data);
                    CapNhatSoGio();
                    CapNhatHienThiCotNgay();
                }
            }
            else
            {
                MessageBox.Show("Chọn Tháng lương, bộ phận, hình thức chấm ngoài giờ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (_data == null) return;
            if (cmbKyLuong.Value == null || cmbBoPhan.Value == null) return;
            //kiểm tra khóa sổ
            ERP_Library.KyTinhLuong t = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value);
            if (t.KhoaSoKy2)
            {
                MessageBox.Show("Tháng lương này đã khóa sổ nên không thể lưu dữ liệu!", "Khóa sổ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveData();
        }

        private void SaveData()
        {
            try
            {
                grdData.UpdateData();
                _data.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null && cmbBoPhan.Value != null && cmbHinhThuc.Value != null && cmbKyCham.Value != null)
            {
                if (_data != null && _data.IsDirty && tlslblLuu.Enabled)
                {
                    if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        SaveData();
                }
                LoadData();
            }
            if (sender != cmbKyCham && cmbKyLuong.Value != null && cmbBoPhan.Value != null && cmbHinhThuc.Value != null)
            {
                    cmbKyCham.DataSource = ERP_Library.KyTinhLuongList.GetKyChamNgoaiGioTungNgay((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, (int)cmbHinhThuc.Value);
            }
            if (sender == cmbKyLuong)
            {
                //kiểm tra khóa sổ
                ERP_Library.KyTinhLuong kyluong = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value);
                if (kyluong.KhoaSoKy2)
                {
                    tlslblLuu.Enabled = false;
                    tlslblThem.Enabled = false;
                    grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
                    grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                    MessageBox.Show("Kỳ tính lương này đã khóa sổ nên không thể cập nhật", "Khóa sổ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    tlslblLuu.Enabled = true;
                    tlslblThem.Enabled = true;
                    grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
                    grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
                }
            }
        }

        private void chkDay_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatHienThiCotNgay();
        }

        private void CapNhatHienThiCotNgay()
        {
            if (chkDay.Checked)
            {
                bool b;
                for (int i = 1; i <= 31; i++)
                {
                    b = true;
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow r in grdData.Rows)
                        if (r.Cells["col" + i].Value is decimal && (decimal)r.Cells["col" + i].Value > 0)
                        {
                            b = false;
                            break;
                        }

                    grdData.DisplayLayout.Bands[0].Columns["col" + i].Hidden = b;

                }
            }
            else
                for (int i = 1; i <= 31; i++)
                    grdData.DisplayLayout.Bands[0].Columns["col" + i].Hidden = false;
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value == null || cmbBoPhan.Value == null || cmbKyCham.Value == null || cmbHinhThuc.Value == null) return;
            frmXemIn f = new frmXemIn();
            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangChamNgoaiGioTungNgay.rdlc";
            //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptBangChamNgoaiGioTungNgay.rdlc";
            rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_ChamNgoaiGioTungNgayList", ERP_Library.Report.ChamNgoaiGioTungNgayList.GetChamNgoaiGioTungNgayList((int)cmbKyLuong.Value, (int)cmbKyCham.Value, (int)cmbBoPhan.Value, (int)cmbHinhThuc.Value)));
            Microsoft.Reporting.WinForms.ReportParameter kycham = new Microsoft.Reporting.WinForms.ReportParameter("KyCham", cmbKyCham.Text);
            Microsoft.Reporting.WinForms.ReportParameter bophan = new Microsoft.Reporting.WinForms.ReportParameter("BoPhan", cmbBoPhan.Text);
            Microsoft.Reporting.WinForms.ReportParameter hinhthuc = new Microsoft.Reporting.WinForms.ReportParameter("HinhThuc", cmbHinhThuc.Text);
            rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { kycham, bophan, hinhthuc });
            f.ShowDialog();
        }

    }
}