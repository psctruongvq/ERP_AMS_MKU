
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhongBan_KHHM : Csla.BusinessBase<PhongBan_KHHM>
	{
		#region Business Properties and Methods

		//declare members
		private int _maBoPhan = 0;
		private bool _khauHaoHaoMon = false;
		private DateTime _ngayThucHien = DateTime.Today;
		private int _maNguoiThayDoi = 0;
		private int _maChiTiet = 0;

		public int MaBoPhan
		{
			get
			{
				return _maBoPhan;
			}
			set
			{
				if (!_maBoPhan.Equals(value))
				{
					_maBoPhan = value;
					PropertyHasChanged("MaBoPhan");
				}
			}
		}

		public bool KhauHaoHaoMon
		{
			get
			{
				return _khauHaoHaoMon;
			}
			set
			{
				if (!_khauHaoHaoMon.Equals(value))
				{
					_khauHaoHaoMon = value;
					PropertyHasChanged("KhauHaoHaoMon");
				}
			}
		}

		public DateTime NgayThucHien
		{
			get
			{
				return _ngayThucHien;
			}
			set
			{
				if (!_ngayThucHien.Equals(value))
				{
					_ngayThucHien = value;
					PropertyHasChanged("NgayThucHien");
				}
			}
		}

		public int MaNguoiThayDoi
		{
			get
			{
				return _maNguoiThayDoi;
			}
			set
			{
				if (!_maNguoiThayDoi.Equals(value))
				{
					_maNguoiThayDoi = value;
					PropertyHasChanged("MaNguoiThayDoi");
				}
			}
		}

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaChiTiet
		{
			get
			{
				return _maChiTiet;
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

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhongBan_KHHM
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhongBan_KHHMViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhongBan_KHHM
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhongBan_KHHMAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhongBan_KHHM
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhongBan_KHHMEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhongBan_KHHM
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhongBan_KHHMDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhongBan_KHHM()
		{ /* require use of factory method */ }

		public static PhongBan_KHHM NewPhongBan_KHHM()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhongBan_KHHM");
			return DataPortal.Create<PhongBan_KHHM>();
		}

        public static PhongBan_KHHM NewPhongBan_KHHM(int MaBoPhan, bool KhauHaoHaoMon, DateTime Ngay)
        {
            PhongBan_KHHM pb = new PhongBan_KHHM();
            pb.MaBoPhan = MaBoPhan;
            pb.KhauHaoHaoMon = KhauHaoHaoMon;
            pb.NgayThucHien = Ngay;
            return pb;
        }

		public static PhongBan_KHHM GetPhongBan_KHHM(int maChiTiet)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhongBan_KHHM");
			return DataPortal.Fetch<PhongBan_KHHM>(new Criteria(maChiTiet));
		}

		public static void DeletePhongBan_KHHM(int maChiTiet)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhongBan_KHHM");
			DataPortal.Delete(new Criteria(maChiTiet));
		}

		public override PhongBan_KHHM Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhongBan_KHHM");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhongBan_KHHM");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a PhongBan_KHHM");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static PhongBan_KHHM NewPhongBan_KHHMChild()
		{
			PhongBan_KHHM child = new PhongBan_KHHM();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhongBan_KHHM GetPhongBan_KHHM(SafeDataReader dr)
		{
			PhongBan_KHHM child =  new PhongBan_KHHM();
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
			public int MaChiTiet;

			public Criteria(int maChiTiet)
			{
				this.MaChiTiet = maChiTiet;
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
                cm.CommandText = "spd_Select_PhongBan_KHHM";

				cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
			DataPortal_Delete(new Criteria(_maChiTiet));
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
				cm.CommandText = "spd_Delete_PhongBan_KHHM";

				cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_khauHaoHaoMon = dr.GetBoolean("KhauHaoHaoMon");
			_ngayThucHien = dr.GetDateTime("NgayThucHien");
			_maNguoiThayDoi = dr.GetInt32("MaNguoiThayDoi");
			_maChiTiet = dr.GetInt32("MaChiTiet");
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
				cm.CommandText = "spd_Insert_PhongBan_KHHM";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_khauHaoHaoMon != false)
				cm.Parameters.AddWithValue("@KhauHaoHaoMon", _khauHaoHaoMon);
			else
				cm.Parameters.AddWithValue("@KhauHaoHaoMon", DBNull.Value);
			
				cm.Parameters.AddWithValue("@NgayThucHien", _ngayThucHien);
			
			if ( Security.CurrentUser.Info.UserID!= 0)
                cm.Parameters.AddWithValue("@MaNguoiThayDoi", Security.CurrentUser.Info.UserID);
			else
				cm.Parameters.AddWithValue("@MaNguoiThayDoi", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
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
				cm.CommandText = "spd_Update_PhongBan_KHHM";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_khauHaoHaoMon != false)
				cm.Parameters.AddWithValue("@KhauHaoHaoMon", _khauHaoHaoMon);
			else
				cm.Parameters.AddWithValue("@KhauHaoHaoMon", DBNull.Value);
			
			cm.Parameters.AddWithValue("@NgayThucHien", _ngayThucHien);
			
			if (_maNguoiThayDoi != 0)
				cm.Parameters.AddWithValue("@MaNguoiThayDoi", _maNguoiThayDoi);
			else
				cm.Parameters.AddWithValue("@MaNguoiThayDoi", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
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

			ExecuteDelete(tr, new Criteria(_maChiTiet));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
