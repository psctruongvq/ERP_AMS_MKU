using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Data;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ERP_Library
{
    [Serializable()]
    public class DanhSachTSDuocDuyetThanhLy_DieuChuyen : BusinessBase<DanhSachTSDuocDuyetThanhLy_DieuChuyen>
    {
        Boolean _idSet = false;
        protected override object GetIdValue()
        {
            return _MaDuocDuyet;
        }

        #region Properties
        int _MaDuocDuyet;
        public int MaDuocDuyet
        {
            get
            {
                CanReadProperty(true);
                if (!_idSet)
                {
                    //generate a default id value
                    _idSet = true;
                    if (Parent == null) return 0;
                    DanhSachTSDuocDuyetThanhLy_DieuChuyenList parent = (DanhSachTSDuocDuyetThanhLy_DieuChuyenList)this.Parent;
                    int max = 0;
                    foreach (DanhSachTSDuocDuyetThanhLy_DieuChuyen item in parent)
                    {
                        if (item.MaDuocDuyet > max)
                            max = item.MaDuocDuyet;
                    }
                    _MaDuocDuyet = max + 1;
                }
                return _MaDuocDuyet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaDuocDuyet.Equals(value))
                {
                    _MaDuocDuyet = value;
                    PropertyHasChanged();
                }
            }
        }

        bool _DuocDuyet;
        public bool DuocDuyet
        {
            get
            {
                CanReadProperty(true);
                return _DuocDuyet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_DuocDuyet.Equals(value))
                {
                    _DuocDuyet = value;
                    PropertyHasChanged();
                }
            }
        }

        TSCDCaBiet _TSCDCaBiet = TSCDCaBiet.NewTSCDCaBiet();
        public TSCDCaBiet TSCDCaBiet
        {
            get
            {
                CanReadProperty(true);
                return _TSCDCaBiet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TSCDCaBiet.Equals(value))
                {
                    _TSCDCaBiet = value;
                    PropertyHasChanged();
                }
            }
        }

        String _SoHieu = String.Empty;
        public String SoHieu
        {
            get
            {
                CanReadProperty(true);
                return _TSCDCaBiet.SoHieuCB;
            }
        }

        String _TenTSCD = String.Empty;
        public String TenTSCD
        {
            get
            {
                CanReadProperty(true);
                return _TSCDCaBiet.TaiSanCoDinh.TenTSCD;
            }
        }

        String _TenBoPhanSD = String.Empty;
        public String TenBoPhanSD
        {
            get
            {
                CanReadProperty(true);
                return _TSCDCaBiet.TenPhongBan;
            }
        }

        int _LoaiPhanBiet;
        public int LoaiPhanBiet
        {
            get
            {
                CanReadProperty(true);
                return _LoaiPhanBiet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_LoaiPhanBiet.Equals(value))
                {
                    _LoaiPhanBiet = value;
                    PropertyHasChanged();
                }
            }
        }
        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaDuocDuyet;
            public Criteria(int maDuocDuyet)
            {
                MaDuocDuyet = maDuocDuyet;
            }

            public bool LoaiPhanBiet;
            public Criteria(bool loaiPhanBiet)
            {
                LoaiPhanBiet = loaiPhanBiet;
            }
        }

        #endregion

        #region Contructors
        private DanhSachTSDuocDuyetThanhLy_DieuChuyen()
        {
            _MaDuocDuyet = 0;
            _TSCDCaBiet = TSCDCaBiet.NewTSCDCaBiet();
            _SoHieu = String.Empty;
            _TenTSCD = String.Empty;
            _LoaiPhanBiet = 0;
            _DuocDuyet = false;
            MarkAsChild();
        }
        #endregion

        #region Static Methods

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }

        public override DanhSachTSDuocDuyetThanhLy_DieuChuyen Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaDuocDuyet));
        }

        private DanhSachTSDuocDuyetThanhLy_DieuChuyen(SafeDataReader dr)
        {
            MarkAsChild();
            _MaDuocDuyet = dr.GetInt32("MaDuocDuyet");
            _TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
            _LoaiPhanBiet = dr.GetInt32("LoaiPhanBiet");
            _DuocDuyet = dr.GetBoolean("DuocDuyet");
            _idSet = true;
            MarkOld();
        }

        public static DanhSachTSDuocDuyetThanhLy_DieuChuyen NewDanhSach1()
        {
            DanhSachTSDuocDuyetThanhLy_DieuChuyen ds = new DanhSachTSDuocDuyetThanhLy_DieuChuyen();
            ds.MaDuocDuyet = 0;
            ds.DuocDuyet = false;
            ds.LoaiPhanBiet = 0;
            ds.TSCDCaBiet.MaTSCDCaBiet = 0;
            ds.MarkDirty();
            return ds;
        }

        public static DanhSachTSDuocDuyetThanhLy_DieuChuyen NewDanhSach()
        {
            DanhSachTSDuocDuyetThanhLy_DieuChuyen ds = new DanhSachTSDuocDuyetThanhLy_DieuChuyen();
            return ds;
        }

        public static DanhSachTSDuocDuyetThanhLy_DieuChuyen GetDanhSach(int maDuocDuyet)
        {
            if (maDuocDuyet == 0) return new DanhSachTSDuocDuyetThanhLy_DieuChuyen();
            return (DanhSachTSDuocDuyetThanhLy_DieuChuyen)DataPortal.Fetch<DanhSachTSDuocDuyetThanhLy_DieuChuyen>(new Criteria(maDuocDuyet));
        }

        internal static DanhSachTSDuocDuyetThanhLy_DieuChuyen GetDanhSach(SafeDataReader dr)
        {
            return new DanhSachTSDuocDuyetThanhLy_DieuChuyen(dr);
        }

        public static void DeleteDanhSach(int maDuocDuyet)
        {
            DataPortal.Delete(new Criteria(maDuocDuyet));
        }

        #endregion

        #region Data Access

        #region load tất cả cả

        protected override void DataPortal_Fetch(object criteria)
        {
            //Criteria crit = (Criteria)criteria;
            //using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            //{
            //    cn.Open();
            //    using (SqlCommand cm = cn.CreateCommand())
            //    {
            //        cm.CommandType = CommandType.StoredProcedure;
            //        cm.CommandText = "spd_LoadMaCaBiet_DSThanhLy_DieuChuyen";
            //        cm.Parameters.AddWithValue("@LoaiPhanBiet", crit.LoaiPhanBiet);

            //        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
            //        {
            //            dr.Read();
            //            _MaDuocDuyet = dr.GetInt32("MaDuocDuyet");
            //            _DuocDuyet = dr.GetBoolean("DuocDuyet");
            //            _TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
            //            _LoaiPhanBiet = dr.GetBoolean("LoaiPhanBiet");
            //            _idSet = true;
            //            // load child objects
            //            dr.NextResult();
            //        }
            //    }
            //    MarkOld();
            //}
        }
        
        protected override void DataPortal_Update()
        {
            // save data into db
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_Update_DSThanhLy_DieuChuyen";
                        cm.Parameters.AddWithValue("@MaDuocDuyet", _MaDuocDuyet);
                        cm.Parameters.AddWithValue("@DuocDuyet", _DuocDuyet);
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", _TSCDCaBiet.MaTSCDCaBiet);
                        cm.Parameters.AddWithValue("@LoaiPhanBiet", _LoaiPhanBiet);
                        cm.ExecuteNonQuery();
                        // make sure we're marked as an old object
                        MarkOld();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #region Delete

        protected override void DataPortal_Delete(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Delete_DSThanhLy_DieuChuyen";
                    cm.Parameters.AddWithValue("@MaDuocDuyet", crit.MaDuocDuyet);
                    cm.ExecuteNonQuery();
                }
            }
        }

        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaDuocDuyet));
        }
        #endregion

        #endregion

        #endregion
    }
}
