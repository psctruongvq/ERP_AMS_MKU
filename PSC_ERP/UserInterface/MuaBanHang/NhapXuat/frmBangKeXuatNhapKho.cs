using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmBangKeXuatNhapKho : Form
    {
        CT_LenhNhapXuatList ctLenhNhapXuatList;
        CT_LenhNhapXuat_DonHangList ctLenhNhapXuat_DonHangList;
        LenhNhapXuatMuaBan lenhNhapXuatMuaBan =  LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan();
        byte _quyTrinh = 0;
        byte _loai = 0;
        bool _nhapXuat = false;

        #region frmBangKeXuatNhapKho()

        public frmBangKeXuatNhapKho()
        {
            InitializeComponent();
            Invisible();
           // KhoiTao();
        }

        public frmBangKeXuatNhapKho(byte quyTrinh, byte loai, bool nhapXuat)
        {
            InitializeComponent();
            _quyTrinh = quyTrinh;
            _nhapXuat = nhapXuat;
            KhoiTao(quyTrinh, loai,nhapXuat);
            KhoiTaoCombo(loai, nhapXuat);
            Invisible();
        }

        public frmBangKeXuatNhapKho(LenhNhapXuatMuaBan _lenhNhapXuatMuaBan)
        {
            InitializeComponent();
            _quyTrinh = _lenhNhapXuatMuaBan.QuyTrinh;
            _nhapXuat = _lenhNhapXuatMuaBan.LaNhap;
            _loai = _lenhNhapXuatMuaBan.Loai;
            KhoiTao(_lenhNhapXuatMuaBan);
            KhoiTaoCombo(_loai,_nhapXuat);
            Invisible();
        }

        #endregion

        #region KhoiTao()

        private void KhoiTao(byte quyTrinh, byte loai, bool nhapXuat)
        {
            lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(quyTrinh, nhapXuat);
            tenNhanVienListBindingSource.DataSource = TenNhanVienList.GetTenNhanVienList();
            khoListBindingSource.DataSource = KhoList.GetKhoList_LoaiKho(0);
            lenhNhapXuatMuaBanBindingSource.DataSource = lenhNhapXuatMuaBan;
            cTLenhNhapXuatListBindingSource.DataSource = lenhNhapXuatMuaBan.CT_LenhNhapXuatList;
            _loai = loai;           
            lenhNhapXuatMuaBan.Loai = loai;
            lenhNhapXuatMuaBan.LaNhap = nhapXuat;
            
        }

        private void KhoiTao(LenhNhapXuatMuaBan _lenhNhapXuatMuaBan)
        {
            tenNhanVienListBindingSource.DataSource = TenNhanVienList.GetTenNhanVienList();
            khoListBindingSource.DataSource = KhoList.GetKhoList_LoaiKho(0);
            lenhNhapXuatMuaBan = _lenhNhapXuatMuaBan;
            _loai = lenhNhapXuatMuaBan.Loai;
            bt_GetDanhSachDonHang.Enabled = false;
            lenhNhapXuatMuaBanBindingSource.DataSource = lenhNhapXuatMuaBan;
            cTLenhNhapXuatListBindingSource.DataSource = lenhNhapXuatMuaBan.CT_LenhNhapXuatList;                    
          
        }

        private void KhoiTaoCombo(Int16 loai, bool nhapXuat)
        {
            if (nhapXuat == true)
            {
                cmbeu_LoaiNhapXuat.Items.Clear();
                ValueListItem listItem = new ValueListItem();
                listItem.DataValue = loai;
                listItem.DisplayText = "Lệnh Nhập Kho Từ Đơn Hàng Lẻ";
                lb_SoLenh.Text = "Số Lệnh Nhập";
                lb_LoaiLenh.Text = "Loại Lệnh Nhập";
                lb_KhoNhapXuat.Text = "Nhập Vào Kho";
                this.Text = "Lệnh Nhập Kho";
                groupBox1.Text = "Thông Tin Lệnh Nhập Kho";
                groupBox2.Text = "Chi Tiết Lệnh Nhập Kho";
                cmbeu_LoaiNhapXuat.Items.Add(listItem);
            }
            else 
            {
                cmbeu_LoaiNhapXuat.Items.Clear();
                ValueListItem listItem = new ValueListItem();
                listItem.DataValue = loai;
                listItem.DisplayText = "Lệnh Xuất Kho Từ Đơn Hàng Lẻ";
                lb_SoLenh.Text = "Số Lệnh Xuất";
                lb_LoaiLenh.Text = "Loại Lệnh Xuất";
                lb_KhoNhapXuat.Text = "Xuất Từ Kho";
                this.Text = "Lệnh Xuất Kho";
                groupBox1.Text = "Thông Tin Lệnh Xuất Kho";
                groupBox2.Text = "Chi Tiết Lệnh Xuất Kho";
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
            //    MessageBox.Show(this, "Vui Lòng Nhập Số Lệnh Nhập Kho", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_SoBangKe.Focus();
            //    return false;
            //}
            if (lenhNhapXuatMuaBan.CT_LenhNhapXuatList.Count == 0)
            {
                MessageBox.Show(this, "Vui Nhập Chi Tiết Lệnh Nhập Xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if(lenhNhapXuatMuaBan.IsNew)
                    lenhNhapXuatMuaBan.SoBangKe = LenhNhapXuatMuaBan.SoBangKeTuDongTang(_nhapXuat,_loai,lenhNhapXuatMuaBan.DoiTuongNhapXuat, lenhNhapXuatMuaBan.NgayLap);

                lenhNhapXuatMuaBan.ApplyEdit();
                lenhNhapXuatMuaBan.Save();
            }
            catch (Exception ex)
            {
                kq = false;
            }
            return kq;
        }
        #endregion

        #region bt_GetDanhSachDonHang_Click

        private void bt_GetDanhSachDonHang_Click(object sender, EventArgs e)
        {
            if(cmbeu_LoaiNhapXuat.Value!=null)
            {
                Int16 loai = (Int16)cmbeu_LoaiNhapXuat.Value;
                frmDonHangLamLenhNhap dlg = new frmDonHangLamLenhNhap(_loai, _nhapXuat);
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    decimal TongTien = 0;
                    lenhNhapXuatMuaBan.CT_LenhNhapXuat_DonHangList= dlg.ctLenhNhapXuat_DonHangList;
                    lenhNhapXuatMuaBan.CT_LenhNhapXuatList = dlg.ctLenhNhapXuatList;                    
                    foreach (CT_LenhNhapXuat ct_lenhNhapXuat in lenhNhapXuatMuaBan.CT_LenhNhapXuatList)
                    {
                        TongTien = TongTien + ct_lenhNhapXuat.ThanhTien;
                    }
                    lenhNhapXuatMuaBan.TongTien = TongTien;
                    lenhNhapXuatMuaBan.MaDoiTac = dlg._maDoiTac;
                    cTLenhNhapXuatListBindingSource.DataSource = lenhNhapXuatMuaBan.CT_LenhNhapXuatList;
                }
            }
        }

        #endregion

        #region grdu_CTLenhNhapXuatKho_InitializeLayout
        private void grdu_CTLenhNhapXuatKho_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
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

            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Hàng Hóa/Dịch Vụ";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;

            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 3;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["SoLuong"].Hidden = false;

            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 4;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Hidden = false;
            
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 7;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].Hidden = false;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].Format = "###,###,###,###,###";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["DonGia"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 10;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].Hidden = false;
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].Format = "###,###,###,###,###";
            grdu_CTLenhNhapXuatKho.DisplayLayout.Bands[0].Columns["ThanhTien"].CellAppearance.TextHAlign = HAlign.Right;

        }
        #endregion

        #region cmbu_NhanVien_InitializeLayout
        private void cmbu_NhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition =1;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên" ;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 2;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 3;
            //cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenPhongBan"].Hidden = false;
            //cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenPhongBan"].Header.Caption = "Tên Phòng Ban";
            //cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenPhongBan"].Header.VisiblePosition = 4;            

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
                        bt_GetDanhSachDonHang.Enabled = false;
                    }
                    else MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            bt_GetDanhSachDonHang.Enabled = true;
            KhoiTao(_quyTrinh,_loai,_nhapXuat);
        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report;
            if (lenhNhapXuatMuaBan.IsNew == false)
            {

                if (lenhNhapXuatMuaBan.Loai == 0 || lenhNhapXuatMuaBan.Loai == 1)
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
                command.Parameters.AddWithValue("@MaLenhNhapXuat", lenhNhapXuatMuaBan.MaLenhNhapXuat);
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

        #region grdu_CTLenhNhapXuatKho_Error
        private void grdu_CTLenhNhapXuatKho_Error(object sender, ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.Data)
                e.ErrorText = "Kiểu dữ liệu không hợp lệ";
        }
        #endregion

        private void frmBangKeXuatNhapKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Lenh Nhap Kho MH Le", "Help_BanHang.chm");
            }
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Lenh Nhap Kho MH Le", "Help_BanHang.chm");
        }
    }
}