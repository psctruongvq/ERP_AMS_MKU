
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhuongThucThanhToan : Csla.BusinessBase<PhuongThucThanhToan>
	{
		#region Business Properties and Methods

		//declare members
		private int _maPhuongThucThanhToan = 0;
		private string _maQuanLyPTTT = string.Empty;
		private string _tenPhuongThucThanhToan = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaPhuongThucThanhToan
		{
			get
			{
				CanReadProperty("MaPhuongThucThanhToan", true);
				return _maPhuongThucThanhToan;
			}
		}

		public string MaQuanLyPTTT
		{
			get
			{
				CanReadProperty("MaQuanLyPTTT", true);
				return _maQuanLyPTTT;
			}
			set
			{
				CanWriteProperty("MaQuanLyPTTT", true);
				if (value == null) value = string.Empty;
				if (!_maQuanLyPTTT.Equals(value))
				{
					_maQuanLyPTTT = value;
					PropertyHasChanged("MaQuanLyPTTT");
				}
			}
		}

		public string TenPhuongThucThanhToan
		{
			get
			{
				CanReadProperty("TenPhuongThucThanhToan", true);
				return _tenPhuongThucThanhToan;
			}
			set
			{
				CanWriteProperty("TenPhuongThucThanhToan", true);
				if (value == null) value = string.Empty;
				if (!_tenPhuongThucThanhToan.Equals(value))
				{
					_tenPhuongThucThanhToan = value;
					PropertyHasChanged("TenPhuongThucThanhToan");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maPhuongThucThanhToan;
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
			// MaQuanLyPTTT
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLyPTTT", 50));
			//
			// TenPhuongThucThanhToan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenPhuongThucThanhToan", 500));
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
			//TODO: Define authorization rules in PhuongThucThanhToan
			//AuthorizationRules.AllowRead("MaPhuongThucThanhToan", "PhuongThucThanhToanReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLyPTTT", "PhuongThucThanhToanReadGroup");
			//AuthorizationRules.AllowRead("TenPhuongThucThanhToan", "PhuongThucThanhToanReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLyPTTT", "PhuongThucThanhToanWriteGroup");
			//AuthorizationRules.AllowWrite("TenPhuongThucThanhToan", "PhuongThucThanhToanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhuongThucThanhToan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucThanhToanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhuongThucThanhToan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucThanhToanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhuongThucThanhToan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucThanhToanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhuongThucThanhToan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucThanhToanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		public PhuongThucThanhToan()
		{ /* require use of factory method */
            MarkAsChild();
        }

		public static PhuongThucThanhToan NewPhuongThucThanhToan()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhuongThucThanhToan");
			return DataPortal.Create<PhuongThucThanhToan>();
		}

		public static PhuongThucThanhToan GetPhuongThucThanhToan(int maPhuongThucThanhToan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhuongThucThanhToan");
			return DataPortal.Fetch<PhuongThucThanhToan>(new Criteria(maPhuongThucThanhToan));
		}

		public static void DeletePhuongThucThanhToan(int maPhuongThucThanhToan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhuongThucThanhToan");
			DataPortal.Delete(new Criteria(maPhuongThucThanhToan));
		}

		public override PhuongThucThanhToan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhuongThucThanhToan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhuongThucThanhToan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a PhuongThucThanhToan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static PhuongThucThanhToan NewPhuongThucThanhToanChild()
		{
			PhuongThucThanhToan child = new PhuongThucThanhToan();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhuongThucThanhToan GetPhuongThucThanhToan(SafeDataReader dr)
		{
			PhuongThucThanhToan child =  new PhuongThucThanhToan();
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
			public int MaPhuongThucThanhToan;

			public Criteria(int maPhuongThucThanhToan)
			{
				this.MaPhuongThucThanhToan = maPhuongThucThanhToan;
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
                cm.CommandText = "spd_SelecttblPhuongThucThanhToan";

				cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", criteria.MaPhuongThucThanhToan);

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
			DataPortal_Delete(new Criteria(_maPhuongThucThanhToan));
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
                cm.CommandText = "spd_DeletetblPhuongThucThanhToan";

				cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", criteria.MaPhuongThucThanhToan);

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
			_maPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
			_maQuanLyPTTT = dr.GetString("MaQuanLyPTTT");
			_tenPhuongThucThanhToan = dr.GetString("TenPhuongThucThanhToan");
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
                cm.CommandText = "spd_InserttblPhuongThucThanhToan";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maPhuongThucThanhToan = (int)cm.Parameters["@MaPhuongThucThanhToan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maQuanLyPTTT.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLyPTTT", _maQuanLyPTTT);
			else
				cm.Parameters.AddWithValue("@MaQuanLyPTTT", DBNull.Value);
			if (_tenPhuongThucThanhToan.Length > 0)
				cm.Parameters.AddWithValue("@TenPhuongThucThanhToan", _tenPhuongThucThanhToan);
			else
				cm.Parameters.AddWithValue("@TenPhuongThucThanhToan", DBNull.Value);
			cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", _maPhuongThucThanhToan);
			cm.Parameters["@MaPhuongThucThanhToan"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblPhuongThucThanhToan";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", _maPhuongThucThanhToan);
			if (_maQuanLyPTTT.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLyPTTT", _maQuanLyPTTT);
			else
				cm.Parameters.AddWithValue("@MaQuanLyPTTT", DBNull.Value);
			if (_tenPhuongThucThanhToan.Length > 0)
				cm.Parameters.AddWithValue("@TenPhuongThucThanhToan", _tenPhuongThucThanhToan);
			else
				cm.Parameters.AddWithValue("@TenPhuongThucThanhToan", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maPhuongThucThanhToan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
