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
    public partial class CT_PhanBoChiPhiCCDCChuyenTuTaiSan_Factory : BaseFactory<Entities, tblCT_PhanBoChiPhiCCDCChuyenTuTaiSan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return CT_PhanBoChiPhiCCDCChuyenTuTaiSan_Factory.New().CreateAloneObject();
        }
        public static CT_PhanBoChiPhiCCDCChuyenTuTaiSan_Factory New()
        {
            return new CT_PhanBoChiPhiCCDCChuyenTuTaiSan_Factory();
        }
        public CT_PhanBoChiPhiCCDCChuyenTuTaiSan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom

        public static void FullDelete(Entities context, params Object[] deleteList)
        {
            //duyệt qua danh sách
            foreach (tblCT_PhanBoChiPhiCCDCChuyenTuTaiSan item in deleteList)
            {
                //điều chỉnh chi phí đã phân bổ
                item.tblCongCuDungCu.ChiPhiDaPhanBo -= item.ChiPhiPhanBo;
                //xóa
                context.tblCT_PhanBoChiPhiCCDCChuyenTuTaiSan.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
