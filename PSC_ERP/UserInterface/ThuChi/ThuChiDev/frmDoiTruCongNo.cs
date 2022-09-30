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
using PSC_ERP_Common;

namespace PSC_ERP
{
    public partial class frmDoiTruCongNo : DevExpress.XtraEditors.XtraForm
    {
        List<GetHDChuaTTOrTTChuaHet> _HDTTNCCList = new List<GetHDChuaTTOrTTChuaHet>();
        public List<GetHDChuaTTOrTTChuaHet> hdttnccListSelected
        {
            get { return _HDTTNCCList; }

        }

        List<GetNCCConNo> _NCCList = new List<GetNCCConNo>();
        public List<GetNCCConNo> nccListSelected
        {
            get { return _NCCList; }
            set { _NCCList = value; }

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
        private int _loai = 1;
        private int _loaiDoiTac = 3;
        private DoiTacList _DoiTacList, _HocSinhList;
        private BindingSource doiTacListBindingSource = new BindingSource();
        private BindingSource DSNCCBindingSource = new BindingSource();
        private BindingSource DSHDTTNCCBindingSource = new BindingSource();
        public frmDoiTruCongNo()
        {
            InitializeComponent();
            this.Load += frmDoiTruCongNo_Load;
            this.NhaCungCap_gridLookUpEdit1.EditValueChanged += NhaCungCap_gridLookUpEdit1_EditValueChanged;
            this.btnLuu.ItemClick += btnLuu_ItemClick;
            this.gridView1.CustomDrawFooterCell += gridView1_CustomDrawFooterCell;
            this.gridView2.CustomDrawFooterCell += gridView2_CustomDrawFooterCell;
            this.checkAll.EditValueChanged += checkAll_EditValueChanged;
            this.btnThoat.ItemClick += btnThoat_ItemClick;
            this.checkAllHD.EditValueChanged += checkAllHD_EditValueChanged;
            this.checkTuDongHD.EditValueChanged += checkTuDongHD_EditValueChanged;
        }
        void checkTuDongHD_EditValueChanged(object sender, EventArgs e)
        {
            #region
            //checkAllHD.Checked = false;
            //if (checkTuDongHD.Checked == true)
            //{ 
            //    _tongTienNCC = 0;
            //    foreach (GetNCCConNo blchild in DSNCCBindingSource)
            //    {
            //        if (blchild.Check == true)
            //        {
            //            nccListSelected.Add(blchild);
            //            _tongTienNCC += blchild.SoTienConNo;
            //        }
            //    }

            //    foreach (GetHDChuaTTOrTTChuaHet blchild in DSHDTTBindingSource)
            //    {
            //        blchild.Check = false;
            //        if (blchild.SoTienHDConLai == _tongTienNCC)
            //        {
            //            blchild.Check = true;
            //            gridControl2.DataSource = DSHDTTBindingSource;
            //            DesignGrid_HDTT();
            //            return;
            //        }
            //    }

            //    int i = 1;
            //    long tamIndexBeGanNhat = 0;
            //    long tamIndexLonGanNhat = 0;
            //    decimal sotienBeGanNhat = 0;
            //    decimal sotienLonGanNhat = 0;
            //    decimal soTieNCCMacDinh = _tongTienNCC;
            //    decimal minBe = _tongTienNCC;
            //    decimal minLon = _tongTienNCC;
            //    decimal vuotTong = 0;

            //    while (i <= DSHDTTBindingSource.Count)
            //    {
            //        foreach (GetHDChuaTTOrTTChuaHet blchild in DSHDTTBindingSource)
            //        {
            //            decimal tempBe = Math.Abs(blchild.SoTienHDConLai - _tongTienNCC);
            //            if (minBe >= Math.Abs(tempBe) && blchild.Check == false)
            //            {
            //                minBe = tempBe;
            //                tamIndexBeGanNhat = blchild.MaHoaDon;
            //                sotienBeGanNhat = blchild.SoTienHDConLai;
            //            }
            //            decimal tempLon = blchild.SoTienHDConLai - _tongTienNCC;
            //            if (minLon <= tempLon && blchild.Check == false)
            //            {
            //                tamIndexLonGanNhat = blchild.MaHoaDon;
            //                sotienLonGanNhat = blchild.SoTienHDConLai;
            //            }
            //        }
            //        foreach (GetHDChuaTTOrTTChuaHet blchild in DSHDTTBindingSource)
            //        {
            //            if (blchild.MaHoaDon == tamIndexBeGanNhat)
            //            {
            //                blchild.Check = true;
            //                _tongTienNCC = minBe;
            //                tamIndexBeGanNhat = 0;
            //                vuotTong += blchild.SoTienHDConLai;
            //                if (vuotTong >= soTieNCCMacDinh)
            //                    minBe = 0;
            //            }
            //        }
            //        i++;
            //    }

            //    sotienBeGanNhat = 0;

            //    foreach (GetHDChuaTTOrTTChuaHet blchild in DSHDTTBindingSource)
            //    {
            //        if (blchild.Check == true)
            //        {
            //            sotienBeGanNhat += blchild.SoTienHDConLai;
            //        }
            //    }

            //    if (sotienBeGanNhat != 0)
            //    {
            //        if (Math.Abs(soTieNCCMacDinh - sotienBeGanNhat) > Math.Abs(soTieNCCMacDinh - sotienLonGanNhat))
            //        {
            //            foreach (GetHDChuaTTOrTTChuaHet blchild in DSHDTTBindingSource)
            //            {
            //                blchild.Check = false;
            //                if (blchild.MaHoaDon == tamIndexLonGanNhat)
            //                {
            //                    blchild.Check = true;
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        foreach (GetHDChuaTTOrTTChuaHet blchild in DSHDTTBindingSource)
            //        {
            //            blchild.Check = false;
            //            if (blchild.MaHoaDon == tamIndexLonGanNhat)
            //            {
            //                blchild.Check = true;
            //            }
            //        }
            //    }

            //    gridControl2.DataSource = DSHDTTBindingSource;
            //    DesignGrid_HDTT();
            //}
            //else
            //{
            //    foreach (GetHDChuaTTOrTTChuaHet blchild in DSHDTTBindingSource)
            //    {
            //        if(blchild.Check == true)
            //            blchild.Check = false;
            //    }
            //    gridControl2.DataSource = DSHDTTBindingSource;
            //    DesignGrid_HDTT();
            //}
            #endregion

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
            decimal _tongSoConNo = 0;
            foreach (GetHDChuaTTOrTTChuaHet blchild in DSHDTTNCCBindingSource)
            {
                if (blchild.Check == true)
                {
                    _tongTienSumGridTT += blchild.TongTien;
                    _tongSoConNo += blchild.SoTienConNo;
                }
            }

            if (e.Column.FieldName.ToString().ToLower() == "tongtien")
            {
                GridSummaryItem summary = e.Info.SummaryItem;
                string summaryText = String.Format("{0:#,###.##}", _tongTienSumGridTT);
                e.Info.DisplayText = summaryText;
            }

            if (e.Column.FieldName.ToString().ToLower() == "sotienconno")
            {
                GridSummaryItem summary = e.Info.SummaryItem;
                string summaryText = String.Format("{0:#,###.##}", _tongSoConNo);
                e.Info.DisplayText = summaryText;
            }

        }


        void gridView1_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            _tongTienSumGridNCC = 0;
            decimal _soTienChuaDoiTru = 0;
            foreach (GetNCCConNo blchild in DSNCCBindingSource)
            {
                if (blchild.Check == true)
                {
                    _soTienChuaDoiTru += blchild.SoTienChuaDoiTru;
                    _tongTienSumGridNCC += blchild.SoTien;
                }
            }

            if (e.Column.FieldName.ToString().ToLower() == "sotien")
            {
                GridSummaryItem summary = e.Info.SummaryItem;
                string summaryText = String.Format("{0:#,###.##}", _tongTienSumGridNCC);
                e.Info.DisplayText = summaryText;
            }

            if (e.Column.FieldName.ToString().ToLower() == "sotienchuadoitru")
            {
                GridSummaryItem summary = e.Info.SummaryItem;
                string summaryText = String.Format("{0:#,###.##}", _soTienChuaDoiTru);
                e.Info.DisplayText = summaryText;
            }


        }

