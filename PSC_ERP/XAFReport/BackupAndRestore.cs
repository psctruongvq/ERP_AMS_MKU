using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using ERP_Library.Security;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class BackupAndRestore : Form
    {
        #region Properties
        ReportTemplateList _reportList;
        UserList _userList;
        #endregion

        #region Load
        public BackupAndRestore()
        {
            InitializeComponent();
            LoadForm();
        }
        #endregion

        #region Process
        private void LoadForm()
        {
            _userList = UserList.GetUserList();
            bdUser.DataSource = _userList;
            FilterCombo f1 = new FilterCombo(grd_Report, "ID", "TenBaoCao");
        }
        #endregion

        #region Event
        private void btn_View_Click(object sender, EventArgs e)
        {
            if (cmbNhom.ActiveRow != null)
            {
                _reportList = ReportTemplateList.GetReportTemplateList_ByUserId((int)cmbNhom.ActiveRow.Cells["UserId"].Value);
                bdReport.DataSource = _reportList;
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Filter = "Report Data|*.bkreport|All file|*.*";
                    dlg.AddExtension = true;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        SqlConnection connec = new SqlConnection(Database.ERP_Connection);
                        connec.Open();

                        SqlCommand cmd = new SqlCommand();
                        string query = "SELECT [ID], [Data], TenBaoCao, TenPhuongThuc, ThuMuc, DenNgay, UserID, SoTTSapXep FROM [dbo].[ReportTemplate] WHERE ID = @Id and UserID = @UserID and DenNgay = @DenNgay";
                        cmd.CommandText = query;
                        cmd.Connection = connec;
                        cmd.CommandType = CommandType.Text;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable("ReportTemplate", "PSC_ERP"))
                            {
                                StringBuilder sb = new StringBuilder();
                                foreach (UltraGridRow row in grd_Report.Rows)
                                {
                                    if ((bool)row.Cells["Chon"].Value)
                                    {
                                        cmd.Parameters.Clear();
                                        cmd.Parameters.AddWithValue("@Id", row.Cells["ID"].Value.ToString());
                                        cmd.Parameters.AddWithValue("@UserID", row.Cells["UserID"].Value.ToString());
                                        cmd.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime( row.Cells["DenNgay"].Value).ToString("MM/dd/yyyy"));
                                        da.Fill(dt);
                                        sb.AppendLine(" - " + row.Cells["Chon"].Value.ToString());
                                    }
                                }
                                dt.WriteXml(dlg.FileName);
                            }
                        }
                        connec.Close();
                        MessageBox.Show(this, "Export dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Report Data|*.bkreport|All file|*.*";
                dlg.AddExtension = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (MessageBox.Show(String.Format("Bạn có muốn import dữ liệu mẫu báo cáo mới từ file {0} không?", dlg.FileName), "Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    DataTable tbl;
                    using (tbl = new DataTable("ReportTemplate", "PSC_ERP"))
                    {
                        tbl.Columns.Add("ID", typeof(string));
                        tbl.Columns.Add("TenBaoCao", typeof(string));
                        tbl.Columns.Add("Data", typeof(byte[]));
                        tbl.Columns.Add("TenPhuongThuc", typeof(string));
                        tbl.Columns.Add("ThuMuc", typeof(int));
                        tbl.Columns.Add("DenNgay", typeof(DateTime));
                        tbl.Columns.Add("UserID", typeof(int));
                        tbl.Columns.Add("SoTTSapXep", typeof(int));
                        tbl.ReadXml(dlg.FileName);
                    }

                    SqlConnection connec = new SqlConnection(Database.ERP_Connection);
                    connec.Open();

                    int record = 0;

                    SqlCommand cm = new SqlCommand("", connec);
                    foreach (DataRow row in tbl.Rows)
                    {
                        record++;
                        ReportTemplate report = ReportTemplate.GetReportTemplateExit(row["ID"].ToString(), (int)cmbNhom.ActiveRow.Cells["UserId"].Value, DateTime.Today);
                        if (report.Data != null)
                        {
                            //Nếu đã tồn tại thì cập nhật dữ liệu lại
                            cm.CommandText = "Update ReportTemplate Set Data = @Data, TenBaoCao = @TenBaoCao, TenPhuongThuc = @TenPhuongThuc, DenNgay = @DenNgay, SoTTSapXep = @SoTTSapXep Where ID = @ID and UserID = @UserID and DenNgay = @DenNgay";
                            cm.Parameters.Clear();
                            cm.Parameters.AddWithValue("@Data", row["Data"]);
                            cm.Parameters.AddWithValue("@TenBaoCao", row["TenBaoCao"]);
                            cm.Parameters.AddWithValue("@TenPhuongThuc", row["TenPhuongThuc"]);
                            cm.Parameters.AddWithValue("@ThuMuc", row["ThuMuc"]);
                            cm.Parameters.AddWithValue("@DenNgay", DateTime.Today);
                            cm.Parameters.AddWithValue("@UserID", cmbNhom.ActiveRow.Cells["UserId"].Value);
                            cm.Parameters.AddWithValue("@ID", row["ID"]);
                            cm.Parameters.AddWithValue("@SoTTSapXep", row["SoTTSapXep"]);
                            cm.ExecuteNonQuery(); ;
                        }
                        else
                        {
                            //Nếu chưa tồn tại thì insert vào
                            cm.CommandText = String.Format("Insert into ReportTemplate (Id, Data, TenBaoCao, TenPhuongThuc, ThuMuc, DenNgay, UserID, SoTTSapXep) Values (@Id, @Data, @TenBaoCao, @TenPhuongThuc, @ThuMuc, @DenNgay, @UserID, @SoTTSapXep)");
                            cm.Parameters.Clear();
                            cm.Parameters.AddWithValue("@Data", row["Data"]);
                            cm.Parameters.AddWithValue("@TenBaoCao", row["TenBaoCao"]);
                            cm.Parameters.AddWithValue("@TenPhuongThuc", row["TenPhuongThuc"]);
                            cm.Parameters.AddWithValue("@ThuMuc", row["ThuMuc"]);
                            cm.Parameters.AddWithValue("@DenNgay", DateTime.Today);
                            cm.Parameters.AddWithValue("@UserID", cmbNhom.ActiveRow.Cells["UserId"].Value);
                            cm.Parameters.AddWithValue("@ID", row["ID"]);
                            cm.Parameters.AddWithValue("@SoTTSapXep", row["SoTTSapXep"]);
                            cm.ExecuteNonQuery();
                        }
                    }

                    connec.Close();
                    MessageBox.Show(this, String.Format("Đã cập nhật {0} báo cáo thành công.", record), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        #endregion
    }
}
