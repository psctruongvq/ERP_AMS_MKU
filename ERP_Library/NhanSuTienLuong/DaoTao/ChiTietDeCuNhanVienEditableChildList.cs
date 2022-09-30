using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietDeCuNhanVienList : Csla.BusinessListBase<ChiTietDeCuNhanVienList, ChiTietDeCuNhanVien>
    {

        #region Factory Methods
        public static ChiTietDeCuNhanVienList NewChiTietDeCuNhanVienList()
        {
            return new ChiTietDeCuNhanVienList();
        }

        internal static ChiTietDeCuNhanVienList GetChiTietDeCuNhanVienList(int maDeCu)
        {
            return new ChiTietDeCuNhanVienList(maDeCu);
        }

        public static ChiTietDeCuNhanVienList GetChiTietDeCuNhanVienList(int maDeCu, int maLopHoc, int loaiVanBang, int maQuocGiaCap, int maTruongDaoTao, int maChuyenNganhDaoTao, int nam, byte sapHetHan, int thoiGianSapHetHan, int maDonViDaoTao)
        {
            return new ChiTietDeCuNhanVienList(maDeCu, maLopHoc, loaiVanBang, maQuocGiaCap, maTruongDaoTao, maChuyenNganhDaoTao,nam,sapHetHan,thoiGianSapHetHan,maDonViDaoTao);
        }

        private ChiTietDeCuNhanVienList()
        {
            MarkAsChild();
        }

        private ChiTietDeCuNhanVienList(int maDeCu, int maLopHoc, int loaiVanBang, int maQuocGiaCap, int maTruongDaoTao, int maChuyenNganhDaoTao, int nam, byte sapHetHan, int thoiGianSapHetHan, int maDonViDaoTao)
        {
            MarkAsChild();
            Fetch(maDeCu, maLopHoc,loaiVanBang,maQuocGiaCap,maTruongDaoTao,maChuyenNganhDaoTao,nam,sapHetHan,thoiGianSapHetHan,maDonViDaoTao);
        }

        private ChiTietDeCuNhanVienList(int maDeCu)
        {
            MarkAsChild();
            Fetch(maDeCu);
        }

        #endregion //Factory Methods


        #region Data Access
        //private void Fetch(SafeDataReader dr)
        //{
        //    RaiseListChangedEvents = false;

        //    while (dr.Read())
        //        this.Add(ChiTietDeCuNhanVien.GetChiTietDeCuNhanVien(dr));

        //    RaiseListChangedEvents = true;
        //}
        private void Fetch(int maDeCu)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsCTDeCuNhanViensbyMaDeCu";
                    cm.Parameters.AddWithValue("@MaDeCu", maDeCu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(ChiTietDeCuNhanVien.GetChiTietDeCuNhanVien(dr));
                        }
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        private void Fetch(int maDeCu, int maLopHoc, int loaiVanBang, int maQuocGiaCap, int maTruongDaoTao, int maChuyenNganhDaoTao, int nam, byte sapHetHan, int thoiGianSapHetHan, int maDonViDaoTao)//R
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsCTDeCuNhanViensbySearch";
                    cm.Parameters.AddWithValue("@MaDeCu", maDeCu);
                    cm.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                    cm.Parameters.AddWithValue("@LoaiVanBang", loaiVanBang);
                    cm.Parameters.AddWithValue("@MaQuocGiaCap", maQuocGiaCap);
                    cm.Parameters.AddWithValue("@MaTruongDaoTao", maTruongDaoTao);
                    cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", maChuyenNganhDaoTao);
                    cm.Parameters.AddWithValue("@Nam", nam);
                    cm.Parameters.AddWithValue("@SapHetHan", sapHetHan);
                    cm.Parameters.AddWithValue("@ThoiGianSapHetHan", thoiGianSapHetHan);
                    cm.Parameters.AddWithValue("@MaDonViDaoTao", maDonViDaoTao);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(ChiTietDeCuNhanVien.GetChiTietDeCuNhanVienSearch(dr));
                        }
                    }
                }
            }
        }

        internal void Update(SqlTransaction tr, DeCu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChiTietDeCuNhanVien deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChiTietDeCuNhanVien child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access

    }
}
