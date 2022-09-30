using System;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmBoPhan_CauHinhHeSo : Form
    {
        BoPhanList _boPhanList;
        BoPhan_CauHinhHeSoList _boPhan_CauHinhList;
        int userID = CurrentUser.Info.UserID;
        public frmBoPhan_CauHinhHeSo()
        {
            InitializeComponent();
        }

        private void frmBoPhan_CauHinhHeSo_Load(object sender, EventArgs e)
        {
            _boPhanList = BoPhanList.GetBoPhanListAll(userID);
            BindS_BoPhan.DataSource = _boPhanList;
            _boPhan_CauHinhList = BoPhan_CauHinhHeSoList.GetBoPhan_CauHinhHeSoList();
            this.bindingSource1.DataSource = _boPhan_CauHinhList;
        }

        private void grdu_LuanChuyen_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);          
            foreach (UltraGridColumn col in this.grdu_LuanChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = false;
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.Caption = "Bộ Phận";
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["MaBoPhan"].Width = cmbu_Bophan.Width;
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["MaBoPhan"].EditorComponent = cmbu_Bophan;
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.VisiblePosition = 0;

            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["HeSoBoSung"].Hidden = false;
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["HeSoBoSung"].Header.Caption = "Hệ Số Bổ Sung";
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["HeSoBoSung"].Header.VisiblePosition = 1;
        
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["HeSoBoSung"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Hidden = false;
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Header.Caption = "Hệ Số Độc Hại";
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Header.VisiblePosition = 2;
        
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["HeSoDocHai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["PhuCapHC"].Hidden = false;
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["PhuCapHC"].Header.Caption = "Phụ Cấp Hành Chính";
            grdu_LuanChuyen.DisplayLayout.Bands[0].Columns["PhuCapHC"].Header.VisiblePosition = 3;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            grdu_LuanChuyen.UpdateData();
            this.bindingSource1.EndEdit();
            _boPhan_CauHinhList.ApplyEdit();
            _boPhan_CauHinhList.Save();
            MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _boPhan_CauHinhList = BoPhan_CauHinhHeSoList.GetBoPhan_CauHinhHeSoList();
            this.bindingSource1.DataSource = _boPhan_CauHinhList;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_LuanChuyen.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _boPhan_CauHinhList = BoPhan_CauHinhHeSoList.GetBoPhan_CauHinhHeSoList();
            this.bindingSource1.DataSource = _boPhan_CauHinhList;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Bộ Phận";         
        }
    }
}
