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
    public partial class frmGiayRutTien_CacQuy : Form
    {
        #region Properties
        private ERP_Library.GiayRutTien_CacQuyList _data;

        SqlCommand command;
        ReportDocument Report;
        frmHienThiReport dlg;
        SqlDataAdapter adapter;
        DataTable table;

        private int _loaiDeNghi = 0;

        long iMaPhieu = 0;
        #endregion

        #region Loads
        public void ShowGiayRutTien_CacQuy()
        {
            _loaiDeNghi = 1;
            this.Text += " Các quỹ";
            this.Show();
        }

        public void ShowGiayRutTien_CongDoan()
        {
            _loaiDeNghi = 2;
            this.Text += " Công đoàn";
            this.Show();
        }
   
        public frmGiayRutTien_CacQuy()
        {
            InitializeComponent();
        }

        private void frmGiayRutTien_Load(object sender, EventArgs e)
        {
            txtTuNgay.Value = DateTime.Today;
            txtDenNgay.Value = DateTime.Today;
            LoadData();
        }

        #endregion

        #region Process
        private void LoadData()
        {
            _data = ERP_Library.GiayRutTien_CacQuyList.GetGiayRutTien_CacQuyList(txtTuNgay.DateTime, txtDenNgay.DateTime, _loaiDeNghi);
            bdChungTu.DataSource = _data;

            TTNhanVienRutGonList _thongTinList = TTNhanVienRutGonList.GetNhanVienListAll();
            TTNhanVienRutGon nv = TTNhanVienRutGon.NewTTNhanVienRutGon(0, "Chưa chọn");
            _thongTinList.Insert(0, nv);
            cmbu_NguoiNhan.DataSource = _thongTinList;

            foreach (ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild item in ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList())
                grdData.DisplayLayout.ValueLists["NganHang"].ValueListItems.Add(item.MaChiTiet, item.SoTaiKhoan);
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
            GiayRutTien_CacQuy item = _data.AddNew();
            frmGiayRutTien_CacQuy_Edit f = new frmGiayRutTien_CacQuy_Edit(_loaiDeNghi);
            item.LoaiDeNghi = _loaiDeNghi;
            if (f.ShowEdit(item, true))
            {
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
                ERP_Library.GiayRutTien_CacQuy item = (ERP_Library.GiayRutTien_CacQuy)grdData.ActiveRow.ListObject;
                frmGiayRutTien_CacQuy_Edit f = new frmGiayRutTien_CacQuy_Edit(_loaiDeNghi);
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

        private void tlslblDNBanNgoaiTe_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null)
            {
                ERP_Library.GiayRutTien item = (ERP_Library.GiayRutTien)grdData.ActiveRow.ListObject;
                iMaPhieu = item.MaGiayRutTien;

                Report = new Report.NganHang.rpt_GiayRutTien();
                command = new SqlCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_tblGiayRutTien";

                command.Parameters.AddWithValue("@MaGiayRutTien", iMaPhieu);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_tblGiayRutTien;1";
                Report.SetDataSource(table);

                Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);

                dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
        }
    }
}