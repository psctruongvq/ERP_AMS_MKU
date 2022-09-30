
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class UuTienBanThan : Csla.BusinessBase<UuTienBanThan>
	{
		#region Business Properties and Methods

		//declare members
		private int _maUuTienBanThan = 0;
		private string _maQuanLy = string.Empty;
		private string _uuTienBanThan = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaUuTienBanThan
		{
			get
			{
				CanReadProperty("MaUuTienBanThan", true);
				return _maUuTienBanThan;
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

        public string UuTienBT
		{
			get
			{
				CanReadProperty("UuTienBanThan", true);
				return _uuTienBanThan;
			}
			set
			{
				CanWriteProperty("UuTienBanThan", true);
				if (value == null) value = string.Empty;
				if (!_uuTienBanThan.Equals(value))
				{
					_uuTienBanThan = value;
					PropertyHasChanged("UuTienBanThan");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maUuTienBanThan;
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
        //    ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
        //    ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
        //    //
        //    // UuTienBanThan
        //    //
        //    ValidationRules.AddRule(CommonRules.StringRequired, "UuTienBanThan");
        //    ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("UuTienBanThan", 500));
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
			//TODO: Define authorization rules in UuTienBanThan
			//AuthorizationRules.AllowRead("MaUuTienBanThan", "UuTienBanThanReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "UuTienBanThanReadGroup");
			//AuthorizationRules.AllowRead("UuTienBanThan", "UuTienBanThanReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "UuTienBanThanWriteGroup");
			//AuthorizationRules.AllowWrite("UuTienBanThan", "UuTienBanThanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in UuTienBanThan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("UuTienBanThanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in UuTienBanThan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("UuTienBanThanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in UuTienBanThan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("UuTienBanThanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in UuTienBanThan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("UuTienBanThanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private UuTienBanThan()
		{ /* require use of factory method */ }

		public static UuTienBanThan NewUuTienBanThan()
		{
            UuTienBanThan item = new UuTienBanThan();
            item.MarkAsChild();
            return item;
		}
        private UuTienBanThan(int mauutienbanthan, string uutienbanthan)
        {
            this._maUuTienBanThan = mauutienbanthan;
            this._uuTienBanThan = uutienbanthan;
        }

        public static UuTienBanThan NewUuTienBanThan(int mauutienbanthan, string Uutienbanthan)
        {
            return new UuTienBanThan(mauutienbanthan, Uutienbanthan);
        }

		public static UuTienBanThan GetUuTienBanThan(int maUuTienBanThan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a UuTienBanThan");
			return DataPortal.Fetch<UuTienBanThan>(new Criteria(maUuTienBanThan));
		}

		public static void DeleteUuTienBanThan(int maUuTienBanThan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a UuTienBanThan");
			DataPortal.Delete(new Criteria(maUuTienBanThan));
		}

		public override UuTienBanThan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a UuTienBanThan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a UuTienBanThan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a UuTienBanThan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static UuTienBanThan NewUuTienBanThanChild()
		{
			UuTienBanThan child = new UuTienBanThan();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static UuTienBanThan GetUuTienBanThan(SafeDataReader dr)
		{
			UuTienBanThan child =  new UuTienBanThan();
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
			public int MaUuTienBanThan;

			public Criteria(int maUuTienBanThan)
			{
				this.MaUuTienBanThan = maUuTienBanThan;
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
                cm.CommandText = "spd_SelecttblnsUuTienBanThan";

				cm.Parameters.AddWithValue("@MaUuTienBanThan", criteria.MaUuTienBanThan);

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
			DataPortal_Delete(new Criteria(_maUuTienBanThan));
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
                cm.CommandText = "spd_DeletetblnsUuTienBanThan";

				cm.Parameters.AddWithValue("@MaUuTienBanThan", criteria.MaUuTienBanThan);

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
            _maUuTienBanThan = dr.GetInt32("MaUuTienBanThan");
            _maQuanLy = dr.GetString("MaQuanLy");
            _uuTienBanThan = dr.GetString("UuTienBanThan");
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
                cm.CommandText = "spd_InserttblnsUuTienBanThan";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maUuTienBanThan = (int)cm.Parameters["@MaUuTienBanThan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@UuTienBanThan", _uuTienBanThan);
			cm.Parameters.AddWithValue("@MaUuTienBanThan", _maUuTienBanThan);
			cm.Parameters["@MaUuTienBanThan"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsUuTienBanThan";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaUuTienBanThan", _maUuTienBanThan);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@UuTienBanThan", _uuTienBanThan);
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

			ExecuteDelete(cn, new Criteria(_maUuTienBanThan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
