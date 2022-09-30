using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraLayout;
//using NPCSimpleReportStorage;
//using NPCSimpleReportStorage.Model;
using DevExpress.XtraReports.UI;
using System.IO;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common;
using DevExpress.XtraTreeList;
using PSC_ERP_Business.Main.Predefined;//
using System.Data;
using System.Data.SqlClient;
//The ShowDesigner and ShowPreview methods of the XtraReport class have been removed.
//To continue using these methods, do the following.
//1. To the project's list of using alias directives, add DevExpress.XtraReports.UI.(using DevExpress.XtraReports.UI;)
//2. To use the ShowPreview methods, add a reference to DevExpress.XtraPrinting.v12.2.dll.
//3. To use the ShowDesigner methods, add a reference to DevExpress.XtraReports.v12.2.Extensions.dll.
namespace PSC_ERPNew.Main.PhanHe.TSCD.Reports
{
    public partial class frmTSCDReportList : Form
    {
        //Singleton
        #region Singleton
        private static frmTSCDReportList singleton_ = null;
        public static frmTSCDReportList Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmTSCDReportList();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }
        #endregion

        Boolean _dangKhoaDanhSach = true;
        //NPCSimpleReportStorage.Model.NPCSimpleReportStorageEntities _db = new NPCSimpleReportStorage.Model.NPCSimpleReportStorageEntities(Database.ChuoiKetNoiChoLinqToEntity);
        Report_Factory _factory = new Report_Factory();
        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        String _maPhanHe = "TSCD";
        Boolean _designMode = false;

        List<tblBoPhanERPNew> _boPhanList_vitri = null;
        List<tblnsBoPhan> _boPhanList = null;
        IQueryable<tblDanhMucTSCD> _loaiTaiSanList = null;
        IQueryable<tblKy> _kyList = null;
        DataSet dataSet = new DataSet();
        public frmTSCDReportList()
        {
            InitializeComponent();

        }
        private void frmTSCDReportList_Load(object sender, EventArgs e)
        {
            using (DialogUtil.Wait())
            {
                this.DocDanhSachReport();

                //set mặc định các ngày
                dteTuNgay.EditValue = (object)(new DateTime(DateTime.Today.Year, 1, 1));
                dteDenNgay.EditValue = (object)DateTime.Today.Date;
                dteNgayChot.EditValue = (object)DateTime.Today.Date;
                dteNgayKiemKe.EditValue = (object)DateTime.Today.Date;

                //năm
                {
                    List<int> namList = new List<int>();
                    int nam = DateTime.Today.Year;
                    for (int i = nam - 10; i < nam + 10; i++)
                        namList.Add(i);
                    cbNam.Properties.DataSource = namList;
                    //set mặc định năm
                    cbNam.EditValue = nam;
                }
                //
                //Lấy bộ phận
                {
                    _boPhanList_vitri = BoPhanERPNew_Factory.New().GetAll().ToList();
                    tblBoPhanERPNew boPhan_chonTatCa_vitri = new tblBoPhanERPNew() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
                    _boPhanList_vitri.Insert(0, boPhan_chonTatCa_vitri);
                    tblBoPhanERPNewBindingSource.DataSource = _boPhanList_vitri;
                    cbPhongBan.EditValue = 0;
                    _boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(_maCongTy).ToList();//BoPhan_Factory.New().GetAll().ToList();
                    tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
                    _boPhanList.Insert(0, boPhan_chonTatCa);
                    tblBoPhanBindingSource.DataSource = _boPhanList;
                    treeListLookUpEdit_BoPhan.EditValue = 0;
                }
                //
                //Lấy kỳ kế toán
                {
                    Ky_Factory ky_Factory = Ky_Factory.New();
                    _kyList = ky_Factory.GetAll();
                    tblKyBindingSource.DataSource = _kyList;
                    //set mặc định kỳ
                    Int32 maKyHienTai = ky_Factory.XacDinhMaKy_ByNgay(app_users_Factory.New().SystemDate);
                    this.cbTuKy.EditValue = maKyHienTai;
                    this.cbDenKy.EditValue = maKyHienTai;

                }
                //
                //Lấy loại tài sản
                {
                    _loaiTaiSanList = DanhMucTSCD_Factory.New().Get_DanhSachTaiSanTheoMaCongTy(_maCongTy);
                    tblDanhMucTSCD danhmuc_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
                    _loaiTaiSanList.ToList().Insert(0, danhmuc_chonTatCa);

                    tblDanhMucTSCDBindingSource_LoaiTaiSan.DataSource = _loaiTaiSanList;
                }
                //
                loaiThanhLyTaiSanBindingSource.DataSource = LoaiThanhLyTaiSan.LoaiThanhLyTaiSanList;
                hinhThucGiamBindingSource.DataSource = HinhThucGiamTaiSan.HinhThucGiamTaiSanList;
                /////Phân quyền user/////
                Boolean isAdmin = false;
                //Kiểm tra xem user đăng nhập có phải admin hay không
                isAdmin = app_users_Factory.New().CheckIsAdmin_PhucVuReport(PSC_ERP_Global.Main.UserID);
                if (isAdmin == false)
                {
                    //Ẩn nút thêm mới
                    btnThemMoi.Enabled = false;
                }
            }
        }


