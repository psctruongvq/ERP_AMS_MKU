
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_DungCuLaoDong : Csla.BusinessBase<NhanVien_DungCuLaoDong>
	{
		#region Business Properties and Methods

		//declare members
		private int _manhanvienDungcu = 0;
		private long _maNhanVien = 0;
		private int _maDungCu = 0;
		private DateTime _ngayCap = DateTime.Today.Date;
		private int _thoiHan = 0;
		private DateTime _ngayHetHan = DateTime.Today.Date;
		private string _ghiChu = string.Empty;
		private bool _taiSuDung = false;
        private string _tenNhanVien = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _maQLNhanVien = string.Empty;
     
		[System.ComponentModel.DataObjectField(true, true)]
        	
        public string TenNhanVien
        {
            get { return _tenNhanVien; }
            set { _tenNhanVien = value; }
        }

        public string TenBoPhan
        {
            get { return _tenBoPhan; }
            set { _tenBoPhan = value; }
        }


        public string MaQLNhanVien
        {
            get { return _maQLNhanVien; }
            set { _maQLNhanVien = value; }
        }
		public int ManhanvienDungcu
		{
			get
			{
				return _manhanvienDungcu;
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
                 
				}
			}
		}

		public int MaDungCu
		{
			get
			{
				return _maDungCu;
			}
			set
			{
				if (!_maDungCu.Equals(value))
				{
					_maDungCu = value;
					PropertyHasChanged("MaDungCu");
				}
			}
		}

		public DateTime NgayCap
		{
			get
			{
                DungCuLaoDong dc = DungCuLaoDong.GetDungCuLaoDong(_maDungCu);
                _thoiHan = dc.ThoiGianSuDung;
                _ngayHetHan = _ngayCap.AddMonths(_thoiHan);
				return _ngayCap;
			}
			set
			{
				if (!_ngayCap.Equals(value))
				{
					_ngayCap = value;
                  
                    DungCuLaoDong dc = DungCuLaoDong.GetDungCuLaoDong(_maDungCu);
                    _thoiHan = dc.ThoiGianSuDung;
                    _ngayHetHan = _ngayCap.AddMonths(_thoiHan);
					PropertyHasChanged("NgayCap");
				}
			}
		}

		public int ThoiHan
		{
			get
			{
				return _thoiHan;
			}
			set
			{
				if (!_thoiHan.Equals(value))
				{
					_thoiHan = value;
					PropertyHasChanged("ThoiHan");
				}
			}
		}

		public DateTime NgayHetHan
		{
			get
			{
				return _ngayHetHan;
			}
			set
			{
				if (!_ngayHetHan.Equals(value))
				{
					_ngayHetHan = value;
					PropertyHasChanged("NgayHetHan");
				}
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

        public bool TaiSuDung
        {
            get
            {
                return _taiSuDung;
            }
            set
            {
                if (!_taiSuDung.Equals(value))
                {
                    _taiSuDung = value;
                    PropertyHasChanged("TaiSuDung");
                }
            }
        }
		protected override object GetIdValue()
		{
			return _manhanvienDungcu;
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
		private NhanVien_DungCuLaoDong()
		{ /* require use of factory method */ }

		public static NhanVien_DungCuLaoDong NewNhanVien_DungCuLaoDong()
		{
            NhanVien_DungCuLaoDong item = new NhanVien_DungCuLaoDong();
            item.MarkAsChild();
            return item;
		}

		public static NhanVien_DungCuLaoDong GetNhanVien_DungCuLaoDong(int manhanvienDungcu)
		{
			return DataPortal.Fetch<NhanVien_DungCuLaoDong>(new Criteria(manhanvienDungcu));
		}

		public static void DeleteNhanVien_DungCuLaoDong(int manhanvienDungcu)
		{
			DataPortal.Delete(new Criteria(manhanvienDungcu));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NhanVien_DungCuLaoDong NewNhanVien_DungCuLaoDongChild()
		{
			NhanVien_DungCuLaoDong child = new NhanVien_DungCuLaoDong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NhanVien_DungCuLaoDong GetNhanVien_DungCuLaoDong(SafeDataReader dr)
		{
			NhanVien_DungCuLaoDong child =  new NhanVien_DungCuLaoDong();
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
			public int ManhanvienDungcu;

			public Criteria(int manhanvienDungcu)
			{
				this.ManhanvienDungcu = manhanvienDungcu;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteFetch(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using
		}

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "SelecttblnsNhanVien_DungCuLD";

				cm.Parameters.AddWithValue("@MaNhanVien_DungCu", criteria.ManhanvienDungcu);

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

		#region Data Access - Insert
		protected override void DataPortal_Insert()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteInsert(tr, null);

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					if (base.IsDirty)
					{
						ExecuteUpdate(tr, null);
					}

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_manhanvienDungcu));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteDelete(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "DeletetblnsNhanVien_DungCuLD";

				cm.Parameters.AddWithValue("@MaNhanVien_DungCu", criteria.ManhanvienDungcu);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

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
			_manhanvienDungcu = dr.GetInt32("MaNhanVien_DungCu");
			_maNhanVien = dr.GetInt64("MaNhanVien");
            TenNV nv = TenNV.GetTenNhanVien(_maNhanVien);
            _tenNhanVien = nv.TenNhanVien;
            _tenBoPhan = nv.TenBoPhan;
            _maQLNhanVien = nv.MaQLNhanVien;
			_maDungCu = dr.GetInt32("MaDungCu");
			_ngayCap = dr.GetDateTime("NgayCap");
			_thoiHan = dr.GetInt32("ThoiHan");
			_ngayHetHan = dr.GetDateTime("NgayHetHan");
			_ghiChu = dr.GetString("GhiChu");
			_taiSuDung = dr.GetBoolean("TaiSuDung");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, NhanVien_DungCuLaoDongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, NhanVien_DungCuLaoDongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblnsNhanVien_DungCuLD";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_manhanvienDungcu = (int)cm.Parameters["@MaNhanVien_DungCu"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVien_DungCuLaoDongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maDungCu != 0)
				cm.Parameters.AddWithValue("@MaDungCu", _maDungCu);
			else
				cm.Parameters.AddWithValue("@MaDungCu", DBNull.Value);
				cm.Parameters.AddWithValue("@NgayCap", _ngayCap);
				if (_thoiHan != 0)
					cm.Parameters.AddWithValue("@ThoiHan", _thoiHan);
				else
					cm.Parameters.AddWithValue("@ThoiHan", DBNull.Value);
					cm.Parameters.AddWithValue("@NgayHetHan", _ngayHetHan);
					if (_ghiChu.Length > 0)
						cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
					else
						cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
					if (_taiSuDung != false)
						cm.Parameters.AddWithValue("@TaiSuDung", _taiSuDung);
					else
						cm.Parameters.AddWithValue("@TaiSuDung", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNhanVien_DungCu", _manhanvienDungcu);
			cm.Parameters["@MaNhanVien_DungCu"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, NhanVien_DungCuLaoDongList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, NhanVien_DungCuLaoDongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblnsNhanVien_DungCuLD";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien_DungCuLaoDongList parent)
		{
			cm.Parameters.AddWithValue("@MaNhanVien_DungCu", _manhanvienDungcu);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maDungCu != 0)
				cm.Parameters.AddWithValue("@MaDungCu", _maDungCu);
			else
				cm.Parameters.AddWithValue("@MaDungCu", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayCap", _ngayCap);
			if (_thoiHan != 0)
				cm.Parameters.AddWithValue("@ThoiHan", _thoiHan);
			else
				cm.Parameters.AddWithValue("@ThoiHan", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayHetHan", _ngayHetHan);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			if (_taiSuDung != false)
				cm.Parameters.AddWithValue("@TaiSuDung", _taiSuDung);
			else
				cm.Parameters.AddWithValue("@TaiSuDung", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_manhanvienDungcu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
