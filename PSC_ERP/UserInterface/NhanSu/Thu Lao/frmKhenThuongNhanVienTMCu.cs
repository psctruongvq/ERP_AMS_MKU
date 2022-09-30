using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using System.Collections;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;

namespace PSC_ERP
{
    public partial class frmKhenThuongNhanVienTMCu : Form
    {
        BoPhanList _boPhanList;
        LoaiPhuCapList _loaiPhuCapList;
        KyTinhLuongList _kyTinhLuongList;
        ThongTinNhanVienTongHopList _nhanVienList;
        PhuCapNhanVienList _phuCapNhanVienList;        
        static int maBoPhan = 0;
        static int maKyTinhluong = 0;
        static int maLoaiBoPhan = 0;
        private bool khoaSo = false;
        public int loaiKhenThuong = 0;
        public frmKhenThuongNhanVienTMCu()
        {
            InitializeComponent();
            this.bindingSource1_BoPhan.DataSource = typeof(BoPhanList);                        
            LoạiKhenThuongList_BindingSouce.DataSource = typeof( LoaiPhuCapList);            
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);            
            BangLuong_PhuCapList_BindingSouce.DataSource = typeof(PhuCapNhanVienList);            
            bindingSource1_NhanVien.DataSource = typeof(ThongTinNhanVienTongHopList);
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));            
            grdu_QuocGia.AfterCellUpdate +=new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            KhoiTao();
        }
        public frmKhenThuongNhanVienTMCu(int _maKyTinhLuong, int _maLoaiPhuCap, string _soQuyetDinh, string _maPhieuChi)
        {
            InitializeComponent();
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));            
            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            KhoiTao();
            cbKyTinhLuong.Value = _maKyTinhLuong;
            cbLoaiKhenThuong.Value = _maLoaiPhuCap;
            txt_SoQuyetDinh.Text = _soQuyetDinh;
            txt_MaPhieuChi.Text = _maPhieuChi;
            
            _phuCapNhanVienList.Clear();
            _phuCapNhanVienList = PhuCapNhanVienList.GetNhapPhuCapListByNgay(_maKyTinhLuong,_maLoaiPhuCap,_soQuyetDinh,_maPhieuChi,false);

            BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
            maKyTinhluong = _maKyTinhLuong;
            maLoaiBoPhan = _maLoaiPhuCap;
            khoaSo = KyTinhLuong.GetKyTinhLuong(maKyTinhluong).KhoaSoKy2;
            if (_phuCapNhanVienList.Count != 0)
            {
                txt_MaPhieuChi.Text = _phuCapNhanVienList[0].MaPhieuChi;
            }
            else
            {
                txt_MaPhieuChi.Text = ""; 
            }
            this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();


        }
        private void frmThuLaoChuongTrinh_Load(object sender, EventArgs e)
        {
            //grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, Infragistics.Win.UltraWinGrid.UltraGridState.AddRow, 0, 0, 0));
        }

        public void KhoiTao()
        {           
            _boPhanList = BoPhanList.GetBoPhanListByAll();
            BoPhan _boPhanAdd = BoPhan.NewBoPhan(0, "Tất Cả");
            _boPhanList.Insert(0, _boPhanAdd);
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            //chuong trinh
            _loaiPhuCapList = LoaiPhuCapList.GetLoaiPhuCapListByThuong();
            //ChuongTrinh _chuongTrinhadd = ChuongTrinh.NewChuongTrinh("Thêm Dòng Mói");
            //_chuongTrinhList.Insert(0, _chuongTrinhadd);
            LoạiKhenThuongList_BindingSouce.DataSource = _loaiPhuCapList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;

            _phuCapNhanVienList = PhuCapNhanVienList.NewPhuCapNhanVienList();
            BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
            
            maBoPhan = 0;
            maLoaiBoPhan = 0;
            maKyTinhluong = 0;
            _nhanVienList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
            bindingSource1_NhanVien.DataSource = _nhanVienList;
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbu_Bophan.ActiveRow!= null)
                {
                    maBoPhan = (int)cmbu_Bophan.ActiveRow.Cells["MaBoPhan"].Value;
                }
                //_nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(maBoPhan, maKyTinhluong, maChuongTrinh, checkBox_NghiHuu.Checked);
                _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(maBoPhan, checkBox_NghiHuu.Checked);
                this.bindingSource1_NhanVien.DataSource = _nhanVienList;
              
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void chkAlldanhsach_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlldanhsach.Checked == true)
            {
                for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                {
                    if (!ultraGrid1.Rows[i].Hidden == true)
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (maLoaiBoPhan != 0 && maKyTinhluong!=0 && txt_SoQuyetDinh.Text!="")
            {
                DialogResult _DialogResult = MessageBox.Show("Bạn Có Đồng Ý Đứa Nhân Viên Qua", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (_DialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                    {
                        if ((bool)ultraGrid1.Rows[i].Cells["Check"].Value == true)
                        {

                            PhuCapNhanVien phuCapNhanVien = PhuCapNhanVien.NewPhuCapNhanVien();                           
                            phuCapNhanVien.MaKyTinhLuong = maKyTinhluong;
                            if(cbLoaiKhenThuong.ActiveRow!=null)
                            phuCapNhanVien.MaLoaiPhuCap = (int)cbLoaiKhenThuong.ActiveRow.Cells["MaLoaiPhuCap"].Value;
                            phuCapNhanVien.TenPhuCap =   "";
                            phuCapNhanVien.SoQuyetDinh = txt_SoQuyetDinh.Text;
                            phuCapNhanVien.MaNhanVien = (long)ultraGrid1.Rows[i].Cells["MaNhanVien"].Value;                            
                            phuCapNhanVien.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                            phuCapNhanVien.TinhThueTNCN = checkBox_TinhThue.Checked;
                            phuCapNhanVien.TenNhanVien = (string)ultraGrid1.Rows[i].Cells["TenNhanVien"].Value;
                            phuCapNhanVien.MaPhieuChi = txt_MaPhieuChi.Text;
                            phuCapNhanVien.ThanhToan = false;
                            phuCapNhanVien.MaBoPhan = NhanVien.GetNhanVien(phuCapNhanVien.MaNhanVien).MaBoPhan;
                            phuCapNhanVien.TenPhuCap = cbLoaiKhenThuong.Text;
                            phuCapNhanVien.DienGiai = cbLoaiKhenThuong.Text;
                            _phuCapNhanVienList.Add(phuCapNhanVien);

                        }
                    }
                    this.BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
                    this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();

                    for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                    {
                        if ((bool)ultraGrid1.Rows[i].Cells["Check"].Value == true)
                        {
                            ultraGrid1.Rows[i].Cells["Check"].Value = false;
                            ultraGrid1.Rows[i].Hidden = true;
                        }
                    }
                    this.bindingSource1_NhanVien.DataSource = _nhanVienList;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (txt_SoQuyetDinh.Text == "")
                {
                    MessageBox.Show("Vui Lòng Nhập Số Quyết Định", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkBox_TinhThue.Focus();
                    return;
                }
                else if (maLoaiBoPhan == 0)
                {
                    MessageBox.Show("Vui Lòng Loại Khen Thưởng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaiKhenThuong.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Vui Lòng Chọn Kỳ Tính Lương ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbKyTinhLuong.Focus();
                    return;
                }
            }
        }

       
        private void ComBoChangedValue()
        {
            decimal _soTienTemp = 0;
         
        }
        
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            
           try
           {
               if (khoaSo==true)
               {
                   MessageBox.Show("Kỳ Này Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   return;
               }
               else
               {
                   if (maKyTinhluong == 0)
                   {
                       MessageBox.Show("Vui Lòng Chọn Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       cbKyTinhLuong.Focus();
                       return;
                   }

                   else if (maLoaiBoPhan == 0)
                   {
                       MessageBox.Show("Vui Lòng Chọn Loại Khen Thưởng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       cbKyTinhLuong.Focus();
                       return;
                   }
                   else if (txt_SoQuyetDinh.Text == "")
                   {
                       MessageBox.Show("Vui Lòng Nhập Quyết Định", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       txt_SoQuyetDinh.Focus();
                       return;
                   }
                   else if (txt_MaPhieuChi.Text == "")
                   {
                       MessageBox.Show("Vui Lòng Nhập Mã Phiếu Chi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       txt_SoQuyetDinh.Focus();
                       return;
                   }
                   foreach (PhuCapNhanVien pc in _phuCapNhanVienList)
                   {
                       pc.MaKyTinhLuong = maKyTinhluong;
                       pc.MaLoaiPhuCap = loaiKhenThuong;
                       pc.MaPhieuChi = txt_MaPhieuChi.Text;
                       pc.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                       pc.SoQuyetDinh = txt_SoQuyetDinh.Text;
                       pc.ThanhToan = false;
                       pc.TinhThueTNCN = checkBox_TinhThue.Checked;
                       pc.TenPhuCap = cbLoaiKhenThuong.Text;
                   }
                   _phuCapNhanVienList.ApplyEdit();
                   BangLuong_PhuCapList_BindingSouce.EndEdit();
                   _phuCapNhanVienList.Save();
                   MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
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
            KhoiTao();           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (khoaSo == true)
            {
                MessageBox.Show("Kỳ Này Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if ((bool)grdu_QuocGia.Rows[i].Cells["Check"].Value == true)
                    {
                        grdu_QuocGia.Rows[i].Selected = true;                       

                    }

                }
                grdu_QuocGia.DeleteSelectedRows();
                _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(maBoPhan, false);
                this.bindingSource1_NhanVien.DataSource = _nhanVienList;
                this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();
            }
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
            if ( e.KeyCode == Keys.Left)
            {
                button2_Click_1(null, null);
                // this.ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                this.grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                this.grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Paste);
                
            }
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

   
        private void ultraGrid1_KeyUp(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Right)
            {
                btnthem_Click(null, null);
            }
        }

      
      
        private void cmbu_ChucVu_Leave(object sender, EventArgs e)
        {
            if (cbLoaiKhenThuong.Value != null)
            {
                maLoaiBoPhan = (int)cbLoaiKhenThuong.Value;
                foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
                {
                   tl.MaLoaiPhuCap = maLoaiBoPhan;
                }
            }    
        }

        private void cbKyTinhLuong_Leave(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null)
            {
                maKyTinhluong = (int)cbKyTinhLuong.Value;
                khoaSo = KyTinhLuong.GetKyTinhLuong(maKyTinhluong).KhoaSoKy2;
                foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
                {
                    tl.MaKyTinhLuong = maKyTinhluong;
                }
            }   
        }

        private void txt_MaPhieuChi_Leave(object sender, EventArgs e)
        {
            //if (txt_MaPhieuChi.Text != "")
            //{
            //    foreach (ThuLaoChuongTrinh tl in _phuCapNhanVienList)
            //    {
            //        tl.MaPhieuChi = txt_MaPhieuChi.Text;
            //    }
            //}
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            //UserInterface.NhanSu.Thu_Lao.frmDanhSachKhenThuong a = new PSC_ERP.UserInterface.NhanSu.Thu_Lao.frmDanhSachKhenThuong();
            //a.Show();
        }

        private void dateTimePicker_NgayLap_Leave(object sender, EventArgs e)
        {
           
            foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
            {
                tl.NgayLap= Convert.ToDateTime(dateTimePicker_NgayLap.Value);
            }
        }

        private void txt_SoQuyetDinh_TextChanged(object sender, EventArgs e)
        {
            foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
            {
                tl.SoQuyetDinh = txt_SoQuyetDinh.Text;
            }
        }

        private void checkBox_TinhThue_TextChanged(object sender, EventArgs e)
        {
            foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
            {
                tl.TinhThueTNCN = checkBox_TinhThue.Checked;
            }
        }

        private void grdu_QuocGia_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "PhuCap")
            {
                e.Cell.Row.Cells["SoTien"].Value = e.Cell.Value;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
            {
                tl.MaPhieuChi = txt_MaPhieuChi.Text;
            }
        }

        private void grdu_QuocGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_QuocGia.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (grdu_QuocGia.ActiveRow.Cells["Check"].Value.ToString() != "")
                    {
                        if ((bool)grdu_QuocGia.ActiveRow.Cells["Check"].Value == true)
                            grdu_QuocGia.ActiveRow.Cells["Check"].Value = false;
                        else
                            grdu_QuocGia.ActiveRow.Cells["Check"].Value = true;
                    }
                }
            }

            if ((e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9) && grdu_QuocGia.ActiveCell != null && grdu_QuocGia.ActiveCell.Column.DataType == typeof(decimal))
            {
                grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
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

        private void cmbu_ChucVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbLoaiKhenThuong, "TenLoaiPhuCap");
        }

        private void cbKyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbKyTinhLuong, "TenKy");
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

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
        }

        private void cbLoaiChucVu_ValueChanged(object sender, EventArgs e)
        {
            if (cbLoaiKhenThuong.ActiveRow!= null)

                loaiKhenThuong = Convert.ToInt32(cbLoaiKhenThuong.ActiveRow.Cells["MaLoaiPhuCap"].Value);
        }


    }
}
