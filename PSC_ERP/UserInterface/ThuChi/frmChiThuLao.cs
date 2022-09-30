using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Infragistics.Shared;
using Infragistics.Win;
namespace PSC_ERP
{
    public partial class frmChiThuLao : Form
    {
        //  ChuongTrinh _ChuongTrinhList = ChuongTrinh.NewChuongTrinh();
        BoPhanList _BoPhanDenList;
        public ChiThuLaoList _ChiThuLaoList;
        ChungTu _chungTu;
        ChiThuLao _chithulao = ChiThuLao.NewChiThuLao();
        int mabophangui = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        string tenbophangui = (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).TenBoPhan;
        public bool Luu = false;
        int MaChuongTrinh = 0;
        long maChungTu = 0;
        decimal soTien = 0;
        public static decimal SoTienDaNhap = 0;
        HeThongTaiKhoan1List tklist;
        HeThongTaiKhoan1List tklistAll;
        public decimal _soTienTong = 0;
        decimal _tongSoTienChiPhiSanXuatChuongTrinh = 0;
        public frmChiThuLao()
        {
            InitializeComponent();
            BoPhanChuyen_bindingSourceList.DataSource = typeof(BoPhanList);
            this.ChiThuLao_BindingSource.DataSource = typeof(ChiThuLaoList);
            this.ChuongTrinh_bindingSourceList.DataSource = typeof(ChuongTrinhList);
            ultraComboEditor_LoaiChi.SelectedIndex = 0;
            ultraComboEditor_LoaiChi.SelectedItem.DataValue = 1;
            ultraComboEditor_LoaiChi.SelectedItem.DisplayText = "Chi Thù Lao";
        }
        public frmChiThuLao(ChungTu ct, ChiThuLaoList _chithulao, int maChuongTrinh,decimal soTien)
        {
            InitializeComponent();
            _chungTu = ct;
            this.MaChuongTrinh = maChuongTrinh;
            _ChiThuLaoList = _chithulao;
            _tongSoTienChiPhiSanXuatChuongTrinh = soTien;
            this.soTien = soTien;
            foreach (ChiThuLao ctl in _ChiThuLaoList)
            {
                _soTienTong += ctl.SoTien;
            }
            KhoiTao();
            if (_chithulao.Count > 0)
            {
                maChungTu = _chithulao[0].MaChungTu;
               // ultraComboEditor_LoaiChi.SelectedIndex = _chithulao[0].MaLoaiKinhPhi;
                if (_chithulao[0].MaLoaiKinhPhi == 1)
                {
                    ultraComboEditor_LoaiChi.Items[0].DataValue= _chithulao[0].MaLoaiKinhPhi;
                    ultraComboEditor_LoaiChi.Items[0].DisplayText = "Chi Thù Lao";
                }
                 else   
                {
                    ultraComboEditor_LoaiChi.Items[1].DataValue = _chithulao[0].MaLoaiKinhPhi;
                    ultraComboEditor_LoaiChi.Items[1].DisplayText = "Chi Khen Thưởng/PC";
                }
            }
        }

        private void KhoiTao()
        {
            ChiThuLao_BindingSource.DataSource = _ChiThuLaoList;
            _BoPhanDenList = BoPhanList.GetBoPhanListByAll();
            BoPhanChuyen_bindingSourceList.DataSource = _BoPhanDenList;
            tklist = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            bindingSource_TaiKhoanlist.DataSource = tklist;

            tklistAll = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            bindingSource_TaiKhoanAll.DataSource = tklist;
        }

