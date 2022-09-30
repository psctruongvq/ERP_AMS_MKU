using System;
using System.Collections.Generic;
using System.Linq;
using PSC_ERP_Core;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERP_Business.Main.Factory
{
    public class ChungTuTyLeKhauHaoTaiSanTheoBoPhan_Factory : BaseFactory<Entities, tblChungTuTyLePhanBoKhauHaoTSCD>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static BaseEntityObject CreateStandAloneObject()
        {
            return ChungTuTyLeKhauHaoTaiSanTheoBoPhan_Factory.New().CreateAloneObject();
        }
        public static ChungTuTyLeKhauHaoTaiSanTheoBoPhan_Factory New()
        {
            return new ChungTuTyLeKhauHaoTaiSanTheoBoPhan_Factory();
        }
        public ChungTuTyLeKhauHaoTaiSanTheoBoPhan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblChungTuTyLePhanBoKhauHaoTSCD Get_ChungTuDangKyTiLeKHHMTheoNgayHieuLuc(DateTime ngayHieuLuc)
        {
            var query = (from o in this.ObjectSet
                         where o.NgayHeThong == ngayHieuLuc
                         select o).SingleOrDefault();
            return query;
        }
        public IQueryable<tblChungTuTyLePhanBoKhauHaoTSCD> Get_All()
        {
            IQueryable<tblChungTuTyLePhanBoKhauHaoTSCD> query = (from o in this.ObjectSet
                                                          orderby o.NgayHeThong descending
                                                          select o);
            return query;
        }
        public tblChungTuTyLePhanBoKhauHaoTSCD Get_ChungTuDangKyTiLeKHHMByMaChungTu(long maChungTu)
        {
            var query = (from o in this.ObjectSet
                         where o.MaChungTu == maChungTu
                         select o).SingleOrDefault();
            return query;
        }
        public static void FullDelete(Entities context, params Object[] deleteList)
        {
            //Duyệt qua danh sách cần xóa
            foreach (tblChungTuTyLePhanBoKhauHaoTSCD item in deleteList)
            {
                //Xóa tỉ lệ khấu hao theo loại
                CT_ChungTuKhauHaoTSCDPhanBoCCDC_Factory.FullDelete(context: context, deleteList: item.tblCT_ChungTyLePhanBoKhauHaoTSCD.ToList<object>());
                context.tblChungTuTyLePhanBoKhauHaoTSCDs.DeleteObject(item);
            }
        }
        public Boolean KiemTraTrungNgayHieuLuc_Helper(int maChungTu, DateTime ngayHieuLuc)
        {
            bool trungNgayHieuLuc = false;

            trungNgayHieuLuc = (from o in this.ObjectSet
                                where
                                  o.NgayHeThong == ngayHieuLuc                                 
                                  && (maChungTu == 0 || o.MaChungTu != maChungTu)
                                select true).SingleOrDefault();

            return trungNgayHieuLuc;
        }
        public Boolean KiemTraTrungNgayHieuLuc_Helper(DateTime ngayHieuLuc)
        {
            bool trungNgayHieuLuc = false;

            trungNgayHieuLuc = (from o in this.ObjectSet
                                where o.NgayHeThong == ngayHieuLuc
                                select true).SingleOrDefault();

            return trungNgayHieuLuc;
        }
        public Boolean KiemTraTrungNgayHieuLuc_Helper(DateTime ngayHieuLuc, Boolean KHHM)
        {
            bool trungNgayHieuLuc = false;

            trungNgayHieuLuc = (from o in this.ObjectSet
                                where o.NgayHeThong == ngayHieuLuc                             
                                select true).SingleOrDefault();

            return trungNgayHieuLuc;
        }
        #endregion
    }//end class
}
