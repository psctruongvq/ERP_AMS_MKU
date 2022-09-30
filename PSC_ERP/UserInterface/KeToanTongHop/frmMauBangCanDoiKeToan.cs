using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class frmMauBangCanDoiKeToan : Form
    {
        #region Properties


        BangCanDoiKeToanList _BangCanDoiKeToanList;
        BangCanDoiKeToanList _BangCanDoiKeToanListComBo;

        private byte _isNHNN = 0;
        private byte _loaiBieuMau = 0;
        private int _maThongTu = 0;
        private string _noidungThongTu = string.Empty;

        #endregion

        #region Contructors
        public frmMauBangCanDoiKeToan()
        {
            InitializeComponent();
            this.Text = "Mẫu Bảng Cân Đối Kế Toán Cho Thông Tư";
            KhoiTao();
        }

        public frmMauBangCanDoiKeToan(byte isNHNN)
        {
            InitializeComponent();
            _isNHNN = isNHNN;
            this.Text = "Mẫu Bảng Cân Đối Kế Toán Cho NHNN";
            KhoiTaoforMauNHNN();
        }

        public frmMauBangCanDoiKeToan(byte loaiBieuMau, byte thuocLoai,int maThongTu,string noidungthongtu)
        {
            InitializeComponent();
            _loaiBieuMau = loaiBieuMau;
            _isNHNN = thuocLoai;
            _maThongTu = maThongTu;
            _noidungThongTu = noidungthongtu;
            if(_isNHNN==1)
            {
                KhoiTaoforMauNHNN();
            }
            else if(_isNHNN==0)
            {
                KhoiTao();
            }
            SetTieuDeForm();
            #region Bosung
            HideShowbtnCopyBieuMau();
            #endregion//Bosung
        }
        #endregion

        private void SetTieuDeForm()
        {
            if(_isNHNN==1)
            {
                this.Text = "Mẫu Bảng Cân Đối Kế Toán Cho NHNN  theo "+_noidungThongTu;
            }
            else if (_isNHNN == 0)
            {
                this.Text = "Mẫu Bảng Cân Đối Kế Toán Cho Thông Tư  theo " + _noidungThongTu;
            }
                

        }
        #region Khởi Tạo
        private void KhoiTao()
        {

            _BangCanDoiKeToanList = BangCanDoiKeToanList.GetBangCanDoiKeToanList(_maThongTu);
            bangCanDoiKeToanListBindingSource.DataSource = _BangCanDoiKeToanList;
            BangCanDoiKeToan bangCanDoiKeToan = BangCanDoiKeToan.NewBangCanDoiKeToan();
            _BangCanDoiKeToanListComBo = BangCanDoiKeToanList.GetBangCanDoiKeToanList(_maThongTu);
            _BangCanDoiKeToanListComBo.Insert(0, bangCanDoiKeToan);
            bangCanDoiKeToanListBindingSource1.DataSource = _BangCanDoiKeToanListComBo;
            HeThongTaiKhoan1 heThongTaiKhoan = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            HeThongTaiKhoan1List _HeThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List(Convert.ToByte(2));
            _HeThongTaiKhoanList.Insert(0, heThongTaiKhoan);
            heThongTaiKhoan1ListBindingSource.DataSource = _HeThongTaiKhoanList;
        }

        private void KhoiTaoforMauNHNN()
        {

            _BangCanDoiKeToanList = BangCanDoiKeToanList.GetBangCanDoiKeToanListforNHNN(_maThongTu);
            bangCanDoiKeToanListBindingSource.DataSource = _BangCanDoiKeToanList;
            BangCanDoiKeToan bangCanDoiKeToan = BangCanDoiKeToan.NewBangCanDoiKeToan();
            bangCanDoiKeToan.isNHNN = 1;//
            bangCanDoiKeToan.MaThongTu = _maThongTu;
            _BangCanDoiKeToanListComBo = BangCanDoiKeToanList.GetBangCanDoiKeToanListforNHNN(_maThongTu);
            _BangCanDoiKeToanListComBo.Insert(0, bangCanDoiKeToan);
            bangCanDoiKeToanListBindingSource1.DataSource = _BangCanDoiKeToanListComBo;
            HeThongTaiKhoan1 heThongTaiKhoan = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            HeThongTaiKhoan1List _HeThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List(Convert.ToByte(2));
            _HeThongTaiKhoanList.Insert(0, heThongTaiKhoan);
            heThongTaiKhoan1ListBindingSource.DataSource = _HeThongTaiKhoanList;
            
        }
        #endregion
        private void HideShowbtnCopyBieuMau()
        {
            if (_BangCanDoiKeToanList.Count == 0)
            {
                btnCopyBieuMau.Visible = true;
            }
            else
            {
                btnCopyBieuMau.Visible = false;
            }
        }

        #region Lưu Dữ Liệu

        private Boolean LuuDuLieu()
        {
            try
            {
                #region Old
                //_BangCanDoiKeToanList.ApplyEdit();
                //_BangCanDoiKeToanList.Save();
                //BangCanDoiKeToan bangCanDoiKeToan = BangCanDoiKeToan.NewBangCanDoiKeToan();
                //bangCanDoiKeToanListBindingSource.DataSource = _BangCanDoiKeToanList;
                //_BangCanDoiKeToanListComBo = BangCanDoiKeToanList.GetBangCanDoiKeToanList();
                //_BangCanDoiKeToanListComBo.Insert(0, bangCanDoiKeToan);
                //_BangCanDoiKeToanListComBo = BangCanDoiKeToanList.GetBangCanDoiKeToanList();
                //bangCanDoiKeToanListBindingSource1.DataSource = _BangCanDoiKeToanListComBo;
                #endregion//Old
                #region New
                _BangCanDoiKeToanList.ApplyEdit();
                _BangCanDoiKeToanList.Save();
                BangCanDoiKeToan bangCanDoiKeToan = BangCanDoiKeToan.NewBangCanDoiKeToan();
                if (_isNHNN == 1)
                {
                    bangCanDoiKeToan.isNHNN = 1;
                    _BangCanDoiKeToanListComBo = BangCanDoiKeToanList.GetBangCanDoiKeToanListforNHNN(_maThongTu);
                }
                else
                    _BangCanDoiKeToanListComBo = BangCanDoiKeToanList.GetBangCanDoiKeToanList(_maThongTu);
                bangCanDoiKeToan.MaThongTu = _maThongTu;//
                _BangCanDoiKeToanListComBo.Insert(0, bangCanDoiKeToan);
                bangCanDoiKeToanListBindingSource.DataSource = _BangCanDoiKeToanList;
                bangCanDoiKeToanListBindingSource1.DataSource = _BangCanDoiKeToanListComBo;
                #endregion//New
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

        private Boolean KiemTraDuLieu(BangCanDoiKeToan bangCanDoi)
        {
            Boolean kq = true;
            if (bangCanDoi.MaSo == "")
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaSo.Focus();
                kq = false;
            }
            else if (bangCanDoi.TenMucTaiKhoan == "")
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
            if (_BangCanDoiKeToanList.Count == 0)
            {
                BangCanDoiKeToan bangCanDoiKeToan = BangCanDoiKeToan.NewBangCanDoiKeToan();
                if (_isNHNN == 1)
                    bangCanDoiKeToan.isNHNN = 1;
                bangCanDoiKeToan.MaThongTu = _maThongTu;//
                _BangCanDoiKeToanList.Add(bangCanDoiKeToan);
                grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_BangCanDoiKeToanList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    BangCanDoiKeToan bangCanDoiKeToan = BangCanDoiKeToan.NewBangCanDoiKeToan();
                    if (_isNHNN == 1)
                        bangCanDoiKeToan.isNHNN = 1;
                    bangCanDoiKeToan.MaThongTu = _maThongTu;//
                    _BangCanDoiKeToanList.Add(bangCanDoiKeToan);
                    grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_BangCanDoiKeToanList.Count - 1];
                }
            }
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
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucTaiKhoan"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucTaiKhoanCha"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = true;

            #region Bosung
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["isNHNN"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaThongTu"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucTaiKhoanDoiUng"].Hidden = true;
            #endregion//Bosung

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaSo"].Header.Caption = "Mã Số";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaSo"].Header.VisiblePosition = 1;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMucTaiKhoan"].Header.Caption = "Tên Mục Tài Khoản";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMucTaiKhoan"].Header.VisiblePosition = 2;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["ThuyetMinh"].Header.Caption = "Thuyết Minh";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["ThuyetMinh"].Header.VisiblePosition = 3;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMucTaiKhoanCha"].Header.Caption = "Tên Mục Tài Khoản Cha";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMucTaiKhoanCha"].Header.VisiblePosition = 4;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 5;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CapMuc"].Header.Caption = "Cấp";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CapMuc"].Header.VisiblePosition = 6;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Ghi chú";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 7;

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

        #region cbu_MucTaiKhoanCha_ValueChanged
        private void cbu_MucTaiKhoanCha_ValueChanged(object sender, EventArgs e)
        {
            if (cbu_MucTaiKhoanCha.Value != null)
            {
                ((BangCanDoiKeToan)bangCanDoiKeToanListBindingSource.Current).MaMucTaiKhoanCha = Convert.ToInt32(cbu_MucTaiKhoanCha.Value);
                ((BangCanDoiKeToan)bangCanDoiKeToanListBindingSource.Current).TenMucTaiKhoanCha = cbu_MucTaiKhoanCha.ActiveRow.Cells["TenMucTaiKhoanCha"].Value.ToString();
            }
        }
        #endregion

        #region cbu_MucTaiKhoanCha_InitializeLayout
        private void cbu_MucTaiKhoanCha_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cbu_MucTaiKhoanCha.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_MucTaiKhoanCha.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns["MaSo"].Header.Caption = "Mã Số";
            cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns["MaSo"].Header.VisiblePosition = 1;
            cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns["MaSo"].Hidden = false;

            cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns["TenMucTaiKhoan"].Header.Caption = "Tên Mục Tài Khoản";
            cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns["TenMucTaiKhoan"].Header.VisiblePosition = 2;
            cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns["TenMucTaiKhoan"].Hidden = false;

            cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns["CapMuc"].Header.Caption = "Cấp";
            cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns["CapMuc"].Header.VisiblePosition = 3;
            cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns["CapMuc"].Hidden = false;
        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region bt_ChiTiet_Click
        private void bt_ChiTiet_Click(object sender, EventArgs e)
        {
            frmCT_MauBangBaoCao dlg = new frmCT_MauBangBaoCao((BangCanDoiKeToan)(bangCanDoiKeToanListBindingSource.Current));
            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }
        #endregion

        #region tlslblUndo_Click
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            if (_isNHNN == 1)
            {
                _BangCanDoiKeToanList = BangCanDoiKeToanList.GetBangCanDoiKeToanListforNHNN(_maThongTu);
            }
            else
                _BangCanDoiKeToanList = BangCanDoiKeToanList.GetBangCanDoiKeToanList(_maThongTu);
            bangCanDoiKeToanListBindingSource.DataSource = _BangCanDoiKeToanList;
        }
        #endregion

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_DanhSachMuc.DeleteSelectedRows();
        }
        #endregion

        private void btnCopyBieuMau_Click(object sender, EventArgs e)
        {
            frmXacNhanThongTuMauBaoCao frm = new frmXacNhanThongTuMauBaoCao(true);
            if(frm.ShowDialog()!=DialogResult.OK)
            {
                //if(frm.MaThongTu!=0)
                //{
                    _BangCanDoiKeToanList = BangCanDoiKeToanList.NewBangCanDoiKeToanList();
                    BangCanDoiKeToanList listForCopy = BangCanDoiKeToanList.GetBangCanDoiKeToanListbyMaThongTu(frm.MaThongTu,_isNHNN);
                    foreach (BangCanDoiKeToan bangCopy in listForCopy)
                    {
                        BangCanDoiKeToan bangCanDoiKeToan = BangCanDoiKeToan.NewBangCanDoiKeToanChild(bangCopy);
                        if (_isNHNN == 1)
                        {
                            bangCanDoiKeToan.isNHNN = 1;
                        }
                        else if (_isNHNN == 0)
                        {
                            bangCanDoiKeToan.isNHNN = 0;
                        }
                        bangCanDoiKeToan.MaThongTu = _maThongTu;
                        _BangCanDoiKeToanList.Add(bangCanDoiKeToan);
                    }
                    bangCanDoiKeToanListBindingSource.DataSource = _BangCanDoiKeToanList;

                    _BangCanDoiKeToanListComBo = BangCanDoiKeToanList.NewBangCanDoiKeToanList();
                    bangCanDoiKeToanListBindingSource1.DataSource = _BangCanDoiKeToanListComBo;
                    
                //}
                
                

            }
        }
    }
}