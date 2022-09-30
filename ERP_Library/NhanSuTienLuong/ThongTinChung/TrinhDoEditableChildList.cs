
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TrinhDoList : Csla.BusinessListBase<TrinhDoList, TrinhDo>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TrinhDo item = TrinhDo.NewTrinhDo();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static TrinhDoList NewTrinhDoList()
		{
			return new TrinhDoList();
		}

		public static TrinhDoList GetTrinhDoList()
		{
			//return new TrinhDoList(dr);
            return DataPortal.Fetch<TrinhDoList>(new FilterCriteriaAll());
		}

        public static TrinhDoList GetTrinhDoList(long maNhanVien)
        {
            //return new TrinhDoList(dr);
            return DataPortal.Fetch<TrinhDoList>(new FilterCriteria(maNhanVien));
        }

		private TrinhDoList()
		{
			MarkAsChild();
		}

		private TrinhDoList(SafeDataReader dr)
		{
			MarkAsChild();
			//Fetch(dr);
		}
		#endregion //Factory Methods


		#region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;

            public FilterCriteria(long MaNhanVien)
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

        protected override void DataPortal_Fetch(object criteria)
        {
            if (criteria is FilterCriteria)
            {
                DataPortal_Fetch(criteria);
            }
            else
            {
                //tu bo sung khi can
            }
        }

        private void DataPortal_Fetch(FilterCriteria criteria)
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

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsTrinhDosAll";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TrinhDo.GetTrinhDo(dr));
                }
            }//using
        }
       

		internal void Update(SqlTransaction tr, NhanVien parent)
		{
			RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (TrinhDo deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (TrinhDo child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, parent);
                    else
                        child.Update(tr, parent);
                }
            }
            catch (SqlException ex)
            {
                HamDungChung.ThongBaoLoi(ex);
            }

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access

	}
}
