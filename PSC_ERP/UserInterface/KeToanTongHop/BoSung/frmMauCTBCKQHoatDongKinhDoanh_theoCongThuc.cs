﻿using System;
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
    public partial class frmMauCTBCKQHoatDongKinhDoanh_theoCongThuc : Form
    {
        #region Properties
        private int _maCongThuc = 0;
        private byte _loaiBaoCao = 4;////Mau Bao Cáo KQHDKD Chi Tiết
        private bool _NewCopy = false;
        #endregion//Properties
        
        BCKQHoatDongKinhDoanhList _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.NewBCKQHoatDongKinhDoanhList();

        #region Contructors

        public frmMauCTBCKQHoatDongKinhDoanh_theoCongThuc(int maCongThuc)
        {
            InitializeComponent();
            _maCongThuc = maCongThuc;
            if (_maCongThuc != 0)
            {
                string noidungcongthuc = CongThucApDungKeToanTongHop.GetCongThucApDungKeToanTongHop(_maCongThuc).NoiDung;
                this.Text = noidungcongthuc;
            }
            else
            {
                this.Text = string.Format("{0}(Công Thức Cũ)", this.Text);
            }
            KhoiTao();
            FormatForm();
        }

        #endregion 

        #region Khởi Tạo
        private void KhoiTao()
        {
            _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhListByMaCongThuc(_loaiBaoCao, _maCongThuc);
            bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;            
            //_BCKQHoatDongKinhDoanhListComBo = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList();
            
            //BCKQHoatDongKinhDoanhListBindingSource1.DataSource = _BCKQHoatDongKinhDoanhListComBo;
            HeThongTaiKhoan1 heThongTaiKhoan = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            HeThongTaiKhoan1List _HeThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
            _HeThongTaiKhoanList.Insert(0, heThongTaiKhoan);
            //heThongTaiKhoan1ListBindingSource.DataSource = _HeThongTaiKhoanList;
        }
        #endregion

        #region FormatForm
        private void FormatForm()
        {
            if (_BCKQHoatDongKinhDoanhList.Count == 0)
                tlSbtnCopy.Visible = true;
            else
                tlSbtnCopy.Visible = false;
        }

        private void ReloadData()
        {
            _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhListByMaCongThuc(_loaiBaoCao, _maCongThuc);
            bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList; 
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
                if (_NewCopy)
                    BCKQHoatDongKinhDoanh.UpdateMaMucCha_MucLienQuanBCKQHoatDongKinhDoanhbyMaCongThuc(_loaiBaoCao, _maCongThuc);
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
                _NewCopy = false;//---
                ReloadData();
            }
            else
            {
                MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            FormatForm();
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (_BCKQHoatDongKinhDoanhList.Count == 0)
            {
                BCKQHoatDongKinhDoanh bckqHoatDongKinhDoanh = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh();
                bckqHoatDongKinhDoanh.LoaiBaoCao = 4;
                bckqHoatDongKinhDoanh.MaCongThuc = _maCongThuc;
                _BCKQHoatDongKinhDoanhList.Add(bckqHoatDongKinhDoanh);
                grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_BCKQHoatDongKinhDoanhList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    BCKQHoatDongKinhDoanh bckqHoatDongKinhDoanh = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh();
                    bckqHoatDongKinhDoanh.LoaiBaoCao = 4;
                    bckqHoatDongKinhDoanh.MaCongThuc = _maCongThuc;
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


            foreach (UltraGridColumn col in this.grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["SoHieu"].Header.Caption = "Tài Khoản";
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["SoHieu"].Header.VisiblePosition = 1;
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["SoHieu"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["CongTru"].Header.Caption = "Cộng Trừ";
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["CongTru"].Header.VisiblePosition = 4;
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["CongTru"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["NoCo"].Hidden = false;
         
        }
        #endregion 

        #region bt_ChiTiet_Click
        private void bt_ChiTiet_Click(object sender, EventArgs e)
        {
            frmCT_MauBangBaoCaoCTKQHDKD_theoCongThuc dlg = new frmCT_MauBangBaoCaoCTKQHDKD_theoCongThuc((BCKQHoatDongKinhDoanh)(bCKQHoatDongKinhDoanhListBindingSource.Current),_maCongThuc);
            if (dlg.ShowDialog() == DialogResult.OK)
            { 
            
            }
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
            _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhListByMaCongThuc(4,_maCongThuc);
            bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;        
        }
        #endregion 

        private void tlSbtnCopy_Click(object sender, EventArgs e)
        {
            frmXacNhanCongThucKeToanTongHop frm = new frmXacNhanCongThucKeToanTongHop(true,_loaiBaoCao);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                if (frm.XacNhan)
                {
                    _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.NewBCKQHoatDongKinhDoanhList();
                    BCKQHoatDongKinhDoanhList listForCopy = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhListByMaCongThuc(_loaiBaoCao, frm.MaCongThuc);
                    foreach (BCKQHoatDongKinhDoanh bangCopy in listForCopy)
                    {
                        BCKQHoatDongKinhDoanh ketqua = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanhChild(bangCopy, _loaiBaoCao, _maCongThuc);
                        _BCKQHoatDongKinhDoanhList.Add(ketqua);
                    }
                    bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;
                }
            }
            if (_BCKQHoatDongKinhDoanhList.Count > 1)
                _NewCopy = true;
        }

      

    }
}