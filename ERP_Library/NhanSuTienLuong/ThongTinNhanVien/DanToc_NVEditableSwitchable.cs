
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DanToc_NV : Csla.BusinessBase<DanToc_NV>
	{
		#region Business Properties and Methods

		//declare members
		private int _maDanToc = 0;
		private string _maQuanLy = string.Empty;
		private string _danToc = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaDanToc
		{
			get
			{
				CanReadProperty("MaDanToc", true);
				return _maDanToc;
			}
		}

		public string MaQuanLy
		{
			get
			{
				CanReadProperty("MaQuanLy", true);
				return _maQuanLy;
			}
			set
			{
				CanWriteProperty("MaQuanLy", true);
				if (value == null) value = string.Empty;
				if (!_maQuanLy.Equals(value))
				{
					_maQuanLy = value;
					PropertyHasChanged("MaQuanLy");
				}
			}
		}

		public string DanToc
		{
			get
			{
				CanReadProperty("DanToc", true);
				return _danToc;
			}
			set
			{
				CanWriteProperty("DanToc", true);
				if (value == null) value = string.Empty;
				if (!_danToc.Equals(value))
				{
					_danToc = value;
					PropertyHasChanged("DanToc");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maDanToc;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{
			//
			// MaQuanLy
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
			//
			// DanToc
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "DanToc");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DanToc", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Authorization Rules
		protected override void AddAuthorizationRules()
		{
			//TODO: Define authorization rules in DanToc_NV
			//AuthorizationRules.AllowRead("MaDanToc", "DanToc_NVReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "DanToc_NVReadGroup");
			//AuthorizationRules.AllowRead("DanToc", "DanToc_NVReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "DanToc_NVWriteGroup");
			//AuthorizationRules.AllowWrite("DanToc", "DanToc_NVWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DanToc_NV
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanToc_NVViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DanToc_NV
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanToc_NVAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DanToc_NV
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanToc_NVEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DanToc_NV
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanToc_NVDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DanToc_NV(int madantoc, string dantoc)
		{
            this._maDanToc = madantoc;
            this._danToc = dantoc;
        }

		public static DanToc_NV NewDanToc_NV(int madantoc, string tendantoc)
		{
            return new DanToc_NV(madantoc, tendantoc);
		}
        private DanToc_NV()
        { /* require use of factory method */ }

        public static DanToc_NV NewDanToc_NV()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DanToc_NV");
            return DataPortal.Create<DanToc_NV>();
        }
		public static DanToc_NV GetDanToc_NV(int maDanToc)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DanToc_NV");
			return DataPortal.Fetch<DanToc_NV>(new Criteria(maDanToc));
		}

		public static void DeleteDanToc_NV(int maDanToc)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DanToc_NV");
			DataPortal.Delete(new Criteria(maDanToc));
		}

		public override DanToc_NV Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DanToc_NV");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DanToc_NV");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DanToc_NV");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static DanToc_NV NewDanToc_NVChild()
		{
			DanToc_NV child = new DanToc_NV();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DanToc_NV GetDanToc_NV(SafeDataReader dr)
		{
			DanToc_NV child =  new DanToc_NV();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaDanToc;

			public Criteria(int maDanToc)
			{
				this.MaDanToc = maDanToc;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsDanToc";

				cm.Parameters.AddWithValue("@MaDanToc", criteria.MaDanToc);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					ValidationRules.CheckRules();

					//load child object(s)
					FetchChildren(dr);
				}
			}//using
		}

		#endregion //Data Access - Fetch

		#region Data Access - Insert
		protected override void DataPortal_Insert()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn);

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				if (base.IsDirty)
				{
					ExecuteUpdate(cn);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maDanToc));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteDelete(cn, criteria);

			}//using

		}

		private void ExecuteDelete(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsDanToc";

				cm.Parameters.AddWithValue("@MaDanToc", criteria.MaDanToc);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maDanToc = dr.GetInt32("MaDanToc");
			_maQuanLy = dr.GetString("MaQuanLy");
			_danToc = dr.GetString("DanToc");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsDanToc";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maDanToc = (int)cm.Parameters["@MaDanToc"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@DanToc", _danToc);
			cm.Parameters.AddWithValue("@MaDanToc", _maDanToc);
			cm.Parameters["@MaDanToc"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsDanToc";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaDanToc", _maDanToc);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@DanToc", _danToc);
		}

		private void UpdateChildren(SqlConnection cn)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlConnection cn)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(cn, new Criteria(_maDanToc));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
