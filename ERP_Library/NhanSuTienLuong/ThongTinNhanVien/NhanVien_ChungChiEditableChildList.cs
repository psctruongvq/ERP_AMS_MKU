
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_ChungChiList : Csla.BusinessListBase<NhanVien_ChungChiList, NhanVien_ChungChi>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NhanVien_ChungChi item = NhanVien_ChungChi.NewNhanVien_ChungChi();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static NhanVien_ChungChiList NewNhanVien_ChungChiList()
		{
            NhanVien_ChungChiList item = new NhanVien_ChungChiList();
            return item;
		}

		internal static NhanVien_ChungChiList GetNhanVien_ChungChiList(SafeDataReader dr)
		{
			return new NhanVien_ChungChiList(dr);
		}
        public static NhanVien_ChungChiList GetNhanVien_ChungChiList(long maNhanVien)
        {
            return DataPortal.Fetch<NhanVien_ChungChiList>(new FilterCriteriaByMaNhanVien(maNhanVien));
        }
		private NhanVien_ChungChiList()
		{
			MarkAsChild();
		}

		private NhanVien_ChungChiList(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods

        [Serializable()]
        private class FilterCriteriaByMaNhanVien
        {
            public long MaNhanVien;

            public FilterCriteriaByMaNhanVien(long MaNhanVien)
            {
                this.MaNhanVien = MaNhanVien;
            }
        }
		#region Data Access
		private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;

			while(dr.Read())
				this.Add(NhanVien_ChungChi.GetNhanVien_ChungChi(dr));

			RaiseListChangedEvents = true;
		}
        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    ExecuteFetch(cn, criteria);
                }
                catch (SqlException ex)
                {
                    
                }
            }//using

            RaiseListChangedEvents = true;
        }
        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteriaByMaNhanVien)
                {
                    cm.CommandText = "SelecttblnsNhanVien_ChungChiByNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByMaNhanVien)criteria).MaNhanVien);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhanVien_ChungChi.GetNhanVien_ChungChi(dr));
                }
            }//using
        }
		internal void Update(SqlTransaction tr, NhanVien parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (NhanVien_ChungChi deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (NhanVien_ChungChi child in this)
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
