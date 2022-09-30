using System;
using System.Collections.Generic;
using System.Linq;
using PSC_ERP_Core;
using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERP_Business.Main.Factory
{
    public class NghiepVuKhauHaoHaoMon_Factory : BaseFactory<Entities, tblNghiepVuKhauHaoHaoMon>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static BaseEntityObject CreateStandAloneObject()
        {
            return NghiepVuKhauHaoHaoMon_Factory.New().CreateAloneObject();
        }
        public static NghiepVuKhauHaoHaoMon_Factory New()
        {
            return new NghiepVuKhauHaoHaoMon_Factory();
        }
        public NghiepVuKhauHaoHaoMon_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public Boolean DaKhoaSoTSCD(Int32 maKy)
        {//đã khóa sổ nếu tồn tại dòng trong tblNghiepVuKhauHaoHaoMons có mã kỳ = mã kỳ gởi vào
            Boolean result = this.ObjectSet.Any(x => x.MaKy == maKy);
            return result;
        }

        public IQueryable<tblNghiepVuKhauHaoHaoMon> GetNghiepVuKhauHaoHaoMonListByMaKy(Int32 maky)
        {
            IQueryable<tblNghiepVuKhauHaoHaoMon> query = from o in this.ObjectSet
                                                         where o.MaKy == maky
                                                         select o;
            return query;
        }
        public void XoaKHHMByMaKy(Int32 maky)
        {
            IQueryable<tblNghiepVuKhauHaoHaoMon> query = GetNghiepVuKhauHaoHaoMonListByMaKy(maky);
            FullDelete(this.Context, query.ToList<Object>());
        }
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            foreach (tblNghiepVuKhauHaoHaoMon item in deleteList)
            {
                context.tblNghiepVuKhauHaoHaoMons.DeleteObject(item);
            }

        }
        #endregion
    }//end class
}
