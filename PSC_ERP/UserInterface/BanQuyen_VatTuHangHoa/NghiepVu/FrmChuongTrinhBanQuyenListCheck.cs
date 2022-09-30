using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
//Create 28/03/2013
namespace PSC_ERP
{
    public partial class FrmChuongTrinhBanQuyenListCheck : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        ChuongTrinhBanQuyenConList _chuongTrinhBanQuyenConList;
        ChuongTrinhBanQuyenConList _chuongTrinhBanQuyenConListChon = ChuongTrinhBanQuyenConList.NewChuongTrinhBanQuyenConList();
        PhieuNhapXuat _phieuXuat;//Phieu xuat truyen tu Form Phieu Xuat
        public ChuongTrinhBanQuyenConList ChuongTrinhBanQuyenConListChon
        {
            get { return _chuongTrinhBanQuyenConListChon; }

        }
        #endregion//Properties
        #region Functions
        void LockFieldsOfGrid()
        {
            colSoLuongTon.OptionsColumn.ReadOnly = true;
            colMaHopDong.OptionsColumn.ReadOnly = true;
            colThoiLuong.OptionsColumn.ReadOnly = true;
            colTenChuongTrinh.OptionsColumn.ReadOnly = true;
            colMaQLChuongTrinhCon.OptionsColumn.ReadOnly = true;
            colMaNguon.OptionsColumn.ReadOnly = true; 
        }

        private void loadForm()
        {
            _chuongTrinhBanQuyenConList = ChuongTrinhBanQuyenConList.GetChuongTrinhBanQuyenConList(_phieuXuat.MaPhieuNhapXuat,_phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.NgayNX);
            bs_ChuongTrinhConBanQuyenList.DataSource = _chuongTrinhBanQuyenConList;
            HopDongMuaBanList_BindingSource.DataSource = HopDongMuaBanList.GetHopDongMuaBanList(1, 0, 0);//M
            //HangHoaList_bindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
            //DonViTinhList_bindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            NguonList_bindingSource.DataSource = NguonList.GetNguonList();//M
            LockFieldsOfGrid();
        }
        
        #endregion //Functions
        public FrmChuongTrinhBanQuyenListCheck()
        {
            InitializeComponent();
            bs_ChuongTrinhConBanQuyenList.DataSource = typeof(ChuongTrinhBanQuyenConList);

        }
        public FrmChuongTrinhBanQuyenListCheck(PhieuNhapXuat _px)
        {
            InitializeComponent();
            _phieuXuat = _px;
            bs_ChuongTrinhConBanQuyenList.DataSource = typeof(ChuongTrinhBanQuyenConList);
            loadForm();

        }


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ////
            bs_ChuongTrinhConBanQuyenList.EndEdit();
            foreach (ChuongTrinhBanQuyenCon _ctbq in _chuongTrinhBanQuyenConList)
            {
                if (_ctbq.CheckChon == true)
                {
                    _chuongTrinhBanQuyenConListChon.Add(_ctbq);
                }
            }
            this.Close();
        }


        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            ChuongTrinhBanQuyenCon ctbq = (ChuongTrinhBanQuyenCon)bs_ChuongTrinhConBanQuyenList.Current;
            CheckEdit check = (CheckEdit)sender;
            ctbq.CheckChon = (bool)check.EditValue;

        }

        private void gridDanhChuongTrinhBanQuyen_Click(object sender, EventArgs e)
        {

        }


    }
}