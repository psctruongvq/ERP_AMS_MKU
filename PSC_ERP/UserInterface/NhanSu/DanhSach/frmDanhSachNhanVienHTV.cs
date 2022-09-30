using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
namespace PSC_ERP
{
    public partial class frmDanhSachNhanVienHTV : Form
    {
        #region Properties
        NhanVien_ThongTinList _list; 
        BoPhanList _boPhanList;
        string _boPhanString = "0";
        string _loaiNVString = "0";
        string _chucVuString = "0";
        string _trinhdohocvan = "0";
        string _trinhdotinhoc = "0";
        string _trinhdongoaingu = "0";
        string _trinhdoQLNN = "0";
        string _trinhdovanhoa = "0";
        string _trinhdoLLCT = "0";
        string _chuyenNganhDT = "0";
        string _trinhDoQLKT = "0";
        string _chungChi = "0";

        /// <summary>
        /// bô sung nhiều điều kiên vao
        /// </summary>
        ChuyenNganhDaoTaoClassList _chuyenNganhDaoTaoClassList;
        TrinhDoVanHoaList _trinhDoVanHoaList;
        TrinhDoTinHocClassList _trinhDoTinHocClassList;
        TrinhDoNgoaiNguClassList _trinhDoNgoaiNguClassList;
        QuanLyKinhTeList _quanLyKinhTeList;
        QuanLyNhaNuocList _quanLyNhaNuocList;
        LyLuanChinhTriList _lyLuanChinhTriList;
        NhanVien_ChungChiList _nhanVien_ChungChiList;
        TrinhDoHocVanClassList _trinhDoHocVanClassList;
        #endregion

