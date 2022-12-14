using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmBoQuiDoi : Form
    {
        #region Properties
        DonViTinhList _dvtList = DonViTinhList.NewDonViTinhList();
        DonViTinhList _dvcanList = DonViTinhList.NewDonViTinhList();
        QuyDoiDVTList _quidoiDVTList;// = QuyDoiDVTList.NewQuyDoiDVTList();
        Util util = new Util();
        #endregion

        #region Constructor
        public frmBoQuiDoi()
        {
            InitializeComponent();
            Khoitao();
        }
        #endregion

        #region Load du lieu
        public void Khoitao()
        {
            try
            {
                _dvtList = DonViTinhList.GetDonViTinh_QuiDoi();
                _dvcanList = DonViTinhList.GetDonViTinhList();
                _quidoiDVTList = QuyDoiDVTList.GetQuyDoiDVTList(0);
                quiDoiDVTListbindingSource.DataSource = _quidoiDVTList;
                donViTinhListbindingSource.DataSource = _dvtList;
                donViCanBindingSource.DataSource = _dvcanList;
                //cmbu_DonViTinh.DataSource = _dvtList;
                //cmbu_DonViCanQuiDoi.DataSource = _dvtList;
            }
            catch (ApplicationException ex)
            {
                //throw ex;
            }
        }
        #endregion

        #region cmbu_DonViTinh_InitializeLayout()
        private void cmbu_DonViTinh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            cmbu_DonViTinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            cmbu_DonViTinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["MaTinhTrang"].Hidden = true;

            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Đơn Vị Tính";
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 105;

            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Tên Đơn Vị Tính";
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 1;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Width = 170;

            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 148;
        }
        #endregion

        #region cmbu_DonViCanQuiDoi_InitializeLayout()
        private void cmbu_DonViCanQuiDoi_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            cmbu_DonViCanQuiDoi.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            cmbu_DonViCanQuiDoi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["MaTinhTrang"].Hidden = true;

            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Đơn Vị Qui Đổi";
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 110;

            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Tên Đơn Vị Qui Đổi";
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 1;
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Width = 170;

            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;
            cmbu_DonViCanQuiDoi.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 148;
        }
        #endregion

        #region grdu_BoQuiDoiDVT_InitializeLayout()
        private void grdu_BoQuiDoiDVT_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung ob = new HamDungChung();
            ob.ultragrdEmail_InitializeLayout(sender, e);
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["MaQuyDoiChuan"].Hidden = true;

            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["MaDVT1"].Header.Caption = "Đơn Vị Tính";
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["MaDVT1"].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["MaDVT1"].Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["MaDVT1"].Header.VisiblePosition = 0;
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["MaDVT1"].Width = 105;

            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["MaDVT2"].Header.Caption = "Đơn Vị Cần Qui Đổi";
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["MaDVT2"].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["MaDVT2"].Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["MaDVT2"].Header.VisiblePosition = 1;
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["MaDVT2"].Width = 170;

            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["QuyDoi12"].Header.Caption = "Tỷ Số Qui Đổi";
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["QuyDoi12"].MaskInput = "{LOC}nnn.nnnn";
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["QuyDoi12"].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["QuyDoi12"].Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["QuyDoi12"].Header.VisiblePosition = 2;
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["QuyDoi12"].Width = 148;
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["QuyDoi12"].CellAppearance.TextHAlign = HAlign.Right;
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["MaDVT1"].EditorComponent = cmbu_DonViTinh;
            grdu_BoQuiDoiDVT.DisplayLayout.Bands[0].Columns["MaDVT2"].EditorComponent = cmbu_DonViCanQuiDoi;
        }
        #endregion

        #region Form_Load()
        private void frmBoQuiDoi_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region tlslbl_Luu_Click()
        private void tlslbl_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                grdu_BoQuiDoiDVT.UpdateData();
                for (int i = 0; i < grdu_BoQuiDoiDVT.Rows.Count; i++)
                {
                    if ((Int32)grdu_BoQuiDoiDVT.Rows[i].Cells["MaDVT1"].Value == (Int32)grdu_BoQuiDoiDVT.Rows[i].Cells["MaDVT2"].Value && (Int32)grdu_BoQuiDoiDVT.Rows[i].Cells["MaDVT1"].Value !=0 && (Int32)grdu_BoQuiDoiDVT.Rows[i].Cells["MaDVT2"].Value!=0)
                    {
                        MessageBox.Show("Hai đơn vị cần quy đổi bị trùng! Vui lòng chọn đơn vị quy đổi khác.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        grdu_BoQuiDoiDVT.ActiveRow = grdu_BoQuiDoiDVT.Rows[i];
                        return;
                    }

                    for (int j = 0; j < grdu_BoQuiDoiDVT.Rows.Count; j++)
                    {
                        if (i != j)
                        {
                            if ((Int32)grdu_BoQuiDoiDVT.Rows[i].Cells["MaDVT1"].Value == (Int32)grdu_BoQuiDoiDVT.Rows[j].Cells["MaDVT1"].Value && (Int32)grdu_BoQuiDoiDVT.Rows[i].Cells["MaDVT2"].Value == (Int32)grdu_BoQuiDoiDVT.Rows[j].Cells["MaDVT2"].Value)
                            {
                                MessageBox.Show("Bộ Quy Đổi Này Đã Có Rồi!", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }                    
                }
                    _quidoiDVTList.ApplyEdit();
                _quidoiDVTList.Save();
                MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Khoitao();
            }
            catch (ApplicationException ex)
            {
                //MessageBox.Show(this, "Lưu thất bại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw ex;
            }
        }
        #endregion

        #region tlslbl_Xoa_Click()
        private void tlslbl_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdu_BoQuiDoiDVT.Selected.Rows.Count == 0)
                {
                    MessageBox.Show(this, util.chodongcanxoa, util.thaoTac, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                grdu_BoQuiDoiDVT.DeleteSelectedRows();
                tlslbl_Luu_Click(sender, e);
            }
            catch (ApplicationException ex)
            {
                //throw ex;
            }
        }
        #endregion

        #region tlslbl_TroLai_Click()
        private void tlslbl_TroLai_Click(object sender, EventArgs e)
        {
            Khoitao();
        }
        #endregion

        #region tlslbl_Thoat_Click()
        private void tlslbl_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                this.Close();
            return;
        }
        #endregion

        private void grdu_BoQuiDoiDVT_AfterRowUpdate(object sender, RowEventArgs e)
        {
            //for (int i = 0; i < grdu_BoQuiDoiDVT.Rows.Count; i++)
            //{
                if ((Int32)grdu_BoQuiDoiDVT.ActiveRow.Cells["MaDVT1"].Value == (Int32)grdu_BoQuiDoiDVT.ActiveRow.Cells["MaDVT2"].Value)
                {
                    MessageBox.Show("Hai đơn vị cần quy đổi bị trùng! Vui lòng chọn đơn vị quy đổi khác.","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            //}
        }

        private void frmBoQuiDoi_Leave(object sender, EventArgs e)
        {
            grdu_BoQuiDoiDVT.UpdateData();
        }

        private void grdu_BoQuiDoiDVT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
                grdu_BoQuiDoiDVT.UpdateData();            
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {

        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Bo Quy Doi", "Help_SanXuat.chm");
        }

        private void cmbu_DonViCanQuiDoi_AfterCloseUp(object sender, EventArgs e)
        {
            grdu_BoQuiDoiDVT.ActiveRow.Cells["MaDVT2"].Value = cmbu_DonViCanQuiDoi.Value;
            if ((Int32)grdu_BoQuiDoiDVT.ActiveRow.Cells["MaDVT1"].Value == (Int32)grdu_BoQuiDoiDVT.ActiveRow.Cells["MaDVT2"].Value)
            {
                MessageBox.Show("Hai đơn vị cần quy đổi bị trùng! Vui lòng chọn đơn vị quy đổi khác.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdu_BoQuiDoiDVT.ActiveCell.Activated = true;
                return;
            }
        }

        private void frmBoQuiDoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Bo Quy Doi", "Help_SanXuat.chm");
            }
        }

    }
}