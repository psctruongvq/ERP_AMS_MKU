using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmBangKeThueTNCN : Form
    {
        private bool IsLoaded = false;
        private BangKeThueTNCNList _data;
        private InChiTietThueTNCN_NhanVienList _dataChiTiet;
        private InChiTietThueTNCN2_TongHopList _dataChiTiet2;
        private NhanVienComboList _nhanVienComboList;
        private int _bophan = 0;
        private long _nhanvien = 0;

        public frmBangKeThueTNCN()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            if (this.IsLoaded)
            {
                this._data = BangKeThueTNCNList.GetBangKeThueTNCNList(Convert.ToInt32(this.txtNam.Value), 0, 0L, this.chkTuQuyetToan.Checked);
                this.bdData.DataSource = this._data;
                this.chkKhoaSo.Enabled = ERP_Library.Security.CurrentUser.IsAdmin;
                this.chkKhoaSo.Checked = KhoaSoQuyetToan.GetKhoaSoQuyetToan((int)this.txtNam.Value).KhoaSo;
            }
        }

        private void toolRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtNam_ValueChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            if ((this._data != null) && (MessageBox.Show("Bạn có muốn tính lại thuế TNCN của nhân viên không", "Tính thuế TNCN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No))
            {
                try
                {

                    this._data.XuLyThueTNCN(Convert.ToInt32(this.txtNam.Value), (int)cmbKyLuong.Value, _bophan, _nhanvien);

                    this.LoadData();
                    MessageBox.Show("Đã xử lý thành công!", "Thuế TNCN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception exception)
                {
                    frmThongBaoLoiDuLieu.ThongBaoLoi(exception, null);
                }
            }
        }

        private void chkTuQuyetToan_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void frmBangKeThueTNCN_Load(object sender, EventArgs e)
        {

            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            _nhanVienComboList = NhanVienComboList.GetNhanVienByQuyetToan((int)this.txtNam.Value, 0);
            ultraCombo_NhanVien.DataSource = _nhanVienComboList;
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            this.txtNam.Value = DateTime.Today.Year;           
            //this.cmbBoPhan.Value = 0;
            this.IsLoaded = true;
            this.LoadData();
            this.cmbKyTen.Value = 0;
            foreach (UltraGridColumn column in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                if (column.DataType == typeof(decimal))
                {
                    column.Format = "#,###";
                    column.CellAppearance.TextHAlign = HAlign.Right;
                    this.grdData.DisplayLayout.Bands[0].Summaries.Add("Sum" + column.Key, SummaryType.Sum, column, SummaryPosition.UseSummaryPositionColumn);
                    this.grdData.DisplayLayout.Bands[0].Summaries["Sum" + column.Key].Appearance.TextHAlign = HAlign.Right;
                    this.grdData.DisplayLayout.Bands[0].Summaries["Sum" + column.Key].DisplayFormat = "{0:#,###}";
                }
            }
        }

        KyTinhLuong _ky;
        private void OpenReport(int Loai)
        {


            int num;
            long num2;
           
            try
            {
                num = _bophan;//(int)this.cmbBoPhan.Value;
            }
            catch
            {
                num = 0;
            }
            try
            {
                num2 = _nhanvien;//(long)this.ComboboxNhanVien.Value;
            }
            catch
            {
                num2 = 0L;
            }
            frmXemIn @in = new frmXemIn();
            if (cmbKyLuong.Value != null)
            {
                _ky = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbKyLuong.Value));
            }
            else
            {
                MessageBox.Show(this, "Vui Lòng Chọn Đến Tháng Quyết Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            switch (Loai)
            {
                case 1:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCNNam.rdlc";
                    break;
                case 20:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCNNamCuaHTV.rdlc";
                    break;

                case 2:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCNNamNhanVien.rdlc";
                    break;

                case 3:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptDanhSachThuTienThueTNCN.rdlc";
                    break;

                case 4:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptDanhSachTraTienThueTNCN.rdlc";
                    break;

                case 5:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCNNam.rdlc";
                    BangKeThueTNCNList _bangKeThueTNCNList = BangKeThueTNCNList.GetBangKeThueTNCNListByNghiViec(Convert.ToInt32(this.txtNam.Value), num, num2, this.checkBox_InQuyetToan.Checked);
                    @in.SetDatabase("ERP_Library_BangKeThueTNCNList", _bangKeThueTNCNList);
                    break;

                case 6:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeTongHopThueTNCNNam.rdlc";
                    @in.SetDatabase("ERP_Library_Report_TongHopQuyetToanThueList", TongHopQuyetToanThueList.GetTongHopQuyetToanThueList(Convert.ToInt32(this.txtNam.Value), this.checkBox_InQuyetToan.Checked));
                    break;


                case 7:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeTongHopThueTNCNNamNhanVien.rdlc";
                    @in.SetDatabase("ERP_Library_Report_TongHopQuyetToanThueList", TongHopQuyetToanThueList.GetTongHopQuyetToanThueList(Convert.ToInt32(this.txtNam.Value), this.checkBox_InQuyetToan.Checked));
                    break;

                case 21:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeTongHopThueTNCNNamNhanVienHTV.rdlc";
                    @in.SetDatabase("ERP_Library_TongHopQuyetToanThueList", TongHopQuyetToanThueList.GetTongHopQuyetToanThueList(Convert.ToInt32(this.txtNam.Value), this.checkBox_InQuyetToan.Checked));
                    break;

                case 8:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCN_09A.rdlc";
                    BangKeThueTNCNList bangKeThueTNCNListGetBangKeThueTNCNList = BangKeThueTNCNList.GetBangKeThueTNCNList(Convert.ToInt32(this.txtNam.Value), num, num2, this.checkBox_InQuyetToan.Checked);
                    @in.SetDatabase("ERP_Library_BangKeThueTNCNList", bangKeThueTNCNListGetBangKeThueTNCNList);
                    break;

                case 9:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCN_09ANhanVien.rdlc";
                    //@in.SetDatabase("ERP_Library_BangKeThueTNCNList", BangKeThueTNCNList.GetBangKeThueTNCNList(Convert.ToInt32(this.txtNam.Value), num, num2, this.chkTuQuyetToan.Checked));
                    break;

                case 10:
                   
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptInChiTietQuyetToan.rdlc";
                    this._dataChiTiet = InChiTietThueTNCN_NhanVienList.GetInChiTietThueTNCN_NhanVienList(num2, num, Convert.ToInt32(this.txtNam.Value), true, checkBox_InQuyetToan.Checked, _ky.Thang);
                    @in.Report.SubreportProcessing += new SubreportProcessingEventHandler(this.ReportChiTiet_SubreportProcessing);
                    @in.SetDatabase("ERP_Library_Report_InChiTietThueTNCN_NhanVienList", this._dataChiTiet);
                    @in.SetParameter(new string[] { "ChuKy", this.GetChuKy() });
                  
                    break;
                    

                case 11:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptInChiTietQuyetToan.rdlc";
                    //this._dataChiTiet = InChiTietThueTNCN_NhanVienList.GetInChiTietThueTNCN_NhanVienList(num2, num, Convert.ToInt32(this.txtNam.Value), false, checkBox_InQuyetToan.Checked);
                    @in.Report.SubreportProcessing += new SubreportProcessingEventHandler(this.ReportChiTiet_SubreportProcessing);
                    @in.SetDatabase("ERP_Library_Report_InChiTietThueTNCN_NhanVienList", this._dataChiTiet);
                    @in.SetParameter(new string[] { "ChuKy", this.GetChuKy() });
                    break;

                case 12:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptInChiTietQuyetToan2.rdlc";
                    this._dataChiTiet2 = InChiTietThueTNCN2_TongHopList.GetInChiTietThueTNCN2_TongHopList(Convert.ToInt32(this.txtNam.Value), num, num2, true);
                    @in.SetDatabase("ERP_Library_Report_InChiTietThueTNCN2_TongHopList", this._dataChiTiet2);
                    @in.SetParameter(new string[] { "ChuKy", this.GetChuKy() });
                    break;

                case 13:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptInChiTietQuyetToan2.rdlc";
                    this._dataChiTiet2 = InChiTietThueTNCN2_TongHopList.GetInChiTietThueTNCN2_TongHopList(Convert.ToInt32(this.txtNam.Value), num, num2, false);
                    @in.SetDatabase("ERP_Library_Report_InChiTietThueTNCN2_TongHopList", this._dataChiTiet2);
                    @in.SetParameter(new string[] { "ChuKy", this.GetChuKy() });
                    break;

                case 14:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptDanhSachThuThueTNCNNVTuQuyetToan.rdlc";
                    @in.SetDatabase("ERP_Library_Report_DanhSachThuThueNVTuQuyetToanList", DanhSachThuThueNVTuQuyetToanList.GetDanhSachThuThueNVTuQuyetToanList((int)this.txtNam.Value));
                    break;

                case 15:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCNKy3QuyetToanNam.rdlc";
                    @in.SetDatabase("ERP_Library_Report_ChiTietThueTNCNKy3QuyetToanNamList", ChiTietThueTNCNKy3QuyetToanNamList.GetChiTietThueTNCNKy3QuyetToanNamList(Convert.ToInt32(this.txtNam.Value), this.checkBox_InQuyetToan.Checked));
                    break;

                case 0x10:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptTongHopThueTNCNKy3QuyetToanNam.rdlc";
                    @in.SetDatabase("ERP_Library_Report_ChiTietThueTNCNKy3QuyetToanNamList", ChiTietThueTNCNKy3QuyetToanNamList.GetTongHopThueTNCNKy3QuyetToanNamList(Convert.ToInt32(this.txtNam.Value), this.checkBox_InQuyetToan.Checked));
                    break;
            }
            if (@in.Report.DataSources.Count == 0)
            {

                BangKeThueTNCNList _bangKeThueTNCNList = BangKeThueTNCNList.GetBangKeThueTNCNList(Convert.ToInt32(this.txtNam.Value), num, num2, this.checkBox_InQuyetToan.Checked);
                @in.SetDatabase("ERP_Library_BangKeThueTNCNList", _bangKeThueTNCNList);

                //_BangKeThueTNCN_NVList = ERP_Library.Report.BangKeThueTNCN_NVList.GetBangKeThueTNCN_NVList(maKyTinhLuong, (int)cmbBoPhan.Value, namTinh);
                //bindingSource_ToKhaiTNCNLias.DataSource = _BangKeThueTNCN_NVList;
            }
            @in.SetParameter(new string[] { "TenBoPhan", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan });
            @in.SetParameter(new string[] { "Nam", "Năm : " + this.txtNam.Value.ToString() });
            if ((((Loai != 10) && (Loai != 11)) && (Loai != 12)) && (Loai != 13))
            {
                @in.SetNguoiKy(Convert.ToInt32(this.cmbKyTen.Value));
            }
            @in.ShowDialog();
        }

        private void ReportChiTiet_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if (e.Parameters["MaNhanVien"].Values[0] != null)
            {
                long num = Convert.ToInt64(e.Parameters["MaNhanVien"].Values[0]);
                InChiTietThueTNCN_NhanVienChild child = null;
                foreach (InChiTietThueTNCN_NhanVienChild child2 in this._dataChiTiet)
                {
                    if (child2.MaNhanVien == num)
                    {
                        child = child2;
                        break;
                    }
                }
                if (e.ReportPath == "rptInChiTietQuyetToanTongHop")
                {
                    e.DataSources.Add(new ReportDataSource("ERP_Library_Report_InChiTietThueTNCN_TongHopList", child.TongHop));
                }
                if (e.ReportPath == "rptInChiTietQuyetToanChiTiet")
                {
                    e.DataSources.Add(new ReportDataSource("ERP_Library_Report_InChiTietThueTNCN_ChiTietList", child.ChiTiet));
                }
            }
        }



        private string GetChuKy()
        {
            NguoiKyTen nguoiKyTen = NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
            string str = DateTime.Today.ToString("'Tp.HCM, Ngày 'dd' tháng 'MM' năm 'yyyy");
            return string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", str, nguoiKyTen.BptTieude, nguoiKyTen.BptTen);
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            this.ultraCombo_NhanVien.Value = null;
            if ((this.cmbBoPhan.Value != null) && (((int)this.cmbBoPhan.Value) != 0))
            {
                _nhanVienComboList = ERP_Library.NhanVienComboList.GetNhanVienByMaBoPhan((int)this.cmbBoPhan.Value);
                ultraCombo_NhanVien.DataSource =_nhanVienComboList;
                nhanVienComboListBindingSource.DataSource = _nhanVienComboList;
                _bophan = (int)this.cmbBoPhan.Value;
          
            }
            else
            {
                 ultraCombo_NhanVien.DataSource= NhanVienComboList.GetNhanVienAll();                
            }
            FilterConditionsCollection filterConditions = this.grdData.DisplayLayout.Bands[0].ColumnFilters[this.grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"]].FilterConditions;
            filterConditions.Clear();
            if ((this.cmbBoPhan.Value != null) && (((int)this.cmbBoPhan.Value) != 0))
            {
                filterConditions.Add(FilterComparisionOperator.Equals, this.cmbBoPhan.Value);
            }
        }

        public void LoadDataByBoPhan(int MaBoPhan)
        {
            this.nhanVienComboListBindingSource.DataSource = NhanVienComboList.GetNhanVienByMaBoPhan(MaBoPhan);
        }

        private void ComboboxNhanVien_ValueChanged(object sender, EventArgs e)
        {
            FilterConditionsCollection filterConditions = this.grdData.DisplayLayout.Bands[0].ColumnFilters[this.grdData.DisplayLayout.Bands[0].Columns["MaNhanVien"]].FilterConditions;
            filterConditions.Clear();
            if ((this.ultraCombo_NhanVien.Value != null) && (((long)this.ultraCombo_NhanVien.Value) != 0))
            {
                filterConditions.Add(FilterComparisionOperator.Equals, this.ultraCombo_NhanVien.Value);
                _nhanvien = (long)this.ultraCombo_NhanVien.Value;
            }
        }

        private void chkKhoaSo_Click(object sender, EventArgs e)
        {
            if (this.chkKhoaSo.Checked)
            {
                this.toolSave_Click(this, null);
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.grdData.UpdateData();                
                this._data.Save();
                KhoaSoQuyetToan khoaSoQuyetToan = KhoaSoQuyetToan.GetKhoaSoQuyetToan((int)this.txtNam.Value);
                khoaSoQuyetToan.KhoaSo = this.chkKhoaSo.Checked;
                khoaSoQuyetToan.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công!");
            }
            catch (Exception exception)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(exception, this._data);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bảngKêChiTiếtPhảiThuĐượcHoànThuếTNCNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(15);
        }

        private void bảngKêThuNhậpChịuThuếVàThuếTNCNmẫu05AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.OpenReport(5);
        }

        private void báoCáoQuyếtToánCơQuanThuếToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(1);
        }

        private void báoCáoQuyếtToánThuếTNCNVớiNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(2);
        }

        private void báoCáoThuNhậpThuếĐãKhấuTrừ09AKỳ312ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(8);
        }

        private void báoCáoThuNhậpThuếĐãKhấyTrừ09AKỳ212ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(9);
        }

        private void danhSáchThuBổSungThuếTNCNKỳ312ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(14);
        }

        private void danhSáchThuThuếTNCNBổSungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(3);
        }

        private void danhSáchTrảTiềnThuếTNCNChoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(4);
        }

        private void inChiTiếtQuyếtToánmẫu2Kỳ212ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(13);
        }

        private void inChiTiếtQuyếtToánmẫu2Kỳ312ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(12);
        }

        private void inChiTiếtQuyếtToánThuếTNCNkỳ212ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(11);
        }

        private void inChiTiếtQuyếtToánThuếTNCNkỳ312ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(10);
        }

        private void tổngHợpQuyếtToánThuếTNCNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(6);
        }

        private void tổngHợpQuyếtToánThuếTNCNVớiNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(7);
        }

        private void xuấtDữLiệuSangPhầnPhềmKêKhaiThuểToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel|*.xls|All|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                Export export = new Export("Win");
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = Database.ERP_Connection;
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_BangKeThueTNCNExport";
                command.Parameters.AddWithValue("@Nam", Convert.ToInt32(this.txtNam.Value));
                command.Parameters.AddWithValue("@UserID",ERP_Library.Security.CurrentUser.Info.UserID);
                command.Parameters.AddWithValue("@MaBoPhan", Convert.ToInt32(this.cmbBoPhan.Value));
                command.Parameters.AddWithValue("@MaNhanVien", Convert.ToInt64(this.ultraCombo_NhanVien.Value));
                command.Parameters.AddWithValue("@TuQuyetToan", this.chkTuQuyetToan.Checked);
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);
                connection.Close();
                export.ExportDetails(dataSet.Tables[0], Export.ExportFormat.Excel, fileName);
                MessageBox.Show("Đã xuất dữ liệu thành công", "Export", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if ((this.bdData.Current != null) && (this.grdData.ActiveCell != null))
            {
                int loai = 0;
                switch (this.grdData.ActiveCell.Column.Key)
                {
                    case "ThuNhapChiuThue":
                        loai = 1;
                        break;

                    case "SoNguoiPhuThuoc":
                        loai = 2;
                        break;

                    case "SoThangGiamTru":
                        loai = 3;
                        break;

                    case "TuThienNhanDao":
                        loai = 4;
                        break;

                    case "BaoHiemBatBuoc":
                        loai = 5;
                        break;

                    case "TNCTGiamThue":
                        loai = 6;
                        break;

                    case "ThueDaKhauTru":
                        loai = 7;
                        break;

                    case "ThueNLDDaNop":
                        loai = 8;
                        break;
                    case "BHXH":
                        loai = 9;
                        break;
                    case "BHYT":
                        loai = 10;
                        break;
                    case "BHTN":
                        loai = 11;
                        break;
                    case "SoThang":
                        loai = 12;
                        break;
                    case "TongThuNhap":
                        loai = 13;
                        break;
                }
                if (loai != 0)
                {
                    BangKeThueTNCNChild current = (BangKeThueTNCNChild)this.bdData.Current;
                    frmDieuChinhQuyetToanTNCN nam = new frmDieuChinhQuyetToanTNCN();
                    if (nam.ShowDieuChinh(current, loai))
                    {
                        this._data.Save();
                        this.grdData.DataBind();
                    }
                }
            }
        }

        private void grdData_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsFilterRow!=true)
            {
                //MessageBox.Show(grdData.ActiveRow.Cells["MaBoPhan"].Value.ToString() + grdData.ActiveRow.Cells["MaNhanVien"].Value.ToString());
                //this.OpenReport(6, (int)grdData.ActiveRow.Cells["MaBoPhan"].Value, (long)grdData.ActiveRow.Cells["MaNhanVien"].Value);
                _bophan = (int)grdData.ActiveRow.Cells["MaBoPhan"].Value;
                _nhanvien = (long)grdData.ActiveRow.Cells["MaNhanVien"].Value;
            }
        }

        private void toolDieuChinh_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Bạn Chọn Dòng Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            grdData.DeleteSelectedRows();
        }

        private void ultraCombo_NhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
             FilterCombo f = new FilterCombo(ultraCombo_NhanVien, "TenNhanVien");
             foreach (UltraGridColumn col in this.ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns)
             {
                 col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                 col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                 col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                 col.Hidden = true;
             }
             ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
             ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
             ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 1;

             ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
             ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhận Viên";
             ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 200;
             ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 2;
          
        }

  
        private void ultraCombo_NhanVien_Leave(object sender, EventArgs e)
        {
            if (ultraCombo_NhanVien.Value != null)
                _nhanvien = (long)this.ultraCombo_NhanVien.Value;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.OpenReport(5);
        }

        private void bao1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(20);
        }

        private void tổngHợpQuyếtToánThuếTNCNVớiNhânViênHTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(21);
        }


        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}
