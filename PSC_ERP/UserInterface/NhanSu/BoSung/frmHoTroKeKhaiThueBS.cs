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
using DevExpress.XtraGrid.Columns;
//05_08_2014
namespace PSC_ERP
{
    public partial class frmHoTroKeKhaiThueBS : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        DataTable _table1BK;
        DataTable _table2BK;
        DataTable _table3BK;
        private int _Nam;
        #endregion//Properties

        #region Constructors

        public frmHoTroKeKhaiThueBS()
        {
            InitializeComponent();
            KhoiTao();

        }

        private void KhoiTao()
        {
            _table1BK = new DataTable();
            _table2BK = new DataTable();
            _table3BK = new DataTable();
        }

        #endregion//Constructors

        #region Function

        private void GetThongTinSearch()
        {
            _Nam = (int)textNamQT.EditValue;
        }

        private void GetThongTinSearchPage2()
        {

        }
        private DataTable Table1BK()
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
                    cm.CommandText = "spd_HoTroKeKhaiThueNhanVien";
                    cm.Parameters.AddWithValue("@Nam", _Nam);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@HTXem", (int)ChonXemTheoUser_radioGroup.EditValue);
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
        private DataTable Table2BK()
        {
            DataTable tblresult = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_HoTroKeKhaiThueCongTacVien";
                    cm.Parameters.AddWithValue("@Nam", _Nam);
                    cm.Parameters.AddWithValue("@Loai", (int)radioGroup_LoaiThuNhapCTV.EditValue);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0)
                            tblresult = ds.Tables[0];
                    }
                }
            }
            return tblresult;
        }

        private DataTable Table3BK()
        {
            DataTable tblresult = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_HoTroKeKhaiNguoiPhuThuoc";
                    cm.Parameters.AddWithValue("@Nam", _Nam);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0)
                            tblresult = ds.Tables[0];
                    }
                }
            }
            return tblresult;
        }

        private void LoadData()
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1BK")
            {
                GetThongTinSearch();
                _table1BK = Table1BK();
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2BK")
            {
                GetThongTinSearch();
                _table2BK = Table2BK();
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage3BK")
            {
                GetThongTinSearch();
                _table3BK = Table3BK();
            }

        }


        private void DesignGridViewPage1BK()
        {//N
            gridView1BK.OptionsView.ShowGroupPanel = true;
            gridView1BK.GroupPanelText = "Bảng Kê Chi Tiết Cá Nhân Thuộc Diện Tính Thuế Theo Biểu Lũy Tiến Từng Phần";
            gridView1BK.OptionsView.ShowAutoFilterRow = true;
            gridView1BK.OptionsView.ColumnAutoWidth = false;
            gridView1BK.OptionsView.ShowFooter = true;
            for (int i = 0; i < gridView1BK.Columns.Count; i++)
            {
                gridView1BK.Columns[i].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                gridView1BK.Columns[i].OptionsColumn.AllowEdit = false;
                gridView1BK.Columns[i].OptionsColumn.FixedWidth = false;
                gridView1BK.Columns[i].BestFit();
                gridView1BK.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1BK.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                if (gridView1BK.Columns[i].FieldName.Contains("Ngày"))
                    gridView1BK.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy";
                else if (gridView1BK.Columns[i].FieldName.Contains("(Số)"))
                {
                    gridView1BK.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1BK.Columns[i].DisplayFormat.FormatString = "#,###";
                    gridView1BK.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,gridView1BK.Columns[i].FieldName, "{0:#,###}")});
                }
            }
            Utils.GridUtils.SetSTTForGridView(gridView1BK, 40);//M
        }

        private void DesignGridViewPage2BK()
        {//N
            gridView2BK.OptionsView.ShowGroupPanel = true;
            gridView2BK.GroupPanelText = "Bảng Kê Chi Tiết Cá Nhân Thuộc Diện Tính Thuế Theo Thuế Suất Toàn Phần";
            gridView2BK.OptionsView.ShowAutoFilterRow = true;
            gridView2BK.OptionsView.ColumnAutoWidth = false;
            gridView2BK.OptionsView.ShowFooter = true;
            for (int i = 0; i < gridView2BK.Columns.Count; i++)
            {
                gridView2BK.Columns[i].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                gridView2BK.Columns[i].OptionsColumn.AllowEdit = false;
                gridView2BK.Columns[i].OptionsColumn.FixedWidth = false;
                gridView2BK.Columns[i].BestFit();
                gridView2BK.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView2BK.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                if (gridView2BK.Columns[i].FieldName.Contains("Ngày"))
                    gridView2BK.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy";
                else if (gridView2BK.Columns[i].FieldName.Contains("(Số)"))
                {
                    gridView2BK.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView2BK.Columns[i].DisplayFormat.FormatString = "#,###";
                    gridView2BK.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,gridView2BK.Columns[i].FieldName, "{0:#,###}")});
                }

            }
            Utils.GridUtils.SetSTTForGridView(gridView2BK, 40);//M
        }

        private void DesignGridViewPage3BK()
        {//N
            gridView3BK.OptionsView.ShowGroupPanel = true;
            gridView3BK.GroupPanelText = "Bảng Kê Chi Tiết Cá Nhân Thuộc Diện Tính Thuế Theo Thuế Suất Toàn Phần";
            gridView3BK.OptionsView.ShowAutoFilterRow = true;
            gridView3BK.OptionsView.ColumnAutoWidth = false;
            gridView3BK.OptionsView.ShowFooter = true;
            for (int i = 0; i < gridView3BK.Columns.Count; i++)
            {
                gridView3BK.Columns[i].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                gridView3BK.Columns[i].OptionsColumn.AllowEdit = false;
                gridView3BK.Columns[i].OptionsColumn.FixedWidth = false;
                gridView3BK.Columns[i].BestFit();
                gridView3BK.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView3BK.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                if (gridView3BK.Columns[i].FieldName.Contains("Ngày"))
                    gridView3BK.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy";
                else if (gridView3BK.Columns[i].FieldName.Contains("(Số)"))
                {
                    gridView3BK.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView3BK.Columns[i].DisplayFormat.FormatString = "#,###";
                }
            }
            Utils.GridUtils.SetSTTForGridView(gridView3BK, 40);//M
        }

        private void BoSung()
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1BK")
            {
                ChonXemTheoUser_radioGroup.Visible = true;
            }
            else
            {
                ChonXemTheoUser_radioGroup.Visible = false;
            }
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2BK")
            {
                lbCTV.Visible = true;
                radioGroup_LoaiThuNhapCTV.Visible = true;
            }
            else
            {
                lbCTV.Visible = false;
                radioGroup_LoaiThuNhapCTV.Visible = false;
            }
        }

        #endregion

        #region Event

        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1BK")
            {
                gridView1BK.Columns.Clear();
                _table1BK = new DataTable();
                LoadData();
                gridControl1BK.DataSource = _table1BK;
                DesignGridViewPage1BK();
                if (_table1BK.Rows.Count == 0)//M
                    MessageBox.Show("Danh Sách Rỗng");
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2BK")
            {
                gridView2BK.Columns.Clear();
                _table2BK = new DataTable();
                LoadData();
                gridControl2BK.DataSource = _table2BK;
                DesignGridViewPage2BK();
                if (_table2BK.Rows.Count == 0)//M
                    MessageBox.Show("Danh Sách Rỗng");
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage3BK")
            {
                gridView3BK.Columns.Clear();
                _table3BK = new DataTable();
                LoadData();
                gridControl3BK.DataSource = _table3BK;
                DesignGridViewPage3BK();
                if (_table3BK.Rows.Count == 0)//M
                    MessageBox.Show("Danh Sách Rỗng");
            }
        }

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
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1BK")
            {
                //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    gridView1BK.ExportToXls(dlg.FileName);
                    OpenFile(dlg.FileName);
                }
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2BK")
            {
                //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    gridView2BK.ExportToXls(dlg.FileName);
                    OpenFile(dlg.FileName);
                }
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage3BK")
            {
                //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    gridView3BK.ExportToXls(dlg.FileName);
                    OpenFile(dlg.FileName);
                }
            }
        }

        private void FrmDanhSachHopDongThuChi_Load(object sender, EventArgs e)
        {
            textNamQT.EditValue = DateTime.Today.Year - 1;
            BoSung();
        }
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            BoSung();
        }
        #endregion

        


    }
}