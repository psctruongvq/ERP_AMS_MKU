using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using PSC_ERP;


namespace PSC_ERP
{// 4-1-2010
    public partial class frmDinhKhoan_MucNganSach : Form
    {
        #region Properties
        TieuMucNganSachList _TieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        ButToanMucNganSach _ButToanMucNganSach;
        ButtoanMucNganSachList _ButtoanMucNganSachList = ButtoanMucNganSachList.NewButtoanMucNganSachList(); 
        public ButToan _Buttoan;
        Util _Util = new Util();
        decimal SoTien = 0;
        string diengiai = string.Empty;    
        #endregion

        #region Events

        private void LayDuLieu()
        {
            _TieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach_BindingSource.DataSource = _TieuMucNganSachList;

            //_ButToanMucNganSach = ButToanMucNganSach.NewButToanMucNganSach();
            //_Buttoan.MucNganSach.Add(_ButToanMucNganSach);
            ButToanMucNganSach_BindingSource.DataSource = _Buttoan.MucNganSach;
            //ugrDSButToanMucNganSach.ActiveRow = ugrDSButToanMucNganSach.Rows[_Buttoan.MucNganSach.Count - 1];
        }
        private void LayDuLieuTheoButToan(ButToan bt)
        {
            _ButtoanMucNganSachList=ButtoanMucNganSachList.GetButtoanMucNganSachListByMaButToan(bt.MaButToan);
            LayDuLieu();
            _Buttoan.MucNganSach=_ButtoanMucNganSachList;
            ButToanMucNganSach_BindingSource.DataSource = _Buttoan.MucNganSach;
        }
        public frmDinhKhoan_MucNganSach(ButToan bt, decimal soTien)
        {
            InitializeComponent();
            _Buttoan = bt;
          // unumTongTien.Value = soTien;
          //tran sua
            unumTongTien.Value = bt.SoTien;
            SoTien = bt.SoTien;
            diengiai = bt.DienGiai;
            LayDuLieu();
        }
        public frmDinhKhoan_MucNganSach(ButToan bt)
        {
            InitializeComponent();
            _Buttoan = bt;           
            LayDuLieuTheoButToan(bt);
        }

        private void ThemMoi()
        {
            //_ButToanMucNganSach = ButToanMucNganSach.NewButToanMucNganSach();
            //_Buttoan.MucNganSach.Add(_ButToanMucNganSach);
            ////ugrDSButToanMucNganSach.ActiveRow = ugrDSButToanMucNganSach.Rows[_Buttoan.MucNganSach.Count - 1];

            
            _ButToanMucNganSach = ButToanMucNganSach.NewButToanMucNganSach();
            _ButToanMucNganSach.DienGiai= diengiai;
            // tran them
            SoTien = (decimal)unumTongTien.Value;
            foreach (ButToanMucNganSach buttoanMucNganSach in _Buttoan.MucNganSach)
            {
                if (SoTien != 0)
                    SoTien -= buttoanMucNganSach.SoTien;
            }
            unumSoTien.Value = SoTien;
            _ButToanMucNganSach.SoTien = SoTien;
            //
           // ultraedit_DienGiai.Text = diengiai;
            _Buttoan.MucNganSach.Add(_ButToanMucNganSach);
            ButToanMucNganSach_BindingSource.DataSource = _Buttoan.MucNganSach;
            ugrDSButToanMucNganSach.ActiveRow = ugrDSButToanMucNganSach.Rows[_Buttoan.MucNganSach.Count - 1];
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            ThemMoi();
            
            
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Decimal sum = 0;
            foreach (ButToanMucNganSach buttoanMucNganSach in _Buttoan.MucNganSach)
            {
                if (buttoanMucNganSach.SoTien == 0)
                {
                    MessageBox.Show(this, "Vui lòng nhập đầy đủ tiền.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                sum += buttoanMucNganSach.SoTien;
            }
            foreach (ButToanMucNganSach buttoanMucNganSach in _Buttoan.MucNganSach)
            {
                if (buttoanMucNganSach.MaTieuMucNganSach == 0)
                {
                    MessageBox.Show(this, "Phải chọn tiểu mục ngân sách cho các mục đã chọn.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            if (_Buttoan.SoTien == sum)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Vui Lòng Nhâp Số Tiền Mục Ngân Sách Bằng Số Tiền Bút Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ButToanMucNganSach_BindingSource.EndEdit();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ugrDSButToanMucNganSach.Selected.Rows.Count == 0)
            {
                MessageBox.Show(_Util.chodongcanxoa, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ugrDSButToanMucNganSach.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void unumSoTien_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void utxeditTenMuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThemMoi();
                ultraCombo_MaTieuMuc.Focus();
            }
        }

        private void ultraedit_DienGiai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThemMoi();
                ultraCombo_MaTieuMuc.Focus();
            }
        }
        #endregion

        #region InitializeLayout
        private void ugrDSButToanMucNganSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            foreach (UltraGridColumn col in this.ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                    col.CellAppearance.TextHAlign = HAlign.Center;
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###,###.##";
                    //col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
                    //col.Format = "###,###,###,###,###,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["MaButToanMucNganSach"].Header.Caption = "STT";
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["MaButToanMucNganSach"].Hidden = false;
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["MaButToanMucNganSach"].Header.VisiblePosition = 0;

            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["SoTien"].Width = 125;

            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 275;

        }

        private void ultraCombo_MaTieuMuc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
      
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Hidden = false;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.Caption = "Mã Mục";
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.VisiblePosition = 0;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Width = 100;

            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Tiểu Mục";
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 100;

            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Hidden = false;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.Caption = "Tên Tiểu Mục";
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.VisiblePosition = 2;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Width = 300;

            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Hidden = true;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Hidden = true;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["Chon"].Hidden = true;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Hidden = true;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Hidden = true;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaMucNganSach"].Hidden = true;

        }

           
        #endregion    

        private void ultraCombo_MaTieuMuc_KeyDown(object sender, KeyEventArgs e)
        {
            FilterCombo _filterCombo = new FilterCombo(ultraCombo_MaTieuMuc, "TenTieuMuc");
        }

        private void frmDinhKhoan_MucNganSach_FormClosed(object sender, FormClosedEventArgs e)
        {
             ButToanMucNganSach_BindingSource.EndEdit();
        }
      
    }
}