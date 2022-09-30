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
    public class DanhSachTSDuocDuyetSCL_DGL : BusinessBase<DanhSachTSDuocDuyetSCL_DGL>
    {
        private bool _idSet;

        protected override object GetIdValue()
        {
            return _MaDuocDuyet;
        }

        #region Properties

        int _MaDuocDuyet = 0;
        public int MaDuocDuyet
        {
            get
            {
                CanReadProperty(true);
                if (!_idSet)
                {
                    //generate a default id value
                    _idSet = true;
                    if (this.Parent == null) return 0;
                    DanhSachTSDuocDuyetSCL_DGLList parent = (DanhSachTSDuocDuyetSCL_DGLList)this.Parent;
                    int max = 0;
                    foreach (DanhSachTSDuocDuyetSCL_DGL item in parent)
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

        bool _LoaiPhanBiet;
        public bool LoaiPhanBiet
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

        String _TenBoPhanSD = String.Empty;
        public String TenBoPhanSD
        {
            get
            {
                CanReadProperty(true);
                return _TSCDCaBiet.TenPhongBan;
            }
        }
        #endregion

        #region Static Methods
        //giống constructor

        public override DanhSachTSDuocDuyetSCL_DGL Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaDuocDuyet));
        }

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }

        private DanhSachTSDuocDuyetSCL_DGL(SafeDataReader dr)
        {
            try
            {
                MarkAsChild();
                _MaDuocDuyet = dr.GetInt32("MaDuocDuyet");
                //_TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
                _TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
                _LoaiPhanBiet = dr.GetBoolean("LoaiPhanBiet");
                _DuocDuyet = dr.GetBoolean("DuocDuyet");
                _idSet = true;
                MarkOld();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DanhSachTSDuocDuyetSCL_DGL NewDanhSach()
        {
            DanhSachTSDuocDuyetSCL_DGL ds = new DanhSachTSDuocDuyetSCL_DGL();
            ds.MaDuocDuyet = 0;
            ds.DuocDuyet = false;
            ds.LoaiPhanBiet = false;
            ds.TSCDCaBiet.MaTSCDCaBiet = 0;
            ds.MarkDirty();
            return ds;
        }

        public static DanhSachTSDuocDuyetSCL_DGL GetDanhSach(int maDuocDuyet)
        {
            if (maDuocDuyet == 0) return DanhSachTSDuocDuyetSCL_DGL.NewDanhSach();
            return (DanhSachTSDuocDuyetSCL_DGL)DataPortal.Fetch<DanhSachTSDuocDuyetSCL_DGL>(new Criteria(maDuocDuyet));
        }

        internal static DanhSachTSDuocDuyetSCL_DGL GetDanhSach(SafeDataReader dr)
        {
            return new DanhSachTSDuocDuyetSCL_DGL(dr);
        }

        public static void DeleteDanhSach(int maDuocDuyet)
        {
            DataPortal.Delete(new Criteria(maDuocDuyet));
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

        #region Constructors

        private DanhSachTSDuocDuyetSCL_DGL()
        {
            // Prevent direct creation
            _MaDuocDuyet = 0;
            _DuocDuyet = false;
            _TSCDCaBiet.MaTSCDCaBiet = 0;
            _LoaiPhanBiet = false;
            _SoHieu = String.Empty;
            _TenTSCD = String.Empty;
            MarkAsChild();            
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
            //        cm.CommandText = "spd_LoadMaCaBiet_LoaiHopDong";
            //        cm.Parameters.AddWithValue("@MaLoaiHopDong", crit.MaLoaiHopDong);

            //        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
            //        {
            //            dr.Read();
            //            _MaLoaiHopDong = dr.GetInt32(0);
            //            _TenLoaiHopDong = dr.GetString(1);
            //            _MaLoaiQuanLy = dr.GetString(2);
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
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    // we're not new, so update
                    cm.CommandText = "spd_Update_DSSCL_DGL";
                    cm.Parameters.AddWithValue("@MaDuocDuyet", _MaDuocDuyet);
                    cm.Parameters.AddWithValue("@DuocDuyet", _DuocDuyet);
                    cm.Parameters.AddWithValue("@MaTSCDCaBiet", _TSCDCaBiet.MaTSCDCaBiet);
                    cm.Parameters.AddWithValue("@LoaiPhanBiet", _LoaiPhanBiet);
                    cm.ExecuteNonQuery();
                    // make sure we're marked as an old object
                    MarkOld();
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
                    cm.CommandText = "spd_Delete_DSSCL_DGL";
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
