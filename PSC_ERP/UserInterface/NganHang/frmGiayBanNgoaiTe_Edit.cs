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

namespace PSC_ERP
{
    public partial class frmGiayBanNgoaiTe_Edit : Form
    {
        #region Properties
        private bool OK = false;
        private GiayBanNgoaiTe _data;
        private bool _isNew = false;

        string _IDSelected = string.Empty;

        #endregion

        #region Loads
        public frmGiayBanNgoaiTe_Edit()
        {
            InitializeComponent();
        }
        #endregion

        #region Process
        public bool ShowEdit(GiayBanNgoaiTe data, bool bIsNew)
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
            cmb_DenTaiKhoan.DataSource = taiKhoanNganHangCongTyList;
            cmb_LoaiTien.DataSource = LoaiTienList.GetLoaiTienList();
            mnu_SoTien.Value=_data.SoTien ;
            grd_DSDeNghi.DataSource = _data.DeNghi_GiayBanNTList;

            XuLyLuaChon(rad_TTR.Name);
            if (!_isNew)
            {
                GetDuLieu();
                if (KiemTraLapCT())
                {
                    btnDongY.Enabled = false;
                }
            }
        }

        private bool KiemTraLapCT()
        {
            bool bFind = false;
            ChungTu_GiayBanNgoaiTeChildList list = ChungTu_GiayBanNgoaiTeChildList.GetChungTu_GiayBanNgoaiTeChildList_ByPhieu(_data.MaPhieu);
            if (list.Count > 0)
                bFind = true;
            return bFind;
        }

