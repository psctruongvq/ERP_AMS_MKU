
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.Windows.Forms;
using System.Text;
//12_04_2013
///
namespace ERP_Library
{
    [Serializable()]
    public class PhieuDeNghiXuatDongPhuc : Csla.BusinessBase<PhieuDeNghiXuatDongPhuc>
    {
        #region Business Properties and Methods

		//declare members
        public bool Check { get; set; }
		private int _maDeNghiXuat = 0;
		private string _soPhieu = string.Empty;
		private int _loai = 0;
		private SmartDate _ngayNX = new SmartDate(DateTime.Today);
		private int _maNguoiLap = 0;
		private long _maDoiTac = 0;
		private string _dienGiai = string.Empty;
		private byte _phuongPhapNX = 0;
		private int _maPhongBan = 0;
		private int _soCTKemTheo = 0;
		private string _lop = string.Empty;
		private string _gioiTinh = string.Empty;
        private string _maQLDoiTac = string.Empty;
        private string _tenDoiTac = string.Empty;
        private string _namHoc = string.Empty;
        private string _ten = string.Empty;
        private string _hoTen = string.Empty;
        private bool _daXuat = false;

        private CT_PhieuDeNghiXuatDongPhucList _cT_PhieuDeNghiXuatDongPhucList = CT_PhieuDeNghiXuatDongPhucList.NewCT_PhieuDeNghiXuatDongPhucList();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaDeNghiXuat
		{
			get
			{
				CanReadProperty("MaDeNghiXuat", true);
				return _maDeNghiXuat;
			}
		}

		public string SoPhieu
		{
			get
			{
				CanReadProperty("SoPhieu", true);
				return _soPhieu;
			}
			set
			{
				CanWriteProperty("SoPhieu", true);
				if (value == null) value = string.Empty;
				if (!_soPhieu.Equals(value))
				{
					_soPhieu = value;
					PropertyHasChanged("SoPhieu");
				}
			}
		}

        public bool DaXuat
        {
            get
            {
                CanReadProperty("DaXuat", true);
                return _daXuat;
            }
            set
            {
                CanWriteProperty("DaXuat", true);
                if (value == null) value = false;
                if (!_daXuat.Equals(value))
                {
                    _daXuat = value;
                    PropertyHasChanged("DaXuat");
                }
            }
        }

        public string Ten
        {
            get
            {
                CanReadProperty("Ten", true);
                return _ten;
            }
            set
            {
                CanWriteProperty("Ten", true);
                if (value == null) value = string.Empty;
                if (!_ten.Equals(value))
                {
                    _ten = value;
                    PropertyHasChanged("Ten");
                }
            }
        }

        public string HoTen
        {
            get
            {
                CanReadProperty("HoTen", true);
                return _hoTen;
            }
            set
            {
                CanWriteProperty("HoTen", true);
                if (value == null) value = string.Empty;
                if (!_hoTen.Equals(value))
                {
                    _hoTen = value;
                    PropertyHasChanged("HoTen");
                }
            }
        }

		public int Loai
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

		public DateTime NgayNX
		{
			get
			{
				CanReadProperty("NgayNX", true);
				return _ngayNX.Date;
			}
            set
            {
                CanWriteProperty("NgayNX", true);
                if (!_ngayNX.Equals(value))
                {
                    _ngayNX =new SmartDate(value);
                    PropertyHasChanged("NgayNX");
                }
            }
		}

		public string NgayNXString
		{
			get
			{
				CanReadProperty("NgayNXString", true);
				return _ngayNX.Text;
			}
			set
			{
				CanWriteProperty("NgayNXString", true);
				if (value == null) value = string.Empty;
				if (!_ngayNX.Equals(value))
				{
					_ngayNX.Text = value;
					PropertyHasChanged("NgayNXString");
				}
			}
		}

        public string MaQLDoiTac
        {
            get
            {
                CanReadProperty("MaQLDoiTac", true);
                return _maQLDoiTac;
            }
            set
            {
                CanWriteProperty("MaQLDoiTac", true);
                if (value == null) value = string.Empty;
                if (!_maQLDoiTac.Equals(value))
                {
                    _maQLDoiTac = value;
                    PropertyHasChanged("MaQLDoiTac");
                }
            }
        }

