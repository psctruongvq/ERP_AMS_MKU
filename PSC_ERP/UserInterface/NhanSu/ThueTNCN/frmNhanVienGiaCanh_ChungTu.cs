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
    public partial class frmNhanVienGiaCanh_ChungTu : Form
    {
        ChungTuGiamTruGiaCanhList _chungTuList;
     public static  NguoiPhuThuoc_ChungTuGiaCanhList _nguoiPhuThuocList;
        public frmNhanVienGiaCanh_ChungTu()
        {
            InitializeComponent();
        }
        public frmNhanVienGiaCanh_ChungTu(NhanVienGiaCanh nhanVien_GiaCanh, int maNhanVien_GiaCanh)
        {
            InitializeComponent();
            _chungTuList = ChungTuGiamTruGiaCanhList.GetChungTuGiamTruGiaCanhList();
            this.bindingSource1_ChungTu.DataSource = _chungTuList;           
            this.bindingSource1_ChiTietGiaCanh_chungTu.DataSource = nhanVien_GiaCanh.NguoiPhuThuoc_ChungTuList;
            _nguoiPhuThuocList = nhanVien_GiaCanh.NguoiPhuThuoc_ChungTuList;
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
        }
    }
}