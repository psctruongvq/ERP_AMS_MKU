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
namespace PSC_ERP.UserInterface.ThuChi
{
    public partial class frmThuChi_CongDoan : Form
    {
        
        private CongDoan_ChungTu _CDChungTu = CongDoan_ChungTu.NewCongDoan_ChungTu();
        private CongDoan_ChungTuList _CDChungTuList = CongDoan_ChungTuList.NewCongDoan_ChungTuList();
        HeThongTaiKhoan1List _taiKhoanNoList, _taiKhoanCoList=HeThongTaiKhoan1List.NewHeThongTaiKhoan1List();
        TTNhanVienRutGonList _nhanVienList = TTNhanVienRutGonList.NewTTNhanVienRutGonList();
        DoiTuongThuChiList _doiTuongThuChiList = DoiTuongThuChiList.NewDoiTuongThuChiList();
        CongDoan_ButToanList _CDButToanLits = CongDoan_ButToanList.NewCongDoan_ButToanList();
        LoaiThuChiCongDoanList _loaiThuChiList = LoaiThuChiCongDoanList.NewLoaiThuChiCongDoanList();
        int maLoaiChungTu = 0; int maLoaiThuChiCD = 0;
        long maDoiTuong = 0;
        public frmThuChi_CongDoan()
        {
            InitializeComponent();
         
            this.bdDanhSachChungTu.DataSource =typeof( CongDoan_ChungTuList);
            this.bdChungTu.DataSource = typeof( CongDoan_ChungTu);          
            bdNoTaiKhoan.DataSource =typeof(  HeThongTaiKhoan1List);
            bdCoTaiKhoan.DataSource =typeof(  HeThongTaiKhoan1List);           
            bdDoiTuong.DataSource = typeof( TTNhanVienRutGonList);
             this.bdCongViec.DataSource = typeof( DoiTuongThuChiList);
             bdButtoan.DataSource = typeof(CongDoan_ButToanList);
             bdLoaiThuChi.DataSource = typeof(LoaiThuChiCongDoanList);
             cbLoaiThuChi.Value = 0;
             cbLoaiThuChi.SelectedIndex = 0;
             ultraComboEditor_LoaiChungTu.SelectedIndex = 3;
             ultraComboEditor_LoaiChungTu.Value = 3;
        }

        private void ultraTextEditor_MNS_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            //soTien= (decimal)tbThanhTien.Value;
            //frmThuChi_ButToanMucNganSach _frmDinhKhoan_MucNganSach = new frmThuChi_ButToanMucNganSach(((CongDoan_ButToan)bdButtoan.Current).CongDoan_ButToanMucNganSachList, soTien, ((CongDoan_ButToan)bdButtoan.Current).DienGiai);
            //if (_frmDinhKhoan_MucNganSach.ShowDialog(this) != DialogResult.OK)
            //{
            //    if (_frmDinhKhoan_MucNganSach.IsSave == true)
            //    {
            //        ((CongDoan_ButToan)bdButtoan.Current).CongDoan_ButToanMucNganSachList = _frmDinhKhoan_MucNganSach._list;
            //        ((CongDoan_ButToan)bdButtoan.Current).CongDoan_ButToanMucNganSachList.ApplyEdit();
            //    }
            //}
        }

