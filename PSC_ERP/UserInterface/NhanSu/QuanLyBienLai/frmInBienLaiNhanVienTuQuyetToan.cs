using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data.SqlClient;
//Tài
namespace PSC_ERP
{
    public partial class frmInBienLaiNhanVienTuQuyetToan : DevExpress.XtraEditors.XtraForm
    {
        #region
        InBienLaiNhanVienTuQuyetToanRootList _bienLaiNhanVientuQTList;
        ChungTuNganHangList _chungTuNganHangList;
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        Int64 _nhanVien = 0;
        long _maChungTu = 0;
        string _chungTu = "";
        Boolean _choPhepPhatSinhSoMoi = true;
        InBienLaiNhanVienTuQuyetToan _bienLai_SoThuTuLonNhat = InBienLaiNhanVienTuQuyetToan.NewInBienLaiNhanVienTuQuyetToanChild();

        BindingSource _KyTinhLuongListBs = new BindingSource();

        #region BoSung TienMat
        private int _maKyTinhLuong = 0;
        private bool _loadFinish = false;
        #endregion//BoSung TienMat
        #endregion

        #region Constructors
        public frmInBienLaiNhanVienTuQuyetToan()
        {
            InitializeComponent();
            InitForm();
            LoadDataForForm();
        }

        public frmInBienLaiNhanVienTuQuyetToan(QuyetToanThueTNCN_TheoThangList danhsachNVtuQuyetToan)
        {
            InitializeComponent();
            InitForm();
            LoadDataForForm();
            KyTinhLuonggridLookUpEdit.EditValue = danhsachNVtuQuyetToan[0].MaKyQuyetToan;
            _maKyTinhLuong = danhsachNVtuQuyetToan[0].MaKyQuyetToan;
            LoadData(danhsachNVtuQuyetToan);
            
        }
        public frmInBienLaiNhanVienTuQuyetToan(int maKyQuyetToan)
        {
            InitializeComponent();
            InitForm();
            LoadDataForForm();
            KyTinhLuonggridLookUpEdit.EditValue = maKyQuyetToan;
            _maKyTinhLuong = maKyQuyetToan;
            TimKiem();

        }

        private void InitForm()
        {
            _KyTinhLuongListBs.DataSource = typeof(KyTinhLuongList);
            BienLaiNhanVienTuQuyetToanList_bindingSource.DataSource = typeof(InBienLaiNhanVienTuQuyetToanRootList);
            DesignGridControl();
            _bienLaiNhanVientuQTList = InBienLaiNhanVienTuQuyetToanRootList.NewInBienLaiNhanVienTuQuyetToanRootList();
        }

        private void LoadDataForForm()
        {
            _KyTinhLuongListBs.DataSource = KyTinhLuongList.GetKyTinhLuongList();

        }

        private void LoadData(QuyetToanThueTNCN_TheoThangList danhsachNVtuQuyetToan)
        {
            foreach (QuyetToanThueTNCN_TheoThang qt in danhsachNVtuQuyetToan)
            {
                InBienLaiNhanVienTuQuyetToan bl = InBienLaiNhanVienTuQuyetToan.NewInBienLaiNhanVienTuQuyetToanChild();

                bl.MaNhanVien = qt.MaNhanVien;
                bl.MaKyQuyetToan = qt.MaKyQuyetToan;
                bl.Nam = qt.Nam;
                bl.Thang = qt.Thang;
                bl.MaBoPhan = 0;
                bl.TenNhanVien = qt.TenNhanVien;
                bl.Mst = qt.MST;
                bl.Cmnd = qt.CMND;
                bl.SoTien = qt.TongThuNhapChiuThue;
                bl.TienThue = qt.TongTienThue;
                //bl.SoTienConLai = 0;
                bl.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                bl.Quyen = string.Empty;
                bl.KyHieu = string.Empty;
                bl.So = string.Empty;
                bl.Stt = 0;
                bl.TinhTrangIn = false;

                bl.TenBoPhan = qt.TenBoPhan;
                _bienLaiNhanVientuQTList.Add(bl);
            }
            BindingValueData();
        }

        private void BindingValueData()
        {
            BienLaiNhanVienTuQuyetToanList_bindingSource.DataSource = _bienLaiNhanVientuQTList;
        }

        #endregion//Constructors

        #region BoSung TienMat



