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
    public partial class frmDoiChieuTaiKhoanTheoChuongTrinh_ChungTu : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        #region TabPage1

        DataTable _tableSourcePage1;
        private int _maTaiKoan = 0;
        private byte _loaiMau = 1;//1: In Có Số Chứng Từ; 2: In Không Có Số Chứng Từ; 3: Bảng Tổng hợp số dư chương trình theo tài khoản
        //private string _NoTKStr = "";
        //private string _CoTKStr = "";
        private string _SoHieuTk = "";
        #endregion//TabPage1

        #endregion//Properties

        public frmDoiChieuTaiKhoanTheoChuongTrinh_ChungTu()
        {
            InitializeComponent();
            heThongTaiKhoan1ListBindingSource.DataSource = typeof(HeThongTaiKhoan1List);
            KhoiTao();

        }

        private void KhoiTao()
        {
            dateEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dateEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            _tableSourcePage1 = new DataTable();
        }
        #region Function
        private void GetThongTinSearchPage1()
        {
            int tryintmaTaiKhoan;
            if (int.TryParse(GridLookupEdit_TaiKhoan.EditValue.ToString(), out tryintmaTaiKhoan))
            {
                _maTaiKoan = tryintmaTaiKhoan;
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_maTaiKoan);
                _SoHieuTk = tk.SoHieuTK;
                //_NoTKStr = "Nợ " + tk.SoHieuTK;
                //_CoTKStr = "Có " + tk.SoHieuTK;
            }
            else _maTaiKoan = 0;
        }
        private void SetTieuDeForGridView()
        {
            if (_loaiMau == 1)
                gridViewPage1.GroupPanelText =string.Format( "Bảng Đối Chiếu Tài Khoản {0} Theo Chương Trình - Chứng Từ",_SoHieuTk);
            else if (_loaiMau == 2)
                gridViewPage1.GroupPanelText = string.Format( "Bảng Đối Chiếu Tài Khoản {0} Theo Chương Trình",_SoHieuTk);
            else if (_loaiMau == 3)
                gridViewPage1.GroupPanelText = string.Format("Bảng Tổng Hợp Số Dư Chương Trình Theo Tài Khoản {0}", _SoHieuTk);
        }
        private DataTable Table_DataRS(int maTaiKhoan)
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
                    if (_loaiMau == 1)
                        cm.CommandText = "spd_MauDoiChieuTaiKhoanTheoChuongTrinh_ChungTu";
                    else if (_loaiMau == 2)
                        cm.CommandText = "spd_MauDoiChieuTaiKhoanTheoChuongTrinh";
                    else if (_loaiMau == 3)
                    {
                        cm.CommandText = "spd_BangTongHopSoDuChuongTrinhTheoTaiKhoan";
                        cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    }
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
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
                _tableSourcePage1 = Table_DataRS(_maTaiKoan);
                SetTieuDeForGridView();
            }

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
                if (gridViewPage1.Columns[i].FieldName == "MaButToan" || gridViewPage1.Columns[i].FieldName == "MaCT_ChiPhiSanXuat"
                    || gridViewPage1.Columns[i].FieldName == "TongNoChuongTrinh" || gridViewPage1.Columns[i].FieldName == "TongCoChuongTrinh"
                    )
                {
                    gridViewPage1.Columns[i].Visible = false;
                }
                gridViewPage1.Columns[i].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                gridViewPage1.Columns[i].OptionsColumn.AllowEdit = false;
                gridViewPage1.Columns[i].OptionsColumn.FixedWidth = false;
                gridViewPage1.Columns[i].BestFit();
                gridViewPage1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridViewPage1.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gridViewPage1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewPage1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                if (_loaiMau == 1 &&
                    (
                        gridViewPage1.Columns[i].FieldName.Contains("Nợ")
                        || gridViewPage1.Columns[i].FieldName.Contains("Có")
                        || gridViewPage1.Columns[i].FieldName.Contains("Số tiền chương trình")
                        || gridViewPage1.Columns[i].FieldName.Contains("Số Chứng Từ")
                        || gridViewPage1.Columns[i].FieldName.Contains("Ngày chứng từ")
                        || gridViewPage1.Columns[i].FieldName.Contains("Chương trình")
                        || gridViewPage1.Columns[i].FieldName.Contains("User lập")
                    )
                   )
                {
                    gridViewPage1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                }//loaiMau == 1
                if (gridViewPage1.Columns[i].FieldName != "Ngày chứng từ")
                    gridViewPage1.Columns[i].DisplayFormat.FormatString = "#,###";
                else gridViewPage1.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy";
                if (
                    _loaiMau == 2 &&
                        (
                            gridViewPage1.Columns[i].FieldName.Contains("Nợ")
                            || gridViewPage1.Columns[i].FieldName.Contains("Có")
                            || gridViewPage1.Columns[i].FieldName.Contains("Số tiền")
                        )

                    )
                {
                    gridViewPage1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,gridViewPage1.Columns[i].FieldName, "{0:#,###}")});
                }//loaiMau == 2
                if (
                    _loaiMau == 3 &&
                        (
                            gridViewPage1.Columns[i].FieldName.Contains("Nợ")
                            || gridViewPage1.Columns[i].FieldName.Contains("Có")
                        )

                    )
                {
                    gridViewPage1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,gridViewPage1.Columns[i].FieldName, "{0:#,###}")});
                }//loaiMau == 3

            }
            //gridViewPage1.Columns["Tên Nhân Viên"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            //new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count,"Tên Nhân Viên", "{0:#,###} người")});
            if (_loaiMau == 1)
            {

                gridViewPage1.Columns["PS Nợ"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max,"TongNoChuongTrinh", "{0:#,###}")});
                gridViewPage1.Columns["PS Có"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max,"TongCoChuongTrinh", "{0:#,###}")});
            }
            //else if (_loaiMau==3)
            //{
            //    gridViewPage1.Columns["PS Nợ trong kỳ"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            //        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max,"PS Nợ trong kỳ", "{0:#,###}")});
            //    gridViewPage1.Columns["PS Có trong kỳ"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            //        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max,"PS Có trong kỳ", "{0:#,###}")});
            //}
            Utils.GridUtils.SetSTTForGridView(gridViewPage1, 45);//M
        }

        #endregion

        #region Event

        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _loaiMau = 1;
            if (GridLookupEdit_TaiKhoan.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xem", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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





        private void GridLookupEdit_TaiKhoan_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void btnTim2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _loaiMau = 2;
            if (GridLookupEdit_TaiKhoan.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xem", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void gridViewPage1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            #region Old
            //int maButToan1 = Convert.ToInt32(gridViewPage1.GetRowCellValue(e.RowHandle1, gridViewPage1.Columns["MaButToan"]));
            //int maButToan2 = Convert.ToInt32(gridViewPage1.GetRowCellValue(e.RowHandle2, gridViewPage1.Columns["MaButToan"]));
            //long mact_CPSX1 = Convert.ToInt64(gridViewPage1.GetRowCellValue(e.RowHandle1, gridViewPage1.Columns["MaCT_ChiPhiSanXuat"]));
            //long mact_CPSX2 = Convert.ToInt64(gridViewPage1.GetRowCellValue(e.RowHandle2, gridViewPage1.Columns["MaCT_ChiPhiSanXuat"]));
            //if (e.Column.FieldName.Contains("Nợ") || e.Column.FieldName.Contains("Có")
            //    || e.Column.FieldName == "Số Chứng Từ"
            //    || e.Column.FieldName == "Ngày chứng từ"
            //    || e.Column.FieldName == "User lập"
            //    )
            //{
            //    e.Merge = (maButToan1 == maButToan2);
            //    e.Handled = true;
            //}
            //else if (e.Column.FieldName.Contains("Số tiền chương trình")
            //    || e.Column.FieldName == "Chương trình"
            //    )
            //{
            //    e.Merge = (mact_CPSX1 == mact_CPSX2);
            //    e.Handled = true;
            //}
            #endregion//Old

            if (_loaiMau == 1)
            {
                int maButToan1 = Convert.ToInt32(gridViewPage1.GetRowCellValue(e.RowHandle1, gridViewPage1.Columns["MaButToan"]));
                int maButToan2 = Convert.ToInt32(gridViewPage1.GetRowCellValue(e.RowHandle2, gridViewPage1.Columns["MaButToan"]));
                long mact_CPSX1 = Convert.ToInt64(gridViewPage1.GetRowCellValue(e.RowHandle1, gridViewPage1.Columns["MaCT_ChiPhiSanXuat"]));
                long mact_CPSX2 = Convert.ToInt64(gridViewPage1.GetRowCellValue(e.RowHandle2, gridViewPage1.Columns["MaCT_ChiPhiSanXuat"]));
                if (e.Column.FieldName.Contains("Nợ") || e.Column.FieldName.Contains("Có")
                    || e.Column.FieldName == "Số Chứng Từ"
                    || e.Column.FieldName == "Ngày chứng từ"
                    || e.Column.FieldName == "User lập"
                    )
                {
                    e.Merge = (maButToan1 == maButToan2);
                    e.Handled = true;
                }
                else if (e.Column.FieldName.Contains("Số tiền chương trình")
                    || e.Column.FieldName == "Chương trình"
                    )
                {
                    e.Merge = (mact_CPSX1 == mact_CPSX2);
                    e.Handled = true;
                }
            }
            //else if (_loaiMau==2)
            //{
            //    string chuongtrinh = gridViewPage1.GetRowCellValue(e.RowHandle1, gridViewPage1.Columns["Chương trình"]).ToString();
            //    string chuongtrinh2 = gridViewPage1.GetRowCellValue(e.RowHandle2, gridViewPage1.Columns["Chương trình"]).ToString();
            //    string mns = gridViewPage1.GetRowCellValue(e.RowHandle1, gridViewPage1.Columns["Mục ngân sách"]).ToString();
            //    string mns2 = gridViewPage1.GetRowCellValue(e.RowHandle2, gridViewPage1.Columns["Mục ngân sách"]).ToString();
            //    string user = gridViewPage1.GetRowCellValue(e.RowHandle1, gridViewPage1.Columns["User lập"]).ToString();
            //    string user2 = gridViewPage1.GetRowCellValue(e.RowHandle2, gridViewPage1.Columns["User lập"]).ToString();
            //    if (e.Column.FieldName.Contains("Nợ") || e.Column.FieldName.Contains("Có")
            //        )
            //    {
            //        e.Merge = (chuongtrinh == chuongtrinh2 && user == user2 && mns == mns2);
            //        e.Handled = true;
            //    }
            //    else if (e.Column.FieldName.Contains("Số tiền chương trình")
            //        || e.Column.FieldName == "Chương trình"
            //        )
            //    {
            //        e.Merge = (chuongtrinh == chuongtrinh2 && user == user2);
            //        e.Handled = true;
            //    }
            //}

        }

        private void btnTim3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _loaiMau = 3;
            if (GridLookupEdit_TaiKhoan.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xem", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}