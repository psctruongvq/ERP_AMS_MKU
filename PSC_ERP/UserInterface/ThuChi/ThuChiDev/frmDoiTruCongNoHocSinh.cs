using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;

namespace PSC_ERP
{
    public partial class frmDoiTruCongNoHocSinh : DevExpress.XtraEditors.XtraForm
    {
        List<GetHDChuaTTOrTTChuaHetForHocSinh> _HDTTHSList = new List<GetHDChuaTTOrTTChuaHetForHocSinh>();
        public List<GetHDChuaTTOrTTChuaHetForHocSinh> hdtthsListSelected
        {
            get { return _HDTTHSList; }

        }

        List<GetHocSinhDoiTru> _HSList = new List<GetHocSinhDoiTru>();
        public List<GetHocSinhDoiTru> hsListSelected
        {
            get { return _HSList; }
            set { _HSList = value; }

        }

        decimal _tongTienSumGridTT = 0;
        decimal _tongTienSumGridNCC = 0;

        private ChungTu _chungTu = ChungTu.NewChungTu();
        private ChungTu_HoaDonThanhToan CTHDTT;
        private ChungTu_HoaDonThanhToanChildList CTHDTTList;
        private TongHopDoiTruCongNoList _THDTCNList = TongHopDoiTruCongNoList.NewTongHopDoiTruCongNoList();
        private TongHopDoiTruCongNo _THDTCN = TongHopDoiTruCongNo.NewTongHopDoiTruCongNo();
        private bool _checkNCC = false;
        private bool _checkHocSinh = false;
        private decimal _tongTienHDTT;
        private List<long> listCheckTrungTien = new List<long>();
        private decimal _tongTienNCC;
        private decimal _tienThue;
        private int _loai = 2;
        private int _loaiDoiTac = 3;
        private DoiTacList _HocSinhList;
        private BindingSource hocSinhListBindingSource = new BindingSource();
        private BindingSource DSHSBindingSource = new BindingSource();
        private BindingSource DSHDTTHSBindingSource = new BindingSource();
        public frmDoiTruCongNoHocSinh()
        {
            InitializeComponent();
            this.Load += frmDoiTruCongNoHocSinh_Load;
            this.btnLuu.ItemClick += btnLuu_ItemClick;
            this.gridView1.CustomDrawFooterCell += gridView1_CustomDrawFooterCell;
            this.gridView2.CustomDrawFooterCell += gridView2_CustomDrawFooterCell;
            this.checkAll.EditValueChanged += checkAll_EditValueChanged;
            this.btnThoat.ItemClick += btnThoat_ItemClick;
            this.checkAllHD.EditValueChanged += checkAllHD_EditValueChanged;
            this.HocSinh_gridLookUpEdit.EditValueChanged += HocSinh_gridLookUpEdit_EditValueChanged;
        }

        void HocSinh_gridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            //gridControl1.DataSource = null;
            //gridControl2.DataSource = null;
            DSHDTTHSBindingSource.DataSource = GetHDChuaTTOrTTChuaHetForHocSinh.LoadGetHDChuaTTOrTTChuaHetForHocSinh(Convert.ToInt32(HocSinh_gridLookUpEdit.EditValue));
            gridControl2.DataSource = DSHDTTHSBindingSource;
            DSHSBindingSource.DataSource = GetHocSinhDoiTru.LoadGetHocSinhDoiTru(Convert.ToInt32(HocSinh_gridLookUpEdit.EditValue));
            gridControl1.DataSource = DSHSBindingSource;

            if (DSHSBindingSource.Count > 0)
            {
                DesignGrid_HocSinh();
            }

            DesignGrid_HDTT(DSHDTTHSBindingSource);

            checkTuDongHD.Checked = false;
            checkAll.Checked = false;
            checkAllHD.Checked = false;
            _checkHocSinh = true;
            _checkNCC = false;
            txt_DienGiai.Text = HocSinh_gridLookUpEdit.Text;
        }


