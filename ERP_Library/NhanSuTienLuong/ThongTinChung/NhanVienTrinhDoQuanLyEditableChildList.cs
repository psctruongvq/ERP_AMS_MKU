
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_TrinhDoQuanLyList : Csla.BusinessListBase<NhanVien_TrinhDoQuanLyList, NhanVien_TrinhDoQuanLy>
	{
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            NhanVien_TrinhDoQuanLy item = NhanVien_TrinhDoQuanLy.NewNhanVien_TrinhDoQuanLy();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

		#region Factory Methods
		public static NhanVien_TrinhDoQuanLyList NewNhanVien_TrinhDoQuanLyList()
		{
			return new NhanVien_TrinhDoQuanLyList();
		}

		public static NhanVien_TrinhDoQuanLyList GetNhanVien_TrinhDoQuanLyList()
		{
			//return new NhanVien_TrinhDoQuanLyList(dr);
            return DataPortal.Fetch<NhanVien_TrinhDoQuanLyList>(new FilterCriteriaAll());
		}

        public static NhanVien_TrinhDoQuanLyList GetNhanVien_TrinhDoQuanLyList(long maNhanVien)
        {
            //return new NhanVien_TrinhDoQuanLyList(dr);
            return DataPortal.Fetch<NhanVien_TrinhDoQuanLyList>(new FilterCriteriaByMaNhanVien(maNhanVien));
        }


		public NhanVien_TrinhDoQuanLyList()
		{
			MarkAsChild();
		}

		public NhanVien_TrinhDoQuanLyList(SafeDataReader dr)
		{
			MarkAsChild();
			//Fetch(dr);
		}
		#endregion //Factory Methods

		#region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaByMaNhanVien
        {
            public long MaNhanVien;

            public FilterCriteriaByMaNhanVien(long MaNhanVien)
            {
                this.MaNhanVien = MaNhanVien;
            }
        }

        [Serializable()]
        private class FilterCriteriaAll
        {
            public FilterCriteriaAll()
            {
            }
        }
        #endregion //Filter Criteria

        //protected override void DataPortal_Fetch(object criteria)
        //{
        //    if (criteria is FilterCriteriaByMaNhanVien)
        //    {
        //        DataPortal_Fetch(criteria);
        //    }
        //    else
        //    {
        //        //tu bo sung khi can
        //        DataPortal_Fetch(criteria);
        //    }
        //}

        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    ExecuteFetch(cn, criteria);
                }
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteriaByMaNhanVien)
                {
                    cm.CommandText = "spd_SelecttblnsNhanVien_TrinhDoQuanLyNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByMaNhanVien)criteria).MaNhanVien);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVien_TrinhDoQuanLy.GetNhanVien_TrinhDoQuanLy(dr));
                    }
                }
                else if (criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "spd_SelecttblnsNhanVien_TrinhDoQuanLyAll";
                   
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVien_TrinhDoQuanLy.GetNhanVien_TrinhDoQuanLy(dr));
                    }
                }
            }//using
        }
		internal void Update(SqlTransaction tr, NhanVien parent)
		{
			RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (NhanVien_TrinhDoQuanLy deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (NhanVien_TrinhDoQuanLy child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, parent);
                    else
                        child.Update(tr, parent);
                }
            }
            catch (SqlException ex)
            {
                tr.Rollback();
                HamDungChung.ThongBaoLoi(ex);
            }
			RaiseListChangedEvents = true;
		}
		#endregion //Data Access

	}
}
