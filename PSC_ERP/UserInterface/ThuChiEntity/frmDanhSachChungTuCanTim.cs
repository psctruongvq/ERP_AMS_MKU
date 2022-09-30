using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Diagnostics;
using System.IO;

using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using PSC_ERP_Common.Ado.Net;
using PSC_ERPNew.Main.Reports;
using System.Data.Objects;
using System.Linq;
using PSC_ERP_Business.Main.Model.Context;
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;
//26_04_2014
namespace PSC_ERP.ThuChiEntity
{
    public partial class frmDanhSachChungTuCanTim : DevExpress.XtraEditors.XtraForm
    {
        #region properties

        ChungTuThuChi_DerivedFactory _factory = null;

        DateTime _tuNgay = DateTime.Today.AddMonths(-6).Date;
        DateTime _denNgay = DateTime.Today.Date;
        List<spd_DanhSachChungTuCanTim_Result> _ChungTuList = null;
        string _tenfrm = ""; // chung tu hoa don
        DataSet dataSet = new DataSet();
        app_users _user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);
        tblChungTu _chungTuCanDeCopy = null;
        private static int _maLoaiChungTu;

        public static int MaLoaiChungTu
        {
            get { return _maLoaiChungTu; }
        }
        public bool DaChon = false;
        long _maChungTuPrint = 0;
        public spd_DanhSachChungTuCanTim_Result _ChungTu1 = null;
        private List<spd_DanhSachChungTuCanTim_Result> _DsChungTuChon;
        public long MaChungTu
        {
            get { return _ChungTu1.MaChungTu; }
        }
        #endregion

        #region Initialize
        public frmDanhSachChungTuCanTim()
        {
            InitializeComponent();
            FormatForm();

        }

        public frmDanhSachChungTuCanTim(int maLoaiChungTu)
        {
            InitializeComponent();
            _maLoaiChungTu = maLoaiChungTu;
            KhoiTao();
            LoadChungTu();
            FormatForm();

        } 
        #endregion//Initialize



        #region Function

        private void KhoiTao()
        {
            tblDanhSachChungTuCanTimSource.DataSource = typeof(PSC_ERP_Business.Main.Model.spd_DanhSachChungTuCanTim_Result);
            //this.WindowState = FormWindowState.Maximized;
            dtmp_TuNgay.EditValue = _tuNgay;
            dtmp_DenNgay.EditValue = _denNgay;
            DesignGridView();

        }

        private void GetThongTinSearch()
        {
            _tuNgay = Convert.ToDateTime(dtmp_TuNgay.EditValue);
            _denNgay = Convert.ToDateTime(dtmp_DenNgay.EditValue); 
        }


        private void LoadChungTu()
        {
            GetThongTinSearch();
            if (_maLoaiChungTu != 0)
            {
                byte kieu;
                if (_tenfrm == "CTHD")
                {
                    kieu = 1;//Danh Dach ChungTu cho Hoa Don: @MaBoPhan ,@TuNgay ,@DenNgay 
                    _ChungTuList = spd_DanhSachChungTuCanTim_Factory.GetAll(kieu, _maLoaiChungTu, _user.MaBoPhan.Value, _tuNgay, _denNgay, _user.UserID).ToList();//(_tuNgay, _denNgay, _user.MaBoPhan.Value);
                    tblDanhSachChungTuCanTimSource.DataSource = _ChungTuList;
                }
                else
                {
                    kieu = 2;//Danh Sach ChungTu load theo MaLoaiChungTu: @MaLoaiChungtu ,@TuNgay ,@DenNgay ,@UserID
                    _ChungTuList = spd_DanhSachChungTuCanTim_Factory.GetAll(kieu, _maLoaiChungTu, _user.MaBoPhan.Value, _tuNgay, _denNgay, _user.UserID).ToList();
                    tblDanhSachChungTuCanTimSource.DataSource = _ChungTuList;
                }
                //}
            }
        }


