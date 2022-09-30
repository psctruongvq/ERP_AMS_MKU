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
//26_04_2014
namespace PSC_ERP.ThuChiEntity
{
    public partial class frmTimDanhSachChungTu : DevExpress.XtraEditors.XtraForm
    {
       

        #region properties

        ChungTuThuChi_DerivedFactory _factory = null;
        tblChungTu _chungTu = null;

        DateTime _tuNgay = DateTime.Today.AddMonths(-6).Date;
        DateTime _denNgay = DateTime.Today.Date;
        IQueryable<tblChungTu> _ChungTuList = null;
        string _tenfrm = ""; // chung tu hoa don
        DataSet _dataSet = new DataSet();
        app_users _user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);
        tblChungTu _chungTuCanDeCopy = null;
        private static int _maLoaiChungTu;
        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

        public static int MaLoaiChungTu
        {
            get { return _maLoaiChungTu; }
        }
        public bool DaChon = false;
        public tblChungTu _ChungTu1 = null;
        public long MaChungTu
        {
            get { return _ChungTu1.MaChungTu; }
        }
        #endregion

        #region Singleton
        private static frmTimDanhSachChungTu singleton_ = null;
        public static frmTimDanhSachChungTu Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmTimDanhSachChungTu();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion

        #region Function

        private void KhoiTao()
        {
            tblChungTuBindingSource_Single.DataSource = typeof(PSC_ERP_Business.Main.Model.tblChungTu);
            //this.WindowState = FormWindowState.Maximized;
            dtmp_TuNgay.EditValue = _tuNgay;
            dtmp_DenNgay.EditValue = _denNgay;
            DesignGridView1();

        }

        private void LoadChungTu()
        {
            _tuNgay = Convert.ToDateTime(dtmp_TuNgay.EditValue);
            _denNgay = Convert.ToDateTime(dtmp_DenNgay.EditValue);
            if (_maLoaiChungTu != 0)
            {
                //using (DialogUtil.Wait(this))
                //{
                    //khởi tạo mới chứng từ factory
                    _factory = ChungTuThuChi_DerivedFactory.New();
                    if (_tenfrm == "CTHD")
                    {
                        _ChungTuList = _factory.TimKiemChungTuThuChibyBoPhan_NgayLap(_tuNgay, _denNgay, _user.MaBoPhan.Value);
                        tblChungTuBindingSource_Single.DataSource = _ChungTuList;
                    }
                    else
                    {
                        _ChungTuList = _factory.TimKiemChungTuThuChibyMaLoaiChungTu_NgayLap(_maLoaiChungTu, _tuNgay, _denNgay, _user.UserID);
                        tblChungTuBindingSource_Single.DataSource = _ChungTuList;
                    }
                //}
            }
        }

