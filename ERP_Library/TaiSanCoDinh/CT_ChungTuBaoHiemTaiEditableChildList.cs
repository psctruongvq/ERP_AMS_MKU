
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_ChungTuBaoHiemTaiSanList : BusinessListBase<CT_ChungTuBaoHiemTaiSanList, CT_ChungTuBaoHiemTaiSan>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_ChungTuBaoHiemTaiSan item = CT_ChungTuBaoHiemTaiSan.NewCT_ChungTuBaoHiemTaiSan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static CT_ChungTuBaoHiemTaiSanList NewCT_ChungTuBaoHiemTaiSanList()
		{
			return new CT_ChungTuBaoHiemTaiSanList();
		}

		internal static CT_ChungTuBaoHiemTaiSanList GetCT_ChungTuBaoHiemTaiSanList(long maChungTu)
		{
			return new CT_ChungTuBaoHiemTaiSanList(maChungTu);
		}

		private CT_ChungTuBaoHiemTaiSanList()
		{
			MarkAsChild();
		}

		private CT_ChungTuBaoHiemTaiSanList(long maChungTu)
		{
			MarkAsChild();
			Fetch(maChungTu);
		}
		#endregion //Factory Methods

		#region Data Access
		private void Fetch(long maChungTu)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_ChungTuBaoHiemTaiSanByMaChungTu";
					cm.CommandTimeout = 1800;
					cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_ChungTuBaoHiemTaiSan.GetCT_ChungTuBaoHiemTaiSan(dr));
                    }
                }
            }      
			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, ChungTuBaoHiemTaiSan parent)
		{
			RaiseListChangedEvents = false;
			// loop through each deleted child object
			foreach (CT_ChungTuBaoHiemTaiSan deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_ChungTuBaoHiemTaiSan child in this)
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
