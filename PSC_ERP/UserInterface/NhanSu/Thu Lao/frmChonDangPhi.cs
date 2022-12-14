using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
//
//
namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class frmChonDangPhi : Form
    {
        int maNhom = 0;
        public frmChonDangPhi()
        {
            InitializeComponent();
        }
        PhuCapNhanVienList _phuCapNhanVienList;
       
        private void frmChonDangPhi_Load(object sender, EventArgs e)
        {
            KhoiTao();
        }

        public void KhoiTao()
        {

            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            cmbKyLuong.DataSource = cmbKyLuong.DataSource;
           // boPhanListBindingSource.DataSource = ERP_Library.BoPhanList.GetBoPhanListAll();
            //HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            //cmbBoPhan.Value = 0;
            foreach (ERP_Library.NhomPhuCap item in ERP_Library.NhomPhuCapList.GetNhomPhuCapList())
                cmbNhomPhuCap.Items.Add(item.MaNhom, item.Ten);            
            cmbNhomPhuCap.Value = 0;
            _phuCapNhanVienList = PhuCapNhanVienList.NewPhuCapNhanVienList();
            _PhuCapNhanVienListUpDate = PhuCapNhanVienList.NewPhuCapNhanVienList();
        }
        PhuCapNhanVienList _PhuCapNhanVienListUpDate = PhuCapNhanVienList.NewPhuCapNhanVienList();
        private void cmbPhuCap_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null ||Convert.ToInt32(cmbKyLuong.Value) != 0 ||Convert.ToInt32(cmbNhomPhuCap.Value) != 0)
            {
                _phuCapNhanVienList = PhuCapNhanVienList.GetNhapPhuCapListByDangPhi(Convert.ToInt32(cmbKyLuong.Value), Convert.ToInt32(cmbNhomPhuCap.Value));
                PhuCapNhanVienList_bindingSource.DataSource = _phuCapNhanVienList;
               // _PhuCapNhanVienListUpDate = PhuCapNhanVienList(Convert.ToInt32(cmbKyLuong.Value), Convert.ToInt32(cmbNhomPhuCap.Value));
                maNhom = Convert.ToInt32(cmbNhomPhuCap.Value);
            }

            
            //if (cmbPhuCap.Value != null)
            //{
            //    cmbLoaiPC.Items.Clear();
            //    cmbLoaiPC.Items.Add(0, "Tất cả");
            //    foreach (ERP_Library.LoaiPhuCapChild item in ERP_Library.LoaiPhuCapList.GetLoaiPhuCapByMaNhom((int)cmbPhuCap.Value))
            //    {
            //        cmbLoaiPC.Items.Add(item.MaLoaiPhuCap, item.TenLoaiPhuCap);
            //    }
            //    cmbLoaiPC.Value = 0;
            //}
        }

        private void cmbLoaiPC_ValueChanged(object sender, EventArgs e)
        {
            //_phuCapNhanVienList = PhuCapNhanVienList.GetNhapPhuCapListByDangPhi(;
            PhuCapNhanVienList_bindingSource.DataSource = _phuCapNhanVienList;
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            KhoiTao();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (_PhuCapNhanVienListUpDate == null) return;
            try
            {
                grdu_QuocGia.UpdateData();
                _PhuCapNhanVienListUpDate.Save();
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        private void grdu_QuocGia_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                if (grdu_QuocGia.ActiveRow != null)
                {
                    if (grdu_QuocGia.ActiveCell == grdu_QuocGia.ActiveRow.Cells["TinhDangPhi"])
                    {
                        int maKyTinhLuong = (int)grdu_QuocGia.ActiveRow.Cells["MaKyTinhLuong"].Value;
                        int maLoaiPhuCap = (int)grdu_QuocGia.ActiveRow.Cells["MaLoaiPhuCap"].Value;
                        Boolean tinhdangphi = (Boolean)grdu_QuocGia.ActiveRow.Cells["TinhDangPhi"].Value;
                        
                        _PhuCapNhanVienListUpDate = PhuCapNhanVienList.GetNhapPhuCapListUpdateDangPhi1(maKyTinhLuong,maLoaiPhuCap,maNhom);

                        for (int i = 0; i < _PhuCapNhanVienListUpDate.Count; i++)
                        {
                            _PhuCapNhanVienListUpDate[i].TinhDangPhi = tinhdangphi;
                           
                        }
                        _PhuCapNhanVienListUpDate.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}