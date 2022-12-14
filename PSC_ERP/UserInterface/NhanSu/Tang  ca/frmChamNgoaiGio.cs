using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{

    public partial class frmChamNgoaiGio : Form
    {
        private ERP_Library.NgoaiGio_TongHopList _data;
        private bool isupdate = false, isLoad = true;
        private int DaDuyet = 0;
        private int ChuaDuyet = 0;
        private int KhongDuyet = 0;

        public frmChamNgoaiGio()
        {
            InitializeComponent();
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdData.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(grdData_BeforeRowsDeleted);
            grdData.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(grdData_AfterCellUpdate);
            grdData.BeforeEnterEditMode += new CancelEventHandler(grdData_BeforeEnterEditMode);
        }

        void grdData_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (grdData.ActiveCell!=null)
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow && grdData.ActiveCell.Tag != null && (grdData.ActiveCell.Tag as ERP_Library.NgoaiGio_ChiTiet).LoaiDuyet == 1)
            {
                MessageBox.Show("Dữ liệu này đã được duyệt nên không thể thay đổi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        void grdData_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            //cập nhật lại giá trị cho bảng dọc
            if (e.Cell.Column.Key.StartsWith("col") && isupdate && grdData.ActiveRow.IsDataRow)
            {
                if (e.Cell.Tag != null)
                {
                    ERP_Library.NgoaiGio_ChiTiet tmp = (ERP_Library.NgoaiGio_ChiTiet)e.Cell.Tag;
                    try
                    {
                        tmp.SoGio = Convert.ToDecimal(e.Cell.Value);
                    }
                    catch 
                    {
                        tmp.SoGio = 0;                        
                    }

                }
                else
                {
                    ERP_Library.NgoaiGio_ChiTiet tmp = ERP_Library.NgoaiGio_ChiTiet.NewNgoaiGio_ChiTiet();
                    try
                    {
                        tmp.SoGio = Convert.ToDecimal(e.Cell.Value);
                    }
                    catch
                    {
                        e.Cell.Value = 0;
                        tmp.SoGio = 0;
                    }
                    tmp.MaLoai = Convert.ToInt32(e.Cell.Column.Key.Remove(0,3));
                    e.Cell.Tag = tmp;
                    ((ERP_Library.NgoaiGio_TongHop)e.Cell.Row.ListObject).ChiTiet.Add(tmp);
                    //cập nhật màu và loại duyệt
                    tmp.SetLoaiDuyet((int)cmbBoPhan.Value, tmp.MaLoai);
                    if (tmp.LoaiDuyet == 0)
                    {
                        e.Cell.Appearance.BackColor = Color.LightCoral;
                        ChuaDuyet++;
                        lblChuaDuyet.Text = ChuaDuyet.ToString("#,###");
                    }
                    else if (tmp.LoaiDuyet==2)
                    {
                        e.Cell.Appearance.BackColor = Color.Gold;
                        KhongDuyet++;
                        lblKhongDuyet.Text = KhongDuyet.ToString("#,###");
                    }
                }
            }
        }

        void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            //kiểm tra dữ liệu đã duyệt trước khi xóa
            bool hl = true;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in e.Rows)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridCell cell in item.Cells)
                    if (cell.Tag != null && Convert.ToDecimal(cell.Value) != 0 && (cell.Tag as ERP_Library.NgoaiGio_ChiTiet).LoaiDuyet == 1)
                    {
                        hl = false;
                        break;
                    }
                if (!hl) break;
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
            ERP_Library.NgoaiGio_TongHop tmp;
            DaDuyet = ChuaDuyet = KhongDuyet = 0;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in grdData.Rows)
            {
                tmp = (ERP_Library.NgoaiGio_TongHop)row.ListObject;
                foreach (ERP_Library.NgoaiGio_ChiTiet item in tmp.ChiTiet)
                {
                    row.Cells["col" + item.MaLoai].Value = item.SoGio;
                    row.Cells["col" + item.MaLoai].Tag = item;
                    if (item.SoGio != 0)
                    {
                        switch (item.LoaiDuyet)
                        {
                            case 0:
                                row.Cells["col" + item.MaLoai].Appearance.BackColor = Color.LightCoral;
                                ChuaDuyet++;
                                break;
                            case 1:
                                row.Cells["col" + item.MaLoai].Appearance.BackColor = Color.LightBlue;
                                DaDuyet++;
                                break;
                            case 2:
                                row.Cells["col" + item.MaLoai].Appearance.BackColor = Color.Gold;
                                KhongDuyet++;
                                break;
                            default:
                                break;
                        }
                    }
                }
                row.Update();
            }
            isupdate = true;
            lblChuaDuyet.Text = ChuaDuyet.ToString("#,###");
            lblDaDuyet.Text = DaDuyet.ToString("#,###");
            lblKhongDuyet.Text = KhongDuyet.ToString("#,###");
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

        private void frmChamNgoaiGio_Load(object sender, EventArgs e)
        {
            lblChuaDuyet.Text = lblDaDuyet.Text = lblKhongDuyet.Text = "";
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            //khởi tạo các cột loại ngoài giờ
            ERP_Library.LoaiTangCaList lst = ERP_Library.LoaiTangCaList.GetLoaiTangCaList();
            Infragistics.Win.UltraWinGrid.UltraGridColumn col;
            Infragistics.Win.UltraWinGrid.SummarySettings sum;
            foreach (ERP_Library.LoaiTangCa item in lst)
            {
                col = grdData.DisplayLayout.Bands[0].Columns.Add("col" + item.MaLoaiTangCa, item.TenLoaiTangCa);
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
                col.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
                col.MaskInput = "{double}";
                //col.Format = "#.#";
                col.DataType = typeof(decimal);
                col.CellDisplayStyle = Infragistics.Win.UltraWinGrid.CellDisplayStyle.FormattedText;
                col.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
                col.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
                col.Tag = item.MaLoaiTangCa;
                //row tổng cộng
                sum = grdData.DisplayLayout.Bands[0].Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, col);
                sum.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                sum.DisplayFormat = "{0:#,###.##}";
            }

            //kiểm tra phân quyền sử dụng chức năng kiểm duyệt
            bool hl = false;
            if (ERP_Library.Security.CurrentUser.IsAdminNhanSu || ERP_Library.Security.CurrentUser.Info.CapNhatChamCong)
            {
                hl = true;
            }
            toolFind.Enabled = hl;
            btnDuyetTatCa.Enabled = hl; 
            btnDuyetDangChon.Enabled = hl;
        }

        private void LoadData()
        {
            if (isLoad && cmbKyLuong.Value != null && cmbBoPhan.Value != null && cmbKyCham.Value != null)
            {
                _data = ERP_Library.NgoaiGio_TongHopList.GetNgoaiGio_TongHopList((int)cmbKyLuong.Value, (int)cmbKyCham.Value,(int)cmbBoPhan.Value);
                bdData.DataSource = _data;
                CapNhatSoGio();
            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null && cmbBoPhan.Value != null)
            {
                frmChamNgoaiGioTongHop f = new frmChamNgoaiGioTongHop();
                if (f.ChamNgoaiGio((ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject, (ERP_Library.BoPhan)cmbBoPhan.SelectedRow.ListObject))
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
                }
            }
            else
            {
                MessageBox.Show("Chọn Tháng lương và bộ phận!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (cmbKyLuong.Value != null)
            {
                if (_data != null && _data.IsDirty)
                {
                    if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        SaveData();
                }

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

            if (cmbKyLuong.Value != null && cmbBoPhan.Value != null)
                cmbKyCham.DataSource = ERP_Library.KyTinhLuongList.GetKyChamNgoaiGioTongHop((int)cmbKyLuong.Value, (int)cmbBoPhan.Value);

            LoadData();
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (_data != null && _data.IsDirty)
            {
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
            }
            if (cmbKyLuong.Value != null && cmbBoPhan.Value != null)
                cmbKyCham.DataSource = ERP_Library.KyTinhLuongList.GetKyChamNgoaiGioTongHop((int)cmbKyLuong.Value, (int)cmbBoPhan.Value);

            LoadData();
        }

        private void cmbKyCham_ValueChanged(object sender, EventArgs e)
        {
            if (_data != null && _data.IsDirty)
            {
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
            }

            LoadData();
        }

        private void toolFind_Click(object sender, EventArgs e)
        {
            frmChamNgoaiGioChuaDuyet f = new frmChamNgoaiGioChuaDuyet();
            f.ShowDialog();
            if (f.OK)
            {
                isLoad = false;
                cmbKyLuong.Value = f.MaKyTinhLuong;
                cmbBoPhan.Value = f.MaBoPhan;
                cmbKyCham.Value = f.MaKyChamCong;
                isLoad = true;
                LoadData();
            }
        }

        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData >= Keys.D0 && e.KeyData<= Keys.D9) || (e.KeyData>= Keys.NumPad0 && e.KeyData<=Keys.NumPad9) && grdData.ActiveCell != null && grdData.ActiveCell.Column.DataType == typeof(decimal))
            {
                grdData.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
        }

        private void grdData_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            if (grdData.ActiveCell != null && grdData.ActiveRow.IsDataRow && grdData.ActiveCell.Tag != null && (grdData.ActiveCell.Tag as ERP_Library.NgoaiGio_ChiTiet).LoaiDuyet == 1)
            {
                MessageBox.Show("Dữ liệu này đã được duyệt nên không thể thay đổi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            if (grdData.ActiveRow != null)
            {
                if (grdData.ActiveRow.IsFilterRow == false)
                {
                    if (!e.Cancel && grdData.ActiveCell != null && grdData.ActiveCell.Column.Tag != null)
                    {
                        int maloai = Convert.ToInt32(grdData.ActiveCell.Column.Tag);
                        if (maloai == 2 || maloai == 3 || maloai == 12)
                        {

                            decimal tong = (grdData.ActiveRow.ListObject as ERP_Library.NgoaiGio_TongHop).TinhTongNgoaiGio(maloai, chkTheoKyChamCong.Checked);
                            if (e.NewValue != null && e.NewValue != DBNull.Value)
                                tong += Convert.ToDecimal(e.NewValue);
                            //tính số giờ ở các cột khác do store chỉ tính giờ ở những kỳ khác, còn kỳ hiện tại có thể new nên chưa lưu, vì vậy cần cộng thêm trên grid
                            foreach (ERP_Library.NgoaiGio_ChiTiet item in (grdData.ActiveRow.ListObject as ERP_Library.NgoaiGio_TongHop).ChiTiet)
                                if (item.MaLoai != maloai && (item.MaLoai == 2 || item.MaLoai == 3 || item.MaLoai == 12))
                                    tong += item.SoGio;


                            decimal max = ERP_Library.Default_Ngay.GetDefault_Ngay().TongSoGioNgoaiGio;
                            if (tong > max)
                                e.Cancel = MessageBox.Show("Thời gian chấm ngoài giờ vượt quá giới hạn : " + max.ToString("#,###") + "\r\nThời gian bạn chấm là : " + tong.ToString("#,###") + "\r\nBạn có muốn tiếp tục nhập không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No;
                        }
                    }
                }
            }
        }

        private void btnDuyetTatCa_Click(object sender, EventArgs e)
        {
            foreach (ERP_Library.NgoaiGio_TongHop item in _data)
                foreach (ERP_Library.NgoaiGio_ChiTiet chitiet in item.ChiTiet)
                    if (chitiet.LoaiDuyet == 0)
                    {
                        chitiet.LoaiDuyet = 1;
                    }
            try
            {
                grdData.UpdateData();
                _data.Save();
                CapNhatSoGio();
                MessageBox.Show("Dữ liệu đã được duyệt!", "Duyệt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void btnDuyetDangChon_Click(object sender, EventArgs e)
        {
            if (grdData.Selected != null && grdData.Selected.Cells != null && grdData.Selected.Cells.Count > 0)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridCell cell in grdData.Selected.Cells)
                    if (cell.Tag != null && Convert.ToDecimal(cell.Value) != 0 && (cell.Tag as ERP_Library.NgoaiGio_ChiTiet).LoaiDuyet == 0)
                    {
                        (cell.Tag as ERP_Library.NgoaiGio_ChiTiet).LoaiDuyet = 1;
                    }

                try
                {
                    grdData.UpdateData();
                    _data.Save();
                    CapNhatSoGio();
                    MessageBox.Show("Dữ liệu đã được duyệt!", "Duyệt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
                }
            }
        }

        private void btnBoDuyet_Click(object sender, EventArgs e)
        {
            foreach (ERP_Library.NgoaiGio_TongHop item in _data)
                foreach (ERP_Library.NgoaiGio_ChiTiet chitiet in item.ChiTiet)
                    if (chitiet.LoaiDuyet == 1)
                    {
                        chitiet.LoaiDuyet = 0;
                    }
            try
            {
                grdData.UpdateData();
                _data.Save();
                CapNhatSoGio();
                MessageBox.Show("Dữ liệu đã được bỏ duyệt!", "Duyệt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }
    }
}