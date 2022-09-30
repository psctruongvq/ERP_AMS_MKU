using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
namespace PSC_ERP
{
    public partial class frmQuaTrinhDaoTaoMoi : Form
    {
        #region Properties
        QuaTrinhDaoTao _QuaTrinhDaoTaoMoi;
        QuaTrinhDaoTaoList _QuaTrinhDaoTaoMoiList;
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;        
        Util util = new Util();
        #endregion

        #region Events
        public frmQuaTrinhDaoTaoMoi()
        {
            InitializeComponent();
            txtu_MaNhanVien.Focus();
            cmbu_Loai.Value = 0;
            cmbu_XepLoai.Value = 0;

            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblXoa.Enabled = false;
            tlslblUndo.Enabled = false;
            tlslblIn.Visible = false;
            toolStripButton1.Visible = false;
            //this.Load_Form();
        }

        public frmQuaTrinhDaoTaoMoi(ThongTinNhanVienTongHop obj)
        {
            _ThongTinNhanVienTongHop = obj;
            InitializeComponent();
        }
        private void Save()
        {
            try
            {
                _QuaTrinhDaoTaoMoiList.ApplyEdit();
                _QuaTrinhDaoTaoMoiList.Save();
                _QuaTrinhDaoTaoMoiList = QuaTrinhDaoTaoList.GetQuaTrinhDaoTaoMoiList(_ThongTinNhanVienTongHop.MaNhanVien);
                QuaTrinhDaoTaoMoi_bindingSource.DataSource = _QuaTrinhDaoTaoMoiList;
                MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }

        #region grdu_QuaTrinhDaoTao_InitializeLayout
        private void grdu_QuaTrinhDaoTao_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {            
           
         

            foreach (UltraGridColumn col in grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                col.Hidden = true;
            }
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["TenvanbangChungchi"].Hidden = false;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["SovanbangChungchi"].Hidden = false;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["VanbangChungchi"].Hidden = false;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["XepLoai"].Hidden = false;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["NamTotNghiep"].Hidden = false;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["NgayCap"].Hidden = false;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["NguoiKy"].Hidden = false;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;

            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["TenvanbangChungchi"].Header.Caption = "Tên Văn Bằng/Chứng Chỉ";
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["SovanbangChungchi"].Header.Caption = "Số VB/CC";
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["VanbangChungchi"].Header.Caption = "Loại";
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["XepLoai"].Header.Caption = "Xếp Loại";
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["NamTotNghiep"].Header.Caption = "Năm TN";
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["NgayCap"].Header.Caption = "Ngày Cấp";
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["NguoiKy"].Header.Caption = "Người Ký";
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["SovanbangChungchi"].Width = 60;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["VanbangChungchi"].Width = 70;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["NamTotNghiep"].Width = 55;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 250;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["MaNhanVien"].Width = 200;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["XepLoai"].Width = 70;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["NgayCap"].Width = 70;

            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["TenvanbangChungchi"].Header.VisiblePosition = 1;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["SovanbangChungchi"].Header.VisiblePosition = 2;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["VanbangChungchi"].Header.VisiblePosition = 3;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["NamTotNghiep"].Header.VisiblePosition = 4;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["XepLoai"].Header.VisiblePosition = 5;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["NgayCap"].Header.VisiblePosition = 6;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["NguoiKy"].Header.VisiblePosition = 7;
            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 8;

            grdu_QuaTrinhDaoTao.DisplayLayout.Bands[0].Columns["VanbangChungchi"].EditorComponent = cmbu_Loai;
        }
        #endregion

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac,util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            New();
        }
        private void New()
        {
            if (txtu_MaNhanVien.Text != "")
            {
                txt_TenVBCC.Focus();

                _QuaTrinhDaoTaoMoi = QuaTrinhDaoTao.NewQuaTrinhDaoTaoMoi(_ThongTinNhanVienTongHop.MaNhanVien);
                _QuaTrinhDaoTaoMoiList.Add(_QuaTrinhDaoTaoMoi);
                QuaTrinhDaoTaoMoi_bindingSource.DataSource = _QuaTrinhDaoTaoMoiList;
                grdu_QuaTrinhDaoTao.ActiveRow = grdu_QuaTrinhDaoTao.Rows[_QuaTrinhDaoTaoMoiList.Count - 1];
            }
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_QuaTrinhDaoTao.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            grdu_QuaTrinhDaoTao.DeleteSelectedRows();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            TimKiem();
        }
        private void TimKiem()
        {
            frmTimNhanVien form_TimNV = new frmTimNhanVien(8);
            if (form_TimNV.ShowDialog(this) != DialogResult.OK)
            {
                if (_ThongTinNhanVienTongHop != null)
                {
                    _QuaTrinhDaoTaoMoiList = QuaTrinhDaoTaoList.GetQuaTrinhDaoTaoMoiList(_ThongTinNhanVienTongHop.MaNhanVien);
                    QuaTrinhDaoTaoMoi_bindingSource.DataSource = _QuaTrinhDaoTaoMoiList;
                    txtu_MaNhanVien.Text = _ThongTinNhanVienTongHop.MaQLNhanVien.ToString();
                    txtu_TenNhanVien.Text = _ThongTinNhanVienTongHop.TenNhanVien.ToString();
                }
            }
            tlslblThem.Enabled = true;
            tlslblLuu.Enabled = true;
            tlslblXoa.Enabled = true;
            tlslblUndo.Enabled = true;
        }
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void Undo()
        {
            _QuaTrinhDaoTaoMoiList = QuaTrinhDaoTaoList.GetQuaTrinhDaoTaoMoiList(_ThongTinNhanVienTongHop.MaNhanVien);
            QuaTrinhDaoTaoMoi_bindingSource.DataSource = _QuaTrinhDaoTaoMoiList;
        }
        #endregion

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (txtu_MaNhanVien.Text == "")
            {
                MessageBox.Show(this, "Chọn nhân viên cần in quá trình đào tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ReportDocument Report = new Report.QuatrinhdaotaotheoNV();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Spd_report_tblnsquatrinhdaotaonhanvien";
            command.Parameters.AddWithValue("@maqlnhanvien", txtu_MaNhanVien.Text);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "Spd_report_tblnsquatrinhdaotaonhanvien;1";

            //// store thu 2
            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_REPORT_ReportHeader";
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";
            dataset.Tables.Add(table1);
            dataset.Tables.Add(table);
            Report.SetDataSource(dataset);
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void frmQuaTrinhDaoTaoMoi_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Control && e.KeyCode == Keys.F)
            {
                TimKiem();
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                New();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                Undo();
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

        private void frmQuaTrinhDaoTaoMoi_Load(object sender, EventArgs e)
        {
            TruongDaoTaoList _truongDaoTaoList = TruongDaoTaoList.GetTruongDaoTaoList();
            TruongDaoTao itemAdd = TruongDaoTao.NewTruongDaoTao("Không Có");
            _truongDaoTaoList.Insert(0, itemAdd);
            this.bindingSource1_TruongDaoTao.DataSource = _truongDaoTaoList;
        }
    }
}