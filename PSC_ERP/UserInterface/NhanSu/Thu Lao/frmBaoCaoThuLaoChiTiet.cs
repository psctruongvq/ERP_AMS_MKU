using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using ERP_Library.Security;

namespace PSC_ERP
{//
    public partial class frmBaoCaoThuLaoChiTiet : Form
    {
        BoPhanList _BoPhanList;
        int maBophan = 0; long maNhanVien = 0;
        int maNganHang = 0; int thanhToan = -1; int nhapHo = -1;
        int maChuongTrinh = 0;  int maNguoiLap = 0;
        int maLoaiNV = 0; bool allUser = true;
        int dinhMuc = -1; int maChiTietGiayXacNhan = 0;
        string tenNguoiLap=string.Empty;
         string _tenNguoiLap=string.Empty;
        string tenBanPhuTrach=string.Empty;
        string _tenBanPhuTrach=string.Empty;
        string tenThuTruong=string.Empty;
            string _tenThuTruong=string.Empty;
        ChuongTrinhList _chuongTrinhList;
        TTNhanVienRutGonList _nhanVienList;
        ERP_Library.Security.UserList _UserList;
        int userID = CurrentUser.Info.UserID;
        //  ChiTietGiayXacNhanList _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.NewChiTietGiayXacNhanList();
        ChiTietGiayXacNhanTongHopList _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.NewChiTietGiayXacNhanTongHopList();
     
        public frmBaoCaoThuLaoChiTiet()
        {
            InitializeComponent();

            BindS_BoPhan.DataSource = typeof(BoPhanList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ChiTietGiayXacNhanList);
            this.NguoiLapListBindingSouce.DataSource = typeof(ERP_Library.Security.UserList);
            ultraComboEditor_CK.Value = 2;
            treeReport.ExpandAll();
           
        }

