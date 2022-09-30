using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
namespace PSC_ERP
{
    public partial class frmChiPhiThucHien : Form
    {
        DoiTuongAllList _doiTuongAllList;
        public ChiPhiThucHienList _chiPhiThucHienList;
        LoaiChiPhiSanXuatChuongTrinhList _loaiChiPhiList;
        long maChungTu = 0;
        string tenChungTu = string.Empty;
        int maChuongTrinh = 0;
        string tenChuongTrinh = string.Empty;
        public bool IsSave = false;
        long maDoiTuong = 0;
        DateTime ngayLap = DateTime.Today.Date;
        decimal soTien = 0;
        string dienGiai = string.Empty;
        public static decimal SoTienDaNhap = 0;
        public decimal _soTienTongChiPhi=0;
        decimal _tongSoTienChiPhiSanXuatChuongTrinh = 0;
        public frmChiPhiThucHien()
        {
            InitializeComponent();
        }
        public frmChiPhiThucHien(ChiPhiThucHienList _chiPhiSanXuatList,long maChungTu, string soChungTu, int maChuongTrinh, string tenChuongTrinh, long  maDoiTuong,decimal soTien,DateTime ngayLap,string dienGiai)
        {
            this.maChungTu = maChungTu; this.tenChungTu = soChungTu; 
            this.maChuongTrinh = maChuongTrinh; 
            this.tenChuongTrinh = tenChuongTrinh;
            this.maDoiTuong = maDoiTuong;
            this.soTien = soTien;
            this.ngayLap = ngayLap;
            this.dienGiai = dienGiai;
            _tongSoTienChiPhiSanXuatChuongTrinh = soTien;
            InitializeComponent();
            _chiPhiThucHienList = _chiPhiSanXuatList;
            this.bdChiPhiThucHien.DataSource = _chiPhiThucHienList;
            _doiTuongAllList = DoiTuongAllList.GetDoiTuongAllList();
            this.bindingSource1_DoiTuong.DataSource = _doiTuongAllList;
            _loaiChiPhiList = LoaiChiPhiSanXuatChuongTrinhList.GetLoaiChiPhiSanXuatChuongTrinhList();
            //LoaiChiPhiSanXuatChuongTrinh itemAdd = LoaiChiPhiSanXuatChuongTrinh.NewLoaiChiPhiSanXuatChuongTrinh("Không có");
            //_loaiChiPhiList.Insert(0, itemAdd);
            this.bdLoaiChiPhiSanXuat.DataSource = _loaiChiPhiList;
            foreach (ChiPhiThucHien cp in _chiPhiSanXuatList)
            {
                _soTienTongChiPhi += cp.SoTien;
            }
        }
        private void frmChiPhiThucHien_Load(object sender, EventArgs e)
        {

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

        private void grdData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Width = cbDoiTuong.Width;
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].EditorComponent = cbDoiTuong;


            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Width = 180;

            grdData.DisplayLayout.Bands[0].Columns["MaLoaiChiPhiSanXuat"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiChiPhiSanXuat"].Header.Caption = "Loại Chi Phí";
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiChiPhiSanXuat"].Width = cbLoaiChiPhiSanXuat.Width;
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiChiPhiSanXuat"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiChiPhiSanXuat"].EditorComponent = cbLoaiChiPhiSanXuat;


            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 3;
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 180;

            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 4;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 250;

            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["SoTien"];
            SummarySettings summary2 = grdData.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.Left;
            summary2.DisplayFormat = "Tổng Tiền = {0:###,###,###,###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            grdData.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            _soTienTongChiPhi = 0;
            SoTienDaNhap = 0;
            bdChiPhiThucHien.EndEdit();
            grdData.UpdateData();
            foreach (ChiPhiThucHien cp in _chiPhiThucHienList)
            {
                if (cp.MaLoaiChiPhiSanXuat == 0)
                {
                    MessageBox.Show("Loại chi phí không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    IsSave = false;
                    return;

                }
                cp.MaChungTu = maChungTu; cp.TenChungTu = tenChungTu;
                cp.MaChuongTrinh = maChuongTrinh;
                cp.TenChuongTrinh = tenChuongTrinh;
                cp.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                SoTienDaNhap += cp.SoTien;
                _soTienTongChiPhi += cp.SoTien;
            }


            if (_soTienTongChiPhi > _tongSoTienChiPhiSanXuatChuongTrinh)
            {
                MessageBox.Show("Không đủ tiền để bổ chi phí thực hiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                IsSave = false;
                return;
            }

            IsSave = true;
            this.Close();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _chiPhiThucHienList = ChiPhiThucHienList.GetChiPhiThucHienListByChungTu(maChungTu);
            this.bdChiPhiThucHien.DataSource = _chiPhiThucHienList;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbLoaiChiPhiSanXuat_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbLoaiChiPhiSanXuat.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbLoaiChiPhiSanXuat.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbLoaiChiPhiSanXuat.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            cbLoaiChiPhiSanXuat.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 80;
            cbLoaiChiPhiSanXuat.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            cbLoaiChiPhiSanXuat.DisplayLayout.Bands[0].Columns["TenLoaiChiPhi"].Hidden = false;
            cbLoaiChiPhiSanXuat.DisplayLayout.Bands[0].Columns["TenLoaiChiPhi"].Header.Caption = "Tên Loại Chi Phí";
            cbLoaiChiPhiSanXuat.DisplayLayout.Bands[0].Columns["TenLoaiChiPhi"].Width = cbLoaiChiPhiSanXuat.Width;
            cbLoaiChiPhiSanXuat.DisplayLayout.Bands[0].Columns["TenLoaiChiPhi"].Header.VisiblePosition = 1;

            cbLoaiChiPhiSanXuat.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            cbLoaiChiPhiSanXuat.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            cbLoaiChiPhiSanXuat.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 100;
            cbLoaiChiPhiSanXuat.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 2;

        }

        private void grdData_AfterRowInsert(object sender, RowEventArgs e)
        {
            decimal soTienDaNhap = 0;
            decimal soTienChiThuLao = 0;

            soTienChiThuLao = frmChiThuLao.SoTienDaNhap;
            
            foreach (ChiPhiThucHien cp in _chiPhiThucHienList)
            {
                soTienDaNhap += cp.SoTien;
            }
            ((ChiPhiThucHien)bdChiPhiThucHien.Current).MaDoiTuong = maDoiTuong;
            ((ChiPhiThucHien)bdChiPhiThucHien.Current).SoTien = soTien-soTienDaNhap-soTienChiThuLao;
            ((ChiPhiThucHien)bdChiPhiThucHien.Current).NgayLap = ngayLap;
            ((ChiPhiThucHien)bdChiPhiThucHien.Current).DienGiai = dienGiai;
            ((ChiPhiThucHien)bdChiPhiThucHien.Current).MaLoaiChiPhiSanXuat = 1;
            e.Row.Update();
        }
    }
}
