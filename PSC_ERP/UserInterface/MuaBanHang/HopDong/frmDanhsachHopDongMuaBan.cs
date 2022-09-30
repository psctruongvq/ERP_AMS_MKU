using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmDanhsachHopDongMuaBan : Form
    {
        HopDongMuaBanList _hopDongMuaBanList;
        Util util = new Util();
        bool _muaBan;

        #region Contructors
        public frmDanhsachHopDongMuaBan(bool muaBan)
        {
            InitializeComponent();
            _muaBan= muaBan;
            Invisible();
        }
        #endregion

        #region Invisible Button
        private void Invisible()
        {
            //tlslblXoa.Available = false;
            //tlslblUndo.Available = false;         
            tlslblTroGiup.Available = false;
        }
        #endregion 

        #region LuuDuLieu()

        private Boolean LuuDuLieu()
        {
            Boolean kq = true;
            try
            {
                _hopDongMuaBanList.ApplyEdit();
                _hopDongMuaBanList.Save();
            }
            catch (Exception ex)
            {
                kq = false;
            }
            return kq;
        }
        #endregion

        #region grdu_DanhSachHopDong_InitializeLayout
        private void grdu_DanhSachHopDong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            this.grdu_DanhSachHopDong.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachHopDong.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.Caption = "Số Hợp Đồng";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.VisiblePosition = 1;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["SoHopDong"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TenHopDong"].Header.Caption = "Tên Hợp Đồng";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TenHopDong"].Header.VisiblePosition = 2;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TenHopDong"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 3;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayLap"].MaskInput = "{LOC}dd/mm/yyyy";

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayKy"].Header.Caption = "Ngày Ký";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayKy"].Header.VisiblePosition = 4;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayKy"].Hidden = false;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayKy"].Format = "dd/MM/yyyy";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayKy"].MaskInput = "{LOC}dd/mm/yyyy";

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 5;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TongTien"].Format = "###,###,###,###,###";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayHetHan"].Header.Caption = "Ngày Hết Hạn";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayHetHan"].Header.VisiblePosition = 6;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayHetHan"].Hidden = false;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayHetHan"].Format = "dd/MM/yyyy";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayHetHan"].MaskInput = "{LOC}dd/mm/yyyy";
            
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 7;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 8;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Đối Tác";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 9;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Số CMND";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 10;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TinhTrangString"].Header.Caption = "Tình Trạng";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TinhTrangString"].Header.VisiblePosition = 10;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TinhTrangString"].Hidden = false;
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            frmHopDong dlg = new frmHopDong(_muaBan);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                _hopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),0,_muaBan);
                hopDongMuaBanListBindingSource.DataSource = _hopDongMuaBanList;
                if (_hopDongMuaBanList.Count == 0)
                {
                    MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DanhSachHopDong.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else grdu_DanhSachHopDong.DeleteSelectedRows();

        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.luudulieu, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (LuuDuLieu() == true)
                {
                    MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }    

        }
        #endregion

        #region grdu_DanhSachHopDong_DoubleClickRow
        private void grdu_DanhSachHopDong_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            HopDongMuaBan _hopDongMuaBan;
            _hopDongMuaBan= HopDongMuaBan.GetHopDongMuaBan((long)(grdu_DanhSachHopDong.ActiveRow.Cells["MaHopDong"].Value));
            frmHopDong dlg = new frmHopDong(_hopDongMuaBan);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                _hopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),0,_muaBan);
                hopDongMuaBanListBindingSource.DataSource = _hopDongMuaBanList;
                if (_hopDongMuaBanList.Count == 0)
                {
                    MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region tlslblTim_Click
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            _hopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanList(0, txt_ThongTin.Text, _muaBan, txt_ThongTinHHDV.Text, Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value));
            hopDongMuaBanListBindingSource.DataSource = _hopDongMuaBanList;
            if (_hopDongMuaBanList.Count == 0)
            {
                MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
             HopDongMuaBan _hopDongMuaBan;
             if (grdu_DanhSachHopDong.ActiveRow != null)
             {
                 _hopDongMuaBan = HopDongMuaBan.GetHopDongMuaBan((long)(grdu_DanhSachHopDong.ActiveRow.Cells["MaHopDong"].Value));
                 ReportDocument Report = new Report.Report_MuaBan.Report_HopDongMuaBan();

                 SqlCommand command = new SqlCommand();
                 command.CommandType = CommandType.StoredProcedure;
                 command.CommandText = "spd_Report_HopDongMuaBan";
                 command.Parameters.AddWithValue("@MaHopDong", _hopDongMuaBan.MaHopDong);
                 command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                 SqlDataAdapter adapter = new SqlDataAdapter(command);
                 DataTable table = new DataTable();
                 adapter.Fill(table);
                 table.TableName = "spd_Report_HopDongMuaBan;1";



                 SqlCommand command1 = new SqlCommand();
                 command1.CommandType = CommandType.StoredProcedure;                
                 command1.CommandText = "spd_Report_CTHopDongMuaBan";
                 command1.Parameters.AddWithValue("@MaHopDong", _hopDongMuaBan.MaHopDong);
                 command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                 DataTable table1 = new DataTable();
                 adapter = new SqlDataAdapter(command1);
                 adapter.Fill(table1);                 
                 table1.TableName = "spd_Report_CTHopDongMuaBan;1";

                 SqlCommand command2 = new SqlCommand();
                 command2.CommandType = CommandType.StoredProcedure;                 
                 command2.CommandText = "spd_Report_DotThanhToan";
                 command2.Parameters.AddWithValue("@MaHopDong", _hopDongMuaBan.MaHopDong);
                 command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                 DataTable table2 = new DataTable();
                 adapter = new SqlDataAdapter(command2);
                 adapter.Fill(table2);
                 table2.TableName = "spd_Report_DotThanhToan;1";

                 SqlCommand command3 = new SqlCommand();
                 command3.CommandType = CommandType.StoredProcedure;                 
                 command3.CommandText = "spd_Report_DotGiaoNhan";
                 command3.Parameters.AddWithValue("@MaHopDong", _hopDongMuaBan.MaHopDong);
                 command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                 DataTable table3 = new DataTable();
                 adapter = new SqlDataAdapter(command3);
                 adapter.Fill(table3);                
                 table3.TableName = "spd_Report_DotGiaoNhan;1";


                 DataSet _myDataset = new DataSet();
                 
                 _myDataset.Tables.Add(table);
                 _myDataset.Tables.Add(table1);
                 _myDataset.Tables.Add(table2);
                 _myDataset.Tables.Add(table3);
                 

                 Report.SetDataSource(_myDataset);

                 Report.SetParameterValue("@MaHopDong", _hopDongMuaBan.MaHopDong);
                 //Report.SetParameterValue("@MaHopDong", _hopDongMuaBan.MaHopDong, "CT_HopDongMuaBan");               
                 frmHienThiReport dlg = new frmHienThiReport();
                 dlg.crytalView_HienThiReport.ReportSource = Report;
                 dlg.Show();
             }
         }
        #endregion

        private void frmDanhsachHopDongMuaBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Danh Sach Hop Dong", "Help_BanHang.chm");
            }
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Danh Sach Hop Dong", "Help_BanHang.chm");
        }     
     }
}