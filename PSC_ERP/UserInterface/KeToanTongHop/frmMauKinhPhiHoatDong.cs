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
    public partial class frmMauKinhPhiHoatDong : Form
    {
        
        BCKQHoatDongKinhDoanhList _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.NewBCKQHoatDongKinhDoanhList();

        #region Contructors

        public frmMauKinhPhiHoatDong()
        {
            InitializeComponent();
            KhoiTao();
        }

        #endregion 

        #region Khởi Tạo
        private void KhoiTao()
        {
            //_BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList(6);
            //bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;

            //BCKQHoatDongKinhDoanhList _BCKQHoatDongKinhDoanhListComBo = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList(6);
            //BCKQHoatDongKinhDoanh _BCKQHoatDongKinhDoanh = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh();
            //_BCKQHoatDongKinhDoanh.TenMuc = "Không Chọn";
            //_BCKQHoatDongKinhDoanhListComBo.Insert(0, _BCKQHoatDongKinhDoanh);

            //bCKQHoatDongKinhDoanhListBindingSource1.DataSource = _BCKQHoatDongKinhDoanhListComBo;

            //HeThongTaiKhoan1 heThongTaiKhoan = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            //HeThongTaiKhoan1List _HeThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
            //_HeThongTaiKhoanList.Insert(0, heThongTaiKhoan);
            ////heThongTaiKhoan1ListBindingSource.DataSource = _HeThongTaiKhoanList;
        }
        #endregion

        #region Lưu Dữ Liệu

        private Boolean LuuDuLieu()
        {
            try
            {
                _BCKQHoatDongKinhDoanhList.ApplyEdit();
                _BCKQHoatDongKinhDoanhList.Save();
                //BangCanDoiKeToan bangCanDoiKeToan = BangCanDoiKeToan.NewBangCanDoiKeToan();
                bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;
               // _BCKQHoatDongKinhDoanhListComBo = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList();
                //_BCKQHoatDongKinhDoanhListComBo.Insert(0, bangCanDoiKeToan);
               // _BCKQHoatDongKinhDoanhListComBo = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList();
                //BCKQHoatDongKinhDoanhListBindingSource1.DataSource = _BCKQHoatDongKinhDoanhListComBo;
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

        private Boolean KiemTraDuLieu(BCKQHoatDongKinhDoanh bckqHoatDongKinhDoanh)
        {
            Boolean kq = true;
            if (bckqHoatDongKinhDoanh.MaSo == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaSo.Focus();
                kq = false;
            }
            else if (bckqHoatDongKinhDoanh.TenMuc == "")
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
            if (_BCKQHoatDongKinhDoanhList.Count == 0)
            {
                BCKQHoatDongKinhDoanh bckqHoatDongKinhDoanh = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh();
                bckqHoatDongKinhDoanh.LoaiBaoCao = 6;
                _BCKQHoatDongKinhDoanhList.Add(bckqHoatDongKinhDoanh);
                grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_BCKQHoatDongKinhDoanhList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    BCKQHoatDongKinhDoanh bckqHoatDongKinhDoanh = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh();
                    bckqHoatDongKinhDoanh.LoaiBaoCao = 6;
                    _BCKQHoatDongKinhDoanhList.Add(bckqHoatDongKinhDoanh);
                    grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_BCKQHoatDongKinhDoanhList.Count - 1];
                }
            }
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

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaSo"].Header.Caption = "Mã Mục";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaSo"].Header.VisiblePosition = 2;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaSo"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMuc"].Header.Caption = "Tên Mục";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMuc"].Header.VisiblePosition = 3;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMuc"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["ThuyetMinh"].Header.Caption = "TT Tính Toán";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["ThuyetMinh"].Header.VisiblePosition = 4;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["ThuyetMinh"].Hidden = false;            

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Loại";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.VisiblePosition = 5;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Hidden = false;


         
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
            //_BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList(6);
            //bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;        
        }
        #endregion 

      

    }
}