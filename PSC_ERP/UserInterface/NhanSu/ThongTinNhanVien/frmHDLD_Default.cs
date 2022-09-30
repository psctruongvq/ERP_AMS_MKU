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


    public partial class frmHDLD_Default : Form
    {
        HinhThucHopDongList _HinhThucHopDongList;
        int Loai = 1;
        Util util = new Util();
        HopDongLaoDong_DieuKhoanList _HDLD_dieukhoan = HopDongLaoDong_DieuKhoanList.NewHopDongLaoDong_DieuKhoanList();
        public frmHDLD_Default()
        {
            InitializeComponent();
            this.Load_Source();
        }
        public frmHDLD_Default(int Loai)
        {
            InitializeComponent();
            this.Loai = Loai;
            this.Load_Source();
        }
        private void Load_Source()
        {
            try
            {
                if (Loai == 1)
                {
                    _HDLD_dieukhoan = HopDongLaoDong_DieuKhoanList.GetHopDongLaoDong_DieuKhoanListByKyMoi();
                    if (_HDLD_dieukhoan.Count == 0)
                    {
                        HopDongLaoDong_DieuKhoan hdld = HopDongLaoDong_DieuKhoan.NewHopDongLaoDong_DieuKhoan();
                        hdld.Loai = Loai;
                        _HDLD_dieukhoan.Add(hdld);
                    }
             
                }
                else if (Loai==2)
                {
                    _HDLD_dieukhoan = HopDongLaoDong_DieuKhoanList.GetHopDongLaoDong_DieuKhoanListByGiaHan();
                    if (_HDLD_dieukhoan.Count == 0)
                    {
                        HopDongLaoDong_DieuKhoan hdld = HopDongLaoDong_DieuKhoan.NewHopDongLaoDong_DieuKhoan();
                        hdld.Loai = Loai;
                        _HDLD_dieukhoan.Add(hdld);
                    }

                }
                else if (Loai == 3)
                {
                    _HDLD_dieukhoan = HopDongLaoDong_DieuKhoanList.GetHopDongLaoDong_DieuKhoanListByHocViecThuViec();
                    if (_HDLD_dieukhoan.Count == 0)
                    {
                        HopDongLaoDong_DieuKhoan hdld = HopDongLaoDong_DieuKhoan.NewHopDongLaoDong_DieuKhoan();
                        hdld.Loai = Loai;
                        _HDLD_dieukhoan.Add(hdld);
                    }

                }
                BindS_Dieukhoan.DataSource = _HDLD_dieukhoan;
            }
            catch (ApplicationException)
            {

            }

        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {

            Save();
        }
        private void Save()
        {
            try
            {
                _HDLD_dieukhoan.ApplyEdit();
                _HDLD_dieukhoan.Save();
                MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Source();
        }

      
        private void frmHDLD_Default_Load(object sender, EventArgs e)
        {
            _HinhThucHopDongList = HinhThucHopDongList.GetHinhThucHopDongList();
            hinhThucHopDongListBindingSource.DataSource = _HinhThucHopDongList;
        }

        private void frmHDLD_Default_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
        }
    }
}