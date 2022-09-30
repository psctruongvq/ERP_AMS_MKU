
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library//05012016
{ 
	[Serializable()] 
	public class CT_PhieuXuatList : Csla.BusinessListBase<CT_PhieuXuatList, CT_PhieuXuat>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_PhieuXuat item = CT_PhieuXuat.NewCT_PhieuXuat();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static CT_PhieuXuatList NewCT_PhieuXuatList()
		{
			return new CT_PhieuXuatList();
		}

		internal static CT_PhieuXuatList GetCT_PhieuXuatList(long maPhieuXuat)
		{
            return new CT_PhieuXuatList(maPhieuXuat);
		}

		private CT_PhieuXuatList()
		{
			MarkAsChild();
		}

		private CT_PhieuXuatList(long maPhieuXuat)
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
                            this.Add(CT_PhieuXuat.GetCT_PhieuXuat(dr));
                    }
                }
            }

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, PhieuNhapXuat parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_PhieuXuat deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_PhieuXuat child in this)
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
