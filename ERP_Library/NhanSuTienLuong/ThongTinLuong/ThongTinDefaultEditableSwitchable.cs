
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThongTinDefault : Csla.BusinessBase<ThongTinDefault>
	{
		#region Business Properties and Methods

		//declare members
		private int _ma = 0;
		private decimal _luongV1 = 0;
		private decimal _luongV2 = 0;
        private DateTime _tuNgay = DateTime.Today;
        private DateTime _denNgay = DateTime.Today;

		[System.ComponentModel.DataObjectField(true, false)]
		public int Ma
		{
			get
			{
				CanReadProperty("Ma", true);
				return _ma;
			}
		}

		public decimal LuongV1
		{
			get
			{
				CanReadProperty("LuongV1", true);
				return _luongV1;
			}
			set
			{
				CanWriteProperty("LuongV1", true);
				if (!_luongV1.Equals(value))
				{
					_luongV1 = value;
					PropertyHasChanged("LuongV1");
				}
			}
		}

		public decimal LuongV2
		{
			get
			{
				CanReadProperty("LuongV2", true);
				return _luongV2;
			}
			set
			{
				CanWriteProperty("LuongV2", true);
				if (!_luongV2.Equals(value))
				{
					_luongV2 = value;
					PropertyHasChanged("LuongV2");
				}
			}
		}

		public DateTime TuNgay
		{
			get
			{
				CanReadProperty("TuNgay", true);
				return _tuNgay.Date;
			}
            set
            {
                CanWriteProperty("TuNgay", true);
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay = value;
                    PropertyHasChanged("TuNgay");
                }
            }
		}

		public DateTime DenNgay
		{
			get
			{
				CanReadProperty("DenNgay", true);
				return _denNgay.Date;
			}
            set
            {
                CanWriteProperty("DenNgay", true);
                if (!_denNgay.Equals(value))
                {
                    _denNgay = value;
                    PropertyHasChanged("DenNgay");
                }
            }
		}

		protected override object GetIdValue()
		{
			return _ma;
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
			// TuNgay
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TuNgayString");
			//
			// DenNgay
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "DenNgayString");
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
			//TODO: Define authorization rules in ThongTinDefault
			//AuthorizationRules.AllowRead("Ma", "ThongTinDefaultReadGroup");
			//AuthorizationRules.AllowRead("LuongV1", "ThongTinDefaultReadGroup");
			//AuthorizationRules.AllowRead("LuongV2", "ThongTinDefaultReadGroup");
			//AuthorizationRules.AllowRead("TuNgay", "ThongTinDefaultReadGroup");
			//AuthorizationRules.AllowRead("TuNgayString", "ThongTinDefaultReadGroup");
			//AuthorizationRules.AllowRead("DenNgay", "ThongTinDefaultReadGroup");
			//AuthorizationRules.AllowRead("DenNgayString", "ThongTinDefaultReadGroup");

			//AuthorizationRules.AllowWrite("LuongV1", "ThongTinDefaultWriteGroup");
			//AuthorizationRules.AllowWrite("LuongV2", "ThongTinDefaultWriteGroup");
			//AuthorizationRules.AllowWrite("TuNgayString", "ThongTinDefaultWriteGroup");
			//AuthorizationRules.AllowWrite("DenNgayString", "ThongTinDefaultWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThongTinDefault
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinDefaultViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThongTinDefault
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinDefaultAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThongTinDefault
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinDefaultEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThongTinDefault
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinDefaultDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThongTinDefault()
		{ /* require use of factory method */ }

		public static ThongTinDefault NewThongTinDefault()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThongTinDefault");
			return DataPortal.Create<ThongTinDefault>(new CriteriaNew());
		}

		public static ThongTinDefault GetThongTinDefault(int ma)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThongTinDefault");
			return DataPortal.Fetch<ThongTinDefault>(new Criteria(ma));
		}

		public static void DeleteThongTinDefault(int ma)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThongTinDefault");
			DataPortal.Delete(new Criteria(ma));
		}

		public override ThongTinDefault Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThongTinDefault");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThongTinDefault");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ThongTinDefault");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private ThongTinDefault(int ma)
		{
			this._ma = ma;
		}

		internal static ThongTinDefault NewThongTinDefaultChild(int ma)
		{
			ThongTinDefault child = new ThongTinDefault(ma);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ThongTinDefault GetThongTinDefault(SafeDataReader dr)
		{
			ThongTinDefault child =  new ThongTinDefault();
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
			public int Ma;

			public Criteria(int ma)
			{
				this.Ma = ma;
			}
		}
        private class CriteriaNew
		{
			//public int Ma;

			public CriteriaNew()
			{
				//this.Ma = ma;
			}
		}
		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_ma = criteria.Ma;
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
				cm.CommandText = "spd_SelecttblnsThongTinDefault";

				cm.Parameters.AddWithValue("@Ma", criteria.Ma);

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
			DataPortal_Delete(new Criteria(_ma));
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
				cm.CommandText = "spd_DeletetblnsThongTinDefault";

				cm.Parameters.AddWithValue("@Ma", criteria.Ma);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			//ValidationRules.CheckRules();

			//load child object(s)
			//FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_ma = dr.GetInt32("Ma");
			_luongV1 = dr.GetDecimal("LuongV1");
			_luongV2 = dr.GetDecimal("LuongV2");
			_tuNgay = dr.GetDateTime("TuNgay");
			_denNgay = dr.GetDateTime("DenNgay");
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
				cm.CommandText = "spd_InserttblnsThongTinDefault";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@Ma", _ma);
			cm.Parameters.AddWithValue("@LuongV1", _luongV1);
			cm.Parameters.AddWithValue("@LuongV2", _luongV2);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay);
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
				cm.CommandText = "spd_UpdatetblnsThongTinDefault";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@Ma", _ma);
			cm.Parameters.AddWithValue("@LuongV1", _luongV1);
			cm.Parameters.AddWithValue("@LuongV2", _luongV2);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay);
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

			ExecuteDelete(cn, new Criteria(_ma));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
