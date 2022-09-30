
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ButToanPhieuNhapXuatList : Csla.BusinessListBase<ButToanPhieuNhapXuatList, ButToanPhieuNhapXuat>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ButToanPhieuNhapXuat item = ButToanPhieuNhapXuat.NewButToanPhieuNhapXuat();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static ButToanPhieuNhapXuatList NewButToanPhieuNhapXuatList()
		{
			return new ButToanPhieuNhapXuatList();
		}

		internal static ButToanPhieuNhapXuatList GetButToanPhieuNhapXuatList(int maDinhKhoan)
		{
            return new ButToanPhieuNhapXuatList(maDinhKhoan);
		}

		private ButToanPhieuNhapXuatList()
		{
			MarkAsChild();
		}

		private ButToanPhieuNhapXuatList(int maDinhKhoan)
		{
			MarkAsChild();
			Fetch(maDinhKhoan);
		}
		#endregion //Factory Methods


		#region Data Access
		private void Fetch(int maDinhKhoan)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblButToansByAndMaDinhKhoan";
                    cm.Parameters.AddWithValue("@MaDinhKhoan", maDinhKhoan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ButToanPhieuNhapXuat.GetButToanPhieuNhapXuat(dr));
                    }
                }
            }
			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, PhieuNhapXuat parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (ButToanPhieuNhapXuat deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (ButToanPhieuNhapXuat child in this)
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
