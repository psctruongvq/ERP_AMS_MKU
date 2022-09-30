using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using ERP_Library.Security;

namespace PSC_ERP
{//
    public partial class frmBaoCaoDeNghiChuyenKhoan : Form
    {
        BoPhanList _BoPhanList;
        int maBophan = 0; long maNhanVien = 0;
        int maNganHang = 0; int thanhToan = -1; int nhapHo = -1;
        int maChuongTrinh = 0;
        int maLoaiNV = 0;
        int dinhMuc = -1; int maChiTietGiayXacNhan = 0;
        int maNguonChuongTrinh = 0;
        string tenNguoiLap=string.Empty;
        string _tenNguoiLap=string.Empty;
        string tenBanPhuTrach=string.Empty;
        string _tenBanPhuTrach=string.Empty;
        string tenThuTruong=string.Empty;
        string _tenThuTruong=string.Empty;
        ChuongTrinhList _chuongTrinhList;
        TTNhanVienRutGonList _nhanVienList;
        int userID = CurrentUser.Info.UserID;
        ChiTietGiayXacNhanList _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.NewChiTietGiayXacNhanList();
        public frmBaoCaoDeNghiChuyenKhoan()
        {
            InitializeComponent();
            BindS_BoPhan.DataSource = typeof(BoPhanList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ChiTietGiayXacNhanList);
            treeReport.ExpandAll();
        }

        private void frmBaoCaoThuLao_Load(object sender, EventArgs e)
        { 
            _BoPhanList = BoPhanList.GetBoPhanListAll(userID);            
            BindS_BoPhan.DataSource = _BoPhanList;

            //chuong trinh
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("Tất Cả");
            _chuongTrinhList.Insert(0, itemChuongTrinh);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.GetChiTietGiayXacNhanListByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            ChiTietGiayXacNhan itemAdd = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0, "Không Có Giấy Xác Nhận");
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
            cmbNhanVien.LoadData();
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
                
                case "Node0":
                    Report = new Report.BaoCaoDeNghiChuyenKhoan();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportDeNghiChuyenKhoan";
                    command.Parameters.AddWithValue("@TuNgay", dateTimePicker_TuNgay.Value.Date);
                    command.Parameters.AddWithValue("@DenNgay", dateTimePicker_DenNgay.Value.Date);
                    command.Parameters.AddWithValue("@UserID", userID);  
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@NhapHo", nhapHo);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaNganHang", maNganHang);
                    command.Parameters.AddWithValue("@ThucNhan", dinhMuc);
                   
                    command.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportDeNghiChuyenKhoan;1";
                   
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("Tu_Ngay", dateTimePicker_TuNgay.Value.Date);
                    Report.SetParameterValue("Den_Ngay", dateTimePicker_DenNgay.Value.Date);
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                   
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
        }

        private void cbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            maNhanVien = cmbNhanVien.MaNhanVien;
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
            if (cmbu_ChuongTrinh.Value != null)
            {
                maChuongTrinh = Convert.ToInt32(cmbu_ChuongTrinh.Value);
            }
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
        }

        private void cbChiTietGiayXacNhan_ValueChanged(object sender, EventArgs e)
        {
            if (cbChiTietGiayXacNhan.Value != null)
            {
                maChiTietGiayXacNhan = Convert.ToInt32(cbChiTietGiayXacNhan.Value);
            }
        }

        private void cbNhanVien_TextChanged(object sender, EventArgs e)
        {
        }
    }
}