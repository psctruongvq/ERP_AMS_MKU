using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Diagnostics;
using System.IO;
using DevExpress.XtraEditors.Repository;

namespace PSC_ERP
{
    
    public partial class FrmDSNghiemThuThanhLy : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        NghiemThuThanhLyHopDongList _nghiemThuThanhLyHopDongList = NghiemThuThanhLyHopDongList.NewNghiemThuThanhLyHopDongList();
        NghiemThuThanhLyHopDong _nghiemThuThanhLyHopDong = NghiemThuThanhLyHopDong.NewNghiemThuThanhLyHopDong();
        long _maHopDong = 0;
        int _loai;
        #endregion

        public void ShowNghiemThu()
        {
            KhoiTao();
            DesignGridView1();
            _loai = 1;
            this.Text = "Danh Sách Nghiệm Thu";
            this.Show();
        }

        public void ShowThanhLy()
        {
            KhoiTao();
            DesignGridView1();
            _loai = 2;
            this.Text = "Danh Sách Thanh Lý";
            this.Show();
        }

        public void ShowNghiemThuThanhLy()
        {
            KhoiTao();
            DesignGridView1();
            _loai = 3;
            this.Text = "Danh Sách Nghiệm Thu Thanh Lý";
            this.Show();
        }

        #region Function
        private void DesignGridView1()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaNghiemThuThanhLyQL", "NoiDung", "SoTien","MaLoaiTien", "MaHopDong", "NgayKy", "TenNguoiKy", "GhiChu" },
                                new string[] { "Mã NT_TL", "Nội dung", "Số tiền","Loại tiền", "Số hợp đồng", "Ngày ký", "Người ký", "Ghi chú" },
                                             new int[] { 100, 120, 100,75, 100, 75, 100, 120 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaNghiemThuThanhLyQL", "NoiDung", "SoTien", "MaLoaiTien", "MaHopDong", "NgayKy", "TenNguoiKy", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev(gridView1, new string[] { "SoTien" });
            HamDungChung.ShowSummaryFooterofColumnGridViewDev(gridView1, new string[] { "SoTien" });

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            //
            RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien" }, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150 }, true);
            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_HopDong_ButtonClick);

            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            //
            //
            RepositoryItemGridLookUpEdit HopDong_GrdLU = new RepositoryItemGridLookUpEdit();
            HopDong_GrdLU.DataSource = HopDongMuaBanList_BindingSource1;
            HopDong_GrdLU.DisplayMember = "SoHopDong";
            HopDong_GrdLU.ValueMember = "MaHopDong";
            HamDungChung.InitRepositoryItemGridLookUpDev(HopDong_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HopDong_GrdLU, new string[] { "SoHopDong", "TenHopDong" }, new string[] { "Số hợp đồng", "Nội dung" }, new int[] { 100, 150 }, true);
            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(HopDong_GrdLU);
            HopDong_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_HopDong_ButtonClick);

            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaHopDong", HopDong_GrdLU);
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev(gridView1, new string[] { "SoTien" });
            gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
        }
        #endregion



        public FrmDSNghiemThuThanhLy()
        {
            InitializeComponent();
           // KhoiTao();
        }

        private void KhoiTao()
        {
            HopDongMuaBanList hopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanByUserID();
            HopDongMuaBan hopDong = HopDongMuaBan.NewHopDongMuaBan(0, "Không chọn");
            hopDongMuaBanList.Insert(0, hopDong);
            HopDongMuaBanList_BindingSource.DataSource = hopDongMuaBanList;

            HopDongMuaBanList_BindingSource1.DataSource = HopDongMuaBanList.GetHopDongMuaBanByUserID();
            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();
            NghiemThuThanhLyList_bindingSource.DataSource = _nghiemThuThanhLyHopDongList;
            gridControl1.DataSource = NghiemThuThanhLyList_bindingSource;

            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;

        }

        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (checkEdit_Ngay.Checked == true)
            {
                _nghiemThuThanhLyHopDongList = NghiemThuThanhLyHopDongList.GetNghiemThuThanhLyHopDongList(_maHopDong,(Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date,_loai);
            }
            else
            {
                _nghiemThuThanhLyHopDongList = NghiemThuThanhLyHopDongList.GetNghiemThuThanhLyHopDongList(_maHopDong,_loai);
            }
            NghiemThuThanhLyList_bindingSource.DataSource = _nghiemThuThanhLyHopDongList;
            if (_nghiemThuThanhLyHopDongList.Count == 0)//M
                MessageBox.Show("Danh Sách Nghiệm thu thanh lý rỗng!");
        }

        private void GridlookUpEdit_HopDong_EditValueChanged(object sender, EventArgs e)
        {
            long maHopDong;
            if (long.TryParse(GridlookUpEdit_HopDong.EditValue.ToString(), out maHopDong))
            {
                _maHopDong = maHopDong;
            }


        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                NghiemThuThanhLyHopDong nghiemThuThanhLy = gridView1.GetFocusedRow() as NghiemThuThanhLyHopDong;
                _nghiemThuThanhLyHopDong = NghiemThuThanhLyHopDong.GetNghiemThuThanhLyHopDong(nghiemThuThanhLy.MaNghiemThuThanhLy);
                FrmThanhLy frm = new FrmThanhLy(_nghiemThuThanhLyHopDong);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    btn_Tim.PerformClick();
                }
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FrmNghiemThuThanhLy frm = new FrmNghiemThuThanhLy();
            FrmThanhLy frm = new FrmThanhLy(_loai);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                btn_Tim.PerformClick();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _nghiemThuThanhLyHopDongList.ApplyEdit();
                NghiemThuThanhLyList_bindingSource.EndEdit();
                _nghiemThuThanhLyHopDongList.Save();
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HamDungChung.DeleteSelectedRowsGridViewDev(gridView1))
            { 
                MessageBox.Show("Việc xóa sẽ có hiệu lực khi bạn nhấn nút [Lưu]!");
            }
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
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void GridLookUpEdit_HopDong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        
    }
}