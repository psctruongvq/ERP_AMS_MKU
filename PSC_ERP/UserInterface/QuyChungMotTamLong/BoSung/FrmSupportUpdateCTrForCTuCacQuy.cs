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
    public partial class FrmSupportUpdateCTrForCTuCacQuy : DevExpress.XtraEditors.XtraForm
    {
        private ChungTu_CacLoaiQuyList _chungTu_CacLoaiQuyList;
        int _maLoaiChungTu;//2: Phieu THu; 3: PhieuChi; 16: Bang Ke
        DateTime _tungay;
        DateTime _dengay;

        public FrmSupportUpdateCTrForCTuCacQuy(int maloaichungtu, DateTime tungay,DateTime denngay)
        {
            InitializeComponent();
            _maLoaiChungTu = maloaichungtu;
            _tungay = tungay;
            _dengay = denngay;
            InitForm();
            KhoiTao();
            DesignGridView_HDBQ();

        }

        public void ShowBangKe()
        {
            KhoiTao();
            DesignGridView_HDBQ();
            this.Text = "Danh Sách Chứng Từ Bảng Kê - Các Quỹ";
            this.Show();

            FormatThongTinTimKiem(true);

        }


        private void InitForm()
        {
            this.bdDanhSachChungTu.DataSource = typeof(ChungTu_CacLoaiQuyList);
            bdLoaiThuChi.DataSource = typeof(LoaiThuChi_CacQuyList);
        }
        private void KhoiTao()
        {
            if(_maLoaiChungTu==2)
                this.Text = "Danh Sách Chứng Từ Phiếu Thu - Các Quỹ";
            else if (_maLoaiChungTu == 3)
                this.Text = "Danh Sách Chứng Từ Phiếu Chi - Các Quỹ";
            else if (_maLoaiChungTu == 16)
                this.Text = "Danh Sách Chứng Từ Bảng Kê - Các Quỹ";

            LoaiThuChi_CacQuyList _loaiThuChi_CacQuyList = LoaiThuChi_CacQuyList.GetLoaiThuChi_CacQuyList();
            _loaiThuChi_CacQuyList.Insert(0, LoaiThuChi_CacQuy.NewLoaiThuChi_CacQuy("<<None>>"));
            bdLoaiThuChi.DataSource = _loaiThuChi_CacQuyList;
           
            gridControl1.DataSource = bdDanhSachChungTu;
        }

        #region Function

        private void FormatThongTinTimKiem(bool isUnLock)
        {
            groupControl1.Enabled = isUnLock;  
        }

        private void GetThongTinSearch()
        {
            
        }

        private void LoadData()
        {
            _chungTu_CacLoaiQuyList = ChungTu_CacLoaiQuyList.GetChungTu_CacLoaiQuyList((Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _maLoaiChungTu);
            this.bdDanhSachChungTu.DataSource = _chungTu_CacLoaiQuyList;

            bdDanhSachChungTu.DataSource = _chungTu_CacLoaiQuyList;
        }


        private void DesignGridView_HDBQ()
        {
            //"SoChungTu","NgayLap","SoTien","SoTienButToan","TKNo","TKCo","MaLoaiChungTu","LoaiQuy","ChuongTrinh","DienGiai","TenDoiTac","DiaChi"
            //"Số Chứng Từ","Ngày Lập","Số Tiền","Số Tiền","TK Nợ","TK Có", "Loại Thu-Chi","Loại quỹ","Chương trình","Diễn Giải","Đối Tác ","Địa chỉ"

            HamDungChung.InitGridViewDev(gridView1,true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false,true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "SoChungTu", "NgayLap", "SoTien", "LoaiQuy", "MaLoaiThuChi", "DienGiai", "TenDoiTac", "DiaChi" },
                                new string[] { "Số Chứng Từ", "Ngày Lập", "Số Tiền", "Loại quỹ", "Chương trình", "Diễn Giải", "Đối Tác ", "Địa chỉ" },
                                             new int[] { 100, 80, 100,100, 120, 120, 100, 100});
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoChungTu", "NgayLap", "SoTien", "LoaiQuy", "MaLoaiThuChi", "DienGiai", "TenDoiTac", "DiaChi" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoChungTu", "NgayLap", "SoTien", "LoaiQuy", "TenDoiTac", "DiaChi" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "MaLoaiThuChi", "DienGiai" });

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            //
            RepositoryItemGridLookUpEdit LoaiThuChi_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiThuChi_GrdLU.DataSource = bdLoaiThuChi;
            LoaiThuChi_GrdLU.DisplayMember = "TenLoaiThuChi";
            LoaiThuChi_GrdLU.ValueMember = "MaLoaiThuChi";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiThuChi_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiThuChi_GrdLU, new string[] { "TenLoaiThuChi" }, new string[] { "Tên chương trình" }, new int[] { 250 }, true);
            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiThuChi_GrdLU);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiThuChi", LoaiThuChi_GrdLU);

            //gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        }

        

        private bool KiemTraChonHopDongRow()
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần thực hiện!");
                return false;
            }
            return true;
        }

        


        #endregion

        #region Event
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }
        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
            if (_chungTu_CacLoaiQuyList.Count == 0)//M
                MessageBox.Show("Danh Sách chứng từ rỗng!");
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
        #endregion

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



        private void FrmSupportUpdateCTrForCTuCacQuy_Load(object sender, EventArgs e)
        {
            DateTime tungay; DateTime denngay;
            if (DateTime.TryParse(_tungay.ToString(), out tungay) && DateTime.TryParse(_dengay.ToString(), out denngay))
            {
                dtEdit_TuNgay.EditValue = tungay;
                dtEdit_DenNgay.EditValue = denngay;
            }
            else
            {
                dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
                dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
            }
            LoadData();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxFocus.Focus();
            try
            {
                _chungTu_CacLoaiQuyList.ApplyEdit();
                bdDanhSachChungTu.EndEdit();
                _chungTu_CacLoaiQuyList.Save();
                MessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}