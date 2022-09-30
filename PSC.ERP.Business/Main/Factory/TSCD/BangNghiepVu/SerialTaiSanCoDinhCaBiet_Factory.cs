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
    public class SerialTaiSanCoDinhCaBiet_Factory : BaseFactory<Entities, tblSerialTaiSanCoDinhCaBiet>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return SerialTaiSanCoDinhCaBiet_Factory.New().CreateAloneObject();
        }
        public static SerialTaiSanCoDinhCaBiet_Factory New()
        {
            return new SerialTaiSanCoDinhCaBiet_Factory();
        }
        public SerialTaiSanCoDinhCaBiet_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public Boolean KiemTraTSCDCaBietDaDuocPhanBo(int maTSCDCaBiet)
        {
            Boolean result = this.ObjectSet.Any(x => x.MaTSCDCB == maTSCDCaBiet);
            return result;
        }
        public tblSerialTaiSanCoDinhCaBiet Get_SerialSauCung_ByMaTSCDCaBiet(int maTSCDCaBiet)
        {//chua test

            tblSerialTaiSanCoDinhCaBiet obj = (from o in this.ObjectSet
                                                  where o.MaTSCDCB == maTSCDCaBiet
                                                  orderby o.NgayApDung descending, o.ID descending
                                                  select o).FirstOrDefault();

            return obj;
        }

        public tblSerialTaiSanCoDinhCaBiet Get_SerialDauTien_ByMaTSCDCaBiet(int maTSCDCaBiet)
        {//chua test

            tblSerialTaiSanCoDinhCaBiet obj = (from o in this.ObjectSet
                                                  where o.MaTSCDCB == maTSCDCaBiet
                                                  orderby o.NgayApDung ascending, o.ID ascending
                                                  select o).FirstOrDefault();

            return obj;
        }

        public tblSerialTaiSanCoDinhCaBiet Get_ChiTietNghiepVu_ByMaTSCDCaBiet_And_MaChungTu(int maTSCDCaBiet, int maChungTu)
        {
            tblSerialTaiSanCoDinhCaBiet obj = (from o in this.ObjectSet
                                               where o.MaTSCDCB == maTSCDCaBiet && o.MaChungTu==maChungTu
                                               orderby o.NgayApDung descending, o.ID descending
                                               select o).FirstOrDefault();

            return obj;
        }

        public static void FullDeleteCT_NghiepVuDoiSerialTaiSan(Entities context, List<Object> deleteList)
        {
            //xóa chi tiết nghiệp vụ đổi số serial
            foreach (tblSerialTaiSanCoDinhCaBiet item in deleteList)
            {
                //xóa chi tiết nghiệp vụ đổi số serial tài sản
                context.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
