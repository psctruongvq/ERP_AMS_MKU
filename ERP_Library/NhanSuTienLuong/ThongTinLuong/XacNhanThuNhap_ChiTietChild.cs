
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class XacNhanThuNhap_ChiTietChild : Csla.BusinessBase<XacNhanThuNhap_ChiTietChild>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maChiTiet = 0;
        private int _maXacNhan = 0;
        private DateTime _kyLuong = new DateTime(2000, 1, 1);
        private decimal _soTien = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaChiTiet
        {
            get
            {
                return _maChiTiet;
            }
        }

        public int MaXacNhan
        {
            get
            {
                return _maXacNhan;
            }
            set
            {
                if (!_maXacNhan.Equals(value))
                {
                    _maXacNhan = value;
                    PropertyHasChanged();
                }
            }
        }

        public DateTime KyLuong
        {
            get
            {
                return _kyLuong;
            }
            set
            {
                if (!_kyLuong.Equals(value))
                {
                    _kyLuong = value;
                    PropertyHasChanged();
                    CapNhatThuNhap();
                }
            }
        }

        private void CapNhatThuNhap()
        {
            //cập nhật lại số tiền lương từ bảng lương
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "Select dbo.fn_TongThuNhapNhanVien(@MaNhanVien, @KyLuong)";
                cm.Parameters.AddWithValue("@MaNhanVien", ((XacNhanThuNhap_ChiTietList)Parent)._parent.MaNhanVien);
                cm.Parameters.AddWithValue("@KyLuong", _kyLuong);
                try
                {
                    SoTien = Convert.ToDecimal(cm.ExecuteScalar());
                }
                catch
                { }
                cn.Close();
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

        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Factory Methods
        internal static XacNhanThuNhap_ChiTietChild NewXacNhanThuNhap_ChiTietChild()
        {
            return new XacNhanThuNhap_ChiTietChild();
        }

        internal static XacNhanThuNhap_ChiTietChild GetXacNhanThuNhap_ChiTietChild(SafeDataReader dr)
        {
            return new XacNhanThuNhap_ChiTietChild(dr);
        }

        public XacNhanThuNhap_ChiTietChild()
        {
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private XacNhanThuNhap_ChiTietChild(SafeDataReader dr)
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
            _maXacNhan = dr.GetInt32("MaXacNhan");
            _kyLuong = dr.GetDateTime("KyLuong");
            _soTien = dr.GetDecimal("SoTien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, XacNhanThuNhap parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, XacNhanThuNhap parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_XacNhanThuNhap_ChiTietChild";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();
                _maChiTiet = Convert.ToInt32(cm.Parameters["@MaChiTiet"].Value);
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, XacNhanThuNhap parent)
        {
            _maXacNhan = parent.MaXacNhan;
            cm.Parameters.AddWithValue("@MaXacNhan", _maXacNhan);
            cm.Parameters.AddWithValue("@KyLuong", _kyLuong);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, XacNhanThuNhap parent)
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

        private void ExecuteUpdate(SqlTransaction tr, XacNhanThuNhap parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_XacNhanThuNhap_ChiTietChild";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, XacNhanThuNhap parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters.AddWithValue("@MaXacNhan", _maXacNhan);
            cm.Parameters.AddWithValue("@KyLuong", _kyLuong);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
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
                cm.CommandText = "spd_Delete_XacNhanThuNhap_ChiTietChild";

                cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
