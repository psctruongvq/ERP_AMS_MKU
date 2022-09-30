using System;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmDigitalFind : Form
    {
        public int maBophan = 0;
        public long maNhanVien = 0;
        public bool bNhanVien = true;
        public string soHoSo = string.Empty;
        BoPhanList _BoPhanList;
        int userID = CurrentUser.Info.UserID;
        public frmDigitalFind()
        {
            InitializeComponent();
            BindS_BoPhan.DataSource = typeof(BoPhanList);
        }

        private void cmbu_Bophan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
                maBophan = Convert.ToInt32(cmbu_Bophan.Value);
                cmbNhanVien.Value = null;
                cmbNhanVien.LoadDataByBoPhan(maBophan);
                cmbNhanVien.FilterByMaBoPhan(maBophan);
            }
        }

        private void frmDigitalFind_Load(object sender, EventArgs e)
        {
            _BoPhanList = BoPhanList.GetBoPhanListAll(userID);
            BindS_BoPhan.DataSource = _BoPhanList;

            //NhanVien_bindingSource.DataSource = NhanVienList.GetNhanVienList();
        }

        private void radNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (radNhanVien.Checked)
            {
                lblPhong.Enabled = true;
                lblNhanVien.Enabled = true;
                cmbNhanVien.Enabled = true;
                cmbu_Bophan.Enabled = true;
                txtu_SoHoSo.Enabled = false;
                bNhanVien = true;
            }
        }

        private void radSoHoSo_CheckedChanged(object sender, EventArgs e)
        {
            if (radSoHoSo.Checked)
            {
                lblPhong.Enabled = false;
                lblNhanVien.Enabled = false;
                cmbNhanVien.Enabled = false;
                cmbu_Bophan.Enabled = false;
                txtu_SoHoSo.Enabled = true;
                bNhanVien = false;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            if (cmbNhanVien.Value != null)
            {
                maNhanVien = Convert.ToInt32(cmbNhanVien.Value);
            }
        }

        private void txtu_SoHoSo_ValueChanged(object sender, EventArgs e)
        {
            soHoSo = txtu_SoHoSo.Text;
        }
    }
}
