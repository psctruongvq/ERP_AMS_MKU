
using System;
using System.Collections.Generic;
using System.Linq;
//Cường

namespace PSC_ERP_Business.Main.Model
{

    public partial class tblBoSungDungCuPhuTung
    {
        partial void On_TongGiaTri_Changed(decimal oldValue, decimal currentValue)
        {
            if (this.LaDCPTSuaChuaLon)
            {
                //cập nhật lại chi tiết nguyên giá
                tblChiTietNguyenGiaTSCD chiTietNguyenGia = this.tblChiTietNguyenGiaTSCDs.First();
                chiTietNguyenGia.SoTien = currentValue;
            }

            //cập nhật đơn giá = nguyên giá - chi phí
            //this._donGia = this.TongGiaTri - (this.ChiPhi ?? 0);

        }


        partial void On_ChiPhi_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue ?? 0);
        }
        partial void On_ChiPhi_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            try
            {
                if ((this.ChiPhi ?? 0) != 0 || (this.DonGia ?? 0) != 0)
                {
                    this.TongGiaTri = ((this.ChiPhi ?? 0) + (this.DonGia ?? 0)) * this.SoLuong;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        partial void On_DonGia_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue ?? 0);
        }
        partial void On_DonGia_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            try
            {
                if ((this.DonGia ?? 0) != 0 || (this.ChiPhi ?? 0) != 0)
                {
                    this.TongGiaTri = ((this.ChiPhi ?? 0) + (this.DonGia ?? 0)) * this.SoLuong;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        partial void On_SoLuong_Changing(int currentValue, ref int newValue, ref bool stopChanging) {
            //newValue = Math.Abs(newValue ?? 0);
        }
        partial void On_SoLuong_Changed(int oldValue, int currentValue) {
            try {
                if ((this.DonGia ?? 0) != 0 || (this.ChiPhi ?? 0) != 0)
                {
                    this.TongGiaTri = ((this.ChiPhi ?? 0) + (this.DonGia ?? 0)) * this.SoLuong;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}