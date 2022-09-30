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
    public partial class frmKyKeToan : Form
    {


        KyList _kyList;
        Util util = new Util();
        public frmKyKeToan()
        {
            InitializeComponent();
            KhoiTao();
           
        }
       

        #region KhoiTao()
        private void KhoiTao()
        {
            _kyList =KyList.GetKyList();
            kyListBindingSource.DataSource = _kyList;
        }
        #endregion

        #region Kiểm Tra Dữ Liệu
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
           
            return kq;
        }

        private Boolean KiemTraDuLieu(Ky kyLuong)
        {
            Boolean kq = true;
            if (kyLuong.TenKy == string.Empty)
            {
                MessageBox.Show(this, util.nhaptenky, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenKy.Focus();
                kq = false;
                return kq;
            }
         
            return kq;
        }
        #endregion

        #region grdu_ky_InitializeLayout
        private void grdu_ky_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditAllGrid(grdu_KyTinhLuong);
            //string 
          
            
            string[] colName = new string[4] { "MaKy", "TenKy", "NgayBatDau", "NgayKetThuc"};
            string[] colCaption = new string[4] {"Mã Kỳ", "Tên Kỳ", "Ngày Bắt Đầu", "Ngày Kết Thúc" };
            int[] doRong = new int[4] { 100, 100, 70, 70 };
            Control[] conTrol = new Control[4] { null, null, null, null};
            KieuDuLieu[] kieuDuLieu = new KieuDuLieu[4] { KieuDuLieu.So, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Ngay};
            bool[] duocEdit = new bool[4] { true, true, true, true };
            HamDungChung.EditNhieuCot(grdu_KyTinhLuong, 0, colName, colCaption, doRong, conTrol, kieuDuLieu, duocEdit);            
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
           Ky ky;
            for (int i = 0; i < _kyList.Count; i++)
            {
                ky= _kyList[i];
                if (ky.TenKy == string.Empty)
                {
                    MessageBox.Show(this, util.nhaptenky, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_KyTinhLuong.ActiveRow = grdu_KyTinhLuong.Rows[i];
                    txt_TenKy.Focus();
                    return;
                }               
                else if (ky.NgayBatDau>ky.NgayKetThuc)
                {
                    MessageBox.Show(this, "Ngày Bắt Đầu phải nhỏ hơn Ngày Kết Thúc", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_KyTinhLuong.ActiveRow = grdu_KyTinhLuong.Rows[i];
                    dtp_TuNgay.Focus();
                    return;
                }
            }
            //if (MessageBox.Show(this, util.luudulieu, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            //{
                _kyList.ApplyEdit();
                _kyList.Save();
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                KhoiTao();
           // }
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
            if (_kyList.Count == 0)
            {
               Ky Ky =Ky.NewKy();
                _kyList.Add(Ky);
                grdu_KyTinhLuong.ActiveRow = grdu_KyTinhLuong.Rows[_kyList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                   Ky Ky =Ky.NewKy();
                    _kyList.Add(Ky);
                    grdu_KyTinhLuong.ActiveRow = grdu_KyTinhLuong.Rows[_kyList.Count - 1];
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
    }
}