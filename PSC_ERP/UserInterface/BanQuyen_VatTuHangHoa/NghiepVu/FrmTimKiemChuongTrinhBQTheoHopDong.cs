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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class FrmTimKiemChuongTrinhBQTheoHopDong : DevExpress.XtraEditors.XtraForm
    {
        long _maHopDong;
        long _maDoiTac;
        int _maBoPhanNhap;
        int _maBoPhanNhan;
        HopDongMuaBanList _HopDongMuaBanList;
        DoiTacList _DoiTacList;
        BoPhanList _boPhanList;

        public FrmTimKiemChuongTrinhBQTheoHopDong()
        {
            InitializeComponent();
            LoadForm();
        }

        #region Function


        private void FormatGridview(GridView gridV)
        {
            HamDungChung.InitGridViewDev(gridV, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev2(gridV, new string[] { "MaVatTu", "TenChuongTrinh", "DVT", "ThoiLuong", "TenDoiTac", "SoHopDong", "SoLuongNhap", "ThanhTienNhap", "SoLuongXuat", "ThanhTienXuat" },
                                new string[] { "Mã chương trình", "Tên chương trình", "ĐVT", "Thời lượng", "Đối tác", "Số hợp đồng", "SLượng nhập", "Giá trị nhập", "SLượng xuất", "Giá trị xuất" },
                                             new int[] { 100, 100, 85, 85, 120, 100, 100, 120, 100, 120 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridV, new string[] { "MaVatTu", "TenChuongTrinh", "DVT", "ThoiLuong", "TenDoiTac", "SoHopDong", "SoLuongNhap", "ThanhTienNhap", "SoLuongXuat", "ThanhTienXuat" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridV, new string[] { "SoLuongNhap", "ThanhTienNhap", "SoLuongXuat", "ThanhTienXuat" }, "#,###");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridV, new string[] { "SoLuongNhap", "ThanhTienNhap", "SoLuongXuat", "ThanhTienXuat" }, "{0:n0}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridV);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridV, new string[] { "SoLuongNhap", "ThanhTienNhap", "SoLuongXuat", "ThanhTienXuat" }, "#,###");
            Utils.GridUtils.SetSTTForGridView(gridV, 40);//M

        }

        private void GetThongTinSearch()
        {
            if (GridlookUpEdit_PhongBanNhap.EditValue != null)
            {
                _maBoPhanNhap = (int)GridlookUpEdit_PhongBanNhap.EditValue;
            }
            else
            {
                _maBoPhanNhap = 0;
            }

            if (gridLookUpEdit_PhongBanNhan.EditValue != null)
            {
                _maBoPhanNhan = (int)gridLookUpEdit_PhongBanNhan.EditValue;
            }
            else
            {
                _maBoPhanNhan = 0;
            }

            if (lookUpEdit_DoiTac.EditValue != null)
            {
                _maDoiTac = (long)lookUpEdit_DoiTac.EditValue;
            }
            else
            {
                _maDoiTac = 0;
            }

            if (gridLookUpEdit_HopDong.EditValue != null)
            {
                _maHopDong = (long)gridLookUpEdit_HopDong.EditValue;
            }
            else
            {
                _maHopDong = 0;
            }


        }
        #region Loadata

        #endregion //Loadata

        public static DataTable DanhSachChuongTrinhBQTheoDieuKien_Ngay(DateTime tuNgay, DateTime denNgay, int maBoPhanNhap, int maBoPhanNhan, long maDoiTac, long maHopDong)
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
                    cm.CommandText = "Spd_TimDanhSachChuongTrinhBQTheoDieuKien_Ngay";
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhanNhap", maBoPhanNhap);
                    cm.Parameters.AddWithValue("@MaBoPhanNhan", maBoPhanNhan);
                    cm.Parameters.AddWithValue("@MaDoiTac", maDoiTac);
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
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

        public static DataTable DanhSachChuongTrinhBQTheoDieuKien(int maBoPhanNhap, int maBoPhanNhan, long maDoiTac, long maHopDong)
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
                    cm.CommandText = "Spd_TimDanhSachChuongTrinhBQTheoDieuKien";
                    cm.Parameters.AddWithValue("@MaBoPhanNhap", maBoPhanNhap);
                    cm.Parameters.AddWithValue("@MaBoPhanNhan", maBoPhanNhan);
                    cm.Parameters.AddWithValue("@MaDoiTac", maDoiTac);
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
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

        #endregion //Function


        private void LoadForm()
        {
            HopDongMuaBan hd = HopDongMuaBan.NewHopDongMuaBan(0, "Không chọn");
            _HopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanByUserID();
            _HopDongMuaBanList.Insert(0, hd);
            HopDongMuaBanList_BindingSource.DataSource = _HopDongMuaBanList;

            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;

            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan bp = BoPhan.NewBoPhan(0, "Không chọn");
            _boPhanList.Insert(0, bp);
            boPhanListBindingSource.DataSource = _boPhanList;

            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;

        }



        private void btn_XuatfileExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView2.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridLookUpEdit_HopDong_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit_HopDong.EditValue != null)
            {
                _maHopDong = (long)gridLookUpEdit_HopDong.EditValue;
            }
        }

        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView2.Columns.Clear();
            DataTable _daTaDanhSachChuongTrinh = new DataTable();
            GetThongTinSearch();
            if (checkEdit_Ngay.Checked == true)
            {
                _daTaDanhSachChuongTrinh = DanhSachChuongTrinhBQTheoDieuKien_Ngay((Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _maBoPhanNhap, _maBoPhanNhan, _maDoiTac, _maHopDong);
            }
            else
            {
                _daTaDanhSachChuongTrinh = DanhSachChuongTrinhBQTheoDieuKien(_maBoPhanNhap, _maBoPhanNhan, _maDoiTac, _maHopDong);
            }

            gridView2.GroupPanelText = "Danh Sách Chương Trình Nhập Xuất";
            gridControl1.DataSource = _daTaDanhSachChuongTrinh;
            FormatGridview(gridView2);
            if (_daTaDanhSachChuongTrinh.Rows.Count <= 0)
                MessageBox.Show("Danh Sách Chương Trình Nhập Xuất Theo Điều Kiện Rỗng!");

        }




    }
}