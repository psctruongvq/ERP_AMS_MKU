
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
//23_04_2013

namespace ERP_Library
{
    [Serializable()]
    public class PhieuDeNghiXuatDongPhucList : Csla.BusinessListBase<PhieuDeNghiXuatDongPhucList, PhieuDeNghiXuatDongPhuc>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            PhieuDeNghiXuatDongPhuc item = PhieuDeNghiXuatDongPhuc.NewPhieuDeNghiXuatDongPhuc();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhieuNhapXuatList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhieuNhapXuatList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhieuNhapXuatList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhieuNhapXuatList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhieuDeNghiXuatDongPhucList()
        { /* require use of factory method */ }

        public static PhieuDeNghiXuatDongPhucList NewPhieuDeNghiXuatDongPhucList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhieuDeNghiXuatDongPhucList");
            return new PhieuDeNghiXuatDongPhucList();
        }

        public static PhieuDeNghiXuatDongPhucList GetPhieuDeNghiXuatDongPhucList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuDeNghiXuatDongPhucList");
            return DataPortal.Fetch<PhieuDeNghiXuatDongPhucList>(new FilterCriteria());
        }
        public static PhieuDeNghiXuatDongPhucList GetPhieuDeNghiXuatDongPhucList(string doiTuong,int loaiPhieu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuDeNghiXuatDongPhucList");
            return DataPortal.Fetch<PhieuDeNghiXuatDongPhucList>(new FilterCriteriaDoiTuong(doiTuong, loaiPhieu));
        }
        public static PhieuDeNghiXuatDongPhucList GetPhieuXuatDongPhucList_Tim(string _action, int _maKho, long _maDoiTac, long _maNguoiNhapXuat, int _maPhongBan, byte _phuongPhapNX, DateTime _tuNgay, DateTime _denNgay, bool _laNhap, int _loaiPhieu, int _userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuDeNghiXuatDongPhucList");
            return DataPortal.Fetch<PhieuDeNghiXuatDongPhucList>(new FilterCriteriaTim(_action, _maKho, _maDoiTac, _maNguoiNhapXuat, _maPhongBan, _phuongPhapNX, _tuNgay, _denNgay, _laNhap, _loaiPhieu, _userID));
        }
        #endregion factory

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {

            public FilterCriteria()
            {

            }
        }


        private class FilterCriteriaDoiTuong
        {
            public string _doiTuong;
            public int _loaiPhieu;
            public FilterCriteriaDoiTuong(string doiTuong,int loaiPhieu)
            {
                this._doiTuong = doiTuong;
                this._loaiPhieu = loaiPhieu;
            }
        }

        private class FilterCriteriaTim
        {
            public int MaKho = 0;
            public long MaDoiTac = 0;
            public long MaNguoiNhapXuat = 0;
            public int MaPhongBan = 0;
            public byte PhuongPhapNX = 0;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public bool LaNhap = false;
            public int LoaiPhieu = 0;
            public int UserID = 0;
            public string action = "";
            public FilterCriteriaTim(string _action, int _maKho, long _maDoiTac, long _maNguoiNhapXuat, int _maPhongBan, byte _phuongPhapNX, DateTime _tuNgay, DateTime _denNgay, bool _laNhap, int _loaiPhieu, int _userID)
            {
                action = _action;
                MaKho = _maKho;
                MaDoiTac = _maDoiTac;
                MaNguoiNhapXuat = _maNguoiNhapXuat;
                MaPhongBan = _maPhongBan;
                PhuongPhapNX = _phuongPhapNX;
                TuNgay = _tuNgay;
                DenNgay = _denNgay;
                LaNhap = _laNhap;
                LoaiPhieu = _loaiPhieu;
                UserID = _userID;
            }

        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, Object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                if (criteria is FilterCriteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "GetPhieuDeNghiXuatDongPhucList";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuDeNghiXuatDongPhuc.GetPhieuDeNghiXuatDongPhuc(dr));
                    }
                }

                else if (criteria is FilterCriteriaTim)
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimPhieuDeNghiXuatDongPhuc";//Xuat Phieu Xuat Vat Tu

                    cm.Parameters.AddWithValue("@MaKho", ((FilterCriteriaTim)criteria).MaKho);
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaTim)criteria).MaDoiTac);
                    cm.Parameters.AddWithValue("@LaNhap", ((FilterCriteriaTim)criteria).LaNhap);
                    cm.Parameters.AddWithValue("@LoaiPhieu", ((FilterCriteriaTim)criteria).LoaiPhieu);
                    cm.Parameters.AddWithValue("@MaNguoiNhapXuat", ((FilterCriteriaTim)criteria).MaNguoiNhapXuat);
                    cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaTim)criteria).MaPhongBan);
                    cm.Parameters.AddWithValue("@PhuongPhapNX", ((FilterCriteriaTim)criteria).PhuongPhapNX);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaTim)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaTim)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaTim)criteria).UserID);
                    cm.Parameters.AddWithValue("@action", ((FilterCriteriaTim)criteria).action);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuDeNghiXuatDongPhuc.GetPhieuDeNghiXuatDongPhucCoDoiTuong(dr));
                    }
                    
                }

                else if (criteria is FilterCriteriaDoiTuong)
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetPhieuDeNghiXuatDongPhuc_TenDoiTuong";//Xuat Phieu Xuat Vat Tu

                    cm.Parameters.AddWithValue("@TenDoiTuong", ((FilterCriteriaDoiTuong)criteria)._doiTuong);
                    cm.Parameters.AddWithValue("@LoaiPhieu", ((FilterCriteriaDoiTuong)criteria)._loaiPhieu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuDeNghiXuatDongPhuc.GetPhieuDeNghiXuatDongPhucCoDoiTuong(dr));
                    }

                }


                
            }//using
        }
        #endregion //Data Access - Fetch

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (PhieuDeNghiXuatDongPhuc deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (PhieuDeNghiXuatDongPhuc child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
