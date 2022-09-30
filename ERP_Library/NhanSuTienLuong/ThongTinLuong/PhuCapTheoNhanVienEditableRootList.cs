
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class PhuCapTheoNhanVienList : Csla.BusinessListBase<PhuCapTheoNhanVienList, PhuCapTheoNhanVien>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            PhuCapTheoNhanVien item = PhuCapTheoNhanVien.NewPhuCapTheoNhanVien();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhuCapTheoNhanVienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTheoNhanVienListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhuCapTheoNhanVienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTheoNhanVienListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhuCapTheoNhanVienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTheoNhanVienListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhuCapTheoNhanVienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTheoNhanVienListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhuCapTheoNhanVienList()
        { /* require use of factory method */ }

        public static PhuCapTheoNhanVienList NewPhuCapTheoNhanVienList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhuCapTheoNhanVienList");
            return new PhuCapTheoNhanVienList();
        }

        public static PhuCapTheoNhanVienList GetPhuCapTheoNhanVienListbyloaipc(long maNhanVien, int maLoaiPhuCap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTheoNhanVienList");
            return DataPortal.Fetch<PhuCapTheoNhanVienList>(new FilterCriteria(maNhanVien, maLoaiPhuCap));
        }
        public static PhuCapTheoNhanVienList GetPhuCapTheoNhanVienList(int maloaiphucap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTheoNhanVienList");
            return DataPortal.Fetch<PhuCapTheoNhanVienList>(new Criteria(maloaiphucap));
        }
        public static PhuCapTheoNhanVienList GetPhuCapTheoNhanVienListByBoPhan(int mabophan, int maloaiphucap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTheoNhanVienList");
            return DataPortal.Fetch<PhuCapTheoNhanVienList>(new CriteriaByBoPhan(mabophan, maloaiphucap));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;
            public int MaLoaiPhuCap;

            public FilterCriteria(long maNhanVien, int maLoaiPhuCap)
            {
                this.MaNhanVien = maNhanVien;
                this.MaLoaiPhuCap = maLoaiPhuCap;
            }
        }
        private class Criteria
        {
            public int maloaiphucap;
            public Criteria(int maloaiphucap)
            {
                this.maloaiphucap = maloaiphucap;
            }
        }
        private class CriteriaByBoPhan
        {
            public int mabophan;
            public int maloaiphucap;
            public CriteriaByBoPhan(int mabophan, int maloaiphucap)
            {
                this.maloaiphucap = maloaiphucap;
                this.mabophan = mabophan;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

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
                    //cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                    //cm.Parameters.AddWithValue("@MaLoaiPhuCap", criteria.MaLoaiPhuCap);
                }
                else if (criteria is Criteria)
                {
                    cm.CommandText = "spd_selecttblnsPhuCapTheoNhanViensAll";
                    cm.Parameters.AddWithValue("@Maloaiphucap", ((Criteria)criteria).maloaiphucap);
                }
                else if (criteria is CriteriaByBoPhan)
                {
                    cm.CommandText = "spd_selecttblnsPhuCapTheoNhanViensAllByBoPhan";
                    cm.Parameters.AddWithValue("@Mabophan",((CriteriaByBoPhan)criteria).mabophan);
                    cm.Parameters.AddWithValue("@MaloaiPhucap", ((CriteriaByBoPhan)criteria).maloaiphucap);
                }   
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(PhuCapTheoNhanVien.GetPhuCapTheoNhanVien(dr));
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
                    foreach (PhuCapTheoNhanVien deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (PhuCapTheoNhanVien child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
