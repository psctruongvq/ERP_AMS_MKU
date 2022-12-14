// Chú ý : class này chỉ cập nhật field KyTinhLuongApDung của table QuyetDinhNangLuong

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TruyLuongNhanVien : Csla.BusinessBase<TruyLuongNhanVien>
	{
		#region Business Properties and Methods

		//declare members
		private int _maQuyetDinh = 0;
		private string _soQuyetDinh = string.Empty;
		private string _tenBoPhan = string.Empty;
		private string _tenNhanVien = string.Empty;
		private decimal _heSoCu = 0;
		private decimal _heSoMoi = 0;
		private DateTime _ngayHieuLuc = DateTime.Today;
		private int _kyTinhLuongApDung = 0;
        private DateTime _tuKy = DateTime.Today;
        private DateTime _denKy = DateTime.Today;
        private int _soKy = 0;
        private bool _traLuongQuaTK = false;
        private decimal _luongDot1 = 0;
        private decimal _luongDot2 = 0;
        private decimal _bhxh = 0;
        
		[System.ComponentModel.DataObjectField(true, false)]
		public int MaQuyetDinh
		{
			get
			{
				return _maQuyetDinh;
			}
		}

		public string SoQuyetDinh
		{
			get
			{
				return _soQuyetDinh;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soQuyetDinh.Equals(value))
				{
					_soQuyetDinh = value;
					PropertyHasChanged("SoQuyetDinh");
				}
			}
		}

		public string TenBoPhan
		{
			get
			{
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

		public decimal HeSoCu
		{
			get
			{
				return _heSoCu;
			}
			set
			{
				if (!_heSoCu.Equals(value))
				{
					_heSoCu = value;
					PropertyHasChanged("HeSoCu");
				}
			}
		}

		public decimal HeSoMoi
		{
			get
			{
				return _heSoMoi;
			}
			set
			{
				if (!_heSoMoi.Equals(value))
				{
					_heSoMoi = value;
					PropertyHasChanged("HeSoMoi");
				}
			}
		}

		public DateTime NgayHieuLuc
		{
			get
			{
				return _ngayHieuLuc;
			}
			set
			{
				if (!_ngayHieuLuc.Equals(value))
				{
					_ngayHieuLuc = value;
					PropertyHasChanged("NgayHieuLuc");
				}
			}
		}

		public int KyTinhLuongApDung
		{
			get
			{
				return _kyTinhLuongApDung;
			}
			set
			{
				if (!_kyTinhLuongApDung.Equals(value))
				{
					_kyTinhLuongApDung = value;
					PropertyHasChanged("KyTinhLuongApDung");
				}
			}
		}

        public DateTime TuKy
        {
            get
            {
                return _tuKy;
            }
            set
            {
                if (!_tuKy.Equals(value))
                {
                    _tuKy = value;
                    PropertyHasChanged();
                    int t = 0;
                    for (DateTime ng = _tuKy; ng <= _denKy; ng = ng.AddMonths(1)) t++;
                    SoKy = t;
                }
            }
        }

        public string TuKyStr
        {
            get
            {
                return _tuKy.ToString("MM/yyyy");
            }
            set
            {
                string s = _tuKy.ToString("MM/yyyy");
                if (!s.Equals(value))
                {
                    DateTime d = new DateTime(Convert.ToInt32(value.Substring(3, 4)), Convert.ToInt32(value.Substring(0, 2)), 1);
                    TuKy = d;
                }
            }
        }

        public DateTime DenKy
        {
            get
            {
                return _denKy;
            }
            set
            {
                if (!_denKy.Equals(value))
                {
                    _denKy = value;
                    PropertyHasChanged();
                    int t = 0;
                    for (DateTime ng = _tuKy; ng <= _denKy; ng = ng.AddMonths(1)) t++;
                    SoKy = t;
                }
            }
        }

        public string DenKyStr
        {
            get
            {
                return _denKy.ToString("MM/yyyy");
            }
            set
            {
                string s = _denKy.ToString("MM/yyyy");
                if (!s.Equals(value))
                {
                    DateTime d = new DateTime(Convert.ToInt32(value.Substring(3, 4)), Convert.ToInt32(value.Substring(0, 2)), 1);
                    DenKy = d;
                }
            }
        }


        public int SoKy
        {
            get
            {
                return _soKy;
            }
            set
            {
                if (!_soKy.Equals(value))
                {
                    _soKy = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool TraLuongQuaTK
        {
            get
            {
                return _traLuongQuaTK;
            }
            set
            {
                if (!_traLuongQuaTK.Equals(value))
                {
                    _traLuongQuaTK = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal LuongDot1
        {
            get
            {
                return _luongDot1;
            }
        }

        public decimal LuongDot2
        {
            get
            {
                return _luongDot2;
            }
        }

        public decimal BHXH
        {
            get
            {
                return _bhxh;
            }
        }

		protected override object GetIdValue()
		{
			return _maQuyetDinh;
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
			// SoQuyetDinh
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "SoQuyetDinh");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoQuyetDinh", 50));
			//
			// TenBoPhan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 200));
			//
			// TenNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 500));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("TuKyStr", "Chưa nhập tháng bắt đầu truy lương"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("DenKyStr", "Chưa nhập tháng kết thúc truy lương"));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private TruyLuongNhanVien()
		{ /* require use of factory method */ }

		public static TruyLuongNhanVien NewTruyLuongNhanVien(int maQuyetDinh)
		{
			return DataPortal.Create<TruyLuongNhanVien>(new Criteria(maQuyetDinh));
		}

		public static TruyLuongNhanVien GetTruyLuongNhanVien(int maQuyetDinh)
		{
			return DataPortal.Fetch<TruyLuongNhanVien>(new Criteria(maQuyetDinh));
		}

		public static void DeleteTruyLuongNhanVien(int maQuyetDinh)
		{
			DataPortal.Delete(new Criteria(maQuyetDinh));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private TruyLuongNhanVien(int maQuyetDinh)
		{
			this._maQuyetDinh = maQuyetDinh;
		}

		internal static TruyLuongNhanVien NewTruyLuongNhanVienChild(int maQuyetDinh)
		{
			TruyLuongNhanVien child = new TruyLuongNhanVien(maQuyetDinh);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TruyLuongNhanVien GetTruyLuongNhanVien(SafeDataReader dr)
		{
			TruyLuongNhanVien child =  new TruyLuongNhanVien();
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
			public int MaQuyetDinh;

			public Criteria(int maQuyetDinh)
			{
				this.MaQuyetDinh = maQuyetDinh;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maQuyetDinh = criteria.MaQuyetDinh;
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
				cm.CommandText = "spd_Select_TruyLuongNhanVien";

				cm.Parameters.AddWithValue("@MaQuyetDinh", criteria.MaQuyetDinh);

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
			DataPortal_Delete(new Criteria(_maQuyetDinh));
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
				cm.CommandText = "spd_Delete_TruyLuongNhanVien";

				cm.Parameters.AddWithValue("@MaQuyetDinh", criteria.MaQuyetDinh);
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
			_maQuyetDinh = dr.GetInt32("MaQuyetDinh");
			_soQuyetDinh = dr.GetString("SoQuyetDinh");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_heSoCu = dr.GetDecimal("HeSoCu");
			_heSoMoi = dr.GetDecimal("HeSoMoi");
			_ngayHieuLuc = dr.GetDateTime("NgayHieuLuc");
			_kyTinhLuongApDung = dr.GetInt32("KyTinhLuongApDung");
            _tuKy = dr.GetDateTime("TuKy");
            _denKy = dr.GetDateTime("DenKy");
            _soKy = dr.GetInt32("SoKy");
            _traLuongQuaTK = dr.GetBoolean("TraLuongQuaTK");
            _luongDot1 = dr.GetDecimal("LuongDot1");
            _luongDot2 = dr.GetDecimal("LuongDot2");
            _bhxh = dr.GetDecimal("BHXH");
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
				cm.CommandText = "spd_Insert_TruyLuongNhanVien";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);
            cm.Parameters.AddWithValue("@KyTinhLuongApDung", _kyTinhLuongApDung);
            cm.Parameters.AddWithValue("@TuKy", _tuKy);
            cm.Parameters.AddWithValue("@DenKy", _denKy);
            cm.Parameters.AddWithValue("@SoKy", _soKy);
            cm.Parameters.AddWithValue("@TraLuongQuaTK", _traLuongQuaTK);
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
                cm.CommandText = "spd_Insert_TruyLuongNhanVien";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
            cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);
            cm.Parameters.AddWithValue("@KyTinhLuongApDung", _kyTinhLuongApDung);
            cm.Parameters.AddWithValue("@TuKy", _tuKy);
            cm.Parameters.AddWithValue("@DenKy", _denKy);
            cm.Parameters.AddWithValue("@SoKy", _soKy);
            cm.Parameters.AddWithValue("@TraLuongQuaTK", _traLuongQuaTK);
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

			ExecuteDelete(tr, new Criteria(_maQuyetDinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