        private void frmBaoCaoThuLao_Load(object sender, EventArgs e)
        {
            _UserList = UserList.GetUserList(CurrentUser.Info.MaBoPhan);
            UserItem user = UserItem.NewUserItem("Tất Cả");
            _UserList.Insert(0, user);
            NguoiLapListBindingSouce.DataSource = _UserList;

           // rbUser.Text = ERP_Library.Security.CurrentUser.Info.TenDangNhap;
            _BoPhanList = BoPhanList.GetBoPhanListAll(userID);            
            BindS_BoPhan.DataSource = _BoPhanList;

            //chuong trinh
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("Tất Cả");
            _chuongTrinhList.Insert(0, itemChuongTrinh);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            //_chiTietGiayXacNhanList = ChiTietGiayXacNhanList.GetChiTietGiayXacNhanListByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiTietGiayXacNhan itemAdd = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0, "Không Có Giấy Xác Nhận");
            //_chiTietGiayXacNhanList.Insert(0, itemAdd);
            //this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;

            _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.GetChiTietGiayXacNhanTongHopListByUserID(CurrentUser.Info.UserID);
            ChiTietGiayXacNhanTongHop itemAdd = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop(0, "Không Có Giấy Xác Nhận");
            _chiTietGiayXacNhanList.Insert(0, itemAdd);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;
           
            foreach (NganHang nh in NganHangList.GetNganHangList())
                cmbNganHang.Items.ValueList.ValueListItems.Add(nh.MaNganHang, nh.TenNganHang);
            cmbNguoiLap.Items.Add(0, "Không Có");
            cmbPTTaiChinh.Items.Add(0, "Không Có");
            cmbPTDonVi.Items.Add(0, "Không Có");
            foreach (NguoiKyChild r in NguoiKyList.GetNguoiKyList())
            {
                
                cmbNguoiLap.Items.Add(r.MaNguoiKy, r.TenNguoiKy);
                cmbPTTaiChinh.Items.Add(r.MaNguoiKy, r.TenNguoiKy);
                cmbPTDonVi.Items.Add(r.MaNguoiKy, r.TenNguoiKy);
            }
            gbChiTiet.Enabled = true;
            TTNhanVienRutGon TTNV = TTNhanVienRutGon.NewTTNhanVienRutGon(0, "Tất Cả");
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListAll();
            _nhanVienList.Insert(0, TTNV);
            cmbNhanVien.DataSource = _nhanVienList;
          //  cmbNhanVien.LoadData();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (allUser == true)
            {
                userID = CurrentUser.Info.UserID;
                maNguoiLap = userID;
            }
            else
            {
                userID = -1;
                maNguoiLap = CurrentUser.Info.UserID;
            }
            SqlCommand command;
           
            DataSet dataset;
            ReportDocument Report;
            frmHienThiReport dlg;
            SqlDataAdapter adapter;
            DataTable table;           
            switch (treeReport.SelectedNode.Name)
            {
   
                case "Node1":
                    Report = new Report.rptDanhSachThuLaoChiTiet();
                    command = new SqlCommand();
                    command.CommandTimeout = 0;
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ThuLaoChuongTrinhByNhanVien";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay",Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@NguoiLap", maNguoiLap);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaNganHang", maNganHang);
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@LoaiNV", maLoaiNV);
                    command.Parameters.AddWithValue("@UserID",userID );
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                    command.Parameters.AddWithValue("@ThucNhan", dinhMuc); command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                     adapter = new SqlDataAdapter(command);
                     table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ThuLaoChuongTrinhByNhanVien;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);

                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    Report.SetParameterValue("_tenBoPhan", CurrentUser.Info.TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node2":
                     Report = new Report.rptThuLaoChuongTrinh();
                     command = new SqlCommand();
                     command.CommandTimeout = 0;
                     dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_DanhSachThuLao_Report";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@NguoiLap", maNguoiLap);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaNganHang", maNganHang);
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@LoaiNV", maLoaiNV);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                    command.Parameters.AddWithValue("@ThucNhan", dinhMuc); command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                     adapter = new SqlDataAdapter(command);
                     table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_DanhSachThuLao_Report;1";
                    
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tenBoPhan", CurrentUser.Info.TenBoPhan);
                     dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node3":
                    Report = new Report.BaoCaoThuLao();
                    command = new SqlCommand();
                    command.CommandTimeout = 0;
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_DanhSachThuLao_ReportParameter";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@NguoiLap", maNguoiLap);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaNganHang", maNganHang);
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@LoaiNV", maLoaiNV);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@ThucNhan", dinhMuc);
                    command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_DanhSachThuLao_ReportParameter;1";
                    
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tenBoPhan", CurrentUser.Info.TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node4":
                    Report = new Report.BaoCaoThuLaoNganHang();
                    command = new SqlCommand();
                    command.CommandTimeout = 0;
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_DanhSachThuLao_NganHang";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@NguoiLap", maNguoiLap);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaNganHang", maNganHang);
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@LoaiNV", maLoaiNV);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@ThucNhan", dinhMuc);
                    command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_DanhSachThuLao_NganHang;1";
                 
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);

                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tenBoPhan", CurrentUser.Info.TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node5":
                    Report = new Report.rptDanhSachThuLaoChiTietThanhToan();
                    command = new SqlCommand();
                    command.CommandTimeout = 0;
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienThanhToan";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@NguoiLap", maNguoiLap);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaNganHang", maNganHang);
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@LoaiNV", maLoaiNV);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@ThucNhan", dinhMuc);
                    command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ThuLaoChuongTrinhByNhanVienThanhToan;1";
                       dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tenBoPhan", CurrentUser.Info.TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node6":
                    Report = new Report.BaoCaoThuLaoTongHop();
                    command = new SqlCommand();
                    command.CommandTimeout = 0;
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportDanhSachThuLao";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@NguoiLap", maNguoiLap);                  
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaNganHang", maNganHang);
                    command.Parameters.AddWithValue("@ThucNhan", dinhMuc);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                    command.Parameters.AddWithValue("@MaChungTuDeNghi", Convert.ToInt32(ultraComboEditor_CK.Value));
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportDanhSachThuLao;1";                  
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("Tu_Ngay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    Report.SetParameterValue("Den_Ngay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_PhuongThucThanhToan", cbThanhToan.Text);
                    Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node7":
                    Report = new Report.rptTheoDoiGiayXacNhan();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportGiayXacNhan_Tracking";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    if (CurrentUser.IsAdminThuChi || userID == 0)
                    {
                        command.Parameters.AddWithValue("@IsAdmin", true);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@IsAdmin", false);
                    }
                    command.CommandTimeout = 0;
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportGiayXacNhan_Tracking;1";
                
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    //Report.SetParameterValue("_PhuongThucThanhToan", cbThanhToan.Text);
                   
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node8":
                    Report = new Report.NhanSu.rptTheoDoiGiayXacNhanNhapThuLao();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportGiayXacNhan_TrackingByNhapThuLao";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.CommandTimeout = 0;
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportGiayXacNhan_TrackingByNhapThuLao;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    //Report.SetParameterValue("_PhuongThucThanhToan", cbThanhToan.Text);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_Bophan.ActiveRow!= null)
            {
                maBophan = Convert.ToInt32(cmbu_Bophan.ActiveRow.Cells["MaBoPhan"].Value);
                cmbNhanVien.Value = null;
                TTNhanVienRutGon TTNV = TTNhanVienRutGon.NewTTNhanVienRutGon(0, "Tất Cả");
                _nhanVienList = TTNhanVienRutGonList.GetNhanVienListBoPhan(maBophan);
                _nhanVienList.Insert(0,TTNV);
                cmbNhanVien.DataSource = _nhanVienList;
               // cmbNhanVien.FilterByMaBoPhan(maBophan);
            }
           
        }

        private void cbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            if (cmbNhanVien.ActiveRow != null)
            {
                maNhanVien = Convert.ToInt32(cmbNhanVien.ActiveRow.Cells["MaNhanVien"].Value);
            }
           
        }
        private void ComboChanged()
        {
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListByBoPhanNganHang(maBophan,maLoaiNV, maNganHang,maNhanVien);
            TTNhanVienRutGon _nhanVienThem = TTNhanVienRutGon.NewTTNhanVienRutGon(0, "Tất Cả");
            _nhanVienList.Insert(0, _nhanVienThem);
            this.bindingSource2_nhanVien.DataSource = _nhanVienList;
        }

        private void cmbNganHang_ValueChanged(object sender, EventArgs e)
        {
            if (cmbNganHang.Value != null)
            {
                maNganHang = Convert.ToInt32(cmbNganHang.Value);
            }
            ComboChanged();
        }

        private void cmbu_ChuongTrinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.ActiveRow!= null)
            {
                maChuongTrinh = Convert.ToInt32(cmbu_ChuongTrinh.ActiveRow.Cells["MaChuongTrinh"].Value);
            }
        }

        private void ultraComboEditor1_ValueChanged(object sender, EventArgs e)
        {
            if (cbThanhToan.Value != null)
            {
                thanhToan = Convert.ToInt32(cbThanhToan.Value);
            }
        }

        private void cmbLoaiNV_ValueChanged(object sender, EventArgs e)
        {
            if (cmbLoaiNV.Value != null)
            {
                maLoaiNV = Convert.ToInt32(cmbLoaiNV.Value);
            }
            ComboChanged();
        }

        private void treeReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeReport.SelectedNode.Name == "Node6")
            {
                //cbDinhMuc.Enabled = false;
                //cmbu_Bophan.Enabled = false;
                //cmbLoaiNV.Enabled = false;
                //cmbNganHang.Enabled = false;
                //cmbNhanVien.Enabled = false;
              //  cbChiTietGiayXacNhan.Enabled = false;
            }
         
           else if (treeReport.SelectedNode.Name == "Node7")
            {
                cbDinhMuc.Enabled = false;
                cmbu_Bophan.Enabled = false;
                cmbLoaiNV.Enabled = false;
                cmbNganHang.Enabled = false;
                cmbNhanVien.Enabled = false;
                cbChiTietGiayXacNhan.Enabled = false;
                cbThanhToan.Enabled = false;
                cmbu_ChuongTrinh.Enabled = false;
            }
            else
            {
                cbDinhMuc.Enabled = true;
                cmbu_Bophan.Enabled = true;
                cmbLoaiNV.Enabled = true;
                cmbNganHang.Enabled = true;
                cmbNhanVien.Enabled = true;
                cbChiTietGiayXacNhan.Enabled = true;
                cbThanhToan.Enabled = true;
                cmbu_ChuongTrinh.Enabled = true;
            }
        }

        private void ultraComboEditor2_ValueChanged(object sender, EventArgs e)
        {
            if (cbDinhMuc.Value != null)
            {
                dinhMuc = Convert.ToInt32(cbDinhMuc.Value);
            }
        }

        private void cmbNguoiLap_ValueChanged(object sender, EventArgs e)
        {
            if (cmbNguoiLap.Value != null && (int)cmbNguoiLap.Value != 0)
            {
                _tenNguoiLap = "Tên Người Lập\r\n(Ký, họ tên)";
                tenNguoiLap = cmbNguoiLap.Text;
            }
            else if ((int)cmbNguoiLap.Value == 0)
            {
                _tenNguoiLap = string.Empty;
                tenNguoiLap = string.Empty;
            }
        }

        private void cmbPTDonVi_ValueChanged(object sender, EventArgs e)
        {
            if (cmbPTDonVi.Value != null && (int)cmbPTDonVi.Value != 0)
            {
                _tenBanPhuTrach = "Ban Phụ Trách\r\n(Ký, họ tên)";
                tenBanPhuTrach = cmbPTDonVi.Text;
            }
            else if ((int)cmbPTDonVi.Value == 0)
            {
                _tenBanPhuTrach = string.Empty;
                tenBanPhuTrach = string.Empty;
            }
        }

        private void cmbPTTaiChinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbPTTaiChinh.Value != null && (int)cmbPTTaiChinh.Value != 0)
            {
                _tenThuTruong = "Thủ Trưởng đơn vị\r\n(Ký, họ tên)";
                tenThuTruong = cmbPTTaiChinh.Text;
            }
            else if ((int)cmbPTTaiChinh.Value == 0)
            {
                _tenThuTruong = string.Empty;
                tenThuTruong = string.Empty;
            }
        }

        private void cbNhapHo_ValueChanged(object sender, EventArgs e)
        {
            if (cbNhapHo.Value != null)
            {
                nhapHo= Convert.ToInt32(cbNhapHo.Value);
            }
        }

        private void cmbu_ChuongTrinh_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
           
        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_ChuongTrinh, "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = cmbu_ChuongTrinh.Width;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã QL";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;
        }

        private void cmbu_Bophan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        private void cbNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
           // FilterCombo f = new FilterCombo(cmbNhanVien, "TenNhanVien");
            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.AllowColMoving = AllowColMoving.WithinBand;
            e.Layout.Override.AllowColSwapping = AllowColSwapping.WithinBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            e.Layout.Bands[0].Columns["TenNhanVien"].FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
            e.Layout.Bands[0].Columns["TenNhanVien"].FilterOperandStyle = FilterOperandStyle.Combo;
            e.Layout.Bands[0].Columns["TenNhanVien"].FilterOperatorLocation = FilterOperatorLocation.AboveOperand;



        }

        private void cbChiTietGiayXacNhan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChiTietGiayXacNhan, "TenGiayXacNhan");
            foreach (UltraGridColumn col in this.cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.Caption = "Tên Giấy Xác Nhận";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.VisiblePosition = 0;

            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###,###";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
            //cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Còn Lại";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "###,###,###,###,###";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 2;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDi"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDi"].Header.Caption = "Đơn Vị Gửi";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDi"].Header.VisiblePosition = 3;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDen"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDen"].Header.Caption = "Đơn Vị Nhận";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDen"].Header.VisiblePosition = 4;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 5;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.Caption = "Nhập Hộ";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.VisiblePosition = 6;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["HoanTat"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["HoanTat"].Header.Caption = "Hoàn Tất";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["HoanTat"].Header.VisiblePosition = 7;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 8;

        }

        private void cbChiTietGiayXacNhan_ValueChanged(object sender, EventArgs e)
        {
            if (cbChiTietGiayXacNhan.ActiveRow!= null)
            {
                maChiTietGiayXacNhan = Convert.ToInt32(cbChiTietGiayXacNhan.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value);
            }
        }

        private void cbNhanVien_TextChanged(object sender, EventArgs e)
        {
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
            ultraCombo1.DisplayLayout.Bands[0].Columns["TenDangNhap"].Width = 200;
            this.ultraCombo1.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraCombo1.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
 
        }

        private void ultraCombo1_ValueChanged(object sender, EventArgs e)
        {
            if (ultraCombo1.ActiveRow != null)
            {
                int userID = Convert.ToInt32(ultraCombo1.ActiveRow.Cells["UserID"].Value);
                if (userID == 0)
                {
                    allUser = true;
                }
                else
                {
                    allUser = false;
                    maNguoiLap = userID;
                }
            }
        }

        private void cmbNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbNhanVien, "TenNhanVien");

            foreach (UltraGridColumn col in this.cmbNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            cmbNhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
            cmbNhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 0;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 200;

            cmbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            cmbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 200;
            this.cmbNhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbNhanVien.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;

        }

        private void ultraComboEditor_CK_ValueChanged(object sender, EventArgs e)
        {
            //if (ultraComboEditor_CK.Value != null)
            //{
            //    maChiTietGiayXacNhan = Convert.ToInt32(ultraComboEditor_CK.SelectedIndex);
            //}
        }

        //private void rbAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rbAll.Checked == true)
        //        allUser = true;
        //    else
        //        allUser = false;
        //}
        
        //private void rbUser_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rbUser.Checked == true)
        //        allUser = false;
        //    else
        //        allUser = true;
        //}
    }
}