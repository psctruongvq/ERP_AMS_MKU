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
    public class NghiepVuSuaChuaLon_Factory : BaseFactory<Entities, tblNghiepVuSuaChuaLon>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return NghiepVuSuaChuaLon_Factory.New().CreateAloneObject();
        }
        public static NghiepVuSuaChuaLon_Factory New()
        {
            return new NghiepVuSuaChuaLon_Factory();
        }
        public NghiepVuSuaChuaLon_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDelete(Entities context, tblNghiepVuSuaChuaLon nghiepVuSuaChuaLon)
        {
            //clear dụng cụ phụ tùng của từng chi tiết nghiệp vụ sữa chữa lớn
            foreach (var item in nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon)
            {
                //item.tblBoSungDungCuPhuTungs.Clear();
                //BaseFactory<Entities, tblBoSungDungCuPhuTung>.DeleteHelper(context, item.tblBoSungDungCuPhuTungs);
                BoSungDungCuPhuTung_Factory.FullDelete(context, item.tblBoSungDungCuPhuTungs.ToList<Object>());
                //xóa chi tiết kèm theo
                ChiTietTaiSanCaBiet_Factory.FullDelete(context, item.tblChiTietTaiSanCaBiets.ToList<Object>());
            }
            //clear chi tiết
            //nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon.Clear();
            BaseFactory<Entities, tblCT_NghiepVuSuaChuaLon>.DeleteHelper(context, nghiepVuSuaChuaLon.tblCT_NghiepVuSuaChuaLon);
            //xóa nghiệp vụ
            context.DeleteObject(nghiepVuSuaChuaLon);
        }
        #endregion
    }//end class
}
