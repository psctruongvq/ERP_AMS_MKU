using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
using System.Collections;
using System.Data.SqlClient;
using PSC_ERP_Business.Main.Predefined;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace PSC_ERP.ThuChiEntity
{
    public partial class FrmKetChuyenChiPhiE : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        private ChungTuThuChi_DerivedFactory _factory = null;
        private ChungTuThuChi_DerivedFactory _factoryMain = null;
        private tblChungTu _ChungTu = null;
        private app_users _user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);
        private int _maCongTy;
        private int _loaiTien;
        Boolean _taoMoiChungTu = true;
        DateTime _ngayLapCu;

        private List<tblnsBoPhan> _boPhanList = null;
        private List<tblTaiKhoan> _taiKhoanNoList = null;
        private List<tblTaiKhoan> _taiKhoanKCList = null;
        private List<tblTieuMucNganSach> _tieuMucNganSachList = null;
        private List<tblMucNganSach> _mucNganSachList = null;
        private List<app_users> _nguoiLapList = null;
        private List<tblnsChuongTrinh> _chuongTrinhList = null;

        private List<spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result> _danhSachChungTuTimDuocList = null;
        private List<spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result> _danhSachChungTuKetChuyenList = null;
        #region Thông tin tim kiếm
        private DateTime _tuNgayS;
        private DateTime _denNgayS;
        private int _maBoPhanS;
        private int _userIDS;
        private int _maChuongTrinhS;
        private int _maTaiKhoanNoS;
        private int _maTieuMucS;
        private int _maMucNganSachS;
        #endregion//Thông tin tim kiếm

        #endregion //Properties

        #region Functions
        private void KhoiTao()
        {
            _maCongTy = _user.MaCongTy.Value;
            _loaiTien = 1;

            DanhSachChungTu_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result);
            DanhSachChungTuKetChuyen_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result);

            BoPhan_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblnsBoPhan);
            tblTaiKhoanBindingSource_No.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTaiKhoan);
            tblTaiKhoanKetChuyenBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTaiKhoan);
            TieuMucNganSach_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTieuMucNganSach);
            MucNganSach_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblMucNganSach);
            NguoiLap_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.app_users);
            nsChuongTrinh_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblnsChuongTrinh);

            DesignGridDanhSachChungTu();
            DesignGridDanhSachChungTuKetChuyen();

        }

        private void LoadData()
        {
            _factory = ChungTuThuChi_DerivedFactory.New();

            _danhSachChungTuTimDuocList = new List<spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result>();
            _danhSachChungTuKetChuyenList = new List<spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result>();

            _boPhanList = BoPhan_Factory.New().GetBoPhanbyUserID(_user
                .UserID).ToList<tblnsBoPhan>();
            //tblnsBoPhan bp = new tblnsBoPhan() { MaBoPhan = 0, TenBoPhan = "<<Tất cả>>" };
            //_boPhanList.Insert(0, bp);
            BoPhan_bindingSource.DataSource = _boPhanList;

            _taiKhoanNoList = TaiKhoan_Factory.New().Get_TaiKhoanbyMaCongTy(_maCongTy).ToList<tblTaiKhoan>();
            tblTaiKhoanBindingSource_No.DataSource = _taiKhoanNoList;
            tblTaiKhoanKetChuyenBindingSource.DataSource = _taiKhoanNoList;

            _tieuMucNganSachList = TieuMucNganSach_Factory.New().GetAll().ToList<tblTieuMucNganSach>();
            tblTieuMucNganSach tm = new tblTieuMucNganSach() { MaTieuMuc = 0, TenTieuMuc = "<<Tất cả>>" };
            _tieuMucNganSachList.Insert(0, tm);
            TieuMucNganSach_bindingSource.DataSource = _tieuMucNganSachList;

            _mucNganSachList = MucNganSach_Factory.New().GetAll().ToList<tblMucNganSach>();
            tblMucNganSach m = new tblMucNganSach() { MaMucNganSach = 0, TenMucNganSach = "<<Tất cả>>" };
            _mucNganSachList.Insert(0, m);
            MucNganSach_bindingSource.DataSource = _mucNganSachList;

            _nguoiLapList = app_users_Factory.New().Get_AppUserbyBoPhan(_user.MaBoPhan.Value).ToList<app_users>();
            app_users us = new app_users() { UserID = 0, TenDangNhap = "<<Tất cả>>" };
            _nguoiLapList.Insert(0, us);
            NguoiLap_bindingSource.DataSource = _nguoiLapList;

            _chuongTrinhList = NsChuongTrinh_Factory.New().Get_ChuongTrinhByMaCongTy(_maCongTy).ToList<tblnsChuongTrinh>();
            tblnsChuongTrinh ct = new tblnsChuongTrinh() { MaChuongTrinh = 0, TenChuongTrinh = "<<Tất cả>>" };
            _chuongTrinhList.Insert(0, ct);
            nsChuongTrinh_bindingSource.DataSource = _chuongTrinhList;

            dtmp_TuNgay.EditValue = DateTime.Today.Date;
            dtmp_DenNgay.EditValue = DateTime.Today.Date;

        }

        private void SetSoChungTuMoiPS(int LoaiChungTu)
        {
            _ChungTu.SoChungTu = _factory.Get_NextSoChungThuChi_ByYear(LoaiChungTu, (Convert.ToDateTime(dtmp_Ngay.EditValue)).Date.Year);
            txtSoChungTu.Text = _ChungTu.SoChungTu;
        }

        private void KhoiTaoChungTuMoi()
        {
            _taoMoiChungTu = true;
            dtmp_Ngay.EditValue = (object)DateTime.Today.Date;

            //khởi tạo mới chứng từ factory
            _factoryMain = ChungTuThuChi_DerivedFactory.New();
            //khởi tạo chứng từ mới 
            int _maLoaiChungTu = 16;
            _ChungTu = _factoryMain.NewChungTuThuChi(_maLoaiChungTu, (Convert.ToDateTime(dtmp_Ngay.EditValue)).Date.Year);
            _ChungTu.MaBoPhanDangNhap = _user.MaBoPhan;
            SetSoChungTuMoiPS(_maLoaiChungTu);
            dtmp_Ngay.EditValue = DateTime.Today;
            _ChungTu.SoChungTuKemTheo = 1;
            //gán bindingSource
            tblChungTuBindingSource_Single.DataSource = _ChungTu;
            dtmp_Ngay.Focus();
        }

        private void TaoChungTuNull()
        {
            _taoMoiChungTu = true;
            _ChungTu = new tblChungTu();
            //gán bindingSource
            tblChungTuBindingSource_Single.DataSource = _ChungTu;

        }

        private bool KiemTraDieuKienTim()
        {
            _tuNgayS = (Convert.ToDateTime(dtmp_TuNgay.EditValue)).Date;
            _denNgayS = (Convert.ToDateTime(dtmp_DenNgay.EditValue)).Date;
            _maBoPhanS = 0;
            _userIDS = 0;
            _maChuongTrinhS = 0;
            _maTaiKhoanNoS = 0;
            _maTieuMucS = 0;
            _maMucNganSachS = 0;

            if (grdLU_BoPhan.EditValue != null)
            {
                _maBoPhanS = Convert.ToInt32(grdLU_BoPhan.EditValue);
            }

            if (_maBoPhanS == 0)
            {
                _userIDS = _user.UserID;
            }
            else
            {
                if (grdLU_NguoiLap.EditValue != null)
                {
                    _userIDS = Convert.ToInt32(grdLU_NguoiLap.EditValue);
                }
            }

            if (grdLU_NoTaiKhoan.EditValue != null)
            {
                _maTaiKhoanNoS = Convert.ToInt32(grdLU_NoTaiKhoan.EditValue);

            }
            else
            {
                MessageBox.Show(this, "Chọn Nợ Tài Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grdLU_NoTaiKhoan.Focus();
                return false;
            }

            if (grdLU_ChuongTrinh.EditValue != null)
            {
                _maChuongTrinhS = Convert.ToInt32(grdLU_ChuongTrinh.EditValue);

            }

            if (grdLU_TieuMuc.EditValue != null)
            {
                _maTieuMucS = Convert.ToInt32(grdLU_TieuMuc.EditValue);

            }

            if (grdLU_Muc.EditValue != null)
            {
                _maMucNganSachS = Convert.ToInt32(grdLU_Muc.EditValue);

            }

            return true;
        }

        protected void Insert_KetChuyenChiPhiTam(int _maChungTu, decimal _soTien, decimal _soTienChiPhiSanXuat, decimal _soTienMucNganSach, int _maChuongTrinh, int _maTieuMuc, int _maMuc, int _maTaiKhoanCo, int _maButToan, int _maButToanChiPhiSanXuat, int _maButToanMucNganSach, int _maChiPhiThucHien, int _maChiThuLao, int _maButToanMucNganSachNew, int userID)
        {
            Hashtable output = new Hashtable();
            SpeedDataAccess execNonQuery = new SpeedDataAccess(Database.NormalConnectionString);
            execNonQuery.ExecuteNonQueryStore(out output, "spd_Insert_KetChuyenChiPhiTam_E"
                                                , new string[] { "@MaChungTu", "@SoTien", "@SoTienChiPhiSanXuat"
                                                    ,"@SoTienMucNganSach","@MaChuongTrinh","@MaTieuMuc","@MaMuc"
                                                    , "@MaTaiKhoanCo","@MaButToan","@MaButToanChiPhiSanXuat"
                                                    ,"@MaButToanMucNganSach", "@MaChiPhiThucHien", "@MaChiThuLao"
                                                    ,"@MaButToanMucNganSachNew","@UserID" }
                                                    , _maChungTu, _soTien, _soTienChiPhiSanXuat, _soTienMucNganSach, _maChuongTrinh, _maTieuMuc
                                                    , _maMuc, _maTaiKhoanCo, _maButToan, _maButToanChiPhiSanXuat, _maButToanMucNganSach, _maChiPhiThucHien
                                                    , _maChiThuLao, _maButToanMucNganSachNew, userID);

        }

        private void Delete_KetChuyenChiPhiTam(int userID)
        {
            //try
            //{
            Hashtable output = new Hashtable();
            SpeedDataAccess execNonQuery = new SpeedDataAccess(Database.NormalConnectionString);
            execNonQuery.ExecuteNonQueryStore(out output, "spd_Delete_KetChuyenChiPhiTam_E"
                                                , new string[] { "@UserID" }
                                                                , userID);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private decimal LaySoTienChiPhiSanXuat()
        {
            decimal _soTien = 0;

            using (SqlConnection cn = new SqlConnection(Database.NormalConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienChiPhiSanXuat";
                    cm.Parameters.AddWithValue("@SoTien", _soTien).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _soTien = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }
            return _soTien;
        }

        private decimal LaySoTienNganSach_New()
        {
            decimal _soTien = 0;

            using (SqlConnection cn = new SqlConnection(Database.NormalConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienNganSach_New";
                    cm.Parameters.AddWithValue("@SoTien", _soTien).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _soTien = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }
            return _soTien;
        }

        private decimal LaySoTienChungTu()
        {
            decimal _soTien = 0;

            using (SqlConnection cn = new SqlConnection(Database.NormalConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienChungTu";
                    cm.Parameters.AddWithValue("@SoTien", _soTien).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _soTien = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }
            return _soTien;
        }

        private decimal LaySoTienButToan(int coTaiKhoan)
        {
            decimal _soTien = 0;

            using (SqlConnection cn = new SqlConnection(Database.NormalConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienButToan";
                    cm.Parameters.AddWithValue("@MaKhoanCo", coTaiKhoan);
                    cm.Parameters.AddWithValue("@SoTien", _soTien).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _soTien = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }
            return _soTien;
        }

        private void TinhSoTienKetChuyen()
        {

            foreach (spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result item in _danhSachChungTuKetChuyenList)
            {
                Insert_KetChuyenChiPhiTam(item.MaChungTu ?? 0, item.SoTien ?? 0, item.SoTienChiPhiSanXuat ?? 0, item.SoTienMucNganSach ?? 0, item.MaChuongTrinh ?? 0, item.MaTieuMucNganSach ?? 0, item.MaMucNganSach ?? 0, item.MaTaiKhoanCo ?? 0, item.MaButToan ?? 0, item.MaButToanChiPhiSanXuat ?? 0, item.MaButToanMucNganSach ?? 0, item.MaChiPhiThucHien ?? 0, item.MaChiThuLao ?? 0, item.MaButToanMucNganSachNew ?? 0, _user.UserID);
            }

            lbSoTien.Text = "Tiền bút toán : " + String.Format("{0:0,0}", LaySoTienChungTu());
            lbSoTienChiPhi.Text = "Tiền chi phí : " + String.Format("{0:0,0}", LaySoTienChiPhiSanXuat());
            lbSoTienNganSach.Text = "Tiền ngân sách : " + String.Format("{0:0,0}", LaySoTienNganSach_New());

            //Xóa bảng kết chuyển chứng từ tạm
            Delete_KetChuyenChiPhiTam(_user.UserID);
        }

        private DataTable LayDanhSachButToanToDataTable()
        {
            DataTable dtResult = new DataTable();
            SpeedDataAccess execNonQuery = new SpeedDataAccess(Database.NormalConnectionString);
            execNonQuery.FillDataTable(out dtResult, "SELECT DISTINCT(MaButToan)  FROM    dbo.tblKetChuyenChungTuTam", "DSMaButToan");
            return dtResult;
        }

        private DataTable LayDanhSachCT_ChiPhiSXToDataTable()
        {
            DataTable dtResult = new DataTable();
            SpeedDataAccess execNonQuery = new SpeedDataAccess(Database.NormalConnectionString);
            execNonQuery.FillDataTable(out dtResult, "SELECT DISTINCT( MaButToanChiPhiSanXuat )   FROM    dbo.tblKetChuyenChungTuTam", "DSChiPhiSX");
            return dtResult;
        }

        private void DesignGridDanhSachChungTu()
        {
            grd_DanhSachChungTu.DataSource = DanhSachChungTu_bindingSource;

            HamDungChung.InitGridViewDev(grdV_DanhSachChungTu, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev2(grdV_DanhSachChungTu, new string[] { "Chon", "SoChungTu", "NgayLap", "TenNguoiLap", "TKCO", "TenTaiKhoan", "TenTieuMucNganSach", "TenMucNganSach", "TenChuongTrinh", "SoTien", "SoTienMucNganSach", "SoTienChiPhiSanXuat" },
                                new string[] { "Chọn", "Số chứng từ", "Ngày lập", "Người lập", "Có TK", "Tài khoản", "Tiểu mục", "Mục", "Chương trình", "Tiền BT", "Tiền NS", "Tiền SX" },
                                             new int[] { 60, 150, 80, 120, 80, 80, 150, 150, 150, 100, 100, 100 }, false);

            HamDungChung.ReadOnlyColumnGridViewDev(grdV_DanhSachChungTu);
            grdV_DanhSachChungTu.Columns["Chon"].OptionsColumn.AllowFocus = true;
            grdV_DanhSachChungTu.Columns["Chon"].OptionsColumn.ReadOnly = false;
            grdV_DanhSachChungTu.Columns["Chon"].OptionsColumn.AllowEdit = true;

            HamDungChung.AlignHeaderColumnGridViewDev(grdV_DanhSachChungTu, new string[] { "Chon", "SoChungTu", "TKCO", "TenTaiKhoan", "TenTieuMucNganSach", "TenMucNganSach", "TenChuongTrinh", "SoTienMucNganSach", "SoTienChiPhiSanXuat", "NgayLap", "SoTien", "TenNguoiLap" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdV_DanhSachChungTu, new string[] { "SoTienMucNganSach", "SoTienChiPhiSanXuat", "SoTien" }, "#,###.#");
            grdV_DanhSachChungTu.OptionsView.ShowAutoFilterRow = true;
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdV_DanhSachChungTu, new string[] { "SoTienMucNganSach", "SoTienChiPhiSanXuat", "SoTien" }, "{0:#,###.#}");
            //HamDungChung.NewRowGridViewDev(grdV_DanhSachChungTu);

            Utils.GridUtils.SetSTTForGridView(grdV_DanhSachChungTu, 40);//M

            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdV_DanhSachChungTu, new string[] { "SoTienMucNganSach", "SoTienChiPhiSanXuat", "SoTien" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdV_DanhSachChungTu, new string[] { "SoTienMucNganSach", "SoTienChiPhiSanXuat", "SoTien" }, "#,###.#");

            this.grdV_DanhSachChungTu.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grdV_DanhSachChungTu_RowCellClick);

        }

        private void DesignGridDanhSachChungTuKetChuyen()
        {
            grd_DanhSachChungTuKetChuyen.DataSource = DanhSachChungTuKetChuyen_bindingSource;

            HamDungChung.InitGridViewDev(grdV_DanhSachChungTuKetChuyen, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev2(grdV_DanhSachChungTuKetChuyen, new string[] { "Chon", "SoChungTu", "NgayLap", "TenNguoiLap", "TKCO", "TenTaiKhoan", "TenTieuMucNganSach", "TenMucNganSach", "TenChuongTrinh", "SoTien", "SoTienMucNganSach", "SoTienChiPhiSanXuat" },
                                new string[] { "Chọn", "Số chứng từ", "Ngày lập", "Người lập", "Có TK", "Tài khoản", "Tiểu mục", "Mục", "Chương trình", "Tiền BT", "Tiền NS", "Tiền SX" },
                                             new int[] { 60, 150, 80, 120, 80, 80, 150, 150, 150, 100, 100, 100 }, false);


            HamDungChung.AlignHeaderColumnGridViewDev(grdV_DanhSachChungTuKetChuyen, new string[] { "Chon", "SoChungTu", "TKCO", "TenTaiKhoan", "TenTieuMucNganSach", "TenMucNganSach", "TenChuongTrinh", "SoTienMucNganSach", "SoTienChiPhiSanXuat", "NgayLap", "SoTien", "TenNguoiLap" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdV_DanhSachChungTuKetChuyen, new string[] { "SoTienMucNganSach", "SoTienChiPhiSanXuat", "SoTien" }, "#,###.#");
            grdV_DanhSachChungTuKetChuyen.OptionsView.ShowAutoFilterRow = true;
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdV_DanhSachChungTuKetChuyen, new string[] { "SoTienMucNganSach", "SoTienChiPhiSanXuat", "SoTien" }, "{0:#,###.#}");
            //HamDungChung.NewRowGridViewDev(grdV_DanhSachChungTuKetChuyen);

            Utils.GridUtils.SetSTTForGridView(grdV_DanhSachChungTuKetChuyen, 40);//M

            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdV_DanhSachChungTuKetChuyen, new string[] { "SoTienMucNganSach", "SoTienChiPhiSanXuat", "SoTien" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdV_DanhSachChungTuKetChuyen, new string[] { "SoTienMucNganSach", "SoTienChiPhiSanXuat", "SoTien" }, "#,###.#");

            HamDungChung.ReadOnlyColumnGridViewDev(grdV_DanhSachChungTuKetChuyen);
            grdV_DanhSachChungTuKetChuyen.Columns["Chon"].OptionsColumn.AllowFocus = true;
            grdV_DanhSachChungTuKetChuyen.Columns["Chon"].OptionsColumn.ReadOnly = false;
            grdV_DanhSachChungTuKetChuyen.Columns["Chon"].OptionsColumn.AllowEdit = true;
            this.grdV_DanhSachChungTuKetChuyen.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grdV_DanhSachChungTuKetChuyen_RowCellClick);
        }

        private bool KiemTraSoChungTu(string soct)
        {
            if (soct.Length < 5)
                return false;
            string[] mang = new string[4];
            for (int i = 0; i < 4; i++)
            {
                mang[i] = soct.Substring(i, 1);
            }
            // kiem tra so
            for (int j = 0; j < 4; j++)
            {
                try
                {
                    int.Parse(mang[j]);
                }
                catch
                {

                    return false;
                }
            }
            return true;
        }

        private bool KiemTraSoChungTuKhongTrung()
        {
            //kiểm tra trùng số chứng từ
            if (_factory.KiemTraTrungSoChungTu(_ChungTu) == true)
            {
                txtSoChungTu.Focus();
                DialogResult _DialogResult = MessageBox.Show("Trùng số chứng từ. Tự động phát sinh số chứng từ mới", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (_DialogResult == DialogResult.Yes)
                {
                    _ChungTu.SoChungTu = _factory.Get_NextSoChungThuChi_ByYear(_ChungTu.MaLoaiChungTu, _ChungTu.NgayLap.Value.Year);
                    //đệ quy
                    return true;
                }
                else
                    return false;
            }
            return true;
        }

        private bool KiemTraDuLieuTruocKhiLuu()
        {
            if (grdV_DanhSachChungTuKetChuyen.RowCount == 0)
            {
                MessageBox.Show(this, "Chưa lấy dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (grdLU_NoTaiKhoan.EditValue == null)
            {
                MessageBox.Show(this, "Chọn Nợ Tài Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grdLU_NoTaiKhoan.Focus();
                return false;
            }
            if (grdLu_TaiKhoanKetChuyen.EditValue == null || (grdLu_TaiKhoanKetChuyen.EditValue != null && Convert.ToInt32(grdLu_TaiKhoanKetChuyen.EditValue) == 0))
            {
                MessageBox.Show(this, "Chọn Tài Khoản Kết Chuyển.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grdLu_TaiKhoanKetChuyen.Focus();
                return false;
            }
            if (txtSoChungTu.Text == "" || KiemTraSoChungTu(txtSoChungTu.Text) == false)
            {
                if (_loaiTien == 1)
                {

                    MessageBox.Show(this, "Vui Lòng Nhập Số Chứng Từ theo định dạng 1234B/DVXX", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Số Chứng Từ theo định dạng 1234NTB/DVXX", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //if (_ChungTu.MaChungTu == 0)
                //    txtSoChungTu.Text = SoCTMoiPS;
                //else
                //    txtSoChungTu.Text = _chungTu.SoChungTu;
                txtSoChungTu.Focus();
                return false;
            }
            if (KiemTraSoChungTuKhongTrung() == false)
            {
                MessageBox.Show(this, "Số Chứng Từ Đã Có Vui Lòng Nhập SCT Khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoChungTu.Focus();
                return false;
            }

            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool KhoaSo()
        {
            bool khoaso = false;
            List<tblKhoaSo_User> khoa = KhoaSoUser_Factory.New().GetKhoaSo_UserbyNgay_User(_user.UserID, _ChungTu.NgayLap.Value).ToList();
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoaso = true;
                }
            }

            if (khoaso == false && _taoMoiChungTu == false)
            {
                khoa = KhoaSoUser_Factory.New().GetKhoaSo_UserbyNgay_User(_user.UserID, _ngayLapCu).ToList();
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        khoaso = true;
                    }
                }
            }
            return khoaso;
        }



        private void Luu()
        {
            try
            {
                ////////////////////////////////////Tiến hành lưu dữ liệu ////////////////////////////////////////
                int maChuongTrinh = 0;
                if (grdLU_ChuongTrinh.EditValue != null)
                {
                    maChuongTrinh = Convert.ToInt32(grdLU_ChuongTrinh.EditValue);
                }

                //Lấy dữ liệu đưa vào bảng tạm
                foreach (spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result item in _danhSachChungTuKetChuyenList)
                {
                    Insert_KetChuyenChiPhiTam(item.MaChungTu ?? 0, item.SoTien ?? 0, item.SoTienChiPhiSanXuat ?? 0, item.SoTienMucNganSach ?? 0, item.MaChuongTrinh ?? 0, item.MaTieuMucNganSach ?? 0, item.MaMucNganSach ?? 0, item.MaTaiKhoanCo ?? 0, item.MaButToan ?? 0, item.MaButToanChiPhiSanXuat ?? 0, item.MaButToanMucNganSach ?? 0, item.MaChiPhiThucHien ?? 0, item.MaChiThuLao ?? 0, item.MaButToanMucNganSachNew ?? 0, _user.UserID);
                }

                //Khởi tạo chứng từ mới
                //_chungTu = ChungTu.NewChungTu();

                //Lấy dữ liệu cho định khoản
                _ChungTu.tblDinhKhoan.GhiMucNganSach = false;
                _ChungTu.tblDinhKhoan.LaMotNoNhieuCo = true;
                _ChungTu.tblDinhKhoan.NoCo = false;

                //Lấy dữ liệu cho chứng từ
                //_ChungTu.NgayLap = Convert.ToDateTime(dtu_NgayLap.Value);
                //_ChungTu.DienGiai = Convert.ToString(txtDienGiai.Value);
                //_ChungTu.SoChungTu = Convert.ToString(txtSoChungTu.Value);
                _ChungTu.MaLoaiChungTu = 16;
                _ChungTu.MaDoiTuongThuChi = 1;
                _ChungTu.KhoaSo = 1;

                //Lấy dữ liệu cho tiền tệ
                decimal _soTien_TienTe = 0;
                decimal _thanhTien_TienTe = 0;
                decimal _tiGiaQuyDoi_TienTe = 1;

                _soTien_TienTe = LaySoTienChungTu();
                _thanhTien_TienTe = _soTien_TienTe;

                _ChungTu.tblTienTe.SoTien = _soTien_TienTe;
                _ChungTu.tblTienTe.ThanhTien = _thanhTien_TienTe;
                _ChungTu.tblTienTe.TiGiaQuyDoi = _tiGiaQuyDoi_TienTe;
                _ChungTu.tblTienTe.MaLoaiTien = 1;

                //Lấy dữ liệu cho bút toán
                int coTaiKhoan = Convert.ToInt32(grdLU_NoTaiKhoan.EditValue);
                int noTaiKhoan = Convert.ToInt32(grdLu_TaiKhoanKetChuyen.EditValue);
                tblButToan butToan = new tblButToan();
                butToan.CoTaiKhoan = coTaiKhoan;
                butToan.NoTaiKhoan = noTaiKhoan;
                string dienGiai = "";

                //Lấy tất cả diễn giải của bút toán trong chứng từ kết chuyển chi phí
                //ButToanList butToanList = ButToanList.LayButToanInKetChuyenChungTuList();
                DataTable dsButToan = LayDanhSachButToanToDataTable();
                int bien = 0;
                foreach (DataRow dr in dsButToan.Rows)
                {
                    int maButToan;
                    if (int.TryParse(dr[0].ToString(), out maButToan))
                    {
                        if (maButToan != 0)
                        {
                            if (int.TryParse(dr[0].ToString(), out maButToan))
                            {
                                tblButToan itembutToan = ButToan_Factory.New().Get_ButToanByMaButToan(maButToan);
                                //DienGiai
                                if (itembutToan.DienGiai != null && bien == dsButToan.Rows.Count - 1)
                                    dienGiai += itembutToan.DienGiai.Trim();
                                else
                                    dienGiai += itembutToan.DienGiai.Trim() + ",";
                                bien += 1;
                            }
                        }
                    }
                }

                //Lấy dữ liệu chi phí sản xuất
                DataTable dsChiPhiSanXuat = LayDanhSachCT_ChiPhiSXToDataTable();
                foreach (DataRow dr in dsChiPhiSanXuat.Rows)
                {
                    int maCT_ChiPhiSX;
                    if (int.TryParse(dr[0].ToString(), out maCT_ChiPhiSX))
                    {
                        if (maCT_ChiPhiSX != 0)
                        {
                            tblCT_ChiPhiSanXuat itemCT_ChiPhiSanXuat = CT_ChiPhiSanXuat_Factory.New().Get_ByID(maCT_ChiPhiSX);
                            //Lấy dữ liệu chi phí sản xuất
                            if (itemCT_ChiPhiSanXuat.MaChuongTrinh != 0)
                            {
                                tblCT_ChiPhiSanXuat chungTu_ChiPhiSanXuatMoi = new tblCT_ChiPhiSanXuat();
                                chungTu_ChiPhiSanXuatMoi.MaChuongTrinh = itemCT_ChiPhiSanXuat.MaChuongTrinh;
                                chungTu_ChiPhiSanXuatMoi.TenChuongTrinh = itemCT_ChiPhiSanXuat.TenChuongTrinh;
                                chungTu_ChiPhiSanXuatMoi.SoTien = itemCT_ChiPhiSanXuat.SoTien;

                                //Lấy dữ liệu bút toán mục ngân sách
                                foreach (tblButToan_MucNganSach itembutToanMucNganSach in itemCT_ChiPhiSanXuat.tblButToan_MucNganSach)
                                {
                                    if (itembutToanMucNganSach.MaTieuMuc != 0)
                                    {
                                        tblButToan_MucNganSach butToan_MucNganSach = new tblButToan_MucNganSach(); ;
                                        butToan_MucNganSach.MaTieuMuc = itembutToanMucNganSach.MaTieuMuc;
                                        butToan_MucNganSach.SoTien = itembutToanMucNganSach.SoTien;
                                        butToan_MucNganSach.DienGiai = itembutToanMucNganSach.DienGiai;

                                        chungTu_ChiPhiSanXuatMoi.tblButToan_MucNganSach.Add(butToan_MucNganSach);
                                    }
                                }
                                butToan.tblCT_ChiPhiSanXuat.Add(chungTu_ChiPhiSanXuatMoi);
                            }
                        }

                    }
                }
                butToan.DienGiai = dienGiai;
                butToan.SoTien = _soTien_TienTe;
                _ChungTu.tblDinhKhoan.tblButToans.Add(butToan);

                _factoryMain.SaveChanges(BusinessCodeEnum.BangKe_ThuChi.ToString());

                ButToan_Factory.New().CapNhatButToanCacChungTuDaKCCP(_ChungTu.MaChungTu, _user.UserID, false);


                //Xóa bảng kết chuyển chứng từ tạm
                Delete_KetChuyenChiPhiTam(_user.UserID);

                MessageBox.Show("Kết chuyển thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //
                {
                    _danhSachChungTuKetChuyenList = new List<spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result>();
                    DanhSachChungTuKetChuyen_bindingSource.DataSource = _danhSachChungTuKetChuyenList;
                    grdV_DanhSachChungTuKetChuyen.RefreshData();
                    TaoChungTuNull();
                    lbSoTien.Text = null;
                    lbSoTienChiPhi.Text = null;
                    lbSoTienNganSach.Text = null;
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion //Functions

        #region Eventhandles
        private void grdV_DanhSachChungTu_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (grdV_DanhSachChungTu.FocusedColumn.FieldName == "Chon")
            {
                spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result currentItem = this.grdV_DanhSachChungTu.GetFocusedRow() as spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result;
                if (currentItem != null)
                {
                    currentItem.Chon = !currentItem.Chon;
                    grdV_DanhSachChungTu.RefreshData();
                }
            }
        }

        private void grdV_DanhSachChungTuKetChuyen_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (grdV_DanhSachChungTuKetChuyen.FocusedColumn.FieldName == "Chon")
            {
                spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result currentItem = this.grdV_DanhSachChungTuKetChuyen.GetFocusedRow() as spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result;
                if (currentItem != null)
                {
                    currentItem.Chon = !currentItem.Chon;
                    grdV_DanhSachChungTuKetChuyen.RefreshData();
                }
            }
        }
        #endregion //Eventhandles

        #region Events
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (KiemTraDieuKienTim())
            {
                _danhSachChungTuTimDuocList = _factory.Context.spd_DanhSachChungTuListByKetChuyenChiPhi_New(_tuNgayS, _denNgayS, _maBoPhanS, _userIDS, _maChuongTrinhS, _maTaiKhoanNoS, _maTieuMucS, _maMucNganSachS).ToList<spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result>(); //XuatDuLieuList.GetXuatDuLieuListByKetChuyenChiPhi_New(tuNgay, denNgay, maBoPhan, userID, maChuongTrinh, maTaiKhoanNo, maTieuMucNganSach, maMucNganSach);
                if (_danhSachChungTuTimDuocList.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DanhSachChungTu_bindingSource.DataSource = _danhSachChungTuTimDuocList;
                _danhSachChungTuKetChuyenList = new List<spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result>();
                DanhSachChungTuKetChuyen_bindingSource.DataSource = _danhSachChungTuKetChuyenList;
                lbSoTien.Text = "";
                lbSoTienChiPhi.Text = "";
                lbSoTienNganSach.Text = "";
            }

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            bool coChon = false;
            foreach (spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result itemTest in _danhSachChungTuTimDuocList)
            {
                if (itemTest.Chon == true)//Nếu đã chọn
                {
                    coChon = true;
                    break;
                }
            }
            if (!coChon)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần chuyển.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dtmp_Ngay.Focus();
            DialogResult _DialogResult = MessageBox.Show("Bạn có đồng ý đưa chứng từ qua không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                if (_danhSachChungTuKetChuyenList.Count == 0)
                {
                    KhoiTaoChungTuMoi();
                }
                ////Đưa dữ liệu vào danh sách chứng từ kết chuyển
                //for (int i = 0; i < grdV_DanhSachChungTu.RowCount; i++)
                //{
                //    spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result item =grdV_DanhSachChungTu.GetRow(i) as spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result;
                //    if (item.Chon == true)//Nếu đã chọn
                //    {
                //        item.Chon = false;
                //        _danhSachChungTuTimDuocList.Remove(item);
                //        _danhSachChungTuKetChuyenList.Add(item);
                //        i -= 1;
                //    }
                //}
                //Đưa dữ liệu vào danh sách chứng từ kết chuyển
                for (int i = 0; i < _danhSachChungTuTimDuocList.Count(); i++)
                {
                    spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result item = _danhSachChungTuTimDuocList.ElementAt<spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result>(i);
                    if (item.Chon == true)//Nếu đã chọn
                    {
                        item.Chon = false;
                        _danhSachChungTuTimDuocList.Remove(item);
                        _danhSachChungTuKetChuyenList.Add(item);
                        i -= 1;
                    }
                }
                DanhSachChungTu_bindingSource.DataSource = _danhSachChungTuTimDuocList;
                DanhSachChungTuKetChuyen_bindingSource.DataSource = _danhSachChungTuKetChuyenList;
                grdV_DanhSachChungTu.RefreshData();
                grdV_DanhSachChungTuKetChuyen.RefreshData();

                //Set lại dữ liệu
                Check_TatCa.Checked = false;
                Check_TatCaKetChuyen.Checked = false;
                //Lấy số tiền kết chuyển
                TinhSoTienKetChuyen();

                //Set giá trị cho tài khoản kết chuyển
                foreach (spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result item in _danhSachChungTuKetChuyenList)
                {
                    if (grdLu_TaiKhoanKetChuyen.EditValue == null)
                    {
                        grdLu_TaiKhoanKetChuyen.EditValue = item.MaTaiKhoan;
                    }
                    else if (Convert.ToInt32(grdLu_TaiKhoanKetChuyen.EditValue) != item.MaTaiKhoan && item.MaTaiKhoan != 0)
                    {
                        grdLu_TaiKhoanKetChuyen.EditValue = null;
                    }
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool coChon = false;
            foreach (spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result itemTest in _danhSachChungTuKetChuyenList)
            {
                if (itemTest.Chon == true)//Nếu đã chọn
                {
                    coChon = true;
                    break;
                }
            }
            if (!coChon)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult _DialogResult = MessageBox.Show("Bạn có thật sự muốn xóa dòng đã chọn không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                //Đưa dữ liệu về lại  vào danh sách chứng từ
                for (int i = 0; i < grdV_DanhSachChungTuKetChuyen.RowCount; i++)
                {
                    spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result item = grdV_DanhSachChungTuKetChuyen.GetRow(i) as spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result;
                    if (item.Chon == true)//Nếu đã chọn
                    {
                        item.Chon = false;
                        _danhSachChungTuKetChuyenList.Remove(item);
                        _danhSachChungTuTimDuocList.Add(item);
                        i -= 1;
                    }
                }

                ////Đưa dữ liệu về lại  vào danh sách chứng từ
                //for (int i = 0; i < _danhSachChungTuKetChuyenList.Count(); i++)
                //{
                //    spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result item = _danhSachChungTuKetChuyenList.ElementAt<spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result>(i);
                //    if (item.Chon == true)//Nếu đã chọn
                //    {
                //        item.Chon = false;
                //        _danhSachChungTuKetChuyenList.Remove(item);
                //        _danhSachChungTuTimDuocList.Add(item);
                //        i -= 1;
                //    }
                //}
                DanhSachChungTu_bindingSource.DataSource = _danhSachChungTuTimDuocList;
                DanhSachChungTuKetChuyen_bindingSource.DataSource = _danhSachChungTuKetChuyenList;
                grdV_DanhSachChungTu.RefreshData();
                grdV_DanhSachChungTuKetChuyen.RefreshData();

                //Tính lại số tiền kết chuyển chi phí
                TinhSoTienKetChuyen();
                //Setup lại dữ liệu
                Check_TatCa.Checked = false;
                Check_TatCaKetChuyen.Checked = false;
                //lbSoTien.Text = "";
                //lbSoTienChiPhi.Text = "";
                //lbSoTienNganSach.Text = "";

                if (_danhSachChungTuKetChuyenList.Count == 0)
                {
                    TaoChungTuNull();
                }
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtSoChungTu.Text = "";
            txt_DienGiai.Text = "";
            dtmp_Ngay.EditValue = DateTime.Now.Date;
            grdLu_TaiKhoanKetChuyen.EditValue = null;
            lbSoTien.Text = "";
            lbSoTienChiPhi.Text = "";
            lbSoTienNganSach.Text = "";
            _danhSachChungTuKetChuyenList = new List<spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result>();
            DanhSachChungTuKetChuyen_bindingSource.DataSource = _danhSachChungTuKetChuyenList;
            grdV_DanhSachChungTuKetChuyen.RefreshData();
            KhoiTaoChungTuMoi();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraDuLieuTruocKhiLuu())
            {
                Luu();
            }

        }

        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.BangKe_ThuChi, this.MdiParent);

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Check_TatCa_CheckedChanged(object sender, EventArgs e)
        {

            if (Check_TatCa.Checked == true)
            {
                for (int i = 0; i < grdV_DanhSachChungTu.RowCount; i++)
                {
                    spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result item = grdV_DanhSachChungTu.GetRow(i) as spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result;
                    if (item.Chon == false)
                    {
                        item.Chon = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdV_DanhSachChungTu.RowCount; i++)
                {
                    spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result item = grdV_DanhSachChungTu.GetRow(i) as spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result;
                    item.Chon = false;
                }
            }
            grdV_DanhSachChungTu.RefreshData();
        }

        private void Check_TatCaKetChuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_TatCaKetChuyen.Checked == true)
            {
                for (int i = 0; i < grdV_DanhSachChungTuKetChuyen.RowCount; i++)
                {
                    spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result item = grdV_DanhSachChungTuKetChuyen.GetRow(i) as spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result;
                    if ((item.Chon) == false)
                    {
                        item.Chon = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdV_DanhSachChungTuKetChuyen.RowCount; i++)
                {
                    spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result item = grdV_DanhSachChungTu.GetRow(i) as spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result;
                    if (item.Chon == false)
                    {
                        item.Chon = true;
                    }
                }
            }
            grdV_DanhSachChungTuKetChuyen.RefreshData();
        }

        #endregion //Events


        public FrmKetChuyenChiPhiE()
        {
            InitializeComponent();
            KhoiTao();
            LoadData();

        }









    }
}