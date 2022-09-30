using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Data;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Library
{
    [Serializable()]
    public class ButToanMucNganSach : BusinessBase<ButToanMucNganSach>
    {
        private bool _idSet;
        protected override object GetIdValue()
        {
            return _MaTieuMuc;
        }

        #region rule
        protected override void AddBusinessRules()
        {
            //ValidationRules.AddRule(KiemTraTextDecimal, "SoTien");
            //ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "DienGiai");
        }
        private bool KiemTraTextDecimal(object target, Csla.Validation.RuleArgs e)
        {
            if (_SoTien == 0)
            {
                e.Description = "Vui Lòng Nhập Tiền Cho Mục Ngân Sách";
                return false;
            }
            else
                return true;
        }
        #endregion

        #region Khai báo biến

        private long _mactChiphisanxuat = 0;
        public long MactChiphisanxuat
        {
            get
            {
                return _mactChiphisanxuat;
            }
            set
            {
                if (!_mactChiphisanxuat.Equals(value))
                {
                    _mactChiphisanxuat = value;
                    PropertyHasChanged("MaCT_ChiPhiSanXuat");
                }
            }
        }
        int _MaButToanMucNganSach;
        public int MaButToanMucNganSach
        {
          get
          {
            CanReadProperty(true) ;
            //if (!_idSet)
            //{
            //    _idSet = true;
            //    int max = 0;
            //    if (this.Parent == null) return 0;
            //    ButtoanMucNganSachList parent = (ButtoanMucNganSachList)this.Parent;
            //    foreach (ButToanMucNganSach item in parent)
            //    {
            //        if (item.MaButToanMucNganSach > max)
            //            max = item.MaButToanMucNganSach;
            //    }
            //    _MaButToanMucNganSach = max + 1;
            //}
            return _MaButToanMucNganSach;
          }
          set
          {
            CanWriteProperty(true);
            if (!_MaButToanMucNganSach.Equals(value))
            {
              _MaButToanMucNganSach = value;
              PropertyHasChanged();
            }
          }
        }

        int _MaButToan;
        public int MaButToan
        {
          get
          {
            CanReadProperty(true) ;
            return _MaButToan;
          }
          set
          {
            CanWriteProperty(true);
            if (!_MaButToan.Equals(value))
            {
              _MaButToan = value;
              PropertyHasChanged();
            }
          }
        }

        int _MaTieuMuc;
        public int MaTieuMucNganSach
        {
            get
            {
                CanReadProperty(true);
                return _MaTieuMuc;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaTieuMuc.Equals(value))
                {
                    _MaTieuMuc = value;
                    PropertyHasChanged();
                }
            }
        }

        string  _MaTieuMucQL=string.Empty;
        public String MaTieuMucQL
        {
            get
            {
                CanReadProperty(true);
                return _MaTieuMucQL;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaTieuMucQL.Equals(value))
                {
                    _MaTieuMucQL = value;
                    PropertyHasChanged();
                }
            }
        }

        String _TenTieuMuc=string.Empty;
        public String TenTieuMuc
        {
            get
            {
                CanReadProperty(true);
                return _TenTieuMuc;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenTieuMuc.Equals(value))
                {
                    _TenTieuMuc = value;
                    PropertyHasChanged();
                }
            }
        }


        Decimal _SoTien;
        public Decimal SoTien
        {
            get
            {
                CanReadProperty(true);
                return _SoTien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoTien.Equals(value))
                {
                    _SoTien = value;
                    PropertyHasChanged();
                }
            }
        }

        String _DienGiai;
        public String DienGiai
        {
            get
            {
                CanReadProperty(true);
                return _DienGiai;
            }
            set
            {
                CanWriteProperty(true);
                if (!_DienGiai.Equals(value))
                {
                    _DienGiai = value;
                    PropertyHasChanged();
                }
            }
        }
        private TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        #endregion

        #region constructor

        private ButToanMucNganSach()
        {
            _MaButToanMucNganSach = 0;
            _MaButToan = 0;
            _MaTieuMuc = 0;
            _SoTien = 0;
            _DienGiai = String.Empty;
            MarkAsChild();
        }

        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaButToanMucNganSach;

            public Criteria(int maButToanMucNganSach)
            {
                MaButToanMucNganSach = maButToanMucNganSach;
            }
        }

        #endregion

        #region Static Methods

        internal void Insert(SqlTransaction tr, long maCTChiPhiSanXuat, int maButToan)
        {
            _mactChiphisanxuat = maCTChiPhiSanXuat;
            _MaButToan = maButToan;
            if (!IsDirty) return;
            ExecuteInsert(tr, maCTChiPhiSanXuat);
            MarkOld();
        }

        internal void Update(SqlTransaction tr,long maCTChiPhiSanXuat, int maButToan)
        {
            _MaButToan = maButToan;
            _mactChiphisanxuat = maCTChiPhiSanXuat;
            ExecuteUpdate(tr,maCTChiPhiSanXuat);
        }

        public override ButToanMucNganSach Save()
        {
            return base.Save();
        }

        public void DeleteSelf(SqlTransaction tr)
        {
            DataPortal_Delete(tr);
        }

        public void Insert(SqlTransaction tr)
        {
            DataPortal_Insert(tr);
        }

        public void Update(SqlTransaction tr)
        {
            DataPortal_Update(tr);
        }


        private ButToanMucNganSach(SafeDataReader dr)
        {
            MarkAsChild();
            _MaButToanMucNganSach = dr.GetInt32("MaButToanMucNganSach");
            _MaButToan = dr.GetInt32("MaButToan");
            _MaTieuMuc = dr.GetInt32("MaTieuMuc");
            _SoTien = dr.GetDecimal("SoTien");
            _DienGiai = dr.GetString("DienGiai");
            _MaTieuMucQL=dr.GetString("MaTieuMucQL");
            _TenTieuMuc = dr.GetString("TenTieuMuc");
            _idSet = true;
            MarkOld();
        }

        private ButToanMucNganSach(SafeDataReader dr, int loai)
        {
            MarkAsChild();
            _MaButToanMucNganSach = dr.GetInt32("MaButToanMucNganSach");
            _MaButToan = dr.GetInt32("MaButToan");
            _MaTieuMuc = dr.GetInt32("MaTieuMuc");
            _SoTien = dr.GetDecimal("SoTien");
            _DienGiai = dr.GetString("DienGiai");
            _mactChiphisanxuat = dr.GetInt64("MaCT_ChiPhiSanXuat");
            _idSet = true;
            MarkOld();
        }

        public static ButToanMucNganSach NewButToanMucNganSach()
        {
            ButToanMucNganSach btmns = new ButToanMucNganSach();
            btmns.MaButToanMucNganSach = 0;
            btmns.MaButToan = 0;
            btmns.MaTieuMucNganSach = 0;
            btmns.SoTien = 0;
            btmns.DienGiai = String.Empty;
            btmns.MarkDirty();
            btmns.ValidationRules.CheckRules();
            return btmns;
        }

        public static ButToanMucNganSach NewButToanMucNganSach(int maButToanMucNganSach, int maButToan, int maTieuMuc, Decimal soTien, String dienGiai)
        {
            ButToanMucNganSach btmns = new ButToanMucNganSach();
            btmns._MaButToanMucNganSach = maButToanMucNganSach;
            btmns._MaButToan = maButToan;
            btmns._MaTieuMuc = maTieuMuc;
            btmns._SoTien = soTien;
            btmns._DienGiai = dienGiai;
            btmns.MarkDirty();
            btmns.ValidationRules.CheckRules();
            return btmns;
        }

        public static ButToanMucNganSach GetButToanMucNganSach(int maButToanMucNganSach)
        {
            return (ButToanMucNganSach)DataPortal.Fetch<ButToanMucNganSach>(new Criteria(maButToanMucNganSach));
        }

        public static ButToanMucNganSach GetButToanMucNganSach(SafeDataReader dr)
        {
            return new ButToanMucNganSach(dr);
        }

        public static ButToanMucNganSach GetButToanMucNganSach(SafeDataReader dr, int loai)
        {
            return new ButToanMucNganSach(dr,loai);
        }

        public static void DeleteButToanMucNganSach(int maButToanMucNganSach)
        {
            DataPortal.Delete(new Criteria(maButToanMucNganSach));
        }

        #endregion

        #region Data Access

        #region load tất cả cả
        private void ExecuteUpdate(SqlTransaction tr, long mactChiphisanxuat)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_ButToan_MucNganSach_New";

                AddUpdateParameters(cm, mactChiphisanxuat);
                try
                {

                    cm.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }

            }//using
        }


        private void AddUpdateParameters(SqlCommand cm, long mactChiphisanxuat)
        {
            cm.Parameters.AddWithValue("@MaButToanMucNganSach", _MaButToanMucNganSach);
            cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", _mactChiphisanxuat);
            cm.Parameters.AddWithValue("@MaButToan", _MaButToan);
            cm.Parameters.AddWithValue("@MaTieuMuc", _MaTieuMuc);
            cm.Parameters.AddWithValue("@SoTien", _SoTien);
            cm.Parameters.AddWithValue("@DienGiai", _DienGiai);   

        }
        protected override void DataPortal_Fetch(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadMaCaBiet_ButToan_MucNganSach";
                    cm.Parameters.AddWithValue("@MaButToanMucNganSach", crit.MaButToanMucNganSach);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        _MaButToanMucNganSach = dr.GetInt32("MaButToanMucNganSach");
                        _MaButToan = dr.GetInt32("MaButToan");
                        _MaTieuMuc = dr.GetInt32("MaTieuMuc");
                        _SoTien = dr.GetDecimal("SoTien");
                        _DienGiai = dr.GetString("DienGiai");                       
                        // load child objects
                        dr.NextResult();
                    }
                }
                MarkOld();
            }
        }
        private void ExecuteInsert(SqlTransaction tr, long maCTChiPhiSanXuat)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_ButToan_MucNganSach_New";

                AddInsertParameters(cm, maCTChiPhiSanXuat);

                cm.ExecuteNonQuery();

                _MaButToanMucNganSach = (int)cm.Parameters["@MaButToanMucNganSach"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, long maCTChiPhiSanXuat)
        {
                    cm.Parameters.AddWithValue("@MaButToanMucNganSach", _MaButToanMucNganSach).Direction = ParameterDirection.Output;
                    cm.Parameters.AddWithValue("@MaButToan", _MaButToan);
                    cm.Parameters.AddWithValue("@MaTieuMuc", _MaTieuMuc);
                    cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", _mactChiphisanxuat);
                    cm.Parameters.AddWithValue("@SoTien", _SoTien);
                    cm.Parameters.AddWithValue("@DienGiai", _DienGiai);
        }
        protected  void DataPortal_Insert( SqlTransaction  tr)
        {
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Insert_ButToan_MucNganSach";
                    cm.Parameters.AddWithValue("@MaButToanMucNganSach", _MaButToanMucNganSach).Direction = ParameterDirection.Output;
                    cm.Parameters.AddWithValue("@MaButToan", ((ButtoanMucNganSachList)Parent)._MaButToan);
                    cm.Parameters.AddWithValue("@MaTieuMuc", _MaTieuMuc);
                    cm.Parameters.AddWithValue("@SoTien", _SoTien);
                    cm.Parameters.AddWithValue("@DienGiai", _DienGiai);
                    cm.ExecuteNonQuery();
                    _MaButToanMucNganSach = (int)cm.Parameters["@MaButToanMucNganSach"].Value;
                    this.MarkOld();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected  void DataPortal_Update(SqlTransaction tr)
        {
            try
            {   
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;                    
                    cm.CommandText = "spd_Update_ButToan_MucNganSach";
                    cm.Parameters.AddWithValue("@MaButToanMucNganSach", _MaButToanMucNganSach);
                    cm.Parameters.AddWithValue("@MaButToan", ((ButtoanMucNganSachList)Parent)._MaButToan);
                    cm.Parameters.AddWithValue("@MaTieuMuc", _MaTieuMuc);
                    cm.Parameters.AddWithValue("@SoTien", _SoTien);
                    cm.Parameters.AddWithValue("@DienGiai", _DienGiai);
                    cm.ExecuteNonQuery();
                    
                    MarkOld();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        #region Delete

        protected void DataPortal_Delete(SqlTransaction tr)
        {
            //Criteria crit = (Criteria)criteria;

                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction=tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Delete_ButToan_MucNganSach";
                        cm.Parameters.AddWithValue("@MaButToanMucNganSach", MaButToanMucNganSach);
                        cm.ExecuteNonQuery();
                    }
                }
                        
            
        

        //protected void DataPortal_DeleteSelf)
        //{
        //    DataPortal_Delete(t);
        //}

        #endregion

        #endregion

        #endregion
    }
}