        void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBox1.Focus();
            txt_DienGiai.Focus();
            SaveData();
            //bool checkNCC = false;
            //bool checkHD = false;
            //if (string.IsNullOrEmpty(txtSoPhieu.Text.ToString()))
            //{
            //    MessageBox.Show("Chưa nhập số phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            ////if (_tongTienSumGridNCC != _tongTienSumGridTT)
            ////{
            ////    MessageBox.Show("Số tiền hóa đơn và chứng từ không bằng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////    return;
            ////}
            //if (gridControl1.DataSource == null)
            //{
            //    MessageBox.Show("Chưa chọn dữ liệu cho nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (gridControl2.DataSource == null)
            //{
            //    MessageBox.Show("Chưa có dữ liệu cho hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //_tongTienHDTT = 0;
            //_tongTienNCC = 0;
            //_tienThue = 0;
            //hdttnccListSelected.Clear();
            //nccListSelected.Clear();
            //if (_checkNCC == true)
            //{
            //    foreach (GetHDChuaTTOrTTChuaHet blchild in DSHDTTNCCBindingSource)
            //    {
            //        if (blchild.Check == true)
            //        {
            //            hdttnccListSelected.Add(blchild);
            //            _tongTienHDTT += blchild.SoTienConNo;
            //            _tienThue += blchild.ThueVAT;
            //            checkHD = true;
            //        }
            //    }
            //    foreach (GetNCCConNo blchild in DSNCCBindingSource)
            //    {
            //        if (blchild.Check == true)
            //        {
            //            nccListSelected.Add(blchild);
            //            _tongTienNCC += blchild.SoTienChuaDoiTru;
            //            checkNCC = true;
            //        }
            //    }
            //}
            //if (checkHD == false)
            //{
            //    MessageBox.Show("Chưa chọn hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (checkNCC == false)
            //{
            //    MessageBox.Show("Chưa chọn chứng từ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (_checkNCC == true)
            //{
            //    nccListSelected = (List<GetNCCConNo>)nccListSelected.OrderBy(x => x.NgayLap).ToList();//uu tien theo ngay
            //    CTHDTTList = _THDTCN.ChungTu_HoaDonThanhToanChildList;
            //    foreach (GetHDChuaTTOrTTChuaHet hdtt in hdttnccListSelected)
            //    {
            //        if (hdtt.checkDaTT == false)
            //        {
            //            foreach (GetNCCConNo ncc in nccListSelected) //lay ra may thang = nhau lam trc
            //            {
            //                if (ncc.CheckDaTraNo == false)
            //                {
            //                    //_chungTu = ChungTu.GetChungTu(ncc.MaChungTu);
            //                    //_THDTCN = TongHopDoiTruCongNo.NewTongHopDoiTruCongNo();
            //                    //CTHDTTList = _THDTCN.ChungTu_HoaDonThanhToanChildList;
            //                    HoaDon _hd = HoaDon.GetHoaDon(hdtt.MaHoaDon);
            //                    CTHDTT = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan(_hd);

