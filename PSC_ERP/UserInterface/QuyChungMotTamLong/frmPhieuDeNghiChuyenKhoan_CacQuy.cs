using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
namespace PSC_ERP
{
    public partial class frmPhieuDeNghiChuyenKhoan_CacQuy : Form
    {
        private bool isLoadData = false;
        
        private DeNghiChuyenKhoan_ChungTuNgoaiList _data;
        private int LoaiDeNghi = 1; //
        private DeNghiChuyenKhoan_ChungTuNgoai newdata;
        private DoiTacList _doiTacList;
        private LoaiTienList _loaiTienList; 

        public frmPhieuDeNghiChuyenKhoan_CacQuy()
        {
            InitializeComponent();
            cmbKyTen.SelectedIndex = 3;
        }

        public void ShowDeNghi_CacQuy()
        {
            LoaiDeNghi = 1;
            this.Text = "Đề nghị chuyển khoản các quỹ";
            this.Show();
        }

        public void ShowDeNghi_CongDoan()
        {
            LoaiDeNghi = 2;
            this.Text = "Đề nghị chuyển khoản Công Đoàn";
            this.Show();
        }

        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlThem_Click(object sender, EventArgs e)
        {
            frmPhieuDeNghiChuyenKhoan_CacQuyEdit f = new frmPhieuDeNghiChuyenKhoan_CacQuyEdit();
            f._doiTacList = this._doiTacList;
            f._loaiTienList = this._loaiTienList;
            newdata = _data.AddNew();
            //Xác định loại đề nghi : 1 - Quỹ CMTL, 2 - CD
            newdata.So = newdata.SoPhieuMoi(txtTuNgay.DateTime.Year, LoaiDeNghi);
            if (!f.EditData(newdata, LoaiDeNghi))
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

            //Thành bổ sung
            _doiTacList = DoiTacList.GetDoiTacListByTen(0);
            _doiTacList.Insert(0, DoiTac.NewDoiTac(0, "Chưa chọn"));
            //cmbDoiTac.DataSource = _doiTacList;

            _loaiTienList = LoaiTienList.GetLoaiTienList();
            cmbu_LoaiTien.DataSource = _loaiTienList;

            LoadData();
        }

        private void LoadData()
        {
            _data = DeNghiChuyenKhoan_ChungTuNgoaiList.GetDeNghiChuyenKhoan_ChungTuNgoaiList(txtTuNgay.DateTime, txtDenNgay.DateTime, LoaiDeNghi);
            bdData.DataSource = _data;
        }

        private void NgayChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tlSua_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null)
            {
                frmPhieuDeNghiChuyenKhoan_CacQuyEdit f = new frmPhieuDeNghiChuyenKhoan_CacQuyEdit();
                f._doiTacList = this._doiTacList;
                f._loaiTienList = this._loaiTienList;
                if (f.EditData((ERP_Library.DeNghiChuyenKhoan_ChungTuNgoai)grdData.ActiveRow.ListObject, LoaiDeNghi))
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void tlIn_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                long id = Convert.ToInt64(grdData.ActiveRow.Cells["MaPhieu"].Value);
                int iNguoiKy = Convert.ToInt32(cmbKyTen.Value);
 
                frmXemIn f = new frmXemIn();
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
                if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 30)
                {
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiChuyenKhoanToChuc.rdlc";
                    f.SetNguoiKy(1);
                }
                else
                {
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.QuyChungMotTamLong.rptDeNghiChuyenKhoan_CacQuy.rdlc";
                    f.SetNguoiKyTongHop_DichVu(iNguoiKy);
                }
                rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_DeNghiChuyenKhoanList", ERP_Library.Report.ReportDeNghiChuyenKhoan_CacQuyList.GetDeNghiChuyenKhoanList_CacQuy(id)));
                rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { new Microsoft.Reporting.WinForms.ReportParameter("BangChu", ERP_Library.HamDungChung.DocTien(Convert.ToDecimal(grdData.ActiveRow.Cells["SoTien"].Value))) });
                f.ShowDialog();
            }
        }
    }
}