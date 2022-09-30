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
    public class BoPhanERPNew_Factory : BaseFactory<Entities, tblBoPhanERPNew>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return BoPhanERPNew_Factory.New().CreateAloneObject();
        }
        public static BoPhanERPNew_Factory New()
        {
            return new BoPhanERPNew_Factory();
        }
        public BoPhanERPNew_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        #region Lấy danh sách tất cả bộ phận
        public override IQueryable<tblBoPhanERPNew> GetAll()
        {
            IQueryable<tblBoPhanERPNew> query = from o in this.ObjectSet
                                                where o.IsNgungSuDung.Value == false || o.IsNgungSuDung == null
                                                orderby o.TenBoPhan
                                                select o;

            return query;
        }
        #endregion

        #region Lấy danh sách tất cả bộ phận theo ngày ngưng sử dụng
        public IQueryable<tblBoPhanERPNew> GetAllByDate(DateTime ngay)
        {
            IQueryable<tblBoPhanERPNew> query = from o in this.ObjectSet
                                                where
                                                o.IsNgungSuDung.Value == false || o.IsNgungSuDung == null ||
                                                (o.IsNgungSuDung == true && o.NgayNgungSuDung > ngay)
                                                orderby o.TenBoPhan
                                                select o;

            return query;
        }
        #endregion

        #region Lấy bộ phận theo mã bộ phận
        public tblBoPhanERPNew Get_BoPhanTheoMaBoPhan(int maBoPhan)
        {
            //var query = (from o in this.Context.sp_TSCD_LayDanhSachPhongBanERPNew().AsQueryable()
            //                                    where o.MaBoPhan == maBoPhan
            //                                    select o).SingleOrDefault();

            var query = (from o in this.ObjectSet
                         where o.MaBoPhan == maBoPhan
                         select o).SingleOrDefault();
            return query;
        }

        public tblBoPhanERPNew Get_BoPhanTheoMaBoPhanQL(string maBoPhanQL)
        {
            //var query = (from o in this.Context.sp_TSCD_LayDanhSachPhongBanERPNew().AsQueryable()
            //             where o.MaBoPhanQL == maBoPhanQL
            //             select o).SingleOrDefault();

            //var query = (from o in this.ObjectSet
            //             where o.MaBoPhanQL == maBoPhanQL
            //             select o).SingleOrDefault();

            var query = (from o in this.ObjectSet
                         where o.MaBoPhanQL == maBoPhanQL && (o.IsNgungSuDung == false || o.IsNgungSuDung == null)
                         select o).FirstOrDefault();
            return query;
        }
        #endregion
        #region Xóa tất cả bộ phận 
        public static void FullDeleteBoPhanERPNew(Entities context, List<Object> deleteList)
        {
            //xóa bộ phận
            foreach (tblBoPhanERPNew item in deleteList)
            {
                context.DeleteObject(item);
            }
        }
        #endregion
        #endregion
    }//end class
}
