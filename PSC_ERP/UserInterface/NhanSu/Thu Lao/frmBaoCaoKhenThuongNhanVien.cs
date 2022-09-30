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
    public partial class frmBaoCaoKhenThuongNhanVien : Form
    {
        BoPhanList _BoPhanList;
        int maBophan = 0; long maNhanVien = 0;
        LoaiPhuCapList _loaiPhuCapList;
        int maLoaiPhuCap = 0;
        int thanhToan = -1;
        int maKyTinhLuong = 0;
        string tenNguoiLap = string.Empty;
        string _tenNguoiLap = string.Empty;
        string tenBanPhuTrach = string.Empty;
        string _tenBanPhuTrach = string.Empty;
        string tenThuTruong = string.Empty;
        string _tenThuTruong = string.Empty;
        TTNhanVienRutGonList _nhanVienList;
        KyTinhLuongList _kyTinhLuongList;
        int userID = CurrentUser.Info.UserID;
        public frmBaoCaoKhenThuongNhanVien()
        {
            InitializeComponent();
            LoạiKhenThuongList_BindingSouce.DataSource = typeof(LoaiPhuCapList);
            BindS_BoPhan.DataSource = typeof(BoPhanList);
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            treeReport.ExpandAll();
        }

        private void frmBaoCaoThuLao_Load(object sender, EventArgs e)
        {
            _loaiPhuCapList = LoaiPhuCapList.GetLoaiPhuCapListByThuong();
            LoaiPhuCapChild itemAdd = LoaiPhuCapChild.NewLoaiPhuCapChild("Tất Cả");
            _loaiPhuCapList.Insert(0, itemAdd);
            LoạiKhenThuongList_BindingSouce.DataSource = _loaiPhuCapList;
            _BoPhanList = BoPhanList.GetBoPhanListAll(userID);
            BindS_BoPhan.DataSource = _BoPhanList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
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
            userID = CurrentUser.Info.UserID;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            DataSet dataset;
            ReportDocument Report;
            frmHienThiReport dlg;
            SqlDataAdapter adapter;
            DataTable table;
            switch (treeReport.SelectedNode.Name)
            {
                case "Node1":
                    Report = new Report.KhenThuongNhanVien();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReporttblnsKhenThuongNhanVien";
                    command.Parameters.AddWithValue("@TuNgay", dateTimePicker_TuNgay.Value.Date);
                    command.Parameters.AddWithValue("@DenNgay", dateTimePicker_DenNgay.Value.Date);

                    command.Parameters.AddWithValue("@MaLoaiPhuCap", maLoaiPhuCap);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@ThanhToan", thanhToan);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReporttblnsKhenThuongNhanVien;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);

                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);

                    Report.SetParameterValue("_tuNgay", dateTimePicker_TuNgay.Value.Date);
                    Report.SetParameterValue("_denNgay", dateTimePicker_DenNgay.Value.Date);
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
            if (cmbu_Bophan.Value != null)
            {
                maBophan = Convert.ToInt32(cmbu_Bophan.Value);
                cmbNhanVien.Value = null;
                cmbNhanVien.FilterByMaBoPhan(maBophan);
            }
            ComboChanged();
        }

        private void cbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            if (cmbNhanVien.Value != null)
            {
                maNhanVien = Convert.ToInt64(cmbNhanVien.Value);
            }
        }
        private void ComboChanged()
        {
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListByBoPhanNhanVien(maBophan, maNhanVien);
            TTNhanVienRutGon _nhanVienThem = TTNhanVienRutGon.NewTTNhanVienRutGon(0, "Tất Cả");
            _nhanVienList.Insert(0, _nhanVienThem);
            this.bindingSource2_nhanVien.DataSource = _nhanVienList;
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
            if (ultraComboEditor1.Value != null)
            {
                thanhToan = Convert.ToInt32(ultraComboEditor1.Value);
            }
        }

        private void cbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null)
            {
                maKyTinhLuong = Convert.ToInt32(cbKyTinhLuong.Value);
                KyTinhLuong ktl = KyTinhLuong.GetKyTinhLuong(maKyTinhLuong);
                dateTimePicker_TuNgay.Value = ktl.NgayBatDau;
                dateTimePicker_DenNgay.Value = ktl.NgayKetThuc;
            }
        }

        private void cmbu_ChucVu_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChucVu.Value != null)
            {
                maLoaiPhuCap = Convert.ToInt32(cmbu_ChucVu.Value);
            }
        }

        private void cbKyTinhLuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
        }

        private void cmbu_ChucVu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
        }

        private void cbNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            //FilterCombo f = new FilterCombo(cmbNhanVien, "TenNhanVien");
        }

        private void cmbu_Bophan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenNhanVien");
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
    }
}