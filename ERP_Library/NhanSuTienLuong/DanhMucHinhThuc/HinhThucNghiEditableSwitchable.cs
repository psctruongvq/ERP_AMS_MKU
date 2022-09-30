
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HinhThucNghi : Csla.BusinessBase<HinhThucNghi>
	{
		#region Business Properties and Methods

		//declare members
		private int _maHinhThucNghi = 0;
		private string _maQuanLy = string.Empty;
		private string _tenHinhThucNghi = string.Empty;
		private bool _truLuong = false;
		private string _ghiChu = string.Empty;
        private double _PhantramLuong = 0;
        private bool _bhxh = false;
        private bool _khongLuongDot1 = false;
        private bool _khongLuongDot2 = false;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaHinhThucNghi
		{
			get
			{
				CanReadProperty("MaHinhThucNghi", true);
				return _maHinhThucNghi;
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

		public string TenHinhThucNghi
		{
			get
			{
				CanReadProperty("TenHinhThucNghi", true);
				return _tenHinhThucNghi;
			}
			set
			{
				CanWriteProperty("TenHinhThucNghi", true);
				if (value == null) value = string.Empty;
				if (!_tenHinhThucNghi.Equals(value))
				{
					_tenHinhThucNghi = value;
					PropertyHasChanged("TenHinhThucNghi");
				}
			}
		}

		public bool TruLuong
		{
			get
			{
				CanReadProperty("TruLuong", true);
				return _truLuong;
			}
			set
			{
				CanWriteProperty("TruLuong", true);
				if (!_truLuong.Equals(value))
				{
					_truLuong = value;
					PropertyHasChanged("TruLuong");
				}
			}
		}

		public string GhiChu
		{
			get
			{
				CanReadProperty("GhiChu", true);
				return _ghiChu;
			}
			set
			{
				CanWriteProperty("GhiChu", true);
				if (value == null) value = string.Empty;
				if (!_ghiChu.Equals(value))
				{
					_ghiChu = value;
					PropertyHasChanged("GhiChu");
				}
			}
		}

        public double PhantramLuong
		{
			get
			{
				CanReadProperty("PhantramLuong", true);
				return _PhantramLuong;
			}
			set
			{
                CanWriteProperty("PhantramLuong", true);
				if (!_PhantramLuong.Equals(value))
				{
					_PhantramLuong = value;
                    PropertyHasChanged("PhantramLuong");
				}
			}
		}

        public bool BHXH
        {
            get
            {
                CanReadProperty("BHXH", true);
                return _bhxh;
            }
            set
            {
                CanWriteProperty("BHXH", true);
                if (!_bhxh.Equals(value))
                {
                    _bhxh = value;
                    PropertyHasChanged("BHXH");
                }
            }
        }

        public bool KhongLuongDot1
        {
            get
            {
                return _khongLuongDot1;
            }
            set
            {
                if (!_khongLuongDot1.Equals(value))
                {
                    _khongLuongDot1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool KhongLuongDot2
        {
            get
            {
                return _khongLuongDot2;
            }
            set
            {
                if (!_khongLuongDot2.Equals(value))
                {
                    _khongLuongDot2 = value;
                    PropertyHasChanged();
                }
            }
        }

		protected override object GetIdValue()
		{
			return _maHinhThucNghi;
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
			// TenHinhThucNghi
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenHinhThucNghi");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHinhThucNghi", 100));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
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
			//TODO: Define authorization rules in HinhThucNghi
			//AuthorizationRules.AllowRead("MaHinhThucNghi", "HinhThucNghiReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "HinhThucNghiReadGroup");
			//AuthorizationRules.AllowRead("TenHinhThucNghi", "HinhThucNghiReadGroup");
			//AuthorizationRules.AllowRead("TruLuong", "HinhThucNghiReadGroup");
			//AuthorizationRules.AllowRead("PhanTramV1", "HinhThucNghiReadGroup");
			//AuthorizationRules.AllowRead("PhanTramV2", "HinhThucNghiReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "HinhThucNghiReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "HinhThucNghiWriteGroup");
			//AuthorizationRules.AllowWrite("TenHinhThucNghi", "HinhThucNghiWriteGroup");
			//AuthorizationRules.AllowWrite("TruLuong", "HinhThucNghiWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramV1", "HinhThucNghiWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramV2", "HinhThucNghiWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "HinhThucNghiWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HinhThucNghi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucNghiViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HinhThucNghi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucNghiAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HinhThucNghi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucNghiEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HinhThucNghi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucNghiDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HinhThucNghi()
		{ /* require use of factory method */ }

		public static HinhThucNghi NewHinhThucNghi()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HinhThucNghi");
			return DataPortal.Create<HinhThucNghi>();
		}

		public static HinhThucNghi GetHinhThucNghi(int maHinhThucNghi)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HinhThucNghi");
			return DataPortal.Fetch<HinhThucNghi>(new Criteria(maHinhThucNghi));
		}

		public static void DeleteHinhThucNghi(int maHinhThucNghi)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HinhThucNghi");
			DataPortal.Delete(new Criteria(maHinhThucNghi));
		}

		public override HinhThucNghi Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HinhThucNghi");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HinhThucNghi");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HinhThucNghi");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HinhThucNghi NewHinhThucNghiChild()
		{
			HinhThucNghi child = new HinhThucNghi();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HinhThucNghi GetHinhThucNghi(SafeDataReader dr)
		{
			HinhThucNghi child =  new HinhThucNghi();
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
			public int MaHinhThucNghi;

			public Criteria(int maHinhThucNghi)
			{
				this.MaHinhThucNghi = maHinhThucNghi;
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
                cm.CommandText = "spd_SelecttblnsHinhThucNghi";

				cm.Parameters.AddWithValue("@MaHinhThucNghi", criteria.MaHinhThucNghi);

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
			DataPortal_Delete(new Criteria(_maHinhThucNghi));
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
                cm.CommandText = "spd_DeletetblnsHinhThucNghi";

				cm.Parameters.AddWithValue("@MaHinhThucNghi", criteria.MaHinhThucNghi);

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
            _maHinhThucNghi = dr.GetInt32("MaHinhThucNghi");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenHinhThucNghi = dr.GetString("TenHinhThucNghi");
            _truLuong = dr.GetBoolean("TruLuong");
            _PhantramLuong = dr.GetDouble("PhantramLuong");
            _ghiChu = dr.GetString("GhiChu");
            _bhxh = dr.GetBoolean("BHXH");
            _khongLuongDot1 = dr.GetBoolean("KhongLuongDot1");
            _khongLuongDot2 = dr.GetBoolean("KhongLuongDot2");
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
                cm.CommandText = "spd_InserttblnsHinhThucNghi";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maHinhThucNghi = (int)cm.Parameters["@MaHinhThucNghi"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenHinhThucNghi", _tenHinhThucNghi);
			cm.Parameters.AddWithValue("@TruLuong", _truLuong);
			cm.Parameters.AddWithValue("@PhantramLuong", _PhantramLuong);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@BHXH", _bhxh);
			cm.Parameters.AddWithValue("@MaHinhThucNghi", _maHinhThucNghi);
			cm.Parameters["@MaHinhThucNghi"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@KhongLuongDot1", _khongLuongDot1);
            cm.Parameters.AddWithValue("@KhongLuongDot2", _khongLuongDot2);
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
                cm.CommandText = "spd_UpdatetblnsHinhThucNghi";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHinhThucNghi", _maHinhThucNghi);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenHinhThucNghi", _tenHinhThucNghi);
			cm.Parameters.AddWithValue("@TruLuong", _truLuong);
			cm.Parameters.AddWithValue("@PhantramLuong", _PhantramLuong);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@BHXH", _bhxh);
            cm.Parameters.AddWithValue("@KhongLuongDot1", _khongLuongDot1);
            cm.Parameters.AddWithValue("@KhongLuongDot2", _khongLuongDot2);
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

			ExecuteDelete(cn, new Criteria(_maHinhThucNghi));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