        private void XuLyLuaChon(string ID)
        {
            AnToanBo();
            _IDSelected = ID;

            switch (_IDSelected)
            {
                case "rad_QuyNH":
                    txt_NoQuyNH.Enabled = true;
                    break;
                case "rad_TraNgay":
                    txt_TraNgay.Enabled = true;
                    dt_TraNgay.Enabled = true;
                    break;
                case "rad_TraCham":
                    txt_TraCham.Enabled = true;
                    dt_TraCham.Enabled = true;
                    break;
                case "rad_Dp":
                    txt_DP.Enabled = true;
                    break;
                case "rad_TTR":
                    txt_TTR.Enabled = true;
                    break;
                case "rad_UyThac":
                    txt_NhapUyThac.Enabled = true;
                    break;
                case "rad_Khac":
                    txt_Khac.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void AnToanBo()
        {
            foreach (Control ctrl in grp_Option.Controls)
            {
                if (ctrl is UltraTextEditor || ctrl is UltraDateTimeEditor)
                {
                    ctrl.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Insert Dữ Liệu Khi Đồng Ý
        /// </summary>
        private void SetDuLieu()
        {
            _data.SoTien = Convert.ToDecimal( mnu_SoTien.Value);
            _data.SoTienBangChu = txt_SoTienBangChu.Text;
            _data.TyGia = Convert.ToDecimal(mnu_TyGia.Value);

            //MỤC ĐÍCH THANH TOÁN -*- BỔ SUNG THÊM NẾU CẦN THIẾT
            //1: Hợp đồng / Khế ước;
            //2: Trả ngay;
            //3: Trả chậm;
            //4: Phương thức DP;
            //5: Phương thức TTR;
            //6: Ủy thác;
            //7: Mục đích khác;
            switch (_IDSelected)
            {
                case "rad_QuyNH":
                    _data.MucDichThanhToan = 1;
                    _data.SoKheUoc = txt_NoQuyNH.Text;
                    break;
                case "rad_TraNgay":
                    _data.MucDichThanhToan = 2;
                    _data.SoKheUoc = txt_TraNgay.Text;
                    _data.NgaySoSach = Convert.ToDateTime(dt_TraNgay.Value);
                    break;
                case "rad_TraCham":
                    _data.MucDichThanhToan = 3;
                    _data.SoKheUoc = txt_TraCham.Text;
                    _data.NgaySoSach = Convert.ToDateTime(dt_TraCham.Value);
                    break;
                case "rad_Dp":
                    _data.MucDichThanhToan = 4;
                    _data.SoKheUoc = txt_DP.Text;
                    break;
                case "rad_TTR":
                    _data.MucDichThanhToan = 5;
                    _data.SoKheUoc = txt_TTR.Text;
                    break;
                case "rad_UyThac":
                    _data.MucDichThanhToan = 6;
                    _data.SoKheUoc = txt_NhapUyThac.Text;
                    break;
                case "rad_Khac":
                    _data.MucDichThanhToan = 7;
                    _data.SoKheUoc = txt_Khac.Text;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Select Dữ Liệu Khi Load Form
        /// </summary>
        private void GetDuLieu()
        {
            //MỤC ĐÍCH THANH TOÁN -*- BỔ SUNG THÊM NẾU CẦN THIẾT
            //1: Hợp đồng / Khế ước;
            //2: Trả ngay;
            //3: Trả chậm;
            //4: Phương thức DP;
            //5: Phương thức TTR;
            //6: Ủy thác;
            //7: Mục đích khác;
            string strSoKeUoc = _data.SoKheUoc;
            DateTime dtNgaySoSach = _data.NgaySoSach;
            switch (_data.MucDichThanhToan)
            {
                case 1:
                    txt_NoQuyNH.Text = strSoKeUoc;
                    rad_QuyNH.PerformClick();
                    break;
                case 2:
                    txt_TraNgay.Text = strSoKeUoc;
                    dt_TraNgay.Value = dtNgaySoSach;
                    rad_TraNgay.Checked = true;
                    break;
                case 3:
                    txt_TraCham.Text = strSoKeUoc;
                    dt_TraCham.Value = dtNgaySoSach;
                    rad_TraCham.Checked = true;
                    break;
                case 4:
                    txt_DP.Text = strSoKeUoc;
                    rad_Dp.Checked = true;
                    break;
                case 5:
                    txt_TTR.Text = strSoKeUoc;
                    rad_TTR.Checked = true;
                    break;
                case 6:
                    txt_NhapUyThac.Text = strSoKeUoc;
                    rad_UyThac.Checked = true;
                    break;
                case 7:
                    txt_Khac.Text = strSoKeUoc;
                    rad_UyThac.Checked = true;
                    break;
                default:
                    break;
            }
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

            if (cmb_DenTaiKhoan.Value == null || (int)cmb_DenTaiKhoan.Value == 0)
            {
                MessageBox.Show("Ngân hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmb_LoaiTien.Value == null || (int)cmb_LoaiTien.Value == 0)
            {
                MessageBox.Show(this, "Loại tiền không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ERP_Library.GiayBanNgoaiTe.KiemTraSoDeNghi(_data.SoDeNghi, _data.MaPhieu))
            {
                MessageBox.Show(this, "Số đế nghị bán ngoại tệ đã tồn tại, vui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetDuLieu();
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
            DocTien(Convert.ToDecimal(mnu_SoTien.Value));
        }

        private void cmb_TuTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_TuTaiKhoan.ActiveRow != null)
            {
                txt_TuNganHang.Text = Convert.ToString(cmb_TuTaiKhoan.ActiveRow.Cells["TenNganHang"].Value);
            }
        }

        private void cmb_DenTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_DenTaiKhoan.ActiveRow != null)
            {
                txt_DenNganHang.Text = Convert.ToString(cmb_DenTaiKhoan.ActiveRow.Cells["TenNganHang"].Value);
            }
        }

        private void rad_QuyNH_CheckedChanged(object sender, EventArgs e)
        {
            XuLyLuaChon(rad_QuyNH.Name);
        }

        private void rad_TraNgay_CheckedChanged(object sender, EventArgs e)
        {
            XuLyLuaChon(rad_TraNgay.Name);
        }

        private void rad_TraCham_CheckedChanged(object sender, EventArgs e)
        {
            XuLyLuaChon(rad_TraCham.Name);
        }

        private void rad_Dp_CheckedChanged(object sender, EventArgs e)
        {
            XuLyLuaChon(rad_Dp.Name);
        }

        private void rad_TTR_CheckedChanged(object sender, EventArgs e)
        {
            XuLyLuaChon(rad_TTR.Name);
        }

        private void rad_UyThac_CheckedChanged(object sender, EventArgs e)
        {
            XuLyLuaChon(rad_UyThac.Name);
        }

        private void rad_Khac_CheckedChanged(object sender, EventArgs e)
        {
            XuLyLuaChon(rad_Khac.Name);
        }

        private void mnu_SoTien_ValueChanged(object sender, EventArgs e)
        {
            DocTien(Convert.ToDecimal(mnu_SoTien.Value));
        }
        #endregion

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmUyNhiemChi_HDDV_ChuaDuyet f = new frmUyNhiemChi_HDDV_ChuaDuyet(3);
            f._giayban = _data;
            f.ShowDialog();
            TinhLaiTien();

            bd_DeNghiChuyenKhoanList.DataSource = _data.DeNghi_GiayBanNTList;

            TinhLaiTien();
        }

        private void TinhLaiTien()
        {
            decimal deSoTien = 0;
            int iLoaiTien = 0;
            decimal deTyGia = 0;
            string strNoiDung = string.Empty;

            foreach (DeNghi_GiayBanNgoaiTe item in _data.DeNghi_GiayBanNTList)
            {
                if (iLoaiTien == 0)
                    iLoaiTien = item.LoaiTien;
                if (deTyGia == 0)
                    deTyGia = item.TyGia;
                deSoTien += item.Sotien;

                DeNghiChuyenKhoan dn = DeNghiChuyenKhoan.GetDeNghiChuyenKhoan(item.MaDeNghi);
                if (strNoiDung == string.Empty)
                {
                    strNoiDung += dn.LyDo;
                }
                else
                {
                    strNoiDung += ", " + dn.LyDo;
                }
            }
            _data.SoTien = deSoTien;
            _data.LoaiTien = iLoaiTien;
            _data.TyGia = deTyGia;
            _data.SoKheUoc = strNoiDung;
            txt_TTR.Text = strNoiDung;

        }

        private void tblXoa_Click(object sender, EventArgs e)
        {
            if (grd_DSDeNghi.Selected.Rows.Count <= 0)
            {
                MessageBox.Show(this, "Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grd_DSDeNghi.DeleteSelectedRows();

            TinhLaiTien();
        }

        private void grd_DSDeNghi_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
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
                col.Header.Appearance.ForeColor = Color.White;
            }
            //màu nền
            this.grd_DSDeNghi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void grd_DSDeNghi_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            string strSoDeNghi = string.Empty;
            int iMaDeNghi = 0;

            iMaDeNghi = Convert.ToInt32(grd_DSDeNghi.Selected.Rows[0].Cells["MaLenhCT"].Value);
            strSoDeNghi = Convert.ToString(grd_DSDeNghi.Selected.Rows[0].Cells["SoChungTu"].Value);
            if (MessageBox.Show("Bạn có muốn xóa lệnh chuyển tiền này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show(this, "Thao tác trên sẽ xóa toàn bộ thông tin liên quan đến chứng từ số  " + strSoDeNghi + ". Bạn có chắc chắn muốn xóa?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //for (int i = 0; i < _data.ChuyenTien_NgoaiTeList.Count; i++)
                    //{
                    //    if (_data.ChuyenTien_NgoaiTeList[i].MaLenhCT == iMaDeNghi)
                    //    {
                    //        _data.ChuyenTien_NgoaiTeList.RemoveAt(i);
                    //        i--;
                    //    }
                    //}

                    //DeNghi_LenhChuyenbindingSource.DataSource = _data.ChuyenTien_NgoaiTeList;
                    //e.Cancel = true;
                }
            }
        }
    }
}