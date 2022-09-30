
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DiaChi_DoiTacList : Csla.BusinessListBase<DiaChi_DoiTacList, DiaChi_DoiTac>
	{

        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DiaChi_DoiTac item = DiaChi_DoiTac.NewDiaChi_DoiTac();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        public static DiaChi_DoiTacList NewDiaChi_DoiTacList()
		{
			return new DiaChi_DoiTacList();
		}

		public static DiaChi_DoiTacList GetDiaChi_DoiTacList(long maDoiTac)
		{			
            return DataPortal.Fetch<DiaChi_DoiTacList>(new FilterCriteria(maDoiTac));
		}

        public static DiaChi_DoiTacList GetDiaChi_DoiTacList()
        {         
            return DataPortal.Fetch<DiaChi_DoiTacList>(new FilterCriteriaAll());
        }
		public DiaChi_DoiTacList()
		{
			MarkAsChild();
		}

		public DiaChi_DoiTacList(SafeDataReader dr)
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
            public long MaDoiTac;

            public FilterCriteria(long MaDoiTac)
            {
                this.MaDoiTac = MaDoiTac;
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
                cm.CommandText = "spd_SelecttblDiaChi_DoiTacsAll";
                cm.Parameters.AddWithValue("@MaDoiTac", criteria.MaDoiTac);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DiaChi_DoiTac.GetDiaChi_DoiTac(dr));
                }
            }//using
        }
      
		internal void Update(SqlTransaction tr, DoiTac parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (DiaChi_DoiTac deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (DiaChi_DoiTac child in this)
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
