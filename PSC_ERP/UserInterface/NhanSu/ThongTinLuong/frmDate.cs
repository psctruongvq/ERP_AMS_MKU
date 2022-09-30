using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmDate : Form
    {
        public static DateTime ngayDenHan = DateTime.Today.Date;
        public static int kieuNhanVien = 0;
        public static int kieuNangLuong = 0;
        public static bool isCancel = false;
        public frmDate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ngayDenHan = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
            kieuNhanVien = Convert.ToInt32(cmbLoaiNV.Value);
            kieuNangLuong = Convert.ToInt32(cbKieuNangLuong.Value);
            isCancel = false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isCancel = true;
            this.Close();
        }

        private void cmbLoaiNV_ValueChanged(object sender, EventArgs e)
        {
            kieuNhanVien = Convert.ToInt32(cmbLoaiNV.Value);
            //if (kieuNhanVien == 1)
            //{
            //    cbKieuNangLuong.Value = 1;
            //    kieuNangLuong = 1;
            //    cbKieuNangLuong.Enabled = false;
            //}
            //else
            //{
            //    cbKieuNangLuong.Enabled = true;
            //}
        }
    }
}
