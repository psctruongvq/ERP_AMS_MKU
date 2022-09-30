using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmExportThuLapImport : Form
    {
        #region Properties
        private BoPhanList _boPhanList;
        private int _loai;
        #endregion


        #region Loads
        public frmExportThuLapImport(int loai)
        {
            InitializeComponent();
            this._loai = loai;
            Load_Form();
        }
       
        private void cmbu_Bophan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }
        #endregion

        #region Process
        private void Load_Form()
        {
            _boPhanList = BoPhanList.GetBoPhanListByMaBoPhanChaNotNull();
            BoPhan itemBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _boPhanList.Insert(0, itemBoPhan);
            this.BoPhanbd.DataSource = _boPhanList;
        }
        #endregion

        #region Event
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Xuat_Click(object sender, EventArgs e)
        {
            try
            {
                //xuất ra 1 file excel từ resource sau đó insert dữ liệu vào excel
                if (cmbu_Bophan.Value == null)
                {
                    MessageBox.Show("Chọn bộ phận cần xuất dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.AddExtension = true;
                dlg.Filter = "Excel|*.xls|All file|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    if (_loai == 0)
                    {
                        //tạo file template
                        FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        fs.Write(Properties.Resources.DanhSachNhanVienExportPhongBan, 0, Properties.Resources.DanhSachNhanVienExportPhongBan.Length);
                        fs.Close();

                        //tạo dữ liệu tạm vào table để xử lý
                        System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                        cm.Connection = new System.Data.SqlClient.SqlConnection(ERP_Library.Database.ERP_Connection);
                        cm.CommandType = CommandType.StoredProcedure;

                        cm.CommandText = "spd_DanhSachNhanVien_ThuLapExport";
                        cm.Parameters.AddWithValue("@LoaiNhanVien", false);
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)cmbu_Bophan.Value);

                        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
                        da.SelectCommand = cm;
                        DataTable tbl = new DataTable("Export");
                        da.Fill(tbl);

                        //ghi dữ liệu vào file

                        string cnnExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dlg.FileName + ";Extended Properties='Excel 8.0; HDR=NO'";
                        OleDbDataAdapter daExcel = new OleDbDataAdapter("Select * From [DanhSachTheoPB$A7:C]", cnnExcel);
                        DataTable tblExcel = new DataTable("Export");
                        daExcel.Fill(tblExcel);
                        //tblExcel.Clear();
                        daExcel.InsertCommand = new OleDbCommand("Insert Into [DanhSachTheoPB$A7:C] (F1,F2,F3) Values (?,?,?)", daExcel.SelectCommand.Connection);
                        daExcel.InsertCommand.Parameters.Add("p1", OleDbType.WChar, 250, "F1"); // hoten
                        daExcel.InsertCommand.Parameters.Add("p2", OleDbType.WChar, 50, "F2");// cmnd
                        daExcel.InsertCommand.Parameters.Add("p3", OleDbType.WChar, 50, "F3");// mst

                        foreach (DataRow r in tbl.Rows)
                        {
                            tblExcel.Rows.Add(r["TenNhanVien"], r["CMND"], r["MaSoThue"]);
                        }

                        daExcel.Update(tblExcel);
                        MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start(dlg.FileName);

                        this.Close();
                        return;
                    }
                    else
                    {
                        //tạo file template
                        FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        fs.Write(Properties.Resources.CongTacVienExport, 0, Properties.Resources.CongTacVienExport.Length);
                        fs.Close();

                        //tạo dữ liệu tạm vào table để xử lý
                        System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                        cm.Connection = new System.Data.SqlClient.SqlConnection(ERP_Library.Database.ERP_Connection);
                        cm.CommandType = CommandType.StoredProcedure;

                        cm.CommandText = "spd_DanhSachCongTacVienExport";
                        cm.Parameters.AddWithValue("@LoaiNhanVien", 1);
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)cmbu_Bophan.Value);

                        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
                        da.SelectCommand = cm;
                        DataTable tbl = new DataTable("Export");
                        da.Fill(tbl);

                        //ghi dữ liệu vào file
                        string cnnExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dlg.FileName + ";Extended Properties='Excel 8.0; HDR=NO'";
                        OleDbDataAdapter daExcel = new OleDbDataAdapter("Select * From [CongTacVienExport$]", cnnExcel);
                        DataTable tblExcel = new DataTable("Export");
                        daExcel.Fill(tblExcel);
                        //tblExcel.Clear();
                        daExcel.InsertCommand = new OleDbCommand("Insert Into [CongTacVienExport$] (F1,F2,F3,F4) Values (?,?,?,?)", daExcel.SelectCommand.Connection);
                        daExcel.InsertCommand.Parameters.Add("p1", OleDbType.WChar, 250, "F1"); // hoten
                        daExcel.InsertCommand.Parameters.Add("p2", OleDbType.WChar, 50, "F2");
                        daExcel.InsertCommand.Parameters.Add("p3", OleDbType.WChar, 50, "F3");
                        daExcel.InsertCommand.Parameters.Add("p4", OleDbType.WChar, 250, "F4"); 

                        foreach (DataRow r in tbl.Rows)
                        {
                          tblExcel.Rows.Add(r["TenNhanVien"],null,r["CMND"], r["MaSoThue"]);                           
                        }

                        daExcel.Update(tblExcel);
                        MessageBox.Show("Đã xuất dữ liệu thành công.", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start(dlg.FileName);

                        this.Close();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
