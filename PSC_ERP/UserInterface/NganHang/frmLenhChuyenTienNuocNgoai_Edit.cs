using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using ERP_Library.ThanhToan;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
//ok
namespace PSC_ERP
{
    public partial class frmLenhChuyenTienNuocNgoai_Edit : Form
    {
        #region Properties
        private bool OK = false;
        private LenhChuyenTienNuocNgoai _data;
        private bool _isNew = false;
        private int _iLoaiChuyen = 1;
        private int _iLoaiPhi = 1;

        string _IDSelected = string.Empty;

        #endregion

        #region Loads
        public frmLenhChuyenTienNuocNgoai_Edit()
        {
            InitializeComponent();
        }

        private void cmb_DoiTac_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmb_DoiTac.DisplayLayout.Bands[0],
            new string[3] { "TenDoiTac", "MaSoThue", "DiaChi" },
            new string[3] { "Tên đối tượng", "Mã số thuế", "Đơn vị" },
            new int[3] { 250, 120, 250 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[3] { false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_DoiTac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.cmb_DoiTac.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.cmb_DoiTac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            FilterCombo filter = new FilterCombo(cmb_DoiTac, "TenDoiTac");
        }

        private void cmb_TaiKhoanNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmb_TaiKhoanNhan.DisplayLayout.Bands[0],
            new string[3] { "SoTK", "TenNganHang", "TenNhomNganHang" },
            new string[3] { "Số tài khoản", "Tên ngân hàng", "Tên nhóm ngân hàng" },
            new int[3] { 120, 250, 250 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[3] { false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_DoiTac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.cmb_TaiKhoanNhan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.cmb_TaiKhoanNhan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            FilterCombo filter = new FilterCombo(cmb_TaiKhoanNhan, "TenNganHang");
        }
        #endregion

        #region Process
        public bool ShowEdit(LenhChuyenTienNuocNgoai data, bool bIsNew)
        {
            _data = data;
            bdData.DataSource = _data;
            _isNew = bIsNew;
            Load_Form();
            this.ShowDialog();
            return OK;
        }

        private void Load_Form()
        {
            TaiKhoanNganHangCongTyList taiKhoanNganHangCongTyList = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            cmb_TuTaiKhoan.DataSource = taiKhoanNganHangCongTyList;
            mnu_SoTien.Value = _data.SoTien;
            //DoiTacList doitacList = DoiTacList.GetDoiTacList(" ", false);
            DoiTacList doitacList = DoiTacList.GetDoiTacList(" ", 0);
            DoiTac _doiTac = DoiTac.NewDoiTac(0,"Chưa chọn");
            doitacList.Insert(0, _doiTac);
            DoiTac_bindingSource.DataSource = doitacList;

            LoaiTienList loaiTienList = LoaiTienList.GetLoaiTienList();
            LoaiTien loaiTien = LoaiTien.NewLoaiTien("Chưa chọn");
            loaiTienList.Insert(0, loaiTien);
            loaiTienListBindingSource.DataSource = loaiTienList;

            ChiTiet_bindingSource.DataSource = _data.ChiTietDeNghi_LenhChuyenTienList;
            LoadCheckBox();

            if (!_isNew & KiemTraLapCT())
            {
                btnDongY.Enabled = false;
            }
        }

        private void LoadCheckBox()
        {
            switch (_data.HinhThucChuyen)
            {
                case 1: 
                    rad_Swift.Checked = true;
                    break;

                case 2:
                    rad_Sec.Checked = true;
                    break;

                case 3:
                    rad_UngTruoc.Checked = true;
                    break;

                case 4:
                    rad_ThucHien.Checked = true;
                    break;

                default: 
                    rad_Swift.Checked = true;
                    break;
            }

            switch (_data.LoaiPhiDichVu)
            {
                case 1:
                    rad_NguoiChuyenChiu.Checked = true;
                    break;

                case 2:
                    rad_NguoiHuongChiu.Checked = true;
                    break;

                case 3:
                    rad_ChiaSe.Checked = true;
                    break;

                case 4:
                    rad_TKSo.Checked = true;
                    break;

                case 5:
                    rad_KhongTruPhi.Checked = true;
                    break;

                case 6:
                    rad_TruPhiMotLan.Checked = true;
                    break;
            }
        }

        private bool KiemTraLapCT()
        {
            bool bFind = false;
            ChungTu_LenhChuyenTienNNChildList list = ChungTu_LenhChuyenTienNNChildList.GetChungTu_LenhChuyenTienNNChildList_ByMaPhieu(_data.MaLenhCT);
            if (list.Count > 0)
                bFind = true;
            return bFind;
        }

        private void DocTien(decimal SoTien)
        {
            string strLoaiTien = "VND";
            int MaLoaiTien = 0;
            if (cmb_LoaiTien.ActiveRow != null)
            {
                strLoaiTien = Convert.ToString(cmb_LoaiTien.ActiveRow.Cells["MaLoaiQuanLy"].Value);
                MaLoaiTien = Convert.ToInt32(cmb_LoaiTien.ActiveRow.Cells["MaLoaiTien"].Value);
            }
            if (strLoaiTien == "VND")
            {
                txt_SoTienBangChu.Text = HamDungChung.DocTien(SoTien);
            }
            else
            {
                LoaiTien lt = LoaiTien.GetLoaiTien(MaLoaiTien);
                txt_SoTienBangChu.Text = HamDungChung.DocTienNgoaiTe(SoTien, lt.TienChan, lt.TienLe);
                _data.SoTienBangChu = txt_SoTienBangChu.Text;
             
            }
        }

        private void SetLoaiVaPhi(int LoaiChuyen, int LoaiPhi)
        {
            this._iLoaiChuyen = LoaiChuyen;
            this._iLoaiPhi = LoaiPhi;
            bdData.EndEdit();
        }
        #endregion
        
        #region Event
        private void btnDongY_Click(object sender, EventArgs e)
        {
            bdData.EndEdit();
            if (cmb_TuTaiKhoan.Value == null || (int)cmb_TuTaiKhoan.Value == 0)
            {
                MessageBox.Show("Ngân hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmb_LoaiTien.Value == null || (int)cmb_LoaiTien.Value == 0)
            {
                MessageBox.Show(this, "Loại tiền không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _data.HinhThucChuyen = _iLoaiChuyen;
            _data.LoaiPhiDichVu = _iLoaiPhi;
            _data.SoTienBangChu = txt_SoTienBangChu.Text;
            _data.SoTien = Convert.ToDecimal(mnu_SoTien.Value);
            _data.TyGia = Convert.ToDecimal(mnu_TyGia.Value);
            _data.ApplyEdit();
            OK = true;
            this.Close();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            OK = false;
            this.Close();
        }

        private void cmb_LoaiTien_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_LoaiTien.ActiveRow != null && _isNew)
            {
                mnu_TyGia.Value = Convert.ToDecimal(cmb_LoaiTien.ActiveRow.Cells["TiGiaQuyDoi"].Value);
                DocTien(Convert.ToDecimal(mnu_SoTien.Value));
            }
            //Nếu là chỉnh sửa
            if (!_isNew)
            {
                mnu_TyGia.Value = _data.TyGia;
                DocTien(Convert.ToDecimal(mnu_SoTien.Value));
            }
        }

        private void cmb_TuTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_TuTaiKhoan.ActiveRow != null)
            {
                txt_TuNganHang.Text = Convert.ToString(cmb_TuTaiKhoan.ActiveRow.Cells["TenNganHang"].Value);
            }
        }

        private void mnu_SoTien_ValueChanged(object sender, EventArgs e)
        {
            DocTien(Convert.ToDecimal(mnu_SoTien.Value));
        }

        private void cmb_DoiTac_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_DoiTac.ActiveRow != null)
                {
                    long lMaDoiTac = Convert.ToInt64(cmb_DoiTac.Value);
                    DoiTac dt = DoiTac.GetDoiTac(lMaDoiTac);

                    TK_NganHangDoiTacBinding.DataSource = dt.TK_NganHangList;
                    _data.NganHangNhan = Convert.ToInt32(cmb_TaiKhoanNhan.Value);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmb_TaiKhoanNhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_TaiKhoanNhan.ActiveRow != null)
            {
                txt_DenNganHang.Text = Convert.ToString(cmb_TaiKhoanNhan.ActiveRow.Cells["TenNganHang"].Value);
                //_data.NganHangNhan = Convert.ToInt32(cmb_TaiKhoanNhan.Value);
            }
        }

