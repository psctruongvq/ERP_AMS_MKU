
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KyLuatTheoNhomList : Csla.BusinessListBase<KyLuatTheoNhomList, KyLuatTheoNhom>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			KyLuatTheoNhom item = KyLuatTheoNhom.NewKyLuatTheoNhom();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private KyLuatTheoNhomList()
		{ /* require use of factory method */ }

		public static KyLuatTheoNhomList NewKyLuatTheoNhomList()
		{
			return new KyLuatTheoNhomList();
		}
        public static KyLuatTheoNhomList GetKyLuatTheoNhomList()
        {
            return DataPortal.Fetch<KyLuatTheoNhomList>(new FilterCriteriaAll());
        }
        //public static KyLuatTheoNhomList GetKyLuatTheoNhomList(int maBoPhan, int maHinhThucKyLuat, int maCapQuyetDinh)
        //{
        //    return DataPortal.Fetch<KyLuatTheoNhomList>(new FilterCriteria(maBoPhan, maHinhThucKyLuat, maCapQuyetDinh));
        //}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
        [Serializable()]
        private class FilterCriteriaAll
        {
            public FilterCriteriaAll()
            {
            }
        }
		private class FilterCriteria
		{
			public int MaBoPhan;
			public int MaHinhThucKyLuat;
			public int MaCapQuyetDinh;

			public FilterCriteria(int maBoPhan, int maHinhThucKyLuat, int maCapQuyetDinh)
			{
				this.MaBoPhan = maBoPhan;
				this.MaHinhThucKyLuat = maHinhThucKyLuat;
				this.MaCapQuyetDinh = maCapQuyetDinh;
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
                if (criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "SelecttblnsKyLuatTheoNhomsAll";
                }
				

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(KyLuatTheoNhom.GetKyLuatTheoNhom(dr));
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
					foreach (KyLuatTheoNhom deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (KyLuatTheoNhom child in this)
					{
						if (child.IsNew)
							child.Insert(tr,this);
						else
							child.Update(tr,this);
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
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
