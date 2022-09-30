
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
    
	public class QuocGia : Csla.BusinessBase<QuocGia>
	{
		#region Business Properties and Methods

		//declare members
		private int _maQuocGia = 0;
		private string _maQuocGiaQuanLy = string.Empty;
		private string _tenQuocGia = string.Empty;
		private string _dienGiai = string.Empty;
        private string _tenVietTat = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaQuocGia
		{
			get
			{
				CanReadProperty("MaQuocGia", true);
				return _maQuocGia;
			}
		}

		public string MaQuocGiaQuanLy
		{
			get
			{
				CanReadProperty("MaQuocGiaQuanLy", true);
				return _maQuocGiaQuanLy;
			}
			set
			{
				CanWriteProperty("MaQuocGiaQuanLy", true);
				if (value == null) value = string.Empty;
				if (!_maQuocGiaQuanLy.Equals(value))
				{
					_maQuocGiaQuanLy = value;
					PropertyHasChanged("MaQuocGiaQuanLy");
				}
			}
		}
        public string TenVietTat
        {
            get
            {
                CanReadProperty("TenVietTat", true);
                return _tenVietTat;
            }
            set
            {
                CanWriteProperty("TenVietTat", true);
                if (value == null) value = string.Empty;
                if (!_tenVietTat.Equals(value))
                {
                    _tenVietTat = value;
                    PropertyHasChanged("TenVietTat");
                }
            }
        }
		public string TenQuocGia
		{
			get
			{
				CanReadProperty("TenQuocGia", true);
				return _tenQuocGia;
			}
			set
			{
				CanWriteProperty("TenQuocGia", true);
				if (value == null) value = string.Empty;
				if (!_tenQuocGia.Equals(value))
				{
					_tenQuocGia = value;
					PropertyHasChanged("TenQuocGia");
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
			return _maQuocGia;
		}
        public override string ToString()
        {
            return QuocGia.GetQuocGia(_maQuocGia)._tenQuocGia;//base.ToString();
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
			// MaQuocGiaQuanLy
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "MaQuocGiaQuanLy");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuocGiaQuanLy", 20));
            ////
            //// TenQuocGia
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "TenQuocGia");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenQuocGia", 500));
            ////
            //// DienGiai
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "DienGiai");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
			//TODO: Define authorization rules in QuocGia
			//AuthorizationRules.AllowRead("MaQuocGia", "QuocGiaReadGroup");
			//AuthorizationRules.AllowRead("MaQuocGiaQuanLy", "QuocGiaReadGroup");
			//AuthorizationRules.AllowRead("TenQuocGia", "QuocGiaReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "QuocGiaReadGroup");

			//AuthorizationRules.AllowWrite("MaQuocGiaQuanLy", "QuocGiaWriteGroup");
			//AuthorizationRules.AllowWrite("TenQuocGia", "QuocGiaWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "QuocGiaWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuocGia
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuocGiaViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuocGia
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuocGiaAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuocGia
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuocGiaEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuocGia
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuocGiaDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuocGia()
		{ /* require use of factory method */ }

		public static QuocGia NewQuocGia()
		{
            QuocGia i = new QuocGia();
            i.MarkAsChild();
            return i;
		}
        private QuocGia(int maquocgia, string tenquocgia)
        {
            this._maQuocGia = maquocgia;
            this._tenQuocGia = tenquocgia;
        }

        public static QuocGia NewQuocGia(int maquocgia, string tenquocgia)
        {
            return new QuocGia(maquocgia, tenquocgia);
        }
		public static QuocGia GetQuocGia(int maQuocGia)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuocGia");
			return DataPortal.Fetch<QuocGia>(new Criteria(maQuocGia));
		}

		public static void DeleteQuocGia(int maQuocGia)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuocGia");
			DataPortal.Delete(new Criteria(maQuocGia));
		}

		public override QuocGia Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuocGia");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuocGia");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuocGia");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuocGia NewQuocGiaChild()
		{
			QuocGia child = new QuocGia();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuocGia GetQuocGia(SafeDataReader dr)
		{
			QuocGia child =  new QuocGia();
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
			public int MaQuocGia;

			public Criteria(int maQuocGia)
			{
				this.MaQuocGia = maQuocGia;
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
                cm.CommandText = "spd_SelecttblQuocGia";

				cm.Parameters.AddWithValue("@MaQuocGia", criteria.MaQuocGia);

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
			DataPortal_Delete(new Criteria(_maQuocGia));
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
                cm.CommandText = "spd_DeletetblQuocGia";

				cm.Parameters.AddWithValue("@MaQuocGia", criteria.MaQuocGia);

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
			_maQuocGia = dr.GetInt32("MaQuocGia");
			_maQuocGiaQuanLy = dr.GetString("MaQuocGiaQuanLy");
			_tenQuocGia = dr.GetString("TenQuocGia");
			_dienGiai = dr.GetString("DienGiai");
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
                cm.CommandText = "spd_InserttblQuocGia";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maQuocGia = (int)cm.Parameters["@MaQuocGia"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuocGiaQuanLy", _maQuocGiaQuanLy);
			cm.Parameters.AddWithValue("@TenQuocGia", _tenQuocGia);
			cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
			cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
			cm.Parameters["@MaQuocGia"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblQuocGia";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
			cm.Parameters.AddWithValue("@MaQuocGiaQuanLy", _maQuocGiaQuanLy);
			cm.Parameters.AddWithValue("@TenQuocGia", _tenQuocGia);
			cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
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

			ExecuteDelete(tr, new Criteria(_maQuocGia));
			MarkNew();
		}
		#endregion //Data Access - Delete

		#endregion //Data Access
	}
    #region Type Converter

    public class QuocGiaTypeConverter : TypeConverter
    {

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            int giatri = Convert.ToInt32(value);
            return QuocGia.GetQuocGia((int)giatri);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(Int32))
            {
                return ((QuocGia)value).MaQuocGia;
            }
            if (destinationType == typeof(String))
            {
                return ((QuocGia)value).TenQuocGia;
            }
            if (destinationType == typeof(Object))
            {
                return ((QuocGia)value).MaQuocGiaQuanLy;
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
