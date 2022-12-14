using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library.ThanhToan;
using ERP_Library;
using System.Data.SqlClient;

namespace PSC_ERP.ThanhToan
{
    public partial class frmPhieuDeNghiChuyenKhoanHDDV : Form
    {
        private bool isLoadData = false;

        private ERP_Library.ThanhToan.DeNghiChuyenKhoanList _data;
        private string MaPhanHe = "ThanhToan";//thay đổi mã này để load các dữ liệu tùy theo phân hệ, chú ý : form edit, form chọn loại chứng từ gốc sẽ tự thay đổi theo
        private ERP_Library.ThanhToan.DeNghiChuyenKhoan newdata;
        #region Devexpress
        DataSet dataSet = new DataSet();
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        #endregion//Devexpress


        public frmPhieuDeNghiChuyenKhoanHDDV()
        {
            InitializeComponent();
            cmbKyTen.SelectedIndex = 3;
        }

        #region BoSung
        DeNghiChuyenKhoan _deNghiCanDeCopy;

        private void CopyDeNghiChuyenKhoan()
        {
            _deNghiCanDeCopy = DeNghiChuyenKhoan.NewDeNghiChuyenKhoan();

            if (grdData.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần copy.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            //
            long maPhieu = ((DeNghiChuyenKhoan)bdData.Current).MaPhieu;
            _deNghiCanDeCopy = DeNghiChuyenKhoan.GetDeNghiChuyenKhoan(maPhieu);

            if (_deNghiCanDeCopy.Ngay.Year <= Convert.ToDateTime("31-12-2013").Year)
            {
                MessageBox.Show("Đề nghị cũ năm [" + _deNghiCanDeCopy.Ngay.Year + "] không thể copy.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _deNghiCanDeCopy = null;
            }
        }

        private void PasteDeNghiChuyenKhoan()
        {
            if (_deNghiCanDeCopy != null)
            {
                if (_deNghiCanDeCopy.MaPhieu != 0)
                {

                    //Khởi tạo DeNghi mới
                    DeNghiChuyenKhoan deNghiMoi = DeNghiChuyenKhoan.NewDeNghiChuyenKhoan();
                    deNghiMoi = DeNghiChuyenKhoan.NewDeNghiChuyenKhoan(_deNghiCanDeCopy);
                    deNghiMoi.Loai = false;
                    //--Lấy số De Nghi mới
                    deNghiMoi.So = deNghiMoi.SoPhieuMoi(txtTuNgay.DateTime.Year);
                    //--End  

                    //Lưu đề nghị
                    deNghiMoi.Save();

                    LoadData();
                    MessageBox.Show("Copy Thành Công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

        #region Functions

        #region Devexpress
        private void InDeNghiThanhToanHDDV()
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_Report_DeNghiThanhToanHDDV");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.ShowDialog();
            }
            //END
        }
        public void Method_Report_DeNghiThanhToanHDDV()
        {
            long id = Convert.ToInt64(grdData.ActiveRow.Cells["MaPhieu"].Value);

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_DeNghiChuyenKhoan_HDDV_Modify";
                    cm.Parameters.AddWithValue("@MaPhieu", id);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("SoTienBangChu", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["SoTienBangChu"] = ERP_Library.HamDungChung.DocTien(Convert.ToDecimal(grdData.ActiveRow.Cells["SoTien"].Value));
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us  
        }

        #endregion//Devexpress

        #endregion//Functions

        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlThem_Click(object sender, EventArgs e)
        {
            frmPhieuDeNghiChuyenKhoanHDDV_Edit f = new frmPhieuDeNghiChuyenKhoanHDDV_Edit(true);
            f.MaPhanHe = MaPhanHe;
            newdata = _data.AddNew();
            newdata.So = newdata.SoPhieuMoi(txtTuNgay.DateTime.Year);
            if (!f.EditData(newdata))
                _data.Remove(newdata);
            else
            {
                _data.Save();
                LoadData();
            }
        }

        private void frmPhieuDeNghiChuyenKhoan_Load(object sender, EventArgs e)
        {
            txtTuNgay.DateTime = DateTime.Today;
            txtDenNgay.Value = DateTime.Today;
            foreach (ERP_Library.BoPhan item in ERP_Library.BoPhanList.GetBoPhanList())
            {
                grdData.DisplayLayout.ValueLists["BoPhan"].ValueListItems.Add(item.MaBoPhan, item.TenBoPhan);
            }
            foreach (ERP_Library.NhanVienComboListChild item in ERP_Library.NhanVienComboList.GetNhanVienAll())
            {
                grdData.DisplayLayout.ValueLists["NhanVien"].ValueListItems.Add(item.MaNhanVien, item.TenNhanVien);
            }
            foreach (ERP_Library.DatabaseNumberChild item in ERP_Library.DatabaseNumberList.GetDatabaseNumberList())
            {
                grdData.DisplayLayout.ValueLists["NoiNhan"].ValueListItems.Add(item.DatabaseNumber, item.Ten);
            }
            isLoadData = true;
            LoadData();
        }

        private void LoadData()
        {
            if (isLoadData)
            {
                _data = ERP_Library.ThanhToan.DeNghiChuyenKhoanList.GetDeNghiChuyenKhoanList(txtTuNgay.DateTime, txtDenNgay.DateTime, MaPhanHe, false);
                bdData.DataSource = _data;
            }
        }

        private void NgayChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tlSua_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null)
            {
                frmPhieuDeNghiChuyenKhoanHDDV_Edit f = new frmPhieuDeNghiChuyenKhoanHDDV_Edit();
                f.MaPhanHe = MaPhanHe;
                if (f.EditData((ERP_Library.ThanhToan.DeNghiChuyenKhoan)grdData.ActiveRow.ListObject))
                {
                    _data.Save();
                    LoadData();
                }
            }
        }

        private void grdData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (e.Row.IsDataRow)
                tlSua.PerformClick();
        }

        private void tlXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
            _data.Save();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            if ((bool)e.Rows[0].Cells["DaDuyet"].Value)
            {
                e.Cancel = true;
                MessageBox.Show("Phiếu đề nghị này đã được duyệt chuyển khoản ngân hàng nên không thể xóa", "Đã duyệt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            e.Cancel = MessageBox.Show("Bạn có muốn xóa phiếu đề nghị này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void tlUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void inPhiếuĐềNghiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                long id = Convert.ToInt64(grdData.ActiveRow.Cells["MaPhieu"].Value);
                frmXemIn f = new frmXemIn();
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
                if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 30)
                {
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiChuyenKhoanToChuc.rdlc";
                    f.SetNguoiKy(1);
                }
                else
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiChuyenKhoan.rdlc";
                //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptDeNghiChuyenKhoan.rdlc";
                rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_DeNghiChuyenKhoanList", ERP_Library.Report.DeNghiChuyenKhoanList.GetDeNghiChuyenKhoanList(id)));
                rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { new Microsoft.Reporting.WinForms.ReportParameter("BangChu", ERP_Library.HamDungChung.DocTien(Convert.ToDecimal(grdData.ActiveRow.Cells["SoTien"].Value))) });
                // f.SetNguoiKyTongHop((int)cmbKyTen.Value);  
                f.ShowDialog();
            }
        }

        private void inDanhSáchChuyểnKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                long id = Convert.ToInt64(grdData.ActiveRow.Cells["MaPhieu"].Value);
                frmXemIn f = new frmXemIn();
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
                rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoan.rdlc";
                //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptChiTietChuyenKhoan.rdlc";
                f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanList", ERP_Library.Report.ChiTietChuyenKhoanList.GetChiTietChuyenKhoanList(id));
                f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "VeViec", grdData.ActiveRow.Cells["LyDo"].Value.ToString());
                f.ShowDialog();
            }

        }

        private void danhSáchGiấyXácNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maPhieuStr = "";
            foreach (UltraGridRow row in grdData.Selected.Rows)
            {
                maPhieuStr += "," + row.Cells["MaPhieu"].Value;
            }
            if (maPhieuStr.Length == 0)
                maPhieuStr = "0";
            else
                maPhieuStr = maPhieuStr.Substring(1);

            frmGiayXacNhan_DeNghiChuyenKhoan f = new frmGiayXacNhan_DeNghiChuyenKhoan(maPhieuStr);
            f.Show();
        }

        private void bảngKêThuNhậpNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERP_Library.Report.ChiTietThuNhapThueTamThuList source = ERP_Library.Report.ChiTietThuNhapThueTamThuList.GetChiTietThuNhapThueTamThuList(txtTuNgay.DateTime, txtDenNgay.DateTime);
            frmXemIn f = new frmXemIn();
            f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietThuNhapThueTamThu.rdlc";
            f.SetDatabase("ERP_Library_Report_ChiTietThuNhapThueTamThuList", source);
            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            f.SetNguoiKy(3);
            f.ShowDialog();
        }

        private void inDanhSáchChuyểnKhoảnĐVCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                long id = Convert.ToInt64(grdData.ActiveRow.Cells["MaPhieu"].Value);
                frmXemIn f = new frmXemIn();
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
                rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoanDVCap2.rdlc";
                //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptChiTietChuyenKhoan.rdlc";
                f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanList", ERP_Library.Report.ChiTietChuyenKhoanList.GetChiTietChuyenKhoanList(id));
                f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "VeViec", grdData.ActiveRow.Cells["LyDo"].Value.ToString());
                f.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void inPhiếuĐềNghịĐVCấp2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                long id = Convert.ToInt64(grdData.ActiveRow.Cells["MaPhieu"].Value);
                frmXemIn f = new frmXemIn();
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
                if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 30)
                {
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiChuyenKhoanToChuc.rdlc";
                    f.SetNguoiKy(1);
                }
                else
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiChuyenKhoanDVCap2.rdlc";
                //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptDeNghiChuyenKhoan.rdlc";
                rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_DeNghiChuyenKhoanList", ERP_Library.Report.DeNghiChuyenKhoanList.GetDeNghiChuyenKhoanList(id)));
                rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { new Microsoft.Reporting.WinForms.ReportParameter("BangChu", ERP_Library.HamDungChung.DocTien(Convert.ToDecimal(grdData.ActiveRow.Cells["SoTien"].Value))) });
                // f.SetNguoiKyTongHop((int)cmbKyTen.Value);  
                f.ShowDialog();
            }
        }

        private void tlIn_Click(object sender, EventArgs e)
        {
            #region Modify
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                InDeNghiThanhToanHDDV();
            }
            #endregion//Modify

            #region Old
            //if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            //{
            //    long id = Convert.ToInt64(grdData.ActiveRow.Cells["MaPhieu"].Value);
            //    int iNguoiKy = Convert.ToInt32(cmbKyTen.Value);

            //    frmXemIn f = new frmXemIn();
            //    Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            //    if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 30)
            //    {
            //        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiChuyenKhoanToChuc.rdlc";
            //        f.SetNguoiKy(1);
            //    }
            //    else if (iNguoiKy != 4)
            //    {
            //        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiChuyenKhoan_HDDV_New.rdlc";
            //        f.SetNguoiKyTongHop_DichVu(iNguoiKy);
            //    }
            //    else
            //    {
            //        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiChuyenKhoan_HDDV_New_BonChuKy.rdlc";
            //        f.SetNguoiKyTongHop_DichVu(iNguoiKy);
            //    }

            //    rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_DeNghiChuyenKhoanList", ERP_Library.Report.DeNghiChuyenKhoanList.GetDeNghiChuyenKhoanList_ByHDDV(id)));
            //    rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { new Microsoft.Reporting.WinForms.ReportParameter("BangChu", ERP_Library.HamDungChung.DocTien(Convert.ToDecimal(grdData.ActiveRow.Cells["SoTien"].Value))) });
            //    f.ShowDialog();
            //} 
            #endregion//Old
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _data.ApplyEdit();
                bdData.EndEdit();
                _data.Save();

                MessageBox.Show(this, "Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tlCopy_Click(object sender, EventArgs e)
        {
            CopyDeNghiChuyenKhoan();
        }

        private void tlPaste_Click(object sender, EventArgs e)
        {
            PasteDeNghiChuyenKhoan();
        }
    }
}