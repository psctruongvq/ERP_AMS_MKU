using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmMauTMBCTC_VonChuSoHuu_ThongTu : Form
    {
        TMBCTC_CongThucVCSHList _TMBCTC_CongThucVCSHList = TMBCTC_CongThucVCSHList.NewTMBCTC_CongThucVCSHList();
        HeThongTaiKhoan1List _HeThongTaiKhoanList;
        HeThongTaiKhoan1List _HeThongTaiKhoanList1;


        #region BoSung
        private byte _isNHNN = 0;
        private int _maThongTu = 1;
        private string _noidungThongTu = string.Empty;
        #endregion//BoSung

        #region Funtions

        private void SetTieuDeForm()
        {
            if (_isNHNN == 1)
            {
                this.Text = "TMBCTC-Vốn Chủ Sở Hữu Của NHNN  theo " + _noidungThongTu;
            }
            else if (_isNHNN == 0)
            {
                this.Text = "TMBCTC-Vốn Chủ Sở Hữu Của Thông Tư  theo " + _noidungThongTu;
            }
        }

        private void HideShowbtnCopyBieuMau()
        {
            if (_TMBCTC_CongThucVCSHList.Count == 0)
            {
                btnCopyBieuMau.Visible = true;
            }
            else
            {
                btnCopyBieuMau.Visible = false;
            }
        }

        private void LoadDataByMaThongTu()
        {
            _TMBCTC_CongThucVCSHList = TMBCTC_CongThucVCSHList.GetTMBCTC_CongThucVCSHListbyMaThongTu(_maThongTu,_isNHNN);
            HideShowbtnCopyBieuMau();
        }
        #endregion//Funtions


        public frmMauTMBCTC_VonChuSoHuu_ThongTu(byte thuocLoai, int maThongTu, string noidungthongtu)
        {
            InitializeComponent();
            //
            _isNHNN = thuocLoai;
            _maThongTu = maThongTu;
            _noidungThongTu = noidungthongtu;
            SetTieuDeForm();
            //
            _HeThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List(Convert.ToByte(0));
            HeThongTaiKhoan1 heThongTaiKhoan = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            heThongTaiKhoan.SoHieuTK = "None";
            heThongTaiKhoan.TenTaiKhoan = "None";
            _HeThongTaiKhoanList.Insert(0, heThongTaiKhoan);
            heThongTaiKhoan1ListBindingSource.DataSource = _HeThongTaiKhoanList;

            _HeThongTaiKhoanList1 = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List(Convert.ToByte(0));
            HeThongTaiKhoan1 heThongTaiKhoan1 = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            heThongTaiKhoan1.SoHieuTK = "None";
            heThongTaiKhoan1.TenTaiKhoan = "None";
            _HeThongTaiKhoanList1.Insert(0, heThongTaiKhoan1);
            heThongTaiKhoan1ListBindingSource1.DataSource = _HeThongTaiKhoanList1;

            //_TMBCTC_CongThucVCSHList = TMBCTC_CongThucVCSHList.GetTMBCTC_CongThucVCSHList();
            LoadDataByMaThongTu();
            tMBCTCCongThucVCSHListBindingSource.DataSource = _TMBCTC_CongThucVCSHList;
        }

        #region cbu_TaiKhoan_InitializeLayout
        private void cbu_TaiKhoan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_TaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;

            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 100;
            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
        }
        #endregion 

        #region cbu_TaiKhoanDU_InitializeLayout
        private void cbu_TaiKhoanDU_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;

            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 100;
            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
        }
        #endregion 

        #region grdu_DanhSachMuc_InitializeLayout
        private void grdu_DanhSachMuc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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
            
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaNguon"].Header.Caption = "Mã Nguồn";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaNguon"].Header.VisiblePosition = 1;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaNguon"].EditorComponent = cbu_Nguon;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaNguon"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["HinhThuc"].Header.Caption = "Hình Thức";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["HinhThuc"].Header.VisiblePosition = 2;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["HinhThuc"].EditorComponent = cbu_HinhThuc;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["HinhThuc"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.Caption = "Tài Khoản";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.VisiblePosition = 3;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].EditorComponent = cbu_TaiKhoan;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = false;
            
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiUng"].Header.Caption = "Tài Khoản Đối Ứng";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiUng"].Header.VisiblePosition = 4;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiUng"].EditorComponent = cbu_TaiKhoanDU;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiUng"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Loại";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.VisiblePosition = 5;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].EditorComponent = cbeu_Loai;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CongTru"].Header.Caption = "Cộng Trừ";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CongTru"].Header.VisiblePosition = 6;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CongTru"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoCo"].Header.Caption = "Nợ Có";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoCo"].Header.VisiblePosition = 7;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoCo"].Hidden = false;
        }
        #endregion 

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (_TMBCTC_CongThucVCSHList.Count == 0)
            {
                TMBCTC_CongThucVCSH _TMBCTC_CongThucVCSH = TMBCTC_CongThucVCSH.NewTMBCTC_CongThucVCSH();
                //
                _TMBCTC_CongThucVCSH.MaThongTu = _maThongTu;
                _TMBCTC_CongThucVCSH.isNHNN = _isNHNN;
                //
                _TMBCTC_CongThucVCSHList.Add(_TMBCTC_CongThucVCSH);
                grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_TMBCTC_CongThucVCSHList.Count - 1];
            }
            else
            {
                
                    TMBCTC_CongThucVCSH _TMBCTC_CongThucVCSH = TMBCTC_CongThucVCSH.NewTMBCTC_CongThucVCSH();
                    //
                    _TMBCTC_CongThucVCSH.MaThongTu = _maThongTu;
                    _TMBCTC_CongThucVCSH.isNHNN = _isNHNN;
                    //
                    _TMBCTC_CongThucVCSHList.Add(_TMBCTC_CongThucVCSH);
                    grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_TMBCTC_CongThucVCSHList.Count - 1];
               
            }
        }
        #endregion 

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _TMBCTC_CongThucVCSHList.ApplyEdit();
                _TMBCTC_CongThucVCSHList.Save();
                MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {

        }

        private void btnCopyBieuMau_Click(object sender, EventArgs e)
        {
            frmXacNhanThongTuMauBaoCao frm = new frmXacNhanThongTuMauBaoCao(true);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                _TMBCTC_CongThucVCSHList = TMBCTC_CongThucVCSHList.NewTMBCTC_CongThucVCSHList();
                TMBCTC_CongThucVCSHList listForCopy = TMBCTC_CongThucVCSHList.GetTMBCTC_CongThucVCSHListbyMaThongTu(frm.MaThongTu, _isNHNN);
                foreach (TMBCTC_CongThucVCSH bangCopy in listForCopy)
                {
                    TMBCTC_CongThucVCSH tMBCTC_VCSH = TMBCTC_CongThucVCSH.NewTMBCTC_CongThucVCSHChild(bangCopy);
                    tMBCTC_VCSH.MaThongTu = _maThongTu;
                    tMBCTC_VCSH.isNHNN = _isNHNN;
                    _TMBCTC_CongThucVCSHList.Add(tMBCTC_VCSH);
                }
                tMBCTCCongThucVCSHListBindingSource.DataSource = _TMBCTC_CongThucVCSHList;

            }
        }
    }
}
