using System;
using System.Collections.Generic;
using System.Linq;
using PSC_ERP_Core;
using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERP_Business.Main.Factory
{
    public class CT_ChungTuKhauHaoTSCDPhanBoCCDC_Factory : BaseFactory<Entities, tblCT_ChungTyLePhanBoKhauHaoTSCD>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static BaseEntityObject CreateStandAloneObject()
        {
            return CT_ChungTuKhauHaoTSCDPhanBoCCDC_Factory.New().CreateAloneObject();
        }
        public static CT_ChungTuKhauHaoTSCDPhanBoCCDC_Factory New()
        {
            return new CT_ChungTuKhauHaoTSCDPhanBoCCDC_Factory();
        }
        public CT_ChungTuKhauHaoTSCDPhanBoCCDC_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblCT_ChungTyLePhanBoKhauHaoTSCD Get_TiLeKhauHaoTheoLoai_ByMaLoaiTaiSan(Int32 maTSCDCB)
        {
            var query = (from o in this.ObjectSet
                         where o.MaTSCDCB == maTSCDCB
                         orderby o.MaTSCDCB descending
                         select o).Take(1).SingleOrDefault();

            return query;
        }
     
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            //duyệt qua danh sách
            foreach (tblCT_ChungTyLePhanBoKhauHaoTSCD item in deleteList)
            {
                //xóa
                context.tblCT_ChungTyLePhanBoKhauHaoTSCD.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
