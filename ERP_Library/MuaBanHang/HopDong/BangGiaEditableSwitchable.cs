
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangGia : Csla.BusinessBase<BangGia>
	{
		#region Business Properties and Methods

		//declare members
		private int _maBangGia = 0;
		private int _maHangHoa = 0;
		private SmartDate _ngayCapNhat = new SmartDate(false);
		private int _donGia = 0;
		private int _maDonViTinh = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaBangGia
		{
			get
			{
				CanReadProperty("MaBangGia", true);
				return _maBangGia;
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

        public DateTime NgayCapNhat
        {
            get
            {
                CanReadProperty(true);
                return _ngayCapNhat.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayCapNhat.Equals(value))
                {
                    _ngayCapNhat = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }
        
		public int DonGia
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

		public int MaDonViTinh
		{
			get
			{
				CanReadProperty("MaDonViTinh", true);
				return _maDonViTinh;
			}
			set
			{
				CanWriteProperty("MaDonViTinh", true);
				if (!_maDonViTinh.Equals(value))
				{
					_maDonViTinh = value;
					PropertyHasChanged("MaDonViTinh");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maBangGia;
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
			//TODO: Define authorization rules in BangGia
			//AuthorizationRules.AllowRead("MaBangGia", "BangGiaReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "BangGiaReadGroup");
			//AuthorizationRules.AllowRead("NgayCapNhat", "BangGiaReadGroup");
			//AuthorizationRules.AllowRead("NgayCapNhatString", "BangGiaReadGroup");
			//AuthorizationRules.AllowRead("DonGia", "BangGiaReadGroup");
			//AuthorizationRules.AllowRead("MaDonViTinh", "BangGiaReadGroup");

			//AuthorizationRules.AllowWrite("MaHangHoa", "BangGiaWriteGroup");
			//AuthorizationRules.AllowWrite("NgayCapNhatString", "BangGiaWriteGroup");
			//AuthorizationRules.AllowWrite("DonGia", "BangGiaWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViTinh", "BangGiaWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangGia
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangGiaViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangGia
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangGiaAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangGia
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangGiaEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangGia
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangGiaDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangGia()
		{ /* require use of factory method */ }

		public static BangGia NewBangGia()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangGia");
			return DataPortal.Create<BangGia>();
		}

		public static BangGia GetBangGia(int maBangGia)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangGia");
			return DataPortal.Fetch<BangGia>(new Criteria(maBangGia));
		}

		public static void DeleteBangGia(int maBangGia)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangGia");
			DataPortal.Delete(new Criteria(maBangGia));
		}

		public override BangGia Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangGia");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangGia");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BangGia");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static BangGia NewBangGiaChild()
		{
			BangGia child = new BangGia();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BangGia GetBangGia(SafeDataReader dr)
		{
			BangGia child =  new BangGia();
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
			public int MaBangGia;

			public Criteria(int maBangGia)
			{
				this.MaBangGia = maBangGia;
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
                cm.CommandText = "spd_SelecttblBangGia";

				cm.Parameters.AddWithValue("@MaBangGia", criteria.MaBangGia);

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
			DataPortal_Delete(new Criteria(_maBangGia));
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
                cm.CommandText = "spd_DeletetblBangGia";

				cm.Parameters.AddWithValue("@MaBangGia", criteria.MaBangGia);

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
			_maBangGia = dr.GetInt32("MaBangGia");
			_maHangHoa = dr.GetInt32("MaHangHoa");
			_ngayCapNhat = dr.GetSmartDate("NgayCapNhat", _ngayCapNhat.EmptyIsMin);
			_donGia = dr.GetInt32("DonGia");
			_maDonViTinh = dr.GetInt32("MaDonViTinh");
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
                cm.CommandText = "spd_InserttblBangGia";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maBangGia = (int)cm.Parameters["@MaBangGia"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayCapNhat", _ngayCapNhat.DBValue);
			if (_donGia != 0)
				cm.Parameters.AddWithValue("@DonGia", _donGia);
			else
				cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
			if (_maDonViTinh != 0)
				cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
			else
				cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
			cm.Parameters.AddWithValue("@MaBangGia", _maBangGia);
			cm.Parameters["@MaBangGia"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblBangGia";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaBangGia", _maBangGia);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayCapNhat", _ngayCapNhat.DBValue);
			if (_donGia != 0)
				cm.Parameters.AddWithValue("@DonGia", _donGia);
			else
				cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
			if (_maDonViTinh != 0)
				cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
			else
				cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maBangGia));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
