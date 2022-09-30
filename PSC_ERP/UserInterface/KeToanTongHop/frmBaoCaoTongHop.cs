using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid; 

namespace PSC_ERP
{
    public partial class frmBaoCaoTongHop : Form
    {
        DateTime ngayBatDau;
        DateTime ngayKetThuc;
        DateTime Ngay;
        int maTaiKhoan;
        int maKy;
        int Loai;
        int Quy;
        int Nam;
        string TenKy = string.Empty;
        string TenQuy = string.Empty;
        string TieuDe = string.Empty;
        string Tua = string.Empty;
        byte loaiTaiKhoan;
        MucNganSachList _MucNganSachList = MucNganSachList.NewMucNganSachList();
        DoiTuongAllList _DoiTuongThuChiList = DoiTuongAllList.NewDoiTuongAllList();
        //DoiTuongAllList _DoiTuongThuChiList;
        Ky ky =  Ky.NewKy();       

        DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
        string mamucngansach = string.Empty;
        string maTieuMucNganSach = string.Empty;
        string maPhongBanChuoi = string.Empty;
        string maTaiKhoanChuoi = string.Empty;
        ERP_Library.Security.UserList _UserList;
        int NguoiLap = 0;
        string tenbophan = "";
        int _maHopDong = 0;
        HopDongMuaBanList _hopDongList;

        TieuMucNganSachList _TieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();

        #region Contructors
        public frmBaoCaoTongHop()
        { 
            InitializeComponent();
            
            kyListBindingSource.DataSource = typeof(KyList);
            cb_Ky.DataSource = kyListBindingSource;
            
            heThongTaiKhoan1ListBindingSource.DataSource = typeof(HeThongTaiKhoan1List);
            cbu_SoHieuTK.DataSource = heThongTaiKhoan1ListBindingSource;
            
            quyListBindingSource.DataSource = typeof(QuyList);
            cbu_Quy.DataSource = quyListBindingSource;

            MucNganSach_BindingSource.DataSource = typeof(MucNganSachList);
            ultraCombo_Nhom.DataSource = MucNganSach_BindingSource;

            TieuMucNSList_bindingSource.DataSource = typeof(TieuMucNganSachList);
            ultraCombo_TieuMuc.DataSource = TieuMucNSList_bindingSource;

            doiTuongAllListBindingSource.DataSource = typeof(DoiTuongAllList);
            cbu_DoiTuong.DataSource = doiTuongAllListBindingSource;

            doiTuongThuChiListBindingSource.DataSource = typeof(DoiTuongThuChiList);
            cb_LoaiCongViec.DataSource = doiTuongThuChiListBindingSource;

            NguoiLapListBindingSouce.DataSource = typeof(ERP_Library.Security.UserList);
            cb_LoaiCongViec.DataSource = NguoiLapListBindingSouce;

            _MucNganSachList = MucNganSachList.GetMucNganSachList();
            MucNganSach _MucNganSach = MucNganSach.NewMucNganSach("Tất Cả");
            _MucNganSachList.Insert(0,_MucNganSach);
            MucNganSach_BindingSource.DataSource = _MucNganSachList;              

            kyListBindingSource.DataSource = KyList.GetKyList();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            quyListBindingSource.DataSource = QuyList.GetQuyList();
            
            _UserList = ERP_Library.Security.UserList.GetUserList(ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            ERP_Library.Security.UserItem user = ERP_Library.Security.UserItem.NewUserItem("Tất Cả");
            _UserList.Insert(0, user);
            NguoiLapListBindingSouce.DataSource = _UserList;

            cmbTaiKhoan.DataSource = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();

            Ky ky;
            if (cb_Ky.SelectedItem != null)
            {
                ky = (Ky)(cb_Ky.SelectedItem);
                maKy = ky.MaKy;
                dtu_TuNgay.Value = ky.NgayBatDau;
                dtu_DenNgay.Value = ky.NgayKetThuc;
                ngayBatDau = ky.NgayBatDau;
                ngayKetThuc = ky.NgayKetThuc;
            }
            for (int i = 2000; i <= 2060; i++)
            {
                cb_Nam.Items.Add(i);
            }
            cb_Nam.Text = DateTime.Today.Year.ToString();
            ultraTree_DSBaoCao.ExpandAll();
            cmbKyTen.SelectedIndex = 1;
           
        }
        #endregion

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            maPhongBanChuoi = ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString();
            
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

            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.StoredProcedure;
            command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command2.CommandTimeout = 0;

            SqlCommand command3 = new SqlCommand();
            command3.CommandType = CommandType.StoredProcedure;
            command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command3.CommandTimeout = 0;

            SqlCommand command4 = new SqlCommand();
            command4.CommandType = CommandType.StoredProcedure;
            command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command4.CommandTimeout = 0;


            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            DataTable table3 = new DataTable();
            DataTable table4 = new DataTable();
            BoPhan _BoPhan = BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            Loai = 0;
            if (cbu_Quy.Value != null)
            {
                Quy = Convert.ToInt32(cbu_Quy.Value);
                TenQuy = cbu_Quy.Text;
            }
            if (cb_Nam.Text != null && cb_Nam.Text != "")
                Nam = Convert.ToInt32(cb_Nam.Text);         
            if (rbt_Ky.Checked == true)
            {
                Loai = 1;
                TieuDe = TenKy;
                ngayBatDau = ky.NgayBatDau ;
                ngayKetThuc = ky.NgayKetThuc;
                Tua = "Tháng";
            }
            else if (rbt_Quy.Checked == true)
            {
                Loai = 2;
                TieuDe = TenQuy;
                Tua = "Quý";
            }
            else if (rbt_TuNgay.Checked == true)
            {
                ngayBatDau = Convert.ToDateTime(dtu_NgayBatDau.Value).Date;
                ngayKetThuc = Convert.ToDateTime(dtu_NgayKetThuc.Value).Date;
                TieuDe = "Từ ngày " + ngayBatDau.ToString("dd/MM/yyyy") + " đến ngày " + ngayKetThuc.ToString("dd/MM/yyyy");
                Loai = 0;
               
            }
            else if (rdbt_TheoTungNgay.Checked == true)
            {
                Ngay = Convert.ToDateTime(dtu_TungNgay.Value);
                ngayBatDau = Convert.ToDateTime(dtu_TungNgay.Value);
                ngayKetThuc = Convert.ToDateTime(dtu_TungNgay.Value);
                TieuDe = "Ngày " + Ngay.ToString("dd/MM/yyyy");
                Tua = "Ngày";
                
            }
            else
            {
                Loai = 3;
                TieuDe = "Năm " + Nam.ToString();
                Tua = "Năm";
            }        

            #region SoChiTietTaiKhoan_nganHang
            if (ultraTree_DSBaoCao.ActiveNode.Key == "SoChiTiet_NganHang" || ultraTree_DSBaoCao.ActiveNode.Key == "SoChiTiet_NganHang_NgayLap" )
            {
                if (_DoiTuong.MaDoiTuong == 0)
                {
                    CongTy_NganHang ct = CongTy_NganHang.GetCongTy_NganHang(Convert.ToInt32(cmbTaiKhoan.Value));
                    HeThongTaiKhoan1 ht = HeThongTaiKhoan1.GetHeThongTaiKhoan1(ct.MaTKKeToan);
                    LoaiTien lt = LoaiTien.GetLoaiTien(ct.LoaiTien);
                    NganHang nh = NganHang.GetNganHang(ct.MaNganHang);

                    if (lt.MaLoaiTien == 1)
                    {
                        Report = new Report.NganHang.rpt_SoChiTietTaiKhoan_NganHang();
                    }
                    else
                    {
                        Report = new Report.NganHang.rpt_SoChiTietTaiKhoan_NganHang_NT();
                    }

                    if (ultraTree_DSBaoCao.ActiveNode.Key == "SoChiTiet_NganHang")
                    {
                        command.CommandText = "spd_Report_SoDuDauKy_NganHang";
                    }
                    else
                    {
                        command.CommandText = "spd_Report_SoDuDauKy_NganHang_TheoNgayLap";
                    }
                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaNganHang", Convert.ToInt32(cmbTaiKhoan.Value));
                    command.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_Report_SoDuDauKy_NganHang;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    adapter.SelectCommand = command1;
                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";
                    command1.CommandTimeout = 0;
                    command2.CommandText = "spd_LayNguoiKyTenCongNo";
                    command2.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command2.CommandTimeout = 0;
                    adapter.SelectCommand = command2;
                    adapter.Fill(table2);
                    table2.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table2);

                    Report.SetDataSource(dataSet);
 
                    Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                    Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
                    Report.SetParameterValue("@TieuDe", "TK " + ht.SoHieuTK + ": " + ht.TenTaiKhoan + " (" + ct.SoTaiKhoan + ") " + ct.TenNganHang);
                    Report.SetParameterValue("@LoaiTien", lt.MaLoaiQuanLy);
                }
            }
            #endregion

