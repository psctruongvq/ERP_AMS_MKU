
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiTaiNan : Csla.BusinessBase<LoaiTaiNan>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiTaiNan = 0;
		private string _maQuanLy = string.Empty;
		private string _tenLoaiTaiNan = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLoaiTaiNan
		{
			get
			{
				CanReadProperty("MaLoaiTaiNan", true);
				return _maLoaiTaiNan;
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

		public string TenLoaiTaiNan
		{
			get
			{
				CanReadProperty("TenLoaiTaiNan", true);
				return _tenLoaiTaiNan;
			}
			set
			{
				CanWriteProperty("TenLoaiTaiNan", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiTaiNan.Equals(value))
				{
					_tenLoaiTaiNan = value;
					PropertyHasChanged("TenLoaiTaiNan");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maLoaiTaiNan;
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
			// TenLoaiTaiNan
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenLoaiTaiNan");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiTaiNan", 500));
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
			//TODO: Define authorization rules in LoaiTaiNan
			//AuthorizationRules.AllowRead("MaLoaiTaiNan", "LoaiTaiNanReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "LoaiTaiNanReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiTaiNan", "LoaiTaiNanReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "LoaiTaiNanWriteGroup");
			//AuthorizationRules.AllowWrite("TenLoaiTaiNan", "LoaiTaiNanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiTaiNan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTaiNanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiTaiNan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTaiNanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiTaiNan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTaiNanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiTaiNan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTaiNanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiTaiNan()
		{ /* require use of factory method */ }

		public static LoaiTaiNan NewLoaiTaiNan()
		{
            LoaiTaiNan item = new LoaiTaiNan();
            item.MarkAsChild();
            return item;
		}

		public static LoaiTaiNan GetLoaiTaiNan(int maLoaiTaiNan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiTaiNan");
			return DataPortal.Fetch<LoaiTaiNan>(new Criteria(maLoaiTaiNan));
		}

		public static void DeleteLoaiTaiNan(int maLoaiTaiNan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiTaiNan");
			DataPortal.Delete(new Criteria(maLoaiTaiNan));
		}

		public override LoaiTaiNan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiTaiNan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiTaiNan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiTaiNan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LoaiTaiNan NewLoaiTaiNanChild()
		{
			LoaiTaiNan child = new LoaiTaiNan();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiTaiNan GetLoaiTaiNan(SafeDataReader dr)
		{
			LoaiTaiNan child =  new LoaiTaiNan();
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
			public int MaLoaiTaiNan;

			public Criteria(int maLoaiTaiNan)
			{
				this.MaLoaiTaiNan = maLoaiTaiNan;
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
                cm.CommandText = "spd_SelecttblnsLoaiTaiNan";

				cm.Parameters.AddWithValue("@MaLoaiTaiNan", criteria.MaLoaiTaiNan);

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
			DataPortal_Delete(new Criteria(_maLoaiTaiNan));
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
                cm.CommandText = "spd_DeletetblnsLoaiTaiNan";

				cm.Parameters.AddWithValue("@MaLoaiTaiNan", criteria.MaLoaiTaiNan);

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
			_maLoaiTaiNan = dr.GetInt32("MaLoaiTaiNan");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenLoaiTaiNan = dr.GetString("TenLoaiTaiNan");
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
                cm.CommandText = "spd_InserttblnsLoaiTaiNan";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maLoaiTaiNan = (int)cm.Parameters["@MaLoaiTaiNan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenLoaiTaiNan", _tenLoaiTaiNan);
			cm.Parameters.AddWithValue("@MaLoaiTaiNan", _maLoaiTaiNan);
			cm.Parameters["@MaLoaiTaiNan"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsLoaiTaiNan";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaLoaiTaiNan", _maLoaiTaiNan);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenLoaiTaiNan", _tenLoaiTaiNan);
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

			ExecuteDelete(cn, new Criteria(_maLoaiTaiNan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
