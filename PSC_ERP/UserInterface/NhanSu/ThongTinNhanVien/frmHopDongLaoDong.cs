using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace PSC_ERP
{
    public partial class frmHopDongLaoDong : Form
    {
        #region Properties
        TenNhanVienList _TenNhanVienList;
        ThongTinNhanVienTongHopList _nhanVienList;
        ChucVuList _ChucVuList;
        HDLaoDongList _HDLaoDongList;
        HDLaoDong _HDLaoDong;
        HinhThucHopDongList _HinhThucHopDongList;
        NgachLuongCoBanList _NgachLuongCoBanList;
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        NhanVien _NhanVien;
         static long maNhanVien=0;
        static int loaiHD = 0;
        static int maHinhThucHD = 0;
        Util util = new Util();
        #endregion

        #region Contructor
        public frmHopDongLaoDong()
        {
            InitializeComponent();
            KhoiTao1();
            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblXoa.Enabled = false;
            tlslblIn.Enabled = false;
        }

        public frmHopDongLaoDong(ThongTinNhanVienTongHop thongTinNhanVienTongHop)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
        }
        #endregion

        #region Events

        #region KhoiTao

        public void KhoiTao1()
        {
            _HinhThucHopDongList = HinhThucHopDongList.GetHinhThucHopDongList();
            hinhThucHopDongListBindingSource.DataSource = _HinhThucHopDongList;

            _NgachLuongCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanList();
            ngachLuongCoBanListBindingSource.DataSource = _NgachLuongCoBanList;

            _ChucVuList = ChucVuList.GetChucVuList();
            chucVuListBindingSource.DataSource = _ChucVuList;
            numeu_HSBHXH.Value = Default_Ngay.GetDefault_Ngay().PhanTramBHXH;
            numeu_HSBHYT.Value = Default_Ngay.GetDefault_Ngay().PhanTramBHYT;
            numeu_SoTienCongDoan.Value = Default_Ngay.GetDefault_Ngay().TienCongDoan;
        }

        public void KhoiTao()
        {
            numeu_HSBHXH.Value = Default_Ngay.GetDefault_Ngay().PhanTramBHXH;
            numeu_HSBHYT.Value = Default_Ngay.GetDefault_Ngay().PhanTramBHYT;
            numeu_SoTienCongDoan.Value = Default_Ngay.GetDefault_Ngay().TienCongDoan;
           // _HDLaoDongList = HDLaoDongList.GetHDLaoDongList(_ThongTinNhanVienTongHop.MaNhanVien);
            _HDLaoDongList = HDLaoDongList.GetHDLaoDongList(maNhanVien);
            hDLaoDongListBindingSource.DataSource = _HDLaoDongList;
        }
        #endregion

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        } 

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            New();
        }
        private void New()
        {
            cmbu_ChucVuNguoiKy.Text = "";

            _HDLaoDong = HDLaoDong.NewHDLaoDong(maNhanVien, _NhanVien.MaChucVu, _NhanVien.MaChucDanh, Default_Ngay.GetDefault_Ngay().PhanTramBHXH, Default_Ngay.GetDefault_Ngay().PhanTramBHYT, Default_Ngay.GetDefault_Ngay().TienCongDoan);
            _HDLaoDongList.Add(_HDLaoDong);

            grdu_DanhSachHopDongLaoDong.ActiveRow = grdu_DanhSachHopDongLaoDong.Rows[_HDLaoDongList.Count - 1];
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            try
            {
                if (_HDLaoDongList != null)
                {
                    if (KT() == false)
                        return;
                    _HDLaoDongList.ApplyEdit();
                    _HDLaoDongList.Save();
                    MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KhoiTao();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DanhSachHopDongLaoDong.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdu_DanhSachHopDongLaoDong.DeleteSelectedRows();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            TimNhanVien();
        }
        private void TimNhanVien()
        {
            try
            {

                frmTimNhanVien _frmTimNhanVien = new frmTimNhanVien(7);
                if (_frmTimNhanVien.ShowDialog(this) != DialogResult.OK)
                {
                    if (_ThongTinNhanVienTongHop != null)
                    {
                        
                        maNhanVien = _ThongTinNhanVienTongHop.MaNhanVien;
                        _HDLaoDongList = HDLaoDongList.GetHDLaoDongList(maNhanVien);
                        hDLaoDongListBindingSource.DataSource = _HDLaoDongList;
                        //_HDLaoDong = (HDLaoDong)(hDLaoDongListBindingSource.Current);
                        _NhanVien = NhanVien.GetNhanVien(maNhanVien);
                        tlslblThem.Enabled = true;
                        tlslblLuu.Enabled = true;
                        tlslblXoa.Enabled = true;
                        tlslblIn.Enabled = true;
                        txt_MaNhanVienQL.Text = _ThongTinNhanVienTongHop.MaQLNhanVien;
                        txt_TenNhanVien.Text = _ThongTinNhanVienTongHop.TenNhanVien;
                        txtu_MaNhanVien.Text = _ThongTinNhanVienTongHop.MaQLNhanVien.ToString();
                        txt_TenChucVu.Text = _ThongTinNhanVienTongHop.TenChucVu;
                        //txtu_Nhom.Text = NgachLuongCoBan.GetNgachLuongCoBan(_NhanVien.MaNgachLuongBaoHiem).MaQuanLy;
                        //txtu_Bac.Text = BacLuongCoBan.GetBacLuongCoBan(_NhanVien.MaBacLuongBaoHiem).MaQuanLy;
                        //numeu_HSLCB.Value = _NhanVien.HeSoLuongBaoHiem;
                        numeu_HSBHXH.Value = Default_Ngay.GetDefault_Ngay().PhanTramBHXH;
                        numeu_HSBHYT.Value = Default_Ngay.GetDefault_Ngay().PhanTramBHYT;
                        numeu_SoTienCongDoan.Value = Default_Ngay.GetDefault_Ngay().TienCongDoan;
          
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (grdu_DanhSachHopDongLaoDong.Selected.Rows.Count != 1)
            {
                MessageBox.Show("Chọn 1 Hợp Đồng Để In","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (grdu_DanhSachHopDongLaoDong.Selected.Rows.Count == 1)
            {
                ReportDocument Report = new ReportDocument();
                if (txtu_MaNhanVien.Text != string.Empty)
                {

                    DataSet dataset = new DataSet();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;

                    command.CommandText = "spd_report_TblnsHopdonglaodong";
                    command.Parameters.AddWithValue("@SoHopDong", (string)grdu_DanhSachHopDongLaoDong.Selected.Rows[0].Cells["SoHopDong"].Value);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_report_TblnsHopdonglaodong;1";

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "hdld_CongTy";
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "hdld_CongTy;1";

                    SqlCommand command2 = new SqlCommand();
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.CommandText = "spd_Report_tblnsNguoikyHDLD";
                    command2.Parameters.AddWithValue("@SoHopDong", (string)grdu_DanhSachHopDongLaoDong.Selected.Rows[0].Cells["SoHopDong"].Value);
                    command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                    DataTable table2 = new DataTable();
                    adapter2.Fill(table2);
                    table2.TableName = "spd_Report_tblnsNguoikyHDLD;1";

                    SqlCommand command3 = new SqlCommand();
                    command3.CommandType = CommandType.StoredProcedure;
                    command3.CommandText = "spd_report_TblnsHopdonglaodong_DieuKhoan";
                    command3.Parameters.AddWithValue("@Loai", 1);
                    command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
                    DataTable table3 = new DataTable();
                    adapter3.Fill(table3);
                    table3.TableName = "spd_report_TblnsHopdonglaodong_DieuKhoan;1";

                    dataset.Tables.Add(table);
                    dataset.Tables.Add(table1);
                    dataset.Tables.Add(table2);
                    dataset.Tables.Add(table3);

                    Report.SetDataSource(dataset);

                    frmHienThiReport dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }

            }
        }

        private void cmbu_ChucVuNguoiKy_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChucVuNguoiKy.ActiveRow != null)
            {
                if ((int)cmbu_ChucVuNguoiKy.Value != 0)
                {
                    _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_ChucVu((int)cmbu_ChucVuNguoiKy.Value);
                    //_TenNhanVienList = TenNhanVienList.GetTenNhanVienChucVuList((int)cmbu_ChucVuNguoiKy.Value);
                    bindingSource1_ThongTinNhanVien.DataSource = _nhanVienList;
                    cmbu_NguoiKy.Text = " ";
                    cmbu_ChucVuNguoiKy.InitializeLayout += new InitializeLayoutEventHandler(cmbu_NguoiKy_InitializeLayout);
                   
                }
            }
        }

         #endregion

        #region Load
        private void cmbu_NguoiKy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = cmbu_ChucVuNguoiKy.Width;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["HeSoBu"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["PhuCapHC"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["HeSoLuongBoSung"].Hidden = true;
            //cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["HeSoLuongNoiBo"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["HeSoPhuCapChucVu"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["Cmnd"].Hidden = true;
            //cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["HeSoLuongCoBan"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["HeSoVuotKhung"].Hidden = true;
            //cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["HeSoPhu"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption ="Tên Người Ký";
            for (int i = 0; i < cmbu_NguoiKy.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                cmbu_NguoiKy.DisplayLayout.Bands[0].Columns[i].Hidden = true;
            }
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Người Ký";
            
            /*
            CardID
                MaBoPhan
            GioiTinh TenGioiTinh NgayCap MaNoiCap MaKiemNhiem TenKiemNhiem MaChucDanh NgaySinh MaNoiSinh
            MaChucVu MaTinhThanhQueQuan QuocTich MaTonGiao MaDanToc
             * */
        }
        private void grdu_DanhSachHopDongLaoDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["MaHopDongLaoDong"].Hidden = true;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["MaNguoiKy"].Hidden = true;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["MaChucDanh"].Hidden = true;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["TuNgay"].Hidden = true;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["DenNgay"].Hidden = true;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["DieuKhoanKhac"].Hidden = true;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = true;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = true;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["MaHinhThucHopDong"].Hidden = true;

            //grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Nhân Viên";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["MaNhanVien"].Width = 100;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["TenHinhThucHD"].Header.Caption = "Hình Thức Hợp Đồng";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["MaHinhThucHopDong"].Width = 120;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.Caption = "Số Hợp Đống";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["SoHopDong"].Width = 80;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["NgayKy"].Header.Caption = "Ngày Ký";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["NgayKy"].Width = 65;

            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["HeSoBHXH"].Header.Caption = "% BHXH";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["HeSoBHXH"].Width = 60;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["HeSoBHYT"].Header.Caption = "% BHYT";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["HeSoBHYT"].Width = 60;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["SoTienCongDoan"].Header.Caption = "Tiền Công Đoàn";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["SoTienCongDoan"].Width = 100;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 200;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["ThoiGianLamViec"].Header.Caption = "TG Làm Việc";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["ThoiGianLamViec"].Width = 80;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["DungCuLamViec"].Header.Caption = "Dụng Cụ Làm Việc";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["DungCuLamViec"].Width = 100;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["PhuongTienDiLamViec"].Header.Caption = "Phương Tiện Đi Làm Việc";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["PhuongTienDiLamViec"].Width = 150;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["CheDoDaoTao"].Header.Caption = "Chế Độ Đào Tạo";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["CheDoDaoTao"].Width = 100;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["CongViecPhaiLam"].Header.Caption = "Công Việc Phải Làm";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["CongViecPhaiLam"].Width = 150;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["NgheNghiep"].Header.Caption = "Nghề Nghiệp";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["NgheNghiep"].Width = 100;

            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["Mucluong"].Header.Caption = "Mức Lương";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["Mucluong"].Width = 100;

            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["Hinhthuctraluong"].Header.Caption = "Hình Thức Trả Lương";
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["Hinhthuctraluong"].Width = 100;

            //grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["MaHinhThucHopDong"].Header.VisiblePosition = 1;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.VisiblePosition = 2;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["NgayKy"].Header.VisiblePosition = 3;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["HeSoBHXH"].Header.VisiblePosition = 12;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["HeSoBHYT"].Header.VisiblePosition = 13;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["SoTienCongDoan"].Header.VisiblePosition = 14;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["ThoiGianLamViec"].Header.VisiblePosition = 16;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["DungCuLamViec"].Header.VisiblePosition = 17;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["PhuongTienDiLamViec"].Header.VisiblePosition = 18;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["CheDoDaoTao"].Header.VisiblePosition = 19;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["CongViecPhaiLam"].Header.VisiblePosition = 20;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["NgheNghiep"].Header.VisiblePosition = 21;
            grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 22;

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DanhSachHopDongLaoDong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
        }
        private void cmbu_ChucVuNguoiKy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["TenChucVu"].Width = cmbu_ChucVuNguoiKy.Width;
            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            //cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["MaNhomChucVu"].Hidden = true;
            //cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Hidden = true;
            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = true;
            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Hidden = true;

            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";

            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 0;
            
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            this.cmbu_ChucVuNguoiKy.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_ChucVuNguoiKy.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
          private void cmbu_HinhThucHopDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["MaHinhThucHopDong"].Hidden = true;
            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["ThoiHanHopDong"].Hidden = true;
            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["DonViKyHan"].Hidden = true;
            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = true;

            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["TenHinhThucHopDong"].Header.Caption = "Tên Hình Thức";
            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["TenHinhThucHopDong"].Header.VisiblePosition = 1;
            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["TenHinhThucHopDong"].Width = cmbu_HinhThucHopDong.Width;

            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            this.cmbu_HinhThucHopDong.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_HinhThucHopDong.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion     

        #region Process
        bool KT()
        {
            bool kq = false;
            if (txtu_MaNhanVien.Text != null)
            {
                kq = true;
            }
            else
            {
                MessageBox.Show(this, "Chưa Chọn Nhân Viên", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //cmbu_MaNhanVien.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }   
        bool KiemTraSoHopDongLuu()
        {
            bool kq = true;
            if (HDLaoDong.KiemTraSoHopDong(txtu_SoHopDong.Text) == 0)
            {
                kq = true;
            }
            else if (HDLaoDong.KiemTraSoHopDong(txtu_SoHopDong.Text) == 1)
            {
                MessageBox.Show(this, "Số Hợp Đồng Đã Tồn Tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kq = false;
                txtu_SoHopDong.Text = string.Empty;
                txtu_SoHopDong.Focus();
            }
            else
            {
                MessageBox.Show(this, "Số Hợp Đồng Bị Trùng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kq = false;
                txtu_SoHopDong.Text = string.Empty;
                txtu_SoHopDong.Focus();
            }
            return kq;
        }
        bool KiemTraSoHopDongCapNhat()
        {
            bool kq = false;
            if (HDLaoDong.KiemTraSoHopDong(txtu_SoHopDong.Text) != 1)
            {
                kq = true;
            }
            else
            {
                MessageBox.Show(this, "Số Hợp Đồng Đã Tồn Tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kq = false;
                txtu_SoHopDong.Text = string.Empty;
                txtu_SoHopDong.Focus();
            }
            return kq;
        }
        #endregion          

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _HDLaoDongList = HDLaoDongList.GetHDLaoDongList(maNhanVien);
            hDLaoDongListBindingSource.DataSource = _HDLaoDongList;
        }

        private void frmHopDongLaoDong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control&&e.KeyCode==Keys.F)
            {
                TimNhanVien();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                New();
            }
        }

        private void cmbu_HinhThucHopDong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_HinhThucHopDong.ActiveRow != null)
            {
                loaiHD = Convert.ToInt32(cmbu_HinhThucHopDong.Value);
            }
        }

        private void điềuKhoảnHĐLĐToolStripMenuItem_Click(object sender, EventArgs e)
        {          
          
            
                frmHDLD_Default frmDefault = new frmHDLD_Default(1);
                frmDefault.ShowDialog();
            
        }

        private void tlslblDKHD_ButtonClick(object sender, EventArgs e)
        {

        }

        private void txtu_SoHopDong_Leave(object sender, EventArgs e)
        {
           
        }

    }
}
