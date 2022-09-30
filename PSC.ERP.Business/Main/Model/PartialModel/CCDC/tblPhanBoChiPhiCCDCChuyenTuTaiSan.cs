
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Factory;
//Cường

namespace PSC_ERP_Business.Main.Model
{

    public partial class tblPhanBoChiPhiCCDCChuyenTuTaiSan
    {
        public Object CurrentForm_AddedObj = null;
        partial void On_PhanTramPhanBo_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {

        }
        partial void On_PhanTramPhanBo_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            if (oldValue != null)
                if ((oldValue ?? 0) != (currentValue ?? 0))
                {
                    //thay đổi đồng loạt phần trăm phân bổ trên chi tiết
                    if (this.tblCT_PhanBoChiPhiCCDCChuyenTuTaiSan != null)
                        foreach (var item in this.tblCT_PhanBoChiPhiCCDCChuyenTuTaiSan)
                        {
                            item.PhanTramPhanBo = this.PhanTramPhanBo;
                        }

                }//


        }

    }
}