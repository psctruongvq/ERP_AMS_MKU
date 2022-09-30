using System;
using System.Linq;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;

namespace PSC_ERP_Business.Main.Model
{
    public partial class tblTaiSanCoDinhCaBiet
    {
        
        public Boolean Chon { get; set; }
        tblTaiSanCoDinhCaBiet_PhongBan _phanBoDauTien_RefObj = null;
       
        private bool CongThue = ERP_Library.Security.CurrentUser.Info.CongThue;
      
        public tblTaiSanCoDinhCaBiet_PhongBan PhanBoDauTien_RefObj
        {
            get
            {
                if (_phanBoDauTien_RefObj == null)
                    _phanBoDauTien_RefObj = (from o in this.tblTaiSanCoDinhCaBiet_PhongBan
                                             orderby o.MaPhanBoSuDung ascending
                                             select o).FirstOrDefault();
                return _phanBoDauTien_RefObj;
            }
        }
        public Int32 MaBoPhanDauTien_RefObj
        {
            get
            {
                Int32 maBoPhan = 0;

                if (PhanBoDauTien_RefObj != null && PhanBoDauTien_RefObj.MaPhongBan != null)
                    maBoPhan = PhanBoDauTien_RefObj.MaPhongBan.Value;
                return maBoPhan;
            }
            set
            {
                if (TaiSanCoDinhCaBiet_Factory.KiemTraTSCDCaBietDaPhatSinhNghiepVuDieuChuyenNoiBo(this.MaTSCDCaBiet))
                {
                    DialogUtil.ShowError(string.Format("Không thể thay đổi bộ phận do tài sản [{0}] đã phát sinh nghiệp vụ điều chuyển nội bộ", this.SoHieu));
                }
                else
                {
                    _phanBoDauTien_RefObj.MaPhongBan = value;
                }
            }
        }
        public Int32 MaViTriDauTien_RefObj
        {
            get
            {
                Int32 maViTri = 0;
                if (PhanBoDauTien_RefObj != null && PhanBoDauTien_RefObj.MaViTri != null)
                    maViTri = PhanBoDauTien_RefObj.MaViTri.Value;
                return maViTri;
            }
            set
            {
                if (TaiSanCoDinhCaBiet_Factory.KiemTraTSCDCaBietDaPhatSinhNghiepVuDieuChuyenNoiBo(this.MaTSCDCaBiet))
                {
                    DialogUtil.ShowError(string.Format("Không thể thay đổi vị trí do tài sản [{0}] đã phát sinh nghiệp vụ điều chuyển nội bộ!\nVui lòng thực hiện nghiệp vụ điều chuyển nội bộ nếu muốn thay đổi vị trí!", this.SoHieu));
                }
                else
                {
                    _phanBoDauTien_RefObj.MaViTri = value;
                }
            }
        }
        tblTaiSanCoDinhCaBiet_PhongBan _phanBoSauCung_RefObj = null;
        public tblTaiSanCoDinhCaBiet_PhongBan PhanBoSauCung_RefObj
        {
            get
            {
                if (_phanBoSauCung_RefObj == null)
                    _phanBoSauCung_RefObj = TaiSanCoDinhCaBiet_PhongBan_Factory.New().Get_PhanBoSauCung_ByMaTSCDCaBiet(this.MaTSCDCaBiet);
                return _phanBoSauCung_RefObj;
            }
        }

        //bổ sung ngày 04/04/2016
        tblSerialTaiSanCoDinhCaBiet _seriaDauTien_RefObj = null;
        public tblSerialTaiSanCoDinhCaBiet SeriaDauTien_RefObj
        {
            get
            {
                if (_seriaDauTien_RefObj == null)
                    _seriaDauTien_RefObj = (from o in this.tblSerialTaiSanCoDinhCaBiets
                                             orderby o.ID ascending
                                             select o).FirstOrDefault();
                return _seriaDauTien_RefObj;
            }
        }

        tblSerialTaiSanCoDinhCaBiet _seriaSauCung_RefObj = null;
        public tblSerialTaiSanCoDinhCaBiet SeriaSauCung_RefObj
        {
            get
            {
                if (_seriaSauCung_RefObj == null)
                    _seriaSauCung_RefObj = SerialTaiSanCoDinhCaBiet_Factory.New().Get_SerialSauCung_ByMaTSCDCaBiet(this.MaTSCDCaBiet);
                return _seriaSauCung_RefObj;
            }
        }

