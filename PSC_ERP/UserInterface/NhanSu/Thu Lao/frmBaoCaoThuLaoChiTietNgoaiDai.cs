using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmBaoCaoThuLaoNgoaiDai : Form
    {
        BoPhanList _BoPhanList;
        int maBophan = 0; long maNhanVien = 0;
        int maChuongTrinh = 0;  int nguoiLap = 0;
        int thanhToan = -1; int nhapHo = -1;
        string tenNguoiLap=string.Empty;
        string _tenNguoiLap=string.Empty;

        string tenBanPhuTrach=string.Empty;
        string _tenBanPhuTrach=string.Empty;
        string tenThuTruong=string.Empty;
        string _tenThuTruong=string.Empty;
        ChuongTrinhList _chuongTrinhList;
        NhanVienNgoaiDaiList _nhanVienList;
        UserList _UserList;
        ChiTietGiayXacNhanList _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.NewChiTietGiayXacNhanList();
        KyTinhLuongList _kyTinhLuongList;
        int userID = CurrentUser.Info.UserID;
        public frmBaoCaoThuLaoNgoaiDai()
        {
            InitializeComponent();            
            BindS_BoPhan.DataSource =typeof(BoPhanList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.NguoiLapListBindingSouce.DataSource = typeof(UserList);
            this.GiayXacNhanList_bindingSource.DataSource = typeof(ChiTietGiayXacNhanList);
            cmbThue.Value = 2;
            ultraComboEditor_CK.Value = 2;
            treeReport.ExpandAll();
        }

        private void frmBaoCaoThuLao_Load(object sender, EventArgs e)
        {           
            _BoPhanList = BoPhanList.GetBoPhanListAll(userID);            
            BindS_BoPhan.DataSource = _BoPhanList;            
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("Tất Cả");
            _chuongTrinhList.Insert(0, itemChuongTrinh);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;           
           
           
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
            //if (ERP_Library.Security.CurrentUser.IsAdmin && ERP_Library.Security.CurrentUser.Info.MaCongTy == 1)
            //    userID = 0;
            //else


            _UserList = UserList.GetUserList(CurrentUser.Info.MaBoPhan);
            UserItem user = UserItem.NewUserItem("Tất Cả");
            _UserList.Insert(0, user);
            NguoiLapListBindingSouce.DataSource = _UserList;

            _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.GetChiTietGiayXacNhanListByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            ChiTietGiayXacNhan itemAdd = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0, "Không Có Giấy Xác Nhận");
            _chiTietGiayXacNhanList.Insert(0, itemAdd);
            this.GiayXacNhanList_bindingSource.DataSource = _chiTietGiayXacNhanList;
            cbChiTietGiayXacNhan.DataSource = GiayXacNhanList_bindingSource;
            

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
            
            cmbThue.Value = 2;
                
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //if (rbAll.Checked == true)
            //{
            //    userID = -1; nguoiLap = 0;
            //}
            //else if (rbBoPhan.Checked == true)
            //{
            //    userID = ERP_Library.Security.CurrentUser.Info.UserID;
            //    nguoiLap = -1;
            //}
            //else if (rbUser.Checked == true)
            //{
            //    nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            //     userID=-1;
            //}
            SqlCommand command;
            DataSet dataset;
            ReportDocument Report;
            frmHienThiReport dlg;
            SqlDataAdapter adapter;
            DataTable table;           
            switch (treeReport.SelectedNode.Name)
            {
                case "Node1":
                    Report = new Report.BaoCaoThuLaoNgoaiDai();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportDanhSachThuLaoNgoaiDai";
                    //command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    //command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    //command.Parameters.AddWithValue("@NguoiLap", nguoiLap);
                    //command.Parameters.AddWithValue("@UserID", userID);
                    //command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    //command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    //command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    //command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    //command.Parameters.AddWithValue("@NhapHo", nhapHo);

                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@NguoiLap", Convert.ToInt32(ultraCombo1.Value));
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", Convert.ToInt32(cbChiTietGiayXacNhan.Value));

                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                     adapter = new SqlDataAdapter(command);
                     table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportDanhSachThuLaoNgoaiDai;1";
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
               
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node2":
                    Report = new Report.BaoCaoThuLaoNgoaiDaiTongHop();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[spd_ReportTongHopDanhSachThuLaoNgoaiDai]";
                    //command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    //command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    //command.Parameters.AddWithValue("@NguoiLap", nguoiLap);
                    //command.Parameters.AddWithValue("@UserID", userID);
                    //command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    //command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    //command.Parameters.AddWithValue("@NhapHo", nhapHo);

                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@NguoiLap", Convert.ToInt32(ultraCombo1.Value));
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    if (cbChiTietGiayXacNhan.ActiveRow != null)
                    {
                        command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", Convert.ToInt32(cbChiTietGiayXacNhan.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value));
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", 0);
                    }
                    //command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", Convert.ToInt32(cbChiTietGiayXacNhan.Value));
                    command.Parameters.AddWithValue("@MaChungTuDeNghi", Convert.ToInt32(ultraComboEditor_CK.Value));  
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportTongHopDanhSachThuLaoNgoaiDai;1";
                  
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
                    Report.SetParameterValue("_BoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node3":
                    Report = new Report.rptDanhSachThuLaoChiTiet_NgoaiDai();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@NguoiLap", Convert.ToInt32(ultraCombo1.Value));
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@Thue", Convert.ToInt32(cmbThue.Value));
                    command.Parameters.AddWithValue("@MaChungTuDeNghi", Convert.ToInt32(ultraComboEditor_CK.Value));
                    if (cbChiTietGiayXacNhan.ActiveRow != null)
                    {
                        command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", Convert.ToInt32(cbChiTietGiayXacNhan.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value));
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", 0);
                    }
                    //command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", Convert.ToInt32(cbChiTietGiayXacNhan.Value));
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai;1";
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
                    Report.SetParameterValue("_PTTToan", cbThanhToan.Text);
                    Report.SetParameterValue("_TenBoPhanDangNhap", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node4":
                    Report = new Report.rptDanhSachThuNhapThuLaoChiTiet_NgoaiDai();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Report_ThuNhapThuLaoNhanVienNgoaiDai";
                    //command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    //command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    //command.Parameters.AddWithValue("@NguoiLap", nguoiLap);
                    //command.Parameters.AddWithValue("@UserID", userID);
                    //command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    //command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    //command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    //command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    //command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);


                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@NguoiLap", Convert.ToInt32(ultraCombo1.Value));
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "Report_ThuNhapThuLaoNhanVienNgoaiDai;1";

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
                    Report.SetParameterValue("_PTTToan", cbThanhToan.Text);
                    Report.SetParameterValue("_tenBoPhan",ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node5":
                    Report = new Report.rptDanhSachThuLaoChiTiet_NgoaiDai_NVChuyenTien();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_NhanVienChuyenTien";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@NguoiLap", Convert.ToInt32(ultraCombo1.Value));
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@Thue", Convert.ToInt32(cmbThue.Value));
                    command.Parameters.AddWithValue("@MaChungTuDeNghi", Convert.ToInt32(ultraComboEditor_CK.Value));
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.CommandTimeout = 0;
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_NhanVienChuyenTien;1";
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
                    Report.SetParameterValue("_PTTToan", cbThanhToan.Text);
                    Report.SetParameterValue("_TenBoPhanDangNhap", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "NodeTheoKy":
                    if (cmbu_KyLuong.Value == null)
                    {
                        MessageBox.Show(this, "Vui lòng chọn kỳ tính lương trước khi thực hiện thao tác này !", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbu_KyLuong.Focus();
                        break;
                    }
                    Report = new Report.rptDanhSachThuLaoChiTiet_NgoaiDai_TheoKy();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_ByKyLuong";
                    command.Parameters.AddWithValue("@MaKyTinhLuong", Convert.ToInt32(cmbu_KyLuong.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@NguoiLap", Convert.ToInt32(ultraCombo1.Value));
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@Thue", Convert.ToInt32(cmbThue.Value));
                    command.Parameters.AddWithValue("@MaChungTuDeNghi", Convert.ToInt32(ultraComboEditor_CK.Value));
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.CommandTimeout = 0;
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_ByKyLuong;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("_TenKy", cmbu_KyLuong.Text);
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_PTTToan", cbThanhToan.Text);
                    Report.SetParameterValue("_TenBoPhanDangNhap", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "NodeCMND":
                    //if (txt_CMND.Text == string.Empty)
                    //{
                    //    MessageBox.Show(this, "Vui lòng chọn nhập số CMND trước khi thực hiện thao tác !", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    txt_CMND.Focus();
                    //    break;
                    //}
                    Report = new Report.rptDanhSachThuLaoChiTiet_NgoaiDai_CMND();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_ByCMND";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@CMND", txt_CMND.Text);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.CommandTimeout = 0;
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_ByCMND;1";
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
                    Report.SetParameterValue("_PTTToan", cbThanhToan.Text);
                    Report.SetParameterValue("_TenBoPhanDangNhap", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "NodeTongHop":
                    Report = new Report.rptDanhSachThuLaoChiTiet_NgoaiDai_TongHop();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_TongHop";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@NguoiLap", Convert.ToInt32(ultraCombo1.Value));
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@Thue", Convert.ToInt32(cmbThue.Value));
                    command.Parameters.AddWithValue("@MaChungTuDeNghi", Convert.ToInt32(ultraComboEditor_CK.Value));
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.CommandTimeout = 0;
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_TongHop;1";
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
                    Report.SetParameterValue("_PTTToan", cbThanhToan.Text);
                    Report.SetParameterValue("_TenBoPhanDangNhap", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "NodeTH":
                    Report = new Report.rptDanhSachThuLaoChiTiet_NgoaiDai_DSTH();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_DSTH";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@NguoiLap", Convert.ToInt32(ultraCombo1.Value));
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@Thue", Convert.ToInt32(cmbThue.Value));
                    command.Parameters.AddWithValue("@MaChungTuDeNghi", Convert.ToInt32(ultraComboEditor_CK.Value));
                    if (cbChiTietGiayXacNhan.ActiveRow != null)
                    {
                        command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", Convert.ToInt32(cbChiTietGiayXacNhan.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value));
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", 0);
                    }
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.CommandTimeout = 0;
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_DSTH;1";
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
                    Report.SetParameterValue("_PTTToan", cbThanhToan.Text);
                    Report.SetParameterValue("_TenBoPhanDangNhap", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;

                case "NodeChuyenTien":
                    Report = new Report.rptDanhSachThuLaoChiTiet_NgoaiDai_NVChuyenTien();
                    if ( (Int32)cbThanhToan.Value != 1)
                    {
                        MessageBox.Show("Vui lòng chọn chuyển khoản", "Thông Báo", MessageBoxButtons.OK);
                            return ;
                    }
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_NhanVienChuyenTienNew";
                    command.Parameters.AddWithValue("@TuNgay", dateTimePicker_TuNgay.DateTime.Date);
                    command.Parameters.AddWithValue("@DenNgay", dateTimePicker_DenNgay.DateTime.Date);
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@NguoiLap", Convert.ToInt32(ultraCombo1.Value));
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@Thue", Convert.ToInt32(cmbThue.Value));
                    command.Parameters.AddWithValue("@MaChungTuDeNghi", Convert.ToInt32(ultraComboEditor_CK.Value));
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.CommandTimeout = 0;
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_NhanVienChuyenTien;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("_tuKy", dateTimePicker_TuNgay.DateTime.Date.ToShortDateString());
                    Report.SetParameterValue("_denKy", dateTimePicker_DenNgay.DateTime.Date.ToShortDateString());
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_PTTToan", cbThanhToan.Text);
                    Report.SetParameterValue("_TenBoPhanDangNhap", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
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
            if (cmbu_Bophan.ActiveRow != null)
            {
                maBophan = Convert.ToInt32(cmbu_Bophan.Value);
            }
            ComboChanged();
        }

        private void cbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            if (cbNhanVien.ActiveRow!= null)
            {
                maNhanVien = Convert.ToInt64(cbNhanVien.ActiveRow.Cells["MaNhanVien"].Value);
            }            
        }
        private void ComboChanged()
        {
          //  _nhanVienList = TTNhanVienRutGonList.GetNhanVienListByBoPhanNganHang(maBophan,maLoaiNV, maNganHang,maNhanVien);
            _nhanVienList = NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiList(maBophan,1);
            NhanVienNgoaiDai _nhanVienThem = NhanVienNgoaiDai.NewNhanVienNgoaiDai("Tất cả");
            _nhanVienList.Insert(0, _nhanVienThem);
            this.bindingSource2_nhanVien.DataSource = _nhanVienList;

            foreach (UltraGridColumn col in this.cbNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            cbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            cbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = cbNhanVien.Width;
            cbNhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = false;
            cbNhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.Caption = "Mã Nhân Viên";
            cbNhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.VisiblePosition = 1;
        }


        private void cmbu_ChuongTrinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.ActiveRow != null)
            {
                maChuongTrinh = Convert.ToInt32(cmbu_ChuongTrinh.ActiveRow.Cells["MaChuongTrinh"].Value);
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

        private void ultraComboEditor1_ValueChanged(object sender, EventArgs e)
        {
            if (cbThanhToan.Value != null)
            {
                thanhToan = Convert.ToInt32(cbThanhToan.Value);
            }
        }

        private void cbNhapHo_ValueChanged(object sender, EventArgs e)
        {
            if (cbNhapHo.Value != null)
            {
                nhapHo = Convert.ToInt32(cbNhapHo.Value);
            }
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
            FilterCombo f = new FilterCombo(cbNhanVien, "TenNhanVien");

        }

        private void treeReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeReport.SelectedNode.Name == "Node2")
            {               
                cmbu_Bophan.Enabled = false;               
                cbNhanVien.Enabled = false;              
            }
            else
            {  cmbu_Bophan.Enabled = true;
                cbNhanVien.Enabled = true;
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

            this.ultraCombo1.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraCombo1.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
        }

        private void cbChiTietGiayXacNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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

        private void cmbu_KyLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_KyLuong, "TenKy");
            foreach (UltraGridColumn col in this.cmbu_KyLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 0;
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["TenKy"].Width = cmbu_KyLuong.Width;
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["MaKy"].Hidden = false;
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["MaKy"].Header.Caption = "Mã Kỳ";
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["MaKy"].Header.VisiblePosition = 1;
        }

     
      
    }
}