
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_PhieuXuatCCDCList : Csla.BusinessListBase<CT_PhieuXuatCCDCList, CT_PhieuXuatCCDC>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_PhieuXuatCCDC item = CT_PhieuXuatCCDC.NewCT_PhieuXuat();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static CT_PhieuXuatCCDCList NewCT_PhieuXuatList()
		{
			return new CT_PhieuXuatCCDCList();
		}

		internal static CT_PhieuXuatCCDCList GetCT_PhieuXuatList(long maPhieuXuat)
		{
            return new CT_PhieuXuatCCDCList(maPhieuXuat);
		}

		private CT_PhieuXuatCCDCList()
		{
			MarkAsChild();
		}

        private CT_PhieuXuatCCDCList(long maPhieuXuat)
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
                            this.Add(CT_PhieuXuatCCDC.GetCT_PhieuXuat(dr));
                    }
                }
            }

			RaiseListChangedEvents = true;
		}

        internal void Update(SqlTransaction tr, PhieuNhapXuatCCDC parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
            foreach (CT_PhieuXuatCCDC deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
            foreach (CT_PhieuXuatCCDC child in this)
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
