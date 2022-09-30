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
    public partial class frmTinhDangPhi : Form
    {
        BoPhanList _BoPhanList;
        int maKyTinhLuong = 0;
        int maBophan = 0; long maNhanVien = 0;
        KyTinhLuongList _kyTinhLuongList;
        TTNhanVienRutGonList _nhanVienList, _nhanVienListTemp;
        TinhDangPhiList _tinhDangPhiList=TinhDangPhiList.NewTinhDangPhiList();
        public frmTinhDangPhi()
        {
            InitializeComponent();
        }

        private void frmTinhDangPhi_Load(object sender, EventArgs e)
        {
            _BoPhanList = BoPhanList.GetBoPhanList();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Tất Cả");
            _BoPhanList.Insert(0, _BoPhan);
            BindS_BoPhan.DataSource = _BoPhanList;
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;           
            _tinhDangPhiList = TinhDangPhiList.NewTinhDangPhiList();
            this.bindingSource1_TinhDangPhi.DataSource = _tinhDangPhiList;
            this.label3.Text = "Tổng số: " + _tinhDangPhiList.Count.ToString();

            
        }
        private void ComboChanged()
        {
          
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListByDangVien(maBophan, maNhanVien);
            TTNhanVienRutGon _nhanVienThem = TTNhanVienRutGon.NewTTNhanVienRutGon(0, "Tất Cả");
            _nhanVienList.Insert(0, _nhanVienThem);
            this.bindingSource2_nhanVien.DataSource = _nhanVienList;
            _tinhDangPhiList = TinhDangPhiList.GetTinhDangPhiList(maKyTinhLuong, maBophan, maNhanVien);
            this.bindingSource1_TinhDangPhi.DataSource = _tinhDangPhiList;
            this.label3.Text = "Tổng số: " + _tinhDangPhiList.Count.ToString();
          
        }
        private void cmbu_BoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_BoPhan.Value != null)
            {
                maBophan = Convert.ToInt32(cmbu_BoPhan.Value);
            }
            ComboChanged();
        }

        private void btXuLyThue_Click(object sender, EventArgs e)
        {
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListByDangVien(maBophan, maNhanVien);
            //for (int i = 0; i < _nhanVienList.Count; i++)
            //{                
            TinhDangPhi.XuLyTinhDangPhi(maKyTinhLuong, maNhanVien);
            //}
            _tinhDangPhiList = TinhDangPhiList.GetTinhDangPhiList(maKyTinhLuong, maBophan, maNhanVien);
            this.bindingSource1_TinhDangPhi.DataSource = _tinhDangPhiList;
            MessageBox.Show("Xử Lý Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.label3.Text = "Tổng số: " + _tinhDangPhiList.Count.ToString();
        }

        private void cbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            if (cbNhanVien.Value != null)
            {
                maNhanVien = Convert.ToInt64(cbNhanVien.Value);
            }
          ComboChanged();
        }

        private void cbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null)
            {
                maKyTinhLuong = Convert.ToInt32(cbKyTinhLuong.Value);
            }
            ComboChanged();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            _tinhDangPhiList.ApplyEdit();
            _tinhDangPhiList.Save();
            MessageBox.Show("Xử Lý Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _tinhDangPhiList = TinhDangPhiList.GetTinhDangPhiList(maKyTinhLuong, maBophan, maNhanVien);
            this.bindingSource1_TinhDangPhi.DataSource = _tinhDangPhiList;
        }

        private void grdu_TrichNgang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_TrichNgang.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _tinhDangPhiList = TinhDangPhiList.GetTinhDangPhiList(maKyTinhLuong, maBophan, maNhanVien);
            this.bindingSource1_TinhDangPhi.DataSource = _tinhDangPhiList;
            this.label3.Text = "Tổng số: "+_tinhDangPhiList.Count.ToString();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            
        }

        private void báoCáoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmBaoCaoThuLao_DangPhi f = new frmBaoCaoThuLao_DangPhi();
            f.Show();
          
        }

        private void báoCáoTổngHợpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
         
        }

        private void báoCáoChiTiếtNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoThuLao_DangPhi f = new frmBaoCaoThuLao_DangPhi();
            f.Show();
        }

        private void cbKyTinhLuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
        }

        private void cmbu_BoPhan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_BoPhan, "TenBoPhan");
        }

        private void cbNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            frmBaoCaoThuLao_DangPhi f = new frmBaoCaoThuLao_DangPhi();
            f.Show();
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            frmTinhDangPhi_DieuChinh f = new frmTinhDangPhi_DieuChinh();
            f.Show();
        }
    }
}