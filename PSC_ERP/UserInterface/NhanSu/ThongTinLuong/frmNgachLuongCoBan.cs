using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;


namespace PSC_ERP
{
    public partial class frmNgachLuongCoBan : Form
    {

        #region Properties
        NgachLuongCoBanList _NgachLuongCoBanList;
        NgachLuongCoBan _NgachLuongCoBan;
        NhomNgachLuongCoBanList _nhomNgachLuongList;
        
        ChucVuList _ChucVuList;
        public delegate void PassData(NgachLuongCoBanList value);
        public PassData passData;
        int maNhomNgachLuong = 0;
        Util util = new Util();
        #endregion

        #region Events
        public frmNgachLuongCoBan()
        {
            InitializeComponent();
            this.Load_Source();
        }

        private void Load_Source()
        {
            _nhomNgachLuongList = NhomNgachLuongCoBanList.GetNhomNgachLuongCoBanListAll();
            this.bindingSource1_NhomNgachLuong.DataSource = _nhomNgachLuongList;
            _ChucVuList = ChucVuList.GetChucVuListAll();
            BindS_ChucVu.DataSource = _ChucVuList;
        }

        private void LayDuLieuLenLuoi()
        {
            try
            {
                _NgachLuongCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanList();
                NgachLuongCoBanBindingSource.DataSource = _NgachLuongCoBanList;
            }
            catch (ApplicationException)
            {

            }
        }

        private void frmNgachLuongCoBan_Load(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
        }

        private bool KiemTraControl()
        {
            bool kq = true;
            //foreach (Control control in grbNgachLuongCoBan.Controls)
            //{
            //    if (errorProvider1.GetError(control) != String.Empty)
            //    {
            //        //if (control.Name == ultratxtMaNgachLuongCB.Name)
            //        //{
            //        //    MessageBox.Show(this, "Vui lòng nhập mã ngạch lương", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        //    control.Focus();
            //        //    kq = false;
            //        //    return kq;
            //        //}                   
                   
            //    }
            //}
            return kq;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
                if (KiemTraControl() == false)
                    return;
                else
                {
                    try
                    {
                        //for (int i = 0; i < _NgachLuongCoBanList.Count; i++)
                        //{
                        //    _NgachLuongCoBanList[i].MaNhomNgachLuongCoBan = maNhomNgachLuong;
                        //}
                            _NgachLuongCoBanList.ApplyEdit();
                        _NgachLuongCoBanList.Save();
                        MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LayDuLieuLenLuoi();
                        if (passData != null)
                        {
                            passData(_NgachLuongCoBanList);
                        }
                    }
                    catch (ApplicationException)
                    {

                    }
                }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraControl() == false)
                {
                    return;
                }
                for (int i = 0; i < _NgachLuongCoBanList.Count; i++)
                {
                    _NgachLuongCoBan = _NgachLuongCoBanList[i];
                    if (_NgachLuongCoBan.MaQuanLy == "")
                    {
                        return;
                    }
                }
                _NgachLuongCoBan = NgachLuongCoBan.NewNgachLuongCoBan();
                _NgachLuongCoBanList.Add(_NgachLuongCoBan);
                NgachLuongCoBanBindingSource.DataSource = _NgachLuongCoBanList;
                ultragrdNgachLuongCoBan.ActiveRow = ultragrdNgachLuongCoBan.Rows[_NgachLuongCoBanList.Count - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdNgachLuongCoBan.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ultragrdNgachLuongCoBan.DeleteSelectedRows();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region ultragrdNgachLuongCoBan_InitializeLayout
        private void ultragrdNgachLuongCoBan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["MaNhomNgachLuongCoBan"].EditorComponent = cbNhomNgachLuong;
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["MaNhomNgachLuongCoBan"].Width = cbNhomNgachLuong.Width;
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["MaNhomNgachLuongCoBan"].Header.Caption="Tên Nhóm Ngạch";
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["MaNhomNgachLuongCoBan"].Header.VisiblePosition=0;
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["Tenchucvu"].Hidden = true;
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["MaNgachLuongCoBan"].Hidden = true;
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã QL";
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 150;
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.Caption = "Tên Ngạch Lương Bảo Hiểm";
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.VisiblePosition = 2;
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Width = 150;
            
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["Machucvu"].Hidden = true;
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["ThoiGianNangBac"].Header.Caption = "TG Nâng Bậc(tháng)";
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["ThoiGianNangBac"].Header.VisiblePosition = 3;
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["ThoiGianNangBac"].Width = 150;

            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["DonViThoiGian"].Hidden = true;
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["DonViThoiGian"].Header.VisiblePosition = 3;
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["DonViThoiGian"].Width = 120;

            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Ghi Chú";
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 5;
            ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 250;

            ultragrdNgachLuongCoBan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.ultragrdNgachLuongCoBan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.ultragrdNgachLuongCoBan.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        private void cmbu_ChucVu_AfterCloseUp(object sender, EventArgs e)
        {
          
        }

        private void cbNhomNgachLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbNhomNgachLuong.Value != null)
            {
                /*
                maNhomNgachLuong = Convert.ToInt32(cbNhomNgachLuong.Value);
                _NgachLuongCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanListByNhomNgach(maNhomNgachLuong);
                NgachLuongCoBanBindingSource.DataSource = _NgachLuongCoBanList;
               */
            }
        }

        private void ultragrdNgachLuongCoBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ultragrdNgachLuongCoBan.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdNgachLuongCoBan);
        }


    }
}

