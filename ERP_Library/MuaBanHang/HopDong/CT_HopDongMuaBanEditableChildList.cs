
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_HopDongMuaBanList : Csla.BusinessListBase<CT_HopDongMuaBanList, CT_HopDongMuaBan>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_HopDongMuaBan item = CT_HopDongMuaBan.NewCT_HopDongMuaBan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static CT_HopDongMuaBanList NewCT_HopDongMuaBanList()
		{
			return new CT_HopDongMuaBanList();
		}
        public static CT_HopDongMuaBanList NewCT_HopDongMuaBanList(CT_HopDongMuaBanList ct_HopDongMuaBanList)
        {
            return new CT_HopDongMuaBanList(ct_HopDongMuaBanList);
        }

		internal static CT_HopDongMuaBanList GetCT_HopDongMuaBanList(long maHopDong)
		{
            return DataPortal.Fetch<CT_HopDongMuaBanList>(new FilterCriteria(maHopDong));
		}

		private CT_HopDongMuaBanList()
		{
            //CT_HopDongMuaBan item = CT_HopDongMuaBan.NewCT_HopDongMuaBan();
            //this.Add(item);
            
            MarkAsChild();
		}


        private CT_HopDongMuaBanList(CT_HopDongMuaBanList ct_HopDongMuaBanList)
        {
            //CT_HopDongMuaBan item = CT_HopDongMuaBan.NewCT_HopDongMuaBan();
            //this.Add(item);
            foreach (CT_HopDongMuaBan ctHopDongMuaBan in ct_HopDongMuaBanList)
            {
                this.Add(CT_HopDongMuaBan.NewCT_HopDongMuaBan(ctHopDongMuaBan));
            }

            MarkAsChild();
        }

		private CT_HopDongMuaBanList(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods

		#region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaHopDong;


            public FilterCriteria(long maHopDong)
            {
                this.MaHopDong = maHopDong;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        protected override void DataPortal_Fetch(object criteria)
        {
            if (criteria is FilterCriteria)
            {
                DataPortal_Fetch((FilterCriteria)criteria);
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
                cm.CommandText = "spd_SelecttblCT_HopDongMuaBansByMaHopDong";
                cm.Parameters.AddWithValue("@MaHopDong", criteria.MaHopDong);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CT_HopDongMuaBan.GetCT_HopDongMuaBan(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch

        private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;           
            while (dr.Read())
                this.Add(CT_HopDongMuaBan.GetCT_HopDongMuaBan(dr));                       

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, HopDongMuaBan parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_HopDongMuaBan deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_HopDongMuaBan child in this)
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
