
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KhenThuongTheoNhomList : Csla.BusinessListBase<KhenThuongTheoNhomList, KhenThuongTheoNhom>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			KhenThuongTheoNhom item = KhenThuongTheoNhom.NewKhenThuongTheoNhom();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private KhenThuongTheoNhomList()
		{ /* require use of factory method */ }

		public static KhenThuongTheoNhomList NewKhenThuongTheoNhomList()
		{
			return new KhenThuongTheoNhomList();
		}

		public static KhenThuongTheoNhomList GetKhenThuongTheoNhomList()
		{
			return DataPortal.Fetch<KhenThuongTheoNhomList>(new FilterCriteria());
		}
        public static KhenThuongTheoNhomList KhenThuongTheoNhomListByNgay(int hinhThuc, int danhHieu, int maCapQuyetDinh, int maBoPhan, DateTime Tungay, DateTime Denngay)
        {
            return DataPortal.Fetch<KhenThuongTheoNhomList>(new FilterCriteriaByNgay(hinhThuc, danhHieu, maCapQuyetDinh, maBoPhan, Tungay, Denngay));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{

			public FilterCriteria()
			{

			}
		}
        private class FilterCriteriaByNgay
        {
            public DateTime Tungay;
            public DateTime Denngay;
            public int MaDanhHieu;
            public int MaHinhThuc;
            public int MaCapQuyetDinh;
         
            public int MaBoPhan;
            public FilterCriteriaByNgay(int hinhThuc, int danhHieu, int maCapQuyetDinh, int maBoPhan, DateTime Tungay, DateTime Denngay)
            {
                this.MaHinhThuc = hinhThuc;
                this.MaDanhHieu = danhHieu;
                this.MaCapQuyetDinh = maCapQuyetDinh;
              
                this.MaBoPhan = maBoPhan;
                this.Tungay = Tungay;
                this.Denngay = Denngay;
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
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "SelecttblnsKhenThuongTapThesAll";
                }
                else if (criteria is FilterCriteriaByNgay)
                {

                    {
                   
                            cm.CommandText = "SelecttblnsKhenThuongTapTheByNggay";
                            cm.Parameters.AddWithValue("@Tungay", ((FilterCriteriaByNgay)criteria).Tungay);
                            cm.Parameters.AddWithValue("@Denngay", ((FilterCriteriaByNgay)criteria).Denngay);
                            cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByNgay)criteria).MaBoPhan);
                            cm.Parameters.AddWithValue("@MaDanhHieu", ((FilterCriteriaByNgay)criteria).MaDanhHieu);
                            cm.Parameters.AddWithValue("@MaCapQuyetDinh", ((FilterCriteriaByNgay)criteria).MaCapQuyetDinh);
                            cm.Parameters.AddWithValue("@MaHinhThucKhenThuong", ((FilterCriteriaByNgay)criteria).MaHinhThuc);
                           
                    }
                }
                

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(KhenThuongTheoNhom.GetKhenThuongTheoNhom(dr));
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
					foreach (KhenThuongTheoNhom deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (KhenThuongTheoNhom child in this)
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
