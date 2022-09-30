using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using Infragistics.Win;

// A long sua in
namespace PSC_ERP.UserInterface.ThuChi
{
    public partial class frmThuChi_CacQuy : Form
    {

        #region properties
        private ChungTu_CacLoaiQuy _chungTu_CacLoaiQuy;// = ChungTu_CacLoaiQuy.NewChungTu_CacLoaiQuy();
        private ChungTu_CacLoaiQuyList _chungTu_CacLoaiQuyList;// = ChungTu_CacLoaiQuyList.NewChungTu_CacLoaiQuyList();
        HeThongTaiKhoan1List _taiKhoanNoList, _taiKhoanCoList;// =HeThongTaiKhoan1List.NewHeThongTaiKhoan1List();
        DoiTuongAllList _doiTuongList;// = DoiTuongAllList.NewDoiTuongAllList();
        DoiTuongThuChiList _doiTuongThuChiList;// = DoiTuongThuChiList.NewDoiTuongThuChiList();
        LoaiThuChi_CacQuyList _loaiThuChiList;// = LoaiThuChiCongDoanList.NewLoaiThuChiCongDoanList();
        ButToan_CacQuyList _butToan_CacQuyList;

        int maLoaiChungTu = 0;
        int maLoaiThuChiCD = 0;
        long maDoiTuong;
        ReportDocument Report;
        DataSet dataset;
        DataSet dataSet = new DataSet();
        int UserID = ERP_Library.Security.CurrentUser.Info.UserID;
        long MaChungTu = 0;

        TamUng_QC1TLList _tamUngList = TamUng_QC1TLList.NewTamUng_QC1TLList();

        bool _changeNgayLap = false;
        #endregion

        #region Loads
        public frmThuChi_CacQuy()
        {
            InitializeComponent();

            this.bdDanhSachChungTu.DataSource = typeof(ChungTu_CacLoaiQuyList);
            this.bdChungTu.DataSource = typeof(ChungTu_CacLoaiQuy);
            bdNoTaiKhoan.DataSource = typeof(HeThongTaiKhoan1List);
            bdCoTaiKhoan.DataSource = typeof(HeThongTaiKhoan1List);
            bdDoiTuong.DataSource = typeof(DoiTuongAllList);
            bdButtoan.DataSource = typeof(ButToan_CacQuyList);
            bdLoaiThuChi.DataSource = typeof(LoaiThuChi_CacQuyList);
            this.bdChungTu_DeNghi.DataSource = typeof(ChungTu_DeNghiChuyenKhoanNgoaiList);

        }

        private void frmThuChi_CongDoan_Load(object sender, EventArgs e)
        {
            _chungTu_CacLoaiQuyList = ChungTu_CacLoaiQuyList.GetChungTu_CacLoaiQuyList(Convert.ToDateTime(dtu_NgayBatDau.Value), Convert.ToDateTime(dtu_NgayKetThuc.Value), Convert.ToInt32(cmb_LoaiChungTu.Value));
            this.bdDanhSachChungTu.DataSource = _chungTu_CacLoaiQuyList;

            _chungTu_CacLoaiQuy = ChungTu_CacLoaiQuy.NewChungTu_CacLoaiQuy();
            this.bdChungTu.DataSource = _chungTu_CacLoaiQuy;

            this.bdButtoan.DataSource = _chungTu_CacLoaiQuy.ButToanQuyList;

            _taiKhoanNoList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            _taiKhoanCoList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            bdNoTaiKhoan.DataSource = _taiKhoanNoList;
            bdCoTaiKhoan.DataSource = _taiKhoanCoList;

            _doiTuongList = DoiTuongAllList.GetDoiTuongAllList();
            DoiTuongAll doituong = DoiTuongAll.NewDoiTuongAll("Không Có");
            _doiTuongList.Add(doituong);
            bdDoiTuong.DataSource = _doiTuongList;

            LoaiTienList _loaiTienList = LoaiTienList.GetLoaiTienList();
            _loaiTienList.Add(LoaiTien.NewLoaiTien(0, "Chưa chọn"));
            bdLoaiTien.DataSource = _loaiTienList;

            LoaiQuyList _loaiQuyList = LoaiQuyList.GetLoaiQuyList();
            _loaiQuyList.Insert(0, LoaiQuy.NewLoaiQuy("Chưa chọn"));
            bdLoaiQuy.DataSource = _loaiQuyList;

            LoaiThuChi_CacQuyList _loaiThuChi_CacQuyList = LoaiThuChi_CacQuyList.GetLoaiThuChi_CacQuyList();
            _loaiThuChi_CacQuyList.Insert(0, LoaiThuChi_CacQuy.NewLoaiThuChi_CacQuy("Chưa chọn"));
            bdLoaiThuChi.DataSource = _loaiThuChi_CacQuyList;

            cbLoaiThuChi.Value = 0;
            cbLoaiThuChi.SelectedIndex = 0;
            cmb_LoaiChungTu.SelectedIndex = 0;

            int LoaiThuChi = Convert.ToInt32(cbLoaiThuChi.Value);
            _chungTu_CacLoaiQuy.SoChungTu = ChungTu_CacLoaiQuy.LaySoChungTuMax(LoaiThuChi, DateTime.Today.Year);

            TaoCauTrucBang();
        }

        private void grdu_DSChungTu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //HamDungChung h = new HamDungChung();
            //h.ultragrdEmail_InitializeLayout(sender, e);

