using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
namespace PSC_ERP
{
    public partial class frmTuNgayDenNgay : Form
    {
        public static DateTime TuNgay = DateTime.Today.Date;
        public static DateTime DenNgay = DateTime.Today.Date;
        KyTinhLuongList _list;
        int maKy1 = 0;
        int maKy2 = 0;
        public frmTuNgayDenNgay()
        {
            InitializeComponent();
            _list = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _list;
            this.bindingSource1_KyTinhLuong2.DataSource = _list;
            TuNgay = KyTinhLuong.GetKyTinhLuong_Ngay(DateTime.Today.Date).NgayBatDau;
            DenNgay = KyTinhLuong.GetKyTinhLuong_Ngay(DateTime.Today.Date).NgayKetThuc;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if(cbTuKyTinhLuong.Value!=null &&cbDenKyTinhLuong.Value!=null)
            {
                maKy1 = (int)cbTuKyTinhLuong.Value;
                maKy2 = (int)cbDenKyTinhLuong.Value;
                TuNgay=KyTinhLuong.GetKyTinhLuong(maKy1).NgayBatDau;
                DenNgay=KyTinhLuong.GetKyTinhLuong(maKy2).NgayKetThuc;
            }
            
            this.Close();
        }

        private void frmTuNgayDenNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbTuKyTinhLuong.Value != null && cbDenKyTinhLuong.Value != null)
                {
                    maKy1 = (int)cbTuKyTinhLuong.Value;
                    maKy2 = (int)cbDenKyTinhLuong.Value;
                    TuNgay = KyTinhLuong.GetKyTinhLuong(maKy1).NgayBatDau;
                    DenNgay = KyTinhLuong.GetKyTinhLuong(maKy2).NgayKetThuc;
                }

                this.Close();
            }
        }
    }
}