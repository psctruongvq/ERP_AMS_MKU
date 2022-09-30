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
    public partial class frmCapNhatCCDCDauTien : DevExpress.XtraEditors.XtraForm
    {
        CCDCDauTienEditableRootList _cCDCList = CCDCDauTienEditableRootList.NewCCDCDauTienEditableRootList();

        BindingSource _CCDCDauTienListBingdingSource = new BindingSource();

        public frmCapNhatCCDCDauTien()
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
            //BoPhanList _BoPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            //BoPhan _BoPhan = BoPhan.NewBoPhan(0, "<<Tất cả>>");
            //_BoPhanList.Insert(0, _BoPhan);
            //boPhanListBindingSource.DataSource = _BoPhanList;

            _CCDCDauTienListBingdingSource.DataSource = _cCDCList;
            gridControl1.DataSource = _CCDCDauTienListBingdingSource;
            //gridControl1.ContextMenuStrip = contextMenuStrip1;
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
            _cCDCList = CCDCDauTienEditableRootList.NewCCDCDauTienEditableRootList();
            _cCDCList = CCDCDauTienEditableRootList.GetCCDCDauTienEditableRootList();

            _CCDCDauTienListBingdingSource.DataSource = _cCDCList;
        }


        private void DesignGridView_CDCC()
        {
            HamDungChung.InitGridViewDev(gridView1,true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false,true, true);
            HamDungChung.ShowFieldGridViewDev2(gridView1, new string[] { "MaQuanLyCCDC", "TenCCDC", "Serial", "NguyenGia", "GiaTriBanDau", "NoiDatDe", "NuocSanXuat", "MaBoPhanQL" },
                                new string[] {"Số hiệu", "Tên CCDC", "Số Serial", "Nguyên giá", "Giá trị ban đầu", "Nơi đặt để (vị trí)", "Nước sản xuất", "Mã QL bộ phận"},
                                             new int[] { 100, 300, 80,90,90, 150,100,90 },true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaQuanLyCCDC", "TenCCDC", "Serial", "NguyenGia", "GiaTriBanDau", "NoiDatDe", "NuocSanXuat", "MaBoPhanQL" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "NguyenGia", "GiaTriBanDau" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "NguyenGia", "GiaTriBanDau" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "MaQuanLyCCDC", "MaBoPhanQL" });

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
          
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
            
        }

        private void InitForm()
        {
            boPhanListBindingSource.DataSource = typeof(BoPhanList);
            _CCDCDauTienListBingdingSource.DataSource = typeof(CCDCDauTienEditableRootList);
        }
        #endregion

        #region Event
        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //_choPhepCapNhatNguyenGia = false;
            ////btnLuu.Enabled = false;
            //Unlock_LockColumnNguyenGia(false);
            //LoadData();
            //if (_cCDCList.Count == 0)//M
            //    MessageBox.Show("Danh Sách CCDC rỗng!");
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

        private void frmCapNhatCCDCDauTien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        


        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxFocus.Focus();
            //if (_choPhepCapNhatNguyenGia)
            //{
            try
            {
                _CCDCDauTienListBingdingSource.EndEdit();
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