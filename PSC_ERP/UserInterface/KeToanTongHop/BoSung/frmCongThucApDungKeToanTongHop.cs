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
    public partial class frmCongThucApDungKeToanTongHop : Form
    {
        #region Properties
        #endregion//Properties

        CongThucApDungKeToanTongHopRootList _CongThucApDungKeToanTongHopList = CongThucApDungKeToanTongHopRootList.NewCongThucApDungKeToanTongHopRootList();

        #region Contructors

        public frmCongThucApDungKeToanTongHop()
        {
            InitializeComponent();
            KhoiTao();
        }

        #endregion

        #region Khởi Tạo
        private void KhoiTao()
        {
            _CongThucApDungKeToanTongHopList = CongThucApDungKeToanTongHopRootList.GetCongThucApDungKeToanTongHopRootList();
            CongThucApDungKeToanTongHopbindingSource.DataSource = _CongThucApDungKeToanTongHopList;

        }
        #endregion

        #region Lưu Dữ Liệu

        private Boolean LuuDuLieu()
        {
            try
            {
                _CongThucApDungKeToanTongHopList.ApplyEdit();
                _CongThucApDungKeToanTongHopList.Save();
                CongThucApDungKeToanTongHopbindingSource.DataSource = _CongThucApDungKeToanTongHopList;
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
            if (txt_NoiDung.Text == "")
            {
                MessageBox.Show(this, "Vui Lòng Nhập Nội Dung Công Thức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_NoiDung.Focus();
                kq = false;
            }
            else
            {
                byte loaimauOut = 0;
                if (!byte.TryParse(cmbLoaiMauBaoCao.Value.ToString(), out loaimauOut))
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Loại Mẫu Báo Cáo Cho Công Thức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbLoaiMauBaoCao.Focus();
                    kq = false;
                }
            }
            return kq;
        }

        private Boolean KiemTraDuLieu(CongThucApDungKeToanTongHop congthucapdungketoantonghop)
        {
            Boolean kq = true;
            if (congthucapdungketoantonghop.NoiDung == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Nội Dung Công Thức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_NoiDung.Focus();
                kq = false;
            }
            else if (congthucapdungketoantonghop.Loai == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Loại Mẫu Báo Cáo Cho Công Thức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLoaiMauBaoCao.Focus();
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
            if (_CongThucApDungKeToanTongHopList.Count == 0)
            {
                CongThucApDungKeToanTongHop congthuc = CongThucApDungKeToanTongHop.NewCongThucApDungKeToanTongHop();
                _CongThucApDungKeToanTongHopList.Add(congthuc);
                grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_CongThucApDungKeToanTongHopList.Count - 1];

            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    CongThucApDungKeToanTongHop congthuc = CongThucApDungKeToanTongHop.NewCongThucApDungKeToanTongHop();
                    _CongThucApDungKeToanTongHopList.Add(congthuc);
                    grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_CongThucApDungKeToanTongHopList.Count - 1];
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

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoiDung"].Header.Caption = "Số Thứ Tự";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoiDung"].Header.VisiblePosition = 1;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoiDung"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LoaiString"].Header.Caption = "Loại Mẫu Báo Cáo";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LoaiString"].Header.VisiblePosition = 2;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LoaiString"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NgayApDung"].Header.Caption = "Tên Mục";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NgayApDung"].Header.VisiblePosition = 3;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NgayApDung"].Hidden = false;

        }
        #endregion


        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_DanhSachMuc.DeleteSelectedRows();
        }
        #endregion



    }
}