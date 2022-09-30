
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_MucTMBCTaiChinh : Csla.BusinessBase<CT_MucTMBCTaiChinh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maMucCapHai = 0;
		private int _maMucCapMot = 0;
		private string _tenMucCapHai = string.Empty;
		private string _dienGiai = string.Empty;
		private int _maSo = 0;
		private byte _capMuc = 0;
		private int _maMucCha = 0;
		private int _loaiTinh = 0;
        private int _soTTTinhToan= 0;

        private byte _isNHNN = 0;
        private int _maThongTu = 0;
        private int _maMucCapHaiDoiUng = 0;

        private bool _LayTheoLuyKe = false;

		//declare child member(s)
		private CT_CongThucTMBCTaiChinhList _cT_CongThucTMBCTaiChinhList = CT_CongThucTMBCTaiChinhList.NewCT_CongThucTMBCTaiChinhList();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaMucCapHai
		{
			get
			{
				CanReadProperty("MaMucCapHai", true);
				return _maMucCapHai;
			}
		}

		public int MaMucCapMot
		{
			get
			{
				CanReadProperty("MaMucCapMot", true);
				return _maMucCapMot;
			}
			set
			{
				CanWriteProperty("MaMucCapMot", true);
				if (!_maMucCapMot.Equals(value))
				{
					_maMucCapMot = value;
					PropertyHasChanged("MaMucCapMot");
				}
			}
		}

		public string TenMucCapHai
		{
			get
			{
				CanReadProperty("TenMucCapHai", true);
				return _tenMucCapHai;
			}
			set
			{
				CanWriteProperty("TenMucCapHai", true);
				if (value == null) value = string.Empty;
				if (!_tenMucCapHai.Equals(value))
				{
					_tenMucCapHai = value;
					PropertyHasChanged("TenMucCapHai");
				}
			}
		}

		public string DienGiai
		{
			get
			{
				CanReadProperty("DienGiai", true);
				return _dienGiai;
			}
			set
			{
				CanWriteProperty("DienGiai", true);
				if (value == null) value = string.Empty;
				if (!_dienGiai.Equals(value))
				{
					_dienGiai = value;
					PropertyHasChanged("DienGiai");
				}
			}
		}

		public int MaSo
		{
			get
			{
				CanReadProperty("MaSo", true);
				return _maSo;
			}
			set
			{
				CanWriteProperty("MaSo", true);
				if (!_maSo.Equals(value))
				{
					_maSo = value;
					PropertyHasChanged("MaSo");
				}
			}
		}

		public byte CapMuc
		{
			get
			{
				CanReadProperty("CapMuc", true);
				return _capMuc;
			}
			set
			{
				CanWriteProperty("CapMuc", true);
				if (!_capMuc.Equals(value))
				{
					_capMuc = value;
					PropertyHasChanged("CapMuc");
				}
			}
		}

		public int MaMucCha
		{
			get
			{
				CanReadProperty("MaMucCha", true);
				return _maMucCha;
			}
			set
			{
				CanWriteProperty("MaMucCha", true);
				if (!_maMucCha.Equals(value))
				{
					_maMucCha = value;
					PropertyHasChanged("MaMucCha");
				}
			}
		}

		public int LoaiTinh
		{
			get
			{
				CanReadProperty("LoaiTinh", true);
				return _loaiTinh;
			}
			set
			{
				CanWriteProperty("LoaiTinh", true);
				if (!_loaiTinh.Equals(value))
				{
					_loaiTinh = value;
					PropertyHasChanged("LoaiTinh");
				}
			}
		}

        public int SoTTTinhToan
        {
            get
            {
                CanReadProperty("SoTTTinhToan", true);
                return _soTTTinhToan;
            }
            set
            {
                CanWriteProperty("SoTTTinhToan", true);
                if (!_soTTTinhToan.Equals(value))
                {
                    _soTTTinhToan = value;
                    PropertyHasChanged("SoTTTinhToan");
                }
            }
        }

        public byte isNHNN
        {
            get
            {
                CanReadProperty("isNHNN", true);
                return _isNHNN;
            }
            set
            {
                CanWriteProperty("isNHNN", true);
                if (!_isNHNN.Equals(value))
                {
                    _isNHNN = value;
                    PropertyHasChanged("isNHNN");
                }
            }
        }

        public int MaThongTu
        {
            get
            {
                CanReadProperty("MaThongTu", true);
                return _maThongTu;
            }
            set
            {
                CanWriteProperty("MaThongTu", true);
                if (!_maThongTu.Equals(value))
                {
                    _maThongTu = value;
                    PropertyHasChanged("MaThongTu");
                }
            }
        }

        public int MaMucCapHaiDoiUng
        {
            get
            {
                CanReadProperty("MaMucCapHaiDoiUng", true);
                return _maMucCapHaiDoiUng;
            }
            set
            {
                CanWriteProperty("MaMucCapHaiDoiUng", true);
                if (!_maMucCapHaiDoiUng.Equals(value))
                {
                    _maMucCapHaiDoiUng = value;
                    PropertyHasChanged("MaMucCapHaiDoiUng");
                }
            }
        }

        public bool LayTheoLuyKe
        {
            get
            {
                CanReadProperty("LayTheoLuyKe", true);
                return _LayTheoLuyKe;
            }
            set
            {
                CanWriteProperty("LayTheoLuyKe", true);
                if (!_LayTheoLuyKe.Equals(value))
                {
                    _LayTheoLuyKe = value;
                    PropertyHasChanged("LayTheoLuyKe");
                }
            }
        }


		public CT_CongThucTMBCTaiChinhList CT_CongThucTMBCTaiChinhList
		{
			get
			{
				CanReadProperty("CT_CongThucTMBCTaiChinhList", true);
				return _cT_CongThucTMBCTaiChinhList;
			}
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _cT_CongThucTMBCTaiChinhList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _cT_CongThucTMBCTaiChinhList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maMucCapHai;
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
			// TenMucCapHai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenMucCapHai", 500));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 1000));
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
			//TODO: Define authorization rules in CT_MucTMBCTaiChinh
			//AuthorizationRules.AllowRead("CT_CongThucTMBCTaiChinhList", "CT_MucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("MaMucCapHai", "CT_MucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("MaMucCapMot", "CT_MucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("TenMucCapHai", "CT_MucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "CT_MucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("MaSo", "CT_MucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("CapMuc", "CT_MucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("MaMucCha", "CT_MucTMBCTaiChinhReadGroup");
			//AuthorizationRules.AllowRead("LoaiTinh", "CT_MucTMBCTaiChinhReadGroup");

			//AuthorizationRules.AllowWrite("MaMucCapMot", "CT_MucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("TenMucCapHai", "CT_MucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "CT_MucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaSo", "CT_MucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("CapMuc", "CT_MucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaMucCha", "CT_MucTMBCTaiChinhWriteGroup");
			//AuthorizationRules.AllowWrite("LoaiTinh", "CT_MucTMBCTaiChinhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CT_MucTMBCTaiChinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_MucTMBCTaiChinhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CT_MucTMBCTaiChinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_MucTMBCTaiChinhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CT_MucTMBCTaiChinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_MucTMBCTaiChinhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CT_MucTMBCTaiChinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_MucTMBCTaiChinhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CT_MucTMBCTaiChinh()
		{ /* require use of factory method */ }

		public static CT_MucTMBCTaiChinh NewCT_MucTMBCTaiChinh()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CT_MucTMBCTaiChinh");
			return DataPortal.Create<CT_MucTMBCTaiChinh>();
		}

		public static CT_MucTMBCTaiChinh GetCT_MucTMBCTaiChinh(int maMucCapHai)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CT_MucTMBCTaiChinh");
			return DataPortal.Fetch<CT_MucTMBCTaiChinh>(new Criteria(maMucCapHai));
		}

		public static void DeleteCT_MucTMBCTaiChinh(int maMucCapHai)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CT_MucTMBCTaiChinh");
			DataPortal.Delete(new Criteria(maMucCapHai));
		}

		public override CT_MucTMBCTaiChinh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CT_MucTMBCTaiChinh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CT_MucTMBCTaiChinh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a CT_MucTMBCTaiChinh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static CT_MucTMBCTaiChinh NewCT_MucTMBCTaiChinhChild()
		{
			CT_MucTMBCTaiChinh child = new CT_MucTMBCTaiChinh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

        public static CT_MucTMBCTaiChinh NewCT_MucTMBCTaiChinhChild(CT_MucTMBCTaiChinh bangCopy)
        {
        //private CT_CongThucTMBCTaiChinhList _cT_CongThucTMBCTaiChinhList = CT_CongThucTMBCTaiChinhList.NewCT_CongThucTMBCTaiChinhList();
            CT_MucTMBCTaiChinh child = new CT_MucTMBCTaiChinh();
            //child.MaMucCapMot
            child.TenMucCapHai = bangCopy.TenMucCapHai;
            child.DienGiai = bangCopy.DienGiai;
            child.MaSo = bangCopy.MaSo;
            child.CapMuc = bangCopy.CapMuc;
            //child.MaMucCha
            child.LoaiTinh = bangCopy.LoaiTinh;
            child.SoTTTinhToan = bangCopy.SoTTTinhToan;
            child.MaMucCapHaiDoiUng = bangCopy.MaMucCapHaiDoiUng != 0 ? bangCopy.MaMucCapHaiDoiUng : bangCopy.MaMucCapHai;
            foreach (CT_CongThucTMBCTaiChinh ct in bangCopy.CT_CongThucTMBCTaiChinhList)
            {
                child.CT_CongThucTMBCTaiChinhList.Add(CT_CongThucTMBCTaiChinh.NewCT_CongThucTMBCTaiChinh(ct));
            }
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

		internal static CT_MucTMBCTaiChinh GetCT_MucTMBCTaiChinh(SafeDataReader dr)
		{
            CT_MucTMBCTaiChinh child = NewCT_MucTMBCTaiChinh();
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
			public int MaMucCapHai;

			public Criteria(int maMucCapHai)
			{
				this.MaMucCapHai = maMucCapHai;
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
                cm.CommandText = "spd_SelecttblCT_MucTMBCTaiChinh";

				cm.Parameters.AddWithValue("@MaMucCapHai", criteria.MaMucCapHai);

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
			DataPortal_Delete(new Criteria(_maMucCapHai));
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
                cm.CommandText = "spd_DeletetblCT_MucTMBCTaiChinh";

				cm.Parameters.AddWithValue("@MaMucCapHai", criteria.MaMucCapHai);

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
			_maMucCapHai = dr.GetInt32("MaMucCapHai");
			_maMucCapMot = dr.GetInt32("MaMucCapMot");
			_tenMucCapHai = dr.GetString("TenMucCapHai");
			_dienGiai = dr.GetString("DienGiai");
			_maSo = dr.GetInt32("MaSo");
			_capMuc = dr.GetByte("CapMuc");
			_maMucCha = dr.GetInt32("MaMucCha");
			_loaiTinh = dr.GetInt32("LoaiTinh");
            _soTTTinhToan = dr.GetInt32("SoTTTinhToan");

            _isNHNN = dr.GetByte("isNHNN");
            _maThongTu = dr.GetInt32("MaThongTu");
            _maMucCapHaiDoiUng = dr.GetInt32("MaMucCapHaiDoiUng");
            _LayTheoLuyKe = dr.GetBoolean("LayTheoLuyKe");
		}

		private void FetchChildren(SafeDataReader dr)
		{
			//dr.NextResult();
			_cT_CongThucTMBCTaiChinhList = CT_CongThucTMBCTaiChinhList.GetCT_CongThucTMBCTaiChinhList(this.MaMucCapHai);
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
                cm.CommandText = "spd_InserttblCT_MucTMBCTaiChinh";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maMucCapHai = (int)cm.Parameters["@MaMucCapHai"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maMucCapMot != 0)
				cm.Parameters.AddWithValue("@MaMucCapMot", _maMucCapMot);
			else
				cm.Parameters.AddWithValue("@MaMucCapMot", DBNull.Value);
			if (_tenMucCapHai.Length > 0)
				cm.Parameters.AddWithValue("@TenMucCapHai", _tenMucCapHai);
			else
				cm.Parameters.AddWithValue("@TenMucCapHai", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maSo != 0)
				cm.Parameters.AddWithValue("@MaSo", _maSo);
			else
				cm.Parameters.AddWithValue("@MaSo", DBNull.Value);
			if (_capMuc != 0)
				cm.Parameters.AddWithValue("@CapMuc", _capMuc);
			else
				cm.Parameters.AddWithValue("@CapMuc", DBNull.Value);
			if (_maMucCha != 0)
				cm.Parameters.AddWithValue("@MaMucCha", _maMucCha);
			else
				cm.Parameters.AddWithValue("@MaMucCha", DBNull.Value);
			if (_loaiTinh != 0)
				cm.Parameters.AddWithValue("@LoaiTinh", _loaiTinh);
			else
				cm.Parameters.AddWithValue("@LoaiTinh", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTTTinhToan", _soTTTinhToan);

            if (_isNHNN != 0)
                cm.Parameters.AddWithValue("@isNHNN", _isNHNN);
            else
                cm.Parameters.AddWithValue("@isNHNN", DBNull.Value);
            if (_maThongTu != 0)
                cm.Parameters.AddWithValue("@MaThongTu", _maThongTu);
            else
                cm.Parameters.AddWithValue("@MaThongTu", DBNull.Value);

            if (_maMucCapHaiDoiUng != 0)
                cm.Parameters.AddWithValue("@MaMucCapHaiDoiUng", _maMucCapHaiDoiUng);
            else
                cm.Parameters.AddWithValue("@MaMucCapHaiDoiUng", DBNull.Value);

            if (_LayTheoLuyKe != false)
                cm.Parameters.AddWithValue("@LayTheoLuyKe", _LayTheoLuyKe);
            else
                cm.Parameters.AddWithValue("@LayTheoLuyKe", DBNull.Value);

			cm.Parameters.AddWithValue("@MaMucCapHai", _maMucCapHai);
			cm.Parameters["@MaMucCapHai"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblCT_MucTMBCTaiChinh";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaMucCapHai", _maMucCapHai);
			if (_maMucCapMot != 0)
				cm.Parameters.AddWithValue("@MaMucCapMot", _maMucCapMot);
			else
				cm.Parameters.AddWithValue("@MaMucCapMot", DBNull.Value);
			if (_tenMucCapHai.Length > 0)
				cm.Parameters.AddWithValue("@TenMucCapHai", _tenMucCapHai);
			else
				cm.Parameters.AddWithValue("@TenMucCapHai", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maSo != 0)
				cm.Parameters.AddWithValue("@MaSo", _maSo);
			else
				cm.Parameters.AddWithValue("@MaSo", DBNull.Value);
			if (_capMuc != 0)
				cm.Parameters.AddWithValue("@CapMuc", _capMuc);
			else
				cm.Parameters.AddWithValue("@CapMuc", DBNull.Value);
			if (_maMucCha != 0)
				cm.Parameters.AddWithValue("@MaMucCha", _maMucCha);
			else
				cm.Parameters.AddWithValue("@MaMucCha", DBNull.Value);
			if (_loaiTinh != 0)
				cm.Parameters.AddWithValue("@LoaiTinh", _loaiTinh);
			else
				cm.Parameters.AddWithValue("@LoaiTinh", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTTTinhToan", _soTTTinhToan);

            if (_isNHNN != 0)
                cm.Parameters.AddWithValue("@isNHNN", _isNHNN);
            else
                cm.Parameters.AddWithValue("@isNHNN", DBNull.Value);
            if (_maThongTu != 0)
                cm.Parameters.AddWithValue("@MaThongTu", _maThongTu);
            else
                cm.Parameters.AddWithValue("@MaThongTu", DBNull.Value);
            if (_maMucCapHaiDoiUng != 0)
                cm.Parameters.AddWithValue("@MaMucCapHaiDoiUng", _maMucCapHaiDoiUng);
            else
                cm.Parameters.AddWithValue("@MaMucCapHaiDoiUng", DBNull.Value);

            if (_LayTheoLuyKe != false)
                cm.Parameters.AddWithValue("@LayTheoLuyKe", _LayTheoLuyKe);
            else
                cm.Parameters.AddWithValue("@LayTheoLuyKe", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_cT_CongThucTMBCTaiChinhList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            _cT_CongThucTMBCTaiChinhList.Clear();
            UpdateChildren(tr);

			ExecuteDelete(tr, new Criteria(_maMucCapHai));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
