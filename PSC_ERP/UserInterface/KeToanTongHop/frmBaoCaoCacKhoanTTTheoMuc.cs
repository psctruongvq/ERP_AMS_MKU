using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ERP_Library;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Documents.Excel;

 
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmBaoCaoCacKhoanTTTheoMuc : Form
    {

        DataTable _dataTable;
        DataTable _dataTable1;
        string path;        
        SaveFileDialog saveFileDialog;
        MucNganSachList _mucNganSachList;
        public frmBaoCaoCacKhoanTTTheoMuc()
        {
            InitializeComponent();
            _mucNganSachList = MucNganSachList.GetMucNganSachList();
            MucNganSachList_bindingSource.DataSource = _mucNganSachList;

        }

        #region btTim_Click
        private void btTim_Click(object sender, EventArgs e)
        {
            _dataTable = new DataTable();
            _dataTable1 = new DataTable();
            using( SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CacKhoanThanhToanTheoMuc"; 
                    cm.Parameters.AddWithValue("@TuNgay", dtu_NgayBatDau.DateTime);
                    cm.Parameters.AddWithValue("@DenNgay", dtu_NgayKetThuc.DateTime);
                    cm.Parameters.AddWithValue("@MaMucNganSach", Convert.ToInt32(ultraCombo1.Value));
                    cm.Parameters.AddWithValue("@MaNhanVien", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(cm);
                    _sqlDataAdapter.Fill(_dataTable);

                }

                using (SqlCommand cm1= cn.CreateCommand())
                {
                    cm1.CommandType = CommandType.StoredProcedure;
                    cm1.CommandText = "spd_LayNguoiKyTenCongNo";
                    cm1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(cm1);
                    _sqlDataAdapter.Fill(_dataTable1);

                }
            }

            for (int i=0; i < _dataTable.Columns.Count; i++)
            {
                if ( i==0)
                    _dataTable.Columns[i].ColumnName = "Ngày chứng từ";
                else if ( i==1)
                    _dataTable.Columns[i].ColumnName = "Số Chứng Từ";
                else if ( i==2)
                    _dataTable.Columns[i].ColumnName = "Diễn giải";
                else if ( i==3)
                    _dataTable.Columns[i].ColumnName = "Số tiền";
                else
                    _dataTable.Columns[i].ColumnName = "Tiết " + _dataTable.Columns[i].ColumnName;
            }


            ultraGrid_DuLieu.DataSource = _dataTable;          
                
        }
        #endregion 

        private void bt_ChonDuongDan_Click(object sender, EventArgs e)
        {
            path = Application.StartupPath;
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Chọn đường dẫn và nhập tên file";
            
            saveFileDialog.Filter = "TNTT(*.xls)|*.xls|All files (*.*)|*.*";
            
            saveFileDialog.InitialDirectory = path;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_DuongDan.Text = saveFileDialog.FileName;
            }
        }

        private void bt_ThucHien_Click(object sender, EventArgs e)
        {


            #region Trang Trí Excel

            int columms = _dataTable.Columns.Count;
            int rows = _dataTable.Rows.Count + 10;
            Workbook wb3 = new Workbook();
            this.ultraGridExcelExporter_XuatDuLieu.Export(this.ultraGrid_DuLieu, wb3, 7, 0);

            wb3.Worksheets[0].MergedCellsRegions.Add(0, 0, 0, 3);
            wb3.Worksheets[0].Rows[0].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Left;
            wb3.Worksheets[0].Rows[0].Cells[0].Value = "Đài Truyền Hình TP.HCM";

            wb3.Worksheets[0].MergedCellsRegions.Add(1, 0, 1, 3);
            wb3.Worksheets[0].Rows[1].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Left;
            wb3.Worksheets[0].Rows[1].Cells[0].Value = "Ban Tài Chính";

            wb3.Worksheets[0].MergedCellsRegions.Add(2, 0, 2, 3);
            wb3.Worksheets[0].Rows[2].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Left;
            wb3.Worksheets[0].Rows[2].Cells[0].Value = "---------------oo0o--------------";

            wb3.Worksheets[0].MergedCellsRegions.Add(3, 0, 3, columms - 2);
            wb3.Worksheets[0].Rows[3].Cells[0].Value = "TNTT CỦA CHƯƠNG TRÌNH - 66121LC ";

            wb3.Worksheets[0].MergedCellsRegions.Add(4, 0, 4, columms - 2);
            wb3.Worksheets[0].Rows[4].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
            wb3.Worksheets[0].Rows[4].Cells[0].Value = "Từ Ngày " + dtu_NgayBatDau.DateTime.ToShortDateString() + " Đến Ngày " + dtu_NgayKetThuc.DateTime.ToShortDateString();

            wb3.Worksheets[0].MergedCellsRegions.Add(5, 0, 5, 4);
            wb3.Worksheets[0].Rows[5].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Left;
            wb3.Worksheets[0].Rows[5].Cells[0].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;
            //if (tenPhongBan!=null)
            //wb3.Worksheets[0].Rows[5].Cells[0].Value = "Đơn Vị: " + tenPhongBan.ToString();

            //wb3.Worksheets[0].MergedCellsRegions.Add(5, 5, 5, 6);
            //wb3.Worksheets[0].Rows[5].Cells[5].CellFormat.Alignment = HorizontalCellAlignment.Right;
            //wb3.Worksheets[0].Rows[5].Cells[5].Value = "Biểu Di Chuyển - Nội Bộ";

            wb3.Worksheets[0].MergedCellsRegions.Add(rows - 2, 0, rows - 2, 1);
            wb3.Worksheets[0].Rows[rows - 2].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
            wb3.Worksheets[0].Rows[rows - 2].Cells[0].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;
            wb3.Worksheets[0].Rows[rows - 2].Cells[0].Value = "Cộng";

            for (int i = 0; i < _dataTable.Columns.Count; i++)
            {
                if (i == 0)
                    wb3.Worksheets[0].Columns[i].Width = 4000;
                else if (i == 1)
                    wb3.Worksheets[0].Columns[i].Width = 4000;
                else if (i == 2)
                    wb3.Worksheets[0].Columns[i].Width = 8000;
                else 
                    wb3.Worksheets[0].Columns[i].Width = 2500;                
            }

            foreach (UltraGridBand band in this.ultraGrid_DuLieu.DisplayLayout.Bands)
            {
                foreach (UltraGridColumn column in band.Columns)
                {
                    if (column.DataType.ToString() == "System.Decimal")
                    {
                        column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        column.Format = "#,###,###";
                    }
                }
            }

            #endregion

            #region chỉnh sửa cho Excel

            wb3.Worksheets[0].Rows[3].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
            wb3.Worksheets[0].Rows[3].Cells[0].CellFormat.Font.Height = 350;
            wb3.Worksheets[0].Rows[3].Cells[0].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;

            wb3.Worksheets[0].Rows[7].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
            wb3.Worksheets[0].Rows[7].Cells[1].CellFormat.Alignment = HorizontalCellAlignment.Center;
            wb3.Worksheets[0].Rows[7].Cells[2].CellFormat.Alignment = HorizontalCellAlignment.Center;
            wb3.Worksheets[0].Rows[7].Cells[3].CellFormat.Alignment = HorizontalCellAlignment.Center;
            wb3.Worksheets[0].Rows[7].Cells[4].CellFormat.Alignment = HorizontalCellAlignment.Center;
            wb3.Worksheets[0].Rows[7].Cells[5].CellFormat.Alignment = HorizontalCellAlignment.Center;
            wb3.Worksheets[0].Rows[7].Cells[6].CellFormat.Alignment = HorizontalCellAlignment.Center;

            wb3.Worksheets[0].Rows[7].Cells[0].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;
            wb3.Worksheets[0].Rows[7].Cells[1].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;
            wb3.Worksheets[0].Rows[7].Cells[2].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;
            wb3.Worksheets[0].Rows[7].Cells[3].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;
            wb3.Worksheets[0].Rows[7].Cells[4].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;
            wb3.Worksheets[0].Rows[7].Cells[5].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;
            wb3.Worksheets[0].Rows[7].Cells[6].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;

            //của Nguoi lap bieu         

            wb3.Worksheets[0].Rows[rows + 3].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
            wb3.Worksheets[0].Rows[rows + 3].Cells[0].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;
            wb3.Worksheets[0].Rows[rows + 3].Cells[0].Value = _dataTable1.Rows[0].ItemArray[6].ToString();
            
            wb3.Worksheets[0].MergedCellsRegions.Add(rows + 3, 2, rows + 3, 4);
            wb3.Worksheets[0].Rows[rows + 3].Cells[2].CellFormat.Alignment = HorizontalCellAlignment.Center;
            wb3.Worksheets[0].Rows[rows + 3].Cells[2].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;
            wb3.Worksheets[0].Rows[rows + 3].Cells[2].Value = _dataTable1.Rows[0].ItemArray[4].ToString();

            TenNV nv = TenNV.GetTenNhanVien(ERP_Library.Security.CurrentUser.Info.MaNhanVien);
            //wb3.Worksheets[0].MergedCellsRegions.Add(rows + 5, 2, rows + 5, 4);
            wb3.Worksheets[0].Rows[rows + 5].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
            wb3.Worksheets[0].Rows[rows + 5].Cells[0].CellFormat.Font.Italic = ExcelDefaultableBoolean.True;
            wb3.Worksheets[0].Rows[rows + 5].Cells[0].Value = nv.TenNhanVien;

            wb3.Worksheets[0].MergedCellsRegions.Add(rows + 5, 2, rows + 5, 4);
            wb3.Worksheets[0].Rows[rows + 5].Cells[2].CellFormat.Alignment = HorizontalCellAlignment.Center;
            wb3.Worksheets[0].Rows[rows + 5].Cells[2].CellFormat.Font.Italic = ExcelDefaultableBoolean.True;
            wb3.Worksheets[0].Rows[rows + 5].Cells[2].Value = _dataTable1.Rows[0].ItemArray[1].ToString();
           

            wb3.Worksheets[0].Rows[rows + 3].Cells[1].CellFormat.Font.Height = 200;
            #endregion
            if (txt_DuongDan.Text == "")
            {
                txt_DuongDan.Focus();
                txt_DuongDan.SelectAll();
                return;
            }
            BIFF8Writer.WriteWorkbookToFile(wb3, txt_DuongDan.Text);
            MessageBox.Show("Export Dữ Liệu Thành Công");
        }

        private void ucb_MucNganSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
           
        }

        private void ultraCombo1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            FilterCombo a = new FilterCombo(ultraCombo1, "TenMucNganSach");
        }

    }
}
