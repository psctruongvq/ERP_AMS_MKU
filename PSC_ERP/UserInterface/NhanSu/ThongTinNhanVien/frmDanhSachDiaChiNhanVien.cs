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
    public partial class frmDanhSachDiaChiNhanVien : Form
    {
        public DiaChi_NhanVienList _DiaChi_NhanVienList;
        QuanHuyenList _QuanHuyenListDiaChi;
        TinhThanhList _TinhThanhListDiaChi;
        QuocGiaList _QuocGiaListDiaChi;

        public frmDanhSachDiaChiNhanVien(DiaChi_NhanVienList dcList)
        {
            InitializeComponent();
            KhoiTaoBanDau();
            _DiaChi_NhanVienList = dcList;
            for (int i = 0; i < _DiaChi_NhanVienList.Count; i++)
            {
                if (_DiaChi_NhanVienList[i].TenDiaChi == "" && _DiaChi_NhanVienList[i].MaQuanHuyen == 0 )
                {
                    _DiaChi_NhanVienList.RemoveAt(i);
                }
            }
            DSDiaChi_bindingSource.DataSource = _DiaChi_NhanVienList;
        }

        public void KhoiTaoBanDau()
        {
            _QuanHuyenListDiaChi = QuanHuyenList.GetQuanHuyenList();
            QuanHuyen_BindingSource.DataSource = _QuanHuyenListDiaChi;

            _TinhThanhListDiaChi = TinhThanhList.GetTinhThanhList();
            TinhThanh_BindingSource.DataSource = _TinhThanhListDiaChi;

            _QuocGiaListDiaChi = QuocGiaList.GetQuocGiaList();
            QuocGia_BindingSource.DataSource = _QuocGiaListDiaChi;
        }

        private void grd_DSDiaChiNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            grd_DSDiaChiNhanVien.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            grd_DSDiaChiNhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaDiaChi"].Hidden = true;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["QuanHuyen"].Hidden = true;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["TinhTP"].Hidden = true;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["QuocGia"].Hidden = true;
            
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["TenDiaChi"].Header.Caption = "Địa Chỉ";
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["TenDiaChi"].Header.VisiblePosition = 0;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["TenDiaChi"].Width = 150;
            
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanHuyen"].EditorComponent = cmbu_QuanHuyen;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaTinhThanh"].EditorComponent = cmbu_TinhThanh;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuocGia"].EditorComponent = cmbu_QuocGia;

            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanHuyen"].Header.Caption = "Quận/Huyện";
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanHuyen"].Width = 130;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanHuyen"].Header.VisiblePosition = 1;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Header.Caption = "Tỉnh/TP";
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Width = 130;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Header.VisiblePosition = 2;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuocGia"].Header.Caption = "Quốc Gia";
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuocGia"].Width = 130;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuocGia"].Header.VisiblePosition = 3;

            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["Active"].Header.Caption = "Sử Dụng";
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["Active"].Header.VisiblePosition = 4;

            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["TamTru"].Header.Caption = "Tạm Trú";
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["TamTru"].Header.VisiblePosition = 5; 

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void cmbu_QuanHuyen_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_QuanHuyen.Value != null)
            {
                int maQuanHuyen = Convert.ToInt32(cmbu_QuanHuyen.Value);
                int maTinhThanh = Convert.ToInt32(QuanHuyen.GetQuanHuyen(maQuanHuyen).MaTinhThanh);
                int maQuocGia = Convert.ToInt32(TinhThanh.GetTinhThanh(maTinhThanh).MaQuocGia);

                cmbu_QuanHuyen.Value = maQuanHuyen;
                cmbu_TinhThanh.Value = maTinhThanh;
                cmbu_QuocGia.Value = maQuocGia;
            }
        }
    }
}