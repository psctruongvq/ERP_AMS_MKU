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
    public class ChiTietSuaChuaLon : BusinessBase<ChiTietSuaChuaLon>
    {
        private bool _idSet;
        protected override object GetIdValue()
        {
            return _MaChiTiet;
        }

        #region Khai Báo Biến

        int _MaChiTiet;
        public int MaChiTiet
        {
            get
            {
                CanReadProperty(true);
                if (!_idSet)
                {
                    _idSet = true;
                    int max = 0;
                    ChiTietSuaChuaLonList parent = (ChiTietSuaChuaLonList)this.Parent;
                    foreach (ChiTietSuaChuaLon item in parent)
                    {
                        if (item.MaChiTiet > max)
                            max = item.MaChiTiet;
                    }
                    _MaChiTiet = max + 1;
                }
                return _MaChiTiet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaChiTiet.Equals(value))
                {
                    _idSet = true;
                    _MaChiTiet = value;
                    PropertyHasChanged();
                }
            }
        }

        String _TenBoPhan = string.Empty;
        public String TenBoPhan
        {
            get
            {
                CanReadProperty(true);
                return _TenBoPhan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenBoPhan.Equals(value))
                {
                    _TenBoPhan = value;
                    PropertyHasChanged();
                }
            }
        }

        String _NoiDung = string.Empty;
        public String NoiDung
        {
            get
            {
                CanReadProperty(true);
                return _NoiDung;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NoiDung.Equals(value))
                {
                    _NoiDung = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _GiaDuToan = 0;
        public Decimal GiaDuToan
        {
            get
            {
                CanReadProperty(true);
                return _GiaDuToan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_GiaDuToan.Equals(value))
                {
                    _GiaDuToan = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _GiaThucTe = 0;
        public Decimal GiaThucTe
        {
            get
            {
                CanReadProperty(true);
                return _GiaThucTe;
            }
            set
            {
                CanWriteProperty(true);
                if (!_GiaThucTe.Equals(value))
                {
                    _GiaThucTe = value;
                    PropertyHasChanged();
                }
            }
        }

        String _KetQua = string.Empty;
        public String KetQua
        {
            get
            {
                CanReadProperty(true);
                return _KetQua;
            }
            set
            {
                CanWriteProperty(true);
                if (!_KetQua.Equals(value))
                {
                    _KetQua = value;
                    PropertyHasChanged();
                }
            }
        }

        String _MaChiTietQuanLy = string.Empty;
        public String MaChiTietQuanLy
        {
            get
            {
                CanReadProperty(true);
                return _MaChiTietQuanLy;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaChiTietQuanLy.Equals(value))
                {
                    _MaChiTietQuanLy = value;
                    PropertyHasChanged();
                }
            }
        }



        #endregion

        #region constructor
        private ChiTietSuaChuaLon()
        {
            _GiaDuToan = 0;
            _GiaThucTe = 0;
            _KetQua = String.Empty;
            _MaChiTiet = 0;
            _MaChiTietQuanLy = String.Empty;

            _NoiDung = String.Empty;
            _TenBoPhan = String.Empty;
            MarkAsChild(); //Bắt buộc --> vì phải thuộc Nghiệp Vụ Sữa Chữa Lớn nào đó
        }

        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaChiTietSuaChuaLon;

            public Criteria(int maChiTietSuaChuaLon)
            {
                MaChiTietSuaChuaLon = maChiTietSuaChuaLon;
            }
        }

        #endregion

        #region Static Methods
        //giống constructor
        public override ChiTietSuaChuaLon Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaChiTiet));
        }
        public void Insert()
        {
            DataPortal_Insert();
        }

        public void InsertTranSacTion(SqlTransaction tr)
        {
            DataPortal_InsertTranSacTion(tr);
        }

        public void Update()
        {
            DataPortal_Update();
        }

        public void UpdateTranSacTion(SqlTransaction tr)
        {
            DataPortal_UpdateTranSacTion(tr);
        }
        /// <summary>
        /// Constructor này dùng cho PhongBanList Load từng Phòng Ban lên
        /// </summary>
        /// <param name="dr">là SafeDataReader của PhongBanList Fetch ra</param>
        private ChiTietSuaChuaLon(SafeDataReader dr)
        {
            MarkAsChild();
            try
            {
                _MaChiTiet = dr.GetInt32("MaChiTietBoPhanSuaChua");
                _TenBoPhan = dr.GetString("TenBoPhan");
                _NoiDung = dr.GetString("NoiDung");
                _GiaDuToan = dr.GetDecimal("GiaDuToan");
                _GiaThucTe = dr.GetDecimal("GiaThucTe");
                _KetQua = dr.GetString("KetQuaKiemTra");

                _MaChiTietQuanLy = dr.GetString("MaChiTietQuanLy");
                _idSet = true; //Do tự set value cho ID
                MarkOld();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetIdent_SuaChuaLon()
        {
            int ident = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select IDent_Current('tblDoiTuongNghiepVu')";
                    ident = Convert.ToInt32(cm.ExecuteScalar()) + 1;
                    _idSet = true;
                }
            }
            return ident;
        }
        public static ChiTietSuaChuaLon NewChiTietSuaChuaLon()
        {
            return new ChiTietSuaChuaLon();
        }

        public static ChiTietSuaChuaLon NewChiTietSuaChuaLon(Decimal giaDuToan, Decimal giaThucTe, String ketQua,
                String maChiTietQL, String noiDung, String tenBoPhan)
        {
            ChiTietSuaChuaLon ct = new ChiTietSuaChuaLon();
            ct._GiaDuToan = giaDuToan;
            ct._GiaThucTe = giaThucTe;
            ct._KetQua = ketQua;
            ct._MaChiTietQuanLy = maChiTietQL;
            ct._NoiDung = noiDung;
            ct._TenBoPhan = tenBoPhan;
            return ct;
        }
        public static ChiTietSuaChuaLon GetChiTietSuaChuaLon(int maChiTiet)
        {
            return (ChiTietSuaChuaLon)DataPortal.Fetch<ChiTietSuaChuaLon>(new Criteria(maChiTiet));
        }

        internal static ChiTietSuaChuaLon GetChiTietSuaChuaLon(SafeDataReader dr)
        {
            return new ChiTietSuaChuaLon(dr);
        }

        public static void DeleteChiTietSuaChuaLon(int maChiTiet)
        {
            DataPortal.Delete(new Criteria(maChiTiet));
        }

        #endregion

        #region Data Access



        protected override void DataPortal_Fetch(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadChiTietSuaChuaLon";
                    cm.Parameters.AddWithValue("@MaChiTietSuaChua", crit.MaChiTietSuaChuaLon);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            _MaChiTiet = dr.GetInt32("MaChiTietBoPhanSuaChua");
                            _TenBoPhan = dr.GetString("TenBoPhan");
                            _NoiDung = dr.GetString("NoiDung");
                            _GiaDuToan = dr.GetDecimal("GiaDuToan");
                            _GiaThucTe = dr.GetDecimal("GiaThucTe");
                            _KetQua = dr.GetString("KetQuaKiemTra");

                            _MaChiTietQuanLy = dr.GetString("MaChiTietQuanLy");
                            _idSet = true;
                            // load child objects
                            dr.NextResult();
                        }
                    }
                }
                MarkOld();
            }
        }



        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_ChiTietBoPhanSuaChua";
                        cm.Parameters.AddWithValue("@MaChiTietBoPhanSuaChua", _MaChiTiet);
                        cm.Parameters["@MaChiTietBoPhanSuaChua"].Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@TenBoPhan", _TenBoPhan.ToString());
                        cm.Parameters.AddWithValue("@NoiDUng", _NoiDung.ToString());
                        cm.Parameters.AddWithValue("@GiaDuToan", _GiaDuToan);
                        cm.Parameters.AddWithValue("@GiaThucTe", _GiaThucTe);
                        cm.Parameters.AddWithValue("@KetQuaKiemTra", _MaChiTiet);
                        cm.Parameters.AddWithValue("@MaChiTietQuanLy", _MaChiTietQuanLy.ToString());
                        cm.Parameters.AddWithValue("@MaNghiepVuSuaChuaLon", ((ChiTietSuaChuaLonList)this.Parent).MaSuaChuaLon);
                        cm.ExecuteNonQuery();
                        _MaChiTiet = (Int32)cm.Parameters["@MaChiTietBoPhanSuaChua"].Value;
                        _idSet = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        protected void DataPortal_InsertTranSacTion(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_ChiTietBoPhanSuaChua";
                cm.Parameters.AddWithValue("@MaChiTietBoPhanSuaChua", _MaChiTiet);
                cm.Parameters["@MaChiTietBoPhanSuaChua"].Direction = ParameterDirection.Output;
                cm.Parameters.AddWithValue("@TenBoPhan", _TenBoPhan.ToString());
                cm.Parameters.AddWithValue("@NoiDUng", _NoiDung.ToString());
                cm.Parameters.AddWithValue("@GiaDuToan", _GiaDuToan);
                cm.Parameters.AddWithValue("@GiaThucTe", _GiaThucTe);
                cm.Parameters.AddWithValue("@KetQuaKiemTra", _MaChiTiet);
                cm.Parameters.AddWithValue("@MaChiTietQuanLy", _MaChiTietQuanLy.ToString());
                cm.Parameters.AddWithValue("@MaNghiepVuSuaChuaLon", ((ChiTietSuaChuaLonList)this.Parent).MaSuaChuaLon);
                cm.ExecuteNonQuery();
                _MaChiTiet = (Int32)cm.Parameters["@MaChiTietBoPhanSuaChua"].Value;
                _idSet = true;
            }
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
                        cm.CommandText = "spd_Update_ChiTietBoPhanSuaChua";
                        cm.Parameters.AddWithValue("@MaChiTietBoPhanSuaChua ", _MaChiTiet);
                        cm.Parameters.AddWithValue("@TenBoPhan", _TenBoPhan.ToString());
                        cm.Parameters.AddWithValue("@NoiDung", _NoiDung.ToString());
                        cm.Parameters.AddWithValue("@GiaDuToan", _GiaDuToan);
                        cm.Parameters.AddWithValue("@GiaThucTe", _GiaThucTe);
                        cm.Parameters.AddWithValue("@KetQuaKiemTra", _MaChiTiet);
                        cm.Parameters.AddWithValue("@MaChiTietQuanLy", _MaChiTietQuanLy.ToString());
                        cm.Parameters.AddWithValue("@MaNghiepVuSuaChuaLon", ((ChiTietSuaChuaLonList)this.Parent).MaSuaChuaLon);
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


        protected void DataPortal_UpdateTranSacTion(SqlTransaction tr)
        {
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Update_ChiTietBoPhanSuaChua";
                    cm.Parameters.AddWithValue("@MaChiTietBoPhanSuaChua ", _MaChiTiet);
                    cm.Parameters.AddWithValue("@TenBoPhan", _TenBoPhan.ToString());
                    cm.Parameters.AddWithValue("@NoiDung", _NoiDung.ToString());
                    cm.Parameters.AddWithValue("@GiaDuToan", _GiaDuToan);
                    cm.Parameters.AddWithValue("@GiaThucTe", _GiaThucTe);
                    cm.Parameters.AddWithValue("@KetQuaKiemTra", _KetQua);
                    cm.Parameters.AddWithValue("@MaChiTietQuanLy", _MaChiTietQuanLy.ToString());
                    cm.Parameters.AddWithValue("@MaNghiepVuSuaChuaLon", ((ChiTietSuaChuaLonList)this.Parent).MaSuaChuaLon);
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

        
        protected override void DataPortal_Delete(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try

                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Delete_ChiTietBoPhanSuaChua";
                        cm.Parameters.AddWithValue("@MaChiTietBoPhanSuaChua", crit.MaChiTietSuaChuaLon);
                        cm.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaChiTiet));
        }       

        #endregion

    }
}
