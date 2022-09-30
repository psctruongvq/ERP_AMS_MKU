
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Factory;
//Cường

namespace PSC_ERP_Business.Main.Model
{

    public partial class tblChiTietDieuChinhGiaTri
    {



        partial void On_GiaTriTang_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue ?? 0);
        }
        partial void On_GiaTriTang_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            try
            {
                if (oldValue != null && currentValue != oldValue)
                {
                    //cập nhật lại chi tiết nguyên giá
                    tblChiTietNguyenGiaTSCD chiTietNguyenGia = this.tblChiTietNguyenGiaTSCDs.First();

                    //cập nhật lại số tiền của chi tiết nguyên giá
                    chiTietNguyenGia.SoTien = (currentValue ?? 0);//+= soTienChenhLech;

                    Decimal soTienChenhLech = (this.GiaTriTang ?? 0) - (this.GiaTriGiam ?? 0);

                    //cập nhật nguyên giá mới
                    this.NguyenGiaMoi = this.NguyenGiaCu + soTienChenhLech;
                    /////////////////////////////////////////////
                    if ((currentValue ?? 0) != 0)
                    {
                        this.GiaTriGiam = 0;
                    }
                    //
                    //Decimal cl = (currentValue ?? 0) - (oldValue ?? 0);
                    //if ((this.DonGia ?? 0) > 0)
                    //    this._donGia += cl;
                    //else if ((this.ChiPhi ?? 0) > 0)
                    //    this._chiPhi += cl;
                    //else
                    //    this._donGia += cl;
                    //cập nhật tổng tiền chứng từ
                    ChungTuDieuChinhGiaTriTaiSan_DerivedFactory.CapNhatLaiTongTienChungTu(this.tblDieuChinhGiaTri);
                }
            }
            catch (System.Exception ex)
            {

            }

        }

        partial void On_GiaTriGiam_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue ?? 0);
        }
        partial void On_GiaTriGiam_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            try
            {
                if (oldValue != null && currentValue != oldValue)
                {
                    //cập nhật lại chi tiết nguyên giá
                    tblChiTietNguyenGiaTSCD chiTietNguyenGia = this.tblChiTietNguyenGiaTSCDs.First();
                    //cập nhật lại số tiền của chi tiết nguyên giá
                    chiTietNguyenGia.SoTien = -(currentValue ?? 0);//-= soTienChenhLech;

                    Decimal soTienChenhLech = (this.GiaTriTang ?? 0) - (this.GiaTriGiam ?? 0);
                    //cập nhật nguyên giá mới
                    this.NguyenGiaMoi = this.NguyenGiaCu + soTienChenhLech;
                    /////////////////////////////////////////////
                    if ((currentValue ?? 0) != 0)
                    {
                        this.GiaTriTang = 0;
                    }
                    //
                    //Decimal cl = (currentValue ?? 0) - (oldValue ?? 0);
                    //if ((this.DonGia ?? 0) > 0)
                    //    this._donGia += cl;
                    //else if ((this.ChiPhi ?? 0) > 0)
                    //    this._chiPhi += cl;
                    //else
                    //    this._donGia += cl;
                    //cập nhật tổng tiền chứng từ
                    ChungTuDieuChinhGiaTriTaiSan_DerivedFactory.CapNhatLaiTongTienChungTu(this.tblDieuChinhGiaTri);
                }
            }
            catch (System.Exception ex)
            {

            }


        }




        partial void On_ChiPhi_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue ?? 0);
        }
        partial void On_ChiPhi_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            try
            {
                if (oldValue != null && currentValue != oldValue)
                {
                    //if ((this.ChiPhi ?? 0) != 0 || (this.DonGia ?? 0) != 0)
                    {
                        if ((this.GiaTriGiam ?? 0) > 0)
                            this.GiaTriGiam = (this.ChiPhi ?? 0) + (this.DonGia ?? 0);
                        else
                            this.GiaTriTang = (this.ChiPhi ?? 0) + (this.DonGia ?? 0);
                    }
                }
            }
            catch (System.Exception ex)
            {

            }


        }
        // ///////
        partial void On_DonGia_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue ?? 0);
        }
        partial void On_DonGia_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            try
            {
                if (oldValue != null && currentValue != oldValue)
                {
                    //if ((this.ChiPhi ?? 0) != 0 || (this.DonGia ?? 0) != 0)
                    {
                        if ((this.GiaTriGiam ?? 0) > 0)
                            this.GiaTriGiam = (this.ChiPhi ?? 0) + (this.DonGia ?? 0);
                        else
                            this.GiaTriTang = (this.ChiPhi ?? 0) + (this.DonGia ?? 0);
                    }
                }
            }
            catch (System.Exception ex)
            {

            }

        }
    }
}