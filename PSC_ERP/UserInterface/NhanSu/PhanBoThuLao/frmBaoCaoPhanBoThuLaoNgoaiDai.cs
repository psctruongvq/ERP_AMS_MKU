using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmBaoCaoPhanBoThuLaoNgoaiDai : Form
    {
        #region
        BoPhanList _BoPhanList;
        KyTinhLuongList _kyTinhLuongList;
        NhanVienNgoaiDaiList _nhanVienList;
        ChuongTrinhList _chuongTrinhList;
        PhanBoThuLaoList _phanBoThuLaoList;
        NguoiKyTen nguoiky = NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
        int userID = CurrentUser.Info.UserID;
        int maBoPhan = 0;
        long maNhanVien = 0;
        int maChuongTrinh = 0;
        int maPhanBoThuLao = 0;
        string tenBanPhuTrach = string.Empty;
        string _tenBanPhuTrach = string.Empty;
        string tenThuTruong = string.Empty;
        string _tenThuTruong = string.Empty;
        string tenNguoiLap = string.Empty;
        string _tenNguoiLap = string.Empty;
        #endregion

        public frmBaoCaoPhanBoThuLaoNgoaiDai()
        {
            InitializeComponent();
            LoadForm();
            treeReport.ExpandAll();
        }
        public void LoadForm()
        {
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            KyTinhLuong_BindingSource.DataSource = _kyTinhLuongList;

            _BoPhanList = BoPhanList.GetBoPhanListAll(userID);
            BoPhan_BindingSource.DataSource = _BoPhanList;

            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("Tất Cả");
            _chuongTrinhList.Insert(0, itemChuongTrinh);
            this.ChuongTrinh_BindingSource.DataSource = _chuongTrinhList;

            _nhanVienList = NhanVienNgoaiDaiList.NewNhanVienNgoaiDaiList();
            NhanVien_BindingSouce.DataSource = _nhanVienList;

        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            DataSet dataset;
            ReportDocument Report;
            frmHienThiReport dlg;
            SqlDataAdapter adapter;
            DataTable table; 
            string kiTenNguoiLap = "";
            string kiTenThuTruong = "";
            string kiTenBanPhuTrach = "";

            if (nguoiky.NguoiLapTieude.Trim() != "")
            {
                kiTenNguoiLap = "\r\n (Họ và tên)";
            }
            if (nguoiky.ThuTruongTieude.Trim() != "")
            {
                kiTenThuTruong = "\r\n (Họ và tên)";
            }
            if (nguoiky.BptTieude.Trim() != "")
            {
                kiTenBanPhuTrach = "\r\n (Họ và tên)";
            } 

            switch (treeReport.SelectedNode.Name)
            {
                case "NodeTHNV":
                    Report = new Report.DanhSachPhanBoThuLaoChiTiet__NgoaiDai_DSNVTH();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_DanhSachPhanBoThuLaoChuongTrinh_DSTHNgoaiDai";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    command.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);
                    command.Parameters.AddWithValue("@Loai", 0);
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.CommandTimeout = 90;
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_DanhSachPhanBoThuLaoChuongTrinh_DSTHNgoaiDai;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", nguoiky.NguoiLapTen);
                    Report.SetParameterValue("TenBPT", nguoiky.BptTen);
                    Report.SetParameterValue("TenThuTruong", nguoiky.ThuTruongTen);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    Report.SetParameterValue("NguoiLapBang", nguoiky.NguoiLapTieude + kiTenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", nguoiky.BptTieude + kiTenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", nguoiky.ThuTruongTieude + kiTenThuTruong);
                    Report.SetParameterValue("_PTTToan", "Chuyển Khoản");
                    Report.SetParameterValue("_TenBoPhanDangNhap", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;

                case "NodeTH":
                    Report = new Report.BaoCaoPhanBoThuLaoNgoaiDaiTongHop();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_DanhSachPhanBoThuLaoNhanVienNgoaiDai_DSTH";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    command.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.CommandTimeout = 0;
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_DanhSachPhanBoThuLaoNhanVienNgoaiDai_DSTH;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", nguoiky.NguoiLapTen);
                    Report.SetParameterValue("TenBPT", nguoiky.BptTen);
                    Report.SetParameterValue("TenThuTruong", nguoiky.ThuTruongTen);
                    Report.SetParameterValue("Tu_Ngay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    Report.SetParameterValue("Den_Ngay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    Report.SetParameterValue("NguoiLapBang", nguoiky.NguoiLapTieude + kiTenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", nguoiky.BptTieude + kiTenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", nguoiky.ThuTruongTieude + kiTenThuTruong);
                    Report.SetParameterValue("_PhuongThucThanhToan", "Chuyển Khoản");
                    Report.SetParameterValue("_BoPhan", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "NodeCTNV":
                    Report = new Report.DanhSachPhanBoThuLaoChiTiet_NgoaiDai();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_DanhSachPhanBoThuLaoNhanVienNgoaiDai_CTNV";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    command.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);
                    command.Parameters.AddWithValue("@Loai", 0);
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.CommandTimeout = 0;
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_DanhSachPhanBoThuLaoNhanVienNgoaiDai_CTNV;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", nguoiky.NguoiLapTen);
                    Report.SetParameterValue("TenBPT", nguoiky.BptTen);
                    Report.SetParameterValue("TenThuTruong", nguoiky.ThuTruongTen);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
                    Report.SetParameterValue("NguoiLapBang", nguoiky.NguoiLapTieude + kiTenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", nguoiky.BptTieude + kiTenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", nguoiky.ThuTruongTieude + kiTenThuTruong);
                    Report.SetParameterValue("_PTTToan", "Chuyển Khoản");
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

        private void cmbu_KyTinhLuong_AfterCloseUp(object sender, EventArgs e)
        {
            if (cmbu_KyTinhLuong.Value != null)
            {
                KyTinhLuong _kyTinhLuong = KyTinhLuong.GetKyTinhLuong((int)cmbu_KyTinhLuong.Value);

                dateTimePicker_TuNgay.Value = _kyTinhLuong.NgayBatDau;
                dateTimePicker_DenNgay.Value = _kyTinhLuong.NgayKetThuc;

                _phanBoThuLaoList = PhanBoThuLaoList.GetPhanBoThuLaoListByNgayLap(_kyTinhLuong.NgayBatDau, _kyTinhLuong.NgayKetThuc, ERP_Library.Security.CurrentUser.Info.UserID, 2);
                PhanBoThuLao itemPhanBoThuLao = PhanBoThuLao.NewPhanBoThuLaoKhoiTao("Tất Cả");
                _phanBoThuLaoList.Insert(0, itemPhanBoThuLao);
                PhanBoThuLao_BindingSource.DataSource = _phanBoThuLaoList;
            }
        }
        private void cmbu_NhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cmbu_NhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
           
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = cmbu_NhanVien.Width;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = false;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.Caption = "Mã Nhân Viên";
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.VisiblePosition = 1;
        }

        private void cmbu_BoPhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cmbu_BoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 1;

            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_BoPhan.Width;

            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;
  
        }

        private void cmbu_KyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["MaKy"].Hidden = false;

            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["MaKy"].Header.Caption = "Mã Kỳ";

            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Width = 150;
            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["MaKy"].Width = 60;

            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 0;
            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["MaKy"].Header.VisiblePosition = 1;
        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_ChuongTrinh, "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;

            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = cmbu_ChuongTrinh.Width;

            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã QL";

            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;
  
        }

        private void cmbu_PhanBoThuLao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            FilterCombo f = new FilterCombo(cmbu_PhanBoThuLao, "MaPhanBoThuLaoQL");
            t.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Header.Caption = "Mã Phân Bổ";
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.Caption = "Chương Trình";
            //cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].EditorComponent = cmbu_ChuongTrinh;

            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Header.VisiblePosition = 0;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.VisiblePosition = 1;
            //cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 3;

            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Width = 150;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Width = 150;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Width = 150;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 300;

            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Hidden = false;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Hidden = false;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;

            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';

        }

        private void cmbu_BoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_BoPhan.ActiveRow != null)
            {
                maBoPhan = Convert.ToInt32(cmbu_BoPhan.ActiveRow.Cells["MaBoPhan"].Value);
                cmbu_NhanVien.Value = null;

                _nhanVienList = NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiList(maBoPhan,0);
                NhanVienNgoaiDai itemNhanVien = NhanVienNgoaiDai.NewNhanVienNgoaiDai("Tất Cả");
                _nhanVienList.Insert(0, itemNhanVien);
                NhanVien_BindingSouce.DataSource = _nhanVienList;
            }
        }

        private void cmbu_NhanVien_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_NhanVien.ActiveRow != null)
            {
                maNhanVien = Convert.ToInt64(cmbu_NhanVien.ActiveRow.Cells["MaNhanVien"].Value);
        
            }
        }

        private void cmbu_ChuongTrinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.ActiveRow != null)
            {
                maChuongTrinh = Convert.ToInt32(cmbu_ChuongTrinh.ActiveRow.Cells["MaChuongTrinh"].Value);
            }
        }

        private void cmbu_PhanBoThuLao_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_PhanBoThuLao.ActiveRow != null)
            {
                maPhanBoThuLao = Convert.ToInt32(cmbu_PhanBoThuLao.ActiveRow.Cells["MaPhanBoThuLao"].Value);
            }
        }
     
    }
}