
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTinVanBanList : Csla.BusinessListBase<ThongTinVanBanList, ThongTinVanBan>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ThongTinVanBan item = ThongTinVanBan.NewThongTinVanBan();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThongTinVanBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinVanBanListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThongTinVanBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinVanBanListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThongTinVanBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinVanBanListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThongTinVanBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinVanBanListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThongTinVanBanList()
        { /* require use of factory method */ }

        public static ThongTinVanBanList NewThongTinVanBanList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinVanBanList");
            return new ThongTinVanBanList();
        }
        
        public static ThongTinVanBanList GetThongTinVanBanList(string strSoHoSo, int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinVanBanList");
            return DataPortal.Fetch<ThongTinVanBanList>(new FilterCriteriaBySoHoSo(strSoHoSo, Loai));
        }

        public static ThongTinVanBanList GetThongTinVanBanList(long maNhomVanBan, int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinVanBanList");
            return DataPortal.Fetch<ThongTinVanBanList>(new FilterCriteria(maNhomVanBan, Loai));
        }

        public static ThongTinVanBanList GetThongTinVanBanList(long maNhomVanBan, long maNhanVien, int Loai)
         {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinVanBanList");
            return DataPortal.Fetch<ThongTinVanBanList>(new FilterCriteriaByNhanVien(maNhomVanBan, maNhanVien, Loai));
        }

        public static ThongTinVanBanList GetThongTinVanBanList(long maNhomVanBan, long maNhanVien, string soHoSo, int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinVanBanList");
            return DataPortal.Fetch<ThongTinVanBanList>(new FilterCriteriaVanBanBySoHoSo(maNhomVanBan, maNhanVien, soHoSo, Loai));
        }

        public static ThongTinVanBanList GetThongTinVanBanList_KiemTra(long maNhanVien, string soHoSo, int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinVanBanList");
            return DataPortal.Fetch<ThongTinVanBanList>(new FilterCriteriaVanBanByKiemTra(maNhanVien, soHoSo, Loai));
        }

        public static ThongTinVanBanList GetThongTinVanBanList_KiemTra(long maThongTinVB, long maNhanVien, string soHoSo, int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinVanBanList");
            return DataPortal.Fetch<ThongTinVanBanList>(new FilterCriteriaVanBanByKiemTraSoHoSo(maThongTinVB,maNhanVien, soHoSo, Loai));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhomVanBan;
            public int Loai = 0;

            public FilterCriteria(long maNhomVanBan, int loai)
            {
                this.MaNhomVanBan = maNhomVanBan;
                this.Loai = loai;
            }
        }

        private class FilterCriteriaBySoHoSo
        {
            public string SoHoSo;
            public int Loai = 0;

            public FilterCriteriaBySoHoSo(string soHoSo, int loai)
            {
                this.SoHoSo = soHoSo;
                this.Loai = loai;
            }
        }

        private class FilterCriteriaByNhanVien
        {
            public long MaNhomVanBan, MaNhanVien;
            public int Loai = 0;

            public FilterCriteriaByNhanVien(long maNhomVanBan, long maNhanVien, int loai)
            {
                this.MaNhomVanBan = maNhomVanBan;
                this.MaNhanVien = maNhanVien;
                this.Loai = loai;
            }
        }

        private class FilterCriteriaVanBanBySoHoSo
        {
            public long MaNhomVanBan, MaNhanVien;
            public string SoHoSo;
            public int Loai = 0;

            public FilterCriteriaVanBanBySoHoSo(long maNhomVanBan, long maNhanVien, string soHoSo, int loai)
            {
                this.MaNhomVanBan = maNhomVanBan;
                this.MaNhanVien = maNhanVien;
                this.SoHoSo = soHoSo;
                this.Loai = loai;
            }
        }

        private class FilterCriteriaVanBanByKiemTra
        {
            public long MaNhanVien;
            public string SoHoSo;
            public int Loai = 0;

            public FilterCriteriaVanBanByKiemTra( long maNhanVien, string soHoSo, int loai)
            {
                this.MaNhanVien = maNhanVien;
                this.SoHoSo = soHoSo;
                this.Loai = loai;
            }
        }

        private class FilterCriteriaVanBanByKiemTraSoHoSo
        {
            public long MaThongTinVanBan;
            public long MaNhanVien;
            public string SoHoSo;
            public int Loai = 0;

            public FilterCriteriaVanBanByKiemTraSoHoSo(long maThongTinVB,long maNhanVien, string soHoSo, int loai)
            {
                this.MaThongTinVanBan = maThongTinVB;
                this.MaNhanVien = maNhanVien;
                this.SoHoSo = soHoSo;
                this.Loai = loai;
            }
        }

        private class FilterCriteriaAllBoPhan
        {
            public string SoHoSo;
            public int Loai = 0;

            public FilterCriteriaAllBoPhan(string soHoSo, int loai)
            {
                this.SoHoSo = soHoSo;
                this.Loai = loai;
            }
        }


        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
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

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblThongTinVanBansByAndMaNhomVanBan";
                    cm.Parameters.AddWithValue("@MaNhomVanBan", ((FilterCriteria)criteria).MaNhomVanBan);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria)criteria).Loai);
                }
                else if (criteria is FilterCriteriaByNhanVien)
                {
                    cm.CommandText = "spd_SelecttblThongTinVanBansByNhomVanBanAndNhanVien";
                    cm.Parameters.AddWithValue("@MaNhomVanBan", ((FilterCriteriaByNhanVien)criteria).MaNhomVanBan);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByNhanVien)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByNhanVien)criteria).Loai);
                }
                else if (criteria is FilterCriteriaBySoHoSo)
                {
                    cm.CommandText = "spd_SelecttblThongTinVanBansBySoHoSo";
                    cm.Parameters.AddWithValue("@SoHoSo", ((FilterCriteriaBySoHoSo)criteria).SoHoSo);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaBySoHoSo)criteria).SoHoSo);
                }
                else if (criteria is FilterCriteriaVanBanBySoHoSo)
                {
                    cm.CommandText = "spd_SelecttblThongTinVanBansBy_Search";
                    cm.Parameters.AddWithValue("@MaNhomVanBan", ((FilterCriteriaVanBanBySoHoSo)criteria).MaNhomVanBan);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaVanBanBySoHoSo)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@SoHoSo", ((FilterCriteriaVanBanBySoHoSo)criteria).SoHoSo);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaVanBanBySoHoSo)criteria).Loai);
                }
                else if (criteria is FilterCriteriaVanBanByKiemTra)
                {
                    cm.CommandText = "spd_SelecttblThongTinVanBansByKiemTra";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaVanBanByKiemTra)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@SoHoSo", ((FilterCriteriaVanBanByKiemTra)criteria).SoHoSo);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaVanBanByKiemTra)criteria).Loai);
                }
                else if (criteria is FilterCriteriaVanBanByKiemTraSoHoSo)
                {
                    cm.CommandText = "spd_SelecttblThongTinVanBansByKiemTraSoHoSo";
                    cm.Parameters.AddWithValue("@MaThongTinVanBan", ((FilterCriteriaVanBanByKiemTraSoHoSo)criteria).MaThongTinVanBan);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaVanBanByKiemTraSoHoSo)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@SoHoSo", ((FilterCriteriaVanBanByKiemTraSoHoSo)criteria).SoHoSo);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaVanBanByKiemTraSoHoSo)criteria).Loai);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ThongTinVanBan.GetThongTinVanBan(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (ThongTinVanBan deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ThongTinVanBan child in this)
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
