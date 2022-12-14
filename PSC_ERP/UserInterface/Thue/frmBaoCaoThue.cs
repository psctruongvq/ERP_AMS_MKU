using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.Data.SqlClient;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Data.OleDb;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace PSC_ERP
{
    public partial class frmBaoCaoThue : Form
    {
        #region Properties

        public static int _maKy = 0;
        public static DateTime _dtNgay = DateTime.Now;
        int macongty = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet = new DataSet();

        DateTime _dtTuNgay = DateTime.Today;
        DateTime _dtDenNgay = DateTime.Today;
        #endregion

        #region Load
        public frmBaoCaoThue()
        {
            InitializeComponent();
            Load_Source();
        }            
        #endregion

        #region Process
        private void Load_Source()
        {
            cbo_Ky.DataSource = KyList.GetKyList();
            dtmp_Ngay.Value = DateTime.Now;
            BoPhanList _boPhanList = BoPhanList.GetBoPhanList();
            _boPhanList.Insert(0, BoPhan.NewBoPhan(0, "Tất cả"));
            BoPhanList_bindingSource.DataSource = _boPhanList;
            kyTinhLuongListBindingSource.DataSource = KyTinhLuongList.GetKyTinhLuongList();
        }

        #region thue GTGT
        public void Tao_bangkeMuavao()
        {
            int sorecord = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "[spd_taodulieu_01_2GTGT]";
                    cm.CommandText = "spd_taodulieu_BangKeHoaDonMuaVao_Modify";
                    cm.Parameters.AddWithValue("@Maky", _maKy);
                    cm.Parameters.AddWithValue("@Ngay", _dtNgay);
                    cm.Parameters.AddWithValue("@Mabophan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.ExecuteNonQuery();
                  //  sorecord = (int)cm.ExecuteNonQuery();
                }
            }

        }
        private void In_BangkeMuavao_rpt(int macongty)
        {
            Tao_bangkeMuavao();
            ReportDocument Report = new Report.Thue.Thue01_2GTGT();
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "spd_REPORT_ReportHeader";
            command.Parameters.AddWithValue("@macongty", macongty);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_REPORT_ReportHeader;1";


            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.StoredProcedure;

            command2.CommandText = "spd_LaymasothueCongty";
            command2.Parameters.AddWithValue("@Macongty", macongty);
            command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            table2.TableName = "spd_LaymasothueCongty;1";


            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_reportThue01_2GTGT";
            command1.Parameters.AddWithValue("@maky", (int)cbo_Ky.Value);
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_reportThue01_2GTGT;1";


            dataset.Tables.Add(table);
            dataset.Tables.Add(table1);
            dataset.Tables.Add(table2);
            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
        private void In_BangkeMuavao(int macongty)
        {
            Tao_bangkeMuavao();
            Ky _ky = Ky.GetKy((int)cbo_Ky.Value);
            frmXemIn f = new frmXemIn();
            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            rpt.ReportEmbeddedResource = "PSC_ERP.Report.Thue.Report_Thue01_2GTGT.rdlc";
            rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_ReportThue01_2GTGTList", ERP_Library.ReportThue01_2GTGTList.GetReportThue01_2GTGTList((int)cbo_Ky.Value)));
            rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_HeaderList", ERP_Library.Report_HeaderList.GetReport_HeaderList(macongty)));

            f.SetParameter("p_ky", "Kỳ tính thuế: Tháng " + _ky.NgayBatDau.Month.ToString() + " năm " + _ky.NgayBatDau.Year.ToString());

            f.Show(this);
            return;
        }
        private void Tao_bangkebanra()
        {
            int sorecord = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[spd_taodulieu_01_1GTGT]";
                    cm.Parameters.AddWithValue("@Maky", (int)cbo_Ky.Value);
                    cm.Parameters.AddWithValue("@Ngay", Convert.ToDateTime(dtmp_Ngay.Value).Date);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    sorecord = (int)cm.ExecuteNonQuery();
                }
            }
            //if (sorecord != 0)
            //    MessageBox.Show(this, "Dữ liệu đã được tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else
            //    MessageBox.Show(this, "Dữ liệu đầu vào không đủ để thực hiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void In_Bangkebanra_rpt(int macongty)
        {
            Tao_bangkebanra();
            ReportDocument Report = new Report.Thue.Thue01_1GTGT();
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "spd_REPORT_ReportHeader";
            command.Parameters.AddWithValue("@macongty", macongty);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_REPORT_ReportHeader;1";


            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.StoredProcedure;

            command2.CommandText = "spd_LaymasothueCongty";
            command2.Parameters.AddWithValue("@Macongty", macongty);
            command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            table2.TableName = "spd_LaymasothueCongty;1";


            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_reportThue01_1GTGT";
            command1.Parameters.AddWithValue("@maky", (int)cbo_Ky.Value);
            //command1.Parameters.AddWithValue("@Ngaytao", Convert.ToDateTime(dtmp_Ngay.Value).Date);
            //command1.Parameters.AddWithValue("@Manhanvien", ERP_Library.Security.CurrentUser.Info.UserID);
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_reportThue01_1GTGT;1";


            dataset.Tables.Add(table);
            dataset.Tables.Add(table1);
            dataset.Tables.Add(table2);
            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
        private void In_Bangkebanra(int macongty)
        {
            Tao_bangkebanra();
            Ky _ky = Ky.GetKy((int)cbo_Ky.Value);
            frmXemIn f = new frmXemIn();
            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            rpt.ReportEmbeddedResource = "PSC_ERP.Report.Thue.Report_Thue01_1GTGT.rdlc";
            rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_ReportThue01_2GTGTList", ERP_Library.ReportThue01_2GTGTList.GetReportThue01_1GTGTList((int)cbo_Ky.Value)));
            rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_HeaderList", ERP_Library.Report_HeaderList.GetReport_HeaderList(macongty)));

            f.SetParameter("p_ky", "Kỳ tính thuế: Tháng " + _ky.NgayBatDau.Month.ToString() + " năm " + _ky.NgayBatDau.Year.ToString());

            f.Show(this);
            return;
        }

        private void Tao_GTbangphanbo()
        {
            int sorecord = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[spd_taodulieu01_4GTGT]";
                    cm.Parameters.AddWithValue("@Maky", (int)cbo_Ky.Value);
                    cm.Parameters.AddWithValue("@Ngay", Convert.ToDateTime(dtmp_Ngay.Value).Date);
                    cm.Parameters.AddWithValue("@Manhanvien", ERP_Library.Security.CurrentUser.Info.UserID);
                    sorecord = (int)cm.ExecuteNonQuery();
                }
            }
            if (sorecord != 0)
                MessageBox.Show(this, "Dữ liệu đã được tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(this, "Dữ liệu đầu vào không đủ để thực hiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void Tao_GTTokhai()
        {
            int sorecord = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[spd_taodulieu_01GTGT]";
                    cm.Parameters.AddWithValue("@Maky", (int)cbo_Ky.Value);
                    cm.Parameters.AddWithValue("@Ngay", Convert.ToDateTime(dtmp_Ngay.Value).Date);
                    cm.Parameters.AddWithValue("@Manhanvien", ERP_Library.Security.CurrentUser.Info.UserID);
                    sorecord = (int)cm.ExecuteNonQuery();
                }
            }
            if (sorecord != 0)
                MessageBox.Show(this, "Dữ liệu đã được tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(this, "Dữ liệu đầu vào không đủ để thực hiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Tong Hop

        private void In_Chitiet342HP(int macongty)
        {
            Tao_bangkeMuavao();
            ReportDocument Report = new Report.Thue.ChiTiet_SoDuTK342HP();
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "spd_REPORT_ReportHeader";
            command.Parameters.AddWithValue("@macongty", macongty);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_REPORT_ReportHeader;1";

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_Report_Chitietsodutaikhoan342";
            command1.Parameters.AddWithValue("@Denngay", Convert.ToDateTime(dtmp_Ngay.Value).Date);
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_Report_Chitietsodutaikhoan342;1";


            dataset.Tables.Add(table);
            dataset.Tables.Add(table1);
            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void In_Chitiet342CAP(int macongty)
        {
            Tao_bangkeMuavao();
            ReportDocument Report = new Report.Thue.ChiTiet_SoDuTK342CAP();
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "spd_REPORT_ReportHeader";
            command.Parameters.AddWithValue("@macongty", macongty);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_REPORT_ReportHeader;1";

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_Report_Chitietsodutaikhoan342";
            command1.Parameters.AddWithValue("@Denngay", Convert.ToDateTime(dtmp_Ngay.Value).Date);
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_Report_Chitietsodutaikhoan342;1";


            dataset.Tables.Add(table);
            dataset.Tables.Add(table1);
            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void In_Chitiet3337(int macongty)
        {
            Tao_bangkeMuavao();
            ReportDocument Report = new Report.Thue.ChiTiet_SoDuTK3337();
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "spd_REPORT_ReportHeader";
            command.Parameters.AddWithValue("@macongty", macongty);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_REPORT_ReportHeader;1";

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_Report_Chitietsodutaikhoan3337";
            command1.Parameters.AddWithValue("@Denngay", Convert.ToDateTime(dtmp_Ngay.Value).Date);
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_Report_Chitietsodutaikhoan3337;1";


            dataset.Tables.Add(table);
            dataset.Tables.Add(table1);
            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        #endregion

        private void In_ToKhaiThueTNCNLuyTien()
        {
            ReportTemplate _reportTemplate;
            int UserId = ERP_Library.Security.CurrentUser.Info.UserID;

            ReportTemplate _report = ReportTemplate.GetReportTemplate("ToKhaiQuyetToanThueTNCN");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                if (!KiemTra(_report.Id))
                {
                    XtraMessageBox.Show("Báo cáo chưa tồn tại vui lòng tạo báo cáo trước khi xem !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //B
                _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }
                bool daChonParameter = false;
                if (_report.TenPhuongThuc != "")
                {
                    daChonParameter = (bool)this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }
                if (daChonParameter)
                {
                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
                //E
            }
        }

        private void In_BaoCaoChiTietThueTNCN()
        {
            ReportDocument Report = new ReportDocument();
            DataSet dataSet = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command.CommandTimeout = 0;

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command1.CommandTimeout = 0;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();

            frmHienThiReport dlg = new frmHienThiReport();

            Report = new Report.NhanSu.rpt_BaoCaoChiTietTNCN_TheoThang();
            command.CommandText = "spd_Report_ChiTietThueTNCN_TheoThang";
            command.Parameters.AddWithValue("@MaKyTinhLuong", Convert.ToInt32(cmb_TuKy.EditValue));
            command.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            table.TableName = "spd_Report_ChiTietThueTNCN_TheoThang;1";

            command1.CommandText = "spd_LayNguoiKyTenCongNo";
            command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            adapter.SelectCommand = command1;
            adapter.Fill(table1);
            table1.TableName = "spd_LayNguoiKyTenCongNo;1";

            dataSet.Tables.Add(table);
            dataSet.Tables.Add(table1);

            Report.SetDataSource(dataSet);
            Report.SetParameterValue("ngay", KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmb_TuKy.EditValue)).NgayBatDau);
            Report.SetParameterValue("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);

            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void In_BaoCaoTongHopThueTNCN()
        {
            ReportDocument Report = new ReportDocument();
            DataSet dataSet = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command.CommandTimeout = 0;

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command1.CommandTimeout = 0;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();

            frmHienThiReport dlg = new frmHienThiReport();

            Report = new Report.NhanSu.rpt_BaoCaoTongHopTNCN_TheoThang();
            command.CommandText = "spd_Report_ChiTietThueTNCN_TheoThang";
            command.Parameters.AddWithValue("@MaKyTinhLuong", Convert.ToInt32(cmb_TuKy.EditValue));
            command.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            table.TableName = "spd_Report_ChiTietThueTNCN_TheoThang;1";

            command1.CommandText = "spd_LayNguoiKyTenCongNo";
            command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            adapter.SelectCommand = command1;
            adapter.Fill(table1);
            table1.TableName = "spd_LayNguoiKyTenCongNo;1";

            dataSet.Tables.Add(table);
            dataSet.Tables.Add(table1);

            Report.SetDataSource(dataSet);
            Report.SetParameterValue("ngay", KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmb_TuKy.EditValue)).NgayBatDau);
            Report.SetParameterValue("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);

            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void In_ToKhaiThueNhaThauNuocNgoai()
        {
            ReportDocument Report = new ReportDocument();
            DataSet dataSet = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command.CommandTimeout = 0;

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command1.CommandTimeout = 0;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();

            frmHienThiReport dlg = new frmHienThiReport();

            Report = new Report.Thue.ToKhaiThueNhaThauNuocNgoai_01_NTNN();
            command.CommandText = "spd_ToKhaiThueNhaThauNuocNgoai";
            command.Parameters.AddWithValue("@MaKy", Convert.ToInt32(cbo_Ky.Value));
            command.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
            command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            //command.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            table.TableName = "spd_ToKhaiThueNhaThauNuocNgoai;1";

            command1.CommandText = "spd_ReportHeaderAndFooter";
            command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            adapter.SelectCommand = command1;
            adapter.Fill(table1);
            table1.TableName = "spd_ReportHeaderAndFooter;1";

            dataSet.Tables.Add(table);
            dataSet.Tables.Add(table1);

            Report.SetDataSource(dataSet);
            //Report.SetParameterValue("ngay", KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmb_TuKy.EditValue)).NgayBatDau);
            //Report.SetParameterValue("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);

            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        public bool ToKhaiThueTNCN()
        {
            if (cmb_TuKy.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Từ Kỳ để xem báo cáo");
                cmb_TuKy.Focus();
                return false;
            }

            if (cmb_DenKy.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Đến Kỳ để xem báo cáo");
                cmb_DenKy.Focus();
                return false;
            }

            int iTuKy = Convert.ToInt32(cmb_TuKy.EditValue);
            int iDenKy = Convert.ToInt32(cmb_DenKy.EditValue);
            DateTime dtTuNgay = KyTinhLuong.GetKyTinhLuong(iTuKy).NgayBatDau;
            DateTime dtDenNgay = KyTinhLuong.GetKyTinhLuong(iDenKy).NgayKetThuc;
            int MaBoPhan = Convert.ToInt32(cmb_BoPhan.EditValue);
            int MaNhanVien = Convert.ToInt32(cmb_NhanVien.EditValue);

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ToKhaiQuyetToanThueTNCN";
                    cm.Parameters.AddWithValue("@TuKy", iTuKy);
                    cm.Parameters.AddWithValue("@DenKy", iDenKy);
                    cm.Parameters.AddWithValue("@BoPhan", MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ToKhaiQuyetToanThueTNCN";
                    dataSet.Tables.Add(dt);
                }

                //tao bang_REPORT_ReportHeader 
                DataTable dtNgay = new DataTable();
                dtNgay.TableName = "TuNgay_DenNgay";
                dtNgay.Columns.Add("TuNgay", typeof(DateTime));
                dtNgay.Columns.Add("DenNgay", typeof(DateTime));
                dtNgay.Rows.Add(dtTuNgay, dtDenNgay);
                dataSet.Tables.Add(dtNgay);

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us 

            return true;
        }

        private bool KiemTra(string name)
        {
            bool bFound = false;
            ReportTemplate obj = ReportTemplate.GetReportTemplate(name);
            if (obj.Data != null)
                bFound = true;
            return bFound;
        }

        private void AnTatCaControlItem()
        {
            foreach (LayoutControlItem item in this.layoutControlGroup1.Items)
            {
                item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void ShowControlItem(LayoutControlItem item)
        {
            item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void LoadDateTime()
        {
            if (ultraTree_BaoCaoThue.ActiveNode.Key == "ToKhaiThueTNCNLuyTien")
            {
                if (cmb_TuKy.EditValue != null)
                {
                    KyTinhLuong TuKy = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmb_TuKy.EditValue));
                    _dtTuNgay = TuKy.NgayBatDau;
                }

                if (cmb_DenKy.EditValue != null)
                {
                    KyTinhLuong DenKy = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmb_DenKy.EditValue));
                    _dtDenNgay = DenKy.NgayKetThuc;
                }
            }
            else if (ultraTree_BaoCaoThue.ActiveNode.Key == "ChiTietThueTNCN" || ultraTree_BaoCaoThue.ActiveNode.Key == "TongHopThueTNCN")
            {
                if (cmb_TuKy.EditValue != null)
                {
                    KyTinhLuong TuKy = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmb_TuKy.EditValue));
                    _dtTuNgay = TuKy.NgayBatDau;
                    _dtDenNgay = TuKy.NgayKetThuc;
                }
            }
            else
            {
                if (cbo_Ky.ActiveRow != null)
                {
                    Ky ky = Ky.GetKy(Convert.ToInt32(cbo_Ky.Value));
                    _dtTuNgay = ky.NgayBatDau;
                    _dtDenNgay = ky.NgayKetThuc;
                }
            }

            dtp_TuNgay.Value = _dtTuNgay;
            dtp_DenNgay.Value = _dtDenNgay;
        }

        #region BangKeHoaDonMuaVao
        private void InBangKeHoaDonMuaVao()
        {

            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_Report_ThueBangKeHoaDonMuaVao");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.Show();
            }
            //END
        }
        public void Method_Report_ThueBangKeHoaDonMuaVao()
        {
            Tao_bangkeMuavao();
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_reportThue01_2GTGT_BangKeHoaDonMuaVao";
                    cm.Parameters.AddWithValue("@MaKy", (int)cbo_Ky.Value);
                    cm.Parameters.AddWithValue("@UserID",ERP_Library.Security.CurrentUser.Info.UserID);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                Ky _ky = Ky.GetKy((int)cbo_Ky.Value);
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("NgaBatDau", typeof(DateTime));
                dtParameters.Columns.Add("NgayKetThuc", typeof(DateTime));
                dtParameters.Columns.Add("TieuDe", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["NgaBatDau"] = _ky.NgayBatDau;
                dr["NgayKetThuc"] = _ky.NgayKetThuc;
                dr["TieuDe"] = "Kỳ tính thuế: Tháng " + _ky.NgayBatDau.Month.ToString() + " năm " + _ky.NgayBatDau.Year.ToString();
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us  
        }
        #endregion//BangKeHoaDonMuaVao

        #endregion

        #region Events
        private void btnu_XemBC_Click(object sender, EventArgs e)
        {
            if (cbo_Ky.ActiveRow == null && ultraTree_BaoCaoThue.ActiveNode.Key != "ToKhaiThueTNCNLuyTien" && (ultraTree_BaoCaoThue.ActiveNode.Key != "TongHopThueTNCN" && ultraTree_BaoCaoThue.ActiveNode.Key != "ChiTietThueTNCN"))
            {
                cbo_Ky.Appearance.BackColor = Color.PeachPuff;
                MessageBox.Show(this, "Vui lòng chọn kỳ tính thuế !", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else if (cmb_TuKy.EditValue == null && (ultraTree_BaoCaoThue.ActiveNode.Key == "TongHopThueTNCN" || ultraTree_BaoCaoThue.ActiveNode.Key == "ChiTietThueTNCN"))
            {
                MessageBox.Show(this, "Vui lòng chọn kỳ tính thuế !", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                cbo_Ky.Appearance.BackColor = Color.White;
                Ky ky = Ky.GetKy(Convert.ToInt32(cbo_Ky.Value));

                #region Thue GTGT
                if (ultraTree_BaoCaoThue.ActiveNode.Key == "nodebanra01_1")
                {
                    //In_Bangkebanra(macongty);
                    //In_Bangkebanra_rpt(macongty);
                    InBangKeHoaDonBanRa();
                }
                else if (ultraTree_BaoCaoThue.ActiveNode.Key == "nodebanra01_2")
                {
                    //In_BangkeMuavao(macongty);
                    InBangKeHoaDonMuaVao();
                }
                else if (ultraTree_BaoCaoThue.ActiveNode.Key == "nodetokhai01")
                {
                    FrmThue_01GTGT frm = new FrmThue_01GTGT((int)cbo_Ky.Value);
                    frm.ShowDialog();
                }
                else if (ultraTree_BaoCaoThue.ActiveNode.Key == "nodebangphanbo")
                {
                    FrmBangPhanBoGTGT frm = new FrmBangPhanBoGTGT((int)cbo_Ky.Value);
                    frm.ShowDialog();
                }
                else if (ultraTree_BaoCaoThue.ActiveNode.Key == "bangdauradauvao")
                {
                    In_BangkeMuavao(macongty);
                }
                else if (ultraTree_BaoCaoThue.ActiveNode.Key == "ToKhaiThueNhaThauNuocNgoai")
                {
                    In_ToKhaiThueNhaThauNuocNgoai();
                }
                #endregion

                #region Tong Hop
                else if (ultraTree_BaoCaoThue.ActiveNode.Key == "chitietsodutaikhoan342hp")
                {
                    In_Chitiet342HP(macongty);
                }
                else if (ultraTree_BaoCaoThue.ActiveNode.Key == "chitietsodutaikhoan342CAP")
                {
                    In_Chitiet342CAP(macongty);
                }
                else if (ultraTree_BaoCaoThue.ActiveNode.Key == "chitietsodutaikhoan3337")
                {
                    In_Chitiet3337(macongty);
                }
                #endregion

                #region Hoa Don
                else if (ultraTree_BaoCaoThue.ActiveNode.Key == "baocaotinhinhsudunghoadon")
                {
                    In_Chitiet3337(macongty);
                }
                #endregion

                #region Thuế TNCN
                else if (ultraTree_BaoCaoThue.ActiveNode.Key == "ToKhaiThueTNCNLuyTien")
                {
                    In_ToKhaiThueTNCNLuyTien();
                }
                else if (ultraTree_BaoCaoThue.ActiveNode.Key == "ChiTietThueTNCN")
                {
                    In_BaoCaoChiTietThueTNCN();
                }
                else if (ultraTree_BaoCaoThue.ActiveNode.Key == "TongHopThueTNCN")
                {
                    In_BaoCaoTongHopThueTNCN();
                }
                #endregion
            }
        }

        private void btnu_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbo_Ky_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //cbo_Ky.DisplayLayout.Bands[0].Columns["Tenky"].Header.Caption = "Kỳ";
            //cbo_Ky.DisplayLayout.Bands[0].Columns["Maky"].Hidden = true;
            //cbo_Ky.DisplayLayout.Bands[0].Columns["KhoaSo"].Hidden = true;
            //cbo_Ky.DisplayLayout.Bands[0].Columns["Ngaybatdau"].Header.Caption = "Bắt đầu";
            //cbo_Ky.DisplayLayout.Bands[0].Columns["Ngayketthuc"].Header.Caption = "Kết thúc";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHoaDonDichVuMuaVao hoaDon = new frmHoaDonDichVuMuaVao(4);
            hoaDon.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmHoaDonDichVuBanRa hoaDon = new frmHoaDonDichVuBanRa(5);
            hoaDon.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCapHoaDon hoaDon = new frmCapHoaDon();
            hoaDon.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmImportDuLieuThueMuaBan hoaDon = new frmImportDuLieuThueMuaBan();
            hoaDon.Show();
        }

        private void tlscaphoadon_Click(object sender, EventArgs e)
        {
            frmCapHoaDon hoaDon = new frmCapHoaDon();
            hoaDon.Show();
        }

        private void tlsmuavao_Click(object sender, EventArgs e)
        {
            frmHoaDonDichVuMuaVao hoaDon = new frmHoaDonDichVuMuaVao(4);
            hoaDon.Show();
        }

        private void tlsbanra_Click(object sender, EventArgs e)
        {
            frmHoaDonDichVuBanRa hoaDon = new frmHoaDonDichVuBanRa(5);
            hoaDon.Show();
        }

        private void tlsimport_Click(object sender, EventArgs e)
        {
            frmImportDuLieuThueMuaBan hoaDon = new frmImportDuLieuThueMuaBan();
            hoaDon.Show();
        }

        private void tlsthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlsdshoadon_Click(object sender, EventArgs e)
        {
            frmDSHoaDonDichVu danhSachHoaDon = new frmDSHoaDonDichVu();
            danhSachHoaDon.Show();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultraTree_BaoCaoThue_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            AnTatCaControlItem();

            //Ẩn hiện button xem lưới
            
            if (ultraTree_BaoCaoThue.ActiveNode.Key == "nodebanra01_2")
            {
                ShowControlItem(Item_XuatExel);
                ShowControlItem(Item_XemLuoi);
            }
            
            if (ultraTree_BaoCaoThue.ActiveNode.Key == "ToKhaiThueTNCNLuyTien")
            {
                ShowControlItem(Item_TuKy);
                ShowControlItem(Item_DenKy);
                ShowControlItem(Item_NhanVien);
                ShowControlItem(Item_BoPhan);
                Item_TuKy.Text = "Từ kỳ lương:";
            }
            else if (ultraTree_BaoCaoThue.ActiveNode.Key == "ChiTietThueTNCN" || ultraTree_BaoCaoThue.ActiveNode.Key == "TongHopThueTNCN")
            {
                ShowControlItem(Item_TuKy);
                Item_TuKy.Text = "Kỳ tính lương:";
                //ShowControlItem(Item_NhanVien);
                //ShowControlItem(Item_BoPhan);
            }
            else
            {
                ShowControlItem(Item_KyLuong);
                ShowControlItem(Item_NgayLap);
            }
            if (ultraTree_BaoCaoThue.ActiveNode.Key == "ToKhaiThueNhaThauNuocNgoai") //Thang
            {
                ShowControlItem(Item_XuatExel);
                ShowControlItem(Item_XemLuoi);
            }

            ShowControlItem(Item_XemBaoCao);
            ShowControlItem(Item_Thoat);
            ShowControlItem(Item_dtTuNgay);
            ShowControlItem(Item_dtDenNgay);
        }

        private void btn_XemLuoi_Click(object sender, EventArgs e)
        {
            if (ultraTree_BaoCaoThue.ActiveNode.Key == "ToKhaiThueNhaThauNuocNgoai")
            {
                if (cbo_Ky.ActiveRow != null)
                {
                    frmHienThiLuoi_ThueNTNN frm = new frmHienThiLuoi_ThueNTNN((int)cbo_Ky.Value);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(this, "Vui lòng chọn kỳ!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (cbo_Ky.ActiveRow != null)
                {
                    frmHienThiLuoi_ThueGTGTMuaVao frm = new frmHienThiLuoi_ThueGTGTMuaVao((int)cbo_Ky.Value);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(this, "Vui lòng chọn kỳ tính lương !", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void cbo_Ky_ValueChanged(object sender, EventArgs e)
        {
            if (cbo_Ky.ActiveRow != null)
            {
                _maKy = (int)cbo_Ky.Value;
                LoadDateTime();
            }
        }

        private void dtmp_Ngay_ValueChanged(object sender, EventArgs e)
        {
            _dtNgay = Convert.ToDateTime(dtmp_Ngay.Value).Date;
        }

        private void btn_XuatExcel_Click(object sender, EventArgs e)
        {
            if (cbo_Ky.Value == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ tính", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Excel|*.xls|All file|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {              
                if (ultraTree_BaoCaoThue.ActiveNode.Key == "ToKhaiThueNhaThauNuocNgoai")
                {
                    //tạo file template
                    //FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    //fs.Write(Properties.Resources._01_GTGT_2012, 0, Properties.Resources._01_GTGT_2012,.Length);
                    //fs.Close();
                    //tạo dữ liệu tạm vào table để xử lý
                    System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                    cm.Connection = new System.Data.SqlClient.SqlConnection(ERP_Library.Database.ERP_Connection);
                    cm.CommandText = "spd_ToKhaiThueNhaThauNuocNgoai";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@maky", (int)cbo_Ky.Value);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
                    da.SelectCommand = cm;
                    DataTable tbl = new DataTable("Export");
                    da.Fill(tbl);

                    ////tạo file template
                    //FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    //fs.Write(Properties.Resources._01_GTGT_2012, 0, Properties.Resources._01_GTGT_2012.Length);
                    //fs.Close();
                    ////tạo dữ liệu tạm vào table để xử lý
                    //System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                    //cm.Connection = new System.Data.SqlClient.SqlConnection(ERP_Library.Database.ERP_Connection);
                    //cm.CommandText = "spd_reportThue01_2GTGT";
                    //cm.CommandType = CommandType.StoredProcedure;
                    //cm.Parameters.AddWithValue("@maky", (int)cbo_Ky.Value);
                    //System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
                    //da.SelectCommand = cm;
                    //DataTable tbl = new DataTable("Export");
                    //da.Fill(tbl);

                    //ghi dữ liệu vào file
                    //string cnnExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dlg.FileName + ";Extended Properties='Excel 8.0; HDR=NO'";
                    //OleDbDataAdapter daExcel = new OleDbDataAdapter("Select * From [Sheet1$B2:L]", cnnExcel);
                    //DataTable tblExcel = new DataTable("Export");
                    //daExcel.Fill(tblExcel);
                    //daExcel.InsertCommand = new OleDbCommand("Insert Into [Sheet1$B2:L] (F1,F2,F3,F4,F5,F6,F7,F8,F9,F10,F11) Values (?,?,?,?,?,?,?,?,?,?,?)", daExcel.SelectCommand.Connection);
                    //daExcel.InsertCommand.Parameters.Add("p1", OleDbType.Integer, 50, "F1");
                    //daExcel.InsertCommand.Parameters.Add("p2", OleDbType.WChar, 50, "F2");
                    //daExcel.InsertCommand.Parameters.Add("p3", OleDbType.WChar, 50, "F3");
                    //daExcel.InsertCommand.Parameters.Add("p4", OleDbType.Date, 200, "F4");
                    //daExcel.InsertCommand.Parameters.Add("p5", OleDbType.WChar, 250, "F5"); 
                    //daExcel.InsertCommand.Parameters.Add("p6", OleDbType.WChar, 200, "F6");
                    //daExcel.InsertCommand.Parameters.Add("p7", OleDbType.WChar, 200, "F7");
                    //daExcel.InsertCommand.Parameters.Add("p8", OleDbType.Decimal, 18, "F8");
                    //daExcel.InsertCommand.Parameters.Add("p9", OleDbType.Double, 18, "F9");
                    //daExcel.InsertCommand.Parameters.Add("p10", OleDbType.Decimal, 18, "F10");
                    //daExcel.InsertCommand.Parameters.Add("p11", OleDbType.WChar, 200, "F11");

                    //int i = 0;
                    //foreach (DataRow r in tbl.Rows)
                    //{
                    //    tblExcel.Rows.Add(++i, r["SoSerial"], r["SoHoaDon"], r["NgayLapHD"], r["TenDoiTac"], r["MaSoThue"], r["MatHang"], r["SoTien"], r["ThueSuat"], r["TienThue"], r["GhiChu"]);
                    //}
                    //daExcel.Update(tblExcel);

                    //clsExcelRpt cls = new clsExcelRpt();
                    //cls.Open(dlg.FileName);
                    //bool b = cls.ExportDataTable2Excel(tbl, 1, 18, 2, false);
                }
                else
                {
                    
                }

                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(dlg.FileName);
            }
        }

        private void lookUpEdit_BoPhan_EditValueChanged(object sender, EventArgs e)
        {
            if (cmb_BoPhan.EditValue != null)
            {
                NhanVienList _nhanVienList = NhanVienList.GetNhanVienList((int)cmb_BoPhan.EditValue);
                _nhanVienList.Insert(0, NhanVien.NewNhanVien(0, "Tất cả"));
                nhanVienListBindingSource.DataSource = _nhanVienList;
            }
        }

        private void cmb_TuKy_EditValueChanged(object sender, EventArgs e)
        {
            if (cmb_TuKy.EditValue != null)
            {
                LoadDateTime();
            }
        }

        private void cmb_DenKy_EditValueChanged(object sender, EventArgs e)
        {
            if (cmb_TuKy.EditValue != null)
            {
                LoadDateTime();
            }
        }
        #endregion

        #region BangKeHoaDonBanRa dev
        private void InBangKeHoaDonBanRa()
        {
            Tao_bangkebanra();
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_Report_ThueBangKeHoaDonBanRa");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.Show();
            }
            //END
        }
        public void Method_Report_ThueBangKeHoaDonBanRa()
        {
            Tao_bangkeMuavao();
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_reportThue01_1GTGT";
                    cm.Parameters.AddWithValue("@MaKy", (int)cbo_Ky.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                Ky _ky = Ky.GetKy((int)cbo_Ky.Value);
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("NgaBatDau", typeof(DateTime));
                dtParameters.Columns.Add("NgayKetThuc", typeof(DateTime));
                dtParameters.Columns.Add("TieuDe", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["NgaBatDau"] = _ky.NgayBatDau;
                dr["NgayKetThuc"] = _ky.NgayKetThuc;
                dr["TieuDe"] = "Kỳ tính thuế: Tháng " + _ky.NgayBatDau.Month.ToString() + " năm " + _ky.NgayBatDau.Year.ToString();
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us  
        }
        #endregion//BangKeHoaDonMuaVao

    }
}