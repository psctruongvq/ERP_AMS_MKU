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
    public partial class NhanVien_Factory : BaseFactory<Entities, tblnsNhanVien>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return NhanVien_Factory.New().CreateAloneObject();
        }
        public static NhanVien_Factory New()
        {
            return new NhanVien_Factory();
        }
        public NhanVien_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom

        #region Danh sách nhân viên theo bộ phận
        public IQueryable<tblnsNhanVien> Get_DanhSachNhanVienTheoBoPhan(int maBoPhan)
        {
            //IQueryable<tblnsNhanVien> query = (from o in this.ObjectSet
            //                                  where o.MaBoPhan == maBoPhan
            //                                  select o);

            //lấy về danh sách nhân viên phòng ban từ hệ thống cũ
            BoPhanERPNew_NhanVien_Factory.New().GetAll();
            //this.Context.sp_TSCD_LayDanhSachPhongBanERPNew_NhanVien();
            IQueryable<tblnsNhanVien> query = (from o in this.ObjectSet
                                               where o.tblBoPhanERPNew_NhanVien.Any(x => x.MaBoPhan == maBoPhan)
                                               select o);
            return query;
        }
        #endregion

        #region Lấy nhân viên theo mã nhân viên
        public tblnsNhanVien Get_NhanVienTheoMaNhanVien(long maNhanVien)
        {
            var query = (from o in this.ObjectSet
                         //where o.tblBoPhanERPNew_NhanVien.Any(x => x.MaNhanVien == maNhanVien)
                         where o.MaNhanVien == maNhanVien
                         select o).SingleOrDefault();
            return query;
        }

        #endregion
        #endregion
    }//end class
}
