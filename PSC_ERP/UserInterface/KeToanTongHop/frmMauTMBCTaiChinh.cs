using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmMauTMBCTaiChinh : Form
    {
        CT_MucTMBCTaiChinhList _CT_MucTMBCTaiChinhList = CT_MucTMBCTaiChinhList.NewCT_MucTMBCTaiChinhList();

        CT_MucTMBCTaiChinhList _CT_MucTMBCTaiChinhMotList = CT_MucTMBCTaiChinhList.NewCT_MucTMBCTaiChinhList();

        Util util = new Util();

        #region BoSung
        private byte _isNHNN = 0;
        private int _maThongTu = 0;
        private string _noidungThongTu = string.Empty;
        #endregion//BoSung

        #region Funtions

        private void SetTieuDeForm()
        {
            if (_isNHNN == 1)
            {
                this.Text = "Mẫu Thuyết Minh Báo Cáo Tài Chính Của NHNN  theo " + _noidungThongTu;
            }
            else if (_isNHNN == 0)
            {
                this.Text = "Mẫu Thuyết Minh Báo Cáo Tài Chính Của Thông Tư  theo " + _noidungThongTu;
            }
        }

        private void HideShowbtnCopyBieuMau()
        {
            if (_CT_MucTMBCTaiChinhList.Count == 0)
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
            _CT_MucTMBCTaiChinhList = CT_MucTMBCTaiChinhList.GetCT_MucTMBCTaiChinhListbyMaThongTu(_maThongTu,_isNHNN);
            cTMucTMBCTaiChinhBindingSource.DataSource = _CT_MucTMBCTaiChinhList;
            HideShowbtnCopyBieuMau();

            _CT_MucTMBCTaiChinhMotList = CT_MucTMBCTaiChinhList.GetCT_MucTMBCTaiChinhListbyMaThongTu(_maThongTu, _isNHNN);
            CT_MucTMBCTaiChinh _CT_MucTMBCTaiChinh = CT_MucTMBCTaiChinh.NewCT_MucTMBCTaiChinh();
            _CT_MucTMBCTaiChinh.TenMucCapHai = "None";
            _CT_MucTMBCTaiChinhMotList.Insert(0, _CT_MucTMBCTaiChinh);

            cTMucTMBCTaiChinhListBindingSource.DataSource = _CT_MucTMBCTaiChinhMotList;
            mucTMBCTaiChinhListBindingSource.DataSource = MucTMBCTaiChinhList.GetMucTMBCTaiChinhListbyMaThongTu(_maThongTu, _isNHNN);
        }
        #endregion//Funtions

        public frmMauTMBCTaiChinh()
        {
            InitializeComponent();
            KhoiTao();
        }

        public frmMauTMBCTaiChinh(byte thuocLoai, int maThongTu, string noidungthongtu)
        {
            InitializeComponent();
            //
            _isNHNN = thuocLoai;
            _maThongTu = maThongTu;
            _noidungThongTu = noidungthongtu;
            SetTieuDeForm();
            //
            KhoiTao();
        }

        #region Khởi Tao
        private void KhoiTao()
        {
            LoadDataByMaThongTu();
            //_CT_MucTMBCTaiChinhList = CT_MucTMBCTaiChinhList.GetCT_MucTMBCTaiChinhList();
            //cTMucTMBCTaiChinhBindingSource.DataSource = _CT_MucTMBCTaiChinhList;

            //_CT_MucTMBCTaiChinhMotList = CT_MucTMBCTaiChinhList.GetCT_MucTMBCTaiChinhList();
            //CT_MucTMBCTaiChinh _CT_MucTMBCTaiChinh = CT_MucTMBCTaiChinh.NewCT_MucTMBCTaiChinh();
            //_CT_MucTMBCTaiChinh.TenMucCapHai = "None";            
            //_CT_MucTMBCTaiChinhMotList.Insert(0, _CT_MucTMBCTaiChinh); 

            //cTMucTMBCTaiChinhListBindingSource.DataSource = _CT_MucTMBCTaiChinhMotList;
            //mucTMBCTaiChinhListBindingSource.DataSource = MucTMBCTaiChinhList.GetMucTMBCTaiChinhList();
        }
        #endregion 

        #region Kiểm Tra Dữ Liệu
        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (txt_TenMuc.Text == string.Empty)
            {
                MessageBox.Show(this, util.nhaptenky, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenMuc.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }
        #endregion 

        #region bt_ChiTiet_Click
        private void bt_ChiTiet_Click(object sender, EventArgs e)
        {
            frmCT_MauTMBCTaiChinh dlg = new frmCT_MauTMBCTaiChinh((CT_MucTMBCTaiChinh)cTMucTMBCTaiChinhBindingSource.Current,_maThongTu,_isNHNN);//new frmCT_MauTMBCTaiChinh((CT_MucTMBCTaiChinh)cTMucTMBCTaiChinhBindingSource.Current);
            dlg.ShowDialog();
        }
        #endregion       

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (_CT_MucTMBCTaiChinhList.Count == 0)
            {
                CT_MucTMBCTaiChinh _CT_MucTMBCTaiChinh = CT_MucTMBCTaiChinh.NewCT_MucTMBCTaiChinh();
                //
                _CT_MucTMBCTaiChinh.MaThongTu = _maThongTu;
                _CT_MucTMBCTaiChinh.isNHNN = _isNHNN;
                //
                _CT_MucTMBCTaiChinhList.Add(_CT_MucTMBCTaiChinh);
                grdu_DanhSach.ActiveRow = grdu_DanhSach.Rows[_CT_MucTMBCTaiChinhList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    CT_MucTMBCTaiChinh _CT_MucTMBCTaiChinh = CT_MucTMBCTaiChinh.NewCT_MucTMBCTaiChinh();
                    //
                    _CT_MucTMBCTaiChinh.MaThongTu = _maThongTu;
                    _CT_MucTMBCTaiChinh.isNHNN = _isNHNN;
                    //
                    _CT_MucTMBCTaiChinhList.Add(_CT_MucTMBCTaiChinh);
                    grdu_DanhSach.ActiveRow = grdu_DanhSach.Rows[_CT_MucTMBCTaiChinhList.Count - 1];
                }
            }
        }
        #endregion 

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            CT_MucTMBCTaiChinh _CT_MucTMBCTaiChinh;
            for (int i = 0; i < _CT_MucTMBCTaiChinhList.Count; i++)
            {
                _CT_MucTMBCTaiChinh = _CT_MucTMBCTaiChinhList[i];
                if (_CT_MucTMBCTaiChinh.TenMucCapHai == string.Empty)
                {
                    MessageBox.Show(this, util.nhaptenky, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_DanhSach.ActiveRow = grdu_DanhSach.Rows[i];
                    txt_TenMuc.Focus();
                    return;
                }
            }

            _CT_MucTMBCTaiChinhList.ApplyEdit();
            _CT_MucTMBCTaiChinhList.Save();
            MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);

            _CT_MucTMBCTaiChinhMotList = CT_MucTMBCTaiChinhList.GetCT_MucTMBCTaiChinhListbyMaThongTu(_maThongTu,_isNHNN);
            CT_MucTMBCTaiChinh _CT_MucTMBCTaiChinhMot = CT_MucTMBCTaiChinh.NewCT_MucTMBCTaiChinh();
            _CT_MucTMBCTaiChinhMot.TenMucCapHai = "None";
            _CT_MucTMBCTaiChinhMotList.Insert(0, _CT_MucTMBCTaiChinhMot);
            cTMucTMBCTaiChinhListBindingSource.DataSource = _CT_MucTMBCTaiChinhMotList;

        }
        #endregion

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DanhSach.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn  Dòng Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else grdu_DanhSach.DeleteSelectedRows();
        }
        #endregion 

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region cbu_MucLienQuan_InitializeLayout
        private void cbu_MucLienQuan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            this.cbu_MucLienQuan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_MucLienQuan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridBand band in this.cbu_MucLienQuan.DisplayLayout.Bands)
            {
                foreach (UltraGridColumn column in band.Columns)
                {
                    column.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    column.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    column.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                    column.Hidden = true;
                }
            }
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["SoTT"].Header.Caption = "Mã Số";
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["SoTT"].Header.VisiblePosition = 1;
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["SoTT"].Hidden = false;

            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["TenMucCapMot"].Header.Caption = "Tên Mục";
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["TenMucCapMot"].Header.VisiblePosition = 2;
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["TenMucCapMot"].Hidden = false;

            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Cấp Mục";
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;

            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["Vitri"].Header.Caption = "Diễn Giải";
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["Vitri"].Header.VisiblePosition = 4;
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["Vitri"].Hidden = false;  
        }
        #endregion 

        #region cbu_MucCapTren_InitializeLayout
        private void cbu_MucCapTren_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cbu_MucCapTren.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_MucCapTren.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridBand band in this.cbu_MucCapTren.DisplayLayout.Bands)
            {
                foreach (UltraGridColumn column in band.Columns)
                {
                    column.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    column.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    column.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                    column.Hidden = true;
                }
            }
            cbu_MucCapTren.DisplayLayout.Bands[0].Columns["MaSo"].Header.Caption = "Mã Số";
            cbu_MucCapTren.DisplayLayout.Bands[0].Columns["MaSo"].Header.VisiblePosition = 1;
            cbu_MucCapTren.DisplayLayout.Bands[0].Columns["MaSo"].Hidden = false;

            cbu_MucCapTren.DisplayLayout.Bands[0].Columns["TenMucCapHai"].Header.Caption = "Tên Mục";
            cbu_MucCapTren.DisplayLayout.Bands[0].Columns["TenMucCapHai"].Header.VisiblePosition = 1;
            cbu_MucCapTren.DisplayLayout.Bands[0].Columns["TenMucCapHai"].Hidden = false;

            cbu_MucCapTren.DisplayLayout.Bands[0].Columns["capMuc"].Header.Caption = "Cấp Mục";
            cbu_MucCapTren.DisplayLayout.Bands[0].Columns["capMuc"].Header.VisiblePosition = 4;
            cbu_MucCapTren.DisplayLayout.Bands[0].Columns["capMuc"].Hidden = false;

            cbu_MucCapTren.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            cbu_MucCapTren.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            cbu_MucCapTren.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;   
        }
        #endregion 

        #region grdu_DanhSach_InitializeLayout
        private void grdu_DanhSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            this.grdu_DanhSach.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSach.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridBand band in this.grdu_DanhSach.DisplayLayout.Bands)
            {
                foreach (UltraGridColumn column in band.Columns)
                {
                    column.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    column.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    column.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                    column.Hidden = true;
                }
            }
            grdu_DanhSach.DisplayLayout.Bands[0].Columns["MaSo"].Header.Caption = "Mã Số";
            grdu_DanhSach.DisplayLayout.Bands[0].Columns["MaSo"].Header.VisiblePosition = 1;
            grdu_DanhSach.DisplayLayout.Bands[0].Columns["MaSo"].Hidden = false;

            grdu_DanhSach.DisplayLayout.Bands[0].Columns["TenMucCapHai"].Header.Caption = "Tên Mục";
            grdu_DanhSach.DisplayLayout.Bands[0].Columns["TenMucCapHai"].Header.VisiblePosition = 1;
            grdu_DanhSach.DisplayLayout.Bands[0].Columns["TenMucCapHai"].Hidden = false;

            grdu_DanhSach.DisplayLayout.Bands[0].Columns["capMuc"].Header.Caption = "Cấp Mục";
            grdu_DanhSach.DisplayLayout.Bands[0].Columns["capMuc"].Header.VisiblePosition = 4;
            grdu_DanhSach.DisplayLayout.Bands[0].Columns["capMuc"].Hidden = false;

            grdu_DanhSach.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_DanhSach.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            grdu_DanhSach.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;

            grdu_DanhSach.DisplayLayout.Bands[0].Columns["SoTTTinhToan"].Header.Caption = "Số TT Tính Toán";
            grdu_DanhSach.DisplayLayout.Bands[0].Columns["SoTTTinhToan"].Header.VisiblePosition = 3;
            grdu_DanhSach.DisplayLayout.Bands[0].Columns["SoTTTinhToan"].Hidden = false;

        }
        #endregion 

        private void frmMauTMBCTaiChinh_Load(object sender, EventArgs e)
        {

        }

        private void btnCopyBieuMau_Click(object sender, EventArgs e)
        {
            frmXacNhanThongTuMauBaoCao frm = new frmXacNhanThongTuMauBaoCao(true);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                _CT_MucTMBCTaiChinhList = CT_MucTMBCTaiChinhList.NewCT_MucTMBCTaiChinhList();
                CT_MucTMBCTaiChinhList listForCopy = CT_MucTMBCTaiChinhList.GetCT_MucTMBCTaiChinhListbyMaThongTu(frm.MaThongTu, _isNHNN);
                foreach (CT_MucTMBCTaiChinh bangCopy in listForCopy)
                {
                    CT_MucTMBCTaiChinh ct_MucTMBCTC = CT_MucTMBCTaiChinh.NewCT_MucTMBCTaiChinhChild(bangCopy);
                    ct_MucTMBCTC.MaThongTu = _maThongTu;
                    ct_MucTMBCTC.isNHNN = _isNHNN;
                    _CT_MucTMBCTaiChinhList.Add(ct_MucTMBCTC);
                }
                cTMucTMBCTaiChinhBindingSource.DataSource = _CT_MucTMBCTaiChinhList;

            }
        }
    }
}
