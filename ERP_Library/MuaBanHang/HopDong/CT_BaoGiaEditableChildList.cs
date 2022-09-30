
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_BaoGiaList : Csla.BusinessListBase<CT_BaoGiaList, CT_BaoGia>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_BaoGia item = CT_BaoGia.NewCT_BaoGia();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static CT_BaoGiaList NewCT_BaoGiaList()
		{
			return new CT_BaoGiaList();
		}

		public static CT_BaoGiaList GetCT_BaoGiaList(int maBangBaoGia)
		{	
			return DataPortal.Fetch<CT_BaoGiaList>(new FilterCriteria(maBangBaoGia));
		}
		
		private CT_BaoGiaList()
		{
            //Moi them vao
            //CT_BaoGia item = CT_BaoGia.NewCT_BaoGia();
            //this.Add(item);            
            MarkAsChild();
		}
		
		#endregion //Factory Methods

		#region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {   
            public int MaBangBaoGia;
            

            public FilterCriteria(int maBangBaoGia)
            {   
                this.MaBangBaoGia = maBangBaoGia;            
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
                cm.CommandText = "spd_SelecttblCT_BaoGiasAll";                
                cm.Parameters.AddWithValue("@MaBangBaoGia", criteria.MaBangBaoGia);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {  
                    while (dr.Read())
                        this.Add(CT_BaoGia.GetCT_BaoGia(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch

		private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;

			while(dr.Read())
				this.Add(CT_BaoGia.GetCT_BaoGia(dr));

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, BangBaoGia parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
            foreach (CT_BaoGia deletedChild in DeletedList)//parent.CT_BaoGiaList
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_BaoGia child in this)
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
