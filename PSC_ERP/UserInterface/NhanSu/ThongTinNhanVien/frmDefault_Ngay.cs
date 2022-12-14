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
    public partial class frmDefault_Ngay : Form
    {
        Util util = new Util();
        Default_NgayList _Default_NgayList;

        public frmDefault_Ngay()
        {
            InitializeComponent();
            this.Load_Form();
        }

        private void Load_Form()
        {
            _Default_NgayList = Default_NgayList.GetDefault_NgayList();
            Default_bindingSource.DataSource = _Default_NgayList;
        }

        private void grdu_ToNhom_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["MaNgay"].Hidden = true;            
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["SoNgayPhepNamTrongNam"].Header.Caption = "Số ngày nghỉ phép năm";
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["NghiLonHonMayNgayTruLuong"].Header.Caption = "Số ngày nghỉ bị trừ lương";
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["PhanTramBHXH"].Header.Caption = "BHXH(%)";
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["PhanTramBHYT"].Header.Caption = "BHYT(%)";
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["PhanTramCongDoan"].Header.Caption = "Công Đoàn(%)";
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["TienDoan"].Header.Caption = "Tiền Đoàn";
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["TienDang"].Header.Caption = "Tiền Đảng";
            
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["SoNgayPhepNamTrongNam"].Header.VisiblePosition = 0;
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["PhanTramBHXH"].Header.VisiblePosition = 1;
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["PhanTramBHYT"].Header.VisiblePosition = 2;
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["PhanTramCongDoan"].Header.VisiblePosition = 3;
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["TienDoan"].Header.VisiblePosition = 4;
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["TienDang"].Header.VisiblePosition = 5;
            grdu_Default_Ngay.DisplayLayout.Bands[0].Columns["NghiLonHonMayNgayTruLuong"].Header.VisiblePosition = 6;

            //grdu_Default_Ngay.DisplayLayout.Bands[0].Columns[""].Width = 210;
            //grdu_Default_Ngay.DisplayLayout.Bands[0].Columns[""].Width = 180;
            //grdu_Default_Ngay.DisplayLayout.Bands[0].Columns[""].Width = 50;

        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                this.Close();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                
                _Default_NgayList.ApplyEdit();
                _Default_NgayList.Save();
                MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Load_Form();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw ex;
            }
        }
        
    }
}