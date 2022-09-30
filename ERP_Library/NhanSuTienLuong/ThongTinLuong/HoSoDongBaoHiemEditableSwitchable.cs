using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HoSoDongBaoHiem : Csla.BusinessBase<HoSoDongBaoHiem>
	{
		#region Business Properties and Methods

		//declare members
		private int _maDongBaoHiem = 0;
		private long _maNhanVien = 0;
        private DateTime _tuNgay = DateTime.Today;
        private DateTime _denNgay = DateTime.Today;
		private double _heSoBHXH = 0;
		private double _heSoBHYT = 0;
		private double _heSoCongDoan = 0;
		private string _dienGiai = string.Empty;
        private string _maQLNhanVien = string.Empty;
        private string _tenNhanVien = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaDongBaoHiem
		{
			get
			{
				CanReadProperty("MaDongBaoHiem", true);
				return _maDongBaoHiem;
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

        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty("MaQLNhanVien", true);
                _maQLNhanVien = NhanVien.GetNhanVien(_maNhanVien).MaQLNhanVien;
                return _maQLNhanVien;
            }
        }

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                _tenNhanVien = NhanVien.GetNhanVien(_maNhanVien).TenNhanVien;
                return _tenNhanVien;
            }
        }

		public DateTime TuNgay
		{
			get
			{
				CanReadProperty("TuNgay", true);
				return _tuNgay.Date;
			}
            set
            {
                CanWriteProperty("TuNgay", true);
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay = value;
                    PropertyHasChanged("TuNgay");
                }
            }
		}

		public DateTime DenNgay
		{
			get
			{
				CanReadProperty("DenNgay", true);
				return _denNgay.Date;
			}
            set
            {
                CanWriteProperty("DenNgay", true);
                if (!_denNgay.Equals(value))
                {
                    _denNgay = value;
                    PropertyHasChanged("DenNgay");
                }
            }
		}

		public double HeSoBHXH
		{
			get
			{
				CanReadProperty("HeSoBHXH", true);
				return _heSoBHXH;
			}
			set
			{
				CanWriteProperty("HeSoBHXH", true);
				if (!_heSoBHXH.Equals(value))
				{
					_heSoBHXH = value;
					PropertyHasChanged("HeSoBHXH");
				}
			}
		}

		public double HeSoBHYT
		{
			get
			{
				CanReadProperty("HeSoBHYT", true);
				return _heSoBHYT;
			}
			set
			{
				CanWriteProperty("HeSoBHYT", true);
				if (!_heSoBHYT.Equals(value))
				{
					_heSoBHYT = value;
					PropertyHasChanged("HeSoBHYT");
				}
			}
		}

		public double HeSoCongDoan
		{
			get
			{
				CanReadProperty("HeSoCongDoan", true);
				return _heSoCongDoan;
			}
			set
			{
				CanWriteProperty("HeSoCongDoan", true);
				if (!_heSoCongDoan.Equals(value))
				{
					_heSoCongDoan = value;
					PropertyHasChanged("HeSoCongDoan");
				}
			}
		}

		public string DienGiai
		{
			get
			{
				CanReadProperty("DienGiai", true);
				return _dienGiai;
			}
			set
			{
				CanWriteProperty("DienGiai", true);
				if (value == null) value = string.Empty;
				if (!_dienGiai.Equals(value))
				{
					_dienGiai = value;
					PropertyHasChanged("DienGiai");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maDongBaoHiem;
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
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
			//TODO: Define authorization rules in HoSoDongBaoHiem
			//AuthorizationRules.AllowRead("MaDongBaoHiem", "HoSoDongBaoHiemReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "HoSoDongBaoHiemReadGroup");
			//AuthorizationRules.AllowRead("TuNgay", "HoSoDongBaoHiemReadGroup");
			//AuthorizationRules.AllowRead("TuNgayString", "HoSoDongBaoHiemReadGroup");
			//AuthorizationRules.AllowRead("DenNgay", "HoSoDongBaoHiemReadGroup");
			//AuthorizationRules.AllowRead("DenNgayString", "HoSoDongBaoHiemReadGroup");
			//AuthorizationRules.AllowRead("HeSoBHXH", "HoSoDongBaoHiemReadGroup");
			//AuthorizationRules.AllowRead("HeSoBHYT", "HoSoDongBaoHiemReadGroup");
			//AuthorizationRules.AllowRead("HeSoCongDoan", "HoSoDongBaoHiemReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "HoSoDongBaoHiemReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "HoSoDongBaoHiemWriteGroup");
			//AuthorizationRules.AllowWrite("TuNgayString", "HoSoDongBaoHiemWriteGroup");
			//AuthorizationRules.AllowWrite("DenNgayString", "HoSoDongBaoHiemWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoBHXH", "HoSoDongBaoHiemWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoBHYT", "HoSoDongBaoHiemWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoCongDoan", "HoSoDongBaoHiemWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "HoSoDongBaoHiemWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HoSoDongBaoHiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoDongBaoHiemViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HoSoDongBaoHiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoDongBaoHiemAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HoSoDongBaoHiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoDongBaoHiemEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HoSoDongBaoHiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoDongBaoHiemDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HoSoDongBaoHiem()
		{ /* require use of factory method */ }

		public static HoSoDongBaoHiem NewHoSoDongBaoHiem()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HoSoDongBaoHiem");
			return DataPortal.Create<HoSoDongBaoHiem>();
		}

        public static HoSoDongBaoHiem NewHoSoDongBaoHiem(long maNhanVien, float BHXH, float BHYT, float KPCD)
        {
            HoSoDongBaoHiem _HoSoDongBaoHiem = new HoSoDongBaoHiem();
            _HoSoDongBaoHiem.MaNhanVien = maNhanVien;
            _HoSoDongBaoHiem.HeSoBHXH = BHXH;
            _HoSoDongBaoHiem.HeSoBHYT = BHYT;
            _HoSoDongBaoHiem.HeSoCongDoan = KPCD;
            return _HoSoDongBaoHiem;
        }

		public static HoSoDongBaoHiem GetHoSoDongBaoHiem(int maDongBaoHiem)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HoSoDongBaoHiem");
			return DataPortal.Fetch<HoSoDongBaoHiem>(new Criteria(maDongBaoHiem));
		}

		public static void DeleteHoSoDongBaoHiem(int maDongBaoHiem)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HoSoDongBaoHiem");
			DataPortal.Delete(new Criteria(maDongBaoHiem));
		}

		public override HoSoDongBaoHiem Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HoSoDongBaoHiem");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HoSoDongBaoHiem");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HoSoDongBaoHiem");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HoSoDongBaoHiem NewHoSoDongBaoHiemChild()
		{
			HoSoDongBaoHiem child = new HoSoDongBaoHiem();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HoSoDongBaoHiem GetHoSoDongBaoHiem(SafeDataReader dr)
		{
			HoSoDongBaoHiem child =  new HoSoDongBaoHiem();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}

        public static int KiemTra_NgayHoaSoBaoHiem(long MaNhanVien, DateTime TuNgay, DateTime DenNgay)
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
                        cm.CommandText = "spd_KiemTraNgay_HoSoBaoHiem";
                        cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                        cm.Parameters.AddWithValue("@TuNgay", TuNgay.ToShortDateString());
                        cm.Parameters.AddWithValue("@DenNgay", DenNgay.ToShortDateString());
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
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaDongBaoHiem;

			public Criteria(int maDongBaoHiem)
			{
				this.MaDongBaoHiem = maDongBaoHiem;
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
                cm.CommandText = "spd_SelecttblnsHoSoDongBaoHiem";

				cm.Parameters.AddWithValue("@MaDongBaoHiem", criteria.MaDongBaoHiem);

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

				ExecuteInsert(cn);

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
					ExecuteUpdate(cn);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maDongBaoHiem));
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
                cm.CommandText = "spd_DeletetblnsHoSoDongBaoHiem";

				cm.Parameters.AddWithValue("@MaDongBaoHiem", criteria.MaDongBaoHiem);

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
			_maDongBaoHiem = dr.GetInt32("MaDongBaoHiem");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tuNgay = dr.GetDateTime("TuNgay");
            _denNgay = dr.GetDateTime("DenNgay");
			_heSoBHXH = dr.GetDouble("HeSoBHXH");
			_heSoBHYT = dr.GetDouble("HeSoBHYT");
			_heSoCongDoan = dr.GetDouble("HeSoCongDoan");
			_dienGiai = dr.GetString("DienGiai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsHoSoDongBaoHiem";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maDongBaoHiem = (int)cm.Parameters["@MaDongBaoHiem"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay);
			if (_heSoBHXH != 0)
				cm.Parameters.AddWithValue("@HeSoBHXH", _heSoBHXH);
			else
				cm.Parameters.AddWithValue("@HeSoBHXH", DBNull.Value);
			if (_heSoBHYT != 0)
				cm.Parameters.AddWithValue("@HeSoBHYT", _heSoBHYT);
			else
				cm.Parameters.AddWithValue("@HeSoBHYT", DBNull.Value);
			if (_heSoCongDoan != 0)
				cm.Parameters.AddWithValue("@HeSoCongDoan", _heSoCongDoan);
			else
				cm.Parameters.AddWithValue("@HeSoCongDoan", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaDongBaoHiem", _maDongBaoHiem);
			cm.Parameters["@MaDongBaoHiem"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsHoSoDongBaoHiem";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaDongBaoHiem", _maDongBaoHiem);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay);
			if (_heSoBHXH != 0)
				cm.Parameters.AddWithValue("@HeSoBHXH", _heSoBHXH);
			else
				cm.Parameters.AddWithValue("@HeSoBHXH", DBNull.Value);
			if (_heSoBHYT != 0)
				cm.Parameters.AddWithValue("@HeSoBHYT", _heSoBHYT);
			else
				cm.Parameters.AddWithValue("@HeSoBHYT", DBNull.Value);
			if (_heSoCongDoan != 0)
				cm.Parameters.AddWithValue("@HeSoCongDoan", _heSoCongDoan);
			else
				cm.Parameters.AddWithValue("@HeSoCongDoan", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maDongBaoHiem));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
