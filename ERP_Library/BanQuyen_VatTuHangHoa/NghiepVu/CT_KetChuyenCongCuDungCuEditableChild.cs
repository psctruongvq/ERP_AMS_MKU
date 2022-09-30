
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CT_KetChuyenCongCuDungCu : Csla.BusinessBase<CT_KetChuyenCongCuDungCu>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTietKetChuyen = 0;
        private int _maKetChuyen = 0;
        private int _maHangHoa = 0;
        private int _soLuong = 0;
        private decimal _thanhTien = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTietKetChuyen
        {
            get
            {
                CanReadProperty("MaChiTietKetChuyen", true);
                return _maChiTietKetChuyen;
            }
        }

        public int MaKetChuyen
        {
            get
            {
                CanReadProperty("MaKetChuyen", true);
                return _maKetChuyen;
            }
            set
            {
                CanWriteProperty("MaKetChuyen", true);
                if (!_maKetChuyen.Equals(value))
                {
                    _maKetChuyen = value;
                    PropertyHasChanged("MaKetChuyen");
                }
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
                    PropertyHasChanged("SoLuong");
                }
            }
        }

        public decimal ThanhTien
        {
            get
            {
                CanReadProperty("ThanhTien", true);
                return _thanhTien;
            }
            set
            {
                CanWriteProperty("ThanhTien", true);
                if (!_thanhTien.Equals(value))
                {
                    _thanhTien = value;
                    PropertyHasChanged("ThanhTien");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTietKetChuyen;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {

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
            //TODO: Define authorization rules in CT_KetChuyenCongCuDungCu
            //AuthorizationRules.AllowRead("MaChiTietKetChuyen", "CT_KetChuyenCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaKetChuyen", "CT_KetChuyenCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaHangHoa", "CT_KetChuyenCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("SoLuong", "CT_KetChuyenCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("ThanhTien", "CT_KetChuyenCongCuDungCuReadGroup");

            //AuthorizationRules.AllowWrite("MaKetChuyen", "CT_KetChuyenCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaHangHoa", "CT_KetChuyenCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuong", "CT_KetChuyenCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhTien", "CT_KetChuyenCongCuDungCuWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static CT_KetChuyenCongCuDungCu NewCT_KetChuyenCongCuDungCu()
        {
            return new CT_KetChuyenCongCuDungCu();
        }

        internal static CT_KetChuyenCongCuDungCu GetCT_KetChuyenCongCuDungCu(SafeDataReader dr)
        {
            return new CT_KetChuyenCongCuDungCu(dr);
        }

        private CT_KetChuyenCongCuDungCu()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_KetChuyenCongCuDungCu(SafeDataReader dr)
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
            _maChiTietKetChuyen = dr.GetInt64("MaChiTietKetChuyen");
            _maKetChuyen = dr.GetInt32("MaKetChuyen");
            _maHangHoa = dr.GetInt32("MaHangHoa");
            _soLuong = dr.GetInt32("SoLuong");
            _thanhTien = dr.GetDecimal("ThanhTien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, KyKetChuyenCongCuDungCu parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, KyKetChuyenCongCuDungCu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_KetChuyenCongCuDungCu";//\\

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTietKetChuyen = (long)cm.Parameters["@MaChiTietKetChuyen"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, KyKetChuyenCongCuDungCu parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maKetChuyen = parent.MaKetChuyen;
            if (_maKetChuyen != 0)
                cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
            else
                cm.Parameters.AddWithValue("@MaKetChuyen", DBNull.Value);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_thanhTien != 0)
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            else
                cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTietKetChuyen", _maChiTietKetChuyen);
            cm.Parameters["@MaChiTietKetChuyen"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, KyKetChuyenCongCuDungCu parent)
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

        private void ExecuteUpdate(SqlTransaction tr, KyKetChuyenCongCuDungCu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_KetChuyenCongCuDungCu";//\\

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, KyKetChuyenCongCuDungCu parent)
        {
            cm.Parameters.AddWithValue("@MaChiTietKetChuyen", _maChiTietKetChuyen);
            if (_maKetChuyen != 0)
                cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
            else
                cm.Parameters.AddWithValue("@MaKetChuyen", DBNull.Value);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_thanhTien != 0)
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            else
                cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_KetChuyenCongCuDungCu";//\\

                cm.Parameters.AddWithValue("@MaChiTietKetChuyen", this._maChiTietKetChuyen);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
