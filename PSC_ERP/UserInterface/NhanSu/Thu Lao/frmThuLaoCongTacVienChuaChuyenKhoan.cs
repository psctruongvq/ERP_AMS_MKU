using System;
using System.Data;
using System.Windows.Forms;

using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using System.Data.OleDb;
using Infragistics.Win;
using ERP_Library.Security;

namespace PSC_ERP
{//1/
    public partial class frmThuLaoCongTacVienChuaChuyenKhoan : Form
    {
        ChiThuLaoList _chiThuLaoList;
        BoPhanList _boPhanList;
        ChuongTrinhList _chuongTrinhList;
        KyTinhLuongList _kyTinhLuongList;
        NhanVienNgoaiDaiList _nhanVienList;
        ThuLaoNhanVienNgoaiDaiList _thuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
        GiayXacNhanChuongTrinhList _giayXacNhanChuongTrinhList = GiayXacNhanChuongTrinhList.NewGiayXacNhanChuongTrinhList();
        ChiTietGiayXacNhan chiTietGXN = ChiTietGiayXacNhan.NewChiTietGiayXacNhan();
        decimal _tienChiTietGiayXacNhan = 0;
        int maKyTinhLuongMoi = 0;
        ChiTietGiayXacNhanTongHopList _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.NewChiTietGiayXacNhanTongHopList();

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
        int userID = CurrentUser.Info.UserID;
        private void LoadControls()
        {
            _boPhanList = BoPhanList.GetBoPhanListAll(userID);
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            //chuong trinh
            cmbu_ChuongTrinh.EditValue = 0;
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;

            //_chiTietGiayXacNhanList = ChiTietGiayXacNhanList.GetChiTietGiayXacNhanListByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiTietGiayXacNhan itemAdd = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0, "Không Có Giấy Xác Nhận");
            //_chiTietGiayXacNhanList.Insert(0, itemAdd);
            //this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;

            _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.GetChiTietGiayXacNhanTongHopListByUserIDAndMaChiTietGiayXacNhan(ERP_Library.Security.CurrentUser.Info.UserID, _maChiTietGiayXacNhan_Update);
            ChiTietGiayXacNhanTongHop itemAdd = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop(0, "Không Có Giấy Xác Nhận");
            _chiTietGiayXacNhanList.Insert(0, itemAdd);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;

            _nhanVienList = NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiList();
            bindingSource1_NhanVien.DataSource = _nhanVienList;
            _thuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
        }

        public frmThuLaoCongTacVienChuaChuyenKhoan()
        {
            InitializeComponent();
            dateTimePicker_NgayLap.Value = DateTime.Now.Date;
            this.bindingSource1_BoPhan.DataSource = typeof(BoPhanList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ChiTietGiayXacNhanList);
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = typeof(ThuLaoNhanVienNgoaiDaiList);
            this.bindingSource1_ChungTu.DataSource = typeof(ChiThuLaoList);
            bindingSource1_NhanVien.DataSource = typeof(NhanVienNgoaiDaiList);
            LoadControls();
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
        }

