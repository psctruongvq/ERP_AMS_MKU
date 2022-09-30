
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVienComboList : Csla.ReadOnlyListBase<NhanVienComboList, NhanVienComboListChild>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhanVienComboList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVienComboListViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhanVienComboList()
        { /* require use of factory method */ }

        public static NhanVienComboList GetNhanVienByMaBoPhan(int MaBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienComboList");
            return DataPortal.Fetch<NhanVienComboList>(new FilterByMaBoPhan(MaBoPhan, false));
        }


        public static NhanVienComboList GetNhanVienByMaBoPhanAll(int MaBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienComboList");
            return DataPortal.Fetch<NhanVienComboList>(new FilterByMaBoPhanAll(MaBoPhan, true));
        }
        public static NhanVienComboList GetNhanVienByMaBoPhanKhongNghiViec(int MaBoPhan, Boolean NghiViec)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienComboList");
            return DataPortal.Fetch<NhanVienComboList>(new FilterByMaBoPhan(MaBoPhan, NghiViec));
        }

        public static NhanVienComboList GetNhanVienAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienComboList");
            return DataPortal.Fetch<NhanVienComboList>(new FilterAll());
        }

        public static NhanVienComboList GetNhanVienAllLong()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienComboList");
            return DataPortal.Fetch<NhanVienComboList>(new FilterAllLong());
        }

        public static NhanVienComboList GetNhanVienByLoai(int BoPhan, int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienComboList");
            return DataPortal.Fetch<NhanVienComboList>(new FilterAllByLoai(BoPhan, Loai));
        }

        public static NhanVienComboList GetNhanVienByQuyetToan(int Nam, int DenKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienComboList");
            return DataPortal.Fetch<NhanVienComboList>(new FilterByQuyetToan(Nam, DenKy));
        }

        public static NhanVienComboList GetNhanVienByKyLuong(int MaKy, int MaBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienComboList");
            return DataPortal.Fetch<NhanVienComboList>(new FilterByKyLuong(MaKy, MaBoPhan));
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterAll
        {
            public FilterAll()
            {
            }
        }

        private class FilterAllLong
        {
            public FilterAllLong()
            {
            }
        }

        private class FilterAllByLoai
        {
            public int Loai;
            public int BoPhan;
            public FilterAllByLoai( int boPhan,int loai)
            {
                this.Loai = loai;
                this.BoPhan = boPhan;
            }
        }
        [Serializable()]
        private class FilterByQuyetToan
        {
            public int Nam;
            public int DenKy;
            public FilterByQuyetToan(int nam, int denky)
            {
                this.Nam = nam;
                this.DenKy = denky;
            }
        }
        [Serializable()]
        private class FilterByKyLuong
        {
            public int MaKy;
            public int MaBoPhan;
            public FilterByKyLuong(int maKy, int maBoPhan)
            {
                this.MaKy = maKy;
                this.MaBoPhan = maBoPhan;
            }
        }
        private class FilterByKhoan
        {
            public int Nam;
            public int DenKy;
            public FilterByKhoan(int nam, int denky)
            {
                this.Nam = nam;
                this.DenKy = denky;
            }
        }
        [Serializable()]
        private class FilterByMaBoPhan
        {
            private int _MaBoPhan;
            public bool NghiViec;

            public FilterByMaBoPhan(int MaBoPhan, bool nghiViec)
            {
                _MaBoPhan = MaBoPhan;
                NghiViec = nghiViec;
            }

            public int MaBoPhan
            {
                get
                {
                    return _MaBoPhan;
                }
            }
        }

        private class FilterByMaBoPhanAll
        {
            private int _MaBoPhan;
            public bool NghiViec;

            public FilterByMaBoPhanAll(int MaBoPhan, bool nghiViec)
            {
                _MaBoPhan = MaBoPhan;
                NghiViec = nghiViec;
            }

            public int MaBoPhan
            {
                get
                {
                    return _MaBoPhan;
                }
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;

                if (criteria is FilterAll)
                {
                    cm.CommandText = "sp_GetNhanVienCombobox";
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }

                else if (criteria is FilterAllLong)
                {
                    cm.CommandText = "sp_GetNhanVienComboboxLong";
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterByQuyetToan)
                {
                    cm.CommandText = "[sp_GetNhanVienByQuyetToan]";
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@Nam", ((FilterByQuyetToan)criteria).Nam);
                    cm.Parameters.AddWithValue("@DenKy", ((FilterByQuyetToan)criteria).DenKy);

                }
                else if (criteria is  FilterByMaBoPhan)
                {
                    cm.CommandText = "sp_GetNhanVienComboboxByMaBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterByMaBoPhan)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@NghiViec", ((FilterByMaBoPhan)criteria).NghiViec); 
                }
                else if (criteria is FilterByMaBoPhanAll)
                {
                    cm.CommandText = "sp_GetNhanVienComboboxByMaBoPhanLong";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterByMaBoPhanAll)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@NghiViec", ((FilterByMaBoPhanAll)criteria).NghiViec);
                }
                else if (criteria is FilterAllByLoai)
                {
                    cm.CommandText = "sp_GetNhanVienComboboxByMaBoPhanbyLoai";
                    cm.Parameters.AddWithValue("@Loai", ((FilterAllByLoai)criteria).Loai);
                    cm.Parameters.AddWithValue("@BoPhan", ((FilterAllByLoai)criteria).BoPhan);
                }
                else if (criteria is FilterByKyLuong)
                {
                    cm.CommandText = "sp_GetNhanVienComboboxByBoPhanAndKy";
                    cm.Parameters.AddWithValue("@MaKyLuong", ((FilterByKyLuong)criteria).MaKy);
                    cm.Parameters.AddWithValue("@BoPhan", ((FilterByKyLuong)criteria).MaBoPhan);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhanVienComboListChild.GetNhanVienComboListChild(dr));
                }
                
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
