using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
//03    /04/2014
namespace PSC_ERP
{
    public partial class FrmLoadPhieuNhapBanQuyenBQList : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        PhieuNhapXuatBQList _phieuNhapList;
        CT_PhieuNhapBQList _ct_PhieuNhapList = CT_PhieuNhapBQList.NewCT_PhieuNhapList();
        CT_PhieuNhapBQList _ct_PhieuNhapListChon = CT_PhieuNhapBQList.NewCT_PhieuNhapList();
        PhieuNhapXuatBQList _phieuNhapListChon = PhieuNhapXuatBQList.NewPhieuNhapXuatList();
        PhieuNhapXuatBQ _phieuXuat;//Phieu xuat truyen tu Form Phieu Xuat

        int _hoanTat = -1;
        int _maCongTyCurrent = ERP_Library.Security.CurrentUser.Info.MaCongTy;

        public PhieuNhapXuatBQList PhieuNhapListChon
        {
            get { return _phieuNhapListChon; }

        }
        public CT_PhieuNhapBQList CT_PhieuNhapListChon
        {
            get { return _ct_PhieuNhapListChon; }

        }
        #endregion//Properties
        #region Functions
        void LockFieldsOfGrid()
        {
            colMaHangHoa.OptionsColumn.ReadOnly = true;
            colMaDonViTinh.OptionsColumn.ReadOnly = true;
            colThoiLuong.OptionsColumn.ReadOnly = true;
            colSoLuong.OptionsColumn.ReadOnly = true;
            colDonGia.OptionsColumn.ReadOnly = true;
            colThanhTien.OptionsColumn.ReadOnly = true;
            colSoLuongXuat.OptionsColumn.ReadOnly = true;
            colNgayNghiemThu.OptionsColumn.ReadOnly = true;
            colMaNguon.OptionsColumn.ReadOnly = true;
            colMaPhieuNhap.OptionsColumn.ReadOnly = true;
        }

        private void loadForm()
        {
            _phieuNhapList = PhieuNhapXuatBQList.GetPhieuNhapXuatList(_phieuXuat.MaKho, _phieuXuat.MaPhongBan, _phieuXuat.PhuongPhapNX, _phieuXuat.NgayNX);
            //
            foreach (PhieuNhapXuatBQ pn in _phieuNhapList)
            {
                foreach (CT_PhieuNhapBQ ct_pn in pn.CT_PhieuNhapList)
                {
                    if (ct_pn.SoLuong > ct_pn.SoLuongXuat)
                    {
                        _ct_PhieuNhapList.Add(ct_pn);
                    }
                }
            }
            //-->
            CT_PhieuNhapList_bindingSource.DataSource = _ct_PhieuNhapList;
            //
            phieuNhapAllList_bindingSource.DataSource = _phieuNhapList;
            DonViTinhList_bindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            NguonList_bindingSource.DataSource = NguonList.GetNguonList();//M

            chuongTrinh_NewListBindingSource.DataSource = ChuongTrinh_NewList.GetChuongTrinh_NewListAll(_hoanTat, _maCongTyCurrent); ;
            LockFieldsOfGrid();
        }
        
        #endregion //Functions
        public FrmLoadPhieuNhapBanQuyenBQList()
        {
            InitializeComponent();

        }
        public FrmLoadPhieuNhapBanQuyenBQList(PhieuNhapXuatBQ _px)
        {
            InitializeComponent();
            _phieuXuat = _px;
            phieuNhapAllList_bindingSource.DataSource = typeof(PhieuNhapXuatBQList);
            loadForm();

        }


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ////
            CT_PhieuNhapList_bindingSource.EndEdit();
            foreach (CT_PhieuNhapBQ _ctPN in _ct_PhieuNhapList)
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
            CT_PhieuNhapBQ ct_pn = (CT_PhieuNhapBQ)CT_PhieuNhapList_bindingSource.Current;
            CheckEdit check = (CheckEdit)sender;
            ct_pn.CheckChon = (bool)check.EditValue;

        }


    }
}