        private void treeList1_AfterFocusNode(object sender, NodeEventArgs e)
        {
            this.AnTatCaLayoutControlItem();
            Report report = this.reportBindingSource.Current as Report;
            //this.txtDescription.Text = report.Description;
            ShowLayoutControlItem(itemXemBaoCao);
            radioChonTuNgayDenNgay.Checked = true;
            switch (report.ReportKey)
            {

                //1 M
                case "TongHopChiTietTaiSanTangTrongKy":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                        ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                    }
                    break;
                //2 M
                case "TongHopChiTietTaiSanTangTrongKy_4ChuKy":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                        ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                    }
                    break;
                //3 M
                case "SoTaiSanCoDinh":
                    {
                        ShowLayoutControlItem(itemNam);
                        ShowLayoutControlItem(itemLoaiTaiSan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //4 M
                case "DanhSachChiTietTaiSanGiamNoiBo":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //5 M
                case "DanhSachChiTietTaiSanTangNoiBo":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //6 M
                case "BangTongHopTangGiamDieuChuyenNoiBo":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //7 M
                case "BangTongHopTaiSanDieuChuyenNoiBo":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //BC10 M
                case "BangTongHopTaiSanDuAnDieuChuyenNoiBo":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //BC11 M
                case "DanhSachTaiSanThanhLy":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemKieuThanhLy);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //BC12 M
                case "DanhSachTaiSanGiamDoTachHeTHong":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //BC13 M
                case "BangTongHopTaiSanTangTrongKy":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //BC14 M
                case "TongHopTaiSanDuAnVaNhapLeDenNgay":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //15
                case "TongHopKhauHaoTheoDonVi":
                    {
                        ShowLayoutControlItem(itemTuKy);
                        ShowLayoutControlItem(itemDenKy);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //16 M
                case "TongHopKinhPhiMuaSamTaiSanTangTrongKyTheoTaiKhoan":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //17 M
                case "TongHopKinhPhiMuaSamTaiSanTangTrongKyTheoDonViSuDung":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //20 M
                case "DanhSachTaiSanCoDenNgay":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //23 M
                case "KiemKeChiTietTaiSanCoDenNgay":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //24 M
                case "DanhSachTaiSanCoDenNgay_DungKiemKe":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //
                        ShowLayoutControlItem(itemRadioChonTuNgayDenNgay);
                        //ShowLayoutControlItem(itemRadioChonTuNgay);
                        ShowLayoutControlItem(itemRadioChonDenNgay);
                        // ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //25 M
                case "DanhSachTaiSanCoDenNgay_KiemKeThieu":
                    {
                        ShowLayoutControlItem(itemNgayChot);
                        ShowLayoutControlItem(itemNgayKiemKe);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //26 M
                case "DanhSachTaiSanCoDenNgay_KiemKeThua":
                    {
                        ShowLayoutControlItem(itemNgayChot);
                        ShowLayoutControlItem(itemNgayKiemKe);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //27 M
                case "DanhSachDoiChieuTaiSanCoDinhKiemKeCoDenNgay":
                    {
                        ShowLayoutControlItem(itemNgayChot);
                        ShowLayoutControlItem(itemNgayKiemKe);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //28 M
                case "TongHopKinhPhiTangTrongKyTheoDonVi":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //29 M
                case "TongHopKinhPhiTangTrongKyTheoDonViCoChungTu":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //30 M
                case "DanhSachTaiSanCoDinhCoDenNgay":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //31 M
                case "DanhSachChungTuHopDongMuaSamTaiSan":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //
                        ShowLayoutControlItem(itemRadioChonTuNgayDenNgay);
                        //ShowLayoutControlItem(itemRadioChonTuNgay);
                        ShowLayoutControlItem(itemRadioChonDenNgay);
                        //
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //32 M
                case "DanhSachTaiSanDieuChinhGia":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        //
                        ShowLayoutControlItem(itemRadioChonTuNgayDenNgay);
                        //ShowLayoutControlItem(itemRadioChonTuNgay);
                        ShowLayoutControlItem(itemRadioChonDenNgay);
                        //
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //33 M
                case "DanhSachTaiSanDuAnvaNhapLeCoDenNgay":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;

                //34 M
                case "TongHopTaiSanTinhKhauHao_HaoMon":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //35 M
                case "TongHopTaiSanGiamTrongKyTheoTaiKhoan":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemKieuThanhLy);
                        //ShowLayoutControlItem(itemHinhThucGiam);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //36 M
                case "TongHopTaiSanGiamTrongKyTheoDonVi":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemKieuThanhLy);
                        //ShowLayoutControlItem(itemHinhThucGiam);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //101 M
                case "ChiTietTaiSanCoDinhTuXXXTroLenTangTrongKy":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //102 M
                case "DanhSachTSCDDieuChuyenNoiBo_GhiGiam":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //103 M
                case "DanhSachTSCDDieuChuyenChoCacDiaPhuong":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //104 M
                case "TongHopTinhHinhTonTangGiamKhauHaoHaoMonTaiSanCoDinh_DonVi":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //105 M
                case "TongHopTonTangGiamNguyenGiaTaiSanCoDinh_TaiKhoan":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //106 M
                case "TongHopTinhHinhTonTangGiamNguyenGiaTaiSanCoDinh_DonVi":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //107
                case "BangTongHopTaiSanCoDinh":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //108 M
                case "DanhSachTSCDDieuChuyenNoiBo_GhiTang":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //201 M
                case "BangTrichKhauHaoTSCD_BoPhan":
                    {
                        ShowLayoutControlItem(itemTuKy);
                        ShowLayoutControlItem(itemDenKy);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //202 M
                case "BangTrichKhauHaoTSCD_TaiKhoan":
                    {
                        ShowLayoutControlItem(itemTuKy);
                        ShowLayoutControlItem(itemDenKy);
                        ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //40-301 M
                case "TongHopKhauHaoTSCD_TaiKhoan":
                    {
                        ShowLayoutControlItem(itemTuKy);
                        ShowLayoutControlItem(itemDenKy);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //37-302
                case "BangTrichKhauHaoChiTietTSCD_NhomLoai":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemLoaiTaiSan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //38-303
                case "BangTrichKhauHaoTongHopTSCD_NhomLoai":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemLoaiTaiSan);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;

                //41-304 (số sau là index báo cáo)
                case "DanhSachTaiSanCoDinhCoDenNgay_CoTrichKhauHao":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemPhongBan_ViTri);
                        //ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //305-305
                case "BangTongHopDuAnTangTheoTaiKhoanTrongNam":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //  //306-306
                case "BangTongHopDuAnTangTheoPhongBanTrongNam":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                //42-307
                case "TongHopChiTietKhauHaoTaiSanTuNgayDenNgay_CoTrichKhauHaoTrongKyBaoCao":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemLoaiTaiSan);
                        //ShowLayoutControlItem(itemPhongBan_ViTri);
                        ShowLayoutControlItem(itemPhongBan);
                        ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                case "DanhSachTaiSanMuaBaoHiem": //report key
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(itemLoaiTaiSan);
                        //ShowLayoutControlItem(itemPhongBan);
                        //ShowLayoutControlItem(itemNguonMua_Le_DuAn);
                        //ShowLayoutControlItem(itemTS_CCDC_TatCa);
                    }
                    break;
                default:
                    this.AnTatCaLayoutControlItem();
                    break;
            }
        }
        private void DocDanhSachReport()
        {
            //Dang ky storage
            //DevExpress.XtraReports.Extensions.ReportStorageExtension.RegisterExtensionGlobal(new CustomReportStorage());
            this.reportBindingSource.DataSource = _factory.Get_DanhSachReport_InList_ByMaPhanHe(_maPhanHe);//_db.Reports; 
            this.treeList1.DataSource = null;
            this.treeList1.DataSource = this.reportBindingSource;

        }
        private void AnTatCaLayoutControlItem()
        {
            foreach (LayoutControlItem item in this.layoutControlGroup1.Items)
            {
                item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void ShowLayoutControlItem(LayoutControlItem item)
        {
            item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        }
        private void HideLayoutControlItem(LayoutControlItem item)
        {
            item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

        }
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report report = new Report();
            report.InList = true;
            report.OnForm = false;
            XtraReport xtraReport = new XtraReport();//khoi tao

            frmFillReportInfo frm = new frmFillReportInfo(PSC_ERP_Global.TSCD.MaPhanHeTSCD, report, xtraReport);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)//chap nhan tao moi report
            {
                _factory.Context.AddToReports(report);//them report vao danh sach report
                _factory.SaveChangesWithoutTrackingLog();//luu lai thay doi
                //doc lai danh sach
                reportBindingSource.DataSource = _factory.Get_DanhSachReport_InList_ByMaPhanHe(_maPhanHe);
                MessageBox.Show("Tạo và lưu thành công, tiếp theo sẽ chuyển sang design");
                xtraReport.Tag = new object[] { report, _factory };//dinh kem

                this.OpenReport(designMode: true, report: report);
            }
            //ReportHelper.ShowReport(reportKey: null, action: null, maPhanHe: PSC_ERP_Global.TSCD.MaPhanHeTSCD, inList: true, onForm: false, designMode: true);
            this.DocDanhSachReport();
        }