        private bool GetThongTinMaKy()
        {
            if (KyTinhLuonggridLookUpEdit.EditValue != null)
            {
                _maKyTinhLuong = Convert.ToInt32(KyTinhLuonggridLookUpEdit.EditValue);
                return true;
            }
            MessageBox.Show("Kỳ tín lương không hợp lệ Không Hợp Lệ", "Thông Báo");
            return false;
        }



        private void GetThongTinIn()
        {
            foreach (InBienLaiNhanVienTuQuyetToan item in _bienLaiNhanVientuQTList)
            {
                if (item.Chon == true && item.TinhTrangIn == false)
                {
                    _nhanVien = item.MaNhanVien;
                    //_maChungTu = item.MaChungTu;
                    break;
                }
            }
        }
        #endregion//BoSung TienMat

        #region Functions
        private void DesignKyTinhLuonggridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(KyTinhLuonggridLookUpEdit, _KyTinhLuongListBs, "TenKy", "MaKy", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(KyTinhLuonggridLookUpEdit, new string[] { "TenKy", "NgayBatDau", "NgayKetThuc" }, new string[] { "Kỳ", "Ngày bắt đầu", "Ngày kết thúc" }, new int[] { 80, 80, 80 }, false);
            //KyTinhLuonggridLookUpEdit.EditValueChanged += new System.EventHandler(this.KyTinhLuonggridLookUpEdit_EditValueChanged);
        }

        private void DesignGridControl()
        {
            DesignKyTinhLuonggridLookUpEdit();
        }
        #endregion Functions

