
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NguoiPhuThuoc_ChungTuGiaCanh : Csla.BusinessBase<NguoiPhuThuoc_ChungTuGiaCanh>
	{
		#region Business Properties and Methods

		//declare members
		private int _manhanvienChungtu = 0;
		private int _manhanvienGiacanh = 0;
		private int _maChungTu = 0;
		private string _tenChungTu = string.Empty;
		private string _ghiChu = string.Empty;
		private DateTime _ngayLap = DateTime.Today.Date;
		private int _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;

		[System.ComponentModel.DataObjectField(true, false)]
		public int ManhanvienChungtu
		{
			get
			{
				return _manhanvienChungtu;
			}
		}

		public int ManhanvienGiacanh
		{
			get
			{
				return _manhanvienGiacanh;
			}
			set
			{
				if (!_manhanvienGiacanh.Equals(value))
				{
					_manhanvienGiacanh = value;
					PropertyHasChanged("ManhanvienGiacanh");
				}
			}
		}

		public int MaChungTu
		{
			get
			{
                _tenChungTu = ChungTuGiamTruGiaCanh.GetChungTuGiamTruGiaCanh(_maChungTu).TenChungTu;
				return _maChungTu;
			}
			set
			{
				if (!_maChungTu.Equals(value))
				{
					_maChungTu = value;
                    _tenChungTu = ChungTuGiamTruGiaCanh.GetChungTuGiamTruGiaCanh(_maChungTu).TenChungTu;
					PropertyHasChanged("MaChungTu");
				}
			}
		}

		public string TenChungTu
		{
            get
            {
                _tenChungTu=ChungTuGiamTruGiaCanh.GetChungTuGiamTruGiaCanh(_maChungTu).TenChungTu;
                return _tenChungTu;
            }
           
		}

		public string GhiChu
		{
			get
			{
				return _ghiChu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_ghiChu.Equals(value))
				{
					_ghiChu = value;
					PropertyHasChanged("GhiChu");
				}
			}
		}

		public DateTime NgayLap
		{
			get
			{
				return _ngayLap;
			}
			set
			{
				if (!_ngayLap.Equals(value))
				{
					_ngayLap = value;
					PropertyHasChanged("NgayLap");
				}
			}
		}

		public int NguoiLap
		{
			get
			{
				return _nguoiLap;
			}
			set
			{
				if (!_nguoiLap.Equals(value))
				{
					_nguoiLap = value;
					PropertyHasChanged("NguoiLap");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _manhanvienChungtu;
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
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		internal static NguoiPhuThuoc_ChungTuGiaCanh NewNguoiPhuThuoc_ChungTuGiaCanh(int manhanvienChungtu)
		{
			return new NguoiPhuThuoc_ChungTuGiaCanh(manhanvienChungtu);
		}

		internal static NguoiPhuThuoc_ChungTuGiaCanh GetNguoiPhuThuoc_ChungTuGiaCanh(SafeDataReader dr)
		{
			return new NguoiPhuThuoc_ChungTuGiaCanh(dr);
		}

		private NguoiPhuThuoc_ChungTuGiaCanh(int manhanvienChungtu)
		{
			this._manhanvienChungtu = manhanvienChungtu;
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private NguoiPhuThuoc_ChungTuGiaCanh(SafeDataReader dr)
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
			_manhanvienChungtu = dr.GetInt32("MaNhanVien_ChungTu");
			_manhanvienGiacanh = dr.GetInt32("MaNhanVien_GiaCanh");
			_maChungTu = dr.GetInt32("MaChungTu");
			_tenChungTu = dr.GetString("TenChungTu");
			_ghiChu = dr.GetString("GhiChu");
			_ngayLap = dr.GetDateTime("NgayLap");
			_nguoiLap = dr.GetInt32("NguoiLap");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
        internal void Insert(SqlTransaction tr, NhanVienGiaCanh parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, NhanVienGiaCanh parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblnsNguoiPhuThuoc_ChungTuGiaCanh";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _manhanvienChungtu = (int)cm.Parameters["@MaNhanVien_ChungTu"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, NhanVienGiaCanh parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaNhanVien_ChungTu", _manhanvienChungtu);
            cm.Parameters["@MaNhanVien_ChungTu"].Direction = ParameterDirection.Output;
            if (parent.NhanvienGiacanh != 0)
                cm.Parameters.AddWithValue("@MaNhanVien_GiaCanh", parent.NhanvienGiacanh);
			else
				cm.Parameters.AddWithValue("@MaNhanVien_GiaCanh", DBNull.Value);
			if (_maChungTu != 0)
				cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			else
				cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
			if (_tenChungTu.Length>0)
				cm.Parameters.AddWithValue("@TenChungTu", _tenChungTu);
			else
				cm.Parameters.AddWithValue("@TenChungTu", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
				cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
				if (_nguoiLap != 0)
					cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
				else
					cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, NhanVienGiaCanh parent)
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

        private void ExecuteUpdate(SqlTransaction tr, NhanVienGiaCanh parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblnsNguoiPhuThuoc_ChungTuGiaCanh";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, NhanVienGiaCanh parent)
		{
			cm.Parameters.AddWithValue("@MaNhanVien_ChungTu", _manhanvienChungtu);
            if (parent.NhanvienGiacanh != 0)
                cm.Parameters.AddWithValue("@MaNhanVien_GiaCanh", parent.NhanvienGiacanh);
            else
                cm.Parameters.AddWithValue("@MaNhanVien_GiaCanh", DBNull.Value);
			if (_maChungTu != 0)
				cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			else
				cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
			if (_tenChungTu.Length>0)
				cm.Parameters.AddWithValue("@TenChungTu", _tenChungTu);
			else
				cm.Parameters.AddWithValue("@TenChungTu", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
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
				cm.CommandText = "DeletetblnsNguoiPhuThuoc_ChungTuGiaCanh";

				cm.Parameters.AddWithValue("@MaNhanVien_ChungTu", this._manhanvienChungtu);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
