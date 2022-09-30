
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	
    
    [Serializable()] 
	public class MucNganSach : Csla.BusinessBase<MucNganSach>
	{
		#region Business Properties and Methods

		//declare members
		private int _maMucNganSach = 0;
		private string _maMucNganSachQL = string.Empty;
		private string _tenMucNganSach = string.Empty;
		private int _maTieuNhom = 0;
        private string _tenTieuNhom = string.Empty;
		private decimal _soTien = 0;
        private bool _chon = false;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaMucNganSach
		{
			get
			{
				CanReadProperty("MaMucNganSach", true);
				return _maMucNganSach;
			}
		}

		public string MaMucNganSachQL
		{
			get
			{
				CanReadProperty("MaMucNganSachQL", true);
				return _maMucNganSachQL;
			}
			set
			{
				CanWriteProperty("MaMucNganSachQL", true);
				if (value == null) value = string.Empty;
				if (!_maMucNganSachQL.Equals(value))
				{
					_maMucNganSachQL = value;
					PropertyHasChanged("MaMucNganSachQL");
				}
			}
		}

		public string TenMucNganSach
		{
			get
			{
				CanReadProperty("TenMucNganSach", true);
				return _tenMucNganSach;
			}
			set
			{
				CanWriteProperty("TenMucNganSach", true);
				if (value == null) value = string.Empty;
				if (!_tenMucNganSach.Equals(value))
				{
					_tenMucNganSach = value;
					PropertyHasChanged("TenMucNganSach");
				}
			}
		}

		public int MaTieuNhom
		{
			get
			{
				CanReadProperty("MaTieuNhom", true);
				return _maTieuNhom;
			}
			set
			{
				CanWriteProperty("MaTieuNhom", true);
				if (!_maTieuNhom.Equals(value))
				{
					_maTieuNhom = value;
					PropertyHasChanged("MaTieuNhom");
				}
			}
		}

        public string TenTieuNhom
        {
            get
            {
                CanReadProperty("TenTieuNhom", true);
                _tenTieuNhom = TieuNhomNganSach.GetTieuNhomNganSach(_maTieuNhom).TenTieuNhom;
                return _tenTieuNhom;
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
					PropertyHasChanged("SoTien");
				}
			}
		}


        public bool Chon
        {
            get
            {
             
                return _chon;
            }
            set
            {
                _chon = value;
            }
        }
 
		protected override object GetIdValue()
		{
			return _maMucNganSach;
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
			// MaMucNganSachQL
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "MaMucNganSachQL");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaMucNganSachQL", 50));
            ////
            //// TenMucNganSach
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "TenMucNganSach");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenMucNganSach", 4000));
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
			//TODO: Define authorization rules in MucNganSach
			//AuthorizationRules.AllowRead("MaMucNganSach", "MucNganSachReadGroup");
			//AuthorizationRules.AllowRead("MaMucNganSachQL", "MucNganSachReadGroup");
			//AuthorizationRules.AllowRead("TenMucNganSach", "MucNganSachReadGroup");
			//AuthorizationRules.AllowRead("MaTieuNhom", "MucNganSachReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "MucNganSachReadGroup");

			//AuthorizationRules.AllowWrite("MaMucNganSachQL", "MucNganSachWriteGroup");
			//AuthorizationRules.AllowWrite("TenMucNganSach", "MucNganSachWriteGroup");
			//AuthorizationRules.AllowWrite("MaTieuNhom", "MucNganSachWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "MucNganSachWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in MucNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucNganSachViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in MucNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucNganSachAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in MucNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucNganSachEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in MucNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucNganSachDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private MucNganSach()
		{ /* require use of factory method */ }

		public static MucNganSach NewMucNganSach()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a MucNganSach");
			return DataPortal.Create<MucNganSach>();
		}

        public static MucNganSach NewMucNganSach(string TenMuc)
        {
           
            MucNganSach a = MucNganSach.NewMucNganSach();
            a.TenMucNganSach = TenMuc;
            
            return a;
        }

		public static MucNganSach GetMucNganSach(int maMucNganSach)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a MucNganSach");
			return DataPortal.Fetch<MucNganSach>(new Criteria(maMucNganSach));
		}

		public static void DeleteMucNganSach(int maMucNganSach)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a MucNganSach");
			DataPortal.Delete(new Criteria(maMucNganSach));
		}

		public override MucNganSach Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a MucNganSach");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a MucNganSach");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a MucNganSach");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static MucNganSach NewMucNganSachChild()
		{
			MucNganSach child = new MucNganSach();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static MucNganSach GetMucNganSach(SafeDataReader dr)
		{
			MucNganSach child =  new MucNganSach();
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
			public int MaMucNganSach;

			public Criteria(int maMucNganSach)
			{
				this.MaMucNganSach = maMucNganSach;
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
                cm.CommandText = "spd_SelecttblMucNganSach";

				cm.Parameters.AddWithValue("@MaMucNganSach", criteria.MaMucNganSach);

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
			DataPortal_Delete(new Criteria(_maMucNganSach));
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
                cm.CommandText = "spd_DeletetblMucNganSach";

				cm.Parameters.AddWithValue("@MaMucNganSach", criteria.MaMucNganSach);

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
			_maMucNganSach = dr.GetInt32("MaMucNganSach");
			_maMucNganSachQL = dr.GetString("MaMucNganSachQL");
			_tenMucNganSach = dr.GetString("TenMucNganSach");
			_maTieuNhom = dr.GetInt32("MaTieuNhom");
			_soTien = dr.GetDecimal("SoTien");
            _chon = false;
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, MucNganSachList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, MucNganSachList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblMucNganSach";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maMucNganSach = (int)cm.Parameters["@MaMucNganSach"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, MucNganSachList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaMucNganSachQL", _maMucNganSachQL);
			cm.Parameters.AddWithValue("@TenMucNganSach", _tenMucNganSach);
			cm.Parameters.AddWithValue("@MaTieuNhom", _maTieuNhom);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			cm.Parameters.AddWithValue("@MaMucNganSach", _maMucNganSach);
			cm.Parameters["@MaMucNganSach"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, MucNganSachList parent)
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

		private void ExecuteUpdate(SqlConnection cn, MucNganSachList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblMucNganSach";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, MucNganSachList parent)
		{
			cm.Parameters.AddWithValue("@MaMucNganSach", _maMucNganSach);
			cm.Parameters.AddWithValue("@MaMucNganSachQL", _maMucNganSachQL);
			cm.Parameters.AddWithValue("@TenMucNganSach", _tenMucNganSach);
			cm.Parameters.AddWithValue("@MaTieuNhom", _maTieuNhom);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
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

			ExecuteDelete(cn, new Criteria(_maMucNganSach));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
