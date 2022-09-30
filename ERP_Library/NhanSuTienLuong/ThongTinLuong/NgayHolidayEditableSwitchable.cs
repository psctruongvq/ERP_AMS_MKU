using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NgayHoliday : Csla.BusinessBase<NgayHoliday>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNgayHoliday = 0;
		private SmartDate _ngay = new SmartDate(DateTime.Today);
		private string _tenNgayHoliday = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNgayHoliday
		{
			get
			{
				CanReadProperty("MaNgayHoliday", true);
				return _maNgayHoliday;
			}
		}

		public DateTime Ngay
		{
			get
			{
				CanReadProperty("Ngay", true);
				return _ngay.Date;
			}
            set
            {
                CanWriteProperty("Ngay", true);
                if (!_ngay.Equals(value))
                {
                    _ngay = new SmartDate(value);
                    PropertyHasChanged("Ngay");
                }
            }
		}

		public string TenNgayHoliday
		{
			get
			{
				CanReadProperty("TenNgayHoliday", true);
				return _tenNgayHoliday;
			}
			set
			{
				CanWriteProperty("TenNgayHoliday", true);
				if (value == null) value = string.Empty;
				if (!_tenNgayHoliday.Equals(value))
				{
					_tenNgayHoliday = value;
					PropertyHasChanged("TenNgayHoliday");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maNgayHoliday;
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
			// Ngay
			//
			//ValidationRules.AddRule(CommonRules.StringRequired, "NgayString");
			//
			// TenNgayHoliday
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNgayHoliday", 500));
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
			//TODO: Define authorization rules in NgayHoliday
			//AuthorizationRules.AllowRead("MaNgayHoliday", "NgayHolidayReadGroup");
			//AuthorizationRules.AllowRead("Ngay", "NgayHolidayReadGroup");
			//AuthorizationRules.AllowRead("NgayString", "NgayHolidayReadGroup");
			//AuthorizationRules.AllowRead("TenNgayHoliday", "NgayHolidayReadGroup");

			//AuthorizationRules.AllowWrite("NgayString", "NgayHolidayWriteGroup");
			//AuthorizationRules.AllowWrite("TenNgayHoliday", "NgayHolidayWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NgayHoliday
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgayHolidayViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NgayHoliday
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgayHolidayAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NgayHoliday
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgayHolidayEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NgayHoliday
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgayHolidayDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NgayHoliday()
		{ /* require use of factory method */ }

		public static NgayHoliday NewNgayHoliday()
		{
            NgayHoliday item = new NgayHoliday();
            item.MarkAsChild();
            return item;
		}

		public static NgayHoliday GetNgayHoliday(int maNgayHoliday)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NgayHoliday");
			return DataPortal.Fetch<NgayHoliday>(new Criteria(maNgayHoliday));
		}

		public static void DeleteNgayHoliday(int maNgayHoliday)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NgayHoliday");
			DataPortal.Delete(new Criteria(maNgayHoliday));
		}

		public override NgayHoliday Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NgayHoliday");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NgayHoliday");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a NgayHoliday");

			return base.Save();
		}

        public static bool LaNgayLe(DateTime ngay)
        {
            bool kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraLaNgayLe";
                    cm.Parameters.AddWithValue("@Ngay", ngay);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@kq", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return kq;
        }

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NgayHoliday NewNgayHolidayChild()
		{
			NgayHoliday child = new NgayHoliday();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NgayHoliday GetNgayHoliday(SafeDataReader dr)
		{
			NgayHoliday child =  new NgayHoliday();
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
			public int MaNgayHoliday;

			public Criteria(int maNgayHoliday)
			{
				this.MaNgayHoliday = maNgayHoliday;
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
                cm.CommandText = "spd_SelecttblnsNgayHoliday";

				cm.Parameters.AddWithValue("@MaNgayHoliday", criteria.MaNgayHoliday);

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

				ExecuteInsert(cn, null);

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
					ExecuteUpdate(cn, null);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maNgayHoliday));
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
                cm.CommandText = "spd_DeletetblnsNgayHoliday";

				cm.Parameters.AddWithValue("@MaNgayHoliday", criteria.MaNgayHoliday);

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
			_maNgayHoliday = dr.GetInt32("MaNgayHoliday");
			_ngay = dr.GetSmartDate("Ngay", _ngay.EmptyIsMin);
			_tenNgayHoliday = dr.GetString("TenNgayHoliday");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, NgayHolidayList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, NgayHolidayList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsNgayHoliday";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maNgayHoliday = (int)cm.Parameters["@MaNgayHoliday"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NgayHolidayList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
			if (_tenNgayHoliday.Length > 0)
				cm.Parameters.AddWithValue("@TenNgayHoliday", _tenNgayHoliday);
			else
				cm.Parameters.AddWithValue("@TenNgayHoliday", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNgayHoliday", _maNgayHoliday);
			cm.Parameters["@MaNgayHoliday"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, NgayHolidayList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn, NgayHolidayList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsNgayHoliday";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NgayHolidayList parent)
		{
			cm.Parameters.AddWithValue("@MaNgayHoliday", _maNgayHoliday);
			cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
			if (_tenNgayHoliday.Length > 0)
				cm.Parameters.AddWithValue("@TenNgayHoliday", _tenNgayHoliday);
			else
				cm.Parameters.AddWithValue("@TenNgayHoliday", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maNgayHoliday));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
