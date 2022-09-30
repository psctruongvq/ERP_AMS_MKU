using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraDataGridView;
using Infragistics.Win;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmNhanVien_ChuyenMon : Form
    {
        public NhanVien_ChuyenNganhList _NhanVien_ChuyenMonList;
        TruongDaoTaoList _truongDaoTaoList;
        HinhThucDaoTaoClassList _hinhThucDaoTaoLits;
        ChuyenNganhDaoTaoClassList _chuyenNganhDaoTaoList;
        //TrinhDoNgoaiNguClassList _trinhDoList;
        public frmNhanVien_ChuyenMon(NhanVien_ChuyenNganhList dcList)
        {
            InitializeComponent();
            KhoiTaoBanDau();
            _NhanVien_ChuyenMonList = dcList;
            for (int i = 0; i < _NhanVien_ChuyenMonList.Count; i++)
            {
                if (_NhanVien_ChuyenMonList[i].TenChuyenNganh== "" && _NhanVien_ChuyenMonList[i].MaChuyenNganh == 0 )
                {
                    _NhanVien_ChuyenMonList.RemoveAt(i);
                }
            }
            ChuyenMon_NhanVien_bindingSource.DataSource = _NhanVien_ChuyenMonList;
        }

        public void KhoiTaoBanDau()
        {
            _hinhThucDaoTaoLits = HinhThucDaoTaoClassList.GetHinhThucDaoTaoClassList();
            this.bindingSource1_HinhThucDaoTao.DataSource = _hinhThucDaoTaoLits;
            _chuyenNganhDaoTaoList = ChuyenNganhDaoTaoClassList.GetChuyenNganhDaoTaoClassList();     
            this.ChuyenNganhDaoTao_BindingSource.DataSource = _chuyenNganhDaoTaoList;
            _truongDaoTaoList = TruongDaoTaoList.GetTruongDaoTaoList();
            this.bindingSource1_TruongDaoTao.DataSource = _truongDaoTaoList;

        }

        private void grd_DSDiaChiNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            

         
        }

        private void grd_DSDiaChiNhanVien_CellChange(object sender, CellEventArgs e)
        {
           // grd_DSDiaChiNhanVien.UpdateData();
        }

        private void frmNhanVien_ChuyenMon_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.grd_DSDiaChiNhanVien.UpdateData();
            this.ChuyenMon_NhanVien_bindingSource.EndEdit();
        }

     
    }
}