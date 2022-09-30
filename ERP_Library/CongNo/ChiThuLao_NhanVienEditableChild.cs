
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 

    // 16 - 1- 2010
	[Serializable()] 
	public class ChiThuLao_NhanVien : Csla.BusinessBase<ChiThuLao_NhanVien>
	{
		#region Business Properties and Methods

		//declare members
		private long _mathulaoNhanvien = 0;
		private long _maChiThuLao = 0;
		private int _maNhanVien = 0;
		private int _mabophanNv = 0;
		private string _tenNhanVien = string.Empty;
		private string _tenBoPhan = string.Empty;
		private decimal _soTien = 0;
        private byte _loaiNV = 0;

        
		[System.ComponentModel.DataObjectField(true, true)]
		public long MathulaoNhanvien
		{
			get
			{
				CanReadProperty("MathulaoNhanvien", true);
				return _mathulaoNhanvien;
			}
		}

		public long MaChiThuLao
		{
			get
			{
				CanReadProperty("MaChiThuLao", true);
				return _maChiThuLao;
			}
			set
			{
				CanWriteProperty("MaChiThuLao", true);
				if (!_maChiThuLao.Equals(value))
				{
					_maChiThuLao = value;
					PropertyHasChanged("MaChiThuLao");
				}
			}
		}

		public int MaNhanVien
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

		public int MabophanNv
		{
			get
			{
				CanReadProperty("MabophanNv", true);
				return _mabophanNv;
			}
			set
			{
				CanWriteProperty("MabophanNv", true);
				if (!_mabophanNv.Equals(value))
				{
					_mabophanNv = value;
					PropertyHasChanged("MabophanNv");
				}
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

		public string TenBoPhan
		{
			get
			{
				CanReadProperty("TenBoPhan", true);
				return _tenBoPhan;
			}
			set
			{
				CanWriteProperty("TenBoPhan", true);
				if (value == null) value = string.Empty;
				if (!_tenBoPhan.Equals(value))
				{
					_tenBoPhan = value;
					PropertyHasChanged("TenBoPhan");
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
        public byte LoaiNV
        {
            get { return _loaiNV; }
            set { _loaiNV = value; }
        }
		protected override object GetIdValue()
		{
			return _mathulaoNhanvien;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{
            ////
            //// TenNhanVien
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 100));
            ////
            //// TenBoPhan
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 200));
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
			//TODO: Define authorization rules in ChiThuLao_NhanVien
			//AuthorizationRules.AllowRead("MathulaoNhanvien", "ChiThuLao_NhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaChiThuLao", "ChiThuLao_NhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "ChiThuLao_NhanVienReadGroup");
			//AuthorizationRules.AllowRead("MabophanNv", "ChiThuLao_NhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenNhanVien", "ChiThuLao_NhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenBoPhan", "ChiThuLao_NhanVienReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "ChiThuLao_NhanVienReadGroup");

			//AuthorizationRules.AllowWrite("MaChiThuLao", "ChiThuLao_NhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "ChiThuLao_NhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MabophanNv", "ChiThuLao_NhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenNhanVien", "ChiThuLao_NhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenBoPhan", "ChiThuLao_NhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "ChiThuLao_NhanVienWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static ChiThuLao_NhanVien NewChiThuLao_NhanVien()
		{
			return new ChiThuLao_NhanVien();
		}

		internal static ChiThuLao_NhanVien GetChiThuLao_NhanVien(SafeDataReader dr)
		{
			return new ChiThuLao_NhanVien(dr);
		}

		private ChiThuLao_NhanVien()
		{

			//ValidationRules.CheckRules();
			MarkAsChild();
		}

		private ChiThuLao_NhanVien(SafeDataReader dr)
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
			//ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_mathulaoNhanvien = dr.GetInt64("MaThuLao_NhanVien");
			_maChiThuLao = dr.GetInt64("MaChiThuLao");
			_maNhanVien = dr.GetInt32("MaNhanVien");
			_mabophanNv = dr.GetInt32("MaBoPhan_NV");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_soTien = dr.GetDecimal("SoTien");
            _loaiNV = dr.GetByte("LoaiNhanVien");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ChiThuLao parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ChiThuLao parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChiThuLao_NhanVien";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_mathulaoNhanvien = (long)cm.Parameters["@MaThuLao_NhanVien"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ChiThuLao parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (parent.MaChiThuLao != 0)
                cm.Parameters.AddWithValue("@MaChiThuLao", parent.MaChiThuLao);
			else
				cm.Parameters.AddWithValue("@MaChiThuLao", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_mabophanNv != 0)
				cm.Parameters.AddWithValue("@MaBoPhan_NV", _mabophanNv);
			else
				cm.Parameters.AddWithValue("@MaBoPhan_NV", DBNull.Value);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
           
                cm.Parameters.AddWithValue("@LoaiNhanVien", _loaiNV);
          
     
			cm.Parameters.AddWithValue("@MaThuLao_NhanVien", _mathulaoNhanvien);
			cm.Parameters["@MaThuLao_NhanVien"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ChiThuLao parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ChiThuLao parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChiThuLao_NhanVien";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ChiThuLao parent)
		{
			cm.Parameters.AddWithValue("@MaThuLao_NhanVien", _mathulaoNhanvien);
            if (parent.MaChiThuLao != 0)
                cm.Parameters.AddWithValue("@MaChiThuLao", parent.MaChiThuLao);
			else
				cm.Parameters.AddWithValue("@MaChiThuLao", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_mabophanNv != 0)
				cm.Parameters.AddWithValue("@MaBoPhan_NV", _mabophanNv);
			else
				cm.Parameters.AddWithValue("@MaBoPhan_NV", DBNull.Value);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@LoaiNhanVien", _loaiNV);
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
                cm.CommandText = "spd_DeletetblChiThuLao_NhanVien";

				cm.Parameters.AddWithValue("@MaThuLao_NhanVien", this._mathulaoNhanvien);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
