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
    public partial class frmMucTMBCTaiChinh : Form
    {
        MucTMBCTaiChinhList _MucTMBCTaiChinhList = MucTMBCTaiChinhList.NewMucTMBCTaiChinhList();
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
                this.Text = "Mục Thuyết Minh Báo Cáo Tài Chính Của NHNN  theo " + _noidungThongTu;
            }
            else if (_isNHNN == 0)
            {
                this.Text = "Mục Thuyết Minh Báo Cáo Tài Chính Của Thông Tư  theo " + _noidungThongTu;
            }
        }

        private void HideShowbtnCopyBieuMau()
        {
            if (_MucTMBCTaiChinhList.Count == 0)
            {
                btnSaoChep.Visible = true;
            }
            else
            {
                btnSaoChep.Visible = false;
            }
        }

        private void LoadDaTabyThongTu()
        {
            _MucTMBCTaiChinhList = MucTMBCTaiChinhList.GetMucTMBCTaiChinhListbyMaThongTu(_maThongTu, _isNHNN);
            HideShowbtnCopyBieuMau();
        }

        #endregion//Funtions
        public frmMucTMBCTaiChinh()
        {
            InitializeComponent();
            KhoiTao();
        }

        public frmMucTMBCTaiChinh(byte thuocLoai, int maThongTu, string noidungthongtu)
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

        private void frmMucTMBCTaiChinh_Load(object sender, EventArgs e)
        {

        }

        #region Khởi Tao
        private void KhoiTao()
        {
            //_MucTMBCTaiChinhList = MucTMBCTaiChinhList.GetMucTMBCTaiChinhList();
            LoadDaTabyThongTu();
            mucTMBCTaiChinhListBindingSource.DataSource = _MucTMBCTaiChinhList;
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

        #region ultraGrid_MucTMBCTaiChinh_InitializeLayout
        private void ultraGrid_MucTMBCTaiChinh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.ultraGrid_MucTMBCTaiChinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraGrid_MucTMBCTaiChinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridBand band in this.ultraGrid_MucTMBCTaiChinh.DisplayLayout.Bands)
            {
                foreach (UltraGridColumn column in band.Columns)
                {
                    column.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    column.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    column.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                    column.Hidden = true;

                }
            }
            ultraGrid_MucTMBCTaiChinh.DisplayLayout.Bands[0].Columns["SoTT"].Header.Caption = "Số TT";
            ultraGrid_MucTMBCTaiChinh.DisplayLayout.Bands[0].Columns["SoTT"].Header.VisiblePosition = 1;
            ultraGrid_MucTMBCTaiChinh.DisplayLayout.Bands[0].Columns["SoTT"].Hidden = false;            

            ultraGrid_MucTMBCTaiChinh.DisplayLayout.Bands[0].Columns["TenMucCapMot"].Header.Caption = "Tên Mục";
            ultraGrid_MucTMBCTaiChinh.DisplayLayout.Bands[0].Columns["TenMucCapMot"].Header.VisiblePosition = 2;
            ultraGrid_MucTMBCTaiChinh.DisplayLayout.Bands[0].Columns["TenMucCapMot"].Hidden = false;

            ultraGrid_MucTMBCTaiChinh.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            ultraGrid_MucTMBCTaiChinh.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            ultraGrid_MucTMBCTaiChinh.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;            

            ultraGrid_MucTMBCTaiChinh.DisplayLayout.Bands[0].Columns["Vitri"].Header.Caption = "Vị Trí";
            ultraGrid_MucTMBCTaiChinh.DisplayLayout.Bands[0].Columns["Vitri"].Header.VisiblePosition = 4;
            ultraGrid_MucTMBCTaiChinh.DisplayLayout.Bands[0].Columns["Vitri"].Hidden = false;
                      
        }
        #endregion 

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (_MucTMBCTaiChinhList.Count == 0)
            {
                MucTMBCTaiChinh _MucTMBCTaiChinh = MucTMBCTaiChinh.NewMucTMBCTaiChinh();
                //
                _MucTMBCTaiChinh.MaThongTu = _maThongTu;
                _MucTMBCTaiChinh.isNHNN = _isNHNN;
                //
                _MucTMBCTaiChinhList.Add(_MucTMBCTaiChinh);
                ultraGrid_MucTMBCTaiChinh.ActiveRow = ultraGrid_MucTMBCTaiChinh.Rows[_MucTMBCTaiChinhList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    MucTMBCTaiChinh _MucTMBCTaiChinh = MucTMBCTaiChinh.NewMucTMBCTaiChinh();
                    //
                    _MucTMBCTaiChinh.MaThongTu = _maThongTu;
                    _MucTMBCTaiChinh.isNHNN = _isNHNN;
                    //
                    _MucTMBCTaiChinhList.Add(_MucTMBCTaiChinh);
                    ultraGrid_MucTMBCTaiChinh.ActiveRow = ultraGrid_MucTMBCTaiChinh.Rows[_MucTMBCTaiChinhList.Count - 1];
                }
            }
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            MucTMBCTaiChinh _MucTMBCTaiChinh;
            for (int i = 0; i < _MucTMBCTaiChinhList.Count; i++)
            {
                _MucTMBCTaiChinh = _MucTMBCTaiChinhList[i];
                if (_MucTMBCTaiChinh.TenMucCapMot == string.Empty)
                {
                    MessageBox.Show(this, util.nhaptenky, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraGrid_MucTMBCTaiChinh.ActiveRow = ultraGrid_MucTMBCTaiChinh.Rows[i];
                    txt_TenMuc.Focus();
                    return;
                }                
            }
           
            _MucTMBCTaiChinhList.ApplyEdit();
            _MucTMBCTaiChinhList.Save();
            MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
          
        }
        #endregion 

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultraGrid_MucTMBCTaiChinh.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn  Dòng Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else ultraGrid_MucTMBCTaiChinh.DeleteSelectedRows();
        }
        #endregion 

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        private void btnSaoChep_Click(object sender, EventArgs e)
        {
            frmXacNhanThongTuMauBaoCao frm = new frmXacNhanThongTuMauBaoCao(true);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                _MucTMBCTaiChinhList = MucTMBCTaiChinhList.NewMucTMBCTaiChinhList();
                MucTMBCTaiChinhList listForCopy = MucTMBCTaiChinhList.GetMucTMBCTaiChinhListbyMaThongTu(frm.MaThongTu, _isNHNN);
                foreach (MucTMBCTaiChinh bangCopy in listForCopy)
                {
                    MucTMBCTaiChinh mucTMBCTC = MucTMBCTaiChinh.NewMucTMBCTaiChinhChild(bangCopy);
                    mucTMBCTC.MaThongTu = _maThongTu;
                    mucTMBCTC.isNHNN = _isNHNN;
                    _MucTMBCTaiChinhList.Add(mucTMBCTC);
                }
                mucTMBCTaiChinhListBindingSource.DataSource = _MucTMBCTaiChinhList;

            }
        }
    }
}