        public string TenDoiTac
        {
            get
            {
                CanReadProperty("TenDoiTac", true);
                return _tenDoiTac;
            }
            set
            {
                CanWriteProperty("TenDoiTac", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTac.Equals(value))
                {
                    _tenDoiTac = value;
                    PropertyHasChanged("TenDoiTac");
                }
            }
        }

        public string NamHoc
        {
            get
            {
                CanReadProperty("NamHoc", true);
                return _namHoc;
            }
            set
            {
                CanWriteProperty("NamHoc", true);
                if (value == null) value = string.Empty;
                if (!_namHoc.Equals(value))
                {
                    _namHoc = value;
                    PropertyHasChanged("NamHoc");
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

		public byte PhuongPhapNX
		{
			get
			{
				CanReadProperty("PhuongPhapNX", true);
				return _phuongPhapNX;
			}
			set
			{
				CanWriteProperty("PhuongPhapNX", true);
				if (!_phuongPhapNX.Equals(value))
				{
					_phuongPhapNX = value;
					PropertyHasChanged("PhuongPhapNX");
				}
			}
		}

		public int MaPhongBan
		{
			get
			{
				CanReadProperty("MaPhongBan", true);
				return _maPhongBan;
			}
			set
			{
				CanWriteProperty("MaPhongBan", true);
				if (!_maPhongBan.Equals(value))
				{
					_maPhongBan = value;
					PropertyHasChanged("MaPhongBan");
				}
			}
		}

		public int SoCTKemTheo
		{
			get
			{
				CanReadProperty("SoCTKemTheo", true);
				return _soCTKemTheo;
			}
			set
			{
				CanWriteProperty("SoCTKemTheo", true);
				if (!_soCTKemTheo.Equals(value))
				{
					_soCTKemTheo = value;
					PropertyHasChanged("SoCTKemTheo");
				}
			}
		}

		public string Lop
		{
			get
			{
				CanReadProperty("Lop", true);
				return _lop;
			}
			set
			{
				CanWriteProperty("Lop", true);
				if (value == null) value = string.Empty;
				if (!_lop.Equals(value))
				{
					_lop = value;
					PropertyHasChanged("Lop");
				}
			}
		}

		public string GioiTinh
		{
			get
			{
				CanReadProperty("GioiTinh", true);
				return _gioiTinh;
			}
			set
			{
				CanWriteProperty("GioiTinh", true);
				if (value == null) value = string.Empty;
				if (!_gioiTinh.Equals(value))
				{
					_gioiTinh = value;
					PropertyHasChanged("GioiTinh");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maDeNghiXuat;
		}


        public CT_PhieuDeNghiXuatDongPhucList CT_PhieuDeNghiXuatDongPhucList
        {
            get
            {
                CanReadProperty("CT_PhieuDeNghiXuatDongPhucList", true);
                return _cT_PhieuDeNghiXuatDongPhucList;
            }

        }

        public override bool IsValid
        {
            get { return base.IsValid && _cT_PhieuDeNghiXuatDongPhucList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _cT_PhieuDeNghiXuatDongPhucList.IsDirty; }
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
			// SoPhieu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoPhieu", 50));
			//
			// NgayNX
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "NgayNXString");
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
			//
			// Lop
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Lop", 100));
			//
			// GioiTinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GioiTinh", 100));
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
			//TODO: Define authorization rules in PhieuDeNghiXuatDongPhuc
			//AuthorizationRules.AllowRead("MaDeNghiXuat", "PhieuDeNghiXuatDongPhucReadGroup");
			//AuthorizationRules.AllowRead("SoPhieu", "PhieuDeNghiXuatDongPhucReadGroup");
			//AuthorizationRules.AllowRead("Loai", "PhieuDeNghiXuatDongPhucReadGroup");
			//AuthorizationRules.AllowRead("NgayNX", "PhieuDeNghiXuatDongPhucReadGroup");
			//AuthorizationRules.AllowRead("NgayNXString", "PhieuDeNghiXuatDongPhucReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "PhieuDeNghiXuatDongPhucReadGroup");
			//AuthorizationRules.AllowRead("MaDoiTac", "PhieuDeNghiXuatDongPhucReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "PhieuDeNghiXuatDongPhucReadGroup");
			//AuthorizationRules.AllowRead("PhuongPhapNX", "PhieuDeNghiXuatDongPhucReadGroup");
			//AuthorizationRules.AllowRead("MaPhongBan", "PhieuDeNghiXuatDongPhucReadGroup");
			//AuthorizationRules.AllowRead("SoCTKemTheo", "PhieuDeNghiXuatDongPhucReadGroup");
			//AuthorizationRules.AllowRead("Lop", "PhieuDeNghiXuatDongPhucReadGroup");
			//AuthorizationRules.AllowRead("GioiTinh", "PhieuDeNghiXuatDongPhucReadGroup");

			//AuthorizationRules.AllowWrite("SoPhieu", "PhieuDeNghiXuatDongPhucWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "PhieuDeNghiXuatDongPhucWriteGroup");
			//AuthorizationRules.AllowWrite("NgayNXString", "PhieuDeNghiXuatDongPhucWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "PhieuDeNghiXuatDongPhucWriteGroup");
			//AuthorizationRules.AllowWrite("MaDoiTac", "PhieuDeNghiXuatDongPhucWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "PhieuDeNghiXuatDongPhucWriteGroup");
			//AuthorizationRules.AllowWrite("PhuongPhapNX", "PhieuDeNghiXuatDongPhucWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhongBan", "PhieuDeNghiXuatDongPhucWriteGroup");
			//AuthorizationRules.AllowWrite("SoCTKemTheo", "PhieuDeNghiXuatDongPhucWriteGroup");
			//AuthorizationRules.AllowWrite("Lop", "PhieuDeNghiXuatDongPhucWriteGroup");
			//AuthorizationRules.AllowWrite("GioiTinh", "PhieuDeNghiXuatDongPhucWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhieuDeNghiXuatDongPhuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhieuDeNghiXuatDongPhucViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhieuDeNghiXuatDongPhuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhieuDeNghiXuatDongPhucAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhieuDeNghiXuatDongPhuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhieuDeNghiXuatDongPhucEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhieuDeNghiXuatDongPhuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhieuDeNghiXuatDongPhucDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhieuDeNghiXuatDongPhuc()
		{ /* require use of factory method */ }

		public static PhieuDeNghiXuatDongPhuc NewPhieuDeNghiXuatDongPhuc()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhieuDeNghiXuatDongPhuc");
			return DataPortal.Create<PhieuDeNghiXuatDongPhuc>();
		}

		public static PhieuDeNghiXuatDongPhuc GetPhieuDeNghiXuatDongPhuc(int maDeNghiXuat)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhieuDeNghiXuatDongPhuc");
			return DataPortal.Fetch<PhieuDeNghiXuatDongPhuc>(new Criteria(maDeNghiXuat));
		}

        public static PhieuDeNghiXuatDongPhuc KiemTraXuatCapPhat(int maDoiTac,string namHoc,int loaiPhieu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuat");
            return DataPortal.Fetch<PhieuDeNghiXuatDongPhuc>(new CriteriaKiemTraXuatCapPhat(maDoiTac, namHoc, loaiPhieu));
        }

		public void DeletePhieuDeNghiXuatDongPhuc(int maDeNghiXuat)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhieuDeNghiXuatDongPhuc");
			DataPortal.Delete(new Criteria(maDeNghiXuat));
		}

        public static void DeletePhieuDeNghiXuatDongPhuc(PhieuDeNghiXuatDongPhuc pdn)
        {
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    pdn.CT_PhieuDeNghiXuatDongPhucList.Clear();
                    pdn.CT_PhieuDeNghiXuatDongPhucList.Update(tr, pdn);


                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletetblPhieuDeNghiXuatDongPhuc";

                        cm.Parameters.AddWithValue("@MaDeNghiXuat", pdn.MaDeNghiXuat);

                        cm.ExecuteNonQuery();
                    }//using
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

		public override PhieuDeNghiXuatDongPhuc Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhieuDeNghiXuatDongPhuc");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhieuDeNghiXuatDongPhuc");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a PhieuDeNghiXuatDongPhuc");

			return base.Save();
		}