        private void grdu_DSChiThuLao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                //if (col.DataType.ToString() == "System.Decimal")
                //{
                //    col.MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn.nn";
                //    col.Format = "###,###,###,###,###,###.##";
                //}
                col.Hidden = true;
            }
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanNhan"].Hidden = false;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanNhan"].EditorComponent = ultraCombo_BoPhanChuyen;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanNhan"].Header.Caption = "Bộ Phận Đến";
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanNhan"].Header.VisiblePosition = 1;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanNhan"].Width = 200;

            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = HAlign.Right;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###,###";
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Width = 150;

            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaLoaiKinhPHi"].Hidden = false;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaLoaiKinhPHi"].Header.Caption = "Loại Chi";
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaLoaiKinhPHi"].EditorComponent = ultraComboEditor_LoaiChi;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaLoaiKinhPHi"].Header.VisiblePosition = 3;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaLoaiKinhPHi"].CellAppearance.TextHAlign = HAlign.Right;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaLoaiKinhPHi"].Width = 150;

            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["NgayThucHienChi"].Hidden = false;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["NgayThucHienChi"].Header.Caption = "Ngày Thực Hiên Chi";
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["NgayThucHienChi"].Header.VisiblePosition = 4;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["NgayThucHienChi"].Width = 80;

            //grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = false;
            //grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.Caption = "Kế Chuyển Nguồn";
            //grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.VisiblePosition = 5;
            //grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].EditorComponent = ultraCombo_TaiKhoan;
            //grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Width = 80;

            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["ChiTiet"].Hidden = false;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["ChiTiet"].Header.Caption = "Nhân viên";
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["ChiTiet"].Header.VisiblePosition = 5;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["ChiTiet"].Width = 60;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["ChiTiet"].CellActivation = Activation.ActivateOnly;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Columns["ChiTiet"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["SoTien"];
            SummarySettings summary2 = grdu_DSChiThuLao.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.Left;
            summary2.DisplayFormat = "Tông Tiền = {0:###,###,###,###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            grdu_DSChiThuLao.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

        private void ultraCombo_BoPhanChuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(grdu_DSChiThuLao, "MaBoPhanNhan", "TenBoPhan");
            foreach (UltraGridColumn col in this.ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 250;

            ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Width = 100;
        }


        private void ultraTextEditor_MNS_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (grdu_DSChiThuLao.ActiveRow != null)
            {
                frmChiThuLao_NhanVien _frmNhanVien = new frmChiThuLao_NhanVien((ChiThuLao)ChiThuLao_BindingSource.Current);
                _frmNhanVien.Show();
            }
        }

        private void grdu_DSChiThuLao_AfterRowUpdate(object sender, RowEventArgs e)
        {
            _chithulao = (ChiThuLao)ChiThuLao_BindingSource.Current;
            if (_chithulao != null)
            {
                _chithulao.MaBoPhanGui = mabophangui;
                _chithulao.TenBoPhanGui = tenbophangui;
                _chithulao.NgayThucHienChi = _chungTu.NgayThucHien;
                if (Convert.ToInt32( e.Row.Cells["MaLoaiKinhPhi"].Value) == 2)
                {
                    _chithulao.MaLoaiKinhPhi = Convert.ToInt32(e.Row.Cells["MaLoaiKinhPhi"].Value);
                }
                else
                {
                    _chithulao.MaLoaiKinhPhi = 1;
                }
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            _soTienTong = 0;
            grdu_DSChiThuLao.UpdateData();
            ChiThuLao_BindingSource.EndEdit();
            SoTienDaNhap = 0;
            bool kq = true;
            int loaikinhphi = 0;
            foreach (ChiThuLao ctl in _ChiThuLaoList)
            {
                ctl.MaChuongTrinh = MaChuongTrinh;
                SoTienDaNhap += ctl.SoTien;
                if (ctl.SoTien == 0)
                {
                    kq = false;
                }
                else if(ctl.SoTien!=0)
                {
                    kq = true;
                }
                if (ctl.MaLoaiKinhPhi == 1)
                {
                    loaikinhphi = 1;
                }
                else if (ctl.MaLoaiKinhPhi == 2)
                {
                    loaikinhphi = 1;
                }
                _soTienTong += ctl.SoTien;
                
            }
            if (kq == false)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Số Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Luu = false;
                return;
            }
            if (_tongSoTienChiPhiSanXuatChuongTrinh < _soTienTong)
            {
                MessageBox.Show(this, "Không đủ tiền để nhập chi thù lao.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Luu = false;
                return;
            }
            Luu = true;
            this.Close();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tlslblIn_Click(object sender, EventArgs e)
        {            
            SqlCommand command;
            DataSet dataset;
            ReportDocument Report;
            frmHienThiReport dlg;
            SqlDataAdapter adapter;
            DataTable table;
            Report = new Report.CongNo.DanhSachChiThuLaoNhanVien();
            command = new SqlCommand();
            dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spDanhSachNhanVienChiThuLao";         
            command.Parameters.AddWithValue("@MaChungTu",maChungTu);         
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spDanhSachNhanVienChiThuLao;1";
            dataset.Tables.Add(table);
            Report.SetDataSource(dataset);          
            Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
            dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void grdu_DSChiThuLao_AfterRowInsert(object sender, RowEventArgs e)
        {
            decimal soTienDaNhap = 0;
            decimal soTienChiPhiThucHien = 0;

            soTienChiPhiThucHien = frmChiPhiThucHien.SoTienDaNhap;

            foreach (ChiThuLao ctl in _ChiThuLaoList)
            {
                soTienDaNhap += ctl.SoTien;
            }
            ((ChiThuLao)ChiThuLao_BindingSource.Current).SoTien = soTien - soTienDaNhap - soTienChiPhiThucHien;
            ((ChiThuLao)ChiThuLao_BindingSource.Current).MaBoPhanNhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            ((ChiThuLao)ChiThuLao_BindingSource.Current).NgayThucHienChi = _chungTu.NgayLap;
            ultraComboEditor_LoaiChi.SelectedIndex = 0;
            ultraComboEditor_LoaiChi.SelectedItem.DataValue = 1;
            ultraComboEditor_LoaiChi.SelectedItem.DisplayText = "Chi Thù Lao";
            e.Row.Update();
        }

        private void ultraComboEditor_LoaiChi_ValueChanged(object sender, EventArgs e)
        {
            foreach (ChiThuLao ctl in _ChiThuLaoList)
            {
                ctl.MaLoaiKinhPhi = Convert.ToInt32( ultraComboEditor_LoaiChi.SelectedItem.DataValue);
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_DSChiThuLao.DeleteSelectedRows();
        }
        private void ultraCombo_TaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            foreach (UltraGridColumn col in this.ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 70;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            FilterCombo f = new FilterCombo(ultraCombo_TaiKhoan, "SoHieuTK");
        }

        private void ultraCombo_TaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void ultraCombo_TaiKhoanAll_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 70;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            FilterCombo f = new FilterCombo(ultraCombo_TaiKhoanAll, "SoHieuTK");
        }

        private void ultraCombo_TaiKhoanAll_ValueChanged(object sender, EventArgs e)
        {
            if (ultraCombo_TaiKhoanAll.Value != null)
            {
                foreach (ChiThuLao ctl in _ChiThuLaoList)
                {
                    ctl.MaTaiKhoan = Convert.ToInt32(ultraCombo_TaiKhoanAll.Value);
                }
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            KhoiTao();

        }

    }
}
