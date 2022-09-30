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
    public partial class frmNgachLuongNoiBo : Form
    {
        #region Properties
        NhomNgachLuongBaoHiemList _nhomNgachLuongBaoHiemList;
        NgachLuongNoiBoList _NgachLuongNoiBoList;
        NgachLuongNoiBo _NgachLuongNoiBo;
        Util _Util = new Util();
        ChucVuList _ChucVuList;
        #endregion
        
        #region Events
        public frmNgachLuongNoiBo()
        {
            InitializeComponent();
        }

        private void LayDuLieuLenLuoi()
        {
            try
            {
                _ChucVuList = ChucVuList.GetChucVuListAll();
                this.BindS_ChucVu.DataSource = _ChucVuList;
                _nhomNgachLuongBaoHiemList = NhomNgachLuongBaoHiemList.GetNhomNgachLuongBaoHiemList();
                this.bindingSource1_NhomNgachLuongBH.DataSource = _nhomNgachLuongBaoHiemList;
                _NgachLuongNoiBoList = NgachLuongNoiBoList.GetNgachLuongNoiBoList();
                NgachLuongKinhDoanh_BindingSource.DataSource = _NgachLuongNoiBoList;
            }
            catch (ApplicationException)
            {

            }
        }

  
        private void frmNgachLuongKinhDoanh_Load(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
        }        

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
                
                    try
                    {
                        grdu_NgachLuongKinhDoanh.UpdateData();
                        _NgachLuongNoiBoList.ApplyEdit();
                        _NgachLuongNoiBoList.Save();
                        MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NgachLuongKinhDoanh_BindingSource.DataSource = _NgachLuongNoiBoList;
                    }
                    catch (ApplicationException)
                    {

                    }
                //}
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_NgachLuongKinhDoanh.DeleteSelectedRows();              
        }

      
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region grdu_NgachLuongKinhDoanh_InitializeLayout
        private void grdu_NgachLuongKinhDoanh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["MaNhomNgachLuongBaoHiem"].EditorComponent = cbNhomNgachLuong;
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["MaNhomNgachLuongBaoHiem"].Width = cbNhomNgachLuong.Width;
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["MaNhomNgachLuongBaoHiem"].Header.Caption = "Tên Nhóm Ngạch";
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["MaNhomNgachLuongBaoHiem"].Header.VisiblePosition = 0;

            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["MaNgachLuongNoiBo"].Hidden = true;
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã QL";
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 80;


       
           
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["TenNgachLuongBaoHiem"].Header.Caption = "Tên Ngạch";
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["TenNgachLuongBaoHiem"].Header.VisiblePosition = 2;
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["TenNgachLuongBaoHiem"].Width = 170;

            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["ThoiGianNangBac"].Header.Caption = "TG Nâng Bậc (tháng)";
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["ThoiGianNangBac"].Header.VisiblePosition = 3;
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["ThoiGianNangBac"].Width = 200;
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["DonViThoiGian"].Hidden = true;
            
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Ghi Chú";
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 4;
            grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 250;

             grdu_NgachLuongKinhDoanh.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_NgachLuongKinhDoanh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_NgachLuongKinhDoanh.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_NgachLuongKinhDoanh);
        }
    }
}