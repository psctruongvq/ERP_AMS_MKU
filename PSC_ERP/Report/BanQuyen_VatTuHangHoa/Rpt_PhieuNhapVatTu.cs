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
    public partial class Rpt_PhieuNhapVatTu : DevExpress.XtraReports.UI.XtraReport
    {
        long _maPhieuNhap;
        DateTime _ngayLap;
        int _sTT;
        decimal _sumTongTien;
        #region tao dataset cho report
            private DataSet DataSet_PhieuNhapVatTu()
            {
                DataSet ds = new DataSet();
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    //tao bang_PhieuXuatBQVT 
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "Spd_PhieuNhapVatTu";
                        cm.Parameters.AddWithValue("@MaPhieuNhap", _maPhieuNhap);
                        cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dt.TableName = "Spd_PhieuNhapBQVT;1";
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

        public Rpt_PhieuNhapVatTu()
        {
            InitializeComponent();
        }
        //
        public Rpt_PhieuNhapVatTu(long MaPhieuNhap, DateTime NgayLap)
        {
            InitializeComponent();
            _maPhieuNhap = MaPhieuNhap;
            _ngayLap = NgayLap;
            this.DataSource = DataSet_PhieuNhapVatTu();
            BindData();
        }

        #region BindData de hien thi du lieu len cac Cell
        public void BindData()
        {
            colNgayLap.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.NgayNhap");
            colSoPhieuPN.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.SoPhieuPN");
            colTaiKhoanNo.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.TaiKhoanNo");
            colTaiKhoanCo.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.TaiKhoanCo");
            //
            colTenNguoiGiao.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.TenNguoiGiao");
            colSoHoaDon.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.SoHoaDon");
            colTenDoiTac_DChi.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.TenDoiTac_Dchi");
            colTenKho.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.TenKho");
            //
            colMaVatTu.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.MaVatTu");
            colTenChuongTrinh.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.TenChuongTrinh");
            colDvt.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.DVT");
            colSLg.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.SoLuong");
            colDonGia.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.DonGia");
            colThanhTien.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.ThanhTien");

            colNgayNhap_PaperFooter.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.NgayNhap");
            //
            colTenCTy.DataBindings.Add("Text", DataSource, "spd_REPORT_ReportHeader;1.TenCongTy");
            colTenBoPhan.DataBindings.Add("Text", DataSource, "Spd_PhieuNhapBQVT;1.TenBoPhan");
    
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
            _sumTongTien += decimal.Parse(colThanhTien.Text);
        }

        

        private void TopMargin_AfterPrint(object sender, EventArgs e)
        {
            colNgayLap.Text = "(" + colNgayLap.Text + ")";
        }


    }
}
