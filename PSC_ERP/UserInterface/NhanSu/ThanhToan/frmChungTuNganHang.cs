using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace PSC_ERP.UserInterface.NhanSu.ThanhToan
{
    public partial class frmChungTuNganHang : Form
    {
        #region Properties
        private ERP_Library.ChungTuNganHangList _data;
        private string _tenNguoiNhan = "";//"Đài Truyền Hình TP HCM";

        SqlCommand command;
        ReportDocument Report;
        frmHienThiReport dlg;
        SqlDataAdapter adapter;
        DataTable table; 

        int maChungTu = 0;
        #endregion

        #region Loads
        public frmChungTuNganHang()
        {
            InitializeComponent();
        }

        private void frmChungTuNganHang_Load(object sender, EventArgs e)
        {
            txtTuNgay.Value = DateTime.Today;
            txtDenNgay.Value = DateTime.Today;
            foreach (ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild item in ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList())
                grdData.DisplayLayout.ValueLists["NganHang"].ValueListItems.Add(item.MaChiTiet, item.TenNganHang);
            LoadData();
        }

        #endregion

        #region Process
        private void LoadData()
        {
            _data = ERP_Library.ChungTuNganHangList.GetChungTuNganHangList(txtTuNgay.DateTime, txtDenNgay.DateTime, 0);
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
            ERP_Library.ChungTuNganHang item = _data.AddNew();
            frmChungTuNganHang_Edit f = new frmChungTuNganHang_Edit(false);
            //item.So = item.SoPhieuMoi();
            if (f.ShowEdit(item))
            {
                int iSoChungTu = item.SoChungTu;
                item.So = item.GetSoChungTu(ref iSoChungTu).ToString() + '-' + item.GetMaUNC();
                item.SoChungTu = iSoChungTu;
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
                ERP_Library.ChungTuNganHang item = (ERP_Library.ChungTuNganHang)grdData.ActiveRow.ListObject;
                frmChungTuNganHang_Edit f = new frmChungTuNganHang_Edit();
                item.BeginEdit();
                if (f.ShowEdit(item))
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
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                int MaChungTu = (int)grdData.ActiveRow.Cells["MaChungTu"].Value;
                frmXemIn f = new frmXemIn();
                f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoan.rdlc";
                //f.Report.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptChiTietChuyenKhoan.rdlc";
                f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanList", ERP_Library.Report.ChiTietChuyenKhoanList.GetChiTietChuyenKhoanListByNganHang(MaChungTu));
                f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "VeViec", grdData.ActiveRow.Cells["DienGiai"].Value.ToString());
                f.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                int MaChungTu = (int)grdData.ActiveRow.Cells["MaChungTu"].Value;
                frmXemIn f = new frmXemIn();
                f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoanDVCap2.rdlc";
                //f.Report.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptChiTietChuyenKhoan.rdlc";
                f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanList", ERP_Library.Report.ChiTietChuyenKhoanList.GetChiTietChuyenKhoanListByNganHang(MaChungTu));
                f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "VeViec", grdData.ActiveRow.Cells["DienGiai"].Value.ToString());
                f.ShowDialog();
            }
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

        private void mnuUNC_BIDV_Click(object sender, EventArgs e)
        {
            //Ủy Nhiệm Chi BIDV
            Load_Report("BIDV");
        }

        private void mnuUNC_DA_Click(object sender, EventArgs e)
        {
            Load_Report("DongA");
        }

        private void mnuUNC_Exim_Click(object sender, EventArgs e)
        {
            Load_Report("EximBank");
        }

        private void mnuUNC_Vietin_Click(object sender, EventArgs e)
        {
            //Ủy Nhiệm Chi VietinBank
            Load_Report("Vietin");
        }

        private void mnuUNC_SCB_Click(object sender, EventArgs e)
        {
            Load_Report("SCB");
        }

        private void mnuUNC_KB_Click(object sender, EventArgs e)
        {
            //Ủy Nhiệm Chi Kho bạc
            Load_Report("KhoBac");
        }

        private void Load_Report(string UNCNganHang)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                //Lấy thông tin Ủy Nhiệm Chi Đang Chọn
                int maChungTu = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaChungTu"].Value);
                decimal soTien = Convert.ToDecimal(grdData.Selected.Rows[0].Cells["SoTien"].Value);

                string SoTienBangChu = HamDungChung.DocTien(soTien);


                switch (UNCNganHang)
                {
                    case "SCB":
                        Report = new Report.NganHang.UNC_SCB();
                        break;

                    case "DongA":
                        Report = new Report.NganHang.UNC_DongA();
                        break;

                    case "EximBank":
                        Report = new Report.NganHang.UNCEximbank();
                        break;

                    case "BIDV":
                        Report = new Report.NganHang.UNC_BIDV();
                        break;

                    case "KhoBac":
                        Report = new Report.NganHang.UNC_BIDV();
                        break;

                    case "VietinBank":
                        Report = new Report.NganHang.UNC_VietinBank();
                        break;

                    default:
                        Report = new Report.NganHang.UNC_BIDV();
                        break;
                }


                command = new SqlCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_UyNhiemChi";

                command.Parameters.AddWithValue("@MaChungTu", maChungTu);
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
    }
}