
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DotThanhToanHDMB : Csla.BusinessBase<DotThanhToanHDMB>
	{
		#region Business Properties and Methods

		//declare members
		private int _maDotThanhToan = 0;
		private long _maHopDongMuaBan = 0;
		private SmartDate _ngayThanhToan = new SmartDate(DateTime.Now.Date);
		private int _maPhuongThucThanhToan = 0;
		private int _maTaiKhoanDoiTac= 0;		
		private int _maLoaiTien = 0;		
		private decimal _soTien = 0;
        private int _maTaiKhoanCongTy = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaDotThanhToan
		{
			get
			{
				CanReadProperty("MaDotThanhToan", true);
				return _maDotThanhToan;
			}
		}

		public long MaHopDongMuaBan
		{
			get
			{
				CanReadProperty("MaHopDongMuaBan", true);
				return _maHopDongMuaBan;
			}
			set
			{
				CanWriteProperty("MaHopDongMuaBan", true);
				if (!_maHopDongMuaBan.Equals(value))
				{
					_maHopDongMuaBan = value;
					PropertyHasChanged("MaHopDongMuaBan");
				}
			}
		}

		public DateTime NgayThanhToan
		{
			get
			{
				CanReadProperty("NgayThanhToan", true);
				return _ngayThanhToan.Date;
			}
            set
            {
                CanWriteProperty("NgayThanhToan", true);
                if (!_ngayThanhToan.Equals(value))
                {
                    _ngayThanhToan = new SmartDate(value);
                    PropertyHasChanged("NgayThanhToan");
                }
            }
		}	

		public int MaPhuongThucThanhToan
		{
			get
			{
				CanReadProperty("MaPhuongThucThanhToan", true);
				return _maPhuongThucThanhToan;
			}
			set
			{
				CanWriteProperty("MaPhuongThucThanhToan", true);
				if (!_maPhuongThucThanhToan.Equals(value))
				{
					_maPhuongThucThanhToan = value;
					PropertyHasChanged("MaPhuongThucThanhToan");
				}
			}
		}

		public int MaTaiKhoanDoiTac
		{
			get
			{
				CanReadProperty("MaTaiKhoanNganHang", true);
                return _maTaiKhoanDoiTac;
			}
			set
			{
				CanWriteProperty("MaTaiKhoanNganHang", true);
                if (!_maTaiKhoanDoiTac.Equals(value))
				{
                    _maTaiKhoanDoiTac = value;
					PropertyHasChanged("MaTaiKhoanNganHang");
				}
			}
		}

		
		public int MaLoaiTien
		{
			get
			{
				CanReadProperty("MaLoaiTien", true);
				return _maLoaiTien;
			}
			set
			{
				CanWriteProperty("MaLoaiTien", true);
				if (!_maLoaiTien.Equals(value))
				{
					_maLoaiTien = value;
					PropertyHasChanged("MaLoaiTien");
				}
			}
		}

		
		public decimal SoTien
		{
			get
			{
				CanReadProperty("SoTien", true);
				return _soTien;
			}
			set
			{
				CanWriteProperty("SoTien", true);
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
				}
			}
		}

        public int MaTaiKhoanCongTy
        {
            get
            {
                CanReadProperty("MaTaiKhoanCongTy", true);
                return _maTaiKhoanCongTy;
            }
            set
            {
                CanWriteProperty("MaTaiKhoanCongTy", true);
                if (!_maTaiKhoanCongTy.Equals(value))
                {
                    _maTaiKhoanCongTy = value;
                    PropertyHasChanged("MaTaiKhoanCongTy");
                }
            }
        }
 
		protected override object GetIdValue()
		{
			return _maDotThanhToan;
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
			//TODO: Define authorization rules in DotThanhToanHDMB
			//AuthorizationRules.AllowRead("MaDotThanhToan", "DotThanhToanHDMBReadGroup");
			//AuthorizationRules.AllowRead("MaHopDongMuaBan", "DotThanhToanHDMBReadGroup");
			//AuthorizationRules.AllowRead("NgayThanhToan", "DotThanhToanHDMBReadGroup");
			//AuthorizationRules.AllowRead("NgayThanhToanString", "DotThanhToanHDMBReadGroup");
			//AuthorizationRules.AllowRead("MaPhuongThucThanhToan", "DotThanhToanHDMBReadGroup");
			//AuthorizationRules.AllowRead("MaTaiKhoanNganHang", "DotThanhToanHDMBReadGroup");
			//AuthorizationRules.AllowRead("NguyenTe", "DotThanhToanHDMBReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiTien", "DotThanhToanHDMBReadGroup");
			//AuthorizationRules.AllowRead("TyGia", "DotThanhToanHDMBReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "DotThanhToanHDMBReadGroup");

			//AuthorizationRules.AllowWrite("MaHopDongMuaBan", "DotThanhToanHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("NgayThanhToanString", "DotThanhToanHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhuongThucThanhToan", "DotThanhToanHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("MaTaiKhoanNganHang", "DotThanhToanHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("NguyenTe", "DotThanhToanHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiTien", "DotThanhToanHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("TyGia", "DotThanhToanHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "DotThanhToanHDMBWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static DotThanhToanHDMB NewDotThanhToanHDMB()
		{
			return new DotThanhToanHDMB();
		}

		internal static DotThanhToanHDMB GetDotThanhToanHDMB(SafeDataReader dr)
		{
			return new DotThanhToanHDMB(dr);
		}

		public DotThanhToanHDMB()
		{
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private DotThanhToanHDMB(SafeDataReader dr)
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
			_maDotThanhToan = dr.GetInt32("MaDotThanhToan");
			_maHopDongMuaBan = dr.GetInt64("MaHopDongMuaBan");
			_ngayThanhToan = dr.GetSmartDate("NgayThanhToan", _ngayThanhToan.EmptyIsMin);
			_maPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
            _maTaiKhoanDoiTac = dr.GetInt32("MaTaiKhoanDoiTac");		
			_maLoaiTien = dr.GetInt32("MaLoaiTien");		
			_soTien = dr.GetDecimal("SoTien");
            _maTaiKhoanCongTy = dr.GetInt32("MaTaiKhoanCongTy");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, HopDongMuaBan parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, HopDongMuaBan parent)
		{
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblDotThanhToanHDMB";

                    AddInsertParameters(cm, parent);

                    cm.ExecuteNonQuery();

                    _maDotThanhToan = (int)cm.Parameters["@MaDotThanhToan"].Value;
                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		private void AddInsertParameters(SqlCommand cm, HopDongMuaBan parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaHopDongMuaBan", parent.MaHopDong);
			cm.Parameters.AddWithValue("@NgayThanhToan", _ngayThanhToan.DBValue);
			if (_maPhuongThucThanhToan != 0)
				cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", _maPhuongThucThanhToan);
			else
				cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", DBNull.Value);
			if (_maTaiKhoanDoiTac != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoanDoiTac", _maTaiKhoanDoiTac);
			else
                cm.Parameters.AddWithValue("@MaTaiKhoanDoiTac", DBNull.Value);
			
			if (_maLoaiTien != 0)
				cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
			else
				cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);			
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_maTaiKhoanCongTy != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanCongTy", _maTaiKhoanCongTy);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanCongTy", DBNull.Value);
			cm.Parameters.AddWithValue("@MaDotThanhToan", _maDotThanhToan);
			cm.Parameters["@MaDotThanhToan"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, HopDongMuaBan parent)
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

		private void ExecuteUpdate(SqlTransaction tr, HopDongMuaBan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDotThanhToanHDMB";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, HopDongMuaBan parent)
		{
			cm.Parameters.AddWithValue("@MaDotThanhToan", _maDotThanhToan);
			cm.Parameters.AddWithValue("@MaHopDongMuaBan", parent.MaHopDong);
			cm.Parameters.AddWithValue("@NgayThanhToan", _ngayThanhToan.DBValue);
			if (_maPhuongThucThanhToan != 0)
				cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", _maPhuongThucThanhToan);
			else
				cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", DBNull.Value);
            if (_maTaiKhoanDoiTac != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanDoiTac", _maTaiKhoanDoiTac);
			else
                cm.Parameters.AddWithValue("@MaTaiKhoanDoiTac", DBNull.Value);		
			if (_maLoaiTien != 0)
				cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
			else
				cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);		
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_maTaiKhoanCongTy != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanCongTy", _maTaiKhoanCongTy);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanCongTy", DBNull.Value);
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

			ExecuteDelete(tr);
			MarkNew();
		}

		private void ExecuteDelete(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblDotThanhToanHDMB";

				cm.Parameters.AddWithValue("@MaDotThanhToan", this._maDotThanhToan);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
