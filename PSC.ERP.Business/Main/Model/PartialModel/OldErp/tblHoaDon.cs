using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Cường

namespace PSC_ERP_Business.Main.Model
{

    public partial class tblHoaDon
    {
        public Boolean Chon { get; set; }

        partial void On_ThanhTien_Changed(decimal oldValue, decimal currentValue)
        {//khi số tiền  thay đổi

            _thueVAT = (decimal)(_thueSuatVAT ?? 0) * (_thanhTien / (Decimal)100);//%VAT * số tiền
            _tongTien = _thanhTien + _thueVAT;
        }
        partial void On_ThueSuatVAT_Changed(Nullable<double> oldValue, Nullable<double> currentValue)
        {//khi phần trăm VAT thay đổi

            _thueVAT = (decimal)(_thueSuatVAT ?? 0) * (_thanhTien / (Decimal)100);//%VAT * số tiền
            _tongTien = _thanhTien + _thueVAT;
        }
        partial void On_ThueVAT_Changed(decimal oldValue, decimal currentValue)
        {//khi tiền thuế VAT thay đổi



        }

        partial void On_TongTien_Changed(decimal oldValue, decimal currentValue)
        {//khi tổng tiền thay đổi

        }



    }
}