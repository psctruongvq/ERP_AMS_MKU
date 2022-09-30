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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmDanhSachHoaDon : Form
    {
        Util util = new Util();
        private HoaDonList _hoaDonList;
        private byte _quyTrinh=0;
        private byte _loaiHoaDon=0;
        private byte _loai = 0;
        private bool _nhapXuat = false;
        private byte _doiTuongMuaBan = 0;
                
        #region Contructors
        public frmDanhSachHoaDon()
        {
            InitializeComponent();
            KhoiTao();
            Invisible();
        }

        public frmDanhSachHoaDon( byte quyTrinh,bool nhapXuat, byte loai, byte doiTuongMuaBan)
        {
            InitializeComponent();
            _quyTrinh = quyTrinh;
            _loai = loai;
            _doiTuongMuaBan = doiTuongMuaBan;
            _nhapXuat = nhapXuat;
            KhoiTao();
            Invisible();
        }
        #endregion 

        #region Khởi Tạo
        private void KhoiTao()
        {
            //if (_nhapXuat == false && _loai != 14)
            //{
            //    _loaiHoaDon = 0;
            //}
            //else if (_nhapXuat == true && _loai != 14)
            //{
            //    _loaiHoaDon = 1;
            //}
            //else if (_nhapXuat == false && _loai == 14)
            //{
            //    _loaiHoaDon = 2;
            //}

            _loaiHoaDon = _loai;

            if(_nhapXuat == true && _loai == 2)
            {
                _loaiHoaDon = 3;
            }
            _hoaDonList = HoaDonList.GetHoaDonMuaBanList(_loaiHoaDon,_quyTrinh, Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value), _doiTuongMuaBan, txt_ThongTin.Text, txt_ThongTinHHDV.Text);
            hoaDonListBindingSource.DataSource = _hoaDonList;
        }
        #endregion 

        #region Invisible Button
        private void Invisible()
        {
            tlslblXoa.Available = false;
            tlslblUndo.Available = false;         
            tlslblTroGiup.Available = false;
        }
        #endregion 

        #region Lưu Dữ Liệu
        private Boolean LuuDuLieu()
        {
            Boolean kq = true;
            try
            {
                _hoaDonList.ApplyEdit();
                _hoaDonList.Save();
            }
            catch (Exception ex)
            {
                kq = false;
            }
            return kq;
        }
        #endregion 

        #region ultragrdDSDonHang_InitializeLayout

        private void grdu_DanhSachHoaDon_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdu_DanhSachHoaDon.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachHoaDon.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }           
            
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Hidden = false;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.Caption = "Số Serial";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.VisiblePosition = 2;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Hidden = false;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.VisiblePosition = 1;

            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 3;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Format = "###,###,###,###,###";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right;
 
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 0;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].MaskInput = "{LOC}dd/mm/yyyy";

            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 8;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;

            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Đối Tác";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 9;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;

            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Số CMND";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 10;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;

        }
        #endregion 

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            frmHoaDon dlg = new frmHoaDon(0,0,false, _doiTuongMuaBan);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                _hoaDonList = HoaDonList.GetHoaDonMuaBanList(_loaiHoaDon,_quyTrinh,Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value), _doiTuongMuaBan);
                hoaDonListBindingSource.DataSource = _hoaDonList;
                if (_hoaDonList.Count == 0)
                {
                    MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DanhSachHoaDon.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else grdu_DanhSachHoaDon.DeleteSelectedRows();

        }
        #endregion

        #region tlslblTim_Click
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            _hoaDonList = HoaDonList.GetHoaDonMuaBanList(_loaiHoaDon,_quyTrinh,Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value), _doiTuongMuaBan, txt_ThongTin.Text,txt_ThongTinHHDV.Text);
            hoaDonListBindingSource.DataSource = _hoaDonList;
            if (_hoaDonList.Count == 0)
            {
                MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HoaDon _hoaDon;
            if (grdu_DanhSachHoaDon.ActiveRow != null)
            {
                _hoaDon = HoaDon.GetHoaDon((long)(grdu_DanhSachHoaDon.ActiveRow.Cells["MaHoaDon"].Value));
                ReportDocument Report = new Report.Report_MuaBan.Report_HoaDon();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_HoaDon";
                command.Parameters.AddWithValue("@MaHoaDon", _hoaDon.MaHoaDon);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_HoaDon;1";
                Report.SetDataSource(table);

                //  Report.SetParameterValue("@SoHopDong", _HopDongMuaBan.SoHopDong);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();

            }
            
        }
        #endregion

        #region grdu_DanhSachHoaDon_DoubleClickRow
        private void grdu_DanhSachHoaDon_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            HoaDon _hoaDon = HoaDon.NewHoaDon();
            
            _hoaDon = HoaDon.GetHoaDon((long)grdu_DanhSachHoaDon.ActiveRow.Cells["MaHoaDon"].Value);
            if (_quyTrinh == 0)
            {
                frmHoaDon dlg = new frmHoaDon(_hoaDon);
                dlg.ShowDialog();
            }
            else
            {
                DonHangBan _donHangBan = DonHangBan.GetDonHangBan(_hoaDon.MaDonHang);
                frmHoaDonTuDonHang dlg = new frmHoaDonTuDonHang(_hoaDon,_donHangBan);
                dlg.ShowDialog();
            }
        }
        #endregion 

        #region frmDanhSachHoaDon_KeyDown
        private void frmDanhSachHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Danh Sach Hoa Don", "Help_BanHang.chm");
            }
        }
        #endregion

        #region tlslblTroGiup_Click
        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Danh Sach Hoa Don", "Help_BanHang.chm");
        }
        #endregion 

    }
}