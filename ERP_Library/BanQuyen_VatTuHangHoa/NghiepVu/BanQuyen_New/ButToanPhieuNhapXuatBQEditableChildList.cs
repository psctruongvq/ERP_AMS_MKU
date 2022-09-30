
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ButToanPhieuNhapXuatBQList : Csla.BusinessListBase<ButToanPhieuNhapXuatBQList, ButToanPhieuNhapXuatBQ>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ButToanPhieuNhapXuatBQ item = ButToanPhieuNhapXuatBQ.NewButToanPhieuNhapXuat();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static ButToanPhieuNhapXuatBQList NewButToanPhieuNhapXuatList()
		{
			return new ButToanPhieuNhapXuatBQList();
		}

		internal static ButToanPhieuNhapXuatBQList GetButToanPhieuNhapXuatList(int maDinhKhoan)
		{
            return new ButToanPhieuNhapXuatBQList(maDinhKhoan);
		}

		private ButToanPhieuNhapXuatBQList()
		{
			MarkAsChild();
		}

        private ButToanPhieuNhapXuatBQList(int maDinhKhoan)
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
                            this.Add(ButToanPhieuNhapXuatBQ.GetButToanPhieuNhapXuat(dr));
                    }
                }
            }
			RaiseListChangedEvents = true;
		}

        internal void Update(SqlTransaction tr, PhieuNhapXuatBQ parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
            foreach (ButToanPhieuNhapXuatBQ deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
            foreach (ButToanPhieuNhapXuatBQ child in this)
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
