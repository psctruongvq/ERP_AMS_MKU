
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DoiTuong : Csla.BusinessBase<DoiTuong>
	{
		#region Business Properties and Methods

		//declare members
		private long _maDoiTuong = 0;
		private bool _loai = false;
		private string _ten = string.Empty;
		private string _maQuanLy = string.Empty;

		//declare child member(s)
		private DoiTac _doiTac = DoiTac.NewDoiTac();

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaDoiTuong
		{
			get
			{
				CanReadProperty("MaDoiTuong", true);
				return _maDoiTuong;
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

		public DoiTac DoiTac
		{
			get
			{
				CanReadProperty("DoiTac", true);
				return _doiTac;
			}
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _doiTac.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _doiTac.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maDoiTuong;
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
			// Ten
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "Ten");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten", 500));
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
			//TODO: Define authorization rules in DoiTuong
			//AuthorizationRules.AllowRead("DoiTac", "DoiTuongReadGroup");
			//AuthorizationRules.AllowRead("MaDoiTuong", "DoiTuongReadGroup");
			//AuthorizationRules.AllowRead("Loai", "DoiTuongReadGroup");
			//AuthorizationRules.AllowRead("Ten", "DoiTuongReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "DoiTuongReadGroup");

			//AuthorizationRules.AllowWrite("Loai", "DoiTuongWriteGroup");
			//AuthorizationRules.AllowWrite("Ten", "DoiTuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanLy", "DoiTuongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DoiTuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTuongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DoiTuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTuongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DoiTuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTuongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DoiTuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTuongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DoiTuong()
		{ /* require use of factory method */ }

		public static DoiTuong NewDoiTuong(long maDoiTuong)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DoiTuong");
			return DataPortal.Create<DoiTuong>(new Criteria(maDoiTuong));
		}

		public static DoiTuong GetDoiTuong(long maDoiTuong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DoiTuong");
			return DataPortal.Fetch<DoiTuong>(new Criteria(maDoiTuong));
		}

        public static DoiTuong GetDoiTuongAll(long maDoiTuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuong");
            return DataPortal.Fetch<DoiTuong>(new CriteriaAll(maDoiTuong));
        }

		public static void DeleteDoiTuong(long maDoiTuong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DoiTuong");
			DataPortal.Delete(new Criteria(maDoiTuong));
		}

		public override DoiTuong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DoiTuong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DoiTuong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DoiTuong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private DoiTuong(long maDoiTuong)
		{
			this._maDoiTuong = maDoiTuong;
		}

		internal static DoiTuong NewDoiTuongChild(long maDoiTuong)
		{
			DoiTuong child = new DoiTuong(maDoiTuong);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DoiTuong GetDoiTuong(SafeDataReader dr)
		{
			DoiTuong child =  new DoiTuong();
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
			public long MaDoiTuong;

			public Criteria(long maDoiTuong)
			{
				this.MaDoiTuong = maDoiTuong;
			}
		}

        private class CriteriaAll
        {
            public long MaDoiTuong;

            public CriteriaAll(long maDoiTuong)
            {
                this.MaDoiTuong = maDoiTuong;
            }
        }

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maDoiTuong = criteria.MaDoiTuong;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblDoiTuong";
                    cm.Parameters.AddWithValue("@MaDoiTuong", ((Criteria)criteria).MaDoiTuong);
                }
                else if (criteria is CriteriaAll)
                {
                    cm.CommandText = "spd_SelecttblDoiTuongAllDT";
                    cm.Parameters.AddWithValue("@MaDoiTuong", ((CriteriaAll)criteria).MaDoiTuong);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(this._maDoiTuong);
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
			DataPortal_Delete(new Criteria(_maDoiTuong));
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
                cm.CommandText = "spd_DeletetblDoiTuong";

				cm.Parameters.AddWithValue("@MaDoiTuong", criteria.MaDoiTuong);

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
			FetchChildren(this._maDoiTuong);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maDoiTuong = dr.GetInt64("MaDoiTuong");
			_loai = dr.GetBoolean("Loai");
			_ten = dr.GetString("Ten");
			_maQuanLy = dr.GetString("MaQuanLy");
		}

		private void FetchChildren(long maDoiTuong)
		{
			//dr.NextResult();
			_doiTac = DoiTac.GetDoiTac(maDoiTuong);
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
                cm.CommandText = "spd_InserttblDoiTuong";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			cm.Parameters.AddWithValue("@Loai", _loai);
			cm.Parameters.AddWithValue("@Ten", _ten);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
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
                cm.CommandText = "spd_UpdatetblDoiTuong";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			cm.Parameters.AddWithValue("@Loai", _loai);
			cm.Parameters.AddWithValue("@Ten", _ten);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_doiTac.Update(tr);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(tr, new Criteria(_maDoiTuong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
