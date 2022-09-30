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
    public partial class Rpt_BienBanGiaoNhanCongCuDungCu : DevExpress.XtraReports.UI.XtraReport
    {
        long _maPhieuNhapXuat;
        int _maPhongBan;
        //
        int _sTT;
        decimal _sumTongTien;
        #region tao dataset cho report
            private DataSet DataSet_BienBanGiaoNhanCongCuDungCu()
            {
                DataSet ds = new DataSet();
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    //tao bang_PhieuXuatBQVT 
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "Spd_BienBanGiaoNhanCongCuDungCu";
                        cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
                        cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dt.TableName = "Spd_BienBanGiaoNhanCongCuDungCu;1";
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
                }//us
                return ds;
            }
        #endregion//END tao dataset cho report
        //
        public Rpt_BienBanGiaoNhanCongCuDungCu()
        {
            InitializeComponent();

        }
        //
        public Rpt_BienBanGiaoNhanCongCuDungCu(long MaPhieuNhapXuat, int MaPhongBan)
        {
            InitializeComponent();
            _maPhieuNhapXuat = MaPhieuNhapXuat;
            _maPhongBan = MaPhongBan;
            this.DataSource = DataSet_BienBanGiaoNhanCongCuDungCu();
            BindData();
            
            
        }
        #region BindData de hien thi du lieu len cac Cell
        public void BindData()
        {
            colNgayLap.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.NgayNhan");
            colSoPhieuNhapXuat.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.SoPhieuNhapXuat");
            colTaiKhoanNo.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.TaiKhoanNo");
            colTaiKhoanCo.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.TaiKhoanCo");
            //
            ColDiaChi.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.DiaChi");
            colSoHoaDon.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.SoHoaDon");
            colDonGia.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.NguyenGia");
            //
            colGhiChu.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.GhiChuHoaDon");
            colTenHangHoa.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.TenHangHoa");
            colNgayHoaDon.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.NgayHoaDon");
            colNguyenGia.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.NguyenGia");
            colNoiDatDe.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.ViTri");
            colNuocSanXuat.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.NuocSanXuat");
            colNgayThangSD.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.NgayNhan");
            colSoLgSD.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.SoLuongSD");

            colSoSerial.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.SoSerial");
            //
            colTenCTy.DataBindings.Add("Text", DataSource, "spd_REPORT_ReportHeader;1.TenCongTy");
            colDiaChi1.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.DiaChi");
            colBoPhan_Cty.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.TenBoPhan");
            colBoPhan.DataBindings.Add("Text", DataSource, "Spd_BienBanGiaoNhanCongCuDungCu;1.TenBoPhan");
        }
        #endregion//END BindData

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _sTT++;
            colSTT.Text = _sTT.ToString();

        }


        private void GroupFooter1_AfterPrint(object sender, EventArgs e)
        {
            colDocTien.Text ="Tổng số tiền (viết bằng chữ): ("+ HamDungChung.DocTien(_sumTongTien)+"./.)";
        }

        private void Detail_AfterPrint(object sender, EventArgs e)
        {
            _sumTongTien += decimal.Parse(colNguyenGia.Text);
        }

    }
}
