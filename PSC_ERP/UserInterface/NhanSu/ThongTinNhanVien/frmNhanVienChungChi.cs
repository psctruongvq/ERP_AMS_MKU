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
    public partial class frmNhanVienChungChi : Form
    {
        public NhanVien_ChungChiList _NhanVien_ChungChiList;


        public frmNhanVienChungChi(NhanVien_ChungChiList dcList)
        {
            InitializeComponent();
            KhoiTaoBanDau();
            _NhanVien_ChungChiList = dcList;
            for (int i = 0; i < _NhanVien_ChungChiList.Count; i++)
            {
                if (_NhanVien_ChungChiList[i].ManhanvienChungchi == 0 && _NhanVien_ChungChiList[i].TenChungChi =="")
                {
                    _NhanVien_ChungChiList.RemoveAt(i);
                }
            }
            ChungChi_NhanVien_bindingSource.DataSource = _NhanVien_ChungChiList;
        }

        public void KhoiTaoBanDau()
        {
           
        }

        private void grd_DSDiaChiNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            

         
           

            
        }

        private void frmNhanVienChungChi_FormClosed(object sender, FormClosedEventArgs e)
        {
            grd_DSDiaChiNhanVien.UpdateData();
        }

        private void frmNhanVienChungChi_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.grd_DSDiaChiNhanVien.UpdateData();
            this.ChungChi_NhanVien_bindingSource.EndEdit();
        }

     
    }
}