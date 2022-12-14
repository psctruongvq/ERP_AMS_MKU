
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
namespace PSC_ERP
{
    public partial class frmQuaTrinhCongTacNuocNgoai : Form
    {
        BoPhanList _boPhanList;
        NguonList _nguonList;
        QuocGiaList _quocGiaList;
        private ERP_Library.CongTacNuocNgoaiList _Data;
        DateTime tuNgay = DateTime.Today.Date;
        DateTime denNgay = DateTime.Today.Date;
        TTNhanVienRutGonList _nhanVienList;
        public frmQuaTrinhCongTacNuocNgoai()
        {
          
            InitializeComponent();
        }
        private void ComboChanged()
        {
            _Data = ERP_Library.CongTacNuocNgoaiList.GetCongTacNuocNgoaiList(tuNgay, denNgay);
            CongTacNuocNgoaiListBindingSource.DataSource = _Data;
        }
        private void frmDaoTaoNgoaiList_Load(object sender, EventArgs e)
        {
            _boPhanList = BoPhanList.GetBoPhanListByAll();
           
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListAll();         
            this.bindingSource2_nhanVien.DataSource = _nhanVienList;
            _nguonList = NguonList.GetNguonList();
            Nguon itemAdd = Nguon.NewNguon("Không Có");
            _nguonList.Insert(0, itemAdd);
            this.bindingSource1_Nguon.DataSource = _nguonList;
            _quocGiaList = QuocGiaList.GetQuocGiaList();
            this.bindingSource1_QuocGia.DataSource = _quocGiaList;
            _Data = ERP_Library.CongTacNuocNgoaiList.GetCongTacNuocNgoaiList(tuNgay, denNgay);
            CongTacNuocNgoaiListBindingSource.DataSource = _Data;
        
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTuNgay_ValueChanged(object sender, EventArgs e)
        {
            tuNgay = Convert.ToDateTime(dateTuNgay.Value.Date);
            ComboChanged();
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            denNgay = Convert.ToDateTime(dateDenNgay.Value.Date);
            ComboChanged();
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
        }

        private void cbNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbNhanVien, "TenNhanVien");
        }

        private void cbNguon_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbNguon, "TenNguon");
        }

        private void cbQuocGia_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbQuocGia, "TenQuocGia");
        }
        private void Save()
        {
            this.CongTacNuocNgoaiListBindingSource.EndEdit();
            this.grdData.UpdateData();
            _Data.ApplyEdit();
            _Data.Save();
            MessageBox.Show("Cập nhật thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
           
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            ComboChanged();
        }

        private void tlslblThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
                _nhanVienList = TTNhanVienRutGonList.GetNhanVienListBoPhan(Convert.ToInt32(cmbu_Bophan.Value));
                this.bindingSource2_nhanVien.DataSource = _nhanVienList;
            }
        }

        private void frmQuaTrinhCongTacNuocNgoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            else if (e.KeyCode == Keys.U)
            {
                ComboChanged();
            }
        }

       
    }
}