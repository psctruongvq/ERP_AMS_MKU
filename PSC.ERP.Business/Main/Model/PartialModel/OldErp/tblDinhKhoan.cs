
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Core;
//Cường
namespace PSC_ERP_Business.Main.Model
{

    public partial class tblDinhKhoan
    {
        partial void On_GhiMucNganSach_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue)
        {
            //if (this.GhiMucNganSach == false)
            //{
            //    //duyệt qua từng bút toán
            //    foreach (var butToan in this.tblButToans)
            //    {
            //        Entities context = butToan.GetContext() as Entities;
            //        //xóa bút toán mục ngân sách đi kèm theo bút toán
            //        ButToan_MucNganSach_Factory.FullDeleteButToan_MucNganSach(context, butToan.tblButToan_MucNganSach.ToList<Object>());
            //    }
            //}

        
        }
    }
}