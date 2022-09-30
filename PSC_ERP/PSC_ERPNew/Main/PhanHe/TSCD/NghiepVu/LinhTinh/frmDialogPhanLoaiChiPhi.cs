using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSC_ERPNew.Main;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Views.Grid;
////
namespace PSC_ERPNew.Main
{
    public partial class frmDialogPhanLoaiChiPhi : Form
    {
        Entities _context = null;
        tblChungTu _chungTu = null;
        tblButToan _butToan = null;
        public frmDialogPhanLoaiChiPhi(Entities context, tblChungTu chungTu, tblButToan butToan)//, IQueryable<tblTaiKhoan> noTaiKhoanList, IQueryable<tblTaiKhoan> coTaiKhoanList)
        {
            InitializeComponent();
            _context = context;
            _chungTu = chungTu;
            _butToan = butToan;
        }

        private Boolean HopLe()
        {
            this.txtBlackHole.Focus();
            tblCTChiPhiSanXuatBindingSource.EndEdit();

            Decimal tongTien = 0;
            foreach (var chiPhi in _butToan.tblCT_ChiPhiSanXuat)
            {
                if ((chiPhi.MaChuongTrinh ?? 0) == 0)
                {
                    DialogUtil.ShowError("Có dòng chưa chọn công việc/CT");
                    return false;
                }
                tongTien += chiPhi.SoTien ?? 0;
            }
            //
            if (tongTien != _butToan.SoTien && _butToan.tblCT_ChiPhiSanXuat.Any())//.Count > 0)
            {
                DialogUtil.ShowError("Tổng tiền chi phí không bằng số tiền bút toán");
                return false;
            }
            return true;
        }
        private void frmDialogPhanLoaiChiPhi_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
           {
               //lấy danh sách chương trình chưa hoàn tất theo mã công ty
               tblnsChuongTrinhBindingSource.DataSource = NsChuongTrinh_Factory.New().Get_DanhSachChuaHoanTatByMaCongTy(BasicInfo.User.MaCongTy ?? 0);
               //lấy danh sách chi phi san xuat theo but toan
               tblCTChiPhiSanXuatBindingSource.DataSource = _butToan.tblCT_ChiPhiSanXuat;
               //lấy danh sách tài khoản
               IQueryable<tblTaiKhoan> taiKhoanList = TaiKhoan_Factory.New().GetAll();
               tblTaiKhoanBindingSource.DataSource = taiKhoanList;
               //
               //cai dat xoa
               GridUtil.DeleteHelper.Setup_ManualType(this.gridViewChiPhiSanXuat, (GridView gridView, List<Object> deleteList) =>
               {
                   //xóa
                   CT_ChiPhiSanXuat_Factory.FullDelete(context: _context, deleteList: deleteList);
               });
           };
        }

        private void btnDuaDuLieuVeChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HopLe())
                this.Close();
        }

        private void btnMucNganSach_ForGrid_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.gridViewChiPhiSanXuat.FocusedRowHandle >= 0)
            {
                //lay dong chi phi san xuat hien tai
                tblCT_ChiPhiSanXuat currentChiPhi = this.gridViewChiPhiSanXuat.GetFocusedRow() as tblCT_ChiPhiSanXuat;
                //kiem tra da chon chuong trinh
                if ((currentChiPhi.MaChuongTrinh ?? 0) == 0)
                {
                    DialogUtil.ShowWarning("Cần chọn công việc/CT");
                }
                else
                {
                    //lấy bút toán hiện tại
                    //tblButToan currentButToan = this.grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
                    //show danh sách bút toán mục ngân sách theo bút toán
                    using (frmDialogDanhSachGhiMucNganSachTheoButToanVaChiPhiSanXuat frm = new frmDialogDanhSachGhiMucNganSachTheoButToanVaChiPhiSanXuat(context: _context, chungTu: _chungTu, butToan: _butToan, chiPhiSanXuat: currentChiPhi))
                    {
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void gridViewChiPhiSanXuat_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

            //lấy chi phi san xuat vừa tạo mới trên lưới
            tblCT_ChiPhiSanXuat chiPhiSX = this.gridViewChiPhiSanXuat.GetRow(e.RowHandle) as tblCT_ChiPhiSanXuat;
            _chungTu.tblCT_ChiPhiSanXuat.Add(chiPhiSX);
            //_butToan.tblCT_ChiPhiSanXuat.Add(chiPhiSX);
            ThietLapChoChiPhiMoi(chiPhiSX);

        }

        private void ThietLapChoChiPhiMoi(tblCT_ChiPhiSanXuat chiPhiSX)
        {
            Decimal tongTienCacChiPhiSanXuatKhac = 0;
            foreach (var item in _butToan.tblCT_ChiPhiSanXuat)
            {
                if (!Object.ReferenceEquals(item, chiPhiSX))
                    tongTienCacChiPhiSanXuatKhac += item.SoTien ?? 0;
            }
            chiPhiSX.SoTien = _butToan.SoTien - tongTienCacChiPhiSanXuatKhac;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tblCT_ChiPhiSanXuat chiPhiSX = CT_ChiPhiSanXuat_Factory.New().CreateAloneObject();
            _chungTu.tblCT_ChiPhiSanXuat.Add(chiPhiSX);
            _butToan.tblCT_ChiPhiSanXuat.Add(chiPhiSX);
            tblCTChiPhiSanXuatBindingSource.Add(chiPhiSX);
            tblCTChiPhiSanXuatBindingSource.MoveLast();
            ThietLapChoChiPhiMoi(chiPhiSX);

        }


    }
}