        private void rad_Swift_CheckedChanged(object sender, EventArgs e)
        {
            //Loại Chuyển
            SetLoaiVaPhi(1, _iLoaiPhi);
        }

        private void rad_Sec_CheckedChanged(object sender, EventArgs e)
        {
            //Loại Chuyển
            SetLoaiVaPhi(2, _iLoaiPhi);
        }

        private void rad_UngTruoc_CheckedChanged(object sender, EventArgs e)
        {
            //Loại Chuyển
            SetLoaiVaPhi(3, _iLoaiPhi);
        }

        private void rad_ThucHien_CheckedChanged(object sender, EventArgs e)
        {
            //Loại Chuyển
            SetLoaiVaPhi(4, _iLoaiPhi);
        }

        private void rad_NguoiChuyenChiu_CheckedChanged(object sender, EventArgs e)
        {
            //Loại Phí
            SetLoaiVaPhi(_iLoaiChuyen, 1);
        }

        private void rad_NguoiHuongChiu_CheckedChanged(object sender, EventArgs e)
        {
            //Loại Phí
            SetLoaiVaPhi(_iLoaiChuyen, 2);
        }

        private void rad_ChiaSe_CheckedChanged(object sender, EventArgs e)
        {
            //Loại Phí
            SetLoaiVaPhi(_iLoaiChuyen, 3);
        }