        //
        //Boolean _pauseDonGia = false;
        partial void On_NguyenGiaMua_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {

            //tblChiTietNguyenGiaTSCD chiTietNguyenGiaDauTienCuaTSCaBiet = (from o in this.tblChiTietNguyenGiaTSCDs
            //                                                              orderby o.MaChiTiet ascending
            //                                                              select o).FirstOrDefault();
            //if (chiTietNguyenGiaDauTienCuaTSCaBiet != null)
            //{
            //    //cập nhật lại số tiền của chi tiết nguyên giá đầu tiên của tài sản
            //    chiTietNguyenGiaDauTienCuaTSCaBiet.SoTien = (this.NguyenGiaMua == null ? 0 : this.NguyenGiaMua.Value);
            //}

            ////cập nhật đơn giá = nguyên giá - chi phí
            //if (oldValue != null && currentValue != oldValue && currentValue!=0)
            //{
            //    //this.DonGia = (this.NguyenGiaMua == null ? 0 : this.NguyenGiaMua.Value) - (this.ChiPhi == null ? 0 : this.ChiPhi.Value) - (this.TienThue == null ? 0 : this.TienThue.Value);
            //    this.NguyenGiaConLai = (this.NguyenGiaMua == null ? 0 : this.NguyenGiaMua.Value) - (this.LuyKeKhauHao == null ? 0 : this.LuyKeKhauHao.Value);
            //}
        }

        partial void On_NguyenGiaTinhKhauHao_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            //tblChiTietNguyenGiaTSCD chiTietNguyenGiaDauTienCuaTSCaBiet = (from o in this.tblChiTietNguyenGiaTSCDs
            //                                                              orderby o.MaChiTiet ascending
            //                                                              select o).FirstOrDefault();
            //if (chiTietNguyenGiaDauTienCuaTSCaBiet != null)
            //{
            //    //cập nhật lại số tiền của chi tiết nguyên giá đầu tiên của tài sản
            //    chiTietNguyenGiaDauTienCuaTSCaBiet.SoTien = (this.NguyenGiaTinhKhauHao == null ? 0 : this.NguyenGiaTinhKhauHao.Value);
            //}

