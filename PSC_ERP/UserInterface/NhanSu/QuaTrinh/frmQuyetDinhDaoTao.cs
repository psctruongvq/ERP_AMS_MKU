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
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace PSC_ERP

{
    public partial class frmQuyetDinhDaoTao : Form
    {
        Util util = new Util();
        ChiTietQuyetDinh _ChiTietQuyetDinh;
        private static QuyetDinhDaoTao _QuyetDinhDaoTao;
        HinhThucDaoTaoClassList _hinhThucDaoTaoList;
        TruongDaoTaoList _truongDaoTaoList;
        ChuyenNganhDaoTaoClassList _chuyenNganhDaoTaoList;
        TacDongDenClassList _tacDongDenList;
        BoPhanList _BophanList;
        ChuyenMonNghiepVuClassList _trinhDoChuyenMonList;
        ThongTinNhanVienTongHopList _TenNhanVienList;
        ThongTinNhanVienTongHopList _NguoikyList;
        ChucVuList _ChucVuList;

        public frmQuyetDinhDaoTao()
        {
            InitializeComponent();
            this.Load_Form();
            tlslblTim.Visible = false;
            toolStripLabel1.Visible = false;
        }
        public frmQuyetDinhDaoTao(QuyetDinhDaoTao obj)
        {
            InitializeComponent();
            _QuyetDinhDaoTao = obj;
        }
       
        #region Load
        private void Load_Form()
        {
            _hinhThucDaoTaoList = HinhThucDaoTaoClassList.GetHinhThucDaoTaoClassList();
            BindS_HinhThucDaoTao.DataSource = _hinhThucDaoTaoList;
            _truongDaoTaoList = TruongDaoTaoList.GetTruongDaoTaoList();
            BindS_TruongDaotao.DataSource = _truongDaoTaoList;
            _chuyenNganhDaoTaoList = ChuyenNganhDaoTaoClassList.GetChuyenNganhDaoTaoClassList();
            BindS_ChuyenNganhDaoTao.DataSource = _chuyenNganhDaoTaoList;
            _tacDongDenList = TacDongDenClassList.GetTacDongDenClassList();
            BindS_TacDongDen.DataSource = _tacDongDenList;
            _trinhDoChuyenMonList = ChuyenMonNghiepVuClassList.GetChuyenMonNghiepVuClassList();
            BindS_TrinhDoChuyenMon.DataSource = _trinhDoChuyenMonList;
            _ChucVuList = ChucVuList.GetChucVuList();
            BindS_ChucVu.DataSource = _ChucVuList;
            _BophanList = BoPhanList.GetBoPhanList();
            BindS_bophan.DataSource = _BophanList;

            _QuyetDinhDaoTao = QuyetDinhDaoTao.NewQuyetDinhDaoTao();
            BindS_QuyetDinhDaoTao.DataSource = _QuyetDinhDaoTao;
            BindS_ChiTietQuyetDinh.DataSource = _QuyetDinhDaoTao.ChiTietQuyetDinhList;
        }
        private void grdu_ChiTietQUyetDinh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["MaQuyetDinh"].Hidden = true;
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = true;

            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["MaNhanVien"].EditorComponent = cmbu_MaNhanVien;
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["CheDo"].Header.Caption = "Chế Độ";
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["MucTamUng"].Header.Caption = "Mức Tạm Ứng";
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["ChiPhiCaNhan"].Header.Caption = "Chi Phí Cá Nhân";
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 250;
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["MaNhanVien"].Width = 200;
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.Caption = "Tên Nhân Viên";

            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 5;
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.VisiblePosition = 1;
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["CheDo"].Header.VisiblePosition = 2;
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["ChiPhiCaNhan"].Header.VisiblePosition = 3;
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["MucTamUng"].Header.VisiblePosition = 4;

            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["ChiPhiCaNhan"].EditorComponent = txtu_ChiPhi;
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["MucTamUng"].EditorComponent = txt_MucTamUng;
            grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["CheDo"].EditorComponent = txt_CheDoChung;

            this.grdu_ChiTietQUyetDinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_ChiTietQUyetDinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            foreach (UltraGridColumn col in grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;

                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###";
                }
            }

        }        
        #endregion

        #region Events
    
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            _QuyetDinhDaoTao = QuyetDinhDaoTao.NewQuyetDinhDaoTao();
            BindS_QuyetDinhDaoTao.DataSource = _QuyetDinhDaoTao;
            BindS_ChiTietQuyetDinh.DataSource = _QuyetDinhDaoTao.ChiTietQuyetDinhList;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbu_MaNhanVien.Value != null)
                {
                    foreach (UltraGridRow row in grdu_ChiTietQUyetDinh.Rows)
                    {
                        if ((long)row.Cells["MaNhanVien"].Value == (long)cmbu_MaNhanVien.Value)
                        {
                            MessageBox.Show("Nhân Viên Đã Được Chọn Rồi!", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                if (this.Validation_Input())
                {
                    decimal tongChiPhi = 0;
                    for (int i = 0; i < grdu_ChiTietQUyetDinh.Rows.Count; i++)
                    {
                        tongChiPhi += decimal.Parse(grdu_ChiTietQUyetDinh.Rows[i].Cells["ChiPhiCaNhan"].Value.ToString());
                    }
                    if ((decimal)crceu_TongChiPhi.Value != tongChiPhi)
                    {
                        MessageBox.Show("Tổng Chi Phí Cá Nhân Phải Bằng Tổng Chi Phí", util.thongbao);
                        return;
                    }
                    grdu_ChiTietQUyetDinh.UpdateData();
                    _QuyetDinhDaoTao.ApplyEdit();
                    _QuyetDinhDaoTao.Save();
                    MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grdu_ChiTietQUyetDinh.DisplayLayout.Bands[0].Columns["MaNhanVien"].CellActivation = Activation.NoEdit;
                }
                else
                    MessageBox.Show(util.chuachonduthongtin, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, util.luuthatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }            
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            BindS_ChiTietQuyetDinh.DataSource = QuyetDinhDaoTao.GetQuyetDinhDaoTao(_QuyetDinhDaoTao.MaQuyetDinh).ChiTietQuyetDinhList;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_ChiTietQUyetDinh.Rows.Count != 0)
            {
                grdu_ChiTietQUyetDinh.DeleteSelectedRows();
            }
        }

        private void tstrip_ThemMoi_Click(object sender, EventArgs e)
        {
            _ChiTietQuyetDinh = ChiTietQuyetDinh.NewChiTietQuyetDinh(_QuyetDinhDaoTao.MaQuyetDinh, 0, txt_CheDoChung.Text.ToString(), Convert.ToInt32(txt_MucTamUng.Value), Convert.ToDecimal(txtu_ChiPhi.Value));
            _QuyetDinhDaoTao.ChiTietQuyetDinhList.Add(_ChiTietQuyetDinh);
            BindS_ChiTietQuyetDinh.DataSource = _QuyetDinhDaoTao.ChiTietQuyetDinhList;
        }

        private void cmbu_Bophan_AfterCloseUp(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
                _TenNhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_Bophan((int)cmbu_Bophan.Value,0);
                BindS_Nhanvien.DataSource = _TenNhanVienList;
            }
        }

        private void cmbu_ChucVuNguoiKy_AfterCloseUp(object sender, EventArgs e)
        {
            if (cmbu_ChucVuNguoiKy.Value != null)
            {
                _NguoikyList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_ChucVu((int)cmbu_ChucVuNguoiKy.Value);
                BindS_Nhanvien.DataSource = _NguoikyList;
            }
        }

        private void cmbu_MaNhanVien_AfterCloseUp(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in grdu_ChiTietQUyetDinh.Rows)
            {
                if ((long)row.Cells["MaNhanVien"].Value == (long)cmbu_MaNhanVien.Value)
                {
                    MessageBox.Show("Nhân Viên Đã Được Chọn Rồi!", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        #endregion

        #region Process
        private bool Validation_Input()
        {
            bool kq = true;
            if (cmbu_HinhThucDT.Value == null || cmbu_NguoiKy.Value == null || cmbu_TrinhDoChuyenMon.Value == null)
            {
                return kq = false;
            }
            if (txt_SoQuyetDinh.Text == "")
            {
                return kq = false;
            }
            if ((DateTime)dtmp_ThoiGianBD.Value > (DateTime)dtmu_ThoiGianKT.Value)
            {
                return kq = false;
            }
            return kq;
        }
        #endregion

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (txt_SoQuyetDinh.Text == "")
            {
                MessageBox.Show(this, "Chọn số quyết định cần in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ReportDocument Report = new Report.Quyetdinhdaotao();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_tblnsQuyetdinhdaotaoAll";
            command.Parameters.AddWithValue("@soquyetdinh", txt_SoQuyetDinh.Text);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_tblnsQuyetdinhdaotaoAll;1";

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

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void TimKiem()
        {
            frmQuyetDinhBoNhiem_Tim frm_tim = new frmQuyetDinhBoNhiem_Tim();
            frm_tim.ShowDialog();
            BindS_QuyetDinhDaoTao.DataSource = _QuyetDinhDaoTao;
            BindS_ChiTietQuyetDinh.DataSource = _QuyetDinhDaoTao.ChiTietQuyetDinhList;           
        }

        private void frmQuyetDinhDaoTao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                TimKiem();
            }
        }

        private void frmQuyetDinhDaoTao_Load(object sender, EventArgs e)
        {

        }

        private void cmbu_ChucVuNguoiKy_ValueChanged(object sender, EventArgs e)
        {
            _TenNhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_ChucVu((int)cmbu_ChucVuNguoiKy.Value);
            this.BindS_Nhanvien.DataSource = _TenNhanVienList;
        }




    }
}