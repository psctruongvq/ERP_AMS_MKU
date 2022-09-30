using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Common;
namespace PSC_ERP//cuong 30-10-2012
{
    public partial class frmTreeVT_HH_BQ_CCDC : XtraForm
    {//////////
        #region Field
        LoaiVatTuHHBQ_VTList _loaiVatTuHangHoaListAll_forTree = null;
        NhomHangHoaBQ_VTList _nhomHangHoaListAll_forTree = null;

        LoaiVatTuHHBQ_VTList _loaiVatTuHangHoaListAll_forGrid = null;
        NhomHangHoaBQ_VTList _nhomHangHoaList_forGrid = null;
        HangHoaBQ_VTList _hangHoaList_forGrid = null;
        CongCuDungCuList _congCuDungCuList_forGrid = null;
        CCDCList _congCuDungCuList_forGrid_1 = null;
        ChuongTrinhBanQuyenConList _chuongTrinhBanQuyenConList_forGrid = null;

        LoaiVatTuHHBQ_VTList _loaiVatTuHangHoaListAll_forCombo = null;
        NhomHangHoaBQ_VTList _nhomHangHoaListAll_forCombo = null;
        HangHoaBQ_VTList _hangHoaListAll_forCombo = null;
        HangHoaBQ_VT _CongCuDungCu = null;

        QuocGiaBQ_VTList _quocGiaListAll = null;
        QuocGiaBQ_VTList _CTBQCon_quocGiaListAll = null;

        BoPhanList _boPhanListAll = null;
        DonViTinhList _donViTinhListAll = null;
        bool _showLoai = true;
        bool _showNhom = true;
        bool _showHangHoa = true;
        byte _loai = 1;
        #endregion
        #region Constructor
        public frmTreeVT_HH_BQ_CCDC()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            using (DialogUtil.Wait())
            {
                this.LoadData();
                this.FillTree();
            }
            //try
            //{
            //    this.treeList1.SetFocusedNode(this.treeList1.Nodes[0]);
            //}
            //catch (System.Exception ex)
            //{
            //}
        }

        public void ShowHangHoaBanQuyen()
        {
            _loai = 1;
            this.LoadData();
            this.FillTree();
            this.tabPageCCDC.PageVisible = false;
            this.Show();
        }

        public void ShowHangHoaVatTu()
        {
            _loai = 2;
            this.LoadData();
            this.FillTree();
            this.tabPageChuongTrinhConBanQuyen.PageVisible = false;
            this.Show();
        }
        #endregion

