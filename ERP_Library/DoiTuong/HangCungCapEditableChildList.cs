
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HangCungCapList : Csla.BusinessListBase<HangCungCapList, HangCungCap>
	{
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            HangCungCap item = HangCungCap.NewHangCungCap();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

		#region Factory Methods
		internal static HangCungCapList NewHangCungCapList()
		{
			return new HangCungCapList();
		}

		internal static HangCungCapList GetHangCungCapList(long maNhaCungCap)
		{
			//return new HangCungCapList(dr);
            return DataPortal.Fetch<HangCungCapList>(new FilterCriteria(maNhaCungCap));
		}

		private HangCungCapList()
		{
			MarkAsChild();
		}

		private HangCungCapList(SafeDataReader dr)
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
            public long maNhaCungCap;

            public FilterCriteria(long _maNhaCungCap)
            {
                this.maNhaCungCap = _maNhaCungCap;
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
                cm.CommandText = "spd_SelecttblHangCungCapsAll";
                cm.Parameters.AddWithValue("@MaNhaCungCap", criteria.maNhaCungCap);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(HangCungCap.GetHangCungCap(dr));
                }
            }//using
        }
               
        internal void Update(SqlTransaction tr, NhaCungCap parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (HangCungCap deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (HangCungCap child in this)
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
