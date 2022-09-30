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
    public partial class frmDanhSachDonHangMua : Form
    {
        Util util = new Util();
        private DonHangMuaList _DonHangMuaList;
        private byte _Loai;
        private byte _quyTrinh;
        HamDungChung hamDungChung = new HamDungChung();

        public frmDanhSachDonHangMua(byte Loai, byte quyTrinh)
        {
            InitializeComponent();
            KhaiBaoSuKienForm();
            KhoiTao(Loai, quyTrinh);
            Invisible();
            
        }

        #region Khai Báo Sự Kiện Form
        private void KhaiBaoSuKienForm()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(ultragrdDSDonHang);
        }
        #endregion 

        #region Khởi Tạo
        private void KhoiTao(byte Loai, byte quyTrinh)
        {
            _Loai = Loai;
            _quyTrinh = quyTrinh;
            _DonHangMuaList = DonHangMuaList.GetDonHangMuaList(DateTime.Today, DateTime.Today,_quyTrinh, Loai,txt_ThongTin.Text, txt_ThongTinHHDV.Text);
            donHangMuaListBindingSource.DataSource = _DonHangMuaList;
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
                _DonHangMuaList.ApplyEdit();
                _DonHangMuaList.Save();
            }
            catch (ApplicationException ex)
            {
                kq = false;
            }
            return kq;
        }
        #endregion

        #region ultragrdDSDonHang_InitializeLayout
        private void ultragrdDSDonHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            /*Khoi Tao  Đơn Hàng*/

            
            foreach (UltraGridColumn col in this.ultragrdDSDonHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].MaskInput = "{LOC}dd/mm/yyyy";

            
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 5;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Format = "###,###,###,###,###";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right;
            
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.Caption = "Số Đơn Hàng";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.VisiblePosition = 1;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Hidden = false;            
            
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 6;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;

            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayThanhToan"].Header.Caption = "Ngày Thanh Toán";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayThanhToan"].Header.VisiblePosition = 3;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayThanhToan"].Hidden = false;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayThanhToan"].Format = "dd/MM/yyyy";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayThanhToan"].MaskInput = "{LOC}dd/mm/yyyy";

            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayNhanHang"].Header.Caption = "Ngày Giao Hàng";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayNhanHang"].Header.VisiblePosition = 4;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayNhanHang"].Hidden = false;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayNhanHang"].Format = "dd/MM/yyyy";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayNhanHang"].MaskInput = "{LOC}dd/mm/yyyy";


            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 8;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;

            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Đối Tác";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 9;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;

            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Số CMND";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 10;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;

            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TinhTrangString"].Header.Caption = "Tình Trạng";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TinhTrangString"].Header.VisiblePosition = 11;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TinhTrangString"].Hidden = false;


            /*Khoi Tao Chi Tiết Đơn Hàng*/
            ultragrdDSDonHang.DisplayLayout.Bands[1].Columns["MaChiTiet"].Hidden = true;
            ultragrdDSDonHang.DisplayLayout.Bands[1].Columns["MaDonHang"].Hidden = true;
            ultragrdDSDonHang.DisplayLayout.Bands[1].Columns["MaHangHoa"].Hidden = true;            
            ultragrdDSDonHang.DisplayLayout.Bands[1].Columns["MaDonViTinh"].Hidden = true;
            ultragrdDSDonHang.DisplayLayout.Bands[1].Columns["SoLuong"].Header.Caption = "Số Lượng";
            ultragrdDSDonHang.DisplayLayout.Bands[1].Columns["SoLuong"].Header.VisiblePosition = 4;
            ultragrdDSDonHang.DisplayLayout.Bands[1].Columns["DonGia"].Header.Caption = "Đơn Giá";
            ultragrdDSDonHang.DisplayLayout.Bands[1].Columns["DonGia"].Header.VisiblePosition = 5;
            ultragrdDSDonHang.DisplayLayout.Bands[1].Columns["ThanhTien"].Header.Caption = "Số Tiền";
            ultragrdDSDonHang.DisplayLayout.Bands[1].Columns["ThanhTien"].Header.VisiblePosition = 6;
            ultragrdDSDonHang.DisplayLayout.Bands[1].Columns["ChietKhau"].Header.Caption = "Chiết Khấu";
            ultragrdDSDonHang.DisplayLayout.Bands[1].Columns["ChietKhau"].Header.VisiblePosition = 7;

            this.ultragrdDSDonHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultragrdDSDonHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultragrdDSDonHang.DisplayLayout.Bands[1].Columns)
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
            frmDonMuaHang dlg = new frmDonMuaHang(_Loai,_quyTrinh);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                _DonHangMuaList = DonHangMuaList.GetDonHangMuaList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),_quyTrinh, _Loai);
                donHangMuaListBindingSource.DataSource = _DonHangMuaList;
                if (_DonHangMuaList.Count == 0)
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
                   // MessageBox.Show(this, util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _DonHangMuaList = DonHangMuaList.GetDonHangMuaList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value), 0, _Loai, txt_ThongTin.Text, txt_ThongTinHHDV.Text);
                }
            }
        }
        #endregion

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdDSDonHang.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else ultragrdDSDonHang.DeleteSelectedRows();
        }
        #endregion

        #region tlslblTim_Click
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            _DonHangMuaList = DonHangMuaList.GetDonHangMuaList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),_quyTrinh, _Loai, txt_ThongTin.Text, txt_ThongTinHHDV.Text);
            donHangMuaListBindingSource.DataSource = _DonHangMuaList;
            if (_DonHangMuaList.Count == 0)
            {
                MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region ultragrdDSDonHang_DoubleClick
        private void ultragrdDSDonHang_DoubleClick(object sender, EventArgs e)
        {
            DonHangMua _donHangMua;
            _donHangMua = DonHangMua.GetDonHangMua((long)(ultragrdDSDonHang.ActiveRow.Cells["MaDonHang"].Value));
            frmDonMuaHang dlg = new frmDonMuaHang(_donHangMua);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                _DonHangMuaList = DonHangMuaList.GetDonHangMuaList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),0, _Loai);
                donHangMuaListBindingSource.DataSource = _DonHangMuaList;
                if (_DonHangMuaList.Count == 0)
                {
                    MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion       

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            DonHangMua _donHangMua;
            if (ultragrdDSDonHang.ActiveRow != null)
            {
                _donHangMua = DonHangMua.GetDonHangMua((long)(ultragrdDSDonHang.ActiveRow.Cells["MaDonHang"].Value));
                ReportDocument Report = new Report.Report_MuaBan.Report_DonHangMua();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_DonHangMua";
                command.Parameters.AddWithValue("@MaDonHang", _donHangMua.MaDonHang);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_DonHangMua;1";

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
               
        private void frmDanhSachDonHangMua_KeyDown(object sender, KeyEventArgs e)
        {
            // if(e.Control & e.KeyCode == Keys.N)
            //{
            //   frmDonMuaHang dlg = new frmDonMuaHang();
            //if (dlg.ShowDialog() != DialogResult.OK)
            //{
            //    _DonHangMuaList = DonHangMuaList.GetDonHangMuaList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),0, _Loai);
            //    donHangMuaListBindingSource.DataSource = _DonHangMuaList;
            //    if (_DonHangMuaList.Count == 0)
            //    {
            //        MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            // }
        }

        private void frmDanhSachDonHangMua_KeyUp(object sender, KeyEventArgs e)
        {
            //if(e.Control && e.Alt && e.KeyCode == Keys.N)
            //{
            //   frmDonMuaHang dlg = new frmDonMuaHang();
            //if (dlg.ShowDialog() != DialogResult.OK)
            //{
            //    _DonHangMuaList = DonHangMuaList.GetDonHangMuaList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),0, _Loai);
            //    donHangMuaListBindingSource.DataSource = _DonHangMuaList;
            //    if (_DonHangMuaList.Count == 0)
            //    {
            //        MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            // }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}