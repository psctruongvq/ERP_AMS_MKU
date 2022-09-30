
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DoiTac_PhuongThucThanhToanList : Csla.BusinessListBase<DoiTac_PhuongThucThanhToanList, DoiTac_PhuongThucThanhToan>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			DoiTac_PhuongThucThanhToan item = DoiTac_PhuongThucThanhToan.NewDoiTac_PhuongThucThanhToan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static DoiTac_PhuongThucThanhToanList NewDoiTac_PhuongThucThanhToanList()
		{
			return new DoiTac_PhuongThucThanhToanList();
		}

		internal static DoiTac_PhuongThucThanhToanList GetDoiTac_PhuongThucThanhToanList(long MaDoiTac)
		{
			return new DoiTac_PhuongThucThanhToanList(MaDoiTac);
		}

		private DoiTac_PhuongThucThanhToanList()
		{
			MarkAsChild();
		}

		private DoiTac_PhuongThucThanhToanList(long MaDoiTac)
		{
			MarkAsChild();
            Fetch(MaDoiTac);
		}
		#endregion //Factory Methods


		#region Data Access
		private void Fetch(long MaDoiTac)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblDoiTac_PhuongPhucThanhToansByMaDoiTac";
                    cm.Parameters.AddWithValue("@MaDoiTac ", MaDoiTac);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(DoiTac_PhuongThucThanhToan.GetDoiTac_PhuongThucThanhToan(dr));
                        }
                    }
                }
            }
			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, DoiTac parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (DoiTac_PhuongThucThanhToan deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (DoiTac_PhuongThucThanhToan child in this)
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
