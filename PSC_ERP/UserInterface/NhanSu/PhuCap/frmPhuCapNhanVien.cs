using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.Data.OleDb;
using System.IO;

namespace PSC_ERP
{
    public partial class frmPhuCapNhanVien : Form
    {
        private ERP_Library.PhuCapNhanVienList _data;
        private bool issave = false;
        private decimal _PhuCapAnTruaKCT = 0;
         //các dữ liệu config
            ERP_Library.Default_Ngay d = ERP_Library.Default_Ngay.GetDefault_Ngay();

        public frmPhuCapNhanVien()
        {
            InitializeComponent();
            _PhuCapAnTruaKCT = d.PhuCapAnTrua;
            this.FormClosed += new FormClosedEventHandler(frmPhuCapNhanVien_FormClosed);
            grdData.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(grdData_BeforeRowsDeleted);
            grdData.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(grdData_AfterCellUpdate);
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
        }

        void grdData_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Row.IsDataRow)
            {
                string t = e.Cell.Column.Key;
                if (t == "ThueSuat" || t == "PhuCap")
                {
                    decimal sotien = Convert.ToDecimal(e.Cell.Row.Cells["PhuCap"].Value);
                    decimal ts = Convert.ToDecimal(e.Cell.Row.Cells["ThueSuat"].Value);
                    e.Cell.Row.Cells["TienThue"].Value = Math.Round(sotien * ts / 100, 0);
                    e.Cell.Row.Cells["SoTien"].Value = sotien - Math.Round(sotien * ts / 100, 0);
                }
                else if (t == "TienThue")
                {
                    decimal sotien = Convert.ToDecimal(e.Cell.Row.Cells["PhuCap"].Value);
                    decimal thue = Convert.ToDecimal(e.Cell.Value);
                    e.Cell.Row.Cells["SoTien"].Value = sotien + thue;
                }
            }
        }

        void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        void frmPhuCapNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_data != null && _data.IsDirty)
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhuCapNhanVien_Load(object sender, EventArgs e)
        {
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            ERP_Library.BoPhanList bp = ERP_Library.BoPhanList.GetBoPhanList();
            ERP_Library.BoPhan allbp = ERP_Library.BoPhan.NewBoPhan("Tất cả");
            bp.Insert(0, allbp);
            cmbBoPhan.DataSource = bp;
            cmbBoPhan.Value = 0;
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbNhomPC.DataSource = ERP_Library.NhomPhuCapList.GetNhomPhuCapList();

        }

        private void LoadData()
        {
            if (_data != null && issave && _data.IsDirty)
            {
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    _data.Save();
            }
            issave = tlslblLuu.Enabled;

            if (cmbKyLuong.Value != null && cmbBoPhan.Value != null & cmbPhanLoai.Value != null && cmbKyPC.Value != null)
            {
                _data = ERP_Library.PhuCapNhanVienList.GetPhuCapNhanVienList((int)cmbKyLuong.Value, (int)cmbKyPC.Value, (int)cmbBoPhan.Value, (int)cmbPhanLoai.Value, (int)cmbNhomPC.Value);
                bdData.DataSource = _data;

            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        
        private void SaveData()
        {
            if (_data != null)
            {
                ERP_Library.KyTinhLuong ky = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value);
                if (ky.KhoaSoKy2)
                {
                    MessageBox.Show("Tháng lương này đã khóa sổ nên bạn không thể cập nhật", "Khóa sổ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                try
                {
                    grdData.UpdateData();
                    _data.Save();
                }
                catch (Exception ex)
                {
                    frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
                }
            }
            MessageBox.Show("Đã lưu dữ liệu thành công", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void Value_Changed(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            bool hl = false;
            if (cmbKyLuong.Value != null)
            {
                ERP_Library.KyTinhLuong ky = (ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject;
                if (ky.KhoaSoKy2)
                    MessageBox.Show("Tháng lương này đã khóa sổ nên bạn không thể cập nhật", "Khóa sổ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    hl = true;
            }
            tlslblLuu.Enabled = hl;
            tlslblXoa.Enabled = hl;

            if (cmbKyLuong.Value != null)
            {
                cmbKyPC.Items.Clear();
                cmbKyPC.Items.Add(0, "Tất cả");
                foreach (ERP_Library.KyTinhLuong item in ERP_Library.KyTinhLuongList.GetKyTinhPhuCap((int)cmbKyLuong.Value))
                {
                    cmbKyPC.Items.Add(item.MaKy, item.TenKy);
                }
            }

            LoadData();
        }

        private void cmbNhomPC_ValueChanged(object sender, EventArgs e)
        {
            if (cmbNhomPC.Value != null)
            {
                LoaiPhuCapList loaipclist=ERP_Library.LoaiPhuCapList.GetLoaiPhuCapByMaNhom((int)cmbNhomPC.Value);
                LoaiPhuCapChild pc=LoaiPhuCapChild.NewLoaiPhuCapChild("Tất Cả");
                loaipclist.Insert(0,pc);
                cmbPhanLoai.DataSource =loaipclist ;
                LoadData();
            }
        }
        private void toolExport_Click(object sender, EventArgs e)
        {
            //xuất ra 1 file excel từ resource sau đó insert dữ liệu vào excel
            if (cmbKyLuong.Value == null)
            {
                MessageBox.Show("Chọn kỳ lương cần lấy hệ số để xuất dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbBoPhan.Value == null)
            {
                MessageBox.Show("Chọn bộ phận cần xuất dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Excel|*.xls|All file|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //tạo file template
                FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Write(Properties.Resources.NhanVienExport, 0, Properties.Resources.NhanVienExport.Length);
                fs.Close();
                
                //tạo dữ liệu tạm vào table để xử lý
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = new System.Data.SqlClient.SqlConnection(ERP_Library.Database.ERP_Connection);
                cm.CommandText = "spd_Select_ExportNhanVien";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@MaKyTinhLuong", cmbKyLuong.Value);
                cm.Parameters.AddWithValue("@MaBoPhan", cmbBoPhan.Value);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
                da.SelectCommand = cm;
                DataTable tbl = new DataTable("Export");
                da.Fill(tbl);

                //ghi dữ liệu vào file
                string cnnExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dlg.FileName + ";Extended Properties='Excel 8.0; HDR=NO'";
                OleDbDataAdapter daExcel = new OleDbDataAdapter("Select * From [Sheet1$A7:S]", cnnExcel);
                DataTable tblExcel = new DataTable("Export");
                daExcel.Fill(tblExcel);
                daExcel.InsertCommand = new OleDbCommand("Insert Into [Sheet1$A7:S] (F1,F2,F3,F4,F5,F6,F7,F8,F9,F10,F11,F12,F13,F14,F15,F16,F17,F18) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", daExcel.SelectCommand.Connection);
                daExcel.InsertCommand.Parameters.Add("p1", OleDbType.BigInt, 8, "F1");
                daExcel.InsertCommand.Parameters.Add("p2", OleDbType.WChar, 50, "F2");
                daExcel.InsertCommand.Parameters.Add("p3", OleDbType.WChar, 50, "F3");
                daExcel.InsertCommand.Parameters.Add("p4", OleDbType.WChar, 50, "F4");
                daExcel.InsertCommand.Parameters.Add("p5", OleDbType.WChar, 250, "F5");
                daExcel.InsertCommand.Parameters.Add("p6", OleDbType.Decimal, 18, "F6");
                daExcel.InsertCommand.Parameters.Add("p7", OleDbType.Decimal, 18, "F7");
                daExcel.InsertCommand.Parameters.Add("p8", OleDbType.Decimal, 18, "F8");
                daExcel.InsertCommand.Parameters.Add("p9", OleDbType.Decimal, 18, "F9");

                daExcel.InsertCommand.Parameters.Add("p10", OleDbType.WChar, 50, "F10");
                daExcel.InsertCommand.Parameters.Add("p11", OleDbType.Double, 18, "F11");
                daExcel.InsertCommand.Parameters.Add("p12", OleDbType.Integer, 4, "F12");
                daExcel.InsertCommand.Parameters.Add("p13", OleDbType.Double, 18, "F13");
                daExcel.InsertCommand.Parameters.Add("p14", OleDbType.Integer, 4, "F14");
                daExcel.InsertCommand.Parameters.Add("p15", OleDbType.Double, 18, "F15");
                daExcel.InsertCommand.Parameters.Add("p16", OleDbType.Double, 18, "F16");
                daExcel.InsertCommand.Parameters.Add("p17", OleDbType.Double, 18, "F17");
                daExcel.InsertCommand.Parameters.Add("p18", OleDbType.Double, 18, "F18");
                daExcel.InsertCommand.Parameters.Add("p19", OleDbType.Double, 18, "F19");


                foreach (DataRow r in tbl.Rows)
                {
                    tblExcel.Rows.Add(r["MaNhanVien"], r["MaNhanVienQL"], r["CMND"], r["MaBoPhanQL"], r["TenNhanVien"], 0, 0, 0, 0, "", 
                        r["HeSoBaoHiem"], r["VKBaoHiem"], r["HeSoLuong"], r["VKLuong"], r["HeSoNoiBo"], r["HeSoPhuCap"], r["HeSoDocHai"], r["HeSoBu"], r["HeSoBoSung"]);
                }
                daExcel.Update(tblExcel);

                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(dlg.FileName);
            }
        }

        private void toolExport_Click2(object sender, EventArgs e)
        {
            //xuất dữ liệu thành file text dạng CSV (tab)  có thể import vào excel
            if (cmbKyLuong.Value == null)
            {
                MessageBox.Show("Chọn kỳ lương cần lấy hệ số để xuất dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbBoPhan.Value == null)
            {
                MessageBox.Show("Chọn bộ phận cần xuất dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Excel CSV|*.CSV|All file|*.*";
            if (dlg.ShowDialog()== DialogResult.OK)
            {
                //tạo dữ liệu tạm vào table để xử lý
                System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand();
                cm.Connection = new System.Data.SqlClient.SqlConnection(ERP_Library.Database.ERP_Connection);
                cm.CommandText = "spd_Select_ExportNhanVien";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@MaKyTinhLuong", cmbKyLuong.Value);
                cm.Parameters.AddWithValue("@MaBoPhan", cmbBoPhan.Value);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
                da.SelectCommand = cm;
                DataTable tbl = new DataTable("Export");
                da.Fill(tbl);

                System.IO.StreamWriter file = new System.IO.StreamWriter(dlg.FileName, false, System.Text.Encoding.Unicode);
                //ghi tiêu đề các cột
                string s = "";
                foreach (DataColumn col in tbl.Columns)
                {
                    if (s == "") s = col.ColumnName;
                    else s += "\t" + col.ColumnName;
                }
                file.WriteLine(s);
                //nội dung dữ liệu từ table
                foreach (DataRow r in tbl.Rows)
                {
                    s = "";
                    foreach (DataColumn c in tbl.Columns)
                    {
                        if (s == "") s = r[c].ToString();
                        else s += "\t" + r[c].ToString();
                    }
                    file.WriteLine(s);
                }
                file.Close();
                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(dlg.FileName);
            }
        }

        private void toolImport_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value == null)
            {
                MessageBox.Show("Bạn cần phải chọn kỳ lương để import dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if ( cmbKyPC.Value == null || (int)cmbKyPC.Value == 0 )
            //{
            //    if (ERP_Library.Security.CurrentUser.IsAdminNhanSu != true)
            //    {
            //        MessageBox.Show("Bạn cần phải chọn kỳ hưởng phụ cấp để import dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    else
            //    { 
                    
            //    }
            //}
            if (cmbNhomPC.Value == null || cmbPhanLoai.Value == null)
            {
                MessageBox.Show("Bạn cần phải chọn nhóm và loại phụ cấp để import dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string cnnExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dlg.FileName + ";Extended Properties='Excel 8.0;HDR=NO'";
                OleDbDataAdapter daExcel = new OleDbDataAdapter("Select * From [Sheet1$A7:S]", cnnExcel);
                DataTable tblExcel = new DataTable("Import");
                daExcel.Fill(tblExcel);
                daExcel.UpdateCommand = new OleDbCommand("Update [Sheet1$A7:S] Set F10=? Where F1=?", daExcel.SelectCommand.Connection);
                
                daExcel.UpdateCommand.Parameters.Add("p1", OleDbType.WChar, 8, "F10");
                daExcel.UpdateCommand.Parameters.Add("p2", OleDbType.Double, 8, "F1");
                daExcel.UpdateCommand.CommandTimeout = 0;
                
                //thêm dữ liệu vào object và save lại
                ERP_Library.PhuCapNhanVienList _lstNew = ERP_Library.PhuCapNhanVienList.NewPhuCapNhanVienList();
                ERP_Library.PhuCapNhanVien objNew;
                ERP_Library.BoPhanList _bophan = ERP_Library.BoPhanList.GetBoPhanList();
                bool ok;
                int _MaBoPhan = 0;
                foreach (DataRow row in tblExcel.Rows)
                {
                    ok = true;
                    if (row.IsNull("F1")) continue;
                    if (row["F1"].ToString() == "") continue;

                    ok = false;
                    foreach (ERP_Library.BoPhan bp in _bophan)
                        if (bp.MaBoPhanQL == row["F4"].ToString())
                        {
                            ok = true;
                            _MaBoPhan = bp.MaBoPhan;
                            break;
                        }

                    if (ok)
                    {
                        if (Convert.ToDecimal(row["F6"]) > 0)
                        {

                            objNew = ERP_Library.PhuCapNhanVien.NewPhuCapNhanVien();
                            objNew.MaKyTinhLuong = (int)cmbKyLuong.Value;
                            if (ERP_Library.Security.CurrentUser.IsAdminNhanSu)
                            {
                                if (cmbKyPC.Value == null || (int)cmbKyPC.Value == 0)
                                {
                                    objNew.MaKyPhuCap = (int)cmbKyLuong.Value;
                                }
                            }
                            else
                            {
                                objNew.MaKyPhuCap = (int)cmbKyPC.Value;
                            }

                            objNew.MaLoaiPhuCap = (int)cmbPhanLoai.Value;
                            objNew.TenPhuCap = cmbPhanLoai.Text;
                            objNew.MaNhanVien = Convert.ToInt64(row["F1"]);
                            objNew.MaBoPhan = _MaBoPhan;
                            objNew.PhuCap = Convert.ToDecimal(row["F6"]);
                            //objNew.SoTien = objNew.PhuCap;

                            objNew.ThueSuat = Convert.ToDecimal(row["F7"]);
                            objNew.TienThue = Convert.ToDecimal(row["F8"]);
                            objNew.SoTien = Convert.ToDecimal(row["F9"]);
                            _lstNew.Add(objNew);
                            row["F10"] = "OK";
                        }
                    }
                    else
                    {
                        row["F10"] = "Lỗi";
                    }

                }
                daExcel.Update(tblExcel);
                _lstNew.Save();
                MessageBox.Show("Đã import dữ liệu thành công!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            
       }
    }
}