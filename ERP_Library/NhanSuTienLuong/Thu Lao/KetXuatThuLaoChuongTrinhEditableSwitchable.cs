
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class KetXuatThuLaoChuongTrinh
    {
        #region Business Properties and Methods

        //declare members
        //MaQLChuongTrinh, TenChuongTrinh, SoTien, TienThue, TienSauThue, DienGiai, NguoiLap, NgayNhap
       


        #endregion //Business Properties and Methods



        #region Factory Methods

        public static DataTable GetKetXuatThuLaoChuongTrinh(int maChuongTrinh, string dienGiai, int loaiThuLao)
        {
            //
            DataTable kqTbl =new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                // @TuNgay datatime, @DenNgay datatime, @MaBoPhan int, @ChuongTrinh int, @DienGiai nvarchar(max)
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "KetXuatThuLaoChuongTrinh";
                    cm.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    if (dienGiai.Length > 0)
                        cm.Parameters.AddWithValue("@DienGiai", dienGiai);
                    else
                        cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
                    cm.Parameters.AddWithValue("@LoaiThuLao", loaiThuLao);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0)
                            kqTbl = ds.Tables[0];
                    }
                }
            }//us
            return kqTbl;
        }

        public static DataTable GetKetXuatThuLaoChuongTrinhTheoNgay(DateTime tuNgay, DateTime denNgay, int maChuongTrinh, string dienGiai, int loaiThuLao)
        {
            //
            DataTable kqTbl = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                // @TuNgay datatime, @DenNgay datatime, @MaBoPhan int, @ChuongTrinh int, @DienGiai nvarchar(max)
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "KetXuatThuLaoChuongTrinhTheoNgay";
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    if (dienGiai.Length > 0)
                        cm.Parameters.AddWithValue("@DienGiai", dienGiai);
                    else
                        cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
                    cm.Parameters.AddWithValue("@LoaiThuLao", loaiThuLao);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds != null && ds.Tables.Count > 0)
                            kqTbl = ds.Tables[0];
                    }
                }
            }//us
            return kqTbl;
        }



        public static DataTable GetKetXuatThuLaoChuongTrinh_ChiTiet(int maChuongTrinh, string dienGiai, int loaiThuLao)
        {
            //
            DataTable kqTbl = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                // @TuNgay datatime, @DenNgay datatime, @MaBoPhan int, @ChuongTrinh int, @DienGiai nvarchar(max)
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "KetXuatThuLaoChuongTrinh_ChiTiet";
                    cm.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    if (dienGiai.Length > 0)
                        cm.Parameters.AddWithValue("@DienGiai", dienGiai);
                    else
                        cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
                    cm.Parameters.AddWithValue("@LoaiThuLao", loaiThuLao);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0)
                            kqTbl = ds.Tables[0];
                    }
                }
            }//us
            return kqTbl;
        }

        public static DataTable GetKetXuatThuLaoChuongTrinhTheoNgay_ChiTiet(DateTime tuNgay, DateTime denNgay, int maChuongTrinh, string dienGiai, int loaiThuLao)
        {
            //
            DataTable kqTbl = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                // @TuNgay datatime, @DenNgay datatime, @MaBoPhan int, @ChuongTrinh int, @DienGiai nvarchar(max)
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "KetXuatThuLaoChuongTrinhTheoNgay_ChiTiet";
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    if (dienGiai.Length > 0)
                        cm.Parameters.AddWithValue("@DienGiai", dienGiai);
                    else
                        cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
                    cm.Parameters.AddWithValue("@LoaiThuLao", loaiThuLao);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds != null && ds.Tables.Count > 0)
                            kqTbl = ds.Tables[0];
                    }
                }
            }//us
            return kqTbl;
        }

        public static DataTable TableKetXuatThuLaoChuongTrinh()
        {
            DataTable kqTbl = new DataTable();
            //MaChuongTrinh,MaQL, TenChuongTrinh, SoTien, TienThue, TienSauThue, DienGiai, NguoiLap,TenNguoiLap, NgayNhap
            kqTbl.Columns.Add("MaChuongTrinh", typeof(int));
            kqTbl.Columns.Add("MaQL", typeof(string));
            kqTbl.Columns.Add("TenChuongTrinh", typeof(string));
            kqTbl.Columns.Add("SoTien", typeof(decimal));
            kqTbl.Columns.Add("TienThue", typeof(decimal));
            kqTbl.Columns.Add("TienSauThue", typeof(decimal));
            //kqTbl.Columns.Add("DienGiai", typeof(string));
            //kqTbl.Columns.Add("NguoiLap", typeof(int));
            //kqTbl.Columns.Add("TenNguoiLap", typeof(string));
            //kqTbl.Columns.Add("NgayNhap", typeof(DateTime));
            return kqTbl;
        }
        public static DataTable TableKetXuatThuLaoChuongTrinh_ChiTiet()
        {
            DataTable kqTbl = new DataTable();
            //MaChuongTrinh,MaQL, TenChuongTrinh, SoTien, TienThue, TienSauThue, DienGiai, NguoiLap,TenNguoiLap, NgayNhap
            kqTbl.Columns.Add("MaChuongTrinh", typeof(int));
            kqTbl.Columns.Add("MaQL", typeof(string));
            kqTbl.Columns.Add("TenChuongTrinh", typeof(string));
            kqTbl.Columns.Add("SoTien", typeof(decimal));
            kqTbl.Columns.Add("TienThue", typeof(decimal));
            kqTbl.Columns.Add("TienSauThue", typeof(decimal));
            kqTbl.Columns.Add("DienGiai", typeof(string));
            kqTbl.Columns.Add("NguoiLap", typeof(int));
            kqTbl.Columns.Add("TenNguoiLap", typeof(string));
            kqTbl.Columns.Add("MaNhanVien", typeof(long));
            kqTbl.Columns.Add("TenNhanVien", typeof(string));
            kqTbl.Columns.Add("NgayNhap", typeof(DateTime));
            return kqTbl;
        }

        #region Table Return

        #endregion//Table Return

        #endregion //Factory Methods

    }
}
