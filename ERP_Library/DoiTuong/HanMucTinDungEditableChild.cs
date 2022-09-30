
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HanMucTinDung : Csla.BusinessBase<HanMucTinDung>
	{
		#region Business Properties and Methods

		//declare members
		private int _maHanMucTinDung = 0;
		private int _phanTramLaiSuat = 0;
        private decimal _gioiHanTinDungChoKH = 0;
        private decimal _gioiHanTinDungChoHD = 0;
		private long _maKhachHang = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaHanMucTinDung
		{
			get
			{
				CanReadProperty("MaHanMucTinDung", true);
				return _maHanMucTinDung;
			}
		}

		public int PhanTramLaiSuat
		{
			get
			{
				CanReadProperty("PhanTramLaiSuat", true);
				return _phanTramLaiSuat;
			}
			set
			{
				CanWriteProperty("PhanTramLaiSuat", true);
				if (!_phanTramLaiSuat.Equals(value))
				{
					_phanTramLaiSuat = value;
					PropertyHasChanged("PhanTramLaiSuat");
				}
			}
		}

        public decimal GioiHanTinDungChoKH
        {
            get
            {
                CanReadProperty("GioiHanTinDungChoKH", true);
                return _gioiHanTinDungChoKH;
            }
            set
            {
                CanWriteProperty("GioiHanTinDungChoKH", true);
                if (!_gioiHanTinDungChoKH.Equals(value))
                {
                    _gioiHanTinDungChoKH = value;
                    PropertyHasChanged("GioiHanTinDungChoKH");
                }
            }
        }

        public decimal GioiHanTinDungChoHD
        {
            get
            {
                CanReadProperty("GioiHanTinDungChoHD", true);
                return _gioiHanTinDungChoHD;
            }
            set
            {
                CanWriteProperty("GioiHanTinDungChoHD", true);
                if (!_gioiHanTinDungChoHD.Equals(value))
                {
                    _gioiHanTinDungChoHD = value;
                    PropertyHasChanged("GioiHanTinDungChoHD");
                }
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
 
		protected override object GetIdValue()
		{
			return _maHanMucTinDung;
		}

		#endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {

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
            //TODO: Define authorization rules in HanMucTinDung
            //AuthorizationRules.AllowRead("MaHanMucTinDung", "HanMucTinDungReadGroup");
            //AuthorizationRules.AllowRead("PhanTramLaiSuat", "HanMucTinDungReadGroup");
            //AuthorizationRules.AllowRead("GioiHanTinDungChoKH", "HanMucTinDungReadGroup");
            //AuthorizationRules.AllowRead("GioiHanTinDungChoHD", "HanMucTinDungReadGroup");
            //AuthorizationRules.AllowRead("MaKhachHang", "HanMucTinDungReadGroup");

            //AuthorizationRules.AllowWrite("PhanTramLaiSuat", "HanMucTinDungWriteGroup");
            //AuthorizationRules.AllowWrite("GioiHanTinDungChoKH", "HanMucTinDungWriteGroup");
            //AuthorizationRules.AllowWrite("GioiHanTinDungChoHD", "HanMucTinDungWriteGroup");
            //AuthorizationRules.AllowWrite("MaKhachHang", "HanMucTinDungWriteGroup");
        }

        #endregion //Authorization Rules

		#region Factory Methods
		public static HanMucTinDung NewHanMucTinDung()
		{
			return new HanMucTinDung();
		}

		internal static HanMucTinDung GetHanMucTinDung(SafeDataReader dr)
		{
			return new HanMucTinDung(dr);
		}

		private HanMucTinDung()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private HanMucTinDung(SafeDataReader dr)
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
			_maHanMucTinDung = dr.GetInt32("MaHanMucTinDung");
			_phanTramLaiSuat = dr.GetInt32("PhanTramLaiSuat");
            _gioiHanTinDungChoKH = dr.GetDecimal("GioiHanTinDungChoKH");
            _gioiHanTinDungChoHD = dr.GetDecimal("GioiHanTinDungChoHD");
			_maKhachHang = dr.GetInt64("MaKhachHang");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, KhachHang parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, KhachHang parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblHanMucTinDung";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maHanMucTinDung = (int)cm.Parameters["@MaHanMucTinDung"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, KhachHang parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@PhanTramLaiSuat", _phanTramLaiSuat);
			cm.Parameters.AddWithValue("@GioiHanTinDungChoKH", _gioiHanTinDungChoKH);
			cm.Parameters.AddWithValue("@GioiHanTinDungChoHD", _gioiHanTinDungChoHD);
			cm.Parameters.AddWithValue("@MaKhachHang", parent.MaKhachHang);
			cm.Parameters.AddWithValue("@MaHanMucTinDung", _maHanMucTinDung);
			cm.Parameters["@MaHanMucTinDung"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, KhachHang parent)
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

		private void ExecuteUpdate(SqlTransaction tr, KhachHang parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblHanMucTinDung";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, KhachHang parent)
		{
			cm.Parameters.AddWithValue("@MaHanMucTinDung", _maHanMucTinDung);
			cm.Parameters.AddWithValue("@PhanTramLaiSuat", _phanTramLaiSuat);
			cm.Parameters.AddWithValue("@GioiHanTinDungChoKH", _gioiHanTinDungChoKH);
			cm.Parameters.AddWithValue("@GioiHanTinDungChoHD", _gioiHanTinDungChoHD);
			cm.Parameters.AddWithValue("@MaKhachHang", parent.MaKhachHang);
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

			ExecuteDelete(tr);
			MarkNew();
		}

		private void ExecuteDelete(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblHanMucTinDung";

				cm.Parameters.AddWithValue("@MaHanMucTinDung", this._maHanMucTinDung);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
