using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace PSC_ERP.ThanhToan
{
    //Thành
    public partial class frmPhieuDeNghiChuyenKhoanCTV : Form
    {
        private bool isLoadData = false;
        GiayXacNhan_TrackingList _list;

        private ERP_Library.ThanhToan.DeNghiChuyenKhoanList _data;
        private string MaPhanHe = "NhanSu";//thay đổi mã này để load các dữ liệu tùy theo phân hệ, chú ý : form edit, form chọn loại chứng từ gốc sẽ tự thay đổi theo

        public frmPhieuDeNghiChuyenKhoanCTV()
        {
            InitializeComponent();
            if (ERP_Library.Security.CurrentUser.Info.MaCongTy == 1)
                cmbKyTen.SelectedIndex = 0;
            else
                cmbKyTen.SelectedIndex = 1;
        }

        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlThem_Click(object sender, EventArgs e)
        {
            frmPhieuDeNghiChuyenKhoan_EditCTV f = new frmPhieuDeNghiChuyenKhoan_EditCTV();
            f.MaPhanHe = MaPhanHe;
            ERP_Library.ThanhToan.DeNghiChuyenKhoan newdata = _data.AddNew();
            newdata.So = newdata.SoPhieuMoi(txtTuNgay.DateTime.Year);
            if (!f.EditData(newdata))
                _data.Remove(newdata);
            else
                _data.Save();
        }

        private void frmPhieuDeNghiChuyenKhoan_Load(object sender, EventArgs e)
        {
            txtTuNgay.DateTime = DateTime.Today;
            txtDenNgay.Value = DateTime.Today;
            foreach (ERP_Library.BoPhan item in ERP_Library.BoPhanList.GetBoPhanList())
            {
                grdData.DisplayLayout.ValueLists["BoPhan"].ValueListItems.Add(item.MaBoPhan, item.TenBoPhan);
            }
            foreach (ERP_Library.NhanVienComboListChild item in ERP_Library.NhanVienComboList.GetNhanVienAll())
            {
                grdData.DisplayLayout.ValueLists["NhanVien"].ValueListItems.Add(item.MaNhanVien, item.TenNhanVien);
            }
            foreach (ERP_Library.DatabaseNumberChild item in ERP_Library.DatabaseNumberList.GetDatabaseNumberList())
            {
                grdData.DisplayLayout.ValueLists["NoiNhan"].ValueListItems.Add(item.DatabaseNumber, item.Ten);
            }
            isLoadData = true;
            LoadData();
            if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 30)
            {
                this.Text = "Danh sách chuyển cho tài chính";
                inPhiếuĐềNghiToolStripMenuItem.Text = "In phiếu chuyển cho tài chính";
            }
        }

        private void LoadData()
        {
            if (isLoadData)
            {
                _data = ERP_Library.ThanhToan.DeNghiChuyenKhoanList.GetDeNghiChuyenKhoanList(txtTuNgay.DateTime, txtDenNgay.DateTime, MaPhanHe,true);
                bdData.DataSource = _data;
            }
        }

        private void NgayChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tlSua_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null)
            {
                frmPhieuDeNghiChuyenKhoan_EditCTV f = new frmPhieuDeNghiChuyenKhoan_EditCTV();
                f.MaPhanHe = MaPhanHe;               
                if (f.EditData((ERP_Library.ThanhToan.DeNghiChuyenKhoan)grdData.ActiveRow.ListObject))
                    _data.Save();
            }
        }

        private void grdData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (e.Row.IsDataRow)
                tlSua.PerformClick(); 
        }

        private void tlXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
            _data.Save();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            if ((bool)e.Rows[0].Cells["DaDuyet"].Value)
            {
                e.Cancel = true;
                MessageBox.Show("Phiếu đề nghị này đã được duyệt chuyển khoản ngân hàng nên không thể xóa", "Đã duyệt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            e.Cancel = MessageBox.Show("Bạn có muốn xóa phiếu đề nghị này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void tlUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void inPhiếuĐềNghiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                long id = Convert.ToInt64(grdData.ActiveRow.Cells["MaPhieu"].Value);
                frmXemIn f = new frmXemIn();
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
                if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 30)
                {
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiChuyenKhoanToChuc.rdlc";
                    f.SetNguoiKy(1);
                }
                else if (Convert.ToInt32(cmbKyTen.Value) != 4)
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiChuyenKhoan.rdlc";
                else
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiChuyenKhoan_BonChuKy.rdlc";
                rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_DeNghiChuyenKhoanList", ERP_Library.Report.DeNghiChuyenKhoanList.GetDeNghiChuyenKhoanList(id)));
                rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { new Microsoft.Reporting.WinForms.ReportParameter("BangChu", ERP_Library.HamDungChung.DocTien(Convert.ToDecimal(grdData.ActiveRow.Cells["SoTien"].Value))) });
                f.SetNguoiKyTheoDCNKMoi((int)cmbKyTen.Value, DateTime.Today);
                f.ShowDialog();
            }
        }

        private void inDanhSáchChuyểnKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                long id = Convert.ToInt64(grdData.ActiveRow.Cells["MaPhieu"].Value);
                frmXemIn f = new frmXemIn();
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
                rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoan.rdlc";
                //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptChiTietChuyenKhoan.rdlc";
                f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanList", ERP_Library.Report.ChiTietChuyenKhoanList.GetChiTietChuyenKhoanList(id));
                f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "VeViec", grdData.ActiveRow.Cells["LyDo"].Value.ToString());
                int NguoiKy = (int)cmbKyTen.Value;
                f.SetNguoiKy_DeNghiCK(NguoiKy);
                f.ShowDialog();
            }

        }

        private void danhSáchGiấyXácNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maPhieuStr = "";
            foreach (UltraGridRow row in grdData.Selected.Rows)
            {
                maPhieuStr += "," + row.Cells["MaPhieu"].Value;
            }
            if (maPhieuStr.Length == 0)
                maPhieuStr = "0";
            else
                maPhieuStr = maPhieuStr.Substring(1);
           
            frmGiayXacNhan_DeNghiChuyenKhoan f = new frmGiayXacNhan_DeNghiChuyenKhoan(maPhieuStr);
            f.Show();
        }

        private void bảngKêThuNhậpNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERP_Library.Report.ChiTietThuNhapThueTamThuList source = ERP_Library.Report.ChiTietThuNhapThueTamThuList.GetChiTietThuNhapThueTamThuList(txtTuNgay.DateTime, txtDenNgay.DateTime);
            frmXemIn f = new frmXemIn();
            f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietThuNhapThueTamThu.rdlc";
            f.SetDatabase("ERP_Library_Report_ChiTietThuNhapThueTamThuList", source);
            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            f.SetNguoiKy(3);
            f.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void tlslbl_InMauCu_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                long id = Convert.ToInt64(grdData.ActiveRow.Cells["MaPhieu"].Value);
                frmXemIn f = new frmXemIn();
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
                if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 30)
                {
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiChuyenKhoanToChuc.rdlc";
                    f.SetNguoiKy(1);
                }
                else
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiChuyenKhoan_Cu.rdlc";
                //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptDeNghiChuyenKhoan.rdlc";
                rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_DeNghiChuyenKhoanList", ERP_Library.Report.DeNghiChuyenKhoanList.GetDeNghiChuyenKhoanList(id)));
                rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { new Microsoft.Reporting.WinForms.ReportParameter("BangChu", ERP_Library.HamDungChung.DocTien(Convert.ToDecimal(grdData.ActiveRow.Cells["SoTien"].Value))) });
                f.ShowDialog();
            }
        }

        private void danhSáchNhânViênNhậpHộToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string maPhieuStr = "";
            foreach (UltraGridRow row in grdData.Selected.Rows)
            {
                maPhieuStr += "," + row.Cells["MaPhieu"].Value;
            }
            if (maPhieuStr.Length == 0)
                maPhieuStr = "0";
            else
                maPhieuStr = maPhieuStr.Substring(1);

            frmGiayXacNhan_DeNghiChuyenKhoan f = new frmGiayXacNhan_DeNghiChuyenKhoan(maPhieuStr, 0);
            f.Show();
        }

        private void inDanhSach1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maPhieuStr = "";
            string soDeNghi = "";
            foreach (UltraGridRow row in grdData.Selected.Rows)
            {
                maPhieuStr += "," + row.Cells["MaPhieu"].Value;
                soDeNghi += ", " + row.Cells["So"].Value;
            }
            if (maPhieuStr.Length == 0)
                maPhieuStr = "0";
            else
                maPhieuStr = maPhieuStr.Substring(1);
            if (soDeNghi.Length == 0)
                soDeNghi = "0";
            else
                soDeNghi = soDeNghi.Substring(1);
            frmXemIn f = new frmXemIn();
            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoanCTVByThue.rdlc";
            //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptChiTietChuyenKhoan.rdlc";
            f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanList", ERP_Library.Report.ChiTietChuyenKhoanList.GetChiTietChuyenKhoanListByThue(maPhieuStr));
            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "VeViec","Số: " +soDeNghi);
            int NguoiKy = (int)cmbKyTen.Value;
            f.SetNguoiKy_DeNghiCK(NguoiKy);
            f.ShowDialog();

        }

        private void inDanhSáchGiấyXácNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maPhieuStr = "";
            string soDeNghi = "";
            foreach (UltraGridRow row in grdData.Selected.Rows)
            {
                maPhieuStr += "," + row.Cells["MaPhieu"].Value;
                soDeNghi += ", " + row.Cells["So"].Value;
            }
            if (maPhieuStr.Length == 0)
                maPhieuStr = "0";
            else
                maPhieuStr = maPhieuStr.Substring(1);
            if (soDeNghi.Length == 0)
                soDeNghi = "0";
            else
                soDeNghi = soDeNghi.Substring(1);
            frmXemIn f = new frmXemIn();
            _list = GiayXacNhan_TrackingList.GetGiayXacNhan_TrackingListByDeNghiChuyenKhoan(maPhieuStr);
            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            rpt.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptDanhSachGiayXacNhan.rdlc";
            f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanList", _list);
            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "VeViec", "Số: " + soDeNghi);
            int NguoiKy = (int)cmbKyTen.Value;
            f.SetNguoiKy_DeNghiCK(NguoiKy);
            f.ShowDialog();
          
        }

        private void inDanhSáchNhânViênNhậpHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maPhieuStr = "";
            string soDeNghi = "";
            foreach (UltraGridRow row in grdData.Selected.Rows)
            {
                maPhieuStr += "," + row.Cells["MaPhieu"].Value;
                soDeNghi += ", " + row.Cells["So"].Value;
            }
            if (maPhieuStr.Length == 0)
                maPhieuStr = "0";
            else
                maPhieuStr = maPhieuStr.Substring(1);
            if (soDeNghi.Length == 0)
                soDeNghi = "0";
            else
                soDeNghi = soDeNghi.Substring(1);
            frmXemIn f = new frmXemIn();
            _list = GiayXacNhan_TrackingList.GetGiayXacNhan_TrackingListByDeNghiChuyenKhoanByNhanVien(maPhieuStr);
            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            rpt.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptDanhSachNhanVienNhapHo.rdlc";
            f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanList", _list);
            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "VeViec", "Số: " + soDeNghi);
            int NguoiKy = (int)cmbKyTen.Value;
            f.SetNguoiKy_DeNghiCK(NguoiKy);
            f.ShowDialog();
          
        }
        SqlCommand command;
        DataSet dataset;
        ReportDocument Report;
        frmHienThiReport dlg;
        SqlDataAdapter adapter;
        DataTable table; 

        private void inDanhSáchTổngHợpChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maPhieuStr = "";
            string soDeNghi = "";
            foreach (UltraGridRow row in grdData.Selected.Rows)
            {
                maPhieuStr += "," + row.Cells["MaPhieu"].Value;
                soDeNghi += ", " + row.Cells["So"].Value;
            }
            if (maPhieuStr.Length == 0)
                maPhieuStr = "0";
            else
                maPhieuStr = maPhieuStr.Substring(1);
            if (soDeNghi.Length == 0)
                soDeNghi = "0";
            else
                soDeNghi = soDeNghi.Substring(1);

            Report = new Report.BaoCaoThuLaoNgoaiDaiTongHopTheoDeNghi();
            command = new SqlCommand();
            dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "[spd_ReportTongHopDanhSachThuLaoNgoaiDaiTheoDeNghi]";
            //command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
            //command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
            //command.Parameters.AddWithValue("@NguoiLap", nguoiLap);
            //command.Parameters.AddWithValue("@UserID", userID);
            //command.Parameters.AddWithValue("@ThanhToan", thanhToan);
            //command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
            //command.Parameters.AddWithValue("@NhapHo", nhapHo);

            command.Parameters.AddWithValue("@MaPhieu", maPhieuStr);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_ReportTongHopDanhSachThuLaoNgoaiDaiTheoDeNghi;1";

            dataset.Tables.Add(table);
            Report.SetDataSource(dataset);
            Report.SetParameterValue("_Chuoi", "Theo Đề Nghị Số: "+ soDeNghi);
            Report.SetParameterValue("@MaPhieu", maPhieuStr);
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
            Report.SetParameterValue("_TenNguoiLap", nguoiky.NguoiLapTen);
            Report.SetParameterValue("_BoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
            dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();

        }
    }
}