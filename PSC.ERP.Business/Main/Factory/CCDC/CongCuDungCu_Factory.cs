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
    public partial class CongCuDungCu_Factory : BaseFactory<Entities, tblCongCuDungCu>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return CongCuDungCu_Factory.New().CreateAloneObject();
        }
        public static CongCuDungCu_Factory New()
        {
            return new CongCuDungCu_Factory();
        }
        public CongCuDungCu_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public IQueryable<tblCongCuDungCu> GetList_CCDCChuyenTuTaiSan()
        {
            IQueryable<tblCongCuDungCu> query = (from o in this.ObjectSet
                                                 where o.ChuyenTuTaiSan == true
                                                 select o);

            return query;
        }
        public IQueryable<tblCongCuDungCu> GetList_CCDCChuyenTuTaiSanChuaPhanBoChiPhiHet()
        {
            DateTime ngayHienTai = app_users_Factory.New().SystemDate;
            IQueryable<tblCongCuDungCu> query = (from o in this.ObjectSet
                                                 where o.ChuyenTuTaiSan == true
                                                    && (o.ChiPhiDaPhanBo ?? 0) != (o.NguyenGia ?? 0) - (o.LuyKeKHTaiSanChuyenSang ?? 0) - (o.LuyKeHMTaiSanChuyenSang ?? 0)
                                                    && ((o.ThanhLy ?? false) == false || (o.ThanhLy == true && o.NgayThanhLy >= ngayHienTai))

                                                 select o);

            return query;
        }
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            //duyệt qua danh sách
            foreach (tblCongCuDungCu item in deleteList)
            {
                //xóa
                context.tblCongCuDungCus.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
