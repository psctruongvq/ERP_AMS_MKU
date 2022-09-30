
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
namespace PSC_ERP
{
    public partial class frmKyTinhLuong : Form
    {
        KyTinhLuongList _kyTinhLuongList = KyTinhLuongList.NewKyTinhLuongList();
        Util util = new Util();
        public delegate void PassData(KyTinhLuongList value);
        public PassData passData;
        public static int maKyTinhLuong = 0;
        public frmKyTinhLuong()
        {
            InitializeComponent();
            KhoiTao();            
        }

        #region KhoiTao()
        private void KhoiTao()
        {
            try
            {
                _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
                cmbMaKyChinh.Items.Clear();
                cmbMaKyChinh.Items.Add(null, "");
                foreach (ERP_Library.KyTinhLuong item in _kyTinhLuongList)
                {
                    cmbMaKyChinh.Items.Add(item.MaKy, item.TenKy);
                }
                kyTinhLuongListBindingSource.DataSource = _kyTinhLuongList;
               // tbNgay.Value = (object)Default_Ngay.GetDefault_Ngay().SoNgayLamViecTrongThang;
               // tbSoCong.Value = (object)Default_Ngay.GetDefault_Ngay().SoCongTinhChuyenCan;
            }
            catch (ApplicationException)
            {

            }
        }
        #endregion

        #region KiemTraDuLieu()
        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (txt_TenKy.Text == string.Empty)
            {
                MessageBox.Show(this,util.nhaptenky, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenKy.Focus();
                kq = false;
                return kq;
            }
            else if (numUp_Thang.Value == null)
            {
                MessageBox.Show(this, util.nhapthang, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numUp_Thang.Focus();
                kq = false;
                return kq;
            }
            else if (maskedTextBox_Nam.Text == "")
            {
                MessageBox.Show(this, util.nhapnam, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedTextBox_Nam.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }

        private Boolean KiemTraDuLieu(KyTinhLuong kyLuong)
        {
            Boolean kq = true;
            if (kyLuong.TenKy == string.Empty)
            {
                MessageBox.Show(this, util.nhaptenky, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenKy.Focus();
                kq = false;
                return kq;
            }
            else if (kyLuong.Thang == 0)
            {
                MessageBox.Show(this, util.nhapthang, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numUp_Thang.Focus();
                kq = false;
                return kq;
            }
            else if (kyLuong.Nam== 0)
            {
                MessageBox.Show(this, util.nhapnam, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedTextBox_Nam.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }
        #endregion

        #region grdu_KyTinhLuong_InitializeLayout
        private void grdu_KyTinhLuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            KyTinhLuong kyLuong;
            for (int i = 0; i < _kyTinhLuongList.Count; i++)
            {
              
                if (_kyTinhLuongList[i].TenKy == string.Empty)
                {
                    MessageBox.Show(this, util.nhaptenky, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_KyTinhLuong.ActiveRow = grdu_KyTinhLuong.Rows[i];
                    txt_TenKy.Focus();
                    return;
                }
                else if (_kyTinhLuongList[i].Thang <= 0 || _kyTinhLuongList[i].Thang > 12)
                {
                    MessageBox.Show(this, "Tháng chưa chính xác", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_KyTinhLuong.ActiveRow = grdu_KyTinhLuong.Rows[i];
                    numUp_Thang.Focus();
                    return;
                }
                else if (_kyTinhLuongList[i].Nam < 1900 || _kyTinhLuongList[i].Nam > 2100)
                {
                    MessageBox.Show(this, "Năm chưa chính xác", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_KyTinhLuong.ActiveRow = grdu_KyTinhLuong.Rows[i];
                    maskedTextBox_Nam.Focus();
                    return;
                }
                else if (_kyTinhLuongList[i].NgayBatDau > _kyTinhLuongList[i].NgayKetThuc)
                {
                    MessageBox.Show(this, "Ngày Bắt Đầu phải nhỏ hơn Ngày Kết Thúc", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_KyTinhLuong.ActiveRow = grdu_KyTinhLuong.Rows[i];
                    maskedTextBox_Nam.Focus();
                    return;
                }
                //if (_kyTinhLuongList[i].DungChung == true)
                //{
                //    _kyTinhLuongList[i].SoCongTinhChuyenCan = 0;
                //    _kyTinhLuongList[i].SoNgayLVTT = 0;
                //}
               
            }
            try
            {
                kyTinhLuongListBindingSource.EndEdit();
                _kyTinhLuongList.Save();
                if (passData != null)
                    passData(this._kyTinhLuongList);
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            }
            catch (ApplicationException)
            {

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
            if (_kyTinhLuongList.Count == 0)
            {
                KyTinhLuong kyTinhLuong = KyTinhLuong.NewKyTinhLuong();
                _kyTinhLuongList.Add(kyTinhLuong);
                grdu_KyTinhLuong.ActiveRow = grdu_KyTinhLuong.Rows[_kyTinhLuongList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    KyTinhLuong kyTinhLuong = KyTinhLuong.NewKyTinhLuong();
                    _kyTinhLuongList.Add(kyTinhLuong);
                    grdu_KyTinhLuong.ActiveRow = grdu_KyTinhLuong.Rows[_kyTinhLuongList.Count - 1];
                }
            }

        }
        #endregion

        #region xóaToolStripMenuItem_Click
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdu_KyTinhLuong.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn  Dòng Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else grdu_KyTinhLuong.DeleteSelectedRows();
        }
        #endregion

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            KhoiTao();
        }
        /*
        private void chk_DungChung_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_DungChung.Checked == true)
            {
               
                tbNgay.Enabled = false;
                ulbSoNgay.Enabled = false;
                tbSoCong.Enabled = false;
                ulbSoCong.Enabled = false;
            }
            else
            {
                tbNgay.Enabled = true;
                ulbSoNgay.Enabled = true;
                tbSoCong.Enabled = true;
                ulbSoCong.Enabled = true;
            }
        }
*/
        private void grdu_KyTinhLuong_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            maKyTinhLuong = Convert.ToInt32(grdu_KyTinhLuong.ActiveRow.Cells["MaKy"].Value);
            if (KyTinhLuong.GetKyTinhLuong(maKyTinhLuong).DungChung == true)
            {
                //maSLTHNhanVien = Convert.ToInt64(ultragrdDanToc.ActiveRow.Cells["MaSLTHNhanVien"].Value);
                maKyTinhLuong = Convert.ToInt32(grdu_KyTinhLuong.ActiveRow.Cells["MaKy"].Value);
                frmKyTinhLuong_BoPhan ds = new frmKyTinhLuong_BoPhan();
                ds.Show();
            }
        }

        private void frmKyTinhLuong_Load(object sender, EventArgs e)
        {

        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_KyTinhLuong);
        }
    }
}
