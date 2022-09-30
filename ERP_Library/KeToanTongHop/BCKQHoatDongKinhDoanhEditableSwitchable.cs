
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BCKQHoatDongKinhDoanh : Csla.BusinessBase<BCKQHoatDongKinhDoanh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maMuc = 0;
		private string _tenMuc = string.Empty;
		private string _maSo = string.Empty;
		private string _thuyetMinh = string.Empty;
		private byte _loai = 0;
        private byte _loaiBaoCao = 0;
        private int _maMucCha = 0;
        private int _sttTinh = 0;
        private string _dienGiai= string.Empty;

        private byte _isNHNN = 0;
        private int _maThongTu = 0;
        private int _maMucDoiUng = 0;
		//declare child member(s)
		private CT_MauBangBaoCaoList _cT_MauBangBaoCaoList = CT_MauBangBaoCaoList.NewCT_MauBangBaoCaoList();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaMuc
		{
			get
			{
				CanReadProperty("MaMuc", true);
				return _maMuc;
			}
		}

		public string TenMuc
		{
			get
			{
				CanReadProperty("TenMuc", true);
				return _tenMuc;
			}
			set
			{
				CanWriteProperty("TenMuc", true);
				if (value == null) value = string.Empty;
				if (!_tenMuc.Equals(value))
				{
					_tenMuc = value;
					PropertyHasChanged("TenMuc");
				}
			}
		}

		public string MaSo
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

		public string ThuyetMinh
		{
			get
			{
				CanReadProperty("ThuyetMinh", true);
				return _thuyetMinh;
			}
			set
			{
				CanWriteProperty("ThuyetMinh", true);
				if (value == null) value = string.Empty;
				if (!_thuyetMinh.Equals(value))
				{
					_thuyetMinh = value;
					PropertyHasChanged("ThuyetMinh");
				}
			}
		}

		public byte Loai
		{
			get
			{
				CanReadProperty("Loai", true);
				return _loai;
			}
			set
			{
				CanWriteProperty("Loai", true);
				if (!_loai.Equals(value))
				{
					_loai = value;
					PropertyHasChanged("Loai");
				}
			}
		}

        public byte LoaiBaoCao
        {
            get
            {
                CanReadProperty("LoaiBaoCao", true);
                return _loaiBaoCao;
            }
            set
            {
                CanWriteProperty("LoaiBaoCao", true);
                if (!_loaiBaoCao.Equals(value))
                {
                    _loaiBaoCao = value;
                    PropertyHasChanged("LoaiBaoCao");
                }
            }
        }

        public int STTTinh
        {
            get
            {
                return _sttTinh;
            }
            set
            {
                if (!_sttTinh.Equals(value))
                {
                    _sttTinh = value;
                    PropertyHasChanged();
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
                if (!_dienGiai.Equals(value))
                {
                    _dienGiai = value;
                    PropertyHasChanged("DienGiai");
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

        public int MaMucDoiUng
        {
            get
            {
                CanReadProperty("MaMucDoiUng", true);
                return _maMucDoiUng;
            }
            set
            {
                CanWriteProperty("MaMucDoiUng", true);
                if (!_maMucDoiUng.Equals(value))
                {
                    _maMucDoiUng = value;
                    PropertyHasChanged("MaMucDoiUng");
                }
            }
        }


		public CT_MauBangBaoCaoList CT_MauBangBaoCaoList
		{
			get
			{
				CanReadProperty("CT_MauBangBaoCaoList", true);
				return _cT_MauBangBaoCaoList;
			}
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _cT_MauBangBaoCaoList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _cT_MauBangBaoCaoList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maMuc;
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
			// TenMuc
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenMuc", 1000));
			//
			// ThuyetMinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ThuyetMinh", 50));
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
			//TODO: Define authorization rules in BCKQHoatDongKinhDoanh
			//AuthorizationRules.AllowRead("CT_MauBangBaoCaoList", "BCKQHoatDongKinhDoanhReadGroup");
			//AuthorizationRules.AllowRead("MaMuc", "BCKQHoatDongKinhDoanhReadGroup");
			//AuthorizationRules.AllowRead("TenMuc", "BCKQHoatDongKinhDoanhReadGroup");
			//AuthorizationRules.AllowRead("MaSo", "BCKQHoatDongKinhDoanhReadGroup");
			//AuthorizationRules.AllowRead("ThuyetMinh", "BCKQHoatDongKinhDoanhReadGroup");
			//AuthorizationRules.AllowRead("Loai", "BCKQHoatDongKinhDoanhReadGroup");

			//AuthorizationRules.AllowWrite("TenMuc", "BCKQHoatDongKinhDoanhWriteGroup");
			//AuthorizationRules.AllowWrite("MaSo", "BCKQHoatDongKinhDoanhWriteGroup");
			//AuthorizationRules.AllowWrite("ThuyetMinh", "BCKQHoatDongKinhDoanhWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "BCKQHoatDongKinhDoanhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BCKQHoatDongKinhDoanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BCKQHoatDongKinhDoanhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BCKQHoatDongKinhDoanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BCKQHoatDongKinhDoanhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BCKQHoatDongKinhDoanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BCKQHoatDongKinhDoanhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BCKQHoatDongKinhDoanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BCKQHoatDongKinhDoanhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BCKQHoatDongKinhDoanh()
		{ /* require use of factory method */ }

		public static BCKQHoatDongKinhDoanh NewBCKQHoatDongKinhDoanh()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BCKQHoatDongKinhDoanh");
			return DataPortal.Create<BCKQHoatDongKinhDoanh>();
		}

		public static BCKQHoatDongKinhDoanh GetBCKQHoatDongKinhDoanh(int maMuc)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BCKQHoatDongKinhDoanh");
			return DataPortal.Fetch<BCKQHoatDongKinhDoanh>(new Criteria(maMuc));
		}

		public static void DeleteBCKQHoatDongKinhDoanh(int maMuc)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BCKQHoatDongKinhDoanh");
			DataPortal.Delete(new Criteria(maMuc));
		}

		public override BCKQHoatDongKinhDoanh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BCKQHoatDongKinhDoanh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BCKQHoatDongKinhDoanh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BCKQHoatDongKinhDoanh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static BCKQHoatDongKinhDoanh NewBCKQHoatDongKinhDoanhChild()
		{
			BCKQHoatDongKinhDoanh child = new BCKQHoatDongKinhDoanh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

        public static BCKQHoatDongKinhDoanh NewBCKQHoatDongKinhDoanhChild(BCKQHoatDongKinhDoanh copy,byte loaiBaoCao)
        {
            BCKQHoatDongKinhDoanh child = new BCKQHoatDongKinhDoanh();
            child._tenMuc = copy.TenMuc;
            child._maSo = copy.MaSo;
            child._thuyetMinh = copy.ThuyetMinh;
            child._loai = copy.Loai;
            child._loaiBaoCao = loaiBaoCao;
            //child._maMucCha
            child._sttTinh = copy.STTTinh;
            child._dienGiai = copy.DienGiai;
            //child._isNHNN

            child._maMucDoiUng = copy.MaMucDoiUng != 0 ? copy.MaMucDoiUng : copy.MaMuc;
            foreach (CT_MauBangBaoCao ct in copy.CT_MauBangBaoCaoList)
            {
                child._cT_MauBangBaoCaoList.Add(CT_MauBangBaoCao.NewCT_MauBangBaoCao(ct, loaiBaoCao));//2 BC KQHDKD; 3: Luu Chuyen TienTe
            }
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

		internal static BCKQHoatDongKinhDoanh GetBCKQHoatDongKinhDoanh(SafeDataReader dr)
		{
			BCKQHoatDongKinhDoanh child =  new BCKQHoatDongKinhDoanh();
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
			public int MaMuc;

			public Criteria(int maMuc)
			{
				this.MaMuc = maMuc;
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
                cm.CommandText = "spd_SelecttblMauBCKQHoatDongKinhDoanh";

				cm.Parameters.AddWithValue("@MaMuc", criteria.MaMuc);

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
			DataPortal_Delete(new Criteria(_maMuc));
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
                cm.CommandText = "spd_DeletetblMauBCKQHoatDongKinhDoanh";

				cm.Parameters.AddWithValue("@MaMuc", criteria.MaMuc);

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
			_maMuc = dr.GetInt32("MaMuc");
			_tenMuc = dr.GetString("TenMuc");
			_maSo = dr.GetString("MaSo");
			_thuyetMinh = dr.GetString("ThuyetMinh");
			_loai = dr.GetByte("Loai");
            _loaiBaoCao = dr.GetByte("LoaiBaoCao");
            _maMucCha= dr.GetInt32("MaMucCha");
            _sttTinh = dr.GetInt32("STTTinh");
            _dienGiai= dr.GetString("DienGiai");
            _isNHNN = dr.GetByte("isNHNN");
            _maThongTu = dr.GetInt32("MaThongTu");
            _maMucDoiUng = dr.GetInt32("MaMucDoiUng");
		}

		private void FetchChildren(SafeDataReader dr)
		{
			///dr.NextResult();
			_cT_MauBangBaoCaoList = CT_MauBangBaoCaoList.GetCT_MauBangBaoCaoList(this.MaMuc, this.LoaiBaoCao);
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
                cm.CommandText = "spd_InserttblMauBCKQHoatDongKinhDoanh";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maMuc = (int)cm.Parameters["@MaMuc"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_tenMuc.Length > 0)
				cm.Parameters.AddWithValue("@TenMuc", _tenMuc);
			else
				cm.Parameters.AddWithValue("@TenMuc", DBNull.Value);
			if (_maSo != string.Empty)
				cm.Parameters.AddWithValue("@MaSo", _maSo);
			else
				cm.Parameters.AddWithValue("@MaSo", DBNull.Value);
			if (_thuyetMinh.Length > 0)
				cm.Parameters.AddWithValue("@ThuyetMinh", _thuyetMinh);
			else
				cm.Parameters.AddWithValue("@ThuyetMinh", DBNull.Value);
			cm.Parameters.AddWithValue("@Loai", _loai);
            cm.Parameters.AddWithValue("@LoaiBaoCao", _loaiBaoCao);
            cm.Parameters.AddWithValue("@STTTinh", _sttTinh);
            if (_maMucCha != 0)
                cm.Parameters.AddWithValue("@MaMucCha", _maMucCha);
            else
                cm.Parameters.AddWithValue("@MaMucCha", DBNull.Value);
            cm.Parameters.AddWithValue("@DienGiai", _dienGiai);

            if (_isNHNN != 0)
                cm.Parameters.AddWithValue("@isNHNN", _isNHNN);
            else
                cm.Parameters.AddWithValue("@isNHNN", DBNull.Value);

            if (_maThongTu != 0)
                cm.Parameters.AddWithValue("@MaThongTu", _maThongTu);
            else
                cm.Parameters.AddWithValue("@MaThongTu", DBNull.Value);

            if (_maMucDoiUng != 0)
                cm.Parameters.AddWithValue("@MaMucDoiUng", _maMucDoiUng);
            else
                cm.Parameters.AddWithValue("@MaMucDoiUng", DBNull.Value);

			cm.Parameters.AddWithValue("@MaMuc", _maMuc);
			cm.Parameters["@MaMuc"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblMauBCKQHoatDongKinhDoanh";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaMuc", _maMuc);
			if (_tenMuc.Length > 0)
				cm.Parameters.AddWithValue("@TenMuc", _tenMuc);
			else
				cm.Parameters.AddWithValue("@TenMuc", DBNull.Value);
			if (_maSo != string.Empty)
				cm.Parameters.AddWithValue("@MaSo", _maSo);
			else
				cm.Parameters.AddWithValue("@MaSo", DBNull.Value);
			if (_thuyetMinh.Length > 0)
				cm.Parameters.AddWithValue("@ThuyetMinh", _thuyetMinh);
			else
				cm.Parameters.AddWithValue("@ThuyetMinh", DBNull.Value);
			cm.Parameters.AddWithValue("@Loai", _loai);
            cm.Parameters.AddWithValue("@STTTinh", _sttTinh);
            cm.Parameters.AddWithValue("@LoaiBaoCao", _loaiBaoCao);
            if (_maMucCha != 0)
                cm.Parameters.AddWithValue("@MaMucCha", _maMucCha);
            else
                cm.Parameters.AddWithValue("@MaMucCha", DBNull.Value);
            cm.Parameters.AddWithValue("@DienGiai", _dienGiai);

            if (_isNHNN != 0)
                cm.Parameters.AddWithValue("@isNHNN", _isNHNN);
            else
                cm.Parameters.AddWithValue("@isNHNN", DBNull.Value);

            if (_maThongTu != 0)
                cm.Parameters.AddWithValue("@MaThongTu", _maThongTu);
            else
                cm.Parameters.AddWithValue("@MaThongTu", DBNull.Value);

            if (_maMucDoiUng != 0)
                cm.Parameters.AddWithValue("@MaMucDoiUng", _maMucDoiUng);
            else
                cm.Parameters.AddWithValue("@MaMucDoiUng", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_cT_MauBangBaoCaoList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

            _cT_MauBangBaoCaoList.Clear();
            UpdateChildren(tr);
			ExecuteDelete(tr, new Criteria(_maMuc));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
