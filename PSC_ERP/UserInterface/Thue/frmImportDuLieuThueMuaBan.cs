using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmImportDuLieuThueMuaBan : Form
    {            
        HamDungChung hamDungChung = new HamDungChung();    
      
        Util util = new Util();
        int _loaiip = 1;
      
        public frmImportDuLieuThueMuaBan()
        {
            InitializeComponent();
            cbo_Ky.DataSource = KyList.GetKyList();
            dtmp_Ngay.Value = DateTime.Now;
            KhoiTao();
        }

        private void cbo_Ky_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cbo_Ky.DisplayLayout.Bands[0].Columns["Tenky"].Header.Caption = "Kỳ";
            cbo_Ky.DisplayLayout.Bands[0].Columns["Maky"].Hidden = true;
            cbo_Ky.DisplayLayout.Bands[0].Columns["KhoaSo"].Hidden = true;
            cbo_Ky.DisplayLayout.Bands[0].Columns["Ngaybatdau"].Header.Caption = "Bắt đầu";
            cbo_Ky.DisplayLayout.Bands[0].Columns["Ngayketthuc"].Header.Caption = "Kết thúc";
        }

        public void KhoiTao()
        {
            if (cbo_Ky.ActiveRow == null)
            {
                cbo_Ky.Appearance.BackColor = Color.PeachPuff;
                return;
            }
            else
            {
                cbo_Ky.Appearance.BackColor = Color.White;
            }
        }

        #region Event
        private void tlslblThoat_Click(object sender, EventArgs e)
        {        
            this.Close();         
        }         
       
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
          
        }         

        private void tlsxem_Click(object sender, EventArgs e)
        {
            KhoiTao();
        }

        private void tlsImportmua_Click(object sender, EventArgs e)
        {
            if (cbo_Ky.ActiveRow == null)
            {
                MessageBox.Show(this, "Vui lòng chọn kỳ tính thuế để import dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbo_Ky.Appearance.BackColor = Color.PeachPuff;
                return;
            }

            if (kiemtradacodl(Convert.ToInt32(cbo_Ky.Value), 1))
            {
                DialogResult dlg= MessageBox.Show(this, "Kỳ hiện tại đã có dữ liệu import. Chương trình sẽ thực hiện import dữ liệu mới và xóa đi dữ liệu cũ. Thực hiện (Yes/No) ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dlg == DialogResult.Yes)
                {
                    // import du lieu
                    cbo_Ky.Appearance.BackColor = Color.White;
                    _loaiip = 1;
                    try
                    {
                        int sodong = 0;
                        sodong = ImportDulieu(_loaiip, ERP_Library.Security.CurrentUser.Info.UserID);
                        if (sodong > 0)
                            MessageBox.Show(this, "Dữ liệu đã được import thành công " + sodong.ToString() + " dòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.ToString());
                    }
                }
            }          
        }

        private void tlsimportban_Click(object sender, EventArgs e)
        {
            if (cbo_Ky.ActiveRow == null)
            {
                MessageBox.Show(this, "Vui lòng chọn kỳ tính thuế để import dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbo_Ky.Appearance.BackColor = Color.PeachPuff;
                return;
            }
            if (kiemtradacodl(Convert.ToInt32(cbo_Ky.Value), 2))
            {
                DialogResult dlg = MessageBox.Show(this, "Kỳ hiện tại đã có dữ liệu import. Chương trình sẽ thực hiện import dữ liệu mới và xóa đi dữ liệu cũ. Thực hiện (Yes/No) ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dlg == DialogResult.Yes)
                {
                    // import du lieu
                    cbo_Ky.Appearance.BackColor = Color.White;
                    _loaiip = 2;
                    try
                    {
                        int sodong = 0;
                        sodong = ImportDulieu(_loaiip, ERP_Library.Security.CurrentUser.Info.UserID);
                        if (sodong > 0)
                            MessageBox.Show(this, "Dữ liệu đã được import thành công " + sodong.ToString() + " dòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.ToString());
                    }
                }
            }
        }
        #endregion

        #region Process
        private int ImportDulieu(int Loai, long manhanvien) // 1 mua 2 ban
        {
            int sodongimport = 0;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Excel(*.xls)|*.xls|All file|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dlg.FileName + ";Extended Properties='Excel 8.0;HDR=NO'";
                OleDbDataAdapter dathue = new OleDbDataAdapter("Select * from [Sheet1$]", strConn);
                DataTable tbl_thue = new DataTable("MuaVaoBanRa");
                dathue.Fill(tbl_thue);

                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletetblDShoadondichvu_import";
                        cm.Parameters.AddWithValue("@MaKy", Convert.ToInt32(cbo_Ky.Value));
                        cm.Parameters.AddWithValue("@Loai", Loai);
                        cm.ExecuteNonQuery();
                    }
                }
                for (int i = 1; i < tbl_thue.Rows.Count; i++)
                {
                    using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_inserttblDShoadondichvu_import";
                            cm.Parameters.AddWithValue("@MaKy", Convert.ToInt32(cbo_Ky.Value));
                            cm.Parameters.AddWithValue("@SoSerial", tbl_thue.DefaultView[i].Row["F2"].ToString());
                            cm.Parameters.AddWithValue("@SoHoaDon", tbl_thue.DefaultView[i].Row["F3"].ToString());
                            cm.Parameters.AddWithValue("@NgayLap", Convert.ToDateTime(dtmp_Ngay.Value).Date);
                            cm.Parameters.AddWithValue("@TenDoiTac", tbl_thue.DefaultView[i].Row["F5"].ToString());
                            cm.Parameters.AddWithValue("@MaSoThue", tbl_thue.DefaultView[i].Row["F6"].ToString());
                            cm.Parameters.AddWithValue("@MatHang", tbl_thue.DefaultView[i].Row["F7"].ToString());
                            cm.Parameters.AddWithValue("@SoTien", Convert.ToDecimal(tbl_thue.DefaultView[i].Row["F8"]));
                            cm.Parameters.AddWithValue("@TienThue", tbl_thue.DefaultView[i].Row["F10"].ToString());
                            cm.Parameters.AddWithValue("@ThueSuat", Convert.ToDecimal(tbl_thue.DefaultView[i].Row["F9"]) * 100);
                            cm.Parameters.AddWithValue("@TienSauThue", Convert.ToDecimal(tbl_thue.DefaultView[i].Row["F8"]) - Convert.ToDecimal(tbl_thue.DefaultView[i].Row["F10"]));
                            cm.Parameters.AddWithValue("@GhiChu", tbl_thue.DefaultView[i].Row["F11"].ToString());
                            cm.Parameters.AddWithValue("@NgayLapHD", Convert.ToDateTime(tbl_thue.DefaultView[i].Row["F4"]).Date);
                            cm.Parameters.AddWithValue("@Loai", Loai);
                            cm.Parameters.AddWithValue("@MaNhanVien", manhanvien);
                            cm.ExecuteNonQuery();
                            sodongimport++;
                        }
                    }
                }
                if (Loai == 1)
                    grd_Muavao.DataSource = tbl_thue;
                else
                    grd_Banra.DataSource = tbl_thue;
            }
            return sodongimport;
        }
        #endregion

        private void cbo_Ky_AfterCloseUp(object sender, EventArgs e)
        {
            KhoiTao();
        }

        private bool kiemtradacodl(int maky,int Loai)
        {            
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                int sorecord = 0;
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Kiemtradacodulieu_import_muaban";
                    cm.Parameters.AddWithValue("@MaKy", Convert.ToInt32(cbo_Ky.Value));
                    cm.Parameters.AddWithValue("@Loai", Loai);
                    sorecord=(int) cm.ExecuteScalar();
                    if (sorecord == 0)
                        return false;
                }
            }
            return true;  
        }
    }
}