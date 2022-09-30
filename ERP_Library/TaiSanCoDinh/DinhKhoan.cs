using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

//123 456
namespace ERP_Library
{
    public class DinhKhoan : BusinessBase<DinhKhoan>
    {

        private bool _idSet;

        #region contrustor
        private DinhKhoan()
        {
            _MaDinhKhoan = 0;
            _GhiMucNganSach = false;

            //MarkAsChild();
        }
        #endregion

        protected override object GetIdValue()
        {
            return _MaDinhKhoan;
        }

        #region Khai báo biến
        int _MaDinhKhoan;
        public int MaDinhKhoan
        {
            get
            {
                CanReadProperty(true);
                //if (!_idSet)
                //{
                //    _idSet = true;
                  
                //}
                return _MaDinhKhoan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaDinhKhoan.Equals(value))
                {
                    _idSet = true;
                    _MaDinhKhoan = value;
                    PropertyHasChanged();
                }
            }
        }

        Boolean _GhiMucNganSach;
        public Boolean GhiMucNganSach
        {
            get
            {
                CanReadProperty(true);
                return _GhiMucNganSach;
            }
            set
            {
                CanWriteProperty(true);
                if (!_GhiMucNganSach.Equals(value))
                {
                    _GhiMucNganSach = value;
                    PropertyHasChanged();
                }
            }
        }

