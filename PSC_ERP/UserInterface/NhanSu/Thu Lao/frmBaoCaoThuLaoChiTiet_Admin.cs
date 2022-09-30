using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
   using ERP_Library.ThanhToan;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmBaoCaoThuLaoChiTiet_Admin : Form
    {
        BoPhanList _BoPhanList;
        int maBophan = 0; long maNhanVien = 0;
        int maNganHang = 0; int thanhToan = -1;
        int maChuongTrinh = 0; int userID = 0;
        int maLoaiNV = 0; int maNguon = 0;
        int maKyTinhLuong = 0;
        int maChungTu = 0;
        int maPhanCap = 0;
      
        string tenNguoiLap = string.Empty;
        string _tenNguoiLap = string.Empty;
        string tenBanPhuTrach = string.Empty;
        string _tenBanPhuTrach = string.Empty;
        string tenThuTruong = string.Empty;
        string _tenThuTruong = string.Empty;
       
        private string tenNganHang ="Ngân Hàng: Tất Cả";
        KyTinhLuongList _kyTinhLuongList;        
        ChuongTrinhList _chuongTrinhList;
        TTNhanVienRutGonList _nhanVienList;
        NguonList _nguonList;
        long maDeDeNghiChuyenKhoan = 0;
        DateTime tuNgay =Convert.ToDateTime("10/10/1990");
       
        DateTime denNgay = DateTime.MaxValue.Date;
        DateTime _tuNgayCK = Convert.ToDateTime("10/10/1990");
        DateTime _denNgayCK = DateTime.MaxValue.Date;
        ERP_Library.ThanhToan.DeNghiChuyenKhoanList _deNghiCKList;
        ChungTuNganHangList _chungTuNganHangList;
             
        public  frmBaoCaoThuLaoChiTiet_Admin()
        {
            InitializeComponent();
            BindS_BoPhan.DataSource = typeof(BoPhanList);
            this.bindingSource1_Nguon.DataSource =typeof(NguonList);           
            this.bindingSource1_ChuongTrinh.DataSource =typeof(ChuongTrinhList);            
            this.bindingSource1_KyTinhLuong.DataSource =typeof(KyTinhLuongList);            
            this.bindingSource1_DeNghiChuyenKhoan.DataSource = typeof(DeNghiChuyenKhoanList);
            this.bindingSource1_ChungTuNganHang.DataSource = typeof(ChungTuNganHangList);
        }

        private void frmBaoCaoThuLao_Load(object sender, EventArgs e)
        {
            _BoPhanList = BoPhanList.GetBoPhanListByPhanCap(maPhanCap);
            BoPhan itemaddBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _BoPhanList.Insert(0, itemaddBoPhan);
            BindS_BoPhan.DataSource = _BoPhanList;

            _nguonList = NguonList.GetNguonList();
            Nguon itemAdd = Nguon.NewNguon("Tất Cả");         
            _nguonList.Insert(0, itemAdd);
            this.bindingSource1_Nguon.DataSource = _nguonList;

            foreach (ERP_Library.NganHang nh in ERP_Library.NganHangList.GetNganHangList())
                cmbNganHang.Items.ValueList.ValueListItems.Add(nh.MaNganHang, nh.TenNganHang);

            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhListByNguon(maNguon);
            ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("Tất Cả");
            _chuongTrinhList.Insert(0, itemChuongTrinh);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
            cmbNguoiLap.Items.Add(0, "Không Có");
            cmbPTTaiChinh.Items.Add(0, "Không Có");
            cmbPTDonVi.Items.Add(0, "Không Có");
               foreach (ERP_Library.NguoiKyChild r in ERP_Library.NguoiKyList.GetNguoiKyList())
            {
                cmbNguoiLap.Items.Add(r.MaNguoiKy, r.TenNguoiKy);
                cmbPTTaiChinh.Items.Add(r.MaNguoiKy, r.TenNguoiKy);
                cmbPTDonVi.Items.Add(r.MaNguoiKy, r.TenNguoiKy);
            }
            gbChiTiet.Enabled = true;
            //if (ERP_Library.Security.CurrentUser.IsAdmin && ERP_Library.Security.CurrentUser.Info.MaCongTy == 1)
            //    userID = 0;
            //else
                userID = ERP_Library.Security.CurrentUser.Info.UserID;

            _deNghiCKList = DeNghiChuyenKhoanList.GetDeNghiChuyenKhoanAllList();
            this.bindingSource1_DeNghiChuyenKhoan.DataSource = _deNghiCKList;

            _chungTuNganHangList = ChungTuNganHangList.GetChungTuNganHangList(_tuNgayCK,_denNgayCK,0);
            ChungTuNganHang _itemAdd = ChungTuNganHang.NewChungTuNganHang("Tất Cả");
            _chungTuNganHangList.Insert(0, _itemAdd);
            this.bindingSource1_ChungTuNganHang.DataSource = _chungTuNganHangList;
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
                    Report = new Report.rptDanhSachThuLaoChiTietTheoNguon();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportBaoCaoThuLaoTheoNguon";                 

                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@TuNgay", _tuNgayCK);
                    command.Parameters.AddWithValue("@DenNgay", _denNgayCK);
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaNguon", maNguon);
                    command.Parameters.AddWithValue("@MaDeNghiChuyenKhoan", maDeDeNghiChuyenKhoan);
                    command.Parameters.AddWithValue("@MaChungTuNganHang",maChungTu);
                    command.Parameters.AddWithValue("@MaPhanCap", maPhanCap);
                    command.Parameters.AddWithValue("@MaNganHang", maNganHang);
                    command.Parameters.AddWithValue("@UserID", userID);  
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                     adapter = new SqlDataAdapter(command);
                     table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportBaoCaoThuLaoTheoNguon;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);

                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_TuNgay", _tuNgayCK);
                    Report.SetParameterValue("_DenNgay", _denNgayCK);
                    Report.SetParameterValue("_tenNganHang", tenNganHang);
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
            }
            ComboChanged();
        }

        private void cbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            if (cbNhanVien.Value != null)
            {
                maNhanVien = Convert.ToInt64(cbNhanVien.Value);
            }            
        }
        private void ComboChanged()
        {
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListByBoPhanNhanVien(maBophan, maNhanVien);
            TTNhanVienRutGon _nhanVienThem = TTNhanVienRutGon.NewTTNhanVienRutGon(0, "Tất Cả");
            _nhanVienList.Insert(0, _nhanVienThem);
            this.bindingSource2_nhanVien.DataSource = _nhanVienList;
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
            switch (treeReport.SelectedNode.Name)
            {
                //case "Node1":
                //    gbChiTiet.Enabled = false;
                //    lbGhiChu.Text = "Báo Cáo thù lao chi tiết cho từng nhân viên điều kiện: Từ ngày->Đến ngày";
                //    break;
                //case "Node2":
                //    gbChiTiet.Enabled = false;
                //    lbGhiChu.Text = "Báo Cáo thù lao chi tiết cho từng nhân viên theo phiếu chi điều kiện: Từ ngày->Đến ngày";
                //    break;
                //case "Node3":
                //    gbChiTiet.Enabled = true;
                //    lbGhiChu.Text = "Báo Cáo thù lao theo bộ phận được phân quyền điều kiện: Điều kiện chi tiết";
                //    break;
                //case "Node4":
                //    gbChiTiet.Enabled = true;
                //    lbGhiChu.Text = "Báo Cáo thù lao chuyển đi ngân hàng của nhân viên từng bộ phận được phân phân quyền điều kiện: Điều kiện chi tiết";
                //    break;
                //default:
                //    lbGhiChu.Text = "";
                //    break;
                    
            }
        }

        private void cbNguon_ValueChanged(object sender, EventArgs e)
        {
            if (cbNguon.Value != null)
            {
                maNguon = Convert.ToInt32(cbNguon.Value);
            }
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhListByNguon(maNguon);
            ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("Tất Cả");
            _chuongTrinhList.Insert(0, itemChuongTrinh);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;
        }

        private void cbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null)
            {
                maKyTinhLuong = Convert.ToInt32(cbKyTinhLuong.Value);
                KyTinhLuong ktl=KyTinhLuong.GetKyTinhLuong(maKyTinhLuong);
                dateTuNgay1.Value = ktl.NgayBatDau;
                dateDenNgay1.Value = ktl.NgayKetThuc;
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

        private void ultraCombo1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(ultraCombo1, "So");
            foreach (UltraGridColumn col in this.ultraCombo1.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            ultraCombo1.DisplayLayout.Bands[0].Columns["So"].Hidden = false;
            ultraCombo1.DisplayLayout.Bands[0].Columns["So"].Header.Caption = "Phiếu Đề Nghị";
            ultraCombo1.DisplayLayout.Bands[0].Columns["So"].Header.VisiblePosition = 0;

            ultraCombo1.DisplayLayout.Bands[0].Columns["LyDo"].Hidden = false;
            ultraCombo1.DisplayLayout.Bands[0].Columns["LyDo"].Header.Caption = "Lý Do";
            ultraCombo1.DisplayLayout.Bands[0].Columns["LyDo"].Header.VisiblePosition = 1;
            ultraCombo1.DisplayLayout.Bands[0].Columns["LyDo"].Width = 250;

            ultraCombo1.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            ultraCombo1.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            ultraCombo1.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            ultraCombo1.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            ultraCombo1.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            //ultraCombo1.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Còn Lại";
            //ultraCombo1.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 2;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "#,###";
            //ultraCombo1.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            //ultraCombo1.DisplayLayout.Bands[0].Columns["SoTienThanhToan"].Hidden = false;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["SoTienThanhToan"].Header.Caption = "Số Tiền Thanh Toán";
            //ultraCombo1.DisplayLayout.Bands[0].Columns["SoTienThanhToan"].Header.VisiblePosition = 2;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["SoTienThanhToan"].Format = "#,###";
            //ultraCombo1.DisplayLayout.Bands[0].Columns["SoTienThanhToan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            //ultraCombo1.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            //ultraCombo1.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 2;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["TongTien"].Format = "#,###";
            //ultraCombo1.DisplayLayout.Bands[0].Columns["TongTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            ultraCombo1.DisplayLayout.Bands[0].Columns["NganHangNhan"].Hidden = false;
            ultraCombo1.DisplayLayout.Bands[0].Columns["NganHangNhan"].Header.Caption = "Ngân Hàng Nhận";
            ultraCombo1.DisplayLayout.Bands[0].Columns["NganHangNhan"].Header.VisiblePosition = 3;

            ultraCombo1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraCombo1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            ultraCombo1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 4;
            ultraCombo1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 250;

        }

        private void ultraCombo1_ValueChanged(object sender, EventArgs e)
        {
            if (ultraCombo1.Value !=null)
            {
                maDeDeNghiChuyenKhoan = Convert.ToInt64(ultraCombo1.Value);
            }
        }

   
        private void  PhieuDeNghiValueChanged(DateTime tuNgay,DateTime denNgay)
        {
            _deNghiCKList = DeNghiChuyenKhoanList.GetDeNghiChuyenKhoanByNgayLap(tuNgay, denNgay);
            DeNghiChuyenKhoan itemAdd = DeNghiChuyenKhoan.NewDeNghiChuyenKhoan("Tất Cả");
            _deNghiCKList.Insert(0, itemAdd);
            this.bindingSource1_DeNghiChuyenKhoan.DataSource = _deNghiCKList;
        }

    

      

        private void cbKyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbKyTinhLuong, "TenKy");
        }

        private void cbNguon_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbNguon, "TenNguon");
        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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

        private void cbNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbNhanVien, "TenNhanVien");
        }

        private void cbChungTu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChungTu, "So");
            foreach (UltraGridColumn col in this.ultraCombo1.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Olive;//x =  //= System.Drawing.w;//Navy
              //  col.Hidden = true;
            }
            ultraCombo1.DisplayLayout.Bands[0].Columns["So"].Hidden = false;
            ultraCombo1.DisplayLayout.Bands[0].Columns["So"].Header.Caption = "Số Chứng Từ";
            ultraCombo1.DisplayLayout.Bands[0].Columns["So"].Header.VisiblePosition = 0;

            ultraCombo1.DisplayLayout.Bands[0].Columns["Ngay"].Hidden = false;
            ultraCombo1.DisplayLayout.Bands[0].Columns["Ngay"].Header.Caption = "Ngày";
            ultraCombo1.DisplayLayout.Bands[0].Columns["Ngay"].Header.VisiblePosition = 1;
            ultraCombo1.DisplayLayout.Bands[0].Columns["Ngay"].Width = 90;

            ultraCombo1.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            ultraCombo1.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            ultraCombo1.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 2;

            //ultraCombo1.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            //ultraCombo1.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 250;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;

            //ultraCombo1.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            //ultraCombo1.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 4;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 250;
        }

        private void cbChungTu_ValueChanged(object sender, EventArgs e)
        {
            if (cbChungTu.Value != null)
            {
                maChungTu = Convert.ToInt32(cbChungTu.Value);
            }
        }

      

        private void dateDenNgay1_ValueChanged(object sender, EventArgs e)
        {
            object obj = dateDenNgay1.Value;
            if (obj == null)
            {
                _denNgayCK = DateTime.MaxValue.Date;
            }
            else
            {
              _denNgayCK=  Convert.ToDateTime(dateDenNgay1.Value);
            }
            _chungTuNganHangList = ChungTuNganHangList.GetChungTuNganHangList(_tuNgayCK, _denNgayCK,0);
            ChungTuNganHang _itemAdd = ChungTuNganHang.NewChungTuNganHang("Tất Cả");
            _chungTuNganHangList.Insert(0, _itemAdd);
            this.bindingSource1_ChungTuNganHang.DataSource = _chungTuNganHangList;
        }

        private void dateTuNgay1_ValueChanged(object sender, EventArgs e)
        {
            object obj = dateTuNgay1.Value;
            if (obj == null)
            {
                _tuNgayCK = dateTuNgay1.MinDate.Date;
            }
            else
            {
                _tuNgayCK = Convert.ToDateTime(dateTuNgay1.Value);
            }
            _chungTuNganHangList = ChungTuNganHangList.GetChungTuNganHangList(_tuNgayCK, _denNgayCK,0);
            ChungTuNganHang _itemAdd = ChungTuNganHang.NewChungTuNganHang("Tất Cả");
            _chungTuNganHangList.Insert(0, _itemAdd);
            this.bindingSource1_ChungTuNganHang.DataSource = _chungTuNganHangList;
        }

        private void dateTuNgay_ValueChanged(object sender, EventArgs e)
        {
            object obj = dateTuNgay.Value;
            if (obj == null)
            {
                tuNgay = dateTuNgay1.MinDate.Date;
            }
            else
            {
                tuNgay = Convert.ToDateTime(dateTuNgay.Value);
            }
            PhieuDeNghiValueChanged(tuNgay, denNgay);
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            object obj = dateDenNgay.Value;
            if (obj == null)
            {
                denNgay = DateTime.MinValue.Date;
            }
            else
            {
                denNgay = Convert.ToDateTime(dateDenNgay.Value);
            }
            PhieuDeNghiValueChanged(tuNgay, denNgay);
        }

        private void ultraComboEditor1_ValueChanged(object sender, EventArgs e)
        {
            if (cbPhanCap.Value != null)
            {
                maPhanCap = Convert.ToInt32(cbPhanCap.Value);
            }
            _BoPhanList = BoPhanList.GetBoPhanListByPhanCap(maPhanCap);
            BoPhan itemaddBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _BoPhanList.Insert(0, itemaddBoPhan);
            BindS_BoPhan.DataSource = _BoPhanList;
        }

        private void cmbNganHang_ValueChanged(object sender, EventArgs e)
        {
            if (cmbNganHang.Value != null)
            {
                maNganHang = Convert.ToInt32(cmbNganHang.Value);
               
            }
            if (maNganHang == 0)
            {
                tenNganHang = "Ngân Hàng: Tất Cả";
            }
            else
            {
                tenNganHang = "Ngân Hàng: " + cmbNganHang.Text;
            }
        }
    }
}