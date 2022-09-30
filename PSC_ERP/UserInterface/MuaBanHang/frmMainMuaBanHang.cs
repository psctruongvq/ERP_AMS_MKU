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
    public partial class frmMainMuaBanHang : Form
    {
        public frmMainMuaBanHang()
        {
            InitializeComponent();

            //ERP_Library.Security.CurrentUser.Info.UserID;//= 14283;//frmDangNhap.maNguoiDung; //14283;
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

        void thoátToolStripMenuItem_mb_Click(object sender, EventArgs e)
        {
            menuStrip1_MuaBan.Items.Clear();
            menuStrip1_MuaBan.Dispose();
            menuStrip1_MuaBan = new MenuStrip();           

            this.Text = "PSC ERP (Pyramid Software & Consulting Enterprice Resource Planning)";
            this.Close();

        }

        void _frmMainMuaBanHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuStrip1_MuaBan.Items.Clear();
            menuStrip1_MuaBan.Dispose();
            menuStrip1_MuaBan = new MenuStrip();


            this.Text = "PSC ERP (Pyramid Software & Consulting Enterprice Resource Planning)";

        }


        #region delegates handle



        private void hóaĐơnThanhToánTiềnHoaHồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDonDichVu)))
            {
                frmHoaDonDichVu danhSach = new frmHoaDonDichVu(26, 4);
                danhSach.MdiParent = this;
                danhSach.Show();
            }
        }

        private void hoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDonDichVu)))
            {
                frmHoaDonDichVu danhSach = new frmHoaDonDichVu(26, 5);
                danhSach.MdiParent = this;
                danhSach.Show();
            }
        }

        private void donHangBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonHangBan)))
            {
                frmDonHangBan donHangBan = new frmDonHangBan((byte)0, 0);
                donHangBan.MdiParent = this;
                donHangBan.Show();
            }
        }

        private void lenhXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeXuatNhapKho)))
            {
                frmBangKeXuatNhapKho bangKeXuatKho = new frmBangKeXuatNhapKho((byte)0, 2, true);
                bangKeXuatKho.MdiParent = this;
                bangKeXuatKho.Show();
            }
        }

        private void donhangBanQuyTrinh2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonHangBan)))
            {
                frmDonHangBan donHangBan = new frmDonHangBan((byte)1, 0);
                donHangBan.MdiParent = this;
                donHangBan.Show();
            }
        }

        private void lenhXuatDonHangChuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKeNhapHang = new frmBangKeNhapDonHangChuan((byte)0, 2, true);
                bangKeNhapHang.MdiParent = this;
                bangKeNhapHang.Show();
            }
        }

         private void lậpLệnhXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeXuatNhapHangTuHoaDon)))
            {
                frmBangKeXuatNhapHangTuHoaDon BangKe = new frmBangKeXuatNhapHangTuHoaDon(1, false);
                BangKe.MdiParent = this;
                BangKe.Show();
            }
        }

        //private void hoaDonToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    //if (!FocusForm(typeof(frmHoaDon)))
        //    //{
        //    //    frmHoaDon hoaDon = new frmHoaDon((byte)0, 0,false);
        //    //    hoaDon.MdiParent = this;
        //    //    hoaDon.Show();
        //    //}   
        //}

        private void lenhXuatHoaDonChuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeHoaDonChuan)))
            {
                frmBangKeHoaDonChuan hoaDon = new frmBangKeHoaDonChuan((byte)1, 2, true);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void donHangMuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonMuaHang)))
            {
                frmDonMuaHang donMuaHang = new frmDonMuaHang();
                donMuaHang.MdiParent = this;
                donMuaHang.Show();
            }
        }

        private void lệnhNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeXuatNhapKho)))
            {
                frmBangKeXuatNhapKho bangKe = new frmBangKeXuatNhapKho((byte)0, 0, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void lenhNhapKhoChuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan((byte)0, 0, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void đơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonTraHangMua)))
            {
                frmDonTraHangMua donHang = new frmDonTraHangMua((byte)0);
                donHang.MdiParent = this;
                donHang.Show();
            }
        }


        private void đơnHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonNhanHangTra)))
            {
                frmDonNhanHangTra donHang = new frmDonNhanHangTra((byte)0, 1);
                donHang.MdiParent = this;
                donHang.Show();
            }
        }

        private void lệnhXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 2, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void lệnhXuấtKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeXuatNhapKho)))
            {
                frmBangKeXuatNhapKho bangKe = new frmBangKeXuatNhapKho((byte)0, 1, true);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonTraHangMua)))
            {
                frmDanhSachDonTraHangMua danhSachDonHang = new frmDanhSachDonTraHangMua();
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }
        
        private void danhSáchBảngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke((byte)0, 2, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke((byte)1, 1, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLenhNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke((byte)0, 0, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void phiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(0, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void phiếuXuấtToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(13, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }


        }

        private void phiếuXuấtToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuNhap = new frmNhapMuaBan(0, 0);
                phieuNhap.MdiParent = this;
                phieuNhap.Show();
            }
        }

        private void loạiTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmLoaiTien)))
            {
                frmLoaiTien loaiTien = new frmLoaiTien();
                loaiTien.MdiParent = this;
                loaiTien.Show();
            }
        }

        private void phuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmPhuongThucThanhToan)))
            {
                frmPhuongThucThanhToan phuongThucThanhToan = new frmPhuongThucThanhToan();
                phuongThucThanhToan.MdiParent = this;
                phuongThucThanhToan.Show();
            }
        }

        private void phươngThứcGiaoNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmPhuongThucGiaoNhan)))
            {
                frmPhuongThucGiaoNhan phuongThucGiaoNhan = new frmPhuongThucGiaoNhan();
                phuongThucGiaoNhan.MdiParent = this;
                phuongThucGiaoNhan.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 2, false, 0);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, false, 2, 0);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchLệnhXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke((byte)0, 2, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void phiếuXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(2, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }

        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBaoCaoBanHang)))
            {
                frmBaoCaoBanHang baoCao = new frmBaoCaoBanHang();
                baoCao.MdiParent = this;
                baoCao.Show();
            }
        }

        //private void hóaĐơnToolStripMenuItem3_Click(object sender, EventArgs e)
        //{
        //    //if (!FocusForm(typeof(frmHoaDon)))
        //    //{
        //    //    frmHoaDon hoaDon = new frmHoaDon(0, 14, true);
        //    //    hoaDon.MdiParent = this;
        //    //    hoaDon.Show();
        //    //}   
        //}

        private void danhSáchLệnhNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke((byte)0, 1, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        //private void danhSáchHóaĐơnToolStripMenuItem3_Click(object sender, EventArgs e)
        //{
        //    //if (!FocusForm(typeof(frmDanhSachHoaDon)))
        //    //{
        //    //    frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon((byte)0, 3);
        //    //    danhsachhoaDon.MdiParent = this;
        //    //    danhsachhoaDon.Show();
        //    //}   
        //}
        //MB
        //private void danhSáchPhiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
        //    {
        //        frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(0, false, 0);
        //        danhsachphieuxuat.MdiParent = this;
        //        danhsachphieuxuat.Show();
        //    }
        //}
        //MB
        //private void danhSáchPhiếuXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        //{

        //    if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
        //    {
        //        frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(0, false, 0);
        //        danhsachphieuxuat.MdiParent = this;
        //        danhsachphieuxuat.Show();
        //    }
        //}
        //MB
        //private void danhSáchPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
        //    {
        //        frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(0, true, 0);
        //        danhsachphieuxuat.MdiParent = this;
        //        danhsachphieuxuat.Show();
        //    }
        //}

        private void dachSáchPhiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(2, false, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }
        //MB
        //private void danhSáchPhiếuNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
        //    {
        //        frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(0, true, 0);
        //        danhsachphieuxuat.MdiParent = this;
        //        danhsachphieuxuat.Show();
        //    }
        //}

        private void nhómKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhomKhachHang)))
            {
                frmNhomKhachHang nhomKhachHang = new frmNhomKhachHang();
                nhomKhachHang.MdiParent = this;
                nhomKhachHang.Show();
            }
        }

        private void loạiKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!FocusForm(typeof(frmLoaiKhachHang)))
            {
                frmLoaiKhachHang loaiKhachHang = new frmLoaiKhachHang();
                loaiKhachHang.MdiParent = this;
                loaiKhachHang.Show();
            }
        }

        private void kháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmKhachHang)))
            {
                frmKhachHang KhachHang = new frmKhachHang();
                KhachHang.MdiParent = this;
                KhachHang.Show();
            }
        }

        private void danhSáchKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachKhachHang)))
            {
                frmDanhSachKhachHang dsKhachHang = new frmDanhSachKhachHang();
                dsKhachHang.MdiParent = this;
                dsKhachHang.Show();
            }
        }

        private void phiếuXuấtToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(0, true, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void đơnHàngToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonHangBan)))
            {
                frmDonHangBan donHangBan = new frmDonHangBan(0, 3);
                donHangBan.MdiParent = this;
                donHangBan.Show();
            }
        }

        private void lệnhXuấtKhoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 3, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void đơnHàngToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonHangBan)))
            {
                frmDonHangBan donHangBan = new frmDonHangBan(0, 5);
                donHangBan.MdiParent = this;
                donHangBan.Show();
            }
        }

        private void lệnhNhậpXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 11, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void hợpĐồngToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHopDong)))
            {
                frmHopDong hopDong = new frmHopDong(true);
                hopDong.MdiParent = this;
                hopDong.Show();
            }
        }

        private void đơnHàngToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonHangBan)))
            {
                frmDonHangBan donHangBan = new frmDonHangBan(0, 0);
                donHangBan.MdiParent = this;
                donHangBan.Show();
            }
        }

        private void lệnhXuấtKhoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 0, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void đơnHàngBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonHangBan)))
            {
                frmDonHangBan donHangBan = new frmDonHangBan(0, 1);
                donHangBan.MdiParent = this;
                donHangBan.Show();
            }
        }

        private void lệnhXuấtKhoToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeXuatNhapKho)))
            {
                frmBangKeXuatNhapKho bangKe = new frmBangKeXuatNhapKho(0, 1, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void đơnHàngToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonHangBan)))
            {
                frmDonHangBan donHangBan = new frmDonHangBan(0, 2);
                donHangBan.MdiParent = this;
                donHangBan.Show();
            }
        }

        private void lệnhXuấtKhoToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 2, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void phiếuXuấtToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(9, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(10, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void phieuXuatToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(4, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void phieuXuatTamToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(11, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void phiếuXuấtToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(0, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void phiếuXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(1, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void phiếuXuấtToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(12, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

             
        private void hợpĐồngToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHopDong)))
            {
                frmHopDong hopDong = new frmHopDong(false);
                hopDong.MdiParent = this;
                hopDong.Show();
            }
        }
     

        private void đơnHàngToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonMuaHang)))
            {
                frmDonMuaHang donHang = new frmDonMuaHang(0,0);
                donHang.MdiParent = this;
                donHang.Show();
            }
        }

        private void đơnHàngToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonMuaHang)))
            {
                frmDonMuaHang donHang = new frmDonMuaHang(1,0);
                donHang.MdiParent = this;
                donHang.Show();
            }
        }
      
        private void lệnhNhậpKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan lenhNhap = new frmBangKeNhapDonHangChuan(0, 3, true);
                lenhNhap.MdiParent = this;
                lenhNhap.Show();
            }
        }

        

        private void lệnhNhậpKhoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan lenhNhap = new frmBangKeNhapDonHangChuan(0, 0, true);
                lenhNhap.MdiParent = this;
                lenhNhap.Show();
            }
        }

        private void phiếuNhậpToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan lenhNhap = new frmNhapMuaBan(1, 0);
                lenhNhap.MdiParent = this;
                lenhNhap.Show();
            }

        }

        private void lệnhNhậpKhoToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan lenhNhap = new frmBangKeNhapDonHangChuan(0, 2, true);
                lenhNhap.MdiParent = this;
                lenhNhap.Show();
            }
        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuXuat = new frmNhapMuaBan(10, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuXuat = new frmNhapMuaBan(4, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuXuat = new frmNhapMuaBan(0, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void lệnhNhậpKhoToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeXuatNhapKho)))
            {
                frmBangKeXuatNhapKho bangKe = new frmBangKeXuatNhapKho(0, 1, true);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void đơnHàngToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachChiTietHangHoaTraLai)))
            {
                frmDanhSachChiTietHangHoaTraLai danhSach = new frmDanhSachChiTietHangHoaTraLai();
                danhSach.MdiParent = this;
                danhSach.Show();
            }
        }

        private void lệnhXuấtTạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 15, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void lệnhXuấtTạmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 14, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void lệnhNhậpKhoToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 13, true, 1);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void phiếuNhậpToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuNhap = new frmNhapMuaBan(19, 0);
                phieuNhap.MdiParent = this;
                phieuNhap.Show();
            }
        }

        private void phiếuNhậpToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuNhap = new frmNhapMuaBan(12, 0);
                phieuNhap.MdiParent = this;
                phieuNhap.Show();
            }
        }

        private void đơnHàngTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void đơnHàngToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonHangBan)))
            {
                frmDonHangBan donHang = new frmDonHangBan(0, 4);
                donHang.MdiParent = this;
                donHang.Show();
            }
        }

        private void lệnhXuấtKhoTạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 16, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void lệnhXuấtKhoToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 12, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void phiếuXuấtKhoTạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(15, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void phiếuXuấtToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(3, 0);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 3, false, 4);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }


        private void frmMainMuaBanHang_Load(object sender, EventArgs e)
        {

        }
        //MB
        private void lệnhNhậpToolStripMenuItem_Click_MB(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 13, true, 0);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void phiếuNhậpToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuNhap = new frmNhapMuaBan(14, 0);
                phieuNhap.MdiParent = this;
                phieuNhap.Show();
            }
        }
      
        private void lệnhNhậpKhoToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 12, true);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void phiếuNhậpToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuNhap = new frmNhapMuaBan(3, 0);
                phieuNhap.MdiParent = this;
                phieuNhap.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 3, true, 4);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 10, true, 3);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 0, true, 0);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void phiếuNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 4, true, 5);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 12, true, 2);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 10, false, 3);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 0, false, 0);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 4, false, 5);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 13, false, 1);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem9_Click(object sender, EventArgs e)
        {

            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 12, false, 2);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 19, true, 5);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void hợpĐồngToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHopDong)))
            {
                frmHopDong hopDong = new frmHopDong(true);
                hopDong.MdiParent = this;
                hopDong.Show();
            }
        }

        private void đơnHàngToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonHangBan)))
            {
                frmDonHangBan donHang = new frmDonHangBan(1, 0);
                donHang.MdiParent = this;
                donHang.Show();
            }
        }

        private void lệnhNhậpXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeHoaDonChuan)))
            {
                frmBangKeHoaDonChuan bangKe = new frmBangKeHoaDonChuan(1, 0, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void phiếuXuấtToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(0, 1);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem13_Click(object sender, EventArgs e)
        {

        }

        private void đơnHàngToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonHangBan)))
            {
                frmDonHangBan donHang = new frmDonHangBan(1, 1);
                donHang.MdiParent = this;
                donHang.Show();
            }
        }

        private void lệnhXuấtKhoToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeXuatNhapHangTuHoaDon)))
            {
                frmBangKeXuatNhapHangTuHoaDon bangKe = new frmBangKeXuatNhapHangTuHoaDon(1, false);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void phiếuXuấtToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmXuatMuaBan)))
            {
                frmXuatMuaBan phieuXuat = new frmXuatMuaBan(1, 1);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void đơnHàngTrảHàngTừKhoĐạiLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonNhanHangTra)))
            {
                frmDonNhanHangTra donHang = new frmDonNhanHangTra(0, 3);
                donHang.MdiParent = this;
                donHang.Show();
            }
        }

        private void đơnNhậnHàngTrảTừKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonNhanHangTra)))
            {
                frmDonNhanHangTra donHang = new frmDonNhanHangTra(0, 2);
                donHang.MdiParent = this;
                donHang.Show();
            }
        }

        private void lệnhNhậpHàngTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 13, true, 2);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void phiếuNhậpHàngTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuNhap = new frmNhapMuaBan(20, 0);
                phieuNhap.MdiParent = this;
                phieuNhap.Show();
            }
        }

        private void danhSáchHợpĐồngToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhsachHopDongMuaBan)))
            {
                frmDanhsachHopDongMuaBan danhSachHopDong = new frmDanhsachHopDongMuaBan(true);
                danhSachHopDong.MdiParent = this;
                danhSachHopDong.Show();
            }
        }
       
        private void danhSáchHợpĐồngToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhsachHopDongMuaBan)))
            {
                frmDanhsachHopDongMuaBan danhSachHopDong = new frmDanhsachHopDongMuaBan(false);
                danhSachHopDong.MdiParent = this;
                danhSachHopDong.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonHang)))
            {
                frmDanhSachDonHang danhSachDonHang = new frmDanhSachDonHang(0, 3);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonHang)))
            {
                frmDanhSachDonHang danhSachDonHang = new frmDanhSachDonHang(0, 0);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchĐơnHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonHang)))
            {
                frmDanhSachDonHang danhSachDonHang = new frmDanhSachDonHang(0, 1);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonHang)))
            {
                frmDanhSachDonHang danhSachDonHang = new frmDanhSachDonHang(0, 5);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonHang)))
            {
                frmDanhSachDonHang danhSachDonHang = new frmDanhSachDonHang(0, 4);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonHang)))
            {
                frmDanhSachDonHang danhSachDonHang = new frmDanhSachDonHang(0, 2);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonHang)))
            {
                frmDanhSachDonHang danhSachDonHang = new frmDanhSachDonHang(1, 0);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonHang)))
            {
                frmDanhSachDonHang danhSachDonHang = new frmDanhSachDonHang(1, 1);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }
       

        private void danhSáchĐơnHàngToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonHangMua)))
            {
                frmDanhSachDonHangMua danhSachDonHang = new frmDanhSachDonHangMua(0,0);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonHangMua)))
            {
                frmDanhSachDonHangMua danhSachDonHang = new frmDanhSachDonHangMua(1,0);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonNhanHangTra)))
            {
                frmDanhSachDonNhanHangTra danhSachDonHang = new frmDanhSachDonNhanHangTra(4);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchĐơnHàngTrảTừKhoĐạiLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonNhanHangTra)))
            {
                frmDanhSachDonNhanHangTra danhSachDonHang = new frmDanhSachDonNhanHangTra(3);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchĐơnNhậnHàngTrảTừKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonNhanHangTra)))
            {
                frmDanhSachDonNhanHangTra danhSachDonHang = new frmDanhSachDonNhanHangTra(2);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem18_Click(object sender, EventArgs e)
        {
           
        }

        private void danhSáchĐơnHàngTrảTừKhoĐạiLýToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonNhanHangTra)))
            {
                frmDanhSachDonNhanHangTra danhSachDonHang = new frmDanhSachDonNhanHangTra(5);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchLệnhXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 3, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhXuấtKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 0, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhXuấtKhoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 1, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhXuấtKýGửiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 14, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhXuấtBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 11, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhXuấtKýGửiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 16, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhXuấtKhoBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 12, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhXuấtKhoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 2, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhXuấtToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(1, 0, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhXuấtKhoToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(1, 1, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhNhậpKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 3, true);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 0, true);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhNhậpKhoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 1, true);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhNhậpKhoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 11, true);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhNhậpKhoToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 12, true);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhNhậpKhoToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 2, true);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhNhậpKhoToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 13, true, 1);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 13, true, 2);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchLệnhNahp65ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void danhSáchLệnhXuấtKhoTạmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchPhiếuXuấtToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(0, false, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuXuấtToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(10, false, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchLệnhXuấtTạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 15, false);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchPhiếuXuấtTạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(9, false, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuXuấtKýGửiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(11, false, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(1, false, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuXuấtBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(4, false, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuXuấtKýGửiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(15, false, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuXuấtKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(3, false, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuXuấtToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(12, false, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuXuấtToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(0, false, 1);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuXuấtToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(1, false, 1);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuNhậpToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(10, true, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(0, true, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuNhậpToolStripMenuItem3_Click(object sender, EventArgs e)
        {

            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(1, true, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuNhậpToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(4, true, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuNhậpToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(3, true, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuNhậpToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(12, false, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuNhậpToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(19, true, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuNhậpToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(20, true, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchPhiếuNhậpToolStripMenuItem9_Click(object sender, EventArgs e)
        {
           
        }

        private void danhSáchHóaĐơnToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, false, 10, 3);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, false, 0, 0);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, false, 13, 1);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, false, 4, 5);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, false, 3, 4);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, false, 12, 2);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(1, false, 0, 0);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(1, false, 1, 1);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, true, 10, 3);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, true, 0, 0);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, true, 4, 5);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, true, 3, 4);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, true, 12, 2);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, true, 19, 5);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, true, 20, 4);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            
        }

        private void lệnhNhậpKhoHàngMuaHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 14, true);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void phiếuNhậpKhoHàngMuaHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuNhap = new frmNhapMuaBan(11, 0);
                phieuNhap.MdiParent = this;
                phieuNhap.Show();
            }
        }

        private void lệnhNhậpKhoHàngMuaHộToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 16, true);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void phiếuNhậpKhoHàngMuaHộToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuNhap = new frmNhapMuaBan(15, 0);
                phieuNhap.MdiParent = this;
                phieuNhap.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 20, true, 4);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }

        private void danhSáchPhiếuNhậpTamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhSach = new frmDSPhieuNhapXuat(11, true, 0);
                danhSach.MdiParent = this;
                danhSach.Show();
            }
        }

        private void danhSáchPhiếuNhậpTạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhSach = new frmDSPhieuNhapXuat(15, true, 0);
                danhSach.MdiParent = this;
                danhSach.Show();
            }
        }

        private void mnt_HoaDonMuaHangDV_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDonDichVu)))
            {
                frmHoaDonDichVu hoaDon = new frmHoaDonDichVu(4);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void mnt_DanhSachHoaDonMHDV_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSHoaDonDichVu)))
            {
                frmDSHoaDonDichVu danhSachHoaDon = new frmDSHoaDonDichVu(4);
                danhSachHoaDon.MdiParent = this;
                danhSachHoaDon.Show();
            }
        }

        private void đạiLýThanhToánVàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void danhSáchPhiếuNhậpĐạiLýThanhToánVàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(21, true, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchLệnhNhậpKhoTạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke dsBangKe = new frmDanhSachBangke(0, 14, true);
                dsBangKe.MdiParent = this;
                dsBangKe.Show();
            }
        }

        private void danhSáchLệnhNhậpKhoHàngMuaHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke dsBangKe = new frmDanhSachBangke(0, 16, true);
                dsBangKe.MdiParent = this;
                dsBangKe.Show();
            }
        }           

        #endregion delegates handle      
               

        private void loạiHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmLoaiHopDong)))
            {
                frmLoaiHopDong loaiHopDong = new frmLoaiHopDong();
                loaiHopDong.MdiParent = this;
                loaiHopDong.Show();
            }
        }

        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHopDong)))
            {
                frmHopDong hopDong = new frmHopDong();
                hopDong.MdiParent = this;
                hopDong.Show();
            }
        }

        private void đơnHàngToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonMuaHang)))
            {
                frmDonMuaHang donHang= new frmDonMuaHang(0,1);
                donHang.MdiParent = this;
                donHang.Show();
            }
        }

        private void đơnHàngToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonMuaHang)))
            {
                frmDonMuaHang donHang = new frmDonMuaHang(1, 1);
                donHang.MdiParent = this;
                donHang.Show();
            }
        }

        private void lệnhNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeHoaDonChuan)))
            {
                frmBangKeHoaDonChuan bangKe = new frmBangKeHoaDonChuan(1, 0, true);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonHangMua)))
            {
                frmDanhSachDonHangMua dsDonHang = new frmDanhSachDonHangMua(0,1);
                dsDonHang.MdiParent = this;
                dsDonHang.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonHangMua)))
            {
                frmDanhSachDonHangMua dsDonHang = new frmDanhSachDonHangMua(1, 1);
                dsDonHang.MdiParent = this;
                dsDonHang.Show();
            }
        }

        private void danhSáchLệnhNhậpKhoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke dsBangKe = new frmDanhSachBangke(1,0, true);
                dsBangKe.MdiParent = this;
                dsBangKe.Show();
            }
        }

        private void danhSáchLệnhNhậpKhoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke dsBangKe = new frmDanhSachBangke(1, 1,  true);
                dsBangKe.MdiParent = this;
                dsBangKe.Show();
            }
        }

        private void danhSáchPhiếuNhậpKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(1, true, 1);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void lệnhNhậpKhoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeHoaDonChuan)))
            {
                frmBangKeHoaDonChuan bangKe = new frmBangKeHoaDonChuan(1, 1, true);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void phiếuNhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuXuat = new frmNhapMuaBan(0, 1);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void phiếuNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuXuat = new frmNhapMuaBan(1, 1);
                phieuXuat.MdiParent = this;
                phieuXuat.Show();
            }
        }

        private void danhSáchHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhsachHopDongMuaBan)))
            {
                frmDanhsachHopDongMuaBan dsHopDong = new frmDanhsachHopDongMuaBan(false);
                dsHopDong.MdiParent = this;
                dsHopDong.Show();
            }
        }

        private void danhSáchPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(0, true, 1);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhSachHoaDon = new frmDanhSachHoaDon(1, true,1, 0);
                danhSachHoaDon.MdiParent = this;
                danhSachHoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhSachHoaDon = new frmDanhSachHoaDon(1, true, 1, 1);
                danhSachHoaDon.MdiParent = this;
                danhSachHoaDon.Show();
            }
        }

        private void đơnHàngTrảToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonNhanHangTra)))
            {
                frmDonNhanHangTra donTraHang = new frmDonNhanHangTra(0, 1);
                donTraHang.MdiParent = this;
                donTraHang.Show();
            }
        }

        private void lệnhNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmBangKeNhapDonHangChuan)))
            {
                frmBangKeNhapDonHangChuan bangKe = new frmBangKeNhapDonHangChuan(0, 2, true, 0);
                bangKe.MdiParent = this;
                bangKe.Show();
            }
        }

        private void phiếuNhậpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmNhapMuaBan)))
            {
                frmNhapMuaBan phieuNhap = new frmNhapMuaBan(2, 0);
                phieuNhap.MdiParent = this;
                phieuNhap.Show();
            }
        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 2, true, 0);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void danhSáchĐơnHàngToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachDonNhanHangTra)))
            {
                frmDanhSachDonNhanHangTra danhSachDonHang = new frmDanhSachDonNhanHangTra(1);
                danhSachDonHang.MdiParent = this;
                danhSachDonHang.Show();
            }
        }

        private void danhSáchLệnhNhậpXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachBangke)))
            {
                frmDanhSachBangke danhsachbangke = new frmDanhSachBangke(0, 2, true, 0);
                danhsachbangke.MdiParent = this;
                danhsachbangke.Show();
            }
        }

        private void danhSáchPhiếuNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDSPhieuNhapXuat)))
            {
                frmDSPhieuNhapXuat danhsachphieuxuat = new frmDSPhieuNhapXuat(2, true, 0);
                danhsachphieuxuat.MdiParent = this;
                danhsachphieuxuat.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, true, 2, 0);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }
        }

        private void đơnVịTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDonViTinh)))
            {
                frmDonViTinh donViTinh = new frmDonViTinh();
                donViTinh.MdiParent = this;
                donViTinh.Show();
            }
        }

        private void hàngHóaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHangHoa)))
            {
                frmHangHoa hangHoa = new frmHangHoa();
                hangHoa.MdiParent = this;
                hangHoa.Show();
            }
        }

        private void loạiHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmLoaiHangHoa)))
            {
                frmLoaiHangHoa loaiHangHoa = new frmLoaiHangHoa();
                loaiHangHoa.MdiParent = this;
                loaiHangHoa.Show();
            }
        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmKho)))
            {
                frmKho kho= new frmKho();
                kho.MdiParent = this;
                kho.Show();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmHoaDon)))
            {
                frmHoaDon hoaDon = new frmHoaDon(0, 1, true, 1);
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
        }

        private void danhSáchHóaĐơnToolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhSachHoaDon)))
            {
                frmDanhSachHoaDon danhsachhoaDon = new frmDanhSachHoaDon(0, true, 1, 1);
                danhsachhoaDon.MdiParent = this;
                danhsachhoaDon.Show();
            }            
        }

        private void danhSáchHợpĐồngToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!FocusForm(typeof(frmDanhsachHopDongMuaBan)))
            {
                frmDanhsachHopDongMuaBan danhSachHopDong = new frmDanhsachHopDongMuaBan(true);
                danhSachHopDong.MdiParent = this;
                danhSachHopDong.Show();
            }
        }             

    }
}
