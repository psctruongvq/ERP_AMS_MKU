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
    public partial class frmLoaiThueThuNhap : Form
    {
        LoaiThueThuNhapList _loaiThueThuNhapList = LoaiThueThuNhapList.NewLoaiThueThuNhapList();
        Util util = new Util();
        public frmLoaiThueThuNhap()
        {
            InitializeComponent();
            KhoiTao();
        }
        #region KhoiTao()
        private void KhoiTao()
        {
            _loaiThueThuNhapList = LoaiThueThuNhapList.GetLoaiThueThuNhapList();
            loaiThueThuNhapListBindingSource.DataSource = _loaiThueThuNhapList;            
        }
        #endregion

        #region KiemTraDuLieu()
        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (nmu_MucToiThieu.Text == string.Empty)
            {
                MessageBox.Show(this, util.nhapmucthuetoithieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nmu_MucToiThieu.Focus();
                kq = false;
                return kq;
            }
            else if (nmu_MucToiDa.Value == null)
            {
                MessageBox.Show(this, util.nhapmucthuetoida, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nmu_MucToiDa.Focus();
                kq = false;
                return kq;
            }
            else if (nmu_Thue.Value == null)
            {
                MessageBox.Show(this, util.nhapphantramthuethunhap, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nmu_Thue.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }

        private Boolean KiemTraDuLieu(LoaiThueThuNhap loaiThueThuNhap)
        {
            Boolean kq = true;
            if (loaiThueThuNhap.TienToiThieu == 0)
            {
                MessageBox.Show(this, util.nhapmucthuetoithieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nmu_MucToiThieu.Focus();
                kq = false;
                return kq;
            }
            else if (loaiThueThuNhap.TienToiDa == 0)
            {
                MessageBox.Show(this, util.nhapmucthuetoida, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nmu_MucToiDa.Focus();
                kq = false;
                return kq;
            }
            else if (loaiThueThuNhap.PhanTramThue == 0)
            {
                MessageBox.Show(this, util.nhapphantramthuethunhap, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nmu_Thue.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }
        #endregion

        #region grd_LoaiThueThuNhap_InitializeLayout
        private void grd_LoaiThueThuNhap_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditAllGrid(grd_LoaiThueThuNhap);
            //string 
            string[] colPhanTramThuee = new string[5] {"MaThueThuNhap", "TienToiThieu", "TienToiDa", "PhanTramThue", "GhiChu"};
            string[] colCaption = new string[5] { "Mã Thuế", "Tiền Tối Thiểu", "Tiền Tối Đa", "Phần Trăm Thuế", "Ghi Chú"};
            int[] doRong = new int[5] { 100, 100, 100, 70, 150 };
            Control[] conTrol = new Control[5] { null, null, null, null, null};
            KieuDuLieu[] kieuDuLieu = new KieuDuLieu[5] { KieuDuLieu.Null, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.So, KieuDuLieu.Null};
            bool[] duocEdit = new bool[5] { true, true, true, true, true };
            HamDungChung.EditNhieuCot(grd_LoaiThueThuNhap, 0, colPhanTramThuee, colCaption, doRong, conTrol, kieuDuLieu, duocEdit);
            grd_LoaiThueThuNhap.DisplayLayout.Bands[0].Columns["mathuethunhap"].Hidden = true;
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            LoaiThueThuNhap loaiThueThuNhap;
            for (int i = 0; i < _loaiThueThuNhapList.Count; i++)
            {

                loaiThueThuNhap = _loaiThueThuNhapList[i];
                if (loaiThueThuNhap.TienToiThieu == 0)
                {
                    MessageBox.Show(this, util.nhapmucthuetoithieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grd_LoaiThueThuNhap.ActiveRow = grd_LoaiThueThuNhap.Rows[i];
                    nmu_MucToiThieu.Focus();
                    return;
                }
                else if (loaiThueThuNhap.TienToiDa == 0)
                {
                    MessageBox.Show(this,util.nhapmucthuetoida, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grd_LoaiThueThuNhap.ActiveRow = grd_LoaiThueThuNhap.Rows[i];
                    nmu_MucToiDa.Focus();
                    return;
                }
                else if (loaiThueThuNhap.PhanTramThue == 0)
                {
                    MessageBox.Show(this, util.nhapphantramthuethunhap, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grd_LoaiThueThuNhap.ActiveRow = grd_LoaiThueThuNhap.Rows[i];
                    nmu_Thue.Focus();
                    return;
                }
            }
            if (MessageBox.Show(this, util.luudulieu, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                _loaiThueThuNhapList.ApplyEdit();
                _loaiThueThuNhapList.Save();
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
            if (_loaiThueThuNhapList.Count == 0)
            {
                LoaiThueThuNhap LoaiThueThuNhap = LoaiThueThuNhap.NewLoaiThueThuNhap();
                _loaiThueThuNhapList.Add(LoaiThueThuNhap);
                grd_LoaiThueThuNhap.ActiveRow = grd_LoaiThueThuNhap.Rows[_loaiThueThuNhapList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    LoaiThueThuNhap LoaiThueThuNhap = LoaiThueThuNhap.NewLoaiThueThuNhap();
                    _loaiThueThuNhapList.Add(LoaiThueThuNhap);
                    grd_LoaiThueThuNhap.ActiveRow = grd_LoaiThueThuNhap.Rows[_loaiThueThuNhapList.Count - 1];
                }
            }

        }
        #endregion

        #region xóaToolStripMenuItem_Click
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grd_LoaiThueThuNhap.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else grd_LoaiThueThuNhap.DeleteSelectedRows();
        }
        #endregion

        private void txt_GhiChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnsLoaithuethunhapAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptLoaithuethunhap(), new frmHienThiReport(), false);           

        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grd_LoaiThueThuNhap);
        }
    }
}