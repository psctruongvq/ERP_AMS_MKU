using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
//10/04/2013
namespace PSC_ERP
{
    public partial class FrmLoadPhieuNhapBanQuyenList : DevExpress.XtraEditors.XtraForm
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
            _phieuNhapList = PhieuNhapXuatList.GetPhieuNhapXuatList(_phieuXuat.MaKho, _phieuXuat.MaPhongBan, _phieuXuat.PhuongPhapNX,_phieuXuat.NgayNX);
            //
            foreach (PhieuNhapXuat pn in _phieuNhapList)
            {
                foreach (CT_PhieuNhap ct_pn in pn.CT_PhieuNhapList)
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
            //
            HangHoaList_bindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
            bs_ChuongTrinhConBanQuyenList.DataSource = ChuongTrinhBanQuyenConList.GetChuongTrinhBanQuyenConList();

            DonViTinhList_bindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            NguonList_bindingSource.DataSource = NguonList.GetNguonList();//M
            LockFieldsOfGrid();
        }
        
        #endregion //Functions
        public FrmLoadPhieuNhapBanQuyenList()
        {
            InitializeComponent();

        }
        public FrmLoadPhieuNhapBanQuyenList(PhieuNhapXuat _px)
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
            ct_pn.CheckChon = (bool)check.EditValue;

        }


    }
}