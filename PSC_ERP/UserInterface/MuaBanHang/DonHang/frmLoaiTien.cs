using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmLoaiTien : Form
    {
        #region Properties
        LoaiTienList _loaiTienList;
        HamDungChung hamDungChung = new HamDungChung();
        #endregion

        #region contructors
        public frmLoaiTien()
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
        }
        #endregion

        #region Khai Báo Sự Kiện
        private void KhaiBaoSuKien()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(ultraGridLoaiTien);
        }
        #endregion 

        #region KhoiTao()
        private void KhoiTao()
        {
            _loaiTienList = LoaiTienList.GetLoaiTienList();
            loaiTienListBindingSource.DataSource = _loaiTienList;
        }
        #endregion

        #region KiemTraDuLieu()
        private Boolean KiemTraDuLieu()
        {
            Boolean kq =true;
            if (txtMaLoaiTien.Text == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Loại Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiTien.Focus();
                kq = false;
                return kq;
            }
            else if (txtTenLoaiTien.Text == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Loại Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiTien.Focus();
                kq = false;
                return kq;
            }
            else if (ultNumericEditorTyGiaQuyDoi.Value== null)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tỷ Giá Quy Đổi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ultNumericEditorTyGiaQuyDoi.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }

        private Boolean KiemTraDuLieu(LoaiTien loaiTien)
        {
            Boolean kq = true;
            if (loaiTien.MaLoaiQuanLy == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Loại Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiTien.Focus();
                kq = false;
                return kq;
            }
            else if (loaiTien.TenLoaiTien == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Loại Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiTien.Focus();
                kq = false;
                return kq;
            }
            else if (loaiTien.TiGiaQuyDoi == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tỷ Giá Quy Đổi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ultNumericEditorTyGiaQuyDoi.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }
        #endregion

        #region ultraGridLoaiTien_InitializeLayout
        private void ultraGridLoaiTien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ultraGridLoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiTien"].Hidden = true;            
            ultraGridLoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.Caption = "Mã Loại Tiền";
            ultraGridLoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.VisiblePosition = 1;
            ultraGridLoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.Caption = "Tên Loại Tiền";
            ultraGridLoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.VisiblePosition = 2;
            ultraGridLoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.Caption = "Tỉ Giá Quy Đổi";
            ultraGridLoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.VisiblePosition = 3;            
            this.ultraGridLoaiTien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraGridLoaiTien.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultraGridLoaiTien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion

        #region thêmToolStripMenuItem_Click
        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_loaiTienList.Count == 0)
            {
                LoaiTien loaiTien = LoaiTien.NewLoaiTien();
                _loaiTienList.Add(loaiTien);
                ultraGridLoaiTien.ActiveRow = ultraGridLoaiTien.Rows[_loaiTienList.Count-1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    LoaiTien loaiTien = LoaiTien.NewLoaiTien();
                    _loaiTienList.Add(loaiTien);
                    ultraGridLoaiTien.ActiveRow = ultraGridLoaiTien.Rows[_loaiTienList.Count-1];
                }
            }
            
        }
        #endregion

        #region luuToolStripMenuItem_Click
        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaiTien loaiTien;
            for (int i=0; i< _loaiTienList.Count ; i++)
            {

                loaiTien = _loaiTienList[i];
                if (loaiTien.MaLoaiQuanLy == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Loại Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraGridLoaiTien.ActiveRow = ultraGridLoaiTien.Rows[i];
                    txtMaLoaiTien.Focus();
                    return;
                }
                else if (loaiTien.TenLoaiTien == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Loại Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraGridLoaiTien.ActiveRow = ultraGridLoaiTien.Rows[i];
                    txtTenLoaiTien.Focus();                    
                    return ;
                }
                else if (loaiTien.TiGiaQuyDoi == 0)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tỷ Giá Quy Đổi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                    ultraGridLoaiTien.ActiveRow = ultraGridLoaiTien.Rows[i];
                    ultNumericEditorTyGiaQuyDoi.Focus();
                    return ;
                }
            }
            if (MessageBox.Show(this, "Bạn Có Muốn Lưu Dữ Liệu Hiện Tại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    _loaiTienList.ApplyEdit();
                    _loaiTienList.Save();
                    KhoiTao();
                }
                catch (ApplicationException ex)
                { 
                
                }
            }
        }
        #endregion       

        #region thoatToolStripMenuItem_Click
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region xóaToolStripMenuItem_Click
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ultraGridLoaiTien.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else ultraGridLoaiTien.DeleteSelectedRows();
        }
        #endregion

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new Report.Report_MuaBan.DanhSachLoaiTien();
            DataSet dataSet = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from View_LoaiTien";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "View_LoaiTien";

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_Report_ReportHeader";
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            adapter = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";

            dataSet.Tables.Add(table);
            dataSet.Tables.Add(table1);

            Report.SetDataSource(dataSet);
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
        #endregion 

        private void ultNumericEditorTyGiaQuyDoi_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmLoaiTien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Loai Tien", "Help_BanHang.chm");
            }
        }
    }
}