
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_KHCapPhatVatTuList : Csla.BusinessListBase<CT_KHCapPhatVatTuList, CT_KHCapPhatVatTu>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_KHCapPhatVatTu item = CT_KHCapPhatVatTu.NewCT_KHCapPhatVatTu();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static CT_KHCapPhatVatTuList NewCT_KHCapPhatVatTuList()
		{
			return new CT_KHCapPhatVatTuList();
		}

		internal static CT_KHCapPhatVatTuList GetCT_KHCapPhatVatTuList(int maKeHoach)
		{
            return new CT_KHCapPhatVatTuList(maKeHoach);
		}

		private CT_KHCapPhatVatTuList()
		{
			MarkAsChild();
		}

		private CT_KHCapPhatVatTuList(int maKeHoach)
		{
			MarkAsChild();
            Fetch(maKeHoach);
		}
		#endregion //Factory Methods


		#region Data Access
		private void Fetch(int  maKeHoach)
		{
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelectCT_KeHoachCapPhatVatTusAll";
                    cm.Parameters.AddWithValue("@MaKeHoachCapPhatVattu", maKeHoach);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_KHCapPhatVatTu.GetCT_KHCapPhatVatTu(dr));
                    }
                }
            }
            RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, KHCapPhatVatTu parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_KHCapPhatVatTu deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_KHCapPhatVatTu child in this)
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
