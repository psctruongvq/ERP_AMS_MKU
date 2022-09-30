using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;


namespace PSC_ERP
{
    public partial class frmGopKhachHang : Form
    {      
        DoiTacList _DoiTacList;
        Util util = new Util();
        int _loai = 0;
        long _ma;

        #region load
        public frmGopKhachHang()
        {
            InitializeComponent();
            doiTacListBindingSource.DataSource = typeof(DoiTacList);
            KhoiTao();
        }
        public frmGopKhachHang(long ma, int loai)
        {
            InitializeComponent();
            _loai = loai; //tìm từ HD cầm đồ
            _ma = ma;
            tlslblLuu.Enabled = false;
            KhoiTao();
        }      

        public void KhoiTao()
        {           
            _DoiTacList = DoiTacList.GetDoiTacList(false);
           // DoiTuongAllList.GetDoiTuongAllList_Tim_NhanVien(txtu_DieuKienTim.Text, ERP_Library.Security.CurrentUser.Info.MaCongTy);
            doiTacListBindingSource.DataSource = _DoiTacList;
        }
        private void ultragrdDSKhachHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //tiêu đề Khách Hàng
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["LoaiDoiTac"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Khách Hàng";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";            
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Khách Hàng";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Dienthoai"].Header.Caption = "Điện Thoại";

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 2;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 3;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 4;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 5;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TinhTrang"].Header.VisiblePosition = 6;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 7;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Diachi"].Header.VisiblePosition = 8;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Dienthoai"].Header.VisiblePosition = 9;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns.Add("dungchinh", "Dùng Chính");
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["dungchinh"].DataType = typeof(bool);
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["dungchinh"].Header.VisiblePosition = 0;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["dungchinh"].Width = 30;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns.Add("loaibo", "Loại Bỏ");
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["loaibo"].DataType = typeof(bool);
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["loaibo"].Header.VisiblePosition = 1;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["loaibo"].Width = 30;

            //tiêu đề Điện Thoại _ Fax
            //grdu_DSKhachHang.DisplayLayout.Bands[5].Columns["MaChiTiet"].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[5].Columns["MaDoiTac"].Hidden = true;

            //tiêu đề Người Liên Lạc
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["MaNguoiLienLac"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["MaDoiTac"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["TenNguoiLienLac"].Header.Caption = "Tên Người Liên Lạc";
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["DienThoai"].Header.Caption = "Điện Thoại";
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["Email"].Header.Caption = "Email";

            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["TenNguoiLienLac"].Header.VisiblePosition = 0;
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["DienThoai"].Header.VisiblePosition = 1;
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["Email"].Header.VisiblePosition = 2;

            //tiêu đề Địa Chỉ
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["MaDiaChi"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["TenDiaChiChung"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["Active"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["TenDiaChi"].Header.Caption = "Địa Chỉ";
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["QuanHuyen"].Header.Caption = "Quận Huyện";
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["TinhTP"].Header.Caption = "Tỉnh / TP";
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["QuocGia"].Header.Caption = "Quốc Gia";

            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["TenDiaChi"].Header.VisiblePosition = 0;
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["QuanHuyen"].Header.VisiblePosition = 1;
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["TinhTP"].Header.VisiblePosition = 2;
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["QuocGia"].Header.VisiblePosition = 3;

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[1].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[2].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[3].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[4].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[5].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[6].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.grdu_DSKhachHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_DSKhachHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }    
        #endregion

        #region Event    
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            int d_dungchinh=0;
            long _makhchinh = 0;
            long _makhloaibo = 0;
            bool _hoantat = false;
            int Type_err = 0; // 0 ko loi , 1 click nhieu dung chinh, 2 vua co dungchinh vua co loai bo
            try
            {
                // kiem tra moi lan cap nhat chi lam cho mot khach hang
                grdu_DSKhachHang.UpdateData();
                for (int i = 0; i < grdu_DSKhachHang.Rows.Count; i++)
                {
                    if ((bool)grdu_DSKhachHang.Rows[i].Cells["dungchinh"].Value)
                    {
                        d_dungchinh++;
                        if (d_dungchinh > 1)
                            break;
                    }
                    if ((bool)grdu_DSKhachHang.Rows[i].Cells["dungchinh"].Value == true && (bool)grdu_DSKhachHang.Rows[i].Cells["Loaibo"].Value == true)
                    {
                        Type_err = 2;
                        break;
                    }

                }
                if (d_dungchinh > 1)
                    Type_err = 1;
                if (Type_err == 1)
                {
                    MessageBox.Show(this, "Mỗi lần chỉ cập nhật dữ liệu 01 khách hàng dùng chính.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Type_err == 2)
                {
                    MessageBox.Show(this, "Khách hàng dùng chính không được chọn loại bỏ.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // process
                for (int j = 0; j < grdu_DSKhachHang.Rows.Count; j++)
                {
                    if ((bool)grdu_DSKhachHang.Rows[j].Cells["dungchinh"].Value)
                    {
                        _makhchinh = (long)grdu_DSKhachHang.Rows[j].Cells["Madoitac"].Value;
                        break;
                    }
                }
                for (int k = 0; k < grdu_DSKhachHang.Rows.Count; k++)
                {
                    if ((bool)grdu_DSKhachHang.Rows[k].Cells["Loaibo"].Value)
                    {
                        _makhloaibo = (long)grdu_DSKhachHang.Rows[k].Cells["Madoitac"].Value;
                        if (DoiTac.GopKhachHang(_makhchinh, _makhloaibo))
                            _hoantat = true;
                    }
                }

                if (_hoantat)
                {
                    MessageBox.Show(this, "Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    for (int u = 0; u < grdu_DSKhachHang.Rows.Count; u++)
                    {
                        grdu_DSKhachHang.Rows[u].Cells["Loaibo"].Value = false;
                        grdu_DSKhachHang.Rows[u].Cells["dungchinh"].Value = false;
                    }
                    grdu_DSKhachHang.UpdateData();
                    _hoantat = false;
                }
                else
                {
                    _DoiTacList.ApplyEdit();
                    _DoiTacList.Save();
                    MessageBox.Show(this, "Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
          
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }      
        #endregion    

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DSKhachHang.ActiveRow != null)
                grdu_DSKhachHang.DeleteSelectedRows();
        }
    }
}
