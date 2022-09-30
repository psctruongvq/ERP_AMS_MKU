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
//04/04/2013
namespace PSC_ERP
{
    public partial class frmChiTietCCDCList : DevExpress.XtraEditors.XtraForm
    {
        long _maDoiTac;
        CCDC _congCuDungCu;
        private bool _formCCDC = false;


        #region Function
        private void InitializeForm()
        {
            ChiTietCCDCList_BindingSource.DataSource = typeof(ChiTietCCDCChildList);
            bs_QuocGiaList.DataSource = typeof(QuocGiaBQ_VTList);
            bs_DonViTinhList.DataSource = typeof(DonViTinhList);
            if (_formCCDC)
            {
                btn_Luu.Caption = "Lưu";
            }
        }

        private void InitializeGrdChitietCCDC()
        {
            HamDungChung.InitGridViewDev(gridView2, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView2, new string[] { "TenChiTiet", "SoHieu", "MaDVT", "NguyenGia", "SoLuong", "GiaTri", "MaQuocGiaSX", "NamSanXuat", "Model", "Serial", "GhiChu" },
                                new string[] { "Tên chi tiết", "Số hiệu", "ĐVT", "Nguyên giá", "Số lượng", "Giá trị", "Nước SX", "Năm SX", "Model", "Serial", "Ghi chú" },
                                             new int[] { 120, 90, 60, 100, 80, 100, 100, 75, 75, 75, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView2, new string[] { "TenChiTiet", "SoHieu", "MaDVT", "NguyenGia", "SoLuong", "GiaTri", "MaQuocGiaSX", "NamSanXuat", "Model", "Serial", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev(gridView2, new string[] { "NguyenGia", "SoLuong", "GiaTri" });
            HamDungChung.ShowSummaryFooterofColumnGridViewDev(gridView2, new string[] { "NguyenGia", "SoLuong", "GiaTri" });
            HamDungChung.NewRowGridViewDev(gridView2);

            Utils.GridUtils.SetSTTForGridView(gridView2, 30);//M
            //
            RepositoryItemGridLookUpEdit NuocSX_GrdLU = new RepositoryItemGridLookUpEdit();
            NuocSX_GrdLU.DataSource = bs_QuocGiaList;
            NuocSX_GrdLU.DisplayMember = "TenQuocGia";
            NuocSX_GrdLU.ValueMember = "MaQuocGia";
            HamDungChung.InitRepositoryItemGridLookUpDev(NuocSX_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(NuocSX_GrdLU, new string[] { "TenVietTat", "TenQuocGia" }, new string[] { "Tên viết tắt", "Tên quốc gia " }, new int[] { 100, 150 }, true);
            //
            //
            RepositoryItemGridLookUpEdit DVT_GrdLU = new RepositoryItemGridLookUpEdit();
            DVT_GrdLU.DataSource = bs_DonViTinhList;
            DVT_GrdLU.DisplayMember = "TenDonViTinh";
            DVT_GrdLU.ValueMember = "MaDonViTinh";
            HamDungChung.InitRepositoryItemGridLookUpDev(DVT_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DVT_GrdLU, new string[] { "TenDonViTinh" }, new string[] { "Tên ĐVT " }, new int[] { 150 }, true);
            //

            HamDungChung.RegisterControlFieldGridViewDev(gridView2, "MaQuocGiaSX", NuocSX_GrdLU);
            HamDungChung.RegisterControlFieldGridViewDev(gridView2, "MaDVT", DVT_GrdLU);

            HamDungChung.FormatNumberTypeofColumnGridViewDev(gridView2, new string[] { "NguyenGia", "SoLuong", "GiaTri" });

            gridView2.KeyDown += new System.Windows.Forms.KeyEventHandler(gridView2_KeyDown);
        }

        private void GetDataForBindingSource()
        {
            QuocGiaBQ_VTList _quocGiaList = QuocGiaBQ_VTList.GetQuocGiaBQ_VTList();
            QuocGiaBQ_VT qg = QuocGiaBQ_VT.NewQuocGiaBQ_VT("<<Không chọn>>");
            _quocGiaList.Insert(0, qg);
            bs_QuocGiaList.DataSource = _quocGiaList;

            DonViTinhList _donViTinhBQ_VTList = DonViTinhList.GetDonViTinhList();
            DonViTinh dvt = DonViTinh.NewDonViTinh(0, "<<Không chọn>>");
            _donViTinhBQ_VTList.Insert(0, dvt);
            bs_DonViTinhList.DataSource = _donViTinhBQ_VTList;
        }

        private void bindingData()
        {
            ChiTietCCDCChildList _chitietCCDCList = ChiTietCCDCChildList.NewChiTietCCDCChildList();
            if (_congCuDungCu.ChiTietCongCuDungCuList.Count == 0)
                _congCuDungCu.ChiTietCongCuDungCuList = ChiTietCCDCChildList.NewChiTietCCDCChildList();
            ChiTietCCDCList_BindingSource.DataSource = _congCuDungCu.ChiTietCongCuDungCuList;
        }

        private bool TestbeforeSave()
        {
            decimal tongNguyenGia = 0;
            foreach (ChiTietCCDCChild item in _congCuDungCu.ChiTietCongCuDungCuList)
            {
                tongNguyenGia += (item.SoLuong == 0 ? 1 : item.SoLuong) * item.NguyenGia;
            }
            if (tongNguyenGia > _congCuDungCu.NguyenGia)
            {
                MessageBox.Show("Tổng nguyên giá chi tiết không vượt quá nguyên giá CCDC", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion//Function
        //private void LockHopDong()
        //{
        //    grdv_ChiTietCCDCList.Columns["Check"].OptionsColumn.AllowEdit = false;

        //}
        //void UnLockHopDong()
        //{
        //    grdv_ChiTietCCDCList.Columns["Check"].OptionsColumn.AllowEdit = true;
        //}

        #region Events
        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.DeleteSelectedRowsGridViewDev(gridView2, e);

        }
        #endregion//Events


        public frmChiTietCCDCList()
        {
            InitializeComponent();
        }//

        public frmChiTietCCDCList(CCDC ccdc)
        {
            InitializeComponent();
            _congCuDungCu = ccdc;
            InitializeForm();
            bindingData();
            GetDataForBindingSource();
            InitializeGrdChitietCCDC();

        }//

        public frmChiTietCCDCList(CCDC ccdc, bool fromCCDC)
        {
            InitializeComponent();
            _formCCDC = fromCCDC;//
            if (_formCCDC)
                _congCuDungCu = CCDC.NewCongCuDungCu(true);
            _congCuDungCu = ccdc;
            InitializeForm();
            bindingData();
            GetDataForBindingSource();
            InitializeGrdChitietCCDC();

        }//



        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TestbeforeSave())
                this.Close();
        }//

        private void btn_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }//

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEdit_Focus.Focus();
            if (TestbeforeSave())
                #region Bo Sung
                if (_formCCDC)
                {
                    try
                    {
                        ChiTietCCDCList_BindingSource.EndEdit();
                        _congCuDungCu.ApplyEdit();
                        _congCuDungCu.Save();
                        MessageBox.Show("Cập Nhật Thành Công");
                    }
                    catch
                    {
                        MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                #endregion//Bo Sung
                    this.Close();
        }

        private void frmChiTietCCDCList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_formCCDC == false)//Bo sung
                if (TestbeforeSave())
                    e.Cancel = false;
                else
                    e.Cancel = true;
        }


    }
}