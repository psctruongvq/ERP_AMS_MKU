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
    public partial class frmBangKeNhapDonHangChuan : Form
    {
        
        #region Properties
        LenhNhapXuatMuaBan _lenhNhapXuatMuaBan =  LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan();
        CT_LenhNhapXuatList _ctLenhNhapXuatList= CT_LenhNhapXuatList.NewCT_LenhNhapXuatList();        
        CT_LenhNhapXuat_DonHangList _ctlenhNhapXuat_DonHangList = CT_LenhNhapXuat_DonHangList.NewCT_LenhNhapXuat_DonHangList();
        DonHangBan _donHangBan;
        DonHangMua _donHangMua;
        DonNhanHangTra _donNhanHangTra;
        DonTraHangMua _donTraHangMua;        
        byte _loai = 0;
        byte _quyTrinh = 0;
        bool _nhapXuat = false;
        byte _doiTuongNhapXuat = 0;
        Util util = new Util();
        #endregion

        #region contructors
        public frmBangKeNhapDonHangChuan()
        {
            InitializeComponent();
            Invisible();
          //  KhoiTao();
        }
        public frmBangKeNhapDonHangChuan(byte quyTrinh, byte loai, bool nhapXuat)
        {
            InitializeComponent();
            _quyTrinh = quyTrinh;
            _loai = loai;            
            KhoiTao(quyTrinh,loai, nhapXuat);           
            Invisible();
        }

        public frmBangKeNhapDonHangChuan(byte quyTrinh, byte loai, bool nhapXuat, byte doiTuongNhapXuat)
        {
            InitializeComponent();
            _quyTrinh = quyTrinh;
            _loai = loai;
            _doiTuongNhapXuat = doiTuongNhapXuat;
            KhoiTao(quyTrinh, loai, nhapXuat);            
            Invisible();
        }
        public frmBangKeNhapDonHangChuan(LenhNhapXuatMuaBan lenhNhapXuatMuaBan)
        {
            InitializeComponent();
            _quyTrinh = lenhNhapXuatMuaBan.QuyTrinh;            
            KhoiTao(lenhNhapXuatMuaBan);
            KhoiTaoCombo(lenhNhapXuatMuaBan.Loai);
            Invisible();
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

        #region KhoiTao()
        private void KhoiTao(byte quyTrinh, byte loai, bool nhapXuat)
        {
              _loai = loai;
            _quyTrinh = quyTrinh;
            _nhapXuat = nhapXuat;
            txt_DonHang.Text = "";
            txt_DonHang.ReadOnly = false;
            _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(quyTrinh, nhapXuat);
            tenNhanVienListBindingSource.DataSource = TenNhanVienList.GetTenNhanVienList();
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(false);
            lenhNhapXuatBindingSource.DataSource = _lenhNhapXuatMuaBan;
            cTLenhNhapXuatListBindingSource.DataSource = _lenhNhapXuatMuaBan.CT_LenhNhapXuatList;                                  
            _lenhNhapXuatMuaBan.Loai = (byte)loai;          


        }

        private void KhoiTao(LenhNhapXuatMuaBan lenhNhapXuatMuaBan)
        {
            tenNhanVienListBindingSource.DataSource = TenNhanVienList.GetTenNhanVienList();
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(false);           
            _lenhNhapXuatMuaBan = lenhNhapXuatMuaBan;
            _loai = _lenhNhapXuatMuaBan.Loai;
            _nhapXuat = _lenhNhapXuatMuaBan.LaNhap;
            _quyTrinh = _lenhNhapXuatMuaBan.QuyTrinh;
            txt_DonHang.ReadOnly = true;
            lenhNhapXuatBindingSource.DataSource = _lenhNhapXuatMuaBan;
            cTLenhNhapXuatListBindingSource.DataSource = _lenhNhapXuatMuaBan.CT_LenhNhapXuatList;
            txt_TenDoiTac.Text = _lenhNhapXuatMuaBan.TenDoiTac;
            SetDonHang();            
        }

        private void SetDonHang()
        {
            if (_nhapXuat == true && _loai != 13)
            {
                txt_DonHang.Text = DonHangMua.GetDonHangMua(_lenhNhapXuatMuaBan.CT_LenhNhapXuat_DonHangList[0].MaDonHang).SoDonHang;                
            }

            else if (_nhapXuat == true && _loai == 13)
            {
                txt_DonHang.Text = DonNhanHangTra.GetDonNhanHangTra(_lenhNhapXuatMuaBan.CT_LenhNhapXuat_DonHangList[0].MaDonHang).SoDonHang;
            }

            else if (_nhapXuat == false && _loai != 13)
            {
                txt_DonHang.Text = DonHangBan.GetDonHangBan(_lenhNhapXuatMuaBan.CT_LenhNhapXuat_DonHangList[0].MaDonHang).SoDonHang;
            }
            else if (_nhapXuat == false && _loai == 13)
            {
                txt_DonHang.Text = DonTraHangMua.GetDonTraHangMua(_lenhNhapXuatMuaBan.CT_LenhNhapXuat_DonHangList[0].MaDonHang).SoDonHang;
            }
        }


        private void KhoiTaoCombo(byte loai)
        {
            if (loai == 0)
            {
                cmbeu_LoaiNhapXuat.Items.Clear();
                ValueListItem listItem = new ValueListItem();
                listItem.DataValue = loai;
                listItem.DisplayText = "Nhập Kho Hàng Mua";
                cmbeu_LoaiNhapXuat.Items.Add(listItem);
            }
            else if (loai == 1)
            {
                cmbeu_LoaiNhapXuat.Items.Clear();
                ValueListItem listItem = new ValueListItem();
                listItem.DataValue = loai;
                listItem.DisplayText = "Nhập Kho Hàng Trả Lại";
                cmbeu_LoaiNhapXuat.Items.Add(listItem);
            }
            else if (loai == 2)
            {
                cmbeu_LoaiNhapXuat.Items.Clear();
                ValueListItem listItem = new ValueListItem();
                listItem.DataValue = loai;
                listItem.DisplayText = "Xuất Kho Hàng Bán";
                cmbeu_LoaiNhapXuat.Items.Add(listItem);
            }
            else if (loai == 3)
            {
                cmbeu_LoaiNhapXuat.Items.Clear();
                ValueListItem listItem = new ValueListItem();
                listItem.DataValue = loai;
                listItem.DisplayText = "Xuất Kho Hàng Trả Lại";
                cmbeu_LoaiNhapXuat.Items.Add(listItem);
            }
        }

        #endregion

        #region KiemTraDuLieu()
        private Boolean KiemTraDuLieu()
        {

            bool kq = true;
            //if (txt_SoBangKe.Text == string.Empty)
            //{
            //    MessageBox.Show(this, "Vui Lòng Nhập Số Bảng Kê", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_SoBangKe.Focus();
            //    return false;
            //}
            if (_lenhNhapXuatMuaBan.CT_LenhNhapXuat_DonHangList.Count==0)
            {
               MessageBox.Show(this, "Vui Lòng Nhập Số Đơn Hàng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DonHang.Focus();
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
                if(_lenhNhapXuatMuaBan.IsNew)
                    _lenhNhapXuatMuaBan.SoBangKe = LenhNhapXuatMuaBan.SoBangKeTuDongTang(_nhapXuat, _loai, _lenhNhapXuatMuaBan.DoiTuongNhapXuat,_lenhNhapXuatMuaBan.NgayLap);

                lenhNhapXuatBindingSource.EndEdit();
                _lenhNhapXuatMuaBan.Save();
                txt_DonHang.ReadOnly = true;
                lenhNhapXuatBindingSource.DataSource = _lenhNhapXuatMuaBan;
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

        #region cmbu_DoiTac_InitializeLayout
        private void cmbu_DoiTac_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
        //    cmbu_DoiTac.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
        //    cmbu_DoiTac.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Số";
        //    cmbu_DoiTac.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 1;
        //    cmbu_DoiTac.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Họ Tên";
        //    cmbu_DoiTac.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 2;
        //    cmbu_DoiTac.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
        //    cmbu_DoiTac.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 3;
        //    cmbu_DoiTac.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = true;
        //    cmbu_DoiTac.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
        //    cmbu_DoiTac.DisplayLayout.Bands[0].Columns["LoaiDoiTac"].Hidden = true;
        //    cmbu_DoiTac.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Nội Dung";
        //    cmbu_DoiTac.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 4;
        //    this.cmbu_DoiTac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        //    this.cmbu_DoiTac.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
        //    foreach (UltraGridColumn col in this.cmbu_DoiTac.DisplayLayout.Bands[0].Columns)
        //    {
        //        col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
        //        col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //        col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
        //    }
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

            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenHangHoa"].Hidden = false;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Thể Loại";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 1;

            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Hàng Hóa/Dịch Vụ";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;

            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 3;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["SoLuong"].Hidden = false;

            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 4;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Hidden = false;

            //grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["KhoiLuong"].Header.Caption = "Khối Lượng";
            //grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["KhoiLuong"].Header.VisiblePosition = 4;
            //grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["KhoiLuong"].Hidden = false;           
            
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 5;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].Hidden = false;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].Format = "###,###,###,###,###";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].CellAppearance.TextHAlign = HAlign.Right;
           
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 6;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].Hidden = false;
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
            KhoiTao(_quyTrinh, _loai, _nhapXuat);
        }
        #endregion      

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report;
            if (_lenhNhapXuatMuaBan.IsNew == false)
            {

                if (_lenhNhapXuatMuaBan.LaNhap == true )
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
            else
            {
                MessageBox.Show(this, "Vui Lòng Cập Nhật Bảng Kê Trước Khi In", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region txt_DonHang_KeyDown
        private void txt_DonHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmTimDonHang dlg = new frmTimDonHang(_quyTrinh, _loai, txt_DonHang.Text,_nhapXuat);
                dlg.ShowDialog();
                if (_nhapXuat == true && (_loai == 0 || _loai == 1))
                {
                    if (dlg._donHangMua != null)
                    {
                        _donHangMua = dlg._donHangMua;
                        txt_DonHang.Text = _donHangMua.SoDonHang;
                        _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_donHangMua, _nhapXuat,_loai);                        
                    }
                }

                else if (_nhapXuat == true && _loai == 2)
                {
                    if (dlg._donNhanHangTra != null)
                    {
                        _donNhanHangTra = dlg._donNhanHangTra;
                        txt_DonHang.Text = _donNhanHangTra.SoDonHang;
                        _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_donNhanHangTra, _nhapXuat, _loai,_doiTuongNhapXuat);
                    }
                }

                else if (_nhapXuat == false && (_loai == 0 || _loai == 1))
                {
                    if (dlg._donHangBan != null)
                    {
                        _donHangBan = dlg._donHangBan;
                        txt_DonHang.Text = _donHangBan.SoDonHang;
                        _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_donHangBan, _nhapXuat,_loai);                        
                    }
                }
                else if (_nhapXuat == false && (_loai == 2))
                {
                    if (dlg._donTraHangMua != null)
                    {
                        _donTraHangMua = dlg._donTraHangMua;
                        txt_DonHang.Text = _donTraHangMua.SoDonHang;
                        _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_donTraHangMua, _nhapXuat, _loai);
                    }
                }               
                _lenhNhapXuatMuaBan.SoBangKe = LenhNhapXuatMuaBan.SoBangKeTuDongTang(_nhapXuat, _loai, _lenhNhapXuatMuaBan.DoiTuongNhapXuat, _lenhNhapXuatMuaBan.NgayLap);
                cTLenhNhapXuatListBindingSource.DataSource = _lenhNhapXuatMuaBan.CT_LenhNhapXuatList;
                lenhNhapXuatBindingSource.DataSource = _lenhNhapXuatMuaBan;
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

        #region grdu_CTLenhNhapXuatKho_Error
        private void grdu_CTLenhNhapXuatKho_Error(object sender, ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.Data)
                e.ErrorText = "Kiểu dữ liệu không hợp lệ";
        }
        #endregion 

        private void frmBangKeNhapDonHangChuan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Lenh Nhap Kho MH Le", "Help_BanHang.chm");
            }
        }

        private void txt_DonHang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}