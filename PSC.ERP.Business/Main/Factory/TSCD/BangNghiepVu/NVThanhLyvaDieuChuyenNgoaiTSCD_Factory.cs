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
    public class NVThanhLyvaDieuChuyenNgoaiTSCD_Factory : BaseFactory<Entities, tblNVThanhLyvaDieuChuyenNgoaiTSCD>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return NVThanhLyvaDieuChuyenNgoaiTSCD_Factory.New().CreateAloneObject();
        }
        public static NVThanhLyvaDieuChuyenNgoaiTSCD_Factory New()
        {
            return new NVThanhLyvaDieuChuyenNgoaiTSCD_Factory();
        }
        public NVThanhLyvaDieuChuyenNgoaiTSCD_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom


        public static void FullDelete(Entities context, tblNVThanhLyvaDieuChuyenNgoaiTSCD nghiepVu)
        {

            //cập nhật lại trạng thái cho các dòng tài sản
            foreach (var item in nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD)
            {
                item.tblTaiSanCoDinhCaBiet.NgayThanhLy = null;
                item.tblTaiSanCoDinhCaBiet.ThanhLy = false;
                //item.tblTaiSanCoDinhCaBiet.MaNghiepVuThanhLy = null;
            }
            //clear chi tiết
            BaseFactory<Entities, tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD>.DeleteHelper(context, nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD);

            //xóa nghiệp vụ
            context.DeleteObject(nghiepVu);

        }
       
        #endregion
    }//end class
}
