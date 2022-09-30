using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CCDCDauTienEditableSwitchable : Csla.BusinessBase<CCDCDauTienEditableSwitchable>
	{
		#region Business Properties and Methods

		//declare members
		private int _maCCDC = 0;
		private int _maHangHoa = 0;
		private int _maBoPhan = 0;
		private long _maPhieuNhapXuat = 0;
		private string _maBoPhanQL = string.Empty;
		private string _soChungTu = string.Empty;
		private string _ngayChungTu = string.Empty;
		private string _maQuanLyCCDC = string.Empty;
		private string _tenCCDC = string.Empty;
		private string _serial = string.Empty;
		private string _dvt = string.Empty;
		private decimal _soLuong = 0;
		private decimal _donGia = 0;
		private decimal _giaTriBanDau = 0;
		private decimal _giaTriConLaiTruocPhanBo = 0;
		private decimal _tyLePhanBoKyBaoCaoSoVoiGiaTriBanDau = 0;
		private decimal _giaTriPhanBoDenKyBaoCao = 0;
		private decimal _giaTriConLaiDenKyBaoCao = 0;
		private string _noiDatDe = string.Empty;
		private int _soLuongUpdate = 0;
		private decimal _nguyenGia = 0;
		private string _maQLhanghoa = string.Empty;
		private string _nuocSanXuat = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaCCDC
		{
			get
			{
				CanReadProperty("MaCCDC", true);
				return _maCCDC;
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

		public int MaBoPhan
		{
			get
			{
				CanReadProperty("MaBoPhan", true);
				return _maBoPhan;
			}
			set
			{
				CanWriteProperty("MaBoPhan", true);
				if (!_maBoPhan.Equals(value))
				{
					_maBoPhan = value;
					PropertyHasChanged("MaBoPhan");
				}
			}
		}

		public long MaPhieuNhapXuat
		{
			get
			{
				CanReadProperty("MaPhieuNhapXuat", true);
				return _maPhieuNhapXuat;
			}
			set
			{
				CanWriteProperty("MaPhieuNhapXuat", true);
				if (!_maPhieuNhapXuat.Equals(value))
				{
					_maPhieuNhapXuat = value;
					PropertyHasChanged("MaPhieuNhapXuat");
				}
			}
		}

		public string MaBoPhanQL
		{
			get
			{
				CanReadProperty("MaBoPhanQL", true);
				return _maBoPhanQL;
			}
			set
			{
				CanWriteProperty("MaBoPhanQL", true);
				if (value == null) value = string.Empty;
				if (!_maBoPhanQL.Equals(value))
				{
					_maBoPhanQL = value;
					PropertyHasChanged("MaBoPhanQL");
				}
			}
		}

		public string SoChungTu
		{
			get
			{
				CanReadProperty("SoChungTu", true);
				return _soChungTu;
			}
			set
			{
				CanWriteProperty("SoChungTu", true);
				if (value == null) value = string.Empty;
				if (!_soChungTu.Equals(value))
				{
					_soChungTu = value;
					PropertyHasChanged("SoChungTu");
				}
			}
		}

		public string NgayChungTu
		{
			get
			{
				CanReadProperty("NgayChungTu", true);
				return _ngayChungTu;
			}
			set
			{
				CanWriteProperty("NgayChungTu", true);
				if (value == null) value = string.Empty;
				if (!_ngayChungTu.Equals(value))
				{
					_ngayChungTu = value;
					PropertyHasChanged("NgayChungTu");
				}
			}
		}

		public string MaQuanLyCCDC
		{
			get
			{
				CanReadProperty("MaQuanLyCCDC", true);
				return _maQuanLyCCDC;
			}
			set
			{
				CanWriteProperty("MaQuanLyCCDC", true);
				if (value == null) value = string.Empty;
				if (!_maQuanLyCCDC.Equals(value))
				{
					_maQuanLyCCDC = value;
					PropertyHasChanged("MaQuanLyCCDC");
				}
			}
		}

		public string TenCCDC
		{
			get
			{
				CanReadProperty("TenCCDC", true);
				return _tenCCDC;
			}
			set
			{
				CanWriteProperty("TenCCDC", true);
				if (value == null) value = string.Empty;
				if (!_tenCCDC.Equals(value))
				{
					_tenCCDC = value;
					PropertyHasChanged("TenCCDC");
				}
			}
		}

		public string Serial
		{
			get
			{
				CanReadProperty("Serial", true);
				return _serial;
			}
			set
			{
				CanWriteProperty("Serial", true);
				if (value == null) value = string.Empty;
				if (!_serial.Equals(value))
				{
					_serial = value;
					PropertyHasChanged("Serial");
				}
			}
		}

		public string Dvt
		{
			get
			{
				CanReadProperty("Dvt", true);
				return _dvt;
			}
			set
			{
				CanWriteProperty("Dvt", true);
				if (value == null) value = string.Empty;
				if (!_dvt.Equals(value))
				{
					_dvt = value;
					PropertyHasChanged("Dvt");
				}
			}
		}

		public decimal SoLuong
		{
			get
			{
				CanReadProperty("SoLuong", true);
				return _soLuong;
			}
			set
			{
				CanWriteProperty("SoLuong", true);
				if (!_soLuong.Equals(value))
				{
					_soLuong = value;
					PropertyHasChanged("SoLuong");
				}
			}
		}

		public decimal DonGia
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

		public decimal GiaTriBanDau
		{
			get
			{
				CanReadProperty("GiaTriBanDau", true);
				return _giaTriBanDau;
			}
			set
			{
				CanWriteProperty("GiaTriBanDau", true);
				if (!_giaTriBanDau.Equals(value))
				{
					_giaTriBanDau = value;
					PropertyHasChanged("GiaTriBanDau");
				}
			}
		}

		public decimal GiaTriConLaiTruocPhanBo
		{
			get
			{
				CanReadProperty("GiaTriConLaiTruocPhanBo", true);
				return _giaTriConLaiTruocPhanBo;
			}
			set
			{
				CanWriteProperty("GiaTriConLaiTruocPhanBo", true);
				if (!_giaTriConLaiTruocPhanBo.Equals(value))
				{
					_giaTriConLaiTruocPhanBo = value;
					PropertyHasChanged("GiaTriConLaiTruocPhanBo");
				}
			}
		}

		public decimal TyLePhanBoKyBaoCaoSoVoiGiaTriBanDau
		{
			get
			{
				CanReadProperty("TyLePhanBoKyBaoCaoSoVoiGiaTriBanDau", true);
				return _tyLePhanBoKyBaoCaoSoVoiGiaTriBanDau;
			}
			set
			{
				CanWriteProperty("TyLePhanBoKyBaoCaoSoVoiGiaTriBanDau", true);
				if (!_tyLePhanBoKyBaoCaoSoVoiGiaTriBanDau.Equals(value))
				{
					_tyLePhanBoKyBaoCaoSoVoiGiaTriBanDau = value;
					PropertyHasChanged("TyLePhanBoKyBaoCaoSoVoiGiaTriBanDau");
				}
			}
		}

		public decimal GiaTriPhanBoDenKyBaoCao
		{
			get
			{
				CanReadProperty("GiaTriPhanBoDenKyBaoCao", true);
				return _giaTriPhanBoDenKyBaoCao;
			}
			set
			{
				CanWriteProperty("GiaTriPhanBoDenKyBaoCao", true);
				if (!_giaTriPhanBoDenKyBaoCao.Equals(value))
				{
					_giaTriPhanBoDenKyBaoCao = value;
					PropertyHasChanged("GiaTriPhanBoDenKyBaoCao");
				}
			}
		}

		public decimal GiaTriConLaiDenKyBaoCao
		{
			get
			{
				CanReadProperty("GiaTriConLaiDenKyBaoCao", true);
				return _giaTriConLaiDenKyBaoCao;
			}
			set
			{
				CanWriteProperty("GiaTriConLaiDenKyBaoCao", true);
				if (!_giaTriConLaiDenKyBaoCao.Equals(value))
				{
					_giaTriConLaiDenKyBaoCao = value;
					PropertyHasChanged("GiaTriConLaiDenKyBaoCao");
				}
			}
		}

		public string NoiDatDe
		{
			get
			{
				CanReadProperty("NoiDatDe", true);
				return _noiDatDe;
			}
			set
			{
				CanWriteProperty("NoiDatDe", true);
				if (value == null) value = string.Empty;
				if (!_noiDatDe.Equals(value))
				{
					_noiDatDe = value;
					PropertyHasChanged("NoiDatDe");
				}
			}
		}

		public int SoLuongUpdate
		{
			get
			{
				CanReadProperty("SoLuongUpdate", true);
				return _soLuongUpdate;
			}
			set
			{
				CanWriteProperty("SoLuongUpdate", true);
				if (!_soLuongUpdate.Equals(value))
				{
					_soLuongUpdate = value;
					PropertyHasChanged("SoLuongUpdate");
				}
			}
		}

		public decimal NguyenGia
		{
			get
			{
				CanReadProperty("NguyenGia", true);
				return _nguyenGia;
			}
			set
			{
				CanWriteProperty("NguyenGia", true);
				if (!_nguyenGia.Equals(value))
				{
					_nguyenGia = value;
					PropertyHasChanged("NguyenGia");
				}
			}
		}

		public string MaQLhanghoa
		{
			get
			{
				CanReadProperty("MaQLhanghoa", true);
				return _maQLhanghoa;
			}
			set
			{
				CanWriteProperty("MaQLhanghoa", true);
				if (value == null) value = string.Empty;
				if (!_maQLhanghoa.Equals(value))
				{
					_maQLhanghoa = value;
					PropertyHasChanged("MaQLhanghoa");
				}
			}
		}

		public string NuocSanXuat
		{
			get
			{
				CanReadProperty("NuocSanXuat", true);
				return _nuocSanXuat;
			}
			set
			{
				CanWriteProperty("NuocSanXuat", true);
				if (value == null) value = string.Empty;
				if (!_nuocSanXuat.Equals(value))
				{
					_nuocSanXuat = value;
					PropertyHasChanged("NuocSanXuat");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maCCDC;
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
			// MaQLhanghoa
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLhanghoa", 100));
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
			//TODO: Define authorization rules in CCDCDauTienEditableSwitchable
			//AuthorizationRules.AllowRead("MaCCDC", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhan", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("MaPhieuNhapXuat", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhanQL", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("SoChungTu", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("NgayChungTu", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLyCCDC", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("TenCCDC", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("Serial", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("Dvt", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("SoLuong", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("DonGia", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("GiaTriBanDau", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("GiaTriConLaiTruocPhanBo", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("TyLePhanBoKyBaoCaoSoVoiGiaTriBanDau", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("GiaTriPhanBoDenKyBaoCao", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("GiaTriConLaiDenKyBaoCao", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("NoiDatDe", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("SoLuongUpdate", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("NguyenGia", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("MaQLhanghoa", "CCDCDauTienEditableSwitchableReadGroup");
			//AuthorizationRules.AllowRead("NuocSanXuat", "CCDCDauTienEditableSwitchableReadGroup");

			//AuthorizationRules.AllowWrite("MaHangHoa", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhan", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhieuNhapXuat", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhanQL", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("SoChungTu", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("NgayChungTu", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanLyCCDC", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("TenCCDC", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("Serial", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("Dvt", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuong", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("DonGia", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("GiaTriBanDau", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("GiaTriConLaiTruocPhanBo", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("TyLePhanBoKyBaoCaoSoVoiGiaTriBanDau", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("GiaTriPhanBoDenKyBaoCao", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("GiaTriConLaiDenKyBaoCao", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("NoiDatDe", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuongUpdate", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("NguyenGia", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("MaQLhanghoa", "CCDCDauTienEditableSwitchableWriteGroup");
			//AuthorizationRules.AllowWrite("NuocSanXuat", "CCDCDauTienEditableSwitchableWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CCDCDauTienEditableSwitchable
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CCDCDauTienEditableSwitchableViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CCDCDauTienEditableSwitchable
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CCDCDauTienEditableSwitchableAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CCDCDauTienEditableSwitchable
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CCDCDauTienEditableSwitchableEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CCDCDauTienEditableSwitchable
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CCDCDauTienEditableSwitchableDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CCDCDauTienEditableSwitchable()
		{ /* require use of factory method */ }

		public static CCDCDauTienEditableSwitchable NewCCDCDauTienEditableSwitchable(int maCCDC)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CCDCDauTienEditableSwitchable");
			return DataPortal.Create<CCDCDauTienEditableSwitchable>(new Criteria(maCCDC));
		}

		public static CCDCDauTienEditableSwitchable GetCCDCDauTienEditableSwitchable(int maCCDC)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CCDCDauTienEditableSwitchable");
			return DataPortal.Fetch<CCDCDauTienEditableSwitchable>(new Criteria(maCCDC));
		}

		public static void DeleteCCDCDauTienEditableSwitchable(int maCCDC)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CCDCDauTienEditableSwitchable");
			DataPortal.Delete(new Criteria(maCCDC));
		}

		public override CCDCDauTienEditableSwitchable Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CCDCDauTienEditableSwitchable");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CCDCDauTienEditableSwitchable");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a CCDCDauTienEditableSwitchable");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
        //private CCDCDauTienEditableSwitchable()
        //{
        //}

		internal static CCDCDauTienEditableSwitchable NewCCDCDauTienEditableSwitchableChild()
		{
			CCDCDauTienEditableSwitchable child = new CCDCDauTienEditableSwitchable();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static CCDCDauTienEditableSwitchable GetCCDCDauTienEditableSwitchable(SafeDataReader dr)
		{
			CCDCDauTienEditableSwitchable child =  new CCDCDauTienEditableSwitchable();
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
			public int MaCCDC;

			public Criteria(int maCCDC)
			{
				this.MaCCDC = maCCDC;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maCCDC = criteria.MaCCDC;
			ValidationRules.CheckRules();
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
                cm.CommandText = "spd_SelecttblCCDCDauTien";

				cm.Parameters.AddWithValue("@MaCCDC", criteria.MaCCDC);

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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn);

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
					ExecuteUpdate(cn);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maCCDC));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteDelete(cn, criteria);

			}//using

		}

		private void ExecuteDelete(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "DeleteCCDCDauTienEditableSwitchable";

				cm.Parameters.AddWithValue("@MaCCDC", criteria.MaCCDC);

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
			_maCCDC = dr.GetInt32("MaCCDC");
			_maHangHoa = dr.GetInt32("MaHangHoa");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_maPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
			_maBoPhanQL = dr.GetString("MaBoPhanQL");
			_soChungTu = dr.GetString("SoChungTu");
			_ngayChungTu = dr.GetString("NgayChungTu");
			_maQuanLyCCDC = dr.GetString("MaQuanLyCCDC");
			_tenCCDC = dr.GetString("TenCCDC");
			_serial = dr.GetString("SERIAL");
			_dvt = dr.GetString("DVT");
			_soLuong = dr.GetDecimal("SoLuong");
			_donGia = dr.GetDecimal("DonGia");
			_giaTriBanDau = dr.GetDecimal("GiaTriBanDau");
			_giaTriConLaiTruocPhanBo = dr.GetDecimal("GiaTriConLaiTruocPhanBo");
			_tyLePhanBoKyBaoCaoSoVoiGiaTriBanDau = dr.GetDecimal("TyLePhanBoKyBaoCaoSoVoiGiaTriBanDau");
			_giaTriPhanBoDenKyBaoCao = dr.GetDecimal("GiaTriPhanBoDenKyBaoCao");
			_giaTriConLaiDenKyBaoCao = dr.GetDecimal("GiaTriConLaiDenKyBaoCao");
			_noiDatDe = dr.GetString("NoiDatDe");
			_soLuongUpdate = dr.GetInt32("SoLuongUpdate");
			_nguyenGia = dr.GetDecimal("NguyenGia");
			_maQLhanghoa = dr.GetString("MaQLhanghoa");
			_nuocSanXuat = dr.GetString("NuocSanXuat");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddCCDCDauTienEditableSwitchable";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaCCDC", _maCCDC);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_maPhieuNhapXuat != 0)
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
			else
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
			if (_maBoPhanQL.Length > 0)
				cm.Parameters.AddWithValue("@MaBoPhanQL", _maBoPhanQL);
			else
				cm.Parameters.AddWithValue("@MaBoPhanQL", DBNull.Value);
			if (_soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			if (_ngayChungTu.Length > 0)
				cm.Parameters.AddWithValue("@NgayChungTu", _ngayChungTu);
			else
				cm.Parameters.AddWithValue("@NgayChungTu", DBNull.Value);
			if (_maQuanLyCCDC.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLyCCDC", _maQuanLyCCDC);
			else
				cm.Parameters.AddWithValue("@MaQuanLyCCDC", DBNull.Value);
			if (_tenCCDC.Length > 0)
				cm.Parameters.AddWithValue("@TenCCDC", _tenCCDC);
			else
				cm.Parameters.AddWithValue("@TenCCDC", DBNull.Value);
			if (_serial.Length > 0)
				cm.Parameters.AddWithValue("@SERIAL", _serial);
			else
				cm.Parameters.AddWithValue("@SERIAL", DBNull.Value);
			if (_dvt.Length > 0)
				cm.Parameters.AddWithValue("@DVT", _dvt);
			else
				cm.Parameters.AddWithValue("@DVT", DBNull.Value);
			if (_soLuong != 0)
				cm.Parameters.AddWithValue("@SoLuong", _soLuong);
			else
				cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
			if (_donGia != 0)
				cm.Parameters.AddWithValue("@DonGia", _donGia);
			else
				cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
			if (_giaTriBanDau != 0)
				cm.Parameters.AddWithValue("@GiaTriBanDau", _giaTriBanDau);
			else
				cm.Parameters.AddWithValue("@GiaTriBanDau", DBNull.Value);
			if (_giaTriConLaiTruocPhanBo != 0)
				cm.Parameters.AddWithValue("@GiaTriConLaiTruocPhanBo", _giaTriConLaiTruocPhanBo);
			else
				cm.Parameters.AddWithValue("@GiaTriConLaiTruocPhanBo", DBNull.Value);
			if (_tyLePhanBoKyBaoCaoSoVoiGiaTriBanDau != 0)
				cm.Parameters.AddWithValue("@TyLePhanBoKyBaoCaoSoVoiGiaTriBanDau", _tyLePhanBoKyBaoCaoSoVoiGiaTriBanDau);
			else
				cm.Parameters.AddWithValue("@TyLePhanBoKyBaoCaoSoVoiGiaTriBanDau", DBNull.Value);
			if (_giaTriPhanBoDenKyBaoCao != 0)
				cm.Parameters.AddWithValue("@GiaTriPhanBoDenKyBaoCao", _giaTriPhanBoDenKyBaoCao);
			else
				cm.Parameters.AddWithValue("@GiaTriPhanBoDenKyBaoCao", DBNull.Value);
			if (_giaTriConLaiDenKyBaoCao != 0)
				cm.Parameters.AddWithValue("@GiaTriConLaiDenKyBaoCao", _giaTriConLaiDenKyBaoCao);
			else
				cm.Parameters.AddWithValue("@GiaTriConLaiDenKyBaoCao", DBNull.Value);
			if (_noiDatDe.Length > 0)
				cm.Parameters.AddWithValue("@NoiDatDe", _noiDatDe);
			else
				cm.Parameters.AddWithValue("@NoiDatDe", DBNull.Value);
			if (_soLuongUpdate != 0)
				cm.Parameters.AddWithValue("@SoLuongUpdate", _soLuongUpdate);
			else
				cm.Parameters.AddWithValue("@SoLuongUpdate", DBNull.Value);
			if (_nguyenGia != 0)
				cm.Parameters.AddWithValue("@NguyenGia", _nguyenGia);
			else
				cm.Parameters.AddWithValue("@NguyenGia", DBNull.Value);
			if (_maQLhanghoa.Length > 0)
				cm.Parameters.AddWithValue("@MaQLhanghoa", _maQLhanghoa);
			else
				cm.Parameters.AddWithValue("@MaQLhanghoa", DBNull.Value);
			if (_nuocSanXuat.Length > 0)
				cm.Parameters.AddWithValue("@NuocSanXuat", _nuocSanXuat);
			else
				cm.Parameters.AddWithValue("@NuocSanXuat", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCCDCDauTien";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaCCDC", _maCCDC);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_maPhieuNhapXuat != 0)
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
			else
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
			if (_maBoPhanQL.Length > 0)
				cm.Parameters.AddWithValue("@MaBoPhanQL", _maBoPhanQL);
			else
				cm.Parameters.AddWithValue("@MaBoPhanQL", DBNull.Value);
			if (_soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			if (_ngayChungTu.Length > 0)
				cm.Parameters.AddWithValue("@NgayChungTu", _ngayChungTu);
			else
				cm.Parameters.AddWithValue("@NgayChungTu", DBNull.Value);
			if (_maQuanLyCCDC.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLyCCDC", _maQuanLyCCDC);
			else
				cm.Parameters.AddWithValue("@MaQuanLyCCDC", DBNull.Value);
			if (_tenCCDC.Length > 0)
				cm.Parameters.AddWithValue("@TenCCDC", _tenCCDC);
			else
				cm.Parameters.AddWithValue("@TenCCDC", DBNull.Value);
			if (_serial.Length > 0)
				cm.Parameters.AddWithValue("@SERIAL", _serial);
			else
				cm.Parameters.AddWithValue("@SERIAL", DBNull.Value);
			if (_dvt.Length > 0)
				cm.Parameters.AddWithValue("@DVT", _dvt);
			else
				cm.Parameters.AddWithValue("@DVT", DBNull.Value);
			if (_soLuong != 0)
				cm.Parameters.AddWithValue("@SoLuong", _soLuong);
			else
				cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
			if (_donGia != 0)
				cm.Parameters.AddWithValue("@DonGia", _donGia);
			else
				cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
			if (_giaTriBanDau != 0)
				cm.Parameters.AddWithValue("@GiaTriBanDau", _giaTriBanDau);
			else
				cm.Parameters.AddWithValue("@GiaTriBanDau", DBNull.Value);
			if (_giaTriConLaiTruocPhanBo != 0)
				cm.Parameters.AddWithValue("@GiaTriConLaiTruocPhanBo", _giaTriConLaiTruocPhanBo);
			else
				cm.Parameters.AddWithValue("@GiaTriConLaiTruocPhanBo", DBNull.Value);
			if (_tyLePhanBoKyBaoCaoSoVoiGiaTriBanDau != 0)
				cm.Parameters.AddWithValue("@TyLePhanBoKyBaoCaoSoVoiGiaTriBanDau", _tyLePhanBoKyBaoCaoSoVoiGiaTriBanDau);
			else
				cm.Parameters.AddWithValue("@TyLePhanBoKyBaoCaoSoVoiGiaTriBanDau", DBNull.Value);
			if (_giaTriPhanBoDenKyBaoCao != 0)
				cm.Parameters.AddWithValue("@GiaTriPhanBoDenKyBaoCao", _giaTriPhanBoDenKyBaoCao);
			else
				cm.Parameters.AddWithValue("@GiaTriPhanBoDenKyBaoCao", DBNull.Value);
			if (_giaTriConLaiDenKyBaoCao != 0)
				cm.Parameters.AddWithValue("@GiaTriConLaiDenKyBaoCao", _giaTriConLaiDenKyBaoCao);
			else
				cm.Parameters.AddWithValue("@GiaTriConLaiDenKyBaoCao", DBNull.Value);
			if (_noiDatDe.Length > 0)
				cm.Parameters.AddWithValue("@NoiDatDe", _noiDatDe);
			else
				cm.Parameters.AddWithValue("@NoiDatDe", DBNull.Value);
			if (_soLuongUpdate != 0)
				cm.Parameters.AddWithValue("@SoLuongUpdate", _soLuongUpdate);
			else
				cm.Parameters.AddWithValue("@SoLuongUpdate", DBNull.Value);
			if (_nguyenGia != 0)
				cm.Parameters.AddWithValue("@NguyenGia", _nguyenGia);
			else
				cm.Parameters.AddWithValue("@NguyenGia", DBNull.Value);
			if (_maQLhanghoa.Length > 0)
				cm.Parameters.AddWithValue("@MaQLhanghoa", _maQLhanghoa);
			else
				cm.Parameters.AddWithValue("@MaQLhanghoa", DBNull.Value);
			if (_nuocSanXuat.Length > 0)
				cm.Parameters.AddWithValue("@NuocSanXuat", _nuocSanXuat);
			else
				cm.Parameters.AddWithValue("@NuocSanXuat", DBNull.Value);
		}

		private void UpdateChildren(SqlConnection cn)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlConnection cn)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(cn, new Criteria(_maCCDC));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
