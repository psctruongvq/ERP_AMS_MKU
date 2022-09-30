
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_HopDongMuaBanNgoaiTeList : Csla.BusinessListBase<CT_HopDongMuaBanNgoaiTeList, CT_HopDongMuaBanNgoaiTe>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_HopDongMuaBanNgoaiTe item = CT_HopDongMuaBanNgoaiTe.NewCT_HopDongMuaBanNgoaiTe();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static CT_HopDongMuaBanNgoaiTeList NewCT_HopDongMuaBanNgoaiTeList()
		{
			return new CT_HopDongMuaBanNgoaiTeList();
		}

		internal static CT_HopDongMuaBanNgoaiTeList GetCT_HopDongMuaBanNgoaiTeList(long maHopDong)
		{
			return new CT_HopDongMuaBanNgoaiTeList(maHopDong);
		}

		private CT_HopDongMuaBanNgoaiTeList()
		{
			MarkAsChild();
		}

		private CT_HopDongMuaBanNgoaiTeList(long maHopDong)
		{
			MarkAsChild();
			Fetch(maHopDong);
		}
		#endregion //Factory Methods

		#region Data Access
		private void Fetch(long maHopDong)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_HopDongMuaBanNgoaiTesByMaHopDong";

                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_HopDongMuaBanNgoaiTe.GetCT_HopDongMuaBanNgoaiTe(dr));
                    }
                }
            }
			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, HopDongMuaBan parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_HopDongMuaBanNgoaiTe deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_HopDongMuaBanNgoaiTe child in this)
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
