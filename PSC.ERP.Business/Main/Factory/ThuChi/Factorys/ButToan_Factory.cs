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
using System.Collections;
using PSC_ERP_Common.Ado.Net;

namespace PSC_ERP_Business.Main.Factory
{
    public partial class ButToan_Factory
    {


        #region Custom

        public static void FullDeleteButToanThuChi(Entities context, List<Object> deleteList)
        {

            foreach (tblButToan butToan in deleteList)
            {
                //xóa chứng từ hóa đơn của bút toán
                ChungTu_HoaDon_Factory.FullDelete(context, butToan.tblChungTu_HoaDon.ToList<Object>());
                ////xóa bút toán mục ngân sách
                //BaseFactory<Entities, tblButToan_MucNganSach>.DeleteHelper(context, butToan.tblButToan_MucNganSach);

                //xóa chi phi san xuat
                CT_ChiPhiSanXuat_Factory.FullDelete(context, butToan.tblCT_ChiPhiSanXuat.ToList<Object>());
                //Xóa ButToan_ChiPhiHD
                ButToan_ChiPhiHD_Factory.FullDelete(context, butToan.tblButToan_ChiPhiHD.ToList<Object>());
                //xóa bút toán
                context.tblButToans.DeleteObject(butToan);
            }

        }

        public static void DeleteChildrenButToanThuChi(Entities context, tblButToan butToan)
        {
            //xóa chứng từ hóa đơn của bút toán
            ChungTu_HoaDon_Factory.FullDelete(context, butToan.tblChungTu_HoaDon.ToList<Object>());
            ////xóa bút toán mục ngân sách
            //BaseFactory<Entities, tblButToan_MucNganSach>.DeleteHelper(context, butToan.tblButToan_MucNganSach);

            //xóa chi phi san xuat
            CT_ChiPhiSanXuat_Factory.FullDelete(context, butToan.tblCT_ChiPhiSanXuat.ToList<Object>());
            //Xóa ButToan_ChiPhiHD
            ButToan_ChiPhiHD_Factory.FullDelete(context, butToan.tblButToan_ChiPhiHD.ToList<Object>());
            //xóa bút toán
            context.tblButToans.DeleteObject(butToan);

        }

        #endregion
    }//end class
}
