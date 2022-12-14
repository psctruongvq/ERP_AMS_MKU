using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmBaoCaoChuyenKhoan : Form
    {
        FilterCombo fileternganHang;
        int userID = CurrentUser.Info.UserID;
        public frmBaoCaoChuyenKhoan()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBaoCaoChuyenKhoan_Load(object sender, EventArgs e)
        {
            txtTuNgay.DateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            txtDenNgay.DateTime = DateTime.Today;
          //  ultraCombo_NganHang.DataSource = ERP_Library.NganHangList.GetNganHangList();
            ultraCombo_NganHang.DataSource = NganHangList.GetNganHangListByCongTy();
            ultraCombo_NganHang.ValueMember = "MaNganHang";
            ultraCombo_NganHang.DisplayMember = "TenNganHang";
            cmbBoPhan.DataSource = BoPhanList.GetBoPhanListAll(userID);
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            HamDungChung.VisibleColumn(ultraCombo_NganHang.DisplayLayout.Bands[0], "TenNganHang", "TenVietTat");
            cmbBoPhan.Value = 0;

            treeReport.ExpandAll();
            cmbKyTen.Value = 0;
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            fileternganHang = new FilterCombo(ultraCombo_NganHang, "TenNganHang");
            
        }

        private void treeReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblBoPhan.Visible = false;
            cmbBoPhan.Visible = false;
            lblNganHang.Visible = false;
            ultraCombo_NganHang.Visible = false;
            lblNhanVien.Visible = false;
            cmbNhanVien.Visible = false;

            if (e.Node.Nodes.Count == 0)
            {
                string s = "";
                int yl = 60, yc = 51, c = 0;
                if (e.Node.Tag is string) s = (string)e.Node.Tag;

                if (s.Contains("NganHang"))
                {
                    lblNganHang.Top = yl + 28 * c;
                    ultraCombo_NganHang.Top = yc + 28 * c;
                    lblNganHang.Visible = true;
                    ultraCombo_NganHang.Visible = true;
                    c++;
                }

                if (s.Contains("BoPhan"))
                {
                    lblBoPhan.Top = yl + 28 * c;
                    cmbBoPhan.Top = yc + 28 * c;
                    lblBoPhan.Visible = true;
                    cmbBoPhan.Visible = true;
                    c++;
                }

                if (s.Contains("NhanVien"))
                {
                    lblNhanVien.Top = yl + 28 * c;
                    cmbNhanVien.Top = yc + 28 * c;
                    lblNhanVien.Visible = true;
                    cmbNhanVien.Visible = true;
                    c++;
                }

                btnReport.Enabled = true;
            }
            else
            {
                btnReport.Enabled = false;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (treeReport.SelectedNode == null) return;
            if (ultraCombo_NganHang.Visible && ultraCombo_NganHang.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn ngân hàng", "Ngân hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (cmbBoPhan.Visible && (cmbBoPhan.Value == null || (int)cmbBoPhan.Value == 0))
            //{
            //    MessageBox.Show("Bạn chưa chọn bộ phận", "Ngân hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //báo cáo
            frmXemIn f = new frmXemIn();
            string sNganHang, PhanLoai;
            sNganHang = ultraCombo_NganHang.Text;
            PhanLoai = "";
            if (ultraCombo_NganHang.Visible)
            {
                PhanLoai = "Ngân hàng : " + sNganHang;
            }
            if (cmbBoPhan.Visible && cmbBoPhan.Value is int && (int)cmbBoPhan.Value != 0)
            {
                if (PhanLoai == "")
                    PhanLoai = "Bộ phận : " + cmbBoPhan.Text;
                else
                    PhanLoai += "\r\nBộ phận : " + cmbBoPhan.Text;
            }
            long MaNhanVien = 0;
            if (cmbNhanVien.Value is long)
                MaNhanVien = (long)cmbNhanVien.Value;

            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;

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

            switch (treeReport.SelectedNode.Name)
            {
                case "tonghopbophan":
                    //rpt.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptTongHopChuyenKhoanBoPhan.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptTongHopChuyenKhoanBoPhan.rdlc";
                    f.SetDatabase("ERP_Library_Report_TongHopChuyenKhoanBoPhanList", ERP_Library.Report.TongHopChuyenKhoanBoPhanList.GetTongHopChuyenKhoanBoPhanList(txtTuNgay.DateTime, txtDenNgay.DateTime, (int)ultraCombo_NganHang.Value));
                    break;
                case "chitietbophan":
                    //rpt.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptChiTietChuyenKhoanBoPhan.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoanBoPhan.rdlc";
                    f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanBoPhanList", ERP_Library.Report.ChiTietChuyenKhoanBoPhanList.GetChiTietChuyenKhoanBoPhanList(txtTuNgay.DateTime, txtDenNgay.DateTime, (int)ultraCombo_NganHang.Value, (int)cmbBoPhan.Value));
                    break;
                case "chitietnhanvienbophan":
                    //rpt.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptChiTietChuyenKhoanNhanVienBoPhan.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoanNhanVienBoPhan.rdlc";
                    f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanNhanVienBoPhanList", ERP_Library.Report.ChiTietChuyenKhoanNhanVienBoPhanList.GetChiTietChuyenKhoanNhanVienBoPhanList(txtTuNgay.DateTime, txtDenNgay.DateTime, (int)ultraCombo_NganHang.Value, (int)cmbBoPhan.Value, MaNhanVien));
                    f.SetParameter("TieuDe", "CHI TIẾT CHUYỂN KHOẢN NHÂN VIÊN");
                    break;
                case "tonghopnhanvien":
                    //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptChiTietChuyenKhoanNhanVienBoPhan.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoanNhanVienBoPhan.rdlc";
                    f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanNhanVienBoPhanList", ERP_Library.Report.ChiTietChuyenKhoanNhanVienBoPhanList.GetTongHopChuyenKhoanNhanvien(txtTuNgay.DateTime, txtDenNgay.DateTime, (int)ultraCombo_NganHang.Value, (int)cmbBoPhan.Value, MaNhanVien));
                    f.SetParameter("TieuDe", "TỔNG HỢP CHUYỂN KHOẢN NHÂN VIÊN");
                    break;
                case "DSNhanVienKhongHopLe":
                    //rpt.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptChiTietChuyenKhoanNhanVienBoPhan.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoanNhanVienKhongHopLe.rdlc";
                    f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanBoPhanList", ERP_Library.Report.ChiTietChuyenKhoanBoPhanList.GetChiTietChuyenByNhanVienKhongHopLe((int)cmbKyLuong.Value));
                    f.SetParameter("TieuDe", "Nhân Viên Chuyển Khoản Không Hợp Lệ");
                    f.SetParameter("BoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);

                    break;
                case "DanhSachTongHopThueTNCN":
                    //rpt.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptChiTietChuyenKhoanNhanVienBoPhan.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangChiTietTamThuThueTNCN_TongHop.rdlc";
                    f.SetDatabase("ThueTNCNList", ERP_Library.ThueTNCNLuyTienList.GetThueTNCNLuyTienList(Convert.ToDateTime(txtDenNgay.Value), (int)cmbBoPhan.Value));
                    f.SetParameter("TieuDe", "BẢNG TỔNG HỢP THUẾ THU NHẬP CÁ NHÂN");
                    f.SetParameter("DenNgay", ((DateTime)txtDenNgay.Value).ToString("dd/MM/yyyy"));
                    f.SetParameter("TenCongTy", ERP_Library.CongTy.GetCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).TenCongTy);
                    break;
                case "NodeTongHopThueTNCNTheoThang":
                    f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptTongHopChuyenKhoanTruThueTheoUNC.rdlc";
                        f.SetDatabase("ChiTietChuyenKhoanList", ERP_Library.Report.ChiTietChuyenKhoanList.GetTongHopChuyenKhoanByKyTinhLuong(Thang, Nam));
                        f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "VeViec","Tháng "+Thang+" Năm "+Nam);
                        int NguoiKy = (int)cmbKyTen.Value;
                        f.SetNguoiKy_DeNghiCK(NguoiKy);
                        f.ShowDialog();
                        return;
                    ////rpt.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptChiTietChuyenKhoanNhanVienBoPhan.rdlc";
                    //rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDanhSachThueTNCN_TongHop.rdlc";
                    //f.SetDatabase("ThueTNCNList", ERP_Library.ThueTNCNLuyTienList.GetThueTNCNLuyTienList(Convert.ToDateTime(txtDenNgay.Value), (int)cmbBoPhan.Value));
                    //f.SetParameter("TieuDe", "BẢNG TỔNG HỢP THUẾ THU NHẬP CÁ NHÂN");
                    //f.SetParameter("DenNgay", ((DateTime)txtDenNgay.Value).ToString("dd/MM/yyyy"));
                    //f.SetParameter("TenCongTy", ERP_Library.CongTy.GetCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).TenCongTy);
                    //break;
                case "ChiTietTNCN_TheoThang":
                    Report = new Report.NhanSu.rpt_BaoCaoChiTietTNCN_TheoThang();
                    command.CommandText = "spd_Report_ChiTietThueTNCN_TheoThang";
                    command.Parameters.AddWithValue("@MaKyTinhLuong", Convert.ToInt32(cmbKyLuong.Value));
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
                    Report.SetParameterValue("ngay", KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbKyLuong.Value)).NgayBatDau);
                    Report.SetParameterValue("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);


                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    return;
                    
                case "TongHopTNCN_TheoThang":
                    Report = new Report.NhanSu.rpt_BaoCaoTongHopTNCN_TheoThang();
                    command.CommandText = "spd_Report_ChiTietThueTNCN_TheoThang";
                    command.Parameters.AddWithValue("@MaKyTinhLuong", Convert.ToInt32(cmbKyLuong.Value));
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
                    Report.SetParameterValue("ngay", KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbKyLuong.Value)).NgayBatDau);
                    Report.SetParameterValue("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);

                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    return;

                case "BaoCaoThuNhapLuyKe":
                    Report = new Report.Thue.TongHopThuNhapTheoThang();
                    command.CommandText = "spd_BaoCaoThuNhapLuyKe";
                    KyTinhLuong ky=  KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbKyLuong.Value));
                    if (checkBox1.Checked == true)
                    {
                        command.Parameters.AddWithValue("@MaKyTinhLuong", 0);
                        command.Parameters.AddWithValue("@Nam", ky.Nam);
                    }
                    else
                    {

                        command.Parameters.AddWithValue("@MaKyTinhLuong", ky.MaKy);
                        command.Parameters.AddWithValue("@Nam",0);
                    }
              
                    command.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BaoCaoThuNhapLuyKe;1";

                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    adapter.SelectCommand = command1;
                    adapter.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);

                    Report.SetDataSource(dataSet);
                    if (checkBox1.Checked == true)
                    {
                        Report.SetParameterValue("NoiDung", "Năm: " +ky.Nam);
                    }
                    else
                    {
                        Report.SetParameterValue("NoiDung", "Theo: " + ky.TenKy);
                    }
                  
                    Report.SetParameterValue("BoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);

                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    return;
                case "BaoCaoThuNhapLuyKeTheoBoPhan":
                    Report = new Report.Thue.TongHopThuNhapTheoThangBoPhan();
                    command.CommandText = "spd_BaoCaoThuNhapLuyKe";
                    KyTinhLuong ky1 = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbKyLuong.Value));
                    if (checkBox1.Checked == true)
                    {
                        command.Parameters.AddWithValue("@MaKyTinhLuong", 0);
                        command.Parameters.AddWithValue("@Nam", ky1.Nam);
                    }
                    else
                    {

                        command.Parameters.AddWithValue("@MaKyTinhLuong", ky1.MaKy);
                        command.Parameters.AddWithValue("@Nam", 0);
                    }

                    command.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BaoCaoThuNhapLuyKe;1";

                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    adapter.SelectCommand = command1;
                    adapter.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);

                    Report.SetDataSource(dataSet);
                    if (checkBox1.Checked == true)
                    {
                        Report.SetParameterValue("NoiDung", "Năm: " + ky1.Nam);
                    }
                    else
                    {
                        Report.SetParameterValue("NoiDung", "Theo: " + ky1.TenKy);
                    }

                    Report.SetParameterValue("BoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);

                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    return;   
                default:
                    return;
            }

            f.SetNguoiKy((int)cmbKyTen.Value);
            f.SetParameter("PhanLoai", PhanLoai);
            if (cmbKyLuong.Value != null)
            {
                f.SetParameter("ThoiGian", ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value).TenKy);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ký tính lương");
                return;
            }
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.Value is int && (int)cmbBoPhan.Value != 0 && cmbNhanVien.Visible)
            {
                cmbNhanVien.LoadDataByBoPhanALL((int)cmbBoPhan.Value);
            }
            else if (cmbNhanVien.Visible)
                cmbNhanVien.LoadDataLong();
        }

        int Thang, Nam;
        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            KyTinhLuong ktl = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbKyLuong.Value));
            Thang = ktl.Thang;
            Nam = ktl.Nam;
        }
    }
}