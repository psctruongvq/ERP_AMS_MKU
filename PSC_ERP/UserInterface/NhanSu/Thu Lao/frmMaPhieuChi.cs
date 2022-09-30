using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;

namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class frmMaPhieuChi : Form
    {
        public static string MaPhieuChi = "";
        public static int MaKyTinhLuong = 0;
        public static DateTime NgayLap = DateTime.Today.Date;
        private KyTinhLuongList _kyTinhLuongList = KyTinhLuongList.NewKyTinhLuongList();
        public frmMaPhieuChi()
        {
            InitializeComponent();
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                MaPhieuChi = textBox1.Text;
                this.Close();
            }
            if (cbKyTinhLuong.Value != null)
            {
                MaKyTinhLuong = Convert.ToInt32(cbKyTinhLuong.Value) ;
            }
            NgayLap = dateTimePicker_NgayLap.Value;
        }

        private void frmMaPhieuChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text != "")
                {
                    MaPhieuChi = textBox1.Text;
                    this.Close();
                }
            }
        }
    }
}