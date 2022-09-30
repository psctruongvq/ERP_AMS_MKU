
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVienCongDoan : Csla.BusinessBase<NhanVienCongDoan>
	{
		#region Business Properties and Methods

		//declare members
		private string _maBoPhanQL = string.Empty;
		private string _tenBoPhan = string.Empty;
		private string _maQLNhanVien = string.Empty;
		private string _tenNhanVien = string.Empty;
		private string _tenChucVu = string.Empty;
		
		private DateTime _ngayVaoDai = DateTime.Today;
        private Nullable<DateTime> _ngayVaoCongDoan = null;
	
		private decimal _heSoPhuCapChucVu = 0;
		private decimal _heSoLuongNoiBo = 0;
		private decimal _heSoLuongBoSung = 0;
		private decimal _heSoVuotKhung = 0;
		private decimal _heSoBu = 0;
		private decimal _heSoDocHai = 0;
		private decimal _heSoLuong = 0;
		private decimal _heSoVuotKhungBH = 0;
		private decimal _heSoLuongBaoHiem = 0;

		public string MaBoPhanQL
		{
			get
			{
				CanReadProperty("MaBoPhanQL", true);
				return _maBoPhanQL;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maBoPhanQL.Equals(value))
				{
					_maBoPhanQL = value;
					PropertyHasChanged("MaBoPhanQL");
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
				if (value == null) value = string.Empty;
				if (!_tenBoPhan.Equals(value))
				{
					_tenBoPhan = value;
					PropertyHasChanged("TenBoPhan");
				}
			}
		}

		public string MaQLNhanVien
		{
			get
			{
				CanReadProperty("MaQLNhanVien", true);
				return _maQLNhanVien;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maQLNhanVien.Equals(value))
				{
					_maQLNhanVien = value;
					PropertyHasChanged("MaQLNhanVien");
				}
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public string TenNhanVien
		{
			get
			{
				CanReadProperty("TenNhanVien", true);
				return _tenNhanVien;
			}
		}

		public string TenChucVu
		{
			get
			{
				CanReadProperty("TenChucVu", true);
				return _tenChucVu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenChucVu.Equals(value))
				{
					_tenChucVu = value;
					PropertyHasChanged("TenChucVu");
				}
			}
		}



        public DateTime NgayVaoDai
		{
			get
			{
                CanReadProperty("NgayVaoDai", true);
				return _ngayVaoDai;
			}
			set
			{
				if (!_ngayVaoDai.Equals(value))
				{
					_ngayVaoDai = value;
                    PropertyHasChanged("NgayVaoDai");
				}
			}
		}
        public Nullable<DateTime> NgayVaoCongDoan
        {
            get
            {
                CanReadProperty("NgayVaoCongDoan", true);
                return _ngayVaoCongDoan;
            }
            set
            {
                if (!_ngayVaoCongDoan.Equals(value))
                {
                    _ngayVaoCongDoan = value;
                    PropertyHasChanged("NgayVaoCongDoan");
                }
            }
        }
	
		public decimal HeSoPhuCapChucVu
		{
			get
			{
				CanReadProperty("HeSoPhuCapChucVu", true);
				return _heSoPhuCapChucVu;
			}
			set
			{
				if (!_heSoPhuCapChucVu.Equals(value))
				{
					_heSoPhuCapChucVu = value;
					PropertyHasChanged("HeSoPhuCapChucVu");
				}
			}
		}

		public decimal HeSoLuongNoiBo
		{
			get
			{
				CanReadProperty("HeSoLuongNoiBo", true);
				return _heSoLuongNoiBo;
			}
			set
			{
				if (!_heSoLuongNoiBo.Equals(value))
				{
					_heSoLuongNoiBo = value;
					PropertyHasChanged("HeSoLuongNoiBo");
				}
			}
		}

		public decimal HeSoLuongBoSung
		{
			get
			{
				CanReadProperty("HeSoLuongBoSung", true);
				return _heSoLuongBoSung;
			}
			set
			{
				if (!_heSoLuongBoSung.Equals(value))
				{
					_heSoLuongBoSung = value;
					PropertyHasChanged("HeSoLuongBoSung");
				}
			}
		}

		public decimal HeSoVuotKhung
		{
			get
			{
				CanReadProperty("HeSoVuotKhung", true);
				return _heSoVuotKhung;
			}
			set
			{
				if (!_heSoVuotKhung.Equals(value))
				{
					_heSoVuotKhung = value;
					PropertyHasChanged("HeSoVuotKhung");
				}
			}
		}

		public decimal HeSoBu
		{
			get
			{
				CanReadProperty("HeSoBu", true);
				return _heSoBu;
			}
			set
			{
				if (!_heSoBu.Equals(value))
				{
					_heSoBu = value;
					PropertyHasChanged("HeSoBu");
				}
			}
		}

		public decimal HeSoDocHai
		{
			get
			{
				CanReadProperty("HeSoDocHai", true);
				return _heSoDocHai;
			}
			set
			{
				if (!_heSoDocHai.Equals(value))
				{
					_heSoDocHai = value;
					PropertyHasChanged("HeSoDocHai");
				}
			}
		}

		public decimal HeSoLuong
		{
			get
			{
				CanReadProperty("HeSoLuong", true);
				return _heSoLuong;
			}
			set
			{
				if (!_heSoLuong.Equals(value))
				{
					_heSoLuong = value;
					PropertyHasChanged("HeSoLuong");
				}
			}
		}

		public decimal HeSoVuotKhungBH
		{
			get
			{
				CanReadProperty("HeSoVuotKhungBH", true);
				return _heSoVuotKhungBH;
			}
			set
			{
				if (!_heSoVuotKhungBH.Equals(value))
				{
					_heSoVuotKhungBH = value;
					PropertyHasChanged("HeSoVuotKhungBH");
				}
			}
		}

		public decimal HeSoLuongBaoHiem
		{
			get
			{
				CanReadProperty("HeSoLuongBaoHiem", true);
				return _heSoLuongBaoHiem;
			}
			set
			{
				if (!_heSoLuongBaoHiem.Equals(value))
				{
					_heSoLuongBaoHiem = value;
					PropertyHasChanged("HeSoLuongBaoHiem");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _tenNhanVien;
		}

		#endregion //Business Properties and Methods

	
		#region Factory Methods
		private NhanVienCongDoan()
		{ /* require use of factory method */ }

		public static NhanVienCongDoan NewNhanVienCongDoan(string tenNhanVien)
		{
			return DataPortal.Create<NhanVienCongDoan>(new Criteria(tenNhanVien));
		}

		public static NhanVienCongDoan GetNhanVienCongDoan(string tenNhanVien)
		{
			return DataPortal.Fetch<NhanVienCongDoan>(new Criteria(tenNhanVien));
		}

	
		#endregion //Factory Methods

		#region Child Factory Methods
		private NhanVienCongDoan(string tenNhanVien)
		{
			this._tenNhanVien = tenNhanVien;
		}

		internal static NhanVienCongDoan NewNhanVienCongDoanChild(string tenNhanVien)
		{
			NhanVienCongDoan child = new NhanVienCongDoan(tenNhanVien);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NhanVienCongDoan GetNhanVienCongDoan(SafeDataReader dr)
		{
			NhanVienCongDoan child =  new NhanVienCongDoan();
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
			public string TenNhanVien;

			public Criteria(string tenNhanVien)
			{
				this.TenNhanVien = tenNhanVien;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_tenNhanVien = criteria.TenNhanVien;
			//ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
        //private void DataPortal_Fetch(Criteria criteria)
        //{
        //    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //    {
        //        cn.Open();

        //        ExecuteFetch(cn, criteria);
        //    }//using
        //}

        //private void ExecuteFetch(SqlConnection cn, Criteria criteria)
        //{
        //    using (SqlCommand cm = cn.CreateCommand())
        //    {
        //        cm.CommandType = CommandType.StoredProcedure;
        //        cm.CommandText = "SelectAAAAA?";

        //        cm.Parameters.AddWithValue("@TenNhanVien", criteria.TenNhanVien);

        //        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
        //        {
        //            dr.Read();
        //            FetchObject(dr);
        //            ValidationRules.CheckRules();

        //            //load child object(s)
        //            FetchChildren(dr);
        //        }
        //    }//using
        //}

		#endregion //Data Access - Fetch
        /*
		#region Data Access - Insert
		protected override void DataPortal_Insert()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn, null);

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				if (base.IsDirty)
				{
					ExecuteUpdate(cn, null);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_tenNhanVien));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteDelete(cn, criteria);

			}//using

		}

		private void ExecuteDelete(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "DeleteAAAAA?";

				cm.Parameters.AddWithValue("@TenNhanVien", criteria.TenNhanVien);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
        */
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
			_maBoPhanQL = dr.GetString("MaBoPhanQL");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_maQLNhanVien = dr.GetString("MaQLNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_tenChucVu = dr.GetString("TenChucVu");

            object ngayKetCD = dr.GetValue("NgayThamGia");
            if (ngayKetCD != null)
                _ngayVaoCongDoan = Convert.ToDateTime(ngayKetCD).Date;
            else
                _ngayVaoCongDoan = null;
			_heSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
			_heSoLuongNoiBo = dr.GetDecimal("HeSoLuongNoiBo");
			_heSoLuongBoSung = dr.GetDecimal("HeSoLuongBoSung");
			_heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
			_heSoBu = dr.GetDecimal("HeSoBu");
			_heSoDocHai = dr.GetDecimal("HeSoDocHai");
			_heSoLuong = dr.GetDecimal("HeSoLuong");
			_heSoVuotKhungBH = dr.GetDecimal("HeSoVuotKhungBH");
			_heSoLuongBaoHiem = dr.GetDecimal("HeSoLuongBaoHiem");
            _ngayVaoDai = dr.GetDateTime("NgayVaoNganh").Date;
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch
        /*
		#region Data Access - Insert
		internal void Insert(SqlConnection cn, NhanVienCongDoanList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, NhanVienCongDoanList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InsertAAAAA?";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVienCongDoanList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maBoPhanQL.Length > 0)
				cm.Parameters.AddWithValue("@MaBoPhanQL", _maBoPhanQL);
			else
				cm.Parameters.AddWithValue("@MaBoPhanQL", DBNull.Value);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			if (_maQLNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
			else
				cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			if (_tenChucVu.Length > 0)
				cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
			else
				cm.Parameters.AddWithValue("@TenChucVu", DBNull.Value);
			if (_soQuyetDinh.Length > 0)
				cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			else
				cm.Parameters.AddWithValue("@SoQuyetDinh", DBNull.Value);
			if (_ngayHieuLuc != DateTime.Today)
				cm.Parameters.AddWithValue("@NgayHieuLuc", _ngayHieuLuc);
			else
				cm.Parameters.AddWithValue("@NgayHieuLuc", DBNull.Value);
			if (_lyDo.Length > 0)
				cm.Parameters.AddWithValue("@LyDo", _lyDo);
			else
				cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
			if (_heSoPhuCapChucVu != 0)
				cm.Parameters.AddWithValue("@HeSoPhuCapChucVu", _heSoPhuCapChucVu);
			else
				cm.Parameters.AddWithValue("@HeSoPhuCapChucVu", DBNull.Value);
			if (_heSoLuongNoiBo != 0)
				cm.Parameters.AddWithValue("@HeSoLuongNoiBo", _heSoLuongNoiBo);
			else
				cm.Parameters.AddWithValue("@HeSoLuongNoiBo", DBNull.Value);
			if (_heSoLuongBoSung != 0)
				cm.Parameters.AddWithValue("@HeSoLuongBoSung", _heSoLuongBoSung);
			else
				cm.Parameters.AddWithValue("@HeSoLuongBoSung", DBNull.Value);
			if (_heSoVuotKhung != 0)
				cm.Parameters.AddWithValue("@HeSoVuotKhung", _heSoVuotKhung);
			else
				cm.Parameters.AddWithValue("@HeSoVuotKhung", DBNull.Value);
			if (_heSoBu != 0)
				cm.Parameters.AddWithValue("@HeSoBu", _heSoBu);
			else
				cm.Parameters.AddWithValue("@HeSoBu", DBNull.Value);
			if (_heSoDocHai != 0)
				cm.Parameters.AddWithValue("@HeSoDocHai", _heSoDocHai);
			else
				cm.Parameters.AddWithValue("@HeSoDocHai", DBNull.Value);
			if (_heSoLuong != 0)
				cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
			else
				cm.Parameters.AddWithValue("@HeSoLuong", DBNull.Value);
			if (_heSoVuotKhungBH != 0)
				cm.Parameters.AddWithValue("@HeSoVuotKhungBH", _heSoVuotKhungBH);
			else
				cm.Parameters.AddWithValue("@HeSoVuotKhungBH", DBNull.Value);
			if (_heSoLuongBaoHiem != 0)
				cm.Parameters.AddWithValue("@HeSoLuongBaoHiem", _heSoLuongBaoHiem);
			else
				cm.Parameters.AddWithValue("@HeSoLuongBaoHiem", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, NhanVienCongDoanList parent)
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

		private void ExecuteUpdate(SqlConnection cn, NhanVienCongDoanList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdateAAAAA?";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVienCongDoanList parent)
		{
			if (_maBoPhanQL.Length > 0)
				cm.Parameters.AddWithValue("@MaBoPhanQL", _maBoPhanQL);
			else
				cm.Parameters.AddWithValue("@MaBoPhanQL", DBNull.Value);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			if (_maQLNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
			else
				cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			if (_tenChucVu.Length > 0)
				cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
			else
				cm.Parameters.AddWithValue("@TenChucVu", DBNull.Value);
			if (_soQuyetDinh.Length > 0)
				cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			else
				cm.Parameters.AddWithValue("@SoQuyetDinh", DBNull.Value);
			if (_ngayHieuLuc != DateTime.Today)
				cm.Parameters.AddWithValue("@NgayHieuLuc", _ngayHieuLuc);
			else
				cm.Parameters.AddWithValue("@NgayHieuLuc", DBNull.Value);
			if (_lyDo.Length > 0)
				cm.Parameters.AddWithValue("@LyDo", _lyDo);
			else
				cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
			if (_heSoPhuCapChucVu != 0)
				cm.Parameters.AddWithValue("@HeSoPhuCapChucVu", _heSoPhuCapChucVu);
			else
				cm.Parameters.AddWithValue("@HeSoPhuCapChucVu", DBNull.Value);
			if (_heSoLuongNoiBo != 0)
				cm.Parameters.AddWithValue("@HeSoLuongNoiBo", _heSoLuongNoiBo);
			else
				cm.Parameters.AddWithValue("@HeSoLuongNoiBo", DBNull.Value);
			if (_heSoLuongBoSung != 0)
				cm.Parameters.AddWithValue("@HeSoLuongBoSung", _heSoLuongBoSung);
			else
				cm.Parameters.AddWithValue("@HeSoLuongBoSung", DBNull.Value);
			if (_heSoVuotKhung != 0)
				cm.Parameters.AddWithValue("@HeSoVuotKhung", _heSoVuotKhung);
			else
				cm.Parameters.AddWithValue("@HeSoVuotKhung", DBNull.Value);
			if (_heSoBu != 0)
				cm.Parameters.AddWithValue("@HeSoBu", _heSoBu);
			else
				cm.Parameters.AddWithValue("@HeSoBu", DBNull.Value);
			if (_heSoDocHai != 0)
				cm.Parameters.AddWithValue("@HeSoDocHai", _heSoDocHai);
			else
				cm.Parameters.AddWithValue("@HeSoDocHai", DBNull.Value);
			if (_heSoLuong != 0)
				cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
			else
				cm.Parameters.AddWithValue("@HeSoLuong", DBNull.Value);
			if (_heSoVuotKhungBH != 0)
				cm.Parameters.AddWithValue("@HeSoVuotKhungBH", _heSoVuotKhungBH);
			else
				cm.Parameters.AddWithValue("@HeSoVuotKhungBH", DBNull.Value);
			if (_heSoLuongBaoHiem != 0)
				cm.Parameters.AddWithValue("@HeSoLuongBaoHiem", _heSoLuongBaoHiem);
			else
				cm.Parameters.AddWithValue("@HeSoLuongBaoHiem", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_tenNhanVien));
			MarkNew();
		}
		#endregion //Data Access - Delete
        */
		#endregion //Data Access
	}
}
