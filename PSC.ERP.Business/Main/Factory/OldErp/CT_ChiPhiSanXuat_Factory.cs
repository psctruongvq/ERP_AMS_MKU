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
    public partial class CT_ChiPhiSanXuat_Factory : BaseFactory<Entities, tblCT_ChiPhiSanXuat>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return CT_ChiPhiSanXuat_Factory.New().CreateAloneObject();
        }
        public static CT_ChiPhiSanXuat_Factory New()
        {
            return new CT_ChiPhiSanXuat_Factory();
        }
        public CT_ChiPhiSanXuat_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public virtual tblCT_ChiPhiSanXuat Get_ByID(long id)
        {
            tblCT_ChiPhiSanXuat obj = (from o in this.ObjectSet
                                       where o.MaCT_ChiPhiSanXuat == id
                                       select o).SingleOrDefault();
            return obj;
        }

        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            foreach (tblCT_ChiPhiSanXuat item in deleteList)
            {
                spd_DanhSachChiPhiSanXuatTheoThang_Result_Factory.New().CapNhatMaButToanChiPhiSanXuat(item.MaCT_ChiPhiSanXuat,0,0,"",false, true);
                //xóa bút toán mục ngân sách
                BaseFactory<Entities, tblButToan_MucNganSach>.DeleteHelper(context, item.tblButToan_MucNganSach);
                //Xoa ChiPhiThuc Hien
                BaseFactory<Entities, tblChiPhiThucHien>.DeleteHelper(context, item.tblChiPhiThucHiens);
                //Xoa ChiThuLao
                BaseFactory<Entities, tblcnChiThuLao>.DeleteHelper(context, item.tblcnChiThuLaos);


                context.tblCT_ChiPhiSanXuat.DeleteObject(item);//N
            }
            //BaseFactory<Entities, tblCT_ChiPhiSanXuat>.DeleteHelper(context, deleteList);//O


        }
        public static void DeleteChildrenCT_ChiPhiSanXuat(Entities context,tblCT_ChiPhiSanXuat ct_ChiPhiSX)
        {
            spd_DanhSachChiPhiSanXuatTheoThang_Result_Factory.New().CapNhatMaButToanChiPhiSanXuat(ct_ChiPhiSX.MaCT_ChiPhiSanXuat, 0, 0, "", false, true);
            //xóa bút toán mục ngân sách
            BaseFactory<Entities, tblButToan_MucNganSach>.DeleteHelper(context, ct_ChiPhiSX.tblButToan_MucNganSach);
            //Xoa ChiPhiThuc Hien
            BaseFactory<Entities, tblChiPhiThucHien>.DeleteHelper(context, ct_ChiPhiSX.tblChiPhiThucHiens);
            //Xoa ChiThuLao
            BaseFactory<Entities, tblcnChiThuLao>.DeleteHelper(context, ct_ChiPhiSX.tblcnChiThuLaos);

            context.tblCT_ChiPhiSanXuat.DeleteObject(ct_ChiPhiSX);
        }

        #endregion
    }//end class
}
