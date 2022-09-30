
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class MucTMBCTaiChinh : Csla.BusinessBase<MucTMBCTaiChinh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maMucCapMot = 0;
		private string _tenMucCapMot = string.Empty;
		private byte _vitri = 0;
		private string _dienGiai = string.Empty;
        private int _soTT= 0;

        private byte _isNHNN = 0;
        private int _maThongTu = 0;
        private int _maMucCapMotDoiUng =0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaMucCapMot
		{
			get
			{
				CanReadProperty("MaMucCapMot", true);
				return _maMucCapMot;
			}
		}

		public string TenMucCapMot
		{
			get
			{
				CanReadProperty("TenMucCapMot", true);
				return _tenMucCapMot;
			}
			set
			{
				CanWriteProperty("TenMucCapMot", true);
				if (value == null) value = string.Empty;
				if (!_tenMucCapMot.Equals(value))
				{
					_tenMucCapMot = value;
					PropertyHasChanged("TenMucCapMot");
				}
			}
		}

		public byte Vitri
		{
			get
			{
				CanReadProperty("Vitri", true);
				return _vitri;
			}
			set
			{
				CanWriteProperty("Vitri", true);
				if (!_vitri.Equals(value))
				{
					_vitri = value;
					PropertyHasChanged("Vitri");
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

        public int SoTT
        {
            get
            {
                CanReadProperty("SoTT", true);
                return _soTT;
            }
            set
            {
                CanWriteProperty("SoTT", true);
                if (!_soTT.Equals(value))
                {
                    _soTT = value;
                    PropertyHasChanged("SoTT");
                }
            }
        }

        public byte isNHNN
        {
            get
            {
                CanReadProperty("isNHNN", true);
                return _isNHNN;
            }
            set
            {
                CanWriteProperty("isNHNN", true);
                if (!_isNHNN.Equals(value))
                {
                    _isNHNN = value;
                    PropertyHasChanged("isNHNN");
                }
            }
        }

        public int MaThongTu
        {
            get
            {
                CanReadProperty("MaThongTu", true);
                return _maThongTu;
            }
            set
            {
                CanWriteProperty("MaThongTu", true);
                if (!_maThongTu.Equals(value))
                {
                    _maThongTu = value;
                    PropertyHasChanged("MaThongTu");
                }
            }
        }

        public int MaMucCapMotDoiUng
        {
            get
            {
                CanReadProperty("MaMucCapMotDoiUng",true);
                return _maMucCapMotDoiUng;
            }
            set
            {
                CanWriteProperty("MaMucCapMotDoiUng",true);
                if(!_maMucCapMotDoiUng.Equals(value))
                {
                    _maMucCapMotDoiUng = value;
                    PropertyHasChanged("MaMucCapMotDoiUng");
                }
            }
        }
 
		protected override object GetIdValue()
		{
			return _maMucCapMot;
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
			// TenMucCapMot
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenMucCapMot", 500));
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
			//TODO: Define authorization rules in MucTMBCTaiChinh
			//AuthorizationRules.AllowRead("MaMucCapMot", "MucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("TenMucCapMot", "MucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("Vitri", "MucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "MucTMBCTaiChinhReadGroup");

			//AuthorizationRules.AllowWrite("TenMucCapMot", "MucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("Vitri", "MucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "MucTMBCTaiChinhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in MucTMBCTaiChinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucTMBCTaiChinhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in MucTMBCTaiChinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucTMBCTaiChinhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in MucTMBCTaiChinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucTMBCTaiChinhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in MucTMBCTaiChinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucTMBCTaiChinhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private MucTMBCTaiChinh()
		{ /* require use of factory method */ }

		public static MucTMBCTaiChinh NewMucTMBCTaiChinh()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a MucTMBCTaiChinh");
			return DataPortal.Create<MucTMBCTaiChinh>();
		}

		public static MucTMBCTaiChinh GetMucTMBCTaiChinh(int maMucCapMot)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a MucTMBCTaiChinh");
			return DataPortal.Fetch<MucTMBCTaiChinh>(new Criteria(maMucCapMot));
		}

		public static void DeleteMucTMBCTaiChinh(int maMucCapMot)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a MucTMBCTaiChinh");
			DataPortal.Delete(new Criteria(maMucCapMot));
		}

		public override MucTMBCTaiChinh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a MucTMBCTaiChinh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a MucTMBCTaiChinh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a MucTMBCTaiChinh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static MucTMBCTaiChinh NewMucTMBCTaiChinhChild()
		{
			MucTMBCTaiChinh child = new MucTMBCTaiChinh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

        public static MucTMBCTaiChinh NewMucTMBCTaiChinhChild(MucTMBCTaiChinh bangCopy)
        {
            MucTMBCTaiChinh child = new MucTMBCTaiChinh();
            child.TenMucCapMot = bangCopy.TenMucCapMot;
            child.Vitri = bangCopy.Vitri;
            child.DienGiai = bangCopy.DienGiai;
            child.SoTT = bangCopy.SoTT;
            child.MaMucCapMotDoiUng=bangCopy.MaMucCapMotDoiUng!=0 ? bangCopy.MaMucCapMotDoiUng : bangCopy.MaMucCapMot;
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

		internal static MucTMBCTaiChinh GetMucTMBCTaiChinh(SafeDataReader dr)
		{
			MucTMBCTaiChinh child =  new MucTMBCTaiChinh();
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
			public int MaMucCapMot;

			public Criteria(int maMucCapMot)
			{
				this.MaMucCapMot = maMucCapMot;
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
                cm.CommandText = "spd_SelecttblMucTMBCTaiChinh";

				cm.Parameters.AddWithValue("@MaMucCapMot", criteria.MaMucCapMot);

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
			DataPortal_Delete(new Criteria(_maMucCapMot));
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
                cm.CommandText = "spd_DeletetblMucTMBCTaiChinh";

				cm.Parameters.AddWithValue("@MaMucCapMot", criteria.MaMucCapMot);

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
			_maMucCapMot = dr.GetInt32("MaMucCapMot");
			_tenMucCapMot = dr.GetString("TenMucCapMot");
			_vitri = dr.GetByte("Vitri");
			_dienGiai = dr.GetString("DienGiai");
            _soTT = dr.GetByte("SoTT");

            _isNHNN = dr.GetByte("isNHNN");
            _maThongTu = dr.GetInt32("MaThongTu");
            _maMucCapMotDoiUng = dr.GetInt32("MaMucCapMotDoiUng");
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
                cm.CommandText = "spd_InserttblMucTMBCTaiChinh";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maMucCapMot = (int)cm.Parameters["@MaMucCapMot"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_tenMucCapMot.Length > 0)
				cm.Parameters.AddWithValue("@TenMucCapMot", _tenMucCapMot);
			else
				cm.Parameters.AddWithValue("@TenMucCapMot", DBNull.Value);
			if (_vitri != 0)
				cm.Parameters.AddWithValue("@Vitri", _vitri);
			else
				cm.Parameters.AddWithValue("@Vitri", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_soTT != 0)
                cm.Parameters.AddWithValue("@SoTT", _soTT);
            else
                cm.Parameters.AddWithValue("@SoTT", DBNull.Value);

            if (_isNHNN != 0)
                cm.Parameters.AddWithValue("@isNHNN", _isNHNN);
            else
                cm.Parameters.AddWithValue("@isNHNN", DBNull.Value);
            if (_maThongTu != 0)
                cm.Parameters.AddWithValue("@MaThongTu", _maThongTu);
            else
                cm.Parameters.AddWithValue("@MaThongTu", DBNull.Value);

            if (_maMucCapMotDoiUng != 0)
                cm.Parameters.AddWithValue("@MaMucCapMotDoiUng", _maMucCapMotDoiUng);
            else
                cm.Parameters.AddWithValue("@MaMucCapMotDoiUng", DBNull.Value);

			cm.Parameters.AddWithValue("@MaMucCapMot", _maMucCapMot);
			cm.Parameters["@MaMucCapMot"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblMucTMBCTaiChinh";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaMucCapMot", _maMucCapMot);
			if (_tenMucCapMot.Length > 0)
				cm.Parameters.AddWithValue("@TenMucCapMot", _tenMucCapMot);
			else
				cm.Parameters.AddWithValue("@TenMucCapMot", DBNull.Value);
			if (_vitri != 0)
				cm.Parameters.AddWithValue("@Vitri", _vitri);
			else
				cm.Parameters.AddWithValue("@Vitri", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_soTT != 0)
                cm.Parameters.AddWithValue("@SoTT", _soTT);
            else
                cm.Parameters.AddWithValue("@SoTT", DBNull.Value);

            if (_isNHNN != 0)
                cm.Parameters.AddWithValue("@isNHNN", _isNHNN);
            else
                cm.Parameters.AddWithValue("@isNHNN", DBNull.Value);
            if (_maThongTu != 0)
                cm.Parameters.AddWithValue("@MaThongTu", _maThongTu);
            else
                cm.Parameters.AddWithValue("@MaThongTu", DBNull.Value);
            if (_maMucCapMotDoiUng != 0)
                cm.Parameters.AddWithValue("@MaMucCapMotDoiUng", _maMucCapMotDoiUng);
            else
                cm.Parameters.AddWithValue("@MaMucCapMotDoiUng", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maMucCapMot));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
