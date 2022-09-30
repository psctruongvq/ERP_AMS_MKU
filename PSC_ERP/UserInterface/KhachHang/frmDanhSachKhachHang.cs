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
using System.IO;
using System.Data.OleDb;


namespace PSC_ERP
{
    //Thành
    public partial class frmDanhSachKhachHang : Form
    {
        #region Khai báo biến
        DoiTacList _DoiTacList;
        DoiTacList _DoiTacListSS;
        DoiTacList _listDoiTacAll_ByMaCongTy;
        Util util = new Util();
        int _loaiDoiTac = 0;
        private DataTable tblDoiTuong;


        long _ma;
        public DoiTac _DoiTac;
        string _FileNameImport = "";
        DataSet _dataSet = new DataSet();
        private int checkImport = 0;
        #endregion

        #region frmDanhSachKhachHang
        public frmDanhSachKhachHang()
        {
            InitializeComponent();
            //tlslblLuu.Enabled = false;
            //KhoiTao();
        }

        public frmDanhSachKhachHang(long ma, int loai)
        {
            InitializeComponent();
            _loaiDoiTac = loai; //tìm từ HD cầm đồ
            _ma = ma;
            //tlslblLuu.Enabled = false;
            KhoiTao();
        }
        public void ShowNhaCungCap()
        {
            _loaiDoiTac = 1;//NhaCungCap
            this.Text = "Danh Sách Nhà Cung Cấp";
            KhoiTao();
            this.Show();
        }

        public void ShowKhachHang()
        {
            _loaiDoiTac = 2;//Khach Hang
            this.Text = "Danh Sách Khách Hàng";
            KhoiTao();
            this.Show();
        }

        public void ShowNhaCungCapKhachHang()
        {
            _loaiDoiTac = 3;//Nha Cugn Cap - Khach Hang
            this.Text = "Danh Sách Đối Tượng Vừa Là Nhà Cung Cấp Vừa Là Khách Hàng";
            KhoiTao();
            this.Show();
        }
        #endregion

        #region Khởi tạo
        public TK_NganHangList tknhList;
        public DiaChi_DoiTacList dchilist;
        public NganHangList nhList;
        public void KhoiTao()
        {
            _DoiTacList = DoiTacList.GetDoiTacList(txtu_TenKhachHang.Text, _loaiDoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;

            tknhList = TK_NganHangList.NewTK_NganHangList();
            nhList = NganHangList.NewNganHangList();

        }
        #endregion

        #region tlslblTim_Click
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            //if (txtu_TenKhachHang.Text == "")
            //{
            //    MessageBox.Show(this, util.chuanhapdulieucantim, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtu_TenKhachHang.Text = "";
            //    txtu_TenKhachHang.Focus();
            //    return;
            //}
            //else 
            if (DoiTacList.GetDoiTacList(txtu_TenKhachHang.Text, _loaiDoiTac).Count == 0)
            {
                _DoiTacList = DoiTacList.NewDoiTacList();
                doiTacListBindingSource.DataSource = _DoiTacList;
                MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtu_TenKhachHang.Text = "";
                txtu_TenKhachHang.Focus();
                return;
            }
            else
            {
                _DoiTacList = DoiTacList.GetDoiTacList(txtu_TenKhachHang.Text, _loaiDoiTac);
                doiTacListBindingSource.DataSource = _DoiTacList;
            }

        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            //frmKhachHang _frmKhachHang = new frmKhachHang();
            //_frmKhachHang.Show();
        }
        #endregion

