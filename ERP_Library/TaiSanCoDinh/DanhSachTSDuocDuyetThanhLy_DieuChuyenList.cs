using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class DanhSachTSDuocDuyetThanhLy_DieuChuyenList:BusinessListBase<DanhSachTSDuocDuyetThanhLy_DieuChuyenList,DanhSachTSDuocDuyetThanhLy_DieuChuyen>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public DanhSachTSDuocDuyetThanhLy_DieuChuyen GetDSThanhLy_DieuChuyen(int maDuocDuyet)
        {
            foreach (DanhSachTSDuocDuyetThanhLy_DieuChuyen ds in this)
                if (ds.MaDuocDuyet == maDuocDuyet)
                    return ds;
            return null;
        }

        public void Remove(int maDuocDuyet)
        {
            foreach (DanhSachTSDuocDuyetThanhLy_DieuChuyen item in this)
            {
                if (item.MaDuocDuyet == maDuocDuyet)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            DanhSachTSDuocDuyetThanhLy_DieuChuyen item = DanhSachTSDuocDuyetThanhLy_DieuChuyen.NewDanhSach();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static DanhSachTSDuocDuyetThanhLy_DieuChuyenList NewDanhSachList()
        {
            //return DataPortal.Create<DanhSachTSDuocDuyetThanhLy_DieuChuyenList>();
            return new DanhSachTSDuocDuyetThanhLy_DieuChuyenList();
        }

        public static DanhSachTSDuocDuyetThanhLy_DieuChuyenList GetDanhSachList( )
        {
          return DataPortal.Fetch<DanhSachTSDuocDuyetThanhLy_DieuChuyenList>(new Criteria());
        }
        
        private DanhSachTSDuocDuyetThanhLy_DieuChuyenList()
        {
            this.AllowNew = true;            
        }

        public static DanhSachTSDuocDuyetThanhLy_DieuChuyenList GetTSCDThanhLy0_DieuChuyen1(int loaiPhanBiet)
        {
            DanhSachTSDuocDuyetThanhLy_DieuChuyenList dsTSCDThanhLy_DieuChuyen;
            dsTSCDThanhLy_DieuChuyen = new DanhSachTSDuocDuyetThanhLy_DieuChuyenList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadTSCDDuyetThanhLy_DieuChuyen";
                        cm.Parameters.AddWithValue("@LoaiPhanBiet", loaiPhanBiet);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                dsTSCDThanhLy_DieuChuyen.Add(DanhSachTSDuocDuyetThanhLy_DieuChuyen.GetDanhSach(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dsTSCDThanhLy_DieuChuyen;
        }

        #endregion

        #region Data Access

        [Serializable()]
        private class Criteria
        {
            //hong làm gì hêt
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
                            cm.CommandText = "select * from tblDanhSachTSCDDuocDuyet";

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(DanhSachTSDuocDuyetThanhLy_DieuChuyen.GetDanhSach(dr));
                                }
                            }
                        }

                    }
                    this.RaiseListChangedEvents = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (DanhSachTSDuocDuyetThanhLy_DieuChuyen obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (DanhSachTSDuocDuyetThanhLy_DieuChuyen obj in this)
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
