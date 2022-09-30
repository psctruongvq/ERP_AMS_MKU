using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class NghiepVuDieuChuyenNgoaiList:BusinessListBase<NghiepVuDieuChuyenNgoaiList,NghiepVuDieuChuyenNgoai>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public NghiepVuDieuChuyenNgoai GetThanhLyTaiSan(int maNghiepVuThanhLy)
        {
            foreach (NghiepVuDieuChuyenNgoai tlts in this)
                if (tlts.MaNghiepVuThanhLy == maNghiepVuThanhLy)
                    return tlts;
            return null;
        }

        public void Remove(int maNghiepVuThanhLy)
        {
            foreach (NghiepVuDieuChuyenNgoai item in this)
            {
                if (item.MaNghiepVuThanhLy == maNghiepVuThanhLy)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            NghiepVuDieuChuyenNgoai item = NghiepVuDieuChuyenNgoai.NewDieuChuyenNgoai();
            Add(item);
            return item;
        }
        #endregion    



        #region Factory Methods

        public static NghiepVuDieuChuyenNgoaiList NewThanhLyTaiSanList()
        {
          return DataPortal.Create<NghiepVuDieuChuyenNgoaiList>();
        }

        public static NghiepVuDieuChuyenNgoaiList GetThanhLyTaiSanList( )
        {
          return DataPortal.Fetch<NghiepVuDieuChuyenNgoaiList>(new Criteria());
        }
               
        private NghiepVuDieuChuyenNgoaiList()
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

        public static NghiepVuDieuChuyenNgoai GetNghiepVuThanhLyTheoChungTu(long maChungTu, int maLoaiChungTu)
        {
            NghiepVuDieuChuyenNgoai nghiepVuThanhLy=NghiepVuDieuChuyenNgoai.NewDieuChuyenNgoai(); 

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_NghiepVuChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    cm.Parameters.AddWithValue("@maLoaiChungTu", maLoaiChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            nghiepVuThanhLy = NghiepVuDieuChuyenNgoai.GetDieuChuyenNgoai(dr);
                            // load child objects
                            dr.NextResult();
                        }
                    }
                }
            }
            return nghiepVuThanhLy;

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
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadAllNghiepVuThanhLy";                       

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(NghiepVuDieuChuyenNgoai.GetDieuChuyenNgoai(dr));
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
            // add/update any current child objects
            foreach (NghiepVuDieuChuyenNgoai obj in this)
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
