using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiTietPhanBoThuLaoList : Csla.BusinessListBase<ChiTietPhanBoThuLaoList, ChiTietPhanBoThuLao>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ChiTietPhanBoThuLao item = ChiTietPhanBoThuLao.NewChiTietPhanBoThuLao();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
        public static ChiTietPhanBoThuLaoList NewChiTietPhanBoThuLaoList()
        {
            return new ChiTietPhanBoThuLaoList();
        }

        public static ChiTietPhanBoThuLaoList GetChiTietPhanBoThuLaoList(long maPhanBoThuLao)
        {
            return DataPortal.Fetch<ChiTietPhanBoThuLaoList>(new FilterCriteria(maPhanBoThuLao));
        }

        public static ChiTietPhanBoThuLaoList GetChiTietPhanBoThuLaoList_BoPhan(int maBoPhan)
        {
            return DataPortal.Fetch<ChiTietPhanBoThuLaoList>(new FilterCriteria_BoPhan(maBoPhan));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public long MaPhanBoThuLao;

			public FilterCriteria(long maPhanBoThuLao)
			{
				this.MaPhanBoThuLao = maPhanBoThuLao;
			}
		}

        private class FilterCriteria_BoPhan
        {
            public int MaBoPhan;

            public FilterCriteria_BoPhan(int maBoPhan)
            {
                this.MaBoPhan = maBoPhan;
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
                if (criteria is FilterCriteria)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsChiTietPhanBoThuLao_MaPhanBoThuLao";
                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", ((FilterCriteria)criteria).MaPhanBoThuLao);
                }
                if (criteria is FilterCriteria_BoPhan)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsChiTietPhanBoThuLao_MaBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_BoPhan)criteria).MaBoPhan);
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ChiTietPhanBoThuLao.GetChiTietPhanBoThuLao(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch



		#region Data Access - Update
        internal void Update(SqlTransaction tr, PhanBoThuLao parent)
        {
            RaiseListChangedEvents = false;
            //tr = cn.BeginTransaction();
            try
            {
                // loop through each deleted child object
                foreach (ChiTietPhanBoThuLao deletedChild in DeletedList)
                {
                    deletedChild.DeleteSelf(tr);
                }
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChiTietPhanBoThuLao child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, parent);
                    else
                        child.Update(tr, parent);
                }

                //tr.Commit();
            }
            catch
            {
                // tr.Rollback();
                throw;
            }

            RaiseListChangedEvents = true;
        }
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