        private void frmTreeVT_HH_BQ_CCDC_Load(object sender, EventArgs e)
        {
            this.RemoveShortCutCacMenuTrongTabPage();
            this.SetShortcutAndSuperToolTip_Loai();

            Utils.GridUtils.ConfigGridView(gridView_LoaiVatTuHangHoaListAll
                , setSTT: true
                , initCopyCell: true
                , multiSelectCell: true
                , multiSelectRow: false
                , initNewRowOnTop: false);
            Utils.GridUtils.ConfigGridView(gridView_NhomHangHoaList
                , setSTT: true
                , initCopyCell: true
                , multiSelectCell: true
                , multiSelectRow: false
                , initNewRowOnTop: false);
            Utils.GridUtils.ConfigGridView(gridView_LoaiVatTuHangHoaListAll
                , setSTT: true
                , initCopyCell: true
                , multiSelectCell: true
                , multiSelectRow: false
                , initNewRowOnTop: false);
            Utils.GridUtils.ConfigGridView(gridView_HangHoaList
                , setSTT: true
                , initCopyCell: true
                , multiSelectCell: true
                , multiSelectRow: false
                , initNewRowOnTop: false);
            Utils.GridUtils.ConfigGridView(gridView_CCDCCBList
                , setSTT: true
                , initCopyCell: true
                , multiSelectCell: true
                , multiSelectRow: false
                , initNewRowOnTop: false);
            Utils.GridUtils.ConfigGridView(gridViewCTConBQ
                            , setSTT: true
                            , initCopyCell: true
                            , multiSelectCell: true
                            , multiSelectRow: false
                            , initNewRowOnTop: false);
            //Utils.GridUtils.SetSTTForGridView(this.gridView_CCDCCBList, 35);
            //Utils.GridUtils.SetSTTForGridView(this.gridView_HangHoaList, 35);
            //Utils.GridUtils.SetSTTForGridView(this.gridView_LoaiVatTuHangHoaListAll, 35);
            //Utils.GridUtils.SetSTTForGridView(this.gridView_NhomHangHoaList, 35);
            GridUtil.DoubleClickHelper.Setup(this.gridView_CCDCCBList, (senderz1, ez1) =>
                                                                                             {
                                                                                                 GridView view = senderz1 as GridView;
                                                                                                 CCDC obj = view.GetFocusedRow() as CCDC;
                                                                                                 if (obj != null)
                                                                                                 {
                                                                                                     if (obj.LaCCDCCu == true)
                                                                                                     {
                                                                                                         XtraFrm_NhapCCDCCu frm = new XtraFrm_NhapCCDCCu(obj);
                                                                                                         if (frm.ShowDialog() == DialogResult.Yes)
                                                                                                         {
                                                                                                             _congCuDungCuList_forGrid_1 = CCDCList.GetCongCuDungCuListChuaThanhLy_By_MaHangHoa(_CongCuDungCu.MaHangHoa);
                                                                                                             CCDC_congCuDungCuCaBietListBindingSource_forGrid.DataSource = _congCuDungCuList_forGrid_1;                                                                                                          
                                                                                                             this.gridView_CCDCCBList.GroupPanelText = "Danh sách công cụ dụng cụ là con trực tiếp của hàng hóa: " + _CongCuDungCu.TenHangHoa;
                                                                                                         }
                                                                                                     }
                                                                                                     else
                                                                                                     {
                                                                                                         return;
                                                                                                     }
                                                                                                 }
                                                                                             });
        }
        #region Useful Method

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }

        private void LoadData()
        {
            if (_loai == 1)
            {
                _loaiVatTuHangHoaListAll_forGrid = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHBanQuyenList();
                _loaiVatTuHangHoaListAll_forCombo = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHBanQuyenList();
                //
                bs_DSHangHoaListAll.DataSource = typeof(HangHoaBQ_VTList);
                bs_DSHangHoaListAll.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
            }
            else
            {
                _loaiVatTuHangHoaListAll_forGrid = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHList();
                _loaiVatTuHangHoaListAll_forCombo = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHList();
            }
            Loai_LoaiVatTuHHBQ_VTListAllBindingSource_forGrid.DataSource = _loaiVatTuHangHoaListAll_forGrid;
            ///////////////////////////////////////////////////////////////////////////////////
            Nhom_loaiVatTuHHBQVTListAllBindingSource_forCombo.DataSource = _loaiVatTuHangHoaListAll_forCombo;
            //
            LoadData_OfNhomHH_forCombo();
            //
            _quocGiaListAll = QuocGiaBQ_VTList.GetQuocGiaBQ_VTList();
            QuocGiaBQ_VT quocGiaKhongChon1 = QuocGiaBQ_VT.NewQuocGiaBQ_VT("<<Không chọn>>");
            _quocGiaListAll.Insert(0, quocGiaKhongChon1);
            HH_QuocGiaListAllBindingSource_forCombo.DataSource = _quocGiaListAll;

            _CTBQCon_quocGiaListAll = QuocGiaBQ_VTList.GetQuocGiaBQ_VTList();
            QuocGiaBQ_VT quocGiaKhongChon2 = QuocGiaBQ_VT.NewQuocGiaBQ_VT("<<Không chọn>>");
            _CTBQCon_quocGiaListAll.Insert(0, quocGiaKhongChon2);
            CTBQ_QuocGiaListBindingSource.DataSource = _CTBQCon_quocGiaListAll;
            //
            _donViTinhListAll = DonViTinhList.GetDonViTinhList();
            HH_DonViTinhBQ_VTListAllBindingSource_forCombo.DataSource = _donViTinhListAll;
            //
            _boPhanListAll = BoPhanList.GetBoPhanListBy_All();
            CCDC_boPhanListAllBindingSource_forCombo.DataSource = _boPhanListAll;
            if (_loai == 1)
                _hangHoaListAll_forCombo = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
            else _hangHoaListAll_forCombo = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
            CCDC_hangHoaBQVTListBindingSource_forCombo.DataSource = _hangHoaListAll_forCombo;

            HeThongTaiKhoan1List danhSachTaiKhoan = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            HeThongTaiKhoan1 taiKhoan_KhongChon = HeThongTaiKhoan1.NewHeThongTaiKhoan1("<<Không chọn>>");
            danhSachTaiKhoan.Insert(0, taiKhoan_KhongChon);
            heThongTaiKhoan1ListKho_BindingSource.DataSource = danhSachTaiKhoan;
            heThongTaiKhoan1ListPhanBo_BindingSource.DataSource = danhSachTaiKhoan;
            heThongTaiKhoan1ListChoPhanBo_BindingSource.DataSource = danhSachTaiKhoan;
        }

        private void LoadData_OfNhomHH_forCombo()
        {
            if (_loai == 1)
                _nhomHangHoaListAll_forCombo = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTListTheoLoaiVatTu(1);
            else _nhomHangHoaListAll_forCombo = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTListVatTuHangHoa();
            NhomHangHoaBQ_VT nhomKhongChon = NhomHangHoaBQ_VT.NewNhomHangHoaBQ_VT();
            nhomKhongChon.MaQuanLy = "<<Không chọn>>";
            nhomKhongChon.TenNhomHangHoa = "<<Không chọn>>";
            _nhomHangHoaListAll_forCombo.Insert(0, nhomKhongChon);
            nhomHangHoaBQVTListAllBindingSource_forCombo.DataSource = _nhomHangHoaListAll_forCombo;
        }

        #endregion

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #region Tree

        private void FillTree()
        {
            if (_loai == 1)
            {
                _loaiVatTuHangHoaListAll_forTree = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHBanQuyenList();
                _nhomHangHoaListAll_forTree = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTListTheoLoaiVatTu(1);
            }
            else
            {
                _loaiVatTuHangHoaListAll_forTree = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHList();
                _nhomHangHoaListAll_forTree = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTListVatTuHangHoa();
            }
            this.treeList1.Nodes.Clear();
            if (_loaiVatTuHangHoaListAll_forTree != null && _loaiVatTuHangHoaListAll_forTree.Count > 0)
            {
                foreach (LoaiVatTuHHBQ_VT item in _loaiVatTuHangHoaListAll_forTree)
                {
                    //TreeListNode node = new TreeListNode();
                    TreeListNode parentForRootNode = null;
                    TreeListNode nodeLoai = this.treeList1.AppendNode(new Object[] { }, parentForRootNode);

                    nodeLoai.SetValue(this.colMa, item.MaQuanLy);
                    nodeLoai.SetValue(this.colTen, item.TenLoaiVatTuHH);
                    nodeLoai.SetValue(this.colGhiChu, "Loại");

                    nodeLoai.Tag = item;
                    nodeLoai.Visible = _showLoai;

                    if (LoaiVatTuHHBQ_VT.KiemTraNhom_CoTonTaiNhomHangHoaCon(item.MaLoaiVatTuHH))
                    {
                        TreeListNode tmpNode = treeList1.AppendNode(new Object[] { }, nodeLoai);
                        tmpNode.SetValue(this.colGhiChu, "TmpNodeSeXoaSauKhiExpand");

                        //nodeLoai.SetValue(colGhiChu, LoaiVatTuHHBQ_VT.DemNhomHangHoaCon(item.MaLoaiVatTuHH).ToString() + " Nhóm");
                    }
                }
            }
        }

        private void treeList1_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            using (DialogUtil.Wait())
            {
                if (e.Node.Tag is LoaiVatTuHHBQ_VT)
                {
                    if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].GetValue(this.colGhiChu).ToString() == "TmpNodeSeXoaSauKhiExpand")
                    {
                        e.Node.Nodes.Clear();
                        LoaiVatTuHHBQ_VT loai = e.Node.Tag as LoaiVatTuHHBQ_VT;
                        NhomHangHoaBQ_VTList nhomList = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTList_NhomCap1TheoLoai(loai.MaLoaiVatTuHH);
                        foreach (NhomHangHoaBQ_VT item in nhomList)
                        {
                            this.AddNhomVaoTree(e.Node, item);
                        }
                    }
                }
                else if (e.Node.Tag is NhomHangHoaBQ_VT)
                {
                    if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].GetValue(this.colGhiChu).ToString() == "TmpNodeSeXoaSauKhiExpand")
                    {
                        e.Node.Nodes.Clear();
                        NhomHangHoaBQ_VT nhomCha = e.Node.Tag as NhomHangHoaBQ_VT;
                        NhomHangHoaBQ_VTList nhomList = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTList_NhomTheoNhomCha(nhomCha.MaNhomHangHoa);

                        foreach (NhomHangHoaBQ_VT item in nhomList)
                        {
                            this.AddNhomVaoTree(e.Node, item);
                        }
                        //
                        HangHoaBQ_VTList hangHoaList = HangHoaBQ_VTList.GetHangHoaBQ_VTListByMaNhom(nhomCha.MaNhomHangHoa);
                        foreach (HangHoaBQ_VT item in hangHoaList)
                        {
                            this.AddHangHoaVaoTree(e.Node, item);
                        }
                    }
                }
                else if (e.Node.Tag is HangHoaBQ_VT)
                {
                    //if ((TimVeNodeLoai(e.Node).Tag as LoaiVatTuHHBQ_VT).MaLoaiVatTuHH == 1)
                    //{
                    //    this.tenChuongTrinhTextEdit.Tag
                    //}
                }
            }
        }

        private void AddNhomVaoTree(TreeListNode parentNode, NhomHangHoaBQ_VT nhom)
        {
            TreeListNode nodeNhom = this.treeList1.AppendNode(new Object[] { }, parentNode);
            nodeNhom.SetValue(this.colMa, nhom.MaQuanLy);
            nodeNhom.SetValue(this.colTen, nhom.TenNhomHangHoa);
            nodeNhom.SetValue(this.colGhiChu, "Nhóm");
            nodeNhom.Tag = nhom;
            nodeNhom.Visible = _showNhom;

            if (NhomHangHoaBQ_VT.KiemTraNhomHH_CoTonTaiNhomHHCon(nhom.MaNhomHangHoa) || NhomHangHoaBQ_VT.KiemTraNhomHH_CoTonTaiHangHoaCon(nhom.MaNhomHangHoa))
            {
                TreeListNode tmpNode = treeList1.AppendNode(new Object[] { }, nodeNhom);
                tmpNode.SetValue(this.colGhiChu, "TmpNodeSeXoaSauKhiExpand");
                //nodeNhom.SetValue(colGhiChu, NhomHangHoaBQ_VT.DemHangHoaCon(nhom.MaNhomHangHoa).ToString() + " Hàng hóa");
            }
        }
        private void AddHangHoaVaoTree(TreeListNode parentNode, HangHoaBQ_VT hangHoa)
        {
            TreeListNode nodeHangHoa = this.treeList1.AppendNode(new Object[] { }, parentNode);

            nodeHangHoa.SetValue(this.colMa, hangHoa.MaQuanLy);
            nodeHangHoa.SetValue(this.colTen, hangHoa.TenHangHoa);
            nodeHangHoa.SetValue(this.colGhiChu, "Hàng hóa");

            nodeHangHoa.Tag = hangHoa;
            nodeHangHoa.Visible = _showHangHoa;
        }

        private void treeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            //if (object.ReferenceEquals(e.Column, this.colGhiChu))//(object.ReferenceEquals(e.Column, this.colMa) || object.ReferenceEquals(e.Column, this.colTen))
            //{
            //    if (e.Node.Tag is LoaiVatTuHHBQ_VT)
            //    {
            //        e.Appearance.BackColor = Color.SkyBlue;
            //        e.Appearance.ForeColor = Color.Black;
            //        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            //    }
            //    else if (e.Node.Tag is NhomHangHoaBQ_VT)
            //    {
            //        e.Appearance.BackColor = Color.FromArgb(0x66, 0x94, 0xD0);
            //        e.Appearance.ForeColor = Color.White;
            //        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            //    }
            //    else if (e.Node.Tag is HangHoaBQ_VT)
            //    {
            //        e.Appearance.BackColor = Color.FromArgb(0x22, 0x76, 0xEC);
            //        e.Appearance.ForeColor = Color.White;

            //        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            //    }
            //}
        }

        private void btnRefreshTree_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (DialogUtil.Wait())
            {
                this.LoadData();
                this.FillTree();
            }
        }

        private void treeList1_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            btn_NhapCCDCCu.Visible = false;
            using (DialogUtil.Wait())
            {
                if (e.Node.Tag is LoaiVatTuHHBQ_VT)
                {
                    e.Node.Expanded = true;
                    LoaiVatTuHHBQ_VT loai = e.Node.Tag as LoaiVatTuHHBQ_VT;
                    //Doc nhom cap1 theo loai
                    {
                        this.tabPageNhom.PageEnabled = true;

                        _nhomHangHoaList_forGrid = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTList_NhomCap1TheoLoai(loai.MaLoaiVatTuHH);
                        Nhom_nhomHangHoaBQVTListBindingSource_forGrid.DataSource = _nhomHangHoaList_forGrid;
                        cbNhom_LoaiVatTuHH.Tag = loai;
                        cbNhom_NhomHangHoaCha.Tag = null;
                        this.gridView_NhomHangHoaList.GroupPanelText = "Danh sách nhóm là con trực tiếp của loại: " + loai.TenLoaiVatTuHH;
                    }
                    //
                    ClearHH();
                    ClearCCDC();
                    //clear CTBQCon
                    ClearCTBQCon();

                    this.xtraTabControl1.SelectedTabPage = this.tabPageNhom;
                }
                else if (e.Node.Tag is NhomHangHoaBQ_VT)
                {
                    e.Node.Expanded = true;
                    NhomHangHoaBQ_VT nhom = e.Node.Tag as NhomHangHoaBQ_VT;
                    //Doc nhom theo nhom cha
                    {
                        this.tabPageNhom.PageEnabled = true;

                        _nhomHangHoaList_forGrid = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTList_NhomTheoNhomCha(nhom.MaNhomHangHoa);
                        Nhom_nhomHangHoaBQVTListBindingSource_forGrid.DataSource = _nhomHangHoaList_forGrid;
                        cbNhom_LoaiVatTuHH.Tag = TimVeNodeLoai(e.Node).Tag;
                        cbNhom_NhomHangHoaCha.Tag = nhom;
                        this.gridView_NhomHangHoaList.GroupPanelText = "Danh sách nhóm là con trực tiếp của nhóm: " + nhom.TenNhomHangHoa;
                    }
                    //
                    ReadHH(nhom);
                    //clear CTBQCon
                    ClearCTBQCon();
                    ClearCCDC();
                    if (NhomHangHoaBQ_VT.KiemTraNhomHH_CoTonTaiNhomHHCon(nhom.MaNhomHangHoa))
                    {
                        this.xtraTabControl1.SelectedTabPage = this.tabPageNhom;
                    }
                    else
                    {
                        this.xtraTabControl1.SelectedTabPage = this.tabPageHangHoa;
                    }
                }
                else if (e.Node.Tag is HangHoaBQ_VT)
                {
                    //Clear nhom
                    ClearNhom();
                    //clear HH
                    ClearHH();
                    if ((TimVeNodeLoai(e.Node).Tag as LoaiVatTuHHBQ_VT).MaLoaiVatTuHH == 3)
                    {
                        HangHoaBQ_VT hangHoa = e.Node.Tag as HangHoaBQ_VT;
                        _CongCuDungCu = e.Node.Tag as HangHoaBQ_VT;
                        btn_NhapCCDCCu.Visible = true;
                        btn_NhapCCDCCu.Text = String.Format("Bạn có muốn nhập CCDC cũ cho [{0}]", hangHoa.TenHangHoa); ;
                        //doc cong cu dung cu chua thanh ly theo MaHangHoa
                        {
                            this.tabPageCCDC.PageEnabled = true;
                            //_congCuDungCuList_forGrid = CongCuDungCuList.GetCongCuDungCuListChuaThanhLy_By_MaHangHoa(hangHoa.MaHangHoa);
                            _congCuDungCuList_forGrid_1 = CCDCList.GetCongCuDungCuListChuaThanhLy_By_MaHangHoa(_CongCuDungCu.MaHangHoa);
                            CCDC_congCuDungCuCaBietListBindingSource_forGrid.DataSource = _congCuDungCuList_forGrid_1;
                            //CCDC_congCuDungCuListBindingSource_forGrid.DataSource = _congCuDungCuList_forGrid;
                            this.gridView_CCDCCBList.GroupPanelText = "Danh sách công cụ dụng cụ là con trực tiếp của hàng hóa: " + hangHoa.TenHangHoa;
                        }
                        this.xtraTabControl1.SelectedTabPage = this.tabPageCCDC;
                    }
                    else if ((TimVeNodeLoai(e.Node).Tag as LoaiVatTuHHBQ_VT).MaLoaiVatTuHH == 1)
                    {
                        HangHoaBQ_VT hangHoa = e.Node.Tag as HangHoaBQ_VT;
                        this.tenChuongTrinhTextEdit.Tag = hangHoa;
                        _chuongTrinhBanQuyenConList_forGrid = ChuongTrinhBanQuyenConList.GetChuongTrinhBanQuyenConList(hangHoa.MaHangHoa);
                        chuongTrinhBanQuyenConListBindingSource.DataSource = _chuongTrinhBanQuyenConList_forGrid;
                        this.gridViewCTConBQ.GroupPanelText = "Danh sách chương trình bản quyền con là con trực tiếp của hàng hóa: " + hangHoa.TenHangHoa;

                        this.tabPageChuongTrinhConBanQuyen.PageEnabled = true;
                        this.xtraTabControl1.SelectedTabPage = this.tabPageChuongTrinhConBanQuyen;
                    }
                }
            }
        }

        private void ClearCTBQCon()
        {
            tabPageChuongTrinhConBanQuyen.PageEnabled = false;
            _chuongTrinhBanQuyenConList_forGrid = ChuongTrinhBanQuyenConList.NewChuongTrinhBanQuyenConList();
            chuongTrinhBanQuyenConListBindingSource.DataSource = _chuongTrinhBanQuyenConList_forGrid;
        }
        private void ClearCCDC()
        {
            tabPageCCDC.PageEnabled = false;
            _congCuDungCuList_forGrid = CongCuDungCuList.NewCongCuDungCuList();
            CCDC_congCuDungCuListBindingSource_forGrid.DataSource = _congCuDungCuList_forGrid;
            _congCuDungCuList_forGrid_1 = CCDCList.NewCongCuDungCuList();
            this.gridView_CCDCCBList.GroupPanelText = "";
        }

        private void ClearNhom()
        {
            //hide tab page
            //this.tabNhom.PageVisible = false;
            this.tabPageNhom.PageEnabled = false;

            _nhomHangHoaList_forGrid = NhomHangHoaBQ_VTList.NewNhomHangHoaBQ_VTList();
            Nhom_nhomHangHoaBQVTListBindingSource_forGrid.DataSource = _nhomHangHoaList_forGrid;
            this.gridView_NhomHangHoaList.GroupPanelText = "";
            cbNhom_LoaiVatTuHH.Tag = null;
            cbNhom_NhomHangHoaCha.Tag = null;
        }

        private void ReadHH(NhomHangHoaBQ_VT nhom)
        {
            this.tabPageHangHoa.PageEnabled = true;
            _hangHoaList_forGrid = HangHoaBQ_VTList.GetHangHoaBQ_VTListByMaNhom(nhom.MaNhomHangHoa);
            HH_HangHoaBQ_VTListBindingSource_forGrid.DataSource = _hangHoaList_forGrid;
            this.gridView_HangHoaList.GroupPanelText = "Danh sách hàng hóa là con trực tiếp của nhóm: " + nhom.TenNhomHangHoa;
            cbHH_NhomHangHoa.Tag = nhom;
        }

        private void ClearHH()
        {
            //hide tab page
            //this.tabPageHangHoa.PageVisible = false;
            this.tabPageHangHoa.PageEnabled = false;

            _hangHoaList_forGrid = HangHoaBQ_VTList.NewHangHoaBQ_VTList();
            HH_HangHoaBQ_VTListBindingSource_forGrid.DataSource = _hangHoaList_forGrid;
            this.gridView_HangHoaList.GroupPanelText = "";
            cbHH_NhomHangHoa.Tag = null;
        }
        private TreeListNode TimVeNodeLoai(TreeListNode node)
        {
            TreeListNode returnValue = null;
            if (node != null)
            {
                if (node.Tag is LoaiVatTuHHBQ_VT)
                    returnValue = node;
                else
                {
                    returnValue = TimVeNodeLoai(node.ParentNode);
                }
            }

            return returnValue;
        }
        #endregion
        #region Nhom

        private void btnNhom_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn lưu danh sách loại", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                ChangeFocus();
                try
                {
                    Nhom_nhomHangHoaBQVTListBindingSource_forGrid.EndEdit();
                    _nhomHangHoaList_forGrid.ApplyEdit();
                    _nhomHangHoaList_forGrid.Save();
                    if ((DialogResult.OK == MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)))
                    {
                        try
                        {
                            int ml = 0;
                            ml = (this.cbNhom_LoaiVatTuHH.Tag as LoaiVatTuHHBQ_VT).MaLoaiVatTuHH;

                            int mnhhc = 0;
                            if (this.cbNhom_NhomHangHoaCha.Tag != null)
                                mnhhc = (this.cbNhom_NhomHangHoaCha.Tag as NhomHangHoaBQ_VT).MaNhomHangHoa;
                            foreach (NhomHangHoaBQ_VT item in _nhomHangHoaList_forGrid)
                            {

                                if (item.MaLoaiVatTuHH != ml || item.MaNhomHangHoaCha != mnhhc)
                                {

                                    //doc nhom hang hoa
                                    if (cbNhom_NhomHangHoaCha.Tag == null)
                                    {
                                        int maLoai = (this.cbNhom_LoaiVatTuHH.Tag as LoaiVatTuHHBQ_VT).MaLoaiVatTuHH;
                                        _nhomHangHoaList_forGrid = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTList_NhomCap1TheoLoai(maLoai);

                                    }
                                    else
                                    {

                                        _nhomHangHoaList_forGrid = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTList_NhomTheoNhomCha(mnhhc);

                                    }
                                    Nhom_nhomHangHoaBQVTListBindingSource_forGrid.DataSource = _nhomHangHoaList_forGrid;
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            DialogUtil.ShowError("Không lưu được!\n"+ ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không lưu được!\n"+ ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //
                LoadData_OfNhomHH_forCombo();
            }
        }


        private void btnNhom_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cbNhom_LoaiVatTuHH.Tag != null)
            {                
                NhomHangHoaBQ_VT nhom = NhomHangHoaBQ_VT.NewNhomHangHoaBQ_VT();
                nhom.MaLoaiVatTuHH = (cbNhom_LoaiVatTuHH.Tag as LoaiVatTuHHBQ_VT).MaLoaiVatTuHH;
                if (cbNhom_NhomHangHoaCha.Tag != null)
                {
                    nhom.MaNhomHangHoaCha = (cbNhom_NhomHangHoaCha.Tag as NhomHangHoaBQ_VT).MaNhomHangHoa;
                }
                _nhomHangHoaList_forGrid.Add(nhom);
                this.txtNhom_MaQuanLy.Focus();
            }
        }
        private void btnNhom_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView_NhomHangHoaList.SelectedRowsCount > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa nhóm đang chọn? Nếu xóa, sau đó cần bấm nút \"[" + btnNhom_Luu.Caption + "]\" để cập nhật thay đổi xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    this.gridView_NhomHangHoaList.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        #region Loai
        private void btnLoai_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoaiVatTuHHBQ_VT item = LoaiVatTuHHBQ_VT.NewLoaiVatTuHHBQ_VT();
            _loaiVatTuHangHoaListAll_forGrid.Insert(0, item);
            this.txtLoai_MaQuanLy.Focus();
        }

        private void btnLoai_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView_LoaiVatTuHangHoaListAll.SelectedRowsCount > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa loại đang chọn? Nếu xóa, sau đó cần bấm nút \"[" + btnLoai_Luu.Caption + "]\" để cập nhật thay đổi xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    this.gridView_LoaiVatTuHangHoaListAll.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLoai_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn lưu danh sách loại", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                ChangeFocus();
                try
                {
                    Loai_LoaiVatTuHHBQ_VTListAllBindingSource_forGrid.EndEdit();
                    _loaiVatTuHangHoaListAll_forGrid.ApplyEdit();
                    _loaiVatTuHangHoaListAll_forGrid.Save();
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không lưu được!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        #endregion

        #region HH
        private void btnHH_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView_HangHoaList.SelectedRowsCount > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa hàng hóa đang chọn? Nếu xóa, sau đó cần bấm nút \"[" + btnHH_Luu.Caption + "]\" để cập nhật thay đổi xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    this.gridView_HangHoaList.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHH_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cbHH_NhomHangHoa.Tag != null)
            {
                int maNhom = (cbHH_NhomHangHoa.Tag as NhomHangHoaBQ_VT).MaNhomHangHoa;
                if (NhomHangHoaBQ_VT.KiemTraNhomHH_CoTonTaiNhomHHCon(maNhom) == false)
                {
                    HangHoaBQ_VT item = HangHoaBQ_VT.NewHangHoaBQ_VT();
                    item.MaNhomHangHoa = maNhom;
                    {
                        int sizeOfNumber = 4;
                        string maQuanLyMoi = (cbHH_NhomHangHoa.Tag as NhomHangHoaBQ_VT).MaQuanLy + new String('0', sizeOfNumber - 1) + "1";
                        string maxMaQuanLy = HangHoaBQ_VT.Get_MaxMaQuanLy(maNhom, sizeOfNumber);
                        if (maxMaQuanLy != "Null")
                        {
                            int max = int.Parse(maxMaQuanLy.Substring(maxMaQuanLy.Length - sizeOfNumber, sizeOfNumber));
                            int soMoi = max + 1;
                            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();

                            maQuanLyMoi = (cbHH_NhomHangHoa.Tag as NhomHangHoaBQ_VT).MaQuanLy + stringSoMoi;
                        }
                        item.MaQuanLy = maQuanLyMoi;
                    }
                    _hangHoaList_forGrid.Insert(0, item);
                    this.txtHH_MaQuanLy.Focus();
                }
                else
                {
                    MessageBox.Show("Không được phép thêm mới hàng hóa ở vị trí này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnHH_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (KiemTraHopLeHangHoaTruocKhiLuu())
            {
                ChangeFocus();
                try
                {
                    HH_HangHoaBQ_VTListBindingSource_forGrid.EndEdit();
                    _hangHoaList_forGrid.ApplyEdit();
                    _hangHoaList_forGrid.Save();

                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    {
                        int mnhh = (this.cbHH_NhomHangHoa.Tag as NhomHangHoaBQ_VT).MaNhomHangHoa;
                        foreach (HangHoaBQ_VT item in _hangHoaList_forGrid)
                        {
                            if (item.MaNhomHangHoa != mnhh)
                            {
                                ReadHH(this.cbHH_NhomHangHoa.Tag as NhomHangHoaBQ_VT);
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không lưu được!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }            
        }

        private bool KiemTraHopLeHangHoaTruocKhiLuu()
        {
            bool hopLe = true;
            foreach (HangHoaBQ_VT item in _hangHoaList_forGrid)
            {
                ////kiem tra 4 ky tu cuoi phai la so
                //bool bonKyTuCuoiLaSo = false;
                //try
                //{
                //    int.Parse(item.MaQuanLy.Substring(item.MaQuanLy.Length - 4, 4));
                //    bonKyTuCuoiLaSo = true;
                //}
                //catch (System.Exception ex)
                //{
                //    hopLe = false;
                //    //bon ky tu cuoi khong phai la so
                //    MessageBox.Show("Mã hàng hóa: " + item.MaQuanLy + " không hợp lệ. Vui lòng nhập mã khác. Mã hàng hóa phải có 4 ký tự cuối là số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                if (HangHoaBQ_VT.KiemTraTrungMaQuanLy(item.MaHangHoa, item.MaQuanLy))
                {
                    hopLe = false;
                    MessageBox.Show("Mã hàng hóa: " + item.MaQuanLy + "đã tồn tại. Vui lòng nhập mã khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return hopLe;
        }
        #endregion

        //private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //this.LoadData();
        //    //this.FillTree();
        //}

        private void cbNhom_NhomHangHoaCha_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit = sender as LookUpEdit;
            try
            {
                int maNhom = (int)lookUpEdit.EditValue;
                int maLoai = (int)this.cbNhom_LoaiVatTuHH.EditValue;
                if (maNhom != 0 && maNhom != maLoai)
                {
                    NhomHangHoaBQ_VT nhom = NhomHangHoaBQ_VT.GetNhomHangHoaBQ_VT(maNhom);
                    this.cbNhom_LoaiVatTuHH.EditValue = nhom.MaLoaiVatTuHH;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void cbNhom_NhomHangHoaCha_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                NhomHangHoaBQ_VT current = Nhom_nhomHangHoaBQVTListBindingSource_forGrid.Current as NhomHangHoaBQ_VT;
                if ((int)e.NewValue == current.MaNhomHangHoa)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
            }
        }
        
        private void cbNhom_LoaiVatTuHH_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            int ml = (this.cbNhom_LoaiVatTuHH.Tag as LoaiVatTuHHBQ_VT).MaLoaiVatTuHH;
            if ((int)e.NewValue != ml)
            {
                this.cbNhom_NhomHangHoaCha.EditValue = 0;
                this.ChangeFocus();
            }
        }

       
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            RemoveShortCutCacMenuTrongTabPage();
            if (object.ReferenceEquals(xtraTabControl1.SelectedTabPage, this.tabPageLoai))
            {
                SetShortcutAndSuperToolTip_Loai();
            }
            else if (object.ReferenceEquals(xtraTabControl1.SelectedTabPage, this.tabPageNhom))
            {
                btnNhom_ThemMoi.ShortCut = Shortcut.CtrlN;
                btnNhom_ThemMoi.SuperTip = NewSuperToolTip("Ctrl+N", "", false, "");
                //
                btnNhom_Luu.ShortCut = Shortcut.CtrlS;
                btnNhom_Luu.SuperTip = NewSuperToolTip("Ctrl+S", "", false, "");

            }
            else if (object.ReferenceEquals(xtraTabControl1.SelectedTabPage, this.tabPageHangHoa))
            {
                btnHH_ThemMoi.ShortCut = Shortcut.CtrlN;
                btnHH_ThemMoi.SuperTip = NewSuperToolTip("Ctrl+N", "", false, "");
                //
                btnHH_Luu.ShortCut = Shortcut.CtrlS;
                btnHH_Luu.SuperTip = NewSuperToolTip("Ctrl+S", "", false, "");
            }
            else if (object.ReferenceEquals(xtraTabControl1.SelectedTabPage, this.tabPageChuongTrinhConBanQuyen))
            {
                btnChuongTrinhConBQ_Them.ShortCut = Shortcut.CtrlN;
                btnChuongTrinhConBQ_Them.SuperTip = NewSuperToolTip("Ctrl+N", "", false, "");
                //
                btnChuongTrinhConBQ_Luu.ShortCut = Shortcut.CtrlS;
                btnChuongTrinhConBQ_Luu.SuperTip = NewSuperToolTip("Ctrl+S", "", false, "");
            }
        }

        private void SetShortcutAndSuperToolTip_Loai()
        {
            btnLoai_ThemMoi.ShortCut = Shortcut.CtrlN;
            btnLoai_ThemMoi.SuperTip = NewSuperToolTip("Ctrl+N", "", false, "");
            //
            //
            btnLoai_Luu.ShortCut = Shortcut.CtrlS;//this.btnLoai_Luu.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            btnLoai_Luu.SuperTip = NewSuperToolTip("Ctrl+S", "", false, "");
        }

        private static DevExpress.Utils.SuperToolTip NewSuperToolTip(String title, String content, bool separator, String footer)
        {
            DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
            {
                if (string.IsNullOrEmpty(title) == false)
                {
                    DevExpress.Utils.ToolTipTitleItem toolTipTitleItem = new DevExpress.Utils.ToolTipTitleItem();
                    toolTipTitleItem.Text = title;
                    superToolTip.Items.Add(toolTipTitleItem);
                }
                //
                if (string.IsNullOrEmpty(content) == false)
                {
                    DevExpress.Utils.ToolTipItem toolTipItem = new DevExpress.Utils.ToolTipItem();
                    toolTipItem.LeftIndent = 6;
                    toolTipItem.Text = content;
                    superToolTip.Items.Add(toolTipItem);
                }
                //
                //
                if (string.IsNullOrEmpty(footer) == false)
                {
                    if (separator == true)
                    {
                        DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem = new DevExpress.Utils.ToolTipSeparatorItem();
                        superToolTip.Items.Add(toolTipSeparatorItem);
                    }
                    DevExpress.Utils.ToolTipTitleItem toolTipFooterItem = new DevExpress.Utils.ToolTipTitleItem();
                    toolTipFooterItem.LeftIndent = 6;
                    toolTipFooterItem.Text = footer;
                    superToolTip.Items.Add(toolTipFooterItem);
                }
            }
            return superToolTip;
        }

        private void RemoveShortCutCacMenuTrongTabPage()
        {
            btnLoai_ThemMoi.ShortCut = Shortcut.None;
            btnNhom_ThemMoi.ShortCut = Shortcut.None;
            btnHH_ThemMoi.ShortCut = Shortcut.None;
            //khong su dung phim tat voi nut xoa
            btnLoai_Xoa.ShortCut = Shortcut.None;
            btnNhom_Xoa.ShortCut = Shortcut.None;
            btnHH_Xoa.ShortCut = Shortcut.None;
            //
            this.btnLoai_Luu.ShortCut = Shortcut.None;
            this.btnNhom_Luu.ShortCut = Shortcut.None;
            this.btnHH_Luu.ShortCut = Shortcut.None;
            // 
            this.btnChuongTrinhConBQ_Them.ShortCut = Shortcut.None;
            this.btnChuongTrinhConBQ_Xoa.ShortCut = Shortcut.None;
            this.btnChuongTrinhConBQ_Luu.ShortCut = Shortcut.None;
        }

        private void gridView_LoaiVatTuHangHoaListAll_KeyDown(object sender, KeyEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.KeyCode == Keys.Delete)
            {

                if (gridView.SelectedRowsCount > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa trên lưới những dòng đang chọn? Nếu xóa, sau đó cần bấm nút" + this.btnLoai_Luu.Caption + " để lưu lại những thay đổi trên lưới xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        gridView.DeleteSelectedRows();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gridView_NhomHangHoaList_KeyDown(object sender, KeyEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView.SelectedRowsCount > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa trên lưới những dòng đang chọn? Nếu xóa, sau đó cần bấm nút" + this.btnNhom_Luu.Caption + " để lưu lại những thay đổi trên lưới xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        gridView.DeleteSelectedRows();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gridView_HangHoaList_KeyDown(object sender, KeyEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView.SelectedRowsCount > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa trên lưới những dòng đang chọn? Nếu xóa, sau đó cần bấm nút" + this.btnHH_Luu.Caption + " để lưu lại những thay đổi trên lưới xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        gridView.DeleteSelectedRows();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnChuongTrinhConBQ_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ChuongTrinhBanQuyenCon chuongTrinhBanQuyenCon = ChuongTrinhBanQuyenCon.NewChuongTrinhBanQuyenCon();
                _chuongTrinhBanQuyenConList_forGrid.Insert(0, chuongTrinhBanQuyenCon);
                HangHoaBQ_VT hh = this.tenChuongTrinhTextEdit.Tag as HangHoaBQ_VT;
                chuongTrinhBanQuyenCon.MaHangHoa = hh.MaHangHoa;
                chuongTrinhBanQuyenCon.MaQLChuongTrinhCon = ChuongTrinhBanQuyenCon.SetMaQuanLyChuongTrinhCon(hh.MaHangHoa, hh.MaQuanLy);
                this.gridViewCTConBQ.SelectRow(0);
                maQLChuongTrinhConTextEdit.Focus();
            }
            catch (Exception ex)
            {
                DialogUtil.ShowWarning(ex.Message);
            }
        }

        private void btnChuongTrinhConBQ_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridViewCTConBQ.SelectedRowsCount > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa chương trình con đang chọn? Nếu xóa, sau đó cần bấm nút \"[" + btnChuongTrinhConBQ_Luu.Caption + "]\" để cập nhật thay đổi xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    this.gridViewCTConBQ.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnChuongTrinhConBQ_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {//copy ben frm_ChuongTrinhConBanQuyen của Nụ, và sửa lại
            this.txtBlackHole.Focus();
            _chuongTrinhBanQuyenConList_forGrid.ApplyEdit();
            this.chuongTrinhBanQuyenConListBindingSource.EndEdit();

            bool dcContinue = false;
            foreach (var ctcon in _chuongTrinhBanQuyenConList_forGrid)
            {
                string maQuanLy = "";
                if (maQLChuongTrinhConTextEdit.EditValue != null)
                    maQuanLy = maQLChuongTrinhConTextEdit.EditValue.ToString().Trim();
                int lengthMaQL = maQuanLy.Length;
                int stt;

                if (gridViewCTConBQ.GetFocusedRow() != null)
                {
                    if (lengthMaQL >= 3 && int.TryParse(maQuanLy.Substring(lengthMaQL - 3, 3), out stt))//IF 2
                    {
                        dcContinue = true;
                    }
                    else
                    {
                        dcContinue = false;
                        MessageBox.Show("Mã Chương Trình Không Hợp Lệ! 3 ký tự cuối phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }
                }
                else
                {
                    dcContinue = true;
                }
            }
            if (dcContinue)
            {
                bool khongTrungMaQuanLy = true;
                foreach (var ctcon in _chuongTrinhBanQuyenConList_forGrid)
                {
                    if (ctcon.IsNew)
                    {
                        khongTrungMaQuanLy = ChuongTrinhBanQuyenCon.CheckMaQuanLyChuongTrinhKhongTrung(ctcon.MaChuongTrinhCon, ctcon.MaQLChuongTrinhCon, true);
                    }
                    else//k phai IS NEW
                    {
                        khongTrungMaQuanLy = ChuongTrinhBanQuyenCon.CheckMaQuanLyChuongTrinhKhongTrung(ctcon.MaChuongTrinhCon, ctcon.MaQLChuongTrinhCon, false);
                    }
                    if (khongTrungMaQuanLy == false)
                        break;

                }
                if (khongTrungMaQuanLy)//IF 5
                {
                    //GH
                    //B
                    try
                    {
                        _chuongTrinhBanQuyenConList_forGrid.Save();
                        MessageBox.Show(this, "Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        DialogUtil.ShowWarning("Không thể lưu!\n" + ex.Message);
                    }
                    //E
                }//END IF 5
                else
                {
                    MessageBox.Show("Trùng Mã Chương Trình ! Không Thể Lưu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }//END IF 2

        }

        private void btn_NhapCCDCCu_Click(object sender, EventArgs e)
        {
            XtraFrm_NhapCCDCCu frmNhapCCDCCu = new XtraFrm_NhapCCDCCu(_CongCuDungCu);
            if (frmNhapCCDCCu.ShowDialog() == DialogResult.OK)
            {
                _congCuDungCuList_forGrid = CongCuDungCuList.GetCongCuDungCuListChuaThanhLy_By_MaHangHoa(_CongCuDungCu.MaHangHoa);
                _congCuDungCuList_forGrid_1 = CCDCList.GetCongCuDungCuListChuaThanhLy_By_MaHangHoa(_CongCuDungCu.MaHangHoa);
                CCDC_congCuDungCuCaBietListBindingSource_forGrid.DataSource = _congCuDungCuList_forGrid_1;
                CCDC_congCuDungCuListBindingSource_forGrid.DataSource = _congCuDungCuList_forGrid;
                this.gridView_CCDCCBList.GroupPanelText = "Danh sách công cụ dụng cụ là con trực tiếp của hàng hóa: " + _CongCuDungCu.TenHangHoa;
            }
        }

        private void btn_Export_Tree_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList1.ExpandAll();
            //xuất excel cây danh mục
            TreeUtils.ExportToExcel(treeList: treeList1, showOpenFilePrompt: true);
        }

    }
}