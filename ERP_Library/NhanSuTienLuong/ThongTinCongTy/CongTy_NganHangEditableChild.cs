
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongTy_NganHang : Csla.BusinessBase<CongTy_NganHang>
	{
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private int _maCongTy = 0;
        private int _maNganHang = 0;
        private string _soTaiKhoan = string.Empty;
        private bool _active = false;
        private long _soUNCBatDau = 0;
        private int _loaiTien = 0;
        private int _maTKKeToan = 0;
        private string _tenNganHang = string.Empty;
        private string _maUNCNganHang = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public int MaCongTy
        {
            get
            {
                CanReadProperty("MaCongTy", true);
                return _maCongTy;
            }
            set
            {
                CanWriteProperty("MaCongTy", true);
                if (!_maCongTy.Equals(value))
                {
                    _maCongTy = value;
                    PropertyHasChanged("MaCongTy");
                }
            }
        }

        public int MaNganHang
        {
            get
            {
                CanReadProperty("MaNganHang", true);
                return _maNganHang;
            }
            set
            {
                CanWriteProperty("MaNganHang", true);
                if (!_maNganHang.Equals(value))
                {
                    _maNganHang = value;
                    PropertyHasChanged("MaNganHang");
                }
            }
        }

        public string SoTaiKhoan
        {
            get
            {
                CanReadProperty("SoTaiKhoan", true);
                return _soTaiKhoan;
            }
            set
            {
                CanWriteProperty("SoTaiKhoan", true);
                if (value == null) value = string.Empty;
                if (!_soTaiKhoan.Equals(value))
                {
                    _soTaiKhoan = value;
                    PropertyHasChanged("SoTaiKhoan");
                }
            }
        }

        public string MaUNCNganHang
        {
            get
            {
                CanReadProperty("MaUNCNganHang", true);
                return _maUNCNganHang;
            }
            set
            {
                CanWriteProperty("MaUNCNganHang", true);
                if (value == null) value = string.Empty;
                if (!_maUNCNganHang.Equals(value))
                {
                    _maUNCNganHang = value;
                    PropertyHasChanged("MaUNCNganHang");
                }
            }
        }

        public string TenNganHang
        {
            get
            {
                _tenNganHang = NganHang.GetNganHang(_maNganHang).TenNganHang;
                return _tenNganHang;
            }

        }

        public bool Active
        {
            get
            {
                CanReadProperty("Active", true);
                return _active;
            }
            set
            {
                CanWriteProperty("Active", true);
                if (!_active.Equals(value))
                {
                    _active = value;
                    PropertyHasChanged("Active");
                }
            }
        }

        public long SoUNCBatDau
        {
            get
            {
                CanReadProperty("SoUNCBatDau", true);
                return _soUNCBatDau;
            }
            set
            {
                CanWriteProperty("SoUNCBatDau", true);
                if (!_soUNCBatDau.Equals(value))
                {
                    _soUNCBatDau = value;
                    PropertyHasChanged("SoUNCBatDau");
                }
            }
        }

        public int LoaiTien
        {
            get
            {
                CanReadProperty("LoaiTien", true);
                return _loaiTien;
            }
            set
            {
                CanWriteProperty("LoaiTien", true);
                if (!_loaiTien.Equals(value))
                {
                    _loaiTien = value;
                    PropertyHasChanged("LoaiTien");
                }
            }
        }

        public int MaTKKeToan
        {
            get
            {
                CanReadProperty("MaTKKeToan", true);
                return _maTKKeToan;
            }
            set
            {
                CanWriteProperty("MaTKKeToan", true);
                if (!_maTKKeToan.Equals(value))
                {
                    _maTKKeToan = value;
                    PropertyHasChanged("MaTKKeToan");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTiet;
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
			// SoTaiKhoan
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "SoTaiKhoan");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTaiKhoan", 50));
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
			//TODO: Define authorization rules in CongTy_NganHang
			//AuthorizationRules.AllowRead("MaChiTiet", "CongTy_NganHangReadGroup");
			//AuthorizationRules.AllowRead("MaCongTy", "CongTy_NganHangReadGroup");
			//AuthorizationRules.AllowRead("MaNganHang", "CongTy_NganHangReadGroup");
			//AuthorizationRules.AllowRead("SoTaiKhoan", "CongTy_NganHangReadGroup");

			//AuthorizationRules.AllowWrite("MaCongTy", "CongTy_NganHangWriteGroup");
			//AuthorizationRules.AllowWrite("MaNganHang", "CongTy_NganHangWriteGroup");
			//AuthorizationRules.AllowWrite("SoTaiKhoan", "CongTy_NganHangWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static CongTy_NganHang NewCongTy_NganHang()
		{
			return new CongTy_NganHang();
		}

		internal static CongTy_NganHang GetCongTy_NganHang(SafeDataReader dr)
		{
			return new CongTy_NganHang(dr);
		}

        public static CongTy_NganHang GetCongTy_NganHang(int maChiTiet)
        {
            return DataPortal.Fetch<CongTy_NganHang>(new Criteria(maChiTiet));
        }
        public static CongTy_NganHang GetCongTy_NganHangByMaNganHang(int maNganHang)
        {
            return DataPortal.Fetch<CongTy_NganHang>(new CriteriaByMaNganHang(maNganHang));
        }

		private CongTy_NganHang()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private CongTy_NganHang(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods

		#region Data Access

        #region Criteria

        [Serializable()]

        private class Criteria
        {
            public int MaChiTiet;

            public Criteria(int maChiTiet)
            {
                this.MaChiTiet = maChiTiet;
            }
        }
        private class CriteriaByMaNganHang
        {
            public int MaNganHang;

            public CriteriaByMaNganHang(int maNganHang)
            {
                this.MaNganHang = maNganHang;
            }
        }
        #endregion //Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_Selecttblns_CongTy_NganHang";
                    cm.Parameters.AddWithValue("@MaChiTiet", ((Criteria)criteria).MaChiTiet);
                }
                else if (criteria is CriteriaByMaNganHang)
                {
                    cm.CommandText = "[spd_Selecttblns_CongTyByNganHang]";
                    cm.Parameters.AddWithValue("@MaNganHang", ((CriteriaByMaNganHang)criteria).MaNganHang);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    if (dr.Read())
                    {
                        FetchObject(dr);
                        //ValidationRules.CheckRules();
                    }
                }
            }//using
        }

        #endregion //Data Access - Fetch

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
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _maCongTy = dr.GetInt32("MaCongTy");
            _maNganHang = dr.GetInt32("MaNganHang");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _active = dr.GetBoolean("Active");
            _soUNCBatDau = dr.GetInt64("SoUNCBatDau");
            _loaiTien = dr.GetInt32("LoaiTien");
            _maTKKeToan = dr.GetInt32("MaTKKeToan");
            _maUNCNganHang = dr.GetString("MaUNCNganHang");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, CongTy parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, CongTy parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Inserttblns_CongTy_NganHang";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, CongTy parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			
            if (parent.MaCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", parent.MaCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_active != false)
                cm.Parameters.AddWithValue("@Active", _active);
            else
                cm.Parameters.AddWithValue("@Active", DBNull.Value);
            if (_soUNCBatDau != 0)
                cm.Parameters.AddWithValue("@SoUNCBatDau", _soUNCBatDau);
            else
                cm.Parameters.AddWithValue("@SoUNCBatDau", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_maTKKeToan != 0)
                cm.Parameters.AddWithValue("@MaTKKeToan", _maTKKeToan);
            else
                cm.Parameters.AddWithValue("@MaTKKeToan", DBNull.Value);
            if (_maUNCNganHang.Length > 0)
                cm.Parameters.AddWithValue("@MaUNCNganHang", _maUNCNganHang);
            else
                cm.Parameters.AddWithValue("@MaUNCNganHang", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, CongTy parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr, CongTy parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Updatetblns_CongTy_NganHang";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, CongTy parent)
		{
            if (parent.MaCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", parent.MaCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_active != false)
                cm.Parameters.AddWithValue("@Active", _active);
            else
                cm.Parameters.AddWithValue("@Active", DBNull.Value);
            if (_soUNCBatDau != 0)
                cm.Parameters.AddWithValue("@SoUNCBatDau", _soUNCBatDau);
            else
                cm.Parameters.AddWithValue("@SoUNCBatDau", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_maTKKeToan != 0)
                cm.Parameters.AddWithValue("@MaTKKeToan", _maTKKeToan);
            else
                cm.Parameters.AddWithValue("@MaTKKeToan", DBNull.Value);
            if (_maUNCNganHang.Length > 0)
                cm.Parameters.AddWithValue("@MaUNCNganHang", _maUNCNganHang);
            else
                cm.Parameters.AddWithValue("@MaUNCNganHang", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
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

			ExecuteDelete(tr);
			MarkNew();
		}

		private void ExecuteDelete(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Deletetblns_CongTy_NganHang";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
