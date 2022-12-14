 #region Using
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
#endregion

namespace PSC_ERP
{
    public partial class frmNhapMuaBan : Form
    {
        #region Properties
        KhoList _dsKho = KhoList.NewKhoList();
        TenNhanVienList _dsNhanVien = TenNhanVienList.NewTenNhanVienList();
        LenhNhapXuatMuaBanList _dsLenhNX = LenhNhapXuatMuaBanList.NewLenhNhapXuatMuaBanList();
        PhieuNhapXuat _phieuNX = PhieuNhapXuat.NewPhieuNhapXuat();
        DoiTuongNhapXuat _DoiTuongNhapXuat;
        Int16 _loai;
        Int16 _loaiLenhNX;
        byte _quyTrinh;
        byte _doiTuongNhapXuat = 0;
        HamDungChung hamDungChung = new HamDungChung();
        LenhNhapXuatMuaBan _LenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan();
        Util util = new Util();
        #endregion 

        #region Contructors
        public frmNhapMuaBan()
        {
            InitializeComponent();
            KhaiBaoSuKien();
        }
        
        public frmNhapMuaBan(PhieuNhapXuat phieuNhapXuat)
        {
            InitializeComponent();           
            KhaiBaoSuKien();
            _phieuNX = phieuNhapXuat;            
            KhoiTao(phieuNhapXuat.Loai, phieuNhapXuat.QuyTrinh);
            KhoiTao(phieuNhapXuat);
            KhoiTaoDinhKhoan();
        }

        public frmNhapMuaBan(Int16 loai, byte quyTrinh)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao(loai, quyTrinh);            
            KhoiTaoDinhKhoan();
        }
       
        #endregion 

        #region Khai Báo Sự Kiện
        private void KhaiBaoSuKien()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(ugrButToan);
            hamDungChung.EventGrid(grdu_ChiTiet);
            hamDungChung.EventsControl(cmb_KhoNhap);
            