            grdu_DSChungTu.DisplayLayout.Bands[1].Hidden = true;
            foreach (UltraGridColumn col in this.grdu_DSChungTu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
                col.CellActivation = Activation.ActivateOnly;
            }

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 1;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";

            //grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            //grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            //grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            //grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###.##";
            //grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTienButToan"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTienButToan"].Header.Caption = "Số Tiền";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTienButToan"].Header.VisiblePosition = 2;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTienButToan"].Format = "###,###,###,###.##";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTienButToan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TKNo"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TKNo"].Header.Caption = "TK Nợ";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TKNo"].Header.VisiblePosition = 3;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TKNo"].Width = 90;

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TKCo"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TKCo"].Header.Caption = "TK Có";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TKCo"].Header.VisiblePosition = 4;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TKCo"].Width = 90;

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Header.Caption = "Loại Thu-Chi";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Header.VisiblePosition = 5;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].EditorComponent = cmb_LoaiChungTu;

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["LoaiQuy"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["LoaiQuy"].Header.Caption = "Loại quỹ";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["LoaiQuy"].Header.VisiblePosition = 6;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["LoaiQuy"].Width = 200;

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["ChuongTrinh"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["ChuongTrinh"].Header.Caption = "Chương trình";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["ChuongTrinh"].Header.VisiblePosition = 7;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["ChuongTrinh"].Width = 200;

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 8;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 200;

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Đối Tác ";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 9;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TenDoiTac"].Width = 150;

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa chỉ";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 10;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["DiaChi"].Width = 200;


        }

        private void cbDoiTuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cmb_DoiTuong, "TenDoiTuong");
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cmb_DoiTuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Hidden = false;
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "Tên Đối Tượng";
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 0;
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Width = 350;

            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa chỉ";
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Width = 300;
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 1;
        }

        private void ugrButToan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.ugrButToan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Hidden = false;
            ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Header.Caption = "Nợ Tài Khoản";
            ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Header.VisiblePosition = 0;
            ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].EditorComponent = ultraCombo_NoTaiKhoan;
            ugrButToan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Width = ultraCombo_NoTaiKhoan.Width;

            ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].Hidden = false;
            ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].Header.Caption = "Có Tài Khoản";
            ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].Header.VisiblePosition = 1;
            ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].EditorComponent = ultraCombo_CoTaiKhoan;
            ugrButToan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].Width = ultraCombo_CoTaiKhoan.Width;

            ugrButToan.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            ugrButToan.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền Chi Tiết";
            ugrButToan.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            ugrButToan.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";
            ugrButToan.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            ugrButToan.DisplayLayout.Bands[0].Columns["DienGiai"].Width = ultraCombo_CoTaiKhoan.Width;

            ugrButToan.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            ugrButToan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            ugrButToan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            ugrButToan.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 350;
        }

        private void ultraCombo_CoTaiKhoan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            FilterCombo f = new FilterCombo(ultraCombo_CoTaiKhoan, "SoHieuTK");
            foreach (UltraGridColumn col in this.ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;

        }

        private void ultraCombo_NoTaiKhoan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(ultraCombo_NoTaiKhoan, "SoHieuTK");

            foreach (UltraGridColumn col in this.ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;
        }
        #endregion

        #region Process
        private void Reload(long maChungTu)
        {
            _chungTu_CacLoaiQuy = ChungTu_CacLoaiQuy.GetChungTu_CacLoaiQuy(maChungTu);
            this.bdChungTu.DataSource = _chungTu_CacLoaiQuy;
            bdButtoan.DataSource = _chungTu_CacLoaiQuy.ButToanQuyList;
            this.cbLoaiThuChi.Value = _chungTu_CacLoaiQuy.MaLoaiChungTu;

            cbLoaiThuChi.Value = _chungTu_CacLoaiQuy.MaLoaiChungTu;
            if (_chungTu_CacLoaiQuy.MaDoiTuong == 0)
            {
                txt_TenDoiTac.Text = _chungTu_CacLoaiQuy.TenDoiTac;
                txt_DiaChi.Text = _chungTu_CacLoaiQuy.DiaChi; ;
            }
        }

        private void DeleteChungTu(long maChungTu)
        {
            if (MessageBox.Show("Bạn có muốn xóa chứng từ: " + _chungTu_CacLoaiQuy.SoChungTu + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //ChungTu_CacLoaiQuy.DeleteChungTu_CacLoaiQuy(maChungTu);
                ChungTu_CacLoaiQuy.DeleteChungTu_CacLoaiQuy(_chungTu_CacLoaiQuy);
                MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Event
        private void tbllbl_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                ugrButToan.UpdateData();
                _chungTu_CacLoaiQuy.ApplyEdit();
                this.bdChungTu.EndEdit();
                this.bdButtoan.EndEdit();

                //if (_chungTu_CacLoaiQuy.MaDoiTuong == 0 & !chk_DoiTuongNgoai.Checked)
                //{
                //    MessageBox.Show("Đối tượng chưa được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                if (_chungTu_CacLoaiQuy.MaLoaiChungTu == 0)
                {
                    MessageBox.Show("Loại Thu/Chi chưa có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_chungTu_CacLoaiQuy.SoTien == 0)
                {
                    MessageBox.Show("Số Tiền chưa có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_chungTu_CacLoaiQuy.ButToanQuyList.Count == 0)
                {
                    MessageBox.Show("Chưa định khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //if (_chungTu_CacLoaiQuy.MaLoaiThuChi== 0)
                //{
                //    MessageBox.Show("Chưa chọn chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                decimal soTienButToan = 0;
                foreach (ButToan_CacQuy bt in _chungTu_CacLoaiQuy.ButToanQuyList)
                {
                    //Kiem tra Tam Ung
                    HeThongTaiKhoan1 httkno = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan);
                    HeThongTaiKhoan1 httkco = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.CoTaiKhoan);
                    string noTK = httkno.SoHieuTK;
                    string CoTK = httkco.SoHieuTK;
                    if (noTK == "312" || noTK == "312.5" || noTK == "312.9" || noTK == "312.93" || CoTK == "312" || CoTK == "312.5" || CoTK == "312.9" || CoTK == "312.93")
                    //if (noTK.Contains("312") )
                    {
                        if (_chungTu_CacLoaiQuy.TamUng_QC1TLList.Count == 0)
                        {
                            MessageBox.Show(this, "Vui lòng chọn nhập tạm ứng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }

                    soTienButToan += bt.SoTien;
                }
                if (_chungTu_CacLoaiQuy.SoTien != soTienButToan)
                {
                    MessageBox.Show("Số tiền Chứng Từ chưa bằng số tiền Định khoản.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ChungTu_CacLoaiQuy.KiemTraSoChungTu(_chungTu_CacLoaiQuy.SoChungTu, _chungTu_CacLoaiQuy.MachungtuCacquy) == true)
                {
                    MessageBox.Show(this, "Số Chứng Từ Đã Có Vui Lòng Nhập SCT Khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _chungTu_CacLoaiQuy.MaLoaiChungTu = Convert.ToInt32(cbLoaiThuChi.Value);
                _chungTu_CacLoaiQuy.ApplyEdit();
                _chungTu_CacLoaiQuy.Save();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.bdChungTu.DataSource = _chungTu_CacLoaiQuy;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_DoiTuong_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            frmTimKhachHang _frmKH = new frmTimKhachHang();
            if (_frmKH.ShowDialog(this) != DialogResult.OK)
            {
                _chungTu_CacLoaiQuy.MaDoiTuong = _frmKH._DoiTuongAll.MaDoiTuong;
                _chungTu_CacLoaiQuy.TenDoiTac = _frmKH._DoiTuongAll.TenDoiTuong;
                txt_TenDoiTac.Text = _frmKH._DoiTuongAll.TenDoiTuong;
                _chungTu_CacLoaiQuy.DiaChi = _frmKH._DoiTuongAll.DiaChi;
                txt_DiaChi.Text = _frmKH._DoiTuongAll.DiaChi; ;
            }

            bdChungTu.DataSource = _chungTu_CacLoaiQuy;
        }

        private void chk_DoiTuongNgoai_CheckedChanged(object sender, EventArgs e)
        {
            bool bCheck = chk_DoiTuongNgoai.Checked;
            cmb_DoiTuong.Enabled = !bCheck;
            txt_TenDoiTac.Enabled = bCheck;
            txt_DiaChi.Enabled = bCheck;

            if (bCheck)
            {
                cmb_DoiTuong.Value = 0;
            }
        }

        private void cmb_DoiTuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_DoiTuong.ActiveRow != null && !chk_DoiTuongNgoai.Checked)
            {
                _chungTu_CacLoaiQuy.MaDoiTuong = Convert.ToInt32(cmb_DoiTuong.ActiveRow.Cells["MaDoiTuong"].Value);
                _chungTu_CacLoaiQuy.TenDoiTac = Convert.ToString(cmb_DoiTuong.ActiveRow.Cells["TenDoiTuong"].Value);
                _chungTu_CacLoaiQuy.DiaChi = Convert.ToString(cmb_DoiTuong.ActiveRow.Cells["DiaChi"].Value);
            }
        }

        private void bt_Tim_Click(object sender, EventArgs e)
        {
            _chungTu_CacLoaiQuyList = ChungTu_CacLoaiQuyList.GetChungTu_CacLoaiQuyList(dtu_NgayBatDau.DateTime.Date, dtu_NgayKetThuc.DateTime.Date, Convert.ToInt32(cmb_LoaiChungTu.Value));
            this.bdDanhSachChungTu.DataSource = _chungTu_CacLoaiQuyList;
        }

        private void grdu_DSChungTu_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            int maChungTu = Convert.ToInt32(grdu_DSChungTu.ActiveRow.Cells["MaChungTuCacQuy"].Value);
            Reload(maChungTu);
            tabControl1.SelectedIndex = 0;
        }

        private void tlslbl_Them_Click(object sender, EventArgs e)
        {
            _chungTu_CacLoaiQuy = ChungTu_CacLoaiQuy.NewChungTu_CacLoaiQuy();
            this.bdChungTu.DataSource = _chungTu_CacLoaiQuy;

            TaoBindingDanhSach();

            this.bdButtoan.DataSource = _chungTu_CacLoaiQuy.ButToanQuyList;
        }

        private void tsllbl_Xoa_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 0)
            {
                int maChungTu = Convert.ToInt32(grdu_DSChungTu.ActiveRow.Cells["MaChungTu"].Value);
                Reload(maChungTu);
                tabControl1.SelectedIndex = 0;
            }
            DeleteChungTu(_chungTu_CacLoaiQuy.MachungtuCacquy);
            Reload(_chungTu_CacLoaiQuy.MachungtuCacquy);

            //Cập nhật lại danh sách để tránh xóa rồi mà còn thấy chứng từ
            _chungTu_CacLoaiQuyList = ChungTu_CacLoaiQuyList.GetChungTu_CacLoaiQuyList(dtu_NgayBatDau.DateTime.Date, dtu_NgayKetThuc.DateTime.Date, Convert.ToInt32(cmb_LoaiChungTu.Value));
            this.bdDanhSachChungTu.DataSource = _chungTu_CacLoaiQuyList;

            TaoBindingDanhSach();
        }

        private void ugrButToan_AfterRowInsert(object sender, RowEventArgs e)
        {
            decimal SoTien = 0;
            ((ButToan_CacQuy)this.bdButtoan.Current).DienGiai = _chungTu_CacLoaiQuy.DienGiai;
            foreach (ButToan_CacQuy cd in _chungTu_CacLoaiQuy.ButToanQuyList)
            {
                SoTien += cd.SoTien;
            }
            ((ButToan_CacQuy)this.bdButtoan.Current).SoTien = mnu_SoTien.Value - SoTien;

            //if (maLoaiChungTu == 2)
            //{
            //    ((CongDoan_ButToan)this.bdButtoan.Current).NoTaiKhoan = 161;
            //    ((CongDoan_ButToan)this.bdButtoan.Current).CoTaiKhoan = 615;
            //}
            //else if (maLoaiChungTu == 3)
            //{
            //    ((CongDoan_ButToan)this.bdButtoan.Current).CoTaiKhoan = 161;
            //    ((CongDoan_ButToan)this.bdButtoan.Current).NoTaiKhoan = 615;
            //}

        }
        #endregion

        private void InPhieu(int loai, long maChungTu)
        {
            SqlCommand command;
            SqlDataAdapter adapter;
            DataTable table;
            string phieuThuChi = string.Empty;
            string soTienChu = string.Empty;
            string nguoiNhanNopTien = string.Empty;
            ChungTu_CacLoaiQuy _chungTu = ChungTu_CacLoaiQuy.GetChungTu_CacLoaiQuy(maChungTu);
            soTienChu = ERP_Library.HamDungChung.DocTien(_chungTu.ThanhTien);
            if (_chungTu.MaLoaiChungTu != 16)
            {

                if (_chungTu.MaLoaiChungTu == 2)
                {
                    phieuThuChi = "Phiếu Thu";
                    nguoiNhanNopTien = "Người Nộp Tiền";
                    if (loai == 4)
                    {
                        Report = new Report.CongNo.PhieuThuCMTL();
                    }
                    else
                    {
                        Report = new Report.CongNo.PhieuThuCMTLA5();
                    }
                }
                else
                {
                    phieuThuChi = "Phiếu Chi";
                    nguoiNhanNopTien = "Người Nhận Tiền";
                    if (loai == 4)
                    {
                        Report = new Report.CongNo.PhieuChiCMTL();
                    }
                    else
                    {
                        Report = new Report.CongNo.PhieuChiCMTLA5();
                    }
                }
                DateTime ngayDauNam = new DateTime(DateTime.Today.Date.Year, 1, 1);
                command = new SqlCommand();
                dataset = new DataSet();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_ChungTu_CacQuy_PhieuChi";
                command.Parameters.AddWithValue("@MaPhieuChi", _chungTu_CacLoaiQuy.MachungtuCacquy);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_PhieuChi_CongDoan;1";

                SqlCommand _SqlCommand;
                DataTable table1;
                _SqlCommand = new SqlCommand();
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.CommandText = "spd_LayNoCoTaiKhoan_CacQuy";
                _SqlCommand.Parameters.AddWithValue("@MaChungTu", _chungTu_CacLoaiQuy.MachungtuCacquy);
                _SqlCommand.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                adapter = new SqlDataAdapter(_SqlCommand);
                table1 = new DataTable();
                adapter.Fill(table1);
                table1.TableName = "spd_LayNoCoTaiKhoanCongDoan;1";

                dataset.Tables.Add(table);
                dataset.Tables.Add(table1);
                Report.SetDataSource(dataset);

                Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                Report.SetParameterValue("_PhieuThuChi", phieuThuChi);
                Report.SetParameterValue("_soTienChu", soTienChu);
                Report.SetParameterValue("_nguoiNhanNopTien", nguoiNhanNopTien);
                Report.SetParameterValue("_keToanTruong", ERP_Library.Security.CurrentUser.Info.TenKeToanTruong);
                Report.SetParameterValue("_thuQuy", ERP_Library.Security.CurrentUser.Info.TenThuQuy);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
            else
            {
                MessageBox.Show(this, "Vui lòng Chọn In Bảng Kê ", "Thống Báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void tlslbl_InPhieuA5_Click(object sender, EventArgs e)
        {
            //A5
            if (tabControl1.SelectedIndex == 0)
            {
                InPhieu(5, _chungTu_CacLoaiQuy.MachungtuCacquy);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                int maChungTu = 0;
                maChungTu = Convert.ToInt32(grdu_DSChungTu.ActiveRow.Cells["MaChungTuCacQuy"].Value);


                SqlCommand command;

                SqlDataAdapter adapter;
                DataTable table;

                string phieuThuChi = string.Empty;
                string soTienChu = string.Empty;
                string nguoiNhanNopTien = string.Empty;
                ChungTu_CacLoaiQuy ct = ChungTu_CacLoaiQuy.GetChungTu_CacLoaiQuy(maChungTu);
                soTienChu = ERP_Library.HamDungChung.DocTien(ct.ThanhTien);
                if (ct.MaLoaiChungTu != 16)
                {
                    if (ct.MaLoaiChungTu == 2)
                    {
                        phieuThuChi = "PHIẾU THU";
                        nguoiNhanNopTien = "Người Nộp Tiền";
                        Report = new Report.CongNo.PhieuThuCMTLA5();
                    }
                    else
                    {
                        phieuThuChi = "PHIẾU CHI";
                        nguoiNhanNopTien = "Người Nhận Tiền";
                        Report = new Report.CongNo.PhieuChiCMTLA5();
                    }
                    DateTime ngayDauNam = new DateTime(DateTime.Today.Date.Year, 1, 1);
                    //Report = new Report.CongNo.PhieuThuCMTLA5();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ChungTu_CacQuy_PhieuChi";
                    command.Parameters.AddWithValue("@MaPhieuChi", ct.MachungtuCacquy);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_CongNo_PhieuChi_CongDoan;1";


                    dataset.Tables.Add(table);

                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                    Report.SetParameterValue("_PhieuThuChi", phieuThuChi);
                    Report.SetParameterValue("_soTienChu", soTienChu);
                    Report.SetParameterValue("_nguoiNhanNopTien", nguoiNhanNopTien);
                    Report.SetParameterValue("_keToanTruong", ERP_Library.Security.CurrentUser.Info.TenKeToanTruong);
                    Report.SetParameterValue("_thuQuy", ERP_Library.Security.CurrentUser.Info.TenThuQuy);


                    frmHienThiReport dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(this, "Vui lòng Chọn In Bảng Kê ", "Thống Báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void tlslbl_InPhieuA4_Click(object sender, EventArgs e)
        {
            //A4
            if (tabControl1.SelectedIndex == 0)
            {
                InPhieu(4, _chungTu_CacLoaiQuy.MachungtuCacquy);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (grdu_DSChungTu.ActiveRow != null)
                {
                    foreach (UltraGridRow row in grdu_DSChungTu.Selected.Rows)
                    {
                        int maChungTu = Convert.ToInt32(row.Cells["MaChungtuCacQuy"].Value);
                        InPhieu(4, maChungTu);
                    }
                }
            }
        }

        private void tlslbl_InBangKeA5_Click(object sender, EventArgs e)
        {
            long maChungTu = 0;
            if (tabControl1.SelectedIndex == 0)
            {
                maChungTu = _chungTu_CacLoaiQuy.MachungtuCacquy;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                foreach (UltraGridRow row in grdu_DSChungTu.Selected.Rows)
                {
                    maChungTu = Convert.ToInt32(row.Cells["MaChungTuCacQuy"].Value);
                }
            }
            ChungTu_CacLoaiQuy cd = ChungTu_CacLoaiQuy.GetChungTu_CacLoaiQuy(maChungTu);
            if (cd.MaLoaiChungTu == 16)
            {
                SqlCommand command;

                SqlDataAdapter adapter;
                DataTable table;

                string phieuThuChi = string.Empty;
                string soTienChu = string.Empty;
                string nguoiNhanNopTien = string.Empty;
                // CongDoan_ChungTu _CDChungTu = CongDoan_ChungTu.GetCongDoan_ChungTu(maChungTu);
                soTienChu = ERP_Library.HamDungChung.DocTien(cd.ThanhTien);

                Report = new Report.CongNo.BangKeCongDoanA5();
                command = new SqlCommand();

                dataset = new DataSet();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_ChungTu_CacQuy_PhieuChi";
                command.Parameters.AddWithValue("@MaPhieuChi", cd.MachungtuCacquy);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_PhieuChi_CongDoan;1";

                SqlCommand _SqlCommand;
                DataTable table1;
                _SqlCommand = new SqlCommand();
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.CommandText = "spd_LayNoCoTaiKhoan_CacQuy";
                _SqlCommand.Parameters.AddWithValue("@MaChungTu", cd.MachungtuCacquy);
                _SqlCommand.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                adapter = new SqlDataAdapter(_SqlCommand);
                table1 = new DataTable();
                adapter.Fill(table1);
                table1.TableName = "spd_LayNoCoTaiKhoanCongDoan;1";

                dataset.Tables.Add(table);
                dataset.Tables.Add(table1);
                Report.SetDataSource(dataset);

                Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_NguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                Report.SetParameterValue("_ThuTruongDonVi", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                Report.SetParameterValue("_BangChu", soTienChu);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Vui lòng Chọn In Phiếu Thu/Chi ", "Thống Báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void tlslbl_InBangKeA4_Click(object sender, EventArgs e)
        {
            long maChungTu = 0;
            if (tabControl1.SelectedIndex == 0)
            {
                maChungTu = _chungTu_CacLoaiQuy.MachungtuCacquy;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                foreach (UltraGridRow row in grdu_DSChungTu.Selected.Rows)
                {
                    maChungTu = Convert.ToInt32(row.Cells["MaChungTuCacQuy"].Value);
                }
            }
            ChungTu_CacLoaiQuy cd = ChungTu_CacLoaiQuy.GetChungTu_CacLoaiQuy(maChungTu);
            if (cd.MaLoaiChungTu == 16)
            {

                SqlCommand command;

                SqlDataAdapter adapter;
                DataTable table;

                string phieuThuChi = string.Empty;
                string soTienChu = string.Empty;
                string nguoiNhanNopTien = string.Empty;
                soTienChu = ERP_Library.HamDungChung.DocTien(cd.ThanhTien);

                Report = new Report.CongNo.BangKeCongDoanA4();
                command = new SqlCommand();

                dataset = new DataSet();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_ChungTu_CacQuy_PhieuChi";
                command.Parameters.AddWithValue("@MaPhieuChi", cd.MachungtuCacquy);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_PhieuChi_CongDoan;1";

                SqlCommand _SqlCommand;
                DataTable table1;
                _SqlCommand = new SqlCommand();
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.CommandText = "spd_LayNoCoTaiKhoan_CacQuy";
                _SqlCommand.Parameters.AddWithValue("@MaChungTu", cd.MachungtuCacquy);
                _SqlCommand.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                adapter = new SqlDataAdapter(_SqlCommand);
                table1 = new DataTable();
                adapter.Fill(table1);
                table1.TableName = "spd_LayNoCoTaiKhoanCongDoan;1";

                dataset.Tables.Add(table);
                dataset.Tables.Add(table1);
                Report.SetDataSource(dataset);

                Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_NguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                Report.SetParameterValue("_ThuTruongDonVi", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                Report.SetParameterValue("_BangChu", soTienChu);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Vui lòng Chọn In Phiếu Thu/Chi ", "Thông Báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void cmbu_LoaiThuChi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Hidden = false;
            cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Header.Caption = "Tên chương trình";
            cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Header.VisiblePosition = 0;
            cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Width = 350;

            cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns["IsThu"].Hidden = true;
            cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns["IsThu"].Header.Caption = "Là thu";
            cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns["IsThu"].Width = 100;
            cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns["IsThu"].Header.VisiblePosition = 1;
        }

        private void cbLoaiThuChi_ValueChanged(object sender, EventArgs e)
        {
            if (_chungTu_CacLoaiQuy.IsNew)
                _chungTu_CacLoaiQuy.SoChungTu = ChungTu_CacLoaiQuy.LaySoChungTuMax(Convert.ToInt32(cbLoaiThuChi.Value), DateTime.Today.Year);
        }

        private void tlslblThemDN_Click(object sender, EventArgs e)
        {
            if (_chungTu_CacLoaiQuy.ChungTu_DeNghiNgoaiList.Count == 0 && _chungTu_CacLoaiQuy.ChungTu_GiayBCList.Count == 0 && _chungTu_CacLoaiQuy.ChungTu_GiayRTList.Count == 0)
            {
                _chungTu_CacLoaiQuy.LoaiChungTuDiKem = 0;
            }
            frmChonDeNghi_CacQuy frm = new frmChonDeNghi_CacQuy(_chungTu_CacLoaiQuy, 1); //Loại đề nghị 1: Các Quỹ - 2: Công Đoàn
            frm.ShowDialog();
            maDoiTuong = _chungTu_CacLoaiQuy.MaDoiTuong;
            dtmp_Ngay.DateTime = _chungTu_CacLoaiQuy.NgayLap;
            TaoBindingDanhSach();
        }

        private void TaoBindingDanhSach()
        {
            if (_chungTu_CacLoaiQuy.LoaiChungTuDiKem == 1)
            {
                this.bdChungTu_DeNghi.DataSource = typeof(ChungTu_DeNghiChuyenKhoanNgoaiList);
                bdChungTu_DeNghi.DataSource = _chungTu_CacLoaiQuy.ChungTu_DeNghiNgoaiList;
            }
            else if (_chungTu_CacLoaiQuy.LoaiChungTuDiKem == 2 || _chungTu_CacLoaiQuy.LoaiChungTuDiKem == 3) //Giấy báo có & Phí Ngân hàng
            {
                this.bdChungTu_DeNghi.DataSource = typeof(ChungTu_GiayBaoCo_CacQuyList);
                bdChungTu_DeNghi.DataSource = _chungTu_CacLoaiQuy.ChungTu_GiayBCList;
            }
            else //if (_chungTu_CacLoaiQuy.LoaiChungTuDiKem == 4)
            {
                this.bdChungTu_DeNghi.DataSource = typeof(ChungTu_GiayRutTien_CacQuyList);
                bdChungTu_DeNghi.DataSource = _chungTu_CacLoaiQuy.ChungTu_GiayRTList;
            }

            _chungTu_CacLoaiQuy.MaDoiTuong = maDoiTuong;
            //Load thông tin của đối tượng
            if (_chungTu_CacLoaiQuy.MaDoiTuong != 0)
            {
                DoiTuongAll dtKhachHang = DoiTuongAll.GetDoiTuongAll(_chungTu_CacLoaiQuy.MaDoiTuong);
                txt_TenDoiTac.Text = dtKhachHang.TenDoiTuong;
                txt_DiaChi.Text = dtKhachHang.DiaChi;
            }

            TaoCauTrucBang();
        }

        private void TaoCauTrucBang()
        {
            HamDungChung.EditBand(grd_DSDeNghi.DisplayLayout.Bands[0],
            new string[3] { "SoChungTu", "LyDo", "SoTien" },
            new string[3] { "Số chứng từ", "Lý do", "Số tiền" },
            new int[3] { 150, 330, 150 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Tien },
            new bool[3] { false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.grd_DSDeNghi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.grd_DSDeNghi.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.grd_DSDeNghi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void tlslblXoaDN_Click(object sender, EventArgs e)
        {
            if (grd_DSDeNghi.Selected.Rows.Count <= 0)
            {
                MessageBox.Show(this, "Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grd_DSDeNghi.DeleteSelectedRows();
            grd_DSDeNghi.UpdateData();
        }

        private void tlslbl_InPhieuA4New_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 0)
            {
                MaChungTu = _chungTu_CacLoaiQuy.MachungtuCacquy;
            }
            else if (tabControl1.SelectedIndex == 1)
            {

                MaChungTu = Convert.ToInt64(grdu_DSChungTu.ActiveRow.Cells["MaChungTuCacQuy"].Value);
            }

            ChungTu_CacLoaiQuy ct = ChungTu_CacLoaiQuy.GetChungTu_CacLoaiQuy(MaChungTu);
            ReportTemplate _report;
            //if (ct.MaLoaiChungTu != 16)
            //{
            if (ct.MaLoaiChungTu == 16)
            {
                _report = ReportTemplate.GetReportTemplate("IDPhieuKeToan_QC1TLA4");
            }
            else if (ct.MaLoaiChungTu == 2)
            {
                _report = ReportTemplate.GetReportTemplate("PhieuThuA4");//PhieuNhapVatTu//
            }
            else
            {
                _report = ReportTemplate.GetReportTemplate("PhieuChi2A4");
            }

            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserID, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserID;
                    _reportTemplate.DenNgay = dtDenNgay;
                }
                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.Show();
            }
            //}

        }

        private void tlslbl_InPhieuA5New_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                MaChungTu = _chungTu_CacLoaiQuy.MachungtuCacquy;
            }
            else if (tabControl1.SelectedIndex == 1)
            {

                MaChungTu = Convert.ToInt64(grdu_DSChungTu.ActiveRow.Cells["MaChungTuCacQuy"].Value);
            }

            ChungTu_CacLoaiQuy ct = ChungTu_CacLoaiQuy.GetChungTu_CacLoaiQuy(MaChungTu);
            ReportTemplate _report;
            //if (ct.MaLoaiChungTu != 16)
            //{
            if (ct.MaLoaiChungTu == 16)
            {
                _report = ReportTemplate.GetReportTemplate("IDPhieuKeToan_QC1TLA5");
            }
            else if (ct.MaLoaiChungTu == 2)
            {
                _report = ReportTemplate.GetReportTemplate("PhieuThuA5");//PhieuNhapVatTu//
            }
            else
            {
                _report = ReportTemplate.GetReportTemplate("PhieuChi2A5");
            }

            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserID, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserID;
                    _reportTemplate.DenNgay = dtDenNgay;
                }
                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.Show();
            }
            //}

        }

        #region Inspd_CongNo_PhieuThu
        public bool Inspd_CongNo_PhieuThu() //Thang
        {

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChuoiHachToanQTMTL";
                    cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dataSet);
                    dataSet.Tables[0].TableName = "spd_ChuoiHachToan";
                    dataSet.Tables[1].TableName = "spd_ChuoiTien";

                }
                //tao Inspd_CongNo_PhieuThu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChungTu_CacQuy_PhieuChi";
                    cm.Parameters.AddWithValue("@MaPhieuChi", MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_CongNo_PhieuThu";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 



                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        } //Inspd_CongNo_PhieuThu
        #endregion

        #region Phiếu Chi
        public bool PhieuChi()//[dbo].[spd_ChuoiHachToan], [dbo].[spd_CongNo_PhieuChi]
        {


            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao spd_ChuoiHachToan
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChuoiHachToanQTMTL";
                    cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dataSet);
                    dataSet.Tables[0].TableName = "spd_ChuoiHachToan";
                    dataSet.Tables[1].TableName = "spd_ChuoiTien";

                }
                //tao spd_CongNo_PhieuChi
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChungTu_CacQuy_PhieuChi";
                    cm.Parameters.AddWithValue("@MaPhieuChi", MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_CongNo_PhieuChi;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }
        #endregion


        #region Bang Ke
        public bool PhieuKeToan()//[dbo].[spd_BaoCaoChungTuGhiSo] 
        {

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao spd_BaoCaoChungTuGhiSo
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChungTu_CacQuy_PhieuChi";
                    cm.Parameters.AddWithValue("@MaPhieuChi", MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ChungTu_CacQuy_PhieuChi";
                    dataSet.Tables.Add(dt);
                }

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayNoCoTaiKhoan_CacQuy";
                    cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_LayNoCoTaiKhoan_CacQuy";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }


                DataTable dtBoSung = new DataTable();
                dtBoSung.Columns.Add("TenBoPhan", typeof(string));
                dtBoSung.Columns.Add("NguoiLap", typeof(string));
                dtBoSung.Columns.Add("ThuTruongDonVi", typeof(string));
                dtBoSung.Columns.Add("BangChu", typeof(string));
                //Add dòng 1
                DataRow dr = dtBoSung.NewRow();
                dr["TenBoPhan"] = ERP_Library.Security.CurrentUser.Info.TenBoPhan;
                dr["NguoiLap"] = ERP_Library.Security.CurrentUser.Info.TenNguoiLap;
                dr["ThuTruongDonVi"] = ERP_Library.Security.CurrentUser.Info.TenThuTruong;
                dtBoSung.Rows.Add(dr);
                dtBoSung.TableName = "dtBoSung";
                dataSet.Tables.Add(dtBoSung);
            }//us 
            return true;
        }
        #endregion//Bang Ke

        private void bt_Export_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_DSChungTu);
        }

        private void ugrButToan_AfterCellUpdate(object sender, CellEventArgs e)
        {

            #region Tạm ứng
            if (e.Cell == ugrButToan.ActiveRow.Cells["NoTaiKhoan"] || e.Cell == ugrButToan.ActiveRow.Cells["CoTaiKhoan"])
            {
                string TK = "";

                if (e.Cell.Value != null)
                {

                    TK = HeThongTaiKhoan1.GetHeThongTaiKhoan1((int)e.Cell.Value).SoHieuTK;
                }

                if (TK == "312" || TK == "312.5" || TK == "312.9" || TK == "312.93" || TK == "312.1")
                {
                    if (_chungTu_CacLoaiQuy.MachungtuCacquy != 0)
                        _tamUngList = _chungTu_CacLoaiQuy.TamUng_QC1TLList;
                    _chungTu_CacLoaiQuy.TamUng_QC1TLList.BeginEdit();

                    frmTamUng_QC1TL _frmTamUng = new frmTamUng_QC1TL(_chungTu_CacLoaiQuy.TamUng_QC1TLList, _chungTu_CacLoaiQuy.MaLoaiChungTu, _chungTu_CacLoaiQuy.DienGiai, _chungTu_CacLoaiQuy.NgayLap, _chungTu_CacLoaiQuy.MaDoiTuong, _chungTu_CacLoaiQuy.ThanhTien);
                    if (_frmTamUng.ShowDialog(this) != DialogResult.OK)
                    {
                        if (_frmTamUng.IsSave == true)
                        {
                            _chungTu_CacLoaiQuy.TamUng_QC1TLList = _frmTamUng._tamUngList;
                            _chungTu_CacLoaiQuy.TamUng_QC1TLList.ApplyEdit();
                        }
                        else
                        {
                            _chungTu_CacLoaiQuy.TamUng_QC1TLList.CancelEdit();
                        }
                    }
                }

            }
            #endregion Hết tạm ứng
        }

        private void ugrButToan_ClickCell(object sender, ClickCellEventArgs e)
        {
            #region Tạm ứng
            if (e.Cell == ugrButToan.ActiveRow.Cells["NoTaiKhoan"] || e.Cell == ugrButToan.ActiveRow.Cells["CoTaiKhoan"])
            {
                string TK = "";

                if (e.Cell.Value != null)
                {

                    TK = HeThongTaiKhoan1.GetHeThongTaiKhoan1((int)e.Cell.Value).SoHieuTK;
                }

                if (TK == "312" || TK == "312.5" || TK == "312.9" || TK == "312.93" || TK == "312.1")
                {

                    if (_chungTu_CacLoaiQuy.MachungtuCacquy != 0)
                        _tamUngList = _chungTu_CacLoaiQuy.TamUng_QC1TLList;
                    _chungTu_CacLoaiQuy.TamUng_QC1TLList.BeginEdit();

                    frmTamUng_QC1TL _frmTamUng = new frmTamUng_QC1TL(_chungTu_CacLoaiQuy.TamUng_QC1TLList, _chungTu_CacLoaiQuy.MaLoaiChungTu, _chungTu_CacLoaiQuy.DienGiai, _chungTu_CacLoaiQuy.NgayLap, _chungTu_CacLoaiQuy.MaDoiTuong, _chungTu_CacLoaiQuy.ThanhTien);
                    if (_frmTamUng.ShowDialog(this) != DialogResult.OK)
                    {
                        if (_frmTamUng.IsSave == true)
                        {
                            _chungTu_CacLoaiQuy.TamUng_QC1TLList = _frmTamUng._tamUngList;
                            _chungTu_CacLoaiQuy.TamUng_QC1TLList.ApplyEdit();
                        }
                        else
                        {
                            _chungTu_CacLoaiQuy.TamUng_QC1TLList.CancelEdit();
                        }
                    }
                }

            }
            #endregion Hết tạm ứng
        }

        private void tlSCapNhatSoCTBangKe_Click(object sender, EventArgs e)
        {
            int maloaiCT = Convert.ToInt32(cmb_LoaiChungTu.Value);

            if (maloaiCT == 16)
            {
                frmCapNhatSoChungTu_QC1TL frm = new frmCapNhatSoChungTu_QC1TL(maloaiCT);
                if (frm.ShowDialog() != DialogResult.OK && frm.CapNhat)
                {
                    dtu_NgayBatDau.Value = (object)frm.TuNgay;
                    dtu_NgayKetThuc.Value = (object)DateTime.Today.Date;
                    _chungTu_CacLoaiQuyList = ChungTu_CacLoaiQuyList.GetChungTu_CacLoaiQuyList(dtu_NgayBatDau.DateTime.Date, dtu_NgayKetThuc.DateTime.Date, Convert.ToInt32(cmb_LoaiChungTu.Value));
                    this.bdDanhSachChungTu.DataSource = _chungTu_CacLoaiQuyList;
                }
            }
        }

        private void dtmp_Ngay_Leave(object sender, EventArgs e)
        {
            DateTime ngaylapOut;
            if (DateTime.TryParse(dtmp_Ngay.Value.ToString(), out ngaylapOut) && _changeNgayLap)
            {
                int LoaiThuChi = Convert.ToInt32(cbLoaiThuChi.Value);
                _chungTu_CacLoaiQuy.SoChungTu = ChungTu_CacLoaiQuy.LaySoChungTuMax(LoaiThuChi, ngaylapOut.Year);
                _changeNgayLap = false;
            }
        }

        private void dtmp_Ngay_ValueChanged(object sender, EventArgs e)
        {
            _changeNgayLap = true;
        }

        private void btnCapNhatNhanhCtr_Click(object sender, EventArgs e)
        {
            FrmSupportUpdateCTrForCTuCacQuy frm = new FrmSupportUpdateCTrForCTuCacQuy(Convert.ToInt32(cmb_LoaiChungTu.Value), dtu_NgayBatDau.DateTime.Date, dtu_NgayKetThuc.DateTime.Date);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                bt_Tim.PerformClick();
            }

        }
    }
}
