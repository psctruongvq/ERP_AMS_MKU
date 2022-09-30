using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using ERP_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmCT_CongThucMauBieuBaoCao : DevExpress.XtraEditors.XtraForm
    {
        CT_MauBangBaoCaoH CT_BangCanDoi1 ;
        CT_MauBangBaoCaoListH CT_BangCanDoi1List = CT_MauBangBaoCaoListH.NewCT_MauBangBaoCaoListH();
       
        BangKQHDKDH bkqhdkdh;

        HeThongTaiKhoan1List _HeThongTaiKhoanList;
        BCKQHoatDongKinhDoanhList _BCKQHoatDongKinhDoanhList;
        private bool indicatorIcon = true;

        private byte _loai = 0;

        private byte _isNHNN = 0;//
        private int _maThongTu = 0;//
        public bool isSave = false;

        private string flag = "";   //goi them,xoa,sua tu form ben ngoai
        private int intRowFocus = 0;

        #region Properties
        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        BindingSource HoatDongList_bindingSource1 = new BindingSource();
        BindingSource CauTrucDoanhThuChiPhiList_bindingSource1 = new BindingSource();


        BindingSource tieuMucNganSachListBindingSource = new BindingSource();
        #endregion Properties

        public DataTable DTLueCongTru()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Value");
            dt.Columns.Add("Display");
            dt.Rows.Add("0", "");
            dt.Rows.Add("1", "Cộng");
            dt.Rows.Add("2", "Trừ");
            dt.Rows.Add("3", "Nhân");
            dt.Rows.Add("4", "Chia");
            return dt;
        }

        public DataTable DTLueLoai()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Value");
            dt.Columns.Add("Display");
            dt.Rows.Add("0", "");
            dt.Rows.Add("1", "Lấy theo số dư");
            dt.Rows.Add("2", "Lấy theo số phát sinh");
            dt.Rows.Add("3", "Lấy theo số dư đầu");
            return dt;
        }

        public DataTable DTNoCo()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Value");
            dt.Columns.Add("Display");
            dt.Rows.Add("0", "");
            dt.Rows.Add("1", "Nợ");
            dt.Rows.Add("2", "Có");
            return dt;
        }

        public frmCT_CongThucMauBieuBaoCao()
        {
            InitializeComponent();
        }

        public frmCT_CongThucMauBieuBaoCao(BangKQHDKDH _BangKQHDKDH, string _flag, int indexRow)
        {
            InitializeComponent();
            KhoiTaoControls(_BangKQHDKDH);
            this.flag = _flag;
            this.intRowFocus = indexRow;
        }

        private void KhoiTaoControls(BangKQHDKDH _BangKQHDKDH)
        {
            //InitializeComponent();
            _loai = _BangKQHDKDH.LoaiBaoCao;
            CT_BangCanDoi1List = _BangKQHDKDH.CT_MauBangBaoCaoListH;
            tblCT_BangCanDoiKeToan1.DataSource = CT_BangCanDoi1List;
            bkqhdkdh = _BangKQHDKDH;
            _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList(_loai, bkqhdkdh.MaThongTu);
            _BCKQHoatDongKinhDoanhList.Insert(0, BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh());
            bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;
            #region BS
            InitBindingSources();
            DesignControls();
            #endregion BS
            Ini();

            this.btnThemMoi.ItemClick += btnThemMoi_ItemClick;
            this.btnLuu.ItemClick += btnLuu_ItemClick;
            this.btnXoa.ItemClick += btnXoa_ItemClick;
            this.btnThoat.ItemClick += btnThoat_ItemClick;

            this.lueCongTru.TextChanged += lueCongTru_TextChanged;
            this.lueLoai.TextChanged += lueLoai_TextChanged;
            this.gv_BangCanDoiKT1.CustomDrawRowIndicator += gv_BangCanDoiKT1_CustomDrawRowIndicator;
            this.gv_BangCanDoiKT1.RowCountChanged += gv_BangCanDoiKT1_RowCountChanged;
            lueNoCo.TextChanged += lueNoCo_TextChanged;
        }

        void gv_BangCanDoiKT1_RowCountChanged(object sender, EventArgs e)
        {
            try
            {
                GridView gridview = ((GridView)sender);
                if (!gridview.GridControl.IsHandleCreated) return;
                Graphics gr = Graphics.FromHwnd(gridview.GridControl.Handle);
                SizeF size = gr.MeasureString(gridview.RowCount.ToString(), gridview.PaintAppearance.Row.GetFont());
                gridview.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 14;
            }
            catch
            {

            }
        }

        void gv_BangCanDoiKT1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                {
                    string sText = (e.RowHandle + 1).ToString();
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString(sText, e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    //e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    e.Info.DisplayText = sText;
                }
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;

                if (e.RowHandle == GridControl.InvalidRowHandle)
                {
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString("STT", e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Info.DisplayText = "STT";
                    e.Info.Appearance.Font = new Font(e.Info.Appearance.Font, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
            }
        }

        void lueNoCo_TextChanged(object sender, EventArgs e)
        {
            txtCol3.Text = lueNoCo.Text;

        }

        void lueLoai_TextChanged(object sender, EventArgs e)
        {
            txtCol2.Text = lueLoai.Text;

        }

        void lueCongTru_TextChanged(object sender, EventArgs e)
        {
            txtCol1.Text = lueCongTru.Text;

        }

        public frmCT_CongThucMauBieuBaoCao(BangKQHDKDH _BangKQHDKDH)
        {
            InitializeComponent();
            _loai = _BangKQHDKDH.LoaiBaoCao;
            CT_BangCanDoi1List = _BangKQHDKDH.CT_MauBangBaoCaoListH;
            tblCT_BangCanDoiKeToan1.DataSource = CT_BangCanDoi1List;
            bkqhdkdh = _BangKQHDKDH;
            _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList(_loai, bkqhdkdh.MaThongTu);
            _BCKQHoatDongKinhDoanhList.Insert(0, BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh());
            bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;
            #region BS
            InitBindingSources();
            DesignControls();
            #endregion BS
            Ini();

            this.btnThemMoi.ItemClick += btnThemMoi_ItemClick;
            this.btnLuu.ItemClick += btnLuu_ItemClick;
            this.btnXoa.ItemClick += btnXoa_ItemClick;
            this.btnThoat.ItemClick += btnThoat_ItemClick;

            this.lueCongTru.TextChanged += lueCongTru_TextChanged;
            this.lueLoai.TextChanged += lueLoai_TextChanged;
            this.gv_BangCanDoiKT1.CustomDrawRowIndicator += gv_BangCanDoiKT1_CustomDrawRowIndicator;
            this.gv_BangCanDoiKT1.RowCountChanged += gv_BangCanDoiKT1_RowCountChanged;
            lueNoCo.TextChanged += lueNoCo_TextChanged;
        }



        void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gv_BangCanDoiKT1.GetFocusedRow() != null)
            {
                gv_BangCanDoiKT1.DeleteSelectedRows();
            }
            else
            {
                MessageBox.Show("Vui Lòng chọn dòng cần xóa!");
            }
        }

        void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.isSave = true;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Không thể lưu");
            }
        }

        void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetForThemMoi();
        }

        private void ResetForThemMoi()
        {
            try
            {
                if (bkqhdkdh != null)
                {
                    CT_BangCanDoi1 = CT_MauBangBaoCaoH.NewCT_MauBangBaoCaoH(0, _loai);
                    CT_BangCanDoi1.MaMuc = bkqhdkdh.MaMuc;
                    //CT_BangCanDoi1List.Insert(0, CT_BangCanDoi1);
                    //gv_BangCanDoiKT1.MoveFirst();
                    CT_BangCanDoi1List.Add(CT_BangCanDoi1);
                    gv_BangCanDoiKT1.MoveLast();
                    MaTaiKhoangridLookUpEdit.Focus();
                    //lueTaiKhoan.Focus();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Ini()
        {
            try
            {
                gv_BangCanDoiKT1.OptionsBehavior.ReadOnly = true;
                //_HeThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
                HeThongTaiKhoan1List hethongTKDoiUngList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
                HeThongTaiKhoan1 tkEmpty = HeThongTaiKhoan1.NewHeThongTaiKhoan1("");
                hethongTKDoiUngList.Insert(0, tkEmpty);
                heThongTaiKhoan1ListBindingSource.DataSource = hethongTKDoiUngList;
                //_HeThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
                HeThongTaiKhoanChinhbindingSource.DataSource = hethongTKDoiUngList;

                tblLoai.DataSource = DTLueLoai();
                tblNoCo.DataSource = DTNoCo();
                tblCongTru.DataSource = DTLueCongTru();

                lueCongTru.Properties.DataSource = DTLueCongTru();
                lueCongTru.Properties.DisplayMember = "Display";
                lueCongTru.Properties.ValueMember = "Value";
                lueLoai.Properties.DataSource = DTLueLoai();
                lueLoai.Properties.DisplayMember = "Display";
                lueLoai.Properties.ValueMember = "Value";
                lueNoCo.Properties.DataSource = DTNoCo();
                lueNoCo.Properties.DisplayMember = "Display";
                lueNoCo.Properties.ValueMember = "Value";

                //lueTaiKhoan.EditValue = 1;
                lueCongTru.EditValue = 1;
                lueLoai.EditValue = 1;
                //lueMucLienQuan.EditValue = 1;
                //lueTKDoiUng.EditValue = 1;
                lueNoCo.EditValue = 1;

                repositoryItemGridLookUpEdit2Loai.DataSource = tblLoai;
                repositoryItemGridLookUpEdit2Loai.DisplayMember = "Display";
                repositoryItemGridLookUpEdit2Loai.ValueMember = "Value";
                repositoryItemGridLookUpEdit3NoCo.DataSource = tblNoCo;
                repositoryItemGridLookUpEdit3NoCo.DisplayMember = "Display";
                repositoryItemGridLookUpEdit3NoCo.ValueMember = "Value";
                repositoryItemGridLookUpEdit4CongTru.DataSource = tblCongTru;
                repositoryItemGridLookUpEdit4CongTru.DisplayMember = "Display";
                repositoryItemGridLookUpEdit4CongTru.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            //CT_BangCanDoi1List = CT_MauBangBaoCaoListH.GetCT_MauBangBaoCaoListH((bcdkt1.MaMucTaiKhoan),1);
            //tblCT_BangCanDoiKeToan1.DataSource = CT_BangCanDoi1List;
            //gc_BangCanDoiKT1.DataSource = tblCT_BangCanDoiKeToan1;

        }

        #region Functions
        private void InitBindingSources()
        {

            tieuMucNganSachListBindingSource.DataSource = typeof(TieuMucNganSachList);

            //7.TieuMucNganSachList
            TieuMucNganSachList tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList(); //ERP_Library.TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach tieuMucNganSach_KhongChon = TieuMucNganSach.NewTieuMucNganSach();
            tieuMucNganSach_KhongChon.MaQuanLy = "";
            tieuMucNganSach_KhongChon.TenTieuMuc = "<<None>>";
            tieuMucNganSachList.Insert(0, tieuMucNganSach_KhongChon);
            tieuMucNganSachListBindingSource.DataSource = tieuMucNganSachList;
            //HoatDongList

            HoatDongDevList hoatdonglist = HoatDongDevList.GetHoatDongDevList(_maCongTy);
            HoatDongDev hoatdongE = HoatDongDev.NewHoatDongDev();
            hoatdongE.TenHoatDong = "<<Không chọn>>";
            hoatdonglist.Insert(0, hoatdongE);
            HoatDongList_bindingSource1.DataSource = hoatdonglist;
            //CauTrucKhoanMucChiPhiList
            CauTrucDoanhThuChiPhiList khoanmuclist = CauTrucDoanhThuChiPhiList.GetCauTrucDoanhThuChiPhiList(_maCongTy);
            CauTrucDoanhThuChiPhi khoanmucE = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
            khoanmucE.Ten = "<<Không chọn>>";
            khoanmuclist.Insert(0, khoanmucE);
            CauTrucDoanhThuChiPhiList_bindingSource1.DataSource = khoanmuclist;
        }
        private void DesignHoatDong_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(HoatDong_gridLookUpEdit1, HoatDongList_bindingSource1, "TenHoatDong", "MaHoatDong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(HoatDong_gridLookUpEdit1, new string[] { "TenHoatDong", "MaQLHoatDong" }, new string[] { "Hoạt động", "Mã QL" }, new int[] { 120, 100 }, false);
            //HoatDong_gridLookUpEdit1.EditValueChanged += new System.EventHandler(this.HoatDong_gridLookUpEdit1_EditValueChanged);
        }

        private void DesignKhoanMuc_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(KhoanMuc_gridLookUpEdit1, CauTrucDoanhThuChiPhiList_bindingSource1, "Ten", "Id", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(KhoanMuc_gridLookUpEdit1, new string[] { "Ten", "MaQL" }, new string[] { "Khoản mục", "Mã QL" }, new int[] { 120, 100 }, false);
        }
        //MucLienQuan
        private void DesignMucLienQuangridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(MucLienQuangridLookUpEdit, bCKQHoatDongKinhDoanhListBindingSource, "TenMuc", "MaMuc", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(MucLienQuangridLookUpEdit, new string[] { "TenMuc", "MaSo" }, new string[] { "Mục", "Mã số " }, new int[] { 300, 100 }, true);
        }
        //MaTaiKhoanChinh
        private void DesignMaTaiKhoangridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(MaTaiKhoangridLookUpEdit, HeThongTaiKhoanChinhbindingSource, "SoHieuTK", "MaTaiKhoan", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(MaTaiKhoangridLookUpEdit, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 300 }, false);
        }
        //MaTKDoiUng
        private void DesignMaTKDoiUnggridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(MaTKDoiUnggridLookUpEdit, heThongTaiKhoan1ListBindingSource, "SoHieuTK", "MaTaiKhoan", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(MaTKDoiUnggridLookUpEdit, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] {"Số hiệu", "Tên tài khoản" }, new int[] { 100, 300 }, false);
        }

        //4.tieuMucNganSachListBindingSource
        private void DesignMaTieuMucgridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(MaTieuMucgridLookUpEdit, tieuMucNganSachListBindingSource, "MaQuanLy", "MaTieuMuc", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(MaTieuMucgridLookUpEdit, new string[] { "MaQuanLy", "TenTieuMuc" }, new string[] { "Mã", "Tên" }, new int[] { 100, 300 }, false);
        }
        private void DesignControls()
        {
            DesignMaTaiKhoangridLookUpEdit();
            DesignMaTKDoiUnggridLookUpEdit();
            DesignMucLienQuangridLookUpEdit();
            DesignHoatDong_gridLookUpEdit1();
            DesignKhoanMuc_gridLookUpEdit1();
            DesignMaTieuMucgridLookUpEdit();
        }
        #endregion Functions

        private void frmCT_CongThucMauBieuBaoCao_Load(object sender, EventArgs e)
        {
            try
            {
                if (flag == "SUA")  //sua cong thuc tu form mau bao cao can doi ke toan
                {
                    //gv_BangCanDoiKT1.OptionsSelection.MultiSelect = false;
                    //gv_BangCanDoiKT1.ClearSelection();
                    //gv_BangCanDoiKT1.FocusedRowHandle = this.intRowFocus;
                    //gv_BangCanDoiKT1.SelectRow(this.intRowFocus);
                    //gv_BangCanDoiKT1.EditingValue = this.CT_BangCanDoi1List[this.intRowFocus];
                    //gv_BangCanDoiKT1.SetFocusedValue(this.CT_BangCanDoi1List[this.intRowFocus]);

                    gc_BangCanDoiKT1.ForceInitialize();
                    gv_BangCanDoiKT1.FocusedRowHandle = this.intRowFocus;
                }
            }
            catch (Exception ex)
            {

            }

        }

    }
}
