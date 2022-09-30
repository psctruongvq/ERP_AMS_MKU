using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Csla;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmThongTinTaiNan_Tim : Form
    {
        Util util = new Util();  
        public int _maTaiNan = 0;
        ThongTinTaiNan _TTTainan;
        ThongTinTaiNanList _TTTaiNanList;
        LoaiTaiNanList _LoaiTNList;
        public frmThongTinTaiNan_Tim()
        {
            InitializeComponent();
            this.Load_Source();
        }

        #region Load
        private void grdu_ThongTinTainan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_ThongTinTainan.DisplayLayout.Bands[1].Hidden = true;

            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["MaTaiNan"].Hidden = true;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["MaNguyenNhanTaiNan"].Hidden = true;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["MaLoaiTaiNan"].Hidden = true;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["TrongHayNgoai"].Hidden = true;

            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["TenTaiNan"].Header.Caption = "Tên tai nạn";
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["NgayTaiNan"].Header.Caption = "Ngày tai nạn";            
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["TenLoaiTaiNan"].Header.Caption = "Loại tai nạn";
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["TenNguyenNhanTaiNan"].Header.Caption = "Nguyên nhân TN";
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["NoiTaiNan"].Header.Caption = "Nơi tai nạn";
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["ThietHai"].Header.Caption = "Thiệt hại(VNĐ)";
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["NgayLapBaoCao"].Header.Caption = "Ngày lập báo cáo";
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["MoTaTaiNan"].Header.Caption = "Mô tả tai nạn";
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["TenTaiNan"].Header.VisiblePosition = 0;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["NgayTaiNan"].Header.VisiblePosition = 1;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["TrongHayNgoai"].Header.VisiblePosition = 2;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["TenLoaiTaiNan"].Header.VisiblePosition = 3;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["TenNguyenNhanTaiNan"].Header.VisiblePosition = 4;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["NoiTaiNan"].Header.VisiblePosition = 5;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["MoTaTaiNan"].Header.VisiblePosition = 6;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["ThietHai"].Header.VisiblePosition = 7;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["NgayLapBaoCao"].Header.VisiblePosition = 8;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 9;

            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["NgayTaiNan"].CellActivation = Activation.NoEdit;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["TenLoaiTaiNan"].CellActivation = Activation.NoEdit;            
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["tenNguyenNhanTaiNan"].CellActivation = Activation.NoEdit;
            grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns["NgayLapBaoCao"].CellActivation = Activation.NoEdit;          
            

            grdu_ThongTinTainan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_ThongTinTainan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_ThongTinTainan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void frmThongTinTaiNan_Tim_Load(object sender, EventArgs e)
        {
            dtp_Denngay.Value = DateTime.Now;
            dtp_TuNgay.Value = Convert.ToDateTime(dtp_Denngay.Value).AddMonths(-6);
        }

        private void Load_Source()
        {
            _LoaiTNList = LoaiTaiNanList.GetLoaiTaiNanList();
            BindS_LoaiTN.DataSource = _LoaiTNList;

            if (cmbu_LoaiTainan_Tracuu.Value != null)
            {
                _TTTaiNanList = ThongTinTaiNanList.GetThongTinTaiNanList((int)cmbu_LoaiTainan_Tracuu.Value, Convert.ToDateTime(dtp_TuNgay.Value), Convert.ToDateTime(dtp_Denngay.Value));
                BindS_Tainan.DataSource = _TTTaiNanList;
            }
            else
            {
                _TTTaiNanList = ThongTinTaiNanList.GetThongTinTaiNanList(Convert.ToDateTime(dtp_TuNgay.Value), Convert.ToDateTime(dtp_Denngay.Value));
                BindS_Tainan.DataSource = _TTTaiNanList;
            }
        }
        #endregion  

        #region Event
        private void grdu_ThongTinTainan_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            _maTaiNan = ((ThongTinTaiNan)BindS_Tainan.Current).MaTaiNan;
            this.Close();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            _TTTaiNanList.ApplyEdit();
            _TTTaiNanList.Save();
            MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_ThongTinTainan.ActiveRow != null)
            {
                grdu_ThongTinTainan.DeleteSelectedRows();
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Source();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


    }
}