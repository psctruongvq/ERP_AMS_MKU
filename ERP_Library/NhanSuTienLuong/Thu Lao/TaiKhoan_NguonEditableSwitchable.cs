
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TaiKhoan_Nguon : Csla.BusinessBase<TaiKhoan_Nguon>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTaiKhoanNguon = 0;
		private int _maNguon = 0;
		private int _maTaiKhoan = 0;
		private byte _noCo = 0;
        private int _maCongTy = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTaiKhoanNguon
		{
			get
			{
				return _maTaiKhoanNguon;
			}
		}

		public int MaNguon
		{
			get
			{
				return _maNguon;
			}
			set
			{
				if (!_maNguon.Equals(value))
				{
					_maNguon = value;
					PropertyHasChanged("MaNguon");
				}
			}
		}
        public int MaCongTy
        {
            get
            {
                return _maCongTy;
            }
            set
            {
                if (!_maCongTy.Equals(value))
                {
                    _maCongTy = value;
                    PropertyHasChanged("MaCongTy");
                }
            }
        }
		public int MaTaiKhoan
		{
			get
			{
				return _maTaiKhoan;
			}
			set
			{
				if (!_maTaiKhoan.Equals(value))
				{
					_maTaiKhoan = value;
					PropertyHasChanged("MaTaiKhoan");
				}
			}
		}

		public byte NoCo
		{
			get
			{
				return _noCo;
			}
			set
			{
				if (!_noCo.Equals(value))
				{
					_noCo = value;
					PropertyHasChanged("NoCo");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTaiKhoanNguon;
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

		#region Factory Methods
		private TaiKhoan_Nguon()
		{ /* require use of factory method */ }

		public static TaiKhoan_Nguon NewTaiKhoan_Nguon()
		{
            TaiKhoan_Nguon item = new TaiKhoan_Nguon();
            item.MarkAsChild();
            return item;
		}

		public static TaiKhoan_Nguon GetTaiKhoan_Nguon(int maTaiKhoanNguon)
		{
			return DataPortal.Fetch<TaiKhoan_Nguon>(new Criteria(maTaiKhoanNguon));
		}

		public static void DeleteTaiKhoan_Nguon(int maTaiKhoanNguon)
		{
			DataPortal.Delete(new Criteria(maTaiKhoanNguon));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TaiKhoan_Nguon NewTaiKhoan_NguonChild()
		{
			TaiKhoan_Nguon child = new TaiKhoan_Nguon();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TaiKhoan_Nguon GetTaiKhoan_Nguon(SafeDataReader dr)
		{
			TaiKhoan_Nguon child =  new TaiKhoan_Nguon();
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
			public int MaTaiKhoanNguon;

			public Criteria(int maTaiKhoanNguon)
			{
				this.MaTaiKhoanNguon = maTaiKhoanNguon;
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
				cm.CommandText = "SelecttblTaiKhoan_Nguon";

				cm.Parameters.AddWithValue("@MaTaiKhoanNguon", criteria.MaTaiKhoanNguon);

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
					ExecuteInsert(tr, null);

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
						ExecuteUpdate(tr, null);
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
			DataPortal_Delete(new Criteria(_maTaiKhoanNguon));
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
				cm.CommandText = "DeletetblTaiKhoan_Nguon";

				cm.Parameters.AddWithValue("@MaTaiKhoanNguon", criteria.MaTaiKhoanNguon);

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
			_maTaiKhoanNguon = dr.GetInt32("MaTaiKhoanNguon");
			_maNguon = dr.GetInt32("MaNguon");
			_maTaiKhoan = dr.GetInt32("MaTaiKhoan");
			_noCo = dr.GetByte("NoCo");
            _maCongTy = dr.GetInt32("MaCongTy");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, TaiKhoan_NguonList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, TaiKhoan_NguonList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblTaiKhoan_Nguon";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maTaiKhoanNguon = (int)cm.Parameters["@MaTaiKhoanNguon"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, TaiKhoan_NguonList parent)
        {
            _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maNguon != 0)
				cm.Parameters.AddWithValue("@MaNguon", _maNguon);
			else
				cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
			if (_maTaiKhoan != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
			
				cm.Parameters.AddWithValue("@NoCo", _noCo);
                cm.Parameters.AddWithValue("@MaCongTy",_maCongTy);
			cm.Parameters.AddWithValue("@MaTaiKhoanNguon", _maTaiKhoanNguon);
            
			cm.Parameters["@MaTaiKhoanNguon"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, TaiKhoan_NguonList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, TaiKhoan_NguonList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblTaiKhoan_Nguon";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, TaiKhoan_NguonList parent)
        {
            cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
			cm.Parameters.AddWithValue("@MaTaiKhoanNguon", _maTaiKhoanNguon);
			if (_maNguon != 0)
				cm.Parameters.AddWithValue("@MaNguon", _maNguon);
			else
				cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
			if (_maTaiKhoan != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
		
				cm.Parameters.AddWithValue("@NoCo", _noCo);
			
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

			ExecuteDelete(tr, new Criteria(_maTaiKhoanNguon));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