        private void DesignGridView1()
        {
            //gridControl1.DataSource = tblChungTuBindingSource_Single;

            //HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            //HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "Chon", "SoChungTu", "NgayLap", "tblTienTe.SoTien", "tblTienTe.ThanhTien", "DienGiai" },
            //                    new string[] { "Chọn", "Số chứng từ", "Ngày lập", "Số tiền", "Thành tiền", "Diễn giải" },
            //                                 new int[] { 15, 120, 100, 150, 150, 400 });


            //HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Chon", "SoChungTu", "NgayLap", "tblTienTe.SoTien", "tblTienTe.ThanhTien", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);

            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "tblTienTe.SoTien", "tblTienTe.ThanhTien" }, "#,###.#");
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "tblTienTe.SoTien", "tblTienTe.ThanhTien" }, "{0:#,###.#}");
            //HamDungChung.NewRowGridViewDev(gridView1);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M



            //HamDungChung.FormatNumberTypeofColumnGridViewDev(gridView1, new string[] { "tblTienTe.SoTien", "tblTienTe.ThanhTien" });
            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "tblTienTe.SoTien", "tblTienTe.ThanhTien" }, "#,###.#");
            //this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            //this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            //this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
        }

        private void CopyChungTu()
        {

            if (gridView1.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần copy.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            //
            long maChungTu = ((tblChungTu)gridView1.GetFocusedRow()).MaChungTu;
            _chungTuCanDeCopy = ChungTu_Factory.New().Get_ChungTu_ByMaChungTu(maChungTu);

            if (_chungTuCanDeCopy.NgayLap.Value.Year <= Convert.ToDateTime("31-12-2013").Year)
            {
                MessageBox.Show("Chứng từ cũ năm [" + _chungTuCanDeCopy.NgayLap.Value.Year + "] không thể copy.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _chungTuCanDeCopy = null;
            }
        }

        private void PasteChungTu()
        {
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
                        tblButToan butToanMoi = new tblButToan() ;
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
                                chungTu_ChiPhiSanXuatMoi.tblButToan_MucNganSach.Add(butToanMucNganSachMoi);
                            }

                            butToanMoi.tblCT_ChiPhiSanXuat.Add(chungTu_ChiPhiSanXuatMoi);
                        }

                        //Lấy chứng từ hóa đơn
                        foreach (tblChungTu_HoaDon chungTu_HoaDon in item.tblChungTu_HoaDon)
                        {
                            tblChungTu_HoaDon chungTu_HoaDonMoi = new tblChungTu_HoaDon();
                            chungTu_HoaDonMoi.MaHoaDon = chungTu_HoaDon.MaHoaDon;
                            chungTu_HoaDonMoi.MaPhieuNhapXuat = chungTu_HoaDon.MaPhieuNhapXuat;
                            chungTu_HoaDonMoi.SoTien = chungTu_HoaDon.SoTien;
                            chungTu_HoaDonMoi.NgayLap = DateTime.Now.Date;
                            chungTu_HoaDonMoi.NguoiLap = _user.UserID;

                            butToanMoi.tblChungTu_HoaDon.Add(chungTu_HoaDonMoi);
                        }

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

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void LockColumnsGridview()
        {
            this.colSoChungTu.OptionsColumn.ReadOnly = true;
            this.colNgayLap.OptionsColumn.ReadOnly = true;
            this.tblTienTe_ThanhTien.OptionsColumn.ReadOnly = true;
            this.colDienGiai.OptionsColumn.ReadOnly = true;
        }

        #endregion

        #region EventHandle

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            _ChungTu1 = tblChungTuBindingSource_Single.Current as tblChungTu;
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

        #endregion

        #region Event
        private void btn_Tim_Click(object sender, EventArgs e)
        {
            LoadChungTu();
        }

        private void copy_ChungTu_Click(object sender, EventArgs e)
        {
            CopyChungTu();
        }

        private void pass_ChungTu_Click(object sender, EventArgs e)
        {
            PasteChungTu();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }//Xuat ra file Excel

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            textBoxFocus.Focus();
            string soct = "";
            List<long> mang = new List<long>();
            foreach (tblChungTu chungtu in _ChungTuList)
            {
                if (chungtu.Chon == true)
                {
                    Ky_Factory ky_Factory = Ky_Factory.New();
                    if (ky_Factory.DaKhoaSoTSCD(chungtu.NgayLap.Value,_maCongTy))
                    {

                        //bật thông báo đã khóa sổ
                        DialogUtil.ShowDaKhoaSoTSCD(chungtu.NgayLap.Value);
                        return;
                    }
                    soct += chungtu.SoChungTu + ", ";
                    mang.Add(chungtu.MaChungTu);

                }
            }
            if (soct.Length > 2)
            {
                soct = soct.Remove(soct.Length - 2, 2);
                if (MessageBox.Show("Bạn Có Muốn Xóa Chứng Từ Số " + soct + " ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (long mact in mang)
                    {
                        tblChungTu chungtuDelete = _factory.Get_ChungTu_ByMaChungTu(mact);
                        try
                        {
                            _factory.XoaChungTuThuChi(chungtuDelete);
                            _factory.SaveChanges();
                            MessageBox.Show(this, "Xóa Thành Công " + chungtuDelete.SoChungTu, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Lỗi khi đang xóa chứng từ số " + chungtuDelete.SoChungTu, "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    }

                }
                LoadChungTu();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chứng từ cần xóa!");
            }
        }

        #endregion//Event

        public frmTimDanhSachChungTu()
        {
            InitializeComponent();
        }

        public frmTimDanhSachChungTu(int maLoaiChungTu)
        {
            InitializeComponent();
            _maLoaiChungTu = maLoaiChungTu;
            KhoiTao();
            LoadChungTu();
        }

        private void frmTimDanhSachChungTu_Load(object sender, EventArgs e)
        {
            LockColumnsGridview();
            //LoadChungTu();
        }





    }
}