            hamDungChung.EventsControl(cbu_NhanVien);          
            hamDungChung.EventsControl(ultraCombo_CoTaiKhoan);          
            hamDungChung.EventsControl(ultraCombo_NoTaiKhoan);          
        }
        #endregion 

        #region Định Khoản

        #region Khởi Tạo
        private void SetDataDinhKhoanButToan()
        {
            DinhKhoanbindingSource.DataSource = _phieuNX.MaDinhKhoan;
            butToanBindingSource.DataSource = _phieuNX.MaDinhKhoan.ButToan;

            if (_phieuNX.MaDinhKhoan != null)
            {
                if (_phieuNX.MaDinhKhoan.LaMotNoNhieuCo == true)
                {
                    ChonNoLoad();
                    if (_phieuNX.MaDinhKhoan.ButToan[0].NoTaiKhoan != 0)
                        ultraCombo_NoTaiKhoan.Value = _phieuNX.MaDinhKhoan.ButToan[0].NoTaiKhoan;
                }
                else
                {
                    ChonCoLoad();
                    if (_phieuNX.MaDinhKhoan.ButToan[0].CoTaiKhoan != 0)
                        ultraCombo_CoTaiKhoan.Value = _phieuNX.MaDinhKhoan.ButToan[0].CoTaiKhoan;
                }
            }
            else
            {
                ChonCoLoad();
            }
        }


        private void KhoiTaoDinhKhoan()
        {

            NoTaiKhoanBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List(0);
            CoTaiKhoanBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List(0);
            DinhKhoanbindingSource.DataSource = _phieuNX.MaDinhKhoan;
            butToanBindingSource.DataSource = _phieuNX.MaDinhKhoan.ButToan;

            if (_phieuNX.MaDinhKhoan != null)
            {
                if (_phieuNX.MaDinhKhoan.LaMotNoNhieuCo == false)
                {
                    
                    ChonCoLoad();
                }
                else ChonNoLoad();
            }
            else
            {
                ChonNoLoad();
            }
            //this.ucmbeditTaiKhoanNC.ValueChanged += new EventHandler(ucmbeditTaiKhoanNC_ValueChanged);            
        }

        void ucmbeditTaiKhoanNC_ValueChanged(object sender, EventArgs e)
        {
            LayNoCoTaiKhoan();
            ThayDoiNoCoTaiKhoan();
        }

        #endregion

        #region hàm thay đổi nợ có tài khoản
        private void ThayDoiNoCoTaiKhoan()
        {
            if (ucmbeditTaiKhoanNC.Text == "Có")
            {
                foreach (ButToan bt in _phieuNX.MaDinhKhoan.ButToan)
                {
                    bt.CoTaiKhoan = Convert.ToInt32(ultraCombo_CoTaiKhoan.Value);
                }
                _phieuNX.MaDinhKhoan.LaMotNoNhieuCo = false;
            }
            if (ucmbeditTaiKhoanNC.Text == "Nợ")
            {
                foreach (ButToan bt in _phieuNX.MaDinhKhoan.ButToan)
                {
                    bt.NoTaiKhoan = Convert.ToInt32(ultraCombo_NoTaiKhoan.Value);
                }
                _phieuNX.MaDinhKhoan.LaMotNoNhieuCo = true;
            }
            butToanBindingSource.DataSource = _phieuNX.MaDinhKhoan.ButToan;
        }
        #endregion

        #region lấy nợ có tài khoản
        private void LayNoCoTaiKhoan()
        {
            Int32 NoTaiKhoan =0 ;
            Int32 CoTaiKhoan = 0;
            if(NoTaiKhoanBindingSource.Current != null) 
                NoTaiKhoan = ((HeThongTaiKhoan1)NoTaiKhoanBindingSource.Current).MaTaiKhoan;
            if (CoTaiKhoanBindingSource.Current != null)
                CoTaiKhoan = ((HeThongTaiKhoan1)CoTaiKhoanBindingSource.Current).MaTaiKhoan;
            if (ucmbeditTaiKhoanNC.Text == "Có")
            {
                if (_phieuNX.MaDinhKhoan.ButToan.Count != 0)
                {
                    CoTaiKhoan = _phieuNX.MaDinhKhoan.ButToan[0].CoTaiKhoan;
                }
                ugrButToan.DisplayLayout.Bands["ButToan"].Columns["CoTaiKhoan"].Hidden = true;
                ugrButToan.DisplayLayout.Bands["ButToan"].Columns["NoTaiKhoan"].Hidden = false;
                ugrButToan.DisplayLayout.Bands["ButToan"].Columns["CoTaiKhoan"].DefaultCellValue = CoTaiKhoan; //ultraCombo_CoTaiKhoan.Value;                
                ultraCombo_CoTaiKhoan.Value = CoTaiKhoan;
                ultraCombo_CoTaiKhoan.Visible = true;
                ultraCombo_NoTaiKhoan.Visible = false;
                ChonCo();
            }
            else
            {

                if (_phieuNX.MaDinhKhoan.ButToan.Count != 0)
                {
                    NoTaiKhoan = _phieuNX.MaDinhKhoan.ButToan[0].NoTaiKhoan;
                }
                ugrButToan.DisplayLayout.Bands["ButToan"].Columns["NoTaiKhoan"].Hidden = true;
                ugrButToan.DisplayLayout.Bands["ButToan"].Columns["CoTaiKhoan"].Hidden = false;
                ugrButToan.DisplayLayout.Bands["ButToan"].Columns["NoTaiKhoan"].DefaultCellValue = NoTaiKhoan;//ultraCombo_NoTaiKhoan.Value;
                ultraCombo_NoTaiKhoan.Value = NoTaiKhoan;
                ultraCombo_NoTaiKhoan.Visible = true;
                ultraCombo_CoTaiKhoan.Visible = false;

                ChonNo();
            }

            butToanBindingSource.DataSource = _phieuNX.MaDinhKhoan.ButToan;
        }

        #endregion

        #region Chọn Nợ Có

        private void ChonNo()
        {
            this.ultraCombo_NoTaiKhoan.ValueChanged += new EventHandler(ultraCombo_NoTaiKhoan_ValueChanged);
            this.ultraCombo_CoTaiKhoan.ValueChanged -= new EventHandler(ultraCombo_CoTaiKhoan_ValueChanged);
        }
        private void ChonCo()
        {
            this.ultraCombo_CoTaiKhoan.ValueChanged += new System.EventHandler(this.ultraCombo_NoTaiKhoan_ValueChanged);
            this.ultraCombo_NoTaiKhoan.ValueChanged -= new System.EventHandler(this.ultraCombo_NoTaiKhoan_ValueChanged);
        }
        void ultraCombo_CoTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            ThayDoiNoCoTaiKhoan();
            if (ultraCombo_CoTaiKhoan.ActiveRow != null)
                lbDienGiai.Text = ultraCombo_CoTaiKhoan.ActiveRow.Cells["TenTaiKhoan"].Value.ToString();
        }

        void ultraCombo_NoTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            ThayDoiNoCoTaiKhoan();
            if (ultraCombo_NoTaiKhoan.ActiveRow != null)
                lbDienGiai.Text = ultraCombo_NoTaiKhoan.ActiveRow.Cells["TenTaiKhoan"].Value.ToString();
        }

        private void ChonNoLoad()
        {
            _phieuNX.MaDinhKhoan.LaMotNoNhieuCo = true;
            ucmbeditTaiKhoanNC.Text = "Nợ";
        }

        private void ChonCoLoad()
        {
            _phieuNX.MaDinhKhoan.LaMotNoNhieuCo = false;
            ucmbeditTaiKhoanNC.Text = "Có";
        }

        #endregion

        #region các Even

        #region ugrButToan_InitializeLayout
        private void ugrButToan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowAddNew = AllowAddNew.FixedAddRowOnTop;
            //e.Layout.Override.AllowAddNew = AllowAddNew.FixedAddRowOnBottom;
            e.Layout.Override.TemplateAddRowPrompt = "Click vào đây để thêm dòng mới";
            e.Layout.Override.TemplateAddRowAppearance.BackColor = Color.FromArgb(245, 250, 255);
            e.Layout.Override.TemplateAddRowAppearance.ForeColor = SystemColors.GrayText;
            e.Layout.Override.AddRowAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.AddRowAppearance.ForeColor = Color.Blue;
            e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.TemplateAddRow;
            e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = SystemColors.Control;
            e.Layout.Override.TemplateAddRowPromptAppearance.ForeColor = Color.Maroon;
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
           // ugrButToan.DisplayLayout.Bands["ButToan"].Columns.Add("ChiTiet", "Chi Tiết");           
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["DoiTuongCo"].Hidden = true;
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["DoiTuongNo"].Hidden = true;
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["MaButToan"].Hidden = true;
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["NoTaiKhoan"].Header.Caption = "Nợ Tài Khoản";
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["NoTaiKhoan"].Header.VisiblePosition = 1;
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["NoTaiKhoan"].EditorControl = ultraCombo_NoTaiKhoan;
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["CoTaiKhoan"].Header.Caption = "Có Tài Khoản";
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["CoTaiKhoan"].Header.VisiblePosition = 2;
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["CoTaiKhoan"].EditorControl = ultraCombo_CoTaiKhoan;
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["CoTaiKhoan"].Header.Caption = "Có Tài Khoản";
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["DienGiai"].Header.VisiblePosition = 4;
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["DienGiai"].Width = 300;
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["SoTien"].Header.Caption = "Số Tiền";
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["SoTien"].Header.VisiblePosition = 3;
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn";
            ugrButToan.DisplayLayout.Bands["ButToan"].Columns["SoTien"].PromptChar = ' ';
           // ugrButToan.DisplayLayout.Bands["ButToan"].Columns["ChiTiet"].EditorControl = txtu_ChiTiet;

            ugrButToan.DisplayLayout.Bands["ButToan"].Override.RowSelectors = DefaultableBoolean.True;
            UltraGridColumn columnToSummarize2 = e.Layout.Bands["ButToan"].Columns["SoTien"];
            SummarySettings summary2 = ugrButToan.DisplayLayout.Bands["ButToan"].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.Left;
            summary2.DisplayFormat = "Tông Tiền = {0:###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            ugrButToan.DisplayLayout.Bands["ButToan"].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            foreach (UltraGridColumn col in this.ugrButToan.DisplayLayout.Bands["ButToan"].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;//x =  //= System.Drawing.w;//RoyalBlue
            }

            foreach (UltraGridBand band in this.ugrButToan.DisplayLayout.Bands)
            {
                foreach (UltraGridColumn column in band.Columns)
                {
                    if (column.DataType.ToString() == "System.Decimal")
                    {
                        column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        column.Format = "###,###,###";
                    }
                }
            }
            ugrButToan.DisplayLayout.Bands["ChiTietButToanList"].Hidden = true;
            ugrButToan.DisplayLayout.Bands["MucNganSach"].Hidden = true;
        }
        #endregion

        #region ugrButToan_Error
        private void ugrButToan_Error(object sender, Infragistics.Win.UltraWinGrid.ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.Data)
                e.ErrorText = "Kiểu dữ liệu không hợp lệ";
        }
        #endregion

        #region ugrButToan_KeyDown
        private void ugrButToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ugrButToan.UpdateData();
            }
        }
        #endregion

        #endregion

        #endregion

        #region Khởi Tạo
        private void KhoiTao(Int16 loai, byte quyTrinh)
        {
            _loai = loai;
            _quyTrinh = quyTrinh;            
          
            _loaiLenhNX = _loai;

            _dsKho = KhoList.GetKhoList_LoaiKho(0);
            _dsNhanVien = TenNhanVienList.GetTenNhanVienList();         

            khoListBindingSource.DataSource = _dsKho;
            tenNhanVienListBindingSource.DataSource = _dsNhanVien;
            
            PhieuNX_bindingSource.DataSource = _phieuNX;
            _phieuNX.Loai = _loai;
            _phieuNX.QuyTrinh = _quyTrinh;
            if (_loai != 3 && _loai != 4 && _loai != 19 && _loai != 20)
            {

            }
            else
                khoDaiLyListBindingSource.DataSource = KhoList.GetKhoList_KhoDaiLy(); 
        }

        private void KhoiTao(PhieuNhapXuat phieuNhapXuat)
        {
            txt_LenhNhap.Enabled = false;
            if (phieuNhapXuat.DoiTuongNhapXuatList.Count != 0)
            {
                LenhNhapXuatMuaBan lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.GetLenhNhapXuatMuaBan(phieuNhapXuat.DoiTuongNhapXuatList[0].MaLenhNhapXuat);
                txt_LenhNhap.Text = lenhNhapXuatMuaBan.SoBangKe;
            }
        }
        #endregion 

        #region Sự Kiện
        
        #region Kiểm Tra Dữ Liệu
        private Boolean KiemTraDuLieu()
        {
            if(_phieuNX.MaKho == 0)
            {
                MessageBox.Show(this,"Vui Lòng Chọn Kho Nhập", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

             //if (cmb_NguoiNhap.SelectedValue != null)
             //{
             //    MessageBox.Show(this, "Chưa Chọn Người Nhập Hàng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             //    return false;
             //}
             
            if(_phieuNX.CT_PhieuNXList.Count ==0 )
            {
                MessageBox.Show(this,"Vui Lòng Nhập Chi Tiết Phiếu Nhập", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }                   
            if(_phieuNX.MaDinhKhoan.ButToan.Count != 0)
            {
                Decimal TongTien =0 ;
                foreach(ButToan _buttoan in _phieuNX.MaDinhKhoan.ButToan)
                {
                    TongTien += _buttoan.SoTien;
                }
                if(TongTien != _phieuNX.GiaTriKho)
                {
                    MessageBox.Show(this,"Vui Lòng Nhập Số Tiền Bút Toán = Giá Trị Nhập Kho", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }            
            
            return true;
        }
        #endregion 

        #region luuToolStripMenuItem_Click
        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(KiemTraDuLieu() == true)
            {
                if (MessageBox.Show("Bạn có muốn lưu không?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    txt_SoPhieu.Focus();
                    txb_DienGiai.Focus();
                    PhieuNX_bindingSource.EndEdit();
                    try
                    {
                        if (_phieuNX.IsDirty || _phieuNX.IsNew)
                        {

                                PhieuNX_bindingSource.EndEdit();
                                _phieuNX.Save();
                                txt_LenhNhap.Enabled = false;
                                MessageBox.Show(this, "Lưu thành công!", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);                            
                                txt_SoPhieu.ReadOnly = true;
                            }                           
                    }
                    catch (ApplicationException ex)
                    {                    
                        
                    }
                }
            }
        }
        #endregion 

        #region tìmToolStripMenuItem_Click
        private void tìmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimPhieuXuatMuaBan frm = new frmTimPhieuXuatMuaBan(true, _loai, _quyTrinh);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                _phieuNX = frm.phieuNhapXuat;
                PhieuNX_bindingSource.DataSource = _phieuNX;
                txt_LenhNhap.Enabled = false;
            }
        }
        #endregion 

        #region thêmToolStripMenuItem_Click
        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                DialogResult result = MessageBox.Show("Bạn có muốn lưu phiếu này không?", "Thông Báo", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                    return;
                else if (result == DialogResult.No)
                {
                    _phieuNX = PhieuNhapXuat.NewPhieuNhapXuat();                    
                    PhieuNX_bindingSource.DataSource = _phieuNX;
                    txt_LenhNhap.Enabled = true;
                    txt_SoPhieu.ReadOnly = false;
                }
                else
                {
                    luuToolStripMenuItem_Click(sender, e);
                    // neu ko luu dc thi thoat neu thanh cong thi tao moi
                    if (_phieuNX.IsDirty || _phieuNX.IsNew)
                        return;
                    else
                    {
                        _phieuNX = PhieuNhapXuat.NewPhieuNhapXuat();                        
                        PhieuNX_bindingSource.DataSource = _phieuNX;
                        txt_LenhNhap.Enabled = true;
                        txt_SoPhieu.ReadOnly = false;
                    }
                }           
         }
        #endregion 

        #region inToolStripMenuItem_Click
            private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_phieuNX.IsNew == false)
            {
                DataSet _ds = new DataSet();

                ReportDocument Report = new Report.Report_MuaBan.PhieuNhapKho();

                SqlCommand cm1 = new SqlCommand();
                cm1.CommandType = CommandType.StoredProcedure;
                cm1.CommandText = "spd_LayCoTaiKhoan_PhieuNhapXuat";
                cm1.Parameters.AddWithValue("@MaPhieuNhapXuat", _phieuNX.MaPhieuNhapXuat);
                cm1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlDataAdapter _adapter = new SqlDataAdapter(cm1);
                DataTable _table1 = new DataTable();
                _adapter.Fill(_table1);
                _table1.TableName = "spd_LayCoTaiKhoan_PhieuNhapXuat;1";

                SqlCommand cm3 = new SqlCommand();
                cm3.CommandType = CommandType.StoredProcedure;
                cm3.CommandText = "spd_LayNoTaiKhoan_PhieuNhapXuat";
                cm3.Parameters.AddWithValue("@MaPhieuNhapXuat", _phieuNX.MaPhieuNhapXuat);
                cm3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                _adapter = new SqlDataAdapter(cm3);
                DataTable _table3 = new DataTable();
                _adapter.Fill(_table3);
                _table3.TableName = "spd_LayNoTaiKhoan_PhieuNhapXuat;1";

                SqlCommand cm2 = new SqlCommand();
                cm2.CommandType = CommandType.StoredProcedure;
                cm2.CommandText = "spd_REPORT_PhieuNhapXuatKho";
                cm2.Parameters.AddWithValue("@MaPhieuNhapXuat", _phieuNX.MaPhieuNhapXuat);
                cm2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                _adapter = new SqlDataAdapter(cm2);
                DataTable _table2 = new DataTable();
                _adapter.Fill(_table2);
                _table2.TableName = "spd_REPORT_PhieuNhapXuatKho;1";


                SqlCommand cm4 = new SqlCommand();
                cm4.CommandType = CommandType.StoredProcedure;
                cm4.CommandText = "spd_REPORT_ReportHeader";
                cm4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                _adapter = new SqlDataAdapter(cm4);
                DataTable _table4 = new DataTable();
                _adapter.Fill(_table4);
                _table4.TableName = "spd_REPORT_ReportHeader;1";

                _ds.Tables.Add(_table1);
                _ds.Tables.Add(_table2);
                _ds.Tables.Add(_table3);
                _ds.Tables.Add(_table4);

                Report.SetDataSource(_ds);
                Report.SetParameterValue("@MaPhieuNhapXuat", _phieuNX.MaPhieuNhapXuat);
                frmHienThiReport frm = new frmHienThiReport();
                frm.crytalView_HienThiReport.ReportSource = Report;
                frm.Show();
            }
            else
            {
                MessageBox.Show(this, "Vui Lòng Cập Nhật Phiếu Xuất Trước Khi In", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
            #endregion        

        #region grdu_ChiTiet_AfterCellUpdate
        private void grdu_ChiTiet_AfterCellUpdate(object sender, CellEventArgs e)
        {
            _phieuNX.Update_Data_PhieuNhapXuat();
        }
        #endregion 

        #region thoatToolStripMenuItem_Click
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion       

        #region txt_LenhNhap_KeyDown
        private void txt_LenhNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmTimLenhNhapXuat dlg = new frmTimLenhNhapXuat(txt_LenhNhap.Text, true, 0, _loaiLenhNX, _quyTrinh, _doiTuongNhapXuat);
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    _LenhNhapXuatMuaBan = dlg._LenhNhapXuatMuaBan;
                    txt_LenhNhap.Text = _LenhNhapXuatMuaBan.SoBangKe;
                    _phieuNX = PhieuNhapXuat.NewPhieuNhapMuaBan(_LenhNhapXuatMuaBan, _loai, _LenhNhapXuatMuaBan.MaKhoDoiTac);
                    if (_loai == 19)
                        _phieuNX.TrangThai = 1;
                    PhieuNX_bindingSource.DataSource = _phieuNX;
                    LenhNhapXuatMuaBanBindingSource.DataSource = _LenhNhapXuatMuaBan;
                    dlg.Close();
                }
            }
        } 
        #endregion        

        #endregion 
        
        #region ultraCombo_NoTaiKhoan_InitializeLayout
        private void ultraCombo_NoTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = true;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["MaTaiKhoanCha"].Hidden = true;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["CoDoiTuongTheoDoi"].Hidden = true;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuCo"].Hidden = true;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuNo"].Hidden = true;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoDuNoDauNam"].Hidden = true;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoDuCoDauNam"].Hidden = true;
            //  ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["MaLoaiTaiKhoan"].Hidden = true;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["CapTaiKhoan"].Hidden = true;

            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;

            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 100;
            ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;

            foreach (UltraGridColumn col in this.ultraCombo_NoTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            }
        }
        #endregion

        #region ultraCombo_CoTaiKhoan_InitializeLayout
        private void ultraCombo_CoTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = true;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["MaTaiKhoanCha"].Hidden = true;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["CoDoiTuongTheoDoi"].Hidden = true;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuCo"].Hidden = true;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuNo"].Hidden = true;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["SoDuNoDauNam"].Hidden = true;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["SoDuCoDauNam"].Hidden = true;
            //ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["MaLoaiTaiKhoan"].Hidden = true;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["CapTaiKhoan"].Hidden = true;

            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;

            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 100;
            ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;

            foreach (UltraGridColumn col in this.ultraCombo_CoTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            }
        }
        #endregion       
       
        #region txtu_ChiTiet_EditorButtonClick
        private void txtu_ChiTiet_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {

            ButToan butToan = (ButToan)(butToanBindingSource.Current);
            if (butToan.ChiTietButToanList.Count == 0)
            {
                int flag = 0;
                foreach (CT_PhieuNX ct_PhieuNX in _phieuNX.CT_PhieuNXList)
                {
                    flag = 0;
                    foreach (ButToan _butToan in _phieuNX.MaDinhKhoan.ButToan)
                    {
                        foreach (ChiTietButToan chiTietButToan in _butToan.ChiTietButToanList)
                        {
                            if (chiTietButToan.MaHangHoa == ct_PhieuNX.MaHangHoa)
                            {
                                flag = 1;
                                break;
                            }
                        }
                    }
                    if (flag == 0)
                        ((ButToan)(butToanBindingSource.Current)).ChiTietButToanList.Add(ChiTietButToan.NewChiTietButToan(ct_PhieuNX));
                }
            }
            
        }
        #endregion 

        #region tlslblInMau2_Click
        private void tlslblInMau2_Click(object sender, EventArgs e)
        {
            if (_phieuNX.IsNew == false)
            {
                DataSet _ds = new DataSet();

                ReportDocument Report = new Report.Report_MuaBan.Report_PhieuNhapKho_XiNghiep();

                SqlCommand cm1 = new SqlCommand();
                cm1.CommandType = CommandType.StoredProcedure;
                cm1.CommandText = "spd_LayCoTaiKhoan_PhieuNhapXuat";
                cm1.Parameters.AddWithValue("@MaPhieuNhapXuat", _phieuNX.MaPhieuNhapXuat);
                cm1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlDataAdapter _adapter = new SqlDataAdapter(cm1);
                DataTable _table1 = new DataTable();
                _adapter.Fill(_table1);
                _table1.TableName = "spd_LayCoTaiKhoan_PhieuNhapXuat;1";

                SqlCommand cm3 = new SqlCommand();
                cm3.CommandType = CommandType.StoredProcedure;
                cm3.CommandText = "spd_LayNoTaiKhoan_PhieuNhapXuat";
                cm3.Parameters.AddWithValue("@MaPhieuNhapXuat", _phieuNX.MaPhieuNhapXuat);
                cm3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                _adapter = new SqlDataAdapter(cm3);
                DataTable _table3 = new DataTable();
                _adapter.Fill(_table3);
                _table3.TableName = "spd_LayNoTaiKhoan_PhieuNhapXuat;1";

                SqlCommand cm2 = new SqlCommand();
                cm2.CommandType = CommandType.StoredProcedure;
                cm2.CommandText = "spd_REPORT_PhieuNhapXuatKho_XiNghiep";
                cm2.Parameters.AddWithValue("@MaPhieuNhapXuat", _phieuNX.MaPhieuNhapXuat);
                cm2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                _adapter = new SqlDataAdapter(cm2);
                DataTable _table2 = new DataTable();
                _adapter.Fill(_table2);
                _table2.TableName = "spd_REPORT_PhieuNhapXuatKho_XiNghiep;1";


                SqlCommand cm4 = new SqlCommand();
                cm4.CommandType = CommandType.StoredProcedure;
                cm4.CommandText = "spd_REPORT_ReportHeader";
                cm4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                _adapter = new SqlDataAdapter(cm4);
                DataTable _table4 = new DataTable();
                _adapter.Fill(_table4);
                _table4.TableName = "spd_REPORT_ReportHeader;1";

                _ds.Tables.Add(_table1);
                _ds.Tables.Add(_table2);
                _ds.Tables.Add(_table3);
                _ds.Tables.Add(_table4);

                Report.SetDataSource(_ds);
                Report.SetParameterValue("@MaPhieuNhapXuat", _phieuNX.MaPhieuNhapXuat);
                frmHienThiReport frm = new frmHienThiReport();
                frm.crytalView_HienThiReport.ReportSource = Report;
                frm.Show();
            }
        }
        #endregion 

        #region grdu_ChiTiet_InitializeLayout
        private void grdu_ChiTiet_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
             foreach (UltraGridColumn col in this.grdu_ChiTiet.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.Hidden = true;
                col.CellActivation = Activation.NoEdit;
            }            

            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["TenHangHoa"].Hidden = false;
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Thể Loại";
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 1;

            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Hàng Hóa/Dịch Vụ";
            
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["SoLuong"].Hidden = false;
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 2;
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["SoLuong"].MaskInput = "nnnnnnnnn";

            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Hidden = false;
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 2;
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["TenDonViTinh"].MaskInput = "nnnnnnnnn";

            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["DonGiaTonKhoSL"].Hidden = false;
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["DonGiaTonKhoSL"].Header.Caption = "Đơn Giá";
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["DonGiaTonKhoSL"].Header.VisiblePosition = 2;
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["DonGiaTonKhoSL"].MaskInput = "nnnnnnnnn";           

          
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["ThanhTien"].Hidden = false;
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 10;
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["ThanhTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["ThanhTien"].Format = "###,###,###,###,###";
            grdu_ChiTiet.DisplayLayout.Bands[0].Columns["ThanhTien"].CellAppearance.TextHAlign = HAlign.Right;           

            this.grdu_ChiTiet.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_ChiTiet.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            

        }
        #endregion 
   
        #region ugrButToan_AfterRowInsert
        private void ugrButToan_AfterRowInsert(object sender, RowEventArgs e)
        {
            Decimal soTien = _phieuNX.GiaTriKho;
            if (ultraCombo_NoTaiKhoan.Value != null || ultraCombo_CoTaiKhoan.Value != null)
            {
                if (_phieuNX.MaDinhKhoan.ButToan.Count != 0)
                {
                    foreach (ButToan bt in _phieuNX.MaDinhKhoan.ButToan)
                    {
                        soTien -= bt.SoTien;
                    }
                    ugrButToan.ActiveRow.Cells["SoTien"].Value = soTien;
                    //ugrButToan.ActiveRow.Cells["DienGiai"].Value = tbx_DienGiai.Value;
                }
            }
        }
        #endregion 

        #region cb_KhoDaiLy_SelectedValueChanged
        private void cb_KhoDaiLy_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_phieuNX.Loai == 19 && _phieuNX.IsNew)
            {
                //if (cb_KhoDaiLy.Text != null)
                //{ 
                //    int maKhoDoiTac = Convert.ToInt32(cb_KhoDaiLy.SelectedValue);
                //    _phieuNX = PhieuNhapXuat.NewPhieuNhapMuaBan(_LenhNhapXuatMuaBan, _loai, maKhoDoiTac);
                //    _phieuNX.TrangThai = 1;
                //    PhieuNX_bindingSource.DataSource = _phieuNX;
                //}
            }

        }
        #endregion

        #region cbu_NhanVien_InitializeLayout
        private void cbu_NhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cbu_NhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_NhanVien.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cbu_NhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            cbu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            cbu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
            cbu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 1;
            cbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            cbu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 2;
            cbu_NhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            cbu_NhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            cbu_NhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 3;
        }
        #endregion 

    }
}