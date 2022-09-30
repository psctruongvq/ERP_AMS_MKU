
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NhomHangHoaBQ_VTList : Csla.BusinessListBase<NhomHangHoaBQ_VTList, NhomHangHoaBQ_VT>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            NhomHangHoaBQ_VT item = NhomHangHoaBQ_VT.NewNhomHangHoaBQ_VT();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhomHangHoaBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomHangHoaBQ_VTListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhomHangHoaBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomHangHoaBQ_VTListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhomHangHoaBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomHangHoaBQ_VTListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhomHangHoaBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomHangHoaBQ_VTListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhomHangHoaBQ_VTList()
        { /* require use of factory method */ }

        public static NhomHangHoaBQ_VTList NewNhomHangHoaBQ_VTList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomHangHoaBQ_VTList");
            return new NhomHangHoaBQ_VTList();
        }

        public static NhomHangHoaBQ_VTList GetNhomHangHoaBQ_VTList_NhomCap1TheoLoai(int maLoai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomHangHoaBQ_VTList");
            return DataPortal.Fetch<NhomHangHoaBQ_VTList>(new FilterCriteria_NhomCap1TheoLoai(maLoai));
        }
        public static NhomHangHoaBQ_VTList GetNhomHangHoaBQ_VTList_NhomTheoNhomCha(int maNhomCha)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomHangHoaBQ_VTList");
            return DataPortal.Fetch<NhomHangHoaBQ_VTList>(new FilterCriteria_NhomTheoNhomCha(maNhomCha));
        }

        public static NhomHangHoaBQ_VTList GetNhomHangHoaBQ_VTListTheoLoaiVatTu(int maLoaiVatTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomHangHoaBQ_VTList");
            return DataPortal.Fetch<NhomHangHoaBQ_VTList>(new FilterCriteria_NhomTheoLoaiVatTu(maLoaiVatTu));
        }

        public static NhomHangHoaBQ_VTList GetNhomHangHoaBQ_VTListVatTuHangHoa()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomHangHoaBQ_VTList");
            return DataPortal.Fetch<NhomHangHoaBQ_VTList>(new FilterCriteria_NhomVatTuHangHoa());
        }

        public static NhomHangHoaBQ_VTList GetNhomHangHoaBQ_VTList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomHangHoaBQ_VTList");
            return DataPortal.Fetch<NhomHangHoaBQ_VTList>(new FilterCriteria());
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaLoaiVatTuHH;

            public FilterCriteria()
            {
                //this.MaLoaiVatTuHH = maLoaiVatTuHH;
            }          
        }

        [Serializable()]
        private class FilterCriteria_NhomCap1TheoLoai
        {
            public int MaLoai;

            public FilterCriteria_NhomCap1TheoLoai(int maLoai)
            {
                this.MaLoai = maLoai;
            }
        }
        [Serializable()]
        private class FilterCriteria_NhomTheoLoaiVatTu
        {
            public int MaLoaiVatTu;

            public FilterCriteria_NhomTheoLoaiVatTu(int maLoaiVatTu)
            {
                this.MaLoaiVatTu = maLoaiVatTu;
            }
        }

        [Serializable()]
        private class FilterCriteria_NhomTheoNhomCha
        {
            public int MaNhomCha;

            public FilterCriteria_NhomTheoNhomCha(int maNhomCha)
            {
                this.MaNhomCha = maNhomCha;
            }
        }

        [Serializable()]
        private class FilterCriteria_NhomVatTuHangHoa
        {     
            public FilterCriteria_NhomVatTuHangHoa()
            {
                
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
        {
            RaiseListChangedEvents = false;
           
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetch(tr, criteria );

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
          
            RaiseListChangedEvents = true;
        }
     
        private void ExecuteFetch(SqlTransaction tr, Object  criteria)
        {
            int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblNhomHangHoasAll";
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                }
                else if (criteria is FilterCriteria_NhomTheoLoaiVatTu)
                {
                    cm.CommandText = "spd_SelecttblNhomHangHoaListByMaLoaiVatTu";
                    cm.Parameters.AddWithValue("@MaLoaiVatTu", ((FilterCriteria_NhomTheoLoaiVatTu)criteria).MaLoaiVatTu);
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                }
                else if (criteria is FilterCriteria_NhomVatTuHangHoa)
                {
                    cm.CommandText = "spd_SelecttblNhomHangHoaListByVatTuHangHoa";
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                }
                else if (criteria is FilterCriteria_NhomTheoNhomCha)
                {
                    cm.CommandText = "spd_SelecttblNhomHangHoaList_TheoNhomCha";
                    cm.Parameters.AddWithValue("@MaNhomCha", ((FilterCriteria_NhomTheoNhomCha)criteria).MaNhomCha);
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                }
                else if (criteria is FilterCriteria_NhomCap1TheoLoai)
                {
                    cm.CommandText = "spd_SelecttblNhomHangHoaList_Cap1TheoLoai";
                    cm.Parameters.AddWithValue("@MaLoai", ((FilterCriteria_NhomCap1TheoLoai)criteria).MaLoai);
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhomHangHoaBQ_VT.GetNhomHangHoaBQ_VT(dr));
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
                    foreach (NhomHangHoaBQ_VT deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (NhomHangHoaBQ_VT child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr, this);
                        else
                            child.Update(tr, this);
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
