
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;


namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiTietGiayXacNhanTongHop : Csla.BusinessBase<ChiTietGiayXacNhanTongHop>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChiTietGiayXacNhan = 0;
		private int _maGiayXacNhan = 0;
		private int _maBoPhanDen = 0;
        private string _tenBoPhanDen = string.Empty;
		private decimal _soTien = 0;
        private SmartDate _ngayHoanTat = new SmartDate(DateTime.Today.Date);
		private bool _hoanTat = false;
        private string _ghiChu = string.Empty;
        private string _tenGiayXacNhan = string.Empty;
        private int _maBoPhanDi = 0;
        private string _tenBoPhanDi = string.Empty;
        private bool _duocNhapHo = false;
        private bool _kinhPhiBan = false;
        private DateTime _ngayLap = DateTime.Today.Date;
        private decimal _soTienConLai = 0;
 
 		[System.ComponentModel.DataObjectField(true, false)]
		public int MaChiTietGiayXacNhan
		{
			get
			{
               
				return _maChiTietGiayXacNhan;
			}
		}

		public int MaGiayXacNhan
		{
			get
			{
				return _maGiayXacNhan;
			}
			set
			{
				if (!_maGiayXacNhan.Equals(value))
				{
					_maGiayXacNhan = value;
					PropertyHasChanged("MaGiayXacNhan");
				}
			}
		}
        public string TenGiayXacNhan
        {
            get
            {
                
                return _tenGiayXacNhan;
            }
            set
            {
                CanWriteProperty("TenGiayXacNhan", true);
                if (value == null) value = string.Empty;
                if (!_tenGiayXacNhan.Equals(value))
                {
                    _tenGiayXacNhan = value;
                    PropertyHasChanged("TenGiayXacNhan");
                }
            }
        }
       
		public int MaBoPhanDen
		{
			get
			{
				return _maBoPhanDen;
			}
			set
			{
				if (!_maBoPhanDen.Equals(value))
				{
					_maBoPhanDen = value;
                    _tenBoPhanDen = BoPhan.GetBoPhan(_maBoPhanDen).TenBoPhan;
					PropertyHasChanged("MaBoPhanDen");
				}
			}
		}
        public string TenBoPhanDen
        {
            get
            {
                CanReadProperty("TenBoPhanDen", true);
                _tenBoPhanDen = BoPhan.GetBoPhan(_maBoPhanDen).TenBoPhan;
                return _tenBoPhanDen;
            }
            set
            {
                CanWriteProperty("TenBoPhanDen", true);
                if (value == null) value = string.Empty;
                if (!_tenBoPhanDen.Equals(value))
                {
                    _tenBoPhanDen = BoPhan.GetBoPhan(_maBoPhanDen).TenBoPhan;
                    _tenBoPhanDen = value;
                    PropertyHasChanged("TenBoPhanDen");
                }
            }
        }
	
		public decimal SoTien
		{
			get
			{
				return _soTien;
			}
			set
			{
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
				}
			}
		}
        public decimal SoTienConLai
        {
            get {
                return _soTienConLai ;
                 }
           
        }

		public DateTime NgayHoanTat
		{
			get
			{
				return _ngayHoanTat.Date;
			}
            set
            {
                CanWriteProperty("NgayHoanTat", true);
                if (!_ngayHoanTat.Equals(value))
                {
                    _ngayHoanTat = new SmartDate(value);
                    PropertyHasChanged("NgayHoanTat");
                }
            }
		}

	
		public bool HoanTat
		{
			get
			{
				return _hoanTat;
			}
			set
			{
				if (!_hoanTat.Equals(value))
				{
					_hoanTat = value;
					PropertyHasChanged("HoanTat");
				}
			}
		}
        /*
		public decimal SoTienConLai
		{
			get
			{
				return _soTienConLai;
			}
			set
			{
				if (!_soTienConLai.Equals(value))
				{
					_soTienConLai = value;
					PropertyHasChanged("SoTienConLai");
				}
			}
		}
        */
        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _ghiChu;
            }
            set
            {
                CanWriteProperty("GhiChu", true);
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }
        public int MaBoPhanDi
        {
            get
            {
                return _maBoPhanDi;
            }
            set
            {
                if (!_maBoPhanDi.Equals(value))
                {
                    _maBoPhanDi = value;
                    PropertyHasChanged("MaBoPhanDi");
                }
            }
        }

        public string TenBoPhanDi
        {
            get
            {
                return _tenBoPhanDi;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenBoPhanDi.Equals(value))
                {
                    _tenBoPhanDi = value;
                    PropertyHasChanged("TenBoPhanDi");
                }
            }
        }

        public DateTime NgayLap
        {
            get {

                return _ngayLap;//
            }
            
        }
        public bool DuocNhapHo
        {
            get
            {
                return _duocNhapHo;
            }
            set
            {
                if (!_duocNhapHo.Equals(value))
                {
                    _duocNhapHo = value;
                    PropertyHasChanged("DuocNhapHo");
                }
            }
        }
        public bool KinhPhiBan
        {
            get
            {
                return _kinhPhiBan;
            }
            set
            {
                if (!_kinhPhiBan.Equals(value))
                {
                    _kinhPhiBan = value;
                    PropertyHasChanged("KinhPhiBan");
                }
            }
        }
     	public override bool IsValid
		{
            get { return base.IsValid; }
		}

		public override bool IsDirty
		{
            get { return base.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maChiTietGiayXacNhan;
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

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChiTietGiayXacNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiTietGiayXacNhanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChiTietGiayXacNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiTietGiayXacNhanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChiTietGiayXacNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiTietGiayXacNhanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChiTietGiayXacNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiTietGiayXacNhanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChiTietGiayXacNhanTongHop()
		{ /* require use of factory method */ }

        public static ChiTietGiayXacNhanTongHop NewChiTietGiayXacNhanTongHop()
        {
            ChiTietGiayXacNhanTongHop item = new ChiTietGiayXacNhanTongHop();
            item.MarkAsChild();
            return item;
        }

        public static ChiTietGiayXacNhanTongHop NewChiTietGiayXacNhanTongHop(int index, string name)
        {

            ChiTietGiayXacNhanTongHop item = new ChiTietGiayXacNhanTongHop();
            item.TenGiayXacNhan = name;

            return item;
        }

        public static ChiTietGiayXacNhanTongHop GetChiTietGiayXacNhanTongHop(int maChiTietGiayXacNhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiTietGiayXacNhan");
            return DataPortal.Fetch<ChiTietGiayXacNhanTongHop>(new Criteria(maChiTietGiayXacNhan));
        }
		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChiTietGiayXacNhanTongHop GetChiTietGiayXacNhanTongHop(SafeDataReader dr)
		{
            ChiTietGiayXacNhanTongHop child = new ChiTietGiayXacNhanTongHop();
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
            public int MaChiTietGiayXacNhan;
            public Criteria(int maChiTietGiayXacNhan)
            {
                this.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
            }

        }

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
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
                    cm.CommandText = "spd_SelecttblnsChiTietGiayXacNhan";
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((Criteria)criteria).MaChiTietGiayXacNhan);
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();
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
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
            _soTienConLai = dr.GetDecimal("SoTienConLai");			
            _maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
			_maBoPhanDen = dr.GetInt32("MaBoPhanDen");
            _tenBoPhanDen = dr.GetString("TenBoPhanDen");         
			_soTien = dr.GetDecimal("SoTien");
			_ngayHoanTat = dr.GetSmartDate("NgayHoanTat", _ngayHoanTat.EmptyIsMin);
			_hoanTat = dr.GetBoolean("HoanTat");		
            _ghiChu = dr.GetString("GhiChu");
            _maBoPhanDi = dr.GetInt32("MaBoPhanDi");
            _tenBoPhanDi = dr.GetString("TenBoPhanDi");
            _tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
            _duocNhapHo = dr.GetBoolean("DuocNhapHo");
            _kinhPhiBan = dr.GetBoolean("KinhPhiBan");
            _ngayLap = dr.GetDateTime("NgayLap");
		}
		#endregion //Data Access - Fetch

		#endregion //Data Access
	}
}
