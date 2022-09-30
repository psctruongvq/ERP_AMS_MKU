
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HopDongChoVay : Csla.BusinessBase<HopDongChoVay>
	{
		#region Business Properties and Methods

		//declare members
		private long _maHopDong = 0;
		private string _soHopDong = string.Empty;
		private int _maPhuongPhapTinhLai = 0;
		private int _kyHanThanhToan = 0;
		private int _maDonViKyHanTT = 0;
		private int _kyTinhLai = 0;
		private int _maDonViKyTinhLai = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaHopDong
		{
			get
			{
				CanReadProperty("MaHopDong", true);
				return _maHopDong;
			}
		}

		public string SoHopDong
		{
			get
			{
				CanReadProperty("SoHopDong", true);
				return _soHopDong;
			}
			set
			{
				CanWriteProperty("SoHopDong", true);
				if (value == null) value = string.Empty;
				if (!_soHopDong.Equals(value))
				{
					_soHopDong = value;
					PropertyHasChanged("SoHopDong");
				}
			}
		}

		public int MaPhuongPhapTinhLai
		{
			get
			{
				CanReadProperty("MaPhuongPhapTinhLai", true);
				return _maPhuongPhapTinhLai;
			}
			set
			{
				CanWriteProperty("MaPhuongPhapTinhLai", true);
				if (!_maPhuongPhapTinhLai.Equals(value))
				{
					_maPhuongPhapTinhLai = value;
					PropertyHasChanged("MaPhuongPhapTinhLai");
				}
			}
		}

		public int KyHanThanhToan
		{
			get
			{
				CanReadProperty("KyHanThanhToan", true);
				return _kyHanThanhToan;
			}
			set
			{
				CanWriteProperty("KyHanThanhToan", true);
				if (!_kyHanThanhToan.Equals(value))
				{
					_kyHanThanhToan = value;
					PropertyHasChanged("KyHanThanhToan");
				}
			}
		}

		public int MaDonViKyHanTT
		{
			get
			{
				CanReadProperty("MaDonViKyHanTT", true);
				return _maDonViKyHanTT;
			}
			set
			{
				CanWriteProperty("MaDonViKyHanTT", true);
				if (!_maDonViKyHanTT.Equals(value))
				{
					_maDonViKyHanTT = value;
					PropertyHasChanged("MaDonViKyHanTT");
				}
			}
		}

		public int KyTinhLai
		{
			get
			{
				CanReadProperty("KyTinhLai", true);
				return _kyTinhLai;
			}
			set
			{
				CanWriteProperty("KyTinhLai", true);
				if (!_kyTinhLai.Equals(value))
				{
					_kyTinhLai = value;
					PropertyHasChanged("KyTinhLai");
				}
			}
		}

		public int MaDonViKyTinhLai
		{
			get
			{
				CanReadProperty("MaDonViKyTinhLai", true);
				return _maDonViKyTinhLai;
			}
			set
			{
				CanWriteProperty("MaDonViKyTinhLai", true);
				if (!_maDonViKyTinhLai.Equals(value))
				{
					_maDonViKyTinhLai = value;
					PropertyHasChanged("MaDonViKyTinhLai");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maHopDong;
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
			// SoHopDong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHopDong", 20));
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
			//TODO: Define authorization rules in HopDongChoVay
			//AuthorizationRules.AllowRead("MaHopDong", "HopDongChoVayReadGroup");
			//AuthorizationRules.AllowRead("SoHopDong", "HopDongChoVayReadGroup");
			//AuthorizationRules.AllowRead("MaPhuongPhapTinhLai", "HopDongChoVayReadGroup");
			//AuthorizationRules.AllowRead("KyHanThanhToan", "HopDongChoVayReadGroup");
			//AuthorizationRules.AllowRead("MaDonViKyHanTT", "HopDongChoVayReadGroup");
			//AuthorizationRules.AllowRead("KyTinhLai", "HopDongChoVayReadGroup");
			//AuthorizationRules.AllowRead("MaDonViKyTinhLai", "HopDongChoVayReadGroup");

			//AuthorizationRules.AllowWrite("SoHopDong", "HopDongChoVayWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhuongPhapTinhLai", "HopDongChoVayWriteGroup");
			//AuthorizationRules.AllowWrite("KyHanThanhToan", "HopDongChoVayWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViKyHanTT", "HopDongChoVayWriteGroup");
			//AuthorizationRules.AllowWrite("KyTinhLai", "HopDongChoVayWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViKyTinhLai", "HopDongChoVayWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HopDongChoVay
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongChoVayViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HopDongChoVay
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongChoVayAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HopDongChoVay
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongChoVayEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HopDongChoVay
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongChoVayDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HopDongChoVay()
		{ /* require use of factory method */ }

		public static HopDongChoVay NewHopDongChoVay()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HopDongChoVay");
			return DataPortal.Create<HopDongChoVay>();
		}

		public static HopDongChoVay GetHopDongChoVay(long maHopDong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HopDongChoVay");
			return DataPortal.Fetch<HopDongChoVay>(new Criteria(maHopDong));
		}

		public static void DeleteHopDongChoVay(long maHopDong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HopDongChoVay");
			DataPortal.Delete(new Criteria(maHopDong));
		}

		public override HopDongChoVay Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HopDongChoVay");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HopDongChoVay");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HopDongChoVay");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HopDongChoVay NewHopDongChoVayChild()
		{
			HopDongChoVay child = new HopDongChoVay();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HopDongChoVay GetHopDongChoVay(SafeDataReader dr)
		{
			HopDongChoVay child =  new HopDongChoVay();
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
			public long MaHopDong;

			public Criteria(long maHopDong)
			{
				this.MaHopDong = maHopDong;
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
				cm.CommandText = "GetHopDongChoVay";

				cm.Parameters.AddWithValue("@MaHopDong", criteria.MaHopDong);

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
			DataPortal_Delete(new Criteria(_maHopDong));
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
				cm.CommandText = "DeleteHopDongChoVay";

				cm.Parameters.AddWithValue("@MaHopDong", criteria.MaHopDong);

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
			_maHopDong = dr.GetInt64("MaHopDong");
			_soHopDong = dr.GetString("SoHopDong");
			_maPhuongPhapTinhLai = dr.GetInt32("MaPhuongPhapTinhLai");
			_kyHanThanhToan = dr.GetInt32("KyHanThanhToan");
			_maDonViKyHanTT = dr.GetInt32("MaDonViKyHanTT");
			_kyTinhLai = dr.GetInt32("KyTinhLai");
			_maDonViKyTinhLai = dr.GetInt32("MaDonViKyTinhLai");
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
				cm.CommandText = "AddHopDongChoVay";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maHopDong = (long)cm.Parameters["@NewMaHopDong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_soHopDong.Length > 0)
				cm.Parameters.AddWithValue("@SoHopDong", _soHopDong);
			else
				cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);
			if (_maPhuongPhapTinhLai != 0)
				cm.Parameters.AddWithValue("@MaPhuongPhapTinhLai", _maPhuongPhapTinhLai);
			else
				cm.Parameters.AddWithValue("@MaPhuongPhapTinhLai", DBNull.Value);
			if (_kyHanThanhToan != 0)
				cm.Parameters.AddWithValue("@KyHanThanhToan", _kyHanThanhToan);
			else
				cm.Parameters.AddWithValue("@KyHanThanhToan", DBNull.Value);
			if (_maDonViKyHanTT != 0)
				cm.Parameters.AddWithValue("@MaDonViKyHanTT", _maDonViKyHanTT);
			else
				cm.Parameters.AddWithValue("@MaDonViKyHanTT", DBNull.Value);
			if (_kyTinhLai != 0)
				cm.Parameters.AddWithValue("@KyTinhLai", _kyTinhLai);
			else
				cm.Parameters.AddWithValue("@KyTinhLai", DBNull.Value);
			if (_maDonViKyTinhLai != 0)
				cm.Parameters.AddWithValue("@MaDonViKyTinhLai", _maDonViKyTinhLai);
			else
				cm.Parameters.AddWithValue("@MaDonViKyTinhLai", DBNull.Value);
			cm.Parameters.AddWithValue("@NewMaHopDong", _maHopDong);
			cm.Parameters["@NewMaHopDong"].Direction = ParameterDirection.Output;
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
				cm.CommandText = "UpdateHopDongChoVay";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
			if (_soHopDong.Length > 0)
				cm.Parameters.AddWithValue("@SoHopDong", _soHopDong);
			else
				cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);
			if (_maPhuongPhapTinhLai != 0)
				cm.Parameters.AddWithValue("@MaPhuongPhapTinhLai", _maPhuongPhapTinhLai);
			else
				cm.Parameters.AddWithValue("@MaPhuongPhapTinhLai", DBNull.Value);
			if (_kyHanThanhToan != 0)
				cm.Parameters.AddWithValue("@KyHanThanhToan", _kyHanThanhToan);
			else
				cm.Parameters.AddWithValue("@KyHanThanhToan", DBNull.Value);
			if (_maDonViKyHanTT != 0)
				cm.Parameters.AddWithValue("@MaDonViKyHanTT", _maDonViKyHanTT);
			else
				cm.Parameters.AddWithValue("@MaDonViKyHanTT", DBNull.Value);
			if (_kyTinhLai != 0)
				cm.Parameters.AddWithValue("@KyTinhLai", _kyTinhLai);
			else
				cm.Parameters.AddWithValue("@KyTinhLai", DBNull.Value);
			if (_maDonViKyTinhLai != 0)
				cm.Parameters.AddWithValue("@MaDonViKyTinhLai", _maDonViKyTinhLai);
			else
				cm.Parameters.AddWithValue("@MaDonViKyTinhLai", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maHopDong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
