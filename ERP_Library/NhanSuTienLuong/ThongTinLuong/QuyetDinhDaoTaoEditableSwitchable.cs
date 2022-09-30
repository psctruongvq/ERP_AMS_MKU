
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuyetDinhDaoTao : Csla.BusinessBase<QuyetDinhDaoTao>
	{
		#region Business Properties and Methods

		//declare members
		private int _maQuyetDinh = 0;
		private string _soQuyetDinh = string.Empty;
		private SmartDate _ngayKy = new SmartDate(DateTime.Today);
        private long _nguoiKy = 0;
		private SmartDate _thoiGianBD = new SmartDate(DateTime.Today);
		private SmartDate _thoiGianKT = new SmartDate(DateTime.Today);
		private string _thoiGianHoc = string.Empty;
		private int _maHinhThucDaoTao = 0;
		private int _maTruongDaoTao = 0;
		private int _maChuyenNganhDaoTao = 0;
		private int _maTacDongDen = 0;
		private int _maTrinhDoChuyenMon = 0;
		private decimal _tongChiPhi = 0;
		private string _ghiChu = string.Empty;
        private long _maNguoiLap = Security.CurrentUser.Info.UserID;
        private string _tenNguoiLap = string.Empty;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		//declare child member(s)
		private ChiTietQuyetDinhList _chiTietQuyetDinhList = ChiTietQuyetDinhList.NewChiTietQuyetDinhList();
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaQuyetDinh
		{
			get
			{
				CanReadProperty("MaQuyetDinh", true);
				return _maQuyetDinh;
			}
		}

		public string SoQuyetDinh
		{
			get
			{
				CanReadProperty("SoQuyetDinh", true);
				return _soQuyetDinh;
			}
			set
			{
				CanWriteProperty("SoQuyetDinh", true);
				if (value == null) value = string.Empty;
				if (!_soQuyetDinh.Equals(value))
				{
					_soQuyetDinh = value;
					PropertyHasChanged("SoQuyetDinh");
				}
			}
		}

		public DateTime NgayKy
		{
			get
			{
				CanReadProperty("NgayKy", true);
				return _ngayKy.Date;
			}
            set
            {
                CanWriteProperty("NgayKy", true);                
                if (!_ngayKy.Equals(value))
                {
                    _ngayKy =  new SmartDate(value);
                    PropertyHasChanged("NgayKy");
                }
            }
		}		

		public long NguoiKy
		{
			get
			{
				CanReadProperty("NguoiKy", true);
				return _nguoiKy;
			}
			set
			{
				CanWriteProperty("NguoiKy", true);
				if (!_nguoiKy.Equals(value))
				{
					_nguoiKy = value;
					PropertyHasChanged("NguoiKy");
				}
			}
		}

		public DateTime ThoiGianBD
		{
			get
			{
				CanReadProperty("ThoiGianBD", true);
				return _thoiGianBD.Date;
			}
            set
            {
                CanWriteProperty("ThoiGianBD", true);                
                if (!_thoiGianBD.Equals(value))
                {
                    _thoiGianBD = new SmartDate(value);
                    PropertyHasChanged("ThoiGianBD");
                }
            }
		}
		
		public DateTime ThoiGianKT
		{
			get
			{
				CanReadProperty("ThoiGianKT", true);
				return _thoiGianKT.Date;
			}
            set
            {
                CanWriteProperty("ThoiGianKT", true);                
                if (!_thoiGianKT.Equals(value))
                {
                    _thoiGianKT = new SmartDate(value);
                    PropertyHasChanged("ThoiGianKT");
                }
            }
		}		

		public string ThoiGianHoc
		{
			get
			{
				CanReadProperty("ThoiGianHoc", true);
				return _thoiGianHoc;
			}
			set
			{
				CanWriteProperty("ThoiGianHoc", true);
				if (value == null) value = string.Empty;
				if (!_thoiGianHoc.Equals(value))
				{
					_thoiGianHoc = value;
					PropertyHasChanged("ThoiGianHoc");
				}
			}
		}

		public int MaHinhThucDaoTao
		{
			get
			{
				CanReadProperty("MaHinhThucDaoTao", true);
				return _maHinhThucDaoTao;
			}
			set
			{
				CanWriteProperty("MaHinhThucDaoTao", true);
				if (!_maHinhThucDaoTao.Equals(value))
				{
					_maHinhThucDaoTao = value;
					PropertyHasChanged("MaHinhThucDaoTao");
				}
			}
		}

		public int MaTruongDaoTao
		{
			get
			{
				CanReadProperty("MaTruongDaoTao", true);
				return _maTruongDaoTao;
			}
			set
			{
				CanWriteProperty("MaTruongDaoTao", true);
				if (!_maTruongDaoTao.Equals(value))
				{
					_maTruongDaoTao = value;
					PropertyHasChanged("MaTruongDaoTao");
				}
			}
		}

		public int MaChuyenNganhDaoTao
		{
			get
			{
				CanReadProperty("MaChuyenNganhDaoTao", true);
				return _maChuyenNganhDaoTao;
			}
			set
			{
				CanWriteProperty("MaChuyenNganhDaoTao", true);
				if (!_maChuyenNganhDaoTao.Equals(value))
				{
					_maChuyenNganhDaoTao = value;
					PropertyHasChanged("MaChuyenNganhDaoTao");
				}
			}
		}

		public int MaTacDongDen
		{
			get
			{
				CanReadProperty("MaTacDongDen", true);
				return _maTacDongDen;
			}
			set
			{
				CanWriteProperty("MaTacDongDen", true);
				if (!_maTacDongDen.Equals(value))
				{
					_maTacDongDen = value;
					PropertyHasChanged("MaTacDongDen");
				}
			}
		}

		public int MaTrinhDoChuyenMon
		{
			get
			{
				CanReadProperty("MaTrinhDoChuyenMon", true);
				return _maTrinhDoChuyenMon;
			}
			set
			{
				CanWriteProperty("MaTrinhDoChuyenMon", true);
				if (!_maTrinhDoChuyenMon.Equals(value))
				{
					_maTrinhDoChuyenMon = value;
					PropertyHasChanged("MaTrinhDoChuyenMon");
				}
			}
		}

		public decimal TongChiPhi
		{
			get
			{
				CanReadProperty("TongChiPhi", true);
				return _tongChiPhi;
			}
			set
			{
				CanWriteProperty("TongChiPhi", true);
				if (!_tongChiPhi.Equals(value))
				{
					_tongChiPhi = value;
					PropertyHasChanged("TongChiPhi");
				}
			}
		}

		public string GhiChu
		{
			get
			{
				CanReadProperty("GhiChu", true);
				return _ghiChu;
			}
			set
			{
				CanWriteProperty("GhiChu", true);
				if (value == null) value = string.Empty;
				if (!_ghiChu.Equals(value))
				{
					_ghiChu = value;
					PropertyHasChanged("GhiChu");
				}
			}
		}

		public long MaNguoiLap
		{
			get
			{
				CanReadProperty("MaNguoiLap", true);
				return _maNguoiLap;
			}
			set
			{
				CanWriteProperty("MaNguoiLap", true);
				if (!_maNguoiLap.Equals(value))
				{
					_maNguoiLap = value;
					PropertyHasChanged("MaNguoiLap");
				}
			}
		}

        public string TenNguoiLap
        {
            get
            {
                CanReadProperty("TenNguoiLap", true);
                return _tenNguoiLap;
            }
        }

		public DateTime NgayLap
		{
			get
			{
				CanReadProperty("NgayLap", true);
				return _ngayLap.Date;
			}
            set
			{
				CanWriteProperty("NgayLap", true);
				
				if (!_ngayLap.Equals(value))
				{
					_ngayLap= new SmartDate(value);
					PropertyHasChanged("NgayLap");
				}
			}
		}		

		public ChiTietQuyetDinhList ChiTietQuyetDinhList
		{
			get
			{
				CanReadProperty("ChiTietQuyetDinhList", true);
				return _chiTietQuyetDinhList;
			}
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _chiTietQuyetDinhList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _chiTietQuyetDinhList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maQuyetDinh;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{
            ////
            //// SoQuyetDinh
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "SoQuyetDinh");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoQuyetDinh", 20));
            ////
            //// NgayKy
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "NgayKyString");
            ////
            //// NguoiKy
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "NguoiKy");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NguoiKy", 200));
            ////
            //// ThoiGianBD
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "ThoiGianBDString");
            ////
            //// ThoiGianKT
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "ThoiGianKTString");
            ////
            //// ThoiGianHoc
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "ThoiGianHoc");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ThoiGianHoc", 20));
            ////
            //// GhiChu
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
            ////
            //// NgayLap
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "NgayLapString");
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
			//TODO: Define authorization rules in QuyetDinhDaoTao
			//AuthorizationRules.AllowRead("ChiTietQuyetDinhList", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("MaQuyetDinh", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("SoQuyetDinh", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("NgayKy", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("NgayKyString", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("NguoiKy", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("ThoiGianBD", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("ThoiGianBDString", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("ThoiGianKT", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("ThoiGianKTString", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("ThoiGianHoc", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("MaHinhThucDaoTao", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("MaTruongDaoTao", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("MaChuyenNganhDaoTao", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("MaTacDongDen", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("MaTrinhDoChuyenMon", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("TongChiPhi", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "QuyetDinhDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "QuyetDinhDaoTaoReadGroup");

			//AuthorizationRules.AllowWrite("SoQuyetDinh", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKyString", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiKy", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("ThoiGianBDString", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("ThoiGianKTString", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("ThoiGianHoc", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaHinhThucDaoTao", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaTruongDaoTao", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaChuyenNganhDaoTao", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaTacDongDen", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaTrinhDoChuyenMon", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("TongChiPhi", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "QuyetDinhDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "QuyetDinhDaoTaoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuyetDinhDaoTao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhDaoTaoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuyetDinhDaoTao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhDaoTaoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuyetDinhDaoTao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhDaoTaoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuyetDinhDaoTao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhDaoTaoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

	    #region Factory Methods
		private QuyetDinhDaoTao()
		{ /* require use of factory method */ }

		public static QuyetDinhDaoTao NewQuyetDinhDaoTao()
		{
            QuyetDinhDaoTao item = new QuyetDinhDaoTao();
            item.MarkAsChild();
            return item;
		}

		public static QuyetDinhDaoTao GetQuyetDinhDaoTao(int maQuyetDinh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuyetDinhDaoTao");
			return DataPortal.Fetch<QuyetDinhDaoTao>(new Criteria(maQuyetDinh));
		}

		public static void DeleteQuyetDinhDaoTao(int maQuyetDinh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuyetDinhDaoTao");
			DataPortal.Delete(new Criteria(maQuyetDinh));
		}

		public override QuyetDinhDaoTao Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuyetDinhDaoTao");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuyetDinhDaoTao");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuyetDinhDaoTao");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuyetDinhDaoTao NewQuyetDinhDaoTaoChild()
		{
			QuyetDinhDaoTao child = new QuyetDinhDaoTao();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuyetDinhDaoTao GetQuyetDinhDaoTao(SafeDataReader dr)
		{
			QuyetDinhDaoTao child =  new QuyetDinhDaoTao();
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
			public int MaQuyetDinh;

			public Criteria(int maQuyetDinh)
			{
				this.MaQuyetDinh = maQuyetDinh;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			//ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsQuyetDinhDaoTao";

				cm.Parameters.AddWithValue("@MaQuyetDinh", criteria.MaQuyetDinh);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(this.MaQuyetDinh);
                    }
				}
			}//using
		}

		#endregion //Data Access - Fetch

		#region Data Access - Insert
		protected override void DataPortal_Insert()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn, null);

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				if (base.IsDirty)
				{
					ExecuteUpdate(cn, null);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maQuyetDinh));
		}

		private void DataPortal_Delete(Criteria criteria)

		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();
                _chiTietQuyetDinhList.Clear();
                UpdateChildren(cn);
				ExecuteDelete(cn, criteria);

			}//using

		}

		private void ExecuteDelete(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsQuyetDinhDaoTao";

				cm.Parameters.AddWithValue("@MaQuyetDinh", criteria.MaQuyetDinh);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			//ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(this.MaQuyetDinh);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maQuyetDinh = dr.GetInt32("MaQuyetDinh");
			_soQuyetDinh = dr.GetString("SoQuyetDinh");
			_ngayKy = dr.GetSmartDate("NgayKy", _ngayKy.EmptyIsMin);
			_nguoiKy = dr.GetInt64("NguoiKy");
			_thoiGianBD = dr.GetSmartDate("ThoiGianBD", _thoiGianBD.EmptyIsMin);
			_thoiGianKT = dr.GetSmartDate("ThoiGianKT", _thoiGianKT.EmptyIsMin);
			_thoiGianHoc = dr.GetString("ThoiGianHoc");
			_maHinhThucDaoTao = dr.GetInt32("MaHinhThucDaoTao");
			_maTruongDaoTao = dr.GetInt32("MaTruongDaoTao");
			_maChuyenNganhDaoTao = dr.GetInt32("MaChuyenNganhDaoTao");
			_maTacDongDen = dr.GetInt32("MaTacDongDen");
			_maTrinhDoChuyenMon = dr.GetInt32("MaTrinhDoChuyenMon");
			_tongChiPhi = dr.GetDecimal("TongChiPhi");
			_ghiChu = dr.GetString("GhiChu");
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
		}

		private void FetchChildren(int maQuyetDinh)
		{			
			_chiTietQuyetDinhList = ChiTietQuyetDinhList.GetChiTietQuyetDinhList(maQuyetDinh);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, QuyetDinhDaoTaoList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, QuyetDinhDaoTaoList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_InserttblnsQuyetDinhDaoTao";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maQuyetDinh = (int)cm.Parameters["@MaQuyetDinh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, QuyetDinhDaoTaoList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
			cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
			cm.Parameters.AddWithValue("@ThoiGianBD", _thoiGianBD.DBValue);
			cm.Parameters.AddWithValue("@ThoiGianKT", _thoiGianKT.DBValue);
			cm.Parameters.AddWithValue("@ThoiGianHoc", _thoiGianHoc);
			cm.Parameters.AddWithValue("@MaHinhThucDaoTao", _maHinhThucDaoTao);
			cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
			cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", _maChuyenNganhDaoTao);
			cm.Parameters.AddWithValue("@MaTacDongDen", _maTacDongDen);
			cm.Parameters.AddWithValue("@MaTrinhDoChuyenMon", _maTrinhDoChuyenMon);
			cm.Parameters.AddWithValue("@TongChiPhi", _tongChiPhi);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);
			cm.Parameters["@MaQuyetDinh"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, QuyetDinhDaoTaoList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn, QuyetDinhDaoTaoList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsQuyetDinhDaoTao";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, QuyetDinhDaoTaoList parent)
		{
			cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);
			cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
			cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
			cm.Parameters.AddWithValue("@ThoiGianBD", _thoiGianBD.DBValue);
			cm.Parameters.AddWithValue("@ThoiGianKT", _thoiGianKT.DBValue);
			cm.Parameters.AddWithValue("@ThoiGianHoc", _thoiGianHoc);
			cm.Parameters.AddWithValue("@MaHinhThucDaoTao", _maHinhThucDaoTao);
			cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
			cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", _maChuyenNganhDaoTao);
			cm.Parameters.AddWithValue("@MaTacDongDen", _maTacDongDen);
			cm.Parameters.AddWithValue("@MaTrinhDoChuyenMon", _maTrinhDoChuyenMon);
			cm.Parameters.AddWithValue("@TongChiPhi", _tongChiPhi);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
		}

		private void UpdateChildren(SqlConnection cn)
		{
			_chiTietQuyetDinhList.Update(cn, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlConnection cn)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            _chiTietQuyetDinhList.Clear();
            UpdateChildren(cn);
			ExecuteDelete(cn, new Criteria(_maQuyetDinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