		#endregion //Factory Methods

        #region Child Factory Methods
        internal static PhieuDeNghiXuatDongPhuc GetPhieuDeNghiXuatDongPhuc(SafeDataReader dr)
        {
            PhieuDeNghiXuatDongPhuc child = new PhieuDeNghiXuatDongPhuc();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        internal static PhieuDeNghiXuatDongPhuc GetPhieuDeNghiXuatDongPhucCoDoiTuong(SafeDataReader dr)
        {
            PhieuDeNghiXuatDongPhuc child = new PhieuDeNghiXuatDongPhuc();
            child.MarkAsChild();
            child.FetchCoDoiTuong(dr);
            return child;
        }


        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaDeNghiXuat;

            public Criteria(int maDeNghiXuat)
            {
                this.MaDeNghiXuat = maDeNghiXuat;
            }
        }
        [Serializable()]
        private class CriteriaKiemTraXuatCapPhat
        {
            public int MaDoiTac;
            public string NamHoc;
            public int LoaiPhieu;
            public CriteriaKiemTraXuatCapPhat(int maDoiTac,string namHoc,int loaiPhieu)
            {
                this.MaDoiTac = maDoiTac;
                this.LoaiPhieu = loaiPhieu;
                this.NamHoc = namHoc;
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
        private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_getPhieuDeNghiXuatDongPhuc";

                    cm.Parameters.AddWithValue("@MaDeNghiXuat", ((Criteria)criteria).MaDeNghiXuat);
                }
                else if (criteria is CriteriaKiemTraXuatCapPhat)
                {
                    cm.CommandText = "spd_KiemTraDaLapPhieuDeNghiCapPhat";

                    cm.Parameters.AddWithValue("@MaDoiTac", ((CriteriaKiemTraXuatCapPhat)criteria).MaDoiTac);
                    cm.Parameters.AddWithValue("@LoaiPhieu", ((CriteriaKiemTraXuatCapPhat)criteria).LoaiPhieu);
                    cm.Parameters.AddWithValue("@NamHoc", ((CriteriaKiemTraXuatCapPhat)criteria).NamHoc);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
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

        private void DataPortal_Delete(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    //ExecuteFetch(tr, criteria);
                    this._cT_PhieuDeNghiXuatDongPhucList.Clear();
                    this.CT_PhieuDeNghiXuatDongPhucList.Clear();
                    UpdateChildren(tr);
                    
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
                cm.CommandText = "spd_DeletetblPhieuDeNghiXuatDongPhuc";

                cm.Parameters.AddWithValue("@MaDeNghiXuat", criteria.MaDeNghiXuat);

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

        private void FetchCoDoiTuong(SafeDataReader dr)
        {
            FetchObjectCoDoiTuong(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);

        }

        private void FetchObject(SafeDataReader dr)
        {
            _maDeNghiXuat = dr.GetInt32("MaDeNghiXuat");
            _soPhieu = dr.GetString("SoPhieu");
            _loai = dr.GetInt16("Loai");
            _ngayNX = dr.GetSmartDate("NgayNX", _ngayNX.EmptyIsMin);
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _dienGiai = dr.GetString("DienGiai");
            _phuongPhapNX = dr.GetByte("PhuongPhapNX");
            _maPhongBan = dr.GetInt32("MaPhongBan");
            _soCTKemTheo = dr.GetInt32("SoCTKemTheo");
            _lop = dr.GetString("Lop");
            _gioiTinh = dr.GetString("GioiTinh");
            //_maQLDoiTac = dr.GetString("MaQLDoiTac");
            //_tenDoiTac = dr.GetString("TenDoiTac");
            _hoTen = dr.GetString("HoTen");
            _ten = dr.GetString("Ten");
            _namHoc = dr.GetString("NamHoc");
        }
        private void FetchObjectCoDoiTuong(SafeDataReader dr)
        {
            _maDeNghiXuat = dr.GetInt32("MaDeNghiXuat");
            _soPhieu = dr.GetString("SoPhieu");
            _loai = dr.GetInt16("Loai");
            _ngayNX = dr.GetSmartDate("NgayNX", _ngayNX.EmptyIsMin);
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _dienGiai = dr.GetString("DienGiai");
            _phuongPhapNX = dr.GetByte("PhuongPhapNX");
            _maPhongBan = dr.GetInt32("MaPhongBan");
            _soCTKemTheo = dr.GetInt32("SoCTKemTheo");
            _lop = dr.GetString("Lop");
            _gioiTinh = dr.GetString("GioiTinh");
            _maQLDoiTac = dr.GetString("MaQLDoiTac");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _hoTen = dr.GetString("HoTen");
            _ten = dr.GetString("Ten");
            _namHoc = dr.GetString("NamHoc");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _cT_PhieuDeNghiXuatDongPhucList = CT_PhieuDeNghiXuatDongPhucList.GetCT_PhieuDeNghiXuatDongPhucList(this.MaDeNghiXuat);
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
                cm.CommandText = "spd_InsertPhieuDeNghiXuatDongPhuc";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maDeNghiXuat = (int)cm.Parameters["@NewMaDeNghiXuat"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_soPhieu.Length > 0)
                cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
            else
                cm.Parameters.AddWithValue("@SoPhieu", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayNX", _ngayNX.DBValue);

            cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_phuongPhapNX != 0)
                cm.Parameters.AddWithValue("@PhuongPhapNX", _phuongPhapNX);
            else
                cm.Parameters.AddWithValue("@PhuongPhapNX", DBNull.Value);
            if (_maPhongBan != 0)
                cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
            else
                cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
            if (_soCTKemTheo != 0)
                cm.Parameters.AddWithValue("@SoCTKemTheo", _soCTKemTheo);
            else
                cm.Parameters.AddWithValue("@SoCTKemTheo", DBNull.Value);
            if (_lop.Length > 0)
                cm.Parameters.AddWithValue("@Lop", _lop);
            else
                cm.Parameters.AddWithValue("@Lop", DBNull.Value);
            if (_gioiTinh.Length > 0)
                cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
            else
                cm.Parameters.AddWithValue("@GioiTinh", DBNull.Value);
            if (_namHoc.Length > 0)
                cm.Parameters.AddWithValue("@NamHoc", _namHoc);
            else
                cm.Parameters.AddWithValue("@NamHoc", DBNull.Value);
            if (_ten.Length > 0)
                cm.Parameters.AddWithValue("@Ten", _ten);
            else
                cm.Parameters.AddWithValue("@Ten", DBNull.Value);
            if (_hoTen.Length > 0)
                cm.Parameters.AddWithValue("@HoTen", _hoTen);
            else
                cm.Parameters.AddWithValue("@HoTen", DBNull.Value);
            cm.Parameters.AddWithValue("@NgaySua", DateTime.Now);
            cm.Parameters.AddWithValue("@NewMaDeNghiXuat", _maDeNghiXuat);
            cm.Parameters["@NewMaDeNghiXuat"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblPhieuDeNghiXuatDongPhuc";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaDeNghiXuat", _maDeNghiXuat);
			if (_soPhieu.Length > 0)
				cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
			else
				cm.Parameters.AddWithValue("@SoPhieu", DBNull.Value);
			if (_loai != 0)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayNX", _ngayNX.DBValue);
            cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
			if (_maDoiTac != 0)
				cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
			else
				cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_phuongPhapNX != 0)
				cm.Parameters.AddWithValue("@PhuongPhapNX", _phuongPhapNX);
			else
				cm.Parameters.AddWithValue("@PhuongPhapNX", DBNull.Value);
			if (_maPhongBan != 0)
				cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
			else
				cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
			if (_soCTKemTheo != 0)
				cm.Parameters.AddWithValue("@SoCTKemTheo", _soCTKemTheo);
			else
				cm.Parameters.AddWithValue("@SoCTKemTheo", DBNull.Value);
			if (_lop.Length > 0)
				cm.Parameters.AddWithValue("@Lop", _lop);
			else
				cm.Parameters.AddWithValue("@Lop", DBNull.Value);
			if (_gioiTinh.Length > 0)
				cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
			else
				cm.Parameters.AddWithValue("@GioiTinh", DBNull.Value);
            if (_namHoc.Length > 0)
                cm.Parameters.AddWithValue("@NamHoc", _namHoc);
            else
                cm.Parameters.AddWithValue("@NamHoc", DBNull.Value);
            cm.Parameters.AddWithValue("@NgaySua", DateTime.Now);
            if (_ten.Length > 0)
                cm.Parameters.AddWithValue("@Ten", _ten);
            else
                cm.Parameters.AddWithValue("@Ten", DBNull.Value);
            if (_hoTen.Length > 0)
                cm.Parameters.AddWithValue("@HoTen", _hoTen);
            else
                cm.Parameters.AddWithValue("@HoTen", DBNull.Value);
            cm.Parameters.AddWithValue("@DaXuat", _daXuat);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _cT_PhieuDeNghiXuatDongPhucList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete

        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            _cT_PhieuDeNghiXuatDongPhucList.Clear();
            UpdateChildren(tr);

            ExecuteDelete(tr, new Criteria(_maDeNghiXuat));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
