using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmMauKinhPhiHoatDongTheoKy : Form
    {


        MauKinhPhiHoatDongList _MauKinhPhiHoatDongList = MauKinhPhiHoatDongList.NewMauKinhPhiHoatDongList();

        #region Contructors

        public frmMauKinhPhiHoatDongTheoKy()
        {
            InitializeComponent();
            KhoiTao();
        }

        #endregion 

        #region Khởi Tạo
        private void KhoiTao()
        {
            //kyListBindingSource.DataSource = KyList.GetKyList();
            for (int i = 2009; i <= 2020; i++)
            {
                cb_Nam.Items.Add(i);
            }
            cb_Nam.Text = DateTime.Today.Year.ToString();
            mauKinhPhiHoatDongListBindingSource.DataSource = _MauKinhPhiHoatDongList;
        }
        #endregion

        #region Lưu Dữ Liệu

        private Boolean LuuDuLieu()
        {
            try
            {
                _MauKinhPhiHoatDongList.ApplyEdit();
                _MauKinhPhiHoatDongList.Save();
                mauKinhPhiHoatDongListBindingSource.DataSource = _MauKinhPhiHoatDongList;
       
            }
            catch
            {
                return false;
            }
            return true;

        }

        #endregion

        #region Kiểm tra dữ liệu

        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (txt_TenMucTK.Text == "")
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Mục", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenMucTK.Focus();
                kq = false;
            }
            return kq;
        }

        private Boolean KiemTraDuLieu(BaoCaoUocTinhDoanhThu baoCaoUocTinhDoanhThu)
        {
            Boolean kq = true;
           if (baoCaoUocTinhDoanhThu.TenMuc == "")
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Mục", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenMucTK.Focus();
                kq = false;
            }
            return kq;
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (LuuDuLieu() == true)
            {
                MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
           
        }
        #endregion 

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region grdu_DanhSachMuc_InitializeLayout
        private void grdu_DanhSachMuc_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdu_DanhSachMuc.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachMuc.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenChiTieu"].Header.Caption = "Chỉ Tiêu";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenChiTieu"].Header.VisiblePosition = 2;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenChiTieu"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CPKyTruocChuyenSang"].Header.Caption = "CP Kỳ Trước Chuyển Sang";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CPKyTruocChuyenSang"].Header.VisiblePosition = 3;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CPKyTruocChuyenSang"].Hidden = false;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CPKyTruocChuyenSang"].Format = "###,###,###";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CPKyTruocChuyenSang"].MaskInput = "nnn,nnn,nnn";

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoThucNhanKyNay"].Header.Caption = "Số Thực Nhận Kỳ Này";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoThucNhanKyNay"].Header.VisiblePosition = 4;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoThucNhanKyNay"].Hidden = false;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoThucNhanKyNay"].Format = "###,###,###";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoThucNhanKyNay"].MaskInput = "nnn,nnn,nnn";

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LuyKeTuDauNam"].Header.Caption = "Lũy Kế Từ Đầu Năm";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LuyKeTuDauNam"].Header.VisiblePosition = 5;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LuyKeTuDauNam"].Hidden = false;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LuyKeTuDauNam"].Format = "###,###,###";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LuyKeTuDauNam"].MaskInput = "nnn,nnn,nnn";

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoKPDaSuDungKyNay"].Header.Caption = "Số KP Đã Sử Dụng Kỳ Này";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoKPDaSuDungKyNay"].Header.VisiblePosition = 6;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoKPDaSuDungKyNay"].Hidden = false;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoKPDaSuDungKyNay"].Format = "###,###,###";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoKPDaSuDungKyNay"].MaskInput = "nnn,nnn,nnn";

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoKPLuyKeTuDauNam"].Header.Caption = "Số KP Lũy Kế Từ Đầu Năm";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoKPLuyKeTuDauNam"].Header.VisiblePosition = 7;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoKPLuyKeTuDauNam"].Hidden = false;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoKPLuyKeTuDauNam"].Format = "###,###,###";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoKPLuyKeTuDauNam"].MaskInput = "nnn,nnn,nnn";
                    
        }
        #endregion       

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_DanhSachMuc.DeleteSelectedRows();
        }
        #endregion 

        #region tlslblUndo_Click
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
           
        }
        #endregion 


        #region cbu_KyKetChuyen_ValueChanged
        private void cbu_KyKetChuyen_ValueChanged(object sender, EventArgs e)
        {

        }
        #endregion 

        #region bt_XemBaoCaoKy_Click
        private void bt_XemBaoCaoKy_Click(object sender, EventArgs e)
        {
            _MauKinhPhiHoatDongList = MauKinhPhiHoatDongList.GetMauKinhPhiHoatDongList(Convert.ToInt32(cb_Nam.Text));
            mauKinhPhiHoatDongListBindingSource.DataSource = _MauKinhPhiHoatDongList;
        }
        #endregion 

        #region cbu_KyKetChuyen_InitializeLayout
        //private void cbu_KyKetChuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        //{
        //    this.cbu_KyKetChuyen.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        //    this.cbu_KyKetChuyen.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
        //    foreach (UltraGridColumn col in this.cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns)
        //    {
        //        col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
        //        col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //        col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
        //        col.Hidden = true;
        //        //x =  //= System.Drawing.w;//RoyalBlue
        //    }
        //    cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Header.Caption = "Mã Kỳ";
        //    cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Header.VisiblePosition = 1;
        //    cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Hidden = false;

        //    cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
        //    cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 2;
        //    cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;

        //    cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.Caption = "Ngày Bắt Đầu";
        //    cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.VisiblePosition = 3;
        //    cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Hidden = false;

        //    cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.Caption = "Ngày Kết Thúc";
        //    cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.VisiblePosition = 4;
        //    cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Hidden = false;
        //}
        #endregion 

        private void ultraGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}