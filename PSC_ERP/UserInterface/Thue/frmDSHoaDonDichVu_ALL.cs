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
namespace PSC_ERP
{
    public partial class  frmDSHoaDonDichVu_ALL : Form
    {    
        HoaDonList _HoaDonList=HoaDonList.NewHoaDonList();
        HoaDonList _HoaDonList_Copy = HoaDonList.NewHoaDonList();
        DoiTacList _DoiTacList;
        HoaDon_DoiTacList _hdDOitacList;
        HoaDon_DoiTac _hdDOitac;
        HoaDon_DoiTacList _hdDOitacListGet;
        HamDungChung hamDungChung = new HamDungChung();
        Util util = new Util();
        int _loai = 0;
        private FilterCombo fCombo;
        int _sorecord_copy = 0;
        public  frmDSHoaDonDichVu_ALL()
        {
            InitializeComponent();
            hoaDonListBindingSource.DataSource = typeof(LoaiHoaDonList);
            doiTacListBindingSource.DataSource = typeof(DoiTacList);
            phuongThucThanhToanListBindingSource.DataSource = typeof(PhuongThucThanhToanList);
            grdu_DSHoaDonDichVu.DataSource = hoaDonListBindingSource;
            KhoiTao();
          
            fCombo = new FilterCombo(grdu_DSHoaDonDichVu, "MaDoiTac", "TenDoiTac");
        }

        public frmDSHoaDonDichVu_ALL(byte loaiHD)
        {
            InitializeComponent();
            KhoiTao();
        }            

