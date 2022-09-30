
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class PhuCapFieldChild : Csla.ReadOnlyBase<PhuCapFieldChild>
    {
        #region Business Properties and Methods

        //declare members
        private string _maField = string.Empty;
        private string _tenField = string.Empty;
        private bool _dieuKien = false;
        private bool _congThuc = false;

        [System.ComponentModel.DataObjectField(true, false)]
        public string MaField
        {
            get
            {
                CanReadProperty("MaField", true);
                return _maField;
            }
        }

        public string TenField
        {
            get
            {
                CanReadProperty("TenField", true);
                return _tenField;

            }
        }

        public bool DieuKien
        {
            get
            {
                CanReadProperty("DieuKien", true);
                return _dieuKien;
            }
        }

        public bool CongThuc
        {
            get
            {
                CanReadProperty("CongThuc", true);
                return _congThuc;
            }
        }

        protected override object GetIdValue()
        {
            return _maField;
        }

        #endregion //Business Properties and Methods

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in PhuCapFieldChild
            //AuthorizationRules.AllowRead("MaField", "PhuCapFieldChildReadGroup");
            //AuthorizationRules.AllowRead("TenField", "PhuCapFieldChildReadGroup");
            //AuthorizationRules.AllowRead("DieuKien", "PhuCapFieldChildReadGroup");
            //AuthorizationRules.AllowRead("CongThuc", "PhuCapFieldChildReadGroup");

        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static PhuCapFieldChild GetPhuCapFieldChild(SafeDataReader dr)
        {
            return new PhuCapFieldChild(dr);
        }

        private PhuCapFieldChild(SafeDataReader dr)
        {
            Fetch(dr);
        }

        public PhuCapFieldChild() { }

        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maField = dr.GetString("MaField");
            _tenField = dr.GetString("TenField");
            _dieuKien = dr.GetBoolean("DieuKien");
            _congThuc = dr.GetBoolean("CongThuc");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
