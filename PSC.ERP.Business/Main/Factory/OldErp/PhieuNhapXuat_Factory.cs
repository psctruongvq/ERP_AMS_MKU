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
    public partial class PhieuNhapXuat_Factory : BaseFactory<Entities, tblPhieuNhapXuat>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return PhieuNhapXuat_Factory.New().CreateAloneObject();
        }
        public static PhieuNhapXuat_Factory New()
        {
            return new PhieuNhapXuat_Factory();
        }
        public PhieuNhapXuat_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        //bổ sung ngày 18/02/2016
        public tblPhieuNhapXuat LayPhieuNhapXuat_TheoSoPhieuNhapXuat(string soPhieu)
        {
            tblPhieuNhapXuat phieuNhapXuat = (from o in this.ObjectSet
                                              where o.SoPhieu.Contains(soPhieu)
                                              select o).SingleOrDefault<tblPhieuNhapXuat>();
            return phieuNhapXuat;
        }

        public tblPhieuNhapXuat GetBy_MaPhieuNhapXuat(Int64 maPhieuNhapXuat)
        {
            var obj = (from o in this.ObjectSet
                       where o.MaPhieuNhapXuat == maPhieuNhapXuat
                       select o).SingleOrDefault();
            return obj;
        }
        public IQueryable<tblPhieuNhapXuat> GetListPhieuNhapBy_MaBoPhan_Nam(Int32? maBoPhan, Int32? nam)
        {
            Boolean tatCaBoPhan = ((maBoPhan ?? 0) == 0);
            Boolean tatCaNam = ((nam ?? 0) == 0);
            var query = from o in this.ObjectSet
                        where o.LaNhap == true && (tatCaBoPhan || o.app_users.MaBoPhan == maBoPhan)
                           && (tatCaNam || o.NgayNX.Year == nam)
                        orderby o.SoPhieu
                        select o;
            return query;
        }

        public IQueryable<tblPhieuNhapXuat> GetListPhieuXuatBy_MaBoPhan_Nam(Int32? maBoPhan, Int32? nam)
        {
            Boolean tatCaBoPhan = ((maBoPhan ?? 0) == 0);
            Boolean tatCaNam = ((nam ?? 0) == 0);
            var query = from o in this.ObjectSet
                        where (o.LaNhap ?? false) == false && (tatCaBoPhan || o.app_users.MaBoPhan == maBoPhan)
                         && (tatCaNam || o.NgayNX.Year == nam)
                        orderby o.SoPhieu
                        select o;
            return query;
        }



        #endregion
    }//end class
}
