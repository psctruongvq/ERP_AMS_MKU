using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmDSPhieuNhapXuatBanQuyen : Form
    {
        PhieuNhapXuat _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
        public PhieuNhapXuat PhieuNhapXuat
        {
            get { return _phieuNhapXuat; }
        }
        public frmDSPhieuNhapXuatBanQuyen()
        {
            InitializeComponent();
        }
        public frmDSPhieuNhapXuatBanQuyen(short _loai, bool _laNhap)
        {
            InitializeComponent();
            //Gan Text
            if(_loai==1 && _laNhap==true)
                this.Text="Danh Sách Phiếu Nhập Bản Quyền";
            else if (_loai == 1 && _laNhap == false)
                this.Text = "Danh Sách Phiếu Xuất Bản Quyền";
            else if (_loai == 4 && _laNhap == true)
                this.Text = "Danh Sách Phiếu Nhập Bổ Sung Giá Trị";
            else if (_loai == 4 && _laNhap == false)
                this.Text = "Danh Sách Phiếu Xuất Bổ Sung Giá Trị";
            //
            phieuNhapXuatListBindingSource.DataSource = PhieuNhapXuatList.GetPhieuNhapXuatList(_loai, _laNhap);
            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListBy_All();
            thongTinNhanVienTongHopListBindingSource1.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
            khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoBQ_VTList();
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListByTen(0);

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnChonCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_DanhSachPhieuNhapXuat.GetFocusedRow() != null)
            {
                PhieuNhapXuat phieuNhapXuat = grdv_DanhSachPhieuNhapXuat.GetFocusedRow() as PhieuNhapXuat;
                _phieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat(phieuNhapXuat.MaPhieuNhapXuat);
                

            }
            this.Close();

        }

        private void grdv_DanhSachPhieuNhapXuat_DoubleClick(object sender, EventArgs e)
        {
            if (grdv_DanhSachPhieuNhapXuat.GetFocusedRow() != null)
            {
                PhieuNhapXuat phieuNhapXuat = grdv_DanhSachPhieuNhapXuat.GetFocusedRow() as PhieuNhapXuat;
                _phieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat(phieuNhapXuat.MaPhieuNhapXuat);

            }
            this.Close();
        }
    }
}
