using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmThuChi_ButToanMucNganSach : Form
    {
        public  CongDoan_ButToanMucNganSachList _list=CongDoan_ButToanMucNganSachList.NewCongDoan_ButToanMucNganSachList();
        int maButToan = 0;
        public  bool IsSave = false;
        TieuMucNganSachList _tieuMucList=TieuMucNganSachList.NewTieuMucNganSachList();
        decimal soTienDefault = 0;
        string dienGiaiDefault = string.Empty;
        public frmThuChi_ButToanMucNganSach()
        {
            InitializeComponent();
            this.ButToanMucNganSach_BindingSource.DataSource = typeof(CongDoan_ButToanMucNganSachList);
            this.TieuMucNganSach_BindingSource.DataSource = typeof(TieuMucNganSachList);
            this.grdData.DataSource = ButToanMucNganSach_BindingSource;
            this.ultraCombo_MaTieuMuc.DataSource = TieuMucNganSach_BindingSource;
        }

        public frmThuChi_ButToanMucNganSach(CongDoan_ButToanMucNganSachList list,decimal soTien,string dienGiai)
        {
            InitializeComponent();

            this.ButToanMucNganSach_BindingSource.DataSource = typeof(CongDoan_ButToanMucNganSachList);
            this.TieuMucNganSach_BindingSource.DataSource = typeof(TieuMucNganSachList);
            this.grdData.DataSource = ButToanMucNganSach_BindingSource;
            this.ultraCombo_MaTieuMuc.DataSource = TieuMucNganSach_BindingSource;

            LayDuLieu();

            _list = list;
            this.soTienDefault = soTien;
            this.dienGiaiDefault = dienGiai;
        }

        private void frmThuChi_ButToanMucNganSach_Load(object sender, EventArgs e)
        {
            LayDuLieu();

        }
        private void LayDuLieu()
        {
            _tieuMucList = TieuMucNganSachList.GetTieuMucNganSachList();
            this.TieuMucNganSach_BindingSource.DataSource = _tieuMucList;
            _list = CongDoan_ButToanMucNganSachList.GetCongDoan_ButToanMucNganSachList(maButToan);
            this.ButToanMucNganSach_BindingSource.DataSource = _list;

        }
        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
           
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdData.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Header.Caption = "Mã Tiểu Mục";
            grdData.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Header.VisiblePosition = 0;
          //  grdData.DisplayLayout.Bands[0].Columns["MaTieuMuc"].EditorComponent = ultraCombo_MaTieuMuc;

            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;
            
        }

        private void grdData_AfterRowInsert(object sender, RowEventArgs e)
        {
            decimal soTienDaNhap = 0;
            foreach (CongDoan_ButToanMucNganSach mns in _list)
            {
                soTienDaNhap += mns.SoTien;
            }
            ((CongDoan_ButToanMucNganSach)ButToanMucNganSach_BindingSource.Current).DienGiai = dienGiaiDefault;
            ((CongDoan_ButToanMucNganSach)ButToanMucNganSach_BindingSource.Current).SoTien = soTienDefault - soTienDaNhap;
            e.Row.Update();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
            this.ButToanMucNganSach_BindingSource.EndEdit();
            _list.ApplyEdit();
            IsSave = true;
            this.Close();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {

        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultraCombo_MaTieuMuc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);

            foreach (UltraGridColumn col in this.ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Tiểu Mục";
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].EditorComponent = ultraCombo_MaTieuMuc;

            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Hidden = false;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.Caption = "Số Tiền";
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.VisiblePosition = 1;
            
        }
    }
}
