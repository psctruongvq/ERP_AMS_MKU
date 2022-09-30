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
    public partial class frmDanhSachNhanVienBS : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        #region TabPage1

        DataTable _tableSourcePage1;
        private int _mabophan = 0;
        #endregion//TabPage1

        #endregion//Properties

        public frmDanhSachNhanVienBS()
        {
            InitializeComponent();
            BoPhanListBindingSource.DataSource = typeof(BoPhanList);
            KhoiTao();

        }

        private void DesignBoPhan_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(BoPhan_gridLookUpEdit1, BoPhanListBindingSource, "TenBoPhan", "MaBoPhan", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(BoPhan_gridLookUpEdit1, new string[] { "TenBoPhan", "MaBoPhanQL" }, new string[] { "Đơn vị", "Mã đơn vị" }, new int[] { 200, 100 }, false);
            BoPhan_gridLookUpEdit1.EditValueChanged += new System.EventHandler(this.BoPhan_gridLookUpEdit1_EditValueChanged);
            BoPhan_gridLookUpEdit1.EditValue = 0;
        }

        private void DesignGridControls()
        {
            DesignBoPhan_gridLookUpEdit1();

        }


        private void KhoiTao()
        {
            btn_Tim.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //DonViList
            BoPhanList bophanlist = BoPhanList.GetBoPhanListByMaCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy);
            BoPhan bpEmpt = BoPhan.NewBoPhan("<<Tất cả>>");
            bophanlist.Insert(0, bpEmpt);
            BoPhanListBindingSource.DataSource = bophanlist;
            _tableSourcePage1 = new DataTable();
            DesignGridControls();
            
        }
        #region Function
        private void GetThongTinSearchPage1()
        {
            _mabophan = 0;
            int tryintmaBoPhan;
            if (BoPhan_gridLookUpEdit1.EditValue !=null && int.TryParse(BoPhan_gridLookUpEdit1.EditValue.ToString(), out tryintmaBoPhan))
            {
                _mabophan = tryintmaBoPhan;
            }
        }
        private void SetTieuDeForGridView()
        {
            gridViewPage1.GroupPanelText = "Danh Sách Nhân Viên";
        }
        private DataTable Table_DataRS(int maBoPhan)
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
                    cm.CommandText = "spd_LoadDanhSachNhanVienBS";
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
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
            GetThongTinSearchPage1();
            _tableSourcePage1 = Table_DataRS(_mabophan);
            SetTieuDeForGridView();

        }


        private void DesignGridViewPage1()
        {//N
            gridViewPage1.OptionsView.ShowGroupPanel = true;
            
            gridViewPage1.OptionsView.ShowAutoFilterRow = true;
            gridViewPage1.OptionsView.ColumnAutoWidth = false;
            gridViewPage1.OptionsView.ShowFooter = true;
            gridViewPage1.OptionsView.AllowCellMerge = true;

            
            for (int i = 0; i < gridViewPage1.Columns.Count; i++)
            {
                //if (gridViewPage1.Columns[i].FieldName == "MaButToan" || gridViewPage1.Columns[i].FieldName == "MaCT_ChiPhiSanXuat"
                //    || gridViewPage1.Columns[i].FieldName == "TongNoChuongTrinh" || gridViewPage1.Columns[i].FieldName == "TongCoChuongTrinh"
                //    )
                //{
                //    gridViewPage1.Columns[i].Visible = false;
                //}
                gridViewPage1.Columns[i].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                gridViewPage1.Columns[i].OptionsColumn.AllowEdit = false;
                gridViewPage1.Columns[i].OptionsColumn.FixedWidth = false;
                gridViewPage1.Columns[i].BestFit();
                gridViewPage1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridViewPage1.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gridViewPage1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewPage1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                //if (_loaiMau == 1 &&
                //    (
                //        gridViewPage1.Columns[i].FieldName.Contains("Nợ")
                //        || gridViewPage1.Columns[i].FieldName.Contains("Có")
                //        || gridViewPage1.Columns[i].FieldName.Contains("Số tiền chương trình")
                //        || gridViewPage1.Columns[i].FieldName.Contains("Số Chứng Từ")
                //        || gridViewPage1.Columns[i].FieldName.Contains("Ngày chứng từ")
                //        || gridViewPage1.Columns[i].FieldName.Contains("Chương trình")
                //        || gridViewPage1.Columns[i].FieldName.Contains("User lập")
                //    )
                //   )
                //{
                //    gridViewPage1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                //}//loaiMau == 1
                if (gridViewPage1.Columns[i].FieldName != "Ngày sinh")
                    gridViewPage1.Columns[i].DisplayFormat.FormatString = "#,###";
                else gridViewPage1.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy";
            //    if (
            //        _loaiMau == 2 &&
            //            (
            //                gridViewPage1.Columns[i].FieldName.Contains("Nợ")
            //                || gridViewPage1.Columns[i].FieldName.Contains("Có")
            //                || gridViewPage1.Columns[i].FieldName.Contains("Số tiền")
            //            )

            //        )
            //    {
            //        gridViewPage1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            //new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,gridViewPage1.Columns[i].FieldName, "{0:#,###}")});
            //    }//loaiMau == 2
            //    if (
            //        _loaiMau == 3 &&
            //            (
            //                gridViewPage1.Columns[i].FieldName.Contains("Nợ")
            //                || gridViewPage1.Columns[i].FieldName.Contains("Có")
            //            )

            //        )
            //    {
            //        gridViewPage1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            //new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,gridViewPage1.Columns[i].FieldName, "{0:#,###}")});
            //    }//loaiMau == 3

            }
            ////gridViewPage1.Columns["Tên Nhân Viên"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            ////new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count,"Tên Nhân Viên", "{0:#,###} người")});
            //if (_loaiMau == 1)
            //{

            //    gridViewPage1.Columns["PS Nợ"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            //        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max,"TongNoChuongTrinh", "{0:#,###}")});
            //    gridViewPage1.Columns["PS Có"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            //        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max,"TongCoChuongTrinh", "{0:#,###}")});
            //}
            ////else if (_loaiMau==3)
            ////{
            ////    gridViewPage1.Columns["PS Nợ trong kỳ"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            ////        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max,"PS Nợ trong kỳ", "{0:#,###}")});
            ////    gridViewPage1.Columns["PS Có trong kỳ"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            ////        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max,"PS Có trong kỳ", "{0:#,###}")});
            ////}
            Utils.GridUtils.SetSTTForGridView(gridViewPage1, 45);//M
        }

        #endregion

        #region Event

        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewPage1.Columns.Clear();
            _tableSourcePage1 = new DataTable();
            LoadData();
            gridControl1.DataSource = _tableSourcePage1;
            DesignGridViewPage1();
            if (_tableSourcePage1.Rows.Count == 0)//M
                MessageBox.Show("Danh Sách Rỗng");
        }


        #endregion

        #region EventHandles
        private void BoPhan_gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            btn_Tim.PerformClick();
            //LoadData();
        }
        #endregion EventHandles

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

    }
}