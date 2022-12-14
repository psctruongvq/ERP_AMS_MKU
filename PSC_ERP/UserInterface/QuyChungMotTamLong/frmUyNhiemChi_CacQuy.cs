using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using ERP_Library;
using ERP_Library.ThanhToan;

namespace PSC_ERP
{
    public partial class frmUyNhiemChi_CacQuy : Form
    {
        #region Properties
        private ERP_Library.UyNhiemChi_CacQuyList _data;
        private int iLoaiDeNghi = 1;
        private string _tenNguoiNhan = "";

        SqlCommand command;
        ReportDocument Report;
        frmHienThiReport dlg;
        SqlDataAdapter adapter;
        DataTable table; 

        int maChungTu = 0;
        #endregion

        #region Loads
        public frmUyNhiemChi_CacQuy()
        {
            InitializeComponent();
        }

        public void ShowUyNhiemChi_CacQuy()
        {
            iLoaiDeNghi = 1;
            this.Text = "Danh sách Ủy Nhiệm Chi các quỹ";
            this.Show();
        }

        public void ShowUyNhiemChi_CongDoan()
        {
            iLoaiDeNghi = 2;
            this.Text = "Danh sách Ủy Nhiệm Chi Công Đoàn";
            this.Show();
        }

        private void frmChungTuNganHang_Load(object sender, EventArgs e)
        {
            txtTuNgay.Value = DateTime.Today;
            txtDenNgay.Value = DateTime.Today;
            LoadData();
        }

        #endregion

        #region Process
        private void LoadData()
        {
            DateTime TuNgay = Convert.ToDateTime(txtTuNgay.Value);
            DateTime DenNgay = Convert.ToDateTime(txtDenNgay.Value);
            _data = ERP_Library.UyNhiemChi_CacQuyList.GetUyNhiemChi_CacQuyList(TuNgay, DenNgay, iLoaiDeNghi);
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
            if (Convert.ToBoolean(e.Rows[0].Cells["HoanTat"].Value))
            {
                MessageBox.Show("Dữ liệu đã hoàn tất nên không thể xóa!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
            else
                e.Cancel = MessageBox.Show("Bạn có muốn xóa chứng từ này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            e.DisplayPromptMsg = false;
        }

        private void grdData_AfterRowsDeleted(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tlThem_Click(object sender, EventArgs e)
        {
            ERP_Library.UyNhiemChi_CacQuy item = _data.AddNew();
            frmUyNhiemChi_CacQuy_Edit f = new frmUyNhiemChi_CacQuy_Edit(iLoaiDeNghi);
            item.LoaiDeNghi = iLoaiDeNghi;
            if (f.ShowEdit(item))
            {
                int iSoChungTu = item.SoChungTu;
                item.So = item.GetSoChungTu(ref iSoChungTu).ToString() + '-' + item.GetMaUNC();
                item.SoChungTu = iSoChungTu;
                SaveData();
                //LoadData();
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
                UyNhiemChi_CacQuy item = (ERP_Library.UyNhiemChi_CacQuy)grdData.ActiveRow.ListObject;
                frmUyNhiemChi_CacQuy_Edit f = new frmUyNhiemChi_CacQuy_Edit(iLoaiDeNghi);
                item.BeginEdit();
                if (f.ShowEdit(item))
                {
                    item.ApplyEdit();
                    SaveData();
                    LoadData();
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

        private void mnuUNC_BIDV_Click(object sender, EventArgs e)
        {
            //Ủy Nhiệm Chi BIDV
            Load_Report("BIDV");
        }

        private void mnuUNC_DA_Click(object sender, EventArgs e)
        {
            Load_Report("Đông Á");
        }

        private void mnuUNC_Exim_Click(object sender, EventArgs e)
        {
            Load_Report("EximBank");
        }

        private void mnuUNC_Vietin_Click(object sender, EventArgs e)
        {
            //Ủy Nhiệm Chi VietinBank
            Load_Report("VietinBank");
        }

        private void mnuUNC_SCB_Click(object sender, EventArgs e)
        {
            Load_Report("SCB");
        }

        private void mnuUNC_KB_Click(object sender, EventArgs e)
        {
            //Ủy Nhiệm Chi Kho bạc
            Load_Report("Kho bạc");
        }

        private void Load_Report(string UNCNganHang)
        {
           
            if (grdData.Selected.Rows.Count > 0)
            {
                //Kiểm tra UNC Đang chọn có đúng với ngân hàng cần in không
                int iMaNganHang = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaNganHang"].Value);
                iMaNganHang = CongTy_NganHang.GetCongTy_NganHang(iMaNganHang).MaNganHang;
                long lNhomNganHang = NganHang.GetNganHang(iMaNganHang).MaNhomNganHang;
                string strTenNganHang = NhomNganHang.GetNhomNganHang(lNhomNganHang).TenNhomNganHang;
                bool bTrung = strTenNganHang.ToUpper().Contains(UNCNganHang.ToUpper());
                if (!bTrung)
                {
                    MessageBox.Show(this, "Mẫu in Ủy Nhiệm Chi không cùng thông tin ngân hàng của Ủy Nhiệm Chi đang chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                //Lấy thông tin Ủy Nhiệm Chi Đang Chọn
                int maChungTu = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaUyNhiemChi"].Value);
                decimal soTien = Convert.ToDecimal(grdData.Selected.Rows[0].Cells["SoTien"].Value);
                string SoTienBangChu = HamDungChung.DocTien(soTien);

                switch (UNCNganHang)
                {
                    case "SCB":
                        Report = new Report.NganHang.UNC_SCB();
                        break;

                    case "Đông Á":
                        Report = new Report.NganHang.UNC_DongA();
                        break;

                    case "EximBank":
                        Report = new Report.NganHang.UNCEximbank();
                        break;

                    case "BIDV":
                        Report = new Report.NganHang.UNC_BIDV();
                        break;

                    case "Kho bạc":
                        Report = new Report.NganHang.UNC_KhoBac();
                        break;

                    case "VietinBank":
                        Report = new Report.NganHang.UNC_VietinBank_CacQuy();
                        _tenNguoiNhan = "Quỹ Chung Một Tấm Lòng";
                        break;

                    default:
                        Report = new Report.NganHang.UNC_BIDV();
                        break;
                }


                command = new SqlCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_UyNhiemChi_CacQuy";

                command.Parameters.AddWithValue("@MaUyNhiemChi", maChungTu);
                command.Parameters.AddWithValue("@TenDonViNhan", _tenNguoiNhan);
                command.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_UyNhiemChi;1";
                Report.SetDataSource(table);

                Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);

                dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
            else
            {
                MessageBox.Show(this, "Vui lòng chọn Ủy Nhiệm Chi cần in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void tlslbl_ExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }
    }
}