        private void frmThuChi_CongDoan_Load(object sender, EventArgs e)
        {
            _CDChungTuList = CongDoan_ChungTuList.GetCongDoan_ChungTuList(dtu_NgayBatDau.DateTime.Date, dtu_NgayKetThuc.DateTime.Date, Convert.ToInt32(ultraComboEditor_LoaiChungTu.Value));
            this.bdDanhSachChungTu.DataSource = _CDChungTuList;
            this.bdChungTu.DataSource = _CDChungTu;
            _taiKhoanNoList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            _taiKhoanCoList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
         
            bdNoTaiKhoan.DataSource = _taiKhoanNoList;
            bdCoTaiKhoan.DataSource = _taiKhoanCoList;
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListAll();
            TTNhanVienRutGon ttnv = TTNhanVienRutGon.NewTTNhanVienRutGon(0, "Không Có");
            _nhanVienList.Add(ttnv);

            bdDoiTuong.DataSource = _nhanVienList;
            _doiTuongThuChiList = DoiTuongThuChiList.GetDoiTuongThuChiList(ERP_Library.Security.CurrentUser.Info.MaCongTy);
            this.bdCongViec.DataSource = _doiTuongThuChiList;
            _CDChungTu.CongDoan_ButToanList = CongDoan_ButToanList.GetCongDoan_ButToanList(_CDChungTu.MaChungTu);
            bdButtoan.DataSource = _CDChungTu.CongDoan_ButToanList;
            _loaiThuChiList = LoaiThuChiCongDoanList.GetLoaiThuChiCongDoanList();
            bdLoaiThuChi.DataSource = _loaiThuChiList;
            _CDChungTu.SoChungTu = CongDoan_ChungTu.LaySoChungTuMax(maLoaiChungTu, Convert.ToDateTime(dtmp_Ngay.Value).Year);

            TaoCauTrucBang();
        }


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _CDChungTu = CongDoan_ChungTu.NewCongDoan_ChungTu(maLoaiChungTu, Convert.ToDateTime(dtmp_Ngay.Value).Year);
            this.bdChungTu.DataSource = _CDChungTu;
            this.bdButtoan.DataSource = _CDChungTu.CongDoan_ButToanList;
            TaoBindingDanhSach();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ugrButToan.UpdateData();
            this.bdChungTu.EndEdit();
            this.bdButtoan.EndEdit();
            _CDChungTu.MaLoaiThuChi = maLoaiChungTu;
            //if (_CDChungTu.MaDoiTuong == 0)
            //{
            //    MessageBox.Show("Đối tượng chưa có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (_CDChungTu.MaLoaiThuChiCongDoan == 0)
            {
                MessageBox.Show("Công việc chưa có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_CDChungTu.MaLoaiThuChi == 0)
            {
                MessageBox.Show("Loại Thu/Chi chưa có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_CDChungTu.SoTien == 0)
            {
                MessageBox.Show("Số Tiền chưa có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_CDChungTu.CongDoan_ButToanList.Count == 0)
            {
                MessageBox.Show("Chưa định khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (HamDungChung.KiemTraLaSo(_CDChungTu.SoChungTu.Substring(0,4)) == false)
            {
                MessageBox.Show("4 ký tự đầu tiên của Số Chứng từ phải 0->9.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal soTienButToan = 0;
            foreach (CongDoan_ButToan bt in _CDChungTu.CongDoan_ButToanList)
            {
                soTienButToan += bt.SoTien;
            }
            if (_CDChungTu.SoTien != soTienButToan)
            {
                MessageBox.Show("Số tiền Chứng Từ chưa bằng số tiền Định khoản.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoaiThuChiCongDoan ltc = LoaiThuChiCongDoan.GetLoaiThuChiCongDoan(maLoaiThuChiCD);
            if (maLoaiChungTu == 2 && ltc.LoaiThu != true)
            {
                MessageBox.Show("Loại Thu/Chi của Công Việc chưa đúng với loại Thu/Chi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (maLoaiChungTu == 3 && ltc.LoaiThu != false)
            {
                MessageBox.Show("Loại Thu/Chi của Công Việc chưa đúng với loại Thu/Chi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (CongDoan_ChungTu.KiemTraSoChungTu(tbSoChungTu.Text,_CDChungTu) == true)
            {
                MessageBox.Show(this, "Số Chứng Từ Đã Có Vui Lòng Nhập SCT Khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _CDChungTu.ApplyEdit();
            _CDChungTu.Save();
            MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _CDChungTu = CongDoan_ChungTu.GetCongDoan_ChungTu(_CDChungTu.MaChungTu);
            this.bdChungTu.DataSource = _CDChungTu;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 0)
            {
                int maChungTu = Convert.ToInt32(grdu_DSChungTu.ActiveRow.Cells["MaChungTu"].Value);
                Reload(maChungTu);
                tabControl1.SelectedIndex = 0;
            }
            DeleteChungTu(_CDChungTu.MaChungTu);
            Reload(_CDChungTu.MaChungTu);

            _CDChungTuList = CongDoan_ChungTuList.GetCongDoan_ChungTuList(dtu_NgayBatDau.DateTime.Date, dtu_NgayKetThuc.DateTime.Date, Convert.ToInt32(ultraComboEditor_LoaiChungTu.Value));
            this.bdDanhSachChungTu.DataSource = _CDChungTuList;

            TaoBindingDanhSach();
        }
        private void DeleteChungTu(int maChungTu)
        {
            if (MessageBox.Show("Bạn có muốn xóa chứng từ: " + _CDChungTu.SoChungTu + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CongDoan_ChungTu.DeleteCongDoan_ChungTu(maChungTu);
                MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdu_DSChungTu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
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

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Header.Caption = "Loại Thu-Chi";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Header.VisiblePosition = 3;

            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 4;
            grdu_DSChungTu.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 400;



        }

        private void cbDoiTuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cbDoiTuong, "TenNhanVien");
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbDoiTuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 200;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 1;
        }

        private void ugrButToan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.ugrButToan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
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



            ugrButToan.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            ugrButToan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            ugrButToan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            ugrButToan.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 450;

            //ugrButToan.DisplayLayout.Bands[0].Columns["ChiTiet"].Hidden = false;
            //ugrButToan.DisplayLayout.Bands[0].Columns["ChiTiet"].Header.Caption = "Mục Ngân Sách";
            //ugrButToan.DisplayLayout.Bands[0].Columns["ChiTiet"].Header.VisiblePosition = 4;
            //ugrButToan.DisplayLayout.Bands[0].Columns["ChiTiet"].EditorComponent = ultraTextEditor_MNS;
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

        private void ugrButToan_AfterRowInsert(object sender, RowEventArgs e)
        {
            decimal soTienDaNhap = 0;
            ((CongDoan_ButToan)this.bdButtoan.Current).DienGiai = _CDChungTu.DienGiai;           
            foreach (CongDoan_ButToan cd in _CDChungTu.CongDoan_ButToanList)
            {
                soTienDaNhap += cd.SoTien; 
            }
            ((CongDoan_ButToan)this.bdButtoan.Current).SoTien = _CDChungTu.SoTien - soTienDaNhap;
            if (maLoaiChungTu == 2)
            {
                ((CongDoan_ButToan)this.bdButtoan.Current).NoTaiKhoan = 161;
                ((CongDoan_ButToan)this.bdButtoan.Current).CoTaiKhoan = 615;
            }
           else if (maLoaiChungTu == 3)
            {
                ((CongDoan_ButToan)this.bdButtoan.Current).CoTaiKhoan = 161;
                ((CongDoan_ButToan)this.bdButtoan.Current).NoTaiKhoan = 615;
            }

        }

        private void cbLoaiThuChi_ValueChanged(object sender, EventArgs e)
        {
            if (cbLoaiThuChi.Value != null)
                maLoaiChungTu =Convert.ToInt32( cbLoaiThuChi.Value);
            if (_CDChungTu.IsNew == true)
                _CDChungTu.SoChungTu = CongDoan_ChungTu.LaySoChungTuMax(maLoaiChungTu, Convert.ToDateTime(dtmp_Ngay.Value).Year);
        }

        private void grdu_DSChungTu_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            int maChungTu = Convert.ToInt32(grdu_DSChungTu.ActiveRow.Cells["MaChungTu"].Value);
            Reload(maChungTu);
            tabControl1.SelectedIndex = 0;
        }
        private void Reload(int maChungTu)
        {
            _CDChungTu = CongDoan_ChungTu.GetCongDoan_ChungTu(maChungTu);
            this.bdChungTu.DataSource = _CDChungTu;
            bdButtoan.DataSource = _CDChungTu.CongDoan_ButToanList;
            this.cbLoaiThuChi.Value = _CDChungTu.MaLoaiThuChi;
        }
        private void bt_Tim_Click(object sender, EventArgs e)
        {
            _CDChungTuList = CongDoan_ChungTuList.GetCongDoan_ChungTuList(dtu_NgayBatDau.DateTime.Date, dtu_NgayKetThuc.DateTime.Date, Convert.ToInt32(ultraComboEditor_LoaiChungTu.Value));
            this.bdDanhSachChungTu.DataSource = _CDChungTuList;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            //A4
            if (tabControl1.SelectedIndex == 0)
            {
                InPhieu(4, _CDChungTu.MaChungTu);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                foreach (UltraGridRow row in grdu_DSChungTu.Selected.Rows)
                {
                    int maChungTu = Convert.ToInt32(row.Cells["MaChungTu"].Value);
                    InPhieu(4,maChungTu);
                }
            }

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {

        }
        ReportDocument Report;
        DataSet dataset;   
        private void InPhieu(int loai, int maChungTu)
        {
            SqlCommand command;
            SqlDataAdapter adapter;
            DataTable table;
            string phieuThuChi = string.Empty;
            string soTienChu = string.Empty;
            string nguoiNhanNopTien = string.Empty;
            CongDoan_ChungTu _CDChungTu = CongDoan_ChungTu.GetCongDoan_ChungTu(maChungTu);
            soTienChu = ERP_Library.HamDungChung.DocTien(_CDChungTu.SoTien);
            if (_CDChungTu.MaLoaiThuChi != 16)
            {

                if (_CDChungTu.MaLoaiThuChi == 2)
                {
                    phieuThuChi = "Phiếu Thu";
                    nguoiNhanNopTien = "Người Nộp Tiền";
                    if (loai == 4)
                    {
                        Report = new Report.CongNo.PhieuThuCongDoan();
                    }
                    else
                    {
                        Report = new Report.CongNo.PhieuThuCongDoanA5();
                    }

                }
                else
                {
                    phieuThuChi = "Phiếu Chi";
                    nguoiNhanNopTien = "Người Nhận Tiền";
                    if (loai == 4)
                    {
                        Report = new Report.CongNo.PhieuChiCongDoan();
                    }
                    else
                    {
                        Report = new Report.CongNo.PhieuChiCongDoanA5();
                    }

                }
                DateTime ngayDauNam = new DateTime(DateTime.Today.Date.Year, 1, 1);

                command = new SqlCommand();
                dataset = new DataSet();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_PhieuChi_CongDoan";
                command.Parameters.AddWithValue("@MaPhieuChi", _CDChungTu.MaChungTu);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_PhieuChi_CongDoan;1";

                SqlCommand _SqlCommand;
                DataTable table1;
                _SqlCommand = new SqlCommand();
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.CommandText = "spd_LayNoCoTaiKhoanCongDoan";
                _SqlCommand.Parameters.AddWithValue("@MaChungTu", _CDChungTu.MaChungTu);
                _SqlCommand.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                adapter = new SqlDataAdapter(_SqlCommand);
                table1 = new DataTable();
                adapter.Fill(table1);
                table1.TableName = "spd_LayNoCoTaiKhoanCongDoan;1";

                dataset.Tables.Add(table);
                dataset.Tables.Add(table1);
                Report.SetDataSource(dataset);


                SqlCommand command4 = new SqlCommand();
                command4.CommandType = CommandType.StoredProcedure;
                command4.CommandText = "spd_LayNguoiKyTenCongNo";
                command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                DataTable table4 = new DataTable();
                adapter4.Fill(table4);
                table4.TableName = "spd_LayNguoiKyTenCongNo;1";
                DataRow dr = table4.Rows[0];//dt là DataTable
              
                //Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                //Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                //Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                //Report.SetParameterValue("_PhieuThuChi", phieuThuChi);
                //Report.SetParameterValue("_soTienChu", soTienChu);
                //Report.SetParameterValue("_nguoiNhanNopTien", nguoiNhanNopTien);
                //Report.SetParameterValue("_keToanTruong", ERP_Library.Security.CurrentUser.Info.TenKeToanTruong);
                //Report.SetParameterValue("_thuQuy", ERP_Library.Security.CurrentUser.Info.TenThuQuy);

                Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_tenNguoiLap", dr["TenNguoiLap"].ToString());
                Report.SetParameterValue("_tenThuTruong", dr["TenThuTruong"].ToString());
                Report.SetParameterValue("_PhieuThuChi", phieuThuChi);
                Report.SetParameterValue("_soTienChu", soTienChu);
                Report.SetParameterValue("_nguoiNhanNopTien", nguoiNhanNopTien);
                Report.SetParameterValue("_keToanTruong", dr["TenKTTTruong"].ToString());
                Report.SetParameterValue("_thuQuy", dr["TenThuQuy"].ToString());
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
        private void toolStripButton7_Click(object sender, EventArgs e)
        {//A5
            if (tabControl1.SelectedIndex == 0)
            {
                InPhieu(5, _CDChungTu.MaChungTu);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                int maChungTu = 0;
                maChungTu = (int)grdu_DSChungTu.ActiveRow.Cells["MaChungTu"].Value;


                SqlCommand command;

                SqlDataAdapter adapter;
                DataTable table;

                string phieuThuChi = string.Empty;
                string soTienChu = string.Empty;
                string nguoiNhanNopTien = string.Empty;
                CongDoan_ChungTu _CDChungTu = CongDoan_ChungTu.GetCongDoan_ChungTu(maChungTu);
                soTienChu = ERP_Library.HamDungChung.DocTien(_CDChungTu.SoTien);
                if (_CDChungTu.MaLoaiThuChi != 16)
                {
                    if (_CDChungTu.MaLoaiThuChi == 2)
                    {
                        phieuThuChi = "PHIẾU THU";
                        nguoiNhanNopTien = "Người Nộp Tiền";
                        Report = new Report.CongNo.PhieuThuCongDoanA5();
                    }
                    else
                    {
                        phieuThuChi = "PHIẾU CHI";
                        nguoiNhanNopTien = "Người Nhận Tiền";
                        Report = new Report.CongNo.PhieuChiCongDoanA5();
                    }
                    DateTime ngayDauNam = new DateTime(DateTime.Today.Date.Year, 1, 1);
                    //Report = new Report.CongNo.PhieuThuCongDoanA5();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_CongNo_PhieuChi_CongDoan";
                    command.Parameters.AddWithValue("@MaPhieuChi", _CDChungTu.MaChungTu);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_CongNo_PhieuChi_CongDoan;1";


                    dataset.Tables.Add(table);

                    Report.SetDataSource(dataset);

                    //Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    //Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    //Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                    //Report.SetParameterValue("_PhieuThuChi", phieuThuChi);
                    //Report.SetParameterValue("_soTienChu", soTienChu);
                    //Report.SetParameterValue("_nguoiNhanNopTien", nguoiNhanNopTien);
                    //Report.SetParameterValue("_keToanTruong", ERP_Library.Security.CurrentUser.Info.TenKeToanTruong);
                    //Report.SetParameterValue("_thuQuy", ERP_Library.Security.CurrentUser.Info.TenThuQuy);

                    SqlCommand command4 = new SqlCommand();
                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                    command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    DataTable table4 = new DataTable();
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";
                    DataRow dr = table4.Rows[0];//dt là DataTable

                    //Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    //Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    //Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                    //Report.SetParameterValue("_PhieuThuChi", phieuThuChi);
                    //Report.SetParameterValue("_soTienChu", soTienChu);
                    //Report.SetParameterValue("_nguoiNhanNopTien", nguoiNhanNopTien);
                    //Report.SetParameterValue("_keToanTruong", ERP_Library.Security.CurrentUser.Info.TenKeToanTruong);
                    //Report.SetParameterValue("_thuQuy", ERP_Library.Security.CurrentUser.Info.TenThuQuy);

                    Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tenNguoiLap", dr["TenNguoiLap"].ToString());
                    Report.SetParameterValue("_tenThuTruong", dr["TenThuTruong"].ToString());
                    Report.SetParameterValue("_PhieuThuChi", phieuThuChi);
                    Report.SetParameterValue("_soTienChu", soTienChu);
                    Report.SetParameterValue("_nguoiNhanNopTien", nguoiNhanNopTien);
                    Report.SetParameterValue("_keToanTruong", dr["TenKTTTruong"].ToString());
                    Report.SetParameterValue("_thuQuy", dr["TenThuQuy"].ToString());

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

        private void ultraCombo1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
              HamDungChung h = new HamDungChung();
              FilterCombo f = new FilterCombo(cbLoaiThuChiCongDoan, "TenLoaiThuChi");
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbLoaiThuChiCongDoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbLoaiThuChiCongDoan.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Hidden = false;
            cbLoaiThuChiCongDoan.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Header.Caption = "Tên Công Việc";
            cbLoaiThuChiCongDoan.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Header.VisiblePosition = 0;
            cbLoaiThuChiCongDoan.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Width = 200;
            cbLoaiThuChiCongDoan.DisplayLayout.Bands[0].Columns["LoaiThu"].Hidden = false;
            cbLoaiThuChiCongDoan.DisplayLayout.Bands[0].Columns["LoaiThu"].Header.Caption = "Loại Thu";
            cbLoaiThuChiCongDoan.DisplayLayout.Bands[0].Columns["LoaiThu"].Header.VisiblePosition = 1;
            
        }

        private void ultraCombo1_ValueChanged(object sender, EventArgs e)
        {
            if (cbLoaiThuChiCongDoan.ActiveRow != null)
            {
                 maLoaiThuChiCD = (int)cbLoaiThuChiCongDoan.Value;
               
            }
        }

        private void toolStripButton9_Click_1(object sender, EventArgs e)
        {
             int maChungTu = 0;            
            if (tabControl1.SelectedIndex == 0)
            {
                maChungTu = _CDChungTu.MaChungTu;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                foreach (UltraGridRow row in grdu_DSChungTu.Selected.Rows)
                {
                     maChungTu = Convert.ToInt32(row.Cells["MaChungTu"].Value);
                }
            }
           CongDoan_ChungTu cd = CongDoan_ChungTu.GetCongDoan_ChungTu(maChungTu);
           if (cd.MaLoaiThuChi == 16)
           {
               SqlCommand command;

               SqlDataAdapter adapter;
               DataTable table;

               string phieuThuChi = string.Empty;
               string soTienChu = string.Empty;
               string nguoiNhanNopTien = string.Empty;
               // CongDoan_ChungTu _CDChungTu = CongDoan_ChungTu.GetCongDoan_ChungTu(maChungTu);
               soTienChu = ERP_Library.HamDungChung.DocTien(cd.SoTien);

               Report = new Report.CongNo.BangKeCongDoanA5();
               command = new SqlCommand();

               dataset = new DataSet();
               command.CommandType = CommandType.StoredProcedure;
               command.CommandText = "spd_CongNo_PhieuChi_CongDoan";
               command.Parameters.AddWithValue("@MaPhieuChi", cd.MaChungTu);
               command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
               adapter = new SqlDataAdapter(command);
               table = new DataTable();
               adapter.Fill(table);
               table.TableName = "spd_CongNo_PhieuChi_CongDoan;1";

               SqlCommand _SqlCommand;
               DataTable table1;
               _SqlCommand = new SqlCommand();
               _SqlCommand.CommandType = CommandType.StoredProcedure;
               _SqlCommand.CommandText = "spd_LayNoCoTaiKhoanCongDoan";
               _SqlCommand.Parameters.AddWithValue("@MaChungTu", cd.MaChungTu);
               _SqlCommand.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
               adapter = new SqlDataAdapter(_SqlCommand);
               table1 = new DataTable();
               adapter.Fill(table1);
               table1.TableName = "spd_LayNoCoTaiKhoanCongDoan;1";

               dataset.Tables.Add(table);
               dataset.Tables.Add(table1);
               Report.SetDataSource(dataset);

               SqlCommand command4 = new SqlCommand();
               command4.CommandType = CommandType.StoredProcedure;
               command4.CommandText = "spd_LayNguoiKyTenCongNo";
               command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

               command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
               SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
               DataTable table4 = new DataTable();
               adapter4.Fill(table4);
               table4.TableName = "spd_LayNguoiKyTenCongNo;1";
               DataRow dr = table4.Rows[0];//dt là DataTable
               Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
               Report.SetParameterValue("_NguoiLap", dr["TenNguoiLap"].ToString());
               Report.SetParameterValue("_ThuTruongDonVi", dr["TenThuTruong"].ToString());
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

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            int maChungTu = 0;
            if (tabControl1.SelectedIndex == 0)
            {
                maChungTu = _CDChungTu.MaChungTu;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                foreach (UltraGridRow row in grdu_DSChungTu.Selected.Rows)
                {
                    maChungTu = Convert.ToInt32(row.Cells["MaChungTu"].Value);
                }
            }
            CongDoan_ChungTu cd = CongDoan_ChungTu.GetCongDoan_ChungTu(maChungTu);
            if (cd.MaLoaiThuChi == 16)
            {

                SqlCommand command;

                SqlDataAdapter adapter;
                DataTable table;

                string phieuThuChi = string.Empty;
                string soTienChu = string.Empty;
                string nguoiNhanNopTien = string.Empty;
                soTienChu = ERP_Library.HamDungChung.DocTien(cd.SoTien);

                Report = new Report.CongNo.BangKeCongDoanA4();
                command = new SqlCommand();

                dataset = new DataSet();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_PhieuChi_CongDoan";
                command.Parameters.AddWithValue("@MaPhieuChi", cd.MaChungTu);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_PhieuChi_CongDoan;1";

                SqlCommand _SqlCommand;
                DataTable table1;
                _SqlCommand = new SqlCommand();
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.CommandText = "spd_LayNoCoTaiKhoanCongDoan";
                _SqlCommand.Parameters.AddWithValue("@MaChungTu", cd.MaChungTu);
                _SqlCommand.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                adapter = new SqlDataAdapter(_SqlCommand);
                table1 = new DataTable();
                adapter.Fill(table1);
                table1.TableName = "spd_LayNoCoTaiKhoanCongDoan;1";

                dataset.Tables.Add(table);
                dataset.Tables.Add(table1);
                Report.SetDataSource(dataset);

                SqlCommand command4 = new SqlCommand();
                command4.CommandType = CommandType.StoredProcedure;
                command4.CommandText = "spd_LayNguoiKyTenCongNo";
                command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                DataTable table4 = new DataTable();
                adapter4.Fill(table4);
                table4.TableName = "spd_LayNguoiKyTenCongNo;1";
                DataRow dr = table4.Rows[0];//dt là DataTable
                Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_NguoiLap", dr["TenNguoiLap"].ToString());
                Report.SetParameterValue("_ThuTruongDonVi", dr["TenThuTruong"].ToString());
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

        private void tlslblThemDN_Click(object sender, EventArgs e)
        {
            if (_CDChungTu.CongDoan_DeNghiList.Count == 0 && _CDChungTu.CongDoan_GiayBCList.Count == 0 && _CDChungTu.CongDoan_GiayRTList.Count == 0)
            {
                _CDChungTu.LoaiChungTuDiKem = 0;
            }
            frmChonDeNghi_CacQuy frm = new frmChonDeNghi_CacQuy(_CDChungTu, 2); //Loại đề nghị 1: Các Quỹ - 2: Công Đoàn
            frm.ShowDialog();
            maDoiTuong = _CDChungTu.MaDoiTuong;
            dtmp_Ngay.DateTime = _CDChungTu.NgayLap;
            TaoBindingDanhSach();
        }

        private void TaoBindingDanhSach()
        {
            if (_CDChungTu.LoaiChungTuDiKem == 1)
            {
                this.bdChungTu_DeNghi.DataSource = typeof(CongDoan_DeNghiChuyenKhoanList);
                bdChungTu_DeNghi.DataSource = _CDChungTu.CongDoan_DeNghiList;
            }
            else if (_CDChungTu.LoaiChungTuDiKem == 2 || _CDChungTu.LoaiChungTuDiKem == 3) //Giấy báo có & Phí Ngân hàng
            {
                this.bdChungTu_DeNghi.DataSource = typeof(CongDoan_GiayBaoCoList);
                bdChungTu_DeNghi.DataSource = _CDChungTu.CongDoan_GiayBCList;
            }
            else //if (_chungTu_CacLoaiQuy.LoaiChungTuDiKem == 4)
            {
                this.bdChungTu_DeNghi.DataSource = typeof(CongDoan_GiayRutTienList);
                bdChungTu_DeNghi.DataSource = _CDChungTu.CongDoan_GiayRTList;
            }

            _CDChungTu.MaDoiTuong = maDoiTuong;
            //Load thông tin của đối tượng
            if (_CDChungTu.MaDoiTuong != 0)
            {
                DoiTuongAll dtKhachHang = DoiTuongAll.GetDoiTuongAll(_CDChungTu.MaDoiTuong);
                //.Text = dtKhachHang.TenDoiTuong;
                //txt_DiaChi.Text = dtKhachHang.DiaChi;
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
    }
}
