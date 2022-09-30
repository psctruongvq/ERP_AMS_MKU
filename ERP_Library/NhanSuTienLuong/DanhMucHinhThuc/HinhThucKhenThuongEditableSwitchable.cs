
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HinhThucKhenThuong : Csla.BusinessBase<HinhThucKhenThuong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maKhenThuong = 0;
		private string _maQuanLy = string.Empty;
		private string _tenKhenThuong = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaKhenThuong
		{
			get
			{
				CanReadProperty("MaKhenThuong", true);
				return _maKhenThuong;
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

		public string TenKhenThuong
		{
			get
			{
				CanReadProperty("TenKhenThuong", true);
				return _tenKhenThuong;
			}
			set
			{
				CanWriteProperty("TenKhenThuong", true);
				if (value == null) value = string.Empty;
				if (!_tenKhenThuong.Equals(value))
				{
					_tenKhenThuong = value;
					PropertyHasChanged("TenKhenThuong");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maKhenThuong;
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
			// TenKhenThuong
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenKhenThuong");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenKhenThuong", 500));
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
			//TODO: Define authorization rules in HinhThucKhenThuong
			//AuthorizationRules.AllowRead("MaKhenThuong", "HinhThucKhenThuongReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "HinhThucKhenThuongReadGroup");
			//AuthorizationRules.AllowRead("TenKhenThuong", "HinhThucKhenThuongReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "HinhThucKhenThuongWriteGroup");
			//AuthorizationRules.AllowWrite("TenKhenThuong", "HinhThucKhenThuongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HinhThucKhenThuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucKhenThuongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HinhThucKhenThuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucKhenThuongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HinhThucKhenThuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucKhenThuongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HinhThucKhenThuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucKhenThuongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		public HinhThucKhenThuong()
		{ /* require use of factory method */ }

		public static HinhThucKhenThuong NewHinhThucKhenThuong(int maKhenThuong)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HinhThucKhenThuong");
			return DataPortal.Create<HinhThucKhenThuong>(new Criteria(maKhenThuong));
		}
        public static HinhThucKhenThuong NewHinhThucKhenThuong(string s)
        {
            HinhThucKhenThuong item = new HinhThucKhenThuong();
            item.TenKhenThuong = s;
            item.MarkAsChild();
            return item;
        }

		public static HinhThucKhenThuong GetHinhThucKhenThuong(int maKhenThuong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HinhThucKhenThuong");
			return DataPortal.Fetch<HinhThucKhenThuong>(new Criteria(maKhenThuong));
		}

		public static void DeleteHinhThucKhenThuong(int maKhenThuong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HinhThucKhenThuong");
			DataPortal.Delete(new Criteria(maKhenThuong));
		}

		public override HinhThucKhenThuong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HinhThucKhenThuong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HinhThucKhenThuong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HinhThucKhenThuong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private HinhThucKhenThuong(int maKhenThuong)
		{
			this._maKhenThuong = maKhenThuong;
		}

		internal static HinhThucKhenThuong NewHinhThucKhenThuongChild(int maKhenThuong)
		{
			HinhThucKhenThuong child = new HinhThucKhenThuong(maKhenThuong);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HinhThucKhenThuong GetHinhThucKhenThuong(SafeDataReader dr)
		{
			HinhThucKhenThuong child =  new HinhThucKhenThuong();
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
			public int MaKhenThuong;

			public Criteria(int maKhenThuong)
			{
				this.MaKhenThuong = maKhenThuong;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maKhenThuong = criteria.MaKhenThuong;
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
                cm.CommandText = "spd_SelecttblnsHinhThucKhenThuong";

				cm.Parameters.AddWithValue("@MaKhenThuong", criteria.MaKhenThuong);

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
			DataPortal_Delete(new Criteria(_maKhenThuong));
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
                cm.CommandText = "spd_DeletetblnsHinhThucKhenThuong";

				cm.Parameters.AddWithValue("@MaKhenThuong", criteria.MaKhenThuong);

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
			_maKhenThuong = dr.GetInt32("MaKhenThuong");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenKhenThuong = dr.GetString("TenKhenThuong");
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
                try
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblnsHinhThucKhenThuong";

                    AddInsertParameters(cm);

                    cm.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {

                }



			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaKhenThuong", _maKhenThuong);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenKhenThuong", _tenKhenThuong);
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
                cm.CommandText = "spd_UpdatetblnsHinhThucKhenThuong";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaKhenThuong", _maKhenThuong);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenKhenThuong", _tenKhenThuong);
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

			ExecuteDelete(cn, new Criteria(_maKhenThuong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
