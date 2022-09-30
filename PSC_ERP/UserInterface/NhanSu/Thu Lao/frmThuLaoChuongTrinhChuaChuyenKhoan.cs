using System;
using System.Collections;
using System.Windows.Forms;

using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using ERP_Library.Security;

namespace PSC_ERP
{//1/
    public partial class frmThuLaoChuongTrinhChuaChuyenKhoan : Form
    {
        ChiThuLaoList _chiThuLaoList;
        BoPhanList _boPhanList;
        ChuongTrinhList _chuongTrinhList;
        KyTinhLuongList _kyTinhLuongList;
        ERP_Library.ThongTinNhanVienTongHopList _nhanVienList;
        ThuLaoChuongTrinhList _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.NewThuLaoChuongTrinhList();
        GiayXacNhanChuongTrinhList _giayXacNhanChuongTrinhList = GiayXacNhanChuongTrinhList.NewGiayXacNhanChuongTrinhList();
        ChiTietGiayXacNhanTongHopList _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.NewChiTietGiayXacNhanTongHopList();
        ChiTietGiayXacNhan chiTietGXN = ChiTietGiayXacNhan.NewChiTietGiayXacNhan();
        decimal _tienChiTietGiayXacNhan = 0;
        int maKyTinhLuongMoi = 0;
    
        DateTime _ngayLap;
        static int maBoPhan = 0;
        static int maKyTinhluong = 0;
        static int maChuongTrinh = 0;
        int maGiayXacNhan = 0;
        int maBoPhanDen = 0;
        int maChiTietGiayXacNhan = 0;
        bool nhapHo = false;
        string tenGiayXacNhan = string.Empty;
        string tenChuongTrinh = string.Empty;
        bool _thanhToan = false;
        bool _hoanTat = false;
        string tenNguon = string.Empty;
        int maNguon = 0;
        int _maChiTietGiayXacNhan_Update = 0;
        ArrayList arr= ERP_Library.Security.CurrentUser.GetBoPhanPhanQuyenList(ERP_Library.Security.CurrentUser.Info.UserID);
        int userID = CurrentUser.Info.UserID;
        private void LoadControls()
        {
         
            _boPhanList = BoPhanList.GetBoPhanListAll(userID);
          
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            //chuong trinh
            cmbu_ChuongTrinh.Value = 0;
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;


            _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.GetChiTietGiayXacNhanTongHopListByUserIDAndMaChiTietGiayXacNhan(ERP_Library.Security.CurrentUser.Info.UserID, _maChiTietGiayXacNhan_Update);
            ChiTietGiayXacNhanTongHop itemAdd = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop(0, "Không Có Giấy Xác Nhận");
            _chiTietGiayXacNhanList.Insert(0, itemAdd);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;
       
            _nhanVienList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
            bindingSource1_NhanVien.DataSource = _nhanVienList;
            _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.NewThuLaoChuongTrinhList();
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;

           // _chiThuLaoList = ChiThuLaoList.GetChiThuLaoListByUser(ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            //ChiThuLao itemChiTL = ChiThuLao.NewChiThuLao("Không Có Chứng Từ");
            //_chiThuLaoList.Insert(0, itemChiTL);
            //this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;
        }
        public frmThuLaoChuongTrinhChuaChuyenKhoan()
        {
            InitializeComponent();
            this.bindingSource1_BoPhan.DataSource = typeof(BoPhanList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ChiTietGiayXacNhanList);
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = typeof(ThuLaoChuongTrinhList);
            this.bindingSource1_ChungTu.DataSource = typeof(ChiThuLaoList);
            bindingSource1_NhanVien.DataSource = typeof(ThongTinNhanVienTongHopList);
            LoadControls();         
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            
            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);

        }

