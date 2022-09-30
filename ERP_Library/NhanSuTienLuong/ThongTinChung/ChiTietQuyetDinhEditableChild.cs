
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiTietQuyetDinh : Csla.BusinessBase<ChiTietQuyetDinh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChiTiet = 0;
		private int _maQuyetDinh = 0;
		private long _maNhanVien = 0;
		private string _cheDo = string.Empty;
		private int _mucTamUng = 0;
		private decimal _chiPhiCaNhan = 0;
		private string _ghiChu = string.Empty;
        private string _tenNhanVien = string.Empty;

		public int MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaQuyetDinh
		{
			get
			{
				CanReadProperty("MaQuyetDinh", true);
				return _maQuyetDinh;
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
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
                    PropertyHasChanged("MaNhanVien");
                }
            }
		}


        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                _tenNhanVien = TenNV.GetTenNhanVien(_maNhanVien).TenNhanVien;
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

		public string CheDo
		{
			get
			{
				CanReadProperty("CheDo", true);
				return _cheDo;
			}
			set
			{
				CanWriteProperty("CheDo", true);
				if (value == null) value = string.Empty;
				if (!_cheDo.Equals(value))
				{
					_cheDo = value;
					PropertyHasChanged("CheDo");
				}
			}
		}

		public int MucTamUng
		{
			get
			{
				CanReadProperty("MucTamUng", true);
				return _mucTamUng;
			}
			set
			{
				CanWriteProperty("MucTamUng", true);
				if (!_mucTamUng.Equals(value))
				{
					_mucTamUng = value;
					PropertyHasChanged("MucTamUng");
				}
			}
		}

		public decimal ChiPhiCaNhan
		{
			get
			{
				CanReadProperty("ChiPhiCaNhan", true);
				return _chiPhiCaNhan;
			}
			set
			{
				CanWriteProperty("ChiPhiCaNhan", true);
				if (!_chiPhiCaNhan.Equals(value))
				{
					_chiPhiCaNhan = value;
					PropertyHasChanged("ChiPhiCaNhan");
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
 
		protected override object GetIdValue()
		{
			return string.Format("{0}:{1}", _maQuyetDinh, _maNhanVien);            
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
			// CheDo
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "CheDo");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CheDo", 500));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
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
			//TODO: Define authorization rules in ChiTietQuyetDinh
			//AuthorizationRules.AllowRead("MaChiTiet", "ChiTietQuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("MaQuyetDinh", "ChiTietQuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "ChiTietQuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("CheDo", "ChiTietQuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("MucTamUng", "ChiTietQuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("ChiPhiCaNhan", "ChiTietQuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "ChiTietQuyetDinhReadGroup");

			//AuthorizationRules.AllowWrite("CheDo", "ChiTietQuyetDinhWriteGroup");
			//AuthorizationRules.AllowWrite("MucTamUng", "ChiTietQuyetDinhWriteGroup");
			//AuthorizationRules.AllowWrite("ChiPhiCaNhan", "ChiTietQuyetDinhWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "ChiTietQuyetDinhWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static ChiTietQuyetDinh NewChiTietQuyetDinh(int maQuyetDinh, long maNhanVien, string cheDo, int mucTamUng, decimal chiPhi)
		{
            return new ChiTietQuyetDinh(maQuyetDinh, maNhanVien, cheDo, mucTamUng, chiPhi);
		}

		internal static ChiTietQuyetDinh GetChiTietQuyetDinh(SafeDataReader dr)
		{
			return new ChiTietQuyetDinh(dr);
		}

        private ChiTietQuyetDinh(int maQuyetDinh, long maNhanVien, string cheDo, int mucTamUng, decimal chiPhi)
		{
			this._maQuyetDinh = maQuyetDinh;
			this._maNhanVien = maNhanVien;
            this._cheDo = cheDo;
            this._mucTamUng = mucTamUng;
            this._chiPhiCaNhan = chiPhi;
			ValidationRules.CheckRules();
			MarkAsChild();
		}

        public ChiTietQuyetDinh()
        {
            ValidationRules.CheckRules();
            MarkAsChild();
        }

		private ChiTietQuyetDinh(SafeDataReader dr)
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
			_maQuyetDinh = dr.GetInt32("MaQuyetDinh");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_cheDo = dr.GetString("CheDo");
			_mucTamUng = dr.GetInt32("MucTamUng");
			_chiPhiCaNhan = dr.GetDecimal("ChiPhiCaNhan");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, QuyetDinhDaoTao parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, QuyetDinhDaoTao parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsChiTietQuyetDinh";
				AddInsertParameters(cm, parent);
				cm.ExecuteNonQuery();

				_maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, QuyetDinhDaoTao parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
			cm.Parameters.AddWithValue("@MaQuyetDinh", parent.MaQuyetDinh);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@CheDo", _cheDo);
			cm.Parameters.AddWithValue("@MucTamUng", _mucTamUng);
			cm.Parameters.AddWithValue("@ChiPhiCaNhan", _chiPhiCaNhan);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);			
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, QuyetDinhDaoTao parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn, QuyetDinhDaoTao parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsChiTietQuyetDinh";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, QuyetDinhDaoTao parent)
		{			
			cm.Parameters.AddWithValue("@MaQuyetDinh", parent.MaQuyetDinh);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@CheDo", _cheDo);
			cm.Parameters.AddWithValue("@MucTamUng", _mucTamUng);
			cm.Parameters.AddWithValue("@ChiPhiCaNhan", _chiPhiCaNhan);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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

			ExecuteDelete(cn);
			MarkNew();
		}

		private void ExecuteDelete(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsChiTietQuyetDinh";
				cm.Parameters.AddWithValue("@MaQuyetDinh", this._maQuyetDinh);
				cm.Parameters.AddWithValue("@MaNhanVien", this._maNhanVien);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