            //                    _THDTCN.SoPhieu = txtSoPhieu.Text;
            //                    _THDTCN.DienGiai = txt_DienGiai.Text;
            //                    _THDTCN.NgayLap = (DateTime)dtmp_Ngay.DateTime;

            //                    CTHDTT.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            //                    if (hdtt.TongTien == ncc.SoTienChuaDoiTru)
            //                    {
            //                        CTHDTT.SoTienThanhToan = hdtt.TongTien;
            //                        CTHDTT.MaChungTu = ncc.MaChungTu;
            //                        CTHDTT.MaButToan = ncc.MaButToan;
            //                        CTHDTT.MaHoaDon = hdtt.MaHoaDon;
            //                        CTHDTT.MaDoiTac = Convert.ToInt64(NhaCungCap_gridLookUpEdit1.EditValue.ToString());
            //                        _THDTCN.ChungTu_HoaDonThanhToanChildList.Add(CTHDTT);
            //                        //_THDTCNList.Add(_THDTCN);
            //                        //_chungTu.ChungTu_HoaDonThanhToanList.Add(CTHDTT);
            //                        //_chungTu.ApplyEdit();
            //                        //_chungTu.Save();
            //                        ncc.CheckDaTraNo = true;
            //                        hdtt.checkDaTT = true;
            //                        break;
            //                    }
            //                }

            //            }
            //        }
            //    }

