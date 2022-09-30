using System;
using DevExpress.XtraEditors;
using ERP_Library;
//13/04/2013
namespace PSC_ERP
{
    public partial class FrmLoadPhieuNhapList : XtraForm
    {
        #region Properties
        PhieuNhapXuatList _phieuNhapList;
        CT_PhieuNhapList _ct_PhieuNhapList = CT_PhieuNhapList.NewCT_PhieuNhapList();
        CT_PhieuNhapList _ct_PhieuNhapListChon = CT_PhieuNhapList.NewCT_PhieuNhapList();
        PhieuNhapXuatList _phieuNhapListChon = PhieuNhapXuatList.NewPhieuNhapXuatList();
        PhieuNhapXuat _phieuXuat;//Phieu xuat truyen tu Form Phieu Xuat
        public PhieuNhapXuatList PhieuNhapListChon
        {
            get { return _phieuNhapListChon; }
        }
        public CT_PhieuNhapList CT_PhieuNhapListChon
        {
            get { return _ct_PhieuNhapListChon; }
        }
        #endregion//Properties

        private void loadForm()
        {
            //_phieuNhapList = PhieuNhapXuatList.GetPhieuNhapXuatList(_phieuXuat.MaKho, _phieuXuat.NgayNX);
            //foreach (PhieuNhapXuat pn in _phieuNhapList)
            //{
            //    foreach (CT_PhieuNhap ct_pn in pn.CT_PhieuNhapList)
            //    {
            //        if (ct_pn.SoLuong > ct_pn.SoLuongXuat)
            //        {
            //            _ct_PhieuNhapList.Add(ct_pn);
            //        }
            //    }
            //}
            _ct_PhieuNhapList = CT_PhieuNhapList.GetCT_PhieuNhapList_ForXuatDichDanh(_phieuXuat.MaKho, _phieuXuat.NgayNX);
            //-->
            CT_PhieuNhapList_bindingSource.DataSource = _ct_PhieuNhapList;
            //
            phieuNhapAllList_bindingSource.DataSource = _phieuNhapList;
            //
            if (_phieuXuat.Loai == 1)
            {
                HangHoaList_bindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
                bdHangHoa_MaQuanLy.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
                colNgayNghiemThu.Visible = true;
            }
            else if (_phieuXuat.Loai == 2)
            {
                HangHoaList_bindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
                bdHangHoa_MaQuanLy.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
                colNgayNghiemThu.Visible = false;
            }
            else
            {
                HangHoaList_bindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
                bdHangHoa_MaQuanLy.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
                colNgayNghiemThu.Visible = false;
            }
            DonViTinhList_bindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            NguonList_bindingSource.DataSource = NguonList.GetNguonList();//M
        }
        public FrmLoadPhieuNhapList()
        {
            InitializeComponent();
        }
        public FrmLoadPhieuNhapList(PhieuNhapXuat _px)
        {
            InitializeComponent();
            _phieuXuat = _px;
            phieuNhapAllList_bindingSource.DataSource = typeof(PhieuNhapXuatList);
            loadForm();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////
            gridView2.RefreshData();
            CT_PhieuNhapList_bindingSource.EndEdit();
            foreach (CT_PhieuNhap _ctPN in _ct_PhieuNhapList)
            {
                if (_ctPN.CheckChon == true)
                {
                    _ct_PhieuNhapListChon.Add(_ctPN);
                }
            }
            this.Close();
        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            CT_PhieuNhap ct_pn = (CT_PhieuNhap)CT_PhieuNhapList_bindingSource.Current;
            CheckEdit check = (CheckEdit)sender;
            if (check.EditValue is bool)
                ct_pn.CheckChon = (bool)check.EditValue;

        }

        private void chkChonTatCa_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkChonTatCa.Checked == true)
            //{
            //    foreach (CT_PhieuNhap _ctPN in _ct_PhieuNhapList)
            //    {
            //        _ctPN.CheckChon = true;
            //    }
            //    CT_PhieuNhapList_bindingSource.DataSource = _ct_PhieuNhapList;
            //    gridView2.RefreshData();
            //}
            //else
            //{
            //    foreach (CT_PhieuNhap _ctPN in _ct_PhieuNhapList)
            //    {
            //        _ctPN.CheckChon = false;
            //    }
            //    CT_PhieuNhapList_bindingSource.DataSource = _ct_PhieuNhapList;
            //    gridView2.RefreshData();
            //}
            int i = 0;
            if (chkChonTatCa.Checked == true)
            {
                for (i = 0; i < gridView2.RowCount; i++)
                {
                    ((CT_PhieuNhap)gridView2.GetRow(i)).CheckChon = true;
                }
            }
            else
            {
                for (i = 0; i < gridView2.RowCount; i++)
                {
                    ((CT_PhieuNhap)gridView2.GetRow(i)).CheckChon = false;
                }
            }
            gridView2.RefreshData();
        }
    }
}