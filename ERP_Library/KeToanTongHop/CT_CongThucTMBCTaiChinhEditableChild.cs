
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_CongThucTMBCTaiChinh : Csla.BusinessBase<CT_CongThucTMBCTaiChinh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChiTiet = 0;
		private int _maMucCapBa = 0;
		private int _maTaiKhoan = 0;
		private int _maTaiKhoanDoiUng = 0;
		private string _soHieuTK = string.Empty;
		private byte _congTru = 0;
		private byte _noCo = 0;
		private int _maMucLienQuan = 0;
		private byte _loaiTinh = 0;
        private byte _ThuocCot = 0;
        private bool _LayTheoLuyKe = false;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public int MaMucCapBa
		{
			get
			{
				CanReadProperty("MaMucCapBa", true);
				return _maMucCapBa;
			}
			set
			{
				CanWriteProperty("MaMucCapBa", true);
				if (!_maMucCapBa.Equals(value))
				{
					_maMucCapBa = value;
					PropertyHasChanged("MaMucCapBa");
				}
			}
		}

		public int MaTaiKhoan
		{
			get
			{
				CanReadProperty("MaTaiKhoan", true);
				return _maTaiKhoan;
			}
			set
			{
				CanWriteProperty("MaTaiKhoan", true);
				if (!_maTaiKhoan.Equals(value))
				{
					_maTaiKhoan = value;
					PropertyHasChanged("MaTaiKhoan");
				}
			}
		}

		public int MaTaiKhoanDoiUng
		{
			get
			{
				CanReadProperty("MaTaiKhoanDoiUng", true);
				return _maTaiKhoanDoiUng;
			}
			set
			{
				CanWriteProperty("MaTaiKhoanDoiUng", true);
				if (!_maTaiKhoanDoiUng.Equals(value))
				{
					_maTaiKhoanDoiUng = value;
					PropertyHasChanged("MaTaiKhoanDoiUng");
				}
			}
		}

		public string SoHieuTK
		{
			get
			{
				CanReadProperty("SoHieuTK", true);
				return _soHieuTK;
			}
			set
			{
				CanWriteProperty("SoHieuTK", true);
				if (value == null) value = string.Empty;
				if (!_soHieuTK.Equals(value))
				{
					_soHieuTK = value;
					PropertyHasChanged("SoHieuTK");
				}
			}
		}

		public byte CongTru
		{
			get
			{
				CanReadProperty("CongTru", true);
				return _congTru;
			}
			set
			{
				CanWriteProperty("CongTru", true);
				if (!_congTru.Equals(value))
				{
					_congTru = value;
					PropertyHasChanged("CongTru");
				}
			}
		}

		public byte NoCo
		{
			get
			{
				CanReadProperty("NoCo", true);
				return _noCo;
			}
			set
			{
				CanWriteProperty("NoCo", true);
				if (!_noCo.Equals(value))
				{
					_noCo = value;
					PropertyHasChanged("NoCo");
				}
			}
		}

		public int MaMucLienQuan
		{
			get
			{
				CanReadProperty("MaMucLienQuan", true);
				return _maMucLienQuan;
			}
			set
			{
				CanWriteProperty("MaMucLienQuan", true);
				if (!_maMucLienQuan.Equals(value))
				{
					_maMucLienQuan = value;
					PropertyHasChanged("MaMucLienQuan");
				}
			}
		}

		public byte LoaiTinh
		{
			get
			{
				CanReadProperty("LoaiTinh", true);
				return _loaiTinh;
			}
			set
			{
				CanWriteProperty("LoaiTinh", true);
				if (!_loaiTinh.Equals(value))
				{
					_loaiTinh = value;
					PropertyHasChanged("LoaiTinh");
				}
			}
		}

        public byte ThuocCot
        {
            get
            {
                CanReadProperty("ThuocCot", true);
                return _ThuocCot;
            }
            set
            {
                CanWriteProperty("ThuocCot", true);
                if (!_ThuocCot.Equals(value))
                {
                    _ThuocCot = value;
                    PropertyHasChanged("ThuocCot");
                }
            }
        }

        public bool LayTheoLuyKe
        {
            get
            {
                CanReadProperty("LayTheoLuyKe", true);
                return _LayTheoLuyKe;
            }
            set
            {
                CanWriteProperty("LayTheoLuyKe", true);
                if (!_LayTheoLuyKe.Equals(value))
                {
                    _LayTheoLuyKe = value;
                    PropertyHasChanged("LayTheoLuyKe");
                }
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
			//
			// SoHieuTK
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHieuTK", 500));
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
			//TODO: Define authorization rules in CT_CongThucTMBCTaiChinh
			//AuthorizationRules.AllowRead("MaChiTiet", "CT_CongThucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("MaMucCapBa", "CT_CongThucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("MaTaiKhoan", "CT_CongThucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("MaTaiKhoanDoiUng", "CT_CongThucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("SoHieuTK", "CT_CongThucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("CongTru", "CT_CongThucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("NoCo", "CT_CongThucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("MaMucLienQuan", "CT_CongThucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("LoaiTinh", "CT_CongThucTMBCTaiChinhReadGroup");

			//AuthorizationRules.AllowWrite("MaMucCapBa", "CT_CongThucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaTaiKhoan", "CT_CongThucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaTaiKhoanDoiUng", "CT_CongThucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("SoHieuTK", "CT_CongThucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("CongTru", "CT_CongThucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("NoCo", "CT_CongThucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaMucLienQuan", "CT_CongThucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("LoaiTinh", "CT_CongThucTMBCTaiChinhWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static CT_CongThucTMBCTaiChinh NewCT_CongThucTMBCTaiChinh()
		{
			return new CT_CongThucTMBCTaiChinh();
		}

        public static CT_CongThucTMBCTaiChinh NewCT_CongThucTMBCTaiChinh(CT_CongThucTMBCTaiChinh copy)
        {
            return new CT_CongThucTMBCTaiChinh(copy);
        }

		internal static CT_CongThucTMBCTaiChinh GetCT_CongThucTMBCTaiChinh(SafeDataReader dr)
		{
			return new CT_CongThucTMBCTaiChinh(dr);
		}

		private CT_CongThucTMBCTaiChinh()
		{

			//ValidationRules.CheckRules();
			MarkAsChild();
		}

        private CT_CongThucTMBCTaiChinh(CT_CongThucTMBCTaiChinh copy)
        {
        
            //this._maMucCapBa
            this._maTaiKhoan = copy.MaTaiKhoan;
            this._maTaiKhoanDoiUng = copy.MaTaiKhoanDoiUng;
            this._soHieuTK = copy.SoHieuTK;
            this._congTru = copy.CongTru;
            this._noCo = copy.NoCo;
            //this._maMucLienQuan ;
            this._loaiTinh = copy.LoaiTinh;
            this._ThuocCot = copy.ThuocCot;//
            this._LayTheoLuyKe = copy.LayTheoLuyKe;//
            //ValidationRules.CheckRules();
            MarkAsChild();
        }

		private CT_CongThucTMBCTaiChinh(SafeDataReader dr)
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
			_maChiTiet = dr.GetInt32("MaChiTiet");
			_maMucCapBa = dr.GetInt32("MaMucCapBa");
			_maTaiKhoan = dr.GetInt32("MaTaiKhoan");
			_maTaiKhoanDoiUng = dr.GetInt32("MaTaiKhoanDoiUng");
			_soHieuTK = dr.GetString("SoHieuTK");
			_congTru = dr.GetByte("CongTru");
			_noCo = dr.GetByte("NoCo");
			_maMucLienQuan = dr.GetInt32("MaMucLienQuan");
			_loaiTinh = dr.GetByte("LoaiTinh");
            _ThuocCot = dr.GetByte("ThuocCot");//
            _LayTheoLuyKe = dr.GetBoolean("LayTheoLuyKe");//
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, CT_MucTMBCTaiChinh parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, CT_MucTMBCTaiChinh parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_CongThucTMBCTaiChinh";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, CT_MucTMBCTaiChinh parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			
				cm.Parameters.AddWithValue("@MaMucCapBa", parent.MaMucCapHai);			
			if (_maTaiKhoan != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
			if (_maTaiKhoanDoiUng != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", _maTaiKhoanDoiUng);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", DBNull.Value);
			if (_soHieuTK.Length > 0)
				cm.Parameters.AddWithValue("@SoHieuTK", _soHieuTK);
			else
				cm.Parameters.AddWithValue("@SoHieuTK", DBNull.Value);
			if (_congTru != 0)
				cm.Parameters.AddWithValue("@CongTru", _congTru);
			else
				cm.Parameters.AddWithValue("@CongTru", DBNull.Value);
			if (_noCo != 0)
				cm.Parameters.AddWithValue("@NoCo", _noCo);
			else
				cm.Parameters.AddWithValue("@NoCo", DBNull.Value);
			if (_maMucLienQuan != 0)
				cm.Parameters.AddWithValue("@MaMucLienQuan", _maMucLienQuan);
			else
				cm.Parameters.AddWithValue("@MaMucLienQuan", DBNull.Value);
			if (_loaiTinh != 0)
				cm.Parameters.AddWithValue("@LoaiTinh", _loaiTinh);
			else
				cm.Parameters.AddWithValue("@LoaiTinh", DBNull.Value);

            if (_ThuocCot != 0)
                cm.Parameters.AddWithValue("@ThuocCot", _ThuocCot);
            else
                cm.Parameters.AddWithValue("@ThuocCot", DBNull.Value);
            if (_LayTheoLuyKe != false)
                cm.Parameters.AddWithValue("@LayTheoLuyKe", _LayTheoLuyKe);
            else
                cm.Parameters.AddWithValue("@LayTheoLuyKe", DBNull.Value);

			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, CT_MucTMBCTaiChinh parent)
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

		private void ExecuteUpdate(SqlTransaction tr, CT_MucTMBCTaiChinh parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_CongThucTMBCTaiChinh";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, CT_MucTMBCTaiChinh parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			if (_maMucCapBa != 0)
				cm.Parameters.AddWithValue("@MaMucCapBa", _maMucCapBa);
			else
				cm.Parameters.AddWithValue("@MaMucCapBa", DBNull.Value);
			if (_maTaiKhoan != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
			if (_maTaiKhoanDoiUng != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", _maTaiKhoanDoiUng);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", DBNull.Value);
			if (_soHieuTK.Length > 0)
				cm.Parameters.AddWithValue("@SoHieuTK", _soHieuTK);
			else
				cm.Parameters.AddWithValue("@SoHieuTK", DBNull.Value);
			if (_congTru != 0)
				cm.Parameters.AddWithValue("@CongTru", _congTru);
			else
				cm.Parameters.AddWithValue("@CongTru", DBNull.Value);
			if (_noCo != 0)
				cm.Parameters.AddWithValue("@NoCo", _noCo);
			else
				cm.Parameters.AddWithValue("@NoCo", DBNull.Value);
			if (_maMucLienQuan != 0)
				cm.Parameters.AddWithValue("@MaMucLienQuan", _maMucLienQuan);
			else
				cm.Parameters.AddWithValue("@MaMucLienQuan", DBNull.Value);
			if (_loaiTinh != 0)
				cm.Parameters.AddWithValue("@LoaiTinh", _loaiTinh);
			else
				cm.Parameters.AddWithValue("@LoaiTinh", DBNull.Value);

            if (_ThuocCot != 0)
                cm.Parameters.AddWithValue("@ThuocCot", _ThuocCot);
            else
                cm.Parameters.AddWithValue("@ThuocCot", DBNull.Value);
            if (_LayTheoLuyKe != false)
                cm.Parameters.AddWithValue("@LayTheoLuyKe", _LayTheoLuyKe);
            else
                cm.Parameters.AddWithValue("@LayTheoLuyKe", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_CongThucTMBCTaiChinh";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
