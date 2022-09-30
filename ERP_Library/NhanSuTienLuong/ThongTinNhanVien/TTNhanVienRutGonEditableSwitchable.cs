



using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    public class NhanVienExport : Csla.BusinessBase<NhanVienExport>
    {
        private string _tenNhanVien = string.Empty;
        private string _maQLNhanVien = string.Empty;

        public string MaQLNhanVien
        {
            get { return _maQLNhanVien; }
            set { _maQLNhanVien = value; }
        }
        private int _maChucVu = 0;

        public int MaChucVu
        {
            get { return _maChucVu; }
            set { _maChucVu = value; }
        }
        private string _tenChucVu = string.Empty;

        public string TenChucVu
        {
            get { return _tenChucVu; }
            set { _tenChucVu = value; }
        }
        private int _maBoPhan = 0;

        public int MaBoPhan
        {
            get { return _maBoPhan; }
            set { _maBoPhan = value; }
        }
        private string _tenBoPhan = string.Empty;

        public string TenBoPhan
        {
            get { return _tenBoPhan; }
            set { _tenBoPhan = value; }
        }
        private bool _gioiTinh = false;

        public bool GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }
        private string _cmnd = string.Empty;

        public string Cmnd
        {
            get { return _cmnd; }
            set { _cmnd = value; }
        }
        private SmartDate _ngayCap = new SmartDate(DateTime.Today);

        public SmartDate NgayCap
        {
            get { return _ngayCap; }
            set { _ngayCap = value; }
        }
        private int _maNoiCap = 0;

        public int MaNoiCap
        {
            get { return _maNoiCap; }
            set { _maNoiCap = value; }
        }
        private SmartDate _ngaySinh = new SmartDate("1/1/1990");

        public SmartDate NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }
        private int _maNoiSinh = 0;

        public int MaNoiSinh
        {
            get { return _maNoiSinh; }
            set { _maNoiSinh = value; }
        }
        private int _quocTich = 0;

        public int QuocTich
        {
            get { return _quocTich; }
            set { _quocTich = value; }
        }
        private int _maDanToc = 0;

        public int MaDanToc
        {
            get { return _maDanToc; }
            set { _maDanToc = value; }
        }
        private int _maTonGiao = 0;

        public int MaTonGiao
        {
            get { return _maTonGiao; }
            set { _maTonGiao = value; }
        }
        private byte _loaiNV = 0;

        public byte LoaiNV
        {
            get { return _loaiNV; }
            set { _loaiNV = value; }
        }
        private int _maCongViec = 0;

        public int MaCongViec
        {
            get { return _maCongViec; }
            set { _maCongViec = value; }
        }
        private int _maNgachLuongCoBan = 0;

        public int MaNgachLuongCoBan
        {
            get { return _maNgachLuongCoBan; }
            set { _maNgachLuongCoBan = value; }
        }
        private int _maBacLuongCoBan = 0;

        public int MaBacLuongCoBan
        {
            get { return _maBacLuongCoBan; }
            set { _maBacLuongCoBan = value; }
        }
        private decimal _heSoLuongCoBan = 0;

        public decimal HeSoLuongCoBan
        {
            get { return _heSoLuongCoBan; }
            set { _heSoLuongCoBan = value; }
        }
        private string _DiaChiTam = string.Empty;

        public string DiaChiTam
        {
            get { return _DiaChiTam; }
            set { _DiaChiTam = value; }
        }
       
        public string TenNhanVien
        {
            get { return _tenNhanVien; }
            set { _tenNhanVien = value; }
        }
        protected override object GetIdValue()
        {
            return 0;
        }
        public NhanVienExport()
        {

        }
        public NhanVienExport GetNhanVienExport()
        {
            return new NhanVienExport();
        }

    }
    public class NhanVienExportList : Csla.BusinessListBase<NhanVienExportList, NhanVienExport>
    {
        private NhanVienExportList()
        {
        }
        public static NhanVienExportList NewNhanVienExportList()
        {
            return new NhanVienExportList();
        }
    }
	[Serializable()] 
	public class TTNhanVienRutGon : Csla.BusinessBase<TTNhanVienRutGon>
	{
		#region Business Properties and Methods

		//declare members
		private long _maNhanVien = 0;
		private int _maBoPhan = 0;
		private string _tenNhanVien = string.Empty;
		private string _maQLNhanVien = string.Empty;
        private byte _loaiNV = 0;
        private string _tenLoai = string.Empty;
        private string _tenBoPhan = string.Empty;

        public string TenBoPhan
        {
            get { return BoPhan.GetBoPhan(_maBoPhan).TenBoPhan; }
          
        }
       
        
		[System.ComponentModel.DataObjectField(true, false)]
		public long MaNhanVien
		{
			get
			{
				CanReadProperty("MaNhanVien", true);
				return _maNhanVien;
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
        public int MaChucVu
        {
            get
            {
               
                return 0;
            }
            
        }
  		public string TenNhanVien
		{
			get
			{
				CanReadProperty("TenNhanVien", true);
				return _tenNhanVien;
			}
			set
			{
				CanWriteProperty("TenNhanVien", true);
				if (value == null) value = string.Empty;
				if (!_tenNhanVien.Equals(value))
				{
					_tenNhanVien = value;
					PropertyHasChanged("TenNhanVien");
				}
			}
		}

		public string MaQLNhanVien
		{
			get
			{
				CanReadProperty("MaQLNhanVien", true);
				return _maQLNhanVien;
			}
			set
			{
				CanWriteProperty("MaQLNhanVien", true);
				if (value == null) value = string.Empty;
				if (!_maQLNhanVien.Equals(value))
				{
					_maQLNhanVien = value;
					PropertyHasChanged("MaQLNhanVien");
				}
			}
		}
        public byte LoaiNV
        {
            get { return _loaiNV; }
            set { _loaiNV = value; }
        }
        public string TenLoai
        {
            get { return _tenLoai; }
            set { _tenLoai = value; }
        }
		protected override object GetIdValue()
		{
			return _maNhanVien;
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
			// TenNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenNhanVien");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 500));
			//
			// MaQLNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "MaQLNhanVien");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLNhanVien", 50));
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
			//TODO: Define authorization rules in TTNhanVienRutGon
			//AuthorizationRules.AllowRead("MaNhanVien", "TTNhanVienRutGonReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhan", "TTNhanVienRutGonReadGroup");
			//AuthorizationRules.AllowRead("TenNhanVien", "TTNhanVienRutGonReadGroup");
			//AuthorizationRules.AllowRead("MaQLNhanVien", "TTNhanVienRutGonReadGroup");

			//AuthorizationRules.AllowWrite("MaBoPhan", "TTNhanVienRutGonWriteGroup");
			//AuthorizationRules.AllowWrite("TenNhanVien", "TTNhanVienRutGonWriteGroup");
			//AuthorizationRules.AllowWrite("MaQLNhanVien", "TTNhanVienRutGonWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TTNhanVienRutGon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TTNhanVienRutGonViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TTNhanVienRutGon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TTNhanVienRutGonAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TTNhanVienRutGon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TTNhanVienRutGonEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TTNhanVienRutGon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TTNhanVienRutGonDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TTNhanVienRutGon()
		{ /* require use of factory method */ }

		public static TTNhanVienRutGon NewTTNhanVienRutGon(long maNhanVien)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TTNhanVienRutGon");
			return DataPortal.Create<TTNhanVienRutGon>(new Criteria(maNhanVien));
		}
        public static TTNhanVienRutGon NewTTNhanVienRutGon(long maNhanVien,string tenNhanVien)
        {
            return new TTNhanVienRutGon(tenNhanVien);
        }

		public static TTNhanVienRutGon GetTTNhanVienRutGon(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TTNhanVienRutGon");
			return DataPortal.Fetch<TTNhanVienRutGon>(new Criteria(maNhanVien));
		}

		public static void DeleteTTNhanVienRutGon(long maNhanVien)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TTNhanVienRutGon");
			DataPortal.Delete(new Criteria(maNhanVien));
		}

		public override TTNhanVienRutGon Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TTNhanVienRutGon");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TTNhanVienRutGon");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TTNhanVienRutGon");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private TTNhanVienRutGon(long maNhanVien)
		{
			this._maNhanVien = maNhanVien;
		}
        private TTNhanVienRutGon(string tenNhanVien)
        {
            this._tenNhanVien = tenNhanVien;
        }
		internal static TTNhanVienRutGon NewTTNhanVienRutGonChild(long maNhanVien)
		{
			TTNhanVienRutGon child = new TTNhanVienRutGon(maNhanVien);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TTNhanVienRutGon GetTTNhanVienRutGon(SafeDataReader dr)
		{
			TTNhanVienRutGon child =  new TTNhanVienRutGon();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
        internal static TTNhanVienRutGon GetTTNhanVienRutGonTrongNgoai(SafeDataReader dr)
        {
            TTNhanVienRutGon child = new TTNhanVienRutGon();
            child.MarkAsChild();
            child.FetchTrongNgoai(dr);
            return child;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public long MaNhanVien;

			public Criteria(long maNhanVien)
			{
				this.MaNhanVien = maNhanVien;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maNhanVien = criteria.MaNhanVien;
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
                cm.CommandText = "spd_SelecttblnsTTNhanVienRutGon";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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
			DataPortal_Delete(new Criteria(_maNhanVien));
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
				cm.CommandText = "DeleteTTNhanVienRutGon";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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
        private void FetchTrongNgoai(SafeDataReader dr)
        {
            FetchObjectTrongNgoai(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }
		private void FetchObject(SafeDataReader dr)
		{
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_maQLNhanVien = dr.GetString("MaQLNhanVien");

		}
        private void FetchObjectTrongNgoai(SafeDataReader dr)
        {
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _loaiNV = dr.GetByte("LoaiNhanVien");
            _tenLoai = dr.GetString("TenLoai");
           
            
        }
		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, TTNhanVienRutGonList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, TTNhanVienRutGonList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddTTNhanVienRutGon";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, TTNhanVienRutGonList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, TTNhanVienRutGonList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, TTNhanVienRutGonList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdateTTNhanVienRutGon";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, TTNhanVienRutGonList parent)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
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

			ExecuteDelete(tr, new Criteria(_maNhanVien));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
