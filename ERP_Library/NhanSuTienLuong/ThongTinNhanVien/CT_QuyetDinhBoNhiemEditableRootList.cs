
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_QuyetDinhBoNhiemList : Csla.BusinessListBase<CT_QuyetDinhBoNhiemList, CT_QuyetDinhBoNhiem>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_QuyetDinhBoNhiem item = CT_QuyetDinhBoNhiem.NewCT_QuyetDinhBoNhiem();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CT_QuyetDinhBoNhiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_QuyetDinhBoNhiemListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CT_QuyetDinhBoNhiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_QuyetDinhBoNhiemListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CT_QuyetDinhBoNhiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_QuyetDinhBoNhiemListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CT_QuyetDinhBoNhiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_QuyetDinhBoNhiemListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CT_QuyetDinhBoNhiemList()
		{ /* require use of factory method */
            MarkAsChild();
        }

		public static CT_QuyetDinhBoNhiemList NewCT_QuyetDinhBoNhiemList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CT_QuyetDinhBoNhiemList");
			return new CT_QuyetDinhBoNhiemList();
		}

		public static CT_QuyetDinhBoNhiemList GetCT_QuyetDinhBoNhiemList(int maQuyetDinh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CT_QuyetDinhBoNhiemList");
			return DataPortal.Fetch<CT_QuyetDinhBoNhiemList>(new FilterCriteria(maQuyetDinh));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaQuyetDinh;

			public FilterCriteria(int maQuyetDinh)
			{
				this.MaQuyetDinh = maQuyetDinh;
			}
		}
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(FilterCriteria criteria)
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

		private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsQuyetDinhBonhiemByMaQuyetDinh";
				cm.Parameters.AddWithValue("@MaQuyetDinh", criteria.MaQuyetDinh);
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(CT_QuyetDinhBoNhiem.GetCT_QuyetDinhBoNhiem(dr));
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
					foreach (CT_QuyetDinhBoNhiem deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (CT_QuyetDinhBoNhiem child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
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

        public void UpdateData(SqlTransaction tr, QuyetDinhBoNhiem parent)
        {
            RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (CT_QuyetDinhBoNhiem deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (CT_QuyetDinhBoNhiem child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr,parent);
                    else
                        child.Update(tr,parent);
                }
            }
            catch
            {
                throw;
            }
            RaiseListChangedEvents = true;
        }
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
