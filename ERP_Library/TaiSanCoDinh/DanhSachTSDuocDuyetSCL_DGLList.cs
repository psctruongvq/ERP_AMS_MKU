using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class DanhSachTSDuocDuyetSCL_DGLList : BusinessListBase<DanhSachTSDuocDuyetSCL_DGLList,DanhSachTSDuocDuyetSCL_DGL>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public DanhSachTSDuocDuyetSCL_DGL GetDanhSach(int maDuocDuyet)
        {
            foreach (DanhSachTSDuocDuyetSCL_DGL lhd in this)
                if (lhd.MaDuocDuyet == maDuocDuyet)
                    return lhd;
            return null;
        }

        public void Remove(int maDuocDuyet)
        {
            foreach (DanhSachTSDuocDuyetSCL_DGL item in this)
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
            DanhSachTSDuocDuyetSCL_DGL item = DanhSachTSDuocDuyetSCL_DGL.NewDanhSach();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static DanhSachTSDuocDuyetSCL_DGLList NewDanhSachList()
        {
            //return DataPortal.Create<DanhSachTSDuocDuyetSCL_DGLList>();
            return new DanhSachTSDuocDuyetSCL_DGLList();
        }

        public static DanhSachTSDuocDuyetSCL_DGLList GetDanhSachList( )
        {
          return DataPortal.Fetch<DanhSachTSDuocDuyetSCL_DGLList>(new Criteria());
        }

        public static DanhSachTSDuocDuyetSCL_DGLList GetTSCDSCL1_DGL0(int loaiPhanBiet)
        {
            DanhSachTSDuocDuyetSCL_DGLList dsTSCDSCL_DGL;
            dsTSCDSCL_DGL = new DanhSachTSDuocDuyetSCL_DGLList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadTSCDDuyetSCL_DGL";
                        cm.Parameters.AddWithValue("@LoaiPhanBiet", loaiPhanBiet);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                dsTSCDSCL_DGL.Add(DanhSachTSDuocDuyetSCL_DGL.GetDanhSach(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dsTSCDSCL_DGL;
        }

        private DanhSachTSDuocDuyetSCL_DGLList()
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

        protected override void DataPortal_Fetch(object criteria)
        {
            this.RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select * from tblDanhSachTSCDDanhGiaLai_SuaChuaLon";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(DanhSachTSDuocDuyetSCL_DGL.GetDanhSach(dr));
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
            foreach (DanhSachTSDuocDuyetSCL_DGL obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (DanhSachTSDuocDuyetSCL_DGL obj in this)
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
