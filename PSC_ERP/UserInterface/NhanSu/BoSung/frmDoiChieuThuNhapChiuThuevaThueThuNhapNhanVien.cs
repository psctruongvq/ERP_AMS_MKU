using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;
using ERP_Library.Security;
//05_08_2014
namespace PSC_ERP
{
    public partial class frmDoiChieuThuNhapChiuThuevaThueThuNhapNhanVien : XtraForm
    {
        #region Properties

        #region TabPage1

        DataTable _tableSourcePage1;
        private int _maKyTinhLuong = 0;
        private int _maBoPhan = 0;
        int userID = CurrentUser.Info.UserID;
        #endregion//TabPage1

        #endregion//Properties

        public frmDoiChieuThuNhapChiuThuevaThueThuNhapNhanVien()
        {
            InitializeComponent();
            KhoiTao();

        }

        private void KhoiTao()
        {
            GrdLUKyTinhLuong.Properties.DataSource = KyTinhLuongList.GetKyTinhLuongList();
            GrdLU_BoPhan.Properties.DataSource = BoPhanList.GetBoPhanListAll(userID);
            _tableSourcePage1 = new DataTable();
        }
        #region Function
        private void GetThongTinSearchPage1()
        {
            int tryintmaBoPhan;
            if (int.TryParse(GrdLU_BoPhan.EditValue.ToString(), out tryintmaBoPhan))
            {
                _maBoPhan = tryintmaBoPhan;
            }
            else _maBoPhan = 0;

            int tryintmaKyTinhLuong;
            if (int.TryParse(GrdLUKyTinhLuong.EditValue.ToString(), out tryintmaKyTinhLuong))
            {
                _maKyTinhLuong = tryintmaKyTinhLuong;
            }
            else _maKyTinhLuong = 0;


        }
        private DataTable Table_DataRS(int makyTinhLuong, int maBoPhan)
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
                    cm.CommandText = "spd_MauDoiChieu_BangKeThueTNCN_NV";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", makyTinhLuong);
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
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                GetThongTinSearchPage1();
                _tableSourcePage1 = Table_DataRS(_maKyTinhLuong, _maBoPhan);
            }

        }


        private void DesignGridViewPage1()
        {//N
            gridViewPage1.OptionsView.ShowGroupPanel = true;
            gridViewPage1.GroupPanelText = "Bảng Đối Chiếu Thu Nhập Chịu Thuế và Thuế Thu Nhập Nhân Viên";
            gridViewPage1.OptionsView.ShowAutoFilterRow = true;
            gridViewPage1.OptionsView.ColumnAutoWidth = false;
            gridViewPage1.OptionsView.ShowFooter = true;
            for (int i = 0; i < gridViewPage1.Columns.Count; i++)
            {
                gridViewPage1.Columns[i].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                gridViewPage1.Columns[i].OptionsColumn.AllowEdit = false;
                gridViewPage1.Columns[i].OptionsColumn.FixedWidth = false;
                gridViewPage1.Columns[i].BestFit();
                gridViewPage1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridViewPage1.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gridViewPage1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewPage1.Columns[i].DisplayFormat.FormatString = "#,###";
                if (gridViewPage1.Columns[i].FieldName != "Tên Nhân Viên")
                    gridViewPage1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,gridViewPage1.Columns[i].FieldName, "{0:#,###}")});

            }
            gridViewPage1.Columns["Tên Nhân Viên"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count,"Tên Nhân Viên", "{0:#,###} người")});
            Utils.GridUtils.SetSTTForGridView(gridViewPage1, 40);//M
        }

        #endregion

        #region Event

        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GrdLUKyTinhLuong.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ lương để xem", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GrdLU_BoPhan.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn bộ phận để xem", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                gridViewPage1.Columns.Clear();
                _tableSourcePage1 = new DataTable();
                LoadData();
                gridControl1.DataSource = _tableSourcePage1;
                DesignGridViewPage1();
                if (_tableSourcePage1.Rows.Count == 0)//M
                    MessageBox.Show("Danh Sách Rỗng");
            }
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
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    gridViewPage1.ExportToXls(dlg.FileName);
                    OpenFile(dlg.FileName);
                }
            }
        }        

        private void FrmDanhSachHopDongThuChi_Load(object sender, EventArgs e)
        {
        }

    }
}