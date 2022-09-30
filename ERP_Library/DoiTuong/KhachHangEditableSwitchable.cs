
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KhachHang : Csla.BusinessBase<KhachHang>
	{
		#region Business Properties and Methods

		//declare members
		private long _maKhachHang = 0;
		private int _maNhomKhachHang = 0;
		private int _maLoaiKhachHang = 0;
        private string _cmnd = string.Empty;
        private Nullable<DateTime> _ngayLap = null;
        private string _noiCap = string.Empty;
        private Nullable<DateTime> _ngaySinh = null;

		//declare child member(s)
		private HanMucTinDungList _hanMucTinDungList = HanMucTinDungList.NewHanMucTinDungList();

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaKhachHang
		{
			get
			{
				CanReadProperty("MaKhachHang", true);
				return _maKhachHang;
			}
		}

		public int MaNhomKhachHang
		{
			get
			{
				CanReadProperty("MaNhomKhachHang", true);
				return _maNhomKhachHang;
			}
			set
			{
				CanWriteProperty("MaNhomKhachHang", true);
				if (!_maNhomKhachHang.Equals(value))
				{
					_maNhomKhachHang = value;
					PropertyHasChanged("MaNhomKhachHang");
				}
			}
		}

		public int MaLoaiKhachHang
		{
			get
			{
				CanReadProperty("MaLoaiKhachHang", true);
				return _maLoaiKhachHang;
			}
			set
			{
				CanWriteProperty("MaLoaiKhachHang", true);
				if (!_maLoaiKhachHang.Equals(value))
				{
					_maLoaiKhachHang = value;
					PropertyHasChanged("MaLoaiKhachHang");
				}
			}
		}

        public string Cmnd
        {
            get
            {
                CanReadProperty("Cmnd", true);
                return _cmnd;
            }
            set
            {
                CanWriteProperty("Cmnd", true);
                if (value == null) value = string.Empty;
                if (!_cmnd.Equals(value))
                {
                    _cmnd = value;
                    PropertyHasChanged("Cmnd");
                }
            }
        }

        public DateTime? NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                if (_ngayLap == null)
                    return null;
                return _ngayLap.Value;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = value;
                    PropertyHasChanged("NgayLap");
                }
            }
        }

        public DateTime? NgaySinh
        {
            get
            {
                CanReadProperty("NgaySinh", true);
                if (_ngaySinh == null)
                    return null;
                return _ngaySinh.Value;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngaySinh.Equals(value))
                {
                    _ngaySinh = value;
                    PropertyHasChanged("NgaySinh");
                }
            }
        }              


        public string NoiCap
        {
            get
            {
                CanReadProperty("NoiCap", true);
                return _noiCap;
            }
            set
            {
                CanWriteProperty("NoiCap", true);
                if (value == null) value = string.Empty;
                if (!_noiCap.Equals(value))
                {
                    _noiCap = value;
                    PropertyHasChanged("NoiCap");
                }
            }
        }

		public HanMucTinDungList HanMucTinDungList
		{
			get
			{
				CanReadProperty("HanMucTinDungList", true);
				return _hanMucTinDungList;
			}
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _hanMucTinDungList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _hanMucTinDungList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maKhachHang;
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
			//TODO: Define authorization rules in KhachHang
			//AuthorizationRules.AllowRead("HanMucTinDungList", "KhachHangReadGroup");
			//AuthorizationRules.AllowRead("MaKhachHang", "KhachHangReadGroup");
			//AuthorizationRules.AllowRead("MaNhomKhachHang", "KhachHangReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiKhachHang", "KhachHangReadGroup");

			//AuthorizationRules.AllowWrite("MaNhomKhachHang", "KhachHangWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiKhachHang", "KhachHangWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KhachHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhachHangViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KhachHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhachHangAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KhachHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhachHangEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KhachHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhachHangDeleteGroup"))
			//	return true;
			//return false;
		}

        public static string LayCMND(long maKH)
        {
            string cmnd = String.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblCMND";
                        cm.Parameters.AddWithValue("@MaKhachHang", maKH);
                        cm.Parameters.AddWithValue("@So", cmnd);
                        cm.Parameters["@So"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        cmnd = (string)cm.Parameters["@So"].Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return cmnd;
            }//using
        }
		#endregion //Authorization Rules

		#region Factory Methods

		private KhachHang()
		{ /* require use of factory method */ }

		public static KhachHang NewKhachHang()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KhachHang");
			return DataPortal.Create<KhachHang>(new CriteriaAll());
		}

		public static KhachHang GetKhachHang(long maKhachHang)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KhachHang");
			return DataPortal.Fetch<KhachHang>(new Criteria(maKhachHang));
		}

		public static void DeleteKhachHang(long maKhachHang)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KhachHang");
			DataPortal.Delete(new Criteria(maKhachHang));
		}

          

		public override KhachHang Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KhachHang");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KhachHang");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a KhachHang");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private KhachHang(long maKhachHang)
		{
			this._maKhachHang = maKhachHang;
		}

		public static KhachHang NewKhachHangChild(long maKhachHang)
		{
			KhachHang child = new KhachHang(maKhachHang);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		public static KhachHang GetKhachHang(SafeDataReader dr)
		{
			KhachHang child =  new KhachHang();
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
			public long MaKhachHang;

			public Criteria(long maKhachHang)
			{
				this.MaKhachHang = maKhachHang;
			}
		}


        [Serializable()]
        private class CriteriaAll
        {
             public CriteriaAll()
            {
                
            }
        }
		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(CriteriaAll criteria)
		{
			//_maKhachHang = criteria.MaKhachHang;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();
				try
				{
					ExecuteFetch(cn, criteria);
				}
				catch
				{
					throw;
				}
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblKhachHang";

				cm.Parameters.AddWithValue("@MaKhachHang", criteria.MaKhachHang);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(this.MaKhachHang);
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
			DataPortal_Delete(new Criteria(_maKhachHang));
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
                cm.CommandText = "spd_DeletetblKhachHang";

				cm.Parameters.AddWithValue("@MaKhachHang", criteria.MaKhachHang);

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
			FetchChildren(this.MaKhachHang);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maKhachHang = dr.GetInt64("MaKhachHang");
			_maNhomKhachHang = dr.GetInt32("MaNhomKhachHang");
			_maLoaiKhachHang = dr.GetInt32("MaLoaiKhachHang");
            _cmnd = dr.GetString("CMND");            
            _noiCap = dr.GetString("NoiCap");
            if (dr.GetValue("NgaySinh") ==null)
                _ngaySinh = null;
            else  _ngaySinh = dr.GetDateTime("NgaySinh");
            if (dr.GetValue("NgayLap") == null)
                _ngayLap = null;
            else _ngayLap = dr.GetDateTime("NgayLap");
		}

		private void FetchChildren(long maKhachHang)
		{			
			_hanMucTinDungList = HanMucTinDungList.GetHanMucTinDungList(maKhachHang);
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
                cm.CommandText = "spd_InserttblKhachHang";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DoiTac parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaKhachHang", parent.MaDoiTac);
			if (_maNhomKhachHang != 0)
				cm.Parameters.AddWithValue("@MaNhomKhachHang", _maNhomKhachHang);
			else
				cm.Parameters.AddWithValue("@MaNhomKhachHang",1);
			if (_maLoaiKhachHang != 0)
				cm.Parameters.AddWithValue("@MaLoaiKhachHang", _maLoaiKhachHang);
			else
				cm.Parameters.AddWithValue("@MaLoaiKhachHang", 1);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);                        
            if (_ngayLap != null)
                cm.Parameters.AddWithValue("@NgayLap", _ngayLap.Value);
            else cm.Parameters.AddWithValue("@NgayLap", DBNull.Value);

            if (_noiCap.Length > 0)
                cm.Parameters.AddWithValue("@NoiCap", _noiCap);
            else
                cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);
            if (_ngaySinh != null) 
                cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh.Value);
            else cm.Parameters.AddWithValue("@NgaySinh", DBNull.Value);
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
                cm.CommandText = "spd_UpdatetblKhachHang";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DoiTac parent)
		{
			cm.Parameters.AddWithValue("@MaKhachHang",parent.MaDoiTac);
			if (_maNhomKhachHang != 0)
				cm.Parameters.AddWithValue("@MaNhomKhachHang", _maNhomKhachHang);
			else
				cm.Parameters.AddWithValue("@MaNhomKhachHang", DBNull.Value);
			if (_maLoaiKhachHang != 0)
				cm.Parameters.AddWithValue("@MaLoaiKhachHang", _maLoaiKhachHang);
			else
				cm.Parameters.AddWithValue("@MaLoaiKhachHang", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_ngayLap != null)
                cm.Parameters.AddWithValue("@NgayLap", _ngayLap.Value);
            else cm.Parameters.AddWithValue("@NgayLap", DBNull.Value);
            if (_noiCap.Length > 0)
                cm.Parameters.AddWithValue("@NoiCap", _noiCap);
            else
                cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);
            if (_ngaySinh != null)
                cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh.Value);
            else cm.Parameters.AddWithValue("@NgaySinh", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_hanMucTinDungList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            _hanMucTinDungList.Clear();
            UpdateChildren(tr);
			ExecuteDelete(tr, new Criteria(_maKhachHang));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access

        #region MaKhachHangTuDongTang
        internal static string MaKhachHangTuDongTang()
        {
            string giaTriTraVe = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayKhachHangLonNhat";
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTri", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    if (prmGiaTriTraVe.Value != null)
                    {
                        giaTriTraVe = (string)prmGiaTriTraVe.Value;
                    }
                }
            }//us
            return giaTriTraVe;
        }
        #endregion

        #region MaKhachHangTuDong
        public static string MaKhachHangTuDong()
        {
            string MaKhachHangLonNhat;
            int temp;
            string GiaTriTraVe;

            MaKhachHangLonNhat = MaKhachHangTuDongTang();
            if (MaKhachHangLonNhat != "")
            {
                temp = Convert.ToInt32(MaKhachHangLonNhat.Substring(4));
                temp = temp + 1;
                if (temp < 10)
                {
                    GiaTriTraVe = MaKhachHangLonNhat.Substring(0, 4) + "000" + temp.ToString();
                }
                else if (temp < 100)
                {
                    GiaTriTraVe = MaKhachHangLonNhat.Substring(0, 4) + "00" + temp.ToString();
                }
                else if (temp < 1000)
                {
                    GiaTriTraVe = MaKhachHangLonNhat.Substring(0, 4) + "0" + temp.ToString();
                }
                else
                {
                    GiaTriTraVe = MaKhachHangLonNhat.Substring(0, 4) + temp.ToString();
                }
                return GiaTriTraVe;
            }
            else
                return "";
        }
        #endregion
	}
}
