using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid;

namespace PSC_ERP
{
    public partial class frmThongTinChung : DevExpress.XtraEditors.XtraForm
    {
        #region Properties and Methods
        Default_Ngay _default_ngay;
        Default_NgayList _default_ngayList;
        #endregion //Properties and Methods


        #region Constructors
        public frmThongTinChung()
        {
            InitializeComponent();
            Default_NgayListBindingSource.DataSource = typeof(Default_NgayList);

        }
        #endregion//Constructors

        #region Functions
        private void loadForm()
        {
            _default_ngayList = Default_NgayList.GetDefault_NgayList_Modify();
            Default_NgayListBindingSource.DataSource = _default_ngayList;
            gridControl1.DataSource = Default_NgayListBindingSource;
            DesignGridView();

            if (Default_NgayListBindingSource.Count == 0)
                btnThemMoi.PerformClick();
            else
                _default_ngay
                    = (Default_Ngay)Default_NgayListBindingSource.Current;
        }


        private void DesignGridView()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "NgayApDung", "SoNgayPhepNamTrongNam", "TuoiConHuongPhuCap", "SoTienGiamTruBanThan", "SoNgayLamViecTrongThang", "SoGioTrongNgay", "TongSoGioNgoaiGio", "LuongCoBan", "LuongNoiBo", "PhuCapThamNien", "PhanTramThueThuLaoKhenThuong", "PhanTramBHXH", "PhanTramBHYT", "PhanTramBHTN", "PhanTramCongDoan" },
                                new string[] { "Ngày áp dụng", "Số ngày nghỉ phép trong năm", "Tuổi của con còn được hưởng PC", "Số tiền giảm trừ bản thân", "Số ngày làm việc trong tháng", "Số giờ làm việc trong 1 ngày", "Số giờ làm ngoài giờ tối đa", "Lương cơ bản", "Lương nội bộ", "Lương thâm niên", "% thuế thù lao - khen thưởng", "% BHXH", "% BHYT", "% BHTN", "% Công đoàn" },
                                             new int[] { 80, 100, 100, 100, 100, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "NgayApDung", "SoNgayPhepNamTrongNam", "TuoiConHuongPhuCap", "SoTienGiamTruBanThan", "SoNgayLamViecTrongThang", "SoGioTrongNgay", "TongSoGioNgoaiGio", "LuongCoBan", "LuongNoiBo", "PhuCapThamNien", "PhanTramThueThuLaoKhenThuong", "PhanTramBHXH", "PhanTramBHYT", "PhanTramBHTN", "PhanTramCongDoan" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoNgayPhepNamTrongNam", "SoNgayLamViecTrongThang", "SoGioTrongNgay", "TongSoGioNgoaiGio", "PhanTramThueThuLaoKhenThuong", "PhanTramBHXH", "PhanTramBHYT", "PhanTramBHTN", "PhanTramCongDoan" }, "#,##0.#0");
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] {  "TuoiConHuongPhuCap", "SoTienGiamTruBanThan", "LuongCoBan", "LuongNoiBo", "PhuCapThamNien" }, "#,##0.##");
            
            gridView1.OptionsNavigation.AutoFocusNewRow = true;
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "NgayApDung", "SoNgayPhepNamTrongNam", "TuoiConHuongPhuCap", "SoTienGiamTruBanThan", "SoNgayLamViecTrongThang", "SoGioTrongNgay", "TongSoGioNgoaiGio", "LuongCoBan", "LuongNoiBo", "PhuCapThamNien", "PhanTramThueThuLaoKhenThuong", "PhanTramBHXH", "PhanTramBHYT", "PhanTramBHTN", "PhanTramCongDoan" });
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            
            //
        }

        private void DeleteDefault_NgayList()
        {
            if (gridView1.RowCount > 0)
            {
                if (gridView1.GetSelectedRows().Length > 0)
                {
                    if (XtraMessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", gridView1.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        gridView1.DeleteSelectedRows();
                    }
                }
            }
        }

        private Default_Ngay NewDefault_Ngay()
        {
            Default_Ngay default_ngay = Default_Ngay.NewDefault_Ngay();
            Default_Ngay default_ngayMax = Default_Ngay.GetDefault_Ngay();
            default_ngay.SoCongTinhChuyenCan = default_ngayMax.SoCongTinhChuyenCan;
            default_ngay.SoNgayPhepNamTrongNam = default_ngayMax.SoNgayPhepNamTrongNam;
            default_ngay.SoNgayLamViecTrongThang = default_ngayMax.SoNgayLamViecTrongThang;
            default_ngay.HeSoKhiLamCaDem = default_ngayMax.HeSoKhiLamCaDem;
            default_ngay.NghiLonHonMayNgayTruLuong = default_ngayMax.NghiLonHonMayNgayTruLuong;
            default_ngay.PhanTramBHXH = default_ngayMax.PhanTramBHXH;
            default_ngay.PhanTramBHYT = default_ngayMax.PhanTramBHYT;
            default_ngay.TienCongDoan = default_ngayMax.TienCongDoan;
            default_ngay.PhuCapConNho = default_ngayMax.PhuCapConNho;
            default_ngay.TuoiConHuongPhuCap = default_ngayMax.TuoiConHuongPhuCap;
            default_ngay.SoGioGianCa = default_ngayMax.SoGioGianCa;
            default_ngay.TienHocViec = default_ngayMax.TienHocViec;
            default_ngay.TienThuViec = default_ngayMax.TienThuViec;
            default_ngay.PhuCapNhaO = default_ngayMax.PhuCapNhaO;
            default_ngay.PhuCapThamNien = default_ngayMax.PhuCapThamNien;
            default_ngay.PhuCapThamNienTangThem1Nam = default_ngayMax.PhuCapThamNienTangThem1Nam;
            default_ngay.PhucapChuyenCan = default_ngayMax.PhucapChuyenCan;
            default_ngay.TruBaoHiemTruocKhiTinhThue = default_ngayMax.TruBaoHiemTruocKhiTinhThue;
            default_ngay.LuongCoBan = default_ngayMax.LuongCoBan;
            default_ngay.SoGioTangCaToiDa = default_ngayMax.SoGioTangCaToiDa;
            default_ngay.CoGianTG = default_ngayMax.CoGianTG;
            default_ngay.TranBHXHNamNay = default_ngayMax.TranBHXHNamNay;
            default_ngay.TranBHXHNamTruoc = default_ngayMax.TranBHXHNamTruoc;
            default_ngay.SoTienGiamTruBanThan = default_ngayMax.SoTienGiamTruBanThan;
            default_ngay.LuongNoiBo = default_ngayMax.LuongNoiBo;
            default_ngay.SoGioTrongNgay = default_ngayMax.SoGioTrongNgay;
            default_ngay.PhuCapTienAn = default_ngayMax.PhuCapTienAn;
            default_ngay.PhuCapHanhChinh = default_ngayMax.PhuCapHanhChinh;
            default_ngay.PhanTramThueThuLaoKhenThuong = default_ngayMax.PhanTramThueThuLaoKhenThuong;
            default_ngay.PhanTramBHTN = default_ngayMax.PhanTramBHTN;
            default_ngay.PhanTramCongDoan = default_ngayMax.PhanTramCongDoan;
            default_ngay.TongSoGioNgoaiGio = default_ngayMax.TongSoGioNgoaiGio;
            default_ngay.PhuCapAnTrua = default_ngayMax.PhuCapAnTrua;
            return default_ngay;
        }

        #endregion//Functions

        #region Events
        private void frmThongTinChung_Load(object sender, EventArgs e)
        {
            loadForm();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _default_ngay = NewDefault_Ngay();
                _default_ngayList.Add(_default_ngay);
                //_default_ngayList.Insert(0, _default_ngay);
                gridView1.RefreshData();
                gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
                dateEdit_NgayApDung.Focus();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DeleteDefault_NgayList();
            }
            catch
            {
                MessageBox.Show("Nhấn nút Refesh trước khi thực hiện thao tác Xóa");
            }


        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _default_ngayList = Default_NgayList.GetDefault_NgayList_Modify();
            Default_NgayListBindingSource.DataSource = _default_ngayList;
            gridControl1.DataSource = Default_NgayListBindingSource;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                _default_ngayList.ApplyEdit();
                Default_NgayListBindingSource.EndEdit();
                _default_ngayList.Save();

                MessageBox.Show(this, "Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Không thể lưu");
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            this.Close();

        }

        private void frmThongTinChung_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_default_ngay.IsDirty)
            {
                DialogResult kq = MessageBox.Show("Bạn có muốn lưu sự chuyển đổi?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (kq == DialogResult.Yes)
                {
                    btnLuu.PerformClick();
                }
                else
                    if (kq == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
            }
        }

        #endregion//Events

        #region EventHandle
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteDefault_NgayList();
            }

        }
        #endregion//EventHandle

    }
}