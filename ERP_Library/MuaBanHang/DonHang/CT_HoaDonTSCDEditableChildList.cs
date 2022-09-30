
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_HoaDonTSCDList : Csla.BusinessListBase<CT_HoaDonTSCDList, CT_HoaDonTSCD>
	{

		#region Factory Methods
		internal static CT_HoaDonTSCDList NewCT_HoaDonTSCDList()
		{
			return new CT_HoaDonTSCDList();
		}

		internal static CT_HoaDonTSCDList GetCT_HoaDonTSCDList(long maHoaDon)
		{
            return new CT_HoaDonTSCDList(maHoaDon);
		}

		private CT_HoaDonTSCDList()
		{
			MarkAsChild();
		}

		private CT_HoaDonTSCDList(long maHoaDon)
		{
			MarkAsChild();
			Fetch(maHoaDon);
		}
		#endregion //Factory Methods

		#region Data Access
		private void Fetch(long maHoaDon)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_HoaDonTSCDsByMaHoaDon";

                    cm.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_HoaDonTSCD.GetCT_HoaDonTSCD(dr));
                    }
                }
            }

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, HoaDon parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_HoaDonTSCD deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_HoaDonTSCD child in this)
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
