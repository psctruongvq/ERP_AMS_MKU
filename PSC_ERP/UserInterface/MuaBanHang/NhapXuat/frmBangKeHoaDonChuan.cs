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
    public partial class frmBangKeHoaDonChuan : Form
    {

        LenhNhapXuatMuaBan _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan();
        CT_LenhNhapXuatList _ctLenhNhapXuatList = CT_LenhNhapXuatList.NewCT_LenhNhapXuatList();
        CT_HoaDon_LenhNhapXuatList _ct_HoaDon_LenhNhapxuatList = CT_HoaDon_LenhNhapXuatList .NewCT_HoaDon_LenhNhapXuatList();
        HoaDon _hoaDon;
        byte _loai;
        byte _quyTrinh = 1;
        bool _nhapxuat = false;
        int _loaiHoaDon = 0; 
        HamDungChung hamDungChung = new HamDungChung();

        #region contructors
        public frmBangKeHoaDonChuan()
        {
            InitializeComponent();
            Invisible();
        }

        public frmBangKeHoaDonChuan(byte quyTrinh, byte loai, bool nhapXuat)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            _quyTrinh = quyTrinh;
            _loai = loai;
            _nhapxuat = nhapXuat;
            if (_nhapxuat == false)
                _loaiHoaDon = 0;
            else _loaiHoaDon = 1;
            KhoiTao(quyTrinh, loai,nhapXuat);
            KhoiTaoCombo(loai, nhapXuat);
            Invisible();
        }

        public frmBangKeHoaDonChuan(LenhNhapXuatMuaBan _lenhNhapXuatMuaBan)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            _quyTrinh = _lenhNhapXuatMuaBan.QuyTrinh;
            _loai = _lenhNhapXuatMuaBan.Loai;
            _nhapxuat = _lenhNhapXuatMuaBan.LaNhap;
            KhoiTao(_lenhNhapXuatMuaBan);
            KhoiTaoCombo(_loai, _nhapxuat);
            
            Invisible();
        }
        #endregion

        #region Khai Báo Sự Kiện
        private void KhaiBaoSuKien()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(grdu_CTLenhNhapXuatKho);
        }
        #endregion 

        #region KhoiTao()

        private void KhoiTao(byte quyTrinh, byte loai, bool nhapXuat)
        {
            _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(quyTrinh, nhapXuat);
            txt_HoaDon.Text = "";
            tenNhanVienListBindingSource.DataSource = TenNhanVienList.GetTenNhanVienList();            
            lenhNhapXuatMuaBanbindingSource.DataSource = _lenhNhapXuatMuaBan;            
            cTLenhNhapXuatListBindingSource.DataSource = _lenhNhapXuatMuaBan.CT_LenhNhapXuatList;
            _loai = loai;                    
            _lenhNhapXuatMuaBan.Loai = (byte)loai;
            _lenhNhapXuatMuaBan.LaNhap = _nhapxuat;
            //_lenhNhapXuatMuaBan.SoBangKe = LenhNhapXuatMuaBan.SoBangKeTuDongTang(_nhapxuat, _loai);
        }

        private void KhoiTao(LenhNhapXuatMuaBan lenhNhapXuatMuaBan)
        {
            tenNhanVienListBindingSource.DataSource = TenNhanVienList.GetTenNhanVienList();
            _lenhNhapXuatMuaBan = lenhNhapXuatMuaBan;
            lenhNhapXuatMuaBanbindingSource.DataSource = _lenhNhapXuatMuaBan;                                   
            cTLenhNhapXuatListBindingSource.DataSource = _lenhNhapXuatMuaBan.CT_LenhNhapXuatList;
            _loai = _lenhNhapXuatMuaBan.Loai;
            _nhapxuat = _lenhNhapXuatMuaBan.LaNhap;
            txt_TenDoiTac.Text = _lenhNhapXuatMuaBan.TenDoiTac;
            HoaDon _hoaDon = HoaDon.GetHoaDon(_lenhNhapXuatMuaBan.CT_HoaDon_LenhNhapXuatList[0].MaHoaDon);
            txt_HoaDon.Text = _hoaDon.SoHoaDon;
        }


        private void KhoiTaoCombo(byte loai, bool nhapXuat)
        {
            if (nhapXuat == true)
            {
                cmbeu_LoaiNhapXuat.Items.Clear();
                ValueListItem listItem = new ValueListItem();
                listItem.DataValue = loai;
                listItem.DisplayText = "Lệnh Nhập Kho";
                cmbeu_LoaiNhapXuat.Items.Add(listItem);
            }
            else 
            {
                cmbeu_LoaiNhapXuat.Items.Clear();
                ValueListItem listItem = new ValueListItem();
                listItem.DataValue = loai;
                listItem.DisplayText = "Lệnh Xuất Kho";
                cmbeu_LoaiNhapXuat.Items.Add(listItem);
            }
            
        }

        #endregion

        #region Invisible Button
        private void Invisible()
        {
            //tlslblXoa.Available = false;
            //tlslblUndo.Available = false;
            //tlslblTim.Available = false;
            tlslblTroGiup.Available = false;
           
        }
        #endregion 

        #region KiemTraDuLieu()
        private Boolean KiemTraDuLieu()
        {
            bool kq = true;
            //if (txt_SoBangKe.Text == string.Empty)
            //{
            //    MessageBox.Show(this, "Vui Lòng Nhập Số Lệnh Nhập Kho","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_SoBangKe.Focus();
            //    return false;
            //}
            //else
            if (_lenhNhapXuatMuaBan.CT_HoaDon_LenhNhapXuatList.Count==0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Hóa Đơn", "Thông Báo" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_HoaDon.Focus();
                return false;
            }
            
            return kq;
        }
        #endregion

        #region LuuDuLieu()
        private Boolean LuuDuLieu()
        {

            bool kq = true;
            try
            {
                if (_lenhNhapXuatMuaBan.IsNew)
                {
                    _lenhNhapXuatMuaBan.SoBangKe = LenhNhapXuatMuaBan.SoBangKeTuDongTang(_nhapxuat, _loai, _lenhNhapXuatMuaBan.DoiTuongNhapXuat,_lenhNhapXuatMuaBan.NgayLap);
                }
                _lenhNhapXuatMuaBan.ApplyEdit();
                _lenhNhapXuatMuaBan.Save();
                lenhNhapXuatMuaBanbindingSource.DataSource = _lenhNhapXuatMuaBan;
            }
            catch (Exception ex)
            {
                kq = false;
            }
            return kq;
        }
        #endregion
        
        #region cmbu_NhanVien_InitializeLayout
        private void cmbu_NhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            this.cmbu_NhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_NhanVien.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_NhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 1;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 2;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 3;
            //cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenPhongBan"].Hidden = false;
            //cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenPhongBan"].Header.Caption = "Tên Phòng Ban";
            //cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenPhongBan"].Header.VisiblePosition = 4;            

        }
        #endregion

        #region grdu_CTLenhNhapXuatKho_InitializeLayout
        private void grdu_CTLenhNhapXuatKho_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
         
            this.grdu_CTLenhNhapXuatKho.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_CTLenhNhapXuatKho.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
                        
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Thể Loại";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 1;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenHangHoa"].Hidden = false;

            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption= "Hàng Hóa/Dịch Vụ";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;

            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 3;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["SoLuong"].Hidden = false;

            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 3;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Hidden = false;
            
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 7;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].Hidden = false;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].Format = "###,###,###,###,###";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].Hidden = false; 
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 10;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].Format = "###,###,###,###,###";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].CellAppearance.TextHAlign = HAlign.Right;

        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
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

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            KhoiTao(_quyTrinh, _loai, _nhapxuat);
        }
        #endregion      
      
        #region cmbeu_LoaiNhapXuat_ValueChanged
        private void cmbeu_LoaiNhapXuat_ValueChanged(object sender, EventArgs e)
        {
            //if (cmbeu_LoaiNhapXuat.Value != null)
            //{
            //    _loai = (Int16)(cmbeu_LoaiNhapXuat.Value);
            //    if (_loai == 2)
            //    {
            //        hoaDonListBindingSource.DataSource = HoaDonList.GetHoaDonList(0, 1, false);
            //    }
            //}
        }
        #endregion

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report;
            if(_lenhNhapXuatMuaBan.IsNew == false)
            {

                if (_lenhNhapXuatMuaBan.LaNhap ==true  )
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

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                
            }
            else
            {
                MessageBox.Show(this, "Vui Lòng Cập Nhật Bảng Kê Trước Khi In", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region txt_HoaDon_KeyDown
        private void txt_HoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                HoaDonList _hoaDonList = HoaDonList.NewHoaDonList() ;
                _hoaDonList = HoaDonList.GetHoaDonList( _loaiHoaDon,_quyTrinh,  false, _loai, txt_HoaDon.Text);                
                //if (!_lenhNhapXuatMuaBan.IsNew)
                //{
                //    HoaDon hoaDon = HoaDon.GetHoaDon(_lenhNhapXuatMuaBan.CT_HoaDon_LenhNhapXuatList[0].MaHoaDon);
                //    _hoaDonList.Insert(hoaDon);
                //}
                frmTimHoaDon dlg = new frmTimHoaDon(_quyTrinh, _loai, _hoaDonList, txt_HoaDon.Text);
                dlg.ShowDialog();
                if (dlg._hoaDon != null)
                {
                    _hoaDon = dlg._hoaDon;
                    txt_HoaDon.Text = dlg._hoaDon.SoHoaDon;
                    _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_hoaDon, (byte)_loai, _nhapxuat);
                }
               // _lenhNhapXuatMuaBan.Loai = (byte)_loai;
                //_lenhNhapXuatMuaBan.LaNhap = _nhapxuat;
                _lenhNhapXuatMuaBan.SoBangKe = LenhNhapXuatMuaBan.SoBangKeTuDongTang(_nhapxuat, _loai, _lenhNhapXuatMuaBan.DoiTuongNhapXuat, _lenhNhapXuatMuaBan.NgayLap);
                cTLenhNhapXuatListBindingSource.DataSource = _lenhNhapXuatMuaBan.CT_LenhNhapXuatList;
                DoiTac doiTac = DoiTac.GetDoiTac(_lenhNhapXuatMuaBan.MaDoiTac);
                txt_TenDoiTac.Text = doiTac.TenDoiTac;
            }
        }
        #endregion 

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Lenh Xuat BHC (Lap HD)", "Help_BanHang.chm");
        }

        private void frmBangKeHoaDonChuan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Lenh Xuat BHC (Lap HD)", "Help_BanHang.chm");
            }
        }

    
    }
}