            //    foreach (GetHDChuaTTOrTTChuaHet hdtt in hdttnccListSelected)
            //    {
            //        if (hdtt.checkDaTT == false)
            //        {
            //            foreach (GetNCCConNo ncc in nccListSelected)
            //            {
            //                if (ncc.CheckDaTraNo == false)
            //                {
            //                    //_THDTCN = TongHopDoiTruCongNo.NewTongHopDoiTruCongNo();
            //                    //CTHDTTList = _THDTCN.ChungTu_HoaDonThanhToanChildList;
            //                    HoaDon _hd = HoaDon.GetHoaDon(hdtt.MaHoaDon);
            //                    CTHDTT = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan(_hd);

            //                    _THDTCN.SoPhieu = txtSoPhieu.EditValue.ToString();
            //                    _THDTCN.DienGiai = txt_DienGiai.Text;
            //                    _THDTCN.NgayLap = (DateTime)dtmp_Ngay.DateTime;

            //                    CTHDTT.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            //                    if (0 != hdtt.MaHoaDon)
            //                    {
            //                        if (ncc.SoTienChuaDoiTru - hdtt.TongTien < 0)
            //                        {
            //                            CTHDTT.SoTienThanhToan = ncc.SoTienChuaDoiTru;
            //                            CTHDTT.MaChungTu = ncc.MaChungTu;
            //                            CTHDTT.MaButToan = ncc.MaButToan;
            //                            CTHDTT.MaHoaDon = hdtt.MaHoaDon;
            //                            CTHDTT.MaDoiTac = Convert.ToInt64(NhaCungCap_gridLookUpEdit1.EditValue.ToString());
            //                            hdtt.TongTien -= ncc.SoTienChuaDoiTru;
            //                            _THDTCN.ChungTu_HoaDonThanhToanChildList.Add(CTHDTT);

            //                            ncc.CheckDaTraNo = true;
            //                        }
            //                        else
            //                        {
            //                            CTHDTT.SoTienThanhToan = hdtt.TongTien;
            //                            CTHDTT.MaChungTu = ncc.MaChungTu;
            //                            CTHDTT.MaButToan = ncc.MaButToan;
            //                            CTHDTT.MaHoaDon = hdtt.MaHoaDon;
            //                            CTHDTT.MaDoiTac = Convert.ToInt64(NhaCungCap_gridLookUpEdit1.EditValue.ToString());
            //                            ncc.SoTienChuaDoiTru -= hdtt.TongTien;
            //                            _THDTCN.ChungTu_HoaDonThanhToanChildList.Add(CTHDTT);
            //                            hdtt.checkDaTT = true;
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    _THDTCNList.Add(_THDTCN);
            //    _THDTCNList.Save();

            //    ThemMoi();

            //    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    DSHDTTNCCBindingSource.DataSource = GetHDChuaTTOrTTChuaHet.LoadGetHDChuaTTOrTTChuaHet(Convert.ToInt32(NhaCungCap_gridLookUpEdit1.EditValue));
            //    gridControl2.DataSource = DSHDTTNCCBindingSource;
            //    DSNCCBindingSource.DataSource = GetNCCConNo.LoadGetNCCConNo(Convert.ToInt32(NhaCungCap_gridLookUpEdit1.EditValue));
            //    gridControl1.DataSource = DSNCCBindingSource;
            //}

            //checkAllHD.Checked = false;
            //checkAll.Checked = false;
            //checkTuDongHD.Checked = false;
            //txtSoPhieu.Text = TongHopDoiTruCongNo.NewSoChungTu(DateTime.Now.Date, "DTNC", _THDTCN.Loai);
        }

        private void ThemMoi()
        {
            _THDTCNList = TongHopDoiTruCongNoList.NewTongHopDoiTruCongNoList();
            _THDTCN = TongHopDoiTruCongNo.NewTongHopDoiTruCongNo();
            txtSoPhieu.EditValue = "";
            txt_DienGiai.EditValue = "";
            dtmp_Ngay.DateTime = DateTime.Now.Date;
        }

        bool isDaLoadComBo = false;
        void NhaCungCap_gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (isDaLoadComBo)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            //gridControl1.DataSource = null;
            //gridControl2.DataSource = null;
            DSHDTTNCCBindingSource.DataSource = GetHDChuaTTOrTTChuaHet.LoadGetHDChuaTTOrTTChuaHet(Convert.ToInt32(NhaCungCap_gridLookUpEdit1.EditValue), dtEdit_TuNgay.DateTime.Date, dtEdit_DenNgay.DateTime.Date);
            gridControl2.DataSource = DSHDTTNCCBindingSource;
            DSNCCBindingSource.DataSource = GetNCCConNo.LoadGetNCCConNo(Convert.ToInt32(NhaCungCap_gridLookUpEdit1.EditValue), dtEdit_TuNgay.DateTime.Date, dtEdit_DenNgay.DateTime.Date);
            gridControl1.DataSource = DSNCCBindingSource;

