using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThongTinNhanVienTrichNgang : Csla.BusinessBase<ThongTinNhanVienTrichNgang>
	{
		#region Business Properties and Methods

		//declare members
		private long _maNhanVien = 0;
		private string _tenNhanVien = string.Empty;
        private string _MaQLNhanVien = string.Empty;
		private int _maDocHai = 0;
        private NhanVien_DuLieuList _chitiet;

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaNhanVien
		{
			get
			{
				return _maNhanVien;
			}
		}

		public string TenNhanVien
		{
			get
			{
				return _tenNhanVien;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenNhanVien.Equals(value))
				{
					_tenNhanVien = value;
					PropertyHasChanged("TenNhanVien");
				}
			}
		}

        public string MaQLNhanVien
        {
            get
            {
                return _MaQLNhanVien;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_MaQLNhanVien.Equals(value))
                {
                    _MaQLNhanVien = value;
                    PropertyHasChanged("MaQLNhanVien");
                }
            }
        }

		public int MaDocHai
		{
			get
			{
				return _maDocHai;
			}
			set
			{
				if (!_maDocHai.Equals(value))
				{
					_maDocHai = value;
					PropertyHasChanged("MaDocHai");
				}
			}
		}

        public NhanVien_DuLieuList ChiTiet
        {
            get
            {
                return _chitiet;
            }
        }
 
		protected override object GetIdValue()
		{
			return _maNhanVien;
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
			// TenNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 500));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private ThongTinNhanVienTrichNgang()
		{ /* require use of factory method */
            _chitiet = NhanVien_DuLieuList.NewNhanVien_DuLieuList();
        }

		public static ThongTinNhanVienTrichNgang NewThongTinNhanVienTrichNgang(long maNhanVien)
		{
			return DataPortal.Create<ThongTinNhanVienTrichNgang>(new Criteria(maNhanVien));
		}

		public static ThongTinNhanVienTrichNgang GetThongTinNhanVienTrichNgang(long maNhanVien)
		{
			return DataPortal.Fetch<ThongTinNhanVienTrichNgang>(new Criteria(maNhanVien));
		}

		public static void DeleteThongTinNhanVienTrichNgang(long maNhanVien)
		{
			DataPortal.Delete(new Criteria(maNhanVien));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private ThongTinNhanVienTrichNgang(long maNhanVien)
		{
			this._maNhanVien = maNhanVien;
            _chitiet = NhanVien_DuLieuList.NewNhanVien_DuLieuList();
		}

		internal static ThongTinNhanVienTrichNgang NewThongTinNhanVienTrichNgangChild(long maNhanVien)
		{
			ThongTinNhanVienTrichNgang child = new ThongTinNhanVienTrichNgang(maNhanVien);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ThongTinNhanVienTrichNgang GetThongTinNhanVienTrichNgang(SafeDataReader dr)
		{
			ThongTinNhanVienTrichNgang child =  new ThongTinNhanVienTrichNgang();
			child.MarkAsChild();
			child.Fetch(dr);
            child._chitiet = NhanVien_DuLieuList.GetNhanVien_DuLieuList(child.MaNhanVien);
			return child;
		}
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public long MaNhanVien;

			public Criteria(long maNhanVien)
			{
				this.MaNhanVien = maNhanVien;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maNhanVien = criteria.MaNhanVien;
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
				cm.CommandText = "spd_Select_ThongTinNhanVienTrichNgang";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					ValidationRules.CheckRules();

					//load child object(s)
					FetchChildren(dr);
				}
			}//using
            _chitiet = NhanVien_DuLieuList.GetNhanVien_DuLieuList(_maNhanVien);
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
					ExecuteInsert(tr);

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
						ExecuteUpdate(tr);
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
			DataPortal_Delete(new Criteria(_maNhanVien));
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
				cm.CommandText = "spd_Delete_ThongTinNhanVienTrichNgang";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
            _MaQLNhanVien = dr.GetString("MaQLNhanVien");
			_maDocHai = dr.GetInt32("MaDocHai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_Insert_ThongTinNhanVienTrichNgang";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
            
			if (_maDocHai != 0)
				cm.Parameters.AddWithValue("@MaDocHai", _maDocHai);
			else
				cm.Parameters.AddWithValue("@MaDocHai", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_Update_ThongTinNhanVienTrichNgang";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
            
			if (_maDocHai != 0)
				cm.Parameters.AddWithValue("@MaDocHai", _maDocHai);
			else
				cm.Parameters.AddWithValue("@MaDocHai", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maNhanVien));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access


        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _chitiet.IsDirty;
            }
        }
	}
}
