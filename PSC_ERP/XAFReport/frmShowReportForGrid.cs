using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;

//2018.08.03
namespace PSC_ERP
{
    public partial class frmShowReportForGrid : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        string strTenPhuongThuc;
        DataSet dsReport;

        private void DesignGridView()
        {
            #region Design Gridview


            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

            //        ,NULL AS PhanTramPhiPOS
            //,NULL AS TienPOSHoaDon
            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "MaQLDoiTuong", "TenDoiTuong", "SoHieuTK", "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" },
                                new string[] { "Mã đối tượng", "Tên đối tượng", "TK công nợ", "Nợ đầu kỳ", "Có đầu kỳ", "Nợ phát sinh", "Có phát sinh", "Nợ cuối kỳ", "Có cuối kỳ" },
                                             new int[] { 100, 200, 80, 120, 120, 120, 120, 120, 120 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaQLDoiTuong", "TenDoiTuong", "SoHieuTK", "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" }, "{0:#,###.#}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "MaQLDoiTuong", "TenDoiTuong", "SoHieuTK", "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" });

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design Gridview

        }

        private void DesignGridView_BangKeThuPhiHocSinh()
        {
            #region Design Gridview


            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

            //        ,NULL AS PhanTramPhiPOS
            //,NULL AS TienPOSHoaDon
            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "MaQLDoiTuong", "TenDoiTuong", "SoPhaiThu", "SoDaThu_ChuaHoaDon", "SoDaThu_CoHoaDon", "SoGiamDoanhThu", "SoDaHoanPhi", "SoConLai" },
                                new string[] { "Mã đối tượng", "Tên đối tượng", "Số phải thu", "Đã thu - chưa HĐơn", "Đã thu - có HĐơn", "Giảm doanh thu", "Số đã hoàn", "Còn lại phải thu" },
                                             new int[] { 100, 200, 120, 120, 120, 120, 120, 120 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaQLDoiTuong", "TenDoiTuong", "SoPhaiThu", "SoDaThu_ChuaHoaDon", "SoDaThu_CoHoaDon", "SoGiamDoanhThu", "SoDaHoanPhi", "SoConLai" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoPhaiThu", "SoDaThu_ChuaHoaDon", "SoDaThu_CoHoaDon", "SoGiamDoanhThu", "SoDaHoanPhi", "SoConLai" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoPhaiThu", "SoDaThu_ChuaHoaDon", "SoDaThu_CoHoaDon", "SoGiamDoanhThu", "SoDaHoanPhi", "SoConLai" }, "{0:#,###.#}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "MaQLDoiTuong", "TenDoiTuong", "SoPhaiThu", "SoDaThu_ChuaHoaDon", "SoDaThu_CoHoaDon", "SoGiamDoanhThu", "SoDaHoanPhi", "SoConLai" });

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design Gridview

        }
        private void DesignGridView_BangKeDoanhThuChuaThucHien()
        {
            #region Design Gridview


            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

            //        ,NULL AS PhanTramPhiPOS
            //,NULL AS TienPOSHoaDon
            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "MaQLDoiTuong", "TenDoiTuong", "DoanhThuChuaThucHien", "GhiTangTrongKy", "DoanhThuDaThucHien", "SoConLai" },
                                new string[] { "Mã đối tượng", "Tên đối tượng", "Doanh thu chưa thực hiện", "Ghi tăng trong kỳ", "Doanh thu đã thực hiện", "Số còn lại" },
                                             new int[] { 100, 200, 120, 120, 120, 120 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaQLDoiTuong", "TenDoiTuong", "DoanhThuChuaThucHien", "GhiTangTrongKy", "DoanhThuDaThucHien", "SoConLai" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "DoanhThuChuaThucHien", "GhiTangTrongKy", "DoanhThuDaThucHien", "SoConLai" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "DoanhThuChuaThucHien", "GhiTangTrongKy", "DoanhThuDaThucHien", "SoConLai" }, "{0:#,###.#}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "MaQLDoiTuong", "TenDoiTuong", "DoanhThuChuaThucHien", "GhiTangTrongKy", "DoanhThuDaThucHien", "SoConLai" });

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design Gridview

        }
        private void DesignGridView_SoTongHopBanHang()
        {
            #region Design Gridview


            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

            //        ,NULL AS PhanTramPhiPOS
            //,NULL AS TienPOSHoaDon
            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "MaQLDoiTuong", "TenDoiTuong", "DoanhSo", "HangBanBiTraLai", "ChietKhau", "GiamGiaHangBan", "DoanhThuThuan" },
                                new string[] { "Mã đối tượng", "Tên đối tượng", "Doanh số bán", "Hàng bán bị trả lại", "Chiết khấu", "Giảm giá", "Doanh thu thuần" },
                                             new int[] { 100, 200, 120, 120, 120, 120, 120 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaQLDoiTuong", "TenDoiTuong", "DoanhSo", "HangBanBiTraLai", "ChietKhau", "GiamGiaHangBan", "DoanhThuThuan" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "DoanhSo", "HangBanBiTraLai", "ChietKhau", "GiamGiaHangBan", "DoanhThuThuan" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "DoanhSo", "HangBanBiTraLai", "ChietKhau", "GiamGiaHangBan", "DoanhThuThuan" }, "{0:#,###.#}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "MaQLDoiTuong", "TenDoiTuong", "DoanhSo", "HangBanBiTraLai", "ChietKhau", "GiamGiaHangBan", "DoanhThuThuan" });

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design Gridview

        }

        private void DesignGridView_BangCanDoiPhatSinh()
        {
            #region Design Gridview


            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

            //        ,NULL AS PhanTramPhiPOS
            //,NULL AS TienPOSHoaDon
            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "SoHieuTK_TrinhBay", "TenTaiKhoan", "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" },
                                new string[] { "Tài khoản", "Tên tài khoản", "Nợ đầu kỳ", "Có đầu kỳ", "Nợ phát sinh", "Có phát sinh", "Nợ cuối kỳ", "Có cuối kỳ" },
                                             new int[] { 100, 200, 120, 120, 120, 120, 120, 120 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoHieuTK_TrinhBay", "TenTaiKhoan", "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" }, "#,###.#");
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" }, "{0:#,###.#}");
            this.ShowSummaryCustomFooterGridView(gridView1, new string[] { "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" }, "{0:#,###.#}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoHieuTK_TrinhBay", "TenTaiKhoan", "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" });

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design Gridview

        }

        private void DesignGridView_BangTongHopPhatSinhTaiKhoan()
        {
            #region Design Gridview


            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

            //        ,NULL AS PhanTramPhiPOS
            //,NULL AS TienPOSHoaDon
            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "SoHieuTKDoiUng", "DienGiai", "NoPhatSinh", "CoPhatSinh"},
                                new string[] { "TK đối ứng", "Tên TK đối ứng",  "Nợ phát sinh", "Có phát sinh" },
                                             new int[] { 100, 200, 120, 120}, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoHieuTKDoiUng", "DienGiai", "NoPhatSinh", "CoPhatSinh" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "NoPhatSinh", "CoPhatSinh" }, "#,###.#");
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" }, "{0:#,###.#}");
            //this.ShowSummaryCustomFooterGridView(gridView1, new string[] { "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" }, "{0:#,###.#}");
            //HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoHieuTK_TrinhBay", "TenTaiKhoan", "SoDuDauKyNo", "SoDuDauKyCo", "SoPhatSinhNo", "SoPhatSinhCo", "SoDuCuoiKyNo", "SoDuCuoiKyCo" });

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design Gridview

        }

        public void ShowSummaryCustomFooterGridView(DevExpress.XtraGrid.Views.Grid.GridView grid, string[] fieldName, string S_format)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, fieldName[i], S_format)});
            }
        }

        public frmShowReportForGrid(string tenPhuongThuc, DataSet ds)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            strTenPhuongThuc = tenPhuongThuc;
            dsReport = ds;

        }


        #endregion Events

        #region event FormLoad
        private void frmShowReportForGrid_Load(object sender, EventArgs e)
        {
            if (this.strTenPhuongThuc == "Method_BangTongHopCongNoDoiDoiTuong")
            {
                DesignGridView();
                gridControl1.DataSource = dsReport.Tables[0];
            }
            else if (this.strTenPhuongThuc == "Method_BangKeThuPhiHocSinh")
            {
                DesignGridView_BangKeThuPhiHocSinh();
                gridControl1.DataSource = dsReport.Tables[0];
            }
            else if (this.strTenPhuongThuc == "Method_SoTongHopBanHang")
            {
                DesignGridView_SoTongHopBanHang();
                gridControl1.DataSource = dsReport.Tables[0];
            }
            else if (this.strTenPhuongThuc == "Method_BangKeDoanhThuChuaThucHien")
            {
                DesignGridView_BangKeDoanhThuChuaThucHien();
                gridControl1.DataSource = dsReport.Tables[0];
            }
            else if (this.strTenPhuongThuc == "Method_BangCanDoiPhatSinh")
            {
                this.TinhTong_CanDoiPhatSinh();
                DesignGridView_BangCanDoiPhatSinh();
                gridControl1.DataSource = dsReport.Tables[0];
            }
            else if (this.strTenPhuongThuc == "Method_BangTongHopPhatSinhTaiKhoan")
            {               
                DesignGridView_BangTongHopPhatSinhTaiKhoan();
                gridControl1.DataSource = dsReport.Tables[0];
            }
        }
        #endregion

        #region sum theo dieu kien - bao cao BangCanDoiPhatSinh
        decimal SumNoDauKy = 0, SumCoDauKy = 0, SumNoPhatSinh = 0, SumCoPhatSinh = 0, SumNoCuoiKy = 0, SumCoCuoiKy = 0;
        private void TinhTong_CanDoiPhatSinh()
        {
            DataTable dt = dsReport.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["KieuIn"] + "" == "1")
                {
                    SumNoDauKy = SumNoDauKy + (decimal)dr["SoDuDauKyNo"];
                    SumCoDauKy = SumCoDauKy + (decimal)dr["SoDuDauKyCo"];
                    SumNoPhatSinh = SumNoPhatSinh + (decimal)dr["SoPhatSinhNo"];
                    SumCoPhatSinh = SumCoPhatSinh + (decimal)dr["SoPhatSinhCo"];
                    SumNoCuoiKy = SumNoCuoiKy + (decimal)dr["SoDuCuoiKyNo"];
                    SumCoCuoiKy = SumCoCuoiKy + (decimal)dr["SoDuCuoiKyCo"];
                }
            }
        }
        #endregion

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                DataRowView drv = (DataRowView)gridView1.GetFocusedRow();
                if (strTenPhuongThuc == "Method_BangTongHopCongNoDoiDoiTuong")
                {
                    IDReport_SoChiTietTaiKhoanTheoDoiTuongNew(drv);
                }
                else if (strTenPhuongThuc == "Method_BangKeThuPhiHocSinh")
                {
                    IDReport_BangKeThuPhiHocSinh(drv);
                }
                else if (strTenPhuongThuc == "Method_BangKeDoanhThuChuaThucHien")
                {
                    IDReport_SoChiTietTaiKhoanTheoDoiTuongNew(drv);
                }
                else if (strTenPhuongThuc == "Method_BangCanDoiPhatSinh")
                {
                    int maTaiKhoan = (int)drv["MaTaiKhoan"];
                    HeThongTaiKhoan1 objTK = HeThongTaiKhoan1.GetHeThongTaiKhoan1(maTaiKhoan);

                    if (objTK.CoDoiTuongTheoDoi == true)
                    {
                        Method_BangTongHopCongNoDoiDoiTuong(drv);
                    }
                    else
                    {
                        IDReport_SoChiTietTaiKhoan(drv);
                    }
                }
            }
        }

        private void IDReport_SoChiTietTaiKhoanTheoDoiTuongNew(DataRowView drv)
        {
            DateTime tuNgay = (DateTime)drv["TuNgay"];
            DateTime denNgay = (DateTime)drv["DenNgay"];
            int maTaiKhoan = (int)drv["MaTaiKhoan"];
            int userID = (int)drv["UserID"];
            int maBoPhan = (int)drv["MaBoPhan"];
            long maDoiTuong = 0;
            if (drv["MaDoiTuong"] != DBNull.Value)
            {
                maDoiTuong = (long)drv["MaDoiTuong"];
            }
            string soHieuTK = drv["SoHieuTK"] + "";
            string tenTaiKhoan = drv["TenTaiKhoan"] + "";
            string tenDoiTuong = drv["TenDoiTuong"] + "";

            DataSet dsMain = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spRpt_ChiTietTaiKhoanTheoDoiTuong";
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", maDoiTuong);
                    cm.Parameters.AddWithValue("@UserID", userID);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dsMain.Tables.Add(dt);
                }

                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", userID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dsMain.Tables.Add(dt);
                }

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                dtngay.Columns.Add("TenLoaiTien", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = tuNgay;
                dr["DenNgay"] = denNgay;
                dr["SoHieuTK"] = soHieuTK;
                dr["TenTaiKhoan"] = tenTaiKhoan;
                dr["TenDoiTuong"] = tenDoiTuong;
                dr["TenLoaiTien"] = "VND";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dsMain.Tables.Add(dtngay);
                ERP_Library.ReportTemplate reportTemplate;

                if (soHieuTK.Contains("131") == true)
                    reportTemplate = ReportTemplate.GetReportTemplate("IDReport_ChiTietCongNoPhaiThu", userID, DateTime.Today.Date);
                else if (soHieuTK.Contains("331") == true)
                    reportTemplate = ReportTemplate.GetReportTemplate("IDReport_ChiTietCongNoPhaiTra", userID, DateTime.Today.Date);
                else
                    reportTemplate = ReportTemplate.GetReportTemplate("IDReport_SoChiTietTaiKhoanTheoDoiTuongNew", userID, DateTime.Today.Date);

                PSC_ERP.frmReport frm = new PSC_ERP.frmReport();
                frm.HienThiReport(reportTemplate, dsMain);
                frm.Show();
            }//us

        }

        private void IDReport_BangKeThuPhiHocSinh(DataRowView drv)
        {
            DateTime tuNgay = (DateTime)drv["TuNgay"];
            DateTime denNgay = (DateTime)drv["DenNgay"];
            int maTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("131");
            int userID = (int)drv["UserID"];
            int maBoPhan = (int)drv["MaBoPhan"];
            long maDoiTuong = (long)drv["MaDoiTuong"];
            string soHieuTK = "131";
            string tenTaiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(maTaiKhoan).TenTaiKhoan;
            string tenDoiTuong = drv["TenDoiTuong"] + "";

            DataSet dsMain = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spRpt_ChiTietTaiKhoanTheoDoiTuong";
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", maDoiTuong);
                    cm.Parameters.AddWithValue("@UserID", userID);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dsMain.Tables.Add(dt);
                }

                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", userID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dsMain.Tables.Add(dt);
                }

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                dtngay.Columns.Add("TenLoaiTien", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = tuNgay;
                dr["DenNgay"] = denNgay;
                dr["SoHieuTK"] = soHieuTK;
                dr["TenTaiKhoan"] = tenTaiKhoan;
                dr["TenDoiTuong"] = tenDoiTuong;
                dr["TenLoaiTien"] = "VND";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dsMain.Tables.Add(dtngay);
                ERP_Library.ReportTemplate reportTemplate;

                reportTemplate = ReportTemplate.GetReportTemplate("IDReport_ChiTietCongNoPhaiThu", userID, DateTime.Today.Date);

                PSC_ERP.frmReport frm = new PSC_ERP.frmReport();
                frm.HienThiReport(reportTemplate, dsMain);
                frm.Show();
            }//us

        }

        private void IDReport_SoChiTietTaiKhoan(DataRowView drv)
        {
            DateTime tuNgay = (DateTime)drv["TuNgay"];
            DateTime denNgay = (DateTime)drv["DenNgay"];
            int maTaiKhoan = (int)drv["MaTaiKhoan"];
            int userID = (int)drv["UserID"];
            int maBoPhan = 0;
            long maDoiTuong = 0;
            string soHieuTK = drv["SoHieuTK"] + "";
            string tenTaiKhoan = drv["TenTaiKhoan"] + "";
            string tenDoiTuong = "";

            DataSet dsMain = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spRpt_SoChiTietTaiKhoan";
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", maDoiTuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@UserID", userID);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dsMain.Tables.Add(dt);
                }

                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", userID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dsMain.Tables.Add(dt);
                }

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                dtngay.Columns.Add("TenLoaiTien", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = tuNgay;
                dr["DenNgay"] = denNgay;
                dr["SoHieuTK"] = soHieuTK;
                dr["TenTaiKhoan"] = tenTaiKhoan;
                dr["TenDoiTuong"] = tenDoiTuong;
                dr["TenLoaiTien"] = "VND";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dsMain.Tables.Add(dtngay);
                ERP_Library.ReportTemplate reportTemplate;

                reportTemplate = ReportTemplate.GetReportTemplate("IDReport_SoChiTietTaiKhoan_New", userID, DateTime.Today.Date);

                PSC_ERP.frmReport frm = new PSC_ERP.frmReport();
                frm.HienThiReport(reportTemplate, dsMain);
                frm.Show();
            }//us

        }

        private void Method_BangTongHopCongNoDoiDoiTuong(DataRowView drv)
        {
            DateTime tuNgay = (DateTime)drv["TuNgay"];
            DateTime denNgay = (DateTime)drv["DenNgay"];
            int maTaiKhoan = (int)drv["MaTaiKhoan"];
            int userID = (int)drv["UserID"];
            int maBoPhan = 0;
            long maDoiTuong = 0;
            string soHieuTK = drv["SoHieuTK"] + "";
            string tenTaiKhoan = drv["TenTaiKhoan"] + "";
            string tenDoiTuong = "";        
           
            DataSet dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;                   
                    cm.CommandText = "spRpt_TongHopCongNoDoiTuong";
                    cm.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", maDoiTuong);
                    cm.Parameters.AddWithValue("@UserId", userID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", userID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = tuNgay;
                dr["DenNgay"] = denNgay;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us

            frmShowReportForGrid frmGrid = new frmShowReportForGrid("Method_BangTongHopCongNoDoiDoiTuong", dataSet);
            frmGrid.Show();

        }

        #region event btn
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnExportDataExcell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridControl1.ExportToXls(dlg.FileName);
                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(dlg.FileName);
            }
        }
        #endregion

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //tinh sum theo dieu kien cho bao cao bang can doi so phat sinh
            if (this.strTenPhuongThuc == "Method_BangCanDoiPhatSinh")
            {
                if (e.IsTotalSummary)
                {
                    if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == "SoDuDauKyNo")
                    {
                        e.TotalValue = Math.Round(this.SumNoDauKy, 0, MidpointRounding.AwayFromZero);
                        e.TotalValueReady = true;
                    }
                    if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == "SoDuDauKyCo")
                    {
                        e.TotalValue = Math.Round(this.SumCoDauKy, 0, MidpointRounding.AwayFromZero);
                        e.TotalValueReady = true;
                    }
                    if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == "SoPhatSinhNo")
                    {
                        e.TotalValue = Math.Round(this.SumNoPhatSinh, 0, MidpointRounding.AwayFromZero);
                        e.TotalValueReady = true;
                    }
                    if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == "SoPhatSinhCo")
                    {
                        e.TotalValue = Math.Round(this.SumCoPhatSinh, 0, MidpointRounding.AwayFromZero);
                        e.TotalValueReady = true;
                    }
                    if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == "SoDuCuoiKyNo")
                    {
                        e.TotalValue = Math.Round(this.SumNoCuoiKy, 0, MidpointRounding.AwayFromZero);
                        e.TotalValueReady = true;
                    }
                    if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == "SoDuCuoiKyCo")
                    {
                        e.TotalValue = Math.Round(this.SumCoCuoiKy, 0, MidpointRounding.AwayFromZero);
                        e.TotalValueReady = true;
                    }

                    //GridView view = sender as GridView;
                    //decimal SoDuDauKyNo = 1; //Convert.ToDecimal(view.Columns["SoDuDauKyNo"].SummaryItem.SummaryValue);
                    //decimal SoDuDauKyCo = Convert.ToDecimal(view.Columns["SoDuDauKyCo"].SummaryItem.SummaryValue);
                    //decimal SoPhatSinhNo = Convert.ToDecimal(view.Columns["SoPhatSinhNo"].SummaryItem.SummaryValue);
                    //e.TotalValue = SoDuDauKyNo;
                    //e.TotalValueReady = true;

                }
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (this.strTenPhuongThuc != "Method_BangCanDoiPhatSinh" && this.strTenPhuongThuc !="Method_BangTongHopPhatSinhTaiKhoan")
                return;

            GridView view = sender as GridView;
            if (view == null) return;
            //if (e.RowHandle != view.FocusedRowHandle &&
            //   ((e.RowHandle % 2 == 0 && e.Column.VisibleIndex % 2 == 1) ||
            //   (e.Column.VisibleIndex % 2 == 0 && e.RowHandle % 2 == 1)))
            //    e.Appearance.BackColor = Color.NavajoWhite;
            if (e.RowHandle < 0)
                return;

            if (e.RowHandle > dsReport.Tables[0].Rows.Count)
                return;

            DataRow dr = dsReport.Tables[0].Rows[e.RowHandle];
            if (dr["KieuIn"] + "" == "1")
            {

                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }









    }
}