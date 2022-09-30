
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
namespace ERP_Library
{ 
	[Serializable()] 
	public class GiayXacNhanChuongTrinh : Csla.BusinessBase<GiayXacNhanChuongTrinh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maGiayXacNhan = 0;
		private string _maGiayXacNhanQL = string.Empty;
		private string _tenGiayXacNhan = string.Empty;
		private int _maChuongTrinh = 0;
		private string _soChuongTrinh = string.Empty;
        private SmartDate _ngayPhatSong = new SmartDate(DateTime.Today.Date);
		private string _soHopDong = string.Empty;
		private int _maDonViXacNhanDi = 0;
        private string _tenDonViXacNhanDi = string.Empty;
		//private int _databaseNumber =0;
		private int _nguoiLap = 0;
		private Nullable <decimal> _soTien = null;
     
     
        private SmartDate _ngayLap = new SmartDate(DateTime.Today.Date);
		private bool _trangThai = false;
        private string _tenChuongTrinh = string.Empty;
        private string _ghiChu = string.Empty;
		//declare child member(s)
		private ChiTietGiayXacNhanList _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.NewChiTietGiayXacNhanList();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaGiayXacNhan
		{
			get
			{
				return _maGiayXacNhan;
			}
		}
        public string TenChuongTrinh
        {
            get
            {

               // _tenChuongTrinh = ChuongTrinh.GetChuongTrinh(_maChuongTrinh, _databaseNumber).TenChuongTrinh;
                return _tenChuongTrinh;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenChuongTrinh.Equals(value))
                {
                    _tenChuongTrinh = value;
                    PropertyHasChanged("TenChuongTrinh");
                }
            }
        }
		public string MaGiayXacNhanQL
		{
			get
			{
				return _maGiayXacNhanQL;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maGiayXacNhanQL.Equals(value))
				{
					_maGiayXacNhanQL = value;
					PropertyHasChanged("MaGiayXacNhanQL");
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
				if (value == null) value = string.Empty;
				if (!_tenGiayXacNhan.Equals(value))
				{
					_tenGiayXacNhan = value;
					PropertyHasChanged("TenGiayXacNhan");
				}
			}
		}

		public int MaChuongTrinh
		{
			get
			{
				return _maChuongTrinh;
			}
			set
			{
				if (!_maChuongTrinh.Equals(value))
				{
					_maChuongTrinh = value;
                  
					PropertyHasChanged("MaChuongTrinh");
				}
			}
		}

		public string SoChuongTrinh
		{
			get
			{
				return _soChuongTrinh;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soChuongTrinh.Equals(value))
				{
					_soChuongTrinh = value;
					PropertyHasChanged("SoChuongTrinh");
				}
			}
		}

		public DateTime NgayPhatSong
		{
			get
			{
				return _ngayPhatSong.Date;
			}
            set
            {
                CanWriteProperty("NgayPhatSong", true);
                if (!_ngayPhatSong.Equals(value))
                {
                    _ngayPhatSong = new SmartDate(value);
                    PropertyHasChanged("NgayPhatSong");
                }
            }
		}

	

		public string SoHopDong
		{
			get
			{
				return _soHopDong;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soHopDong.Equals(value))
				{
					_soHopDong = value;
					PropertyHasChanged("SoHopDong");
				}
			}
		}
        public string TenDonViXacNhanDi
        {
            get
            {
              
                return _tenDonViXacNhanDi;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenDonViXacNhanDi.Equals(value))
                {
                    _tenDonViXacNhanDi = value;
                    PropertyHasChanged("TenDonViXacNhanDi");
                }
            }

           
        }
		public int MaDonViXacNhanDi
		{
			get
			{
				return _maDonViXacNhanDi;
			}
			set
			{
				if (!_maDonViXacNhanDi.Equals(value))
				{
					_maDonViXacNhanDi = value;                   
					PropertyHasChanged("MaDonViXacNhanDi");
				}
			}
		}

	
		public int NguoiLap
		{
			get
			{
				return _nguoiLap;
			}
			set
			{
				if (!_nguoiLap.Equals(value))
				{
					_nguoiLap = value;
					PropertyHasChanged("NguoiLap");
				}
			}
		}

		public Nullable<decimal> SoTien
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
     
		public DateTime NgayLap
		{
			get
			{
				return _ngayLap.Date;
			}
            set
            {
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    
                    PropertyHasChanged("NgayLap");
                }
            }
		}


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
		public bool TrangThai
		{
			get
			{
				return _trangThai;
			}
			set
			{
				if (!_trangThai.Equals(value))
				{
					_trangThai = value;
					PropertyHasChanged("TrangThai");
				}
			}
		}

		public ChiTietGiayXacNhanList ChiTietGiayXacNhanList
		{
			get
			{
				return _chiTietGiayXacNhanList;
			}
            set
            {
                if (!_chiTietGiayXacNhanList.Equals(value))
                {
                    _chiTietGiayXacNhanList = value;
                    PropertyHasChanged("ChiTietGiayXacNhanList");
                }
            }
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _chiTietGiayXacNhanList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _chiTietGiayXacNhanList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maGiayXacNhan;
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
			// MaGiayXacNhanQL
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaGiayXacNhanQL", 50));
			//
			// TenGiayXacNhan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenGiayXacNhan", 400));
			//
			// SoChuongTrinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChuongTrinh", 50));
			//
			// SoHopDong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHopDong", 50));
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
			//TODO: Define CanGetObject permission in GiayXacNhanChuongTrinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayXacNhanChuongTrinhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in GiayXacNhanChuongTrinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayXacNhanChuongTrinhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in GiayXacNhanChuongTrinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayXacNhanChuongTrinhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in GiayXacNhanChuongTrinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayXacNhanChuongTrinhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private GiayXacNhanChuongTrinh()
		{ /* require use of factory method */ }
       
		public static GiayXacNhanChuongTrinh NewGiayXacNhanChuongTrinh()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a GiayXacNhanChuongTrinh");
			return DataPortal.Create<GiayXacNhanChuongTrinh>();
		}

        private GiayXacNhanChuongTrinh(int maChuongTrinh, string tenGiayXacNhan)
        {
            _maChuongTrinh = maChuongTrinh;
            _tenGiayXacNhan = tenGiayXacNhan;
        }
        public static GiayXacNhanChuongTrinh NewGiayXacNhanChuongTrinhMa(int maChuongTrinh, string tenGiayXacNhan)
        {
            return new GiayXacNhanChuongTrinh(maChuongTrinh, tenGiayXacNhan);
        }

        public static GiayXacNhanChuongTrinh NewGiayXacNhanChuongTrinh(int index,string name)
        {
            return new GiayXacNhanChuongTrinh();
        }
		
        public static GiayXacNhanChuongTrinh GetGiayXacNhanChuongTrinh(int maGiayXacNhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayXacNhanChuongTrinh");
            return DataPortal.Fetch<GiayXacNhanChuongTrinh>(new Criteria(maGiayXacNhan));
        }
		public static void DeleteGiayXacNhanChuongTrinh(int maGiayXacNhan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a GiayXacNhanChuongTrinh");
			DataPortal.Delete(new Criteria(maGiayXacNhan));
		}

		public override GiayXacNhanChuongTrinh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a GiayXacNhanChuongTrinh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a GiayXacNhanChuongTrinh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a GiayXacNhanChuongTrinh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static GiayXacNhanChuongTrinh NewGiayXacNhanChuongTrinhChild()
		{
			GiayXacNhanChuongTrinh child = new GiayXacNhanChuongTrinh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static GiayXacNhanChuongTrinh GetGiayXacNhanChuongTrinh(SafeDataReader dr)
		{
			GiayXacNhanChuongTrinh child =  new GiayXacNhanChuongTrinh();
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
			public int MaGiayXacNhan;
           
			public Criteria(int maGiayXacNhan)
			{
				this.MaGiayXacNhan = maGiayXacNhan;
              
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
                cm.CommandText = "spd_SelecttblnsGiayXacNhanChuongTrinh";

				cm.Parameters.AddWithValue("@MaGiayXacNhan",((Criteria) criteria).MaGiayXacNhan);
              
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
			DataPortal_Delete(new Criteria(_maGiayXacNhan));
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
                cm.CommandText = "spd_DeletetblnsGiayXacNhanChuongTrinh";
				cm.Parameters.AddWithValue("@MaGiayXacNhan", criteria.MaGiayXacNhan);

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
			_maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
			_maGiayXacNhanQL = dr.GetString("MaGiayXacNhanQL");
			_tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
			_maChuongTrinh = dr.GetInt32("MaChuongTrinh");
			_soChuongTrinh = dr.GetString("SoChuongTrinh");
			_ngayPhatSong = dr.GetSmartDate("NgayPhatSong", _ngayPhatSong.EmptyIsMin);
			_soHopDong = dr.GetString("SoHopDong");
			_maDonViXacNhanDi = dr.GetInt32("MaDonViXacNhanDi");
			
			_nguoiLap = dr.GetInt32("NguoiLap");
            object soTien = dr.GetValue("SoTien");

            if (soTien != null)
                _soTien = (decimal)soTien;
            else
                _soTien = null;
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_trangThai = dr.GetBoolean("TrangThai");
            _ghiChu = dr.GetString("GhiChu");
            _tenChuongTrinh = dr.GetString("TenChuongTrinh");
		}

		private void FetchChildren(SafeDataReader dr)
		{
			//dr.NextResult();
			_chiTietGiayXacNhanList = ChiTietGiayXacNhanList.GetChiTietGiayXacNhanList(_maGiayXacNhan);
		}
		#endregion //Data Access - Fetch
        
		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, GiayXacNhanChuongTrinhList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, GiayXacNhanChuongTrinhList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsGiayXacNhanChuongTrinh";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maGiayXacNhan = (int)cm.Parameters["@MaGiayXacNhan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, GiayXacNhanChuongTrinhList parent)
		{
         
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maGiayXacNhanQL.Length > 0)
				cm.Parameters.AddWithValue("@MaGiayXacNhanQL", _maGiayXacNhanQL);
			else
				cm.Parameters.AddWithValue("@MaGiayXacNhanQL", DBNull.Value);
			if (_tenGiayXacNhan.Length > 0)
				cm.Parameters.AddWithValue("@TenGiayXacNhan", _tenGiayXacNhan);
			else
				cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
			if (_maChuongTrinh != 0)
				cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			else
				cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
			if (_soChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@SoChuongTrinh", _soChuongTrinh);
			else
				cm.Parameters.AddWithValue("@SoChuongTrinh", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayPhatSong", _ngayPhatSong.DBValue);
			if (_soHopDong.Length > 0)
				cm.Parameters.AddWithValue("@SoHopDong", _soHopDong);
			else
				cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);
			if (_maDonViXacNhanDi != 0)
				cm.Parameters.AddWithValue("@MaDonViXacNhanDi", _maDonViXacNhanDi);
			else
				cm.Parameters.AddWithValue("@MaDonViXacNhanDi", DBNull.Value);
			
				
			
			
				cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
		
			if (_soTien == null)
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            else
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			
				
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_trangThai != false)
				cm.Parameters.AddWithValue("@TrangThai", _trangThai);
			else
				cm.Parameters.AddWithValue("@TrangThai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaGiayXacNhan", _maGiayXacNhan);
			cm.Parameters["@MaGiayXacNhan"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            if (_tenChuongTrinh.Length> 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, GiayXacNhanChuongTrinhList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, GiayXacNhanChuongTrinhList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsGiayXacNhanChuongTrinh";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, GiayXacNhanChuongTrinhList parent)
		{
			cm.Parameters.AddWithValue("@MaGiayXacNhan", _maGiayXacNhan);
			if (_maGiayXacNhanQL.Length > 0)
				cm.Parameters.AddWithValue("@MaGiayXacNhanQL", _maGiayXacNhanQL);
			else
				cm.Parameters.AddWithValue("@MaGiayXacNhanQL", DBNull.Value);
			if (_tenGiayXacNhan.Length > 0)
				cm.Parameters.AddWithValue("@TenGiayXacNhan", _tenGiayXacNhan);
			else
				cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
			if (_maChuongTrinh != 0)
				cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			else
				cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
			if (_soChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@SoChuongTrinh", _soChuongTrinh);
			else
				cm.Parameters.AddWithValue("@SoChuongTrinh", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayPhatSong", _ngayPhatSong.DBValue);
			if (_soHopDong.Length > 0)
				cm.Parameters.AddWithValue("@SoHopDong", _soHopDong);
			else
				cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);
			if (_maDonViXacNhanDi != 0)
				cm.Parameters.AddWithValue("@MaDonViXacNhanDi", _maDonViXacNhanDi);
			else
				cm.Parameters.AddWithValue("@MaDonViXacNhanDi", DBNull.Value);
			
			
			
            cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            if (_soTien == null)
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@SoTien", _soTien);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_trangThai != false)
				cm.Parameters.AddWithValue("@TrangThai", _trangThai);
			else
				cm.Parameters.AddWithValue("@TrangThai", DBNull.Value);
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            if (_tenChuongTrinh.Length> 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_chiTietGiayXacNhanList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

            
             _chiTietGiayXacNhanList.Clear();
            UpdateChildren(tr);
			ExecuteDelete(tr, new Criteria(_maGiayXacNhan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access

        public static GiayXacNhanChuongTrinh NewGiayXacNhanChuongTrinh(string p)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public static string KiemTraSoChungTuMoiNhat( int nam)
        {

            string kq = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[spd_laySoXacNhanMoiNhat]";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@Nam", nam);
                    int so = 0;
                    so = (int)cm.ExecuteScalar();
                    so++;
                    kq = so.ToString();
                }
            }
            return kq;
        }

        public static string LaySoChungTuMax( int _nam)
        {
            string strSoMoi = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spd_LaySoXacNhanMax";
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);              
                cm.Parameters.AddWithValue("@Nam", _nam);
                strSoMoi = Convert.ToString(cm.ExecuteScalar());               
                cn.Close();
            }
            if (strSoMoi == "")
            {
                strSoMoi = "1";
            }
            int len = strSoMoi.Length;
            while (len < 4)
            {
                strSoMoi = "0" + strSoMoi;
                len = strSoMoi.Length;
            }
            strSoMoi = strSoMoi + "XN/" + ERP_Library.Security.CurrentUser.Info.MaQLUser + "/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);
            return strSoMoi + "/" + _nam.ToString();
        }
    }
}
