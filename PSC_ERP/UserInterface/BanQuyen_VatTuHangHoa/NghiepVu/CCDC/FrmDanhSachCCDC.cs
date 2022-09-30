using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using System.IO;
using System.Diagnostics;

namespace PSC_ERP
{
    public partial class FrmDanhSachCCDC : DevExpress.XtraEditors.XtraForm
    {
        private bool _choPhepCapNhatNguyenGia = false;
        CCDCList _cCDCList = CCDCList.NewCongCuDungCuList();

        int _maBoPhan=0;
        DateTime _TuNgay; DateTime _DenNgay; byte _HTXemNgay;//1 Từ ngày Đến ngày; 2 Đến ngày;

        public FrmDanhSachCCDC()
        {
            InitializeComponent();
            InitForm();
            //btnLuu.Enabled = false;
            KhoiTao();
            DesignGridView_CDCC();
            //LoadData();
        }

        private void KhoiTao()
        {
            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "<<Tất cả>>");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;

            congCuDungCuListBindingSource.DataSource = _cCDCList;
            gridControl1.DataSource = congCuDungCuListBindingSource;
            gridControl1.ContextMenuStrip = contextMenuStrip1;
        }

        #region Function

        private void Unlock_LockColumnNguyenGia(bool unlock)
        {
            if (unlock)
                HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "NguyenGia" });
            else
                HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "NguyenGia" });
        }

        private void LoadData()
        {
            GetThongTinSearch();
            _cCDCList = CCDCList.NewCongCuDungCuList();
            _cCDCList = CCDCList.GetCongCuDungCuListForShowListAll(_maBoPhan,_TuNgay,_DenNgay,_HTXemNgay);
            
            congCuDungCuListBindingSource.DataSource = _cCDCList;
        }

        private void LoadDataForCapNhatNguyenGia()
        {
            _cCDCList = CCDCList.NewCongCuDungCuListForUpdate();
            _cCDCList = CCDCList.GetCongCuDungCuListForUpdateNguyenGia();

            congCuDungCuListBindingSource.DataSource = _cCDCList;
        }


        private void DesignGridView_CDCC()
        {
            HamDungChung.InitGridViewDev(gridView1,true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false,true, true);
            HamDungChung.ShowFieldGridViewDev2(gridView1, new string[] { "TenHangHoa", "MaQuanLy", "SoSerial", "NgayNhan", "HasManage", "ThoiGianSuDung", "NguyenGia","GiaTriConLai", "PhongBanHienTai", "GhiChu", "ChungTuPhanBo" },
                                new string[] { "Tên CCDC", "Mã CCDC", "Số Serial", "Ngày nhận", "CCDC quản lý", "Thời gian PB(năm)", "Nguyên giá","Giá trị còn lại", "Bộ phận hiện tại", "Ghi chú", "Số chứng từ phân bổ ban đầu" },
                                             new int[] { 200, 100, 90,90,90, 100,100,100,150,120,120 },false);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "TenHangHoa", "MaQuanLy", "SoSerial", "NgayNhan", "HasManage", "ThoiGianSuDung", "NguyenGia", "GiaTriConLai", "PhongBanHienTai", "GhiChu", "ChungTuPhanBo" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "NguyenGia", "GiaTriConLai" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "NguyenGia", "GiaTriConLai" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "TenHangHoa", "MaQuanLy", "SoSerial", "NgayNhan", "NguyenGia", "GiaTriConLai", "PhongBanHienTai", "GhiChu", "ChungTuPhanBo" });

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            ////
            //RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            //LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            //LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            //LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            //HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien"}, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150}, true);
            //HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            //LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            //HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            //gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        }

        private bool KiemTraChonCCDCRow()
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn công cụ dụng cụ cần xem!");
                return false;
            }
            return true;
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void GetThongTinSearch()
        {
            _maBoPhan = 0;
            if (lookUpEdit_PhongBan.EditValue != null)
            {
                int maBophanOut;
                if(int.TryParse(lookUpEdit_PhongBan.EditValue.ToString(),out maBophanOut))
                {
                    _maBoPhan = maBophanOut;
                }

            }

            _TuNgay = (DateTime)dtEdit_TuNgay.EditValue;
            _DenNgay = (DateTime)dtEdit_DenNgay.EditValue;
            _HTXemNgay =(byte) radioGroupChonDenNgay.EditValue;
        }

        private void InitForm()
        {
            boPhanListBindingSource.DataSource = typeof(BoPhanList);
            congCuDungCuListBindingSource.DataSource = typeof(CCDCList);
        }
        #endregion

        #region Event
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }
        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _choPhepCapNhatNguyenGia = false;
            //btnLuu.Enabled = false;
            Unlock_LockColumnNguyenGia(false);
            LoadData();
            if (_cCDCList.Count == 0)//M
                MessageBox.Show("Danh Sách CCDC rỗng!");
        }

        private void GridLookUpEdit_MaDuAn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void GrdView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_XuatRaExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        private void FrmDanhSachCCDC_Load(object sender, EventArgs e)
        {
            lookUpEdit_PhongBan.EditValue = 0;
            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
        }

        private void xemChiTiếtCCDCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraChonCCDCRow())
            {
                CCDC ccdc = gridView1.GetFocusedRow() as CCDC;
                CCDC ccdcUpdate = CCDC.NewCongCuDungCu();
                ccdcUpdate = CCDC.GetCongCuDungCuIsNotChild(ccdc.MaCongCuDungCu);

                frmChiTietCCDCList frm = new frmChiTietCCDCList(ccdcUpdate, true);

                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    LoadData();
                }
                //

            }
        }

        private void xemLịchSửĐiềuChuyểnCCDCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraChonCCDCRow())
            {
                CCDC ccdc = gridView1.GetFocusedRow() as CCDC;
                frmLichSuDieuChuyenCCDC frm = new frmLichSuDieuChuyenCCDC(ccdc.MaCongCuDungCu);
                frm.ShowDialog();
            }
        }

        private void btnCapNhatNguyenGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _choPhepCapNhatNguyenGia = true;
            //btnLuu.Enabled = true;
            Unlock_LockColumnNguyenGia(true);
            LoadDataForCapNhatNguyenGia();
            if (_cCDCList.Count == 0)//M
                MessageBox.Show("Danh Sách CCDC rỗng!");
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxFocus.Focus();
            //if (_choPhepCapNhatNguyenGia)
            //{
            try
            {
                congCuDungCuListBindingSource.EndEdit();
                _cCDCList.ApplyEdit();
                _cCDCList.Save();
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //}
        }
        #endregion

      


    }
}