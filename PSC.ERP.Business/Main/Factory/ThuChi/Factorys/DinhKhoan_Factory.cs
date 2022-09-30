using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Core;
using System.Reflection;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Objects;
using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main;
using PSC_ERP_Util.DateTimeExtension;

namespace PSC_ERP_Business.Main.Factory
{
    public partial class DinhKhoan_Factory 
    {

        #region Custom
        public static void FullDeleteDinhKhoanThuChi(Entities context, tblDinhKhoan dinhKhoan)
        {
            //xoa but toan cua dinh khoan
            ButToan_Factory.FullDeleteButToanThuChi(context, dinhKhoan.tblButToans.ToList<Object>());
            //xoa dinh khoan
            context.tblDinhKhoans.DeleteObject(dinhKhoan);
        }
        #endregion
    }//end class
}
