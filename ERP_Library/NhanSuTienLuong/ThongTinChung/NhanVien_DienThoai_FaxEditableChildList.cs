
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_DienThoai_FaxList : Csla.BusinessListBase<NhanVien_DienThoai_FaxList, NhanVien_DienThoai_Fax>
	{
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            NhanVien_DienThoai_Fax item = NhanVien_DienThoai_Fax.NewNhanVien_DienThoai_Fax();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

		#region Factory Methods
		public static NhanVien_DienThoai_FaxList NewNhanVien_DienThoai_FaxList()
		{
			return new NhanVien_DienThoai_FaxList();
		}

		public static NhanVien_DienThoai_FaxList GetNhanVien_DienThoai_FaxList()
		{			
            return DataPortal.Fetch<NhanVien_DienThoai_FaxList>(new FilterCriteriaAll());
		}

        public static NhanVien_DienThoai_FaxList GetNhanVien_DienThoai_FaxList(long maNhanVien)
        {
            //return new NhanVien_DienThoai_FaxList(dr);
            return DataPortal.Fetch<NhanVien_DienThoai_FaxList>(new FilterCriteria(maNhanVien));
        }

		public NhanVien_DienThoai_FaxList()
		{
			MarkAsChild();
		}

		public NhanVien_DienThoai_FaxList(SafeDataReader dr)
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
            public long MaNhanVien;

            public FilterCriteria(long MaNhanVien)
            {
                this.MaNhanVien = MaNhanVien;
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
                try
                {
                    ExecuteFetch(cn, criteria);
                }
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblNhanVien_DienThoai_FaxesAll";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhanVien_DienThoai_Fax.GetNhanVien_DienThoai_Fax(dr));
                }
            }//using
        }

       
		internal void Update(SqlTransaction tr, NhanVien parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (NhanVien_DienThoai_Fax deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (NhanVien_DienThoai_Fax child in this)
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
