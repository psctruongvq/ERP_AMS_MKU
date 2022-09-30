
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThueTNCN : Csla.BusinessBase<ThueTNCN>
	{
		#region Business Properties and Methods

		//declare members
		private int _iDThueThuNhapCaNhan = 0;
		private decimal _tongThuNhapTaiCongTy = 0;
		private decimal _thuNhapChiuThueTaiCongTy = 0;
		private decimal _thuNhapKhongChiuThueTaiCongTy = 0;
		private decimal _tongThuNhapNgoai = 0;
		private decimal _thuNhapChiuThueNgoai = 0;
		private decimal _thuNhapKhongChiuThueNgoai = 0;
		private decimal _soTienGiamTruGiaCanh = 0;
		private decimal _tienThuePhaiNop = 0;
		private decimal _thuNhapSauThue = 0;
		private long _maNhanVien = 0;
		private int _maKyTinhLuong = 0;
        private string _tenNhanVien = string.Empty;
		[System.ComponentModel.DataObjectField(true, true)]
		public int IDThueThuNhapCaNhan
		{
			get
			{
				CanReadProperty("IDThueThuNhapCaNhan", true);
				return _iDThueThuNhapCaNhan;
			}
		}

		public decimal TongThuNhapTaiCongTy
		{
			get
			{
				CanReadProperty("TongThuNhapTaiCongTy", true);
				return _tongThuNhapTaiCongTy;
			}
            set
            {
                CanWriteProperty("TongThuNhapTaiCongTy", true);
                if (!_tongThuNhapTaiCongTy.Equals(value))
                {
                    _tongThuNhapTaiCongTy = value;
                    PropertyHasChanged("TongThuNhapTaiCongTy");
                }
            }
		}

		public decimal ThuNhapChiuThueTaiCongTy
		{
			get
			{
				CanReadProperty("ThuNhapChiuThueTaiCongTy", true);
				return _thuNhapChiuThueTaiCongTy;
			}
            set
            {
                CanWriteProperty("ThuNhapChiuThueTaiCongTy", true);
                if (!_thuNhapChiuThueTaiCongTy.Equals(value))
                {
                    _thuNhapChiuThueTaiCongTy = value;
                    PropertyHasChanged("ThuNhapChiuThueTaiCongTy");
                }
            }
		}

		public decimal ThuNhapKhongChiuThueTaiCongTy
		{
			get
			{
				CanReadProperty("ThuNhapKhongChiuThueTaiCongTy", true);
				return _thuNhapKhongChiuThueTaiCongTy;
			}
            //set
            //{
            //    CanWriteProperty("ThuNhapKhongChiuThueTaiCongTy", true);
            //    if (!_thuNhapKhongChiuThueTaiCongTy.Equals(value))
            //    {
            //        _thuNhapKhongChiuThueTaiCongTy = value;
            //        PropertyHasChanged("ThuNhapKhongChiuThueTaiCongTy");
            //    }
            //}
		}

		public decimal TongThuNhapNgoai
		{
			get
			{
				CanReadProperty("TongThuNhapNgoai", true);
				return _tongThuNhapNgoai;
			}
			set
			{
				CanWriteProperty("TongThuNhapNgoai", true);
				if (!_tongThuNhapNgoai.Equals(value))
				{
					_tongThuNhapNgoai = value;
					PropertyHasChanged("TongThuNhapNgoai");
				}
			}
		}

		public decimal ThuNhapChiuThueNgoai
		{
			get
			{
				CanReadProperty("ThuNhapChiuThueNgoai", true);
				return _thuNhapChiuThueNgoai;
			}
			set
			{
				CanWriteProperty("ThuNhapChiuThueNgoai", true);
				if (!_thuNhapChiuThueNgoai.Equals(value))
				{
					_thuNhapChiuThueNgoai = value;
					PropertyHasChanged("ThuNhapChiuThueNgoai");
				}
			}
		}

		public decimal ThuNhapKhongChiuThueNgoai
		{
			get
			{
				CanReadProperty("ThuNhapKhongChiuThueNgoai", true);
				return _thuNhapKhongChiuThueNgoai;
			}
			set
			{
				CanWriteProperty("ThuNhapKhongChiuThueNgoai", true);
				if (!_thuNhapKhongChiuThueNgoai.Equals(value))
				{
					_thuNhapKhongChiuThueNgoai = value;
					PropertyHasChanged("ThuNhapKhongChiuThueNgoai");
				}
			}
		}

		public decimal SoTienGiamTruGiaCanh
		{
			get
			{
				CanReadProperty("SoTienGiamTruGiaCanh", true);
				return _soTienGiamTruGiaCanh;
			}
            set
            {
                CanWriteProperty("SoTienGiamTruGiaCanh", true);
                if (!_soTienGiamTruGiaCanh.Equals(value))
                {
                    _soTienGiamTruGiaCanh = value;
                    PropertyHasChanged("SoTienGiamTruGiaCanh");
                }
            }
		}

		public decimal TienThuePhaiNop
		{
			get
			{
				CanReadProperty("TienThuePhaiNop", true);
				return _tienThuePhaiNop;
			}
            //set
            //{
            //    CanWriteProperty("TienThuePhaiNop", true);
            //    if (!_tienThuePhaiNop.Equals(value))
            //    {
            //        _tienThuePhaiNop = value;
            //        PropertyHasChanged("TienThuePhaiNop");
            //    }
            //}
		}

		public decimal ThuNhapSauThue
		{
			get
			{
				CanReadProperty("ThuNhapSauThue", true);
				return _thuNhapSauThue;
			}
            //set
            //{
            //    CanWriteProperty("ThuNhapSauThue", true);
            //    if (!_thuNhapSauThue.Equals(value))
            //    {
            //        _thuNhapSauThue = value;
            //        PropertyHasChanged("ThuNhapSauThue");
            //    }
            //}
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
                    _tenNhanVien = NhanVien.GetNhanVien(_maNhanVien).TenNhanVien;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}
        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                _tenNhanVien = NhanVien.GetNhanVien(_maNhanVien).TenNhanVien;
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
		public int MaKyTinhLuong
		{
			get
			{
				CanReadProperty("MaKyTinhLuong", true);
				return _maKyTinhLuong;
			}
			set
			{
				CanWriteProperty("MaKyTinhLuong", true);
				if (!_maKyTinhLuong.Equals(value))
				{
					_maKyTinhLuong = value;
					PropertyHasChanged("MaKyTinhLuong");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _iDThueThuNhapCaNhan;
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
			//TODO: Define authorization rules in ThueTNCN
			//AuthorizationRules.AllowRead("IDThueThuNhapCaNhan", "ThueTNCNReadGroup");
			//AuthorizationRules.AllowRead("TongThuNhapTaiCongTy", "ThueTNCNReadGroup");
			//AuthorizationRules.AllowRead("ThuNhapChiuThueTaiCongTy", "ThueTNCNReadGroup");
			//AuthorizationRules.AllowRead("ThuNhapKhongChiuThueTaiCongTy", "ThueTNCNReadGroup");
			//AuthorizationRules.AllowRead("TongThuNhapNgoai", "ThueTNCNReadGroup");
			//AuthorizationRules.AllowRead("ThuNhapChiuThueNgoai", "ThueTNCNReadGroup");
			//AuthorizationRules.AllowRead("ThuNhapKhongChiuThueNgoai", "ThueTNCNReadGroup");
			//AuthorizationRules.AllowRead("SoTienGiamTruGiaCanh", "ThueTNCNReadGroup");
			//AuthorizationRules.AllowRead("TienThuePhaiNop", "ThueTNCNReadGroup");
			//AuthorizationRules.AllowRead("ThuNhapSauThue", "ThueTNCNReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "ThueTNCNReadGroup");
			//AuthorizationRules.AllowRead("MaKyTinhLuong", "ThueTNCNReadGroup");

			//AuthorizationRules.AllowWrite("TongThuNhapTaiCongTy", "ThueTNCNWriteGroup");
			//AuthorizationRules.AllowWrite("ThuNhapChiuThueTaiCongTy", "ThueTNCNWriteGroup");
			//AuthorizationRules.AllowWrite("ThuNhapKhongChiuThueTaiCongTy", "ThueTNCNWriteGroup");
			//AuthorizationRules.AllowWrite("TongThuNhapNgoai", "ThueTNCNWriteGroup");
			//AuthorizationRules.AllowWrite("ThuNhapChiuThueNgoai", "ThueTNCNWriteGroup");
			//AuthorizationRules.AllowWrite("ThuNhapKhongChiuThueNgoai", "ThueTNCNWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienGiamTruGiaCanh", "ThueTNCNWriteGroup");
			//AuthorizationRules.AllowWrite("TienThuePhaiNop", "ThueTNCNWriteGroup");
			//AuthorizationRules.AllowWrite("ThuNhapSauThue", "ThueTNCNWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "ThueTNCNWriteGroup");
			//AuthorizationRules.AllowWrite("MaKyTinhLuong", "ThueTNCNWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThueTNCN
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTNCNViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThueTNCN
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTNCNAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThueTNCN
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTNCNEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThueTNCN
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTNCNDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThueTNCN()
		{ /* require use of factory method */ }

		public static ThueTNCN NewThueTNCN()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThueTNCN");
			return DataPortal.Create<ThueTNCN>();
		}

		public static ThueTNCN GetThueTNCN(int iDThueThuNhapCaNhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThueTNCN");
			return DataPortal.Fetch<ThueTNCN>(new Criteria(iDThueThuNhapCaNhan));
		}

		public static void DeleteThueTNCN(int iDThueThuNhapCaNhan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThueTNCN");
			DataPortal.Delete(new Criteria(iDThueThuNhapCaNhan));
		}

		public override ThueTNCN Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThueTNCN");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThueTNCN");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ThueTNCN");

			return base.Save();
		}
        public static void XuLyThueTNCN(int maKyTinhLuong, long maNhanVien)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_XuLyThueTNCN";
                        cm.Parameters.AddWithValue("@MaNhanVien",maNhanVien);
                        cm.Parameters.AddWithValue("@MaKyTinhLuong",maKyTinhLuong);
                        cm.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        public static void CapNhatThueVaThuNhap(int MaKyLuong)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_CapNhatThuNhapConLai";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", MaKyLuong);
                        cm.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        public static decimal SoTienGiamTruGiacanh(long maNhanVien)
        {

            decimal gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SoTienGiamTruGiaCanh";
                        cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        cm.Parameters.AddWithValue("@SoTienGiamTruGiaCanh", gt);
                        cm.Parameters["@SoTienGiamTruGiaCanh"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (decimal)cm.Parameters["@SoTienGiamTruGiaCanh"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ThueTNCN NewThueTNCNChild()
		{
			ThueTNCN child = new ThueTNCN();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ThueTNCN GetThueTNCN(SafeDataReader dr)
		{
			ThueTNCN child =  new ThueTNCN();
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
			public int IDThueThuNhapCaNhan;

			public Criteria(int iDThueThuNhapCaNhan)
			{
				this.IDThueThuNhapCaNhan = iDThueThuNhapCaNhan;
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
                cm.CommandText = "spd_SelecttblnsThueThuNhapCaNhan";

				cm.Parameters.AddWithValue("@IDThueThuNhapCaNhan", criteria.IDThueThuNhapCaNhan);

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
			DataPortal_Delete(new Criteria(_iDThueThuNhapCaNhan));
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
                cm.CommandText = "spd_DeletetblnsThueThuNhapCaNhan";

				cm.Parameters.AddWithValue("@IDThueThuNhapCaNhan", criteria.IDThueThuNhapCaNhan);

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
			_iDThueThuNhapCaNhan = dr.GetInt32("IDThueThuNhapCaNhan");
			_tongThuNhapTaiCongTy = dr.GetDecimal("TongThuNhapTaiCongTy");
			_thuNhapChiuThueTaiCongTy = dr.GetDecimal("ThuNhapChiuThueTaiCongTy");
			_thuNhapKhongChiuThueTaiCongTy = dr.GetDecimal("ThuNhapKhongChiuThueTaiCongTy");
			_tongThuNhapNgoai = dr.GetDecimal("TongThuNhapNgoai");
			_thuNhapChiuThueNgoai = dr.GetDecimal("ThuNhapChiuThueNgoai");
			_thuNhapKhongChiuThueNgoai = dr.GetDecimal("ThuNhapKhongChiuThueNgoai");
			_soTienGiamTruGiaCanh = dr.GetDecimal("SoTienGiamTruGiaCanh");
			_tienThuePhaiNop = dr.GetDecimal("TienThuePhaiNop");
			_thuNhapSauThue = dr.GetDecimal("ThuNhapSauThue");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ThueTNCNList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ThueTNCNList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsThueThuNhapCaNhan";
				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_iDThueThuNhapCaNhan = (int)cm.Parameters["@IDThueThuNhapCaNhan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ThueTNCNList parent)
		{
			cm.Parameters.AddWithValue("@TongThuNhapNgoai", _tongThuNhapNgoai);			
			cm.Parameters.AddWithValue("@ThuNhapChiuThueNgoai", _thuNhapChiuThueNgoai);
            cm.Parameters.AddWithValue("@SoTienGiamTruGiaCanh", _soTienGiamTruGiaCanh);
            cm.Parameters.AddWithValue("@TongThuNhapTaiCongTy", _tongThuNhapTaiCongTy);
            cm.Parameters.AddWithValue("@ThuNhapChiuThueTaiCongTy", _thuNhapChiuThueTaiCongTy);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			cm.Parameters.AddWithValue("@IDThueThuNhapCaNhan", _iDThueThuNhapCaNhan);
			cm.Parameters["@IDThueThuNhapCaNhan"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ThueTNCNList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ThueTNCNList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsThueThuNhapCaNhan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, ThueTNCNList parent)
        {
            cm.Parameters.AddWithValue("@IDThueThuNhapCaNhan", _iDThueThuNhapCaNhan);
            cm.Parameters.AddWithValue("@TongThuNhapNgoai", _tongThuNhapNgoai);
            cm.Parameters.AddWithValue("@ThuNhapChiuThueNgoai", _thuNhapChiuThueNgoai);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
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

			ExecuteDelete(tr, new Criteria(_iDThueThuNhapCaNhan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
