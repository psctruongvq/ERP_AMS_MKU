
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_MauBangBaoCaoList : Csla.BusinessListBase<CT_MauBangBaoCaoList, CT_MauBangBaoCao>
	{

		#region Factory Methods
		internal static CT_MauBangBaoCaoList NewCT_MauBangBaoCaoList()
		{
			return new CT_MauBangBaoCaoList();
		}

		internal static CT_MauBangBaoCaoList GetCT_MauBangBaoCaoList(int MaMuc, byte loaiMau)
		{
			return new CT_MauBangBaoCaoList(MaMuc, loaiMau);
		}

		private CT_MauBangBaoCaoList()
		{
			MarkAsChild();
		}

		private CT_MauBangBaoCaoList(int MaMuc, byte loaiMau)
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
                        cm.CommandText = "spd_SelecttblCT_MauBangBaoCaoByMaMuc";
                        cm.Parameters.AddWithValue("@MaMuc", MaMuc);
                        cm.Parameters.AddWithValue("@LoaiMau", loaiMau);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(CT_MauBangBaoCao.GetCT_MauBangBaoCao(dr));
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
		#endregion //Factory Methods
        
		#region Data Access
		private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;

			while(dr.Read())
				this.Add(CT_MauBangBaoCao.GetCT_MauBangBaoCao(dr));

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, BCKQHoatDongKinhDoanh parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_MauBangBaoCao deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_MauBangBaoCao child in this)
			{
				if(child.IsNew)
					child.Insert(tr, parent);
				else
					child.Update(tr, parent);
			}

			RaiseListChangedEvents = true;
		}

        internal void Update(SqlTransaction tr, BangCanDoiKeToan parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_MauBangBaoCao deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_MauBangBaoCao child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, BangTongHopTinhHinhKinhPhi parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_MauBangBaoCao deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_MauBangBaoCao child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }



		#endregion //Data Access

	}
}
