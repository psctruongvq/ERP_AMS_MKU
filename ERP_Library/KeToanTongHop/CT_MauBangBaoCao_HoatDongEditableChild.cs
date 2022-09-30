
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_MauBangBaoCao_HoatDong : Csla.BusinessBase<CT_MauBangBaoCao_HoatDong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChiTiet = 0;
		private int _maChiTietMuc = 0;
		private int _maHoatDong = 0;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public int MaChiTietMuc
		{
			get
			{
				CanReadProperty("MaChiTietMuc", true);
				return _maChiTietMuc;
			}
			set
			{
				CanWriteProperty("MaChiTietMuc", true);
				if (!_maChiTietMuc.Equals(value))
				{
					_maChiTietMuc = value;
					PropertyHasChanged("MaChiTietMuc");
				}
			}
		}

		public int MaHoatDong
		{
			get
			{
				CanReadProperty("MaHoatDong", true);
				return _maHoatDong;
			}
			set
			{
				CanWriteProperty("MaHoatDong", true);
				if (!_maHoatDong.Equals(value))
				{
					_maHoatDong = value;
					PropertyHasChanged("MaHoatDong");
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
			//TODO: Define authorization rules in CT_MauBangBaoCao_HoatDong
			//AuthorizationRules.AllowRead("MaChiTiet", "CT_MauBangBaoCao_HoatDongReadGroup");
			//AuthorizationRules.AllowRead("MaChiTietMuc", "CT_MauBangBaoCao_HoatDongReadGroup");
			//AuthorizationRules.AllowRead("MaHoatDong", "CT_MauBangBaoCao_HoatDongReadGroup");

			//AuthorizationRules.AllowWrite("MaChiTietMuc", "CT_MauBangBaoCao_HoatDongWriteGroup");
			//AuthorizationRules.AllowWrite("MaHoatDong", "CT_MauBangBaoCao_HoatDongWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static CT_MauBangBaoCao_HoatDong NewCT_MauBangBaoCao_HoatDong(int maChiTiet)
		{
			return new CT_MauBangBaoCao_HoatDong(maChiTiet);
		}

        public static CT_MauBangBaoCao_HoatDong NewCT_MauBangBaoCao_HoatDong(CT_MauBangBaoCao_HoatDong ctcopy)
        {
            return new CT_MauBangBaoCao_HoatDong(ctcopy);
        }

		internal static CT_MauBangBaoCao_HoatDong GetCT_MauBangBaoCao_HoatDong(SafeDataReader dr)
		{
			return new CT_MauBangBaoCao_HoatDong(dr);
		}

		private CT_MauBangBaoCao_HoatDong(int maChiTiet)
		{
			this._maChiTiet = maChiTiet;
			ValidationRules.CheckRules();
			MarkAsChild();
		}

        private CT_MauBangBaoCao_HoatDong(CT_MauBangBaoCao_HoatDong ctcopy)
        {
            this._maHoatDong = ctcopy.MaHoatDong;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

		private CT_MauBangBaoCao_HoatDong(SafeDataReader dr)
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
			_maChiTietMuc = dr.GetInt32("MaChiTietMuc");
			_maHoatDong = dr.GetInt32("MaHoatDong");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, CT_MauBangBaoCao parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, CT_MauBangBaoCao parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_MauBangBaoCao_HoatDong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, CT_MauBangBaoCao parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maChiTietMuc = parent.MaChiTiet;
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			if (_maChiTietMuc != 0)
				cm.Parameters.AddWithValue("@MaChiTietMuc", _maChiTietMuc);
			else
				cm.Parameters.AddWithValue("@MaChiTietMuc", DBNull.Value);
			if (_maHoatDong != 0)
				cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
			else
				cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, CT_MauBangBaoCao parent)
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

		private void ExecuteUpdate(SqlTransaction tr, CT_MauBangBaoCao parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_MauBangBaoCao_HoatDong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, CT_MauBangBaoCao parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			if (_maChiTietMuc != 0)
				cm.Parameters.AddWithValue("@MaChiTietMuc", _maChiTietMuc);
			else
				cm.Parameters.AddWithValue("@MaChiTietMuc", DBNull.Value);
			if (_maHoatDong != 0)
				cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
			else
				cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_MauBangBaoCao_HoatDong";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
