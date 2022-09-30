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
    public partial class frmChiTietGiayXacNhan_NhanVien : Form
    {
        TTNhanVienRutGonList _nhanVienList = TTNhanVienRutGonList.NewTTNhanVienRutGonList();
       public static ChiTietGiayXacNhan_NhanVienList _chiTietList;
        public frmChiTietGiayXacNhan_NhanVien()
        {
            InitializeComponent();
            this.bindingSource1_NhanVien.DataSource = typeof(TTNhanVienRutGonList);
            this.bindingSource1_ChiTietXacNhan_NhanVien.DataSource = typeof(ChiTietGiayXacNhan_NhanVienList);
       
        }
        public frmChiTietGiayXacNhan_NhanVien(ChiTietGiayXacNhan chiTietGiayXacNhanList, int maBoPhanDen)
        {
            InitializeComponent();
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListBoPhan(maBoPhanDen);
            this.bindingSource1_NhanVien.DataSource = _nhanVienList;
            this.bindingSource1_ChiTietXacNhan_NhanVien.DataSource = chiTietGiayXacNhanList.ChiTietGiayXacNhan_NhanVienList;
            _chiTietList = chiTietGiayXacNhanList.ChiTietGiayXacNhan_NhanVienList;
            
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
          
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            ultraGrid1.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {

        }

        private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Tab)
            //    ultraGrid1.UpdateData();
        }
    }
}