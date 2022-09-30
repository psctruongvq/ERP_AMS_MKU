
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhanBoChiPhiCCDC : Csla.BusinessBase<PhanBoChiPhiCCDC>
	{
		#region Business Properties and Methods

		//declare members
		private int _maPhanBo = 0;
		private SmartDate _ngayPhanBo = new SmartDate(DateTime.Today);
		private int _maNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
		private string _soChungTu = string.Empty;
		private string _dienGiai = string.Empty;
		private int _maBoPhan = -1;
        private long _maChungTu = 0;
        private int _maKy;
		//declare child member(s)
		private CT_PhanBoChiPhiCCDCList _cT_PhanBoChiPhiCCDCList = CT_PhanBoChiPhiCCDCList.NewCT_PhanBoChiPhiCCDCList();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaPhanBo
		{
			get
			{
				CanReadProperty("MaPhanBo", true);
				return _maPhanBo;
			}
		}

		public DateTime NgayPhanBo
		{
			get
			{
				CanReadProperty("NgayPhanBo", true);
				return _ngayPhanBo.Date;
			}
            set
            {

                CanWriteProperty("NgayPhanBo", true);
                _ngayPhanBo = new SmartDate(value);
                PropertyHasChanged("NgayPhanBo");
            }
		}

		public string NgayPhanBoString
		{
			get
			{
				CanReadProperty("NgayPhanBoString", true);
				return _ngayPhanBo.Text;
			}
			set
			{
				CanWriteProperty("NgayPhanBoString", true);
				if (value == null) value = string.Empty;
				if (!_ngayPhanBo.Equals(value))
				{
					_ngayPhanBo.Text = value;
					PropertyHasChanged("NgayPhanBoString");
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

        public long MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _maChungTu;
            }
            set
            {
                CanWriteProperty("MaChungTu", true);
                if (!_maChungTu.Equals(value))
                {
                    _maChungTu = value;
                    PropertyHasChanged("MaChungTu");
                }
            }
        }

        public int MaKy
        {
            get
            {
                CanReadProperty("MaKyKeToan", true);
                return _maKy;
            }
            set
            {
                CanWriteProperty("MaKyKeToan", true);
                if (!_maKy.Equals(value))
                {
                    _maKy = value;
                    PropertyHasChanged("MaKyKeToan");
                }
            }
        }

		public CT_PhanBoChiPhiCCDCList CT_PhanBoChiPhiCCDCList
		{
			get
			{
				CanReadProperty("CT_PhanBoChiPhiCCDCList", true);
				return _cT_PhanBoChiPhiCCDCList;
			}
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _cT_PhanBoChiPhiCCDCList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _cT_PhanBoChiPhiCCDCList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maPhanBo;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
			//
			// DienGiai
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 10));
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
			//TODO: Define authorization rules in PhanBoChiPhiCCDC
			//AuthorizationRules.AllowRead("CT_PhanBoChiPhiCCDCList", "PhanBoChiPhiCCDCReadGroup");
			//AuthorizationRules.AllowRead("MaPhanBo", "PhanBoChiPhiCCDCReadGroup");
			//AuthorizationRules.AllowRead("NgayPhanBo", "PhanBoChiPhiCCDCReadGroup");
			//AuthorizationRules.AllowRead("NgayPhanBoString", "PhanBoChiPhiCCDCReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "PhanBoChiPhiCCDCReadGroup");
			//AuthorizationRules.AllowRead("SoChungTu", "PhanBoChiPhiCCDCReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "PhanBoChiPhiCCDCReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhan", "PhanBoChiPhiCCDCReadGroup");

			//AuthorizationRules.AllowWrite("NgayPhanBoString", "PhanBoChiPhiCCDCWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "PhanBoChiPhiCCDCWriteGroup");
			//AuthorizationRules.AllowWrite("SoChungTu", "PhanBoChiPhiCCDCWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "PhanBoChiPhiCCDCWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhan", "PhanBoChiPhiCCDCWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhanBoChiPhiCCDC
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoChiPhiCCDCViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhanBoChiPhiCCDC
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoChiPhiCCDCAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhanBoChiPhiCCDC
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoChiPhiCCDCEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhanBoChiPhiCCDC
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoChiPhiCCDCDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhanBoChiPhiCCDC()
		{ /* require use of factory method */ }

		public static PhanBoChiPhiCCDC NewPhanBoChiPhiCCDC()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanBoChiPhiCCDC");
			return DataPortal.Create<PhanBoChiPhiCCDC>();
		}

        public static PhanBoChiPhiCCDC NewPhanBoChiPhiCCDC( int maBoPhan)
        {
            PhanBoChiPhiCCDC phanBoChiPhiCCDC = new PhanBoChiPhiCCDC();
            phanBoChiPhiCCDC.MaBoPhan = maBoPhan;
            phanBoChiPhiCCDC.SoChungTu = PhanBoChiPhiCCDC.SetSoChungTu(phanBoChiPhiCCDC.NgayPhanBo);
            phanBoChiPhiCCDC._cT_PhanBoChiPhiCCDCList = CT_PhanBoChiPhiCCDCList.GetCT_PhanBoChiPhiCCDCNewList(maBoPhan);
            return phanBoChiPhiCCDC;
        }

        public static PhanBoChiPhiCCDC NewPhanBoChiPhiCCDC(int maBoPhan, DateTime ngayPhanBo)
        {
            PhanBoChiPhiCCDC phanBoChiPhiCCDC = new PhanBoChiPhiCCDC();
            phanBoChiPhiCCDC.MaBoPhan = maBoPhan;
            phanBoChiPhiCCDC.NgayPhanBo = ngayPhanBo;
            phanBoChiPhiCCDC.SoChungTu = PhanBoChiPhiCCDC.SetSoChungTu(phanBoChiPhiCCDC.NgayPhanBo);
            phanBoChiPhiCCDC._cT_PhanBoChiPhiCCDCList = CT_PhanBoChiPhiCCDCList.GetCT_PhanBoChiPhiCCDCNewList(maBoPhan,ngayPhanBo);
            return phanBoChiPhiCCDC;
        }

        public static PhanBoChiPhiCCDC NewPhanBoChiPhiCCDC(int maBoPhan, int maKy , int userID)
        {
            PhanBoChiPhiCCDC phanBoChiPhiCCDC = new PhanBoChiPhiCCDC();
            phanBoChiPhiCCDC.MaBoPhan = maBoPhan;
            phanBoChiPhiCCDC.MaNguoiLap = userID;
            phanBoChiPhiCCDC.MaKy = maKy;
            phanBoChiPhiCCDC.SoChungTu = PhanBoChiPhiCCDC.SetSoChungTu(phanBoChiPhiCCDC.NgayPhanBo);
            phanBoChiPhiCCDC._cT_PhanBoChiPhiCCDCList = CT_PhanBoChiPhiCCDCList.GetCT_PhanBoChiPhiCCDCNewList(maBoPhan, maKy);
            return phanBoChiPhiCCDC;
        }


		public static PhanBoChiPhiCCDC GetPhanBoChiPhiCCDC(int maPhanBo)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhanBoChiPhiCCDC");
			return DataPortal.Fetch<PhanBoChiPhiCCDC>(new Criteria(maPhanBo));
		}

		public static void DeletePhanBoChiPhiCCDC(int maPhanBo)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhanBoChiPhiCCDC");
			DataPortal.Delete(new Criteria(maPhanBo));
		}

		public override PhanBoChiPhiCCDC Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhanBoChiPhiCCDC");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanBoChiPhiCCDC");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a PhanBoChiPhiCCDC");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static PhanBoChiPhiCCDC NewPhanBoChiPhiCCDCChild()
		{
			PhanBoChiPhiCCDC child = new PhanBoChiPhiCCDC();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhanBoChiPhiCCDC GetPhanBoChiPhiCCDC(SafeDataReader dr)
		{
			PhanBoChiPhiCCDC child =  new PhanBoChiPhiCCDC();
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
			public int MaPhanBo;

			public Criteria(int maPhanBo)
			{
				this.MaPhanBo = maPhanBo;
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
                cm.CommandText = "spd_SelecttblPhanBoChiPhiCCDC";

				cm.Parameters.AddWithValue("@MaPhanBo", criteria.MaPhanBo);

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
			DataPortal_Delete(new Criteria(_maPhanBo));
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
                    _cT_PhanBoChiPhiCCDCList.Clear();
                    _cT_PhanBoChiPhiCCDCList.Update(tr, this);
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
                cm.CommandText = "spd_DeletetblPhanBoChiPhiCCDC";

				cm.Parameters.AddWithValue("@MaPhanBo", criteria.MaPhanBo);

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
			_maPhanBo = dr.GetInt32("MaPhanBo");
			_ngayPhanBo = dr.GetSmartDate("NgayPhanBo", _ngayPhanBo.EmptyIsMin);
			_maNguoiLap = dr.GetInt32("MaNguoiLap");
			_soChungTu = dr.GetString("SoChungTu");
			_dienGiai = dr.GetString("DienGiai");
			_maBoPhan = dr.GetInt32("MaBoPhan");
            _maChungTu = dr.GetInt64("MaChungTu");
            _maKy = dr.GetInt32("MaKyKeToan");
		}

		private void FetchChildren(SafeDataReader dr)
		{			
			_cT_PhanBoChiPhiCCDCList = CT_PhanBoChiPhiCCDCList.GetCT_PhanBoChiPhiCCDCList(this.MaPhanBo);
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
                cm.CommandText = "spd_InserttblPhanBoChiPhiCCDC";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maPhanBo = (int)cm.Parameters["@MaPhanBo"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@NgayPhanBo", _ngayPhanBo.DBValue);
            cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);  
			if (_soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maChungTu !=0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
			cm.Parameters.AddWithValue("@MaPhanBo", _maPhanBo);
			cm.Parameters["@MaPhanBo"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblPhanBoChiPhiCCDC";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaPhanBo", _maPhanBo);
			cm.Parameters.AddWithValue("@NgayPhanBo", _ngayPhanBo.DBValue);
			cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);  
			if (_soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_cT_PhanBoChiPhiCCDCList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            _cT_PhanBoChiPhiCCDCList.Clear();
            _cT_PhanBoChiPhiCCDCList.Update(tr, this);
			ExecuteDelete(tr, new Criteria(_maPhanBo));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access


        #region Set So Phieu
        public static string SetSoChungTu( DateTime _ngayLap)
        {
            string _soPhieuNhapXuat = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SetSoChungTuPBCP_CCDC";                    
                    cm.Parameters.AddWithValue("NgayLap", _ngayLap);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _soPhieuNhapXuat = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return _soPhieuNhapXuat;
        }

        public static bool KiemTraDaPhanBoTrongKy(int maBoPhan,DateTime ngayPhanBo)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraDaPhanBoTrongKy_CCDC";
                    cm.Parameters.AddWithValue("@NgayPhanBo", ngayPhanBo);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@Result", SqlDbType.Bit, 10);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    result = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return result;
        }

        public static int KiemTraDuocPhepPhanBoTrongKy(int maBoPhan, int maKy)
        {
            int result = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraKyPhanBoHopLe_CCDC";
                    cm.Parameters.AddWithValue("@MaKy", maKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@Result", SqlDbType.Int, 10);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    result = (int)prmGiaTriTraVe.Value;
                }
            }//us
            return result;
        }

        #endregion//End So Phieu
	}
}
