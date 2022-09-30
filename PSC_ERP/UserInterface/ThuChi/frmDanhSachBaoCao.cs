
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;
using ERP_Library;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Reporting.WinForms;

//long

namespace PSC_ERP
{//
    public partial class frmDanhSachBaoCao : Form
    {
        #region Properties
        HeThongTaiKhoan1List _HeThongTaiKhoan1ListNo;
        DoiTuongAllList _DoiTuongAllList;
       
        int maTaiKhoan = 0;
        int maChuongTrinh = 0;
        int maCongViec = 0;
        int maLoaiChungTu = 0;
        long maChungTu = 0;
        int maSoQuy = 0;
        Util _Util = new Util();
      
        long MaKhachHang = 0;
        int MaTKDoiTuong = 0;
        string ChuoiDoiTuong = "";
        int loaiChiPhi = 0;
        ChungTuRutGonList _chungTuList;
        ChuongTrinhList _chuongTrinhList;
        int _noCoTK = -1;//1: Nợ; 2: Có; -1: Tất cả
        string MaMucString = string.Empty;
        string MaTieuMucString = string.Empty;
        string mamucngansach = string.Empty;
        string maTieuMucNganSach = string.Empty;
        TieuMucNganSachList _TieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        MucNganSachList _MucNganSachList = MucNganSachList.NewMucNganSachList();
        ERP_Library.Security.UserList _UserList;
        #endregion

        #region Events
        public frmDanhSachBaoCao()
        {
            InitializeComponent();
            this.bindingSource2_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.bindingSource1_ChungTu.DataSource = typeof(ChungTuRutGonList);
            this.KhachHang_BindingSource.DataSource = typeof(DoiTuongAllList);
            this.NoTaiKhoan_BindingSource.DataSource = typeof(HeThongTaiKhoan1List);
            this.bindingSource1_DoiTuongThuChi.DataSource = typeof(DoiTuongThuChiList);
            this.bdSoQuy.DataSource = typeof(SoQuyList);
            LayDuLieu();

        }

