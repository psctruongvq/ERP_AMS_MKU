using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
namespace PSC_ERP
{
    public partial class frmHoSoBaoHiem : Form
    {
        
        NhanVienList _NVBHXHList,_NVBHYTList,_NVBHTNList;
        BoPhanList _boPhanList;
        SoBaoHiemXaHoi _soBHXH;
        SoBaoHiemXaHoiList _soBHXHList;
        TheBaoHiemYTe _theBHYT;
        TheBaoHiemYTeList _theBHYTList;
        NoiDangKyKCBList _KCBList;
        BaoHiemThatNghiepList _baoHiemTNList;
        BaoHiemThatNghiep _baoHiemTN;
        int maBoPhan = 0;
        public frmHoSoBaoHiem()
        {
            InitializeComponent();
        }

        private void frmHoSoBaoHiem_Load(object sender, EventArgs e)
        {
            _KCBList = NoiDangKyKCBList.GetNoiDangKyKCBList();
            this.bindingSource1_NoiDangKyKCB.DataSource = _KCBList;
            _boPhanList = BoPhanList.GetBoPhanList();
            BoPhan _bpNew = BoPhan.NewBoPhan(0, "Tất Cả");
            _boPhanList.Insert(0, _bpNew);
            bindingSource2_BoPhan.DataSource = _boPhanList;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void ultraComboEditor2_ValueChanged(object sender, EventArgs e)
        {
            if (cbBoPhan.Value != null)
            {
                maBoPhan = Convert.ToInt32(cbBoPhan.Value);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            long maNhanVien = 0;
            try
            {
                _soBHXHList = SoBaoHiemXaHoiList.NewSoBaoHiemXaHoiList();
                DialogResult result = MessageBox.Show("Bạn Có Muốn Tạo Sổ BHXH Cho Các Nhân Viên Đã Chọn", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < ulGrid_ChuaSoBHXH.Rows.Count; i++)
                    {
                        if ((bool)ulGrid_ChuaSoBHXH.DisplayLayout.Rows[i].Cells["Check"].Value == true)
                        {
                            maNhanVien = (long)ulGrid_ChuaSoBHXH.DisplayLayout.Rows[i].Cells["MaNhanVien"].Value;
                            _soBHXH = SoBaoHiemXaHoi.NewSoBaoHiemXaHoi(maNhanVien);                            
                            _soBHXHList.Add(_soBHXH);
                        }
                    }
                    bindingSource1_BHXH.DataSource = _soBHXHList;
                }
            }
            catch (Exception ex) { throw ex; }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                for (int i = 0; i < ulGrid_ChuaTheBHYT.Rows.Count; i++)
                {
                    if (!ulGrid_ChuaTheBHYT.Rows[i].Hidden == true)
                    {
                        ulGrid_ChuaTheBHYT.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < ulGrid_ChuaTheBHYT.Rows.Count; i++)
                {
                    ulGrid_ChuaTheBHYT.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < ulGrid_ChuaSoBHXH.Rows.Count; i++)
                {
                    if (!ulGrid_ChuaSoBHXH.Rows[i].Hidden == true)
                    {
                        ulGrid_ChuaSoBHXH.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < ulGrid_ChuaSoBHXH.Rows.Count; i++)
                {
                    ulGrid_ChuaSoBHXH.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _soBHXHList.Count; i++)
                {
                    if (_soBHXHList[i].SoSoBaoHiem.Length < 3 || _soBHXHList[i].SoSoBaoHiem == " ")
                    {
                        MessageBox.Show("Số sổ bảo hiểm chưa đúng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //ultraGrid1.DisplayLayout.Rows[i].Appearance.ForeColor = Color.Red;
                        return;
                    }
                }
                _soBHXHList.ApplyEdit();
                _soBHXHList.Save();
                DSChuaCoSoBHXH();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { throw ex; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _soBHXHList = SoBaoHiemXaHoiList.GetSoBaoHiemXaHoiListByBoPhan(maBoPhan);
            this.bindingSource1_BHXH.DataSource = _soBHXHList;
            this.lbCoSoBHXH.Text = "Tổng Số: "+_soBHXHList.Count.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DSChuaCoSoBHXH();
        }
        private void DSChuaCoSoBHXH()
        {
            _NVBHXHList = NhanVienList.GetNhanVienListByDanhSachChuaCoSoBHXH(maBoPhan);
            bindingSource1_NhanVien_BHXH.DataSource = _NVBHXHList;
            lbTongSo.Text = "Tổng Số: " + _NVBHXHList.Count.ToString();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            DSChuaCoTheBHYT();
            
        }
        private void DSChuaCoTheBHYT()
        {
            _NVBHYTList = NhanVienList.GetNhanVienListByDanhSachChuaCoTheBHYT(maBoPhan);
            bindingSource1_NhanVien_BHYT.DataSource = _NVBHYTList;
            lbTongSoBHYT.Text = "Tổng Số: " + _NVBHYTList.Count.ToString();
        }
        private void cbNoiKCB_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            foreach (UltraGridColumn col in this.cbNoiKCB.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            cbNoiKCB.DisplayLayout.Bands[0].Columns["MaQLBenhVienKCB"].Hidden = false;
            cbNoiKCB.DisplayLayout.Bands[0].Columns["MaQLBenhVienKCB"].Header.Caption = "Mã Bệnh Viện";
            cbNoiKCB.DisplayLayout.Bands[0].Columns["MaQLBenhVienKCB"].Header.VisiblePosition = 0;

            cbNoiKCB.DisplayLayout.Bands[0].Columns["TenBenhVienKCB"].Hidden = false;
            cbNoiKCB.DisplayLayout.Bands[0].Columns["TenBenhVienKCB"].Header.Caption = "Tên Bệnh Viện";
            cbNoiKCB.DisplayLayout.Bands[0].Columns["TenBenhVienKCB"].Header.VisiblePosition = 1;

            cbNoiKCB.DisplayLayout.Bands[0].Columns["MaQLTinhThanhKCB"].Hidden = false;
            cbNoiKCB.DisplayLayout.Bands[0].Columns["MaQLTinhThanhKCB"].Header.Caption = "Mã Tỉnh Thành";
            cbNoiKCB.DisplayLayout.Bands[0].Columns["MaQLTinhThanhKCB"].Header.VisiblePosition = 2;

            cbNoiKCB.DisplayLayout.Bands[0].Columns["TenTinhThanhKCB"].Hidden = false;
            cbNoiKCB.DisplayLayout.Bands[0].Columns["TenTinhThanhKCB"].Header.Caption = "Tên Tỉnh Thành";
            cbNoiKCB.DisplayLayout.Bands[0].Columns["TenTinhThanhKCB"].Header.VisiblePosition = 3;

            this.cbNoiKCB.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cbNoiKCB.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            _theBHYTList = TheBaoHiemYTeList.GetTheBaoHiemYTeListByBoPhan(maBoPhan);
            this.bindingSource1_BHYT.DataSource = _theBHYTList;
            this.lbCoSoBHYT.Text = "Tổng Số: "+_theBHYTList.Count.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            long maNhanVien = 0;
            try
            {              
                _theBHYTList = TheBaoHiemYTeList.NewTheBaoHiemYTeList();
                DialogResult result = MessageBox.Show("Bạn Có Muốn Tạo Sổ BHYT Cho Các Nhân Viên Đã Chọn", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < ulGrid_ChuaTheBHYT.Rows.Count; i++)
                    {
                        if ((bool)ulGrid_ChuaTheBHYT.DisplayLayout.Rows[i].Cells["Check"].Value == true)
                        {
                            maNhanVien = (long)ulGrid_ChuaTheBHYT.DisplayLayout.Rows[i].Cells["MaNhanVien"].Value;
                            _theBHYT = TheBaoHiemYTe.NewTheBaoHiemYTe(maNhanVien);
                            _theBHYTList.Add(_theBHYT);
                                
                        }
                    }
                    bindingSource1_BHYT.DataSource = _theBHYTList;
                }
            }
            catch (Exception ex) { throw ex; }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _theBHYTList.Count; i++)
                {
                    if (_theBHYTList[i].SoTheBHYT.Length < 3 || _theBHYTList[i].SoTheBHYT == " ")
                    {
                        MessageBox.Show("Số thẻ bảo hiểm chưa đúng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultraGrid2.DisplayLayout.Rows[i].Appearance.ForeColor = Color.Red;
                        return;
                    }
                }
                _theBHYTList.ApplyEdit();
                _theBHYTList.Save();
                DSChuaCoTheBHYT();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { throw ex; }
        }

        private void ultraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultraGrid2.DisplayLayout.Bands[0].Columns["MaNoiDangKyKCB"].EditorComponent = cbNoiKCB;
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
        }

        private void ulGrid_ChuaSoBHXH_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Check";
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;

            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;

            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["HeSoLuongBaoHiem"].Hidden = false;
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["HeSoLuongBaoHiem"].Header.Caption = "HSL";
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["HeSoLuongBaoHiem"].Header.VisiblePosition = 3;

            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["HeSoPhuCapChucVu"].Hidden = false;
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["HeSoPhuCapChucVu"].Header.Caption = "HSPC";
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["HeSoPhuCapChucVu"].Header.VisiblePosition = 4;

            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["HeSoVuotKhung"].Hidden = false;
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["HeSoVuotKhung"].Header.Caption = "HSVK";
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["HeSoVuotKhung"].Header.VisiblePosition = 5;

            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Hidden = false;
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Header.Caption = "HSĐH";
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Header.VisiblePosition = 6;

            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["NgayVaoNganh"].Hidden = false;
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["NgayVaoNganh"].Header.Caption = "Ngày Vào Ngành";
            ulGrid_ChuaSoBHXH.DisplayLayout.Bands[0].Columns["NgayVaoNganh"].Header.VisiblePosition = 7;
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
        }

        private void ulGrid_ChuaTheBHYT_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Check";
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;

            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;

            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["HeSoLuongBaoHiem"].Hidden = false;
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["HeSoLuongBaoHiem"].Header.Caption = "HSL";
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["HeSoLuongBaoHiem"].Header.VisiblePosition = 3;

            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["HeSoPhuCapChucVu"].Hidden = false;
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["HeSoPhuCapChucVu"].Header.Caption = "HSPC";
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["HeSoPhuCapChucVu"].Header.VisiblePosition = 4;

            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["HeSoVuotKhung"].Hidden = false;
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["HeSoVuotKhung"].Header.Caption = "HSVK";
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["HeSoVuotKhung"].Header.VisiblePosition = 5;

            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Hidden = false;
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Header.Caption = "HSĐH";
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Header.VisiblePosition = 6;

            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["NgayVaoNganh"].Hidden = false;
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["NgayVaoNganh"].Header.Caption = "Ngày Vào Ngành";
            ulGrid_ChuaTheBHYT.DisplayLayout.Bands[0].Columns["NgayVaoNganh"].Header.VisiblePosition = 7;
        }

        private void btDanhSachBHTN_Click(object sender, EventArgs e)
        {
            DSChuaDongBHTN();
        }
        private void DSChuaDongBHTN()
        {
            _NVBHTNList = NhanVienList.GetNhanVienListByDanhSachChuaDongBHTN(maBoPhan);
            this.bindingSource1_NhanVien_BHTN.DataSource = _NVBHTNList;
            this.lbSoNVChuaDongBHTN.Text = "Tổng Số: " + _NVBHTNList.Count.ToString();
        }
        private void cbBaoHiemTN_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBaoHiemTN.Checked == true)
            {
                for (int i = 0; i <grid_ChuaDongBHTN .Rows.Count; i++)
                {
                    if (!grid_ChuaDongBHTN.Rows[i].Hidden == true)
                    {
                        grid_ChuaDongBHTN.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grid_ChuaDongBHTN.Rows.Count; i++)
                {
                    grid_ChuaDongBHTN.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void btLuuBHTN_Click(object sender, EventArgs e)
        {
            long maNhanVien = 0;
            try
            {              
                _baoHiemTNList=BaoHiemThatNghiepList.NewBaoHiemThatNghiepList();
                DialogResult result = MessageBox.Show("Bạn Có Muốn Tạo Danh Sách Đóng Bảo Hiểm Thất Nghiệp Cho Các Nhân Viên Đã Chọn", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < grid_ChuaDongBHTN.Rows.Count; i++)
                    {
                        if ((bool)grid_ChuaDongBHTN.DisplayLayout.Rows[i].Cells["Check"].Value == true)
                        {
                            maNhanVien = (long)grid_ChuaDongBHTN.DisplayLayout.Rows[i].Cells["MaNhanVien"].Value;
                            _baoHiemTN = BaoHiemThatNghiep.NewBaoHiemThatNghiep(maNhanVien);
                            _baoHiemTNList.Add(_baoHiemTN);
                        }
                    }
                    bindingSource1_BHTN.DataSource = _baoHiemTNList;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _baoHiemTNList = BaoHiemThatNghiepList.GetBaoHiemThatNghiepList(maBoPhan);
            this.bindingSource1_BHTN.DataSource = _baoHiemTNList;
            this.lbDaDongBHTN.Text = "Tổng Số: "+_baoHiemTNList.Count.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try {
                _baoHiemTNList.ApplyEdit();
                _baoHiemTNList.Save();
                DSChuaDongBHTN();
                MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex) { throw ex; }
        }

        private void grid_ChuaDongBHTN_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Check";
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;

            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;

            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["HeSoLuongBaoHiem"].Hidden = false;
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["HeSoLuongBaoHiem"].Header.Caption = "HSL";
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["HeSoLuongBaoHiem"].Header.VisiblePosition = 3;

            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["HeSoPhuCapChucVu"].Hidden = false;
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["HeSoPhuCapChucVu"].Header.Caption = "HSPC";
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["HeSoPhuCapChucVu"].Header.VisiblePosition = 4;

            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["HeSoVuotKhung"].Hidden = false;
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["HeSoVuotKhung"].Header.Caption = "HSVK";
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["HeSoVuotKhung"].Header.VisiblePosition = 5;

            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Hidden = false;
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Header.Caption = "HSĐH";
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Header.VisiblePosition = 6;

            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["NgayVaoNganh"].Hidden = false;
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["NgayVaoNganh"].Header.Caption = "Ngày Vào Ngành";
            grid_ChuaDongBHTN.DisplayLayout.Bands[0].Columns["NgayVaoNganh"].Header.VisiblePosition = 7;
        }
    }
}