        #region Loads
        public frmDanhSachNhanVienHTV()
        {
            InitializeComponent();
            this.bindingSource_ThongTinNhanVienList.DataSource = typeof(NhanVien_ThongTinList);
            this.bdLoaiNhanVien.DataSource = typeof(LoaiNhanVienList);
            this.chucDanhListBindingSource.DataSource = typeof(ChucDanhList);
            this.bdBoPhan.DataSource = typeof(BoPhanList);
            //// A Long Bo Sung them
            this.ChuyenNganhDaoTaoListbindingSource.DataSource = typeof(ChuyenNganhDaoTaoClassList);
            this.TrinhDoVanHoaListbindingSource.DataSource = typeof(TrinhDoVanHoaList);
            this.ChuyenNganhDaoTaoListbindingSource.DataSource = typeof(ChuyenNganhDaoTaoClassList);
            this.TrinhDoHocVanListbindingSource.DataSource = typeof(TrinhDoHocVanClassList);
            this.TrinhDoTinHocListbindingSource.DataSource = typeof(TrinhDoTinHocClassList);
            this.TrinhDoNgoaiNguListbindingSource.DataSource = typeof(TrinhDoNgoaiNguClassList);
            this.TrinhDoQLKTListbindingSource.DataSource = typeof(QuanLyKinhTeList);
            this.TrinhDoQLKTNNListbindingSource.DataSource = typeof(QuanLyNhaNuocList);
            this.LyLuanCTListbindingSource.DataSource = typeof(LyLuanChinhTriList);
            this.ChungChiListbindingSource.DataSource = typeof(NhanVien_ChungChiList);

            _trinhDoHocVanClassList = TrinhDoHocVanClassList.GetTrinhDoHocVanClassList();
            TrinhDoHocVanClass tdhv = TrinhDoHocVanClass.NewTrinhDoHocVanClass(0, "Tất Cả");
            _trinhDoHocVanClassList.Insert(0, tdhv);
            TrinhDoHocVanListbindingSource.DataSource = _trinhDoHocVanClassList;
            cmbu_TrinhDoHocVan.DataSource = TrinhDoHocVanListbindingSource;

            _chuyenNganhDaoTaoClassList = ChuyenNganhDaoTaoClassList.GetChuyenNganhDaoTaoClassList();
            ChuyenNganhDaoTaoClass cndt = ChuyenNganhDaoTaoClass.NewChuyenNganhDaoTaoClass(0, "Tất Cả");
            _chuyenNganhDaoTaoClassList.Insert(0, cndt);
            ChuyenNganhDaoTaoListbindingSource.DataSource = _chuyenNganhDaoTaoClassList;
            cmbu_ChuyenNganhDT.DataSource = _chuyenNganhDaoTaoClassList;

            _trinhDoVanHoaList = TrinhDoVanHoaList.GetTrinhDoVanHoaList();
            TrinhDoVanHoa tdvh = TrinhDoVanHoa.NewTrinhDoVanHoa();
            _trinhDoVanHoaList.Insert(0, tdvh);
            TrinhDoVanHoaListbindingSource.DataSource = _trinhDoVanHoaList;
            cmbu_TrinhDoVanHoa.DataSource = TrinhDoVanHoaListbindingSource;

            _trinhDoTinHocClassList = TrinhDoTinHocClassList.GetTrinhDoTinHocClassList();
            TrinhDoTinHocClass tdth = TrinhDoTinHocClass.NewTrinhDoTinHocClass(0, "Tất Cả");
            _trinhDoTinHocClassList.Insert(0, tdth);
            TrinhDoTinHocListbindingSource.DataSource = _trinhDoTinHocClassList;
            cmbu_TrinhDoTinHoc.DataSource = _trinhDoTinHocClassList;

            _trinhDoNgoaiNguClassList = TrinhDoNgoaiNguClassList.GetTrinhDoNgoaiNguClassList();
            TrinhDoNgoaiNguClass tdnn = TrinhDoNgoaiNguClass.NewTrinhDoNgoaiNguClass(0, "Tất Cả");
            _trinhDoNgoaiNguClassList.Insert(0, tdnn);
            TrinhDoNgoaiNguListbindingSource.DataSource = _trinhDoNgoaiNguClassList;
            cmbu_TrinhDoNgoaiNgu.DataSource = _trinhDoNgoaiNguClassList;


            _quanLyKinhTeList = QuanLyKinhTeList.GetQuanLyKinhTeList();
            QuanLyKinhTe qlkt = QuanLyKinhTe.NewQuanLyKinhTe(0, "Tất Cả");
            _quanLyKinhTeList.Insert(0, qlkt);
            TrinhDoQLKTListbindingSource.DataSource = _quanLyKinhTeList;
            cmbu_TrinhDoQuanLy.DataSource = _quanLyKinhTeList;

            _quanLyNhaNuocList = QuanLyNhaNuocList.GetQuanLyNhaNuocList();
            QuanLyNhaNuoc qlnn = QuanLyNhaNuoc.NewQuanLyNhaNuoc(0, "Tất Cả");
            _quanLyNhaNuocList.Insert(0, qlnn);
            TrinhDoQLKTNNListbindingSource.DataSource = _quanLyNhaNuocList;
            cmbu_TrinhDoQLNN.DataSource = _quanLyNhaNuocList;

            _lyLuanChinhTriList = LyLuanChinhTriList.GetLyLuanChinhTriList();
            LyLuanChinhTri llct = LyLuanChinhTri.NewLyLuanChinhTri(0, "Tất Cả");
            _lyLuanChinhTriList.Insert(0, llct);
            LyLuanCTListbindingSource.DataSource = _lyLuanChinhTriList;
            cmbu_LyLuanCT.DataSource = LyLuanCTListbindingSource;

            _nhanVien_ChungChiList = NhanVien_ChungChiList.GetNhanVien_ChungChiList(0);
            NhanVien_ChungChi nncc = NhanVien_ChungChi.NewNhanVien_ChungChi();
            _nhanVien_ChungChiList.Insert(0, nncc);
            ChungChiListbindingSource.DataSource = _nhanVien_ChungChiList;
            cmbu_ChungChi.DataSource = ChungChiListbindingSource;

            //////ket thuc A Long Bo sung the
            this.grdTinhThanh.DataSource = this.bindingSource_ThongTinNhanVienList;
            _list = NhanVien_ThongTinList.GetNhanVien_ThongTinList(_boPhanString, _chucVuString, _loaiNVString, _trinhdohocvan, _trinhdotinhoc, _trinhdongoaingu, _trinhdoQLNN, _trinhdovanhoa, _trinhdoLLCT, _chuyenNganhDT, _trinhDoQLKT, _chungChi);
            this.bindingSource_ThongTinNhanVienList.DataSource = _list;
            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan bp = BoPhan.NewBoPhan("Tất Cả");
            _boPhanList.Insert(0, bp);
            bdBoPhan.DataSource = _boPhanList;
            LoaiNhanVienList lnv = LoaiNhanVienList.GetLoaiNhanVienList();
            LoaiNhanVienChild item = LoaiNhanVienChild.NewLoaiNhanVienChild("Tất Cả");
            lnv.Insert(0, item);
            bdLoaiNhanVien.DataSource = lnv;
            ChucDanhList cvl = ChucDanhList.GetChucDanhList();
            ChucDanh cv = ChucDanh.NewChucDanh(0, "Tất Cả");
            cvl.Insert(0, cv);
            chucDanhListBindingSource.DataSource = cvl;

            ((ICheckedItemList)cbBoPhan).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(cbBoPhan_CheckStateChanged);
            ((ICheckedItemList)cbLoaiNV).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(cbLoaiNV_CheckStateChanged);
            ((ICheckedItemList)cbChucDanh).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(cbChucVu_CheckStateChanged);

            ((ICheckedItemList)cmbu_TrinhDoHocVan).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(cmbu_TrinhDoHocVan_CheckStateChanged);
            ((ICheckedItemList)cmbu_TrinhDoTinHoc).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(cmbu_TrinhDoTinHoc_CheckStateChanged);
            ((ICheckedItemList)cmbu_TrinhDoNgoaiNgu).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(cmbu_TrinhDoNgoaiNgu_CheckStateChanged);
            ((ICheckedItemList)cmbu_TrinhDoQLNN).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(cmbu_TrinhDoQLNN_CheckStateChanged);
            ((ICheckedItemList)cmbu_TrinhDoVanHoa).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(cmbu_TrinhDoVanHoa_CheckStateChanged);
            ((ICheckedItemList)cmbu_LyLuanCT).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(cmbu_LyLuanCT_CheckStateChanged);
            ((ICheckedItemList)cmbu_ChuyenNganhDT).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(cmbu_ChuyenNganhDT_CheckStateChanged);
            ((ICheckedItemList)cmbu_TrinhDoQuanLy).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(cmbu_TrinhDoQuanLy_CheckStateChanged);
            ((ICheckedItemList)cmbu_ChungChi).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(cmbu_ChungChi_CheckStateChanged);
        }

