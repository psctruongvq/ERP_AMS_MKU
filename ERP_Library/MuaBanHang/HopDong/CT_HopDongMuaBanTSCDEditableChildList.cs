
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_MuaBanTSCDList : Csla.BusinessListBase<CT_MuaBanTSCDList, CT_MuaBanTSCD>
	{

		#region Factory Methods
		internal static CT_MuaBanTSCDList NewCT_MuaBanTSCDList()
		{
			return new CT_MuaBanTSCDList();
		}

        internal static CT_MuaBanTSCDList GetCT_MuaBanTSCDList(long maHopDong)
		{
			return new CT_MuaBanTSCDList(maHopDong);
		}

		private CT_MuaBanTSCDList()
		{
			MarkAsChild();
		}

        private CT_MuaBanTSCDList(long maHopDong)
		{
			MarkAsChild();
            Fetch(maHopDong);
		}
		#endregion //Factory Methods

		#region Data Access
        private void Fetch(long maHopDong)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_MuaBanTSCDsByMaHopDong";

                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_MuaBanTSCD.GetCT_MuaBanTSCD(dr));
                    }
                }
            }
			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, HopDongMuaBan parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_MuaBanTSCD deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_MuaBanTSCD child in this)
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
