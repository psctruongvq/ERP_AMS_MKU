
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_PhieuNhapBQList : Csla.BusinessListBase<CT_PhieuNhapBQList, CT_PhieuNhapBQ>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_PhieuNhapBQ item = CT_PhieuNhapBQ.NewCT_PhieuNhap();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
        public static CT_PhieuNhapBQList NewCT_PhieuNhapList()
		{
			return new CT_PhieuNhapBQList();
		}

		internal static CT_PhieuNhapBQList GetCT_PhieuNhapList(long maPhieuNhap)
		{
			return new CT_PhieuNhapBQList(maPhieuNhap);
		}

		private CT_PhieuNhapBQList()
		{
			MarkAsChild();
		}

		private CT_PhieuNhapBQList(long maPhieuNhap)
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
                    cm.CommandText = "spd_SelecttblCT_PhieuNhapsByAndMaPhieuNhap_BQ";
                    cm.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_PhieuNhapBQ.GetCT_PhieuNhap(dr));
                    }
                }
            }
			RaiseListChangedEvents = true;
		}
        //M
        
        //M

        internal void Update(SqlTransaction tr, PhieuNhapXuatBQ parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_PhieuNhapBQ deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_PhieuNhapBQ child in this)
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
