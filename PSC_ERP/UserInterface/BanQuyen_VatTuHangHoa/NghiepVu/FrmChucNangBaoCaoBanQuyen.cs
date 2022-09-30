using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class FrmChucNangBaoCaoBanQuyen : DevExpress.XtraEditors.XtraForm
    {
        int _maBoPhan;
        bool _timTheoNgay;
        DataTable _tableSource;
        public FrmChucNangBaoCaoBanQuyen()
        {
            InitializeComponent();
            KhoiTao();

        }

        private void KhoiTao()
        {
            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList; 


            _tableSource = new DataTable();
        }
        #region Function
        private void GetThongTinSearch()
        {

            if (grdLU_BoPhan.EditValue != null)
            {
                _maBoPhan = Convert.ToInt32(grdLU_BoPhan.EditValue);
            }
            else
            {
                _maBoPhan = 0;
            }
  

            if (checkEdit_Ngay.EditValue != null)
            {
                _timTheoNgay =checkEdit_Ngay.Checked;

            }
            else
            {
                _timTheoNgay = false;
            }

        }

        private DataTable Table_ChucNangBaoCaoBanQuyen(bool timTheoNgay, DateTime tuNgay, DateTime denNgay, int maBoPhan)
        {
            //
            DataTable kqTbl = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_ChucNangBaoCaoBanQuyen";
                    cm.Parameters.AddWithValue("@TimTheoNgay", timTheoNgay);
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
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

        private void LoadData()
        {
            GetThongTinSearch();
            _tableSource = Table_ChucNangBaoCaoBanQuyen(_timTheoNgay, (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _maBoPhan); 
            
        }


        private void DesignGridView()
        {
            HamDungChung.InitGridViewDev(gridView1,true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false,true, true);
            HamDungChung.ShowFieldGridViewDev2(gridView1, new string[] { "MaQLChuongTrinhCon", "TenChuongTrinh", "TenDonViTinh", "TenQuocGia", "ThoiLuong", "DonGia", "SoLuongTonDau", "GiaTriTonDau", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi", "TenDoiTac", "SoHopDong", "NgayHopDong", "SoHoaDon", "NgayHoaDon", "NgayNhap", "PhieuNhap", "NgayPS", "NgayXuat", "SoPhieuXuat", "NghiemThu", "TenNguon", "DienGiaiChiTiet", "TenBoPhan" },
                                new string[] { "Mã chương trình", "Tên chương trình", "ĐVT", "Nước SX", "TLượng", "Đơn giá", "Slg Đầu kỳ", "Giá trị Đầu kỳ", "Slg Nhập", "Giá trị Nhập", "Slg Xuất", "Giá trị Xuất", "Slg cuối", "Giá trị cuối", "Đối tác", "Số Hợp Đồng", "Ngày HĐồng", "Số hóa đơn", "Ngày hóa đơn", "Ngày nhập", "Số phiếu nhập", "Ngày PS", "Ngày xuất", "Số phiếu xuất","Nghiệm thu", "Nguồn","Ghi Chú","Thuộc Bộ phận" },
                                             new int[] { 100, 120, 75, 85, 85, 100, 100, 120, 100, 120, 100, 120, 100, 120, 120, 100, 80, 120, 120, 80, 100, 80, 80, 120,100,120,120,100 }, false);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaQLChuongTrinhCon", "TenChuongTrinh", "TenDonViTinh", "TenQuocGia", "ThoiLuong", "DonGia", "SoLuongTonDau", "GiaTriTonDau", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi", "TenDoiTac", "SoHopDong", "NgayHopDong", "SoHoaDon", "NgayHoaDon", "NgayNhap", "PhieuNhap", "NgayPS", "NgayXuat", "SoPhieuXuat", "NghiemThu", "TenNguon", "DienGiaiChiTiet", "TenBoPhan" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] {"ThoiLuong", "DonGia", "SoLuongTonDau", "GiaTriTonDau", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi" }, "#,###");
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "ThoiLuong"}, "{0:N1}");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoLuongTonDau", "GiaTriTonDau", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi" }, "{0:n0}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "ThoiLuong", "DonGia", "SoLuongTonDau", "GiaTriTonDau", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi" }, "#,###");
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "ThoiLuong" }, "{0:N1}");
            Utils.GridUtils.SetSTTForGridView(gridView1, 40);//M
            gridView1.GroupPanelText = "Danh Sách Chương Trình Nhập Xuất Tồn Bản Quyền";
        }

        #endregion

        #region Event

        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.Columns.Clear();
            _tableSource = new DataTable();
            LoadData();
            gridControl1.DataSource = _tableSource;
            DesignGridView();
            if (_tableSource.Rows.Count == 0)//M
                MessageBox.Show("Danh Sách Rỗng");
        }

       
        #endregion

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void btn_XuatRaExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }



     

        private void FrmDanhSachHopDongThuChi_Load(object sender, EventArgs e)
        {
            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
        }
    }
}