using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmMauBaoCaoLuuChuyenTienTe : Form
    {
        BCKQHoatDongKinhDoanhList _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.NewBCKQHoatDongKinhDoanhList();
        BCKQHoatDongKinhDoanhList _BCKQHoatDongKinhDoanhList1 = BCKQHoatDongKinhDoanhList.NewBCKQHoatDongKinhDoanhList();
        public byte LoaiBaoCao = 3;

        private byte _isNHNN = 0;
        private byte _loaiBieuMau = 0;
        private int _maThongTu = 0;
        private string _noidungThongTu = string.Empty;
        #region Contructors
        public frmMauBaoCaoLuuChuyenTienTe()
        {
            InitializeComponent();
            KhoiTao();
        }

        public frmMauBaoCaoLuuChuyenTienTe(byte loaiBieuMau, byte thuocLoai, int maThongTu, string noidungthongtu)
        {
            InitializeComponent();
            _loaiBieuMau = loaiBieuMau;
            _isNHNN = thuocLoai;
            _maThongTu = maThongTu;
            _noidungThongTu = noidungthongtu;
            if (_isNHNN == 1)
            {
                ShowBaoCaoLuuChuyenTienTeforNHNN();
            }
            else if (_isNHNN == 0)
            {
                ShowBaoCaoLuuChuyenTienTe();
            }
            SetTieuDeForm();
            KhoiTao();
            HideShowbtnCopyBieuMau();
        }
        #endregion

        public void ShowBaoCaoLuuChuyenTienTe()
        {
            LoaiBaoCao = 3;
            this.Text = "Báo Cáo Lưu Chuyển Tiền Tệ";
            KhoiTao();
            lb_CapMuc.Visible = false;
            cbu_CapMuc.Visible = false;
            this.Show();
        }

        public void ShowBaoCaoLuuChuyenTienTeforNHNN()
        {
            LoaiBaoCao = 3;
            _isNHNN = 1;
            this.Text = "Báo Cáo Lưu Chuyển Tiền Tệ theo NHNN";
            KhoiTao();
            lb_CapMuc.Visible = false;
            cbu_CapMuc.Visible = false;
            this.Show();
        }

        public void ShowBaoCaoTongHopTinhHinhCongTy()
        {
            LoaiBaoCao = 7;
            KhoiTao();
            this.Text = "Báo Cáo Tổng Hợp Tình Hình Công Ty";
            lb_ThuyetMinh.Visible = false;
            txt_ThuyetMinh.Visible = false;
            this.Show();
        }

        private void SetTieuDeForm()
        {
            if (_isNHNN == 1)
            {
                this.Text = "Báo Cáo Lưu Chuyển Tiền Tệ NHNN  theo " + _noidungThongTu;
            }
            else if (_isNHNN == 0)
            {
                this.Text = "Báo Cáo Lưu Chuyển Tiền Tệ Thông Tư  theo " + _noidungThongTu;
            }
        }


        private void HideShowbtnCopyBieuMau()
        {
            if (_BCKQHoatDongKinhDoanhList.Count == 0)
            {
                tlsbtnCopyBieuMau.Visible = true;
            }
            else
            {
                tlsbtnCopyBieuMau.Visible = false;
            }
        }
        #region Khởi Tạo
        private void KhoiTao()
        {
            if (_isNHNN == 1)
                _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhListforNHNN(LoaiBaoCao,_maThongTu);
            else
                _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList(LoaiBaoCao,_maThongTu);
            bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;

            if (_isNHNN == 1)
                _BCKQHoatDongKinhDoanhList1 = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhListforNHNN(LoaiBaoCao,_maThongTu);
            else
                _BCKQHoatDongKinhDoanhList1 = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList(LoaiBaoCao,_maThongTu);
            BCKQHoatDongKinhDoanh _bckqHoatDongKinhDoanh = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh();
            _bckqHoatDongKinhDoanh.TenMuc = "None";
            if (_isNHNN == 1) _bckqHoatDongKinhDoanh.isNHNN = 1;//
            _BCKQHoatDongKinhDoanhList1.Insert(0, _bckqHoatDongKinhDoanh);
            bCKQHoatDongKinhDoanhListBindingSource1.DataSource = _BCKQHoatDongKinhDoanhList1;

        }
        #endregion

        #region Lưu Dữ Liệu

        private Boolean LuuDuLieu()
        {
            try
            {
                _BCKQHoatDongKinhDoanhList.ApplyEdit();
                _BCKQHoatDongKinhDoanhList.Save();
                //BangCanDoiKeToan bangCanDoiKeToan = BangCanDoiKeToan.NewBangCanDoiKeToan();
                bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;

                if (_isNHNN == 1)
                    _BCKQHoatDongKinhDoanhList1 = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhListforNHNN(LoaiBaoCao,_maThongTu);
                else
                    _BCKQHoatDongKinhDoanhList1 = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList(LoaiBaoCao,_maThongTu);
                BCKQHoatDongKinhDoanh _bckqHoatDongKinhDoanh = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh();
                _bckqHoatDongKinhDoanh.TenMuc = "None";
                if (_isNHNN == 1) _bckqHoatDongKinhDoanh.isNHNN = 1;
                _BCKQHoatDongKinhDoanhList1.Insert(0, _bckqHoatDongKinhDoanh);
                bCKQHoatDongKinhDoanhListBindingSource1.DataSource = _BCKQHoatDongKinhDoanhList1;
            }
            catch
            {
                return false;
            }
            return true;

        }

        #endregion

        #region Kiểm tra dữ liệu

        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            //if (txt_MaSo.Text == "")
            //{
            //    MessageBox.Show(this, "Vui Lòng Nhập Mã Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_MaSo.Focus();
            //    kq = false;
            //}
            if (txt_TenMucTK.Text == "")
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Mục", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenMucTK.Focus();
                kq = false;
            }
            return kq;
        }

        private Boolean KiemTraDuLieu(BCKQHoatDongKinhDoanh bckqHoatDongKinhDoanh)
        {
            Boolean kq = true;
            if (bckqHoatDongKinhDoanh.MaSo == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaSo.Focus();
                kq = false;
            }
            else if (bckqHoatDongKinhDoanh.TenMuc == "")
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Mục", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenMucTK.Focus();
                kq = false;
            }
            return kq;
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (LuuDuLieu() == true)
            {
                MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            HideShowbtnCopyBieuMau();
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (_BCKQHoatDongKinhDoanhList.Count == 0)
            {
                BCKQHoatDongKinhDoanh bckqHoatDongKinhDoanh = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh();
                bckqHoatDongKinhDoanh.LoaiBaoCao = LoaiBaoCao;
                if (_isNHNN == 1) bckqHoatDongKinhDoanh.isNHNN = 1;
                bckqHoatDongKinhDoanh.MaThongTu = _maThongTu;//
                _BCKQHoatDongKinhDoanhList.Add(bckqHoatDongKinhDoanh);
                grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_BCKQHoatDongKinhDoanhList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    BCKQHoatDongKinhDoanh bckqHoatDongKinhDoanh = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh();
                    bckqHoatDongKinhDoanh.LoaiBaoCao = LoaiBaoCao;
                    if (_isNHNN == 1) bckqHoatDongKinhDoanh.isNHNN = 1;
                    bckqHoatDongKinhDoanh.MaThongTu = _maThongTu;//
                    _BCKQHoatDongKinhDoanhList.Add(bckqHoatDongKinhDoanh);
                    grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_BCKQHoatDongKinhDoanhList.Count - 1];
                }
            }
        }
        #endregion

        #region tlslblThoat_Click

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region grdu_DanhSachMuc_InitializeLayout
        private void grdu_DanhSachMuc_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdu_DanhSachMuc.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachMuc.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                //x =  //= System.Drawing.w;//RoyalBlue
            }
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMuc"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucCha"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LoaiBaoCao"].Hidden = true;

            #region Bosung
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["isNHNN"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaThongTu"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucDoiUng"].Hidden = true;
            #endregion//Bosung

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaSo"].Header.Caption = "Mã Mục";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaSo"].Header.VisiblePosition = 1;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMuc"].Header.Caption = "Tên Mục";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMuc"].Header.VisiblePosition = 2;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["ThuyetMinh"].Header.Caption = "Thuyết Minh";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["ThuyetMinh"].Header.VisiblePosition = 3;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Loại";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.VisiblePosition = 4;


            foreach (UltraGridColumn col in this.grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                //x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["LoaiMau"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["MaChiTiet"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["MaMuc"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["MaTaiKhoan"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["MaTaiKhoanDoiUng"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["Loai"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["MaMucLienQuan"].Hidden = true;

            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["SoHieu"].Header.Caption = "Tài Khoản";
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["SoHieu"].Header.VisiblePosition = 1;

            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["CongTru"].Header.Caption = "Cộng Trừ";
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["CongTru"].Header.VisiblePosition = 4;


        }
        #endregion

        #region bt_ChiTiet_Click
        private void bt_ChiTiet_Click(object sender, EventArgs e)
        {
            frmCT_MauBangBaoCao dlg = new frmCT_MauBangBaoCao((BCKQHoatDongKinhDoanh)(bCKQHoatDongKinhDoanhListBindingSource.Current), LoaiBaoCao,_isNHNN,_maThongTu);
            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }
        #endregion

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_DanhSachMuc.DeleteSelectedRows();
        }
        #endregion

        #region tlslblUndo_Click
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            if (_isNHNN == 1)
                _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhListforNHNN(LoaiBaoCao,_maThongTu);
            else
                _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList(LoaiBaoCao,_maThongTu);
            bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;
        }
        #endregion

        private void tlsbtnCopyBieuMau_Click(object sender, EventArgs e)
        {
            frmXacNhanThongTuMauBaoCao frm = new frmXacNhanThongTuMauBaoCao(true);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                //if (frm.MaThongTu != 0)
                //{
                    _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.NewBCKQHoatDongKinhDoanhList();
                    BCKQHoatDongKinhDoanhList listForCopy = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhListbyMaThongTu(LoaiBaoCao, frm.MaThongTu,_isNHNN);
                    foreach (BCKQHoatDongKinhDoanh bangCopy in listForCopy)
                    {
                        BCKQHoatDongKinhDoanh ketqua = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanhChild(bangCopy, LoaiBaoCao);
                        if (_isNHNN == 1)
                        {
                            ketqua.isNHNN = 1;
                        }
                        else if (_isNHNN == 0)
                        {
                            ketqua.isNHNN = 0;
                        }
                        ketqua.MaThongTu = _maThongTu;
                        _BCKQHoatDongKinhDoanhList.Add(ketqua);
                    }
                    bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;

                    _BCKQHoatDongKinhDoanhList1 = BCKQHoatDongKinhDoanhList.NewBCKQHoatDongKinhDoanhList();
                    bCKQHoatDongKinhDoanhListBindingSource1.DataSource = _BCKQHoatDongKinhDoanhList1;

                //}
            }
        }
    }
}