        private void btnPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenReport();//xem report
        }

        private void OpenReport(Boolean designMode = false, Report report = null)
        {
            //xác định kiểu hiển thị
            _designMode = designMode;
            if (report == null)
            {
                report = this.reportBindingSource.Current as Report;
            }
            XtraReport xtraReport = new XtraReport();
            if (report.ReportLayoutData != null)
            {
                //Load layout
                MemoryStream newMemoryStream = new MemoryStream(report.ReportLayoutData);
                xtraReport.LoadLayout(newMemoryStream);
            }
            //lay du lieu cho report
            bool daChonParameter = false;
            if (report.DataSourceMethod != "")
            {
                //goi phuong thuc lấy về dữ liệu của báo cáo
                //du lieu se chua trong 1 dataSet
                daChonParameter = (bool)(this.GetType().GetMethod(report.DataSourceMethod).Invoke(this, null));
                //sau khi invoke se tu dong show ở che do preview
            }
            else
            {
                String key = report.ReportKey;
                ReportHelper.ShowReport(key, null, PSC_ERP_Global.TSCD.MaPhanHeTSCD, true, false, designMode);

                //xtraReport.Tag = new object[] { report, _factory };
                ////
                ////_xtraReport.CreateDocument();
                ////xem hoac thiet ke
                //if (!designMode)
                //{
                //    frmReportPreviewer frm = new frmReportPreviewer(xtraReport, report.ReportName);
                //    frm.Show();
                //    //xtraReport.ShowPreview();//mo de xem
                //}
                //else
                //{

                //    //_xtraReport.ShowDesigner();//mo thiet ke
                //    frmReportDesigner frm = new frmReportDesigner(xtraReport);
                //    frm.Show();
                //}
            }
            /*
            //cung cap du lieu cho report
            xtraReport.DataSource = _dataSet;
            //
          
             */
        }

        private void btnDesign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenReport(designMode: true);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.txtBlackHole.Focus();
                //this.reportBindingSource.EndEdit(); 
                this._factory.SaveChangesWithoutTrackingLog();
                //this._factory.SaveChanges(BusinessCodeEnum.TSCD_Report.ToString());
                DialogUtil.ShowSaveSuccessful();
            }
            catch (Exception ex)
            {
                DialogUtil.ShowNotSaveSuccessful();
            }
        }

        private void btnEditList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_dangKhoaDanhSach)
            {
                TreeUtils.UnlockAll_TreeListColumn(treeList: this.treeList1);
                this.btnLockUnlockList.ImageIndex = 8;
                this.btnLockUnlockList.Caption = "Khóa chỉnh sửa";
                this.txtDescription.Properties.ReadOnly = false;
                _dangKhoaDanhSach = false;

            }
            else
            {
                TreeUtils.LockAll_TreeListColumn(treeList: this.treeList1);
                this.btnLockUnlockList.ImageIndex = 9;
                this.btnLockUnlockList.Caption = "Mở khóa chỉnh sửa";
                this.txtDescription.Properties.ReadOnly = true;
                _dangKhoaDanhSach = true;

            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DocDanhSachReport();
        }
        #region Kiem tra dieu kien

        private bool ChuaChon_BoPhan()
        {
            if (this.treeListLookUpEdit_BoPhan.EditValue == null || treeListLookUpEdit_BoPhan.EditValue == "")
            {
                MessageBox.Show("Chưa chọn bộ phận", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                treeListLookUpEdit_BoPhan.Focus();
                return true;
            }
            return false;
        }
        private bool ChuaChon_TuKy()
        {
            if (Convert.ToInt32(this.cbTuKy.EditValue) == 0)
            {
                MessageBox.Show("Chưa chọn từ kỳ", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbTuKy.Focus();
                return true;
            }
            return false;
        }
        private bool ChuaChon_DenKy()
        {
            if (Convert.ToInt32(this.cbDenKy.EditValue) == 0)
            {
                MessageBox.Show("Chưa chọn đến kỳ", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbDenKy.Focus();
                return true;
            }
            return false;
        }
        private bool ChuaChon_DenNgay()
        {
            if (dteDenNgay.EditValue == null)
            {

                MessageBox.Show("Chưa chọn đến ngày", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dteDenNgay.Focus();
                return true;
            }
            return false;
        }
        private bool ChuaChon_NgayChot()
        {
            if (dteNgayChot.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày chốt", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dteNgayChot.Focus();
                return true;
            }
            return false;
        }
        private bool ChuaChon_NgayKiemKe()
        {
            if (dteNgayKiemKe.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày kê", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dteNgayKiemKe.Focus();
                return true;
            }
            return false;
        }

        private bool ChuaChon_TaiKhoan()
        {
            //if (cbTaiKhoan.EditValue == null || (int)cbTaiKhoan.EditValue == 0)
            //{

            //    MessageBox.Show("Chưa chọn tài khoản", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    cbTaiKhoan.Focus();
            //    return true;
            //}
            return false;
        }
        private bool ChuaChon_TuNgay()
        {
            if (dteTuNgay.EditValue == null)
            {
                MessageBox.Show("Chưa chọn từ ngày", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dteTuNgay.Focus();
                return true;
            }
            return false;
        }
        private bool ChuaChon_Nam()
        {
            if (cbNam.EditValue == null || (int)cbNam.EditValue == 0)
            {
                MessageBox.Show("Chưa chọn năm", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbNam.Focus();
                return true;
            }
            return false;
        }
        private static bool NamBaoCaoKhongHopLe(DateTime ngay)
        {
            if (ngay.Year < 2013)
            {
                DialogUtil.ShowWarning("Không hỗ trợ xuất báo cáo trước năm 2014");
                return true;
            }

            return false;
        }
        private static bool NamBaoCaoKhongHopLe(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay.Year < 2013 || denNgay.Year < 2013)
            {
                DialogUtil.ShowWarning("Không hỗ trợ xuất báo cáo trước năm 2014");
                return true;
            }
            return false;
        }
        #endregion
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (hi.Node != null)
            {
                OpenReport();//xem report
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            OpenReport();//xem report
        }

        private void radioChonTuNgayDenNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (radioChonTuNgayDenNgay.Checked)
            {
                ShowLayoutControlItem(itemTuNgay);
                ShowLayoutControlItem(itemDenNgay);
            }
        }

        private void radioChonTuNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (radioChonTuNgay.Checked)
            {
                ShowLayoutControlItem(itemTuNgay);
                HideLayoutControlItem(itemDenNgay);
            }
        }

        private void radioChonDenNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (radioChonDenNgay.Checked)
            {
                ShowLayoutControlItem(itemDenNgay);
                HideLayoutControlItem(itemTuNgay);
            }
        }

        private void btn_XuatDataKiemDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report report = this.reportBindingSource.Current as Report;
            if (report == null)
                return;

            if (report.DataSourceMethod + "" == "DanhSachTaiSanCoDenNgay")
            {
                XuatExcelBaoCao20();
                return;
            }
            else
            {
                XuatExcelDuLieuKiemDo();
            }


        }
       
        private void XuatExcelBaoCao20()
        {
            dataSet = new DataSet();
            DateTime denNgay = (Convert.ToDateTime(dteDenNgay.EditValue)).Date;
            int maBoPhan = (Int32)treeListLookUpEdit_BoPhan.EditValue;
            int nguonMua = (Int32)radioGroupNguonMua_Le_DuAn.EditValue;
            int LoaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
            int maViTri = (Int32)cbPhongBan.EditValue;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command.CommandText = "spRpt_TSCD_DanhSachTaiSanCoDenNgay";
            command.Parameters.AddWithValue("@DenNgay", denNgay);
            command.Parameters.AddWithValue("@MaBoPhan", maBoPhan);          
            command.Parameters.AddWithValue("@NguonMua", nguonMua);
            command.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            command.Parameters.AddWithValue("@LoaiBaoCao", LoaiBaoCao);
            command.CommandTimeout = 3000;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataSet.Tables.Add(table);
            table.TableName = "DanhSachTaiSanCoDenNgay";

            frmShowReportForGrid frm = new frmShowReportForGrid("spRpt_TSCD_DanhSachTaiSanCoDenNgay", dataSet);
            frm.ShowDialog();
        }

        private void XuatExcelDuLieuKiemDo()
        {
            dataSet = new DataSet();
            DateTime denNgay = (Convert.ToDateTime(dteDenNgay.EditValue)).Date;
            int maBoPhan = (Int32)treeListLookUpEdit_BoPhan.EditValue;
            int nguonMua = (Int32)radioGroupNguonMua_Le_DuAn.EditValue;
            int LoaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
            int maViTri = (Int32)cbPhongBan.EditValue;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command.CommandText = "spRpt_KiemDo";
            command.Parameters.AddWithValue("@DenNgay", denNgay);
            command.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
            command.Parameters.AddWithValue("@MaViTri", maViTri);
            command.Parameters.AddWithValue("@NguonMua", nguonMua);
            command.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            command.Parameters.AddWithValue("@LoaiBaoCao", LoaiBaoCao);
            command.CommandTimeout = 3000;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataSet.Tables.Add(table);
            table.TableName = "BangDataKiemDo";

            frmShowReportForGrid frm = new frmShowReportForGrid("spRpt_KiemDo", dataSet);
            frm.ShowDialog();
        }
    }
}
