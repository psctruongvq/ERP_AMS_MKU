using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.Diagnostics;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
namespace PSC_ERP.UserInterface.NhanSu.TongHopThuLao
{
    public partial class frmTheoDoiPhieuChi : Form
    {
        #region
        ChiThuLaoTongHopList _chiThiLaoList = ChiThuLaoTongHopList.NewChiThuLaoTongHopList();
        Util util = new Util();

        #endregion



        #region BoSung
        private bool _theoDVCQ = false;

        private void FormatFormTheoKieu()
        {
            if(_theoDVCQ==true)
            {
                this.Text = "Theo Dõi Phiếu Chi Theo Đơn Vị Chủ Quản";
            }
            else
            {
                this.Text = "Theo Dõi Phiếu Chi";
            }
        }

        #region Constructors
        public void ShowTheoDoiPhieuChi()
        {
            _theoDVCQ = false;
            FormatFormTheoKieu();
            this.Show();
            
        }

        public void ShowTheoDoiPhieuChi_DVCQ()
        {
            _theoDVCQ = true;
            FormatFormTheoKieu();
            this.Show();
        }
        #endregion//Constructors

        #endregion//BoSung

        public frmTheoDoiPhieuChi()
        {
            InitializeComponent();
            this.ChiThuLao_BindingSource.DataSource = typeof(ChiThuLaoTongHopList);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = Convert.ToDateTime(dateTimePicker_TuNgay.Value);
            DateTime denNgay = Convert.ToDateTime(dateTimePicker_DenNgay.Value);
            int userID = ERP_Library.Security.CurrentUser.Info.UserID;
            //Lấy danh sách chi thù lao
            if(_theoDVCQ==true)
            {
                _chiThiLaoList = ChiThuLaoTongHopList.GetChiThuLaoListByNgayLap_TheoDoiChiThuLao_MaLoaiChi_DVCQ(userID, tuNgay, denNgay);   
            }
            else
            {
                //_chiThiLaoList = ChiThuLaoTongHopList.GetChiThuLaoListByNgayLap_TheoDoiChiThuLao(userID, tuNgay, denNgay);
                _chiThiLaoList = ChiThuLaoTongHopList.GetChiThuLaoListByNgayLap_TheoDoiChiThuLao_MaLoaiChi(userID, tuNgay, denNgay);  
            }
            ChiThuLao_BindingSource.DataSource = _chiThiLaoList;
            if (_chiThiLaoList.Count == 0)
            {
                MessageBox.Show(util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(gridViewDanhSachChiThuLao);
        }

        private void gridViewDanhSachChiThuLao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                col.Hidden = true;
            }
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 200;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoChungTu"].CellAppearance.TextHAlign = HAlign.Center;

            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Hidden = false;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.Caption = "Tên Chương Trình";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.VisiblePosition = 1;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Width = 200;

            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Hidden = false;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.Caption = "Bộ Phận Gửi";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.VisiblePosition = 2;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Width = 200;

            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Hidden = false;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.Caption = "Bộ Phận Nhận";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.VisiblePosition = 3;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Width = 200;

            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Chi";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 4;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 130;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].CellAppearance.TextHAlign = HAlign.Center;


            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 5;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = HAlign.Right;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###,###";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Width = 140;

            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienDaNhap"].Hidden = false;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienDaNhap"].Header.Caption = "Tiền NV";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienDaNhap"].Header.VisiblePosition = 6;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienDaNhap"].CellAppearance.TextHAlign = HAlign.Right;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienDaNhap"].Format = "###,###,###,###,###";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienDaNhap"].Width = 140;

            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienDaNhapNgoaiDai"].Hidden = false;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienDaNhapNgoaiDai"].Header.Caption = "Tiền CTV";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienDaNhapNgoaiDai"].Header.VisiblePosition = 7;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienDaNhapNgoaiDai"].CellAppearance.TextHAlign = HAlign.Right;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienDaNhapNgoaiDai"].Format = "###,###,###,###,###";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienDaNhapNgoaiDai"].Width = 140;

            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Tiền Còn Lại";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 8;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellAppearance.TextHAlign = HAlign.Right;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "###,###,###,###,###";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Width = 140;


            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["MaLoaiKinhPhi"].Hidden = false;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["MaLoaiKinhPhi"].Header.Caption = "Loại Chi";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["MaLoaiKinhPhi"].EditorComponent = cmbu_LoaiKinhPhi;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["MaLoaiKinhPhi"].Header.VisiblePosition = 9;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["MaLoaiKinhPhi"].Width = 150;

            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 10;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 100;

            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["HoanTat"].Hidden = false;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["HoanTat"].Header.Caption = "Hoàn Tất";
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["HoanTat"].Header.VisiblePosition = 11;
            gridViewDanhSachChiThuLao.DisplayLayout.Bands[0].Columns["HoanTat"].Width = 150;

        }
    }
}