        public frmThuLaoChuongTrinhChuaChuyenKhoan(ThuLaoChuongTrinhList list)
        {
            InitializeComponent();
            KhoiTao(list);
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));            
            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
        }
        private void frmThuLaoChuongTrinh_Load(object sender, EventArgs e)
        {
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, Infragistics.Win.UltraWinGrid.UltraGridState.AddRow, 0, 0, 0));
            //LoadControls();
            cmbu_ChuongTrinh.Enabled = false;
        }

        public void KhoiTao(ThuLaoChuongTrinhList _list)
        {
            _maChiTietGiayXacNhan_Update = _list[0].MaChiTietGiayXacNhan;
            LoadControls();
           
            cbKyTinhLuong.Value = _list[0].MaKyTinhLuong;
            cmbu_ChuongTrinh.Value = _list[0].MaChuongTrinh;
            if (_list[0].MaChiTietGiayXacNhan != 0)
            {
                maChiTietGiayXacNhan = _list[0].MaChiTietGiayXacNhan;
                cbChiTietGiayXacNhan.Text = _list[0].TenGiayXacNhan;
            }
            cmbu_ChuongTrinh.Text = _list[0].TenChuongTrinh;
            maChuongTrinh = _list[0].MaChuongTrinh;

            _thuLaoChuongTrinhList = _list;
            bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
            this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cmbu_Bophan.Value != null)
            //    {
            //        maBoPhan = (int)cmbu_Bophan.Value;
            //    }
            //    if (maGiayXacNhan != 0)
            //    {
            //        _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(maBoPhan, checkBox_NghiHuu.Checked);
            //    }
            //    else
            //    {
            //        _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByDatabase(maBoPhan, checkBox_NghiHuu.Checked);
            //    }
            //     this.bindingSource1_NhanVien.DataSource = _nhanVienList;
              
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }

        private void chkAlldanhsach_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlldanhsach.Checked == true)
            {
                for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                {
                    if (!ultraGrid1.Rows[i].Hidden == true && ultraGrid1.Rows[i].IsFilteredOut==false)
                    {
                        ultraGrid1.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                {
                    ultraGrid1.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }
               
        private void ComBoChangedValue()
        {
            //decimal _soTienTemp = 0;
            //if (txt_MaPhieuChi.Text != "")
            //{
            //    _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(maBoPhan, maChuongTrinh, maKyTinhluong, txt_MaPhieuChi.Text);
            //    this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
            //}
            lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();
            //for (int i = 0; i < _thuLaoChuongTrinhList.Count; i++)
            //{
            //    _soTienTemp += _thuLaoChuongTrinhList[i].SoTien;
            //}
            //SoTien = _soTienTemp;
            //if (_soTienTemp != 0)
            //{
            //    tbSoTien.Text = SoTien.ToString();
            //}
        }
           
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
                try
           {
               if (maKyTinhLuongMoi==0)
               {
                   MessageBox.Show("Chọn Kỳ Tính Lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return;
               }
              KyTinhLuong ktl=KyTinhLuong.GetKyTinhLuong(maKyTinhLuongMoi);
              if (ktl.KhoaSoKy2 == true)
              {
                  MessageBox.Show("Kỳ Tính Lương Mới Đã Khóa Sổ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  return;
              }
              else
              {
                  DateTime ngayLap=Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                  foreach (ThuLaoChuongTrinh tl in _thuLaoChuongTrinhList)
                  {
                      ThuLaoChuongTrinh.InsertThuLaoChuaChuyenKhoan(maKyTinhLuongMoi,ngayLap, tl);                     
                  }
                  
                  MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
           }
           catch (Exception ex)
           {
               throw ex;               
           }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            ComBoChangedValue();
        }

       
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
           // KhoiTao(maKyTinhluong,maChuongTrinh,maGiayXacNhan);           
        }          

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if (!grdu_QuocGia.Rows[i].Hidden == true)
                    {
                        grdu_QuocGia.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    grdu_QuocGia.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void grdu_QuocGia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
               
                // this.ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            }
            //else if (e.KeyCode == (Keys.C && Keys.Control))
            //{
            //    this.grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            //}
            //if (e.KeyCode == (Keys.V && Keys.Control))
            //{
            //    this.grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Paste);
            //}
        }

        private void grdu_QuocGia_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            // Turn on all of the Cut, Copy, and Paste functionality. 
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;

            // In order to cut or copy, the user needs to select cells or rows. 
            // So set CellClickAction so that clicking on a cell selects that cell
            // instead of going into edit mode.
            e.Layout.Override.CellClickAction = CellClickAction.CellSelect;
            foreach (UltraGridColumn col in this.grdu_QuocGia.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;

            }
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Width = 60;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Width = 80;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 150;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 4;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 120;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 5;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 100;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Header.Caption = "Ngoài Định Mức";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Header.VisiblePosition = 6;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Width = 40;

        }

        private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ultraGrid1.ActiveRow != null)
            {
                
                if (e.KeyCode == Keys.Space)
                {
                    if (ultraGrid1.ActiveRow.Cells["Check"].Value.ToString() !="")
                    {
                        if ((bool)ultraGrid1.ActiveRow.Cells["Check"].Value == true)
                            ultraGrid1.ActiveRow.Cells["Check"].Value = false;
                        else
                            ultraGrid1.ActiveRow.Cells["Check"].Value = true;
                    }
                }
            }
        }

        private void grdu_QuocGia_KeyDown(object sender, KeyEventArgs e)
        {
            //if (grdu_QuocGia.ActiveRow != null)
            //{
            //    if (e.KeyCode == Keys.Space)
            //    {
            //        if (grdu_QuocGia.ActiveRow.Cells["Check"].Value.ToString() != "")
            //        {
            //            if ((bool)grdu_QuocGia.ActiveRow.Cells["Check"].Value == true)
            //                grdu_QuocGia.ActiveRow.Cells["Check"].Value = false;
            //            else
            //                grdu_QuocGia.ActiveRow.Cells["Check"].Value = true;
            //        }
            //    }
            //}
        }

        private void ultraGrid1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {               
            }
        }      
       
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            frmBaoCaoThuLaoChiTiet f = new frmBaoCaoThuLaoChiTiet();
            f.Show();
        }

        private void dateTimePicker_NgayLap_Leave(object sender, EventArgs e)
        {
           
            foreach (ThuLaoChuongTrinh tl in _thuLaoChuongTrinhList)
            {
                tl.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
            }
        }

        private void cmbu_ChucVu_KeyDown(object sender, KeyEventArgs e)
        {
            FilterCombo _filter = new FilterCombo(cmbu_ChuongTrinh,"TenChuongTrinh");
        }

        private void grdu_QuocGia_AfterCellUpdate(object sender, CellEventArgs e)
        {
            //MessageBox.Show("Kỳ Này Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //return;
        }
       
        private void TbTongTien_ValueChanged(object sender, EventArgs e)
        {
            TbTongTien.Value = _tienChiTietGiayXacNhan;
        }       

        private bool iskeyok = false;//xử lý key cho cột string
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_QuocGia.ActiveCell != null && !grdu_QuocGia.ActiveCell.IsInEditMode && grdu_QuocGia.ActiveCell.Column.Key != "TenNhanVien")
            {
                if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                {
                    grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    grdu_QuocGia.ActiveCell.SelectAll();
                    iskeyok = true;
                }
                if (e.KeyCode == Keys.Space && grdu_QuocGia.ActiveCell.Column.DataType == typeof(bool))
                {
                    grdu_QuocGia.ActiveCell.Value = !Convert.ToBoolean(grdu_QuocGia.ActiveCell.Value);
                }
            }
        }

        private void grdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (iskeyok && grdu_QuocGia.ActiveCell.Row.IsDataRow)
            {
                if (grdu_QuocGia.ActiveCell.Column.DataType == typeof(decimal))
                    try
                    {
                        grdu_QuocGia.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                    }
                    catch
                    { }
                else
                    grdu_QuocGia.ActiveCell.Value = e.KeyChar.ToString();
                grdu_QuocGia.ActiveCell.SelStart = grdu_QuocGia.ActiveCell.Text.Length;
                e.Handled = true;
                iskeyok = false;
            }
        }
        //xử lý copy 1 cell cho nhiều cell
        private bool iscopyok = false;
        private object copyvalue;
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
                    if (iscopyok && grdu_QuocGia.Selected != null && grdu_QuocGia.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_QuocGia.Selected.Cells)
                        {
                            try
                            {
                                item.Value = copyvalue;
                                item.Row.Update();
                            }
                            catch { }
                        }
                    }
                    iscopyok = false;
                }
        }

        private void cbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null)
            {
                maKyTinhluong = (int)cbKyTinhLuong.Value;
            }   
        }

        private void cbKyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbKyTinhLuong, "TenKy");
            foreach (UltraGridColumn col in this.cbKyTinhLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Width = cbKyTinhLuong.Width;
        }

        private void chbTinhDangPhi_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTinhDangPhi.Checked == true)
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if (!grdu_QuocGia.Rows[i].Hidden == true)
                    {
                        grdu_QuocGia.Rows[i].Cells["TinhDangPhi"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    grdu_QuocGia.Rows[i].Cells["TinhDangPhi"].Value = (object)false;
                }
            }
        }

        private void cbNhanVienTuGiayXacNhan_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNhanVienTuGiayXacNhan.Checked == true)
            {
                _nhanVienList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
                chiTietGXN.ChiTietGiayXacNhan_NhanVienList = ChiTietGiayXacNhan_NhanVienList.GetChiTietGiayXacNhan_NhanVienList(maChiTietGiayXacNhan);
                if (cbNhanVienTuGiayXacNhan.Checked == true)
                {
                    for (int i = 0; i < chiTietGXN.ChiTietGiayXacNhan_NhanVienList.Count; i++)
                    {
                        ThongTinNhanVienTongHop item = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(chiTietGXN.ChiTietGiayXacNhan_NhanVienList[i].MaNhanVien, maBoPhanDen);
                        item.SoTien = chiTietGXN.ChiTietGiayXacNhan_NhanVienList[i].SoTien;
                        _nhanVienList.Add(item);
                    }
                    this.bindingSource1_NhanVien.DataSource = _nhanVienList;
                }
            }
            else
            {
                _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong(maBoPhan, checkBox_NghiHuu.Checked);
                this.bindingSource1_NhanVien.DataSource = _nhanVienList;
            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void chbChuyenKhoan_CheckedChanged(object sender, EventArgs e)
        {
            //if (chbChuyenKhoan.Checked == true)
            //{
            //    for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
            //    {
            //        if (!grdu_QuocGia.Rows[i].Hidden == true)
            //        {
            //            grdu_QuocGia.Rows[i].Cells["ThanhToan"].Value = (object)true;
            //        }
            //    }

            //}
            //else
            //{
            //    for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
            //    {
            //        grdu_QuocGia.Rows[i].Cells["ThanhToan"].Value = (object)false;
            //    }
            //}
        }

        private void ultraComboEditor1_ValueChanged(object sender, EventArgs e)
        {
            //if (ultraComboEditor1.Value != null)
            //{
            //    thanhToan = Convert.ToInt32(ultraComboEditor1.Value);
            //}
        }

        private void cbDinhMuc_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDinhMuc.Checked == true)
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if (!grdu_QuocGia.Rows[i].Hidden == true)
                    {
                        grdu_QuocGia.Rows[i].Cells["ThucNhan"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    grdu_QuocGia.Rows[i].Cells["ThucNhan"].Value = (object)false;
                }
            }
        }

        private void cmbu_ChuongTrinh_ValueChanged(object sender, EventArgs e)
        {
            //if (cmbu_ChuongTrinh.Value != null)
            //{
            //    maChuongTrinh = Convert.ToInt32(cmbu_ChuongTrinh.Value);
            //    ChuongTrinh ct = ChuongTrinh.GetChuongTrinh(maChuongTrinh);
            //    maNguon = ct.MaNguon;
            //    tenNguon = ct.TenNguon;
            //}
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Quản Lý";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Chứng Minh";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Header.Caption = "Chức Vụ";
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 2;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 3;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 4;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Header.VisiblePosition = 5;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 6;

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Width = 40;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 100;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Width = 100;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 150;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Width = 100;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 100;

            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucVu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_ChuongTrinh, "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = cmbu_ChuongTrinh.Width;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã QL";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;
        }

        private void cbChiTietGiayXacNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChiTietGiayXacNhan, "TenGiayXacNhan");
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        private void ultraCombo1_ValueChanged(object sender, EventArgs e)
        {
            if (ultraCombo1.Value != null)
            {
                maKyTinhLuongMoi = Convert.ToInt32(ultraCombo1.Value);
            }
        }

    }
}
