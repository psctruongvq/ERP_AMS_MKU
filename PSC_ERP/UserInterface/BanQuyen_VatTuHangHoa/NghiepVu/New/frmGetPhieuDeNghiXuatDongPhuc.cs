using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraEditors.Repository;
//13/04/2013
namespace PSC_ERP
{
    public partial class frmGetPhieuDeNghiXuatDongPhuc : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        int _loaiPhieu = 0;
        PhieuDeNghiXuatDongPhucList _phieuDeNhiXuatDongPhucList;
        PhieuDeNghiXuatDongPhucList _phieuDeNhiXuatDongPhucListSelected = PhieuDeNghiXuatDongPhucList.NewPhieuDeNghiXuatDongPhucList();
        BindingSource PhieudeNghiXuatDongPhuc_BindingSource = new BindingSource();
        CT_PhieuDeNghiXuatDongPhucList _ct_phieuDeNhiXuatDongPhucList;
        CT_PhieuDeNghiXuatDongPhucList _ct_phieuDeNhiXuatDongPhucListSelected = CT_PhieuDeNghiXuatDongPhucList.NewCT_PhieuDeNghiXuatDongPhucList();
        BindingSource CT_PhieudeNghiXuatDongPhuc_BindingSource = new BindingSource();
        public PhieuDeNghiXuatDongPhucList PhieuDeNhiXuatDongPhucListSelected
        {
            get { return _phieuDeNhiXuatDongPhucListSelected; }

        }
        public CT_PhieuDeNghiXuatDongPhucList CT_PhieuDeNhiXuatDongPhucListSelected
        {
            get { return _ct_phieuDeNhiXuatDongPhucListSelected; }

        }
        #endregion//Properties

        #region Function

        private void FormatForm()
        {
        }

        private void DesignGridViewMaster()
        {
            #region Design Gridview
            gridControl1.DataSource = PhieudeNghiXuatDongPhuc_BindingSource;

            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "Check", "SoPhieu", "NgayNX", "MaQLDoiTac", "TenDoiTac", "SoCTKemTheo", "Lop", "GioiTinh", "DienGiai" },
                               new string[] { "Chọn", "Số phiếu", "Ngày lập", "Mã đối tượng", "Tên đối tượng", "Số CT kèm theo", "Lớp", "Giới Tính", "Nội dung" },
                                            new int[] { 80, 100, 80, 80, 100, 100, 80, 100, 100 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Check", "SoPhieu", "NgayNX", "MaQLDoiTac", "TenDoiTac", "SoCTKemTheo", "Lop", "GioiTinh", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "Check", "SoPhieu", "NgayNX", "MaQLDoiTac", "TenDoiTac", "SoCTKemTheo", "Lop", "GioiTinh", "DienGiai" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design Gridview

        }


        private void DesignGridViewDetails()
        {
            #region Design Gridview
            gridControl1.DataSource = PhieudeNghiXuatDongPhuc_BindingSource;

            HamDungChung.InitGridViewDev(gridView2, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

            HamDungChung.ShowFieldGridViewDev_Modify(gridView2, new string[] { "Check", "MaHang", "MaDonViTinh", "SoLuong", "DienGiai" },
                               new string[] { "Chọn", "Mã hàng", "Mã đơn vị tính", "Số lượng", "Diễn giải" },
                                            new int[] { 10, 100, 80, 80, 100, 100 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView2, new string[] { "Check", "MaHang", "MaDonViTinh", "SoLuong", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView2, new string[] { "Check", "MaHang", "MaDonViTinh", "SoLuong", "DienGiai" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView2, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView2, 50);//M
            #endregion//Design Gridview
            //DonViTinh
            RepositoryItemGridLookUpEdit DVT_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(DVT_GrdLU, donViTinhListBindingSource, "MaQuanLy", "MaDonViTinh", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DVT_GrdLU, new string[] { "MaQuanLy", "TenDonViTinh" }, new string[] { "Mã ĐVT", "Tên ĐVT" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView2, "MaDonViTinh", DVT_GrdLU);
        }

        private void loadForm(string tenDoiTuong)
        {
            PhieudeNghiXuatDongPhuc_BindingSource.DataSource = typeof(ChiTietXuatKhoFromOtherDB);
            // chi lay nhung hoa don cua nguoi lap chung tu
            _phieuDeNhiXuatDongPhucList = PhieuDeNghiXuatDongPhucList.GetPhieuDeNghiXuatDongPhucList(tenDoiTuong, _loaiPhieu);
            PhieudeNghiXuatDongPhuc_BindingSource.DataSource = _phieuDeNhiXuatDongPhucList;
            DesignGridViewMaster();
            DesignGridViewDetails();
        }



        public frmGetPhieuDeNghiXuatDongPhuc(string tenDoiTuong,int loaiPhieu)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            if (loaiPhieu == 20)
                _loaiPhieu = 26;
            else
                _loaiPhieu = 27;
            FormatForm();
            loadForm(tenDoiTuong);
            this.splitContainerControl1.SplitterPosition = Screen.PrimaryScreen.Bounds.Height / 2;
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }


        #endregion //Function

        #region Events

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FocustextBox1.Focus();
            PhieudeNghiXuatDongPhuc_BindingSource.EndEdit();
            foreach (PhieuDeNghiXuatDongPhuc gptg in _phieuDeNhiXuatDongPhucList)
            {
                if (gptg.Check == true)
                {
                    _phieuDeNhiXuatDongPhucListSelected.Add(gptg);
                }
            }
            foreach (CT_PhieuDeNghiXuatDongPhuc ct_pdgxdp in _ct_phieuDeNhiXuatDongPhucList)
            { 
                if(ct_pdgxdp.Check == true)
                {
                    _ct_phieuDeNhiXuatDongPhucListSelected.Add(ct_pdgxdp);
                }
            }
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        private void btnExportDataExcell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        #endregion Events

        private void btnHienThiChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FocustextBox1.Focus();
            string maDuocCheck = "";
            foreach(PhieuDeNghiXuatDongPhuc phieuDN in _phieuDeNhiXuatDongPhucList)
            {
                if (phieuDN.Check)
                {
                    maDuocCheck += phieuDN.MaDeNghiXuat.ToString() + ",";
                }
            }
            if (maDuocCheck.Trim() != "")
            {
                maDuocCheck = maDuocCheck.Substring(0, maDuocCheck.Length - 1);
                _ct_phieuDeNhiXuatDongPhucList = CT_PhieuDeNghiXuatDongPhucList.GetCT_PhieuDeNghiXuatDongPhucList_Multi(maDuocCheck);
                CT_PhieudeNghiXuatDongPhuc_BindingSource.DataSource = _ct_phieuDeNhiXuatDongPhucList;
                gridControl2.DataSource = CT_PhieudeNghiXuatDongPhuc_BindingSource;
            }
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAll.Checked == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    gridView2.SetRowCellValue(i, gridView2.Columns["Check"], true);
                }
            }
            else
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    gridView2.SetRowCellValue(i, gridView2.Columns["Check"], false);
                }
            }
        }

        private void btnDaXuaKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FocustextBox1.Focus();
                foreach (PhieuDeNghiXuatDongPhuc gptg in _phieuDeNhiXuatDongPhucList)
                {
                    if (gptg.Check == true)
                    {
                        gptg.DaXuat = true;
                    }
                }
                _phieuDeNhiXuatDongPhucList.Save();
                MessageBox.Show("Lưu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadForm("");
            }
            catch
            {
                MessageBox.Show("Lưu thất bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}