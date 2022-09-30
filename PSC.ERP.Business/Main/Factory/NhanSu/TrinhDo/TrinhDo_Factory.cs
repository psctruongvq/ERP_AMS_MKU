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
    public partial class TrinhDo_Factory : BaseFactory<Entities, tblnsTrinhDo>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return TrinhDo_Factory.New().CreateAloneObject();
        }
        public static TrinhDo_Factory New()
        {
            return new TrinhDo_Factory();
        }
        public TrinhDo_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsTrinhDo> GetAll()
        {
            IQueryable<tblnsTrinhDo> query = from o in ObjectSet orderby o.MaTrinhDo select o;
            return query;
        }
        public tblnsTrinhDo GetById(int id)
        {
            tblnsTrinhDo obj = this.ObjectSet.SingleOrDefault(o => o.MaTrinhDo == id);
            return obj;
        }

        //lấy trình độ của 1 nhân viên
        public IQueryable<tblnsTrinhDo> GetTrinhDoByMaNhanVien(long maNhanVien)
        {
            IQueryable<tblnsTrinhDo> query = from o in ObjectSet where o.MaNhanVien == maNhanVien orderby o.MaTrinhDo select o;
            return query;
        }

        #endregion
    }//end class
}
