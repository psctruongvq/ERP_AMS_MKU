
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_PhieuXuatBQList : Csla.BusinessListBase<CT_PhieuXuatBQList, CT_PhieuXuatBQ>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_PhieuXuatBQ item = CT_PhieuXuatBQ.NewCT_PhieuXuat();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static CT_PhieuXuatBQList NewCT_PhieuXuatList()
		{
			return new CT_PhieuXuatBQList();
		}

		internal static CT_PhieuXuatBQList GetCT_PhieuXuatList(long maPhieuXuat)
		{
            return new CT_PhieuXuatBQList(maPhieuXuat);
		}

		private CT_PhieuXuatBQList()
		{
			MarkAsChild();
		}

        private CT_PhieuXuatBQList(long maPhieuXuat)
		{
			MarkAsChild();
            Fetch(maPhieuXuat);
		}
		#endregion //Factory Methods


		#region Data Access
        private void Fetch(long maPhieuXuat)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_PhieuXuatsByAndMaPhieuxuat";
                    cm.Parameters.AddWithValue("@MaPhieuXuat", maPhieuXuat);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_PhieuXuatBQ.GetCT_PhieuXuat(dr));
                    }
                }
            }

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, PhieuNhapXuatBQ parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
            foreach (CT_PhieuXuatBQ deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
            foreach (CT_PhieuXuatBQ child in this)
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
