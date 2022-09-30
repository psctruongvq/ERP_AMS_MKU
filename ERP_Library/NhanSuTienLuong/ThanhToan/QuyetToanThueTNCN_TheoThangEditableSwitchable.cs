
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuyetToanThueTNCN_TheoThang : Csla.BusinessBase<QuyetToanThueTNCN_TheoThang>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChiTiet = 0;
		private int _maKyQuyetToan = 0;
		private int _thang = 0;
		private int _nam = 0;
		private long _maNhanVien = 0;
		private decimal _tongThuNhap = 0;
		private decimal _tongThuNhapChiuThue = 0;
		private decimal _tongGiamTru = 0;
		private decimal _tongTienThue = 0;
		private decimal _daNop = 0;
		private decimal _conPhaiNop = 0;
        
        private decimal _bhxh = 0;
        private decimal _bhyt = 0;
        private decimal _bhtn = 0;
 
        private string _tenNhanVien = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _cmnd = string.Empty;
        private string _mst = string.Empty;
        private bool _tinhTrang = false;
        private decimal _tncnDongBoSung = 0;
        private bool _daNopBoSung = false;
        private bool _tuQuyetToan = false;
        private int _soThang = 0;
        private decimal _thueNLDNopThem = 0;
        private decimal _thueNLDTraLai = 0;

        private int _SoNguoiPhuThuoc = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public int MaKyQuyetToan
		{
			get
			{
				CanReadProperty("MaKyQuyetToan", true);
				return _maKyQuyetToan;
			}
			set
			{
				CanWriteProperty("MaKyQuyetToan", true);
				if (!_maKyQuyetToan.Equals(value))
				{
					_maKyQuyetToan = value;
					PropertyHasChanged("MaKyQuyetToan");
				}
			}
		}

		public int Thang
		{
			get
			{
				CanReadProperty("Thang", true);
				return _thang;
			}
			set
			{
				CanWriteProperty("Thang", true);
				if (!_thang.Equals(value))
				{
					_thang = value;
					PropertyHasChanged("Thang");
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

		public decimal TongThuNhap
		{
			get
			{
				CanReadProperty("TongThuNhap", true);
				return _tongThuNhap;
			}
			set
			{
				CanWriteProperty("TongThuNhap", true);
				if (!_tongThuNhap.Equals(value))
				{
					_tongThuNhap = value;
					PropertyHasChanged("TongThuNhap");
				}
			}
		}

		public decimal TongThuNhapChiuThue
		{
			get
			{
				CanReadProperty("TongThuNhapChiuThue", true);
				return _tongThuNhapChiuThue;
			}
			set
			{
				CanWriteProperty("TongThuNhapChiuThue", true);
				if (!_tongThuNhapChiuThue.Equals(value))
				{
					_tongThuNhapChiuThue = value;
					PropertyHasChanged("TongThuNhapChiuThue");
				}
			}
		}

		public decimal TongGiamTru
		{
			get
			{
				CanReadProperty("TongGiamTru", true);
				return _tongGiamTru;
			}
			set
			{
				CanWriteProperty("TongGiamTru", true);
				if (!_tongGiamTru.Equals(value))
				{
					_tongGiamTru = value;
					PropertyHasChanged("TongGiamTru");
				}
			}
		}

		public decimal TongTienThue
		{
			get
			{
				CanReadProperty("TongTienThue", true);
				return _tongTienThue;
			}
			set
			{
				CanWriteProperty("TongTienThue", true);
				if (!_tongTienThue.Equals(value))
				{
					_tongTienThue = value;
					PropertyHasChanged("TongTienThue");
				}
			}
		}

		public decimal DaNop
		{
			get
			{
				CanReadProperty("DaNop", true);
				return _daNop;
			}
			set
			{
				CanWriteProperty("DaNop", true);
				if (!_daNop.Equals(value))
				{
					_daNop = value;
					PropertyHasChanged("DaNop");
				}
			}
		}

		public decimal ConPhaiNop
		{
            get
            {
                CanReadProperty("ConPhaiNop", true);
                //if (_tuQuyetToan == true)
                //{
                //    _conPhaiNop = _tongTienThue - _daNop;

                //}
                //else
                //{
                //    _conPhaiNop = 0;
                //}
                return _conPhaiNop;
                //_tongTienThue - _daNop;
            }
		}

        public decimal BHXH
        {
            get
            {
                CanReadProperty("BHXH", true);
                return _bhxh;
            }
        }

        public decimal BHYT
        {
            get
            {
                CanReadProperty("BHYT", true);
                return _bhyt;
            }
        }

        public decimal BHTN
        {
            get
            {
                CanReadProperty("BHTN", true);
                return _bhtn;
            }
            
        }

        public decimal BHBatBuoc
        {
            get
            {
                CanReadProperty("BHBatBuoc", true);
                return _bhtn + _bhxh + _bhyt;
            }

        }
        decimal ConPhaiNopNew = 0;
        public decimal ConPhaiNop_SuDung
        {
            get
            {
                CanReadProperty("ConPhaiNop_SuDung", true);
                if (_tuQuyetToan == true)
                {
                    _conPhaiNop = _tongTienThue - _daNop;
                    ConPhaiNopNew = _tongTienThue - _daNop;

                }
                else
                {
                    _conPhaiNop = 0;
                    ConPhaiNopNew = 0;
                }
                return ConPhaiNopNew;
                    //_tongTienThue - _daNop;
            }
        }

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return _tenNhanVien;
            }
        }

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }
        }

        public string CMND
        {
            get
            {
                CanReadProperty("CMND", true);
                return _cmnd;
            }
        }

        public string MST
        {
            get
            {
                CanReadProperty("MST", true);
                return _mst;
            }
        }

        public bool TinhTrang
        {
            get
            {
                CanReadProperty("TinhTrang", true);
                return _tinhTrang;
            }
        }

        public decimal TNCNDongBoSung
        {
            get
            {
                CanReadProperty("TNCNDongBoSung", true);
                return _tncnDongBoSung;
            }
            set
            {
                CanWriteProperty("TNCNDongBoSung", true);
                if (!_tncnDongBoSung.Equals(value))
                {
                    _tncnDongBoSung = value;
                    PropertyHasChanged("TNCNDongBoSung");
                }
            }
        }

        public bool DaNopBoSung
        {
            get
            {
                CanReadProperty("DaNopBoSung", true);
                return _daNopBoSung;
            }
            set
            {
                CanWriteProperty("DaNopBoSung", true);
                if (!_daNopBoSung.Equals(value))
                {
                    _daNopBoSung = value;
                    PropertyHasChanged("DaNopBoSung");
                }
            }
        }

        public bool TuQuyetToan
        {
            get
            {
                CanReadProperty("TuQuetToan", true);
                return _tuQuyetToan;
            }
            set
            {
                CanWriteProperty("TuQuetToan", true);
                if (!_tuQuyetToan.Equals(value))
                {
                    _tuQuyetToan = value;
                    PropertyHasChanged("TuQuetToan");
                }
            }
        }

        public int SoThang
        {
            get
            {
                CanReadProperty("SoThang", true);
                return _soThang;
            }
            set
            {
                CanWriteProperty("SoThang", true);
                if (!_soThang.Equals(value))
                {
                    _soThang = value;
                    PropertyHasChanged("SoThang");
                }
            }
        }

        public decimal ThueNLDNopThem
        {
            get
            {
                CanReadProperty("ThueNLDNopThem", true);
                //if (_tuQuyetToan==true)
                //{
                //    if (_conPhaiNop>=0)
                //        _thueNLDNopThem = _tongTienThue- _daNop ;
                //}
                //else
                //{
                //    _thueNLDNopThem = 0;
                //}
                return _thueNLDNopThem;
            }
           
        }
        public decimal ThueNLDTraLai
        {
            get
            {
                CanReadProperty("ThueNLDTraLai", true);
                //if (_conPhaiNop < 0)
                //{
                //    _thueNLDTraLai = Math.Abs(_tongTienThue -_daNop);
                //}
                //else
                //{
                //    _thueNLDTraLai = 0;
                //}
                return _thueNLDTraLai;
            }
            //set
            //{
            //    CanWriteProperty("ThueNLDNopThem", true);
            //    if (!_soThang.Equals(value))
            //    {
            //        _soThang = value;
            //        PropertyHasChanged("ThueNLDNopThem");
            //    }
            //}
        }

        public int SoNguoiPhuThuoc
        {
            get
            {
                CanReadProperty("SoNguoiPhuThuoc", true);
                return _SoNguoiPhuThuoc;
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
			//TODO: Define authorization rules in QuyetToanThueTNCN_TheoThang
			//AuthorizationRules.AllowRead("MaChiTiet", "QuyetToanThueTNCN_TheoThangReadGroup");
			//AuthorizationRules.AllowRead("MaKyQuyetToan", "QuyetToanThueTNCN_TheoThangReadGroup");
			//AuthorizationRules.AllowRead("Thang", "QuyetToanThueTNCN_TheoThangReadGroup");
			//AuthorizationRules.AllowRead("Nam", "QuyetToanThueTNCN_TheoThangReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "QuyetToanThueTNCN_TheoThangReadGroup");
			//AuthorizationRules.AllowRead("TongThuNhap", "QuyetToanThueTNCN_TheoThangReadGroup");
			//AuthorizationRules.AllowRead("TongThuNhapChiuThue", "QuyetToanThueTNCN_TheoThangReadGroup");
			//AuthorizationRules.AllowRead("TongGiamTru", "QuyetToanThueTNCN_TheoThangReadGroup");
			//AuthorizationRules.AllowRead("TongTienThue", "QuyetToanThueTNCN_TheoThangReadGroup");
			//AuthorizationRules.AllowRead("DaNop", "QuyetToanThueTNCN_TheoThangReadGroup");
			//AuthorizationRules.AllowRead("ConPhaiNop", "QuyetToanThueTNCN_TheoThangReadGroup");

			//AuthorizationRules.AllowWrite("MaKyQuyetToan", "QuyetToanThueTNCN_TheoThangWriteGroup");
			//AuthorizationRules.AllowWrite("Thang", "QuyetToanThueTNCN_TheoThangWriteGroup");
			//AuthorizationRules.AllowWrite("Nam", "QuyetToanThueTNCN_TheoThangWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "QuyetToanThueTNCN_TheoThangWriteGroup");
			//AuthorizationRules.AllowWrite("TongThuNhap", "QuyetToanThueTNCN_TheoThangWriteGroup");
			//AuthorizationRules.AllowWrite("TongThuNhapChiuThue", "QuyetToanThueTNCN_TheoThangWriteGroup");
			//AuthorizationRules.AllowWrite("TongGiamTru", "QuyetToanThueTNCN_TheoThangWriteGroup");
			//AuthorizationRules.AllowWrite("TongTienThue", "QuyetToanThueTNCN_TheoThangWriteGroup");
			//AuthorizationRules.AllowWrite("DaNop", "QuyetToanThueTNCN_TheoThangWriteGroup");
			//AuthorizationRules.AllowWrite("ConPhaiNop", "QuyetToanThueTNCN_TheoThangWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuyetToanThueTNCN_TheoThang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetToanThueTNCN_TheoThangViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuyetToanThueTNCN_TheoThang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetToanThueTNCN_TheoThangAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuyetToanThueTNCN_TheoThang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetToanThueTNCN_TheoThangEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuyetToanThueTNCN_TheoThang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetToanThueTNCN_TheoThangDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuyetToanThueTNCN_TheoThang()
		{ /* require use of factory method */ }

		public static QuyetToanThueTNCN_TheoThang NewQuyetToanThueTNCN_TheoThang(long maChiTiet)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuyetToanThueTNCN_TheoThang");
			return DataPortal.Create<QuyetToanThueTNCN_TheoThang>(new Criteria(maChiTiet));
		}

		public static QuyetToanThueTNCN_TheoThang GetQuyetToanThueTNCN_TheoThang(long maChiTiet)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuyetToanThueTNCN_TheoThang");
			return DataPortal.Fetch<QuyetToanThueTNCN_TheoThang>(new Criteria(maChiTiet));
		}

		public static void DeleteQuyetToanThueTNCN_TheoThang(long maChiTiet)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuyetToanThueTNCN_TheoThang");
			DataPortal.Delete(new Criteria(maChiTiet));
		}

		public override QuyetToanThueTNCN_TheoThang Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuyetToanThueTNCN_TheoThang");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuyetToanThueTNCN_TheoThang");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuyetToanThueTNCN_TheoThang");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private QuyetToanThueTNCN_TheoThang(long maChiTiet)
		{
			this._maChiTiet = maChiTiet;
		}

		internal static QuyetToanThueTNCN_TheoThang NewQuyetToanThueTNCN_TheoThangChild(long maChiTiet)
		{
			QuyetToanThueTNCN_TheoThang child = new QuyetToanThueTNCN_TheoThang(maChiTiet);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuyetToanThueTNCN_TheoThang GetQuyetToanThueTNCN_TheoThang(SafeDataReader dr)
		{
			QuyetToanThueTNCN_TheoThang child =  new QuyetToanThueTNCN_TheoThang();
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
			public long MaChiTiet;

			public Criteria(long maChiTiet)
			{
				this.MaChiTiet = maChiTiet;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maChiTiet = criteria.MaChiTiet;
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
				cm.CommandText = "spd_SelecttblQuyetToanThueTNCN_TheoThang";

				cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
					ExecuteInsert(tr, null);

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
						ExecuteUpdate(tr, null);
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
			DataPortal_Delete(new Criteria(_maChiTiet));
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
				cm.CommandText = "spd_DeletetblQuyetToanThueTNCN_TheoThang";

				cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
			_maChiTiet = dr.GetInt64("MaChiTiet");
			_maKyQuyetToan = dr.GetInt32("MaKyQuyetToan");
			_thang = dr.GetInt32("Thang");
			_nam = dr.GetInt32("Nam");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tongThuNhap = dr.GetDecimal("TongThuNhap");
			_tongThuNhapChiuThue = dr.GetDecimal("TongThuNhapChiuThue");
			_tongGiamTru = dr.GetDecimal("TongGiamTru");
			_tongTienThue = dr.GetDecimal("TongTienThue");
			_daNop = dr.GetDecimal("DaNop");
            _bhxh = dr.GetDecimal("BHXH");
            _bhyt = dr.GetDecimal("BHYT");
            _bhtn = dr.GetDecimal("BHTN");
			_conPhaiNop = dr.GetDecimal("ConPhaiNop");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _cmnd = dr.GetString("CMND");
            _mst = dr.GetString("MaSoThue");
            _tinhTrang = dr.GetBoolean("TinhTrang");
            _tncnDongBoSung = dr.GetDecimal("TNCNDongBoSung");
            _daNopBoSung = dr.GetBoolean("DaNopBoSung");
            _soThang = dr.GetInt32("SoThang");
            _tuQuyetToan = dr.GetBoolean("TuQuyetToan");
            _thueNLDNopThem = dr.GetDecimal("ThueNLDNopThem");
            _thueNLDTraLai = dr.GetDecimal("ThueNLDTraLai");

            _SoNguoiPhuThuoc = dr.GetInt32("SoNguoiPhuThuoc");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, QuyetToanThueTNCN_TheoThangList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, QuyetToanThueTNCN_TheoThangList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_InserttblQuyetToanThueTNCN_TheoThang";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, QuyetToanThueTNCN_TheoThangList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			if (_maKyQuyetToan != 0)
				cm.Parameters.AddWithValue("@MaKyQuyetToan", _maKyQuyetToan);
			else
				cm.Parameters.AddWithValue("@MaKyQuyetToan", DBNull.Value);
			if (_thang != 0)
				cm.Parameters.AddWithValue("@Thang", _thang);
			else
				cm.Parameters.AddWithValue("@Thang", DBNull.Value);
			if (_nam != 0)
				cm.Parameters.AddWithValue("@Nam", _nam);
			else
				cm.Parameters.AddWithValue("@Nam", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_tongThuNhap != 0)
				cm.Parameters.AddWithValue("@TongThuNhap", _tongThuNhap);
			else
				cm.Parameters.AddWithValue("@TongThuNhap", DBNull.Value);
			if (_tongThuNhapChiuThue != 0)
				cm.Parameters.AddWithValue("@TongThuNhapChiuThue", _tongThuNhapChiuThue);
			else
				cm.Parameters.AddWithValue("@TongThuNhapChiuThue", DBNull.Value);
			if (_tongGiamTru != 0)
				cm.Parameters.AddWithValue("@TongGiamTru", _tongGiamTru);
			else
				cm.Parameters.AddWithValue("@TongGiamTru", DBNull.Value);
			if (_tongTienThue != 0)
				cm.Parameters.AddWithValue("@TongTienThue", _tongTienThue);
			else
				cm.Parameters.AddWithValue("@TongTienThue", DBNull.Value);
			if (_daNop != 0)
				cm.Parameters.AddWithValue("@DaNop", _daNop);
			else
				cm.Parameters.AddWithValue("@DaNop", DBNull.Value);
			if (_conPhaiNop != 0)
				cm.Parameters.AddWithValue("@ConPhaiNop", _conPhaiNop);
			else
				cm.Parameters.AddWithValue("@ConPhaiNop", DBNull.Value);
            cm.Parameters.AddWithValue("@DaNopBoSung", _daNopBoSung);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, QuyetToanThueTNCN_TheoThangList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, QuyetToanThueTNCN_TheoThangList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblQuyetToanThueCuoiThang";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, QuyetToanThueTNCN_TheoThangList parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			if (_maKyQuyetToan != 0)
				cm.Parameters.AddWithValue("@MaKyQuyetToan", _maKyQuyetToan);
			else
				cm.Parameters.AddWithValue("@MaKyQuyetToan", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_tongThuNhap != 0)
				cm.Parameters.AddWithValue("@TongThuNhap", _tongThuNhap);
			else
				cm.Parameters.AddWithValue("@TongThuNhap", DBNull.Value);
			if (_tongThuNhapChiuThue != 0)
				cm.Parameters.AddWithValue("@TongThuNhapChiuThue", _tongThuNhapChiuThue);
			else
				cm.Parameters.AddWithValue("@TongThuNhapChiuThue", DBNull.Value);
			if (_tongTienThue != 0)
				cm.Parameters.AddWithValue("@TongTienThue", _tongTienThue);
			else
				cm.Parameters.AddWithValue("@TongTienThue", DBNull.Value);
			if (_daNop != 0)
				cm.Parameters.AddWithValue("@DaNop", _daNop);
			else
				cm.Parameters.AddWithValue("@DaNop", DBNull.Value);
			if (_conPhaiNop != 0)
				cm.Parameters.AddWithValue("@ConPhaiNop", _conPhaiNop);
			else
				cm.Parameters.AddWithValue("@ConPhaiNop", DBNull.Value);
			if (_tncnDongBoSung != 0)
                cm.Parameters.AddWithValue("@TNCNDongBoSung", _tncnDongBoSung);
			else
				cm.Parameters.AddWithValue("@TNCNDongBoSung", DBNull.Value);
            cm.Parameters.AddWithValue("@DaNopBoSung", _daNopBoSung);
            cm.Parameters.AddWithValue("@TuQuyetToan", _tuQuyetToan);
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

			ExecuteDelete(tr, new Criteria(_maChiTiet));
			MarkNew();
		}
		#endregion //Data Access - Delete

        public static void XuLyQuyetToanThueTNCN(int Thang, int Nam, bool qTCuoiNam)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 0;
                    //cm.CommandText = "spd_XuLyQuyetToanThueTNCNCuoiThang";
                    cm.CommandText = "spd_XuLyQuyetToanThueTNCNCuoiThang_MaLoaiChi";
                    cm.Parameters.AddWithValue("@Thang", Thang);
                    cm.Parameters.AddWithValue("@Nam", Nam);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@QTCuoiNam", qTCuoiNam);
                    cm.ExecuteNonQuery();
                }
                cn.Close();
            }//using
        }

        public static void XuLyQuyetToanThueTNCNCuoiNam(int Thang, int Nam)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 0;
                    cm.CommandText = "spd_XuLyQuyetToanThueTNCNCuoiNam";
                    cm.Parameters.AddWithValue("@Thang", Thang);
                    cm.Parameters.AddWithValue("@Nam", Nam);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.ExecuteNonQuery();
                }
                cn.Close();
            }//using
        }

        public static void XoaQuyetToanThueTNCN(int Thang, int Nam)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 0;
                    cm.CommandText = "spd_XoaQuyetToanThueTNCN_TheoThang";
                    cm.Parameters.AddWithValue("@Thang", Thang);
                    cm.Parameters.AddWithValue("@Nam", Nam);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.ExecuteNonQuery();
                }
                cn.Close();
            }//using
        }

        public static void XoaQuyetToanThueTNCNCuoiNam(int Thang, int Nam)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 0;
                    cm.CommandText = "spd_XoaQuyetToanThueTNCNCuoiNam";
                    cm.Parameters.AddWithValue("@Thang", Thang);
                    cm.Parameters.AddWithValue("@Nam", Nam);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.ExecuteNonQuery();
                }
                cn.Close();
            }//using
        }

        public static int KiemTraQuyetToanThueTNCN(int Thang, int Nam)
        {
            int iFound = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 0;
                    cm.CommandText = "spd_KiemTraQuyetToanThue";
                    cm.Parameters.AddWithValue("@Thang", Thang);
                    cm.Parameters.AddWithValue("@Nam", Nam);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@Found", iFound);
                    cm.Parameters["@Found"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();

                    iFound = (int)cm.Parameters["@Found"].Value;
                }
                cn.Close();
            }//using
            return iFound;
        }
		#endregion //Data Access
	}
}
