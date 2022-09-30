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
    public partial class frmCapNhatThueCTV_TienMat : DevExpress.XtraEditors.XtraForm
    {
        #region
        NhanVienNgoaiDaiList _nhanVienList;
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        NhanVienNgoaiDai _nvNgoaiDai_SoThuTuLonNhat = NhanVienNgoaiDai.NewNhanVienNgoaiDai();

        private long _maChungTuPC = 0;
        private DateTime _tuNgay;
        private DateTime _denNgay;
        private bool _loadFinish = false;
        #endregion

        public frmCapNhatThueCTV_TienMat()
        {
            InitializeComponent();
            dte_DenNgay.EditValue = DateTime.Today.Date;
            dte_TuNgay.EditValue = DateTime.Today.Date;
            KhoiTaoGridLookupEditMaChungTuPhieuChi();
        }

        private void KhoiTaoGridLookupEditMaChungTuPhieuChi()
        {
            if (LoadDanhSachChungTuPhieuChi())
            {
                gridLookUpEditMaChungTuPC.Properties.DisplayMember = "SoChungTu";
                gridLookUpEditMaChungTuPC.Properties.ValueMember = "MaChungTu";
                HamDungChung.InitGridLookUpDev(gridLookUpEditMaChungTuPC, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
                HamDungChung.ShowFieldGridLookUpDev(gridLookUpEditMaChungTuPC, new string[] { "SoChungTu", "NgayLap" }, new string[] { "Số chứng từ", "Ngày lập" }, new int[] { 100, 100 });
            }

        }

        private bool LoadDanhSachChungTuPhieuChi()
        {
            if (GetThongTinNgayThang())
            {
                List<ChungTuPhieuChiforLapPhieuThu> chungtuphieuchiList = ChungTuPhieuChiforLapPhieuThu.CreatChungTuPhieuChiListforCapNhatThueCTVTienMat(_tuNgay, _denNgay);
                gridLookUpEditMaChungTuPC.Properties.DataSource = chungtuphieuchiList;
                return true;
            }
            return false;
        }

        private bool GetThongTinNgayThang()
        {
            if (dte_TuNgay.EditValue != null && dte_DenNgay.EditValue != null)
            {
                _tuNgay = Convert.ToDateTime(dte_TuNgay.EditValue);
                _denNgay = Convert.ToDateTime(dte_DenNgay.EditValue);
                return true;
            }
            MessageBox.Show("Ngày Tháng Không Hợp Lệ", "Thông Báo");
            return false;
        }

        private bool GetThongTinMaChungTuPC()
        {
            if (gridLookUpEditMaChungTuPC.EditValue != null)
            {
                long mactOut = 0;
                if (long.TryParse(gridLookUpEditMaChungTuPC.EditValue.ToString(), out mactOut))
                {
                    _maChungTuPC = mactOut;
                    return true;
                }
            }
            MessageBox.Show("Chứng Từ Chọn Không Hợp Lệ", "Thông Báo");
            return false;
        }

        private bool KiemTraTruocKhiXoa()
        {
            if (ChungTuPhieuChiforLapPhieuThu.KiemTraThueCTVDaIN(_tuNgay, _denNgay, _maChungTuPC))
                return false;
            return true;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }
        private void frmDanhSachChungTuKhauTruTTNCN_Load(object sender, EventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Office 2007 Blue";
            dte_TuNgay.EditValue = DateTime.Now.Date;
            dte_DenNgay.EditValue = DateTime.Now.Date;
            _loadFinish = true;

            //
        }


        private void dte_DenNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (_loadFinish)
                LoadDanhSachChungTuPhieuChi();
        }
        private void LoadData()
        {
            //if (dte_TuNgay.EditValue != null && dte_DenNgay.EditValue != null)
            //{
            //    DateTime tuNgay = Convert.ToDateTime(dte_TuNgay.EditValue);
            //    DateTime denNgay = Convert.ToDateTime(dte_DenNgay.EditValue);

            //    _chungTuNganHangList = ChungTuNganHangList.GetChungTuNganHangList(tuNgay, denNgay);

            //    ChungTuNganHang chungTuNganHang = new ChungTuNganHang() { MaChungTu = 0, So = "Tất Cả" };
            //    _chungTuNganHangList.Insert(0, chungTuNganHang);
            //    ChungTuNganHang_BindingSource.DataSource = _chungTuNganHangList;
            //}
        }


        private void dte_TuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (_loadFinish)
                LoadDanhSachChungTuPhieuChi();
        }

        private void frmCapNhatThueCTV_TienMat_FormClosed(object sender, FormClosedEventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = " DevExpress Style";
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetThongTinNgayThang())
                    if (GetThongTinMaChungTuPC())
                    {
                        ChungTuPhieuChiforLapPhieuThu.InsertIntotblThueCongTacVienbyMaChungTuPC(_tuNgay, _denNgay, _maChungTuPC);
                        MessageBox.Show("Cập Nhật Thành Công", "Thông Báo");
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (GetThongTinNgayThang())
                if (GetThongTinMaChungTuPC())
                {
                    if (KiemTraTruocKhiXoa())
                    {
                        if (MessageBox.Show("Bạn Thật Sự Muốn Xóa Việc Chốt Dữ Liệu Thuế Trong Khoản Thời Gian Này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            try
                            {
                                ChungTuPhieuChiforLapPhieuThu.DeleteblThueCongTacVienbyMaChungTuPC(_tuNgay, _denNgay, _maChungTuPC);
                                MessageBox.Show("Xóa Thành Công", "Thông Báo");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tiền thuế của nhân viên đã được in ra sổ. Không thể xóa! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                }
            
        }
    }
}