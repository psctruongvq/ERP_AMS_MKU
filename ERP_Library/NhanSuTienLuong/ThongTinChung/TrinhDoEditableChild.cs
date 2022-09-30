
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TrinhDo : Csla.BusinessBase<TrinhDo>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTrinhDo = 0;
		private long _maNhanVien = 0;
		private int _maTrinhDoHocVan = 0;
		private int _maHocHam = 0;
		private int _maHocVi = 0;
		private int _maLyLuanCT = 0;
		//private int _maNgoaiNgu = 0;
        private int _maTrinhDoVanHoa = 0;
		private int _maTrinhDoTinhHoc = 0;
		private int _maChuyenMonNghiepVu = 0;
		private int _maTrinhDoChuyenMon = 0;
		private int _maChuyenNganh = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTrinhDo
		{
			get
			{
				CanReadProperty("MaTrinhDo", true);
				return _maTrinhDo;
			}
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

		public int MaTrinhDoHocVan
		{
			get
			{
				CanReadProperty("MaTrinhDoHocVan", true);
				return _maTrinhDoHocVan;
			}
			set
			{
				CanWriteProperty("MaTrinhDoHocVan", true);
				if (!_maTrinhDoHocVan.Equals(value))
				{
					_maTrinhDoHocVan = value;
					PropertyHasChanged("MaTrinhDoHocVan");
				}
			}
		}

		public int MaHocHam
		{
			get
			{
				CanReadProperty("MaHocHam", true);
				return _maHocHam;
			}
			set
			{
				CanWriteProperty("MaHocHam", true);
				if (!_maHocHam.Equals(value))
				{
					_maHocHam = value;
					PropertyHasChanged("MaHocHam");
				}
			}
		}

		public int MaHocVi
		{
			get
			{
				CanReadProperty("MaHocVi", true);
				return _maHocVi;
			}
			set
			{
				CanWriteProperty("MaHocVi", true);
				if (!_maHocVi.Equals(value))
				{
					_maHocVi = value;
					PropertyHasChanged("MaHocVi");
				}
			}
		}

		public int MaLyLuanCT
		{
			get
			{
				CanReadProperty("MaLyLuanCT", true);
				return _maLyLuanCT;
			}
			set
			{
				CanWriteProperty("MaLyLuanCT", true);
				if (!_maLyLuanCT.Equals(value))
				{
					_maLyLuanCT = value;
					PropertyHasChanged("MaLyLuanCT");
				}
			}
		}
        /*
		public int MaNgoaiNgu
		{
			get
			{
				CanReadProperty("MaNgoaiNgu", true);
				return _maNgoaiNgu;
			}
			set
			{
				CanWriteProperty("MaNgoaiNgu", true);
				if (!_maNgoaiNgu.Equals(value))
				{
					_maNgoaiNgu = value;
					PropertyHasChanged("MaNgoaiNgu");
				}
			}
		}
        */
        public int MaTrinhDoVanHoa
		{
			get
			{
                CanReadProperty("MaTrinhDoVanHoa", true);
				return _maTrinhDoVanHoa;
			}
			set
			{
                CanWriteProperty("MaTrinhDoVanHoa", true);
                if (!_maTrinhDoVanHoa.Equals(value))
				{
                    _maTrinhDoVanHoa = value;
                    PropertyHasChanged("MaTrinhDoVanHoa");
				}
			}
		}
        
		public int MaTrinhDoTinhHoc
		{
			get
			{
				CanReadProperty("MaTrinhDoTinhHoc", true);
				return _maTrinhDoTinhHoc;
			}
			set
			{
				CanWriteProperty("MaTrinhDoTinhHoc", true);
				if (!_maTrinhDoTinhHoc.Equals(value))
				{
					_maTrinhDoTinhHoc = value;
					PropertyHasChanged("MaTrinhDoTinhHoc");
				}
			}
		}

		public int MaChuyenMonNghiepVu
		{
			get
			{
				CanReadProperty("MaChuyenMonNghiepVu", true);
				return _maChuyenMonNghiepVu;
			}
			set
			{
				CanWriteProperty("MaChuyenMonNghiepVu", true);
				if (!_maChuyenMonNghiepVu.Equals(value))
				{
					_maChuyenMonNghiepVu = value;
					PropertyHasChanged("MaChuyenMonNghiepVu");
				}
			}
		}

		public int MaTrinhDoChuyenMon
		{
			get
			{
				CanReadProperty("MaTrinhDoChuyenMon", true);
				return _maTrinhDoChuyenMon;
			}
			set
			{
				CanWriteProperty("MaTrinhDoChuyenMon", true);
				if (!_maTrinhDoChuyenMon.Equals(value))
				{
					_maTrinhDoChuyenMon = value;
					PropertyHasChanged("MaTrinhDoChuyenMon");
				}
			}
		}

		public int MaChuyenNganh
		{
			get
			{
				CanReadProperty("MaChuyenNganh", true);
				return _maChuyenNganh;
			}
			set
			{
				CanWriteProperty("MaChuyenNganh", true);
				if (!_maChuyenNganh.Equals(value))
				{
					_maChuyenNganh = value;
					PropertyHasChanged("MaChuyenNganh");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTrinhDo;
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
			//TODO: Define authorization rules in TrinhDo
			//AuthorizationRules.AllowRead("MaTrinhDo", "TrinhDoReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "TrinhDoReadGroup");
			//AuthorizationRules.AllowRead("MaTrinhDoHocVan", "TrinhDoReadGroup");
			//AuthorizationRules.AllowRead("MaHocHam", "TrinhDoReadGroup");
			//AuthorizationRules.AllowRead("MaHocVi", "TrinhDoReadGroup");
			//AuthorizationRules.AllowRead("MaLyLuanCT", "TrinhDoReadGroup");
			//AuthorizationRules.AllowRead("MaNgoaiNgu", "TrinhDoReadGroup");
			//AuthorizationRules.AllowRead("MaTrinhDoNgoaiNgu", "TrinhDoReadGroup");
			//AuthorizationRules.AllowRead("MaTrinhDoTinhHoc", "TrinhDoReadGroup");
			//AuthorizationRules.AllowRead("MaChuyenMonNghiepVu", "TrinhDoReadGroup");
			//AuthorizationRules.AllowRead("MaTrinhDoChuyenMon", "TrinhDoReadGroup");
			//AuthorizationRules.AllowRead("MaChuyenNganh", "TrinhDoReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "TrinhDoWriteGroup");
			//AuthorizationRules.AllowWrite("MaTrinhDoHocVan", "TrinhDoWriteGroup");
			//AuthorizationRules.AllowWrite("MaHocHam", "TrinhDoWriteGroup");
			//AuthorizationRules.AllowWrite("MaHocVi", "TrinhDoWriteGroup");
			//AuthorizationRules.AllowWrite("MaLyLuanCT", "TrinhDoWriteGroup");
			//AuthorizationRules.AllowWrite("MaNgoaiNgu", "TrinhDoWriteGroup");
			//AuthorizationRules.AllowWrite("MaTrinhDoNgoaiNgu", "TrinhDoWriteGroup");
			//AuthorizationRules.AllowWrite("MaTrinhDoTinhHoc", "TrinhDoWriteGroup");
			//AuthorizationRules.AllowWrite("MaChuyenMonNghiepVu", "TrinhDoWriteGroup");
			//AuthorizationRules.AllowWrite("MaTrinhDoChuyenMon", "TrinhDoWriteGroup");
			//AuthorizationRules.AllowWrite("MaChuyenNganh", "TrinhDoWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static TrinhDo NewTrinhDo()
		{
			return new TrinhDo();
		}

		public static TrinhDo GetTrinhDo(SafeDataReader dr)
		{
			return new TrinhDo(dr);
		}

        public static TrinhDo GetTrinhDo(long maNhanVien)
        {
            return DataPortal.Fetch<TrinhDo>(new FilterCriteria(maNhanVien));
        }

		private TrinhDo()
		{

			//ValidationRules.CheckRules();
			MarkAsChild();
		}

		private TrinhDo(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods

		#region Data Access

		#region Data Access - Fetch

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaTrinhDo;

            public FilterCriteria(long MaTrinhDo)
            {
                this.MaTrinhDo = MaTrinhDo;
            }
        }
        
        #endregion //Filter Criteria

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
            _maTrinhDo = dr.GetInt32("MaTrinhDo");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maTrinhDoHocVan = dr.GetInt32("MaTrinhDoHocVan");
            _maHocHam = dr.GetInt32("MaHocHam");
            _maHocVi = dr.GetInt32("MaHocVi");
            _maLyLuanCT = dr.GetInt32("MaLyLuanCT");
            //_maNgoaiNgu = dr.GetInt32("MaNgoaiNgu");
            _maTrinhDoVanHoa = dr.GetInt32("MaTrinhDoVanHoa");
            _maTrinhDoTinhHoc = dr.GetInt32("MaTrinhDoTinhHoc");
            _maChuyenMonNghiepVu = dr.GetInt32("MaChuyenMonNghiepVu");
            _maTrinhDoChuyenMon = dr.GetInt32("MaTrinhDoChuyenMon");
            _maChuyenNganh = dr.GetInt32("MaChuyenNganh");
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
                cm.CommandText = "spd_InserttblnsTrinhDo";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maTrinhDo = (int)cm.Parameters["@MaTrinhDo"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			
			if (_maTrinhDoHocVan != 0)
				cm.Parameters.AddWithValue("@MaTrinhDoHocVan", _maTrinhDoHocVan);
			else
				cm.Parameters.AddWithValue("@MaTrinhDoHocVan", DBNull.Value);
			if (_maHocHam != 0)
				cm.Parameters.AddWithValue("@MaHocHam", _maHocHam);
			else
				cm.Parameters.AddWithValue("@MaHocHam", DBNull.Value);
			if (_maHocVi != 0)
				cm.Parameters.AddWithValue("@MaHocVi", _maHocVi);
			else
				cm.Parameters.AddWithValue("@MaHocVi", DBNull.Value);
			if (_maLyLuanCT != 0)
				cm.Parameters.AddWithValue("@MaLyLuanCT", _maLyLuanCT);
			else
				cm.Parameters.AddWithValue("@MaLyLuanCT", DBNull.Value);
            //if (_maNgoaiNgu != 0)
            //    cm.Parameters.AddWithValue("@MaNgoaiNgu", _maNgoaiNgu);
            //else
			//	cm.Parameters.AddWithValue("@MaNgoaiNgu", DBNull.Value);
            if (_maTrinhDoVanHoa != 0)
                cm.Parameters.AddWithValue("@MaTrinhDoVanHoa", _maTrinhDoVanHoa);
            else
                cm.Parameters.AddWithValue("@MaTrinhDoVanHoa", DBNull.Value);
			if (_maTrinhDoTinhHoc != 0)
				cm.Parameters.AddWithValue("@MaTrinhDoTinhHoc", _maTrinhDoTinhHoc);
			else
				cm.Parameters.AddWithValue("@MaTrinhDoTinhHoc", DBNull.Value);
			if (_maChuyenMonNghiepVu != 0)
				cm.Parameters.AddWithValue("@MaChuyenMonNghiepVu", _maChuyenMonNghiepVu);
			else
				cm.Parameters.AddWithValue("@MaChuyenMonNghiepVu", DBNull.Value);
			if (_maTrinhDoChuyenMon != 0)
				cm.Parameters.AddWithValue("@MaTrinhDoChuyenMon", _maTrinhDoChuyenMon);
			else
				cm.Parameters.AddWithValue("@MaTrinhDoChuyenMon", DBNull.Value);
			if (_maChuyenNganh != 0)
				cm.Parameters.AddWithValue("@MaChuyenNganh", _maChuyenNganh);
			else
				cm.Parameters.AddWithValue("@MaChuyenNganh", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTrinhDo", _maTrinhDo);
			cm.Parameters["@MaTrinhDo"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsTrinhDo";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
			cm.Parameters.AddWithValue("@MaTrinhDo", _maTrinhDo);
			
		    cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			
			if (_maTrinhDoHocVan != 0)
				cm.Parameters.AddWithValue("@MaTrinhDoHocVan", _maTrinhDoHocVan);
			else
				cm.Parameters.AddWithValue("@MaTrinhDoHocVan", DBNull.Value);
			if (_maHocHam != 0)
				cm.Parameters.AddWithValue("@MaHocHam", _maHocHam);
			else
				cm.Parameters.AddWithValue("@MaHocHam", DBNull.Value);
			if (_maHocVi != 0)
				cm.Parameters.AddWithValue("@MaHocVi", _maHocVi);
			else
				cm.Parameters.AddWithValue("@MaHocVi", DBNull.Value);
			if (_maLyLuanCT != 0)
				cm.Parameters.AddWithValue("@MaLyLuanCT", _maLyLuanCT);
			else
				cm.Parameters.AddWithValue("@MaLyLuanCT", DBNull.Value);
            //if (_maNgoaiNgu != 0)
            //    cm.Parameters.AddWithValue("@MaNgoaiNgu", _maNgoaiNgu);
            //else
			//	cm.Parameters.AddWithValue("@MaNgoaiNgu", DBNull.Value);
            if (_maTrinhDoVanHoa != 0)
                cm.Parameters.AddWithValue("@MaTrinhDoVanHoa", _maTrinhDoVanHoa);
            else
                cm.Parameters.AddWithValue("@MaTrinhDoVanHoa", DBNull.Value);
			if (_maTrinhDoTinhHoc != 0)
				cm.Parameters.AddWithValue("@MaTrinhDoTinhHoc", _maTrinhDoTinhHoc);
			else
				cm.Parameters.AddWithValue("@MaTrinhDoTinhHoc", DBNull.Value);
			if (_maChuyenMonNghiepVu != 0)
				cm.Parameters.AddWithValue("@MaChuyenMonNghiepVu", _maChuyenMonNghiepVu);
			else
				cm.Parameters.AddWithValue("@MaChuyenMonNghiepVu", DBNull.Value);
			if (_maTrinhDoChuyenMon != 0)
				cm.Parameters.AddWithValue("@MaTrinhDoChuyenMon", _maTrinhDoChuyenMon);
			else
				cm.Parameters.AddWithValue("@MaTrinhDoChuyenMon", DBNull.Value);
			if (_maChuyenNganh != 0)
				cm.Parameters.AddWithValue("@MaChuyenNganh", _maChuyenNganh);
			else
				cm.Parameters.AddWithValue("@MaChuyenNganh", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblnsTrinhDo";

				cm.Parameters.AddWithValue("@MaTrinhDo", this._maTrinhDo);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsTrinhDo";

                cm.Parameters.AddWithValue("@MaTrinhDo", criteria.MaTrinhDo);

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
		#endregion //Data Access
	}
}
