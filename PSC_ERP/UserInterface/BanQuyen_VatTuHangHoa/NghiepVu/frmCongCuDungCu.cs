using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmCongCuDungCu : DevExpress.XtraEditors.XtraForm
    {
        byte _tinhTrang = 0;
        CongCuDungCuList _congCuDungCuList = CongCuDungCuList.NewCongCuDungCuList();

        public byte TinhTrang
        {
            get { return _tinhTrang; }
        }

        public CongCuDungCuList CongCuDungCuList
        {
            get { return _congCuDungCuList; }
        }

        public frmCongCuDungCu()
        {
            InitializeComponent();
            KhoiTao();
        }

        #region KhoiTao()
        private void KhoiTao()
        {
            nhomHangHoaBQVTListBindingSource.DataSource = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTListTheoLoaiVatTu(3);
            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            ///
            HeThongTaiKhoan1List heThongTaiKhoanList1All = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            HeThongTaiKhoan1 tkKhongChon = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            tkKhongChon.SoHieuTK = "<<Không chọn>>";
            tkKhongChon.TenTaiKhoan = "<<Không chọn>>";
            heThongTaiKhoanList1All.Insert(0, tkKhongChon);
            heThongTaiKhoan1ListAllBindingSource.DataSource = heThongTaiKhoanList1All;

            ChonTaiKhoanMacDinh("153");
        }

        private void ChonTaiKhoanMacDinh(String soHieuTaiKhoanMacDinh)
        {
            cbTaiKhoan.EditValue = HeThongTaiKhoan1.LayMaTaiKhoan(soHieuTaiKhoanMacDinh);
            //if (string.IsNullOrEmpty(soHieuTaiKhoanMacDinh) == false)
            //{
            //    heThongTaiKhoan1ListAllBindingSource.MoveFirst();
            //    int i = 0;
            //    bool timDuoc = false;
            //    while (i < heThongTaiKhoan1ListAllBindingSource.Count)
            //    {
            //        if ((heThongTaiKhoan1ListAllBindingSource.Current as HeThongTaiKhoan1).SoHieuTK == soHieuTaiKhoanMacDinh)
            //        {
            //            this.cbTaiKhoan.EditValue = (heThongTaiKhoan1ListAllBindingSource.Current as HeThongTaiKhoan1).MaTaiKhoan;
            //            timDuoc = true;
            //            break;
            //        }
            //        else
            //        {
            //            i++;
            //            heThongTaiKhoan1ListAllBindingSource.MoveNext();
            //        }

            //    }
            //    if (timDuoc == false)
            //    {
            //        heThongTaiKhoan1ListAllBindingSource.MoveFirst();
            //    }
            //}
            
        }//end function
        #endregion

        #region lookUpEdit_NhomHangHoa_EditValueChanged
        private void lookUpEdit_NhomHangHoa_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_NhomHangHoa.EditValue != null && (int)lookUpEdit_NhomHangHoa.EditValue != 0)
            {
                hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTListByMaNhom((int)lookUpEdit_NhomHangHoa.EditValue);
                btnAddHangHoa.Enabled = true;
                btnAddHangHoa.ForeColor = Color.Red;
            }
            else
            {
                btnAddHangHoa.Enabled = false;
                btnAddHangHoa.ForeColor = Color.Gray;
            }
        }
        #endregion

        #region btnThemMoi_ItemClick
        //private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    XtraFrm_HangHoa frm = new XtraFrm_HangHoa();
        //    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
        //    {
        //        if (lookUpEdit_NhomHangHoa.EditValue != null)
        //            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList((int)lookUpEdit_NhomHangHoa.EditValue);
        //    }
        //}
        #endregion

        #region btnLuu_ItemClick
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            ////////////////////
            int maTaiKhoan = 0;
            if (cbTaiKhoan.EditValue != null) maTaiKhoan = (int)this.cbTaiKhoan.EditValue;
            _tinhTrang = 1;
            int soLuong = 0;
            int maCongCuDungCu;
            string MaQuanLy = "";
            int maBoPhan = 0;
            soLuong = Convert.ToInt16(txt_SoLuong.EditValue);
            Decimal tongTien = 0;
            tongTien = Convert.ToDecimal(txt_TongTien.EditValue);
            Decimal DonGia = 0;

            if (soLuong != 0)
                DonGia = Math.Round(tongTien / soLuong);

            if (lookUpEdit_PhongBan.EditValue != null)
            {
                maBoPhan = (int)lookUpEdit_PhongBan.EditValue;
            }

            if (gridLookUpEdit_HangHoa.EditValue != null && soLuong != 0)
            {
                HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT((int)gridLookUpEdit_HangHoa.EditValue);
                CongCuDungCu congCu = CongCuDungCu.GetCongCuDungCuByMaHangHoa(hangHoa.MaHangHoa);
                if (congCu.MaCongCuDungCu != 0)
                {
                    maCongCuDungCu = Convert.ToInt32(congCu.MaQuanLy.Substring(congCu.MaQuanLy.Length - 4)) + 1;

                }
                else
                {
                    maCongCuDungCu = 1;
                }
                for (int i = 0; i < soLuong; i++)
                {
                    if (maCongCuDungCu < 10)
                        MaQuanLy = hangHoa.MaQuanLy + "000" + maCongCuDungCu.ToString();
                    else if (maCongCuDungCu < 100)
                        MaQuanLy = hangHoa.MaQuanLy + "00" + maCongCuDungCu.ToString();
                    else if (maCongCuDungCu < 1000)
                        MaQuanLy = hangHoa.MaQuanLy + "0" + maCongCuDungCu.ToString();
                    else if (maCongCuDungCu < 10000)
                    {
                        MaQuanLy = hangHoa.MaQuanLy + maCongCuDungCu.ToString();
                    }
                    CongCuDungCu ccdc = CongCuDungCu.NewCongCuDungCu(MaQuanLy, txt_ViTri.Text, maBoPhan, hangHoa.MaHangHoa, DonGia, Convert.ToDateTime(dateEdit_NgayNha.EditValue), Convert.ToDecimal(txt_PhanTramPhanBo.EditValue));
                    ccdc.MaTaiKhoan = maTaiKhoan;
                    _congCuDungCuList.Add(ccdc);
                    maCongCuDungCu = maCongCuDungCu + 1;
                }
            }
            this.Close();
        }
        #endregion

        #region btnThoat_ItemClick
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _tinhTrang = 0;
            this.Close();
        }
        #endregion

        private void btnAddHangHoa_Click(object sender, EventArgs e)
        {
            if (lookUpEdit_NhomHangHoa.EditValue != null && (int)lookUpEdit_NhomHangHoa.EditValue != 0)
            {

                HangHoaBQ_VT hh = HangHoaBQ_VT.NewHangHoaBQ_VT();
                hh.MaNhomHangHoa = (int)lookUpEdit_NhomHangHoa.EditValue;
            XtraFrm_HangHoa frm = new XtraFrm_HangHoa(hh);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //if (lookUpEdit_NhomHangHoa.EditValue != null && (int)lookUpEdit_NhomHangHoa.EditValue !=0)
                    hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList((int)lookUpEdit_NhomHangHoa.EditValue);
            } 
            }
        }
    }
}