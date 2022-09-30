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
    public partial class FrmThuPhiListFromOtherDB : DevExpress.XtraEditors.XtraForm
    {
        List<ThuPhiListFromOtherDB> _thuPhiListFromOtherDB = new List<ThuPhiListFromOtherDB>();
        BindingSource ThuPhiListFromOtherDB_bindingSource = new BindingSource();
        private string _tenloaithuThuPhi = string.Empty;
        public string TenloaithuThuPhi
        {
            get { return _tenloaithuThuPhi; }
        }
        public FrmThuPhiListFromOtherDB()
        {
            InitializeComponent();
            KhoiTao();
            DesignGridView();
            LoadData();
        }

        private void KhoiTao()
        {
            ThuPhiListFromOtherDB_bindingSource.DataSource = typeof(ThuPhiListFromOtherDB);
            ThuPhiListFromOtherDB_bindingSource.DataSource = _thuPhiListFromOtherDB;
            gridControl1.DataSource = ThuPhiListFromOtherDB_bindingSource;
            //gridControl1.ContextMenuStrip = contextMenuStrip1;
        }

        #region Function


        private void LoadData()
        {
            _thuPhiListFromOtherDB = ThuPhiListFromOtherDB.LoadThuPhiListFromOtherDBList();  
            ThuPhiListFromOtherDB_bindingSource.DataSource = _thuPhiListFromOtherDB;
        }

        private void DesignGridView()
        {
            HamDungChung.InitGridViewDev(gridView1,true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false,true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "FeeDetailTypeName" },
                                new string[] { "Tên loại thu phí"},
                                             new int[] { 200});
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "FeeDetailTypeName" }, DevExpress.Utils.HorzAlignment.Center);
            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" },"#,###.#");
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

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
            ////
            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
            //gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
        }

        private bool KiemTraChonThuPhiRow()
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn Loại thu phí cần thực hiện!");
                return false;
            }
            return true;
        }


        private bool TestBeforeDelete()
        {
            return true;
        }

        private void DeleteObject()
        {
            if (TestBeforeDelete())
            {
                HamDungChung.DeleteSelectedRowsGridViewDev(gridView1);
            }
        }
        #endregion

        #region Event
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FrmThuPhiListFromOtherDBEdit frm = new FrmThuPhiListFromOtherDBEdit();

            //if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //{
            //    LoadData();
            //}
        }

        #endregion

        #region eventHandles
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteObject();
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }

        private void GrdView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                ThuPhiListFromOtherDB thuphi = gridView1.GetFocusedRow() as ThuPhiListFromOtherDB;
                _tenloaithuThuPhi = thuphi.FeeDetailTypeName;
                this.Close();

            }
        }
        #endregion eventHandles
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
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

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                ThuPhiListFromOtherDB thuphi = gridView1.GetFocusedRow() as ThuPhiListFromOtherDB;
                _tenloaithuThuPhi = thuphi.FeeDetailTypeName;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Loại thu phí cần thực hiện!");
            }
        }

    }
}