        private void ultraCombo_ChuyenNganhDT_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cmbu_ChuyenNganhDT, "ChuyenNganhDaoTao");
            foreach (UltraGridColumn col in this.cmbu_ChuyenNganhDT.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cmbu_ChuyenNganhDT.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_ChuyenNganhDT.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản";
            cmbu_ChuyenNganhDT.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;

            cmbu_ChuyenNganhDT.DisplayLayout.Bands[0].Columns["ChuyenNganhDaoTao"].Hidden = false;
            cmbu_ChuyenNganhDT.DisplayLayout.Bands[0].Columns["ChuyenNganhDaoTao"].Header.Caption = "Tên CN Đào Tao";
            cmbu_ChuyenNganhDT.DisplayLayout.Bands[0].Columns["ChuyenNganhDaoTao"].Header.VisiblePosition = 2;

            cmbu_ChuyenNganhDT.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cmbu_ChuyenNganhDT.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cmbu_ChuyenNganhDT.CheckedListSettings.CheckStateMember = checkColumn.Key;
        }

        private void ultraCombo_TrinhDoTinHoc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cmbu_TrinhDoTinHoc, "TrinhDoTinHoc");
            foreach (UltraGridColumn col in this.cmbu_TrinhDoTinHoc.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cmbu_TrinhDoTinHoc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_TrinhDoTinHoc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã ";
            cmbu_TrinhDoTinHoc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;

            cmbu_TrinhDoTinHoc.DisplayLayout.Bands[0].Columns["TrinhDoTinHoc"].Hidden = false;
            cmbu_TrinhDoTinHoc.DisplayLayout.Bands[0].Columns["TrinhDoTinHoc"].Header.Caption = "Tên Trình Độ Tin Học";
            cmbu_TrinhDoTinHoc.DisplayLayout.Bands[0].Columns["TrinhDoTinHoc"].Header.VisiblePosition = 2;

            cmbu_TrinhDoTinHoc.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cmbu_TrinhDoTinHoc.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cmbu_TrinhDoTinHoc.CheckedListSettings.CheckStateMember = checkColumn.Key;
        }

        private void ultraCombo_TrinhDoNgoaiNgu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cmbu_TrinhDoNgoaiNgu, "TrinhDoNgoaiNgu");
            foreach (UltraGridColumn col in this.cmbu_TrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cmbu_TrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_TrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã ";
            cmbu_TrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;

            cmbu_TrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns["TrinhDoNgoaiNgu"].Hidden = false;
            cmbu_TrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns["TrinhDoNgoaiNgu"].Header.Caption = "Tên Trình Độ Ngoại Ngữ";
            cmbu_TrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns["TrinhDoNgoaiNgu"].Header.VisiblePosition = 2;

            cmbu_TrinhDoNgoaiNgu.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cmbu_TrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cmbu_TrinhDoNgoaiNgu.CheckedListSettings.CheckStateMember = checkColumn.Key;


        }

        private void ultraCombo_TrinhDoQuanLy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cmbu_TrinhDoQuanLy, "TenQuanLyKinhTe");
            foreach (UltraGridColumn col in this.cmbu_TrinhDoQuanLy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cmbu_TrinhDoQuanLy.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_TrinhDoQuanLy.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã ";
            cmbu_TrinhDoQuanLy.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;

            cmbu_TrinhDoQuanLy.DisplayLayout.Bands[0].Columns["TenQuanLyKinhTe"].Hidden = false;
            cmbu_TrinhDoQuanLy.DisplayLayout.Bands[0].Columns["TenQuanLyKinhTe"].Header.Caption = "Tên Quản lý Kinh Tế";
            cmbu_TrinhDoQuanLy.DisplayLayout.Bands[0].Columns["TenQuanLyKinhTe"].Header.VisiblePosition = 2;

            cmbu_TrinhDoQuanLy.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cmbu_TrinhDoQuanLy.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cmbu_TrinhDoQuanLy.CheckedListSettings.CheckStateMember = checkColumn.Key;
        }

        private void ultraCombo_TrinhDoQLNN_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cmbu_TrinhDoQLNN, "TenQuanLyNhaNuoc");
            foreach (UltraGridColumn col in this.cmbu_TrinhDoQLNN.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cmbu_TrinhDoQLNN.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_TrinhDoQLNN.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã ";
            cmbu_TrinhDoQLNN.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;

            cmbu_TrinhDoQLNN.DisplayLayout.Bands[0].Columns["TenQuanLyNhaNuoc"].Hidden = false;
            cmbu_TrinhDoQLNN.DisplayLayout.Bands[0].Columns["TenQuanLyNhaNuoc"].Header.Caption = "Tên QL KT Nhà Nước";
            cmbu_TrinhDoQLNN.DisplayLayout.Bands[0].Columns["TenQuanLyNhaNuoc"].Header.VisiblePosition = 2;

            cmbu_TrinhDoQLNN.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cmbu_TrinhDoQLNN.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cmbu_TrinhDoQLNN.CheckedListSettings.CheckStateMember = checkColumn.Key;
        }

        private void ultraCombo_LyLuanCT_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cmbu_LyLuanCT, "LyLuanCT");
            foreach (UltraGridColumn col in this.cmbu_LyLuanCT.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cmbu_LyLuanCT.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_LyLuanCT.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã ";
            cmbu_LyLuanCT.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;

            cmbu_LyLuanCT.DisplayLayout.Bands[0].Columns["LyLuanCT"].Hidden = false;
            cmbu_LyLuanCT.DisplayLayout.Bands[0].Columns["LyLuanCT"].Header.Caption = "Tên Lý Luận Chính Trị";
            cmbu_LyLuanCT.DisplayLayout.Bands[0].Columns["LyLuanCT"].Header.VisiblePosition = 2;

            cmbu_LyLuanCT.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cmbu_LyLuanCT.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cmbu_LyLuanCT.CheckedListSettings.CheckStateMember = checkColumn.Key;
        }

        private void ultraCombo_ChungChi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cmbu_ChungChi, "TenChungChi");
            foreach (UltraGridColumn col in this.cmbu_ChungChi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }

            cmbu_ChungChi.DisplayLayout.Bands[0].Columns["TenChungChi"].Hidden = false;
            cmbu_ChungChi.DisplayLayout.Bands[0].Columns["TenChungChi"].Header.Caption = "Tên Chúng Chỉ";
            cmbu_ChungChi.DisplayLayout.Bands[0].Columns["TenChungChi"].Header.VisiblePosition = 2;

            cmbu_ChungChi.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cmbu_ChungChi.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cmbu_ChungChi.CheckedListSettings.CheckStateMember = checkColumn.Key;
        }

        private void ultraCombo_TrinhDoHocVan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cmbu_TrinhDoHocVan, "TrinhDoHocVan");
            foreach (UltraGridColumn col in this.cmbu_TrinhDoHocVan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }

            cmbu_TrinhDoHocVan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_TrinhDoHocVan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã TĐHV ";
            cmbu_TrinhDoHocVan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;

            cmbu_TrinhDoHocVan.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Hidden = false;
            cmbu_TrinhDoHocVan.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Header.Caption = "Tên Trình Độ Học Vấn";
            cmbu_TrinhDoHocVan.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Header.VisiblePosition = 2;

            cmbu_TrinhDoHocVan.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cmbu_TrinhDoHocVan.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cmbu_TrinhDoHocVan.CheckedListSettings.CheckStateMember = checkColumn.Key;
        }

        private void ultraCombo_TrinhDoVanHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cmbu_TrinhDoVanHoa, "TenTrinhVanHoa");
            foreach (UltraGridColumn col in this.cmbu_TrinhDoVanHoa.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }

            cmbu_TrinhDoVanHoa.DisplayLayout.Bands[0].Columns["TenTrinhVanHoa"].Hidden = false;
            cmbu_TrinhDoVanHoa.DisplayLayout.Bands[0].Columns["TenTrinhVanHoa"].Header.Caption = "Tên Trình Độ VH";
            cmbu_TrinhDoVanHoa.DisplayLayout.Bands[0].Columns["TenTrinhVanHoa"].Header.VisiblePosition = 2;

            cmbu_TrinhDoVanHoa.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cmbu_TrinhDoVanHoa.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cmbu_TrinhDoVanHoa.CheckedListSettings.CheckStateMember = checkColumn.Key;
        }

        private void grdTinhThanh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            foreach (UltraGridColumn col in this.grdTinhThanh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType == typeof(decimal))
                {
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (col.DataType == typeof(DateTime))
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 1;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaChucDanh"].Header.VisiblePosition = 2;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaChucDanh"].Header.Caption = "Mã Chức Danh";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenChucDanh"].Header.VisiblePosition = 3;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenChucDanh"].Header.Caption = "Tên Chức Danh";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaChucVu"].Header.VisiblePosition = 4;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaChucVu"].Header.Caption = "Mã Chức Vụ";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 5;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaQLBoPhan"].Header.VisiblePosition = 6;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaQLBoPhan"].Header.Caption = "Mã Đơn Vị";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 7;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Đơn Vị";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["GioiTinh"].Header.VisiblePosition = 8;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["GioiTinh"].Header.Caption = "Giới Tính";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["Cmnd"].Header.VisiblePosition = 9;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["Cmnd"].Header.Caption = "CMND";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["NgaySinh"].Header.VisiblePosition = 10;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["NgaySinh"].Header.Caption = "Ngày Sinh";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TinhThanhNoiSinh"].Header.VisiblePosition = 11;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TinhThanhNoiSinh"].Header.Caption = "Nơi Sinh";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["DanToc"].Header.VisiblePosition = 12;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["DanToc"].Header.Caption = "Dân Tộc";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenTonGiao"].Header.VisiblePosition = 13;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenTonGiao"].Header.Caption = "Tôn Giáo";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TinhTrang"].Header.VisiblePosition = 14;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TinhTrang"].Header.Caption = "Tình Trạng";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["NgayVaoNganh"].Header.VisiblePosition = 15;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["NgayVaoNganh"].Header.Caption = "Ngày Vào Đài";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["NgayTinhThamNien"].Header.VisiblePosition = 16;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["NgayTinhThamNien"].Header.Caption = "Ngày Bổ Nhiệm";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 17;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TheNhaBao"].Header.VisiblePosition = 18;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TheNhaBao"].Header.Caption = "Thẻ Nhà Báo";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 19;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "MSThuế";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["LoaiNhanVien"].Header.VisiblePosition = 20;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["LoaiNhanVien"].Header.Caption = "Loại NV";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TinhTrangHonNhan"].Header.VisiblePosition = 21;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TinhTrangHonNhan"].Header.Caption = "TT Hôn Nhân";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 22;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "Số TK";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.VisiblePosition = 23;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.Caption = "Ngân Hàng";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["NgachLuong"].Header.VisiblePosition = 24;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["NgachLuong"].Header.Caption = "Mã Ngạch";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenNgachLuong"].Header.VisiblePosition = 25;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenNgachLuong"].Header.Caption = "Tên Ngạch";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["BacLuong"].Header.VisiblePosition = 26;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["BacLuong"].Header.Caption = "Bậc Lương";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 27;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "HSL";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoVuotKhung"].Header.VisiblePosition = 28;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoVuotKhung"].Header.Caption = "%HSVK";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["MocLenLuong"].Header.VisiblePosition = 29;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MocLenLuong"].Header.Caption = "Mốc Lên Lương";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["NgachLuongBH"].Header.VisiblePosition = 30;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["NgachLuongBH"].Header.Caption = "Mã Ngạch BH";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenNgachLuongBH"].Header.VisiblePosition = 31;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenNgachLuongBH"].Header.Caption = "Tên Ngạch BH";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["BacLuongBH"].Header.VisiblePosition = 32;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["BacLuongBH"].Header.Caption = "Bậc BH";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoLuongBaoHiem"].Header.VisiblePosition = 33;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoLuongBaoHiem"].Header.Caption = "HSL BH";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["MocLenLuongBaoHiem"].Header.VisiblePosition = 34;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MocLenLuongBaoHiem"].Header.Caption = "Mốc LL BH";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoVuotKhungBH"].Header.VisiblePosition = 35;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoVuotKhungBH"].Header.Caption = "%HSVKBH";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoPhuCapChucVu"].Header.VisiblePosition = 36;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoPhuCapChucVu"].Header.Caption = "HSPC";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoLuongNoiBo"].Header.VisiblePosition = 37;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoLuongNoiBo"].Header.Caption = "HSNB";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoLuongBoSung"].Header.VisiblePosition = 38;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoLuongBoSung"].Header.Caption = "HSLBS";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoBu"].Header.VisiblePosition = 39;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoBu"].Header.Caption = "HSB";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Header.VisiblePosition = 40;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["HeSoDocHai"].Header.Caption = "HSĐH";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["PhuCapHC"].Header.VisiblePosition = 41;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["PhuCapHC"].Header.Caption = "PCHC";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["ChuyenNganhDaoTao"].Hidden = true;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["ChuyenNganhDaoTao"].Header.VisiblePosition = 42;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["ChuyenNganhDaoTao"].Header.Caption = "Chuyên Ngành";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Hidden = true;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Header.VisiblePosition = 43;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Header.Caption = "Học Vấn";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TrinhDoTinHoc"].Hidden = true;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TrinhDoTinHoc"].Header.VisiblePosition = 44;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TrinhDoTinHoc"].Header.Caption = "Tin Học";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenNgoaiNgu"].Hidden = true;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenNgoaiNgu"].Header.VisiblePosition = 45;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenNgoaiNgu"].Header.Caption = "Ngoại Ngữ";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TrinhDoNgoaiNgu"].Hidden = true;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TrinhDoNgoaiNgu"].Header.VisiblePosition = 46;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TrinhDoNgoaiNgu"].Header.Caption = "Trình Độ NN";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenQuanLyKinhTe"].Hidden = true;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenQuanLyKinhTe"].Header.VisiblePosition = 47;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenQuanLyKinhTe"].Header.Caption = "Quản Lý KT";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenQuanLyNhaNuoc"].Hidden = true;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenQuanLyNhaNuoc"].Header.VisiblePosition = 48;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenQuanLyNhaNuoc"].Header.Caption = "Quản Lý NN";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["LyLuanCT"].Header.VisiblePosition = 49;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["LyLuanCT"].Header.Caption = "Lý Luận CT";

            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenChungChi"].Hidden = true;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenChungChi"].Header.Caption = "Chứng Chỉ";
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenChungChi"].Header.VisiblePosition = 50;

        }

        private void cbBoPhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cbBoPhan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cbBoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cbBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cbBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
            cbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 200;
            cbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;

            cbBoPhan.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cbBoPhan.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cbBoPhan.CheckedListSettings.CheckStateMember = checkColumn.Key;

        }

        private void ultraCombo1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cbLoaiNV, "TenLoaiNhanVien");
            foreach (UltraGridColumn col in this.cbLoaiNV.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbLoaiNV.DisplayLayout.Bands[0].Columns["TenLoaiNhanVien"].Hidden = false;
            cbLoaiNV.DisplayLayout.Bands[0].Columns["TenLoaiNhanVien"].Header.Caption = "Tên Loại NV";
            cbLoaiNV.DisplayLayout.Bands[0].Columns["TenLoaiNhanVien"].Header.VisiblePosition = 1;


            cbLoaiNV.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cbLoaiNV.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cbLoaiNV.CheckedListSettings.CheckStateMember = checkColumn.Key;
        }

        private void cmbu_ChucVuMoi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cbChucDanh, "TenChucVu");
            foreach (UltraGridColumn col in this.cbChucDanh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbChucDanh.DisplayLayout.Bands[0].Columns["TenChucDanh"].Hidden = false;
            cbChucDanh.DisplayLayout.Bands[0].Columns["TenChucDanh"].Header.Caption = "Tên Chức Danh";
            cbChucDanh.DisplayLayout.Bands[0].Columns["TenChucDanh"].Header.VisiblePosition = 1;


            cbChucDanh.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cbChucDanh.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cbChucDanh.CheckedListSettings.CheckStateMember = checkColumn.Key;
        }
        #endregion

        #region Process
        #endregion

        #region Event
        void cbBoPhan_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _boPhanString = string.Empty;
            string boPhanString = string.Empty;
            if (cbBoPhan.ActiveRow != null)
            {
                for (int i = 0; i < cbBoPhan.CheckedRows.Count; i++)
                {
                    string s = cbBoPhan.CheckedRows[i].Cells["MaBoPhan"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cbBoPhan;
                        for (int j = 1; j < this.cbBoPhan.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    boPhanString += s + ",";
                }

                if (boPhanString.Length > 0)
                {
                    _boPhanString = boPhanString.Substring(0, boPhanString.Length - 1);
                }
                else
                    _boPhanString = "0";
            }
        }

        void cbLoaiNV_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _loaiNVString = string.Empty;
            string LoaiNhanVienString = string.Empty;
            if (cbLoaiNV.ActiveRow != null)
            {
                for (int i = 0; i < cbLoaiNV.CheckedRows.Count; i++)
                {
                    string s = cbLoaiNV.CheckedRows[i].Cells["MaLoaiNhanVien"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cbLoaiNV;
                        for (int j = 1; j < this.cbLoaiNV.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    LoaiNhanVienString += s + ",";
                }

                if (LoaiNhanVienString.Length > 0)
                {
                    _loaiNVString = LoaiNhanVienString.Substring(0, LoaiNhanVienString.Length - 1);
                }
                else
                    _loaiNVString = "0";
            }
        }

        void cbChucVu_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _chucVuString = string.Empty;
            string ChucVuString = string.Empty;
            if (cbChucDanh.ActiveRow != null)
            {
                for (int i = 0; i < cbChucDanh.CheckedRows.Count; i++)
                {
                    string s = cbChucDanh.CheckedRows[i].Cells["MaChucVu"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cbChucDanh;
                        for (int j = 1; j < this.cbChucDanh.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    ChucVuString += s + ",";
                }

                if (ChucVuString.Length > 0)
                {
                    _chucVuString = ChucVuString.Substring(0, ChucVuString.Length - 1);
                }
                else
                    _chucVuString = "0";
            }
        }

        void cmbu_TrinhDoHocVan_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _trinhdohocvan = string.Empty;
            string TrinhDoHocVan = string.Empty;
            if (cmbu_TrinhDoHocVan.ActiveRow != null)
            {
                for (int i = 0; i < cmbu_TrinhDoHocVan.CheckedRows.Count; i++)
                {
                    string s = cmbu_TrinhDoHocVan.CheckedRows[i].Cells["MaTrinhDoHocVan"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cmbu_TrinhDoHocVan;
                        for (int j = 1; j < this.cmbu_TrinhDoHocVan.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    TrinhDoHocVan += s + ",";
                }

                if (TrinhDoHocVan.Length > 0)
                {
                    _trinhdohocvan = TrinhDoHocVan.Substring(0, TrinhDoHocVan.Length - 1);
                }
                else
                    _trinhdohocvan = "0";
            }
        }

        void cmbu_TrinhDoTinHoc_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _trinhdotinhoc = string.Empty;
            string TrinhDoTinHoc = string.Empty;
            if (cmbu_TrinhDoTinHoc.ActiveRow != null)
            {
                for (int i = 0; i < cmbu_TrinhDoTinHoc.CheckedRows.Count; i++)
                {
                    string s = cmbu_TrinhDoTinHoc.CheckedRows[i].Cells["MaTrinhDoTH"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cmbu_TrinhDoHocVan;
                        for (int j = 1; j < this.cmbu_TrinhDoHocVan.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    TrinhDoTinHoc += s + ",";
                }

                if (TrinhDoTinHoc.Length > 0)
                {
                    _trinhdotinhoc = TrinhDoTinHoc.Substring(0, TrinhDoTinHoc.Length - 1);
                }
                else
                    _trinhdotinhoc = "0";
            }
        }

        void cmbu_ChungChi_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _chungChi = string.Empty;
            string ChungChi = string.Empty;
            if (cmbu_ChungChi.ActiveRow != null)
            {
                for (int i = 0; i < cmbu_ChungChi.CheckedRows.Count; i++)
                {
                    string s = cmbu_ChungChi.CheckedRows[i].Cells["ManhanvienChungchi"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cmbu_ChungChi;
                        for (int j = 1; j < this.cmbu_ChungChi.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    ChungChi += s + ",";
                }

                if (ChungChi.Length > 0)
                {
                    _chungChi = ChungChi.Substring(0, ChungChi.Length - 1);
                }
                else
                    _chungChi = "0";
            }
        }

        void cmbu_TrinhDoQuanLy_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _trinhDoQLKT = string.Empty;
            string TrinhDoQLKT = string.Empty;
            if (cmbu_TrinhDoQuanLy.ActiveRow != null)
            {
                for (int i = 0; i < cmbu_TrinhDoQuanLy.CheckedRows.Count; i++)
                {
                    string s = cmbu_TrinhDoQuanLy.CheckedRows[i].Cells["MaQuanLyKinhTe"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cmbu_TrinhDoQuanLy;
                        for (int j = 1; j < this.cmbu_TrinhDoQuanLy.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    TrinhDoQLKT += s + ",";
                }

                if (TrinhDoQLKT.Length > 0)
                {
                    _trinhDoQLKT = TrinhDoQLKT.Substring(0, TrinhDoQLKT.Length - 1);
                }
                else
                    _trinhDoQLKT = "0";
            }
        }

        void cmbu_ChuyenNganhDT_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _chuyenNganhDT = string.Empty;
            string ChuyenNganhDaoTao = string.Empty;
            if (cmbu_ChuyenNganhDT.ActiveRow != null)
            {
                for (int i = 0; i < cmbu_ChuyenNganhDT.CheckedRows.Count; i++)
                {
                    string s = cmbu_ChuyenNganhDT.CheckedRows[i].Cells["MaChuyenNganhDaoTao"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cmbu_ChuyenNganhDT;
                        for (int j = 1; j < this.cmbu_ChuyenNganhDT.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    ChuyenNganhDaoTao += s + ",";
                }

                if (ChuyenNganhDaoTao.Length > 0)
                {
                    _chuyenNganhDT = ChuyenNganhDaoTao.Substring(0, ChuyenNganhDaoTao.Length - 1);
                }
                else
                    _chuyenNganhDT = "0";
            }
        }

        void cmbu_LyLuanCT_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _trinhdoLLCT = string.Empty;
            string TrinhDoLLCT = string.Empty;
            if (cmbu_LyLuanCT.ActiveRow != null)
            {
                for (int i = 0; i < cmbu_LyLuanCT.CheckedRows.Count; i++)
                {
                    string s = cmbu_LyLuanCT.CheckedRows[i].Cells["MaLyLuanCT"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cmbu_LyLuanCT;
                        for (int j = 1; j < this.cmbu_LyLuanCT.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    TrinhDoLLCT += s + ",";
                }

                if (TrinhDoLLCT.Length > 0)
                {
                    _trinhdoLLCT = TrinhDoLLCT.Substring(0, TrinhDoLLCT.Length - 1);
                }
                else
                    _trinhdoLLCT = "0";
            }
        }

        void cmbu_TrinhDoVanHoa_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _trinhdovanhoa = string.Empty;
            string TrinhDoVanHoa = string.Empty;
            if (cmbu_TrinhDoVanHoa.ActiveRow != null)
            {
                for (int i = 0; i < cmbu_TrinhDoVanHoa.CheckedRows.Count; i++)
                {
                    string s = cmbu_TrinhDoVanHoa.CheckedRows[i].Cells["MaTrinhDoVanHoa"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cmbu_TrinhDoVanHoa;
                        for (int j = 1; j < this.cmbu_TrinhDoVanHoa.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    TrinhDoVanHoa += s + ",";
                }

                if (TrinhDoVanHoa.Length > 0)
                {
                    _trinhdovanhoa = TrinhDoVanHoa.Substring(0, TrinhDoVanHoa.Length - 1);
                }
                else
                    _trinhdovanhoa = "0";
            }
        }

        void cmbu_TrinhDoQLNN_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _trinhdoQLNN = string.Empty;
            string TrinhDoQLNN = string.Empty;
            if (cmbu_TrinhDoQLNN.ActiveRow != null)
            {
                for (int i = 0; i < cmbu_TrinhDoQLNN.CheckedRows.Count; i++)
                {
                    string s = cmbu_TrinhDoQLNN.CheckedRows[i].Cells["MaQuaLyNhaNuoc"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cmbu_TrinhDoQLNN;
                        for (int j = 1; j < this.cmbu_TrinhDoQLNN.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    TrinhDoQLNN += s + ",";
                }

                if (TrinhDoQLNN.Length > 0)
                {
                    _trinhdoQLNN = TrinhDoQLNN.Substring(0, TrinhDoQLNN.Length - 1);
                }
                else
                    _trinhdoQLNN = "0";
            }
        }

        void cmbu_TrinhDoNgoaiNgu_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _trinhdongoaingu = string.Empty;
            string TrinhDoNgoaiNgu = string.Empty;
            if (cmbu_TrinhDoNgoaiNgu.ActiveRow != null)
            {
                for (int i = 0; i < cmbu_TrinhDoNgoaiNgu.CheckedRows.Count; i++)
                {
                    string s = cmbu_TrinhDoNgoaiNgu.CheckedRows[i].Cells["MaTrinhDoNN"].Value.ToString();
                    if (s == "0")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cmbu_TrinhDoNgoaiNgu;
                        for (int j = 1; j < this.cmbu_TrinhDoNgoaiNgu.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    TrinhDoNgoaiNgu += s + ",";
                }

                if (TrinhDoNgoaiNgu.Length > 0)
                {
                    _trinhdongoaingu = TrinhDoNgoaiNgu.Substring(0, TrinhDoNgoaiNgu.Length - 1);
                }
                else
                    _trinhdongoaingu = "0";
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _list = NhanVien_ThongTinList.GetNhanVien_ThongTinList(_boPhanString, _chucVuString, _loaiNVString, _trinhdohocvan, _trinhdotinhoc, _trinhdongoaingu, _trinhdoQLNN, _trinhdovanhoa, _trinhdoLLCT, _chuyenNganhDT, _trinhDoQLKT, _chungChi);
            this.bindingSource_ThongTinNhanVienList.DataSource = _list;
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdTinhThanh);
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Xem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(_trinhdohocvan.ToString());
            _list = NhanVien_ThongTinList.GetNhanVien_ThongTinList(_boPhanString, _chucVuString, _loaiNVString, _trinhdohocvan, _trinhdotinhoc, _trinhdongoaingu, _trinhdoQLNN, _trinhdovanhoa, _trinhdoLLCT, _chuyenNganhDT, _trinhDoQLKT, _chungChi);
            this.bindingSource_ThongTinNhanVienList.DataSource = _list;
        }
        #endregion
    }
}
