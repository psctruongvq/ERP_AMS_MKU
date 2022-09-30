
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NganHang : Csla.BusinessBase<NganHang>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNganHang = 0;
		private string _maQuanLy = string.Empty;
		private string _tenNganHang = string.Empty;
		private string _tenVietTat = string.Empty;
        private string _tenChiNhanh = string.Empty;
        private string _tenTinhThanh = string.Empty;
        private int _maTinhThanh = 0;
        private bool _chon = false;
        private long _maNhomNganHang = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNganHang
		{
			get
			{
				CanReadProperty("MaNganHang", true);
				return _maNganHang;
			}
		}

		public string MaQuanLy
		{
			get
			{
				CanReadProperty("MaQuanLy", true);
				return _maQuanLy;
			}
			set
			{
				CanWriteProperty("MaQuanLy", true);
				if (value == null) value = string.Empty;
				if (!_maQuanLy.Equals(value))
				{
					_maQuanLy = value;
					PropertyHasChanged("MaQuanLy");
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

		public string TenVietTat
		{
			get
			{
				CanReadProperty("TenVietTat", true);
				return _tenVietTat;
			}
			set
			{
				CanWriteProperty("TenVietTat", true);
				if (value == null) value = string.Empty;
				if (!_tenVietTat.Equals(value))
				{
					_tenVietTat = value;
					PropertyHasChanged("TenVietTat");
				}
			}
		}


        public string TenChiNhanh
        {
            get
            {
                CanReadProperty("TenChiNhanh", true);
                return _tenChiNhanh;
            }
            set
            {
                CanWriteProperty("TenChiNhanh", true);
                if (value == null) value = string.Empty;
                if (!_tenChiNhanh.Equals(value))
                {
                    _tenChiNhanh = value;
                    PropertyHasChanged("TenChiNhanh");
                }
            }
        }

        public string TenTinhThanh
        {
            get
            {
                CanReadProperty("TenTinhThanh", true);
                return _tenTinhThanh;
            }
            set
            {
                CanWriteProperty("TenTinhThanh", true);
                if (value == null) value = string.Empty;
                if (!_tenTinhThanh.Equals(value))
                {
                    _tenTinhThanh = value;
                    PropertyHasChanged("TenTinhThanh");
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

        public long MaNhomNganHang
        {
            get
            {
                CanReadProperty("MaNhomNganHang", true);
                return _maNhomNganHang;
            }
            set
            {
                CanWriteProperty("MaNhomNganHang", true);
                if (!_maNhomNganHang.Equals(value))
                {
                    _maNhomNganHang = value;
                    PropertyHasChanged("MaTinhThanh");
                }
            }
        }


        public bool Chon
        {
            get
            {
                CanReadProperty("Chon", true);
                return _chon;
            }
            set
            {
                CanWriteProperty("Chon", true);
                if (!_chon.Equals(value))
                {
                    _chon = value;
                    PropertyHasChanged("Chon");
                }
            }
        }
		protected override object GetIdValue()
		{
			return _maNganHang;
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
			// MaQuanLy
			//
            
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
			//
			// TenNganHang
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNganHang", 200));
			//
			// TenVietTat
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenVietTat", 100));
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
			//TODO: Define authorization rules in NganHang
			//AuthorizationRules.AllowRead("MaNganHang", "NganHangReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "NganHangReadGroup");
			//AuthorizationRules.AllowRead("TenNganHang", "NganHangReadGroup");
			//AuthorizationRules.AllowRead("TenVietTat", "NganHangReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "NganHangWriteGroup");
			//AuthorizationRules.AllowWrite("TenNganHang", "NganHangWriteGroup");
			//AuthorizationRules.AllowWrite("TenVietTat", "NganHangWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NganHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NganHangViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NganHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NganHangAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NganHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NganHangEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NganHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NganHangDeleteGroup"))
			//	return true;
			//return false;
		}

        #region Override
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty ;

            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid ;

            }
        }
        #endregion
		#endregion //Authorization Rules

		#region Factory Methods
		private NganHang()
		{ /* require use of factory method */ }
        private NganHang(int maNganHang, string tenNganHang)
        {
            this._maNganHang = maNganHang;
            this._tenNganHang = tenNganHang;
        }
		public static NganHang NewNganHang()
		{
            NganHang item = new NganHang();
            item.MarkAsChild();
            return item;
		}
        public static NganHang NewNganHang(int maNganHang, string teNganHang)
        {
            return new NganHang(maNganHang, teNganHang);
        }


		public static NganHang GetNganHang(int maNganHang)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NganHang");
			return DataPortal.Fetch<NganHang>(new Criteria(maNganHang));
		}

		public static void DeleteNganHang(int maNganHang)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NganHang");
			DataPortal.Delete(new Criteria(maNganHang));
		}

		public override NganHang Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NganHang");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NganHang");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a NganHang");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NganHang NewNganHangChild()
		{
			NganHang child = new NganHang();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NganHang GetNganHang(SafeDataReader dr)
		{
			NganHang child =  new NganHang();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}

        internal static NganHang GetNganHang_CoNhom(SafeDataReader dr)
        {
            NganHang child = new NganHang();
            child.MarkAsChild();
            child.Fetch_ByNhom(dr);
            return child;
        }

        public static string SetMaQuanLy()
        {
            string maQuanLy = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SetMaQuanLyNganHang";
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    maQuanLy = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return maQuanLy;

        }

        public static bool KiemTraTrungMaQuanLy(int maNganHang, string maQuanLy)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraTrungMaQuanLy";
                    cm.Parameters.AddWithValue("@MaNganHang", maNganHang);
                    cm.Parameters.AddWithValue("@MaQuanLy", maQuanLy);
                    SqlParameter outPara = new SqlParameter("@TrungMaQuanLy", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }//end function
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaNganHang;

			public Criteria(int maNganHang)
			{
				this.MaNganHang = maNganHang;
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
		private void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsNganHang";

				cm.Parameters.AddWithValue("@MaNganHang", criteria.MaNganHang);

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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn);

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				if (base.IsDirty)
				{
					ExecuteUpdate(cn);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maNganHang));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteDelete(cn, criteria);

			}//using

		}

		private void ExecuteDelete(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsNganHang";

				cm.Parameters.AddWithValue("@MaNganHang", criteria.MaNganHang);

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

        private void Fetch_ByNhom(SafeDataReader dr)
        {
            FetchObject_ByNhom(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject_ByNhom(SafeDataReader dr)
		{
			_maNganHang = dr.GetInt32("MaNganHang");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenNganHang = dr.GetString("TenNganHang");
			_tenVietTat = dr.GetString("TenVietTat");
            _tenChiNhanh = dr.GetString("TenChiNhanh");           
            _tenTinhThanh = dr.GetString("TenTinhThanh");
            _maNhomNganHang = dr.GetInt64("MaNhomNganHang");
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maNganHang = dr.GetInt32("MaNganHang");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenNganHang = dr.GetString("TenNganHang");
			_tenVietTat = dr.GetString("TenVietTat");
            _tenChiNhanh = dr.GetString("TenChiNhanh");           
            _tenTinhThanh = dr.GetString("TenTinhThanh");
            _maNhomNganHang = dr.GetInt64("MaNhomNganHang");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsNganHang";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maNganHang = (int)cm.Parameters["@MaNganHang"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenNganHang.Length > 0)
				cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
			else
				cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
			if (_tenVietTat.Length > 0)
				cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
			else
				cm.Parameters.AddWithValue("@TenVietTat", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            if (_tenChiNhanh.Length > 0)
                cm.Parameters.AddWithValue("@TenChiNhanh", _tenChiNhanh);
            else
                cm.Parameters.AddWithValue("@TenChiNhanh", DBNull.Value);

            if (_maTinhThanh!= 0)
                cm.Parameters.AddWithValue("@MaTinhThanh", _tenTinhThanh);
            else
                cm.Parameters.AddWithValue("@MaTinhThanh", DBNull.Value);
            if (_maNhomNganHang != 0)
                cm.Parameters.AddWithValue("@maNhomNganHang", _maNhomNganHang);
            else
                cm.Parameters.AddWithValue("@maNhomNganHang", DBNull.Value);
			cm.Parameters["@MaNganHang"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn)
		{
            try
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdatetblnsNganHang";

                    AddUpdateParameters(cm);

                    cm.ExecuteNonQuery();

                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenNganHang.Length > 0)
				cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
			else
				cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
			if (_tenVietTat.Length > 0)
				cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
			else
				cm.Parameters.AddWithValue("@TenVietTat", DBNull.Value);
            if (_maTinhThanh !=0)
                cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
            else
                cm.Parameters.AddWithValue("@MaTinhThanh", DBNull.Value);
            if (_tenChiNhanh.Length > 0)
                cm.Parameters.AddWithValue("@TenChiNhanh", _tenChiNhanh);
            else
                cm.Parameters.AddWithValue("@TenChiNhanh", DBNull.Value);
            if (_maNhomNganHang != 0)
                cm.Parameters.AddWithValue("@maNhomNganHang", _maNhomNganHang);
            else
                cm.Parameters.AddWithValue("@maNhomNganHang", DBNull.Value);
		}

		private void UpdateChildren(SqlConnection cn)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlConnection cn)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(cn, new Criteria(_maNganHang));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
        #region LayMaQuanLyNganHangLonNhat
        internal static string LayMaQuanLyNganHangLonNhat()
        {
            string giaTriTraVe = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayMaQuanLyNganHangLonNhat";
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
        #region MaQuanLyNganHang
        public static string MaQuanLyNganHang()
        {
            string MaNganHangLonNhat;
            int temp = 0;
            string GiaTriTraVe;

            MaNganHangLonNhat = LayMaQuanLyNganHangLonNhat();

            if (MaNganHangLonNhat != "")
            {
                try
                {
                    temp = Convert.ToInt32(MaNganHangLonNhat);
                }
                catch (Exception ex)
                {
                    temp = 0;
                }
                temp = temp + 1;

                GiaTriTraVe = temp.ToString();

                return GiaTriTraVe;
            }
            else
                return "";
        }
        #endregion
        #region TenVietTatNganHang
        public static string TenVietTatNganHang()
        {
            string MaQuanLyNganHangLonNhat;
            int temp = 0;
            string GiaTriTraVe;

            MaQuanLyNganHangLonNhat = LayMaQuanLyNganHangLonNhat();

            if (MaQuanLyNganHangLonNhat != "")
            {
                try
                {
                    temp = Convert.ToInt32(MaQuanLyNganHangLonNhat);
                }
                catch (Exception ex)
                {
                    temp = 0;
                }
                temp = temp + 1;

                string chuoiXuLy = "NH";

                GiaTriTraVe = chuoiXuLy + temp.ToString();

                return GiaTriTraVe;
            }
            else
                return "";
        }
        #endregion
    }
}
