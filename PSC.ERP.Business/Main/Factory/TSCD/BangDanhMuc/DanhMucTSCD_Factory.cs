using System;
using System.Collections.Generic;
using System.Linq;
using PSC_ERP_Core;
using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using ERP_Library.Security;

namespace PSC_ERP_Business.Main.Factory
{
    public class DanhMucTSCD_Factory : BaseFactory<Entities, tblDanhMucTSCD>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return DanhMucTSCD_Factory.New().CreateAloneObject();
        }
        public static DanhMucTSCD_Factory New()
        {
            return new DanhMucTSCD_Factory();
        }
        public DanhMucTSCD_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        //Số hiệu /////////////////////////////////////////////////////////////////
        #region Số hiệu
        #region Số hiệu loại tài sản
        public static String IncreaseMaQuanLyLoaiTaiSan(String soHieu)
        {

            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaLoaiTaiSanQuanLy_IncreasePart;
            string leftPart = soHieu.Substring(0, soHieu.Length - 4);

            string soHieuMoi = "";//String.Format("{0}{1}1", leftPart, new String('0', sizeOfNumber - 1));


            int max = int.Parse(soHieu.Substring(soHieu.Length - sizeOfNumber, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();

            soHieuMoi = leftPart + stringSoMoi;


            return soHieuMoi;

        }
        public String CreateFirst_MaQuanLyLoaiTaiSan(String soHieuCapTren)
        {
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaLoaiTaiSanQuanLy_IncreasePart;


            result = String.Format("{0}{1}1", soHieuCapTren, new String('0', sizeOfNumber - 1));

            return result;
        }
        public String Create_MaQuanLyLoaiTaiSan(String soHieuCapTren, Int32 index)
        {
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaLoaiTaiSanQuanLy_IncreasePart;

            String indexString = index.ToString();
            result = String.Format("{0}{1}{2}", soHieuCapTren, new String('0', sizeOfNumber - indexString.Length), indexString);

            return result;
        }
        #endregion
        // ////////////

        #region Số hiệu TSCD
        public static String IncreaseMaQuanLyTSCD(String soHieu)
        {

            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaTSCDQuanLy_IncreasePart;
            string leftPart = soHieu.Substring(0, soHieu.Length - 4);

            string soHieuMoi = "";//String.Format("{0}{1}1", leftPart, new String('0', sizeOfNumber - 1));


            int max = int.Parse(soHieu.Substring(soHieu.Length - sizeOfNumber, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();

            soHieuMoi = leftPart + stringSoMoi;


            return soHieuMoi;

        }
        public String CreateFirst_MaQuanLyTSCD(String soHieuCapTren)
        {
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaTSCDQuanLy_IncreasePart;


            result = String.Format("{0}{1}1", soHieuCapTren, new String('0', sizeOfNumber - 1));

            return result;
        }
        public String Create_MaQuanLyTSCD(String soHieuCapTren, Int32 index)
        {
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaTSCDQuanLy_IncreasePart;
            String indexString = index.ToString();
            
            result = String.Format("{0}{1}{2}", soHieuCapTren, new String('0', sizeOfNumber - indexString.Length), indexString);
            //05/11/2020 
            //result = soHieuCapTren   + string.Format("{0:00000}",index);

            return result;
        }
        // // 20/11/2020 bổ sung mã công ty 
        public String Get_MaxSoHieuLoaiTS_ByMaCapTrenTrucTiep(int maCapTren, int MaCongTy=0)
        {
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaLoaiTaiSanQuanLy_IncreasePart;
            String soHieu = (from o in this.ObjectSet
                             where o.ParentID == maCapTren
                                && o.MaCongTy== MaCongTy 
                              && o.LaLoaiTaiSan == true
                             orderby o.MaQuanLy.Substring(o.MaQuanLy.Length - sizeOfNumber, sizeOfNumber) descending
                             select o.MaQuanLy).FirstOrDefault();

            return soHieu;
        }
        // 20/11/2020 bổ sung mã công ty 
        public String Get_MaxSoHieuTSCD_ByMaLoaiCapTrenTrucTiep(int maLoaiTS, int MaCongTy=0)
        {
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaTSCDQuanLy_IncreasePart;
            String soHieu = (from o in this.ObjectSet
                             where o.ParentID == maLoaiTS
                             && o.MaCongTy == MaCongTy
                             && o.LaTaiSanCoDinh == true
                             orderby o.MaQuanLy.Substring(o.MaQuanLy.Length - sizeOfNumber, sizeOfNumber) descending
                             select o.MaQuanLy).FirstOrDefault();

            return soHieu;
        }
        #endregion

        #endregion

       
        public IQueryable<tblDanhMucTSCD> Get_OneItemList_NhomTaiSan_ByMaNhomTaiSan(int maNhomTaiSan)
        {

            IQueryable<tblDanhMucTSCD> query = (from o in this.ObjectSet
                                                where o.LaNhomTaiSan.Value == true
                                                 && o.ID == maNhomTaiSan
                                                select o);
            return query;
        }
        public IQueryable<tblDanhMucTSCD> Get_DanhSachNhomTaiSan_CuaTaiSanChuaThanhLy_ByMaPhongBan(Int32 maPhongBan)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);



            IQueryable<tblDanhMucTSCD> dsTaiSan = from o in this.ObjectSet
                                                  where o.LaTaiSanCoDinh.Value == true

                                                 && (o.tblTaiSanCoDinhCaBiets.Any(x => (x.ThanhLy ?? false) == false && phanBoTheoPhongBanList.Any(phanBo => phanBo.MaTSCDCaBiet == x.MaTSCDCaBiet)))
                                                  orderby o.MaQuanLy
                                                  select o;

            IQueryable<tblDanhMucTSCD> dsLoai = from o in this.ObjectSet
                                                where o.LaLoaiTaiSan == true
                                                && o.tblDanhMucTSCD1.Any(x => dsTaiSan.Any(ts => ts.ID == x.ID))
                                                select o;

            IQueryable<tblDanhMucTSCD> dsNhom = from o in this.ObjectSet
                                                where o.LaNhomTaiSan == true
                                                && o.tblDanhMucTSCD1.Any(x => dsLoai.Any(loai => loai.LoaiTaiSanThuocNhomTaiSan == x.LoaiTaiSanThuocNhomTaiSan))
                                                select o;

            return dsNhom;
        }
        public tblDanhMucTSCD Get_NhomTaiSan_ByMaNhomTaiSan(int maLoaiTaiSan)
        {
            tblDanhMucTSCD obj = (from o in this.ObjectSet
                                  where o.LaNhomTaiSan.Value == true
                                   && o.ID == maLoaiTaiSan
                                  select o).SingleOrDefault();
            return obj;
        }

        public tblDanhMucTSCD Get_NhomTaiSan_ByMaQuanLy(String maQuanLy)
        {
            tblDanhMucTSCD obj = (from o in this.ObjectSet
                                  where o.LaNhomTaiSan.Value == true
                                   && o.MaQuanLy == maQuanLy
                                  select o).SingleOrDefault();
            return obj;
        }
      
        public Boolean XacDinhNhomTaiSan_CoTSCDCaBiet(int maNhomTaiSan)
        {
            String maNhomTaiSanQuanLy = (from dm in Context.tblDanhMucTSCDs where dm.ID == maNhomTaiSan && dm.LaNhomTaiSan == true select dm.MaQuanLy).SingleOrDefault();
            Boolean query = (from o in this.Context.tblTaiSanCoDinhCaBiets
                             where o.tblDanhMucTSCD.MaQuanLy.StartsWith(maNhomTaiSanQuanLy)
                             select true).FirstOrDefault();
            return query;
        }
        public IQueryable<tblDanhMucTSCD> Get_DanhSachNhomLoaiTaiSan()
        {
            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where (o.LaNhomTaiSan.Value == true || o.LaLoaiTaiSan.Value == true)
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////
        public IQueryable<tblDanhMucTSCD> Get_DanhSachLoaiTaiSan_CuaTaiSanChuaThanhLy_ByMaPhongBanAndMaNhomTS(Int32 maPhongBan, Int32 maNhomTS)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);

            IQueryable<tblDanhMucTSCD> dsTaiSan = from o in this.ObjectSet
                                                  where o.LaTaiSanCoDinh.Value == true

                                                 && (o.tblTaiSanCoDinhCaBiets.Any(x => (x.ThanhLy ?? false) == false && phanBoTheoPhongBanList.Any(phanBo => phanBo.MaTSCDCaBiet == x.MaTSCDCaBiet)))
                                                  orderby o.MaQuanLy
                                                  select o;

            IQueryable<tblDanhMucTSCD> dsLoai = from o in this.ObjectSet
                                                where o.LaLoaiTaiSan == true
                                                && o.tblDanhMucTSCD1.Any(x => dsTaiSan.Any(ts => ts.ID == x.ID))
                                                && (maNhomTS == 0 || o.LoaiTaiSanThuocNhomTaiSan == maNhomTS)
                                                select o;
            return dsLoai;
        }
        public IQueryable<tblDanhMucTSCD> Get_DanhSachLoaiTaiSan()
        {
            //IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
            //                                   where o.LaLoaiTaiSan.Value == true
            //                                   orderby o.MaQuanLy
            //                                   select o;
            IQueryable<tblDanhMucTSCD> query = (from o in this.ObjectSet
                                                where o.LaLoaiTaiSan.Value == true && o.DungChung.Value == true
                                                orderby o.MaQuanLy
                                                select o).Union((from o in this.ObjectSet
                                                                 where o.LaLoaiTaiSan.Value == true && o.MaCongTy.Value == CurrentUser.Info.MaCongTy
                                                                 orderby o.MaQuanLy
                                                                 select o));
            return query;
        }

        public IQueryable<tblDanhMucTSCD> Get_DanhSachLoaiTaiSan_ByMaNhomTaiSan(int maNhomTaiSan)
        {
            String maNhomTaiSanQuanLy = (from dm in Context.tblDanhMucTSCDs where dm.ID == maNhomTaiSan && dm.LaNhomTaiSan == true select dm.MaQuanLy).SingleOrDefault();

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.MaQuanLy.StartsWith(maNhomTaiSanQuanLy)
                                               &&
                                               o.LoaiTaiSanThuocNhomTaiSan == maNhomTaiSan
                                               && o.LaLoaiTaiSan == true

                                               select o;
            return query;
        }



        public IQueryable<tblDanhMucTSCD> Get_DanhSachLoaiTaiSan_CoTSCD_ByMaNhomTaiSan(int maNhomTaiSan)
        {
            String maNhomTaiSanQuanLy = (from dm in Context.tblDanhMucTSCDs where dm.ID == maNhomTaiSan && dm.LaNhomTaiSan == true select dm.MaQuanLy).SingleOrDefault();

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.MaQuanLy.StartsWith(maNhomTaiSanQuanLy)
                                               &&
                                               o.LoaiTaiSanThuocNhomTaiSan == maNhomTaiSan
                                               && o.LaLoaiTaiSan == true
                                               && o.tblDanhMucTSCD1.Any(x => x.LaTaiSanCoDinh == true)
                                               //&& o.ID == (from x in this.ObjectSet
                                               //            where x.LaTaiSanCoDinh == true
                                               //             && o.ID == x.ParentID
                                               //            select x.ID).FirstOrDefault()

                                               select o;
            return query;
        }
        public IQueryable<tblDanhMucTSCD> Get_OneItemList_LoaiTaiSan_ByMaLoaiTaiSan(int maLoaiTaiSan)
        {
            IQueryable<tblDanhMucTSCD> query = (from o in this.ObjectSet
                                                where o.LaLoaiTaiSan.Value == true
                                                 && o.ID == maLoaiTaiSan
                                                select o);
            return query;
        }
        public tblDanhMucTSCD Get_LoaiTaiSan_ByMaLoaiTaiSan(int maLoaiTaiSan)
        {
            tblDanhMucTSCD obj = (from o in this.ObjectSet
                                  where o.LaLoaiTaiSan.Value == true
                                   && o.ID == maLoaiTaiSan
                                  select o).SingleOrDefault();
            return obj;
        }

        public tblDanhMucTSCD Get_LoaiTaiSan_ByMaQuanLy(String maQuanLy)
        {
            tblDanhMucTSCD obj = (from o in this.ObjectSet
                                  where o.LaLoaiTaiSan.Value == true
                                   && o.MaQuanLy == maQuanLy
                                  select o).SingleOrDefault();
            return obj;
        }
        
        public tblDanhMucTSCD Get_DanhMuc_ByMaQuanLy(String maQuanLy)
        {
            tblDanhMucTSCD obj = (from o in this.ObjectSet
                                  where  o.MaQuanLy == maQuanLy
                                  select o).SingleOrDefault();
            return obj;
        }
        public tblDanhMucTSCD Get_DanhMuc_ByMaQuanLy_And_MaCongTy(String maQuanLy, int maCongTy)
        {
            tblDanhMucTSCD obj = (from o in this.ObjectSet
                                  where (o.MaQuanLy == maQuanLy && (o.MaCongTy==maCongTy|| o.DungChung.Value) && o.LaTaiSanCoDinh == true)
                                  select o).SingleOrDefault();
            return obj;
        }
        public Boolean XacDinhLoaiTaiSan_CoTSCDCaBiet(int maLoaiTaiSan)
        {
            String maLoaiTaiSanQuanLy = (from dm in Context.tblDanhMucTSCDs where dm.ID == maLoaiTaiSan && dm.LaLoaiTaiSan == true select dm.MaQuanLy).SingleOrDefault();

            Boolean query = (from o in this.Context.tblTaiSanCoDinhCaBiets
                             where o.tblDanhMucTSCD.MaQuanLy.StartsWith(maLoaiTaiSanQuanLy)
                             select true).FirstOrDefault();
            return query;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////
        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_CuaTaiSanChuaThanhLy_ByMaPhongBanAndMaNhomTSAndMaLoaiTS(Int32 maPhongBan, Int32 maNhomTS, Int32 maLoaiTS)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);



            IQueryable<tblDanhMucTSCD> dsTaiSan = from o in this.ObjectSet
                                                  where o.LaTaiSanCoDinh.Value == true

                                                 && (o.tblTaiSanCoDinhCaBiets.Any(x => (x.ThanhLy ?? false) == false && phanBoTheoPhongBanList.Any(phanBo => phanBo.MaTSCDCaBiet == x.MaTSCDCaBiet)))
                                                 && (maNhomTS == 0 || o.tblDanhMucTSCD2.LoaiTaiSanThuocNhomTaiSan == maNhomTS)
                                                 && (maLoaiTS == 0 || o.ParentID == maLoaiTS)
                                                  orderby o.MaQuanLy
                                                  select o;

            return dsTaiSan;
        }
        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh()
        {

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }

        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_ByMaPhongBanAndLoaiTaiSan()
        {

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }

        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_TrucTiep_ByMaLoaiTaiSan(int maLoaiTaiSan)
        {
            int maCongTy = CurrentUser.Info.MaCongTy;
            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                                && o.ParentID == maLoaiTaiSan &&(o.DungChung.Value==true || o.MaCongTy==maCongTy)
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }
        public IQueryable<tblDanhMucTSCD> Get_OneItemList_TaiSanCoDinh_ByMaTSCD(int maTaiSanCoDinh)
        {

            IQueryable<tblDanhMucTSCD> query = (from o in this.ObjectSet
                                                where o.LaTaiSanCoDinh.Value == true
                                                 && o.ID == maTaiSanCoDinh
                                                select o);
            return query;
        }
        public tblDanhMucTSCD Get_TaiSanCoDinh_ByMaTSCD(int maTaiSanCoDinh)
        {

            tblDanhMucTSCD obj = (from o in this.ObjectSet
                                  where o.LaTaiSanCoDinh.Value == true
                                   && o.ID == maTaiSanCoDinh
                                  select o).SingleOrDefault();
            return obj;
        }
        public tblDanhMucTSCD Get_TaiSanCoDinh_ByMaQuanLy(String maQuanLy, int maCongTy)
        {
            tblDanhMucTSCD obj = (from o in this.ObjectSet
                                  where o.LaTaiSanCoDinh.Value == true
                                   && o.MaQuanLy == maQuanLy && o.MaCongTy.Value == maCongTy
                                  select o).SingleOrDefault();
            return obj;
        }

        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_KhongCoTSCDCaBiet()
        {

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                                && o.tblTaiSanCoDinhCaBiets.Count == 0
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }
        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_CoTSCDCaBiet()
        {

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                                && o.tblTaiSanCoDinhCaBiets.Count > 0
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }

        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_CoTSCDCaBietChuaThanhLy()
        {
            int maCongTy = CurrentUser.Info.MaCongTy;
            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                                   && (o.MaCongTy==maCongTy || o.DungChung.Value==true)
                                                && o.tblTaiSanCoDinhCaBiets.Any(x => (x.ThanhLy ?? false) == false)
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }
        //sửa ngày 04/03/2016 
        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_CoTSCDCaBietChuaThanhLy_ByMaPhongBan(int maPhongBan)
        {

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               join pb in this.Context.tblTaiSanCoDinhCaBiet_PhongBan on o.ID equals pb.MaTSCDCaBiet
                                               where o.LaTaiSanCoDinh.Value == true
                                                   //&& o.tblTaiSanCoDinhCaBiets.Count > 0
                                                && o.tblTaiSanCoDinhCaBiets.Any(x => (x.ThanhLy ?? false) == false)
                                               orderby pb.NgayPhanBo descending
                                               select o;
            return query;
        }
        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanTheoMaCongTy(int maCongTy)
        {
            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where (o.DungChung.Value == true || o.MaCongTy.Value == maCongTy)
                                               orderby o.MaQuanLy
                                               select o;

            return query;
        }

        public IQueryable<tblDanhMucTSCD> Get_DanhSachNhomTaiSan()
        {

            IQueryable<tblDanhMucTSCD> query = (from o in this.ObjectSet
                                               where o.LaNhomTaiSan.Value == true &&  o.DungChung.Value == true
                                               orderby o.MaQuanLy
                                               select o).Union((from o in this.ObjectSet
                                                                where o.LaNhomTaiSan.Value == true && o.MaCongTy.Value == CurrentUser.Info.MaCongTy
                                                                orderby o.MaQuanLy
                                                                select o));
            return query;
        }
       
        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_NamTrongDanhSachDangDuyetTSCD_ByLoaiNghiepVu(LoaiNghiepVuTaiSanEnum loaiNghiepVu)
        {


            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                                && o.tblTaiSanCoDinhCaBiets.Any(x => x.tblDuyetTSCDs.Any(duyet => (duyet.DaThucHienNghiepVu ?? false) == false && duyet.LoaiNghiepVu == (Int32)loaiNghiepVu))
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }
        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_NamTrongDanhSachDangDuyetTSCD_ByMaPhongBan_AndLoaiNghiepVu(Int32 maPhongBan, LoaiNghiepVuTaiSanEnum loaiNghiepVu)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);


            //(from o in this.Context.tblTaiSanCoDinhCaBiet_PhongBan
            //                                                                 where (o.MaPhongBan == maPhongBan || maPhongBan == 0)
            //                                                                   && o.MaPhanBoSuDung ==
            //                                                                       (from x in this.Context.tblTaiSanCoDinhCaBiet_PhongBan
            //                                                                        where x.MaTSCDCaBiet == o.MaTSCDCaBiet
            //                                                                        orderby x.NgayPhanBo descending, x.MaPhanBoSuDung descending
            //                                                                        select x.MaPhanBoSuDung).FirstOrDefault()
            //                                                                 orderby o.NgayPhanBo ascending, o.MaPhanBoSuDung ascending
            //                                                                 select o);



            //tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);
            //tempFactory.Detach(phanBoTheoPhongBanList);

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                                   //&& o.tblTaiSanCoDinhCaBiets.Count > 0
                                                && o.tblTaiSanCoDinhCaBiets.Any(x => x.tblDuyetTSCDs.Any(duyet => (duyet.DaThucHienNghiepVu ?? false) == false && duyet.LoaiNghiepVu == (Int32)loaiNghiepVu))
                                                && (o.tblTaiSanCoDinhCaBiets.Any(x => phanBoTheoPhongBanList.Any(phanBo => phanBo.MaTSCDCaBiet == x.MaTSCDCaBiet)))
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }

        //bổ sung ngày 21/12/2015
        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_CoTSCB_CT_ConSuDung_ByMaPhongBan(Int32 maPhongBan)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);

            IQueryable<tblDanhMucTSCD> query = (from o in this.ObjectSet
                                                join tscdcb in this.Context.tblTaiSanCoDinhCaBiets on o.ID equals tscdcb.MaTSCD
                                                where o.LaTaiSanCoDinh.Value == true
                                                  && o.tblTaiSanCoDinhCaBiets.Any(x => (x.NgungSuDung ?? false) == false)
                                                 && (o.tblTaiSanCoDinhCaBiets.Any(x => phanBoTheoPhongBanList.Any(phanBo => phanBo.MaTSCDCaBiet == x.MaTSCDCaBiet)))
                                                orderby o.MaQuanLy
                                                select o).Distinct();
            return query;
        }

        //

        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_ConSuDung_ByMaPhongBan(Int32 maPhongBan)
        {//Minh Tài
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                                 && o.tblTaiSanCoDinhCaBiets.Any(x => (x.NgungSuDung ?? false) == false)
                                                && (o.tblTaiSanCoDinhCaBiets.Any(x => phanBoTheoPhongBanList.Any(phanBo => phanBo.MaTSCDCaBiet == x.MaTSCDCaBiet)))
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }

        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_NgungSuDung_ByMaPhongBan(Int32 maPhongBan)
        {//Minh Tài
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                                 && o.tblTaiSanCoDinhCaBiets.Any(x => (x.NgungSuDung ?? false) == true)
                                                && (o.tblTaiSanCoDinhCaBiets.Any(x => phanBoTheoPhongBanList.Any(phanBo => phanBo.MaTSCDCaBiet == x.MaTSCDCaBiet)))
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }

        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_CoPhatSinhNghiepVuGhiTangTSCDCaBiet()
        {

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                                && o.tblTaiSanCoDinhCaBiets.Any(x => (x.MaChungTuGhiTang ?? 0) != 0)
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }
        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_KhongPhatSinhNghiepVuGhiTangTSCDCaBiet()
        {

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                                && !o.tblTaiSanCoDinhCaBiets.Any(x => (x.MaChungTuGhiTang ?? 0) != 0)
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }

        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_CoPhatSinhNghiepVuThanhLyTSCDCaBiet()
        {

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                                && o.tblTaiSanCoDinhCaBiets.Any(x => (x.MaNghiepVuThanhLy ?? 0) != 0)
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }
        public tblDanhMucTSCD Get_TaiSanCoDinh_ByTenTaiSan_And_MaLoaiTaiSan(string tenTSCD, int maLoaiTaiSan)
        {

            tblDanhMucTSCD obj = (from o in this.ObjectSet
                                  where o.LaTaiSanCoDinh.Value == true
                                   && o.ParentID == maLoaiTaiSan && o.Ten.ToLower() == tenTSCD.ToLower()
                                  select o).SingleOrDefault();
            return obj;
        }
        public IQueryable<tblDanhMucTSCD> Get_DanhSachTaiSanCoDinh_KhongPhatSinhNghiepVuThanhLyTSCDCaBiet()
        {

            IQueryable<tblDanhMucTSCD> query = from o in this.ObjectSet
                                               where o.LaTaiSanCoDinh.Value == true
                                                && !o.tblTaiSanCoDinhCaBiets.Any(x => (x.MaNghiepVuThanhLy ?? 0) != 0)
                                               orderby o.MaQuanLy
                                               select o;
            return query;
        }
        public Boolean XacDinhTaiSanCoDinh_CoTSCDCaBiet(int maTaiSanCoDinh)
        {
            Boolean query = (from o in this.ObjectSet
                             where o.LaTaiSanCoDinh.Value == true
                             && o.ID == maTaiSanCoDinh
                             && o.tblTaiSanCoDinhCaBiets.Any()//&& o.tblTaiSanCoDinhCaBiets.Count > 0
                             select true).SingleOrDefault();
            return query;
        }
        public Boolean XacDinhTaiSanCoDinh_CoTSCDCaBietChuaThanhLy(int maTaiSanCoDinh)
        {
            Boolean query = (from o in this.ObjectSet
                             where o.LaTaiSanCoDinh.Value == true
                                && o.ID == maTaiSanCoDinh
                                 //&& o.tblTaiSanCoDinhCaBiets.Count > 0
                                && o.tblTaiSanCoDinhCaBiets.Any(x => (x.ThanhLy ?? false) == false)
                             select true).SingleOrDefault();
            return query;
        }
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            //xóa
            foreach (tblDanhMucTSCD item in deleteList)
            {
                context.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
