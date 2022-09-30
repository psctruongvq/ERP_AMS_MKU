
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiHinhThucNghiChild : Csla.ReadOnlyBase<LoaiHinhThucNghiChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maLoaiHinhThucNghi = 0;
        private string _tenLoaiHinhThucNghi = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaLoaiHinhThucNghi
        {
            get
            {
                CanReadProperty("MaLoaiHinhThucNghi", true);
                return _maLoaiHinhThucNghi;
            }
        }

        public string TenLoaiHinhThucNghi
        {
            get
            {
                CanReadProperty("TenLoaiHinhThucNghi", true);
                return _tenLoaiHinhThucNghi;
            }
        }

        protected override object GetIdValue()
        {
            return _maLoaiHinhThucNghi;
        }

        #endregion //Business Properties and Methods

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in LoaiHinhThucNghiChild
            //AuthorizationRules.AllowRead("MaLoaiHinhThucNghi", "LoaiHinhThucNghiChildReadGroup");
            //AuthorizationRules.AllowRead("TenLoaiHinhThucNghi", "LoaiHinhThucNghiChildReadGroup");

        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static LoaiHinhThucNghiChild GetLoaiHinhThucNghiChild(SafeDataReader dr)
        {
            return new LoaiHinhThucNghiChild(dr);
        }

        private LoaiHinhThucNghiChild(SafeDataReader dr)
        {
            Fetch(dr);
        }
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
            _maLoaiHinhThucNghi = dr.GetInt32("MaLoaiHinhThucNghi");
            _tenLoaiHinhThucNghi = dr.GetString("TenLoaiHinhThucNghi");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
