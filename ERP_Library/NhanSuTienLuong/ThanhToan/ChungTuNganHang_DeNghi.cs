
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTuNganHang_DeNghi : Csla.BusinessBase<ChungTuNganHang_DeNghi>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChungTu = 0;
        private long _maDeNghi = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _lyDo = string.Empty;
        private decimal _soTien = 0;
        private string _tinhTrang = "";
        private string _phanLoai = "";
        private string _nganHang = "";
        private string _NguoiLap = string.Empty;
        private string _soDeNghi = string.Empty;
        private string _tenDoiTac = string.Empty;
        private string _taiKhoanDT = string.Empty;
        private DateTime _ngaylap = DateTime.Now.Date;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaChungTu
        {
            get
            {
                return _maChungTu;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaDeNghi
        {
            get
            {
                return _maDeNghi;
            }
        }

        public string MaBoPhanQL
        {
            get
            {
                return _maBoPhanQL;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_maBoPhanQL.Equals(value))
                {
                    _maBoPhanQL = value;
                    PropertyHasChanged("MaBoPhanQL");
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

        public string LyDo
        {
            get
            {
                return _lyDo;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_lyDo.Equals(value))
                {
                    _lyDo = value;
                    PropertyHasChanged("LyDo");
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

        public string TinhTrang
        {
            get
            {
                return _tinhTrang;
            }
            set
            {
                if (!_tinhTrang.Equals(value))
                {
                    _tinhTrang = value;
                    //cập nhật vào database
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        SqlTransaction tr;
                        tr = cn.BeginTransaction();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.Transaction = tr;
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "Update tblDeNghiChuyenKhoan Set TinhTrang = @TinhTrang Where MaPhieu = @MaPhieu";
                            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
                            cm.Parameters.AddWithValue("@MaPhieu", _maDeNghi);
                            try
                            {
                                cm.ExecuteNonQuery();
                                tr.Commit();
                            }
                            catch (Exception ex)
                            {
                                tr.Rollback();
                            }
                        }
                        cn.Close();
                    }
                }
            }
        }

        public string NganHang
        {
            get
            {
                return _nganHang;
            }
        }

        public string PhaLoai
        {
            get
            {
                return _phanLoai;
            }
        }

        public string NguoiLap
        {
            get
            {
                return _NguoiLap;
            }
        }

        public string SoDeNghi
        {
            get
            {
                return _soDeNghi;
            }
        }

        public string TenDoiTac
        {
            get
            {
                return _tenDoiTac;
            }
        }

        public DateTime NgayLap 
        {
            get
            {
                return _ngaylap;
            }
        }

        public string TKDoiTac
        {
            get
            {
                return _taiKhoanDT;
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}", _maChungTu, _maDeNghi);
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
            // MaBoPhanQL
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaBoPhanQL", 50));
            //
            // TenBoPhan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 200));
            //
            // LyDo
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "LyDo");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 250));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Factory Methods
        internal static ChungTuNganHang_DeNghi NewChungTuNganHang_DeNghi(int maChungTu, long maDeNghi, int databaseDeNghi)
        {
            return new ChungTuNganHang_DeNghi(maChungTu, maDeNghi);
        }

        internal static ChungTuNganHang_DeNghi GetChungTuNganHang_DeNghi(SafeDataReader dr)
        {
            return new ChungTuNganHang_DeNghi(dr);
        }

        internal static ChungTuNganHang_DeNghi GetChungTuNganHang_DeNghi_New(SafeDataReader dr)
        {
            ChungTuNganHang_DeNghi child = new ChungTuNganHang_DeNghi();
            child.MarkAsChild();
            child.Fetch_New(dr);
            return child;
        }

        public ChungTuNganHang_DeNghi(int maChungTu, long maDeNghi)
        {
            this._maChungTu = maChungTu;
            this._maDeNghi = maDeNghi;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChungTuNganHang_DeNghi()
        {
        }

        private ChungTuNganHang_DeNghi(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void Fetch_New(SafeDataReader dr)
        {
            FetchObject_New(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maChungTu = dr.GetInt32("MaChungTu");
            _maDeNghi = dr.GetInt64("MaDeNghi");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _lyDo = dr.GetString("LyDo");
            _soTien = dr.GetDecimal("SoTien");
            _tinhTrang = dr.GetString("TinhTrang");
            _nganHang = dr.GetString("NganHang");
            _phanLoai = dr.GetString("LoaiNV");
            _soDeNghi = dr.GetString("SoDeNghi");
            _ngaylap = dr.GetDateTime("NgayLap");
        }

        private void FetchObject_New(SafeDataReader dr)
        {
            _maChungTu = dr.GetInt32("MaChungTu");
            _maDeNghi = dr.GetInt64("MaDeNghi");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _lyDo = dr.GetString("LyDo");
            _soTien = dr.GetDecimal("SoTien");
            _tinhTrang = dr.GetString("TinhTrang");
            _nganHang = dr.GetString("NganHang");
            _phanLoai = dr.GetString("LoaiNV");
            _NguoiLap = dr.GetString("NguoiLap");
            _soDeNghi = dr.GetString("SoDeNghi");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _taiKhoanDT = dr.GetString("SoTaiKhoan");
            _ngaylap = dr.GetDateTime("NgayLap");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ChungTuNganHang parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ChungTuNganHang parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_ChungTuNganHang_DeNghi";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTuNganHang parent)
        {
            _maChungTu = parent.MaChungTu;
            cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ChungTuNganHang parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChungTuNganHang parent)
        {
            //using (SqlCommand cm = tr.Connection.CreateCommand())
            //{
            //    cm.Transaction = tr;
            //    cm.CommandType = CommandType.StoredProcedure;
            //    cm.CommandText = "spd_Update_ChungTuNganHang_DeNghi";

            //    AddUpdateParameters(cm, parent);

            //    cm.ExecuteNonQuery();

            //}//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTuNganHang parent)
        {
            //cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            //cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
            //if (_maBoPhanQL.Length > 0)
            //    cm.Parameters.AddWithValue("@MaBoPhanQL", _maBoPhanQL);
            //else
            //    cm.Parameters.AddWithValue("@MaBoPhanQL", DBNull.Value);
            //if (_tenBoPhan.Length > 0)
            //    cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
            //else
            //    cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            //cm.Parameters.AddWithValue("@LyDo", _lyDo);
            //cm.Parameters.AddWithValue("@SoTien", _soTien);
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

            ExecuteDelete(tr);
            MarkNew();
        }

        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Delete_ChungTuNganHang_DeNghi";

                cm.Parameters.AddWithValue("@MaChungTu", this._maChungTu);
                cm.Parameters.AddWithValue("@MaDeNghi", this._maDeNghi);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
