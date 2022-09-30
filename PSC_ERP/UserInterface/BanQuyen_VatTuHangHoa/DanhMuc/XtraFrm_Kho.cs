using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using PSC_ERP_Common;

namespace PSC_ERP
{
    public partial class XtraFrm_Kho : XtraForm
    {
        #region Properties and Methods
        KhoBQ_VT _kho;
        KhoBQ_VTList _khoBQ_VTList;
        LoaiKhoBQ_VTList _loaiKhoBQ_VTList;
        DiaChiBQ_VTList _diaChiBQ_VTList;
        HeThongTaiKhoan1List _taiKhoanList;
        int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        private bool KiemTraMaQuanLyHopLe(KhoBQ_VT kho)
        {
            if (KhoBQ_VT.KiemTraTrungMaMaQuanLyKho(kho.MaKho, kho.MaQuanLy))
            {
                MessageBox.Show(string.Format("[{0}] Trùng Mã quản lý với Kho đang tồn tại! Vui lòng chỉnh lại!", kho.TenKho));
                //txt_MaQuanLy.Focus();
                return false;
            }
            return true;
        }
        #endregion //Properties and Methods
        private void loadForm()
        {
            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;

            _khoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList();
            bs_Kho.DataSource = _khoBQ_VTList;
            grd_DSKho.DataSource = bs_Kho;
            //
            _loaiKhoBQ_VTList = LoaiKhoBQ_VTList.GetLoaiKhoBQ_VTList();
            bs_LoaiKho.DataSource = _loaiKhoBQ_VTList;
            //
            _diaChiBQ_VTList = DiaChiBQ_VTList.GetDiaChiBQ_VTList();
            bs_DiaChi.DataSource = _diaChiBQ_VTList;
            //
            _taiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();// TaiKhoanList.GetTaiKhoanList();
            HeThongTaiKhoan1 httk = HeThongTaiKhoan1.NewHeThongTaiKhoan1("Không chọn");
            _taiKhoanList.Insert(0, httk);
            bs_TaiKhoanList.DataSource = _taiKhoanList;
            //
            if (bs_Kho.Count == 0)
                btnThemMoi.PerformClick();
            else
                _kho = (KhoBQ_VT)bs_Kho.Current;
        }
        public XtraFrm_Kho()
        {
            InitializeComponent();
            bs_Kho.DataSource = typeof(KhoBQ_VTList);
            bs_LoaiKho.DataSource = typeof(LoaiKhoBQ_VTList);
            bs_DiaChi.DataSource = typeof(DiaChiBQ_VTList);
        }

        private void XtraFrm_Kho_Load(object sender, EventArgs e)
        {
            loadForm();
            Utils.GridUtils.SetSTTForGridView(gridView_DMKho, 35);
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _kho = KhoBQ_VT.NewKhoBQ_VT();
                _kho.MaCongTy = maCongTy;
                _khoBQ_VTList.Insert(0, _kho);
                txt_MaQuanLy.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView_DMKho.GetFocusedRow() != null)
            {
                gridView_DMKho.DeleteSelectedRows();
            }
            else
            {
                MessageBox.Show("Vui Lòng chọn dòng cần xóa!");
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _khoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList();
            bs_Kho.DataSource = _khoBQ_VTList;
            grd_DSKho.DataSource = bs_Kho;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool luu = false;
            _kho = (KhoBQ_VT)bs_Kho.Current;
            if (_kho != null)
            {
                luu = KiemTraMaQuanLyHopLe(_kho); 
                if (!luu)
                    return;
                foreach (KhoBQ_VT k in _khoBQ_VTList)
                {                    
                    luu = KiemTraMaQuanLyHopLe(k);
                    if (!luu)
                        return;
                }
            }
            else
            {
                MessageBox.Show("Không thể lưu");
            }
            if (luu)
            {
                //
                try
                {
                    _khoBQ_VTList.ApplyEdit();
                    bs_Kho.EndEdit();
                    _khoBQ_VTList.Save();

                    MessageBox.Show(this, "Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowWarning("Không thể lưu!\n"+ex.Message);
                }
                //
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void XtraFrm_Kho_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_kho.IsDirty)
            {
                DialogResult kq = MessageBox.Show("Bạn có muốn lưu sự chuyển đổi?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (kq == DialogResult.Yes)
                {
                    btnLuu.PerformClick();
                }
                else
                    if (kq == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
            }
        }
    }
}