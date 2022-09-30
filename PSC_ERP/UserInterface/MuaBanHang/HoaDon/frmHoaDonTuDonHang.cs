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
    public partial class frmHoaDonTuDonHang : Form
    {
        #region properties
        HoaDon _hoaDon;
        int _loai = 0;        
        DonHangBan _donHangBan;
        DonHangMua _donHangMua;
        DonNhanHangTra _donNhanHangTra;
        DonTraHangMua _donTraHangMua;
        LenhNhapXuatMuaBan _lenhNhapXuatMuaBan;
        HamDungChung hamDungChung = new HamDungChung();
        Util util = new Util();
        #endregion

        #region Contructors
        public frmHoaDonTuDonHang()
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
            Invisible();
        }

        public frmHoaDonTuDonHang(DonHangBan donHangBan)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao(donHangBan);
            Invisible();
        }

        public frmHoaDonTuDonHang(DonHangMua donHangMua)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao(donHangMua);
            Invisible();
        }       


        public frmHoaDonTuDonHang(HoaDon hoaDon, DonHangBan donHangBan)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao(hoaDon, donHangBan);
            Invisible();
        }

        public frmHoaDonTuDonHang(HoaDon hoaDon, DonHangMua donHangMua)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao(hoaDon, donHangMua);
            Invisible();
        }
        #endregion

        #region Khai Báo Sự Kiện
        private void KhaiBaoSuKien()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(grdu_ChiTietHoaDon);
        }
        #endregion 

        #region Invisible Button
        private void Invisible()
        {            
            tlslblUndo.Available = false;            
            tlslblTroGiup.Available = false;
            tlsThem.Available = false;
        }
        #endregion 

        #region KhoiTao()

        private void KhoiTao()
        {
            _hoaDon = HoaDon.NewHoaDon();
            HoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonListBindingSource.DataSource = _hoaDon.CT_HoaDonList;
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();                       
        }

        private void KhoiTao(DonHangBan donHangBan)
        {
            _donHangBan = donHangBan;            
            _hoaDon = HoaDon.NewHoaDon(donHangBan);
            _loai = _donHangBan.Loai;
            DoiTac _doiTac = DoiTac.GetDoiTac(_hoaDon.MaDoiTac);
            DoiTacbindingSource.DataSource = _doiTac;
            txt_SoDonHang.Text = donHangBan.SoDonHang;
            HoaDonbindingSource.DataSource = _hoaDon;           
            cTHoaDonListBindingSource.DataSource = _hoaDon.CT_HoaDonList;
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
        }

        private void KhoiTao(DonHangMua donHangMua)
        {
            _donHangMua = donHangMua;            
            _hoaDon = HoaDon.NewHoaDon(_donHangMua);
            _loai = _donHangMua.Loai;
            DoiTac _doiTac = DoiTac.GetDoiTac(_hoaDon.MaDoiTac);
            DoiTacbindingSource.DataSource = _doiTac;
            txt_SoDonHang.Text = donHangMua.SoDonHang;
            HoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonListBindingSource.DataSource = _hoaDon.CT_HoaDonList;
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
        }

        private void KhoiTao(DonTraHangMua donTraHangMua)
        {
            _donTraHangMua = donTraHangMua;            
            _hoaDon = HoaDon.NewHoaDon(donTraHangMua);
            DoiTac _doiTac = DoiTac.GetDoiTac(_hoaDon.MaDoiTac);
            DoiTacbindingSource.DataSource = _doiTac;
            txt_SoDonHang.Text = donTraHangMua.SoDonHang;
            HoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonListBindingSource.DataSource = _hoaDon.CT_HoaDonList;
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
        }

        private void KhoiTao(DonNhanHangTra donNhanHangTra)
        {
            _donNhanHangTra = donNhanHangTra;            
            _hoaDon = HoaDon.NewHoaDon(donNhanHangTra);
            DoiTac _doiTac = DoiTac.GetDoiTac(_hoaDon.MaDoiTac);
            DoiTacbindingSource.DataSource = _doiTac;
            txt_SoDonHang.Text = donNhanHangTra.SoDonHang;
            HoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonListBindingSource.DataSource = _hoaDon.CT_HoaDonList;
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
        }

        private void KhoiTao(HoaDon hoaDon, DonHangBan donHangBan)
        {
            _hoaDon = hoaDon;
            DoiTac _doiTac = DoiTac.GetDoiTac(_hoaDon.MaDoiTac);
            txt_SoDonHang.Text = donHangBan.SoDonHang;
            DoiTacbindingSource.DataSource = _doiTac;
            HoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonListBindingSource.DataSource = _hoaDon.CT_HoaDonList;
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
        }

        private void KhoiTao(HoaDon hoaDon, DonHangMua donHangMua)
        {
            _hoaDon = hoaDon;            
            DoiTac _doiTac = DoiTac.GetDoiTac(_hoaDon.MaDoiTac);
            txt_SoDonHang.Text = donHangMua.SoDonHang;
            DoiTacbindingSource.DataSource = _doiTac;
            HoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonListBindingSource.DataSource = _hoaDon.CT_HoaDonList;
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
        }

        #endregion

        #region ThemMoi
        private void ThemMoi(byte quyTrinh)
        {
            _hoaDon = HoaDon.NewHoaDon(quyTrinh);
            HoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonListBindingSource.DataSource = _hoaDon.CT_HoaDonList;
        }

        private void ThemMoi()
        {
            _hoaDon = HoaDon.NewHoaDon();
            HoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonListBindingSource.DataSource = _hoaDon.CT_HoaDonList;
        }
        #endregion 

        #region Kiểm Tra Dữ Liệu

        private bool KiemTraDuLieu()
        {
            bool kq = true;
            if (_hoaDon.LoaiHoaDon == 0)
            {
                if (_hoaDon.CT_HoaDonList.Count == 0)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Chi Tiết Hoá Đơn", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_SoSerial.Focus();
                    kq = false;
                }
            }
            else
            {
                if (_hoaDon.SoHoaDon == string.Empty)
                {
                    MessageBox.Show(this, util.sohoadon, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_SoHoaDon.Focus();
                    kq = false;
                }
                else if (_hoaDon.SoSerial == string.Empty)
                {
                    MessageBox.Show(this, util.soserial, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_SoSerial.Focus();
                    kq = false;
                }
                if (_hoaDon.CT_HoaDonList.Count == 0)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Chi Tiết Hoá Đơn", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_SoSerial.Focus();
                    kq = false;
                }
            }

            return kq;
        }
        #endregion 

        #region Lưu Dữ Liệu
        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                if (_hoaDon.IsNew)
                {
                    if (_hoaDon.MuaBan == false)
                    {
                        _hoaDon.SoHoaDon = HoaDon.SoHoaDonTuDong();
                        _hoaDon.SoSerial = HoaDon.SoSerialTuDong();
                    }
                    HoaDonbindingSource.EndEdit();
                    _hoaDon.Save();
                    _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_hoaDon, (byte)_loai, _hoaDon.MuaBan);
                    _lenhNhapXuatMuaBan.Save();
                }
                else
                {
                    if (_hoaDon.IsDirty)
                    {
                        HoaDonbindingSource.EndEdit();
                        _hoaDon.Save();
                        LenhNhapXuatMuaBanList _LenhNhapXuatMuaBanList = LenhNhapXuatMuaBanList.GetLenhNhapXuatMuaBanListByHoaDon(_hoaDon.MaHoaDon);                        
                        _LenhNhapXuatMuaBanList.Clear();
                        _LenhNhapXuatMuaBanList.Save();                        
                        _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_hoaDon, (byte)_loai, _hoaDon.MuaBan);
                        _lenhNhapXuatMuaBan.Save();
                    }
                }                             
            }
            catch (Exception ex)
            {
                kq = false;
            }
            return kq;
        }
        #endregion              

        #region cmbue_LoaiHoaDon_ValueChanged

        private void cmbue_LoaiHoaDon_ValueChanged(object sender, EventArgs e)
        {
            
                //if (_hoaDon.LoaiHoaDon== 2)
                //{
                //    KhoiTaoDonHangBan();
                //}
                //if (_hoaDon.LoaiHoaDon== 3)
                //{
                //    KhoiTaoDonHangMua();
                //}
                //if (_hoaDon.LoaiHoaDon == 4)
                //{
                //    KhoiTaoNhanHangTra();
                //}
                //if (_hoaDon.LoaiHoaDon == 5)
                //{
                //    KhoiTaoDonTraHangMua();
                //}
            
        }

        #endregion     

        #region grdu_ChiTietHoaDon_InitializeLayout
        private void grdu_ChiTietHoaDon_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MactHoadon"].Hidden = true;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaHoaDon"].Hidden = true;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].Hidden = true;

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Thể Loại";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 1;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaHangHoa"].Hidden = true;

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Hàng Hóa/Dịch Vụ";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 3;            

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 4;            
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
                
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 6;           
                        
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 9;
            

            this.grdu_ChiTietHoaDon.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_ChiTietHoaDon.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###";
                }
                //x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion
        
        #region cTHoaDonListBindingSource_CurrentChanged
        private void cTHoaDonListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Decimal _tongTien = 0;
            foreach (CT_HoaDon ct_HoaDon in _hoaDon.CT_HoaDonList)
            {
                _tongTien = _tongTien + ct_HoaDon.ThanhTien;
            }
            numeu_ThanhTien.Value = _tongTien;
        }
        #endregion

        #region cmbu_NguoiLienLac_InitializeLayout
        private void cmbu_NguoiLienLac_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["MaNguoiLienLac"].Hidden = true;
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["TenNguoiLienLac"].Header.Caption = "Tên Người Liên Lạc";
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["TenNguoiLienLac"].Header.VisiblePosition = 1;
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["DienThoai"].Header.Caption = "Điện Thoại";
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["DienThoai"].Header.VisiblePosition = 2;
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["Email"].Header.Caption = "Email";
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["Email"].Header.VisiblePosition = 3;
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            this.cmbu_NguoiLienLac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_NguoiLienLac.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion

        #region luuToolStripMenuItem_Click
        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grdu_ChiTietHoaDon.UpdateData();
            if (KiemTraDuLieu() == true)
            {
                if (MessageBox.Show(this, "Bạn Muốn Lưu Dữ Liệu", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {                
                    if (LuuDuLieu() == true)
                    {
                        MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region thêmToolStripMenuItem_Click
        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  ThemMoi(_quyTrinh);
        }
        #endregion

        #region cmbeu_TinhTrang_ValueChanged
        private void cmbeu_TinhTrang_ValueChanged(object sender, EventArgs e)
        {
            if (cmbeu_TinhTrang.Value != null)
            {
                if (Convert.ToInt16(cmbeu_TinhTrang.Value) == 1)
                {
                    numeu_SoTienDaThanhToan.Value = _hoaDon.TongTien;
                }
                else numeu_SoTienDaThanhToan.Value = 0;

            }
        }
        #endregion

        #region btlIn_Click

        private void btlIn_Click(object sender, EventArgs e)
        {
            if (_hoaDon.IsNew != true)
            {
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
            else
            {
                MessageBox.Show(this, "Vui Lòng Cập Nhật Hóa Đơn Trước Khi In", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region inToolStripMenuItem_Click
        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region grdu_ChiTietHoaDon_Error
        private void grdu_ChiTietHoaDon_Error(object sender, ErrorEventArgs e)
        {
            if(e.ErrorType == ErrorType.Data)
                 e.ErrorText = "Kiểu dữ liệu không hợp lệ";
        }
        #endregion 

    }
}