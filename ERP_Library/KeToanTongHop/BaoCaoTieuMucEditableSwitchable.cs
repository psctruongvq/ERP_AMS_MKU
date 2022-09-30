
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BaoCaoTieuMuc : Csla.BusinessBase<BaoCaoTieuMuc>
	{
		#region Business Properties and Methods

		//declare members
		private string _soChungTu = string.Empty;
		private SmartDate _ngayLap = new SmartDate(false);
		private string _dienGiai = string.Empty;
		private string _maTieuMuc = string.Empty;
		private decimal _soTien = 0;

        private decimal _soDuDauKy = 0;
        private decimal _luyKe = 0;

		public string SoChungTu
		{
			get
			{
				CanReadProperty("SoChungTu", true);
				return _soChungTu;
			}
			set
			{
				CanWriteProperty("SoChungTu", true);
				if (value == null) value = string.Empty;
				if (!_soChungTu.Equals(value))
				{
					_soChungTu = value;
					PropertyHasChanged("SoChungTu");
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
		}

		public string NgayLapString
		{
			get
			{
				CanReadProperty("NgayLapString", true);
				return _ngayLap.Text;
			}
			set
			{
				CanWriteProperty("NgayLapString", true);
				if (value == null) value = string.Empty;
				if (!_ngayLap.Equals(value))
				{
					_ngayLap.Text = value;
					PropertyHasChanged("NgayLapString");
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

		[System.ComponentModel.DataObjectField(true, false)]
		public string MaTieuMuc
		{
			get
			{
				CanReadProperty("MaTieuMuc", true);
				return _maTieuMuc;
			}
		}

		public decimal SoTien
		{
			get
			{
				CanReadProperty("SoTien", true);
				return _soTien;
			}
			set
			{
				CanWriteProperty("SoTien", true);
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
				}
			}
		}

        public decimal SoDuDauKy
        {
            get
            {
                CanReadProperty("SoDuDauKy", true);
                return _soDuDauKy;
            }
            set
            {
                CanWriteProperty("SoTien", true);
                if (!_soDuDauKy.Equals(SoDuDauKy))
                {
                    _soDuDauKy = value;
                    PropertyHasChanged("SoDuDauKy");
                }
            }
        }

        public decimal LuyKe
        {
            get
            {
                CanReadProperty("LuyKe", true);
                return _luyKe;
            }
            set
            {
                CanWriteProperty("_luyKe", true);
                if (!_soDuDauKy.Equals(SoDuDauKy))
                {
                    _soDuDauKy = value;
                    PropertyHasChanged("_luyKe");
                }
            }
        }
		protected override object GetIdValue()
		{
			return _maTieuMuc;
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
			// SoChungTu
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "SoChungTu");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 4000));
			//
			// MaTieuMuc
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaTieuMuc", 50));
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
			//TODO: Define authorization rules in BaoCaoTieuMuc
			//AuthorizationRules.AllowRead("SoChungTu", "BaoCaoTieuMucReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "BaoCaoTieuMucReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "BaoCaoTieuMucReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "BaoCaoTieuMucReadGroup");
			//AuthorizationRules.AllowRead("MaTieuMuc", "BaoCaoTieuMucReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "BaoCaoTieuMucReadGroup");

			//AuthorizationRules.AllowWrite("SoChungTu", "BaoCaoTieuMucWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "BaoCaoTieuMucWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "BaoCaoTieuMucWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "BaoCaoTieuMucWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BaoCaoTieuMuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoTieuMucViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BaoCaoTieuMuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoTieuMucAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BaoCaoTieuMuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoTieuMucEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BaoCaoTieuMuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoTieuMucDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BaoCaoTieuMuc()
		{ /* require use of factory method */ }

		public static BaoCaoTieuMuc NewBaoCaoTieuMuc(string maTieuMuc)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BaoCaoTieuMuc");
			return DataPortal.Create<BaoCaoTieuMuc>(new Criteria(maTieuMuc));
		}

		public static BaoCaoTieuMuc GetBaoCaoTieuMuc(string maTieuMuc)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BaoCaoTieuMuc");
			return DataPortal.Fetch<BaoCaoTieuMuc>(new Criteria(maTieuMuc));
		}

		public static void DeleteBaoCaoTieuMuc(string maTieuMuc)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BaoCaoTieuMuc");
			DataPortal.Delete(new Criteria(maTieuMuc));
		}

		public override BaoCaoTieuMuc Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BaoCaoTieuMuc");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BaoCaoTieuMuc");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BaoCaoTieuMuc");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private BaoCaoTieuMuc(string maTieuMuc)
		{
			this._maTieuMuc = maTieuMuc;
		}

		internal static BaoCaoTieuMuc NewBaoCaoTieuMucChild(string maTieuMuc)
		{
			BaoCaoTieuMuc child = new BaoCaoTieuMuc(maTieuMuc);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BaoCaoTieuMuc GetBaoCaoTieuMuc(SafeDataReader dr)
		{
			BaoCaoTieuMuc child =  new BaoCaoTieuMuc();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}

        internal static BaoCaoTieuMuc GetBaoCaoTieuMucSoTien(SafeDataReader dr)
        {
            BaoCaoTieuMuc child = new BaoCaoTieuMuc();
            child.MarkAsChild();           
            child._soTien = dr.GetDecimal("SoTien");
            return child;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public string MaTieuMuc;

			public Criteria(string maTieuMuc)
			{
				this.MaTieuMuc = maTieuMuc;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maTieuMuc = criteria.MaTieuMuc;
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
				cm.CommandText = "GetBaoCaoTieuMuc";

				cm.Parameters.AddWithValue("@MaTieuMuc", criteria.MaTieuMuc);

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
			DataPortal_Delete(new Criteria(_maTieuMuc));
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
				cm.CommandText = "DeleteBaoCaoTieuMuc";

				cm.Parameters.AddWithValue("@MaTieuMuc", criteria.MaTieuMuc);

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
			_soChungTu = dr.GetString("SoChungTu");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_dienGiai = dr.GetString("DienGiai");
			_maTieuMuc = dr.GetString("MaTieuMuc");
			_soTien = dr.GetDecimal("SoTien");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, BaoCaoTieuMucList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, BaoCaoTieuMucList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddBaoCaoTieuMuc";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BaoCaoTieuMucList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maTieuMuc.Length > 0)
				cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
			else
				cm.Parameters.AddWithValue("@MaTieuMuc", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, BaoCaoTieuMucList parent)
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

		private void ExecuteUpdate(SqlConnection cn, BaoCaoTieuMucList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdateBaoCaoTieuMuc";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BaoCaoTieuMucList parent)
		{
			cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maTieuMuc.Length > 0)
				cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
			else
				cm.Parameters.AddWithValue("@MaTieuMuc", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maTieuMuc));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