            #region SoChiTietTaiKhoan
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "SoChiTietTaiKhoan" || ultraTree_DSBaoCao.ActiveNode.Key == "SoChiTietTaiKhoanTongHopTheoCT")
            {
                if (_DoiTuong.MaDoiTuong == 0)
                {
                    Report = new Report.ReportTongHop.Report_SoChiTietTaiKhoan();
                    command.CommandText = "report_SoChiTietTaiKhoan_SoHieu";
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());
                    command.CommandTimeout = 0;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "report_SoChiTietTaiKhoan_SoHieu;1";
                    if (ultraTree_DSBaoCao.ActiveNode.Key == "SoChiTietTaiKhoan")
                    {
                        command1.CommandText = "report_SoChiTietTaiKhoan";
                    }
                    else
                    {
                        command1.CommandText = "report_SoChiTietTaiKhoanTongHopTheoChungTu";
                    }
                   
                    command1.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command1.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command1.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command1.Parameters.AddWithValue("@MaKy", maKy);
                    command1.Parameters.AddWithValue("@Loai", Loai);
                    command1.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());
                    command1.Parameters.AddWithValue("@UserId", NguoiLap);
                    adapter.SelectCommand = command1;
                    adapter.Fill(table1);
                    table1.TableName = "report_SoChiTietTaiKhoan;1";

