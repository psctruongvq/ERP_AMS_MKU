using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using ERP_Library;

namespace PSC_ERP
{

    //Thành
    public partial class frmDanhSachHDDichVu : Form
    {
        #region Properties
        private HopDongMuaBanList _data;

        long iMaPhieu = 0;
        #endregion

        #region Loads
        public frmDanhSachHDDichVu()
        {
            InitializeComponent();
        }

        private void frmChungTuNganHang_Load(object sender, EventArgs e)
        {
            txtTuNgay.Value = DateTime.Today;
            txtDenNgay.Value = DateTime.Today;
            LoadData();
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grdData.DisplayLayout.Bands[0],
               new string[8] { "SoHopDong", "TenHopDong", "TenDoiTac", "NgayLap", "NgayHetHan", "SoTienDatCoc", "TongTien", "MaLoaiTien" },
               new string[8] { "Số hợp đồng", "Tên hợp đồng", "Tên đối tác", "Ngày lập", "Ngày hết hạn", "Số tiền ký quỹ", "Số tiền", "Loại tiền" },
               new int[8] { 100, 150, 150, 100, 100, 120, 120, 100 },
               new Control[8] { null, null, null, null, null, null, null, cmbu_LoaiTien },
               new KieuDuLieu[8] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Ngay, KieuDuLieu.TienLe, KieuDuLieu.TienLe, KieuDuLieu.Null },
               new bool[8] { false, false, false, false, false, false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.White;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion

        #region Process
        private void LoadData()
        {
            _data = HopDongMuaBanList.GetHopDongMuaBanList(txtTuNgay.DateTime, txtDenNgay.DateTime);
            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            bdChungTu.DataSource = _data;

        }

        private void SaveData()
        {
            try
            {
                _data.Save();
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }
        #endregion

        #region Event
        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tlXoa_Click(object sender, EventArgs e)
        {
            foreach (UltraGridRow rowSelected in this.grdData.Selected.Rows)
            {
                if (rowSelected.IsDataRow)
                {
                    HopDongMuaBan hdmb = rowSelected.ListObject as HopDongMuaBan;

                    //if (HopDongMuaBan.KiemTraHopDongDaPhatSinhPhuLucHayNghiemThu(hdmb.MaHopDong))
                    //{
                    //    MessageBox.Show(this, "Hợp đồng đã phát sinh Phụ lục hay đã Nghiệm thu thanh lý, Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;

                    //}
                    //else
                    {
                        if (MessageBox.Show("Bạn có muốn xóa chứng từ này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            grdData.DeleteSelectedRows();
                    }
                }
            }


        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {

            //e.Cancel = MessageBox.Show("Bạn có muốn xóa chứng từ này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            //e.DisplayPromptMsg = false;
        }

        private void grdData_AfterRowsDeleted(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tlThem_Click(object sender, EventArgs e)
        {
            HopDongMuaBan item = _data.AddNew();
            frmHopDongDichVu f = new frmHopDongDichVu(item);
            f.ShowDialog();
            if (f._OK)
            {
                SaveData();
            }
            else
            {
                _data.Remove(item);
            }

            LoadData();
        }

        private void tlSua_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                HopDongMuaBan item = (HopDongMuaBan)grdData.ActiveRow.ListObject;
                frmHopDongDichVu f = new frmHopDongDichVu(item);
                item.BeginEdit();
                f.ShowDialog();
                //Sửa
                if (f._OK)
                {
                    item.ApplyEdit();
                    SaveData();
                }
                else
                    item.CancelEdit();
            }
            LoadData();
        }

        private void grdData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (e.Row.IsDataRow)
                tlSua.PerformClick();
        }

        private void Ngay_Changed(object sender, EventArgs e)
        {
            LoadData();
            if (_data.Count == 0)
                MessageBox.Show("Danh Sách Hợp đồng rỗng!");
        }

        private void tlIn_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grdData.UpdateData();
                bdChungTu.EndEdit();
                _data.ApplyEdit();
                _data.Save();

                MessageBox.Show(this, "Cập nhật thông tin thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}