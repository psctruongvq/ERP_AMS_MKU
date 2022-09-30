using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frm02ATBH : Form
    {
        int maKyTinhBaoHiem = 0;
        DateTime _ngayHienHanh=DateTime.Today.Date;
        BHXH02AList _bhxh02aList,_bhxh02aListTam;
        BHXH02A _bhxh02a;
        KyTinhBaoHiemList _kyTinhBaoHiemList;
        public frm02ATBH()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _bhxh02aListTam = BHXH02AList.BHXH02AListGetDanhSachLapByTuNgayDenNgay(dateTuNgay.DateTime.Date,_ngayHienHanh);
            this.bindingSource1_02ATam.DataSource = _bhxh02aListTam;
            this.lbSoDS.Text ="Tổng Số: "+ _bhxh02aListTam.Count.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < gridBHXH02ATam.Rows.Count; i++)
                {
                    gridBHXH02ATam.Rows[i].Cells["Check"].Value = (object)true;
                }
            }
            else
            {
                for (int i = 0; i < gridBHXH02ATam.Rows.Count; i++)
                {
                    gridBHXH02ATam.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            long maNhanVien = 0;
            DateTime _thamGiaTuNgay = DateTime.Now.Date;
            string _ghiChu = string.Empty;
            try
            {
                _bhxh02aList = BHXH02AList.NewBHXH02AList();
                DialogResult result = MessageBox.Show("Bạn Có Muốn Tạo Dữ Liệu Cho Các Nhân Viên Đã Chọn", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < gridBHXH02ATam.Rows.Count; i++)
                    {
                        if ((bool)gridBHXH02ATam.DisplayLayout.Rows[i].Cells["Check"].Value == true)
                        {
                            maNhanVien = (long)gridBHXH02ATam.DisplayLayout.Rows[i].Cells["MaNhanVien"].Value;
                            _thamGiaTuNgay = (DateTime)gridBHXH02ATam.DisplayLayout.Rows[i].Cells["NgaySinh"].Value;//dùng tạm "NgaySinh".
                            _ghiChu = (string)gridBHXH02ATam.DisplayLayout.Rows[i].Cells["GhiChu"].Value;
                            _bhxh02a = BHXH02A.NewBHXH02A(maNhanVien,maKyTinhBaoHiem,_thamGiaTuNgay,_ngayHienHanh,_ghiChu);
                            _bhxh02aList.Add(_bhxh02a);
                        }
                    }
                    this.bindingSource1_02ATBH.DataSource = _bhxh02aList;
                }
            }
            catch (Exception ex) { throw ex; }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                _bhxh02aList.ApplyEdit();
                _bhxh02aList.Save();
                MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex) { throw ex; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _bhxh02aList = BHXH02AList.GetBHXH02AList(maKyTinhBaoHiem);
            this.bindingSource1_02ATBH.DataSource = _bhxh02aList;
            this.lbSo02A.Text = "Tổng Số: "+_bhxh02aList.Count.ToString();

        }

        private void cbKyTinhBaoHiem_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhBaoHiem.Value != null)
            {
                maKyTinhBaoHiem = Convert.ToInt32( cbKyTinhBaoHiem.Value);
                _ngayHienHanh = KyTinhBaoHiem.GetKyTinhBaoHiem(maKyTinhBaoHiem).ThoiGianHienHanh;
            }
        }

        private void frm02ATBH_Load(object sender, EventArgs e)
        {
            _kyTinhBaoHiemList = KyTinhBaoHiemList.GetKyTinhBaoHiemList();
            this.bindingSource1_KyTinhBaoHiem.DataSource = _kyTinhBaoHiemList;
        }

        private void gridBHXH02A_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            gridBHXH02A.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption="Tên Nhân Viên";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["SoSoBHXH"].Header.Caption = "Số Sổ BHXH";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["SoTheBHYT"].Header.Caption = "Số Sổ BHYT";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["NgaySinh"].Header.Caption = "Ngày Sinh";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["GioiTinh"].Header.Caption = "Giới Tính";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "HSL";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["HeSoPhuCap"].Header.Caption = "HSPC";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["HeSoVuotKhung"].Header.Caption = "HSVK";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["HeSoThamNien"].Header.Caption = "HSTN";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["HeSoKhuVuc"].Header.Caption = "HSKV";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["DongBHTN"].Header.Caption = "BHTN";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["ThamGiaTu"].Header.Caption = "Tham Gia Từ";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["ThamGiaDen"].Header.Caption = "Tham Gia Đến";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            gridBHXH02A.DisplayLayout.Bands[0].Columns["MaMauBH02A"].Hidden=true;
            gridBHXH02A.DisplayLayout.Bands[0].Columns["KyTinhBaoHiem"].Hidden = true;
            gridBHXH02A.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            gridBHXH02A.DisplayLayout.Bands[0].Columns["MaTheBHYT"].Hidden = true;
            gridBHXH02A.DisplayLayout.Bands[0].Columns["MaSoBaoHiemXH"].Hidden = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _bhxh02aList = BHXH02AList.GetBHXH02AList(maKyTinhBaoHiem);

        }
    }
}