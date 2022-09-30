
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ //4-1-2010

	[Serializable()] 
	public class ChungTu_DiaChi : Csla.BusinessBase<ChungTu_DiaChi>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChungTu = 0;
		private string _ten = string.Empty;
		private string _diaChi = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaChungTu
		{
			get
			{
				CanReadProperty("MaChungTu", true);
				return _maChungTu;
			}
            set
            {
                CanWriteProperty("MaChungTu", true);
                if (!_maChungTu.Equals(value))
                {
                    _maChungTu = value;
                    PropertyHasChanged("MaChungTu");
                }
            }
		}

		public string Ten
		{
			get
			{
				CanReadProperty("Ten", true);
				return _ten;
			}
			set
			{
				CanWriteProperty("Ten", true);
				if (value == null) value = string.Empty;
				if (!_ten.Equals(value))
				{
					_ten = value;
					PropertyHasChanged("Ten");
				}
			}
		}

		public string DiaChi
		{
			get
			{
				CanReadProperty("DiaChi", true);
				return _diaChi;
			}
			set
			{
				CanWriteProperty("DiaChi", true);
				if (value == null) value = string.Empty;
				if (!_diaChi.Equals(value))
				{
					_diaChi = value;
					PropertyHasChanged("DiaChi");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maChungTu;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{
            ////
            //// Ten
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten", 50));
            ////
            //// DiaChi
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChi", 100));
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
			//TODO: Define authorization rules in ChungTu_DiaChi
			//AuthorizationRules.AllowRead("MaChungTu", "ChungTu_DiaChiReadGroup");
			//AuthorizationRules.AllowRead("Ten", "ChungTu_DiaChiReadGroup");
			//AuthorizationRules.AllowRead("DiaChi", "ChungTu_DiaChiReadGroup");

			//AuthorizationRules.AllowWrite("Ten", "ChungTu_DiaChiWriteGroup");
			//AuthorizationRules.AllowWrite("DiaChi", "ChungTu_DiaChiWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChungTu_DiaChi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_DiaChiViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChungTu_DiaChi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_DiaChiAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChungTu_DiaChi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_DiaChiEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChungTu_DiaChi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_DiaChiDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChungTu_DiaChi()
		{ /* require use of factory method */ }

		public static ChungTu_DiaChi NewChungTu_DiaChi(long maChungTu)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChungTu_DiaChi");
			return DataPortal.Create<ChungTu_DiaChi>(new Criteria(maChungTu));
		}

		public static ChungTu_DiaChi GetChungTu_DiaChi(long maChungTu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChungTu_DiaChi");
			return DataPortal.Fetch<ChungTu_DiaChi>(new Criteria(maChungTu));
		}

		public static void DeleteChungTu_DiaChi(long maChungTu)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChungTu_DiaChi");
			DataPortal.Delete(new Criteria(maChungTu));
		}

		public override ChungTu_DiaChi Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChungTu_DiaChi");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChungTu_DiaChi");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChungTu_DiaChi");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private ChungTu_DiaChi(long maChungTu)
		{
			this._maChungTu = maChungTu;
		}

		internal static ChungTu_DiaChi NewChungTu_DiaChiChild(long maChungTu)
		{
			ChungTu_DiaChi child = new ChungTu_DiaChi(maChungTu);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChungTu_DiaChi GetChungTu_DiaChi(SafeDataReader dr)
		{
			ChungTu_DiaChi child =  new ChungTu_DiaChi();
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
			public long MaChungTu;

			public Criteria(long maChungTu)
			{
				this.MaChungTu = maChungTu;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maChungTu = criteria.MaChungTu;
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
				cm.CommandText = "SelecttblChungTu_DiaChibyMaChungTu";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
			DataPortal_Delete(new Criteria(_maChungTu));
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
                cm.CommandText = "sp_DeletetblChungTu_DiaChi";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
			_maChungTu = dr.GetInt64("MaChungTu");
			_ten = dr.GetString("Ten");
			_diaChi = dr.GetString("DiaChi");
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
                cm.CommandText = "sp_InserttblChungTu_DiaChi";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			if (_ten.Length > 0)
				cm.Parameters.AddWithValue("@Ten", _ten);
			else
				cm.Parameters.AddWithValue("@Ten", DBNull.Value);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
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
                cm.CommandText = "sp_UpdatetblChungTu_DiaChi";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			if (_ten.Length > 0)
				cm.Parameters.AddWithValue("@Ten", _ten);
			else
				cm.Parameters.AddWithValue("@Ten", DBNull.Value);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
            //if (!IsDirty) return;
            //if (IsNew) return;

			ExecuteDelete(tr, new Criteria(_maChungTu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
