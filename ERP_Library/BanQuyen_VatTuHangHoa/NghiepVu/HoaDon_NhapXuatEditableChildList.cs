
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library//05012016
{ 
	[Serializable()] 
	public class HoaDon_NhapXuatList : Csla.BusinessListBase<HoaDon_NhapXuatList, HoaDon_NhapXuat>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			HoaDon_NhapXuat item = HoaDon_NhapXuat.NewHoaDon_NhapXuat();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static HoaDon_NhapXuatList NewHoaDon_NhapXuatList()
		{
			return new HoaDon_NhapXuatList();
		}


		internal static HoaDon_NhapXuatList GetHoaDon_NhapXuatList(long maPhieuNhapXuat)
		{
			return new HoaDon_NhapXuatList(maPhieuNhapXuat);
		}

		private HoaDon_NhapXuatList()
		{
			MarkAsChild();
		}

		private HoaDon_NhapXuatList(long maPhieuNhapXuat)
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
                     cm.CommandText = "spd_SelecttblHoaDon_NhapXuatsByAndMaPhieuNhapXuat";
                     cm.Parameters.AddWithValue("@MaPhieuNhapXuat", maPhieuNhapXuat);
                     using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                     {
                         while (dr.Read())
                             this.Add(HoaDon_NhapXuat.GetHoaDon_NhapXuat(dr));
                     }
                 }
            }
			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, PhieuNhapXuat parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (HoaDon_NhapXuat deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (HoaDon_NhapXuat child in this)
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
            foreach (HoaDon_NhapXuat deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (HoaDon_NhapXuat child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }
        #endregion //BanQuyen

        #region CCDC
        internal void Update(SqlTransaction tr, PhieuNhapXuatCCDC parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (HoaDon_NhapXuat deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (HoaDon_NhapXuat child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }
        #endregion//CCDC
        #endregion //Data Access

    }
}
