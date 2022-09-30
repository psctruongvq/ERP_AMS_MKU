using System;
using System.Linq;
using PSC_ERP_Core;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERP_Business.Main.Factory
{
    public class ChungTuKhauHaoTSCDPhanBoCCDC_Factory : BaseFactory<Entities, tblChungTuKhauHaoTSCDPhanBoCCDC>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static BaseEntityObject CreateStandAloneObject()
        {
            return ChungTuKhauHaoTSCDPhanBoCCDC_Factory.New().CreateAloneObject();
        }
        public static ChungTuKhauHaoTSCDPhanBoCCDC_Factory New()
        {
            return new ChungTuKhauHaoTSCDPhanBoCCDC_Factory();
        }
        public ChungTuKhauHaoTSCDPhanBoCCDC_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblChungTuKhauHaoTSCDPhanBoCCDC Get_ChungTuDangKyTiLeKHHMTheoNgayHieuLuc(DateTime ngayHieuLuc)
        {
            var query = (from o in this.ObjectSet
                         where o.NgayHeThong == ngayHieuLuc
                         select o).SingleOrDefault();
            return query;
        }
        public IQueryable<tblChungTuKhauHaoTSCDPhanBoCCDC> Get_All()
        {
            IQueryable<tblChungTuKhauHaoTSCDPhanBoCCDC> query = (from o in this.ObjectSet
                                                          orderby o.NgayHeThong descending
                                                          select o);
            return query;
        }
        public tblChungTuKhauHaoTSCDPhanBoCCDC Get_ChungTuDangKyTiLeKHHMByMaChungTu(int maChungTu)
        {
            var query = (from o in this.ObjectSet
                         where o.MaChungTu == maChungTu
                         select o).SingleOrDefault();
            return query;
        }
        public bool tblChungTuKhauHao_CheckHasData_ByMaKy(int maKy)
        {
            var query = (from o in this.ObjectSet
                         where o.MaKy == maKy
                         select o).Count();
            return (int)query > 0;
        }
        public static void FullDelete(Entities context, params Object[] deleteList)
        {
            //Duyệt qua danh sách cần xóa
            foreach (tblChungTuKhauHaoTSCDPhanBoCCDC item in deleteList)
            {
                //Xóa tỉ lệ khấu hao theo loại
                NghiepVuKhauHaoHaoMon_Factory.FullDelete(context: context, deleteList: item.tblNghiepVuKhauHaoHaoMons.ToList<object>());

                //Xóa tỉ lệ khấu hao theo tài khoản
                //TiLeKhauHaoTheoTaiKhoan_Factory.FullDelete(context: context, deleteList: item.tblTiLeKhauHaoTheoTaiKhoans.ToArray<Object>());
                context.tblChungTuKhauHaoTSCDPhanBoCCDCs.DeleteObject(item);
            }
        }
        public Boolean KiemTraTrungNgayHieuLuc_Helper(int maChungTu, DateTime ngayHieuLuc, Boolean loai)
        {
            bool trungNgayHieuLuc = false;

            trungNgayHieuLuc = (from o in this.ObjectSet
                                where
                                  o.NgayHeThong == ngayHieuLuc
                                  && (o.LoaiKHHM) == loai
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
                                && o.LoaiKHHM==KHHM
                                select true).SingleOrDefault();

            return trungNgayHieuLuc;
        }
        #endregion
    }//end class
}
