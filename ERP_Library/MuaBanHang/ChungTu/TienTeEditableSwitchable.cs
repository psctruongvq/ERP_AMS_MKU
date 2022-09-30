
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
    [TypeConverter(typeof(TienTeTypeConverter))]     
	public class TienTe : Csla.BusinessBase<TienTe>
	{
		#region Business Properties and Methods

		//declare members
		private long  _maTienTe = 0;
		private decimal  _soTien = 0;
		private int  _maLoaiTien = 0;
		private decimal _thanhTien = 0;
		private string _vietBangChu   = string.Empty;
		private decimal _tiGiaQuyDoi = 1;


       
		[System.ComponentModel.DataObjectField(true, false)]
		public long MaTienTe
		{
			get
			{
				CanReadProperty("MaTienTe", true);
				return _maTienTe;
			}
            set
            {
                CanWriteProperty("MaTienTe", true);
                if (!_maTienTe.Equals(value))
                {
                    _maTienTe = value;
                    PropertyHasChanged("MaTienTe");
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
                    //_vietBangChu = HamDungChung.DocTien(_soTien);
                    // _thanhTien = Math.Round(_soTien * _tiGiaQuyDoi, 0, MidpointRounding.AwayFromZero); 
                   
                    //_vietBangChu = HamDungChung.DocTien( Math.Abs(Convert.ToDecimal(_thanhTien)));
                        
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
                    _tiGiaQuyDoi = Convert.ToDecimal(LoaiTien.GetLoaiTien(_maLoaiTien).TiGiaQuyDoi);                    
                    //_thanhTien = Math.Round(_soTien * _tiGiaQuyDoi, 0, MidpointRounding.AwayFromZero);
                    //_vietBangChu = HamDungChung.DocTien( Math.Abs(Convert.ToDecimal(_thanhTien)));
					PropertyHasChanged("MaLoaiTien");
				}
			}
		}

		public decimal ThanhTien
		{
			get
			{
				CanReadProperty("ThanhTien", true);
				return _thanhTien;
			}
			set
			{
				CanWriteProperty("ThanhTien", true);
				if (!_thanhTien.Equals(value))
				{
					_thanhTien = value;
                    _vietBangChu = HamDungChung.DocTien( Math.Abs(Convert.ToDecimal(_thanhTien)));
                    
					PropertyHasChanged("ThanhTien");
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

		public decimal TiGiaQuyDoi
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
                    //_thanhTien = _soTien * _tiGiaQuyDoi;
                    //_thanhTien = Math.Round(_soTien * _tiGiaQuyDoi, 0, MidpointRounding.AwayFromZero); 
                    //_vietBangChu = HamDungChung.DocTien(_thanhTien);
					PropertyHasChanged("TiGiaQuyDoi");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTienTe;
		}

        public override string ToString()
        {
            return _soTien.ToString();
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
			// VietBangChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("VietBangChu", 1000));
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
			//TODO: Define authorization rules in TienTe
			//AuthorizationRules.AllowRead("MaTienTe", "TienTeReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "TienTeReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiTien", "TienTeReadGroup");
			//AuthorizationRules.AllowRead("ThanhTien", "TienTeReadGroup");
			//AuthorizationRules.AllowRead("VietBangChu", "TienTeReadGroup");
			//AuthorizationRules.AllowRead("TiGiaQuyDoi", "TienTeReadGroup");

			//AuthorizationRules.AllowWrite("SoTien", "TienTeWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiTien", "TienTeWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhTien", "TienTeWriteGroup");
			//AuthorizationRules.AllowWrite("VietBangChu", "TienTeWriteGroup");
			//AuthorizationRules.AllowWrite("TiGiaQuyDoi", "TienTeWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TienTe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TienTeViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TienTe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TienTeAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TienTe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TienTeEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TienTe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TienTeDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TienTe()
		{ /* require use of factory method */ }

		public static TienTe NewTienTe(long maTienTe)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TienTe");
			return DataPortal.Create<TienTe>(new Criteria(maTienTe));
		}

		public static TienTe GetTienTe(long maTienTe)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TienTe");
			return DataPortal.Fetch<TienTe>(new Criteria(maTienTe));
		}

		public static void DeleteTienTe(long maTienTe)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TienTe");
			DataPortal.Delete(new Criteria(maTienTe));
		}

		public override TienTe Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TienTe");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TienTe");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TienTe");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private TienTe(long maTienTe)
		{
			this._maTienTe = maTienTe;
		}

		internal static TienTe NewTienTeChild(long maTienTe)
		{
			TienTe child = new TienTe(maTienTe);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TienTe GetTienTe(SafeDataReader dr)
		{
			TienTe child =  new TienTe();
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
			public long MaTienTe;

			public Criteria(long maTienTe)
			{
				this.MaTienTe = maTienTe;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maTienTe = criteria.MaTienTe;
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
				cm.CommandText = "spd_SelecttblTienTe";

				cm.Parameters.AddWithValue("@MaTienTe", criteria.MaTienTe);

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
			DataPortal_Delete(new Criteria(_maTienTe));
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
				cm.CommandText = "spd_DeletetblTienTe";

				cm.Parameters.AddWithValue("@MaTienTe", criteria.MaTienTe);

				cm.ExecuteNonQuery();
			}//using
		}
        // tran them
        public void DataPortal_Delete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblTienTe";

                cm.Parameters.AddWithValue("@MaTienTe",_maTienTe);

                cm.ExecuteNonQuery();
            }//using
        }
        //
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
			_maTienTe = dr.GetInt64("MaTienTe");
			_soTien = dr.GetDecimal("SoTien");
			_maLoaiTien = dr.GetInt32("MaLoaiTien");
			_thanhTien = dr.GetDecimal("ThanhTien");
			_vietBangChu = dr.GetString("VietBangChu");
			_tiGiaQuyDoi = dr.GetDecimal("TiGiaQuyDoi");
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
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblTienTe";

                    AddInsertParameters(cm);

                    cm.ExecuteNonQuery();

                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }

		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaTienTe", _maTienTe);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
            //if (_soTien != 0)
            //    cm.Parameters.AddWithValue("@SoTien", _soTien);
            //else
            //    cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_maLoaiTien == 0)
            {
                cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
            }
            else
            {
                cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            }
			if (_thanhTien != 0)
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			else
				cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
			if (_vietBangChu.Length > 0)
				cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
			else
				cm.Parameters.AddWithValue("@VietBangChu", DBNull.Value);
			if (_tiGiaQuyDoi != 0)
				cm.Parameters.AddWithValue("@TiGiaQuyDoi", _tiGiaQuyDoi);
			else
				cm.Parameters.AddWithValue("@TiGiaQuyDoi", DBNull.Value);
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
				cm.CommandText = "spd_UpdatetblTienTe";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaTienTe", _maTienTe);
			cm.Parameters.AddWithValue("@SoTien", _soTien);           
            if (_maLoaiTien == 0)
            {
                cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
            }
            else
            {
                cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            }
			if (_thanhTien != 0)
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			else
				cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
			if (_vietBangChu.Length > 0)
				cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
			else
				cm.Parameters.AddWithValue("@VietBangChu", DBNull.Value);
			if (_tiGiaQuyDoi != 0)
				cm.Parameters.AddWithValue("@TiGiaQuyDoi", _tiGiaQuyDoi);
			else
				cm.Parameters.AddWithValue("@TiGiaQuyDoi", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maTienTe));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
    #region Type Converter

    public class TienTeTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            long giatri = Convert.ToInt64(value);
            return TienTe.GetTienTe((long)giatri);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(long))
            {
                return ((TienTe)value).MaLoaiTien;
            }
            if (destinationType == typeof(Decimal))
            {
                return ((TienTe)value).ThanhTien;
            }
            if (destinationType == typeof(String))
            {
                return ((TienTe)value).VietBangChu;
            }
            if (destinationType == typeof(Object))
            {
                return ((TienTe)value).SoTien;
            }
            return value;

        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(long))
            {
                return true;
            }
            else if (destinationType == typeof(Decimal))
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
            if (sourceType == typeof(long))
            {
                return true;
            }
            else return false;
        }
    }
    #endregion 
}
