
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BaoCaoTongHopThuLao : Csla.ReadOnlyBase<BaoCaoTongHopThuLao>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChuongTrinh = 0;
		private string _tenChuongTrinh = string.Empty;
		private SmartDate _ngayLap = new SmartDate(false);
		private string _maQLBoPhan = string.Empty;
		private string _tenBoPhan = string.Empty;
		private string _maQLNhanVien = string.Empty;
		private string _tenNhanVien = string.Empty;
		private string _tenNguonChuongTrinh = string.Empty;
		private string _maPhieuChi = string.Empty;
		private int _maGiayXacNhan = 0;
		private decimal _soTien = 0;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaChuongTrinh
		{
			get
			{
				return _maChuongTrinh;
			}
		}

		public string TenChuongTrinh
		{
			get
			{
				return _tenChuongTrinh;
			}
		}

		public DateTime NgayLap
		{
			get
			{
				return _ngayLap.Date;
			}
		}

		public string NgayLapString
		{
			get
			{
				return _ngayLap.Text;
			}
		}

		public string MaQLBoPhan
		{
			get
			{
				return _maQLBoPhan;
			}
		}

		public string TenBoPhan
		{
			get
			{
				return _tenBoPhan;
			}
		}

		public string MaQLNhanVien
		{
			get
			{
				return _maQLNhanVien;
			}
		}

		public string TenNhanVien
		{
			get
			{
				return _tenNhanVien;
			}
		}

		public string TenNguonChuongTrinh
		{
			get
			{
				return _tenNguonChuongTrinh;
			}
		}

		public string MaPhieuChi
		{
			get
			{
				return _maPhieuChi;
			}
		}

		public int MaGiayXacNhan
		{
			get
			{
				return _maGiayXacNhan;
			}
		}

		public decimal SoTien
		{
			get
			{
				return _soTien;
			}
		}
 
		protected override object GetIdValue()
		{
			return _maChuongTrinh;
		}

		#endregion //Business Properties and Methods

		#region Factory Methods
		private BaoCaoTongHopThuLao()
		{ /* require use of factory method */ }

		public static BaoCaoTongHopThuLao GetBaoCaoTongHopThuLao(int maChuongTrinh)
		{
			return DataPortal.Fetch<BaoCaoTongHopThuLao>(new Criteria(maChuongTrinh));
		}
		#endregion //Factory Methods


		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaChuongTrinh;

			public Criteria(int maChuongTrinh)
			{
				this.MaChuongTrinh = maChuongTrinh;
			}
		}

		#endregion //Criteria

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
				cm.CommandText = "spd_TongHopThuLaoChuongTrinh";

				cm.Parameters.AddWithValue("@MaChuongTrinh", criteria.MaChuongTrinh);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					FetchObject(dr);

					//load child object(s)
					FetchChildren(dr);
				}
			}//using
		}

		private void FetchObject(SafeDataReader dr)
		{
			dr.Read();
			_maChuongTrinh = dr.GetInt32("MaChuongTrinh");
			_tenChuongTrinh = dr.GetString("TenChuongTrinh");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_maQLBoPhan = dr.GetString("MaQLBoPhan");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_maQLNhanVien = dr.GetString("MaQLNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_tenNguonChuongTrinh = dr.GetString("TenNguonChuongTrinh");
			_maPhieuChi = dr.GetString("MaPhieuChi");
			_maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
			_soTien = dr.GetDecimal("SoTien");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch
		#endregion //Data Access
	}
}
