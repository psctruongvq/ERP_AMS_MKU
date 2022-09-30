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
    public partial class frmTimKhachHang : Form
    {

        #region Properties
        DoiTuongAllList _DoiTuongAllList;
        public DoiTuongAll _DoiTuongAll = DoiTuongAll.NewDoiTuongAll(0);
        public long _maDoiTuong = 0;
        #endregion
        
        #region Events
        public frmTimKhachHang()
        {
            InitializeComponent();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            //if (frmCongNo.DoiTuongThu_Chi == 32) // chi tien cho khach hang di cong tac
            //{
            //    _DoiTuongAllList = DoiTuongAllList.GetDoiTuongAllList_Tim_NhanVien(txtu_DieuKienTim.Text);
            //    DSKhachHang_BindingSource.DataSource = _DoiTuongAllList;
            //}
            //else //(frmCongNo.DoiTuongThu_Chi == 0 || frmCongNo.DoiTuongThu_Chi == 2 || frmCongNo.DoiTuongThu_Chi == 3 || frmCongNo.DoiTuongThu_Chi == 4 || frmCongNo.DoiTuongThu_Chi == 5 || frmCongNo.DoiTuongThu_Chi == 7) // thu tien ban hang cho Khach hang, doi tac
            //{
            //    _DoiTuongAllList = DoiTuongAllList.GetDoiTuongAllList_Tim(txtu_DieuKienTim.Text);
            //    DSKhachHang_BindingSource.DataSource = _DoiTuongAllList;
            //}

            _DoiTuongAllList = DoiTuongAllList.GetDoiTuongAllList_Tim_NhanVien(txtu_DieuKienTim.Text, ERP_Library.Security.CurrentUser.Info.MaCongTy);
            DSKhachHang_BindingSource.DataSource = _DoiTuongAllList;
              
        }

        private void txtu_DieuKienTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                    _DoiTuongAllList = DoiTuongAllList.GetDoiTuongAllList_Tim_NhanVien(txtu_DieuKienTim.Text, ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    DSKhachHang_BindingSource.DataSource = _DoiTuongAllList;
               
            } 
        }

        private void grdu_DSKhachHang_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void grdu_DSKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((DoiTuongAll)(DSKhachHang_BindingSource.Current) != null)
                {
                    _DoiTuongAll = ((DoiTuongAll)(DSKhachHang_BindingSource.Current));
                    _maDoiTuong = _DoiTuongAll.MaDoiTuong;
                }

                this.Close();
            }
        }

        #endregion

        #region grdu_DSKhachHang_InitializeLayout
        private void grdu_DSKhachHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.Caption = "Mã Đối Tượng";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.VisiblePosition = 0;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Width = 70;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "Tên Đối Tượng";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 1;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Width = 267;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa chỉ";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 2;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DiaChi"].Width = 300;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 3;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 110;



            grdu_DSKhachHang.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_DSKhachHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        private void DSKhachHang_BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void grdu_DSKhachHang_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if ((DoiTuongAll)(DSKhachHang_BindingSource.Current) != null)
            {
                _DoiTuongAll = ((DoiTuongAll)(DSKhachHang_BindingSource.Current));
                _maDoiTuong = _DoiTuongAll.MaDoiTuong;
            }

            this.Close();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            frmKhachHang frmKhachHang = new frmKhachHang();
            if (frmKhachHang.ShowDialog(this) != DialogResult.OK)
            {

            }
        }
    }
}