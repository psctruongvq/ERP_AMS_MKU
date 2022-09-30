
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TMBCTC_CongThucVCSH : Csla.BusinessBase<TMBCTC_CongThucVCSH>
	{
		#region Business Properties and Methods

		//declare members
		private int _maCongThuc = 0;
		private byte _maNguon = 0;
		private byte _hinhThuc = 0;
		private int _maTaiKhoan = 0;
		private int _maTaiKhoanDoiUng = 0;
		private byte _congTru = 0;
		private string _soHieuTK = string.Empty;
		private byte _loai = 0;
		private byte _noCo = 0;

        private int _maThongTu = 0;
        private byte _isNHNN = 0;
        private int _maCongThucDoiUng = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaCongThuc
		{
			get
			{
				CanReadProperty("MaCongThuc", true);
				return _maCongThuc;
			}
		}

		public byte MaNguon
		{
			get
			{
				CanReadProperty("MaNguon", true);
				return _maNguon;
			}
			set
			{
				CanWriteProperty("MaNguon", true);
				if (!_maNguon.Equals(value))
				{
					_maNguon = value;
					PropertyHasChanged("MaNguon");
				}
			}
		}

		public byte HinhThuc
		{
			get
			{
				CanReadProperty("HinhThuc", true);
				return _hinhThuc;
			}
			set
			{
				CanWriteProperty("HinhThuc", true);
				if (!_hinhThuc.Equals(value))
				{
					_hinhThuc = value;
					PropertyHasChanged("HinhThuc");
				}
			}
		}

		public int MaTaiKhoan
		{
			get
			{
				CanReadProperty("MaTaiKhoan", true);
				return _maTaiKhoan;
			}
			set
			{
				CanWriteProperty("MaTaiKhoan", true);
				if (!_maTaiKhoan.Equals(value))
				{
					_maTaiKhoan = value;
					PropertyHasChanged("MaTaiKhoan");
				}
			}
		}

		public int MaTaiKhoanDoiUng
		{
			get
			{
				CanReadProperty("MaTaiKhoanDoiUng", true);
				return _maTaiKhoanDoiUng;
			}
			set
			{
				CanWriteProperty("MaTaiKhoanDoiUng", true);
				if (!_maTaiKhoanDoiUng.Equals(value))
				{
					_maTaiKhoanDoiUng = value;
					PropertyHasChanged("MaTaiKhoanDoiUng");
				}
			}
		}

		public byte CongTru
		{
			get
			{
				CanReadProperty("CongTru", true);
				return _congTru;
			}
			set
			{
				CanWriteProperty("CongTru", true);
				if (!_congTru.Equals(value))
				{
					_congTru = value;
					PropertyHasChanged("CongTru");
				}
			}
		}

		public string SoHieuTK
		{
			get
			{
				CanReadProperty("SoHieuTK", true);
				return _soHieuTK;
			}
			set
			{
				CanWriteProperty("SoHieuTK", true);
				if (value == null) value = string.Empty;
				if (!_soHieuTK.Equals(value))
				{
					_soHieuTK = value;
					PropertyHasChanged("SoHieuTK");
				}
			}
		}

		public byte Loai
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

		public byte NoCo
		{
			get
			{
				CanReadProperty("NoCo", true);
				return _noCo;
			}
			set
			{
				CanWriteProperty("NoCo", true);
				if (!_noCo.Equals(value))
				{
					_noCo = value;
					PropertyHasChanged("NoCo");
				}
			}
		}

        public int MaThongTu
        {
            get
            {
                CanReadProperty("MaThongTu", true);
                return _maThongTu;
            }
            set
            {
                CanWriteProperty("MaThongTu", true);
                if(!_maThongTu.Equals(value))
                {
                    _maThongTu = value;
                    PropertyHasChanged("MaThongTu");
                }
            }
        }

        public byte isNHNN
        {
            get
            {
                CanReadProperty("isNHNN", true);
                return _isNHNN;
            }
            set
            {
                CanWriteProperty("isNHNN", true);
                if(!_isNHNN.Equals(value))
                {
                    _isNHNN = value;
                    PropertyHasChanged("isNHNN");
                }
            }
        }

        public int MaCongThucDoiUng
        {
            get
            {
                CanReadProperty("MaCongThucDoiUng", true);
                return _maCongThucDoiUng;
            }
            set
            {
                CanWriteProperty("MaCongThucDoiUng", true);
                if(!_maCongThucDoiUng.Equals(value))
                {
                    _maCongThucDoiUng = value;
                    PropertyHasChanged("MaCongThucDoiUng");
                }
            }
        }
 
		protected override object GetIdValue()
		{
			return _maCongThuc;
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
			// SoHieuTK
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHieuTK", 50));
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
			//TODO: Define authorization rules in TMBCTC_CongThucVCSH
			//AuthorizationRules.AllowRead("MaCongThuc", "TMBCTC_CongThucVCSHReadGroup");
			//AuthorizationRules.AllowRead("MaNguon", "TMBCTC_CongThucVCSHReadGroup");
			//AuthorizationRules.AllowRead("HinhThuc", "TMBCTC_CongThucVCSHReadGroup");
			//AuthorizationRules.AllowRead("MaTaiKhoan", "TMBCTC_CongThucVCSHReadGroup");
			//AuthorizationRules.AllowRead("MaTaiKhoanDoiUng", "TMBCTC_CongThucVCSHReadGroup");
			//AuthorizationRules.AllowRead("CongTru", "TMBCTC_CongThucVCSHReadGroup");
			//AuthorizationRules.AllowRead("SoHieuTK", "TMBCTC_CongThucVCSHReadGroup");
			//AuthorizationRules.AllowRead("Loai", "TMBCTC_CongThucVCSHReadGroup");
			//AuthorizationRules.AllowRead("NoCo", "TMBCTC_CongThucVCSHReadGroup");

			//AuthorizationRules.AllowWrite("MaNguon", "TMBCTC_CongThucVCSHWriteGroup");
			//AuthorizationRules.AllowWrite("HinhThuc", "TMBCTC_CongThucVCSHWriteGroup");
			//AuthorizationRules.AllowWrite("MaTaiKhoan", "TMBCTC_CongThucVCSHWriteGroup");
			//AuthorizationRules.AllowWrite("MaTaiKhoanDoiUng", "TMBCTC_CongThucVCSHWriteGroup");
			//AuthorizationRules.AllowWrite("CongTru", "TMBCTC_CongThucVCSHWriteGroup");
			//AuthorizationRules.AllowWrite("SoHieuTK", "TMBCTC_CongThucVCSHWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "TMBCTC_CongThucVCSHWriteGroup");
			//AuthorizationRules.AllowWrite("NoCo", "TMBCTC_CongThucVCSHWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TMBCTC_CongThucVCSH
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TMBCTC_CongThucVCSHViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TMBCTC_CongThucVCSH
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TMBCTC_CongThucVCSHAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TMBCTC_CongThucVCSH
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TMBCTC_CongThucVCSHEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TMBCTC_CongThucVCSH
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TMBCTC_CongThucVCSHDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TMBCTC_CongThucVCSH()
		{ /* require use of factory method */ }

		public static TMBCTC_CongThucVCSH NewTMBCTC_CongThucVCSH()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TMBCTC_CongThucVCSH");
			return DataPortal.Create<TMBCTC_CongThucVCSH>();
		}

		public static TMBCTC_CongThucVCSH GetTMBCTC_CongThucVCSH(int maCongThuc)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TMBCTC_CongThucVCSH");
			return DataPortal.Fetch<TMBCTC_CongThucVCSH>(new Criteria(maCongThuc));
		}

		public static void DeleteTMBCTC_CongThucVCSH(int maCongThuc)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TMBCTC_CongThucVCSH");
			DataPortal.Delete(new Criteria(maCongThuc));
		}

		public override TMBCTC_CongThucVCSH Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TMBCTC_CongThucVCSH");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TMBCTC_CongThucVCSH");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TMBCTC_CongThucVCSH");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TMBCTC_CongThucVCSH NewTMBCTC_CongThucVCSHChild()
		{
			TMBCTC_CongThucVCSH child = new TMBCTC_CongThucVCSH();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

        public static TMBCTC_CongThucVCSH NewTMBCTC_CongThucVCSHChild(TMBCTC_CongThucVCSH bangCopy)
        {
            TMBCTC_CongThucVCSH child = new TMBCTC_CongThucVCSH();
            child.MaNguon = bangCopy.MaNguon;
            child.HinhThuc = bangCopy.HinhThuc;
            child.MaTaiKhoan = bangCopy.MaTaiKhoan;
            child.MaTaiKhoanDoiUng = bangCopy.MaTaiKhoanDoiUng;
            child.CongTru = bangCopy.CongTru;
            child.SoHieuTK = bangCopy.SoHieuTK;
            child.Loai = bangCopy.Loai;
            child.NoCo = bangCopy.NoCo;
            child.MaCongThucDoiUng = bangCopy.MaCongThucDoiUng != 0 ? bangCopy.MaCongThucDoiUng : bangCopy.MaCongThuc;
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

		internal static TMBCTC_CongThucVCSH GetTMBCTC_CongThucVCSH(SafeDataReader dr)
		{
			TMBCTC_CongThucVCSH child =  new TMBCTC_CongThucVCSH();
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
			public int MaCongThuc;

			public Criteria(int maCongThuc)
			{
				this.MaCongThuc = maCongThuc;
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

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "usp_SelecttblTMBCTC_CongThucVCSH";

				cm.Parameters.AddWithValue("@MaCongThuc", criteria.MaCongThuc);

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
			DataPortal_Delete(new Criteria(_maCongThuc));
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
                cm.CommandText = "usp_DeletetblTMBCTC_CongThucVCSH";

				cm.Parameters.AddWithValue("@MaCongThuc", criteria.MaCongThuc);

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
			_maCongThuc = dr.GetInt32("MaCongThuc");
			_maNguon = dr.GetByte("MaNguon");
			_hinhThuc = dr.GetByte("HinhThuc");
			_maTaiKhoan = dr.GetInt32("MaTaiKhoan");
			_maTaiKhoanDoiUng = dr.GetInt32("MaTaiKhoanDoiUng");
			_congTru = dr.GetByte("CongTru");
			_soHieuTK = dr.GetString("SoHieuTK");
			_loai = dr.GetByte("Loai");
			_noCo = dr.GetByte("NoCo");
            _maThongTu = dr.GetInt32("MaThongTu");
            _isNHNN = dr.GetByte("isNHNN");
            _maCongThucDoiUng = dr.GetInt32("MaCongThucDoiUng");
		}

		private void FetchChildren(SafeDataReader dr)
		{
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
                cm.CommandText = "usp_InserttblTMBCTC_CongThucVCSH";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maCongThuc = (int)cm.Parameters["@MaCongThuc"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maNguon != 0)
				cm.Parameters.AddWithValue("@MaNguon", _maNguon);
			else
				cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
			
				cm.Parameters.AddWithValue("@HinhThuc", _hinhThuc);
			
			if (_maTaiKhoan != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
			if (_maTaiKhoanDoiUng != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", _maTaiKhoanDoiUng);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", DBNull.Value);
			if (_congTru != 0)
				cm.Parameters.AddWithValue("@CongTru", _congTru);
			else
				cm.Parameters.AddWithValue("@CongTru", DBNull.Value);
			if (_soHieuTK.Length > 0)
				cm.Parameters.AddWithValue("@SoHieuTK", _soHieuTK);
			else
				cm.Parameters.AddWithValue("@SoHieuTK", DBNull.Value);
			if (_loai != 0)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);
			if (_noCo != 0)
				cm.Parameters.AddWithValue("@NoCo", _noCo);
			else
				cm.Parameters.AddWithValue("@NoCo", DBNull.Value);

            if (_maThongTu != 0)
                cm.Parameters.AddWithValue("@MaThongTu", _maThongTu);
            else
                cm.Parameters.AddWithValue("@MaThongTu", DBNull.Value);
            if (_isNHNN != 0)
                cm.Parameters.AddWithValue("@isNHNN", _isNHNN);
            else
                cm.Parameters.AddWithValue("@isNHNN", DBNull.Value);
            if (_maCongThucDoiUng != 0)
                cm.Parameters.AddWithValue("@MaCongThucDoiUng", _maCongThucDoiUng);
            else
                cm.Parameters.AddWithValue("@MaCongThucDoiUng", DBNull.Value);
			cm.Parameters.AddWithValue("@MaCongThuc", _maCongThuc);
			cm.Parameters["@MaCongThuc"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "usp_UpdatetblTMBCTC_CongThucVCSH";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaCongThuc", _maCongThuc);
			if (_maNguon != 0)
				cm.Parameters.AddWithValue("@MaNguon", _maNguon);
			else
				cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);			
				cm.Parameters.AddWithValue("@HinhThuc", _hinhThuc);			
			if (_maTaiKhoan != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
			if (_maTaiKhoanDoiUng != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", _maTaiKhoanDoiUng);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", DBNull.Value);
			if (_congTru != 0)
				cm.Parameters.AddWithValue("@CongTru", _congTru);
			else
				cm.Parameters.AddWithValue("@CongTru", DBNull.Value);
			if (_soHieuTK.Length > 0)
				cm.Parameters.AddWithValue("@SoHieuTK", _soHieuTK);
			else
				cm.Parameters.AddWithValue("@SoHieuTK", DBNull.Value);
			if (_loai != 0)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);
			if (_noCo != 0)
				cm.Parameters.AddWithValue("@NoCo", _noCo);
			else
				cm.Parameters.AddWithValue("@NoCo", DBNull.Value);

            if (_maThongTu != 0)
                cm.Parameters.AddWithValue("@MaThongTu", _maThongTu);
            else
                cm.Parameters.AddWithValue("@MaThongTu", DBNull.Value);
            if (_isNHNN != 0)
                cm.Parameters.AddWithValue("@isNHNN", _isNHNN);
            else
                cm.Parameters.AddWithValue("@isNHNN", DBNull.Value);
            if (_maCongThucDoiUng != 0)
                cm.Parameters.AddWithValue("@MaCongThucDoiUng", _maCongThucDoiUng);
            else
                cm.Parameters.AddWithValue("@MaCongThucDoiUng", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(tr, new Criteria(_maCongThuc));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