        void checkAllHD_EditValueChanged(object sender, EventArgs e)
        {
            if (checkAllHD.Checked == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    gridView2.SetRowCellValue(i, gridView2.Columns["Check"], true);
                }
                gridControl2.Select();
                checkTuDongHD.Checked = false;
            }
            else
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    gridView2.SetRowCellValue(i, gridView2.Columns["Check"], false);
                }
                gridControl2.Select();
            }
        }

        void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void checkAll_EditValueChanged(object sender, EventArgs e)
        {
            if (checkAll.Checked == true)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["Check"], true);
                }
                gridControl1.Select();
            }
            else
            {

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["Check"], false);
                }
                gridControl1.Select();
            }

        }

        void gridView2_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            _tongTienSumGridTT = 0;
            foreach (GetHDChuaTTOrTTChuaHetForHocSinh blchild in DSHDTTHSBindingSource)
            {
                if (blchild.Check == true)
                {
                    _tongTienSumGridTT += blchild.SoTienConNo;
                }
            }
            GridSummaryItem summary = e.Info.SummaryItem;
            string summaryText = String.Format("{0:#,###.##}", _tongTienSumGridTT);
            e.Info.DisplayText = summaryText;
        }


        void gridView1_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            _tongTienSumGridNCC = 0;

            foreach (GetHocSinhDoiTru blchild in DSHSBindingSource)
            {
                if (blchild.Check == true)
                {
                    _tongTienSumGridNCC += blchild.SoTienChuaDoiTru;
                }
            }
            GridSummaryItem summary = e.Info.SummaryItem;
            string summaryText = String.Format("{0:#,###.##}", _tongTienSumGridNCC);
            e.Info.DisplayText = summaryText;
        }

        void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBox1.Focus();
            txt_DienGiai.Focus();
            bool checkNCC = false;
            bool checkHD = false;
            if (string.IsNullOrEmpty(txtSoPhieu.Text.ToString()))
            {
                MessageBox.Show("Chưa nhập số phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (_tongTienSumGridNCC != _tongTienSumGridTT)
            //{
            //    MessageBox.Show("Số tiền hóa đơn và chứng từ không bằng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            if (gridControl1.DataSource == null)
            {
                MessageBox.Show("Chưa chọn dữ liệu cho học sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (gridControl2.DataSource == null)
            {
                MessageBox.Show("Chưa có dữ liệu cho hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _tongTienHDTT = 0;
            _tongTienNCC = 0;
            _tienThue = 0;
            if (_checkHocSinh == true)
            {
                foreach (GetHDChuaTTOrTTChuaHetForHocSinh blchild in DSHDTTHSBindingSource)
                {
                    if (blchild.Check == true)
                    {
                        hdtthsListSelected.Add(blchild);
                        _tongTienHDTT += blchild.TongTien;
                        _tienThue += blchild.ThueVAT;
                        checkHD = true;
                    }
                }
                foreach (GetHocSinhDoiTru blchild in DSHSBindingSource)
                {
                    if (blchild.Check == true)
                    {
                        hsListSelected.Add(blchild);
                        _tongTienNCC += blchild.SoTienChuaDoiTru;
                        checkNCC = true;
                    }
                }
            }
            if (checkHD == false)
            {
                MessageBox.Show("Chưa chọn hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (checkNCC == false)
            {
                MessageBox.Show("Chưa chọn chứng từ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_checkHocSinh == true)
            {
                //foreach (GetHDChuaTTOrTTChuaHetForHocSinh hdtt in hdtthsListSelected)
                //{
                //    if (hdtt.checkDaTT == false)
                //    {
                //        foreach (GetHocSinhDoiTru ncc in hsListSelected) //lay ra may thang = nhau lam trc
                //        {
                //            if (ncc.CheckDaTraNo == false)
                //            {
                //                //_chungTu = ChungTu.GetChungTu(ncc.MaChungTu);
                //                //_THDTCN = TongHopDoiTruCongNo.NewTongHopDoiTruCongNo();
                //                //CTHDTTList = _THDTCN.ChungTu_HoaDonThanhToanChildList;
                //                HoaDon _hd = HoaDon.GetHoaDon(hdtt.MaHoaDon);
                //                CTHDTT = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan(_hd);

                //                _THDTCN.SoPhieu = txtSoPhieu.EditValue.ToString();
                //                _THDTCN.DienGiai = txt_DienGiai.Text;
                //                _THDTCN.NgayLap = (DateTime)dtmp_Ngay.DateTime;

                //                CTHDTT.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                //                if (hdtt.TongTien == ncc.SoTienConNo)
                //                {
                //                    CTHDTT.SoTienThanhToan = hdtt.TongTien;
                //                    CTHDTT.MaChungTu = ncc.MaChungTu;
                //                    CTHDTT.MaButToan = ncc.MaButToan;
                //                    CTHDTT.MaHoaDon = hdtt.MaHoaDon;
                //                    CTHDTT.MaDoiTac = Convert.ToInt64(HocSinh_gridLookUpEdit.EditValue.ToString());
                //                    _THDTCN.ChungTu_HoaDonThanhToanChildList.Add(CTHDTT);
                //                    //_THDTCNList.Add(_THDTCN);
                //                    //_chungTu.ChungTu_HoaDonThanhToanList.Add(CTHDTT);
                //                    //_chungTu.ApplyEdit();
                //                    //_chungTu.Save();
                //                    ncc.CheckDaTraNo = true;
                //                    hdtt.checkDaTT = true;
                //                    break;
                //                }
                //            }

                //        }
                //    }
                //}
                string dienGiai = "";
                foreach (GetHDChuaTTOrTTChuaHetForHocSinh hdtt in hdtthsListSelected)
                {
                    if (hdtt.checkDaTT == false)
                    {
                        foreach (GetHocSinhDoiTru ncc in hsListSelected)
                        {
                            if (ncc.CheckDaTraNo == false)
                            {
                                //_THDTCN = TongHopDoiTruCongNo.NewTongHopDoiTruCongNo();
                                //CTHDTTList = _THDTCN.ChungTu_HoaDonThanhToanChildList;
                                HoaDon _hd = HoaDon.GetHoaDon(hdtt.MaHoaDon);
                                CTHDTT = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan(_hd);

                                _THDTCN.SoPhieu = txtSoPhieu.EditValue.ToString();
                                _THDTCN.DienGiai = txt_DienGiai.Text;
                                _THDTCN.NgayLap = (DateTime)dtmp_Ngay.DateTime;
                                _THDTCN.Loai = 2;

                                CTHDTT.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                                CTHDTT.MaDoiTac = Convert.ToInt64(HocSinh_gridLookUpEdit.EditValue);

                                if (dienGiai == "")
                                    dienGiai = ncc.DienGiai + " " + ncc.SoChungTu;
                                else if (dienGiai.Contains(ncc.SoChungTu) == false)
                                    dienGiai = dienGiai + " " + ncc.SoChungTu;


                                if (0 != hdtt.MaHoaDon)
                                {
                                    if (ncc.SoTienChuaDoiTru == hdtt.SoTienConNo)
                                    {
                                        CTHDTT.SoTienThanhToan = ncc.SoTienChuaDoiTru;
                                        CTHDTT.MaChungTu = ncc.MaChungTu;
                                        CTHDTT.MaButToan = ncc.MaButToan;
                                        CTHDTT.MaHoaDon = hdtt.MaHoaDon;
                                        //CTHDTT.MaDoiTac = Convert.ToInt64(NhaCungCap_gridLookUpEdit1.EditValue.ToString());
                                        hdtt.SoTienConNo = 0;
                                        ncc.SoTienChuaDoiTru = 0;
                                        _THDTCN.ChungTu_HoaDonThanhToanChildList.Add(CTHDTT);

                                        ncc.CheckDaTraNo = true;
                                        hdtt.checkDaTT = true;
                                        if (dienGiai.Contains(_hd.SoHoaDon) == false)
                                            dienGiai = dienGiai + "," + _hd.SoHoaDon;
                                    }
                                    else if (ncc.SoTienChuaDoiTru < hdtt.SoTienConNo)    //lay so tien chung tu lam so tien thanh toan
                                    {
                                        CTHDTT.SoTienThanhToan = ncc.SoTienChuaDoiTru;
                                        CTHDTT.MaChungTu = ncc.MaChungTu;
                                        CTHDTT.MaButToan = ncc.MaButToan;
                                        CTHDTT.MaHoaDon = hdtt.MaHoaDon;
                                        //CTHDTT.MaDoiTac = Convert.ToInt64(NhaCungCap_gridLookUpEdit1.EditValue.ToString());
                                        hdtt.SoTienConNo = hdtt.SoTienConNo - ncc.SoTienChuaDoiTru;
                                        _THDTCN.ChungTu_HoaDonThanhToanChildList.Add(CTHDTT);

                                        ncc.CheckDaTraNo = true;

                                        if (dienGiai.Contains(_hd.SoHoaDon) == false)
                                            dienGiai = dienGiai + "," + _hd.SoHoaDon;
                                    }
                                    else
                                    {
                                        CTHDTT.SoTienThanhToan = hdtt.SoTienConNo;
                                        CTHDTT.MaChungTu = ncc.MaChungTu;
                                        CTHDTT.MaButToan = ncc.MaButToan;
                                        CTHDTT.MaHoaDon = hdtt.MaHoaDon;
                                        //CTHDTT.MaDoiTac = Convert.ToInt64(NhaCungCap_gridLookUpEdit1.EditValue.ToString());
                                        ncc.SoTienChuaDoiTru = ncc.SoTienChuaDoiTru - hdtt.SoTienConNo;
                                        _THDTCN.ChungTu_HoaDonThanhToanChildList.Add(CTHDTT);
                                        hdtt.checkDaTT = true;

                                        if (dienGiai.Contains(_hd.SoHoaDon) == false)
                                            dienGiai = dienGiai + "," + _hd.SoHoaDon;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                txt_DienGiai.Text = txt_DienGiai.Text + " " + dienGiai;
                _THDTCN.DienGiai = txt_DienGiai.Text;
                _THDTCNList.Add(_THDTCN);
                _THDTCNList.Save();

                ThemMoi();

                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DSHDTTHSBindingSource.DataSource = GetHDChuaTTOrTTChuaHetForHocSinh.LoadGetHDChuaTTOrTTChuaHetForHocSinh(Convert.ToInt32(HocSinh_gridLookUpEdit.EditValue));
                gridControl2.DataSource = DSHDTTHSBindingSource;
                DSHSBindingSource.DataSource = GetHocSinhDoiTru.LoadGetHocSinhDoiTru(Convert.ToInt32(HocSinh_gridLookUpEdit.EditValue));
                gridControl1.DataSource = DSHSBindingSource;
            }
            checkAllHD.Checked = false;
            checkAll.Checked = false;
            checkTuDongHD.Checked = false;
            txtSoPhieu.Text = TongHopDoiTruCongNo.NewSoChungTu(DateTime.Now.Date, "DTKH", 2);
        }

        private void ThemMoi()
        {
            _THDTCNList = TongHopDoiTruCongNoList.NewTongHopDoiTruCongNoList();
            _THDTCN = TongHopDoiTruCongNo.NewTongHopDoiTruCongNo();
            txtSoPhieu.EditValue = "";
            txt_DienGiai.EditValue = "";
            dtmp_Ngay.DateTime = DateTime.Now.Date;
        }

        void frmDoiTruCongNoHocSinh_Load(object sender, EventArgs e)
        {
            _THDTCN.Loai = 2;
            dtmp_Ngay.DateTime = DateTime.Now.Date;
            this.splitContainerControl1.SplitterPosition = Screen.PrimaryScreen.Bounds.Width / 2;
            //PublicClass.SetSoChungTuByMaLoaiChungTu(, (Convert.ToDateTime(dtmp_Ngay.EditValue)).Date); PC0002-1803
            //DSHDTTBindingSource.DataSource = typeof(GetHDChuaTTOrTTChuaHet);

            _HocSinhList = DoiTacList.GetDoiTacList("", 10);
            DoiTac dtHS = DoiTac.NewDoiTac();
            dtHS.TenDoiTac = "";
            _HocSinhList.Insert(0, dtHS);
            hocSinhListBindingSource.DataSource = _HocSinhList;

            DesignHocSinh_gridLookUpEdit1();
            //DesignGrid_HDTT();
            txtSoPhieu.Text = TongHopDoiTruCongNo.NewSoChungTu(DateTime.Now.Date, "DTKH", _THDTCN.Loai);
            this.splitContainerControl1.SplitterPosition = this.splitContainerControl1.Height / 2;
        }

        private void DesignHocSinh_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(HocSinh_gridLookUpEdit, hocSinhListBindingSource, "TenDoiTac", "MaDoiTac", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(HocSinh_gridLookUpEdit, new string[] { "TenDoiTac", "MaQLDoiTac" }, new string[] { "Tên Đối Tác", "Mã QL" }, new int[] { 120, 100 }, false);
            //HoatDong_gridLookUpEdit1.EditValueChanged += new System.EventHandler(this.HoatDong_gridLookUpEdit1_EditValueChanged);
        }


        private void DesignGrid_HocSinh()
        {
            gridControl1.DataSource = DSHSBindingSource;
            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "Check", "SoChungTu", "NgayLap", "SoTien", "SoTienChuaDoiTru", "DienGiai" },
                                new string[] { "Chọn", "Số Chứng Từ", "Ngày ghi sổ", "Số Tiền", "Số chưa đối trừ", "Diễn Giải" },
                                             new int[] { 50, 80, 80, 80, 80, 300 }, true);

            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Check", "SoChungTu", "NgayLap", "SoTien", "SoTienChuaDoiTru", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoChungTu", "NgayLap", "SoTien", "SoTienChuaDoiTru", "DienGiai" });
            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTienChuaDoiTru" }, "#,###.##");
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTienChuaDoiTru" }, "{0:#,###.##}");
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M

            RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();

            repositoryItemCalcEditSoTien.AutoHeight = false;
            repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditSoTien.Name = "repositoryItemCalcEditSoTien";
            gridView1.Columns["SoTienChuaDoiTru"].ColumnEdit = repositoryItemCalcEditSoTien;
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "{0:#,###.##}");

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTienChuaDoiTru" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTienChuaDoiTru" }, "{0:#,###.##}");
            gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
        }

        private void DesignGrid_HDTT(BindingSource db)
        {
            gridControl2.DataSource = db;
            HamDungChung.InitGridViewDev(gridView2, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev_Modify(gridView2, new string[] { "Check", "SoHoaDon", "NgayLap", "TongTien", "SoTienConNo", "DienGiai" },
                                new string[] { "Chọn", "Số Hóa Đơn", "Ngày Lập", "Tổng Tiền", "Số chưa đối trừ", "Diễn giải" },
                                             new int[] { 50, 80, 80, 80, 80, 300 }, true);

            HamDungChung.AlignHeaderColumnGridViewDev(gridView2, new string[] { "Check", "SoHoaDon", "NgayLap", "TongTien", "SoTienConNo", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView2, new string[] { "TongTien", "SoTienConNo" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView2, new string[] { "TongTien", "SoTienConNo" }, "{0:#,###.##}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView2, new string[] { "SoHoaDon", "NgayLap", "TongTien", "SoTienConNo" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView2, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView2, 50);//M

            RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();

            repositoryItemCalcEditSoTien.AutoHeight = false;
            repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditSoTien.Name = "repositoryItemCalcEditSoTien";
            gridView2.Columns["TongTien"].ColumnEdit = repositoryItemCalcEditSoTien;
            //gridView2.Columns["SoTienHDDaTT"].ColumnEdit = repositoryItemCalcEditSoTien;
            gridView2.Columns["SoTienConNo"].ColumnEdit = repositoryItemCalcEditSoTien;
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView2, new string[] { "TongTien", "SoTienConNo" }, "#,###.##");
            gridView2.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
        }

        private void btnDanhSachDoiTru_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDSDoiTruCongNo frm = new frmDSDoiTruCongNo(_loai);
            frm.Show();
            frm.StartPosition = FormStartPosition.CenterScreen;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.Name.ToLower() == "colsochungtu")
            {
                GetHocSinhDoiTru obj = (GetHocSinhDoiTru)DSHSBindingSource.Current;

                long maChungTu = obj.MaChungTu;
                int maLoaiChungTu = obj.MaLoaiChungTu;

                switch (maLoaiChungTu)
                {
                    case 2:
                        //PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu,isShowFromReport);
                        PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu);
                        //frm.maChungTuOfReport = maChungTu;
                        //frm.isShowFromReport = isShowFromReport;
                        frm.WindowState = FormWindowState.Maximized;
                        frm.ShowDialog();
                        break;

                    case 3:
                        PSC_ERP.FrmChungTuChiTienMat frm3 = new PSC_ERP.FrmChungTuChiTienMat(maChungTu);
                        frm3.WindowState = FormWindowState.Maximized;
                        frm3.ShowDialog();
                        break;

                    case 4:
                        PSC_ERP.frmPhieuNhapVatTuHangHoa_New frm4 = new PSC_ERP.frmPhieuNhapVatTuHangHoa_New(maChungTu);
                        frm4.WindowState = FormWindowState.Maximized;
                        frm4.ShowDialog();
                        break;

                    case 5:
                        PSC_ERP.FrmPhieuXuatVatTuHangHoa_New frm5 = new PSC_ERP.FrmPhieuXuatVatTuHangHoa_New(maChungTu, 1);
                        frm5.WindowState = FormWindowState.Maximized;
                        frm5.ShowDialog();
                        break;

                    case 6:
                        PSC_ERP.FrmChungTuThuTienGui frm6 = new PSC_ERP.FrmChungTuThuTienGui(maChungTu);
                        frm6.WindowState = FormWindowState.Maximized;
                        frm6.ShowDialog();
                        break;

                    case 7:
                        PSC_ERP.FrmChungTuChiTienGui frm7 = new PSC_ERP.FrmChungTuChiTienGui(maChungTu);
                        frm7.WindowState = FormWindowState.Maximized;
                        frm7.ShowDialog();
                        break;

                    case 8:
                        PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD frm8 = new PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD(maChungTu);
                        frm8.WindowState = FormWindowState.Maximized;
                        frm8.ShowDialog();
                        break;

                    case 9:
                        PSC_ERP.FrmChungTuMuaChuaThanhToan frm9 = new PSC_ERP.FrmChungTuMuaChuaThanhToan(maChungTu);
                        frm9.WindowState = FormWindowState.Maximized;
                        frm9.ShowDialog();
                        break;

                    case 10:
                        PSC_ERP.FrmChungTuGiayNhanNo frm10 = new PSC_ERP.FrmChungTuGiayNhanNo(maChungTu);
                        frm10.WindowState = FormWindowState.Maximized;
                        frm10.ShowDialog();
                        break;

                    case 14:
                        PSC_ERP.FrmChungTuChuyenTienNoiBo frm14 = new PSC_ERP.FrmChungTuChuyenTienNoiBo(maChungTu);
                        frm14.WindowState = FormWindowState.Maximized;
                        frm14.ShowDialog();
                        break;

                    case 16:
                        PSC_ERP.FrmChungTuKeToanCustomize frm16 = new PSC_ERP.FrmChungTuKeToanCustomize(maChungTu);
                        frm16.WindowState = FormWindowState.Maximized;
                        frm16.ShowDialog();
                        break;

                    case 22:
                        PSC_ERP.FrmChungTuPhiNganHang frm22 = new PSC_ERP.FrmChungTuPhiNganHang(maChungTu);
                        frm22.WindowState = FormWindowState.Maximized;
                        frm22.ShowDialog();
                        break;

                    case 23:
                        PSC_ERP.FrmChungTuMuaNgoaiTe frm23 = new PSC_ERP.FrmChungTuMuaNgoaiTe(maChungTu);
                        frm23.WindowState = FormWindowState.Maximized;
                        frm23.ShowDialog();
                        break;

                    case 24:
                        PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai frm24 = new PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai(maChungTu);
                        frm24.WindowState = FormWindowState.Maximized;
                        frm24.ShowDialog();
                        break;

                    case 25:
                        PSC_ERP.FrmChungTuGiayRutTienMat frm25 = new PSC_ERP.FrmChungTuGiayRutTienMat(maChungTu);
                        frm25.WindowState = FormWindowState.Maximized;
                        frm25.ShowDialog();
                        break;


                    default:
                        MessageBox.Show("Không tìm thấy form chứng từ");
                        break;
                }
            }
        }



    }
}