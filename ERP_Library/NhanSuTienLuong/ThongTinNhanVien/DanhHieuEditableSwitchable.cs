
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DanhHieu : Csla.BusinessBase<DanhHieu>
	{
		#region Business Properties and Methods

		//declare members
		private int _maDanhHieu = 0;
		private string _maQuanLy = string.Empty;
		private string _tenDanhHieu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaDanhHieu
		{
			get
			{
				CanReadProperty("MaDanhHieu", true);
				return _maDanhHieu;
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

		public string TenDanhHieu
		{
			get
			{
				CanReadProperty("TenDanhHieu", true);
				return _tenDanhHieu;
			}
			set
			{
				CanWriteProperty("TenDanhHieu", true);
				if (value == null) value = string.Empty;
				if (!_tenDanhHieu.Equals(value))
				{
					_tenDanhHieu = value;
					PropertyHasChanged("TenDanhHieu");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maDanhHieu;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
			//
			// TenDanhHieu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDanhHieu", 150));
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
			//TODO: Define authorization rules in DanhHieu
			//AuthorizationRules.AllowRead("MaDanhHieu", "DanhHieuReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "DanhHieuReadGroup");
			//AuthorizationRules.AllowRead("TenDanhHieu", "DanhHieuReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "DanhHieuWriteGroup");
			//AuthorizationRules.AllowWrite("TenDanhHieu", "DanhHieuWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DanhHieu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhHieuViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DanhHieu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhHieuAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DanhHieu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhHieuEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DanhHieu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhHieuDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DanhHieu()
		{ /* require use of factory method */ }

		public static DanhHieu NewDanhHieu()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DanhHieu");
			return DataPortal.Create<DanhHieu>();
		}
        public static DanhHieu NewDanhHieu(string s)
        {
            DanhHieu item = new DanhHieu();
            item.TenDanhHieu = s;
            item.MarkAsChild();
            return item;
        }
		public static DanhHieu GetDanhHieu(int maDanhHieu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DanhHieu");
			return DataPortal.Fetch<DanhHieu>(new Criteria(maDanhHieu));
		}

		public static void DeleteDanhHieu(int maDanhHieu)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DanhHieu");
			DataPortal.Delete(new Criteria(maDanhHieu));
		}

		public override DanhHieu Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DanhHieu");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DanhHieu");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DanhHieu");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static DanhHieu NewDanhHieuChild()
		{
			DanhHieu child = new DanhHieu();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DanhHieu GetDanhHieu(SafeDataReader dr)
		{
			DanhHieu child =  new DanhHieu();
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
			public int MaDanhHieu;

			public Criteria(int maDanhHieu)
			{
				this.MaDanhHieu = maDanhHieu;
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
                cm.CommandText = "spd_SelecttblnsDanhHieu";

				cm.Parameters.AddWithValue("@MaDanhHieu", criteria.MaDanhHieu);

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
			DataPortal_Delete(new Criteria(_maDanhHieu));
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
                cm.CommandText = "spd_DeletetblnsDanhHieu";

				cm.Parameters.AddWithValue("@MaDanhHieu", criteria.MaDanhHieu);

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
			_maDanhHieu = dr.GetInt32("MaDanhHieu");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenDanhHieu = dr.GetString("TenDanhHieu");
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
                cm.CommandText = "spd_InserttblnsDanhHieu";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maDanhHieu = (int)cm.Parameters["@MaDanhHieu"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_tenDanhHieu.Length > 0)
				cm.Parameters.AddWithValue("@TenDanhHieu", _tenDanhHieu);
			else
				cm.Parameters.AddWithValue("@TenDanhHieu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaDanhHieu", _maDanhHieu);
			cm.Parameters["@MaDanhHieu"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsDanhHieu";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaDanhHieu", _maDanhHieu);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_tenDanhHieu.Length > 0)
				cm.Parameters.AddWithValue("@TenDanhHieu", _tenDanhHieu);
			else
				cm.Parameters.AddWithValue("@TenDanhHieu", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maDanhHieu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
