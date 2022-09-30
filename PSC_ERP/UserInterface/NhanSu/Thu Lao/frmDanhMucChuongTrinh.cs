//111
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.Misc;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmDanhMucChuongTrinh : Form
    {
        #region Properties
        ChuongTrinhList _ChuongTrinhList;
        ChuongTrinhList _ChuongTrinhListCha;
        NguonList _nguonList;
        Util _Util = new Util();
        int hoanTat = 0;
        #endregion

        #region Events
        public frmDanhMucChuongTrinh()
        {
            InitializeComponent();            
            ChuongTrinhList_BindingSource.DataSource = typeof(ChuongTrinhList);
            _ChuongTrinhListCha = ChuongTrinhList.GetChuongTrinhList(true);        
            ChuongTrinhCha_BindingSource.DataSource = typeof(ChuongTrinhList);            
            this.bindingSource1_Nguon.DataSource = typeof(NguonList);
        }

        private void LayDuLieuLenLuoi()
        {
           _ChuongTrinhList = ChuongTrinhList.GetChuongTrinhList(hoanTat);
            ChuongTrinhList_BindingSource.DataSource = _ChuongTrinhList;

            _ChuongTrinhListCha = ChuongTrinhList.GetChuongTrinhList(true);
            ChuongTrinh itemCT = ChuongTrinh.NewChuongTrinh("Không Có");
            _ChuongTrinhListCha.Insert(0,itemCT);
            ChuongTrinhCha_BindingSource.DataSource = _ChuongTrinhListCha;
            _nguonList = NguonList.GetNguonList();
            Nguon _itemAdd = Nguon.NewNguon("Không Có");
            _nguonList.Insert(0, _itemAdd);
            this.bindingSource1_Nguon.DataSource = _nguonList;
            

            toolStripLabel1.Visible = false;
            toolStripSeparator4.Visible = false;

            tlslblIn.Visible = false;
            tlslblTim.Visible = false;

            tlslblXoa.Visible = false;
            toolStripSeparator3.Visible = false;
        }

     

        private void frmDanhMucChuongTrinh_Load(object sender, EventArgs e)
        {
             LayDuLieuLenLuoi();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
        }

        private void ultraGrid_TaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              //  ultraGrid_TaiKhoan.UpdateData();
            }
        }

        private void ultraGrid_TaiKhoan_Click(object sender, EventArgs e)
        {
          //  ultraGrid_TaiKhoan.Update();
        }

        private void ultraGrid_TaiKhoan_Leave(object sender, EventArgs e)
        {
            //ultraGrid_TaiKhoan.Update();
        }

        private void ultraGrid_TaiKhoan_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
           
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            ultraGrid_TaiKhoan.DeleteSelectedRows(); 
        }


        ChuongTrinh _ChongTrinh1;
     

        private void tlslblLuu_Click(object sender, EventArgs e)
        {   
            try
            {       
                ChuongTrinhList_BindingSource.EndEdit();
                ultraGrid_TaiKhoan.UpdateData();
                _ChuongTrinhList.ApplyEdit();
                _ChuongTrinhList.Save();
                MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ChuongTrinhList = ChuongTrinhList.GetChuongTrinhList(hoanTat);
                ChuongTrinhList_BindingSource.DataSource = _ChuongTrinhList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    
        #endregion

        #region InitializeLayout
        private void ultraGrid_TaiKhoan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {


            foreach (UltraGridColumn col in ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy; 
                col.Hidden = true;
            }

            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã Chương Trình";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaQL"].Width = 80;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 0;

            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 1;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 230;

            //ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["NgaySanXuat"].Hidden = false;
            //ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["NgaySanXuat"].Header.Caption = "Ngày Sản Xuất";
            //ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["NgaySanXuat"].Header.VisiblePosition = 2;
            //ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["NgaySanXuat"].Width = 80;

            //ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Hidden = false;
            //ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.Caption = "Ngày Kết Thúc";
            //ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.VisiblePosition = 3;
            //ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Width = 80;

            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 80;

            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaChuongTrinhCha"].Hidden = false;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaChuongTrinhCha"].EditorComponent = cbChuongTrinhCha;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaChuongTrinhCha"].Header.Caption = "Chương Trình Cha";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaChuongTrinhCha"].Header.VisiblePosition = 3;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaChuongTrinhCha"].Width = cbChuongTrinhCha.Width;

            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaNguon"].Hidden = false;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaNguon"].EditorComponent = cbNguon;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaNguon"].Header.Caption = "Nguồn";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaNguon"].Header.VisiblePosition = 4;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaNguon"].Width = cbNguon.Width;


            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["DungChung"].Hidden = false;           
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["DungChung"].Header.Caption = "Dùng Chung";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["DungChung"].Header.VisiblePosition = 5;

            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["HoanTat"].Hidden = false;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["HoanTat"].Header.Caption = "Hoàn Tất";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["HoanTat"].Header.VisiblePosition = 6;

            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["PhanTramThueTNCN"].Hidden = false;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["PhanTramThueTNCN"].Format="#,###";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["PhanTramThueTNCN"].Header.VisiblePosition = 7;
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
           
        }
              
       
        #endregion

        private void lbTaiKhoanCha_Click(object sender, EventArgs e)
        {

        }

        private void utxeditTenTaiKhoan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbu_ChucVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in cbChuongTrinhCha.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }            

             cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
             cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã Chương Trình";
             cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 0;
             cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["MaQL"].Width =100;
             cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
             cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
             cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 1;
             cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 240;

           
        }

        private void grbTTChiTietTaiKhoan_Enter(object sender, EventArgs e)
        {

        }

        private void rbChuaHoanTat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbChuaHoanTat.Checked == true)
                hoanTat = 0;
            _ChuongTrinhList = ChuongTrinhList.GetChuongTrinhList(hoanTat);
            ChuongTrinhList_BindingSource.DataSource = _ChuongTrinhList;
        }

        private void rbHoanTat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHoanTat.Checked == true)
                hoanTat = 1;
            _ChuongTrinhList = ChuongTrinhList.GetChuongTrinhList(hoanTat);
            ChuongTrinhList_BindingSource.DataSource = _ChuongTrinhList;
        }

        private void rbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTatCa.Checked == true)
                hoanTat = -1;
            _ChuongTrinhList = ChuongTrinhList.GetChuongTrinhList(hoanTat);
            ChuongTrinhList_BindingSource.DataSource = _ChuongTrinhList;
        }

      
    }
}