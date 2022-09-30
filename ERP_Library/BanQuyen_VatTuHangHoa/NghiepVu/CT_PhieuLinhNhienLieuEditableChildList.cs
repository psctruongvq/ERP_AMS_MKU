
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_PhieuLinhNhienLieuList : Csla.BusinessListBase<CT_PhieuLinhNhienLieuList, CT_PhieuLinhNhienLieu>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_PhieuLinhNhienLieu item = CT_PhieuLinhNhienLieu.NewCT_PhieuLinhNhienLieu();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static CT_PhieuLinhNhienLieuList NewCT_PhieuLinhNhienLieuList()
		{
			return new CT_PhieuLinhNhienLieuList();
		}

		internal static CT_PhieuLinhNhienLieuList GetCT_PhieuLinhNhienLieuList(long maPhieuLinhNhienLieu)
		{
            return new CT_PhieuLinhNhienLieuList(maPhieuLinhNhienLieu);
		}

		private CT_PhieuLinhNhienLieuList()
		{
			MarkAsChild();
		}

		private CT_PhieuLinhNhienLieuList(long maPhieuLinhNhienLieu)
		{
			MarkAsChild();
            Fetch(maPhieuLinhNhienLieu);
		}
		#endregion //Factory Methods


		#region Data Access
		private void Fetch(long maPhieuLinhNhienLieu)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_PhieuLinhNhienLieusByAndMaPhieuLinhNhienLieu";
                    cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", maPhieuLinhNhienLieu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_PhieuLinhNhienLieu.GetCT_PhieuLinhNhienLieu(dr));
                    }
                }
            }

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, PhieuLinhNhienLieu parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_PhieuLinhNhienLieu deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_PhieuLinhNhienLieu child in this)
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
