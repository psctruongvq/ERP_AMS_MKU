using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public  class DieuChuyenNoiBoList:BusinessListBase<DieuChuyenNoiBoList,DieuChuyenNoiBo> 
    {
        #region Business Methods

        // TODO: add public properties and methods

        public DieuChuyenNoiBo GetDieuChuyenNoiBo(int maDieuChuyenNoiBo)
        {
            foreach (DieuChuyenNoiBo dgl in this)
                if (dgl.MaNghiepVuDieuChuyen == maDieuChuyenNoiBo)
                    return dgl;
            return null;
        }

        public void Remove(int maDieuChuyenNoiBo)
        {
            foreach (DieuChuyenNoiBo item in this)
            {
                if (item.MaNghiepVuDieuChuyen == maDieuChuyenNoiBo)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            DieuChuyenNoiBo item = DieuChuyenNoiBo.NewDieuChuyenNoiBo();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static DieuChuyenNoiBoList NewDieuChuyenNoiBoList()
        {
          return DataPortal.Create<DieuChuyenNoiBoList>();
        }

        public static DieuChuyenNoiBoList GetDieuChuyenNoiBoList( )
        {
          return DataPortal.Fetch<DieuChuyenNoiBoList>(new Criteria());
        }
        public static DieuChuyenNoiBoList GetDieuChuyenNoiBoList(DateTime tuNgay, DateTime denNgay)
        {
            return DataPortal.Fetch<DieuChuyenNoiBoList>(new CriteriaByNgayLap(tuNgay, denNgay));
        }

        private DieuChuyenNoiBoList()
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

        private class CriteriaByNgayLap
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public CriteriaByNgayLap(DateTime _tuNgay, DateTime _denNgay)
            {
                TuNgay = _tuNgay;
                DenNgay = _denNgay;
            }
        }

        private void DataPortal_Create(Criteria criteria)
        {
            // TODO: load default values into object
        }

        protected override void DataPortal_Fetch(Object criteria)
        {
            this.RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    if (criteria is Criteria)
                    {
                        cm.CommandText = "spd_LoadAllDieuChuyenNoiBo";
                    }
                    else if (criteria is CriteriaByNgayLap)
                    {
                        cm.CommandText = "spd_SelectDieuChuyenNoiBoByNgayLap";
                        cm.Parameters.AddWithValue("@TuNgay", ((CriteriaByNgayLap)criteria).TuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", ((CriteriaByNgayLap)criteria).DenNgay);                  
                    }

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(DieuChuyenNoiBo.GetDieuChuyenNoiBo(dr));
                        }
                    }
                }

            }
            this.RaiseListChangedEvents = true;
        }


        protected override void DataPortal_Update()
        {


            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (DieuChuyenNoiBo obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();



            // add/update any current child objects
            foreach (DieuChuyenNoiBo obj in this)
            {
                if (obj.IsDirty)
                {
                    if (obj.IsNew)
                        obj.Insert();
                    else
                        obj.Update();
                }
            }
            this.RaiseListChangedEvents = true;
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            // TODO: delete object's data
        }

        #endregion


    }
}
