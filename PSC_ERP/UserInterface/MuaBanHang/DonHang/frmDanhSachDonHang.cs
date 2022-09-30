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
    public partial class frmDanhSachDonHang : Form
    {
        Util util = new Util();
        private DonHangBanList _DonHangBanList;
        private byte _QuyTrinh;
        private byte _Loai;
        HamDungChung hamDungChung = new HamDungChung();

        #region Contructor
        public frmDanhSachDonHang()
        {
            InitializeComponent();
            KhaiBaoSuKienForm();
            KhoiTao();
            Invisible();
        }

        public frmDanhSachDonHang(byte quyTrinh, byte loai)
        {
            InitializeComponent();
            KhaiBaoSuKienForm();
            _QuyTrinh = quyTrinh;
            _Loai = loai;
            KhoiTao();
            Invisible();
        }
        #endregion 

        #region Khai Báo Sự Kiện Form
        private void KhaiBaoSuKienForm()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(grdu_DanhSachDonHang);
        }
        #endregion 

        #region KhoiTao()
        private void KhoiTao()
        {
            _DonHangBanList = DonHangBanList.GetDonHangBanList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value), _QuyTrinh, _Loai, txt_ThongTin.Text, txt_ThongTinHHDV.Text);
            donHangBanListBindingSource.DataSource = _DonHangBanList;
        }
        #endregion 

        #region LuuDuLieu
        private Boolean LuuDuLieu()
        {
            Boolean kq = true;
            try
            {
                _DonHangBanList.ApplyEdit();                
                _DonHangBanList.Save();
            }
            catch (ApplicationException ex)
            {
                kq = false;
            }
            return kq;
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

        #region ultragrdDSDonHang_DoubleClick
        private void ultragrdDSDonHang_DoubleClick(object sender, EventArgs e)
        {
            DonHangBan _donHangBan;
            _donHangBan = DonHangBan.GetDonHangBan((long)(grdu_DanhSachDonHang.ActiveRow.Cells["MaDonHang"].Value));
            frmDonHangBan dlg = new frmDonHangBan(_donHangBan);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                _DonHangBanList = DonHangBanList.GetDonHangBanList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),_QuyTrinh, _Loai);
                donHangBanListBindingSource.DataSource = _DonHangBanList;
                if (_DonHangBanList.Count == 0)
                {
                    MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region ultragrdDSDonHang_InitializeLayout
        private void grdu_DanhSachDonHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            /*Khoi Tao  Đơn Hàng*/
            
            foreach (UltraGridColumn col in this.grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].MaskInput = "{LOC}dd/mm/yyyy";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 5;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Hidden= false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Format = "###,###,###,###,###";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right;
            
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.Caption = "Số Đơn Hàng";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.VisiblePosition = 1;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Hidden = false;

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 6;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayThanhToan"].Header.Caption = "Ngày Thanh Toán";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayThanhToan"].Header.VisiblePosition = 3;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayThanhToan"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayThanhToan"].MaskInput = "{LOC}dd/mm/yyyy";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayThanhToan"].Format = "dd/MM/yyyy";
 
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayGiaoHang"].Header.Caption = "Ngày Giao Hàng";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayGiaoHang"].Header.VisiblePosition = 4;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayGiaoHang"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayGiaoHang"].MaskInput = "{LOC}dd/mm/yyyy";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayGiaoHang"].Format = "dd/MM/yyyy";

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 8;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Đối Tác";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 9;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Số CMND";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 10;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TinhTrangString"].Header.Caption = "Tình Trạng";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TinhTrangString"].Header.VisiblePosition = 11;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TinhTrangString"].Hidden = false;

            /*Khoi Tao Chi Tiết Đơn Hàng*/
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["MaChiTiet"].Hidden = true;
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["MaDonHang"].Hidden = true;
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["MaHangHoa"].Hidden = true;
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["TenHangHoa"].Header.Caption = "Hàng Hóa";
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["TenHangHoa"].Header.VisiblePosition = 2;
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["TenDonViTinh"].Header.VisiblePosition = 3;
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["MaDonViTinh"].Hidden = true;
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["SoLuong"].Header.VisiblePosition = 4;
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["DonGia"].Header.VisiblePosition = 5;
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["SoTien"].Header.VisiblePosition = 6;
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["ChietKhau"].Header.Caption = "Chiết Khấu";
            grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns["ChietKhau"].Header.VisiblePosition = 7;

            this.grdu_DanhSachDonHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachDonHang.DisplayLayout.Bands[1].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }      

        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            frmDonHangBan dlg = new frmDonHangBan(_QuyTrinh,_Loai);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                _DonHangBanList = DonHangBanList.GetDonHangBanList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),_QuyTrinh,_Loai);
                donHangBanListBindingSource.DataSource = _DonHangBanList;
                if (_DonHangBanList.Count == 0)
                {
                    MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }  
            }
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.luudulieu, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)==DialogResult.OK)
            {
                if (LuuDuLieu() == true)
                {
                    MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show(this, util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                    _DonHangBanList = DonHangBanList.GetDonHangBanList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value), _QuyTrinh, _Loai, txt_ThongTin.Text, txt_ThongTinHHDV.Text);
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
            if (grdu_DanhSachDonHang.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else grdu_DanhSachDonHang.DeleteSelectedRows();

        }
        #endregion

        #region tlslblTim_Click
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            _DonHangBanList = DonHangBanList.GetDonHangBanList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),_QuyTrinh, _Loai, txt_ThongTin.Text, txt_ThongTinHHDV.Text);
            donHangBanListBindingSource.DataSource = _DonHangBanList;
            if (_DonHangBanList.Count == 0)
            {
                MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            DonHangBan _donHangBan;
            if (grdu_DanhSachDonHang.ActiveRow != null)
            {
                _donHangBan = DonHangBan.GetDonHangBan((long)(grdu_DanhSachDonHang.ActiveRow.Cells["MaDonHang"].Value));          
                ReportDocument Report = new Report.Report_MuaBan.Report_DonHangBan();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_DonHangBan";
                command.Parameters.AddWithValue("@MaDonHang", _donHangBan.MaDonHang);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_DonHangBan;1";

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
            

        }
        #endregion

        #region tlslblUndo_Click
        private void tlslblUndo_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void frmDanhSachDonHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Danh Sach Don Hang", "Help_BanHang.chm");
            }
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Danh Sach Don Hang", "Help_BanHang.chm");
        }

       
    }
}