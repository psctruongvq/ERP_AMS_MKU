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
    public partial class frmDiaChi_NhanVien : Form
    {
        #region Properties
        QuocGiaList _QuocGiaList;
        TinhThanhList _TinhThanhList;
        QuanHuyenList _QuanHuyenList;
        DiaChi_NhanVien _DiaChi_NhanVien;
        public DiaChi_NhanVienList _DiaChi_NhanVienList;
        frmThongTinNhanVien f = new frmThongTinNhanVien();
        public string _diaChi;
        #endregion

        public frmDiaChi_NhanVien()
        {
            InitializeComponent();
            _DiaChi_NhanVienList = f._DiaChi_NhanVienList;
            NhanVien_DiaChi_bindingSource.DataSource = _DiaChi_NhanVienList;
            LayDuLieu();
        }
        private void LayDuLieu()
        {
            _QuocGiaList = QuocGiaList.GetQuocGiaList();
            QuocGia_bindingSource.DataSource = _QuocGiaList;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            _diaChi = txtu_SoNha.Text + ", " + cmbu_QuanHuyen.Text + ", " + cmbu_TinhThanh.Text + ", " + cmbu_QuocGia.Text;
            this.Close();
        }

        private void cmbu_QuocGia_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_QuocGia.ActiveRow != null)
            {
                _TinhThanhList = TinhThanhList.GetQuocGiaist((int)cmbu_QuocGia.Value);
                TinhThanh_BindingSource.DataSource = _TinhThanhList;
            }
        }

        private void cmbu_TinhThanh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_TinhThanh.ActiveRow != null)
            {
                _QuanHuyenList = QuanHuyenList.GetQuanHuyenList((int)cmbu_TinhThanh.Value);
                QuanHuyen_BindingSource.DataSource = _QuanHuyenList;
            }
        }
    }
}