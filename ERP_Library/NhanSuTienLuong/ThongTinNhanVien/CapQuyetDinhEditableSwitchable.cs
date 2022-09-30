
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CapQuyetDinh : Csla.BusinessBase<CapQuyetDinh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maCapQuyetDinh = 0;
		private string _maQuanLy = string.Empty;
		private string _tenCapQuyetDinh = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaCapQuyetDinh
		{
			get
			{
				CanReadProperty("MaCapQuyetDinh", true);
				return _maCapQuyetDinh;
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

		public string TenCapQuyetDinh
		{
			get
			{
				CanReadProperty("TenCapQuyetDinh", true);
				return _tenCapQuyetDinh;
			}
			set
			{
				CanWriteProperty("TenCapQuyetDinh", true);
				if (value == null) value = string.Empty;
				if (!_tenCapQuyetDinh.Equals(value))
				{
					_tenCapQuyetDinh = value;
					PropertyHasChanged("TenCapQuyetDinh");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maCapQuyetDinh;
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
			// TenCapQuyetDinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenCapQuyetDinh", 150));
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
			//TODO: Define authorization rules in CapQuyetDinh
			//AuthorizationRules.AllowRead("MaCapQuyetDinh", "CapQuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "CapQuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("TenCapQuyetDinh", "CapQuyetDinhReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "CapQuyetDinhWriteGroup");
			//AuthorizationRules.AllowWrite("TenCapQuyetDinh", "CapQuyetDinhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CapQuyetDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CapQuyetDinhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CapQuyetDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CapQuyetDinhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CapQuyetDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CapQuyetDinhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CapQuyetDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CapQuyetDinhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CapQuyetDinh()
		{ /* require use of factory method */ }

		public static CapQuyetDinh NewCapQuyetDinh()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CapQuyetDinh");
			return DataPortal.Create<CapQuyetDinh>();
		}
        public static CapQuyetDinh NewCapQuyetDinh(string s)
        {
            CapQuyetDinh item = new CapQuyetDinh();
            item.TenCapQuyetDinh = s;
            return item;
        }

		public static CapQuyetDinh GetCapQuyetDinh(int maCapQuyetDinh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CapQuyetDinh");
			return DataPortal.Fetch<CapQuyetDinh>(new Criteria(maCapQuyetDinh));
		}

		public static void DeleteCapQuyetDinh(int maCapQuyetDinh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CapQuyetDinh");
			DataPortal.Delete(new Criteria(maCapQuyetDinh));
		}

		public override CapQuyetDinh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CapQuyetDinh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CapQuyetDinh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a CapQuyetDinh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static CapQuyetDinh NewCapQuyetDinhChild()
		{
			CapQuyetDinh child = new CapQuyetDinh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static CapQuyetDinh GetCapQuyetDinh(SafeDataReader dr)
		{
			CapQuyetDinh child =  new CapQuyetDinh();
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
			public int MaCapQuyetDinh;

			public Criteria(int maCapQuyetDinh)
			{
				this.MaCapQuyetDinh = maCapQuyetDinh;
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
                cm.CommandText = "spd_SelecttblnsCapQuyetDinh";

				cm.Parameters.AddWithValue("@MaCapQuyetDinh", criteria.MaCapQuyetDinh);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
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
			DataPortal_Delete(new Criteria(_maCapQuyetDinh));
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
                cm.CommandText = "spd_DeletetblnsCapQuyetDinh";

				cm.Parameters.AddWithValue("@MaCapQuyetDinh", criteria.MaCapQuyetDinh);

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
			_maCapQuyetDinh = dr.GetInt32("MaCapQuyetDinh");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenCapQuyetDinh = dr.GetString("TenCapQuyetDinh");
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
                cm.CommandText = "spd_InserttblnsCapQuyetDinh";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maCapQuyetDinh = (int)cm.Parameters["@MaCapQuyetDinh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_tenCapQuyetDinh.Length > 0)
				cm.Parameters.AddWithValue("@TenCapQuyetDinh", _tenCapQuyetDinh);
			else
				cm.Parameters.AddWithValue("@TenCapQuyetDinh", DBNull.Value);
			cm.Parameters.AddWithValue("@MaCapQuyetDinh", _maCapQuyetDinh);
			cm.Parameters["@MaCapQuyetDinh"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsCapQuyetDinh";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaCapQuyetDinh", _maCapQuyetDinh);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_tenCapQuyetDinh.Length > 0)
				cm.Parameters.AddWithValue("@TenCapQuyetDinh", _tenCapQuyetDinh);
			else
				cm.Parameters.AddWithValue("@TenCapQuyetDinh", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maCapQuyetDinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
