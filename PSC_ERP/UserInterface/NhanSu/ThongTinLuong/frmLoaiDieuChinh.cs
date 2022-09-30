using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmLoaiDieuChinh : Form
    {
        LoaiDieuChinhLuongList _loaiDieuChinhLuongList = LoaiDieuChinhLuongList.NewLoaiDieuChinhLuongList();
        Util util = new Util();

        public frmLoaiDieuChinh()
        {
            InitializeComponent();
            KhoiTao();
        }

        #region KhoiTao()
        private void KhoiTao()
        {
            _loaiDieuChinhLuongList = LoaiDieuChinhLuongList.GetLoaiDieuChinhLuongList();
            loaiDieuChinhLuongListBindingSource.DataSource = _loaiDieuChinhLuongList;
         
        }
        #endregion

        #region KiemTraDuLieu()
        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (txt_LoaiDieuChinh.Text == string.Empty)
            {
                MessageBox.Show(this,util.nhapmaloaidieuchinhluong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_LoaiDieuChinh.Focus();
                kq = false;
                return kq;
            }
            else if (txt_TenLoaiDieuChinh.Text == string.Empty)
            {
                MessageBox.Show(this, util.nhaptenloaidieuchinhluong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenLoaiDieuChinh.Focus();
                kq = false;
                return kq;
            }          
            return kq;
        }

        private Boolean KiemTraDuLieu(LoaiDieuChinhLuong loaiDieuChinhLuong)
        {
            Boolean kq = true;
            if (loaiDieuChinhLuong.MaQuanLy == string.Empty)
            {
                MessageBox.Show(this, util.nhapmaloaidieuchinhluong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_LoaiDieuChinh.Focus();
                kq = false;
                return kq;
            }
            else if (loaiDieuChinhLuong.TenLoaiDieuChinh== string.Empty)
            {
                MessageBox.Show(this, util.nhaptenloaidieuchinhluong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenLoaiDieuChinh.Focus();
                kq = false;
                return kq;
            }            
            return kq;
        }
        #endregion

        #region grdu_loaiDieuChinhLuong_InitializeLayout
        private void grdu_loaiDieuChinhLuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditAllGrid(grdu_LoaiDieuChinhLuong);
            //string 
            string[] colName = new string[3] { "MaQuanLy", "TenLoaiDieuChinh", "GhiChu" };
            string[] colCaption = new string[3] { "Mã Quản Lý", "Tên Loại Điều Chỉnh Lương", "Ghi Chú"};
            int[] doRong = new int[3] { 100, 150, 200};
            Control[] conTrol = new Control[3] { null, null, null };
            KieuDuLieu[] kieuDuLieu = new KieuDuLieu[3] { KieuDuLieu.Null,  KieuDuLieu.Null, KieuDuLieu.Null};
            bool[] duocEdit = new bool[3] { false, false, false};
            HamDungChung.EditNhieuCot(grdu_LoaiDieuChinhLuong, 0, colName, colCaption, doRong, conTrol, kieuDuLieu, duocEdit);
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            LoaiDieuChinhLuong loaiDieuChinhLuong;
            for (int i = 0; i < _loaiDieuChinhLuongList.Count; i++)
            {

                loaiDieuChinhLuong = _loaiDieuChinhLuongList[i];
                if (loaiDieuChinhLuong.MaQuanLy== string.Empty)
                {
                     MessageBox.Show(this, util.nhapmaloaidieuchinhluong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_LoaiDieuChinhLuong.ActiveRow = grdu_LoaiDieuChinhLuong.Rows[i];
                    txt_LoaiDieuChinh.Focus();
                    return;
                }
                else if (loaiDieuChinhLuong.TenLoaiDieuChinh == string.Empty)
                {
                     MessageBox.Show(this, util.nhaptenloaidieuchinhluong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_LoaiDieuChinhLuong.ActiveRow = grdu_LoaiDieuChinhLuong.Rows[i];
                    txt_TenLoaiDieuChinh.Focus();
                    return;
                }
               
            }
            if (MessageBox.Show(this, util.luudulieu, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                _loaiDieuChinhLuongList.ApplyEdit();
                _loaiDieuChinhLuongList.Save();
                KhoiTao();
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region thoatToolStripMenuItem_Click
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region thêmToolStripMenuItem_Click
        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_loaiDieuChinhLuongList.Count == 0)
            {
                LoaiDieuChinhLuong loaiDieuChinhLuong = LoaiDieuChinhLuong.NewLoaiDieuChinhLuong();
                _loaiDieuChinhLuongList.Add(loaiDieuChinhLuong);
                grdu_LoaiDieuChinhLuong.ActiveRow = grdu_LoaiDieuChinhLuong.Rows[_loaiDieuChinhLuongList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    LoaiDieuChinhLuong loaiDieuChinhLuong = LoaiDieuChinhLuong.NewLoaiDieuChinhLuong();
                    _loaiDieuChinhLuongList.Add(loaiDieuChinhLuong);
                    grdu_LoaiDieuChinhLuong.ActiveRow = grdu_LoaiDieuChinhLuong.Rows[_loaiDieuChinhLuongList.Count - 1];
                }
            }

        }
        #endregion

        #region xóaToolStripMenuItem_Click
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdu_LoaiDieuChinhLuong.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else grdu_LoaiDieuChinhLuong.DeleteSelectedRows();
        }
        #endregion

        private void frmLoaiDieuChinh_Load(object sender, EventArgs e)
        {

        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnsLoaidieuchinhluongAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptLoaidieuchinhluong(), new frmHienThiReport(), false);           
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_LoaiDieuChinhLuong);
        }
    }
}