        public void KhoiTao()
        {
            //grdu_DSHoaDonDichVu.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            //grdu_DSHoaDonDichVu.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0,0));
            //grdu_DSHoaDonDichVu.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));


            grdu_DSHoaDonDichVu.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_DSHoaDonDichVu.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_DSHoaDonDichVu.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            grdu_DSHoaDonDichVu.DoubleClickCell += new DoubleClickCellEventHandler(grdData_DoubleClickCell);

            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
            _DoiTacList.Insert(0, _DoiTac);
            DoiTac _DoiTac1 = DoiTac.NewDoiTac(0, "<None>");
            _DoiTacList.Insert(0, _DoiTac1);
            doiTacListBindingSource.DataSource = _DoiTacList;         

            LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value));
        }

        public void LayHoaDon(byte loai, DateTime tuNgay, DateTime denNgay)
        {
            _HoaDonList = HoaDonList.GetHoaDonListByCT(loai, 0, tuNgay, denNgay);
            hoaDonListBindingSource.DataSource = _HoaDonList;
            _hdDOitacList = HoaDon_DoiTacList.NewHoaDon_DoiTacList();
            for (int i = 0; i < grdu_DSHoaDonDichVu.Rows.Count; i++)
            {
                // gan vaop du lieu hoa don
                if ((long)grdu_DSHoaDonDichVu.Rows[i].Cells["MaDoiTac"].Value <= 0)
                {
                    long _mahoadon = (long)grdu_DSHoaDonDichVu.Rows[i].Cells["Mahoadon"].Value;
                    _hdDOitacListGet = HoaDon_DoiTacList.GetHoaDon_DoiTacList(_mahoadon);
                    if (_hdDOitacListGet.Count != 0)
                    {
                        grdu_DSHoaDonDichVu.Rows[i].Cells["TenKhachHAngNgoai"].Value = _hdDOitacListGet[0].TenDoiTac;
                        grdu_DSHoaDonDichVu.Rows[i].Cells["NguoiLienLacNgoai"].Value = _hdDOitacListGet[0].NguoiLienHe;
                        grdu_DSHoaDonDichVu.Rows[i].Cells["MSThueNgoai"].Value = _hdDOitacListGet[0].MSThue;
                        grdu_DSHoaDonDichVu.Rows[i].Cells["DiaChiNgoai"].Value = _hdDOitacListGet[0].DiaChi;
                        grdu_DSHoaDonDichVu.Rows[i].Cells["DTNgoai"].Value = _hdDOitacListGet[0].DienThoai;
                    }
                }
            }
        } 
     
        private void grdu_DSHoaDonDichVu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {


            this.grdu_DSHoaDonDichVu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DSHoaDonDichVu.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DSHoaDonDichVu.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }


            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["mahoadon"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["mahoadon"].Header.Caption = "No.";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["mahoadon"].Header.VisiblePosition = 0;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["mahoadon"].CellActivation = Activation.NoEdit;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoSerial"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoSerial"].Header.Caption = "Số Serial";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoSerial"].Header.VisiblePosition = 1;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoHoaDon"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";            
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoHoaDon"].Header.VisiblePosition = 2;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLap"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLap"].Header.VisiblePosition = 3;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["maDoiTac"].Header.Caption = "Khách Hàng";            
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["maDoiTac"].Header.VisiblePosition = 4;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["maDoiTac"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["maDoiTac"].Width = 250;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["maDoiTac"].EditorComponent = cmbu_KhachHang;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["MaSoThue"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["MaSoThue"].Header.VisiblePosition = 5;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["GhiCHu"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["GhiCHu"].Header.Caption = "Diễn Giải";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["GhiCHu"].Header.VisiblePosition = 6;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThanhTien"].Header.Caption = "Tiền Trước Thuế";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThanhTien"].Header.VisiblePosition = 7;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThanhTien"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThanhTien"].Format = "#,###";
            //grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThanhTien"].MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn,nnn";

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThueSuatVAt"].Header.Caption = "Thuế Suất";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThueSuatVAt"].Header.VisiblePosition = 8;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThueSuatVAt"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThueSuatVAt"].EditorComponent = cmbe_ThueVAT;


            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThueVAT"].Header.Caption = "Tiền Thuế";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThueVAT"].Header.VisiblePosition = 9;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThueVAT"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThueVAT"].Format = "#,###";
            //grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["ThueVAT"].MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn,nnn";

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].Header.Caption = "Tiền Sau Thuế";            
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].Header.VisiblePosition = 10;            
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].Format = "#,###";
            //grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn,nnn";

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["maHinhThucTT"].Hidden = true;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["maHinhThucTT"].Header.Caption = "Hình Thức Thanh Toán";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["maHinhThucTT"].Header.VisiblePosition = 11;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["maHinhThucTT"].EditorComponent = cbo_hinhthuctt;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["KhauTruThue"].Hidden = true;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["KhauTruThue"].Header.Caption = "HĐ Khấu Trừ Thuế";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["KhauTruThue"].Header.VisiblePosition = 12;



            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns.Add("TenKhachHangNgoai");
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TenKhachHangNgoai"].Header.Caption = "Tên KH Ngoài";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TenKhachHangNgoai"].Hidden = true;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TenKhachHangNgoai"].Header.VisiblePosition = 13;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TenKhachHangNgoai"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TenKhachHangNgoai"].Header.Appearance.BackColor = System.Drawing.Color.PeachPuff;//x =  //= System.Drawing.w;//RoyalBlue

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns.Add("MSThueNgoai");
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["MSThueNgoai"].Header.Caption = "MS Thuế";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["MSThueNgoai"].Hidden = true;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["MSThueNgoai"].Header.VisiblePosition = 14;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["MSThueNgoai"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["MSThueNgoai"].Header.Appearance.BackColor = System.Drawing.Color.PeachPuff;//x =  //= System.Drawing.w;//RoyalBlue

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns.Add("NguoiLienLacNgoai");
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NguoiLienLacNgoai"].Header.Caption = "Người Liên Hệ";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NguoiLienLacNgoai"].Hidden = true;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NguoiLienLacNgoai"].Header.VisiblePosition = 15;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NguoiLienLacNgoai"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NguoiLienLacNgoai"].Header.Appearance.BackColor = System.Drawing.Color.PeachPuff;//x =  //= System.Drawing.w;//RoyalBlue

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns.Add("diachiNgoai");
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["diachiNgoai"].Header.Caption = "Địa Chỉ";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["diachiNgoai"].Hidden = true;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["diachiNgoai"].Header.VisiblePosition = 16;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["diachiNgoai"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["diachiNgoai"].Header.Appearance.BackColor = System.Drawing.Color.PeachPuff;//x =  //= System.Drawing.w;//RoyalBlue

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns.Add("DTNgoai");
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["DTNgoai"].Header.Caption = "Điện Thoại";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["DTNgoai"].Hidden = true;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["DTNgoai"].Header.VisiblePosition = 17;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["DTNgoai"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["DTNgoai"].Header.Appearance.BackColor = System.Drawing.Color.PeachPuff;//x =  //= System.Drawing.w;//RoyalBlue

            
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoCT_HD"].Header.Caption = "Số CT";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoCT_HD"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoCT_HD"].Header.VisiblePosition = 18;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoCT_HD"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoCT_HD"].Header.Appearance.BackColor = System.Drawing.Color.PeachPuff;//x =  //= System.Drawing.w;//RoyalBlue


            grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Hidden = true;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonTSCDList"].Hidden = true;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonList"].Hidden = true;

            
            
            
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;          
            e.Layout.Override.CellClickAction = CellClickAction.CellSelect;


        }     
     
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value));
        }   

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }    
      
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
           // try
           // {
                grdu_DSHoaDonDichVu.UpdateData();
                for (int i = 0; i < grdu_DSHoaDonDichVu.Rows.Count; i++)
                {
                    if ((long)grdu_DSHoaDonDichVu.Rows[i].Cells["MaDoiTac"].Value > 0 && Convert.ToString(grdu_DSHoaDonDichVu.Rows[i].Cells["TenKhachHangNgoai"].Value).Trim() != "")
                    {
                        MessageBox.Show(this, "Nhập liệu khách hàng không đồng thời chọn khách hàng trong danh mục và ngoài danh mục.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        grdu_DSHoaDonDichVu.Rows[i].Selected = true;
                        return;
                    }
                    if ((long)grdu_DSHoaDonDichVu.Rows[i].Cells["MaDoiTac"].Value <= 0 && Convert.ToString(grdu_DSHoaDonDichVu.Rows[i].Cells["TenKhachHangNgoai"].Value).Trim() == "")
                    {
                        MessageBox.Show(this, "Vui lòng chọn khách hàng.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        grdu_DSHoaDonDichVu.Rows[i].Selected = true;
                        return;
                    }              

                }                                         
                for (int i = 0; i < _HoaDonList.Count; i++)               
                    _HoaDonList[i].LoaiHoaDon = 4;                                                
                _HoaDonList.ApplyEdit();
                _HoaDonList.Save();


                for (int i = 0; i < grdu_DSHoaDonDichVu.Rows.Count; i++)
                {
                    if ((long)grdu_DSHoaDonDichVu.Rows[i].Cells["MaDoiTac"].Value <= 0)
                    {
                        _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
                        _hdDOitac.MaHoaDon = (long)grdu_DSHoaDonDichVu.Rows[i].Cells["MaHoaDon"].Value;
                        _hdDOitac.TenDoiTac = Convert.ToString  (grdu_DSHoaDonDichVu.Rows[i].Cells["TenKhachHAngNgoai"].Value);
                        _hdDOitac.NguoiLienHe = Convert.ToString(grdu_DSHoaDonDichVu.Rows[i].Cells["NguoiLienLacNgoai"].Value);
                        _hdDOitac.MSThue = Convert.ToString  (grdu_DSHoaDonDichVu.Rows[i].Cells["MSThueNgoai"].Value);
                        _hdDOitac.DiaChi = Convert.ToString  (grdu_DSHoaDonDichVu.Rows[i].Cells["DiaChiNgoai"].Value);
                        _hdDOitac.DienThoai = Convert.ToString  (grdu_DSHoaDonDichVu.Rows[i].Cells["DTNgoai"].Value);
                        _hdDOitacList.Add(_hdDOitac);
                    }
                }
                _hdDOitacList.ApplyEdit();
                _hdDOitacList.Save();
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tlslblTim_Click(sender, e);
           // }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, ex.ToString(), util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);                
            //}
        }     

        private void cmbu_KhachHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
           

            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["KhachHang"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["NhaCungCap"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["LoaiDoitac"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["DienThoai"].Hidden = true;

            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 100;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 1;

            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoitac"].Header.Caption = "Tên Khách Hàng";
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoitac"].Width = 250;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoitac"].Header.VisiblePosition = 0;


            this.cmbu_KhachHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;//appearance17;
            this.cmbu_KhachHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_KhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void cmbu_KhachHang_AfterCloseUp(object sender, EventArgs e)
        {
            long ma = 0;
            if (cmbu_KhachHang.ActiveRow != null)
            {
                if (cmbu_KhachHang.Text == "Thêm Mới...")
                {
                    frmKhachHang _frmKhachHang = new frmKhachHang();
                    if (_frmKhachHang.ShowDialog() != DialogResult.OK)
                    {
                        _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
                        DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
                        _DoiTacList.Insert(0, _DoiTac);
                        DoiTac _DoiTac1 = DoiTac.NewDoiTac(0, "<None>");
                        _DoiTacList.Insert(0, _DoiTac1);
                        ma = _DoiTacList[_DoiTacList.Count - 1].MaDoiTac;
                        cmbu_KhachHang.Value = ma;
                        doiTacListBindingSource.DataSource = _DoiTacList;
                    }
                }
            }
        }      

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdu_DSHoaDonDichVu.ActiveRow != null)
            {
                _sorecord_copy = grdu_DSHoaDonDichVu.Selected.Rows.Count;
                MessageBox.Show(this,"Đã sao chép được " + _sorecord_copy.ToString() + " dòng");
                if (_sorecord_copy != 0)
                {
                    _HoaDonList_Copy=HoaDonList.NewHoaDonList();
                    HoaDon hd = HoaDon.NewHoaDon();
                    for (int i = 0; i < grdu_DSHoaDonDichVu.Rows.Count; i++)
                    {
                        if (grdu_DSHoaDonDichVu.Rows[i].Selected)
                        {
                            hd = HoaDon.NewHoaDon();
                            hd.SoHoaDon = grdu_DSHoaDonDichVu.Rows[i].Cells["Sohoadon"].Value.ToString();
                            hd.SoSerial = grdu_DSHoaDonDichVu.Rows[i].Cells["SoSerial"].Value.ToString();
                            hd.NgayLap = Convert.ToDateTime(grdu_DSHoaDonDichVu.Rows[i].Cells["NgayLap"].Value);
                            hd.MaDoiTac = (long)grdu_DSHoaDonDichVu.Rows[i].Cells["MaDoiTac"].Value;
                            hd.GhiChu = grdu_DSHoaDonDichVu.Rows[i].Cells["Ghichu"].Value.ToString();
                            hd.ThanhTien = (decimal)grdu_DSHoaDonDichVu.Rows[i].Cells["ThanhTien"].Value;
                            hd.ThueSuatVAT = (double)grdu_DSHoaDonDichVu.Rows[i].Cells["ThueSuatVAT"].Value;
                            hd.ThueVAT = (decimal)grdu_DSHoaDonDichVu.Rows[i].Cells["ThueVAT"].Value;
                            hd.TongTien = (decimal)grdu_DSHoaDonDichVu.Rows[i].Cells["TongTien"].Value;
                            hd.VietBangChu = grdu_DSHoaDonDichVu.Rows[i].Cells["VietBangChu"].Value.ToString();
                            hd.NgayHetHanTT = Convert.ToDateTime(grdu_DSHoaDonDichVu.Rows[i].Cells["NgayHetHanTT"].Value);
                            hd.KhauTruThue = (bool)grdu_DSHoaDonDichVu.Rows[i].Cells["KhauTruThue"].Value;
                            _HoaDonList_Copy.Add(hd);
                        }                            
                    }
                }
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            // neu so luong copy la 1 dong thi bat lenh lam nhieu dong con neu nguoc lai thi khong
            if (_HoaDonList_Copy.Count > 0)
            {
                if (_HoaDonList_Copy.Count == 1)
                {
                    string result = Microsoft.VisualBasic.Interaction.InputBox("Nhập số lượng dòng cần sao chép", "Copy", "", (this.Width / 2) + 100, (this.Height / 2) + 100);
                    // duyet qua tung dong copy va Insert truc tiep vao trong bang
                    int sodong = Convert.ToInt32(result);
                    HoaDon __hd;
                    for (int i = 0; i < sodong; i++)
                    {
                        __hd = HoaDon.NewHoaDon();

                        __hd.SoHoaDon = _HoaDonList_Copy[0].SoHoaDon;
                        __hd.SoSerial = _HoaDonList_Copy[0].SoSerial;
                        __hd.NgayLap = _HoaDonList_Copy[0].NgayLap;
                        __hd.MaDoiTac = _HoaDonList_Copy[0].MaDoiTac;
                        __hd.GhiChu = _HoaDonList_Copy[0].GhiChu;
                        __hd.ThanhTien = _HoaDonList_Copy[0].ThanhTien;
                        __hd.ThueSuatVAT = _HoaDonList_Copy[0].ThueSuatVAT;
                        __hd.ThueVAT = _HoaDonList_Copy[0].ThueVAT;
                        __hd.TongTien = _HoaDonList_Copy[0].TongTien;
                        __hd.VietBangChu = _HoaDonList_Copy[0].VietBangChu;
                        __hd.NgayHetHanTT = _HoaDonList_Copy[0].NgayHetHanTT;
                        __hd.KhauTruThue = _HoaDonList_Copy[0].KhauTruThue;


                        _HoaDonList.Add(__hd);
                    }
                }
                else
                {
                    foreach (HoaDon hd in _HoaDonList_Copy)
                    {
                        _HoaDonList.Add(hd);
                    }
                }
            }
            hoaDonListBindingSource.DataSource = _HoaDonList;

        }


        #region process 
        private bool iskeyok = false;
        private bool iscopyok = false;
        private object copyvalue;
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_DSHoaDonDichVu.ActiveCell != null && !grdu_DSHoaDonDichVu.ActiveCell.IsInEditMode && grdu_DSHoaDonDichVu.ActiveCell.Column.Key != "MaDoitac" && grdu_DSHoaDonDichVu.ActiveCell.Column.Key != "mahoadon")
            {
                if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                {
                    grdu_DSHoaDonDichVu.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    grdu_DSHoaDonDichVu.ActiveCell.SelectAll();
                    iskeyok = true;
                }
                if (e.KeyCode == Keys.Space && grdu_DSHoaDonDichVu.ActiveCell.Column.DataType == typeof(bool))
                {
                    grdu_DSHoaDonDichVu.ActiveCell.Value = !Convert.ToBoolean(grdu_DSHoaDonDichVu.ActiveCell.Value);
                }
            }          
        }
        private void grdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (iskeyok && grdu_DSHoaDonDichVu.ActiveCell.Row.IsDataRow)
            {
                if (grdu_DSHoaDonDichVu.ActiveCell.Column.DataType == typeof(decimal))
                    try
                    {
                        grdu_DSHoaDonDichVu.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                    }
                    catch
                    { }
                else
                    grdu_DSHoaDonDichVu.ActiveCell.Value = e.KeyChar.ToString();
                grdu_DSHoaDonDichVu.ActiveCell.SelStart = grdu_DSHoaDonDichVu.ActiveCell.Text.Length;
                e.Handled = true;
                iskeyok = false;
            }
        }    
        private void grdData_BeforeMultiCellOperation(object sender, Infragistics.Win.UltraWinGrid.BeforeMultiCellOperationEventArgs e)
        {
            if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Copy)
            {
                if (e.Cells.RowCount == 1 && e.Cells.ColumnCount == 1)
                {
                    iscopyok = true;
                    copyvalue = e.Cells[0, 0].Value;
                }
            }
            else
                if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Paste)
                {
                    if (iscopyok && grdu_DSHoaDonDichVu.Selected != null && grdu_DSHoaDonDichVu.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_DSHoaDonDichVu.Selected.Cells)
                        {
                            try
                            {
                                item.Value = copyvalue;
                                item.Row.Update();
                            }
                            catch { }
                        }
                    }
                    if (!iscopyok && grdu_DSHoaDonDichVu.Selected != null && grdu_DSHoaDonDichVu.Selected.Cells != null)
                    {
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_DSHoaDonDichVu.Selected.Cells)
                        {
                            try
                            {
                                
                                item.Row.Update();
                            }
                            catch { }
                        }
                    }
                    iscopyok = false;
                }
        }
        private void grdData_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            grdu_DSHoaDonDichVu.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        }
        #endregion

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DSHoaDonDichVu.ActiveRow != null)
            {
                grdu_DSHoaDonDichVu.DeleteSelectedRows();
            }
        }

        private void tlsxuatexcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_DSHoaDonDichVu);
        }

    

     
    }
}