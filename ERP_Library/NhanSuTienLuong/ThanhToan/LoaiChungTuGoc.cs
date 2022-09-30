using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.ThanhToan
{ 
	[Serializable()] 
	public class LoaiChungTuGoc : Csla.BusinessBase<LoaiChungTuGoc>
	{
		#region Business Properties and Methods

		//declare members
		internal int _maLoaiChungTu = 0;
		private string _tenLoai = string.Empty;
		private string _maPhanHe = string.Empty;
        private int _stt = 0;
        private string _tenForm = "";

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaLoaiChungTu
		{
			get
			{
				return _maLoaiChungTu;
			}
		}

		public string TenLoai
		{
			get
			{
				return _tenLoai;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenLoai.Equals(value))
				{
					_tenLoai = value;
					PropertyHasChanged("TenLoai");
				}
			}
		}

		public string MaPhanHe
		{
			get
			{
				return _maPhanHe;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maPhanHe.Equals(value))
				{
					_maPhanHe = value;
					PropertyHasChanged("MaPhanHe");
				}
			}
		}

        public int STT
        {
            get
            {
                return _stt;
            }
            set
            {
                if (!_stt.Equals(value))
                {
                    _stt = value;
                    PropertyHasChanged();
                }
            }
        }

        public string TenForm
        {
            get
            {
                return _tenForm;
            }
            set
            {
                if (!_tenForm.Equals(value))
                {
                    _tenForm = value;
                    PropertyHasChanged();
                }
            }
        }
 
		protected override object GetIdValue()
		{
			return _maLoaiChungTu;
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
			// TenLoai
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenLoai");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoai", 100));
			//
			// MaPhanHe
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "MaPhanHe");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaPhanHe", 50));
            //
            // TenForm
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenForm");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenForm", 50));
        }

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		public LoaiChungTuGoc()
		{ /* require use of factory method */ }

		public static LoaiChungTuGoc NewLoaiChungTuGoc(int maLoaiChungTu)
		{
			return DataPortal.Create<LoaiChungTuGoc>(new Criteria(maLoaiChungTu));
		}

		public static LoaiChungTuGoc GetLoaiChungTuGoc(int maLoaiChungTu)
		{
			return DataPortal.Fetch<LoaiChungTuGoc>(new Criteria(maLoaiChungTu));
		}

		public static void DeleteLoaiChungTuGoc(int maLoaiChungTu)
		{
			DataPortal.Delete(new Criteria(maLoaiChungTu));
		}

		#endregion //Factory Methods

		#region Child Factory Methods

		internal static LoaiChungTuGoc NewLoaiChungTuGocChild()
		{
			LoaiChungTuGoc child = new LoaiChungTuGoc();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiChungTuGoc GetLoaiChungTuGoc(SafeDataReader dr)
		{
			LoaiChungTuGoc child =  new LoaiChungTuGoc();
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
			public int MaLoaiChungTu;

			public Criteria(int maLoaiChungTu)
			{
				this.MaLoaiChungTu = maLoaiChungTu;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maLoaiChungTu = criteria.MaLoaiChungTu;
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
				cm.CommandText = "spd_Select_LoaiChungTuGoc";

				cm.Parameters.AddWithValue("@MaLoaiChungTu", criteria.MaLoaiChungTu);

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
			DataPortal_Delete(new Criteria(_maLoaiChungTu));
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
				cm.CommandText = "spd_Delete_LoaiChungTuGoc";

				cm.Parameters.AddWithValue("@MaLoaiChungTu", criteria.MaLoaiChungTu);

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
			_maLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
			_tenLoai = dr.GetString("TenLoai");
			_maPhanHe = dr.GetString("MaPhanHe");
            _stt = dr.GetInt32("STT");
            _tenForm = dr.GetString("TenForm");
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
				cm.CommandText = "spd_Insert_LoaiChungTuGoc";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
			cm.Parameters.AddWithValue("@TenLoai", _tenLoai);
			cm.Parameters.AddWithValue("@MaPhanHe", _maPhanHe);
            cm.Parameters.AddWithValue("@STT", _stt);
            cm.Parameters.AddWithValue("@TenForm", _tenForm);
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
				cm.CommandText = "spd_Update_LoaiChungTuGoc";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
			cm.Parameters.AddWithValue("@TenLoai", _tenLoai);
			cm.Parameters.AddWithValue("@MaPhanHe", _maPhanHe);
            cm.Parameters.AddWithValue("@STT", _stt);
            cm.Parameters.AddWithValue("@TenForm", _tenForm);
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

			ExecuteDelete(tr, new Criteria(_maLoaiChungTu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
