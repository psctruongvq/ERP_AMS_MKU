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
    public partial class frmMauUocTinhDoanhThuChiPhiTheoKy : Form
    {
        
        
        BaoCaoUocTinhDoanhThuList _BaoCaoUocTinhDoanhThuList = BaoCaoUocTinhDoanhThuList.NewBaoCaoUocTinhDoanhThuList();

        #region Contructors

        public frmMauUocTinhDoanhThuChiPhiTheoKy()
        {
            InitializeComponent();
            KhoiTao();
        }

        #endregion 

        #region Khởi Tạo
        private void KhoiTao()
        {
            kyListBindingSource.DataSource = KyList.GetKyList();
            baoCaoUocTinhDoanhThuListBindingSource.DataSource = _BaoCaoUocTinhDoanhThuList;
        }
        #endregion

        #region Lưu Dữ Liệu

        private Boolean LuuDuLieu()
        {
            try
            {
                _BaoCaoUocTinhDoanhThuList.ApplyEdit();
                _BaoCaoUocTinhDoanhThuList.Save();       
                baoCaoUocTinhDoanhThuListBindingSource.DataSource = _BaoCaoUocTinhDoanhThuList;


       
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
            if (txt_MaSo.Text == "")
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaSo.Focus();
                kq = false;
            }
            else if (txt_TenMucTK.Text == "")
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
            if (baoCaoUocTinhDoanhThu.UocTinhDoanhThu == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Ước Tính Doanh Thu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaSo.Focus();
                kq = false;
            }
            else if (baoCaoUocTinhDoanhThu.TenMuc == "")
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

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoTT"].Header.Caption = "Số Thứ Tự";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoTT"].Header.VisiblePosition = 1;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoTT"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMuc"].Header.Caption = "Tên Mục";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMuc"].Header.VisiblePosition = 2;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMuc"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuThucTeKyTruoc"].Header.Caption = "DT Lũy Kế Kỳ Trước";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuThucTeKyTruoc"].Header.VisiblePosition = 3;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuThucTeKyTruoc"].Hidden = false;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuThucTeKyTruoc"].Format = "###,###,###";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuThucTeKyTruoc"].MaskInput = "nnn,nnn,nnn";

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["UocTinhDoanhThu"].Header.Caption = "Ước DT Đến Kỳ Này";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["UocTinhDoanhThu"].Header.VisiblePosition = 4;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["UocTinhDoanhThu"].Hidden = false;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["UocTinhDoanhThu"].Format = "###,###,###";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["UocTinhDoanhThu"].MaskInput = "nnn,nnn,nnn";

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuLuyKeKyNay"].Header.Caption = "DT Lũy Kế Kỳ Này";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuLuyKeKyNay"].Header.VisiblePosition = 5;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuLuyKeKyNay"].Hidden = false;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuLuyKeKyNay"].Format = "###,###,###";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuLuyKeKyNay"].MaskInput = "nnn,nnn,nnn";

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["KeHoachNam"].Header.Caption = "Kế Hoạch Năm";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["KeHoachNam"].Header.VisiblePosition = 6;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["KeHoachNam"].Hidden = false;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["KeHoachNam"].Format = "###,###,###";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["KeHoachNam"].MaskInput = "nnn,nnn,nnn";

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuLuyLeCungKyNamTruoc"].Header.Caption = "DT Cùng Kỳ Năm Trước";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuLuyLeCungKyNamTruoc"].Header.VisiblePosition = 7;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuLuyLeCungKyNamTruoc"].Hidden = false;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuLuyLeCungKyNamTruoc"].Format = "###,###,###";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["DoanhThuLuyLeCungKyNamTruoc"].MaskInput = "nnn,nnn,nnn";
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
            _BaoCaoUocTinhDoanhThuList = BaoCaoUocTinhDoanhThuList.GetBaoCaoUocTinhDoanhThuListByMaKy(Convert.ToInt32(cbu_KyKetChuyen.Value));
            baoCaoUocTinhDoanhThuListBindingSource.DataSource = _BaoCaoUocTinhDoanhThuList;
        }
        #endregion 

        private void cbu_KyKetChuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cbu_KyKetChuyen.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_KyKetChuyen.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Header.Caption = "Mã Kỳ";
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Header.VisiblePosition = 1;
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Hidden = false;

            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 2;
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;

            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.Caption = "Ngày Bắt Đầu";
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.VisiblePosition = 3;
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Hidden = false;

            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.Caption = "Ngày Kết Thúc";
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.VisiblePosition = 4;
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Hidden = false;
        }
    }
}