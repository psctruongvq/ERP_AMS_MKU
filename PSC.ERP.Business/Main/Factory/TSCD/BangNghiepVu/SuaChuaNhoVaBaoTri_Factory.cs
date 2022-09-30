using System;
using System.Collections.Generic;
using System.Linq;
using PSC_ERP_Core;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERP_Business.Main.Factory
{
    public class SuaChuaNhoVaBaoTri_Factory : BaseFactory<Entities, tblLichSuSuaChuaTaiSan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static BaseEntityObject CreateStandAloneObject()
        {
            return SuaChuaNhoVaBaoTri_Factory.New().CreateAloneObject();
        }
        public static SuaChuaNhoVaBaoTri_Factory New()
        {
            return new SuaChuaNhoVaBaoTri_Factory();
        }
        public SuaChuaNhoVaBaoTri_Factory()
            : base(Database.NewEntities())
        {
        }
       
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            foreach (tblLichSuSuaChuaTaiSan item in deleteList)
            {   
                context.tblLichSuSuaChuaTaiSans.DeleteObject(item);
            }           
        }      
    }//end class
}
