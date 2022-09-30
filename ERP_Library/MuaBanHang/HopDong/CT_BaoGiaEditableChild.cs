
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_BaoGia : Csla.BusinessBase<CT_BaoGia>
	{
		#region Business Properties and Methods

		//declare members
		private int _mactBaogia = 0;
		private int _maBangBaoGia = 0;
		private int _maHangHoa = 0;
        private int _maDonViTinh = 0;
		private decimal _donGia = 0;
        private Int16 _vat = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MactBaogia
		{
			get
			{
				CanReadProperty("MactBaogia", true);
				return _mactBaogia;
			}
		}

		public int MaBangBaoGia
		{
			get
			{
				CanReadProperty("MaBangBaoGia", true);
				return _maBangBaoGia;
			}
			set
			{
				CanWriteProperty("MaBangBaoGia", true);
				if (!_maBangBaoGia.Equals(value))
				{
					_maBangBaoGia = value;
					PropertyHasChanged("MaBangBaoGia");
				}
			}
		}

		public int MaHangHoa
		{
			get
			{
				CanReadProperty("MaHangHoa", true);
				return _maHangHoa;
			}
			set
			{
				CanWriteProperty("MaHangHoa", true);
				if (!_maHangHoa.Equals(value))
				{
					_maHangHoa = value;
					PropertyHasChanged("MaHangHoa");
				}
			}
		}

        public int MaDonViTinh
        {
            get
            {
                CanReadProperty("MaHangHoa", true);
                return _maDonViTinh;
            }
            set
            {
                CanWriteProperty("MaHangHoa", true);
                if (!_maDonViTinh.Equals(value))
                {
                    _maDonViTinh = value;
                    PropertyHasChanged("MaHangHoa");
                }
            }
        }

		public decimal DonGia
		{
			get
			{
				CanReadProperty("DonGia", true);
				return _donGia;
			}
			set
			{
				CanWriteProperty("DonGia", true);
				if (!_donGia.Equals(value))
				{
					_donGia = value;
					PropertyHasChanged("DonGia");
				}
			}
		}

        public Int16 Vat
        {
            get
            {
                CanReadProperty("DonGia", true);
                return _vat;
            }
            set
            {
                CanWriteProperty("DonGia", true);
                if (!_vat.Equals(value))
                {
                    _vat = value;
                    PropertyHasChanged("DonGia");
                }
            }
        }
 
		protected override object GetIdValue()
		{
			return _mactBaogia;
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
			//TODO: Define authorization rules in CT_BaoGia
			//AuthorizationRules.AllowRead("MactBaogia", "CT_BaoGiaReadGroup");
			//AuthorizationRules.AllowRead("MaBangBaoGia", "CT_BaoGiaReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "CT_BaoGiaReadGroup");
			//AuthorizationRules.AllowRead("DonGia", "CT_BaoGiaReadGroup");

			//AuthorizationRules.AllowWrite("MaBangBaoGia", "CT_BaoGiaWriteGroup");
			//AuthorizationRules.AllowWrite("MaHangHoa", "CT_BaoGiaWriteGroup");
			//AuthorizationRules.AllowWrite("DonGia", "CT_BaoGiaWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static CT_BaoGia NewCT_BaoGia()
		{
			return new CT_BaoGia();
		}

		internal static CT_BaoGia GetCT_BaoGia(SafeDataReader dr)
		{
            CT_BaoGia child = new CT_BaoGia();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
            //return new CT_BaoGia(dr);
		}

		private CT_BaoGia()
		{
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private CT_BaoGia(SafeDataReader dr)
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
			_mactBaogia = dr.GetInt32("MaCT_BaoGia");
			_maBangBaoGia = dr.GetInt32("MaBangBaoGia");
			_maHangHoa = dr.GetInt32("MaHangHoa");
            _maDonViTinh = dr.GetInt32("MaDonViTinh");
			_donGia = dr.GetDecimal("DonGia");
            _vat=dr.GetInt16("Vat");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, BangBaoGia parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			//UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, BangBaoGia parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_BaoGia";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_mactBaogia = (int)cm.Parameters["@MaCT_BaoGia"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BangBaoGia parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaBangBaoGia", parent.MaBangBaoGia);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
			cm.Parameters.AddWithValue("@DonGia", _donGia);
            cm.Parameters.AddWithValue("@Vat", _vat);
			cm.Parameters.AddWithValue("@MaCT_BaoGia", _mactBaogia);
			cm.Parameters["@MaCT_BaoGia"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, BangBaoGia parent)
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

		private void ExecuteUpdate(SqlTransaction tr, BangBaoGia parent)
		{
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdatetblCT_BaoGia";

                    AddUpdateParameters(cm, parent);

                    cm.ExecuteNonQuery();

                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		private void AddUpdateParameters(SqlCommand cm, BangBaoGia parent)
		{
			cm.Parameters.AddWithValue("@MaCT_BaoGia", _mactBaogia);
			cm.Parameters.AddWithValue("@MaBangBaoGia", parent.MaBangBaoGia);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
			cm.Parameters.AddWithValue("@DonGia", _donGia);
            cm.Parameters.AddWithValue("@Vat", _vat);
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
		//	MarkNew();
		}

		private void ExecuteDelete(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblCT_BaoGia";

				cm.Parameters.AddWithValue("@MaCT_BaoGia", this._mactBaogia);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#endregion //Data Access
	}
}
