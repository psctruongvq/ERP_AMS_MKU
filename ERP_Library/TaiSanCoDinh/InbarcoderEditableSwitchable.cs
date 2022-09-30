
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class InBarcoder : Csla.BusinessBase<InBarcoder>
	{
		#region Business Properties and Methods

		//declare members
		private int _maBarCoder = 0;
		private int _maTaiSan = 0;
		private string _soHieuTaiSan = string.Empty;
		private string _tenTaiSan = string.Empty;
		private string _moduler = string.Empty;
		private string _serial = string.Empty;
		private bool _loai = false;
		private SmartDate _ngayLap = new SmartDate(false);

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaBarCoder
		{
			get
			{
				CanReadProperty("MaBarCoder", true);
				return _maBarCoder;
			}
		}

		public int MaTaiSan
		{
			get
			{
				CanReadProperty("MaTaiSan", true);
				return _maTaiSan;
			}
			set
			{
				CanWriteProperty("MaTaiSan", true);
				if (!_maTaiSan.Equals(value))
				{
					_maTaiSan = value;
					PropertyHasChanged("MaTaiSan");
				}
			}
		}

		public string SoHieuTaiSan
		{
			get
			{
				CanReadProperty("SoHieuTaiSan", true);
				return _soHieuTaiSan;
			}
			set
			{
				CanWriteProperty("SoHieuTaiSan", true);
				if (value == null) value = string.Empty;
				if (!_soHieuTaiSan.Equals(value))
				{
					_soHieuTaiSan = value;
					PropertyHasChanged("SoHieuTaiSan");
				}
			}
		}

		public string TenTaiSan
		{
			get
			{
				CanReadProperty("TenTaiSan", true);
				return _tenTaiSan;
			}
			set
			{
				CanWriteProperty("TenTaiSan", true);
				if (value == null) value = string.Empty;
				if (!_tenTaiSan.Equals(value))
				{
					_tenTaiSan = value;
					PropertyHasChanged("TenTaiSan");
				}
			}
		}

		public string Moduler
		{
			get
			{
				CanReadProperty("Moduler", true);
				return _moduler;
			}
			set
			{
				CanWriteProperty("Moduler", true);
				if (value == null) value = string.Empty;
				if (!_moduler.Equals(value))
				{
					_moduler = value;
					PropertyHasChanged("Moduler");
				}
			}
		}

		public string Serial
		{
			get
			{
				CanReadProperty("Serial", true);
				return _serial;
			}
			set
			{
				CanWriteProperty("Serial", true);
				if (value == null) value = string.Empty;
				if (!_serial.Equals(value))
				{
					_serial = value;
					PropertyHasChanged("Serial");
				}
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
                    _ngayLap = new SmartDate(DateTime.Today);
                    PropertyHasChanged("NgayLap");
                }
            }
		}

		
		protected override object GetIdValue()
		{
			return _maBarCoder;
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
			// SoHieuTaiSan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHieuTaiSan", 50));
			//
			// TenTaiSan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTaiSan", 250));
			//
			// Moduler
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Moduler", 50));
			//
			// Serial
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Serial", 50));
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
			//TODO: Define authorization rules in InBarcoder
			//AuthorizationRules.AllowRead("MaBarCoder", "InBarcoderReadGroup");
			//AuthorizationRules.AllowRead("MaTaiSan", "InBarcoderReadGroup");
			//AuthorizationRules.AllowRead("SoHieuTaiSan", "InBarcoderReadGroup");
			//AuthorizationRules.AllowRead("TenTaiSan", "InBarcoderReadGroup");
			//AuthorizationRules.AllowRead("Moduler", "InBarcoderReadGroup");
			//AuthorizationRules.AllowRead("Serial", "InBarcoderReadGroup");
			//AuthorizationRules.AllowRead("Loai", "InBarcoderReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "InBarcoderReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "InBarcoderReadGroup");

			//AuthorizationRules.AllowWrite("MaTaiSan", "InBarcoderWriteGroup");
			//AuthorizationRules.AllowWrite("SoHieuTaiSan", "InBarcoderWriteGroup");
			//AuthorizationRules.AllowWrite("TenTaiSan", "InBarcoderWriteGroup");
			//AuthorizationRules.AllowWrite("Moduler", "InBarcoderWriteGroup");
			//AuthorizationRules.AllowWrite("Serial", "InBarcoderWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "InBarcoderWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "InBarcoderWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in InBarcoder
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("InBarcoderViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in InBarcoder
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("InBarcoderAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in InBarcoder
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("InBarcoderEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in InBarcoder
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("InBarcoderDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private InBarcoder()
		{ /* require use of factory method */ }

		public static InBarcoder NewInBarcoder(int maBarCoder)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a InBarcoder");
			return DataPortal.Create<InBarcoder>(new Criteria(maBarCoder));
		}

		public static InBarcoder GetInBarcoder(int maBarCoder)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a InBarcoder");
			return DataPortal.Fetch<InBarcoder>(new Criteria(maBarCoder));
		}

		public static void DeleteInBarcoder(int maBarCoder)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a InBarcoder");
			DataPortal.Delete(new Criteria(maBarCoder));
		}

		public override InBarcoder Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a InBarcoder");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a InBarcoder");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a InBarcoder");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private InBarcoder(int maBarCoder)
		{
			this._maBarCoder = maBarCoder;
		}

		internal static InBarcoder NewInBarcoderChild(int maBarCoder)
		{
			InBarcoder child = new InBarcoder(maBarCoder);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static InBarcoder GetInBarcoder(SafeDataReader dr)
		{
			InBarcoder child =  new InBarcoder();
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
			public int MaBarCoder;

			public Criteria(int maBarCoder)
			{
				this.MaBarCoder = maBarCoder;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maBarCoder = criteria.MaBarCoder;
            this.MarkAsChild();
			//ValidationRules.CheckRules();
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
				cm.CommandText = "GetInBarcoder";

				cm.Parameters.AddWithValue("@MaBarCoder", criteria.MaBarCoder);

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
			DataPortal_Delete(new Criteria(_maBarCoder));
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
                cm.CommandText = "[spd_DeletetblInBarcoder]";

				cm.Parameters.AddWithValue("@MaBarCoder", criteria.MaBarCoder);

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
			_maBarCoder = dr.GetInt32("MaBarCoder");
			_maTaiSan = dr.GetInt32("MaTaiSan");
			_soHieuTaiSan = dr.GetString("SoHieuTaiSan");
			_tenTaiSan = dr.GetString("TenTaiSan");
			_moduler = dr.GetString("Moduler");
			_serial = dr.GetString("Serial");
			_loai = dr.GetBoolean("Loai");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, InBarcoderList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, InBarcoderList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_InserttblInBarcoder]";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, InBarcoderList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaBarCoder", _maBarCoder);
			if (_maTaiSan != 0)
				cm.Parameters.AddWithValue("@MaTaiSan", _maTaiSan);
			else
				cm.Parameters.AddWithValue("@MaTaiSan", DBNull.Value);
			if (_soHieuTaiSan.Length > 0)
				cm.Parameters.AddWithValue("@SoHieuTaiSan", _soHieuTaiSan);
			else
				cm.Parameters.AddWithValue("@SoHieuTaiSan", DBNull.Value);
			if (_tenTaiSan.Length > 0)
				cm.Parameters.AddWithValue("@TenTaiSan", _tenTaiSan);
			else
				cm.Parameters.AddWithValue("@TenTaiSan", DBNull.Value);
			if (_moduler.Length > 0)
				cm.Parameters.AddWithValue("@Moduler", _moduler);
			else
				cm.Parameters.AddWithValue("@Moduler", DBNull.Value);
			if (_serial.Length > 0)
				cm.Parameters.AddWithValue("@Serial", _serial);
			else
				cm.Parameters.AddWithValue("@Serial", DBNull.Value);
			if (_loai != false)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, InBarcoderList parent)
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

		private void ExecuteUpdate(SqlConnection cn, InBarcoderList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_UpdatetblInBarcoder]";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, InBarcoderList parent)
		{
			cm.Parameters.AddWithValue("@MaBarCoder", _maBarCoder);
			if (_maTaiSan != 0)
				cm.Parameters.AddWithValue("@MaTaiSan", _maTaiSan);
			else
				cm.Parameters.AddWithValue("@MaTaiSan", DBNull.Value);
			if (_soHieuTaiSan.Length > 0)
				cm.Parameters.AddWithValue("@SoHieuTaiSan", _soHieuTaiSan);
			else
				cm.Parameters.AddWithValue("@SoHieuTaiSan", DBNull.Value);
			if (_tenTaiSan.Length > 0)
				cm.Parameters.AddWithValue("@TenTaiSan", _tenTaiSan);
			else
				cm.Parameters.AddWithValue("@TenTaiSan", DBNull.Value);
			if (_moduler.Length > 0)
				cm.Parameters.AddWithValue("@Moduler", _moduler);
			else
				cm.Parameters.AddWithValue("@Moduler", DBNull.Value);
			if (_serial.Length > 0)
				cm.Parameters.AddWithValue("@Serial", _serial);
			else
				cm.Parameters.AddWithValue("@Serial", DBNull.Value);
			if (_loai != false)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maBarCoder));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