        private void DesignGridView()
        {
            gridControl1.DataSource = tblDanhSachChungTuCanTimSource;
            HamDungChung.InitGridViewDev(gridView1,true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false,true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] {"Chon","SoChungTu", "NgayLap", "SoTien","TenDoiTuong", "DienGiai"},
                                new string[] {"Chọn In", "Số chứng từ", "Ngày lập", "Số tiền","Đối tượng", "Diễn giải" },
                                             new int[] {70, 120, 100, 100,200, 350 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Chon", "SoChungTu", "NgayLap", "SoTien", "TenDoiTuong", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoChungTu", "NgayLap", "SoTien", "TenDoiTuong", "DienGiai" });

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
            //
        }


        private bool KiemTraChonChungTuRow()
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần thực hiện!");
                return false;
            }
            return true;
        }


        private void CopyChungTu()
        {

            if (gridView1.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần copy.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            //
            long maChungTu = ((spd_DanhSachChungTuCanTim_Result)gridView1.GetFocusedRow()).MaChungTu;
            _chungTuCanDeCopy = ChungTu_Factory.New().Get_ChungTu_ByMaChungTu(maChungTu);

            if (_chungTuCanDeCopy.NgayLap.Value.Year <= Convert.ToDateTime("31-12-2013").Year)
            {
                MessageBox.Show("Chứng từ cũ năm [" + _chungTuCanDeCopy.NgayLap.Value.Year + "] không thể copy.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _chungTuCanDeCopy = null;
            }
        }

        private void PasteChungTu()
        {
            _factory = ChungTuThuChi_DerivedFactory.New();
            if (_chungTuCanDeCopy != null)
            {
                if (_chungTuCanDeCopy.MaChungTu != 0)
                {

                    //Khởi tạo chứng từ mới
                    tblChungTu chungTuMoi = null;
                    chungTuMoi = _factory.NewChungTuThuChi(_chungTuCanDeCopy.MaLoaiChungTu, DateTime.Now.Year);

                    //Lấy dữ liệu cho chứng từ mới
                    chungTuMoi.MaDoiTuongThuChi = _chungTuCanDeCopy.MaDoiTuongThuChi;
                    chungTuMoi.NgayLap = DateTime.Now.Date;
                    chungTuMoi.NgayThucHien = DateTime.Now.Date;
                    chungTuMoi.DienGiai = _chungTuCanDeCopy.DienGiai;
                    chungTuMoi.SoChungTuKemTheo = _chungTuCanDeCopy.SoChungTuKemTheo;
                    chungTuMoi.LoaiChungTu = _chungTuCanDeCopy.LoaiChungTu;
                    chungTuMoi.MaDoiTuong = _chungTuCanDeCopy.MaDoiTuong;
                    chungTuMoi.MaPhuongThucThanhToan = _chungTuCanDeCopy.MaPhuongThucThanhToan;
                    chungTuMoi.GhiSoCai = _chungTuCanDeCopy.GhiSoCai;
                    chungTuMoi.MaNguoiLap = _user.UserID;
                    chungTuMoi.MaBoPhanDangNhap = _user.MaBoPhan;

                    //--Lấy số chứng từ mới
                    int loaitien = _chungTuCanDeCopy.tblTienTe.MaLoaiTien.Value;
                    //chungTuMoi.SoChungTu = _factory.Get_NextSoChungThuChi_ByYear(_chungTuCanDeCopy.MaLoaiChungTu, DateTime.Now.Date.Year);
                    //--End  

                    //Lấy dữ liệu tiền tệ mới
                    chungTuMoi.tblTienTe.SoTien = _chungTuCanDeCopy.tblTienTe.SoTien;
                    chungTuMoi.tblTienTe.ThanhTien = _chungTuCanDeCopy.tblTienTe.ThanhTien;
                    chungTuMoi.tblTienTe.TiGiaQuyDoi = _chungTuCanDeCopy.tblTienTe.TiGiaQuyDoi;
                    chungTuMoi.tblTienTe.VietBangChu = _chungTuCanDeCopy.tblTienTe.VietBangChu;
                    chungTuMoi.tblTienTe.MaLoaiTien = _chungTuCanDeCopy.tblTienTe.MaLoaiTien;

                    //Lấy dữ liệu định khoản mới
                    chungTuMoi.tblDinhKhoan.LaMotNoNhieuCo = _chungTuCanDeCopy.tblDinhKhoan.LaMotNoNhieuCo;
                    chungTuMoi.tblDinhKhoan.NoCo = _chungTuCanDeCopy.tblDinhKhoan.NoCo;
                    chungTuMoi.tblDinhKhoan.GhiMucNganSach = _chungTuCanDeCopy.tblDinhKhoan.GhiMucNganSach;

                    //Lấy dữ liệu bút toán mới
                    foreach (tblButToan item in _chungTuCanDeCopy.tblDinhKhoan.tblButToans)
                    {
                        tblButToan butToanMoi = new tblButToan();
                        butToanMoi.NoTaiKhoan = item.NoTaiKhoan;
                        butToanMoi.CoTaiKhoan = item.CoTaiKhoan;
                        butToanMoi.SoTien = item.SoTien;
                        butToanMoi.DienGiai = item.DienGiai;
                        butToanMoi.MaDoiTuongCo = item.MaDoiTuongCo;
                        butToanMoi.MaDoiTuongNo = item.MaDoiTuongNo;
                        butToanMoi.MaSoQuy = item.MaSoQuy;


                        //Lấy bút toán chi phí sản xuất
                        foreach (tblCT_ChiPhiSanXuat chungTu_ChiPhiSanXuat in item.tblCT_ChiPhiSanXuat)
                        {
                            tblCT_ChiPhiSanXuat chungTu_ChiPhiSanXuatMoi = new tblCT_ChiPhiSanXuat();
                            chungTu_ChiPhiSanXuatMoi.SoChungTu = chungTuMoi.SoChungTu;
                            chungTu_ChiPhiSanXuatMoi.MaChuongTrinh = chungTu_ChiPhiSanXuat.MaChuongTrinh;
                            chungTu_ChiPhiSanXuat.TenChuongTrinh = chungTu_ChiPhiSanXuat.TenChuongTrinh;
                            chungTu_ChiPhiSanXuatMoi.SoTien = chungTu_ChiPhiSanXuat.SoTien;
                            chungTu_ChiPhiSanXuat.MaLoaiChiPhi = chungTu_ChiPhiSanXuat.MaLoaiChiPhi;
                            chungTu_ChiPhiSanXuatMoi.MaTaiKhoan = chungTu_ChiPhiSanXuat.MaTaiKhoan;
                            chungTu_ChiPhiSanXuatMoi.IsUpdate = chungTu_ChiPhiSanXuat.IsUpdate;

                            //Lấy chi thù lao
                            foreach (tblcnChiThuLao chiThuLao in chungTu_ChiPhiSanXuat.tblcnChiThuLaos)
                            {
                                tblcnChiThuLao chiThuLaoMoi = new tblcnChiThuLao();
                                chiThuLaoMoi.MaChungTu = chungTuMoi.MaChungTu;
                                chiThuLaoMoi.SoChungTu = chungTuMoi.SoChungTu;
                                chiThuLaoMoi.MaBoPhanGui = chiThuLao.MaBoPhanGui;
                                chiThuLaoMoi.MaBoPhanNhan = chiThuLao.MaBoPhanNhan;
                                chiThuLaoMoi.SoTien = chiThuLao.SoTien;
                                chiThuLaoMoi.GhiChu = chiThuLao.GhiChu;
                                chiThuLaoMoi.HoanTat = chiThuLao.HoanTat;
                                chiThuLaoMoi.TenBoPhanGui = chiThuLao.TenBoPhanGui;
                                chiThuLaoMoi.TenBoPhanNhan = chiThuLao.TenBoPhanNhan;
                                chiThuLaoMoi.MaChuongTrinh = chiThuLao.MaChuongTrinh;
                                chiThuLaoMoi.TenChuongTrinh = chiThuLao.TenChuongTrinh;
                                chiThuLaoMoi.SoTienDaNhap = chiThuLao.SoTienDaNhap;
                                chiThuLaoMoi.SoTienDaNhapNgoaiDai = chiThuLao.SoTienDaNhapNgoaiDai;
                                chiThuLaoMoi.SoTienConLai = chiThuLao.SoTienConLai;
                                chiThuLaoMoi.NgayLap = DateTime.Now.Date;
                                chiThuLaoMoi.SoTienSeNhap = chiThuLao.SoTienSeNhap;
                                chiThuLaoMoi.SoTienSeNhapNgoaiDai = chiThuLao.SoTienSeNhapNgoaiDai;
                                chiThuLaoMoi.NguoiLap = _user.UserID;
                                chiThuLaoMoi.MaLoaiKinhPhi = chiThuLao.MaLoaiKinhPhi;
                                chiThuLaoMoi.SoTienSeNhapNgoaiDai = chiThuLao.SoTienSeNhapNgoaiDai;
                                chiThuLaoMoi.NgayThucHienChi = chiThuLao.NgayThucHienChi;
                                chiThuLaoMoi.MaTaiKhoan = chiThuLao.MaTaiKhoan;

                                //Lấy chi thù lao nhân viên
                                foreach (tblChiThuLao_NhanVien chiThuLao_NhanVien in chiThuLao.tblChiThuLao_NhanVien)
                                {
                                    tblChiThuLao_NhanVien chiThuLao_NhanVienMoi = new tblChiThuLao_NhanVien();
                                    chiThuLao_NhanVienMoi.MaBoPhan_NV = chiThuLao_NhanVien.MaBoPhan_NV;
                                    chiThuLao_NhanVienMoi.MaNhanVien = chiThuLao_NhanVien.MaNhanVien;
                                    chiThuLao_NhanVienMoi.SoTien = chiThuLao_NhanVien.SoTien;
                                    chiThuLao_NhanVienMoi.TenBoPhan = chiThuLao_NhanVien.TenBoPhan;
                                    chiThuLao_NhanVienMoi.TenNhanVien = chiThuLao_NhanVien.TenNhanVien;
                                    chiThuLao_NhanVienMoi.LoaiNhanVien = chiThuLao_NhanVien.LoaiNhanVien;

                                    chiThuLaoMoi.tblChiThuLao_NhanVien.Add(chiThuLao_NhanVienMoi);

                                }
                                chungTu_ChiPhiSanXuatMoi.tblcnChiThuLaos.Add(chiThuLaoMoi);
                            }
                            //Lấy chi phí thực hiện
                            foreach (tblChiPhiThucHien chiPhiThucHien in chungTu_ChiPhiSanXuat.tblChiPhiThucHiens)
                            {
                                tblChiPhiThucHien chiPhiThucHienMoi = new tblChiPhiThucHien();
                                chiPhiThucHienMoi.TenChungTu = chungTuMoi.SoChungTu;
                                chiPhiThucHienMoi.TenChuongTrinh = chiPhiThucHien.TenChuongTrinh;
                                chiPhiThucHienMoi.MaChuongTrinh = chiPhiThucHien.MaChuongTrinh;
                                chiPhiThucHienMoi.MaDoiTuong = chiPhiThucHien.MaDoiTuong;
                                chiPhiThucHienMoi.TenDoiTuong = chiPhiThucHien.TenDoiTuong;
                                chiPhiThucHienMoi.DiaChi = chiPhiThucHien.DiaChi;
                                chiPhiThucHienMoi.SoTien = chiPhiThucHien.SoTien;
                                chiPhiThucHienMoi.DienGiai = chiPhiThucHien.DienGiai;
                                chiPhiThucHienMoi.NgayLap = DateTime.Now.Date;
                                chiPhiThucHienMoi.NguoiLap = _user.UserID;
                                chiPhiThucHienMoi.MaLoaiChiPhiSanXuat = chiPhiThucHien.MaLoaiChiPhiSanXuat;

                                chungTu_ChiPhiSanXuatMoi.tblChiPhiThucHiens.Add(chiPhiThucHienMoi);
                            }

                            //Lấy bút toán mục ngân sách
                            foreach (tblButToan_MucNganSach butToanMucNganSach in chungTu_ChiPhiSanXuat.tblButToan_MucNganSach)
                            {
                                tblButToan_MucNganSach butToanMucNganSachMoi = new tblButToan_MucNganSach();
                                butToanMucNganSachMoi.MaTieuMuc = butToanMucNganSach.MaTieuMuc;
                                butToanMucNganSachMoi.SoTien = butToanMucNganSach.SoTien;
                                butToanMucNganSachMoi.DienGiai = butToanMucNganSach.DienGiai;
                                butToanMoi.tblButToan_MucNganSach.Add(butToanMucNganSachMoi);
                                chungTu_ChiPhiSanXuatMoi.tblButToan_MucNganSach.Add(butToanMucNganSachMoi);
                            }

                            chungTuMoi.tblCT_ChiPhiSanXuat.Add(chungTu_ChiPhiSanXuatMoi);
                            butToanMoi.tblCT_ChiPhiSanXuat.Add(chungTu_ChiPhiSanXuatMoi);
                        }

                        #region ChungTu_HoaDon
                        ////Lấy chứng từ hóa đơn
                        //foreach (tblChungTu_HoaDon chungTu_HoaDon in item.tblChungTu_HoaDon)
                        //{
                        //    tblChungTu_HoaDon chungTu_HoaDonMoi = new tblChungTu_HoaDon();
                        //    chungTu_HoaDonMoi.MaHoaDon = chungTu_HoaDon.MaHoaDon;
                        //    chungTu_HoaDonMoi.MaPhieuNhapXuat = chungTu_HoaDon.MaPhieuNhapXuat;
                        //    chungTu_HoaDonMoi.SoTien = chungTu_HoaDon.SoTien;
                        //    chungTu_HoaDonMoi.NgayLap = DateTime.Now.Date;
                        //    chungTu_HoaDonMoi.NguoiLap = _user.UserID;
                        //    chungTuMoi.tblChungTu_HoaDon.Add(chungTu_HoaDonMoi);
                        //    butToanMoi.tblChungTu_HoaDon.Add(chungTu_HoaDonMoi);
                        //} 
                        #endregion//

                        //Thêm dữ liêu bút toán
                        chungTuMoi.tblDinhKhoan.tblButToans.Add(butToanMoi);
                    }

                    //Lưu chứng tù
                    _factory.SaveChanges(BusinessCodeEnum.BangKe_ThuChi.ToString());//lưu lại chứng từ

                    LoadChungTu();
                    MessageBox.Show("Copy Thành Công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        #region Methods Report

        public bool PhieuChi()//[dbo].[spd_ChuoiHachToan], [dbo].[spd_CongNo_PhieuChi]
        {

            int soChungTuKemTheo = 0;
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao spd_ChuoiHachToan
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChuoiHachToan";
                    cm.Parameters.AddWithValue("@MaChungTu", _maChungTuPrint);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dataSet);
                    dataSet.Tables[0].TableName = "spd_ChuoiHachToan";
                    dataSet.Tables[1].TableName = "spd_ChuoiTien";

                }
                //tao spd_CongNo_PhieuChi
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CongNo_PhieuChi";
                    cm.Parameters.AddWithValue("@MaPhieuChi", _maChungTuPrint);
                    cm.Parameters.AddWithValue("@SoCTKemTheo ", soChungTuKemTheo);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_CongNo_PhieuChi;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", _user.UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }

        public bool PhieuKeToan()//[dbo].[spd_BaoCaoChungTuGhiSo] 
        {

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao spd_BaoCaoChungTuGhiSo
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoChungTuGhiSo";
                    cm.Parameters.AddWithValue("@MaChungTu", _maChungTuPrint);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_BaoCaoChungTuGhiSo;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", _user.UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }

        public bool Inspd_CongNo_PhieuThu() //Thang
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChuoiHachToan";
                    cm.Parameters.AddWithValue("@MaChungTu", _maChungTuPrint);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dataSet);
                    dataSet.Tables[0].TableName = "spd_ChuoiHachToan";
                    dataSet.Tables[1].TableName = "spd_ChuoiTien";

                }
                //tao Inspd_CongNo_PhieuThu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CongNo_PhieuThu";
                    cm.Parameters.AddWithValue("@MaPhieuThu", _maChungTuPrint);
                    cm.Parameters.AddWithValue("@SoCTKemTheo", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_CongNo_PhieuThu";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 



                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", _user.UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }

        #endregion//Methods Report

        #region BoSung
        private void FormatForm()
        {
            btnCopyChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnPasteChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnPasteChungTu.Enabled = false;
            if(_maLoaiChungTu==2)
            {
                this.Text = "Danh Sách Chứng Từ Phiếu Thu";
            }
            else if (_maLoaiChungTu == 3)
            {
                this.Text = "Danh Sách Chứng Từ Phiếu Chi";
            }
            else if (_maLoaiChungTu == 16)
            {
                this.Text = "Danh Sách Chứng Từ Nghiệp Vụ Khác";
                if (_maLoaiChungTu == 16
                && BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).MaBoPhanQL != "DV02"
                )
                {
                    btnCapNhatSoChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                btnCopyChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnPasteChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }
        #endregion//BoSung

        #region Xuat Ra File Excel

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }
        #endregion//Xuat Ra File Excel


        private void InHangLoatPhieuChi(int loaiin)
        {
            DataSet _DataSet;
            ReportDocument Report=new ReportDocument();
            //ChungTuRutGon _ChungTu = ChungTuRutGon.NewChungTuRutGon();
            //ChungTuRutGonList _ChungTuList = ChungTuRutGonList.NewChungTuRutGonList();
            //for (int i=0; i < _DsChungTuChon.Count; i++)
            //{
            //    _ChungTu = ChungTuRutGon.GetChungTuRutGon(_DsChungTuChon[i].MaChungTu);
            //    _ChungTuList.Add(_ChungTu);
            //}

            spd_DanhSachChungTuCanTim_Result _ChungTu = new spd_DanhSachChungTuCanTim_Result();

            #region Phieu Chi
            //foreach (ChungTuRutGon ct in _ChungTuList)
            foreach(spd_DanhSachChungTuCanTim_Result ct in _DsChungTuChon) 
            {
                if (ct.Chon == true)
                {
                    _ChungTu = ct;
                    if (ChungTu.GetChungTu(ct.MaChungTu).DinhKhoan.ButToan.Count > 3 && loaiin == 5)
                    {
                        MessageBox.Show(ct.SoChungTu + " có quá nhiều chi tiết, không thể in trên khổ A5", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {

                        _DataSet = new DataSet();

                        SqlCommand command = new SqlCommand();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();

                        SqlCommand command1 = new SqlCommand();
                        command1.CommandType = CommandType.StoredProcedure;
                        command1.CommandText = "spd_REPORT_ReportHeader";
                        command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                        command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);


                        SqlCommand command2 = new SqlCommand();
                        command2.CommandType = CommandType.StoredProcedure;
                        command2.CommandText = "spd_LayNoTaiKhoan_1";
                        command2.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                        command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                        SqlCommand command3 = new SqlCommand();
                        command3.CommandType = CommandType.StoredProcedure;
                        command3.CommandText = "spd_LayCoTaiKhoan_1";
                        command3.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                        command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                        SqlCommand command4 = new SqlCommand();
                        command4.CommandType = CommandType.StoredProcedure;
                        command4.CommandText = "spd_LayNguoiKyTenCongNo";
                        command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                        command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                        SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                        DataTable table1 = new DataTable();
                        adapter1.Fill(table1);
                        table1.TableName = "spd_REPORT_ReportHeader;1";
                        _DataSet.Tables.Add(table1);

                        SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                        DataTable table2 = new DataTable();
                        adapter2.Fill(table2);
                        table2.TableName = "spd_LayNoTaiKhoan_1;1";
                        _DataSet.Tables.Add(table2);

                        SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
                        DataTable table3 = new DataTable();
                        adapter3.Fill(table3);
                        table3.TableName = "spd_LayCoTaiKhoan_1;1";
                        _DataSet.Tables.Add(table3);

                        SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                        DataTable table4 = new DataTable();
                        adapter4.Fill(table4);
                        table4.TableName = "spd_LayNguoiKyTenCongNo;1";
                        _DataSet.Tables.Add(table4);

                        if (loaiin == 5)
                        {
                            if (_ChungTu.MaLoaiChungTu == 3)// phiếu chi
                            {
                                //SqlCommand command = new SqlCommand();
                                command.CommandType = CommandType.StoredProcedure;
                                command.CommandText = "spd_CongNo_PhieuChi";
                                command.Parameters.AddWithValue("@MaPhieuChi", _ChungTu.MaChungTu);
                                command.Parameters.AddWithValue("@SoCTKemTheo", 0);
                                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                                Report = new Report.CongNo.PhieuChi();
                                adapter.Fill(table);
                                table.TableName = "spd_CongNo_PhieuChi;1";
                                _DataSet.Tables.Add(table);
                            }
                            else if (_ChungTu.MaLoaiChungTu == 2)// phiếu thu
                            {

                                // SqlCommand command = new SqlCommand();
                                command.CommandType = CommandType.StoredProcedure;
                                command.CommandText = "spd_CongNo_PhieuThu";
                                command.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);
                                command.Parameters.AddWithValue("@SoCTKemTheo", 0);
                                command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                                Report = new Report.CongNo.PhieuThu();
                                // SqlDataAdapter adapter = new SqlDataAdapter(command);
                                //DataTable table = new DataTable();
                                adapter.Fill(table);
                                table.TableName = "spd_CongNo_PhieuThu;1";
                                _DataSet.Tables.Add(table);

                            }
                            else if (_ChungTu.MaLoaiChungTu == 16)// phiếu thu
                            {
                                //SqlCommand command = new SqlCommand();

                                //Tách ra Tài chính và các ban khác Thành sửa
                                if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9)
                                {
                                    Report = new Report.CongNo.ChungTuGhiSo();
                                }
                                else
                                {
                                    Report = new Report.CongNo.ChungTuGhiSo_DVC2();
                                }
                                command.CommandType = CommandType.StoredProcedure;
                                command.CommandText = "spd_BaoCaoChungTuGhiSo";
                                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                                //DataTable table = new DataTable();
                                adapter.Fill(table);
                                table.TableName = "spd_BaoCaoChungTuGhiSo;1";
                                _DataSet.Tables.Add(table);

                            }
                        }
                        else if (loaiin == 4) //2) // In phieu thu
                        {
                            // Report = new Report.CongNo.PhieuChiA4();
                            if (_ChungTu.MaLoaiChungTu == 3)// phiếu chi
                            {
                                //SqlCommand command = new SqlCommand();
                                command.CommandType = CommandType.StoredProcedure;
                                command.CommandText = "spd_CongNo_PhieuChi";
                                command.Parameters.AddWithValue("@MaPhieuChi", _ChungTu.MaChungTu);
                                command.Parameters.AddWithValue("@SoCTKemTheo", 0);
                                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                                Report = new Report.CongNo.PhieuChiA4();
                                adapter.Fill(table);
                                table.TableName = "spd_CongNo_PhieuChi;1";
                                _DataSet.Tables.Add(table);
                            }
                            else if (_ChungTu.MaLoaiChungTu == 2)// phieu chi
                            {
                                // SqlCommand command = new SqlCommand();
                                command.CommandType = CommandType.StoredProcedure;
                                command.CommandText = "spd_CongNo_PhieuThu";
                                command.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);
                                command.Parameters.AddWithValue("@SoCTKemTheo", 0);
                                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                                Report = new Report.CongNo.PhieuThuA4();
                                // SqlDataAdapter adapter = new SqlDataAdapter(command);
                                //DataTable table = new DataTable();
                                adapter.Fill(table);
                                table.TableName = "spd_CongNo_PhieuThu;1";
                                _DataSet.Tables.Add(table);
                            }
                            else if (_ChungTu.MaLoaiChungTu == 16)// phieu chi
                            {
                                //SqlCommand command = new SqlCommand();

                                //Tách ra Tài chính và các ban khác Thành sửa
                                if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9)
                                {
                                    Report = new Report.CongNo.ChungTuGhiSoA4();
                                }
                                else
                                {
                                    Report = new Report.CongNo.ChungTuGhiSoA4_DVC2();
                                }
                                command.CommandType = CommandType.StoredProcedure;
                                command.CommandText = "spd_BaoCaoChungTuGhiSo";
                                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                                //DataTable table = new DataTable();
                                adapter.Fill(table);
                                table.TableName = "spd_BaoCaoChungTuGhiSo;1";
                                _DataSet.Tables.Add(table);
                            }

                            if (table.Rows.Count == 0)
                            {
                                MessageBox.Show(this, "Lưu dữ liệu trước khi in.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        Report.SetDataSource(_DataSet);
                        frmHienThiReport dlg = new frmHienThiReport();
                        dlg.crytalView_HienThiReport.ReportSource = Report;
                        Report.PrintToPrinter(1, false, -1, -1);
                    }


                }
            }
            //dlg.Show();
            #endregion


        }

        private void GetChungTuChon()
        {
            _DsChungTuChon =new List<spd_DanhSachChungTuCanTim_Result>();
            for(int i=0; i<_ChungTuList.Count;i++)
            {
                if (_ChungTuList[i].Chon)
                    _DsChungTuChon.Add(_ChungTuList[i]);
            }
        }

        private void FormatControlForForm()
        {
            if (_maLoaiChungTu == 16)//BangKe
            {
                btnCopyChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnPasteChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnCopyChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnPasteChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        #endregion//Methods

        #region Events
        

        private void GrdView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                _ChungTu1 = gridView1.GetFocusedRow() as spd_DanhSachChungTuCanTim_Result;
                if (_ChungTu1 != null)
                {
                    DaChon = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn chứng từ cần mở!");
                    return;
                }
            }
        }



        private void frmDanhSachChungTuCanTim_Load(object sender, EventArgs e)
        {
            //dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            //dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            LoadChungTu();
        }

        private void btnINA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxFocus.Focus();
            GetChungTuChon();
            if (_DsChungTuChon == null || _DsChungTuChon.Count() == 0)
            {

            }
            else if (_DsChungTuChon.Count() == 1)
            {
                _maChungTuPrint = _DsChungTuChon[0].MaChungTu;
                if (_maLoaiChungTu == 16)//Bảng Kê
                {
                    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuKeToanA4");//PhieuNhapVatTu//
                    if (_report != null)
                    {
                        DateTime dtDenNgay = DateTime.Today;
                        frmReport frm = new frmReport();

                        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _user.UserID, dtDenNgay);
                        if (_reportTemplate.Id == string.Empty)
                        {
                            _reportTemplate.Id = _report.Id;
                            _reportTemplate.UserID = _user.UserID;
                            _reportTemplate.DenNgay = dtDenNgay;
                        }
                        if (_report.TenPhuongThuc != "")
                        {
                            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                        }

                        frm.HienThiReport(_reportTemplate, dataSet);
                        frm.Show();
                    }
                }
                else if (_maLoaiChungTu == 2)//Phiếu Thu
                {
                    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuThuA4_2");//PhieuNhapVatTu//
                    if (_report != null)
                    {
                        DateTime dtDenNgay = DateTime.Today;
                        frmReport frm = new frmReport();

                        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _user.UserID, dtDenNgay);
                        if (_reportTemplate.Id == string.Empty)
                        {
                            _reportTemplate.Id = _report.Id;
                            _reportTemplate.UserID = _user.UserID;
                            _reportTemplate.DenNgay = dtDenNgay;
                        }
                        if (_report.TenPhuongThuc != "")
                        {
                            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                        }

                        frm.HienThiReport(_reportTemplate, dataSet);
                        frm.Show();
                    }
                }
                else if (_maLoaiChungTu == 3)//Phiếu Chi
                {
                    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuChi1A4");//PhieuNhapVatTu//
                    if (_report != null)
                    {
                        DateTime dtDenNgay = DateTime.Today;
                        frmReport frm = new frmReport();

                        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _user.UserID, dtDenNgay);
                        if (_reportTemplate.Id == string.Empty)
                        {
                            _reportTemplate.Id = _report.Id;
                            _reportTemplate.UserID = _user.UserID;
                            _reportTemplate.DenNgay = dtDenNgay;
                        }
                        if (_report.TenPhuongThuc != "")
                        {
                            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                        }

                        frm.HienThiReport(_reportTemplate, dataSet);
                        frm.Show();
                    }
                }
            }
            else
            {
                InHangLoatPhieuChi(4);
            }
            #region In 1 Chung Tu
            //if (KiemTraChonChungTuRow())
            //{
            //    _maChungTuPrint = ((spd_DanhSachChungTuCanTim_Result)gridView1.GetFocusedRow()).MaChungTu;
            //}
            //else return;

            //if (_maLoaiChungTu == 16)//Bảng Kê
            //{
            //    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuKeToanA4");//PhieuNhapVatTu//
            //    if (_report != null)
            //    {
            //        DateTime dtDenNgay = DateTime.Today;
            //        frmReport frm = new frmReport();

            //        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _user.UserID, dtDenNgay);
            //        if (_reportTemplate.Id == string.Empty)
            //        {
            //            _reportTemplate.Id = _report.Id;
            //            _reportTemplate.UserID = _user.UserID;
            //            _reportTemplate.DenNgay = dtDenNgay;
            //        }
            //        if (_report.TenPhuongThuc != "")
            //        {
            //            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
            //        }

            //        frm.HienThiReport(_reportTemplate, dataSet);
            //        frm.Show();
            //    }
            //}
            //else if (_maLoaiChungTu == 2)//Phiếu Thu
            //{
            //    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuThuA4_2");//PhieuNhapVatTu//
            //    if (_report != null)
            //    {
            //        DateTime dtDenNgay = DateTime.Today;
            //        frmReport frm = new frmReport();

            //        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _user.UserID, dtDenNgay);
            //        if (_reportTemplate.Id == string.Empty)
            //        {
            //            _reportTemplate.Id = _report.Id;
            //            _reportTemplate.UserID = _user.UserID;
            //            _reportTemplate.DenNgay = dtDenNgay;
            //        }
            //        if (_report.TenPhuongThuc != "")
            //        {
            //            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
            //        }

            //        frm.HienThiReport(_reportTemplate, dataSet);
            //        frm.Show();
            //    }
            //}
            //else if (_maLoaiChungTu == 3)//Phiếu Chi
            //{
            //    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuChi1A4");//PhieuNhapVatTu//
            //    if (_report != null)
            //    {
            //        DateTime dtDenNgay = DateTime.Today;
            //        frmReport frm = new frmReport();

            //        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _user.UserID, dtDenNgay);
            //        if (_reportTemplate.Id == string.Empty)
            //        {
            //            _reportTemplate.Id = _report.Id;
            //            _reportTemplate.UserID = _user.UserID;
            //            _reportTemplate.DenNgay = dtDenNgay;
            //        }
            //        if (_report.TenPhuongThuc != "")
            //        {
            //            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
            //        }

            //        frm.HienThiReport(_reportTemplate, dataSet);
            //        frm.Show();
            //    }
            //}
            #endregion//In 1 Chung Tu
        }

        private void btnINA5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxFocus.Focus();
            GetChungTuChon();
            if (_DsChungTuChon == null || _DsChungTuChon.Count() == 0)
            {

            }
            else if (_DsChungTuChon.Count() == 1)
            {
                _maChungTuPrint = _DsChungTuChon[0].MaChungTu;
                if (_maLoaiChungTu == 16)//Bảng Kê
                {
                    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuKeToanA5");//PhieuNhapVatTu//
                    if (_report != null)
                    {
                        DateTime dtDenNgay = DateTime.Today;
                        frmReport frm = new frmReport();

                        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _user.UserID, dtDenNgay);
                        if (_reportTemplate.Id == string.Empty)
                        {
                            _reportTemplate.Id = _report.Id;
                            _reportTemplate.UserID = _user.UserID;
                            _reportTemplate.DenNgay = dtDenNgay;
                        }
                        if (_report.TenPhuongThuc != "")
                        {
                            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                        }

                        frm.HienThiReport(_reportTemplate, dataSet);
                        frm.Show();
                    }
                }
                else if (_maLoaiChungTu == 2)//Phiếu Thu
                {
                    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuThuA5_2");//PhieuNhapVatTu//
                    if (_report != null)
                    {
                        DateTime dtDenNgay = DateTime.Today;
                        frmReport frm = new frmReport();

                        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _user.UserID, dtDenNgay);
                        if (_reportTemplate.Id == string.Empty)
                        {
                            _reportTemplate.Id = _report.Id;
                            _reportTemplate.UserID = _user.UserID;
                            _reportTemplate.DenNgay = dtDenNgay;
                        }
                        if (_report.TenPhuongThuc != "")
                        {
                            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                        }

                        frm.HienThiReport(_reportTemplate, dataSet);
                        frm.Show();
                    }
                }
                else if (_maLoaiChungTu == 3)//Phiếu Chi
                {
                    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuChi1A5");//PhieuNhapVatTu//
                    if (_report != null)
                    {
                        DateTime dtDenNgay = DateTime.Today;
                        frmReport frm = new frmReport();

                        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _user.UserID, dtDenNgay);
                        if (_reportTemplate.Id == string.Empty)
                        {
                            _reportTemplate.Id = _report.Id;
                            _reportTemplate.UserID = _user.UserID;
                            _reportTemplate.DenNgay = dtDenNgay;
                        }
                        if (_report.TenPhuongThuc != "")
                        {
                            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                        }

                        frm.HienThiReport(_reportTemplate, dataSet);
                        frm.Show();
                    }
                }
            }
            else
            {
                InHangLoatPhieuChi(5);
            }
            #region In 1 Chung Tu
            //if (KiemTraChonChungTuRow())
            //{
            //    _maChungTuPrint = ((spd_DanhSachChungTuCanTim_Result)gridView1.GetFocusedRow()).MaChungTu;
            //}
            //else return;
            //if (_maLoaiChungTu == 16)//Bảng Kê
            //{
            //    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuKeToanA5");//PhieuNhapVatTu//
            //    if (_report != null)
            //    {
            //        DateTime dtDenNgay = DateTime.Today;
            //        frmReport frm = new frmReport();

            //        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _user.UserID, dtDenNgay);
            //        if (_reportTemplate.Id == string.Empty)
            //        {
            //            _reportTemplate.Id = _report.Id;
            //            _reportTemplate.UserID = _user.UserID;
            //            _reportTemplate.DenNgay = dtDenNgay;
            //        }
            //        if (_report.TenPhuongThuc != "")
            //        {
            //            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
            //        }

            //        frm.HienThiReport(_reportTemplate, dataSet);
            //        frm.Show();
            //    }
            //}
            //else if (_maLoaiChungTu == 2)//Phiếu Thu
            //{
            //    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuThuA5_2");//PhieuNhapVatTu//
            //    if (_report != null)
            //    {
            //        DateTime dtDenNgay = DateTime.Today;
            //        frmReport frm = new frmReport();

            //        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _user.UserID, dtDenNgay);
            //        if (_reportTemplate.Id == string.Empty)
            //        {
            //            _reportTemplate.Id = _report.Id;
            //            _reportTemplate.UserID = _user.UserID;
            //            _reportTemplate.DenNgay = dtDenNgay;
            //        }
            //        if (_report.TenPhuongThuc != "")
            //        {
            //            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
            //        }

            //        frm.HienThiReport(_reportTemplate, dataSet);
            //        frm.Show();
            //    }
            //}
            //else if (_maLoaiChungTu == 3)//Phiếu Chi
            //{
            //    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuChi1A5");//PhieuNhapVatTu//
            //    if (_report != null)
            //    {
            //        DateTime dtDenNgay = DateTime.Today;
            //        frmReport frm = new frmReport();

            //        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _user.UserID, dtDenNgay);
            //        if (_reportTemplate.Id == string.Empty)
            //        {
            //            _reportTemplate.Id = _report.Id;
            //            _reportTemplate.UserID = _user.UserID;
            //            _reportTemplate.DenNgay = dtDenNgay;
            //        }
            //        if (_report.TenPhuongThuc != "")
            //        {
            //            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
            //        }

            //        frm.HienThiReport(_reportTemplate, dataSet);
            //        frm.Show();
            //    }
            //}
            #endregion//In 1 Chung Tu
        }

        private void btnPasteChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PasteChungTu();
        }

        private void btnCopyChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CopyChungTu();
            if (_chungTuCanDeCopy != null)
            {
                btnPasteChungTu.Enabled = true;
            }
        }

        private void btnCapNhatSoChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_maLoaiChungTu == 16)
            {
                frmCapNhatSoChungTu frm = new frmCapNhatSoChungTu(_maLoaiChungTu);
                if (frm.ShowDialog() != DialogResult.OK && frm.CapNhat)
                {
                    dtmp_TuNgay.EditValue = (object)frm.TuNgay;
                    dtmp_DenNgay.EditValue = (object)DateTime.Today.Date;
                    _ChungTuList = spd_DanhSachChungTuCanTim_Factory.GetAll(2, _maLoaiChungTu, 0, frm.TuNgay, DateTime.Today.Date, _user.UserID).ToList();//(MaLoaiChungTu, frm.TuNgay, DateTime.Today.Date);
                    this.tblDanhSachChungTuCanTimSource.DataSource = _ChungTuList;
                }
            }
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        private void btn_XuatRaExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        #endregion//Events

        
       




        
    }
}