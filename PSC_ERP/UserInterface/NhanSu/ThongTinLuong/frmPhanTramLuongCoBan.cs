using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmPhanTramLuongCoBan : Form
    {
        private ERP_Library.PhanTramLuongCoBanList _Data;
        ThongTinNhanVienTongHopList _ttnvlist;
       
   
        public frmPhanTramLuongCoBan()
        {
            InitializeComponent();
        }

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                if (_Data != null && _Data.IsDirty)
                    if (MessageBox.Show("Dữ liệu đã được thay đổi.\r\nBạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Question)== DialogResult.Yes)
                        SaveData();
                _Data = ERP_Library.PhanTramLuongCoBanList.GetPhanTramLuongCoBanList((int)cmbKyLuong.Value);
                bdData.DataSource = _Data;
       
            }
        }

        private bool SaveData()
        {
            if (_Data != null)
            {
                try
                {
                    bdData.EndEdit();
                    _Data.Save();
                }
                catch (Exception ex)
                {
                    frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _Data);
                    return false;
                }
            }
            return true;
        }

        private void frmPhanTramLuongCoBan_Load(object sender, EventArgs e)
        {
            ERP_Library.BoPhanList bp = ERP_Library.BoPhanList.GetBoPhanList();
            ERP_Library.NhanVienComboList nv = ERP_Library.NhanVienComboList.GetNhanVienAll();
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            cmbBoPhan.DataSource = bp;
            cmbBoPhan.DisplayMember = "TenBoPhan";
            cmbBoPhan.ValueMember = "MaBoPhan";
            foreach (ERP_Library.BoPhan i in bp)
                grdData.DisplayLayout.ValueLists["BoPhan"].ValueListItems.Add(i.MaBoPhan, i.TenBoPhan);
            //foreach (ERP_Library.NhanVienComboListChild i in nv)
            //    grdData.DisplayLayout.ValueLists["NhanVien"].ValueListItems.Add(i.MaNhanVien, i.TenNhanVien);
            _ttnvlist=ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_ByBophan(0);
            bd_NhanVien.DataSource = _ttnvlist;
            cmbNhanVien.DataSource = bd_NhanVien;

        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                MessageBox.Show("Đã lưu dữ liệu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (_Data != null)
            {
                bdData.AddNew();
                grdData.ActiveRow = grdData.Rows[grdData.Rows.Count - 1];
                grdData.ActiveRow.Selected = true;
            }
            else
                MessageBox.Show("Chọn Tháng lương trước khi thêm dữ liệu", "Điều chỉnh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa điều chỉnh này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                _Data = ERP_Library.PhanTramLuongCoBanList.GetPhanTramLuongCoBanList((int)cmbKyLuong.Value);
                bdData.DataSource = _Data;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            int id = 0;
            if (cmbBoPhan.ActiveRow!=null)
            {
                if (Convert.ToInt32(cmbBoPhan.ActiveRow.Cells["MaBoPhan"].Value) != 0)
                {
                    try
                    {
                        id = (int)cmbBoPhan.Value;
                        _ttnvlist = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong(id, false);
                        bd_NhanVien.DataSource = _ttnvlist;
                        cmbNhanVien.DataSource = bd_NhanVien;
                    }
                    catch { }
                }
            }
        }
       
        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                _Data = ERP_Library.PhanTramLuongCoBanList.GetPhanTramLuongCoBanList((int)cmbKyLuong.Value);
                bdData.DataSource = _Data;
                grdData.DataSource = _Data;
            }
        }

        private void cmbBoPhan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbBoPhan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbBoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition =1;
            cmbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbBoPhan.Width;
            cmbBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;
        }

        private void grdData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Header.Appearance.BackColor = System.Drawing.Color.White;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    //col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "#,###.##";
                }
            }
            grdData.DisplayLayout.Bands[0].Columns["MaBophan"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaBophan"].Header.Caption = "Bộ Phận";
            grdData.DisplayLayout.Bands[0].Columns["MaBophan"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["MaBophan"].EditorComponent = cmbBoPhan;
            grdData.DisplayLayout.Bands[0].Columns["MaBophan"].Width = 100;

            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Nhân Viên";
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;

            grdData.DisplayLayout.Bands[0].Columns["PhanTram"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["PhanTram"].Header.Caption = "% Lương Kỳ 1";
            grdData.DisplayLayout.Bands[0].Columns["PhanTram"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["PhanTram"].Width = 80;

            grdData.DisplayLayout.Bands[0].Columns["PhanTramV2"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["PhanTramV2"].Header.Caption = "% Lương Kỳ 2";
            grdData.DisplayLayout.Bands[0].Columns["PhanTramV2"].Header.VisiblePosition = 3;
            grdData.DisplayLayout.Bands[0].Columns["PhanTramV2"].Width = 80;
            
            grdData.DisplayLayout.Bands[0].Columns["LyDo"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["LyDo"].Header.Caption = "Lý Do";
            grdData.DisplayLayout.Bands[0].Columns["LyDo"].Header.VisiblePosition = 4;
            grdData.DisplayLayout.Bands[0].Columns["LyDo"].Width = 80;
        }

        private void cmbNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbNhanVien, "TenNhanVien");
            foreach (UltraGridColumn col in this.cmbNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbNhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
            cmbNhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 0;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 80;

            cmbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            cmbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 250;
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }



    }
}