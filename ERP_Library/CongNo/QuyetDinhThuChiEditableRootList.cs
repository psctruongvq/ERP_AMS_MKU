
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class QuyetDinhThuChiList : Csla.BusinessListBase<QuyetDinhThuChiList, QuyetDinhThuChi>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            QuyetDinhThuChi item = QuyetDinhThuChi.NewQuyetDinhThuChi();
            this.Add(item);
            return item;
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in QuyetDinhThuChiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhThuChiListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in QuyetDinhThuChiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhThuChiListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in QuyetDinhThuChiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhThuChiListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in QuyetDinhThuChiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhThuChiListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private QuyetDinhThuChiList()
        { /* require use of factory method */ }

        public static QuyetDinhThuChiList NewQuyetDinhThuChiList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuyetDinhThuChiList");
            return new QuyetDinhThuChiList();
        }

        public static QuyetDinhThuChiList GetQuyetDinhThuChiList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyetDinhThuChiList");
            return DataPortal.Fetch<QuyetDinhThuChiList>(new FilterCriteria());
        }

        public static QuyetDinhThuChiList GetQuyetDinhThuChiList(int LoaiQuyetDinh, int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyetDinhThuChiList");
            return DataPortal.Fetch<QuyetDinhThuChiList>(new FilterCriteria_ThuChi(LoaiQuyetDinh, Loai));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {

            public FilterCriteria()
            {

            }
        }

        private class FilterCriteria_ThuChi
        {
            public int LoaiQuyetDinh;
            public int Loai;
            public FilterCriteria_ThuChi(int loaiQuyetDinh, int loai)
            {
                this.LoaiQuyetDinh = loaiQuyetDinh;
                this.Loai = loai;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblcnQuyetDinhesAll";


                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(QuyetDinhThuChi.GetQuyetDinhThuChi(dr));
                    }
                }//using
            }
            else if(criteria is FilterCriteria_ThuChi)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblcnQuyetDinhesAll_ThuChi";
                    cm.Parameters.AddWithValue("@LoaiQuyetDinh", ((FilterCriteria_ThuChi)criteria).LoaiQuyetDinh);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria_ThuChi)criteria).Loai);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(QuyetDinhThuChi.GetQuyetDinhThuChi(dr));
                    }
                }//using
            }
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                // loop through each deleted child object
                foreach (QuyetDinhThuChi deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (QuyetDinhThuChi child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn);
                    else
                        child.Update(cn);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }

        public void DataPortal_Update(SqlTransaction tr, long MaChungTu)
        {
            RaiseListChangedEvents = false;

            try
            {
                // loop through each deleted child object
                foreach (QuyetDinhThuChi deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (QuyetDinhThuChi child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, MaChungTu);
                    else
                        child.Update(tr, MaChungTu);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
