
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_HoaDonList : Csla.BusinessListBase<CT_HoaDonList, CT_HoaDon>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_HoaDon item = CT_HoaDon.NewCT_HoaDon();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static CT_HoaDonList NewCT_HoaDonList()
		{
			return new CT_HoaDonList();
		}

		internal static CT_HoaDonList GetCT_HoaDonList(long MaHoaDon)
		{
			return new CT_HoaDonList(MaHoaDon);
		}

		private CT_HoaDonList()
		{
			MarkAsChild();
		}

		private CT_HoaDonList(long MaHoaDon)
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
                    cm.CommandText = "spd_SelecttblCT_HoaDonsByAndMaHoaDon";

                    cm.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_HoaDon.GetCT_HoaDon(dr));
                    }
                }
            }

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, HoaDon parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_HoaDon deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_HoaDon child in this)
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
