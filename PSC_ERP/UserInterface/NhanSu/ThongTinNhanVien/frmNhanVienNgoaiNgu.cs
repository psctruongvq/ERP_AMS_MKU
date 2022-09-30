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
    public partial class frmNhanVien_NgoaiNgu : Form
    {
        public NhanVien_NgoaiNguList _NhanVien_NgoaiNguList;       

        NgoaiNguList _ngoaiNguList;
        TrinhDoNgoaiNguClassList _trinhDoList;
        public frmNhanVien_NgoaiNgu(NhanVien_NgoaiNguList dcList)
        {
            InitializeComponent();
            KhoiTaoBanDau();
            _NhanVien_NgoaiNguList = dcList;
            for (int i = 0; i < _NhanVien_NgoaiNguList.Count; i++)
            {
                if (_NhanVien_NgoaiNguList[i].TenNgoaiNgu == "" && _NhanVien_NgoaiNguList[i].MaTrinhDoNN == 0 )
                {
                    _NhanVien_NgoaiNguList.RemoveAt(i);
                }
            }
            NgoaiNgu_NhanVien_bindingSource.DataSource = _NhanVien_NgoaiNguList;
        }

        public void KhoiTaoBanDau()
        {
            _ngoaiNguList = NgoaiNguList.GetNgoaiNguList();            
            this.NgoaiNgu_BindingSource.DataSource = _ngoaiNguList;
            _trinhDoList = TrinhDoNgoaiNguClassList.GetTrinhDoNgoaiNguClassList();
            this.TrinhDoNgoaiNgu_BindingSource.DataSource = _trinhDoList;
        }

        private void grd_DSDiaChiNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            

        
           

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaNgoaiNgu"].EditorComponent=cbNgoaiNgu;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaNgoaiNgu"].Hidden = false;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaNgoaiNgu"].Header.Caption = "Ngoại Ngữ";
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaNgoaiNgu"].Width = cbNgoaiNgu.Width;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaNgoaiNgu"].Header.VisiblePosition = 0;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaTrinhDoNN"].EditorComponent = cbTrinhDoNgoaiNgu;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaTrinhDoNN"].Hidden = false;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaTrinhDoNN"].Header.Caption = " Trình Độ Ngoại Ngữ";
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaTrinhDoNN"].Width = cbNgoaiNgu.Width;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["MaTrinhDoNN"].Header.VisiblePosition = 1;

            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["NgoaiNguChinh"].Hidden = false;
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["NgoaiNguChinh"].Header.Caption = "Ngoại Ngữ Chính";            
            grd_DSDiaChiNhanVien.DisplayLayout.Bands[0].Columns["NgoaiNguChinh"].Header.VisiblePosition = 2;
            
        }

        private void grd_DSDiaChiNhanVien_CellChange(object sender, CellEventArgs e)
        {
            if (grd_DSDiaChiNhanVien.Rows.Count > 0)
            {
                grd_DSDiaChiNhanVien.UpdateData();
            }
        }

        private void frmNhanVien_NgoaiNgu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.grd_DSDiaChiNhanVien.UpdateData();
            this.NgoaiNgu_NhanVien_bindingSource.EndEdit();
        }

     
    }
}