using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class frmBaoCaoTongHop_CacQuy : Form
    {

        #region Properties
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
        Ky ky = Ky.NewKy();

        DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
        string mamucngansach = string.Empty;
        string maPhongBanChuoi = string.Empty;
        string maTaiKhoanChuoi = string.Empty;
        ERP_Library.Security.UserList _UserList;
        int NguoiLap = 0;
        string tenbophan = "";

        long _maDoiTuong = 0;
        int _maLoaiQuy = 0;
        int _maChuongTrinh = 0;


        #region  Dev
        DataSet dataSetdev = new DataSet();
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        #endregion//Dev

        #endregion

        #region Load
        public frmBaoCaoTongHop_CacQuy()
        {
            InitializeComponent();
            LoadForm();
        }
        #endregion

        #region Process
        private void LoadForm()
        {
            //Kỳ
            kyListBindingSource.DataSource = typeof(KyList);
            cb_Ky.DataSource = kyListBindingSource;

            //Tài khoản
            heThongTaiKhoan1ListBindingSource.DataSource = typeof(HeThongTaiKhoan1List);
            cbu_SoHieuTK.DataSource = heThongTaiKhoan1ListBindingSource;

            //Quý
            quyListBindingSource.DataSource = typeof(QuyList);
            cbu_Quy.DataSource = quyListBindingSource;

            //LoaiQuy
            bd_LoaiQuy.DataSource = typeof(LoaiQuyList);
            cmbu_Quy.DataSource = bd_LoaiQuy;

            //Chương trình
            bdChuongTrinh.DataSource = typeof(ChuongTrinhList);
            cmbu_ChuongTrinh.DataSource = bdChuongTrinh;

            //Đối tượng
            bdDoiTuong.DataSource = typeof(DoiTuongAllList);
            cmbu_DoiTuong.DataSource = bdDoiTuong;

            //Loads Kỳ
            KyList _kyList = KyList.GetKyList();
            kyListBindingSource.DataSource = _kyList;

            //Load năm
            foreach (Ky item in _kyList)
            {
                if (item.NgayBatDau.Month == DateTime.Today.Month && item.NgayBatDau.Year == DateTime.Today.Year)
                    cb_Ky.SelectedValue = item.MaKy;
            }

            //Load Hệ Thống TK
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();

            //Load Quý
            quyListBindingSource.DataSource = QuyList.GetQuyList();

            //Đối tượng all
            DoiTuongAllList _doiTuongList = DoiTuongAllList.GetDoiTuongAllList();
            DoiTuongAll doituong = DoiTuongAll.NewDoiTuongAll("Tất cả");
            _doiTuongList.Insert(0, doituong);
            bdDoiTuong.DataSource = _doiTuongList;

            //Loại Quỹ
            LoaiQuy loaiQuy = LoaiQuy.NewLoaiQuy("Tất Cả");
            LoaiQuyList _loaiQuyList = LoaiQuyList.GetLoaiQuyList();
            _loaiQuyList.Insert(0, loaiQuy);
            bd_LoaiQuy.DataSource = _loaiQuyList;

            //Chương trình
            LoaiThuChi_CacQuyList _chuongTrinhList = LoaiThuChi_CacQuyList.GetLoaiThuChi_CacQuyList();
            LoaiThuChi_CacQuy _ct = LoaiThuChi_CacQuy.NewLoaiThuChi_CacQuy("Tất cả");
            _chuongTrinhList.Insert(0, _ct);
            bdChuongTrinh.DataSource = _chuongTrinhList;

            grd_DanhSachBC.ExpandAll();

            //Load Năm
            for (int i = 2000; i <= 2060; i++)
            {
                cb_Nam.Items.Add(i);
            }
            cb_Nam.Text = DateTime.Today.Year.ToString();
        }

        private void Unlock_LockControl(bool unlock)
        {
            rad_Ky.Enabled = unlock;
            cb_Ky.Enabled = unlock;
            dtu_TuNgay.Enabled = unlock;
            dtu_DenNgay.Enabled = unlock;
            rbt_Quy.Enabled = unlock;
            cbu_Quy.Enabled = unlock;
            rbt_Nam.Enabled = unlock;
            cb_Nam.Enabled = unlock;

            rbt_TuNgay.Enabled = unlock;
            dtu_NgayBatDau.Enabled = unlock;
            dtu_NgayKetThuc.Enabled = unlock;

            rdbt_TheoTungNgay.Enabled = unlock;
            dtu_TungNgay.Enabled = unlock;
            groupBox1.Enabled = unlock;

        }

        private void UnlockControlForBaoCaoTongKetCongTacHoatDongQC1TL()
        {
            rbt_TuNgay.Enabled = true;
            dtu_NgayBatDau.Enabled = true;
            dtu_NgayKetThuc.Enabled = true;
            rbt_TuNgay.Checked = true;
        }

        private bool ChuaChon_TuNgay()
        {
            if (dtu_NgayBatDau.Value == null)
            {
                MessageBox.Show("Chưa chọn từ ngày", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtu_NgayBatDau.Focus();
                return true;
            }
            return false;
        }

        private bool ChuaChon_DenNgay()
        {
            if (dtu_NgayKetThuc.Value == null)
            {

                MessageBox.Show("Chưa chọn đến ngày", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtu_NgayKetThuc.Focus();
                return true;
            }
            return false;
        }

        #endregion

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
            frmHienThiReport dlg = new frmHienThiReport();
            Loai = 0;
            if (cbu_Quy.Value != null)
            {
                Quy = Convert.ToInt32(cbu_Quy.Value);
                TenQuy = cbu_Quy.Text;
            }
            if (cb_Nam.Text != null && cb_Nam.Text != "")
                Nam = Convert.ToInt32(cb_Nam.Text);
            if (rad_Ky.Checked == true)
            {
                Loai = 1;
                TieuDe = TenKy;
                ngayBatDau = ky.NgayBatDau;
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

            if (cbu_SoHieuTK.ActiveRow != null)
            {
                maTaiKhoan = Convert.ToInt32(cbu_SoHieuTK.Value);
            }

            if (cmbu_Quy.ActiveRow != null)
            {
                _maLoaiQuy = Convert.ToInt32(cmbu_Quy.Value);
            }

            if (cmbu_ChuongTrinh.ActiveRow != null)
            {
                _maChuongTrinh = Convert.ToInt32(cmbu_ChuongTrinh.Value);
            }

            if (cmbu_DoiTuong.ActiveRow != null)
            {
                _maDoiTuong = Convert.ToInt64(cmbu_DoiTuong.Value);
            }

            if (grd_DanhSachBC.ActiveNode.Key == "KeyBaoCaoTongKetCongTacHoatDongQC1TL")
            {
                InBaoCaoTongKetCongTacHoatDongQC1TL();
                return;
            }
            //ok
            //IN BÁO CÁO
            if (grd_DanhSachBC.ActiveNode.Key == "SoChiTietTaiKhoan")
            {
                Report = new Report.QuyChungMotTamLong.Report_SoChiTietTaiKhoan_CacQuy();

                command1.CommandText = "spd_Report_SoDuDauKy_CacQuy_ByNgay";
                command1.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command1.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command1.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                command1.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_Report_SoDuDauKy_CacQuy_ByNgay;1";

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

                command4.CommandText = "spd_LuyKe_CacQuy";
                command4.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command4.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command4.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                adapter.SelectCommand = command4;
                adapter.Fill(table4);
                table4.TableName = "spd_LuyKe_CacQuy;1";

                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table2);
                dataSet.Tables.Add(table3);
                dataSet.Tables.Add(table4);

                Report.SetDataSource(dataSet);

                Report.SetParameterValue("_SoHieuTK", HeThongTaiKhoan1.GetHeThongTaiKhoan1(maTaiKhoan).SoHieuTK);
                Report.SetParameterValue("_tenTaiKhoan", HeThongTaiKhoan1.GetHeThongTaiKhoan1(maTaiKhoan).TenTaiKhoan);
                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);

            }
            else if (grd_DanhSachBC.ActiveNode.Key == "theodoitaitro")
            {
                Report = new Report.QuyChungMotTamLong.rpt_Report_TinhHinhThuChi_CacQuy();

                command1.CommandText = "spd_Report_QuaTrinhTaiTro";
                command1.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command1.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command1.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
                command1.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
                command1.Parameters.AddWithValue("@MaQuy", _maLoaiQuy);
                command1.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_Report_QuaTrinhTaiTro;1";

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

                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table2);
                dataSet.Tables.Add(table3);

                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);

            }
            else if (grd_DanhSachBC.ActiveNode.Key == "thuquytienmat")
            {
                // co xu ly trang in theo ky lien ke 
                int maky = getmaky(ngayBatDau.Month, ngayKetThuc.Year);
                if (maky == 0)
                {
                    MessageBox.Show(this, "Chưa tạo kỳ kế toán trong thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataSet = new DataSet();
                Report = new Report.QuyChungMotTamLong.rpt_Report_ThuQuyTienMat_CacQuy();

                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_tblSoChiTiet_CacQuy";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau.Date);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc.Date);
                command.Parameters.AddWithValue("@userId", ERP_Library.Security.CurrentUser.Info.UserID);
                command.Parameters.AddWithValue("@MaLoaiQuy", _maLoaiQuy);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_tblSoChiTiet_CacQuy;1";
                dataSet.Tables.Add(table);

                Report.SetDataSource(dataSet);
                Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_TuNgay", ngayBatDau.Date);
                Report.SetParameterValue("_DenNgay", ngayKetThuc.Date);
                Report.SetParameterValue("_tieuDeNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTieude);
                Report.SetParameterValue("_tieuDeThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTieude);

                Report.SetParameterValue("_tenNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTen);
                Report.SetParameterValue("_tenThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTen);


                Report.SetParameterValue("_tieuDeGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TieuDeTongGiamDoc);
                Report.SetParameterValue("_tenGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TenTongGiamDoc);

                // by Loc  set so tran Loai =1 bao cao theo so quy tien mat
                string _thang = ngayKetThuc.Date.Month.ToString() + "/" + ngayKetThuc.Date.Year.ToString();
                Report.SetParameterValue("p_thangnam", _thang);
                string _tentk;
                if (_maLoaiQuy == 0)
                {
                    _tentk = "Quỹ Chung Một Tấm Lòng";
                    Report.SetParameterValue("p_loaiquy", _tentk);
                }
                else
                {
                    _tentk = cmbu_Quy.ActiveRow.Cells["TenCacQuy"].Value.ToString();
                    Report.SetParameterValue("p_loaiquy", "Quỹ: " + _tentk);
                }


                int sotrangbd = 0, sorecordbd = 0;
                Laysotrangbatdautrongky(maky, 3, ref sotrangbd, ref sorecordbd);

                Report.SetParameterValue("_trangbd", sotrangbd);
                Report.SetParameterValue("_recordbd", sorecordbd);
                // 
                dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;

                // by Loc  set so tran Loai =1 bao cao theo so quy tien mat
                dlg.crytalView_HienThiReport.ShowLastPage();
                int _sotrang = dlg.crytalView_HienThiReport.GetCurrentPageNumber();
                int _sorecord = dataSet.Tables["spd_Report_tblSoChiTiet_CacQuy;1"].Rows.Count;

                Updatesotrangin(maky, _sotrang + sotrangbd, sotrangbd, 3, Report.Name, sorecordbd, _sorecord + sorecordbd);
            }
            else if (grd_DanhSachBC.ActiveNode.Key == "chitietthuquytienmat")
            {
                // co xu ly trang in theo ky lien ke 
                int maky = getmaky(ngayBatDau.Month, ngayKetThuc.Year);
                if (maky == 0)
                {
                    MessageBox.Show(this, "Chưa tạo kỳ kế toán trong thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataSet = new DataSet();
                Report = new Report.QuyChungMotTamLong.rpt_Report_ChiTietThuQuyTienMat_CacQuy();

                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_tblSoChiTiet_CacQuy";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau.Date);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc.Date);
                command.Parameters.AddWithValue("@userId", ERP_Library.Security.CurrentUser.Info.UserID);
                command.Parameters.AddWithValue("@MaLoaiQuy", _maLoaiQuy);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_tblSoChiTiet_CacQuy;1";
                dataSet.Tables.Add(table);

                Report.SetDataSource(dataSet);
                Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_TuNgay", ngayBatDau.Date);
                Report.SetParameterValue("_DenNgay", ngayKetThuc.Date);
                Report.SetParameterValue("_tieuDeNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTieude);
                Report.SetParameterValue("_tieuDeThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTieude);

                Report.SetParameterValue("_tenNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTen);
                Report.SetParameterValue("_tenThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTen);


                Report.SetParameterValue("_tieuDeGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TieuDeTongGiamDoc);
                Report.SetParameterValue("_tenGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TenTongGiamDoc);

                // by Loc  set so tran Loai =1 bao cao theo so quy tien mat
                string _thang = ngayKetThuc.Date.Month.ToString() + "/" + ngayKetThuc.Date.Year.ToString();
                //Report.SetParameterValue("p_thangnam", _thang);

                string _tentk = cmbu_Quy.ActiveRow.Cells["TenCacQuy"].Value.ToString();
                Report.SetParameterValue("p_loaiquy", "Quỹ: " + _tentk);

                //int sotrangbd = 0, sorecordbd = 0;
                //Laysotrangbatdautrongky(maky, 3, ref sotrangbd, ref sorecordbd);

                //Report.SetParameterValue("_trangbd", sotrangbd);
                //Report.SetParameterValue("_recordbd", sorecordbd);
                // 
                dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;

                // by Loc  set so tran Loai =1 bao cao theo so quy tien mat
                //dlg.crytalView_HienThiReport.ShowLastPage();
                //int _sotrang = dlg.crytalView_HienThiReport.GetCurrentPageNumber();
                //int _sorecord = dataSet.Tables["spd_Report_tblSoChiTiet_CacQuy;1"].Rows.Count;

                //Updatesotrangin(maky, _sotrang + sotrangbd, sotrangbd, 3, Report.Name, sorecordbd, _sorecord + sorecordbd);
            }
            else if (grd_DanhSachBC.ActiveNode.Key == "TongHopQuy")
            {
                dataSet = new DataSet();

                DateTime dt = new DateTime(DateTime.Today.Year, 1, 1);
                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReportCacQuyCMTL";
                // command.CommandText = "spd_Report_tblSoChiTiet_CacQuy";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau.Date);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc.Date);
                command.Parameters.AddWithValue("@NgayDauNam", dt);
                command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                command.Parameters.AddWithValue("@LoaiQuy", _maLoaiQuy);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "ReportQuyChungMotTamLong;1";
                dataSet.Tables.Add(table);


                ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);


                if (_maLoaiQuy == 0)
                {
                    Report = new Report.QuyChungMotTamLong.BangKeChungTu_CMTL();
                    Report.SetDataSource(dataSet);

                }
                else if (_maLoaiQuy == 1)
                {
                    Report = new Report.QuyChungMotTamLong.rptQuyChungMotTamLong();
                    Report.SetDataSource(dataSet);
                }
                else
                {
                    Report = new Report.QuyChungMotTamLong.rptQuyNgoiNhaMoUot();
                    Report.SetDataSource(dataSet);
                }
                Report.SetParameterValue("_tenCongViec", "Tất Cả");
                Report.SetParameterValue("_TieuDe", "BÁO CÁO QUỸ CHUNG MỘT LÒNG");
                Report.SetParameterValue("_keToanTruong", nguoiky.BptTen);
                Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                Report.SetParameterValue("_tenThuTruong", nguoiky.TenTongGiamDoc);
                Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_TuNgay", ngayBatDau.Date);
                Report.SetParameterValue("_DenNgay", ngayKetThuc.Date);
                Report.SetParameterValue("_NgayThangDauNam", Convert.ToDateTime(dt).Date);
                //dlg = new frmHienThiReport();
                //dlg.crytalView_HienThiReport.ReportSource = Report;
                //dlg.Show();
            }

            #region BoSung
            if (grd_DanhSachBC.ActiveNode.Key == "SoChiTietTaiKhoan_LoaiQuy")
            {
                Report = new Report.QuyChungMotTamLong.Report_SoChiTietTaiKhoan_CacQuy();

                command1.CommandText = "spd_Report_SoDuDauKy_CacQuy_ByNgay_LoaiQuy";
                command1.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command1.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command1.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                command1.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                command1.Parameters.AddWithValue("@MaLoaiQuy", _maLoaiQuy);
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_Report_SoDuDauKy_CacQuy_ByNgay;1";

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

                command4.CommandText = "spd_LuyKe_CacQuy_LoaiQuy";
                command4.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command4.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command4.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                command4.Parameters.AddWithValue("@MaLoaiQuy", _maLoaiQuy);
                adapter.SelectCommand = command4;
                adapter.Fill(table4);
                table4.TableName = "spd_LuyKe_CacQuy;1";

                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table2);
                dataSet.Tables.Add(table3);
                dataSet.Tables.Add(table4);

                Report.SetDataSource(dataSet);

                Report.SetParameterValue("_SoHieuTK", HeThongTaiKhoan1.GetHeThongTaiKhoan1(maTaiKhoan).SoHieuTK);
                Report.SetParameterValue("_tenTaiKhoan", HeThongTaiKhoan1.GetHeThongTaiKhoan1(maTaiKhoan).TenTaiKhoan);
                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);

            }
            else if (grd_DanhSachBC.ActiveNode.Key == "theodoitaitro_LoaiQuy")
            {
                Report = new Report.QuyChungMotTamLong.rpt_Report_TinhHinhThuChi_CacQuy();

                command1.CommandText = "spd_Report_QuaTrinhTaiTro_LoaiQuy";
                command1.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command1.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command1.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
                command1.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
                command1.Parameters.AddWithValue("@MaQuy", _maLoaiQuy);
                command1.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_Report_QuaTrinhTaiTro;1";

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

                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table2);
                dataSet.Tables.Add(table3);

                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);

            }
            else if (grd_DanhSachBC.ActiveNode.Key == "thuquytienmat_LoaiQuy")
            {
                // co xu ly trang in theo ky lien ke 
                int maky = getmaky(ngayBatDau.Month, ngayKetThuc.Year);
                if (maky == 0)
                {
                    MessageBox.Show(this, "Chưa tạo kỳ kế toán trong thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataSet = new DataSet();
                Report = new Report.QuyChungMotTamLong.rpt_Report_ThuQuyTienMat_CacQuy();

                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_tblSoChiTiet_CacQuy_LoaiQuy";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau.Date);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc.Date);
                command.Parameters.AddWithValue("@userId", ERP_Library.Security.CurrentUser.Info.UserID);
                command.Parameters.AddWithValue("@MaLoaiQuy", _maLoaiQuy);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_tblSoChiTiet_CacQuy;1";
                dataSet.Tables.Add(table);

                Report.SetDataSource(dataSet);
                Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_TuNgay", ngayBatDau.Date);
                Report.SetParameterValue("_DenNgay", ngayKetThuc.Date);
                Report.SetParameterValue("_tieuDeNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTieude);
                Report.SetParameterValue("_tieuDeThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTieude);

                Report.SetParameterValue("_tenNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTen);
                Report.SetParameterValue("_tenThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTen);


                Report.SetParameterValue("_tieuDeGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TieuDeTongGiamDoc);
                Report.SetParameterValue("_tenGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TenTongGiamDoc);

                // by Loc  set so tran Loai =1 bao cao theo so quy tien mat
                string _thang = ngayKetThuc.Date.Month.ToString() + "/" + ngayKetThuc.Date.Year.ToString();
                Report.SetParameterValue("p_thangnam", _thang);
                string _tentk;
                if (_maLoaiQuy == 0)
                {
                    _tentk = "Quỹ Chung Một Tấm Lòng";
                    Report.SetParameterValue("p_loaiquy", _tentk);
                }
                else
                {
                    _tentk = cmbu_Quy.ActiveRow.Cells["TenCacQuy"].Value.ToString();
                    Report.SetParameterValue("p_loaiquy", "Quỹ: " + _tentk);
                }


                int sotrangbd = 0, sorecordbd = 0;
                Laysotrangbatdautrongky(maky, 3, ref sotrangbd, ref sorecordbd);

                Report.SetParameterValue("_trangbd", sotrangbd);
                Report.SetParameterValue("_recordbd", sorecordbd);
                // 
                dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;

                // by Loc  set so tran Loai =1 bao cao theo so quy tien mat
                dlg.crytalView_HienThiReport.ShowLastPage();
                int _sotrang = dlg.crytalView_HienThiReport.GetCurrentPageNumber();
                int _sorecord = dataSet.Tables["spd_Report_tblSoChiTiet_CacQuy;1"].Rows.Count;

                Updatesotrangin(maky, _sotrang + sotrangbd, sotrangbd, 3, Report.Name, sorecordbd, _sorecord + sorecordbd);
            }
            else if (grd_DanhSachBC.ActiveNode.Key == "chitietthuquytienmat_LoaiQuy")
            {
                // co xu ly trang in theo ky lien ke 
                int maky = getmaky(ngayBatDau.Month, ngayKetThuc.Year);
                if (maky == 0)
                {
                    MessageBox.Show(this, "Chưa tạo kỳ kế toán trong thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataSet = new DataSet();
                Report = new Report.QuyChungMotTamLong.rpt_Report_ChiTietThuQuyTienMat_CacQuy();

                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_tblSoChiTiet_CacQuy_LoaiQuy";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau.Date);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc.Date);
                command.Parameters.AddWithValue("@userId", ERP_Library.Security.CurrentUser.Info.UserID);
                command.Parameters.AddWithValue("@MaLoaiQuy", _maLoaiQuy);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_tblSoChiTiet_CacQuy;1";
                dataSet.Tables.Add(table);

                Report.SetDataSource(dataSet);
                Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_TuNgay", ngayBatDau.Date);
                Report.SetParameterValue("_DenNgay", ngayKetThuc.Date);
                Report.SetParameterValue("_tieuDeNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTieude);
                Report.SetParameterValue("_tieuDeThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTieude);

                Report.SetParameterValue("_tenNguoiLap", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).NguoiLapTen);
                Report.SetParameterValue("_tenThuTruong", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).ThuTruongTen);


                Report.SetParameterValue("_tieuDeGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TieuDeTongGiamDoc);
                Report.SetParameterValue("_tenGiamDoc", ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID).TenTongGiamDoc);

                // by Loc  set so tran Loai =1 bao cao theo so quy tien mat
                string _thang = ngayKetThuc.Date.Month.ToString() + "/" + ngayKetThuc.Date.Year.ToString();
                //Report.SetParameterValue("p_thangnam", _thang);

                string _tentk = cmbu_Quy.ActiveRow.Cells["TenCacQuy"].Value.ToString();
                Report.SetParameterValue("p_loaiquy", "Quỹ: " + _tentk);

                //int sotrangbd = 0, sorecordbd = 0;
                //Laysotrangbatdautrongky(maky, 3, ref sotrangbd, ref sorecordbd);

                //Report.SetParameterValue("_trangbd", sotrangbd);
                //Report.SetParameterValue("_recordbd", sorecordbd);
                // 
                dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;

                // by Loc  set so tran Loai =1 bao cao theo so quy tien mat
                //dlg.crytalView_HienThiReport.ShowLastPage();
                //int _sotrang = dlg.crytalView_HienThiReport.GetCurrentPageNumber();
                //int _sorecord = dataSet.Tables["spd_Report_tblSoChiTiet_CacQuy;1"].Rows.Count;

                //Updatesotrangin(maky, _sotrang + sotrangbd, sotrangbd, 3, Report.Name, sorecordbd, _sorecord + sorecordbd);
            }
            else if (grd_DanhSachBC.ActiveNode.Key == "TongHopQuy_LoaiQuy")
            {
                dataSet = new DataSet();

                DateTime dt = new DateTime(DateTime.Today.Year, 1, 1);
                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReportCacQuyCMTL_LoaiQuy";
                // command.CommandText = "spd_Report_tblSoChiTiet_CacQuy";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau.Date);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc.Date);
                command.Parameters.AddWithValue("@NgayDauNam", dt);
                command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                command.Parameters.AddWithValue("@LoaiQuy", _maLoaiQuy);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "ReportQuyChungMotTamLong;1";
                dataSet.Tables.Add(table);


                ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);


                if (_maLoaiQuy == 0)
                {
                    Report = new Report.QuyChungMotTamLong.BangKeChungTu_CMTL();
                    Report.SetDataSource(dataSet);

                }
                else if (_maLoaiQuy == 1)
                {
                    Report = new Report.QuyChungMotTamLong.rptQuyChungMotTamLong();
                    Report.SetDataSource(dataSet);
                }
                else
                {
                    Report = new Report.QuyChungMotTamLong.rptQuyNgoiNhaMoUot();
                    Report.SetDataSource(dataSet);
                }
                Report.SetParameterValue("_tenCongViec", "Tất Cả");
                Report.SetParameterValue("_TieuDe", "BÁO CÁO QUỸ CHUNG MỘT LÒNG");
                Report.SetParameterValue("_keToanTruong", nguoiky.BptTen);
                Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                Report.SetParameterValue("_tenThuTruong", nguoiky.TenTongGiamDoc);
                Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_TuNgay", ngayBatDau.Date);
                Report.SetParameterValue("_DenNgay", ngayKetThuc.Date);
                Report.SetParameterValue("_NgayThangDauNam", Convert.ToDateTime(dt).Date);
                //dlg = new frmHienThiReport();
                //dlg.crytalView_HienThiReport.ReportSource = Report;
                //dlg.Show();
            }
            #endregion//BoSung


            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();

        }

        #region Events
        private void cb_Ky_SelectedIndexChanged(object sender, EventArgs e)
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

        private void cbu_SoHieuTK_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
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

        private void cmbu_DoiTuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(cmbu_DoiTuong, "TenDoiTuong");
            foreach (UltraGridColumn col in this.cmbu_DoiTuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Hidden = false;
            cmbu_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "Tên Đối Tượng";
            cmbu_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 0;
            cmbu_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Width = 350;

            cmbu_DoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            cmbu_DoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa chỉ";
            cmbu_DoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Width = 300;
            cmbu_DoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 1;
        }

        private void cmbu_Quy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Header.Caption = "Tên chương trình";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Header.VisiblePosition = 0;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Width = 350;

            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["IsThu"].Hidden = true;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["IsThu"].Header.Caption = "Là thu";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["IsThu"].Width = 100;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["IsThu"].Header.VisiblePosition = 1;
        }

        #region process by Loc
        private int getmaky(int thang, int nam)
        {
            int maky;
            using (SqlConnection cnn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cnn.Open();
                using (SqlCommand cm = cnn.CreateCommand())
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


        #region Dev

        private void InBaoCaoTongKetCongTacHoatDongQC1TL()
        {
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_BaoCaoTongKetCongTacHoatDongQC1TL");//PhieuNhapVatTu//
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

                frm.HienThiReport(_reportTemplate, dataSetdev);
                frm.Show();
            }
        }

        public bool Method_BaoCaoTongKetCongTacHoatDongQC1TL()
        {
            if (ChuaChon_TuNgay() || ChuaChon_DenNgay())
            {
                return false;
            }
            dataSetdev = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoTongKetCongTacHoatDongQC1TL";
                    cm.CommandTimeout = 300;//5 phút
                    cm.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                    cm.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    da.Fill(dataSetdev);
                    //dt.TableName = "DataResult";
                    //dataSetdev.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "tblHF";
                    dataSetdev.Tables.Add(dt);
                }

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dtu_NgayBatDau.Value;
                dr["DenNgay"] = dtu_NgayKetThuc.Value;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "tblNgay";
                dataSetdev.Tables.Add(dtngay);

            }
            return true;
        }
        #endregion//Dev


        private void grd_DanhSachBC_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            if (grd_DanhSachBC.ActiveNode.Key == "KeyBaoCaoTongKetCongTacHoatDongQC1TL")
            {
                Unlock_LockControl(false);
                UnlockControlForBaoCaoTongKetCongTacHoatDongQC1TL();
            }
            else
            {
                Unlock_LockControl(true);
            }
        }


    }
}
