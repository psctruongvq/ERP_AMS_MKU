
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.ComponentModel;

namespace ERP_Library
{ 
	[Serializable()]
    //[TypeConverter(typeof(LoaiTienTypeConverter))]
	public class LoaiTien : Csla.BusinessBase<LoaiTien>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiTien = 0;
		private double _tiGiaQuyDoi = 0;
		private string _tenLoaiTien = string.Empty;
		private string _maLoaiQuanLy = string.Empty;
        private string _tienChan = string.Empty;
        private string _tienLe = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLoaiTien
		{
			get
			{
				CanReadProperty("MaLoaiTien", true);
				return _maLoaiTien;
			}
		}

		public double TiGiaQuyDoi
		{
			get
			{
				CanReadProperty("TiGiaQuyDoi", true);
				return _tiGiaQuyDoi;
			}
			set
			{
				CanWriteProperty("TiGiaQuyDoi", true);
				if (!_tiGiaQuyDoi.Equals(value))
				{
					_tiGiaQuyDoi = value;
					PropertyHasChanged("TiGiaQuyDoi");
				}
			}
		}

		public string TenLoaiTien
		{
			get
			{
				CanReadProperty("TenLoaiTien", true);
				return _tenLoaiTien;
			}
			set
			{
				CanWriteProperty("TenLoaiTien", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiTien.Equals(value))
				{
					_tenLoaiTien = value;
					PropertyHasChanged("TenLoaiTien");
				}
			}
		}

		public string MaLoaiQuanLy
		{
			get
			{
				CanReadProperty("MaLoaiQuanLy", true);
				return _maLoaiQuanLy;
			}
			set
			{
				CanWriteProperty("MaLoaiQuanLy", true);
				if (value == null) value = string.Empty;
				if (!_maLoaiQuanLy.Equals(value))
				{
					_maLoaiQuanLy = value;
					PropertyHasChanged("MaLoaiQuanLy");
				}
			}
		}

        public string TienChan
		{
			get
			{
				CanReadProperty("TienChan", true);
				return _tienChan;
			}
			set
			{
				CanWriteProperty("TienChan", true);
				if (value == null) value = string.Empty;
				if (!_tienChan.Equals(value))
				{
					_tienChan = value;
					PropertyHasChanged("TienChan");
				}
			}
		}

        public string TienLe
		{
			get
			{
				CanReadProperty("TienLe", true);
				return _tienLe;
			}
			set
			{
				CanWriteProperty("TienLe", true);
				if (value == null) value = string.Empty;
				if (!_tienLe.Equals(value))
				{
					_tienLe = value;
					PropertyHasChanged("TienLe");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maLoaiTien;
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
			// TenLoaiTien
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenLoaiTien");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiTien", 500));
			//
			// MaLoaiQuanLy
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "MaLoaiQuanLy");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaLoaiQuanLy", 50));
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
			//TODO: Define authorization rules in LoaiTien
			//AuthorizationRules.AllowRead("MaLoaiTien", "LoaiTienReadGroup");
			//AuthorizationRules.AllowRead("TiGiaQuyDoi", "LoaiTienReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiTien", "LoaiTienReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiQuanLy", "LoaiTienReadGroup");

			//AuthorizationRules.AllowWrite("TiGiaQuyDoi", "LoaiTienWriteGroup");
			//AuthorizationRules.AllowWrite("TenLoaiTien", "LoaiTienWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiQuanLy", "LoaiTienWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiTien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTienViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiTien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTienAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiTien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTienEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiTien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTienDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiTien()
		{ /* require use of factory method */ }

        private LoaiTien(int ma,string ten)
        {
            _maLoaiTien = ma;
            _tenLoaiTien = ten;
        }

        private LoaiTien(string MaLoaiTien)
        {
            _maLoaiQuanLy = MaLoaiTien;
        }

        public static LoaiTien NewLoaiTien(int ma,string ten)
        {
            return new LoaiTien(ma, ten);
        }

        public static LoaiTien NewLoaiTien(string ten)
        {
            return new LoaiTien(ten);
        }

		public static LoaiTien NewLoaiTien()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiTien");
			return DataPortal.Create<LoaiTien>();
		}

		public static LoaiTien GetLoaiTien(int maLoaiTien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiTien");
			return DataPortal.Fetch<LoaiTien>(new Criteria(maLoaiTien));
		}

		public static void DeleteLoaiTien(int maLoaiTien)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiTien");
			DataPortal.Delete(new Criteria(maLoaiTien));
		}

		public override LoaiTien Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiTien");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiTien");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiTien");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LoaiTien NewLoaiTienChild()
		{
			LoaiTien child = new LoaiTien();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiTien GetLoaiTien(SafeDataReader dr)
		{
			LoaiTien child =  new LoaiTien();
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
			public int MaLoaiTien;

			public Criteria(int maLoaiTien)
			{
				this.MaLoaiTien = maLoaiTien;
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
                cm.CommandText = "spd_SelecttblLoaiTien";

				cm.Parameters.AddWithValue("@MaLoaiTien", criteria.MaLoaiTien);

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
			DataPortal_Delete(new Criteria(_maLoaiTien));
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
                cm.CommandText = "spd_DeletetblLoaiTien";

				cm.Parameters.AddWithValue("@MaLoaiTien", criteria.MaLoaiTien);

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
			_maLoaiTien = dr.GetInt32("MaLoaiTien");
			_tiGiaQuyDoi = dr.GetDouble("TiGiaQuyDoi");
			_tenLoaiTien = dr.GetString("TenLoaiTien");
			_maLoaiQuanLy = dr.GetString("MaLoaiQuanLy");
            _tienChan = dr.GetString("TienChan");
            _tienLe = dr.GetString("TienLe");
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
                cm.CommandText = "spd_InserttblLoaiTien";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maLoaiTien = (int)cm.Parameters["@MaLoaiTien"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@TiGiaQuyDoi", _tiGiaQuyDoi);
			cm.Parameters.AddWithValue("@TenLoaiTien", _tenLoaiTien);
			cm.Parameters.AddWithValue("@MaLoaiQuanLy", _maLoaiQuanLy);
            cm.Parameters.AddWithValue("@TienChan", _tienChan);
            cm.Parameters.AddWithValue("@TienLe", _tienLe);
			cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
			cm.Parameters["@MaLoaiTien"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblLoaiTien";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
			cm.Parameters.AddWithValue("@TiGiaQuyDoi", _tiGiaQuyDoi);
			cm.Parameters.AddWithValue("@TenLoaiTien", _tenLoaiTien);
            cm.Parameters.AddWithValue("@TienChan", _tienChan);
            cm.Parameters.AddWithValue("@TienLe", _tienLe);
			cm.Parameters.AddWithValue("@MaLoaiQuanLy", _maLoaiQuanLy);
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

			ExecuteDelete(tr, new Criteria(_maLoaiTien));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
    #region Type Converter

    public class LoaiTienTypeConverter : TypeConverter
    {
             
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(Int32))
            {
                return ((LoaiTien)value).MaLoaiTien;
            }
            if (destinationType == typeof(String))
            {
                return ((LoaiTien)value).TenLoaiTien;
            }
            return value;
            
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Int32))
            {
                return true;
            }
            else if (destinationType == typeof(String))
            {
                return true;
            }
            else if (destinationType == typeof(Object))
            {
                return true;
            }
            return false;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(Int32))
            {
                return true;
            }
            else return false;
        }
    }
    #endregion 
}
