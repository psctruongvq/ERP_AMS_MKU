
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class MucDoHTCongViec : Csla.BusinessBase<MucDoHTCongViec>
	{
		#region Business Properties and Methods

		//declare members
		private int _maMucDo = 0;
		private string _maQuanLy = string.Empty;
		private string _tenMucDo = string.Empty;
		private string _ghiChu = string.Empty;
        //Mã Người Lập = mã nhân viên đăng nhập vào chương trình
		private long _maNguoiLap = 96;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaMucDo
		{
			get
			{
				CanReadProperty("MaMucDo", true);
				return _maMucDo;
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

		public string TenMucDo
		{
			get
			{
				CanReadProperty("TenMucDo", true);
				return _tenMucDo;
			}
			set
			{
				CanWriteProperty("TenMucDo", true);
				if (value == null) value = string.Empty;
				if (!_tenMucDo.Equals(value))
				{
					_tenMucDo = value;
					PropertyHasChanged("TenMucDo");
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

		public long MaNguoiLap
		{
			get
			{
				CanReadProperty("MaNguoiLap", true);
				return _maNguoiLap;
			}
			set
			{
				CanWriteProperty("MaNguoiLap", true);
				if (!_maNguoiLap.Equals(value))
				{
					_maNguoiLap = value;
					PropertyHasChanged("MaNguoiLap");
				}
			}
		}

		public DateTime NgayLap
		{
			get
			{
				CanReadProperty("NgayLap", true);
				return _ngayLap.Date;
			}
            set
            {
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap =new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
            }
		}

		protected override object GetIdValue()
		{
			return _maMucDo;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
			//
			// TenMucDo
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenMucDo");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenMucDo", 200));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 2000));
			
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
			//TODO: Define authorization rules in MucDoHTCongViec
			//AuthorizationRules.AllowRead("MaMucDo", "MucDoHTCongViecReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "MucDoHTCongViecReadGroup");
			//AuthorizationRules.AllowRead("TenMucDo", "MucDoHTCongViecReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "MucDoHTCongViecReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "MucDoHTCongViecReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "MucDoHTCongViecReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "MucDoHTCongViecReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "MucDoHTCongViecWriteGroup");
			//AuthorizationRules.AllowWrite("TenMucDo", "MucDoHTCongViecWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "MucDoHTCongViecWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "MucDoHTCongViecWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "MucDoHTCongViecWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in MucDoHTCongViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViecViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in MucDoHTCongViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViecAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in MucDoHTCongViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViecEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in MucDoHTCongViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViecDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private MucDoHTCongViec()
		{ /* require use of factory method */ }

		public static MucDoHTCongViec NewMucDoHTCongViec()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a MucDoHTCongViec");
			return DataPortal.Create<MucDoHTCongViec>();
		}
        public static MucDoHTCongViec NewMucDoHTCongViec(int Ma,string Ten)
        {
            return new MucDoHTCongViec(Ma, Ten);
        }
         private MucDoHTCongViec(int _ma, string _ten)
        {
            this._maMucDo= _ma;
            this._tenMucDo = _ten;
            MarkAsChild();
        }
		public static MucDoHTCongViec GetMucDoHTCongViec(int maMucDo)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a MucDoHTCongViec");
			return DataPortal.Fetch<MucDoHTCongViec>(new Criteria(maMucDo));
		}

		public static void DeleteMucDoHTCongViec(int maMucDo)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a MucDoHTCongViec");
			DataPortal.Delete(new Criteria(maMucDo));
		}

		public override MucDoHTCongViec Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a MucDoHTCongViec");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a MucDoHTCongViec");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a MucDoHTCongViec");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static MucDoHTCongViec NewMucDoHTCongViecChild()
		{
			MucDoHTCongViec child = new MucDoHTCongViec();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static MucDoHTCongViec GetMucDoHTCongViec(SafeDataReader dr)
		{
			MucDoHTCongViec child =  new MucDoHTCongViec();
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
			public int MaMucDo;

			public Criteria(int maMucDo)
			{
				this.MaMucDo = maMucDo;
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
                cm.CommandText = "spd_SelecttblnsMucDoHTCongViec";

				cm.Parameters.AddWithValue("@MaMucDo", criteria.MaMucDo);

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
			DataPortal_Delete(new Criteria(_maMucDo));
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
                cm.CommandText = "spd_DeletetblnsMucDoHTCongViec";

				cm.Parameters.AddWithValue("@MaMucDo", criteria.MaMucDo);

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
			_maMucDo = dr.GetInt32("MaMucDo");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenMucDo = dr.GetString("TenMucDo");
			_ghiChu = dr.GetString("GhiChu");
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, MucDoHTCongViecList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, MucDoHTCongViecList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsMucDoHTCongViec";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maMucDo = (int)cm.Parameters["@MaMucDo"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, MucDoHTCongViecList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenMucDo", _tenMucDo);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@MaMucDo", _maMucDo);
			cm.Parameters["@MaMucDo"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, MucDoHTCongViecList parent)
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

		private void ExecuteUpdate(SqlConnection cn, MucDoHTCongViecList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsMucDoHTCongViec";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, MucDoHTCongViecList parent)
		{
			cm.Parameters.AddWithValue("@MaMucDo", _maMucDo);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenMucDo", _tenMucDo);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
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

			ExecuteDelete(cn, new Criteria(_maMucDo));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
