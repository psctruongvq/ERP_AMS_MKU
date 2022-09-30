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
namespace PSC_ERP_Business.Main.Factory//
{
    public partial class DigitizingBag_Factory : BaseFactory<Entities, DigitizingBag>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return DigitizingBag_Factory.New().CreateAloneObject();
        }
        public static DigitizingBag_Factory New()
        {
            return new DigitizingBag_Factory();
        }
        public DigitizingBag_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        //bổ sung ngày 18/01/2016
        public DigitizingBag LayCapChaCuaFile(int maBoPhan, int loaiChungTu, int nam)
        {
            DigitizingBag dig = (from o in this.ObjectSet
                                 where o.MaBoPhan == maBoPhan
                                 && o.CapDoCay == 3
                                 && (o.IsFile ?? false) == false
                                 && o.MaLoaiChungTu == loaiChungTu
                                 && o.FolderYear == nam
                                 select o).SingleOrDefault<DigitizingBag>();
            return dig;
        }
        //25/01/2016
        public IQueryable<DigitizingBag> TimFile(int maBoPhan, int loaiChungTu, int nam)
        {
            IQueryable<DigitizingBag> dig = from o in this.ObjectSet
                                            where (o.MaBoPhan == maBoPhan || maBoPhan == 0)
                                            && (o.IsFile ?? false) == true
                                            && (o.MaLoaiChungTu == loaiChungTu || loaiChungTu == 0)
                                            && (o.FolderYear == nam || nam == 0)
                                            select o;
            return dig;
        }
        //-----------------------------------------
        public override IQueryable<DigitizingBag> GetAll()
        {
            IQueryable<DigitizingBag> query = from o in ObjectSet orderby o.Name select o;
            return query;
        }
        public DigitizingBag GetById(Guid id)
        {
            DigitizingBag obj = this.ObjectSet.SingleOrDefault(o => o.BagId == id);
            return obj;
        }

        public static IQueryable<DigitizingBag> GetAllFileList_ByYear_MaBoPhan(IQueryable<DigitizingBag> fullList, Int32? nam, Int32? maBoPhan)
        {
            Boolean tatCaNam = (nam ?? 0) == 0;
            Boolean tatCaBoPhan = (maBoPhan ?? 0) == 0;
            IQueryable<DigitizingBag> objList = fullList.Where(o => o.IsFile == true);
            //    && (tatCaBoPhan
            //            || (o.tblChungTu.app_users.MaBoPhan == maBoPhan && (tatCaNam || o.tblChungTu.NgayLap.Value.Year == nam))
            //            || (o.tblChungTuImport.MaBoPhan == maBoPhan && (tatCaNam || o.tblChungTuImport.NgayLap.Value.Year == nam))
            //            || (o.tblPhieuNhapXuat.app_users.MaBoPhan == maBoPhan && (tatCaNam || o.tblPhieuNhapXuat.NgayNX.Year == nam))
            //            || (o.tblHopDong.app_users.MaBoPhan == maBoPhan && (tatCaNam || o.tblHopDong.NgayKy.Value.Year == nam))
            //       )
            //   );
            return objList;
        }
        public IQueryable<DigitizingBag> GetAllFileList()
        {
            IQueryable<DigitizingBag> objList = this.ObjectSet.Where(o => o.IsFile == true);
            return objList;
        }
        public IQueryable<DigitizingBag> FindFileBag_ByTitleContain(String titleContain)
        {
            String lowerTitleContain = titleContain.Trim().ToLower();
            IQueryable<DigitizingBag> objList = this.ObjectSet.Where(o => o.IsFile == true && o.Name.ToLower().Contains(lowerTitleContain));
            return objList;
        }
        public static IQueryable<DigitizingBag> GetListByIdList(IQueryable<DigitizingBag> fullList, List<Guid> idList)
        {
            IQueryable<DigitizingBag> objList = fullList.Where(o => idList.Any(x => x == o.BagId));
            return objList;
        }
        public static ParallelQuery<DigitizingBag> GetListByIdListParallel(ParallelQuery<DigitizingBag> fullList, List<Guid> idList)
        {
            ParallelQuery<DigitizingBag> objList = fullList.Where(o => idList.Any(x => x == o.BagId));
            return objList;
        }
        public IQueryable<DigitizingBag> GetListByIdList(List<Guid> idList)
        {
            IQueryable<DigitizingBag> objList = this.ObjectSet.Where(o => idList.Any(x => x == o.BagId));
            return objList;
        }

        public List<DigitizingBag> LayFileKhongCoChungTu_BoPhan_Nam(Int32? maBoPhan, Int32? nam, Int32? maLoaiChungTu, Int64? maChungTu)
        {
            List<DigitizingBag> dsFile = this.ObjectSet.Where(x => x.MaBoPhan == maBoPhan && x.FolderYear == nam && x.MaLoaiChungTu == maLoaiChungTu && (x.MaChungTu == maChungTu || maChungTu == 0)) as List<DigitizingBag>;
            return dsFile;
        }
       
        //lấy file theo mã chứng từ và số chứng từ
        public IQueryable<DigitizingBag> LayFileTheoMaChungTu_SoChungTu(Int64? maChungTu, String soChungTu)
        {
            IQueryable<DigitizingBag> dsFile = this.ObjectSet.Where(x => x.MaChungTu.Value == maChungTu && x.SoChungTu.Contains(soChungTu));
            return dsFile;
        }
        //public static IQueryable<DigitizingBag> GetListBy_tblChungTu_MaChungTu(IQueryable<DigitizingBag> fullList, Int32? nam, Int32? maBoPhan, Int32 maLoaiChungTu, Int64? maChungTu)
        //{
        //    //Boolean tatCaNam = (nam ?? 0) == 0;
        //    //Boolean tatCaBoPhan = (maBoPhan ?? 0) == 0;
        //    //Boolean tatCaMaChungTu = (maChungTu ?? 0) == 0;
        //    //IQueryable<DigitizingBag> objList = from o in fullList
        //    //                                    where
        //    //                                    (o.IsFile == true)
        //    //                                    && (tatCaNam || o.tblChungTu.NgayLap.Value.Year == nam)
        //    //                                    && (tatCaBoPhan || o.tblChungTu.app_users.MaBoPhan == maBoPhan)
        //    //                                    && o.tblChungTu.MaLoaiChungTu == maLoaiChungTu
        //    //                                    && (tatCaMaChungTu || o.File_tblChungTu_MaChungTu == maChungTu)
        //    //                                    orderby o.Name ascending
        //    //                                    select o;
        //    IQueryable<DigitizingBag> objList=from o in fullList;
        //    return objList;
        //}
        //public IQueryable<DigitizingBag> GetListBy_tblChungTu_MaChungTu(Int32? nam, Int32? maBoPhan, Int32 maLoaiChungTu, Int64? maChungTu)
        //{
        //    Boolean tatCaNam = (nam ?? 0) == 0;
        //    Boolean tatCaBoPhan = (maBoPhan ?? 0) == 0;
        //    Boolean tatCaMaChungTu = (maChungTu ?? 0) == 0;
        //    IQueryable<DigitizingBag> objList = from o in this.ObjectSet
        //                                        where
        //                                        (o.IsFile == true)
        //                                        && (tatCaNam || o.tblChungTu.NgayLap.Value.Year == nam)
        //                                        && (tatCaBoPhan || o.tblChungTu.app_users.MaBoPhan == maBoPhan)
        //                                        && o.tblChungTu.MaLoaiChungTu == maLoaiChungTu
        //                                        && (tatCaMaChungTu || o.File_tblChungTu_MaChungTu == maChungTu)
        //                                        orderby o.Name ascending
        //                                        select o;
        //    return objList;
        //}
        //public static IQueryable<DigitizingBag> GetListBy_tblChungTuImport_MaChungTu(IQueryable<DigitizingBag> fullList, Int32? nam, Int32? maBoPhan, Int32 maLoaiChungTu, Int64? maChungTu)
        //{
        //    Boolean tatCaNam = (nam ?? 0) == 0;
        //    Boolean tatCaBoPhan = (maBoPhan ?? 0) == 0;
        //    Boolean tatCaMaChungTu = (maChungTu ?? 0) == 0;
        //    IQueryable<DigitizingBag> objList = from o in fullList
        //                                        where
        //                                        (o.IsFile == true)
        //                                        && (tatCaNam || o.tblChungTuImport.NgayLap.Value.Year == nam)
        //                                        && (tatCaBoPhan || o.tblChungTuImport.MaBoPhan == maBoPhan)
        //                                        && (o.tblChungTuImport.MaLoaiChungTu ?? 0) == maLoaiChungTu
        //                                        && (tatCaMaChungTu || o.File_tblChungTuImport_MaChungTu == maChungTu)
        //                                        orderby o.Name ascending
        //                                        select o;
        //    return objList;
        //}
        //public IQueryable<DigitizingBag> GetListBy_tblChungTuImport_MaChungTu(Int32? nam, Int32? maBoPhan, Int32 maLoaiChungTu, Int64? maChungTu)
        //{
        //    Boolean tatCaNam = (nam ?? 0) == 0;
        //    Boolean tatCaBoPhan = (maBoPhan ?? 0) == 0;
        //    Boolean tatCaMaChungTu = (maChungTu ?? 0) == 0;
        //    IQueryable<DigitizingBag> objList = from o in this.ObjectSet
        //                                        where
        //                                        (o.IsFile == true)
        //                                        && (tatCaNam || o.tblChungTuImport.NgayLap.Value.Year == nam)
        //                                        && (tatCaBoPhan || o.tblChungTuImport.MaBoPhan == maBoPhan)
        //                                        && (o.tblChungTuImport.MaLoaiChungTu ?? 0) == maLoaiChungTu
        //                                        && (tatCaMaChungTu || o.File_tblChungTuImport_MaChungTu == maChungTu)
        //                                        orderby o.Name ascending
        //                                        select o;
        //    return objList;
        //}
        //public static IQueryable<DigitizingBag> GetListBy_tblPhieuNhapXuat_MaPhieuNhapXuat(IQueryable<DigitizingBag> fullList, Int32? nam, Int32? maBoPhan, Boolean laNhap, Int64? maPhieuNhapXuat)
        //{
        //    Boolean tatCaNam = (nam ?? 0) == 0;
        //    Boolean tatCaBoPhan = (maBoPhan ?? 0) == 0;
        //    Boolean tatCaMaPhieuNhapXuat = (maPhieuNhapXuat ?? 0) == 0;
        //    IQueryable<DigitizingBag> objList = from o in fullList
        //                                        where
        //                                        (o.IsFile == true)
        //                                        && (tatCaNam || o.tblPhieuNhapXuat.NgayNX.Year == nam)
        //                                        && (tatCaBoPhan || o.tblPhieuNhapXuat.app_users.MaBoPhan == maBoPhan)
        //                                        && ((o.File_tblPhieuNhapXuat_MaPhieuNhapXuat ?? 0) != 0 && (o.tblPhieuNhapXuat.LaNhap ?? false) == laNhap)
        //                                        && (tatCaMaPhieuNhapXuat || o.File_tblPhieuNhapXuat_MaPhieuNhapXuat == maPhieuNhapXuat)
        //                                        orderby o.Name ascending
        //                                        select o;
        //    return objList;
        //}
        //public IQueryable<DigitizingBag> GetListBy_tblPhieuNhapXuat_MaPhieuNhapXuat(Int32? nam, Int32? maBoPhan, Boolean laNhap, Int64? maPhieuNhapXuat)
        //{
        //    Boolean tatCaNam = (nam ?? 0) == 0;
        //    Boolean tatCaBoPhan = (maBoPhan ?? 0) == 0;
        //    Boolean tatCaMaPhieuNhapXuat = (maPhieuNhapXuat ?? 0) == 0;
        //    IQueryable<DigitizingBag> objList = from o in this.ObjectSet
        //                                        where
        //                                        (o.IsFile == true)
        //                                        && (tatCaNam || o.tblPhieuNhapXuat.NgayNX.Year == nam)
        //                                        && (tatCaBoPhan || o.tblPhieuNhapXuat.app_users.MaBoPhan == maBoPhan)
        //                                        && ((o.File_tblPhieuNhapXuat_MaPhieuNhapXuat ?? 0) != 0 && (o.tblPhieuNhapXuat.LaNhap ?? false) == laNhap)
        //                                        && (tatCaMaPhieuNhapXuat || o.File_tblPhieuNhapXuat_MaPhieuNhapXuat == maPhieuNhapXuat)
        //                                        orderby o.Name ascending
        //                                        select o;
        //    return objList;
        //}
        //public static IQueryable<DigitizingBag> GetListBy_tblHopDong_MaHopDong(IQueryable<DigitizingBag> fullList, Int32? nam, Int32? maBoPhan, Boolean hdBenNgoai, Int64? maHopDong)
        //{
        //    Boolean tatCaNam = (nam ?? 0) == 0;
        //    Boolean tatCaBoPhan = (maBoPhan ?? 0) == 0;
        //    Boolean tatCaMaHopDong = (maHopDong ?? 0) == 0;
        //    IQueryable<DigitizingBag> objList = from o in fullList
        //                                        where
        //                                        (o.IsFile == true)
        //                                        && (tatCaNam || o.tblHopDong.NgayKy.Value.Year == nam)
        //                                        && (tatCaBoPhan || o.tblHopDong.app_users.MaBoPhan == maBoPhan)
        //                                        && ((o.File_tblHopDong_MaHopDong ?? 0) != 0 && (o.tblHopDong.tblHopDongMuaBan.HDTrongNgoaiDai ?? false) == hdBenNgoai)
        //                                        && (tatCaMaHopDong || o.File_tblHopDong_MaHopDong == maHopDong)
        //                                        orderby o.Name ascending
        //                                        select o;
        //    return objList;
        //}
        //public IQueryable<DigitizingBag> GetListBy_tblHopDong_MaHopDong(Int32? nam, Int32? maBoPhan, Boolean hdBenNgoai, Int64? maHopDong)
        //{
        //    Boolean tatCaNam = (nam ?? 0) == 0;
        //    Boolean tatCaBoPhan = (maBoPhan ?? 0) == 0;
        //    Boolean tatCaMaHopDong = (maHopDong ?? 0) == 0;
        //    IQueryable<DigitizingBag> objList = from o in this.ObjectSet
        //                                        where
        //                                        (o.IsFile == true)
        //                                        && (tatCaNam || o.tblHopDong.NgayKy.Value.Year == nam)
        //                                        && (tatCaBoPhan || o.tblHopDong.app_users.MaBoPhan == maBoPhan)
        //                                        && ((o.File_tblHopDong_MaHopDong ?? 0) != 0 && (o.tblHopDong.tblHopDongMuaBan.HDTrongNgoaiDai ?? false) == hdBenNgoai)
        //                                        && (tatCaMaHopDong || o.File_tblHopDong_MaHopDong == maHopDong)
        //                                        orderby o.Name ascending
        //                                        select o;
        //    return objList;
        //}

        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            //duyệt qua danh sách
            foreach (DigitizingBag item in deleteList)
            {
                //xóa DigitizingFile
                //DigitizingFile_Factory.FullDelete(context, item.DigitizingFiles.ToList<Object>());
                //xóa
                context.DigitizingBags.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
