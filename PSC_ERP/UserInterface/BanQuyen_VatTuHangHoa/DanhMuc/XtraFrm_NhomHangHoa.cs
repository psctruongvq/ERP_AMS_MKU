using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using PSC_ERP_Common;

namespace PSC_ERP
{
    public partial class XtraFrm_NhomHangHoa : XtraForm
    {
        #region Properties
        NhomHangHoaBQ_VT nhh;
        NhomHangHoaBQ_VTList _NhomHangHoaBQ_VTAll_forCombo;
        NhomHangHoaBQ_VTList _nhomHangHoaBQ_VTList_forGrid;
        LoaiVatTuHHBQ_VTList _loaiVatTuHHBQ_VTListAll;

        byte _kieu = 1;

        #endregion

        public XtraFrm_NhomHangHoa()
        {
            InitializeComponent();
            nhomHangHoaBQVTListAllBindingSource.DataSource = typeof(NhomHangHoaBQ_VTList);
            bs_NhomHangHoaList.DataSource = typeof(NhomHangHoaBQ_VTList);
            bs_LoaiVatTuHH.DataSource = typeof(LoaiVatTuHHBQ_VT);
        }
                
        public void ShowHangHoaBanQuyen()
        {
            _kieu = 1;
             LoadData();
             this.Show();
        }

        public void ShowHangHoaVatTu()
        {
            _kieu = 2;
            LoadData();
            this.Show();
        }

        private void DinhDangLable()
        {
            this.lb_MaNhomHangHoa.Text = "Mã nhóm chương trình:";
            this.lb_TenNhomHangHoa.Text = "Tên nhóm chương trình:";
            this.lb_ThuocNhomHangHoa.Text = "Thuốc nhóm chương trình:";
            //Grid
            this.colMaNhomHangHoa.Caption = "Mã Nhóm Chương Trình";
            this.colTenNhomHangHoa.Caption = "Tên Nhóm Chương Trình";
            colMaLoaiVatTuHH.Caption = "Tên Loại Chương Trình";
            colMaNhomHangHoaCha.Caption = "Nhóm Chương Trình Cha";
        }
        #region Useful Method

        private void GetNhomHHList_forCombo()
        {
            if(_kieu == 1)
                _NhomHangHoaBQ_VTAll_forCombo = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTListTheoLoaiVatTu(1);
            else 
                _NhomHangHoaBQ_VTAll_forCombo = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTListVatTuHangHoa();
            NhomHangHoaBQ_VT itemKhongChon = NhomHangHoaBQ_VT.NewNhomHangHoaBQ_VT();
            itemKhongChon.MaQuanLy = "<<Không chọn>>";
            itemKhongChon.TenNhomHangHoa = "<<Không chọn>>";
            _NhomHangHoaBQ_VTAll_forCombo.Insert(0, itemKhongChon);

            nhomHangHoaBQVTListAllBindingSource.DataSource = _NhomHangHoaBQ_VTAll_forCombo;
        }
        private void LoadData()
        {
            GetNhomHHList_forCombo();
            if (_kieu == 1)
            {
                _nhomHangHoaBQ_VTList_forGrid = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTListTheoLoaiVatTu(1);
                _loaiVatTuHHBQ_VTListAll = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHBanQuyenList();
                DinhDangLable();
            }
            else
            {
                _nhomHangHoaBQ_VTList_forGrid = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTListVatTuHangHoa();
                _loaiVatTuHHBQ_VTListAll = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHList();
            }
            bs_NhomHangHoaList.DataSource = _nhomHangHoaBQ_VTList_forGrid;
            grd_DSNhomHangHoa.DataSource = bs_NhomHangHoaList;
            //                    
            bs_LoaiVatTuHH.DataSource = _loaiVatTuHHBQ_VTListAll;
            //
            if (bs_NhomHangHoaList.Count == 0)
                btnThemMoi.PerformClick();
            else
                nhh = (NhomHangHoaBQ_VT)bs_NhomHangHoaList.Current;
        }
        #endregion

        private void XtraForm2_Load(object sender, EventArgs e)
        {
            Utils.GridUtils.SetSTTForGridView(gridView_DSNhomHangHoa, 35);
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                nhh = NhomHangHoaBQ_VT.NewNhomHangHoaBQ_VT();
                _nhomHangHoaBQ_VTList_forGrid.Insert(0, nhh);
                if (_kieu == 1)
                    nhh.MaLoaiVatTuHH = _loaiVatTuHHBQ_VTListAll[0].MaLoaiVatTuHH;
                txt_Manhomhanghoa.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView_DSNhomHangHoa.DeleteSelectedRows();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //_nhomHangHoaBQ_VTList_forGrid = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTList();
            //bs_NhomHangHoaList.DataSource = _nhomHangHoaBQ_VTList_forGrid;
            //grd_DSNhomHangHoa.DataSource = bs_NhomHangHoaList;
            LoadData();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _nhomHangHoaBQ_VTList_forGrid.ApplyEdit();
                bs_NhomHangHoaList.EndEdit();
                _nhomHangHoaBQ_VTList_forGrid.Save();
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetNhomHHList_forCombo();                
            }
            catch (Exception ex)
            {
                DialogUtil.ShowWarning("Không thể lưu!\n"+ ex.Message);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void XtraFrm_NhomHangHoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (nhh.IsDirty)
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

        private void btn_ExportDataExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridUtil.ExportToExcel(gridView: this.gridView_DSNhomHangHoa, showOpenFilePrompt: true);
        }
    }
}