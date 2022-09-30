
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_CongThucTMBCTaiChinhList : Csla.BusinessListBase<CT_CongThucTMBCTaiChinhList, CT_CongThucTMBCTaiChinh>
	{

		#region Factory Methods
		public static CT_CongThucTMBCTaiChinhList NewCT_CongThucTMBCTaiChinhList()
		{
			return new CT_CongThucTMBCTaiChinhList();
		}

		internal static CT_CongThucTMBCTaiChinhList GetCT_CongThucTMBCTaiChinhList(int MaCongThuc)
		{
			return new CT_CongThucTMBCTaiChinhList(MaCongThuc);
		}

		private CT_CongThucTMBCTaiChinhList()
		{
			MarkAsChild();
		}

		private CT_CongThucTMBCTaiChinhList(int MaCongThuc)
		{
			MarkAsChild();
			Fetch(MaCongThuc);
		}
		#endregion //Factory Methods


		#region Data Access
		private void Fetch(int MaCongThuc)
		{
            RaiseListChangedEvents = false;


            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblCT_CongThucTMBCTaiChinhesByMaMucCapBa";
                        cm.Parameters.AddWithValue("@MaMucCapBa", MaCongThuc);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(CT_CongThucTMBCTaiChinh.GetCT_CongThucTMBCTaiChinh(dr));	
                        }
                    }//using
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

		internal void Update(SqlTransaction tr, CT_MucTMBCTaiChinh parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_CongThucTMBCTaiChinh deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_CongThucTMBCTaiChinh child in this)
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
