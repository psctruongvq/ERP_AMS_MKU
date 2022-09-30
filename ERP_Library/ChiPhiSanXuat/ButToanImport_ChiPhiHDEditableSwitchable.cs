
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ButToanImport_ChiPhiHD : Csla.BusinessBase<ButToanImport_ChiPhiHD>
	{
		#region Business Properties and Methods

		//declare members
		private long _maButToanCPHD = 0;
		private int _maChiPhiHD = 0;
		private string _tenChiPhiHD = string.Empty;
		private int _maButToan = 0;
		private decimal _soTien = 0;
		private DateTime _ngayLap = DateTime.Today.Date;
		private int _nguoiLap = 0;
		private int _maBoPhan = 0;
		private string _tenBoPhan = string.Empty;
        private bool _thuChi = false;
        private string _tenButToan = string.Empty;

        public string TenButToan
        {
            get { return _tenButToan; }
            set { _tenButToan = value; }
        }
        private int _maCongTy = 0;
		[System.ComponentModel.DataObjectField(true, true)]
        /// <summary>
        /// True: Thu; False: Chi
        /// </summary>
        public bool ThuChi
        {
            get { return _thuChi; }
            set { _thuChi = value; PropertyHasChanged("ThuChi"); }
        }
		public long MaButToanCPHD
		{
			get
			{
				return _maButToanCPHD;
			}
		}

		public int MaChiPhiHD
		{
			get
			{
				return _maChiPhiHD;
			}
			set
			{
				if (!_maChiPhiHD.Equals(value))
				{
					_maChiPhiHD = value;
					PropertyHasChanged("MaChiPhiHD");
				}
			}
		}

		public string TenChiPhiHD
		{
			get
			{
				return _tenChiPhiHD;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenChiPhiHD.Equals(value))
				{
					_tenChiPhiHD = value;
					PropertyHasChanged("TenChiPhiHD");
				}
			}
		}

		public int MaButToan
		{
			get
			{
				return _maButToan;
			}
			set
			{
				if (!_maButToan.Equals(value))
				{
					_maButToan = value;
					PropertyHasChanged("MaButToan");
				}
			}
		}

		public decimal SoTien
		{
			get
			{
				return _soTien;
			}
			set
			{
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
				}
			}
		}

		public DateTime NgayLap
		{
			get
			{
				return _ngayLap;
			}
			set
			{
				if (!_ngayLap.Equals(value))
				{
					_ngayLap = value;
					PropertyHasChanged("NgayLap");
				}
			}
		}

		public int NguoiLap
		{
			get
			{
				return _nguoiLap;
			}
			set
			{
				if (!_nguoiLap.Equals(value))
				{
					_nguoiLap = value;
					PropertyHasChanged("NguoiLap");
				}
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

		public string TenBoPhan
		{
			get
			{
				return _tenBoPhan;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenBoPhan.Equals(value))
				{
					_tenBoPhan = value;
					PropertyHasChanged("TenBoPhan");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maButToanCPHD;
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
			// TenChiPhiHD
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChiPhiHD", 2000));
			//
			// TenBoPhan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 200));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private ButToanImport_ChiPhiHD()
		{ /* require use of factory method */ }

		public static ButToanImport_ChiPhiHD NewButToanImport_ChiPhiHD()
		{
			return DataPortal.Create<ButToanImport_ChiPhiHD>();
		}

		public static ButToanImport_ChiPhiHD GetButToanImport_ChiPhiHD(long maButToanCPHD)
		{
			return DataPortal.Fetch<ButToanImport_ChiPhiHD>(new Criteria(maButToanCPHD));
		}
        public static ButToanImport_ChiPhiHD GetButToanImport_ChiPhiHDByButToan(int maButToan)
        {
            return DataPortal.Fetch<ButToanImport_ChiPhiHD>(new FilterCriteriaButToan(maButToan));
        }
		public static void DeleteButToanImport_ChiPhiHD(long maButToanCPHD)
		{
			DataPortal.Delete(new Criteria(maButToanCPHD));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ButToanImport_ChiPhiHD NewButToanImport_ChiPhiHDChild()
		{
			ButToanImport_ChiPhiHD child = new ButToanImport_ChiPhiHD();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ButToanImport_ChiPhiHD GetButToanImport_ChiPhiHD(SafeDataReader dr)
		{
			ButToanImport_ChiPhiHD child =  new ButToanImport_ChiPhiHD();
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
			public long MaButToanCPHD;

			public Criteria(long maButToanCPHD)
			{
				this.MaButToanCPHD = maButToanCPHD;
			}
		}
        private class FilterCriteriaButToan
        {
            public long MaButToan;

            public FilterCriteriaButToan(long maButToan)
            {
                this.MaButToan = maButToan;
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
		private void DataPortal_Fetch(object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "SelecttblButToanImport_ChiPhiHD";
                    cm.Parameters.AddWithValue("@MaButToanCPHD",((Criteria)criteria).MaButToanCPHD);
                }
                else if (criteria is FilterCriteriaButToan)
                {
                    cm.CommandText = "SelecttblButToanImport_ChiPhiHDByButToan";
                    cm.Parameters.AddWithValue("@MaButToan", ((FilterCriteriaButToan)criteria).MaButToan);
                }
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
   
    
		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maButToanCPHD));
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
                cm.CommandText = "DeletetblButToanImport_ChiPhiHD";

				cm.Parameters.AddWithValue("@MaButToanCPHD", criteria.MaButToanCPHD);

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
			_maButToanCPHD = dr.GetInt32("MaButToanCPHD");
			_maChiPhiHD = dr.GetInt32("MaChiPhiHD");
			_tenChiPhiHD = dr.GetString("TenChiPhiHD");
			_maButToan = dr.GetInt32("MaButToan");
			_soTien = dr.GetDecimal("SoTien");
			_ngayLap = dr.GetDateTime("NgayLap");
			_nguoiLap = dr.GetInt32("NguoiLap");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_tenBoPhan = dr.GetString("TenBoPhan");
            _tenButToan = dr.GetString("TenButToan");
            _thuChi = dr.GetBoolean("ThuChi");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
        public void Insert(SqlTransaction tr, ButToanImport butToan)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, butToan);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, ButToanImport butToan)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "InserttblButToanImport_ChiPhiHD";

				AddInsertParameters(cm, butToan);

				cm.ExecuteNonQuery();

				_maButToanCPHD = (long)cm.Parameters["@MaButToanCPHD"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, ButToanImport butToan)
		{          
            
            _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            _tenBoPhan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;
            cm.Parameters.AddWithValue("@MaCongTy",ERP_Library.Security.CurrentUser.Info.MaCongTy);
			if (_maChiPhiHD != 0)
				cm.Parameters.AddWithValue("@MaChiPhiHD", _maChiPhiHD);
			else
				cm.Parameters.AddWithValue("@MaChiPhiHD", DBNull.Value);
			if (_tenChiPhiHD.Length > 0)
				cm.Parameters.AddWithValue("@TenChiPhiHD", _tenChiPhiHD);
			else
				cm.Parameters.AddWithValue("@TenChiPhiHD", DBNull.Value);
			if (butToan.MaButToan != 0)
                cm.Parameters.AddWithValue("@MaButToan", butToan.MaButToan);
			else
				cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
            if (butToan.SoTien != 0)
                cm.Parameters.AddWithValue("@SoTien", butToan.SoTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
				cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
				if (_nguoiLap != 0)
					cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
				else
					cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
				if (_maBoPhan != 0)
					cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
				else
					cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
				if (_tenBoPhan.Length > 0)
					cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
				else
					cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
                cm.Parameters.AddWithValue("@ThuChi", _thuChi);
			cm.Parameters.AddWithValue("@MaButToanCPHD", _maButToanCPHD);
			cm.Parameters["@MaButToanCPHD"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        public void Update(SqlTransaction tr, ButToanImport butToan)
		{
			
				ExecuteUpdate(tr, butToan);
				MarkOld();
		

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteUpdate(SqlTransaction tr, ButToanImport butToan)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdatetblButToanImport_ChiPhiHD";

				AddUpdateParameters(cm, butToan);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, ButToanImport butToan)
		{
            _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            _tenBoPhan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;
			cm.Parameters.AddWithValue("@MaButToanCPHD", _maButToanCPHD);
			if (_maChiPhiHD != 0)
				cm.Parameters.AddWithValue("@MaChiPhiHD", _maChiPhiHD);
			else
				cm.Parameters.AddWithValue("@MaChiPhiHD", DBNull.Value);
			if (_tenChiPhiHD.Length > 0)
				cm.Parameters.AddWithValue("@TenChiPhiHD", _tenChiPhiHD);
			else
				cm.Parameters.AddWithValue("@TenChiPhiHD", DBNull.Value);
            if (butToan.MaButToan != 0)
                cm.Parameters.AddWithValue("@MaButToan", butToan.MaButToan);
            else
                cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
            if (butToan.SoTien != 0)
                cm.Parameters.AddWithValue("@SoTien", butToan.SoTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongTy",ERP_Library.Security.CurrentUser.Info.MaCongTy);
            cm.Parameters.AddWithValue("@ThuChi",_thuChi);
		}
        public void Update(SqlTransaction tr)
        {

            ExecuteUpdate(tr);
            MarkOld();


            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdatetblButToanImport_ChiPhiHDByMaChiPhi";
                cm.Parameters.AddWithValue("@ThuChi", _thuChi);
                if (_maChiPhiHD != 0)
                    cm.Parameters.AddWithValue("@MaChiPhiHD", _maChiPhiHD);
                else
                    cm.Parameters.AddWithValue("@MaChiPhiHD", DBNull.Value);
                cm.Parameters.AddWithValue("@MaButToanCPHD", _maButToanCPHD);
                cm.ExecuteNonQuery();

            }//using
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

			ExecuteDelete(tr, new Criteria(_maButToanCPHD));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
