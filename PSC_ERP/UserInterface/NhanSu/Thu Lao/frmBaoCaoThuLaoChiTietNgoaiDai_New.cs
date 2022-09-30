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
    public partial class frmBaoCaoThuLaoNgoaiDai_New : Form
    {
        BoPhanList _BoPhanList;
        int maBophan = 0; long maNhanVien = 0;
        int maChuongTrinh = 0; int nguoiLap = 0;
        int thanhToan = -1; int nhapHo = -1;
        string tenNguoiLap = string.Empty;
        string _tenNguoiLap = string.Empty;
        string tenBanPhuTrach = string.Empty;
        string _tenBanPhuTrach = string.Empty;
        string tenThuTruong = string.Empty;
        string _tenThuTruong = string.Empty;
        ChuongTrinhList _chuongTrinhList;
        NhanVienNgoaiDaiList _nhanVienList;
        ERP_Library.Security.UserList _UserList;
        ChiTietGiayXacNhanList _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.NewChiTietGiayXacNhanList();
        KyTinhLuongList _kyTinhLuongList;
        int userID = CurrentUser.Info.UserID;
        public frmBaoCaoThuLaoNgoaiDai_New()
        {
            InitializeComponent();
            BindS_BoPhan.DataSource = typeof(BoPhanList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.NguoiLapListBindingSouce.DataSource = typeof(ERP_Library.Security.UserList);
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
            _UserList = ERP_Library.Security.UserList.GetUserList(ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            ERP_Library.Security.UserItem user = ERP_Library.Security.UserItem.NewUserItem("Tất Cả");
            _UserList.Insert(0, user);
            NguoiLapListBindingSouce.DataSource = _UserList;

            _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.GetChiTietGiayXacNhanListByBoPhanDen(ERP_Library.Security.CurrentUser.Info.MaBoPhan, Convert.ToInt32(nhapHo));
            ChiTietGiayXacNhan itemAdd = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0, "Không Có Giấy Xác Nhận");
            _chiTietGiayXacNhanList.Insert(0, itemAdd);
            this.GiayXacNhanList_bindingSource.DataSource = _chiTietGiayXacNhanList;
            cbChiTietGiayXacNhan.DataSource = GiayXacNhanList_bindingSource;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
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
                case "NodeChuyenTien":
                    Report = new Report.rptDanhSachThuLaoChiTiet_NgoaiDai_NVChuyenTien();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_NhanVienChuyenTien";
                    command.Parameters.AddWithValue("@TuKy", Convert.ToInt32(cmbu_TuKy.Value));
                    command.Parameters.AddWithValue("@DenKy", Convert.ToInt32(cmbu_DenKy.Value));
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
                    Report.SetParameterValue("_tuKy", cmbu_TuKy.Text);
                    Report.SetParameterValue("_denKy", cmbu_DenKy.Text);
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
                    Report = new Report.rptDanhSachThuLaoChiTiet_NgoaiDai_CMND();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    if (KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbu_TuKy.Value)).Nam <= 2013)
                    {
                        command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_ByCMND2013";
                    }
                    else if (KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbu_TuKy.Value)).Nam <= 2015)
                    {
                        command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_ByCMND2015";
                    }
                    else
                    {
                        command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_ByCMND";
                        command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    }
                    command.Parameters.AddWithValue("@TuKy", Convert.ToInt32(cmbu_TuKy.Value));
                    command.Parameters.AddWithValue("@DenKy", Convert.ToInt32(cmbu_DenKy.Value));
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
                    Report.SetParameterValue("_tuKy", cmbu_TuKy.Text);
                    Report.SetParameterValue("_denKy", cmbu_DenKy.Text);
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_PTTToan", cbThanhToan.Text);
                    Report.SetParameterValue("_TenBoPhanDangNhap", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "NodeXNTN":

                    Report = new Report.NhanSu.XacNhanThuNhapNew();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    if (KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbu_TuKy.Value)).Nam <= 2013)
                    {
                        command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_ByXacNhan2013";
                    }
                        else if (KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbu_TuKy.Value)).Nam <= 2015)
                    {
                        command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_ByXacNhan2015";
                    }
                    else
                    {
                        command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_ByXacNhan";
                        command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    }
                    command.Parameters.AddWithValue("@TuKy", Convert.ToInt32(cmbu_TuKy.Value));
                    command.Parameters.AddWithValue("@DenKy", Convert.ToInt32(cmbu_DenKy.Value));
                    command.Parameters.AddWithValue("@CMND", txt_CMND.Text);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.CommandTimeout = 240;
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_ByXacNhan;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("_tuKy", cmbu_TuKy.Text);
                    Report.SetParameterValue("_denKy", cmbu_DenKy.Text);
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_PTTToan", cbThanhToan.Text);
                    Report.SetParameterValue("@TuKy", Convert.ToInt32(cmbu_TuKy.Value));
                    Report.SetParameterValue("@DenKy", Convert.ToInt32(cmbu_DenKy.Value));
                    Report.SetParameterValue("@CMND", txt_CMND.Text);
                    Report.SetParameterValue("@MaBoPhan", maBophan);
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
                    command.Parameters.AddWithValue("@TuKy", Convert.ToInt32(cmbu_TuKy.Value));
                    command.Parameters.AddWithValue("@DenKy", Convert.ToInt32(cmbu_DenKy.Value));
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
                    Report.SetParameterValue("_tuKy", cmbu_TuKy.Text);
                    Report.SetParameterValue("_denKy", cmbu_DenKy.Text);
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_PTTToan", cbThanhToan.Text);
                    Report.SetParameterValue("_TenBoPhanDangNhap", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "NodeChuyenTien_TH":
                    Report = new Report.rptDanhSachThuLaoChiTiet_NgoaiDai_ChuyenTienTH();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_NhanVienChuyenTien_TH";
                    command.Parameters.AddWithValue("@TuKy", Convert.ToInt32(cmbu_TuKy.Value));
                    command.Parameters.AddWithValue("@DenKy", Convert.ToInt32(cmbu_DenKy.Value));
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
                    table.TableName = "spd_ThuLaoChuongTrinhByNhanVienNgoaiDai_NhanVienChuyenTien_TH;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("_tuKy", cmbu_TuKy.Text);
                    Report.SetParameterValue("_denKy", cmbu_DenKy.Text);
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
            if (cbNhanVien.ActiveRow != null)
            {
                maNhanVien = Convert.ToInt64(cbNhanVien.ActiveRow.Cells["MaNhanVien"].Value);
            }
        }
        private void ComboChanged()
        {
            //  _nhanVienList = TTNhanVienRutGonList.GetNhanVienListByBoPhanNganHang(maBophan,maLoaiNV, maNganHang,maNhanVien);
            _nhanVienList = NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiList(maBophan, 1);
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
            {
                cmbu_Bophan.Enabled = true;
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
        }

        private void cmbu_DenKy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_DenKy, "TenKy");
            foreach (UltraGridColumn col in this.cmbu_DenKy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cmbu_DenKy.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cmbu_DenKy.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cmbu_DenKy.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 0;
            cmbu_DenKy.DisplayLayout.Bands[0].Columns["TenKy"].Width = cbNhanVien.Width;
            cmbu_DenKy.DisplayLayout.Bands[0].Columns["MaKy"].Hidden = false;
            cmbu_DenKy.DisplayLayout.Bands[0].Columns["MaKy"].Header.Caption = "Mã Kỳ";
            cmbu_DenKy.DisplayLayout.Bands[0].Columns["MaKy"].Header.VisiblePosition = 1;
        }

        private void cmbu_TuKy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_TuKy, "TenKy");
            foreach (UltraGridColumn col in this.cmbu_TuKy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cmbu_TuKy.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cmbu_TuKy.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cmbu_TuKy.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 0;
            cmbu_TuKy.DisplayLayout.Bands[0].Columns["TenKy"].Width = cbNhanVien.Width;
            cmbu_TuKy.DisplayLayout.Bands[0].Columns["MaKy"].Hidden = false;
            cmbu_TuKy.DisplayLayout.Bands[0].Columns["MaKy"].Header.Caption = "Mã Kỳ";
            cmbu_TuKy.DisplayLayout.Bands[0].Columns["MaKy"].Header.VisiblePosition = 1;
        }
    }
}