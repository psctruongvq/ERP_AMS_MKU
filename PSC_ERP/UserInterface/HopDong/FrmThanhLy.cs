using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class FrmThanhLy : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        NghiemThuThanhLyHopDong _nghiemThuThanhLyHopDong = NghiemThuThanhLyHopDong.NewNghiemThuThanhLyHopDong();
        HopDongThuChi _hopDong = HopDongThuChi.NewHopDongMuaBan();
        long _maHopDong;

        int _loai;//Xac dinh la nghiem thu, thanh ly hay nghiem thu thanh ly
        private bool _notNewNT_TL = false;

        HopDongThuChiList _hopDongThuChiList = HopDongThuChiList.NewHopDongMuaBanList();
        #endregion



        public FrmThanhLy()
        {
            InitializeComponent();
        }

        public FrmThanhLy(int loai)
        {
            InitializeComponent();
            LoadForm();
            _loai = loai;
            SetTieuDeOfForm();
        }

        public FrmThanhLy(long maHopDong, int loai)
        {
            InitializeComponent();
            LoadForm();
            _hopDong = HopDongThuChi.GetHopDongMuaBanWithoutChild(maHopDong);
            _loai = loai;
            SetTieuDeOfForm();
            SetThongTinMacDinhFromHopDong(_hopDong);
            ReLoadBingdingHopDongThuChiList(maHopDong);//
        }

        public FrmThanhLy(NghiemThuThanhLyHopDong nghiemThuThanhLy)
        {
            InitializeComponent();
            _notNewNT_TL = true;
            LoadForm();
            _loai = nghiemThuThanhLy.Loai;
            SetTieuDeOfForm();
            KhoiTaoNghiemThuThanhLy(nghiemThuThanhLy);
            ReLoadBingdingHopDongThuChiList(nghiemThuThanhLy.MaHopDong);//
        }

        public void ShowNghiemThu()
        {
            LoadForm();
            _loai = 1;
            SetTieuDeOfForm();
            this.Show();
        }
        public void ShowThanhLy()
        {
            LoadForm();
            _loai = 2;
            SetTieuDeOfForm();
            this.Show();
        }

        public void ShowNghiemThuThanhLy()
        {
            LoadForm();
            _loai = 3;
            SetTieuDeOfForm();
            this.Show();
        }

        private void ReLoadBingdingHopDongThuChiList(long maHopDong)
        {
            HopDongThuChi hdinsert = HopDongThuChi.GetHopDongMuaBanWithoutChild(maHopDong);
            _hopDongThuChiList.Add(hdinsert);
            HopDongThuChiList_bindingSource.DataSource = _hopDongThuChiList;

        }

        private void LoadForm()
        {
            HopDongThuChiList_bindingSource.DataSource = typeof(HopDongThuChiList);
            NguoiDaiDienList_bindingSource.DataSource = typeof(TenNhanVienList);
            loaiTienListBindingSource.DataSource = typeof(LoaiTienList);

            NguoiDaiDienList_bindingSource.DataSource = TenNhanVienList.GetTenNhanVienList_NguoiDaiDienHopDong();

            HopDongThuChi hopdong = HopDongThuChi.NewHopDongMuaBan(0, "Không chọn");
            _hopDongThuChiList = HopDongThuChiList.GetHopDongMuaBanByUserID();
            _hopDongThuChiList.Insert(0, hopdong);
            HopDongThuChiList_bindingSource.DataSource = _hopDongThuChiList;

            LoaiTien loaitien = LoaiTien.NewLoaiTien(0, "Không chọn");
            LoaiTienList loaiTienlist = LoaiTienList.GetLoaiTienList();
            loaiTienlist.Insert(0, loaitien);
            loaiTienListBindingSource.DataSource = loaiTienlist;

        }

        private void SetTieuDeOfForm()
        {
            if (_loai == 1)
                this.Text = "Nghiệm Thu Hợp Đồng";
            else if (_loai == 2)
                this.Text = "Thanh Lý Hợp Đồng";
            else if (_loai == 3)
                this.Text = "Nghệm Thu Thanh Lý Hợp Đồng";
        }

        #region Function
        private void SetThongTinMacDinhFromHopDong(HopDongThuChi hopDong)
        {
            if (_nghiemThuThanhLyHopDong.IsNew)
            {
                _nghiemThuThanhLyHopDong.Loai = _loai;
                _nghiemThuThanhLyHopDong.MaHopDong = _hopDong.MaHopDong;
                grdLU_MaHopDong.EditValue = (object)_hopDong.MaHopDong;

                _nghiemThuThanhLyHopDong.NoiDung = _hopDong.TenHopDong;
                txt_NoiDung.Text = _hopDong.TenHopDong;

                _nghiemThuThanhLyHopDong.NgayKy = _hopDong.NgayKy;
                dateEdit_NgayKy.EditValue = (object)_hopDong.NgayKy;

                _nghiemThuThanhLyHopDong.MaNguoiKy = _hopDong.MaNguoiKy;
                grdLU_MaNguoiKy.EditValue = _hopDong.MaNguoiKy;

                _nghiemThuThanhLyHopDong.GhiChu = _hopDong.GhiChu;
                textEdit_GhiChu.Text = _hopDong.GhiChu;

                _nghiemThuThanhLyHopDong.SoTien = _hopDong.TongTien;
                //txt_SoTien.Text =_hopDong.TongTien.ToString();
                txt_SoTien.EditValue = (object)_hopDong.TongTien;

                _nghiemThuThanhLyHopDong.MaLoaiTien = _hopDong.MaLoaiTien;
                grdLU_MaLoaiTien.EditValue = (object)_hopDong.MaLoaiTien;
            }

        }
        private void SetMaNghiemThuThanhLyQL()
        {
            if (_nghiemThuThanhLyHopDong.IsNew)
            {
                txt_MamaNghiemThuThanhLyQL.Text = NghiemThuThanhLyHopDong.SetMaNghiemThuThanhLyQL(_hopDong.MaHopDong, _loai);
            }
        }

        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                SetMaNghiemThuThanhLyQL();
                if (KiemTraMaNghiemThuThanhLyQLHopLe())
                {
                    NghiemThuThanhLy_bindingSource.EndEdit();
                    _nghiemThuThanhLyHopDong.ApplyEdit();
                    _nghiemThuThanhLyHopDong.Save();
                }
                else
                {
                    kq = false;
                }

            }
            catch (ApplicationException ex)
            {
                kq = false;
            }
            return kq;
        }

        private bool KiemTraMaNghiemThuThanhLyQLHopLe()
        {//txt_MamaNghiemThuThanhLyQL  "Vui lòng nhập vào Mã Nghiệm thu thanh lý!"    "Mã Nghiệm thu thanh lý không hợp lệ!
            //
            string sohopdongChinh = HopDongThuChi.GetSoHopDongForSoPhuLuc(_hopDong.MaHopDong);
            string maNghiemThuThanhLyQL = txt_MamaNghiemThuThanhLyQL.Text.Trim();
            if (maNghiemThuThanhLyQL.Length == 0)
            {
                if (_loai == 1)
                    MessageBox.Show("Vui lòng nhập vào Mã Nghiệm thu!");
                else if (_loai == 2)
                    MessageBox.Show("Vui lòng nhập vào Mã Thanh lý!");
                else if (_loai == 3)
                    MessageBox.Show("Vui lòng nhập vào Mã Nghiệm thu thanh lý!");
                txt_MamaNghiemThuThanhLyQL.Focus();
                return false;
            }
            if (sohopdongChinh.Length > 0)
            {
                int size = sohopdongChinh.Length;
                if (maNghiemThuThanhLyQL.Substring(0, size) != sohopdongChinh)
                {
                    MessageBox.Show(size + " ký tự đầu không trùng khớp với số hợp đồng!");
                    txt_MamaNghiemThuThanhLyQL.Focus();
                    return false;
                }
                if (_loai == 1)//Kiem tra khi la [Nghiem Thu]
                {
                    //
                    int soTTHD;
                    if (!int.TryParse(maNghiemThuThanhLyQL.Substring(size + 1, 1), out soTTHD))
                    {
                        MessageBox.Show("Mã Nghiệm thu không hợp lệ! ký tự thứ " + (size + 2) + " phải là số!");
                        txt_MamaNghiemThuThanhLyQL.Focus();
                        return false;
                    }
                    //
                }//Kiem tra khi la [Nghiem Thu]
            }
            //

            if (NghiemThuThanhLyHopDong.KiemTraTrungMaNghiemThuThanhLyQL(_nghiemThuThanhLyHopDong.MaNghiemThuThanhLy, maNghiemThuThanhLyQL))
            {
                if (_loai == 1)
                    MessageBox.Show("Trùng Mã Nghiệm thu! Vui lòng chỉnh lại!");
                else if (_loai == 2)
                    MessageBox.Show("Trùng Mã Thanh lý! Vui lòng chỉnh lại!");
                else if (_loai == 3)
                    MessageBox.Show("Trùng Mã Nghiệm thu thanh lý! Vui lòng chỉnh lại!");

                txt_MamaNghiemThuThanhLyQL.Focus();
                return false;
            }

            return true;
        }
        private bool KiemTraDuLieu()
        {
            if (_nghiemThuThanhLyHopDong.MaHopDong == 0)
            {
                if (_loai == 1)
                    MessageBox.Show("Vui lòng chọn Hợp đồng cần Nghiệm thu!");
                else if (_loai == 2)
                    MessageBox.Show("Vui lòng chọn Hợp đồng cần Thanh Lý!");
                else if (_loai == 3)
                    MessageBox.Show("Vui lòng chọn Hợp đồng cần Nghiệm thu Thanh Lý!");
                grdLU_MaHopDong.Focus();
                return false;
            }
            if (HopDongThuChi.KiemTraHopDongDaThanhly(_nghiemThuThanhLyHopDong.MaHopDong))
            {
                MessageBox.Show("Hợp Đồng đã Thanh lý hay đã Nghệm thu Thanh lý. Không thể thực hiện!");
                return false;
            }
            else if (_nghiemThuThanhLyHopDong.SoTien == 0)
            {
                MessageBox.Show("Vui lòng nhập vào Số tiền!");
                txt_SoTien.Focus();
                return false;
            }
            return true;
        }

        private void KhoiTaoNghiemThuThanhLy(int loai)
        {
            _nghiemThuThanhLyHopDong = NghiemThuThanhLyHopDong.NewNghiemThuThanhLyHopDong();
            _nghiemThuThanhLyHopDong.Loai = loai;
            NghiemThuThanhLy_bindingSource.DataSource = _nghiemThuThanhLyHopDong;
            grdLU_MaHopDong.Focus();

        }

        private void KhoiTaoNghiemThuThanhLy(NghiemThuThanhLyHopDong nghiemThuThanhLy)
        {
            _nghiemThuThanhLyHopDong = nghiemThuThanhLy;
            NghiemThuThanhLy_bindingSource.DataSource = _nghiemThuThanhLyHopDong;

        }

        #endregion
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoNghiemThuThanhLy(_loai);
        }



        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                if (KiemTraDuLieu())
                {
                    //GH
                    try
                    {
                        if (LuuDuLieu())
                        {
                            MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //
                }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void grdLU_MaHopDong_EditValueChanged(object sender, EventArgs e)
        {
            if (!_notNewNT_TL)
            {
                //
                if (grdLU_MaHopDong.EditValue != null)
                {
                    if (long.TryParse(grdLU_MaHopDong.EditValue.ToString(), out _maHopDong))
                    {
                        if (HopDongThuChi.KiemTraHopDongDaThanhly(_maHopDong))
                        {
                            MessageBox.Show("Hợp Đồng đã Thanh lý hay đã Nghệm thu Thanh lý. Không thể thực hiện!");
                        }
                        else
                        {
                            _hopDong = HopDongThuChi.GetHopDongMuaBanWithoutChild(_maHopDong);
                            SetThongTinMacDinhFromHopDong(_hopDong);
                        }
                        NghiemThuThanhLy_bindingSource.DataSource = _nghiemThuThanhLyHopDong;

                    }
                }
                //
            }
            _notNewNT_TL = false;
        }



    }
}