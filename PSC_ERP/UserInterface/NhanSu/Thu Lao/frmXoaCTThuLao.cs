using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;
using ERP_Library;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmXoaCTThuLao : Form
    {
        KyList _kyList;
        BoPhanList _boPhanList;
        int userID = CurrentUser.Info.UserID;
        public frmXoaCTThuLao()
        {
            InitializeComponent();
            bindingSource_Ky.DataSource = typeof(KyList);
            BindS_BoPhan.DataSource = typeof(BoPhanList);
            _kyList = KyList.GetKyList();
            bindingSource_Ky.DataSource = _kyList;
            cmbu_KyLuong.DataSource = bindingSource_Ky;

            _boPhanList = BoPhanList.GetBoPhanListByUserID(userID);
            BindS_BoPhan.DataSource = _boPhanList;
            cmbu_Bophan.DataSource = BindS_BoPhan;

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_XoaDuLieuCTButToan";
                        cm.Parameters.AddWithValue("@MaKy", Convert.ToInt32(cmbu_KyLuong.Value));
                        cm.Parameters.AddWithValue("@MaBoPhan", Convert.ToInt32(cmbu_Bophan.Value));
                        cm.ExecuteNonQuery();
                    }
                }
                MessageBox.Show(this, "Đã thực hiện thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbu_KyLuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_KyLuong, "TenKy");
            foreach (UltraGridColumn col in this.cmbu_KyLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 0;
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["TenKy"].Width = cmbu_KyLuong.Width;
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["NgayBatDau"].Hidden = false;
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.Caption = "Ngày Bắt Đầu";
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.VisiblePosition = 1;

            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Hidden = false;
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.Caption = "Ngày Kết Thúc";
            cmbu_KyLuong.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.VisiblePosition = 2;
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 1;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;
        }
    }
}
