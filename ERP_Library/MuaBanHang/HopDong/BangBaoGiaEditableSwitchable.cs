
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangBaoGia : Csla.BusinessBase<BangBaoGia>
	{
		#region Business Properties and Methods

		//declare members
		private int _maBangBaoGia = 0;
		private long _maKhachHang = 0;
        private string _tenKhachHang = string.Empty;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private string _noiDung = string.Empty;

		//declare child member(s)
		private CT_BaoGiaList _cT_BaoGiaList = CT_BaoGiaList.NewCT_BaoGiaList();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaBangBaoGia
		{
			get
			{
				CanReadProperty("MaBangBaoGia", true);
				return _maBangBaoGia;
			}
		}

		public long MaKhachHang
		{
			get
			{
				CanReadProperty("MaKhachHang", true);
				return _maKhachHang;
			}
			set
			{
				CanWriteProperty("MaKhachHang", true);
				if (!_maKhachHang.Equals(value))
				{
					_maKhachHang = value;
					PropertyHasChanged("MaKhachHang");
				}
			}
		}

        public string TenKhachHang
        {
            get
            {
                CanReadProperty("TenKhachHang", true);
                return DoiTac.GetDoiTac(_maKhachHang).TenDoiTac;
            }
        }

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty(true);
                return _ngayLap.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged();
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

		public CT_BaoGiaList CT_BaoGiaList
		{
			get
			{
				CanReadProperty("CT_BaoGia", true);
				return _cT_BaoGiaList;
			}
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _cT_BaoGiaList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _cT_BaoGiaList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maBangBaoGia;
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
			// NgayLap
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "NgayLapString");
			//
			// NoiDung
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiDung", 1000));
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
			//TODO: Define authorization rules in BangBaoGia
			//AuthorizationRules.AllowRead("CT_BaoGia", "BangBaoGiaReadGroup");
			//AuthorizationRules.AllowRead("MaBangBaoGia", "BangBaoGiaReadGroup");
			//AuthorizationRules.AllowRead("MaKhachHang", "BangBaoGiaReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "BangBaoGiaReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "BangBaoGiaReadGroup");
			//AuthorizationRules.AllowRead("NoiDung", "BangBaoGiaReadGroup");

			//AuthorizationRules.AllowWrite("MaKhachHang", "BangBaoGiaWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "BangBaoGiaWriteGroup");
			//AuthorizationRules.AllowWrite("NoiDung", "BangBaoGiaWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangBaoGia
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangBaoGiaViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangBaoGia
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangBaoGiaAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangBaoGia
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangBaoGiaEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangBaoGia
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangBaoGiaDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangBaoGia()
		{ 
            /* require use of factory method */ 

        }

		public static BangBaoGia NewBangBaoGia()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangBaoGia");
			return DataPortal.Create<BangBaoGia>();
		}

		public static BangBaoGia GetBangBaoGia(int maBangBaoGia)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangBaoGia");
			return DataPortal.Fetch<BangBaoGia>(new Criteria(maBangBaoGia));
		}

		public static void DeleteBangBaoGia(int maBangBaoGia)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangBaoGia");
			DataPortal.Delete(new Criteria(maBangBaoGia));
		}

		public override BangBaoGia Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangBaoGia");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangBaoGia");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BangBaoGia");
            
			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static BangBaoGia NewBangBaoGiaChild()
		{
			BangBaoGia child = new BangBaoGia();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BangBaoGia GetBangBaoGia(SafeDataReader dr)
		{
			BangBaoGia child =  new BangBaoGia();
			//child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaBangBaoGia;

			public Criteria(int maBangBaoGia)
			{
				this.MaBangBaoGia = maBangBaoGia;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{   
            
            //ValidationRules.CheckRules();
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
				catch(Exception ex)
				{
					tr.Rollback();
					throw ex;
				}
			}//using
		}

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblBangBaoGia";

				cm.Parameters.AddWithValue("@MaBangBaoGia", criteria.MaBangBaoGia);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					//ValidationRules.CheckRules();

					//load child object(s)
					FetchChildren(_maBangBaoGia);
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
			DataPortal_Delete(new Criteria(_maBangBaoGia));
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
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DeletetblBangBaoGia";

                    cm.Parameters.AddWithValue("@MaBangBaoGia", criteria.MaBangBaoGia);

                    cm.ExecuteNonQuery();
                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            //ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(MaBangBaoGia);
            //FetchChildren(tr);
        }
		private void FetchObject(SafeDataReader dr)
		{
			_maBangBaoGia = dr.GetInt32("MaBangBaoGia");
			_maKhachHang = dr.GetInt64("MaKhachHang");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_noiDung = dr.GetString("NoiDung");
		}

		private void FetchChildren(int mabangbaogia)
		{
            _cT_BaoGiaList = CT_BaoGiaList.GetCT_BaoGiaList(mabangbaogia);
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
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblBangBaoGia";

                    AddInsertParameters(cm);

                    cm.ExecuteNonQuery();

                    _maBangBaoGia = (int)cm.Parameters["@MaBangBaoGia"].Value;
                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaKhachHang", _maKhachHang);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_noiDung.Length > 0)
				cm.Parameters.AddWithValue("@NoiDung", _noiDung);
			else
				cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
			cm.Parameters.AddWithValue("@MaBangBaoGia", _maBangBaoGia);
			cm.Parameters["@MaBangBaoGia"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblBangBaoGia";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaBangBaoGia", _maBangBaoGia);
			cm.Parameters.AddWithValue("@MaKhachHang", _maKhachHang);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_noiDung.Length > 0)
				cm.Parameters.AddWithValue("@NoiDung", _noiDung);
			else
				cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_cT_BaoGiaList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            _cT_BaoGiaList.Clear();
            _cT_BaoGiaList.Update(tr, this);
			ExecuteDelete(tr, new Criteria(_maBangBaoGia));
			//MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
