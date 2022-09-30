
using System;
using System.Linq;
//Cường

namespace PSC_ERP_Business.Main.Model
{

    public partial class tblChiTietTaiSanCaBiet
    {
        partial void On_NguyenGia_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {

            if (this.LaChiTietSuaChuaLon)
            {
                //cập nhật lại chi tiết nguyên giá
                tblChiTietNguyenGiaTSCD chiTietNguyenGia = this.tblChiTietNguyenGiaTSCDs.First();
                chiTietNguyenGia.SoTien = currentValue;
            }

            //cập nhật đơn giá = nguyên giá - chi phí
            //this._donGia = (this.NguyenGia == null ? 0 : this.NguyenGia.Value) - (this.ChiPhi == null ? 0 : this.ChiPhi.Value);
        }

        partial void On_ChiPhi_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue == null ? 0 : newValue.Value);
        }
        partial void On_ChiPhi_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            try
            {
                if ((this.ChiPhi == null ? 0 : this.ChiPhi.Value) != 0 || (this.DonGia == null ? 0 : this.DonGia.Value) != 0)
                {
                    this.NguyenGia = ((this.ChiPhi == null ? 0 : this.ChiPhi.Value) + (this.DonGia == null ? 0 : this.DonGia.Value)) * (this.SoLuong == null ? 0 : this.SoLuong.Value);
                }
            }
            catch (Exception ex)
            {
            }
        }
        partial void On_SoLuong_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue == null ? 0 : newValue.Value);
        }
        partial void On_SoLuong_Changed(Nullable<int> oldValue, Nullable<int> currentValue)
        {
            try
            {
                if ((this.DonGia ?? 0) != 0 || (this.ChiPhi ?? 0) != 0)
                {
                    this.NguyenGia = ((this.ChiPhi == null ? 0 : this.ChiPhi.Value) + (this.DonGia == null ? 0 : this.DonGia.Value)) * (this.SoLuong == null ? 0 : this.SoLuong.Value);
                }
            }
            catch (Exception ex)
            {             
            }
        }

    partial void On_DonGia_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {
            newValue = Math.Abs(newValue == null ? 0 : newValue.Value);
        }
        partial void On_DonGia_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            try
            {
                if ((this.ChiPhi == null ? 0 : this.ChiPhi.Value) != 0 || (this.DonGia == null ? 0 : this.DonGia.Value) != 0)
                {
                    this.NguyenGia = ((this.ChiPhi == null ? 0 : this.ChiPhi.Value) + (this.DonGia == null ? 0 : this.DonGia.Value)) * (this.SoLuong == null ? 0 : this.SoLuong.Value);
                }
            }
            catch (Exception ex)
            {
            }
        }   
    }
}