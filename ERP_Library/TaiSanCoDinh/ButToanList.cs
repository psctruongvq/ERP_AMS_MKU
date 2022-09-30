
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
namespace ERP_Library
{
    public class ButToanList : BusinessListBase<ButToanList, ButToan>
    {
        public int _MaDinhKhoan;

        #region Business Methods

        // TODO: add public properties and methods

        public ButToan GetButToan(int maButToan)
        {
            foreach (ButToan bt in this)

                if (bt.MaButToan == maButToan)
                    return bt;
            return null;
        }

        public void Remove(int maButToan)
        {
            foreach (ButToan item in this)
            {
                if (item.MaButToan == maButToan)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            int maButToan = this.Count + 1;
            ButToan item = ButToan.NewButToan(maButToan);
            Add(item);
            return item;
        }
        #endregion

        private ButToanList()
        {
            MarkAsChild();
        }

        private ButToanList(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;
            while (dr.Read())
                this.Add(ButToan.GetButToan(dr));
            RaiseListChangedEvents = true;
        }

        #region Factory Methods

        public static ButToanList NewButToanList()
        {
            return new ButToanList();
        }

        public static ButToanList GetButToanList()
        {
            return DataPortal.Fetch<ButToanList>(new Criteria());
        }

        public static ButToanList LayButToanList(int maTaiKhoanCo, int maChuongTrinh)
        {
            return DataPortal.Fetch<ButToanList>(new CriteriaLayButToan(maTaiKhoanCo, maChuongTrinh));
        }
        public static ButToanList LayButToanInKetChuyenChungTuList()
        {
            return DataPortal.Fetch<ButToanList>(new CriteriaLayButToanInKetChuyenChungTu());
        }
        public static ButToanList GetButToanList_DinhKhoan(int MaDinhKhoan)
        {
            return DataPortal.Fetch<ButToanList>(new Criteria_DinhKhoan(MaDinhKhoan));
        }

        public static ButToanList GetButToanList_DinhKhoan_New(int MaDinhKhoan, bool ghiMucNganSach)
        {
            return DataPortal.Fetch<ButToanList>(new Criteria_DinhKhoan_New(MaDinhKhoan,ghiMucNganSach));
        }
        // chi lay but toan khong lay cac chi tiet con khac
        public static ButToanList GetButToanList_DinhKhoanByLoc(int MaDinhKhoan)
        {
            return DataPortal.Fetch<ButToanList>(new Criteria_DinhKhoanByLoc(MaDinhKhoan));
        }

        public static ButToanList GetButToanList(SafeDataReader dr)
        {
            return new ButToanList(dr);
        }
        public static ButToanList GetButToanListByThuQuy(DateTime tuNgay, DateTime denNgay, string NoTK, string CoTK, string maBoPhan)
        {
            return DataPortal.Fetch<ButToanList>(new CriteriaByThuQuy(tuNgay, denNgay, NoTK, CoTK, maBoPhan));
        }

        #endregion

        #region Data Access

        [Serializable()]
        private class Criteria
        {
            //hong làm gì hêt
        }
        private class CriteriaLayButToanInKetChuyenChungTu
        {
            //hong làm gì hêt
        }
        private class CriteriaLayButToan
        {
            public int _maTaiKhoanCo;
            public int _maChuongTrinh;

            public CriteriaLayButToan(int maTaiKhoanCo, int maChuongTrinh)
            {
                _maTaiKhoanCo = maTaiKhoanCo;
                _maChuongTrinh = maChuongTrinh;
            }
        }


        private class CriteriaByThuQuy
        {
            public DateTime tuNgay;
            public DateTime denNgay;
            public string NoTK;
            public string CoTK;
            public string MaBoPhan;
            public CriteriaByThuQuy(DateTime _tuNgay, DateTime _denNgay, string _noTK, string _coTK, string _maBoPhan)
            {
                this.tuNgay = _tuNgay;
                this.denNgay = _denNgay;
                this.NoTK = _noTK;
                this.CoTK = _coTK;
                this.MaBoPhan = _maBoPhan;
            }
        }
        private class Criteria_DinhKhoan
        {
            public int MaDinhKhoan;
            public Criteria_DinhKhoan(int maDinhKhoan)
            {
                this.MaDinhKhoan = maDinhKhoan;
            }
        }

      
        private class Criteria_DinhKhoan_New
        {
            public int MaDinhKhoan;
            public bool GhiMucNganSach;
            public Criteria_DinhKhoan_New(int maDinhKhoan, bool ghiMucNganSach)
            {
                this.MaDinhKhoan = maDinhKhoan;
                GhiMucNganSach = ghiMucNganSach;
            }
        }

        private class Criteria_DinhKhoanByLoc
        {
            public int MaDinhKhoan;
            public Criteria_DinhKhoanByLoc(int maDinhKhoan)
            {
                this.MaDinhKhoan = maDinhKhoan;
            }
        }

        protected override void DataPortal_Fetch(object criteria)
        {
            this.RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                if (criteria is Criteria)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        //cm.CommandType = CommandType.Text;
                        //cm.CommandText = "select *from v_ButToanTaiKhoan order by MaDinhKhoan asc";
                         cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblDinhKhoanAll_Modify";
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(ButToan.GetButToan(dr));
                            }
                        }
                    }
                }
                else if (criteria is Criteria_DinhKhoan)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        //cm.CommandType = CommandType.Text;
                        //cm.CommandText = "select *from v_ButToanTaiKhoan where MaDinhKhoan = " + ((Criteria_DinhKhoan)criteria).MaDinhKhoan + " order by MaDinhKhoan asc ";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblDinhKhoan_Modify";
                        cm.Parameters.AddWithValue("@MaDinhKhoan", ((Criteria_DinhKhoan)criteria).MaDinhKhoan);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(ButToan.GetButToan(dr));
                            }
                        }
                    }
                }
                else if (criteria is Criteria_DinhKhoan_New)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        //cm.CommandType = CommandType.Text;
                        //cm.CommandText = "select *from v_ButToanTaiKhoan where MaDinhKhoan = " + ((Criteria_DinhKhoan_New)criteria).MaDinhKhoan + " order by MaDinhKhoan asc ";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblDinhKhoan_Modify";
                        cm.Parameters.AddWithValue("@MaDinhKhoan", ((Criteria_DinhKhoan_New)criteria).MaDinhKhoan);
                        bool ghiMucNganSach = ((Criteria_DinhKhoan_New)criteria).GhiMucNganSach;
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(ButToan.GetButToan_New(dr,ghiMucNganSach));
                            }
                        }
                    }
                }
                else if (criteria is Criteria_DinhKhoanByLoc)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        //cm.CommandType = CommandType.Text;
                        //cm.CommandText = "select *from v_ButToanTaiKhoan where MaDinhKhoan = " + ((Criteria_DinhKhoanByLoc)criteria).MaDinhKhoan + " order by MaDinhKhoan asc ";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblDinhKhoan_Modify";
                        cm.Parameters.AddWithValue("@MaDinhKhoan", ((Criteria_DinhKhoanByLoc)criteria).MaDinhKhoan);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(ButToan.GetButToanByLoc(dr, true));
                            }
                        }
                    }
                }
                else if (criteria is CriteriaByThuQuy)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "SelecttblButToan_SoQuy";
                        cm.CommandTimeout = 240;
                        cm.Parameters.AddWithValue("@TuNgay", ((CriteriaByThuQuy)criteria).tuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", ((CriteriaByThuQuy)criteria).denNgay);
                        cm.Parameters.AddWithValue("@NoTK", ((CriteriaByThuQuy)criteria).NoTK);
                        cm.Parameters.AddWithValue("@CoTK", ((CriteriaByThuQuy)criteria).CoTK);
                        cm.Parameters.AddWithValue("@MaBoPhan", ((CriteriaByThuQuy)criteria).MaBoPhan);
                        cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(ButToan.GetButToanBySoQuy(dr));
                            }
                        }
                    }
                }
                else if (criteria is CriteriaLayButToan)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandTimeout = 240;
                        cm.CommandText = "spd_LayButToanByKetChuyenChungTuTam";
                        cm.Parameters.Add("@MaTaiKhoanCo",((CriteriaLayButToan)criteria)._maTaiKhoanCo);
                        cm.Parameters.Add("@MaChuongTrinh", ((CriteriaLayButToan)criteria)._maChuongTrinh);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(ButToan.GetButToan(dr,1));
                            }
                        }
                    }
                }
                else if (criteria is CriteriaLayButToanInKetChuyenChungTu)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandTimeout = 240;
                        cm.CommandText = "spd_LayButToanInKetChuyenChungTuTam";

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(ButToan.GetButToan(dr,2));
                            }
                        }
                    }
                }
            }
            this.RaiseListChangedEvents = true;
        }



        public void DataPortal_Update(SqlTransaction tr)
        {
            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (ButToan obj in DeletedList)
                obj.DeleteSelf(tr);
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (ButToan obj in this)
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
        public void Dataportal_Delete(SqlTransaction tr)
        {
            foreach (ButToan obj in this)
                obj.DeleteSelf(tr);
        }

        #endregion

    }
}
