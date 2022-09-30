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
    public partial class frmCT_BangCanDoiKeToan1 : DevExpress.XtraEditors.XtraForm
    {
        CT_MauBangBaoCaoH CT_BangCanDoi1;
        CT_MauBangBaoCaoListH CT_BangCanDoi1List;

        BangCanDoiKeToanH bcdkt1;
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

        public frmCT_BangCanDoiKeToan1()
        {
        }

        public frmCT_BangCanDoiKeToan1(BangCanDoiKeToanH _BangCanDoiKeToan)
        {
            InitializeComponent();
            KhoiTaoControls(_BangCanDoiKeToan);
            //ResetForThemMoi();
        }

        public frmCT_BangCanDoiKeToan1(BangCanDoiKeToanH _BangCanDoiKeToan, string _flag, int indexRow)
        {
            InitializeComponent();
            KhoiTaoControls(_BangCanDoiKeToan);
            this.flag = _flag;
            this.intRowFocus = indexRow;

        }

        public frmCT_BangCanDoiKeToan1(BangKQHDKDH _BangKQHDKDH, string _flag, int indexRow)
        {
            InitializeComponent();
            KhoiTaoControls(_BangKQHDKDH);
            this.flag = _flag;
            this.intRowFocus = indexRow;
        }

        private void KhoiTaoControls(BangCanDoiKeToanH _BangCanDoiKeToan)
        {
            _loai = 1;
            CT_BangCanDoi1List = _BangCanDoiKeToan.CT_MauBangBaoCaoListH;
            tblCT_BangCanDoiKeToan1.DataSource = CT_BangCanDoi1List;

            bcdkt1 = _BangCanDoiKeToan;
            //_BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList(_loai, bcdkt1.MaThongTu);
            //bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;

            BangCanDoiKeToanListH _bangCanDoiList = BangCanDoiKeToanListH.GetBangCanDoiKeToanListH(_BangCanDoiKeToan.MaThongTu);
            _bangCanDoiList.Insert(0, BangCanDoiKeToanH.NewBangCanDoiKeToanH());
            bCKQHoatDongKinhDoanhListBindingSource.DataSource = _bangCanDoiList;

            HamDungChung.InitGridLookUpDev2(lueMucLienQuan, bCKQHoatDongKinhDoanhListBindingSource, "TenMucTaiKhoan", "MaMucTaiKhoan", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(lueMucLienQuan, new string[] { "MaMucTaiKhoan", "TenMucTaiKhoan", "MaSo", "ThuyetMinh", "MaMucTaiKhoanCha", "CapMuc" }, new string[] { "Mã mục tài khoản", "Tên mục tài khoản", "Mã số", "Thuyết minh", "Mã mục tài khoản cha", "Cấp mục" }, new int[] { 100, 150, 100, 100, 100, 100 }, false);

            //repositoryItemGridLookUpEdit1
            HamDungChung.InitRepositoryItemGridLookUpDev2(repositoryItemGridLookUpEdit1, bCKQHoatDongKinhDoanhListBindingSource, "TenMucTaiKhoan", "MaMucTaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(repositoryItemGridLookUpEdit1, new string[] { "MaMucTaiKhoan", "TenMucTaiKhoan" }, new string[] { "Mã mục tài khoản", "Tên mục tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gv_BangCanDoiKT1, "MaMucLienQuan", repositoryItemGridLookUpEdit1);
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

        private void KhoiTaoControls(BangKQHDKDH _BangKQHDKDH)
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

        public frmCT_BangCanDoiKeToan1(BangKQHDKDH _BangKQHDKDH)
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
                if (bcdkt1 != null)
                {
                    CT_BangCanDoi1 = CT_MauBangBaoCaoH.NewCT_MauBangBaoCaoH(0, _loai);
                    CT_BangCanDoi1.MaMuc = bcdkt1.MaMucTaiKhoan;
                    //CT_BangCanDoi1List.Insert(0, CT_BangCanDoi1);
                    //gv_BangCanDoiKT1.MoveFirst();
                    CT_BangCanDoi1List.Add(CT_BangCanDoi1);
                    gv_BangCanDoiKT1.MoveLast();
                    lueTaiKhoan.Focus();
                }
                else if (bkqhdkdh != null)
                {
                    CT_BangCanDoi1 = CT_MauBangBaoCaoH.NewCT_MauBangBaoCaoH(0, _loai);
                    CT_BangCanDoi1.MaMuc = bkqhdkdh.MaMuc;
                    //CT_BangCanDoi1List.Insert(0, CT_BangCanDoi1);
                    //gv_BangCanDoiKT1.MoveFirst();
                    CT_BangCanDoi1List.Add(CT_BangCanDoi1);
                    gv_BangCanDoiKT1.MoveLast();
                    lueTaiKhoan.Focus();
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
                _HeThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
                heThongTaiKhoan1ListBindingSource.DataSource = _HeThongTaiKhoanList;

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

                lueTaiKhoan.EditValue = 1;
                lueCongTru.EditValue = 1;
                lueLoai.EditValue = 1;
                lueMucLienQuan.EditValue = 1;
                lueTKDoiUng.EditValue = 1;
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

        private void DesignControls()
        {
            DesignHoatDong_gridLookUpEdit1();
            DesignKhoanMuc_gridLookUpEdit1();
        }
        #endregion Functions

        private void frmCT_BangCanDoiKeToan1_Load(object sender, EventArgs e)
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
                else if (flag == "THEM")
                {
                    ResetForThemMoi();
                    gc_BangCanDoiKT1.ForceInitialize();
                    gv_BangCanDoiKT1.FocusedRowHandle = CT_BangCanDoi1List.Count - 1;
                }
            }
            catch (Exception ex)
            {

            }

        }

    }
}
