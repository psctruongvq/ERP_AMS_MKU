
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_ChuyenNganh : Csla.BusinessBase<NhanVien_ChuyenNganh>
	{
		#region Business Properties and Methods

		//declare members
		private int _manhanvienChuyenNganh = 0;
		private long _maNhanVien = 0;
		private int _maChuyenNganh = 0;
		private bool _chuyenNganhChinh = false;
        private string _tenChuyenNganh = string.Empty;
        private int _maTruongDaoTao = 0;
        private string _tenTruongDaoTao=string.Empty;
        private int _maHinhThucDaoTao = 0;
        private string _tenHinhThucDaoTao = string.Empty;
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNhanVienChuyenNganh
		{
			get
			{
				return _manhanvienChuyenNganh;
			}
		}
        public string TenChuyenNganh
        {
            get
            {
                _tenChuyenNganh = ChuyenNganhDaoTaoClass.GetChuyenNganhDaoTaoClass(_maChuyenNganh).ChuyenNganhDaoTao;
                return _tenChuyenNganh;
            }
            set { _tenChuyenNganh = value; }
        }
		public long MaNhanVien
		{
			get
			{
				return _maNhanVien;
			}
			set
			{
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public int MaChuyenNganh
		{
			get
			{
				return _maChuyenNganh;
			}
			set
			{
				if (!_maChuyenNganh.Equals(value))
				{
					_maChuyenNganh = value;
                    PropertyHasChanged("MaChuyenNganh");
				}
			}
		}

		public bool ChuyenNganhChinh
		{
			get
			{
				return _chuyenNganhChinh;
			}
			set
			{
				if (!_chuyenNganhChinh.Equals(value))
				{
					_chuyenNganhChinh = value;
                    PropertyHasChanged("ChuyenNganhChinh");
				}
			}
		}
        public int MaTruongDaoTao
        {
            get
            {
                return _maTruongDaoTao;
            }
            set
            {
                if (!_maTruongDaoTao.Equals(value))
                {
                    _maTruongDaoTao = value;
                    _tenTruongDaoTao = TruongDaoTao.GetTruongDaoTao(_maTruongDaoTao).TenTruongDaoTao;
                    PropertyHasChanged("MaTruongDaoTao");
                }
            }
        }
        public string TenTruongDaoTao
        {
            get
            {
                _tenTruongDaoTao = TruongDaoTao.GetTruongDaoTao(_maTruongDaoTao).TenTruongDaoTao;
                return _tenTruongDaoTao;
            }
            set { _tenTruongDaoTao = value; }
        }
        public int MaHinhThucDaoTao
        {
            get
            {
                return _maHinhThucDaoTao;
            }
            set
            {
                if (!_maHinhThucDaoTao.Equals(value))
                {
                    _maHinhThucDaoTao = value;
                    _tenHinhThucDaoTao = HinhThucDaoTaoClass.GetHinhThucDaoTaoClass(_maHinhThucDaoTao).HinhThucDaoTao;
                    PropertyHasChanged("MaHinhThucDaoTao");
                }
            }
        }
        public string TenHinhThucDaoTao
        {
            get
            {
                _tenHinhThucDaoTao = HinhThucDaoTaoClass.GetHinhThucDaoTaoClass(_maHinhThucDaoTao).HinhThucDaoTao;
                return _tenHinhThucDaoTao;
            }
            set { _tenHinhThucDaoTao = value; }
        }
		protected override object GetIdValue()
		{
			return _manhanvienChuyenNganh;
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

		#region Factory Methods
		public static NhanVien_ChuyenNganh NewNhanVien_ChuyenNganh()
		{
			return new NhanVien_ChuyenNganh();
		}

		internal static NhanVien_ChuyenNganh GetNhanVien_ChuyenNganh(SafeDataReader dr)
		{
			return new NhanVien_ChuyenNganh(dr);
		}

		private NhanVien_ChuyenNganh()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private NhanVien_ChuyenNganh(SafeDataReader dr)
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
			_manhanvienChuyenNganh = dr.GetInt32("MaNhanVien_ChuyenNganh");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maChuyenNganh = dr.GetInt32("MaTrinhDoChuyenNganh");
			_chuyenNganhChinh = dr.GetBoolean("ChuyenNganhChinh");
            _maTruongDaoTao = dr.GetInt32("MaTruongDaoTao");
            _maHinhThucDaoTao = dr.GetInt32("MaHinhThucDaoTao");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
        internal void Insert(SqlTransaction tr, NhanVien parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, NhanVien parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsNhanVien_ChuyenNganh";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

                _manhanvienChuyenNganh = (int)cm.Parameters["@MaNhanVien_ChuyenNganh"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			if (_maChuyenNganh != 0)
				cm.Parameters.AddWithValue("@MaTrinhDoChuyenNganh", _maChuyenNganh);
			else
                cm.Parameters.AddWithValue("@MaTrinhDoChuyenNganh", DBNull.Value);
			if (_chuyenNganhChinh != false)
				cm.Parameters.AddWithValue("@ChuyenNganhChinh", _chuyenNganhChinh);
			else
                cm.Parameters.AddWithValue("@ChuyenNganhChinh", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNhanVien_ChuyenNganh", _manhanvienChuyenNganh);
            if (_maTruongDaoTao != 0)
                cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
            else
                cm.Parameters.AddWithValue("@MaTruongDaoTao", DBNull.Value);
            if (_maHinhThucDaoTao != 0)
                cm.Parameters.AddWithValue("@MaHinhThucDaoTao", _maHinhThucDaoTao);
            else
                cm.Parameters.AddWithValue("@MaHinhThucDaoTao", DBNull.Value);
            cm.Parameters["@MaNhanVien_ChuyenNganh"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, NhanVien parent)
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

        private void ExecuteUpdate(SqlTransaction tr, NhanVien parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsNhanVien_ChuyenNganh";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
			cm.Parameters.AddWithValue("@MaNhanVien_ChuyenNganh", _manhanvienChuyenNganh);
            cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			if (_maChuyenNganh != 0)
				cm.Parameters.AddWithValue("@MaTrinhDoChuyenNganh", _maChuyenNganh);
			else
                cm.Parameters.AddWithValue("@MaTrinhDoChuyenNganh", DBNull.Value);
			if (_chuyenNganhChinh != false)
				cm.Parameters.AddWithValue("@ChuyenNganhChinh", _chuyenNganhChinh);
			else
				cm.Parameters.AddWithValue("@ChuyenNganhChinh", DBNull.Value);
            if (_maTruongDaoTao != 0)
                cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
            else
                cm.Parameters.AddWithValue("@MaTruongDaoTao", DBNull.Value);
            if (_maHinhThucDaoTao != 0)
                cm.Parameters.AddWithValue("@MaHinhThucDaoTao", _maHinhThucDaoTao);
            else
                cm.Parameters.AddWithValue("@MaHinhThucDaoTao", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblnsNhanVien_ChuyenNganh";

				cm.Parameters.AddWithValue("@MaNhanVien_ChuyenNganh", this._manhanvienChuyenNganh);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
