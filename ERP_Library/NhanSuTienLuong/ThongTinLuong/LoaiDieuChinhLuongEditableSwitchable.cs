
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiDieuChinhLuong : Csla.BusinessBase<LoaiDieuChinhLuong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiDieuChinh = 0;
		private string _maQuanLy = string.Empty;
		private string _tenLoaiDieuChinh = string.Empty;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLoaiDieuChinh
		{
			get
			{
				CanReadProperty("MaLoaiDieuChinh", true);
				return _maLoaiDieuChinh;
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

		public string TenLoaiDieuChinh
		{
			get
			{
				CanReadProperty("TenLoaiDieuChinh", true);
				return _tenLoaiDieuChinh;
			}
			set
			{
				CanWriteProperty("TenLoaiDieuChinh", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiDieuChinh.Equals(value))
				{
					_tenLoaiDieuChinh = value;
					PropertyHasChanged("TenLoaiDieuChinh");
				}
			}
		}

		public string GhiChu
		{
			get
			{
				CanReadProperty("GhiChu", true);
				return _ghiChu;
			}
			set
			{
				CanWriteProperty("GhiChu", true);
				if (value == null) value = string.Empty;
				if (!_ghiChu.Equals(value))
				{
					_ghiChu = value;
					PropertyHasChanged("GhiChu");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maLoaiDieuChinh;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
			//
			// TenLoaiDieuChinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiDieuChinh", 1000));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 1000));
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
			//TODO: Define authorization rules in LoaiDieuChinhLuong
			//AuthorizationRules.AllowRead("MaLoaiDieuChinh", "LoaiDieuChinhLuongReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "LoaiDieuChinhLuongReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiDieuChinh", "LoaiDieuChinhLuongReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "LoaiDieuChinhLuongReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "LoaiDieuChinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("TenLoaiDieuChinh", "LoaiDieuChinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "LoaiDieuChinhLuongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiDieuChinhLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiDieuChinhLuongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiDieuChinhLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiDieuChinhLuongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiDieuChinhLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiDieuChinhLuongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiDieuChinhLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiDieuChinhLuongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiDieuChinhLuong()
		{ /* require use of factory method */ }

		public static LoaiDieuChinhLuong NewLoaiDieuChinhLuong()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiDieuChinhLuong");
			return DataPortal.Create<LoaiDieuChinhLuong>();
		}

		public static LoaiDieuChinhLuong GetLoaiDieuChinhLuong(int maLoaiDieuChinh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiDieuChinhLuong");
			return DataPortal.Fetch<LoaiDieuChinhLuong>(new Criteria(maLoaiDieuChinh));
		}

		public static void DeleteLoaiDieuChinhLuong(int maLoaiDieuChinh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiDieuChinhLuong");
			DataPortal.Delete(new Criteria(maLoaiDieuChinh));
		}

		public override LoaiDieuChinhLuong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiDieuChinhLuong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiDieuChinhLuong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiDieuChinhLuong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LoaiDieuChinhLuong NewLoaiDieuChinhLuongChild()
		{
			LoaiDieuChinhLuong child = new LoaiDieuChinhLuong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiDieuChinhLuong GetLoaiDieuChinhLuong(SafeDataReader dr)
		{
			LoaiDieuChinhLuong child =  new LoaiDieuChinhLuong();
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
			public int MaLoaiDieuChinh;

			public Criteria(int maLoaiDieuChinh)
			{
				this.MaLoaiDieuChinh = maLoaiDieuChinh;
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
                cm.CommandText = "spd_SelecttblnsLoaiDieuChinhLuong";

				cm.Parameters.AddWithValue("@MaLoaiDieuChinh", criteria.MaLoaiDieuChinh);

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
			DataPortal_Delete(new Criteria(_maLoaiDieuChinh));
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
                cm.CommandText = "spd_DeletetblnsLoaiDieuChinhLuong";

				cm.Parameters.AddWithValue("@MaLoaiDieuChinh", criteria.MaLoaiDieuChinh);

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
			_maLoaiDieuChinh = dr.GetInt32("MaLoaiDieuChinh");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenLoaiDieuChinh = dr.GetString("TenLoaiDieuChinh");
			_ghiChu = dr.GetString("GhiChu");
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
                cm.CommandText = "spd_InserttblnsLoaiDieuChinhLuong";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maLoaiDieuChinh = (int)cm.Parameters["@MaLoaiDieuChinh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenLoaiDieuChinh.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiDieuChinh", _tenLoaiDieuChinh);
			else
				cm.Parameters.AddWithValue("@TenLoaiDieuChinh", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaLoaiDieuChinh", _maLoaiDieuChinh);
			cm.Parameters["@MaLoaiDieuChinh"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsLoaiDieuChinhLuong";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaLoaiDieuChinh", _maLoaiDieuChinh);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenLoaiDieuChinh.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiDieuChinh", _tenLoaiDieuChinh);
			else
				cm.Parameters.AddWithValue("@TenLoaiDieuChinh", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maLoaiDieuChinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
