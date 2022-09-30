
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BoPhanDuyetTangCaChild : Csla.BusinessBase<BoPhanDuyetTangCaChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBoPhan = 0;
        private int _maLoaiTangCa = 0;
        private bool _khongDuyet = false;
        private string _tenLoaiTangCa = "";

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaLoaiTangCa
        {
            get
            {
                return _maLoaiTangCa;
            }
        }

        public bool KhongDuyet
        {
            get
            {
                return _khongDuyet;
            }
            set
            {
                if (!_khongDuyet.Equals(value))
                {
                    _khongDuyet = value;
                    PropertyHasChanged("KhongDuyet");
                }
            }
        }

        public string TenLoaiTangCa
        {
            get
            {
                return _tenLoaiTangCa;
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}", _maBoPhan, _maLoaiTangCa);
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
        internal static BoPhanDuyetTangCaChild NewBoPhanDuyetTangCaChild(int maBoPhan, int maLoaiTangCa)
        {
            return new BoPhanDuyetTangCaChild(maBoPhan, maLoaiTangCa);
        }

        internal static BoPhanDuyetTangCaChild GetBoPhanDuyetTangCaChild(SafeDataReader dr)
        {
            return new BoPhanDuyetTangCaChild(dr);
        }

        private BoPhanDuyetTangCaChild(int maBoPhan, int maLoaiTangCa)
        {
            this._maBoPhan = maBoPhan;
            this._maLoaiTangCa = maLoaiTangCa;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private BoPhanDuyetTangCaChild(SafeDataReader dr)
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
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maLoaiTangCa = dr.GetInt32("MaLoaiTangCa");
            _khongDuyet = dr.GetBoolean("KhongDuyet");
            _tenLoaiTangCa = dr.GetString("TenLoaiTangCa");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_BoPhanDuyetTangCa";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaLoaiTangCa", _maLoaiTangCa);
            cm.Parameters.AddWithValue("@KhongDuyet", _khongDuyet);
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
                cm.CommandText = "spd_Update_BoPhanDuyetTangCa";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaLoaiTangCa", _maLoaiTangCa);
            cm.Parameters.AddWithValue("@KhongDuyet", _khongDuyet);
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
                cm.CommandText = "spd_Delete_BoPhanDuyetTangCa";

                cm.Parameters.AddWithValue("@MaBoPhan", this._maBoPhan);
                cm.Parameters.AddWithValue("@MaLoaiTangCa", this._maLoaiTangCa);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
