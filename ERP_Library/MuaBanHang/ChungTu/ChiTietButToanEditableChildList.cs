
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiTietButToanList : Csla.BusinessListBase<ChiTietButToanList, ChiTietButToan>
	{

		#region Factory Methods
		public static ChiTietButToanList NewChiTietButToanList()
		{
			return new ChiTietButToanList();
		}

		internal static ChiTietButToanList GetChiTietButToanList(int  MaButToan)
		{
            return new ChiTietButToanList(MaButToan);
		}

		private ChiTietButToanList()
		{
			MarkAsChild();
		}

		private ChiTietButToanList(int MaButToan)
		{
			MarkAsChild();
            Fetch(MaButToan);
		}
		#endregion //Factory Methods


		#region Data Access
		private void Fetch(int MaButToan)
		{

			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblChiTietButToansByMaButToan";
                    cm.Parameters.AddWithValue("@MaButToan", MaButToan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChiTietButToan.GetChiTietButToan(dr));
                    }
                }
            }

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, ButToan parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (ChiTietButToan deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (ChiTietButToan child in this)
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
