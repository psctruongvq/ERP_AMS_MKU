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
    public class ChiTietTaiSanCaBiet_Factory : BaseFactory<Entities, tblChiTietTaiSanCaBiet>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChiTietTaiSanCaBiet_Factory.New().CreateAloneObject();
        }
        public static ChiTietTaiSanCaBiet_Factory New()
        {
            return new ChiTietTaiSanCaBiet_Factory();
        }
        public ChiTietTaiSanCaBiet_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        //bổ sung ngày 24/12/2015
        public tblChiTietTaiSanCaBiet LaySoHieuSauCung_TheoMaTSCDCB(int maTSCDCB)
        {
            tblChiTietTaiSanCaBiet obj = (from o in this.ObjectSet
                                          where o.MaTSCDCaBiet == maTSCDCB
                                          orderby o.SoHieu descending
                                          select o).FirstOrDefault();
            return obj;
        }

        public tblChiTietTaiSanCaBiet GetChiTietTaiSan_TheoMaTSCDCB_And_TenChiTiet(int maTSCDCB, string tenChiTiet)
        {
            tblChiTietTaiSanCaBiet obj = (from o in this.ObjectSet
                                         where o.MaTSCDCaBiet == maTSCDCB
                                         && o.TenChiTiet.Equals(tenChiTiet)
                                         select o).SingleOrDefault();
            return obj;
        }

        //bổ sung ngày 11/01/2016
        public tblChiTietTaiSanCaBiet GetChiTietTaiSan_TheoMaChiTietTSCDCB(int maChiTietTSCDCB)
        {
            tblChiTietTaiSanCaBiet obj = (from o in this.ObjectSet
                                          where o.MaChiTiet == maChiTietTSCDCB
                                          select o).SingleOrDefault();
            return obj;
        }
        //
        public static String IncreaseSoHieuChiTietTaiSanCaBiet(String soHieu)
        {

            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoHieuChiTietTSCDCaBiet_IncreasePart;
            string leftPart = soHieu.Substring(0, soHieu.Length - sizeOfNumber);

            string soHieuMoi = "";//String.Format("{0}{1}1", leftPart, new String('0', sizeOfNumber - 1));


            int max = int.Parse(soHieu.Substring(soHieu.Length - sizeOfNumber, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();

            soHieuMoi = leftPart + stringSoMoi;


            return soHieuMoi;

        }
        public static String CreateFirst_SoHieuChiTietTaiSanCaBiet(String soHieuCapTren)
        {
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoHieuChiTietTSCDCaBiet_IncreasePart;


            result = String.Format("{0}{1}1", soHieuCapTren, new String('0', sizeOfNumber - 1));

            return result;
        }
        public static String Create_SoHieuChiTietTaiSanCaBiet(String soHieuCapTren, Int32 index)
        {
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoHieuChiTietTSCDCaBiet_IncreasePart;

            String indexString = index.ToString();
            result = String.Format("{0}{1}{2}", soHieuCapTren, new String('0', sizeOfNumber - indexString.Length), indexString);

            return result;
        }


        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            foreach (tblChiTietTaiSanCaBiet item in deleteList)
            {
                //01-xóa chi tiết nguyên giá phát sinh từ nghiệp vụ sửa chữa lớn nếu có
                ChiTietNguyenGiaTSCD_Factory.FullDelete(context, item.tblChiTietNguyenGiaTSCDs.ToList<Object>());//BaseFactory<Entities, tblChiTietNguyenGiaTSCD>.DeleteHelper(context, item.tblChiTietNguyenGiaTSCDs);
                //02-xóa bổ sung chi tiết
                context.tblChiTietTaiSanCaBiets.DeleteObject(item);
            }

        }
        public tblChiTietTaiSanCaBiet Get_ChiTietTaiSanCaBiet_BySoHieu(string soHieu)
        {

            tblChiTietTaiSanCaBiet obj = (from o in this.ObjectSet
                                          where o.SoHieu == soHieu 
                                          select o).SingleOrDefault();
            return obj;
        }
        // 30/11/2020 
        public tblChiTietTaiSanCaBiet Get_ChiTietTaiSanCaBiet_BySoHieu_MaTSCDCB(string soHieu, int maTSCDCaBiet)
        {
            tblChiTietTaiSanCaBiet obj = (from o in this.ObjectSet
                                          where o.SoHieu == soHieu
                                            && o.MaTSCDCaBiet==maTSCDCaBiet
                                          select o).SingleOrDefault();
            return obj;
        }
        public static tblChiTietTaiSanCaBiet BasicCloneChiTietTaiSan(tblChiTietTaiSanCaBiet chiTietTaiSanCaBiet)
        {
            //ghi chú: không copy so hieu
            //so hieu se xu ly sau
            tblChiTietTaiSanCaBiet clonedObject = ChiTietTaiSanCaBiet_Factory.New().CreateAloneObject();
            clonedObject.LaChiTietSuaChuaLon = chiTietTaiSanCaBiet.LaChiTietSuaChuaLon;
            clonedObject.MaChiTietNghiepVuSuaChuaLon = chiTietTaiSanCaBiet.MaChiTietNghiepVuSuaChuaLon;
            clonedObject.MaChiTiet = chiTietTaiSanCaBiet.MaChiTiet;
            clonedObject.MaDVT = chiTietTaiSanCaBiet.MaDVT;
            clonedObject.MaQuocGiaSX = chiTietTaiSanCaBiet.MaQuocGiaSX;
            clonedObject.MaTSCDCaBiet = chiTietTaiSanCaBiet.MaTSCDCaBiet;
            clonedObject.Model = chiTietTaiSanCaBiet.Model;
            clonedObject.NamSanXuat = chiTietTaiSanCaBiet.NamSanXuat;
            clonedObject.NguyenGia = chiTietTaiSanCaBiet.NguyenGia;
            clonedObject.PmCuMaDVT = chiTietTaiSanCaBiet.PmCuMaDVT;
            clonedObject.PmCuMaQuocGiaSX = chiTietTaiSanCaBiet.PmCuMaQuocGiaSX;
            clonedObject.Serial = chiTietTaiSanCaBiet.Serial;

            clonedObject.SoLuong = chiTietTaiSanCaBiet.SoLuong;
            clonedObject.TenChiTiet = chiTietTaiSanCaBiet.TenChiTiet;
            return clonedObject;
        }

        #endregion
    }//end class
}
