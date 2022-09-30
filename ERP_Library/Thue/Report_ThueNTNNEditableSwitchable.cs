
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class Report_ThueNTNN : Csla.BusinessBase<Report_ThueNTNN>
	{
		#region Business Properties and Methods

		//declare members
		private int _maKy = 0;
		private string _noiDung = string.Empty;
		private string _maSoThue = string.Empty;
		private string _soHopDong = string.Empty;
		private decimal _soTienThanhToan = 0;
		private SmartDate _ngayThanhToan = new SmartDate(false);
		private decimal _tyLeGTGT = 0;
		private decimal _thueSuatGTGT = 0;
		private decimal _thueGTGTPhaiNop = 0;
		private decimal _tyLeThueTNDN = 0;
		private decimal _thueMienGiam = 0;
		private decimal _thueTNDNPhaiNop = 0;
		private string _vietBangChu = string.Empty;
        

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaKy
		{
			get
			{
				return _maKy;
			}
		}

		public string NoiDung
		{
			get
			{
				return _noiDung;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_noiDung.Equals(value))
				{
					_noiDung = value;
					PropertyHasChanged("NoiDung");
				}
			}
		}

		public string MaSoThue
		{
			get
			{
				return _maSoThue;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maSoThue.Equals(value))
				{
					_maSoThue = value;
					PropertyHasChanged("MaSoThue");
				}
			}
		}

		public string SoHopDong
		{
			get
			{
				return _soHopDong;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soHopDong.Equals(value))
				{
					_soHopDong = value;
					PropertyHasChanged("SoHopDong");
				}
			}
		}

		public decimal SoTienThanhToan
		{
			get
			{
				return _soTienThanhToan;
			}
			set
			{
				if (!_soTienThanhToan.Equals(value))
				{
					_soTienThanhToan = value;
					PropertyHasChanged("SoTienThanhToan");
				}
			}
		}

		public DateTime NgayThanhToan
		{
			get
			{
				return _ngayThanhToan.Date;
			}
		}

		public string NgayThanhToanString
		{
			get
			{
				return _ngayThanhToan.Text;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_ngayThanhToan.Equals(value))
				{
					_ngayThanhToan.Text = value;
					PropertyHasChanged("NgayThanhToanString");
				}
			}
		}

		public decimal TyLeGTGT
		{
			get
			{
				return _tyLeGTGT;
			}
			set
			{
				if (!_tyLeGTGT.Equals(value))
				{
					_tyLeGTGT = value;
					PropertyHasChanged("TyLeGTGT");
				}
			}
		}

		public decimal ThueSuatGTGT
		{
			get
			{
				return _thueSuatGTGT;
			}
			set
			{
				if (!_thueSuatGTGT.Equals(value))
				{
					_thueSuatGTGT = value;
					PropertyHasChanged("ThueSuatGTGT");
				}
			}
		}

		public decimal ThueGTGTPhaiNop
		{
			get
			{
				return _thueGTGTPhaiNop;
			}
			set
			{
				if (!_thueGTGTPhaiNop.Equals(value))
				{
					_thueGTGTPhaiNop = value;
					PropertyHasChanged("ThueGTGTPhaiNop");
				}
			}
		}

		public decimal TyLeThueTNDN
		{
			get
			{
				return _tyLeThueTNDN;
			}
			set
			{
				if (!_tyLeThueTNDN.Equals(value))
				{
					_tyLeThueTNDN = value;
					PropertyHasChanged("TyLeThueTNDN");
				}
			}
		}

		public decimal ThueMienGiam
		{
			get
			{
				return _thueMienGiam;
			}
			set
			{
				if (!_thueMienGiam.Equals(value))
				{
					_thueMienGiam = value;
					PropertyHasChanged("ThueMienGiam");
				}
			}
		}

		public decimal ThueTNDNPhaiNop
		{
			get
			{
				return _thueTNDNPhaiNop;
			}
			set
			{
				if (!_thueTNDNPhaiNop.Equals(value))
				{
					_thueTNDNPhaiNop = value;
					PropertyHasChanged("ThueTNDNPhaiNop");
				}
			}
		}

		public string VietBangChu
		{
			get
			{
				return _vietBangChu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_vietBangChu.Equals(value))
				{
					_vietBangChu = value;
					PropertyHasChanged("VietBangChu");
				}
			}
		}

        public decimal DoanhThuTinhThueGTGT
        {
            get
            {
                return _soTienThanhToan + _thueGTGTPhaiNop;
            }
            
        }

        public decimal DoanhThuTinhThueTNDN
        {
            get
            {
                return _soTienThanhToan + _thueTNDNPhaiNop;
            }

        }
        public decimal TongSoThueNopVaoNSNN
        {
            get
            {
                return _thueGTGTPhaiNop +  _thueTNDNPhaiNop -_thueMienGiam;
            }

        }
 

		protected override object GetIdValue()
		{
			return _maKy;
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
			// NoiDung
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiDung", 4000));
			//
			// MaSoThue
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaSoThue", 50));
			//
			// SoHopDong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHopDong", 20));
			//
			// VietBangChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("VietBangChu", 2000));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private Report_ThueNTNN()
		{ /* require use of factory method */ }

		public static Report_ThueNTNN NewReport_ThueNTNN(int maKy)
		{
			return DataPortal.Create<Report_ThueNTNN>(new Criteria(maKy));
		}

		public static Report_ThueNTNN GetReport_ThueNTNN(int maKy)
		{
			return DataPortal.Fetch<Report_ThueNTNN>(new Criteria(maKy));
		}

		public static void DeleteReport_ThueNTNN(int maKy)
		{
			DataPortal.Delete(new Criteria(maKy));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private Report_ThueNTNN(int maKy)
		{
			this._maKy = maKy;
		}

		internal static Report_ThueNTNN NewReport_ThueNTNNChild(int maKy)
		{
			Report_ThueNTNN child = new Report_ThueNTNN(maKy);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static Report_ThueNTNN GetReport_ThueNTNN(SafeDataReader dr)
		{
			Report_ThueNTNN child =  new Report_ThueNTNN();
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
			public int MaKy;

			public Criteria(int maKy)
			{
				this.MaKy = maKy;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maKy = criteria.MaKy;
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
				cm.CommandText = "spd_ToKhaiThueNhaThauNuocNgoai";

				cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

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
			DataPortal_Delete(new Criteria(_maKy));
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
				cm.CommandText = "DeleteReport_ThueNTNN";

				cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

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
			_maKy = dr.GetInt32("MaKy");
			_noiDung = dr.GetString("NoiDung");
			_maSoThue = dr.GetString("MaSoThue");
			_soHopDong = dr.GetString("SoHopDong");
			_soTienThanhToan = dr.GetDecimal("SoTienThanhToan");
			_ngayThanhToan = dr.GetSmartDate("NgayThanhToan", _ngayThanhToan.EmptyIsMin);
			_tyLeGTGT = dr.GetDecimal("TyLeGTGT");
			_thueSuatGTGT = dr.GetDecimal("ThueSuatGTGT");
			_thueGTGTPhaiNop = dr.GetDecimal("ThueGTGTPhaiNop");
			_tyLeThueTNDN = dr.GetDecimal("TyLeThueTNDN");
			_thueMienGiam = dr.GetDecimal("ThueMienGiam");
			_thueTNDNPhaiNop = dr.GetDecimal("ThueTNDNPhaiNop");
			_vietBangChu = dr.GetString("VietBangChu");
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
				cm.CommandText = "AddReport_ThueNTNN";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maKy != 0)
				cm.Parameters.AddWithValue("@MaKy", _maKy);
			else
				cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
			if (_noiDung.Length > 0)
				cm.Parameters.AddWithValue("@NoiDung", _noiDung);
			else
				cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
			if (_maSoThue.Length > 0)
				cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
			else
				cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
			if (_soHopDong.Length > 0)
				cm.Parameters.AddWithValue("@SoHopDong", _soHopDong);
			else
				cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);
			cm.Parameters.AddWithValue("@SoTienThanhToan", _soTienThanhToan);
			cm.Parameters.AddWithValue("@NgayThanhToan", _ngayThanhToan.DBValue);
			if (_tyLeGTGT != 0)
				cm.Parameters.AddWithValue("@TyLeGTGT", _tyLeGTGT);
			else
				cm.Parameters.AddWithValue("@TyLeGTGT", DBNull.Value);
			if (_thueSuatGTGT != 0)
				cm.Parameters.AddWithValue("@ThueSuatGTGT", _thueSuatGTGT);
			else
				cm.Parameters.AddWithValue("@ThueSuatGTGT", DBNull.Value);
			if (_thueGTGTPhaiNop != 0)
				cm.Parameters.AddWithValue("@ThueGTGTPhaiNop", _thueGTGTPhaiNop);
			else
				cm.Parameters.AddWithValue("@ThueGTGTPhaiNop", DBNull.Value);
			if (_tyLeThueTNDN != 0)
				cm.Parameters.AddWithValue("@TyLeThueTNDN", _tyLeThueTNDN);
			else
				cm.Parameters.AddWithValue("@TyLeThueTNDN", DBNull.Value);
			if (_thueMienGiam != 0)
				cm.Parameters.AddWithValue("@ThueMienGiam", _thueMienGiam);
			else
				cm.Parameters.AddWithValue("@ThueMienGiam", DBNull.Value);
			if (_thueTNDNPhaiNop != 0)
				cm.Parameters.AddWithValue("@ThueTNDNPhaiNop", _thueTNDNPhaiNop);
			else
				cm.Parameters.AddWithValue("@ThueTNDNPhaiNop", DBNull.Value);
			if (_vietBangChu.Length > 0)
				cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
			else
				cm.Parameters.AddWithValue("@VietBangChu", DBNull.Value);
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
				cm.CommandText = "UpdateReport_ThueNTNN";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			if (_maKy != 0)
				cm.Parameters.AddWithValue("@MaKy", _maKy);
			else
				cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
			if (_noiDung.Length > 0)
				cm.Parameters.AddWithValue("@NoiDung", _noiDung);
			else
				cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
			if (_maSoThue.Length > 0)
				cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
			else
				cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
			if (_soHopDong.Length > 0)
				cm.Parameters.AddWithValue("@SoHopDong", _soHopDong);
			else
				cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);
			cm.Parameters.AddWithValue("@SoTienThanhToan", _soTienThanhToan);
			cm.Parameters.AddWithValue("@NgayThanhToan", _ngayThanhToan.DBValue);
			if (_tyLeGTGT != 0)
				cm.Parameters.AddWithValue("@TyLeGTGT", _tyLeGTGT);
			else
				cm.Parameters.AddWithValue("@TyLeGTGT", DBNull.Value);
			if (_thueSuatGTGT != 0)
				cm.Parameters.AddWithValue("@ThueSuatGTGT", _thueSuatGTGT);
			else
				cm.Parameters.AddWithValue("@ThueSuatGTGT", DBNull.Value);
			if (_thueGTGTPhaiNop != 0)
				cm.Parameters.AddWithValue("@ThueGTGTPhaiNop", _thueGTGTPhaiNop);
			else
				cm.Parameters.AddWithValue("@ThueGTGTPhaiNop", DBNull.Value);
			if (_tyLeThueTNDN != 0)
				cm.Parameters.AddWithValue("@TyLeThueTNDN", _tyLeThueTNDN);
			else
				cm.Parameters.AddWithValue("@TyLeThueTNDN", DBNull.Value);
			if (_thueMienGiam != 0)
				cm.Parameters.AddWithValue("@ThueMienGiam", _thueMienGiam);
			else
				cm.Parameters.AddWithValue("@ThueMienGiam", DBNull.Value);
			if (_thueTNDNPhaiNop != 0)
				cm.Parameters.AddWithValue("@ThueTNDNPhaiNop", _thueTNDNPhaiNop);
			else
				cm.Parameters.AddWithValue("@ThueTNDNPhaiNop", DBNull.Value);
			if (_vietBangChu.Length > 0)
				cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
			else
				cm.Parameters.AddWithValue("@VietBangChu", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maKy));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
