using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmKhenThuongTapThe : Form
    {
        #region Khai Báo Biến
        
        KhenThuongTheoNhomList _KhenThuongTheoNhomList=KhenThuongTheoNhomList.NewKhenThuongTheoNhomList();
        KhenThuongTheoNhom _KhenThuongTheoNhom;
        HinhThucKhenThuongList _HinhThucKhenThuongList;
        DanhHieuList _DanhHieuList;
        CapQuyetDinhList _CapQuyetDinhList;
        long maNhanVien = 0;
        Util util = new Util();
        BoPhanList _BoPhanList;

        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        #endregion

        #region Constuctors
        public frmKhenThuongTapThe()
        {
            InitializeComponent();

           
            _HinhThucKhenThuongList = HinhThucKhenThuongList.GetHinhThucKhenThuongList();
            this.HinhThucKhenThuong_bindingSource.DataSource = _HinhThucKhenThuongList;
            _DanhHieuList = DanhHieuList.GetDanhHieuList();
            this.DanhHieu_bindingSource.DataSource = _DanhHieuList;
            _CapQuyetDinhList = CapQuyetDinhList.GetCapQuyetDinhList();
            this.bindingSource1_CapQuyetDinh.DataSource = _CapQuyetDinhList;
            _KhenThuongTheoNhomList = KhenThuongTheoNhomList.GetKhenThuongTheoNhomList();
            DanhSachKhenThuong_bindingSource.DataSource = _KhenThuongTheoNhomList;

        }

      
        #endregion

        #region Events
        private void LayDuLieu()
        {
            _KhenThuongTheoNhomList = KhenThuongTheoNhomList.GetKhenThuongTheoNhomList();
            DanhSachKhenThuong_bindingSource.DataSource = _KhenThuongTheoNhomList;

          

            tlslblThem.Enabled = true;
            tlslblLuu.Enabled = true;
            tlslblXoa.Enabled = true;
            tlslblIn.Enabled = true;
            tlslblUndo.Enabled = true;
        }

        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 0; i < grdu_KhenThuongTungNhanVien.Rows.Count; i++)
            {
                if (grdu_KhenThuongTungNhanVien.Rows[i].Cells["SoQuyetDinh"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Nhập Số Quyết Định", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_KhenThuongTungNhanVien.ActiveRow = grdu_KhenThuongTungNhanVien.Rows[i];
                    return kq;
                }
                if (grdu_KhenThuongTungNhanVien.Rows[i].Cells["MaCapQuyetDinh"].Text == "0")
                {
                    kq = false;
                    MessageBox.Show(this, "Chọn Cấp Quyết Định", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_KhenThuongTungNhanVien.ActiveRow = grdu_KhenThuongTungNhanVien.Rows[i];
                    return kq;
                }
                if (grdu_KhenThuongTungNhanVien.Rows[i].Cells["MaHinhThucKhenThuong"].Text == "0")
                {
                    kq = false;
                    MessageBox.Show(this, "Chọn Hình Thức Khen Thưởng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_KhenThuongTungNhanVien.ActiveRow = grdu_KhenThuongTungNhanVien.Rows[i];
                    return kq;
                }
                if (grdu_KhenThuongTungNhanVien.Rows[i].Cells["NguoiCapQiuyetDinh"].Text == "0")
                {
                    kq = false;
                    MessageBox.Show(this, "Nhập Người Ký Quyết Định", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_KhenThuongTungNhanVien.ActiveRow = grdu_KhenThuongTungNhanVien.Rows[i];
                    return kq;
                }
            }
            return kq;
        }

        private Boolean KiemTraMaQuanLy()
        {
            ////for (int i = 0; i < _KhenThuongTheoNhomList.Count; i++)
            ////{
            ////    for (int j = 0; j < _KhenThuongTheoNhomList.Count; j++)
            ////    {
            ////        if (i != j)
            ////        {
            ////            if (_KhenThuongTheoNhomList[i].SoQuyetDinh.Trim() == _KhenThuongTheoNhomList[j].SoQuyetDinh.Trim())
            ////            {
            ////                KhenThuongTheoNhom qg = KhenThuongTheoNhom.GetKhenThuongTheoNhom(_KhenThuongTheoNhomList[i].MaKhenThuong);
            ////                MessageBox.Show(this, "Số Quyết Định " + qg.SoQuyetDinh.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ////                grdu_KhenThuongTungNhanVien.ActiveRow = grdu_KhenThuongTungNhanVien.Rows[i + 1];
            ////                grdu_KhenThuongTungNhanVien.Focus();
            ////                return false;
            ////            }
            ////        }
            //  }
            //}
            return true;
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            _KhenThuongTheoNhom = KhenThuongTheoNhom.NewKhenThuongTheoNhom();
            _KhenThuongTheoNhomList.Add(_KhenThuongTheoNhom);
            DanhSachKhenThuong_bindingSource.DataSource = _KhenThuongTheoNhomList;
            grdu_KhenThuongTungNhanVien.ActiveRow = grdu_KhenThuongTungNhanVien.Rows[_KhenThuongTheoNhomList.Count - 1];
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_KhenThuongTungNhanVien.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grdu_KhenThuongTungNhanVien.DeleteSelectedRows();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.LayDuLieu();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
           
                        _KhenThuongTheoNhomList.ApplyEdit();
                        _KhenThuongTheoNhomList.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LayDuLieu();
                
            
          
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            frmTimNhanVien form = new frmTimNhanVien(10);
            if (form.ShowDialog(this) != DialogResult.OK)
            {

                maNhanVien=frmTimNhanVien.MaNhanVien;
                this.LayDuLieu();
              
            }
        }

        private void txtu_SoQuyetDinh_Leave(object sender, EventArgs e)
        {
            //foreach (UltraGridRow row in grdu_KhenThuongTungNhanVien.Rows)
            //{
            //    if (row.Cells["SoQuyetDinh"].Value.ToString().ToUpper() == txtu_SoQuyetDinh.Text.ToUpper())
            //    {
            //        MessageBox.Show("Quyết Định Này Đã Có Rồi !", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //        //txtu_SoQuyetDinh.Focus();
            //    }
            //}

        }
        #endregion

        #region grdu_KhenThuongTungNhanVien_InitializeLayout
        private void grdu_KhenThuongTungNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //_HinhThucKhenThuongList = HinhThucKhenThuongList.GetHinhThucKhenThuongList();
            //HinhThucKhenThuong_bindingSource.DataSource = _HinhThucKhenThuongList;

            //_DanhHieuList = DanhHieuList.GetDanhHieuList();
            //DanhHieu_bindingSource.DataSource = _DanhHieuList;

            //_CapQuyetDinhList = CapQuyetDinhList.GetCapQuyetDinhList();
            //CapQuyetDinh_bindingSource.DataSource = _CapQuyetDinhList;

          
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["MaHinhThucKhenThuong"].Hidden = true;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["MaDanhHieu"].Hidden = true;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["MaKhenThuong"].Hidden = true;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["MaCapQuyetDinh"].Hidden = true;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = true;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = true;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = true;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["TenCapQuyetDinh"].Hidden = true;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["NangLuongTruocHan"].Hidden = true;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["TenDanhHieu"].Header.Caption = "Danh Hiệu";
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["TenHinhThucKhenThuong"].Header.Caption = "Hình Thức Khen Thưởng";
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.Caption = "Số Quyết Định";
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["TenCapQuyetDinh"].Header.Caption = "Cấp Quyết Định";
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["NgayCapQuyetDinh"].Header.Caption = "Ngày Cấp";
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["NguoiCapQiuyetDinh"].Header.Caption = "Người Cấp";
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["NangLuongTruocHan"].Header.Caption = "Nâng lương(tháng)";
     
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 100;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;

            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["TenHinhThucKhenThuong"].Header.VisiblePosition = 1;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["TenDanhHieu"].Header.VisiblePosition = 2;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.VisiblePosition = 3;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["NangLuongTruocHan"].Header.VisiblePosition =4;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["TenCapQuyetDinh"].Header.VisiblePosition = 4;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["NgayCapQuyetDinh"].Header.VisiblePosition = 5;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["NguoiCapQiuyetDinh"].Header.VisiblePosition = 6;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["NangLuongTruocHan"].Header.VisiblePosition = 7;
            //grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 8;

            //foreach (UltraGridColumn col in grdu_KhenThuongTungNhanVien.DisplayLayout.Bands[0].Columns)
            //{
            //    col.SortIndicator = SortIndicator.Ascending;
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = Color.Navy;

            //    if (col.DataType.ToString() == "System.DateTime")
            //    {
            //        col.Format = "dd/MM/yyyy";
            //    }
            //}
            //this.grdu_KhenThuongTungNhanVien.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.grdu_KhenThuongTungNhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
      
        }
       #endregion

        private void frmKhenThuongTungNhanVien_Load(object sender, EventArgs e)
        {
            _BoPhanList = BoPhanList.GetBoPhanList();
            this.bindingSource1_BoPhan.DataSource = _BoPhanList;
        }
    }
}