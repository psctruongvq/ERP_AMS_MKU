
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HoSoLuong : Csla.BusinessBase<HoSoLuong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maHeSoLuong = 0;
		private long _maNhanVien = 0;
		private SmartDate _ngayBatDau = new SmartDate(DateTime.Today);
		private SmartDate _ngayKetThuc = new SmartDate(DateTime.Today);
		private int _maNgachLuongCB = 0;
        private string _maQLNgachLuongCB = string.Empty;        
		private int _maBacLuongCB = 0;
        private string _maQLBacLuongCB = string.Empty;
		private int _maNgachLuongKD = 0;
		private int _maBacLuongKD = 0;
		private decimal _heSoLuongCB = 0;
		private decimal _heSoLuongKD = 0;
        private string _tenNhanVien = string.Empty;
        private string _MaQlNhanVien = string.Empty;
        private SmartDate _NgayVaoNganh = new SmartDate(DateTime.Today);
        private string _tenchucvu = string.Empty;
        private bool _chon = true;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaHeSoLuong
		{
			get
			{
				CanReadProperty("MaHeSoLuong", true);
				return _maHeSoLuong;
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

        public string TenNhanVien
        {
            get
            {
                CanReadProperty(true);
                return _tenNhanVien;
            }
        }

		public DateTime NgayBatDau
		{
			get
			{
				CanReadProperty("NgayBatDau", true);
				return _ngayBatDau.Date;
			}
            set
            {
                CanWriteProperty("NgayBatDau", true);
                if (!_ngayBatDau.Equals(value))
                {
                    _ngayBatDau = new SmartDate(value);
                    PropertyHasChanged("NgayBatDau");
                }
            }
		}

		public DateTime NgayKetThuc
		{
			get
			{
				CanReadProperty("NgayKetThuc", true);
				return _ngayKetThuc.Date;
			}
            set
            {
                CanWriteProperty("NgayKetThuc", true);
                if (!_ngayBatDau.Equals(value))
                {
                    _ngayBatDau = new SmartDate(value);
                    PropertyHasChanged("NgayKetThuc");
                }
            }
		}

        public DateTime NgayVaoNganh
        {
            get
            {
                CanReadProperty( true);
                return _NgayVaoNganh.Date;
            }          
        }

		public int MaNgachLuongCB
		{
			get
			{
				CanReadProperty("MaNgachLuongCB", true);
				return _maNgachLuongCB;
			}
			set
			{
				CanWriteProperty("MaNgachLuongCB", true);
				if (!_maNgachLuongCB.Equals(value))
				{
					_maNgachLuongCB = value;
					PropertyHasChanged("MaNgachLuongCB");
				}
			}
		}

		public int MaBacLuongCB
		{
			get
			{
				CanReadProperty("MaBacLuongCB", true);
				return _maBacLuongCB;
			}
			set
			{
				CanWriteProperty("MaBacLuongCB", true);
				if (!_maBacLuongCB.Equals(value))
				{
					_maBacLuongCB = value;
					PropertyHasChanged("MaBacLuongCB");
				}
			}
		}

		public int MaNgachLuongKD
		{
			get
			{
				CanReadProperty("MaNgachLuongKD", true);
				return _maNgachLuongKD;
			}
			set
			{
				CanWriteProperty("MaNgachLuongKD", true);
				if (!_maNgachLuongKD.Equals(value))
				{
					_maNgachLuongKD = value;
					PropertyHasChanged("MaNgachLuongKD");
				}
			}
		}

		public int MaBacLuongKD
		{
			get
			{
				CanReadProperty("MaBacLuongKD", true);
				return _maBacLuongKD;
			}
			set
			{
				CanWriteProperty("MaBacLuongKD", true);
				if (!_maBacLuongKD.Equals(value))
				{
					_maBacLuongKD = value;
					PropertyHasChanged("MaBacLuongKD");
				}
			}
		}

		public decimal HeSoLuongCB
		{
			get
			{
				CanReadProperty("HeSoLuongCB", true);
                if (_maBacLuongCB != 0)
                {
                    _heSoLuongCB = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongCB).HeSoLuong;
                }
                return _heSoLuongCB;
			}
			set
			{
				CanWriteProperty("HeSoLuongCB", true);
				if (!_heSoLuongCB.Equals(value))
				{
                    if (_maBacLuongCB != 0)
                    {
                        _heSoLuongCB = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongCB).HeSoLuong;
                    }
                    else
                        _heSoLuongCB = value;
					PropertyHasChanged("HeSoLuongCB");
				}
			}
		}

        public string MaQLNgachLuongCB
        {
            get
            {
                CanReadProperty(true);
                return _maQLNgachLuongCB;
            }
        }

        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty(true);
                return _MaQlNhanVien;
            }
        }

        public string Tenchucvu
        {
            get
            {
                CanReadProperty(true);
                return _tenchucvu;
            }
        }

        public string MaQlBacLuongCB
        {
            get
            {
                CanReadProperty(true);
                return _maQLBacLuongCB;
            }
        }

        public Boolean Chon
        {
            get
            {
                CanReadProperty(true);
                return _chon;
            }
            set
            {
                CanWriteProperty(true);
                if (!_chon.Equals(value))
                {
                    _chon = value;
                    PropertyHasChanged();
                }
            }
        }

		public decimal HeSoLuongKD
		{
			get
			{
				CanReadProperty("HeSoLuongKD", true);
                if (_maBacLuongKD != 0)
                {
                   // _heSoLuongKD = BacLuongKinhDoanh.GetBacLuongKinhDoanh(_maBacLuongKD).HeSoLuong;
                }
                return _heSoLuongKD;
			}
			set
			{
				CanWriteProperty("HeSoLuongKD", true);
				if (!_heSoLuongKD.Equals(value))
				{
                    if (_maBacLuongKD != 0)
                    {
                        //_heSoLuongKD = BacLuongKinhDoanh.GetBacLuongKinhDoanh(_maBacLuongKD).HeSoLuong;
                    }
                    else
                        _heSoLuongKD = value;        
					PropertyHasChanged("HeSoLuongKD");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maHeSoLuong;
		}

		#endregion //Business Properties and Methods
                                                                                                                                                                   
		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{

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
			//TODO: Define authorization rules in HoSoLuong
			//AuthorizationRules.AllowRead("MaHeSoLuong", "HoSoLuongReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "HoSoLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayBatDau", "HoSoLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayBatDauString", "HoSoLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayKetThuc", "HoSoLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayKetThucString", "HoSoLuongReadGroup");
			//AuthorizationRules.AllowRead("MaNgachLuongCB", "HoSoLuongReadGroup");
			//AuthorizationRules.AllowRead("MaBacLuongCB", "HoSoLuongReadGroup");
			//AuthorizationRules.AllowRead("MaNgachLuongKD", "HoSoLuongReadGroup");
			//AuthorizationRules.AllowRead("MaBacLuongKD", "HoSoLuongReadGroup");
			//AuthorizationRules.AllowRead("HeSoLuongCB", "HoSoLuongReadGroup");
			//AuthorizationRules.AllowRead("HeSoLuongKD", "HoSoLuongReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "HoSoLuongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayBatDauString", "HoSoLuongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKetThucString", "HoSoLuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaNgachLuongCB", "HoSoLuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaBacLuongCB", "HoSoLuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaNgachLuongKD", "HoSoLuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaBacLuongKD", "HoSoLuongWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoLuongCB", "HoSoLuongWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoLuongKD", "HoSoLuongWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static HoSoLuong NewHoSoLuong()
		{
			return new HoSoLuong();
		}

        public static HoSoLuong NewHoSoLuong(long maNhanVien)
        {
            HoSoLuong _HoSoLuong = new HoSoLuong();
            _HoSoLuong.MaNhanVien = maNhanVien;
            return _HoSoLuong;
        }

        public static HoSoLuong GetHoSoLuong(SafeDataReader dr)
        {
            return new HoSoLuong(dr);
        }

		private HoSoLuong()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private HoSoLuong(SafeDataReader dr)
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
            _maHeSoLuong = dr.GetInt32("MaHeSoLuong");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _ngayBatDau = dr.GetSmartDate("NgayBatDau", _ngayBatDau.EmptyIsMin);
            _ngayKetThuc = dr.GetSmartDate("NgayKetThuc", _ngayKetThuc.EmptyIsMin);
            _maNgachLuongCB = dr.GetInt32("MaNgachLuongCB");
            _maQLNgachLuongCB = dr.GetString("MaQLNgachLuongCB");
            _maBacLuongCB = dr.GetInt32("MaBacLuongCB");
            _maQLBacLuongCB = dr.GetString("maQLBacluongCB");
            _maNgachLuongKD = dr.GetInt32("MaNgachLuongKD");
            _maBacLuongKD = dr.GetInt32("MaBacLuongKD");
            _heSoLuongCB = dr.GetDecimal("HeSoLuongCB");
            _heSoLuongKD = dr.GetDecimal("HeSoLuongKD");
            _MaQlNhanVien = dr.GetString("MaQlNhanVien");
            _tenNhanVien = dr.GetString("Tennhanvien");
            _tenchucvu = dr.GetString("Tenchucvu");
            _NgayVaoNganh = dr.GetSmartDate("NgayVaoNganh",_NgayVaoNganh.EmptyIsMin);
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

        #region Insert_Them
        public void Insert(NhanVien parent)
        {

            if (!IsDirty) return;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                ExecuteInsert(parent);
                MarkOld();
            }
            //update child object(s)
            //UpdateChildren(cn);
        }

        private void ExecuteInsert(NhanVien parent)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblnsHoSoLuong";

                    AddInsertParameters(cm, parent);

                    cm.ExecuteNonQuery();

                    _maHeSoLuong = (int)cm.Parameters["@MaHeSoLuong"].Value;
                }//using
            }
        }
        #endregion

		#region Data Access - Insert
        internal void Insert(SqlTransaction cn, NhanVien parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			//UpdateChildren(cn);
		}

        private void ExecuteInsert(SqlTransaction cn, NhanVien parent)
		{
            using (SqlCommand cm = cn.Connection.CreateCommand())
			{
                cm.Transaction = cn;    
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsHoSoLuong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maHeSoLuong = (int)cm.Parameters["@MaHeSoLuong"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau.DBValue);
			cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
            if(_maNgachLuongCB!=0)
			    cm.Parameters.AddWithValue("@MaNgachLuongCB", _maNgachLuongCB);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongCB", DBNull.Value);
            if(_maBacLuongCB!=0)
			    cm.Parameters.AddWithValue("@MaBacLuongCB", _maBacLuongCB);
            else
                cm.Parameters.AddWithValue("@MaBacLuongCB", DBNull.Value);
            if(_maNgachLuongKD!=0)
			    cm.Parameters.AddWithValue("@MaNgachLuongKD", _maNgachLuongKD);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongKD", DBNull.Value);
            if(_maBacLuongKD!=0)
	    		cm.Parameters.AddWithValue("@MaBacLuongKD", _maBacLuongKD);
            else
                cm.Parameters.AddWithValue("@MaBacLuongKD", DBNull.Value);
			cm.Parameters.AddWithValue("@HeSoLuongCB", _heSoLuongCB);// _heSoLuongCB);
			cm.Parameters.AddWithValue("@HeSoLuongKD", -_heSoLuongKD);// _heSoLuongKD);
			cm.Parameters.AddWithValue("@MaHeSoLuong", _maHeSoLuong);
			cm.Parameters["@MaHeSoLuong"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

        #region Update_Them
        public void Update(NhanVien parent)
        {
            if (!IsDirty) return;
            if (base.IsDirty)
            {
                ExecuteUpdate(parent);
                MarkOld();
            }

            //update child object(s)
            //UpdateChildren(cn);
        }

        private void ExecuteUpdate(NhanVien parent)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdatetblnsHoSoLuong";

                    AddUpdateParameters(cm, parent);

                    cm.ExecuteNonQuery();

                }//using
            }
        }
        #endregion

        #region Data Access - Update
        internal void Update(SqlTransaction cn, NhanVien parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn, parent);
				MarkOld();
			}

			//update child object(s)
			//UpdateChildren(cn);
		}

        private void ExecuteUpdate(SqlTransaction cn, NhanVien parent)
		{
            
            using (SqlCommand cm = cn.Connection.CreateCommand())
			{
                cm.Transaction = cn;  
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsHoSoLuong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
			cm.Parameters.AddWithValue("@MaHeSoLuong", _maHeSoLuong);
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau.DBValue);
			cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
            if (_maNgachLuongCB != 0)
                cm.Parameters.AddWithValue("@MaNgachLuongCB", _maNgachLuongCB);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongCB", DBNull.Value);
            if (_maBacLuongCB != 0)
                cm.Parameters.AddWithValue("@MaBacLuongCB", _maBacLuongCB);
            else
                cm.Parameters.AddWithValue("@MaBacLuongCB", DBNull.Value);
            if (_maNgachLuongKD != 0)
                cm.Parameters.AddWithValue("@MaNgachLuongKD", _maNgachLuongKD);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongKD", DBNull.Value);
            if (_maBacLuongKD != 0)
                cm.Parameters.AddWithValue("@MaBacLuongKD", _maBacLuongKD);
            else
                cm.Parameters.AddWithValue("@MaBacLuongKD", DBNull.Value);
			cm.Parameters.AddWithValue("@HeSoLuongCB", _heSoLuongCB);
			cm.Parameters.AddWithValue("@HeSoLuongKD", _heSoLuongKD);
		}

		private void UpdateChildren(SqlConnection cn)
		{
		}
		#endregion //Data Access - Update

        #region Delete
        internal void DeleteSelf(SqlTransaction cn)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(cn);
            MarkNew();
        }

        private void ExecuteDelete(SqlTransaction cn)
        {
            using (SqlCommand cm = cn.Connection.CreateCommand())
            {
                cm.Transaction = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsHoSoLuong";

                cm.Parameters.AddWithValue("@MaHeSoLuong", this._maHeSoLuong);

                cm.ExecuteNonQuery();
            }//using
            
        }
        #endregion

		#region Delete_Them
        public void DeleteSelf()
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete();
			MarkNew();
		}

        private void ExecuteDelete()
		{
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DeletetblnsHoSoLuong";

                    cm.Parameters.AddWithValue("@MaHeSoLuong", this._maHeSoLuong);

                    cm.ExecuteNonQuery();
                }//using
            }
        }
        #endregion

        public static void TaoDanhsach()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    try
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_tblnsHoSoLuongTaoDanhSach";
                        cm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {

                    }
                }
            }
        }
        public static void NangBac(long manhanvien, string denngay)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    try
                    {

                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_tblnsHoSoLuongNangBac";
                        cm.Parameters.AddWithValue("@manhanvien", manhanvien);
                        cm.Parameters.AddWithValue("@Denngay", denngay);
                        cm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {

                    }
                }
            }
        }
        #endregion //Data Access
    }
}
