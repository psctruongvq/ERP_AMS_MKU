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
    public partial class frmHoaDon : Form
    {
        HoaDon _hoaDon;
        HamDungChung hamDungChung = new HamDungChung();
        CT_HoaDonList ctHoaDonList = CT_HoaDonList.NewCT_HoaDonList();
        byte _quyTrinh = 0;
        int _loai = 0;
        bool _nhapXuat = false;
        byte _doiTuongMuaBan = 0;
        byte _loaiHoaDon =0 ;

        Util util = new Util();

        #region Contructors

        public frmHoaDon()
        {
            InitializeComponent();
            KhaiBaoSuKien();
            Invisible();
            //ThemMoi();
            //KhoiTao();
        }

        public frmHoaDon(HoaDon _hoaDon)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao(_hoaDon);
            ThemMoi(_hoaDon);
            Invisible();
            
        }
     

        public frmHoaDon(byte quyTrinh, int Loai, bool nhapXuat, byte doiTuongMuaBan)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            _quyTrinh = quyTrinh;
            KhoiTao(Loai, nhapXuat, doiTuongMuaBan);
            ThemMoi(quyTrinh);
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
           
            
            if( _loaiHoaDon == 0 && _doiTuongMuaBan == 3)
             tlslblToKhaiThue.Available = true;
         else tlslblToKhaiThue.Available = false;
        }
        #endregion 

        #region Kiểm Tra Dữ Liệu

        private bool KiemTraDuLieu()
        {
            bool kq = true;
            if (_loaiHoaDon == 0)
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

        #region KhoiTao()
        private void KhoiTao(int Loai, bool nhapXuat, byte doiTuongMuaBan  )
        {
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();                       
            _loai = Loai;
            _nhapXuat = nhapXuat;
            _doiTuongMuaBan = doiTuongMuaBan;
            _loaiHoaDon = Convert.ToByte(Loai);
            
            if (_nhapXuat == true && (_loai == 2)  )
            {
                _loaiHoaDon = 3;
            }
            phieuNhapXuatListBindingSource.DataSource = PhieuNhapXuatList.GetPhieuNhapXuat_MuaBanList(_nhapXuat, 0, _loai, _quyTrinh);           
        }

        private void KhoiTao(HoaDon hoaDon)
        {
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            //_loai = Loai;
            _nhapXuat = hoaDon.NhapXuat;
            _doiTuongMuaBan = hoaDon.DoiTuongMuaBan;
            _loaiHoaDon = Convert.ToByte( hoaDon.LoaiHoaDon);
           
            phieuNhapXuatListBindingSource.DataSource = PhieuNhapXuatList.GetPhieuNhapXuat_MuaBanList(_nhapXuat, 0, _loai, _quyTrinh);
        }


        private void ThemMoi(byte quyTrinh)
        {
            _hoaDon = HoaDon.NewHoaDon(quyTrinh);
           // _hoaDon.LoaiHoaDon = _loai;
          
            hoaDonBindingSource.DataSource = _hoaDon;
            cTHoaDonListBindingSource.DataSource = _hoaDon.CT_HoaDonList;
        }

        private void ThemMoi()
        {
            _hoaDon = HoaDon.NewHoaDon();
            hoaDonBindingSource.DataSource = _hoaDon;
            cTHoaDonListBindingSource.DataSource = _hoaDon.CT_HoaDonList;
        }

        private void ThemMoi(HoaDon hoaDon)
        {
            _hoaDon = hoaDon;
            phieuNhapXuatListBindingSource.DataSource = PhieuNhapXuat.GetPhieuNhapXuat(_hoaDon.MaPhieuNhapXuat);
            DoiTac doiTac = DoiTac.GetDoiTac(_hoaDon.MaDoiTac);
            doiTacBindingSource.DataSource = doiTac;

            txt_DoiTac.Text = doiTac.TenDoiTac;
            nguoiLienLacListBindingSource.DataSource = doiTac.NguoiLienLacList;
            diaChiDoiTacListBindingSource.DataSource = doiTac.DiaChi_DoiTacList;
            doiTacDienThoaiFaxListBindingSource.DataSource = doiTac.DoiTac_DienThoai_FaxList;
            //PhieuNhapXuat a = PhieuNhapXuat.GetPhieuNhapXuat(_hoaDon.MaPhieuNhapXuat);
            hoaDonBindingSource.DataSource = _hoaDon;
            cTHoaDonListBindingSource.DataSource = _hoaDon.CT_HoaDonList;                      
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
                    if (_nhapXuat == false)
                    {
                        _hoaDon.SoHoaDon = HoaDon.SoHoaDonTuDong();
                        _hoaDon.SoSerial = HoaDon.SoSerialTuDong();
                    }
                }
                hoaDonBindingSource.EndEdit();
                _hoaDon.Save();
            }
            catch (Exception ex)
            {
                kq = false;
            }
            return kq;
        }
        #endregion         

        #region cmbu_NguoiLienLac_InitializeLayout
        private void cmbu_NguoiLienLac_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
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

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption= "Số Lượng";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 3;

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 4;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
            
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 5;                                        
            
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 6;   

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
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
                //x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion     
               
        #region cmbu_PhieuNhapXuat_InitializeLayout
        private void cmbu_PhieuNhapXuat_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cmbu_PhieuNhapXuat.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_PhieuNhapXuat.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_PhieuNhapXuat.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            cmbu_PhieuNhapXuat.DisplayLayout.Bands[0].Columns["SoPhieu"].Hidden = false;
            cmbu_PhieuNhapXuat.DisplayLayout.Bands[0].Columns["SoPhieu"].Header.Caption = "Số Phiếu";
            cmbu_PhieuNhapXuat.DisplayLayout.Bands[0].Columns["SoPhieu"].Header.VisiblePosition = 0;
            cmbu_PhieuNhapXuat.DisplayLayout.Bands[0].Columns["NgayHT"].Hidden = false;
            cmbu_PhieuNhapXuat.DisplayLayout.Bands[0].Columns["NgayHT"].Header.Caption = "Ngày Lập";
            cmbu_PhieuNhapXuat.DisplayLayout.Bands[0].Columns["NgayHT"].Header.VisiblePosition = 1;
            cmbu_PhieuNhapXuat.DisplayLayout.Bands[0].Columns["GiaTriKho"].Hidden = false;
            cmbu_PhieuNhapXuat.DisplayLayout.Bands[0].Columns["GiaTriKho"].Header.Caption = "Tổng Tiền";
            cmbu_PhieuNhapXuat.DisplayLayout.Bands[0].Columns["GiaTriKho"].Header.VisiblePosition = 2;
            
        }
        #endregion

        #region phieuNhapXuatListBindingSource_CurrentItemChanged
        private void phieuNhapXuatListBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            

        }
        #endregion

        #region cmbu_PhieuNhapXuat_ValueChanged
        private void cmbu_PhieuNhapXuat_ValueChanged(object sender, EventArgs e)
        {
            PhieuNhapXuat phieuNhapXuat;
            DoiTac doiTac;
            CT_HoaDon chiTietHoaDon;
            if (_hoaDon.IsNew)
            {
                ctHoaDonList = CT_HoaDonList.NewCT_HoaDonList();
                if (phieuNhapXuatListBindingSource.Current != null)
                {
                    phieuNhapXuat = ((PhieuNhapXuat)phieuNhapXuatListBindingSource.Current);                                      
                    _hoaDon = HoaDon.NewHoaDon(phieuNhapXuat);
                    _hoaDon.DoiTuongMuaBan = _doiTuongMuaBan;
                    _hoaDon.LoaiHoaDon = _loaiHoaDon;

                    doiTac = DoiTac.GetDoiTac(phieuNhapXuat.MaDoiTac);
                    doiTacBindingSource.DataSource = doiTac;

                    txt_DoiTac.Text = doiTac.TenDoiTac;
                    nguoiLienLacListBindingSource.DataSource = doiTac.NguoiLienLacList;
                    diaChiDoiTacListBindingSource.DataSource = doiTac.DiaChi_DoiTacList;
                    doiTacDienThoaiFaxListBindingSource.DataSource = doiTac.DoiTac_DienThoai_FaxList;

                
                }
                else
                {
                   
                    _hoaDon = HoaDon.NewHoaDon();
                    doiTacBindingSource.DataSource = DoiTac.NewDoiTac();                   
                    nguoiLienLacListBindingSource.DataSource = NguoiLienLacList.NewNguoiLienLacList();
                    diaChiDoiTacListBindingSource.DataSource = DiaChi_DoiTacList.NewDiaChi_DoiTacList();
                    doiTacDienThoaiFaxListBindingSource.DataSource = DoiTac_DienThoai_FaxList.NewDoiTac_DienThoai_FaxList();
                    //_hoaDon.CT_HoaDonList = CT_HoaDonList.NewCT_HoaDonList();
                }

                hoaDonBindingSource.DataSource = _hoaDon;
                cTHoaDonListBindingSource.DataSource = _hoaDon.CT_HoaDonList;
            }
            
        }

        #endregion

        #region cTHoaDonListBindingSource_CurrentItemChanged
        private void cTHoaDonListBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            Decimal ThanhTien = 0;
            foreach (CT_HoaDon ctHoaDon in _hoaDon.CT_HoaDonList)
            {
                ThanhTien = ThanhTien + ctHoaDon.ThanhTien;
            }
            _hoaDon.ThanhTien = ThanhTien;
        }
        #endregion 

        #region grdu_ChiTietHoaDon_KeyDown
        private void grdu_ChiTietHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                grdu_ChiTietHoaDon.UpdateData();
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
            ThemMoi(_quyTrinh);
        }
          #endregion

        #region tlslblThoat_Click

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
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

        #region tlslblToKhaiThue_Click
        private void tlslblToKhaiThue_Click(object sender, EventArgs e)
        {
            if (_hoaDon.IsNew)
            {
                MessageBox.Show(this, "Cập Nhật Hóa Đơn Khi Làm Tờ Khai Thuế", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                ToKhaiThue toKhaiThue = ToKhaiThue.NewToKhaiThue();
                toKhaiThue = ToKhaiThue.GetToKhaiThueByHoaDon(_hoaDon.MaHoaDon);
                if (toKhaiThue == null || toKhaiThue.MaToKhai == 0)
                {
                    toKhaiThue = ToKhaiThue.NewToKhaiThue(_hoaDon.CT_HoaDonList);
                }
                toKhaiThue.MaHoaDon = _hoaDon.MaHoaDon; 
                frmToKhaiThue dlg = new frmToKhaiThue(toKhaiThue);
                dlg.ShowDialog();
            }
                     
        }
        #endregion 

        private void frmHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Hoa Don", "Help_BanHang.chm");
            }
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Hoa Don", "Help_BanHang.chm");
        }

    }
}
