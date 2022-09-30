

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiTietGiayXacNhan_NhanVien : Csla.BusinessBase<ChiTietGiayXacNhan_NhanVien>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChiTiet = 0;
		private long _maNhanVien = 0;
		private decimal _soTien = 0;
		private int _maChiTietGiayXacNhan = 0;
        private string _ghiChu = string.Empty;
		[System.ComponentModel.DataObjectField(true, false)]
		public long MaChiTiet
		{
			get
			{
				return _maChiTiet;
			}
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

		public decimal SoTien
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

		public int MaChiTietGiayXacNhan
		{
			get
			{
				return _maChiTietGiayXacNhan;
			}
			set
			{
				if (!_maChiTietGiayXacNhan.Equals(value))
				{
					_maChiTietGiayXacNhan = value;
					PropertyHasChanged("MaChiTietGiayXacNhan");
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

		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		internal static ChiTietGiayXacNhan_NhanVien NewChiTietGiayXacNhan_NhanVien(long maChiTiet)
		{
			return new ChiTietGiayXacNhan_NhanVien(maChiTiet);
		}

		internal static ChiTietGiayXacNhan_NhanVien GetChiTietGiayXacNhan_NhanVien(SafeDataReader dr)
		{
			return new ChiTietGiayXacNhan_NhanVien(dr);
		}

		private ChiTietGiayXacNhan_NhanVien(long maChiTiet)
		{
			this._maChiTiet = maChiTiet;
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private ChiTietGiayXacNhan_NhanVien(SafeDataReader dr)
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
			_maChiTiet = dr.GetInt64("MaChiTiet");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_soTien = dr.GetDecimal("SoTien");
			_maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
            _ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
        internal void Insert(SqlTransaction tr, ChiTietGiayXacNhan parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, ChiTietGiayXacNhan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsChiTietGiayXacNhan_NhanVien";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddInsertParameters(SqlCommand cm, ChiTietGiayXacNhan parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (parent.MaChiTietGiayXacNhan != 0)
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", parent.MaChiTietGiayXacNhan);
			else
				cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@GhiChu",_ghiChu);

		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, ChiTietGiayXacNhan parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChiTietGiayXacNhan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsChiTietGiayXacNhan_NhanVien";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, ChiTietGiayXacNhan parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (parent.MaChiTietGiayXacNhan != 0)
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", parent.MaChiTietGiayXacNhan);
			else
				cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
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
                cm.CommandText = "spd_DeletetblnsChiTietGiayXacNhan_NhanVien";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
