using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ERP_Library;
namespace PSC_ERP
{
    public partial class Rpt_PhieuXuatBanQuyen : DevExpress.XtraReports.UI.XtraReport
    {
        long _maPhieuXuat;
        DateTime _ngayLap;
        int _sTT;
        #region Tao DataSet cho Phieu In
            private DataSet DataSet_PhieuXuatBanQuyen()
            {
                DataSet ds = new DataSet();
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    //tao bang_PhieuXuatBQVT 
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "Spd_PhieuXuatBanQuyen ";
                        cm.Parameters.AddWithValue("@MaPhieuXuat", _maPhieuXuat);
                        cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dt.TableName = "Spd_PhieuXuatBQVT;1";
                        ds.Tables.Add(dt);
                    }
                    //tao bang_REPORT_ReportHeader 
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_REPORT_ReportHeader";
                        cm.Parameters.AddWithValue("@MaCongTy", 1);
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dt.TableName = "spd_REPORT_ReportHeader;1";
                        ds.Tables.Add(dt);
                    }
                    //Tao Bang Chua [chuoi ngay Phat song] va [chuoi doi tac]
                    string _chuoiNgayPS = "";
                    string _chuoiDoiTac = "";
                    int i = 1;
                    foreach (DataRow dr in ds.Tables["Spd_PhieuXuatBQVT;1"].Rows)
                    {
                        //Dieu kien cho Chuoi ten Doi Tac
                        if (i < ds.Tables["Spd_PhieuXuatBQVT;1"].Rows.Count)
                        {
                            if(dr["TenDoiTac"].ToString().Trim()=="") 
                                {
                                    //
                                    _chuoiDoiTac += dr["TenDoiTac"].ToString() + "; ";
                                    //
                                }
                            _chuoiNgayPS += dr["NgayPhatSong"].ToString() + "; ";
                            i++;
                        }
                        else
                        {
                            _chuoiNgayPS += dr["NgayPhatSong"].ToString();
                            _chuoiDoiTac += dr["TenDoiTac"].ToString();
                        }
                        //END Dieu kien cho Chuoi ten Doi Tac

                        
                    }
                    DataTable dt1 = new DataTable("tblLuuTru");
                    dt1.Columns.Add("ChuoiNgayPS", typeof(string));
                    dt1.Columns.Add("ChuoiDoiTac", typeof(string));
                    DataRow dr1 = dt1.NewRow();//tao dong dua du lieu vao
                    dr1["ChuoiNgayPS"] = _chuoiNgayPS;
                    dr1["ChuoiDoiTac"] = _chuoiDoiTac;
                    dt1.Rows.Add(dr1);
                    ds.Tables.Add(dt1);//Add tblLuuTru vao
                    //End Tao Bang Chua [chuoi ngay Phat song] va [chuoi doi tac]
                }//us
                return ds;
            }
        #endregion//END Tao DataSet cho Phieu In


        public Rpt_PhieuXuatBanQuyen()
        {
            InitializeComponent();
        }
        //
        public Rpt_PhieuXuatBanQuyen(long MaPhieuXuat, DateTime NgayLap)
        {
            InitializeComponent();
            _maPhieuXuat = MaPhieuXuat;
            _ngayLap = NgayLap;
            this.DataSource = DataSet_PhieuXuatBanQuyen();
            BindData();
        }
        #region BindData de hien thi du lieu len cac Cell
        public void BindData()
        {
            colSoPhieuPX.DataBindings.Add("Text", DataSource, "Spd_PhieuXuatBQVT;1.SoPhieuPX");
            colSoPhieuPN.DataBindings.Add("Text", DataSource, "Spd_PhieuXuatBQVT;1.SoPhieuPN");
            colTenChuongTrinh.DataBindings.Add("Text", DataSource, "Spd_PhieuXuatBQVT;1.TenChuongTrinh");
            colDvt.DataBindings.Add("Text", DataSource, "Spd_PhieuXuatBQVT;1.DVT");
            colTLg.DataBindings.Add("Text", DataSource, "Spd_PhieuXuatBQVT;1.ThoiLuong");
            colDonGia.DataBindings.Add("Text", DataSource, "Spd_PhieuXuatBQVT;1.DonGia");
            colSL.DataBindings.Add("Text", DataSource, "Spd_PhieuXuatBQVT;1.SoLuong");
            colThanhTien.DataBindings.Add("Text", DataSource, "Spd_PhieuXuatBQVT;1.ThanhTien");
            //
            colTenCTy.DataBindings.Add("Text", DataSource, "spd_REPORT_ReportHeader;1.TenCongTy");
            colTenBoPhan.DataBindings.Add("Text", DataSource, "Spd_PhieuXuatBQVT;1.TenBoPhan");
            colChuoiTenDoiTac.DataBindings.Add("Text", DataSource, "tblLuuTru.ChuoiDoiTac");
            colChuoiNgayPS.DataBindings.Add("Text", DataSource, "tblLuuTru.ChuoiNgayPS");


        }
        #endregion//END BindData

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _sTT++;
            colSTT.Text = _sTT.ToString();
        }

    }
}
