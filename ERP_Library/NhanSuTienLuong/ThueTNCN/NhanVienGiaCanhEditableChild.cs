
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVienGiaCanh : Csla.BusinessBase<NhanVienGiaCanh>
	{
		#region Business Properties and Methods

		//declare members
		private long _maNhanVien = 0;
		private int _maGiaCanh = 0;
        private int _SoLuong = 0;
		private bool _coChungTu = false;
		private int _nhanvienGiacanh = 0;
        private int _MaQuanHeGiaDinh = 0;
		private string _ghiChu = string.Empty;
        
        private NguoiPhuThuoc_ChungTuGiaCanhList _nguoiPhuThuoc_ChungTuList = NguoiPhuThuoc_ChungTuGiaCanhList.NewNguoiPhuThuoc_ChungTuGiaCanhList();

        public NguoiPhuThuoc_ChungTuGiaCanhList NguoiPhuThuoc_ChungTuList
        {
            get { return _nguoiPhuThuoc_ChungTuList; }
            set { _nguoiPhuThuoc_ChungTuList = value; }
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
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public int MaGiaCanh
		{
			get
			{
				CanReadProperty("MaGiaCanh", true);
				return _maGiaCanh;
			}
			set
			{
				CanWriteProperty("MaGiaCanh", true);
				if (!_maGiaCanh.Equals(value))
				{
					_maGiaCanh = value;
					PropertyHasChanged("MaGiaCanh");
				}
			}
		}
       
        public int MaQuanHeGiaDinh
        {
            get
            {
                CanReadProperty("MaQuanHeGiaDinh", true);
                return _MaQuanHeGiaDinh;
            }
            set
            {
                CanWriteProperty("MaQuanHeGiaDinh", true);
                if (!_MaQuanHeGiaDinh.Equals(value))
                {
                    _MaQuanHeGiaDinh = value;
                    PropertyHasChanged("MaQuanHeGiaDinh");
                }
            }
        }
        public int SoLuong
        {
            get
            {
                CanReadProperty("SoLuong", true);
                return _SoLuong;
            }
            set
            {
                CanWriteProperty("SoLuong", true);
                if (!_SoLuong.Equals(value))
                {
                    _SoLuong = value;
                    PropertyHasChanged("SoLuong");
                }
            }
        }

		public bool CoChungTu
		{
			get
			{
				CanReadProperty("CoChungTu", true);
				return _coChungTu;
			}
			set
			{
				CanWriteProperty("CoChungTu", true);
				if (!_coChungTu.Equals(value))
				{
					_coChungTu = value;
					PropertyHasChanged("CoChungTu");
				}
			}
		}

		[System.ComponentModel.DataObjectField(true, true)]
		public int NhanvienGiacanh
		{
			get
			{
				CanReadProperty("NhanvienGiacanh", true);
				return _nhanvienGiacanh;
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
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty||_nguoiPhuThuoc_ChungTuList.IsDirty;
            }
        }
		protected override object GetIdValue()
		{
			return _nhanvienGiacanh;
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
		//	ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 50));
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
			//TODO: Define authorization rules in NhanVienGiaCanh
			//AuthorizationRules.AllowRead("MaNhanVien", "NhanVienGiaCanhReadGroup");
			//AuthorizationRules.AllowRead("MaGiaCanh", "NhanVienGiaCanhReadGroup");
			//AuthorizationRules.AllowRead("CoChungTu", "NhanVienGiaCanhReadGroup");
			//AuthorizationRules.AllowRead("NhanvienGiacanh", "NhanVienGiaCanhReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "NhanVienGiaCanhReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "NhanVienGiaCanhWriteGroup");
			//AuthorizationRules.AllowWrite("MaGiaCanh", "NhanVienGiaCanhWriteGroup");
			//AuthorizationRules.AllowWrite("CoChungTu", "NhanVienGiaCanhWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "NhanVienGiaCanhWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods

        public static int KiemTraHoChieu_GiaCanhDuyNhat(string HoChieu, long MaNhanVien)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraHoChieu_GiaCanhDuyNhat";
                        if (HoChieu.Length > 0)
                            cm.Parameters.AddWithValue("@HoChieu", HoChieu);
                        else
                            cm.Parameters.AddWithValue("@HoChieu", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);

                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        public static int KiemTraCMND_GiaCanhDuyNhat(string CMND,long MaNhanVien)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraCMND_GiaCanhDuyNhat";
                        if (CMND.Length > 0)
                            cm.Parameters.AddWithValue("@CMND", CMND);
                        else
                            cm.Parameters.AddWithValue("@CMND", DBNull.Value);

                        cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                        

                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        public static NhanVienGiaCanh NewNhanVienGiaCanh()
		{
			return new NhanVienGiaCanh();
		}

        public static NhanVienGiaCanh GetNhanVienGiaCanh(SafeDataReader dr)
		{
			return new NhanVienGiaCanh(dr);
		}

		private NhanVienGiaCanh()
		{

			//ValidationRules.CheckRules();
			MarkAsChild();
		}

		private NhanVienGiaCanh(SafeDataReader dr)
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
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maGiaCanh = dr.GetInt32("MaGiaCanh");
			_coChungTu = dr.GetBoolean("CoChungTu");
			_nhanvienGiacanh = dr.GetInt32("NhanVien_GiaCanh");
			_ghiChu = dr.GetString("GhiChu");
            _SoLuong = dr.GetInt32("SoLuong");
            _MaQuanHeGiaDinh = dr.GetInt32("MaQuanHeGiaDinh");
           
		}

		private void FetchChildren(SafeDataReader dr)
		{
            _nguoiPhuThuoc_ChungTuList = NguoiPhuThuoc_ChungTuGiaCanhList.GetNguoiPhuThuoc_ChungTuGiaCanhList(_nhanvienGiacanh);
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
                cm.CommandText = "spd_InserttblnsNhanVien_GiaCanh";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_nhanvienGiacanh = (int)cm.Parameters["@NhanVien_GiaCanh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maGiaCanh != 0)
				cm.Parameters.AddWithValue("@MaGiaCanh", _maGiaCanh);
			else
				cm.Parameters.AddWithValue("@MaGiaCanh", DBNull.Value);
            if (_SoLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _SoLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_MaQuanHeGiaDinh != 0)
                cm.Parameters.AddWithValue("@MaQuanHeGiaDinh", _MaQuanHeGiaDinh);
            else
                cm.Parameters.AddWithValue("@MaQuanHeGiaDinh", DBNull.Value);
			if (_coChungTu != false)
				cm.Parameters.AddWithValue("@CoChungTu", _coChungTu);
			else
				cm.Parameters.AddWithValue("@CoChungTu", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@NhanVien_GiaCanh", _nhanvienGiacanh);
          
			cm.Parameters["@NhanVien_GiaCanh"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsNhanVien_GiaCanh";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
            if (parent.MaNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maGiaCanh != 0)
				cm.Parameters.AddWithValue("@MaGiaCanh", _maGiaCanh);
			else
				cm.Parameters.AddWithValue("@MaGiaCanh", DBNull.Value);
            if (_SoLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _SoLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_MaQuanHeGiaDinh != 0)
                cm.Parameters.AddWithValue("@MaQuanHeGiaDinh", _MaQuanHeGiaDinh);
            else
                cm.Parameters.AddWithValue("@MaQuanHeGiaDinh", DBNull.Value);
			if (_coChungTu != false)
				cm.Parameters.AddWithValue("@CoChungTu", _coChungTu);
			else
				cm.Parameters.AddWithValue("@CoChungTu", DBNull.Value);
			cm.Parameters.AddWithValue("@NhanVien_GiaCanh", _nhanvienGiacanh);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
         
		}

		private void UpdateChildren(SqlTransaction tr)
		{
            _nguoiPhuThuoc_ChungTuList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            _nguoiPhuThuoc_ChungTuList.Clear();
            UpdateChildren(tr);
			ExecuteDelete(tr);
			MarkNew();
		}

		private void ExecuteDelete(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsNhanVien_GiaCanh";

				cm.Parameters.AddWithValue("@NhanVien_GiaCanh", this._nhanvienGiacanh);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
