using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using PSC_ERP_Common;

namespace PSC_ERP
{
    public partial class frmDialogDSPhieuNhapCCDC : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        PhieuNhapXuatList _phieuNhapList;
        CT_PhieuNhapList _dsCT_PhieuNhapTrenLuoi = CT_PhieuNhapList.NewCT_PhieuNhapList();
        CT_PhieuNhapList _dsCT_PhieNhapDaChon = CT_PhieuNhapList.NewCT_PhieuNhapList();
        //PhieuNhapXuatList _phieuNhapListChon = PhieuNhapXuatList.NewPhieuNhapXuatList();
        //PhieuNhapXuat _phieuXuat;//Phieu xuat truyen tu Form Phieu Xuat
        int _maKho = 0;
        byte _phuongphapNX = 0;
        DateTime _ngayNhapXuat = DateTime.Now.Date;
        //public PhieuNhapXuatList DSPhieuNhapDaChon
        //{
        //    get { return _phieuNhapListChon; }

        //}
        public CT_PhieuNhapList DSChiTietPhieuNhapDaChon
        {
            get { return _dsCT_PhieNhapDaChon; }
        }
        #endregion//Properties

        private void LoadData()
        {
            //_phieuNhapList = PhieuNhapXuatList.GetDSPhieuNhapThangChuaXuatHetTheoMaKho(_maKho,_phuongphapNX);
            ////
            //foreach (PhieuNhapXuat pn in _phieuNhapList)
            //{
            //    foreach (CT_PhieuNhap ct_pn in pn.CT_PhieuNhapList)
            //    {
            //        if (ct_pn.SoLuong > ct_pn.SoLuongXuat)
            //        {
            //            _dsCT_PhieuNhapTrenLuoi.Add(ct_pn);
            //        }
            //    }
            //}
            _dsCT_PhieuNhapTrenLuoi = CT_PhieuNhapList.GetCT_PhieuNhapCCDCList_ForXuatDichDanh(_maKho, _phuongphapNX,_ngayNhapXuat);
            CT_PhieuNhapList_bindingSource.DataSource = _dsCT_PhieuNhapTrenLuoi;

            //phieuNhapList_bindingSource.DataSource = _phieuNhapList;

            HangHoaList_bindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);//chi lay hang hoa thuoc loai cong cu dung cu
            DonViTinhList_bindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            //NguonList_bindingSource.DataSource = NguonList.GetNguonList();//M
        }
        public frmDialogDSPhieuNhapCCDC()
        {
            InitializeComponent();
        }
        public frmDialogDSPhieuNhapCCDC(int maKho,byte phuongphapNX)
        {
            _maKho = maKho;
            _phuongphapNX = phuongphapNX;
            InitializeComponent();
            phieuNhapList_bindingSource.DataSource = typeof(PhieuNhapXuatList);
            LoadData();
        }

        public frmDialogDSPhieuNhapCCDC(PhieuNhapXuatCCDC phieuNhapXuatCCDC)
        {
            _maKho = phieuNhapXuatCCDC.MaKho;
            _phuongphapNX = phieuNhapXuatCCDC.PhuongPhapNX;
            _ngayNhapXuat = phieuNhapXuatCCDC.NgayNX;
            InitializeComponent();
            phieuNhapList_bindingSource.DataSource = typeof(PhieuNhapXuatList);
            LoadData();
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            ////
            CT_PhieuNhapList_bindingSource.EndEdit();
            foreach (CT_PhieuNhap ct in _dsCT_PhieuNhapTrenLuoi)
            {
                if (ct.CheckChon == true)
                {
                    _dsCT_PhieNhapDaChon.Add(ct);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            CT_PhieuNhap ct_pn = (CT_PhieuNhap)CT_PhieuNhapList_bindingSource.Current;
            CheckEdit check = (CheckEdit)sender;
            ct_pn.CheckChon = (bool)check.EditValue;
        }

        private void btn_Export_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridUtil.ExportToExcel(gridView: this.gridView2, showOpenFilePrompt: true);
        }

    }
}