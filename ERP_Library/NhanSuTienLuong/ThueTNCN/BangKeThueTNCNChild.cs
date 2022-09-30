namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using Csla.Validation;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [Serializable]
    public class BangKeThueTNCNChild : BusinessBase<BangKeThueTNCNChild>
    {
        private decimal _baoHiemBatBuoc;
        private string _cmnd;
        private string _hoTen;
        private int _id;
        private int _maBoPhan;
        private string _maBoPhanQL;
        private long _maNhanVien;
        private string _mst;
        private int _nam;
        private DateTime _ngayLap;
        private int _soNguoiPhuThuoc;
        private int _soThang;
        private int _soThangGiamTru;
        private decimal _soThueKhauTru;
        private decimal _soThueNopThua;
        private decimal _soThuePhaiNop;
        private string _tenBoPhan;
        private decimal _thueDaKhauTru;
        private decimal _thueNLDDaNop;
        private decimal _thueNLDNopThem;
        private decimal _thueNLDTraLai;
        private decimal _thuNhapChiuThue;
        private decimal _tNCTGiamThue;
        private bool _TuQuyetToan;
        private decimal _tuThienNhanDao;
        private int _userID;
        private decimal _bHXH = 0;
        private decimal _bHYT = 0;
        private decimal _bHTN = 0;
        private decimal _tongThuNhap = 0;
        private bool _daVietBienLai = false;
        private decimal _tongTienGiamTru = 0;
        private decimal _hesoPCCV = 0;


        private BangKeThueTNCNChild()
        {
            this._id = 0;
            this._userID = 0;
            this._ngayLap = DateTime.Today;
            this._nam = 0;
            this._maBoPhan = 0;
            this._maNhanVien = 0L;
            this._hoTen = string.Empty;
            this._mst = string.Empty;
            this._cmnd = string.Empty;
            this._thuNhapChiuThue = 0M;
            this._soNguoiPhuThuoc = 0;
            this._soThangGiamTru = 0;
            this._tuThienNhanDao = 0M;
            this._baoHiemBatBuoc = 0M;
            this._tNCTGiamThue = 0M;
            this._thueDaKhauTru = 0M;
            this._soThuePhaiNop = 0M;
            this._soThueNopThua = 0M;
            this._soThueKhauTru = 0M;
            this._maBoPhanQL = "";
            this._tenBoPhan = "";
            this._thueNLDDaNop = 0M;
            this._thueNLDNopThem = 0M;
            this._thueNLDTraLai = 0M;
            this._soThang = 0;
            this._TuQuyetToan = false;
            this._bHXH = 0;
            this._bHYT = 0;
            this._bHTN = 0;
            this._tongThuNhap = 0;
            this._daVietBienLai = false;
            this._tongTienGiamTru = 0;
            this._hesoPCCV = 0;
            base.ValidationRules.CheckRules();
            base.MarkAsChild();
        }

        private BangKeThueTNCNChild(SafeDataReader dr)
        {
            this._id = 0;
            this._userID = 0;
            this._ngayLap = DateTime.Today;
            this._nam = 0;
            this._maBoPhan = 0;
            this._maNhanVien = 0L;
            this._hoTen = string.Empty;
            this._mst = string.Empty;
            this._cmnd = string.Empty;
            this._thuNhapChiuThue = 0M;
            this._soNguoiPhuThuoc = 0;
            this._soThangGiamTru = 0;
            this._tuThienNhanDao = 0M;
            this._baoHiemBatBuoc = 0M;
            this._tNCTGiamThue = 0M;
            this._thueDaKhauTru = 0M;
            this._soThuePhaiNop = 0M;
            this._soThueNopThua = 0M;
            this._soThueKhauTru = 0M;
            this._maBoPhanQL = "";
            this._tenBoPhan = "";
            this._thueNLDDaNop = 0M;
            this._thueNLDNopThem = 0M;
            this._thueNLDTraLai = 0M;
            this._soThang = 0;
            this._TuQuyetToan = false;
            this._bHXH = 0;
            this._bHYT = 0;
            this._bHTN = 0;
            this._tongThuNhap = 0;
            this._daVietBienLai = false;
            this._tongTienGiamTru = 0;
            this._hesoPCCV = 0;

            base.MarkAsChild();
            this.Fetch(dr);
        }

        protected override void AddBusinessRules()
        {
            this.AddCommonRules();
            this.AddCustomRules();
        }

        private void AddCommonRules()
        {
            //base.ValidationRules.AddRule(new RuleHandler(CommonRules.StringRequired), "HoTen");
            //base.ValidationRules.AddRule(new RuleHandler(CommonRules.StringMaxLength), new CommonRules.MaxLengthRuleArgs("HoTen", 50));
            //base.ValidationRules.AddRule(new RuleHandler(CommonRules.StringMaxLength), new CommonRules.MaxLengthRuleArgs("Mst", 50));
            //base.ValidationRules.AddRule(new RuleHandler(CommonRules.StringMaxLength), new CommonRules.MaxLengthRuleArgs("Cmnd", 50));
        }

        private void AddCustomRules()
        {
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@UserID", this._userID);
            cm.Parameters.AddWithValue("@NgayLap", this._ngayLap);
            cm.Parameters.AddWithValue("@Nam", this._nam);
            cm.Parameters.AddWithValue("@MaBoPhan", this._maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", this._maNhanVien);
            cm.Parameters.AddWithValue("@MST", this._mst);
            cm.Parameters.AddWithValue("@HoTen", this._hoTen);
            cm.Parameters.AddWithValue("@CMND", this._cmnd);
            cm.Parameters.AddWithValue("@ThuNhapChiuThue", this._thuNhapChiuThue);
            cm.Parameters.AddWithValue("@SoNguoiPhuThuoc", this._soNguoiPhuThuoc);
            cm.Parameters.AddWithValue("@SoThangGiamTru", this._soThangGiamTru);
            cm.Parameters.AddWithValue("@TuThienNhanDao", this._tuThienNhanDao);
            cm.Parameters.AddWithValue("@BaoHiemBatBuoc", this._baoHiemBatBuoc);
            cm.Parameters.AddWithValue("@TNCTGiamThue", this._tNCTGiamThue);
            cm.Parameters.AddWithValue("@ThueDaKhauTru", this._thueDaKhauTru);
            cm.Parameters.AddWithValue("@SoThuePhaiNop", this._soThuePhaiNop);
            cm.Parameters.AddWithValue("@SoThueNopThua", this._soThueNopThua);
            cm.Parameters.AddWithValue("@SoThueKhauTru", this._soThueKhauTru);
            cm.Parameters.AddWithValue("@ThueNLDDaNop", this._thueNLDDaNop);
            cm.Parameters.AddWithValue("@ThueNLDNopThem", this._thueNLDNopThem);
            cm.Parameters.AddWithValue("@ThueNLDTraLai", this._thueNLDTraLai);
            cm.Parameters.AddWithValue("@TuQuyetToan", this._TuQuyetToan);
            cm.Parameters.AddWithValue("@ID", this._id);
            cm.Parameters.AddWithValue("@BHXH", this._bHXH);
            cm.Parameters.AddWithValue("@BHYT", this._bHYT);
            cm.Parameters.AddWithValue("@BHTN", this._bHTN);
            cm.Parameters.AddWithValue("@TongThuNhap", this._tongThuNhap);
            cm.Parameters.AddWithValue("@DaVietBienLai", _daVietBienLai);
            //cm.Parameters.AddWithValue("@TongTienGiamTru",_tongTienGiamTru);  
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", this._id);
            cm.Parameters.AddWithValue("@UserID", this._userID);
            cm.Parameters.AddWithValue("@NgayLap", this._ngayLap);
            cm.Parameters.AddWithValue("@Nam", this._nam);
            cm.Parameters.AddWithValue("@MaBoPhan", this._maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", this._maNhanVien);
            cm.Parameters.AddWithValue("@MST", this._mst);
            cm.Parameters.AddWithValue("@HoTen", this._hoTen);
            cm.Parameters.AddWithValue("@CMND", this._cmnd);
            cm.Parameters.AddWithValue("@ThuNhapChiuThue", this._thuNhapChiuThue);
            cm.Parameters.AddWithValue("@SoNguoiPhuThuoc", this._soNguoiPhuThuoc);
            cm.Parameters.AddWithValue("@SoThangGiamTru", this._soThangGiamTru);
            cm.Parameters.AddWithValue("@TuThienNhanDao", this._tuThienNhanDao);
            cm.Parameters.AddWithValue("@BaoHiemBatBuoc", this._baoHiemBatBuoc);
            cm.Parameters.AddWithValue("@TNCTGiamThue", this._tNCTGiamThue);
            cm.Parameters.AddWithValue("@ThueDaKhauTru", this._thueDaKhauTru);
            cm.Parameters.AddWithValue("@SoThuePhaiNop", this._soThuePhaiNop);
            cm.Parameters.AddWithValue("@SoThueNopThua", this._soThueNopThua);
            cm.Parameters.AddWithValue("@SoThueKhauTru", this._soThueKhauTru);
            cm.Parameters.AddWithValue("@ThueNLDDaNop", this._thueNLDDaNop);
            cm.Parameters.AddWithValue("@ThueNLDNopThem", this._thueNLDNopThem);
            cm.Parameters.AddWithValue("@ThueNLDTraLai", this._thueNLDTraLai);
            cm.Parameters.AddWithValue("@TuQuyetToan", this._TuQuyetToan);
            cm.Parameters.AddWithValue("@SoThang", this._soThang);
            cm.Parameters.AddWithValue("@BHXH", this._bHXH);
            cm.Parameters.AddWithValue("@BHYT", this._bHYT);
            cm.Parameters.AddWithValue("@BHTN", this._bHTN);
            cm.Parameters.AddWithValue("@TongThuNhap", this._tongThuNhap);
            cm.Parameters.AddWithValue("@DaVietBienLai", _daVietBienLai);
            //cm.Parameters.AddWithValue("@TongTienGiamTru", _tongTienGiamTru);  
            
        }

        internal void DeleteSelf(SqlTransaction tr)
        {
            if (this.IsDirty && !base.IsNew)
            {
                this.ExecuteDelete(tr);
                this.MarkNew();
            }
        }

        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Delete_BangKeThueTNCNChild";
                command.Parameters.AddWithValue("@ID", this._id);
                command.ExecuteNonQuery();
            }
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Insert_BangKeThueTNCNChild";
                this.AddInsertParameters(command);
                command.ExecuteNonQuery();
                this._id = (int) command.Parameters["@NewID"].Value;
            }
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Update_BangKeThueTNCNChild";
                this.AddUpdateParameters(command);
                command.ExecuteNonQuery();
            }
        }

        private void Fetch(SafeDataReader dr)
        {
            this.FetchObject(dr);
            this.MarkOld();
            base.ValidationRules.CheckRules();
            this.FetchChildren(dr);
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }

        private void FetchObject(SafeDataReader dr)
        {
            this._id = dr.GetInt32("ID");
            this._userID = dr.GetInt32("UserID");
            this._ngayLap = dr.GetDateTime("NgayLap");
            this._nam = dr.GetInt32("Nam");
            this._maBoPhan = dr.GetInt32("MaBoPhan");
            this._maNhanVien = dr.GetInt64("MaNhanVien");
            this._hoTen = dr.GetString("HoTen");
            this._mst = dr.GetString("MST");
            this._cmnd = dr.GetString("CMND");
            this._thuNhapChiuThue = dr.GetDecimal("ThuNhapChiuThue");
            this._soNguoiPhuThuoc = dr.GetInt32("SoNguoiPhuThuoc");
            this._soThangGiamTru = dr.GetInt32("SoThangGiamTru");
            this._tuThienNhanDao = dr.GetDecimal("TuThienNhanDao");
            this._baoHiemBatBuoc = dr.GetDecimal("BaoHiemBatBuoc");
            this._tNCTGiamThue = dr.GetDecimal("TNCTGiamThue");
            this._thueDaKhauTru = dr.GetDecimal("ThueDaKhauTru");
            this._soThuePhaiNop = dr.GetDecimal("SoThuePhaiNop");
            this._soThueNopThua = dr.GetDecimal("SoThueNopThua");
            this._soThueKhauTru = dr.GetDecimal("SoThueKhauTru");
            this._maBoPhanQL = dr.GetString("MaBoPhanQL");
            this._tenBoPhan = dr.GetString("TenBoPhan");
            this._thueNLDDaNop = dr.GetDecimal("ThueNLDDaNop");
            this._thueNLDNopThem = dr.GetDecimal("ThueNLDNopThem");
            this._thueNLDTraLai = dr.GetDecimal("ThueNLDTraLai");
            this._soThang = dr.GetInt32("SoThang");
            this._TuQuyetToan = dr.GetBoolean("TuQuyetToan");
            this._bHXH = dr.GetDecimal("BHXH");
            this._bHYT = dr.GetDecimal("BHYT");
            this._bHTN = dr.GetDecimal("BHTN");
            this._tongThuNhap = dr.GetDecimal("TongThuNhap");
            this._daVietBienLai = dr.GetBoolean("DaVietBienLai");
            this._tongTienGiamTru = dr.GetDecimal("TongTienGiamTru");
            this._hesoPCCV = dr.GetDecimal("HeSoPCCV");
          
        }

        internal static BangKeThueTNCNChild GetBangKeThueTNCNChild(SafeDataReader dr)
        {
            return new BangKeThueTNCNChild(dr);
        }
        internal static BangKeThueTNCNChild GetBangKeThueTNCNChild2013(SafeDataReader dr)
        {
            BangKeThueTNCNChild bk = BangKeThueTNCNChild.NewBangKeThueTNCNChild();
            bk._nam = dr.GetInt32("Nam");
            bk._maBoPhan = dr.GetInt32("MaBoPhan");
            bk._maBoPhanQL = dr.GetString("MaBoPhanQL");
            bk._tenBoPhan = dr.GetString("TenBoPhan");
            bk._maNhanVien = dr.GetInt64("MaNhanVien");
            bk._hoTen = dr.GetString("HoTen");
            bk._mst = dr.GetString("MST");
            bk._cmnd = dr.GetString("CMND");
            bk._thuNhapChiuThue = dr.GetDecimal("ThuNhapChiuThue");
            bk._baoHiemBatBuoc = dr.GetDecimal("BaoHiemBatBuoc");
            bk._soThuePhaiNop = dr.GetDecimal("SoThuePhaiNop");
            bk._thueNLDDaNop = dr.GetDecimal("ThueNLDDaNop");
            bk._thueNLDNopThem = dr.GetDecimal("ThueNLDNopThem");
            bk._thueNLDTraLai = dr.GetDecimal("ThueNLDTraLai");
            bk._soThang = dr.GetInt32("SoThang");
            bk._TuQuyetToan = dr.GetBoolean("TuQuyetToan");
            bk._bHXH = dr.GetDecimal("BHXH");
            bk._bHYT = dr.GetDecimal("BHYT");
            bk._bHTN = dr.GetDecimal("BHTN");
            bk._tongThuNhap = dr.GetDecimal("TongThuNhap");
            return bk;
        }

        protected override object GetIdValue()
        {
            return this._id;
        }

        internal void Insert(SqlTransaction tr)
        {
            if (this.IsDirty)
            {
                this.ExecuteInsert(tr);
                this.MarkOld();
                this.UpdateChildren(tr);
            }
        }

        internal static BangKeThueTNCNChild NewBangKeThueTNCNChild()
        {
            return new BangKeThueTNCNChild();
        }

        public void TinhLaiThueTNCN()
        {
            if (this._TuQuyetToan)
            {
                this.SoThuePhaiNop = 0M;
            }
            else
            {
                decimal num = 0M;
                num = (((this._thuNhapChiuThue - (this._soThangGiamTru * 0x186a00)) - (this._soThang * 0x3d0900)) - this._tuThienNhanDao) - this._baoHiemBatBuoc;
                if (num > 0M)
                {
                    num = Math.Round((decimal) (num / this._soThang), 0);
                }
                else
                {
                    num = 0M;
                }
                if (num > 80000000M)
                {
                    this.SoThuePhaiNop = ((num * 0.35M) - 9850000M) * this._soThang;
                }
                else if (num > 52000000M)
                {
                    this.SoThuePhaiNop = ((num * 0.3M) - 5850000M) * this._soThang;
                }
                else if (num > 32000000M)
                {
                    this.SoThuePhaiNop = ((num * 0.25M) - 3250000M) * this._soThang;
                }
                else if (num > 18000000M)
                {
                    this.SoThuePhaiNop = ((num * 0.2M) - 1650000M) * this._soThang;
                }
                else if (num > 10000000M)
                {
                    this.SoThuePhaiNop = ((num * 0.15M) - 750000M) * this._soThang;
                }
                else if (num > 5000000M)
                {
                    this.SoThuePhaiNop = ((num * 0.1M) - 250000M) * this._soThang;
                }
                else
                {
                    this.SoThuePhaiNop = (num * 0.05M) * this._soThang;
                }
            }
        }

        internal void Update(SqlTransaction tr)
        {
            if (this.IsDirty)
            {
                if (base.IsDirty)
                {
                    this.ExecuteUpdate(tr);
                    this.MarkOld();
                }
                this.UpdateChildren(tr);
            }
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }

        public decimal BaoHiemBatBuoc
        {
            get
            {
                return this._baoHiemBatBuoc;
            }
            set
            {
                if (!this._baoHiemBatBuoc.Equals(value))
                {
                    this._baoHiemBatBuoc = value;
                    this.PropertyHasChanged("BaoHiemBatBuoc");
                    this.TinhLaiThueTNCN();
                }
            }
        }

        public string Cmnd
        {
            get
            {
                return this._cmnd;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                if (!this._cmnd.Equals(value))
                {
                    this._cmnd = value;
                    this.PropertyHasChanged("Cmnd");
                }
            }
        }

        public string HoTen
        {
            get
            {
                return this._hoTen;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                if (!this._hoTen.Equals(value))
                {
                    this._hoTen = value;
                    this.PropertyHasChanged("HoTen");
                }
            }
        }

        [DataObjectField(true, true)]
        public int Id
        {
            get
            {
                return this._id;
            }
        }

        public int MaBoPhan
        {
            get
            {
                return this._maBoPhan;
            }
            set
            {
                if (!this._maBoPhan.Equals(value))
                {
                    this._maBoPhan = value;
                    this.PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public string MaBoPhanQL
        {
            get
            {
                return this._maBoPhanQL;
            }
        }

        public long MaNhanVien
        {
            get
            {
                return this._maNhanVien;
            }
            set
            {
                if (!this._maNhanVien.Equals(value))
                {
                    this._maNhanVien = value;
                    this.PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public string Mst
        {
            get
            {
                return this._mst;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                if (!this._mst.Equals(value))
                {
                    this._mst = value;
                    this.PropertyHasChanged("Mst");
                }
            }
        }

        public int Nam
        {
            get
            {
                return this._nam;
            }
            set
            {
                if (!this._nam.Equals(value))
                {
                    this._nam = value;
                    this.PropertyHasChanged("Nam");
                }
            }
        }

        public DateTime NgayLap
        {
            get
            {
                return this._ngayLap.Date;
            }
            set
            {
                if (!this._ngayLap.Equals(value))
                {
                    this._ngayLap = value;
                    base.PropertyHasChanged();
                }
            }
        }

        public int SoNguoiPhuThuoc
        {
            get
            {
                return this._soNguoiPhuThuoc;
            }
            set
            {
                if (!this._soNguoiPhuThuoc.Equals(value))
                {
                    this._soNguoiPhuThuoc = value;
                    this.PropertyHasChanged("SoNguoiPhuThuoc");
                }
            }
        }

        public int SoThang
        {
            get
            {
                return this._soThang;
            }
            set
            {
                if (!this._soThang.Equals(value))
                {
                    this._soThang = value;
                    base.PropertyHasChanged();
                    this.TinhLaiThueTNCN();
                }
            }
        }

        public int SoThangGiamTru
        {
            get
            {
                return this._soThangGiamTru;
            }
            set
            {
                if (!this._soThangGiamTru.Equals(value))
                {
                    this._soThangGiamTru = value;
                    this.PropertyHasChanged("SoThangGiamTru");
                    this.TinhLaiThueTNCN();
                }
            }
        }

        public decimal SoThueKhauTru
        {
            get
            {
                return this._soThueKhauTru;
            }
            set
            {
                if (!this._soThueKhauTru.Equals(value))
                {
                    this._soThueKhauTru = value;
                    this.PropertyHasChanged("SoThueKhauTru");
                }
            }
        }

        public decimal SoThueNopThua
        {
            get
            {
                return this._soThueNopThua;
            }
            set
            {
                if (!this._soThueNopThua.Equals(value))
                {
                    this._soThueNopThua = value;
                    this.PropertyHasChanged("SoThueNopThua");
                }
            }
        }

        public decimal SoThuePhaiNop
        {
            get
            {
                return this._soThuePhaiNop;
            }
            set
            {
                if (!this._soThuePhaiNop.Equals(value))
                {
                    this._soThuePhaiNop = value;
                    this.PropertyHasChanged("SoThuePhaiNop");
                    if (this._TuQuyetToan)
                    {
                        this.SoThueNopThua = 0M;
                        this.SoThueKhauTru = 0M;
                        this.ThueNLDNopThem = 0M;
                        this.ThueNLDTraLai = 0M;
                    }
                    else
                    {
                        if (this._soThuePhaiNop < this._thueDaKhauTru)
                        {
                            this.SoThueNopThua = this._thueDaKhauTru - this._soThuePhaiNop;
                            this.SoThueKhauTru = 0M;
                        }
                        else
                        {
                            this.SoThueNopThua = 0M;
                            this.SoThueKhauTru = this._soThuePhaiNop - this._thueDaKhauTru;
                        }
                        if (this._soThuePhaiNop < this._thueNLDDaNop)
                        {
                            this.ThueNLDTraLai = this._thueNLDDaNop - this._soThuePhaiNop;
                            this.ThueNLDNopThem = 0M;
                        }
                        else
                        {
                            this.ThueNLDTraLai = 0M;
                            this.ThueNLDNopThem = this._soThuePhaiNop - this._thueNLDDaNop;
                        }
                    }
                }
            }
        }

        public string TenBoPhan
        {
            get
            {
                return this._tenBoPhan;
            }
        }

        public decimal ThueDaKhauTru
        {
            get
            {
                return this._thueDaKhauTru;
            }
            set
            {
                if (!this._thueDaKhauTru.Equals(value))
                {
                    this._thueDaKhauTru = value;
                    this.PropertyHasChanged("ThueDaKhauTru");
                    if (this._TuQuyetToan)
                    {
                        this.SoThueNopThua = 0M;
                        this.SoThueKhauTru = 0M;
                    }
                    else if (this._soThuePhaiNop < this._thueDaKhauTru)
                    {
                        this.SoThueNopThua = this._thueDaKhauTru - this._soThuePhaiNop;
                        this.SoThueKhauTru = 0M;
                    }
                    else
                    {
                        this.SoThueNopThua = 0M;
                        this.SoThueKhauTru = this._soThuePhaiNop - this._thueDaKhauTru;
                    }
                }
            }
        }

        public decimal ThueNLDDaNop
        {
            get
            {
                return this._thueNLDDaNop;
            }
            set
            {
                if (!this._thueNLDDaNop.Equals(value))
                {
                    this._thueNLDDaNop = value;
                    base.PropertyHasChanged();
                    if (this._TuQuyetToan)
                    {
                        this.ThueNLDNopThem = 0M;
                        this.ThueNLDTraLai = 0M;
                    }
                    else if (this._soThuePhaiNop < this._thueNLDDaNop)
                    {
                        this.ThueNLDTraLai = this._thueNLDDaNop - this._soThuePhaiNop;
                        this.ThueNLDNopThem = 0M;
                    }
                    else
                    {
                        this.ThueNLDTraLai = 0M;
                        this.ThueNLDNopThem = this._soThuePhaiNop - this._thueNLDDaNop;
                    }
                }
            }
        }

        public decimal ThueNLDNopThem
        {
            get
            {
                return this._thueNLDNopThem;
            }
            set
            {
                if (!this._thueNLDNopThem.Equals(value))
                {
                    this._thueNLDNopThem = value;
                    base.PropertyHasChanged();
                }
            }
        }

        public decimal ThueNLDTraLai
        {
            get
            {
                return this._thueNLDTraLai;
            }
            set
            {
                if (!this._thueNLDTraLai.Equals(value))
                {
                    this._thueNLDTraLai = value;
                    base.PropertyHasChanged();
                }
            }
        }

        public decimal ThuNhapChiuThue
        {
            get
            {
                return this._thuNhapChiuThue;
            }
            set
            {
                if (!this._thuNhapChiuThue.Equals(value))
                {
                    this._thuNhapChiuThue = value;
                    this.PropertyHasChanged("ThuNhapChiuThue");
                    this.TinhLaiThueTNCN();
                }
            }
        }

        public decimal TNCTGiamThue
        {
            get
            {
                return this._tNCTGiamThue;
            }
            set
            {
                if (!this._tNCTGiamThue.Equals(value))
                {
                    this._tNCTGiamThue = value;
                    this.PropertyHasChanged("TNCTGiamThue");
                }
            }
        }

        public bool TuQuyetToan
        {
            get
            {
                return this._TuQuyetToan;
            }
            set
            {
                if (!this._TuQuyetToan.Equals(value))
                {
                    this._TuQuyetToan = value;
                    base.PropertyHasChanged();
                    this.TinhLaiThueTNCN();
                }
            }
        }

        public decimal TuThienNhanDao
        {
            get
            {
                return this._tuThienNhanDao;
            }
            set
            {
                if (!this._tuThienNhanDao.Equals(value))
                {
                    this._tuThienNhanDao = value;
                    this.PropertyHasChanged("TuThienNhanDao");
                    this.TinhLaiThueTNCN();
                }
            }
        }

        public int UserID
        {
            get
            {
                return this._userID;
            }
            set
            {
                if (!this._userID.Equals(value))
                {
                    this._userID = value;
                    this.PropertyHasChanged("UserID");
                }
            }
        }

        public decimal BHXH
        {
            get
            {
                return this._bHXH;
            }
            set
            {
                if (!this._bHXH.Equals(value))
                {
                    this._bHXH = value;
                    this.PropertyHasChanged("BHXH");
                    _baoHiemBatBuoc = _bHXH + _bHYT + _bHTN;
                    //TinhLaiThueTNCN();
                }
            }
        }

        public decimal BHYT
        {
            get
            {
                return this._bHYT;
            }
            set
            {
                if (!this._bHYT.Equals(value))
                {
                    this._bHYT = value;
                    this.PropertyHasChanged("BHYT");
                    //TinhLaiThueTNCN();
                    _baoHiemBatBuoc = _bHXH + _bHYT + _bHTN;

                }
            }
        }


        public decimal BHTN
        {
            get
            {
                return this._bHTN;
            }
            set
            {
                if (!this._bHTN.Equals(value))
                {
                    this._bHTN = value;
                    this.PropertyHasChanged("BHTN");
                    //TinhLaiThueTNCN();
                    _baoHiemBatBuoc = _bHXH + _bHYT + _bHTN;

                }
            }
        }


        public decimal TongThuNhap
        {
            get
            {
                return this._tongThuNhap;
            }
            set
            {
                if (!this._tongThuNhap.Equals(value))
                {
                    this._tongThuNhap = value;
                    this.PropertyHasChanged("TongThuNhap");
                }
            }
        }

        public bool DaVietBienLai
        {
            get
            {
                return this._daVietBienLai;
            }
            set
            {
                if (!this._daVietBienLai.Equals(value))
                {
                    this._daVietBienLai = value;
                    this.PropertyHasChanged("DaVietBienLai");
                }
            }
        }

        public decimal TongTienGiamTru
        {
            get
            {
                return this._tongTienGiamTru ;
            }
            set
            {
                if (!this._tongTienGiamTru.Equals(value))
                {
                    this._tongTienGiamTru = value;
                    this.PropertyHasChanged("TongTienGiamTru");
                  
                }
            }
        }

        public decimal HeSoPCCV
        {
            get
            {
                return this._hesoPCCV;
            }
            set
            {
                if (!this._hesoPCCV.Equals(value))
                {
                    this._hesoPCCV = value;
                    this.PropertyHasChanged("HeSoPCCV");

                }
            }
        }


    }
}

