using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using PSC_ERP_Common;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP.UserInterface.NhanSu.TongHopThuLao
{
    public partial class frmChonDuLieuImport : Form
    {
        BoPhanList _boPhanList;
        QuocGiaList _quocGiaList;
        int _maBoPhan = 0;
        int _maQuocGia = 0;

        public frmChonDuLieuImport()
        {
            InitializeComponent();

            LoadForm();
        }

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                }
            }
        }
        public int MaQuocGia
        {
            get
            {
                return _maQuocGia;
            }
            set
            {
                if (!_maQuocGia.Equals(value))
                {
                    _maQuocGia = value;
                }
            }
        }
        private void LoadForm()
        {
            _boPhanList = BoPhanList.GetBoPhanListByAll();
            //BoPhan itemBoPhan = BoPhan.NewBoPhan("Tất Cả");
            //_boPhanList.Insert(0, itemBoPhan);
            this.BoPhan_BindingSource.DataSource = _boPhanList;

            //
            _quocGiaList = QuocGiaList.GetQuocGiaList();
            QuocGia_BindingSource.DataSource = _quocGiaList;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (cmbuBoPhan.Value == null)
            {
                DialogUtil.ShowWarning("Chọn bộ phận cần import.");
                return;
            }
            if (cmbuBoPhan.Value == null)
            {
                DialogUtil.ShowWarning("Chọn quốc gia cần import.");
                return;
            }

            _maBoPhan = Convert.ToInt32(cmbuBoPhan.Value);
            _maQuocGia = Convert.ToInt32(cmbuQuocGia.Value);

            this.Close();
        }

        private void cmbuBoPhan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbuBoPhan, "MaBoPhanQL");
            foreach (UltraGridColumn col in this.cmbuBoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbuBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;
            cmbuBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbuBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Quản Lý";
            cmbuBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Width = cmbuBoPhan.Width;

            cmbuBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbuBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbuBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbuBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbuBoPhan.Width;


        }

        private void cmbuQuocGia_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbuQuocGia, "MaQuocGiaQuanLy");
            foreach (UltraGridColumn col in this.cmbuQuocGia.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbuQuocGia.DisplayLayout.Bands[0].Columns["MaQuocGiaQuanLy"].Header.VisiblePosition = 0;
            cmbuQuocGia.DisplayLayout.Bands[0].Columns["MaQuocGiaQuanLy"].Hidden = false;
            cmbuQuocGia.DisplayLayout.Bands[0].Columns["MaQuocGiaQuanLy"].Header.Caption = "Mã Quản Lý";
            cmbuQuocGia.DisplayLayout.Bands[0].Columns["MaQuocGiaQuanLy"].Width = cmbuBoPhan.Width;

            cmbuQuocGia.DisplayLayout.Bands[0].Columns["TenQuocGia"].Header.VisiblePosition = 0;
            cmbuQuocGia.DisplayLayout.Bands[0].Columns["TenQuocGia"].Hidden = false;
            cmbuQuocGia.DisplayLayout.Bands[0].Columns["TenQuocGia"].Header.Caption = "Tên Quốc Gia";
            cmbuQuocGia.DisplayLayout.Bands[0].Columns["TenQuocGia"].Width = cmbuBoPhan.Width;
        }

        private void frmChonDuLieuImport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnImport_Click(sender,e);
            }
            else if (e.Alt && e.KeyCode == Keys.X)
            {
                this.Close();
            }
        }
    }
}
