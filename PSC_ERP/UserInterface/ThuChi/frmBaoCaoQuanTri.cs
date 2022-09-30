
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


namespace PSC_ERP
{//
    public partial class frmBaoCaoQuanTri : Form
    {
        #region Properties
        HeThongTaiKhoan1List _HeThongTaiKhoan1ListNo;
        DoiTuongAllList _DoiTuongAllList;
       
        int maTaiKhoan = 0;
        int maChuongTrinh = 0;
        int maCongViec = 0;
        int maLoaiChungTu = 0;
        long maChungTu = 0;
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
        #endregion

        #region Events
        public frmBaoCaoQuanTri()
        {
            InitializeComponent();
            this.bindingSource2_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.bindingSource1_ChungTu.DataSource = typeof(ChungTuRutGonList);
            this.KhachHang_BindingSource.DataSource = typeof(DoiTuongAllList);
            this.NoTaiKhoan_BindingSource.DataSource = typeof(HeThongTaiKhoan1List);
            this.bindingSource1_DoiTuongThuChi.DataSource = typeof(DoiTuongThuChiList);

            LayDuLieu();

        }

        private void LayDuLieu()
        {

            //chuong trinh
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("Tất Cả");
            _chuongTrinhList.Insert(0, itemChuongTrinh);
            this.bindingSource2_ChuongTrinh.DataSource = _chuongTrinhList;

            _chungTuList = ChungTuRutGonList.GetChungTuRutGonList();
            ChungTuRutGon ct = ChungTuRutGon.NewChungTuRutGon("Tất Cả");
            _chungTuList.Insert(0, ct);
            this.bindingSource1_ChungTu.DataSource = _chungTuList;
            _DoiTuongAllList = DoiTuongAllList.GetDoiTuongAllList();

            KhachHang_BindingSource.DataSource = _DoiTuongAllList;

            _HeThongTaiKhoan1ListNo = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
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
            if (_noCoTK == -1 && maTaiKhoan != 0)//Tất cả Nợ/Có của TK
            {
                Kieu = 3;
            }
            else if (_noCoTK == 1)//Nợ TK
            {
                Kieu = 1;
            }
            else if (_noCoTK == 2)//Có TK
            {
                Kieu = 2;
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
                    command.Parameters.AddWithValue("@MaKy",0);

                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportQuyTaiKhoanTienMat;1";
                    _DataSet.Tables.Add(table);
                 
               
                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                    Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                    #endregion

                }
                else if (treeReport.SelectedNode.Name == "Node2") //Kiểm tra tài khoản tạm ứng.
                {

                    _DataSet = new DataSet();
                    Report = new Report.CongNo.KiemTraTamUng();

                    command = new SqlCommand();
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

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    Report.SetParameterValue("tenDonVi", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }


                else if (treeReport.SelectedNode.Name == "Node3") //Bảng Kê Chứng Từ - Chương Trình
                {

                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BangKeChungTu_ChuongTrinh();

                    command = new SqlCommand();
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

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    Report.SetParameterValue("tenDonVi", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tenDoiTuongThuChi", cbCongViec.Text);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }

                else if (treeReport.SelectedNode.Name == "Node4")//Chi phí Sản Xuất Chương Trình
                {

                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BaoCaoChiPhiSanXuatChuongTrinh();

                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Report_ChuongTrinhSanXuatChuongTrinh";
                    command.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaDoiTuongThuChi", maCongViec);
                    command.Parameters.AddWithValue("@MaLoaiChungTu", maLoaiChungTu);
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaLoaiChiPhi", loaiChiPhi);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    command.Parameters.AddWithValue("@Kieu", Kieu);
                    command.Parameters.AddWithValue("@MaMucNganSach", MaMucString);
                    command.Parameters.AddWithValue("@MaTieuMuc", MaTieuMucString);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "Report_ChuongTrinhSanXuatChuongTrinh;1";
                    _DataSet.Tables.Add(table);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    Report.SetParameterValue("tenDonVi", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tenDoiTuongThuChi", cbCongViec.Text);
                    Report.SetParameterValue("_tenChuongTrinh", cbChuongTrinh.Text);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }
                else if (treeReport.SelectedNode.Name == "Node5")
                {
                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BaoCaoTheoDoiThuChiTienMat();

                    command = new SqlCommand();
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

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }
                else if (treeReport.SelectedNode.Name == "Node6")
                {
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

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                }
                else if (treeReport.SelectedNode.Name == "Node7")
                {
                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BaoCaoThuQuyTienMat();

                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportThuQuyTienMat";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportThuQuyTienMat;1";
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
                else if (treeReport.SelectedNode.Name == "Node8")
                {
                    _DataSet = new DataSet();
                    Report = new Report.CongNo.BaoCaoQuyChungMotTamLong();
                    DateTime dt=new DateTime(DateTime.Today.Year,1,1);
                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReportQuyChungMotTamLong";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@NgayDauNam",dt);
                    command.Parameters.AddWithValue("@MaDoiTuongThuChi", maCongViec);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "ReportQuyChungMotTamLong;1";
                    _DataSet.Tables.Add(table);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(dateTuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(dateDenNgay.Value).Date);
                    Report.SetParameterValue("_NgayThangDauNam", Convert.ToDateTime(dt).Date);
                    Report.SetParameterValue("_tenCongViec", cbCongViec.Text);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
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

        private void frmBaoCaoQuanTri_Load(object sender, EventArgs e)
        {
            EnableDisableControl(false);
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
            }
        }
        private void treeReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            EnableDisableControl(false);
            if (treeReport.SelectedNode.Name == "Node1")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
                cmbu_DSTaiKhoan.Enabled = true;
                rbCo.Enabled = true;
                rbNo.Enabled = true;
                rbTatCa.Enabled = true;
                cbMucNganSach.Enabled = true;
                cbTieuMucNganSach.Enabled = true;

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
                cbMucNganSach.Enabled = true;
                cbTieuMucNganSach.Enabled = true;

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
            else if (treeReport.SelectedNode.Name == "Node7")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
                // cmbu_DSTaiKhoan.Enabled = true;

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

            //cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            //cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            //cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
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

            cbTieuMucNganSach.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.CheckedItems;
            UltraGridColumn checkColumn = this.cbTieuMucNganSach.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cbTieuMucNganSach.CheckedListSettings.CheckStateMember = checkColumn.Key;

            cbTieuMucNganSach.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbTieuMucNganSach.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Tiểu Mục";
            cbTieuMucNganSach.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;

            cbTieuMucNganSach.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Hidden = false;
            cbTieuMucNganSach.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.Caption = "Tên Tiểu Mục";
            cbTieuMucNganSach.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.VisiblePosition = 2;
            cbTieuMucNganSach.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Width = 200;

            this.cbTieuMucNganSach.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbTieuMucNganSach.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked == true)
            //{
            //    ICheckedItemList itemList = (ICheckedItemList)this.ultraCombo_Nhom;
            //    for (int i = 0; i < this.ultraCombo_Nhom.Rows.Count; i++)
            //        itemList.SetCheckState(i, CheckState.Checked);
            //}
            //else
            //{
            //    ICheckedItemList itemList = (ICheckedItemList)this.ultraCombo_Nhom;
            //    for (int i = 0; i < this.ultraCombo_Nhom.Rows.Count; i++)
            //        itemList.SetCheckState(i, CheckState.Unchecked);
            //}
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked == true)
            //{
            //    ICheckedItemList itemList = (ICheckedItemList)this.ultraCombo_Nhom;
            //    for (int i = 0; i < this.ultraCombo_Nhom.Rows.Count; i++)
            //        itemList.SetCheckState(i, CheckState.Checked);
            //}
            //else
            //{
            //    ICheckedItemList itemList = (ICheckedItemList)this.ultraCombo_Nhom;
            //    for (int i = 0; i < this.ultraCombo_Nhom.Rows.Count; i++)
            //        itemList.SetCheckState(i, CheckState.Unchecked);
            //}
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
    }
}