                    command2.CommandText = "spd_report_ReportHeader";
                    command2.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    adapter.SelectCommand = command2;
                    adapter.Fill(table2);
                    table2.TableName = "spd_REPORT_ReportHeader;1";
                    command2.CommandTimeout = 0;
                    command3.CommandText = "spd_LayNguoiKyTenCongNo";
                    command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command2.CommandTimeout = 0;
                    adapter.SelectCommand = command3;
                    adapter.Fill(table3);
                    table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                    command4.CommandText = "aspd_LuyKe";
                    command4.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command4.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command4.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command4.Parameters.AddWithValue("@MaKy", maKy);
                    //command4.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command4;
                    adapter.Fill(table4);
                    table4.TableName = "aspd_LuyKe;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table2);
                    dataSet.Tables.Add(table3);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);

                    Report.SetParameterValue("@MaTaiKhoan", maTaiKhoan);
                    Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                    Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
                }
                else
                {
                    Report = new Report.ReportTongHop.Report_SoChiTietTaiKhoanTheoDoiTuong();

                    command.CommandText = "report_SoChiTietTaiKhoan_SoHieu";
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    command.CommandTimeout = 0;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "report_SoChiTietTaiKhoan_SoHieu;1";

                    command1.CommandText = "report_SoChiTietTaiKhoanTheoDoiTuong";
                    command1.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command1.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command1.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command1.Parameters.AddWithValue("@MaKy", maKy);
                    command1.Parameters.AddWithValue("@Loai", Loai);
                    command1.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    command1.Parameters.AddWithValue("@MaDoiTuong", _DoiTuong.MaDoiTuong);
                    command1.Parameters.AddWithValue("@MaDoiTuongThuChi", 0);
                    command1.Parameters.AddWithValue("@MaUser", NguoiLap);
                    adapter.SelectCommand = command1;
                    adapter.Fill(table1);
                    table1.TableName = "report_SoChiTietTaiKhoanTheoDoiTuong;1";

                    command2.CommandText = "spd_report_ReportHeader";
                    command2.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    adapter.SelectCommand = command2;
                    command2.CommandTimeout = 0;
                    adapter.Fill(table2);
                    table2.TableName = "spd_REPORT_ReportHeader;1";

                    command3.CommandText = "spd_LayNguoiKyTenCongNo";
                    command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command3.CommandTimeout = 0;
                    adapter.SelectCommand = command3;
                    adapter.Fill(table3);
                    table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                    command4.CommandText = "aspd_LuyKe_DoiTuong";
                    command4.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command4.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command4.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command4.Parameters.AddWithValue("@MaKy", maKy);
                    command4.Parameters.AddWithValue("@MaDoiTuong", _DoiTuong.MaDoiTuong);
                    command4.CommandTimeout = 0;
                   // command4.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command4;
                    adapter.Fill(table4);
                    table4.TableName = "aspd_LuyKe_DoiTuong;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table2);
                    dataSet.Tables.Add(table3);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);

                    Report.SetParameterValue("@MaTaiKhoan", maTaiKhoan);
                    Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                    Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
                    Report.SetParameterValue("@TuNgay", ngayBatDau);
                    Report.SetParameterValue("@DenNgay", ngayKetThuc);
                    Report.SetParameterValue("@MaKy", maKy);
                    Report.SetParameterValue("@Loai", Loai);
                    Report.SetParameterValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    Report.SetParameterValue("@MaDoiTuong", _DoiTuong.MaDoiTuong);
                    Report.SetParameterValue("@MaDoiTuongThuChi", 0);
                    Report.SetParameterValue("@TenDoiTuong", _DoiTuong.TenDoiTuong);
                }

            }
            #endregion 

            else if (ultraTree_DSBaoCao.ActiveNode.Key == "SoChiTietTaiKhoan_TheoHopDong")
            {
                Report = new Report.ReportTongHop.Report_SoChiTietTaiKhoan_TheoHopDong();

                command.CommandText = "report_SoChiTietTaiKhoan_SoHieu";
                command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                command.Parameters.AddWithValue("@MaKy", maKy);
                command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());
                command.CommandTimeout = 0;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "report_SoChiTietTaiKhoan_SoHieu;1";

                command1.CommandText = "spd_Report_SoChiTietTaiKhoanTheoHopdong";
                command1.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command1.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command1.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                command1.Parameters.AddWithValue("@MaKy", maKy);
                command1.Parameters.AddWithValue("@MaDoiTuong", _DoiTuong.MaDoiTuong);
                command1.Parameters.AddWithValue("@MaHopDong", _maHopDong);
                command1.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());
                command1.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_Report_SoChiTietTaiKhoanTheoHopdong;1";

                command2.CommandText = "spd_report_ReportHeader";
                command2.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                adapter.SelectCommand = command2;
                adapter.Fill(table2);
                table2.TableName = "spd_REPORT_ReportHeader;1";
                command2.CommandTimeout = 0;
                command3.CommandText = "spd_LayNguoiKyTenCongNo";
                command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                command2.CommandTimeout = 0;
                adapter.SelectCommand = command3;
                adapter.Fill(table3);
                table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                command4.CommandText = "aspd_LuyKe_HopDong";
                command4.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command4.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command4.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                command4.Parameters.AddWithValue("@MaHopDong", _maHopDong);
                command4.Parameters.AddWithValue("@MaDoiTuong", _DoiTuong.MaDoiTuong);
                //command4.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                adapter.SelectCommand = command4;
                adapter.Fill(table4);
                table4.TableName = "aspd_LuyKe_HopDong;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table2);
                dataSet.Tables.Add(table3);
                dataSet.Tables.Add(table4);

                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@MaTaiKhoan", maTaiKhoan);
                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);

            }


            #region SoNhatKyChung
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "SoNhatKyChung")
            {

                Report = new Report.ReportTongHop.Report_SoNhatKyChung();
                command.CommandText = "report_SoNhatKyChung";
                command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dtu_NgayBatDau.Value));
                command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dtu_NgayKetThuc.Value));
                command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "report_SoNhatKyChung;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                command3.CommandText = "spd_LayNguoiKyTenCongNo";
                command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                adapter.SelectCommand = command3;
                adapter.Fill(table3);
                table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table3);

                Report.SetDataSource(dataSet);
                Report.SetParameterValue("@NgayBatDau", Convert.ToDateTime(dtu_NgayBatDau.Value));
                Report.SetParameterValue("@NgayKetThuc", Convert.ToDateTime(dtu_NgayKetThuc.Value));

            }
            #endregion

            #region SoCai
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "SoCai")
            {
                Report = new Report.ReportTongHop.SoCai();
                command.CommandText = "spd_SoDuDau_TaiKhoan";

                command.Parameters.AddWithValue("@MaKy", maKy);
                command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_SoDuDau_TaiKhoan;1";

                command1.CommandText = "spd_SoCai";
                command1.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command1.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command1.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                command1.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_SoCai;1";

                command4.CommandType = CommandType.StoredProcedure;
                command4.CommandText = "spd_LayNguoiKyTenCongNo";
                command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                adapter4.Fill(table4);
                table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table4);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("ngayBatDau", ngayBatDau);
                Report.SetParameterValue("ngayKetThuc", ngayKetThuc);
            }
            #endregion

            #region BangCanDoiSoPhatSinhCapMot
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiSoPhatSinhCapMot")
            {
                if (rdbt_TheoTungNgay.Checked == true)
                {
                    Report = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapMot_TheoNgay();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_CapMot_TheoNgay";

                    command.Parameters.AddWithValue("@TuNgay", Ngay);
                    command.Parameters.AddWithValue("@DenNgay", Ngay);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_CapMot_TheoNgay;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@NgayTrenForm", Ngay);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                }

                else
                {
                    Report = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapMotAll();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_CapMotAll";

                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@Quy", Quy);
                    command.Parameters.AddWithValue("@Nam", Nam);
                    command.Parameters.AddWithValue("@Loai", Loai);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_CapMotAll;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";


                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@Thang", ngayBatDau.Month);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@Tua", Tua);

                }
            }
            #endregion

            #region BangCanDoiSoPhatSinhCapHai
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiSoPhatSinhCapHai")
            {
                if (rdbt_TheoTungNgay.Checked == true)
                {
                    Report = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapHai_TheoNgay();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_CapHai_TheoNgay";
                    command.Parameters.AddWithValue("@TuNgay", Ngay);
                    command.Parameters.AddWithValue("@DenNgay", Ngay);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_CapHai_TheoNgay;1";

                    //command1.CommandText = "spd_BangCanDoiSoPhatSinh_CapMot_TheoNgay";
                    //command1.Parameters.AddWithValue("@TuNgay", Ngay);
                    //command1.Parameters.AddWithValue("@DenNgay", Ngay);
                    //command1.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    //adapter.SelectCommand = command1;
                    //adapter.Fill(table1);
                    //table1.TableName = "spd_BangCanDoiSoPhatSinh_CapMot_TheoNgay;1";

                    command2.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command2;
                    command2.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                    adapter.Fill(table2);
                    table2.TableName = "spd_REPORT_ReportHeader;1";
                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table2);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@NgayTrenForm", Ngay);
                    Report.SetParameterValue("@TieuDe", TieuDe);

                }

                else
                {

                    Report = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapHaiAll();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_CapMotAll";

                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@Quy", Quy);
                    command.Parameters.AddWithValue("@Nam", Nam);
                    command.Parameters.AddWithValue("@Loai", Loai);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_CapMotAll;1";

                    command1.CommandText = "spd_BangCanDoiSoPhatSinh_CapHaiAll";
                    command1.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command1.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command1.Parameters.AddWithValue("@MaKy", maKy);
                    command1.Parameters.AddWithValue("@Quy", Quy);
                    command1.Parameters.AddWithValue("@Nam", Nam);
                    command1.Parameters.AddWithValue("@Loai", Loai);
                    command1.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());

                    adapter.SelectCommand = command1;
                    adapter.Fill(table1);
                    table1.TableName = "spd_BangCanDoiSoPhatSinh_CapHaiAll;1";


                    command2.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command2;
                    command2.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                    adapter.Fill(table2);
                    table2.TableName = "spd_REPORT_ReportHeader;1";

                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table2);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@TuNgay", ngayBatDau);
                    Report.SetParameterValue("@DenNgay", ngayKetThuc);
                    Report.SetParameterValue("@MaKy", maKy);
                    Report.SetParameterValue("@Quy", Quy);
                    Report.SetParameterValue("@Nam", Nam);
                    Report.SetParameterValue("@Loai", Loai);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@Tua", Tua);
                }

            }
            #endregion

            #region BangCanDoiSoPhatSinhCapBa
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiSoPhatSinhCapBa")
            {
                if (rdbt_TheoTungNgay.Checked == true)
                {
                    Report = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapBa_TheoNgay();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_CapBa_TheoNgay";

                    command.Parameters.AddWithValue("@TuNgay", Ngay);
                    command.Parameters.AddWithValue("@DenNgay", Ngay);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_CapBa_TheoNgay;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@Ngay", Ngay);
                    Report.SetParameterValue("@NgayTrenForm", Ngay);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@TenBoPhan", _BoPhan.TenBoPhan);
                }
                else if (rbt_TuNgay.Checked == true)
                {
                    Report = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapBa_TheoNgay();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_CapBa_TheoNgay";

                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_CapBa_TheoNgay;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@TuNgay", ngayBatDau);
                    Report.SetParameterValue("@DenNgay", ngayBatDau);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    Report.SetParameterValue("@TenBoPhan", _BoPhan.TenBoPhan);
                }
                else
                {

                    Report = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapBaAll();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_CapBaAll";

                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@Quy", Quy);
                    command.Parameters.AddWithValue("@Nam", Nam);
                    command.Parameters.AddWithValue("@Loai", Loai);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_CapBaAll;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);


                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@TenBoPhan", _BoPhan.TenBoPhan);
                    Report.SetParameterValue("@Tua", Tua);
                }
                //Report.SetParameterValue("@Thang", ngayBatDau.Month);
            }
            #endregion

            #region BangCanDoiSoPhatSinhCapMotLuyKe
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiTaiKhoanCapMotLuyKe")
            {

                Report = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapMot_LuyKe();
                command.CommandText = "spd_BangCanDoiSoPhatSinh_CapMot_LuyKe";

                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@MaKy", maKy);
                command.Parameters.AddWithValue("@Quy", Quy);
                command.Parameters.AddWithValue("@Nam", Nam);
                command.Parameters.AddWithValue("@Loai", Loai);
                command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());

                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BangCanDoiSoPhatSinh_CapMot_LuyKe;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";


                command4.CommandType = CommandType.StoredProcedure;
                command4.CommandText = "spd_LayNguoiKyTenCongNo";
                command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                adapter4.Fill(table4);
                table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table4);

                Report.SetDataSource(dataSet);
                Report.SetParameterValue("@Thang", ngayBatDau.Month);
                Report.SetParameterValue("@TieuDe", TieuDe);
                Report.SetParameterValue("@Tua", Tua);

            }
            #endregion

            #region BangCanDoiSoPhatSinhCapHaiLuyKe
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiTaiKhoanCapHaiLuyKe")
            {

                Report = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapHai_LuyKe();
                command.CommandText = "spd_BangCanDoiSoPhatSinh_CapHai_LuyKe";

                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@MaKy", maKy);
                command.Parameters.AddWithValue("@Quy", Quy);
                command.Parameters.AddWithValue("@Nam", Nam);
                command.Parameters.AddWithValue("@Loai", Loai);
                command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());

                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BangCanDoiSoPhatSinh_CapHai_LuyKe;1";

                command1.CommandText = "spd_BangCanDoiSoPhatSinh_CapMot_LuyKe";
                command1.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command1.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command1.Parameters.AddWithValue("@MaKy", maKy);
                command1.Parameters.AddWithValue("@Quy", Quy);
                command1.Parameters.AddWithValue("@Nam", Nam);
                command1.Parameters.AddWithValue("@Loai", Loai);
                command1.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());

                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_BangCanDoiSoPhatSinh_CapMot_LuyKe;1";


                command2.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command2;
                command2.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                adapter.Fill(table2);
                table2.TableName = "spd_REPORT_ReportHeader;1";

                command4.CommandType = CommandType.StoredProcedure;
                command4.CommandText = "spd_LayNguoiKyTenCongNo";
                command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                adapter4.Fill(table4);
                table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table2);
                dataSet.Tables.Add(table4);

                Report.SetDataSource(dataSet);
                Report.SetParameterValue("@TuNgay", ngayBatDau);
                Report.SetParameterValue("@DenNgay", ngayKetThuc);
                Report.SetParameterValue("@MaKy", maKy);
                Report.SetParameterValue("@Quy", Quy);
                Report.SetParameterValue("@Nam", Nam);
                Report.SetParameterValue("@Loai", Loai);
                Report.SetParameterValue("@TieuDe", TieuDe);
                Report.SetParameterValue("@Tua", Tua);

            }
            #endregion

            #region BangCanDoiSoPhatSinhCapBaLuyKe
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiSoPhatSinhCapBaLuyKe")
            {
                if (rdbt_TheoTungNgay.Checked == true)
                {
                    Report = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapBa_TheoNgay_LuyKe();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_CapBa_LuyKeTheoNgay";

                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_CapBa_TheoNgay;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);


                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@TuNgay", ngayBatDau);
                    Report.SetParameterValue("@DenNgay", ngayBatDau);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    Report.SetParameterValue("@TenBoPhan", _BoPhan.TenBoPhan);

                }
                else if (rbt_TuNgay.Checked == true)
                {
                    Report = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapBa_TheoNgay_LuyKe();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_CapBa_LuyKeTheoNgay";

                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_CapBa_TheoNgay;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);


                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@TuNgay", ngayBatDau);
                    Report.SetParameterValue("@DenNgay", ngayBatDau);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    Report.SetParameterValue("@TenBoPhan", _BoPhan.TenBoPhan);
                }
                else
                {

                    Report = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapBaAll_LuyKe();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_CapBa_LuyKe";

                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@Quy", Quy);
                    command.Parameters.AddWithValue("@Nam", Nam);
                    command.Parameters.AddWithValue("@Loai", Loai);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString());

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_CapBaAll;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);


                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@TenBoPhan", _BoPhan.TenBoPhan);
                    Report.SetParameterValue("@Tua", Tua);
                }
                //Report.SetParameterValue("@Thang", ngayBatDau.Month);
            }
            #endregion

            #region Bảng Tổng hợp Theo Doi Đối Tượng
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangTongHopTheoDoiDoiTuong")
            {
                if (rdbt_TheoTungNgay.Checked == true)
                {
                    Report = new Report.ReportTongHop.Report_BangCanDoiSoPhatSinh_DoiTuong();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_DoiTuong";
                    command.Parameters.AddWithValue("@TuNgay", Ngay);
                    command.Parameters.AddWithValue("@DenNgay", Ngay);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@Quy", Quy);
                    command.Parameters.AddWithValue("@Nam", Nam);
                    command.Parameters.AddWithValue("@Loai", Loai);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Parameters.AddWithValue("@MaNguoiLap", NguoiLap);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_DoiTuong;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    command2.CommandText = "report_SoChiTietTaiKhoan_SoHieu";
                    command2.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command2.Parameters.AddWithValue("@MaKy", maKy);
                    command2.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command2;
                    adapter.Fill(table2);
                    table2.TableName = "report_SoChiTietTaiKhoan_SoHieu;1";

                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table2);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@TuNgay", ngayBatDau);
                    Report.SetParameterValue("@DenNgay", ngayKetThuc);
                    Report.SetParameterValue("@MaKy", maKy);
                    Report.SetParameterValue("@Quy", Quy);
                    Report.SetParameterValue("@Nam", Nam);
                    Report.SetParameterValue("@Loai", Loai);
                    Report.SetParameterValue("@MaTaiKhoan", maTaiKhoan);
                    Report.SetParameterValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);

                }
                else if (rbt_TuNgay.Checked == true)
                {
                    Report = new Report.ReportTongHop.Report_BangCanDoiSoPhatSinh_DoiTuong();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_DoiTuong";
                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@Quy", Quy);
                    command.Parameters.AddWithValue("@Nam", Nam);
                    command.Parameters.AddWithValue("@Loai", Loai);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Parameters.AddWithValue("@MaNguoiLap", NguoiLap);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_DoiTuong;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    command2.CommandText = "report_SoChiTietTaiKhoan_SoHieu";
                    command2.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command2.Parameters.AddWithValue("@MaKy", maKy);
                    command2.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command2;
                    adapter.Fill(table2);
                    table2.TableName = "report_SoChiTietTaiKhoan_SoHieu;1";

                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table2);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@TuNgay", ngayBatDau);
                    Report.SetParameterValue("@DenNgay", ngayKetThuc);
                    Report.SetParameterValue("@MaKy", maKy);
                    Report.SetParameterValue("@Quy", Quy);
                    Report.SetParameterValue("@Nam", Nam);
                    Report.SetParameterValue("@Loai", Loai);
                    Report.SetParameterValue("@MaTaiKhoan", maTaiKhoan);
                    Report.SetParameterValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                }
                else
                {

                    Report = new Report.ReportTongHop.Report_BangCanDoiSoPhatSinh_DoiTuong();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_DoiTuong";
                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@Quy", Quy);
                    command.Parameters.AddWithValue("@Nam", Nam);
                    command.Parameters.AddWithValue("@Loai", Loai);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Parameters.AddWithValue("@MaNguoiLap", NguoiLap);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_DoiTuong;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    command2.CommandText = "report_SoChiTietTaiKhoan_SoHieu";
                    command2.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command2.Parameters.AddWithValue("@MaKy", maKy);
                    command2.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command2;
                    adapter.Fill(table2);
                    table2.TableName = "report_SoChiTietTaiKhoan_SoHieu;1";

                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table2);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@TuNgay", ngayBatDau);
                    Report.SetParameterValue("@DenNgay", ngayKetThuc);
                    Report.SetParameterValue("@MaKy", maKy);
                    Report.SetParameterValue("@Quy", Quy);
                    Report.SetParameterValue("@Nam", Nam);
                    Report.SetParameterValue("@Loai", Loai);
                    Report.SetParameterValue("@MaTaiKhoan", maTaiKhoan);
                    Report.SetParameterValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    // Report.SetParameterValue("@TenBoPhan", _BoPhan.TenBoPhan);
                }
                //Report.SetParameterValue("@Thang", ngayBatDau.Month);
            }
            #endregion

            #region Bảng Tổng hợp Theo Hợp Đồng
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangTongHopTheoHopDong")
            {
                if (rdbt_TheoTungNgay.Checked == true)
                {
                    Report = new Report.ReportTongHop.Report_BangCanDoiSoPhatSinh_DoiTuong_TheoHopDong();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_DoiTuong_TheoHopDong";
                    command.Parameters.AddWithValue("@TuNgay", Ngay);
                    command.Parameters.AddWithValue("@DenNgay", Ngay);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@Quy", Quy);
                    command.Parameters.AddWithValue("@Nam", Nam);
                    command.Parameters.AddWithValue("@Loai", Loai);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Parameters.AddWithValue("@MaNguoiLap", NguoiLap);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_DoiTuong_TheoHopDong;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    command2.CommandText = "report_SoChiTietTaiKhoan_SoHieu";
                    command2.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command2.Parameters.AddWithValue("@MaKy", maKy);
                    command2.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command2;
                    adapter.Fill(table2);
                    table2.TableName = "report_SoChiTietTaiKhoan_SoHieu;1";

                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table2);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@TuNgay", ngayBatDau);
                    Report.SetParameterValue("@DenNgay", ngayKetThuc);
                    Report.SetParameterValue("@MaKy", maKy);
                    Report.SetParameterValue("@Quy", Quy);
                    Report.SetParameterValue("@Nam", Nam);
                    Report.SetParameterValue("@Loai", Loai);
                    Report.SetParameterValue("@MaTaiKhoan", maTaiKhoan);
                    Report.SetParameterValue("@MaNguoiLap", NguoiLap);
                    Report.SetParameterValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    Report.SetParameterValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                }
                else if (rbt_TuNgay.Checked == true)
                {
                    Report = new Report.ReportTongHop.Report_BangCanDoiSoPhatSinh_DoiTuong_TheoHopDong();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_DoiTuong_TheoHopDong";
                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@Quy", Quy);
                    command.Parameters.AddWithValue("@Nam", Nam);
                    command.Parameters.AddWithValue("@Loai", Loai);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Parameters.AddWithValue("@MaNguoiLap", NguoiLap);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_DoiTuong_TheoHopDong;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    command2.CommandText = "report_SoChiTietTaiKhoan_SoHieu";
                    command2.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command2.Parameters.AddWithValue("@MaKy", maKy);
                    command2.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command2;
                    adapter.Fill(table2);
                    table2.TableName = "report_SoChiTietTaiKhoan_SoHieu;1";

                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table2);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@TuNgay", ngayBatDau);
                    Report.SetParameterValue("@DenNgay", ngayKetThuc);
                    Report.SetParameterValue("@MaKy", maKy);
                    Report.SetParameterValue("@Quy", Quy);
                    Report.SetParameterValue("@Nam", Nam);
                    Report.SetParameterValue("@Loai", Loai);
                    Report.SetParameterValue("@MaTaiKhoan", maTaiKhoan);
                    Report.SetParameterValue("@MaNguoiLap", NguoiLap);
                    Report.SetParameterValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    Report.SetParameterValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                }
                else
                {
                    Report = new Report.ReportTongHop.Report_BangCanDoiSoPhatSinh_DoiTuong_TheoHopDong();
                    command.CommandText = "spd_BangCanDoiSoPhatSinh_DoiTuong_TheoHopDong";
                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@Quy", Quy);
                    command.Parameters.AddWithValue("@Nam", Nam);
                    command.Parameters.AddWithValue("@Loai", Loai);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Parameters.AddWithValue("@MaNguoiLap", NguoiLap);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_BangCanDoiSoPhatSinh_DoiTuong_TheoHopDong;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    command2.CommandText = "report_SoChiTietTaiKhoan_SoHieu";
                    command2.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command2.Parameters.AddWithValue("@MaKy", maKy);
                    command2.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    adapter.SelectCommand = command2;
                    adapter.Fill(table2);
                    table2.TableName = "report_SoChiTietTaiKhoan_SoHieu;1";

                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table2);
                    dataSet.Tables.Add(table4);

                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                    Report.SetParameterValue("@TuNgay", ngayBatDau);
                    Report.SetParameterValue("@DenNgay", ngayKetThuc);
                    Report.SetParameterValue("@MaKy", maKy);
                    Report.SetParameterValue("@Quy", Quy);
                    Report.SetParameterValue("@Nam", Nam);
                    Report.SetParameterValue("@Loai", Loai);
                    Report.SetParameterValue("@MaTaiKhoan", maTaiKhoan);
                    Report.SetParameterValue("@MaNguoiLap", NguoiLap);
                    Report.SetParameterValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    Report.SetParameterValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    // Report.SetParameterValue("@TenBoPhan", _BoPhan.TenBoPhan);
                }
                //Report.SetParameterValue("@Thang", ngayBatDau.Month);
            }
            #endregion

            #region BangCanDoiTaiKhoan
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiTaiKhoan")
            {
                Report = new Report.ReportTongHop.BangCanDoiTaiKhoan();
                command.CommandText = "spd_BangCanDoiTaiKhoan";

                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@MaKy", maKy);
                command.Parameters.AddWithValue("@Loai", 1);
                command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BangCanDoiTaiKhoan;1";

                command2.CommandText = "spd_report_ReportHeader";
                command2.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                adapter.SelectCommand = command2;
                adapter.Fill(table2);
                table2.TableName = "spd_REPORT_ReportHeader;1";

                command3.CommandText = "spd_LayNguoiKyTenCongNo";
                command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                adapter.SelectCommand = command3;
                adapter.Fill(table3);
                table3.TableName = "spd_LayNguoiKyTenCongNo;1";
                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table2);
                dataSet.Tables.Add(table3);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@Thang", ngayBatDau.Month);

            }
            #endregion

            #region Bảng Cân Đối Kế Toán
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiKeToan")
            {
                Report = new Report.ReportTongHop.BangCanDoiKeToan();
                command.CommandText = "spd_Report_BangCanDoiKeToan";

                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@MaKy", maKy);
                command.Parameters.AddWithValue("@Quy", Quy);
                command.Parameters.AddWithValue("@Nam", Nam);
                command.Parameters.AddWithValue("@Loai", Loai);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_Report_BangCanDoiKeToan;1";

                command1.CommandText = "spd_report_ReportHeader";
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                command2.CommandText = "spd_report_ChiTieuNgoaiBangCanDoi";
                command2.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command2.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command2.Parameters.AddWithValue("@MaKy", maKy);
                command2.Parameters.AddWithValue("@Quy", Quy);
                command2.Parameters.AddWithValue("@Nam", Nam);
                command2.Parameters.AddWithValue("@Loai", Loai);

                adapter.SelectCommand = command2;
                adapter.Fill(table2);
                table2.TableName = "spd_report_ChiTieuNgoaiBangCanDoi;1";

                command3.CommandText = "spd_LayNguoiKyTenCongNo";
                command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                adapter.SelectCommand = command3;
                adapter.Fill(table3);
                table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table2);
                dataSet.Tables.Add(table3);

                Report.SetDataSource(dataSet);
                Report.SetParameterValue("@TuNgay", ngayBatDau);
                Report.SetParameterValue("@DenNgay", ngayKetThuc);
                Report.SetParameterValue("@MaKy", maKy);
                Report.SetParameterValue("@Quy", Quy);
                Report.SetParameterValue("@Nam", Nam);
                Report.SetParameterValue("@Loai", Loai);
                Report.SetParameterValue("@TieuDe", TieuDe);
            }
            #endregion

            #region ChungTuGhiSo
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "ChungTuGhiSo")
            {
                Report = new Report.ReportTongHop.Report_ChungTuGhiSo();
                command.CommandText = "spd_ChungTuGhiSo";
                if (rdbt_TheoTungNgay.Checked == true)
                {
                    command.Parameters.AddWithValue("@TuNgay", Ngay);
                    command.Parameters.AddWithValue("@DenNgay", Ngay);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    TieuDe = "Ngày " + Ngay.Day.ToString() + " tháng " + Ngay.Month.ToString() + " năm " + Ngay.Year.ToString();
                }
                else
                {
                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    TieuDe = "Từ ngày " + ngayBatDau.ToShortDateString() + " đến ngày " + ngayKetThuc.ToShortDateString();
                }
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_ChungTuGhiSo;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);

                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@TieuDe", TieuDe);
            }
            #endregion

            #region BaoCaoKetQuaHoatDongKinhDoanh
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoKetQuaHoatDongKinhDoanh")
            {
                Report = new Report.ReportTongHop.Report_BaoCaoKetQuaHoatDongKinhDoanh();
                command.CommandText = "spd_report_BaoCaoketQuaHoatDongKinhDoanh";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@MaKy", maKy);
                command.Parameters.AddWithValue("@Quy", Quy);
                command.Parameters.AddWithValue("@Nam", Nam);
                command.Parameters.AddWithValue("@Loai", Loai);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_report_BaoCaoketQuaHoatDongKinhDoanh;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                command3.CommandText = "spd_LayNguoiKyTenCongNo";
                command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                adapter.SelectCommand = command3;
                adapter.Fill(table3);
                table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table3);
                Report.SetDataSource(dataSet);
                Report.SetParameterValue("@TieuDe", TieuDe);
                Report.SetParameterValue("@TuNgay", ngayBatDau);
                Report.SetParameterValue("@DenNgay", ngayKetThuc);
                Report.SetParameterValue("@MaKy", maKy);
                Report.SetParameterValue("@Quy", Quy);
                Report.SetParameterValue("@Nam", Nam);
                Report.SetParameterValue("@Loai", Loai);

                #region Reporting
                //command.CommandText = "spd_report_BaoCaoketQuaHoatDongKinhDoanh";
                //command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                //command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                //command.Parameters.AddWithValue("@MaKy", maKy);
                //command.Parameters.AddWithValue("@Quy", Quy);
                //command.Parameters.AddWithValue("@Nam", Nam);
                //command.Parameters.AddWithValue("@Loai", Loai);
                //adapter.SelectCommand = command;
                //adapter.Fill(table);
                //table.TableName = "spd_report_BaoCaoketQuaHoatDongKinhDoanh;1";

                //command1.CommandText = "spd_report_ReportHeader";
                //adapter.SelectCommand = command1;
                //command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                //adapter.Fill(table1);
                //table1.TableName = "spd_REPORT_ReportHeader;1";

                //command3.CommandText = "spd_LayNguoiKyTenCongNo";
                //command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                //adapter.SelectCommand = command3;
                //adapter.Fill(table3);
                //table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                //dataSet.Tables.Add(table);
                //dataSet.Tables.Add(table1);
                //dataSet.Tables.Add(table3);
                //frmXemIn f = new frmXemIn();

                ////int MaKy = (int)cmbKyLuong.Value;
                //Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;

                //rpt.ReportEmbeddedResource = "PSC_ERP.Report.ReportTongHop.rpt_BaoCaoThuChiHoatDong.rdlc";
                //rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_HTVDataSet_spd_report_BaoCaoketQuaHoatDongKinhDoanh", dataSet.Tables[0]));
                //rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_HTVDataSet_spd_REPORT_ReportHeader", dataSet.Tables[1]));
                //rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_HTVDataSet_spd_LayNguoiKyTenCongNo", dataSet.Tables[2]));

                //Microsoft.Reporting.WinForms.ReportParameter _TieuDe= null;
                //_TieuDe = new Microsoft.Reporting.WinForms.ReportParameter("TieuDe", TieuDe);
                //rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { _TieuDe});
                //f.SetNguoiKyTongHop((int)cmbKyTen.Value);
                //f.Show(this);
                //return;
                #endregion

                //Report.SetDataSource(dataSet);
                //Report.SetParameterValue("@TieuDe", TieuDe);
            }
            #endregion

            #region Báo Cáo Lưu Chuyển Tiền Tệ
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoLuuChuyenTienTe")
            {
                Report = new Report.ReportTongHop.Report_BaoCaoLuuChuyenTienTe();
                command.CommandText = "spd_report_BaoCaoLuuChuyenTienTe";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@MaKy", maKy);
                command.Parameters.AddWithValue("@Quy", Quy);
                command.Parameters.AddWithValue("@Nam", Nam);
                command.Parameters.AddWithValue("@Loai", Loai);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_report_BaoCaoLuuChuyenTienTe;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";


                command3.CommandText = "spd_LayNguoiKyTenCongNo";
                command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                adapter.SelectCommand = command3;
                adapter.Fill(table3);
                table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table3);

                Report.SetDataSource(dataSet);
                Report.SetParameterValue("@TieuDe", TieuDe);
            }
            #endregion

            #region Bao Cao Nguon
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoNguon")
            {
                //Report = new Report.ReportTongHop.Report_SoChiTietTaiKhoan();
                Report = new Report.CongNo.BaoCaoBangKeChiPhiHTV();
                command.CommandText = "spd_BaoCaoBangKeChiPhiTheoTaiKhoan";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@TaiKhoan", maTaiKhoan);
                command.Parameters.AddWithValue("@LoaiTK", loaiTaiKhoan);
                command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                command.Parameters.AddWithValue("@MaNguoiLap", NguoiLap);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoBangKeChiPhiTheoTaiKhoan;1";

                command1.CommandText = "LayTaiKhoanDoiTuong_SoHieu";
                command1.Parameters.AddWithValue("@TaiKhoan", maTaiKhoan);
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "LayTaiKhoanDoiTuong_SoHieu;1";

                command2.CommandText = "spd_report_ReportHeader";
                command2.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                adapter.SelectCommand = command2;
                adapter.Fill(table2);
                table2.TableName = "spd_REPORT_ReportHeader;1";

                command3.CommandText = "spd_LayNguoiKyTenCongNo";
                command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                adapter.SelectCommand = command3;
                adapter.Fill(table3);
                table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table2);
                dataSet.Tables.Add(table3);

                Report.SetDataSource(dataSet);
                Report.SetParameterValue("PTuNgay", ngayBatDau);
                Report.SetParameterValue("PDenNgay", ngayKetThuc);
                if (loaiTaiKhoan == 1)
                {
                    Report.SetParameterValue("LoaiTaiKhoan", "Nợ");
                    //Report.SetParameterValue("@LoaiTK", "Nợ");
                    Report.SetParameterValue("@LoaiTK", 1);

                }
                else
                {
                    Report.SetParameterValue("LoaiTaiKhoan", "Có");
                    //Report.SetParameterValue("@LoaiTK", "Có");
                    Report.SetParameterValue("@LoaiTK", 0);
                }
                Report.SetParameterValue("@TuNgay", ngayBatDau);
                Report.SetParameterValue("@DenNgay", ngayKetThuc);
                Report.SetParameterValue("@TaiKhoan", maTaiKhoan);
                Report.SetParameterValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                if (maPhongBanChuoi != "")
                {
                    tenbophan = string.Empty;
                    BoPhanList bplist = BoPhanList.GetBoPhan(maPhongBanChuoi);
                    foreach (BoPhan bp in bplist)
                    {
                        tenbophan += bp.TenBoPhan + ", ";
                    }
                    if (tenbophan != "")
                    {
                        tenbophan = tenbophan.Substring(0, tenbophan.Length - 2);
                    }


                    Report.SetParameterValue("_BoPhan", tenbophan);
                }
                else
                {
                    Report.SetParameterValue("_BoPhan", "Tất Cả");
                }
                string soHieuTk = string.Empty;
                string tentaikhoan = string.Empty;
                if (Convert.ToInt32(cbu_SoHieuTK.Value) != 0)
                {

                    HeThongTaiKhoan1List taikhoanlist = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List(maTaiKhoanChuoi);
                    foreach (HeThongTaiKhoan1 tk in taikhoanlist)
                    {
                        // tentaikhoan += tk.SoHieuTK + "(" + tk.TenTaiKhoan + ")" + " ,";
                        soHieuTk += tk.SoHieuTK + ", ";
                        tentaikhoan += tk.TenTaiKhoan + ", ";
                    }
                    if (tentaikhoan != "")
                    {
                        soHieuTk = soHieuTk.Substring(0, soHieuTk.Length - 2);
                        tentaikhoan = tentaikhoan.Substring(0, tentaikhoan.Length - 2);
                    }

                    //taikhoan = tentaikhoan;
                }
                else
                {
                    soHieuTk = " Tất Cả ";
                    tentaikhoan = " Tất Cả ";
                }
                Report.SetParameterValue("_SoHieu", soHieuTk);
                Report.SetParameterValue("_TenTaiKhoan", tentaikhoan);


            }
            #endregion

            #region Bao CaoChi Tiet Nguon
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "ChiTietNguon")
            {
                frmXemIn f = new frmXemIn();

                //int MaKy = (int)cmbKyLuong.Value;
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;

                rpt.ReportEmbeddedResource = "PSC_ERP.Report.ReportTongHop.BaoCaoTieuMuc.rdlc";
                rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_BaoCaoTieuMucList", ERP_Library.BaoCaoTieuMucList.GetBaoCaoTieuMucList(ngayBatDau, ngayKetThuc, ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString(), mamucngansach, maTaiKhoanChuoi, maTieuMucNganSach, NguoiLap)));


                f.SetParameter("TenBoPhan", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);

                if (ultraCombo_Nhom.Value != null)
                {
                    string tenmucngansach = string.Empty;
                    MucNganSachList mnslist = MucNganSachList.GetMucNganSachList(mamucngansach);
                    foreach (MucNganSach mns in mnslist)
                    {
                        tenmucngansach += mns.TenMucNganSach + "(" + mns.MaMucNganSachQL + ")" + " ,";
                    }
                    if (tenmucngansach != "")
                    {
                        tenmucngansach = tenmucngansach.Substring(0, tenmucngansach.Length - 1);
                    }
                    if (int.Parse(ultraCombo_Nhom.Value.ToString()) == 0 && mamucngansach == "")
                        f.SetParameter("TieuDeReport", "Mục Ngân Sách: Tất Cả ");
                    else
                        f.SetParameter("TieuDeReport", "Mục Ngân Sách  " + tenmucngansach);
                }

                else
                {
                    MessageBox.Show("Chưa chọn nguồn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string taikhoan = string.Empty;

                if (Convert.ToInt32(cbu_SoHieuTK.Value) != 0)
                {
                    taikhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(Convert.ToInt32(cbu_SoHieuTK.Value)).SoHieuTK.ToString() + " (" + HeThongTaiKhoan1.GetHeThongTaiKhoan1(Convert.ToInt32(cbu_SoHieuTK.Value)).TenTaiKhoan + ")";
                }
                else
                {
                    taikhoan = " Tất Cả ";
                }
                f.SetParameter("Ngay", "Từ Ngày " + ngayBatDau.ToShortDateString() + " Đến Ngày " + ngayKetThuc.ToShortDateString() + ", của Tài Khoản:  " + taikhoan.ToString());

                ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
                string ngay = DateTime.Today.ToString("'Tp.HCM, Ngày .... tháng .... năm 'yyyy");

                f.SetNguoiKyTongHop((int)cmbKyTen.Value);


                decimal _SoDuDau = ERP_Library.BaoCaoTieuMucList.GetBaoCaoTieuMucSoDuDau(ngayBatDau, ngayKetThuc, ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString(), mamucngansach, maTaiKhoanChuoi, maTieuMucNganSach, NguoiLap);
                decimal _LuyKe = ERP_Library.BaoCaoTieuMucList.GetBaoCaoTieuMucLuyKe(ngayBatDau, ngayKetThuc, ERP_Library.Security.CurrentUser.Info.MaBoPhan.ToString(), mamucngansach, maTaiKhoanChuoi, maTieuMucNganSach, NguoiLap);


                Microsoft.Reporting.WinForms.ReportParameter SoDuDau = null;
                SoDuDau = new Microsoft.Reporting.WinForms.ReportParameter("SoDuDau", _SoDuDau.ToString());

                Microsoft.Reporting.WinForms.ReportParameter LuyKe = null;
                LuyKe = new Microsoft.Reporting.WinForms.ReportParameter("LuyKe", _LuyKe.ToString());

                rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { SoDuDau, LuyKe });
                f.Show(this);
                return;
            }
            #endregion

            #region BaoCaoKetQuaHoatDongKinhDoanh
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoKetQuaHoatDongKinhDoanh2")
            {
                Report = new Report.ReportTongHop.Report_BaoCaoKetQuaHoatDongKinhDoanhNew();
                command.CommandText = "spd_report_BaoCaoketQuaHoatDongKinhDoanhNew";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@MaKy", maKy);
                command.Parameters.AddWithValue("@Quy", Quy);
                command.Parameters.AddWithValue("@Nam", Nam);
                command.Parameters.AddWithValue("@Loai", Loai);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_report_BaoCaoketQuaHoatDongKinhDoanhNew;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                command3.CommandText = "spd_LayNguoiKyTenCongNo";
                command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                adapter.SelectCommand = command3;
                adapter.Fill(table3);
                table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table3);
                Report.SetDataSource(dataSet);
                Report.SetParameterValue("@TieuDe", TieuDe);

                //Report.SetDataSource(dataSet);
                //Report.SetParameterValue("@TieuDe", TieuDe);
            }
            #endregion

            #region BaoCaoKetQuaHoatDongKinhDoanhChiTiet
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoKQHDKDChiTiet")
            {
                // Report = new Report.ReportTongHop.report_BaoCaoKetQuaHoatDongKinhDoanhChiTiet();
                try
                {
                    Report = new Report.ReportTongHop.report_BaoCaoKQHDKinhDoanhChiTiet();
                    command.CommandText = "spd_report_BaoCaoketQuaHoatDongKinhDoanhChiTiet";
                    command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@Quy", Quy);
                    command.Parameters.AddWithValue("@Nam", Nam);
                    command.Parameters.AddWithValue("@Loai", Loai);
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "spd_report_BaoCaoketQuaHoatDongKinhDoanhChiTiet;1";

                    command1.CommandText = "spd_report_ReportHeader";
                    adapter.SelectCommand = command1;
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    adapter.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";

                    command3.CommandText = "spd_LayNguoiKyTenCongNo";
                    command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    adapter.SelectCommand = command3;
                    adapter.Fill(table3);
                    table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table3);
                    Report.SetDataSource(dataSet);
                    Report.SetParameterValue("@TieuDe", TieuDe);
                }
                catch
                {
                    throw;
                }

            }
            #endregion

            else
            {
                MessageBox.Show(this, "Vui Lòng Chọn Báo Cáo Trước Khi In", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
        #endregion 

        private string Report_LoadString(string reportname, int socot, double colwidth, double space)
        {
            string s = "";
            decimal l = 0;
            l = Convert.ToDecimal((space - (colwidth * socot)) / 2);
            if (l < 0) l = 0;
            System.IO.Stream m = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(reportname);
            byte[] a = new byte[m.Length];
            m.Read(a, 0, (int)m.Length);
            m.Close();
            s = System.Text.Encoding.UTF8.GetString(a);
            s = s.Replace(@"<Left>0.31746cm</Left>", @"<Left>" + l.ToString().Replace(",", ".") + @"in</Left>");
            return s;
        }

        private string Report_NguoiKyTenA3()
        {
            string s = "";
            System.IO.Stream m = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PSC_ERP.Report.rptNguoiKyTenA3.rdlc");
            byte[] a = new byte[m.Length];
            m.Read(a, 0, (int)m.Length);
            m.Close();
            s = System.Text.Encoding.UTF8.GetString(a);
            return s;
        }

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 
        
        #region cb_Ky_SelectedValueChanged
        private void cb_Ky_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_Ky.SelectedItem != null)
            {              
                ky = (Ky)(cb_Ky.SelectedItem);
                maKy = ky.MaKy;
                dtu_TuNgay.Value = ky.NgayBatDau;
                dtu_DenNgay.Value = ky.NgayKetThuc;
                ngayBatDau = ky.NgayBatDau;
                ngayKetThuc = ky.NgayKetThuc;
                TenKy = ky.TenKy;
                // maKy = Convert.ToInt32(cb_Ky.SelectedValue);
            }
        }
        #endregion 

        #region ultraCombo_SoHieuTK_ValueChanged
        private void ultraCombo_SoHieuTK_ValueChanged(object sender, EventArgs e)
        {
            if (cbu_SoHieuTK.ActiveRow != null)
            {
                HeThongTaiKhoan1 taiKhoan;
                taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1((int)cbu_SoHieuTK.Value);
                maTaiKhoan = taiKhoan.MaTaiKhoan;

                if (cbu_SoHieuTK.ActiveRow != null)
                {
                    maTaiKhoanChuoi = string.Empty;
                    if (Convert.ToInt32(cbu_SoHieuTK.ActiveRow.Cells["MaTaiKhoan"].Value) != 0)
                    {
                        maTaiKhoanChuoi = cbu_SoHieuTK.ActiveRow.Cells["MaTaiKhoan"].Value.ToString();
                    }
                    else
                    {
                        maTaiKhoanChuoi = "";
                    }

                }

            }
        }
        #endregion 

        #region ultraCombo_SoHieuTK_InitializeLayout
        private void ultraCombo_SoHieuTK_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_SoHieuTK.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu Tài Khoản";
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 70;

            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 250;
            
            this.cbu_SoHieuTK.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_SoHieuTK.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
          
        }
        #endregion 

        #region ultraTree_DSBaoCao_AfterSelect
        private void ultraTree_DSBaoCao_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            if (ultraTree_DSBaoCao.ActiveNode.Key == "SoChiTietTaiKhoan" || ultraTree_DSBaoCao.ActiveNode.Key == "SoCai" || ultraTree_DSBaoCao.ActiveNode.Key == "SoChiTietTaiKhoanTongHopTheoCT")
            {
                groupBox_DieuKienKhac.Enabled = true;
                rbt_Ky.Enabled = true;
                cb_Ky.Enabled = true;
                label1.Enabled = true;
                dtu_TuNgay.Enabled = true;
                lb_Den.Enabled = true;
                dtu_DenNgay.Enabled = true;

                rbt_TuNgay.Enabled = true;
                dtu_NgayBatDau.Enabled = true;
                lb_DenNgay.Enabled = true;
                dtu_NgayKetThuc.Enabled = true;

                rbt_Nam.Enabled = false;
                cb_Nam.Enabled = false;
                rbt_Quy.Enabled = false;
                cbu_Quy.Enabled = false;

                rdbt_TheoTungNgay.Enabled = true;
                dtu_TungNgay.Enabled = true;
                toolStripButton_CapNhat.Visible = false;
                toolStripSeparator1.Visible = false;

            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "ChungTuGhiSo" )
            {
                groupBox_DieuKienKhac.Enabled = true;
                rbt_Ky.Enabled = true;
                cb_Ky.Enabled = true;
                label1.Enabled = true;
                dtu_TuNgay.Enabled = true;
                lb_Den.Enabled = true;
                dtu_DenNgay.Enabled = true;

                rbt_TuNgay.Enabled = false;
                dtu_NgayBatDau.Enabled = false;
                lb_DenNgay.Enabled = false;
                dtu_NgayKetThuc.Enabled = false;

                rbt_Nam.Enabled = false;
                cb_Nam.Enabled = false;
                rbt_Quy.Enabled = false;
                cbu_Quy.Enabled = false;

                rdbt_TheoTungNgay.Enabled = true;
                dtu_TungNgay.Enabled = true;
                toolStripButton_CapNhat.Visible = false;
                toolStripSeparator1.Visible = false;
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "SoNhatKyChung" )
            {
                groupBox_DieuKienKhac.Enabled = false;
                rbt_Ky.Enabled = false;
                cb_Ky.Enabled = false;
                label1.Enabled = false;
                dtu_TuNgay.Enabled = false;
                lb_Den.Enabled = false;
                dtu_DenNgay.Enabled = false;
                rbt_TuNgay.Enabled = true;
                dtu_NgayBatDau.Enabled = true;
                lb_DenNgay.Enabled = true;
                dtu_NgayKetThuc.Enabled = true;

                rbt_Nam.Enabled = false;
                cb_Nam.Enabled = false;
                rbt_Quy.Enabled = false;
                cbu_Quy.Enabled = false;

                rdbt_TheoTungNgay.Enabled = true;
                dtu_TungNgay.Enabled = true;
                toolStripButton_CapNhat.Visible = false;
                toolStripSeparator1.Visible = false;
            }

            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiSoPhatSinhCapMot" || ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiSoPhatSinhCapHai" || ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiSoPhatSinhCapBa" || ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiTaiKhoan" || ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiKeToan" || ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoLuuChuyenTienTe" || ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiSoPhatSinhCapBaLuyKe" || ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiTaiKhoanCapHaiLuyKe" || ultraTree_DSBaoCao.ActiveNode.Key == "BangCanDoiTaiKhoanCapMotLuyKe")
            {
                groupBox_DieuKienKhac.Enabled = false;
                rbt_Ky.Enabled = true;
                cb_Ky.Enabled = true;
                label1.Enabled = true;
                dtu_TuNgay.Enabled = true;
                lb_Den.Enabled = true;
                dtu_DenNgay.Enabled = true;

                rbt_TuNgay.Enabled = true;
                dtu_NgayBatDau.Enabled = true;
                lb_DenNgay.Enabled = true;
                dtu_NgayKetThuc.Enabled = true;

                rdbt_TheoTungNgay.Enabled = true;
                dtu_TungNgay.Enabled = true;

                rbt_Nam.Enabled = true;
                cb_Nam.Enabled = true;
                rbt_Quy.Enabled = true;
                cbu_Quy.Enabled = true;
                toolStripButton_CapNhat.Visible = false;
                toolStripSeparator1.Visible = false;
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoKetQuaHoatDongKinhDoanh" || ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoKetQuaHoatDongKinhDoanh2" || ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoKQHDKDChiTiet")
            {
                groupBox_DieuKienKhac.Enabled = false;
                rbt_Ky.Enabled = false;
                cb_Ky.Enabled = false;
                label1.Enabled = false;
                dtu_TuNgay.Enabled = false;
                lb_Den.Enabled = false;
                dtu_DenNgay.Enabled = false;

                rbt_TuNgay.Enabled = true;
                dtu_NgayBatDau.Enabled = true;
                lb_DenNgay.Enabled = true;
                dtu_NgayKetThuc.Enabled = true;

                rdbt_TheoTungNgay.Enabled = false;
                dtu_TungNgay.Enabled = false;

                rbt_Nam.Enabled = true;
                cb_Nam.Enabled = true;
                rbt_Quy.Enabled = true;
                cbu_Quy.Enabled = true;
                toolStripButton_CapNhat.Visible = true;
                toolStripSeparator1.Visible = true;
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangTongHopTheoDoiDoiTuong")
            {
                groupBox_DieuKienKhac.Enabled = true;
                rbt_Ky.Enabled = true;
                cb_Ky.Enabled = true;
                label1.Enabled = true;
                dtu_TuNgay.Enabled = true;
                lb_Den.Enabled = true;
                dtu_DenNgay.Enabled = true;

                rbt_TuNgay.Enabled = true;
                dtu_NgayBatDau.Enabled = true;
                lb_DenNgay.Enabled = true;
                dtu_NgayKetThuc.Enabled = true;

                rdbt_TheoTungNgay.Enabled = true;
                dtu_TungNgay.Enabled = true;

                rbt_Nam.Enabled = true;
                cb_Nam.Enabled = true;
                rbt_Quy.Enabled = true;
                cbu_Quy.Enabled = true;
                toolStripButton_CapNhat.Visible = false;
                toolStripSeparator1.Visible = false;
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoNguon")
            {
                groupBox_DieuKienKhac.Enabled = true;
                rbt_Ky.Enabled = false;
                cb_Ky.Enabled = false;
                label1.Enabled = false;
                dtu_TuNgay.Enabled = false;
                lb_Den.Enabled = false;
                dtu_DenNgay.Enabled = false;


                rbt_Nam.Enabled = false;
                cb_Nam.Enabled = false;
                rbt_Quy.Enabled = false;
                cbu_Quy.Enabled = false;

                rdbt_TheoTungNgay.Enabled = true;
                dtu_TungNgay.Enabled = true;
                rbt_TuNgay.Enabled = true;
                dtu_NgayBatDau.Enabled = true;
                lb_DenNgay.Enabled = true;
                dtu_NgayKetThuc.Enabled = true;
                ultraComboEditor1_ValueChanged(sender, e);
                dtu_NgayBatDau_ValueChanged(sender, e);
                dtu_NgayKetThuc_ValueChanged(sender, e);
                toolStripButton_CapNhat.Visible = false;
                toolStripSeparator1.Visible = false;
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "ChiTietNguon")
            {
                groupBox_DieuKienKhac.Enabled = true;
                rbt_Ky.Enabled = true;
                cb_Ky.Enabled = true;
                label1.Enabled = true;
                dtu_TuNgay.Enabled = true;
                lb_Den.Enabled = true;
                dtu_DenNgay.Enabled = true;


                rbt_Nam.Enabled = true;
                cb_Nam.Enabled = true;
                rbt_Quy.Enabled = true;
                cbu_Quy.Enabled = true;

                rdbt_TheoTungNgay.Enabled = true;
                dtu_TungNgay.Enabled = true;
                rbt_TuNgay.Enabled = true;
                dtu_NgayBatDau.Enabled = true;
                lb_DenNgay.Enabled = true;
                dtu_NgayKetThuc.Enabled = true;
                ultraComboEditor1_ValueChanged(sender, e);
                dtu_NgayBatDau_ValueChanged(sender, e);
                dtu_NgayKetThuc_ValueChanged(sender, e);
                toolStripButton_CapNhat.Visible = false;
                toolStripSeparator1.Visible = false;
            }
            
        }
        #endregion 

        private void dtu_TuNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtu_NgayBatDau_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void ultraComboEditor1_ValueChanged(object sender, EventArgs e)
        {
            if (ultraComboEditor1.SelectedItem != null)
            {
                loaiTaiKhoan = Convert.ToByte(ultraComboEditor1.SelectedItem.DataValue) ; 

            }
        }

        private void dtu_NgayKetThuc_ValueChanged(object sender, EventArgs e)
        {
            if (dtu_NgayKetThuc.Value != null)
            {
                //ngayBatDau = Convert.ToDateTime(dtu_NgayBatDau.Value).Date;
                ngayKetThuc = Convert.ToDateTime(dtu_NgayKetThuc.Value).Date;

            }
        }

        private void dtu_NgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            if (dtu_NgayBatDau.Value != null)
            {
                ngayBatDau = Convert.ToDateTime(dtu_NgayBatDau.Value).Date;
                // ngayKetThuc = Convert.ToDateTime(dtu_NgayKetThuc.Value).Date;

            }
        }

        private void ultraCombo_Nhom_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            
            FilterCombo a = new FilterCombo(ultraCombo_Nhom, "MaMucNganSachQL");
            foreach (UltraGridColumn col in this.ultraCombo_Nhom.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            ultraCombo_Nhom.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Hidden = false;
            ultraCombo_Nhom.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.Caption = "Mã Mục NS";
            ultraCombo_Nhom.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.VisiblePosition = 0;
            ultraCombo_Nhom.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Width = 80;

            ultraCombo_Nhom.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Hidden = false;
            ultraCombo_Nhom.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.Caption = "Tên Mục";
            ultraCombo_Nhom.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.VisiblePosition = 1;
            ultraCombo_Nhom.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Width = 250;

          
        }

        #region cbu_DoiTuong_InitializeLayout
        private void cbu_DoiTuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            
            
            foreach (UltraGridColumn col in this.cbu_DoiTuong.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            cbu_DoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Hidden = false;
            cbu_DoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.Caption = "Mã Số";
            cbu_DoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.VisiblePosition = 0;

            cbu_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Hidden = false;
            cbu_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "Họ Tên";
            cbu_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 1;
            cbu_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Width = 500;

            this.cbu_DoiTuong.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_DoiTuong.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            FilterCombo a = new FilterCombo(cbu_DoiTuong, "TenDoiTuong");
        }
        #endregion 

        private void cbu_DoiTuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbu_DoiTuong.ActiveRow != null)
            {
                if (cbu_DoiTuong.Value != null && ((long)cbu_DoiTuong.Value) != 0)
                    _DoiTuong = DoiTuongAll.GetDoiTuongAll((long)(cbu_DoiTuong.Value));
                if (((long)cbu_DoiTuong.Value) == 0)
                    _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);

                _hopDongList = HopDongMuaBanList.GetHopDongMuaBanList_TheoDoiTac(_DoiTuong.MaDoiTuong);
                _hopDongList.Insert(0, HopDongMuaBan.NewHopDongMuaBan(0, "Không chọn"));
                cmb_HopDong.DataSource = _hopDongList;
            }
        }

        private void txt_ChonMucNganSach_Click(object sender, EventArgs e)
        {
            mamucngansach = string.Empty;
            UserInterface.KeToanTongHop.frmDanhSachMuc _frmMuc = new PSC_ERP.UserInterface.KeToanTongHop.frmDanhSachMuc();
            if (_frmMuc.ShowDialog(this) != DialogResult.OK)
            {
                mamucngansach = _frmMuc.MaMuc;
                lb_MucNganSach.Text = _frmMuc.MaMucQL;
            }
        }

        private void ultraCombo_Nhom_ValueChanged(object sender, EventArgs e)
        {
            //if (ultraCombo_Nhom.ActiveRow != null)
            //{
            //    mamucngansach = string.Empty;
            //    if (Convert.ToInt32(ultraCombo_Nhom.ActiveRow.Cells["MaMucNganSach"].Value) != 0)
            //    {
            //        mamucngansach = ultraCombo_Nhom.ActiveRow.Cells["MaMucNganSach"].Value.ToString();
            //    }
            //    else
            //    {
            //        mamucngansach = "";
            //    }

            //}

            if (ultraCombo_Nhom.ActiveRow != null)
            {
                mamucngansach = string.Empty;

                MucNganSach mns;
                if ((int)ultraCombo_Nhom.Value == 0)
                {
                    lb_MucNganSach.Text = "Tất Cả";
                }
                else
                {
                    mns = MucNganSach.GetMucNganSach((int)ultraCombo_Nhom.Value);
                    lb_MucNganSach.Text = mns.MaMucNganSachQL;
                }


                if (Convert.ToInt32(ultraCombo_Nhom.ActiveRow.Cells["MaMucNganSach"].Value) != 0)
                {
                    mamucngansach = ultraCombo_Nhom.ActiveRow.Cells["MaMucNganSach"].Value.ToString();
                }
                else
                {
                    mamucngansach = "";
                }

                _TieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList(Convert.ToInt32(ultraCombo_Nhom.ActiveRow.Cells["MaMucNganSach"].Value));
                TieuMucNganSach tmns = TieuMucNganSach.NewTieuMucNganSach("Tất Cả", "Tất Cả");
                _TieuMucNganSachList.Insert(0, tmns);
                TieuMucNSList_bindingSource.DataSource = _TieuMucNganSachList;
            }
        }

        private void ultraCombo1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraCombo1.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            ultraCombo1.DisplayLayout.Bands[0].Columns["TenDangNhap"].Hidden = false;
            ultraCombo1.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.Caption = "Người Lập";
            ultraCombo1.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.VisiblePosition = 0;
            ultraCombo1.DisplayLayout.Bands[0].Columns["TenDangNhap"].Width = ultraCombo1.Width;
          
            this.ultraCombo1.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraCombo1.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
        }

        private void ultraCombo1_ValueChanged(object sender, EventArgs e)
        {
            if (ultraCombo1.ActiveRow != null)
            {
                NguoiLap = Convert.ToInt32(ultraCombo1.ActiveRow.Cells["UserID"].Value);
            }
        }

        #region toolStripButton_CapNhat_Click
        private void toolStripButton_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                command.CommandTimeout = 0;

                command.CommandText = "spd_CapNhat_BaoCaoketQuaHoatDongKinhDoanh";
                command.Parameters.AddWithValue("@Quy", Quy);
                command.Connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            catch 
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #endregion 

        private void ultraCombo_TieuMuc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraCombo_TieuMuc.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.Hidden = true;
            }
            ultraCombo_TieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            ultraCombo_TieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Tiểu Mục";
            ultraCombo_TieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            ultraCombo_TieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Hidden = false;
            ultraCombo_TieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.Caption = "Tên Tiểu Mục";
            ultraCombo_TieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.VisiblePosition = 1;
            ultraCombo_TieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Width = 500;

            this.ultraCombo_TieuMuc.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraCombo_TieuMuc.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
        }

        private void bt_ChonTieuMuc_Click(object sender, EventArgs e)
        {
            maTieuMucNganSach = string.Empty;
            frmTieuMucNganSach _frmTieuMuc = new frmTieuMucNganSach(Convert.ToInt32(ultraCombo_Nhom.ActiveRow.Cells["MaMucNganSach"].Value));
            if (_frmTieuMuc.ShowDialog(this) != DialogResult.OK)
            {
                maTieuMucNganSach = _frmTieuMuc.maTieuMuc;
                lb_TieuMuc.Text = _frmTieuMuc.maTieuMucQL;
            }
        }

        private void ultraCombo_TieuMuc_ValueChanged(object sender, EventArgs e)
        {
            maTieuMucNganSach = "";
            if (ultraCombo_TieuMuc.ActiveRow != null)
            {
                TieuMucNganSach tmns;
                if ((int)ultraCombo_TieuMuc.Value == 0)
                {
                    lb_TieuMuc.Text = "Tất Cả";
                }
                else
                {
                    tmns = TieuMucNganSach.GetTieuMucNganSach((int)ultraCombo_TieuMuc.Value);
                    lb_TieuMuc.Text = tmns.MaQuanLy;
                }

                if (Convert.ToInt32(ultraCombo_TieuMuc.ActiveRow.Cells["MaTieuMuc"].Value) != 0)
                {
                    maTieuMucNganSach = ultraCombo_TieuMuc.ActiveRow.Cells["MaTieuMuc"].Value.ToString();
                }
                else
                {
                    maTieuMucNganSach = "";
                }

            }
        }

        private void rbt_TuNgay_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbTaiKhoan.SelectedRow != null)
            {
                txtNganHang.Text = ((ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild)cmbTaiKhoan.SelectedRow.ListObject).TenNganHang;
            }
            else
                txtNganHang.Text = "";
        }

        private void cbu_SoHieuTK_Leave(object sender, EventArgs e)
        {
            if (cbu_SoHieuTK.ActiveRow != null)
            {                                                                                                                     
                // maKy = Convert.ToInt32(cb_Ky.SelectedValue);
                DoiTuongAll _doiTuongThuChi = DoiTuongAll.NewDoiTuongAll("Tất Cả");
                _DoiTuongThuChiList = DoiTuongAllList.GetDoiTuongAllListByMaTaiKhoan(maTaiKhoan);
                _DoiTuongThuChiList.Insert(0, _doiTuongThuChi);
                doiTuongAllListBindingSource.DataSource = _DoiTuongThuChiList;

            }
        }

        private void cbu_SoHieuTK_RowSelected(object sender, RowSelectedEventArgs e)
        {

        }

        private void heThongTaiKhoan1ListBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void cmb_HopDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmb_HopDong.DisplayLayout.Bands[0],
                new string[5] { "SoHopDong", "TenHopDong", "TenDoiTac", "NgayLap", "NgayHetHan" },
                new string[5] { "Số hợp đồng", "Tên hợp đồng", "Tên đối tác", "Ngày lập", "Ngày hết hạn" },
                new int[5] { 100, 150, 150, 100, 100 },
                new Control[5] { null, null, null, null, null },
                new KieuDuLieu[5] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Ngay },
                new bool[5] { false, false, false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_HopDong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            FilterCombo filter = new FilterCombo(cmb_HopDong, "SoHopDong");
        }

        private void cmb_HopDong_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_HopDong.ActiveRow != null)
            {
                _maHopDong = Convert.ToInt32(cmb_HopDong.Value);
            }
        }
    }
}
