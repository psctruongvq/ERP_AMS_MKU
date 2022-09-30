
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_PhieuNhapList : Csla.BusinessListBase<CT_PhieuNhapList, CT_PhieuNhap>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_PhieuNhap item = CT_PhieuNhap.NewCT_PhieuNhap();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
        public static CT_PhieuNhapList NewCT_PhieuNhapList()
		{
			return new CT_PhieuNhapList();
		}

		internal static CT_PhieuNhapList GetCT_PhieuNhapList(long maPhieuNhap)
		{
			return new CT_PhieuNhapList(maPhieuNhap);
		}

		private CT_PhieuNhapList()
		{
			MarkAsChild();
		}

		private CT_PhieuNhapList(long maPhieuNhap)
		{
			MarkAsChild();
            Fetch(maPhieuNhap);
		}
		#endregion //Factory Methods


		#region Data Access
        private void Fetch(long maPhieuNhap)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_PhieuNhapsByAndMaPhieuNhap";
                    cm.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_PhieuNhap.GetCT_PhieuNhap(dr));
                    }
                }
            }
			RaiseListChangedEvents = true;
		}
        //M
        
        //M

		internal void Update(SqlTransaction tr, PhieuNhapXuat parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_PhieuNhap deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_PhieuNhap child in this)
			{
				if(child.IsNew)
					child.Insert(tr, parent);
				else
					child.Update(tr, parent);
			}

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access

        public static CT_PhieuNhapList GetCT_PhieuNhapList_ForXuatDichDanh(int MaKho, DateTime NgayNX)
        {
            CT_PhieuNhapList list = new CT_PhieuNhapList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_PhieuNhap_ForXuatDichDanh";
                    cm.Parameters.AddWithValue("@MaKho", MaKho);
                    cm.Parameters.AddWithValue("@NgayNX", NgayNX);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            list.Add(CT_PhieuNhap.GetCT_PhieuNhap_ForXuatDichDanh(dr));
                    }
                }
            }
            return list;          
        }
        public static CT_PhieuNhapList GetCT_PhieuNhapCCDCList_ForXuatDichDanh(int MaKho, byte phuongPhapNhapXuat, DateTime ngayNX)
        {
            CT_PhieuNhapList list = new CT_PhieuNhapList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetDSPhieuNhapCCDCThangChuaXuatHetTheoMaKhoandSoDuDauKy";
                    cm.Parameters.AddWithValue("@MaKho", MaKho);
                    cm.Parameters.AddWithValue("@PhuongPhapNX", phuongPhapNhapXuat);
                    cm.Parameters.AddWithValue("@NgayNX", ngayNX);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            list.Add(CT_PhieuNhap.GetCT_PhieuNhap_ForXuatDichDanh(dr));
                    }
                }
            }
            return list;
        }
	}
}
