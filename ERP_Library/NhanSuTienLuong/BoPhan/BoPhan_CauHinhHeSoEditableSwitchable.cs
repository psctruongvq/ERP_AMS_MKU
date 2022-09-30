
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BoPhan_CauHinhHeSo : Csla.BusinessBase<BoPhan_CauHinhHeSo>
	{
		#region Business Properties and Methods

		//declare members
		private int _maCauHinh = 0;
		private int _maBoPhan = 0;
		private decimal _heSoBoSung = 0;
		private decimal _heSoDocHai = 0;
		private bool _phuCapHC = false;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaCauHinh
		{
			get
			{
				return _maCauHinh;
			}
		}

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

		public decimal HeSoBoSung
		{
			get
			{
				return _heSoBoSung;
			}
			set
			{
				if (!_heSoBoSung.Equals(value))
				{
					_heSoBoSung = value;
					PropertyHasChanged("HeSoBoSung");
				}
			}
		}

		public decimal HeSoDocHai
		{
			get
			{
				return _heSoDocHai;
			}
			set
			{
				if (!_heSoDocHai.Equals(value))
				{
					_heSoDocHai = value;
					PropertyHasChanged("HeSoDocHai");
				}
			}
		}

		public bool PhuCapHC
		{
			get
			{
				return _phuCapHC;
			}
			set
			{
				if (!_phuCapHC.Equals(value))
				{
					_phuCapHC = value;
					PropertyHasChanged("PhuCapHC");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maCauHinh;
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
		private BoPhan_CauHinhHeSo()
		{ /* require use of factory method */ }

		public static BoPhan_CauHinhHeSo NewBoPhan_CauHinhHeSo()
		{
            BoPhan_CauHinhHeSo item = new BoPhan_CauHinhHeSo();
            item.MarkAsChild();
            return item;
		}

		public static BoPhan_CauHinhHeSo GetBoPhan_CauHinhHeSo(int maCauHinh)
		{
			return DataPortal.Fetch<BoPhan_CauHinhHeSo>(new Criteria(maCauHinh));
		}

		public static void DeleteBoPhan_CauHinhHeSo(int maCauHinh)
		{
			DataPortal.Delete(new Criteria(maCauHinh));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static BoPhan_CauHinhHeSo NewBoPhan_CauHinhHeSoChild()
		{
			BoPhan_CauHinhHeSo child = new BoPhan_CauHinhHeSo();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BoPhan_CauHinhHeSo GetBoPhan_CauHinhHeSo(SafeDataReader dr)
		{
			BoPhan_CauHinhHeSo child =  new BoPhan_CauHinhHeSo();
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
			public int MaCauHinh;

			public Criteria(int maCauHinh)
			{
				this.MaCauHinh = maCauHinh;
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
				cm.CommandText = "SelecttblnsBoPhan_CauHinhHS";

				cm.Parameters.AddWithValue("@MaCauHinh", criteria.MaCauHinh);

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
			DataPortal_Delete(new Criteria(_maCauHinh));
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
				cm.CommandText = "DeletetblnsBoPhan_CauHinhHS";

				cm.Parameters.AddWithValue("@MaCauHinh", criteria.MaCauHinh);

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
			_maCauHinh = dr.GetInt32("MaCauHinh");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_heSoBoSung = dr.GetDecimal("HeSoBoSung");
			_heSoDocHai = dr.GetDecimal("HeSoDocHai");
			_phuCapHC = dr.GetBoolean("PhuCapHC");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, BoPhan_CauHinhHeSoList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, BoPhan_CauHinhHeSoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblnsBoPhan_CauHinhHS";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maCauHinh = (int)cm.Parameters["@MaCauHinh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BoPhan_CauHinhHeSoList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_heSoBoSung != 0)
				cm.Parameters.AddWithValue("@HeSoBoSung", _heSoBoSung);
			else
				cm.Parameters.AddWithValue("@HeSoBoSung", DBNull.Value);
			if (_heSoDocHai != 0)
				cm.Parameters.AddWithValue("@HeSoDocHai", _heSoDocHai);
			else
				cm.Parameters.AddWithValue("@HeSoDocHai", DBNull.Value);
			if (_phuCapHC != false)
				cm.Parameters.AddWithValue("@PhuCapHC", _phuCapHC);
			else
				cm.Parameters.AddWithValue("@PhuCapHC", DBNull.Value);
			cm.Parameters.AddWithValue("@MaCauHinh", _maCauHinh);
			cm.Parameters["@MaCauHinh"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, BoPhan_CauHinhHeSoList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, BoPhan_CauHinhHeSoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblnsBoPhan_CauHinhHS";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BoPhan_CauHinhHeSoList parent)
		{
			cm.Parameters.AddWithValue("@MaCauHinh", _maCauHinh);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_heSoBoSung != 0)
				cm.Parameters.AddWithValue("@HeSoBoSung", _heSoBoSung);
			else
				cm.Parameters.AddWithValue("@HeSoBoSung", DBNull.Value);
			if (_heSoDocHai != 0)
				cm.Parameters.AddWithValue("@HeSoDocHai", _heSoDocHai);
			else
				cm.Parameters.AddWithValue("@HeSoDocHai", DBNull.Value);
			if (_phuCapHC != false)
				cm.Parameters.AddWithValue("@PhuCapHC", _phuCapHC);
			else
				cm.Parameters.AddWithValue("@PhuCapHC", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maCauHinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
