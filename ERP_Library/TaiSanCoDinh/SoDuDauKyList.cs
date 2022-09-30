using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class SoDuDauKyList:BusinessListBase<SoDuDauKyList,SoDuDauKy>
    {
        #region Business Methods

        // TODO: add public properties and methods
        //
        public SoDuDauKy GetSoDuDauKy(int maSoDuDauKy)
        {
            foreach (SoDuDauKy sddk in this)
                if (sddk.MaSoDuDauKy == maSoDuDauKy)
                    return sddk;
            return null;
        }

        public void Remove(int maSoDuDauKy)
        {
            foreach (SoDuDauKy item in this)
            {
                if (item.MaSoDuDauKy == maSoDuDauKy)
                {
                    Remove(item);
                    break;
                }
            }
        }

        //protected override object AddNewCore()
        //{
        //    SoDuDauKy item = SoDuDauKy.NewSoDuDauKy();
        //    Add(item);
        //    return item;
        //}
        #endregion    

        #region Factory Methods

        public static SoDuDauKyList NewSoDuDauKyList()
        {
          //return DataPortal.Create<SoDuDauKyList>();
            return new SoDuDauKyList();
        }

        //public static SoDuDauKyList NewSoDuDauKyList1()
        //{
        //    return new SoDuDauKyList();
        //}

        public static SoDuDauKyList GetSoDuDauKyList( )
        {
          return DataPortal.Fetch<SoDuDauKyList>(new Criteria());
        }

        public static SoDuDauKyList GetSoDuDauKyListByMaKy(int maKy, int maBoPhan)
        {
            return DataPortal.Fetch<SoDuDauKyList>(new CriteriaSoDuDauKyByMaKy(maKy, maBoPhan));
        }

        public static SoDuDauKyList InSertGetSoDuDauKy(int maKy, int maBoPhan)
        {
            return DataPortal.Fetch<SoDuDauKyList>(new CriteriaInsertSoDuDauKy(maKy, maBoPhan));
        }
        public static SoDuDauKyList InSertGetSoDuTaiKhoanDoiTuongDauKy(int maKy, int maBoPhan)
        {
            return DataPortal.Fetch<SoDuDauKyList>(new CriteriaInsertSoDuDauKyTaiKhoanDoiTuong(maKy, maBoPhan));
        }
               
        //private SoDuDauKyList()
        //{
        //    this.AllowNew = true;            
        //}

        #endregion

        #region Data Access

        [Serializable()]
        private class Criteria
        {
            //hong làm gì hêt
        }

        [Serializable()]
        private class CriteriaByMaKy
        {
            int MaKy;
            public CriteriaByMaKy(int maKy)
            {
                MaKy = maKy;
            }
            
        }

        [Serializable()]
        private class CriteriaSoDuDauKyByMaKy
        {
            public int MaKy;
            public int MaBoPhan;
            public CriteriaSoDuDauKyByMaKy(int maKy, int maBoPhan)
            {
                MaKy = maKy;
                MaBoPhan = maBoPhan;
            }

        }
        [Serializable()]
        private class CriteriaInsertSoDuDauKy
        {
            public int MaKy;
            public int MaBoPhan;
            public CriteriaInsertSoDuDauKy(int maKy, int maBoPhan)
            {
                MaKy = maKy;
                MaBoPhan = maBoPhan;
            }

        }

        [Serializable()]
        private class CriteriaInsertSoDuDauKyTaiKhoanDoiTuong
        {
            public int MaKy;
            public int MaBoPhan;
            public CriteriaInsertSoDuDauKyTaiKhoanDoiTuong(int maKy, int maBoPhan)
            {
                MaKy = maKy;
                MaBoPhan = maBoPhan;
            }

        }

        public void InserTaiKhoan(int maKy)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadSoHieuTaiKhoanTheoKy";
                        cm.Parameters.AddWithValue("@MaKy",maKy);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(SoDuDauKy.GetSoDuDauKy(dr,true));
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

        public static SoDuDauKyList GetMaKy()
        {            
            SoDuDauKyList _SoDuDauKyList=new SoDuDauKyList();
            try
            {                
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select distinct * from tblsodudauky";
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _SoDuDauKyList.Add(SoDuDauKy.GetSoDuDauKy(dr,true));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _SoDuDauKyList;
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
                            cm.CommandText = "select *from tblSoDuDauKy";
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(SoDuDauKy.GetSoDuDauKy(dr,true));
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
            else if (criteria is CriteriaSoDuDauKyByMaKy)
            {
               
                CriteriaSoDuDauKyByMaKy crit = (CriteriaSoDuDauKyByMaKy)criteria;
                int count;
                count = SoDuDauKy.KiemTraKyKetChuyen(crit.MaKy, crit.MaBoPhan);
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_LaySoDuDauTaiKhoan";
                            cm.Parameters.AddWithValue("@MaKy", crit.MaKy);
                            cm.Parameters.AddWithValue("@MaBoPhan", crit.MaBoPhan);
                            if (count > 0)
                            {
                                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                                {
                                    while (dr.Read())
                                    {
                                        this.Add(SoDuDauKy.GetSoDuDauKy(dr, true));
                                    }
                                }
                            }
                            else
                            {
                                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                                {
                                    while (dr.Read())
                                    {
                                        this.Add(SoDuDauKy.GetSoDuDauKy(dr, false));
                                    }
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

            else if (criteria is CriteriaInsertSoDuDauKy)
            {
                CriteriaInsertSoDuDauKy critinsert = (CriteriaInsertSoDuDauKy)criteria;
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_KetChuyenSoDuDau";
                            cm.CommandTimeout = 0;
                            cm.Parameters.AddWithValue("@MaKy", critinsert.MaKy);
                            cm.Parameters.AddWithValue("@MaBoPhan", critinsert.MaBoPhan);
                            cm.ExecuteNonQuery();                                         
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else if (criteria is CriteriaInsertSoDuDauKyTaiKhoanDoiTuong)
            {
                CriteriaInsertSoDuDauKyTaiKhoanDoiTuong critinsert = (CriteriaInsertSoDuDauKyTaiKhoanDoiTuong)criteria;
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_KetChuyenSoDuDauTaiKhoanDoiTuong";
                            cm.CommandTimeout = 0;
                            cm.Parameters.AddWithValue("@Nam", critinsert.MaKy);
                            cm.Parameters.AddWithValue("@MaBoPhan", critinsert.MaBoPhan);
                            cm.ExecuteNonQuery();
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
            // update (thus deleting) any deleted child objects
            foreach (SoDuDauKy obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (SoDuDauKy obj in this)
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
