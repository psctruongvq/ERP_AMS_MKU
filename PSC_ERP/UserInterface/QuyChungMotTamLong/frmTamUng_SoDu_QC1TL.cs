using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmTamUng_SoDu_QC1TL : Form
    {
        DoiTuongAllList _doiTuongAllList;
        TamUng_DauKy_QC1TLList _list;
        ChuongTrinhList _chuongTrinhList;
        public frmTamUng_SoDu_QC1TL()
        {
            InitializeComponent();
            this.bindingSource1_TamUng_SoDu.DataSource = typeof(TamUng_DauKy_QC1TLList);            
            this.bindingSource1_DoiTuong.DataSource = typeof(DoiTuongAllList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            for (int i = 2009; i <= 2020; i++)
            {
                cb_Nam.Items.Add(i);
            }
            cb_Nam.Text = DateTime.Today.Year.ToString();
        }
        private void frmTamUng_SoDu_QC1TL_Load(object sender, EventArgs e)
        {
            _list = TamUng_DauKy_QC1TLList.GetTamUng_DauKy_QC1TLList(Convert.ToInt32(cb_Nam.Text));
            this.bindingSource1_TamUng_SoDu.DataSource = _list;
            _doiTuongAllList = DoiTuongAllList.GetDoiTuongAllList_Tim_NhanVien("", ERP_Library.Security.CurrentUser.Info.MaCongTy);
            //_doiTuongAllList = DoiTuongAllList.GetDoiTuongAllList();
            this.bindingSource1_DoiTuong.DataSource = _doiTuongAllList;
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh itemAdd = ChuongTrinh.NewChuongTrinh("Không Có");
            _chuongTrinhList.Insert(0, itemAdd);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;
        }
   

        private void cbDoiTuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(grdData, "MaDoiTuong", "TenDoiTuong");
            foreach (UltraGridColumn col in this.cbDoiTuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Hidden = false;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "Tên Khách Hàng";
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 0;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Width = 250;

            cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 2;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Width = 250;

            cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Hidden = false;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.Caption = "Mã Quản Lý";
            cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.VisiblePosition = 1;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Width = 250;
        }


        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Header.Caption = "Tên Khách Hàng";            
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].EditorComponent = cbDoiTuong;
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Width = 200;

            grdData.DisplayLayout.Bands[0].Columns["SoDuChiDauKy"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoDuChiDauKy"].Header.Caption = "Số Dư Chi T.Ứng(NỢ)";
            grdData.DisplayLayout.Bands[0].Columns["SoDuChiDauKy"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["SoDuChiDauKy"].Format = "###,###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["SoDuChiDauKy"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdData.DisplayLayout.Bands[0].Columns["SoDuThuDauKy"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoDuThuDauKy"].Header.Caption = "Số Dư Hoàn T.Ứng(CÓ)";            
            grdData.DisplayLayout.Bands[0].Columns["SoDuThuDauKy"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["SoDuThuDauKy"].Format = "###,###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["SoDuThuDauKy"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
           
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].EditorComponent = cmbu_ChuongTrinh;
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Width = cmbu_ChuongTrinh.Width;
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.Caption = "Chương Trình";
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.VisiblePosition = 3;

            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";            
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 4;
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";

            grdData.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";            
            grdData.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 5;
            grdData.DisplayLayout.Bands[0].Columns["GhiChu"].Width=350;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            bindingSource1_TamUng_SoDu.EndEdit();
            grdData.UpdateData();
            _list.ApplyEdit();
            _list.Save();
            MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _list = TamUng_DauKy_QC1TLList.GetTamUng_DauKy_QC1TLList(Convert.ToInt32(cb_Nam.Text));
            this.bindingSource1_TamUng_SoDu.DataSource = _list;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(grdData,"MaChuongTrinh", "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = cmbu_ChuongTrinh.Width;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã QL";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _list = TamUng_DauKy_QC1TLList.GetTamUng_DauKy_QC1TLList(Convert.ToInt32(cb_Nam.Text));
            this.bindingSource1_TamUng_SoDu.DataSource = _list;
            _doiTuongAllList = DoiTuongAllList.GetDoiTuongAllList();
            this.bindingSource1_DoiTuong.DataSource = _doiTuongAllList;
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh itemAdd = ChuongTrinh.NewChuongTrinh("Không Có");
            _chuongTrinhList.Insert(0, itemAdd);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;
        }

       
    }
}
