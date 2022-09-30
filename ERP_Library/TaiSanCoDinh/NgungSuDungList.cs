using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class NgungSuDungList:BusinessListBase<NgungSuDungList,NgungSuDung>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public NgungSuDung GetNgungSuDung(int MaNgungSuDung)
        {
            foreach (NgungSuDung nsd in this)
                if (nsd.MaNghiepVuNgungSuDungTSCD == MaNgungSuDung)
                    return nsd;
            return null;
        }

        public void Remove(int maNgungSuDung)
        {
            foreach (NgungSuDung item in this)
            {
                if (item.MaNghiepVuNgungSuDungTSCD == maNgungSuDung)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            NgungSuDung item = NgungSuDung.NewNgungSuDung();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static NgungSuDungList NewNgungSuDungList()
        {
          //return DataPortal.Create<NgungSuDungList>();
            return new NgungSuDungList();
        }

        public static NgungSuDungList GetNgungSuDungList( )
        {
          return DataPortal.Fetch<NgungSuDungList>(new Criteria());
        }

        public static NgungSuDungList GetNgungSuDungList(DateTime TuNgay, DateTime DenNgay )
        {
            return DataPortal.Fetch<NgungSuDungList>(new CriteriaByNgay(TuNgay, DenNgay));
        }
               
        private NgungSuDungList()
        {
            this.AllowNew = true;            
        }

        #endregion

        #region Data Access

        [Serializable()]
        private class Criteria
        {
            //hong làm gì hêt
        }

        [Serializable()]
        private class CriteriaByNgay
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public CriteriaByNgay(DateTime tuNgay, DateTime denNgay )
            {
                TuNgay = tuNgay;
                DenNgay = denNgay;
            }
        }

        protected override void DataPortal_Fetch(object criteria)
        {
            this.RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    if (criteria is Criteria)
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select * from view_loadDanhSachTaiSanNgungSuDung";
                    }
                    else if (criteria is CriteriaByNgay)
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_NghiepVuNgungSuDungByNgay";
                        cm.Parameters.AddWithValue("@TuNgay", ((CriteriaByNgay)criteria).TuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", ((CriteriaByNgay)criteria).DenNgay);
                    }
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(NgungSuDung.GetNgungSuDung(dr));
                        }
                    }
                }
            }
            this.RaiseListChangedEvents = true;
        }

        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    foreach (NgungSuDung deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // add/update any current child objects
                    foreach (NgungSuDung obj in this)
                    {

                        if (obj.IsNew)
                            obj.Insert(tr);
                        else
                            obj.Update(tr);
                    }
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
            }
            this.RaiseListChangedEvents = true;
        }

        #endregion
    }
}
