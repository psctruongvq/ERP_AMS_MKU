
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangCanDoiKeToanH : Csla.BusinessBase<BangCanDoiKeToanH>
	{
		#region Business Properties and Methods

		//declare members
		private int _maMucTaiKhoan = 0;
		private string _tenMucTaiKhoan = string.Empty;
		private string _maSo =string.Empty;
		private string _thuyetMinh = string.Empty;
        private int _maMucTaiKhoanCha = 0;
        //private string _maMucTaiKhoanCha = "";
        private string _maMucTaiKhoanCha1 = "";
		private int _capMuc = 0;
		private int _maTaiKhoan = 0;
        private string _tenMucTaiKhoanCha = string.Empty;
        private string _tenTaiKhoan = string.Empty;

        private byte _isNHNN = 0;

        private int _maThongTu = 0;
        private int _maMucTaiKhoanDoiUng = 0;
        private string _dienGiai = string.Empty;

        private string _soHieuTK = string.Empty;
        private string _dauCongThuc = string.Empty;
        private string _kieuLaySoDu = string.Empty;
        private string _benNoCo = string.Empty;
        private string _tenMucLienQuan = string.Empty;
        private string _soHieuTKDoiUng = string.Empty;
        private string _TenHoatDong = string.Empty;
        private string _TenKhoanMuc = string.Empty;
        private string _SapXep = string.Empty;
        private string _strCapMuc = string.Empty;
        private int _MaChiTiet = 0;
        private int _keyOfTree = 0;

        private CT_MauBangBaoCaoListH _cT_MauBangBaoCaoListH = CT_MauBangBaoCaoListH.NewCT_MauBangBaoCaoListH();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaMucTaiKhoan
		{
			get
			{
				CanReadProperty("MaMucTaiKhoan", true);
				return _maMucTaiKhoan;
			}
            set
            {
                CanWriteProperty("MaMucTaiKhoan", true);
                if (!_maMucTaiKhoan.Equals(value))
                {
                    _maMucTaiKhoan = value;
                    PropertyHasChanged("MaMucTaiKhoan");
                }
            }
		}

		public string TenMucTaiKhoan
		{
			get
			{
				CanReadProperty("TenMucTaiKhoan", true);
				return _tenMucTaiKhoan;
			}
			set
			{
				CanWriteProperty("TenMucTaiKhoan", true);
				if (value == null) value = string.Empty;
				if (!_tenMucTaiKhoan.Equals(value))
				{
					_tenMucTaiKhoan = value;
					PropertyHasChanged("TenMucTaiKhoan");
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

        public string MaMucTaiKhoanCha1
        {
            get
            {
                CanReadProperty("MaMucTaiKhoanCha1", true);
                return _maMucTaiKhoanCha1;
            }
            set
            {
                CanWriteProperty("MaMucTaiKhoanCha1", true);
                if (value == null) value = string.Empty;
                if (!_maMucTaiKhoanCha1.Equals(value))
                {
                    _maMucTaiKhoanCha1 = value;
                    PropertyHasChanged("MaMucTaiKhoanCha1");
                }
            }
        }

        //public string MaMucTaiKhoanCha
        //{
        //    get
        //    {
        //        CanReadProperty("MaMucTaiKhoanCha", true);
        //        return _maMucTaiKhoanCha;
        //    }
        //    set
        //    {
        //        CanWriteProperty("MaMucTaiKhoanCha", true);
        //        if (!_maMucTaiKhoanCha.Equals(value))
        //        {
        //            _maMucTaiKhoanCha = value;
        //            //_tenMucTaiKhoanCha = BangCanDoiKeToanH.GetBangCanDoiKeToanH(_maMucTaiKhoan).TenMucTaiKhoanCha;
        //            PropertyHasChanged("MaMucTaiKhoanCha");
        //        }
        //    }
        //}

        public int MaMucTaiKhoanCha
        {
            get
            {
                CanReadProperty("MaMucTaiKhoanCha", true);
                return _maMucTaiKhoanCha;
            }
            set
            {
                CanWriteProperty("MaMucTaiKhoanCha", true);
                if (!_maMucTaiKhoanCha.Equals(value))
                {
                    _maMucTaiKhoanCha = value;
                    //_tenMucTaiKhoanCha = BangCanDoiKeToanH.GetBangCanDoiKeToanH(_maMucTaiKhoan).TenMucTaiKhoanCha;
                    PropertyHasChanged("MaMucTaiKhoanCha");
                }
            }
        }

		public int CapMuc
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

		public int MaTaiKhoan
		{
			get
			{
				CanReadProperty("MaTaiKhoan", true);
				return _maTaiKhoan;
			}
			set
			{
				CanWriteProperty("MaTaiKhoan", true);
				if (!_maTaiKhoan.Equals(value))
				{
					_maTaiKhoan = value;
					PropertyHasChanged("MaTaiKhoan");
				}
			}
		}

        public string TenMucTaiKhoanCha
        {
            get
            {
                CanReadProperty("TenMucTaiKhoanCha", true);
                return _tenMucTaiKhoanCha;
            }
            set
            {
                CanWriteProperty("TenMucTaiKhoanCha", true);
                if (!_tenMucTaiKhoanCha.Equals(value))
                {
                    _tenMucTaiKhoanCha = value;
                    PropertyHasChanged("TenMucTaiKhoanCha");
                }
            }
        }

        public string TenTaiKhoan
        {
            get
            {
                CanReadProperty("TenTaiKhoan", true);
                return _tenTaiKhoan;
            }
            set
            {
                CanWriteProperty("TenTaiKhoan", true);
                if (!_tenTaiKhoan.Equals(value))
                {
                    _tenTaiKhoan = value;
                    PropertyHasChanged("TenTaiKhoan");
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

        public int MaMucTaiKhoanDoiUng
        {
            get
            {
                CanReadProperty("MaMucTaiKhoanDoiUng", true);
                return _maMucTaiKhoanDoiUng;
            }
            set
            {
                CanWriteProperty("MaMucTaiKhoanDoiUng", true);
                if (!_maMucTaiKhoanDoiUng.Equals(value))
                {
                    _maMucTaiKhoanDoiUng = value;
                    PropertyHasChanged("MaMucTaiKhoanDoiUng");
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

        public string SoHieuTK
        {
            get
            {
                CanReadProperty("SoHieuTK", true);
                return _soHieuTK;
            }
            set
            {
                CanWriteProperty("SoHieuTK", true);
                if (!_soHieuTK.Equals(value))
                {
                    _soHieuTK = value;
                    PropertyHasChanged("SoHieuTK");
                }
            }
        }

        public string DauCongThuc
        {
            get
            {
                CanReadProperty("DauCongThuc", true);
                return _dauCongThuc;
            }
            set
            {
                CanWriteProperty("DauCongThuc", true);
                if (!_dauCongThuc.Equals(value))
                {
                    _dauCongThuc = value;
                    PropertyHasChanged("DauCongThuc");
                }
            }
        }

        public string KieuLaySoDu
        {
            get
            {
                CanReadProperty("KieuLaySoDu", true);
                return _kieuLaySoDu;
            }
            set
            {
                CanWriteProperty("KieuLaySoDu", true);
                if (!_kieuLaySoDu.Equals(value))
                {
                    _kieuLaySoDu = value;
                    PropertyHasChanged("KieuLaySoDu");
                }
            }
        }

        public string BenNoCo
        {
            get
            {
                CanReadProperty("BenNoCo", true);
                return _benNoCo;
            }
            set
            {
                CanWriteProperty("BenNoCo", true);
                if (!_benNoCo.Equals(value))
                {
                    _benNoCo = value;
                    PropertyHasChanged("BenNoCo");
                }
            }
        }

        public string TenMucLienQuan
        {
            get
            {
                CanReadProperty("TenMucLienQuan", true);
                return _tenMucLienQuan;
            }
            set
            {
                CanWriteProperty("TenMucLienQuan", true);
                if (!_tenMucLienQuan.Equals(value))
                {
                    _tenMucLienQuan = value;
                    PropertyHasChanged("TenMucLienQuan");
                }
            }
        }

        public string SoHieuTKDoiUng
        {
            get
            {
                CanReadProperty("SoHieuTKDoiUng", true);
                return _soHieuTKDoiUng;
            }
            set
            {
                CanWriteProperty("SoHieuTKDoiUng", true);
                if (!_soHieuTKDoiUng.Equals(value))
                {
                    _soHieuTKDoiUng = value;
                    PropertyHasChanged("SoHieuTKDoiUng");
                }
            }
        }

        public string TenHoatDong
        {
            get
            {
                CanReadProperty("TenHoatDong", true);
                return _TenHoatDong;
            }
            set
            {
                CanWriteProperty("TenHoatDong", true);
                if (!_TenHoatDong.Equals(value))
                {
                    _TenHoatDong = value;
                    PropertyHasChanged("TenHoatDong");
                }
            }
        }

        public string TenKhoanMuc
        {
            get
            {
                CanReadProperty("TenKhoanMuc", true);
                return _TenKhoanMuc;
            }
            set
            {
                CanWriteProperty("TenKhoanMuc", true);
                if (!_TenKhoanMuc.Equals(value))
                {
                    _TenKhoanMuc = value;
                    PropertyHasChanged("TenKhoanMuc");
                }
            }
        }

        public string SapXep
        {
            get
            {
                CanReadProperty("SapXep", true);
                return _SapXep;
            }
            set
            {
                CanWriteProperty("SapXep", true);
                if (!_SapXep.Equals(value))
                {
                    _SapXep = value;
                    PropertyHasChanged("SapXep");
                }
            }
        }

        public string StrCapMuc
        {
            get
            {
                CanReadProperty("StrCapMuc", true);
                return _strCapMuc;
            }
            set
            {
                CanWriteProperty("StrCapMuc", true);
                if (!_strCapMuc.Equals(value))
                {
                    _strCapMuc = value;
                    PropertyHasChanged("StrCapMuc");
                }
            }
        }

        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _MaChiTiet;
            }
            set
            {
                CanWriteProperty("MaChiTiet", true);
                if (!_MaChiTiet.Equals(value))
                {
                    _MaChiTiet = value;
                    PropertyHasChanged("MaChiTiet");
                }
            }
        }

        public int KeyOfTree
        {
            get
            {
                CanReadProperty("KeyOfTree", true);
                return _keyOfTree;
            }
            set
            {
                CanWriteProperty("KeyOfTree", true);
                if (!_keyOfTree.Equals(value))
                {
                    _keyOfTree = value;
                    PropertyHasChanged("KeyOfTree");
                }
            }
        }

        public CT_MauBangBaoCaoListH CT_MauBangBaoCaoListH
        {
            get
            {
                CanReadProperty("CT_MauBangBaoCaoListH", true);
                return _cT_MauBangBaoCaoListH;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _cT_MauBangBaoCaoListH.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _cT_MauBangBaoCaoListH.IsDirty; }
        }
 
		protected override object GetIdValue()
		{
			return _maMucTaiKhoan;
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
			// TenMucTaiKhoan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenMucTaiKhoan", 1000));
			//
			// ThuyetMinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ThuyetMinh", 10));
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
			//TODO: Define authorization rules in BangCanDoiKeToan
			//AuthorizationRules.AllowRead("MaMucTaiKhoan", "BangCanDoiKeToanReadGroup");
			//AuthorizationRules.AllowRead("TenMucTaiKhoan", "BangCanDoiKeToanReadGroup");
			//AuthorizationRules.AllowRead("MaSo", "BangCanDoiKeToanReadGroup");
			//AuthorizationRules.AllowRead("ThuyetMinh", "BangCanDoiKeToanReadGroup");
			//AuthorizationRules.AllowRead("MaMucTaiKhoanCha", "BangCanDoiKeToanReadGroup");
			//AuthorizationRules.AllowRead("CapMuc", "BangCanDoiKeToanReadGroup");
			//AuthorizationRules.AllowRead("MaTaiKhoan", "BangCanDoiKeToanReadGroup");

			//AuthorizationRules.AllowWrite("TenMucTaiKhoan", "BangCanDoiKeToanWriteGroup");
			//AuthorizationRules.AllowWrite("MaSo", "BangCanDoiKeToanWriteGroup");
			//AuthorizationRules.AllowWrite("ThuyetMinh", "BangCanDoiKeToanWriteGroup");
			//AuthorizationRules.AllowWrite("MaMucTaiKhoanCha", "BangCanDoiKeToanWriteGroup");
			//AuthorizationRules.AllowWrite("CapMuc", "BangCanDoiKeToanWriteGroup");
			//AuthorizationRules.AllowWrite("MaTaiKhoan", "BangCanDoiKeToanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangCanDoiKeToan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCanDoiKeToanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangCanDoiKeToan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCanDoiKeToanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangCanDoiKeToan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCanDoiKeToanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangCanDoiKeToan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCanDoiKeToanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangCanDoiKeToanH()
		{ /* require use of factory method */ }

        public static BangCanDoiKeToanH NewBangCanDoiKeToanH()
		{
			if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangCanDoiKeToanH");
            return DataPortal.Create<BangCanDoiKeToanH>();
		}

        public BangCanDoiKeToanH GetBangCanDoiKeToanH(int maMucTaiKhoan)
		{
			if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCanDoiKeToanH");
            return DataPortal.Fetch<BangCanDoiKeToanH>(new Criteria(maMucTaiKhoan));
		}

		public static void DeleteBangCanDoiKeToanH(int maMucTaiKhoan)
		{
			if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BangCanDoiKeToanH");
			DataPortal.Delete(new Criteria(maMucTaiKhoan));
		}
		public override BangCanDoiKeToanH Save()
		{
			if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BangCanDoiKeToanH");
			else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangCanDoiKeToanH");
			else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a BangCanDoiKeToanH");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		public static BangCanDoiKeToanH NewBangCanDoiKeToanHChild()
		{
			BangCanDoiKeToanH child = new BangCanDoiKeToanH();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

        
		internal static BangCanDoiKeToanH GetBangCanDoiKeToanH(SafeDataReader dr)
		{
			BangCanDoiKeToanH child =  new BangCanDoiKeToanH();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}

        internal static BangCanDoiKeToanH GetBangCanDoiKeToanH_ForTree(SafeDataReader dr)
        {
            BangCanDoiKeToanH child = new BangCanDoiKeToanH();
            child.MarkAsChild();
            child.Fetch_ForTree(dr);
            return child;
        }

        public static BangCanDoiKeToanH NewBangCanDoiKeToanChildH(BangCanDoiKeToanH copy)
        {
            BangCanDoiKeToanH child = new BangCanDoiKeToanH();
            child.TenMucTaiKhoan = copy.TenMucTaiKhoan;
            child.MaSo = copy.MaSo;
            child.ThuyetMinh = copy.ThuyetMinh;
            child._maMucTaiKhoanDoiUng = copy.MaMucTaiKhoanCha;
            child.CapMuc = copy.CapMuc;
            //child.MaTaiKhoan = copy.MaTaiKhoan;
            child.TenMucTaiKhoanCha = copy.TenMucTaiKhoanCha;
            child.TenTaiKhoan = copy.TenTaiKhoan;
            child.MaMucTaiKhoan = copy.MaMucTaiKhoan;
            //child.isNHNN = copy.isNHNN;
            //child.MaThongTu
            child.MaMucTaiKhoanDoiUng = copy.MaMucTaiKhoanDoiUng != 0 ? copy.MaMucTaiKhoanDoiUng : copy.MaMucTaiKhoan;
            foreach (CT_MauBangBaoCaoH ct in copy.CT_MauBangBaoCaoListH)
            {
                child._cT_MauBangBaoCaoListH.Add(CT_MauBangBaoCaoH.NewCT_MauBangBaoCaoH(ct, 1));//1 Mau Can Doi Ke Toan
            }
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaMucTaiKhoan;

			public Criteria(int maMucTaiKhoan)
			{
				this.MaMucTaiKhoan = maMucTaiKhoan;
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
                cm.CommandText = "spd_GetBangCanDoiKeToan1";

				cm.Parameters.AddWithValue("@MaMucTaiKhoan", criteria.MaMucTaiKhoan);

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
			DataPortal_Delete(new Criteria(_maMucTaiKhoan));
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
                cm.CommandText = "spd_DeleteBangCanDoiKeToan1";

				cm.Parameters.AddWithValue("@MaMucTaiKhoan", criteria.MaMucTaiKhoan);

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

        private void Fetch_ForTree(SafeDataReader dr)
        {
            FetchObjectForTree(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

		private void FetchObject(SafeDataReader dr)
		{
			_maMucTaiKhoan = dr.GetInt32("MaMucTaiKhoan");
			_tenMucTaiKhoan = dr.GetString("TenMucTaiKhoan");
			_maSo = dr.GetString("MaSo");
			_thuyetMinh = dr.GetString("ThuyetMinh");
			_maMucTaiKhoanCha = dr.GetInt32("MaMucTaiKhoanCha");
            //_maMucTaiKhoanCha = dr.GetString("MaMucTaiKhoanCha");
			_capMuc = dr.GetInt32("CapMuc");
			_maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            _tenTaiKhoan= dr.GetString("TenTaiKhoan");
            _tenMucTaiKhoanCha= dr.GetString("TenMucTaiKhoanCha");
            _isNHNN = dr.GetByte("isNHNN");
            _maThongTu = dr.GetInt32("MaThongTu");
            _maMucTaiKhoanDoiUng = dr.GetInt32("MaMucTaiKhoanDoiUng");
            _dienGiai = dr.GetString("DienGiai");
		}

        private void FetchObjectForTree(SafeDataReader dr)
        {
            _maMucTaiKhoan = dr.GetInt32("MaMucTaiKhoan");
            _tenMucTaiKhoan = dr.GetString("TenMucTaiKhoan");
            _maSo = dr.GetString("MaSo");
            _thuyetMinh = dr.GetString("ThuyetMinh");
            _maMucTaiKhoanCha = dr.GetInt32("MaMucTaiKhoanCha");
            //_maMucTaiKhoanCha = dr.GetString("MaMucTaiKhoanCha");
            _capMuc = dr.GetInt32("CapMuc");
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            _tenTaiKhoan = dr.GetString("TenTaiKhoan");
            _tenMucTaiKhoanCha = dr.GetString("TenMucTaiKhoanCha");
            _isNHNN = dr.GetByte("isNHNN");
            _maThongTu = dr.GetInt32("MaThongTu");
            _maMucTaiKhoanDoiUng = dr.GetInt32("MaMucTaiKhoanDoiUng");
            _dienGiai = dr.GetString("DienGiai");
            _soHieuTK = dr.GetString("SoHieuTK");
            _dauCongThuc = dr.GetString("DauCongThuc");
            _kieuLaySoDu = dr.GetString("KieuLaySoDu");
            _benNoCo = dr.GetString("BenNoCo");
            _tenMucLienQuan = dr.GetString("TenMucLienQuan");
            _soHieuTKDoiUng = dr.GetString("SoHieuTKDoiUng");
            _TenHoatDong = dr.GetString("TenHoatDong");
            _TenKhoanMuc = dr.GetString("TenKhoanMuc");
            _MaChiTiet = dr.GetInt32("MaChiTiet");
            _strCapMuc = dr.GetString("strCapMuc");
            _keyOfTree = dr.GetInt32("KeyOfTree");
        }

		public void FetchChildren(SafeDataReader dr)
		{
            _cT_MauBangBaoCaoListH = CT_MauBangBaoCaoListH.GetCT_MauBangBaoCaoListH(this.MaMucTaiKhoan, 1);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr);
			MarkOld();

            MarkAsChild();
			//update child object(s)
            UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblBangCanDoiKeToan";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maMucTaiKhoan = (int)cm.Parameters["@MaMucTaiKhoan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_tenMucTaiKhoan.Length > 0)
				cm.Parameters.AddWithValue("@TenMucTaiKhoan", _tenMucTaiKhoan);
			else
				cm.Parameters.AddWithValue("@TenMucTaiKhoan", DBNull.Value);
			if (_maSo.Length > 0)
				cm.Parameters.AddWithValue("@MaSo", _maSo);
			else
				cm.Parameters.AddWithValue("@MaSo", DBNull.Value);
			if (_thuyetMinh.Length > 0)
				cm.Parameters.AddWithValue("@ThuyetMinh", _thuyetMinh);
			else
				cm.Parameters.AddWithValue("@ThuyetMinh", DBNull.Value);
            //if (_maMucTaiKhoanCha != "")
            if (_maMucTaiKhoanCha != 0)
				cm.Parameters.AddWithValue("@MaMucTaiKhoanCha", _maMucTaiKhoanCha);
			else
				cm.Parameters.AddWithValue("@MaMucTaiKhoanCha", DBNull.Value);
			if (_capMuc != 0)
				cm.Parameters.AddWithValue("@CapMuc", _capMuc);
			else
				cm.Parameters.AddWithValue("@CapMuc", DBNull.Value);
			if (_maTaiKhoan != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_isNHNN != 0)
                cm.Parameters.AddWithValue("@isNHNN", _isNHNN);
            else
                cm.Parameters.AddWithValue("@isNHNN", DBNull.Value);

            if (_maThongTu != 0)
                cm.Parameters.AddWithValue("@MaThongTu", _maThongTu);
            else
                cm.Parameters.AddWithValue("@MaThongTu", DBNull.Value);

            if (_maMucTaiKhoanDoiUng != 0)
                cm.Parameters.AddWithValue("@MaMucTaiKhoanDoiUng", _maMucTaiKhoanDoiUng);
            else
                cm.Parameters.AddWithValue("@MaMucTaiKhoanDoiUng", DBNull.Value);

            if (_dienGiai != string.Empty)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);

			cm.Parameters.AddWithValue("@MaMucTaiKhoan", _maMucTaiKhoan);
			cm.Parameters["@MaMucTaiKhoan"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblBangCanDoiKeToan";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaMucTaiKhoan", _maMucTaiKhoan);
			if (_tenMucTaiKhoan.Length > 0)
				cm.Parameters.AddWithValue("@TenMucTaiKhoan", _tenMucTaiKhoan);
			else
				cm.Parameters.AddWithValue("@TenMucTaiKhoan", DBNull.Value);
            if (_maSo.Length > 0)
				cm.Parameters.AddWithValue("@MaSo", _maSo);
			else
				cm.Parameters.AddWithValue("@MaSo", DBNull.Value);
			if (_thuyetMinh.Length > 0)
				cm.Parameters.AddWithValue("@ThuyetMinh", _thuyetMinh);
			else
				cm.Parameters.AddWithValue("@ThuyetMinh", DBNull.Value);
            //if (_maMucTaiKhoanCha != "")
            if (_maMucTaiKhoanCha != 0)
				cm.Parameters.AddWithValue("@MaMucTaiKhoanCha", _maMucTaiKhoanCha);
			else
				cm.Parameters.AddWithValue("@MaMucTaiKhoanCha", DBNull.Value);
			if (_capMuc != 0)
				cm.Parameters.AddWithValue("@CapMuc", _capMuc);
			else
				cm.Parameters.AddWithValue("@CapMuc", DBNull.Value);
			if (_maTaiKhoan != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_isNHNN != 0)
                cm.Parameters.AddWithValue("@isNHNN", _isNHNN);
            else
                cm.Parameters.AddWithValue("@isNHNN", DBNull.Value);

            if (_maThongTu != 0)
                cm.Parameters.AddWithValue("@MaThongTu", _maThongTu);
            else
                cm.Parameters.AddWithValue("@MaThongTu", DBNull.Value);

            if (_maMucTaiKhoanDoiUng != 0)
                cm.Parameters.AddWithValue("@MaMucTaiKhoanDoiUng", _maMucTaiKhoanDoiUng);
            else
                cm.Parameters.AddWithValue("@MaMucTaiKhoanDoiUng", DBNull.Value);

            if (_dienGiai != string.Empty)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
            _cT_MauBangBaoCaoListH.Update(tr,this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

            _cT_MauBangBaoCaoListH.Clear();
            UpdateChildren(tr);

			ExecuteDelete(tr, new Criteria(_maMucTaiKhoan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
