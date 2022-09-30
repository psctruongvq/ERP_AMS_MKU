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
    public partial class NhanVien_NgoaiNgu_Factory : BaseFactory<Entities, tblnsNhanVien_NgoaiNgu>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return NhanVien_NgoaiNgu_Factory.New().CreateAloneObject();
        }
        public static NhanVien_NgoaiNgu_Factory New()
        {
            return new NhanVien_NgoaiNgu_Factory();
        }
        public NhanVien_NgoaiNgu_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsNhanVien_NgoaiNgu> GetAll()
        {
            IQueryable<tblnsNhanVien_NgoaiNgu> query = from o in ObjectSet orderby o.MaNhanVien_NgoaiNgu select o;
            return query;
        }
        public tblnsNhanVien_NgoaiNgu GetById(int id)
        {
            tblnsNhanVien_NgoaiNgu obj = this.ObjectSet.SingleOrDefault(o => o.MaNhanVien_NgoaiNgu == id);
            return obj;
        }

        public IQueryable<tblnsNhanVien_NgoaiNgu> GetTrinhDoNgoaiNgu_ByNhanVien(long maNhanVien)
        {
            IQueryable<tblnsNhanVien_NgoaiNgu> query = from o in ObjectSet where o.MaNhanVien == maNhanVien orderby o.MaNhanVien_NgoaiNgu select o;
            return query;
        }
        #endregion
    }//end class
}
