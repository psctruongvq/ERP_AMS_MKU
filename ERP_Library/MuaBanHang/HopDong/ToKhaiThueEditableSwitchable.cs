
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ToKhaiThue : Csla.BusinessBase<ToKhaiThue>
	{
		#region Business Properties and Methods
        


		//declare members
		private int _maToKhai = 0;
		private string _soToKhai = string.Empty;
		private SmartDate _ngayKhai = new SmartDate(false);
		private long _maHoaDon = 0;
		private decimal _soTien = 0;
		private int _maLoaiTien = 0;
		private double _tyGia = 0;
		private decimal _tongSoTienThue = 0;
		private string _vietBangChu = string.Empty;

		//declare child member(s)
		private CT_ToKhaiThueList _cT_ToKhaiThueList = CT_ToKhaiThueList.NewCT_ToKhaiThueList();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaToKhai
		{
			get
			{
				CanReadProperty("MaToKhai", true);
				return _maToKhai;
			}
		}

		public string SoToKhai
		{
			get
			{
				CanReadProperty("SoToKhai", true);
				return _soToKhai;
			}
			set
			{
				CanWriteProperty("SoToKhai", true);
				if (value == null) value = string.Empty;
				if (!_soToKhai.Equals(value))
				{
					_soToKhai = value;
					PropertyHasChanged("SoToKhai");
				}
			}
		}

		public DateTime NgayKhai
		{
			get
			{
				CanReadProperty("NgayKhai", true);
				return _ngayKhai.Date;
			}
		}

		public string NgayKhaiString
		{
			get
			{
				CanReadProperty("NgayKhaiString", true);
				return _ngayKhai.Text;
			}
			set
			{
				CanWriteProperty("NgayKhaiString", true);
				if (value == null) value = string.Empty;
				if (!_ngayKhai.Equals(value))
				{
					_ngayKhai.Text = value;
					PropertyHasChanged("NgayKhaiString");
				}
			}
		}

		public long MaHoaDon
		{
			get
			{
                CanReadProperty("MaHoaDon", true);
				return _maHoaDon;
			}
			set
			{
                CanWriteProperty("MaHoaDon", true);
                if (!_maHoaDon.Equals(value))
				{
                    _maHoaDon = value;
                    PropertyHasChanged("MaHoaDon");
				}
			}
		}

		public decimal SoTien
		{
			get
			{
				CanReadProperty("SoTien", true);
				return _soTien;
			}
			set
			{
				CanWriteProperty("SoTien", true);
				if (!_soTien.Equals(value))
				{
					_soTien = value;
                    TongSoTienThue = _soTien * (decimal)_tyGia;
					PropertyHasChanged("SoTien");
				}
			}
		}

		public int MaLoaiTien
		{
			get
			{
				CanReadProperty("MaLoaiTien", true);
				return _maLoaiTien;
			}
			set
			{
				CanWriteProperty("MaLoaiTien", true);
				if (!_maLoaiTien.Equals(value))
				{
					_maLoaiTien = value;
					PropertyHasChanged("MaLoaiTien");
				}
			}
		}

		public double TyGia
		{
			get
			{
				CanReadProperty("TyGia", true);
				return _tyGia;
			}
			set
			{
				CanWriteProperty("TyGia", true);
				if (!_tyGia.Equals(value))
				{
					_tyGia = value;
                    TongSoTienThue = _soTien * (decimal)_tyGia;
					PropertyHasChanged("TyGia");
				}
			}
		}

		public decimal TongSoTienThue
		{
			get
			{
				CanReadProperty("TongSoTienThue", true);
				return _tongSoTienThue;
			}
			set
			{
				CanWriteProperty("TongSoTienThue", true);
				if (!_tongSoTienThue.Equals(value))
				{
					_tongSoTienThue = value;
                    _vietBangChu = HamDungChung.DocTien(_tongSoTienThue);
					PropertyHasChanged("TongSoTienThue");
				}
			}
		}

		public string VietBangChu
		{
			get
			{
				CanReadProperty("VietBangChu", true);
				return _vietBangChu;
			}
			set
			{
				CanWriteProperty("VietBangChu", true);
				if (value == null) value = string.Empty;
				if (!_vietBangChu.Equals(value))
				{
					_vietBangChu = value;
					PropertyHasChanged("VietBangChu");
				}
			}
		}

		public CT_ToKhaiThueList CT_ToKhaiThueList
		{
			get
			{
				CanReadProperty("CT_ToKhaiThueList", true);
				return _cT_ToKhaiThueList;
			}
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _cT_ToKhaiThueList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _cT_ToKhaiThueList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maToKhai;
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
			// SoToKhai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoToKhai", 20));
			//
			// VietBangChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("VietBangChu", 500));
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
			//TODO: Define authorization rules in ToKhaiThue
			//AuthorizationRules.AllowRead("CT_ToKhaiThueList", "ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("MaToKhai", "ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("SoToKhai", "ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("NgayKhai", "ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("NgayKhaiString", "ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("MaHopDong", "ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiTien", "ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("TyGia", "ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("TongSoTienThue", "ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("VietBangChu", "ToKhaiThueReadGroup");

			//AuthorizationRules.AllowWrite("SoToKhai", "ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKhaiString", "ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("MaHopDong", "ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiTien", "ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("TyGia", "ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("TongSoTienThue", "ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("VietBangChu", "ToKhaiThueWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ToKhaiThue
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ToKhaiThue
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ToKhaiThue
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ToKhaiThue
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ToKhaiThue()
		{ /* require use of factory method */ }

        private ToKhaiThue(CT_HoaDonList ct_HoaDonList)
        {
            foreach (CT_HoaDon ct_HoaDon in ct_HoaDonList)
            {
                _cT_ToKhaiThueList.Add(CT_ToKhaiThue.NewCT_ToKhaiThue(ct_HoaDon));
            }
        }

		public static ToKhaiThue NewToKhaiThue()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ToKhaiThue");
			return DataPortal.Create<ToKhaiThue>();
		}

        public static ToKhaiThue NewToKhaiThue(CT_HoaDonList ct_HoaDonList)
        {
            return new ToKhaiThue(ct_HoaDonList);
        }

		public static ToKhaiThue GetToKhaiThue(int maToKhai)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ToKhaiThue");
			return DataPortal.Fetch<ToKhaiThue>(new Criteria(maToKhai));
		}

        public static ToKhaiThue GetToKhaiThueByHoaDon(long  maHoaDon)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ToKhaiThue");
            return DataPortal.Fetch<ToKhaiThue>(new CriteriaByMaHoaDon(maHoaDon));
        }

		public static void DeleteToKhaiThue(int maToKhai)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ToKhaiThue");
			DataPortal.Delete(new Criteria(maToKhai));
		}

		public override ToKhaiThue Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ToKhaiThue");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ToKhaiThue");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ToKhaiThue");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ToKhaiThue NewToKhaiThueChild()
		{
			ToKhaiThue child = new ToKhaiThue();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ToKhaiThue GetToKhaiThue(SafeDataReader dr)
		{
			ToKhaiThue child =  new ToKhaiThue();
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
			public int MaToKhai;

			public Criteria(int maToKhai)
			{
				this.MaToKhai = maToKhai;
			}
		}
        
        [Serializable()]
        private class CriteriaByMaHoaDon
        {
            public long  MaHoaDon;

            public CriteriaByMaHoaDon(long maHoaDon)
            {
                this.MaHoaDon = maHoaDon;
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
		private void DataPortal_Fetch(Object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
            
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
                if (criteria is Criteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblToKhaiThue";

                    cm.Parameters.AddWithValue("@MaToKhai", ((Criteria)criteria).MaToKhai);
                }
                else if (criteria is CriteriaByMaHoaDon)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblToKhaiThuesByMaHopDong";

                    cm.Parameters.AddWithValue("@MaHoaDon", ((CriteriaByMaHoaDon)criteria).MaHoaDon);
                
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
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
				catch(SqlException ex)
				{
					tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
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
				catch(SqlException ex)
				{
					tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
				}
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maToKhai));
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
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using

		}

		private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblToKhaiThue";

				cm.Parameters.AddWithValue("@MaToKhai", criteria.MaToKhai);

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
			_maToKhai = dr.GetInt32("MaToKhai");
			_soToKhai = dr.GetString("SoToKhai");
			_ngayKhai = dr.GetSmartDate("NgayKhai", _ngayKhai.EmptyIsMin);
			_maHoaDon = dr.GetInt64("MaHoaDon");
			_soTien = dr.GetDecimal("SoTien");
			_maLoaiTien = dr.GetInt32("MaLoaiTien");
			_tyGia = dr.GetDouble("TyGia");
			_tongSoTienThue = dr.GetDecimal("TongSoTienThue");
			_vietBangChu = dr.GetString("VietBangChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{			
			_cT_ToKhaiThueList = CT_ToKhaiThueList.GetCT_ToKhaiThueList(this._maToKhai);
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
                cm.CommandText = "spd_InserttblToKhaiThue";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maToKhai = (int)cm.Parameters["@MaToKhai"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_soToKhai.Length > 0)
				cm.Parameters.AddWithValue("@SoToKhai", _soToKhai);
			else
				cm.Parameters.AddWithValue("@SoToKhai", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayKhai", _ngayKhai.DBValue);
			if (_maHoaDon != 0)
				cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
			else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_maLoaiTien != 0)
				cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
			else
				cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
			if (_tyGia != 0)
				cm.Parameters.AddWithValue("@TyGia", _tyGia);
			else
				cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
			if (_tongSoTienThue != 0)
				cm.Parameters.AddWithValue("@TongSoTienThue", _tongSoTienThue);
			else
				cm.Parameters.AddWithValue("@TongSoTienThue", DBNull.Value);
			if (_vietBangChu.Length > 0)
				cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
			else
				cm.Parameters.AddWithValue("@VietBangChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaToKhai", _maToKhai);
			cm.Parameters["@MaToKhai"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblToKhaiThue";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaToKhai", _maToKhai);
			if (_soToKhai.Length > 0)
				cm.Parameters.AddWithValue("@SoToKhai", _soToKhai);
			else
				cm.Parameters.AddWithValue("@SoToKhai", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayKhai", _ngayKhai.DBValue);
			if (_maHoaDon != 0)
				cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
			else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_maLoaiTien != 0)
				cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
			else
				cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
			if (_tyGia != 0)
				cm.Parameters.AddWithValue("@TyGia", _tyGia);
			else
				cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
			if (_tongSoTienThue != 0)
				cm.Parameters.AddWithValue("@TongSoTienThue", _tongSoTienThue);
			else
				cm.Parameters.AddWithValue("@TongSoTienThue", DBNull.Value);
			if (_vietBangChu.Length > 0)
				cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
			else
				cm.Parameters.AddWithValue("@VietBangChu", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_cT_ToKhaiThueList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(tr, new Criteria(_maToKhai));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