        ButToanList _ButToan = ButToanList.NewButToanList();
        public ButToanList ButToan
        {
            get
            {
                CanReadProperty(true);
                return _ButToan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ButToan.Equals(value))
                {
                    _ButToan = value;
                    PropertyHasChanged();
                }
            }
        }

        Boolean _LaMotNoNhieuCo = false;
        public Boolean LaMotNoNhieuCo
        {
            get
            {
                CanReadProperty(true);
                return _LaMotNoNhieuCo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_LaMotNoNhieuCo.Equals(value))
                {
                    _LaMotNoNhieuCo = value;
                    PropertyHasChanged();
                }
            }
        }
        Boolean _NoCo = false;
        public Boolean NoCo
        {
            get
            {
                CanReadProperty(true);
                return _NoCo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NoCo.Equals(value))
                {
                    _NoCo = value;
                    PropertyHasChanged();
                }
            }
        }
        #endregion

        #region Static Methods

        public void Save(SqlTransaction tr)
        {
            //this.RaiseListChangedEvents = false;
            //// update (thus deleting) any deleted child objects
            //foreach (DinhKhoan obj in DeletedList)
            //    obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            //DeletedList.Clear();
            // add/update any current child objects
            if (this.IsDirty)
            {
                if (this.IsNew)
                    this.Insert(tr);
                else
                    this.Update(tr);
            }

        }

        public override DinhKhoan Save()
        {
            return base.Save();
        }


        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaDinhKhoan));
        }

        public void Insert()
        {
            DataPortal_Insert();
        }
        public void Update(SqlTransaction tr)
        {
            DataPortal_Update(tr);
        }


        /// <summary>
        /// Constructor này dùng cho PhongBanList Load từng Phòng Ban lên
        /// </summary>
        /// <param name="dr">là SafeDataReader của PhongBanList Fetch ra</param>
        private DinhKhoan(SafeDataReader dr)
        {
            //MarkAsChild();           
            _MaDinhKhoan = dr.GetInt32("MaDinhKhoan");
            _GhiMucNganSach = dr.GetBoolean("GhiMucNganSach");
            _LaMotNoNhieuCo = dr.GetBoolean("LaMotNoNhieuCo");
            _NoCo = dr.GetBoolean("NoCo");
            _idSet = true; //Do tự set value cho ID
            MarkOld();
        }

        public static DinhKhoan NewDinhKhoan()
        {
            return new DinhKhoan();
        }

        public static DinhKhoan NewDinhKhoan(Boolean ghiMucNganSach)
        {
            DinhKhoan dinhKhoan = new DinhKhoan();
            dinhKhoan._GhiMucNganSach = ghiMucNganSach;
            return dinhKhoan;
        }

        public static DinhKhoan GetDinhKhoan(int maDinhKhoan)
        {
            return (DinhKhoan)DataPortal.Fetch<DinhKhoan>(new Criteria(maDinhKhoan));
        }

        public static DinhKhoan GetDinhKhoan_New(int maDinhKhoan)
        {
            return (DinhKhoan)DataPortal.Fetch<DinhKhoan>(new Criteria_New(maDinhKhoan));
        }

        public static DinhKhoan GetDinhKhoanByLoc(int maDinhKhoan)
        {
            return (DinhKhoan)DataPortal.Fetch<DinhKhoan>(new CriteriaByLoc(maDinhKhoan));
        }

        internal static DinhKhoan GetDinhKhoan(SafeDataReader dr)
        {
            return new DinhKhoan(dr);
        }

        public static void DeleteDinhKhoan(int maDinhKhoan)
        {
            DataPortal.Delete(new Criteria(maDinhKhoan));
        }


        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaDinhKhoan;

            public Criteria(int maDinhKhoan)
            {
                MaDinhKhoan = maDinhKhoan;
            }
        }

        private class Criteria_New
        {
            // Add criteria here
            public int MaDinhKhoan;

            public Criteria_New(int maDinhKhoan)
            {
                MaDinhKhoan = maDinhKhoan;
            }
        }

        private class CriteriaByLoc
        {
            // Add criteria here
            public int MaDinhKhoan;

            public CriteriaByLoc(int maDinhKhoan)
            {
                MaDinhKhoan = maDinhKhoan;
            }
        }

        #endregion

        #region Override
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _ButToan.IsDirty;
            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid && _ButToan.IsValid;
            }
        }
        #endregion

        #region Data Access
        protected override void DataPortal_Create()
        {
            base.DataPortal_Create();
        }

        //protected override void DataPortal_Create(object criteria)
        //{
        //    Criteria crit = (Criteria)criteria;

        //    // Load default values from database
        //}



        protected override void DataPortal_Fetch(object criteria)
        {
            
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    if (criteria is Criteria)
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadMaCaBiet_DinhKhoan";
                        cm.Parameters.AddWithValue("@MaDinhKhoan", ((Criteria)criteria).MaDinhKhoan);
                        //đọc định khoản
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaDinhKhoan = dr.GetInt32("MaDinhKhoan");
                                _GhiMucNganSach = dr.GetBoolean("GhiMucNganSach");
                                _LaMotNoNhieuCo = dr.GetBoolean("LaMotNoNhieuCo");
                                _NoCo = dr.GetBoolean("NoCo");
                                _idSet = true;
                                FetchChildren();
                                // load child objects
                                //    dr.NextResult();
                            }
                            MarkOld();
                        }
                    }
                    else if (criteria is Criteria_New)
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadMaCaBiet_DinhKhoan";
                        cm.Parameters.AddWithValue("@MaDinhKhoan", ((Criteria_New)criteria).MaDinhKhoan);
                        //đọc định khoản
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaDinhKhoan = dr.GetInt32("MaDinhKhoan");
                                _GhiMucNganSach = dr.GetBoolean("GhiMucNganSach");
                                _LaMotNoNhieuCo = dr.GetBoolean("LaMotNoNhieuCo");
                                _NoCo = dr.GetBoolean("NoCo");
                                _idSet = true;
                                FetchChildren(1);
                                // load child objects
                                //    dr.NextResult();
                            }
                            MarkOld();
                        }
                    }
                    else if (criteria is CriteriaByLoc)
                    {

                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadMaCaBiet_DinhKhoan";
                        cm.Parameters.AddWithValue("@MaDinhKhoan", ((CriteriaByLoc)criteria).MaDinhKhoan);
                        //đọc định khoản
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaDinhKhoan = dr.GetInt32("MaDinhKhoan");
                                _GhiMucNganSach = dr.GetBoolean("GhiMucNganSach");
                                _LaMotNoNhieuCo = dr.GetBoolean("LaMotNoNhieuCo");
                                _NoCo = dr.GetBoolean("NoCo");
                                _idSet = true;
                                FetchChildrenByLoc();
                                // load child objects
                                //    dr.NextResult();
                            }
                            MarkOld();

                        }
                    }
                    // đọc nhựng bút toán thuộc mã định khoản
                    //try
                    //{
                    //    using (SqlCommand command = cn.CreateCommand())
                    //    {
                    //        command.CommandType = CommandType.StoredProcedure;
                    //        command.CommandText = "spd_LoadList_ButToan_ByMaDinhKhoan";
                    //        command.Parameters.AddWithValue("@MaDinhKhoan", _MaDinhKhoan);

                    //        using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
                    //        {
                    //            _ButToan = ButToanList.GetButToanList(dr);
                    //            _ButToan._MaDinhKhoan = _MaDinhKhoan;
                    //        }
                    //    }
                    //}
                    //catch (Exception ee)
                    //{
                    //    string temp = ee.Message;
                    //}
                }
                MarkOld();

            }
        }
     

        public void Insert(SqlTransaction tr)
        {
            DataPortal_Insert(tr);
        }

        protected void DataPortal_Insert(SqlTransaction tr)
        {
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Insert_DinhKhoan";
                    cm.Parameters.AddWithValue("@MaDinhKhoan", _MaDinhKhoan).Direction = ParameterDirection.Output;
                    cm.Parameters.AddWithValue("@GhiMucNganSach", _GhiMucNganSach);
                    cm.Parameters.AddWithValue("@LaMotNoNhieuCo", _LaMotNoNhieuCo);
                    cm.Parameters.AddWithValue("@NoCo", _NoCo);
                    cm.ExecuteNonQuery();
                    _idSet = true;
                    _MaDinhKhoan = (int)cm.Parameters["@MaDinhKhoan"].Value;
                }
                //Update ButToanList
                _ButToan._MaDinhKhoan = _MaDinhKhoan;
                //_ButToan.Save();
                _ButToan.DataPortal_Update(tr);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void DataPortal_Update(SqlTransaction tr)
        {

            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_DinhKhoan";
                cm.Parameters.AddWithValue("@MaDinhKhoan", _MaDinhKhoan);
                cm.Parameters.AddWithValue("@GhiMucNgansach", _GhiMucNganSach);
                cm.Parameters.AddWithValue("@LaMotNoNhieuCo", _LaMotNoNhieuCo);
                cm.Parameters.AddWithValue("@NoCo", _NoCo);
                cm.ExecuteNonQuery();
                _MaDinhKhoan = (int)cm.Parameters["@MaDinhKhoan"].Value;
                _ButToan._MaDinhKhoan = _MaDinhKhoan;
                _ButToan.DataPortal_Update(tr);
                //_ButToan.Save();
                MarkOld();
            }

        }


        protected override void DataPortal_Delete(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Delete_DinhKhoan";
                    cm.Parameters.AddWithValue("@MaDinhKhoan", crit.MaDinhKhoan);
                    cm.ExecuteNonQuery();
                }
            }
        }
//
        public void DataPortal_Delete(SqlTransaction tr)
        {
            
            // delete buttoan
            _ButToan.Dataportal_Delete(tr);
           //
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Delete_DinhKhoan";
                cm.Parameters.AddWithValue("@MaDinhKhoan", _MaDinhKhoan);
                cm.ExecuteNonQuery();
            }//using
        }


        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaDinhKhoan));
        }
        private void FetchChildren()
        {

            _ButToan = ButToanList.GetButToanList_DinhKhoan(_MaDinhKhoan);
            
        }

        private void FetchChildren(int loai)
        {
            _ButToan = ButToanList.GetButToanList_DinhKhoan_New(_MaDinhKhoan, _GhiMucNganSach);
        }

        private void FetchChildrenByLoc()
        {

            _ButToan = ButToanList.GetButToanList_DinhKhoanByLoc(_MaDinhKhoan);

        }



        #endregion

    }
}
