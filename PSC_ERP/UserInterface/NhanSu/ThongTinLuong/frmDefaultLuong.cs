using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class frmDefaultLuong : Form
    {
        #region Properties
        ThongTinDefaultList _ThongTinDefaultList;
        ThongTinDefault _ThongTinDefault;
        Util _Util = new Util(); 
        #endregion

        #region Events
        public frmDefaultLuong()
        {
            InitializeComponent();
            LayDuLieu();
        }

        private void LayDuLieu()
        {
            _ThongTinDefaultList = ThongTinDefaultList.GetThongTinDefaultList();
            ThongTinLuong_BindingSource.DataSource = _ThongTinDefaultList;
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            try
            {
                _ThongTinDefault = ThongTinDefault.NewThongTinDefault();
                _ThongTinDefaultList.Add(_ThongTinDefault);
                ThongTinLuong_BindingSource.DataSource = _ThongTinDefaultList;
                grdu_DanhSachLuong.ActiveRow = grdu_DanhSachLuong.Rows[_ThongTinDefaultList.Count - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grdu_DanhSachLuong.UpdateData();
                _ThongTinDefaultList.ApplyEdit();
                _ThongTinDefaultList.Save();
                MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_DanhSachLuong.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void grdu_DanhSachLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns["Ma"].Hidden = true;

            grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns["TuNgay"].Header.Caption = "Từ Ngày";
            grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns["TuNgay"].Header.VisiblePosition = 0;
            grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns["TuNgay"].Width = 100;

            grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns["DenNgay"].Header.Caption = "Đến Ngày";
            grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns["DenNgay"].Header.VisiblePosition = 1;
            grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns["DenNgay"].Width = 100;

            grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns["LuongV1"].Header.Caption = "Lương Cơ Bản";
            grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns["LuongV1"].Header.VisiblePosition = 2;
            grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns["LuongV1"].Width = 140;

            grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns["LuongV2"].Header.Caption = "Lương Kinh Doanh";
            grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns["LuongV2"].Header.VisiblePosition = 3;
            grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns["LuongV2"].Width = 140;

            grdu_DanhSachLuong.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_DanhSachLuong.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_DanhSachLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn";
                    col.Format = "###,###,###,###,###";
                }
                if (col.DataType.ToString() == "System.Datetime")
                    col.MaskInput = "{LOC}dd/mm/yyyy";
            }                
        }
    }
}