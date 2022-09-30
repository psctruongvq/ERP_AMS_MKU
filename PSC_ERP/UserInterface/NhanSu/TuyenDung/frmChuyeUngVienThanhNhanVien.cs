using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
namespace PSC_ERP
{


    public partial class frmChuyeUngVienThanhNhanVien : Form
    {
        BoPhanList _boPhanList;
        ThongTinUngVienList _ttUngVienList;
        ThongTinTuyenDungList _thongTinTuyenDungList;
        ThongTinUngVien _ttUngVien;
        //ThongTinUngVienList _ttUngVienList;
        TinhThanhList _tinhThanhList;
        TrinhDoHocVanClassList _trinhDoHocVanList;
        //TrinhDoChuyenMonList _trinhDoChuyenMonList;
        ChuyenMonNghiepVuClassList _ChuyenMonNghiepVu;
        private static long maTuyenDung = 0;
        public frmChuyeUngVienThanhNhanVien()
        {
            InitializeComponent();
        }

        private void TimKiem()
        {
            _boPhanList = BoPhanList.GetBoPhanList();
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            _tinhThanhList = TinhThanhList.GetTinhThanhList();
            this.bindingSource1_tinhThanh.DataSource = _tinhThanhList;
            _trinhDoHocVanList = TrinhDoHocVanClassList.GetTrinhDoHocVanClassList();
            this.bindingSource1_trinhDoHocVan.DataSource = _trinhDoHocVanList;
            _ChuyenMonNghiepVu = ChuyenMonNghiepVuClassList.GetChuyenMonNghiepVuClassList();
            this.bindingSource1_trinhDoTayNghe.DataSource = _ChuyenMonNghiepVu;
            //_trinhDoChuyenMonList = TrinhDoChuyenMonList.GetTrinhDoChuyenMonList();
            //this.bindingSource1_trinhDoTayNghe.DataSource = _trinhDoChuyenMonList;
            DateTime tuNgay = Convert.ToDateTime(datTuNgay.Value.ToShortDateString());
            DateTime denNgay = Convert.ToDateTime(dateDenNgay.Value.ToShortDateString());
            //_ttUngVienList = ThongTinUngVienList.GetThongTinUngVienListTrungTuyen(maTuyenDung);
           // _ttUngVienList = ThongTinUngVienList.GetThongTinUngVienListTrungTuyenByNgay(tuNgay, denNgay);

            if (_ttUngVienList.Count == 0)
            {
                MessageBox.Show("Chưa có Ứng Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.bindingSource1_UngVienTrungTuyen.DataSource = _ttUngVienList;
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void frmChuyeUngVienThanhNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < ultragrdDanToc.Rows.Count; i++)
                {
                    ultragrdDanToc.Rows[i].Cells["Check"].Value = (object)true;
                }

            }
            else
            {
                for (int i = 0; i < ultragrdDanToc.Rows.Count; i++)
                {
                    ultragrdDanToc.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void ultragrdDanToc_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaBoPhan"].EditorComponent = cbBophan;
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["NoiSinh"].EditorComponent = cbTinhThanh;
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["NoiCap"].EditorComponent = cbNoiSinh;
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["TrinhDoVanHoa"].EditorComponent = cbTrinhDoVH;
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["TrinhDoTayNghe"].EditorComponent = cbChuyenMonNghiepVu;

            foreach (UltraGridColumn col in ultragrdDanToc.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _ttUngVienList.ApplyEdit();
                _ttUngVienList.Save();
            }
            catch (Exception ex)
            {
 
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            long maUngVien = 0;
            TTNhanVienRutGonList _ttNVList = TTNhanVienRutGonList.GetNhanVienListAll();
            try
            {
                DialogResult result = MessageBox.Show("Bạn Có Muốn Chuyển Những Ứng Viên Đã Chọn Thành Nhân Viên ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    for (int i = 0; i < ultragrdDanToc.Rows.Count; i++)
                    {

                        if ((Convert.ToBoolean(ultragrdDanToc.Rows[i].Cells["Check"].Value) == true) && (Convert.ToBoolean(ultragrdDanToc.Rows[i].Cells["ChuyenThanhNV"].Value) == false))
                        {
                            string maQLNV = Convert.ToString(ultragrdDanToc.Rows[i].Cells["MaQuanLy"].Value);
                            for (int j = 0; j < _ttNVList.Count; j++)
                            {
                                if (_ttNVList[j].MaQLNhanVien == maQLNV)
                                {
                                    MessageBox.Show("Mã Quản Lý Nhân Viên "+maQLNV+ " Đã Tồn Tại, Xin Chọn Nhập Lại Mã Quản Lý Mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    ultragrdDanToc.ActiveRow = ultragrdDanToc.Rows[i];
                                    ultragrdDanToc.Focus();
                                    return;
                                }
                            }

                            maUngVien = Convert.ToInt64(ultragrdDanToc.Rows[i].Cells["MaUngVien"].Value);
                            string tenNV = Convert.ToString(ultragrdDanToc.Rows[i].Cells["HoTen"].Value);
                            int maBoPhan = Convert.ToInt32(ultragrdDanToc.Rows[i].Cells["MaBoPhan"].Value);
                            bool gioiTinh = Convert.ToBoolean(ultragrdDanToc.Rows[i].Cells["GioiTinh"].Value);
                            string CMND = Convert.ToString(ultragrdDanToc.Rows[i].Cells["SoCMND"].Value);
                            DateTime ngayCap = Convert.ToDateTime(ultragrdDanToc.Rows[i].Cells["NgayCap"].Value);
                            DateTime ngaySinh = Convert.ToDateTime(ultragrdDanToc.Rows[i].Cells["NgaySinh"].Value);
                            int maNoiCap = Convert.ToInt32(ultragrdDanToc.Rows[i].Cells["NoiCap"].Value);
                            int maNoiSinh = Convert.ToInt32(ultragrdDanToc.Rows[i].Cells["NoiSinh"].Value);
                            string diaChiTam = Convert.ToString(ultragrdDanToc.Rows[i].Cells["DiaChiLienLac"].Value);
                            ThongTinUngVien.ChuyenUngVienThanhNV(maUngVien, maQLNV, tenNV, maBoPhan, gioiTinh, CMND, ngayCap, maNoiCap, ngaySinh, maNoiSinh, diaChiTam);
                            TimKiem();
                        }
                    }
                    MessageBox.Show("Chuyển Ứng Viên Thành Nhân Viên Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chuyển Ứng Viên Thất Bại","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
           
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void ultragrdDanToc_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            
            if ((Convert.ToBoolean(ultragrdDanToc.ActiveRow.Cells["ChuyenThanhNV"].Value) == true))
            {

                string MaQLNV = "";
                MaQLNV = Convert.ToString(ultragrdDanToc.ActiveRow.Cells["MaQuanLy"].Value);
                frmThongTinNhanVien frmNV = new frmThongTinNhanVien();
                frmNV.TimNhanVienTheoMa(MaQLNV);
                frmNV.Show();
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new ReportDocument();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_SelecttblnsUngVienTrungTuyenByNgayReport";
            command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(datTuNgay.Value));
            command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay.Value));

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "sp_SelecttblnsUngVienTrungTuyenByNgayReport;1";
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
    }
}