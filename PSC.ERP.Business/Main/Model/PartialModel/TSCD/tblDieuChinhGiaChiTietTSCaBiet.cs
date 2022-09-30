﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Factory;
//Cường

namespace PSC_ERP_Business.Main.Model
{


    public partial class tblDieuChinhGiaChiTietTSCaBiet
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
                    Decimal soTienChenhLech = (this.GiaTriTang ?? 0) - (this.GiaTriGiam ?? 0);

                    //cập nhật nguyên giá mới
                    this.NguyenGiaCTMoi = this.NguyenGiaCTCu + soTienChenhLech;
                    /////////////////////////////////////////////
                    if ((currentValue == null ? 0 : currentValue.Value) != 0)
                    {
                        this._giaTriGiam = 0;
                    }
                    //cập nhật đơn giá
                    this._donGia = (this.GiaTriTang ?? 0) - (this.ChiPhi ?? 0);

                    //gôm dữ liệu lên trên
                    if (this.tblChiTietDieuChinhGiaTri != null)
                        ChiTietDieuChinhGiaTri_Factory.GomGiaTriTangGiamTuDieuChinhGiaChiTietVaDieuChinhGiaPhuTungVeChiTietNghiepVu(this.tblChiTietDieuChinhGiaTri);
                }
            }
            catch (System.Exception ex)
            {

            }

        }

        partial void On_GiaTriGiam_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue ?? 0);
            if ((newValue ?? 0) > this.NguyenGiaCTCu)
                newValue = NguyenGiaCTCu;
        }
        partial void On_GiaTriGiam_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            try
            {

                if (oldValue != null && currentValue != oldValue)
                {
                    Decimal soTienChenhLech = (this.GiaTriTang ?? 0) - (this.GiaTriGiam ?? 0);
                    //cập nhật nguyên giá mới
                    this.NguyenGiaCTMoi = this.NguyenGiaCTCu + soTienChenhLech;

                    /////////////////////////////////////////////
                    if ((currentValue == null ? 0 : currentValue.Value) != 0)
                    {
                        this._giaTriTang = 0;
                    }

                    //cập nhật đơn giá
                    //this._donGia = (this.GiaTriGiam == null ? 0 : this.GiaTriGiam.Value) - (this.ChiPhi == null ? 0 : this.ChiPhi.Value);


                    //gôm dữ liệu lên trên
                    if (this.tblChiTietDieuChinhGiaTri != null)
                        ChiTietDieuChinhGiaTri_Factory.GomGiaTriTangGiamTuDieuChinhGiaChiTietVaDieuChinhGiaPhuTungVeChiTietNghiepVu(this.tblChiTietDieuChinhGiaTri);
                }
            }
            catch (System.Exception ex)
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