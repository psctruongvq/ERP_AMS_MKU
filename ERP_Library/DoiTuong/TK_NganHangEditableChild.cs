
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
    //fixm-long
	[Serializable()] 
	public class TK_NganHang : Csla.BusinessBase<TK_NganHang>

	{
		#region Business Properties and Methods

		//declare members
		private int _maTKNganHang = 0;
		private string _soTK = string.Empty;
		private int _maNganHang = 0;
		private long _maDoiTac = 0;
        private int _maTinhThanh = 0;
        private string _tenNganHang = string.Empty;

        private  ThongTinNganHangChildList _thongTinNganHangChildList = ThongTinNganHangChildList.NewThongTinNganHangChildList();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTKNganHang
		{
			get
			{
				CanReadProperty("MaTKNganHang", true);
				return _maTKNganHang;
			}
		}

		public string SoTK
		{
			get
			{
				CanReadProperty("SoTK", true);
				return _soTK;
			}
			set
			{
				CanWriteProperty("SoTK", true);
				if (value == null) value = string.Empty;
				if (!_soTK.Equals(value))
				{
					_soTK = value;
					PropertyHasChanged("SoTK");
				}
			}
		}

        public string TenNganHang
        {
            get
            {
                CanReadProperty("TenNganHang", true);
                return _tenNganHang;
            }
            set
            {
                CanWriteProperty("TenNganHang", true);
                if (value == null) value = string.Empty;
                if (!_tenNganHang.Equals(value))
                {
                    _tenNganHang = value;
                    PropertyHasChanged("TenNganHang");
                }
            }
        }

        public string TenNhomNganHang
        {
            get
            {
                CanReadProperty("TenNhomNganHang", true);
                return NhomNganHang.GetNhomNganHang(Convert.ToInt64(MaNganHang)).TenNhomNganHang;
            }
        }

        //Mã Nhóm Ngân Hàng
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

		public long MaDoiTac
		{
			get
			{
				CanReadProperty("MaDoiTac", true);
				return _maDoiTac;
			}
			set
			{
				CanWriteProperty("MaDoiTac", true);
				if (!_maDoiTac.Equals(value))
				{
					_maDoiTac = value;
					PropertyHasChanged("MaDoiTac");
				}
			}
		}

        public int MaTinhThanh
        {
            get
            {
                CanReadProperty("MaTinhThanh", true);
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

        public ThongTinNganHangChildList ThongTinNganHangList
        {
            get
            {
                CanReadProperty("ThongTinNganHangList", true);
                return _thongTinNganHangChildList;
            }
            set
            {
                CanWriteProperty("ThongTinNganHangList", true);
                if (!_thongTinNganHangChildList.Equals(value))
                {
                    _thongTinNganHangChildList = value;
                    PropertyHasChanged("ThongTinNganHangList");
                }
            }
        }

        public string ThongTinKhac
        {
            get
            {
                CanReadProperty("ThongTinKhac", true);
                string Chuoi = string.Empty;
                if (_thongTinNganHangChildList.Count > 0)
                    Chuoi += _thongTinNganHangChildList[0].DiaChi + "...";
                return Chuoi;
            }
        }
 
		protected override object GetIdValue()
		{
			return _maTKNganHang;
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
			// SoTK
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "SoTK");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTK", 20));
			//
			// TenNganHang
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "TenNganHang");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNganHang", 500));
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
			//TODO: Define authorization rules in TK_NganHang
			//AuthorizationRules.AllowRead("MaTKNganHang", "TK_NganHangReadGroup");
			//AuthorizationRules.AllowRead("SoTK", "TK_NganHangReadGroup");
			//AuthorizationRules.AllowRead("TenNganHang", "TK_NganHangReadGroup");
			//AuthorizationRules.AllowRead("MaDoiTac", "TK_NganHangReadGroup");

			//AuthorizationRules.AllowWrite("SoTK", "TK_NganHangWriteGroup");
			//AuthorizationRules.AllowWrite("TenNganHang", "TK_NganHangWriteGroup");
			//AuthorizationRules.AllowWrite("MaDoiTac", "TK_NganHangWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods

        private TK_NganHang(int maTK, int maNganHang)
        {
            this._maTKNganHang = maTK;
            this._maNganHang = maNganHang;
            MarkAsChild();
        }

        private TK_NganHang(string TenNganHang)
        {
            this._tenNganHang = TenNganHang;
            this._soTK = string.Empty;
            MarkAsChild();
        }

        public static TK_NganHang NewTK_NganHang(int _maTK, int _maNganHang)
        {
            return new TK_NganHang(_maTK, _maNganHang);
        }

        public static TK_NganHang NewTK_NganHang(string tenNganHang)
        {
            return new TK_NganHang(tenNganHang);
        }

		public static TK_NganHang NewTK_NganHang()
		{
			return new TK_NganHang();
		}

		public static TK_NganHang GetTK_NganHang(SafeDataReader dr)
		{
			return new TK_NganHang(dr);
		}

        public static TK_NganHang GetTK_NganHangByMaTKNgaHang(int maTKNganHang)
        {
            TK_NganHang tk = new TK_NganHang();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTK_NganHangByMaTKNganHang";
                    cm.Parameters.AddWithValue("@MaTKNganHang", maTKNganHang);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            tk._maTKNganHang = dr.GetInt32("MaTKNganHang");
                            tk._soTK = dr.GetString("SoTK");
                            tk._tenNganHang = dr.GetString("TenNganHang");
                            tk._maNganHang = dr.GetInt32("MaNganHang");
                            tk._maDoiTac = dr.GetInt64("MaDoiTac");
                            tk._maTinhThanh = dr.GetInt32("MaTinhThanh");
                        }

                    }
                }
            }
            return tk;

        }

		public TK_NganHang()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		public TK_NganHang(SafeDataReader dr)
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
			_maTKNganHang = dr.GetInt32("MaTKNganHang");
			_soTK = dr.GetString("SoTK");
            _tenNganHang = dr.GetString("TenNganHang");
            _maNganHang = dr.GetInt32("MaNganHang");
			_maDoiTac = dr.GetInt64("MaDoiTac");
            _maTinhThanh = dr.GetInt32("MaTinhThanh");
		}

		private void FetchChildren(SafeDataReader dr)
		{
            _thongTinNganHangChildList = ThongTinNganHangChildList.GetChungTu_GiayBanNgoaiTeChildList(_maTKNganHang);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, DoiTac parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, DoiTac parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblTK_NganHang";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maTKNganHang = (int)cm.Parameters["@MaTKNganHang"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DoiTac parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@SoTK", _soTK);
            cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
			cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
			cm.Parameters.AddWithValue("@MaDoiTac", parent.MaDoiTac);
			cm.Parameters.AddWithValue("@MaTKNganHang", _maTKNganHang);
            cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
			cm.Parameters["@MaTKNganHang"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, DoiTac parent)
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

		private void ExecuteUpdate(SqlTransaction tr, DoiTac parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblTK_NganHang";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DoiTac parent)
		{
			cm.Parameters.AddWithValue("@MaTKNganHang", _maTKNganHang);
			cm.Parameters.AddWithValue("@SoTK", _soTK);
            cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
            cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
			cm.Parameters.AddWithValue("@MaDoiTac", parent.MaDoiTac);
            cm.Parameters.AddWithValue("@maTinhThanh", _maTinhThanh);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
            _thongTinNganHangChildList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

            _thongTinNganHangChildList.DataPortal_Delete(tr);

			ExecuteDelete(tr);
			MarkNew();
		}

		private void ExecuteDelete(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblTK_NganHang";

				cm.Parameters.AddWithValue("@MaTKNganHang", this._maTKNganHang);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access

        public static string GetSoTaiKhoan(int MaDoiTac, int MaNganHang)
        {
            string strSoTaiKhoan = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayTaiKhoanDoiTac";

                    cm.Parameters.AddWithValue("@MaDoiTac", MaDoiTac);
                    cm.Parameters.AddWithValue("@MaNganHang", MaNganHang);

                    strSoTaiKhoan = Convert.ToString(cm.ExecuteScalar());
                }//using
                cn.Close();
            }
            return strSoTaiKhoan;
        }
	}
}
