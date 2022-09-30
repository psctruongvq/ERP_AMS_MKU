
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhTGQDList : Csla.BusinessListBase<QuaTrinhTGQDList, QuaTrinhTGQD>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			QuaTrinhTGQD item = QuaTrinhTGQD.NewQuaTrinhTGQD();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static QuaTrinhTGQDList NewQuaTrinhTGQDList()
		{
			return new QuaTrinhTGQDList();
		}

		public static QuaTrinhTGQDList GetQuaTrinhTGQDList()
		{
			//return new QuaTrinhTGQDList(dr);
            return DataPortal.Fetch<QuaTrinhTGQDList>(new FilterCriteriaAll());
		}

        public static QuaTrinhTGQDList GetQuaTrinhTGQDList(long maNhanVien)
        {
            //return new QuaTrinhTGQDList(dr);
            return DataPortal.Fetch<QuaTrinhTGQDList>(new FilterCriteria(maNhanVien));
        }

		private QuaTrinhTGQDList()
		{
			MarkAsChild();
		}

		private QuaTrinhTGQDList(SafeDataReader dr)
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

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsQuaTrinhTGQDsAll";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(QuaTrinhTGQD.GetQuaTrinhTGQD(dr));
                }
            }//using
        }
       

		internal void Update(SqlTransaction tr, NhanVien parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (QuaTrinhTGQD deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (QuaTrinhTGQD child in this)
			{
				if(child.IsNew)
					child.Insert(tr, parent);
				else
					child.Update(tr, parent);
			}

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access

	}
}
