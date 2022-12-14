using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmGiayNghiPhepNuocNgoaiEdit : Form
    {
        private bool OK = false;
        private bool IsNew;
        private int _IDEdit;
        private ERP_Library.GiayNghiPhepNuocNgoai _Data;
        int UserID = ERP_Library.Security.CurrentUser.Info.UserID;
        public frmGiayNghiPhepNuocNgoaiEdit()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGiayNghiPhepNuocNgoaiEdit_Load(object sender, EventArgs e)
        {
            cmbNhanVien.LoadData();
            cmbNVBanGiao.LoadData();
            cmbNguoiDuyet.LoadData();
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            boPhanListBindingSource.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            hinhThucNghiListBindingSource.DataSource = ERP_Library.HinhThucNghiList.GetHinhThucNghiList();
            loaiKinhPhiListBindingSource.DataSource = ERP_Library.LoaiKinhPhiList.GetLoaiKinhPhiList();
            tlslblXoa.Enabled = !IsNew;
            tlslblUndo.Enabled = !IsNew;
            if (IsNew)
                _Data = ERP_Library.GiayNghiPhepNuocNgoai.NewGiayNghiPhepNuocNgoai();
            else
                _Data = ERP_Library.GiayNghiPhepNuocNgoai.GetGiayNghiPhepNuocNgoai(_IDEdit);
            bdGiayNghiPhep.DataSource = _Data;
            ERP_Library.QuocGiaList qg = ERP_Library.QuocGiaList.GetQuocGiaList();
            foreach (ERP_Library.QuocGia q in qg)
            {
                grdNuocDen.DisplayLayout.ValueLists["NuocDen"].ValueListItems.Add(q.MaQuocGia, q.TenQuocGia);
            }

            txtNamTruoc.Value = _Data.SoNgayPhepConLai(txtNgay.DateTime.Year - 1);
            //txtNamNay.Value = _Data.SoNgayPhepTrongNam(txtNgay.DateTime.Year);

            

        }

        public bool NewGiayPhep()
        {
            IsNew = true;
            this.ShowDialog();
            return OK;
        }
        public bool EditGiayPhep(int MaNghiPhep)
        {
            IsNew = false;
            _IDEdit = MaNghiPhep;
            this.ShowDialog();
            return OK;            
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                MessageBox.Show("Lưu dữ liệu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool SaveData()
        {
            bool _ok = true;
            bdGiayNghiPhep.EndEdit();
            try
            {
                _Data.Save();
                OK = true;
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _Data);
                _ok = false;
            }
            return _ok;
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            bdGiayNghiPhep.CancelEdit();
        }

        private void cmbBoPhan_Validated(object sender, EventArgs e)
        {
            cmbNhanVien.FilterByMaBoPhan(cmbBoPhan.Value);
            cmbNVBanGiao.FilterByMaBoPhan(cmbBoPhan.Value);
            //cmbNguoiDuyet.FilterByMaBoPhan(cmbBoPhan.Value);
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa giấy nghỉ phép này không?", "Xóa", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Data.Delete();
                SaveData();
                this.Close();
            }
        }

        private void grdNuocDen_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa chi tiết nước đến này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.Close();
                frmXemIn f = new frmXemIn();
                f.rptView.LocalReport.ReportEmbeddedResource = "PSC_ERP.Report.rptGiayNghiPhep.rdlc";
                f.rptView.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_GiayNghiPhepList", ERP_Library.Report.GiayNghiPhepList.GetGiayNghiPhepNgoaiNuoc(_Data.MaNghiPhep)));
                f.ShowDialog();
            }
        }

        private void tlslblMau_Click(object sender, EventArgs e)
        {
            if (cmbNhanVien.Value != null && txtNgay.Value != null)
            {
                InMauGiayNghiPhep();
            }
        }

        public void InMauGiayNghiPhep()
        {
            ReportDocument Report = new ReportDocument();
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "spd_ReportHeaderAndFooter";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command.Parameters.AddWithValue("@MaNguoiLap", UserID);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "Spd_ReportHeaderAndFooter;1";

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "Spd_GiayNghiPhep_NgoaiNuoc";
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command1.Parameters.AddWithValue("@MaNhanVien", Convert.ToInt64(cmbNhanVien.Value));
            command1.Parameters.AddWithValue("@NgayLap", Convert.ToDateTime(txtNgay.Value));

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "Spd_GiayNghiPhep_NgoaiNuoc;1";


            dataset.Tables.Add(table);
            dataset.Tables.Add(table1);
            Report.SetDataSource(dataset);
            Report.SetParameterValue("@NgayLap", Convert.ToDateTime(txtNgay.Value).Date);
            Report.SetParameterValue("p_Ngay", DateTime.Now.Date);
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
    }
}