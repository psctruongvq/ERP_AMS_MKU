
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class To : Csla.BusinessBase<To>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTo = 0;
		private string _maQuanLy = string.Empty;
		private int _maPhanXuong = 0;
		private string _tenTo = string.Empty;
        private int _maPhongBan = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTo
		{
			get
			{
				CanReadProperty("MaTo", true);
				return _maTo;
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

		public int MaPhanXuong
		{
			get
			{
				CanReadProperty("MaPhanXuong", true);
                _maPhanXuong = BoPhan.GetBoPhan(_maPhongBan).MaCongTy;
				return _maPhanXuong;
			}
			set
			{
				CanWriteProperty("MaPhanXuong", true);
				if (!_maPhanXuong.Equals(value))
				{
					_maPhanXuong = value;
					PropertyHasChanged("MaPhanXuong");
				}
			}
		}

        public int MaPhongBan
        {
            get
            {
                CanReadProperty("MaPhongBan", true);
                return _maPhongBan;
            }
            set
            {
                CanWriteProperty("MaPhongBan", true);
                if (!_maPhongBan.Equals(value))
                {
                    _maPhongBan = value;
                    PropertyHasChanged("MaPhongBan");
                }
            }
        }

		public string TenTo
		{
			get
			{
				CanReadProperty("TenTo", true);
				return _tenTo;
			}
			set
			{
				CanWriteProperty("TenTo", true);
				if (value == null) value = string.Empty;
				if (!_tenTo.Equals(value))
				{
					_tenTo = value;
					PropertyHasChanged("TenTo");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTo;
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
			// TenTo
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenTo");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTo", 200));
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
			//TODO: Define authorization rules in To
			//AuthorizationRules.AllowRead("MaTo", "ToReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "ToReadGroup");
			//AuthorizationRules.AllowRead("MaPhanXuong", "ToReadGroup");
			//AuthorizationRules.AllowRead("TenTo", "ToReadGroup");
            //AuthorizationRules.AllowRead("MaPhongBan", "ToReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "ToWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhanXuong", "ToWriteGroup");
			//AuthorizationRules.AllowWrite("TenTo", "ToWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhongBan", "ToWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in To
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission child.ValidationRules.CheckRules();in To
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in To
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in To
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private To()
		{ /* require use of factory method */ }

        private To(int mato, string maquanly)
        {
            this._maTo = mato;
            this._tenTo = maquanly;
        }

		public static To NewTo()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a To");
			return DataPortal.Create<To>();
		}

        public static To NewTo(int maTo,string _maQuanLy)
        {
            return new To(maTo, _maQuanLy);
        }

		public static To GetTo(int maTo)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a To");
			return DataPortal.Fetch<To>(new Criteria(maTo));
		}

		public static void DeleteTo(int maTo)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a To");
			DataPortal.Delete(new Criteria(maTo));
		}

		public override To Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a To");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a To");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a To");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static To NewToChild()
		{
			To child = new To();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static To GetTo(SafeDataReader dr)
		{
			To child =  new To();
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
			public int MaTo;

			public Criteria(int maTo)
			{
				this.MaTo = maTo;
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
                cm.CommandText = "spd_SelecttblnsTo";

				cm.Parameters.AddWithValue("@MaTo", criteria.MaTo);

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
			DataPortal_Delete(new Criteria(_maTo));
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
                cm.CommandText = "spd_DeletetblnsTo";

				cm.Parameters.AddWithValue("@MaTo", criteria.MaTo);

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
			_maTo = dr.GetInt32("MaTo");
			_maQuanLy = dr.GetString("MaQuanLy");
			_maPhanXuong = dr.GetInt32("MaPhanXuong");
			_tenTo = dr.GetString("TenTo");
            _maPhongBan = dr.GetInt32("MaPhongBan");
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
                cm.CommandText = "spd_InserttblnsTo";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maTo = (int)cm.Parameters["@MaTo"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@MaPhanXuong", _maPhanXuong);
			cm.Parameters.AddWithValue("@TenTo", _tenTo);
			cm.Parameters.AddWithValue("@MaTo", _maTo);            
            cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);            
			cm.Parameters["@MaTo"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsTo";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaTo", _maTo);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@MaPhanXuong", _maPhanXuong);
			cm.Parameters.AddWithValue("@TenTo", _tenTo);
            cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);            
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

			ExecuteDelete(tr, new Criteria(_maTo));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
