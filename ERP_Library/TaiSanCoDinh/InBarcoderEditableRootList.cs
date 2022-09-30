
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class InBarcoderList : Csla.BusinessListBase<InBarcoderList, InBarcoder>
	{

		#region Authorization Rules
        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }
		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in InBarcoderList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("InBarcoderListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in InBarcoderList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("InBarcoderListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in InBarcoderList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("InBarcoderListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in InBarcoderList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("InBarcoderListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private InBarcoderList()
		{ /* require use of factory method */ }

		public static InBarcoderList NewInBarcoderList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a InBarcoderList");
			return new InBarcoderList();
		}

        public static InBarcoderList GetInBarcoderList(DateTime ngayBatDau, DateTime ngayKetThuc)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a InBarcoderList");
            return DataPortal.Fetch<InBarcoderList>(new FilterCriteria(ngayBatDau, ngayKetThuc));
		}
       
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public DateTime NgayBatDau;
            public DateTime NgayKeThuc;

            public FilterCriteria(DateTime ngayBatDau, DateTime ngayKetThuc)
			{
                this.NgayBatDau = ngayBatDau;
                this.NgayKeThuc = ngayKetThuc;
			}
		}
       
		#endregion //Filter Criteria

		#region Data Access - Fetch
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
                    cm.CommandText = "SelectAllInBarCoderByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria)criteria).NgayBatDau);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria)criteria).NgayKeThuc);
               

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(InBarcoder.GetInBarcoder(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				// loop through each deleted child object
				foreach (InBarcoder deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (InBarcoder child in this)
				{
					if (child.IsNew)
						child.Insert(cn,this);
					else
						child.Update(cn,this);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
