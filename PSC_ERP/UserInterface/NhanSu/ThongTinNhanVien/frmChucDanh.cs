
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmChucDanh : Form
    {
        Util util = new Util();
        NhomChucDanhList _NhomChucDanhList;
        ChucDanhList _ChucDanhList;
       
        public delegate void PassData(ChucDanhList value);
        public PassData getData;
        NgachLuongNoiBoList _NgachLuongKinhDoanhList;
        public frmChucDanh()
        {
            InitializeComponent();
            
            cmbu_NhomChucDanh.Visible = false;
            try
            {
                _NhomChucDanhList = NhomChucDanhList.GetNhomChucDanhList();
                NhomChucDanh_bindingSource.DataSource = _NhomChucDanhList;
                

            }
            catch (ApplicationException)
            {

            }
            this.Load_Luoi();
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _ChucDanhList.Count; i++)
            {
                for (int j = 0; j < _ChucDanhList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_ChucDanhList[i].MaQuanLy.Trim() == _ChucDanhList[j].MaQuanLy.Trim())
                        {
                            ChucDanh cd = ChucDanh.GetChucDanh(_ChucDanhList[i].MaChucDanh);
                            MessageBox.Show(this, "Chức danh " + cd.TenChucDanh.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_ChucDanh.ActiveRow = grdu_ChucDanh.Rows[i];
                            grdu_ChucDanh.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void Load_Luoi()
        {
            try
            {
                _ChucDanhList = ChucDanhList.GetChucDanhList();
                ChucDanh_bindingSource.DataSource = _ChucDanhList;
            }
            catch (ApplicationException)
            {

            }
        }

        private void grdu_ChucDanh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            grdu_ChucDanh.DisplayLayout.Bands[0].Columns["MaChucDanh"].Hidden = true;            
            grdu_ChucDanh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            grdu_ChucDanh.DisplayLayout.Bands[0].Columns["TenChucDanh"].Header.Caption = "Tên Chức Danh";
            grdu_ChucDanh.DisplayLayout.Bands[0].Columns["MaNhomChucDanh"].Header.Caption = "Nhóm Chức Danh";
           
            grdu_ChucDanh.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            grdu_ChucDanh.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_ChucDanh.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 200;

            grdu_ChucDanh.DisplayLayout.Bands[0].Columns["MaNhomChucDanh"].EditorComponent = cmbu_NhomChucDanh;
          
            
            grdu_ChucDanh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            grdu_ChucDanh.DisplayLayout.Bands[0].Columns["TenChucDanh"].Header.VisiblePosition = 1;
            grdu_ChucDanh.DisplayLayout.Bands[0].Columns["MaNhomChucDanh"].Header.VisiblePosition = 2;
            //grdu_ChucDanh.DisplayLayout.Bands[0].Columns["MaChucVu"].Header.VisiblePosition = 3;
            grdu_ChucDanh.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 4;            
            grdu_ChucDanh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 100;
                        
            //grdu_ChucDanh.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //this.grdu_ChucDanh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_ChucDanh.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();

        }
        private void Save()
        {
            ChucDanh chucDanh;
            for (int i = 0; i < _ChucDanhList.Count; i++)
            {
                chucDanh = _ChucDanhList[i];
                if (chucDanh.MaQuanLy == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Chức Danh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_ChucDanh.ActiveRow = grdu_ChucDanh.Rows[i + 1];
                    grdu_ChucDanh.Focus();
                    return;
                }
                else if (chucDanh.TenChucDanh == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Quốc Gia", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_ChucDanh.ActiveRow = grdu_ChucDanh.Rows[i + 1];
                    grdu_ChucDanh.Focus();
                    return;
                }
            }
            if (KiemTraMaQuanLy() == true)
            {
                try
                {
                    _ChucDanhList.ApplyEdit();
                    _ChucDanhList.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (getData != null)
                    {
                        getData(_ChucDanhList);
                    }
                }
                catch (ApplicationException)
                {

                }
                //this.Load_Luoi();
            }
        }
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChucDanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F1)
            {
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                Load_Luoi();
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

        private void grdu_ChucDanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              //  grdu_ChucDanh.UpdateData();
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_ChucDanh.DeleteSelectedRows();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_ChucDanh);
        }
    }
}
