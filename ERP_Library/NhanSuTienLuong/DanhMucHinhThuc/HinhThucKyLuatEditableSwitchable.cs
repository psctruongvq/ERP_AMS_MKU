
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HinhThucKyLuat : Csla.BusinessBase<HinhThucKyLuat>
	{
		#region Business Properties and Methods

		//declare members
		private int _maKyLuat = 0;
		private string _maQuanLy = string.Empty;
		private string _tenKyLyat = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaKyLuat
		{
			get
			{
				CanReadProperty("MaKyLuat", true);
				return _maKyLuat;
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

		public string TenKyLyat
		{
			get
			{
				CanReadProperty("TenKyLyat", true);
				return _tenKyLyat;
			}
			set
			{
				CanWriteProperty("TenKyLyat", true);
				if (value == null) value = string.Empty;
				if (!_tenKyLyat.Equals(value))
				{
					_tenKyLyat = value;
					PropertyHasChanged("TenKyLyat");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maKyLuat;
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
			// TenKyLyat
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenKyLyat");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenKyLyat", 500));
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
			//TODO: Define authorization rules in HinhThucKyLuat
			//AuthorizationRules.AllowRead("MaKyLuat", "HinhThucKyLuatReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "HinhThucKyLuatReadGroup");
			//AuthorizationRules.AllowRead("TenKyLyat", "HinhThucKyLuatReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "HinhThucKyLuatWriteGroup");
			//AuthorizationRules.AllowWrite("TenKyLyat", "HinhThucKyLuatWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HinhThucKyLuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucKyLuatViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HinhThucKyLuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucKyLuatAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HinhThucKyLuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucKyLuatEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HinhThucKyLuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucKyLuatDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HinhThucKyLuat()
		{ /* require use of factory method */ }

		public static HinhThucKyLuat NewHinhThucKyLuat()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HinhThucKyLuat");
			return DataPortal.Create<HinhThucKyLuat>();
		}
        public static HinhThucKyLuat NewHinhThucKyLuat(string s)
        {
            HinhThucKyLuat item = new HinhThucKyLuat();
            item.TenKyLyat = s;
            item.MarkAsChild();
            return item;
        }

		public static HinhThucKyLuat GetHinhThucKyLuat(int maKyLuat)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HinhThucKyLuat");
			return DataPortal.Fetch<HinhThucKyLuat>(new Criteria(maKyLuat));
		}

		public static void DeleteHinhThucKyLuat(int maKyLuat)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HinhThucKyLuat");
			DataPortal.Delete(new Criteria(maKyLuat));
		}

		public override HinhThucKyLuat Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HinhThucKyLuat");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HinhThucKyLuat");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HinhThucKyLuat");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HinhThucKyLuat NewHinhThucKyLuatChild()
		{
			HinhThucKyLuat child = new HinhThucKyLuat();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HinhThucKyLuat GetHinhThucKyLuat(SafeDataReader dr)
		{
			HinhThucKyLuat child =  new HinhThucKyLuat();
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
			public int MaKyLuat;

			public Criteria(int maKyLuat)
			{
				this.MaKyLuat = maKyLuat;
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
                cm.CommandText = "spd_SelecttblnsHinhThucKyLuat";

				cm.Parameters.AddWithValue("@MaKyLuat", criteria.MaKyLuat);

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
			DataPortal_Delete(new Criteria(_maKyLuat));
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
                cm.CommandText = "spd_DeletetblnsHinhThucKyLuat";

				cm.Parameters.AddWithValue("@MaKyLuat", criteria.MaKyLuat);

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
			_maKyLuat = dr.GetInt32("MaKyLuat");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenKyLyat = dr.GetString("TenKyLyat");
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
				//cm.CommandText = "AddHinhThucKyLuat";
               // spd_InserttblnsHinhThucKyLuat
                cm.CommandText = "spd_InserttblnsHinhThucKyLuat";
				AddInsertParameters(cm);
                
				cm.ExecuteNonQuery();

              //  _maKyLuat = (int)cm.Parameters["@MaKyLuat"].Value;
			}//using
          
           
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenKyLyat", _tenKyLyat);
			cm.Parameters.AddWithValue("@MaKyLuat", _maKyLuat);
			//cm.Parameters["@NewMaKyLuat"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsHinhThucKyLuat";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaKyLuat", _maKyLuat);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenKyLyat", _tenKyLyat);
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

			ExecuteDelete(cn, new Criteria(_maKyLuat));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
