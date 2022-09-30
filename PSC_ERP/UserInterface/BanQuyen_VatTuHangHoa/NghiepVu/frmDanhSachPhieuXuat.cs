using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
//24/04/2013
namespace PSC_ERP
{
    public partial class frmDanhSachPhieuXuat : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachPhieuXuat()
        {
            InitializeComponent();
            LoadForm();
        }

        int _maKho;
        long _maDoiTac;
        long _maNguoiNhapXuat;
        int _maPhongBan;
        byte _phuongPhapNX;
        DateTime _tuNgay;
        DateTime _denNgay;
        bool _laNhap = false;
        int _loaiPhieu;

        PhieuNhapXuatList _phieuNhapXuatList = PhieuNhapXuatList.NewPhieuNhapXuatList();

        public void LoadForm()
        {
            btnThemMoi.Enabled = false;

            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));
            _dataTable.Rows.Add(1, "Bình Quân");
            _dataTable.Rows.Add(2, "Nhập Xuất Thẳng");

            _maKho = 0;
            _maDoiTac = 0;
            _maNguoiNhapXuat = 0;
            _maPhongBan = 0;
            _phuongPhapNX = 1;// 0;
            _tuNgay = DateTime.Parse("12/12/2000");
            _denNgay = DateTime.Parse("12/12/2092");
            //_laNhap = false;
            _loaiPhieu = 0;


            this.luePPNX.Properties.DataSource = _dataTable;
            this.luePPNX.Properties.ValueMember = "Ma";
            this.luePPNX.Properties.DisplayMember = "Ten";
            this.luePPNX.EditValue = null;//M

            deTuNgay.EditValue = DateTime.Parse("12/12/2000");
            deDenNgay.EditValue = DateTime.Parse("12/12/2092");
            deTuNgay.Enabled = (bool)ceNgayNhapXuat.EditValue;
            deDenNgay.Enabled = (bool)ceNgayNhapXuat.EditValue;

            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
            thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListByTen(0);
            khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoVatTuList();
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btLuu();
        }
        private void btLuu()
        {
            try
            {
                //gridView_PhieuXuat.EndUpdate();                
                _phieuNhapXuatList.ApplyEdit();
                _phieuNhapXuatList.Save();

                MessageBox.Show(this, "Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(this, "Không thể lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void luePhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (luePhongBan.EditValue != null)
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)luePhongBan.EditValue, false);
        }

        private void gridView_PhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                gridView_PhieuXuat.DeleteSelectedRows();
        }

        private void ceNgayNhapXuat_CheckedChanged(object sender, EventArgs e)
        {
            deTuNgay.Enabled = (bool)ceNgayNhapXuat.EditValue;
            deDenNgay.Enabled = (bool)ceNgayNhapXuat.EditValue;
        }

        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lueKhoNhan.GetSelectedDataRow() == null)
                _maKho = 0;
            else
                _maKho = (int)lueKhoNhan.EditValue;
            if (luePhongBan.GetSelectedDataRow() == null)
                _maPhongBan = 0;
            else
                _maPhongBan = (int)luePhongBan.EditValue;
            if (lueNguoiNhan.GetSelectedDataRow() == null)
                _maNguoiNhapXuat = 0;
            else
                _maNguoiNhapXuat = (long)lueNguoiNhan.EditValue;
            if (luePPNX.GetSelectedDataRow() == null)
                _phuongPhapNX = 1;// 0;
            else
                _phuongPhapNX = (byte)luePPNX.EditValue;
            _tuNgay = (DateTime)deTuNgay.EditValue;
            _denNgay = (DateTime)deDenNgay.EditValue;

            _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList(_maKho, _maDoiTac, _maNguoiNhapXuat, _maPhongBan, _phuongPhapNX, _tuNgay, _denNgay, _laNhap, _loaiPhieu, 0);
            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void luePPNX_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                luePPNX.EditValue = null;
            }
        }

        private void lueNguoiNhan_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                lueNguoiNhan.EditValue = null;
            }
        }

        private void luePhongBan_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                luePhongBan.EditValue = null;
            }
        }

        private void lueKhoNhan_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                lueKhoNhan.EditValue = null;
            }
        }

        private void frmDanhSachPhieuXuat_Load(object sender, EventArgs e)
        {
            deTuNgay.EditValue = (object)DateTime.Today.Date;
            deDenNgay.EditValue = (object)DateTime.Today.Date;
            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(gridView_PhieuXuat, 35);
            Utils.GridUtils.SetSTTForGridView(gridView_CT_PhieuNhap, 35);
            Utils.GridUtils.SetSTTForGridView(gridView_CT_PhieuXuat, 35);
        }

        private void SubBtn_PhieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _laNhap = true;
            if (lueKhoNhan.GetSelectedDataRow() == null)
                _maKho = 0;
            else
                _maKho = (int)lueKhoNhan.EditValue;
            if (luePhongBan.GetSelectedDataRow() == null)
                _maPhongBan = 0;
            else
                _maPhongBan = (int)luePhongBan.EditValue;
            if (lueNguoiNhan.GetSelectedDataRow() == null)
                _maNguoiNhapXuat = 0;
            else
                _maNguoiNhapXuat = (long)lueNguoiNhan.EditValue;
            if (luePPNX.GetSelectedDataRow() == null)
                _phuongPhapNX = 1;// 0;
            else
                //_phuongPhapNX = (byte)luePPNX.EditValue;
                _phuongPhapNX = 1;
            _tuNgay = (DateTime)deTuNgay.EditValue;
            _denNgay = (DateTime)deDenNgay.EditValue;

            if (ceNgayNhapXuat.Checked == true)
            {
                _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList(_maKho, _maNguoiNhapXuat, _maPhongBan, _phuongPhapNX, _tuNgay, _denNgay, _laNhap);
            }
            else
            {
                _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList(_maKho, _maNguoiNhapXuat, _maPhongBan, _phuongPhapNX, _laNhap);
            }
            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
            if (_phieuNhapXuatList.Count == 0)//M
                MessageBox.Show("Danh Sách Phiếu rỗng!");
            
        }

        private void SubBtn_PhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _laNhap = false;
            if (lueKhoNhan.GetSelectedDataRow() == null)
                _maKho = 0;
            else
                _maKho = (int)lueKhoNhan.EditValue;
            if (luePhongBan.GetSelectedDataRow() == null)
                _maPhongBan = 0;
            else
                _maPhongBan = (int)luePhongBan.EditValue;
            if (lueNguoiNhan.GetSelectedDataRow() == null)
                _maNguoiNhapXuat = 0;
            else
                _maNguoiNhapXuat = (long)lueNguoiNhan.EditValue;
            if (luePPNX.GetSelectedDataRow() == null)
                _phuongPhapNX = 1;//0;
            else
                //_phuongPhapNX = (byte)luePPNX.EditValue;
                _phuongPhapNX = 1;
            _tuNgay = (DateTime)deTuNgay.EditValue;
            _denNgay = (DateTime)deDenNgay.EditValue;

            if (ceNgayNhapXuat.Checked == true)
            {
                _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList(_maKho, _maNguoiNhapXuat, _maPhongBan, _phuongPhapNX, _tuNgay, _denNgay, _laNhap);
            }
            else
            {
                _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList(_maKho, _maNguoiNhapXuat, _maPhongBan, _phuongPhapNX, _laNhap);
            }
            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
            if (_phieuNhapXuatList.Count == 0)//M
                MessageBox.Show("Danh Sách Phiếu rỗng!");
        }

        private void repositoryItemGridLookUpEdit_Kho_Click(object sender, EventArgs e)
        {
            //if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            //{
            //    luePPNX.EditValue = null;
            //} 
        }

        private void CheckEdit_XacNhan_EditValueChanged(object sender, EventArgs e)
        {
            //
            PhieuNhapXuat _pnx = phieuNhapXuatListBindingSource.Current as PhieuNhapXuat;
            CheckEdit ch = sender as CheckEdit;
            if (ch.EditValue != null)
            {
                _pnx.XacNhan = (bool)ch.EditValue;
            }
        }

        private void repositoryItemGridLookUpEdit_Kho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)//M
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void repositoryItemGridLookUpEdit_BoPhan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)//M
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void repositoryItemGridLookUpEdit_DoiTac_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)//M
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void repositoryItemGridLookUpEdit_NhanVien_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)//M
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }//M










    }
}
