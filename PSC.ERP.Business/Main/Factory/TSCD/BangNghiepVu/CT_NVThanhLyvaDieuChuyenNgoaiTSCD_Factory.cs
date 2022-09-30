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
    public class CT_NVThanhLyvaDieuChuyenNgoaiTSCD_Factory : BaseFactory<Entities, tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return CT_NVThanhLyvaDieuChuyenNgoaiTSCD_Factory.New().CreateAloneObject();
        }
        public static CT_NVThanhLyvaDieuChuyenNgoaiTSCD_Factory New()
        {
            return new CT_NVThanhLyvaDieuChuyenNgoaiTSCD_Factory();
        }
        public CT_NVThanhLyvaDieuChuyenNgoaiTSCD_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDeleteCT_NVThanhLyvaDieuChuyenNgoaiTSCD_Factory(Entities context, List<Object> deleteList)
        {
            //xóa chi tiết nghiệp vụ thanh lý
            foreach (tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD item in deleteList)
            {
                //Cập nhật lại tài sản cố định cá biệt
                item.tblTaiSanCoDinhCaBiet.ThanhLy = false;
                item.tblTaiSanCoDinhCaBiet.NgayThanhLy = null;
                item.tblTaiSanCoDinhCaBiet.MaNghiepVuThanhLy = null;

                if (item.tblDuyetTSCD!=null)
                { 
                    //Cập nhật lại đã thực hiện nghiệp vụ trong duyệt tài sản cá biệt phòng ban
                    item.tblDuyetTSCD.DaThucHienNghiepVu = false;
                }
                //xóa chi tiết nghiệp vụ điều chuyển nội bộ
                context.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
