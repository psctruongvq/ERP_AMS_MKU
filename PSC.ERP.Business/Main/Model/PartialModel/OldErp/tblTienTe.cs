using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Util;
//Cường

namespace PSC_ERP_Business.Main.Model
{

    public partial class tblTienTe
    {
        partial void On_ThanhTien_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {

        }
        partial void On_ThanhTien_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {     
            VietBangChu = ERP_Library.HamDungChung.DocTien(currentValue.Value);
        }

        partial void On_MaLoaiTien_Changed(Nullable<int> oldValue, Nullable<int> currentValue)
        {
            try
            {
                TiGiaQuyDoi = (decimal?)tblLoaiTien.TiGiaQuyDoi;
            }
            catch (System.Exception ex)
            {
                TiGiaQuyDoi = 1;
            }

        }

        partial void On_TiGiaQuyDoi_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            if (TiGiaQuyDoi == null)
                TiGiaQuyDoi = 1;
            ThanhTien = TiGiaQuyDoi * SoTien;
        }

        partial void On_SoTien_Changed(decimal oldValue, decimal currentValue)
        {
            if (TiGiaQuyDoi == null)
                TiGiaQuyDoi = 1;
            ThanhTien = TiGiaQuyDoi * SoTien;
        }

    }
}