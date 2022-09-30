
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_NghiepVuDieuChuyenList : Csla.BusinessListBase<CT_NghiepVuDieuChuyenList, CT_NghiepVuDieuChuyen>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_NghiepVuDieuChuyen item = CT_NghiepVuDieuChuyen.NewCT_NghiepVuDieuChuyen();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static CT_NghiepVuDieuChuyenList NewCT_NghiepVuDieuChuyenList()
		{
			return new CT_NghiepVuDieuChuyenList();
		}

		internal static CT_NghiepVuDieuChuyenList GetCT_NghiepVuDieuChuyenList(int MaNghiepVuDieuChuyen)
		{
            return new CT_NghiepVuDieuChuyenList(MaNghiepVuDieuChuyen);
		}

		private CT_NghiepVuDieuChuyenList()
		{
			MarkAsChild();
		}

		private CT_NghiepVuDieuChuyenList(int MaNghiepVuDieuChuyen)
		{
			MarkAsChild();
            Fetch(MaNghiepVuDieuChuyen);
		}
		#endregion //Factory Methods

		#region Data Access
		private void Fetch(int MaNghiepVuDieuChuyen)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_NghiepVuDieuChuyenNoiBoByMaDieuChuyen";

                    cm.Parameters.AddWithValue("@MaNghiepVuDieuChuyen", MaNghiepVuDieuChuyen);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_NghiepVuDieuChuyen.GetCT_NghiepVuDieuChuyen(dr));
                    }
                }
            }

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, DieuChuyenNoiBo parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_NghiepVuDieuChuyen deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_NghiepVuDieuChuyen child in this)
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
