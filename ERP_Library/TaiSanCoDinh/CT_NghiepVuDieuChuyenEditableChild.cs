
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_NghiepVuDieuChuyen : Csla.BusinessBase<CT_NghiepVuDieuChuyen>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChiTiet = 0;
		private int _maTSCDCaBiet = 0;
		private int _maNghiepVuDieuChuyen = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public int MaTSCDCaBiet
		{
			get
			{
				CanReadProperty("MaTSCDCaBiet", true);
				return _maTSCDCaBiet;
			}
			set
			{
				CanWriteProperty("MaTSCDCaBiet", true);
				if (!_maTSCDCaBiet.Equals(value))
				{
					_maTSCDCaBiet = value;
					PropertyHasChanged("MaTSCDCaBiet");
				}
			}
		}

		public int MaNghiepVuDieuChuyen
		{
			get
			{
				CanReadProperty("MaNghiepVuDieuChuyen", true);
				return _maNghiepVuDieuChuyen;
			}
			set
			{
				CanWriteProperty("MaNghiepVuDieuChuyen", true);
				if (!_maNghiepVuDieuChuyen.Equals(value))
				{
					_maNghiepVuDieuChuyen = value;
					PropertyHasChanged("MaNghiepVuDieuChuyen");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maChiTiet;
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
			//TODO: Define authorization rules in CT_NghiepVuDieuChuyen
			//AuthorizationRules.AllowRead("MaChiTiet", "CT_NghiepVuDieuChuyenReadGroup");
			//AuthorizationRules.AllowRead("MaTSCDCaBiet", "CT_NghiepVuDieuChuyenReadGroup");
			//AuthorizationRules.AllowRead("MaNghiepVuDieuChuyen", "CT_NghiepVuDieuChuyenReadGroup");

			//AuthorizationRules.AllowWrite("MaTSCDCaBiet", "CT_NghiepVuDieuChuyenWriteGroup");
			//AuthorizationRules.AllowWrite("MaNghiepVuDieuChuyen", "CT_NghiepVuDieuChuyenWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static CT_NghiepVuDieuChuyen NewCT_NghiepVuDieuChuyen()
		{
			return new CT_NghiepVuDieuChuyen();
		}

        public static CT_NghiepVuDieuChuyen NewCT_NghiepVuDieuChuyen(int MaTSCDCaBiet)
        {
            return new CT_NghiepVuDieuChuyen(MaTSCDCaBiet);
        }

		internal static CT_NghiepVuDieuChuyen GetCT_NghiepVuDieuChuyen(SafeDataReader dr)
		{
			return new CT_NghiepVuDieuChuyen(dr);
		}

		private CT_NghiepVuDieuChuyen()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

        private CT_NghiepVuDieuChuyen(int MaTSCDCaBiet)
        {
            _maTSCDCaBiet = MaTSCDCaBiet;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

		private CT_NghiepVuDieuChuyen(SafeDataReader dr)
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
			_maChiTiet = dr.GetInt32("MaChiTiet");
			_maTSCDCaBiet = dr.GetInt32("MaTSCDCaBiet");
			_maNghiepVuDieuChuyen = dr.GetInt32("MaNghiepVuDieuChuyen");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, DieuChuyenNoiBo parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, DieuChuyenNoiBo parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_NghiepVuDieuChuyenNoiBo";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DieuChuyenNoiBo parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maNghiepVuDieuChuyen = parent.MaNghiepVuDieuChuyen;
			if (_maTSCDCaBiet != 0)
				cm.Parameters.AddWithValue("@MaTSCDCaBiet", _maTSCDCaBiet);
			else
				cm.Parameters.AddWithValue("@MaTSCDCaBiet", DBNull.Value);
			if (_maNghiepVuDieuChuyen != 0)
				cm.Parameters.AddWithValue("@MaNghiepVuDieuChuyen", _maNghiepVuDieuChuyen);
			else
				cm.Parameters.AddWithValue("@MaNghiepVuDieuChuyen", DBNull.Value);
            cm.Parameters.AddWithValue("@MaPhongBan", parent.MaPhongBanNhan);
            cm.Parameters.AddWithValue("@NgayThucHien", parent.NgaythucHien); 
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, DieuChuyenNoiBo parent)
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

		private void ExecuteUpdate(SqlTransaction tr, DieuChuyenNoiBo parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_NghiepVuDieuChuyenNoiBo";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DieuChuyenNoiBo parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			if (_maTSCDCaBiet != 0)
				cm.Parameters.AddWithValue("@MaTSCDCaBiet", _maTSCDCaBiet);
			else
				cm.Parameters.AddWithValue("@MaTSCDCaBiet", DBNull.Value);
			if (_maNghiepVuDieuChuyen != 0)
				cm.Parameters.AddWithValue("@MaNghiepVuDieuChuyen", _maNghiepVuDieuChuyen);
			else
				cm.Parameters.AddWithValue("@MaNghiepVuDieuChuyen", DBNull.Value);
            cm.Parameters.AddWithValue("@MaPhongBan", parent.MaPhongBanNhan);
            cm.Parameters.AddWithValue("@NgayThucHien", parent.NgaythucHien); 
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
				cm.CommandText = "DeleteCT_NghiepVuDieuChuyen";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
