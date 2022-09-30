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
using ERP_Library;

namespace PSC_ERP_Business.Main.Factory
{
    public partial class HoaDon_Factory : BaseFactory<Entities, tblHoaDon>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return HoaDon_Factory.New().CreateAloneObject();
        }
        public static HoaDon_Factory New()
        {
            return new HoaDon_Factory();
        }
        public HoaDon_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public virtual tblHoaDon Get_HoaDon_ByMaHoaDon(long maHoaDon)
        {
            tblHoaDon obj = (from o in this.ObjectSet
                             where o.MaHoaDon == maHoaDon
                             select o).SingleOrDefault();
            return obj;
        }

        public static void FullDelete(Entities context, List<Object> deleteList)
        {

            foreach (tblHoaDon obj in deleteList)
            {
                //01 xóa HoaDon_DoiTac
                HoaDon_DoiTac_Factory.FullDelete(context, obj.tblHoaDon_DoiTac.ToList<Object>());
                //xóa bảng chứng từ hóa đơn
                ChungTu_HoaDon_Factory.FullDelete(context, obj.tblChungTu_HoaDon.ToList<Object>());
                //02 xóa hóa đơn
                context.tblHoaDons.DeleteObject(obj);

            }

        }

        public IQueryable<tblHoaDon> GetHoaDonListbySearchForChungTu(bool timtheongay, DateTime tungay, DateTime denngay, string sohoadon, long madoitac)
        {
            IQueryable<tblHoaDon> listhoadon = null;
            if(timtheongay)
            {
                tungay = tungay.ToStartDate();
                denngay = denngay.ToEndDate();
                listhoadon = from o in this.ObjectSet
                             where o.NgayLap >= tungay && o.NgayLap <= denngay
                       && (o.SoHoaDon.Contains(sohoadon) || o.SoSerial.Contains(sohoadon)) 
                       && (madoitac == 0 ||  o.MaDoiTac.Value == madoitac)
                       && !(from ct_hd in this.Context.tblChungTu_HoaDon select ct_hd.MaHoaDon).Contains(o.MaHoaDon)
                       orderby o.NgayLap
                       select o;
            }
            else
            {
                listhoadon = from o in this.ObjectSet
                             where (o.SoHoaDon.Contains(sohoadon) || o.SoSerial.Contains(sohoadon)) 
                             && (madoitac == 0 || o.MaDoiTac == madoitac)
                             && !(from ct_hd in this.Context.tblChungTu_HoaDon select ct_hd.MaHoaDon).Contains(o.MaHoaDon)
                             orderby o.NgayLap
                             select o;
            }
            return listhoadon;
        }

        public IQueryable<tblHoaDon> GetHoaDonByChungTu(long machungtu)
        {
            IQueryable<tblHoaDon> listhoadon = null;
            listhoadon = from o in this.ObjectSet
                         join cthd in this.Context.tblChungTu_HoaDon on o.MaHoaDon equals cthd.MaHoaDon
                         where cthd.MaChungTu == machungtu
                         orderby o.MaHoaDon
                         select o;
            return listhoadon;
        }
        #endregion
    }//end class
}
