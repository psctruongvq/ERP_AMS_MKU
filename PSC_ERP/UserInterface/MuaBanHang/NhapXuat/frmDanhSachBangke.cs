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
    public partial class frmDanhSachBangke : Form
    {
        #region properties
        Util util = new Util();
        private LenhNhapXuatMuaBanList _lenhNhapXuatMuaBanList;
        private byte _quyTrinh = 0;
        private byte _loai = 0;
        private bool _nhapXuat = false;
        private byte _doiTuongNhapXuat = 0;

        #endregion

        #region frmDanhSachBangke
        public frmDanhSachBangke()
        {
            InitializeComponent();
            KhoiTao();
        }
        public frmDanhSachBangke(byte quyTrinh, byte loai, bool nhapXuat)
        {
            InitializeComponent();
            _quyTrinh = quyTrinh;
            _loai = loai;
            _nhapXuat = nhapXuat;
            KhoiTao();
        }
        public frmDanhSachBangke(byte quyTrinh, byte loai, bool nhapXuat, byte doiTuongNhapXuat)
        {
            InitializeComponent();
            _quyTrinh = quyTrinh;
            _loai = loai;
            _nhapXuat = nhapXuat;
            _doiTuongNhapXuat = doiTuongNhapXuat;
            KhoiTao();
        }
        #endregion

        #region KhoiTao
        private void KhoiTao()
        {
            _lenhNhapXuatMuaBanList = LenhNhapXuatMuaBanList.GetLenhNhapXuatMuaBanList( _quyTrinh,_loai, Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value), _nhapXuat, _doiTuongNhapXuat);
            lenhNhapXuatMuaBanListBindingSource.DataSource = _lenhNhapXuatMuaBanList;
            
        }
        #endregion

        #region grdu_DanhSachLenhNhapXuat_InitializeLayout
        private void grdu_DanhSachLenhNhapXuat_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdu_DanhSachLenhNhapXuat.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachLenhNhapXuat.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["SoBangKe"].Hidden = false;
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["SoBangKe"].Header.Caption = "Số Bảng Kê";
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["SoBangKe"].Header.VisiblePosition = 1;

            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 2;
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right;
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["TongTien"].Format = "###,###,###,###,###";
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn";

            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 0;
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["NgayLap"].MaskInput = "{LOC}dd/mm/yyyy";

            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["TinhTrangString"].Hidden = false;
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["TinhTrangString"].Header.Caption = "Tình Trạng";
            grdu_DanhSachLenhNhapXuat.DisplayLayout.Bands[0].Columns["TinhTrangString"].Header.VisiblePosition = 4;
            
        }
        #endregion

        #region LuuDuLieu
        private Boolean LuuDuLieu()
        {
            Boolean kq = true;
            try
            {
                _lenhNhapXuatMuaBanList.ApplyEdit();
                _lenhNhapXuatMuaBanList.Save();
            }
            catch (Exception ex)
            {
                kq = false;
            }
            return kq;
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            frmBangKeNhapDonHangChuan dlg = new frmBangKeNhapDonHangChuan(0, 0,false);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                _lenhNhapXuatMuaBanList = LenhNhapXuatMuaBanList.GetLenhNhapXuatMuaBanList(_loai, _quyTrinh, Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value), _nhapXuat, _doiTuongNhapXuat);
                lenhNhapXuatMuaBanListBindingSource.DataSource = _lenhNhapXuatMuaBanList;
                if (_lenhNhapXuatMuaBanList.Count == 0)
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
            if (grdu_DanhSachLenhNhapXuat.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else grdu_DanhSachLenhNhapXuat.DeleteSelectedRows();

        }
        #endregion

        #region tlslblTim_Click
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            _lenhNhapXuatMuaBanList = LenhNhapXuatMuaBanList.GetLenhNhapXuatMuaBanList(_quyTrinh, _loai, Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),_nhapXuat, _doiTuongNhapXuat);
            lenhNhapXuatMuaBanListBindingSource.DataSource = _lenhNhapXuatMuaBanList;
            if (_lenhNhapXuatMuaBanList.Count == 0)
            {
                MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region grdu_DanhSachLenhNhapXuat_DoubleClickRow
        private void grdu_DanhSachLenhNhapXuat_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            LenhNhapXuatMuaBan _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.GetLenhNhapXuatMuaBan(((LenhNhapXuatMuaBan)lenhNhapXuatMuaBanListBindingSource.Current).MaLenhNhapXuat);
            if (_lenhNhapXuatMuaBan.Loai == 1 && _lenhNhapXuatMuaBan.QuyTrinh == 0)
            {
                frmBangKeXuatNhapKho dlg = new frmBangKeXuatNhapKho(_lenhNhapXuatMuaBan);
                dlg.Show();
            }
            else if (_lenhNhapXuatMuaBan.Loai != 1 && _lenhNhapXuatMuaBan.QuyTrinh == 0)
            {
                frmBangKeNhapDonHangChuan dlg = new frmBangKeNhapDonHangChuan(_lenhNhapXuatMuaBan);
                dlg.Show();
            }
            else if (_lenhNhapXuatMuaBan.Loai != 1 && _lenhNhapXuatMuaBan.QuyTrinh == 1)
            {
                frmBangKeHoaDonChuan dlg = new frmBangKeHoaDonChuan(_lenhNhapXuatMuaBan);
                dlg.Show();
            }
            else if (_lenhNhapXuatMuaBan.Loai == 1 && _lenhNhapXuatMuaBan.QuyTrinh == 1)
            {
                frmBangKeXuatNhapHangTuHoaDon dlg = new frmBangKeXuatNhapHangTuHoaDon(_lenhNhapXuatMuaBan);
                dlg.Show();
            }
        }
        #endregion

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
                LenhNhapXuatMuaBan _lenhNhapXuatMuaBan;
                _lenhNhapXuatMuaBan = (LenhNhapXuatMuaBan)(lenhNhapXuatMuaBanListBindingSource.Current);
                ReportDocument Report;

                if (_lenhNhapXuatMuaBan.Loai == 0 || _lenhNhapXuatMuaBan.Loai == 1)
                {
                    Report = new Report.Report_MuaBan.Report_LenhNhapKho();

                }
                else
                {
                    Report = new Report.Report_MuaBan.Report_LenhXuatKho();
                }
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_LenhNhapXuat";
                command.Parameters.AddWithValue("@MaLenhNhapXuat", _lenhNhapXuatMuaBan.MaLenhNhapXuat);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_LenhNhapXuat;1";

                 SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_Report_ReportHeader";                
                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_Report_ReportHeader;1";

                DataSet myDataSet = new DataSet();
                myDataSet.Tables.Add(table);
                myDataSet.Tables.Add(table1);
                Report.SetDataSource(myDataSet);      

                //  Report.SetParameterValue("@SoHopDong", _HopDongMuaBan.SoHopDong);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            
        }
        #endregion 

    }
}