        private void LayDuLieu()
        {
            SoQuyList _soQuyList = SoQuyList.GetSoQuyList();
            SoQuy item = SoQuy.NewSoQuy("Tất Cả");
            _soQuyList.Insert(0, item);
            bdSoQuy.DataSource = _soQuyList;
            //chuong trinh
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("Tất Cả");
            _chuongTrinhList.Insert(0, itemChuongTrinh);
            this.bindingSource2_ChuongTrinh.DataSource = _chuongTrinhList;

            //_chungTuList = ChungTuRutGonList.GetChungTuRutGonList();
            //ChungTuRutGon ct = ChungTuRutGon.NewChungTuRutGon("Tất Cả");
            //_chungTuList.Insert(0, ct);
            //this.bindingSource1_ChungTu.DataSource = _chungTuList;
            _DoiTuongAllList = DoiTuongAllList.GetDoiTuongAllList();

            KhachHang_BindingSource.DataSource = _DoiTuongAllList;

            _HeThongTaiKhoan1ListNo = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
            HeThongTaiKhoan1 tk = HeThongTaiKhoan1.NewHeThongTaiKhoan1("Tất Cả");
            _HeThongTaiKhoan1ListNo.Insert(0, tk);
            NoTaiKhoan_BindingSource.DataSource = _HeThongTaiKhoan1ListNo;
            cmbu_DSTaiKhoan.Value = GetMaTaiKhoan("1111");

            DoiTuongThuChiList list = DoiTuongThuChiList.GetDoiTuongThuChiList(ERP_Library.Security.CurrentUser.Info.MaCongTy);
            DoiTuongThuChi itemAdd = DoiTuongThuChi.NewDoiTuongThuChi("Tất Cả");
            list.Insert(0, itemAdd);
            this.bindingSource1_DoiTuongThuChi.DataSource = list;

            _MucNganSachList = MucNganSachList.GetMucNganSachList();
            MucNganSach _MucNganSach = MucNganSach.NewMucNganSach("Tất Cả");
            _MucNganSachList.Insert(0, _MucNganSach);
            MucNganSach_BindingSource.DataSource = _MucNganSachList;

            _UserList = ERP_Library.Security.UserList.GetUserList(ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            ERP_Library.Security.UserItem user = ERP_Library.Security.UserItem.NewUserItem("Tất Cả");
            _UserList.Insert(0, user);
            NguoiLapListBindingSouce.DataSource = _UserList;
          
        }
        public int GetMaTaiKhoan(String soHieuTK)
        {
            foreach (HeThongTaiKhoan1 tk in _HeThongTaiKhoan1ListNo)
                if (tk.SoHieuTK == soHieuTK)
                    return tk.MaTaiKhoan;
            return 0;
        }

        #region ultr_XemTruocKhiIn_Click
        private void ultr_XemTruocKhiIn_Click(object sender, EventArgs e)
        {
            if (MaMucString == "")
                MaMucString = "0";
            if (MaTieuMucString == "")
                MaTieuMucString = "0";
            int Kieu = 0;

            if (_noCoTK == 1)//Nợ TK
            {
                Kieu = 1;
            }
            else if (_noCoTK == 2)//Có TK
            {
                Kieu = 2;
            }
            else
            {
                Kieu = 3;
            }
            DataSet _DataSet;
            ReportDocument Report;
            SqlCommand command;
            frmHienThiReport dlg;
            if (treeReport.SelectedNode == null)
            {
                MessageBox.Show(this, "Chưa chọn báo cáo để xem.", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                if (treeReport.SelectedNode.Name == "Node1") // thong ke tien quy theo ngay
                {
                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BaoCaoThuQuyTienMat_HoatDong();

                    command = new SqlCommand();
                    command.CommandTimeout = 180;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportThuQuyTienMat_HoatDong";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Parameters.AddWithValue("@MaHoatDong", maSoQuy);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportThuQuyTienMat_HoatDong;1";
                    _DataSet.Tables.Add(table);

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    _DataSet.Tables.Add(table1);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    if (maSoQuy != 0)
                    {
                        Report.SetParameterValue("_TenSoQuy", SoQuy.GetSoQuy(maSoQuy).TenSoQuy);
                    }
                    else
                    {
                        Report.SetParameterValue("_TenSoQuy", "Tất Cả");
                    }
                    
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }
                else if (treeReport.SelectedNode.Name == "Node2") //Kiểm tra tài khoản tạm ứng.
                {

                    _DataSet = new DataSet();
                    Report = new Report.CongNo.KiemTraTamUng();

                    command = new SqlCommand();
                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Report_KiemTraTamUngChungTu";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "Report_KiemTraTamUngChungTu;1";
                    _DataSet.Tables.Add(table);

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    _DataSet.Tables.Add(table1);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    Report.SetParameterValue("tenDonVi", ERP_Library.Security.CurrentUser.Info.TenBoPhan);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }


                else if (treeReport.SelectedNode.Name == "Node3") //Bảng Kê Chứng Từ - Chương Trình
                {

                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BangKeChungTu_ChuongTrinh();

                    command = new SqlCommand();
                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Report_ChungTuChuongTrinh";
                    command.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaDoiTuongThuChi", maCongViec);
                    command.Parameters.AddWithValue("@MaLoaiChungTu", maLoaiChungTu);
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Parameters.AddWithValue("@Kieu", Kieu);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "Report_ChungTuChuongTrinh;1";
                    _DataSet.Tables.Add(table);

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    _DataSet.Tables.Add(table1);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay.Value).Date);

                    Report.SetParameterValue("tenDonVi", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tenDoiTuongThuChi", cbCongViec.Text);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }

                else if (treeReport.SelectedNode.Name == "Node4")//Chi phí Sản Xuất Chương Trình
                {

                    _DataSet = new DataSet();
                    Report = new Report.ChiPhiSanXuat.BaoCaoChiPhiSanXuatChuongTrinh();

                    command = new SqlCommand();
                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Report_ChuongTrinhSanXuatChuongTrinh";
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaDoiTuongThuChi", maCongViec);
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaLoaiChiPhi", loaiChiPhi);
                    if (Convert.ToInt32(ultraCombo_NguoiLap.Value)==0)
                        command.Parameters.AddWithValue("@UserID",ERP_Library.Security.CurrentUser.Info.UserID);
                    else
                    command.Parameters.AddWithValue("@UserID", Convert.ToInt32(ultraCombo_NguoiLap.Value));
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Parameters.AddWithValue("@Kieu", Kieu);
                    command.Parameters.AddWithValue("@MaMuc", Convert.ToInt32(cbMucNganSach.ActiveRow.Cells["MaMucNganSach"].Value));
                    if (cbTieuMucNganSach.Value != null)
                    {
                        command.Parameters.AddWithValue("@TieuMuc", Convert.ToInt32(cbTieuMucNganSach.Value));
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@TieuMuc", 0);
                    }
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "Report_ChuongTrinhSanXuatChuongTrinh;1";
                    _DataSet.Tables.Add(table);

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    _DataSet.Tables.Add(table1);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    Report.SetParameterValue("tenDonVi", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tenDoiTuongThuChi", cbCongViec.Text);
                    Report.SetParameterValue("_tenChuongTrinh", cbChuongTrinh.Text);
                    Report.SetParameterValue("_tenTaiKhoan", cmbu_DSTaiKhoan.Text);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenDangNhap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }
                else if (treeReport.SelectedNode.Name == "Node5")
                {
                    InSoTheoDoiDaThuChi_Dev();
                    return;

                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BaoCaoTheoDoiThuChiTienMat();

                    command = new SqlCommand();
                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportQuyTaiKhoanTienMatDaThuChi";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportQuyTaiKhoanTienMatDaThuChi;1";
                    _DataSet.Tables.Add(table);

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    _DataSet.Tables.Add(table1);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }
                else if (treeReport.SelectedNode.Name == "Node6")
                {
                    InSoTheoDoiThuChiChuaHoanTat_Dev();
                    return;

                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BaoCaoKiemTraLapPhieuThuQuy();

                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportQuyTaiKhoanTienMatChuaHoanTat";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportQuyTaiKhoanTienMatChuaHoanTat;1";
                    _DataSet.Tables.Add(table);

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    _DataSet.Tables.Add(table1);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                }
                else if (treeReport.SelectedNode.Name == "TongHopCacQuy")
                {
                    _DataSet = new DataSet();
                    Report = new Report.CongNo.TongHopCacQuy();

                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportThuQuyTienMat_TongHop";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@MaTaiKhoan", Convert.ToInt32(cmbu_DSTaiKhoan.Value));

                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportThuQuyTienMat_TongHop;1";
                    _DataSet.Tables.Add(table);

                    Report.SetDataSource(_DataSet);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                }

                else if (treeReport.SelectedNode.Name == "Node7")
                {
                    InSoQuyTienMat_Dev();
                    return;

                    // co xu ly trang in theo ky lien ke 
                    int maky = getmaky(Convert.ToDateTime(dateTuNgay.Value).Month, Convert.ToDateTime(dateTuNgay.Value).Year);
                    if (maky == 0)
                    {
                        MessageBox.Show(this, "Chưa tạo kỳ kế toán trong thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BaoCaoThuQuyTienMat();

                    command = new SqlCommand();
                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportThuQuyTienMat";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportThuQuyTienMat;1";
                    _DataSet.Tables.Add(table);

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    _DataSet.Tables.Add(table1);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);

                    string _tentk = cmbu_DSTaiKhoan.ActiveRow.Cells["TenTaiKhoan"].Value.ToString();
                    Report.SetParameterValue("p_loaiquy", "Loại quỹ: " + _tentk);

                    string _thang = Convert.ToDateTime(dateDenNgay.Value).Date.Month.ToString() + "/" + Convert.ToDateTime(dateDenNgay.Value).Date.Year.ToString();
                    Report.SetParameterValue("p_thangnam", _thang);

                    // by Loc  set so tran Loai =1 bao cao theo so quy tien mat
                    int sotrangbd = 0, sorecordbd = 0;
                    Laysotrangbatdautrongky(maky, 1, ref sotrangbd, ref sorecordbd);

                    Report.SetParameterValue("_trangbd", sotrangbd);
                    Report.SetParameterValue("_recordbd", sorecordbd);



                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;

                    // by Loc  set so tran Loai =1 bao cao theo so quy tien mat
                    dlg.crytalView_HienThiReport.ShowLastPage();
                    int _sotrang = dlg.crytalView_HienThiReport.GetCurrentPageNumber();
                    int _sorecord = _DataSet.Tables["spd_ReportThuQuyTienMat;1"].Rows.Count;

                    Updatesotrangin(maky, _sotrang + sotrangbd, sotrangbd, 1, Report.Name, sorecordbd, _sorecord + sorecordbd);

                    //

                    dlg.Show();
                }


                else if (treeReport.SelectedNode.Name == "Node8")
                {
                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BaoCaoQuyChungMotTamLong();
                    DateTime dt = new DateTime(DateTime.Today.Year, 1, 1);
                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReportQuyChungMotTamLong";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@NgayDauNam", dt);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    command.Parameters.AddWithValue("@MaDoiTuongThuChi", maCongViec);

                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "ReportQuyChungMotTamLong;1";
                    _DataSet.Tables.Add(table);

                    Report.SetDataSource(_DataSet);
                    ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    Report.SetParameterValue("_NgayThangDauNam", Convert.ToDateTime(dt).Date);
                    Report.SetParameterValue("_tenCongViec", cbCongViec.Text);
                    Report.SetParameterValue("_keToanTruong", nguoiky.BptTen);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", nguoiky.TenTongGiamDoc);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }
                else if (treeReport.SelectedNode.Name == "Node9")
                {
                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BaoCaoThuQuyTienMatCongDoan();
                    DateTime dt = new DateTime(DateTime.Today.Year, 1, 1);
                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportQuyTaiKhoanTienMatCongDoan";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportQuyTaiKhoanTienMatCongDoan;1";
                    _DataSet.Tables.Add(table);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    Report.SetParameterValue("_tieuDeNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTieude);
                    Report.SetParameterValue("_tieuDeThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTieude);

                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTen);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTen);


                    Report.SetParameterValue("_tieuDeGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TieuDeTongGiamDoc);
                    Report.SetParameterValue("_tenGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TenTongGiamDoc);


                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }
                else if (treeReport.SelectedNode.Name == "Node10")
                {

                    // co xu ly trang in theo ky lien ke 
                    int maky = getmaky(Convert.ToDateTime(dateTuNgay.Value).Month, Convert.ToDateTime(dateTuNgay.Value).Year);
                    if (maky == 0)
                    {
                        MessageBox.Show(this, "Chưa tạo kỳ kế toán trong thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BaoCaoThuQuyTienMat_CongDoan();

                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportThuQuyTienMatCongDoan";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportThuQuyTienMatCongDoan;1";
                    _DataSet.Tables.Add(table);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    Report.SetParameterValue("_tieuDeNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTieude);
                    Report.SetParameterValue("_tieuDeThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTieude);

                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTen);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTen);


                    Report.SetParameterValue("_tieuDeGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TieuDeTongGiamDoc);
                    Report.SetParameterValue("_tenGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TenTongGiamDoc);



                    // by Loc  set so tran Loai =1 bao cao theo so quy tien mat
                    string _thang = Convert.ToDateTime(dateDenNgay.Value).Date.Month.ToString() + "/" + Convert.ToDateTime(dateDenNgay.Value).Date.Year.ToString();
                    Report.SetParameterValue("p_thangnam", _thang);

                    string _tentk = cmbu_DSTaiKhoan.ActiveRow.Cells["TenTaiKhoan"].Value.ToString();
                    Report.SetParameterValue("p_loaiquy", "Loại quỹ: " + _tentk);

                    int sotrangbd = 0, sorecordbd = 0;
                    Laysotrangbatdautrongky(maky, 2, ref sotrangbd, ref sorecordbd);

                    Report.SetParameterValue("_trangbd", sotrangbd);
                    Report.SetParameterValue("_recordbd", sorecordbd);
                    // 
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;

                    // by Loc  set so tran Loai =1 bao cao theo so quy tien mat
                    dlg.crytalView_HienThiReport.ShowLastPage();
                    int _sotrang = dlg.crytalView_HienThiReport.GetCurrentPageNumber();
                    int _sorecord = _DataSet.Tables["spd_ReportThuQuyTienMatCongDoan;1"].Rows.Count;

                    Updatesotrangin(maky, _sotrang + sotrangbd, sotrangbd, 2, Report.Name, sorecordbd, _sorecord + sorecordbd);

                    dlg.Show();
                }
                else if (treeReport.SelectedNode.Name == "Node11")
                {
                    _DataSet = new DataSet();
                    Report = new Report.CongNo.ThuChiNganSachCongDoan();

                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReportSoThuChiCongDoanCoSo";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "ReportSoThuChiCongDoanCoSo;1";
                    _DataSet.Tables.Add(table);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    Report.SetParameterValue("_tieuDeNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTieude);
                    Report.SetParameterValue("_tieuDeThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTieude);

                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTen);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTen);


                    Report.SetParameterValue("_tieuDeGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TieuDeTongGiamDoc);
                    Report.SetParameterValue("_tenGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TenTongGiamDoc);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }
                else if (treeReport.SelectedNode.Name == "NodeThuChi_SoQuy")
                {
                    #region Báo cáo quỹ theo tài khoản theo ngày

                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BaoCaoQuyTheoTaiKhoan();

                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportQuyTaiKhoanTienMat";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@TaiKhoan", int.Parse(cmbu_DSTaiKhoan.Value.ToString()));
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@MaKy", 0);
                    command.Parameters.AddWithValue("@MaSoQuy", maSoQuy);

                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.CommandTimeout = 0;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportQuyTaiKhoanTienMat;1";
                    _DataSet.Tables.Add(table);

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    _DataSet.Tables.Add(table1);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    if (maSoQuy == 0)
                        Report.SetParameterValue("_tenSoQuy", string.Empty);
                    else
                        Report.SetParameterValue("_tenSoQuy", "Tên sổ quỹ: " + cbSoQuy.Text);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                    #endregion
                }

                else if (treeReport.SelectedNode.Name == "DoSoQuyTienMat")
                {

                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BaoCaoThuQuyTienMatDoSoQuy();

                    command = new SqlCommand();
                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_DoSoQuy";
                    command.Parameters.AddWithValue("@Nam", Convert.ToDateTime(dateDenNgay.Value).Year);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_DoSoQuy;1";
                    _DataSet.Tables.Add(table);

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    _DataSet.Tables.Add(table1);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    string _tentk = cmbu_DSTaiKhoan.ActiveRow.Cells["TenTaiKhoan"].Value.ToString();
                    Report.SetParameterValue("p_loaiquy", "Loại quỹ: " + _tentk);



                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;


                    dlg.Show();
                }

            }
        }
        #endregion

        #region CheckedChanged
        private void radioButton_Ngay_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region ValueChanged
        private void ultraCombo_KhachHang_ValueChanged(object sender, EventArgs e)
        {
            MaKhachHang = Convert.ToInt64(cbKhachHang.Value);
        }
        #endregion

        #endregion

        private void cmbu_DSTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            FilterCombo filter = new FilterCombo(cmbu_DSTaiKhoan, "SoHieuTK");
        }

        private void frmDanhSachBaoCao_Load(object sender, EventArgs e)
        {
            EnableDisableControl(false);
            dateTuNgay.Value = DateTime.Today.Date;
            dateDenNgay.Value = DateTime.Today.Date;
        }

        private void btnKHTheoDoi_Click(object sender, EventArgs e)
        {
            MaTKDoiTuong = int.Parse(cmbu_DSTaiKhoan.Value.ToString());
            frmDSDoiTuongTaiKhoan frmDoiTuong = new frmDSDoiTuongTaiKhoan(MaTKDoiTuong, true);
            if (frmDoiTuong.ShowDialog(this) != DialogResult.OK)
            {
                ChuoiDoiTuong = frmDoiTuong.ChuoiDoiTuong;
            }
        }

        private void EnableDisableControl(bool enable)
        {
            if (enable == true)
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
                cmbu_DSTaiKhoan.Enabled = true;
                cbChungTu.Enabled = true;
                cbChuongTrinh.Enabled = true;
                cbCongViec.Enabled = true;
                cbLoaiChiPhi.Enabled = true;
                cbLoaiChungTu.Enabled = true;
                cbKhachHang.Enabled = true;
                rbCo.Enabled = true;
                rbNo.Enabled = true;
                rbTatCa.Enabled = true;
                cbMucNganSach.Enabled = true;
                cbTieuMucNganSach.Enabled = true;
                cbSoQuy.Enabled = true;
            }
            else
            {
                dateTuNgay.Enabled = false;
                dateDenNgay.Enabled = false;
                cmbu_DSTaiKhoan.Enabled = false;
                cbChungTu.Enabled = false;
                cbChuongTrinh.Enabled = false;
                cbCongViec.Enabled = false;
                cbLoaiChiPhi.Enabled = false;
                cbLoaiChungTu.Enabled = false;
                cbKhachHang.Enabled = false;
                rbCo.Enabled = false;
                rbNo.Enabled = false;
                rbTatCa.Enabled = false;
                cbMucNganSach.Enabled = false;
                cbTieuMucNganSach.Enabled = false;
                cbSoQuy.Enabled = false;
            }
        }

        private void treeReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            EnableDisableControl(false);
            if (treeReport.SelectedNode.Name == "Node1" || treeReport.SelectedNode.Name == "NodeThuChi_SoQuy"|| treeReport.SelectedNode.Name =="TongHopCacQuy")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
                cmbu_DSTaiKhoan.Enabled = true;
                rbCo.Enabled = true;
                rbNo.Enabled = true;
                rbTatCa.Enabled = true;
                cbSoQuy.Enabled = true;

            }
            else if (treeReport.SelectedNode.Name == "Node2")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;

            }
            else if (treeReport.SelectedNode.Name == "Node3")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
                cbChungTu.Enabled = true;
                cbChuongTrinh.Enabled = true;
                cbCongViec.Enabled = true;
                cbLoaiChungTu.Enabled = true;
                cmbu_DSTaiKhoan.Enabled = true;
                rbCo.Enabled = true;
                rbNo.Enabled = true;
                rbTatCa.Enabled = true;
             //   cbMucNganSach.Enabled = true;
             //   cbTieuMucNganSach.Enabled = true;

            }
            else if (treeReport.SelectedNode.Name == "Node4")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
                cbChungTu.Enabled = true;
                cbChuongTrinh.Enabled = true;
                cbCongViec.Enabled = true;
                cbLoaiChiPhi.Enabled = true;
                cbLoaiChungTu.Enabled = true;
                cmbu_DSTaiKhoan.Enabled = true;
                rbCo.Enabled = true;
                rbNo.Enabled = true;
                rbTatCa.Enabled = true;
                cbMucNganSach.Enabled = true;
                cbTieuMucNganSach.Enabled = true;
            }
            else if (treeReport.SelectedNode.Name == "Node5")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
               // cmbu_DSTaiKhoan.Enabled = true;

            }
            else if (treeReport.SelectedNode.Name == "Node6")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
               // cmbu_DSTaiKhoan.Enabled = true;

            }
            else if (treeReport.SelectedNode.Name == "Node7" || treeReport.SelectedNode.Name=="DoSoQuyTienMat")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
                 cmbu_DSTaiKhoan.Enabled = true;

            }
            else if (treeReport.SelectedNode.Name == "Node8")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
                cbCongViec.Enabled = true;
                // cmbu_DSTaiKhoan.Enabled = true;

            }
            else if (treeReport.SelectedNode.Name == "Node9")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
              

            }
            else if (treeReport.SelectedNode.Name == "Node10")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
                cmbu_DSTaiKhoan.Enabled = true;

            }
            else if (treeReport.SelectedNode.Name == "Node11")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
            }
        }

        private void cmbu_DSTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_DSTaiKhoan.ActiveRow != null)
            {
                maTaiKhoan = Convert.ToInt32(cmbu_DSTaiKhoan.ActiveRow.Cells["MataiKhoan"].Value);

                rbCo.Enabled = true;
                rbNo.Enabled = true;
                rbTatCa.Enabled = true;
            }
            else
            {
                maTaiKhoan = 0;
                rbCo.Enabled = false;
                rbNo.Enabled = false;
                rbTatCa.Enabled = false;
            }
        }

        private void ultraCombo_CongViec_ValueChanged(object sender, EventArgs e)
        {

            if (cbCongViec.ActiveRow != null)
                maCongViec = Convert.ToInt32(cbCongViec.ActiveRow.Cells["MaDoiTuongThuChi"].Value);
        }

        private void ultraCombo_ChuongTrinh_ValueChanged(object sender, EventArgs e)
        {
            if (cbChuongTrinh.ActiveRow != null)
                maChuongTrinh = Convert.ToInt32(cbChuongTrinh.ActiveRow.Cells["MaChuongTrinh"].Value);
        }

        private void cbChungTu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChungTu, "SoChungTu");
            foreach (UltraGridColumn col in this.cbChungTu.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                if (col.DataType == typeof(decimal))
                {
                    col.Format = "###,###,###,####,###";
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
            }
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
        }

        private void cbChungTu_ValueChanged(object sender, EventArgs e)
        {
            if (cbChungTu.ActiveRow != null)
                maChungTu = Convert.ToInt64(cbChungTu.ActiveRow.Cells["MaChungTu"].Value);
        }

        private void ultraCombo_KhachHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbKhachHang, "TenDoiTuong");
            foreach (UltraGridColumn col in this.cbKhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Hidden = false;
            cbKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "Tên Khách Hàng";
            cbKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 0;
            cbKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Width = 250;

            cbKhachHang.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            cbKhachHang.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            cbKhachHang.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 2;
            cbKhachHang.DisplayLayout.Bands[0].Columns["DiaChi"].Width = 250;

            cbKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Hidden = false;
            cbKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.Caption = "Mã Quản Lý";
            cbKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.VisiblePosition = 1;
            cbKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Width = 250;
        }

        private void ultraCombo_CongViec_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbCongViec, "TenDoiTuongThuChi");
            foreach (UltraGridColumn col in this.cbCongViec.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbCongViec.DisplayLayout.Bands[0].Columns["TenDoiTuongThuChi"].Hidden = false;
            cbCongViec.DisplayLayout.Bands[0].Columns["TenDoiTuongThuChi"].Header.Caption = "Tên Công Việc";
            cbCongViec.DisplayLayout.Bands[0].Columns["TenDoiTuongThuChi"].Header.VisiblePosition = 0;
            cbCongViec.DisplayLayout.Bands[0].Columns["TenDoiTuongThuChi"].Width = 250;
        }

        private void ultraCombo_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChuongTrinh, "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cbChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cbChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cbChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cbChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 250;
        }

        private void cbThanhToan_ValueChanged(object sender, EventArgs e)
        {
            if (cbLoaiChungTu.Value != null)
                maLoaiChungTu = Convert.ToInt32(cbLoaiChungTu.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbLoaiChiPhi_ValueChanged(object sender, EventArgs e)
        {
            if (cbLoaiChiPhi.Value != null)
                loaiChiPhi = Convert.ToInt32(cbLoaiChiPhi.Value);


        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNo.Checked == true)
                _noCoTK = 1;
        }

        private void rbCo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCo.Checked == true)
                _noCoTK = 2;
        }

        private void rbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTatCa.Checked == true)
                _noCoTK = -1;
        }

        private void ultraCombo_Nhom_ValueChanged(object sender, EventArgs e)
        {
            string maMucString = string.Empty;
            if (cbMucNganSach.ActiveRow != null)
            {
                TieuMucNganSach tmns = TieuMucNganSach.NewTieuMucNganSach("Tất Cả", "Tất Cả");
                for (int i = 0; i < cbMucNganSach.CheckedRows.Count; i++)
                {
                    string s = cbMucNganSach.CheckedRows[i].Cells["MaMucNganSach"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cbMucNganSach;
                        for (int j = 1; j < this.cbMucNganSach.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    maMucString += s + ",";
                }
                MaMucString = string.Empty;
                if (maMucString.Length > 0)
                {
                    MaMucString = maMucString.Substring(0, maMucString.Length - 1);
                }
                if (MaMucString.Length > 0 && MaMucString != "0")
                {
                    _TieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachListByNhieuMaMuc(MaMucString);
                    _TieuMucNganSachList.Insert(0, tmns);
                }
                else
                {
                    _TieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
                    _TieuMucNganSachList.Insert(0, tmns);
                }
                TieuMucNSList_bindingSource.DataSource = _TieuMucNganSachList;



            }

        }

        private void ultraCombo_Nhom_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            cbMucNganSach.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.CheckedItems;
            UltraGridColumn checkColumn = this.cbMucNganSach.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cbMucNganSach.CheckedListSettings.CheckStateMember = checkColumn.Key;

        }

        private void ultraCombo_TieuMuc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);

            foreach (UltraGridColumn col in this.cbTieuMucNganSach.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.Hidden = true;
            }          
            this.cbTieuMucNganSach.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbTieuMucNganSach.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;

        }
             
        private void ultraCombo_TieuMuc_ValueChanged(object sender, EventArgs e)
        {
            string maTieuMucString = string.Empty;
            if (cbTieuMucNganSach.ActiveRow != null)
            {

                for (int i = 0; i < cbTieuMucNganSach.CheckedRows.Count; i++)
                {
                    string s = cbTieuMucNganSach.CheckedRows[i].Cells["MaTieuMuc"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cbTieuMucNganSach;
                        for (int j = 1; j < this.cbTieuMucNganSach.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    maTieuMucString += s + ",";
                }
                MaTieuMucString = string.Empty;
                if (maTieuMucString.Length > 0)
                {
                    MaTieuMucString = maTieuMucString.Substring(0, maTieuMucString.Length - 1);
                }

            }
        }

        private void cmbu_DSTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(cmbu_DSTaiKhoan, "SoHieuTK");
            foreach (UltraGridColumn col in this.cmbu_DSTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cmbu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cmbu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cmbu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;
            cmbu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cmbu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cmbu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            cmbu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;
        }

        private void cbSoQuy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(cbSoQuy, "TenSoQuy");
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbSoQuy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbSoQuy.DisplayLayout.Bands[0].Columns["TenSoQuy"].Hidden = false;
            cbSoQuy.DisplayLayout.Bands[0].Columns["TenSoQuy"].Header.Caption = "Tên Sổ Quỹ";
            cbSoQuy.DisplayLayout.Bands[0].Columns["TenSoQuy"].Width = 250;
            cbSoQuy.DisplayLayout.Bands[0].Columns["TenSoQuy"].Header.VisiblePosition = 0;

        }

        private void cbSoQuy_ValueChanged(object sender, EventArgs e)
        {
            if (cbSoQuy.ActiveRow != null)
                maSoQuy = (int)cbSoQuy.Value;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        #region process by Loc
        private int getmaky(int thang, int nam)
        {
            int maky;
            using (SqlConnection cnn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cnn.Open();
                using (SqlCommand cm=cnn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_laykytheothangnam";
                    cm.Parameters.AddWithValue("@thang", thang);
                    cm.Parameters.AddWithValue("@nam", nam);
                    maky = (int)cm.ExecuteScalar();
                }
            }
            return maky;
        }
        private void Laysotrangbatdautrongky(int maky, int Loai, ref int sotrangbd, ref int sorecordbd)
        {

            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_laysotrangdautheokyvaloaibc";
                        cm.Parameters.AddWithValue("@maky", maky);
                        cm.Parameters.AddWithValue("@Loai", Loai);
                        cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                        sotrangbd = (int)cm.ExecuteScalar();
                    }
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_laysorecorddautheokyvaloaibc";
                        cm.Parameters.AddWithValue("@maky", maky);
                        cm.Parameters.AddWithValue("@Loai", Loai);
                        cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                        sorecordbd = (int)cm.ExecuteScalar();
                    }
                }
               
            }
          
        }
        private void Updatesotrangin(int maky, int sotrangdain, int sotrangdau, int Loai, string tenbc, int sorecordbd, int tongsorecord)
        {
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        // up date ky nay va ky ke tiep 
                        cm.CommandText = "spd_updatesotrangvaoky";
                        cm.Parameters.AddWithValue("@maky", maky);
                        cm.Parameters.AddWithValue("@sotrangdau", sotrangdau);
                        cm.Parameters.AddWithValue("@tongsotrang", sotrangdain);
                        cm.Parameters.AddWithValue("@SoRecordBd", sorecordbd);
                        cm.Parameters.AddWithValue("@tongsorecord", tongsorecord);
                        cm.Parameters.AddWithValue("@Loai", Loai);
                        cm.Parameters.AddWithValue("@tenbc", tenbc);
                        cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion

        private void ultraCombo_NguoiLap_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraCombo_NguoiLap.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            ultraCombo_NguoiLap.DisplayLayout.Bands[0].Columns["TenDangNhap"].Hidden = false;
            ultraCombo_NguoiLap.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.Caption = "Người Lập";
            ultraCombo_NguoiLap.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.VisiblePosition = 0;
            ultraCombo_NguoiLap.DisplayLayout.Bands[0].Columns["TenDangNhap"].Width = ultraCombo_NguoiLap.Width;

            this.ultraCombo_NguoiLap.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraCombo_NguoiLap.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
        }

        DataSet dataSet = new DataSet();
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        private void InSoQuyTienMat_Dev()
        {           

            ReportTemplate _report = ReportTemplate.GetReportTemplate("IDReport_SoQuyTienMat");//PhieuNhapVatTu//
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
                frm.ShowDialog();
            }
        }

        public void Method_SoQuyTienMat()
        {          
           
             dataSet = new DataSet();
             using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
             {
                 cn.Open();
                 //tao MainData
                 using (SqlCommand command = cn.CreateCommand())
                 {

                     command.CommandTimeout = 0;
                     command.CommandType = CommandType.StoredProcedure;
                     command.CommandText = "spd_ReportThuQuyTienMat";
                     command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                     command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                     command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                     command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                     command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                     SqlDataAdapter adapter = new SqlDataAdapter(command);
                     DataTable table = new DataTable();
                     adapter.Fill(table);
                     table.TableName = "spd_ReportThuQuyTienMat";
                     dataSet.Tables.Add(table);                                                  
                 }

                 using (SqlCommand command = cn.CreateCommand())
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     command.CommandText = "spd_ReportHeaderAndFooter";
                     command.Parameters.AddWithValue("@MaNguoiLap", UserId);
                     SqlDataAdapter da = new SqlDataAdapter(command);
                     DataTable dt = new DataTable();
                     da.Fill(dt);
                     dt.TableName = "spd_ReportHeaderAndFooter";
                     dataSet.Tables.Add(dt);
                 }

                 using (SqlCommand command = cn.CreateCommand())
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     command.CommandText = "spd_LayNguoiKyTenCongNo";
                     command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                     command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                     SqlDataAdapter adapter1 = new SqlDataAdapter(command);
                     DataTable table1 = new DataTable();
                     adapter1.Fill(table1);
                     table1.TableName = "spd_LayNguoiKyTenCongNo";
                     dataSet.Tables.Add(table1);
                 }

                 DataTable dtngay = new DataTable();
                 dtngay.Columns.Add("TuNgay", typeof(DateTime));
                 dtngay.Columns.Add("DenNgay", typeof(DateTime));
                 dtngay.Columns.Add("SoHieuTK", typeof(string));
                 dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                 dtngay.Columns.Add("TenDoiTuong", typeof(string));
                 //Add dòng 1
                 DataRow dr = dtngay.NewRow();
                 dr["TuNgay"] = Convert.ToDateTime(dateTuNgay.Value).Date;
                 dr["DenNgay"] = Convert.ToDateTime(dateDenNgay.Value).Date;
                 dr["SoHieuTK"] = "";
                 dr["TenTaiKhoan"] = "";
                 dr["TenDoiTuong"] = "";
                 dtngay.Rows.Add(dr);
                 dtngay.TableName = "TblTuNgay_DenNgay";
                 dataSet.Tables.Add(dtngay);

             }

        }

        private void InSoTheoDoiDaThuChi_Dev()
        {

            ReportTemplate _report = ReportTemplate.GetReportTemplate("IDReport_SoTheoDoiDaThuChi");//PhieuNhapVatTu//
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
                frm.ShowDialog();
            }
        }

        public void Method_SoTheoDoiDaThuChi()
        {

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand command = cn.CreateCommand())
                {

                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportQuyTaiKhoanTienMatDaThuChi";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    //command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportQuyTaiKhoanTienMatDaThuChi";
                    dataSet.Tables.Add(table);
                }

                using (SqlCommand command = cn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportHeaderAndFooter";
                    command.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

                using (SqlCommand command = cn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_LayNguoiKyTenCongNo";
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(command);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo";
                    dataSet.Tables.Add(table1);
                }

                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = Convert.ToDateTime(dateTuNgay.Value).Date;
                dr["DenNgay"] = Convert.ToDateTime(dateDenNgay.Value).Date;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dr["TenDoiTuong"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }

        }

        private void InSoTheoDoiThuChiChuaHoanTat_Dev()
        {

            ReportTemplate _report = ReportTemplate.GetReportTemplate("IDReport_QuyTaiKhoanTienMatChuaHoanTat");//PhieuNhapVatTu//
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
                frm.ShowDialog();
            }
        }

        public void Method_QuyTaiKhoanTienMatChuaHoanTat()
        {

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand command = cn.CreateCommand())
                {

                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportQuyTaiKhoanTienMatChuaHoanTat";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    //command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportQuyTaiKhoanTienMatDaThuChi";
                    dataSet.Tables.Add(table);
                }

                using (SqlCommand command = cn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportHeaderAndFooter";
                    command.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

                using (SqlCommand command = cn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_LayNguoiKyTenCongNo";
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(command);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo";
                    dataSet.Tables.Add(table1);
                }

                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = Convert.ToDateTime(dateTuNgay.Value).Date;
                dr["DenNgay"] = Convert.ToDateTime(dateDenNgay.Value).Date;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dr["TenDoiTuong"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }

        }



    }
}