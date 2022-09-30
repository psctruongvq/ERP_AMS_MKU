
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_KetChuyenTonKhoList : Csla.BusinessListBase<CT_KetChuyenTonKhoList, CT_KetChuyenTonKho>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_KetChuyenTonKho item = CT_KetChuyenTonKho.NewCT_KetChuyenTonKho();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static CT_KetChuyenTonKhoList NewCT_KetChuyenTonKhoList()
		{
			return new CT_KetChuyenTonKhoList();
		}

		internal static CT_KetChuyenTonKhoList GetCT_KetChuyenTonKhoList(long MaKetChuyen)
		{
            return new CT_KetChuyenTonKhoList(MaKetChuyen);
		}

        internal static CT_KetChuyenTonKhoList GetCT_KetChuyenTonKhoList(int maKho)
        {
            return new CT_KetChuyenTonKhoList(maKho);
        }

		private CT_KetChuyenTonKhoList()
		{
			MarkAsChild();
		}

		private CT_KetChuyenTonKhoList(long MaKetChuyen)
		{
			MarkAsChild();
            Fetch(MaKetChuyen);
		}

        private CT_KetChuyenTonKhoList(int maKho)
        {
            MarkAsChild();
            Fetch(maKho);
        }
		#endregion //Factory Methods


		#region Data Access
		private void Fetch(long MaKetChuyen)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_KetChuyenTonKhosByAndMaKetChuyen";
                    cm.Parameters.AddWithValue("@MaKetChuyen", MaKetChuyen);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_KetChuyenTonKho.GetCT_KetChuyenTonKho(dr, true));
                    }
                }
            }

			RaiseListChangedEvents = true;
		}

        private void Fetch(int maKho)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_KetChuyenTonKhosByMaKho";
                    cm.Parameters.AddWithValue("@MaKho", maKho);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_KetChuyenTonKho.GetCT_KetChuyenTonKho(dr, false));
                    }
                }
            }

            RaiseListChangedEvents = true;
        }

		internal void Update(SqlTransaction tr, KyKetChuyenTonKho parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_KetChuyenTonKho deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_KetChuyenTonKho child in this)
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
