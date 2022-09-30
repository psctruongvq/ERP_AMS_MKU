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
namespace PSC_ERP_Business.Main.Factory//
{
    public partial class NhanVien_Loai_Factory : BaseFactory<Entities, tblnsNhanVien_Loai>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return NhanVien_Loai_Factory.New().CreateAloneObject();
        }
        public static NhanVien_Loai_Factory New()
        {
            return new NhanVien_Loai_Factory();
        }
        public NhanVien_Loai_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsNhanVien_Loai> GetAll()
        {
            IQueryable<tblnsNhanVien_Loai> query = from o in ObjectSet orderby o.TenLoaiNhanVien select o;
            return query;
        }
        public tblnsNhanVien_Loai GetById(int id)
        {
            tblnsNhanVien_Loai obj = this.ObjectSet.SingleOrDefault(o => o.MaLoaiNhanVien == id);
            return obj;
        }

        #endregion
    }//end class
}
