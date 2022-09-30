using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DieuChuyenNoiBoCongCuDungCuList : Csla.BusinessListBase<DieuChuyenNoiBoCongCuDungCuList, DieuChuyenNoiBoCongCuDungCu>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DieuChuyenNoiBoCongCuDungCuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChuyenNoiBoCongCuDungCuListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DieuChuyenNoiBoCongCuDungCuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChuyenNoiBoCongCuDungCuListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DieuChuyenNoiBoCongCuDungCuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChuyenNoiBoCongCuDungCuListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DieuChuyenNoiBoCongCuDungCuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChuyenNoiBoCongCuDungCuListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DieuChuyenNoiBoCongCuDungCuList()
        { /* require use of factory method */ }

        public static DieuChuyenNoiBoCongCuDungCuList NewDieuChuyenNoiBoCongCuDungCuList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DieuChuyenNoiBoCongCuDungCuList");
            return new DieuChuyenNoiBoCongCuDungCuList();
        }
        public static DieuChuyenNoiBoCongCuDungCuList GetDieuChuyenNoiBoCongCuDungCuList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DieuChuyenNoiBoCongCuDungCuList");
            return DataPortal.Fetch<DieuChuyenNoiBoCongCuDungCuList>(new FilterCriteriaAll());
        }
        public static DieuChuyenNoiBoCongCuDungCuList GetDieuChuyenNoiBoCongCuDungCuList_TimTheoNgay(DateTime ngay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DieuChuyenNoiBoCongCuDungCuList");
            return DataPortal.Fetch<DieuChuyenNoiBoCongCuDungCuList>(new FilterCriteria_TimTheoNgay(ngay, denNgay));
        }

        public static DieuChuyenNoiBoCongCuDungCuList GetDieuChuyenNoiBoCongCuDungCuList_TimTheoSoChungTu(String soChungTu, String phepToanSoSanh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DieuChuyenNoiBoCongCuDungCuList");
            return DataPortal.Fetch<DieuChuyenNoiBoCongCuDungCuList>(new FilterCriteria_TimTheoSoChungTu(soChungTu, phepToanSoSanh));
        }
        public static DieuChuyenNoiBoCongCuDungCuList GetDieuChuyenNoiBoCongCuDungCuList(int maBoPhanGiao, long maNhanVienGiao, int maBoPhanNhan, long maNhanVienNhan, int maNguoiLap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DieuChuyenNoiBoCongCuDungCuList");
            return DataPortal.Fetch<DieuChuyenNoiBoCongCuDungCuList>(new FilterCriteria(maBoPhanGiao, maNhanVienGiao, maBoPhanNhan, maNhanVienNhan, maNguoiLap));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaBoPhanGiao;
            public long MaNhanVienGiao;
            public int MaBoPhanNhan;
            public long MaNhanVienNhan;
            public int MaNguoiLap;

            public FilterCriteria(int maBoPhanGiao, long maNhanVienGiao, int maBoPhanNhan, long maNhanVienNhan, int maNguoiLap)
            {
                this.MaBoPhanGiao = maBoPhanGiao;
                this.MaNhanVienGiao = maNhanVienGiao;
                this.MaBoPhanNhan = maBoPhanNhan;
                this.MaNhanVienNhan = maNhanVienNhan;
                this.MaNguoiLap = maNguoiLap;
            }
        }
        [Serializable()]
        private class FilterCriteriaAll
        {


            public FilterCriteriaAll()
            {

            }
        }

        [Serializable()]
        private class FilterCriteria_TimTheoNgay
        {

            public DateTime Ngay = DateTime.Parse("01/01/1753");
            public DateTime DenNgay = DateTime.MaxValue;
            public FilterCriteria_TimTheoNgay(DateTime ngay, DateTime denNgay)
            {
                this.Ngay = ngay;
                this.DenNgay = denNgay;
            }
        }

        [Serializable()]
        private class FilterCriteria_TimTheoSoChungTu
        {

            public String SoChungTu = "";
            public String PhepToanSoSanh = "";
            public FilterCriteria_TimTheoSoChungTu(string soChungTu, string phepToanSoSanh)
            {
                this.SoChungTu = soChungTu;
                this.PhepToanSoSanh = phepToanSoSanh;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
        {
            RaiseListChangedEvents = false;
            if (criteria is FilterCriteria_TimTheoNgay)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetch_TimTheoNgay(tr, criteria as FilterCriteria_TimTheoNgay);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
            }
            else if (criteria is FilterCriteria_TimTheoSoChungTu)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetch_TimTheoSoChungTu(tr, criteria as FilterCriteria_TimTheoSoChungTu);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
            }
            else if (criteria is FilterCriteria)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetch(tr, criteria as FilterCriteria);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
            }
            else if (criteria is FilterCriteriaAll)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetchAll(tr, criteria as FilterCriteriaAll);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
            }
            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "GetDieuChuyenNoiBoCongCuDungCuList";
                cm.Parameters.AddWithValue("@MaBoPhanGiao", criteria.MaBoPhanGiao);
                cm.Parameters.AddWithValue("@MaNhanVienGiao", criteria.MaNhanVienGiao);
                cm.Parameters.AddWithValue("@MaBoPhanNhan", criteria.MaBoPhanNhan);
                cm.Parameters.AddWithValue("@MaNhanVienNhan", criteria.MaNhanVienNhan);
                cm.Parameters.AddWithValue("@MaNguoiLap", criteria.MaNguoiLap);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DieuChuyenNoiBoCongCuDungCu.GetDieuChuyenNoiBoCongCuDungCu(dr));
                }
            }//using
        }
        private void ExecuteFetchAll(SqlTransaction tr, FilterCriteriaAll criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectDieuChuyenNoiBoCongCuDungCuListAll";

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DieuChuyenNoiBoCongCuDungCu.GetDieuChuyenNoiBoCongCuDungCu(dr));
                }
            }//using
        }
        private void ExecuteFetch_TimTheoNgay(SqlTransaction tr, FilterCriteria_TimTheoNgay criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectDieuChuyenNoiBoCongCuDungCuList_TimTheoNgay";

                if (criteria.Ngay != DateTime.MinValue)
                    cm.Parameters.AddWithValue("@Ngay", criteria.Ngay);
                else
                    cm.Parameters.AddWithValue("@Ngay", DBNull.Value);
                ///
                if (criteria.DenNgay != DateTime.MinValue)
                    cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);
                else
                    cm.Parameters.AddWithValue("@DenNgay", DBNull.Value);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DieuChuyenNoiBoCongCuDungCu.GetDieuChuyenNoiBoCongCuDungCu(dr));
                }
            }//using
        }
        private void ExecuteFetch_TimTheoSoChungTu(SqlTransaction tr, FilterCriteria_TimTheoSoChungTu criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectDieuChuyenNoiBoCongCuDungCuList_TimTheoSoChungTu";


                cm.Parameters.AddWithValue("@SoChungTu", criteria.SoChungTu);
                cm.Parameters.AddWithValue("@PhepToanSoSanh", criteria.PhepToanSoSanh);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DieuChuyenNoiBoCongCuDungCu.GetDieuChuyenNoiBoCongCuDungCu(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (DieuChuyenNoiBoCongCuDungCu deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DieuChuyenNoiBoCongCuDungCu child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr, this);
                        else
                            child.Update(tr, this);
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
