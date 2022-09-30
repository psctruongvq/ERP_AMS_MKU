
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiHoaDon : Csla.BusinessBase<LoaiHoaDon>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiHoaDon = 0;
		private string _tenLoaiHonDon = string.Empty;
		private string _maQuanLy = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLoaiHoaDon
		{
			get
			{
				CanReadProperty("MaLoaiHoaDon", true);
				return _maLoaiHoaDon;
			}
		}

		public string TenLoaiHonDon
		{
			get
			{
				CanReadProperty("TenLoaiHonDon", true);
				return _tenLoaiHonDon;
			}
			set
			{
				CanWriteProperty("TenLoaiHonDon", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiHonDon.Equals(value))
				{
					_tenLoaiHonDon = value;
					PropertyHasChanged("TenLoaiHonDon");
				}
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
 
		protected override object GetIdValue()
		{
			return _maLoaiHoaDon;
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
			// TenLoaiHonDon
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenLoaiHonDon");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiHonDon", 500));
			//
			// MaQuanLy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
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
			//TODO: Define authorization rules in LoaiHoaDon
			//AuthorizationRules.AllowRead("MaLoaiHoaDon", "LoaiHoaDonReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiHonDon", "LoaiHoaDonReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "LoaiHoaDonReadGroup");

			//AuthorizationRules.AllowWrite("TenLoaiHonDon", "LoaiHoaDonWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanLy", "LoaiHoaDonWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiHoaDon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiHoaDonViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiHoaDon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiHoaDonAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiHoaDon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiHoaDonEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiHoaDon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiHoaDonDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiHoaDon()
		{ /* require use of factory method */ }

		public static LoaiHoaDon NewLoaiHoaDon()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiHoaDon");
			return DataPortal.Create<LoaiHoaDon>();
		}

		public static LoaiHoaDon GetLoaiHoaDon(int maLoaiHoaDon)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiHoaDon");
			return DataPortal.Fetch<LoaiHoaDon>(new Criteria(maLoaiHoaDon));
		}

		public static void DeleteLoaiHoaDon(int maLoaiHoaDon)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiHoaDon");
			DataPortal.Delete(new Criteria(maLoaiHoaDon));
		}

		public override LoaiHoaDon Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiHoaDon");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiHoaDon");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiHoaDon");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LoaiHoaDon NewLoaiHoaDonChild()
		{
			LoaiHoaDon child = new LoaiHoaDon();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiHoaDon GetLoaiHoaDon(SafeDataReader dr)
		{
			LoaiHoaDon child =  new LoaiHoaDon();
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
			public int MaLoaiHoaDon;

			public Criteria(int maLoaiHoaDon)
			{
				this.MaLoaiHoaDon = maLoaiHoaDon;
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
                cm.CommandText = "spd_SelecttblLoaiHoaDon";

				cm.Parameters.AddWithValue("@MaLoaiHoaDon", criteria.MaLoaiHoaDon);

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
			DataPortal_Delete(new Criteria(_maLoaiHoaDon));
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
                cm.CommandText = "spd_DeletetblLoaiHoaDon";

				cm.Parameters.AddWithValue("@MaLoaiHoaDon", criteria.MaLoaiHoaDon);

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
			_maLoaiHoaDon = dr.GetInt32("MaLoaiHoaDon");
			_tenLoaiHonDon = dr.GetString("TenLoaiHonDon");
			_maQuanLy = dr.GetString("MaQuanLy");
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
                cm.CommandText = "spd_InserttblLoaiHoaDon";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maLoaiHoaDon = (int)cm.Parameters["@MaLoaiHoaDon"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@TenLoaiHonDon", _tenLoaiHonDon);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			cm.Parameters.AddWithValue("@MaLoaiHoaDon", _maLoaiHoaDon);
			cm.Parameters["@MaLoaiHoaDon"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblLoaiHoaDon";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaLoaiHoaDon", _maLoaiHoaDon);
			cm.Parameters.AddWithValue("@TenLoaiHonDon", _tenLoaiHonDon);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maLoaiHoaDon));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
