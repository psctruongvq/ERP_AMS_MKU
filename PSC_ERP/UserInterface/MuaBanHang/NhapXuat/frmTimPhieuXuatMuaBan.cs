using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Csla;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class frmTimPhieuXuatMuaBan : Form
    {
        PhieuNhapXuatList _PhieuXuatMuaBanList;
        Util util = new Util();
        public  PhieuNhapXuat phieuNhapXuat= PhieuNhapXuat.NewPhieuNhapXuat();
        private int _loai = 0;
        //public frmTimPhieuXuatMuaBan()
        //{
        //    InitializeComponent();
        //    KhoiTao();
        //}
        public frmTimPhieuXuatMuaBan(bool laNhap, int loai, byte quyTrinh)
        {
            InitializeComponent();
            KhoiTao(laNhap, loai, quyTrinh);
        }
        private void KhoiTao(bool laNhap, int loai, byte quyTrinh)
        {
            _loai = loai;
            _PhieuXuatMuaBanList = PhieuNhapXuatList.GetPhieuNhapXuat_MuaBanList(laNhap, 0, loai, quyTrinh);
            PhieuNhapXuat_bindingSource.DataSource = _PhieuXuatMuaBanList;
            if (laNhap)
            {
                HamDungChung.EditNhieuCot(grdu_DanhsachPhieuXuatMuaBan, 0,
                          new string[8] { "SoPhieu", "GiaTriKho", "GiaTriHoaDon", "TenNhanCong", "NgayNX", "TenKho", "TenDoiTac", "DienGiai" },
                          new string[8] { "Số Phiếu", "Giá Trị Nhập", "GT Hóa Đơn", "Người Nhập", "Ngày Nhập", "Vào Kho", "Khách Hàng", "Ghi Chú" },
                          new int[8] { 80, 80, 80, 80, 80, 80, 80, 80 },
                          new Control[8] { null, null, null, null, null, null, null, null },
                          new KieuDuLieu[8] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
                          new bool[8] { false, false, false, false, false, false, false, false }
                          );
            }
            else
            {
                HamDungChung.EditNhieuCot(grdu_DanhsachPhieuXuatMuaBan, 0,
                          new string[8] { "SoPhieu", "GiaTriKho", "GiaTriHoaDon", "TenNhanCong", "NgayNX", "TenKho", "TenDoiTac", "DienGiai" },
                          new string[8] { "Số Phiếu", "Giá Trị Xuất", "GT Hóa Đơn", "Người Xuất", "Ngày Xuất", "Từ Kho", "Khách Hàng", "Ghi Chú" },
                          new int[8] { 80, 80, 80, 80, 80, 80, 80, 80 },
                          new Control[8] { null, null, null, null, null, null, null, null },
                          new KieuDuLieu[8] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
                          new bool[8] { false, false, false, false, false, false, false, false }
                          );
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _PhieuXuatMuaBanList.ApplyEdit();
                _PhieuXuatMuaBanList.Save();
                MessageBox.Show("Lưu thành công!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DanhsachPhieuXuatMuaBan.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grdu_DanhsachPhieuXuatMuaBan.DeleteSelectedRows();
        }

        private void grdu_DanhsachPhieuXuatMuaBan_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            phieuNhapXuat = (PhieuNhapXuat)PhieuNhapXuat_bindingSource.Current;
            phieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat(phieuNhapXuat.MaPhieuNhapXuat);
            this.Close();
        }
    }
}