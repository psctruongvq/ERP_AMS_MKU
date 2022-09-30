using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;  

namespace ERP_Library
{
    public class LoaiTaiSanList:BusinessListBase<LoaiTaiSanList,LoaiTaiSan>
    {

        #region Business Methods

        // TODO: add public properties and methods

        public LoaiTaiSan GetLoaiTaiSan(int MaLoaiTaiSan)
        {
            foreach (LoaiTaiSan lts in this)
                if (lts.MaLoaiTaiSan == MaLoaiTaiSan)
                    return lts;
            return null;
        }

        public void Remove(int maLoaiTaiSan)
        {
            foreach (LoaiTaiSan item in this)
            {
                if (item.MaLoaiTaiSan == maLoaiTaiSan)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            LoaiTaiSan item = LoaiTaiSan.NewLoaiTaiSan();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static LoaiTaiSanList NewLoaiTaiSanList()
        {
          return DataPortal.Create<LoaiTaiSanList>();
        }

        public static LoaiTaiSanList GetLoaiTaiSanList( )
        {
          return DataPortal.Fetch<LoaiTaiSanList>(new Criteria());
        }

        public static LoaiTaiSanList GetLoaiTaiSanTheoNhom(int MaNhomTaiSan)
        {
            return DataPortal.Fetch<LoaiTaiSanList>(new CriteriaByNhomTaiSan(MaNhomTaiSan));
        }
               
        private LoaiTaiSanList()
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

        private class CriteriaByNhomTaiSan
        {
            private int _MaNhomTaiSan;
            public int MaNhomTaiSan
            {
                get { return _MaNhomTaiSan; }  
              
            }

            public CriteriaByNhomTaiSan(int MaNhomTaiSan)
            {
                _MaNhomTaiSan= MaNhomTaiSan;
            }
        }

        private class CriteriaComb
        {
            private int _MaNhomTaiSan;
            private int _MaLoaiTaiSan;
            public int MaNhomTaiSan
            {
                get { return _MaNhomTaiSan; }
            }
            public int MaLoaiTaiSan
            {
                get { return _MaLoaiTaiSan; }
            }
            public CriteriaComb(int MaNhomTaiSan, int MaLoaiTaiSan)
            {
                _MaNhomTaiSan = MaNhomTaiSan;
                _MaLoaiTaiSan = MaLoaiTaiSan;
            }
        }

        public int LayMaLoaiTaiSanCon(int maNhomTaiSan, int maLoaiTSHTai)
        {
            int maLoaiTSCha = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "SELECT MaLoaiTaiSan FROM tblLoaiTaiSan WHERE MaNhomTaiSan='" + maNhomTaiSan + "' and MaLoaiTaiSanCha ='" + maLoaiTSHTai+"'";
                        if (cm.ExecuteScalar() != null)
                            maLoaiTSCha = (int)cm.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return maLoaiTSCha;
        }

        public static LoaiTaiSanList DSLoaiTaiSanCon(int maNhomTaiSan, int maLoaiTSHTai)
        {
            return DataPortal.Fetch<LoaiTaiSanList>(new CriteriaComb(maNhomTaiSan, maLoaiTSHTai));
        }

        protected override void DataPortal_Fetch(object criteria)
        {
            this.RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        if (criteria is Criteria)
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_LoaiTaiSanAll";
                        }
                        else if (criteria is CriteriaByNhomTaiSan)
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_LayLoaiTaiSan_TheoNhom ";
                            cm.Parameters.AddWithValue("@MaNhomTaiSan", ((CriteriaByNhomTaiSan)criteria).MaNhomTaiSan);
                        }
                        else if (criteria is CriteriaComb)
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_LayLoaiTaiSan_LoaiCha";
                            cm.Parameters.AddWithValue("@MaNhomTaiSan", ((CriteriaComb)criteria).MaNhomTaiSan);
                            cm.Parameters.AddWithValue("@MaLoaiTaiSan", ((CriteriaComb)criteria).MaLoaiTaiSan);
                        }
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(LoaiTaiSan.GetLoaiTaiSan(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.RaiseListChangedEvents = true;
        }


        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (LoaiTaiSan obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (LoaiTaiSan obj in this)
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