        #region tlslblXoa_Click(
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DSKhachHang.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            tlslblLuu.Enabled = true;
            grdu_DSKhachHang.DeleteSelectedRows();
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                txtu_TenKhachHang.Focus();
                _DoiTacList.ApplyEdit();
                _DoiTacList.Save();
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                string tem = ex.Message;
            }
        }
        #endregion

        #region ultragrdDSKhachHang_DoubleClick
        private void ultragrdDSKhachHang_DoubleClick(object sender, EventArgs e)
        {
            //DoiTac _DoiTac = DoiTac.GetDoiTac((long)grdu_DSKhachHang.ActiveRow.Cells["MaDoiTac"].Value);
            //this.Close();
            //frmKhachHang frmKH = new frmKhachHang(_DoiTac);
            //frmKH.Show(this);
            _DoiTac = DoiTac.GetDoiTac((long)grdu_DSKhachHang.ActiveRow.Cells["MaDoiTac"].Value);
            Form frm = new Form();
            if (_loaiDoiTac == 1)
            {
                frm = new frmNhaCungCapCustomize(_DoiTac);
            }
            else if (_loaiDoiTac == 2)
            {
                frm = new frmKhachHangCustomize(_DoiTac);
            }
            else if (_loaiDoiTac == 3)
            {
                frm = new frmNCC_KhachHangCustomize(_DoiTac);
            }
            //frmKhachHangDoiTacCustomize frm = new frmKhachHangDoiTacCustomize(_DoiTac);
            frm.ShowDialog();
            //this.Close();
        }
        #endregion

        #region ultragrdDSKhachHang_InitializeLayout
        private void ultragrdDSKhachHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //tiêu đề Khách Hàng
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Check"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["NgaySinh"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["GioiTinh"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenLop"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Ten"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["NamHoc"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenKhoi"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenTruong"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["NoiCap"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaCongTy"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaCongTyQuanLy"].Header.Caption = "Mã Công Ty";

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["LoaiDoiTac"].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Khách Hàng";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Nhà Cung Cấp";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TinhTrang"].Header.Caption = "Tình Trạng";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["NgungSuDung"].Header.Caption = "Ngưng sử dụng";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            //grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Khách Hàng";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Nhà Cung Cấp";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Dienthoai"].Header.Caption = "Điện Thoại";

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 0;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 1;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 2;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 3;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TinhTrang"].Header.VisiblePosition = 4;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["NgungSuDung"].Header.VisiblePosition = 5;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 6;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Diachi"].Header.VisiblePosition = 7;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Dienthoai"].Header.VisiblePosition = 8;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaCongTyQuanLy"].Header.VisiblePosition = 9;
            //tiêu đề Điện Thoại _ Fax
            //grdu_DSKhachHang.DisplayLayout.Bands[6].Columns["MaChiTiet"].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[6].Columns["MaDoiTac"].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[5].Columns["Active"].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[5].Columns["MaDienThoaiFax"].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[5].Columns["SoDTFax"].Header.Caption = "Số ĐT/Fax";
            //grdu_DSKhachHang.DisplayLayout.Bands[5].Columns["Loai"].Header.Caption = "Loại";

            //grdu_DSKhachHang.DisplayLayout.Bands[5].Columns["SoDTFax"].Header.VisiblePosition = 0;
            //grdu_DSKhachHang.DisplayLayout.Bands[5].Columns["Loai"].Header.VisiblePosition = 1;

            //tiêu đề Người Liên Lạc
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["MaNguoiLienLac"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["MaDoiTac"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["TenNguoiLienLac"].Header.Caption = "Tên Người Liên Lạc";
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["DienThoai"].Header.Caption = "Điện Thoại";
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["Email"].Header.Caption = "Email";

            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["TenNguoiLienLac"].Header.VisiblePosition = 0;
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["DienThoai"].Header.VisiblePosition = 1;
            grdu_DSKhachHang.DisplayLayout.Bands[1].Columns["Email"].Header.VisiblePosition = 2;

            //tiêu đề Địa Chỉ
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["MaDiaChi"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["TenDiaChiChung"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["Active"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["TenDiaChi"].Header.Caption = "Địa Chỉ";
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["QuanHuyen"].Header.Caption = "Quận Huyện";
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["TinhTP"].Header.Caption = "Tỉnh / TP";
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["QuocGia"].Header.Caption = "Quốc Gia";

            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["TenDiaChi"].Header.VisiblePosition = 0;
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["QuanHuyen"].Header.VisiblePosition = 1;
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["TinhTP"].Header.VisiblePosition = 2;
            grdu_DSKhachHang.DisplayLayout.Bands[2].Columns["QuocGia"].Header.VisiblePosition = 3;

            ////tiêu đề phương thức thanh toán
            //grdu_DSKhachHang.DisplayLayout.Bands[4].Columns["MaPhuongThucThanhToan"].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[4].Columns["MaDoiTac"].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[4].Columns["TenPhuongThucThanhToan"].Header.Caption = "Tên Phương Thức Thanh Toán";

            //grdu_DSKhachHang.DisplayLayout.Bands[4].Columns["TenPhuongThucThanhToan"].Header.VisiblePosition = 0;

            //tiêu đề tài khoản ngân hàng
            //grdu_DSKhachHang.DisplayLayout.Bands[3].Columns["MaTKNganHang"].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[3].Columns["MaDoiTac"].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[3].Columns["SoTK"].Header.Caption = "Số Tài Khoản";
            //grdu_DSKhachHang.DisplayLayout.Bands[3].Columns["TenNganHang"].Header.Caption = "Tên Ngân Hàng";

            //grdu_DSKhachHang.DisplayLayout.Bands[3].Columns["SoTK"].Header.VisiblePosition = 0;
            //grdu_DSKhachHang.DisplayLayout.Bands[3].Columns["TenNganHang"].Header.VisiblePosition = 1;

            ////tiêu đề website email
            //grdu_DSKhachHang.DisplayLayout.Bands[6].Columns["MaChiTiet"].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[6].Columns["MaDoiTac"].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[6].Columns["MaWebsiteEmail"].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[6].Columns["DiaChi"].Header.Caption = "Địa Chỉ Email/Web";
            //grdu_DSKhachHang.DisplayLayout.Bands[6].Columns["Loai"].Header.Caption = "Loại";

            //grdu_DSKhachHang.DisplayLayout.Bands[6].Columns["DiaChi"].Header.VisiblePosition = 0;
            //grdu_DSKhachHang.DisplayLayout.Bands[6].Columns["Loai"].Header.VisiblePosition = 1;

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[1].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[2].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[3].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[4].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[5].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[6].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.grdu_DSKhachHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_DSKhachHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            e.Layout.Override.TemplateAddRowPromptAppearance.FontData.Bold = DefaultableBoolean.True;
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;
            e.Layout.Override.RowSelectors = DefaultableBoolean.True;
            e.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;
        }
        #endregion

        #region tlsLamTuoi_Click
        private void tlsLamTuoi_Click(object sender, EventArgs e)
        {
            KhoiTao();
        }
        #endregion

        #region txtu_TenKhachHang_KeyDown
        private void txtu_TenKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtu_TenKhachHang.Text == "")
                {
                    MessageBox.Show(this, util.chuanhapdulieucantim, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtu_TenKhachHang.Text = "";
                    txtu_TenKhachHang.Focus();
                    return;
                }
                else if (DoiTacList.GetDoiTacList(txtu_TenKhachHang.Text, _loaiDoiTac).Count == 0)
                {
                    MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtu_TenKhachHang.Text = "";
                    txtu_TenKhachHang.Focus();
                    return;
                }
                else
                {
                    _DoiTacList = DoiTacList.GetDoiTacList(txtu_TenKhachHang.Text, _loaiDoiTac);
                    doiTacListBindingSource.DataSource = _DoiTacList;
                }
            }
        }
        #endregion

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {

            ReportDocument Report = new Report.Report_MuaBan.DanhSachKhachHang();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_Report_DanhSachKhachHang";
            command.Parameters.AddWithValue("@MaLoaiKhachHang", 0);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_DanhSachKhachHang;1";

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_Report_ReportHeader";
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_Report_ReportHeader;1";

            DataSet myDataSet = new DataSet();
            myDataSet.Tables.Add(table);
            myDataSet.Tables.Add(table1);
            Report.SetDataSource(myDataSet);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();

        }

        #endregion

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_DSKhachHang);
        }

        private void btnExportMau_Click(object sender, EventArgs e)
        {
            //HamDungChung.ExportToExcel(grdu_DSHoaDon);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Excel|*.xlsx|All file|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //tạo file template
                FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Write(Properties.Resources.Template_Import_DoiTuong, 0, Properties.Resources.Template_Import_DoiTuong.Length);
                fs.Close();




                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(dlg.FileName);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                _FileNameImport = "";
                //isimportfromExcel = true;
                #region Old
                OpenFileDialog oFD = new OpenFileDialog();
                oFD.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                oFD.ShowDialog();
                string path = oFD.FileName;
                string p = System.IO.Path.GetFileName(path);
                _FileNameImport = p;
                //DataTable tblResult = ImportExcelXLS(path, true);
                //ImportToTable(tblResult);
                DataSet dsRerult = ImportExcelXLSToDataset(path, true);
                ImportToChungTuFromDataSet(dsRerult);
                //ImportToChiTietNhapXuatFromDataSet(dsRerult);
                //BindingData();
                //if (_ChungTuImportFromExcelList.Count > 0)
                //{
                //    btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //}
                //if (_ChungTuImportFromExcelList.Count > 0)
                //{
                //    btnLuuCTNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //}
                #endregion//Old

                //isimportfromExcel = false;
            }
            catch
            {
                MessageBox.Show("Không thể đọc file!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DataSet ImportExcelXLSToDataset(string FileName, bool hasHeaders)
        {

            #region Old
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";

            _dataSet = new DataSet();
            DataTable outputTable = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = schemaRow["TABLE_NAME"].ToString();

                    if (sheet == "Sheet1$" && !sheet.EndsWith("_"))
                    {
                        try
                        {
                            outputTable = new DataTable();
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "A5:H]", conn);
                            cmd.CommandType = CommandType.Text;

                            outputTable = new DataTable(sheet);
                            outputTable.TableName = "DoiTuong";
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                            _dataSet.Tables.Add(outputTable);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }


                }
            }

            return _dataSet;
            #endregion//Old
        }

        private bool KiemTraTonTaiDoiTuong(string MaDoiTac, string filepath, string STT)
        {
            //foreach (DoiTac item in _DoiTacListSS)
            foreach (DoiTac item in _listDoiTacAll_ByMaCongTy)
            {
                if (item.MaQLDoiTac == MaDoiTac)
                {

                    System.IO.StreamWriter str = System.IO.File.AppendText(filepath);
                    str.WriteLine(STT + "  " + item.MaQLDoiTac);
                    str.Close();
                    //FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt)//fs là 1 FileStream 

                    //StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
                    //sWriter.WriteLine(item.MaQLDoiTac);
                    // Ghi và đóng file
                    //sWriter.Flush();

                    //fs.Close();
                    return false;
                }
            }
            return true;
        }


        private void ImportToChungTuFromDataSet(DataSet dsresult)
        {

            #region NCC
            if (_loaiDoiTac == 1)
            {

                _DoiTacList = DoiTacList.NewDoiTacList();
                _DoiTac = DoiTac.NewDoiTac();


                _DoiTacListSS = DoiTacList.NewDoiTacList();
                _DoiTacListSS = DoiTacList.GetDoiTacListByTen(_loaiDoiTac);

                MessageBox.Show("Chọn nơi lưu file chứa các đối tượng lỗi không thêm được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.AddExtension = true;
                dlg.Filter = "Text File|*.txt";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //tạo file template
                    FileStream fsa = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fsa.Close();
                }
                string filepath = dlg.FileName;
                //String filepath = "E:\\test.txt";// đường dẫn của file muốn tạo

                FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt)//fs là 1 FileStream 

                StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
                sWriter.WriteLine("Danh Sách Đối Tượng Bị Trùng Mã");
                //Ghi và đóng file
                sWriter.Flush();

                fs.Close();

                if (dsresult.Tables.Count == 0) return;
                tblDoiTuong = new DataTable();
                tblDoiTuong = dsresult.Tables["DoiTuong"];
                if (tblDoiTuong.Rows.Count > 0)
                {
                    foreach (DataRow rowhd in tblDoiTuong.Rows)
                    {
                        if (rowhd[1].ToString().Trim().Length == 0 && rowhd[2].ToString().Trim().Length == 0)//MaDoiuong va TenDoiTuong = rong
                        {
                            break;
                        }
                        //STT
                        double sTT = 0;
                        double sTTOut;
                        if (double.TryParse(rowhd[0].ToString(), out sTTOut))
                        {
                            sTT = sTTOut;
                        }

                        if (rowhd[1].ToString().Trim() != "")
                        {
                            //LoaiChungTu
                            if (KiemTraTonTaiDoiTuong(rowhd[1].ToString().Trim(), filepath, rowhd[0].ToString()) != false)
                            {

                                _DoiTac = DoiTac.NewDoiTac();

                                DiaChi_DoiTac dchi = DiaChi_DoiTac.NewDiaChi_DoiTac();
                                DiaChi_DoiTacList dchilist = _DoiTac.DiaChi_DoiTacList;

                                TK_NganHang tknh = TK_NganHang.NewTK_NganHang();
                                TK_NganHangList tknhList = _DoiTac.TK_NganHangList;

                                NhomNganHang nnh = NhomNganHang.NewNhomNganHang();
                                NhomNganHangList nnhList = NhomNganHangList.NewNhomNganHangList();

                                _DoiTac.MaQLDoiTac = rowhd[1].ToString();
                                _DoiTac.TenDoiTac = rowhd[2].ToString();
                                _DoiTac.TenVietTat = "";
                                _DoiTac.MaSoThue = rowhd[3].ToString();
                                _DoiTac.TinhTrang = true;
                                _DoiTac.LoaiDoiTac = 1;
                                _DoiTac.DienGiai = "";

                                dchi.TenDiaChi = rowhd[4].ToString();
                                dchi.Active = true;
                                dchilist.Add(dchi);

                                if (rowhd[6].ToString().Trim() != "" && rowhd[6].ToString().Trim() != "NULL")
                                {
                                    nnhList = nnhList.GetNhomNganHangList(rowhd[6].ToString());
                                    tknh.SoTK = rowhd[5].ToString();
                                    //if (nnhList.Count > 0)
                                    //{
                                        tknh.MaNganHang = Convert.ToInt32(nnhList[0].MaNhomNganHang.ToString());
                                    //}
                                    if (rowhd[7].ToString().Trim() != "" && rowhd[7].ToString().Trim() != "NULL")
                                        tknh.TenNganHang = rowhd[6].ToString() + " - " + rowhd[7].ToString();
                                    else
                                        tknh.TenNganHang = rowhd[6].ToString();
                                }
                                tknhList.Add(tknh);
                                _DoiTacList.Add(_DoiTac);
                            }
                        }
                    }

                }

                DialogResult NCC = MessageBox.Show("Bạn có muốn lưu đối tượng mới import", "Thông báo!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (NCC == DialogResult.OK)
                {
                    tlslblLuu.PerformClick();
                    KhoiTao();
                }
            }

            #endregion//NCC

            else if (_loaiDoiTac == 2)
            {


                _DoiTacListSS = DoiTacList.NewDoiTacList();
                _DoiTacListSS = DoiTacList.GetDoiTacListByTen(_loaiDoiTac);

                _DoiTacList = DoiTacList.NewDoiTacList();
                _DoiTac = DoiTac.NewDoiTac();

                MessageBox.Show("Chọn nơi lưu file chứa các đối tượng lỗi không thêm được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.AddExtension = true;
                dlg.Filter = "Text File|*.txt";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //tạo file template
                    FileStream fsa = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fsa.Close();
                }
                string filepath = dlg.FileName;
                //String filepath = "E:\\test.txt";// đường dẫn của file muốn tạo

                FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt)//fs là 1 FileStream 

                StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
                sWriter.WriteLine("Danh Sách Đối Tượng Bị Trùng Mã");
                //Ghi và đóng file
                sWriter.Flush();

                fs.Close();

                if (dsresult.Tables.Count == 0) return;
                tblDoiTuong = new DataTable();
                tblDoiTuong = dsresult.Tables["DoiTuong"];
                if (tblDoiTuong.Rows.Count > 0)
                {
                    foreach (DataRow rowhd in tblDoiTuong.Rows)
                    {
                        if (rowhd[1].ToString().Trim().Length == 0 && rowhd[2].ToString().Trim().Length == 0)//MaDoiuong va TenDoiTuong = rong
                        {
                            break;
                        }
                        //STT
                        double sTT = 0;
                        double sTTOut;
                        if (double.TryParse(rowhd[0].ToString(), out sTTOut))
                        {
                            sTT = sTTOut;
                        }

                        //LoaiChungTu
                        if (rowhd[1].ToString().Trim() != "")
                        {
                            if (KiemTraTonTaiDoiTuong(rowhd[1].ToString().Trim(), filepath, rowhd[0].ToString()) != false)
                            {

                                _DoiTac = DoiTac.NewDoiTac();

                                DiaChi_DoiTac dchi = DiaChi_DoiTac.NewDiaChi_DoiTac();
                                DiaChi_DoiTacList dchilist = _DoiTac.DiaChi_DoiTacList;

                                TK_NganHang tknh = TK_NganHang.NewTK_NganHang();
                                TK_NganHangList tknhList = _DoiTac.TK_NganHangList;

                                NhomNganHang nnh = NhomNganHang.NewNhomNganHang();
                                NhomNganHangList nnhList = NhomNganHangList.NewNhomNganHangList();

                                _DoiTac.MaQLDoiTac = rowhd[1].ToString();
                                _DoiTac.TenDoiTac = rowhd[2].ToString();
                                _DoiTac.TenVietTat = "";
                                _DoiTac.MaSoThue = rowhd[3].ToString();
                                _DoiTac.TinhTrang = true;
                                _DoiTac.LoaiDoiTac = 2;
                                _DoiTac.DienGiai = "";

                                dchi.TenDiaChi = rowhd[4].ToString();
                                dchi.Active = true;
                                dchilist.Add(dchi);

                                if (rowhd[6].ToString().Trim() != "" && rowhd[6].ToString().Trim() != "NULL")
                                {
                                    nnhList = nnhList.GetNhomNganHangList(rowhd[6].ToString());
                                    tknh.SoTK = rowhd[5].ToString();
                                    tknh.MaNganHang = Convert.ToInt32(nnhList[0].MaNhomNganHang.ToString());
                                    //tknh.TenNganHang = rowhd[6].ToString() + " - " + rowhd[7].ToString();
                                    if (rowhd[7].ToString().Trim() != "" && rowhd[7].ToString().Trim() != "NULL")
                                        tknh.TenNganHang = rowhd[6].ToString() + " - " + rowhd[7].ToString();
                                    else
                                        tknh.TenNganHang = rowhd[6].ToString();
                                }
                                tknhList.Add(tknh);
                                _DoiTacList.Add(_DoiTac);
                            }
                        }



                    }

                }

                DialogResult KH = MessageBox.Show("Bạn có muốn lưu đối tượng mới import", "Thông báo!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (KH == DialogResult.OK)
                {
                    tlslblLuu.PerformClick();
                    KhoiTao();
                }
            }
            else if (_loaiDoiTac == 3)
            {

                _DoiTacList = DoiTacList.NewDoiTacList();
                _DoiTacListSS = DoiTacList.NewDoiTacList();
                _DoiTacListSS = DoiTacList.GetDoiTacListByTen(_loaiDoiTac);
                _DoiTac = DoiTac.NewDoiTac();
                MessageBox.Show("Chọn nơi lưu file chứa các đối tượng lỗi không thêm được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.AddExtension = true;
                dlg.Filter = "Text File|*.txt";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //tạo file template
                    FileStream fsa = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fsa.Close();
                }
                string filepath = dlg.FileName;
                //String filepath = "E:\\test.txt";// đường dẫn của file muốn tạo

                FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt)//fs là 1 FileStream 

                StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
                sWriter.WriteLine("Danh Sách Đối Tượng Bị Trùng Mã");
                //Ghi và đóng file
                sWriter.Flush();

                fs.Close();

                if (dsresult.Tables.Count == 0) return;
                tblDoiTuong = new DataTable();
                tblDoiTuong = dsresult.Tables["DoiTuong"];
                if (tblDoiTuong.Rows.Count > 0)
                {
                    foreach (DataRow rowhd in tblDoiTuong.Rows)
                    {
                        if (rowhd[0].ToString().Trim().Length != 0)
                        {
                            if (rowhd[1].ToString().Trim().Length == 0 && rowhd[2].ToString().Trim().Length == 0)//MaDoiuong va TenDoiTuong = rong
                            {
                                MessageBox.Show(string.Format("Đối tượng chưa có mã hoặc tên, số TT {0}!", rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                            //STT
                            double sTT = 0;
                            double sTTOut;
                            if (double.TryParse(rowhd[0].ToString(), out sTTOut))
                            {
                                sTT = sTTOut;
                            }

                            //LoaiChungTu
                            if (rowhd[1].ToString().Trim() != "")
                            {
                                if (KiemTraTonTaiDoiTuong(rowhd[1].ToString().Trim(), filepath, rowhd[0].ToString()) != false)
                                {
                                    _DoiTac = DoiTac.NewDoiTac();

                                    DiaChi_DoiTac dchi = DiaChi_DoiTac.NewDiaChi_DoiTac();
                                    DiaChi_DoiTacList dchilist = _DoiTac.DiaChi_DoiTacList;

                                    TK_NganHang tknh = TK_NganHang.NewTK_NganHang();
                                    TK_NganHangList tknhList = _DoiTac.TK_NganHangList;

                                    NhomNganHang nnh = NhomNganHang.NewNhomNganHang();
                                    NhomNganHangList nnhList = NhomNganHangList.NewNhomNganHangList();

                                    _DoiTac.MaQLDoiTac = rowhd[1].ToString();
                                    _DoiTac.TenDoiTac = rowhd[2].ToString();
                                    _DoiTac.TenVietTat = "";
                                    _DoiTac.MaSoThue = rowhd[3].ToString();
                                    _DoiTac.TinhTrang = true;
                                    _DoiTac.LoaiDoiTac = 3;
                                    _DoiTac.DienGiai = "";

                                    dchi.TenDiaChi = rowhd[4].ToString();
                                    dchi.Active = true;
                                    dchilist.Add(dchi);

                                    if (rowhd[6].ToString().Trim() != "" && rowhd[6].ToString().Trim() != "NULL")
                                    {
                                        nnhList = nnhList.GetNhomNganHangList(rowhd[6].ToString());
                                        tknh.SoTK = rowhd[5].ToString();
                                        tknh.MaNganHang = Convert.ToInt32(nnhList[0].MaNhomNganHang.ToString());
                                        //tknh.TenNganHang = rowhd[6].ToString() + " - " + rowhd[7].ToString();
                                        if (rowhd[7].ToString().Trim() != "" && rowhd[7].ToString().Trim() != "NULL")
                                            tknh.TenNganHang = rowhd[6].ToString() + " - " + rowhd[7].ToString();
                                        else
                                            tknh.TenNganHang = rowhd[6].ToString();
                                    }
                                    tknhList.Add(tknh);
                                    _DoiTacList.Add(_DoiTac);
                                    _DoiTacListSS.Add(_DoiTac);
                                }
                            }



                        }
                    }

                }

                DialogResult NCCKH = MessageBox.Show("Bạn có muốn lưu đối tượng mới import", "Thông báo!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (NCCKH == DialogResult.OK)
                {
                    tlslblLuu.PerformClick();
                    KhoiTao();
                }
            }

        }

        private void frmDanhSachKhachHang_Load(object sender, EventArgs e)
        {
            this._listDoiTacAll_ByMaCongTy = DoiTacList.GetDoiTacList_ByMaCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy);
            PhanQuyenThemSuaXoa();


        }
        private void PhanQuyenThemSuaXoa()
        {
            PhanQuyenSuDungForm _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(ERP_Library.Security.CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            tlslblThem.Enabled = _phanQuyen.Them;
            tlslblLuu.Enabled = _phanQuyen.Sua;
            tlslblXoa.Enabled = _phanQuyen.Xoa;
        }


    }
}
