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
    public partial class frmNhanVien_TrinhDoQuanLy : Form
    {
        public NhanVien_TrinhDoQuanLyList _NhanVien_TrinhDoQuanLyList;       

        QuanLyNhaNuocList _quanLyNNList;
        QuanLyKinhTeList _quanLyKinhTeList;
        public frmNhanVien_TrinhDoQuanLy(NhanVien_TrinhDoQuanLyList dcList)
        {
            InitializeComponent();
            KhoiTaoBanDau();
            _NhanVien_TrinhDoQuanLyList = dcList;
            for (int i = 0; i < _NhanVien_TrinhDoQuanLyList.Count; i++)
            {
                if (_NhanVien_TrinhDoQuanLyList[i].MaQuanLyNhaNuoc == 0 && _NhanVien_TrinhDoQuanLyList[i].MaQuanLyKinhTe == 0 )
                {
                    _NhanVien_TrinhDoQuanLyList.RemoveAt(i);
                }
            }
            TrinhDoQuanLy_NhanVien_bindingSource.DataSource = _NhanVien_TrinhDoQuanLyList;
        }

        public void KhoiTaoBanDau()
        {
            QuanLyNhaNuoc item = QuanLyNhaNuoc.NewQuanLyNhaNuoc(0,"Trống");
            _quanLyNNList = QuanLyNhaNuocList.GetQuanLyNhaNuocList();           
            _quanLyNNList.Insert(0, item);
            
            this.QuanLyNhaNuoc_BindingSource.DataSource = _quanLyNNList;

            QuanLyKinhTe item1 = QuanLyKinhTe.NewQuanLyKinhTe(0,"Trống");            
            _quanLyKinhTeList = QuanLyKinhTeList.GetQuanLyKinhTeList();
            _quanLyKinhTeList.Insert(0, item1);
            this.QuanLyKinhTe_BindingSource.DataSource = _quanLyKinhTeList;
        }

        private void grd_DSDiaChiNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            

            grd_DSDiaChiNhanVien.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            grd_DSDiaChiNhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

           

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanLyNhaNuoc"].EditorComponent=cbQuanLyNhaNuoc;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanLyNhaNuoc"].Hidden = false;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanLyNhaNuoc"].Header.Caption = "Quản Lý Nhà Nước";
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanLyNhaNuoc"].Width = cbQuanLyNhaNuoc.Width;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanLyNhaNuoc"].Header.VisiblePosition = 0;

            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanLyKinhTe"].EditorComponent = cbQuanLyKT;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanLyKinhTe"].Hidden = false;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanLyKinhTe"].Header.Caption = " Quản Lý Kinh Tế";
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanLyKinhTe"].Width = cbQuanLyNhaNuoc.Width;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaQuanLyKinhTe"].Header.VisiblePosition = 1;

            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["TrinhDoChinh"].Hidden = false;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["TrinhDoChinh"].Header.Caption = "Trình Độ Chính";
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["TrinhDoChinh"].Header.VisiblePosition = 2;
            
        }

        private void frmNhanVien_TrinhDoQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.grd_DSDiaChiNhanVien.UpdateData();
            this.TrinhDoQuanLy_NhanVien_bindingSource.EndEdit();
        }

     
    }
}