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
    public partial class frmGiayBanNgoaiTe : Form
    {
        #region Properties
        private ERP_Library.GiayBanNgoaiTeList _data;
        private string _tenNguoiNhan = "Đài Truyền Hình TP HCM";

        SqlCommand command;
        ReportDocument Report;
        frmHienThiReport dlg;
        SqlDataAdapter adapter;
        DataTable table; 

        long iMaPhieu = 0;
        #endregion

        #region Loads
        public frmGiayBanNgoaiTe()
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
                new string[9] { "SoDeNghi", "NgayXacNhan", "NgayLap", "NganHangBan", "NganHangMua", "SoTien", "TyGia", "LoaiTien", "TieuDe" },
                new string[9] { "Số đề nghị", "Ngày xác nhận", "Ngày lập", "Ngân hàng bán", "Ngân hàng mua", "Số tiền", "Tỷ giá", "Loại tiền", "Tiêu đề" },
                new int[9] { 100, 130, 100, 200, 200, 120, 120, 80, 350 },
                new Control[9] { null, txtTuNgay, null, null, null, null, null, null, null },
                new KieuDuLieu[9] { KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Ngay, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.TienLe, KieuDuLieu.Tien, KieuDuLieu.Null, KieuDuLieu.Null },
                new bool[9] { false, true, false, false, false, false, true, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.White;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
            }
        }
        #endregion

        #region Process
        private void LoadData()
        {
            _data = ERP_Library.GiayBanNgoaiTeList.GetGiayBanNgoaiTeList(txtTuNgay.DateTime, txtDenNgay.DateTime);
            foreach (ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild item in ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList())
                grdData.DisplayLayout.ValueLists["NganHang"].ValueListItems.Add(item.MaChiTiet, item.TenNganHang);
            foreach (LoaiTien item in LoaiTienList.GetLoaiTienList())
                grdData.DisplayLayout.ValueLists["LoaiTien"].ValueListItems.Add(item.MaLoaiTien, item.MaLoaiQuanLy);
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
            grdData.DeleteSelectedRows();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.Cancel = MessageBox.Show("Bạn có muốn xóa chứng từ này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            e.DisplayPromptMsg = false;
        }

        private void grdData_AfterRowsDeleted(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tlThem_Click(object sender, EventArgs e)
        {
            GiayBanNgoaiTe item = _data.AddNew();
            frmGiayBanNgoaiTe_Edit f = new frmGiayBanNgoaiTe_Edit();
            if (f.ShowEdit(item, true))
            {
                int iSoChungTu = 0;
                item.SoDeNghi = item.GetSoChungTu(ref iSoChungTu).ToString() + '-' + item.GetMaDNBNT();

                SaveData();
            }
            else
            {
                _data.Remove(item);
            }
        }

        private void tlSua_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                ERP_Library.GiayBanNgoaiTe item = (ERP_Library.GiayBanNgoaiTe)grdData.ActiveRow.ListObject;
                frmGiayBanNgoaiTe_Edit f = new frmGiayBanNgoaiTe_Edit();
                item.BeginEdit();
                //Sửa
                if (f.ShowEdit(item, false))
                {
                    item.ApplyEdit();
                    SaveData();
                }
                else
                    item.CancelEdit();
            }
        }

        private void grdData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (e.Row.IsDataRow)
                tlSua.PerformClick();
        }

        private void Ngay_Changed(object sender, EventArgs e)
        {
            LoadData();
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
                LoadData();

                MessageBox.Show(this, "Cập nhật thông tin thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        private void tlslblDNBanNgoaiTe_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null)
            {
                ERP_Library.GiayBanNgoaiTe item = (ERP_Library.GiayBanNgoaiTe)grdData.ActiveRow.ListObject;
                ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
                iMaPhieu = item.MaPhieu;

                Report = new Report.NganHang.rpt_GiayDeNghiBanNT();
                command = new SqlCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_tblGiayBanNgoaiTe";

                command.Parameters.AddWithValue("@MaPhieu", iMaPhieu);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_tblGiayBanNgoaiTe;1";
                Report.SetDataSource(table);

                //Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                //Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                //Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);

                Report.SetParameterValue("_tenBoPhan", nguoiky.ThuTruongTen);
                Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                Report.SetParameterValue("_tenThuTruong", nguoiky.TenTongGiamDoc);

                dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
        }
        GiayBanNgoaiTe _giayBanNgoaiTeNew = GiayBanNgoaiTe.NewGiayBanNgoaiTe();
        private void toolStripButton_Coppy_Click(object sender, EventArgs e)
        {
            GiayBanNgoaiTe _giayBanNgoaiTeOld = GiayBanNgoaiTe.NewGiayBanNgoaiTe();
            if (grdData.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Chọn dòng cần coppy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                _giayBanNgoaiTeNew = GiayBanNgoaiTe.NewGiayBanNgoaiTe();
                _giayBanNgoaiTeOld = (GiayBanNgoaiTe)bdChungTu.Current;
                 int iSoChungTu = 0;
                 _giayBanNgoaiTeNew.LoaiMatHang = _giayBanNgoaiTeOld.LoaiMatHang;
                 _giayBanNgoaiTeNew.LoaiTien = _giayBanNgoaiTeOld.LoaiTien;
                 //_giayBanNgoaiTeNew.MaPhieu = _giayBanNgoaiTeOld.LoaiMatHang;
                 _giayBanNgoaiTeNew.MucDichThanhToan = _giayBanNgoaiTeOld.MucDichThanhToan;
                 _giayBanNgoaiTeNew.NganHangBan = _giayBanNgoaiTeOld.NganHangBan;
                 _giayBanNgoaiTeNew.NganHangMua = _giayBanNgoaiTeOld.NganHangMua;
                 _giayBanNgoaiTeNew.NgayLap = _giayBanNgoaiTeOld.NgayLap;
                 _giayBanNgoaiTeNew.NgaySoSach = _giayBanNgoaiTeOld.NgaySoSach;
                // _giayBanNgoaiTeNew.NgayXacNhan = _giayBanNgoaiTeOld.NgayXacNhan;
                 _giayBanNgoaiTeNew.SoDeNghi = _giayBanNgoaiTeNew.GetSoChungTu(ref iSoChungTu).ToString() + '-' + _giayBanNgoaiTeNew.GetMaDNBNT();
                 _giayBanNgoaiTeNew.SoKheUoc = _giayBanNgoaiTeOld.SoDeNghi;
                 _giayBanNgoaiTeNew.SoTien = _giayBanNgoaiTeOld.SoTien;
                 _giayBanNgoaiTeNew.SoTienBangChu = _giayBanNgoaiTeOld.SoTienBangChu;
                 _giayBanNgoaiTeNew.TieuDe = _giayBanNgoaiTeOld.TieuDe;
                 _giayBanNgoaiTeNew.TyGia = _giayBanNgoaiTeOld.TyGia;
                 _giayBanNgoaiTeNew.UserID = _giayBanNgoaiTeOld.UserID;
               
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Chọn dòng cần coppy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                _data.Insert(0, _giayBanNgoaiTeNew);
            }
        }
    }
}