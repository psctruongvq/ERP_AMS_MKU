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
    public partial class BoPhan_Factory : BaseFactory<Entities, tblnsBoPhan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return BoPhan_Factory.New().CreateAloneObject();
        }
        public static BoPhan_Factory New()
        {
            return new BoPhan_Factory();
        }
        public BoPhan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        //BỔ SUNG NGÀY 18/02/2016
        public tblnsBoPhan LayBoPhan_TheoMaQuanLy(string  maBPQuanLy)
        {
            //var result = (from o in this.ObjectSet
            //              where o.MaBoPhanQL == maBPQuanLy
            //              select o).SingleOrDefault();
            var result = (from o in this.ObjectSet
                          where o.MaBoPhanQL == maBPQuanLy && (o.NgungSuDung == null || o.NgungSuDung==false)
                          select o).FirstOrDefault();
            return result;
        }

        //-------------
        public tblnsBoPhan Get_ByID(Int32 maBoPhan)
        {
            var result = (from o in this.ObjectSet
                          where o.MaBoPhan == maBoPhan
                          select o).SingleOrDefault();
            return result;
        }

        public IQueryable<tblnsBoPhan> GetBoPhanbyUserID(int userID)//pcm
        {
            IQueryable<app_userbophan> listUs_Bp=from u in this.Context.app_userbophan 
                                                 where u.UserID==@userID 
                                                 && u.SuDung.Value==true
                                                     select u;

            IQueryable<tblnsBoPhan> query=(from o in this.ObjectSet
                     join u in listUs_Bp on o.MaBoPhan equals u.MaBoPhan
                     where o.MaBoPhanCha != null
                     orderby o.MaBoPhanQL, o.TenBoPhan
                     select o);
            return query;
        }
        public IQueryable<tblnsBoPhan> GetBoPhanbyMaCongTy(int maCongTy)
        {
           
            IQueryable<tblnsBoPhan> query = (from o in this.ObjectSet                                        
                                             where o.MaCongTy == maCongTy
                                             orderby o.MaBoPhanQL, o.TenBoPhan
                                             select o);
            return query;
        }

        public ParallelQuery<tblnsBoPhan> GetBoPhanbyMaCongTyParallelQuery(int maCongTy)
        {

            ParallelQuery<tblnsBoPhan> query = (from o in this.ObjectSet.AsParallel()
                                             where o.MaCongTy == maCongTy
                                             orderby o.MaBoPhanQL, o.TenBoPhan
                                             select o);
            return query;
        }
        #endregion
    }//end class
}
