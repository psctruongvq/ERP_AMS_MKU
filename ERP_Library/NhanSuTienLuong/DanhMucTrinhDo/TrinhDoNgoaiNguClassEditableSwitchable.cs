
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TrinhDoNgoaiNguClass : Csla.BusinessBase<TrinhDoNgoaiNguClass>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTrinhDoNN = 0;
		private string _maQuanLy = string.Empty;
		private string _trinhDoNgoaiNgu = string.Empty;
		private string _tenVietTat = string.Empty;
		private string _dienGiai = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTrinhDoNN
		{
			get
			{
				CanReadProperty("MaTrinhDoNN", true);
				return _maTrinhDoNN;
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

		public string TrinhDoNgoaiNgu
		{
			get
			{
				CanReadProperty("TrinhDoNgoaiNgu", true);
				return _trinhDoNgoaiNgu;
			}
			set
			{
				CanWriteProperty("TrinhDoNgoaiNgu", true);
				if (value == null) value = string.Empty;
				if (!_trinhDoNgoaiNgu.Equals(value))
				{
					_trinhDoNgoaiNgu = value;
					PropertyHasChanged("TrinhDoNgoaiNgu");
				}
			}
		}

		public string TenVietTat
		{
			get
			{
				CanReadProperty("TenVietTat", true);
				return _tenVietTat;
			}
			set
			{
				CanWriteProperty("TenVietTat", true);
				if (value == null) value = string.Empty;
				if (!_tenVietTat.Equals(value))
				{
					_tenVietTat = value;
					PropertyHasChanged("TenVietTat");
				}
			}
		}

		public string DienGiai
		{
			get
			{
				CanReadProperty("DienGiai", true);
				return _dienGiai;
			}
			set
			{
				CanWriteProperty("DienGiai", true);
				if (value == null) value = string.Empty;
				if (!_dienGiai.Equals(value))
				{
					_dienGiai = value;
					PropertyHasChanged("DienGiai");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTrinhDoNN;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
			//
			// TrinhDoNgoaiNgu
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TrinhDoNgoaiNgu");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TrinhDoNgoaiNgu", 100));
			//
			// TenVietTat
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenVietTat", 50));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
			//TODO: Define authorization rules in TrinhDoNgoaiNguClass
			//AuthorizationRules.AllowRead("MaTrinhDoNN", "TrinhDoNgoaiNguClassReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "TrinhDoNgoaiNguClassReadGroup");
			//AuthorizationRules.AllowRead("TrinhDoNgoaiNgu", "TrinhDoNgoaiNguClassReadGroup");
			//AuthorizationRules.AllowRead("TenVietTat", "TrinhDoNgoaiNguClassReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "TrinhDoNgoaiNguClassReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "TrinhDoNgoaiNguClassWriteGroup");
			//AuthorizationRules.AllowWrite("TrinhDoNgoaiNgu", "TrinhDoNgoaiNguClassWriteGroup");
			//AuthorizationRules.AllowWrite("TenVietTat", "TrinhDoNgoaiNguClassWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "TrinhDoNgoaiNguClassWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TrinhDoNgoaiNguClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoNgoaiNguClassViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TrinhDoNgoaiNguClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoNgoaiNguClassAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TrinhDoNgoaiNguClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoNgoaiNguClassEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TrinhDoNgoaiNguClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoNgoaiNguClassDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TrinhDoNgoaiNguClass()
		{ /* require use of factory method */ }

		public static TrinhDoNgoaiNguClass NewTrinhDoNgoaiNguClass()
		{
            TrinhDoNgoaiNguClass item = new TrinhDoNgoaiNguClass();
            item.MarkAsChild();
            return item;
		}
        private TrinhDoNgoaiNguClass(int matrinhdoNN, string trinhdoNN)
        {
            this._maTrinhDoNN = matrinhdoNN;
            this._trinhDoNgoaiNgu = trinhdoNN;
        }

        public static TrinhDoNgoaiNguClass NewTrinhDoNgoaiNguClass(int matrinhdoNN, string trinhdoNN)
        {
            return new TrinhDoNgoaiNguClass(matrinhdoNN, trinhdoNN);
        }

		public static TrinhDoNgoaiNguClass GetTrinhDoNgoaiNguClass(int maTrinhDoNN)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TrinhDoNgoaiNguClass");
			return DataPortal.Fetch<TrinhDoNgoaiNguClass>(new Criteria(maTrinhDoNN));
		}

		public static void DeleteTrinhDoNgoaiNguClass(int maTrinhDoNN)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TrinhDoNgoaiNguClass");
			DataPortal.Delete(new Criteria(maTrinhDoNN));
		}

		public override TrinhDoNgoaiNguClass Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TrinhDoNgoaiNguClass");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TrinhDoNgoaiNguClass");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TrinhDoNgoaiNguClass");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TrinhDoNgoaiNguClass NewTrinhDoNgoaiNguClassChild()
		{
			TrinhDoNgoaiNguClass child = new TrinhDoNgoaiNguClass();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TrinhDoNgoaiNguClass GetTrinhDoNgoaiNguClass(SafeDataReader dr)
		{
			TrinhDoNgoaiNguClass child =  new TrinhDoNgoaiNguClass();
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
			public int MaTrinhDoNN;

			public Criteria(int maTrinhDoNN)
			{
				this.MaTrinhDoNN = maTrinhDoNN;
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
                cm.CommandText = "spd_SelecttblnsTrinhDoNgoaiNgu";

				cm.Parameters.AddWithValue("@MaTrinhDoNN", criteria.MaTrinhDoNN);

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
			DataPortal_Delete(new Criteria(_maTrinhDoNN));
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
                cm.CommandText = "spd_DeletetblnsTrinhDoNgoaiNgu";

				cm.Parameters.AddWithValue("@MaTrinhDoNN", criteria.MaTrinhDoNN);

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
			_maTrinhDoNN = dr.GetInt32("MaTrinhDoNN");
			_maQuanLy = dr.GetString("MaQuanLy");
			_trinhDoNgoaiNgu = dr.GetString("TrinhDoNgoaiNgu");
			_tenVietTat = dr.GetString("TenVietTat");
			_dienGiai = dr.GetString("DienGiai");
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
                cm.CommandText = "spd_InserttblnsTrinhDoNgoaiNgu";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maTrinhDoNN = (int)cm.Parameters["@MaTrinhDoNN"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			cm.Parameters.AddWithValue("@TrinhDoNgoaiNgu", _trinhDoNgoaiNgu);
			if (_tenVietTat.Length > 0)
				cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
			else
				cm.Parameters.AddWithValue("@TenVietTat", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTrinhDoNN", _maTrinhDoNN);
			cm.Parameters["@MaTrinhDoNN"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsTrinhDoNgoaiNgu";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaTrinhDoNN", _maTrinhDoNN);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			cm.Parameters.AddWithValue("@TrinhDoNgoaiNgu", _trinhDoNgoaiNgu);
			if (_tenVietTat.Length > 0)
				cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
			else
				cm.Parameters.AddWithValue("@TenVietTat", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maTrinhDoNN));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
