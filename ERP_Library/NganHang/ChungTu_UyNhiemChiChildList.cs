
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTu_UNCChildList : Csla.BusinessListBase<ChungTu_UNCChildList, ChungTu_UNCChild>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ChungTu_UNCChild item = ChungTu_UNCChild.NewChungTu_UNCChild();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static ChungTu_UNCChildList NewChungTu_UNCChildList()
		{
			return new ChungTu_UNCChildList();
		}

		internal static ChungTu_UNCChildList GetChungTu_UNCChildList(SafeDataReader dr)
		{
			return new ChungTu_UNCChildList(dr);
		}

        public static ChungTu_UNCChildList GetChungTu_UNCChildList(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_UNCChildList>(new FilterCriteria_ByChungTu(maChungTu));
        }

        public static ChungTu_UNCChildList GetChungTu_UNCChildList_ByUyNhiemChi(long maUNC)
        {
            return DataPortal.Fetch<ChungTu_UNCChildList>(new FilterCriteria(maUNC));
        }

		private ChungTu_UNCChildList()
		{
			MarkAsChild();
		}

		private ChungTu_UNCChildList(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods


        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaPhieu;

            public FilterCriteria(long maUNC)
            {
                this.MaPhieu = maUNC;
            }
        }

        private class FilterCriteria_ByChungTu
        {
            public long MaChungTu;

            public FilterCriteria_ByChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }
        #endregion //Filter Criteria

		#region Data Access
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
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblChungTu_UyNhiemChisByMaUNC";
                    cm.Parameters.AddWithValue("@maUNC", ((FilterCriteria)criteria).MaPhieu);
                }
                else if (criteria is FilterCriteria_ByChungTu)
                {
                    cm.CommandText = "spd_SelecttblChungTu_UyNhiemChisByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria_ByChungTu)criteria).MaChungTu);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChungTu_UNCChild.GetChungTu_UNCChild(dr));
                }

            }//using
        }


		private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;

			while(dr.Read())
				this.Add(ChungTu_UNCChild.GetChungTu_UNCChild(dr));

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, ChungTu parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (ChungTu_UNCChild deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (ChungTu_UNCChild child in this)
			{
				if(child.IsNew)
					child.Insert(tr, parent);
				else
					child.Update(tr, parent);
			}

			RaiseListChangedEvents = true;
		}

        public void DataPortal_Delete(SqlTransaction tr)
        {
            foreach (ChungTu_UNCChild child in this)
            {
                child.DeleteSelf(tr);
            }
        }

        #endregion //Data Access
	}
}