        public frmThuLaoCongTacVienChuaChuyenKhoan(ThuLaoNhanVienNgoaiDaiList list)
        {
            InitializeComponent();
            dateTimePicker_NgayLap.Value = DateTime.Now.Date;
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

        public void KhoiTao(ThuLaoNhanVienNgoaiDaiList _list)
        {
            if (_list.Count != 0)
                _maChiTietGiayXacNhan_Update = _list[0].MaChiTietGiayXacNhan;
            LoadControls();

            if (_list.Count != 0)
            {
                cbKyTinhLuong.Value = _list[0].MaKyTinhLuong;
                cmbu_ChuongTrinh.EditValue = _list[0].MaChuongTrinh;
                if (_list[0].MaChiTietGiayXacNhan != 0)
                {
                    maChiTietGiayXacNhan = _list[0].MaChiTietGiayXacNhan;
                    cbChiTietGiayXacNhan.Text = _list[0].TenGiayXacNhan;
                }
                maChuongTrinh = _list[0].MaChuongTrinh;
                dateTimePicker_NgayLap.Value = _list[0].NgayLap;
                _thuLaoChuongTrinhList = _list;
                bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
                this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();
            }
        }
        private void ComBoChangedValue()
        {
            lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (maKyTinhLuongMoi == 0)
                {
                    MessageBox.Show("Chọn Kỳ Tính Lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                KyTinhLuong ktl = KyTinhLuong.GetKyTinhLuong(maKyTinhLuongMoi);
                if (ktl.KhoaSoKy2 == true)
                {
                    MessageBox.Show("Kỳ Tính Lương Mới Đã Khóa Sổ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    DateTime ngayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                    foreach (ThuLaoNhanVienNgoaiDai tl in _thuLaoChuongTrinhList)
                    {
                        ThuLaoNhanVienNgoaiDai.InsertThuLaoChuaChuyenKhoan(maKyTinhLuongMoi, ngayLap, tl);
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
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Width = 40;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 120;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Width = 70;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 100;


            grdu_QuocGia.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 4;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "MST";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 5;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 100;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 6;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 150;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 7;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 100;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaSoThue"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaNhanVienChuyenTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        }

        private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ultraGrid1.ActiveRow != null)
            {

                if (e.KeyCode == Keys.Space)
                {
                    if (ultraGrid1.ActiveRow.Cells["Check"].Value.ToString() != "")
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
            foreach (ThuLaoNhanVienNgoaiDai tl in _thuLaoChuongTrinhList)
            {
                tl.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
            }
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
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;

            foreach (UltraGridColumn col in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;

                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    //col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "#,###.##";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }
            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Width = 40;

            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 130;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 150;

            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 3;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Width = 100;

            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "Số Tài Khoản";
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 4;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Width = 100;

            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNganHang"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.Caption = "Tên Ngân Hàng";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.VisiblePosition = 5;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNganHang"].Width = 120;

            ultraGrid1.DisplayLayout.Bands[0].Columns["Mst"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["Mst"].Header.Caption = "Mã Số Thuế";
            ultraGrid1.DisplayLayout.Bands[0].Columns["Mst"].Header.VisiblePosition = 6;
            ultraGrid1.DisplayLayout.Bands[0].Columns["Mst"].Width = 100;
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

        private void cmbu_ChuongTrinh_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.EditValue != null)
            {
                maChuongTrinh = Convert.ToInt32(cmbu_ChuongTrinh.EditValue);
                ChuongTrinh ct = ChuongTrinh.GetChuongTrinh(maChuongTrinh);
                tenChuongTrinh = ct.TenChuongTrinh;
                maNguon = ct.MaNguon;
                tenNguon = ct.TenNguon;
            }
        }

        private void tlslbl_ExportMau_Click(object sender, EventArgs e)
        {
            try
            {
                frmExportThuLapImport frm = new frmExportThuLapImport(1);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslbl_ImportMau_Click(object sender, EventArgs e)
        {
            if (maChuongTrinh == 0)
            {
                MessageBox.Show("Vui lòng chọn chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string cnnExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dlg.FileName + ";Extended Properties='Excel 8.0;HDR=NO'";
                    OleDbDataAdapter daExcel = new OleDbDataAdapter("Select * From [CongTacVienExport$A7:H] ", cnnExcel);
                    DataTable tblExcel = new DataTable("Import");
                    daExcel.Fill(tblExcel);

                    daExcel.UpdateCommand = new OleDbCommand("Update [CongTacVienExport$A7:L] Set F8=? Where F3=?", daExcel.SelectCommand.Connection);
                    daExcel.UpdateCommand.Parameters.Add("p1", OleDbType.WChar, 8, "F8");
                    daExcel.UpdateCommand.Parameters.Add("p3", OleDbType.WChar, 20, "F3");

                    //thêm dữ liệu vào object và save lại
                    ThuLaoNhanVienNgoaiDai objNew;
                    bool ok;
                    _thuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();

                    foreach (DataRow row in tblExcel.Rows)
                    {
                        ok = true;
                        if (row.IsNull("F3")) continue;
                        {
                            if (ok)
                            {

                                objNew = ERP_Library.ThuLaoNhanVienNgoaiDai.NewThuLaoNhanVienNgoaiDai();

                                objNew.ThanhToan = true;
                                objNew.MaChuongTrinh = maChuongTrinh;
                                objNew.MaKyTinhLuong = maKyTinhluong;
                                objNew.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                                objNew.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);

                                objNew.TenChuongTrinh = tenChuongTrinh;
                                objNew.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                                objNew.MaGiayXacNhan = maGiayXacNhan;


                                if (row["F3"].ToString() == string.Empty) return;

                                NhanVienNgoaiDai nv = NhanVienNgoaiDai.GetNhanVienNgoaiDaiByCMND(row["F3"].ToString());
                                BoPhan bp = BoPhan.GetBoPhan(nv.MaBoPhan);
                                objNew.MaQLBoPhan = bp.MaBoPhanQL;
                                objNew.MaBoPhan = nv.MaBoPhan;
                                objNew.TenBoPhan = nv.TenBoPhan;
                                objNew.MaNhanVien = nv.MaNhanVien;
                                objNew.TenNhanVien = nv.TenNhanVien;
                                objNew.Cmnd = nv.Cmnd;

                                if (!string.IsNullOrEmpty((row["F4"].ToString())))
                                {
                                    objNew.MaSoThue = row["F4"].ToString();
                                }
                                if (!string.IsNullOrEmpty((row["F2"].ToString())))
                                {
                                    objNew.SoTien = Convert.ToDecimal(row["F2"]);
                                }
                                if (!string.IsNullOrEmpty((row["F5"].ToString())))
                                {
                                    objNew.DienThoai = row["F5"].ToString();
                                }
                                if (!string.IsNullOrEmpty((row["F6"].ToString())))
                                {
                                    objNew.DienGiai = row["F6"].ToString();
                                }
                                if (!string.IsNullOrEmpty((row["F7"].ToString())))
                                {
                                    objNew.DiaChi = row["F7"].ToString();
                                }
                                objNew.MaNhanVienChuyenTien = objNew.MaNhanVien;

                                if (objNew.MaNhanVien != 0)
                                {
                                    _thuLaoChuongTrinhList.Add(objNew);
                                }

                                row["F8"] = "OK";
                            }
                            else
                            {
                                row["F8"] = "Lỗi";
                            }
                        }
                    }

                    daExcel.Update(tblExcel);
                    this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
