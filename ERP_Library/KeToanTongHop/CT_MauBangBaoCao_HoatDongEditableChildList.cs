
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_MauBangBaoCao_HoatDongList : Csla.BusinessListBase<CT_MauBangBaoCao_HoatDongList, CT_MauBangBaoCao_HoatDong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_MauBangBaoCao_HoatDong item = CT_MauBangBaoCao_HoatDong.NewCT_MauBangBaoCao_HoatDong(0);
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static CT_MauBangBaoCao_HoatDongList NewCT_MauBangBaoCao_HoatDongList()
		{
			return new CT_MauBangBaoCao_HoatDongList();
		}

		internal static CT_MauBangBaoCao_HoatDongList GetCT_MauBangBaoCao_HoatDongList(int MaChiTietMuc )
		{
			return new CT_MauBangBaoCao_HoatDongList(MaChiTietMuc);
		}

		private CT_MauBangBaoCao_HoatDongList()
		{
			MarkAsChild();
		}

		private CT_MauBangBaoCao_HoatDongList(int MaChiTietMuc)
		{
			MarkAsChild();
			Fetch(MaChiTietMuc);
		}
		#endregion //Factory Methods

		#region Data Access
		private void Fetch(int MaChiTietMuc)
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
                        cm.CommandText = "spd_SelecttblCT_MauBangBaoCao_HoatDongbyMaChiTietMuc";
                        cm.Parameters.AddWithValue("@MaChiTietMuc", MaChiTietMuc);                        

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(CT_MauBangBaoCao_HoatDong.GetCT_MauBangBaoCao_HoatDong(dr));
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

		internal void Update(SqlTransaction tr, CT_MauBangBaoCao parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_MauBangBaoCao_HoatDong deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_MauBangBaoCao_HoatDong child in this)
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