        private void TimKiem()
        {
            try
            {
                if (GetThongTinMaKy())
                {
                    _bienLaiNhanVientuQTList = InBienLaiNhanVienTuQuyetToanRootList.NewInBienLaiNhanVienTuQuyetToanRootList();
                    if (_maKyTinhLuong != 0)
                        _bienLaiNhanVientuQTList = InBienLaiNhanVienTuQuyetToanRootList.GetInBienLaiNhanVienTuQuyetToanRootList(_maKyTinhLuong);
                    BindingValueData();

                    _choPhepPhatSinhSoMoi = true;
                    _bienLai_SoThuTuLonNhat = InBienLaiNhanVienTuQuyetToan.NewInBienLaiNhanVienTuQuyetToanChild();
                }
            }
            catch (ApplicationException)
            {

            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private bool KiemTraTruocKhiXoa()
        {
            int[] deleteRows = gridView_NhanVienNgoaiDai.GetSelectedRows();
            foreach (int deleteRow in deleteRows)
            {
                InBienLaiNhanVienTuQuyetToan blai = gridView_NhanVienNgoaiDai.GetRow(deleteRow) as InBienLaiNhanVienTuQuyetToan;
                if (blai.TinhTrangIn)
                {
                    MessageBox.Show("Biên lai đã in, không thể xóa", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return false;
                }

            }
            return true;
        }

        private bool KiemTraVaLayDuLieuTruocKhiIn()
        {
            Boolean kq = true;
            _nhanVien = 0;
            _chungTu = "";
            Boolean chungTuDaIn = false;
            Boolean daNhapQuyenSoKiHieu = true;
            txt_Focus.Focus();

            if ((_bienLaiNhanVientuQTList == null) || (_bienLaiNhanVientuQTList != null && _bienLaiNhanVientuQTList.Count == 0))
            {
                MessageBox.Show("Chưa có nhân viên.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return kq = false;
            }

            NhanVienNgoaiDai_BindingSource.EndEdit();
            _bienLaiNhanVientuQTList.ApplyEdit();
            Boolean daChonChungTu = false;

            //Xóa tất dữ liệu trong danh sách chứng từ khấu trừ tạm
            XoaDanhSachChungTuKhauTruTam();

            foreach (InBienLaiNhanVienTuQuyetToan item in _bienLaiNhanVientuQTList)
            {
                if (item.Chon == true)
                {
                    /////////////////Lưu ký hiệu quyển và số trước khi in///////////////////

                    //Kiểm tra bị trùng
                    if (KiemTraTrungKyKyHieuAndQuyenAndSo(item.MaNhanVien, item.KyHieu, item.Quyen, item.So, item.MaKyQuyetToan) > 0)
                    {
                        MessageBox.Show("Ký hiệu quyển và số đã bị trùng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return kq = false;
                    }
                    if (item.So.Length > 7)
                    {
                        MessageBox.Show("Tối đa 7 số.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return kq = false;
                    }
                    try
                    {
                        //Tiến hành cập nhật lại thông tin trong thuế cộng tác viên
                        _bienLaiNhanVientuQTList.Save();
                        //CapNhatThueCongTacVien_KyHieuQuyenSo(item.MaChungTu, item.MaNhanVien, item.KyHieu, item.Quyen, item.So, item.MaBoPhan, item.STT);
                    }
                    catch (Exception ex) { throw; }

                    ////Lấy danh sách mã nhân viên và mã chứng từ đã chọn đưa vào danh sách tạm
                    //InsertDanhSachChungTuKhauTruTam(item.MaNhanVien, item.MaChungTu);

                    //// Kiểm tra xem đã lưu ký hiệu quyển số chưa
                    //if (KiemTraDaNhap_KyHieuAndQuyenAndSo(item.MaNhanVien, item.MaChungTu) > 0)
                    //{
                    //    daNhapQuyenSoKiHieu = false;
                    //}

                    daChonChungTu = true;
                }
                if (item.TinhTrangIn == true && item.Chon == true)
                {
                    chungTuDaIn = true;
                }
            }

            if (daChonChungTu == false)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return kq = false;
            }

            if (chungTuDaIn == true)
            {
                MessageBox.Show("Có chứng từ đã in rồi.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return kq = false;
            }

            if (daNhapQuyenSoKiHieu == false)
            {
                MessageBox.Show("Chưa nhập Quyển, Số hoặc Ký Hiệu.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return kq = false;
            }
            return kq;
        }
        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ////Kiểm tra và lấy dữ liệu trước khi in
            if (KiemTraVaLayDuLieuTruocKhiIn() == true)
            {
                //Bắt đầu in
                ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_ChungTuKhauTruThueTNCNNhanVienTuQuyetToan");
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();


                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = UserId;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }
                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.ShowDialog();

                    //Cập nhật trạng thái đã in
                    foreach (InBienLaiNhanVienTuQuyetToan item in _bienLaiNhanVientuQTList)
                    {
                        if (item.Chon == true && item.TinhTrangIn == false)
                        {
                            CapNhatTrangThaiIn(item.MaNhanVien, item.MaKyQuyetToan, item.KyHieu, item.Quyen, item.So, true);
                        }
                    }
                }

                TimKiem();
            }
        }

        public bool MeThod_ChungTuKhauTruThueTNCNNhanVienTuQuyetToan()
        {
            GetThongTinIn();
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tạo bảng chứng từ khấu trừ thếu thu nhập cá nhân
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportChungTuKhauTruThueThuNhapCaNhanNhanVienTuQuyetToanThue";
                    //cm.Parameters.AddWithValue("@NhanVien", ((NhanVienNgoaiDai)NhanVienNgoaiDai_BindingSource.Current).MaNhanVien);
                    //cm.Parameters.AddWithValue("@ChungTu", ((NhanVienNgoaiDai)NhanVienNgoaiDai_BindingSource.Current).MaChungTu);
                    cm.Parameters.AddWithValue("@NhanVien", _nhanVien);
                    cm.Parameters.AddWithValue("@MaKyQuyetToan", _maKyTinhLuong);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportChungTuKhauTruThueThuNhapCaNhanNhanVienNgoaiDai;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter_New";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter_New;1";
                    dataSet.Tables.Add(dt);
                }
                ////Tao Bang Chua TuNgay, DenNgay
                //DataTable dtngay = new DataTable();
                //dtngay.Columns.Add("TuNgay", typeof(DateTime));
                //dtngay.Columns.Add("DenNgay", typeof(DateTime));
                ////Add dòng 1
                //DataRow dr = dtngay.NewRow();
                //dr["TuNgay"] = dte_TuNgay.EditValue;
                //dr["DenNgay"] = dte_DenNgay.EditValue;
                //dtngay.Rows.Add(dr);
                //dtngay.TableName = "TblTuNgay_DenNgay:1";
                //dataSet.Tables.Add(dtngay);

            }//us 
            return true;
        }
        private void CapNhatThueCongTacVien_KyHieuQuyenSo(long maUNC, long maNhanVien, string kyHieu, string quyen, string so, int maBoPhan, int sTT)
        {
            if (string.IsNullOrWhiteSpace(kyHieu) && string.IsNullOrWhiteSpace(quyen) && string.IsNullOrWhiteSpace(so))
            {
                kyHieu = "";
                quyen = "";
                so = "";
            }

            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdatetblThueCongTacVien_KyHieuAndQuyenAndSo_TienMat";
                    cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cm.Parameters.AddWithValue("@MaUNC", maUNC);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@STT", sTT);
                    if (kyHieu.Length > 0)
                        cm.Parameters.AddWithValue("@KyHieu", kyHieu.Trim());
                    else
                        cm.Parameters.AddWithValue("@KyHieu", DBNull.Value);
                    if (quyen.Length > 0)
                        cm.Parameters.AddWithValue("@Quyen", quyen.Trim());
                    else
                        cm.Parameters.AddWithValue("@Quyen", DBNull.Value);
                    if (so.Length > 0)
                        cm.Parameters.AddWithValue("@So", so.Trim());
                    else
                        cm.Parameters.AddWithValue("@So", DBNull.Value);

                    cm.ExecuteNonQuery();
                }
            }//using
        }
        private void CapNhatTrangThaiIn(long maNhanVien, long makyquyettoan, string kyHieu, string quyen, string so, Boolean tinhTrangIn)
        {
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_UpdateInBienLaiNhanVienTuQuyetToan_TrangThaiIn";
                    cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cm.Parameters.AddWithValue("@MaKyQuyetToan", makyquyettoan);
                    cm.Parameters.AddWithValue("@Quyen", quyen);
                    cm.Parameters.AddWithValue("@So", so);
                    cm.Parameters.AddWithValue("@KyHieu", kyHieu);
                    cm.Parameters.AddWithValue("@TrangThai", tinhTrangIn);

                    cm.ExecuteNonQuery();
                }
            }//using
        }
        private void InsertDanhSachChungTuKhauTruTam(long maNhanVien, long maUNC)
        {
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_InsertDanhSachChungTuKhauTruTam";
                    cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cm.Parameters.AddWithValue("@MaUNC", maUNC);

                    cm.ExecuteNonQuery();
                }
            }//using
        }
        private void XoaDanhSachChungTuKhauTruTam()
        {
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_DeleteanhSachChungTuKhauTruTam";

                    cm.ExecuteNonQuery();
                }
            }//using
        }
        private void frmDanhSachChungTuKhauTruTTNCN_Load(object sender, EventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Office 2007 Blue";
            // gridView_NhanVienNgoaiDai.OptionsBehavior.Editable = false;

            Utils.GridUtils.SetSTTForGridView(gridView_NhanVienNgoaiDai, 35);
            Utils.GridUtils.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(gridView_NhanVienNgoaiDai, gridView_NhanVienNgoaiDai.Columns["Chon"]);

            //dte_TuNgay.EditValue = DateTime.Now.Date;
            //dte_DenNgay.EditValue = DateTime.Now.Date;
            _loadFinish = true;
            //
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TimKiem();
        }

        private void dte_DenNgay_EditValueChanged(object sender, EventArgs e)
        {
            //if (_loadFinish)
            //    //LoadData();
            //    LoadDanhSachChungTuPhieuChi();
        }
        //private void LoadData()
        //{
        //    if (dte_TuNgay.EditValue != null && dte_DenNgay.EditValue != null)
        //    {
        //        DateTime tuNgay = Convert.ToDateTime(dte_TuNgay.EditValue);
        //        DateTime denNgay = Convert.ToDateTime(dte_DenNgay.EditValue);

        //        _chungTuNganHangList = ChungTuNganHangList.GetChungTuNganHangList(tuNgay, denNgay);

        //        ChungTuNganHang chungTuNganHang = new ChungTuNganHang() { MaChungTu = 0, So = "Tất Cả" };
        //        _chungTuNganHangList.Insert(0, chungTuNganHang);
        //        ChungTuNganHang_BindingSource.DataSource = _chungTuNganHangList;
        //    }
        //}

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            txt_Focus.Focus();
            //Kiểm tra dữ liệu
            //if ((_bienLaiNhanVientuQTList == null) || (_bienLaiNhanVientuQTList != null && _bienLaiNhanVientuQTList.Count == 0))
            //{
            //    MessageBox.Show("Chưa có nhân viên.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    return;
            //}

            BienLaiNhanVienTuQuyetToanList_bindingSource.EndEdit();
            _bienLaiNhanVientuQTList.ApplyEdit();

            bool daChonNhanVien = false;
            bool daIn = false;
            //Duyệt qua các dòng đã chọn trên lưới
            foreach (InBienLaiNhanVienTuQuyetToan item in _bienLaiNhanVientuQTList)
            {
                if (item.Chon == true)
                {
                    daChonNhanVien = true;

                    if (item.TinhTrangIn && (string.IsNullOrEmpty(item.KyHieu) || string.IsNullOrEmpty(item.Quyen) || string.IsNullOrEmpty(item.So)))
                    {
                        MessageBox.Show("Không thể cập nhật quyển số và ký hiệu khi đã in.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }

                    ////Cập nhật trang thái đã in
                    //CapNhatTrangThaiIn(item.MaNhanVien, item.MaChungTu, item.KyHieu, item.Quyen, item.So, item.TinhTrangIn);

                    if (KiemTraTrungKyKyHieuAndQuyenAndSo(item.MaNhanVien, item.KyHieu, item.Quyen, item.So, item.MaKyQuyetToan) > 0)
                    {
                        MessageBox.Show("Ký hiệu quyển và số đã bị trùng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (item.So.Length > 7)
                    {
                        MessageBox.Show("Tối đa 7 số.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //try
                    //{
                    //    //Tiến hành cập nhật lại thông tin trong thuế cộng tác viên
                    //    _bienLaiNhanVientuQTList.Save();
                    //    //CapNhatThueCongTacVien_KyHieuQuyenSo(item.MaChungTu, item.MaNhanVien, item.KyHieu, item.Quyen, item.So, item.MaBoPhan, item.STT);
                    //}
                    //catch (Exception ex) { throw; }
                }
            }
            //if (daChonNhanVien == false)
            //{
            //    MessageBox.Show("Chưa chọn nhân viên.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    return;
            //}
            try
            {
                //Tiến hành cập nhật lại thông tin trong thuế cộng tác viên
                _bienLaiNhanVientuQTList.Save();
                //CapNhatThueCongTacVien_KyHieuQuyenSo(item.MaChungTu, item.MaNhanVien, item.KyHieu, item.Quyen, item.So, item.MaBoPhan, item.STT);
            }
            catch (Exception ex) { throw; }

            _bienLai_SoThuTuLonNhat = InBienLaiNhanVienTuQuyetToan.NewInBienLaiNhanVienTuQuyetToanChild();

            MessageBox.Show("Cập nhật thành công.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //Load lại danh sách
            TimKiem();
        }


        //private static int KiemTraDaNhap_KyHieuAndQuyenAndSo(long maNhanVien, long maChungTu)
        //{
        //    int gt = 0;
        //    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //    {
        //        cn.Open();
        //        try
        //        {
        //            using (SqlCommand cm = cn.CreateCommand())
        //            {
        //                cm.CommandType = CommandType.StoredProcedure;
        //                cm.CommandText = "spd_KiemTraDaNhap_KyHieuAndQuyenAndSo_TienMat";
        //                cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
        //                cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
        //                cm.Parameters.AddWithValue("@GiaTri", gt);
        //                cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

        //                cm.ExecuteNonQuery();
        //                gt = (int)cm.Parameters["@GiaTri"].Value;

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return gt;
        //    }//using
        //}
        private static int KiemTraTrungKyKyHieuAndQuyenAndSo(long maNhanVien, string kyHieu, string quyen, string so, int maKyQT)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraTrungKyHieuAndQuyenAndSo_BienLaiNhanVien";
                        if (kyHieu.Length > 0)
                            cm.Parameters.AddWithValue("@KyHieu", kyHieu);
                        else
                            cm.Parameters.AddWithValue("@KyHieu", DBNull.Value);
                        if (quyen.Length > 0)
                            cm.Parameters.AddWithValue("@Quyen", quyen);
                        else
                            cm.Parameters.AddWithValue("@Quyen", DBNull.Value);

                        cm.Parameters.AddWithValue("@So", so);
                        cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        cm.Parameters.AddWithValue("@MaKyQuyetToan", maKyQT);

                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }

        private void btnInNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////Kiểm tra và lấy dữ liệu trước khi in
            if (KiemTraVaLayDuLieuTruocKhiIn() == true)
            {
                ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_ChungTuKhauTruThueTNCNNhanVienTuQuyetToan");
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();

                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = UserId;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }
                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.InTrucTiepReport(_reportTemplate, dataSet);

                    //Cập nhật trạng thái đã in
                    foreach (InBienLaiNhanVienTuQuyetToan item in _bienLaiNhanVientuQTList)
                    {
                        if (item.Chon == true && item.TinhTrangIn == false)
                        {
                            CapNhatTrangThaiIn(item.MaNhanVien, item.MaKyQuyetToan, item.KyHieu, item.Quyen, item.So, true);
                        }
                    }
                }
                TimKiem();
            }
        }

        private void frmInBienLaiNhanVienTuQuyetToan_FormClosed(object sender, FormClosedEventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = " DevExpress Style";
        }

        private string ChuoiKhong(string chuoi)
        {
            string kq = "";
            foreach (char kiTu in chuoi)
            {
                if (kiTu == '0')
                {
                    kq = kq + kiTu;
                }
                else
                {
                    return kq;
                }
            }
            return kq;
        }
        private void gridView_NhanVienNgoaiDai_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            txt_Focus.Focus();
            if (e.Column.FieldName == "TinhTrangIn")
                return;

            if (_bienLai_SoThuTuLonNhat.MaNhanVien == 0)
            {
                //Lấy dòng có số thứ tự lớn nhất
                foreach (InBienLaiNhanVienTuQuyetToan item in _bienLaiNhanVientuQTList)
                {
                    int sTTCurrent = item.Stt == null ? 0 : item.Stt;

                    int sTTMax = _bienLai_SoThuTuLonNhat.Stt == null ? 0 : _bienLai_SoThuTuLonNhat.Stt;

                    if (sTTCurrent >= sTTMax)
                    {
                        _bienLai_SoThuTuLonNhat = item;
                    }
                }
            }

            if (e.Column.FieldName == "Chon")
            {

                int soNew = 0;
                bool resultsoNew = Int32.TryParse(_bienLai_SoThuTuLonNhat.So, out soNew);

                if (_bienLai_SoThuTuLonNhat.So.Length > 7)
                {
                    MessageBox.Show("Tối đa 7 số.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                foreach (InBienLaiNhanVienTuQuyetToan item in _bienLaiNhanVientuQTList)
                {
                    if (item.Chon == true && (item.MaNhanVien != _bienLai_SoThuTuLonNhat.MaNhanVien || item.MaKyQuyetToan != _bienLai_SoThuTuLonNhat.MaKyQuyetToan) && string.IsNullOrEmpty(item.Quyen) && string.IsNullOrEmpty(item.KyHieu) && string.IsNullOrEmpty(item.So))
                    {
                        item.KyHieu = _bienLai_SoThuTuLonNhat.KyHieu;
                        item.Quyen = _bienLai_SoThuTuLonNhat.Quyen;
                        //Cập nhật số thứ tự
                        item.Stt = _bienLai_SoThuTuLonNhat.Stt + 1;

                        item.So = SetSoBienLai((soNew + 1));
                        _bienLai_SoThuTuLonNhat = item;
                    }
                }
            }

            NhanVienNgoaiDai_BindingSource.DataSource = _bienLaiNhanVientuQTList;
            gridView_NhanVienNgoaiDai.RefreshData();
        }

        private string SetSoBienLai(int soNew)
        {
            string ketQua = string.Empty;

            if (soNew < 10)
            {
                ketQua = "000000" + soNew;
            }
            else if (soNew < 100)
            {
                ketQua = "00000" + soNew;
            }
            else if (soNew < 1000)
            {
                ketQua = "0000" + soNew;
            }
            else if (soNew < 10000)
            {
                ketQua = "000" + soNew;
            }
            else if (soNew < 100000)
            {
                ketQua = "00" + soNew;
            }
            else if (soNew < 1000000)
            {
                ketQua = "0" + soNew;
            }
            else if (soNew < 10000000)
            {
                ketQua = Convert.ToString(soNew);
            }

            return ketQua;
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HamDungChung.ExportToExcelFromGridViewDev(gridView_NhanVienNgoaiDai);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraTruocKhiXoa())
            {
                if (MessageBox.Show("Bạn muốn xóa các dòng đang chọn?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gridView_NhanVienNgoaiDai.DeleteSelectedRows();
                }
            }


        }
    }
}