using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
using DevExpress.XtraLayout;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmBaoCaoTongThuNhap : Form
    {
        FilterCombo fileternganHang;
        int userID = CurrentUser.Info.UserID;
        public frmBaoCaoTongThuNhap()
        {
            InitializeComponent();
        }

        #region Functions

        private void AnTatCaControlItem()
        {
            foreach (LayoutControlItem item in this.layoutControlGroup1.Items)
            {
                item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            emptySpaceItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void ShowControlItem(LayoutControlItem item)
        {
            item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        }

        private void frmBaoCaoTongThuNhap_Load(object sender, EventArgs e)
        {
            txtTuNgay.DateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            txtDenNgay.DateTime = DateTime.Today;

            treeReport.ExpandAll();
            cmbKyTen.Value = 0;


            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();

            cmbDenKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();

            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanListAll(userID);
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbBoPhan.Value = 0;

        }
        #endregion//Functions

        #region Events
        private void treeReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AnTatCaControlItem();
            if (e.Node.Nodes.Count == 0)
            {
                switch (treeReport.SelectedNode.Name)
                {
                    case "NodeBaoCaoTongHopThuNhapCoTinhThue"://1
                        {
                            ShowControlItem(item_cmbKyLuong);
                            item_cmbKyLuong.Text = "Từ kỳ";
                            ShowControlItem(item_cmbDenKyLuong);
                        }
                        break;
                    case "NodeBaoCaoChiTietThuNhapCoTinhThue"://1
                        {
                            ShowControlItem(item_cmbKyLuong);
                            item_cmbKyLuong.Text = "Từ kỳ";
                            ShowControlItem(item_cmbDenKyLuong);
                        }
                        break;
                    case "NodeDanhSachTongHopThueTNCN"://2///Chi Tiet Thue Thu Nhap Ca Nhan
                    case "NodeTongHopTongThuNhapCaNhan":
                        {
                            //ShowControlItem(item_txtTuNgay);
                            //ShowControlItem(item_txtDenNgay);
                            ShowControlItem(item_cmbBoPhan);
                            ShowControlItem(item_cmbDenKyLuong);
                            ShowControlItem(item_checkChayTheoNam);
                            ShowControlItem(item_cmbKyTen);
                        }
                        break;
                    case "NodeChiTietTNCN_TheoThang"://2//Chi Tiet Thue THu Nhap Ca Nhan Theo Thang
                    case "NodeTongHopTNCN_TheoThang"://2 Tong Hop Thue Thu Nhap Ca Nhan Theo Thang
                    case "NodeTongHopThueTNCNTheoThang"://2
                        {
                            //ShowControlItem(item_txtTuNgay);
                            //ShowControlItem(item_txtDenNgay);
                            ShowControlItem(item_cmbKyLuong);
                            item_cmbKyLuong.Text = "Tháng lương";
                            ShowControlItem(item_checkChayTheoNam);
                            ShowControlItem(item_cmbKyTen);
                        }
                        break;
                    default:
                        this.AnTatCaControlItem();
                        break;
                }
            }
            else
            {
                barbt_Xem.Enabled = false;
            }
        }



        int Thang, Nam;
        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            KyTinhLuong ktl = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbKyLuong.Value));
            Thang = ktl.Thang;
            Nam = ktl.Nam;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barbt_Xem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (treeReport.SelectedNode == null) return;
            if (cmbKyLuong.Visible && (cmbKyLuong.Value == null || (int)cmbKyLuong.Value == 0))
            {
                MessageBox.Show("Bạn chưa chọn từ kỳ tính lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbDenKyLuong.Visible && (cmbDenKyLuong.Value == null || (int)cmbDenKyLuong.Value == 0))
            {
                MessageBox.Show("Bạn chưa chọn đến kỳ tính lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //báo cáo
            frmXemIn f = new frmXemIn();
            string PhanLoai;
            PhanLoai = "";
            long MaNhanVien = 0;

            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;

            ReportDocument Report = new ReportDocument();
            DataSet dataSet = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command.CommandTimeout = 360;

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command1.CommandTimeout = 360;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();

            frmHienThiReport dlg = new frmHienThiReport();

            switch (treeReport.SelectedNode.Name)
            {
                case "NodeDanhSachTongHopThueTNCN":
                    DateTime denNgay = (KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbDenKyLuong.Value))).NgayKetThuc;
                    //rpt.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptChiTietChuyenKhoanNhanVienBoPhan.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangChiTietTamThuThueTNCN_TongHop.rdlc";
                    f.SetDatabase("ThueTNCNList", ERP_Library.ThueTNCNLuyTienList.GetThueTNCNLuyTienList(denNgay, (int)cmbBoPhan.Value));
                    f.SetParameter("TieuDe", "BẢNG CHI TIẾT TỔNG THU NHẬP, THU NHẬP CHỊU THUẾ VÀ THUẾ THU NHẬP CÁ NHÂN");
                    f.SetParameter("DenNgay", (denNgay).ToString("dd/MM/yyyy"));//((DateTime)txtDenNgay.Value).ToString("dd/MM/yyyy"));
                    f.SetParameter("TenCongTy", ERP_Library.CongTy.GetCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).TenCongTy);
                    break;
                case "NodeTongHopTongThuNhapCaNhan":
                    DateTime denNgay1 = (KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbDenKyLuong.Value))).NgayKetThuc;
                    //rpt.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptChiTietChuyenKhoanNhanVienBoPhan.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangTongHopTamThuThueTNCN_TongHop.rdlc";
                    f.SetDatabase("ThueTNCNList", ERP_Library.ThueTNCNLuyTienList.GetThueTNCNLuyTienList(denNgay1, (int)cmbBoPhan.Value));
                    f.SetParameter("TieuDe", "BẢNG CHI TIẾT TỔNG THU NHẬP, THU NHẬP CHỊU THUẾ VÀ THUẾ THU NHẬP CÁ NHÂN");
                    f.SetParameter("DenNgay", (denNgay1).ToString("dd/MM/yyyy")); //((DateTime)txtDenNgay.Value).ToString("dd/MM/yyyy"));
                    f.SetParameter("TenCongTy", ERP_Library.CongTy.GetCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).TenCongTy);
                    break;
                case "NodeChiTietTNCN_TheoThang":
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
                case "NodeTongHopTNCN_TheoThang":
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
                case "NodeTongHopThueTNCNTheoThang":
                    f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptTongHopChuyenKhoanTruThueTheoUNC.rdlc";
                    f.SetDatabase("ChiTietChuyenKhoanList", ERP_Library.Report.ChiTietChuyenKhoanList.GetTongHopChuyenKhoanByKyTinhLuong(Thang, Nam));
                    f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "VeViec", "Tháng " + Thang + " Năm " + Nam);
                    int NguoiKy = (int)cmbKyTen.Value;
                    f.SetNguoiKy_DeNghiCK(NguoiKy);
                    f.ShowDialog();
                    return;

                case "NodeBaoCaoChiTietThuNhapCoTinhThue":
                    Report = new Report.Thue.TongThuNhapCoTinhThueNew();
                    command.CommandText = "spd_BaoCaoTongThuNhapCoTinhThue";
                    KyTinhLuong ky = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbKyLuong.Value));
                    KyTinhLuong denky = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbDenKyLuong.Value));
                    command.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@TuKyTinhLuong", Convert.ToInt32(cmbKyLuong.Value));
                    command.Parameters.AddWithValue("@DenKyTinhLuong", Convert.ToInt32(cmbDenKyLuong.Value));
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BaoCaoTongThuNhapCoTinhThue;1";
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    adapter.SelectCommand = command1;
                    adapter.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("NoiDung", String.Format("Từ: {0} Đến: {1}", ky.TenKy, denky.TenKy));
                    Report.SetParameterValue("BoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                    Report.SetParameterValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    Report.SetParameterValue("@TuKyTinhLuong", Convert.ToInt32(cmbKyLuong.Value));
                    Report.SetParameterValue("@DenKyTinhLuong", Convert.ToInt32(cmbDenKyLuong.Value));
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    return;

                case "NodeBaoCaoTongHopThuNhapCoTinhThue":
                    Report = new Report.Thue.TongThuNhapCoTinhThueTheoBoPhanNew();
                    command.CommandText = "spd_BaoCaoTongThuNhapCoTinhThue";
                    KyTinhLuong TukyTH = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbKyLuong.Value));
                    KyTinhLuong DenkyTH = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbDenKyLuong.Value));
                    command.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@TuKyTinhLuong", Convert.ToInt32(cmbKyLuong.Value));
                    command.Parameters.AddWithValue("@DenKyTinhLuong", Convert.ToInt32(cmbDenKyLuong.Value));
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BaoCaoTongThuNhapCoTinhThue;1";
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    adapter.SelectCommand = command1;
                    adapter.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("NoiDung", String.Format("Từ: {0} Đến: {1}", TukyTH.TenKy, DenkyTH.TenKy));
                    Report.SetParameterValue("BoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                    Report.SetParameterValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    Report.SetParameterValue("@TuKyTinhLuong", Convert.ToInt32(cmbKyLuong.Value));
                    Report.SetParameterValue("@DenKyTinhLuong", Convert.ToInt32(cmbDenKyLuong.Value));
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    return;

                case "BaoCaoThuNhapLuyKeTheoBoPhan":
                    Report = new Report.Thue.TongHopThuNhapTheoThangBoPhan();
                    command.CommandText = "spd_BaoCaoThuNhapLuyKe";
                    KyTinhLuong ky1 = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbKyLuong.Value));

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

                    Report.SetParameterValue("BoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);

                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    return;
                default:
                    return;
            }

            f.SetNguoiKy((int)cmbKyTen.Value);
            f.SetParameter("PhanLoai", PhanLoai);
            if (cmbKyLuong.Visible && cmbKyLuong.Value != null)
            {
                f.SetParameter("ThoiGian", ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value).TenKy);
                f.ShowDialog();
            }
            else if (cmbDenKyLuong.Visible && cmbDenKyLuong.Value != null)
            {
                f.SetParameter("ThoiGian", ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbDenKyLuong.Value).TenKy);
                f.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Vui lòng chọn kỳ tính lương");
                return;
            }
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            //if (cmbBoPhan.Value is int && (int)cmbBoPhan.Value != 0 && cmbNhanVien.Visible)
            //{
            //    cmbNhanVien.LoadDataByBoPhanALL((int)cmbBoPhan.Value);
            //}
            //else if (cmbNhanVien.Visible)
            //    cmbNhanVien.LoadDataLong();
        }
        #endregion//Events
    }
}