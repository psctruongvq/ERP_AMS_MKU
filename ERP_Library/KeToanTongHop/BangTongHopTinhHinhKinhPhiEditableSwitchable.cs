
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangTongHopTinhHinhKinhPhi : Csla.BusinessBase<BangTongHopTinhHinhKinhPhi>
	{
		#region Business Properties and Methods

		//declare members
		private int _maMucTaiKhoan = 0;
		private string _tenMucTaiKhoan = string.Empty;
		private string _maSo = string.Empty;
		private int _maMucTaiKhoanCha = 0;
		private byte _capMuc = 0;
		private int _soTTTinhToan = 0;
		private int _soTTSapXep = 0;
		private byte _format = 1;
		private byte _loai = 0;
		private int _maCongTy = 0;
        private byte _loaiMau = 1;

		//declare child member(s)
		private CT_MauBangBaoCaoList _cT_MauBangBaoCaoList = CT_MauBangBaoCaoList.NewCT_MauBangBaoCaoList();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaMucTaiKhoan
		{
			get
			{
				CanReadProperty("MaMucTaiKhoan", true);
				return _maMucTaiKhoan;
			}
		}

		public string TenMucTaiKhoan
		{
			get
			{
				CanReadProperty("TenMucTaiKhoan", true);
				return _tenMucTaiKhoan;
			}
			set
			{
				CanWriteProperty("TenMucTaiKhoan", true);
				if (value == null) value = string.Empty;
				if (!_tenMucTaiKhoan.Equals(value))
				{
					_tenMucTaiKhoan = value;
					PropertyHasChanged("TenMucTaiKhoan");
				}
			}
		}

		public string MaSo
		{
			get
			{
				CanReadProperty("MaSo", true);
				return _maSo;
			}
			set
			{
				CanWriteProperty("MaSo", true);
				if (value == null) value = string.Empty;
				if (!_maSo.Equals(value))
				{
					_maSo = value;
					PropertyHasChanged("MaSo");
				}
			}
		}

		public int MaMucTaiKhoanCha
		{
			get
			{
				CanReadProperty("MaMucTaiKhoanCha", true);
				return _maMucTaiKhoanCha;
			}
			set
			{
				CanWriteProperty("MaMucTaiKhoanCha", true);
				if (!_maMucTaiKhoanCha.Equals(value))
				{
					_maMucTaiKhoanCha = value;
					PropertyHasChanged("MaMucTaiKhoanCha");
				}
			}
		}

		public byte CapMuc
		{
			get
			{
				CanReadProperty("CapMuc", true);
				return _capMuc;
			}
			set
			{
				CanWriteProperty("CapMuc", true);
				if (!_capMuc.Equals(value))
				{
					_capMuc = value;
					PropertyHasChanged("CapMuc");
				}
			}
		}

		public int SoTTTinhToan
		{
			get
			{
				CanReadProperty("SoTTTinhToan", true);
				return _soTTTinhToan;
			}
			set
			{
				CanWriteProperty("SoTTTinhToan", true);
				if (!_soTTTinhToan.Equals(value))
				{
					_soTTTinhToan = value;
					PropertyHasChanged("SoTTTinhToan");
				}
			}
		}

		public int SoTTSapXep
		{
			get
			{
				CanReadProperty("SoTTSapXep", true);
				return _soTTSapXep;
			}
			set
			{
				CanWriteProperty("SoTTSapXep", true);
				if (!_soTTSapXep.Equals(value))
				{
					_soTTSapXep = value;
					PropertyHasChanged("SoTTSapXep");
				}
			}
		}

		public byte Format
		{
			get
			{
				CanReadProperty("Format", true);
				return _format;
			}
			set
			{
				CanWriteProperty("Format", true);
				if (!_format.Equals(value))
				{
					_format = value;
					PropertyHasChanged("Format");
				}
			}
		}

		public byte Loai
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

		public int MaCongTy
		{
			get
			{
				CanReadProperty("MaCongTy", true);
				return _maCongTy;
			}
			set
			{
				CanWriteProperty("MaCongTy", true);
				if (!_maCongTy.Equals(value))
				{
					_maCongTy = value;
					PropertyHasChanged("MaCongTy");
				}
			}
		}


        public byte LoaiMau
        {
            get
            {
                CanReadProperty("LoaiMau", true);
                return _loaiMau;
            }
            set
            {
                CanWriteProperty("LoaiMau", true);
                if (!_loaiMau.Equals(value))
                {
                    _loaiMau = value;
                    PropertyHasChanged("LoaiMau");
                }
            }
        }


		public CT_MauBangBaoCaoList CT_MauBangBaoCaoList
		{
			get
			{
				CanReadProperty("CT_MauBangBaoCaoList", true);
				return _cT_MauBangBaoCaoList;
			}
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _cT_MauBangBaoCaoList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _cT_MauBangBaoCaoList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maMucTaiKhoan;
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
			// TenMucTaiKhoan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenMucTaiKhoan", 1000));
			//
			// MaSo
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaSo", 50));
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
			//TODO: Define authorization rules in BangTongHopTinhHinhKinhPhi
			//AuthorizationRules.AllowRead("CT_MauBangBaoCaoList", "BangTongHopTinhHinhKinhPhiReadGroup");
			//AuthorizationRules.AllowRead("MaMucTaiKhoan", "BangTongHopTinhHinhKinhPhiReadGroup");
			//AuthorizationRules.AllowRead("TenMucTaiKhoan", "BangTongHopTinhHinhKinhPhiReadGroup");
			//AuthorizationRules.AllowRead("MaSo", "BangTongHopTinhHinhKinhPhiReadGroup");
			//AuthorizationRules.AllowRead("MaMucTaiKhoanCha", "BangTongHopTinhHinhKinhPhiReadGroup");
			//AuthorizationRules.AllowRead("CapMuc", "BangTongHopTinhHinhKinhPhiReadGroup");
			//AuthorizationRules.AllowRead("SoTTTinhToan", "BangTongHopTinhHinhKinhPhiReadGroup");
			//AuthorizationRules.AllowRead("SoTTSapXep", "BangTongHopTinhHinhKinhPhiReadGroup");
			//AuthorizationRules.AllowRead("Format", "BangTongHopTinhHinhKinhPhiReadGroup");
			//AuthorizationRules.AllowRead("Loai", "BangTongHopTinhHinhKinhPhiReadGroup");
			//AuthorizationRules.AllowRead("MaCongTy", "BangTongHopTinhHinhKinhPhiReadGroup");

			//AuthorizationRules.AllowWrite("TenMucTaiKhoan", "BangTongHopTinhHinhKinhPhiWriteGroup");
			//AuthorizationRules.AllowWrite("MaSo", "BangTongHopTinhHinhKinhPhiWriteGroup");
			//AuthorizationRules.AllowWrite("MaMucTaiKhoanCha", "BangTongHopTinhHinhKinhPhiWriteGroup");
			//AuthorizationRules.AllowWrite("CapMuc", "BangTongHopTinhHinhKinhPhiWriteGroup");
			//AuthorizationRules.AllowWrite("SoTTTinhToan", "BangTongHopTinhHinhKinhPhiWriteGroup");
			//AuthorizationRules.AllowWrite("SoTTSapXep", "BangTongHopTinhHinhKinhPhiWriteGroup");
			//AuthorizationRules.AllowWrite("Format", "BangTongHopTinhHinhKinhPhiWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "BangTongHopTinhHinhKinhPhiWriteGroup");
			//AuthorizationRules.AllowWrite("MaCongTy", "BangTongHopTinhHinhKinhPhiWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangTongHopTinhHinhKinhPhi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangTongHopTinhHinhKinhPhiViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangTongHopTinhHinhKinhPhi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangTongHopTinhHinhKinhPhiAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangTongHopTinhHinhKinhPhi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangTongHopTinhHinhKinhPhiEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangTongHopTinhHinhKinhPhi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangTongHopTinhHinhKinhPhiDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangTongHopTinhHinhKinhPhi()
		{ /* require use of factory method */ }

		public static BangTongHopTinhHinhKinhPhi NewBangTongHopTinhHinhKinhPhi()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangTongHopTinhHinhKinhPhi");
			return DataPortal.Create<BangTongHopTinhHinhKinhPhi>();
		}

		public static BangTongHopTinhHinhKinhPhi GetBangTongHopTinhHinhKinhPhi(int maMucTaiKhoan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangTongHopTinhHinhKinhPhi");
			return DataPortal.Fetch<BangTongHopTinhHinhKinhPhi>(new Criteria(maMucTaiKhoan));
		}

		public static void DeleteBangTongHopTinhHinhKinhPhi(int maMucTaiKhoan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangTongHopTinhHinhKinhPhi");
			DataPortal.Delete(new Criteria(maMucTaiKhoan));
		}

		public override BangTongHopTinhHinhKinhPhi Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangTongHopTinhHinhKinhPhi");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangTongHopTinhHinhKinhPhi");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BangTongHopTinhHinhKinhPhi");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static BangTongHopTinhHinhKinhPhi NewBangTongHopTinhHinhKinhPhiChild()
		{
			BangTongHopTinhHinhKinhPhi child = new BangTongHopTinhHinhKinhPhi();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BangTongHopTinhHinhKinhPhi GetBangTongHopTinhHinhKinhPhi(SafeDataReader dr)
		{
			BangTongHopTinhHinhKinhPhi child =  new BangTongHopTinhHinhKinhPhi();
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
			public int MaMucTaiKhoan;

			public Criteria(int maMucTaiKhoan)
			{
				this.MaMucTaiKhoan = maMucTaiKhoan;
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
                cm.CommandText = "spd_SelecttblBangTongHopTinhHinhKinhPhi";

				cm.Parameters.AddWithValue("@MaMucTaiKhoan", criteria.MaMucTaiKhoan);

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
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maMucTaiKhoan));
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
                cm.CommandText = "spd_DeletetblBangTongHopTinhHinhKinhPhi";

				cm.Parameters.AddWithValue("@MaMucTaiKhoan", criteria.MaMucTaiKhoan);

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
			_maMucTaiKhoan = dr.GetInt32("MaMucTaiKhoan");
			_tenMucTaiKhoan = dr.GetString("TenMucTaiKhoan");
			_maSo = dr.GetString("MaSo");
			_maMucTaiKhoanCha = dr.GetInt32("MaMucTaiKhoanCha");
			_capMuc = dr.GetByte("CapMuc");
			_soTTTinhToan = dr.GetInt32("SoTTTinhToan");
			_soTTSapXep = dr.GetInt32("SoTTSapXep");
			_format = dr.GetByte("Format");
			_loai = dr.GetByte("Loai");
			_maCongTy = dr.GetInt32("MaCongTy");
            _loaiMau = dr.GetByte("LoaiMau");
		}

		private void FetchChildren(SafeDataReader dr)
		{			
			_cT_MauBangBaoCaoList = CT_MauBangBaoCaoList.GetCT_MauBangBaoCaoList(this.MaMucTaiKhoan, _loaiMau);
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
                cm.CommandText = "spd_InserttblBangTongHopTinhHinhKinhPhi";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maMucTaiKhoan = (int)cm.Parameters["@MaMucTaiKhoan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_tenMucTaiKhoan.Length > 0)
				cm.Parameters.AddWithValue("@TenMucTaiKhoan", _tenMucTaiKhoan);
			else
				cm.Parameters.AddWithValue("@TenMucTaiKhoan", DBNull.Value);
			if (_maSo.Length > 0)
				cm.Parameters.AddWithValue("@MaSo", _maSo);
			else
				cm.Parameters.AddWithValue("@MaSo", DBNull.Value);
			if (_maMucTaiKhoanCha != 0)
				cm.Parameters.AddWithValue("@MaMucTaiKhoanCha", _maMucTaiKhoanCha);
			else
				cm.Parameters.AddWithValue("@MaMucTaiKhoanCha", DBNull.Value);
			if (_capMuc != 0)
				cm.Parameters.AddWithValue("@CapMuc", _capMuc);
			else
				cm.Parameters.AddWithValue("@CapMuc", DBNull.Value);
			if (_soTTTinhToan != 0)
				cm.Parameters.AddWithValue("@SoTTTinhToan", _soTTTinhToan);
			else
				cm.Parameters.AddWithValue("@SoTTTinhToan", DBNull.Value);
			if (_soTTSapXep != 0)
				cm.Parameters.AddWithValue("@SoTTSapXep", _soTTSapXep);
			else
				cm.Parameters.AddWithValue("@SoTTSapXep", DBNull.Value);
			if (_format != 0)
				cm.Parameters.AddWithValue("@Format", _format);
			else
				cm.Parameters.AddWithValue("@Format", DBNull.Value);
			if (_loai != 0)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);			
				cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
            cm.Parameters.AddWithValue("@LoaiMau", _loaiMau);			
			cm.Parameters.AddWithValue("@MaMucTaiKhoan", _maMucTaiKhoan);
			cm.Parameters["@MaMucTaiKhoan"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblBangTongHopTinhHinhKinhPhi";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaMucTaiKhoan", _maMucTaiKhoan);
			if (_tenMucTaiKhoan.Length > 0)
				cm.Parameters.AddWithValue("@TenMucTaiKhoan", _tenMucTaiKhoan);
			else
				cm.Parameters.AddWithValue("@TenMucTaiKhoan", DBNull.Value);
			if (_maSo.Length > 0)
				cm.Parameters.AddWithValue("@MaSo", _maSo);
			else
				cm.Parameters.AddWithValue("@MaSo", DBNull.Value);
			if (_maMucTaiKhoanCha != 0)
				cm.Parameters.AddWithValue("@MaMucTaiKhoanCha", _maMucTaiKhoanCha);
			else
				cm.Parameters.AddWithValue("@MaMucTaiKhoanCha", DBNull.Value);
			if (_capMuc != 0)
				cm.Parameters.AddWithValue("@CapMuc", _capMuc);
			else
				cm.Parameters.AddWithValue("@CapMuc", DBNull.Value);
			if (_soTTTinhToan != 0)
				cm.Parameters.AddWithValue("@SoTTTinhToan", _soTTTinhToan);
			else
				cm.Parameters.AddWithValue("@SoTTTinhToan", DBNull.Value);
			if (_soTTSapXep != 0)
				cm.Parameters.AddWithValue("@SoTTSapXep", _soTTSapXep);
			else
				cm.Parameters.AddWithValue("@SoTTSapXep", DBNull.Value);
			if (_format != 0)
				cm.Parameters.AddWithValue("@Format", _format);
			else
				cm.Parameters.AddWithValue("@Format", DBNull.Value);
			if (_loai != 0)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            cm.Parameters.AddWithValue("@LoaiMau", _loaiMau);			
			cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
			
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_cT_MauBangBaoCaoList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(tr, new Criteria(_maMucTaiKhoan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access

        public static int LaySoTTTinhToanMax( byte loaiMau)
        { 
            int GiaTriTraVe =0 ;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayMaxSoTTTinhToanTrongBCTHKPVaQuyetToanKp";
                    SqlParameter parameter = new SqlParameter("@GiaTri",SqlDbType.Int);

                    cm.Parameters.AddWithValue("@LoaiMau", loaiMau);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    parameter.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(parameter);
                    cm.ExecuteNonQuery();
                    GiaTriTraVe = (int)parameter.Value;
                }
            }

            return GiaTriTraVe;
        }


        public static int LaySTTSapXepMax(byte loaiMau)
        {
            int GiaTriTraVe = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayMaxSoTTSXTrongBCTHKPVaQuyetToanKP";
                    SqlParameter parameter = new SqlParameter("@GiaTri", SqlDbType.Int);
                    cm.Parameters.AddWithValue("@LoaiMau", loaiMau);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    parameter.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(parameter);
                    cm.ExecuteNonQuery();
                    GiaTriTraVe = (int)parameter.Value;
                }
            }
            return GiaTriTraVe;
                 
        }
	}
}
