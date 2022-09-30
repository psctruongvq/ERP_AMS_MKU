
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiQuyetDinh : Csla.BusinessBase<LoaiQuyetDinh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiQuyetDinh = 0;
		private string _maQuanLy = string.Empty;
		private string _tenLoaiQuyetDinh = string.Empty;
		private bool _loai = false;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLoaiQuyetDinh
		{
			get
			{
				CanReadProperty("MaLoaiQuyetDinh", true);
				return _maLoaiQuyetDinh;
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

		public string TenLoaiQuyetDinh
		{
			get
			{
				CanReadProperty("TenLoaiQuyetDinh", true);
				return _tenLoaiQuyetDinh;
			}
			set
			{
				CanWriteProperty("TenLoaiQuyetDinh", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiQuyetDinh.Equals(value))
				{
					_tenLoaiQuyetDinh = value;
					PropertyHasChanged("TenLoaiQuyetDinh");
				}
			}
		}

		public bool Loai
		{
			get
			{
				CanReadProperty("Loai", true);
				return _loai;
			}
			set
			{
				CanWriteProperty("Loai", true);
				if (!_loai.Equals(value))
				{
					_loai = value;
					PropertyHasChanged("Loai");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maLoaiQuyetDinh;
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
			// TenLoaiQuyetDinh
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenLoaiQuyetDinh");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiQuyetDinh", 500));
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
			//TODO: Define authorization rules in LoaiQuyetDinh
			//AuthorizationRules.AllowRead("MaLoaiQuyetDinh", "LoaiQuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "LoaiQuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiQuyetDinh", "LoaiQuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("Loai", "LoaiQuyetDinhReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "LoaiQuyetDinhWriteGroup");
			//AuthorizationRules.AllowWrite("TenLoaiQuyetDinh", "LoaiQuyetDinhWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "LoaiQuyetDinhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiQuyetDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiQuyetDinhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiQuyetDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiQuyetDinhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiQuyetDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiQuyetDinhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiQuyetDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiQuyetDinhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiQuyetDinh()
		{ /* require use of factory method */ }

		public static LoaiQuyetDinh NewLoaiQuyetDinh()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiQuyetDinh");
			return DataPortal.Create<LoaiQuyetDinh>();
		}

		public static LoaiQuyetDinh GetLoaiQuyetDinh(int maLoaiQuyetDinh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiQuyetDinh");
			return DataPortal.Fetch<LoaiQuyetDinh>(new Criteria(maLoaiQuyetDinh));
		}

		public static void DeleteLoaiQuyetDinh(int maLoaiQuyetDinh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiQuyetDinh");
			DataPortal.Delete(new Criteria(maLoaiQuyetDinh));
		}

		public override LoaiQuyetDinh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiQuyetDinh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiQuyetDinh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiQuyetDinh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LoaiQuyetDinh NewLoaiQuyetDinhChild()
		{
			LoaiQuyetDinh child = new LoaiQuyetDinh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiQuyetDinh GetLoaiQuyetDinh(SafeDataReader dr)
		{
			LoaiQuyetDinh child =  new LoaiQuyetDinh();
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
			public int MaLoaiQuyetDinh;

			public Criteria(int maLoaiQuyetDinh)
			{
				this.MaLoaiQuyetDinh = maLoaiQuyetDinh;
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
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteFetch(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using
		}

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsLoaiQuyetDinh";

				cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", criteria.MaLoaiQuyetDinh);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    if (dr.Read())
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
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteInsert(tr);

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					if (base.IsDirty)
					{
						ExecuteUpdate(tr);
					}

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maLoaiQuyetDinh));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteDelete(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsLoaiQuyetDinh";

				cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", criteria.MaLoaiQuyetDinh);

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
			_maLoaiQuyetDinh = dr.GetInt32("MaLoaiQuyetDinh");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenLoaiQuyetDinh = dr.GetString("TenLoaiQuyetDinh");
			_loai = dr.GetBoolean("Loai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsLoaiQuyetDinh";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maLoaiQuyetDinh = (int)cm.Parameters["@MaLoaiQuyetDinh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenLoaiQuyetDinh", _tenLoaiQuyetDinh);
			cm.Parameters.AddWithValue("@Loai", _loai);
			cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", _maLoaiQuyetDinh);
			cm.Parameters["@MaLoaiQuyetDinh"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsLoaiQuyetDinh";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", _maLoaiQuyetDinh);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenLoaiQuyetDinh", _tenLoaiQuyetDinh);
			cm.Parameters.AddWithValue("@Loai", _loai);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(tr, new Criteria(_maLoaiQuyetDinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
