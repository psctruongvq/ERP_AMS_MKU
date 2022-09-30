using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class NuocSanXuatList:BusinessListBase<NuocSanXuatList,NuocSanXuat>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public NuocSanXuat GetNuocSanXuat(int MaNuocSX)
        {
            foreach (NuocSanXuat nsx in this)
                if (nsx.MaNuocSX == MaNuocSX)
                    return nsx;
            return null;
        }

        public void Remove(int maNuocSX)
        {
            foreach (NuocSanXuat item in this)
            {
                if (item.MaNuocSX == maNuocSX)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            try
            {
                NuocSanXuat item = NuocSanXuat.NewNuocSanXuat();
                Add(item);
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }                
        }
        #endregion    

        #region Factory Methods

        public static NuocSanXuatList NewNuocSanXuatList()
        {
          return DataPortal.Create<NuocSanXuatList>();
        }

        public static NuocSanXuatList GetNuocSanXuatList( )
        {
          return DataPortal.Fetch<NuocSanXuatList>(new Criteria());
        }
               
        private NuocSanXuatList()
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
                    cm.CommandText = "select [MaQuocGia],[MaQuocGiaQuanLy],[TenQuocGia],[TenVietTat],[DienGiai] from tblQuocGia";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(NuocSanXuat.GetNuocSanXuat(dr));
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
            foreach (NuocSanXuat obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (NuocSanXuat obj in this)
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