            checkTuDongHD.Checked = false;
            checkAll.Checked = false;
            checkAllHD.Checked = false;
            _checkNCC = true;
            _checkHocSinh = false;

            txt_DienGiai.Text = NhaCungCap_gridLookUpEdit1.Text;
        }

        private void DesignGrid()
        {
            DesignGrid_NCC();
            DesignGrid_HDTT();
        }

        void frmDoiTruCongNo_Load(object sender, EventArgs e)
        {
            _THDTCN.Loai = 1;
            dtmp_Ngay.DateTime = DateTime.Now.Date;
            this.splitContainerControl1.SplitterPosition = Screen.PrimaryScreen.Bounds.Width / 2;
            //PublicClass.SetSoChungTuByMaLoaiChungTu(, (Convert.ToDateTime(dtmp_Ngay.EditValue)).Date); PC0002-1803
            //DSHDTTBindingSource.DataSource = typeof(GetHDChuaTTOrTTChuaHet);

            _DoiTacList = DoiTacList.GetNCCVaKHList();
            DoiTac dt = DoiTac.NewDoiTac();
            dt.TenDoiTac = "";
            _DoiTacList.Insert(0, dt);
            doiTacListBindingSource.DataSource = _DoiTacList;


            DesignNhaCungCap_gridLookUpEdit1();
            //DesignGrid_HDTT();
            txtSoPhieu.Text = TongHopDoiTruCongNo.NewSoChungTu(DateTime.Now.Date, "DTNC", _THDTCN.Loai);
            this.splitContainerControl1.SplitterPosition = this.splitContainerControl1.Height / 2;

            DateTime _tuNgay = DateTime.Today.Month > 6 ? new DateTime(DateTime.Today.Year, 7, 1) : new DateTime(DateTime.Today.Year - 1, 7, 1);
            DateTime _denNgay = DateTime.Today.Month > 6 ? new DateTime(DateTime.Today.Year + 1, 6, 30) : new DateTime(DateTime.Today.Year, 6, 30);
            dtEdit_DenNgay.DateTime = _denNgay;
            dtEdit_TuNgay.DateTime = _tuNgay;
            isDaLoadComBo = true;

            DesignGrid();
        }

        private void DesignNhaCungCap_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(NhaCungCap_gridLookUpEdit1, doiTacListBindingSource, "TenDoiTac", "MaDoiTac", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(NhaCungCap_gridLookUpEdit1, new string[] { "TenDoiTac", "MaQLDoiTac" }, new string[] { "Tên Đối Tác", "Mã QL" }, new int[] { 120, 100 }, false);
            //HoatDong_gridLookUpEdit1.EditValueChanged += new System.EventHandler(this.HoatDong_gridLookUpEdit1_EditValueChanged);
        }

        private void DesignGrid_NCC()
        {
            gridControl1.DataSource = DSNCCBindingSource;
            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "Check", "SoChungTu", "NgayLap", "SoTien", "SoTienChuaDoiTru", "DienGiai" },
                                new string[] { "Chọn", "Số Chứng Từ", "Ngày ghi sổ", "Số Tiền", "Số chưa đối trừ", "Diễn Giải" },
                                             new int[] { 50, 80, 100, 80, 80, 300 }, true);

            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Check", "SoChungTu", "NgayLap", "SoTien", "SoTienChuaDoiTru", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoChungTu", "NgayLap", "SoTien", "SoTienChuaDoiTru", "DienGiai" });
            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien", "SoTienChuaDoiTru" }, "#,###.##");
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTien", "SoTienChuaDoiTru" }, "{0:#,###.##}");
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

            //gridView1.DoubleClick += gridView1_DoubleClick;
        }

        void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GetNCCConNo obj = (GetNCCConNo)DSNCCBindingSource.Current;
            long maChungTu = obj.MaChungTu;
            int MaLoaiChungTu = obj.MaLoaiChungTu;
            switch (MaLoaiChungTu)
            {

                case 3:
                    PSC_ERP.FrmChungTuChiTienMat frm3 = new PSC_ERP.FrmChungTuChiTienMat(maChungTu);
                    frm3.WindowState = FormWindowState.Maximized;
                    frm3.ShowDialog();
                    break;
                case 7:
                    PSC_ERP.FrmChungTuChiTienGui frm7 = new PSC_ERP.FrmChungTuChiTienGui(maChungTu);
                    frm7.WindowState = FormWindowState.Maximized;
                    frm7.ShowDialog();
                    break;
                default:
                    MessageBox.Show("Không tìm thấy Form chứng từ");
                    break;

            }
        }


        private void DesignGrid_HDTT()
        {
            gridControl2.DataSource = DSHDTTNCCBindingSource;
            HamDungChung.InitGridViewDev(gridView2, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev_Modify(gridView2, new string[] { "Check", "SoHoaDon", "NgayLap", "TongTien", "SoTienConNo", "GhiChu" },
                                new string[] { "Chọn", "Số Hóa Đơn", "Ngày Lập", "Tổng Tiền", "Số còn nợ", "Diễn giải" },
                                             new int[] { 50, 80, 100, 80, 80, 300 }, true);

            HamDungChung.AlignHeaderColumnGridViewDev(gridView2, new string[] { "Check", "SoHoaDon", "NgayLap", "TongTien", "SoTienConNo", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);

            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView2, new string[] { "TongTien", "SoTienConNo" }, "#,###.##");
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView2, new string[] { "TongTien", "SoTienConNo" }, "{0:#,###.##}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView2, new string[] { "SoHoaDon", "NgayLap", "TongTien", "SoTienConNo", "GhiChu" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView2, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView2, 50);//M

            RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();

            repositoryItemCalcEditSoTien.AutoHeight = false;
            repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditSoTien.Name = "repositoryItemCalcEditSoTien";
            gridView2.Columns["TongTien"].ColumnEdit = repositoryItemCalcEditSoTien;
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView2, new string[] { "TongTien" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView2, new string[] { "TongTien" }, "{0:#,###.##}");

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView2, new string[] { "SoTienConNo" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView2, new string[] { "SoTienConNo" }, "{0:#,###.##}");

            gridView2.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;

            //gridView2.DoubleClick += gridView2_DoubleClick;
        }

        void gridView2_DoubleClick(object sender, EventArgs e)
        {
            GetHDChuaTTOrTTChuaHet obj = (GetHDChuaTTOrTTChuaHet)DSHDTTNCCBindingSource.Current;

            if (obj != null)
            {
                HoaDon objHoaDon = HoaDon.GetHoaDon(obj.MaHoaDon);

                frmHoaDonDichVuMuaVao _frmHoaDonDichVu = new frmHoaDonDichVuMuaVao(objHoaDon);
                _frmHoaDonDichVu.WindowState = FormWindowState.Maximized;
                _frmHoaDonDichVu.ShowDialog();
            }
        }

        private void btnDanhSachDoiTru_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDSDoiTruCongNo frm = new frmDSDoiTruCongNo(_loai);
            frm.Show();
            frm.StartPosition = FormStartPosition.CenterScreen;
        }


        private void SaveData()
        {
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
                MessageBox.Show("Chưa chọn dữ liệu cho nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            hdttnccListSelected.Clear();
            nccListSelected.Clear();
            if (_checkNCC == true)
            {
                foreach (GetHDChuaTTOrTTChuaHet blchild in DSHDTTNCCBindingSource)
                {
                    if (blchild.Check == true)
                    {
                        hdttnccListSelected.Add(blchild);
                        _tongTienHDTT += blchild.SoTienConNo;
                        _tienThue += blchild.ThueVAT;
                        checkHD = true;
                    }
                }
                foreach (GetNCCConNo blchild in DSNCCBindingSource)
                {
                    if (blchild.Check == true)
                    {
                        nccListSelected.Add(blchild);
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

            string sDienGiai = "Đối trừ ";
            string sCtuCongNo = "";
            string sHoaDon = "";
            foreach (GetHDChuaTTOrTTChuaHet hdtt in hdttnccListSelected)
            {
                if (hdtt.checkDaTT == false)
                {
                    foreach (GetNCCConNo ncc in nccListSelected)
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
                            _THDTCN.Loai = 1;
                            CTHDTT.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                            CTHDTT.MaDoiTac = Convert.ToInt64(NhaCungCap_gridLookUpEdit1.EditValue);
                            //if (0 != hdtt.MaHoaDon)
                            //{
                            if (ncc.SoTienChuaDoiTru == hdtt.SoTienConNo && ncc.SoTienChuaDoiTru > 0)
                            {
                                CTHDTT.SoTienThanhToan = ncc.SoTienChuaDoiTru;
                                CTHDTT.MaChungTu = ncc.MaChungTu;
                                CTHDTT.MaButToan = ncc.MaButToan;
                                CTHDTT.MaHoaDon = hdtt.MaHoaDon;
                                //CTHDTT.MaDoiTac = Convert.ToInt64(NhaCungCap_gridLookUpEdit1.EditValue.ToString());
                                hdtt.SoTienConNo = 0;
                                ncc.SoTienChuaDoiTru = 0;
                                if (hdtt.MaHoaDon == 0)     //so du dau ky ben CO
                                {
                                    CTHDTT.IsCanTruSoDauKy = true;
                                    CTHDTT.NgayLap = ncc.NgayLap.Date;
                                    sDienGiai = sDienGiai + ncc.SoChungTu + " ngày " + ncc.NgayLap.ToString("dd/MM/yyyy") + " và Số Đầu Kỳ ngày" + dtEdit_TuNgay.DateTime.ToString("dd/MM/yyyy") + " ";
                                }
                                else if (ncc.MaChungTu == 0)   //so du dau ky ben NO
                                {
                                    CTHDTT.IsCanTruSoDauKy = true;
                                    CTHDTT.NgayLap = hdtt.NgayLap.Date;
                                    sDienGiai = sDienGiai + hdtt.SoHoaDon + " ngày " + hdtt.NgayLap.ToString("dd/MM/yyyy") + " và Số Đầu Kỳ ngày" + dtEdit_TuNgay.DateTime.ToString("dd/MM/yyyy") + " ";
                                }
                                else
                                {
                                    CTHDTT.IsCanTruSoDauKy = false;
                                    sDienGiai = sDienGiai + ncc.SoChungTu + " ngày " + ncc.NgayLap.ToString("dd/MM/yyyy") + " và " + hdtt.SoHoaDon + " ngày " + hdtt.NgayLap.ToString("dd/MM/yyyy") + " ";
                                }

                                _THDTCN.ChungTu_HoaDonThanhToanChildList.Add(CTHDTT);

                                ncc.CheckDaTraNo = true;
                                hdtt.checkDaTT = true;

                            }
                            else if (ncc.SoTienChuaDoiTru < hdtt.SoTienConNo && ncc.SoTienChuaDoiTru > 0)    //lay so tien chung tu lam so tien thanh toan
                            {
                                CTHDTT.SoTienThanhToan = ncc.SoTienChuaDoiTru;
                                CTHDTT.MaChungTu = ncc.MaChungTu;
                                CTHDTT.MaButToan = ncc.MaButToan;
                                CTHDTT.MaHoaDon = hdtt.MaHoaDon;
                                //CTHDTT.MaDoiTac = Convert.ToInt64(NhaCungCap_gridLookUpEdit1.EditValue.ToString());
                                hdtt.SoTienConNo = hdtt.SoTienConNo - ncc.SoTienChuaDoiTru;

                                if (hdtt.MaHoaDon == 0)
                                {
                                    CTHDTT.IsCanTruSoDauKy = true;
                                    CTHDTT.NgayLap = ncc.NgayLap.Date;
                                    sDienGiai = sDienGiai + ncc.SoChungTu + " ngày " + ncc.NgayLap.ToString("dd/MM/yyyy") + " và Số Đầu Kỳ ngày " + dtEdit_TuNgay.DateTime.ToString("dd/MM/yyyy") + " ";
                                }
                                else if (ncc.MaChungTu == 0)   //so du dau ky ben NO
                                {
                                    CTHDTT.IsCanTruSoDauKy = true;
                                    CTHDTT.NgayLap = hdtt.NgayLap.Date;
                                    sDienGiai = sDienGiai + hdtt.SoHoaDon + " ngày " + hdtt.NgayLap.ToString("dd/MM/yyyy") + " và Số Đầu Kỳ ngày" + dtEdit_TuNgay.DateTime.ToString("dd/MM/yyyy") + " ";
                                }
                                else
                                {
                                    CTHDTT.IsCanTruSoDauKy = false;
                                    sDienGiai = sDienGiai + ncc.SoChungTu + " ngày " + ncc.NgayLap.ToString("dd/MM/yyyy") + " và " + hdtt.SoHoaDon + " ngày " + hdtt.NgayLap.ToString("dd/MM/yyyy") + " ";
                                }

                                _THDTCN.ChungTu_HoaDonThanhToanChildList.Add(CTHDTT);

                                ncc.CheckDaTraNo = true;
                            }
                            else if (hdtt.SoTienConNo > 0)
                            {
                                CTHDTT.SoTienThanhToan = hdtt.SoTienConNo;
                                CTHDTT.MaChungTu = ncc.MaChungTu;
                                CTHDTT.MaButToan = ncc.MaButToan;
                                CTHDTT.MaHoaDon = hdtt.MaHoaDon;
                                //CTHDTT.MaDoiTac = Convert.ToInt64(NhaCungCap_gridLookUpEdit1.EditValue.ToString());
                                ncc.SoTienChuaDoiTru = ncc.SoTienChuaDoiTru - hdtt.SoTienConNo;

                                if (hdtt.MaHoaDon == 0)
                                {
                                    CTHDTT.IsCanTruSoDauKy = true;
                                    CTHDTT.NgayLap = ncc.NgayLap.Date;
                                    sDienGiai = sDienGiai + ncc.SoChungTu + " ngày " + ncc.NgayLap.ToString("dd/MM/yyyy") + " và Số Đầu Kỳ ngày " + dtEdit_TuNgay.DateTime.ToString("dd/MM/yyyy") + " ";
                                }
                                else if (ncc.MaChungTu == 0)   //so du dau ky ben NO
                                {
                                    CTHDTT.IsCanTruSoDauKy = true;
                                    CTHDTT.NgayLap = hdtt.NgayLap.Date;
                                    sDienGiai = sDienGiai + hdtt.SoHoaDon + " ngày " + hdtt.NgayLap.ToString("dd/MM/yyyy") + " và Số Đầu Kỳ ngày" + dtEdit_TuNgay.DateTime.ToString("dd/MM/yyyy") + " ";
                                }
                                else
                                {
                                    CTHDTT.IsCanTruSoDauKy = false;
                                    sDienGiai = sDienGiai + ncc.SoChungTu + " ngày " + ncc.NgayLap.ToString("dd/MM/yyyy") + " và " + hdtt.SoHoaDon + " ngày " + hdtt.NgayLap.ToString("dd/MM/yyyy") + " ";
                                }

                                _THDTCN.ChungTu_HoaDonThanhToanChildList.Add(CTHDTT);
                                hdtt.checkDaTT = true;
                                break;
                            }
                            //}
                        }
                    }
                }
            }
            if (txt_DienGiai.Text != "")
                _THDTCN.DienGiai = txt_DienGiai.Text;
            else
                _THDTCN.DienGiai = sDienGiai;

            _THDTCNList.Add(_THDTCN);
            _THDTCNList.Save();

            ThemMoi();

            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DSHDTTNCCBindingSource.DataSource = GetHDChuaTTOrTTChuaHet.LoadGetHDChuaTTOrTTChuaHet(Convert.ToInt32(NhaCungCap_gridLookUpEdit1.EditValue), dtEdit_TuNgay.DateTime, dtEdit_DenNgay.DateTime);
            gridControl2.DataSource = DSHDTTNCCBindingSource;
            DSNCCBindingSource.DataSource = GetNCCConNo.LoadGetNCCConNo(Convert.ToInt32(NhaCungCap_gridLookUpEdit1.EditValue), dtEdit_TuNgay.DateTime, dtEdit_DenNgay.DateTime);
            gridControl1.DataSource = DSNCCBindingSource;

            checkAllHD.Checked = false;
            checkAll.Checked = false;
            checkTuDongHD.Checked = false;
            txtSoPhieu.Text = TongHopDoiTruCongNo.NewSoChungTu(DateTime.Now.Date, "DTNC", 1);
        }

        private void btnLayDuLieu_Click(object sender, EventArgs e)
        {
            LoadData();
        }


    }
}