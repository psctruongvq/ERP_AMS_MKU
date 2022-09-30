using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//ttt
namespace PSC_ERP
{
    public partial class frmMainTongHop : Form
    {
        public frmMainTongHop()
        {
            InitializeComponent();
        }

        private void kỳKếToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (!FocusForm(typeof(frmKyKeToan)))
            {
                frmKyKeToan kyKeToan = new frmKyKeToan();
                kyKeToan.MdiParent = this;
                kyKeToan.Show();
            }   
        }
       
        public bool FocusForm(Type type)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == type)
                {
                    if (f.MinimizeBox == true)
                    {
                        f.Focus();
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();
                    return true;
                }
            }
            return false;
        }

      
        private void khóaSồKếToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmKhoaSo)))
            {
                frmKhoaSo khoaSo = new frmKhoaSo();
                khoaSo.MdiParent = this;
                khoaSo.Show();
            }
        }

        private void mởSồKếToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmMoSo)))
            {
                frmMoSo moSo = new frmMoSo();
                moSo.MdiParent = this;
                moSo.Show();
            }   

        }

        private void sốDưĐầuNămToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmSoDuDauNam)))
            {
                frmSoDuDauNam soDuDaNam = new frmSoDuDauNam();
                soDuDaNam.MdiParent = this;
                soDuDaNam.Show();
            }   
        }

        private void sốDưĐầuKỳToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmSoDuDauKy)))
            {
                frmSoDuDauKy soDuDauKy = new frmSoDuDauKy();
                soDuDauKy.MdiParent = this;
                soDuDauKy.Show();
            }   
        }

        private void hệThốngTàiKhoảnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHeThongTaiKhoan)))
            {
                frmHeThongTaiKhoan heThongTaiKhoan = new frmHeThongTaiKhoan();
                heThongTaiKhoan.MdiParent = this;
                heThongTaiKhoan.Show();
            }   
        }

        private void báoCáoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBaoCaoTongHop)))
            {
                frmBaoCaoTongHop baoCaoTongHop = new frmBaoCaoTongHop();
                baoCaoTongHop.MdiParent = this;
                baoCaoTongHop.Show();
            } 
        }

        private void mauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmMauBangCanDoiKeToan)))
            {
                frmMauBangCanDoiKeToan baoCaoTongHop = new frmMauBangCanDoiKeToan();
                baoCaoTongHop.MdiParent = this;
                baoCaoTongHop.Show();
            } 
        }

        private void mẫuBáoCáoKếtQuảHoạtĐộngKinhDoanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmMauBCKQHoatDongKinhDoanh)))
            {
                frmMauBCKQHoatDongKinhDoanh baoCaoTongHop = new frmMauBCKQHoatDongKinhDoanh();
                baoCaoTongHop.MdiParent = this;
                baoCaoTongHop.Show();
            } 
        }

        private void mẫuBáoCáoLưuChuyểnTiềnTệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmMauBaoCaoLuuChuyenTienTe)))
            {
                frmMauBaoCaoLuuChuyenTienTe baoCaoLuuChuyenTienTe = new frmMauBaoCaoLuuChuyenTienTe();
                baoCaoLuuChuyenTienTe.MdiParent = this;
                baoCaoLuuChuyenTienTe.Show();
            } 
        }

        private void taiKhoanKêtChuyênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmTaiKhoanKetChuyen)))
            {
                frmTaiKhoanKetChuyen taiKhoanKetChuyen= new frmTaiKhoanKetChuyen();
                taiKhoanKetChuyen.MdiParent = this;
                taiKhoanKetChuyen.Show();
            } 
        }

        private void kêtChuyênTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmKetChuyenXacDinhKQHDKD)))
            {
                frmKetChuyenXacDinhKQHDKD ketChuyenTaiKhoan = new frmKetChuyenXacDinhKQHDKD();
                ketChuyenTaiKhoan.MdiParent = this;
                ketChuyenTaiKhoan.Show();
            } 
        }

        private void quýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmQuy)))
            {
                frmQuy quy = new frmQuy();
                quy.MdiParent = this; 
                quy.Show();
            } 
        }

        private void kếtChuyểnSốDưTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmKetChuyenTaiKhoan)))
            {
                frmKetChuyenTaiKhoan kctk = new frmKetChuyenTaiKhoan();
                kctk.MdiParent = this;
                kctk.Show();
            } 
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBaoCaoCacKhoanTTTheoMuc)))
            {
                frmBaoCaoCacKhoanTTTheoMuc frmbc = new frmBaoCaoCacKhoanTTTheoMuc();
                frmbc.MdiParent = this;
                frmbc.Show();
            } 
        }
    }
}