
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhepNamTruoc : Csla.BusinessBase<PhepNamTruoc>
	{
		#region Business Properties and Methods

		//declare members
		private int _maPhepNamTruoc = 0;
		private long _maNhanVien = 0;
		private int _maBoPhan = 0;
		private int _nam = 0;
		private decimal _soNgay = 0;
		private int _nguoiLap = 0;
		private DateTime _ngayLap;
		private string _tenNhanVien = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaPhepNamTruoc
		{
			get
			{
				return _maPhepNamTruoc;
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

		public int MaBoPhan
		{
			get
			{
				return _maBoPhan;
			}
			set
			{
				if (!_maBoPhan.Equals(value))
				{
					_maBoPhan = value;
					PropertyHasChanged("MaBoPhan");
				}
			}
		}

		public int Nam
		{
			get
			{
				return _nam;
			}
			set
			{
				if (!_nam.Equals(value))
				{
					_nam = value;
					PropertyHasChanged("Nam");
				}
			}
		}

		public decimal SoNgay
		{
			get
			{
				return _soNgay;
			}
			set
			{
				if (!_soNgay.Equals(value))
				{
					_soNgay = value;
					PropertyHasChanged("SoNgay");
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
 
		protected override object GetIdValue()
		{
			return _maPhepNamTruoc;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 2000));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private PhepNamTruoc()
		{ /* require use of factory method */ }

		public static PhepNamTruoc NewPhepNamTruoc()
		{
			return DataPortal.Create<PhepNamTruoc>();
		}

		public static PhepNamTruoc GetPhepNamTruoc(int maPhepNamTruoc)
		{
			return DataPortal.Fetch<PhepNamTruoc>(new Criteria(maPhepNamTruoc));
		}

		public static void DeletePhepNamTruoc(int maPhepNamTruoc)
		{
			DataPortal.Delete(new Criteria(maPhepNamTruoc));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static PhepNamTruoc NewPhepNamTruocChild()
		{
			PhepNamTruoc child = new PhepNamTruoc();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhepNamTruoc GetPhepNamTruoc(SafeDataReader dr)
		{
			PhepNamTruoc child =  new PhepNamTruoc();
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
			public int MaPhepNamTruoc;

			public Criteria(int maPhepNamTruoc)
			{
				this.MaPhepNamTruoc = maPhepNamTruoc;
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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_SelecttblPhepNamTruoc]";

				cm.Parameters.AddWithValue("@MaPhepNamTruoc", criteria.MaPhepNamTruoc);

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
			DataPortal_Delete(new Criteria(_maPhepNamTruoc));
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
                cm.CommandText = "[spd_DeletetblPhepNamTruoc]";

				cm.Parameters.AddWithValue("@MaPhepNamTruoc", criteria.MaPhepNamTruoc);

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
			_maPhepNamTruoc = dr.GetInt32("MaPhepNamTruoc");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_nam = dr.GetInt32("Nam");
			_soNgay = dr.GetDecimal("SoNgay");
			_nguoiLap = dr.GetInt32("NguoiLap");
			_ngayLap = dr.GetDateTime("NgayLap");
			_tenNhanVien = dr.GetString("TenNhanVien");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, PhepNamTruocList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, PhepNamTruocList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_InserttblPhepNamTruoc]";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maPhepNamTruoc = (int)cm.Parameters["@MaPhepNamTruoc"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, PhepNamTruocList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_nam != 0)
				cm.Parameters.AddWithValue("@Nam", _nam);
			else
				cm.Parameters.AddWithValue("@Nam", DBNull.Value);
			if (_soNgay != 0)
				cm.Parameters.AddWithValue("@SoNgay", _soNgay);
			else
				cm.Parameters.AddWithValue("@SoNgay", DBNull.Value);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@MaPhepNamTruoc", _maPhepNamTruoc);
			cm.Parameters["@MaPhepNamTruoc"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, PhepNamTruocList parent)
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

		private void ExecuteUpdate(SqlConnection cn, PhepNamTruocList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_InsertUpdatetblPhepNamTruoc]";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, PhepNamTruocList parent)
		{
			cm.Parameters.AddWithValue("@MaPhepNamTruoc", _maPhepNamTruoc);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_nam != 0)
				cm.Parameters.AddWithValue("@Nam", _nam);
			else
				cm.Parameters.AddWithValue("@Nam", DBNull.Value);
			if (_soNgay != 0)
				cm.Parameters.AddWithValue("@SoNgay", _soNgay);
			else
				cm.Parameters.AddWithValue("@SoNgay", DBNull.Value);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maPhepNamTruoc));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
