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
    public partial class frm03ATBH : Form
    {
        int soLuongConLai = 0;
        TTNhanVienRutGonList _nhanVienList;
        BHXH03A _bHXH03A;
        BHXH03AList _bHXH03AList, _bHXH03AListTam, _bHXH03AListTam1;
        int maKyTinhBaoHiem = 0;
        KyTinhBaoHiemList _kyTinhBaoHiemList;
        DateTime _ngayHienHanh = DateTime.Today.Date;
        public frm03ATBH()
        {
            InitializeComponent();
           // comboboxNhanVien1.LoadData();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _bHXH03AListTam = BHXH03AList.GetBHXH03AList_LapDanhSach(dateTuNgay.DateTime.Date,_ngayHienHanh);
            this.bindingSource1_03ATam.DataSource = _bHXH03AListTam;
            this.lbSoLuong3ATam.Text = "Tổng Số: "+_bHXH03AListTam.Count.ToString();
            soLuongConLai = 0;
        }

        private void frm03ATBH_Load(object sender, EventArgs e)
        {
            _kyTinhBaoHiemList = KyTinhBaoHiemList.GetKyTinhBaoHiemList();
            this.bindingSource1_KyTinhBaoHiem.DataSource = _kyTinhBaoHiemList;
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListAll();
            this.bindingSource1_NhanVien.DataSource = _nhanVienList;
            _bHXH03AList = BHXH03AList.NewBHXH03AList();
            
        }

        private void cbKyTinhBaoHiem_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhBaoHiem.Value != null)
            {
                maKyTinhBaoHiem = Convert.ToInt32(cbKyTinhBaoHiem.Value);
                _ngayHienHanh = KyTinhBaoHiem.GetKyTinhBaoHiem(maKyTinhBaoHiem).ThoiGianHienHanh;
            }
        }

        private void gridBHXH02ATam_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            //e.Layout.Override.AllowAddNew = AllowAddNew.No;
            gridBHXH03ATam.DisplayLayout.Bands[0].Columns["MaNhanVien"].EditorComponent =ultraCombo1;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _bHXH03AListTam1 = BHXH03AList.NewBHXH03AList();
            long maNhanVien = 0;
            int maQuyetDinhNangLuong = 0;
            string ghiChu = "";
            DateTime _thamGiaTuNgay = DateTime.Now.Date;
            try
            {
                
                DialogResult result = MessageBox.Show("Bạn Có Muốn Tạo Dữ Liệu Cho Các Nhân Viên Đã Chọn", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < gridBHXH03ATam.Rows.Count; i++)
                    {
                        if ((bool)gridBHXH03ATam.DisplayLayout.Rows[i].Cells["Check"].Value == true)
                        {
                            maNhanVien = (long)gridBHXH03ATam.DisplayLayout.Rows[i].Cells["MaNhanVien"].Value;
                            maQuyetDinhNangLuong = (int)gridBHXH03ATam.DisplayLayout.Rows[i].Cells["MaTheBHYT"].Value;
                            _thamGiaTuNgay = (DateTime)gridBHXH03ATam.DisplayLayout.Rows[i].Cells["TuNgay"].Value;//dùng tạm .
                            ghiChu = (string)gridBHXH03ATam.DisplayLayout.Rows[i].Cells["GhiChu"].Value; 
                            _bHXH03A = BHXH03A.NewBHXH03A(maNhanVien,maKyTinhBaoHiem,maQuyetDinhNangLuong,_thamGiaTuNgay,_ngayHienHanh,ghiChu);
                            _bHXH03AList.Add(_bHXH03A);
                           
                        }
                    }
                    
                    for (int i = 0; i < gridBHXH03ATam.Rows.Count; i++)
                    {
                        if ((bool)gridBHXH03ATam.Rows[i].Cells["Check"].Value == true)
                        {
                            gridBHXH03ATam.Rows[i].Cells["Check"].Value = false;                            
                            gridBHXH03ATam.Rows[i].Hidden = true;
                            soLuongConLai++;
                            
                        }
                    }
                    lbSoLuong3ATam.Text = "Tổng Số: "+Convert.ToString(_bHXH03AListTam.Count-soLuongConLai);
                    this.bindingSource1_03ATBH.DataSource = _bHXH03AList;
                    this.lbTongSo03A.Text = "Tổng Số: "+_bHXH03AList.Count.ToString();
                    
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void ultraCombo1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //màu và font chữ
            foreach (UltraGridColumn col in this.ultraCombo1.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            //màu nền
            ultraCombo1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraCombo1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ultraCombo1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 300;

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _bHXH03AList = BHXH03AList.GetBHXH03AListByMaKyTinhBaoHiem(maKyTinhBaoHiem);
            this.bindingSource1_03ATBH.DataSource = _bHXH03AList;
            this.lbDS03ATBH.Text = "Số Lượng: "+_bHXH03AList.Count.ToString();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < gridBHXH03ATam.Rows.Count; i++)
                {
                    if (gridBHXH03ATam.Rows[i].Hidden == false)
                    {
                        gridBHXH03ATam.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < gridBHXH03ATam.Rows.Count; i++)
                {
                    gridBHXH03ATam.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void bindingSource1_03ATam_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        private void gridBHXH03A_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

     
    }
}