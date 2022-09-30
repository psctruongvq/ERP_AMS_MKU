using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Business.Main.Model
{
    public partial class tblChungTu_HoaDon
    {
        public string LoaiHoaDon
        {
            get
            {
                string loaiHD = "";
                if (this.tblHoaDon.LoaiHoaDon == 4)
                    loaiHD = "Hóa đơn mua hàng dịch vụ";
                return loaiHD;
            }
        }
        public Boolean Chon { get; set; }
    }
}
