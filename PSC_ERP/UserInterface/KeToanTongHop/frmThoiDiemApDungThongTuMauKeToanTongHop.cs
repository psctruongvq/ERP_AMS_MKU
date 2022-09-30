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
    public partial class frmThoiDiemApDungThongTuMauKeToanTongHop : Form
    {


        ThoiDiemApDungThongTuMauKeToanTongHopList _ThoiDiemApDungThongTuMauKeToanTongHopList;
        Util util = new Util();
        public frmThoiDiemApDungThongTuMauKeToanTongHop()
        {
            InitializeComponent();
            KhoiTao();
           
        }
       

        #region KhoiTao()
        private void KhoiTao()
        {
            _ThoiDiemApDungThongTuMauKeToanTongHopList =ThoiDiemApDungThongTuMauKeToanTongHopList.GetThoiDiemApDungThongTuMauKeToanTongHopList();
            ThoiDiemApDungMauKeToanTongHopbindingSource.DataSource = _ThoiDiemApDungThongTuMauKeToanTongHopList;
             KyList kylist   =KyList.GetKyList();
             kyListBindingSource.DataSource = kylist;
        }
        #endregion
        private void ReLoadData()
        {
            _ThoiDiemApDungThongTuMauKeToanTongHopList = ThoiDiemApDungThongTuMauKeToanTongHopList.GetThoiDiemApDungThongTuMauKeToanTongHopList();
            ThoiDiemApDungMauKeToanTongHopbindingSource.DataSource = _ThoiDiemApDungThongTuMauKeToanTongHopList;
        }
        #region Kiểm Tra Dữ Liệu
        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (cbu_Ky.Value == null)
            {
                MessageBox.Show("Vui lòng nhập kỳ áp dụng thông tư!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbu_Ky.Focus();
                kq = false;
                return kq;
            }
            else if (txt_NoiDung.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập nội dung thông tư!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_NoiDung.Focus();
                kq = false;
                return kq;
            }
           
            return kq;
        }

        //private Boolean KiemTraDuLieu(Ky kyLuong)
        //{
        //    Boolean kq = true;
        //    if (kyLuong.TenKy == string.Empty)
        //    {
        //        MessageBox.Show(this, util.nhaptenky, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txt_TenKy.Focus();
        //        kq = false;
        //        return kq;
        //    }
         
        //    return kq;
        //}
        #endregion

        #region grdu_ky_InitializeLayout
        private void grdu_ky_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditAllGrid(grdu_ThoiDiemApDungThongTuKeToanTongHop);
            //string           
            
            string[] colName = new string[3] { "MaKy", "NoiDung", "GhiChu"};
            string[] colCaption = new string[3] {"Kỳ áp dụng", "Nội dung", "Ghi Chú" };
            int[] doRong = new int[3] { 100, 150, 70 };
            Control[] conTrol = new Control[3] {cbu_Ky, null, null};
            KieuDuLieu[] kieuDuLieu = new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null };
            bool[] duocEdit = new bool[3] { true, true, true };
            HamDungChung.EditNhieuCot(grdu_ThoiDiemApDungThongTuKeToanTongHop, 0, colName, colCaption, doRong, conTrol, kieuDuLieu, duocEdit);            
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
           ThoiDiemApDungThongTuMauKeToanTongHop thongtu;
            for (int i = 0; i < _ThoiDiemApDungThongTuMauKeToanTongHopList.Count; i++)
            {
                thongtu= _ThoiDiemApDungThongTuMauKeToanTongHopList[i];
                if (thongtu.MaKy == 0)
                {
                    MessageBox.Show("Vui lòng nhập kỳ áp dụng thông tư!","Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_ThoiDiemApDungThongTuKeToanTongHop.ActiveRow = grdu_ThoiDiemApDungThongTuKeToanTongHop.Rows[i];
                    cbu_Ky.Focus();
                    return;
                }               
                else if (thongtu.NoiDung==String.Empty)
                {
                    MessageBox.Show("Vui lòng nhập nội dung thông tư!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_ThoiDiemApDungThongTuKeToanTongHop.ActiveRow = grdu_ThoiDiemApDungThongTuKeToanTongHop.Rows[i];
                    txt_NoiDung.Focus();
                    return;
                }
            }
            //if (MessageBox.Show(this, util.luudulieu, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            //{
                _ThoiDiemApDungThongTuMauKeToanTongHopList.ApplyEdit();
                _ThoiDiemApDungThongTuMauKeToanTongHopList.Save();
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReLoadData();
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
            if (_ThoiDiemApDungThongTuMauKeToanTongHopList.Count == 0)
            {
                ThoiDiemApDungThongTuMauKeToanTongHop thongtu = ThoiDiemApDungThongTuMauKeToanTongHop.NewThoiDiemApDungThongTuMauKeToanTongHop();
                _ThoiDiemApDungThongTuMauKeToanTongHopList.Add(thongtu);
                grdu_ThoiDiemApDungThongTuKeToanTongHop.ActiveRow = grdu_ThoiDiemApDungThongTuKeToanTongHop.Rows[_ThoiDiemApDungThongTuMauKeToanTongHopList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    ThoiDiemApDungThongTuMauKeToanTongHop thongtu = ThoiDiemApDungThongTuMauKeToanTongHop.NewThoiDiemApDungThongTuMauKeToanTongHop();
                    _ThoiDiemApDungThongTuMauKeToanTongHopList.Add(thongtu);
                    grdu_ThoiDiemApDungThongTuKeToanTongHop.ActiveRow = grdu_ThoiDiemApDungThongTuKeToanTongHop.Rows[_ThoiDiemApDungThongTuMauKeToanTongHopList.Count - 1];
                }
            }

        }
        #endregion

        #region xóaToolStripMenuItem_Click
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdu_ThoiDiemApDungThongTuKeToanTongHop.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn  Dòng Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else grdu_ThoiDiemApDungThongTuKeToanTongHop.DeleteSelectedRows();
        }
        #endregion

    }
}