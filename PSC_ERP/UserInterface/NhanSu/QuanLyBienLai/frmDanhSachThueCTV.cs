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
    public partial class frmDanhSachThueCTV : DevExpress.XtraEditors.XtraForm
    {
        #region
        NhanVienNgoaiDaiList _nhanVienList;
        ChungTuNganHangList _chungTuNganHangList;
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        string _nhanVien = "";
        string _chungTu = "";
        Boolean _choPhepPhatSinhSoMoi = true;
        NhanVienNgoaiDai _nvNgoaiDai_SoThuTuLonNhat = NhanVienNgoaiDai.NewNhanVienNgoaiDai();
        #endregion

        public frmDanhSachThueCTV()
        {
            InitializeComponent();
            dte_DenNgay.EditValue = DateTime.Today.Date;
            dte_TuNgay.EditValue = DateTime.Today.Date;
        }

        private void TimKiem()
        {
            try
            {
                if (cmbu_UyNhiemChi.EditValue == null)
                {
                    MessageBox.Show("Vui lòng chọn ủy nhiệm chi.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                _nhanVienList = NhanVienNgoaiDaiList.NewNhanVienNgoaiDaiList();
                DateTime tuNgay = Convert.ToDateTime(dte_TuNgay.EditValue);
                DateTime denNgay = Convert.ToDateTime(dte_DenNgay.EditValue);
                int maChungTu = Convert.ToInt32(cmbu_UyNhiemChi.EditValue);

                _nhanVienList = ERP_Library.NhanVienNgoaiDaiList.GetChungTuThueTNCNNhanVienNgoaiDaiList_ByNgayLapAndMaChungTu(tuNgay, denNgay, maChungTu);
                NhanVienNgoaiDai_BindingSource.DataSource = _nhanVienList;

                _choPhepPhatSinhSoMoi = true;
                _nvNgoaiDai_SoThuTuLonNhat = NhanVienNgoaiDai.NewNhanVienNgoaiDai();
            }
            catch (ApplicationException)
            {

            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private bool KiemTraVaLayDuLieuTruocKhiIn()
        {
            Boolean kq = true;
            _nhanVien = "";
            _chungTu = "";
            Boolean chungTuDaIn = false;
            Boolean daNhapQuyenSoKiHieu = true;
            txt_Focus.Focus();

            if (cmbu_UyNhiemChi.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn ủy nhiệm chi.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return kq = false;
            }
            if ((_nhanVienList == null) || (_nhanVienList != null && _nhanVienList.Count == 0))
            {
                MessageBox.Show("Chưa có nhân viên.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return kq = false;
            }

            NhanVienNgoaiDai_BindingSource.EndEdit();
            _nhanVienList.ApplyEdit();
            Boolean daChonChungTu = false;

            //Xóa tất dữ liệu trong danh sách chứng từ khấu trừ tạm
            XoaDanhSachChungTuKhauTruTam();

            foreach (NhanVienNgoaiDai item in _nhanVienList)
            {
                if (item.Chon == true)
                {
                    /////////////////Lưu ký hiệu quyển và số trước khi in///////////////////

                    //Kiểm tra bị trùng
                    if (KiemTraKyKyHieuAndQuyenAndSo(item.MaNhanVien, item.KyHieu, item.Quyen, item.So, item.MaUNC) > 0)
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
                        CapNhatThueCongTacVien_KyHieuQuyenSo(item.MaUNC, item.MaNhanVien, item.KyHieu, item.Quyen, item.So, item.MaBoPhan, item.STT);
                    }
                    catch (Exception ex) { throw; }
                    
                    //Lấy danh sách mã nhân viên và mã chứng từ đã chọn đưa vào danh sách tạm
                    InsertDanhSachChungTuKhauTruTam(item.MaNhanVien, item.MaUNC);

                    // Kiểm tra xem đã lưu ký hiệu quyển số chưa
                    if (KiemTraDaNhap_KyHieuAndQuyenAndSo(item.MaNhanVien, item.MaUNC) > 0)
                    {
                        daNhapQuyenSoKiHieu = false;
                    }

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
                ReportTemplate _report = ReportTemplate.GetReportTemplate("ChungTuKhauTruThueTNCNNgoaiDai");
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
                    frm.Show();

                    //Cập nhật trạng thái đã in
                    foreach (NhanVienNgoaiDai item in _nhanVienList)
                    {
                        if (item.Chon == true && item.TinhTrangIn == false)
                        {
                            CapNhatTrangThaiIn(item.MaNhanVien,item.MaUNC, item.KyHieu, item.Quyen, item.So, true);
                        }
                    }
                }

                TimKiem();
            }
        }

        public bool Spd_ChungTuKhauTruThueTNCNNgoaiDai()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tạo bảng chứng từ khấu trừ thếu thu nhập cá nhân
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportChungTuKhauTruThueThuNhapCaNhanNhanVienNgoaiDai";
                    cm.Parameters.AddWithValue("@NhanVien", _nhanVien);
                    cm.Parameters.AddWithValue("@ChungTu", _chungTu);

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
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dte_TuNgay.EditValue;
                dr["DenNgay"] = dte_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }//us 
            return true;
        }
        private void CapNhatThueCongTacVien_KyHieuQuyenSo(int maUNC,long maNhanVien, string kyHieu, string quyen, string so, int maBoPhan, int sTT)
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
                    cm.CommandText = "spd_UpdatetblThueCongTacVien_KyHieuAndQuyenAndSo";
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
        private void CapNhatTrangThaiIn(long maNhanVien,int maUNC ,string kyHieu, string quyen, string so, Boolean tinhTrangIn)
        {
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_UpdateThueCongTacVien_TrangThaiIn";
                    cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cm.Parameters.AddWithValue("@MaUNC", maUNC);
                    cm.Parameters.AddWithValue("@Quyen", quyen);
                    cm.Parameters.AddWithValue("@So", so);
                    cm.Parameters.AddWithValue("@KyHieu", kyHieu);
                    cm.Parameters.AddWithValue("@TrangThai", tinhTrangIn);

                    cm.ExecuteNonQuery();
                }
            }//using
        }
        private void InsertDanhSachChungTuKhauTruTam(long maNhanVien, int maUNC)
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
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }
        private void frmDanhSachChungTuKhauTruTTNCN_Load(object sender, EventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Office 2007 Blue";
            // gridView_NhanVienNgoaiDai.OptionsBehavior.Editable = false;

            Utils.GridUtils.SetSTTForGridView(gridView_NhanVienNgoaiDai, 35);
            Utils.GridUtils.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(gridView_NhanVienNgoaiDai, gridView_NhanVienNgoaiDai.Columns["Chon"]);

            dte_TuNgay.EditValue = DateTime.Now.Date;
            dte_DenNgay.EditValue = DateTime.Now.Date;

            //
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TimKiem();
        }

        private void dte_DenNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            if (dte_TuNgay.EditValue != null && dte_DenNgay.EditValue != null)
            {
                DateTime tuNgay = Convert.ToDateTime(dte_TuNgay.EditValue);
                DateTime denNgay = Convert.ToDateTime(dte_DenNgay.EditValue);

                _chungTuNganHangList = ChungTuNganHangList.GetChungTuNganHangList(tuNgay, denNgay);

                ChungTuNganHang chungTuNganHang = new ChungTuNganHang() { MaChungTu = 0, So = "Tất Cả" };
                _chungTuNganHangList.Insert(0,chungTuNganHang);
                ChungTuNganHang_BindingSource.DataSource = _chungTuNganHangList;
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            txt_Focus.Focus();
            //Kiểm tra dữ liệu
            if ((_nhanVienList == null) || (_nhanVienList != null && _nhanVienList.Count == 0))
            {
                MessageBox.Show("Chưa có nhân viên.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            NhanVienNgoaiDai_BindingSource.EndEdit();
            _nhanVienList.ApplyEdit();

            bool daChonNhanVien = false;
            bool daIn = false;
            //Duyệt qua các dòng đã chọn trên lưới
            foreach (NhanVienNgoaiDai item in _nhanVienList)
            {
                if (item.Chon == true)
                {
                    daChonNhanVien = true;

                    if (item.TinhTrangIn && (string.IsNullOrEmpty(item.KyHieu) || string.IsNullOrEmpty(item.Quyen) || string.IsNullOrEmpty(item.So)))
                    {
                        MessageBox.Show("Không thể cập nhật quyển số và ký hiệu khi chứng từ đã in.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }

                    //Cập nhật trang thái đã in
                    CapNhatTrangThaiIn(item.MaNhanVien, item.MaUNC,item.KyHieu, item.Quyen, item.So, item.TinhTrangIn);

                    if (KiemTraKyKyHieuAndQuyenAndSo(item.MaNhanVien, item.KyHieu, item.Quyen, item.So, item.MaUNC) > 0)
                    {
                        MessageBox.Show("Ký hiệu quyển và số đã bị trùng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (item.So.Length > 7)
                    {
                        MessageBox.Show("Tối đa 7 số.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    try
                    {
                         //Tiến hành cập nhật lại thông tin trong thuế cộng tác viên
                        CapNhatThueCongTacVien_KyHieuQuyenSo(item.MaUNC, item.MaNhanVien, item.KyHieu, item.Quyen, item.So, item.MaBoPhan,item.STT);                                             
                    }
                    catch (Exception ex) { throw; }
                }
            }
            if (daChonNhanVien == false)
            {
                MessageBox.Show("Chưa chọn nhân viên.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            _nvNgoaiDai_SoThuTuLonNhat = NhanVienNgoaiDai.NewNhanVienNgoaiDai();

            MessageBox.Show("Cập nhật thành công.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //Load lại danh sách
            TimKiem();
        }

        private void dte_TuNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
      
        private static int KiemTraDaNhap_KyHieuAndQuyenAndSo(long maNhanVien, int maChungTu)
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
                        cm.CommandText = "spd_KiemTraDaNhap_KyHieuAndQuyenAndSo";
                        cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
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
        private static int KiemTraKyKyHieuAndQuyenAndSo(long maNhanVien, string kyHieu, string quyen, string so, int maUNC)
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
                        cm.CommandText = "spd_KiemTraKyHieuAndQuyenAndSo_ThueCongTacVien";
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
                        cm.Parameters.AddWithValue("@MaUNC", maUNC);

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
                ReportTemplate _report = ReportTemplate.GetReportTemplate("ChungTuKhauTruThueTNCNNgoaiDai");
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
                    foreach (NhanVienNgoaiDai item in _nhanVienList)
                    {
                        if (item.Chon == true && item.TinhTrangIn == false)
                        {
                            CapNhatTrangThaiIn(item.MaNhanVien, item.MaUNC, item.KyHieu, item.Quyen, item.So, true);
                        }
                    }
                }
                TimKiem();
            }
        }

        private void frmDanhSachThueCTV_FormClosed(object sender, FormClosedEventArgs e)
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

            if (_nvNgoaiDai_SoThuTuLonNhat.MaNhanVien == 0)
            {
                //Lấy dòng có số thứ tự lớn nhất
                foreach (NhanVienNgoaiDai item in _nhanVienList)
                {
                    int sTTCurrent = item.STT == null ? 0 : item.STT;

                    int sTTMax = _nvNgoaiDai_SoThuTuLonNhat.STT == null ? 0 : _nvNgoaiDai_SoThuTuLonNhat.STT;

                    if (sTTCurrent >= sTTMax)
                    {
                        _nvNgoaiDai_SoThuTuLonNhat = item;
                    }
                }
            }

            if (e.Column.FieldName == "Chon")
            {

                int soNew = 0;
                bool resultsoNew = Int32.TryParse(_nvNgoaiDai_SoThuTuLonNhat.So, out soNew);

                if (_nvNgoaiDai_SoThuTuLonNhat.So.Length > 7)
                {
                    MessageBox.Show("Tối đa 7 số.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                foreach (NhanVienNgoaiDai item in _nhanVienList)
                {
                    if (item.Chon == true && (item.MaNhanVien != _nvNgoaiDai_SoThuTuLonNhat.MaNhanVien || item.MaUNC != _nvNgoaiDai_SoThuTuLonNhat.MaUNC) && string.IsNullOrEmpty(item.Quyen) && string.IsNullOrEmpty(item.KyHieu) && string.IsNullOrEmpty(item.So))
                    {
                        item.KyHieu = _nvNgoaiDai_SoThuTuLonNhat.KyHieu;
                        item.Quyen = _nvNgoaiDai_SoThuTuLonNhat.Quyen;
                        //Cập nhật số thứ tự
                        item.STT = _nvNgoaiDai_SoThuTuLonNhat.STT + 1;

                        item.So = SoTrongThueCongTacVien((soNew + 1));
                        _nvNgoaiDai_SoThuTuLonNhat = item;
                    }
                }
            }
            
            NhanVienNgoaiDai_BindingSource.DataSource = _nhanVienList;
            gridView_NhanVienNgoaiDai.RefreshData();
        }

        private string SoTrongThueCongTacVien(int soNew)
        {
            string ketQua = string.Empty;

            if (soNew <10)
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
    }
}