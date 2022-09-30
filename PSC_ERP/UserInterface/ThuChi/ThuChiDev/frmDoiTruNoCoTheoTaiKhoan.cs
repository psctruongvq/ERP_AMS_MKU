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
    public partial class frmDoiTruNoCoTheoTaiKhoan : XtraForm
    {
        
        List<GetButToanTheoDoiTuongvaTaiKhoan> _danhSachButToanNo = new List<GetButToanTheoDoiTuongvaTaiKhoan>();       
        public List<GetButToanTheoDoiTuongvaTaiKhoan> _danhSachButToanNoChon
        {
            get { return _danhSachButToanNo; }
            set { _danhSachButToanNo = value; }
        }
        List<GetButToanTheoDoiTuongvaTaiKhoan> _danhSach_chungTu_ChungTu = new List<GetButToanTheoDoiTuongvaTaiKhoan>();
        public List<GetButToanTheoDoiTuongvaTaiKhoan> _danhSachButToanCoChon
        {
            get { return _danhSach_chungTu_ChungTu; }

        }
        decimal _tongTienSumGridbutToanCoChon = 0;
        decimal _tongTienSumGridbutToanNoChon = 0;
        
        private ChungTu_ChungTuChild _chungTu_ChungTu;
        private ChungTu_ChungTuChildList _chungTu_ChungTuList;
        private TongHopDoiTruCongNoList _THDTCNList = TongHopDoiTruCongNoList.NewTongHopDoiTruCongNoList();
        private TongHopDoiTruCongNo _THDTCN = TongHopDoiTruCongNo.NewTongHopDoiTruCongNo();
        private bool _checkButToanNo = false;
        private bool _checkHocSinh = false;
        private decimal _tongTien_chungTu_ChungTu;
        private List<long> listCheckTrungTien = new List<long>();
        private decimal _tongTienButToanNo;
        private decimal _tienThue;
        private int _loai = 3;
        private int _loaiDoiTac = 3;
        private DoiTacList _DoiTacList, _HocSinhList;
        private BindingSource doiTacListBindingSource = new BindingSource();
        private BindingSource DanhSachButToanNo_BindingSource = new BindingSource();
        private BindingSource DanhSachButToanCo_BindingSource = new BindingSource();
        public frmDoiTruNoCoTheoTaiKhoan()
        {
            InitializeComponent();
            this.Load += frmDoiTruCongNo_Load;
            this.gridView_DanhSachButToanNo.CustomDrawFooterCell += gridView_DanhSachButToanNo_CustomDrawFooterCell;
            this.gridView_DanhSachButToanCo.CustomDrawFooterCell += gridView_DanhSachButToanCo_CustomDrawFooterCell;           
            this.btnThoat.ItemClick += btnThoat_ItemClick;         
        }
       
        void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void gridView_DanhSachButToanCo_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            _tongTienSumGridbutToanCoChon = 0;
            decimal _soTienChuaDoiTru = 0;
            foreach (GetButToanTheoDoiTuongvaTaiKhoan blchild in DanhSachButToanCo_BindingSource)
            {
                if (blchild.Check == true)
                {
                    _soTienChuaDoiTru += blchild.SoTienChuaDoiTru;
                    _tongTienSumGridbutToanNoChon += blchild.SoTien;
                }
            }

            if (e.Column.FieldName.ToString().ToLower() == "sotien")
            {
                GridSummaryItem summary = e.Info.SummaryItem;
                string summaryText = String.Format("{0:#,###.##}", _tongTienSumGridbutToanCoChon);
                e.Info.DisplayText = summaryText;
            }

            if (e.Column.FieldName.ToString().ToLower() == "sotienchuadoitru")
            {
                GridSummaryItem summary = e.Info.SummaryItem;
                string summaryText = String.Format("{0:#,###.##}", _soTienChuaDoiTru);
                e.Info.DisplayText = summaryText;
            }
        }

        void gridView_DanhSachButToanNo_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            _tongTienSumGridbutToanNoChon = 0;
            decimal _soTienChuaDoiTru = 0;
            foreach (GetButToanTheoDoiTuongvaTaiKhoan blchild in DanhSachButToanNo_BindingSource)
            {
                if (blchild.Check == true)
                {
                    _soTienChuaDoiTru += blchild.SoTienChuaDoiTru;
                    _tongTienSumGridbutToanNoChon += blchild.SoTien;
                }
            }

            if (e.Column.FieldName.ToString().ToLower() == "sotien")
            {
                GridSummaryItem summary = e.Info.SummaryItem;
                string summaryText = String.Format("{0:#,###.##}", _tongTienSumGridbutToanNoChon);
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
        void DoiTuonggridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (isDaLoadComBo)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using (DialogUtil.Wait("Đang tải dữ liệu!","Vui lòng đợi!"))
            {
                DanhSachButToanCo_BindingSource.DataSource = GetButToanTheoDoiTuongvaTaiKhoan.LoadGetButToanTheoDoiTuongvaTaiKhoan(Convert.ToInt32(DoiTuonggridLookUpEdit.EditValue), dtEdit_TuNgay.DateTime.Date, dtEdit_DenNgay.DateTime.Date, Convert.ToInt32(TaiKhoanGridLookUpEdit.EditValue), false);
                gridControl_DanhSachButToanCo.DataSource = DanhSachButToanCo_BindingSource;
                DanhSachButToanNo_BindingSource.DataSource = GetButToanTheoDoiTuongvaTaiKhoan.LoadGetButToanTheoDoiTuongvaTaiKhoan(Convert.ToInt32(DoiTuonggridLookUpEdit.EditValue), dtEdit_TuNgay.DateTime.Date, dtEdit_DenNgay.DateTime.Date, Convert.ToInt32(TaiKhoanGridLookUpEdit.EditValue), true);
                gridControl_DanhSachButToanNo.DataSource = DanhSachButToanNo_BindingSource;

                _checkButToanNo = true;
                _checkHocSinh = false;
                txt_DienGiai.Text = DoiTuonggridLookUpEdit.Text;
            }
        }

        private void DesignGrid()
        {
            DesignGrid_DanhSachButToanNo();
            DesignGrid_DanhSach_chungTu_ChungTu();
        }

        void frmDoiTruCongNo_Load(object sender, EventArgs e)
        {
            _THDTCN.Loai = 3;
            dtmp_Ngay.DateTime = DateTime.Now.Date;
            this.splitContainerControl1.SplitterPosition = Screen.PrimaryScreen.Bounds.Width / 2;
            
            //TaiKhoanList
            HeThongTaiKhoan1 tk = HeThongTaiKhoan1.NewHeThongTaiKhoan1("<<Tất cả>>");
            HeThongTaiKhoan1List taikhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            taikhoanList.Insert(0, tk);
            heThongTaiKhoanListAllBindingSource.DataSource = taikhoanList;
            TaiKhoanGridLookUpEdit.EditValue = HeThongTaiKhoan1List.GetHeThongTaiKhoanBySoHieu("141")[0].MaTaiKhoan;
            //DoiTuongList
            DoiTuongAll doituong = DoiTuongAll.NewDoiTuongAll("<<Tất cả>>");
            DoiTuongAllList doiTuongList = DoiTuongAllList.GetDoiTuongAllList_Tim("", 0); ;
            doiTuongList.Insert(0, doituong);
            doiTuongAllListBindingSource.DataSource = doiTuongList;

            //DesignGrid_DanhSach_chungTu_ChungTu();
            txtSoPhieu.Text = TongHopDoiTruCongNo.NewSoChungTu(DateTime.Now.Date, "DTNC", _THDTCN.Loai);
            this.splitContainerControl1.SplitterPosition = this.splitContainerControl1.Height / 2;

            DateTime _tuNgay = DateTime.Today.Month > 6 ? new DateTime(DateTime.Today.Year, 7, 1) : new DateTime(DateTime.Today.Year - 1, 7, 1);
            DateTime _denNgay = DateTime.Today.Month > 6 ? new DateTime(DateTime.Today.Year + 1, 6, 30) : new DateTime(DateTime.Today.Year, 6, 30);
            dtEdit_DenNgay.DateTime = _denNgay;
            dtEdit_TuNgay.DateTime = _tuNgay;
            isDaLoadComBo = true;
            DesignDoiTuonggridLookUpEdit();
            DesignGrid();
        }
        //DoiTuonggridLookUpEdit
        private void DesignDoiTuonggridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(DoiTuonggridLookUpEdit, doiTuongAllListBindingSource, "TenDoiTuong", "MaDoiTuong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(DoiTuonggridLookUpEdit, new string[] { "TenDoiTuong", "MaQLDoiTuong" }, new string[] { "Đối tượng", "Mã Ql" }, new int[] { 200, 90 }, false);          
        }

        private void DesignGrid_DanhSachButToanNo()
        {
            gridControl_DanhSachButToanNo.DataSource = DanhSachButToanNo_BindingSource;
            HamDungChung.InitGridViewDev(gridView_DanhSachButToanNo, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev_Modify(gridView_DanhSachButToanNo, new string[] { "Check", "SoChungTu", "NgayLap", "SoTien", "SoTienChuaDoiTru", "DienGiai" },
                                new string[] { "Chọn", "Số Chứng Từ", "Ngày ghi sổ", "Số Tiền", "Số chưa đối trừ", "Diễn Giải" },
                                             new int[] { 50, 80, 100, 80, 80, 300 }, true);

            HamDungChung.AlignHeaderColumnGridViewDev(gridView_DanhSachButToanNo, new string[] { "Check", "SoChungTu", "NgayLap", "SoTien", "SoTienChuaDoiTru", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView_DanhSachButToanNo, new string[] { "SoChungTu", "NgayLap", "SoTien", "SoTienChuaDoiTru", "DienGiai" });
            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien", "SoTienChuaDoiTru" }, "#,###.##");
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTien", "SoTienChuaDoiTru" }, "{0:#,###.##}");
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView_DanhSachButToanNo, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView_DanhSachButToanNo, 50);//M

            RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();

            repositoryItemCalcEditSoTien.AutoHeight = false;
            repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditSoTien.Name = "repositoryItemCalcEditSoTien";
            gridView_DanhSachButToanNo.Columns["SoTienChuaDoiTru"].ColumnEdit = repositoryItemCalcEditSoTien;
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_DanhSachButToanNo, new string[] { "SoTien" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_DanhSachButToanNo, new string[] { "SoTien" }, "{0:#,###.##}");

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_DanhSachButToanNo, new string[] { "SoTienChuaDoiTru" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_DanhSachButToanNo, new string[] { "SoTienChuaDoiTru" }, "{0:#,###.##}");

            gridView_DanhSachButToanNo.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            //gridView1.DoubleClick += gridView1_DoubleClick;
        }

        void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GetButToanTheoDoiTuongvaTaiKhoan obj = (GetButToanTheoDoiTuongvaTaiKhoan)DanhSachButToanNo_BindingSource.Current;
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

        private void DesignGrid_DanhSach_chungTu_ChungTu()
        {
            gridControl_DanhSachButToanCo.DataSource = DanhSachButToanCo_BindingSource;
            HamDungChung.InitGridViewDev(gridView_DanhSachButToanCo, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev_Modify(gridView_DanhSachButToanCo, new string[] { "Check", "SoChungTu", "NgayLap", "SoTien", "SoTienChuaDoiTru", "DienGiai" },
                                new string[] { "Chọn", "Số Chứng Từ", "Ngày ghi sổ", "Số Tiền", "Số chưa đối trừ", "Diễn Giải" },
                                             new int[] { 50, 80, 100, 80, 80, 300 }, true);

            HamDungChung.AlignHeaderColumnGridViewDev(gridView_DanhSachButToanCo, new string[] { "Check", "SoChungTu", "NgayLap", "SoTien", "SoTienChuaDoiTru", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView_DanhSachButToanCo, new string[] { "SoChungTu", "NgayLap", "SoTien", "SoTienChuaDoiTru", "DienGiai" });            
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView_DanhSachButToanCo, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView_DanhSachButToanCo, 50);//M

            RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();

            repositoryItemCalcEditSoTien.AutoHeight = false;
            repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditSoTien.Name = "repositoryItemCalcEditSoTien";
            gridView_DanhSachButToanCo.Columns["SoTienChuaDoiTru"].ColumnEdit = repositoryItemCalcEditSoTien;
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_DanhSachButToanCo, new string[] { "SoTien" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_DanhSachButToanCo, new string[] { "SoTien" }, "{0:#,###.##}");

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_DanhSachButToanCo, new string[] { "SoTienChuaDoiTru" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_DanhSachButToanCo, new string[] { "SoTienChuaDoiTru" }, "{0:#,###.##}");

            gridView_DanhSachButToanCo.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
        }       

        private void btnDanhSachDoiTru_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDSDoiTruCongNo frm = new frmDSDoiTruCongNo(_loai);
            frm.Show();
            frm.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SaveData()
        {
            bool checkButToanNo = false;
            bool check_chungTu_ChungTu = false;
            if (string.IsNullOrEmpty(txtSoPhieu.Text.ToString()))
            {
                MessageBox.Show("Chưa nhập số phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (_tongTienSumGridbutToanNoChon != _tongTienSumGridTT)
            //{
            //    MessageBox.Show("Số tiền hóa đơn và chứng từ không bằng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            if (gridControl_DanhSachButToanNo.DataSource == null)
            {
                MessageBox.Show("Chưa chọn dữ liệu phát sinh nợ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (gridControl_DanhSachButToanCo.DataSource == null)
            {
                MessageBox.Show("Chưa có dữ liệu phát sinh có!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _tongTien_chungTu_ChungTu = 0;
            _tongTienButToanNo = 0;
            _tienThue = 0;
            _danhSachButToanCoChon.Clear();
            _danhSachButToanNoChon.Clear();
            if (_checkButToanNo == true)
            {
                foreach (GetButToanTheoDoiTuongvaTaiKhoan blchild in DanhSachButToanCo_BindingSource)
                {
                    if (blchild.Check == true)
                    {
                        _danhSachButToanCoChon.Add(blchild);
                        _tongTien_chungTu_ChungTu += blchild.SoTienChuaDoiTru;
                        //_tienThue += blchild.ThueVAT;
                        check_chungTu_ChungTu = true;
                    }
                }
                foreach (GetButToanTheoDoiTuongvaTaiKhoan blchild in DanhSachButToanNo_BindingSource)
                {
                    if (blchild.Check == true)
                    {
                        _danhSachButToanNoChon.Add(blchild);
                        _tongTienButToanNo += blchild.SoTienChuaDoiTru;
                        checkButToanNo = true;
                    }
                }
            }
            if (check_chungTu_ChungTu == false)
            {
                MessageBox.Show("Chưa chọn chứng từ có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (checkButToanNo == false)
            {
                MessageBox.Show("Chưa chọn chứng từ nợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sDienGiai = "Đối trừ ";
            foreach (GetButToanTheoDoiTuongvaTaiKhoan butToanCoChon in _danhSachButToanCoChon)
            {
                if (butToanCoChon.CheckDaTraNo == false)
                {
                    foreach (GetButToanTheoDoiTuongvaTaiKhoan butToanNoChon in _danhSachButToanNoChon)
                    {
                        if (butToanNoChon.CheckDaTraNo == false)
                        {                           
                            _chungTu_ChungTu = ChungTu_ChungTuChild.NewChungTu_ChungTuChild();

                            _THDTCN.SoPhieu = txtSoPhieu.EditValue.ToString();
                            _THDTCN.DienGiai = txt_DienGiai.Text;
                            _THDTCN.NgayLap = (DateTime)dtmp_Ngay.DateTime;
                            _THDTCN.Loai = 3;                          
                            _chungTu_ChungTu.MaDoiTuong = Convert.ToInt64(DoiTuonggridLookUpEdit.EditValue);                            
                                if (butToanNoChon.SoTienChuaDoiTru == butToanCoChon.SoTienChuaDoiTru)
                                {
                                    _chungTu_ChungTu.SoTien = butToanNoChon.SoTien;                                    
                                    _chungTu_ChungTu.IDChungTuRef = butToanNoChon.MaChungTu;
                                    _chungTu_ChungTu.SoChungTuRef = butToanNoChon.SoChungTu;
                                    _chungTu_ChungTu.IDChungTu = butToanCoChon.MaChungTu;
                                     _chungTu_ChungTu.NgayCanTru = butToanCoChon.NgayLap;
                                if ((Int32)TaiKhoanGridLookUpEdit.EditValue == 46)
                                    _chungTu_ChungTu.RefType = 1;
                                    _chungTu_ChungTu.NoiDung = butToanNoChon.DienGiai + " - " + butToanCoChon.DienGiai;
                                    _chungTu_ChungTu.MaDoiTuong = Convert.ToInt64(DoiTuonggridLookUpEdit.EditValue.ToString());
                                    butToanCoChon.SoTienChuaDoiTru = 0;
                                    butToanNoChon.SoTienChuaDoiTru = 0;
                                    if (butToanNoChon.MaChungTu == 0 || butToanCoChon.MaChungTu==0)
                                    {
                                        _chungTu_ChungTu.IsCanTruSoDauKy = true;                                        
                                    }
                                    else
                                    {
                                        _chungTu_ChungTu.IsCanTruSoDauKy = false;                                        
                                    }

                                    _THDTCN.ChungTu_ChungTuChildList.Add(_chungTu_ChungTu);

                                    butToanNoChon.CheckDaTraNo = true;
                                    butToanCoChon.CheckDaTraNo = true;
                                    break;                                    
                                }
                                else if (butToanNoChon.SoTienChuaDoiTru < butToanCoChon.SoTienChuaDoiTru)    //lay so tien chung tu lam so tien thanh toan
                                {
                                    _chungTu_ChungTu.SoTien = butToanNoChon.SoTien;
                                    _chungTu_ChungTu.IDChungTuRef = butToanNoChon.MaChungTu;
                                    _chungTu_ChungTu.SoChungTuRef = butToanNoChon.SoChungTu;
                                    _chungTu_ChungTu.IDChungTu = butToanCoChon.MaChungTu;
                                    _chungTu_ChungTu.NgayCanTru = butToanCoChon.NgayLap;
                                if ((Int32)TaiKhoanGridLookUpEdit.EditValue == 46)
                                    _chungTu_ChungTu.RefType = 1;
                                    _chungTu_ChungTu.NoiDung = butToanNoChon.DienGiai + " - " + butToanCoChon.DienGiai;
                                    _chungTu_ChungTu.MaDoiTuong = Convert.ToInt64(DoiTuonggridLookUpEdit.EditValue.ToString());
                                    //butToanCoChon.SoTienConNo = butToanCoChon.SoTienConNo - butToanNoChon.SoTienChuaDoiTru;

                                    if (butToanNoChon.MaChungTu == 0 || butToanCoChon.MaChungTu==0)
                                    {
                                        _chungTu_ChungTu.IsCanTruSoDauKy = true;                                      
                                    }
                                    else
                                    {
                                        _chungTu_ChungTu.IsCanTruSoDauKy = false;                                      
                                    }

                                    _THDTCN.ChungTu_ChungTuChildList.Add(_chungTu_ChungTu);
                                    butToanNoChon.CheckDaTraNo = true;
                                }
                                else
                                {
                                    _chungTu_ChungTu.SoTien = butToanCoChon.SoTienChuaDoiTru;
                                    _chungTu_ChungTu.IDChungTuRef = butToanNoChon.MaChungTu;
                                    _chungTu_ChungTu.SoChungTuRef = butToanNoChon.SoChungTu;
                                    _chungTu_ChungTu.IDChungTu = butToanCoChon.MaChungTu;
                                     _chungTu_ChungTu.NgayCanTru = butToanCoChon.NgayLap;
                                if ((Int32)TaiKhoanGridLookUpEdit.EditValue==46)
                                        _chungTu_ChungTu.RefType = 1;
                                    _chungTu_ChungTu.NoiDung = butToanNoChon.DienGiai + " - " + butToanCoChon.DienGiai;

                                    if (butToanNoChon.MaChungTu == 0 || butToanCoChon.MaChungTu==0)
                                    {
                                        _chungTu_ChungTu.IsCanTruSoDauKy = true;                                     
                                    }
                                    else
                                    {
                                        _chungTu_ChungTu.IsCanTruSoDauKy = false;                                      
                                    }

                                    _THDTCN.ChungTu_ChungTuChildList.Add(_chungTu_ChungTu);
                                    butToanCoChon.CheckDaTraNo = true;
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
            DanhSachButToanCo_BindingSource.DataSource = GetButToanTheoDoiTuongvaTaiKhoan.LoadGetButToanTheoDoiTuongvaTaiKhoan(Convert.ToInt32(DoiTuonggridLookUpEdit.EditValue), dtEdit_TuNgay.DateTime, dtEdit_DenNgay.DateTime, Convert.ToInt32(TaiKhoanGridLookUpEdit.EditValue), false);
            gridControl_DanhSachButToanCo.DataSource = DanhSachButToanCo_BindingSource;
            DanhSachButToanNo_BindingSource.DataSource = GetButToanTheoDoiTuongvaTaiKhoan.LoadGetButToanTheoDoiTuongvaTaiKhoan(Convert.ToInt32(DoiTuonggridLookUpEdit.EditValue), dtEdit_TuNgay.DateTime, dtEdit_DenNgay.DateTime, Convert.ToInt32(TaiKhoanGridLookUpEdit.EditValue), true);
            gridControl_DanhSachButToanNo.DataSource = DanhSachButToanNo_BindingSource;          
            txtSoPhieu.Text = TongHopDoiTruCongNo.NewSoChungTu(DateTime.Now.Date, "DTNC", 3);
        }

        private void btnLayDuLieu_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}