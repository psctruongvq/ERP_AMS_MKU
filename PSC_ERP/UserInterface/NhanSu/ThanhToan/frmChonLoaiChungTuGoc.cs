using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.ThanhToan
{
    public partial class frmChonLoaiChungTuGoc : Form
    {
        private bool OK = false;
        private int maLoaiChungTu = 0;
        string MaPhanHe = "";
        string PhanLoai = "";
        public frmChonLoaiChungTuGoc()
        {
            InitializeComponent();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool ChonLoaiChungTuGoc(string maPhanHe, string phanLoai)
        {
            MaPhanHe = maPhanHe;
            PhanLoai = phanLoai;
            this.ShowDialog();
            return OK;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (lstData.SelectedItem != null)
            {
                maLoaiChungTu = (int)lstData.SelectedValue;
                OK = true;
                this.Close();
            }
        }

        public ERP_Library.ThanhToan.LoaiChungTuGoc LoaiChungTu
        {
            get
            {
                return (ERP_Library.ThanhToan.LoaiChungTuGoc)lstData.SelectedItem;
            }
        }

        private void frmChonLoaiChungTuGoc_Load(object sender, EventArgs e)
        {
            bdData.DataSource = ERP_Library.ThanhToan.LoaiChungTuGocList.GetLoaiChungTuGocList(MaPhanHe, PhanLoai, false);
        }

        private void lstData_DoubleClick(object sender, EventArgs e)
        {
            btnDongY.PerformClick();
        }
    }
}