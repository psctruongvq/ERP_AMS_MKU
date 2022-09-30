using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietCCDCChild : Csla.BusinessBase<ChiTietCCDCChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private string _tenChiTiet = string.Empty;
        private decimal _nguyenGia = 0;
        private int _maQuocGiaSX = 0;
        private string _maDVT = string.Empty;
        private int _maCongCuDungCu = 0;
        private int _testMaChiTiet = 0;
        private int _testMaQuocGiaSX = 0;
        private int _testMaDVT = 0;
        private int _testMaTSCDCaBiet = 0;
        private int _namSanXuat = 0;
        private int _soLuong = 1;
        private string _model = string.Empty;
        private string _serial = string.Empty;
        private string _soHieu = string.Empty;
        private decimal _nguyenGiaTinhKhauHao = 0;
        private bool _testChoDuyet = false;
        private string _ghiChu = string.Empty;
        private decimal _chiPhi = 0;
        private decimal _donGia = 0;

        private decimal _giaTri = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public string TenChiTiet
        {
            get
            {
                CanReadProperty("TenChiTiet", true);
                return _tenChiTiet;
            }
            set
            {
                CanWriteProperty("TenChiTiet", true);
                if (value == null) value = string.Empty;
                if (!_tenChiTiet.Equals(value))
                {
                    _tenChiTiet = value;
                    PropertyHasChanged("TenChiTiet");
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
                    _giaTri = (_soLuong == 0 ? 1 : _soLuong) * NguyenGia;
                    PropertyHasChanged("NguyenGia");
                }
            }
        }

        public int MaQuocGiaSX
        {
            get
            {
                CanReadProperty("MaQuocGiaSX", true);
                return _maQuocGiaSX;
            }
            set
            {
                CanWriteProperty("MaQuocGiaSX", true);
                if (!_maQuocGiaSX.Equals(value))
                {
                    _maQuocGiaSX = value;
                    PropertyHasChanged("MaQuocGiaSX");
                }
            }
        }

        public string MaDVT
        {
            get
            {
                CanReadProperty("MaDVT", true);
                return _maDVT;
            }
            set
            {
                CanWriteProperty("MaDVT", true);
                if (value == null) value = string.Empty;
                if (!_maDVT.Equals(value))
                {
                    _maDVT = value;
                    PropertyHasChanged("MaDVT");
                }
            }
        }

        public int MaCongCuDungCu
        {
            get
            {
                CanReadProperty("MaCongCuDungCu", true);
                return _maCongCuDungCu;
            }
            set
            {
                CanWriteProperty("MaCongCuDungCu", true);
                if (!_maCongCuDungCu.Equals(value))
                {
                    _maCongCuDungCu = value;
                    PropertyHasChanged("MaCongCuDungCu");
                }
            }
        }

        public int TestMaChiTiet
        {
            get
            {
                CanReadProperty("TestMaChiTiet", true);
                return _testMaChiTiet;
            }
            set
            {
                CanWriteProperty("TestMaChiTiet", true);
                if (!_testMaChiTiet.Equals(value))
                {
                    _testMaChiTiet = value;
                    PropertyHasChanged("TestMaChiTiet");
                }
            }
        }

        public int TestMaQuocGiaSX
        {
            get
            {
                CanReadProperty("TestMaQuocGiaSX", true);
                return _testMaQuocGiaSX;
            }
            set
            {
                CanWriteProperty("TestMaQuocGiaSX", true);
                if (!_testMaQuocGiaSX.Equals(value))
                {
                    _testMaQuocGiaSX = value;
                    PropertyHasChanged("TestMaQuocGiaSX");
                }
            }
        }

        public int TestMaDVT
        {
            get
            {
                CanReadProperty("TestMaDVT", true);
                return _testMaDVT;
            }
            set
            {
                CanWriteProperty("TestMaDVT", true);
                if (!_testMaDVT.Equals(value))
                {
                    _testMaDVT = value;
                    PropertyHasChanged("TestMaDVT");
                }
            }
        }

        public int TestMaTSCDCaBiet
        {
            get
            {
                CanReadProperty("TestMaTSCDCaBiet", true);
                return _testMaTSCDCaBiet;
            }
            set
            {
                CanWriteProperty("TestMaTSCDCaBiet", true);
                if (!_testMaTSCDCaBiet.Equals(value))
                {
                    _testMaTSCDCaBiet = value;
                    PropertyHasChanged("TestMaTSCDCaBiet");
                }
            }
        }

        public int NamSanXuat
        {
            get
            {
                CanReadProperty("NamSanXuat", true);
                return _namSanXuat;
            }
            set
            {
                CanWriteProperty("NamSanXuat", true);
                if (!_namSanXuat.Equals(value))
                {
                    _namSanXuat = value;
                    PropertyHasChanged("NamSanXuat");
                }
            }
        }

        public int SoLuong
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
                    _giaTri = (_soLuong == 0 ? 1 : _soLuong) * NguyenGia;//
                    PropertyHasChanged("SoLuong");
                }
            }
        }

        public string Model
        {
            get
            {
                CanReadProperty("Model", true);
                return _model;
            }
            set
            {
                CanWriteProperty("Model", true);
                if (value == null) value = string.Empty;
                if (!_model.Equals(value))
                {
                    _model = value;
                    PropertyHasChanged("Model");
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

        public string SoHieu
        {
            get
            {
                CanReadProperty("SoHieu", true);
                return _soHieu;
            }
            set
            {
                CanWriteProperty("SoHieu", true);
                if (value == null) value = string.Empty;
                if (!_soHieu.Equals(value))
                {
                    _soHieu = value;
                    PropertyHasChanged("SoHieu");
                }
            }
        }

        public decimal NguyenGiaTinhKhauHao
        {
            get
            {
                CanReadProperty("NguyenGiaTinhKhauHao", true);
                return _nguyenGiaTinhKhauHao;
            }
            set
            {
                CanWriteProperty("NguyenGiaTinhKhauHao", true);
                if (!_nguyenGiaTinhKhauHao.Equals(value))
                {
                    _nguyenGiaTinhKhauHao = value;
                    PropertyHasChanged("NguyenGiaTinhKhauHao");
                }
            }
        }

        public bool TestChoDuyet
        {
            get
            {
                CanReadProperty("TestChoDuyet", true);
                return _testChoDuyet;
            }
            set
            {
                CanWriteProperty("TestChoDuyet", true);
                if (!_testChoDuyet.Equals(value))
                {
                    _testChoDuyet = value;
                    PropertyHasChanged("TestChoDuyet");
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

        public decimal ChiPhi
        {
            get
            {
                CanReadProperty("ChiPhi", true);
                return _chiPhi;
            }
            set
            {
                CanWriteProperty("ChiPhi", true);
                if (!_chiPhi.Equals(value))
                {
                    _chiPhi = value;
                    PropertyHasChanged("ChiPhi");
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

        public decimal GiaTri
        {
            get
            {
                CanReadProperty("GiaTri", true);
                return _giaTri;
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTiet;
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
            // TenChiTiet
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenChiTiet");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChiTiet", 4000));
            //
            // MaDVT
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaDVT", 10));
            //
            // Model
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Model", 50));
            //
            // Serial
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Serial", 50));
            //
            // SoHieu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHieu", 30));
            //
            // GhiChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
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
            //TODO: Define authorization rules in ChiTietCCDCChild
            //AuthorizationRules.AllowRead("MaChiTiet", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("TenChiTiet", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("NguyenGia", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("MaQuocGiaSX", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("MaDVT", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("MaCongCuDungCu", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("TestMaChiTiet", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("TestMaQuocGiaSX", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("TestMaDVT", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("TestMaTSCDCaBiet", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("NamSanXuat", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("SoLuong", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("Model", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("Serial", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("SoHieu", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("NguyenGiaTinhKhauHao", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("TestChoDuyet", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("ChiPhi", "ChiTietCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("DonGia", "ChiTietCCDCChildReadGroup");

            //AuthorizationRules.AllowWrite("TenChiTiet", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("NguyenGia", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaQuocGiaSX", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaDVT", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongCuDungCu", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("TestMaChiTiet", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("TestMaQuocGiaSX", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("TestMaDVT", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("TestMaTSCDCaBiet", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("NamSanXuat", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuong", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("Model", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("Serial", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoHieu", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("NguyenGiaTinhKhauHao", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("TestChoDuyet", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("ChiPhi", "ChiTietCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("DonGia", "ChiTietCCDCChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChiTietCCDCChild NewChiTietCCDCChild()
        {
            return new ChiTietCCDCChild();
        }

        internal static ChiTietCCDCChild GetChiTietCCDCChild(SafeDataReader dr)
        {
            return new ChiTietCCDCChild(dr);
        }

        private ChiTietCCDCChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChiTietCCDCChild(SafeDataReader dr)
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

        private void FetchObject(SafeDataReader dr)
        {
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _tenChiTiet = dr.GetString("TenChiTiet");
            _nguyenGia = dr.GetDecimal("NguyenGia");
            _maQuocGiaSX = dr.GetInt32("MaQuocGiaSX");
            _maDVT = dr.GetString("MaDVT");
            _maCongCuDungCu = dr.GetInt32("MaCongCuDungCu");
            _testMaChiTiet = dr.GetInt32("TestMaChiTiet");
            _testMaQuocGiaSX = dr.GetInt32("TestMaQuocGiaSX");
            _testMaDVT = dr.GetInt32("TestMaDVT");
            _testMaTSCDCaBiet = dr.GetInt32("TestMaTSCDCaBiet");
            _namSanXuat = dr.GetInt32("NamSanXuat");
            _soLuong = dr.GetInt32("SoLuong");
            _model = dr.GetString("Model");
            _serial = dr.GetString("Serial");
            _soHieu = dr.GetString("SoHieu");
            _nguyenGiaTinhKhauHao = dr.GetDecimal("NguyenGiaTinhKhauHao");
            _testChoDuyet = dr.GetBoolean("TestChoDuyet");
            _ghiChu = dr.GetString("GhiChu");
            _chiPhi = dr.GetDecimal("ChiPhi");
            _donGia = dr.GetDecimal("DonGia");

            _giaTri = _nguyenGia * (_soLuong == 0 ? 1 : _soLuong);
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, CCDC parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, CCDC parent)
        {
            using (SqlCommand cm =tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChiTietCCDC";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, CCDC parent)
        {
            _maCongCuDungCu = parent.MaCongCuDungCu;
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@TenChiTiet", _tenChiTiet);
            if (_nguyenGia != 0)
                cm.Parameters.AddWithValue("@NguyenGia", _nguyenGia);
            else
                cm.Parameters.AddWithValue("@NguyenGia", DBNull.Value);
            if (_maQuocGiaSX != 0)
                cm.Parameters.AddWithValue("@MaQuocGiaSX", _maQuocGiaSX);
            else
                cm.Parameters.AddWithValue("@MaQuocGiaSX", DBNull.Value);
            if (_maDVT.Length > 0)
                cm.Parameters.AddWithValue("@MaDVT", _maDVT);
            else
                cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
            if (_testMaChiTiet != 0)
                cm.Parameters.AddWithValue("@TestMaChiTiet", _testMaChiTiet);
            else
                cm.Parameters.AddWithValue("@TestMaChiTiet", DBNull.Value);
            if (_testMaQuocGiaSX != 0)
                cm.Parameters.AddWithValue("@TestMaQuocGiaSX", _testMaQuocGiaSX);
            else
                cm.Parameters.AddWithValue("@TestMaQuocGiaSX", DBNull.Value);
            if (_testMaDVT != 0)
                cm.Parameters.AddWithValue("@TestMaDVT", _testMaDVT);
            else
                cm.Parameters.AddWithValue("@TestMaDVT", DBNull.Value);
            if (_testMaTSCDCaBiet != 0)
                cm.Parameters.AddWithValue("@TestMaTSCDCaBiet", _testMaTSCDCaBiet);
            else
                cm.Parameters.AddWithValue("@TestMaTSCDCaBiet", DBNull.Value);
            if (_namSanXuat != 0)
                cm.Parameters.AddWithValue("@NamSanXuat", _namSanXuat);
            else
                cm.Parameters.AddWithValue("@NamSanXuat", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_model.Length > 0)
                cm.Parameters.AddWithValue("@Model", _model);
            else
                cm.Parameters.AddWithValue("@Model", DBNull.Value);
            if (_serial.Length > 0)
                cm.Parameters.AddWithValue("@Serial", _serial);
            else
                cm.Parameters.AddWithValue("@Serial", DBNull.Value);
            if (_soHieu.Length > 0)
                cm.Parameters.AddWithValue("@SoHieu", _soHieu);
            else
                cm.Parameters.AddWithValue("@SoHieu", DBNull.Value);
            if (_nguyenGiaTinhKhauHao != 0)
                cm.Parameters.AddWithValue("@NguyenGiaTinhKhauHao", _nguyenGiaTinhKhauHao);
            else
                cm.Parameters.AddWithValue("@NguyenGiaTinhKhauHao", DBNull.Value);
            if (_testChoDuyet != false)
                cm.Parameters.AddWithValue("@TestChoDuyet", _testChoDuyet);
            else
                cm.Parameters.AddWithValue("@TestChoDuyet", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_chiPhi != 0)
                cm.Parameters.AddWithValue("@ChiPhi", _chiPhi);
            else
                cm.Parameters.AddWithValue("@ChiPhi", DBNull.Value);
            if (_donGia != 0)
                cm.Parameters.AddWithValue("@DonGia", _donGia);
            else
                cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, CCDC parent)
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

        private void ExecuteUpdate(SqlTransaction tr, CCDC parent)
        {
            using (SqlCommand cm =tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChiTietCCDC";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, CCDC parent)
        {
            _maCongCuDungCu = parent.MaCongCuDungCu;
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters.AddWithValue("@TenChiTiet", _tenChiTiet);
            if (_nguyenGia != 0)
                cm.Parameters.AddWithValue("@NguyenGia", _nguyenGia);
            else
                cm.Parameters.AddWithValue("@NguyenGia", DBNull.Value);
            if (_maQuocGiaSX != 0)
                cm.Parameters.AddWithValue("@MaQuocGiaSX", _maQuocGiaSX);
            else
                cm.Parameters.AddWithValue("@MaQuocGiaSX", DBNull.Value);
            if (_maDVT.Length > 0)
                cm.Parameters.AddWithValue("@MaDVT", _maDVT);
            else
                cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
            if (_testMaChiTiet != 0)
                cm.Parameters.AddWithValue("@TestMaChiTiet", _testMaChiTiet);
            else
                cm.Parameters.AddWithValue("@TestMaChiTiet", DBNull.Value);
            if (_testMaQuocGiaSX != 0)
                cm.Parameters.AddWithValue("@TestMaQuocGiaSX", _testMaQuocGiaSX);
            else
                cm.Parameters.AddWithValue("@TestMaQuocGiaSX", DBNull.Value);
            if (_testMaDVT != 0)
                cm.Parameters.AddWithValue("@TestMaDVT", _testMaDVT);
            else
                cm.Parameters.AddWithValue("@TestMaDVT", DBNull.Value);
            if (_testMaTSCDCaBiet != 0)
                cm.Parameters.AddWithValue("@TestMaTSCDCaBiet", _testMaTSCDCaBiet);
            else
                cm.Parameters.AddWithValue("@TestMaTSCDCaBiet", DBNull.Value);
            if (_namSanXuat != 0)
                cm.Parameters.AddWithValue("@NamSanXuat", _namSanXuat);
            else
                cm.Parameters.AddWithValue("@NamSanXuat", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_model.Length > 0)
                cm.Parameters.AddWithValue("@Model", _model);
            else
                cm.Parameters.AddWithValue("@Model", DBNull.Value);
            if (_serial.Length > 0)
                cm.Parameters.AddWithValue("@Serial", _serial);
            else
                cm.Parameters.AddWithValue("@Serial", DBNull.Value);
            if (_soHieu.Length > 0)
                cm.Parameters.AddWithValue("@SoHieu", _soHieu);
            else
                cm.Parameters.AddWithValue("@SoHieu", DBNull.Value);
            if (_nguyenGiaTinhKhauHao != 0)
                cm.Parameters.AddWithValue("@NguyenGiaTinhKhauHao", _nguyenGiaTinhKhauHao);
            else
                cm.Parameters.AddWithValue("@NguyenGiaTinhKhauHao", DBNull.Value);
            if (_testChoDuyet != false)
                cm.Parameters.AddWithValue("@TestChoDuyet", _testChoDuyet);
            else
                cm.Parameters.AddWithValue("@TestChoDuyet", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_chiPhi != 0)
                cm.Parameters.AddWithValue("@ChiPhi", _chiPhi);
            else
                cm.Parameters.AddWithValue("@ChiPhi", DBNull.Value);
            if (_donGia != 0)
                cm.Parameters.AddWithValue("@DonGia", _donGia);
            else
                cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblChiTietCCDC";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
