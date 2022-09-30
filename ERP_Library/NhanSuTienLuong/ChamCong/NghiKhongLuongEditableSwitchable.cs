
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NghiKhongLuong : Csla.BusinessBase<NghiKhongLuong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNghiKhongLuong = 0;
		private long _maNhanVien = 0;
		private int _tuKy = 0;
		private int _denKy = 0;
		private string _dienGiai = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNghiKhongLuong
		{
			get
			{
				return _maNghiKhongLuong;
			}
		}

		public long MaNhanVien
		{
			get
			{
				return _maNhanVien;
			}
			set
			{
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public int TuKy
		{
			get
			{
				return _tuKy;
			}
			set
			{
				if (!_tuKy.Equals(value))
				{
					_tuKy = value;
					PropertyHasChanged("TuKy");
				}
			}
		}

		public int DenKy
		{
			get
			{
				return _denKy;
			}
			set
			{
				if (!_denKy.Equals(value))
				{
					_denKy = value;
					PropertyHasChanged("DenKy");
				}
			}
		}

		public string DienGiai
		{
			get
			{
				return _dienGiai;
			}
			set
			{
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
			return _maNghiKhongLuong;
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
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 2000));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private NghiKhongLuong()
		{ /* require use of factory method */ }

		public static NghiKhongLuong NewNghiKhongLuong()
		{
			return DataPortal.Create<NghiKhongLuong>();
		}

		public static NghiKhongLuong GetNghiKhongLuong(int maNghiKhongLuong)
		{
			return DataPortal.Fetch<NghiKhongLuong>(new Criteria(maNghiKhongLuong));
		}

		public static void DeleteNghiKhongLuong(int maNghiKhongLuong)
		{
			DataPortal.Delete(new Criteria(maNghiKhongLuong));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NghiKhongLuong NewNghiKhongLuongChild()
		{
			NghiKhongLuong child = new NghiKhongLuong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NghiKhongLuong GetNghiKhongLuong(SafeDataReader dr)
		{
			NghiKhongLuong child =  new NghiKhongLuong();
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
			public int MaNghiKhongLuong;

			public Criteria(int maNghiKhongLuong)
			{
				this.MaNghiKhongLuong = maNghiKhongLuong;
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
				cm.CommandText = "GetNghiKhongLuong";

				cm.Parameters.AddWithValue("@MaNghiKhongLuong", criteria.MaNghiKhongLuong);

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
			DataPortal_Delete(new Criteria(_maNghiKhongLuong));
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
                cm.CommandText = "[spd_DeletetblnsNghiKhongLuong]";

				cm.Parameters.AddWithValue("@MaNghiKhongLuong", criteria.MaNghiKhongLuong);

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
			_maNghiKhongLuong = dr.GetInt32("MaNghiKhongLuong");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tuKy = dr.GetInt32("TuKy");
			_denKy = dr.GetInt32("DenKy");
			_dienGiai = dr.GetString("DienGiai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, NghiKhongLuongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, NghiKhongLuongList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_InserttblnsNghiKhongLuong]";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maNghiKhongLuong = (int)cm.Parameters["@MaNghiKhongLuong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NghiKhongLuongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@TuKy", _tuKy);
			cm.Parameters.AddWithValue("@DenKy", _denKy);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNghiKhongLuong", _maNghiKhongLuong);
			cm.Parameters["@MaNghiKhongLuong"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, NghiKhongLuongList parent)
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

		private void ExecuteUpdate(SqlConnection cn, NghiKhongLuongList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_UpdatetblnsNghiKhongLuong]";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NghiKhongLuongList parent)
		{
			cm.Parameters.AddWithValue("@MaNghiKhongLuong", _maNghiKhongLuong);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@TuKy", _tuKy);
			cm.Parameters.AddWithValue("@DenKy", _denKy);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maNghiKhongLuong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
