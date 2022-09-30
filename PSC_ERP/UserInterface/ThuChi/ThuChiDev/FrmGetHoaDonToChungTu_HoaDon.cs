using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
//13/04/2013
namespace PSC_ERP
{
    public partial class FrmGetHoaDonToChungTu_HoaDon : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        HoaDonList _HoanDonListSelected = HoaDonList.NewHoaDonList();
        ChungTu _chungTu;//ChungTu truyen tu Form ChungTu

        public HoaDonList HoanDonListSelected
        {
            get { return _HoanDonListSelected; }

        }
        #endregion//Properties


        #region Initializes
        public FrmGetHoaDonToChungTu_HoaDon()
        {
            InitializeComponent();

        }
        public FrmGetHoaDonToChungTu_HoaDon(ChungTu ct)
        {
            InitializeComponent();
            _chungTu = ct;
            FormatForm();
            loadForm();

        }

        private void FormatForm()
        {
            if (_chungTu.LoaiChungTu.MaLoaiCTQuanLy == "PKT")
            {
                NewVAT_barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                NewNoVAT_barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                NewBanra_barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            }
            else if (_chungTu.LoaiChungTu.MaLoaiCTQuanLy == "PT111" || _chungTu.LoaiChungTu.MaLoaiCTQuanLy == "PT112")
            {
                NewVAT_barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                NewNoVAT_barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                NewBanra_barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else 
            {
                NewVAT_barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                NewNoVAT_barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                NewBanra_barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        #endregion Initializes


        #region Functions
        private void DesignGridViewHoaDon()
        {
            #region Design ChungTu_HoaDon
            HoaDonListgridControl.DataSource = DSHoaDonDichVu_BindingSource;

            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);


            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "Check", "NgayLap", "SoHoaDon", "SoSerial", "MauHoaDon", "KyHieuMauHoaDon", "TongTien", "ThueVAT", "MaQLDoiTac", "TenDoiTac" },
                                new string[] { "Chọn", "Ngày hóa đơn", "Số hóa đơn", "Số Serial", "Mẫu hóa đơn", "Ký hiệu", "Tổng Tiền", "Tiền Thuế", "Mã đối tượng", "Tên đối tượng" },
                                             new int[] { 80, 80, 100, 100, 90, 90, 100, 100, 90, 120 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Check", "NgayLap", "SoHoaDon", "SoSerial", "MauHoaDon", "KyHieuMauHoaDon", "TongTien", "ThueVAT", "MaQLDoiTac", "TenDoiTac" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien", "ThueVAT" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "TongTien", "ThueVAT" }, "{0:#,###.#}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "NgayLap", "SoHoaDon", "SoSerial", "MauHoaDon", "KyHieuMauHoaDon", "TongTien", "ThueVAT", "MaQLDoiTac", "TenDoiTac" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design ChungTu_HoaDon

        }

        private void loadForm()
        {
            DSHoaDonDichVu_BindingSource.DataSource = typeof(HoaDonList);
            // chi lay nhung hoa don cua nguoi lap chung tu
            _hoaDonList = HoaDonList.GetHoaDonLisForLapChungTu_HoaDon(_chungTu.LoaiChungTu.MaLoaiCT, _chungTu.DoiTuong);
            DSHoaDonDichVu_BindingSource.DataSource = _hoaDonList;
            DesignGridViewHoaDon();

        }
        #endregion Functions

        #region Events
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FocustextBox1.Focus();
            DSHoaDonDichVu_BindingSource.EndEdit();
            foreach (HoaDon hd in _hoaDonList)
            {
                if (hd.Check == true)
                {
                    HoaDon hdGetChild = HoaDon.GetHoaDon(hd.MaHoaDon);
                    _HoanDonListSelected.Add(hdGetChild);
                }
            }
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            HoaDon hd = (HoaDon)DSHoaDonDichVu_BindingSource.Current;
            CheckEdit check = (CheckEdit)sender;
            hd.Check = (bool)check.EditValue;

        }

        private void NewVAT_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_chungTu.DoiTuong, _chungTu.NgayLap, false,_chungTu);
            frmhoadondichvu.ShowDialog();
            _hoaDonList = HoaDonList.GetHoaDonLisForLapChungTu_HoaDon(_chungTu.LoaiChungTu.MaLoaiCT, _chungTu.DoiTuong);
            DSHoaDonDichVu_BindingSource.DataSource = _hoaDonList;
        }

        private void NewNoVAT_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_chungTu.DoiTuong, _chungTu.NgayLap, true, _chungTu);
            frmhoadondichvu.ShowDialog();
            _hoaDonList = HoaDonList.GetHoaDonLisForLapChungTu_HoaDon(_chungTu.LoaiChungTu.MaLoaiCT, _chungTu.DoiTuong);
            DSHoaDonDichVu_BindingSource.DataSource = _hoaDonList;
        }

        private void NewBanra_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmHoaDonDichVuBanRa frmhoadondichvu = new frmHoaDonDichVuBanRa(_chungTu.DoiTuong, 5, _chungTu.NgayLap);
            frmHoaDonDichVuBanRa frmhoadondichvu = new frmHoaDonDichVuBanRa(_chungTu.DoiTuong, 5, _chungTu.NgayLap, _chungTu);
            frmhoadondichvu.ShowDialog();
            _hoaDonList = HoaDonList.GetHoaDonLisForLapChungTu_HoaDon(_chungTu.LoaiChungTu.MaLoaiCT, _chungTu.DoiTuong);
            DSHoaDonDichVu_BindingSource.DataSource = _hoaDonList;
        }


        #endregion Events

        private void btnThemChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmChungTuMuaChuaThanhToan frm = new FrmChungTuMuaChuaThanhToan();
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowPhieuMuaChuaThanhToan();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            HoaDon hd = (HoaDon)DSHoaDonDichVu_BindingSource.Current;
            if (hd.LoaiHoaDon == 4)
            {
                HoaDon objHD = HoaDon.GetHoaDon(hd.MaHoaDon);
                frmHoaDonDichVuMuaVao frm = new frmHoaDonDichVuMuaVao(objHD);
                frm.ShowDialog();    
            }
        }





    }
}