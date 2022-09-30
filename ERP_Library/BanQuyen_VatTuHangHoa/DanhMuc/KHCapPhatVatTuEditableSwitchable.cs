
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KHCapPhatVatTu : Csla.BusinessBase<KHCapPhatVatTu>
	{
		#region Business Properties and Methods

		//declare members
		private int _makeHoachCapPhat = 0;
		private int _maBoPhan = 0;
		private int _nam = DateTime.Today.Year;
		private string _dienGiai = string.Empty;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private string _soKeHoach = string.Empty;
		private int _maNguoiLap = 0;
		private byte _tinhTrang = 1;
        private int _maLoaiVatTuHH = 0;

		//declare child member(s)
		private CT_KHCapPhatVatTuList _cT_KHCapPhatVatTuList = CT_KHCapPhatVatTuList.NewCT_KHCapPhatVatTuList();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MakeHoachCapPhat
		{
			get
			{
				CanReadProperty("MakeHoachCapPhat", true);
				return _makeHoachCapPhat;
			}
		}

		public int MaBoPhan
		{
			get
			{
				CanReadProperty("MaBoPhan", true);
				return _maBoPhan;
			}
			set
			{
				CanWriteProperty("MaBoPhan", true);
				if (!_maBoPhan.Equals(value))
				{
					_maBoPhan = value;
					PropertyHasChanged("MaBoPhan");
				}
			}
		}

		public int Nam
		{
			get
			{
				CanReadProperty("Nam", true);
				return _nam;
			}
			set
			{
				CanWriteProperty("Nam", true);
				if (!_nam.Equals(value))
				{
					_nam = value;
					PropertyHasChanged("Nam");
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
                _ngayLap = new SmartDate(value);

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

		public string SoKeHoach
		{
			get
			{
				CanReadProperty("SoKeHoach", true);
				return _soKeHoach;
			}
			set
			{
				CanWriteProperty("SoKeHoach", true);
				if (value == null) value = string.Empty;
				if (!_soKeHoach.Equals(value))
				{
					_soKeHoach = value;
					PropertyHasChanged("SoKeHoach");
				}
			}
		}

		public int MaNguoiLap
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

		public byte TinhTrang
		{
			get
			{
				CanReadProperty("TinhTrang", true);
				return _tinhTrang;
			}
			set
			{
				CanWriteProperty("TinhTrang", true);
				if (!_tinhTrang.Equals(value))
				{
					_tinhTrang = value;
					PropertyHasChanged("TinhTrang");
				}
			}
		}

        public int MaLoaiVatTuHH
        {
            get
            {
                CanReadProperty("MaLoaiVatTuHH", true);
                return _maLoaiVatTuHH;
            }
            set
            {
                CanWriteProperty("MaLoaiVatTuHH", true);
                if (!_maLoaiVatTuHH.Equals(value))
                {
                    _maLoaiVatTuHH = value;
                    PropertyHasChanged("MaLoaiVatTuHH");
                }
            }
        }

		public CT_KHCapPhatVatTuList CT_KHCapPhatVatTuList
		{
			get
			{
				CanReadProperty("CT_KHCapPhatVatTuList", true);
				return _cT_KHCapPhatVatTuList;
			}
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _cT_KHCapPhatVatTuList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _cT_KHCapPhatVatTuList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _makeHoachCapPhat;
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
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 1000));
			//
			// SoKeHoach
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoKeHoach", 50));
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
			//TODO: Define authorization rules in KHCapPhatVatTu
			//AuthorizationRules.AllowRead("CT_KHCapPhatVatTuList", "KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("MakeHoachCapPhat", "KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhan", "KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("Nam", "KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("SoKeHoach", "KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("TinhTrang", "KHCapPhatVatTuReadGroup");

			//AuthorizationRules.AllowWrite("MaBoPhan", "KHCapPhatVatTuWriteGroup");
			//AuthorizationRules.AllowWrite("Nam", "KHCapPhatVatTuWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "KHCapPhatVatTuWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "KHCapPhatVatTuWriteGroup");
			//AuthorizationRules.AllowWrite("SoKeHoach", "KHCapPhatVatTuWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "KHCapPhatVatTuWriteGroup");
			//AuthorizationRules.AllowWrite("TinhTrang", "KHCapPhatVatTuWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KHCapPhatVatTu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KHCapPhatVatTuViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KHCapPhatVatTu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KHCapPhatVatTuAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KHCapPhatVatTu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KHCapPhatVatTuEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KHCapPhatVatTu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KHCapPhatVatTuDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KHCapPhatVatTu()
		{ /* require use of factory method */ }

		public static KHCapPhatVatTu NewKHCapPhatVatTu()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KHCapPhatVatTu");
			return DataPortal.Create<KHCapPhatVatTu>();
		}

		public static KHCapPhatVatTu GetKHCapPhatVatTu(int makeHoachCapPhat)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KHCapPhatVatTu");
			return DataPortal.Fetch<KHCapPhatVatTu>(new Criteria(makeHoachCapPhat));
		}

		public static void DeleteKHCapPhatVatTu(int makeHoachCapPhat)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KHCapPhatVatTu");
			DataPortal.Delete(new Criteria(makeHoachCapPhat));
		}

		public override KHCapPhatVatTu Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KHCapPhatVatTu");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KHCapPhatVatTu");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a KHCapPhatVatTu");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static KHCapPhatVatTu NewKHCapPhatVatTuChild()
		{
			KHCapPhatVatTu child = new KHCapPhatVatTu();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static KHCapPhatVatTu GetKHCapPhatVatTu(SafeDataReader dr)
		{
			KHCapPhatVatTu child =  new KHCapPhatVatTu();
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
			public int MakeHoachCapPhat;

			public Criteria(int makeHoachCapPhat)
			{
				this.MakeHoachCapPhat = makeHoachCapPhat;
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
                cm.CommandText = "spd_SelectKeHoachCapPhatVatTu";

				cm.Parameters.AddWithValue("@MakeHoachCapPhat", criteria.MakeHoachCapPhat);

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
			DataPortal_Delete(new Criteria(_makeHoachCapPhat));
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
                    _cT_KHCapPhatVatTuList.Clear();
                    _cT_KHCapPhatVatTuList.Update(tr, this);

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
                cm.CommandText = "spd_DeleteKeHoachCapPhatVatTu";

				cm.Parameters.AddWithValue("@MakeHoachCapPhat", criteria.MakeHoachCapPhat);

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
			_makeHoachCapPhat = dr.GetInt32("MakeHoachCapPhat");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_nam = dr.GetInt32("Nam");
			_dienGiai = dr.GetString("DienGiai");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_soKeHoach = dr.GetString("SoKeHoach");
			_maNguoiLap = dr.GetInt32("MaNguoiLap");
			_tinhTrang = dr.GetByte("TinhTrang");
            _maLoaiVatTuHH = dr.GetInt32("MaLoaiVatTuHH");
		}

		private void FetchChildren(SafeDataReader dr)
		{
			
			_cT_KHCapPhatVatTuList = CT_KHCapPhatVatTuList.GetCT_KHCapPhatVatTuList(this.MakeHoachCapPhat);
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
                cm.CommandText = "spd_InsertKeHoachCapPhatVatTu";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_makeHoachCapPhat = (int)cm.Parameters["@MakeHoachCapPhat"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_nam != 0)
				cm.Parameters.AddWithValue("@Nam", _nam);
			else
				cm.Parameters.AddWithValue("@Nam", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_soKeHoach.Length > 0)
				cm.Parameters.AddWithValue("@SoKeHoach", _soKeHoach);
			else
				cm.Parameters.AddWithValue("@SoKeHoach", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			if (_tinhTrang != 0)
				cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
			else
				cm.Parameters.AddWithValue("@TinhTrang", DBNull.Value);
            if (_maLoaiVatTuHH != 0)
                cm.Parameters.AddWithValue("@MaLoaiVatTuHH", _maLoaiVatTuHH);
            else
                cm.Parameters.AddWithValue("@MaLoaiVatTuHH", DBNull.Value);
			cm.Parameters.AddWithValue("@MakeHoachCapPhat", _makeHoachCapPhat);
			cm.Parameters["@MakeHoachCapPhat"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdateKeHoachCapPhatVatTu";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MakeHoachCapPhat", _makeHoachCapPhat);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_nam != 0)
				cm.Parameters.AddWithValue("@Nam", _nam);
			else
				cm.Parameters.AddWithValue("@Nam", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_soKeHoach.Length > 0)
				cm.Parameters.AddWithValue("@SoKeHoach", _soKeHoach);
			else
				cm.Parameters.AddWithValue("@SoKeHoach", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			if (_tinhTrang != 0)
				cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
			else
				cm.Parameters.AddWithValue("@TinhTrang", DBNull.Value);
            if (_maLoaiVatTuHH != 0)
                cm.Parameters.AddWithValue("@MaLoaiVatTuHH", _maLoaiVatTuHH);
            else
                cm.Parameters.AddWithValue("@MaLoaiVatTuHH", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_cT_KHCapPhatVatTuList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            _cT_KHCapPhatVatTuList.Clear();
            _cT_KHCapPhatVatTuList.Update(tr, this);
			ExecuteDelete(tr, new Criteria(_makeHoachCapPhat));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access

        #region Set,Check So Ke Hoach
        public static string SetSoKeHoach(int _userID, DateTime _ngayLap)
        {
            string _soKeHoach = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SetSoKeHoachKHCapPhatVatTu";
                    cm.Parameters.AddWithValue("@UserID", _userID);
                    cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _soKeHoach = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return _soKeHoach;
        }

        public static int CheckSoKeHoach(long _makeHoachCapPhat, string _soKeHoach)
        {
            int _isOld;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckSoKeHoachKHCapPhatVatTu";
                    cm.Parameters.AddWithValue("@MakeHoachCapPhat", _makeHoachCapPhat);
                    cm.Parameters.AddWithValue("@SoKeHoach", _soKeHoach);
                    SqlParameter isOld = new SqlParameter("@isOld", SqlDbType.Int);
                    isOld.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(isOld);
                    cm.ExecuteNonQuery();
                    _isOld = (int)isOld.Value;
                }
            }//us
            return _isOld;

        }
        #endregion 
	}
}
