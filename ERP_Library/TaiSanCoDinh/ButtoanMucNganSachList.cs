using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class ButtoanMucNganSachList:BusinessListBase<ButtoanMucNganSachList,ButToanMucNganSach>
    {
        public int _MaButToan = 0;
        
        #region Business Methods

        // TODO: add public properties and methods

        public ButToanMucNganSach GetButoanMucNganSach(int MaButtoanMucNgansach)
        {
            foreach (ButToanMucNganSach btmns in this)
                if (btmns.MaButToanMucNganSach == MaButtoanMucNgansach)
                    return btmns;
            return null;
        }

        public void Remove(int maButtoanMucNganSach)
        {
            foreach (ButToanMucNganSach item in this)
            {
                if (item.MaButToanMucNganSach == maButtoanMucNganSach)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            ButToanMucNganSach item = ButToanMucNganSach.NewButToanMucNganSach();
            item.MaButToan = _MaButToan;
            Add(item);
            return item;
        }
        #endregion    

        public ButtoanMucNganSachList(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;
            while (dr.Read())
                this.Add(ButToanMucNganSach.GetButToanMucNganSach(dr));
            RaiseListChangedEvents = true;
        }

        #region Factory Methods

        public static ButtoanMucNganSachList NewButtoanMucNganSachList()
        {
          return new ButtoanMucNganSachList();
        }

        public static ButtoanMucNganSachList GetButtoanMucNganSachList( )
        {
          return DataPortal.Fetch<ButtoanMucNganSachList>(new Criteria());
        }
        
        public static ButtoanMucNganSachList GetButtoanMucNganSachListByMaButToan(int maButToan)
        {
            return DataPortal.Fetch<ButtoanMucNganSachList>(new FilterByMaButToanCriteria(maButToan));
        }

        public static ButtoanMucNganSachList GetButtoanMucNganSachListByChiPhiSanXuat(long maCT_CPSX)
        {
            return DataPortal.Fetch<ButtoanMucNganSachList>(new FilterCriteriaByChiPhiSanXuat(maCT_CPSX));
        }

        public static ButtoanMucNganSachList GetButtoanMucNganSachListByKetChuyenChiPhi_New(long maCT_CPSX)
        {
            return DataPortal.Fetch<ButtoanMucNganSachList>(new FilterCriteriaByKetChuyenChiPhi_New(maCT_CPSX));
        }

        private ButtoanMucNganSachList ()
        {
            this.AllowNew = true;             
        }

        /*public static ButtoanMucNganSachList GetButtoanMucNganSachList(SafeDataReader dr)
        {
            return new ButtoanMucNganSachList(dr);
        }
        */
        #endregion

        #region Data Access

        [Serializable()]
        private class Criteria
        {
            //hong làm gì hêt
        }


        [Serializable()]
        private class FilterByMaButToanCriteria
        {
            public int MaButToan;
            public FilterByMaButToanCriteria(int maButToan)
            {
                MaButToan = maButToan;
            }

        }
        private class FilterCriteriaByKetChuyenChiPhi_New
        {
            public long MaCT_CPSX;
            public FilterCriteriaByKetChuyenChiPhi_New(long maCT_CPSX)
            {
                MaCT_CPSX = maCT_CPSX;
            }
        }

        private class FilterCriteriaByChiPhiSanXuat
        {
            public long MaCT_CPSX;
            public FilterCriteriaByChiPhiSanXuat(long maCT_CPSX)
            {
                MaCT_CPSX = maCT_CPSX;
            }
        }  

        protected override void DataPortal_Fetch(object criteria)
        {
            try
            {
                if (criteria is Criteria)
                {
                    this.RaiseListChangedEvents = false;
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = " Select tblButToan_MucNganSach.*, tblTieuMucNganSach.MaQuanLy as MaTieuMucQL,tblTieuMucNganSach.TenTieuMuc as TenTieuMuc from tblButToan_MucNganSach  inner join tblTieuMucNganSach on tblButToan_MucNganSach.MaTieuMuc=tblTieuMucNganSach.MaTieuMuc";
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(ButToanMucNganSach.GetButToanMucNganSach(dr));
                                }
                            }
                        }

                    }
                    this.RaiseListChangedEvents = true;
                }
                else if (criteria is FilterCriteriaByKetChuyenChiPhi_New)
                {
                    FilterCriteriaByKetChuyenChiPhi_New crit = (FilterCriteriaByKetChuyenChiPhi_New)criteria;

                    this.RaiseListChangedEvents = false;
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "Spd_SelecttblButToanMucNganSachByKetChuyen_New";
                            cm.Parameters.AddWithValue("@MaCT_CPSX", crit.MaCT_CPSX);
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(ButToanMucNganSach.GetButToanMucNganSach(dr,1));
                                }
                            }
                            this.RaiseListChangedEvents = true;
                        }
                    }
                }
                else if (criteria is FilterByMaButToanCriteria)
                {
                    FilterByMaButToanCriteria crit = (FilterByMaButToanCriteria)criteria;

                    this.RaiseListChangedEvents = false;
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_Load_ButToan_MucNganSach_ByMaButToan";
                            cm.Parameters.AddWithValue("@MaButToan", crit.MaButToan);
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(ButToanMucNganSach.GetButToanMucNganSach(dr));
                                }
                            }
                            this._MaButToan = crit.MaButToan;
                            this.RaiseListChangedEvents = true;
                        }
                    }
                }
                else if (criteria is FilterCriteriaByChiPhiSanXuat)
                {
                    FilterCriteriaByChiPhiSanXuat crit = (FilterCriteriaByChiPhiSanXuat)criteria;

                    this.RaiseListChangedEvents = false;
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_SelecttblButToanMucNganSachByChiPhiSanXuat";
                            cm.Parameters.AddWithValue("@MaCT_CPSX", ((FilterCriteriaByChiPhiSanXuat)criteria).MaCT_CPSX);
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(ButToanMucNganSach.GetButToanMucNganSach(dr,1));
                                }
                            }
                            this.RaiseListChangedEvents = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public  void DataPortal_Update(SqlTransaction tr)
        {
            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (ButToanMucNganSach obj in DeletedList)
                obj.DeleteSelf(tr);
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (ButToanMucNganSach obj in this)
            {
                if (obj.IsDirty)
                {
                    if (obj.IsNew)
                        obj.Insert(tr);
                    else
                        obj.Update(tr);
                }
            }
            this.RaiseListChangedEvents = true;
        }

        public void DataPortal_Update(SqlTransaction tr, long maCTChiPhiSanXuat, int maButToan)
        {
            RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (ButToanMucNganSach deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ButToanMucNganSach child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, maCTChiPhiSanXuat, maButToan);
                    else
                        child.Update(tr, maCTChiPhiSanXuat, maButToan);
                }
            }

            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }


            RaiseListChangedEvents = true;
        }

        public void DataPortal_Delete(SqlTransaction tr)
        {
            foreach (ButToanMucNganSach obj in this)
            {
                obj.DeleteSelf(tr);
            }
        }
        #endregion
    }
}
