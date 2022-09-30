
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DiaChi_NhanVien : Csla.BusinessBase<DiaChi_NhanVien>
	{
		#region Business Properties and Methods

		//declare members
		private string _tenDiaChi = string.Empty;
        private int _maQuanHuyen = 0;
		private string _quanHuyen = string.Empty;
        private int _maTinhThanh = 0;
		private string _tinhTP = string.Empty;
        private int _maQuocGia = 0;
		private string _quocGia = string.Empty;
		private long _maNhanVien = 0;
		private int _maDiaChi = 0;
		private int _maChiTiet = 0;
        private bool _active = false;
        private bool _TamTru = false;

		public string TenDiaChi
		{
			get
			{
				CanReadProperty("TenDiaChi", true);
				return _tenDiaChi;
			}
			set
			{
				CanWriteProperty("TenDiaChi", true);
				if (value == null) value = string.Empty;
				if (!_tenDiaChi.Equals(value))
				{
					_tenDiaChi = value;
					PropertyHasChanged("TenDiaChi");
				}
			}
		}

        public int MaQuanHuyen
        {
            get
            {
                CanReadProperty("MaQuanHuyen", true);
                return _maQuanHuyen;
            }
            set
            {
                CanWriteProperty("MaQuanHuyen", true);
                if (!_maQuanHuyen.Equals(value))
                {
                    _maQuanHuyen = value;
                    PropertyHasChanged("MaQuanHuyen");
                }
            }
        }

		public string QuanHuyen
		{
			get
			{
				CanReadProperty("QuanHuyen", true);
                if (_maQuanHuyen != 0)
                {
                    _quanHuyen = ERP_Library.QuanHuyen.GetQuanHuyen(_maQuanHuyen).TenQuanHuyen;
                }
				return _quanHuyen;
			}
			set
			{
				CanWriteProperty("QuanHuyen", true);
				if (value == null) value = string.Empty;
				if (!_quanHuyen.Equals(value))
				{
					_quanHuyen = value;
					PropertyHasChanged("QuanHuyen");
				}
			}
		}

        public int MaTinhThanh
        {
            get
            {
                CanReadProperty("MaTinhThanh", true);
                if (_maQuanHuyen != 0)
                {
                    _maTinhThanh = ERP_Library.QuanHuyen.GetQuanHuyen(_maQuanHuyen).MaTinhThanh;
                }
                return _maTinhThanh;
            }
            set
            {
                CanWriteProperty("MaTinhThanh", true);
                if (!_maTinhThanh.Equals(value))
                {
                    _maTinhThanh = value;
                    PropertyHasChanged("MaTinhThanh");
                }
            }
        }

		public string TinhTP
		{
			get
			{
				CanReadProperty("TinhTP", true);
                if (MaTinhThanh != 0)
                {
                    _tinhTP = TinhThanh.GetTinhThanh(MaTinhThanh).TenTinhThanh;
                }
                return _tinhTP;
			}
			set
			{
				CanWriteProperty("TinhTP", true);
				if (value == null) value = string.Empty;
				if (!_tinhTP.Equals(value))
				{
					_tinhTP = value;
					PropertyHasChanged("TinhTP");
				}
			}
		}

        public int MaQuocGia
        {
            get
            {
                CanReadProperty("MaQuocGia", true);
                if (_maQuanHuyen!=0)
                {
                    _maQuocGia = TinhThanh.GetTinhThanh(ERP_Library.QuanHuyen.GetQuanHuyen(_maQuanHuyen).MaTinhThanh).MaQuocGia;
                }
                return _maQuocGia;
            }
            set
            {
                CanWriteProperty("MaQuocGia", true);
                if (!_maQuocGia.Equals(value))
                {
                    _maQuocGia = value;
                    PropertyHasChanged("MaQuocGia");
                }
            }
        }

		public string QuocGia
		{
			get
			{
				CanReadProperty("QuocGia", true);
                if (MaQuocGia != 0)
                {
                    _quocGia = ERP_Library.QuocGia.GetQuocGia(_maQuocGia).TenQuocGia;
                }
                return _quocGia;
			}
			set
			{
				CanWriteProperty("QuocGia", true);
				if (value == null) value = string.Empty;
				if (!_quocGia.Equals(value))
				{
					_quocGia = value;
					PropertyHasChanged("QuocGia");
				}
			}
		}

		public long MaNhanVien
		{
			get
			{
				CanReadProperty("MaNhanVien", true);
				return _maNhanVien;
			}
			set
			{
				CanWriteProperty("MaNhanVien", true);
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public int MaDiaChi
		{
			get
			{
				CanReadProperty("MaDiaChi", true);
				return _maDiaChi;
			}
			set
			{
				CanWriteProperty("MaDiaChi", true);
				if (!_maDiaChi.Equals(value))
				{
					_maDiaChi = value;
					PropertyHasChanged("MaDiaChi");
				}
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
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

        public bool TamTru
        {
            get
            {
                CanReadProperty("TramTru", true);
                return _TamTru;
            }
            set
            {
                CanWriteProperty("TramTru", true);
                if (!_TamTru.Equals(value))
                {
                    _TamTru = value;
                    PropertyHasChanged("TramTru");
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
			// TenDiaChi
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "TenDiaChi");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDiaChi", 500));
            ////
            //// QuanHuyen
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "QuanHuyen");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("QuanHuyen", 50));
            ////
            //// TinhTP
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "TinhTP");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TinhTP", 50));
            ////
            //// QuocGia
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "QuocGia");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("QuocGia", 50));
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
			//TODO: Define authorization rules in DiaChi_NhanVien
			//AuthorizationRules.AllowRead("TenDiaChi", "DiaChi_NhanVienReadGroup");
			//AuthorizationRules.AllowRead("QuanHuyen", "DiaChi_NhanVienReadGroup");
			//AuthorizationRules.AllowRead("TinhTP", "DiaChi_NhanVienReadGroup");
			//AuthorizationRules.AllowRead("QuocGia", "DiaChi_NhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "DiaChi_NhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaDiaChi", "DiaChi_NhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaChiTiet", "DiaChi_NhanVienReadGroup");
            //AuthorizationRules.AllowRead("Active", "DiaChi_NhanVienReadGroup");

			//AuthorizationRules.AllowWrite("TenDiaChi", "DiaChi_NhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("QuanHuyen", "DiaChi_NhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TinhTP", "DiaChi_NhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("QuocGia", "DiaChi_NhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "DiaChi_NhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaDiaChi", "DiaChi_NhanVienWriteGroup");
            //AuthorizationRules.AllowWrite("Active", "DiaChi_NhanVienWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
        
        public static DiaChi_NhanVien NewDiaChi_NhanVien()
        {
            return new DiaChi_NhanVien();
        }

		public static DiaChi_NhanVien NewDiaChi_NhanVien(long maNhanVien)
        {
            DiaChi_NhanVien _DiaChi_NhanVien = new DiaChi_NhanVien();
            _DiaChi_NhanVien.MaNhanVien = maNhanVien;
            return _DiaChi_NhanVien;
        }

		public static DiaChi_NhanVien GetDiaChi_NhanVien(SafeDataReader dr)
		{
			return new DiaChi_NhanVien(dr);
		}

		private DiaChi_NhanVien()
		{			
			//ValidationRules.CheckRules();
			MarkAsChild();
		}

		private DiaChi_NhanVien(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods

		#region Data Access

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
            _tenDiaChi = dr.GetString("TenDiaChi");
            _maQuanHuyen = dr.GetInt32("MaQuanHuyen");
            _quanHuyen = dr.GetString("QuanHuyen");
            _maTinhThanh = dr.GetInt32("MaTinhThanh");
            _tinhTP = dr.GetString("TinhTP");
            _maQuocGia = dr.GetInt32("MaQuocGia");
            _quocGia = dr.GetString("QuocGia");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maDiaChi = dr.GetInt32("MaDiaChi");
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _active = dr.GetBoolean("Active");
            _TamTru = dr.GetBoolean("TamTru");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, NhanVien parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, NhanVien parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblDiaChi_NhanVien";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
                _maDiaChi = (int)cm.Parameters["@MaDiaChi"].Value;

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@TenDiaChi", _tenDiaChi);
            cm.Parameters.AddWithValue("@MaQuanHuyen", _maQuanHuyen);
			cm.Parameters.AddWithValue("@QuanHuyen", _quanHuyen);
            cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
			cm.Parameters.AddWithValue("@TinhTP", _tinhTP);
            cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
			cm.Parameters.AddWithValue("@QuocGia", _quocGia);
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
            cm.Parameters.AddWithValue("@MaDiaChi", _maDiaChi);
            cm.Parameters["@MaDiaChi"].Direction = ParameterDirection.Output;

            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;

            if (_active != false)
                cm.Parameters.AddWithValue("@Active", _active);
            else
                cm.Parameters.AddWithValue("@Active", false);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, NhanVien parent)
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

		private void ExecuteUpdate(SqlTransaction tr, NhanVien parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDiaChi_NhanVien";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
			cm.Parameters.AddWithValue("@TenDiaChi", _tenDiaChi);
            cm.Parameters.AddWithValue("@MaQuanHuyen", _maQuanHuyen);
            cm.Parameters.AddWithValue("@QuanHuyen", _quanHuyen);
            cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
            cm.Parameters.AddWithValue("@TinhTP", _tinhTP);
            cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            cm.Parameters.AddWithValue("@QuocGia", _quocGia);
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			cm.Parameters.AddWithValue("@MaDiaChi", _maDiaChi);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_active != false)
                cm.Parameters.AddWithValue("@Active", _active);
            else
                cm.Parameters.AddWithValue("@Active", false);
            if (_TamTru != false)
                cm.Parameters.AddWithValue("@TamTru", _TamTru);
            else
                cm.Parameters.AddWithValue("@TamTru", false);
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
                cm.CommandText = "spd_DeletetblDiaChi_NhanVien";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
