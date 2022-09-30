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
    public partial class NsChuongTrinh_Factory : BaseFactory<Entities, tblnsChuongTrinh>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return NsChuongTrinh_Factory.New().CreateAloneObject();
        }
        public static NsChuongTrinh_Factory New()
        {
            return new NsChuongTrinh_Factory();
        }
        public NsChuongTrinh_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblnsChuongTrinh GetChuongTrinhByMaChuongTrinh(int maChuongTrinh)
        {//cuong
            tblnsChuongTrinh chuongtrinh = (from o in this.ObjectSet
                                            where o.MaChuongTrinh == maChuongTrinh
                                            select o).SingleOrDefault()
                                                  ;
            return chuongtrinh;
        }
    
        public IQueryable<tblnsChuongTrinh> Get_DanhSachChuaHoanTatByMaCongTy(Int32 maCongTy)
        {//cuong
            IQueryable<tblnsChuongTrinh> query = (from o in this.ObjectSet
                                                  where (o.MaCongTy == maCongTy || (o.DungChung ?? false) == true)
                                                  && (o.HoanTat ?? false) == false
                                                  orderby o.NgayLap descending, o.MaChuongTrinh descending
                                                  select o)
                                                  ;
            return query;
        }

        public IQueryable<tblnsChuongTrinh> Get_ChuongTrinhByMaCongTy(Int32 maCongTy)//pcm
        {//cuong
            IQueryable<tblnsChuongTrinh> query = (from o in this.ObjectSet
                                                  where (o.MaCongTy == maCongTy 
                                                  || (o.DungChung ?? false) == true
                                                  ||maCongTy==0)
                                                  orderby o.NgayLap descending, o.MaChuongTrinh descending
                                                  select o)
                                                  ;
            return query;
        } 
        #endregion
    }//end class
}