        private void rad_TKSo_CheckedChanged(object sender, EventArgs e)
        {
            //Loại Phí
            SetLoaiVaPhi(_iLoaiChuyen, 4);
        }

        private void rad_KhongTruPhi_CheckedChanged(object sender, EventArgs e)
        {
            //Loại Phí
            SetLoaiVaPhi(_iLoaiChuyen, 5);
        }

        private void rad_TruPhiMotLan_CheckedChanged(object sender, EventArgs e)
        {
            //Loại Phí
            SetLoaiVaPhi(_iLoaiChuyen, 6);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            frmUyNhiemChi_HDDV_ChuaDuyet f = new frmUyNhiemChi_HDDV_ChuaDuyet(2);
            f._lenhChuyen = _data;
            f.ShowDialog();
            TinhLaiTien();

            ChiTiet_bindingSource.DataSource = _data.ChiTietDeNghi_LenhChuyenTienList;
            if (f._tyGia > 0)
                mnu_TyGia.Value = f._tyGia;
        }

        private void TinhLaiTien()
        {
            _data.SoTien = 0;
            _data.LoaiTien = 0;
            string strNoiDung = string.Empty;
            foreach (ChiTietDeNghi_LenhChuyenTien ct in _data.ChiTietDeNghi_LenhChuyenTienList)
            {
                _data.SoTien += ct.SoTien;
                _data.LoaiTien = ct.LoaiTien;
                DeNghiChuyenKhoan dn = DeNghiChuyenKhoan.GetDeNghiChuyenKhoan(ct.MaDeNghi);
                if (strNoiDung == string.Empty)
                {
                    strNoiDung += dn.LyDo;
                }
                else
                {
                    strNoiDung += ", " + dn.LyDo;
                }

            }
            txtNoiDung.Text = strNoiDung;
           
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (grd_DSDeNghi.Selected.Rows.Count <= 0)
            {
                MessageBox.Show(this, "Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grd_DSDeNghi.DeleteSelectedRows();
            TinhLaiTien();
        }
        #endregion

        private void XoaChungTu(int maDeNghi)
        { 
        
        }

        private void grd_DSDeNghi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grd_DSDeNghi.DisplayLayout.Bands[0],
            new string[3] { "SoChungTu", "SoTien", "LoaiTien" },
            new string[3] { "Số chứng từ", "Số tiền", "Loại tiền" },
            new int[3] { 250, 120, 100 },
            new Control[3] { null, null, cmb_LoaiTien },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.TienLe, KieuDuLieu.Null },
            new bool[3] { false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.grd_DSDeNghi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.White;
            }
            //màu nền
            
            this.grd_DSDeNghi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void grd_DSDeNghi_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            string strSoDeNghi = string.Empty;
            int iMaDeNghi = 0;

            iMaDeNghi = Convert.ToInt32(grd_DSDeNghi.Selected.Rows[0].Cells["MaDeNghi"].Value);
            strSoDeNghi = Convert.ToString(grd_DSDeNghi.Selected.Rows[0].Cells["SoChungTu"].Value);
            if (MessageBox.Show("Bạn có muốn xóa chuyển khoản đề nghị này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show(this, "Thao tác trên sẽ xóa toàn bộ thông tin liên quan đến chứng từ số  " + strSoDeNghi + ". Bạn có chắc chắn muốn xóa?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < _data.ChiTietDeNghi_LenhChuyenTienList.Count; i++)
                    {
                        if (_data.ChiTietDeNghi_LenhChuyenTienList[i].MaDeNghi == iMaDeNghi)
                        {
                            _data.ChiTietDeNghi_LenhChuyenTienList.RemoveAt(i);
                            i--;
                        }
                    }

                    ChiTiet_bindingSource.DataSource = _data.ChiTietDeNghi_LenhChuyenTienList;
                    e.Cancel = true;
                }
            }
        }
    }
}