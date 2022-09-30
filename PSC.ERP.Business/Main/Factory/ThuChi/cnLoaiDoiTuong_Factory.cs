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
    public class cnLoaiDoiTuong_Factory : BaseFactory<Entities, tblcnLoaiDoiTuong>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return cnLoaiDoiTuong_Factory.New().CreateAloneObject();
        }
        public static cnLoaiDoiTuong_Factory New()
        {
            return new cnLoaiDoiTuong_Factory();
        }
        public cnLoaiDoiTuong_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        #region Lấy danh sách tất cả Loại đối tượng
        public override IQueryable<tblcnLoaiDoiTuong> GetAll()
        {
            //IQueryable<tblBoPhanERPNew> query = this.Context.sp_TSCD_LayDanhSachPhongBanERPNew().AsQueryable();
            IQueryable<tblcnLoaiDoiTuong> query = from o in this.ObjectSet
                                                  orderby o.TenDoiTuongThuChi
                                                  select o;

            return query;
        }
        #endregion

        #region Lấy Loại đối tượng theo Mã Công Ty
        public IQueryable<tblcnLoaiDoiTuong> Get_LoaiDoiTuongbyMaCongTy(int maCongTy)
        {

            IQueryable<tblcnLoaiDoiTuong> query = from o in this.ObjectSet
                                                  where o.MaCongTy == maCongTy
                                                  && o.SuDung == true
                                                  orderby o.TenDoiTuongThuChi
                                                  select o;
            return query;
        }
        #endregion

        #region Lấy Loại đối tượng theo Mã
        public tblcnLoaiDoiTuong Get_LoaiDoiTuongbyMa(int maDoiTuongThuChi)
        {

            var query = (from o in this.ObjectSet
                         where o.MaDoiTuongThuChi == maDoiTuongThuChi
                         select o).SingleOrDefault();
            return query;
        }
        #endregion



        #region Xóa tất cả Loại đối tượng
        public static void FullDeletecnLoaiDoiTuong(Entities context, List<Object> deleteList)
        {
            //xóa bộ phận
            foreach (tblcnLoaiDoiTuong item in deleteList)
            {
                context.DeleteObject(item);
            }
        }
        #endregion
        #endregion
    }//end class
}