            ////cập nhật đơn giá = nguyên giá - chi phí
            //if (oldValue != null && currentValue != oldValue && currentValue != 0)
            //{
            //    //this.DonGia = (this.NguyenGiaMua == null ? 0 : this.NguyenGiaMua.Value) - (this.ChiPhi == null ? 0 : this.ChiPhi.Value) - (this.TienThue == null ? 0 : this.TienThue.Value);
            //    this.NguyenGiaConLai = (this.NguyenGiaTinhKhauHao == null ? 0 : this.NguyenGiaTinhKhauHao.Value) - (this.LuyKeKhauHao == null ? 0 : this.LuyKeKhauHao.Value);
            //}
        }
        partial void On_DonGia_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue == null ? 0 : newValue.Value);
        }
        partial void On_DonGia_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            
            try
            {
                tblChiTietNguyenGiaTSCD chiTietNguyenGiaDauTienCuaTSCaBiet = (from o in this.tblChiTietNguyenGiaTSCDs
                                                                              orderby o.MaChiTiet ascending
                                                                              select o).FirstOrDefault();
                if (oldValue != null && currentValue != oldValue && currentValue!=0)
                {
                    this.TongNguyenGiaCoThue = (this.ChiPhiCoThue == null ? 0 : this.ChiPhiCoThue.Value) + (this.DonGia == null ? 0 : this.DonGia.Value + (this.TienThue == null ? 0 : this.TienThue.Value));
                    this.TongNguyenGiaKhongThue = (this.ChiPhi == null ? 0 : this.ChiPhi.Value) + (this.DonGia == null ? 0 : this.DonGia.Value);
                    this.NguyenGiaMua = (this.DonGia == null ? 0 : this.DonGia.Value) + (this.TienThue == null ? 0 : this.TienThue.Value);
                    this.TienThue = Math.Round((this.PhanTramThue == null ? 0 : this.PhanTramThue.Value) * (this.DonGia == null ? 0 : this.DonGia.Value) / 100);
                    if (CongThue)//((congTy.CongThue == null ? false : congTy.CongThue.Value))
                    {
                        this.NguyenGiaTinhKhauHao = (this.ChiPhiCoThue == null ? 0 : this.ChiPhiCoThue.Value) + (this.DonGia == null ? 0 : this.DonGia.Value) + (this.TienThue == null ? 0 : this.TienThue.Value);
                        this.NguyenGiaConLai = this.NguyenGiaTinhKhauHao;
                        if (chiTietNguyenGiaDauTienCuaTSCaBiet != null)
                        {
                            //cập nhật lại số tiền của chi tiết nguyên giá đầu tiên của tài sản
                            chiTietNguyenGiaDauTienCuaTSCaBiet.SoTien = (this.NguyenGiaTinhKhauHao == null ? 0 : this.NguyenGiaTinhKhauHao.Value);
                        }
                    }
                    else
                    {
                        this.NguyenGiaTinhKhauHao = (this.ChiPhi == null ? 0 : this.ChiPhi.Value) + (this.DonGia == null ? 0 : this.DonGia.Value);
                        this.NguyenGiaConLai = this.NguyenGiaTinhKhauHao;
                        if (chiTietNguyenGiaDauTienCuaTSCaBiet != null)
                        {
                            //cập nhật lại số tiền của chi tiết nguyên giá đầu tiên của tài sản
                            chiTietNguyenGiaDauTienCuaTSCaBiet.SoTien = (this.NguyenGiaTinhKhauHao == null ? 0 : this.NguyenGiaTinhKhauHao.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        partial void On_ChiPhi_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue == null ? 0 : newValue.Value);
        }
        partial void On_ChiPhi_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            
            try
            {
                tblChiTietNguyenGiaTSCD chiTietNguyenGiaDauTienCuaTSCaBiet = (from o in this.tblChiTietNguyenGiaTSCDs
                                                                              orderby o.MaChiTiet ascending
                                                                              select o).FirstOrDefault();
                if (oldValue != null && currentValue != oldValue)
                    if ( (this.DonGia == null ? 0 : this.DonGia.Value) != 0)
                    {
                        this.TongNguyenGiaKhongThue= (this.ChiPhi == null ? 0 : this.ChiPhi.Value) + (this.DonGia == null ? 0 : this.DonGia.Value);
                        this.TongNguyenGiaCoThue = (this.ChiPhiCoThue == null ? 0 : this.ChiPhiCoThue.Value) + (this.DonGia == null ? 0 : this.DonGia.Value + (this.TienThue == null ? 0 : this.TienThue.Value));
                        if (CongThue)//((congTy.CongThue == null ? false : congTy.CongThue.Value))
                        {
                            this.NguyenGiaTinhKhauHao = (this.ChiPhiCoThue == null ? 0 : this.ChiPhiCoThue.Value) + (this.DonGia == null ? 0 : this.DonGia.Value) + (this.TienThue == null ? 0 : this.TienThue.Value);
                            this.NguyenGiaConLai = this.NguyenGiaTinhKhauHao;
                            if (chiTietNguyenGiaDauTienCuaTSCaBiet != null)
                            {
                                //cập nhật lại số tiền của chi tiết nguyên giá đầu tiên của tài sản
                                chiTietNguyenGiaDauTienCuaTSCaBiet.SoTien = (this.NguyenGiaTinhKhauHao == null ? 0 : this.NguyenGiaTinhKhauHao.Value);
                            }
                        }
                        else
                        {
                            this.NguyenGiaTinhKhauHao = (this.ChiPhi == null ? 0 : this.ChiPhi.Value) + (this.DonGia == null ? 0 : this.DonGia.Value);
                            this.NguyenGiaConLai = this.NguyenGiaTinhKhauHao;
                            if (chiTietNguyenGiaDauTienCuaTSCaBiet != null)
                            {
                                //cập nhật lại số tiền của chi tiết nguyên giá đầu tiên của tài sản
                                chiTietNguyenGiaDauTienCuaTSCaBiet.SoTien = (this.NguyenGiaTinhKhauHao == null ? 0 : this.NguyenGiaTinhKhauHao.Value);
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
            }
        }
        partial void On_ChiPhiCoThue_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue == null ? 0 : newValue.Value);
        }
        partial void On_ChiPhiCoThue_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
           
            try
            {
                tblChiTietNguyenGiaTSCD chiTietNguyenGiaDauTienCuaTSCaBiet = (from o in this.tblChiTietNguyenGiaTSCDs
                                                                              orderby o.MaChiTiet ascending
                                                                              select o).FirstOrDefault();
                if (oldValue != null && currentValue != oldValue)
                    if ((this.DonGia == null ? 0 : this.DonGia.Value) != 0)
                    {
                        this.TongNguyenGiaKhongThue = (this.ChiPhi == null ? 0 : this.ChiPhi.Value) + (this.DonGia == null ? 0 : this.DonGia.Value);
                        this.TongNguyenGiaCoThue = (this.ChiPhiCoThue == null ? 0 : this.ChiPhiCoThue.Value) + (this.DonGia == null ? 0 : this.DonGia.Value + (this.TienThue == null ? 0 : this.TienThue.Value));
                        if (CongThue)//((congTy.CongThue == null ? false : congTy.CongThue.Value))
                        {
                            this.NguyenGiaTinhKhauHao = (this.ChiPhiCoThue == null ? 0 : this.ChiPhiCoThue.Value) + (this.DonGia == null ? 0 : this.DonGia.Value) + (this.TienThue == null ? 0 : this.TienThue.Value);
                            this.NguyenGiaConLai = this.NguyenGiaTinhKhauHao;
                            if (chiTietNguyenGiaDauTienCuaTSCaBiet != null)
                            {
                                //cập nhật lại số tiền của chi tiết nguyên giá đầu tiên của tài sản
                                chiTietNguyenGiaDauTienCuaTSCaBiet.SoTien = (this.NguyenGiaTinhKhauHao == null ? 0 : this.NguyenGiaTinhKhauHao.Value);
                            }
                        }
                        else
                        {
                            this.NguyenGiaTinhKhauHao = (this.ChiPhi == null ? 0 : this.ChiPhi.Value) + (this.DonGia == null ? 0 : this.DonGia.Value);
                            this.NguyenGiaConLai = this.NguyenGiaTinhKhauHao;
                            if (chiTietNguyenGiaDauTienCuaTSCaBiet != null)
                            {
                                //cập nhật lại số tiền của chi tiết nguyên giá đầu tiên của tài sản
                                chiTietNguyenGiaDauTienCuaTSCaBiet.SoTien = (this.NguyenGiaTinhKhauHao == null ? 0 : this.NguyenGiaTinhKhauHao.Value);
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
            }
        }
        partial void On_PhanTramThue_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue == null ? 0 : newValue.Value);
        }
        partial void On_PhanTramThue_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            try
            {
                if (oldValue != null && currentValue != oldValue)
                    if ((this.DonGia == null ? 0 : this.DonGia.Value) != 0)
                    {                      
                        this.TienThue =Math.Round((this.PhanTramThue == null ? 0 : this.PhanTramThue.Value) * (this.DonGia == null ? 0 : this.DonGia.Value) / 100);                     
                    }
            }
            catch (Exception ex)
            {
            }
        }
        partial void On_TienThue_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue == null ? 0 : newValue.Value);
        }
        partial void On_TienThue_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            
            try
            {
                tblChiTietNguyenGiaTSCD chiTietNguyenGiaDauTienCuaTSCaBiet = (from o in this.tblChiTietNguyenGiaTSCDs
                                                                              orderby o.MaChiTiet ascending
                                                                              select o).FirstOrDefault();
                if (oldValue != null && currentValue != oldValue)
                    if ((this.DonGia == null ? 0 : this.DonGia.Value) != 0)
                    {
                        this.TongNguyenGiaCoThue = (this.ChiPhiCoThue == null ? 0 : this.ChiPhiCoThue.Value) + (this.DonGia == null ? 0 : this.DonGia.Value + (this.TienThue == null ? 0 : this.TienThue.Value));
                        this.TongNguyenGiaKhongThue = (this.ChiPhi == null ? 0 : this.ChiPhi.Value) + (this.DonGia == null ? 0 : this.DonGia.Value);
                        this.NguyenGiaMua = (this.DonGia == null ? 0 : this.DonGia.Value) + (this.TienThue == null ? 0 : this.TienThue.Value);
                        if (CongThue)//((congTy.CongThue == null ? false : congTy.CongThue.Value))
                        {
                            this.NguyenGiaTinhKhauHao = (this.ChiPhiCoThue == null ? 0 : this.ChiPhiCoThue.Value) + (this.DonGia == null ? 0 : this.DonGia.Value) + (this.TienThue == null ? 0 : this.TienThue.Value);
                            this.NguyenGiaConLai = this.NguyenGiaTinhKhauHao;
                            if (chiTietNguyenGiaDauTienCuaTSCaBiet != null)
                            {
                                //cập nhật lại số tiền của chi tiết nguyên giá đầu tiên của tài sản
                                chiTietNguyenGiaDauTienCuaTSCaBiet.SoTien = (this.NguyenGiaTinhKhauHao == null ? 0 : this.NguyenGiaTinhKhauHao.Value);
                            }
                        }
                        else
                        {
                            this.NguyenGiaTinhKhauHao = (this.ChiPhi == null ? 0 : this.ChiPhi.Value) + (this.DonGia == null ? 0 : this.DonGia.Value);
                            this.NguyenGiaConLai = this.NguyenGiaTinhKhauHao;
                            if (chiTietNguyenGiaDauTienCuaTSCaBiet != null)
                            {
                                //cập nhật lại số tiền của chi tiết nguyên giá đầu tiên của tài sản
                                chiTietNguyenGiaDauTienCuaTSCaBiet.SoTien = (this.NguyenGiaTinhKhauHao == null ? 0 : this.NguyenGiaTinhKhauHao.Value);
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
            }
        }
        partial void On_LuyKeKhauHao_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            tblChiTietNguyenGiaTSCD chiTietNguyenGiaDauTienCuaTSCaBiet = (from o in this.tblChiTietNguyenGiaTSCDs
                                                                          orderby o.MaChiTiet ascending
                                                                          select o).FirstOrDefault();
            if (chiTietNguyenGiaDauTienCuaTSCaBiet != null)
            {
                chiTietNguyenGiaDauTienCuaTSCaBiet.LuyKeKhauHao = this.LuyKeKhauHao;
            }
            this.NguyenGiaConLai = (this.NguyenGiaMua == null ? 0 : this.NguyenGiaMua.Value) - (this.LuyKeKhauHao == null ? 0 : this.LuyKeKhauHao.Value);
        }
        partial void On_LuyKeHaoMon_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            tblChiTietNguyenGiaTSCD chiTietNguyenGiaDauTienCuaTSCaBiet = (from o in this.tblChiTietNguyenGiaTSCDs
                                                                          orderby o.MaChiTiet ascending
                                                                          select o).FirstOrDefault();
            if (chiTietNguyenGiaDauTienCuaTSCaBiet != null)
            {
                chiTietNguyenGiaDauTienCuaTSCaBiet.LuyKeHaoMon = this.LuyKeHaoMon;
            }           
        }

        //đổi ngày sử dụng
        partial void On_NgaySuDung_Changing(Nullable<DateTime> currentValue, ref Nullable<DateTime> newValue, ref bool stopChanging)
        {
            tblChiTietNguyenGiaTSCD chiTietNguyenGiaDauTienCuaTSCaBiet = (from o in this.tblChiTietNguyenGiaTSCDs
                                                                          orderby o.MaChiTiet ascending
                                                                          select o).FirstOrDefault();
            if (chiTietNguyenGiaDauTienCuaTSCaBiet != null)
            {
                //cập nhật lại số tiền của chi tiết nguyên giá đầu tiên của tài sản
                chiTietNguyenGiaDauTienCuaTSCaBiet.NgayThucHien = this.NgaySuDung == null ? app_users_Factory.New().SystemDate.Date : this.NgaySuDung.Value;
            }
        }
    }
}