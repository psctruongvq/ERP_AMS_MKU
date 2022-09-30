
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_ToKhaiThueList : Csla.BusinessListBase<CT_ToKhaiThueList, CT_ToKhaiThue>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CT_ToKhaiThue item = CT_ToKhaiThue.NewCT_ToKhaiThue();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static CT_ToKhaiThueList NewCT_ToKhaiThueList()
		{
			return new CT_ToKhaiThueList();
		}

		internal static CT_ToKhaiThueList GetCT_ToKhaiThueList(int MaToKhai)
		{
            return new CT_ToKhaiThueList(MaToKhai);
		}

		private CT_ToKhaiThueList()
		{
			MarkAsChild();
		}

		private CT_ToKhaiThueList(int MaToKhai)
		{
			MarkAsChild();
			Fetch(MaToKhai);
		}
		#endregion //Factory Methods


		#region Data Access
		private void Fetch(int MaToKhai)
		{
			RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_ToKhaiThuesByMaToKhaiThue";
                    cm.Parameters.AddWithValue("@MaToKhaiThue", MaToKhai);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_ToKhaiThue.GetCT_ToKhaiThue(dr));
                    }
                }
            }

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, ToKhaiThue parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_ToKhaiThue deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_ToKhaiThue child in this)
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
