
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_PhieuNhapCCDCList : Csla.BusinessListBase<CT_PhieuNhapCCDCList, CT_PhieuNhapCCDC>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_PhieuNhapCCDC item = CT_PhieuNhapCCDC.NewCT_PhieuNhap();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
        public static CT_PhieuNhapCCDCList NewCT_PhieuNhapList()
		{
			return new CT_PhieuNhapCCDCList();
		}

		internal static CT_PhieuNhapCCDCList GetCT_PhieuNhapList(long maPhieuNhap)
		{
			return new CT_PhieuNhapCCDCList(maPhieuNhap);
		}

		private CT_PhieuNhapCCDCList()
		{
			MarkAsChild();
		}

        private CT_PhieuNhapCCDCList(long maPhieuNhap)
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
                            this.Add(CT_PhieuNhapCCDC.GetCT_PhieuNhap(dr));
                    }
                }
            }
			RaiseListChangedEvents = true;
		}
        //M
        
        //M

        internal void Update(SqlTransaction tr, PhieuNhapXuatCCDC parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
            foreach (CT_PhieuNhapCCDC deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
            foreach (CT_PhieuNhapCCDC child in this)
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
