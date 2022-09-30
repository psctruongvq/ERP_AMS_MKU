
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_PhieuNXList : Csla.BusinessListBase<CT_PhieuNXList, CT_PhieuNX>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_PhieuNX item = CT_PhieuNX.NewCT_PhieuNX();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static CT_PhieuNXList NewCT_PhieuNXList()
		{
			return new CT_PhieuNXList();
		}

		internal static CT_PhieuNXList GetCT_PhieuNXList(long maPhieuNX)
		{
			return new CT_PhieuNXList(maPhieuNX);
		}

		private CT_PhieuNXList()
		{
			MarkAsChild();
		}

		private CT_PhieuNXList(long maPhieuNX)
		{
			MarkAsChild();
			Fetch(maPhieuNX);
		}
		#endregion //Factory Methods


		#region Data Access
		private void Fetch(long maPhieuNX)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_PhieuNXesByAndMaPhieuNhapXuat";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", maPhieuNX);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_PhieuNX.GetCT_PhieuNX(dr));
                    }
                }
            }        

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, PhieuNhapXuat parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_PhieuNX deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_PhieuNX child in this)
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
