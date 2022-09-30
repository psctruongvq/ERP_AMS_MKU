using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class SuaChuaLonList:BusinessListBase<SuaChuaLonList,SuaChuaLon>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public SuaChuaLon GetSuaChuaLon(int maSuaChuaLon)
        {
            foreach (SuaChuaLon scl in this)
                if (scl.MaNghiepVuSuaChuaLon == maSuaChuaLon)
                    return scl;
            return null;
        }

        public void Remove(int maSuaChuaLon)
        {
            foreach (SuaChuaLon item in this)
            {
                if (item.MaNghiepVuSuaChuaLon == maSuaChuaLon)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            SuaChuaLon item = SuaChuaLon.NewSuaChuaLon();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static SuaChuaLonList NewSuaChuaLonList()
        {
          return DataPortal.Create<SuaChuaLonList>();
        }

        public static SuaChuaLonList GetSuaChuaLonList( )
        {
          return DataPortal.Fetch<SuaChuaLonList>(new Criteria());
        }
        public static SuaChuaLonList GetSuaChuaLonTheoChungTu(int maChungTu, int maLoaiChungTu)
        {
            return DataPortal.Fetch<SuaChuaLonList>(new CriteriaSuaChuaLonTheoChungTu(maChungTu,maLoaiChungTu));
        }
       
        private SuaChuaLonList()
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
        private class CriteriaSuaChuaLonTheoChungTu
        {
            public int MaChungTu;
            public int MaLoaiChungTu;
            public CriteriaSuaChuaLonTheoChungTu(int maChungTu, int maLoaiChungTu)
            {
                MaChungTu = maChungTu;
                MaLoaiChungTu = maLoaiChungTu;
            }
        }

        public static SuaChuaLon GetNghiepVuSuaChuaLonTheoChungTu(long maChungTu, int maLoaiChungTu)
        {
            SuaChuaLon suaChuaLon = SuaChuaLon.NewSuaChuaLon();

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_NghiepVuChungTuSuaChuaLon";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    cm.Parameters.AddWithValue("@maLoaiChungTu", maLoaiChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            suaChuaLon = SuaChuaLon.GetSuaChuaLon(dr);
                            // load child objects
                            dr.NextResult();
                        }
                    }
                }
            }
            return suaChuaLon;

        }



        protected override void DataPortal_Fetch(object criteria)
        {
            this.RaiseListChangedEvents = false;
            if (criteria is Criteria)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "select * from view_loadDanhSachTaiSanSuaChuaLon";

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(SuaChuaLon.GetSuaChuaLon(dr));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else if (criteria is CriteriaSuaChuaLonTheoChungTu)
            {
                CriteriaSuaChuaLonTheoChungTu crit = (CriteriaSuaChuaLonTheoChungTu)criteria;
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_NghiepVuChungTu";
                            cm.Parameters.AddWithValue("@MaChungTu", crit.MaChungTu);
                            cm.Parameters.AddWithValue("@maLoaiChungTu",crit.MaLoaiChungTu);
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(SuaChuaLon.GetSuaChuaLon(dr));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            this.RaiseListChangedEvents = true;
        }

        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            // add/update any current child objects
            foreach (SuaChuaLon obj in this)
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

        #endregion
    }
}
