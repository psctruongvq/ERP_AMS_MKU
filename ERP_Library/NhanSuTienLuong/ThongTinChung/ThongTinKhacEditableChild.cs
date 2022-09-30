
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThongTinKhac : Csla.BusinessBase<ThongTinKhac>
	{
		#region Business Properties and Methods

		//declare members
		private int _maThongTinKhac = 0;
		private long _maNhanVien = 0;
		private string _lichSuBanThan1 = string.Empty;
		private string _lichSuBanThan2 = string.Empty;
		private string _quanHeNN = string.Empty;
		private string _quanHeGD = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaThongTinKhac
		{
			get
			{
				CanReadProperty("MaThongTinKhac", true);
				return _maThongTinKhac;
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

		public string LichSuBanThan1
		{
			get
			{
				CanReadProperty("LichSuBanThan1", true);
				return _lichSuBanThan1;
			}
			set
			{
				CanWriteProperty("LichSuBanThan1", true);
				if (value == null) value = string.Empty;
				if (!_lichSuBanThan1.Equals(value))
				{
					_lichSuBanThan1 = value;
					PropertyHasChanged("LichSuBanThan1");
				}
			}
		}

		public string LichSuBanThan2
		{
			get
			{
				CanReadProperty("LichSuBanThan2", true);
				return _lichSuBanThan2;
			}
			set
			{
				CanWriteProperty("LichSuBanThan2", true);
				if (value == null) value = string.Empty;
				if (!_lichSuBanThan2.Equals(value))
				{
					_lichSuBanThan2 = value;
					PropertyHasChanged("LichSuBanThan2");
				}
			}
		}

		public string QuanHeNN
		{
			get
			{
				CanReadProperty("QuanHeNN", true);
				return _quanHeNN;
			}
			set
			{
				CanWriteProperty("QuanHeNN", true);
				if (value == null) value = string.Empty;
				if (!_quanHeNN.Equals(value))
				{
					_quanHeNN = value;
					PropertyHasChanged("QuanHeNN");
				}
			}
		}

		public string QuanHeGD
		{
			get
			{
				CanReadProperty("QuanHeGD", true);
				return _quanHeGD;
			}
			set
			{
				CanWriteProperty("QuanHeGD", true);
				if (value == null) value = string.Empty;
				if (!_quanHeGD.Equals(value))
				{
					_quanHeGD = value;
					PropertyHasChanged("QuanHeGD");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maThongTinKhac;
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
			// LichSuBanThan1
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "LichSuBanThan1");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LichSuBanThan1", 4000));
            ////
            //// LichSuBanThan2
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "LichSuBanThan2");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LichSuBanThan2", 4000));
            ////
            //// QuanHeNN
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "QuanHeNN");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("QuanHeNN", 4000));
            ////
            //// QuanHeGD
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "QuanHeGD");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("QuanHeGD", 4000));
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
			//TODO: Define authorization rules in ThongTinKhac
			//AuthorizationRules.AllowRead("MaThongTinKhac", "ThongTinKhacReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "ThongTinKhacReadGroup");
			//AuthorizationRules.AllowRead("LichSuBanThan1", "ThongTinKhacReadGroup");
			//AuthorizationRules.AllowRead("LichSuBanThan2", "ThongTinKhacReadGroup");
			//AuthorizationRules.AllowRead("QuanHeNN", "ThongTinKhacReadGroup");
			//AuthorizationRules.AllowRead("QuanHeGD", "ThongTinKhacReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "ThongTinKhacWriteGroup");
			//AuthorizationRules.AllowWrite("LichSuBanThan1", "ThongTinKhacWriteGroup");
			//AuthorizationRules.AllowWrite("LichSuBanThan2", "ThongTinKhacWriteGroup");
			//AuthorizationRules.AllowWrite("QuanHeNN", "ThongTinKhacWriteGroup");
			//AuthorizationRules.AllowWrite("QuanHeGD", "ThongTinKhacWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static ThongTinKhac NewThongTinKhac()
		{
			return new ThongTinKhac();
		}

        public static ThongTinKhac GetThongTinKhac(SafeDataReader dr)
        {
            return new ThongTinKhac(dr);
        }

        //public static ThongTinKhac GetThongTinKhac(long MaNhanVien)
        //{
        //    return DataPortal.Fetch<ThongTinKhac>(new FilterCriteria(MaNhanVien));
        //}

		private ThongTinKhac()
		{
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private ThongTinKhac(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods

		#region Data Access

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
            _maThongTinKhac = dr.GetInt32("MaThongTinKhac");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _lichSuBanThan1 = dr.GetString("LichSuBanThan1");
            _lichSuBanThan2 = dr.GetString("LichSuBanThan2");
            _quanHeNN = dr.GetString("QuanHeNN");
            _quanHeGD = dr.GetString("QuanHeGD");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

        #region Data Access - Fetch

        //#region Filter Criteria
        //[Serializable()]
        //private class FilterCriteria
        //{
        //    public long MaNhanVien;

        //    public FilterCriteria(long MaNhanVien)
        //    {
        //        this.MaNhanVien = MaNhanVien;
        //    }
        //}
        //#endregion //Filter Criteria

        //private void DataPortal_Fetch(FilterCriteria criteria)
        //{
        //    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //    {
        //        cn.Open();

        //        ExecuteFetch(cn, criteria);
        //    }//using
        //}

        //private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        //{
        //    using (SqlCommand cm = cn.CreateCommand())
        //    {
        //        cm.CommandType = CommandType.StoredProcedure;
        //        cm.CommandText = "spd_SelecttblnsThongTinKhacsAll";

        //        cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

        //        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
        //        {
        //            dr.Read();
        //            FetchObject(dr);
        //            ValidationRules.CheckRules();

        //            //load child object(s)
        //           // FetchChildren(dr);
        //        }
        //    }//using
        //}

        #endregion //Data Access - Fetch

		#region Data Access - Insert
        internal void Insert(SqlTransaction cn, NhanVien parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

        private void ExecuteInsert(SqlTransaction cn, NhanVien parent)
		{
            using (SqlCommand cm = cn.Connection.CreateCommand())
			{
                cm.Transaction = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsThongTinKhac";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maThongTinKhac = (int)cm.Parameters["@MaThongTinKhac"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			cm.Parameters.AddWithValue("@LichSuBanThan1", _lichSuBanThan1);
			cm.Parameters.AddWithValue("@LichSuBanThan2", _lichSuBanThan2);
			cm.Parameters.AddWithValue("@QuanHeNN", _quanHeNN);
			cm.Parameters.AddWithValue("@QuanHeGD", _quanHeGD);
			cm.Parameters.AddWithValue("@MaThongTinKhac", _maThongTinKhac);
			cm.Parameters["@MaThongTinKhac"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction cn, NhanVien parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn, parent);
				MarkOld();
			}

			//update child object(s)
			//UpdateChildren(cn);
		}

        private void ExecuteUpdate(SqlTransaction cn, NhanVien parent)
		{
            using (SqlCommand cm = cn.Connection.CreateCommand())
			{
                cm.Transaction = cn;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsThongTinKhac";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
			cm.Parameters.AddWithValue("@MaThongTinKhac", _maThongTinKhac);
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			cm.Parameters.AddWithValue("@LichSuBanThan1", _lichSuBanThan1);
			cm.Parameters.AddWithValue("@LichSuBanThan2", _lichSuBanThan2);
			cm.Parameters.AddWithValue("@QuanHeNN", _quanHeNN);
			cm.Parameters.AddWithValue("@QuanHeGD", _quanHeGD);
		}

        private void UpdateChildren(SqlTransaction cn)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
        internal void DeleteSelf(SqlTransaction cn)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(cn);
			MarkNew();
		}

        private void ExecuteDelete(SqlTransaction cn)
		{
            using (SqlCommand cm = cn.Connection.CreateCommand())
			{
                cm.Transaction = cn; 
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsThongTinKhac";

				cm.Parameters.AddWithValue("@MaThongTinKhac", this._maThongTinKhac);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
