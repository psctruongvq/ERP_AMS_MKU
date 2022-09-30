
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TrinhDoTinHocClass : Csla.BusinessBase<TrinhDoTinHocClass>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTrinhDoTH = 0;
		private string _maQuanLy = string.Empty;
		private string _trinhDoTinHoc = string.Empty;
		private string _tenVietTat = string.Empty;
		private string _dienGiai = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTrinhDoTH
		{
			get
			{
				CanReadProperty("MaTrinhDoTH", true);
				return _maTrinhDoTH;
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

		public string TrinhDoTinHoc
		{
			get
			{
				CanReadProperty("TrinhDoTinHoc", true);
				return _trinhDoTinHoc;
			}
			set
			{
				CanWriteProperty("TrinhDoTinHoc", true);
				if (value == null) value = string.Empty;
				if (!_trinhDoTinHoc.Equals(value))
				{
					_trinhDoTinHoc = value;
					PropertyHasChanged("TrinhDoTinHoc");
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
			return _maTrinhDoTH;
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
			// TrinhDoTinHoc
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TrinhDoTinHoc", 100));
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
			//TODO: Define authorization rules in TrinhDoTinHocClass
			//AuthorizationRules.AllowRead("MaTrinhDoTH", "TrinhDoTinHocClassReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "TrinhDoTinHocClassReadGroup");
			//AuthorizationRules.AllowRead("TrinhDoTinHoc", "TrinhDoTinHocClassReadGroup");
			//AuthorizationRules.AllowRead("TenVietTat", "TrinhDoTinHocClassReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "TrinhDoTinHocClassReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "TrinhDoTinHocClassWriteGroup");
			//AuthorizationRules.AllowWrite("TrinhDoTinHoc", "TrinhDoTinHocClassWriteGroup");
			//AuthorizationRules.AllowWrite("TenVietTat", "TrinhDoTinHocClassWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "TrinhDoTinHocClassWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TrinhDoTinHocClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoTinHocClassViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TrinhDoTinHocClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoTinHocClassAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TrinhDoTinHocClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoTinHocClassEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TrinhDoTinHocClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoTinHocClassDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TrinhDoTinHocClass()
		{ /* require use of factory method */ }

		public static TrinhDoTinHocClass NewTrinhDoTinHocClass()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TrinhDoTinHocClass");
			return DataPortal.Create<TrinhDoTinHocClass>();
		}
        private TrinhDoTinHocClass(int matrinhdoTH,string trinhdoTH)
        {
            this._maTrinhDoTH= matrinhdoTH;
            this._trinhDoTinHoc = trinhdoTH;
        }

        public static TrinhDoTinHocClass NewTrinhDoTinHocClass(int matrinhdoTH, string trinhdoTH)
        {
            return new TrinhDoTinHocClass(matrinhdoTH, trinhdoTH);
        }

		public static TrinhDoTinHocClass GetTrinhDoTinHocClass(int maTrinhDoTH)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TrinhDoTinHocClass");
			return DataPortal.Fetch<TrinhDoTinHocClass>(new Criteria(maTrinhDoTH));
		}

		public static void DeleteTrinhDoTinHocClass(int maTrinhDoTH)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TrinhDoTinHocClass");
			DataPortal.Delete(new Criteria(maTrinhDoTH));
		}

		public override TrinhDoTinHocClass Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TrinhDoTinHocClass");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TrinhDoTinHocClass");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TrinhDoTinHocClass");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TrinhDoTinHocClass NewTrinhDoTinHocClassChild()
		{
			TrinhDoTinHocClass child = new TrinhDoTinHocClass();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TrinhDoTinHocClass GetTrinhDoTinHocClass(SafeDataReader dr)
		{
			TrinhDoTinHocClass child =  new TrinhDoTinHocClass();
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
			public int MaTrinhDoTH;

			public Criteria(int maTrinhDoTH)
			{
				this.MaTrinhDoTH = maTrinhDoTH;
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
                cm.CommandText = "spd_SelecttblnsTrinhDoTinHoc";

				cm.Parameters.AddWithValue("@MaTrinhDoTH", criteria.MaTrinhDoTH);

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
			DataPortal_Delete(new Criteria(_maTrinhDoTH));
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
                cm.CommandText = "spd_DeletetblnsTrinhDoTinHoc";

				cm.Parameters.AddWithValue("@MaTrinhDoTH", criteria.MaTrinhDoTH);

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
			_maTrinhDoTH = dr.GetInt32("MaTrinhDoTH");
			_maQuanLy = dr.GetString("MaQuanLy");
			_trinhDoTinHoc = dr.GetString("TrinhDoTinHoc");
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
                cm.CommandText = "spd_InserttblnsTrinhDoTinHoc";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maTrinhDoTH = (int)cm.Parameters["@MaTrinhDoTH"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_trinhDoTinHoc.Length > 0)
				cm.Parameters.AddWithValue("@TrinhDoTinHoc", _trinhDoTinHoc);
			else
				cm.Parameters.AddWithValue("@TrinhDoTinHoc", DBNull.Value);
			if (_tenVietTat.Length > 0)
				cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
			else
				cm.Parameters.AddWithValue("@TenVietTat", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTrinhDoTH", _maTrinhDoTH);
			cm.Parameters["@MaTrinhDoTH"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsTrinhDoTinHoc";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaTrinhDoTH", _maTrinhDoTH);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_trinhDoTinHoc.Length > 0)
				cm.Parameters.AddWithValue("@TrinhDoTinHoc", _trinhDoTinHoc);
			else
				cm.Parameters.AddWithValue("@TrinhDoTinHoc", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maTrinhDoTH));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
