using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmMauBCKQHoatDongKinhDoanh : Form
    {

        BCKQHoatDongKinhDoanhList _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.NewBCKQHoatDongKinhDoanhList();
        public byte LoaiBaoCao = 2;

        private byte _isNHNN = 0;
        private byte _loaiBieuMau = 0;
        private int _maThongTu = 0;
        private string _noidungThongTu = string.Empty;

        public void ShowKQHDKD()
        {
            LoaiBaoCao = 2;
            KhoiTao();
            this.Show();
        }

        public void ShowKQHDKDforNHNN()
        {
            _isNHNN = 1;
            LoaiBaoCao = 2;
            KhoiTao();
            //this.Text = "Mẫu Báo Cáo Kết Quả Hoạt Động Kinh Doanh theo NHNN";
            this.Show();
        }

        public void ShowThueTNDNTamTinh()
        {
            LoaiBaoCao = 4;
            KhoiTao();
            this.Text = "Tờ khai thuế TNDN tạm tính";

            this.Show();
        }

        public void ShowThueTNDNNam()
        {
            LoaiBaoCao = 5;
            KhoiTao();
            this.Text = "Tờ khai thuế TNDN năm";
            this.Show();
        }

        public void ShowBCCPSanXuat()
        {
            LoaiBaoCao = 6;
            KhoiTao();
            this.Show();
            this.Text = "Báo Cáo Chi Phí Sản Xuất Kinh Doanh";
        }

        private void SetTieuDeForm()
        {
            if (_isNHNN == 1)
            {
                this.Text = "Mẫu Báo Cáo Kết Quả Hoạt Động Kinh Doanh NHNN  theo " + _noidungThongTu;
            }
            else if (_isNHNN == 0)
            {
                this.Text = "Mẫu Báo Cáo Kết Quả Hoạt Động Kinh Doanh Thông Tư  theo " + _noidungThongTu;
            }
        }

        #region Contructors

        public frmMauBCKQHoatDongKinhDoanh()
        {
            InitializeComponent();

        }

        public frmMauBCKQHoatDongKinhDoanh(byte loaiBieuMau, byte thuocLoai, int maThongTu, string noidungthongtu)
        {
            InitializeComponent();
            _loaiBieuMau = loaiBieuMau;
            _isNHNN = thuocLoai;
            _maThongTu = maThongTu;
            _noidungThongTu = noidungthongtu;
            if(_isNHNN==1)
            {
                ShowKQHDKDforNHNN();
            }
            else if(_isNHNN==0)
            {
                ShowKQHDKD();
            }
            SetTieuDeForm();

            #region Bosung
            HideShowbtnCopyBieuMau();
            #endregion//Bosung

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


        #endregion

        #region Khởi Tạo
        private void KhoiTao()
        {
            if (_isNHNN==1)
                _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhListforNHNN(LoaiBaoCao,_maThongTu);
            else
                _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList(LoaiBaoCao,_maThongTu);
            bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;
            //_BCKQHoatDongKinhDoanhListComBo = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList();

            //BCKQHoatDongKinhDoanhListBindingSource1.DataSource = _BCKQHoatDongKinhDoanhListComBo;
            HeThongTaiKhoan1 heThongTaiKhoan = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            HeThongTaiKhoan1List _HeThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List(Convert.ToByte(2));
            _HeThongTaiKhoanList.Insert(0, heThongTaiKhoan);
            //heThongTaiKhoan1ListBindingSource.DataSource = _HeThongTaiKhoanList;
        }
        #endregion

        #region Lưu Dữ Liệu

        private Boolean LuuDuLieu()
        {
            try
            {
                this.bCKQHoatDongKinhDoanhListBindingSource.EndEdit();
                _BCKQHoatDongKinhDoanhList.ApplyEdit();
                _BCKQHoatDongKinhDoanhList.Save();
                //BangCanDoiKeToan bangCanDoiKeToan = BangCanDoiKeToan.NewBangCanDoiKeToan();
                bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;
                // _BCKQHoatDongKinhDoanhListComBo = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList();
                //_BCKQHoatDongKinhDoanhListComBo.Insert(0, bangCanDoiKeToan);
                // _BCKQHoatDongKinhDoanhListComBo = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList();
                //BCKQHoatDongKinhDoanhListBindingSource1.DataSource = _BCKQHoatDongKinhDoanhListComBo;
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
            if (txt_MaSo.Text == "")
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaSo.Focus();
                kq = false;
            }
            else if (txt_TenMucTK.Text == "")
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
                bckqHoatDongKinhDoanh.MaThongTu = _maThongTu;//
                if (_isNHNN == 1) bckqHoatDongKinhDoanh.isNHNN = 1;
                _BCKQHoatDongKinhDoanhList.Add(bckqHoatDongKinhDoanh);
                grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_BCKQHoatDongKinhDoanhList.Count - 1];
            }
            else
            {
                this.bCKQHoatDongKinhDoanhListBindingSource.EndEdit();
                if (KiemTraDuLieu() == true)
                {
                    BCKQHoatDongKinhDoanh bckqHoatDongKinhDoanh = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh();
                    bckqHoatDongKinhDoanh.LoaiBaoCao = LoaiBaoCao;
                    bckqHoatDongKinhDoanh.MaThongTu = _maThongTu;//
                    if (_isNHNN == 1) bckqHoatDongKinhDoanh.isNHNN = 1;
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
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaSo"].Header.Caption = "Mã Mục";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaSo"].Header.VisiblePosition = 1;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaSo"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMuc"].Header.Caption = "Tên Mục";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMuc"].Header.VisiblePosition = 2;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMuc"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["ThuyetMinh"].Header.Caption = "Thuyết Minh";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["ThuyetMinh"].Header.VisiblePosition = 3;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["ThuyetMinh"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Loại";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.VisiblePosition = 4;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["STTTinh"].Hidden = false;

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
            dlg.ShowDialog();
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
                        BCKQHoatDongKinhDoanh ketqua = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanhChild(bangCopy,LoaiBaoCao);
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

                //}
            }
        }
    }
}