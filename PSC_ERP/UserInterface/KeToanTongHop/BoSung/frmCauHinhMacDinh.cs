using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using DevExpress.XtraEditors.Repository;

namespace PSC_ERP
{
    public partial class frmCauHinhMacDinh : DevExpress.XtraEditors.XtraForm
    {
        TaiKhoanThueH _tKThue;
        TaiKhoanThueHList _tKThueList;
        HeThongTaiKhoan1List _taiKhoanList;
        CongTyList _congTyList;
        public frmCauHinhMacDinh()
        {
            InitializeComponent();
            #region GetTaiKhoan
            _taiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();// TaiKhoanList.GetTaiKhoanList();
            _congTyList = CongTyList.GetCongTyList();
            HeThongTaiKhoan1 httk = HeThongTaiKhoan1.NewHeThongTaiKhoan1("Không chọn");
            _taiKhoanList.Insert(0, httk);
            bs_TaiKhoanList.DataSource = _taiKhoanList;
            lueTKThue.Properties.DataSource = bs_TaiKhoanList;
            lueTKThue.Properties.DisplayMember = "SoHieuTK";
            lueTKThue.Properties.ValueMember = "MaTaiKhoan";
            lueTKTamUng.Properties.DataSource = bs_TaiKhoanList;
            lueTKTamUng.Properties.DisplayMember = "SoHieuTK";
            lueTKTamUng.Properties.ValueMember = "MaTaiKhoan";
            lueTKPhaiNop.Properties.DataSource = bs_TaiKhoanList;
            lueTKPhaiNop.Properties.DisplayMember = "SoHieuTK";
            lueTKPhaiNop.Properties.ValueMember = "MaTaiKhoan";
            #endregion


            this.Load += FrmCauHinhMacDinh_Load;
            this.btnThemMoi.ItemClick += BtnThemMoi_ItemClick1;
            this.btnLuu.ItemClick += BtnLuu_ItemClick;
            this.btnXoa.ItemClick += BtnXoa_ItemClick;
            this.btnThoat.ItemClick += BtnThoat_ItemClick;
        }

        private void BtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvCauHinhMD.GetFocusedRow() != null)
            {
                gvCauHinhMD.DeleteSelectedRows();
            }
            else
            {
                MessageBox.Show("Vui Lòng chọn dòng cần xóa!");
            }
        }

        private void BtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                _tKThueList.ApplyEdit();
                tblTKThue.EndEdit();
                _tKThueList.Save();

                MessageBox.Show(this, "Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Không thể lưu");
            }
        }

        private void BtnThemMoi_ItemClick1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _tKThue = TaiKhoanThueH.NewTaiKhoanThueH();
                _tKThueList.Insert(0, _tKThue);
                gvCauHinhMD.MoveFirst();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboSPGrid()
        {
            var editor = (RepositoryItemGridLookUpEdit)gcCauHinhMD.RepositoryItems.Add("GridLookUpEdit");
            editor.DataSource = _taiKhoanList;
            editor.ValueMember = "SoHieuTK";
            editor.DisplayMember = "SoHieuTK";

            gvCauHinhMD.Columns["SoHieuTKTamUng"].ColumnEdit = editor;
            gvCauHinhMD.Columns["SoHieuTKTamUng"].FieldName = "SoHieuTKTamUng";
            //gridView1.Columns["MaSP"].Visible = false;
        }

        private void FrmCauHinhMacDinh_Load(object sender, EventArgs e)
        {
            _tKThueList = TaiKhoanThueHList.GetTaiKhoanThueHList();
            tblTKThue.DataSource = _tKThueList;
            gcCauHinhMD.DataSource = tblTKThue;

            _congTyList = CongTyList.GetCongTyList();
            bs_CongTy.DataSource = _congTyList;
            lueCongTy.Properties.DataSource = bs_CongTy;
            lueCongTy.Properties.DisplayMember = "TenCongTy";
            lueCongTy.Properties.ValueMember = "MaCongTy";


            gvCauHinhMD.Columns["Id"].Visible = false;
            gvCauHinhMD.Columns["MaTaiKhoanThue"].Visible = false;
            gvCauHinhMD.Columns["MaTKTamUng"].Visible = false;
            gvCauHinhMD.Columns["MaTaiKhoanThuePhaiNop"].Visible = false;
            gvCauHinhMD.Columns["MaCongTy"].Visible = false;


            gvCauHinhMD.Columns["SoHieuTKThue"].Caption = "Số hiệu TK thuế";
            gvCauHinhMD.Columns["SoHieuTKTamUng"].Caption = "Số hiệu TK tạm ứng";
            gvCauHinhMD.Columns["MaCongTy"].Caption = "Mã công ty";
            gvCauHinhMD.Columns["TenCongTy"].Caption = "Tên công ty";
            gvCauHinhMD.Columns["MauHoaDon"].Caption = "Mẫu hóa Đơn";
            gvCauHinhMD.Columns["KyHieuHoaDon"].Caption = "Ký hiệu hóa đơn";
            gvCauHinhMD.Columns["SoHieuTKThuePhaiNop"].Caption = "Số hiệu TK thuế phải nộp";
            gvCauHinhMD.Columns["DungChung"].Caption = "Dùng chung";
            gvCauHinhMD.Columns["TuNgayNamTC"].Caption = "Từ ngày";
            gvCauHinhMD.Columns["DenNgayNamTC"].Caption = "Đến ngày";
            gvCauHinhMD.Columns["TuThangNamTC"].Caption = "Từ tháng";
            gvCauHinhMD.Columns["DenThangNamTC"].Caption = "Đến tháng";
            gvCauHinhMD.OptionsBehavior.ReadOnly = true;
            //cboSPGrid();
        }
    }
}
