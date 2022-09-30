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
using System.Runtime.InteropServices;


namespace PSC_ERP
{

    public partial class frmDanhSachChungTu_HoaDon : Form
    {
     
        long MaDangNhap = ERP_Library.Security.CurrentUser.Info.UserID;
        public bool IsSave = false;
        public HoaDonList _HoaDonList = HoaDonList.NewHoaDonList();
        public ChungTu_HoaDonList ct_hdList=ChungTu_HoaDonList.NewChungTu_HoaDonList();
        public decimal TongTien = 0;
        public decimal TongTienThue = 0;
        public Decimal TongTienChungTu = 0;
        decimal _tongtienthue = 0;      
        ChungTuRutGonList _chungTuList;
        int _mabuttoan = 0;
        ChungTu _ct = ChungTu.NewChungTu();
        decimal _tongtienhoadon = 0;
        ButToan _bt;
        decimal _tongtienhd = 0;

        #region Load
        public frmDanhSachChungTu_HoaDon()
        {
            InitializeComponent();
            this.DSHoaDonDichVu_BindingSource.DataSource = typeof(HoaDonList);
            this.bdCT_HoaDon.DataSource = typeof(ChungTu_HoaDonList);
            this.bindingSource1_ChungTu.DataSource = typeof(ChungTuRutGonList);
        }   
        private void cbChungTu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChungTu, "SoChungTu");
            foreach (UltraGridColumn col in this.cbChungTu.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                if (col.DataType == typeof(decimal))
                {
                    col.Format = "###,###,###,####,###";
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
            }
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 300;
         
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
        }       
        private void grdu_DSHoaDon_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdu_DSHoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.CellAppearance.TextHAlign = HAlign.Right;
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
                    col.Format = "###,###,###,###,###,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
                col.CellActivation = Activation.NoEdit;
            }
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["Chon"].CellActivation = Activation.AllowEdit;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chọn";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 30;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["LoaiHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["LoaiHoaDon"].Header.Caption = "Loại HĐ";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["LoaiHoaDon"].Header.VisiblePosition = 1;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["LoaiHoaDon"].EditorComponent = cbo_LoaiHoaDon;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 70;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.VisiblePosition = 3;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Width = 80;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].CellAppearance.TextHAlign = HAlign.Center;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.Caption = "Số Serial";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.VisiblePosition = 4;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Width = 50;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 6;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Width = 120;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["ThueVAt"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["ThueVAt"].Header.Caption = "Tiền Thuế";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["ThueVAt"].Header.VisiblePosition = 5;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["ThueVAt"].Width = 120;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].Hidden = false;
            // grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].CellActivation = Activation.AllowEdit;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].Header.Caption = "Số Tiền Đã Thanh Toán";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].Header.VisiblePosition = 7;


            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["ThueVAt"];
            SummarySettings summary2 = grdu_DSHoaDon.DisplayLayout.Bands[0].Summaries.Add("ThueVAt", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary2.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            summary2.SummaryType = SummaryType.Sum;
            summary2.SummaryPositionColumn = columnToSummarize2;


            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Top;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }
  
       
        #endregion

        #region Event
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            // kiem tra da co hoa don cho chung tu nay chua
            if (_bt.ChungTu_HoaDonList.Count != 0)
            {
                MessageBox.Show(this, "Đã có hóa đơn cho chứng từ này đề nghị xem lại dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ct.NgayLap);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Them())
                    Save();
            }
           
        
        }
        private void grdu_DSHoaDon_DoubleClick(object sender, EventArgs e)
        {
            //if (grdu_DSHoaDon.ActiveRow != null && grdu_DSHoaDon.ActiveRow.IsFilterRow==false)
            //{
            //    HoaDon _HoaDon = HoaDon.NewHoaDon();
            //    _HoaDon = HoaDon.GetHoaDon((long)grdu_DSHoaDon.ActiveRow.Cells["MaHoaDon"].Value);
            //    if ((int)grdu_DSHoaDon.ActiveRow.Cells["LoaiHoaDon"].Value == 4) // mua vao 
            //    {
            //        frmHoaDonDichVuMuaVao _frmHoaDonDichVu = new frmHoaDonDichVuMuaVao(_HoaDon);
            //        _frmHoaDonDichVu.ShowDialog();
            //    }

            //    else // ban ra
            //    {
            //        frmHoaDonDichVuBanRa _frmHoaDonDichVu = new frmHoaDonDichVuBanRa(_HoaDon);
            //        _frmHoaDonDichVu.ShowDialog();
            //    }
            //}
           
            //    //hd.SoTienDaThanhToan = (decimal)grdu_DSHoaDon.ActiveRow.Cells["SoTienDaThanhToan"].Value;
            //_HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
            //DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;


        }
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }     

        private void tlshdmuavao_Click(object sender, EventArgs e)
        {
            
            
            if (_ct.MaChungTu == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn chứng từ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_ct.DoiTuong, _ct.NgayLap.Date,false);
            frmhoadondichvu.ShowDialog();


            _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
            DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;



        }
        private void tlshdbanra_Click(object sender, EventArgs e)
        {
            if (_ct.MaChungTu == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn chứng từ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmHoaDonDichVuBanRa frmhoadondichvu = new frmHoaDonDichVuBanRa(_ct.DoiTuong,5, _ct.NgayLap.Date);
            frmhoadondichvu.ShowDialog();
            
            //if (_ct.DoiTuong != 0) // nam trong danh muc khach hang
            //{
            //    _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(_ct.DoiTuong, 0, false, _ct.MaChungTu);
            //    DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            //}
            //else //ngoai danh muc 
            //{
                _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
                DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            //}

        }
        private void grdu_DSHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_DSHoaDon.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Space)
                {
                    if ((bool)grdu_DSHoaDon.ActiveRow.Cells["Chon"].Value)
                        grdu_DSHoaDon.ActiveRow.Cells["Chon"].Value = false;
                    else
                        grdu_DSHoaDon.ActiveRow.Cells["Chon"].Value = true;
                    grdu_DSHoaDon.Refresh();
                }
            }
        }
        private void tlstim_Click(object sender, EventArgs e)
        {
            TongTienChungTu = 0;
            int taikhoan31131 = HeThongTaiKhoan1.LayMaTaiKhoan("31131");
            int taikhoan31132 = HeThongTaiKhoan1.LayMaTaiKhoan("31132");

            frmTimChungTuNew_TheoHD f = new frmTimChungTuNew_TheoHD("CTHD");
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                if (f._ChungTu1.MaChungTu != 0)
                {
                    bindingSource1_ChungTu.DataSource = ChungTuRutGon.GetChungTuRutGon(f._ChungTu1.MaChungTu);
                    _ct = ChungTuList.GetChungTuListByMaChungTuByLoc(f._ChungTu1.MaChungTu)[0];                  
                    cbChungTu.Value = _ct.MaChungTu;
                    btn_chonbt.Enabled = true;
                    // kiem tra neu chung tu chi co 1 but toan thi lay tu dong
                    if (_ct.DinhKhoan.ButToan.Count == 1)
                    {
                        this._mabuttoan = _ct.DinhKhoan.ButToan[0].MaButToan;
                        _bt = _ct.DinhKhoan.ButToan[0];
                        TongTienChungTu = _ct.DinhKhoan.ButToan[0].SoTien;
                        cbSoTien.Value = TongTienChungTu;
                        if (_ct.DinhKhoan.LaMotNoNhieuCo == true)
                            txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_ct.DinhKhoan.ButToan[0].CoTaiKhoan).SoHieuTK;
                        else
                            txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_ct.DinhKhoan.ButToan[0].NoTaiKhoan).SoHieuTK;
                    }
                    else // lay but toan co tai khoan 31131
                    {
                        foreach (ButToan bt in _ct.DinhKhoan.ButToan)
                        {
                            if (taikhoan31131 == bt.NoTaiKhoan || taikhoan31132 == bt.NoTaiKhoan)
                            {
                                this._mabuttoan = bt.MaButToan;
                                _bt = bt;
                                TongTienChungTu = _bt.SoTien;
                                cbSoTien.Value = TongTienChungTu;
                                txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan).SoHieuTK;
                            }
                        }                       
                    }

                    // Load ds hoa don phai theo but toan 
                    _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
                    DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
                    bdCT_HoaDon.DataSource = _bt.ChungTu_HoaDonList;

                    if (_bt.ChungTu_HoaDonList.Count != 0)
                        tlslblThem.Enabled = true;
                    else
                        tlslblThem.Enabled = false;

                    // check chon tat ca hoa don
                    for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
                    {
                        grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
                    }      
                }
            }
        }
      
   
        #endregion

        #region Process
        private bool Them()
        {
            _tongtienthue = 0;
            _tongtienhoadon = 0;
            grdu_DSHoaDon.UpdateData();
            if (_ct.MaChungTu == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn chứng từ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this._mabuttoan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn bút toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                if ((bool)grdu_DSHoaDon.Rows[i].Cells["Chon"].Value == true && grdu_DSHoaDon.Rows[i].IsFilterRow == false)
                {
                    long maHoaDon = (long)grdu_DSHoaDon.Rows[i].Cells["MaHoaDon"].Value;
                    _tongtienthue = _tongtienthue + (decimal)grdu_DSHoaDon.Rows[i].Cells["ThueVAT"].Value;
                    _tongtienhoadon = _tongtienhoadon + (decimal)grdu_DSHoaDon.Rows[i].Cells["ThanhTien"].Value;
                    decimal _tienthue = (decimal)grdu_DSHoaDon.Rows[i].Cells["ThueVAT"].Value;
                }
            }

            //if (_tongtienthue != 0)
            //{
            //    if (_tongtienthue != TongTienChungTu)
            //    {
            //        MessageBox.Show("Tổng tiền hóa đơn khác tổng tiền bút toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            //else
            //{
            //    if (_tongtienhoadon != TongTienChungTu)
            //    {
            //        MessageBox.Show("Tổng tiền hóa đơn khác tổng tiền bút toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            ChungTu_HoaDon ct_hd;
            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                bool exists = false;
                if ((bool)grdu_DSHoaDon.Rows[i].Cells["Chon"].Value == true && grdu_DSHoaDon.Rows[i].IsFilterRow == false)
                {
                    long maHoaDon = (long)grdu_DSHoaDon.Rows[i].Cells["MaHoaDon"].Value;
                    decimal _tienhoadon = (decimal)grdu_DSHoaDon.Rows[i].Cells["ThanhTien"].Value;
                    decimal _tienthue = (decimal)grdu_DSHoaDon.Rows[i].Cells["ThueVAT"].Value;
                    string soHoaDon = (string)grdu_DSHoaDon.Rows[i].Cells["SoHoaDon"].Value;

                    // truong hop khi edite lai cho nguoi dung them vao danh sach co san           
                    foreach (ChungTu_HoaDon ct_hd1 in _bt.ChungTu_HoaDonList)
                    {
                        if (maHoaDon == ct_hd1.MaHoaDon)//Đã tồn tại hóa đơn bên danh sách Chứng từ-hóa đơn list                      
                            exists = true;

                    }
                    if (exists == false)
                    {
                        ct_hd = ChungTu_HoaDon.NewChungTu_HoaDon();
                        if (_tongtienthue != 0)
                        {
                            ct_hd.SoTien = _tongtienthue;
                            ct_hd.SoTienSeThanhToan = _tienthue;
                        }
                        else
                        {
                            ct_hd.SoTien = _tongtienhoadon;
                            ct_hd.SoTienSeThanhToan = _tienhoadon;
                        }
                       
                        //ct_hd.SoTienDaThanhToan = 0;
                        ct_hd.MaHoaDon = maHoaDon;
                        ct_hd.MaChungTu = _ct.MaChungTu;
                        ct_hd.MaButToan = this._mabuttoan;
                        ct_hd.SoHoaDon = soHoaDon;
                        _bt.ChungTu_HoaDonList.Add(ct_hd);
                    }
                }
            }
            // kiem tra tog tien trong hoa don va tong tien trong chung tu phai bang nhai thi moi cho luu

          
            this.bdCT_HoaDon.DataSource = _bt.ChungTu_HoaDonList;
            return true;
        }
        private void Save()
        {
          

            try
            {
                _bt.ChungTu_HoaDonList._Update();                
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);          
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            

        }
        #endregion                                                          

        private void btn_chonbt_Click(object sender, EventArgs e)
        {
            frmDSButToan_ChungTu f = new frmDSButToan_ChungTu(this._ct);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                if (f._mabt != 0)
                {
                    this._mabuttoan = f._mabt;
                    this._bt = f._bt;
                    TongTienChungTu = f._sotien;
                    cbSoTien.Value = TongTienChungTu;

                    if (_ct.DinhKhoan.LaMotNoNhieuCo)                   
                        txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_bt.CoTaiKhoan).SoHieuTK;                   
                    else                  
                        txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_bt.NoTaiKhoan).SoHieuTK;                   
                    // kh \i nay moi Load ds hoa don len

                    _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
                    DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
                    bdCT_HoaDon.DataSource = _bt.ChungTu_HoaDonList;

                    if (_bt.ChungTu_HoaDonList.Count != 0)
                        tlslblThem.Enabled = true;
                    else
                        tlslblThem.Enabled = false;
                    for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
                    {
                        grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
                    }      
                }
            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            frmDanhSachHoaDonDichVu_DadinhKem frm = new frmDanhSachHoaDonDichVu_DadinhKem(_ct, _bt);
            frm.ShowDialog();

            _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
            DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;           
        }

        private void hóaĐơnMuaVàoKhôngCóVATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ct.MaChungTu == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn chứng từ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

         
          
            frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_ct.DoiTuong, _ct.NgayLap.Date, true);
            frmhoadondichvu.ShowDialog();


            _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
            DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
        }

        private void grdu_DSHoaDon_AfterCellUpdate(object sender, CellEventArgs e)
        {
            grdu_DSHoaDon.UpdateData();
            decimal _ttthue = 0, _tthd = 0;
            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                if ((bool)grdu_DSHoaDon.Rows[i].Cells["Chon"].Value)
                {
                    _ttthue = _ttthue + (decimal)grdu_DSHoaDon.Rows[i].Cells["ThueVAT"].Value;
                    _tthd = _tthd + (decimal)grdu_DSHoaDon.Rows[i].Cells["ThanhTien"].Value;
                }
            }
            if (_ttthue != 0)
            {
                txttienhoadon.Value = _ttthue;
            }
            else
            {
                txttienhoadon.Value = _tthd;
            }
        }
        
                
    }
}