
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_HoaDonDichVuList : Csla.BusinessListBase<CT_HoaDonDichVuList, CT_HoaDonDichVu>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_HoaDonDichVu item = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static CT_HoaDonDichVuList NewCT_HoaDonDichVuList()
		{
			return new CT_HoaDonDichVuList();
		}

		public static CT_HoaDonDichVuList GetCT_HoaDonDichVuList(long MaHoaDon)
		{
			return new CT_HoaDonDichVuList(MaHoaDon);
		}

		private CT_HoaDonDichVuList()
		{
			MarkAsChild();
		}

		private CT_HoaDonDichVuList(long MaHoaDon)
		{
			MarkAsChild();
            Fetch(MaHoaDon);
		}
		#endregion //Factory Methods


		#region Data Access
		private void Fetch(long MaHoaDon)
		{
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_HoaDonDichVusByMaHoaDon";

                    cm.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_HoaDonDichVu.GetCT_HoaDonDichVu(dr));
                    }
                }
            }

            RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, HoaDon parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_HoaDonDichVu deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_HoaDonDichVu child in this)
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
