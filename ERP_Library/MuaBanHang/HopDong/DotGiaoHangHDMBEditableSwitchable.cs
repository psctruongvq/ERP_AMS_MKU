
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DotGiaoHangHDMB : Csla.BusinessBase<DotGiaoHangHDMB>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChiTiet = 0;
		private long _maHopDongMuaBan = 0;
		private int _maPhuongThucGiaoNhan = 0;
		private SmartDate _ngayGiao = new SmartDate(DateTime.Today);
		private int _maDiaChi = 0;
		private int _maDiaChiHD = 0;
		private string _noiDung = string.Empty;
        private bool _daGiaoHang = false;
        private decimal _chiPhiVanChuyen = 0;

		//declare child member(s)
		private CT_DotGiaoHangHDMBList _cT_DotGiaoHangHDMBList = CT_DotGiaoHangHDMBList.NewCT_DotGiaoHangHDMBList();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public long MaHopDongMuaBan
		{
			get
			{
				CanReadProperty("MaHopDongMuaBan", true);
				return _maHopDongMuaBan;
			}
			set
			{
				CanWriteProperty("MaHopDongMuaBan", true);
				if (!_maHopDongMuaBan.Equals(value))
				{
					_maHopDongMuaBan = value;
					PropertyHasChanged("MaHopDongMuaBan");
				}
			}
		}

		public int MaPhuongThucGiaoNhan
		{
			get
			{
				CanReadProperty("MaPhuongThucGiaoNhan", true);
				return _maPhuongThucGiaoNhan;
			}
			set
			{
				CanWriteProperty("MaPhuongThucGiaoNhan", true);
				if (!_maPhuongThucGiaoNhan.Equals(value))
				{
					_maPhuongThucGiaoNhan = value;
					PropertyHasChanged("MaPhuongThucGiaoNhan");
				}
			}
		}

		public DateTime NgayGiao
		{
			get
			{
				CanReadProperty("NgayGiao", true);
				return _ngayGiao.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayGiao.Equals(value))
                {
                    _ngayGiao = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
		}

		public int MaDiaChi
		{
			get
			{
				CanReadProperty("MaDiaChi", true);
				return _maDiaChi;
			}
			set
			{
				CanWriteProperty("MaDiaChi", true);
				if (!_maDiaChi.Equals(value))
				{
					_maDiaChi = value;
					PropertyHasChanged("MaDiaChi");
				}
			}
		}

		public int MaDiaChiHD
		{
			get
			{
				CanReadProperty("MaDiaChiHD", true);
				return _maDiaChiHD;
			}
			set
			{
				CanWriteProperty("MaDiaChiHD", true);
				if (!_maDiaChiHD.Equals(value))
				{
					_maDiaChiHD = value;
					PropertyHasChanged("MaDiaChiHD");
				}
			}
		}


        public bool DaGiaoHang
        {
            get
            {
                CanReadProperty("DaGiaoHang", true);
                return _daGiaoHang;
            }
            set
            {
                CanWriteProperty("DaGiaoHang", true);
                if (!_daGiaoHang.Equals(value))
                {
                    _daGiaoHang = value;
                    PropertyHasChanged("DaGiaoHang");
                }
            }
        }


		public string NoiDung
		{
			get
			{
				CanReadProperty("NoiDung", true);
				return _noiDung;
			}
			set
			{
				CanWriteProperty("NoiDung", true);
				if (value == null) value = string.Empty;
				if (!_noiDung.Equals(value))
				{
					_noiDung = value;
					PropertyHasChanged("NoiDung");
				}
			}
		}

        public decimal ChiPhiVanChuyen
        {
            get
            {
                CanReadProperty("ChiPhiVanChuyen", true);
                return _chiPhiVanChuyen;
            }
            set
            {
                CanWriteProperty("ChiPhiVanChuyen", true);                
                if (!_chiPhiVanChuyen.Equals(value))
                {
                    _chiPhiVanChuyen = value;
                    PropertyHasChanged("ChiPhiVanChuyen");
                }
            }
        }


		public CT_DotGiaoHangHDMBList CT_DotGiaoHangHDMBList
		{
			get
			{
				CanReadProperty("CT_DotGiaoHangHDMBList", true);
				return _cT_DotGiaoHangHDMBList;
			}
            set
            { 
                CanWriteProperty("CT_DotGiaoHangHDMBList", true);
				if (value == null) _cT_DotGiaoHangHDMBList =CT_DotGiaoHangHDMBList.NewCT_DotGiaoHangHDMBList();
				if (!_cT_DotGiaoHangHDMBList.Equals(value))
				{
					_cT_DotGiaoHangHDMBList = value;
					PropertyHasChanged("NoiDung");
				}			
            }
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _cT_DotGiaoHangHDMBList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _cT_DotGiaoHangHDMBList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maChiTiet;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiDung", 500));
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
			//TODO: Define authorization rules in DotGiaoHangHDMB
			//AuthorizationRules.AllowRead("CT_DotGiaoHangHDMBList", "DotGiaoHangHDMBReadGroup");
			//AuthorizationRules.AllowRead("MaChiTiet", "DotGiaoHangHDMBReadGroup");
			//AuthorizationRules.AllowRead("MaHopDongMuaBan", "DotGiaoHangHDMBReadGroup");
			//AuthorizationRules.AllowRead("MaPhuongThucGiaoNhan", "DotGiaoHangHDMBReadGroup");
			//AuthorizationRules.AllowRead("NgayGiao", "DotGiaoHangHDMBReadGroup");
			//AuthorizationRules.AllowRead("NgayGiaoString", "DotGiaoHangHDMBReadGroup");
			//AuthorizationRules.AllowRead("MaDiaChi", "DotGiaoHangHDMBReadGroup");
			//AuthorizationRules.AllowRead("MaDiaChiHD", "DotGiaoHangHDMBReadGroup");
			//AuthorizationRules.AllowRead("NoiDung", "DotGiaoHangHDMBReadGroup");

			//AuthorizationRules.AllowWrite("MaHopDongMuaBan", "DotGiaoHangHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhuongThucGiaoNhan", "DotGiaoHangHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("NgayGiaoString", "DotGiaoHangHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("MaDiaChi", "DotGiaoHangHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("MaDiaChiHD", "DotGiaoHangHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("NoiDung", "DotGiaoHangHDMBWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DotGiaoHangHDMB
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DotGiaoHangHDMBViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DotGiaoHangHDMB
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DotGiaoHangHDMBAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DotGiaoHangHDMB
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DotGiaoHangHDMBEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DotGiaoHangHDMB
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DotGiaoHangHDMBDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		public DotGiaoHangHDMB()
		{ /* require use of factory method */
            MarkAsChild();
        }

		public static DotGiaoHangHDMB NewDotGiaoHangHDMB()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DotGiaoHangHDMB");
			return DataPortal.Create<DotGiaoHangHDMB>();
		}

		public static DotGiaoHangHDMB GetDotGiaoHangHDMB(int maChiTiet)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DotGiaoHangHDMB");
			return DataPortal.Fetch<DotGiaoHangHDMB>(new Criteria(maChiTiet));
		}

		public static void DeleteDotGiaoHangHDMB(int maChiTiet)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DotGiaoHangHDMB");
			DataPortal.Delete(new Criteria(maChiTiet));
		}

		public override DotGiaoHangHDMB Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DotGiaoHangHDMB");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DotGiaoHangHDMB");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DotGiaoHangHDMB");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static DotGiaoHangHDMB NewDotGiaoHangHDMBChild()
		{
			DotGiaoHangHDMB child = new DotGiaoHangHDMB();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DotGiaoHangHDMB GetDotGiaoHangHDMB(SafeDataReader dr)
		{
			DotGiaoHangHDMB child =  new DotGiaoHangHDMB();
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
			public int MaChiTiet;

			public Criteria(int maChiTiet)
			{
				this.MaChiTiet = maChiTiet;
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
                cm.CommandText = "spd_SelecttblDotGiaoHangHDMB";

				cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					ValidationRules.CheckRules();

					//load child object(s)
					FetchChildren(_maChiTiet);
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
			DataPortal_Delete(new Criteria(_maChiTiet));
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
                    _cT_DotGiaoHangHDMBList.Clear();
                    UpdateChildren(tr);
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
                cm.CommandText = "spd_DeletetblDotGiaoHangHDMB";

				cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
			FetchChildren(_maChiTiet);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maChiTiet = dr.GetInt32("MaChiTiet");
			_maHopDongMuaBan = dr.GetInt64("MaHopDongMuaBan");
			_maPhuongThucGiaoNhan = dr.GetInt32("MaPhuongThucGiaoNhan");
			_ngayGiao = dr.GetSmartDate("NgayGiao", _ngayGiao.EmptyIsMin);
			_maDiaChi = dr.GetInt32("MaDiaChi");
			_maDiaChiHD = dr.GetInt32("MaDiaChiHD");
			_noiDung = dr.GetString("NoiDung");
            _daGiaoHang= dr.GetBoolean("DaGiaoHang");
            _chiPhiVanChuyen = dr.GetDecimal("ChiPhiVanChuyen");
		}

		private void FetchChildren(int MaChiTiet)
		{
			//dr.NextResult();
            _cT_DotGiaoHangHDMBList = CT_DotGiaoHangHDMBList.GetCT_DotGiaoHangHDMBList(MaChiTiet);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, HopDongMuaBan parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, HopDongMuaBan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblDotGiaoHangHDMB";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, HopDongMuaBan parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maHopDongMuaBan = parent.MaHopDong;
			if (_maHopDongMuaBan != 0)
				cm.Parameters.AddWithValue("@MaHopDongMuaBan", _maHopDongMuaBan);
			else
				cm.Parameters.AddWithValue("@MaHopDongMuaBan", DBNull.Value);
			if (_maPhuongThucGiaoNhan != 0)
				cm.Parameters.AddWithValue("@MaPhuongThucGiaoNhan", _maPhuongThucGiaoNhan);
			else
				cm.Parameters.AddWithValue("@MaPhuongThucGiaoNhan", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayGiao", _ngayGiao.DBValue);
			if (_maDiaChi != 0)
				cm.Parameters.AddWithValue("@MaDiaChi", _maDiaChi);
			else
				cm.Parameters.AddWithValue("@MaDiaChi", DBNull.Value);
			if (_maDiaChiHD != 0)
				cm.Parameters.AddWithValue("@MaDiaChiHD", _maDiaChiHD);
			else
				cm.Parameters.AddWithValue("@MaDiaChiHD", DBNull.Value);
			if (_noiDung.Length > 0)
				cm.Parameters.AddWithValue("@NoiDung", _noiDung);
			else
				cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            cm.Parameters.AddWithValue("@DaGiaoHang", _daGiaoHang);
            cm.Parameters.AddWithValue("@ChiPhiVanChuyen", _chiPhiVanChuyen);

			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, HopDongMuaBan parent)
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

		private void ExecuteUpdate(SqlTransaction tr, HopDongMuaBan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDotGiaoHangHDMB";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, HopDongMuaBan parent)
		{
            _maHopDongMuaBan = parent.MaHopDong; 
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			if (_maHopDongMuaBan != 0)
				cm.Parameters.AddWithValue("@MaHopDongMuaBan", _maHopDongMuaBan);
			else
				cm.Parameters.AddWithValue("@MaHopDongMuaBan", DBNull.Value);
			if (_maPhuongThucGiaoNhan != 0)
				cm.Parameters.AddWithValue("@MaPhuongThucGiaoNhan", _maPhuongThucGiaoNhan);
			else
				cm.Parameters.AddWithValue("@MaPhuongThucGiaoNhan", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayGiao", _ngayGiao.DBValue);
			if (_maDiaChi != 0)
				cm.Parameters.AddWithValue("@MaDiaChi", _maDiaChi);
			else
				cm.Parameters.AddWithValue("@MaDiaChi", DBNull.Value);
			if (_maDiaChiHD != 0)
				cm.Parameters.AddWithValue("@MaDiaChiHD", _maDiaChiHD);
			else
				cm.Parameters.AddWithValue("@MaDiaChiHD", DBNull.Value);
			if (_noiDung.Length > 0)
				cm.Parameters.AddWithValue("@NoiDung", _noiDung);
			else
				cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            cm.Parameters.AddWithValue("@DaGiaoHang", _daGiaoHang);
            cm.Parameters.AddWithValue("@ChiPhiVanChuyen", _chiPhiVanChuyen);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_cT_DotGiaoHangHDMBList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            _cT_DotGiaoHangHDMBList.Clear();
            UpdateChildren(tr);
			ExecuteDelete(tr, new Criteria(_maChiTiet));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
