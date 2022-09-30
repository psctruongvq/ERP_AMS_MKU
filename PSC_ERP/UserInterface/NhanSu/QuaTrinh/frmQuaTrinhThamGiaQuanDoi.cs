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

namespace PSC_ERP
{
    public partial class frmQuaTrinhThamGiaQuanDoi : Form
    {
        #region Properties
        TenNhanVienList _TenNhanVienList;
        ChucVuList _ChucVuList;
        ThamGiaQuanDoi _ThamGiaQuanDoi;
        ThamGiaQuanDoiList _ThamGiaQuanDoiList;
        QuanHamList _QuanHamList;
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        Util util = new Util();
        #endregion

        #region Contructor
        public frmQuaTrinhThamGiaQuanDoi()
        {
            InitializeComponent();
            KhoiTao();

            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblXoa.Enabled = false;
            tlslblUndo.Enabled = false;
            
            tlslblIn.Visible = false;
            toolStripButton1.Visible = false;
        }

        public frmQuaTrinhThamGiaQuanDoi(ThongTinNhanVienTongHop thongTinNhanVienTongHop)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
        }

        #endregion

        #region KhoiTao
        private void KhoiTao()
        {
            _TenNhanVienList = TenNhanVienList.GetTenNhanVienList();
            tenNhanVienListBindingSource.DataSource = _TenNhanVienList;

            _ChucVuList = ChucVuList.GetChucVuList();
            chucVuListBindingSource.DataSource = _ChucVuList;

            _QuanHamList = QuanHamList.GetQuanHamList();
            quanHamListBindingSource.DataSource = _QuanHamList;
        }

        private void LayQuaTrinhTGQD()
        {
            _ThamGiaQuanDoiList = ThamGiaQuanDoiList.GetThamGiaQuanDoiList(_ThongTinNhanVienTongHop.MaNhanVien);
            thamGiaQuanDoiListBindingSource.DataSource = _ThamGiaQuanDoiList;
        }

        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            try
            {
                //MaNhanVien = Convert.ToInt64(txtu_MaNhanVien.Value);
                _ThamGiaQuanDoi = ThamGiaQuanDoi.NewThamGiaQuanDoi(_ThongTinNhanVienTongHop.MaNhanVien);
                _ThamGiaQuanDoiList.Add(_ThamGiaQuanDoi);
                thamGiaQuanDoiListBindingSource.DataSource = _ThamGiaQuanDoiList;
                grdu_QTTGQuanDoi.ActiveRow = grdu_QTTGQuanDoi.Rows[_ThamGiaQuanDoiList.Count - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (_ThamGiaQuanDoiList != null)
            {
                grdu_QTTGQuanDoi.UpdateData();
                _ThamGiaQuanDoiList.ApplyEdit();
                _ThamGiaQuanDoiList.Save();
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayQuaTrinhTGQD();
            }
            else
            {
                MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_QTTGQuanDoi.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdu_QTTGQuanDoi.DeleteSelectedRows();
        }
        #endregion

        #region cmbu_ChucVu_InitializeLayout
        private void cmbu_ChucVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["MaNhomChucVu"].Hidden = true;
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Hidden = true;

            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Header.Caption = "Mã Chức Vụ";
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";

            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 0;
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Header.VisiblePosition = 1;
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 2;
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_ChucVu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            this.cmbu_ChucVu.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_ChucVu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region grdu_QTTGQuanDoi_InitializeLayout
        private void grdu_QTTGQuanDoi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["MactQuatrinhtgqd"].Hidden = true;
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;                        
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = true;
            
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["TuNgay"].Header.Caption = "Ngày Nhập Ngũ";
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["MaQuanHam"].Header.Caption = "Quân Hàm";
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["MaChucVu"].Header.Caption = "Chức Vụ";
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["DenNgay"].Header.Caption = "Ngày Xuất Ngũ";
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["DonVi"].Header.Caption = "Đơn Vị";
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Loại";
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["CongViec"].Header.Caption = "Công Việc";

            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["TuNgay"].Header.VisiblePosition = 0;
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["MaQuanHam"].Header.VisiblePosition = 1;
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["MaChucVu"].Header.VisiblePosition = 2;
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["DenNgay"].Header.VisiblePosition = 3;
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["DonVi"].Header.VisiblePosition = 4;
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 5;
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["Loai"].Header.VisiblePosition = 6;
            grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns["CongViec"].Header.VisiblePosition = 7;

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_QTTGQuanDoi.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
            ////màu nền
            //this.grdu_QTTGQuanDoi.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.grdu_QTTGQuanDoi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region cmbu_QuanHam_InitializeLayout
        private void cmbu_QuanHam_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_QuanHam.DisplayLayout.Bands[0].Columns["MaQuanHam"].Hidden = true;
            cmbu_QuanHam.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quân Hàm";
            cmbu_QuanHam.DisplayLayout.Bands[0].Columns["TenQuanHam"].Header.Caption = "Tên Quân Hàm";

            cmbu_QuanHam.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            cmbu_QuanHam.DisplayLayout.Bands[0].Columns["TenQuanHam"].Header.VisiblePosition = 1;                        
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_QuanHam.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            ////màu nền
            //this.cmbu_QuanHam.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.cmbu_QuanHam.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            frmTimNhanVien _frmTimNhanVien = new frmTimNhanVien(18);
            if (_frmTimNhanVien.ShowDialog(this) != DialogResult.OK)
            {
                if (_ThongTinNhanVienTongHop != null)
                {
                    _ThamGiaQuanDoiList = ThamGiaQuanDoiList.GetThamGiaQuanDoiList(_ThongTinNhanVienTongHop.MaNhanVien);
                    thamGiaQuanDoiListBindingSource.DataSource = _ThamGiaQuanDoiList;

                    txtu_TenNhanVien.Text = _ThongTinNhanVienTongHop.TenNhanVien.ToString();
                    txtu_MaNhanVien.Value = _ThongTinNhanVienTongHop.MaNhanVien;
                    txtu_MaNhanVienQL.Text = _ThongTinNhanVienTongHop.MaQLNhanVien.ToString();

                    tlslblThem.Enabled = true;
                    tlslblLuu.Enabled = true;
                    tlslblUndo.Enabled = true;
                    tlslblXoa.Enabled = true;
                }
            }
        }
    }
}