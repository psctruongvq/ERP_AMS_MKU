
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiTietQuyetDinhList : Csla.BusinessListBase<ChiTietQuyetDinhList, ChiTietQuyetDinh>
	{

		#region Factory Methods
		internal static ChiTietQuyetDinhList NewChiTietQuyetDinhList()
		{
			return new ChiTietQuyetDinhList();
		}

        internal static ChiTietQuyetDinhList GetChiTietQuyetDinhList(int maQuyetDinh)
        {
            ChiTietQuyetDinhList kq = new ChiTietQuyetDinhList();
            //RaiseListChangedEvents = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "spd_SelecttblnsChiTietQuyetDinhesAll";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaQuyetDinh", maQuyetDinh);
                        using (SafeDataReader dr = new SafeDataReader(cmd.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                kq.Add(ChiTietQuyetDinh.GetChiTietQuyetDinh(dr));
                            }
                        }
                    }

                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return kq;            
        }

		internal static ChiTietQuyetDinhList GetChiTietQuyetDinhList(SafeDataReader dr)
		{
			return new ChiTietQuyetDinhList(dr);
		}

		private ChiTietQuyetDinhList()
		{
			MarkAsChild();
		}

		private ChiTietQuyetDinhList(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods

		#region Data Access
		private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;

            //while(dr.Read())
              //  this.Add(ChiTietQuyetDinh.GetChiTietQuyetDinh(dr));

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlConnection cn, QuyetDinhDaoTao parent)
		{
			RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (ChiTietQuyetDinh deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChiTietQuyetDinh child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn, parent);
                    else
                        child.Update(cn, parent);
                }
            }
            catch (SqlException ex)
            {
                HamDungChung.ThongBaoLoi(ex);
            }
			RaiseListChangedEvents = true;
		}
		#endregion //Data Access

	}
}
