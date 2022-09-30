
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BacLuongNoiBo : Csla.BusinessBase<BacLuongNoiBo>
	{
		#region Business Properties and Methods

		//declare members
		private int _maBacLuongNoiBo = 0;
		private string _maQuanLy = string.Empty;
		private decimal _heSoLuong = 0;
		private int _maNgachLuongNoiBo = 0;
		private int _thoiGianNangBac = 0;
		private int _soThuTu = 0;
		private string _dienGiai = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaBacLuongNoiBo
		{
			get
			{
				CanReadProperty("MaBacLuongNoiBo", true);
				return _maBacLuongNoiBo;
			}
		}

		public string MaQuanLy
		{
			get
			{
				CanReadProperty("MaQuanLy", true);
				return _maQuanLy;
			}
			set
			{
				CanWriteProperty("MaQuanLy", true);
				if (value == null) value = string.Empty;
				if (!_maQuanLy.Equals(value))
				{
					_maQuanLy = value;
					PropertyHasChanged("MaQuanLy");
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
				CanWriteProperty("HeSoLuong", true);
				if (!_heSoLuong.Equals(value))
				{
					_heSoLuong = value;
					PropertyHasChanged("HeSoLuong");
				}
			}
		}

		public int MaNgachLuongNoiBo
		{
			get
			{
                CanReadProperty("MaNgachLuongNoiBo", true);
				return _maNgachLuongNoiBo;
			}
			set
			{
                CanWriteProperty("MaNgachLuongNoiBo", true);
				if (!_maNgachLuongNoiBo.Equals(value))
				{
					_maNgachLuongNoiBo = value;
                    PropertyHasChanged("MaNgachLuongNoiBo");
				}
			}
		}

		public int ThoiGianNangBac
		{
			get
			{
				CanReadProperty("ThoiGianNangBac", true);
				return _thoiGianNangBac;
			}
			set
			{
                CanWriteProperty("ThoiGianNangBac", true);
                if (!_thoiGianNangBac.Equals(value))
                {
                    _thoiGianNangBac = value;
                    PropertyHasChanged("ThoiGianNangBac");
                }
			}
		}

		public int SoThuTu
		{
			get
			{
				CanReadProperty("SoThuTu", true);
				return _soThuTu;
			}
			set
			{
				CanWriteProperty("SoThuTu", true);
				if (!_soThuTu.Equals(value))
				{
					_soThuTu = value;
					PropertyHasChanged("SoThuTu");
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
			return _maBacLuongNoiBo;
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
            //// MaQuanLy
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
            ////
            //// ThoiGianNangBac
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ThoiGianNangBac", 50));
            ////
            //// DienGiai
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 4000));
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
			//TODO: Define authorization rules in BacLuongNoiBo
			//AuthorizationRules.AllowRead("MaBacLuongNoiBo", "BacLuongNoiBoReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "BacLuongNoiBoReadGroup");
			//AuthorizationRules.AllowRead("HeSoLuong", "BacLuongNoiBoReadGroup");
			//AuthorizationRules.AllowRead("MaNgachLuongCB", "BacLuongNoiBoReadGroup");
			//AuthorizationRules.AllowRead("ThoiGianNangBac", "BacLuongNoiBoReadGroup");
			//AuthorizationRules.AllowRead("SoThuTu", "BacLuongNoiBoReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "BacLuongNoiBoReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "BacLuongNoiBoWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoLuong", "BacLuongNoiBoWriteGroup");
			//AuthorizationRules.AllowWrite("MaNgachLuongCB", "BacLuongNoiBoWriteGroup");
			//AuthorizationRules.AllowWrite("ThoiGianNangBac", "BacLuongNoiBoWriteGroup");
			//AuthorizationRules.AllowWrite("SoThuTu", "BacLuongNoiBoWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "BacLuongNoiBoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BacLuongNoiBo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongNoiBoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BacLuongNoiBo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongNoiBoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BacLuongNoiBo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongNoiBoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BacLuongNoiBo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongNoiBoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BacLuongNoiBo()
		{ /* require use of factory method */ }

		public static BacLuongNoiBo NewBacLuongNoiBo()
		{
            BacLuongNoiBo child = new BacLuongNoiBo();
           // child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
		}

		public static BacLuongNoiBo GetBacLuongNoiBo(int maBacLuongNoiBo)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BacLuongNoiBo");
			return DataPortal.Fetch<BacLuongNoiBo>(new Criteria(maBacLuongNoiBo));
		}
        public static BacLuongNoiBo BacLuongNoiBoByHeSoLuong(decimal heSo,int maNgachLuongNoiBo)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BacLuongNoiBo");
            return DataPortal.Fetch<BacLuongNoiBo>(new CriteriaByHeSo(heSo, maNgachLuongNoiBo));
        }
		public static void DeleteBacLuongNoiBo(int maBacLuongNoiBo)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BacLuongNoiBo");
			DataPortal.Delete(new Criteria(maBacLuongNoiBo));
		}

		public override BacLuongNoiBo Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BacLuongNoiBo");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BacLuongNoiBo");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BacLuongNoiBo");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static BacLuongNoiBo NewBacLuongNoiBoChild()
		{
			BacLuongNoiBo child = new BacLuongNoiBo();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BacLuongNoiBo GetBacLuongNoiBo(SafeDataReader dr)
		{
			BacLuongNoiBo child =  new BacLuongNoiBo();
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
			public int MaBacLuongNoiBo;

			public Criteria(int maBacLuongNoiBo)
			{
				this.MaBacLuongNoiBo = maBacLuongNoiBo;
			}
		}

        [Serializable()]
        private class CriteriaByHeSo
        {
            public decimal heSo;
            public int maNgachLuongNoiBo;
            public CriteriaByHeSo(decimal heso,int maNgachLuongNB)
            {
                this.heSo = heso;
                this.maNgachLuongNoiBo = maNgachLuongNB;
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
		private void DataPortal_Fetch(object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblnsBacLuongNoiBo";
                    
                        cm.Parameters.AddWithValue("@MaBacLuongNoiBo", ((Criteria)criteria).MaBacLuongNoiBo);
                   

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            //ValidationRules.CheckRules();

                            //load child object(s)
                            FetchChildren(dr);
                        }
                    }
                }
                else if (criteria is CriteriaByHeSo)
                {
                    cm.CommandText = "spd_SelecttblnsBacLuongNoiBoByHeSoLuong";
                    cm.Parameters.AddWithValue("@HeSoLuong", ((CriteriaByHeSo)criteria).heSo);
                    cm.Parameters.AddWithValue("@MaNgachLuongNoiBo", ((CriteriaByHeSo)criteria).maNgachLuongNoiBo);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            
                        }
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
			DataPortal_Delete(new Criteria(_maBacLuongNoiBo));
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
                cm.CommandText = "spd_DeletetblnsBacLuongNoiBo";

				cm.Parameters.AddWithValue("@MaBacLuongNoiBo", criteria.MaBacLuongNoiBo);

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
			_maBacLuongNoiBo = dr.GetInt32("MaBacLuongNoiBo");
			_maQuanLy = dr.GetString("MaQuanLy");
			_heSoLuong = dr.GetDecimal("HeSoLuong");
			_maNgachLuongNoiBo = dr.GetInt32("MaNgachLuongNoiBo");
			_thoiGianNangBac = dr.GetInt32("ThoiGianNangBac");
			_soThuTu = dr.GetInt32("SoThuTu");
			_dienGiai = dr.GetString("DienGiai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, BacLuongNoiBoList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, BacLuongNoiBoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsBacLuongNoiBo";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maBacLuongNoiBo = (int)cm.Parameters["@MaBacLuongNoiBo"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BacLuongNoiBoList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
			if (_maNgachLuongNoiBo != 0)
				cm.Parameters.AddWithValue("@MaNgachLuongNoiBo", _maNgachLuongNoiBo);
			else
				cm.Parameters.AddWithValue("@MaNgachLuongNoiBo", DBNull.Value);
			if (_thoiGianNangBac!= 0)
				cm.Parameters.AddWithValue("@ThoiGianNangBac", _thoiGianNangBac);
			else
				cm.Parameters.AddWithValue("@ThoiGianNangBac", DBNull.Value);
			if (_soThuTu != 0)
				cm.Parameters.AddWithValue("@SoThuTu", _soThuTu);
			else
				cm.Parameters.AddWithValue("@SoThuTu", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaBacLuongNoiBo", _maBacLuongNoiBo);
			cm.Parameters["@MaBacLuongNoiBo"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, BacLuongNoiBoList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, BacLuongNoiBoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsBacLuongNoiBo";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BacLuongNoiBoList parent)
		{
			cm.Parameters.AddWithValue("@MaBacLuongNoiBo", _maBacLuongNoiBo);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
			if (_maNgachLuongNoiBo != 0)
				cm.Parameters.AddWithValue("@MaNgachLuongNoiBo", _maNgachLuongNoiBo);
			else
				cm.Parameters.AddWithValue("@MaNgachLuongNoiBo", DBNull.Value);
			if (_thoiGianNangBac!= 0)
				cm.Parameters.AddWithValue("@ThoiGianNangBac", _thoiGianNangBac);
			else
				cm.Parameters.AddWithValue("@ThoiGianNangBac", DBNull.Value);
			if (_soThuTu != 0)
				cm.Parameters.AddWithValue("@SoThuTu", _soThuTu);
			else
				cm.Parameters.AddWithValue("@SoThuTu", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maBacLuongNoiBo));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
