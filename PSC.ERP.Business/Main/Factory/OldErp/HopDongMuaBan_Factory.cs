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
    public partial class HopDongMuaBan_Factory : BaseFactory<Entities, tblHopDongMuaBan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return HopDongMuaBan_Factory.New().CreateAloneObject();
        }
        public static HopDongMuaBan_Factory New()
        {
            return new HopDongMuaBan_Factory();
        }
        public HopDongMuaBan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public virtual tblHopDongMuaBan Get_HopDongMuaBan_ByMaHopDong(long maHopDong)
        {
            tblHopDongMuaBan obj = (from o in this.ObjectSet
                                    where o.MaHopDong == maHopDong
                                    select o).SingleOrDefault();
            return obj;
        }

        public IQueryable<tblHopDongMuaBan> GetListHDNoiBoBy_MaBoPhan_Nam(Int32? maBoPhan, Int32? nam)
        {
            Boolean tatCaBoPhan = ((maBoPhan ?? 0) == 0);
            Boolean tatCaNam = ((nam ?? 0) == 0);
            var query = from o in this.ObjectSet
                        where (o.HDTrongNgoaiDai ?? false) == false && (tatCaBoPhan || o.tblHopDong.app_users.MaBoPhan == maBoPhan)
                         && (tatCaNam || o.tblHopDong.NgayKy.Value.Year == nam)
                        orderby o.SoHopDong
                        select o;
            return query;
        }

        public IQueryable<tblHopDongMuaBan> GetListHDBenNgoaiBy_MaBoPhan(Int32? maBoPhan, Int32? nam)
        {
            Boolean tatCaBoPhan = ((maBoPhan ?? 0) == 0);
            Boolean tatCaNam = ((nam ?? 0) == 0);
            var query = from o in this.ObjectSet
                        where o.HDTrongNgoaiDai == true && (tatCaBoPhan || o.tblHopDong.app_users.MaBoPhan == maBoPhan)
                         && (tatCaNam || o.tblHopDong.NgayKy.Value.Year == nam)
                        orderby o.SoHopDong
                        select o;
            return query;
        }
        #endregion
    }//end class
}
