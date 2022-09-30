using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmNghiViecChamDutHD : Form
    {
        ThongTinNhanVienTongHopList _TTNhanVienList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
        BoPhanList _BoPhanList = BoPhanList.NewBoPhanList();
        LoaiQuyetDinhThoiViecList _LoaiQDList = LoaiQuyetDinhThoiViecList.NewLoaiQuyetDinhThoiViecList();
        LyDoThoiViecList _LyDoList = LyDoThoiViecList.NewLyDoThoiViecList();
        ThoiViecList _QuyetDinhList = ThoiViecList.NewThoiViecList();
        ThoiViecList _DsThoiViec = ThoiViecList.NewThoiViecList();
        ChucVuList _ChucVuList = ChucVuList.NewChucVuList();
        DanhsachNVTheoHDList _DSNhanvien = DanhsachNVTheoHDList.NewDanhsachNVTheoHDList();
        long NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        int maThoiViec = 0;
        public frmNghiViecChamDutHD()
        {
            InitializeComponent();
            BindS_BoPhan.DataSource = typeof(BoPhanList);
            BindS_LoaiQD.DataSource = typeof(LoaiQuyetDinhThoiViecList);
            BindS_LyDo.DataSource = typeof(LyDoThoiViecList);
            BindS_NguoiKy.DataSource = typeof(ThongTinNhanVienTongHopList);
            BindS_DSNghi.DataSource = typeof(ThoiViecList);
            BindS_ChucVu.DataSource = typeof(ChucVuList);
            this.Load_Source();
        }

        #region Load
        private void Load_Source()
        {
            try
            {
                _BoPhanList = BoPhanList.GetBoPhanList();
                BindS_BoPhan.DataSource = _BoPhanList;
                _LyDoList = LyDoThoiViecList.GetLyDoThoiViecList();
                BindS_LyDo.DataSource = _LyDoList;
                _LoaiQDList = LoaiQuyetDinhThoiViecList.GetLoaiQuyetDinhThoiViecList();
                BindS_LoaiQD.DataSource = _LoaiQDList;
                _ChucVuList = ChucVuList.GetChucVuList();
                BindS_ChucVu.DataSource = _ChucVuList;
                _QuyetDinhList = ThoiViecList.GetThoiViecListSoQD();
                BindS_Quyetdinhso.DataSource = _QuyetDinhList;
            }
            catch (ApplicationException)
            {

            }

        }

        private void Load_Nguon()
        {
            if (cmbu_Bophan.ActiveRow != null)
            {
                try
                {
                    if (txt_NhanVien.Text == string.Empty)
                    {
                        _DSNhanvien = DanhsachNVTheoHDList.GetDSNhanvienDangDiLamByBophan((int)cmbu_Bophan.Value);
                    }
                    else
                    {
                        _DSNhanvien = DanhsachNVTheoHDList.GetDSNhanvienDangDiLamByNhanVien((int)cmbu_Bophan.Value,txt_NhanVien.Text);
                    }
                    lstvDsnguon.Items.Clear();
                    for (int i = 0; i < _DSNhanvien.Count; i++)
                    {
                        ListViewItem lstnguonitem;
                        lstnguonitem = lstvDsnguon.Items.Add(_DSNhanvien[i].MaNhanVien.ToString());
                        lstnguonitem.SubItems.Add(_DSNhanvien[i].MaQLNhanVien.ToString());
                        lstnguonitem.SubItems.Add(_DSNhanvien[i].TenNhanVien.ToString());
                        lstnguonitem.SubItems.Add(_DSNhanvien[i].TenChucVu.ToString());
                        lstnguonitem.SubItems.Add(DateTime.Parse(_DSNhanvien[i].NgayVaoLam.ToString()).ToString("dd/MM/yyyy"));
                    }
                }
                catch (ApplicationException)
                {

                }
                lblTSo.Text = "Tổng cộng : " + _DSNhanvien.Count;
            }
        }

        private void Load_Dich()
        {
            try
            {
                //if (cbo_SoQuyetdinh.Value == null)
                //{
                    _DsThoiViec = ThoiViecList.GetThoiViecListByNgay(Convert.ToDateTime(dtp_Tungay.Value), Convert.ToDateTime(dtp_Denngay.Value));
                    BindS_DSNghi.DataSource = _DsThoiViec;
                //}
                //else
                //{
                //    _DsThoiViec = ThoiViecList.GetThoiViecListTheoSoQD(cbo_SoQuyetdinh.Text, Convert.ToDateTime(dtp_Tungay.Value), Convert.ToDateTime(dtp_Denngay.Value));
                //    BindS_DSNghi.DataSource = _DsThoiViec;
                //}
            }
            catch (ApplicationException)
            {

            }
            lblTSoNghi.Text = "Tổng Số : " + _DsThoiViec.Count;
        }

        private void cbou_ChucVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(cbou_ChucVu, "TenChucVu");
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbou_ChucVu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cbou_ChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            cbou_ChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            cbou_ChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Width = 240;
        }

        private void cmbu_Bophan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Width = 250;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 1;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 250;
        }

        private void cmbu_LoaiQuyetDinh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {


            FilterCombo f = new FilterCombo(cmbu_LoaiQuyetDinh, "Tenloaiquyetdinh");
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cmbu_LoaiQuyetDinh.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_LoaiQuyetDinh.DisplayLayout.Bands[0].Columns["Tenloaiquyetdinh"].Hidden = false;
            cmbu_LoaiQuyetDinh.DisplayLayout.Bands[0].Columns["Tenloaiquyetdinh"].Header.VisiblePosition = 0;
            cmbu_LoaiQuyetDinh.DisplayLayout.Bands[0].Columns["Tenloaiquyetdinh"].Header.Caption = "Loại Quyết Định";
            cmbu_LoaiQuyetDinh.DisplayLayout.Bands[0].Columns["Tenloaiquyetdinh"].Width = 250;
        }

        private void cmbu_LyDo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            FilterCombo f = new FilterCombo(cmbu_LyDo, "LyDo");
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cmbu_LyDo.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_LyDo.DisplayLayout.Bands[0].Columns["LyDo"].Hidden = false;
            cmbu_LyDo.DisplayLayout.Bands[0].Columns["LyDo"].Header.VisiblePosition = 0;
            cmbu_LyDo.DisplayLayout.Bands[0].Columns["LyDo"].Header.Caption = "Lý do";
            cmbu_LyDo.DisplayLayout.Bands[0].Columns["LyDo"].Width = 250;
  
        }

        private void cmbu_NguoiKy_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
           
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cmbu_NguoiKy.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            FilterCombo f = new FilterCombo(cmbu_NguoiKy, "TenNhanVien");
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
        }

       
        private void grdu_DSThoiViec_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaThoiViec"].Hidden = true;
           // grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["NgayKy"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["NguoiKy"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaChucVuNguoiKy"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenLoaiQuyetDinh"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenLyDoThoiViec"].Hidden = true;

            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Số";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 170;

          
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaLoaiQuyetDinh"].Header.Caption = "Loại Quyết Định Thôi Việc";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaLyDoThoiViec"].Header.Caption = "Lý Do Thôi Việc";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaLyDoThoiViec"].EditorComponent = cmbu_LyDo;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaLoaiQuyetDinh"].EditorComponent = cmbu_LoaiQuyetDinh;
            //grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenLoaiQuyetDinh"].Header.Caption = "Loại Quyết Định Thôi Việc";
            //grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenLyDoThoiViec"].Header.Caption = "Lý Do Thôi Việc";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.Caption = "Số Quyết Định";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["NgayKy"].Header.Caption = "Ngày Ký";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.Caption = "Ngày Hiệu Lực";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TroCapThoiViec"].Header.Caption = "Trợ Cấp Thôi Việc";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TroCapKhac"].Header.Caption = "Trợ Cấp Khác";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 0;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenLoaiQuyetDinh"].Header.VisiblePosition = 2;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenLyDoThoiViec"].Header.VisiblePosition = 3;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.VisiblePosition = 4;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.VisiblePosition = 5;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TroCapThoiViec"].Header.VisiblePosition = 6;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TroCapKhac"].Header.VisiblePosition = 7;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 8;

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSThoiViec.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
           
        }

        private void frmNghiViecChamDutHD_Load(object sender, EventArgs e)
        {
            dtmp_NgayHieuLuc.Value = DateTime.Now;
            dtp_NgayKy.Value = DateTime.Now;
            dtp_ngaylap.Value = DateTime.Now;
            dtp_Denngay.Value = DateTime.Now;
            dtp_Tungay.Value = Convert.ToDateTime(dtp_Denngay.Value).AddMonths(-1);
        }
        #endregion

        #region Event
        private void tlslblQuyetDinh_Click(object sender, EventArgs e)
        {
            NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            int Tinhtrang =0;
            //if (cmbu_LyDo.Value == null || cmbu_NguoiKy.Value == null || cmbu_LoaiQuyetDinh.Value == null || txtu_SoQuyetDinh.Text.Trim() == "" || cbou_ChucVu.Value == null)
            //{
            //    MessageBox.Show(this, "Nhập Thông Tin Cho Quyết Định Nghỉ Việc !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            Tinhtrang=radChuaChi.Checked ? 0 :1;
            DialogResult = MessageBox.Show(this, "Quyết Định Nghỉ Việc Cho Các Nhân Viên Được Chọn (Yes/No) ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < lstvDsnguon.Items.Count; i++)
                {
                    if (lstvDsnguon.Items[i].Checked == true)
                    {
                        ThoiViec.Thoiviec(Convert.ToInt64(lstvDsnguon.Items[i].Text), (int)cmbu_LoaiQuyetDinh.Value, (int)cmbu_LyDo.Value, txtu_SoQuyetDinh.Text, Convert.ToDateTime(dtmp_NgayHieuLuc.Value), Convert.ToDateTime(dtp_NgayKy.Value),(long)cmbu_NguoiKy.Value,(int)cbou_ChucVu.Value,crec_TroCapThoiViec.Value,crec_TroCapKhac.Value,txtu_GhiChu.Text,NguoiLap,Convert.ToDateTime(dtp_ngaylap.Value),Tinhtrang);
                    }
                }
                Load_Source();
                this.Load_Nguon();
                this.Load_Dich();
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _DsThoiViec.ApplyEdit();
                _DsThoiViec.Save();
                MessageBox.Show(this, "Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ApplicationException)
            {

            }

        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Source();
            this.Load_Nguon();
            this.Load_Dich();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            this.Load_Nguon();
            this.Load_Dich();
        }

        private void txt_NhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Load_Nguon();
            }
        }

        private void cbo_SoQuyetdinh_ValueChanged(object sender, EventArgs e)
        {
            this.Load_Dich();
        }
      
        private void cbou_ChucVu_ValueChanged(object sender, EventArgs e)
        {
            if (cbou_ChucVu.ActiveRow != null)
            {
               _TTNhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_ChucVu((int)cbou_ChucVu.Value);
                BindS_NguoiKy.DataSource = _TTNhanVienList;
            }
        }

        private void mẫuChấmDứtHĐLĐToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (maThoiViec==0)
            {
                MessageBox.Show(this, "Chọn Số Quyết Định Cần In", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ReportDocument Report = new ReportDocument();
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_QuyetDinhThoiViec";
            command.Parameters.AddWithValue("@MaThoiViec", maThoiViec);

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_QuyetDinhThoiViec;1";

            dataset.Tables.Add(table);
            Report.SetDataSource(dataset);
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void mẫuSaThảiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (maThoiViec==0)
            {
                MessageBox.Show(this, "Chọn Số Quyết Định Cần In", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ReportDocument Report = new ReportDocument();
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_QuyetDinhThoiViec";
            command.Parameters.AddWithValue("@MaThoiViec",maThoiViec);

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_QuyetDinhThoiViec;1";

            dataset.Tables.Add(table);
            Report.SetDataSource(dataset);
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
        #endregion

        private void dtp_Tungay_ValueChanged(object sender, EventArgs e)
        {
            this.Load_Dich();
        }

        private void dtp_Denngay_ValueChanged(object sender, EventArgs e)
        {
            this.Load_Dich();
        }

        private void grdu_DSThoiViec_AfterRowActivate(object sender, EventArgs e)
        {
            maThoiViec = (int)grdu_DSThoiViec.ActiveRow.Cells["MaThoiViec"].Value;
        }

        private void grdu_DSThoiViec_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            maThoiViec = (int)grdu_DSThoiViec.ActiveRow.Cells["MaThoiViec"].Value;
        }

        #region Process
        #endregion


    }
}