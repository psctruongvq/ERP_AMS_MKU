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
    public class KhoaSoUser_Factory : BaseFactory<Entities, tblKhoaSo_User>
    {
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return KhoaSoUser_Factory.New().CreateAloneObject();
        }
        public static KhoaSoUser_Factory New()
        {
            return new KhoaSoUser_Factory();
        }
        public KhoaSoUser_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        #region Lấy danh sách KhoaSo_User
        public  IQueryable<tblKhoaSo_User> GetKhoaSo_UserbyNgay_User(int uSerID, DateTime ngay)
        {
            IQueryable<tblKhoaSo_User> query = from o in this.ObjectSet
                                               join k in this.Context.tblKies.AsQueryable<tblKy>() on o.MaKy equals k.MaKy
                                               where k.NgayBatDau <= ngay
                                               && k.NgayKetThuc >= ngay
                                               && o.UserID== uSerID
                                               select o;

            return query;
        }
        #endregion



        #endregion
    }//end class
}
