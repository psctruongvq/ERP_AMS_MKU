using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmQuanHeGiaDinh : Form
    {
        #region Properties
        QuanHeGiaDinhList _QuanHeGiaDinhList;
        QuanHeGiaDinh _QuanHeGiaDinh;
        QuanHeClassList _QuanHeClassList;
        TenNhanVienList _TenNhanVienList;
        TinhThanhList _TinhThanhList;
        QuocGiaList _QuocGiaList;
        ThanhPhanGiaDinhClassList _ThanhPhanGiaDinhClassList;
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        Util util = new Util();
        bool flag = false;
        static long maNV = 0;
        #endregion

        #region Contructor
        public frmQuanHeGiaDinh()
        {
            InitializeComponent();
            KhoiTao();

            tlslblIn.Visible = false;
            toolStripButton1.Visible = false;
            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblUndo.Enabled = false;
            tlslblXoa.Enabled = false;
        }

        public frmQuanHeGiaDinh(ThongTinNhanVienTongHop thongTinNhanVienTongHop)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
        }
        #endregion

        #region KhoiTao
        public void KhoiTao()
        {
            _QuanHeClassList = QuanHeClassList.GetQuanHeClassList();
            quanHeClassListBindingSource.DataSource = _QuanHeClassList;

            _TenNhanVienList = TenNhanVienList.GetTenNhanVienList();
            tenNhanVienListBindingSource.DataSource = _TenNhanVienList;

            _TinhThanhList = TinhThanhList.GetTinhThanhList();
            tinhThanhListBindingSource.DataSource = _TinhThanhList;

            _ThanhPhanGiaDinhClassList = ThanhPhanGiaDinhClassList.GetThanhPhanGiaDinhClassList();
            thanhPhanGiaDinhClassListBindingSource.DataSource = _ThanhPhanGiaDinhClassList;

            _QuocGiaList = QuocGiaList.GetQuocGiaList();
            quocGiaListBindingSource.DataSource = _QuocGiaList;
        }
        #endregion

        #region grdu_QuanHeGiaDinh_InitializeLayout
        private void grdu_QuanHeGiaDinh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["MactQuanhegiadinh"].Hidden = true;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["HoChieu"].Hidden = true;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["SoGiayKhaiSinh"].Hidden = true;            
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["GioiTinh"].Hidden = true;            
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["MaQuanHe"].Hidden = true;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["Cmnd"].Hidden = true;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["NgayCap"].Hidden = true;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["MaNoiCap"].Hidden = true;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;            
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["MaThanhPhanGD"].Hidden = true;            
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["DangVien"].Hidden = true;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["CuTruNgoaiNuoc"].Hidden = true;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["MaNuoc"].Hidden = true;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["QuaTrinhCongTac"].Hidden = true;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = true;

            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["HoTenNguoiThan"].Header.Caption = "Họ Tên Người Thân";
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["HoTenNguoiThan"].Width = 200;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["NgaySinh"].Header.Caption = "Ngày Sinh";
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chì";
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["NgheNghiepHienTai"].Header.Caption = "Nghề Nghiệp Hiện Tại";
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["NoilamViec"].Header.Caption = "Nơi Làm Việc";
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["NoilamViec"].Width = 300;

            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["HoTenNguoiThan"].Header.VisiblePosition = 0;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["NgaySinh"].Header.VisiblePosition = 1;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 2;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["NgheNghiepHienTai"].Header.VisiblePosition = 3;
            grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns["NoilamViec"].Header.VisiblePosition = 4;
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_QuanHeGiaDinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            //this.grdu_QuanHeGiaDinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.grdu_QuanHeGiaDinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region cmbu_NoiCap_InitializeLayout
        private void cmbu_NoiCap_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Hidden = true;
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["MaKhuVuc"].Hidden = true;
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["MaTinhThanhQuanLy"].Hidden = true;
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.Caption = "Tên Tỉnh Thành";
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;

            //cmbu_NoiCap.DisplayLayout.Bands[0].Columns["MaTinhThanhQuanLy"].Header.VisiblePosition = 0;
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.VisiblePosition = 1;
            //cmbu_NoiCap.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_NoiCap.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            //this.cmbu_NoiCap.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.cmbu_NoiCap.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region tlslblThem_Click
        private void ThemMoi()
        {
            if (_ThongTinNhanVienTongHop != null)
            {
                maNV = _ThongTinNhanVienTongHop.MaNhanVien;
            }
            _QuanHeGiaDinh = QuanHeGiaDinh.NewQuanHeGiaDinh(maNV);
            _QuanHeGiaDinhList.Add(_QuanHeGiaDinh);
            quanHeGiaDinhListBindingSource.DataSource = _QuanHeGiaDinhList;
            grdu_QuanHeGiaDinh.ActiveRow = grdu_QuanHeGiaDinh.Rows[_QuanHeGiaDinhList.Count - 1];     
        }
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            ThemMoi();  
        }
        #endregion

        #region KT
        bool KT()
        {
            bool kq = false;
            if (txtu_MaNhanVien.Value != null)
            {
                kq = true;
            }
            else
            {
                MessageBox.Show(this, util.chuachonmanhanvien, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtu_MaNhanVien.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }
        #endregion

        #region tlslblLuu_Click
        private bool KiemTraDuyNhat(QuanHeGiaDinh quanHeGiaDinh)
        {
            if (QuanHeGiaDinh.KiemTraCMNDBiTrung(txt_CMND.Text,quanHeGiaDinh.MaNhanVien) > 1)
            {
                MessageBox.Show(this, "CMND đã được dùng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_CMND.Focus();
                return false;
            }
            if (QuanHeGiaDinh.KiemTraHoChieuBiTrung(tbHoChieu.Text, quanHeGiaDinh.MaNhanVien) > 1)
            {
                MessageBox.Show(this, "Hộ Chiếu đã tồn tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbHoChieu.Focus();
                return false;
            }
            if (QuanHeGiaDinh.KiemTraSoGiayKhaiSinhBiTrung(tbSoGiayKhaiSinh.Text, quanHeGiaDinh.MaNhanVien) > 1)
            {
                MessageBox.Show(this, "Số Giấy Khai Sinh đã tồn tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbSoGiayKhaiSinh.Focus();
                return false;
            }
            return true;
        }
        private void Save()
        {
            if (!KiemTraControl())
            {
                return;
            }
           
                if (flag == true) // la doi tuong moi
                {
                    if (KT() == true)
                    {
                        try
                        {
                            this.quanHeGiaDinhListBindingSource.EndEdit();
                            _QuanHeGiaDinhList.ApplyEdit();
                            _QuanHeGiaDinhList.Save();
                            MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            KhoiTao();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, util.luuthatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            string tem = ex.Message;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    try
                    {
                        this.quanHeGiaDinhListBindingSource.EndEdit();
                        _QuanHeGiaDinhList.ApplyEdit();
                        _QuanHeGiaDinhList.Save();
                        MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KhoiTao();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, util.luuthatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        string tem = ex.Message;
                    }
                }          
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            
                Save();
           
            
        }
        #endregion
        private bool KiemTraControl()
        {
            if (!HamDungChung.KiemTraLaKyTu(txt_HoTen.Text))
            {
                MessageBox.Show("Họ Tên không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_HoTen.Focus();
                return false;
            }
            if (!HamDungChung.KiemTraLaSo(txt_CMND.Text))
            {
                MessageBox.Show("CMND không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_CMND.Focus();
                return false;
            }
            QuanHeGiaDinhList _listTemp = _QuanHeGiaDinhList;
            for (int i = 0; i < _QuanHeGiaDinhList.Count; i++)
            {
                if (_QuanHeGiaDinhList[i].Cmnd == _ThongTinNhanVienTongHop.Cmnd && _ThongTinNhanVienTongHop.Cmnd != "")
                {
                    MessageBox.Show(this, "CMND của " + _ThongTinNhanVienTongHop.TenNhanVien + " không thể sử dụng để khai báo người quan hệ, Xin kiểm tra lại CMND", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_CMND.Focus();
                    return false;
                }
                for (int j = 0; j < _listTemp.Count; j++)
                {
                    if (i < j)
                    {

                        if ((_QuanHeGiaDinhList[i].Cmnd == _listTemp[j].Cmnd) && (_QuanHeGiaDinhList[i].Cmnd != ""))
                        {
                            MessageBox.Show(this, "CMND đã được dùng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txt_CMND.Focus();
                            return false;
                        }
                        if ((_QuanHeGiaDinhList[i].HoChieu == _listTemp[j].HoChieu) && (_QuanHeGiaDinhList[i].HoChieu != ""))
                        {
                            MessageBox.Show(this, "Hộ Chiếu đã tồn tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbHoChieu.Focus();
                            return false;
                        }
                        if ((_QuanHeGiaDinhList[i].SoGiayKhaiSinh == _listTemp[j].SoGiayKhaiSinh) && (_QuanHeGiaDinhList[i].SoGiayKhaiSinh != ""))
                        {
                            MessageBox.Show(this, "Số Giấy Khai Sinh đã tồn tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbSoGiayKhaiSinh.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_QuanHeGiaDinh.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdu_QuanHeGiaDinh.DeleteSelectedRows();
        }
        #endregion

        #region tlslblUndo_Click
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            KhoiTao();
        }
        #endregion

        #region cmbu_NoiCuTru_InitializeLayout
        private void cmbu_NoiCuTru_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_NoiCuTru.DisplayLayout.Bands[0].Columns["MaQuocGia"].Hidden = true;
            cmbu_NoiCuTru.DisplayLayout.Bands[0].Columns["MaQuocGiaQuanLy"].Hidden = true;
            cmbu_NoiCuTru.DisplayLayout.Bands[0].Columns["TenQuocGia"].Header.Caption = "Tên Quốc Gia";
            cmbu_NoiCuTru.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true; 

            //cmbu_NoiCuTru.DisplayLayout.Bands[0].Columns["MaQuocGiaQuanLy"].Header.VisiblePosition = 0;
            cmbu_NoiCuTru.DisplayLayout.Bands[0].Columns["TenQuocGia"].Header.VisiblePosition = 1;
            cmbu_NoiCuTru.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_NoiCuTru.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            }
            ////màu nền
            //this.cmbu_NoiCuTru.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.cmbu_NoiCuTru.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region cmbu_ThanhPhanGD_InitializeLayout
        private void cmbu_ThanhPhanGD_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_ThanhPhanGD.DisplayLayout.Bands[0].Columns["MaThanhPhan"].Hidden = true;
            cmbu_ThanhPhanGD.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Thành Phần Gia Đình";
            cmbu_ThanhPhanGD.DisplayLayout.Bands[0].Columns["ThanhPhanGiaDinh"].Header.Caption = "Thành Phần Gia Đình";


            cmbu_ThanhPhanGD.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            cmbu_ThanhPhanGD.DisplayLayout.Bands[0].Columns["ThanhPhanGiaDinh"].Header.VisiblePosition = 1;            
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_ThanhPhanGD.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            ////màu nền
            //this.cmbu_ThanhPhanGD.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.cmbu_ThanhPhanGD.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            TimKiem();
        }
        private void TimKiem()
        {
            frmTimNhanVien _frmTimNhanVien = new frmTimNhanVien(21);
            if (_frmTimNhanVien.ShowDialog(this) != DialogResult.OK)
            {
                if (_ThongTinNhanVienTongHop != null)
                {
                    _QuanHeGiaDinhList = QuanHeGiaDinhList.GetQuanHeGiaDinhList(_ThongTinNhanVienTongHop.MaNhanVien);
                    quanHeGiaDinhListBindingSource.DataSource = _QuanHeGiaDinhList;

                    txtu_TenNhanVien.Text = _ThongTinNhanVienTongHop.TenNhanVien.ToString();
                    txtu_MaNhanVien.Value = _ThongTinNhanVienTongHop.MaNhanVien;
                    txtu_MaNhanVienQL.Text = _ThongTinNhanVienTongHop.MaQLNhanVien.ToString();

                    tlslblThem.Enabled = true;
                    tlslblLuu.Enabled = true;
                    tlslblUndo.Enabled = true;
                    tlslblXoa.Enabled = true;
                }
            }

        }
        private void cmbu_CuTruNuocNgoai_ValueChanged(object sender, EventArgs e)
        {
            if ((bool)cmbu_CuTruNuocNgoai.Value==true)
            {
                label17.Enabled = true;
                cmbu_NoiCuTru.Enabled = true;
            }
            else
            {
                label17.Enabled = false;
                cmbu_NoiCuTru.Enabled = false;
            }
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
           // frmMainNhanSu.LoadHelp(this, "Quan he gia dinh");
        }

        private void frmQuanHeGiaDinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                TimKiem();
            }
            else if (e.KeyCode == Keys.F1)
            {
                //frmMainNhanSu.LoadHelp(this, "Quan he gia dinh");
            }
            else if (e.Control && e.KeyCode == Keys.N && tlslblThem.Enabled==true)
            {
                ThemMoi();
            }
            else if (e.Control && e.KeyCode == Keys.S && tlslblLuu.Enabled==true)
            {
                Save();
            }
        }

        private void frmQuanHeGiaDinh_Load(object sender, EventArgs e)
        {

        }

        private void txtu_MaNhanVienQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                maNV = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop_ByMaQLNhanVien(txtu_MaNhanVienQL.Text).MaNhanVien;
                _QuanHeGiaDinhList = QuanHeGiaDinhList.GetQuanHeGiaDinhList(maNV);
                quanHeGiaDinhListBindingSource.DataSource = _QuanHeGiaDinhList;                
                    txtu_TenNhanVien.Text = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop_ByMaQLNhanVien(txtu_MaNhanVienQL.Text).TenNhanVien;
                   
                    //txtu_MaNhanVienQL.Text = _ThongTinNhanVienTongHop.MaQLNhanVien.ToString();
                    if (maNV == 0)
                    {
                        tlslblThem.Enabled = false;
                        tlslblLuu.Enabled = false;
                        tlslblUndo.Enabled = false;
                        tlslblXoa.Enabled = false;
                    }
                    else
                    {
                        txtu_MaNhanVienQL.Text = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop_ByMaQLNhanVien(txtu_MaNhanVienQL.Text).MaQLNhanVien;                 
                        tlslblThem.Enabled = true;
                        tlslblLuu.Enabled = true;
                        tlslblUndo.Enabled = true;
                        tlslblXoa.Enabled = true;
                    }

                
            }
        }

     
    }
}