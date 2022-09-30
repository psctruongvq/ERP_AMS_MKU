using System;
using System.Drawing;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmCapHoaDon : Form
    {
        int userID = CurrentUser.Info.UserID;
        CapPhatHoaDonList _capphathdlist;
        CapPhatHoaDonList _capphathdlistbophan;
        Util util = new Util();
        HamDungChung hdc = new HamDungChung();
        BoPhanList _bophanlist;
        DoiTacList _dtlist;
       int _mabophan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        public frmCapHoaDon()
        {
            InitializeComponent();         
            KhoiTao();
        }       
     
        public void KhoiTao()
        {
            _capphathdlistbophan = CapPhatHoaDonList.GetCapPhatHoaDonListMoiNhat(_mabophan);
            if (_capphathdlistbophan.Count == 0)
                lblthongbao.Text = "";
            else
                lblthongbao.Text = "Số được cấp sử dụng từ " + _capphathdlistbophan[0].TuSo.ToString() + " đến " + _capphathdlistbophan[0].DenSo.ToString() + " . Ký hiệu là  " + _capphathdlistbophan[0].KyHieu.ToString();

            _bophanlist = BoPhanList.GetBoPhanListAll(userID);
            BoPhan _bp = BoPhan.NewBoPhan(0, "<Trống>");
            _bophanlist.Insert(0, _bp);
            cmbu_KhachHang.DataSource = _dtlist;
            cbo_bophan.DataSource = _bophanlist;

            _dtlist = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "<Trống>");
            _dtlist.Insert(0, _DoiTac);
            cmbu_KhachHang.DataSource = _dtlist;

            cbo_bophan.DisplayMember = "TenBoPhan";
            cbo_bophan.ValueMember = "maBoPhan";

            cmbu_KhachHang.DisplayMember = "tendoitac";
            cmbu_KhachHang.ValueMember = "madoitac";
          
            _capphathdlist = CapPhatHoaDonList.GetCapPhatHoaDonList(_mabophan);
            bindscaphd.DataSource = _capphathdlist;
        }       
      
        private void tlslblThoat_Click(object sender, EventArgs e)
        {        
            this.Close();         
        }               
      
        private void tlslblLuu_Click(object sender, EventArgs e)
        
        {
            // kiem tra du lieu
            grdu_KyHan.UpdateData();
            for (int i = 0; i < grdu_KyHan.Rows.Count; i++)
            {
                if ((int)grdu_KyHan.Rows[i].Cells["Mabophanduoccap"].Value != 0 && (int)grdu_KyHan.Rows[i].Cells["madailyduoccap"].Value != 0)
                {
                    MessageBox.Show(this, "Dữ liệu không hợp lệ. Không được cấp cho bộ phận và đại lý", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            grdu_KyHan.UpdateData();
            _capphathdlist.ApplyEdit();
            _capphathdlist.Save();
            MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            KhoiTao();
        }            
       
        private void grdu_KyHan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            hdc.ultragrdEmail_InitializeLayout(sender, e);
            grdu_KyHan.DisplayLayout.Bands[0].Columns["id"].Hidden = true;
            grdu_KyHan.DisplayLayout.Bands[0].Columns["mabophancap"].Hidden = true;
            grdu_KyHan.DisplayLayout.Bands[0].Columns["tenbophancap"].Hidden = true;
            grdu_KyHan.DisplayLayout.Bands[0].Columns["tenBoPhanDuocCap"].Hidden = true;
            grdu_KyHan.DisplayLayout.Bands[0].Columns["tendailyDuocCap"].Hidden = true;
            grdu_KyHan.DisplayLayout.Bands[0].Columns["sudung"].Hidden = true;
            grdu_KyHan.DisplayLayout.Bands[0].Columns["KyHieu"].Header.Caption = "Ký Hiệu";
            grdu_KyHan.DisplayLayout.Bands[0].Columns["Tuso"].Header.Caption = "Từ Số";
            grdu_KyHan.DisplayLayout.Bands[0].Columns["Denso"].Header.Caption = "Đến Số";
            grdu_KyHan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

            grdu_KyHan.DisplayLayout.Bands[0].Columns["NgayCap"].Header.Caption = "Ghi Chú";
            grdu_KyHan.DisplayLayout.Bands[0].Columns["MaBoPhanDuocCap"].Header.Caption = "Bộ phận được cấp";
            grdu_KyHan.DisplayLayout.Bands[0].Columns["MaBoPhanDuocCap"].EditorComponent = cbo_bophan;
            grdu_KyHan.DisplayLayout.Bands[0].Columns["madailyduoccap"].Header.Caption = "Bộ phận được cấp";
            grdu_KyHan.DisplayLayout.Bands[0].Columns["madailyduoccap"].EditorComponent = cmbu_KhachHang;
        }

        private void cmbu_KhachHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(cmbu_KhachHang, "TenDoiTac");

            foreach (UltraGridColumn col in this.cmbu_KhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã KH";
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Width = 80;

            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoitac"].Hidden = false;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoitac"].Header.Caption = "Tên Khách Hàng";
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoitac"].Width = 150;
            
            this.cmbu_KhachHang.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;//appearance17;
            this.cmbu_KhachHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void cbo_bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(cbo_bophan, "tenbophan");
            foreach (UltraGridColumn col in this.cbo_bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }

            cbo_bophan.DisplayLayout.Bands[0].Columns["tenbophan"].Hidden = false;
            cbo_bophan.DisplayLayout.Bands[0].Columns["tenbophan"].Header.Caption = "Tên Khách Hàng";
            cbo_bophan.DisplayLayout.Bands[0].Columns["tenbophan"].Width = 150;            

            this.cbo_bophan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;//appearance17;
            this.cbo_bophan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }       
      
    }
}