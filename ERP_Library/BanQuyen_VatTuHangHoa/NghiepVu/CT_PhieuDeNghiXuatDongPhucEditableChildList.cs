
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library//05012016
{ 
	[Serializable()] 
	public class CT_PhieuDeNghiXuatDongPhucList : Csla.BusinessListBase<CT_PhieuDeNghiXuatDongPhucList, CT_PhieuDeNghiXuatDongPhuc>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_PhieuDeNghiXuatDongPhuc item = CT_PhieuDeNghiXuatDongPhuc.NewCT_PhieuDeNghiXuatDongPhuc();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static CT_PhieuDeNghiXuatDongPhucList NewCT_PhieuDeNghiXuatDongPhucList()
		{
			return new CT_PhieuDeNghiXuatDongPhucList();
		}

		internal static CT_PhieuDeNghiXuatDongPhucList GetCT_PhieuDeNghiXuatDongPhucList(int maPhieuXuat)
		{
            return new CT_PhieuDeNghiXuatDongPhucList(maPhieuXuat);
		}
        public static CT_PhieuDeNghiXuatDongPhucList GetCT_PhieuDeNghiXuatDongPhucList_Multi(string maPhieuXuat)
        {
            return new CT_PhieuDeNghiXuatDongPhucList(maPhieuXuat);
        }

		private CT_PhieuDeNghiXuatDongPhucList()
		{
			MarkAsChild();
		}

        private CT_PhieuDeNghiXuatDongPhucList(int maPhieuXuat)
		{
			MarkAsChild();
            Fetch(maPhieuXuat);
		}
        private CT_PhieuDeNghiXuatDongPhucList(string maPhieuXuat)
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
                    cm.CommandText = "spd_SelecttblCT_PhieuDeNghiXuatDongPhuc";
                    cm.Parameters.AddWithValue("@MaDeNghiXuat", maPhieuXuat);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_PhieuDeNghiXuatDongPhuc.GetCT_PhieuDeNghiXuatDongPhuc(dr));
                    }
                }
            }

			RaiseListChangedEvents = true;
		}

        private void Fetch(string maPhieuXuat)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_PhieuDeNghiXuatDongPhuc_Multi";
                    cm.Parameters.AddWithValue("@MaDeNghiXuat", maPhieuXuat);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_PhieuDeNghiXuatDongPhuc.GetCT_PhieuDeNghiXuatDongPhuc(dr));
                    }
                }
            }

            RaiseListChangedEvents = true;
        }

		internal void Update(SqlTransaction tr, PhieuDeNghiXuatDongPhuc parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
            foreach (CT_PhieuDeNghiXuatDongPhuc deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
            foreach (CT_PhieuDeNghiXuatDongPhuc child in this)
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
