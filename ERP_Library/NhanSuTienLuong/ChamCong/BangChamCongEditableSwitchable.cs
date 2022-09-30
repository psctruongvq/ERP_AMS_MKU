
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangChamCong_New : Csla.BusinessBase<BangChamCong_New>
	{
		#region Business Properties and Methods

		//declare members
		private int _thang = 0;
		private int _nam = 0;
		private long _maNhanVien = 0;
		private string _tenNhanVien = string.Empty;
		private int _maBoPhan = 0;
		private string _tenBoPhan = string.Empty;
		private int _soNgayDiLam = 0;
		private int _nghiKhongLuong = 0;
		private int _nghiBaoHiem = 0;
        private decimal _heSoLuong = 0;
		private string _ngay1 = string.Empty;
		private string _ngay2 = string.Empty;
		private string _ngay3 = string.Empty;
		private string _ngay4 = string.Empty;
		private string _ngay5 = string.Empty;
		private string _ngay6 = string.Empty;
		private string _ngay7 = string.Empty;
		private string _ngay8 = string.Empty;
		private string _ngay9 = string.Empty;
		private string _ngay10 = string.Empty;
		private string _ngay11 = string.Empty;
		private string _ngay12 = string.Empty;
		private string _ngay13 = string.Empty;
		private string _ngay14 = string.Empty;
		private string _ngay15 = string.Empty;
		private string _ngay16 = string.Empty;
		private string _ngay17 = string.Empty;
		private string _ngay18 = string.Empty;
		private string _ngay19 = string.Empty;
		private string _ngay20 = string.Empty;
		private string _ngay21 = string.Empty;
		private string _ngay22 = string.Empty;
		private string _ngay23 = string.Empty;
		private string _ngay24 = string.Empty;
		private string _ngay25 = string.Empty;
		private string _ngay26 = string.Empty;
		private string _ngay27 = string.Empty;
		private string _ngay28 = string.Empty;
		private string _ngay29 = string.Empty;
		private string _ngay30 = string.Empty;
		private string _ngay31 = string.Empty;
		private int _isle1 = 0;
		private int _isle2 = 0;
		private int _isle3 = 0;
		private int _isle4 = 0;
		private int _isle5 = 0;
		private int _isle6 = 0;
		private int _isle7 = 0;
		private int _isle8 = 0;
		private int _isle9 = 0;
		private int _isle10 = 0;
		private int _isle11 = 0;
		private int _isle12 = 0;
		private int _isle13 = 0;
		private int _isle14 = 0;
		private int _isle15 = 0;
		private int _isle16 = 0;
		private int _isle17 = 0;
		private int _isle18 = 0;
		private int _isle19 = 0;
		private int _isle20 = 0;
		private int _isle21 = 0;
		private int _isle22 = 0;
		private int _isle23 = 0;
		private int _isle24 = 0;
		private int _isle25 = 0;
		private int _isle26 = 0;
		private int _isle27 = 0;
		private int _isle28 = 0;
		private int _isle29 = 0;
		private int _isle30 = 0;
		private int _isle31 = 0;
		private int _isbu1 = 0;
		private int _isbu2 = 0;
		private int _isbu3 = 0;
		private int _isbu4 = 0;
		private int _isbu5 = 0;
		private int _isbu6 = 0;
		private int _isbu7 = 0;
		private int _isbu8 = 0;
		private int _isbu9 = 0;
		private int _isbu10 = 0;
		private int _isbu11 = 0;
		private int _isbu12 = 0;
		private int _isbu13 = 0;
		private int _isbu14 = 0;
		private int _isbu15 = 0;
		private int _isbu16 = 0;
		private int _isbu17 = 0;
		private int _isbu18 = 0;
		private int _isbu19 = 0;
		private int _isbu20 = 0;
		private int _isbu21 = 0;
		private int _isbu22 = 0;
		private int _isbu23 = 0;
		private int _isbu24 = 0;
		private int _isbu25 = 0;
		private int _isbu26 = 0;
		private int _isbu27 = 0;
		private int _isbu28 = 0;
		private int _isbu29 = 0;
		private int _isbu30 = 0;
		private int _isbu31 = 0;
		private string _tenNgay1 = string.Empty;
		private string _tenNgay2 = string.Empty;
		private string _tenNgay3 = string.Empty;
		private string _tenNgay4 = string.Empty;
		private string _tenNgay5 = string.Empty;
		private string _tenNgay6 = string.Empty;
		private string _tenNgay7 = string.Empty;
		private string _tenNgay8 = string.Empty;
		private string _tenNgay9 = string.Empty;
		private string _tenNgay10 = string.Empty;
		private string _tenNgay11 = string.Empty;
		private string _tenNgay12 = string.Empty;
		private string _tenNgay13 = string.Empty;
		private string _tenNgay14 = string.Empty;
		private string _tenNgay15 = string.Empty;
		private string _tenNgay16 = string.Empty;
		private string _tenNgay17 = string.Empty;
		private string _tenNgay18 = string.Empty;
		private string _tenNgay19 = string.Empty;
		private string _tenNgay20 = string.Empty;
		private string _tenNgay21 = string.Empty;
		private string _tenNgay22 = string.Empty;
		private string _tenNgay23 = string.Empty;
		private string _tenNgay24 = string.Empty;
		private string _tenNgay25 = string.Empty;
		private string _tenNgay26 = string.Empty;
		private string _tenNgay27 = string.Empty;
		private string _tenNgay28 = string.Empty;
		private string _tenNgay29 = string.Empty;
		private string _tenNgay30 = string.Empty;
		private string _tenNgay31 = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
		public int Thang
		{
			get
			{
				CanReadProperty("Thang", true);
				return _thang;
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public int Nam
		{
			get
			{
				CanReadProperty("Nam", true);
				return _nam;
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaNhanVien
		{
			get
			{
				CanReadProperty("MaNhanVien", true);
				return _maNhanVien;
			}
		}

		public string TenNhanVien
		{
			get
			{
				CanReadProperty("TenNhanVien", true);
				return _tenNhanVien;
			}
			set
			{
				CanWriteProperty("TenNhanVien", true);
				if (value == null) value = string.Empty;
				if (!_tenNhanVien.Equals(value))
				{
					_tenNhanVien = value;
					PropertyHasChanged("TenNhanVien");
				}
			}
		}

        public decimal HeSoLuong
        {
            get
            {
                CanReadProperty("HeSoLuong", true);
                return _heSoLuong;
            }
            set
            {
                CanWriteProperty("HeSoLuong", true);
                if (!_heSoLuong.Equals(value))
                {
                    _heSoLuong = value;
                    PropertyHasChanged("HeSoLuong");
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

		public string TenBoPhan
		{
			get
			{
				CanReadProperty("TenBoPhan", true);
				return _tenBoPhan;
			}
			set
			{
				CanWriteProperty("TenBoPhan", true);
				if (value == null) value = string.Empty;
				if (!_tenBoPhan.Equals(value))
				{
					_tenBoPhan = value;
					PropertyHasChanged("TenBoPhan");
				}
			}
		}

		public int SoNgayDiLam
		{
			get
			{
				CanReadProperty("SoNgayDiLam", true);
				return _soNgayDiLam;
			}
			set
			{
				CanWriteProperty("SoNgayDiLam", true);
				if (!_soNgayDiLam.Equals(value))
				{
					_soNgayDiLam = value;
					PropertyHasChanged("SoNgayDiLam");
				}
			}
		}

		public int NghiKhongLuong
		{
			get
			{
				CanReadProperty("NghiKhongLuong", true);
				return _nghiKhongLuong;
			}
			set
			{
				CanWriteProperty("NghiKhongLuong", true);
				if (!_nghiKhongLuong.Equals(value))
				{
					_nghiKhongLuong = value;
					PropertyHasChanged("NghiKhongLuong");
				}
			}
		}

		public int NghiBaoHiem
		{
			get
			{
				CanReadProperty("NghiBaoHiem", true);
				return _nghiBaoHiem;
			}
			set
			{
				CanWriteProperty("NghiBaoHiem", true);
				if (!_nghiBaoHiem.Equals(value))
				{
					_nghiBaoHiem = value;
					PropertyHasChanged("NghiBaoHiem");
				}
			}
		}

		public string Ngay_1
		{
			get
			{
				CanReadProperty("Ngay_1", true);
				return _ngay1;
			}
			set
			{
				CanWriteProperty("Ngay_1", true);
				if (value == null) value = string.Empty;
				if (!_ngay1.Equals(value))
				{
					_ngay1 = value;
					PropertyHasChanged("Ngay_1");
				}
			}
		}

		public string Ngay_2
		{
			get
			{
				CanReadProperty("Ngay_2", true);
				return _ngay2;
			}
			set
			{
				CanWriteProperty("Ngay_2", true);
				if (value == null) value = string.Empty;
				if (!_ngay2.Equals(value))
				{
					_ngay2 = value;
					PropertyHasChanged("Ngay_2");
				}
			}
		}

		public string Ngay_3
		{
			get
			{
				CanReadProperty("Ngay_3", true);
				return _ngay3;
			}
			set
			{
				CanWriteProperty("Ngay_3", true);
				if (value == null) value = string.Empty;
				if (!_ngay3.Equals(value))
				{
					_ngay3 = value;
					PropertyHasChanged("Ngay_3");
				}
			}
		}

		public string Ngay_4
		{
			get
			{
				CanReadProperty("Ngay_4", true);
				return _ngay4;
			}
			set
			{
				CanWriteProperty("Ngay_4", true);
				if (value == null) value = string.Empty;
				if (!_ngay4.Equals(value))
				{
					_ngay4 = value;
					PropertyHasChanged("Ngay_4");
				}
			}
		}

		public string Ngay_5
		{
			get
			{
				CanReadProperty("Ngay_5", true);
				return _ngay5;
			}
			set
			{
				CanWriteProperty("Ngay_5", true);
				if (value == null) value = string.Empty;
				if (!_ngay5.Equals(value))
				{
					_ngay5 = value;
					PropertyHasChanged("Ngay_5");
				}
			}
		}

		public string Ngay_6
		{
			get
			{
				CanReadProperty("Ngay_6", true);
				return _ngay6;
			}
			set
			{
				CanWriteProperty("Ngay_6", true);
				if (value == null) value = string.Empty;
				if (!_ngay6.Equals(value))
				{
					_ngay6 = value;
					PropertyHasChanged("Ngay_6");
				}
			}
		}

		public string Ngay_7
		{
			get
			{
				CanReadProperty("Ngay_7", true);
				return _ngay7;
			}
			set
			{
				CanWriteProperty("Ngay_7", true);
				if (value == null) value = string.Empty;
				if (!_ngay7.Equals(value))
				{
					_ngay7 = value;
					PropertyHasChanged("Ngay_7");
				}
			}
		}

		public string Ngay_8
		{
			get
			{
				CanReadProperty("Ngay_8", true);
				return _ngay8;
			}
			set
			{
				CanWriteProperty("Ngay_8", true);
				if (value == null) value = string.Empty;
				if (!_ngay8.Equals(value))
				{
					_ngay8 = value;
					PropertyHasChanged("Ngay_8");
				}
			}
		}

		public string Ngay_9
		{
			get
			{
				CanReadProperty("Ngay_9", true);
				return _ngay9;
			}
			set
			{
				CanWriteProperty("Ngay_9", true);
				if (value == null) value = string.Empty;
				if (!_ngay9.Equals(value))
				{
					_ngay9 = value;
					PropertyHasChanged("Ngay_9");
				}
			}
		}

		public string Ngay_10
		{
			get
			{
				CanReadProperty("Ngay_10", true);
				return _ngay10;
			}
			set
			{
				CanWriteProperty("Ngay_10", true);
				if (value == null) value = string.Empty;
				if (!_ngay10.Equals(value))
				{
					_ngay10 = value;
					PropertyHasChanged("Ngay_10");
				}
			}
		}

		public string Ngay_11
		{
			get
			{
				CanReadProperty("Ngay_11", true);
				return _ngay11;
			}
			set
			{
				CanWriteProperty("Ngay_11", true);
				if (value == null) value = string.Empty;
				if (!_ngay11.Equals(value))
				{
					_ngay11 = value;
					PropertyHasChanged("Ngay_11");
				}
			}
		}

		public string Ngay_12
		{
			get
			{
				CanReadProperty("Ngay_12", true);
				return _ngay12;
			}
			set
			{
				CanWriteProperty("Ngay_12", true);
				if (value == null) value = string.Empty;
				if (!_ngay12.Equals(value))
				{
					_ngay12 = value;
					PropertyHasChanged("Ngay_12");
				}
			}
		}

		public string Ngay_13
		{
			get
			{
				CanReadProperty("Ngay_13", true);
				return _ngay13;
			}
			set
			{
				CanWriteProperty("Ngay_13", true);
				if (value == null) value = string.Empty;
				if (!_ngay13.Equals(value))
				{
					_ngay13 = value;
					PropertyHasChanged("Ngay_13");
				}
			}
		}

		public string Ngay_14
		{
			get
			{
				CanReadProperty("Ngay_14", true);
				return _ngay14;
			}
			set
			{
				CanWriteProperty("Ngay_14", true);
				if (value == null) value = string.Empty;
				if (!_ngay14.Equals(value))
				{
					_ngay14 = value;
					PropertyHasChanged("Ngay_14");
				}
			}
		}

		public string Ngay_15
		{
			get
			{
				CanReadProperty("Ngay_15", true);
				return _ngay15;
			}
			set
			{
				CanWriteProperty("Ngay_15", true);
				if (value == null) value = string.Empty;
				if (!_ngay15.Equals(value))
				{
					_ngay15 = value;
					PropertyHasChanged("Ngay_15");
				}
			}
		}

		public string Ngay_16
		{
			get
			{
				CanReadProperty("Ngay_16", true);
				return _ngay16;
			}
			set
			{
				CanWriteProperty("Ngay_16", true);
				if (value == null) value = string.Empty;
				if (!_ngay16.Equals(value))
				{
					_ngay16 = value;
					PropertyHasChanged("Ngay_16");
				}
			}
		}

		public string Ngay_17
		{
			get
			{
				CanReadProperty("Ngay_17", true);
				return _ngay17;
			}
			set
			{
				CanWriteProperty("Ngay_17", true);
				if (value == null) value = string.Empty;
				if (!_ngay17.Equals(value))
				{
					_ngay17 = value;
					PropertyHasChanged("Ngay_17");
				}
			}
		}

		public string Ngay_18
		{
			get
			{
				CanReadProperty("Ngay_18", true);
				return _ngay18;
			}
			set
			{
				CanWriteProperty("Ngay_18", true);
				if (value == null) value = string.Empty;
				if (!_ngay18.Equals(value))
				{
					_ngay18 = value;
					PropertyHasChanged("Ngay_18");
				}
			}
		}

		public string Ngay_19
		{
			get
			{
				CanReadProperty("Ngay_19", true);
				return _ngay19;
			}
			set
			{
				CanWriteProperty("Ngay_19", true);
				if (value == null) value = string.Empty;
				if (!_ngay19.Equals(value))
				{
					_ngay19 = value;
					PropertyHasChanged("Ngay_19");
				}
			}
		}

		public string Ngay_20
		{
			get
			{
				CanReadProperty("Ngay_20", true);
				return _ngay20;
			}
			set
			{
				CanWriteProperty("Ngay_20", true);
				if (value == null) value = string.Empty;
				if (!_ngay20.Equals(value))
				{
					_ngay20 = value;
					PropertyHasChanged("Ngay_20");
				}
			}
		}

		public string Ngay_21
		{
			get
			{
				CanReadProperty("Ngay_21", true);
				return _ngay21;
			}
			set
			{
				CanWriteProperty("Ngay_21", true);
				if (value == null) value = string.Empty;
				if (!_ngay21.Equals(value))
				{
					_ngay21 = value;
					PropertyHasChanged("Ngay_21");
				}
			}
		}

		public string Ngay_22
		{
			get
			{
				CanReadProperty("Ngay_22", true);
				return _ngay22;
			}
			set
			{
				CanWriteProperty("Ngay_22", true);
				if (value == null) value = string.Empty;
				if (!_ngay22.Equals(value))
				{
					_ngay22 = value;
					PropertyHasChanged("Ngay_22");
				}
			}
		}

		public string Ngay_23
		{
			get
			{
				CanReadProperty("Ngay_23", true);
				return _ngay23;
			}
			set
			{
				CanWriteProperty("Ngay_23", true);
				if (value == null) value = string.Empty;
				if (!_ngay23.Equals(value))
				{
					_ngay23 = value;
					PropertyHasChanged("Ngay_23");
				}
			}
		}

		public string Ngay_24
		{
			get
			{
				CanReadProperty("Ngay_24", true);
				return _ngay24;
			}
			set
			{
				CanWriteProperty("Ngay_24", true);
				if (value == null) value = string.Empty;
				if (!_ngay24.Equals(value))
				{
					_ngay24 = value;
					PropertyHasChanged("Ngay_24");
				}
			}
		}

		public string Ngay_25
		{
			get
			{
				CanReadProperty("Ngay_25", true);
				return _ngay25;
			}
			set
			{
				CanWriteProperty("Ngay_25", true);
				if (value == null) value = string.Empty;
				if (!_ngay25.Equals(value))
				{
					_ngay25 = value;
					PropertyHasChanged("Ngay_25");
				}
			}
		}

		public string Ngay_26
		{
			get
			{
				CanReadProperty("Ngay_26", true);
				return _ngay26;
			}
			set
			{
				CanWriteProperty("Ngay_26", true);
				if (value == null) value = string.Empty;
				if (!_ngay26.Equals(value))
				{
					_ngay26 = value;
					PropertyHasChanged("Ngay_26");
				}
			}
		}

		public string Ngay_27
		{
			get
			{
				CanReadProperty("Ngay_27", true);
				return _ngay27;
			}
			set
			{
				CanWriteProperty("Ngay_27", true);
				if (value == null) value = string.Empty;
				if (!_ngay27.Equals(value))
				{
					_ngay27 = value;
					PropertyHasChanged("Ngay_27");
				}
			}
		}

		public string Ngay_28
		{
			get
			{
				CanReadProperty("Ngay_28", true);
				return _ngay28;
			}
			set
			{
				CanWriteProperty("Ngay_28", true);
				if (value == null) value = string.Empty;
				if (!_ngay28.Equals(value))
				{
					_ngay28 = value;
					PropertyHasChanged("Ngay_28");
				}
			}
		}

		public string Ngay_29
		{
			get
			{
				CanReadProperty("Ngay_29", true);
				return _ngay29;
			}
			set
			{
				CanWriteProperty("Ngay_29", true);
				if (value == null) value = string.Empty;
				if (!_ngay29.Equals(value))
				{
					_ngay29 = value;
					PropertyHasChanged("Ngay_29");
				}
			}
		}

		public string Ngay_30
		{
			get
			{
				CanReadProperty("Ngay_30", true);
				return _ngay30;
			}
			set
			{
				CanWriteProperty("Ngay_30", true);
				if (value == null) value = string.Empty;
				if (!_ngay30.Equals(value))
				{
					_ngay30 = value;
					PropertyHasChanged("Ngay_30");
				}
			}
		}

		public string Ngay_31
		{
			get
			{
				CanReadProperty("Ngay_31", true);
				return _ngay31;
			}
			set
			{
				CanWriteProperty("Ngay_31", true);
				if (value == null) value = string.Empty;
				if (!_ngay31.Equals(value))
				{
					_ngay31 = value;
					PropertyHasChanged("Ngay_31");
				}
			}
		}

		public int IsLe_1
		{
			get
			{
				CanReadProperty("IsLe_1", true);
				return _isle1;
			}
			set
			{
				CanWriteProperty("IsLe_1", true);
				if (!_isle1.Equals(value))
				{
					_isle1 = value;
					PropertyHasChanged("IsLe_1");
				}
			}
		}

		public int IsLe_2
		{
			get
			{
				CanReadProperty("IsLe_2", true);
				return _isle2;
			}
			set
			{
				CanWriteProperty("IsLe_2", true);
				if (!_isle2.Equals(value))
				{
					_isle2 = value;
					PropertyHasChanged("IsLe_2");
				}
			}
		}

		public int IsLe_3
		{
			get
			{
				CanReadProperty("IsLe_3", true);
				return _isle3;
			}
			set
			{
				CanWriteProperty("IsLe_3", true);
				if (!_isle3.Equals(value))
				{
					_isle3 = value;
					PropertyHasChanged("IsLe_3");
				}
			}
		}

		public int IsLe_4
		{
			get
			{
				CanReadProperty("IsLe_4", true);
				return _isle4;
			}
			set
			{
				CanWriteProperty("IsLe_4", true);
				if (!_isle4.Equals(value))
				{
					_isle4 = value;
					PropertyHasChanged("IsLe_4");
				}
			}
		}

		public int IsLe_5
		{
			get
			{
				CanReadProperty("IsLe_5", true);
				return _isle5;
			}
			set
			{
				CanWriteProperty("IsLe_5", true);
				if (!_isle5.Equals(value))
				{
					_isle5 = value;
					PropertyHasChanged("IsLe_5");
				}
			}
		}

		public int IsLe_6
		{
			get
			{
				CanReadProperty("IsLe_6", true);
				return _isle6;
			}
			set
			{
				CanWriteProperty("IsLe_6", true);
				if (!_isle6.Equals(value))
				{
					_isle6 = value;
					PropertyHasChanged("IsLe_6");
				}
			}
		}

		public int IsLe_7
		{
			get
			{
				CanReadProperty("IsLe_7", true);
				return _isle7;
			}
			set
			{
				CanWriteProperty("IsLe_7", true);
				if (!_isle7.Equals(value))
				{
					_isle7 = value;
					PropertyHasChanged("IsLe_7");
				}
			}
		}

		public int IsLe_8
		{
			get
			{
				CanReadProperty("IsLe_8", true);
				return _isle8;
			}
			set
			{
				CanWriteProperty("IsLe_8", true);
				if (!_isle8.Equals(value))
				{
					_isle8 = value;
					PropertyHasChanged("IsLe_8");
				}
			}
		}

		public int IsLe_9
		{
			get
			{
				CanReadProperty("IsLe_9", true);
				return _isle9;
			}
			set
			{
				CanWriteProperty("IsLe_9", true);
				if (!_isle9.Equals(value))
				{
					_isle9 = value;
					PropertyHasChanged("IsLe_9");
				}
			}
		}

		public int IsLe_10
		{
			get
			{
				CanReadProperty("IsLe_10", true);
				return _isle10;
			}
			set
			{
				CanWriteProperty("IsLe_10", true);
				if (!_isle10.Equals(value))
				{
					_isle10 = value;
					PropertyHasChanged("IsLe_10");
				}
			}
		}

		public int IsLe_11
		{
			get
			{
				CanReadProperty("IsLe_11", true);
				return _isle11;
			}
			set
			{
				CanWriteProperty("IsLe_11", true);
				if (!_isle11.Equals(value))
				{
					_isle11 = value;
					PropertyHasChanged("IsLe_11");
				}
			}
		}

		public int IsLe_12
		{
			get
			{
				CanReadProperty("IsLe_12", true);
				return _isle12;
			}
			set
			{
				CanWriteProperty("IsLe_12", true);
				if (!_isle12.Equals(value))
				{
					_isle12 = value;
					PropertyHasChanged("IsLe_12");
				}
			}
		}

		public int IsLe_13
		{
			get
			{
				CanReadProperty("IsLe_13", true);
				return _isle13;
			}
			set
			{
				CanWriteProperty("IsLe_13", true);
				if (!_isle13.Equals(value))
				{
					_isle13 = value;
					PropertyHasChanged("IsLe_13");
				}
			}
		}

		public int IsLe_14
		{
			get
			{
				CanReadProperty("IsLe_14", true);
				return _isle14;
			}
			set
			{
				CanWriteProperty("IsLe_14", true);
				if (!_isle14.Equals(value))
				{
					_isle14 = value;
					PropertyHasChanged("IsLe_14");
				}
			}
		}

		public int IsLe_15
		{
			get
			{
				CanReadProperty("IsLe_15", true);
				return _isle15;
			}
			set
			{
				CanWriteProperty("IsLe_15", true);
				if (!_isle15.Equals(value))
				{
					_isle15 = value;
					PropertyHasChanged("IsLe_15");
				}
			}
		}

		public int IsLe_16
		{
			get
			{
				CanReadProperty("IsLe_16", true);
				return _isle16;
			}
			set
			{
				CanWriteProperty("IsLe_16", true);
				if (!_isle16.Equals(value))
				{
					_isle16 = value;
					PropertyHasChanged("IsLe_16");
				}
			}
		}

		public int IsLe_17
		{
			get
			{
				CanReadProperty("IsLe_17", true);
				return _isle17;
			}
			set
			{
				CanWriteProperty("IsLe_17", true);
				if (!_isle17.Equals(value))
				{
					_isle17 = value;
					PropertyHasChanged("IsLe_17");
				}
			}
		}

		public int IsLe_18
		{
			get
			{
				CanReadProperty("IsLe_18", true);
				return _isle18;
			}
			set
			{
				CanWriteProperty("IsLe_18", true);
				if (!_isle18.Equals(value))
				{
					_isle18 = value;
					PropertyHasChanged("IsLe_18");
				}
			}
		}

		public int IsLe_19
		{
			get
			{
				CanReadProperty("IsLe_19", true);
				return _isle19;
			}
			set
			{
				CanWriteProperty("IsLe_19", true);
				if (!_isle19.Equals(value))
				{
					_isle19 = value;
					PropertyHasChanged("IsLe_19");
				}
			}
		}

		public int IsLe_20
		{
			get
			{
				CanReadProperty("IsLe_20", true);
				return _isle20;
			}
			set
			{
				CanWriteProperty("IsLe_20", true);
				if (!_isle20.Equals(value))
				{
					_isle20 = value;
					PropertyHasChanged("IsLe_20");
				}
			}
		}

		public int IsLe_21
		{
			get
			{
				CanReadProperty("IsLe_21", true);
				return _isle21;
			}
			set
			{
				CanWriteProperty("IsLe_21", true);
				if (!_isle21.Equals(value))
				{
					_isle21 = value;
					PropertyHasChanged("IsLe_21");
				}
			}
		}

		public int IsLe_22
		{
			get
			{
				CanReadProperty("IsLe_22", true);
				return _isle22;
			}
			set
			{
				CanWriteProperty("IsLe_22", true);
				if (!_isle22.Equals(value))
				{
					_isle22 = value;
					PropertyHasChanged("IsLe_22");
				}
			}
		}

		public int IsLe_23
		{
			get
			{
				CanReadProperty("IsLe_23", true);
				return _isle23;
			}
			set
			{
				CanWriteProperty("IsLe_23", true);
				if (!_isle23.Equals(value))
				{
					_isle23 = value;
					PropertyHasChanged("IsLe_23");
				}
			}
		}

		public int IsLe_24
		{
			get
			{
				CanReadProperty("IsLe_24", true);
				return _isle24;
			}
			set
			{
				CanWriteProperty("IsLe_24", true);
				if (!_isle24.Equals(value))
				{
					_isle24 = value;
					PropertyHasChanged("IsLe_24");
				}
			}
		}

		public int IsLe_25
		{
			get
			{
				CanReadProperty("IsLe_25", true);
				return _isle25;
			}
			set
			{
				CanWriteProperty("IsLe_25", true);
				if (!_isle25.Equals(value))
				{
					_isle25 = value;
					PropertyHasChanged("IsLe_25");
				}
			}
		}

		public int IsLe_26
		{
			get
			{
				CanReadProperty("IsLe_26", true);
				return _isle26;
			}
			set
			{
				CanWriteProperty("IsLe_26", true);
				if (!_isle26.Equals(value))
				{
					_isle26 = value;
					PropertyHasChanged("IsLe_26");
				}
			}
		}

		public int IsLe_27
		{
			get
			{
				CanReadProperty("IsLe_27", true);
				return _isle27;
			}
			set
			{
				CanWriteProperty("IsLe_27", true);
				if (!_isle27.Equals(value))
				{
					_isle27 = value;
					PropertyHasChanged("IsLe_27");
				}
			}
		}

		public int IsLe_28
		{
			get
			{
				CanReadProperty("IsLe_28", true);
				return _isle28;
			}
			set
			{
				CanWriteProperty("IsLe_28", true);
				if (!_isle28.Equals(value))
				{
					_isle28 = value;
					PropertyHasChanged("IsLe_28");
				}
			}
		}

		public int IsLe_29
		{
			get
			{
				CanReadProperty("IsLe_29", true);
				return _isle29;
			}
			set
			{
				CanWriteProperty("IsLe_29", true);
				if (!_isle29.Equals(value))
				{
					_isle29 = value;
					PropertyHasChanged("IsLe_29");
				}
			}
		}

		public int IsLe_30
		{
			get
			{
				CanReadProperty("IsLe_30", true);
				return _isle30;
			}
			set
			{
				CanWriteProperty("IsLe_30", true);
				if (!_isle30.Equals(value))
				{
					_isle30 = value;
					PropertyHasChanged("IsLe_30");
				}
			}
		}

		public int IsLe_31
		{
			get
			{
				CanReadProperty("IsLe_31", true);
				return _isle31;
			}
			set
			{
				CanWriteProperty("IsLe_31", true);
				if (!_isle31.Equals(value))
				{
					_isle31 = value;
					PropertyHasChanged("IsLe_31");
				}
			}
		}

		public int IsBu_1
		{
			get
			{
				CanReadProperty("IsBu_1", true);
				return _isbu1;
			}
			set
			{
				CanWriteProperty("IsBu_1", true);
				if (!_isbu1.Equals(value))
				{
					_isbu1 = value;
					PropertyHasChanged("IsBu_1");
				}
			}
		}

		public int IsBu_2
		{
			get
			{
				CanReadProperty("IsBu_2", true);
				return _isbu2;
			}
			set
			{
				CanWriteProperty("IsBu_2", true);
				if (!_isbu2.Equals(value))
				{
					_isbu2 = value;
					PropertyHasChanged("IsBu_2");
				}
			}
		}

		public int IsBu_3
		{
			get
			{
				CanReadProperty("IsBu_3", true);
				return _isbu3;
			}
			set
			{
				CanWriteProperty("IsBu_3", true);
				if (!_isbu3.Equals(value))
				{
					_isbu3 = value;
					PropertyHasChanged("IsBu_3");
				}
			}
		}

		public int IsBu_4
		{
			get
			{
				CanReadProperty("IsBu_4", true);
				return _isbu4;
			}
			set
			{
				CanWriteProperty("IsBu_4", true);
				if (!_isbu4.Equals(value))
				{
					_isbu4 = value;
					PropertyHasChanged("IsBu_4");
				}
			}
		}

		public int IsBu_5
		{
			get
			{
				CanReadProperty("IsBu_5", true);
				return _isbu5;
			}
			set
			{
				CanWriteProperty("IsBu_5", true);
				if (!_isbu5.Equals(value))
				{
					_isbu5 = value;
					PropertyHasChanged("IsBu_5");
				}
			}
		}

		public int IsBu_6
		{
			get
			{
				CanReadProperty("IsBu_6", true);
				return _isbu6;
			}
			set
			{
				CanWriteProperty("IsBu_6", true);
				if (!_isbu6.Equals(value))
				{
					_isbu6 = value;
					PropertyHasChanged("IsBu_6");
				}
			}
		}

		public int IsBu_7
		{
			get
			{
				CanReadProperty("IsBu_7", true);
				return _isbu7;
			}
			set
			{
				CanWriteProperty("IsBu_7", true);
				if (!_isbu7.Equals(value))
				{
					_isbu7 = value;
					PropertyHasChanged("IsBu_7");
				}
			}
		}

		public int IsBu_8
		{
			get
			{
				CanReadProperty("IsBu_8", true);
				return _isbu8;
			}
			set
			{
				CanWriteProperty("IsBu_8", true);
				if (!_isbu8.Equals(value))
				{
					_isbu8 = value;
					PropertyHasChanged("IsBu_8");
				}
			}
		}

		public int IsBu_9
		{
			get
			{
				CanReadProperty("IsBu_9", true);
				return _isbu9;
			}
			set
			{
				CanWriteProperty("IsBu_9", true);
				if (!_isbu9.Equals(value))
				{
					_isbu9 = value;
					PropertyHasChanged("IsBu_9");
				}
			}
		}

		public int IsBu_10
		{
			get
			{
				CanReadProperty("IsBu_10", true);
				return _isbu10;
			}
			set
			{
				CanWriteProperty("IsBu_10", true);
				if (!_isbu10.Equals(value))
				{
					_isbu10 = value;
					PropertyHasChanged("IsBu_10");
				}
			}
		}

		public int IsBu_11
		{
			get
			{
				CanReadProperty("IsBu_11", true);
				return _isbu11;
			}
			set
			{
				CanWriteProperty("IsBu_11", true);
				if (!_isbu11.Equals(value))
				{
					_isbu11 = value;
					PropertyHasChanged("IsBu_11");
				}
			}
		}

		public int IsBu_12
		{
			get
			{
				CanReadProperty("IsBu_12", true);
				return _isbu12;
			}
			set
			{
				CanWriteProperty("IsBu_12", true);
				if (!_isbu12.Equals(value))
				{
					_isbu12 = value;
					PropertyHasChanged("IsBu_12");
				}
			}
		}

		public int IsBu_13
		{
			get
			{
				CanReadProperty("IsBu_13", true);
				return _isbu13;
			}
			set
			{
				CanWriteProperty("IsBu_13", true);
				if (!_isbu13.Equals(value))
				{
					_isbu13 = value;
					PropertyHasChanged("IsBu_13");
				}
			}
		}

		public int IsBu_14
		{
			get
			{
				CanReadProperty("IsBu_14", true);
				return _isbu14;
			}
			set
			{
				CanWriteProperty("IsBu_14", true);
				if (!_isbu14.Equals(value))
				{
					_isbu14 = value;
					PropertyHasChanged("IsBu_14");
				}
			}
		}

		public int IsBu_15
		{
			get
			{
				CanReadProperty("IsBu_15", true);
				return _isbu15;
			}
			set
			{
				CanWriteProperty("IsBu_15", true);
				if (!_isbu15.Equals(value))
				{
					_isbu15 = value;
					PropertyHasChanged("IsBu_15");
				}
			}
		}

		public int IsBu_16
		{
			get
			{
				CanReadProperty("IsBu_16", true);
				return _isbu16;
			}
			set
			{
				CanWriteProperty("IsBu_16", true);
				if (!_isbu16.Equals(value))
				{
					_isbu16 = value;
					PropertyHasChanged("IsBu_16");
				}
			}
		}

		public int IsBu_17
		{
			get
			{
				CanReadProperty("IsBu_17", true);
				return _isbu17;
			}
			set
			{
				CanWriteProperty("IsBu_17", true);
				if (!_isbu17.Equals(value))
				{
					_isbu17 = value;
					PropertyHasChanged("IsBu_17");
				}
			}
		}

		public int IsBu_18
		{
			get
			{
				CanReadProperty("IsBu_18", true);
				return _isbu18;
			}
			set
			{
				CanWriteProperty("IsBu_18", true);
				if (!_isbu18.Equals(value))
				{
					_isbu18 = value;
					PropertyHasChanged("IsBu_18");
				}
			}
		}

		public int IsBu_19
		{
			get
			{
				CanReadProperty("IsBu_19", true);
				return _isbu19;
			}
			set
			{
				CanWriteProperty("IsBu_19", true);
				if (!_isbu19.Equals(value))
				{
					_isbu19 = value;
					PropertyHasChanged("IsBu_19");
				}
			}
		}

		public int IsBu_20
		{
			get
			{
				CanReadProperty("IsBu_20", true);
				return _isbu20;
			}
			set
			{
				CanWriteProperty("IsBu_20", true);
				if (!_isbu20.Equals(value))
				{
					_isbu20 = value;
					PropertyHasChanged("IsBu_20");
				}
			}
		}

		public int IsBu_21
		{
			get
			{
				CanReadProperty("IsBu_21", true);
				return _isbu21;
			}
			set
			{
				CanWriteProperty("IsBu_21", true);
				if (!_isbu21.Equals(value))
				{
					_isbu21 = value;
					PropertyHasChanged("IsBu_21");
				}
			}
		}

		public int IsBu_22
		{
			get
			{
				CanReadProperty("IsBu_22", true);
				return _isbu22;
			}
			set
			{
				CanWriteProperty("IsBu_22", true);
				if (!_isbu22.Equals(value))
				{
					_isbu22 = value;
					PropertyHasChanged("IsBu_22");
				}
			}
		}

		public int IsBu_23
		{
			get
			{
				CanReadProperty("IsBu_23", true);
				return _isbu23;
			}
			set
			{
				CanWriteProperty("IsBu_23", true);
				if (!_isbu23.Equals(value))
				{
					_isbu23 = value;
					PropertyHasChanged("IsBu_23");
				}
			}
		}

		public int IsBu_24
		{
			get
			{
				CanReadProperty("IsBu_24", true);
				return _isbu24;
			}
			set
			{
				CanWriteProperty("IsBu_24", true);
				if (!_isbu24.Equals(value))
				{
					_isbu24 = value;
					PropertyHasChanged("IsBu_24");
				}
			}
		}

		public int IsBu_25
		{
			get
			{
				CanReadProperty("IsBu_25", true);
				return _isbu25;
			}
			set
			{
				CanWriteProperty("IsBu_25", true);
				if (!_isbu25.Equals(value))
				{
					_isbu25 = value;
					PropertyHasChanged("IsBu_25");
				}
			}
		}

		public int IsBu_26
		{
			get
			{
				CanReadProperty("IsBu_26", true);
				return _isbu26;
			}
			set
			{
				CanWriteProperty("IsBu_26", true);
				if (!_isbu26.Equals(value))
				{
					_isbu26 = value;
					PropertyHasChanged("IsBu_26");
				}
			}
		}

		public int IsBu_27
		{
			get
			{
				CanReadProperty("IsBu_27", true);
				return _isbu27;
			}
			set
			{
				CanWriteProperty("IsBu_27", true);
				if (!_isbu27.Equals(value))
				{
					_isbu27 = value;
					PropertyHasChanged("IsBu_27");
				}
			}
		}

		public int IsBu_28
		{
			get
			{
				CanReadProperty("IsBu_28", true);
				return _isbu28;
			}
			set
			{
				CanWriteProperty("IsBu_28", true);
				if (!_isbu28.Equals(value))
				{
					_isbu28 = value;
					PropertyHasChanged("IsBu_28");
				}
			}
		}

		public int IsBu_29
		{
			get
			{
				CanReadProperty("IsBu_29", true);
				return _isbu29;
			}
			set
			{
				CanWriteProperty("IsBu_29", true);
				if (!_isbu29.Equals(value))
				{
					_isbu29 = value;
					PropertyHasChanged("IsBu_29");
				}
			}
		}

		public int IsBu_30
		{
			get
			{
				CanReadProperty("IsBu_30", true);
				return _isbu30;
			}
			set
			{
				CanWriteProperty("IsBu_30", true);
				if (!_isbu30.Equals(value))
				{
					_isbu30 = value;
					PropertyHasChanged("IsBu_30");
				}
			}
		}

		public int IsBu_31
		{
			get
			{
				CanReadProperty("IsBu__31", true);
				return _isbu31;
			}
			set
			{
				CanWriteProperty("IsBu__31", true);
				if (!_isbu31.Equals(value))
				{
					_isbu31 = value;
					PropertyHasChanged("IsBu__31");
				}
			}
		}

		public string Ten_Ngay_1
		{
			get
			{
				CanReadProperty("Ten_Ngay_1", true);
				return _tenNgay1;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_1", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay1.Equals(value))
				{
					_tenNgay1 = value;
                    PropertyHasChanged("Ten_Ngay_1");
				}
			}
		}

		public string Ten_Ngay_2
		{
			get
			{
				CanReadProperty("Ten_Ngay_2", true);
				return _tenNgay2;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_2", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay2.Equals(value))
				{
					_tenNgay2 = value;
					PropertyHasChanged("Ten_Ngay_2");
				}
			}
		}

		public string Ten_Ngay_3
		{
			get
			{
				CanReadProperty("Ten_Ngay_3", true);
				return _tenNgay3;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_3", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay3.Equals(value))
				{
					_tenNgay3 = value;
					PropertyHasChanged("Ten_Ngay_3");
				}
			}
		}

		public string Ten_Ngay_4
		{
			get
			{
				CanReadProperty("Ten_Ngay_4", true);
				return _tenNgay4;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_4", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay4.Equals(value))
				{
					_tenNgay4 = value;
					PropertyHasChanged("Ten_Ngay_4");
				}
			}
		}

		public string Ten_Ngay_5
		{
			get
			{
				CanReadProperty("Ten_Ngay_5", true);
				return _tenNgay5;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_5", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay5.Equals(value))
				{
					_tenNgay5 = value;
					PropertyHasChanged("Ten_Ngay_5");
				}
			}
		}

		public string Ten_Ngay_6
		{
			get
			{
				CanReadProperty("Ten_Ngay_6", true);
				return _tenNgay6;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_6", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay6.Equals(value))
				{
					_tenNgay6 = value;
					PropertyHasChanged("Ten_Ngay_6");
				}
			}
		}

		public string Ten_Ngay_7
		{
			get
			{
				CanReadProperty("Ten_Ngay_7", true);
				return _tenNgay7;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_7", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay7.Equals(value))
				{
					_tenNgay7 = value;
					PropertyHasChanged("Ten_Ngay_7");
				}
			}
		}

		public string Ten_Ngay_8
		{
			get
			{
				CanReadProperty("Ten_Ngay_8", true);
				return _tenNgay8;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_8", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay8.Equals(value))
				{
					_tenNgay8 = value;
					PropertyHasChanged("Ten_Ngay_8");
				}
			}
		}

		public string Ten_Ngay_9
		{
			get
			{
				CanReadProperty("Ten_Ngay_9", true);
				return _tenNgay9;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_9", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay9.Equals(value))
				{
					_tenNgay9 = value;
					PropertyHasChanged("Ten_Ngay_9");
				}
			}
		}

		public string Ten_Ngay_10
		{
			get
			{
				CanReadProperty("Ten_Ngay_10", true);
				return _tenNgay10;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_10", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay10.Equals(value))
				{
					_tenNgay10 = value;
					PropertyHasChanged("Ten_Ngay_10");
				}
			}
		}

		public string Ten_Ngay_11
		{
			get
			{
				CanReadProperty("Ten_Ngay_11", true);
				return _tenNgay11;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_11", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay11.Equals(value))
				{
					_tenNgay11 = value;
					PropertyHasChanged("Ten_Ngay_11");
				}
			}
		}

		public string Ten_Ngay_12
		{
			get
			{
				CanReadProperty("Ten_Ngay_12", true);
				return _tenNgay12;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_12", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay12.Equals(value))
				{
					_tenNgay12 = value;
					PropertyHasChanged("Ten_Ngay_12");
				}
			}
		}

		public string Ten_Ngay_13
		{
			get
			{
				CanReadProperty("Ten_Ngay_13", true);
				return _tenNgay13;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_13", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay13.Equals(value))
				{
					_tenNgay13 = value;
					PropertyHasChanged("Ten_Ngay_13");
				}
			}
		}

		public string Ten_Ngay_14
		{
			get
			{
				CanReadProperty("Ten_Ngay_14", true);
				return _tenNgay14;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_14", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay14.Equals(value))
				{
					_tenNgay14 = value;
					PropertyHasChanged("Ten_Ngay_14");
				}
			}
		}

		public string Ten_Ngay_15
		{
			get
			{
				CanReadProperty("Ten_Ngay_15", true);
				return _tenNgay15;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_15", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay15.Equals(value))
				{
					_tenNgay15 = value;
					PropertyHasChanged("Ten_Ngay_15");
				}
			}
		}

		public string Ten_Ngay_16
		{
			get
			{
				CanReadProperty("Ten_Ngay_16", true);
				return _tenNgay16;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_16", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay16.Equals(value))
				{
					_tenNgay16 = value;
					PropertyHasChanged("Ten_Ngay_16");
				}
			}
		}

		public string Ten_Ngay_17
		{
			get
			{
				CanReadProperty("Ten_Ngay_17", true);
				return _tenNgay17;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_17", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay17.Equals(value))
				{
					_tenNgay17 = value;
					PropertyHasChanged("Ten_Ngay_17");
				}
			}
		}

		public string Ten_Ngay_18
		{
			get
			{
				CanReadProperty("Ten_Ngay_18", true);
				return _tenNgay18;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_18", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay18.Equals(value))
				{
					_tenNgay18 = value;
					PropertyHasChanged("Ten_Ngay_18");
				}
			}
		}

		public string Ten_Ngay_19
		{
			get
			{
				CanReadProperty("Ten_Ngay_19", true);
				return _tenNgay19;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_19", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay19.Equals(value))
				{
					_tenNgay19 = value;
					PropertyHasChanged("Ten_Ngay_19");
				}
			}
		}

		public string Ten_Ngay_20
		{
			get
			{
				CanReadProperty("Ten_Ngay_20", true);
				return _tenNgay20;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_20", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay20.Equals(value))
				{
					_tenNgay20 = value;
					PropertyHasChanged("Ten_Ngay_20");
				}
			}
		}

		public string Ten_Ngay_21
		{
			get
			{
				CanReadProperty("Ten_Ngay_21", true);
				return _tenNgay21;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_21", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay21.Equals(value))
				{
					_tenNgay21 = value;
					PropertyHasChanged("Ten_Ngay_21");
				}
			}
		}

		public string Ten_Ngay_22
		{
			get
			{
				CanReadProperty("Ten_Ngay_22", true);
				return _tenNgay22;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_22", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay22.Equals(value))
				{
					_tenNgay22 = value;
					PropertyHasChanged("Ten_Ngay_22");
				}
			}
		}

		public string Ten_Ngay_23
		{
			get
			{
				CanReadProperty("Ten_Ngay_23", true);
				return _tenNgay23;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_23", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay23.Equals(value))
				{
					_tenNgay23 = value;
					PropertyHasChanged("Ten_Ngay_23");
				}
			}
		}

		public string Ten_Ngay_24
		{
			get
			{
				CanReadProperty("Ten_Ngay_24", true);
				return _tenNgay24;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_24", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay24.Equals(value))
				{
					_tenNgay24 = value;
					PropertyHasChanged("Ten_Ngay_24");
				}
			}
		}

		public string Ten_Ngay_25
		{
			get
			{
				CanReadProperty("Ten_Ngay_25", true);
				return _tenNgay25;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_25", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay25.Equals(value))
				{
					_tenNgay25 = value;
					PropertyHasChanged("Ten_Ngay_25");
				}
			}
		}

		public string Ten_Ngay_26
		{
			get
			{
				CanReadProperty("Ten_Ngay_26", true);
				return _tenNgay26;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_26", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay26.Equals(value))
				{
					_tenNgay26 = value;
					PropertyHasChanged("Ten_Ngay_26");
				}
			}
		}

		public string Ten_Ngay_27
		{
			get
			{
				CanReadProperty("Ten_Ngay_27", true);
				return _tenNgay27;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_27", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay27.Equals(value))
				{
					_tenNgay27 = value;
					PropertyHasChanged("Ten_Ngay_27");
				}
			}
		}

		public string Ten_Ngay_28
		{
			get
			{
				CanReadProperty("Ten_Ngay_28", true);
				return _tenNgay28;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_28", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay28.Equals(value))
				{
					_tenNgay28 = value;
					PropertyHasChanged("Ten_Ngay_28");
				}
			}
		}

		public string Ten_Ngay_29
		{
			get
			{
				CanReadProperty("Ten_Ngay_29", true);
				return _tenNgay29;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_29", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay29.Equals(value))
				{
					_tenNgay29 = value;
					PropertyHasChanged("Ten_Ngay_29");
				}
			}
		}

		public string Ten_Ngay_30
		{
			get
			{
				CanReadProperty("Ten_Ngay_30", true);
				return _tenNgay30;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_30", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay30.Equals(value))
				{
					_tenNgay30 = value;
					PropertyHasChanged("Ten_Ngay_30");
				}
			}
		}

		public string Ten_Ngay_31
		{
			get
			{
				CanReadProperty("Ten_Ngay_31", true);
				return _tenNgay31;
			}
			set
			{
				CanWriteProperty("Ten_Ngay_31", true);
				if (value == null) value = string.Empty;
				if (!_tenNgay31.Equals(value))
				{
					_tenNgay31 = value;
					PropertyHasChanged("Ten_Ngay_31");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return string.Format("{0}:{1}:{2}", _thang, _nam, _maNhanVien);
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
			// TenNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 500));
			//
			// TenBoPhan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 200));
			//
			// Ngay1
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_1", 10));
			//
			// Ngay2
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_2", 10));
			//
			// Ngay3
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_3", 10));
			//
			// Ngay4
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_4", 10));
			//
			// Ngay5
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_5", 10));
			//
			// Ngay6
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_6", 10));
			//
			// Ngay7
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_7", 10));
			//
			// Ngay8
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_8", 10));
			//
			// Ngay9
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_9", 10));
			//
			// Ngay10
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_10", 10));
			//
			// Ngay11
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_11", 10));
			//
			// Ngay12
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_12", 10));
			//
			// Ngay13
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_13", 10));
			//
			// Ngay14
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_14", 10));
			//
			// Ngay15
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_15", 10));
			//
			// Ngay16
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_16", 10));
			//
			// Ngay17
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_17", 10));
			//
			// Ngay18
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_18", 10));
			//
			// Ngay19
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_19", 10));
			//
			// Ngay20
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_20", 10));
			//
			// Ngay21
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_21", 10));
			//
			// Ngay22
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_22", 10));
			//
			// Ngay23
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_23", 10));
			//
			// Ngay24
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_24", 10));
			//
			// Ngay25
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_25", 10));
			//
			// Ngay26
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_26", 10));
			//
			// Ngay27
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_27", 10));
			//
			// Ngay28
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_28", 10));
			//
			// Ngay29
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_29", 10));
			//
			// Ngay30
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_30", 10));
			//
			// Ngay31
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ngay_31", 10));
			//
			// TenNgay1
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_1", 30));
			//
			// TenNgay2
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_2", 30));
			//
			// TenNgay3
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_3", 30));
			//
			// TenNgay4
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_4", 30));
			//
			// TenNgay5
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_5", 30));
			//
			// TenNgay6
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_6", 30));
			//
			// TenNgay7
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_7", 30));
			//
			// TenNgay8
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_8", 30));
			//
			// TenNgay9
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_9", 30));
			//
			// TenNgay10
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_10", 30));
			//
			// TenNgay11
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_11", 30));
			//
			// TenNgay12
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_12", 30));
			//
			// TenNgay13
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_13", 30));
			//
			// TenNgay14
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_14", 30));
			//
			// TenNgay15
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_15", 30));
			//
			// TenNgay16
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_16", 30));
			//
			// TenNgay17
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_17", 30));
			//
			// TenNgay18
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_18", 30));
			//
			// TenNgay19
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_19", 30));
			//
			// TenNgay20
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_20", 30));
			//
			// TenNgay21
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_21", 30));
			//
			// TenNgay22
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_22", 30));
			//
			// TenNgay23
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_23", 30));
			//
			// TenNgay24
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_24", 30));
			//
			// TenNgay25
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_25", 30));
			//
			// TenNgay26
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_26", 30));
			//
			// TenNgay27
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_27", 30));
			//
			// TenNgay28
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_28", 30));
			//
			// TenNgay29
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_29", 30));
			//
			// TenNgay30
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_30", 30));
			//
			// TenNgay31
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten_Ngay_31", 30));
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
			//TODO: Define authorization rules in BangChamCong_New
			//AuthorizationRules.AllowRead("Thang", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Nam", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("TenNhanVien", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhan", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("TenBoPhan", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("SoNgayDiLam", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("NghiKhongLuong", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("NghiBaoHiem", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_1", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_2", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_3", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_4", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_5", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_6", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_7", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_8", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_9", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_10", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_11", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_12", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_13", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_14", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_15", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_16", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_17", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_18", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_19", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_20", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_21", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_22", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_23", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_24", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_25", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_26", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_27", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_28", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_29", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_30", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ngay_31", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_1", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_2", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_3", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_4", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_5", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_6", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_7", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_8", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_9", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_10", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_11", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_12", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_13", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_14", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_15", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_16", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_17", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_18", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_19", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_20", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_21", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_22", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_23", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_24", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_25", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_26", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_27", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_28", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_29", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_30", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsLe_31", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_1", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_2", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_3", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_4", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_5", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_6", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_7", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_8", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_9", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_10", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_11", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_12", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_13", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_14", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_15", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_16", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_17", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_18", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_19", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_20", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_21", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_22", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_23", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_24", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_25", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_26", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_27", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_28", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_29", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_30", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("IsBu_31", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_1", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_2", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_3", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_4", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_5", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_6", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_7", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_8", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_9", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_10", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_11", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_12", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_13", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_14", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_15", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_16", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_17", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_18", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_19", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_20", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_21", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_22", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_23", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_24", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_25", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_26", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_27", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_28", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_29", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_30", "BangChamCong_NewReadGroup");
			//AuthorizationRules.AllowRead("Ten_Ngay_31", "BangChamCong_NewReadGroup");

			//AuthorizationRules.AllowWrite("TenNhanVien", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhan", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("TenBoPhan", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("SoNgayDiLam", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("NghiKhongLuong", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("NghiBaoHiem", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_1", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_2", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_3", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_4", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_5", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_6", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_7", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_8", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_9", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_10", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_11", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_12", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_13", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_14", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_15", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_16", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_17", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_18", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_19", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_20", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_21", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_22", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_23", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_24", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_25", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_26", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_27", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_28", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_29", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_30", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay_31", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_1", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_2", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_3", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_4", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_5", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_6", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_7", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_8", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_9", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_10", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_11", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_12", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_13", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_14", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_15", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_16", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_17", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_18", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_19", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_20", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_21", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_22", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_23", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_24", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_25", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_26", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_27", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_28", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_29", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_30", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsLe_31", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_1", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_2", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_3", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_4", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_5", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_6", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_7", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_8", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_9", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_10", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_11", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_12", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_13", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_14", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_15", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_16", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_17", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_18", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_19", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_20", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_21", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_22", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_23", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_24", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_25", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_26", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_27", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_28", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_29", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_30", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("IsBu_31", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_1", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_2", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_3", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_4", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_5", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_6", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_7", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_8", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_9", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_10", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_11", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_12", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_13", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_14", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_15", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_16", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_17", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_18", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_19", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_20", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_21", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_22", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_23", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_24", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_25", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_26", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_27", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_28", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_29", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_30", "BangChamCong_NewWriteGroup");
			//AuthorizationRules.AllowWrite("Ten_Ngay_31", "BangChamCong_NewWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangChamCong_New
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangChamCong_NewViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangChamCong_New
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangChamCong_NewAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangChamCong_New
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangChamCong_NewEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangChamCong_New
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangChamCong_NewDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangChamCong_New()
		{ /* require use of factory method */ }

		public static BangChamCong_New NewBangChamCong_New(int thang, int nam, long maNhanVien)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangChamCong_New");
			return DataPortal.Create<BangChamCong_New>(new Criteria(thang, nam, maNhanVien));
		}

		public static BangChamCong_New GetBangChamCong_New(int thang, int nam, long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangChamCong_New");
			return DataPortal.Fetch<BangChamCong_New>(new Criteria(thang, nam, maNhanVien));
		}

		public static void DeleteBangChamCong_New(int thang, int nam, long maNhanVien)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangChamCong_New");
			DataPortal.Delete(new Criteria(thang, nam, maNhanVien));
		}

		public override BangChamCong_New Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangChamCong_New");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangChamCong_New");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BangChamCong_New");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private BangChamCong_New(int thang, int nam, long maNhanVien)
		{
			this._thang = thang;
			this._nam = nam;
			this._maNhanVien = maNhanVien;
		}

		internal static BangChamCong_New NewBangChamCong_NewChild(int thang, int nam, long maNhanVien)
		{
			BangChamCong_New child = new BangChamCong_New(thang, nam, maNhanVien);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BangChamCong_New GetBangChamCong_New(SafeDataReader dr)
		{
			BangChamCong_New child =  new BangChamCong_New();
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
			public int Thang;
			public int Nam;
			public long MaNhanVien;

			public Criteria(int thang, int nam, long maNhanVien)
			{
				this.Thang = thang;
				this.Nam = nam;
				this.MaNhanVien = maNhanVien;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_thang = criteria.Thang;
			_nam = criteria.Nam;
			_maNhanVien = criteria.MaNhanVien;
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
				cm.CommandText = "spd_SelecttblBangChamCong_New";

				cm.Parameters.AddWithValue("@Thang", criteria.Thang);
				cm.Parameters.AddWithValue("@Nam", criteria.Nam);
				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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
			DataPortal_Delete(new Criteria(_thang, _nam, _maNhanVien));
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
				cm.CommandText = "spd_DeletetblBangChamCong_New";

				cm.Parameters.AddWithValue("@Thang", criteria.Thang);
				cm.Parameters.AddWithValue("@Nam", criteria.Nam);
				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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
			_thang = dr.GetInt32("Thang");
			_nam = dr.GetInt32("Nam");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_soNgayDiLam = dr.GetInt32("SoNgayDiLam");
			_nghiKhongLuong = dr.GetInt32("NghiKhongLuong");
			_nghiBaoHiem = dr.GetInt32("NghiBaoHiem");
            _heSoLuong = dr.GetDecimal("HeSoLuong");
			_ngay1 = dr.GetString("Ngay_1");
			_ngay2 = dr.GetString("Ngay_2");
			_ngay3 = dr.GetString("Ngay_3");
			_ngay4 = dr.GetString("Ngay_4");
			_ngay5 = dr.GetString("Ngay_5");
			_ngay6 = dr.GetString("Ngay_6");
			_ngay7 = dr.GetString("Ngay_7");
			_ngay8 = dr.GetString("Ngay_8");
			_ngay9 = dr.GetString("Ngay_9");
			_ngay10 = dr.GetString("Ngay_10");
			_ngay11 = dr.GetString("Ngay_11");
			_ngay12 = dr.GetString("Ngay_12");
			_ngay13 = dr.GetString("Ngay_13");
			_ngay14 = dr.GetString("Ngay_14");
			_ngay15 = dr.GetString("Ngay_15");
			_ngay16 = dr.GetString("Ngay_16");
			_ngay17 = dr.GetString("Ngay_17");
			_ngay18 = dr.GetString("Ngay_18");
			_ngay19 = dr.GetString("Ngay_19");
			_ngay20 = dr.GetString("Ngay_20");
			_ngay21 = dr.GetString("Ngay_21");
			_ngay22 = dr.GetString("Ngay_22");
			_ngay23 = dr.GetString("Ngay_23");
			_ngay24 = dr.GetString("Ngay_24");
			_ngay25 = dr.GetString("Ngay_25");
			_ngay26 = dr.GetString("Ngay_26");
			_ngay27 = dr.GetString("Ngay_27");
			_ngay28 = dr.GetString("Ngay_28");
			_ngay29 = dr.GetString("Ngay_29");
			_ngay30 = dr.GetString("Ngay_30");
			_ngay31 = dr.GetString("Ngay_31");
            _isle1 = dr.GetInt32("IsLe_1");
            _isle2 = dr.GetInt32("IsLe_2");
            _isle3 = dr.GetInt32("IsLe_3");
            _isle4 = dr.GetInt32("IsLe_4");
            _isle5 = dr.GetInt32("IsLe_5");
            _isle6 = dr.GetInt32("IsLe_6");
            _isle7 = dr.GetInt32("IsLe_7");
            _isle8 = dr.GetInt32("IsLe_8");
            _isle9 = dr.GetInt32("IsLe_9");
            _isle10 = dr.GetInt32("IsLe_10");
            _isle11 = dr.GetInt32("IsLe_11");
            _isle12 = dr.GetInt32("IsLe_12");
            _isle13 = dr.GetInt32("IsLe_13");
            _isle14 = dr.GetInt32("IsLe_14");
            _isle15 = dr.GetInt32("IsLe_15");
            _isle16 = dr.GetInt32("IsLe_16");
            _isle17 = dr.GetInt32("IsLe_17");
            _isle18 = dr.GetInt32("IsLe_18");
            _isle19 = dr.GetInt32("IsLe_19");
            _isle20 = dr.GetInt32("IsLe_20");
            _isle21 = dr.GetInt32("IsLe_21");
            _isle22 = dr.GetInt32("IsLe_22");
            _isle23 = dr.GetInt32("IsLe_23");
            _isle24 = dr.GetInt32("IsLe_24");
            _isle25 = dr.GetInt32("IsLe_25");
            _isle26 = dr.GetInt32("IsLe_26");
            _isle27 = dr.GetInt32("IsLe_27");
            _isle28 = dr.GetInt32("IsLe_28");
            _isle29 = dr.GetInt32("IsLe_29");
            _isle30 = dr.GetInt32("IsLe_30");
            _isle31 = dr.GetInt32("IsLe_31");
            _isbu1 = dr.GetInt32("IsBu_1");
            _isbu2 = dr.GetInt32("IsBu_2");
            _isbu3 = dr.GetInt32("IsBu_3");
            _isbu4 = dr.GetInt32("IsBu_4");
            _isbu5 = dr.GetInt32("IsBu_5");
            _isbu6 = dr.GetInt32("IsBu_6");
            _isbu7 = dr.GetInt32("IsBu_7");
            _isbu8 = dr.GetInt32("IsBu_8");
            _isbu9 = dr.GetInt32("IsBu_9");
            _isbu10 = dr.GetInt32("IsBu_10");
            _isbu11 = dr.GetInt32("IsBu_11");
            _isbu12 = dr.GetInt32("IsBu_12");
            _isbu13 = dr.GetInt32("IsBu_13");
            _isbu14 = dr.GetInt32("IsBu_14");
            _isbu15 = dr.GetInt32("IsBu_15");
            _isbu16 = dr.GetInt32("IsBu_16");
            _isbu17 = dr.GetInt32("IsBu_17");
            _isbu18 = dr.GetInt32("IsBu_18");
            _isbu19 = dr.GetInt32("IsBu_19");
            _isbu20 = dr.GetInt32("IsBu_20");
            _isbu21 = dr.GetInt32("IsBu_21");
            _isbu22 = dr.GetInt32("IsBu_22");
            _isbu23 = dr.GetInt32("IsBu_23");
            _isbu24 = dr.GetInt32("IsBu_24");
            _isbu25 = dr.GetInt32("IsBu_25");
            _isbu26 = dr.GetInt32("IsBu_26");
            _isbu27 = dr.GetInt32("IsBu_27");
            _isbu28 = dr.GetInt32("IsBu_28");
            _isbu29 = dr.GetInt32("IsBu_29");
            _isbu30 = dr.GetInt32("IsBu_30");
            _isbu31 = dr.GetInt32("IsBu_31");
            _tenNgay1 = dr.GetString("Ten_Ngay_1");
            _tenNgay2 = dr.GetString("Ten_Ngay_2");
            _tenNgay3 = dr.GetString("Ten_Ngay_3");
            _tenNgay4 = dr.GetString("Ten_Ngay_4");
            _tenNgay5 = dr.GetString("Ten_Ngay_5");
            _tenNgay6 = dr.GetString("Ten_Ngay_6");
            _tenNgay7 = dr.GetString("Ten_Ngay_7");
            _tenNgay8 = dr.GetString("Ten_Ngay_8");
            _tenNgay9 = dr.GetString("Ten_Ngay_9");
            _tenNgay10 = dr.GetString("Ten_Ngay_10");
            _tenNgay11 = dr.GetString("Ten_Ngay_11");
            _tenNgay12 = dr.GetString("Ten_Ngay_12");
            _tenNgay13 = dr.GetString("Ten_Ngay_13");
            _tenNgay14 = dr.GetString("Ten_Ngay_14");
            _tenNgay15 = dr.GetString("Ten_Ngay_15");
            _tenNgay16 = dr.GetString("Ten_Ngay_16");
            _tenNgay17 = dr.GetString("Ten_Ngay_17");
            _tenNgay18 = dr.GetString("Ten_Ngay_18");
            _tenNgay19 = dr.GetString("Ten_Ngay_19");
            _tenNgay20 = dr.GetString("Ten_Ngay_20");
            _tenNgay21 = dr.GetString("Ten_Ngay_21");
            _tenNgay22 = dr.GetString("Ten_Ngay_22");
            _tenNgay23 = dr.GetString("Ten_Ngay_23");
            _tenNgay24 = dr.GetString("Ten_Ngay_24");
            _tenNgay25 = dr.GetString("Ten_Ngay_25");
            _tenNgay26 = dr.GetString("Ten_Ngay_26");
            _tenNgay27 = dr.GetString("Ten_Ngay_27");
            _tenNgay28 = dr.GetString("Ten_Ngay_28");
            _tenNgay29 = dr.GetString("Ten_Ngay_29");
            _tenNgay30 = dr.GetString("Ten_Ngay_30");
            _tenNgay31 = dr.GetString("Ten_Ngay_31");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, BangChamCong_NewList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, BangChamCong_NewList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_InserttblBangChamCong_New";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BangChamCong_NewList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@Thang", _thang);
			cm.Parameters.AddWithValue("@Nam", _nam);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			if (_soNgayDiLam != 0)
				cm.Parameters.AddWithValue("@SoNgayDiLam", _soNgayDiLam);
			else
				cm.Parameters.AddWithValue("@SoNgayDiLam", DBNull.Value);
			if (_nghiKhongLuong != 0)
				cm.Parameters.AddWithValue("@NghiKhongLuong", _nghiKhongLuong);
			else
				cm.Parameters.AddWithValue("@NghiKhongLuong", DBNull.Value);
			if (_nghiBaoHiem != 0)
				cm.Parameters.AddWithValue("@NghiBaoHiem", _nghiBaoHiem);
			else
				cm.Parameters.AddWithValue("@NghiBaoHiem", DBNull.Value);
			if (_ngay1.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_1", _ngay1);
			else
				cm.Parameters.AddWithValue("@Ngay_1", DBNull.Value);
			if (_ngay2.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_2", _ngay2);
			else
				cm.Parameters.AddWithValue("@Ngay_2", DBNull.Value);
			if (_ngay3.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_3", _ngay3);
			else
				cm.Parameters.AddWithValue("@Ngay_3", DBNull.Value);
			if (_ngay4.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_4", _ngay4);
			else
				cm.Parameters.AddWithValue("@Ngay_4", DBNull.Value);
			if (_ngay5.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_5", _ngay5);
			else
				cm.Parameters.AddWithValue("@Ngay_5", DBNull.Value);
			if (_ngay6.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_6", _ngay6);
			else
				cm.Parameters.AddWithValue("@Ngay_6", DBNull.Value);
			if (_ngay7.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_7", _ngay7);
			else
				cm.Parameters.AddWithValue("@Ngay_7", DBNull.Value);
			if (_ngay8.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_8", _ngay8);
			else
				cm.Parameters.AddWithValue("@Ngay_8", DBNull.Value);
			if (_ngay9.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_9", _ngay9);
			else
				cm.Parameters.AddWithValue("@Ngay_9", DBNull.Value);
			if (_ngay10.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_10", _ngay10);
			else
				cm.Parameters.AddWithValue("@Ngay_10", DBNull.Value);
			if (_ngay11.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_11", _ngay11);
			else
				cm.Parameters.AddWithValue("@Ngay_11", DBNull.Value);
			if (_ngay12.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_12", _ngay12);
			else
				cm.Parameters.AddWithValue("@Ngay_12", DBNull.Value);
			if (_ngay13.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_13", _ngay13);
			else
				cm.Parameters.AddWithValue("@Ngay_13", DBNull.Value);
			if (_ngay14.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_14", _ngay14);
			else
				cm.Parameters.AddWithValue("@Ngay_14", DBNull.Value);
			if (_ngay15.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_15", _ngay15);
			else
				cm.Parameters.AddWithValue("@Ngay_15", DBNull.Value);
			if (_ngay16.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_16", _ngay16);
			else
				cm.Parameters.AddWithValue("@Ngay_16", DBNull.Value);
			if (_ngay17.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_17", _ngay17);
			else
				cm.Parameters.AddWithValue("@Ngay_17", DBNull.Value);
			if (_ngay18.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_18", _ngay18);
			else
				cm.Parameters.AddWithValue("@Ngay_18", DBNull.Value);
			if (_ngay19.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_19", _ngay19);
			else
				cm.Parameters.AddWithValue("@Ngay_19", DBNull.Value);
			if (_ngay20.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_20", _ngay20);
			else
				cm.Parameters.AddWithValue("@Ngay_20", DBNull.Value);
			if (_ngay21.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_21", _ngay21);
			else
				cm.Parameters.AddWithValue("@Ngay_21", DBNull.Value);
			if (_ngay22.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_22", _ngay22);
			else
				cm.Parameters.AddWithValue("@Ngay_22", DBNull.Value);
			if (_ngay23.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_23", _ngay23);
			else
				cm.Parameters.AddWithValue("@Ngay_23", DBNull.Value);
			if (_ngay24.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_24", _ngay24);
			else
				cm.Parameters.AddWithValue("@Ngay_24", DBNull.Value);
			if (_ngay25.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_25", _ngay25);
			else
				cm.Parameters.AddWithValue("@Ngay_25", DBNull.Value);
			if (_ngay26.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_26", _ngay26);
			else
				cm.Parameters.AddWithValue("@Ngay_26", DBNull.Value);
			if (_ngay27.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_27", _ngay27);
			else
				cm.Parameters.AddWithValue("@Ngay_27", DBNull.Value);
			if (_ngay28.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_28", _ngay28);
			else
				cm.Parameters.AddWithValue("@Ngay_28", DBNull.Value);
			if (_ngay29.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_29", _ngay29);
			else
				cm.Parameters.AddWithValue("@Ngay_29", DBNull.Value);
			if (_ngay30.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_30", _ngay30);
			else
				cm.Parameters.AddWithValue("@Ngay_30", DBNull.Value);
			if (_ngay31.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_31", _ngay31);
			else
				cm.Parameters.AddWithValue("@Ngay_31", DBNull.Value);
			if (_isle1 != 0)
				cm.Parameters.AddWithValue("@IsLe_1", _isle1);
			else
				cm.Parameters.AddWithValue("@IsLe_1", DBNull.Value);
			if (_isle2 != 0)
				cm.Parameters.AddWithValue("@IsLe_2", _isle2);
			else
				cm.Parameters.AddWithValue("@IsLe_2", DBNull.Value);
			if (_isle3 != 0)
				cm.Parameters.AddWithValue("@IsLe_3", _isle3);
			else
				cm.Parameters.AddWithValue("@IsLe_3", DBNull.Value);
			if (_isle4 != 0)
				cm.Parameters.AddWithValue("@IsLe_4", _isle4);
			else
				cm.Parameters.AddWithValue("@IsLe_4", DBNull.Value);
			if (_isle5 != 0)
				cm.Parameters.AddWithValue("@IsLe_5", _isle5);
			else
				cm.Parameters.AddWithValue("@IsLe_5", DBNull.Value);
			if (_isle6 != 0)
				cm.Parameters.AddWithValue("@IsLe_6", _isle6);
			else
				cm.Parameters.AddWithValue("@IsLe_6", DBNull.Value);
			if (_isle7 != 0)
				cm.Parameters.AddWithValue("@IsLe_7", _isle7);
			else
				cm.Parameters.AddWithValue("@IsLe_7", DBNull.Value);
			if (_isle8 != 0)
				cm.Parameters.AddWithValue("@IsLe_8", _isle8);
			else
				cm.Parameters.AddWithValue("@IsLe_8", DBNull.Value);
			if (_isle9 != 0)
				cm.Parameters.AddWithValue("@IsLe_9", _isle9);
			else
				cm.Parameters.AddWithValue("@IsLe_9", DBNull.Value);
			if (_isle10 != 0)
				cm.Parameters.AddWithValue("@IsLe_10", _isle10);
			else
				cm.Parameters.AddWithValue("@IsLe_10", DBNull.Value);
			if (_isle11 != 0)
				cm.Parameters.AddWithValue("@IsLe_11", _isle11);
			else
				cm.Parameters.AddWithValue("@IsLe_11", DBNull.Value);
			if (_isle12 != 0)
				cm.Parameters.AddWithValue("@IsLe_12", _isle12);
			else
				cm.Parameters.AddWithValue("@IsLe_12", DBNull.Value);
			if (_isle13 != 0)
				cm.Parameters.AddWithValue("@IsLe_13", _isle13);
			else
				cm.Parameters.AddWithValue("@IsLe_13", DBNull.Value);
			if (_isle14 != 0)
				cm.Parameters.AddWithValue("@IsLe_14", _isle14);
			else
				cm.Parameters.AddWithValue("@IsLe_14", DBNull.Value);
			if (_isle15 != 0)
				cm.Parameters.AddWithValue("@IsLe_15", _isle15);
			else
				cm.Parameters.AddWithValue("@IsLe_15", DBNull.Value);
			if (_isle16 != 0)
				cm.Parameters.AddWithValue("@IsLe_16", _isle16);
			else
				cm.Parameters.AddWithValue("@IsLe_16", DBNull.Value);
			if (_isle17 != 0)
				cm.Parameters.AddWithValue("@IsLe_17", _isle17);
			else
				cm.Parameters.AddWithValue("@IsLe_17", DBNull.Value);
			if (_isle18 != 0)
				cm.Parameters.AddWithValue("@IsLe_18", _isle18);
			else
				cm.Parameters.AddWithValue("@IsLe_18", DBNull.Value);
			if (_isle19 != 0)
				cm.Parameters.AddWithValue("@IsLe_19", _isle19);
			else
				cm.Parameters.AddWithValue("@IsLe_19", DBNull.Value);
			if (_isle20 != 0)
				cm.Parameters.AddWithValue("@IsLe_20", _isle20);
			else
				cm.Parameters.AddWithValue("@IsLe_20", DBNull.Value);
			if (_isle21 != 0)
				cm.Parameters.AddWithValue("@IsLe_21", _isle21);
			else
				cm.Parameters.AddWithValue("@IsLe_21", DBNull.Value);
			if (_isle22 != 0)
				cm.Parameters.AddWithValue("@IsLe_22", _isle22);
			else
				cm.Parameters.AddWithValue("@IsLe_22", DBNull.Value);
			if (_isle23 != 0)
				cm.Parameters.AddWithValue("@IsLe_23", _isle23);
			else
				cm.Parameters.AddWithValue("@IsLe_23", DBNull.Value);
			if (_isle24 != 0)
				cm.Parameters.AddWithValue("@IsLe_24", _isle24);
			else
				cm.Parameters.AddWithValue("@IsLe_24", DBNull.Value);
			if (_isle25 != 0)
				cm.Parameters.AddWithValue("@IsLe_25", _isle25);
			else
				cm.Parameters.AddWithValue("@IsLe_25", DBNull.Value);
			if (_isle26 != 0)
				cm.Parameters.AddWithValue("@IsLe_26", _isle26);
			else
				cm.Parameters.AddWithValue("@IsLe_26", DBNull.Value);
			if (_isle27 != 0)
				cm.Parameters.AddWithValue("@IsLe_27", _isle27);
			else
				cm.Parameters.AddWithValue("@IsLe_27", DBNull.Value);
			if (_isle28 != 0)
				cm.Parameters.AddWithValue("@IsLe_28", _isle28);
			else
				cm.Parameters.AddWithValue("@IsLe_28", DBNull.Value);
			if (_isle29 != 0)
				cm.Parameters.AddWithValue("@IsLe_29", _isle29);
			else
				cm.Parameters.AddWithValue("@IsLe_29", DBNull.Value);
			if (_isle30 != 0)
				cm.Parameters.AddWithValue("@IsLe_30", _isle30);
			else
				cm.Parameters.AddWithValue("@IsLe_30", DBNull.Value);
			if (_isle31 != 0)
				cm.Parameters.AddWithValue("@IsLe_31", _isle31);
			else
				cm.Parameters.AddWithValue("@IsLe_31", DBNull.Value);
			if (_isbu1 != 0)
				cm.Parameters.AddWithValue("@IsBu_1", _isbu1);
			else
				cm.Parameters.AddWithValue("@IsBu_1", DBNull.Value);
			if (_isbu2 != 0)
				cm.Parameters.AddWithValue("@IsBu_2", _isbu2);
			else
				cm.Parameters.AddWithValue("@IsBu_2", DBNull.Value);
			if (_isbu3 != 0)
				cm.Parameters.AddWithValue("@IsBu_3", _isbu3);
			else
				cm.Parameters.AddWithValue("@IsBu_3", DBNull.Value);
			if (_isbu4 != 0)
				cm.Parameters.AddWithValue("@IsBu_4", _isbu4);
			else
				cm.Parameters.AddWithValue("@IsBu_4", DBNull.Value);
			if (_isbu5 != 0)
				cm.Parameters.AddWithValue("@IsBu_5", _isbu5);
			else
				cm.Parameters.AddWithValue("@IsBu_5", DBNull.Value);
			if (_isbu6 != 0)
				cm.Parameters.AddWithValue("@IsBu_6", _isbu6);
			else
				cm.Parameters.AddWithValue("@IsBu_6", DBNull.Value);
			if (_isbu7 != 0)
				cm.Parameters.AddWithValue("@IsBu_7", _isbu7);
			else
				cm.Parameters.AddWithValue("@IsBu_7", DBNull.Value);
			if (_isbu8 != 0)
				cm.Parameters.AddWithValue("@IsBu_8", _isbu8);
			else
				cm.Parameters.AddWithValue("@IsBu_8", DBNull.Value);
			if (_isbu9 != 0)
				cm.Parameters.AddWithValue("@IsBu_9", _isbu9);
			else
				cm.Parameters.AddWithValue("@IsBu_9", DBNull.Value);
			if (_isbu10 != 0)
				cm.Parameters.AddWithValue("@IsBu_10", _isbu10);
			else
				cm.Parameters.AddWithValue("@IsBu_10", DBNull.Value);
			if (_isbu11 != 0)
				cm.Parameters.AddWithValue("@IsBu_11", _isbu11);
			else
				cm.Parameters.AddWithValue("@IsBu_11", DBNull.Value);
			if (_isbu12 != 0)
				cm.Parameters.AddWithValue("@IsBu_12", _isbu12);
			else
				cm.Parameters.AddWithValue("@IsBu_12", DBNull.Value);
			if (_isbu13 != 0)
				cm.Parameters.AddWithValue("@IsBu_13", _isbu13);
			else
				cm.Parameters.AddWithValue("@IsBu_13", DBNull.Value);
			if (_isbu14 != 0)
				cm.Parameters.AddWithValue("@IsBu_14", _isbu14);
			else
				cm.Parameters.AddWithValue("@IsBu_14", DBNull.Value);
			if (_isbu15 != 0)
				cm.Parameters.AddWithValue("@IsBu_15", _isbu15);
			else
				cm.Parameters.AddWithValue("@IsBu_15", DBNull.Value);
			if (_isbu16 != 0)
				cm.Parameters.AddWithValue("@IsBu_16", _isbu16);
			else
				cm.Parameters.AddWithValue("@IsBu_16", DBNull.Value);
			if (_isbu17 != 0)
				cm.Parameters.AddWithValue("@IsBu_17", _isbu17);
			else
				cm.Parameters.AddWithValue("@IsBu_17", DBNull.Value);
			if (_isbu18 != 0)
				cm.Parameters.AddWithValue("@IsBu_18", _isbu18);
			else
				cm.Parameters.AddWithValue("@IsBu_18", DBNull.Value);
			if (_isbu19 != 0)
				cm.Parameters.AddWithValue("@IsBu_19", _isbu19);
			else
				cm.Parameters.AddWithValue("@IsBu_19", DBNull.Value);
			if (_isbu20 != 0)
				cm.Parameters.AddWithValue("@IsBu_20", _isbu20);
			else
				cm.Parameters.AddWithValue("@IsBu_20", DBNull.Value);
			if (_isbu21 != 0)
				cm.Parameters.AddWithValue("@IsBu_21", _isbu21);
			else
				cm.Parameters.AddWithValue("@IsBu_21", DBNull.Value);
			if (_isbu22 != 0)
				cm.Parameters.AddWithValue("@IsBu_22", _isbu22);
			else
				cm.Parameters.AddWithValue("@IsBu_22", DBNull.Value);
			if (_isbu23 != 0)
				cm.Parameters.AddWithValue("@IsBu_23", _isbu23);
			else
				cm.Parameters.AddWithValue("@IsBu_23", DBNull.Value);
			if (_isbu24 != 0)
				cm.Parameters.AddWithValue("@IsBu_24", _isbu24);
			else
				cm.Parameters.AddWithValue("@IsBu_24", DBNull.Value);
			if (_isbu25 != 0)
				cm.Parameters.AddWithValue("@IsBu_25", _isbu25);
			else
				cm.Parameters.AddWithValue("@IsBu_25", DBNull.Value);
			if (_isbu26 != 0)
				cm.Parameters.AddWithValue("@IsBu_26", _isbu26);
			else
				cm.Parameters.AddWithValue("@IsBu_26", DBNull.Value);
			if (_isbu27 != 0)
				cm.Parameters.AddWithValue("@IsBu_27", _isbu27);
			else
				cm.Parameters.AddWithValue("@IsBu_27", DBNull.Value);
			if (_isbu28 != 0)
				cm.Parameters.AddWithValue("@IsBu_28", _isbu28);
			else
				cm.Parameters.AddWithValue("@IsBu_28", DBNull.Value);
			if (_isbu29 != 0)
				cm.Parameters.AddWithValue("@IsBu_29", _isbu29);
			else
				cm.Parameters.AddWithValue("@IsBu_29", DBNull.Value);
			if (_isbu30 != 0)
				cm.Parameters.AddWithValue("@IsBu_30", _isbu30);
			else
				cm.Parameters.AddWithValue("@IsBu_30", DBNull.Value);
			if (_isbu31 != 0)
				cm.Parameters.AddWithValue("@IsBu_31", _isbu31);
			else
				cm.Parameters.AddWithValue("@IsBu_31", DBNull.Value);
			if (_tenNgay1.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_1", _tenNgay1);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_1", DBNull.Value);
			if (_tenNgay2.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_2", _tenNgay2);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_2", DBNull.Value);
			if (_tenNgay3.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_3", _tenNgay3);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_3", DBNull.Value);
			if (_tenNgay4.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_4", _tenNgay4);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_4", DBNull.Value);
			if (_tenNgay5.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_5", _tenNgay5);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_5", DBNull.Value);
			if (_tenNgay6.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_6", _tenNgay6);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_6", DBNull.Value);
			if (_tenNgay7.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_7", _tenNgay7);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_7", DBNull.Value);
			if (_tenNgay8.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_8", _tenNgay8);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_8", DBNull.Value);
			if (_tenNgay9.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_9", _tenNgay9);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_9", DBNull.Value);
			if (_tenNgay10.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_10", _tenNgay10);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_10", DBNull.Value);
			if (_tenNgay11.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_11", _tenNgay11);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_11", DBNull.Value);
			if (_tenNgay12.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_12", _tenNgay12);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_12", DBNull.Value);
			if (_tenNgay13.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_13", _tenNgay13);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_13", DBNull.Value);
			if (_tenNgay14.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_14", _tenNgay14);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_14", DBNull.Value);
			if (_tenNgay15.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_15", _tenNgay15);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_15", DBNull.Value);
			if (_tenNgay16.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_16", _tenNgay16);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_16", DBNull.Value);
			if (_tenNgay17.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_17", _tenNgay17);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_17", DBNull.Value);
			if (_tenNgay18.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_18", _tenNgay18);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_18", DBNull.Value);
			if (_tenNgay19.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_19", _tenNgay19);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_19", DBNull.Value);
			if (_tenNgay20.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_20", _tenNgay20);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_20", DBNull.Value);
			if (_tenNgay21.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_21", _tenNgay21);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_21", DBNull.Value);
			if (_tenNgay22.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_22", _tenNgay22);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_22", DBNull.Value);
			if (_tenNgay23.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_23", _tenNgay23);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_23", DBNull.Value);
			if (_tenNgay24.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_24", _tenNgay24);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_24", DBNull.Value);
			if (_tenNgay25.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_25", _tenNgay25);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_25", DBNull.Value);
			if (_tenNgay26.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_26", _tenNgay26);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_26", DBNull.Value);
			if (_tenNgay27.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_27", _tenNgay27);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_27", DBNull.Value);
			if (_tenNgay28.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_28", _tenNgay28);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_28", DBNull.Value);
			if (_tenNgay29.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_29", _tenNgay29);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_29", DBNull.Value);
			if (_tenNgay30.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_30", _tenNgay30);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_30", DBNull.Value);
			if (_tenNgay31.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_31", _tenNgay31);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_31", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, BangChamCong_NewList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, BangChamCong_NewList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_UpdatetblBangChamCong_New";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BangChamCong_NewList parent)
		{
			cm.Parameters.AddWithValue("@Thang", _thang);
			cm.Parameters.AddWithValue("@Nam", _nam);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			if (_soNgayDiLam != 0)
				cm.Parameters.AddWithValue("@SoNgayDiLam", _soNgayDiLam);
			else
				cm.Parameters.AddWithValue("@SoNgayDiLam", DBNull.Value);
			if (_nghiKhongLuong != 0)
				cm.Parameters.AddWithValue("@NghiKhongLuong", _nghiKhongLuong);
			else
				cm.Parameters.AddWithValue("@NghiKhongLuong", DBNull.Value);
			if (_nghiBaoHiem != 0)
				cm.Parameters.AddWithValue("@NghiBaoHiem", _nghiBaoHiem);
			else
				cm.Parameters.AddWithValue("@NghiBaoHiem", DBNull.Value);
			if (_ngay1.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_1", _ngay1);
			else
				cm.Parameters.AddWithValue("@Ngay_1", DBNull.Value);
			if (_ngay2.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_2", _ngay2);
			else
				cm.Parameters.AddWithValue("@Ngay_2", DBNull.Value);
			if (_ngay3.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_3", _ngay3);
			else
				cm.Parameters.AddWithValue("@Ngay_3", DBNull.Value);
			if (_ngay4.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_4", _ngay4);
			else
				cm.Parameters.AddWithValue("@Ngay_4", DBNull.Value);
			if (_ngay5.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_5", _ngay5);
			else
				cm.Parameters.AddWithValue("@Ngay_5", DBNull.Value);
			if (_ngay6.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_6", _ngay6);
			else
				cm.Parameters.AddWithValue("@Ngay_6", DBNull.Value);
			if (_ngay7.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_7", _ngay7);
			else
				cm.Parameters.AddWithValue("@Ngay_7", DBNull.Value);
			if (_ngay8.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_8", _ngay8);
			else
				cm.Parameters.AddWithValue("@Ngay_8", DBNull.Value);
			if (_ngay9.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_9", _ngay9);
			else
				cm.Parameters.AddWithValue("@Ngay_9", DBNull.Value);
			if (_ngay10.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_10", _ngay10);
			else
				cm.Parameters.AddWithValue("@Ngay_10", DBNull.Value);
			if (_ngay11.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_11", _ngay11);
			else
				cm.Parameters.AddWithValue("@Ngay_11", DBNull.Value);
			if (_ngay12.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_12", _ngay12);
			else
				cm.Parameters.AddWithValue("@Ngay_12", DBNull.Value);
			if (_ngay13.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_13", _ngay13);
			else
				cm.Parameters.AddWithValue("@Ngay_13", DBNull.Value);
			if (_ngay14.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_14", _ngay14);
			else
				cm.Parameters.AddWithValue("@Ngay_14", DBNull.Value);
			if (_ngay15.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_15", _ngay15);
			else
				cm.Parameters.AddWithValue("@Ngay_15", DBNull.Value);
			if (_ngay16.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_16", _ngay16);
			else
				cm.Parameters.AddWithValue("@Ngay_16", DBNull.Value);
			if (_ngay17.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_17", _ngay17);
			else
				cm.Parameters.AddWithValue("@Ngay_17", DBNull.Value);
			if (_ngay18.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_18", _ngay18);
			else
				cm.Parameters.AddWithValue("@Ngay_18", DBNull.Value);
			if (_ngay19.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_19", _ngay19);
			else
				cm.Parameters.AddWithValue("@Ngay_19", DBNull.Value);
			if (_ngay20.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_20", _ngay20);
			else
				cm.Parameters.AddWithValue("@Ngay_20", DBNull.Value);
			if (_ngay21.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_21", _ngay21);
			else
				cm.Parameters.AddWithValue("@Ngay_21", DBNull.Value);
			if (_ngay22.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_22", _ngay22);
			else
				cm.Parameters.AddWithValue("@Ngay_22", DBNull.Value);
			if (_ngay23.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_23", _ngay23);
			else
				cm.Parameters.AddWithValue("@Ngay_23", DBNull.Value);
			if (_ngay24.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_24", _ngay24);
			else
				cm.Parameters.AddWithValue("@Ngay_24", DBNull.Value);
			if (_ngay25.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_25", _ngay25);
			else
				cm.Parameters.AddWithValue("@Ngay_25", DBNull.Value);
			if (_ngay26.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_26", _ngay26);
			else
				cm.Parameters.AddWithValue("@Ngay_26", DBNull.Value);
			if (_ngay27.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_27", _ngay27);
			else
				cm.Parameters.AddWithValue("@Ngay_27", DBNull.Value);
			if (_ngay28.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_28", _ngay28);
			else
				cm.Parameters.AddWithValue("@Ngay_28", DBNull.Value);
			if (_ngay29.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_29", _ngay29);
			else
				cm.Parameters.AddWithValue("@Ngay_29", DBNull.Value);
			if (_ngay30.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_30", _ngay30);
			else
				cm.Parameters.AddWithValue("@Ngay_30", DBNull.Value);
			if (_ngay31.Length > 0)
				cm.Parameters.AddWithValue("@Ngay_31", _ngay31);
			else
				cm.Parameters.AddWithValue("@Ngay_31", DBNull.Value);
			if (_isle1 != 0)
				cm.Parameters.AddWithValue("@IsLe_1", _isle1);
			else
				cm.Parameters.AddWithValue("@IsLe_1", DBNull.Value);
			if (_isle2 != 0)
				cm.Parameters.AddWithValue("@IsLe_2", _isle2);
			else
				cm.Parameters.AddWithValue("@IsLe_2", DBNull.Value);
			if (_isle3 != 0)
				cm.Parameters.AddWithValue("@IsLe_3", _isle3);
			else
				cm.Parameters.AddWithValue("@IsLe_3", DBNull.Value);
			if (_isle4 != 0)
				cm.Parameters.AddWithValue("@IsLe_4", _isle4);
			else
				cm.Parameters.AddWithValue("@IsLe_4", DBNull.Value);
			if (_isle5 != 0)
				cm.Parameters.AddWithValue("@IsLe_5", _isle5);
			else
				cm.Parameters.AddWithValue("@IsLe_5", DBNull.Value);
			if (_isle6 != 0)
				cm.Parameters.AddWithValue("@IsLe_6", _isle6);
			else
				cm.Parameters.AddWithValue("@IsLe_6", DBNull.Value);
			if (_isle7 != 0)
				cm.Parameters.AddWithValue("@IsLe_7", _isle7);
			else
				cm.Parameters.AddWithValue("@IsLe_7", DBNull.Value);
			if (_isle8 != 0)
				cm.Parameters.AddWithValue("@IsLe_8", _isle8);
			else
				cm.Parameters.AddWithValue("@IsLe_8", DBNull.Value);
			if (_isle9 != 0)
				cm.Parameters.AddWithValue("@IsLe_9", _isle9);
			else
				cm.Parameters.AddWithValue("@IsLe_9", DBNull.Value);
			if (_isle10 != 0)
				cm.Parameters.AddWithValue("@IsLe_10", _isle10);
			else
				cm.Parameters.AddWithValue("@IsLe_10", DBNull.Value);
			if (_isle11 != 0)
				cm.Parameters.AddWithValue("@IsLe_11", _isle11);
			else
				cm.Parameters.AddWithValue("@IsLe_11", DBNull.Value);
			if (_isle12 != 0)
				cm.Parameters.AddWithValue("@IsLe_12", _isle12);
			else
				cm.Parameters.AddWithValue("@IsLe_12", DBNull.Value);
			if (_isle13 != 0)
				cm.Parameters.AddWithValue("@IsLe_13", _isle13);
			else
				cm.Parameters.AddWithValue("@IsLe_13", DBNull.Value);
			if (_isle14 != 0)
				cm.Parameters.AddWithValue("@IsLe_14", _isle14);
			else
				cm.Parameters.AddWithValue("@IsLe_14", DBNull.Value);
			if (_isle15 != 0)
				cm.Parameters.AddWithValue("@IsLe_15", _isle15);
			else
				cm.Parameters.AddWithValue("@IsLe_15", DBNull.Value);
			if (_isle16 != 0)
				cm.Parameters.AddWithValue("@IsLe_16", _isle16);
			else
				cm.Parameters.AddWithValue("@IsLe_16", DBNull.Value);
			if (_isle17 != 0)
				cm.Parameters.AddWithValue("@IsLe_17", _isle17);
			else
				cm.Parameters.AddWithValue("@IsLe_17", DBNull.Value);
			if (_isle18 != 0)
				cm.Parameters.AddWithValue("@IsLe_18", _isle18);
			else
				cm.Parameters.AddWithValue("@IsLe_18", DBNull.Value);
			if (_isle19 != 0)
				cm.Parameters.AddWithValue("@IsLe_19", _isle19);
			else
				cm.Parameters.AddWithValue("@IsLe_19", DBNull.Value);
			if (_isle20 != 0)
				cm.Parameters.AddWithValue("@IsLe_20", _isle20);
			else
				cm.Parameters.AddWithValue("@IsLe_20", DBNull.Value);
			if (_isle21 != 0)
				cm.Parameters.AddWithValue("@IsLe_21", _isle21);
			else
				cm.Parameters.AddWithValue("@IsLe_21", DBNull.Value);
			if (_isle22 != 0)
				cm.Parameters.AddWithValue("@IsLe_22", _isle22);
			else
				cm.Parameters.AddWithValue("@IsLe_22", DBNull.Value);
			if (_isle23 != 0)
				cm.Parameters.AddWithValue("@IsLe_23", _isle23);
			else
				cm.Parameters.AddWithValue("@IsLe_23", DBNull.Value);
			if (_isle24 != 0)
				cm.Parameters.AddWithValue("@IsLe_24", _isle24);
			else
				cm.Parameters.AddWithValue("@IsLe_24", DBNull.Value);
			if (_isle25 != 0)
				cm.Parameters.AddWithValue("@IsLe_25", _isle25);
			else
				cm.Parameters.AddWithValue("@IsLe_25", DBNull.Value);
			if (_isle26 != 0)
				cm.Parameters.AddWithValue("@IsLe_26", _isle26);
			else
				cm.Parameters.AddWithValue("@IsLe_26", DBNull.Value);
			if (_isle27 != 0)
				cm.Parameters.AddWithValue("@IsLe_27", _isle27);
			else
				cm.Parameters.AddWithValue("@IsLe_27", DBNull.Value);
			if (_isle28 != 0)
				cm.Parameters.AddWithValue("@IsLe_28", _isle28);
			else
				cm.Parameters.AddWithValue("@IsLe_28", DBNull.Value);
			if (_isle29 != 0)
				cm.Parameters.AddWithValue("@IsLe_29", _isle29);
			else
				cm.Parameters.AddWithValue("@IsLe_29", DBNull.Value);
			if (_isle30 != 0)
				cm.Parameters.AddWithValue("@IsLe_30", _isle30);
			else
				cm.Parameters.AddWithValue("@IsLe_30", DBNull.Value);
			if (_isle31 != 0)
				cm.Parameters.AddWithValue("@IsLe_31", _isle31);
			else
				cm.Parameters.AddWithValue("@IsLe_31", DBNull.Value);
			if (_isbu1 != 0)
				cm.Parameters.AddWithValue("@IsBu_1", _isbu1);
			else
				cm.Parameters.AddWithValue("@IsBu_1", DBNull.Value);
			if (_isbu2 != 0)
				cm.Parameters.AddWithValue("@IsBu_2", _isbu2);
			else
				cm.Parameters.AddWithValue("@IsBu_2", DBNull.Value);
			if (_isbu3 != 0)
				cm.Parameters.AddWithValue("@IsBu_3", _isbu3);
			else
				cm.Parameters.AddWithValue("@IsBu_3", DBNull.Value);
			if (_isbu4 != 0)
				cm.Parameters.AddWithValue("@IsBu_4", _isbu4);
			else
				cm.Parameters.AddWithValue("@IsBu_4", DBNull.Value);
			if (_isbu5 != 0)
				cm.Parameters.AddWithValue("@IsBu_5", _isbu5);
			else
				cm.Parameters.AddWithValue("@IsBu_5", DBNull.Value);
			if (_isbu6 != 0)
				cm.Parameters.AddWithValue("@IsBu_6", _isbu6);
			else
				cm.Parameters.AddWithValue("@IsBu_6", DBNull.Value);
			if (_isbu7 != 0)
				cm.Parameters.AddWithValue("@IsBu_7", _isbu7);
			else
				cm.Parameters.AddWithValue("@IsBu_7", DBNull.Value);
			if (_isbu8 != 0)
				cm.Parameters.AddWithValue("@IsBu_8", _isbu8);
			else
				cm.Parameters.AddWithValue("@IsBu_8", DBNull.Value);
			if (_isbu9 != 0)
				cm.Parameters.AddWithValue("@IsBu_9", _isbu9);
			else
				cm.Parameters.AddWithValue("@IsBu_9", DBNull.Value);
			if (_isbu10 != 0)
				cm.Parameters.AddWithValue("@IsBu_10", _isbu10);
			else
				cm.Parameters.AddWithValue("@IsBu_10", DBNull.Value);
			if (_isbu11 != 0)
				cm.Parameters.AddWithValue("@IsBu_11", _isbu11);
			else
				cm.Parameters.AddWithValue("@IsBu_11", DBNull.Value);
			if (_isbu12 != 0)
				cm.Parameters.AddWithValue("@IsBu_12", _isbu12);
			else
				cm.Parameters.AddWithValue("@IsBu_12", DBNull.Value);
			if (_isbu13 != 0)
				cm.Parameters.AddWithValue("@IsBu_13", _isbu13);
			else
				cm.Parameters.AddWithValue("@IsBu_13", DBNull.Value);
			if (_isbu14 != 0)
				cm.Parameters.AddWithValue("@IsBu_14", _isbu14);
			else
				cm.Parameters.AddWithValue("@IsBu_14", DBNull.Value);
			if (_isbu15 != 0)
				cm.Parameters.AddWithValue("@IsBu_15", _isbu15);
			else
				cm.Parameters.AddWithValue("@IsBu_15", DBNull.Value);
			if (_isbu16 != 0)
				cm.Parameters.AddWithValue("@IsBu_16", _isbu16);
			else
				cm.Parameters.AddWithValue("@IsBu_16", DBNull.Value);
			if (_isbu17 != 0)
				cm.Parameters.AddWithValue("@IsBu_17", _isbu17);
			else
				cm.Parameters.AddWithValue("@IsBu_17", DBNull.Value);
			if (_isbu18 != 0)
				cm.Parameters.AddWithValue("@IsBu_18", _isbu18);
			else
				cm.Parameters.AddWithValue("@IsBu_18", DBNull.Value);
			if (_isbu19 != 0)
				cm.Parameters.AddWithValue("@IsBu_19", _isbu19);
			else
				cm.Parameters.AddWithValue("@IsBu_19", DBNull.Value);
			if (_isbu20 != 0)
				cm.Parameters.AddWithValue("@IsBu_20", _isbu20);
			else
				cm.Parameters.AddWithValue("@IsBu_20", DBNull.Value);
			if (_isbu21 != 0)
				cm.Parameters.AddWithValue("@IsBu_21", _isbu21);
			else
				cm.Parameters.AddWithValue("@IsBu_21", DBNull.Value);
			if (_isbu22 != 0)
				cm.Parameters.AddWithValue("@IsBu_22", _isbu22);
			else
				cm.Parameters.AddWithValue("@IsBu_22", DBNull.Value);
			if (_isbu23 != 0)
				cm.Parameters.AddWithValue("@IsBu_23", _isbu23);
			else
				cm.Parameters.AddWithValue("@IsBu_23", DBNull.Value);
			if (_isbu24 != 0)
				cm.Parameters.AddWithValue("@IsBu_24", _isbu24);
			else
				cm.Parameters.AddWithValue("@IsBu_24", DBNull.Value);
			if (_isbu25 != 0)
				cm.Parameters.AddWithValue("@IsBu_25", _isbu25);
			else
				cm.Parameters.AddWithValue("@IsBu_25", DBNull.Value);
			if (_isbu26 != 0)
				cm.Parameters.AddWithValue("@IsBu_26", _isbu26);
			else
				cm.Parameters.AddWithValue("@IsBu_26", DBNull.Value);
			if (_isbu27 != 0)
				cm.Parameters.AddWithValue("@IsBu_27", _isbu27);
			else
				cm.Parameters.AddWithValue("@IsBu_27", DBNull.Value);
			if (_isbu28 != 0)
				cm.Parameters.AddWithValue("@IsBu_28", _isbu28);
			else
				cm.Parameters.AddWithValue("@IsBu_28", DBNull.Value);
			if (_isbu29 != 0)
				cm.Parameters.AddWithValue("@IsBu_29", _isbu29);
			else
				cm.Parameters.AddWithValue("@IsBu_29", DBNull.Value);
			if (_isbu30 != 0)
				cm.Parameters.AddWithValue("@IsBu_30", _isbu30);
			else
				cm.Parameters.AddWithValue("@IsBu_30", DBNull.Value);
			if (_isbu31 != 0)
				cm.Parameters.AddWithValue("@IsBu_31", _isbu31);
			else
				cm.Parameters.AddWithValue("@IsBu_31", DBNull.Value);
			if (_tenNgay1.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_1", _tenNgay1);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_1", DBNull.Value);
			if (_tenNgay2.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_2", _tenNgay2);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_2", DBNull.Value);
			if (_tenNgay3.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_3", _tenNgay3);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_3", DBNull.Value);
			if (_tenNgay4.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_4", _tenNgay4);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_4", DBNull.Value);
			if (_tenNgay5.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_5", _tenNgay5);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_5", DBNull.Value);
			if (_tenNgay6.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_6", _tenNgay6);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_6", DBNull.Value);
			if (_tenNgay7.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_7", _tenNgay7);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_7", DBNull.Value);
			if (_tenNgay8.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_8", _tenNgay8);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_8", DBNull.Value);
			if (_tenNgay9.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_9", _tenNgay9);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_9", DBNull.Value);
			if (_tenNgay10.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_10", _tenNgay10);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_10", DBNull.Value);
			if (_tenNgay11.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_11", _tenNgay11);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_11", DBNull.Value);
			if (_tenNgay12.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_12", _tenNgay12);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_12", DBNull.Value);
			if (_tenNgay13.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_13", _tenNgay13);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_13", DBNull.Value);
			if (_tenNgay14.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_14", _tenNgay14);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_14", DBNull.Value);
			if (_tenNgay15.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_15", _tenNgay15);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_15", DBNull.Value);
			if (_tenNgay16.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_16", _tenNgay16);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_16", DBNull.Value);
			if (_tenNgay17.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_17", _tenNgay17);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_17", DBNull.Value);
			if (_tenNgay18.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_18", _tenNgay18);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_18", DBNull.Value);
			if (_tenNgay19.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_19", _tenNgay19);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_19", DBNull.Value);
			if (_tenNgay20.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_20", _tenNgay20);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_20", DBNull.Value);
			if (_tenNgay21.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_21", _tenNgay21);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_21", DBNull.Value);
			if (_tenNgay22.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_22", _tenNgay22);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_22", DBNull.Value);
			if (_tenNgay23.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_23", _tenNgay23);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_23", DBNull.Value);
			if (_tenNgay24.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_24", _tenNgay24);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_24", DBNull.Value);
			if (_tenNgay25.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_25", _tenNgay25);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_25", DBNull.Value);
			if (_tenNgay26.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_26", _tenNgay26);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_26", DBNull.Value);
			if (_tenNgay27.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_27", _tenNgay27);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_27", DBNull.Value);
			if (_tenNgay28.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_28", _tenNgay28);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_28", DBNull.Value);
			if (_tenNgay29.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_29", _tenNgay29);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_29", DBNull.Value);
			if (_tenNgay30.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_30", _tenNgay30);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_30", DBNull.Value);
			if (_tenNgay31.Length > 0)
				cm.Parameters.AddWithValue("@Ten_Ngay_31", _tenNgay31);
			else
				cm.Parameters.AddWithValue("@Ten_Ngay_31", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_thang, _nam, _maNhanVien));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
