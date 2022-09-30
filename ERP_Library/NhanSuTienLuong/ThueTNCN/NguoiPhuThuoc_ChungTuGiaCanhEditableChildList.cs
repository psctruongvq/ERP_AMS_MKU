
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NguoiPhuThuoc_ChungTuGiaCanhList : Csla.BusinessListBase<NguoiPhuThuoc_ChungTuGiaCanhList, NguoiPhuThuoc_ChungTuGiaCanh>
	{

		#region Factory Methods
        protected override object AddNewCore()
        {
            NguoiPhuThuoc_ChungTuGiaCanh item = NguoiPhuThuoc_ChungTuGiaCanh.NewNguoiPhuThuoc_ChungTuGiaCanh(0);
            this.Add(item);
            return item;
        }
		internal static NguoiPhuThuoc_ChungTuGiaCanhList NewNguoiPhuThuoc_ChungTuGiaCanhList()
		{
			return new NguoiPhuThuoc_ChungTuGiaCanhList();
		}
        public static NguoiPhuThuoc_ChungTuGiaCanhList GetNguoiPhuThuoc_ChungTuGiaCanhList(int maNhanVien_GiaCanh)
        {
            return DataPortal.Fetch<NguoiPhuThuoc_ChungTuGiaCanhList>(new FilterCriteria(maNhanVien_GiaCanh));
        }
		internal static NguoiPhuThuoc_ChungTuGiaCanhList GetNguoiPhuThuoc_ChungTuGiaCanhList(SafeDataReader dr)
		{
			return new NguoiPhuThuoc_ChungTuGiaCanhList(dr);
		}
        private class FilterCriteria
        {
            public  int MaNhanVien_GiaCanh;

            public FilterCriteria(int maNhanVien_GiaCanh)
            {
                this.MaNhanVien_GiaCanh = maNhanVien_GiaCanh;
            }
        }
		private NguoiPhuThuoc_ChungTuGiaCanhList()
		{
			MarkAsChild();
		}

		private NguoiPhuThuoc_ChungTuGiaCanhList(SafeDataReader dr)
		{
			MarkAsChild();
            DataPortal_Fetch(dr);
		}
		#endregion //Factory Methods

        protected override void DataPortal_Fetch(object criteria)
        {
            
                DataPortal_Fetch(criteria);
            
        }       
		#region Data Access
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
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "SelecttblnsNguoiPhuThuoc_ChungTuGiaCanhesAll";
                    cm.Parameters.AddWithValue("@MaNhanVien_GiaCanh", ((FilterCriteria)criteria).MaNhanVien_GiaCanh);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NguoiPhuThuoc_ChungTuGiaCanh.GetNguoiPhuThuoc_ChungTuGiaCanh(dr));
                }
            }//using
        }


		internal void Update(SqlTransaction tr, NhanVienGiaCanh parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (NguoiPhuThuoc_ChungTuGiaCanh deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (NguoiPhuThuoc_ChungTuGiaCanh child in this)
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
