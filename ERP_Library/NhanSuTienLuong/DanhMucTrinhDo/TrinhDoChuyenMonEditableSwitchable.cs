
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TrinhDoChuyenMon : Csla.BusinessBase<TrinhDoChuyenMon>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTrinhDoChuyenMon = 0;
		private string _maQuanLy = string.Empty;
		private string _tenTrinhDo = string.Empty;
		private string _tenVietTat = string.Empty;
		private string _dienGiai = string.Empty;
     
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTrinhDoChuyenMon
		{
			get
			{
				CanReadProperty("MaTrinhDoChuyenMon", true);
				return _maTrinhDoChuyenMon;
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

		public string TenTrinhDo
		{
			get
			{
				CanReadProperty("TenTrinhDo", true);
				return _tenTrinhDo;
			}
			set
			{
				CanWriteProperty("TenTrinhDo", true);
				if (value == null) value = string.Empty;
				if (!_tenTrinhDo.Equals(value))
				{
					_tenTrinhDo = value;
					PropertyHasChanged("TenTrinhDo");
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
			return _maTrinhDoChuyenMon;
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
			// TenTrinhDo
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTrinhDo", 500));
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
			//TODO: Define authorization rules in TrinhDoChuyenMon
			//AuthorizationRules.AllowRead("MaTrinhDoChuyenMon", "TrinhDoChuyenMonReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "TrinhDoChuyenMonReadGroup");
			//AuthorizationRules.AllowRead("TenTrinhDo", "TrinhDoChuyenMonReadGroup");
			//AuthorizationRules.AllowRead("TenVietTat", "TrinhDoChuyenMonReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "TrinhDoChuyenMonReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "TrinhDoChuyenMonWriteGroup");
			//AuthorizationRules.AllowWrite("TenTrinhDo", "TrinhDoChuyenMonWriteGroup");
			//AuthorizationRules.AllowWrite("TenVietTat", "TrinhDoChuyenMonWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "TrinhDoChuyenMonWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TrinhDoChuyenMon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoChuyenMonViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TrinhDoChuyenMon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoChuyenMonAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TrinhDoChuyenMon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoChuyenMonEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TrinhDoChuyenMon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoChuyenMonDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TrinhDoChuyenMon()
		{ /* require use of factory method */ }

		public static TrinhDoChuyenMon NewTrinhDoChuyenMon()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TrinhDoChuyenMon");
			return DataPortal.Create<TrinhDoChuyenMon>();
		}

        private TrinhDoChuyenMon(int matrinhdoCM, string TrinhdoCM)
        {
            this._maTrinhDoChuyenMon = matrinhdoCM;
            this._tenTrinhDo = TrinhdoCM;
        }

        public static TrinhDoChuyenMon NewTrinhDoChuyenMon(int matrinhdoCm, string TrinhdoCm)
        {
            return new TrinhDoChuyenMon(matrinhdoCm, TrinhdoCm);
        }
		public static TrinhDoChuyenMon GetTrinhDoChuyenMon(int maTrinhDoChuyenMon)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TrinhDoChuyenMon");
			return DataPortal.Fetch<TrinhDoChuyenMon>(new Criteria(maTrinhDoChuyenMon));
		}

		public static void DeleteTrinhDoChuyenMon(int maTrinhDoChuyenMon)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TrinhDoChuyenMon");
			DataPortal.Delete(new Criteria(maTrinhDoChuyenMon));
		}

		public override TrinhDoChuyenMon Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TrinhDoChuyenMon");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TrinhDoChuyenMon");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TrinhDoChuyenMon");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TrinhDoChuyenMon NewTrinhDoChuyenMonChild()
		{
			TrinhDoChuyenMon child = new TrinhDoChuyenMon();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TrinhDoChuyenMon GetTrinhDoChuyenMon(SafeDataReader dr)
		{
			TrinhDoChuyenMon child =  new TrinhDoChuyenMon();
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
			public int MaTrinhDoChuyenMon;

			public Criteria(int maTrinhDoChuyenMon)
			{
				this.MaTrinhDoChuyenMon = maTrinhDoChuyenMon;
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
                cm.CommandText = "spd_SelecttblnsTrinhDoChuyenMon";

				cm.Parameters.AddWithValue("@MaTrinhDoChuyenMon", criteria.MaTrinhDoChuyenMon);

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
			DataPortal_Delete(new Criteria(_maTrinhDoChuyenMon));
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
                cm.CommandText = "spd_DeletetblnsTrinhDoChuyenMon";

				cm.Parameters.AddWithValue("@MaTrinhDoChuyenMon", criteria.MaTrinhDoChuyenMon);

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
			_maTrinhDoChuyenMon = dr.GetInt32("MaTrinhDoChuyenMon");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenTrinhDo = dr.GetString("TenTrinhDo");
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
                cm.CommandText = "spd_InserttblnsTrinhDoChuyenMon";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maTrinhDoChuyenMon = (int)cm.Parameters["@MaTrinhDoChuyenMon"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenTrinhDo.Length > 0)
				cm.Parameters.AddWithValue("@TenTrinhDo", _tenTrinhDo);
			else
				cm.Parameters.AddWithValue("@TenTrinhDo", DBNull.Value);
			if (_tenVietTat.Length > 0)
				cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
			else
				cm.Parameters.AddWithValue("@TenVietTat", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTrinhDoChuyenMon", _maTrinhDoChuyenMon);
			cm.Parameters["@MaTrinhDoChuyenMon"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsTrinhDoChuyenMon";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaTrinhDoChuyenMon", _maTrinhDoChuyenMon);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenTrinhDo.Length > 0)
				cm.Parameters.AddWithValue("@TenTrinhDo", _tenTrinhDo);
			else
				cm.Parameters.AddWithValue("@TenTrinhDo", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maTrinhDoChuyenMon));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
