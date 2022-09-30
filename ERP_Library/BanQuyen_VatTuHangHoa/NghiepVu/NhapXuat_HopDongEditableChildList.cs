
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhapXuat_HopDongList : Csla.BusinessListBase<NhapXuat_HopDongList, NhapXuat_HopDong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NhapXuat_HopDong item = NhapXuat_HopDong.NewNhapXuat_HopDong();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static NhapXuat_HopDongList NewNhapXuat_HopDongList()
		{
			return new NhapXuat_HopDongList();
		}

        public static NhapXuat_HopDongList GetNhapXuat_HopDongList(long maPhieuNhapXuat)
		{
            return new NhapXuat_HopDongList(maPhieuNhapXuat);
		}

		private NhapXuat_HopDongList()
		{
			MarkAsChild();
		}

		private NhapXuat_HopDongList(long maPhieuNhapXuat)
		{
			MarkAsChild();
            Fetch(maPhieuNhapXuat);
		}
		#endregion //Factory Methods


		#region Data Access
		private void Fetch(long maPhieuNhapXuat)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblNhapXuat_HopDongsByAndMaPhieuNhapXuat";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", maPhieuNhapXuat);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhapXuat_HopDong.GetNhapXuat_HopDong(dr));
                    }
                }
            }

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, PhieuNhapXuat parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (NhapXuat_HopDong deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (NhapXuat_HopDong child in this)
			{
				if(child.IsNew)
					child.Insert(tr, parent);
				else
					child.Update(tr, parent);
			}

			RaiseListChangedEvents = true;
        }

        #region BanQuyen
        internal void Update(SqlTransaction tr, PhieuNhapXuatBQ parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (NhapXuat_HopDong deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (NhapXuat_HopDong child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }
        #endregion //BanQuyen
        #endregion //Data Access

    }
}
