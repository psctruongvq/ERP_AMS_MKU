
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HanMucTinDungList : Csla.BusinessListBase<HanMucTinDungList, HanMucTinDung>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			HanMucTinDung item = HanMucTinDung.NewHanMucTinDung();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static HanMucTinDungList NewHanMucTinDungList()
		{
			return new HanMucTinDungList();
		}

		public static HanMucTinDungList GetHanMucTinDungList(long maKhachHang)
		{
			//return new HanMucTinDungList(dr);
            return DataPortal.Fetch<HanMucTinDungList>(new FilterCriteria(maKhachHang));
		}

		public HanMucTinDungList()
		{
			MarkAsChild();
		}

		public HanMucTinDungList(SafeDataReader dr)
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
            public long MaKhachHang;

            public FilterCriteria(long MaKhachHang)
            {
                this.MaKhachHang = MaKhachHang;
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
                cm.CommandText = "spd_SelecttblHanMucTinDungsAll";
                cm.Parameters.AddWithValue("@MaKhachHang", criteria.MaKhachHang);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(HanMucTinDung.GetHanMucTinDung(dr));
                }
            }//using
        }

        //private void Fetch(SafeDataReader dr)
        //{
        //    RaiseListChangedEvents = false;

        //    while(dr.Read())
        //        this.Add(HanMucTinDung.GetHanMucTinDung(dr));

        //    RaiseListChangedEvents = true;
        //}

		internal void Update(SqlTransaction tr, KhachHang parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (HanMucTinDung deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (HanMucTinDung child in this)
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
