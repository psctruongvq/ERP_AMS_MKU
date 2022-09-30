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
using System.Collections;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Common;

namespace PSC_ERP_Business.Main.Factory
{
    public partial class ButToan_Factory : BaseFactory<Entities, tblButToan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ButToan_Factory.New().CreateAloneObject();
        }
        public static ButToan_Factory New()
        {
            return new ButToan_Factory();
        }
        public ButToan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblButToan Get_ButToanByMaButToan(Int32 maButToan)
        {
            tblButToan obj = (from o in this.ObjectSet
                              where o.MaButToan == maButToan
                              select o).SingleOrDefault();
            return obj;
        }

        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            foreach (tblButToan butToan in deleteList)
            {
                //xóa chứng từ hóa đơn của bút toán
                ChungTu_HoaDon_Factory.FullDelete(context, butToan.tblChungTu_HoaDon.ToList<Object>());
                //xóa bút toán mục ngân sách
                BaseFactory<Entities, tblButToan_MucNganSach>.DeleteHelper(context, butToan.tblButToan_MucNganSach);

                //xóa chi phi san xuat
                CT_ChiPhiSanXuat_Factory.FullDelete(context, butToan.tblCT_ChiPhiSanXuat.ToList<Object>());
                //xóa bút toán
                context.tblButToans.DeleteObject(butToan);
            }

        }

        public void CapNhatButToanCacChungTuDaKCCP(long maChungTu, int userID, bool isDelete)
        {
            //try
            //{
            Hashtable output = new Hashtable();
            SpeedDataAccess execNonQuery = new SpeedDataAccess(Database.NormalConnectionString);
            execNonQuery.ExecuteNonQueryStore(out output, "spd_CapNhatButtoanChungTuDaKCCP"
                                                , new string[] { "@MaChungTu", "@UserID", "@IsDelete" }
                                                                , maChungTu, userID, isDelete);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }


        public static void FullDeleteKiemTraKhoaTaiKhoan(Entities context, List<Object> deleteList, int userID, int maKy)
        {
            foreach (tblButToan butToan in deleteList)
            {
                if (TaiKhoan_Factory.New().DaKhoaTaiKhoan(maKy, userID, butToan.CoTaiKhoan.Value) || TaiKhoan_Factory.New().DaKhoaTaiKhoan(maKy, userID, butToan.NoTaiKhoan.Value))
                {
                    DialogUtil.ShowError("Không thể xóa bỏ định khoản vì có tài khoản đã khóa sổ!");
                }
                else
                {
                    //xóa chứng từ hóa đơn của bút toán
                    ChungTu_HoaDon_Factory.FullDelete(context, butToan.tblChungTu_HoaDon.ToList<Object>());
                    //xóa bút toán mục ngân sách
                    BaseFactory<Entities, tblButToan_MucNganSach>.DeleteHelper(context, butToan.tblButToan_MucNganSach);

                    //xóa chi phi san xuat
                    CT_ChiPhiSanXuat_Factory.FullDelete(context, butToan.tblCT_ChiPhiSanXuat.ToList<Object>());
                    //xóa bút toán
                    context.tblButToans.DeleteObject(butToan);
                }
            }

        }
        #endregion
    }//end class
}
